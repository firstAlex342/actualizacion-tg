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

namespace GymAPP     //WindowsFormsApp1
{
    public partial class FrmInicial : Form
    {
        public FrmInicial()
        {
            InitializeComponent();
        }

        private void salirDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿ Deseas Salir del sistema ?"," Cerrar sistema ",MessageBoxButtons.YesNo)==DialogResult.Yes) { Application.Exit(); }
        }

        private void TabGral_Click(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_ContentPanel_Leave(object sender, EventArgs e)
        {
            
        }

        private void FrmInicial_Leave(object sender, EventArgs e)
        {
            
        }

        private void FrmInicial_FormClosed(object sender, FormClosedEventArgs e)
        {           
             Application.Exit(); 
        }

        private void FrmInicial_Load(object sender, EventArgs e)
        {
            BuscarDispositivos();
        }

        //*******************************  agregamos los controles para la camara

        private bool ExistenDispositivos = false;
        private FilterInfoCollection DispositivosDeVideo;
        private VideoCaptureDevice FuenteDeVideo = null;

        private void btnIniciar_Click(object sender, EventArgs e)
        {

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
            if (btnIniciar.Text == "Iniciar")
            {
                if (ExistenDispositivos)
                {
                    FuenteDeVideo = new VideoCaptureDevice(DispositivosDeVideo[cboDispositivos.SelectedIndex].MonikerString);
                    FuenteDeVideo.NewFrame += new NewFrameEventHandler(video_NuevoFrame);
                    FuenteDeVideo.Start();
                    btnIniciar.Text = "Tomar";
                    cboDispositivos.Enabled = false;
                    //gbMenu.Text = DispositivosDeVideo[cboDispositivos.SelectedIndex].Name.ToString();
                }
                else
                    MessageBox.Show("Error: No se encuentra dispositivo.");
            }
            else
            {
                if (FuenteDeVideo.IsRunning)
                {
                    TerminarFuenteDeVideo();
                    btnIniciar.Text = "Iniciar";
                    cboDispositivos.Enabled = true;
                }
            }
        }

        private void cboDispositivos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
