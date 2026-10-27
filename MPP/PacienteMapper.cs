using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP
{
    public class PacienteMapper
    {
        public static Paciente Map(SqlDataReader sqlDataReader)
        {
            int idPaciente = Convert.ToInt32(sqlDataReader["ID_PACIENTE"]);
            int idPersona = Convert.ToInt32(sqlDataReader["ID_PERSONA"]);

            string nombre = Convert.ToString(sqlDataReader["NOMBRE"]);
            string apellido = Convert.ToString(sqlDataReader["APELLIDO"]);
            string dni = Convert.ToString(sqlDataReader["DNI"]);

            string telefono = sqlDataReader["TELEFONO"] == DBNull.Value
                ? null
                : Convert.ToString(sqlDataReader["TELEFONO"]);

            string mail = sqlDataReader["MAIL"] == DBNull.Value
                ? null
                : Convert.ToString(sqlDataReader["MAIL"]);

            DateTime fechaNacimiento =
                Convert.ToDateTime(sqlDataReader["FECHA_NACIMIENTO"]);

            string numeroAfiliado = sqlDataReader["NUMERO_AFILIADO"] == DBNull.Value
                ? null
                : Convert.ToString(sqlDataReader["NUMERO_AFILIADO"]);

            ObraSocial obraSocial = null;

            if (sqlDataReader["ID_OBRA_SOCIAL"] != DBNull.Value)
            {
                int idObraSocial =
                    Convert.ToInt32(sqlDataReader["ID_OBRA_SOCIAL"]);

                string nombreObraSocial =
                    Convert.ToString(sqlDataReader["NOMBRE_OBRA_SOCIAL"]);

                obraSocial = new ObraSocial(idObraSocial, nombreObraSocial);
            }

            Paciente paciente = new Paciente(
                idPersona,
                idPaciente,
                nombre,
                apellido,
                dni,
                telefono,
                mail,
                fechaNacimiento,
                obraSocial,
                numeroAfiliado
            );

            return paciente;
        }
    }
}
