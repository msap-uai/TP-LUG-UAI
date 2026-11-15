using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using BE;
using DAL;

namespace BLL
{
    public static class PersonaBLL
    {
        public static List<Persona> ObtenerPersonas() => PersonaDAL.ObtenerPersonas();

        public static List<Persona> ObtenerPersonasNoProfesionales() => PersonaDAL.ObtenerPersonasNoProfesionales();

        public static List<Persona> ObtenerPersonasQueNoSonPacientes() => PersonaDAL.ObtenerPersonasQueNoSonPacientes();

        public static void GuardarPersona(int? id, string nombre, string apellido, string dni, string telefono, string mail)
        {
            int personaId = (id == null) ? 0 : id.Value;

            nombre = (nombre ?? string.Empty).Trim();
            apellido = (apellido ?? string.Empty).Trim();
            dni = (dni ?? string.Empty).Replace(".", "").Replace(" ", "").Trim();
            telefono = (telefono ?? string.Empty).Trim();
            mail = (mail ?? string.Empty).Trim();

            ValidarNombre(nombre);
            ValidarApellido(apellido);
            ValidarDni(dni);
            ValidarTelefono(telefono);
            ValidarMail(mail);
            ValidarDniNoRepetido(personaId, dni);

            Persona persona = new Persona(personaId, nombre, apellido, dni, telefono, mail);

            if (persona.Id == 0)
            {
                PersonaDAL.AgregarPersona(persona);
            }
            else
            {
                PersonaDAL.ModificarPersona(persona);
            }
        }

        public static void EliminarPersona(int id)
        {
            if (PersonaDAL.TieneRegistrosAsociados(id))
            {
                throw new Exception("No se puede eliminar la persona porque está registrada como paciente o profesional.");
            }

            PersonaDAL.EliminarPersona(id);
        }

        public static void ValidarNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre es obligatorio.");
            }

            if (nombre.Length < 2)
            {
                throw new ArgumentException("El nombre debe tener al menos 2 caracteres.");
            }

            if (nombre.Length > 50)
            {
                throw new ArgumentException("El nombre no puede tener más de 50 caracteres.");
            }
        }

        public static void ValidarApellido(string apellido)
        {
            if (string.IsNullOrWhiteSpace(apellido))
            {
                throw new ArgumentException("El apellido es obligatorio.");
            }

            if (apellido.Length < 2)
            {
                throw new ArgumentException("El apellido debe tener al menos 2 caracteres.");
            }

            if (apellido.Length > 50)
            {
                throw new ArgumentException("El apellido no puede tener más de 50 caracteres.");
            }
        }

        public static void ValidarDni(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
            {
                throw new ArgumentException("El DNI es obligatorio.");
            }

            foreach (char c in dni)
            {
                if (!char.IsDigit(c))
                {
                    throw new ArgumentException("El DNI solo debe contener números.");
                }
            }

            if (dni.Length != 8)
            {
                throw new ArgumentException("El DNI debe tener 8 dígitos.");
            }
        }

        public static void ValidarTelefono(string telefono)
        {
            if (telefono.Length == 0)
            {
                return;
            }

            if (telefono.Length > 20)
            {
                throw new ArgumentException("El teléfono no puede tener más de 20 caracteres.");
            }

            for (int i = 0; i < telefono.Length; i++)
            {
                char c = telefono[i];
                if (!char.IsDigit(c) && c != ' ' && c != '-' && c != '(' && c != ')' && c != '+')
                {
                    throw new ArgumentException("El teléfono solo puede contener dígitos, espacios, guiones, paréntesis o el signo +.");
                }
            }
        }

        public static void ValidarMail(string mail)
        {
            if (mail.Length == 0)
            {
                return;
            }

            if (mail.Length > 100)
            {
                throw new ArgumentException("El mail no puede tener más de 100 caracteres.");
            }

            // Verificar que tenga una arroba
            if (!mail.Contains("@"))
            {
                throw new ArgumentException("El mail no tiene un formato válido.");
            }
        }

        private static void ValidarDniNoRepetido(int id, string dni)
        {
            List<Persona> personas = PersonaDAL.ObtenerPersonas();

            bool repetido = personas.Any(persona => persona.Dni == dni && persona.Id != id);

            if (repetido)
            {
                throw new ArgumentException("Ya existe una persona con ese DNI.");
            }
        }
    }
}
