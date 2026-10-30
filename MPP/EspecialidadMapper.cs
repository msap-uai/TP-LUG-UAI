using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP
{
    public class EspecialidadMapper
    {
        public static Especialidad Map(SqlDataReader sqlDataReader)
        {
            int id = Convert.ToInt32(sqlDataReader["ID_ESPECIALIDAD"]);
            string descripcion = Convert.ToString(sqlDataReader["DESCRIPCION"]);

            Especialidad especialidad = new Especialidad(id, descripcion);

            return especialidad;
        }
    }
}
