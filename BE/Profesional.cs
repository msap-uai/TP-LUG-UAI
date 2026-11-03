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
                // verifica que la especialidad exista
                if (value == null)
                {
                    throw new Exception( "debe informar la especialidad del profesional");
                }

                especialidad = value;
            }
        }

        public decimal Arancel
        {
            get => arancel;

            set
            {
                // arancel debe ser positivo
                if (value <= 0)
                {
                    throw new Exception("el arancel debe ser un numero positivo.");
                }

                //arancel max 1.000.000
                if (value >= 1000000)
                {
                    throw new Exception("el arancel debe ser menor a 1 millon.");
                }

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
    }
}
