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
    public class TurnoDAL
    {
        public void AgregarTurno(Turno turno)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConectionString.GetConectionString()))
                {
                    conexion.Open();

                    string query = @"INSERT INTO TURNO (ID_PACIENTE, ID_PROFESIONAL,ID_CONSULTORIO, FECHA_HORA, ESTADO)
                                     VALUES (@ID_PACIENTE, @ID_PROFESIONAL, @ID_CONSULTORIO, @FECHA_HORA, @ESTADO)";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID_PACIENTE", turno.Paciente.IdPaciente);

                        comando.Parameters.AddWithValue("@ID_PROFESIONAL", turno.Profesional.IdProfesional);

                        comando.Parameters.AddWithValue("@ID_CONSULTORIO", turno.Consultorio.Id);

                        comando.Parameters.AddWithValue("@FECHA_HORA", turno.FechaHora);

                        comando.Parameters.AddWithValue("@ESTADO", turno.Estado.ToString());

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Turno> ObtenerTurnos()
        {
            try
            {
                List<Turno> lista = new List<Turno>();

                using (SqlConnection conexion = new SqlConnection(ConectionString.GetConectionString()))
                {
                    conexion.Open();

                    string query = @"SELECT
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
                    T.ESTADO FROM TURNO T
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
                                lista.Add(TurnoMapper.Map(sqlDataReader));
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

        public void ModificarTurno(Turno turno)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConectionString.GetConectionString()))
                {
                    conexion.Open();

                    string query = @"UPDATE TURNO SET 
                                 ID_PACIENTE = @ID_PACIENTE,
                                 ID_PROFESIONAL = @ID_PROFESIONAL,
                                 ID_CONSULTORIO = @ID_CONSULTORIO,
                                 FECHA_HORA = @FECHA_HORA,
                                 ESTADO = @ESTADO
                                 WHERE ID_TURNO = @ID_TURNO";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID_PACIENTE", turno.Paciente.IdPaciente);

                        comando.Parameters.AddWithValue("@ID_PROFESIONAL", turno.Profesional.IdProfesional);

                        comando.Parameters.AddWithValue("@ID_CONSULTORIO", turno.Consultorio.Id);

                        comando.Parameters.AddWithValue("@FECHA_HORA", turno.FechaHora);

                        comando.Parameters.AddWithValue("@ESTADO", turno.Estado.ToString());

                        comando.Parameters.AddWithValue("@ID_TURNO", turno.Id);

                        int filasAfectadas = comando.ExecuteNonQuery();

                        if (filasAfectadas == 0)
                        {
                            throw new Exception("No se encontró el turno que desea modificar.");
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CancelarTurno(int idTurno)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConectionString.GetConectionString()))
                {
                    conexion.Open();

                    string query = @"UPDATE TURNO SET ESTADO = @ESTADO WHERE ID_TURNO = @ID_TURNO";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@ESTADO", EstadoTurno.Cancelado.ToString());

                        comando.Parameters.AddWithValue("@ID_TURNO", idTurno);

                        int filasAfectadas = comando.ExecuteNonQuery();

                        if (filasAfectadas == 0)
                        {
                            throw new Exception("No se encontró el turno que desea cancelar.");
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
