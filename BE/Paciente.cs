using System;

namespace BE
{
    public class Paciente : Persona
    {
        public int IdPaciente { get; private set; }

        public DateTime FechaNacimiento 
        { 
            get; 
            
            set
            {
                // Verifica que la fecha de nacimiento no sea mayor a la fecha actual
                if (value > DateTime.Now)
                {
                    throw new ArgumentException("La fecha de nacimiento no puede ser mayor a la fecha actual.");
                }

                field = value;
            }
        }

        public ObraSocial ObraSocial 
        { 
            get;

            set
            {
                // Verifica que la obra social exista
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(ObraSocial), "Debe informar la obra social del paciente.");
                }

                field = value;
            }
        }

        public string NumeroAfiliado
        {
            get;

            // Controla que la longitud del número de afiliado no supere los 30 caracteres
            set
            {
                if (value != null && value.Length > 30)
                {
                    throw new ArgumentException("El número de afiliado no puede superar los 30 caracteres.");
                }

                field = value;
            }
        }

        public Paciente()
        {

        }
    }
}
