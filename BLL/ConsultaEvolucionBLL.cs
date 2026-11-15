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
    }
}
