namespace UI
{
    partial class Profesionales
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
            comboBox1 = new ComboBox();
            textBox2 = new TextBox();
            label8 = new Label();
            label7 = new Label();
            textBox1 = new TextBox();
            labelPersona = new Label();
            comboBoxPersona = new ComboBox();
            label1 = new Label();
            button2 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(20, 248);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "Nuevo";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(331, 32);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(423, 348);
            dataGridView1.TabIndex = 10;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(20, 148);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(291, 23);
            comboBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(20, 202);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(291, 23);
            textBox2.TabIndex = 3;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(20, 184);
            label8.Name = "label8";
            label8.Size = new Size(47, 15);
            label8.TabIndex = 9;
            label8.Text = "Arancel";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(20, 130);
            label7.Name = "label7";
            label7.Size = new Size(72, 15);
            label7.TabIndex = 8;
            label7.Text = "Especialidad";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(20, 94);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(291, 23);
            textBox1.TabIndex = 1;
            // 
            // labelPersona
            // 
            labelPersona.AutoSize = true;
            labelPersona.Location = new Point(20, 22);
            labelPersona.Name = "labelPersona";
            labelPersona.Size = new Size(48, 15);
            labelPersona.TabIndex = 11;
            labelPersona.Text = "Persona";
            // 
            // comboBoxPersona
            // 
            comboBoxPersona.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPersona.FormattingEnabled = true;
            comboBoxPersona.Location = new Point(20, 40);
            comboBoxPersona.Name = "comboBoxPersona";
            comboBoxPersona.Size = new Size(291, 23);
            comboBoxPersona.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 76);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 7;
            label1.Text = "Matricula";
            // 
            // button2
            // 
            button2.Location = new Point(128, 248);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 5;
            button2.Text = "Guardar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(236, 248);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 6;
            button3.Text = "Eliminar";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Profesionales
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(comboBox1);
            Controls.Add(textBox2);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(textBox1);
            Controls.Add(comboBoxPersona);
            Controls.Add(labelPersona);
            Controls.Add(label1);
            Name = "Profesionales";
            Text = "Profesionales";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private DataGridView dataGridView1;
        private ComboBox comboBox1;
        private TextBox textBox2;
        private Label label8;
        private Label label7;
        private TextBox textBox1;
        private Label labelPersona;
        private ComboBox comboBoxPersona;
        private Label label1;
        private Button button2;
        private Button button3;
    }
}