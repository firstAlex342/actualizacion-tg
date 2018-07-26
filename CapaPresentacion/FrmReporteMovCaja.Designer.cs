namespace CapaPresentacion
{
    partial class FrmReporteMovCaja
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
            this.crvMovCaja = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvMovCaja
            // 
            this.crvMovCaja.ActiveViewIndex = -1;
            this.crvMovCaja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvMovCaja.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvMovCaja.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvMovCaja.Location = new System.Drawing.Point(0, 0);
            this.crvMovCaja.Name = "crvMovCaja";
            this.crvMovCaja.Size = new System.Drawing.Size(1178, 894);
            this.crvMovCaja.TabIndex = 0;
            // 
            // FrmReporteMovCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 894);
            this.Controls.Add(this.crvMovCaja);
            this.Name = "FrmReporteMovCaja";
            this.Text = "FrmReporteMovCaja";
            this.Load += new System.EventHandler(this.FrmReporteMovCaja_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvMovCaja;
    }

}