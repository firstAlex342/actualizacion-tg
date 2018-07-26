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
using System.IO;
using System.Threading;
using System.IO.Ports;

namespace CapaPresentacion
{
    public partial class FrmVentanaEntradas : Form
    {
        ClsSocios cls_socios = new ClsSocios();
        ClsRegistroEntradas cls_registroEntradas = new ClsRegistroEntradas();
        ClsMovVentasHist cls_mov_ventas_hist = new ClsMovVentasHist();
        ClsLockers cls_lockers = new ClsLockers();

        // Con este objeto estableceremos las comunicaciones
        SerialPort PuertoCOM;
        // Nos ayudará a seleccionar que puertos mantener abiertos
        byte[] Valores = { 1, 2, 4, 8, 16, 32, 64, 128 };
        // el comando final que enviaremos en las comunicaciones
        byte Comando = 0;


        int numeroLocker;
        public FrmVentanaEntradas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //variable que recibe la respuesta del procedimiento almacenado
            //string respuesta;
            
            //cls_socios.m_IdSocio =Convert.ToInt32(textBox1.Text);
            //respuesta = cls_socios.ConsultarSocio();
            //if(respuesta.Equals("1"))
            //{
            //    cls_socios.conectarAlServidor(textBox1.Text);
            //}

            //else
            //{
            //    MessageBox.Show("La es incorrecta");
            //}
        }

        private void FrmVentanaEntradas_Load(object sender, EventArgs e)
        {
            txtClaveSocio.Focus();
            // Cargamos las interfaces de Puertos COM disponibles
            List<string> COMS = ((string[])SerialPort.GetPortNames()).ToList();
            foreach (string puerto_com in COMS)
            {
                cmb_puerto.Items.Add(puerto_com);
            }

            if (cmb_puerto.Items.Count > 0)
            {
                // seleccionamos un puerto por default
                cmb_puerto.SelectedIndex = 0;

                // creamos la primera tentativa de conexión
                // baudios = 9600
                // Paridad = None
                // Numero de bits = 8
                // Bits Parada = 1
                PuertoCOM = new SerialPort((string)cmb_puerto.SelectedItem, 9600, Parity.None, 8, StopBits.One);
                PuertoCOM.WriteTimeout = 30;

                // con este comando ponemos a trabajar a la tarjeta ics
                IniciarTarjetaICS();
            }

            // habilitamos en controles en función de que si hay un puerto disponible
            // tabs.Enabled = (cmb_puerto.Items.Count > 0);

            // Establecemos el intervalo de tiempo
            timer1.Interval = (int)(2 * 1000);
            // Crea el valor adecuado para activar este relay
            Comando += Valores[0];
            ActivarPuertosICS(Comando);
            // Activamos y habilitamos el timer
            timer1.Enabled = true;
            timer1.Start();
        }

        private void IniciarTarjetaICS()
        {
            // nos aseguramos que el puerto esté cerrado
            if (PuertoCOM == null) { return; }
            if (PuertoCOM.IsOpen) { PuertoCOM.Close(); }
            // Rutina para iniciar comunicaciones con la tarjeta 
            // enviar cada vez que la tarjeta sea conectada
            PuertoCOM.Open(); EscribirByteSerial(PuertoCOM, 0x50); PuertoCOM.Close();
            PuertoCOM.Open(); EscribirByteSerial(PuertoCOM, 0x51); PuertoCOM.Close();
            PuertoCOM.Open(); EscribirByteSerial(PuertoCOM, 0x00); PuertoCOM.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void imprimirDatosSocio(Color color)
        {
            DataTable dt = cls_socios.DatosSocio();

            foreach (DataRow filas in dt.Rows)
            {
                txtNombreSocio.Text = filas["Nombre"].ToString();
                txtFechaVencimiento.Text = filas["Vencimiento"].ToString().Substring(0,10);
                byte[] imageBuffer = (byte[])filas["Foto"];
                // Se crea un MemoryStream a partir de ese buffer
                MemoryStream ms = new MemoryStream(imageBuffer);
                // Se utiliza el MemoryStream para extraer la imagen
                pictureBox2.Image = Image.FromStream(ms);

                txtClaveSocio.Text = "";
             }

            this.BackColor = color;
           
            cls_lockers.m_idSocio = numeroLocker;
           string respuesta = cls_lockers.buscar_lockers_ocupados();
           // MessageBox.Show(respuesta);
            //cls_socios.conectarAlServidor(Convert.ToInt32(txtClaveSocio.Text));

        }

        private void limpiarFormulario()
        {
            txtClaveSocio.Text = "";
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                string respuesta;

                cls_socios.m_IdSocio = Convert.ToInt32(txtClaveSocio.Text);
                respuesta = cls_socios.ConsultarSocio();
                if (respuesta.Equals("1"))                
                {
                   
                    imprimirDatosSocio(Color.Firebrick);

                }

                else if(respuesta.Equals("2"))
                {
                    this.BackColor = Color.Firebrick;
                    imprimirDatosSocio(Color.Gold);
                }

                else if(respuesta.Equals("3"))
                {
                    
                    imprimirDatosSocio(Color.Firebrick);
                    limpiarFormulario();
                }

                else
                {
                    this.BackColor = Color.Firebrick;
                    limpiarFormulario();
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        public void buscarSocio(int tipoBusqueda)
        {
            cls_socios.m_IdSocio = Convert.ToInt32(txtClaveSocio.Text.Replace("*", ""));
            DataTable dt = cls_socios.RegresaSocio();
            foreach (DataRow filas in dt.Rows)
            {
                txtNombreSocio.Text = filas["Nombre"].ToString();
                txtFechaVencimiento.Text = filas["Vencimiento"].ToString();
                if(tipoBusqueda ==1)
                {
                    if(filas["DiasViajero"].ToString().Equals("") || Convert.ToInt32(filas["DiasViajero"].ToString()) <=0)
                    {
                        txtNumEntradas.Text = "";
                    }
                    else
                    {
                        filas["DiasViajero"].ToString();
                    }
                }

                    byte[] imageBuffer = (byte[])filas["Foto"];
                    // Se crea un MemoryStream a partir de ese buffer
                    MemoryStream ms = new MemoryStream(imageBuffer);
                    // Se utiliza el MemoryStream para extraer la imagen
                    //PbFotoSocio.Image = Image.FromStream(ms);
                    pictureBox2.Image = Image.FromStream(ms);
                    txtObservacion.Text = filas["Observacion"].ToString();
            }
        }

        public void buscarVenta(string[] numArreglo)
        {
            if (numArreglo.Length > 1)
            {
                if(numArreglo[1].Equals(""))
                {
                    cls_mov_ventas_hist.m_Recnum = Convert.ToInt32(numArreglo[0].ToString());
                }
                else
                {
                    cls_mov_ventas_hist.m_Recnum = Convert.ToInt32(numArreglo[1].ToString());
                }
                
                DataTable dt2 = cls_mov_ventas_hist.movVentasHistBuscarVenta();

                foreach (DataRow filas in dt2.Rows)
                {

                    txtFechaVencimiento.Text = filas["fechaVencimiento"].ToString();
                    txtNumEntradas.Text = "";
                    if (filas["diasViajero"].ToString().Equals("True"))
                    {
                        txtNumEntradas.Text = filas["numDiasViajero"].ToString();
                    }
                    
                   
                }

            }
        }

        private void ActivarPuertosICS(byte Valor)
        {
            // Cambiamos el byte que solicita la tarjeta para activar o desactivar relays
            PuertoCOM.Open();
            EscribirByteSerial(PuertoCOM, Valor);
            PuertoCOM.Close();
        }
        private bool EscribirByteSerial(SerialPort Puerto, byte Byte)
        {
            // traduce el comando a texto para que pueda enviarse por el objeto de PuertoCOM
            try
            {
                string Enviar = "";
                Enviar += Convert.ToChar(Byte);
                Puerto.Write(Enviar);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void txtClaveSocio_KeyDown(object sender, KeyEventArgs e)
        {
            if ((int)e.KeyCode == (int)Keys.Enter)
            {

                try
                {

                    if (txtClaveSocio.UseSystemPasswordChar)
                    {
                        // desabilitamos el timer
                        timer1.Enabled = false;
                        timer1.Stop();
                        // Crea el valor adecuado para desactivar este relay
                        Comando -= Valores[0];
                        ActivarPuertosICS(Comando);

                        // Establecemos el intervalo de tiempo
                        timer1.Interval = (int)(2 * 1000);
                        // Crea el valor adecuado para activar este relay
                        Comando += Valores[0];
                        ActivarPuertosICS(Comando);
                        // Activamos y habilitamos el timer
                        timer1.Enabled = true;
                        timer1.Start();
                        txtClaveSocio.Text = "";
                        txtClaveSocio.Focus();
                    }

                    else if (txtClaveSocio.Text.Equals(""))
                    {
                        MessageBox.Show("Ingresar el Id del socio");
                    }
                    else
                    {


                        lblMembresiaFueraDiaHora.Visible = false;
                        cls_socios.IdSocioText = txtClaveSocio.Text.ToString();
                        string respuesta = cls_socios.catSociosValidarEntrada();


                        char[] delimiters = { ',' };
                        string[] numArreglo = respuesta.Split(delimiters);

                        if (numArreglo.Length > 1)
                        {
                            if (numArreglo[1] == "")
                            {
                                respuesta = "0";
                            }
                            else
                            {
                                respuesta = numArreglo[0].ToString();
                            }

                        }


                        //el horario de entrada o el dia de entrada no son validos
                        if (respuesta.Equals("6"))
                        {
                            lblMembresiaFueraDiaHora.Text = "El SOCIO INGRESADO NO EXISTE";
                            lblMembresiaFueraDiaHora.Visible = true;
                        }
                        else if (respuesta.Equals("7"))
                        {
                            lblMembresiaFueraDiaHora.Text = "MEMBRESIA FUERA DE DIA O DE HORARIO";
                            lblMembresiaFueraDiaHora.Visible = true;
                        }
                        else if (respuesta.Equals("1") || respuesta.Equals("3") || respuesta.Equals("4") || respuesta.Equals("2"))
                        {
                            buscarSocio(1);
                            buscarVenta(numArreglo);
                            cls_lockers.m_idSocio = Convert.ToInt32(txtClaveSocio.Text.Replace("*", ""));
                            DataTable dt3 = cls_lockers.unSociosLockersBuscarSocio();
                            foreach (DataRow filas in dt3.Rows)
                            {

                                txtLocker.Text = filas["Descripcion"].ToString();

                            }
                            if (respuesta.Equals("2"))
                            {
                                lblMembresiaFueraDiaHora.Text = "SU LOCKER SE ENCUENTA VENCIDO";
                                lblMembresiaFueraDiaHora.Visible = true;
                            }
                            else
                            {
                                this.BackColor = Color.Red;
                            }



                        }
                        else if (respuesta.Equals("0"))
                        {

                            buscarSocio(0);
                            buscarVenta(numArreglo);
                            this.BackColor = Color.ForestGreen;
                            cls_lockers.m_idSocio = Convert.ToInt32(txtClaveSocio.Text.Replace("*", ""));
                            DataTable dt3 = cls_lockers.unSociosLockersBuscarSocio();
                            foreach (DataRow filas in dt3.Rows)
                            {

                                txtLocker.Text = filas["Descripcion"].ToString();

                            }
                            // desabilitamos el timer
                            timer1.Enabled = false;
                            timer1.Stop();
                            // Crea el valor adecuado para desactivar este relay
                            Comando -= Valores[0];
                            ActivarPuertosICS(Comando);

                            // Establecemos el intervalo de tiempo
                            timer1.Interval = (int)(2 * 1000);
                            // Crea el valor adecuado para activar este relay
                            Comando += Valores[0];
                            ActivarPuertosICS(Comando);
                            // Activamos y habilitamos el timer
                            timer1.Enabled = true;
                            timer1.Start();
                        }


                        txtClaveSocio.Text = "";
                    }

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

               
                

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //double total = Convert.ToDouble(lblTimer.Text);
            //total += 1;
            //lblTimer.Text = total.ToString();
            //if(lblTimer.Text.Equals("2"))
            //{
            //    //timer1.Enabled = false;
            //    timer1.Stop();
            //    // Crea el valor adecuado para desactivar este relay
            //    Comando -= Valores[0];
            //    ActivarPuertosICS(Comando);
            //    lblTimer.Text = "1";
            //}
        }

        private void txtClaveSocio_TextChanged(object sender, EventArgs e)
        {

            if (txtClaveSocio.Text != "")
            {
                if (txtClaveSocio.Text[0].ToString().Equals("/"))
                {
                    txtClaveSocio.UseSystemPasswordChar = true;
                    txtClaveSocio.Select(txtClaveSocio.Text.Length, 0);
                }

            }
            else
            {
                txtClaveSocio.UseSystemPasswordChar = false;
            }
        }
    }
}
