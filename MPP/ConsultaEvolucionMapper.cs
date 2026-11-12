using BE;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP
{
    public class ConsultaEvolucionMapper
    {
        public static ConsultaEvolucion Map(SqlDataReader sqlDataReader)
        {
            int idConsulta = Convert.ToInt32(sqlDataReader["ID_CONSULTA"]);

            DateTime fechaAtencion = Convert.ToDateTime(sqlDataReader["FECHA_ATENCION"]);

            string observaciones = sqlDataReader["OBSERVACIONES"] == DBNull.Value ? null : Convert.ToString(sqlDataReader["OBSERVACIONES"]);

            string diagnostico = sqlDataReader["DIAGNOSTICO"] == DBNull.Value ? null : Convert.ToString(sqlDataReader["DIAGNOSTICO"]);

            string medicacion = sqlDataReader["MEDICACION"] == DBNull.Value ? null : Convert.ToString(sqlDataReader["MEDICACION"]);

            decimal montoCobrado = Convert.ToDecimal(sqlDataReader["MONTO_COBRADO"]);

            Turno turno = TurnoMapper.Map(sqlDataReader);

            ConsultaEvolucion consulta = new ConsultaEvolucion(
                idConsulta,
                turno,
                fechaAtencion,
                observaciones,
                diagnostico,
                medicacion,
                montoCobrado
            );

            return consulta;
        }
    }
}
