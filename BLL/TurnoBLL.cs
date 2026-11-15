using System;
using System.Collections.Generic;
using BE;
using DAL;

namespace BLL
{
    public class TurnoBLL
    {
        private TurnoDAL turnos = new TurnoDAL();

        public List<Turno> ObtenerTurnos()
        {
            return turnos.ObtenerTurnos();
        }

        public List<Turno> ObtenerTurnosFiltrados(DateTime? fecha, int? idConsultorio)
        {
            List<Turno> filtrados = new List<Turno>();

            foreach (var t in turnos.ObtenerTurnos())
            {
                if (fecha != null)
                {
                    if (t.FechaHora.Date != fecha.Value.Date)
                    {
                        continue;
                    }
                }

                if (idConsultorio != null)
                {
                    if (t.Consultorio == null || t.Consultorio.Id != idConsultorio.Value)
                    {
                        continue;
                    }
                }

                filtrados.Add(t);
            }

            return filtrados;
        }

        public List<string> ObtenerHorariosOcupados(int idProfesional, int idConsultorio, int idPaciente, DateTime fecha, int idTurnoExcluido)
        {
            List<string> ocupados = new List<string>();

            foreach (var t in turnos.ObtenerTurnos())
            {
                if (t.Id == idTurnoExcluido)
                {
                    continue;
                }

                if (t.Estado == EstadoTurno.Cancelado)
                {
                    continue;
                }

                if (t.FechaHora.Date != fecha.Date)
                {
                    continue;
                }

                bool mismoProfesional = false;

                if (t.Profesional != null)
                {
                    if (t.Profesional.IdProfesional == idProfesional)
                    {
                        mismoProfesional = true;
                    }
                }

                bool mismoConsultorio = false;

                if (t.Consultorio != null)
                {
                    if (t.Consultorio.Id == idConsultorio)
                    {
                        mismoConsultorio = true;
                    }
                }

                bool mismoPaciente = false;

                if (t.Paciente != null)
                {
                    if (t.Paciente.IdPaciente == idPaciente)
                    {
                        mismoPaciente = true;
                    }
                }

                if (mismoProfesional || mismoConsultorio || mismoPaciente)
                {
                    ocupados.Add(t.FechaHora.ToString("HH:mm"));
                }
            }

            return ocupados;
        }

        public void AgregarTurno(Turno turno)
        {
            try
            { 
                ValidarTurno(turno);
                turnos.AgregarTurno(turno);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el turno: " + ex.Message);
            }
        }

        public void ModificarTurno(Turno turno)
        {
            if (turno == null || turno.Id <= 0)
            {
                throw new Exception("Debe seleccionar un turno valido.");
            }

            ValidarTurno(turno);
            turnos.ModificarTurno(turno);
        }

        public void CancelarTurno(int idTurno)
        {
            if (idTurno <= 0)
            {
                throw new Exception("Debe seleccionar un turno valido.");
            }

            // busca el turno para revisar el estado
            List<Turno> lista = turnos.ObtenerTurnos();
            Turno encontrado = null;

            foreach (var t in lista)
            {
                if (t.Id == idTurno)
                {
                    encontrado = t;
                    break;
                }
            }

            if (encontrado == null)
            {
                throw new Exception("No se encontro el turno.");
            }

            if (encontrado.Estado == EstadoTurno.Cancelado)
            {
                throw new Exception("El turno ya se encuentra cancelado.");
            }

            if (encontrado.Estado == EstadoTurno.Atendido)
            {
                throw new Exception("No se puede cancelar un turno que ya fue atendido.");
            }

            turnos.CancelarTurno(idTurno);
        }

        private void ValidarTurno(Turno turno)
        {
            if (turno == null)
            {
                throw new Exception("El turno no puede ser nulo.");
            }

            if (turno.Paciente == null || turno.Paciente.IdPaciente <= 0)
            {
                throw new Exception("Debe seleccionar un paciente.");
            }

            if (turno.Profesional == null || turno.Profesional.IdProfesional <= 0)
            {
                throw new Exception("Debe seleccionar un profesional.");
            }

            if (turno.Consultorio == null || turno.Consultorio.Id <= 0)
            {
                throw new Exception("Debe seleccionar un consultorio.");
            }

            if (turno.FechaHora <= DateTime.Now)
            {
                throw new Exception("La fecha y hora no puede ser anterior a la actual.");
            }

            // valida lunes a viernes
            if (turno.FechaHora.DayOfWeek == DayOfWeek.Saturday || turno.FechaHora.DayOfWeek == DayOfWeek.Sunday)
            {
                throw new Exception("Los turnos solo se pueden agendar de lunes a viernes.");
            }

            // valida horario de 8 a 20 cada media hora
            if (turno.FechaHora.Hour < 8 || turno.FechaHora.Hour > 20 || (turno.FechaHora.Hour == 20 && turno.FechaHora.Minute > 0))
            {
                throw new Exception("El horario de atencion es de 08:00 a 20:00.");
            }

            if (turno.FechaHora.Minute != 0 && turno.FechaHora.Minute != 30)
            {
                throw new Exception("Los turnos deben ser cada media hora.");
            }

            // controla superposicion de horarios
            List<Turno> existentes = turnos.ObtenerTurnos();

            foreach (var t in existentes)
            {
                if (t.Id == turno.Id)
                {
                    continue;
                }

                if (t.Estado == EstadoTurno.Cancelado)
                {
                    continue;
                }

                double diferenciaMinutos = Math.Abs((t.FechaHora - turno.FechaHora).TotalMinutes);

                if (diferenciaMinutos < 30)
                {
                    if (t.Profesional != null && t.Profesional.IdProfesional == turno.Profesional.IdProfesional)
                    {
                        throw new Exception("El profesional ya tiene un turno asignado en ese horario.");
                    }

                    if (t.Consultorio != null && t.Consultorio.Id == turno.Consultorio.Id)
                    {
                        throw new Exception("El consultorio ya esta ocupado en ese horario.");
                    }

                    if (t.Paciente != null && t.Paciente.IdPaciente == turno.Paciente.IdPaciente)
                    {
                        throw new Exception("El paciente ya tiene un turno asignado en ese horario.");
                    }
                }
            }
        }
    }
}
