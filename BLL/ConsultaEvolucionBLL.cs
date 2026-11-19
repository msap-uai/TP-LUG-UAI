using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BLL
{
    public class ConsultaEvolucionBLL
    {
        private ConsultaEvolucionDAL dal = new ConsultaEvolucionDAL();

        public void RegistrarAtencion(ConsultaEvolucion consulta)
        {
            try
            {
                // VALIDACIONES DE NEGOCIO
                if (consulta == null)
                {
                    throw new Exception("La consulta médica no puede ser nula.");
                }

                if (consulta.Turno == null || consulta.Turno.Id <= 0)
                {
                    throw new Exception("Debe seleccionar un turno válido.");
                }

                ValidarDiagnostico(consulta);
                ValidarMedicacion(consulta);
               

                // VALIDAR EL ESTADO ACTUAL DEL TURNO

                TurnoDAL turnoDAL = new TurnoDAL();

                List<Turno> lista = turnoDAL.ObtenerTurnos();

                Turno turnoEncontrado = null;

                foreach (var t in lista)
                {
                    if (t.Id == consulta.Turno.Id)
                    {
                        turnoEncontrado = t;
                        break;
                    }
                }

                if (turnoEncontrado == null)
                {
                    throw new Exception("No se encontró el turno.");
                }

                if (turnoEncontrado.Estado != EstadoTurno.Pendiente)
                {
                    throw new Exception("Solo se pueden atender turnos pendientes.");
                }

                // VALIDAR PACIENTE Y PROFESIONAL
                if (turnoEncontrado.Paciente == null)
                {
                    throw new Exception("El turno no tiene un paciente asignado.");
                }

                if (turnoEncontrado.Profesional == null)
                {
                    throw new Exception("El turno no tiene un profesional asignado.");
                }

                decimal arancel = turnoEncontrado.Profesional.Arancel;

                if (arancel <= 0)
                {
                    throw new Exception("El arancel del profesional debe ser mayor a cero.");
                }

                // POLIMORFISMO
                Persona persona = turnoEncontrado.Paciente;

                consulta.MontoCobrado = persona.CalcularCostoFinal(arancel);

                // VALIDAR EL MONTO CALCULADO
                ValidarMontoCobrado(consulta);

                // UTILIZAR EL TURNO RECUPERADO
                consulta.Turno = turnoEncontrado;



                // TRANSACCIÓN
                using (TransactionScope trx = new TransactionScope())
                {
                    // PRIMERA OPERACIÓN: REGISTRAR CONSULTA
                    dal.AgregarConsultaEvolucion(consulta);

                    // SEGUNDA OPERACIÓN: ACTUALIZAR ESTADO DEL TURNO                  

                    turnoDAL.MarcarTurnoAtendido(consulta.Turno.Id);

                    // CONFIRMAR TRANSACCIÓN
                    trx.Complete();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<ConsultaEvolucion> ObtenerConsultas()
        {
            try
            {
                 return dal.ObtenerConsultasEvolucion();
            }
            catch
            {
                throw;
            }
           
        }

        private void ValidarDiagnostico(ConsultaEvolucion consulta)
        {
            try
            {
                if (consulta.Diagnostico != null && consulta.Diagnostico.Length > 500)
                {
                    throw new ArgumentException("El diagnóstico no puede superar los 500 caracteres.");
                }
            }
            catch
            {
                throw;
            }
        }

        private void ValidarMedicacion(ConsultaEvolucion consulta)
        {
            try
            {
                if (consulta.Medicacion != null && consulta.Medicacion.Length > 500)
                {
                    throw new ArgumentException("La medicación no puede superar los 500 caracteres.");
                }
            }
            catch
            {
                throw;
            }
        }

        private void ValidarMontoCobrado(ConsultaEvolucion consulta)
        {
            try
            {
                if (consulta.MontoCobrado < 0)
                {
                    throw new ArgumentException("El monto cobrado no puede ser negativo.");
                }

                if (consulta.MontoCobrado >= 100000000m)
                {
                    throw new ArgumentException("El monto cobrado debe ser menor a 100 millones.");
                }
            }
            catch
            {
                throw;
            }
        }

    }
}
