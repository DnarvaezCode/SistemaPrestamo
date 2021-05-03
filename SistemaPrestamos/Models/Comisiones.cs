using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPrestamos.Models
{
    public class Comisione
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int PrestamoId { get; set; }
        public float Porcentaje { get; set; }
        public float Monto { get; set; }
        public Cliente Cliente { get; set; }
        public Prestamo Prestamo { get; set; }
    }
}
