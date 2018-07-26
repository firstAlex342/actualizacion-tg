using System;
using System.Collections;
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
    public partial class FrmCorteSalida : Form
    {
        ClsCorteCaja cls_corte_caja = new ClsCorteCaja();
        ClsGeneral cls_generales = new ClsGeneral();
        double totalDinero;
        double dineroEnCaja;
        double totalEfectivoCaja;
        verReporte VER;
        Datos DS = new Datos();
        double total=0;
        public FrmCorteSalida()
        {
            InitializeComponent();
        }

        private void FrmCorteSalida_Load(object sender, EventArgs e)
        {
            Login.cerrarSesion = false;

            cls_corte_caja.m_idUsuario = Login.idUsuario;
            cls_corte_caja.m_user_modif = Login.nombre;

           DataTable dt = cls_corte_caja.sumaTotalCorte();
           totalEfectivoCaja = 0;
            foreach (DataRow filas in dt.Rows)
            {
                totalEfectivoCaja = Convert.ToDouble(filas["totalVentasEfectivo"].ToString()) + Convert.ToDouble(filas["totalMovimientoCaja"].ToString());
                txtDineroEfectivo.Text = totalEfectivoCaja.ToString();
                
                txtDineroTarjeta.Text = filas["totalVentasTarjeta"].ToString();
                totalDinero = totalEfectivoCaja + Convert.ToDouble(txtDineroTarjeta.Text);
            }

            dgvMovimientos.DataSource = cls_corte_caja.seleccionarMovimientosCajaCorte();
            dgvEfectivo.DataSource = cls_corte_caja.seleccionarMovimientosVentaEfectivo();
            dgvTarjetas.DataSource =  cls_corte_caja.seleccionarMovimientosVentaTarjeta();
            DataTable dtMovimientos = cls_corte_caja.seleccionarMovimientosCajaCorte();
            DataTable dtEfectivo = cls_corte_caja.seleccionarMovimientosVentaEfectivo();
            DataTable dtTarjeta = cls_corte_caja.seleccionarMovimientosVentaTarjeta();
            DataTable dtRetiro = cls_corte_caja.seleccionarMovimientoRetiroCaja();

            DataTable dtCorteFinal = cls_corte_caja.seleccionarCorte();
            string textoCorreo = "";
            double Total = 0;
            foreach (DataRow filas in dtCorteFinal.Rows)
            {
                Total += Convert.ToDouble(filas["Monto"].ToString());
            }
            foreach (DataRow filas in dtCorteFinal.Rows)
            {
                textoCorreo +="Folio venta:"+filas["FolioVenta"].ToString()+"<br>";
                textoCorreo +="Desc: "+ filas["Item"].ToString() + "<br>";
                textoCorreo += "Monto:" + filas["Monto"].ToString() + "<br>";
                textoCorreo += "________ <br>";
                string item = filas["FolioVenta"]+": "+filas["Item"].ToString().Replace("12:00:00 a. m.","");
                double monto = Convert.ToDouble(filas["Monto"].ToString());
                string tipoPago = filas["tipoPago"].ToString().Equals("True") ? "Tarjeta" : "Efectivo";

                DS.Corte.Rows.Add(item,"$"+monto.ToString("N2"),"$" + Total.ToString("N2"),tipoPago);
            }

                foreach (DataRow filas in dtMovimientos.Rows)
            {
                int idMovimientoCaja = Convert.ToInt32(filas["idMovimientoCaja"].ToString());
                double cantidad = Convert.ToDouble(filas["cantidad"].ToString());
                total += cantidad;
                string detalle = filas["detalle"].ToString();
                string Fecha = filas["Fecha"].ToString();
                DS.MovimientoCaja.Rows.Add(idMovimientoCaja, cantidad, detalle, Fecha);
            }

            foreach (DataRow filas in dtEfectivo.Rows)
            {
                int FolioVenta = Convert.ToInt32(filas["FolioVenta"].ToString());
                string User_modif = filas["User_modif"].ToString();
                string FechaMovimiento = filas["FechaMovimiento"].ToString();
                double Total1 = Convert.ToDouble(filas["Subtotal"].ToString());
                total += Total;
                DS.MovimientoEfectivo.Rows.Add(FolioVenta, User_modif, FechaMovimiento,Total);
            }

            foreach (DataRow filas in dtTarjeta.Rows)
            {
                int FolioVenta = Convert.ToInt32(filas["FolioVenta"].ToString());
                string User_modif = filas["User_modif"].ToString();
                string FechaMovimiento = filas["FechaMovimiento"].ToString();
                double Total1 = Convert.ToDouble(filas["Subtotal"].ToString());
                total += Total;
                DS.MovimientoTarjeta.Rows.Add(FolioVenta, User_modif, FechaMovimiento, Total);
            }

            foreach (DataRow filas in dtRetiro.Rows)
            {
                int idMovimientoCaja = Convert.ToInt32(filas["idMovimientoCaja"].ToString());
                double cantidad = Convert.ToDouble(filas["cantidad"].ToString());
                total -= cantidad;
                string detalle = filas["detalle"].ToString();
                string Fecha = filas["Fecha"].ToString();
                DS.RetiroEfectivo.Rows.Add(idMovimientoCaja, cantidad, detalle, Fecha);
            }

            textoCorreo += "<b>Total: </b> " + Total.ToString();

            ArrayList email = new ArrayList();
            cambios cb = new cambios();
            email.Add(cb.Correo);
            cls_generales.EnviarCorreo(email, textoCorreo, "Corte Total Gym", "");
            

            txtDineroEfectivo.Text = Total.ToString();

            DS.TotalTicket.Rows.Add(total);
            VER = new verReporte(DS.Corte, DS.MovimientoTarjeta, DS.MovimientoCaja, DS.TotalTicket, DS.RetiroEfectivo);
           //VER.ShowDialog();

        }

        public void guardarMovimiento()
        {
            cls_corte_caja.m_Supervisor = "Super Usuario";
            cls_corte_caja.m_idUsuario = Login.idUsuario;
            cls_corte_caja.m_totalCaja = totalEfectivoCaja;
            cls_corte_caja.m_totalTarjeta = Convert.ToDouble(txtDineroTarjeta.Text);
            cls_corte_caja.m_totalCorte = dineroEnCaja;
            string respuesta = cls_corte_caja.movimientoCorteCajaEntrada();
            MessageBox.Show(respuesta);
            Login.cerrarSesion = true;  
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           dineroEnCaja = Convert.ToDouble(txtDineroSalida.Text);
            if(totalDinero>dineroEnCaja)
            {
                if (MessageBox.Show("El dinero en caja es menor. \n ¿Seguro que desea continuar?", "Continuar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                   guardarMovimiento();
                }
            }
            else
            {
                if (MessageBox.Show("¿Realizar corte?", "Continuar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                   guardarMovimiento();
            }

            
            //double dineroCaja = Convert.ToDouble(txtDineroEfectivo.Text);
            //double dineroSalida = Convert.ToDouble(txtDineroSalida.Text);
            //cls_corte_caja.m_Supervisor = "supervisor";
            //cls_corte_caja.m_cantidadCorte = dineroSalida;

            //if (dineroCaja > dineroSalida)
            //{
            //    MessageBox.Show("el dinero es menor");
            //}
            //else if(dineroCaja<=dineroSalida)
            //{
            //    MessageBox.Show("dinero correcto");
            //    cls_corte_caja.cerrarCaja();
            //    MessageBox.Show("bien");
            //    this.Hide();
            //    Login.tipoObservacion = 2;
            //    FrmObservacion observacion = new FrmObservacion(3);
            //    observacion.ShowDialog();
            //}
        }
    }
}
