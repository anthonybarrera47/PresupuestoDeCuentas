﻿using PresupuestoDeCuentas.BLL;
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
    public partial class PresupuestoCuentas : Form
    {
        public PresupuestoCuentas()
        {
            InitializeComponent();
            LlenaComboBox();
        }
        private void LlenaComboBox()
        {
            RepositorioBase<Cuentas> rCuentas = new RepositorioBase<Cuentas>();
            CuentascomboBox.DataSource = rCuentas.GetList(x => true);
            CuentascomboBox.ValueMember = "CuentaId";
            CuentascomboBox.DisplayMember = "Descripcion";
        }
        private void Limpiar()
        {
            errorProvider.Clear();
            PresupuestoIDnumericUpDown.Value = 0;
            DescripciontextBox.Text = string.Empty;
            CuentascomboBox.SelectedIndex = 0;
            ValorTextBox.Text = string.Empty;
        }
        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private Presupuesto LlenaClase()
        {
            Presupuesto presupuesto = new Presupuesto()
            {
                PresupuestoId = Convert.ToInt32(PresupuestoIDnumericUpDown.Value),
                Descripcion = DescripciontextBox.Text,
                Fecha = DateTime.Now,
                Monto = Convert.ToDouble(ValorTextBox.Text)
            };
            return presupuesto;
        }
        private void LlenaCampo(Presupuesto presupuesto)
        {
            
        }

        private void AgregarCuentaButton_Click(object sender, EventArgs e)
        {
            CuentasRegistro cuentaRegistro = new CuentasRegistro();
            cuentaRegistro.ShowDialog();
        }
    }
}
