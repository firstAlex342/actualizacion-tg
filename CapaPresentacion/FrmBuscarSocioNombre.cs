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
    public partial class FrmBuscarSocioNombre : Form
    {
        ClsSocios cls_socios = new ClsSocios();
        string nombreSocio;

        public FrmBuscarSocioNombre(string nombreSocio)
        {
            InitializeComponent();
            this.nombreSocio = nombreSocio;

        }

        private void FrmBuscarSocioNombre_Load(object sender, EventArgs e)
        {
            cls_socios.m_Nombre = nombreSocio;
            DataTable dt = cls_socios.buscarSocioPorNombre();
            dataGridView1.DataSource = dt;
            Login.idSocio = 0;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Login.idSocio =  int.Parse(dataGridView1.Rows[e.RowIndex].Cells["idSocio"].Value.ToString());
            this.Hide();
        }
    }
}
