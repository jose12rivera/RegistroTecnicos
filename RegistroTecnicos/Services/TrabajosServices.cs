using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;


namespace RegistroTecnicos.Services;
public class TrabajosServices(IDbContextFactory<Contexto> DbFactory)
{
    
    //Metodo  Existe
    public async Task<bool>Existe(int trabajoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Trabajos.AnyAsync(t=>t.TrabajoId == trabajoId);
    }
    //Metodo Insertar
    private async Task<bool> Insertar(Trabajos trabajo)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Trabajos.Add(trabajo);
        return await contexto.SaveChangesAsync()>0;
    }
    //Metodo Modificar
    private async Task<bool>Modificar(Trabajos trabajo)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Trabajos.Update(trabajo);
        return await contexto.SaveChangesAsync() > 0;
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
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var cantidad = await contexto.Trabajos
            .Where(t => t.TrabajoId == trabajoId)
            .ExecuteUpdateAsync(t => t.SetProperty(x => x.Fecha, DateTime.Now));
        return cantidad > 0;
    }
  
    //Metodo  Eliminar
    public async Task<bool>Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var eliminado = await contexto.Trabajos
            .Where(t => t.TrabajoId == id)
            .ExecuteDeleteAsync();
        return eliminado > 0;
    }
    public async Task<bool> EliminarDetalle(int trabajoDetalleId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var detalle = await contexto.TrabajosDetalle.FindAsync(trabajoDetalleId);
        if (detalle != null)
        {
            contexto.TrabajosDetalle.Remove(detalle);
            return await contexto.SaveChangesAsync() > 0;
        }
        return false;
    }
    public async Task<Trabajos?> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Trabajos
            .Include(t => t.TrabajosDetalle) 
            .FirstOrDefaultAsync(t => t.TrabajoId == id);
    }
    public async Task<List<Trabajos>>Listar(Expression<Func<Trabajos, bool>> Criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Trabajos
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
        await using var contexto = await DbFactory.CreateDbContextAsync();
        foreach (var detalle in detalles)
        {
            contexto.TrabajosDetalle.Add(detalle); 
        }
        await contexto.SaveChangesAsync();
        return true; 
    }
    public async Task<bool> Validar(Trabajos trabajo)
    {
        var listaTrabajo = await Listar(t => t.Descripcion.ToLower() == trabajo.Descripcion.ToLower() && t.TrabajoId != trabajo.TrabajoId);
        return listaTrabajo.Any();
    }
   
    public async Task Actualizar(Trabajos trabajo, List<TrabajosDetalle> detalles)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var trabajoExistente = await Buscar(trabajo.TrabajoId);
        if (trabajoExistente != null)
        {
           
            trabajoExistente.Fecha = trabajo.Fecha;
            trabajoExistente.ClienteId = trabajo.ClienteId;
            trabajoExistente.TecnicoId = trabajo.TecnicoId;
            trabajoExistente.PrioridadId = trabajo.PrioridadId;
            trabajoExistente.Descripcion = trabajo.Descripcion;
            trabajoExistente.Monto = trabajo.Monto;

            var detallesExistentes = contexto.TrabajosDetalle.Where(td => td.TrabajoId == trabajo.TrabajoId);
            contexto.TrabajosDetalle.RemoveRange(detallesExistentes);

            foreach (var detalle in detalles)
            {
                detalle.TrabajoId = trabajo.TrabajoId; 
                contexto.TrabajosDetalle.Add(detalle);
            }

            await contexto.SaveChangesAsync();
        }
    }
    public async Task<List<TrabajosDetalle>> ListarDetalles(int trabajoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var detalles = await contexto.TrabajosDetalle
            .Where(td => td.TrabajoId == trabajoId)
            .ToListAsync();

        return detalles;

    }
}
