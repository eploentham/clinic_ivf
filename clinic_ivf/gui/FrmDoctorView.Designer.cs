namespace clinic_ivf.gui
{
    partial class FrmDoctorView
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
            this.tC = new C1.Win.C1Command.C1DockingTab();
            this.tabWait = new C1.Win.C1Command.C1DockingTabPage();
            this.tabDiag = new C1.Win.C1Command.C1DockingTabPage();
            this.tabFinish = new C1.Win.C1Command.C1DockingTabPage();
            this.tabSearch = new C1.Win.C1Command.C1DockingTabPage();
            this.pnSearch = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSearch = new C1.Win.C1Input.C1Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDateStart = new C1.Win.C1Input.C1DateEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSearch = new C1.Win.C1Input.C1TextBox();
            this.pnQue = new System.Windows.Forms.Panel();
            this.pnDiag = new System.Windows.Forms.Panel();
            this.pnFinish = new System.Windows.Forms.Panel();
            this.sB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tC)).BeginInit();
            this.tC.SuspendLayout();
            this.tabWait.SuspendLayout();
            this.tabDiag.SuspendLayout();
            this.tabFinish.SuspendLayout();
            this.tabSearch.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // sB
            // 
            this.sB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sB1});
            this.sB.Location = new System.Drawing.Point(0, 693);
            this.sB.Name = "sB";
            this.sB.Size = new System.Drawing.Size(1008, 22);
            this.sB.TabIndex = 5;
            this.sB.Text = "statusStrip1";
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
            // tC
            // 
            this.tC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tC.Controls.Add(this.tabWait);
            this.tC.Controls.Add(this.tabDiag);
            this.tC.Controls.Add(this.tabFinish);
            this.tC.Controls.Add(this.tabSearch);
            this.tC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tC.HotTrack = true;
            this.tC.Location = new System.Drawing.Point(0, 0);
            this.tC.Name = "tC";
            this.tC.Size = new System.Drawing.Size(1008, 693);
            this.tC.TabIndex = 6;
            this.tC.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Fit;
            this.tC.TabsShowFocusCues = false;
            this.tC.TabsSpacing = 2;
            this.tC.TabStyle = C1.Win.C1Command.TabStyleEnum.Office2007;
            this.theme1.SetTheme(this.tC, "(default)");
            // 
            // tabWait
            // 
            this.tabWait.Controls.Add(this.pnQue);
            this.tabWait.Location = new System.Drawing.Point(1, 24);
            this.tabWait.Name = "tabWait";
            this.tabWait.Size = new System.Drawing.Size(1006, 668);
            this.tabWait.TabIndex = 0;
            this.tabWait.Text = "Waiting Queue";
            // 
            // tabDiag
            // 
            this.tabDiag.Controls.Add(this.pnDiag);
            this.tabDiag.Location = new System.Drawing.Point(1, 24);
            this.tabDiag.Name = "tabDiag";
            this.tabDiag.Size = new System.Drawing.Size(1006, 668);
            this.tabDiag.TabIndex = 1;
            this.tabDiag.Text = "Diagnosis";
            // 
            // tabFinish
            // 
            this.tabFinish.Controls.Add(this.pnFinish);
            this.tabFinish.Location = new System.Drawing.Point(1, 24);
            this.tabFinish.Name = "tabFinish";
            this.tabFinish.Size = new System.Drawing.Size(1006, 668);
            this.tabFinish.TabIndex = 2;
            this.tabFinish.Text = "Finish Diagnosis";
            // 
            // tabSearch
            // 
            this.tabSearch.Controls.Add(this.pnSearch);
            this.tabSearch.Controls.Add(this.panel3);
            this.tabSearch.Location = new System.Drawing.Point(1, 24);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.Size = new System.Drawing.Size(1006, 668);
            this.tabSearch.TabIndex = 3;
            this.tabSearch.Text = "Search";
            // 
            // pnSearch
            // 
            this.pnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnSearch.Location = new System.Drawing.Point(0, 36);
            this.pnSearch.Name = "pnSearch";
            this.pnSearch.Size = new System.Drawing.Size(1006, 632);
            this.pnSearch.TabIndex = 4;
            this.theme1.SetTheme(this.pnSearch, "(default)");
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel3.Controls.Add(this.btnSearch);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.txtDateStart);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txtSearch);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1006, 36);
            this.panel3.TabIndex = 3;
            this.theme1.SetTheme(this.panel3, "(default)");
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(744, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(28, 23);
            this.btnSearch.TabIndex = 736;
            this.btnSearch.Text = "...";
            this.theme1.SetTheme(this.btnSearch, "(default)");
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label11.Location = new System.Drawing.Point(246, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 16);
            this.label11.TabIndex = 735;
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
            this.txtDateStart.CurrentTimeZone = false;
            this.txtDateStart.DateTimeInput = false;
            this.txtDateStart.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtDateStart.DisplayFormat.CustomFormat = "dd-MM-yyyy";
            this.txtDateStart.DisplayFormat.EmptyAsNull = false;
            this.txtDateStart.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate;
            this.txtDateStart.DisplayFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)((((C1.Win.C1Input.FormatInfoInheritFlags.NullText | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) 
            | C1.Win.C1Input.FormatInfoInheritFlags.CalendarType)));
            this.txtDateStart.EditFormat.CustomFormat = "dd-MM-yyyy";
            this.txtDateStart.EditFormat.EmptyAsNull = false;
            this.txtDateStart.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate;
            this.txtDateStart.EditFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)((((C1.Win.C1Input.FormatInfoInheritFlags.NullText | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) 
            | C1.Win.C1Input.FormatInfoInheritFlags.CalendarType)));
            this.txtDateStart.EmptyAsNull = true;
            this.txtDateStart.GMTOffset = System.TimeSpan.Parse("00:00:00");
            this.txtDateStart.ImagePadding = new System.Windows.Forms.Padding(0);
            this.txtDateStart.Location = new System.Drawing.Point(325, 8);
            this.txtDateStart.Name = "txtDateStart";
            this.txtDateStart.ParseInfo.EmptyAsNull = false;
            this.txtDateStart.ParseInfo.Inherit = ((C1.Win.C1Input.ParseInfoInheritFlags)(((((((C1.Win.C1Input.ParseInfoInheritFlags.CaseSensitive | C1.Win.C1Input.ParseInfoInheritFlags.FormatType) 
            | C1.Win.C1Input.ParseInfoInheritFlags.CustomFormat) 
            | C1.Win.C1Input.ParseInfoInheritFlags.NullText) 
            | C1.Win.C1Input.ParseInfoInheritFlags.ErrorMessage) 
            | C1.Win.C1Input.ParseInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.ParseInfoInheritFlags.TrimEnd)));
            this.txtDateStart.Size = new System.Drawing.Size(142, 18);
            this.txtDateStart.TabIndex = 734;
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
            this.label4.Location = new System.Drawing.Point(7, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 16);
            this.label4.TabIndex = 733;
            this.label4.Text = "key :";
            this.theme1.SetTheme(this.label4, "(default)");
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtSearch.Location = new System.Drawing.Point(77, 6);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(157, 20);
            this.txtSearch.TabIndex = 732;
            this.txtSearch.Tag = null;
            this.theme1.SetTheme(this.txtSearch, "(default)");
            this.txtSearch.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // pnQue
            // 
            this.pnQue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnQue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnQue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnQue.Location = new System.Drawing.Point(0, 0);
            this.pnQue.Name = "pnQue";
            this.pnQue.Size = new System.Drawing.Size(1006, 668);
            this.pnQue.TabIndex = 0;
            this.theme1.SetTheme(this.pnQue, "(default)");
            // 
            // pnDiag
            // 
            this.pnDiag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnDiag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnDiag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnDiag.Location = new System.Drawing.Point(0, 0);
            this.pnDiag.Name = "pnDiag";
            this.pnDiag.Size = new System.Drawing.Size(1006, 668);
            this.pnDiag.TabIndex = 0;
            this.theme1.SetTheme(this.pnDiag, "(default)");
            // 
            // pnFinish
            // 
            this.pnFinish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnFinish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnFinish.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnFinish.Location = new System.Drawing.Point(0, 0);
            this.pnFinish.Name = "pnFinish";
            this.pnFinish.Size = new System.Drawing.Size(1006, 668);
            this.pnFinish.TabIndex = 0;
            this.theme1.SetTheme(this.pnFinish, "(default)");
            // 
            // FrmDoctorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 715);
            this.Controls.Add(this.tC);
            this.Controls.Add(this.sB);
            this.Name = "FrmDoctorView";
            this.Text = "FrmDoctorView";
            this.Load += new System.EventHandler(this.FrmDoctorView_Load);
            this.sB.ResumeLayout(false);
            this.sB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tC)).EndInit();
            this.tC.ResumeLayout(false);
            this.tabWait.ResumeLayout(false);
            this.tabDiag.ResumeLayout(false);
            this.tabFinish.ResumeLayout(false);
            this.tabSearch.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip sB;
        private System.Windows.Forms.ToolStripStatusLabel sB1;
        private C1.Win.C1Themes.C1ThemeController theme1;
        private C1.Win.C1Command.C1DockingTab tC;
        private C1.Win.C1Command.C1DockingTabPage tabWait;
        private C1.Win.C1Command.C1DockingTabPage tabDiag;
        private C1.Win.C1Command.C1DockingTabPage tabFinish;
        private C1.Win.C1Command.C1DockingTabPage tabSearch;
        private System.Windows.Forms.Panel pnSearch;
        private System.Windows.Forms.Panel panel3;
        private C1.Win.C1Input.C1Button btnSearch;
        private System.Windows.Forms.Label label11;
        private C1.Win.C1Input.C1DateEdit txtDateStart;
        private System.Windows.Forms.Label label4;
        private C1.Win.C1Input.C1TextBox txtSearch;
        private System.Windows.Forms.Panel pnQue;
        private System.Windows.Forms.Panel pnDiag;
        private System.Windows.Forms.Panel pnFinish;
    }
}