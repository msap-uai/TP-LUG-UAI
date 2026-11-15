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
            labelPersona = new Label();
            cmbPersona = new ComboBox();
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
            // labelPersona
            // 
            labelPersona.AutoSize = true;
            labelPersona.Location = new Point(20, 22);
            labelPersona.Name = "labelPersona";
            labelPersona.Size = new Size(48, 15);
            labelPersona.TabIndex = 18;
            labelPersona.Text = "Persona";
            // 
            // cmbPersona
            // 
            cmbPersona.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPersona.FormattingEnabled = true;
            cmbPersona.Location = new Point(20, 40);
            cmbPersona.Name = "cmbPersona";
            cmbPersona.Size = new Size(291, 23);
            cmbPersona.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 76);
            label1.Name = "label1";
            label1.Size = new Size(115, 15);
            label1.TabIndex = 28;
            label1.Text = "Fecha de nacimiento";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(20, 130);
            label7.Name = "label7";
            label7.Size = new Size(65, 15);
            label7.TabIndex = 30;
            label7.Text = "Obra Social";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(20, 184);
            label8.Name = "label8";
            label8.Size = new Size(90, 15);
            label8.TabIndex = 31;
            label8.Text = "Numero afiliado";
            // 
            // txtNumeroAfiliado
            // 
            txtNumeroAfiliado.Location = new Point(20, 202);
            txtNumeroAfiliado.Name = "txtNumeroAfiliado";
            txtNumeroAfiliado.Size = new Size(291, 23);
            txtNumeroAfiliado.TabIndex = 32;
            // 
            // cmbObraSocial
            // 
            cmbObraSocial.FormattingEnabled = true;
            cmbObraSocial.Location = new Point(20, 148);
            cmbObraSocial.Name = "cmbObraSocial";
            cmbObraSocial.Size = new Size(291, 23);
            cmbObraSocial.TabIndex = 33;
            // 
            // dgvPacientes
            // 
            dgvPacientes.AllowUserToAddRows = false;
            dgvPacientes.AllowUserToDeleteRows = false;
            dgvPacientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvPacientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPacientes.Location = new Point(331, 32);
            dgvPacientes.MultiSelect = false;
            dgvPacientes.Name = "dgvPacientes";
            dgvPacientes.ReadOnly = true;
            dgvPacientes.RowHeadersWidth = 51;
            dgvPacientes.Size = new Size(423, 348);
            dgvPacientes.TabIndex = 34;
            dgvPacientes.CellClick += dgvPacientes_CellClick;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(20, 248);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 35;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Location = new Point(20, 94);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(291, 23);
            dtpFechaNacimiento.TabIndex = 36;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(128, 248);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 37;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(236, 248);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 38;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // Pacientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
            Controls.Add(cmbPersona);
            Controls.Add(labelPersona);
            Name = "Pacientes";
            Text = "Pacientes";
            Load += Pacientes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPacientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelPersona;
        private ComboBox cmbPersona;
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