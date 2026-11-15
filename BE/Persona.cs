using System;

namespace BE
{
    public class Persona
    {
        public int Id { get; private set; }


        public string Nombre { get; set; } = string.Empty;
        
        public string Apellido {  get; set; } = string.Empty;
       

        public string Dni {  get; set; } = string.Empty;
       
        public string Telefono {  get; set; } = string.Empty;
       

        public string Mail {  get; set; } = string.Empty;
       
        public string NombreCompleto
        {
            get { return Apellido + ", " + Nombre; }
        }

        public string NombreCompletoConDNI
        {
            get { return Apellido + ", " + Nombre + " (" + Dni + ")"; }
        }

        public override string ToString()
        {
            return Apellido + ", " + Nombre;
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

        public virtual string ObtenerDatosPersona()
        {
            return Apellido + ", " + Nombre + " (DNI: " + Dni + ")";
        }

        public virtual decimal CalcularCostoFinal(decimal arancelBase)
        {
            return arancelBase;
        }
    }
}
