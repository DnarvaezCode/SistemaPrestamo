using SistemaPrestamos.Models;
using SistemaPrestamos.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPrestamos.Services.Prestamos
{
    public interface IPrestamos
    {
        Task<List<PrestamosDTO>> GetAll();
        Task<PrestamosDTO> GetById(int IdPrestamo);
        Task<Prestamo> Create(Prestamo prestamo);
        Task<PrestamosDTO> Update(Prestamo prestamo);
    }
}
