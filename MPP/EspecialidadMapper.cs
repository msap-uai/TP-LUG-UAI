using BE;
using System;
using Microsoft.Data.SqlClient;

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
