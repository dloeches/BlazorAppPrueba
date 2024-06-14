using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppPruebaModelos.Entities
{
    public partial class Tarea
    {
        public void AvanzarEstado()
        {
            Estado = (EstadoTarea)(((int)Estado + 1) % Enum.GetValues(typeof(EstadoTarea)).Length);
        }

        public void Bloquear()
        {
            Bloqueada = true;
        }

        public void Desbloquear()
        {
            Bloqueada = false;
        }
    }
}
