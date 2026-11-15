using System;
using System.Collections.Generic;
using BE;
using DAL;
using MPP;

namespace BLL
{
    public class ObraSocialBLL
    {


        public List<ObraSocial> ObtenerObrasSociales()
        {
            try
            {
                return ObraSocialDAL.ObtenerObrasSociales();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las obras sociales: " + ex.Message, ex);
            }
        }

        public void GuardarObraSocial(int? id, string nombre)
        {
            try
            {
                string nombreLimpio = nombre.Trim();

                int obraSocialId = (id == null) ? 0 : id.Value;

                ValidarNombre(nombreLimpio);
                // VALIDAR QUE NO EXISTA OTRA OBRA SOCIAL CON EL MISMO NOMBRE

                List<ObraSocial> existentes = ObraSocialDAL.ObtenerObrasSociales();

                foreach (var obra in existentes)
                {
                    if (obra.Id != obraSocialId && string.Equals(obra.Nombre.Trim(), nombreLimpio, StringComparison.OrdinalIgnoreCase))
                    {
                        throw new Exception("Ya existe una obra social con ese nombre.");
                    }
                }

                ObraSocial obraSocial = ObraSocialMapper.Map(obraSocialId, nombreLimpio);

                if (obraSocial.Id == 0)
                {
                    ObraSocialDAL.AgregarObraSocial(obraSocial);
                }
                else
                {
                    ObraSocialDAL.ModificarObraSocial(obraSocial);
                }
            }
            catch
            {
                throw;
            }
                
        }

        public void EliminarObraSocial(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new Exception("Debe seleccionar una obra social válida para eliminar.");
                }

                PacienteBLL pacienteBLL = new PacienteBLL();
                List<Paciente> pacientes = pacienteBLL.ObtenerPacientesPorObraSocial(id);
                if (pacientes.Count > 0)
                {
                    throw new Exception("No se puede eliminar la obra social porque hay pacientes en ella.");
                }
                ObraSocialDAL.EliminarObraSocial(id);
            }
            catch
            {
                throw;
            }
        }

        private void ValidarNombre(string nombre)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    throw new System.ArgumentException("El nombre no puede estar vacío.");
                }

                if (nombre.Length > 100)
                {
                    throw new System.ArgumentException("El nombre no puede tener más de 100 caracteres.");
                }

                if (nombre.Length < 3)
                {
                    throw new System.ArgumentException("El nombre debe tener al menos 3 caracteres.");
                }
            }
            catch
            {
                throw;
            }
            
        }
    }
}
