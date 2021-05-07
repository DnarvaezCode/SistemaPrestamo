using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPrestamos.Models.DTOs
{
    public class PrestamosDTO
    {
        public string Codigo { get; set; }
        public int IdPrestamo { get; set; }
        public string Fecha { get; set; }
        public string Cliente { get; set; }
        public float Monto { get; set; }
        public float Tasa { get; set; }
        public float AbonadoInteres { get; set; }
        public float AbonadoCapital { get; set; }
        public float Resta { get; set; }
        public string Estado { get; set; }
    }
}
