using BLL;

namespace UI
{
    public partial class ObraSocial : Form
    {
        private BE.ObraSocial? instancia = null;
        private ObraSocialBLL obraSocialBll = new ObraSocialBLL();
        private int? id = null;

        public ObraSocial()
        {
            InitializeComponent();

            Shown += Inicio;
            FormClosing += Cierre;

            ConfigurarDataGrid();

            MostrarObrasSociales();
        }

        private void Inicio(object? sender, EventArgs e)
        {
            ModoNuevoRegistro();
        }

        private void ModoNuevoRegistro()
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

            BE.ObraSocial obraSocial = (BE.ObraSocial)grid.CurrentRow!.DataBoundItem;

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
                        List<BE.ObraSocial> lista = (List<BE.ObraSocial>)grid.DataSource;

                        int indice = lista.IndexOf(instancia!);

                        grid.CurrentCell = grid.Rows[indice].Cells[0];
                    }

                    return;
                }
            }

            instancia = obraSocial;
            id = instancia.Id;

            textBox1.Text = instancia.Nombre;
        }

        private static bool ConfirmarCambios()
        {
            var confirma = MessageBox.Show("Hay cambios sin guardar. Desea continuar y perder los cambios?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirma == DialogResult.No)
            {
                return false;
            }

            return true;
        }

        private bool HayCambios()
        {
            if (id is null)
            {
                if (textBox1.Text != string.Empty)
                {
                    return true;
                }
                    
                return false;
            }

            if (textBox1.Text != instancia!.Nombre)
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
            columnaNombre.DataPropertyName = "Nombre";
            columnaNombre.HeaderText = "Obra social";
            columnaNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.Columns.Add(columnaNombre);

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.CellClick += ElementoSeleccionado;
        }

        private void MostrarObrasSociales()
        {
            try
            {
                dataGridView1.DataSource = obraSocialBll.ObtenerObrasSociales();
                dataGridView1.CurrentCell = null;
                dataGridView1.ClearSelection();

                textBox1.Text = string.Empty;
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error al cargar las obras sociales: " + ex.Message,"Error" ,MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Cierre(object? sender, FormClosingEventArgs e)
        {
            if (HayCambios())
            {
                if (!ConfirmarCambios())
                {
                    e.Cancel = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (HayCambios())
            {
                if (!ConfirmarCambios())
                {
                    return;
                }
            }

            ModoNuevoRegistro();
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
                obraSocialBll.GuardarObraSocial(id, textBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la obra social: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return;
            }

            MostrarObrasSociales();

            ModoNuevoRegistro();

            MessageBox.Show("Obra social guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (id is null)
            {
                MessageBox.Show("Debe seleccionar una obra social para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            var confirma = MessageBox.Show("¿Está seguro que desea eliminar la obra social seleccionada?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            
            if (confirma == DialogResult.No)
            {
                return;
            }

            try
            {
                obraSocialBll.EliminarObraSocial(id.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la obra social: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            MostrarObrasSociales();

            ModoNuevoRegistro();

            MessageBox.Show("Obra social eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
