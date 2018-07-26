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
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
        {
            InitializeComponent();
        }
        ClsUsuario cls_usuario = new ClsUsuario();
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
        public void llenarDatagrid()
        {
            cls_usuario.m_IdUsuario = 1;
            cls_usuario.m_TipoBusqueda = 2;
            DataTable dt = cls_usuario.buscarUsuario();
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Aun no cuenta con usuarios", "no hay usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dgvUsuarios.DataSource = dt;
            }
        }
        private void btnVerUsuarios_Click(object sender, EventArgs e)
        {
            llenarDatagrid();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea guardar y continuar?", "Continuar", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
                    while (bandera == "0")
                    {
                        
                        string respuesta;
                        cls_usuario.m_Nombre = txtNombre.Text;
                        cls_usuario.m_Puesto = txtPuesto.Text;
                        cls_usuario.m_Login = txtLogin.Text;
                        cls_usuario.m_Nivel = Convert.ToInt32(cmbNivel.Text);
                        cls_usuario.m_Password = txtPassword.Text;
                        cls_usuario.m_Fingerprint = 'p';
                        cls_usuario.m_FechaAlta = DateTime.Now;
                        cls_usuario.m_Fecha_modif = DateTime.Now;
                        cls_usuario.m_User_modif = "No";
                        respuesta = cls_usuario.guardarUsuario();
                        if (respuesta != "0")
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
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            validarControles(false, "Agregar");
            btnModificar.Enabled = true;
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Equals("") && txtNombre.Enabled.Equals(false))
            {
                MessageBox.Show("Favor de seleccionar un Usuario", "Seleccionar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (btnModificar.Text == "Guardar")
            {
               
                string respuesta2="";
                cls_usuario.m_Nombre = txtNombre.Text;
                cls_usuario.m_Puesto = txtPuesto.Text;
                cls_usuario.m_Login = txtLogin.Text;
                cls_usuario.m_Nivel = Convert.ToInt32(cmbNivel.Text);
                cls_usuario.m_Password = txtPassword.Text;
                cls_usuario.m_Fingerprint = 'p';
                cls_usuario.m_Fecha_modif = DateTime.Now;
                cls_usuario.m_User_modif = Login.nombre;
                string respuesta = cls_usuario.modificarUsuario();
                MessageBox.Show(respuesta2);
                btnAgregar.Enabled = true;
                llenarDatagrid();
                btnModificar.Text = "Modificar";
                btnModificar.Image = Properties.Resources.pencil;
                validarControles(false, "Agregar");
            }
            else
            {
                btnModificar.Text = "Guardar";
                btnModificar.Image = Properties.Resources.add1;
                btnAgregar.Enabled = false;
                validarModificar(true);
            }
        }
        private void btnBuscarUsuario_Click(object sender, EventArgs e)
        {
            if (txtIdUsuario.Text == "" || txtIdUsuario.Text==null)
            {
                MessageBox.Show("Ingrese un ID de usuario", "No se encontro Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                cls_usuario.m_IdUsuario = Convert.ToInt32(txtIdUsuario.Text);
                cls_usuario.m_TipoBusqueda = 1;
                DataTable dt = cls_usuario.buscarUsuario();
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontro Usuario con la clave ingresada", "No se encontro Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dgvUsuarios.DataSource = dt;
                }
            }
        }
        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvUsuarios.CurrentRow;
            txtNombre.Text = Convert.ToString(row.Cells["Nombre"].Value);
            txtPuesto.Text = Convert.ToString(row.Cells["Puesto"].Value);
            txtLogin.Text = Convert.ToString(row.Cells["Login"].Value);
            txtPassword.Text = Convert.ToString(row.Cells["Password"].Value);
            cmbNivel.Text = Convert.ToString(row.Cells["Nivel"].Value);
        }
        public void validarControles(bool bandera, string textoBoton)
        {
           
            txtPuesto.Enabled = bandera;
            txtPuesto.Text = "";
            txtLogin.Enabled = bandera;
            txtLogin.Text = "";
            txtPassword.Enabled = bandera;
            txtPassword.Text = "";
            txtNombre.Enabled = bandera;
            txtNombre.Text = "";
            cmbNivel.Enabled = bandera;
            cmbNivel.Text = "";
            btnCancelar.Enabled = bandera;
            btnAgregar.Text = textoBoton;
        }
        public void validarModificar(bool bandera)
        {
            txtNombre.Enabled = bandera;
            
            txtPuesto.Enabled = bandera;
            txtLogin.Enabled = bandera;
            txtPassword.Enabled = bandera;
            cmbNivel.Enabled = bandera;
            btnCancelar.Enabled = bandera;
        }

        private void btnListaUsuarios_Click(object sender, EventArgs e)
        {
            llenarDatagrid();
        }

        private void cbVerPass_CheckedChanged(object sender, EventArgs e)
        {
            string text = txtPassword.Text;
            if (cbVerPass.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.Text = text;

            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                txtPassword.Text = text;
            }
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {

        }
    }
}
