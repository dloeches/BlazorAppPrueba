using System.ComponentModel.DataAnnotations;

namespace BlazorAppPruebaModelos.Entities
{
    public enum EstadoTarea
    {
        Pendiente,
        EnProgreso,
        Completada,
        Cancelada
    }

    public partial class Tarea
    {
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string? Nombre { get; set; }

        public EstadoTarea Estado { get; set; }

        public bool Bloqueada { get; set; }

        public Tarea() {
           Estado = EstadoTarea.Pendiente; }

    }
}