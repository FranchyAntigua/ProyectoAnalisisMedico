using ProyectoAnalisisMedico.BLL;
using ProyectoAnalisisMedico.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoAnalisisMedico.UI.Registro
{
    public partial class rUsuario : Form
    {
        public rUsuario()
        {
            InitializeComponent();
        }

        private Usuarios LlenaClase()
        {
            Usuarios usuario = new Usuarios();

            usuario.UsuarioId = Convert.ToInt32(IdNumericUpDown.Value);
            usuario.Fecha = FechaDateTimePicker.Value;
            usuario.Nombres = NombrestextBox.Text;
            usuario.Username = UsernametextBox.Text;
            usuario.Contraseña = ContraseñatextBox.Text;

            return usuario;
        }

        private void Limpiar()
        {
            IdNumericUpDown.Value = 0;
            FechaDateTimePicker.Value = DateTime.Now;
            NombrestextBox.Clear();
            UsernametextBox.Clear();
            ContraseñatextBox.Clear();
            MyErrorProvider.Clear();
        }

        private bool Validar()
        {
            bool estado = false;

            string s = ContraseñatextBox.Text;
            string ss = ConfirmartextBox.Text;
            int comparacion = 0;
            comparacion = String.Compare(s, ss);
            if (comparacion != 0)
            {
                MyErrorProvider.SetError(ContraseñatextBox, "No coinciden");
                MyErrorProvider.SetError(ConfirmartextBox, "No coinciden");
                estado = true;
            }

            if (IdNumericUpDown.Value < 0)
            {
                MyErrorProvider.SetError(IdNumericUpDown,
                    "No es un id válido");
                estado = true;
            }

            if (String.IsNullOrWhiteSpace(NombrestextBox.Text))
            {
                MyErrorProvider.SetError(Nombres,
                    "No puede estar vacio");
                estado = true;
            }

            if (String.IsNullOrWhiteSpace(UsernametextBox.Text))
            {
                MyErrorProvider.SetError(UsernametextBox,
                    "No puede estar vacio");
                estado = true;
            }

            if (String.IsNullOrWhiteSpace(ContraseñatextBox.Text))
            {
                MyErrorProvider.SetError(ContraseñatextBox,
                    "No puede estar vacio");
                estado = true;
            }

            return estado;
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdNumericUpDown.Value);
            Usuarios usuario = UsuariosBLL.Buscar(id);

            if (usuario != null)
            {
                FechaDateTimePicker.Value = usuario.Fecha;
                NombrestextBox.Text = usuario.Nombres;
                UsernametextBox.Text = usuario.Username;
                ContraseñatextBox.Text = usuario.Contraseña;
            }
            else
                MessageBox.Show("No se encontró", "Falló",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios();
            bool Estado = false;

            if (Validar())
            {
                MessageBox.Show("Debe llenar todos los campos que se indican!!!", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            usuario = LlenaClase();

            if (IdNumericUpDown.Value == 0)
                Estado = UsuariosBLL.Guardar(usuario);
            else
            {
                int id = Convert.ToInt32(IdNumericUpDown.Value);
                usuario = UsuariosBLL.Buscar(id);

                if (usuario != null)
                {
                    Estado = UsuariosBLL.Editar(LlenaClase());
                }
                else
                    MessageBox.Show("Id no existe", "Falló",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (Estado)
            {
                MessageBox.Show("Modificado", "Exito",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
                MessageBox.Show("No se pudo guardar", "Falló",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdNumericUpDown.Value);

            Usuarios usuario = UsuariosBLL.Buscar(id);

            if (usuario != null)
            {
                if (UsuariosBLL.Eliminar(id))
                {
                    MessageBox.Show("Eliminado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }

                else
                    MessageBox.Show("No se pudo eliminar!!", "Falló", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("No existe!!", "Falló", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
