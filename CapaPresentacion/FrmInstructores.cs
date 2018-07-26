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
    public partial class FrmInstructores : Form
    {
        ClsInstructores cls_instructores = new ClsInstructores();
        string idEntrenador;
        public FrmInstructores()
        {
            InitializeComponent();
        }

        private void txtSoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        private void txtSoloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {



            if (!btnAgregar.Text.Equals("Guardar"))
            {
                validarControles(true, "Guardar");
                btnModificar.Enabled = false;
            }
            else
            {
                string bandera = "0";
                int i = 0;
                while(bandera=="0")
                {
                    string PrimeraLetraNombre = txtNombre.Text[i].ToString();
                    string Apellido = txtApellido.Text;
                    string claveInstructor = PrimeraLetraNombre + Apellido;
                    string respuesta;

                    cls_instructores.m_idEntrenador = claveInstructor;
                    cls_instructores.m_NombreCompleto = txtNombre.Text + Apellido;
                    cls_instructores.m_Especialidad = txtEspecialidad.Text;
                    cls_instructores.m_LugarNacimiento = txtLugarNacimiento.Text;
                    cls_instructores.m_HoraEntrada = Convert.ToDateTime(txtHoraEntrada.Text);
                    cls_instructores.m_Activo = true;
                    respuesta = cls_instructores.guardarInstructor();
                    if(respuesta!="0")
                    {
                        bandera = respuesta;
                        MessageBox.Show(respuesta);
                    }
                    else
                    {
                        i++;
                    }  
                }
                
                validarControles(false, "Agregar");
                btnModificar.Enabled = true;
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            validarControles(false,"Agregar");
            btnModificar.Enabled = true;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(txtNombre.Text.Equals("")&&txtNombre.Enabled.Equals(false))
            {
                MessageBox.Show("Favor de seleccionar un Intructor","Seleccionar instructor",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else if(btnModificar.Text=="Guardar")
            {
                cls_instructores.m_idEntrenador = idEntrenador;
                cls_instructores.m_NombreCompleto = txtNombre.Text;
                cls_instructores.m_Especialidad = txtEspecialidad.Text;
                cls_instructores.m_LugarNacimiento = txtLugarNacimiento.Text;
                cls_instructores.m_HoraEntrada = Convert.ToDateTime(txtHoraEntrada.Text);
                cls_instructores.m_Activo = chkActivo.Checked;
                string respuesta = cls_instructores.modificarIntructor();
                MessageBox.Show(respuesta);
                btnAgregar.Enabled = true;
                
                llenarDatagrid();
                btnModificar.Text = "Modificar";
                validarControles(false, "Agregar");
            }
            else
            {
                btnModificar.Text = "Guardar";
                btnAgregar.Enabled = false;
                validarModificar(true);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cls_instructores.m_idEntrenador = txtClaveInstructor.Text;
            cls_instructores.m_TipoBusqueda = 1;
            DataTable dt = cls_instructores.buscarInstructor();
            if(dt.Rows.Count==0)
            {
                MessageBox.Show("No se encontro instructor con la clave ingresada","No se encontro instructor",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                dataGridView1.DataSource = dt;
            }

            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            llenarDatagrid();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            idEntrenador = Convert.ToString(row.Cells["idEntrenador"].Value);
            txtNombre.Text = Convert.ToString(row.Cells["NombreCompleto"].Value);
            txtApellido.Text = "Apellido";
            txtEspecialidad.Text = Convert.ToString(row.Cells["Especialidad"].Value);
            txtLugarNacimiento.Text = Convert.ToString(row.Cells["LugarNacimiento"].Value);
            txtHoraEntrada.Text = Convert.ToString(row.Cells["HoraEntrada"].Value);
            chkActivo.Checked = Convert.ToBoolean(row.Cells["Activo"].Value);
            MessageBox.Show(Convert.ToBoolean(row.Cells["Activo"].Value).ToString());


            //MessageBox.Show(datos);

            //TextBox1.Text = Convert.ToString(row.Cells("campo1").Value);
            //TextBox2.Text = Convert.ToString(row.Cells("campo2").Value);
            //TextBox3.Text = Convert.ToString(row.Cells("campo3").Value);
        }

        /****************/
        public void validarControles(bool bandera, string textoBoton)
        {
            txtApellido.Enabled = bandera;
            txtApellido.Text = "";
            txtEspecialidad.Enabled = bandera;
            txtEspecialidad.Text = "";
            txtHoraEntrada.Enabled = bandera;
            txtHoraEntrada.Text = "";
            txtLugarNacimiento.Enabled = bandera;
            txtLugarNacimiento.Text = "";
            txtNombre.Enabled = bandera;
            txtNombre.Text = "";
            chkActivo.Enabled = bandera;
            chkActivo.Checked = false;
            btnCancelar.Enabled = bandera;
            btnAgregar.Text = textoBoton;
        }

        public void validarModificar(bool bandera)
        {
            txtApellido.Enabled = bandera;
            txtEspecialidad.Enabled = bandera;
            txtHoraEntrada.Enabled = bandera;
            txtLugarNacimiento.Enabled = bandera;
            txtNombre.Enabled = bandera;
            chkActivo.Enabled = bandera;
            btnCancelar.Enabled = bandera;

        }

        public void llenarDatagrid()
        {
            cls_instructores.m_idEntrenador = "1";
            cls_instructores.m_TipoBusqueda = 2;
            DataTable dt = cls_instructores.buscarInstructor();
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Aun no cuenta con instructores", "no hay instructores", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dataGridView1.DataSource = dt;
            }
        }

        private void FrmInstructores_Load(object sender, EventArgs e)
        {

        }
    }
}
