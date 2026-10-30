using System;

namespace BE
{
    public class ObraSocial
    {
        public int Id { get; private set; }


        public string Nombre
        {
            get;

            set
            {
                // Verifica que el nombre de la obra social exista
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El nombre de la obra social es obligatorio.");
                }

                // Verifica que el nombre de la obra social no supere los 100 caracteres
                if (value.Length > 100)
                {
                    throw new ArgumentException("El nombre de la obra social no puede superar los 100 caracteres.");
                }

                field = value;
            }
        }

        public ObraSocial()
        {

        }
        public ObraSocial(int id,string nombre)
        {
            Id= id;
            Nombre= nombre;
        }
    }
}
