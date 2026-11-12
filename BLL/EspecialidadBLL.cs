using System;
using System.Collections.Generic;
using BE;
using DAL;

namespace BLL
{
    public static class EspecialidadBLL
    {
        public static List<Especialidad> ObtenerEspecialidades() => EspecialidadDAL.ObtenerEspecialidades();

        public static void GuardarEspecialidad(int? id, string descripcion)
        {
            int especialidadId = (id == null) ? 0 : id.Value;

            ValidarDescripcion(descripcion);

            Especialidad especialidad = new Especialidad(especialidadId, descripcion);

            if (especialidad.Id == 0)
            {
                EspecialidadDAL.AgregarEspecialidad(especialidad);
            }
            else
            {
                EspecialidadDAL.ModificarEspecialidad(especialidad);
            }
        }

        public static void EliminarEspecialidad(int id)
        {
            List<Profesional> profesionales = ProfesionalBLL.ObtenerProfesionalesPorEspecialidad(id);

            if (profesionales.Count > 0)
            {
                throw new Exception("No se puede eliminar la especialidad porque hay profesionales asociados a ella.");
            }

            EspecialidadDAL.EliminarEspecialidad(id);
        }

        private static void ValidarDescripcion(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
            {
                throw new ArgumentException("La descripción no puede estar vacía.");
            }

            if (descripcion.Length > 60)
            {
                throw new ArgumentException("La descripción no puede tener más de 60 caracteres.");
            }

            if (descripcion.Length < 3)
            {
                throw new ArgumentException("La descripción debe tener al menos 3 caracteres.");
            }
        }
    }
}
