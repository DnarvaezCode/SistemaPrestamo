using SistemaPrestamos.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPrestamos.Services.IngresosEgresos
{
    public interface IServiceIngresoEgreso
    {
        Task<List<IngresosEgresosDTO>> IngresosEgresos();
    }
}
