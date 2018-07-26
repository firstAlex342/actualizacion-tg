using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogicaNegocios;

namespace CapaPresentacion
{
    public partial class FrmCorteEntrada : Form
    {
        ClsCorteCaja cls_corte_caja = new ClsCorteCaja();
        ClsIngresarRetirar cls_ingresarRetirar = new ClsIngresarRetirar();
        public FrmCorteEntrada()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        public void guardarDinero()
        {
            if (MessageBox.Show("Dinero en caja entrada: " + txtDineroCaja.Text + "\n¿Continuar?", "Continuar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                cls_ingresarRetirar.m_cantidad = Convert.ToDouble(txtDineroCaja.Text);
                cls_ingresarRetirar.m_observacion = "Dinero entrada caja";
                cls_ingresarRetirar.m_tipoMovCaja = 0;
                cls_ingresarRetirar.m_usuario = Login.idUsuario;
                string mensaje = cls_ingresarRetirar.guardarMovimientoCaja();
                MessageBox.Show(mensaje);
                //double dineroEntrada = Convert.ToDouble(txtDineroCaja.Text); 
                //cls_corte_caja.m_idUsuario = Login.idUsuario;
                //cls_corte_caja.m_cantidad = dineroEntrada;
                //string respuesta = cls_corte_caja.movimientoCorteCajaEntrada();
                //MessageBox.Show(respuesta);
                //Login.dineroEntrada = dineroEntrada;
                Login.cajaAbierta = true;
                this.Hide();
                FrmMain abrir = new FrmMain();
                abrir.Show();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            guardarDinero();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtDineroCaja_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDineroCaja_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) &&
              e.KeyChar != Convert.ToChar(Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void txtDineroCaja_KeyDown(object sender, KeyEventArgs e)
        {
            if ((int)e.KeyCode == (int)Keys.Enter)
            {
                guardarDinero();
            }
        }
    }
}
