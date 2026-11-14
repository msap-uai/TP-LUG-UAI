using BE;
using MPP;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class ProfesionalDAL
    {
        public void AgregarProfesional(Profesional profesional)
        {
            using (SqlConnection conexion = new SqlConnection(ConectionString.GetConectionString()))
            {
                conexion.Open();

                SqlTransaction transaccion = conexion.BeginTransaction();

                try
                {
                    string query = @"INSERT INTO PROFESIONAL (ID_PERSONA, MATRICULA, ID_ESPECIALIDAD, ARANCEL)
                        VALUES (@ID_PERSONA, @MATRICULA, @ID_ESPECIALIDAD, @ARANCEL)";

                    using (SqlCommand comando = new SqlCommand(query, conexion, transaccion))
                    {
                        comando.Parameters.AddWithValue("@ID_PERSONA", profesional.Id);

                        comando.Parameters.AddWithValue("@MATRICULA", profesional.Matricula);

                        comando.Parameters.AddWithValue("@ID_ESPECIALIDAD", profesional.Especialidad.Id);

                        comando.Parameters.AddWithValue("@ARANCEL", profesional.Arancel);

                        comando.ExecuteNonQuery();
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

        public List<Profesional> ObtenerProfesionales()
        {
            try
            {
                List<Profesional> lista = new List<Profesional>();

                using (SqlConnection conexion = new SqlConnection(ConectionString.GetConectionString()))
                {
                    conexion.Open();

                    string query = @"SELECT
                    PR.ID_PROFESIONAL,
                    PE.ID_PERSONA,
                    PE.NOMBRE,
                    PE.APELLIDO,
                    PE.DNI,
                    PE.TELEFONO,
                    PE.MAIL,
                    PR.MATRICULA,
                    PR.ID_ESPECIALIDAD,
                    ES.DESCRIPCION,
                    PR.ARANCEL
                    FROM PROFESIONAL PR
                    INNER JOIN PERSONA PE
                    ON PR.ID_PERSONA = PE.ID_PERSONA
                    INNER JOIN ESPECIALIDAD ES
                    ON PR.ID_ESPECIALIDAD = ES.ID_ESPECIALIDAD";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        using (SqlDataReader sqlDataReader = comando.ExecuteReader())
                        {
                            while (sqlDataReader.Read())
                            {
                                lista.Add(ProfesionalMapper.Map(sqlDataReader));
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

        public static List<Profesional> ObtenerProfesionalesPorEspecialidad(int idEspecialidad)
        {
            try
            {
                List<Profesional> lista = new List<Profesional>();

                using (SqlConnection conexion = new SqlConnection(ConectionString.GetConectionString()))
                {
                    conexion.Open();

                    string query = @"SELECT
                    PR.ID_PROFESIONAL,
                    PE.ID_PERSONA,
                    PE.NOMBRE,
                    PE.APELLIDO,
                    PE.DNI,
                    PE.TELEFONO,
                    PE.MAIL,
                    PR.MATRICULA,
                    PR.ID_ESPECIALIDAD,
                    ES.DESCRIPCION,
                    PR.ARANCEL
                    FROM PROFESIONAL PR
                    INNER JOIN PERSONA PE
                    ON PR.ID_PERSONA = PE.ID_PERSONA
                    INNER JOIN ESPECIALIDAD ES
                    ON PR.ID_ESPECIALIDAD = ES.ID_ESPECIALIDAD
                    WHERE PR.ID_ESPECIALIDAD = @ID_ESPECIALIDAD";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID_ESPECIALIDAD", idEspecialidad);

                        using (SqlDataReader sqlDataReader = comando.ExecuteReader())
                        {
                            while (sqlDataReader.Read())
                            {
                                lista.Add(ProfesionalMapper.Map(sqlDataReader));
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

        public void ModificarProfesional(Profesional profesional)
        {
            using (SqlConnection conexion = new SqlConnection(ConectionString.GetConectionString()))
            {
                conexion.Open();

                SqlTransaction transaccion = conexion.BeginTransaction();

                try
                {
                    string query = @"UPDATE PROFESIONAL SET
                        MATRICULA = @MATRICULA,
                        ID_ESPECIALIDAD = @ID_ESPECIALIDAD,
                        ARANCEL = @ARANCEL
                        WHERE ID_PROFESIONAL = @ID_PROFESIONAL
                        AND ID_PERSONA = @ID_PERSONA";

                    using (SqlCommand comando = new SqlCommand(query, conexion, transaccion))
                    {
                        comando.Parameters.AddWithValue("@MATRICULA", profesional.Matricula);

                        comando.Parameters.AddWithValue("@ID_ESPECIALIDAD", profesional.Especialidad.Id);

                        comando.Parameters.AddWithValue("@ARANCEL", profesional.Arancel);

                        comando.Parameters.AddWithValue("@ID_PROFESIONAL", profesional.IdProfesional);

                        comando.Parameters.AddWithValue("@ID_PERSONA", profesional.Id);

                        int filasAfectadas = comando.ExecuteNonQuery();

                        if (filasAfectadas == 0)
                        {
                            throw new Exception("No se encontró el profesional que desea modificar.");
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

        public void EliminarProfesional(int idProfesional)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConectionString.GetConectionString()))
                {
                    conexion.Open();

                    string query = @"DELETE FROM PROFESIONAL WHERE ID_PROFESIONAL = @ID_PROFESIONAL";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID_PROFESIONAL", idProfesional);

                        int filasAfectadas = comando.ExecuteNonQuery();

                        if (filasAfectadas == 0)
                        {
                            throw new Exception("no se encontró el profesional que desea eliminar.");
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
