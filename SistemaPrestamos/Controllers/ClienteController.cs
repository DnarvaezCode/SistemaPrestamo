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
    public class ClienteController : Controller
    {
        private readonly PrestamosContext context;
        private readonly IMapper mapper;

        public ClienteController(PrestamosContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var clientes = await context.Clientes.Where(x => x.Estado.Equals(true)).ToListAsync();
            return View(mapper.Map<List<ClienteDTO>>(clientes));
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ClienteDTO clienteDTO)
        {
            if (ModelState.IsValid)
            {
                var cliente = mapper.Map<Cliente>(clienteDTO);
                cliente.Estado = true;
                await context.Clientes.AddAsync(cliente);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clienteDTO);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var cliente = await context.Clientes.FirstOrDefaultAsync(x => x.Id.Equals(id.GetValueOrDefault()));
            if (cliente == null) return NotFound();
            var clienteDTO = mapper.Map<ClienteDTO>(cliente);
            return View(clienteDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ClienteDTO clienteDTO)
        {
            if (ModelState.IsValid)
            {
                var cliente = mapper.Map<Cliente>(clienteDTO);
                cliente.Estado = true;
                context.Clientes.Update(cliente);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clienteDTO);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var cliente = await context.Clientes.FirstOrDefaultAsync(x => x.Id.Equals(id.GetValueOrDefault()));
            if (cliente == null) return NotFound();
            var clienteDTO = mapper.Map<ClienteDTO>(cliente);
            return View(clienteDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await context.Clientes.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (cliente == null) return NotFound();
            cliente.Estado = false;
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
