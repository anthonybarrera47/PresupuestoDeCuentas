using PresupuestoDeCuentas.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PresupuestoDeCuentas.UI.Registro
{
    public partial class CuentasRegistro : Form
    {
        public CuentasRegistro()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            CuentaIDnumericUpDown.Value = 0;
            DescripciontextBox1.Text = string.Empty;
            MontoNumericUpDown.Value = 0;
        }
        private Cuentas LlenaClase()
        {
            Cuentas cuentas = new Cuentas()
            {
                CuentaId = Convert.ToInt32(CuentaIDnumericUpDown.Value),
                Descripcion = DescripciontextBox1.Text,
                TipoId = (int)TipoComboBox.SelectedValue,
                Monto = Convert.ToDouble(MontoNumericUpDown.Value)
            };
            return cuentas;
        }
        private void LlenaCampo(Cuentas cuentas)
        {
           
            CuentaIDnumericUpDown.Value = cuentas.CuentaId;
            DescripciontextBox1.Text = cuentas.Descripcion;
            TipoComboBox.SelectedIndex = cuentas.TipoId;
            MontoNumericUpDown.Value = Convert.ToDecimal(cuentas.Monto);
        }
        
        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
