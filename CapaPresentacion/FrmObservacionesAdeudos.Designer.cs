namespace CapaPresentacion
{
    partial class FrmObservacionesAdeudos
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtAgregarComentario = new System.Windows.Forms.TextBox();
            this.btnAgregarComentario = new System.Windows.Forms.Button();
            this.txtVerComentario = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(22, 171);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(745, 176);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // txtAgregarComentario
            // 
            this.txtAgregarComentario.Location = new System.Drawing.Point(4, 17);
            this.txtAgregarComentario.Margin = new System.Windows.Forms.Padding(2);
            this.txtAgregarComentario.Multiline = true;
            this.txtAgregarComentario.Name = "txtAgregarComentario";
            this.txtAgregarComentario.Size = new System.Drawing.Size(362, 87);
            this.txtAgregarComentario.TabIndex = 1;
            this.txtAgregarComentario.TextChanged += new System.EventHandler(this.validarCampos);
            // 
            // btnAgregarComentario
            // 
            this.btnAgregarComentario.Enabled = false;
            this.btnAgregarComentario.Image = global::CapaPresentacion.Properties.Resources.add1;
            this.btnAgregarComentario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarComentario.Location = new System.Drawing.Point(84, 108);
            this.btnAgregarComentario.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregarComentario.Name = "btnAgregarComentario";
            this.btnAgregarComentario.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnAgregarComentario.Size = new System.Drawing.Size(185, 32);
            this.btnAgregarComentario.TabIndex = 2;
            this.btnAgregarComentario.Text = "Agregar Comentario";
            this.btnAgregarComentario.UseVisualStyleBackColor = true;
            this.btnAgregarComentario.Click += new System.EventHandler(this.btnAgregarComentario_Click);
            // 
            // txtVerComentario
            // 
            this.txtVerComentario.Location = new System.Drawing.Point(386, 17);
            this.txtVerComentario.Margin = new System.Windows.Forms.Padding(2);
            this.txtVerComentario.Multiline = true;
            this.txtVerComentario.Name = "txtVerComentario";
            this.txtVerComentario.Size = new System.Drawing.Size(355, 87);
            this.txtVerComentario.TabIndex = 3;
            this.txtVerComentario.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAgregarComentario);
            this.groupBox1.Controls.Add(this.btnAgregarComentario);
            this.groupBox1.Controls.Add(this.txtVerComentario);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(22, 17);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(745, 150);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Comentarios";
            // 
            // FrmObservacionesAdeudos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 358);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FrmObservacionesAdeudos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Observaciones de adeudos";
            this.Load += new System.EventHandler(this.FrmObservacionesAdeudos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtAgregarComentario;
        private System.Windows.Forms.Button btnAgregarComentario;
        private System.Windows.Forms.TextBox txtVerComentario;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}