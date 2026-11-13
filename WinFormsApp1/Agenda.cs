using System;
using System.Windows.Forms;
using BE;
using BLL;

namespace UI
{
    public partial class Agenda : Form
    {
        private TurnoBLL turnoBll = new TurnoBLL();

        public Agenda()
        {
            InitializeComponent();

            ConfigurarDataGrid();
        }

        private void Agenda_Load(object sender, EventArgs e)
        {
            CargarTurnos();

        }

        private void ConfigurarDataGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Paciente", HeaderText = "Paciente" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Profesional", HeaderText = "Profesional" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Consultorio", HeaderText = "Consultorio" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FechaHora", HeaderText = "Fecha y Hora" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Estado", HeaderText = "Estado" });

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

        }

        private void CargarTurnos()
        {
            try
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = turnoBll.ObtenerTurnos();

                dataGridView1.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la agenda: " + ex.Message);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // boton cancelar turno
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un turno para cancelar.");

                return;
            }

            BE.Turno? turno = dataGridView1.CurrentRow.DataBoundItem as BE.Turno;

            if (turno == null)
            {
                return;
            }

       

            try
            {
                turnoBll.CancelarTurno(turno.Id);
                MessageBox.Show("Turno cancelado correctamente.");
                CargarTurnos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
