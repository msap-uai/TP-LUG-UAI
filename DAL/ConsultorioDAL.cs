using BE;
using MPP;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ConsultorioDAL
    {
        public void AgregarConsultorio(Consultorio consultorio)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConectionString.GetConectionString()))
                {
                    conexion.Open();

                    string query = "INSERT INTO CONSULTORIO (NUMERO_CONSULTORIO) VALUES (@NUMERO_CONSULTORIO)";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@NUMERO_CONSULTORIO", consultorio.Numero);

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Consultorio> ObtenerConsultorios()
        {
            try
            {
                List<Consultorio> lista = new List<Consultorio>();

                using (SqlConnection conexion =
                    new SqlConnection(ConectionString.GetConectionString()))
                {
                    conexion.Open();

                    string query = "SELECT * FROM CONSULTORIO";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        using (SqlDataReader sqlDataReader = comando.ExecuteReader())
                        {
                            while (sqlDataReader.Read())
                            {
                                lista.Add(ConsultorioMapper.Map(sqlDataReader));
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

        public void ModificarConsultorio(Consultorio consultorio)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConectionString.GetConectionString()))
                {
                    conexion.Open();

                    string query = @"UPDATE CONSULTORIO SET NUMERO_CONSULTORIO = @NUMERO_CONSULTORIO WHERE ID_CONSULTORIO = @ID_CONSULTORIO";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@NUMERO_CONSULTORIO", consultorio.Numero);
                        comando.Parameters.AddWithValue("@ID_CONSULTORIO", consultorio.Id);

                        int filasAfectadas = comando.ExecuteNonQuery();

                        if (filasAfectadas == 0)
                        {
                            throw new Exception(
                                "No se encontro el consultorio.");
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void EliminarConsultorio(int idConsultorio)
        {
            try
            {
                using (SqlConnection conexion =
                    new SqlConnection(ConectionString.GetConectionString()))
                {
                    conexion.Open();

                    string query = @"DELETE FROM CONSULTORIO
                                     WHERE ID_CONSULTORIO = @ID_CONSULTORIO";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID_CONSULTORIO", idConsultorio);

                        int filasAfectadas = comando.ExecuteNonQuery();

                        if (filasAfectadas == 0)
                        {
                            throw new Exception(
                                "No se encontro el consultorio.");
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
