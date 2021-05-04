using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaPrestamos.Context;
using SistemaPrestamos.Models;
using SistemaPrestamos.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPrestamos.Controllers
{
    public class EstadoPrestamoController : Controller
    {
        private readonly PrestamosContext context;
        private readonly IMapper mapper;

        public EstadoPrestamoController(PrestamosContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var estadoPrestamos = await context.EstadoPrestamos.Where(x => x.Estado.Equals(true)).ToListAsync();
            return View(mapper.Map<List<EstadoPrestamoDTO>>(estadoPrestamos));
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EstadoPrestamoDTO estadoPrestamoDTO)
        {
            if (ModelState.IsValid)
            {
                var estadoPrestamo = mapper.Map<EstadoPrestamo>(estadoPrestamoDTO);
                estadoPrestamo.Estado = true;
                await context.EstadoPrestamos.AddAsync(estadoPrestamo);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadoPrestamoDTO);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var estadoPrestamo = await context.EstadoPrestamos.FirstOrDefaultAsync(x => x.Id.Equals(id.GetValueOrDefault()));
            if (estadoPrestamo == null) return NotFound();
            var estadoPrestamoDTO = mapper.Map<EstadoPrestamoDTO>(estadoPrestamo);
            return View(estadoPrestamoDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EstadoPrestamoDTO estadoPrestamoDTO)
        {
            if (ModelState.IsValid)
            {
                var estadoPrestamo = mapper.Map<EstadoPrestamo>(estadoPrestamoDTO);
                context.EstadoPrestamos.Update(estadoPrestamo);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadoPrestamoDTO);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var estadoPrestamo = await context.EstadoPrestamos.FirstOrDefaultAsync(x => x.Id.Equals(id.GetValueOrDefault()));
            if (estadoPrestamo == null) return NotFound();
            var estadoPrestamoDTO = mapper.Map<EstadoPrestamoDTO>(estadoPrestamo);
            return View(estadoPrestamoDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var estadoPrestamo = await context.EstadoPrestamos.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (estadoPrestamo == null) return NotFound();
            estadoPrestamo.Estado = false;
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
