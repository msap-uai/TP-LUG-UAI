using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP
{
    public class ConsultorioMapper
    {
        public static Consultorio Map(SqlDataReader sqlDataReader)
        {
            int id = Convert.ToInt32(sqlDataReader["ID_CONSULTORIO"]);
            int numero = Convert.ToInt32(sqlDataReader["NUMERO_CONSULTORIO"]);

            Consultorio consultorio = new Consultorio(id, numero);

            return consultorio;
        }
    }
}
