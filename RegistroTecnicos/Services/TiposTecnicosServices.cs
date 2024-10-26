using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class TiposTecnicosServices(IDbContextFactory<Contexto> DbFactory)
{
   
    //Metodo del Existe
    public async Task <bool>Existe(int tipoTecnicoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TiposTecnicos.AnyAsync(t=>t.TipoTecnicoId == tipoTecnicoId);
    }
    //Metodo del Insertar
    private async Task<bool>Insertar(TiposTecnicos tiposTecnico)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.TiposTecnicos.Add(tiposTecnico);
        return await contexto.SaveChangesAsync() > 0;
    }
    //Metodo del Modificar
    private async Task<bool> Modificar(TiposTecnicos tiposTecnico)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.TiposTecnicos.Update(tiposTecnico);
        var modificado = await contexto.SaveChangesAsync() > 0;
        return modificado;
    }
    //Metodo del Guardar
    public async Task<bool>Guardar(TiposTecnicos tiposTecnico)
    {
        if(!await Existe(tiposTecnico.TipoTecnicoId))
        {
            return await Insertar(tiposTecnico);
        }
        else
        {
            return await Modificar(tiposTecnico);
        }
    }
    //Metodo del Eliminar
    public async Task<bool>Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var eliminado = await contexto.TiposTecnicos
            .Where(t => t.TipoTecnicoId == id)
            .ExecuteDeleteAsync();
        return eliminado > 0;
    }
    //Metodo del Buscar
    public async Task<TiposTecnicos?>Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TiposTecnicos
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.TipoTecnicoId == id);
    }
    //Metodo del listar
    public async Task<List<TiposTecnicos>>Listar(Expression<Func<TiposTecnicos, bool>> Criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TiposTecnicos
            .AsNoTracking()
            .Where(Criterio)
            .ToListAsync();
    }

}
