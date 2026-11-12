using System;
using System.Collections.Generic;
using BE;
using DAL;

namespace BLL
{
    public class ConsultorioBLL
    {
        private ConsultorioDAL consultorioDAL = new ConsultorioDAL();

        public List<Consultorio> ObtenerConsultorios()
        {
            return consultorioDAL.ObtenerConsultorios();
        }

        public void AgregarConsultorio(Consultorio consultorio)
        {
            if (consultorio == null)
            {
                throw new Exception("El consultorio no puede ser nulo.");
            }

            ValidarConsultorio(consultorio);

            consultorioDAL.AgregarConsultorio(consultorio);
        }

        public void ModificarConsultorio(Consultorio consultorio)
        {
            if (consultorio == null)
            {
                throw new Exception("El consultorio no puede ser nulo.");
            }

            if (consultorio.Id <= 0)
            {
                throw new Exception("Debe seleccionar un consultorio válido para modificar.");
            }

            ValidarConsultorio(consultorio);

            consultorioDAL.ModificarConsultorio(consultorio);
        }

        public void EliminarConsultorio(int idConsultorio)
        {
            if (idConsultorio <= 0)
            {
                throw new Exception("Debe seleccionar un consultorio válido para eliminar.");
            }

            // Validar que no tenga turnos asociados
            TurnoDAL turnoDAL = new TurnoDAL();
            List<Turno> turnos = turnoDAL.ObtenerTurnos();
            foreach (var turno in turnos)
            {
                if (turno.Consultorio != null && turno.Consultorio.Id == idConsultorio)
                {
                    throw new Exception("No se puede eliminar el consultorio porque tiene turnos asignados.");
                }
            }

            consultorioDAL.EliminarConsultorio(idConsultorio);
        }

        private void ValidarConsultorio(Consultorio consultorio)
        {
            if (consultorio.Numero < 1 || consultorio.Numero > 9)
            {
                throw new Exception("El número de consultorio debe estar entre 1 y 9.");
            }

            // Validar número duplicado
            List<Consultorio> lista = consultorioDAL.ObtenerConsultorios();
            foreach (var c in lista)
            {
                if (c.Id != consultorio.Id && c.Numero == consultorio.Numero)
                {
                    throw new Exception("Ya existe un consultorio con el número " + consultorio.Numero + ".");
                }
            }
        }
    }
}
