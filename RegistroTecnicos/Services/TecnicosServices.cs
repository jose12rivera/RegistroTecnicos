﻿using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;
public class TecnicosServices
{
    private readonly Contexto _contexto;

    //Metodo del Contexto
    public TecnicosServices(Contexto contexto)
    {
        _contexto = contexto;
    }
    //Metodo del Existe
    public async Task<bool> Existe(int tecnicoId )
    {
        return await _contexto.Tecnicos
            .AnyAsync(T => T.TecnicoId == tecnicoId );
    }
    //Metodo del Insertar
    private async Task<bool> Insertar(Tecnicos tecnico)
    {
        _contexto.Tecnicos.Add(tecnico);
        return await _contexto
            .SaveChangesAsync() > 0;
    }
    //Metodo del Modificar
    private async Task<bool> Modificar(Tecnicos tecnico)
    {
        _contexto.Tecnicos.Update(tecnico);
        var modificado = await _contexto
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
        var eliminado = await _contexto.Tecnicos
            .Where(t => t.TecnicoId == id)
            .ExecuteDeleteAsync();
        return eliminado > 0;
    }
    //Metodo del Buscar
    public async Task<Tecnicos?> Buscar(int id)
    {
        return await _contexto.Tecnicos
            .AsNoTracking()
            .FirstOrDefaultAsync(T => T.TecnicoId == id);
    }
    //Metodo del listar
    public async Task<List<Tecnicos>>Listar(Expression<Func<Tecnicos, bool>> Criterio)
    {
        return await _contexto.Tecnicos
            .Include(t=>t.TiposTecnicos)
            .AsNoTracking()
            .Where(Criterio)
            .ToListAsync();
    }
   
}
