namespace clinic_ivf.gui
{
    partial class FrmNurseView
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDateStart = new C1.Win.C1Input.C1DateEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSearch = new C1.Win.C1Input.C1TextBox();
            this.btnNew = new C1.Win.C1Input.C1Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tC = new C1.Win.C1Command.C1DockingTab();
            this.tabWaiting = new C1.Win.C1Command.C1DockingTabPage();
            this.pnQue = new System.Windows.Forms.Panel();
            this.tabDiag = new C1.Win.C1Command.C1DockingTabPage();
            this.pnDiag = new System.Windows.Forms.Panel();
            this.tabFinish = new C1.Win.C1Command.C1DockingTabPage();
            this.pnFinish = new System.Windows.Forms.Panel();
            this.sB = new System.Windows.Forms.StatusStrip();
            this.sB1 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNew)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tC)).BeginInit();
            this.tC.SuspendLayout();
            this.tabWaiting.SuspendLayout();
            this.tabDiag.SuspendLayout();
            this.tabFinish.SuspendLayout();
            this.sB.SuspendLayout();
            this.SuspendLayout();
            // 
            // theme1
            // 
            this.theme1.Theme = "Office2013Red";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtDateStart);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.btnNew);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1071, 54);
            this.groupBox1.TabIndex = 527;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            this.theme1.SetTheme(this.groupBox1, "(default)");
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label11.Location = new System.Drawing.Point(371, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 16);
            this.label11.TabIndex = 534;
            this.label11.Text = "Date Start :";
            this.theme1.SetTheme(this.label11, "(default)");
            // 
            // txtDateStart
            // 
            this.txtDateStart.AllowSpinLoop = false;
            this.txtDateStart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // 
            // 
            this.txtDateStart.Calendar.ArrowColor = System.Drawing.Color.Black;
            this.txtDateStart.Calendar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtDateStart.Calendar.DayNamesFont = new System.Drawing.Font("Tahoma", 8F);
            this.txtDateStart.Calendar.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtDateStart.Calendar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.txtDateStart.Calendar.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(71)))), ((int)(((byte)(47)))));
            this.txtDateStart.Calendar.SelectionForeColor = System.Drawing.Color.White;
            this.txtDateStart.Calendar.TitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.txtDateStart.Calendar.TitleFont = new System.Drawing.Font("Tahoma", 8F);
            this.txtDateStart.Calendar.TitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.txtDateStart.Calendar.TodayBorderColor = System.Drawing.Color.White;
            this.txtDateStart.Calendar.TrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtDateStart.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.txtDateStart.Culture = 1054;
            this.txtDateStart.DateTimeInput = false;
            this.txtDateStart.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtDateStart.DisplayFormat.CustomFormat = "dd-MM-yyyy";
            this.txtDateStart.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate;
            this.txtDateStart.DisplayFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) 
            | C1.Win.C1Input.FormatInfoInheritFlags.CalendarType)));
            this.txtDateStart.ImagePadding = new System.Windows.Forms.Padding(0);
            this.txtDateStart.Location = new System.Drawing.Point(450, 21);
            this.txtDateStart.Name = "txtDateStart";
            this.txtDateStart.Size = new System.Drawing.Size(105, 18);
            this.txtDateStart.TabIndex = 533;
            this.txtDateStart.Tag = null;
            this.theme1.SetTheme(this.txtDateStart, "(default)");
            this.txtDateStart.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.tC);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel1.Location = new System.Drawing.Point(0, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1071, 624);
            this.panel1.TabIndex = 533;
            this.theme1.SetTheme(this.panel1, "(default)");
            // 
            // tC
            // 
            this.tC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tC.Controls.Add(this.tabWaiting);
            this.tC.Controls.Add(this.tabDiag);
            this.tC.Controls.Add(this.tabFinish);
            this.tC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tC.HotTrack = true;
            this.tC.Location = new System.Drawing.Point(0, 0);
            this.tC.Name = "tC";
            this.tC.SelectedIndex = 1;
            this.tC.Size = new System.Drawing.Size(1071, 624);
            this.tC.TabIndex = 0;
            this.tC.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Fit;
            this.tC.TabsShowFocusCues = false;
            this.tC.TabsSpacing = 2;
            this.tC.TabStyle = C1.Win.C1Command.TabStyleEnum.Office2007;
            this.theme1.SetTheme(this.tC, "(default)");
            // 
            // tabWaiting
            // 
            this.tabWaiting.Controls.Add(this.pnQue);
            this.tabWaiting.Location = new System.Drawing.Point(1, 24);
            this.tabWaiting.Name = "tabWaiting";
            this.tabWaiting.Size = new System.Drawing.Size(1069, 599);
            this.tabWaiting.TabIndex = 0;
            this.tabWaiting.Text = "waiting in queue";
            // 
            // pnQue
            // 
            this.pnQue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnQue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnQue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnQue.Location = new System.Drawing.Point(0, 0);
            this.pnQue.Name = "pnQue";
            this.pnQue.Size = new System.Drawing.Size(1069, 599);
            this.pnQue.TabIndex = 0;
            this.theme1.SetTheme(this.pnQue, "(default)");
            // 
            // tabDiag
            // 
            this.tabDiag.Controls.Add(this.pnDiag);
            this.tabDiag.Location = new System.Drawing.Point(1, 24);
            this.tabDiag.Name = "tabDiag";
            this.tabDiag.Size = new System.Drawing.Size(1069, 599);
            this.tabDiag.TabIndex = 1;
            this.tabDiag.Text = "doctor diagnose";
            // 
            // pnDiag
            // 
            this.pnDiag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnDiag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnDiag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnDiag.Location = new System.Drawing.Point(0, 0);
            this.pnDiag.Name = "pnDiag";
            this.pnDiag.Size = new System.Drawing.Size(1069, 599);
            this.pnDiag.TabIndex = 0;
            this.theme1.SetTheme(this.pnDiag, "(default)");
            // 
            // tabFinish
            // 
            this.tabFinish.Controls.Add(this.pnFinish);
            this.tabFinish.Location = new System.Drawing.Point(1, 24);
            this.tabFinish.Name = "tabFinish";
            this.tabFinish.Size = new System.Drawing.Size(1069, 599);
            this.tabFinish.TabIndex = 2;
            this.tabFinish.Text = "Finish Diagnose";
            // 
            // pnFinish
            // 
            this.pnFinish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnFinish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnFinish.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnFinish.Location = new System.Drawing.Point(0, 0);
            this.pnFinish.Name = "pnFinish";
            this.pnFinish.Size = new System.Drawing.Size(1069, 599);
            this.pnFinish.TabIndex = 0;
            this.theme1.SetTheme(this.pnFinish, "(default)");
            // 
            // sB
            // 
            this.sB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sB1});
            this.sB.Location = new System.Drawing.Point(0, 678);
            this.sB.Name = "sB";
            this.sB.Size = new System.Drawing.Size(1071, 22);
            this.sB.TabIndex = 526;
            this.sB.Text = "statusStrip1";
            // 
            // sB1
            // 
            this.sB1.Name = "sB1";
            this.sB1.Size = new System.Drawing.Size(118, 17);
            this.sB1.Text = "toolStripStatusLabel1";
            // 
            // FrmNurseView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 700);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.sB);
            this.Name = "FrmNurseView";
            this.Text = "FrmNurseView";
            this.Load += new System.EventHandler(this.FrmNurseView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNew)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tC)).EndInit();
            this.tC.ResumeLayout(false);
            this.tabWaiting.ResumeLayout(false);
            this.tabDiag.ResumeLayout(false);
            this.tabFinish.ResumeLayout(false);
            this.sB.ResumeLayout(false);
            this.sB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Themes.C1ThemeController theme1;
        private System.Windows.Forms.StatusStrip sB;
        private System.Windows.Forms.ToolStripStatusLabel sB1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private C1.Win.C1Input.C1TextBox txtSearch;
        private C1.Win.C1Input.C1Button btnNew;
        private System.Windows.Forms.Panel panel1;
        private C1.Win.C1Command.C1DockingTab tC;
        private C1.Win.C1Command.C1DockingTabPage tabWaiting;
        private C1.Win.C1Command.C1DockingTabPage tabDiag;
        private C1.Win.C1Command.C1DockingTabPage tabFinish;
        private C1.Win.C1Input.C1DateEdit txtDateStart;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel pnQue;
        private System.Windows.Forms.Panel pnDiag;
        private System.Windows.Forms.Panel pnFinish;
    }
}