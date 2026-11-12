using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;
using DAL;

namespace UI
{
    public partial class HistoriaClinica : Form
    {
        private Paciente? pacienteActual = null;
        private PacienteBLL pacienteBll = new PacienteBLL();
        private TurnoBLL turnoBll = new TurnoBLL();
        private ConsultaEvolucionBLL consultaBll = new ConsultaEvolucionBLL();

        public HistoriaClinica()
        {
            InitializeComponent();

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ConfigurarGrillas();

        }

        public void ConfigurarGrillas()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FechaHora", HeaderText = "Fecha" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Estado", HeaderText = "Estado" });

            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.Columns.Clear();
            dataGridView2.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FechaAtencion", HeaderText = "Fecha" });
            dataGridView2.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Diagnostico", HeaderText = "Diagnostico" });
            dataGridView2.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MontoCobrado", HeaderText = "Monto" });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //guardar consulta
            Turno turno = null;

            if (dataGridView1.CurrentRow != null)
            {
                turno = dataGridView1.CurrentRow.DataBoundItem as Turno;
            }
            if (turno == null)
            {
                MessageBox.Show("Seleccione el turno que desea atender");
                return;
            }

            if (turno.Estado != EstadoTurno.Pendiente)
            {
                MessageBox.Show("Solo se pueden atender turnos pendientes.");
                return;
            }

            string evolucionTexto = textBox1.Text.Trim();
            if (string.IsNullOrWhiteSpace(evolucionTexto))
            {
                MessageBox.Show("Debe ingresar la evolucion / diagnóstico");
                return;
            }

            try
            {
                ConsultaEvolucion consulta = new ConsultaEvolucion
                {
                    Turno = turno,
                    FechaAtencion = DateTime.Now, 
                    Diagnostico = evolucionTexto,
                    Observaciones = "Atención realizada el " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                    MontoCobrado = turno.Profesional != null ? turno.Profesional.Arancel : 0
                };

                consultaBll.RegistrarAtencion(consulta);
                MessageBox.Show("Consulta finalizada");
                textBox1.Clear();
                CargarDatosPaciente();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar atencion: " + ex.Message);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //buscar paciente
            string dni = textBox2.Text;
            if (string.IsNullOrWhiteSpace(dni))
            {
                MessageBox.Show("Ingrese el DNI para buscar.");
                return;
            }
            var pacientes = pacienteBll.ObtenerPacientes();
            pacienteActual = null;
            foreach (var p in pacientes)
            {
                if (p.Dni == dni)
                {
                    pacienteActual = p;
                    break;
                }
            }

            if (pacienteActual == null)
            {
                MessageBox.Show("No se encontro ningun");
                dataGridView1.DataSource = null;
                dataGridView2.DataSource = null;
                return;
            }

            CargarDatosPaciente();
        }
        private void CargarDatosPaciente()
        {
            if (pacienteActual == null) return;

            var todosTurnos = turnoBll.ObtenerTurnos();
            List<Turno> turnosPaciente = new List<Turno>();
            foreach (var t in todosTurnos)
            {
                if (t.Paciente != null && t.Paciente.IdPaciente == pacienteActual.IdPaciente)
                {
                    turnosPaciente.Add(t);
                }
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = turnosPaciente;

            var todasConsultas = consultaBll.ObtenerConsultas();
            List<ConsultaEvolucion> consultasPaciente = new List<ConsultaEvolucion>();
            foreach (var c in todasConsultas)
            {
                if (c.Turno != null && c.Turno.Paciente != null && c.Turno.Paciente.IdPaciente == pacienteActual.IdPaciente)
                {
                    consultasPaciente.Add(c);
                }
            }

            dataGridView2.DataSource = null;
            dataGridView2.DataSource = consultasPaciente;
        }

    }
}
