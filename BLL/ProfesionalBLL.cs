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
            try
            {
                return ProfesionalDAL.ObtenerProfesionalesPorEspecialidad(idEspecialidad);
            }
            catch
            {
                throw;
            }            
        }

        public List<Profesional> ObtenerProfesionales()
        {
            try
            {
                return profesionalDAL.ObtenerProfesionales();
            }
            catch
            {
                throw;
            }
            
        }

        public void GuardarProfesional(Profesional profesional)
        {
            try
            {
                if (profesional == null)
                {
                    throw new Exception("El profesional no puede ser nulo.");
                }

                if (profesional.Id == 0)
                {
                    throw new Exception("Debe seleccionar una persona.");
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

                // Validar que la persona no sea ya profesional y que la matrícula no esté duplicada
                List<Profesional> existentes = profesionalDAL.ObtenerProfesionales();
                foreach (var prof in existentes)
                {
                    if (prof.IdProfesional != profesional.IdProfesional)
                    {
                        if (prof.Id == profesional.Id)
                        {
                            throw new Exception("la persona seleccionada ya es profesional.");
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
            catch
            {
                throw;
            }
            
        }

        public void EliminarProfesional(int idProfesional)
        {
            try
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
            catch
            {
                throw;
            }
            
        }
    }
}
