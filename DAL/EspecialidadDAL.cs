using BE;

using Microsoft.Data.SqlClient;
using MPP;
using System;
using System.Collections.Generic;

namespace DAL
{
    public static class EspecialidadDAL
    {
        public static void AgregarEspecialidad(Especialidad especialidad)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConectionString.GetConectionString()))
                {
                    conexion.Open();

                    string query = "INSERT INTO ESPECIALIDAD (DESCRIPCION) VALUES (@DESCRIPCION)";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@DESCRIPCION", especialidad.Descripcion);

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Especialidad> ObtenerEspecialidades()
        {
            try
            {
                List<Especialidad> lista = new List<Especialidad>();

                using (SqlConnection conexion =
                    new SqlConnection(ConectionString.GetConectionString()))
                {
                    conexion.Open();

                    string query = "SELECT * FROM ESPECIALIDAD";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        using (SqlDataReader sqlDataReader = comando.ExecuteReader())
                        {
                            while (sqlDataReader.Read())
                            {
                                lista.Add(EspecialidadMapper.Map(sqlDataReader));
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

        public static void ModificarEspecialidad(Especialidad especialidad)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConectionString.GetConectionString()))
                {
                    conexion.Open();

                    string query = @"UPDATE ESPECIALIDAD SET DESCRIPCION = @DESCRIPCION WHERE ID_ESPECIALIDAD = @ID_ESPECIALIDAD";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@DESCRIPCION", especialidad.Descripcion);
                        comando.Parameters.AddWithValue("@ID_ESPECIALIDAD", especialidad.Id);

                        int filasAfectadas = comando.ExecuteNonQuery();

                        if (filasAfectadas == 0)
                        {
                            throw new Exception("No se encontró la especialidad que desea modificar.");
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void EliminarEspecialidad(int idEspecialidad)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConectionString.GetConectionString()))
                {
                    conexion.Open();

                    string query = @"DELETE FROM ESPECIALIDAD WHERE ID_ESPECIALIDAD = @ID_ESPECIALIDAD";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID_ESPECIALIDAD", idEspecialidad);

                        int filasAfectadas = comando.ExecuteNonQuery();

                        if (filasAfectadas == 0)
                        {
                            throw new Exception("No se encontró la especialidad que desea eliminar.");
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
