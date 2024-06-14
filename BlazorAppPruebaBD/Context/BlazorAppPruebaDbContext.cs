using BlazorAppPruebaModelos.Entities;
using Microsoft.EntityFrameworkCore;
namespace BlazorAppPruebaBD.Context
{
    public class BlazorAppPruebaDbContext : DbContext
    {
        public BlazorAppPruebaDbContext(DbContextOptions<BlazorAppPruebaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Tarea> Tareas { get; set; }
    }
}
