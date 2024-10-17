using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class ArticulosServices(Contexto _contexto)
{
    public async Task<List<Articulos>> Listar(Expression<Func<Articulos, bool>> criterio)
    {
        return await _contexto.Articulos
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<Articulos>> ListarArticulos()
    {
        return await _contexto.Articulos
            .AsNoTracking()
            .ToListAsync();
    }
  

}
