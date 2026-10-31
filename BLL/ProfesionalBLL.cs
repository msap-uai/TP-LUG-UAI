using System;
using System.Collections.Generic;
using DAL;
using BE;

namespace BLL
{
    public static class ProfesionalBLL
    {
        public static List<Profesional> ObtenerProfesionalesPorEspecialidad(int idEspecialidad)
        {
            return ProfesionalDAL.ObtenerProfesionalesPorEspecialidad(idEspecialidad);
        }
    }
}
