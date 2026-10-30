using BE;
using DAL;
using System.Collections.Generic;

namespace BLL
{
    public static class ObraSocialBLL
    {
        public static List<ObraSocial> ObtenerObrasSociales() => ObraSocialDAL.ObtenerObrasSociales();
    }
}
