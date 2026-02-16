using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminTareas.Models.Models
{
    public class Tarea
    {
        public Tarea()
        {
            FechaCompromiso = DateTime.Today;
        }

        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public string Usuario { get; set; } = string.Empty;
        public int EstadoId { get; set; }
        public int PrioridadId { get; set; }
        public DateTime FechaCompromiso { get; set; }
        public string Notas { get; set; } = string.Empty;

        public string EstadoNombre { get; set; }
        public string PrioridadNombre { get; set; }

    }
}
