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
    public partial class FrmCancelarTicket : Form
    {
        ClsHdrVentaHist cls_hdr_venta_hist = new ClsHdrVentaHist();
        ClsGeneral cls_generales = new ClsGeneral();
        string textoBoton;
        public FrmCancelarTicket(string textoBoton)
        {
            this.textoBoton = textoBoton;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtNumTicket.Text.Equals(""))
            {
                MessageBox.Show("Favor de ingresar el numero de ticket");
            }
            else
            {
                string numeroMes = "";
                switch (comboBox1.Text.ToString())
                {
                    case "Enero":
                        numeroMes = "01";
                        break;
                    case "Febrero":
                        numeroMes = "02";
                        break;
                    case "Marzo":
                        numeroMes = "03";
                        break;
                    case "Abril":
                        numeroMes = "04";
                        break;
                    case "Mayo":
                        numeroMes = "05";
                        break;
                    case "Junio":
                        numeroMes = "06";
                        break;
                    case "Julio":
                        numeroMes = "07";
                        break;
                    case "Agosto":
                        numeroMes = "08";
                        break;
                    case "Septiembre":
                        numeroMes = "09";
                        break;
                    case "Octubre":
                        numeroMes = "10";
                        break;
                    case "Noviembre":
                        numeroMes = "11";
                        break;
                    case "Diciembre":
                        numeroMes = "12";
                        break;

                }

                DateTime fechaActual = DateTime.Today;
                string año = fechaActual.Year.ToString();


                cls_hdr_venta_hist.m_FolioVenta = Convert.ToInt32(txtNumTicket.Text);
                cls_hdr_venta_hist.Fecha = Convert.ToDateTime("01/" + numeroMes + "/" + año);

                if(button1.Text.Equals("Cancelar"))
                {
                    string respuesta = cls_hdr_venta_hist.cancelarTicket();
                    MessageBox.Show(respuesta);

                    if (respuesta.Equals("Ticket cancelado de forma correcta"))
                    {
                        this.Hide();
                    }
                }
                else
                {
                    DataTable dt = cls_hdr_venta_hist.buscarTicket();
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No se encontro ticket ingresado");
                    }
                    else
                    {
                        verReporte VER;
                        Datos DS = new Datos();
                        double SubtotalAPagar = 0;
                        foreach (DataRow filas in dt.Rows)
                        {
                            SubtotalAPagar += Convert.ToDouble(filas["Monto"]);
                        }
                        foreach (DataRow filas in dt.Rows)
                        {

                            DS.Tabla.Rows.Add(Login.nombre, filas["idSocio"].ToString(), filas["Nombre"], filas["Item"].ToString(), "$" + filas["Monto"].ToString(), cls_generales.enletras(SubtotalAPagar.ToString()), txtNumTicket.Text, "$" + SubtotalAPagar);
                        }
                        VER = new verReporte(DS.Tabla, null, null, null, null);
                        //VER.ShowDialog();
                    }
                }

                
               

              
            }
            
        }

        private void FrmCancelarTicket_Load(object sender, EventArgs e)
        {
            button1.Text = textoBoton;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
