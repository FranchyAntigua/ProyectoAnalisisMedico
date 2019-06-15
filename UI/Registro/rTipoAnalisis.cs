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
    public partial class rTipoAnalisis : Form
    {
        public rTipoAnalisis()
        {
            InitializeComponent();
        }

        private TiposAnalisis LlenaClase()
        {
            TiposAnalisis tipo = new TiposAnalisis();

            tipo.TipoId = Convert.ToInt32(IdnumericUpDown.Value);
            tipo.Descripcion = DescripciontextBox.Text;

            return tipo;
        }

        private void Limpiar()
        {
            IdnumericUpDown.Value = 0;
            DescripciontextBox.Clear();
            MyErrorProvider.Clear();
        }

        private bool Validar()
        {
            bool estado = false;

            if (IdnumericUpDown.Value < 0)
            {
                MyErrorProvider.SetError(IdnumericUpDown,
                    "No es un id válido");
                estado = true;
            }

            if (String.IsNullOrWhiteSpace(DescripciontextBox.Text))
            {
                MyErrorProvider.SetError(DescripciontextBox,
                    "No puede estar vacio");
                estado = true;
            }

            return estado;
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);
            TiposAnalisis tipo = TiposAnalisisBLL.Buscar(id);

            if (tipo != null)
            {
                DescripciontextBox.Text = tipo.Descripcion;
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
            bool estado = false;
            TiposAnalisis tipo = new TiposAnalisis();

            if (Validar())
            {
                MessageBox.Show("Llene los campos correctamente", "Falló",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                tipo = LlenaClase();

                if (Convert.ToInt32(IdnumericUpDown.Value) == 0)
                {
                    estado = TiposAnalisisBLL.Guardar(tipo);
                    MessageBox.Show("Guardado", "Exito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                {
                    
                    int id = Convert.ToInt32(IdnumericUpDown.Value);
                    TiposAnalisis tiposAnalisis = new TiposAnalisis();
                    tiposAnalisis = TiposAnalisisBLL.Buscar(id);

                    if (tiposAnalisis != null)
                    {
                        estado= TiposAnalisisBLL.Editar(LlenaClase());
                        MessageBox.Show("Modificado", "Exito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Id no existe", "Falló",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (estado)
                {
                    Limpiar();
                }
                else
                    MessageBox.Show("No se pudo guardar", "Falló",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);

            TiposAnalisis tipo = TiposAnalisisBLL.Buscar(id);

            if (tipo != null)
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
