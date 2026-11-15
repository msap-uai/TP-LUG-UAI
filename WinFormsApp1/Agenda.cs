using System;
using System.Windows.Forms;
using BE;
using BLL;

namespace UI
{
    public partial class Agenda : Form
    {
        private TurnoBLL turnoBll = new TurnoBLL();
        private ConsultorioBLL consultorioBll = new ConsultorioBLL();
        private bool cargando = false;

        public Agenda()
        {
            InitializeComponent();

            ConfigurarDataGrid();

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            checkBox1.CheckedChanged += CambioFiltro;
            dateTimePicker1.ValueChanged += CambioFiltro;
            comboBox1.SelectedIndexChanged += CambioFiltro;
        }

        private void Agenda_Load(object sender, EventArgs e)
        {
            CargarConsultorios();
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
                DateTime? fecha = null;

                if (checkBox1.Checked)
                {
                    fecha = dateTimePicker1.Value.Date;
                }

                int? idConsultorio = null;

                if (comboBox1.SelectedItem != null)
                {
                    idConsultorio = ((BE.Consultorio)comboBox1.SelectedItem).Id;
                }

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = turnoBll.ObtenerTurnosFiltrados(fecha, idConsultorio);

                dataGridView1.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la agenda: " + ex.Message);

            }
        }

        private void CargarConsultorios()
        {
            cargando = true;

            try
            {
                comboBox1.DisplayMember = "Descripcion";
                comboBox1.DataSource = consultorioBll.ObtenerConsultorios();
                comboBox1.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los consultorios: " + ex.Message);
            }

            cargando = false;
        }

        private void CambioFiltro(object? sender, EventArgs e)
        {
            if (cargando)
            {
                return;
            }

            dateTimePicker1.Enabled = checkBox1.Checked;
            CargarTurnos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // boton limpiar filtros
            cargando = true;
            checkBox1.Checked = false;
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker1.Enabled = false;
            comboBox1.SelectedIndex = -1;
            cargando = false;

            CargarTurnos();
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
