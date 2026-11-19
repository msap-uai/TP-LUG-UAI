using System;

namespace BE
{
    public class ConsultaEvolucion
    {
        public int Id { get; private set; }

        public Turno Turno { get; set; }
       
        public DateTime FechaAtencion {  get; set; }
       

        public string Observaciones { get; set; }

        public string Diagnostico {  get; set; }
       

        public string Medicacion { get; set;  }
       

        public decimal MontoCobrado { get; set;  }
       
        public ConsultaEvolucion()
        {

        }
        public ConsultaEvolucion(int id, Turno turno, DateTime fechaAtencion,string observaciones, string diagnostico, string medicacion, decimal montoCobrado)
        {
            Id = id;
            Turno = turno;
            FechaAtencion = fechaAtencion;
            Observaciones = observaciones;
            Diagnostico = diagnostico;
            Medicacion = medicacion;
            MontoCobrado = montoCobrado;
        }
    }
}
