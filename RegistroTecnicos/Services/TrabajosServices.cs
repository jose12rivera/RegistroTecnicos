﻿using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;


namespace RegistroTecnicos.Services;
public class TrabajosServices
{
    private readonly Contexto _contexto;
    //Metodo Contexto
    public TrabajosServices(Contexto contexto)
    {
        _contexto = contexto;
    }
    //Metodo  Existe
    public async Task<bool>Existe(int trabajoId)
    {
        return await _contexto.Trabajos.AnyAsync(t=>t.TrabajoId == trabajoId);
    }
    //Metodo Insertar
    private async Task<bool> Insertar(Trabajos trabajo)
    {
        _contexto.Trabajos.Add(trabajo);
        return await _contexto.SaveChangesAsync()>0;
    }
    //Metodo Modificar
    private async Task<bool>Modificar(Trabajos trabajo)
    {
        _contexto.Trabajos.Update(trabajo);
        return await _contexto.SaveChangesAsync() > 0;
    }
    //Metodo Guardar
    public async Task<bool>Guardar(Trabajos trabajo)
    {
        if(!await Existe(trabajo.TrabajoId))
        {
            return await Insertar(trabajo);
        }
        else
        {
            return await Modificar(trabajo);
        }
    }
    //Metodo Finalizar
    public async Task<bool> Finalizar(int trabajoId)
    {
        var cantidad = await _contexto.Trabajos
            .Where(t => t.TrabajoId == trabajoId)
            .ExecuteUpdateAsync(t => t.SetProperty(x => x.Fecha, DateTime.Now));
        return cantidad > 0;
    }
  
    //Metodo  Eliminar
    public async Task<bool>Eliminar(int id)
    {
        var eliminado = await _contexto.Trabajos
            .Where(t => t.TrabajoId == id)
            .ExecuteDeleteAsync();
        return eliminado > 0;
    }
    // Método para eliminar un detalle específico
    public async Task<bool> EliminarDetalle(int trabajoDetalleId)
    {
        var detalle = await _contexto.TrabajosDetalle.FindAsync(trabajoDetalleId);
        if (detalle != null)
        {
            _contexto.TrabajosDetalle.Remove(detalle);
            return await _contexto.SaveChangesAsync() > 0;
        }
        return false;
    }


    public async Task<Trabajos?> Buscar(int id)
    {
        return await _contexto.Trabajos
            .Include(t => t.TrabajosDetalle) // Carga los detalles
            .FirstOrDefaultAsync(t => t.TrabajoId == id);
    }

    //Metodo  Listar
    public async Task<List<Trabajos>>Listar(Expression<Func<Trabajos, bool>> Criterio)
    {
        return await _contexto.Trabajos
            .Include(t => t.Tecnicos)
            .Include(t => t.Clientes)
            .Include(t => t.Prioridades)
            .Include(t=>t.TrabajosDetalle)
            .AsNoTracking()
            .Where(Criterio)
            .ToListAsync();
    }

    public async Task<bool> GuardarDetalles(List<TrabajosDetalle> detalles)
    {
        foreach (var detalle in detalles)
        {
            _contexto.TrabajosDetalle.Add(detalle); // Asegúrate de tener el DbSet correspondiente
        }
        await _contexto.SaveChangesAsync(); // Guardar todos los cambios a la base de datos
        return true; // Retornar verdadero si se guardó correctamente
    }

   


}
