using System;

namespace BE
{
    public class ObraSocial
    {
        public int Id { get; private set; }
        public string Nombre { get; set; }

        public ObraSocial()
        { }

        public ObraSocial(int id,string nombre)
        {
            Id= id;
            Nombre= nombre;
        }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
