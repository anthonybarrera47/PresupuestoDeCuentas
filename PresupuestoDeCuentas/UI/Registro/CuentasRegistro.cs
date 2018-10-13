using PresupuestoDeCuentas.BLL;
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
        private RepositorioBase<Cuentas> repositorio;
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
        private bool ExisteEnLaBaseDeDatos()
        {
            repositorio = new RepositorioBase<Cuentas>();
            Cuentas cuenta = repositorio.Buscar((int)CuentaIDnumericUpDown.Value);
            return (cuenta != null);
        }
        private bool GuardarValidar()
        {
            bool paso = true;
            if(string.IsNullOrEmpty(DescripciontextBox1.Text))
            {
                errorProviderCuenta.SetError(DescripciontextBox1, "El Campo Descripcion esta Vacio");
                paso = false;
            }
            if(MontoNumericUpDown.Value==0)
            {
                errorProviderCuenta.SetError(MontoNumericUpDown, "El Campo Monto esta en 0");
                paso = false;
            }
            return paso;
        }
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            repositorio = new RepositorioBase<Cuentas>();
            Cuentas cuenta;
            bool paso = false;

            cuenta = LlenaClase();
            if (!GuardarValidar())
                return;

            if (CuentaIDnumericUpDown.Value >= 0)
                paso = repositorio.Guardar(cuenta);
            else
            {
                if(!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede Modificar una cuenta no Existente", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = repositorio.Modificar(cuenta);
            }
            if(paso)
            {
                MessageBox.Show("Guardado!!", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
                MessageBox.Show("No se Guardo La Cuenta!!", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Error);    
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id;
            repositorio = new RepositorioBase<Cuentas>();
            Cuentas cuenta = new Cuentas();
            int.TryParse(CuentaIDnumericUpDown.Text, out id);
            cuenta = repositorio.Buscar(id);

            if (cuenta!=null)
            {
                MessageBox.Show("Cuenta Encontrada.!!", "Exito!!!", MessageBoxButtons.OK);
                LlenaCampo(cuenta);
            }
            else
                MessageBox.Show("Cuenta no Encontrada", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            int id;
            repositorio = new RepositorioBase<Cuentas>();
            int.TryParse(CuentaIDnumericUpDown.Text, out id);
            if(!ExisteEnLaBaseDeDatos())
            {
                errorProviderCuenta.SetError(CuentaIDnumericUpDown, "Esta Cuenta No Existe");
                CuentaIDnumericUpDown.Focus();
                return;
            }
            if(repositorio.Eliminar(id))
                MessageBox.Show("Cuenta Eliminada!!", "Exitoso!!!", MessageBoxButtons.OK);
            else
                MessageBox.Show("No se pudo eliminar la Cuenta!!", "Fallo!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
