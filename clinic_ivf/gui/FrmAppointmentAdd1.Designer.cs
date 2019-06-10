namespace clinic_ivf.gui
{
    partial class FrmAppointmentAdd1
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
            this.sB = new System.Windows.Forms.StatusStrip();
            this.sB1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.theme1 = new C1.Win.C1Themes.C1ThemeController();
            this.c1SplitContainer1 = new C1.Win.C1SplitContainer.C1SplitContainer();
            this.c1SplitterPanel1 = new C1.Win.C1SplitContainer.C1SplitterPanel();
            this.c1SplitterPanel2 = new C1.Win.C1SplitContainer.C1SplitterPanel();
            this.sB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1SplitContainer1)).BeginInit();
            this.c1SplitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sB
            // 
            this.sB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.sB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sB1});
            this.sB.Location = new System.Drawing.Point(0, 632);
            this.sB.Name = "sB";
            this.sB.Size = new System.Drawing.Size(1056, 22);
            this.sB.TabIndex = 529;
            this.sB.Text = "statusStrip1";
            this.theme1.SetTheme(this.sB, "Office2013DarkGray");
            // 
            // sB1
            // 
            this.sB1.Name = "sB1";
            this.sB1.Size = new System.Drawing.Size(118, 17);
            this.sB1.Text = "toolStripStatusLabel1";
            // 
            // theme1
            // 
            this.theme1.Theme = "Office2013Red";
            // 
            // c1SplitContainer1
            // 
            this.c1SplitContainer1.AutoSizeElement = C1.Framework.AutoSizeElement.Both;
            this.c1SplitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.c1SplitContainer1.CollapsingCueColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(133)))), ((int)(((byte)(150)))));
            this.c1SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1SplitContainer1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.c1SplitContainer1.HeaderLineWidth = 1;
            this.c1SplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.c1SplitContainer1.Name = "c1SplitContainer1";
            this.c1SplitContainer1.Panels.Add(this.c1SplitterPanel1);
            this.c1SplitContainer1.Panels.Add(this.c1SplitterPanel2);
            this.c1SplitContainer1.Size = new System.Drawing.Size(1056, 632);
            this.c1SplitContainer1.SplitterMovingColor = System.Drawing.Color.Black;
            this.c1SplitContainer1.TabIndex = 530;
            this.theme1.SetTheme(this.c1SplitContainer1, "(default)");
            // 
            // c1SplitterPanel1
            // 
            this.c1SplitterPanel1.Collapsible = true;
            this.c1SplitterPanel1.Dock = C1.Win.C1SplitContainer.PanelDockStyle.Left;
            this.c1SplitterPanel1.Location = new System.Drawing.Point(0, 21);
            this.c1SplitterPanel1.Name = "c1SplitterPanel1";
            this.c1SplitterPanel1.Size = new System.Drawing.Size(241, 611);
            this.c1SplitterPanel1.SizeRatio = 23.574D;
            this.c1SplitterPanel1.TabIndex = 0;
            this.c1SplitterPanel1.Text = "Panel 1";
            this.c1SplitterPanel1.Width = 248;
            // 
            // c1SplitterPanel2
            // 
            this.c1SplitterPanel2.Height = 632;
            this.c1SplitterPanel2.Location = new System.Drawing.Point(252, 21);
            this.c1SplitterPanel2.Name = "c1SplitterPanel2";
            this.c1SplitterPanel2.Size = new System.Drawing.Size(804, 611);
            this.c1SplitterPanel2.TabIndex = 1;
            this.c1SplitterPanel2.Text = "Panel 2";
            // 
            // FrmAppointmentAdd1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 654);
            this.Controls.Add(this.c1SplitContainer1);
            this.Controls.Add(this.sB);
            this.Name = "FrmAppointmentAdd1";
            this.Text = "FrmAppointmentAdd1";
            this.sB.ResumeLayout(false);
            this.sB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1SplitContainer1)).EndInit();
            this.c1SplitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip sB;
        private System.Windows.Forms.ToolStripStatusLabel sB1;
        private C1.Win.C1Themes.C1ThemeController theme1;
        private C1.Win.C1SplitContainer.C1SplitContainer c1SplitContainer1;
        private C1.Win.C1SplitContainer.C1SplitterPanel c1SplitterPanel1;
        private C1.Win.C1SplitContainer.C1SplitterPanel c1SplitterPanel2;
    }
}