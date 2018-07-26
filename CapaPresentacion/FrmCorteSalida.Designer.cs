namespace CapaPresentacion
{
    partial class FrmCorteSalida
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
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDineroEfectivo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDineroSalida = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvEfectivo = new System.Windows.Forms.DataGridView();
            this.dgvTarjetas = new System.Windows.Forms.DataGridView();
            this.dgvMovimientos = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDineroTarjeta = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEfectivo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTarjetas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.button1.Image = global::CapaPresentacion.Properties.Resources.Continuar;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(594, 96);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 35);
            this.button1.TabIndex = 8;
            this.button1.Text = "Continuar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(90, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 40);
            this.label2.TabIndex = 7;
            this.label2.Text = "$";
            // 
            // txtDineroEfectivo
            // 
            this.txtDineroEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDineroEfectivo.Location = new System.Drawing.Point(130, 37);
            this.txtDineroEfectivo.Multiline = true;
            this.txtDineroEfectivo.Name = "txtDineroEfectivo";
            this.txtDineroEfectivo.ReadOnly = true;
            this.txtDineroEfectivo.Size = new System.Drawing.Size(229, 43);
            this.txtDineroEfectivo.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(176, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "EFECTIVO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(433, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 40);
            this.label3.TabIndex = 11;
            this.label3.Text = "$";
            // 
            // txtDineroSalida
            // 
            this.txtDineroSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDineroSalida.Location = new System.Drawing.Point(473, 37);
            this.txtDineroSalida.Multiline = true;
            this.txtDineroSalida.Name = "txtDineroSalida";
            this.txtDineroSalida.Size = new System.Drawing.Size(223, 43);
            this.txtDineroSalida.TabIndex = 10;
            this.txtDineroSalida.Text = "0.00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(533, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "DINERO CORTE";
            // 
            // dgvEfectivo
            // 
            this.dgvEfectivo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEfectivo.Location = new System.Drawing.Point(7, 161);
            this.dgvEfectivo.Name = "dgvEfectivo";
            this.dgvEfectivo.Size = new System.Drawing.Size(251, 314);
            this.dgvEfectivo.TabIndex = 15;
            // 
            // dgvTarjetas
            // 
            this.dgvTarjetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTarjetas.Location = new System.Drawing.Point(268, 161);
            this.dgvTarjetas.Name = "dgvTarjetas";
            this.dgvTarjetas.Size = new System.Drawing.Size(251, 314);
            this.dgvTarjetas.TabIndex = 16;
            // 
            // dgvMovimientos
            // 
            this.dgvMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovimientos.Location = new System.Drawing.Point(531, 161);
            this.dgvMovimientos.Name = "dgvMovimientos";
            this.dgvMovimientos.Size = new System.Drawing.Size(251, 314);
            this.dgvMovimientos.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(73, 141);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 17);
            this.label7.TabIndex = 18;
            this.label7.Text = "VENTAS EFECTIVO";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(341, 141);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 17);
            this.label8.TabIndex = 19;
            this.label8.Text = "VENTAS TARJETA";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(613, 141);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 17);
            this.label9.TabIndex = 20;
            this.label9.Text = "MOVIMIENTOS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(309, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 40);
            this.label5.TabIndex = 14;
            this.label5.Text = "$";
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(365, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 25);
            this.label6.TabIndex = 12;
            this.label6.Text = "TARJETA";
            this.label6.Visible = false;
            // 
            // txtDineroTarjeta
            // 
            this.txtDineroTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDineroTarjeta.Location = new System.Drawing.Point(318, 37);
            this.txtDineroTarjeta.Multiline = true;
            this.txtDineroTarjeta.Name = "txtDineroTarjeta";
            this.txtDineroTarjeta.ReadOnly = true;
            this.txtDineroTarjeta.Size = new System.Drawing.Size(179, 43);
            this.txtDineroTarjeta.TabIndex = 13;
            this.txtDineroTarjeta.Visible = false;
            // 
            // FrmCorteSalida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 487);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgvMovimientos);
            this.Controls.Add(this.dgvTarjetas);
            this.Controls.Add(this.dgvEfectivo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDineroSalida);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDineroEfectivo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDineroTarjeta);
            this.Name = "FrmCorteSalida";
            this.Text = "FrmCorteSalida";
            this.Load += new System.EventHandler(this.FrmCorteSalida_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEfectivo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTarjetas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDineroEfectivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDineroSalida;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvEfectivo;
        private System.Windows.Forms.DataGridView dgvTarjetas;
        private System.Windows.Forms.DataGridView dgvMovimientos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDineroTarjeta;
    }
}