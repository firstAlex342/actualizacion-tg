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
    public partial class FrmConfigTicket : Form
    {
        cambios cam = new cambios();
        public FrmConfigTicket()
        {
            InitializeComponent();
        }

        private void FrmConfigTicket_Load(object sender, EventArgs e)
        {
            txtTitulo.Text = cam.TituloTicket;
            txtLinea1.Text = cam.Linea1;
            txtLinea2.Text = cam.Linea2;
            txtLinea3.Text = cam.Linea3;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Guardar Cambios?", "Continuar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                cam.TituloTicket = txtTitulo.Text;
                cam.Linea1 = txtLinea1.Text;
                cam.Linea2 = txtLinea2.Text;
                cam.Linea3 = txtLinea3.Text;
                cam.Save();
                MessageBox.Show("Cambios Guardados correctamente");
                this.Close();             
            }
        }
    }
}
