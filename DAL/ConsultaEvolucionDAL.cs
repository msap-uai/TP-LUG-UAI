using BE;
using MPP;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class ConsultaEvolucionDAL
    {
        public void AgregarConsultaEvolucion(ConsultaEvolucion consulta)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConectionString.GetConectionString()))
                {
                    conexion.Open();

                    string query = @"INSERT INTO CONSULTA_EVOLUCION (ID_TURNO, FECHA_ATENCION, OBSERVACIONES, DIAGNOSTICO, MEDICACION, MONTO_COBRADO)
                      VALUES (@ID_TURNO, @FECHA_ATENCION, @OBSERVACIONES, @DIAGNOSTICO, @MEDICACION, @MONTO_COBRADO)";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID_TURNO", consulta.Turno.Id);

                        comando.Parameters.AddWithValue("@FECHA_ATENCION", consulta.FechaAtencion);

                        comando.Parameters.AddWithValue("@OBSERVACIONES", (object)consulta.Observaciones ?? DBNull.Value);

                        comando.Parameters.AddWithValue("@DIAGNOSTICO", (object)consulta.Diagnostico ?? DBNull.Value);

                        comando.Parameters.AddWithValue("@MEDICACION", (object)consulta.Medicacion ?? DBNull.Value);

                        comando.Parameters.AddWithValue("@MONTO_COBRADO", consulta.MontoCobrado);

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<ConsultaEvolucion> ObtenerConsultasEvolucion()
        {
            try
            {
                List<ConsultaEvolucion> lista = new List<ConsultaEvolucion>();

                using (SqlConnection conexion = new SqlConnection(ConectionString.GetConectionString()))
                {
                    conexion.Open();

                    string query = @"SELECT
                    CE.ID_CONSULTA,
                    CE.FECHA_ATENCION,
                    CE.OBSERVACIONES,
                    CE.DIAGNOSTICO,
                    CE.MEDICACION,
                    CE.MONTO_COBRADO,
                    T.ID_TURNO,
                    T.ID_PACIENTE,
                    PA.ID_PERSONA AS ID_PERSONA_PACIENTE,
                    PP.NOMBRE AS NOMBRE_PACIENTE,
                    PP.APELLIDO AS APELLIDO_PACIENTE,
                    PP.DNI AS DNI_PACIENTE,
                    PA.FECHA_NACIMIENTO,
                    T.ID_PROFESIONAL,
                    PR.ID_PERSONA AS ID_PERSONA_PROFESIONAL,
                    PPR.NOMBRE AS NOMBRE_PROFESIONAL,
                    PPR.APELLIDO AS APELLIDO_PROFESIONAL,
                    PPR.DNI AS DNI_PROFESIONAL,
                    PR.MATRICULA,
                    PR.ID_ESPECIALIDAD,
                    E.DESCRIPCION AS DESCRIPCION_ESPECIALIDAD,
                    PR.ARANCEL,
                    T.ID_CONSULTORIO,
                    C.NUMERO_CONSULTORIO,
                    T.FECHA_HORA,
                    T.ESTADO
                    FROM CONSULTA_EVOLUCION CE
                    INNER JOIN TURNO T
                    ON CE.ID_TURNO = T.ID_TURNO

                    INNER JOIN PACIENTE PA
                    ON T.ID_PACIENTE = PA.ID_PACIENTE

                    INNER JOIN PERSONA PP
                    ON PA.ID_PERSONA = PP.ID_PERSONA

                    INNER JOIN PROFESIONAL PR
                    ON T.ID_PROFESIONAL = PR.ID_PROFESIONAL

                    INNER JOIN PERSONA PPR
                    ON PR.ID_PERSONA = PPR.ID_PERSONA

                    INNER JOIN ESPECIALIDAD E
                    ON PR.ID_ESPECIALIDAD = E.ID_ESPECIALIDAD

                    INNER JOIN CONSULTORIO C
                    ON T.ID_CONSULTORIO = C.ID_CONSULTORIO";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        using (SqlDataReader sqlDataReader = comando.ExecuteReader())
                        {
                            while (sqlDataReader.Read())
                            {
                                lista.Add(ConsultaEvolucionMapper.Map(sqlDataReader));
                            }
                        }
                    }
                }

                return lista;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void ModificarConsultaEvolucion(ConsultaEvolucion consulta)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConectionString.GetConectionString()))
                {
                    conexion.Open();

                    string query = @"UPDATE CONSULTA_EVOLUCION SET
                                 FECHA_ATENCION = @FECHA_ATENCION,
                                 OBSERVACIONES = @OBSERVACIONES,
                                 DIAGNOSTICO = @DIAGNOSTICO,
                                 MEDICACION = @MEDICACION,
                                 MONTO_COBRADO = @MONTO_COBRADO
                                 WHERE ID_CONSULTA = @ID_CONSULTA
                                 AND ID_TURNO = @ID_TURNO";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@FECHA_ATENCION", consulta.FechaAtencion);

                        comando.Parameters.AddWithValue("@OBSERVACIONES",(object)consulta.Observaciones ?? DBNull.Value);

                        comando.Parameters.AddWithValue("@DIAGNOSTICO",(object)consulta.Diagnostico ?? DBNull.Value);

                        comando.Parameters.AddWithValue("@MEDICACION",(object)consulta.Medicacion ?? DBNull.Value);

                        comando.Parameters.AddWithValue("@MONTO_COBRADO", consulta.MontoCobrado);

                        comando.Parameters.AddWithValue("@ID_CONSULTA", consulta.Id);

                        comando.Parameters.AddWithValue("@ID_TURNO", consulta.Turno.Id);

                        int filasAfectadas = comando.ExecuteNonQuery();

                        if (filasAfectadas == 0)
                        {
                            throw new Exception("No se encontró la consulta que desea modificar.");
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
