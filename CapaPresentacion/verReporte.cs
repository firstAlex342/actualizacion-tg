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
    public partial class verReporte : Form
    {
        public verReporte(DataTable DT, DataTable DT2, DataTable DT3,DataTable DT4,DataTable DT5)
        {
            InitializeComponent();
            //Crear Objeto REPORTE
            if (DT3 != null && DT2 == null)
            {
                CRSociosVencidos RP = new CRSociosVencidos();
                RP.SetDataSource(DT3);
                //RP.PrintToPrinter(1, false, 0, 0);
                //crystalReportViewer1.ReportSource = RP;
                RP.PrintToPrinter(1, false, 0, 0);
            }

            else if (DT2 == null)
            {
                cambios cam = new cambios();
                CRTicketVenta RP = new CRTicketVenta();
                
                RP.SetDataSource(DT);
                RP.SetParameterValue("Titulo",cam.TituloTicket);
                RP.SetParameterValue("Linea1", cam.Linea1);
                RP.SetParameterValue("Linea2", cam.Linea2);
                RP.SetParameterValue("Linea3", cam.Linea3);
               // this.crystalReportViewer1.ReportSource = RP;
                RP.PrintToPrinter(1, false, 0, 0);
            }

            else if(DT2!=null)
            {
                CRTicketCorte2 RP = new CRTicketCorte2();
                RP.SetDataSource(DT);
                //CRTicketCorte RP = new CRTicketCorte();
                //RP.SetDataSource(DT4);
                //crystalReportViewer1.ReportSource = RP;
                //RP.Refresh();
                //if (DT2 != null)
                //{

                //    RP.Subreports[1].SetDataSource(DT);
                //    RP.Subreports[2].SetDataSource(DT2);
                //    RP.Subreports[3].SetDataSource(DT3);
                //    RP.Subreports[0].SetDataSource(DT5);
                //}
                //RP.SetParameterValue("idSocio",49);
                //crystalReportViewer1.ReportSource = RP;
                RP.PrintToPrinter(1, false, 0, 0);
            }

           
            //Asignar datos al reporte
            //Asignar reporte creado al visor de reportes
            
            

          //  RP2.SetDataSource(DT2);
            
            //RP.Subreports[1].SetDataSource(DT);
            


        }

        private void verReporte_Load(object sender, EventArgs e)
        {

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
