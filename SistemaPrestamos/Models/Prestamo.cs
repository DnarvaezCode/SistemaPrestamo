using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPrestamos.Models
{
    public class Prestamo
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public float Monto { get; set; }
        public float Interes { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public int FormaPagoId { get; set; }
        public int EstadoPrestamoId { get; set; }
        public Cliente Cliente { get; set; }
        public FormaPago FormaPago { get; set; }
        public List<Abono> Abonos { get; set; }
        public List<Comisione> Comisiones { get; set; }
        public EstadoPrestamo EstadoPrestamo { get; set; }
        public bool Estado { get; set; }
    }
}
