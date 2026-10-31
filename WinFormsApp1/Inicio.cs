using UI;

namespace WinFormsApp1
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form formulario = new ObraSocial();

            formulario.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form formulario = new Especialidad();

            formulario.Show();
        }
    }
}
