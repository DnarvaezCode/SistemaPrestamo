using SistemaPrestamos.Context;
using SistemaPrestamos.Models;
using SistemaPrestamos.Models.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPrestamos.ViewModels
{
    public class AbonosViewModels
    {
        /// <summary>
        ///     Contexto de base de datos
        /// </summary>
        private readonly PrestamosContext _context;
        public AbonosViewModels()
        {

        }
        public AbonosViewModels(PrestamosContext context, int IdPrestamo)
        {
            _context = context;
            this.IdPrestamo = IdPrestamo;
        }
        public float Prestamo { get; set; }
        public string Cliente { get; set; }
        public string Fecha { get; set; }
        public string Saldo { get; set; }
        public int IdPrestamo { get; set; }
        [DataType( DataType.Currency), Required(ErrorMessage = "El campo {0} es requerido")]
        public float Monto { get; set; }
        public bool Pagado { get; set; }
        public float Minimo { get; set; }
        public float Maximo { get; set; }
        public List<AbonoDTO> Abonos { get; set; }

        public AbonosViewModels DetallePrestamo() {

            var modelo = this;
            var prestamo = _context.Prestamos.SingleOrDefault(x => x.Id == IdPrestamo);
            modelo.Cliente = _context.Clientes.FirstOrDefault(cl => cl.Id == prestamo.ClienteId)?.Nombre ?? string.Empty;
            modelo.Fecha = prestamo.Fecha.ToShortDateString();
            modelo.Prestamo = prestamo.Monto;
            return modelo;
        }
    }
}
