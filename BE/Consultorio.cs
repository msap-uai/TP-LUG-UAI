using System;

namespace BE
{
    public class Consultorio
    {
        public int Id { get; set; }
        public int Numero { get; set; }

        public Consultorio()
        {
        }

        public Consultorio(int id, int numero)
        {
            Id = id;
            Numero = numero;
        }

        public string Descripcion
        {
            get { return "Consultorio " + Numero; }
        }

        public override string ToString()
        {
            return "Consultorio " + Numero;
        }
    }
}
