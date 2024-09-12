using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services
{
    public class TrabajosServices
    {
        private readonly Contexto _contexto;
        public TrabajosServices(Contexto contexto)
        {
            _contexto = contexto;
        }
        public async Task<bool>Existe(int trabajoId)
        {
            return await _contexto.Trabajos.AnyAsync(t=>t.TrabajoId == trabajoId);
        }
        private async Task<bool> Insertar(Trabajos trabajo)
        {
            _contexto.Trabajos.Add(trabajo);
            return await _contexto.SaveChangesAsync()>0;
        }
        private async Task<bool>Modificar(Trabajos trabajo)
        {
            _contexto.Trabajos.Update(trabajo);
            return await _contexto.SaveChangesAsync() > 0;
        }
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
        public async Task<bool>Eliminar(int id)
        {
            var eliminado = await _contexto.Trabajos
                .Where(t => t.TrabajoId == id)
                .ExecuteDeleteAsync();
            return eliminado > 0;
        }
        public async Task<Trabajos?>Buscar(int id)
        {
            return await _contexto.Trabajos
                .AsNoTracking()
                .FirstOrDefaultAsync(t=>t.TrabajoId == id);
        }
        public async Task<List<Trabajos>>Listar(Expression<Func<Trabajos, bool>> Criterio)
        {
            return await _contexto.Trabajos
                .Include(t => t.Tecnicos)
                .Include(t => t.Clientes)
                .AsNoTracking()
                .Where(Criterio)
                .ToListAsync();
        }

    }
}
