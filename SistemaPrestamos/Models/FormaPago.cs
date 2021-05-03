using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPrestamos.Models
{
    public class FormaPago
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
    }
}
