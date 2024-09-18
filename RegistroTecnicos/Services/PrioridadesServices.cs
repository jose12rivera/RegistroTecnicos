using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;
public class PrioridadesServices
{
    private readonly Contexto _contexto;
    //Metodo del Contexto
    public PrioridadesServices(Contexto contexto)
    {
        _contexto = contexto;
    }
    //Metodo del existe
    public async Task<bool>Existe(int prioridadId)
    {
        return await _contexto.Prioridades.AnyAsync(p=>p.PrioridadId == prioridadId);
    }
    //Metodo del Insertar
    private async Task<bool>Insertar(Prioridades prioridades)
    {
        _contexto.Prioridades.Add(prioridades);
        return await _contexto.SaveChangesAsync() > 0;
    }
    //Metodo  del Modificar
    private async Task<bool> Modificar(Prioridades prioridad)
    {
        _contexto.Prioridades.Update(prioridad);
        return await _contexto.SaveChangesAsync() > 0;
    }
    //Metodo el Guardar
    public async Task<bool>Guardar(Prioridades prioridad)
    {
        if(!await Existe(prioridad.PrioridadId))
        {
            return await Insertar(prioridad);
        }
        else
        {
            return await Modificar(prioridad);
        }
    }
    //Metodo Eliminar
    public async Task<bool> Eliminar(int id)
    {
        var eliminado = await _contexto.Prioridades
            .Where(p=>p.PrioridadId==id)
            .ExecuteDeleteAsync();
        return eliminado > 0;
    }
    //Metodo del Buscar
    public async Task<Prioridades?> Buscar(int id)
    {
        return await _contexto.Prioridades
            .AsNoTracking()
            .FirstOrDefaultAsync(p=>p.PrioridadId== id);
    }
    //Metodo del listar
    public async Task<List<Prioridades>>Listar(Expression<Func<Prioridades, bool>> Criterio)
    {
        return await _contexto.Prioridades
            .AsNoTracking()
            .Where(Criterio)
            .ToListAsync();
    }
}
