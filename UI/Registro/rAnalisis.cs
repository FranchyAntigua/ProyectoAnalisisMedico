using ProyectoAnalisisMedico.BLL;
using ProyectoAnalisisMedico.DAL;
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
    public partial class rAnalisis : Form
    {
        public rAnalisis()
        {
            InitializeComponent();
        }

        private void LlenarCampos(Analisis analisis)
        {
            IdnumericUpDown.Value = analisis.AnalisisId;
            FechaDateTimePicker.Value = analisis.Fecha;
            UsuarioComboBox.SelectedValue = analisis.UsuarioId;
            AnalisisDataGridView.DataSource = analisis.Detalle;

            AnalisisDataGridView.Columns["Id"].Visible = false;
            AnalisisDataGridView.Columns["MantenimientoId"].Visible = false;
            AnalisisDataGridView.Columns["UsuarioId"].Visible = false;
        }

        private void LlenarComboBox()
        {
            Repositorio<Usuarios> repositorioU = new Repositorio<Usuarios>();
            Repositorio<Usuarios> repositorioT = new Repositorio<Usuarios>();

            UsuarioComboBox.DataSource = repositorioU.GetList(c => true);
            UsuarioComboBox.ValueMember = "UsuarioId";
            UsuarioComboBox.DisplayMember = "Nombres";

            TipocomboBox.DataSource = repositorioT.GetList(c => true);
            TipocomboBox.ValueMember = "TipoId";
            TipocomboBox.DisplayMember = "Descripcion";

        }

        private Analisis LlenaClase()
        {
            Analisis analisis = new Analisis();

            analisis.AnalisisId = Convert.ToInt32(IdnumericUpDown.Value);
            analisis.Fecha = FechaDateTimePicker.Value;
            analisis.UsuarioId = Convert.ToInt32(UsuarioComboBox.SelectedValue);

            foreach (DataGridViewRow item in AnalisisDataGridView.Rows)
            {
                analisis.AgregarDetalle(
                    Convert.ToInt32(item.Cells["Id"].Value),
                    Convert.ToInt32(item.Cells["AnalisisId"].Value),
                    Convert.ToInt32(item.Cells["TipoId"].Value),
                    item.Cells["Articulo"].ToString()
                );
            }

            AnalisisDataGridView.Columns["Id"].Visible = false;
            AnalisisDataGridView.Columns["AnalisisId"].Visible = false;
            AnalisisDataGridView.Columns["UsuarioId"].Visible = false;

            return analisis;
        }

        private void Limpiar()
        {
            IdnumericUpDown.Value = 0;
            FechaDateTimePicker.Value = DateTime.Now;
            UsuarioComboBox.SelectedIndex = 0;
            TipocomboBox.SelectedIndex = 0;
            ResultadotextBox.Clear();
            MyErrorProvider.Clear();
        }

        private bool Validar()
        {
            bool estado = false;

            if (String.IsNullOrWhiteSpace(ResultadotextBox.Text))
            {
                MyErrorProvider.SetError(ResultadotextBox,
                    "No puede estar vacio");
                estado = true;
            }

            return estado;
        }

        private void AgregarButton_Click(object sender, EventArgs e)
        {
            List<AnalisisDetalle> detalle = new List<AnalisisDetalle>();

            if (AnalisisDataGridView.DataSource != null)
            {
                detalle = (List<AnalisisDetalle>)AnalisisDataGridView.DataSource;
            }
            else
            {
                detalle.Add(
               new AnalisisDetalle(
                   id: 0,
                   analisisId: (int)IdnumericUpDown.Value,
                   tipoId: (int)TipocomboBox.SelectedValue,
                   resultado: ResultadotextBox.Text
               ));

                AnalisisDataGridView.DataSource = null;
                AnalisisDataGridView.DataSource = detalle;

            }
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);
            Analisis analisis = AnalisisBLL.Buscar(id);

            if (analisis != null)
            {
                LlenarCampos(analisis);
            }
            else
                MessageBox.Show("No se encontró!!!", "Falló",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Analisis analisis;
            bool Paso = false;

            if (Validar())
            {
                MessageBox.Show("Favor revisar todos los campos!!", "Validación!!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            analisis = LlenaClase();

            if (IdnumericUpDown.Value == 0)
            {
                Paso = AnalisisBLL.Guardar(analisis);
                MessageBox.Show("Guardado!!", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int id = Convert.ToInt32(IdnumericUpDown.Value);
                Analisis analisi = AnalisisBLL.Buscar(id);

                if (analisi != null)
                {
                    Paso = AnalisisBLL.Editar(analisis);
                    MessageBox.Show("Modificado!!", "Exito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Id no existe", "Falló",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (Paso)
            {
                Limpiar();
            }
            else
                MessageBox.Show("No se pudo guardar!!", "Fallo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);

            Analisis analisis = AnalisisBLL.Buscar(id);

            if (analisis != null)
            {
                if (AnalisisBLL.Eliminar(id))
                {
                    MessageBox.Show("Eliminado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                    MessageBox.Show("No se pudo eliminar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("No existe!!", "Falló", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
