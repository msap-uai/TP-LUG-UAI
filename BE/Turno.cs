using System;

namespace BE
{
    public class Turno
    {
        public int Id { get; private set; }

        public Paciente Paciente
        {
            get;

            set
            {
                // Validar que el paciente exista
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(Paciente), "El paciente es obligatorio.");
                }

                field = value;
            }
        }

        public Profesional Profesional
        {
            get;

            set
            {
                // Validar que el profesional exista
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(Profesional), "El profesional es obligatorio.");
                }

                field = value;
            }
        }

        public Consultorio Consultorio
        {
            get;

            set
            {
                // Validar que el consultorio exista
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(Consultorio), "El consultorio es obligatorio.");
                }

                field = value;
            }
        }

        public DateTime FechaHora { get; set; }

        public EstadoTurno Estado
        {
            get;

            set
            {
                // Controlar que el estado exista en la lista de estados válidos
                if (!Enum.IsDefined(typeof(EstadoTurno), value))
                {
                    throw new ArgumentException("El estado del turno no es válido.");
                }

                field = value;
            }
        }

        public Turno()
        {
            Estado = EstadoTurno.Pendiente;
        }
    }
}
