using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP
{
    public class TurnoMapper
    {
        public static Turno Map(SqlDataReader sqlDataReader)
        {
            int idTurno = Convert.ToInt32(sqlDataReader["ID_TURNO"]);

            int idPaciente = Convert.ToInt32(sqlDataReader["ID_PACIENTE"]);

            int idPersonaPaciente = Convert.ToInt32(sqlDataReader["ID_PERSONA_PACIENTE"]);

            int idProfesional = Convert.ToInt32(sqlDataReader["ID_PROFESIONAL"]);

            int idPersonaProfesional = Convert.ToInt32(sqlDataReader["ID_PERSONA_PROFESIONAL"]);

            int idConsultorio = Convert.ToInt32(sqlDataReader["ID_CONSULTORIO"]);

            int numeroConsultorio = Convert.ToInt32(sqlDataReader["NUMERO_CONSULTORIO"]);

            DateTime fechaHora = Convert.ToDateTime(sqlDataReader["FECHA_HORA"]);

            string estadoTexto = Convert.ToString(sqlDataReader["ESTADO"]);

            EstadoTurno estado = (EstadoTurno)Enum.Parse(typeof(EstadoTurno), estadoTexto);

            Paciente paciente = new Paciente(
                idPersonaPaciente,
                idPaciente,
                Convert.ToString(sqlDataReader["NOMBRE_PACIENTE"]),
                Convert.ToString(sqlDataReader["APELLIDO_PACIENTE"]),
                Convert.ToString(sqlDataReader["DNI_PACIENTE"]),
                null,
                null,
                Convert.ToDateTime(sqlDataReader["FECHA_NACIMIENTO"]),
                null,
                null
            );

            Especialidad especialidad = new Especialidad(
                Convert.ToInt32(sqlDataReader["ID_ESPECIALIDAD"]),
                Convert.ToString(sqlDataReader["DESCRIPCION_ESPECIALIDAD"])
            );

            Profesional profesional = new Profesional(
                idPersonaProfesional,
                idProfesional,
                Convert.ToString(sqlDataReader["NOMBRE_PROFESIONAL"]),
                Convert.ToString(sqlDataReader["APELLIDO_PROFESIONAL"]),
                Convert.ToString(sqlDataReader["DNI_PROFESIONAL"]),
                null,
                null,
                Convert.ToString(sqlDataReader["MATRICULA"]),
                especialidad,
                Convert.ToDecimal(sqlDataReader["ARANCEL"])
            );

            Consultorio consultorio = new Consultorio(idConsultorio, numeroConsultorio);

            Turno turno = new Turno(
                idTurno,
                paciente,
                profesional,
                consultorio,
                fechaHora,
                estado
            );

            return turno;
        }
    }
}
