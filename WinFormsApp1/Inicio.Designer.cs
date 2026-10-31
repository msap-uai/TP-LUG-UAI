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
            especialidadesToolStripMenuItem1 = new ToolStripMenuItem();
            obrasSocialesToolStripMenuItem1 = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip1 = new ContextMenuStrip(components);
            especialidadesToolStripMenuItem = new ToolStripMenuItem();
            obrasSocialesToolStripMenuItem = new ToolStripMenuItem();
            cerrarToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { inicioToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            // 
            // inicioToolStripMenuItem
            // 
            inicioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { especialidadesToolStripMenuItem1, obrasSocialesToolStripMenuItem1, salirToolStripMenuItem });
            inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            inicioToolStripMenuItem.Size = new Size(48, 20);
            inicioToolStripMenuItem.Text = "Inicio";
            // 
            // especialidadesToolStripMenuItem1
            // 
            especialidadesToolStripMenuItem1.Name = "especialidadesToolStripMenuItem1";
            especialidadesToolStripMenuItem1.Size = new Size(180, 22);
            especialidadesToolStripMenuItem1.Text = "Especialidades";
            especialidadesToolStripMenuItem1.Click += especialidadesToolStripMenuItem1_Click;
            // 
            // obrasSocialesToolStripMenuItem1
            // 
            obrasSocialesToolStripMenuItem1.Name = "obrasSocialesToolStripMenuItem1";
            obrasSocialesToolStripMenuItem1.Size = new Size(180, 22);
            obrasSocialesToolStripMenuItem1.Text = "Obras Sociales";
            obrasSocialesToolStripMenuItem1.Click += obrasSocialesToolStripMenuItem1_Click;
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(180, 22);
            salirToolStripMenuItem.Text = "Salir";
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;
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
    }
}
