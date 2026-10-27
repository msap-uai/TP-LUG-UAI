using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class PacienteDAL
    {
        public void AgregarPaciente(Paciente paciente)
        {
            using (SqlConnection conexion = new SqlConnection(ConectionString.GetConectionString()))
            {
                conexion.Open();

                SqlTransaction transaccion = conexion.BeginTransaction();

                try
                {//primero insertamos persona
                    string queryPersona = @"INSERT INTO PERSONA (NOMBRE, APELLIDO, DNI, TELEFONO, MAIL)
                        VALUES (@NOMBRE, @APELLIDO, @DNI, @TELEFONO, @MAIL);
                        SELECT CAST(SCOPE_IDENTITY() AS INT);";

                    int idPersona;

                    using (SqlCommand comandoPersona = new SqlCommand(queryPersona, conexion, transaccion))
                    {
                        comandoPersona.Parameters.AddWithValue("@NOMBRE", paciente.Nombre);
                        comandoPersona.Parameters.AddWithValue("@APELLIDO", paciente.Apellido);
                        comandoPersona.Parameters.AddWithValue("@DNI", paciente.Dni);

                        comandoPersona.Parameters.AddWithValue("@TELEFONO", (object)paciente.Telefono ?? DBNull.Value);

                        comandoPersona.Parameters.AddWithValue("@MAIL",(object)paciente.Mail ?? DBNull.Value);

                        idPersona = Convert.ToInt32(comandoPersona.ExecuteScalar());
                    }

                    // luego se inserta paciente
                    string queryPaciente = @"INSERT INTO PACIENTE (ID_PERSONA, FECHA_NACIMIENTO, ID_OBRA_SOCIAL, NUMERO_AFILIADO)
                        VALUES (@ID_PERSONA, @FECHA_NACIMIENTO, @ID_OBRA_SOCIAL, @NUMERO_AFILIADO)";

                    using (SqlCommand comandoPaciente = new SqlCommand(queryPaciente, conexion, transaccion))
                    {
                        comandoPaciente.Parameters.AddWithValue("@ID_PERSONA", idPersona);

                        comandoPaciente.Parameters.Add("@FECHA_NACIMIENTO", SqlDbType.Date).Value = paciente.FechaNacimiento.Date;

                        if (paciente.ObraSocial != null)
                        {
                            comandoPaciente.Parameters.AddWithValue("@ID_OBRA_SOCIAL", paciente.ObraSocial.Id);
                        }
                        else
                        {
                            comandoPaciente.Parameters.AddWithValue("@ID_OBRA_SOCIAL", DBNull.Value);
                        }

                        comandoPaciente.Parameters.AddWithValue("@NUMERO_AFILIADO",(object)paciente.NumeroAfiliado ?? DBNull.Value);

                        comandoPaciente.ExecuteNonQuery();
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


        public List<Paciente> ObtenerPacientes()
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

        public void ModificarPaciente(Paciente paciente)
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
                        comandoPersona.Parameters.AddWithValue("@NOMBRE", paciente.Nombre);
                        comandoPersona.Parameters.AddWithValue("@APELLIDO", paciente.Apellido);
                        comandoPersona.Parameters.AddWithValue("@DNI", paciente.Dni);

                        comandoPersona.Parameters.AddWithValue("@TELEFONO",(object)paciente.Telefono ?? DBNull.Value);

                        comandoPersona.Parameters.AddWithValue("@MAIL",(object)paciente.Mail ?? DBNull.Value);

                        comandoPersona.Parameters.AddWithValue("@ID_PERSONA", paciente.Id);

                        int filasAfectadas = comandoPersona.ExecuteNonQuery();

                        if (filasAfectadas == 0)
                        {
                            throw new Exception("No se encontró la persona que desea modificar.");
                        }
                    }

                    // SEGUNDO UPDATE: PACIENTE
                    string queryPaciente = @"UPDATE PACIENTE SET
                    FECHA_NACIMIENTO = @FECHA_NACIMIENTO,
                    ID_OBRA_SOCIAL = @ID_OBRA_SOCIAL,
                    NUMERO_AFILIADO = @NUMERO_AFILIADO
                    WHERE ID_PACIENTE = @ID_PACIENTE
                    AND ID_PERSONA = @ID_PERSONA";

                    using (SqlCommand comandoPaciente = new SqlCommand(queryPaciente, conexion, transaccion))
                    {
                        comandoPaciente.Parameters.Add("@FECHA_NACIMIENTO", SqlDbType.Date).Value = paciente.FechaNacimiento.Date;                    

                        comandoPaciente.Parameters.AddWithValue("@ID_OBRA_SOCIAL",paciente.ObraSocial != null? (object)paciente.ObraSocial.Id : DBNull.Value);

                        comandoPaciente.Parameters.AddWithValue("@NUMERO_AFILIADO",(object)paciente.NumeroAfiliado ?? DBNull.Value);

                        comandoPaciente.Parameters.AddWithValue("@ID_PACIENTE", paciente.IdPaciente);

                        comandoPaciente.Parameters.AddWithValue("@ID_PERSONA", paciente.Id);

                        int filasAfectadas = comandoPaciente.ExecuteNonQuery();

                        if (filasAfectadas == 0)
                        {
                            throw new Exception("No se encontró el paciente que desea modificar.");
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

        public void EliminarPaciente(int idPaciente)
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
            catch (Exception)
            {
                throw;
            }
        }
    }
}
