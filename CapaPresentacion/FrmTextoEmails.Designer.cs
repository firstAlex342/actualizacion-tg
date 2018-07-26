namespace CapaPresentacion
{
    partial class FrmTextoEmails
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
            this.gbDeudores = new System.Windows.Forms.GroupBox();
            this.btnGuardarAdeudos = new System.Windows.Forms.Button();
            this.btnModificarAdeudos = new System.Windows.Forms.Button();
            this.txtCuerpoAdeudos = new System.Windows.Forms.TextBox();
            this.txtAsuntoAdeudos = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbCumpleañeros = new System.Windows.Forms.GroupBox();
            this.btnModificarCumpleañeros = new System.Windows.Forms.Button();
            this.btnGuardarCumpleañeos = new System.Windows.Forms.Button();
            this.txtCuerpoCumpleañeros = new System.Windows.Forms.TextBox();
            this.txtAsuntoCumpleañeros = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gbDeudores.SuspendLayout();
            this.gbCumpleañeros.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDeudores
            // 
            this.gbDeudores.Controls.Add(this.btnGuardarAdeudos);
            this.gbDeudores.Controls.Add(this.btnModificarAdeudos);
            this.gbDeudores.Controls.Add(this.txtCuerpoAdeudos);
            this.gbDeudores.Controls.Add(this.txtAsuntoAdeudos);
            this.gbDeudores.Controls.Add(this.label2);
            this.gbDeudores.Controls.Add(this.label1);
            this.gbDeudores.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDeudores.Location = new System.Drawing.Point(13, 13);
            this.gbDeudores.Name = "gbDeudores";
            this.gbDeudores.Size = new System.Drawing.Size(1169, 410);
            this.gbDeudores.TabIndex = 0;
            this.gbDeudores.TabStop = false;
            this.gbDeudores.Text = "Deudores";
            // 
            // btnGuardarAdeudos
            // 
            this.btnGuardarAdeudos.Enabled = false;
            this.btnGuardarAdeudos.Image = global::CapaPresentacion.Properties.Resources.add1;
            this.btnGuardarAdeudos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarAdeudos.Location = new System.Drawing.Point(960, 354);
            this.btnGuardarAdeudos.Name = "btnGuardarAdeudos";
            this.btnGuardarAdeudos.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnGuardarAdeudos.Size = new System.Drawing.Size(189, 50);
            this.btnGuardarAdeudos.TabIndex = 5;
            this.btnGuardarAdeudos.Text = "Guardar";
            this.btnGuardarAdeudos.UseVisualStyleBackColor = true;
            this.btnGuardarAdeudos.Click += new System.EventHandler(this.btnGuardarAdeudos_Click);
            // 
            // btnModificarAdeudos
            // 
            this.btnModificarAdeudos.Image = global::CapaPresentacion.Properties.Resources.pencil;
            this.btnModificarAdeudos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificarAdeudos.Location = new System.Drawing.Point(738, 354);
            this.btnModificarAdeudos.Name = "btnModificarAdeudos";
            this.btnModificarAdeudos.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnModificarAdeudos.Size = new System.Drawing.Size(181, 50);
            this.btnModificarAdeudos.TabIndex = 4;
            this.btnModificarAdeudos.Text = "Modificar";
            this.btnModificarAdeudos.UseVisualStyleBackColor = true;
            this.btnModificarAdeudos.Click += new System.EventHandler(this.btnModificarAdeudos_Click);
            // 
            // txtCuerpoAdeudos
            // 
            this.txtCuerpoAdeudos.Enabled = false;
            this.txtCuerpoAdeudos.Location = new System.Drawing.Point(23, 176);
            this.txtCuerpoAdeudos.Multiline = true;
            this.txtCuerpoAdeudos.Name = "txtCuerpoAdeudos";
            this.txtCuerpoAdeudos.Size = new System.Drawing.Size(1126, 150);
            this.txtCuerpoAdeudos.TabIndex = 3;
            // 
            // txtAsuntoAdeudos
            // 
            this.txtAsuntoAdeudos.Enabled = false;
            this.txtAsuntoAdeudos.Location = new System.Drawing.Point(23, 82);
            this.txtAsuntoAdeudos.Name = "txtAsuntoAdeudos";
            this.txtAsuntoAdeudos.Size = new System.Drawing.Size(1126, 26);
            this.txtAsuntoAdeudos.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cuerpo del correo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Asunto correo adeudos:";
            // 
            // gbCumpleañeros
            // 
            this.gbCumpleañeros.Controls.Add(this.btnModificarCumpleañeros);
            this.gbCumpleañeros.Controls.Add(this.btnGuardarCumpleañeos);
            this.gbCumpleañeros.Controls.Add(this.txtCuerpoCumpleañeros);
            this.gbCumpleañeros.Controls.Add(this.txtAsuntoCumpleañeros);
            this.gbCumpleañeros.Controls.Add(this.label4);
            this.gbCumpleañeros.Controls.Add(this.label3);
            this.gbCumpleañeros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCumpleañeros.Location = new System.Drawing.Point(13, 439);
            this.gbCumpleañeros.Name = "gbCumpleañeros";
            this.gbCumpleañeros.Size = new System.Drawing.Size(1169, 410);
            this.gbCumpleañeros.TabIndex = 1;
            this.gbCumpleañeros.TabStop = false;
            this.gbCumpleañeros.Text = "Cumpleañeros";
            // 
            // btnModificarCumpleañeros
            // 
            this.btnModificarCumpleañeros.Image = global::CapaPresentacion.Properties.Resources.pencil;
            this.btnModificarCumpleañeros.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificarCumpleañeros.Location = new System.Drawing.Point(738, 354);
            this.btnModificarCumpleañeros.Name = "btnModificarCumpleañeros";
            this.btnModificarCumpleañeros.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnModificarCumpleañeros.Size = new System.Drawing.Size(181, 50);
            this.btnModificarCumpleañeros.TabIndex = 5;
            this.btnModificarCumpleañeros.Text = "Modificar";
            this.btnModificarCumpleañeros.UseVisualStyleBackColor = true;
            this.btnModificarCumpleañeros.Click += new System.EventHandler(this.btnModificarCumpleañeros_Click);
            // 
            // btnGuardarCumpleañeos
            // 
            this.btnGuardarCumpleañeos.Enabled = false;
            this.btnGuardarCumpleañeos.Image = global::CapaPresentacion.Properties.Resources.add1;
            this.btnGuardarCumpleañeos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarCumpleañeos.Location = new System.Drawing.Point(960, 354);
            this.btnGuardarCumpleañeos.Name = "btnGuardarCumpleañeos";
            this.btnGuardarCumpleañeos.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnGuardarCumpleañeos.Size = new System.Drawing.Size(188, 50);
            this.btnGuardarCumpleañeos.TabIndex = 4;
            this.btnGuardarCumpleañeos.Text = "Guardar";
            this.btnGuardarCumpleañeos.UseVisualStyleBackColor = true;
            this.btnGuardarCumpleañeos.Click += new System.EventHandler(this.btnGuardarCumpleañeos_Click);
            // 
            // txtCuerpoCumpleañeros
            // 
            this.txtCuerpoCumpleañeros.Enabled = false;
            this.txtCuerpoCumpleañeros.Location = new System.Drawing.Point(22, 176);
            this.txtCuerpoCumpleañeros.Multiline = true;
            this.txtCuerpoCumpleañeros.Name = "txtCuerpoCumpleañeros";
            this.txtCuerpoCumpleañeros.Size = new System.Drawing.Size(1126, 150);
            this.txtCuerpoCumpleañeros.TabIndex = 3;
            // 
            // txtAsuntoCumpleañeros
            // 
            this.txtAsuntoCumpleañeros.Enabled = false;
            this.txtAsuntoCumpleañeros.Location = new System.Drawing.Point(22, 81);
            this.txtAsuntoCumpleañeros.Name = "txtAsuntoCumpleañeros";
            this.txtAsuntoCumpleañeros.Size = new System.Drawing.Size(1126, 26);
            this.txtAsuntoCumpleañeros.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Cuerpo del correo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(244, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Asunto correo cumpleañeros:";
            // 
            // FrmTextoEmails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 861);
            this.Controls.Add(this.gbCumpleañeros);
            this.Controls.Add(this.gbDeudores);
            this.Name = "FrmTextoEmails";
            this.Text = "Textos de Correos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmTextoEmails_Load);
            this.gbDeudores.ResumeLayout(false);
            this.gbDeudores.PerformLayout();
            this.gbCumpleañeros.ResumeLayout(false);
            this.gbCumpleañeros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDeudores;
        private System.Windows.Forms.Button btnGuardarAdeudos;
        private System.Windows.Forms.Button btnModificarAdeudos;
        private System.Windows.Forms.TextBox txtCuerpoAdeudos;
        private System.Windows.Forms.TextBox txtAsuntoAdeudos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbCumpleañeros;
        private System.Windows.Forms.Button btnModificarCumpleañeros;
        private System.Windows.Forms.Button btnGuardarCumpleañeos;
        private System.Windows.Forms.TextBox txtCuerpoCumpleañeros;
        private System.Windows.Forms.TextBox txtAsuntoCumpleañeros;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}