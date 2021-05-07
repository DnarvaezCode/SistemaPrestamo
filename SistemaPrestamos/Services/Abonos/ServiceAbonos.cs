using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaPrestamos.Context;
using SistemaPrestamos.Models;
using SistemaPrestamos.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SistemaPrestamos.Utilidad.Helper;

namespace SistemaPrestamos.Services.Abonos
{
    public class ServiceAbonos : IServiceAbonos
    {
        /// <summary>
        ///     Contexto de consultas
        /// </summary>
        private readonly PrestamosContext _context;

        /// <summary>
        ///     Interface de autoMapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        ///     Constructor base inicializa dependencias
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public ServiceAbonos(PrestamosContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        ///     Ejecuta abono de prestamo
        /// </summary>
        /// <param name="abono"></param>
        /// <returns></returns>
        public async Task<Abono> Abonar(Abono abono)
        {
            var prestamo = await _context.Prestamos.FirstOrDefaultAsync(p => p.Id == abono.PrestamoId);
            var pagado = _context.Abonos.Where(x => x.PrestamoId == abono.PrestamoId).Sum(s => s.Capital);
            var mprestamo = prestamo.Monto;
            var saldo = mprestamo - pagado;
            var interes = await CalculaInteres(abono);

            var abonoCapital = abono.Monto > saldo + interes ? saldo : (abono.Monto - interes);
            var abonoInteres = abono.Monto > saldo + interes ? interes + (abono.Monto - saldo) : interes;
            abono.Capital = abonoCapital;
            abono.Interes = abonoInteres;

            abono.Fecha = DateTime.Now;
            _context.Abonos.Add(abono);
            await _context.SaveChangesAsync();

            var pagadoTotal = _context.Abonos.Where(x => x.PrestamoId == abono.PrestamoId).Sum(s => s.Capital);
            prestamo.EstadoPrestamo = prestamo.Monto == pagadoTotal ? ESTADOPRESTAMO.PAGADO.ToString() : ESTADOPRESTAMO.PROCESOPAGO.ToString();
            prestamo.EstadoComision = prestamo.EstadoPrestamo == ESTADOPRESTAMO.PAGADO.ToString() ? ESTADOPRESTAMO.PENDIENTE.ToString() : null;
            await _context.SaveChangesAsync();
            return abono;
        }

        /// <summary>
        ///     Calcula el interes del prestamo, en base al saldo del mismo
        /// </summary>
        /// <param name="abono"></param>
        /// <returns></returns>
        public async Task<float> CalculaInteres(Abono abono) {
            var prestamo = await _context.Prestamos.SingleAsync(x => x.Id == abono.PrestamoId);
            var abonos = _context.Abonos.Where(x => x.PrestamoId == abono.PrestamoId).Sum(a => a.Capital);

            return (prestamo.Monto - abonos) * (prestamo.Interes / 100);
        }

        /// <summary>
        ///     Obtiene todos los abonos por id de prestamo
        /// </summary>
        /// <param name="IdPrestamo"></param>
        /// <returns></returns>
        public async Task<List<AbonoDTO>> GetAllByPrestamo(int IdPrestamo)
        {
            var prestamo = await _context.Prestamos.SingleAsync(x => x.Id == IdPrestamo);

            var abonos = await (from abono in _context.Abonos
                          where abono.PrestamoId == IdPrestamo
                          select new AbonoDTO
                          {
                              Abono = abono.Monto,
                              IdPrestamo = IdPrestamo,
                              Capital = abono.Capital,
                              Fecha = abono.Fecha.ToShortDateString(),
                              Interes = abono.Interes,
                              MontoPrestamo = prestamo.Monto
                          }).ToListAsync();
            return abonos;
        }
    }
}
