using PresupuestoDeCuentas.UI.Registro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PresupuestoDeCuentas
{
    public partial class VentanaPrincipal : Form
    {
        public VentanaPrincipal()
        {
            InitializeComponent();
        }

        private void presupuestoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PresupuestoCuentas presupuesto = new PresupuestoCuentas();
            presupuesto.MdiParent = this;
            presupuesto.Show();
        }
     
    }
}
