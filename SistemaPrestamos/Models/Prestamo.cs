using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPrestamos.Models
{
    public class Prestamo
    {
        public int Id { get; set; }
        [Display(Name = "Código")]
        public string Codigo { get; set; }
        [Display(Name = "Monto"), Required(ErrorMessage = "El campo {0} es requerido")]
        public float Monto { get; set; }
        [Display(Name = "Interes mensual"), Required(ErrorMessage = "El campo {0} es requerido")]
        public float Interes { get; set; }
        public DateTime Fecha { get; set; }

        [Display(Name = "Cliente"), Required(ErrorMessage = "El campo {0} es requerido")]
        public int ClienteId { get; set; }

        [Display(Name = "Forma de pago"), Required(ErrorMessage = "El campo {0} es requerido")]
        public int FormaPagoId { get; set; }
        public string EstadoPrestamo { get; set; }
        public string EstadoComision { get; set; }
        public Cliente Cliente { get; set; }
        public FormaPago FormaPago { get; set; }
        public List<Abono> Abonos { get; set; }
        public List<Comisione> Comisiones { get; set; }
        public bool Estado { get; set; }
    }
}
