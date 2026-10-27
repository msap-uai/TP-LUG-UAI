using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    // PRIMER INSERT: PERSONA
                    string queryPersona = @"INSERT INTO PERSONA (NOMBRE, APELLIDO, DNI, TELEFONO, MAIL)
                        VALUES (@NOMBRE, @APELLIDO, @DNI, @TELEFONO, @MAIL);
                        SELECT CAST(SCOPE_IDENTITY() AS INT);";

                    int idPersona;

                    using (SqlCommand comandoPersona = new SqlCommand(queryPersona, conexion, transaccion))
                    {
                        comandoPersona.Parameters.AddWithValue("@NOMBRE", profesional.Nombre);
                        comandoPersona.Parameters.AddWithValue("@APELLIDO", profesional.Apellido);
                        comandoPersona.Parameters.AddWithValue("@DNI", profesional.Dni);

                        comandoPersona.Parameters.AddWithValue("@TELEFONO",(object)profesional.Telefono ?? DBNull.Value);

                        comandoPersona.Parameters.AddWithValue("@MAIL",(object)profesional.Mail ?? DBNull.Value);

                        idPersona = Convert.ToInt32(comandoPersona.ExecuteScalar());
                    }

                    // SEGUNDO INSERT: PROFESIONAL

                    string queryProfesional = @"INSERT INTO PROFESIONAL (ID_PERSONA, MATRICULA, ID_ESPECIALIDAD, ARANCEL)
                        VALUES (@ID_PERSONA, @MATRICULA, @ID_ESPECIALIDAD, @ARANCEL)";

                    using (SqlCommand comandoProfesional = new SqlCommand(queryProfesional, conexion, transaccion))
                    {
                        comandoProfesional.Parameters.AddWithValue("@ID_PERSONA", idPersona);

                        comandoProfesional.Parameters.AddWithValue("@MATRICULA", profesional.Matricula);

                        comandoProfesional.Parameters.AddWithValue("@ID_ESPECIALIDAD", profesional.Especialidad.Id);

                        comandoProfesional.Parameters.AddWithValue("@ARANCEL", profesional.Arancel);

                        comandoProfesional.ExecuteNonQuery();
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

        public void ModificarProfesional(Profesional profesional)
        {
            using (SqlConnection conexion = new SqlConnection(ConectionString.GetConectionString()))
            {
                conexion.Open();

                SqlTransaction transaccion = conexion.BeginTransaction();

                try
                {
                    // PRIMER UPDATE: PERSONA
                    string queryPersona = @"UPDATE PERSONA SET
                    NOMBRE = @NOMBRE,
                    APELLIDO = @APELLIDO,
                    DNI = @DNI,
                    TELEFONO = @TELEFONO,
                    MAIL = @MAIL
                    WHERE ID_PERSONA = @ID_PERSONA";

                    using (SqlCommand comandoPersona = new SqlCommand(queryPersona, conexion, transaccion))
                    {
                        comandoPersona.Parameters.AddWithValue("@NOMBRE", profesional.Nombre);

                        comandoPersona.Parameters.AddWithValue("@APELLIDO", profesional.Apellido);

                        comandoPersona.Parameters.AddWithValue("@DNI", profesional.Dni);

                        comandoPersona.Parameters.AddWithValue("@TELEFONO",(object)profesional.Telefono ?? DBNull.Value);

                        comandoPersona.Parameters.AddWithValue("@MAIL",(object)profesional.Mail ?? DBNull.Value);

                        comandoPersona.Parameters.AddWithValue("@ID_PERSONA", profesional.Id);

                        int filasAfectadas = comandoPersona.ExecuteNonQuery();

                        if (filasAfectadas == 0)
                        {
                            throw new Exception("No se encontró la persona que desea modificar.");
                        }
                    }

                    // SEGUNDO UPDATE: PROFESIONAL 
                    string queryProfesional = @"UPDATE PROFESIONAL SET
                    MATRICULA = @MATRICULA,
                    ID_ESPECIALIDAD = @ID_ESPECIALIDAD,
                    ARANCEL = @ARANCEL
                    WHERE ID_PROFESIONAL = @ID_PROFESIONAL
                    AND ID_PERSONA = @ID_PERSONA";

                    using (SqlCommand comandoProfesional = new SqlCommand(queryProfesional, conexion, transaccion))
                    {
                        comandoProfesional.Parameters.AddWithValue("@MATRICULA", profesional.Matricula);

                        comandoProfesional.Parameters.AddWithValue("@ID_ESPECIALIDAD", profesional.Especialidad.Id);

                        comandoProfesional.Parameters.AddWithValue("@ARANCEL", profesional.Arancel);

                        comandoProfesional.Parameters.AddWithValue("@ID_PROFESIONAL", profesional.IdProfesional);

                        comandoProfesional.Parameters.AddWithValue("@ID_PERSONA", profesional.Id);

                        int filasAfectadas = comandoProfesional.ExecuteNonQuery();

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
                            throw new Exception("No se encontró el profesional que desea eliminar.");
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
