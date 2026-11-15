using System;

namespace BE
{
    public class Paciente : Persona
    {
        
        public int IdPaciente { get; private set; }

        public DateTime FechaNacimiento {  get; set; }
       
      
        public ObraSocial ObraSocial { get; set; }
        

        public string NumeroAfiliado {  get; set; }
        
        public Paciente()
        {

        }
        public Paciente(int idPersona, int idPaciente, string nombre, string apellido, string dni, string telefono, string mail, DateTime fechaNacimiento, ObraSocial obraSocial, string numeroAfiliado) : base(idPersona, nombre, apellido, dni, telefono, mail)
        {
            IdPaciente = idPaciente;
            FechaNacimiento = fechaNacimiento;
            ObraSocial = obraSocial;
            NumeroAfiliado = numeroAfiliado;
        }

        public override string ObtenerDatosPersona()
        {
            // condicional para saber si tiene obra social o no
            string os = ObraSocial != null ? ObraSocial.Nombre : "Particular";
            return Apellido + ", " + Nombre + " (DNI: " + Dni + ") - OS: " + os;
        }

        public override decimal CalcularCostoFinal(decimal arancelBase)
        {
            // si tiene obra social paga la mitad, si es particular paga todo
            if (ObraSocial != null)
            {
                return arancelBase * 0.5m;
            }
            return arancelBase;
        }
    }
}
