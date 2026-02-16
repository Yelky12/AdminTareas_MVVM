using AdminTareas.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminTareas.Services.Interfaces
{
    public interface ITaskService
    {
        List<Tarea> GetTasks();
        void Save(Tarea task);
        void Delete(int id);


        void Crear(Tarea tarea);
        void Actualizar(Tarea tarea);
        void Eliminar(int id);
        void CambiarEstado(int id, TareaEstado nuevoEstado);


        IEnumerable<Tarea> GetFilteredTasks(TareaEstado? estado,TareaPrioridad? prioridad,string? usuario);


    }
}
