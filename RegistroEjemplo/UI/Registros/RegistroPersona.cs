using RegistroEjemplo.BLL;
using RegistroEjemplo.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroEjemplo.UI.Registros
{
    public partial class RegistroPersona : Form
    {
        public RegistroPersona()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            IDnumericUpDown.Value = 0;
            NombretextBox.Text = string.Empty;
            DirecciontextBox.Text = string.Empty;
            DirecciontextBox.Text = string.Empty;
            MyErrorProvider.Clear();
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private Personas LlenaCLase()
        {
            Personas persona = new Personas();
            persona.PersonaId = Convert.ToInt32(IDnumericUpDown.Value);
            persona.Nombre = NombretextBox.Text;
            persona.Cedula = DirecciontextBox.Text;
            persona.Direccion = DirecciontextBox.Text;

            return persona;
        }

        private void LlenaCampo(Personas persona)
        {
            IDnumericUpDown.Value = persona.PersonaId;
            NombretextBox.Text = persona.Nombre;
            CedulamaskedTextBox.Text = persona.Cedula;
            DirecciontextBox.Text = persona.Direccion;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Personas persona = PersonasBLL.Buscar((int)IDnumericUpDown.Value);
            return (persona != null);
        }
        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Personas persona;
            bool paso = false;

            if (!Validar())
                return;

            persona = LlenaCLase();
            Limpiar();

            if (IDnumericUpDown.Value == 0)
                paso = PersonasBLL.Guardar(persona);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar una persona que no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = PersonasBLL.Modificar(persona);
            }

            if (paso)
                MessageBox.Show("Guardado!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No fue posible guardar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool Validar()
        {
            bool paso = true;
            MyErrorProvider.Clear();

            if (NombretextBox.Text == string.Empty)
            {
                MyErrorProvider.SetError(NombretextBox, "El campo nombre no puede estar vacio");
                NombretextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(DirecciontextBox.Text))
            {
                MyErrorProvider.SetError(DirecciontextBox, "El campo Direccion no puede estar vacio");
                DirecciontextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(CedulamaskedTextBox.Text.Replace("-", "")))
            {
                MyErrorProvider.SetError(CedulamaskedTextBox, "El campo cedula no puede estar vacio");
                CedulamaskedTextBox.Focus();
                paso = false;
            }
            return paso;
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id;
            Personas persona = new Personas();
            int.TryParse(IDnumericUpDown.Text, out id);

            Limpiar();

            persona = PersonasBLL.Buscar(id);

            if (persona != null)
            {
                MessageBox.Show("Persona Encontrada");
                LlenaCampo(persona);
            }
            else
            {
                MessageBox.Show("Persona no encontrada");
            }
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            MyErrorProvider.Clear();

            int id;
            int.TryParse(IDnumericUpDown.Text, out id);

            Limpiar();

            if (PersonasBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MyErrorProvider.SetError(IDnumericUpDown, "No se puede eliminar una persona que no existe");
        }
    }
}