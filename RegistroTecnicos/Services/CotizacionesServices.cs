using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class CotizacionesServices(IDbContextFactory<Contexto> DbFactory)
{
   
    public async Task<bool> Existe(int CotizacionId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Cotizaciones.AnyAsync(c => c.CotizacionId == CotizacionId);
    }
    private async Task<bool> Insertar(Cotizaciones cotizacion)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Cotizaciones.Add(cotizacion);
        return await contexto.SaveChangesAsync() > 0;
    }
    private async Task<bool> Modificar(Cotizaciones cotizacion)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Cotizaciones.Update(cotizacion);
        return await contexto.SaveChangesAsync() > 0;
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
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var eliminado = await contexto.Cotizaciones
            .Where(c => c.CotizacionId == id)
            .ExecuteDeleteAsync();
        return eliminado > 0;
    }
    public async Task<Cotizaciones?> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Cotizaciones
            .Include(c => c.Clientes)
            .Include(c => c.CotizacionesDetalle)
             .Include(c => c.Articulos)
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.CotizacionId == id);
    }
    public async Task<List<Cotizaciones>> Listar(Expression<Func<Cotizaciones, bool>> Criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Cotizaciones
            .Include(c => c.Clientes)
            .Include(c => c.CotizacionesDetalle)
            .Include(c => c.Articulos)
            .AsNoTracking()
            .Where(Criterio)
            .ToListAsync();
    }
    public async Task<List<Cotizaciones>> ListaCotizaciones()
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Cotizaciones
           .AsNoTracking()
           .ToListAsync();
    }
    public async Task<Cotizaciones?> ObtenerPorId(int id)
    {

        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Cotizaciones
            .Include(c => c.CotizacionesDetalle) 
            .FirstOrDefaultAsync(c => c.CotizacionId == id); 
    }
    public async Task<bool> EliminarDetalle(CotizacionesDetalle detalle)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var cotizacionDetalleDb = await contexto.CotizacionesDetalle.FindAsync(detalle.DetalleId);
        if (cotizacionDetalleDb != null)
        {
            contexto.CotizacionesDetalle.Remove(cotizacionDetalleDb);
            await contexto.SaveChangesAsync();
            return true;
        }
        return false;
    }
    public async Task<List<CotizacionesDetalle>> ListarDetalles(int cotizacionId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var detalles = await contexto.CotizacionesDetalle
            .Where(td => td.CotizacionId == cotizacionId)
            .ToListAsync();

        return detalles;

    }
    public async Task<bool> EliminarDetalle(int CotizacionId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var detalle = await contexto.CotizacionesDetalle.FindAsync(CotizacionId);
        if (detalle != null)
        {
            contexto.CotizacionesDetalle.Remove(detalle);
            return await contexto.SaveChangesAsync() > 0;
        }
        return false;
    }
}
