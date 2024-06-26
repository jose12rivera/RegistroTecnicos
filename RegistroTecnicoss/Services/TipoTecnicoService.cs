﻿using Microsoft.EntityFrameworkCore;
using RegistroTecnicoss.DAL;
using RegistroTecnicoss.Modelss;
using System.Linq.Expressions;

namespace RegistroTecnicoss.Services;

public class TipoTecnicoService
{
    private readonly Contexto _contexto;

    public TipoTecnicoService(Contexto contexto)
    {
        _contexto = contexto;
    }

    // Método Existente
    public async Task<bool> Existe(int TipoTecnicoId)
    {
        return await _contexto.TipoTecnico.AnyAsync(T => T.TipoId == TipoTecnicoId);
    }

    // Método Insertar
    private async Task<bool> Insertar(TiposTecnicos tipoTecnico)
    {
        _contexto.TipoTecnico.Add(tipoTecnico);
        return await _contexto.SaveChangesAsync() > 0;
    }

    // Método Modificar
    private async Task<bool> Modificar(TiposTecnicos tipoTecnico)
    {
        _contexto.TipoTecnico.Update(tipoTecnico);
        return await _contexto.SaveChangesAsync() > 0;
    }

    // Método guardar
    public async Task<bool> Guardar(TiposTecnicos tipoTecnico)
    {
        if (!await Existe(tipoTecnico.TipoId))
            return await Insertar(tipoTecnico);
        else
            return await Modificar(tipoTecnico);
    }

    // Método eliminar
    public async Task<bool> Eliminar(int id)
    {
        var tipoTecnico = await _contexto.TipoTecnico.FindAsync(id);
        if (tipoTecnico == null)
            return false;

        _contexto.TipoTecnico.Remove(tipoTecnico);
        return await _contexto.SaveChangesAsync() > 0;
    }

    // Método buscar
    public async Task<TiposTecnicos?> Buscar(int id)
    {
        return await _contexto.TipoTecnico
            .AsNoTracking()
            .FirstOrDefaultAsync(T => T.TipoId == id);
    }

    // Método listar
    public async Task<List<TiposTecnicos>> Listar(Expression<Func<TiposTecnicos, bool>> criterio)
    {
        return await _contexto.TipoTecnico
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<List<Tecnicos>> ObtenerTecnicosPorTipo(int tipoTecnicoId)
    {
        return await _contexto.Tecnicos
            .Where(t => t.TipoId == tipoTecnicoId)
            .Include(t => t.IncentivoId) 
            .ToListAsync();
    }

    public async Task<List<int>> ObtenerTecnicosIdsPorTipo(int tipoTecnicoId)
    {
        var tecnicosIds = await _contexto.Tecnicos
            .Where(t => t.TipoId == tipoTecnicoId)
            .Select(t => t.TecnicoId)
            .ToListAsync();

        return tecnicosIds;
    }

    public async Task ActualizarTotalIncentivos(int tipoTecnicoId)
    {
        var tecnicosIds = await ObtenerTecnicosIdsPorTipo(tipoTecnicoId);

        var incentivos = await _contexto.IncentivosTecnicos
            .Where(i => tecnicosIds.Contains(i.TecnicoId))
            .ToListAsync();

        var totalIncentivos = incentivos.Sum(i => i.Monto ?? 0);

        var tipoTecnico = await _contexto.TipoTecnico.FindAsync(tipoTecnicoId);
        if (tipoTecnico != null)
        {
            tipoTecnico.Incentivo = totalIncentivos;
            await _contexto.SaveChangesAsync();
        }
    }
}

