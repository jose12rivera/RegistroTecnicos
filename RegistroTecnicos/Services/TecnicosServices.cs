using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;
public class TecnicosServices(IDbContextFactory<Contexto> DbFactory)
{
   
    //Metodo del Existe
    public async Task<bool> Existe(int tecnicoId )
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Tecnicos
            .AnyAsync(T => T.TecnicoId == tecnicoId );
    }
    //Metodo del Insertar
    private async Task<bool> Insertar(Tecnicos tecnico)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Tecnicos.Add(tecnico);
        return await contexto
            .SaveChangesAsync() > 0;
    }
    //Metodo del Modificar
    private async Task<bool> Modificar(Tecnicos tecnico)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Tecnicos.Update(tecnico);
        var modificado = await contexto
            .SaveChangesAsync() > 0;
        return modificado;
    }
    //Metodo del Guardar
    public async Task<bool> Guardar(Tecnicos tecnico )  
    {
      
        if (!await Existe(tecnico.TecnicoId ))
        
            return await Insertar(tecnico);
        else
            return await Modificar(tecnico);
        
    }
    //Metodo del Eliminar
    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var eliminado = await contexto.Tecnicos
            .Where(t => t.TecnicoId == id)
            .ExecuteDeleteAsync();
        return eliminado > 0;
    }
    //Metodo del Buscar
    public async Task<Tecnicos?> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Tecnicos
            .AsNoTracking()
            .FirstOrDefaultAsync(T => T.TecnicoId == id);
    }
    //Metodo del listar
    public async Task<List<Tecnicos>>Listar(Expression<Func<Tecnicos, bool>> Criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Tecnicos
            .Include(t=>t.TiposTecnicos)
            .AsNoTracking()
            .Where(Criterio)
            .ToListAsync();
    }
   
}
