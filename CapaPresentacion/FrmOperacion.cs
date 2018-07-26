using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using CapaAccesoDatos;
using CapaLogicaNegocios;
using System.IO;
using System.Threading;
using System.Media;
using System.Drawing.Printing;
using System.Collections;
using System.Text.RegularExpressions;

namespace CapaPresentacion
{
    public partial class FrmOperacion : Form
    {
        ClsGeneral cls_generales = new ClsGeneral();
        ClsObservaciones cls_observaciones = new ClsObservaciones();
        ClsSocios cls_socios = new ClsSocios();
        ClsLockers cls_lockers = new ClsLockers();
        ClsMembresias cls_membresias = new ClsMembresias();
        SoundPlayer sonido = new SoundPlayer();
        ClsHdrVentaHist cls_hdr_venta_hist = new ClsHdrVentaHist();
        ClsMovVentasHist cls_mov_ventas_hist = new ClsMovVentasHist();
        ClsProductos cls_productos = new ClsProductos();
        ClsMovVisitas cls_mov_visitas = new ClsMovVisitas();
        List<datosVenta> lista_datos_venta = new List<datosVenta>();
        
        DataTable dt;
        bool cortesiaVisita;
        double monto;
        string concepto;
        double SubtotalAPagar;
        int idSocio;
        int FolioVenta;
        int numero_fila;
        int periodoLocker = 0;
        DateTime fechaVencimiento;
        int claveTipoMembresia;
        int folioVenta;
        bool nuevoSocio;
        public FrmOperacion()
        {
            InitializeComponent();
        }

        private Font fuente = new Font("Arial", 12);

        //A continuacion se agregara el siguiente método
        public void Imprimir_Solicitud()
        {

            //Este método contiene dos componentes muy importantes los cuales son:

            //PrintDocument y printDialog estos métodos definen las propiedades de impresión

            //como son: numero de copias, numero de paginas y seleccionar tipo de impresora
            PrintDocument formulario = new PrintDocument();
            formulario.PrintPage += new PrintPageEventHandler(Datos_Cliente);
            PrintDialog printDialog1 = new PrintDialog();
            printDialog1.Document = formulario;
            DialogResult result = printDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                formulario.Print();
            }
        }

        //los datos de nuestros clientes y la posición de los mismos en el documento
        private void Datos_Cliente(object obj, PrintPageEventArgs ev)
        {
            float pos_x = 10;
            float pos_y = 20;
            string Nombre = "Nombre aqui";
            string Direccion = "Direccion aqui";
            string Telefono = "Telefono aqui";

            //Lo que vamos a imprimir
            //Estas 3 prmieras lineas de codigo son las que definen los datos del cliente
            ev.Graphics.DrawString("Nombre: ", fuente, Brushes.Black, pos_x, pos_y, new
            StringFormat());
            ev.Graphics.DrawString("Direccion: ", fuente, Brushes.Black, pos_x, pos_y + 15, new
            StringFormat());
            ev.Graphics.DrawString("Telefono: ", fuente, Brushes.Black, pos_x, pos_y + 30, new
            StringFormat());
            //Estas ultimas 3 lineas de codigo son las que capturamos en nuestro formulario
            ev.Graphics.DrawString(Nombre, fuente, Brushes.Black, pos_x + 65, pos_y, new
            StringFormat());
            ev.Graphics.DrawString(Direccion, fuente, Brushes.Black, pos_x + 75, pos_y + 15, new
            StringFormat());
            ev.Graphics.DrawString(Telefono, fuente, Brushes.Black, pos_x + 80, pos_y + 30, new
            StringFormat());
        }





        private void validarControles(bool bandera)
        {
            TxtNombreSocio.Enabled = bandera;
            TxtDireccion1.Enabled = bandera;
            TxtDireccion2.Enabled = bandera;
            mktCelular.Enabled = bandera;
            TxtEmail.Enabled = bandera;
            RDmasculino.Enabled = bandera;
            RDsexoFem.Enabled = bandera;
            //cbbLockers.Enabled = bandera;
            mktFechaNacimiento.Enabled = bandera;
            btnIniciar.Enabled = bandera;
            txtComentario.Enabled = bandera;

        }

        private void FrmOperacion_Load(object sender, EventArgs e)
        {
            
            BuscarDispositivos();
            llenarComboMembresias();
            llenarComboProductos();
            cboDispositivos.Visible = false;
            llenarcomboTipoMembresiaLocker();

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
        private void txtSoloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            //if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            //{
            //    MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    e.Handled = true;
            //    return;
            //}
               

        }

        void validarGBX()
        {
            if(!btnModificarSocio.Text.Equals("Guardar Modificacion"))
            {
                bool bandera = true;
                string texto = mktFechaNacimiento.Text.Replace("_", "");
                if (TxtNombreSocio.Text.Equals(""))
                {
                    bandera = false;
                }

                if (TxtDireccion1.Text.Equals("") && TxtDireccion2.Text.Equals(""))
                {
                    bandera = false;
                }

                if (mktCelular.Text.Equals(""))
                {
                    bandera = false;
                }

                if (TxtEmail.Text.Equals(""))
                {
                    bandera = false;
                }

                if (RDmasculino.Checked == false && RDsexoFem.Checked == false)
                {
                    bandera = false;
                }

                if (pbFotoUser.Image == null)
                {
                    bandera = false;
                }

                if (texto.Length < 10)
                {
                    bandera = false;
                }


                if (bandera)
                {

                    gbxMembresia.Enabled = true;


                }
                else
                {
                    gbxMembresia.Enabled = false;
                }
            }
               

               
            


        }

        //*******************************  agregamos los controles para la camara

        private bool ExistenDispositivos = false;
        private FilterInfoCollection DispositivosDeVideo;
        private VideoCaptureDevice FuenteDeVideo = null;
        private void capturarImagen()
        {
            TerminarFuenteDeVideo();
            btnIniciar.Text = "Tomar foto";
            cboDispositivos.Enabled = true;
            validarGBX();
        }
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (btnIniciar.Text == "Tomar foto")
            {
                if (ExistenDispositivos)
                {
                    FuenteDeVideo = new VideoCaptureDevice(DispositivosDeVideo[cboDispositivos.SelectedIndex].MonikerString);
                    FuenteDeVideo.NewFrame += new NewFrameEventHandler(video_NuevoFrame);
                    FuenteDeVideo.Start();
                    btnIniciar.Text = "Tomar";
                    cboDispositivos.Enabled = false;
                    //gbMenu.Text = DispositivosDeVideo[cboDispositivos.SelectedIndex].Name.ToString();
                    btnCancelarCamara.Enabled = true;
                }
                else
                    MessageBox.Show("Error: No se encuentra dispositivo.");



            }
            else
            {
                if (FuenteDeVideo.IsRunning)
                {
                    capturarImagen();
                    btnCancelarCamara.Enabled = false;
                }
            }
        }

        public void CargarDispositivos(FilterInfoCollection Dispositivos)
        {
            for (int i = 0; i < Dispositivos.Count; i++)
                cboDispositivos.Items.Add(Dispositivos[i].Name.ToString()); //cboDispositivos es nuestro combobox
            cboDispositivos.Text = cboDispositivos.Items[0].ToString();
        }

        public void BuscarDispositivos()
        {
            DispositivosDeVideo = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (DispositivosDeVideo.Count == 0)
                ExistenDispositivos = false;
            else
            {
                ExistenDispositivos = true;
                CargarDispositivos(DispositivosDeVideo);
            }
        }

        public void TerminarFuenteDeVideo()
        {
            if (!(FuenteDeVideo == null))
                if (FuenteDeVideo.IsRunning)
                {
                    FuenteDeVideo.SignalToStop();
                    FuenteDeVideo = null;
                }
        }

        private void video_NuevoFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap Imagen = (Bitmap)eventArgs.Frame.Clone();
            pbFotoUser.Image = Imagen; //pbFotoUser es nuestro pictureBox
        }

        private void btnIniciar_Click_1(object sender, EventArgs e)
        {

        }

        private void cboDispositivos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TstCmdAgregarUsr_Click(object sender, EventArgs e)
        {

        }

        //FUNCION PARA CONVERTIR LA IMAGEN A BYTES

        public Byte[] Imagen_A_Bytes(String ruta)

        {

            FileStream foto = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            Byte[] arreglo = new Byte[foto.Length];

            BinaryReader reader = new BinaryReader(foto);

            arreglo = reader.ReadBytes(Convert.ToInt32(foto.Length));

            return arreglo;

        }

        //FUNCION PARA CONVERTIR DE BYTES A IMAGEN

        public Image Bytes_A_Imagen(Byte[] ImgBytes)

        {

            Bitmap imagen = null;

            Byte[] bytes = (Byte[])(ImgBytes);

            MemoryStream ms = new MemoryStream(bytes);

            imagen = new Bitmap(ms);

            return imagen;

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (btnAgregarUsuario.Text.Equals("N. socio"))
            {
                // TstCmdAgrefarUsr.Text = "Guardar nuevo socio";
                nuevoSocio = true;
                LimpiaFormulario();
                gbxMembresia.Enabled = false;
                validarControles(true);
                dtpVencimientoViajero.Value = DateTime.Today;
                fechaVencimiento = DateTime.Today;
                DataTable dt = cls_socios.catSociosNuevoIdSocio();
                foreach (DataRow filas in dt.Rows)
                {
                    TxtIdSocio.Text = filas["id"].ToString();
                }
                botones(false);
            }

            //else if (btnAgregarUsuario.Text.Equals("Guardar nuevo socio"))
            //{

                
            //}






        }

        private void cargar_locker(int idSocio)
        {
            cls_lockers.m_idLocker = Convert.ToInt32(cbbLockers.SelectedValue.ToString());
            cls_lockers.m_Descripcion = cbbLockers.Text;
            cls_lockers.m_Sexo = 'M';
            cls_lockers.m_fechaVencimiento = DTPLockerVence.Value;
            cls_lockers.m_Status = 'S';
            cls_lockers.m_idSocio = idSocio;
            cls_lockers.numeroDias = periodoLocker;
            cls_lockers.m_User_modif = Login.nombre;
            cls_lockers.Tipo = 1;
            cls_lockers.modificar_locker();
        }

        private void TSTxtBuscaSocio_Click(object sender, EventArgs e)
        {

        }

        private void buscarSocio()
        {
            DateTime thisDay = DateTime.Today;
            ClsSocios Socio = new ClsSocios();
            dt = new DataTable();
            int result=3;
            string fechaDeVencimiento = "";


            DataTable dt2 = new DataTable();


            long NoSocio;
            NoSocio = Int64.Parse(TSTxtBuscaSocio.Text);
            Socio.m_IdSocio = NoSocio;
            dt = Socio.RegresaSocio();


            dt2 = Socio.buscar_socio_con_vencimiento();

            foreach (DataRow filas in dt2.Rows)
            {

                fechaVencimiento = Convert.ToDateTime(filas["fechaVencimiento"].ToString());
                fechaDeVencimiento = filas["fechaVencimiento"].ToString();
                result = DateTime.Compare(fechaVencimiento, thisDay);
            }



            if (dt.Rows.Count != 0)
            {

                foreach (DataRow filas in dt.Rows)
                {

                    // indice de columnas 
                    //IdSocio 0
                    TxtIdSocio.Text = filas["IdSocio"].ToString();
                    //[FotoId] 1
                    //[Fingerprint] 2
                    //[Nombre] 3
                    TxtNombreSocio.Text = filas["Nombre"].ToString();
                    //[Direccion1] 4
                    TxtDireccion1.Text = filas["Direccion1"].ToString();
                    //[Direccion2] 5
                    TxtDireccion2.Text = filas["Direccion2"].ToString();
                    //[Email] 6
                    TxtEmail.Text = filas["Email"].ToString();
                    //[Edad] 7 
                    //[Telefono] 8 
                    mktCelular.Text = filas["Telefono"].ToString();
                    //,[Sexo] 9
                    string Sexo;
                    Sexo = filas["Sexo"].ToString();
                    if (Sexo == "F")
                    {
                        RDsexoFem.Checked = true;
                        RDmasculino.Checked = false;
                    }
                    else
                    {
                        RDsexoFem.Checked = false;
                        RDmasculino.Checked = true;
                    }
                    
                    if(filas["Foto"].ToString()!="")
                    {
                        byte[] imageBuffer = (byte[])filas["Foto"];
                        // Se crea un MemoryStream a partir de ese buffer
                        MemoryStream ms = new MemoryStream(imageBuffer);
                        // Se utiliza el MemoryStream para extraer la imagen
                        //PbFotoSocio.Image = Image.FromStream(ms);
                        pbFotoUser.Image = Image.FromStream(ms);
                    }
                    
                    

                    //[fechaNacimiento] 20
                    //DTPFechaNac.Text = filas["fechaNacimiento"].ToString();
                    txtComentario.Text = filas["Observacion"].ToString();
                    mktFechaNacimiento.Text = filas["fechaNacimiento"].ToString();
                    if (!filas["Vencimiento"].ToString().Equals("01/01/1900 12:00:00 a. m."))
                    {
                        if(result==3)
                        {
                            fechaVencimiento = Convert.ToDateTime(filas["Vencimiento"].ToString());
                            dtpVencimientoViajero.Value = Convert.ToDateTime(filas["Vencimiento"].ToString());
                            dateTimePicker1.Value = Convert.ToDateTime(filas["FechaIngreso"].ToString());
                        }
                        else
                        {
                           
                            dtpVencimientoViajero.Value = Convert.ToDateTime(fechaDeVencimiento);
                            dateTimePicker1.Value = Convert.ToDateTime(filas["FechaIngreso"].ToString());
                        }
                        
                        
                    }

                    
                    
                }
                 cls_lockers.m_idSocio = Convert.ToInt32(TxtIdSocio.Text);
            DataTable dtLockerSocio = cls_lockers.unSociosLockersBuscarSocio();

            if(dtLockerSocio.Rows.Count>0)
            {
                foreach (DataRow filas in dtLockerSocio.Rows)
                {
                   // DTPLockerVence.Value = Convert.ToDateTime(filas["FechaVencimiento"].ToString());
                }
                    
            }
                cls_socios.m_IdSocio = Convert.ToInt32(TxtIdSocio.Text);
                dt = cls_socios.movimientosSocios();
                dataGridView1.DataSource = dt;
                dt = cls_socios.membresiasSocios();
                dataGridView2.DataSource = dt;
                dt = cls_socios.HistorialSocioAnterior();
                dataGridView3.DataSource = dt;
                cls_lockers.m_idSocio = Convert.ToInt32(TSTxtBuscaSocio.Text);
                // MessageBox.Show(cls_lockers.m_idSocio.ToString());
                DataTable dtLocker = cls_lockers.buscarLockerSocio();
                foreach (DataRow filas in dtLocker.Rows)
                {
                    if(!filas["fechaVencimiento"].ToString().Equals(""))
                    {
                        DTPLockerVence.Value = Convert.ToDateTime(filas["fechaVencimiento"].ToString());
                    }
                }

                dt = cls_socios.buscarSocioDiasViajero();

                if (dt.Rows.Count > 0)
                {
                   // txtDiasViajero.Text = dt.Rows[0]["numDiasViajero"].ToString();
                    
                }

                llenarComboMembresias();
                llenarComboProductos();
                llenarcomboTipoMembresiaLocker();

            }
            else MessageBox.Show("  Socio no encontrado ");
        }

        private void TSTxtBuscaSocio_KeyDown(object sender, KeyEventArgs e)
        {
            if ((int)e.KeyCode == (int)Keys.Enter)
            {
                if(TSTxtBuscaSocio.Text.Equals(""))
                {
                    MessageBox.Show("Favor de ingresar id del socio");
                }
                else
                {
                    buscarSocio();
                    validarControles(false);
                    gbxMembresia.Enabled = true;
                    btnAgregarUsuario.Text = "N. socio";
                }

            }
        }
        // First method: Convert Image to byte[] array:
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
        // Second method: Convert byte[] array to Image:
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private void cancelar()
        {
            dtgVentas.DataSource = null;
            txtNumDiasViajero.Text = "";
            chkDiasViajero.Checked = false;
            txtNombreMembresia.Text = "";
            LimpiaFormulario();
            validarGBX();
            validarControles(false);
            btnAgregarUsuario.Text = "N. socio";
            btnIniciar.Text = "Tomar foto";

            btnCancelarCamara.Enabled = false;
        }

        private void TsLimpiaForm_Click(object sender, EventArgs e)
        {
            lblTexto.Text = "";
            TxtIdSocio.Text = "";
            botones(true);
            cancelar();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
        private void LimpiaFormulario()
        {
            DateTime thisDay = DateTime.Today;

            TxtNombreSocio.Text = "";
            TxtDireccion1.Text = "";
            TxtDireccion2.Text = "";
            TxtEmail.Text = "";
            mktCelular.Text = "";
            //DtpFechaIngreso.Text = "";
            //DTPFechaNac.Value  = thisDay;
            mktFechaNacimiento.Text = "";
            //DtpFechaIngreso.Value = thisDay;
            //PbFotoSocio.Image = null;
            txtComentario.Text = "";

            TerminarFuenteDeVideo();

            pbFotoUser.Image = null;
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;

            if (lista_datos_venta.Count > 0)
            {
                for (int i = 0; i < lista_datos_venta.Count; i++)
                {
                    lista_datos_venta.RemoveAt(i);
                    dtgVentas.Rows.RemoveAt(i);
                }
            }

        }

        public bool ChkForm_InsOGuardar()
        {
            Boolean bandera = false;
            // Si el picturebox DEL SOCIO esta vacio,  el chkform marca falso para no continuar
            if (pbFotoUser.Image == null)
            {
                bandera = false;
                MessageBox.Show("     ¡ NO SE HA ASIGNADO UNA FOTO AL SOCIO ! \n  -POR FAVOR TOME LA FOTO ANTES DE CONTINUAR- ");
            }
            else bandera = true;  // HA PASADO EL FILTRO DE LA FOTO



            return bandera;
        }

        private void mktCelular_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void mktCelular_Click(object sender, EventArgs e)
        {

            mktCelular.Focus();
        }

        private void RDmasculino_CheckedChanged(object sender, EventArgs e)
        {
            //llama al metodo para llevar el combo de los lockers
            seleccionar_locker(1);
            validarGBX();
        }

        private void RDsexoFem_CheckedChanged(object sender, EventArgs e)
        {
            //llama al metodo para llevar el combo de los lockers
            seleccionar_locker(2);
            validarGBX();
        }

        private void seleccionar_locker(int tipoBusqueda)
        {
            //se le asigna un valor a la variable tipo que se encarga de
            //seleccionar el tipo de busqueda en el SP
            cls_lockers.Tipo = tipoBusqueda;
            //se llama al metodo  donde esta la accion de SP
            DataTable dt = cls_lockers.verLockers();
            //se llena el datasoucer con lo que regreso el SP
            cbbLockers.DataSource = dt;
            //se coloca el indice o option en web
            cbbLockers.ValueMember = "idLocker";
            //se coloca el valor del combo
            cbbLockers.DisplayMember = "Descripcion";
            cbbLockers.Text = "";
        }

        private void llenarComboMembresias()
        {
            //se llama al metodo  donde esta la accion de SP
            cls_membresias.m_idMembresia = 0;
            cls_membresias.Tipo = 1;
            DataTable dt = cls_membresias.seleccionarMembresias();
            //se llena el datasoucer con lo que regreso el SP
            cbbMembresia.DataSource = dt;
            //se coloca el indice o option en web
            cbbMembresia.ValueMember = "idMembresia";
            //se coloca el valor del combo
            cbbMembresia.DisplayMember = "Descripcion";
            cbbMembresia.Text = "";
        }

        private void llenarComboProductos()
        {

            DataTable dt = cls_productos.SeleccionarProductos();
            //se llena el datasoucer con lo que regreso el SP
            cbbProductos.DataSource = dt;
            //se coloca el indice o option en web
            cbbProductos.ValueMember = "idProducto";
            //se coloca el valor del combo
            cbbProductos.DisplayMember = "descripcion";
            cbbProductos.Text = "";
        }

        private void llenarcomboTipoMembresiaLocker()
        {
            
            DataTable dt = cls_lockers.seleccinarMembresiaTipoLockers();
            cbbMembresiaLockers.DataSource = dt;
            cbbMembresiaLockers.ValueMember = "idMembresia";
            //se coloca el valor del combo
            cbbMembresiaLockers.DisplayMember = "Descripcion";
            //dataGridView1.DataSource = dt;

        }

        private void cbbLockers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cbbLockers.Text.Equals(""))
            {
                //txtnumDias.Enabled = true;
            }
            else
            {
                //txtnumDias.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void buscarProducto(ComboBox combo)
        {
            cls_productos.m_idProducto = Convert.ToInt32(combo.SelectedValue.ToString());
            DataTable dt = cls_productos.buscarProducto();
            datosVenta DatosVenta;
            foreach (DataRow filas in dt.Rows)
            {

                int rowEscribir = Convert.ToInt32(dtgVentas.Rows.Count) - 1;
                //se agrega una nueva fila donde van a ir los datos
                dtgVentas.Rows.Add(1);
                //se agregan los datos
                dtgVentas.Rows[rowEscribir].Cells[0].Value = filas["descripcion"].ToString();
                dtgVentas.Rows[rowEscribir].Cells[1].Value = filas["precio"].ToString();

                DatosVenta = new datosVenta();
                DatosVenta.Item = "Producto " + filas["descripcion"].ToString();
                DatosVenta.Monto = Convert.ToInt32(filas["precio"]);
                DatosVenta.Tipo = 'P';
                DatosVenta.ClaveMembresia = Convert.ToInt32(filas["idProducto"]);
                //if (Convert.ToChar(filas["Viajero"].ToString()).Equals('S'))
                //{
                //    MessageBox.Show("es true viajero");
                //    DatosVenta.DiasViajero = true;
                //}
                //else
                //{
                //    MessageBox.Show("es false viajero");
                //    DatosVenta.DiasViajero =false;
                //}
                   
                //DatosVenta.NumDiasViajero = Convert.ToInt32(filas["Periodo"]);
                DatosVenta.FechaVencimiento = DateTime.Today;
                DatosVenta.Prefijo = "";
                lista_datos_venta.Add(DatosVenta);
            }
        }

        private void seleccionarMembresia(ComboBox combo, bool bandera,int idMembresia)
        {
           
           if(bandera)
            {
                cls_membresias.m_idMembresia = Convert.ToInt32(combo.SelectedValue.ToString());
            }
            else
            {
                cls_membresias.m_idMembresia = Convert.ToInt32(idMembresia);
            }
            cls_membresias.Tipo = 2;
            DataTable dt = cls_membresias.seleccionarMembresias();
            datosVenta DatosVenta;
            foreach (DataRow filas in dt.Rows)
            {

                int rowEscribir = Convert.ToInt32(dtgVentas.Rows.Count) - 1;
                //se agrega una nueva fila donde van a ir los datos
                dtgVentas.Rows.Add(1);
                //se agregan los datos
                dtgVentas.Rows[rowEscribir].Cells[0].Value = filas["Descripcion"].ToString();
                dtgVentas.Rows[rowEscribir].Cells[1].Value = filas["Costo"].ToString();

                DatosVenta = new datosVenta();
                DatosVenta.Item = "Membresia " + filas["Descripcion"].ToString();
                DatosVenta.Monto = Convert.ToInt32(filas["Costo"]);
                DatosVenta.Tipo = Convert.ToChar(filas["Tipo"].ToString());

                DatosVenta.ClaveMembresia = Convert.ToInt32(filas["idMembresia"]);

                if (Convert.ToChar(filas["Viajero"].ToString()).Equals('S'))
                {
                    DatosVenta.DiasViajero = true;
                    if (filas["ConteoViajero"].ToString().Equals("") || filas["ConteoViajero"].ToString().Equals("0"))
                    {

                        DatosVenta.NumDiasViajero = Convert.ToInt32(filas["Periodo"].ToString());
                        txtDiasViajero.Text = filas["Periodo"].ToString();
                    }
                    else
                    {
                        DatosVenta.NumDiasViajero = Convert.ToInt32((filas["ConteoViajero"].ToString()));
                        txtDiasViajero.Text = filas["ConteoViajero"].ToString();
                    }

                }
                else
                {
                    txtDiasViajero.Text = "0";
                    DatosVenta.DiasViajero = false;
                    DatosVenta.NumDiasViajero = 0;
                }



                DateTime hoy = DateTime.Today;
                //dtpVencimientoViajero.Value = hoy;
                //DatosVenta.FechaVencimiento = dtpVencimientoViajero.Value.AddDays(Convert.ToInt32(filas["Periodo"].ToString()) - 1);

               int numero= DateTime.Compare(fechaVencimiento,hoy);

                if(numero>=0)
                {
                    hoy = fechaVencimiento;
                }

                if (!Convert.ToChar(filas["Tipo"].ToString()).Equals('L'))
                {

                    //dtpVencimientoViajero.Value = fechaVencimiento;
                    //dtpVencimientoViajero.Value = dtpVencimientoViajero.Value.AddDays(Convert.ToInt32(filas["Periodo"].ToString()) - 1);
                    cls_socios.m_IdSocio = Convert.ToInt32(TxtIdSocio.Text);
                    cls_socios.m_idMembresia = Convert.ToInt32(combo.SelectedValue.ToString());
                    DataTable dt2 = cls_socios.buscarVencimientoMembresiaSocio();
                    //if(dt2.Rows.Count>0)
                    //{
                    //    foreach (DataRow filas2 in dt2.Rows)
                    //    {

                    //        // indice de columnas 
                    //        //IdSocio 0
                    //        //TxtIdSocio.Text = filas["fechaVencimiento"].ToString();
                    //        dtpVencimientoViajero.Value = Convert.ToDateTime(filas2["fechaVencimiento"].ToString());
                    //        DatosVenta.FechaVencimiento = dtpVencimientoViajero.Value.AddDays(Convert.ToInt32(filas["Periodo"].ToString()));
                    //        dtpVencimientoViajero.Value = dtpVencimientoViajero.Value.AddDays(Convert.ToInt32(filas["Periodo"].ToString()));
                    //    }
                           
                    //}
                    //else
                    //{
                    //    dtpVencimientoViajero.Value = hoy;
                    //    DatosVenta.FechaVencimiento = dtpVencimientoViajero.Value.AddDays(Convert.ToInt32(filas["Periodo"].ToString()));
                    //    //dtpVencimientoViajero.Value = dtpVencimientoViajero.Value.AddDays(Convert.ToInt32(filas["Periodo"].ToString()));
                    //}
                    dtpVencimientoViajero.Value = hoy;
                    DatosVenta.FechaVencimiento = dtpVencimientoViajero.Value.AddDays(Convert.ToInt32(filas["Periodo"].ToString()));
                    dtpVencimientoViajero.Value = dtpVencimientoViajero.Value.AddDays(Convert.ToInt32(filas["Periodo"].ToString()));

                }
                else
                {
                    DTPLockerVence.Value = hoy;
                    DatosVenta.FechaVencimiento = DTPLockerVence.Value.AddDays(Convert.ToInt32(filas["Periodo"].ToString()));

                    DTPLockerVence.Value = DTPLockerVence.Value.AddDays(Convert.ToInt32(filas["Periodo"].ToString()));
                }
                if (filas["Tipo"].ToString().Equals("L"))
                {
                    periodoLocker = Convert.ToInt32(filas["Periodo"].ToString());
                }
                DatosVenta.Prefijo = filas["prefijo"].ToString();
                lista_datos_venta.Add(DatosVenta);
            }
        }

        private void cbbMembresia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!cbbMembresia.Equals(""))
            {

                    seleccionarMembresia(cbbMembresia,true,0);

            }
        }

        private void realizarVenta()
        {
            string textoSMS = "";
            if (dtgVentas.Rows.Count <= 1)
            {
                MessageBox.Show("No cuenta con membresias o productos agregados para realizar una venta");
            }
            else if (MessageBox.Show("Cerrar venta?", "Continuar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
               

                SubtotalAPagar = 0;
                for (int i = 0; i < lista_datos_venta.Count; i++)
                {
                    SubtotalAPagar += lista_datos_venta[i].Monto;
                }
                FrmPagoVenta frm_pago_venta = new FrmPagoVenta(SubtotalAPagar);
                frm_pago_venta.ShowDialog();
                if (Login.Pago)
                {
                    Login.num_ticket++;
                    //int numeroRegistros = Convert.ToInt32(cls_hdr_venta_hist.hdrVentaHistCantidadRegistros());

                    this.Cursor = Cursors.WaitCursor;
                    //double total_a_pagar_Iva = (SubtotalAPagar * 0.16);
                    //double total_a_pagar = SubtotalAPagar + total_a_pagar_Iva;
                    cls_hdr_venta_hist.m_FolioVenta = Login.num_ticket;
                    cls_hdr_venta_hist.m_IdSocio = Convert.ToInt32(TxtIdSocio.Text);
                    cls_hdr_venta_hist.m_Subtotal = SubtotalAPagar;
                    //cls_hdr_venta_hist.m_IVA = total_a_pagar_Iva;
                    //cls_hdr_venta_hist.m_Total = total_a_pagar;
                    cls_hdr_venta_hist.m_User_modif = Login.nombre;
                    cls_hdr_venta_hist.m_tipoPago = Login.tipoPago;

                    FolioVenta = Login.num_ticket;
                    cls_hdr_venta_hist.guardarVentaHist();
                    //FolioVenta = Convert.ToInt32();
                    string idSocio="";
                    string nombreVenta="";

                    
                    


                    //MessageBox.Show("El folio es: " + FolioVenta.ToString());
                    Datos DS = new Datos();
                    
                    verReporte VER;
                    string textoCorreo = "";
                    // bool banderaEnviarSMS = false;
                    DateTime fechaYhora = DateTime.Today;
                    textoCorreo += "<style>table, th, td {border: 1px solid black;}</style>";
                    textoCorreo += "<div><b>Clave Socio: " + TxtIdSocio.Text + " </b></div>";
                    textoCorreo += "<div><b>Nombre: " + TxtNombreSocio.Text + " </b></div>";
                    textoCorreo += "<div><b>Folio venta: " + Login.num_ticket + " </b></div>";
                    textoCorreo += "<div><b>Fecha: "+DateTime.Now.ToShortDateString()+" "+ DateTime.Now.ToShortTimeString() + " </b></div>";
                    textoCorreo += "<table style='border: 1px solid black;'><thead><th style='border: 1px solid black;'> Item </th><th style='border: 1px solid black;'> Monto </th><th style='border: 1px solid black;'>clave</th></thead><tbody>";
                    textoSMS = "clave socio: " + TxtIdSocio.Text + "\n";
                    for (int i = 0; i < lista_datos_venta.Count; i++)
                    {

                        if (!lista_datos_venta[i].Prefijo.Equals(""))
                        {
                            // banderaEnviarSMS = true;
                            textoSMS += "clave: " + lista_datos_venta[i].Item + ": " + lista_datos_venta[i].Prefijo + TxtIdSocio.Text + "\n\n";
                        }
                       


                       

                            cls_mov_ventas_hist.m_FolioVenta = Login.num_ticket;
                            cls_mov_ventas_hist.m_Item = lista_datos_venta[i].Item + " con vencimiento " + lista_datos_venta[i].FechaVencimiento.ToString();
                            cls_mov_ventas_hist.m_Monto = lista_datos_venta[i].Monto;
                            cls_mov_ventas_hist.m_Tipo = lista_datos_venta[i].Tipo;
                            cls_mov_ventas_hist.m_User_modif = Login.nombre;
                            cls_mov_ventas_hist.m_claveTipoMembresia = lista_datos_venta[i].ClaveMembresia;
                            cls_mov_ventas_hist.m_idSocio = Convert.ToInt32(TxtIdSocio.Text);
                            cls_mov_ventas_hist.m_diasViajero = lista_datos_venta[i].DiasViajero;
                            cls_mov_ventas_hist.m_numDiasViajero = lista_datos_venta[i].NumDiasViajero;
                            cls_mov_ventas_hist.fechaVencimiento = lista_datos_venta[i].FechaVencimiento;
                            cls_mov_ventas_hist.guardarMovimientoVenta();
                            idSocio = TxtIdSocio.Text;
                            nombreVenta = TxtNombreSocio.Text;
                        

                        textoCorreo += "<tr>";
                        textoCorreo += "<td style='border: 1px solid black;'>" + lista_datos_venta[i].Item + " con vencimiento " + lista_datos_venta[i].FechaVencimiento.ToString() + "</td>";
                        textoCorreo += "<td style='border: 1px solid black;'>$" + lista_datos_venta[i].Monto + "</td>";
                        textoCorreo += "<td style='border: 1px solid black;'>" + lista_datos_venta[i].Prefijo +idSocio + "</td>";
                        textoCorreo += "</tr>";


                        //cls_socios.m_IdSocio = Convert.ToInt32(TxtIdSocio.Text);
                        //cls_socios.m_Vencimiento = Convert.ToDateTime(dtpVencimientoViajero.Value);
                        //cls_socios.Viajero = lista_datos_venta[i].DiasViajero;
                        //cls_socios.m_NumeroDias = lista_datos_venta[i].NumDiasViajero;
                        //cls_socios.m_User_modif = Login.nombre;
                        //cls_socios.ActualizarMembresia();

                        DS.Tabla.Rows.Add(Login.nombre, idSocio, nombreVenta, lista_datos_venta[i].Item + " con vencimiento " + lista_datos_venta[i].FechaVencimiento.ToString(), "$" + lista_datos_venta[i].Monto, cls_generales.enletras(SubtotalAPagar.ToString()), Login.num_ticket.ToString(), "$" + SubtotalAPagar);

                    }
                    textoCorreo += "<tr  style='text-align: right;'><td style='border: 1px solid black;' colspan='3'><b>Total: $" + SubtotalAPagar.ToString() + "</b></td></tr>";
                    textoCorreo += "</tbody>";
                    textoCorreo += "</table>";
                    lista_datos_venta.Clear();

                    double total_a_pagar_Iva = (SubtotalAPagar * 0.16);
                    double total_a_pagar = SubtotalAPagar + total_a_pagar_Iva;
                    Login.dineroEntrada += total_a_pagar;

                    SubtotalAPagar = 0;
                    Login.Pago = false;


                    if (!cbbLockers.Text.Equals(""))
                    {
                        cargar_locker(Convert.ToInt32(TxtIdSocio.Text));
                    }

                    //////////////////
                    //int nuevoRegistros = Convert.ToInt32(cls_hdr_venta_hist.hdrVentaHistCantidadRegistros());

                    //if(numeroRegistros==nuevoRegistros)
                    //{
                    //    total_a_pagar_Iva = (SubtotalAPagar * 0.16);
                    //    total_a_pagar = SubtotalAPagar + total_a_pagar_Iva;
                    //    cls_hdr_venta_hist.m_IdSocio = Convert.ToInt32(TxtIdSocio.Text);
                    //    cls_hdr_venta_hist.m_Subtotal = SubtotalAPagar;
                    //    cls_hdr_venta_hist.m_IVA = total_a_pagar_Iva;
                    //    cls_hdr_venta_hist.m_Total = total_a_pagar;
                    //    cls_hdr_venta_hist.m_User_modif = Login.nombre;
                    //    cls_hdr_venta_hist.m_tipoPago = Login.tipoPago;
                    //    cls_hdr_venta_hist.guardarVenta();
                    //}
                   


                    //////////////////////


                    // Inicializar el visor de reportes y mandarle la tabla con los datos
                    VER = new verReporte(DS.Tabla, null, null,null,null);
                   // VER.ShowDialog();
                    ArrayList email = new ArrayList();
                    cambios cb = new cambios();
                    email.Add(cb.Correo);
                    if (!TxtEmail.Text.Equals(""))
                    {
                        email.Add(TxtEmail.Text);
                        cls_generales.EnviarCorreo(email, textoCorreo, "Venta Total Gym", "");
                    }
                   
                    //string respuestaSMS = cls_generales.enviarSMS(mktCelular.Text, textoSMS.ToString());

                    //MessageBox.Show(respuestaSMS);
                    LimpiaFormulario();
                   
                    dtgVentas.Rows.Clear();
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("venta exitosa");
                    dateTimePicker1.Enabled = false;
                    dtpVencimientoViajero.Enabled = false;
                    DTPLockerVence.Enabled = false;
                    button2.Text = "Editar fecha";
                    cortesiaVisita = false;
                    seleccionar_locker(1);
                    botones(true);
                    cancelar();
                    //Imprimir_Solicitud();
                }



            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

                if(!ChkForm_InsOGuardar())
                {
                   
                }
               else if(TxtNombreSocio.Text.Equals(""))
                {
                    MessageBox.Show("Favor de ingresar el nombre del usuario");
                    TxtNombreSocio.Focus();
                }
                else if(TxtDireccion1.Text.Equals("")&&TxtDireccion2.Text.Equals(""))
                {
                    MessageBox.Show("Favor de ingresar una direccion");
                    TxtDireccion1.Focus();
                }
                else if(!RDmasculino.Checked&&!RDsexoFem.Checked)
                {
                    MessageBox.Show("Favor de seleccionar el sexo");
                }
                else if (mktFechaNacimiento.Text.Length < 10)
                {
                    MessageBox.Show("Favor de ingresar la fecha de nacimiento");
                }

                else
                {
                    bool emailFormato = Regex.IsMatch(TxtEmail.Text, "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*");
                    if (emailFormato)
                    {

                    if (nuevoSocio)
                    {
                        ClsSocios Socio = new ClsSocios();
                        btnAgregarUsuario.Text = "N. socio";

                        // pasamos todos los datos a los parametros de la esctructura para ejecutar el SP AltaSocio
                        Socio.m_Nombre = TxtNombreSocio.Text;
                        //Socio.m_IdSocio =
                        Socio.m_FotoId = "fff";
                        Socio.m_Direccion1 = TxtDireccion1.Text;
                        Socio.m_Direccion2 = TxtDireccion2.Text;
                        Socio.m_Email = TxtEmail.Text;
                        Socio.m_Edad = "0";
                        Socio.m_Telefono = mktCelular.Text;
                        Socio.m_Sexo = RDsexoFem.Checked ? "F" : "M";
                        Socio.m_TipoSocio = txtDiasViajero.Text;

                        Socio.m_Fingerprint = "Finger";
                        //Socio.m_FechaIngreso = DtpFechaIngreso.Value;
                        //Socio.m_Vencimiento = DTPFechaVencHasta.Value;
                        Socio.m_Observacion = txtComentario.Text;
                        Socio.m_Indicaciones = "Indicaciones";
                        Socio.m_User_modif = Login.nombre;
                        Socio.m_FechaNacimiento = Convert.ToDateTime(mktFechaNacimiento.Text);
                        // Asignando el valor de la imagen
                        // Stream usado como buffer
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        // Se guarda la imagen en el buffer
                        pbFotoUser.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        // Se extraen los bytes del buffer para asignarlos como valor para el parámetro.
                        //ImgFoto =  ms.GetBuffer();
                        //imagen = Convert.ToByte( ms.GetBuffer());
                        Socio.m_Foto = ms.GetBuffer();

                        //Parametros de salida
                        TxtIdSocio.Text = Socio.InsSocio();
                        idSocio = Convert.ToInt32(TxtIdSocio.Text);


                        // mens = TxtIdSocio.Text;
                        // MessageBox.Show("Socio agregado de forma correcta");
                        //validarGBX();
                        nuevoSocio = false;
                    }
                        nuevoSocio = false;
                        realizarVenta();
                        nuevoSocio = false;
                    }
                    else
                    {
                        MessageBox.Show("El formato del correo ingresado no es correto","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }
                    
                    
                }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            FuenteDeVideo.Stop();
            pbFotoUser.Image = null;
            btnIniciar.Text = "Tomar foto";
            btnCancelarCamara.Enabled = false;


        }

        private void button3_Click(object sender, EventArgs e)
        {


            //this.pbFotoUser.Image = System.Drawing.Image.FromFile("C:\\Users\\Pablo\\Pictures\\1.jpg");

            if (dtgVentas.Rows.Count <= 1)
            {
                MessageBox.Show("aun no cuenta con membresias");
            }
            else
            {
                numero_fila = dtgVentas.CurrentRow.Index;

                //if(numero_fila==0)
                //{
                //    MessageBox.Show("favor de seleccionar una membresia");
                //}
                //else
                //{
                FrmDescuento frm_descuento = new FrmDescuento(concepto, monto);
                frm_descuento.ShowDialog();
                if (Login.cantidadDescuento >= 0)
                {
                    lista_datos_venta[numero_fila].Monto = Login.cantidadDescuento;
                    dtgVentas.Rows[numero_fila].Cells["Monto"].Value = Login.cantidadDescuento;
                }
                //}
            }

        }

        private void TxtNombreSocio_TextChanged(object sender, EventArgs e)
        {
            validarGBX();
        }

        private void TxtDireccion1_TextChanged(object sender, EventArgs e)
        {
            validarGBX();
        }

        private void TxtDireccion2_TextChanged(object sender, EventArgs e)
        {
            validarGBX();
        }

        private void mktCelular_TextChanged(object sender, EventArgs e)
        {
            validarGBX();
        }

        private void TxtEmail_TextChanged(object sender, EventArgs e)
        {
            validarGBX();
        }

        private void mktFechaNacimiento_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            mktFechaNacimiento.ValidatingType = typeof(System.DateTime);
            //MessageBox.Show(mktFechaNacimiento.ValidatingType.ToString());

        }

        private void mktFechaNacimiento_TextChanged(object sender, EventArgs e)
        {
            validarGBX();

            if (mktFechaNacimiento.Text.Length == 10)
            {
                String value = mktFechaNacimiento.Text;
                String[] substrings = value.Split('/');
                int año = Convert.ToInt32(substrings[2]);
                int mes = Convert.ToInt32(substrings[1]);
                int dia = Convert.ToInt32(substrings[0]);
                DateTime nacimiento = new DateTime(año, mes, dia); //Fecha de nacimiento
                int edad = DateTime.Today.AddTicks(-nacimiento.Ticks).Year - 1;
                txtEdad.Text = edad.ToString();
            }
            else
            {
                txtEdad.Text = "";
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                dtgVentas.Rows.RemoveAt(numero_fila);
                lista_datos_venta.RemoveAt(numero_fila);
                //for (int i = 0; i < lista_datos_venta.Count; i++)
                //{
                //    MessageBox.Show(lista_datos_venta[i].Item.ToString());
                //}
            }
            catch
            {
                MessageBox.Show("Favor de seleccinar una fila");
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            numero_fila = dtgVentas.CurrentRow.Index;

        }

        private void crToolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            LimpiaFormulario();
        }

        private void dtgVentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //monto = Convert.ToDouble(dtgVentas.Rows[e.RowIndex].Cells["Monto"].Value.ToString());
            //concepto = dtgVentas.Rows[e.RowIndex].Cells["Concepto"].Value.ToString();
            //numero_fila = dtgVentas.CurrentRow.Index;

            //FrmDescuento frm_descuento = new FrmDescuento(concepto, monto);
            //frm_descuento.ShowDialog();
            //if(Login.cantidadDescuento!=0)
            //{
            //    lista_datos_venta[numero_fila].Monto = Login.cantidadDescuento;
            //    dtgVentas.Rows[e.RowIndex].Cells["Monto"].Value = Login.cantidadDescuento;
            //}
            
        }

        private void dtgVentas_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {

        }

        private void cbbMembresiaLockers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbbMembresiaLockers_SelectionChangeCommitted(object sender, EventArgs e)
        {
            seleccionarMembresia(cbbMembresiaLockers,true,0);
            //DTPLockerVence.Value = DateTime.Today;
            //DTPLockerVence.Value = dtpVencimientoViajero.Value.AddDays(periodoLocker);

            // MessageBox.Show(cbbMembresiaLockers.SelectedValue.ToString());
            // periodoLocker =  Convert.ToInt32(cbbMembresiaLockers.SelectedValue.ToString());
        }

        private void mktFechaNacimiento_Click(object sender, EventArgs e)
        {
            mktFechaNacimiento.Focus();
            
        }

        private void txtBuscarPorNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if ((int)e.KeyCode == (int)Keys.Enter)
            {
                if(txtBuscarPorNombre.Text.Equals(""))
                {
                    MessageBox.Show("Ingresar nombre");
                }

                else
                {
                    FrmBuscarSocioNombre frm_buscar_socio_por_nombre = new FrmBuscarSocioNombre(txtBuscarPorNombre.Text);
                    frm_buscar_socio_por_nombre.ShowDialog();
                    if (Login.idSocio != 0)
                    {
                        TSTxtBuscaSocio.Text = Login.idSocio.ToString();
                        buscarSocio();
                        validarControles(false);
                        gbxMembresia.Enabled = true;
                        btnAgregarUsuario.Text = "N. socio";
                    }
                }

            }
        }

        private void cbbProductos_SelectionChangeCommitted(object sender, EventArgs e)
        {

            buscarProducto(cbbProductos);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
           
            if (btnModificarSocio.Text.Equals("Mod. socio"))
            {
                if (TxtIdSocio.Text.Equals(""))
                {
                    MessageBox.Show("Favor de seleccionar un socio");
                }
                else
                {
                    validarControles(true);
                    botones(false);
                    lblTexto.Text = "Modificando Socio";
                    btnModificarSocio.Enabled = true;
                    btnModificarSocio.Text = "Guardar Modificacion";
                    gbxMembresia.Enabled = false;
                }
                
            }
            else if(btnModificarSocio.Text.Equals("Guardar Modificacion"))
            {
                if(mktFechaNacimiento.Text.Length<10)
                {
                    MessageBox.Show("Ingresar la fecha de nacimiento correctamente");
                    mktFechaNacimiento.Focus();
                }
                else if (ChkForm_InsOGuardar())
                {
                    string sexo = "";
                    if (RDmasculino.Checked)
                    {
                        sexo = "M";
                    }
                    else
                    {
                        sexo = "F";
                    }
                    cls_socios.m_IdSocio = Convert.ToInt32(TxtIdSocio.Text);
                    cls_socios.m_Nombre = TxtNombreSocio.Text;
                    cls_socios.m_Direccion1 = TxtDireccion1.Text;
                    cls_socios.m_Direccion2 = TxtDireccion2.Text;
                    cls_socios.m_Email = TxtEmail.Text;
                    cls_socios.m_Edad = txtEdad.Text;
                    cls_socios.m_Telefono = mktCelular.Text;
                    cls_socios.m_Sexo = sexo;
                    cls_socios.m_Observacion = txtComentario.Text;
                    cls_socios.m_User_modif = Login.nombre;
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    // Se guarda la imagen en el buffer
                    pbFotoUser.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    // Se extraen los bytes del buffer para asignarlos como valor para el parámetro.
                    //ImgFoto =  ms.GetBuffer();
                    //imagen = Convert.ToByte( ms.GetBuffer());
                    cls_socios.m_Foto = ms.GetBuffer();
                    cls_socios.m_FechaNacimiento = Convert.ToDateTime(mktFechaNacimiento.Text);
                    string respuesta = cls_socios.catSociosModificar();

                    MessageBox.Show(respuesta);
                    validarControles(false);
                    LimpiaFormulario();
                    btnModificarSocio.Text = "Mod. socio";
                    botones(true);
                    cancelar();
                }
                
            }
            
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            if(button2.Text.Equals("Editar fecha"))
            {
                FrmLogin frm_login = new FrmLogin(true);
                frm_login.ShowDialog();

                if (Login.superUsuario)
                {
                    button2.Text = "Cambiar fecha";
                    dtpVencimientoViajero.Enabled = true;
                    dateTimePicker1.Enabled = true;
                    DTPLockerVence.Enabled = true;
                }

            }

            else if(button2.Text.Equals("Cambiar fecha"))
            {
                //cls_socios.m_IdSocio = Convert.ToInt32(TxtIdSocio.Text);
                //cls_socios.m_Vencimiento = Convert.ToDateTime(dtpVencimientoViajero.Value);
                //cls_socios.Viajero = 'N';
                //cls_socios.m_NumeroDias = 0;
                //cls_socios.m_User_modif = Login.nombre;
                //cls_socios.ActualizarMembresia();
                lista_datos_venta[numero_fila].FechaVencimiento =  dtpVencimientoViajero.Value;
                MessageBox.Show("Fecha actualizada de forma correcta");
                button2.Text = "Editar fecha";
                dtpVencimientoViajero.Enabled = false;
                dateTimePicker1.Enabled = false;
                DTPLockerVence.Enabled = false;
            }
        }

        private void dtgVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                dtpVencimientoViajero.Value = lista_datos_venta[numero_fila].FechaVencimiento;
                txtDiasViajero.Text = lista_datos_venta[numero_fila].NumDiasViajero.ToString();
                monto = Convert.ToDouble(dtgVentas.Rows[e.RowIndex].Cells["Monto"].Value.ToString());
                concepto = dtgVentas.Rows[e.RowIndex].Cells["Concepto"].Value.ToString();
            }
            catch
            {

            }

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtNombreMembresia.Text = dataGridView2.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString();
                folioVenta = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["num"].Value.ToString());
                cls_socios.Descripcion = txtNombreMembresia.Text;
                cls_socios.m_IdSocio = Convert.ToInt32(TxtIdSocio.Text);
                dt = cls_socios.buscarVencimientoMembresia();

                foreach (DataRow filas in dt.Rows)
                {

                    // indice de columnas 
                    //IdSocio 0
                    //MessageBox.Show(filas["fechaVencimiento"].ToString());
                    dtpVencimientoMembresias.Value = Convert.ToDateTime(filas["fechaVencimiento"].ToString());
                    Convert.ToDateTime(filas["fechaVencimiento"].ToString());
                    claveTipoMembresia = Convert.ToInt32(filas["claveTipoMembresia"].ToString());
                   
                    if(Convert.ToBoolean(filas["diasViajero"].ToString()))
                    {
                        chkDiasViajero.Checked = true;
                        txtNumDiasViajero.Text = filas["numDiasViajero"].ToString();
                    }
                    else
                    {
                        chkDiasViajero.Checked = false;
                        txtNumDiasViajero.Text = "0";
                    }
                    //TxtIdSocio.Text = filas["IdSocio"].ToString();

                }
                //double monto = Convert.ToDouble(dtgVentas.Rows[e.RowIndex].Cells["Monto"].Value.ToString());
                //string concepto = dtgVentas.Rows[e.RowIndex].Cells["Concepto"].Value.ToString();
                //numero_fila = dtgVentas.CurrentRow.Index;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (btnEditarFecha.Text.Equals("Editar fecha"))
            {
                FrmLogin frm_login = new FrmLogin(true);
                frm_login.ShowDialog();


                if (Login.superUsuario)
                {
                    btnEditarFecha.Text = "Cambiar fecha";
                    dtpVencimientoMembresias.Enabled = true;   
                }

            }

            else if (btnEditarFecha.Text.Equals("Cambiar fecha"))
            {
                //cls_socios.m_IdSocio = Convert.ToInt32(TxtIdSocio.Text);
                //cls_socios.m_Vencimiento = Convert.ToDateTime(dtpVencimientoViajero.Value);
                //cls_socios.Viajero = 'N';
                //cls_socios.m_NumeroDias = 0;
                //cls_socios.m_User_modif = Login.nombre;
                //cls_socios.ActualizarMembresia();
                cls_socios.m_fechaVencimiento = dtpVencimientoMembresias.Value;
                cls_socios.m_folioVenta = folioVenta;
                string respuesta = cls_socios.modificarFechaVenta();
                MessageBox.Show(respuesta);
                btnEditarFecha.Text = "Editar fecha";
                dtpVencimientoMembresias.Enabled = false;
            }


            //FolioVenta = Convert.ToInt32(cls_hdr_venta_hist.guardarVenta());


            //foreach (DataGridViewRow fila in dataGridView2.Rows)
            //{
            //    if (Convert.ToBoolean(fila.Cells["Renovar"].Value) == true)
            //    {
            //        int idMembresia = Convert.ToInt32(fila.Cells["idMembresia"].Value.ToString());
            //        seleccionarMembresia(cbbMembresiaLockers, false, idMembresia);
            //    }
            //}


            //realizarVenta();
        }

        private void TxtNombreSocio_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void mktFechaNacimiento_MaskInputRejected_1(object sender, MaskInputRejectedEventArgs e)
        {
            mktFechaNacimiento.Focus();
        }

        private void mktFechaNacimiento_TextChanged_1(object sender, EventArgs e)
        {
            validarGBX();

            if (mktFechaNacimiento.Text.Length == 10)
            {
                String value = mktFechaNacimiento.Text;
                String[] substrings = value.Split('/');
                int año = Convert.ToInt32(substrings[2]);
                int mes = Convert.ToInt32(substrings[1]);
                int dia = Convert.ToInt32(substrings[0]);
                DateTime nacimiento = new DateTime(año, mes, dia); //Fecha de nacimiento
                int edad = DateTime.Today.AddTicks(-nacimiento.Ticks).Year - 1;
                txtEdad.Text = edad.ToString();
            }
            else
            {
                txtEdad.Text = "";
            }

        }

        private void TxtEmail_TextChanged_1(object sender, EventArgs e)
        {
            validarGBX();
        }

        private void mktCelular_TextChanged_1(object sender, EventArgs e)
        {
            validarGBX();
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
           
            LimpiaFormulario();
            cancelar();
            botones(false);
            visitaCortesia('M', "Visita");
            lblTexto.Visible = true;
            lblTexto.Text = "Guardando Visita";
            validarControles(true);
            botones(false);
            nuevoSocio = true;
        }

        public void botones(bool condicion)
        {
            
            btnAgregarUsuario.Enabled = condicion;
            btnModificarSocio.Enabled = condicion;
            btnVisita.Enabled = condicion;
            btnCortesia.Enabled = condicion;
            TSTxtBuscaSocio.Enabled = condicion;
            txtBuscarPorNombre.Enabled = condicion;
        }

        public void visitaCortesia(char tipo,string texto)
        {

            
            cortesiaVisita = true;
            TxtIdSocio.Text = "99999";
            datosVenta DatosVenta;
            int rowEscribir = Convert.ToInt32(dtgVentas.Rows.Count) - 1;
            //se agrega una nueva fila donde van a ir los datos
            dtgVentas.Rows.Add(1);
            //se agregan los datos
            dtgVentas.Rows[rowEscribir].Cells[0].Value = texto;
            dtgVentas.Rows[rowEscribir].Cells[1].Value = "0";

            DatosVenta = new datosVenta();
            DatosVenta.Item = texto;
            DatosVenta.Monto = 0;
            DatosVenta.Tipo = tipo;

            DatosVenta.ClaveMembresia = 0;

            txtDiasViajero.Text = "0";
            DatosVenta.DiasViajero = false;
            DatosVenta.NumDiasViajero = 0;



            DateTime hoy = DateTime.Today;
            DatosVenta.FechaVencimiento = hoy;
            //dtpVencimientoViajero.Value = hoy;
            //DatosVenta.FechaVencimiento = dtpVencimientoViajero.Value.AddDays(Convert.ToInt32(filas["Periodo"].ToString()) - 1);

            DatosVenta.Prefijo = "";
            lista_datos_venta.Add(DatosVenta);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            validarControles(true);
            botones(false);
            LimpiaFormulario();
            cancelar();
            botones(false);
            visitaCortesia('M',"Cortesia");
            lblTexto.Visible = true;
            lblTexto.Text = "Guardando cortesia";
            nuevoSocio = true;
            validarControles(true);
            botones(false);
            DataTable dt = cls_socios.catSociosNuevoIdSocio();
            foreach (DataRow filas in dt.Rows)
            {
                TxtIdSocio.Text = filas["id"].ToString();
            }

        }

        private void TSTxtBuscaSocio_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void RDmasculino_CheckedChanged_1(object sender, EventArgs e)
        {
            seleccionar_locker(1);
            validarGBX();
        }

        private void RDsexoFem_CheckedChanged_1(object sender, EventArgs e)
        {
            seleccionar_locker(2);
            validarGBX();
        }

        private void mktFechaNacimiento_Click_1(object sender, EventArgs e)
        {
            mktFechaNacimiento.Focus();
        }

        private void button5_Click_2(object sender, EventArgs e)
        {
            
        }

        private void button5_Click_3(object sender, EventArgs e)
        {
            
            //DataTable dt = cls_socios.seleccionarSocios();

            //foreach (DataRow filas in dt.Rows)
            //{

            //    //MessageBox.Show(filas["FotoId"].ToString());
            //    this.pbFotoUser.Image = System.Drawing.Image.FromFile("Z:\\Imgs\\" + filas["FotoId"].ToString() + ".jpg");

            //    System.IO.MemoryStream ms = new System.IO.MemoryStream();
            //    // Se guarda la imagen en el buffer
            //    pbFotoUser.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            //    // Se extraen los bytes del buffer para asignarlos como valor para el parámetro.
            //    //ImgFoto =  ms.GetBuffer();
            //    //imagen = Convert.ToByte( ms.GetBuffer());
            //    cls_socios.m_FotoId = filas["FotoId"].ToString();
            //    cls_socios.m_Foto = ms.GetBuffer();
            //    string respuesta = cls_socios.modificarFoto();
            //    MessageBox.Show(respuesta);
            //}
        }

        private void txtComentario_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FrmOperacion_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }

    class datosVenta
    {
        string item;
        char tipo;
        double monto;
        int claveMembresia;
        bool diasViajero;
        int numDiasViajero;
        DateTime fechaVencimiento;
        string prefijo;
        public string Item { get => item; set => item = value; }
        public char Tipo { get => tipo; set => tipo = value; }
        public double Monto { get => monto; set => monto = value; }
        public int ClaveMembresia { get => claveMembresia; set => claveMembresia = value; }
        public bool DiasViajero { get => diasViajero; set => diasViajero = value; }
        public int NumDiasViajero { get => numDiasViajero; set => numDiasViajero = value; }
        public DateTime FechaVencimiento { get => fechaVencimiento; set => fechaVencimiento = value; }
        public string Prefijo { get => prefijo; set => prefijo = value; }
    }
}
