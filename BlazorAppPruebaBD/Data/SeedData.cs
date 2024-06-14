using BlazorAppPruebaBD.Context;
using BlazorAppPruebaModelos.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorAppPruebaBD.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BlazorAppPruebaDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<BlazorAppPruebaDbContext>>()))
            {
                if (context.Tareas.Any())
                {
                    return;   
                }

                var random = new Random();
                var estados = Enum.GetValues(typeof(EstadoTarea)).Cast<EstadoTarea>().ToList();

                for (int i = 1; i <= 100000; i++)
                {
                    var estadoAleatorio = estados[random.Next(estados.Count)];

                    context.Tareas.Add(new Tarea
                    {
                        Nombre = $"Tarea {i}",
                        Estado = estadoAleatorio
                    });

                    if (i % 1000 == 0)
                    {
                        context.SaveChanges();
                    }
                }
                context.SaveChanges();
            }
        }

    }
}
