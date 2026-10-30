using BE;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using MPP;

namespace DAL
{
    public static class ObraSocialDAL
    {
        public static void AgregarObraSocial(ObraSocial obraSocial)
        {
            try
            {
                using (SqlConnection conexion= new SqlConnection(ConectionString.GetConectionString()))
                {
                    conexion.Open();
                    string query = "INSERT INTO OBRA_SOCIAL (NOMBRE) VALUES (@NOMBRE)";
                    using(SqlCommand comando=new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@NOMBRE", obraSocial.Nombre);
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw ;
            }
        }

        public static List<ObraSocial> ObtenerObrasSociales()
        {
            List<ObraSocial> lista= new List<ObraSocial>();

            using (SqlConnection conexion = new SqlConnection(ConectionString.GetConectionString()))
            {
                conexion.Open();

                string query = "SELECT * FROM OBRA_SOCIAL";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    using (SqlDataReader sqlDataReader = comando.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            lista.Add(ObraSocialMapper.Map(sqlDataReader));
                        }
                    }
                }
            }

            return lista;
        }

        public static void ModificarObraSocial(ObraSocial obraSocial)
        {
            using (SqlConnection conexion = new SqlConnection(ConectionString.GetConectionString()))
            {
                conexion.Open();

                string query = @"UPDATE OBRA_SOCIAL SET NOMBRE = @NOMBRE WHERE ID_OBRA_SOCIAL = @ID_OBRA_SOCIAL";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@NOMBRE", obraSocial.Nombre);
                    comando.Parameters.AddWithValue("@ID_OBRA_SOCIAL", obraSocial.Id);

                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas == 0)
                    {
                        throw new Exception("No se encontró la obra social que desea modificar.");
                    }
                }
            }
        }

        public static void EliminarObraSocial(int idObraSocial)
        {
            using (SqlConnection conexion = new SqlConnection(ConectionString.GetConectionString()))
            {
                conexion.Open();

                string query = @"DELETE FROM OBRA_SOCIAL WHERE ID_OBRA_SOCIAL = @ID_OBRA_SOCIAL";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@ID_OBRA_SOCIAL", idObraSocial);

                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas == 0)
                    {
                        throw new Exception("No se encontró la obra social que desea eliminar.");
                    }
                }
            }
        }
    }
}
