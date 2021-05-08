using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaPrestamos.Context;
using SistemaPrestamos.Services.IngresosEgresos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPrestamos.Controllers
{
    public class IngresosEgresosController : Controller
    {

        /// <summary>
        ///     Contexto de base de datos
        /// </summary>
        private readonly PrestamosContext _context;

        /// <summary>
        ///     Interface de IMapper
        /// </summary>
        private readonly IMapper _mapper;

        public IServiceIngresoEgreso _ServiceIngresosEgresos { get; set; }

        public IngresosEgresosController(PrestamosContext context, IMapper mapper, IServiceIngresoEgreso ServiceIngresosEgresos)
        {
            _context = context;
            _mapper = mapper;
            _ServiceIngresosEgresos = ServiceIngresosEgresos;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _ServiceIngresosEgresos.IngresosEgresos();
            return View(result);
        }
    }
}
