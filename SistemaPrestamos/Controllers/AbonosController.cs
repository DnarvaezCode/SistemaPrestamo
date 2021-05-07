using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaPrestamos.Context;
using SistemaPrestamos.Services.Abonos;
using SistemaPrestamos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPrestamos.Controllers
{
    public class AbonosController : Controller
    {

        /// <summary>
        ///     Contexto de base de datos
        /// </summary>
        private readonly PrestamosContext _context;

        /// <summary>
        ///     Interface de IMapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        ///     Servicio de operaciones y consultas para prestamos
        /// </summary>
        private readonly IServiceAbonos _ServiceAbonos;

        /// <summary>
        ///     Constructor base, inicializa dependencias
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public AbonosController(PrestamosContext context, IMapper mapper, IServiceAbonos ServiceAbonos)
        {
            _context = context;
            _mapper = mapper;
            _ServiceAbonos = ServiceAbonos;
        }

        /// <summary>
        ///     Vista inicial de los abonos
        /// </summary>
        /// <param name="IdPrestamo"></param>
        /// <returns></returns>
        public async Task<IActionResult> Index(int IdPrestamo)
        {
            var prestamo = await _context.Prestamos.FirstOrDefaultAsync(x => x.Id == IdPrestamo);
            if (prestamo is null) return NotFound();

            var modelo = new AbonosViewModels(_context, IdPrestamo);
            modelo.DetallePrestamo();

            modelo.Abonos = await _ServiceAbonos.GetAllByPrestamo(IdPrestamo);
            modelo.Saldo = (modelo.Prestamo - modelo.Abonos.Sum(x => x.Capital)).ToString("F");
            modelo.Pagado = _context.Prestamos.FirstOrDefault(x => x.Id == IdPrestamo).Monto == modelo.Abonos.Sum(s => s.Capital);

            modelo.Minimo = (float)Math.Ceiling(await _ServiceAbonos.CalculaInteres(new Models.Abono { PrestamoId = IdPrestamo, Monto = 0 }));
            modelo.Maximo = (float)Math.Ceiling((modelo.Prestamo - modelo.Abonos.Sum(x => x.Capital)) + (await _ServiceAbonos.CalculaInteres(new Models.Abono { PrestamoId = IdPrestamo, Monto = 0 })));
            modelo.Monto = (float)Math.Ceiling((decimal)modelo.Minimo);
            return View(modelo);
        }

        /// <summary>
        ///     Ejeucta abono del prestamo
        /// </summary>
        /// <param name="abonosViewModels"></param>
        /// <returns></returns>
        public async Task<IActionResult> Abonar(AbonosViewModels abonosViewModels)
        {
            await _ServiceAbonos.Abonar(new Models.Abono { Monto = abonosViewModels.Monto, PrestamoId = abonosViewModels.IdPrestamo });
            return RedirectToAction(nameof(Index), new { IdPrestamo = abonosViewModels.IdPrestamo });
        }
    }
}
