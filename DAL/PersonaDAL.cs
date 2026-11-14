using BE;
using Microsoft.Data.SqlClient;
using MPP;
using System;
using System.Collections.Generic;

namespace DAL
{
    public static class PersonaDAL
    {
        public static int AgregarPersona(Persona persona)
        {
            try
            {

                using (SqlConnection conexion = new SqlConnection(ConectionString.GetConectionString()))
                {
                    conexion.Open();

                    string query = @"INSERT INTO PERSONA (NOMBRE, APELLIDO, DNI, TELEFONO, MAIL) VALUES (@NOMBRE, @APELLIDO, @DNI, @TELEFONO, @MAIL); 
                  SELECT CAST(SCOPE_IDENTITY() AS INT);";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@NOMBRE", persona.Nombre);
                        comando.Parameters.AddWithValue("@APELLIDO", persona.Apellido);
                        comando.Parameters.AddWithValue("@DNI", persona.Dni);
                        comando.Parameters.AddWithValue("@TELEFONO", (object)persona.Telefono ?? DBNull.Value);
                        comando.Parameters.AddWithValue("@MAIL", (object)persona.Mail ?? DBNull.Value);
                        int idPersona = Convert.ToInt32(comando.ExecuteScalar());
                        return idPersona;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar la persona: " + ex.Message, ex);
            }
        }

        public static List<Persona> ObtenerPersonas()
        {
            try
            {
                List<Persona> lista = new List<Persona>();

                using (SqlConnection conexion = new SqlConnection(ConectionString.GetConectionString()))
                {
                    conexion.Open();

                    string query = @"SELECT ID_PERSONA, NOMBRE, APELLIDO, DNI, TELEFONO, MAIL FROM PERSONA ORDER BY APELLIDO, NOMBRE";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        using (SqlDataReader sqlDataReader = comando.ExecuteReader())
                        {
                            while (sqlDataReader.Read())
                            {
                                lista.Add(PersonaMapper.Map(sqlDataReader));
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

        public static List<Persona> ObtenerPersonasNoProfesionales()
        {
            try
            {
                List<Persona> lista = new List<Persona>();

                using (SqlConnection conexion = new SqlConnection(ConectionString.GetConectionString()))
                {
                    conexion.Open();

                    string query = @"SELECT PE.ID_PERSONA, PE.NOMBRE, PE.APELLIDO, PE.DNI, PE.TELEFONO, PE.MAIL
                        FROM PERSONA PE
                        WHERE NOT EXISTS (SELECT 1 FROM PROFESIONAL PR WHERE PR.ID_PERSONA = PE.ID_PERSONA)
                        ORDER BY PE.APELLIDO, PE.NOMBRE";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        using (SqlDataReader sqlDataReader = comando.ExecuteReader())
                        {
                            while (sqlDataReader.Read())
                            {
                                lista.Add(PersonaMapper.Map(sqlDataReader));
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

        public static void ModificarPersona(Persona persona)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConectionString.GetConectionString()))
                {
                    conexion.Open();

                    string query = @"UPDATE PERSONA SET NOMBRE = @NOMBRE, APELLIDO = @APELLIDO, DNI = @DNI, TELEFONO = @TELEFONO, MAIL = @MAIL WHERE ID_PERSONA = @ID_PERSONA";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@NOMBRE", persona.Nombre);
                        comando.Parameters.AddWithValue("@APELLIDO", persona.Apellido);
                        comando.Parameters.AddWithValue("@DNI", persona.Dni);
                        comando.Parameters.AddWithValue("@TELEFONO", string.IsNullOrEmpty(persona.Telefono) ? (object)DBNull.Value : persona.Telefono);
                        comando.Parameters.AddWithValue("@MAIL", string.IsNullOrEmpty(persona.Mail) ? (object)DBNull.Value : persona.Mail);
                        comando.Parameters.AddWithValue("@ID_PERSONA", persona.Id);

                        int filasAfectadas = comando.ExecuteNonQuery();

                        if (filasAfectadas == 0)
                        {
                            throw new Exception("No se encontró la persona a modificar.");
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void EliminarPersona(int idPersona)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConectionString.GetConectionString()))
                {
                    conexion.Open();

                    string query = @"DELETE FROM PERSONA WHERE ID_PERSONA = @ID_PERSONA";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID_PERSONA", idPersona);

                        int filasAfectadas = comando.ExecuteNonQuery();

                        if (filasAfectadas == 0)
                        {
                            throw new Exception("No se encontró la persona a eliminar.");
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool TieneRegistrosAsociados(int idPersona)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConectionString.GetConectionString()))
                {
                    conexion.Open();

                    string query = @"SELECT CASE WHEN EXISTS (SELECT 1 FROM PACIENTE WHERE ID_PERSONA = @ID_PERSONA) OR EXISTS (SELECT 1 FROM PROFESIONAL WHERE ID_PERSONA = @ID_PERSONA) THEN 1 ELSE 0 END";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID_PERSONA", idPersona);

                        return Convert.ToInt32(comando.ExecuteScalar()) == 1;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Persona ObtenerPersonaPorDni(string dni)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConectionString.GetConectionString()))
                {
                    conexion.Open();

                    string query = @"SELECT ID_PERSONA, NOMBRE, APELLIDO, DNI, TELEFONO, MAIL
                             FROM PERSONA WHERE DNI = @DNI";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@DNI", dni);

                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return PersonaMapper.Map(reader);
                            }
                        }
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Error al buscar la persona por DNI: " + ex.Message, ex);
            }
        }



    }
}
