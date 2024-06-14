using BlazorAppPruebaBD.Context;
using BlazorAppPruebaModelos.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppPruebaServicios.TareaServicio
{
    public class TareaServicio: ITareaServicio
    {
        private readonly BlazorAppPruebaDbContext _context;

        public TareaServicio(BlazorAppPruebaDbContext context)
        {
            _context = context;
        }

        //public async Task<List<Tarea>> GetTareasAsync()
        //{
        //    return await _context.Tareas.ToListAsync();
        //}

        public async Task<Tarea> GetTareaByIdAsync(int id)
        {
            return await _context.Tareas.FindAsync(id);
        }

        public async Task CrearTareaAsync(Tarea tarea)
        {
            _context.Tareas.Add(tarea);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarTareaAsync(Tarea tarea)
        {
            _context.Tareas.Update(tarea);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarTareaAsync(int id)
        {
            var tarea = await _context.Tareas.FindAsync(id);
            if (tarea != null)
            {
                _context.Tareas.Remove(tarea);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Tarea>> GetTareasPaginadasAsync(int pagina, int tareasPorPagina)
        {
            return await _context.Tareas
                .OrderBy(t => t.Id)
                .Skip((pagina - 1) * tareasPorPagina)
                .Take(tareasPorPagina)
                .ToListAsync();
        }
        public async Task<int> ContarTareasAsync()
        {
            return await _context.Tareas.CountAsync();
        }
    }
}
