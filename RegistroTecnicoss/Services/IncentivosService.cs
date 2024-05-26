using RegistroTecnicoss.DAL;
using RegistroTecnicoss.Modelss;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RegistroTecnicoss.Services
{
    public class IncentivosService
    {
        private readonly Contexto _contexto;

        public IncentivosService(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Existe(int IncentivoId)
        {
            return await _contexto.IncentivosTecnicos.AnyAsync(t => t.IncentivoId == IncentivoId);
        }

        public async Task<bool> Existe(string? Descripcion)
        {
            return await _contexto.IncentivosTecnicos.AnyAsync(t => t.Descripcion == Descripcion);
        }
        private async Task<bool> Insertar(IncentivosTecnicos IncentivosTecnico)
        {

            _contexto.IncentivosTecnicos.Add(IncentivosTecnico);
                return await _contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(IncentivosTecnicos IncentivosTecnico)
        {
                _contexto.IncentivosTecnicos.Update(IncentivosTecnico);
                return await _contexto.SaveChangesAsync() > 0;
            
        }

        public async Task<bool> Guardar(IncentivosTecnicos IncentivosTecnico)
        {
            
                if (!await Existe(IncentivosTecnico.IncentivoId))
                    return await Insertar(IncentivosTecnico);
                else
                    return await Modificar(IncentivosTecnico);
           
        }

        public async Task<bool> Eliminar(int id)
        {
           
                var IncentivosTecnico = await _contexto.IncentivosTecnicos.FindAsync(id);
                if (IncentivosTecnico == null)
                    return false;

                _contexto.IncentivosTecnicos.Remove(IncentivosTecnico);
                return await _contexto.SaveChangesAsync() > 0;
           
        }

        public async Task<IncentivosTecnicos?> Buscar(int id)
        {
            
                return await _contexto.IncentivosTecnicos.AsNoTracking().FirstOrDefaultAsync(t => t.IncentivoId == id);
           
        }

        public async Task<List<IncentivosTecnicos>> Listar(Expression<Func<IncentivosTecnicos, bool>> criterio)
        {
            
                return await _contexto.IncentivosTecnicos.AsNoTracking().Where(criterio).ToListAsync();
        }
    }
}
