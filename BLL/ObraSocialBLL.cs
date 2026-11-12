using System;
using System.Collections.Generic;
using BE;
using DAL;
using MPP;

namespace BLL
{
    public class ObraSocialBLL
    {
       
        
        public List<ObraSocial> ObtenerObrasSociales() => ObraSocialDAL.ObtenerObrasSociales();

        public void GuardarObraSocial(int? id, string nombre)
        {
            string nombreLimpio = nombre.Trim();

            int obraSocialId = (id == null) ? 0 : id.Value;

            ValidarNombre(nombreLimpio);

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

        public void EliminarObraSocial(int id)
        {
            try
            {
                
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
    }
}
