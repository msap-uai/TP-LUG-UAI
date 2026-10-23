using System;

namespace BE
{
    public class Profesional : Persona
    {
        public int IdProfesional { get; private set; }

        public string Matricula
        {
            get;

            set
            {
                // Verifica que la matrícula exista
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("La matrícula es obligatoria.");
                }

                // Verifica que la matricula solo tenga números
                for(int i = 0; i < value.Length; i++)
                {
                    if (!char.IsDigit(value[i]))
                    {
                        throw new ArgumentException("La matrícula solo puede contener números.");
                    }
                }

                // Controla que la longitud de la matrícula no supere los 20 caracteres
                if (value.Length > 20)
                {
                    throw new ArgumentException("La matrícula no puede superar los 20 caracteres.");
                }

                field = value;
            }
        }

        public Especialidad Especialidad
        {
            get;

            set
            {
                // Verifica que la especialidad exista
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(Especialidad), "Debe informar la especialidad del profesional.");
                }

                field = value;
            }
        }

        public decimal Arancel
        {
            get;

            set
            {
                // El arancel debe ser un número positivo
                if (value <= 0)
                {
                    throw new ArgumentException("El arancel debe ser un número positivo.");
                }

                // Limite superior del arancel de 100 millones
                if (!(value < 100000000m))
                {
                    throw new ArgumentException("El arancel debe ser menora a 100 millones.");
                }

                field = value;
            }
        }

        public Profesional()
        {

        }
    }
}
