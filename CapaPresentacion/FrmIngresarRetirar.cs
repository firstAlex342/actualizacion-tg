using CapaLogicaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmIngresarRetirar : Form
    {
        public int tipoMovimiento;
        ClsIngresarRetirar cls_ingresarRetirar = new ClsIngresarRetirar();
        public FrmIngresarRetirar(int tipoMovimientoCaja)
        {
            this.tipoMovimiento = tipoMovimientoCaja;
            InitializeComponent();
        }

        private void FrmIngresarRetirar_Load(object sender, EventArgs e)
        {
            if (tipoMovimiento == 1)
            {
                btnTipoMovimiento.Image = Properties.Resources.money_1;
                btnTipoMovimiento.Text = "Ingresar";
            }
            else if (tipoMovimiento == 2)
            {
                btnTipoMovimiento.Image = Properties.Resources.money;
                btnTipoMovimiento.Text = "Retirar";
            }
        }

        private void btnTipoMovimiento_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea "+btnTipoMovimiento.Text+" el dinero y continuar?", "Continuar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string mensaje = "";
                double cantidad = Convert.ToDouble(txtCantidad.Text);
                string observacion = txtObservacion.Text;
                int tipoMov = 0;
                if (tipoMovimiento == 1)
                {
                    Login.dineroEntrada = Login.dineroEntrada + cantidad;
                    tipoMov = 0;
                }
                else if (tipoMovimiento == 2)
                {
                    Login.dineroEntrada = Login.dineroEntrada - cantidad;
                    tipoMov = 1;
                }
                
                cls_ingresarRetirar.m_cantidad = cantidad;
                cls_ingresarRetirar.m_observacion = observacion;
                cls_ingresarRetirar.m_tipoMovCaja = tipoMov;
                cls_ingresarRetirar.m_usuario = Login.idUsuario;
                mensaje = cls_ingresarRetirar.guardarMovimientoCaja();
                MessageBox.Show(mensaje);
                this.Close();
            }
        }
    }
}