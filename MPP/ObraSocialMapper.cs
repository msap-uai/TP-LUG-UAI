using BE;
using System;
using Microsoft.Data.SqlClient;

namespace MPP
{
    static public class ObraSocialMapper
    {
        public static ObraSocial Map(SqlDataReader sqlDataReader)
        {
            int id = Convert.ToInt32(sqlDataReader["ID_OBRA_SOCIAL"]);
            string nombre = Convert.ToString(sqlDataReader["NOMBRE"]);

            ObraSocial obraSocial = new ObraSocial(id, nombre);

            return obraSocial;
        }

    }
}
