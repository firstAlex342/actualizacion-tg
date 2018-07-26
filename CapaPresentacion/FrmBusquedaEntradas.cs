using CapaLogicaNegocios;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmBusquedaEntradas : Form
    {
        ClsRegistroEntradas cls_registroEntradas = new ClsRegistroEntradas();
        FrmReporteEntradas reporteEntradas = new FrmReporteEntradas();
        public FrmBusquedaEntradas()
        {
            InitializeComponent();
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
        
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void validarCampos(object sender, EventArgs e)
        {
            if (txtSocio.Text != null)
            {
                btnBuscar.Enabled = true;
            }
            else
            {
                MessageBox.Show("No pueden estar los campos vacios para realizar la busqueda");
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtSocio.Text.Equals(""))
                {
                    MessageBox.Show("colocar clave de socio");
                }
                else
                {
                    cls_registroEntradas.m_IdSocio = Convert.ToInt32(txtSocio.Text);
                    cls_registroEntradas.m_FechaInicioBusqueda = dtpInicioBusqueda.Value;
                    cls_registroEntradas.m_FechaFinBusqueda = dtpFinBusqueda.Value;
                    DataTable dt = cls_registroEntradas.buscarRegistrosEntradas();
                    dgvEntradas.DataSource = dt;
                    btnGenerarReporte.Enabled = true;
                }
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
 
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea generar un reporte?", "Continuar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Login.opcionReporte = 1;
                FrmReporteEntradas reporteEntradas = new FrmReporteEntradas();
                reporteEntradas.idSocio = Convert.ToInt32(txtSocio.Text);
                reporteEntradas.fechaInicioBusqueda = dtpInicioBusqueda.Value;
                reporteEntradas.fechaFinBusqueda = dtpFinBusqueda.Value;
                reporteEntradas.ShowDialog();
            }
        }

        private void FrmBusquedaEntradas_Load(object sender, EventArgs e)
        {

        }
    }
}
