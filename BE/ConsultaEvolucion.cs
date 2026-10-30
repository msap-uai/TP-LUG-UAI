using System;

namespace BE
{
    public class ConsultaEvolucion
    {
        public int Id { get; private set; }

        public Turno Turno
        {
            get;

            set
            {
                // VERIFICAR SI EL TURNO PUEDE SER NULO

                // Validar que el turno exista
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(Turno), "El turno es obligatorio.");
                }

                field = value;
            }
        }

        public DateTime FechaAtencion 
        {             
            get; 
            
            // VALIDAMOS QUE LA FECHA SEA LA DEL TURNO ?
            set; 
        }

        public string Observaciones { get; set; }

        public string Diagnostico
        {
            get;

            set
            {
                // NO SERIA BUENO QUE TENGA LA LONGITUD COMO LAS OBSERVACIONES ?

                // Validar que el diagnóstico no supere los 500 caracteres
                if (value != null && value.Length > 500)
                {
                    throw new ArgumentException("El diagnóstico no puede superar los 500 caracteres.");
                }

                field = value;
            }
        }

        public string Medicacion
        {
            get;

            set
            {
                // IGUAL QUE EL DIAGNOSTICO, NO SERIA BUENO QUE TENGA LA LONGITUD COMO LAS OBSERVACIONES ?

                // Validar que la medicación no supere los 500 caracteres
                if (value != null && value.Length > 500)
                {
                    throw new ArgumentException("La medicación no puede superar los 500 caracteres.");
                }

                field = value;
            }
        }

        public decimal MontoCobrado
        {
            get;

            set
            {
                // Validar que el monto cobrado sea un número positivo
                if (value < 0)
                {
                    throw new ArgumentException("El monto cobrado no puede ser negativo.");
                }

                // Validar que el monto cobrado no sea mayor a 100 millones 
                if (value >= 100000000m)
                {
                    throw new ArgumentException("El monto cobrado no debe superar los 100 millones.");
                }

                // VALIDAMOS CONTRA EL ARANCEL DEL PROFESIONAL ?

                field = value;
            }
        }
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
