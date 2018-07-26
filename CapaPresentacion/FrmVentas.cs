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
    public partial class FrmVentas : Form
    {
        ClsVentas cls_ventas = new ClsVentas();
        public FrmVentas()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                cls_ventas.m_FechaInicioBusqueda = dtpInicioBusqueda.Value;
                cls_ventas.m_FechaFinBusqueda = dtpFinBusqueda.Value;
                DataTable dt = cls_ventas.buscarVentas();
                dgvVentas.DataSource = dt;
                btnGenerarReporte.Enabled = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        { //generar reporte
            if (MessageBox.Show("¿Desea generar un reporte?", "Continuar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Login.opcionReporte = 4;
                FrmReporteEntradas reporteEntradas = new FrmReporteEntradas();
                reporteEntradas.fechaInicioBusqueda = dtpInicioBusqueda.Value;
                reporteEntradas.fechaFinBusqueda = dtpFinBusqueda.Value;
                reporteEntradas.ShowDialog();
            }
        }
    }
}
