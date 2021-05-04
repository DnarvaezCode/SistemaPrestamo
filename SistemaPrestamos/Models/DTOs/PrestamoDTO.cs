using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPrestamos.Models.DTOs
{
    public class PrestamoDTO
    {
        public string Nombre { get; set; }
        public List<Prestamo> Prestamos { get; set; }
    }
}
