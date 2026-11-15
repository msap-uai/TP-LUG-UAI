using System;

namespace BE
{
    public class Profesional : Persona
    {
        public int IdProfesional { get; private set; }

        public string Matricula{ get; set; }
         

        private Especialidad especialidad;
        private decimal arancel;

        public Especialidad Especialidad
        {
            get => especialidad;

            set
            {
                especialidad = value;
            }
        }

        public decimal Arancel
        {
            get => arancel;

            set
            {
                arancel = value;
            }
        }

        public Profesional()
        {

        }
        public Profesional(int idPersona, int idProfesional,string nombre, string apellido, string dni, string telefono, string mail, string matricula, Especialidad especialidad, decimal arancel): base(idPersona, nombre, apellido, dni, telefono, mail)
        {
            IdProfesional = idProfesional;
            Matricula = matricula;
            Especialidad = especialidad;
            Arancel = arancel;
        }

        public override string ObtenerDatosPersona()
        {
            return "Dr /Dra " + Apellido + ", " + Nombre + " (Mat: " + Matricula + ") - " + Especialidad;
        }

        public override decimal CalcularCostoFinal(decimal arancelBase)
        {
            return Arancel;
        }
    }
}
