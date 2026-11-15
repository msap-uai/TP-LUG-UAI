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

                if (profesional.Id <= 0)
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

                if (profesional.Arancel >= 1000000)
                {
                    throw new Exception("El arancel debe ser menor a un millón.");
                }

                // OBTENER PROFESIONALES EXISTENTES
                List<Profesional> existentes = profesionalDAL.ObtenerProfesionales();

                bool existe = false;

                foreach (var prof in existentes)
                {
                        if (prof.IdProfesional == profesional.IdProfesional)
                        {
                            existe= true;
                            continue;
                        }
                        if (prof.Id == profesional.Id)
                        {
                            throw new Exception("La persona seleccionada ya es profesional");
                        }
                        //VALIDAR MATRICULA DUPLICADA
                        if (prof.Matricula == profesional.Matricula)
                        {
                            throw new Exception("ya existe un profesional con esa matrícula.");
                        }
                    
                }

                if (profesional.IdProfesional == 0)
                {
                    profesionalDAL.AgregarProfesional(profesional);
                }
                else
                {
                    if (!existe)
                    {
                        throw new Exception("El profesional que intenta modificar no existe");
                    }
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
                // VALIDAR IDENTIFICADOR
                if (idProfesional <= 0)
                {
                    throw new Exception("Debe seleccionar un profesional válido para eliminar.");
                }

                // VALIDAR QUE EL PROFESIONAL EXISTA
                List<Profesional> profesionales = profesionalDAL.ObtenerProfesionales();

                bool existe = false;

                foreach (var profesional in profesionales)
                {
                    if (profesional.IdProfesional == idProfesional)
                    {
                        existe = true;
                        break;
                    }
                }

                if (!existe)
                {
                    throw new Exception("El profesional que intenta eliminar no existe.");
                }

                // VALIDAR QUE NO TENGA TURNOS ASIGNADOS
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
