using Microsoft.AspNetCore.Mvc;
using SistemaPrestamos.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPrestamos.Controllers
{
    public class ClienteController : Controller
    {
        private readonly PrestamosContext context;

        public ClienteController(PrestamosContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View(context.Clientes.ToList());
        }
    }
}
