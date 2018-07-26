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
    public partial class FrmEmail : Form
    {
        ClsTextoEmail cls_texto_email = new ClsTextoEmail();
        cambios cb = new cambios();
        public FrmEmail()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            cb.Correo = textBox1.Text;
            cb.Save();
            MessageBox.Show("Correo modificado correctamente");
            this.Hide();
        }

        private void FrmEmail_Load(object sender, EventArgs e)
        {
            textBox1.Text = cb.Correo;
        }
    }
}
