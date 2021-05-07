using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPrestamos.Models.DTOs
{
    public class AbonoDTO
    {
        public int IdPrestamo { get; set; }
        public float MontoPrestamo { get; set; }
        public float Abono { get; set; }
        public float Interes { get; set; }
        public float Capital { get; set; }
        public string Fecha { get; set; }
    }
}
