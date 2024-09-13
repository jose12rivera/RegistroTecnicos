﻿using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;
public class ClientesServices
{
    private readonly Contexto _contexto;
    //Metodo Contexto
    public ClientesServices(Contexto contexto)
    {
        _contexto = contexto;
    }
    //Metodo Existe
    public async Task <bool>Existe(int clienteId)
    {
        return await _contexto.Clientes.AnyAsync(c=>c.ClienteId == clienteId);
    }
    //Metodo Insertar
    private async Task<bool> Insertar(Clientes cliente)
    {
        _contexto.Clientes.Add(cliente);
        return await _contexto.SaveChangesAsync() > 0;
    }
    //Metodo Modificar
    private async Task<bool> Modificar(Clientes cliente)
    {
        _contexto.Clientes.Update(cliente);
        return await _contexto.SaveChangesAsync() > 0;
        
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
        var Eliminado = await _contexto.Clientes
            .Where(c => c.ClienteId == id)
            .ExecuteDeleteAsync();
        return Eliminado > 0;
    }
    //Metodo Buscar
    public async Task<Clientes?>Buscar(int id)
    {
        return await _contexto.Clientes
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.ClienteId == id);
    }
    //Metodo Listar
    public async Task<List<Clientes>>Listar(Expression<Func<Clientes, bool>> Criterio)
    {
        return await _contexto.Clientes
            .AsNoTracking()
            .Where(Criterio)
            .ToListAsync();
    }
}
