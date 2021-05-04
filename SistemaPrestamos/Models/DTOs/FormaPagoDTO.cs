using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPrestamos.Models.DTOs
{
    public class FormaPagoDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "La forma de pago es requerida.")]
        public string Nombre { get; set; }
        public bool Estado { get; set; }
    }
}
