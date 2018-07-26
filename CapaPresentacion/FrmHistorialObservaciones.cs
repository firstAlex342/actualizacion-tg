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
    public partial class FrmHistorialObservaciones : Form
    {
        ClsHistorialObservaciones cls_HisObvservaciones = new ClsHistorialObservaciones();
        FrmReporteEntradas reporteObservaciones = new FrmReporteEntradas();
        public int tipo;
        public FrmHistorialObservaciones()
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

        private void btnBuscarH_Click(object sender, EventArgs e)
        {
            if (cbTipo.SelectedIndex == 0)
            {
                try
                {
                    cls_HisObvservaciones.m_IdUsuario = Convert.ToInt32(txtUsuario.Text);
                    DataTable dt = cls_HisObvservaciones.buscarHisObGeneralesID();
                    dgvObGenerales.DataSource = dt;
                    DataTable dt2 = cls_HisObvservaciones.buscarHisObCajaID();
                    dgvObCaja.DataSource = dt2;
                    btnGenerarReporteH.Enabled = true;
                    btnGenerarReporte2.Enabled = true;
                    tipo = 0;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (cbTipo.SelectedIndex == 1)
            {
                try
                {
                    cls_HisObvservaciones.m_FechaInicioBusquedaH = dtpInicioBusquedaH.Value;
                    cls_HisObvservaciones.m_FechaFinBusquedaH = dtpFinBusquedaH.Value;
                    DataTable dt = cls_HisObvservaciones.buscarHisObGeneralesFecha();
                    dgvObGenerales.DataSource = dt;
                    DataTable dt2 = cls_HisObvservaciones.buscarHisObCajaFecha();
                    dgvObCaja.DataSource = dt2;
                    btnGenerarReporteH.Enabled = true;
                    btnGenerarReporte2.Enabled = true;
                    tipo = 1;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (cbTipo.SelectedIndex == 2)
            {
                try
                {
                    cls_HisObvservaciones.m_IdUsuario = Convert.ToInt32(txtUsuario.Text);
                    cls_HisObvservaciones.m_FechaInicioBusquedaH = dtpInicioBusquedaH.Value;
                    cls_HisObvservaciones.m_FechaFinBusquedaH = dtpFinBusquedaH.Value;
                    DataTable dt = cls_HisObvservaciones.buscarHisObGenerales();
                    dgvObGenerales.DataSource = dt;
                    DataTable dt2 = cls_HisObvservaciones.buscarHisObCaja();
                    dgvObCaja.DataSource = dt2;
                    btnGenerarReporteH.Enabled = true;
                    btnGenerarReporte2.Enabled = true;
                    tipo = 2;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private void btnGenerarReporteH_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea generar un reporte?", "Continuar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                switch (tipo)
                { // observaciones generales
                    case 0:
                        Login.opcionReporte = 5; //busqueda por id 
                        FrmReporteEntradas reporteEntradas = new FrmReporteEntradas();
                        reporteEntradas.idSocio = Convert.ToInt32(txtUsuario.Text);
                        reporteEntradas.ShowDialog();
                        break;
                    case 1:
                        Login.opcionReporte = 7; // busqueda por fecha
                        FrmReporteEntradas reporteEntradas2 = new FrmReporteEntradas();
                        reporteEntradas2.fechaInicioBusqueda = dtpInicioBusquedaH.Value;
                        reporteEntradas2.fechaFinBusqueda = dtpFinBusquedaH.Value;
                        reporteEntradas2.ShowDialog();
                        break;
                    case 2:
                        Login.opcionReporte = 2; //busqueda por id y fecha
                        FrmReporteEntradas reporteEntradas3 = new FrmReporteEntradas();
                        reporteEntradas3.idSocio = Convert.ToInt32(txtUsuario.Text);
                        reporteEntradas3.fechaInicioBusqueda = dtpInicioBusquedaH.Value;
                        reporteEntradas3.fechaFinBusqueda = dtpFinBusquedaH.Value;
                        reporteEntradas3.ShowDialog();
                        break;
                    default:
                        break;
                }
            }
        }

        private void btnGenerarReporte2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea generar un reporte?", "Continuar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                switch (tipo)
                { // observaciones caja
                    case 0:
                        Login.opcionReporte = 6; //busqueda por id 
                        FrmReporteEntradas reporteEntradas = new FrmReporteEntradas();
                        reporteEntradas.idSocio = Convert.ToInt32(txtUsuario.Text);
                        reporteEntradas.ShowDialog();
                        break;
                    case 1:
                        Login.opcionReporte = 8; // busqueda por fecha
                        FrmReporteEntradas reporteEntradas2 = new FrmReporteEntradas();
                        reporteEntradas2.fechaInicioBusqueda = dtpInicioBusquedaH.Value;
                        reporteEntradas2.fechaFinBusqueda = dtpFinBusquedaH.Value;
                        reporteEntradas2.ShowDialog();
                        break;
                    case 2:
                        Login.opcionReporte = 3; //busqueda por id y fecha
                        FrmReporteEntradas reporteEntradas3 = new FrmReporteEntradas();
                        reporteEntradas3.idSocio = Convert.ToInt32(txtUsuario.Text);
                        reporteEntradas3.fechaInicioBusqueda = dtpInicioBusquedaH.Value;
                        reporteEntradas3.fechaFinBusqueda = dtpFinBusquedaH.Value;
                        reporteEntradas3.ShowDialog();
                        break;
                    default:
                        break;
                }
            }
        }
        private void btnBuscarEnabled(object sender, EventArgs e)
        {
            btnBuscarH.Enabled = true;
        }

        private void dgvObCaja_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtObservacion.Text =dgvObCaja.Rows[e.RowIndex].Cells["texto"].Value.ToString();
        }

        private void FrmHistorialObservaciones_Load(object sender, EventArgs e)
        {

        }
    }
}
