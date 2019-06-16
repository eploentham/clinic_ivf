namespace clinic_ivf.gui
{
    partial class FrmShowPdf
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
            this.c1FlexViewer1 = new C1.Win.FlexViewer.C1FlexViewer();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexViewer1)).BeginInit();
            this.SuspendLayout();
            // 
            // c1FlexViewer1
            // 
            this.c1FlexViewer1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.c1FlexViewer1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.c1FlexViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1FlexViewer1.Location = new System.Drawing.Point(0, 0);
            this.c1FlexViewer1.Name = "c1FlexViewer1";
            this.c1FlexViewer1.Size = new System.Drawing.Size(1065, 790);
            this.c1FlexViewer1.TabIndex = 0;
            // 
            // FrmShowPdf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 790);
            this.Controls.Add(this.c1FlexViewer1);
            this.Name = "FrmShowPdf";
            this.Text = "FrmShowPdf";
            this.Load += new System.EventHandler(this.FrmShowPdf_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexViewer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.FlexViewer.C1FlexViewer c1FlexViewer1;
    }
}