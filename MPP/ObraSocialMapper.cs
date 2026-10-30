using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP
{
    public class ObraSocialMapper
    {
        public static ObraSocial Map(SqlDataReader sqlDataReader)
        {
            

            int id = Convert.ToInt32(sqlDataReader["ID_OBRA_SOCIAL"]);
            string nombre = Convert.ToString(sqlDataReader["NOMBRE"]);
            ObraSocial obraSocial = new ObraSocial(id,nombre);
            return obraSocial;
        }

    }
}
