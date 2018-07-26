using CapaLogicaNegocios;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
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
    public partial class FrmReporteEntradas : Form
    {
        public int idSocio;
        public DateTime fechaInicioBusqueda;
        public DateTime fechaFinBusqueda;
        public FrmReporteEntradas()
        {
            InitializeComponent();
        }

        private void FrmReporteEntradas_Load(object sender, EventArgs e)
        {
     
        }

        private void FrmReporteEntradas_Load_1(object sender, EventArgs e)
        {

            ConnectionInfo cn = new ConnectionInfo();
            cn.ServerName = "LAPTOP-QIDIFK7G";
            cn.DatabaseName = "Tgcontrol";
            cn.UserID = "sa";
            cn.Password = "sqlserver.2018";
            cn.Type = ConnectionInfoType.SQL;
            

            switch (Login.opcionReporte)
            {

                case 1:
                    CREntradas reporteEntradas = new CREntradas();
                    reporteEntradas.SetParameterValue("@idSocio", idSocio);
                    reporteEntradas.SetParameterValue("@FechaInicioBusqueda", fechaInicioBusqueda);
                    reporteEntradas.SetParameterValue("@FechaFinBusqueda", fechaFinBusqueda);
                    SetDBLogonForReport(cn, reporteEntradas);
                    CRVreporteEntradas.ReportSource = reporteEntradas;
                    break;
                case 2:
                    CRHisObGenerales reporteHisObGenerales = new CRHisObGenerales();
                    reporteHisObGenerales.SetParameterValue("@idSocio", idSocio);
                    reporteHisObGenerales.SetParameterValue("@FechaInicioBusqueda", fechaInicioBusqueda);
                    reporteHisObGenerales.SetParameterValue("@FechaFinBusqueda", fechaFinBusqueda);
                    SetDBLogonForReport(cn, reporteHisObGenerales);
                    CRVreporteEntradas.ReportSource = reporteHisObGenerales;
                    break;
                case 3:
                    CRHisObCaja reporteHisObCaja = new CRHisObCaja();
                    reporteHisObCaja.SetParameterValue("@idSocio", idSocio);
                    reporteHisObCaja.SetParameterValue("@FechaInicioBusqueda", fechaInicioBusqueda);
                    reporteHisObCaja.SetParameterValue("@FechaFinBusqueda", fechaFinBusqueda);
                    SetDBLogonForReport(cn, reporteHisObCaja);
                    CRVreporteEntradas.ReportSource = reporteHisObCaja;
                    break;
                case 4:
                    CRVentas reporteVentas = new CRVentas();
                    reporteVentas.SetParameterValue("@FechaInicioBusqueda", fechaInicioBusqueda);
                    reporteVentas.SetParameterValue("@FechaFinBusqueda", fechaFinBusqueda);
                    SetDBLogonForReport(cn, reporteVentas);
                    CRVreporteEntradas.ReportSource = reporteVentas;
                    break;
                case 5:
                    CRHisObGeneralesID reporteHisObGeneralesID = new CRHisObGeneralesID();
                    reporteHisObGeneralesID.SetParameterValue("@idSocio", idSocio);
                    SetDBLogonForReport(cn, reporteHisObGeneralesID);
                    CRVreporteEntradas.ReportSource = reporteHisObGeneralesID;
                    break;
                case 6:
                    CRHisObCajaID reporteHisObCajaID = new CRHisObCajaID();
                    reporteHisObCajaID.SetParameterValue("@IdSocio", idSocio);
                    SetDBLogonForReport(cn, reporteHisObCajaID);
                    CRVreporteEntradas.ReportSource = reporteHisObCajaID;
                    break;
                case 7:
                    CRHisObGeneralesFecha reporteHisObGeneralesFecha = new CRHisObGeneralesFecha();
                    reporteHisObGeneralesFecha.SetParameterValue("@FechaInicioBusqueda", fechaInicioBusqueda);
                    reporteHisObGeneralesFecha.SetParameterValue("@FechaFinBusqueda", fechaFinBusqueda);
                    SetDBLogonForReport(cn, reporteHisObGeneralesFecha);
                    CRVreporteEntradas.ReportSource = reporteHisObGeneralesFecha;
                    break;
                case 8:
                    CRHisObCajaFecha reporteHisObCajaFecha = new CRHisObCajaFecha();
                    reporteHisObCajaFecha.SetParameterValue("@FechaInicioBusqueda", fechaInicioBusqueda);
                    reporteHisObCajaFecha.SetParameterValue("@FechaFinBusqueda", fechaFinBusqueda);
                    SetDBLogonForReport(cn, reporteHisObCajaFecha);
                    CRVreporteEntradas.ReportSource = reporteHisObCajaFecha;
                    break;
                case 9:
                    CRMovimientoCajaFecha reporteMovCajaFecha = new CRMovimientoCajaFecha();
                    reporteMovCajaFecha.SetParameterValue("@Fecha", fechaInicioBusqueda);
                    SetDBLogonForReport(cn, reporteMovCajaFecha);
                    CRVreporteEntradas.ReportSource = reporteMovCajaFecha;
                    break;
                case 10:
                    CRMovimientoCajaUsuario reporteMovCajaUsuario = new CRMovimientoCajaUsuario();
                    reporteMovCajaUsuario.SetParameterValue("@idUsuario", idSocio);
                    SetDBLogonForReport(cn, reporteMovCajaUsuario);
                    CRVreporteEntradas.ReportSource = reporteMovCajaUsuario;
                    break;
                default:
                    break;
            }

        }

        private void SetDBLogonForReport(ConnectionInfo connectionInfo, ReportDocument rptDocument)
        {
            Tables myTables = rptDocument.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table myTable in myTables)
            {
                TableLogOnInfo myTableLogonInfo = myTable.LogOnInfo;
                myTableLogonInfo.ConnectionInfo = connectionInfo;
                myTable.ApplyLogOnInfo(myTableLogonInfo);
            }
        }

        private void CRVreporteEntradas_Load(object sender, EventArgs e)
        {

        }
    }
}
