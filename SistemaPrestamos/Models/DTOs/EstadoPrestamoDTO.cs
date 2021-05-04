using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPrestamos.Models.DTOs
{
    public class EstadoPrestamoDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="El estado del préstamo es requerido.")]
        public string Nombre { get; set; }
        public bool Estado { get; set; }
    }
}
