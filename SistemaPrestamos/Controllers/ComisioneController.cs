using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaPrestamos.Context;
using SistemaPrestamos.Models;
using SistemaPrestamos.Models.DTOs;
using SistemaPrestamos.Utilidad;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPrestamos.Controllers
{
    public class ComisioneController : Controller
    {
        private readonly PrestamosContext context;
        private readonly IMapper mapper;

        public ComisioneController(PrestamosContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var cliente = context.Clientes.FirstOrDefault(x => x.Cedula.Equals("NODEFINIDO"));
            if (cliente is null) return NotFound();
            var prestamos = context.Prestamos.Where(x => x.EstadoPrestamo.Equals(Helper.ESTADOPRESTAMO.PAGADO.ToString()) && x.EstadoComision.Equals(Helper.ESTADOCOMISION.PENDIENTE.ToString())).ToList();
            return View(new ComisionDTO { Id = cliente.Id, Nombre = cliente.Nombre, Prestamos = prestamos });
        }

        public JsonResult ObtenerMontoDePrestamoPorId(int id)
        {
            return Json(context.Prestamos.Select(x => new { x.Id, x.Monto, x.EstadoComision }).FirstOrDefault(x => x.Id.Equals(id)));
        }

        public async Task<JsonResult> GuardarComision(List<ComisionDTO> comisionDTO)
        {
            var comisiones = mapper.Map<List<Comisione>>(comisionDTO);
            await context.Comisiones.AddRangeAsync(comisiones);
            foreach (var item in comisiones)
            {
                var prestamo = await context.Prestamos.FirstOrDefaultAsync(x => x.Id.Equals(item.PrestamoId));
                prestamo.EstadoComision = Helper.ESTADOCOMISION.PAGADO.ToString();
            }
            int save = await context.SaveChangesAsync();
            return Json(new { Data = save });
        }
    }
}
