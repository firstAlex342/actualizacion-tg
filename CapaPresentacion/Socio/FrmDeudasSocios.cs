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
using System.Net.Mail;
using System.Net;
using System.Collections;

namespace CapaPresentacion
{
    public partial class FrmDeudasSocios : Form
    {
        ClsSocios cls_socios = new ClsSocios();
        ClsGeneral cls_generales = new ClsGeneral();
        string idSocio;
        public FrmDeudasSocios()
        {
            InitializeComponent();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void FrmDeudasSocios_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns["Enviar_Email"].Visible = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {

            
            if (chkEsta_semana.Checked.Equals(false) && chkHoy.Checked.Equals(false) && chkEste_mes.Checked.Equals(false))
            {
                MessageBox.Show("Favor de seleccionar una opción", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (chkHoy.Checked.Equals(true))
            {
                buscarVencimientos(1, 0,0);
            }
            else if (chkEsta_semana.Checked.Equals(true))
            {
                buscarVencimientos(2, 0,0);
            }
            else if(chkEste_mes.Checked.Equals(true))
            {
                buscarVencimientos(3,0,0);


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            buscarVencimientos(4,0,0);
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if(cmbNumeroDias.Equals(""))
            {
                MessageBox.Show("Favor de seleccionar un dia", "Seleccionar dia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int numerodias = Convert.ToInt32(cmbNumeroDias.Text);
                buscarVencimientos(5, numerodias,0);
            }
            
        }

        /****************************************/
        public void buscarVencimientos(int tipoBusqueda, int numeroDias, int idSocio)
        {
            dataGridView1.Columns["Enviar_Email"].Visible = true;
            DateTime fechaInicio = Convert.ToDateTime(dtpFechaInicio.Value);
            DateTime fechaFinal = Convert.ToDateTime(dtpFechaFinal.Value);
            cls_socios.m_IdSocio = idSocio;
            cls_socios.m_FechaInicio = fechaInicio;
            cls_socios.m_FechaFinal = fechaFinal;
            cls_socios.m_NumeroDias = numeroDias;
            cls_socios.m_TipoBusqueda = tipoBusqueda;
            DataTable dt = cls_socios.DatosSociosVencidos();
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ArrayList Correos = new ArrayList();
            string textoCorreo="";
            string asunto = "";
            string respuesta = "";
            string respuestaM = "Correos enviador de forma correcta";
            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(fila.Cells["Enviar_Email"].Value) == true)
                {
                   if(fila.Cells["Email"].Value.ToString().Equals(""))
                   {
                        MessageBox.Show("El socio con clave: "+ fila.Cells["idSocio"].Value.ToString() +", no tiene correo");
                       
                   }
                   else
                   {
                        Correos.Add(fila.Cells["Email"].Value.ToString());
                   }
                }
            }

            DataTable dt = cls_socios.EnviarEmailSocios();
            foreach (DataRow filas in dt.Rows)
            {
                textoCorreo = filas["TextoCorreo"].ToString();
                asunto = filas["AsuntoDeudas"].ToString();
            }

            if(Correos.Count>0)
            {
                respuesta = cls_generales.EnviarCorreo(Correos, textoCorreo, asunto, respuestaM);
                MessageBox.Show(respuesta);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            buscarVencimientos(6, 0, Convert.ToInt32(txtIdSocio.Text));
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            idSocio = Convert.ToString(row.Cells["idSocio"].Value);
           // MessageBox.Show(idSocio);
			FrmObservacionesAdeudos observacionesForm = new FrmObservacionesAdeudos(Convert.ToInt32(idSocio));
			observacionesForm.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Datos DS = new Datos();
            verReporte VER;
            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                DS.sociosVencidos.Rows.Add(fila.Cells["idSocio"].Value, fila.Cells["Nombre"].Value);
            }
            VER = new verReporte(null, null, DS.sociosVencidos, null, null);
            VER.ShowDialog();
        }
    }
}
