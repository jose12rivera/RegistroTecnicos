using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class PrioridadesServices
{
    private readonly Contexto _contexto;
    public PrioridadesServices(Contexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<bool>Existe(int prioridadId)
    {
        return await _contexto.Prioridades.AnyAsync(p=>p.PrioridadId == prioridadId);
    }
    private async Task<bool>Insertar(Prioridades prioridades)
    {
        _contexto.Prioridades.Add(prioridades);
        return await _contexto.SaveChangesAsync() > 0;
    }
    private async Task<bool> Modificar(Prioridades prioridades)
    {
        _contexto.Prioridades.Update(prioridades);
        return await _contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool>Guardar(Prioridades prioridades)
    {
        if(!await Existe(prioridades.PrioridadId))
        {
            return await Insertar(prioridades);
        }
        else
        {
            return await Modificar(prioridades);
        }
    }
    public async Task<bool> Eliminar(int id)
    {
        var eliminado = await _contexto.Prioridades
            .Where(p=>p.PrioridadId==id)
            .ExecuteDeleteAsync();
        return eliminado > 0;
    }
    public async Task<Prioridades?> Buscar(int id)
    {
        return await _contexto.Prioridades
            .AsNoTracking()
            .FirstOrDefaultAsync(p=>p.PrioridadId== id);
    }
    public async Task<List<Prioridades>>Listar(Expression<Func<Prioridades, bool>> Criterio)
    {
        return await _contexto.Prioridades
            .AsNoTracking()
            .Where(Criterio)
            .ToListAsync();
    }
}
