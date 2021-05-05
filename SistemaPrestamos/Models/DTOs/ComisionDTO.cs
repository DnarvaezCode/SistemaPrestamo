using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPrestamos.Models.DTOs
{
    public class ComisionDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int ClienteId { get; set; }
        public int PrestamoId { get; set; }
        public float Porcentaje { get; set; }
        public float Monto { get; set; }
        public List<Prestamo> Prestamos { get; set; }
    }
}
