using Microsoft.EntityFrameworkCore;
using RegistroTecnicoss.DAL;
using RegistroTecnicoss.Modelss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RegistrodeTecnicos.Services
{
    public class TecnicoService
    {
        private readonly Contexto _contexto;

        public TecnicoService(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Existe(int tecnicoId)
        {
            return await _contexto.Tecnicos.AnyAsync(t => t.TecnicoId == tecnicoId);
        }

        private async Task<bool> Insertar(Tecnicos tecnico)
        {
            try
            {
                _contexto.Tecnicos.Add(tecnico);
                return await _contexto.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Insertar: {ex.Message}");
                return false;
            }
        }

        private async Task<bool> Modificar(Tecnicos tecnico)
        {
            try
            {
                _contexto.Tecnicos.Update(tecnico);
                return await _contexto.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Modificar: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> Guardar(Tecnicos tecnico)
        {
            if (string.IsNullOrWhiteSpace(tecnico.Nombres))
            {
                Console.WriteLine("Por Favor Ingresar El Nombre");
                return false;
            }

            if (tecnico.Sueldohora <= 0)
            {
                Console.WriteLine("Por Favor Ingresar El Sueldo Por Hora");
                return false;
            }

            try
            {
                if (!await Existe(tecnico.TecnicoId))
                    return await Insertar(tecnico);
                else
                    return await Modificar(tecnico);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Guardar: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var tecnico = await _contexto.Tecnicos.FindAsync(id);
                if (tecnico == null)
                    return false;

                _contexto.Tecnicos.Remove(tecnico);
                return await _contexto.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Eliminar: {ex.Message}");
                return false;
            }
        }

        public async Task<Tecnicos?> Buscar(int id)
        {
            try
            {
                return await _contexto.Tecnicos.AsNoTracking().FirstOrDefaultAsync(t => t.TecnicoId == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Buscar: {ex.Message}");
                return null;
            }
        }

        public async Task<List<Tecnicos>> Listar(Expression<Func<Tecnicos, bool>> criterio)
        {
            try
            {
                return await _contexto.Tecnicos.Include(T => T.TiposTecnicos).AsNoTracking().Where(criterio).ToListAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Listar: {ex.Message}");
                return new List<Tecnicos>();
            }
        }
    }
}
