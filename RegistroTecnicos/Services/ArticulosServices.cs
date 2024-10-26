using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class ArticulosServices(IDbContextFactory<Contexto> DbFactory)
{
 
    public async Task<List<Articulos>> Listar(Expression<Func<Articulos, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Articulos
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }
  
    public async Task<Articulos?> ObtenerArticuloPorId(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Articulos
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.ArticuloId == id);
    }


    public async Task<List<Articulos>> ListarArticulos()
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Articulos
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<bool> ActualizarExistencia(int articuloId, int cantidad)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var articulo = await contexto.Articulos.FindAsync(articuloId);

        if (articulo != null)
        {
            // Permitir actualizar la existencia tanto para sumar como para restar
            int nuevaExistencia = articulo.Existencia + cantidad;
            if (nuevaExistencia >= 0)
            {
                articulo.Existencia = nuevaExistencia;
                contexto.Articulos.Update(articulo);
                await contexto.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new InvalidOperationException("No hay suficiente existencia para reducir.");
            }
        }
        return false;
    }


    public async Task<bool> AgregarCantidad(int articuloId, int cantidad)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        if (cantidad <= 0)
        {
            throw new ArgumentException("La cantidad a agregar debe ser mayor que cero.");
        }

        var articulo = await contexto.Articulos.FindAsync(articuloId);

        if (articulo != null)
        {
            articulo.Existencia += cantidad;
            contexto.Articulos.Update(articulo);
            await contexto.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<Articulos?> Buscar(int articuloId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Articulos.AsNoTracking()
            .FirstOrDefaultAsync(a => a.ArticuloId == articuloId);
    }
}
