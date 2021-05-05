using Microsoft.EntityFrameworkCore;
using SistemaPrestamos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPrestamos.Context
{
    public class PrestamosContext : DbContext
    {
        public PrestamosContext(DbContextOptions<PrestamosContext> options) : base(options)
        {

        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<FormaPago> FormaPagos { get; set; }
        public DbSet<Comisione> Comisiones { get; set; }
        public DbSet<Abono> Abonos { get; set; }
    }
}
