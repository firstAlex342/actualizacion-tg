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
    public partial class FrmReporteMovCaja : Form
    {
        public int idUsuario;
        public DateTime fecha;
        public int opc;
        public FrmReporteMovCaja()
        {
            InitializeComponent();
        }

        private void FrmReporteMovCaja_Load(object sender, EventArgs e)
        {
            ConnectionInfo cn = new ConnectionInfo();
            cn.ServerName = "LAPTOP-QIDIFK7G";
            cn.DatabaseName = "Tgcontrol";
            cn.UserID = "sa";
            cn.Password = "sqlserver.2018";
            cn.Type = ConnectionInfoType.SQL;

            CRMovCaja reporteCaja = new CRMovCaja();
            CRMovCajaFecha reporteCajaFecha = new CRMovCajaFecha();
            if (opc==1)
            {
                reporteCajaFecha.SetParameterValue("@FechaHora", fecha);
                SetDBLogonForReport(cn, reporteCajaFecha);
                crvMovCaja.ReportSource = reporteCajaFecha;
            }
            else if (opc==2)
            {
                reporteCaja.SetParameterValue("@idUsuario", idUsuario);
                SetDBLogonForReport(cn, reporteCaja);
                crvMovCaja.ReportSource = reporteCaja;
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
    }
}
