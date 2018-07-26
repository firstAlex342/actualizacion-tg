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
    public partial class FrmObservacion : Form
    {
        ClsObservaciones cls_observaciones = new ClsObservaciones();
        ClsObservacionesCaja cls_observaciones_caja = new ClsObservacionesCaja();
        ClsGeneral cls_generales = new ClsGeneral();
        public int ObCaja;
        public FrmObservacion(int obvCaja)
        {
            this.ObCaja = obvCaja;
            InitializeComponent();
        }
        //public FrmObservacion()
        //{
        //    InitializeComponent();
        //}
        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Guardar observacion y continuar?", "Continuar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                cambios cb = new cambios();
                ArrayList email = new ArrayList();
                email.Add(cb.Correo);
                cls_observaciones_caja.m_texto = txtTexto.Text;
                cls_observaciones_caja.m_idUsuario = Login.idUsuario;
                string respuesta = cls_observaciones_caja.agregarObservacion();
                cls_generales.EnviarCorreo(email, txtTexto.Text, "Observaciones", "");
                MessageBox.Show(respuesta);
            }
            if(ObCaja==1)
            {
                this.Hide();
                FrmCorteEntrada abrir = new FrmCorteEntrada();
                abrir.Show();
            }

            this.Hide();
        }

        private void FrmObservacion_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
