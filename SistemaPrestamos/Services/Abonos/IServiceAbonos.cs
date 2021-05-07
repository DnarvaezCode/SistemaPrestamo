using SistemaPrestamos.Models;
using SistemaPrestamos.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPrestamos.Services.Abonos
{
    public interface IServiceAbonos
    {
        Task<List<AbonoDTO>> GetAllByPrestamo(int IdPrestamo);
        Task<float> CalculaInteres(Abono abono);
        Task<Abono> Abonar(Abono abono);
    }
}
