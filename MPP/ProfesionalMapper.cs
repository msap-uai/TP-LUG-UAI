using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP
{
    public class ProfesionalMapper
    {
        public static Profesional Map(SqlDataReader sqlDataReader)
        {
            int idProfesional = Convert.ToInt32(sqlDataReader["ID_PROFESIONAL"]);

            int idPersona = Convert.ToInt32(sqlDataReader["ID_PERSONA"]);

            string nombre = Convert.ToString(sqlDataReader["NOMBRE"]);

            string apellido = Convert.ToString(sqlDataReader["APELLIDO"]);

            string dni = Convert.ToString(sqlDataReader["DNI"]);

            string telefono = sqlDataReader["TELEFONO"] == DBNull.Value ? null: Convert.ToString(sqlDataReader["TELEFONO"]);

            string mail = sqlDataReader["MAIL"] == DBNull.Value ? null: Convert.ToString(sqlDataReader["MAIL"]);

            string matricula = Convert.ToString(sqlDataReader["MATRICULA"]);

            int idEspecialidad = Convert.ToInt32(sqlDataReader["ID_ESPECIALIDAD"]);

            string descripcionEspecialidad = Convert.ToString(sqlDataReader["DESCRIPCION"]);

            decimal arancel = Convert.ToDecimal(sqlDataReader["ARANCEL"]);

            Especialidad especialidad = new Especialidad(idEspecialidad, descripcionEspecialidad);

            Profesional profesional = new Profesional(
                idPersona,
                idProfesional,
                nombre,
                apellido,
                dni,
                telefono,
                mail,
                matricula,
                especialidad,
                arancel
            );

            return profesional;
        }
    }
}
