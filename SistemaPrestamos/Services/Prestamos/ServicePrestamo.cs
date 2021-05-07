using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaPrestamos.Context;
using SistemaPrestamos.Models;
using SistemaPrestamos.Models.DTOs;
using SistemaPrestamos.Utilidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SistemaPrestamos.Utilidad.Helper;

namespace SistemaPrestamos.Services.Prestamos
{
    public class ServicePrestamo : IPrestamos
    {
        private readonly PrestamosContext _context;
        private readonly IMapper _mapper;
        public ServicePrestamo(PrestamosContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Prestamo> Create(Prestamo prestamo)
        {
            prestamo.Fecha = DateTime.Now;
            prestamo.EstadoPrestamo = ESTADOPRESTAMO.PENDIENTE.ToString();
            _context.Prestamos.Add(prestamo);
            await _context.SaveChangesAsync();
            return prestamo;
        }

        public async Task<List<PrestamosDTO>> GetAll()
        {
            var prestamos = await (from prestamo in _context.Prestamos
                             join cliente in _context.Clientes on prestamo.ClienteId equals cliente.Id
                             let totalInteres = _context.Abonos.Where(a  => a.PrestamoId == prestamo.Id).Sum(x => x.Interes)
                             let totalCapital = _context.Abonos.Where(a => a.PrestamoId == prestamo.Id).Sum(x => x.Capital)
                             select new PrestamosDTO
                             {
                                 Codigo = prestamo.Codigo,
                                 Fecha = prestamo.Fecha.ToShortDateString(),
                                 IdPrestamo = prestamo.Id,
                                 Cliente = cliente.Nombre,
                                 Monto = prestamo.Monto,
                                 Tasa = prestamo.Interes,
                                 AbonadoInteres = totalInteres,
                                 AbonadoCapital = totalCapital,
                                 Estado = prestamo.EstadoPrestamo,
                                 

                             }).ToListAsync();


            return prestamos;
        }

        public Task<PrestamosDTO> GetById(int IdPrestamo)
        {
            throw new NotImplementedException();
        }

        public Task<PrestamosDTO> Update(Prestamo prestamo)
        {
            throw new NotImplementedException();
        }
    }
}
