namespace UI
{
    partial class Agenda
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
            checkBox1 = new CheckBox();
            dateTimePicker1 = new DateTimePicker();
            label1 = new Label();
            comboBox1 = new ComboBox();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 369);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Cancelar turno";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 59);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(704, 287);
            dataGridView1.TabIndex = 1;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(12, 28);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(116, 19);
            checkBox1.TabIndex = 2;
            checkBox1.Text = "Filtrar por fecha";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Enabled = false;
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(140, 26);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(120, 23);
            dateTimePicker1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(290, 30);
            label1.Name = "label1";
            label1.Size = new Size(70, 15);
            label1.TabIndex = 4;
            label1.Text = "Consultorio:";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(365, 26);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(180, 23);
            comboBox1.TabIndex = 5;
            // 
            // button2
            // 
            button2.Location = new Point(560, 26);
            button2.Name = "button2";
            button2.Size = new Size(110, 23);
            button2.TabIndex = 6;
            button2.Text = "Limpiar filtros";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Agenda
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Controls.Add(dateTimePicker1);
            Controls.Add(checkBox1);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Name = "Agenda";
            Text = "Agenda";
            Load += Agenda_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private DataGridView dataGridView1;
        private CheckBox checkBox1;
        private DateTimePicker dateTimePicker1;
        private Label label1;
        private ComboBox comboBox1;
        private Button button2;
    }
}