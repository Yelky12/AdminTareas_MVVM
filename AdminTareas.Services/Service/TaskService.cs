using AdminTareas.Data.Abstractions.Interfaces;
using AdminTareas.Models.Models;
using AdminTareas.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminTareas.Services.Service
{
    public class TaskService : ITaskService
    {
        private readonly ITareaRepository _repository;

        public TaskService(ITareaRepository repository)
        {
            _repository = repository;
        }

        public List<Tarea> GetTasks()
            => _repository.GetAll().ToList();

        public void Save(Tarea task)
        {
            if (task.Id == 0)
                _repository.Add(task);
            else
                _repository.Update(task);
        }

        public void Delete(int id)
            => _repository.Delete(id);

        public void Crear(Tarea tarea)
        {
            tarea.EstadoId = (int)TareaEstado.Pendiente;

            _repository.Add(tarea);
        }

        public void CambiarEstado(int id, TareaEstado nuevoEstado)
        {
            var tarea = _repository.GetById(id);

            var estadoActual = (TareaEstado)tarea.EstadoId;

            if (estadoActual == TareaEstado.Pendiente &&
                nuevoEstado == TareaEstado.EnProceso)
            {
                tarea.EstadoId = (int)nuevoEstado;
            }
            else if (estadoActual == TareaEstado.EnProceso &&
                     nuevoEstado == TareaEstado.Terminada)
            {
                tarea.EstadoId = (int)nuevoEstado;
            }
           
            _repository.Update(tarea);
        }

        public void Actualizar(Tarea tarea)
        {
            var existente = _repository.GetById(tarea.Id);

            _repository.Update(tarea);
        }

        public void Eliminar(int id)
        {
            var tarea = _repository.GetById(id);
            _repository.Delete(id);
        }



        public IEnumerable<Tarea> GetFilteredTasks(TareaEstado? estado, TareaPrioridad? prioridad, string? usuario)
        {
            return _repository.GetFiltered(estado, prioridad, usuario);
        }

    }

}
