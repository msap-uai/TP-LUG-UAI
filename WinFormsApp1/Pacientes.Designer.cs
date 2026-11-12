namespace UI
{
    partial class Pacientes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            txtMail = new TextBox();
            txtTelefono = new TextBox();
            txtDni = new TextBox();
            txtApellido = new TextBox();
            txtNombre = new TextBox();
            label6 = new Label();
            label1 = new Label();
            label7 = new Label();
            label8 = new Label();
            txtNumeroAfiliado = new TextBox();
            cmbObraSocial = new ComboBox();
            dgvPacientes = new DataGridView();
            btnAgregar = new Button();
            dtpFechaNacimiento = new DateTimePicker();
            btnModificar = new Button();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPacientes).BeginInit();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(35, 308);
            label5.Name = "label5";
            label5.Size = new Size(38, 20);
            label5.TabIndex = 27;
            label5.Text = "Mail";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(32, 247);
            label4.Name = "label4";
            label4.Size = new Size(67, 20);
            label4.TabIndex = 26;
            label4.Text = "Telefono";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(35, 185);
            label3.Name = "label3";
            label3.Size = new Size(35, 20);
            label3.TabIndex = 25;
            label3.Text = "DNI";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 123);
            label2.Name = "label2";
            label2.Size = new Size(66, 20);
            label2.TabIndex = 24;
            label2.Text = "Apellido";
            // 
            // txtMail
            // 
            txtMail.Location = new Point(197, 304);
            txtMail.Margin = new Padding(3, 4, 3, 4);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(166, 27);
            txtMail.TabIndex = 23;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(197, 243);
            txtTelefono.Margin = new Padding(3, 4, 3, 4);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(166, 27);
            txtTelefono.TabIndex = 22;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(197, 181);
            txtDni.Margin = new Padding(3, 4, 3, 4);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(166, 27);
            txtDni.TabIndex = 21;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(197, 120);
            txtApellido.Margin = new Padding(3, 4, 3, 4);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(166, 27);
            txtApellido.TabIndex = 20;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(197, 59);
            txtNombre.Margin = new Padding(3, 4, 3, 4);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(166, 27);
            txtNombre.TabIndex = 19;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(32, 59);
            label6.Name = "label6";
            label6.Size = new Size(64, 20);
            label6.TabIndex = 18;
            label6.Text = "Nombre";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 377);
            label1.Name = "label1";
            label1.Size = new Size(146, 20);
            label1.TabIndex = 28;
            label1.Text = "Fecha de nacimiento";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(32, 437);
            label7.Name = "label7";
            label7.Size = new Size(86, 20);
            label7.TabIndex = 30;
            label7.Text = "Obra Social";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(32, 492);
            label8.Name = "label8";
            label8.Size = new Size(118, 20);
            label8.TabIndex = 31;
            label8.Text = "Numero afiliado";
            // 
            // txtNumeroAfiliado
            // 
            txtNumeroAfiliado.Location = new Point(197, 488);
            txtNumeroAfiliado.Margin = new Padding(3, 4, 3, 4);
            txtNumeroAfiliado.Name = "txtNumeroAfiliado";
            txtNumeroAfiliado.Size = new Size(166, 27);
            txtNumeroAfiliado.TabIndex = 32;
            // 
            // cmbObraSocial
            // 
            cmbObraSocial.FormattingEnabled = true;
            cmbObraSocial.Location = new Point(197, 427);
            cmbObraSocial.Margin = new Padding(3, 4, 3, 4);
            cmbObraSocial.Name = "cmbObraSocial";
            cmbObraSocial.Size = new Size(166, 28);
            cmbObraSocial.TabIndex = 33;
            // 
            // dgvPacientes
            // 
            dgvPacientes.AllowUserToAddRows = false;
            dgvPacientes.AllowUserToDeleteRows = false;
            dgvPacientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvPacientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPacientes.Location = new Point(403, 63);
            dgvPacientes.Margin = new Padding(3, 4, 3, 4);
            dgvPacientes.MultiSelect = false;
            dgvPacientes.Name = "dgvPacientes";
            dgvPacientes.ReadOnly = true;
            dgvPacientes.RowHeadersWidth = 51;
            dgvPacientes.Size = new Size(483, 464);
            dgvPacientes.TabIndex = 34;
            dgvPacientes.CellClick += dgvPacientes_CellClick;
            // 
            // btnAgregar
            // 
            btnAgregar.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregar.Location = new Point(32, 553);
            btnAgregar.Margin = new Padding(3, 4, 3, 4);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(170, 31);
            btnAgregar.TabIndex = 35;
            btnAgregar.Text = "Agregar paciente";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Location = new Point(192, 365);
            dtpFechaNacimiento.Margin = new Padding(3, 4, 3, 4);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(166, 27);
            dtpFechaNacimiento.TabIndex = 36;
            // 
            // btnModificar
            // 
            btnModificar.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnModificar.Location = new Point(234, 559);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(192, 29);
            btnModificar.TabIndex = 37;
            btnModificar.Text = "Modificar paciente";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminar.Location = new Point(455, 559);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(192, 29);
            btnEliminar.TabIndex = 38;
            btnEliminar.Text = "Eliminar paciente";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // Pacientes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(dtpFechaNacimiento);
            Controls.Add(btnAgregar);
            Controls.Add(dgvPacientes);
            Controls.Add(cmbObraSocial);
            Controls.Add(txtNumeroAfiliado);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtMail);
            Controls.Add(txtTelefono);
            Controls.Add(txtDni);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(label6);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Pacientes";
            Text = "Pacientes";
            Load += Pacientes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPacientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtMail;
        private TextBox txtTelefono;
        private TextBox txtDni;
        private TextBox txtApellido;
        private TextBox txtNombre;
        private Label label6;
        private Label label1;
        private Label label7;
        private Label label8;
        private TextBox txtNumeroAfiliado;
        private ComboBox cmbObraSocial;
        private DataGridView dgvPacientes;
        private Button btnAgregar;
        private DateTimePicker dtpFechaNacimiento;
        private Button btnModificar;
        private Button btnEliminar;
    }
}