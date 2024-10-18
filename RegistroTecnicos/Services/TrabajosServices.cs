using Microsoft.EntityFrameworkCore;
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
            .Include(t => t.TrabajosDetalle) 
            .FirstOrDefaultAsync(t => t.TrabajoId == id);
    }
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
            _contexto.TrabajosDetalle.Add(detalle); 
        }
        await _contexto.SaveChangesAsync();
        return true; 
    }
    public async Task<bool> Validar(Trabajos trabajo)
    {
        var listaTrabajo = await Listar(t => t.Descripcion.ToLower() == trabajo.Descripcion.ToLower() && t.TrabajoId != trabajo.TrabajoId);
        return listaTrabajo.Any();
    }
   
    public async Task Actualizar(Trabajos trabajo, List<TrabajosDetalle> detalles)
    {
      
        var trabajoExistente = await Buscar(trabajo.TrabajoId);
        if (trabajoExistente != null)
        {
           
            trabajoExistente.Fecha = trabajo.Fecha;
            trabajoExistente.ClienteId = trabajo.ClienteId;
            trabajoExistente.TecnicoId = trabajo.TecnicoId;
            trabajoExistente.PrioridadId = trabajo.PrioridadId;
            trabajoExistente.Descripcion = trabajo.Descripcion;
            trabajoExistente.Monto = trabajo.Monto;

            var detallesExistentes = _contexto.TrabajosDetalle.Where(td => td.TrabajoId == trabajo.TrabajoId);
            _contexto.TrabajosDetalle.RemoveRange(detallesExistentes);

            foreach (var detalle in detalles)
            {
                detalle.TrabajoId = trabajo.TrabajoId; 
                _contexto.TrabajosDetalle.Add(detalle);
            }

            await _contexto.SaveChangesAsync();
        }
    }
}
