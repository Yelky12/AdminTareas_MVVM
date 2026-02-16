using AdminTareas.Models.Models;
using AdminTareas.Services.Interfaces;
using AdminTareas.ViewModels.Interfaces;
using System.ComponentModel;

namespace AdminTareas.ViewModels.ViewModels
{
    public class TaskViewModel : ITaskViewModel, INotifyPropertyChanged , IDataErrorInfo
    {
        private readonly ITaskService _service;

        public BindingList<Tarea> Tasks { get; set; }

        private TareaEstado? _filtroEstado;
        public TareaEstado? FiltroEstado
        {
            get => _filtroEstado;
            set { _filtroEstado = value; OnPropertyChanged(nameof(FiltroEstado)); }
        }

        private TareaPrioridad? _filtroPrioridad;
        public TareaPrioridad? FiltroPrioridad
        {
            get => _filtroPrioridad;
            set { _filtroPrioridad = value; OnPropertyChanged(nameof(FiltroPrioridad)); }
        }

        private string? _filtroUsuario;
        public string? FiltroUsuario
        {
            get => _filtroUsuario;
            set { _filtroUsuario = value; OnPropertyChanged(nameof(FiltroUsuario)); }
        }

        private int _id;

        private string _descripcion = string.Empty;

        public string Descripcion
        {
            get => _descripcion;
            set { _descripcion = value; OnPropertyChanged(nameof(Descripcion)); }
        }

        private string _usuario = string.Empty;
        public string Usuario
        {
            get => _usuario;
            set { _usuario = value; OnPropertyChanged(nameof(Usuario)); }
        }

        private TareaEstado _estado;
        public TareaEstado Estado
        {
            get => _estado;
            set { _estado = value; OnPropertyChanged(nameof(Estado)); }
        }

        private TareaPrioridad _prioridad;
        public TareaPrioridad Prioridad
        {
            get => _prioridad;
            set { _prioridad = value; OnPropertyChanged(nameof(Prioridad)); }
        }

        private DateTime _fechaCompromiso = DateTime.Today;
        public DateTime FechaCompromiso
        {
            get => _fechaCompromiso;
            set { _fechaCompromiso = value; OnPropertyChanged(nameof(FechaCompromiso)); }
        }

        private string _notas = string.Empty;
        public string Notas
        {
            get => _notas;
            set { _notas = value; OnPropertyChanged(nameof(Notas)); }
        }

        public TaskViewModel(ITaskService service)
        {
            _service = service;
            Tasks = new BindingList<Tarea>(_service.GetTasks());
        }

        public void Save()
        {
            var tarea = new Tarea
            {
                Id = _id,
                Descripcion = Descripcion,
                Usuario = Usuario,
                EstadoId = (int)Estado,
                PrioridadId = (int)Prioridad,
                FechaCompromiso = FechaCompromiso,
                Notas = Notas
            };

            if (_id == 0)
                _service.Crear(tarea);
            else
                _service.Actualizar(tarea);

            LimpiarForm();
            Refrescar();
        }


        public void LoadTask(Tarea tarea)
        {
            _id = tarea.Id;
            Descripcion = tarea.Descripcion;
            Usuario = tarea.Usuario;
            Estado = (TareaEstado)tarea.EstadoId;
            Prioridad = (TareaPrioridad)tarea.PrioridadId;
            FechaCompromiso = tarea.FechaCompromiso;
            Notas = tarea.Notas;
        }


        public void Delete(int id)
        {
            _service.Eliminar(id);
            Refrescar();
        }

        public void AvanzarEstado(int id)
        {
            var tarea = _service.GetTasks().First(t => t.Id == id);
            var estadoActual = (TareaEstado)tarea.EstadoId;

            if (estadoActual == TareaEstado.Pendiente)
                _service.CambiarEstado(id, TareaEstado.EnProceso);
            else if (estadoActual == TareaEstado.EnProceso)
                _service.CambiarEstado(id, TareaEstado.Terminada);

            Refrescar();
        }

        public void RecargarTodo()
        {
            Refrescar();
        }

        private void Refrescar()
        {
            Tasks.Clear();
            foreach (var t in _service.GetTasks())
                Tasks.Add(t);
        }

        public void AplicarFiltros()
        {
            var tareasFiltradas = _service.GetFilteredTasks(
                FiltroEstado,
                FiltroPrioridad,
                FiltroUsuario);

            Tasks.Clear();

            foreach (var t in tareasFiltradas.OrderBy(t => t.FechaCompromiso))
                Tasks.Add(t);
        }

        public void LimpiarFiltros()
        {
            FiltroEstado = null;
            FiltroPrioridad = null;
            FiltroUsuario = null;

            Refrescar();
        }


        private void LimpiarForm()
        {
            _id = 0;
            Descripcion = string.Empty;
            Usuario = string.Empty;
            Estado = TareaEstado.Pendiente;
            Prioridad = TareaPrioridad.Media;
            FechaCompromiso = DateTime.Today;
            Notas = string.Empty;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string prop)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));


        // Implementar validacion de IDataErrorInfo
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(Descripcion):
                        if (string.IsNullOrWhiteSpace(Descripcion))
                            return "La descripción es obligatoria";
                        break;

                    case nameof(Usuario):
                        if (string.IsNullOrWhiteSpace(Usuario))
                            return "El usuario es obligatorio";
                        break;
                }

                return null; // importante
            }
        }

        public string Error => null;

        public bool EsValido()
        {
            return
                !string.IsNullOrWhiteSpace(Descripcion) &&
                !string.IsNullOrWhiteSpace(Usuario);
        }


    }
}
