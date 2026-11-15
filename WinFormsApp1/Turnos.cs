using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BE;
using BLL;

namespace UI
{
    public partial class Turnos : Form
    {
        private TurnoBLL turnoBll = new TurnoBLL();
        private PacienteBLL pacienteBll = new PacienteBLL();
        private ProfesionalBLL profesionalBll = new ProfesionalBLL();
        private ConsultorioBLL consultorioBll = new ConsultorioBLL();

        private BE.Turno? turnoSeleccionado = null;
        private bool cargando = false;

        public Turnos()
        {
            InitializeComponent();

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;

            dateTimePicker1.Format = DateTimePickerFormat.Short;

            Load += Turnos_Load;

            comboBox1.SelectedIndexChanged += CambioSeleccion;
            comboBox2.SelectedIndexChanged += CambioSeleccion;
            comboBox3.SelectedIndexChanged += CambioSeleccion;
            dateTimePicker1.ValueChanged += CambioSeleccion;

            ConfigurarDataGrid();
        }

        private void Turnos_Load(object? sender, EventArgs e)
        {
            cargando = true;
            CargarCombos();
            cargando = false;

            MostrarTurnos();
            ModoNuevo();
        }

        private void ConfigurarDataGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Paciente", HeaderText = "Paciente" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Profesional", HeaderText = "Profesional" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Consultorio", HeaderText = "Consultorio" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FechaHora", HeaderText = "Fecha y Hora" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Estado", HeaderText = "Estado" });

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.CellClick += ElementoSeleccionado;
        }

        private void CargarCombos()
        {
            try
            {
                comboBox1.DisplayMember = "NombreCompleto";
                comboBox1.ValueMember = "IdPaciente";
                comboBox1.DataSource = pacienteBll.ObtenerPacientes();
                comboBox1.SelectedIndex = -1;

                comboBox2.DisplayMember = "NombreCompleto";
                comboBox2.ValueMember = "IdProfesional";
                comboBox2.DataSource = profesionalBll.ObtenerProfesionales();
                comboBox2.SelectedIndex = -1;

                comboBox3.DisplayMember = "Descripcion";
                comboBox3.ValueMember = "Id";
                comboBox3.DataSource = consultorioBll.ObtenerConsultorios();
                comboBox3.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);

            }
        }

        private void CambioSeleccion(object? sender, EventArgs e)
        {
            if (cargando)
            {
                return;
            }

            CargarHorarios();
        }

        private void CargarHorarios()
        {
            string? elegido = comboBox4.SelectedItem?.ToString();

            List<string> ocupados = new List<string>();

            if (comboBox2.SelectedItem != null && comboBox3.SelectedItem != null)
            {
                int idPaciente = 0;

                if (comboBox1.SelectedItem != null)
                {
                    idPaciente = ((BE.Paciente)comboBox1.SelectedItem).IdPaciente;
                }

                int idProfesional = ((BE.Profesional)comboBox2.SelectedItem).IdProfesional;
                int idConsultorio = ((BE.Consultorio)comboBox3.SelectedItem).Id;
                int idTurnoExcluido = turnoSeleccionado != null ? turnoSeleccionado.Id : 0;

                try
                {
                    ocupados = turnoBll.ObtenerHorariosOcupados(idProfesional, idConsultorio, idPaciente, dateTimePicker1.Value, idTurnoExcluido);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los horarios: " + ex.Message);
                }
            }

            comboBox4.Items.Clear();

            // horarios de 8 a 20 cada media hora
            for (int hora = 8; hora <= 20; hora++)
            {
                string horario = hora.ToString("00") + ":00";

                if (!ocupados.Contains(horario))
                {
                    comboBox4.Items.Add(horario);
                }

                if (hora < 20)
                {
                    horario = hora.ToString("00") + ":30";

                    if (!ocupados.Contains(horario))
                    {
                        comboBox4.Items.Add(horario);
                    }
                }
            }

            if (elegido != null && comboBox4.Items.Contains(elegido))
            {
                comboBox4.SelectedItem = elegido;
            }
            else
            {
                comboBox4.SelectedIndex = -1;
            }
        }

        private void MostrarTurnos()
        {
            try
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = turnoBll.ObtenerTurnos();
                LimpiarSeleccion();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los turnos: " + ex.Message);

            }
        }

        private void LimpiarSeleccion()
        {
            dataGridView1.CurrentCell = null;
            dataGridView1.ClearSelection();
        }

        private void ModoNuevo()
        {
            LimpiarSeleccion();
            turnoSeleccionado = null;

            cargando = true;
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            dateTimePicker1.Value = DateTime.Today;
            cargando = false;

            CargarHorarios();
        }

        private void ElementoSeleccionado(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dataGridView1.CurrentRow == null)
            {
                return;
            }

            turnoSeleccionado = dataGridView1.CurrentRow.DataBoundItem as BE.Turno;

            if (turnoSeleccionado == null)
            {
                return;
            }


            // carga los controles
            cargando = true;

            if (turnoSeleccionado.Paciente != null)
            {
                comboBox1.SelectedValue = turnoSeleccionado.Paciente.IdPaciente;
            }

            if (turnoSeleccionado.Profesional != null)
            {
                comboBox2.SelectedValue = turnoSeleccionado.Profesional.IdProfesional;
            }

            if (turnoSeleccionado.Consultorio != null)
            {
                comboBox3.SelectedValue = turnoSeleccionado.Consultorio.Id;
            }

            dateTimePicker1.Value = turnoSeleccionado.FechaHora.Date;

            cargando = false;

            CargarHorarios();
            comboBox4.SelectedItem = turnoSeleccionado.FechaHora.ToString("HH:mm");
        }
        //nuevo
        private void button1_Click(object? sender, EventArgs e)
        {
            try
            {

                ModoNuevo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //boton guardar
        private void button2_Click(object? sender, EventArgs e)
        {

            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un paciente.");
                return;
            }


            if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un profesional.");
                return;
            }

            if (comboBox3.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un consultorio.");
                return;
            }


            if (comboBox4.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un horario.");
                return;
            }

            BE.Paciente paciente = (BE.Paciente)comboBox1.SelectedItem;
            BE.Profesional profesional = (BE.Profesional)comboBox2.SelectedItem;

            BE.Consultorio consultorio = (BE.Consultorio)comboBox3.SelectedItem;

            TimeSpan horaSeleccionada = TimeSpan.Parse(comboBox4.SelectedItem.ToString()!);
            DateTime fechaHora = dateTimePicker1.Value.Date + horaSeleccionada;

            try
            {
                if (turnoSeleccionado == null)
                {
                    BE.Turno nuevo = new BE.Turno(0, paciente, profesional, consultorio, fechaHora, EstadoTurno.Pendiente);
                    turnoBll.AgregarTurno(nuevo);

                    MessageBox.Show("Turno agendado correctamente.");
                }
                else
                {
                    BE.Turno modificado = new BE.Turno(turnoSeleccionado.Id, paciente, profesional, consultorio, fechaHora, turnoSeleccionado.Estado);
                    turnoBll.ModificarTurno(modificado);
                    MessageBox.Show("Turno modificado correctamente.");

                }

                MostrarTurnos();
                ModoNuevo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        //boton cancelar
        private void button3_Click(object? sender, EventArgs e)
        {
            if (turnoSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un turno de la grilla para cancelar.");

                return;
            }

            

            try
            {
                turnoBll.CancelarTurno(turnoSeleccionado.Id);
                MessageBox.Show("Turno cancelado correctamente.");
                MostrarTurnos();
                ModoNuevo();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
    }
}
