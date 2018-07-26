using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaAccesoDatos;
using CapaLogicaNegocios;

namespace CapaPresentacion
{
    public partial class FrmPagoVenta : Form
    {
        double totalAPagar;
        public FrmPagoVenta(double totalAPagar)
        {
            this.totalAPagar = totalAPagar;
            InitializeComponent();
        }

        private void FrmPagoVenta_Load(object sender, EventArgs e)
        {
            txtTotalAPagar.Text = totalAPagar.ToString();
            

        }

        private void realizarVenta()
        {
            if (MessageBox.Show("Realizar venta?", "Continuar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                double cantidadEntregada = Convert.ToDouble(txtCantidad.Text);
                if (cantidadEntregada < totalAPagar)
                {
                    MessageBox.Show("El efectivo ingresado no es suficiente");
                }
                else if (cmbTipoPago.Text.Equals(""))
                {
                    MessageBox.Show("Favor de seleccionar el metodo de pago");
                }
                else
                {
                    if (cmbTipoPago.Text.Equals("Efectivo"))
                    {
                        Login.tipoPago = 0;
                    }
                    else if (cmbTipoPago.Text.Equals("Tarjeta"))
                    {
                        Login.tipoPago = 1;
                    }
                    double cambio = cantidadEntregada - totalAPagar;
                    MessageBox.Show("Cambio: " + cambio.ToString());
                    Login.Pago = true;
                    this.Hide();

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            realizarVenta();
        }

        private void cmbTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbTipoPago_KeyDown(object sender, KeyEventArgs e)
        {
            if ((int)e.KeyCode == (int)Keys.Enter)
            {
                realizarVenta();
            }
        }
    }
}
