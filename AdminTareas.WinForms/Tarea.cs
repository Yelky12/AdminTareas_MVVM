using AdminTareas.Models.Models;
using AdminTareas.ViewModels.Interfaces;
using AdminTareas.ViewModels.ViewModels;

namespace AdminTareas.WinForms;

public partial class TaskForm : Form
{
    private readonly ITaskViewModel _vm;

    public TaskForm(TaskViewModel vm)
    {
        InitializeComponent();
        _vm = vm;

        InicializarBindings();
    }

    private void InicializarBindings()
    {
        this.Load += TaskForm_Load;

        dgvTasks.DataBindingComplete += dgvTasks_DataBindingComplete;
        dgvTasks.RowPrePaint += dgvTasks_RowPrePaint;

        txtDescription.DataBindings.Add(
            "Text",
            _vm,
            nameof(TaskViewModel.Descripcion),
            false,
            DataSourceUpdateMode.OnPropertyChanged
        );


        dtpDueDate.DataBindings.Add(
            "Value",
            _vm,
            nameof(TaskViewModel.FechaCompromiso),
            false,
            DataSourceUpdateMode.OnPropertyChanged
        );


        dgvTasks.AutoGenerateColumns = true;
        dgvTasks.DataSource = _vm.Tasks;



        txtUsuario.DataBindings.Add(
            "Text",
            _vm,
            nameof(TaskViewModel.Usuario),
            true,
            DataSourceUpdateMode.OnPropertyChanged
        );

        txtNotas.DataBindings.Add(
            "Text",
            _vm,
            nameof(TaskViewModel.Notas),
            true,
            DataSourceUpdateMode.OnPropertyChanged
        );


        cmbEstado.DataSource = Enum.GetValues(typeof(TareaEstado));
        cmbPrioridad.DataSource = Enum.GetValues(typeof(TareaPrioridad));
        cmbFiltroEstado.DataSource = Enum.GetValues(typeof(TareaEstado));
        cmbFiltroEstado.SelectedIndex = -1;
        cmbFiltroPrioridad.DataSource = Enum.GetValues(typeof(TareaPrioridad));
        cmbFiltroPrioridad.SelectedIndex = -1;

        cmbFiltroUsuario.DataSource = _vm.Tasks.Select(t => t.Usuario).Distinct().ToList();
        cmbFiltroUsuario.SelectedIndex = -1;


        cmbEstado.DataBindings.Add(
            "SelectedItem",
            _vm,
            nameof(TaskViewModel.Estado),
            false,
            DataSourceUpdateMode.OnPropertyChanged
        );

        cmbPrioridad.DataBindings.Add(
            "SelectedItem",
            _vm,
            nameof(TaskViewModel.Prioridad),
            false,
            DataSourceUpdateMode.OnPropertyChanged
        );

    }

    private void TaskForm_Load(object sender, EventArgs e)
    {
        dgvTasks.ClearSelection();
        _vm.LoadTask(new Tarea());
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        MarcarValidacion();

        if (!_vm.EsValido())
        {
            MessageBox.Show("Complete los campos obligatorios",
                "Validacion",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }


        _vm.Save();
        LimpiarFormulario();
    }


    private void LimpiarFormulario()
    {
        _vm.LoadTask(new Tarea());

        btnSave.Text = "Guardar";
        btnSave.Enabled = true;

        txtDescription.ReadOnly = false;
        txtUsuario.ReadOnly = false;
        txtNotas.ReadOnly = false;
        cmbEstado.Enabled = true;
        cmbPrioridad.Enabled = true;
        dtpDueDate.Enabled = true;
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (dgvTasks.CurrentRow == null)
            return;

        var tarea = (Tarea)dgvTasks.CurrentRow.DataBoundItem;

        try
        {
            _vm.Delete(tarea.Id);
            MessageBox.Show("Tarea eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (InvalidOperationException ex)
        {
            
            MessageBox.Show(ex.Message, "Proceso no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (Exception ex)
        {
            
            MessageBox.Show("Ocurrió un error al eliminar la tarea: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void dgvTasks_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvTasks.CurrentRow == null ||
            dgvTasks.CurrentRow.DataBoundItem == null ||
            dgvTasks.SelectedRows.Count == 0)
            return;

        var tarea = (Tarea)dgvTasks.CurrentRow.DataBoundItem;

        if (tarea == null)
            return;
        dtpDueDate.MinDate = new DateTime(2010, 1, 1);

        _vm.LoadTask(tarea);

        btnSave.Text = "Actualizar";



        bool editable = tarea.EstadoId == (int)TareaEstado.Pendiente;

        btnSave.Enabled = editable;

        txtDescription.ReadOnly = !editable;
        txtUsuario.ReadOnly = !editable;
        txtNotas.ReadOnly = !editable;
        cmbEstado.Enabled = editable;
        cmbPrioridad.Enabled = editable;
        dtpDueDate.Enabled = editable;

        btnDelete.Enabled = ((TareaEstado)tarea.EstadoId != TareaEstado.EnProceso);
    }


    private void btnNueva_Click(object sender, EventArgs e)
    {
        dgvTasks.ClearSelection();

        _vm.LoadTask(new Tarea());

        btnSave.Text = "Guardar";
        btnSave.Enabled = true;

        txtDescription.ReadOnly = false;
        txtUsuario.ReadOnly = false;
        txtNotas.ReadOnly = false;
        cmbEstado.Enabled = false;
        cmbEstado.SelectedIndex = 0;

        cmbPrioridad.Enabled = true;
        dtpDueDate.Enabled = true;
        dtpDueDate.MinDate = DateTime.Today;

    }

    private void btnCambiarEstado_Click(object sender, EventArgs e)
    {
        if (dgvTasks.CurrentRow == null)
            return;

        var tarea = (Tarea)dgvTasks.CurrentRow.DataBoundItem;

        _vm.AvanzarEstado(tarea.Id);
    }

    private void btnFiltrar_Click(object sender, EventArgs e)
    {
        _vm.FiltroEstado = cmbFiltroEstado.SelectedIndex >= 0
            ? (TareaEstado?)cmbFiltroEstado.SelectedItem
            : null;

        _vm.FiltroPrioridad = cmbFiltroPrioridad.SelectedIndex >= 0
            ? (TareaPrioridad?)cmbFiltroPrioridad.SelectedItem
            : null;

        _vm.FiltroUsuario = cmbFiltroUsuario.SelectedIndex >= 0
           ? cmbFiltroUsuario.SelectedItem.ToString()
           : null;

        _vm.AplicarFiltros();
    }


    private void dgvTasks_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
        if (dgvTasks.Columns.Contains("EstadoId"))
        {
            dgvTasks.Columns["EstadoId"].Visible = false;
            dgvTasks.Columns["EstadoNombre"].HeaderText = "Estado";
        }

        if (dgvTasks.Columns.Contains("PrioridadId"))
        {
            dgvTasks.Columns["PrioridadId"].Visible = false;
            dgvTasks.Columns["PrioridadNombre"].HeaderText = "Prioridad";
        }
        if (dgvTasks.Columns.Contains("FechaCompromiso"))
            dgvTasks.Columns["FechaCompromiso"].HeaderText = "Fecha de Compromiso";


        if (dgvTasks.Columns.Contains("PrioridadId"))
            dgvTasks.Columns["PrioridadId"].Visible = false;
        if (dgvTasks.Columns.Contains("Id"))
            dgvTasks.Columns["Id"].Visible = false;

        dgvTasks.Columns["Descripcion"].FillWeight = 20;
        dgvTasks.Columns["Usuario"].FillWeight = 15;
        dgvTasks.Columns["EstadoNombre"].FillWeight = 10;
        dgvTasks.Columns["PrioridadNombre"].FillWeight = 10;
        dgvTasks.Columns["FechaCompromiso"].FillWeight = 20;
        dgvTasks.Columns["Notas"].FillWeight = 30;


        //orden
        dgvTasks.Columns["Descripcion"].DisplayIndex = 0;
        dgvTasks.Columns["Usuario"].DisplayIndex = 1;
        dgvTasks.Columns["EstadoNombre"].DisplayIndex = 2;
        dgvTasks.Columns["PrioridadNombre"].DisplayIndex = 3;
        dgvTasks.Columns["FechaCompromiso"].DisplayIndex = 4;
        dgvTasks.Columns["Notas"].DisplayIndex = 5;


    }


    private void dgvTasks_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
    {

        if (dgvTasks.Rows[e.RowIndex].DataBoundItem is Tarea tarea)
        {
            var color = ((TareaEstado)tarea.EstadoId) switch
            {
                TareaEstado.Pendiente => Color.FromArgb(209, 208, 130),
                TareaEstado.EnProceso => Color.FromArgb(34, 110, 168),
                TareaEstado.Terminada => Color.FromArgb(45, 97, 58),
                _ => Color.FromArgb(136, 63, 63)
            };

            dgvTasks.Rows[e.RowIndex].DefaultCellStyle.BackColor = color;
        }
    }

    private void btnLimpiar_Click(object sender, EventArgs e)
    {
        cmbFiltroEstado.SelectedIndex = -1;
        cmbFiltroPrioridad.SelectedIndex = -1;
        cmbFiltroUsuario.SelectedIndex = -1;

        _vm.FiltroEstado = null;
        _vm.FiltroPrioridad = null;
        _vm.FiltroUsuario = null;

        _vm.RecargarTodo();
    }

    private void dtpDueDate_ValueChanged(object sender, EventArgs e)
    {

    }

    //private void MarcarValidacion(Label label, bool esvalido)
    //{
    //    if (!esvalido)
    //        label.Text = label.Text.Replace( ".",". **");
    //}

    //private void txtUsuario_TextChanged(object sender, EventArgs e)
    //{
    //    MarcarValidacion(lblUsr, !string.IsNullOrEmpty(txtUsuario.Text));
    //}

    private void MarcarValidacion()
    {
        MarcarCampo(lblDescription, string.IsNullOrWhiteSpace(txtDescription.Text));
        MarcarCampo(lblUsuario, string.IsNullOrWhiteSpace(txtUsuario.Text));
    }

    private void MarcarCampo(Label label, bool invalido)
    {
        string textoBase = label.Text.Replace(" *", "");

        if (invalido)
        {
            label.Text = textoBase + " *";
            label.ForeColor = Color.Red;
        }
        else
        {
            label.Text = textoBase;
            label.ForeColor = Color.White ;
        }
    }

}
