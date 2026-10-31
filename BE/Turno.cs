using System;

namespace BE
{
    public class Turno
    {
        public int Id { get; private set; }

        public Paciente Paciente { get; set; }
        //Validamos el paciente en BLL asi nos aseguramos que este en la base de datos

        public Profesional Profesional {  get; set; }
        //Validar en BLL para ver que este en la base de datos

        public Consultorio Consultorio {  get; set; }
       //Validar en BLL para que un consultorio no se asigne a 2 turnos a la vez

        public DateTime FechaHora { get; set; }

        private EstadoTurno _estado;

        public EstadoTurno Estado
        {
            get => _estado;

            set
            {
                // Controlar que el estado exista en la lista de estados válidos
                if (!Enum.IsDefined(typeof(EstadoTurno), value))
                {
                    throw new ArgumentException("El estado del turno no es válido.");
                }

                _estado = value;
            }
        }

        public Turno()
        {
            Estado = EstadoTurno.Pendiente;
        }
        public Turno(int id, Paciente paciente, Profesional profesional, Consultorio consultorio, DateTime fechaHora, EstadoTurno estado)
        {
            Id = id;
            Paciente = paciente;
            Profesional = profesional;
            Consultorio = consultorio;
            FechaHora = fechaHora;
            Estado = estado;
        }
    }
}
