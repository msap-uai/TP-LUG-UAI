using UI;

namespace WinFormsApp1
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }




 

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void especialidadesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirVista(new Especialidad());
        }

        private void obrasSocialesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirVista(new ObraSocial());
        }
        private void AbrirVista(Form formularioNuevo)
        {
            // Si ya hay abierta cierra
            if (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Close();
            }

            // Configuracion del formulario
            formularioNuevo.MdiParent = this;
            formularioNuevo.FormBorderStyle = FormBorderStyle.None; // quita bordes
            formularioNuevo.Dock = DockStyle.Fill;                  // ocupa todo el espacio

            
            formularioNuevo.Show();
        }
    }
}
