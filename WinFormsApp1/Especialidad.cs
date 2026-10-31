using BLL;

namespace UI
{
    public partial class Especialidad : MiForm
    {
        private BE.Especialidad? instancia = null;
        private int? id = null;

        public Especialidad()
        {
            InitializeComponent();

            Shown += Inicio;
            FormClosing += Cierre;

            ConfigurarDataGrid();

            MostrarEspecialidades();
        }

        private void Inicio(object? sender, EventArgs e)
        {
            ModoNuevoRegistro();
        }

        protected void ModoNuevoRegistro()
        {
            LimpiarSeleccion();

            textBox1.Text = string.Empty;
            instancia = null;
            id = null;
        }

        private void LimpiarSeleccion()
        {
            dataGridView1.CurrentCell = null;
            dataGridView1.ClearSelection();
        }

        private void ElementoSeleccionado(object? sender, EventArgs e)
        {
            if (sender == null)
            {
                return;
            }

            DataGridView grid = (sender as DataGridView)!;

            if (grid.SelectedRows.Count == 0)
            {
                return;
            }

            BE.Especialidad especialidad = (BE.Especialidad)grid.CurrentRow!.DataBoundItem;

            if (HayCambios())
            {
                if (!ConfirmarCambios())
                {
                    if (id is null)
                    {
                        textBox1.Focus();

                        grid.CurrentCell = null;
                    }
                    else
                    {
                        List<BE.Especialidad> lista = (List<BE.Especialidad>)grid.DataSource;

                        int indice = lista.IndexOf(instancia!);

                        grid.CurrentCell = grid.Rows[indice].Cells[0];
                    }

                    return;
                }
            }

            instancia = especialidad;
            id = instancia.Id;

            textBox1.Text = instancia.Descripcion;
        }

        protected static bool ConfirmarCambios()
        {
            var confirma = MessageBox.Show("Hay cambios sin guardar. Desea continuar y perder los cambios?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirma == DialogResult.No)
            {
                return false;
            }

            return true;
        }

        protected bool HayCambios()
        {
            if (id is null)
            {
                if (textBox1.Text != string.Empty)
                {
                    return true;
                }
                    
                return false;
            }

            if (textBox1.Text != instancia!.Descripcion)
            {
                return true;
            }

            return false;
        }

        private void ConfigurarDataGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            DataGridViewTextBoxColumn columnaNombre = new DataGridViewTextBoxColumn();
            columnaNombre.DataPropertyName = "Descripcion";
            columnaNombre.HeaderText = "Especialidad";
            columnaNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.Columns.Add(columnaNombre);

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.CellClick += ElementoSeleccionado;
        }

        private void MostrarEspecialidades()
        {
            dataGridView1.DataSource = BLL.EspecialidadBLL.ObtenerEspecialidades();
            dataGridView1.CurrentCell = null;
            dataGridView1.ClearSelection();

            textBox1.Text = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!HayCambios())
            {
                MessageBox.Show("No hay cambios para guardar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                return;
            }

            try
            {
                BLL.EspecialidadBLL.GuardarEspecialidad(id, textBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la especialidad: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return;
            }

            MostrarEspecialidades();

            ModoNuevoRegistro();

            MessageBox.Show("Especialidad guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (id is null)
            {
                MessageBox.Show("Debe seleccionar una especialidad para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            var confirma = MessageBox.Show("¿Está seguro que desea eliminar la especialidad seleccionada?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            
            if (confirma == DialogResult.No)
            {
                return;
            }

            try
            {
                BLL.EspecialidadBLL.EliminarEspecialidad(id.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la especialidad: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            MostrarEspecialidades();

            ModoNuevoRegistro();

            MessageBox.Show("Especialidad eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
