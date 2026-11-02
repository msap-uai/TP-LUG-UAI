using UI;

namespace WinFormsApp1
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }
        //cierra el programa
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //abre formularios
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

        private void especialidadesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirVista(new Profesionales());
        }

        private void obrasSocialesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirVista(new ObraSocial());
        }
        private void especialidadesToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AbrirVista(new Especialidad());
        }

        private void pacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirVista(new Pacientes());
        }

        private void consultoriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirVista(new Consultorio());
        }

        private void agendarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirVista(new Turnos());
        }

        private void agendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirVista(new Agenda());
        }

        private void historiaClinicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirVista(new HistoriaClinica());
        }
    }
}
