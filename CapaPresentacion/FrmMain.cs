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
using System.Collections;
using System.Media;

namespace CapaPresentacion
{
    public partial class FrmMain : Form
    {
        ClsGeneral cls_generales = new ClsGeneral();
        ClsSocios cls_socios = new ClsSocios();
        ClsLockers cls_lockers = new ClsLockers();
        SoundPlayer sonido = new SoundPlayer();
        ThreadStart delegado;
        Thread hilo;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmOperacion form3 = new FrmOperacion();

            form3.MdiParent = this.MdiParent;

            form3.Show();
        }

        private void FrmSocios_Load(object sender, EventArgs e)
        {
           
            //Creamos el delegado 
            delegado = new ThreadStart(llamarServidor);
            //Creamos la instancia del hilo 
            hilo = new Thread(delegado);
            //Iniciamos el hilo 
            hilo.Start();

            FrmOperacion abrir = new FrmOperacion();
            AbrirVentanas(abrir);

            /*******Enviar correo cumpleañeros********/
            DataTable dt = cls_socios.EnviarEmailCumpleañeros();

            if (dt.Rows.Count > 0)
            {
                ArrayList Correos = new ArrayList();
                string textoCorreo = "";
                string asunto = "";
                string respuestaM = "Correos a cumpleañeros enviado de forma correcta";
                string respuesta = "";

                foreach (DataRow filas in dt.Rows)
                {
                    Correos.Add(filas["Email"].ToString());
                    textoCorreo = filas["TextoCumpleAnos"].ToString();
                    asunto = filas["AsuntoCumpleanos"].ToString();
                }


                respuesta = cls_generales.EnviarCorreo(Correos, textoCorreo, asunto, respuestaM);
                MessageBox.Show(respuesta.ToString());
            }
        }

        private void nueviToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FrmOperacion abrir = new FrmOperacion();
            AbrirVentanas(abrir);
        }

        /***************************************/

        public void llamarServidor()
        {
            while (true)
            {
                int idSocio = Convert.ToInt32(cls_generales.Servidor());
                cls_lockers.m_idSocio = idSocio;
                string respuesta = cls_lockers.buscar_lockers_ocupados();
                //if(respuesta.Equals("1"))
                //{
                //    //sonido.Stream = Properties.Resources._02_01_04;
                //    //sonido.Play();
                //}


                cls_socios.m_IdSocio = idSocio ;
                DataTable dt = cls_socios.DatosSocio();
                Invoke(new MethodInvoker(delegate
                {
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns.RemoveAt(2);
                    foreach (DataRow filas in dt.Rows)
                    {
                        // MessageBox.Show(filas["Nombre"].ToString());

                        //txtNombre.Text = "hola";

                    
                            txtNombre.Text = filas["Nombre"].ToString();
                           /// txtFechaVencimiento.Text = filas["Vencimiento"].ToString().Substring(0, 10);
                            //  Ejemplo: Mostrar datos de los eventos
                            // enviados por el Thread en una ListBox

                   

                        //txtFechaVencimiento.BeginInvoke(new myDelegate(myMethod), new Object[] { 1, "This is the string" });
                    
                        byte[] imageBuffer = (byte[])filas["Foto"];
                        // Se crea un MemoryStream a partir de ese buffer
                        MemoryStream ms = new MemoryStream(imageBuffer);
                        // Se utiliza el MemoryStream para extraer la imagen
                        ptbImagenSocio.Image = Image.FromStream(ms);
                    
                    }

                }));


            }
        }


        public void AbrirVentanas(Form abrir)
        {
           // int x = (pPrincipal.Width - abrir.Width) / 2, y = (pPrincipal.Height - abrir.Height) / 2;
            foreach (Control c in pPrincipal.Controls)
            {
                
                if (c.Name == abrir.Name)
                {
                   // c.Location = new Point(x, y);
                    c.BringToFront();
                    c.Show();
                    return;
                }
                
            }
            //abrir.Location = new Point(x, y);
            abrir.TopLevel = false;
            pPrincipal.Controls.Add(abrir);
            abrir.BringToFront();
            abrir.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void deudasToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FrmOperacion abrir = new FrmOperacion();
            AbrirVentanas(abrir);
        }

        private void sociosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deudasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmDeudasSocios abrir = new FrmDeudasSocios();
            AbrirVentanas(abrir);
        }

        private void instructoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInstructores abrir = new FrmInstructores();
            AbrirVentanas(abrir);
        }

        private void entradasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBusquedaEntradas abrir = new FrmBusquedaEntradas();
            AbrirVentanas(abrir);
        }

        private void textoDeEmailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTextoEmails abrir = new FrmTextoEmails();
            AbrirVentanas(abrir);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void corteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("¿Seguro que desea salir?", "Continuar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                FrmLogin frm_login = new FrmLogin(true);

                FrmCorteSalida abrir = new FrmCorteSalida();
                abrir.ShowDialog();

                if (Login.cerrarSesion)
                {
                    FrmObservacion observacion = new FrmObservacion(2);
                    observacion.ShowDialog();
                    this.Hide();
                    hilo.Suspend();
                    frm_login = new FrmLogin(false);
                    frm_login.ShowDialog();
                   
                }
              

            }

           


        }

        private void cortesDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCortesCaja abrir = new FrmCortesCaja();
            AbrirVentanas(abrir);
        }

        private void observacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmObservacion abrir = new FrmObservacion(2);
            AbrirVentanas(abrir);
        }

        private void historialDeObservacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHistorialObservaciones abrir = new FrmHistorialObservaciones();
            AbrirVentanas(abrir);
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLogin frm_login = new FrmLogin(true);
            frm_login.ShowDialog();

            if (Login.superUsuario)
            {
                FrmUsuarios abrir = new FrmUsuarios();
                AbrirVentanas(abrir);
            }
           
        }

        private void ingresarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIngresarRetirar abrir = new FrmIngresarRetirar(1);
            AbrirVentanas(abrir);
        }

        private void retirarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIngresarRetirar abrir = new FrmIngresarRetirar(2);
            AbrirVentanas(abrir);
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVentas abrir = new FrmVentas();
            AbrirVentanas(abrir);
        }

        private void membresiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCatMemebresias frm_cat_membresias = new FrmCatMemebresias();
            AbrirVentanas(frm_cat_membresias);
            //frm_cat_membresias.Show();
        }

        private void movimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMovimientosEScaja abrir = new FrmMovimientosEScaja();
            AbrirVentanas(abrir);
        }

        private void cerrarCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCorteSalida abrir = new FrmCorteSalida();
            abrir.ShowDialog();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir?", "Continuar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                FrmLogin frm_login = new FrmLogin(true);

                    FrmCorteSalida abrir = new FrmCorteSalida();
                    abrir.ShowDialog();

                    if (Login.cerrarSesion)
                    {
                    FrmObservacion observacion = new FrmObservacion(2);
                    observacion.ShowDialog();
                    this.Hide();
                        hilo.Suspend();
                        frm_login = new FrmLogin(false);
                        frm_login.ShowDialog();
                        e.Cancel = false;
                    }
                e.Cancel = true;

            }

            else
            {
                e.Cancel = true;
            }
        }

        private void cancelarTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLogin frm_login = new FrmLogin(true);
            frm_login.ShowDialog();

            if (Login.superUsuario)
            {
               FrmCancelarTicket abrir = new FrmCancelarTicket("Cancelar");
                AbrirVentanas(abrir);
            }
        }

        private void emailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEmail frm_email = new FrmEmail();
            frm_email.ShowDialog();
        }

        private void conexionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            hilo.Suspend();
            FrmDatosConexion abrir = new FrmDatosConexion();
            abrir.ShowDialog();
        }

        private void claveMembresiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClvMembresias abrir = new FrmClvMembresias();
            abrir.Show();
        }

        private void lockersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLockers abrir = new FrmLockers();
            AbrirVentanas(abrir);
        }

        private void operacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOperacion abrir = new FrmOperacion();
            AbrirVentanas(abrir);
        }

        private void ticketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConfigTicket abrir = new FrmConfigTicket();
            abrir.ShowDialog();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCatProductos abrir = new FrmCatProductos();
            abrir.ShowDialog();
        }

        private void imprimirTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCancelarTicket abrir = new FrmCancelarTicket("Imprimir");
            abrir.ShowDialog();
        }
    }
}
