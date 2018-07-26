using CapaLogicaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmTextoEmails : Form
    {
        public FrmTextoEmails()
        {
            InitializeComponent();
        }
        ClsTextoEmail cls_textoEmail = new ClsTextoEmail();
        private void FrmTextoEmails_Load(object sender, EventArgs e)
        {
            DataTable dt = cls_textoEmail.TextosEmails();
            foreach (DataRow filas in dt.Rows)
            {
                txtAsuntoAdeudos.Text = filas["AsuntoDeudas"].ToString();
                txtCuerpoAdeudos.Text = filas["TextoCorreo"].ToString();
                txtAsuntoCumpleañeros.Text = filas["AsuntoCumpleanos"].ToString();
                txtCuerpoCumpleañeros.Text = filas["TextoCumpleAnos"].ToString();
            }
        }

        private void btnModificarAdeudos_Click(object sender, EventArgs e)
        {
            
            txtAsuntoAdeudos.Enabled = true;
            txtCuerpoAdeudos.Enabled = true;
            btnGuardarAdeudos.Enabled = true;
        }

        private void btnModificarCumpleañeros_Click(object sender, EventArgs e)
        {
            txtAsuntoCumpleañeros.Enabled = true;
            txtCuerpoCumpleañeros.Enabled = true;
            btnGuardarCumpleañeos.Enabled = true;
        }
        
        private void btnGuardarAdeudos_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea guardar y continuar?", "Continuar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                cls_textoEmail.m_AsuntoDeudas = txtAsuntoAdeudos.Text;
                cls_textoEmail.m_AsuntoCumpleanos = txtAsuntoCumpleañeros.Text;
                cls_textoEmail.m_TextoCorreo = txtCuerpoAdeudos.Text;
                cls_textoEmail.m_TextoCumpleAnos = txtCuerpoCumpleañeros.Text;
                string respuesta = cls_textoEmail.modificarTextosEmails();
                MessageBox.Show(respuesta);
            }
        }

        private void btnGuardarCumpleañeos_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea guardar y continuar?", "Continuar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                cls_textoEmail.m_AsuntoDeudas = txtAsuntoAdeudos.Text;
                cls_textoEmail.m_AsuntoCumpleanos = txtAsuntoCumpleañeros.Text;
                cls_textoEmail.m_TextoCorreo = txtCuerpoAdeudos.Text;
                cls_textoEmail.m_TextoCumpleAnos = txtCuerpoCumpleañeros.Text;
                string respuesta = cls_textoEmail.modificarTextosEmails();
                MessageBox.Show(respuesta);
            }
        }
    }
}
