using System;

namespace BE
{
    public class Especialidad
    {
        public int Id { get; private set; }

        public string Descripcion { get; set; }

        public Especialidad()
        { }

        public Especialidad(int id, string descripcion) : this()
        {
            Id = id;
            Descripcion = descripcion;
        }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
