using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaPrestamos.Context;
using SistemaPrestamos.Models.DTOs;
using System;
using System.Collections.Generic;
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
            var cliente = context.Clientes.FirstOrDefault(x => x.Cedula.Equals("045251090")).Nombre;
            if (cliente is null) return NotFound();
            var prestamos = context.Prestamos.Where(x => x.EstadoPrestamo.Nombre.Equals("Cancelado")).ToList();
            return View(new PrestamoDTO {Nombre = cliente, Prestamos = prestamos });
        }
    }
}
