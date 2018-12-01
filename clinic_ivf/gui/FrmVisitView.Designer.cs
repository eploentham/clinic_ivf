namespace clinic_ivf.gui
{
    partial class FrmVisitView
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
            this.theme1 = new C1.Win.C1Themes.C1ThemeController();
            this.gB = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkVisit = new System.Windows.Forms.RadioButton();
            this.chkHn = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSearch = new C1.Win.C1Input.C1TextBox();
            this.btnNew = new C1.Win.C1Input.C1Button();
            this.sB = new System.Windows.Forms.StatusStrip();
            this.sB1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.chkToday = new C1.Win.C1Input.C1CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNew)).BeginInit();
            this.sB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkToday)).BeginInit();
            this.SuspendLayout();
            // 
            // theme1
            // 
            this.theme1.Theme = "Office2013Red";
            // 
            // gB
            // 
            this.gB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.gB.Location = new System.Drawing.Point(0, 54);
            this.gB.Name = "gB";
            this.gB.Size = new System.Drawing.Size(1126, 658);
            this.gB.TabIndex = 529;
            this.gB.TabStop = false;
            this.gB.Text = "ค้นหา";
            this.theme1.SetTheme(this.gB, "(default)");
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.groupBox1.Controls.Add(this.chkToday);
            this.groupBox1.Controls.Add(this.chkVisit);
            this.groupBox1.Controls.Add(this.chkHn);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.btnNew);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1126, 54);
            this.groupBox1.TabIndex = 528;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            this.theme1.SetTheme(this.groupBox1, "(default)");
            // 
            // chkVisit
            // 
            this.chkVisit.AutoSize = true;
            this.chkVisit.BackColor = System.Drawing.Color.Transparent;
            this.chkVisit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.chkVisit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(189)))), ((int)(((byte)(182)))));
            this.chkVisit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(189)))), ((int)(((byte)(182)))));
            this.chkVisit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.chkVisit.Location = new System.Drawing.Point(463, 22);
            this.chkVisit.Name = "chkVisit";
            this.chkVisit.Size = new System.Drawing.Size(62, 17);
            this.chkVisit.TabIndex = 533;
            this.chkVisit.TabStop = true;
            this.chkVisit.Text = "ค้น Visit";
            this.theme1.SetTheme(this.chkVisit, "(default)");
            this.chkVisit.UseVisualStyleBackColor = false;
            // 
            // chkHn
            // 
            this.chkHn.AutoSize = true;
            this.chkHn.BackColor = System.Drawing.Color.Transparent;
            this.chkHn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.chkHn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(189)))), ((int)(((byte)(182)))));
            this.chkHn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(189)))), ((int)(((byte)(182)))));
            this.chkHn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.chkHn.Location = new System.Drawing.Point(351, 21);
            this.chkHn.Name = "chkHn";
            this.chkHn.Size = new System.Drawing.Size(59, 17);
            this.chkHn.TabIndex = 530;
            this.chkHn.TabStop = true;
            this.chkHn.Text = "ค้น HN";
            this.theme1.SetTheme(this.chkHn, "(default)");
            this.chkHn.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label4.Location = new System.Drawing.Point(12, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 16);
            this.label4.TabIndex = 532;
            this.label4.Text = "key :";
            this.theme1.SetTheme(this.label4, "(default)");
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtSearch.Location = new System.Drawing.Point(82, 19);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(246, 20);
            this.txtSearch.TabIndex = 531;
            this.txtSearch.Tag = null;
            this.theme1.SetTheme(this.txtSearch, "(default)");
            this.txtSearch.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(960, 13);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(86, 31);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "ป้อนใหม่";
            this.theme1.SetTheme(this.btnNew, "(default)");
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // sB
            // 
            this.sB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sB1});
            this.sB.Location = new System.Drawing.Point(0, 712);
            this.sB.Name = "sB";
            this.sB.Size = new System.Drawing.Size(1126, 22);
            this.sB.TabIndex = 526;
            this.sB.Text = "statusStrip1";
            // 
            // sB1
            // 
            this.sB1.Name = "sB1";
            this.sB1.Size = new System.Drawing.Size(118, 17);
            this.sB1.Text = "toolStripStatusLabel1";
            // 
            // chkToday
            // 
            this.chkToday.BackColor = System.Drawing.Color.Transparent;
            this.chkToday.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.chkToday.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkToday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkToday.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkToday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.chkToday.Location = new System.Drawing.Point(557, 19);
            this.chkToday.Name = "chkToday";
            this.chkToday.Padding = new System.Windows.Forms.Padding(4, 1, 1, 1);
            this.chkToday.Size = new System.Drawing.Size(151, 24);
            this.chkToday.TabIndex = 582;
            this.chkToday.Text = "Today ยังไม่ได้ออก  visit";
            this.theme1.SetTheme(this.chkToday, "(default)");
            this.chkToday.UseVisualStyleBackColor = true;
            this.chkToday.Value = null;
            this.chkToday.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // FrmVisitView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 734);
            this.Controls.Add(this.gB);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.sB);
            this.Name = "FrmVisitView";
            this.Text = "FrmVisitView";
            this.Load += new System.EventHandler(this.FrmVisitView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNew)).EndInit();
            this.sB.ResumeLayout(false);
            this.sB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkToday)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Themes.C1ThemeController theme1;
        private System.Windows.Forms.StatusStrip sB;
        private System.Windows.Forms.ToolStripStatusLabel sB1;
        private System.Windows.Forms.GroupBox gB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private C1.Win.C1Input.C1TextBox txtSearch;
        private C1.Win.C1Input.C1Button btnNew;
        private System.Windows.Forms.RadioButton chkVisit;
        private System.Windows.Forms.RadioButton chkHn;
        private C1.Win.C1Input.C1CheckBox chkToday;
    }
}