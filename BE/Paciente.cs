using System;

namespace BE
{
    public class Paciente : Persona
    {
        private DateTime _fechaNacimiento;
        private string _numeroAfiliado;

        public int IdPaciente { get; private set; }

        public DateTime FechaNacimiento 
        { 
            get => _fechaNacimiento; 
            
            set
            {
                // Verifica que la fecha de nacimiento no sea mayor a la fecha actual
                if (value > DateTime.Now)
                {
                    throw new ArgumentException("La fecha de nacimiento no puede ser mayor a la fecha actual.");
                }

                _fechaNacimiento = value;
            }
        }
        // Asi puede o no tener Obra Social
        public ObraSocial ObraSocial { get; set; }
        

        public string NumeroAfiliado
        {
            get => _numeroAfiliado;

            // Controla que la longitud del número de afiliado no supere los 30 caracteres
            set
            {
                if (value != null && value.Length > 30)
                {
                    throw new ArgumentException("El número de afiliado no puede superar los 30 caracteres.");
                }

                _numeroAfiliado = value;
            }
        }

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
