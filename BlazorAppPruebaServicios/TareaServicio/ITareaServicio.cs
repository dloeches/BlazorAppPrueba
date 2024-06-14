using BlazorAppPruebaModelos.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppPruebaServicios.TareaServicio
{
    public interface ITareaServicio
    {
        //Task<List<Tarea>> GetTareasAsync();

        Task<Tarea> GetTareaByIdAsync(int id);

        Task CrearTareaAsync(Tarea tarea);

        Task ActualizarTareaAsync(Tarea tarea);

        Task EliminarTareaAsync(int id);

        Task<List<Tarea>> GetTareasPaginadasAsync(int pagina, int tareasPorPagina);
        Task<int> ContarTareasAsync();
    }
}