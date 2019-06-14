using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoAnalisisMedico.UI.Registro;

namespace ProyectoAnalisisMedico
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void CargosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void UsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rUsuario rUsuario = new rUsuario();
            rUsuario.Show();
        }

        private void AnalisisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rAnalisis rAnalisis = new rAnalisis();
            rAnalisis.Show();
        }

        private void TipoAnalisisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rTipoAnalisis rTipoAnalisis = new rTipoAnalisis();
            rTipoAnalisis.Show();
        }
    }
}
