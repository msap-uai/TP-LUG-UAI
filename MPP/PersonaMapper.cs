using BE;
using System;
using Microsoft.Data.SqlClient;

namespace MPP
{
    public static class PersonaMapper
    {
        public static Persona Map(SqlDataReader sqlDataReader)
        {
            int id = Convert.ToInt32(sqlDataReader["ID_PERSONA"]);
            string nombre = Convert.ToString(sqlDataReader["NOMBRE"]);
            string apellido = Convert.ToString(sqlDataReader["APELLIDO"]);
            string dni = Convert.ToString(sqlDataReader["DNI"]);
            string telefono = Convert.ToString(sqlDataReader["TELEFONO"]);
            string mail = Convert.ToString(sqlDataReader["MAIL"]);

            Persona persona = new Persona(id, nombre, apellido, dni, telefono, mail);

            return persona;
        }
    }
}
