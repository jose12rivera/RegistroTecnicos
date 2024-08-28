using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services
{
    public class TecnicosServices
    {
        private readonly Contexto _contexto;

        //Metodo del Contexto
        public TecnicosServices(Contexto contexto)
        {
            _contexto = contexto;
        }
        //Metodo del Existe
        public async Task<bool> Existe(int tecnicoId ,string nombres)
        {
            return await _contexto.tecnicos
                .AnyAsync(T => T.TecnicoId != tecnicoId && T.Nombres.Equals(nombres));
        }
        //Metodo del Insertar
        private async Task<bool> Insertar(Tecnicos tecnico)
        {
            _contexto.tecnicos.Add(tecnico);
            return await _contexto
                .SaveChangesAsync() > 0;
        }
        //Metodo del Modificar
        private async Task<bool> Modificar(Tecnicos tecnico)
        {
            _contexto.tecnicos.Update(tecnico);
            var modificado = await _contexto
                .SaveChangesAsync() > 0;
            _contexto.Entry(tecnico)
                .State = EntityState.Detached;
            return modificado;
        }
        //Metodo del Guardar
        public async Task<bool> Guardar(Tecnicos tecnico )
        {
            if (!await Existe(tecnico.TecnicoId ,tecnico.Nombres))
            {
                return await Insertar(tecnico);
            }
            else
            {
                return await Modificar(tecnico);
            }
        }
        //Metodo del Eliminar
        public async Task<bool> Eliminar(int id)
        {
            var eliminado = await _contexto.tecnicos
                .Where(T => T.TecnicoId == id)
                .ExecuteDeleteAsync();
            return eliminado > 0;
        }
        //Metodo del Buscar
        public async Task<Tecnicos?> Buscar(int id)
        {
            return await _contexto.tecnicos
                .AsNoTracking()
                .FirstOrDefaultAsync(T => T.TecnicoId == id);
        }
        //Metodo del listar
        public async Task<List<Tecnicos>>Listar(Expression<Func<Tecnicos, bool>> Criterio)
        {
            return await _contexto.tecnicos
                .Where(Criterio)
                .ToListAsync();
        }
    }
}
