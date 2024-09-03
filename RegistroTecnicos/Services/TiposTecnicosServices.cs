using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class TiposTecnicosServices
{
    private readonly Contexto _contexto;
    //Metodo del Contexto
    public TiposTecnicosServices(Contexto contexto)
    {
        _contexto = contexto;
    }
    //Metodo del Existe
    public async Task <bool>Existe(int tipoId)
    {
        return await _contexto.TiposTecnicos.AnyAsync(t=>t.TipoId == tipoId);
    }

    //Metodo del Insertar
    private async Task<bool>Insertar(TiposTecnicos tiposTecnico)
    {
        _contexto.TiposTecnicos.Add(tiposTecnico);
        return await _contexto.SaveChangesAsync() > 0;
    }
    //Metodo del Modificar
    private async Task<bool> Modificar(TiposTecnicos tiposTecnico)
    {
        _contexto.TiposTecnicos.Update(tiposTecnico);
        var modificado = await _contexto.SaveChangesAsync() > 0;
        return modificado;
    }
    //Metodo del Guardar
    public async Task<bool>Guardar(TiposTecnicos tiposTecnico)
    {
        if(!await Existe(tiposTecnico.TipoId))
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
        var eliminado = await _contexto.TiposTecnicos
            .Where(t => t.TipoId == id)
            .ExecuteDeleteAsync();
        return eliminado > 0;
    }
    //Metodo del Buscar
    public async Task<TiposTecnicos?>Buscar(int id)
    {
        return await _contexto.TiposTecnicos
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.TipoId == id);
    }
    //Metodo del listar
    public async Task<List<TiposTecnicos>>Listar(Expression<Func<TiposTecnicos, bool>> Criterio)
    {
        return await _contexto.TiposTecnicos
            .AsNoTracking()
            .Where(Criterio)
            .ToListAsync();
    }

}
