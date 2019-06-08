namespace clinic_ivf.gui
{
    partial class FrmCashierView
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
            this.tabQue = new C1.Win.C1Command.C1DockingTabPage();
            this.pnQue = new System.Windows.Forms.Panel();
            this.tabFinish = new C1.Win.C1Command.C1DockingTabPage();
            this.pnFinish = new System.Windows.Forms.Panel();
            this.tabSearch = new C1.Win.C1Command.C1DockingTabPage();
            this.pnSearch = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtDateStart = new C1.Win.C1Input.C1DateEdit();
            this.chkLabFormA = new C1.Win.C1Input.C1CheckBox();
            this.btnSearch = new C1.Win.C1Input.C1Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSearch = new C1.Win.C1Input.C1TextBox();
            this.tabCloseDay = new C1.Win.C1Command.C1DockingTabPage();
            this.tabReport = new C1.Win.C1Command.C1DockingTabPage();
            this.pnReport = new System.Windows.Forms.Panel();
            this.c1SplitContainer1 = new C1.Win.C1SplitContainer.C1SplitContainer();
            this.c1SplitterPanel1 = new C1.Win.C1SplitContainer.C1SplitterPanel();
            this.c1SplitterPanel2 = new C1.Win.C1SplitContainer.C1SplitterPanel();
            this.c1SplitContainer2 = new C1.Win.C1SplitContainer.C1SplitContainer();
            this.c1SplitterPanel3 = new C1.Win.C1SplitContainer.C1SplitterPanel();
            this.c1SplitterPanel4 = new C1.Win.C1SplitContainer.C1SplitterPanel();
            this.pnReportItem = new System.Windows.Forms.Panel();
            this.pnReportCri = new System.Windows.Forms.Panel();
            this.pnReportView = new System.Windows.Forms.Panel();
            this.c1DockingTab1 = new C1.Win.C1Command.C1DockingTab();
            this.tabCloseDayToday = new C1.Win.C1Command.C1DockingTabPage();
            this.tabCloseDayView = new C1.Win.C1Command.C1DockingTabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.c1DateEdit1 = new C1.Win.C1Input.C1DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.sB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tC)).BeginInit();
            this.tC.SuspendLayout();
            this.tabQue.SuspendLayout();
            this.tabFinish.SuspendLayout();
            this.tabSearch.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLabFormA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).BeginInit();
            this.tabCloseDay.SuspendLayout();
            this.tabReport.SuspendLayout();
            this.pnReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1SplitContainer1)).BeginInit();
            this.c1SplitContainer1.SuspendLayout();
            this.c1SplitterPanel1.SuspendLayout();
            this.c1SplitterPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1SplitContainer2)).BeginInit();
            this.c1SplitContainer2.SuspendLayout();
            this.c1SplitterPanel3.SuspendLayout();
            this.c1SplitterPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1DockingTab1)).BeginInit();
            this.c1DockingTab1.SuspendLayout();
            this.tabCloseDayToday.SuspendLayout();
            this.tabCloseDayView.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1DateEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // sB
            // 
            this.sB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sB1});
            this.sB.Location = new System.Drawing.Point(0, 722);
            this.sB.Name = "sB";
            this.sB.Size = new System.Drawing.Size(1074, 22);
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
            // tC
            // 
            this.tC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tC.Controls.Add(this.tabQue);
            this.tC.Controls.Add(this.tabFinish);
            this.tC.Controls.Add(this.tabSearch);
            this.tC.Controls.Add(this.tabCloseDay);
            this.tC.Controls.Add(this.tabReport);
            this.tC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tC.HotTrack = true;
            this.tC.Location = new System.Drawing.Point(0, 0);
            this.tC.Name = "tC";
            this.tC.Size = new System.Drawing.Size(1074, 722);
            this.tC.TabIndex = 528;
            this.tC.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Fit;
            this.tC.TabsShowFocusCues = false;
            this.tC.TabsSpacing = 2;
            this.tC.TabStyle = C1.Win.C1Command.TabStyleEnum.Office2007;
            this.theme1.SetTheme(this.tC, "(default)");
            // 
            // tabQue
            // 
            this.tabQue.Controls.Add(this.pnQue);
            this.tabQue.Location = new System.Drawing.Point(1, 24);
            this.tabQue.Name = "tabQue";
            this.tabQue.Size = new System.Drawing.Size(1072, 697);
            this.tabQue.TabIndex = 0;
            this.tabQue.Text = "Waiting in Process";
            // 
            // pnQue
            // 
            this.pnQue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnQue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnQue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnQue.Location = new System.Drawing.Point(0, 0);
            this.pnQue.Name = "pnQue";
            this.pnQue.Size = new System.Drawing.Size(1072, 697);
            this.pnQue.TabIndex = 0;
            this.theme1.SetTheme(this.pnQue, "(default)");
            // 
            // tabFinish
            // 
            this.tabFinish.Controls.Add(this.pnFinish);
            this.tabFinish.Location = new System.Drawing.Point(1, 24);
            this.tabFinish.Name = "tabFinish";
            this.tabFinish.Size = new System.Drawing.Size(1072, 697);
            this.tabFinish.TabIndex = 1;
            this.tabFinish.Text = "Finish";
            // 
            // pnFinish
            // 
            this.pnFinish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnFinish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnFinish.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnFinish.Location = new System.Drawing.Point(0, 0);
            this.pnFinish.Name = "pnFinish";
            this.pnFinish.Size = new System.Drawing.Size(1072, 697);
            this.pnFinish.TabIndex = 0;
            this.theme1.SetTheme(this.pnFinish, "(default)");
            // 
            // tabSearch
            // 
            this.tabSearch.Controls.Add(this.pnSearch);
            this.tabSearch.Controls.Add(this.panel3);
            this.tabSearch.Location = new System.Drawing.Point(1, 24);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.Size = new System.Drawing.Size(1072, 697);
            this.tabSearch.TabIndex = 2;
            this.tabSearch.Text = "Search";
            // 
            // pnSearch
            // 
            this.pnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnSearch.Location = new System.Drawing.Point(0, 36);
            this.pnSearch.Name = "pnSearch";
            this.pnSearch.Size = new System.Drawing.Size(1072, 661);
            this.pnSearch.TabIndex = 4;
            this.theme1.SetTheme(this.pnSearch, "(default)");
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel3.Controls.Add(this.txtDateStart);
            this.panel3.Controls.Add(this.chkLabFormA);
            this.panel3.Controls.Add(this.btnSearch);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txtSearch);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1072, 36);
            this.panel3.TabIndex = 3;
            this.theme1.SetTheme(this.panel3, "(default)");
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
            this.txtDateStart.EmptyAsNull = true;
            this.txtDateStart.GMTOffset = System.TimeSpan.Parse("00:00:00");
            this.txtDateStart.ImagePadding = new System.Windows.Forms.Padding(0);
            this.txtDateStart.Location = new System.Drawing.Point(325, 8);
            this.txtDateStart.Name = "txtDateStart";
            this.txtDateStart.Size = new System.Drawing.Size(119, 18);
            this.txtDateStart.TabIndex = 738;
            this.txtDateStart.Tag = null;
            this.theme1.SetTheme(this.txtDateStart, "(default)");
            this.txtDateStart.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // chkLabFormA
            // 
            this.chkLabFormA.BackColor = System.Drawing.Color.Transparent;
            this.chkLabFormA.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.chkLabFormA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkLabFormA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkLabFormA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLabFormA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.chkLabFormA.Location = new System.Drawing.Point(483, 6);
            this.chkLabFormA.Name = "chkLabFormA";
            this.chkLabFormA.Padding = new System.Windows.Forms.Padding(4, 1, 1, 1);
            this.chkLabFormA.Size = new System.Drawing.Size(140, 24);
            this.chkLabFormA.TabIndex = 737;
            this.chkLabFormA.Text = "ค้นหา Lab Form A";
            this.theme1.SetTheme(this.chkLabFormA, "(default)");
            this.chkLabFormA.UseVisualStyleBackColor = true;
            this.chkLabFormA.Value = null;
            this.chkLabFormA.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
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
            // tabCloseDay
            // 
            this.tabCloseDay.Controls.Add(this.c1DockingTab1);
            this.tabCloseDay.Location = new System.Drawing.Point(1, 24);
            this.tabCloseDay.Name = "tabCloseDay";
            this.tabCloseDay.Size = new System.Drawing.Size(1072, 697);
            this.tabCloseDay.TabIndex = 3;
            this.tabCloseDay.Text = "Close Day";
            // 
            // tabReport
            // 
            this.tabReport.Controls.Add(this.pnReport);
            this.tabReport.Location = new System.Drawing.Point(1, 24);
            this.tabReport.Name = "tabReport";
            this.tabReport.Size = new System.Drawing.Size(1072, 697);
            this.tabReport.TabIndex = 4;
            this.tabReport.Text = "Report";
            // 
            // pnReport
            // 
            this.pnReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnReport.Controls.Add(this.c1SplitContainer1);
            this.pnReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnReport.Location = new System.Drawing.Point(0, 0);
            this.pnReport.Name = "pnReport";
            this.pnReport.Size = new System.Drawing.Size(1072, 697);
            this.pnReport.TabIndex = 0;
            this.theme1.SetTheme(this.pnReport, "(default)");
            // 
            // c1SplitContainer1
            // 
            this.c1SplitContainer1.AutoSizeElement = C1.Framework.AutoSizeElement.Both;
            this.c1SplitContainer1.BackColor = System.Drawing.Color.White;
            this.c1SplitContainer1.CollapsingAreaColor = System.Drawing.Color.White;
            this.c1SplitContainer1.CollapsingCueColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.c1SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1SplitContainer1.FixedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(189)))), ((int)(((byte)(182)))));
            this.c1SplitContainer1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.c1SplitContainer1.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.c1SplitContainer1.HeaderLineWidth = 1;
            this.c1SplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.c1SplitContainer1.Name = "c1SplitContainer1";
            this.c1SplitContainer1.Panels.Add(this.c1SplitterPanel1);
            this.c1SplitContainer1.Panels.Add(this.c1SplitterPanel2);
            this.c1SplitContainer1.Size = new System.Drawing.Size(1072, 697);
            this.c1SplitContainer1.SplitterColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(189)))), ((int)(((byte)(182)))));
            this.c1SplitContainer1.SplitterMovingColor = System.Drawing.Color.Black;
            this.c1SplitContainer1.TabIndex = 0;
            this.theme1.SetTheme(this.c1SplitContainer1, "(default)");
            this.c1SplitContainer1.UseParentVisualStyle = false;
            // 
            // c1SplitterPanel1
            // 
            this.c1SplitterPanel1.Collapsible = true;
            this.c1SplitterPanel1.Controls.Add(this.c1SplitContainer2);
            this.c1SplitterPanel1.Dock = C1.Win.C1SplitContainer.PanelDockStyle.Left;
            this.c1SplitterPanel1.Location = new System.Drawing.Point(0, 21);
            this.c1SplitterPanel1.Name = "c1SplitterPanel1";
            this.c1SplitterPanel1.Size = new System.Drawing.Size(285, 676);
            this.c1SplitterPanel1.SizeRatio = 27.341D;
            this.c1SplitterPanel1.TabIndex = 0;
            this.c1SplitterPanel1.Text = "Panel 1";
            this.c1SplitterPanel1.Width = 285;
            // 
            // c1SplitterPanel2
            // 
            this.c1SplitterPanel2.Controls.Add(this.pnReportView);
            this.c1SplitterPanel2.Height = 697;
            this.c1SplitterPanel2.Location = new System.Drawing.Point(296, 21);
            this.c1SplitterPanel2.Name = "c1SplitterPanel2";
            this.c1SplitterPanel2.Size = new System.Drawing.Size(776, 676);
            this.c1SplitterPanel2.TabIndex = 1;
            this.c1SplitterPanel2.Text = "Panel 2";
            // 
            // c1SplitContainer2
            // 
            this.c1SplitContainer2.AutoSizeElement = C1.Framework.AutoSizeElement.Both;
            this.c1SplitContainer2.BackColor = System.Drawing.Color.White;
            this.c1SplitContainer2.CollapsingAreaColor = System.Drawing.Color.White;
            this.c1SplitContainer2.CollapsingCueColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.c1SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1SplitContainer2.FixedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(189)))), ((int)(((byte)(182)))));
            this.c1SplitContainer2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.c1SplitContainer2.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.c1SplitContainer2.HeaderLineWidth = 1;
            this.c1SplitContainer2.Location = new System.Drawing.Point(0, 0);
            this.c1SplitContainer2.Name = "c1SplitContainer2";
            this.c1SplitContainer2.Panels.Add(this.c1SplitterPanel3);
            this.c1SplitContainer2.Panels.Add(this.c1SplitterPanel4);
            this.c1SplitContainer2.Size = new System.Drawing.Size(285, 676);
            this.c1SplitContainer2.SplitterColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(189)))), ((int)(((byte)(182)))));
            this.c1SplitContainer2.SplitterMovingColor = System.Drawing.Color.Black;
            this.c1SplitContainer2.TabIndex = 529;
            this.theme1.SetTheme(this.c1SplitContainer2, "(default)");
            this.c1SplitContainer2.UseParentVisualStyle = false;
            // 
            // c1SplitterPanel3
            // 
            this.c1SplitterPanel3.Collapsible = true;
            this.c1SplitterPanel3.Controls.Add(this.pnReportItem);
            this.c1SplitterPanel3.Height = 329;
            this.c1SplitterPanel3.Location = new System.Drawing.Point(0, 21);
            this.c1SplitterPanel3.Name = "c1SplitterPanel3";
            this.c1SplitterPanel3.Size = new System.Drawing.Size(285, 308);
            this.c1SplitterPanel3.TabIndex = 0;
            this.c1SplitterPanel3.Text = "Panel 1";
            // 
            // c1SplitterPanel4
            // 
            this.c1SplitterPanel4.Controls.Add(this.pnReportCri);
            this.c1SplitterPanel4.Height = 336;
            this.c1SplitterPanel4.Location = new System.Drawing.Point(0, 361);
            this.c1SplitterPanel4.Name = "c1SplitterPanel4";
            this.c1SplitterPanel4.Size = new System.Drawing.Size(285, 315);
            this.c1SplitterPanel4.TabIndex = 1;
            this.c1SplitterPanel4.Text = "Panel 2";
            // 
            // pnReportItem
            // 
            this.pnReportItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnReportItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnReportItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnReportItem.Location = new System.Drawing.Point(0, 0);
            this.pnReportItem.Name = "pnReportItem";
            this.pnReportItem.Size = new System.Drawing.Size(285, 308);
            this.pnReportItem.TabIndex = 0;
            this.theme1.SetTheme(this.pnReportItem, "(default)");
            // 
            // pnReportCri
            // 
            this.pnReportCri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnReportCri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnReportCri.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnReportCri.Location = new System.Drawing.Point(0, 0);
            this.pnReportCri.Name = "pnReportCri";
            this.pnReportCri.Size = new System.Drawing.Size(285, 315);
            this.pnReportCri.TabIndex = 0;
            this.theme1.SetTheme(this.pnReportCri, "(default)");
            // 
            // pnReportView
            // 
            this.pnReportView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnReportView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnReportView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnReportView.Location = new System.Drawing.Point(0, 0);
            this.pnReportView.Name = "pnReportView";
            this.pnReportView.Size = new System.Drawing.Size(776, 676);
            this.pnReportView.TabIndex = 0;
            this.theme1.SetTheme(this.pnReportView, "(default)");
            // 
            // c1DockingTab1
            // 
            this.c1DockingTab1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.c1DockingTab1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.c1DockingTab1.Controls.Add(this.tabCloseDayToday);
            this.c1DockingTab1.Controls.Add(this.tabCloseDayView);
            this.c1DockingTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1DockingTab1.HotTrack = true;
            this.c1DockingTab1.Location = new System.Drawing.Point(0, 0);
            this.c1DockingTab1.Name = "c1DockingTab1";
            this.c1DockingTab1.Size = new System.Drawing.Size(1072, 697);
            this.c1DockingTab1.TabIndex = 529;
            this.c1DockingTab1.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Fit;
            this.c1DockingTab1.TabsShowFocusCues = false;
            this.c1DockingTab1.TabsSpacing = 2;
            this.c1DockingTab1.TabStyle = C1.Win.C1Command.TabStyleEnum.Office2007;
            this.theme1.SetTheme(this.c1DockingTab1, "(default)");
            // 
            // tabCloseDayToday
            // 
            this.tabCloseDayToday.Controls.Add(this.panel1);
            this.tabCloseDayToday.Location = new System.Drawing.Point(1, 24);
            this.tabCloseDayToday.Name = "tabCloseDayToday";
            this.tabCloseDayToday.Size = new System.Drawing.Size(1070, 672);
            this.tabCloseDayToday.TabIndex = 0;
            this.tabCloseDayToday.Text = "Today";
            // 
            // tabCloseDayView
            // 
            this.tabCloseDayView.Controls.Add(this.panel4);
            this.tabCloseDayView.Controls.Add(this.panel2);
            this.tabCloseDayView.Location = new System.Drawing.Point(1, 24);
            this.tabCloseDayView.Name = "tabCloseDayView";
            this.tabCloseDayView.Size = new System.Drawing.Size(1070, 672);
            this.tabCloseDayView.TabIndex = 1;
            this.tabCloseDayView.Text = "ค้นหา";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1070, 672);
            this.panel1.TabIndex = 0;
            this.theme1.SetTheme(this.panel1, "(default)");
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel2.Controls.Add(this.c1DateEdit1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1070, 39);
            this.panel2.TabIndex = 0;
            this.theme1.SetTheme(this.panel2, "(default)");
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel4.Location = new System.Drawing.Point(0, 39);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1070, 633);
            this.panel4.TabIndex = 1;
            this.theme1.SetTheme(this.panel4, "(default)");
            // 
            // c1DateEdit1
            // 
            this.c1DateEdit1.AllowSpinLoop = false;
            this.c1DateEdit1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // 
            // 
            this.c1DateEdit1.Calendar.ArrowColor = System.Drawing.Color.Black;
            this.c1DateEdit1.Calendar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.c1DateEdit1.Calendar.DayNamesFont = new System.Drawing.Font("Tahoma", 8F);
            this.c1DateEdit1.Calendar.Font = new System.Drawing.Font("Tahoma", 8F);
            this.c1DateEdit1.Calendar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.c1DateEdit1.Calendar.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(71)))), ((int)(((byte)(47)))));
            this.c1DateEdit1.Calendar.SelectionForeColor = System.Drawing.Color.White;
            this.c1DateEdit1.Calendar.TitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.c1DateEdit1.Calendar.TitleFont = new System.Drawing.Font("Tahoma", 8F);
            this.c1DateEdit1.Calendar.TitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.c1DateEdit1.Calendar.TodayBorderColor = System.Drawing.Color.White;
            this.c1DateEdit1.Calendar.TrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.c1DateEdit1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.c1DateEdit1.Culture = 1054;
            this.c1DateEdit1.CurrentTimeZone = false;
            this.c1DateEdit1.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.c1DateEdit1.DisplayFormat.CalendarType = C1.Win.C1Input.CalendarType.GregorianCalendar;
            this.c1DateEdit1.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate;
            this.c1DateEdit1.DisplayFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText) 
            | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.c1DateEdit1.EditFormat.CalendarType = C1.Win.C1Input.CalendarType.GregorianCalendar;
            this.c1DateEdit1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate;
            this.c1DateEdit1.EditFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText) 
            | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.c1DateEdit1.EmptyAsNull = true;
            this.c1DateEdit1.GMTOffset = System.TimeSpan.Parse("00:00:00");
            this.c1DateEdit1.ImagePadding = new System.Windows.Forms.Padding(0);
            this.c1DateEdit1.Location = new System.Drawing.Point(515, 13);
            this.c1DateEdit1.Name = "c1DateEdit1";
            this.c1DateEdit1.Size = new System.Drawing.Size(119, 18);
            this.c1DateEdit1.TabIndex = 740;
            this.c1DateEdit1.Tag = null;
            this.theme1.SetTheme(this.c1DateEdit1, "(default)");
            this.c1DateEdit1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label1.Location = new System.Drawing.Point(436, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 739;
            this.label1.Text = "Date Start :";
            this.theme1.SetTheme(this.label1, "(default)");
            // 
            // FrmCashierView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 744);
            this.Controls.Add(this.tC);
            this.Controls.Add(this.sB);
            this.Name = "FrmCashierView";
            this.Text = "FrmCashierView";
            this.Load += new System.EventHandler(this.FrmCashierView_Load);
            this.sB.ResumeLayout(false);
            this.sB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tC)).EndInit();
            this.tC.ResumeLayout(false);
            this.tabQue.ResumeLayout(false);
            this.tabFinish.ResumeLayout(false);
            this.tabSearch.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLabFormA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).EndInit();
            this.tabCloseDay.ResumeLayout(false);
            this.tabReport.ResumeLayout(false);
            this.pnReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1SplitContainer1)).EndInit();
            this.c1SplitContainer1.ResumeLayout(false);
            this.c1SplitterPanel1.ResumeLayout(false);
            this.c1SplitterPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1SplitContainer2)).EndInit();
            this.c1SplitContainer2.ResumeLayout(false);
            this.c1SplitterPanel3.ResumeLayout(false);
            this.c1SplitterPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1DockingTab1)).EndInit();
            this.c1DockingTab1.ResumeLayout(false);
            this.tabCloseDayToday.ResumeLayout(false);
            this.tabCloseDayView.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1DateEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip sB;
        private System.Windows.Forms.ToolStripStatusLabel sB1;
        private C1.Win.C1Themes.C1ThemeController theme1;
        private C1.Win.C1Command.C1DockingTab tC;
        private C1.Win.C1Command.C1DockingTabPage tabQue;
        private C1.Win.C1Command.C1DockingTabPage tabFinish;
        private C1.Win.C1Command.C1DockingTabPage tabSearch;
        private System.Windows.Forms.Panel pnSearch;
        private System.Windows.Forms.Panel panel3;
        private C1.Win.C1Input.C1CheckBox chkLabFormA;
        private C1.Win.C1Input.C1Button btnSearch;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private C1.Win.C1Input.C1TextBox txtSearch;
        private System.Windows.Forms.Panel pnQue;
        private System.Windows.Forms.Panel pnFinish;
        private C1.Win.C1Input.C1DateEdit txtDateStart;
        private C1.Win.C1Command.C1DockingTabPage tabCloseDay;
        private C1.Win.C1Command.C1DockingTabPage tabReport;
        private System.Windows.Forms.Panel pnReport;
        private C1.Win.C1SplitContainer.C1SplitContainer c1SplitContainer1;
        private C1.Win.C1SplitContainer.C1SplitterPanel c1SplitterPanel1;
        private C1.Win.C1SplitContainer.C1SplitterPanel c1SplitterPanel2;
        private C1.Win.C1SplitContainer.C1SplitContainer c1SplitContainer2;
        private C1.Win.C1SplitContainer.C1SplitterPanel c1SplitterPanel3;
        private C1.Win.C1SplitContainer.C1SplitterPanel c1SplitterPanel4;
        private System.Windows.Forms.Panel pnReportItem;
        private System.Windows.Forms.Panel pnReportCri;
        private System.Windows.Forms.Panel pnReportView;
        private C1.Win.C1Command.C1DockingTab c1DockingTab1;
        private C1.Win.C1Command.C1DockingTabPage tabCloseDayToday;
        private System.Windows.Forms.Panel panel1;
        private C1.Win.C1Command.C1DockingTabPage tabCloseDayView;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private C1.Win.C1Input.C1DateEdit c1DateEdit1;
        private System.Windows.Forms.Label label1;
    }
}