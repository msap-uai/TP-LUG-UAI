using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace BLL
{
    public class PacienteBLL
    {

        
        public List<Paciente> ObtenerPacientes()
        {
            try
            {
               return PacienteDAL.ObtenerPacientes();

            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo obtener la lista de pacientes"+ ex.Message, ex);
            }
        }



        public List<Paciente> ObtenerPacientesPorObraSocial(int idObraSocial)
        {
            try
            {
                return PacienteDAL.ObtenerPacientesPorObraSocial(idObraSocial);
            }
            catch (Exception ex)
            {
                throw new Exception("No se obtuvo la lista de pacientes por obra social"+ ex.Message,ex);
            }
           
        }

        public static void AgregarPaciente(Paciente paciente)
        {
            try
            {
                if (paciente == null)
                {
                    throw new Exception("El paciente no puede ser nulo.");
                }
                // Normalizar los datos personales
                paciente.Nombre = (paciente.Nombre ?? string.Empty).Trim();
                paciente.Apellido = (paciente.Apellido ?? string.Empty).Trim();
                paciente.Dni = (paciente.Dni ?? string.Empty)
                    .Replace(".", "")
                    .Replace(" ", "")
                    .Trim();

                paciente.Telefono = (paciente.Telefono ?? string.Empty).Trim();
                paciente.Mail = (paciente.Mail ?? string.Empty).Trim();

                // Validaciones de PersonaBLL
                PersonaBLL.ValidarNombre(paciente.Nombre);
                PersonaBLL.ValidarApellido(paciente.Apellido);
                PersonaBLL.ValidarDni(paciente.Dni);
                PersonaBLL.ValidarTelefono(paciente.Telefono);
                PersonaBLL.ValidarMail(paciente.Mail);

                // Validaciones específicas del paciente
                if (paciente.FechaNacimiento == DateTime.MinValue || paciente.FechaNacimiento.Date > DateTime.Today)
                {
                    throw new Exception("La fecha de nacimiento no es válida.");
                }

                if (paciente.ObraSocial != null && paciente.ObraSocial.Id <= 0)
                {
                    throw new Exception("La obra social seleccionada no es válida.");
                }

                using (TransactionScope transaccion = new TransactionScope())
                {
                    // Buscar si la persona ya existe por DNI
                    Persona personaExistente = PersonaDAL.ObtenerPersonaPorDni(paciente.Dni);

                    int idPersona;

                    if (personaExistente == null)
                    {
                        // La persona no existe: registrarla
                        idPersona = PersonaDAL.AgregarPersona(paciente);
                    }
                    else
                    {
                        // La persona ya existe: recuperar su ID
                        idPersona = personaExistente.Id;

                        // Comprobar si ya está registrada como paciente
                        if (PacienteDAL.ExistePacientePorIdPersona(idPersona))
                        {
                            throw new Exception("La persona ya esta registrada como paciente.");
                        }
                    }

                    // Registrar el paciente utilizando el ID_PERSONA
                    PacienteDAL.AgregarPaciente(paciente, idPersona);

                    // Confirmar todas las operaciones
                    transaccion.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el paciente: " + ex.Message, ex);
            }
        }

        public void ModificarPaciente(Paciente paciente)
        {

            if (paciente == null)
            {
                throw new Exception("Tiene que existir el paciente");
            }

            if (paciente.IdPaciente <= 0)
            {
                throw new Exception("Debe seleccionar un paciente válido para modificar.");
            }

            if (paciente.Id <= 0)
            {
                throw new Exception("La persona asociada al paciente no es válida.");
            }

            // Normalizar los datos personales
            paciente.Nombre = (paciente.Nombre ?? string.Empty).Trim();
            paciente.Apellido = (paciente.Apellido ?? string.Empty).Trim();

            paciente.Dni = (paciente.Dni ?? string.Empty).Replace(".", "").Replace(" ", "").Trim();

            paciente.Telefono = (paciente.Telefono ?? string.Empty).Trim();
            paciente.Mail = (paciente.Mail ?? string.Empty).Trim();

            // Validaciones de PersonaBLL
            PersonaBLL.ValidarNombre(paciente.Nombre);
            PersonaBLL.ValidarApellido(paciente.Apellido);
            PersonaBLL.ValidarDni(paciente.Dni);
            PersonaBLL.ValidarTelefono(paciente.Telefono);
            PersonaBLL.ValidarMail(paciente.Mail);

            // Validaciones específicas del paciente

            if (paciente.FechaNacimiento == DateTime.MinValue)
            {
                throw new Exception("Debe ingresar la fecha de nacimiento.");
            }

            if (paciente.FechaNacimiento.Date > DateTime.Today)
            {
                throw new Exception("La fecha de nacimiento no puede ser futura.");
            }

            if (paciente.ObraSocial != null && paciente.ObraSocial.Id <= 0)
            {
                throw new Exception("La obra social seleccionada no es válida.");
            }

            try
            {
                using (var trx = new TransactionScope())
                {
                    // Verificar si el DNI pertenece a otra persona
                    Persona personaExistente = PersonaDAL.ObtenerPersonaPorDni(paciente.Dni);

                    if (personaExistente != null && personaExistente.Id != paciente.Id)
                    {
                        throw new Exception("El DNI ingresado pertenece a otra persona.");
                    }
                    PacienteDAL.ModificarPaciente(paciente);
                    trx.Complete();
                }
            }
            catch (Exception ex) 
            {
                throw new Exception("No se pudo modificar el paciente"+ex.Message,ex);
            }
        }

        public void EliminarPaciente(int idPaciente)
        {
            try
            {
                if (idPaciente <= 0)
                    {
                        throw new Exception("Debe seleccionar un paciente válido para eliminar.");
                    }
                using (var trx = new TransactionScope())
                {
                    if (TurnoDAL.ExisteTurnoPorPaciente(idPaciente))
                    {
                        throw new Exception("No se puede eliminar al paciente porque tiene turnos registrados.");
                    }

                    PacienteDAL.EliminarPaciente(idPaciente);

                    trx.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar el paciente: " + ex.Message, ex);
            }
        }



    }
}
