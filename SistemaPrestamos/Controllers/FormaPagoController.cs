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
    public class FormaPagoController : Controller
    {
        private readonly PrestamosContext context;
        private readonly IMapper mapper;

        public FormaPagoController(PrestamosContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var formaPagos = await context.FormaPagos.Where(x => x.Estado.Equals(true)).ToListAsync();
            return View(mapper.Map<List<FormaPagoDTO>>(formaPagos));
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(FormaPagoDTO formaPagoDTO)
        {
            if (ModelState.IsValid)
            {
                var formaPago = mapper.Map<FormaPago>(formaPagoDTO);
                formaPago.Estado = true;
                await context.FormaPagos.AddAsync(formaPago);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(formaPagoDTO);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var formaPago = await context.FormaPagos.FirstOrDefaultAsync(x => x.Id.Equals(id.GetValueOrDefault()));
            if (formaPago == null) return NotFound();
            var formaPagoDTO = mapper.Map<FormaPagoDTO>(formaPago);
            return View(formaPagoDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FormaPagoDTO formaPagoDTO)
        {
            if (ModelState.IsValid)
            {
                var formaPago = mapper.Map<FormaPago>(formaPagoDTO);
                context.FormaPagos.Update(formaPago);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(formaPagoDTO);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var formaPago = await context.FormaPagos.FirstOrDefaultAsync(x => x.Id.Equals(id.GetValueOrDefault()));
            if (formaPago == null) return NotFound();
            var formaPagoDTO = mapper.Map<FormaPagoDTO>(formaPago);
            return View(formaPagoDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var formaPago = await context.FormaPagos.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (formaPago == null) return NotFound();
            formaPago.Estado = false;
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
