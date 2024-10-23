using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;
public class ClientesServices(IDbContextFactory<Contexto> DbFactory)
{
    
    //Metodo Existe
    public async Task <bool>Existe(int clienteId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Clientes.AnyAsync(c=>c.ClienteId == clienteId);
    }
    //Metodo Insertar
    private async Task<bool> Insertar(Clientes cliente)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Clientes.Add(cliente);
        return await contexto.SaveChangesAsync() > 0;
    }
    //Metodo Modificar
    private async Task<bool> Modificar(Clientes cliente)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Clientes.Update(cliente);
        return await contexto.SaveChangesAsync() > 0;
        
    }
    //Metodo Guardar
    public async Task<bool>Guardar(Clientes cliente)
    {
        if(!await Existe(cliente.ClienteId))
        {
            return await Insertar(cliente);
        }
        else
        {
            return await Modificar(cliente);
        }
    }
    //Metodo Eliminar
    public async Task<bool>Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var Eliminado = await contexto.Clientes
            .Where(c => c.ClienteId == id)
            .ExecuteDeleteAsync();
        return Eliminado > 0;
    }
    //Metodo Buscar
    public async Task<Clientes?>Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Clientes
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.ClienteId == id);
    }
    //Metodo Listar
    public async Task<List<Clientes>>Listar(Expression<Func<Clientes, bool>> Criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Clientes
            .AsNoTracking()
            .Where(Criterio)
            .ToListAsync();
    }

    public async Task<List<Clientes>> ListarClientes()
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Clientes
            .AsNoTracking()
            .ToListAsync();
    }
}


