using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class ObraSocial : Form
    {
        public ObraSocial()
        {
            InitializeComponent();

            Shown += ObraSocial_Shown;

            ConfigurarDataGrid();

            MostrarObrasSociales();
        }

        private void ObraSocial_Shown(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell = null;
            dataGridView1.ClearSelection();
        }

        private void ConfigurarDataGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            DataGridViewTextBoxColumn columnaNombre = new DataGridViewTextBoxColumn();
            columnaNombre.DataPropertyName = "Nombre";
            columnaNombre.HeaderText = "Obra social";
            columnaNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.Columns.Add(columnaNombre);
        }

        private void MostrarObrasSociales()
        {
            dataGridView1.DataSource = BLL.ObraSocialBLL.ObtenerObrasSociales();
            dataGridView1.CurrentCell = null;
            dataGridView1.ClearSelection();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
