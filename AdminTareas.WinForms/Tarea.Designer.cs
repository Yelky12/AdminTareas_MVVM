namespace AdminTareas.WinForms;

partial class TaskForm
{
    private System.ComponentModel.IContainer components = null;

    private TextBox txtDescription;
    private DateTimePicker dtpDueDate;
    private DataGridView dgvTasks;
    private Button btnSave;
    private Button btnDelete;
    private Label lblDescription;
    private Label lblDueDate;

    private TextBox txtUsuario;
    private ComboBox cmbEstado;
    private ComboBox cmbPrioridad;
    private TextBox txtNotas;
    private Label lblUsuario;
    private Label lblEstado;
    private Label lblPrioridad;
    private Label lblNotas;
    private Button btnCambiarEstado;

    private Button btnNueva;


    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        txtDescription = new TextBox();
        dtpDueDate = new DateTimePicker();
        dgvTasks = new DataGridView();
        btnSave = new Button();
        btnDelete = new Button();
        lblDescription = new Label();
        lblDueDate = new Label();
        lblUsuario = new Label();
        txtUsuario = new TextBox();
        lblEstado = new Label();
        cmbEstado = new ComboBox();
        lblPrioridad = new Label();
        cmbPrioridad = new ComboBox();
        lblNotas = new Label();
        txtNotas = new TextBox();
        btnCambiarEstado = new Button();
        btnNueva = new Button();
        cmbFiltroEstado = new ComboBox();
        cmbFiltroPrioridad = new ComboBox();
        cmbFiltroUsuario = new ComboBox();
        btnFiltrar = new Button();
        btnLimpiar = new Button();
        groupBox1 = new GroupBox();
        groupBox2 = new GroupBox();
        lblUsr = new Label();
        lblPrio = new Label();
        lblEst = new Label();
        groupBox3 = new GroupBox();
        ((System.ComponentModel.ISupportInitialize)dgvTasks).BeginInit();
        groupBox1.SuspendLayout();
        groupBox2.SuspendLayout();
        groupBox3.SuspendLayout();
        SuspendLayout();
        // 
        // txtDescription
        // 
        txtDescription.Location = new Point(94, 16);
        txtDescription.Name = "txtDescription";
        txtDescription.Size = new Size(300, 23);
        txtDescription.TabIndex = 1;
        // 
        // dtpDueDate
        // 
        dtpDueDate.CustomFormat = "dd/MM/yyyy";
        dtpDueDate.Format = DateTimePickerFormat.Custom;
        dtpDueDate.Location = new Point(94, 49);
        dtpDueDate.Name = "dtpDueDate";
        dtpDueDate.Size = new Size(200, 23);
        dtpDueDate.TabIndex = 3;
        dtpDueDate.Value = new DateTime(2026, 2, 15, 0, 0, 0, 0);
        dtpDueDate.ValueChanged += dtpDueDate_ValueChanged;
        // 
        // dgvTasks
        // 
        dgvTasks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvTasks.BackgroundColor = Color.FromArgb(136, 63, 63);
        dgvTasks.Location = new Point(6, 22);
        dgvTasks.MultiSelect = false;
        dgvTasks.Name = "dgvTasks";
        dgvTasks.ReadOnly = true;
        dgvTasks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvTasks.Size = new Size(831, 160);
        dgvTasks.TabIndex = 16;
        dgvTasks.SelectionChanged += dgvTasks_SelectionChanged;
        // 
        // btnSave
        // 
        btnSave.BackColor = Color.FromArgb(193, 8, 7);
        btnSave.ForeColor = Color.White;
        btnSave.Location = new Point(425, 16);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(100, 30);
        btnSave.TabIndex = 12;
        btnSave.Text = "Guardar";
        btnSave.UseVisualStyleBackColor = false;
        btnSave.Click += btnSave_Click;
        // 
        // btnDelete
        // 
        btnDelete.BackColor = Color.FromArgb(193, 8, 7);
        btnDelete.ForeColor = Color.White;
        btnDelete.Location = new Point(425, 54);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new Size(100, 30);
        btnDelete.TabIndex = 13;
        btnDelete.Text = "Eliminar";
        btnDelete.UseVisualStyleBackColor = false;
        btnDelete.Click += btnDelete_Click;
        // 
        // lblDescription
        // 
        lblDescription.AutoSize = true;
        lblDescription.ForeColor = Color.White;
        lblDescription.Location = new Point(6, 19);
        lblDescription.Name = "lblDescription";
        lblDescription.Size = new Size(69, 15);
        lblDescription.TabIndex = 0;
        lblDescription.Text = "Descripcion";
        // 
        // lblDueDate
        // 
        lblDueDate.AutoSize = true;
        lblDueDate.ForeColor = Color.White;
        lblDueDate.Location = new Point(6, 54);
        lblDueDate.Name = "lblDueDate";
        lblDueDate.Size = new Size(71, 15);
        lblDueDate.TabIndex = 2;
        lblDueDate.Text = "Fecha límite";
        // 
        // lblUsuario
        // 
        lblUsuario.AutoSize = true;
        lblUsuario.ForeColor = Color.White;
        lblUsuario.Location = new Point(6, 84);
        lblUsuario.Name = "lblUsuario";
        lblUsuario.Size = new Size(47, 15);
        lblUsuario.TabIndex = 4;
        lblUsuario.Text = "Usuario";
        // 
        // txtUsuario
        // 
        txtUsuario.Location = new Point(94, 81);
        txtUsuario.Name = "txtUsuario";
        txtUsuario.Size = new Size(200, 23);
        txtUsuario.TabIndex = 5;
        //txtUsuario.TextChanged += txtUsuario_TextChanged;
        // 
        // lblEstado
        // 
        lblEstado.AutoSize = true;
        lblEstado.ForeColor = Color.White;
        lblEstado.Location = new Point(6, 114);
        lblEstado.Name = "lblEstado";
        lblEstado.Size = new Size(42, 15);
        lblEstado.TabIndex = 6;
        lblEstado.Text = "Estado";
        // 
        // cmbEstado
        // 
        cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbEstado.Location = new Point(94, 111);
        cmbEstado.Name = "cmbEstado";
        cmbEstado.Size = new Size(200, 23);
        cmbEstado.TabIndex = 7;
        // 
        // lblPrioridad
        // 
        lblPrioridad.AutoSize = true;
        lblPrioridad.ForeColor = Color.White;
        lblPrioridad.Location = new Point(6, 144);
        lblPrioridad.Name = "lblPrioridad";
        lblPrioridad.Size = new Size(55, 15);
        lblPrioridad.TabIndex = 8;
        lblPrioridad.Text = "Prioridad";
        // 
        // cmbPrioridad
        // 
        cmbPrioridad.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbPrioridad.Location = new Point(94, 141);
        cmbPrioridad.Name = "cmbPrioridad";
        cmbPrioridad.Size = new Size(200, 23);
        cmbPrioridad.TabIndex = 9;
        // 
        // lblNotas
        // 
        lblNotas.AutoSize = true;
        lblNotas.ForeColor = Color.White;
        lblNotas.Location = new Point(6, 174);
        lblNotas.Name = "lblNotas";
        lblNotas.Size = new Size(38, 15);
        lblNotas.TabIndex = 10;
        lblNotas.Text = "Notas";
        // 
        // txtNotas
        // 
        txtNotas.Location = new Point(94, 171);
        txtNotas.Multiline = true;
        txtNotas.Name = "txtNotas";
        txtNotas.Size = new Size(300, 60);
        txtNotas.TabIndex = 11;
        // 
        // btnCambiarEstado
        // 
        btnCambiarEstado.BackColor = Color.FromArgb(193, 8, 7);
        btnCambiarEstado.ForeColor = Color.White;
        btnCambiarEstado.Location = new Point(425, 94);
        btnCambiarEstado.Name = "btnCambiarEstado";
        btnCambiarEstado.Size = new Size(100, 30);
        btnCambiarEstado.TabIndex = 14;
        btnCambiarEstado.Text = "Avanzar";
        btnCambiarEstado.UseVisualStyleBackColor = false;
        btnCambiarEstado.Click += btnCambiarEstado_Click;
        // 
        // btnNueva
        // 
        btnNueva.BackColor = Color.FromArgb(193, 8, 7);
        btnNueva.ForeColor = Color.White;
        btnNueva.Location = new Point(425, 134);
        btnNueva.Name = "btnNueva";
        btnNueva.Size = new Size(100, 30);
        btnNueva.TabIndex = 15;
        btnNueva.Text = "Nueva";
        btnNueva.UseVisualStyleBackColor = false;
        btnNueva.Click += btnNueva_Click;
        // 
        // cmbFiltroEstado
        // 
        cmbFiltroEstado.FormattingEnabled = true;
        cmbFiltroEstado.Location = new Point(64, 22);
        cmbFiltroEstado.Name = "cmbFiltroEstado";
        cmbFiltroEstado.Size = new Size(121, 23);
        cmbFiltroEstado.TabIndex = 17;
        // 
        // cmbFiltroPrioridad
        // 
        cmbFiltroPrioridad.FormattingEnabled = true;
        cmbFiltroPrioridad.Location = new Point(252, 22);
        cmbFiltroPrioridad.Name = "cmbFiltroPrioridad";
        cmbFiltroPrioridad.Size = new Size(121, 23);
        cmbFiltroPrioridad.TabIndex = 18;
        // 
        // cmbFiltroUsuario
        // 
        cmbFiltroUsuario.FormattingEnabled = true;
        cmbFiltroUsuario.Location = new Point(447, 22);
        cmbFiltroUsuario.Name = "cmbFiltroUsuario";
        cmbFiltroUsuario.Size = new Size(121, 23);
        cmbFiltroUsuario.TabIndex = 19;
        // 
        // btnFiltrar
        // 
        btnFiltrar.BackColor = Color.FromArgb(193, 8, 7);
        btnFiltrar.Location = new Point(589, 18);
        btnFiltrar.Name = "btnFiltrar";
        btnFiltrar.Size = new Size(100, 30);
        btnFiltrar.TabIndex = 20;
        btnFiltrar.Text = "Filtrar";
        btnFiltrar.UseVisualStyleBackColor = false;
        btnFiltrar.Click += btnFiltrar_Click;
        // 
        // btnLimpiar
        // 
        btnLimpiar.BackColor = Color.FromArgb(193, 8, 7);
        btnLimpiar.Location = new Point(695, 18);
        btnLimpiar.Name = "btnLimpiar";
        btnLimpiar.Size = new Size(100, 30);
        btnLimpiar.TabIndex = 21;
        btnLimpiar.Text = "Limpiar";
        btnLimpiar.UseVisualStyleBackColor = false;
        btnLimpiar.Click += btnLimpiar_Click;
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(dgvTasks);
        groupBox1.ForeColor = Color.White;
        groupBox1.Location = new Point(6, 347);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(845, 193);
        groupBox1.TabIndex = 22;
        groupBox1.TabStop = false;
        groupBox1.Text = "Listado de Tareas";
        // 
        // groupBox2
        // 
        groupBox2.Controls.Add(lblUsr);
        groupBox2.Controls.Add(lblPrio);
        groupBox2.Controls.Add(lblEst);
        groupBox2.Controls.Add(cmbFiltroEstado);
        groupBox2.Controls.Add(cmbFiltroPrioridad);
        groupBox2.Controls.Add(btnLimpiar);
        groupBox2.Controls.Add(cmbFiltroUsuario);
        groupBox2.Controls.Add(btnFiltrar);
        groupBox2.ForeColor = Color.White;
        groupBox2.Location = new Point(12, 274);
        groupBox2.Name = "groupBox2";
        groupBox2.Size = new Size(839, 65);
        groupBox2.TabIndex = 23;
        groupBox2.TabStop = false;
        groupBox2.Text = "Filtros";
        // 
        // lblUsr
        // 
        lblUsr.AutoSize = true;
        lblUsr.ForeColor = Color.White;
        lblUsr.Location = new Point(379, 26);
        lblUsr.Name = "lblUsr";
        lblUsr.Size = new Size(47, 15);
        lblUsr.TabIndex = 24;
        lblUsr.Text = "Usuario";
        // 
        // lblPrio
        // 
        lblPrio.AutoSize = true;
        lblPrio.ForeColor = Color.White;
        lblPrio.Location = new Point(191, 26);
        lblPrio.Name = "lblPrio";
        lblPrio.Size = new Size(55, 15);
        lblPrio.TabIndex = 23;
        lblPrio.Text = "Prioridad";
        // 
        // lblEst
        // 
        lblEst.AutoSize = true;
        lblEst.ForeColor = Color.White;
        lblEst.Location = new Point(16, 26);
        lblEst.Name = "lblEst";
        lblEst.Size = new Size(42, 15);
        lblEst.TabIndex = 22;
        lblEst.Text = "Estado";
        // 
        // groupBox3
        // 
        groupBox3.Controls.Add(lblDescription);
        groupBox3.Controls.Add(txtNotas);
        groupBox3.Controls.Add(lblNotas);
        groupBox3.Controls.Add(btnSave);
        groupBox3.Controls.Add(btnDelete);
        groupBox3.Controls.Add(cmbPrioridad);
        groupBox3.Controls.Add(btnCambiarEstado);
        groupBox3.Controls.Add(txtDescription);
        groupBox3.Controls.Add(btnNueva);
        groupBox3.Controls.Add(lblPrioridad);
        groupBox3.Controls.Add(lblDueDate);
        groupBox3.Controls.Add(cmbEstado);
        groupBox3.Controls.Add(dtpDueDate);
        groupBox3.Controls.Add(lblEstado);
        groupBox3.Controls.Add(lblUsuario);
        groupBox3.Controls.Add(txtUsuario);
        groupBox3.ForeColor = Color.White;
        groupBox3.Location = new Point(12, 16);
        groupBox3.Name = "groupBox3";
        groupBox3.Size = new Size(550, 252);
        groupBox3.TabIndex = 24;
        groupBox3.TabStop = false;
        groupBox3.Text = "Formulario de Tareas";
        // 
        // TaskForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(51, 51, 51);
        ClientSize = new Size(872, 559);
        Controls.Add(groupBox3);
        Controls.Add(groupBox2);
        Controls.Add(groupBox1);
        Name = "TaskForm";
        Text = "Administración de Tareas";
        ((System.ComponentModel.ISupportInitialize)dgvTasks).EndInit();
        groupBox1.ResumeLayout(false);
        groupBox2.ResumeLayout(false);
        groupBox2.PerformLayout();
        groupBox3.ResumeLayout(false);
        groupBox3.PerformLayout();
        ResumeLayout(false);
    }
    private ComboBox cmbFiltroEstado;
    private ComboBox cmbFiltroPrioridad;
    private ComboBox cmbFiltroUsuario;
    private Button btnFiltrar;
    private Button btnLimpiar;
    private GroupBox groupBox1;
    private GroupBox groupBox2;
    private Label lblUsr;
    private Label lblPrio;
    private Label lblEst;
    private GroupBox groupBox3;
}
