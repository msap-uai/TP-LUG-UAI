using System;

namespace BE
{
    public class Persona
    {
        public int Id { get; private set; }

        public string Nombre
        {
            get;

            set
            {
                // Verifica que el nombre exista
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El nombre es obligatorio.");
                }

                // Controla que la longitud del nombre no supere los 50 caracteres
                if (value.Length > 50)
                {
                    throw new ArgumentException("El nombre no puede tener más de 50 caracteres.");
                }

                field = value;
            }
        }

        public string Apellido
        {
            get;

            set
            {
                // Verifica que el apellido exista
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El apellido es obligatorio.");
                }

                // Verifica que el nombre no supere los 50 caracteres
                if (value.Length > 50)
                {
                    throw new ArgumentException("El apellido no puede tener más de 50 caracteres.");
                }

                field = value;
            }
        }

        public string Dni
        {
            get;

            set
            {
                //Verifica que el Dni no sea nulo o vacio
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El numero de DNI es obligatorio");
                }

                // Elimina los puntos "."
                value = value.Replace(".", "");

                // Elimina espacios en blanco
                value = value.Replace(" ", "");


                // Verifica que el DNI no supere los 10 caracteres
                if (value.Length > 10)
                {
                    throw new ArgumentException("El DNI no puede tener más de 10 caracteres.");
                }

                // verifica que Dni solo tenga numeros
                if (!System.Text.RegularExpressions.Regex.IsMatch(value, @"^[0-9]+$"))
                {
                    throw new ArgumentException("El DNI solo debe contener numeros");
                }


                field = value;
            }
        }

        public string Telefono
        {
            get;

            set
            {
                // Si el teléfono es nulo, lo convierte en una cadena vacía
                if (value == null)
                {
                    value = string.Empty;
                }

                // Verifica que el teléfono no supere los 20 caracteres
                if (value.Length > 20)
                {
                    throw new ArgumentException("El número de teléfono no puede tener más de 20 caracteres.");
                }

                // Validar que el teléfono contenga solo dígitos y opcionalmente espacios, guiones o paréntesis
                if (value != null && !System.Text.RegularExpressions.Regex.IsMatch(value, @"^[0-9\s\-\(\)]*$"))
                {
                    throw new ArgumentException("El número de teléfono solo puede contener dígitos, espacios, guiones o paréntesis.");
                }

                field = value;
            }
        }

        public string Mail
        {
            get;

            set
            {
                // Si no se informa un correo, permite dejarlo vacio
                if(string.IsNullOrWhiteSpace(value))
                {
                    field= string.Empty;
                    return;
                }
                
                // Verifica que el mail no supere los 100 caracteres
                if (value.Length > 100)
                {
                    throw new ArgumentException("El mail no puede superar los 100 caracteres.");
                }

                // Verifica que el mail tenga un formato válido
                if (!System.Text.RegularExpressions.Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    throw new ArgumentException("El mail no tiene un formato válido.");
                }

                field = value;
            }
        }

        public Persona()
        {

        }
        public Persona(int id, string nombre, string apellido, string dni, string telefono, string mail)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni;
            Telefono = telefono;
            Mail = mail;
        }
    }
}
