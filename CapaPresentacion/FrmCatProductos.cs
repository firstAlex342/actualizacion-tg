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
    public partial class FrmCatProductos : Form
    {
        ClsCatProductos cls_cat_productos = new ClsCatProductos();
        int idProducto;

        public FrmCatProductos()
        {
            InitializeComponent();
        }

        

        private void validarBotones(bool bandera)
        {
            button1.Enabled = bandera;
            button2.Enabled = bandera;
            button3.Enabled = bandera;
        }

        private void limpiar()
        {
            txtDescripcion.Text = "";
            txtCosto.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text.Equals("Nuevo"))
            {
                limpiar();
                groupBox1.Enabled = true;
                button1.Text = "Guardar";
                validarBotones(false);
                button1.Enabled = true;
                
                
            }
            else if (button1.Text.Equals("Guardar"))
            {
                if (txtDescripcion.Text.Equals(""))
                {
                    MessageBox.Show("Ingresar descripcion");
                    txtDescripcion.Focus();
                }
                else if (txtCosto.Text.Equals(""))
                {
                    MessageBox.Show("Ingresar el precio del producto");
                    txtCosto.Focus();
                }
                else
                {
                    cls_cat_productos.m_descripcion = txtDescripcion.Text;
                    cls_cat_productos.m_precio = Convert.ToDouble(txtCosto.Text);
                    string respuesta = cls_cat_productos.catProductosInsert();
                    MessageBox.Show(respuesta);
                    limpiar();
                    groupBox1.Enabled = false;
                    button1.Text = "Nuevo";
                    llenarDatagrid();
                    validarBotones(true);
                }



            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            limpiar();
            validarBotones(true);
            groupBox1.Enabled = false;
            button1.Text = "Nuevo";
            button2.Text = "Modificar";
        }

        private void llenarDatagrid()
        {
            dataGridView1.DataSource = cls_cat_productos.catProductosSelect();
        }

        private void FrmCatProductos_Load(object sender, EventArgs e)
        {
            llenarDatagrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           

            if(button2.Text.Equals("Modificar"))
            {

                if (txtDescripcion.Text.Equals(""))
                {
                    MessageBox.Show("Seleccionar Membresia a modificar");
                }
                else
                {
                    groupBox1.Enabled = true;
                    button2.Text = "Guardar";
                    validarBotones(false);
                    button2.Enabled = true;
                }

            }

           else if (button2.Text.Equals("Guardar"))
            {
                if (txtDescripcion.Text.Equals(""))
                {
                    MessageBox.Show("Seleccionar Membresia a modificar");
                }
                else if(txtCosto.Text.Equals(""))
                {
                    MessageBox.Show("Ingresar el precio");
                }
                else
                {
                    cls_cat_productos.m_idProducto = idProducto;
                    cls_cat_productos.m_descripcion = txtDescripcion.Text;
                    cls_cat_productos.m_precio = Convert.ToDouble(txtCosto.Text);
                    string respuesta = cls_cat_productos.catProductosUpdate();
                    MessageBox.Show(respuesta);
                    limpiar();
                    groupBox1.Enabled = false;
                    button2.Text = "Modificar";
                    llenarDatagrid();
                    validarBotones(true);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idProducto = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtDescripcion.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtCosto.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(txtDescripcion.Text.Equals(""))
            {
                MessageBox.Show("Seleccionar un producto");
            }
            else
            {
                if (MessageBox.Show("¿Eliminar producto?", "Continuar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    cls_cat_productos.m_idProducto = idProducto;
                    string respuesta = cls_cat_productos.catProductosDelete();
                    MessageBox.Show(respuesta);
                    limpiar();
                    llenarDatagrid();
                }
            }
        }
    }
}
