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
            using (SqlConnection conexion = new SqlConnection(ConectionString.GetConectionString()))
            {
                conexion.Open();

                SqlTransaction transaccion = conexion.BeginTransaction();

                try
                {
                    // PRIMERA OPERACIÓN: REGISTRAR CONSULTA

                    string queryConsulta = @"INSERT INTO CONSULTA_EVOLUCION (ID_TURNO, FECHA_ATENCION, OBSERVACIONES, DIAGNOSTICO, MEDICACION, MONTO_COBRADO)
                      VALUES (@ID_TURNO, @FECHA_ATENCION, @OBSERVACIONES,@DIAGNOSTICO, @MEDICACION, @MONTO_COBRADO)";

                    using (SqlCommand comandoConsulta = new SqlCommand(queryConsulta, conexion, transaccion))
                    {
                        comandoConsulta.Parameters.AddWithValue("@ID_TURNO", consulta.Turno.Id);

                        comandoConsulta.Parameters.AddWithValue("@FECHA_ATENCION", consulta.FechaAtencion);

                        comandoConsulta.Parameters.AddWithValue("@OBSERVACIONES", (object)consulta.Observaciones ?? DBNull.Value);

                        comandoConsulta.Parameters.AddWithValue("@DIAGNOSTICO",(object)consulta.Diagnostico ?? DBNull.Value);

                        comandoConsulta.Parameters.AddWithValue("@MEDICACION",(object)consulta.Medicacion ?? DBNull.Value);

                        comandoConsulta.Parameters.AddWithValue("@MONTO_COBRADO", consulta.MontoCobrado);

                        comandoConsulta.ExecuteNonQuery();
                    }

                    // SEGUNDA OPERACIÓN: ACTUALIZAR ESTADO DEL TURNO

                    string queryTurno = @"UPDATE TURNO SET 
                        ESTADO = @ESTADO
                        WHERE ID_TURNO = @ID_TURNO AND ESTADO = @ESTADO_ACTUAL";

                    using (SqlCommand comandoTurno = new SqlCommand(queryTurno, conexion, transaccion))
                    {
                        comandoTurno.Parameters.AddWithValue("@ESTADO", EstadoTurno.Atendido.ToString());

                        comandoTurno.Parameters.AddWithValue("@ID_TURNO", consulta.Turno.Id);

                        comandoTurno.Parameters.AddWithValue("@ESTADO_ACTUAL", EstadoTurno.Pendiente.ToString());

                        int filasAfectadas = comandoTurno.ExecuteNonQuery();

                        if (filasAfectadas == 0)
                        {
                            throw new Exception("No se pudo actualizar el turno. Verifique que exista y esté pendiente.");
                        }
                    }

                    transaccion.Commit();
                }
                catch (Exception)
                {
                    transaccion.Rollback();
                    throw;
                }
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
