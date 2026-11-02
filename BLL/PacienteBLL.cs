using System.Collections.Generic;
using DAL;
using BE;

namespace BLL
{
    public class PacienteBLL
    {

        
        public List<Paciente> ObtenerPacientes()
        {
            return PacienteDAL.ObtenerPacientes();
        }



        public List<Paciente> ObtenerPacientesPorObraSocial(int idObraSocial)
        {
            return PacienteDAL.ObtenerPacientesPorObraSocial(idObraSocial);
        }
        
    }
}
