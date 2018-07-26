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
using CapaPresentacion;

namespace CapaPresentacion
{
    public partial class FrmLogin : Form
    {
        Login ini = new Login();
        ClsGeneral cls_generales = new ClsGeneral();
        ClsHdrVentaHist cls_hdr_venta_hist = new ClsHdrVentaHist();
        cambios cm = new cambios();
        
        
        bool validarSuperUsuario;

        public void guardarClave()
        {
            // la primera vez que se ejecuta, cambios.Settings esta vacio 

            //Presento formulario para pedir ingreso de serial
            FrmIntroduceSerial frmIntroduceSerial = new FrmIntroduceSerial();
            frmIntroduceSerial.ShowDialog(this);
            string serial = frmIntroduceSerial.Serial;
            frmIntroduceSerial.Dispose();

            //Recupero detalles de serial desde el servidor
            ClsSerial clsSerial = new ClsSerial();
            clsSerial.ClaveConexion = serial;
            DataTable respuestaTabla = clsSerial.RecuperarSerial();

            if (respuestaTabla.Rows.Count == 1)
            {
                //recupero el contenido de la unica fila del DataTable 
                DataRow fila = respuestaTabla.Rows[0];
                bool estadoClaveProducto = (fila["estadoClaveConexion"].ToString()) == "True" ? true : false;


                if (estadoClaveProducto)  //examino el estado de la clave
                {
                    //Modifico el estado de la clave y la fecha de vencimiento en la BD
                    clsSerial.EstadoClaveConexion = false;
                    clsSerial.ModificarEnSerial_FechaVencimientoDeClave_EstadoClave();


                    //Guardo valores en el archivo .settings local
                    DataTable otraRespuestaTabla = clsSerial.RecuperarSerial();
                    DataRow otraFila = otraRespuestaTabla.Rows[0];
                    cm.ClaveProducto = otraFila["claveConexion"].ToString();
                    cm.FechaVencimiento = otraFila["fechaVencimientoClaveConexion"].ToString();
                    cm.NumeroMensajesSMS = Int32.Parse(otraFila["numeroMensajesSMS"].ToString());
                    cm.Save();
                    cm.Reload();

                    MessageBox.Show("Se ha guardado serial de la aplicación", "Acerca de serial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Visible = false;
                    Application.Exit();
                }

                else
                {
                    MessageBox.Show("Serial no disponible", "Acerca de serial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Visible = false;
                    Application.Exit();
                }
            }

            else
            {
                MessageBox.Show("serial no valido", "Acerca de serial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Visible = false;
                Application.Exit();
            }
        }




        public FrmLogin(bool validarSuperUsuario)
        {
            Login.superUsuario = false;
            this.validarSuperUsuario = validarSuperUsuario;
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            //if(cm.FechaVencimiento=="")
            //{
            //    cm.ClaveProducto = "txt";
            //    cm.FechaVencimiento = "00/00/0000";
            //    cm.Save();
            //    MessageBox.Show("ventana configuracion");
            //}
            //else
            //{

            //}
            try
            {
                if (cm.FechaVencimiento == "")
                {
                    guardarClave();
                }


                else
                {
                    DateTime t = DateTime.Parse(cm.FechaVencimiento);
                    DataTable fechaActualEnServer = (new ClsSerial()).RecuperarFecha();  //recupero la fecha, solo es una fila con una columna
                    DataRow otraFila = fechaActualEnServer.Rows[0];
                    DateTime dTimeActualEnServer = DateTime.Parse(otraFila[0].ToString());

                    //dTimeActualEnServer = new DateTime(2018, 05, 30);
                    if (dTimeActualEnServer <= t)
                    {
                        //Serial vigente
                        Login.cantidadDescuento = 0;
                        Login.tipoPago = 2;
                        if (!validarSuperUsuario)
                        {
                            ClsGeneral.miPrimerSocket.Close();
                        }
                        else
                        {

                        }
                    }

                    else
                    {
                        //Serial vencio

                        MessageBox.Show("Serial vencio", "Acerca de Serial", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        //Presento formulario para pedir ingreso de serial
                        FrmIntroduceSerial frmIntroduceSerial = new FrmIntroduceSerial();
                        frmIntroduceSerial.ShowDialog(this);
                        string serial = frmIntroduceSerial.Serial;
                        frmIntroduceSerial.Dispose();

                        //Recupero detalles de serial desde el servidor
                        ClsSerial clsSerial = new ClsSerial();
                        clsSerial.ClaveConexion = serial;
                        DataTable respuestaTabla = clsSerial.RecuperarSerial();

                        if (respuestaTabla.Rows.Count == 1)
                        {
                            //recupero el contenido de la unica fila del DataTable 
                            DataRow fila = respuestaTabla.Rows[0];
                            bool estadoClaveProducto = (fila["estadoClaveConexion"].ToString()) == "True" ? true : false;


                            if (estadoClaveProducto)  //examino el estado de la clave
                            {
                                //Modifico el estado de la clave y la fecha de vencimiento en la BD
                                clsSerial.EstadoClaveConexion = false;
                                clsSerial.ModificarEnSerial_FechaVencimientoDeClave_EstadoClave();


                                //Guardo valores en el archivo .settings local
                                DataTable otraRespuestaTabla = clsSerial.RecuperarSerial();
                                DataRow otraFila2 = otraRespuestaTabla.Rows[0];
                                cm.ClaveProducto = otraFila2["claveConexion"].ToString();
                                cm.FechaVencimiento = otraFila2["fechaVencimientoClaveConexion"].ToString();
                                cm.NumeroMensajesSMS = Int32.Parse(otraFila2["numeroMensajesSMS"].ToString());
                                cm.Save();
                                cm.Reload();

                                MessageBox.Show("Se ha guardado serial de la aplicación", "Acerca de serial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Visible = false;
                                Application.Exit();
                            }

                            else
                            {
                                MessageBox.Show("serial no valido", "Acerca de serial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.Visible = false;
                                Application.Exit();
                            }
                        }

                        else
                        {
                            MessageBox.Show("serial no valido", "Acerca de serial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.Visible = false;
                            Application.Exit();
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                guardarClave();
                //MessageBox.Show(ex.Message);
                //MessageBox.Show(ex.Source);
                //MessageBox.Show("Error inesperado, la aplicación finalizara su ejecución");
                Application.Exit();
            }
        }

        private void CmdLogin_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.ingresar_login;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.ingresar_login_1;
        }

        public void ingresar()
        {
            ini.M_Login = TxtUsuario.Text;
            ini.M_Pass = TxtPassword.Text;
            DataTable dt = null;
            if (!validarSuperUsuario)
            {
                dt = ini.buscarUsuario();
            }
            else
            {
                dt = ini.buscarSuperUsuario();
            }


            int numeroFilas = dt.Rows.Count;

            if (numeroFilas == 1)
            {
                if (!validarSuperUsuario)
                {
                    foreach (DataRow filas in dt.Rows)
                    {
                        Login.idUsuario = Convert.ToInt32(filas["idUsuario"]);
                        Login.nombre = Convert.ToString(filas["Nombre"]);
                        
                    }

                    DataTable dt2 = cls_hdr_venta_hist.guardarVenta();
                    foreach (DataRow filas in dt2.Rows)
                    {
                        Login.num_ticket = Convert.ToInt32(filas["folioVenta"]);
                    }



                    this.Hide();
                    FrmObservacion abrir = new FrmObservacion(1);
                    abrir.Show();

                    //FrmCorteEntrada abrir = new FrmCorteEntrada();
                    //abrir.Show();

                    //FrmMain abrir = new FrmMain();
                    //abrir.Show();
                }
                else
                {
                    foreach (DataRow filas in dt.Rows)
                    {
                        Login.idSuperUsuario = Convert.ToInt32(filas["idUsuario"]);
                        Login.Supernombre = Convert.ToString(filas["Nombre"]);
                        Login.superUsuario = true;
                    }
                    this.Hide();
                }

            }

            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Usuario no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TxtPassword.Text = "";
                TxtUsuario.Text = "";
                TxtUsuario.Focus();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ingresar();
            //if (cls_generales.validarConexion())
            //{
            //    ingresar();
            //}
            //else
            //{
            //    if (MessageBox.Show("Error al conectar con la base de datos.\n¿Ver datos de conexion?", "Error de conexion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //    {
            //        this.Hide();
            //        FrmDatosConexion abrir = new FrmDatosConexion();
            //        abrir.ShowDialog();
            //    }
            //}
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            //VER.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DateTime thisDay = DateTime.Now;
            MessageBox.Show(thisDay.ToShortDateString());

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            //verReporte VER;
            //Datos DS = new Datos();
            //DS.MovimientoCaja.Rows.Add(1, 30.0, "prueba", "Fecha");
            //DS.MovimientoCaja.Rows.Add(1, 30.0, "prueba", "Fecha");
            //DS.MovimientoCaja.Rows.Add(1, 30.0, "prueba", "Fecha");
            //DS.MovimientoCaja.Rows.Add(1, 30.0, "prueba", "Fecha");
            //DS.MovimientoCaja.Rows.Add(1, 30.0, "prueba", "Fecha");
            //DS.MovimientoCaja.Rows.Add(1, 30.0, "prueba", "Fecha");
            //DS.MovimientoCaja.Rows.Add(1, 30.0, "prueba", "Fecha");
            //DS.MovimientoCaja.Rows.Add(1, 30.0, "prueba", "Fecha");
            //DS.MovimientoCaja.Rows.Add(1, 30.0, "prueba", "Fecha");

            //DS.MovimientoEfectivo.Rows.Add(1, "Efectivo", "prueba", 33);
            //DS.MovimientoEfectivo.Rows.Add(1, "Efectivo", "prueba", 33);
            //DS.MovimientoEfectivo.Rows.Add(1, "Efectivo", "prueba", 33);
            //DS.MovimientoEfectivo.Rows.Add(1, "Efectivo", "prueba", 33);
            //DS.MovimientoEfectivo.Rows.Add(1, "Efectivo", "prueba", 33);
            //DS.MovimientoEfectivo.Rows.Add(1, "Efectivo", "prueba", 33);
            //DS.MovimientoEfectivo.Rows.Add(1, "Efectivo", "prueba", 33);
            //DS.MovimientoEfectivo.Rows.Add(1, "Efectivo", "prueba", 33);
            //DS.MovimientoEfectivo.Rows.Add(1, "Efectivo", "prueba", 33);
            //DS.MovimientoEfectivo.Rows.Add(1, "Efectivo", "prueba", 33);
            //DS.MovimientoEfectivo.Rows.Add(1, "Efectivo", "prueba", 33);
            //DS.MovimientoEfectivo.Rows.Add(1, "Efectivo", "prueba", 33);

            //DS.MovimientoTarjeta.Rows.Add(1, "Tarjeta", "prueba", 33);
            //DS.MovimientoTarjeta.Rows.Add(1, "Tarjeta", "prueba", 33);
            //DS.MovimientoTarjeta.Rows.Add(1, "tARJETA", "prueba", 33);
            //DS.MovimientoTarjeta.Rows.Add(1, "Tarjeta", "prueba", 33);
            //DS.MovimientoTarjeta.Rows.Add(1, "Tarjeta", "prueba", 33);
            //DS.MovimientoTarjeta.Rows.Add(1, "tARJETA", "prueba", 33);
            //DS.MovimientoTarjeta.Rows.Add(1, "Tarjeta", "prueba", 33);
            //DS.MovimientoTarjeta.Rows.Add(1, "Tarjeta", "prueba", 33);
            //DS.MovimientoTarjeta.Rows.Add(1, "Tarjeta", "prueba", 33);
            //DS.MovimientoTarjeta.Rows.Add(1, "Tarjeta", "prueba", 33);
            //DS.MovimientoTarjeta.Rows.Add(1, "tARJETA", "prueba", 33);
            //DS.MovimientoTarjeta.Rows.Add(1, "tARJETA", "prueba", 33);

            //VER = new verReporte(DS.MovimientoEfectivo,DS.MovimientoTarjeta,DS.MovimientoCaja);
            //VER.Show();
        }

        private void TxtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if ((int)e.KeyCode == (int)Keys.Enter)
            {
                ingresar();
            }
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if ((int)e.KeyCode == (int)Keys.Enter)
            {
                ingresar();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            FrmDatosConexion abrir = new FrmDatosConexion();
            abrir.ShowDialog();
        }
    }
}
