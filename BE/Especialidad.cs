using System;

namespace BE
{
    public class Especialidad
    {
        private string _descripcion;

        public int Id { get; private set; }

        public string Descripcion
        {
            get => _descripcion;

            set
            {
                // Verifica que la descripción de la especialidad exista
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("La descripción es obligatoria.");
                }

                // Verifica que la descripción de la especialidad no supere los 60 caracteres
                if (value.Length > 60)
                {
                    throw new ArgumentException("La descripción no puede superar los 60 caracteres.");
                }

                _descripcion = value;
            }
        }

        public Especialidad()
        {

        }
        public Especialidad(int id, string descripcion)
        {
            Id = id;
            Descripcion = descripcion;
        }
    }
}
