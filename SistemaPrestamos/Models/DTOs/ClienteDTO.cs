using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPrestamos.Models.DTOs
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="El nombre es requerido.")]
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        [Required(ErrorMessage = "El código pink es requerido.")]
        public string CodigoPink { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public bool Estado { get; set; }
    }
}
