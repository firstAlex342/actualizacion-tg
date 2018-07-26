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
    public partial class FrmMovimientosEScaja : Form
    {

        ClsIngresarRetirar cls_ingresarRetirar = new ClsIngresarRetirar();
        FrmReporteEntradas FrmReporte = new FrmReporteEntradas();
        public FrmMovimientosEScaja()
        {
            InitializeComponent();
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea generar un reporte?", "Continuar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                FrmReporte.ShowDialog();
            }
        }
        private void txtSoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        private void validarTextBoxID(object sender, EventArgs e)
        {
            if (txtUsuario.Text != null)
            {
                btnBuscarxID.Enabled = true;
               // btnBuscarxFecha.Enabled = false;
            }
            else
            {
                MessageBox.Show("No pueden estar los campos vacios para realizar la busqueda");
            }
        }
        private void validarDateTimePickerFecha(object sender, EventArgs e)
        {

        }

        private void btnBuscarxFecha_Click(object sender, EventArgs e)
        {
            try
            {
                cls_ingresarRetirar.m_fecha = dtpFecha.Value;
                DataTable dt = cls_ingresarRetirar.buscarCortesCajaXFecha();
                dgvMovimientos.DataSource = dt;
                btnGenerarReporte.Enabled = true;
                Login.opcionReporte = 9;
                FrmReporte.fechaInicioBusqueda = dtpFecha.Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnBuscarxID_Click(object sender, EventArgs e)
        {
            try
            {
                cls_ingresarRetirar.m_usuario = Convert.ToInt32(txtUsuario.Text);
                DataTable dt = cls_ingresarRetirar.buscarCortesCajaXUsuario();
                dgvMovimientos.DataSource = dt;
                btnGenerarReporte.Enabled = true;
                Login.opcionReporte = 10;
                FrmReporte.idSocio = Convert.ToInt32(txtUsuario.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FrmMovimientosEScaja_Load(object sender, EventArgs e)
        {

        }
    }
}
