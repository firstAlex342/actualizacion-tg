namespace CapaPresentacion
{
    partial class FrmCatMemebresias
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbInformacion = new System.Windows.Forms.GroupBox();
            this.rdbServicio = new System.Windows.Forms.RadioButton();
            this.rdbMembresia = new System.Windows.Forms.RadioButton();
            this.chkActiva = new System.Windows.Forms.CheckBox();
            this.txtPeriodo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbDiaSemana = new System.Windows.Forms.GroupBox();
            this.chkDomingo = new System.Windows.Forms.CheckBox();
            this.chkSabado = new System.Windows.Forms.CheckBox();
            this.chkViernes = new System.Windows.Forms.CheckBox();
            this.chkJueves = new System.Windows.Forms.CheckBox();
            this.chkMiercoles = new System.Windows.Forms.CheckBox();
            this.chkMartes = new System.Windows.Forms.CheckBox();
            this.chkLunes = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.mktHoraFinalVespertino = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.mktHoraInicioVespertino = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkVespertino = new System.Windows.Forms.CheckBox();
            this.mktHoraFinalMatutino = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.mktHoraInicioMatutino = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkMatutino = new System.Windows.Forms.CheckBox();
            this.chkViajero = new System.Windows.Forms.CheckBox();
            this.txtDiasViajero = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.gbDatosExtras = new System.Windows.Forms.GroupBox();
            this.chkPrefijo = new System.Windows.Forms.CheckBox();
            this.txtClavePrefijo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.chkGrupal = new System.Windows.Forms.CheckBox();
            this.txtNumPersonasGrupal = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnNueva = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.gbInformacion.SuspendLayout();
            this.gbDiaSemana.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbDatosExtras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbInformacion
            // 
            this.gbInformacion.Controls.Add(this.rdbServicio);
            this.gbInformacion.Controls.Add(this.rdbMembresia);
            this.gbInformacion.Controls.Add(this.chkActiva);
            this.gbInformacion.Controls.Add(this.txtPeriodo);
            this.gbInformacion.Controls.Add(this.label4);
            this.gbInformacion.Controls.Add(this.txtCosto);
            this.gbInformacion.Controls.Add(this.label3);
            this.gbInformacion.Controls.Add(this.txtDescripcion);
            this.gbInformacion.Controls.Add(this.label1);
            this.gbInformacion.Enabled = false;
            this.gbInformacion.Location = new System.Drawing.Point(12, 12);
            this.gbInformacion.Name = "gbInformacion";
            this.gbInformacion.Size = new System.Drawing.Size(243, 216);
            this.gbInformacion.TabIndex = 0;
            this.gbInformacion.TabStop = false;
            this.gbInformacion.Text = "Información";
            // 
            // rdbServicio
            // 
            this.rdbServicio.AutoSize = true;
            this.rdbServicio.Location = new System.Drawing.Point(129, 94);
            this.rdbServicio.Name = "rdbServicio";
            this.rdbServicio.Size = new System.Drawing.Size(63, 17);
            this.rdbServicio.TabIndex = 28;
            this.rdbServicio.TabStop = true;
            this.rdbServicio.Text = "Servicio";
            this.rdbServicio.UseVisualStyleBackColor = true;
            // 
            // rdbMembresia
            // 
            this.rdbMembresia.AutoSize = true;
            this.rdbMembresia.Location = new System.Drawing.Point(47, 94);
            this.rdbMembresia.Name = "rdbMembresia";
            this.rdbMembresia.Size = new System.Drawing.Size(76, 17);
            this.rdbMembresia.TabIndex = 27;
            this.rdbMembresia.TabStop = true;
            this.rdbMembresia.Text = "Membresia";
            this.rdbMembresia.UseVisualStyleBackColor = true;
            this.rdbMembresia.CheckedChanged += new System.EventHandler(this.rdbMembresia_CheckedChanged);
            // 
            // chkActiva
            // 
            this.chkActiva.AutoSize = true;
            this.chkActiva.Location = new System.Drawing.Point(169, 182);
            this.chkActiva.Name = "chkActiva";
            this.chkActiva.Size = new System.Drawing.Size(56, 17);
            this.chkActiva.TabIndex = 26;
            this.chkActiva.Text = "Activa";
            this.chkActiva.UseVisualStyleBackColor = true;
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Location = new System.Drawing.Point(55, 178);
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Size = new System.Drawing.Size(55, 20);
            this.txtPeriodo.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Periodo";
            // 
            // txtCosto
            // 
            this.txtCosto.Location = new System.Drawing.Point(55, 142);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(180, 20);
            this.txtCosto.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Costo $";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(9, 43);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(228, 45);
            this.txtDescripcion.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descripción";
            // 
            // cmbTipo
            // 
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(619, 159);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(195, 21);
            this.cmbTipo.TabIndex = 3;
            this.cmbTipo.Visible = false;
            this.cmbTipo.SelectedIndexChanged += new System.EventHandler(this.cmbTipo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(585, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tipo";
            this.label2.Visible = false;
            // 
            // gbDiaSemana
            // 
            this.gbDiaSemana.Controls.Add(this.chkDomingo);
            this.gbDiaSemana.Controls.Add(this.chkSabado);
            this.gbDiaSemana.Controls.Add(this.chkViernes);
            this.gbDiaSemana.Controls.Add(this.chkJueves);
            this.gbDiaSemana.Controls.Add(this.chkMiercoles);
            this.gbDiaSemana.Controls.Add(this.chkMartes);
            this.gbDiaSemana.Controls.Add(this.chkLunes);
            this.gbDiaSemana.Enabled = false;
            this.gbDiaSemana.Location = new System.Drawing.Point(261, 12);
            this.gbDiaSemana.Name = "gbDiaSemana";
            this.gbDiaSemana.Size = new System.Drawing.Size(320, 88);
            this.gbDiaSemana.TabIndex = 1;
            this.gbDiaSemana.TabStop = false;
            this.gbDiaSemana.Text = "Dias de la semana";
            // 
            // chkDomingo
            // 
            this.chkDomingo.AutoSize = true;
            this.chkDomingo.Location = new System.Drawing.Point(168, 58);
            this.chkDomingo.Name = "chkDomingo";
            this.chkDomingo.Size = new System.Drawing.Size(68, 17);
            this.chkDomingo.TabIndex = 6;
            this.chkDomingo.Text = "Domingo";
            this.chkDomingo.UseVisualStyleBackColor = true;
            // 
            // chkSabado
            // 
            this.chkSabado.AutoSize = true;
            this.chkSabado.Location = new System.Drawing.Point(86, 58);
            this.chkSabado.Name = "chkSabado";
            this.chkSabado.Size = new System.Drawing.Size(63, 17);
            this.chkSabado.TabIndex = 5;
            this.chkSabado.Text = "Sabado";
            this.chkSabado.UseVisualStyleBackColor = true;
            // 
            // chkViernes
            // 
            this.chkViernes.AutoSize = true;
            this.chkViernes.Location = new System.Drawing.Point(6, 58);
            this.chkViernes.Name = "chkViernes";
            this.chkViernes.Size = new System.Drawing.Size(61, 17);
            this.chkViernes.TabIndex = 4;
            this.chkViernes.Text = "Viernes";
            this.chkViernes.UseVisualStyleBackColor = true;
            // 
            // chkJueves
            // 
            this.chkJueves.AutoSize = true;
            this.chkJueves.Location = new System.Drawing.Point(249, 23);
            this.chkJueves.Name = "chkJueves";
            this.chkJueves.Size = new System.Drawing.Size(60, 17);
            this.chkJueves.TabIndex = 3;
            this.chkJueves.Text = "Jueves";
            this.chkJueves.UseVisualStyleBackColor = true;
            // 
            // chkMiercoles
            // 
            this.chkMiercoles.AutoSize = true;
            this.chkMiercoles.Location = new System.Drawing.Point(167, 23);
            this.chkMiercoles.Name = "chkMiercoles";
            this.chkMiercoles.Size = new System.Drawing.Size(71, 17);
            this.chkMiercoles.TabIndex = 2;
            this.chkMiercoles.Text = "Miercoles";
            this.chkMiercoles.UseVisualStyleBackColor = true;
            // 
            // chkMartes
            // 
            this.chkMartes.AutoSize = true;
            this.chkMartes.Location = new System.Drawing.Point(87, 23);
            this.chkMartes.Name = "chkMartes";
            this.chkMartes.Size = new System.Drawing.Size(58, 17);
            this.chkMartes.TabIndex = 1;
            this.chkMartes.Text = "Martes";
            this.chkMartes.UseVisualStyleBackColor = true;
            // 
            // chkLunes
            // 
            this.chkLunes.AutoSize = true;
            this.chkLunes.Location = new System.Drawing.Point(6, 23);
            this.chkLunes.Name = "chkLunes";
            this.chkLunes.Size = new System.Drawing.Size(55, 17);
            this.chkLunes.TabIndex = 0;
            this.chkLunes.Text = "Lunes";
            this.chkLunes.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.mktHoraFinalVespertino);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.mktHoraInicioVespertino);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.chkVespertino);
            this.groupBox3.Controls.Add(this.mktHoraFinalMatutino);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.mktHoraInicioMatutino);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.chkMatutino);
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(587, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(180, 113);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Horarios";
            // 
            // mktHoraFinalVespertino
            // 
            this.mktHoraFinalVespertino.Location = new System.Drawing.Point(261, 89);
            this.mktHoraFinalVespertino.Mask = "00:00";
            this.mktHoraFinalVespertino.Name = "mktHoraFinalVespertino";
            this.mktHoraFinalVespertino.Size = new System.Drawing.Size(48, 20);
            this.mktHoraFinalVespertino.TabIndex = 16;
            this.mktHoraFinalVespertino.ValidatingType = typeof(System.DateTime);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(198, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Hora final";
            // 
            // mktHoraInicioVespertino
            // 
            this.mktHoraInicioVespertino.Location = new System.Drawing.Point(261, 46);
            this.mktHoraInicioVespertino.Mask = "00:00";
            this.mktHoraInicioVespertino.Name = "mktHoraInicioVespertino";
            this.mktHoraInicioVespertino.Size = new System.Drawing.Size(48, 20);
            this.mktHoraInicioVespertino.TabIndex = 14;
            this.mktHoraInicioVespertino.ValidatingType = typeof(System.DateTime);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(198, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Hora inicio";
            // 
            // chkVespertino
            // 
            this.chkVespertino.AutoSize = true;
            this.chkVespertino.Location = new System.Drawing.Point(201, 19);
            this.chkVespertino.Name = "chkVespertino";
            this.chkVespertino.Size = new System.Drawing.Size(76, 17);
            this.chkVespertino.TabIndex = 12;
            this.chkVespertino.Text = "Vespertino";
            this.chkVespertino.UseVisualStyleBackColor = true;
            // 
            // mktHoraFinalMatutino
            // 
            this.mktHoraFinalMatutino.Location = new System.Drawing.Point(78, 85);
            this.mktHoraFinalMatutino.Mask = "00:00";
            this.mktHoraFinalMatutino.Name = "mktHoraFinalMatutino";
            this.mktHoraFinalMatutino.Size = new System.Drawing.Size(48, 20);
            this.mktHoraFinalMatutino.TabIndex = 11;
            this.mktHoraFinalMatutino.ValidatingType = typeof(System.DateTime);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Hora final";
            // 
            // mktHoraInicioMatutino
            // 
            this.mktHoraInicioMatutino.Location = new System.Drawing.Point(78, 46);
            this.mktHoraInicioMatutino.Mask = "00:00";
            this.mktHoraInicioMatutino.Name = "mktHoraInicioMatutino";
            this.mktHoraInicioMatutino.Size = new System.Drawing.Size(48, 20);
            this.mktHoraInicioMatutino.TabIndex = 9;
            this.mktHoraInicioMatutino.ValidatingType = typeof(System.DateTime);
            this.mktHoraInicioMatutino.Click += new System.EventHandler(this.mktHoraInicioMatutino_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Hora inicio";
            // 
            // chkMatutino
            // 
            this.chkMatutino.AutoSize = true;
            this.chkMatutino.Location = new System.Drawing.Point(18, 19);
            this.chkMatutino.Name = "chkMatutino";
            this.chkMatutino.Size = new System.Drawing.Size(60, 17);
            this.chkMatutino.TabIndex = 7;
            this.chkMatutino.Text = "Horario";
            this.chkMatutino.UseVisualStyleBackColor = true;
            this.chkMatutino.CheckedChanged += new System.EventHandler(this.chkMatutino_CheckedChanged);
            // 
            // chkViajero
            // 
            this.chkViajero.AutoSize = true;
            this.chkViajero.Location = new System.Drawing.Point(192, 22);
            this.chkViajero.Name = "chkViajero";
            this.chkViajero.Size = new System.Drawing.Size(58, 17);
            this.chkViajero.TabIndex = 17;
            this.chkViajero.Text = "Viajero";
            this.chkViajero.UseVisualStyleBackColor = true;
            // 
            // txtDiasViajero
            // 
            this.txtDiasViajero.Location = new System.Drawing.Point(252, 46);
            this.txtDiasViajero.Name = "txtDiasViajero";
            this.txtDiasViajero.Size = new System.Drawing.Size(55, 20);
            this.txtDiasViajero.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(189, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "No. clases";
            // 
            // gbDatosExtras
            // 
            this.gbDatosExtras.Controls.Add(this.chkViajero);
            this.gbDatosExtras.Controls.Add(this.txtDiasViajero);
            this.gbDatosExtras.Controls.Add(this.chkPrefijo);
            this.gbDatosExtras.Controls.Add(this.label9);
            this.gbDatosExtras.Controls.Add(this.txtClavePrefijo);
            this.gbDatosExtras.Controls.Add(this.label11);
            this.gbDatosExtras.Controls.Add(this.chkGrupal);
            this.gbDatosExtras.Controls.Add(this.txtNumPersonasGrupal);
            this.gbDatosExtras.Controls.Add(this.label10);
            this.gbDatosExtras.Enabled = false;
            this.gbDatosExtras.Location = new System.Drawing.Point(261, 110);
            this.gbDatosExtras.Name = "gbDatosExtras";
            this.gbDatosExtras.Size = new System.Drawing.Size(320, 118);
            this.gbDatosExtras.TabIndex = 21;
            this.gbDatosExtras.TabStop = false;
            this.gbDatosExtras.Text = "Datos extras";
            // 
            // chkPrefijo
            // 
            this.chkPrefijo.AutoSize = true;
            this.chkPrefijo.Location = new System.Drawing.Point(22, 76);
            this.chkPrefijo.Name = "chkPrefijo";
            this.chkPrefijo.Size = new System.Drawing.Size(55, 17);
            this.chkPrefijo.TabIndex = 23;
            this.chkPrefijo.Text = "Prefijo";
            this.chkPrefijo.UseVisualStyleBackColor = true;
            // 
            // txtClavePrefijo
            // 
            this.txtClavePrefijo.Location = new System.Drawing.Point(168, 73);
            this.txtClavePrefijo.Name = "txtClavePrefijo";
            this.txtClavePrefijo.Size = new System.Drawing.Size(55, 20);
            this.txtClavePrefijo.TabIndex = 25;
            this.txtClavePrefijo.Text = "*";
            this.txtClavePrefijo.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(87, 76);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "clave prefijo";
            this.label11.Visible = false;
            // 
            // chkGrupal
            // 
            this.chkGrupal.AutoSize = true;
            this.chkGrupal.Location = new System.Drawing.Point(22, 22);
            this.chkGrupal.Name = "chkGrupal";
            this.chkGrupal.Size = new System.Drawing.Size(57, 17);
            this.chkGrupal.TabIndex = 20;
            this.chkGrupal.Text = "Grupal";
            this.chkGrupal.UseVisualStyleBackColor = true;
            // 
            // txtNumPersonasGrupal
            // 
            this.txtNumPersonasGrupal.Location = new System.Drawing.Point(100, 46);
            this.txtNumPersonasGrupal.Name = "txtNumPersonasGrupal";
            this.txtNumPersonasGrupal.Size = new System.Drawing.Size(55, 20);
            this.txtNumPersonasGrupal.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Num personas";
            // 
            // btnNueva
            // 
            this.btnNueva.Location = new System.Drawing.Point(582, 213);
            this.btnNueva.Name = "btnNueva";
            this.btnNueva.Size = new System.Drawing.Size(57, 23);
            this.btnNueva.TabIndex = 22;
            this.btnNueva.Text = "Nueva";
            this.btnNueva.UseVisualStyleBackColor = true;
            this.btnNueva.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(645, 213);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(59, 23);
            this.btnModificar.TabIndex = 23;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 242);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(755, 185);
            this.dataGridView1.TabIndex = 24;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(709, 213);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(59, 23);
            this.button1.TabIndex = 25;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // FrmCatMemebresias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 439);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnNueva);
            this.Controls.Add(this.gbDatosExtras);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gbDiaSemana);
            this.Controls.Add(this.gbInformacion);
            this.Name = "FrmCatMemebresias";
            this.Text = "FrmCatMemebresias";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmCatMemebresias_Load);
            this.gbInformacion.ResumeLayout(false);
            this.gbInformacion.PerformLayout();
            this.gbDiaSemana.ResumeLayout(false);
            this.gbDiaSemana.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbDatosExtras.ResumeLayout(false);
            this.gbDatosExtras.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbInformacion;
        private System.Windows.Forms.TextBox txtPeriodo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbDiaSemana;
        private System.Windows.Forms.CheckBox chkDomingo;
        private System.Windows.Forms.CheckBox chkSabado;
        private System.Windows.Forms.CheckBox chkViernes;
        private System.Windows.Forms.CheckBox chkJueves;
        private System.Windows.Forms.CheckBox chkMiercoles;
        private System.Windows.Forms.CheckBox chkMartes;
        private System.Windows.Forms.CheckBox chkLunes;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.MaskedTextBox mktHoraFinalVespertino;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox mktHoraInicioVespertino;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkVespertino;
        private System.Windows.Forms.MaskedTextBox mktHoraFinalMatutino;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox mktHoraInicioMatutino;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkMatutino;
        private System.Windows.Forms.CheckBox chkViajero;
        private System.Windows.Forms.TextBox txtDiasViajero;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox gbDatosExtras;
        private System.Windows.Forms.CheckBox chkPrefijo;
        private System.Windows.Forms.TextBox txtClavePrefijo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chkGrupal;
        private System.Windows.Forms.TextBox txtNumPersonasGrupal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnNueva;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.CheckBox chkActiva;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RadioButton rdbServicio;
        private System.Windows.Forms.RadioButton rdbMembresia;
        private System.Windows.Forms.Button button1;
    }
}