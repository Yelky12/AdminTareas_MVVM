using AdminTareas.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminTareas.ViewModels.Interfaces
{
    public interface ITaskViewModel
    {

        string Descripcion { get; set; }
        string Usuario { get; set; }
        TareaEstado Estado { get; set; }
        TareaPrioridad Prioridad { get; set; }
        DateTime FechaCompromiso { get; set; }
        string Notas { get; set; }

        BindingList<Tarea> Tasks { get; }


        void Save();
        void Delete(int id);
        void LoadTask(Tarea tarea);
        void AvanzarEstado(int id);
        void RecargarTodo();
        TareaEstado? FiltroEstado { get; set; }
        TareaPrioridad? FiltroPrioridad { get; set; }
        string? FiltroUsuario { get; set; }
        void AplicarFiltros();
        void LimpiarFiltros();
        bool EsValido();
    }
}
