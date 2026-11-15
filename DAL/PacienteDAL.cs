using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DAL
{
   public static class PacienteDAL
    {
        public static void AgregarPaciente(Paciente paciente)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConectionString.GetConectionString()))
                {
                    conexion.Open();

                    string query = @"INSERT INTO PACIENTE (ID_PERSONA, FECHA_NACIMIENTO, ID_OBRA_SOCIAL, NUMERO_AFILIADO)
                VALUES (@ID_PERSONA, @FECHA_NACIMIENTO, @ID_OBRA_SOCIAL, @NUMERO_AFILIADO)";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID_PERSONA", paciente.Id);

                        comando.Parameters.AddWithValue("@FECHA_NACIMIENTO", paciente.FechaNacimiento.Date);

                        comando.Parameters.AddWithValue("@ID_OBRA_SOCIAL",paciente.ObraSocial != null ? (object)paciente.ObraSocial.Id: DBNull.Value);

                        comando.Parameters.AddWithValue("@NUMERO_AFILIADO",(object)paciente.NumeroAfiliado ?? DBNull.Value); comando.ExecuteNonQuery();
                    }
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Error al agregar el paciente: " + ex.Message, ex);
            }
        }

        public static List<Paciente> ObtenerPacientes()
        {
            try
            {
                List<Paciente> lista = new List<Paciente>();

                using (SqlConnection conexion = new SqlConnection(ConectionString.GetConectionString()))
                {
                    conexion.Open();

                    string query = @"SELECT 
                    PA.ID_PACIENTE,
                    PE.ID_PERSONA,
                    PE.NOMBRE,
                    PE.APELLIDO,
                    PE.DNI,
                    PE.TELEFONO,
                    PE.MAIL,
                    PA.FECHA_NACIMIENTO,
                    PA.ID_OBRA_SOCIAL,
                    PA.NUMERO_AFILIADO,
                    OS.NOMBRE AS NOMBRE_OBRA_SOCIAL
                    FROM PACIENTE PA
                    INNER JOIN PERSONA PE
                    ON PA.ID_PERSONA = PE.ID_PERSONA
                    LEFT JOIN OBRA_SOCIAL OS
                    ON PA.ID_OBRA_SOCIAL = OS.ID_OBRA_SOCIAL";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        using (SqlDataReader sqlDataReader = comando.ExecuteReader())
                        {
                            while (sqlDataReader.Read())
                            {
                                lista.Add(PacienteMapper.Map(sqlDataReader));
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

        public static List<Paciente> ObtenerPacientesPorObraSocial(int idObraSocial)
        {
            try
            {
                List<Paciente> lista = new List<Paciente>();

                using (SqlConnection conexion = new SqlConnection(ConectionString.GetConectionString()))
                {
                    conexion.Open();

                    string query = @"SELECT 
                    PA.ID_PACIENTE,
                    PE.ID_PERSONA,
                    PE.NOMBRE,
                    PE.APELLIDO,
                    PE.DNI,
                    PE.TELEFONO,
                    PE.MAIL,
                    PA.FECHA_NACIMIENTO,
                    PA.ID_OBRA_SOCIAL,
                    PA.NUMERO_AFILIADO,
                    OS.NOMBRE AS NOMBRE_OBRA_SOCIAL
                    FROM PACIENTE PA
                    INNER JOIN PERSONA PE
                    ON PA.ID_PERSONA = PE.ID_PERSONA
                    LEFT JOIN OBRA_SOCIAL OS
                    ON PA.ID_OBRA_SOCIAL = OS.ID_OBRA_SOCIAL
                    WHERE PA.ID_OBRA_SOCIAL = @ID_OBRA_SOCIAL";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID_OBRA_SOCIAL", idObraSocial);

                        using (SqlDataReader sqlDataReader = comando.ExecuteReader())
                        {
                            while (sqlDataReader.Read())
                            {
                                lista.Add(PacienteMapper.Map(sqlDataReader));
                            }
                        }
                    }
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los pacientes por obra social: " + ex.Message, ex);
            }
        }

        public static void ModificarPaciente(Paciente paciente)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConectionString.GetConectionString()))
                {
                    conexion.Open();

                    string queryPaciente = @"UPDATE PACIENTE SET
                    FECHA_NACIMIENTO = @FECHA_NACIMIENTO,
                    ID_OBRA_SOCIAL = @ID_OBRA_SOCIAL,
                    NUMERO_AFILIADO = @NUMERO_AFILIADO
                    WHERE ID_PACIENTE = @ID_PACIENTE
                    AND ID_PERSONA = @ID_PERSONA";

                    using (SqlCommand comandoPaciente = new SqlCommand(queryPaciente, conexion))
                    {
                        comandoPaciente.Parameters.AddWithValue("@FECHA_NACIMIENTO", paciente.FechaNacimiento.Date);

                        comandoPaciente.Parameters.AddWithValue("@ID_OBRA_SOCIAL",paciente.ObraSocial != null? (object)paciente.ObraSocial.Id: DBNull.Value);

                        comandoPaciente.Parameters.AddWithValue("@NUMERO_AFILIADO",(object)paciente.NumeroAfiliado ?? DBNull.Value);

                        comandoPaciente.Parameters.AddWithValue("@ID_PACIENTE", paciente.IdPaciente);

                        comandoPaciente.Parameters.AddWithValue("@ID_PERSONA", paciente.Id);

                        int filasAfectadas = comandoPaciente.ExecuteNonQuery();

                        if (filasAfectadas == 0)
                        {
                            throw new Exception("No se encontró el paciente que desea modificar.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el paciente: " + ex.Message, ex);
            }
        }

        public static void EliminarPaciente(int idPaciente)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConectionString.GetConectionString()))
                {
                    conexion.Open();

                    string query = @"DELETE FROM PACIENTE WHERE ID_PACIENTE = @ID_PACIENTE";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID_PACIENTE", idPaciente);

                        int filasAfectadas = comando.ExecuteNonQuery();

                        if (filasAfectadas == 0)
                        {
                            throw new Exception("No se encontró el paciente que desea eliminar.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el paciente: " + ex.Message, ex);
            }
        }

        public static bool ExistePacientePorIdPersona(int idPersona)
        {
            try
            {
                using (SqlConnection conexion =
                    new SqlConnection(ConectionString.GetConectionString()))
                {
                    conexion.Open();

                    string query = @"SELECT COUNT(*)
                             FROM PACIENTE
                             WHERE ID_PERSONA = @ID_PERSONA";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID_PERSONA", idPersona);

                        int cantidad = Convert.ToInt32(comando.ExecuteScalar());

                        return cantidad > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar si la persona ya es paciente: " + ex.Message, ex);
            }
        }


    }
}
