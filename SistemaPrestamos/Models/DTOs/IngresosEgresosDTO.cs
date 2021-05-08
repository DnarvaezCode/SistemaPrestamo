using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPrestamos.Models.DTOs
{
    public class IngresosEgresosDTO
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string FechaPrestamo { get; set; }
        public string ClientePrestamo { get; set; }
        public float MontoPrestamo { get; set; }
        public float Interes { get; set; }
        public float InteresGanado => Abonos.Sum(x => x.Interes);

        public string ClienteComision { get; set; }
        public float MontoComisionPago{ get; set; }
        public float PorcentajeComisionPAgo { get; set; }
        public List<AbonoDTO> Abonos { get; set; } = new List<AbonoDTO>();
    }
}
