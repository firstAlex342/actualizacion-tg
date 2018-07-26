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
    public partial class FrmIntroduceSerial : Form
    {
        private string serial;


        public FrmIntroduceSerial()
        {
            InitializeComponent();
            this.Serial = String.Empty;           
        }



        //-------------properties
        public string Serial
        {
            set { serial = value; }
            get { return serial; }
        }


        //------------eventos

        private void button1_Click(object sender, EventArgs e)
        {
            this.Serial = textBox1.Text.Trim();
            this.Visible = false;
        }

        
    }
}
