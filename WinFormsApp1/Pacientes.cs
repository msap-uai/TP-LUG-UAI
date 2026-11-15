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
    public partial class Pacientes : Form
    {
        private PacienteBLL pacienteBLL = new PacienteBLL();
        private Paciente? pacienteSeleccionado = null;
        public Pacientes()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbPersona.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar una persona.");
                    return;
                }

                BE.Persona persona = (BE.Persona)cmbPersona.SelectedItem;

                // Obtener la obra social seleccionada
                BE.ObraSocial? obraSocialSeleccionada = null;

                if (cmbObraSocial.SelectedIndex != -1)
                {
                    obraSocialSeleccionada = (BE.ObraSocial?)cmbObraSocial.SelectedItem;
                }

                // Crear el objeto Paciente
                Paciente paciente = new Paciente(
                    persona.Id,
                    0,
                    persona.Nombre,
                    persona.Apellido,
                    persona.Dni,
                    persona.Telefono,
                    persona.Mail,
                    dtpFechaNacimiento.Value,
                    obraSocialSeleccionada,
                    txtNumeroAfiliado.Text
                );

                PacienteBLL.AgregarPaciente(paciente);

                MessageBox.Show("Paciente registrado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarPacientes();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Pacientes_Load(object sender, EventArgs e)
        {
            try
            {
                ObraSocialBLL obraSocialBLL = new ObraSocialBLL();

                cmbObraSocial.DataSource = obraSocialBLL.ObtenerObrasSociales();

                cmbObraSocial.DisplayMember = "Nombre";
                cmbObraSocial.ValueMember = "Id";

                cmbObraSocial.SelectedIndex = -1;
                CargarPersonas(null);
                CargarPacientes();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarPersonas(BE.Persona? persona)
        {
            try
            {
                List<BE.Persona> personas = PersonaBLL.ObtenerPersonasQueNoSonPacientes();

                if (persona != null)
                {
                    personas.Insert(0, persona);
                }

                cmbPersona.DisplayMember = "NombreCompletoConDNI";
                cmbPersona.DataSource = personas;

                if (persona != null)
                {
                    cmbPersona.SelectedIndex = 0;
                }
                else
                {
                    cmbPersona.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las personas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarPacientes()
        {
            try
            {
                dgvPacientes.DataSource = null;

                dgvPacientes.DataSource = pacienteBLL.ObtenerPacientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar pacientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimpiarCampos()
        {
            try
            {
                pacienteSeleccionado = null;
                CargarPersonas(null);
                cmbPersona.Enabled = true;
                txtNumeroAfiliado.Clear();

                dtpFechaNacimiento.Value = DateTime.Today;

                cmbObraSocial.SelectedIndex = -1;

                dgvPacientes.ClearSelection();

                cmbPersona.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al limpiar los campos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPacientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                {
                    return;
                }

                pacienteSeleccionado = dgvPacientes.Rows[e.RowIndex].DataBoundItem as Paciente;

                if (pacienteSeleccionado == null)
                {
                    return;
                }

                CargarPersonas(pacienteSeleccionado);
                cmbPersona.Enabled = false;

                dtpFechaNacimiento.Value = pacienteSeleccionado.FechaNacimiento;

                txtNumeroAfiliado.Text = pacienteSeleccionado.NumeroAfiliado;

                // Seleccionar la obra social correspondiente
                cmbObraSocial.SelectedIndex = -1;

                if (pacienteSeleccionado.ObraSocial != null)
                {
                    cmbObraSocial.SelectedValue = pacienteSeleccionado.ObraSocial.Id;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar el paciente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (pacienteSeleccionado == null)
                {
                    MessageBox.Show("Debe seleccionar un paciente para modificar.");
                    return;
                }

                // Obtener la obra social seleccionada
                BE.ObraSocial?   obraSocialSeleccionada = null;

                if (cmbObraSocial.SelectedIndex != -1)
                {
                    obraSocialSeleccionada = (BE.ObraSocial?)cmbObraSocial.SelectedItem;
                }

                // Crear el paciente con sus identificadores originales
                Paciente paciente = new Paciente(
                    pacienteSeleccionado.Id,
                    pacienteSeleccionado.IdPaciente,
                    pacienteSeleccionado.Nombre,
                    pacienteSeleccionado.Apellido,
                    pacienteSeleccionado.Dni,
                    pacienteSeleccionado.Telefono,
                    pacienteSeleccionado.Mail,
                    dtpFechaNacimiento.Value,
                    obraSocialSeleccionada,
                    txtNumeroAfiliado.Text
                );

                // Llamar a BLL para modificar
                pacienteBLL.ModificarPaciente(paciente);

                CargarPacientes();               
                LimpiarCampos();

                MessageBox.Show("Paciente modificado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (pacienteSeleccionado == null)
                {
                    MessageBox.Show("Debe seleccionar un paciente para eliminar.");
                    return;
                }

                DialogResult respuesta = MessageBox.Show("¿Está seguro de que desea eliminar al paciente seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.No)
                {
                    return;
                }

                pacienteBLL.EliminarPaciente(pacienteSeleccionado.IdPaciente);

                CargarPacientes();
                LimpiarCampos();

                MessageBox.Show("Paciente eliminado correctamente.", "Información",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
