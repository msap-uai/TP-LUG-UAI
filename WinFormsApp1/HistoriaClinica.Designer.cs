namespace UI
{
    partial class HistoriaClinica
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
            button1 = new Button();
            dataGridView1 = new DataGridView();
            dataGridView2 = new DataGridView();
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            comboBoxPaciente = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(22, 384);
            button1.Name = "button1";
            button1.Size = new Size(144, 23);
            button1.TabIndex = 0;
            button1.Text = "Guardar consulta";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(22, 91);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(368, 203);
            dataGridView1.TabIndex = 1;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(408, 91);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(368, 203);
            dataGridView2.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(22, 339);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(380, 23);
            textBox1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 321);
            label1.Name = "label1";
            label1.Size = new Size(70, 15);
            label1.TabIndex = 4;
            label1.Text = "Diagnostico";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 66);
            label2.Name = "label2";
            label2.Size = new Size(120, 15);
            label2.TabIndex = 5;
            label2.Text = "Historial de consultas";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(408, 66);
            label3.Name = "label3";
            label3.Size = new Size(137, 15);
            label3.TabIndex = 6;
            label3.Text = "Historial de diagnosticos";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 27);
            label4.Name = "label4";
            label4.Size = new Size(52, 15);
            label4.TabIndex = 8;
            label4.Text = "Paciente";
            // 
            // comboBoxPaciente
            // 
            comboBoxPaciente.FormattingEnabled = true;
            comboBoxPaciente.Location = new Point(88, 24);
            comboBoxPaciente.Name = "comboBoxPaciente";
            comboBoxPaciente.Size = new Size(210, 23);
            comboBoxPaciente.TabIndex = 9;
            // 
            // HistoriaClinica
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(comboBoxPaciente);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Name = "HistoriaClinica";
            Text = "HistoriaClinica";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox comboBoxPaciente;
    }
}