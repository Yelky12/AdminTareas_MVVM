using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminTareas.Models.Models
{
    public enum TareaEstado
    {
        Pendiente = 1,
        EnProceso = 2,
        Terminada = 3
    }

    public enum TareaPrioridad
    {
        Baja = 1,
        Media = 2,
        Alta = 3
    }
}
