using System;

namespace BE
{
    public class Profesional : Persona
    {
        public int IdProfesional { get; private set; }

        public string Matricula{ get; set; }
         // Las validaciones de matricula es mejor en BLL, ademas matricula puede tener Letras  

        public Especialidad Especialidad
        {
            get;

            set
            {
                // Verifica que la especialidad exista
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(Especialidad), "Debe informar la especialidad del profesional.");
                }

                field = value;
            }
        }

        public decimal Arancel
        {
            get;

            set
            {
                // El arancel debe ser un número positivo
                if (value <= 0)
                {
                    throw new ArgumentException("El arancel debe ser un número positivo.");
                }

                // Limite superior del arancel de 100 millones
                if (value >= 100000000m)
                {
                    throw new ArgumentException("El arancel debe ser menor a 100 millones.");
                }

                field = value;
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
