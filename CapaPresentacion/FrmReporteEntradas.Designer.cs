namespace CapaPresentacion
{
    partial class FrmReporteEntradas
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
            this.CRVreporteEntradas = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CREntradas1 = new CapaPresentacion.CREntradas();
            this.SuspendLayout();
            // 
            // CRVreporteEntradas
            // 
            this.CRVreporteEntradas.ActiveViewIndex = 0;
            this.CRVreporteEntradas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRVreporteEntradas.Cursor = System.Windows.Forms.Cursors.Default;
            this.CRVreporteEntradas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRVreporteEntradas.Location = new System.Drawing.Point(0, 0);
            this.CRVreporteEntradas.Name = "CRVreporteEntradas";
            this.CRVreporteEntradas.ReportSource = this.CREntradas1;
            this.CRVreporteEntradas.Size = new System.Drawing.Size(1370, 677);
            this.CRVreporteEntradas.TabIndex = 0;
            this.CRVreporteEntradas.Load += new System.EventHandler(this.CRVreporteEntradas_Load);
            // 
            // FrmReporteEntradas
            // 
            this.ClientSize = new System.Drawing.Size(1370, 677);
            this.Controls.Add(this.CRVreporteEntradas);
            this.Name = "FrmReporteEntradas";
            this.Load += new System.EventHandler(this.FrmReporteEntradas_Load_1);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRVreporteEntradas;
        private CREntradas CREntradas1;
    }
}