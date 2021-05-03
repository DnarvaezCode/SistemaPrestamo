using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPrestamos.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string CodigoPink { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public bool Estado { get; set; }
        public List<Prestamo> ListaPrestamos { get; set; }
        public List<Comisione> Comisiones { get; set; }

    }
}
