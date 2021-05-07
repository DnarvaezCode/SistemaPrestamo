using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaPrestamos.Context;
using SistemaPrestamos.Models;
using SistemaPrestamos.Services.Prestamos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPrestamos.Controllers
{
    public class PrestamoController : Controller
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
        private readonly IPrestamos _ServicePrestamos;
        public PrestamoController(PrestamosContext context, IMapper mapper, IPrestamos ServicePrestamos)
        {
            _context = context;
            _mapper = mapper;
            _ServicePrestamos = ServicePrestamos;
        }
        public async Task<IActionResult> Index() { 
            return View(await _ServicePrestamos.GetAll());
        }
        

        /// <summary>
        ///     Vista para crear un nuevo prestamo
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            var codigo = (_context.Prestamos.Count() + 1).ToString();
            codigo = codigo.ToString().PadLeft(5, '0');
            ViewBag.Clientes = _context.Clientes.Select(cl => new SelectListItem { Value = cl.Id.ToString(), Text = cl.Nombre }).ToList();
            ViewBag.FormaPago = _context.FormaPagos.Select(cl => new SelectListItem { Value = cl.Id.ToString(), Text = cl.Nombre }).ToList();
            return View(new Prestamo() { Codigo = codigo.ToString() });
        }

        /// <summary>
        ///     Post de creación de un nuevo prestamo
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(Prestamo prestamo)
        {
            var result = await _ServicePrestamos.Create(prestamo);
            if (result.Id == default) return View();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update()
        {
            return View();
        }

        public async Task<IActionResult> Update(Prestamo prestamo)
        {
            return View();
        }
    }
}
