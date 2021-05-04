using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaPrestamos.Context;
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
            return View();
        }
    }
}
