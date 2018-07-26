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
    public partial class FrmDatosConexion : Form
    {
        ClsGeneral cls_generales = new ClsGeneral();
        public FrmDatosConexion()
        {
            InitializeComponent();
        }

        private void FrmDatosConexion_Load(object sender, EventArgs e)
        {

            string[] datosConexion = cls_generales.verDatosConexion();
            txtUsuario.Text = datosConexion[0].ToString();
            txtContrasena.Text = datosConexion[1].ToString();
            txtBD.Text = datosConexion[2].ToString();
            txtServidor.Text = datosConexion[3].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool respuesta = cls_generales.CambiardatosConexion(txtUsuario.Text, txtContrasena.Text, txtBD.Text, txtServidor.Text);
            if (!respuesta)
            {
                MessageBox.Show("Error al conectar con la base de datos, verificar los datos de conexion", "Error de conexion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                this.Close();
                FrmLogin abrir = new FrmLogin(false);
                abrir.ShowDialog();
                
            }
        }
    }
}
