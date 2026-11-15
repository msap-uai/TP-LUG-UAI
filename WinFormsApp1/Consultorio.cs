using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BE;
using BLL;

namespace UI
{
    public partial class Consultorio : Form
    {
        private ConsultorioBLL consultorioBll = new ConsultorioBLL();
        private int? idConsultorio = null;

        public Consultorio()
        {
            InitializeComponent();
            ConfigurarDataGrid();
        }

        private void Consultorio_Load(object sender, EventArgs e)
        {
            MostrarConsultorios();
            LimpiarCampos();
        }

        private void ConfigurarDataGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            DataGridViewTextBoxColumn colNumero = new DataGridViewTextBoxColumn();
            colNumero.DataPropertyName = "Numero";
            colNumero.HeaderText = "Número de Consultorio";
            colNumero.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns.Add(colNumero);

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.CellClick += ElementoSeleccionado;
        }

        private void MostrarConsultorios()
        {
            try
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = consultorioBll.ObtenerConsultorios();
                LimpiarSeleccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message);
            }
        }

        private void LimpiarSeleccion()
        {
            dataGridView1.CurrentCell = null;
            dataGridView1.ClearSelection();
        }

        private void LimpiarCampos()
        {
            textBox1.Clear();
            idConsultorio = null;
            LimpiarSeleccion();
        }

        private void ElementoSeleccionado(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dataGridView1.CurrentRow == null)
            {
                return;
            }

            BE.Consultorio consultorio = (BE.Consultorio)dataGridView1.CurrentRow.DataBoundItem;

            if (consultorio != null)
            {
                idConsultorio = consultorio.Id;
                textBox1.Text = consultorio.Numero.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Botón Agregar
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Debe ingresar el numero de consultorio.");
                return;
            }

            if (!int.TryParse(textBox1.Text, out int numero))
            {
                MessageBox.Show("Debe ingresar un numero.");
                return;
            }

            try
            {
                BE.Consultorio nuevo = new BE.Consultorio(0, numero);

                consultorioBll.AgregarConsultorio(nuevo);

                MessageBox.Show("Consultorio agregado correctamente.");

                MostrarConsultorios();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Botón Modificar
            if (idConsultorio == null)
            {
                MessageBox.Show("Debe seleccionar un consultorio de la grilla para modificar.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Debe ingresar el numero de consultorio.");
                return;
            }

            if (!int.TryParse(textBox1.Text, out int numero))
            {
                MessageBox.Show("El numero de consultorio debe ser un valor numerico.");
                return;
            }

            try
            {
                BE.Consultorio consultorio = new BE.Consultorio(idConsultorio.Value, numero);

                consultorioBll.ModificarConsultorio(consultorio);

                MessageBox.Show("Consultorio modificado correctamente.");

                MostrarConsultorios();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Botón Eliminar
            if (idConsultorio == null)
            {
                MessageBox.Show("Debe seleccionar un consultorio de la grilla para eliminar.");
                return;
            }
                     

            try
            {
                consultorioBll.EliminarConsultorio(idConsultorio.Value);

                MessageBox.Show("Consultorio eliminado correctamente.");

                MostrarConsultorios();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
