namespace UI
{
    partial class Persona
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
            labelNombre = new Label();
            textBoxNombre = new TextBox();
            labelApellido = new Label();
            textBoxApellido = new TextBox();
            labelDni = new Label();
            textBoxDni = new TextBox();
            labelTelefono = new Label();
            textBoxTelefono = new TextBox();
            labelMail = new Label();
            textBoxMail = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            dataGridView1 = new DataGridView();
            labelPersonas = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // labelNombre
            // 
            labelNombre.AutoSize = true;
            labelNombre.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelNombre.Location = new Point(20, 22);
            labelNombre.Name = "labelNombre";
            labelNombre.Size = new Size(56, 15);
            labelNombre.TabIndex = 9;
            labelNombre.Text = "Nombre:";
            // 
            // textBoxNombre
            // 
            textBoxNombre.Location = new Point(20, 40);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(291, 23);
            textBoxNombre.TabIndex = 0;
            // 
            // labelApellido
            // 
            labelApellido.AutoSize = true;
            labelApellido.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelApellido.Location = new Point(20, 76);
            labelApellido.Name = "labelApellido";
            labelApellido.Size = new Size(56, 15);
            labelApellido.TabIndex = 10;
            labelApellido.Text = "Apellido:";
            // 
            // textBoxApellido
            // 
            textBoxApellido.Location = new Point(20, 94);
            textBoxApellido.Name = "textBoxApellido";
            textBoxApellido.Size = new Size(291, 23);
            textBoxApellido.TabIndex = 1;
            // 
            // labelDni
            // 
            labelDni.AutoSize = true;
            labelDni.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDni.Location = new Point(20, 130);
            labelDni.Name = "labelDni";
            labelDni.Size = new Size(56, 15);
            labelDni.TabIndex = 11;
            labelDni.Text = "DNI:";
            // 
            // textBoxDni
            // 
            textBoxDni.Location = new Point(20, 148);
            textBoxDni.Name = "textBoxDni";
            textBoxDni.Size = new Size(291, 23);
            textBoxDni.TabIndex = 2;
            // 
            // labelTelefono
            // 
            labelTelefono.AutoSize = true;
            labelTelefono.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTelefono.Location = new Point(20, 184);
            labelTelefono.Name = "labelTelefono";
            labelTelefono.Size = new Size(56, 15);
            labelTelefono.TabIndex = 12;
            labelTelefono.Text = "Teléfono:";
            // 
            // textBoxTelefono
            // 
            textBoxTelefono.Location = new Point(20, 202);
            textBoxTelefono.Name = "textBoxTelefono";
            textBoxTelefono.Size = new Size(291, 23);
            textBoxTelefono.TabIndex = 3;
            // 
            // labelMail
            // 
            labelMail.AutoSize = true;
            labelMail.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelMail.Location = new Point(20, 238);
            labelMail.Name = "labelMail";
            labelMail.Size = new Size(56, 15);
            labelMail.TabIndex = 13;
            labelMail.Text = "Mail:";
            // 
            // textBoxMail
            // 
            textBoxMail.Location = new Point(20, 256);
            textBoxMail.Name = "textBoxMail";
            textBoxMail.Size = new Size(291, 23);
            textBoxMail.TabIndex = 4;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(20, 302);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 5;
            button1.Text = "Nuevo";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(128, 302);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 6;
            button2.Text = "Guardar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(236, 302);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 7;
            button3.Text = "Eliminar";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(340, 40);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(440, 335);
            dataGridView1.TabIndex = 8;
            // 
            // labelPersonas
            // 
            labelPersonas.AutoSize = true;
            labelPersonas.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPersonas.Location = new Point(340, 22);
            labelPersonas.Name = "labelPersonas";
            labelPersonas.Size = new Size(56, 15);
            labelPersonas.TabIndex = 14;
            labelPersonas.Text = "Personas:";
            // 
            // Persona
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 392);
            Controls.Add(labelNombre);
            Controls.Add(textBoxNombre);
            Controls.Add(labelApellido);
            Controls.Add(textBoxApellido);
            Controls.Add(labelDni);
            Controls.Add(textBoxDni);
            Controls.Add(labelTelefono);
            Controls.Add(textBoxTelefono);
            Controls.Add(labelMail);
            Controls.Add(textBoxMail);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(button3);
            Controls.Add(dataGridView1);
            Controls.Add(labelPersonas);
            Name = "Persona";
            Text = "Personas";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelNombre;
        private TextBox textBoxNombre;
        private Label labelApellido;
        private TextBox textBoxApellido;
        private Label labelDni;
        private TextBox textBoxDni;
        private Label labelTelefono;
        private TextBox textBoxTelefono;
        private Label labelMail;
        private TextBox textBoxMail;
        private Button button1;
        private Button button2;
        private Button button3;
        private DataGridView dataGridView1;
        private Label labelPersonas;
    }
}