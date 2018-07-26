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
    public partial class FrmObservacionesAdeudos : Form
    {
        ClsObservaciones cls_observaciones = new ClsObservaciones();
        public int idSocio;
        public FrmObservacionesAdeudos(int idSocio)
        {
            InitializeComponent();
            this.idSocio = idSocio;
        }

        private void FrmObservacionesAdeudos_Load(object sender, EventArgs e)
        {
            cls_observaciones.m_IdSocio = idSocio;
            DataTable dt = cls_observaciones.BuscarObservacion();
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "FECHA";
            dataGridView1.Columns[2].HeaderText = "OBSERVACION";
            dataGridView1.Columns[3].HeaderText = "ID SOCIO";

        }
        private void validarCampos(object sender, EventArgs e)
        {
            if (txtAgregarComentario.Text != null)
            {
                btnAgregarComentario.Enabled = true;
            }
            else
            {
                btnAgregarComentario.Enabled = false;
                MessageBox.Show("No pueden estar los campos vacios para realizar la busqueda");
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAgregarComentario_Click(object sender, EventArgs e)
        {
            string bandera = "0";
            int i = 0;
            while (bandera == "0")
            {
                string observaciones = txtAgregarComentario.Text;
                string respuesta;

                cls_observaciones.m_IdSocio = idSocio;
                cls_observaciones.m_Observacion = observaciones;
                cls_observaciones.m_Fecha = DateTime.Now;
                respuesta = cls_observaciones.guardarObservacion();
                if (respuesta != "0")
                {
                    bandera = respuesta;
                    MessageBox.Show(respuesta);
                    txtAgregarComentario.Text = "";
                    FrmObservacionesAdeudos_Load(sender, e);
                }
                else
                {
                    i++;
                }
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtVerComentario.Visible = true;
            txtVerComentario.Enabled = false;
            txtVerComentario.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }
    }
}
