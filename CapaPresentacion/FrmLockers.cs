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
    public partial class FrmLockers : Form
    {
        ClsLockers cls_lokers = new ClsLockers();
        int idLocker;
        public FrmLockers()
        {
            InitializeComponent();
        }

        private void FrmLockers_Load(object sender, EventArgs e)
        {
           dataGridView1.DataSource= cls_lokers.catLockersSelectOcupados();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cls_lokers.catLockersSelectLibres();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cls_lokers.catLockersSelectOcupados();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cls_lokers.catLockersSelectTodo();
        }

        private void limpiar()
        {
            btnCambiarLocker.Text = "Cambiar Locker";
            btnNuevo.Text = "Nuevo";
            btnModificar.Text = "Modificar";
            txtNumLocker.Text = "";
            txtClaveSocio.Text = "";
            rdbMasculino.Checked = false;
            rdbFemenino.Checked = false;
            cbbNuevoLocker.Enabled = false;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (btnNuevo.Text.Equals("Nuevo"))
            {
                limpiar();
                chkOcupado.Enabled = false;
                chkStatus.Enabled = false;
                btnNuevo.Text = "Agregar";
                groupBox(true);
                
            }

            else if (btnNuevo.Text.Equals("Agregar"))
            {
                if (txtNumLocker.Text.Equals(""))
                {
                    MessageBox.Show("Favor de ingresar el numero de locker");
                }
                else if(!rdbMasculino.Checked || !rdbFemenino.Checked)
                {
                    MessageBox.Show("Favor de seleccionar el sexo");
                    rdbFemenino.Focus();
                }
                else
                {
                    char sexo = 'M';
                    if (rdbMasculino.Checked)
                    {
                        sexo = 'M';
                    }
                    else
                    {
                        sexo = 'F';
                    }
                    cls_lokers.m_Descripcion = txtNumLocker.Text;
                    cls_lokers.m_Sexo = sexo;
                    cls_lokers.m_User_modif = Login.nombre;
                    string respuesta = cls_lokers.catLockersInsert();
                    MessageBox.Show(respuesta);
                    txtNumLocker.Text = "";
                    rdbFemenino.Checked = false;
                    rdbMasculino.Checked = false;

                    chkOcupado.Enabled = true;
                    chkStatus.Enabled = true;
                    btnNuevo.Text = "Nuevo";
                    groupBox(false);
                }


                
               
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            //string concepto = dataGridView1.Rows[e.RowIndex].Cells["Concepto"].Value.ToString();

        }

        public void groupBox(bool condicion)
        {
            groupBox1.Enabled = condicion;
            groupBox2.Enabled = condicion;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            if (btnModificar.Text.Equals("Modificar"))
            {
                btnModificar.Text = "Guardar";
                groupBox(true);
            }

            else if(btnModificar.Text.Equals("Guardar"))
            {
                if (txtNumLocker.Text.Equals(""))
                {
                    MessageBox.Show("Favor de ingresar el numero de locker");
                }
                else if (rdbMasculino.Checked==false && rdbFemenino.Checked == false)
                {
                    MessageBox.Show("Favor de seleccionar el sexo");
                    rdbFemenino.Focus();
                }
                else
                {
                    char sexo = 'M';
                    char ocupado = 'N';
                    char status = 'S';
                    int idSocio = 0;
                    if (rdbFemenino.Checked)
                    {
                        sexo = 'F';
                    }
                    else if (rdbMasculino.Checked)
                    {
                        sexo = 'M';
                    }

                    if (chkOcupado.Checked == true)
                    {
                        ocupado = 'S';
                    }

                    else
                    {
                        ocupado = 'N';
                        idSocio = 0;
                    }

                    if (chkStatus.Checked)
                    {
                        status = 'S';
                    }
                    else
                    {
                        status = 'N';
                    }



                    cls_lokers.m_idLocker = idLocker;
                    cls_lokers.m_Descripcion = txtNumLocker.Text;
                    cls_lokers.m_Sexo = sexo;
                    cls_lokers.m_Ocupado = ocupado;
                    cls_lokers.m_Status = status;
                    cls_lokers.m_User_modif = Login.nombre;
                    cls_lokers.m_idSocio = idSocio;
                    string respuesta = cls_lokers.catLockersUpdate();
                    MessageBox.Show(respuesta);
                    btnModificar.Text = "Modificar";
                    groupBox(false);
                }

               
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                idLocker = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["IdLocker"].Value.ToString());
                string lockerNum = dataGridView1.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString();
                char sexo = Convert.ToChar(dataGridView1.Rows[e.RowIndex].Cells["Sexo"].Value.ToString());
                char status = Convert.ToChar(dataGridView1.Rows[e.RowIndex].Cells["Status"].Value.ToString());
                char ocupado = Convert.ToChar(dataGridView1.Rows[e.RowIndex].Cells["Ocupado"].Value.ToString());
                txtClaveSocio.Text = dataGridView1.Rows[e.RowIndex].Cells["idSocio"].Value.ToString();
                txtNumLocker.Text = lockerNum.Replace("LOCKER", "");
                if (sexo.Equals('F'))
                {
                    rdbFemenino.Checked = true;
                }
                else if (sexo.Equals('M'))
                {
                    rdbMasculino.Checked = true;
                }
                if (status.Equals('S'))
                {
                    chkStatus.Checked = true;
                }
                else
                {
                    chkStatus.Checked = false;
                }

                if (ocupado.Equals('S'))
                {
                    chkOcupado.Checked = true;
                }
                else
                {
                    chkOcupado.Checked = false;
                }
            }

            catch
            {

            }
        }

        private void chkOcupado_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtClaveSocio_KeyDown(object sender, KeyEventArgs e)
        {
            if ((int)e.KeyCode == (int)Keys.Enter)
            {
                cls_lokers.m_idSocio = Convert.ToInt32(txtClaveSocio.Text);
               DataTable dt = cls_lokers.catLockersSelectId();

                foreach (DataRow filas in dt.Rows)
                {
                    idLocker = Convert.ToInt32(filas["idLocker"].ToString());
                    string lockerNum = filas["Descripcion"].ToString();
                    char sexo = Convert.ToChar(filas["Sexo"].ToString());
                    if (sexo.Equals('F'))
                    {
                        rdbFemenino.Checked = true;
                    }
                    else if (sexo.Equals('M'))
                    {
                        rdbMasculino.Checked = true;
                    }

                    chkStatus.Checked = true;

                    chkOcupado.Checked = true;
                    txtNumLocker.Text = lockerNum.Replace("LOCKER", "");


                   // TxtIdSocio.Text = filas["id"].ToString();
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtNumLocker.Text.Equals(""))
            {
                MessageBox.Show("Favor de seleccionar locker");
            }
            else
            {
                if(btnCambiarLocker.Text.Equals("Cambiar Locker"))
                {

                    btnCambiarLocker.Text = "Guardar Cambio";
                    cbbNuevoLocker.Enabled = true;
                }
                else
                {
                    if(txtClaveSocio.Text.Equals("")||txtClaveSocio.Text.Equals("0"))
                    {
                        MessageBox.Show("Colocar el ID del socio");
                        txtClaveSocio.Focus();
                    }
                    else
                    {
                        cls_lokers.m_idLocker = idLocker;
                        cls_lokers.idLockerNuevo = Convert.ToInt32(cbbNuevoLocker.SelectedValue.ToString());
                        string respuesta = cls_lokers.catLockersUpdateLocker();
                        MessageBox.Show(respuesta);
                        limpiar();
                    }
                   
                }
            }
        }

        private void seleccionar_locker(int tipoBusqueda)
        {
            //se le asigna un valor a la variable tipo que se encarga de
            //seleccionar el tipo de busqueda en el SP
            cls_lokers.Tipo = tipoBusqueda;
            //se llama al metodo  donde esta la accion de SP
            DataTable dt = cls_lokers.verLockers();
            //se llena el datasoucer con lo que regreso el SP
            cbbNuevoLocker.DataSource = dt;
            //se coloca el indice o option en web
            cbbNuevoLocker.ValueMember = "idLocker";
            //se coloca el valor del combo
            cbbNuevoLocker.DisplayMember = "Descripcion";
            cbbNuevoLocker.Text = "";
        }

        private void rdbMasculino_CheckedChanged(object sender, EventArgs e)
        {
            seleccionar_locker(1);
        }

        private void rdbFemenino_CheckedChanged(object sender, EventArgs e)
        {
            seleccionar_locker(2);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
            groupBox(false);
            limpiar();
        }
    }
}
