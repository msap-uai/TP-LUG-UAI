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

namespace UI
{
    public partial class Profesionales : Form
    {
        private BE.Profesional? instancia = null;
        private int? idProfesional = null;
        private int? idPersona = null;
        private ProfesionalBLL profesionalBll = new ProfesionalBLL();

        public Profesionales()
        {
            InitializeComponent();
            ConfigurarDataGrid();
        }
        private void Profesionales_Load(object sender, EventArgs e)
        {
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
                MessageBox.Show("Error al cargar las especialidades");
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
                MessageBox.Show("Error al cargar la lista de profesionales");
            }
        }

        private void ModoNuevoRegistro()
        {
            LimpiarSeleccion();

            textBox10.Clear(); // nombre
            textBox9.Clear();  // apellido
            textBox8.Clear();  // DNI
            textBox7.Clear();  // telefono
            textBox6.Clear();  // mail
            textBox1.Clear();  // matrícula
            comboBox1.SelectedIndex = -1;  // especialidad
            textBox2.Clear();  // arancel

            instancia = null;
            idProfesional = null;
            idPersona = null;
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

            BE.Profesional profesional = (BE.Profesional)dataGridView1.CurrentRow.DataBoundItem;

            instancia = profesional;
            idProfesional = profesional.IdProfesional;
            idPersona = profesional.Id;

            textBox10.Text = profesional.Nombre;
            textBox9.Text = profesional.Apellido;
            textBox8.Text = profesional.Dni;
            textBox7.Text = profesional.Telefono;
            textBox6.Text = profesional.Mail;
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
        //BOTONES
        private void button1_Click(object? sender, EventArgs e)
        {
            //Nuevo
            ModoNuevoRegistro();
        }

        private void button2_Click(object? sender, EventArgs e)
        {
            // Guardar
            string nombre = textBox10.Text;
            string apellido = textBox9.Text;
            string dni = textBox8.Text;
            string telefono = textBox7.Text;
            string mail = textBox6.Text;
            string matricula = textBox1.Text;

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) || string.IsNullOrWhiteSpace(dni))
            {
                MessageBox.Show("Debe completar Nombre, Apellido y DNI.");
                return;
            }

            if (string.IsNullOrWhiteSpace(matricula))
            {
                MessageBox.Show("debe ingresar la matricula del profesional.");
                return;
            }

            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("debe seleccionar una especialidad.");
                return;
            }

            BE.Especialidad especialidad = (BE.Especialidad)comboBox1.SelectedItem;

            if (!decimal.TryParse(textBox2.Text, out decimal arancel) || arancel <= 0)
            {
                MessageBox.Show("debe ingresar un arancel valido mayor a cero");
                return;
            }

            try
            {
                int personaId = idPersona ?? 0;
                int profesionalId = idProfesional ?? 0;

                Profesional profesional = new Profesional(
                    personaId,
                    profesionalId,
                    nombre,
                    apellido,
                    dni,
                    telefono,
                    mail,
                    matricula,
                    especialidad,
                    arancel
                );

                profesionalBll.GuardarProfesional(profesional);

                MessageBox.Show("Profesional guardado correctamente");

                MostrarProfesionales();
                ModoNuevoRegistro();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object? sender, EventArgs e)
        {
            // Botón Eliminar
            if (idProfesional == null)
            {
                MessageBox.Show("debe seleccionar un profesional de la grilla para eliminar.");
                return;
            }

            try
            {
                profesionalBll.EliminarProfesional(idProfesional.Value);

                MessageBox.Show("profesional eliminado");

                MostrarProfesionales();
                ModoNuevoRegistro();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
