﻿namespace clinic_ivf.gui
{
    partial class FrmLabBloodView
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
            this.tcLabView = new C1.Win.C1Command.C1DockingTab();
            this.tabLabAccept = new C1.Win.C1Command.C1DockingTabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnReq = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.c1SplitButton1 = new C1.Win.C1Input.C1SplitButton();
            this.btnOPU = new C1.Win.C1Input.DropDownItem();
            this.btnFet = new C1.Win.C1Input.DropDownItem();
            this.txtHn = new C1.Win.C1Input.C1TextBox();
            this.btnSearchA = new C1.Win.C1Input.C1Button();
            this.txtDateEnd = new C1.Win.C1Input.C1DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDateStart = new C1.Win.C1Input.C1DateEdit();
            this.label11 = new System.Windows.Forms.Label();
            this.btnNew = new C1.Win.C1Input.C1Button();
            this.tabProcess = new C1.Win.C1Command.C1DockingTabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabLabFinish = new C1.Win.C1Command.C1DockingTabPage();
            this.gbFinish = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtFiDateEnd = new C1.Win.C1Input.C1DateEdit();
            this.txtFiDateStart = new C1.Win.C1Input.C1DateEdit();
            this.c1TextBox1 = new C1.Win.C1Input.C1TextBox();
            this.btnSearchF = new C1.Win.C1Input.C1Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.c1Button3 = new C1.Win.C1Input.C1Button();
            this.tabSearch = new C1.Win.C1Command.C1DockingTabPage();
            this.pnSearch = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSearch = new C1.Win.C1Input.C1Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSearch = new C1.Win.C1Input.C1TextBox();
            this.sB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcLabView)).BeginInit();
            this.tcLabView.SuspendLayout();
            this.tabLabAccept.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1SplitButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNew)).BeginInit();
            this.tabProcess.SuspendLayout();
            this.tabLabFinish.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFiDateEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFiDateStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1TextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Button3)).BeginInit();
            this.tabSearch.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // sB
            // 
            this.sB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sB1});
            this.sB.Location = new System.Drawing.Point(0, 716);
            this.sB.Name = "sB";
            this.sB.Size = new System.Drawing.Size(1095, 22);
            this.sB.TabIndex = 527;
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
            // tcLabView
            // 
            this.tcLabView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tcLabView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tcLabView.Controls.Add(this.tabLabAccept);
            this.tcLabView.Controls.Add(this.tabProcess);
            this.tcLabView.Controls.Add(this.tabLabFinish);
            this.tcLabView.Controls.Add(this.tabSearch);
            this.tcLabView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcLabView.HotTrack = true;
            this.tcLabView.Location = new System.Drawing.Point(0, 0);
            this.tcLabView.Name = "tcLabView";
            this.tcLabView.SelectedIndex = 3;
            this.tcLabView.Size = new System.Drawing.Size(1095, 716);
            this.tcLabView.TabIndex = 528;
            this.tcLabView.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Fit;
            this.tcLabView.TabsShowFocusCues = false;
            this.tcLabView.TabsSpacing = 2;
            this.tcLabView.TabStyle = C1.Win.C1Command.TabStyleEnum.Office2007;
            this.theme1.SetTheme(this.tcLabView, "(default)");
            // 
            // tabLabAccept
            // 
            this.tabLabAccept.Controls.Add(this.panel1);
            this.tabLabAccept.Location = new System.Drawing.Point(1, 24);
            this.tabLabAccept.Name = "tabLabAccept";
            this.tabLabAccept.Size = new System.Drawing.Size(1093, 691);
            this.tabLabAccept.TabIndex = 0;
            this.tabLabAccept.Text = "Request LAB";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.pnReq);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1093, 691);
            this.panel1.TabIndex = 9;
            this.theme1.SetTheme(this.panel1, "(default)");
            // 
            // pnReq
            // 
            this.pnReq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnReq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnReq.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnReq.Location = new System.Drawing.Point(0, 47);
            this.pnReq.Name = "pnReq";
            this.pnReq.Size = new System.Drawing.Size(1093, 644);
            this.pnReq.TabIndex = 1;
            this.theme1.SetTheme(this.pnReq, "(default)");
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.groupBox1.Controls.Add(this.c1SplitButton1);
            this.groupBox1.Controls.Add(this.txtHn);
            this.groupBox1.Controls.Add(this.btnSearchA);
            this.groupBox1.Controls.Add(this.txtDateEnd);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDateStart);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.btnNew);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1093, 47);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            this.theme1.SetTheme(this.groupBox1, "(default)");
            // 
            // c1SplitButton1
            // 
            this.c1SplitButton1.Items.Add(this.btnOPU);
            this.c1SplitButton1.Items.Add(this.btnFet);
            this.c1SplitButton1.Location = new System.Drawing.Point(602, 15);
            this.c1SplitButton1.Name = "c1SplitButton1";
            this.c1SplitButton1.Size = new System.Drawing.Size(115, 23);
            this.c1SplitButton1.TabIndex = 11;
            this.c1SplitButton1.Text = "ป้อน LAB";
            this.theme1.SetTheme(this.c1SplitButton1, "(default)");
            this.c1SplitButton1.UseVisualStyleBackColor = true;
            this.c1SplitButton1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // btnOPU
            // 
            this.btnOPU.Text = "OPU";
            // 
            // btnFet
            // 
            this.btnFet.Text = "FET";
            // 
            // txtHn
            // 
            this.txtHn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHn.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtHn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtHn.Location = new System.Drawing.Point(519, 18);
            this.txtHn.Name = "txtHn";
            this.txtHn.Size = new System.Drawing.Size(29, 20);
            this.txtHn.TabIndex = 522;
            this.txtHn.Tag = null;
            this.theme1.SetTheme(this.txtHn, "(default)");
            this.txtHn.Visible = false;
            this.txtHn.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // btnSearchA
            // 
            this.btnSearchA.Location = new System.Drawing.Point(471, 15);
            this.btnSearchA.Name = "btnSearchA";
            this.btnSearchA.Size = new System.Drawing.Size(28, 23);
            this.btnSearchA.TabIndex = 517;
            this.btnSearchA.Text = "...";
            this.theme1.SetTheme(this.btnSearchA, "(default)");
            this.btnSearchA.UseVisualStyleBackColor = true;
            this.btnSearchA.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // txtDateEnd
            // 
            this.txtDateEnd.AllowSpinLoop = false;
            this.txtDateEnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // 
            // 
            this.txtDateEnd.Calendar.ArrowColor = System.Drawing.Color.Black;
            this.txtDateEnd.Calendar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtDateEnd.Calendar.DayNamesFont = new System.Drawing.Font("Tahoma", 8F);
            this.txtDateEnd.Calendar.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtDateEnd.Calendar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.txtDateEnd.Calendar.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(71)))), ((int)(((byte)(47)))));
            this.txtDateEnd.Calendar.SelectionForeColor = System.Drawing.Color.White;
            this.txtDateEnd.Calendar.TitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.txtDateEnd.Calendar.TitleFont = new System.Drawing.Font("Tahoma", 8F);
            this.txtDateEnd.Calendar.TitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.txtDateEnd.Calendar.TodayBorderColor = System.Drawing.Color.White;
            this.txtDateEnd.Calendar.TrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtDateEnd.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.txtDateEnd.Culture = 1054;
            this.txtDateEnd.CurrentTimeZone = false;
            this.txtDateEnd.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtDateEnd.DisplayFormat.CalendarType = C1.Win.C1Input.CalendarType.GregorianCalendar;
            this.txtDateEnd.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate;
            this.txtDateEnd.DisplayFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText) 
            | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.txtDateEnd.EditFormat.CalendarType = C1.Win.C1Input.CalendarType.GregorianCalendar;
            this.txtDateEnd.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate;
            this.txtDateEnd.EditFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText) 
            | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.txtDateEnd.GMTOffset = System.TimeSpan.Parse("00:00:00");
            this.txtDateEnd.ImagePadding = new System.Windows.Forms.Padding(0);
            this.txtDateEnd.Location = new System.Drawing.Point(323, 17);
            this.txtDateEnd.Name = "txtDateEnd";
            this.txtDateEnd.Size = new System.Drawing.Size(129, 18);
            this.txtDateEnd.TabIndex = 514;
            this.txtDateEnd.Tag = null;
            this.theme1.SetTheme(this.txtDateEnd, "(default)");
            this.txtDateEnd.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label1.Location = new System.Drawing.Point(247, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 513;
            this.label1.Text = "Date End :";
            this.theme1.SetTheme(this.label1, "(default)");
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
            this.txtDateStart.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtDateStart.DisplayFormat.CalendarType = C1.Win.C1Input.CalendarType.GregorianCalendar;
            this.txtDateStart.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate;
            this.txtDateStart.DisplayFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText) 
            | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.txtDateStart.EditFormat.CalendarType = C1.Win.C1Input.CalendarType.GregorianCalendar;
            this.txtDateStart.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate;
            this.txtDateStart.EditFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText) 
            | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.txtDateStart.GMTOffset = System.TimeSpan.Parse("00:00:00");
            this.txtDateStart.ImagePadding = new System.Windows.Forms.Padding(0);
            this.txtDateStart.Location = new System.Drawing.Point(90, 17);
            this.txtDateStart.Name = "txtDateStart";
            this.txtDateStart.Size = new System.Drawing.Size(129, 18);
            this.txtDateStart.TabIndex = 512;
            this.txtDateStart.Tag = null;
            this.theme1.SetTheme(this.txtDateStart, "(default)");
            this.txtDateStart.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label11.Location = new System.Drawing.Point(11, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 16);
            this.label11.TabIndex = 511;
            this.label11.Text = "Date Start :";
            this.theme1.SetTheme(this.label11, "(default)");
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(960, 10);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(86, 31);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "ป้อนใหม่";
            this.theme1.SetTheme(this.btnNew, "(default)");
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // tabProcess
            // 
            this.tabProcess.Controls.Add(this.panel2);
            this.tabProcess.Location = new System.Drawing.Point(1, 24);
            this.tabProcess.Name = "tabProcess";
            this.tabProcess.Size = new System.Drawing.Size(1093, 691);
            this.tabProcess.TabIndex = 2;
            this.tabProcess.Text = "Process";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1093, 691);
            this.panel2.TabIndex = 0;
            this.theme1.SetTheme(this.panel2, "(default)");
            // 
            // tabLabFinish
            // 
            this.tabLabFinish.Controls.Add(this.gbFinish);
            this.tabLabFinish.Controls.Add(this.groupBox2);
            this.tabLabFinish.Location = new System.Drawing.Point(1, 24);
            this.tabLabFinish.Name = "tabLabFinish";
            this.tabLabFinish.Size = new System.Drawing.Size(1093, 691);
            this.tabLabFinish.TabIndex = 1;
            this.tabLabFinish.Text = "LAB Finish";
            // 
            // gbFinish
            // 
            this.gbFinish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gbFinish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbFinish.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.gbFinish.Location = new System.Drawing.Point(0, 46);
            this.gbFinish.Name = "gbFinish";
            this.gbFinish.Size = new System.Drawing.Size(1093, 645);
            this.gbFinish.TabIndex = 2;
            this.gbFinish.TabStop = false;
            this.gbFinish.Text = "groupBox2";
            this.theme1.SetTheme(this.gbFinish, "(default)");
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.groupBox2.Controls.Add(this.txtFiDateEnd);
            this.groupBox2.Controls.Add(this.txtFiDateStart);
            this.groupBox2.Controls.Add(this.c1TextBox1);
            this.groupBox2.Controls.Add(this.btnSearchF);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.c1Button3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1093, 46);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search";
            this.theme1.SetTheme(this.groupBox2, "(default)");
            // 
            // txtFiDateEnd
            // 
            this.txtFiDateEnd.AllowSpinLoop = false;
            this.txtFiDateEnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // 
            // 
            this.txtFiDateEnd.Calendar.ArrowColor = System.Drawing.Color.Black;
            this.txtFiDateEnd.Calendar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtFiDateEnd.Calendar.DayNamesFont = new System.Drawing.Font("Tahoma", 8F);
            this.txtFiDateEnd.Calendar.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtFiDateEnd.Calendar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.txtFiDateEnd.Calendar.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(71)))), ((int)(((byte)(47)))));
            this.txtFiDateEnd.Calendar.SelectionForeColor = System.Drawing.Color.White;
            this.txtFiDateEnd.Calendar.TitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.txtFiDateEnd.Calendar.TitleFont = new System.Drawing.Font("Tahoma", 8F);
            this.txtFiDateEnd.Calendar.TitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.txtFiDateEnd.Calendar.TodayBorderColor = System.Drawing.Color.White;
            this.txtFiDateEnd.Calendar.TrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtFiDateEnd.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.txtFiDateEnd.Culture = 1054;
            this.txtFiDateEnd.CurrentTimeZone = false;
            this.txtFiDateEnd.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtFiDateEnd.DisplayFormat.CalendarType = C1.Win.C1Input.CalendarType.GregorianCalendar;
            this.txtFiDateEnd.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate;
            this.txtFiDateEnd.DisplayFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText) 
            | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.txtFiDateEnd.EditFormat.CalendarType = C1.Win.C1Input.CalendarType.GregorianCalendar;
            this.txtFiDateEnd.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate;
            this.txtFiDateEnd.EditFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText) 
            | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.txtFiDateEnd.GMTOffset = System.TimeSpan.Parse("00:00:00");
            this.txtFiDateEnd.ImagePadding = new System.Windows.Forms.Padding(0);
            this.txtFiDateEnd.Location = new System.Drawing.Point(323, 14);
            this.txtFiDateEnd.Name = "txtFiDateEnd";
            this.txtFiDateEnd.Size = new System.Drawing.Size(129, 18);
            this.txtFiDateEnd.TabIndex = 524;
            this.txtFiDateEnd.Tag = null;
            this.theme1.SetTheme(this.txtFiDateEnd, "(default)");
            this.txtFiDateEnd.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // txtFiDateStart
            // 
            this.txtFiDateStart.AllowSpinLoop = false;
            this.txtFiDateStart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // 
            // 
            this.txtFiDateStart.Calendar.ArrowColor = System.Drawing.Color.Black;
            this.txtFiDateStart.Calendar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtFiDateStart.Calendar.DayNamesFont = new System.Drawing.Font("Tahoma", 8F);
            this.txtFiDateStart.Calendar.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtFiDateStart.Calendar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.txtFiDateStart.Calendar.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(71)))), ((int)(((byte)(47)))));
            this.txtFiDateStart.Calendar.SelectionForeColor = System.Drawing.Color.White;
            this.txtFiDateStart.Calendar.TitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.txtFiDateStart.Calendar.TitleFont = new System.Drawing.Font("Tahoma", 8F);
            this.txtFiDateStart.Calendar.TitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.txtFiDateStart.Calendar.TodayBorderColor = System.Drawing.Color.White;
            this.txtFiDateStart.Calendar.TrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtFiDateStart.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.txtFiDateStart.Culture = 1054;
            this.txtFiDateStart.CurrentTimeZone = false;
            this.txtFiDateStart.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtFiDateStart.DisplayFormat.CalendarType = C1.Win.C1Input.CalendarType.GregorianCalendar;
            this.txtFiDateStart.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate;
            this.txtFiDateStart.DisplayFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText) 
            | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.txtFiDateStart.EditFormat.CalendarType = C1.Win.C1Input.CalendarType.GregorianCalendar;
            this.txtFiDateStart.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate;
            this.txtFiDateStart.EditFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText) 
            | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.txtFiDateStart.GMTOffset = System.TimeSpan.Parse("00:00:00");
            this.txtFiDateStart.ImagePadding = new System.Windows.Forms.Padding(0);
            this.txtFiDateStart.Location = new System.Drawing.Point(90, 15);
            this.txtFiDateStart.Name = "txtFiDateStart";
            this.txtFiDateStart.Size = new System.Drawing.Size(129, 18);
            this.txtFiDateStart.TabIndex = 523;
            this.txtFiDateStart.Tag = null;
            this.theme1.SetTheme(this.txtFiDateStart, "(default)");
            this.txtFiDateStart.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // c1TextBox1
            // 
            this.c1TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.c1TextBox1.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.c1TextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.c1TextBox1.Location = new System.Drawing.Point(519, 16);
            this.c1TextBox1.Name = "c1TextBox1";
            this.c1TextBox1.Size = new System.Drawing.Size(29, 20);
            this.c1TextBox1.TabIndex = 522;
            this.c1TextBox1.Tag = null;
            this.theme1.SetTheme(this.c1TextBox1, "(default)");
            this.c1TextBox1.Visible = false;
            this.c1TextBox1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // btnSearchF
            // 
            this.btnSearchF.Location = new System.Drawing.Point(471, 13);
            this.btnSearchF.Name = "btnSearchF";
            this.btnSearchF.Size = new System.Drawing.Size(28, 23);
            this.btnSearchF.TabIndex = 517;
            this.btnSearchF.Text = "...";
            this.theme1.SetTheme(this.btnSearchF, "(default)");
            this.btnSearchF.UseVisualStyleBackColor = true;
            this.btnSearchF.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label2.Location = new System.Drawing.Point(247, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 513;
            this.label2.Text = "Date End :";
            this.theme1.SetTheme(this.label2, "(default)");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label3.Location = new System.Drawing.Point(11, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 511;
            this.label3.Text = "Date Start :";
            this.theme1.SetTheme(this.label3, "(default)");
            // 
            // c1Button3
            // 
            this.c1Button3.Location = new System.Drawing.Point(630, 15);
            this.c1Button3.Name = "c1Button3";
            this.c1Button3.Size = new System.Drawing.Size(86, 24);
            this.c1Button3.TabIndex = 0;
            this.c1Button3.Text = "ป้อนใหม่";
            this.theme1.SetTheme(this.c1Button3, "(default)");
            this.c1Button3.UseVisualStyleBackColor = true;
            this.c1Button3.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // tabSearch
            // 
            this.tabSearch.Controls.Add(this.pnSearch);
            this.tabSearch.Controls.Add(this.panel3);
            this.tabSearch.Location = new System.Drawing.Point(1, 24);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.Size = new System.Drawing.Size(1093, 691);
            this.tabSearch.TabIndex = 3;
            this.tabSearch.Text = "Search";
            // 
            // pnSearch
            // 
            this.pnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnSearch.Location = new System.Drawing.Point(0, 49);
            this.pnSearch.Name = "pnSearch";
            this.pnSearch.Size = new System.Drawing.Size(1093, 642);
            this.pnSearch.TabIndex = 0;
            this.theme1.SetTheme(this.pnSearch, "(default)");
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel3.Controls.Add(this.btnSearch);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txtSearch);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1093, 49);
            this.panel3.TabIndex = 0;
            this.theme1.SetTheme(this.panel3, "(default)");
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(242, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(28, 23);
            this.btnSearch.TabIndex = 739;
            this.btnSearch.Text = "...";
            this.theme1.SetTheme(this.btnSearch, "(default)");
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label4.Location = new System.Drawing.Point(9, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 16);
            this.label4.TabIndex = 738;
            this.label4.Text = "key :";
            this.theme1.SetTheme(this.label4, "(default)");
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtSearch.Location = new System.Drawing.Point(79, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(157, 20);
            this.txtSearch.TabIndex = 737;
            this.txtSearch.Tag = null;
            this.theme1.SetTheme(this.txtSearch, "(default)");
            this.txtSearch.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // FrmLabBloodView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 738);
            this.Controls.Add(this.tcLabView);
            this.Controls.Add(this.sB);
            this.Name = "FrmLabBloodView";
            this.Text = "FrmLabBloodView";
            this.Load += new System.EventHandler(this.FrmLabBloodView_Load);
            this.sB.ResumeLayout(false);
            this.sB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcLabView)).EndInit();
            this.tcLabView.ResumeLayout(false);
            this.tabLabAccept.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1SplitButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNew)).EndInit();
            this.tabProcess.ResumeLayout(false);
            this.tabLabFinish.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFiDateEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFiDateStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1TextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Button3)).EndInit();
            this.tabSearch.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip sB;
        private System.Windows.Forms.ToolStripStatusLabel sB1;
        private C1.Win.C1Themes.C1ThemeController theme1;
        private C1.Win.C1Command.C1DockingTab tcLabView;
        private C1.Win.C1Command.C1DockingTabPage tabLabAccept;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnReq;
        private System.Windows.Forms.GroupBox groupBox1;
        private C1.Win.C1Input.C1SplitButton c1SplitButton1;
        private C1.Win.C1Input.DropDownItem btnOPU;
        private C1.Win.C1Input.DropDownItem btnFet;
        private C1.Win.C1Input.C1TextBox txtHn;
        private C1.Win.C1Input.C1Button btnSearchA;
        private C1.Win.C1Input.C1DateEdit txtDateEnd;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1Input.C1DateEdit txtDateStart;
        private System.Windows.Forms.Label label11;
        private C1.Win.C1Input.C1Button btnNew;
        private C1.Win.C1Command.C1DockingTabPage tabProcess;
        private System.Windows.Forms.Panel panel2;
        private C1.Win.C1Command.C1DockingTabPage tabLabFinish;
        private System.Windows.Forms.GroupBox gbFinish;
        private System.Windows.Forms.GroupBox groupBox2;
        private C1.Win.C1Input.C1DateEdit txtFiDateEnd;
        private C1.Win.C1Input.C1DateEdit txtFiDateStart;
        private C1.Win.C1Input.C1TextBox c1TextBox1;
        private C1.Win.C1Input.C1Button btnSearchF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private C1.Win.C1Input.C1Button c1Button3;
        private C1.Win.C1Command.C1DockingTabPage tabSearch;
        private System.Windows.Forms.Panel pnSearch;
        private System.Windows.Forms.Panel panel3;
        private C1.Win.C1Input.C1Button btnSearch;
        private System.Windows.Forms.Label label4;
        private C1.Win.C1Input.C1TextBox txtSearch;
    }
}