using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPrestamos.Models
{
    public class Abono
    {
        public int Id { get; set; }
        public int PrestamoId { get; set; }
        public float Monto { get; set; }
        public float Interes { get; set; }
        public float Capital { get; set; }
        public DateTime Fecha { get; set; }
        public Prestamo Prestamo { get; set; }
    }
}
