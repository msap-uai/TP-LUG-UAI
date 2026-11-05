namespace WinFormsApp1
{
    partial class Inicio
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            inicioToolStripMenuItem = new ToolStripMenuItem();
            toolStripTextBox1 = new ToolStripTextBox();
            especialidadesToolStripMenuItem1 = new ToolStripMenuItem();
            especialidadesToolStripMenuItem2 = new ToolStripMenuItem();
            obrasSocialesToolStripMenuItem1 = new ToolStripMenuItem();
            pacientesToolStripMenuItem = new ToolStripMenuItem();
            consultoriosToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            salirToolStripMenuItem = new ToolStripMenuItem();
            turnosToolStripMenuItem = new ToolStripMenuItem();
            agendarToolStripMenuItem = new ToolStripMenuItem();
            agendaToolStripMenuItem = new ToolStripMenuItem();
            historiaClinicaToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip1 = new ContextMenuStrip(components);
            especialidadesToolStripMenuItem = new ToolStripMenuItem();
            obrasSocialesToolStripMenuItem = new ToolStripMenuItem();
            cerrarToolStripMenuItem = new ToolStripMenuItem();
            personaToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { inicioToolStripMenuItem, turnosToolStripMenuItem, historiaClinicaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            // 
            // inicioToolStripMenuItem
            // 
            inicioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripTextBox1, especialidadesToolStripMenuItem1, especialidadesToolStripMenuItem2, obrasSocialesToolStripMenuItem1, personaToolStripMenuItem, pacientesToolStripMenuItem, consultoriosToolStripMenuItem, toolStripSeparator1, salirToolStripMenuItem });
            inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            inicioToolStripMenuItem.Size = new Size(60, 20);
            inicioToolStripMenuItem.Text = "Archivo";
            // 
            // toolStripTextBox1
            // 
            toolStripTextBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            toolStripTextBox1.Name = "toolStripTextBox1";
            toolStripTextBox1.Size = new Size(100, 23);
            toolStripTextBox1.Text = "ABM";
            // 
            // especialidadesToolStripMenuItem1
            // 
            especialidadesToolStripMenuItem1.Name = "especialidadesToolStripMenuItem1";
            especialidadesToolStripMenuItem1.Size = new Size(160, 22);
            especialidadesToolStripMenuItem1.Text = "Profesionales";
            especialidadesToolStripMenuItem1.Click += especialidadesToolStripMenuItem1_Click;
            // 
            // especialidadesToolStripMenuItem2
            // 
            especialidadesToolStripMenuItem2.Name = "especialidadesToolStripMenuItem2";
            especialidadesToolStripMenuItem2.Size = new Size(160, 22);
            especialidadesToolStripMenuItem2.Text = "Especialidades";
            especialidadesToolStripMenuItem2.Click += especialidadesToolStripMenuItem2_Click;
            // 
            // obrasSocialesToolStripMenuItem1
            // 
            obrasSocialesToolStripMenuItem1.Name = "obrasSocialesToolStripMenuItem1";
            obrasSocialesToolStripMenuItem1.Size = new Size(160, 22);
            obrasSocialesToolStripMenuItem1.Text = "Obras Sociales";
            obrasSocialesToolStripMenuItem1.Click += obrasSocialesToolStripMenuItem1_Click;
            // 
            // pacientesToolStripMenuItem
            // 
            pacientesToolStripMenuItem.Name = "pacientesToolStripMenuItem";
            pacientesToolStripMenuItem.Size = new Size(160, 22);
            pacientesToolStripMenuItem.Text = "Pacientes";
            pacientesToolStripMenuItem.Click += pacientesToolStripMenuItem_Click;
            // 
            // consultoriosToolStripMenuItem
            // 
            consultoriosToolStripMenuItem.Name = "consultoriosToolStripMenuItem";
            consultoriosToolStripMenuItem.Size = new Size(160, 22);
            consultoriosToolStripMenuItem.Text = "Consultorios";
            consultoriosToolStripMenuItem.Click += consultoriosToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(157, 6);
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(160, 22);
            salirToolStripMenuItem.Text = "Salir";
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;
            // 
            // turnosToolStripMenuItem
            // 
            turnosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { agendarToolStripMenuItem, agendaToolStripMenuItem });
            turnosToolStripMenuItem.Name = "turnosToolStripMenuItem";
            turnosToolStripMenuItem.Size = new Size(56, 20);
            turnosToolStripMenuItem.Text = "Turnos";
            // 
            // agendarToolStripMenuItem
            // 
            agendarToolStripMenuItem.Name = "agendarToolStripMenuItem";
            agendarToolStripMenuItem.Size = new Size(146, 22);
            agendarToolStripMenuItem.Text = "Asignar turno";
            agendarToolStripMenuItem.Click += agendarToolStripMenuItem_Click;
            // 
            // agendaToolStripMenuItem
            // 
            agendaToolStripMenuItem.Name = "agendaToolStripMenuItem";
            agendaToolStripMenuItem.Size = new Size(146, 22);
            agendaToolStripMenuItem.Text = "Agenda";
            agendaToolStripMenuItem.Click += agendaToolStripMenuItem_Click;
            // 
            // historiaClinicaToolStripMenuItem
            // 
            historiaClinicaToolStripMenuItem.Name = "historiaClinicaToolStripMenuItem";
            historiaClinicaToolStripMenuItem.Size = new Size(99, 20);
            historiaClinicaToolStripMenuItem.Text = "Historia Clinica";
            historiaClinicaToolStripMenuItem.Click += historiaClinicaToolStripMenuItem_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { especialidadesToolStripMenuItem, obrasSocialesToolStripMenuItem, cerrarToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(151, 70);
            // 
            // especialidadesToolStripMenuItem
            // 
            especialidadesToolStripMenuItem.Name = "especialidadesToolStripMenuItem";
            especialidadesToolStripMenuItem.Size = new Size(150, 22);
            especialidadesToolStripMenuItem.Text = "Especialidades";
            // 
            // obrasSocialesToolStripMenuItem
            // 
            obrasSocialesToolStripMenuItem.Name = "obrasSocialesToolStripMenuItem";
            obrasSocialesToolStripMenuItem.Size = new Size(150, 22);
            obrasSocialesToolStripMenuItem.Text = "Obras Sociales";
            // 
            // cerrarToolStripMenuItem
            // 
            cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            cerrarToolStripMenuItem.Size = new Size(150, 22);
            cerrarToolStripMenuItem.Text = "Cerrar";
            // 
            // personaToolStripMenuItem
            // 
            personaToolStripMenuItem.Name = "personaToolStripMenuItem";
            personaToolStripMenuItem.Size = new Size(160, 22);
            personaToolStripMenuItem.Text = "Persona";
            personaToolStripMenuItem.Click += personaToolStripMenuItem_Click;
            // 
            // Inicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "Inicio";
            Text = "POLICONSULTORIOS";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem inicioToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem cerrarToolStripMenuItem;
        private ToolStripMenuItem especialidadesToolStripMenuItem;
        private ToolStripMenuItem obrasSocialesToolStripMenuItem;
        private ToolStripMenuItem especialidadesToolStripMenuItem1;
        private ToolStripMenuItem obrasSocialesToolStripMenuItem1;
        private ToolStripMenuItem salirToolStripMenuItem;
        private ToolStripMenuItem consultoriosToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem turnosToolStripMenuItem;
        private ToolStripTextBox toolStripTextBox1;
        private ToolStripMenuItem pacientesToolStripMenuItem;
        private ToolStripMenuItem agendarToolStripMenuItem;
        private ToolStripMenuItem historiaClinicaToolStripMenuItem;
        private ToolStripMenuItem especialidadesToolStripMenuItem2;
        private ToolStripMenuItem agendaToolStripMenuItem;
        private ToolStripMenuItem personaToolStripMenuItem;
    }
}
