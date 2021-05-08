using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaPrestamos.Context;
using SistemaPrestamos.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPrestamos.Services.IngresosEgresos
{
    public class ServiceIngresoEgreso : IServiceIngresoEgreso
    {
        /// <summary>
        ///     Contexto de consultas
        /// </summary>
        private readonly PrestamosContext _context;

        /// <summary>
        ///     Interface de autoMapper
        /// </summary>
        private readonly IMapper _mapper;

        public ServiceIngresoEgreso(PrestamosContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<IngresosEgresosDTO>> IngresosEgresos()
        {
            var query = await (from prestamo in _context.Prestamos
                               join cliente in _context.Clientes on prestamo.ClienteId equals cliente.Id
                               

                               join comision in _context.Comisiones on prestamo.Id equals comision.PrestamoId into comi
                               from pco in comi.DefaultIfEmpty()
                               join uComision in _context.Clientes on pco.ClienteId equals uComision.Id into ucomi
                               from leftComi in ucomi.DefaultIfEmpty()


                               group new { prestamo, pco, cliente, leftComi } by new
                               {
                                   Id = prestamo.Id,
                                   Codigo = prestamo.Codigo,
                                   Fecha = prestamo.Fecha,
                                   Monto =  prestamo.Monto,
                                   Interes = prestamo.Interes,
                                   EstadoPrestamo = prestamo.EstadoPrestamo,
                                   EstadoComision = prestamo.EstadoComision,

                                   Nombre = cliente.Nombre,

                                   MontoComision = pco == null ? default :pco.Monto,
                                   Porcentaje = pco == null ? default : pco.Porcentaje,
                                   ClienteComision = leftComi == null ? default : leftComi.Nombre
                               }
                               into grupo
                               select new IngresosEgresosDTO
                               {
                                   Id = grupo.Key.Id,
                                   Codigo = grupo.Key.Codigo,
                                   FechaPrestamo = grupo.Key.Fecha.ToShortDateString(),
                                   ClientePrestamo = grupo.Key.Nombre,
                                   MontoPrestamo = grupo.Key.Monto,
                                   Interes = grupo.Key.Interes,

                                   ClienteComision = grupo.Key.ClienteComision,
                                   MontoComisionPago = grupo.Key.MontoComision,
                                   PorcentajeComisionPAgo = grupo.Key.Porcentaje,

                               }
                         ).ToListAsync();

            query.ForEach(x => x.Abonos = (from abono in _context.Abonos
                                                    where abono.PrestamoId == x.Id
                                                    select new AbonoDTO
                                                    {

                                                        Abono = abono.Monto,
                                                        IdPrestamo = x.Id,
                                                        Capital = abono.Capital,
                                                        Fecha = abono.Fecha.ToShortDateString(),
                                                        Interes = abono.Interes,
                                                        MontoPrestamo = x.MontoPrestamo
                                                    }).ToList());
            return query;
        }

    }
}
