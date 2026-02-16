using AdminTareas.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminTareas.Data.Abstractions.Interfaces
{
    public interface ITareaRepository
    {
        IEnumerable<Tarea> GetAll();

        Tarea? GetById(int id);

        void Add(Tarea tarea);

        void Update(Tarea tarea);

        void Delete(int id);

        IEnumerable<Tarea> GetFiltered(TareaEstado? estado,TareaPrioridad? prioridad,string? usuario);
    }
}
