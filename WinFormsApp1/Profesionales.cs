using BE;
using BLL;

namespace UI
{
    public partial class Profesionales : Form
    {
        private BE.Profesional? instancia = null;
        private int? idProfesional = null;
        private ProfesionalBLL profesionalBll = new ProfesionalBLL();

        public Profesionales()
        {
            InitializeComponent();
            ConfigurarDataGrid();
            CargarEspecialidades();
            MostrarProfesionales();
            ModoNuevoRegistro();
        }


        private void ConfigurarDataGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Apellido", HeaderText = "Apellido" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nombre", HeaderText = "Nombre" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Dni", HeaderText = "DNI" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Matricula", HeaderText = "Matrícula" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Especialidad", HeaderText = "Especialidad" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Arancel", HeaderText = "Arancel" });

            dataGridView1.CellClick += ElementoSeleccionado;
        }

        private void CargarEspecialidades()
        {
            try
            {
                comboBox1.DataSource = EspecialidadBLL.ObtenerEspecialidades();
                comboBox1.DisplayMember = "Descripcion";
                comboBox1.ValueMember = "Id";
                comboBox1.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las especialidades: {ex.Message}");
            }
        }

        private void CargarPersonas(BE.Persona? persona)
        {
            try
            {
                List<BE.Persona> personas = PersonaBLL.ObtenerPersonasNoProfesionales();

                if (persona != null)
                {
                    personas.Insert(0, persona);
                }

                comboBoxPersona.DataSource = personas;

                if (persona != null)
                {
                    comboBoxPersona.SelectedIndex = 0;
                }
                else
                {
                    comboBoxPersona.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las personas: {ex.Message}");
            }
        }

        private void MostrarProfesionales()
        {
            try
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = profesionalBll.ObtenerProfesionales();
                LimpiarSeleccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la lista de profesionales: {ex.Message}");
            }
        }

        private void ModoNuevoRegistro()
        {
            LimpiarSeleccion();

            CargarPersonas(null);
            comboBoxPersona.Enabled = true;
            textBox1.Clear();  // matrícula
            comboBox1.SelectedIndex = -1;  // especialidad
            textBox2.Clear();  // arancel

            instancia = null;
            idProfesional = null;
        }

        private void LimpiarSeleccion()
        {
            dataGridView1.CurrentCell = null;
            dataGridView1.ClearSelection();
        }

        private void ElementoSeleccionado(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dataGridView1.CurrentRow == null)
            {
                return;
            }

            BE.Profesional profesional = (Profesional)dataGridView1.CurrentRow.DataBoundItem;

            instancia = profesional;
            idProfesional = profesional.IdProfesional;

            CargarPersonas(profesional);
            comboBoxPersona.Enabled = false;
            textBox1.Text = profesional.Matricula;

            if (profesional.Especialidad != null)
            {
                comboBox1.SelectedValue = profesional.Especialidad.Id;
            }
            else
            {
                comboBox1.SelectedIndex = -1;
            }

            textBox2.Text = profesional.Arancel.ToString();
        }

        private void button1_Click(object? sender, EventArgs e)
        {
            try
            {
                ModoNuevoRegistro();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object? sender, EventArgs e)
        {
            string matricula = textBox1.Text;

            if (comboBoxPersona.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una persona.");
                return;
            }

            BE.Persona persona = (BE.Persona)comboBoxPersona.SelectedItem;
                       
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("debe seleccionar una especialidad.");
                return;
            }

            BE.Especialidad especialidad = (BE.Especialidad)comboBox1.SelectedItem;

            if (!decimal.TryParse(textBox2.Text, out decimal arancel))
            {
                MessageBox.Show("debe ingresar un arancel numerico valido");
                return;
            }

            try
            {
                int profesionalId = idProfesional ?? 0;

                Profesional profesional = new Profesional(
                    persona.Id,
                    profesionalId,
                    persona.Nombre,
                    persona.Apellido,
                    persona.Dni,
                    persona.Telefono,
                    persona.Mail,
                    matricula,
                    especialidad,
                    arancel
                );

                profesionalBll.GuardarProfesional(profesional);

                MostrarProfesionales();
                ModoNuevoRegistro();

                MessageBox.Show("Profesional guardado correctamente");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object? sender, EventArgs e)
        {
            if (idProfesional == null)
            {
                MessageBox.Show("debe seleccionar un profesional de la grilla para eliminar.");

                return;
            }

            try
            {
                profesionalBll.EliminarProfesional(idProfesional.Value);

                MostrarProfesionales();
                ModoNuevoRegistro();

                MessageBox.Show("profesional eliminado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
