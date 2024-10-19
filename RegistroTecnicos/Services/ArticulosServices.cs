using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class ArticulosServices
{
    private readonly Contexto _contexto;

    public ArticulosServices(Contexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<List<Articulos>> Listar(Expression<Func<Articulos, bool>> criterio)
    {
        return await _contexto.Articulos
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }
  
    public async Task<Articulos?> ObtenerArticuloPorId(int id)
    {
        return await _contexto.Articulos
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.ArticuloId == id);
    }


    public async Task<List<Articulos>> ListarArticulos()
    {
        return await _contexto.Articulos
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<bool> ActualizarExistencia(int articuloId, int cantidad)
    {
        var articulo = await _contexto.Articulos.FindAsync(articuloId);

        if (articulo != null)
        {
            // Permitir actualizar la existencia tanto para sumar como para restar
            int nuevaExistencia = articulo.Existencia + cantidad;
            if (nuevaExistencia >= 0)
            {
                articulo.Existencia = nuevaExistencia;
                _contexto.Articulos.Update(articulo);
                await _contexto.SaveChangesAsync();
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
        if (cantidad <= 0)
        {
            throw new ArgumentException("La cantidad a agregar debe ser mayor que cero.");
        }

        var articulo = await _contexto.Articulos.FindAsync(articuloId);

        if (articulo != null)
        {
            articulo.Existencia += cantidad;
            _contexto.Articulos.Update(articulo);
            await _contexto.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<Articulos?> Buscar(int articuloId)
    {
        return await _contexto.Articulos.AsNoTracking()
            .FirstOrDefaultAsync(a => a.ArticuloId == articuloId);
    }
}
