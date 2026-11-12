using System;
using System.Collections.Generic;
using BE;
using DAL;

namespace BLL
{
    public class ProfesionalBLL
    {
        private ProfesionalDAL profesionalDAL = new ProfesionalDAL();
        private TurnoDAL turnoDAL = new TurnoDAL();

        public static List<Profesional> ObtenerProfesionalesPorEspecialidad(int idEspecialidad)
        {
            return ProfesionalDAL.ObtenerProfesionalesPorEspecialidad(idEspecialidad);
        }

        public List<Profesional> ObtenerProfesionales()
        {
            return profesionalDAL.ObtenerProfesionales();
        }

        public void GuardarProfesional(Profesional profesional)
        {
            if (profesional == null)
            {
                throw new Exception("El profesional no puede ser nulo.");
            }

            if (string.IsNullOrWhiteSpace(profesional.Matricula))
            {
                throw new Exception("La matrícula es obligatoria.");
            }

            if (profesional.Especialidad == null || profesional.Especialidad.Id == 0)
            {
                throw new Exception("Debe seleccionar una especialidad.");
            }

            if (profesional.Arancel <= 0)
            {
                throw new Exception("El arancel debe ser un importe mayor a cero.");
            }

            // Validar DNI y Matrícula duplicada
            List<Profesional> existentes = profesionalDAL.ObtenerProfesionales();
            foreach (var prof in existentes)
            {
                if (prof.IdProfesional != profesional.IdProfesional)
                {
                    if (prof.Dni == profesional.Dni)
                    {
                        throw new Exception("ya existe un profesional con ese DNI.");
                    }

                    if (prof.Matricula == profesional.Matricula)
                    {
                        throw new Exception("ya existe un profesional con esa matrícula.");
                    }
                }
            }

            if (profesional.IdProfesional == 0)
            {
                profesionalDAL.AgregarProfesional(profesional);
            }
            else
            {
                profesionalDAL.ModificarProfesional(profesional);
            }
        }

        public void EliminarProfesional(int idProfesional)
        {
            List<Turno> turnos = turnoDAL.ObtenerTurnos();
            foreach (var turno in turnos)
            {
                if (turno.Profesional != null && turno.Profesional.IdProfesional == idProfesional)
                {
                    throw new Exception("no se puede eliminar el profesional porque tiene turnos asignados.");
                }
            }

            profesionalDAL.EliminarProfesional(idProfesional);
        }
    }
}
