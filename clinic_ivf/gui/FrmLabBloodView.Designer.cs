namespace clinic_ivf.gui
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
            this.tabProcess = new C1.Win.C1Command.C1DockingTabPage();
            this.pnProc = new System.Windows.Forms.Panel();
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
            this.tabTestLis = new C1.Win.C1Command.C1DockingTabPage();
            this.pnLis = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboData = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboStop = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboParity = new System.Windows.Forms.ComboBox();
            this.cboBaud = new System.Windows.Forms.ComboBox();
            this.sB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcLabView)).BeginInit();
            this.tcLabView.SuspendLayout();
            this.tabLabAccept.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.tabTestLis.SuspendLayout();
            this.pnLis.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.tcLabView.Controls.Add(this.tabTestLis);
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
            this.pnReq.Location = new System.Drawing.Point(0, 0);
            this.pnReq.Name = "pnReq";
            this.pnReq.Size = new System.Drawing.Size(1093, 691);
            this.pnReq.TabIndex = 1;
            this.theme1.SetTheme(this.pnReq, "(default)");
            // 
            // tabProcess
            // 
            this.tabProcess.Controls.Add(this.pnProc);
            this.tabProcess.Location = new System.Drawing.Point(1, 24);
            this.tabProcess.Name = "tabProcess";
            this.tabProcess.Size = new System.Drawing.Size(1093, 691);
            this.tabProcess.TabIndex = 2;
            this.tabProcess.Text = "Process";
            // 
            // pnProc
            // 
            this.pnProc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnProc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnProc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnProc.Location = new System.Drawing.Point(0, 0);
            this.pnProc.Name = "pnProc";
            this.pnProc.Size = new System.Drawing.Size(1093, 691);
            this.pnProc.TabIndex = 0;
            this.theme1.SetTheme(this.pnProc, "(default)");
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
            // tabTestLis
            // 
            this.tabTestLis.Controls.Add(this.pnLis);
            this.tabTestLis.Location = new System.Drawing.Point(1, 24);
            this.tabTestLis.Name = "tabTestLis";
            this.tabTestLis.Size = new System.Drawing.Size(1093, 691);
            this.tabTestLis.TabIndex = 4;
            this.tabTestLis.Text = "Test LIS";
            // 
            // pnLis
            // 
            this.pnLis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnLis.Controls.Add(this.groupBox3);
            this.pnLis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnLis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnLis.Location = new System.Drawing.Point(0, 0);
            this.pnLis.Name = "pnLis";
            this.pnLis.Size = new System.Drawing.Size(1093, 691);
            this.pnLis.TabIndex = 0;
            this.theme1.SetTheme(this.pnLis, "(default)");
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.cboData);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.cboStop);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.cboParity);
            this.groupBox3.Controls.Add(this.cboBaud);
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.groupBox3.Location = new System.Drawing.Point(11, 14);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(117, 246);
            this.groupBox3.TabIndex = 86;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Options";
            this.theme1.SetTheme(this.groupBox3, "(default)");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label5.Location = new System.Drawing.Point(6, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Data Bits";
            this.theme1.SetTheme(this.label5, "(default)");
            // 
            // cboData
            // 
            this.cboData.BackColor = System.Drawing.Color.White;
            this.cboData.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.cboData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.cboData.FormattingEnabled = true;
            this.cboData.Items.AddRange(new object[] {
            "7",
            "8",
            "9"});
            this.cboData.Location = new System.Drawing.Point(9, 195);
            this.cboData.Name = "cboData";
            this.cboData.Size = new System.Drawing.Size(102, 26);
            this.cboData.TabIndex = 14;
            this.theme1.SetTheme(this.cboData, "(default)");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label6.Location = new System.Drawing.Point(7, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Stop Bits";
            this.theme1.SetTheme(this.label6, "(default)");
            // 
            // cboStop
            // 
            this.cboStop.BackColor = System.Drawing.Color.White;
            this.cboStop.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.cboStop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.cboStop.FormattingEnabled = true;
            this.cboStop.Location = new System.Drawing.Point(9, 144);
            this.cboStop.Name = "cboStop";
            this.cboStop.Size = new System.Drawing.Size(102, 26);
            this.cboStop.TabIndex = 13;
            this.theme1.SetTheme(this.cboStop, "(default)");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label7.Location = new System.Drawing.Point(6, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Parity";
            this.theme1.SetTheme(this.label7, "(default)");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label8.Location = new System.Drawing.Point(6, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Baud Rate";
            this.theme1.SetTheme(this.label8, "(default)");
            // 
            // cboParity
            // 
            this.cboParity.BackColor = System.Drawing.Color.White;
            this.cboParity.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.cboParity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.cboParity.FormattingEnabled = true;
            this.cboParity.Location = new System.Drawing.Point(9, 90);
            this.cboParity.Name = "cboParity";
            this.cboParity.Size = new System.Drawing.Size(102, 26);
            this.cboParity.TabIndex = 12;
            this.theme1.SetTheme(this.cboParity, "(default)");
            // 
            // cboBaud
            // 
            this.cboBaud.BackColor = System.Drawing.Color.White;
            this.cboBaud.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.cboBaud.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.cboBaud.FormattingEnabled = true;
            this.cboBaud.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "28800",
            "36000",
            "115200"});
            this.cboBaud.Location = new System.Drawing.Point(9, 37);
            this.cboBaud.Name = "cboBaud";
            this.cboBaud.Size = new System.Drawing.Size(102, 26);
            this.cboBaud.TabIndex = 11;
            this.theme1.SetTheme(this.cboBaud, "(default)");
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
            this.tabTestLis.ResumeLayout(false);
            this.pnLis.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
        private C1.Win.C1Command.C1DockingTabPage tabProcess;
        private System.Windows.Forms.Panel pnProc;
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
        private C1.Win.C1Command.C1DockingTabPage tabTestLis;
        private System.Windows.Forms.Panel pnLis;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboData;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboStop;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboParity;
        private System.Windows.Forms.ComboBox cboBaud;
    }
}