using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class ConsultaEvolucionBLL
    {
        private ConsultaEvolucionDAL dal = new ConsultaEvolucionDAL();
        
        public void RegistrarAtencion(ConsultaEvolucion consulta)
        {
            dal.AgregarConsultaEvolucion(consulta);
        }
        public List<ConsultaEvolucion> ObtenerConsultas()
        {
            return dal.ObtenerConsultasEvolucion();
        }
    }
}
