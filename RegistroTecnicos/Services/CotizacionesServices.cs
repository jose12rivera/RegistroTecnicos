using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class CotizacionesServices
{
    private readonly Contexto _contexto;
    public CotizacionesServices(Contexto contexto)
    {
        _contexto = contexto;
    }
    public async Task<bool> Existe(int CotizacionId)
    {
        return await _contexto.Cotizaciones.AnyAsync(c => c.CotizacionId == CotizacionId);
    }
    private async Task<bool> Insertar(Cotizaciones cotizacion)
    {
        _contexto.Cotizaciones.Add(cotizacion);
        return await _contexto.SaveChangesAsync() > 0;
    }
    private async Task<bool> Modificar(Cotizaciones cotizacion)
    {
        _contexto.Cotizaciones.Update(cotizacion);
        return await _contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool> Guardar(Cotizaciones cotizacion)
    {
        if (!await Existe(cotizacion.CotizacionId))
            return await Insertar(cotizacion);
        else
            return await Modificar(cotizacion);
    }
    public async Task <bool> Eliminar(int id)
    {
        var eliminado = await _contexto.Cotizaciones
            .Where(c => c.CotizacionId == id)
            .ExecuteDeleteAsync();
        return eliminado > 0;
    }
    public async Task<Cotizaciones?> Buscar(int id)
    {
        return await _contexto.Cotizaciones
            .Include(c => c.Clientes)
            .Include(c => c.CotizacionesDetalle)
             .Include(c => c.Articulos)
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.CotizacionId == id);
    }
    public async Task<List<Cotizaciones>> Listar(Expression<Func<Cotizaciones, bool>> Criterio)
    {
        return await _contexto.Cotizaciones
            .Include(c => c.Clientes)
            .Include(c => c.CotizacionesDetalle)
            .Include(c => c.Articulos)
            .AsNoTracking()
            .Where(Criterio)
            .ToListAsync();
    }
    public async Task<List<Cotizaciones>> ListaCotizaciones()
    {
        return await _contexto.Cotizaciones
           .AsNoTracking()
           .ToListAsync();
    }
}
