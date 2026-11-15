namespace UI
{
    public partial class Persona : Form
    {
        private BE.Persona? instancia = null;
        private int? id = null;

        public Persona()
        {
            InitializeComponent();

            Shown += Inicio;
            FormClosing += Cierre;

            ConfigurarDataGrid();

            MostrarPersonas();
        }

        private void Inicio(object? sender, EventArgs e)
        {
            ModoNuevoRegistro();
        }

        private void ModoNuevoRegistro()
        {
            LimpiarSeleccion();

            textBoxNombre.Text = string.Empty;
            textBoxApellido.Text = string.Empty;
            textBoxDni.Text = string.Empty;
            textBoxTelefono.Text = string.Empty;
            textBoxMail.Text = string.Empty;
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

            BE.Persona persona = (BE.Persona)grid.CurrentRow!.DataBoundItem;

            if (HayCambios())
            {
                if (!ConfirmarCambios())
                {
                    if (id is null)
                    {
                        textBoxNombre.Focus();

                        grid.CurrentCell = null;
                    }
                    else
                    {
                        List<BE.Persona> lista = (List<BE.Persona>)grid.DataSource;

                        int indice = lista.IndexOf(instancia!);

                        grid.CurrentCell = grid.Rows[indice].Cells[0];
                    }

                    return;
                }
            }

            instancia = persona;
            id = instancia.Id;

            textBoxNombre.Text = instancia.Nombre;
            textBoxApellido.Text = instancia.Apellido;
            textBoxDni.Text = instancia.Dni;
            textBoxTelefono.Text = instancia.Telefono;
            textBoxMail.Text = instancia.Mail;
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

        private static string NormalizarDni(string dni)
        {
            return dni.Replace(".", "").Replace(" ", "");
        }

        private bool HayCambios()
        {
            if (id is null)
            {
                if (textBoxNombre.Text != string.Empty
                    || textBoxApellido.Text != string.Empty
                    || textBoxDni.Text != string.Empty
                    || textBoxTelefono.Text != string.Empty
                    || textBoxMail.Text != string.Empty)
                {
                    return true;
                }

                return false;
            }

            if (textBoxNombre.Text.Trim() != instancia!.Nombre)
            {
                return true;
            }

            if (textBoxApellido.Text.Trim() != instancia.Apellido)
            {
                return true;
            }

            if (NormalizarDni(textBoxDni.Text.Trim()) != instancia.Dni)
            {
                return true;
            }

            if (textBoxTelefono.Text.Trim() != instancia.Telefono)
            {
                return true;
            }

            if (textBoxMail.Text.Trim() != instancia.Mail)
            {
                return true;
            }

            return false;
        }

        private void ConfigurarDataGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            DataGridViewTextBoxColumn columnaApellido = new DataGridViewTextBoxColumn();
            columnaApellido.DataPropertyName = "Apellido";
            columnaApellido.HeaderText = "Apellido";
            columnaApellido.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DataGridViewTextBoxColumn columnaNombre = new DataGridViewTextBoxColumn();
            columnaNombre.DataPropertyName = "Nombre";
            columnaNombre.HeaderText = "Nombre";
            columnaNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DataGridViewTextBoxColumn columnaDni = new DataGridViewTextBoxColumn();
            columnaDni.DataPropertyName = "Dni";
            columnaDni.HeaderText = "DNI";
            columnaDni.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.Columns.Add(columnaApellido);
            dataGridView1.Columns.Add(columnaNombre);
            dataGridView1.Columns.Add(columnaDni);

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.CellClick += ElementoSeleccionado;
        }

        private void MostrarPersonas()
        {
            dataGridView1.DataSource = BLL.PersonaBLL.ObtenerPersonas();
            dataGridView1.CurrentCell = null;
            dataGridView1.ClearSelection();
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
            try
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
                BLL.PersonaBLL.GuardarPersona(id, textBoxNombre.Text, textBoxApellido.Text, textBoxDni.Text, textBoxTelefono.Text, textBoxMail.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la persona: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            MostrarPersonas();

            ModoNuevoRegistro();

            MessageBox.Show("Persona guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (id is null)
            {
                MessageBox.Show("Debe seleccionar una persona para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            var confirma = MessageBox.Show("¿Está seguro que desea eliminar la persona seleccionada?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirma == DialogResult.No)
            {
                return;
            }

            try
            {
                BLL.PersonaBLL.EliminarPersona(id.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la persona: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            MostrarPersonas();

            ModoNuevoRegistro();

            MessageBox.Show("Persona eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
