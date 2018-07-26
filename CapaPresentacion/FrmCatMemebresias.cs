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
using CapaPresentacion;

namespace CapaPresentacion
{
    public partial class FrmCatMemebresias : Form
    {
        ClsMembresias cls_membresias = new ClsMembresias();
        ClsClvMembresias cls_clv_membresias = new ClsClvMembresias();
        int Dom;
        int Lun;
        int Mar;
        int Mier;
        int Jue;
        int Vie;
        int Sab;
        int Matutino;
        string HoraInicioiMaT;
        string HoraFinalMat;
        int Vespertino;
        string HoraInicioVesp;
        string HoraFinalVesp;
        int Activa;
        char Viajero;
        int ConteoViajero;
        int Grupal;
        int numPersonasGrupal;
        string prefijo;
        int BanderaPrefijo;
        int id_membresia;

        public FrmCatMemebresias()
        {
            InitializeComponent();
        }

        private void validarDias()
        {
            if (chkDomingo.Checked)
            {
                Dom = 1;
            }
            else
            {
                Dom = 0;
            }

            if (chkLunes.Checked)
            {
                Lun = 1;
            }
            else
            {
                Lun = 0;
            }

            if (chkMartes.Checked)
            {
                Mar = 1;
            }
            else
            {
                Mar = 0;
            }

            if (chkMiercoles.Checked)
            {
                Mier = 1;
            }
            else
            {
                Mier = 0;
            }

            if (chkJueves.Checked)
            {
                Jue = 1;
            }
            else
            {
                Jue = 0;
            }

            if (chkViernes.Checked)
            {
                Vie = 1;
            }
            else
            {
                Vie = 0;
            }

            if (chkSabado.Checked)
            {
                Sab = 1;
            }
            else
            {
                Sab = 0;
            }
        }

        private void validarHorarios()
        {
            if(chkMatutino.Checked)
            {
                Matutino = 1;
                HoraInicioiMaT = mktHoraInicioMatutino.Text;
                HoraFinalMat = mktHoraFinalMatutino.Text;
            }
            else
            {
                Matutino = 0;
                HoraInicioiMaT = "0";
                HoraFinalMat = "0";
            }

            if(chkVespertino.Checked)
            {
                Vespertino = 1;
                HoraInicioVesp = mktHoraInicioVespertino.Text;
                HoraFinalVesp = mktHoraFinalVespertino.Text;
            }
            else
            {
                Vespertino = 0;
                HoraInicioVesp = "0";
                HoraFinalVesp = "0";
            }

        }

        public void validarDatosExtras()
        {
            if(chkActiva.Checked)
            {
                Activa = 1;
            }
            else
            {
                Activa = 0;
            }

            if(chkViajero.Checked)
            {
                Viajero = 'S';
                if(txtDiasViajero.Text.Equals(""))
                {
                    ConteoViajero = 0;
                }

                else
                {
                    ConteoViajero = Convert.ToInt32(txtDiasViajero.Text);
                }
                
            }
            else
            {
                Viajero = 'N';
                ConteoViajero = 0;
            }

            if(chkGrupal.Checked)
            {
                Grupal = 1;
                numPersonasGrupal = Convert.ToInt32(txtNumPersonasGrupal.Text);
            }
            else
            {
                Grupal = 0;
                numPersonasGrupal = 0;
            }

            if(chkPrefijo.Checked)
            {
                BanderaPrefijo = 1;
                prefijo = txtClavePrefijo.Text;
            }
            else
            {
                BanderaPrefijo = 0;
                prefijo = "";
            }
            


        }

        private void guardarDatos()
        {
            char membresia='M';
            validarDias();
            validarHorarios();
            validarDatosExtras();

           if(rdbMembresia.Checked)
           {
                membresia = 'M';
           }
           else if(rdbServicio.Checked)
            {
                membresia = 'S';
            }

            cls_membresias.m_Descripcion = txtDescripcion.Text;
            cls_membresias.m_Tipo = membresia;
            cls_membresias.m_Costo = Convert.ToDouble(txtCosto.Text);
            cls_membresias.m_Perdiodo = Convert.ToInt32(txtPeriodo.Text);
            cls_membresias.m_User_modif = Login.nombre;
            cls_membresias.m_Dom = Dom;
            cls_membresias.m_Lun = Lun;
            cls_membresias.m_Mar = Mar;
            cls_membresias.m_Mier = Mier;
            cls_membresias.m_Jue = Jue;
            cls_membresias.m_Vie = Vie;
            cls_membresias.m_Sab = Sab;
            cls_membresias.m_Matutino = Matutino;
            cls_membresias.m_HoraInicioiMaT = HoraInicioiMaT;
            cls_membresias.m_HoraFinalMat = HoraFinalMat;
            cls_membresias.m_Vespertino = Vespertino;
            cls_membresias.m_HoraInicioVesp = HoraInicioVesp;
            cls_membresias.m_HoraFinalVesp = HoraFinalVesp;
            cls_membresias.m_Activa = Activa;
            cls_membresias.m_Viajero = Viajero;
            cls_membresias.m_ConteoViajero = ConteoViajero;
            cls_membresias.m_Grupal = Grupal;
            cls_membresias.m_numeroPersonasGrupal = numPersonasGrupal;
            cls_membresias.m_prefijo = txtClavePrefijo.Text;
            cls_membresias.m_BanderaPrefijo = BanderaPrefijo;
        }
        private void activarDatagrid(bool bandera)
        {
            dataGridView1.Enabled = bandera;
        }
        private void activarGroupBox(bool bandera)
        {
            gbDatosExtras.Enabled = bandera;
            gbDiaSemana.Enabled = bandera;
            gbInformacion.Enabled = bandera;
            groupBox3.Enabled = bandera;
            
        }
        private void limpiar()
        {
            txtDescripcion.Text = "";
            cmbTipo.Text = "";
            txtCosto.Text = "";
            txtPeriodo.Text = "";
            //chkActiva.Enabled = false;
            chkLunes.Checked = false;
            chkMartes.Checked = false;
            chkMiercoles.Checked = false;
            chkJueves.Checked = false;
            chkViernes.Checked = false;
            chkSabado.Checked = false;
            chkDomingo.Checked = false;
            chkGrupal.Checked = false;
            chkViajero.Checked = false;
            chkPrefijo.Checked = false;
            txtNumPersonasGrupal.Text = "";
            txtDiasViajero.Text = "";
            txtClavePrefijo.Text = "";
            chkMatutino.Checked = false;
            mktHoraInicioMatutino.Text = "";
            mktHoraFinalMatutino.Text = "";
            rdbMembresia.Checked = false;
            //rdbProducto.Checked = false;
            rdbServicio.Checked = false;
            btnModificar.Text = "Modificar";
            btnNueva.Text = "Nueva";

        }

        private bool validarControladores()
        {
            if (txtDescripcion.Text.Equals(""))
            {
                MessageBox.Show("Ingresar Descripción");
                txtDescripcion.Focus();
                return false;
            }

            else if (!rdbMembresia.Checked && !rdbServicio.Checked)
            {
                MessageBox.Show("Seleccionar el tipo de membresia");
                rdbMembresia.Focus();
                return false;
            }

            else if (txtCosto.Text.Equals(""))
            {
                MessageBox.Show("Ingresar el costo");
                txtCosto.Focus();
                return false;
            }

            else if (txtPeriodo.Text.Equals(""))
            {
                MessageBox.Show("Ingresar periodo");
                txtPeriodo.Focus();
                return false;
            }

            else if (chkGrupal.Checked && txtNumPersonasGrupal.Text.Equals(""))
            {
                MessageBox.Show("Seleccionar el numero de personas");
                txtNumPersonasGrupal.Focus();
                return false;
            }

            else if (chkViajero.Checked && txtDiasViajero.Text.Equals(""))
            {
                MessageBox.Show("Seleccionar los dias de clases");
                txtDiasViajero.Focus();
                return false;
            }

            else if (!chkLunes.Checked && !chkMartes.Checked && !chkMiercoles.Checked && !chkJueves.Checked && !chkViernes.Checked && !chkSabado.Checked && !chkDomingo.Checked)
            {
                MessageBox.Show("Favor de seleccionar los dias de la semana");
                return false;
            }

            else if (chkMatutino.Checked && mktHoraInicioMatutino.Text.Length < 5 || chkMatutino.Checked && mktHoraFinalMatutino.Text.Length < 5)
            {
                MessageBox.Show("Ingresar horarios correctamente");
                chkMatutino.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(btnNueva.Text.Equals("Nueva"))
            {
                limpiar();
                btnNueva.Text = "Agregar";
                activarGroupBox(true);
                activarDatagrid(false);
            }
            else if((btnNueva.Text.Equals("Agregar")))
            {
                
                if(validarControladores())
                {
                    activarGroupBox(false);
                    guardarDatos();
                    string respuesta = cls_membresias.altaMembresias();
                    MessageBox.Show(respuesta);
                    btnNueva.Text = "Nueva";
                    limpiar();
                    llenarDataGrid();
                    activarDatagrid(true);
                }

                
            }
            
        }

        private void llenarComboClveMembresia()
        {

            DataTable dt = cls_clv_membresias.seleccionarClvMembresias();
            //se llena el datasoucer con lo que regreso el SP
            cmbTipo.DataSource = dt;
            //se coloca el indice o option en web
            cmbTipo.ValueMember = "clvMembresia";
            //se coloca el valor del combo
            cmbTipo.DisplayMember = "Descripcion";
            // cmbTipo.SelectedIndex = 1;
            cmbTipo.Text = "";
        }

        private void llenarDataGrid()
        {
            dataGridView1.DataSource = cls_membresias.catTipoMembresia();
        }

        private void FrmCatMemebresias_Load(object sender, EventArgs e)
        {
            

            llenarComboClveMembresia();
            llenarDataGrid();
            

        }

        private void diasMembresia(bool lunes, bool martes, bool miercoles, bool jueves, bool viernes, bool sabado, bool domingo)
        {
            if(lunes)
            {
                chkLunes.Checked = true;
            }
            else
            {
                chkLunes.Checked = false;
            }

            if (martes)
            {
                chkMartes.Checked = true;
            }
            else
            {
                chkMartes.Checked = false;
            }

            if (miercoles)
            {
                chkMiercoles.Checked = true;
            }
            else
            {
                chkMiercoles.Checked = false;
            }

            if (jueves)
            {
                chkJueves.Checked = true;
            }
            else
            {
                chkJueves.Checked = false;
            }

            if (viernes)
            {
                chkViernes.Checked = true;
            }
            else
            {
                chkViernes.Checked = false;
            }

            if (sabado)
            {
                chkSabado.Checked = true;
            }
            else
            {
                chkSabado.Checked = false;
            }

            if (domingo)
            {
                chkDomingo.Checked = true;
            }
            else
            {
                chkDomingo.Checked = false;
            }

        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                bool lunes, martes, miercoles, jueves, viernes, sabado, domingo, activa, grupal, prefijo, horario;
                char membresia, viajero;
                membresia = Convert.ToChar(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                if (membresia.Equals('M'))
                {
                    rdbMembresia.Checked = true;
                    //rdbProducto.Checked = false;
                    rdbServicio.Checked = false;
                }
                else if (membresia.Equals('S'))
                {
                    rdbMembresia.Checked = false;
                    //rdbProducto.Checked = false;
                    rdbServicio.Checked = true;
                }
                else if (membresia.Equals('P'))
                {
                    rdbMembresia.Checked = false;
                    //rdbProducto.Checked = true;
                    rdbServicio.Checked = false;
                }
                if (dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString().Equals(""))
                {
                    domingo = false;
                    lunes = false;
                    martes = false;
                    miercoles = false;
                    jueves = false;
                    viernes = false;
                    sabado = false;
                }
                else
                {
                    domingo = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString());
                    lunes = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString());
                    martes = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString());
                    miercoles = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString());
                    jueves = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString());
                    viernes = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString());
                    sabado = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[15].Value.ToString());
                }

                if (!dataGridView1.Rows[e.RowIndex].Cells[16].Value.ToString().Equals(""))
                {
                    horario = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[16].Value.ToString());
                }
                else
                {
                    horario = false;
                }



                if (horario)
                {
                    chkMatutino.Checked = true;
                }
                else
                {
                    chkMatutino.Checked = false;
                }

                mktHoraInicioMatutino.Text = dataGridView1.Rows[e.RowIndex].Cells[17].Value.ToString();
                mktHoraFinalMatutino.Text = dataGridView1.Rows[e.RowIndex].Cells[18].Value.ToString();




                id_membresia = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtDescripcion.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtCosto.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtPeriodo.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                diasMembresia(lunes, martes, miercoles, jueves, viernes, sabado, domingo);

                if (dataGridView1.Rows[e.RowIndex].Cells[23].Value.ToString().Equals(""))
                {
                    activa = true;
                }
                else
                {
                    activa = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[23].Value.ToString());
                }

                if (dataGridView1.Rows[e.RowIndex].Cells[25].Value.ToString().Equals(""))
                {
                    grupal = false;
                }
                else
                {
                    grupal = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[25].Value.ToString());
                }



                txtNumPersonasGrupal.Text = dataGridView1.Rows[e.RowIndex].Cells[26].Value.ToString();
                txtDiasViajero.Text = dataGridView1.Rows[e.RowIndex].Cells[24].Value.ToString();
                viajero = Convert.ToChar(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                if (dataGridView1.Rows[e.RowIndex].Cells[28].Value.ToString().Equals(""))
                {
                    prefijo = false;
                }
                else
                {
                    prefijo = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[28].Value.ToString());
                }

                txtClavePrefijo.Text = dataGridView1.Rows[e.RowIndex].Cells[27].Value.ToString();
                if (activa)
                {
                    chkActiva.Checked = true;
                }

                else
                {
                    chkActiva.Checked = false;
                }

                if (grupal)
                {
                    chkGrupal.Checked = true;
                }
                else
                {
                    chkGrupal.Checked = false;
                }

                if (prefijo)
                {
                    chkPrefijo.Checked = true;
                }
                else
                {
                    chkPrefijo.Checked = false;
                }

                if (viajero.Equals('S'))
                {
                    chkViajero.Checked = true;
                }
                else
                {
                    chkViajero.Checked = false;
                }
                for (int i = 0; i <= cmbTipo.Items.Count; i++)
                {
                    cmbTipo.SelectedIndex = i;
                    char claveMem = Convert.ToChar(cmbTipo.SelectedValue.ToString());
                    if (membresia.Equals(claveMem))
                    {
                        cmbTipo.SelectedIndex = i;
                        break;
                    }


                }
            }

            catch(Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(btnModificar.Text.Equals("Modificar"))
            {
                activarGroupBox(true);
                activarDatagrid(false);
                btnModificar.Text = "Guardar";
            }
            else if(btnModificar.Text.Equals("Guardar"))
            {
                if (validarControladores())
                {
                    activarGroupBox(false);
                    cls_membresias.m_idMembresia = id_membresia;
                    guardarDatos();
                    string respuesta = cls_membresias.catTipoMembresiaUpdate();
                    MessageBox.Show(respuesta);
                    btnModificar.Text = "Modificar";
                    limpiar();
                    llenarDataGrid();
                    activarDatagrid(true);
                }
                    
            }
        }

        private void mktHoraInicioMatutino_Click(object sender, EventArgs e)
        {
            mktHoraInicioMatutino.Focus();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
            activarGroupBox(false);
            activarDatagrid(true);
            limpiar();
        }

        private void chkMatutino_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdbProducto_CheckedChanged(object sender, EventArgs e)
        {

            activarGroupBox(false);
            gbInformacion.Enabled = true;
        }

        private void rdbMembresia_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
