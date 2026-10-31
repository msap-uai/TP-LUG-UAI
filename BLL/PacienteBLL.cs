using System.Collections.Generic;
using DAL;
using BE;

namespace BLL
{
    public static class PacienteBLL
    {
        public static List<Paciente> ObtenerPacientesPorObraSocial(int idObraSocial)
        {
            return PacienteDAL.ObtenerPacientesPorObraSocial(idObraSocial);
        }
    }
}
