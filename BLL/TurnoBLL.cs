using BE;
using DAL;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class TurnoBLL
    {
        private TurnoDAL turnos = new TurnoDAL();

        public List<Turno> ObtenerTurnos()
        {
            try
            {
                return turnos.ObtenerTurnos();
            }
            catch
            {
                throw;
            }

        }

        public List<Turno> ObtenerTurnosFiltrados(DateTime? fecha, int? idConsultorio)
        {
            try
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
            catch
            {
                throw;
            }

        }

        public List<string> ObtenerHorariosOcupados(int idProfesional, int idConsultorio, int idPaciente, DateTime fecha, int idTurnoExcluido)
        {
            try
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
            catch
            {
                throw;
            }

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
                throw;
            }
        }

        public void ModificarTurno(Turno turno)
        {
            try
            {
                if (turno == null || turno.Id <= 0)
                {
                    throw new Exception("Debe seleccionar un turno valido.");
                }
                // Buscar el turno registrado en la base de datos
                List<Turno> lista = turnos.ObtenerTurnos();

                Turno encontrado = null;

                foreach (var t in lista)
                {
                    if (t.Id == turno.Id)
                    {
                        encontrado = t;
                        break;
                    }
                }

                if (encontrado == null)
                {
                    throw new Exception("No se encontró el turno.");
                }

                // Validar que el turno esté pendiente
                if (encontrado.Estado != EstadoTurno.Pendiente)
                {
                    throw new Exception("Solo se pueden modificar turnos pendientes.");
                }

                ValidarTurno(turno);
                turnos.ModificarTurno(turno);
            }
            catch
            {
                throw;
            }

        }

        public void CancelarTurno(int idTurno)
        {
            try
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
            catch
            {
                throw;
            }

        }

        private void ValidarTurno(Turno turno)
        {
            try
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
            catch
            {
                throw;
            }

        }
    }
}

