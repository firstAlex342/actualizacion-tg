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
    public partial class FrmClvMembresias : Form
    {
        ClsClvMembresias cls_clv_membresias = new ClsClvMembresias();
        public FrmClvMembresias()
        {
            InitializeComponent();
        }

        private void FrmClvMembresias_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cls_clv_membresias.seleccionarClvMembresias();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cls_clv_membresias.m_clvMembresia = Convert.ToChar(txtClaveMembresia.Text);
            cls_clv_membresias.m_Descripcion = txtDescripcion.Text;
            string respuesta = cls_clv_membresias.clvMembresiasIngresar();
            MessageBox.Show(respuesta);
            dataGridView1.DataSource = cls_clv_membresias.seleccionarClvMembresias();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cls_clv_membresias.m_idClaveMembresias = Convert.ToInt32(txtIdMembresia.Text);
            string respuesta = cls_clv_membresias.clvMembresiasEliminar();
            MessageBox.Show(respuesta);
            dataGridView1.DataSource = cls_clv_membresias.seleccionarClvMembresias();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdMembresia.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtClaveMembresia.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtDescripcion.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }
    }
}
