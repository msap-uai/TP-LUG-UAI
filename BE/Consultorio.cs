using System;

namespace BE
{
    public class Consultorio
    {
        private int _numero;

        public int Id { get; private set; }

        public int Numero 
        { 
            get => _numero; 
            
            set
            {
                // Verifica que el número del consultorio sea mayor a 0
                if (value <= 0)
                {
                    throw new ArgumentException("El número del consultorio debe ser mayor a 0.");
                }

                // Controla que el número del consultorio no supere los 9
                if (value > 9)
                {
                    throw new ArgumentException("El número del consultorio no puede ser mayor que 9.");
                }

                _numero = value;
            }
        }

        public Consultorio()
        {

        }
        public Consultorio(int id, int numero)
        {
            Id = id;
            Numero = numero;
        }
    }
}
