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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tC = new C1.Win.C1Command.C1DockingTab();
            this.tabWaiting = new C1.Win.C1Command.C1DockingTabPage();
            this.tabDiag = new C1.Win.C1Command.C1DockingTabPage();
            this.pnDiag = new System.Windows.Forms.Panel();
            this.tabFinish = new C1.Win.C1Command.C1DockingTabPage();
            this.pnFinish = new System.Windows.Forms.Panel();
            this.tabLab = new C1.Win.C1Command.C1DockingTabPage();
            this.pnLab = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLabResultSearch = new C1.Win.C1Input.C1Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLabResultDate = new C1.Win.C1Input.C1DateEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLabResultHn = new C1.Win.C1Input.C1TextBox();
            this.tabSearch = new C1.Win.C1Command.C1DockingTabPage();
            this.pnSearch = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chkLabFormA = new C1.Win.C1Input.C1CheckBox();
            this.btnSearch = new C1.Win.C1Input.C1Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDateStart = new C1.Win.C1Input.C1DateEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSearch = new C1.Win.C1Input.C1TextBox();
            this.sB = new System.Windows.Forms.StatusStrip();
            this.sB1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnVisitBsp = new System.Windows.Forms.Panel();
            this.pnQue = new System.Windows.Forms.Panel();
            this.label70 = new System.Windows.Forms.Label();
            this.cboVisitBsp = new C1.Win.C1Input.C1ComboBox();
            this.chkAll = new C1.Win.C1Input.C1CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tC)).BeginInit();
            this.tC.SuspendLayout();
            this.tabWaiting.SuspendLayout();
            this.tabDiag.SuspendLayout();
            this.tabFinish.SuspendLayout();
            this.tabLab.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnLabResultSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLabResultDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLabResultHn)).BeginInit();
            this.tabSearch.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkLabFormA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).BeginInit();
            this.sB.SuspendLayout();
            this.pnVisitBsp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboVisitBsp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll)).BeginInit();
            this.SuspendLayout();
            // 
            // theme1
            // 
            this.theme1.Theme = "Office2013Red";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.tC);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1071, 678);
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
            this.tC.Controls.Add(this.tabLab);
            this.tC.Controls.Add(this.tabSearch);
            this.tC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tC.HotTrack = true;
            this.tC.Location = new System.Drawing.Point(0, 0);
            this.tC.Name = "tC";
            this.tC.SelectedIndex = 3;
            this.tC.Size = new System.Drawing.Size(1071, 678);
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
            this.tabWaiting.Controls.Add(this.pnVisitBsp);
            this.tabWaiting.Location = new System.Drawing.Point(1, 24);
            this.tabWaiting.Name = "tabWaiting";
            this.tabWaiting.Size = new System.Drawing.Size(1069, 653);
            this.tabWaiting.TabIndex = 0;
            this.tabWaiting.Text = "waiting in queue";
            // 
            // tabDiag
            // 
            this.tabDiag.Controls.Add(this.pnDiag);
            this.tabDiag.Location = new System.Drawing.Point(1, 24);
            this.tabDiag.Name = "tabDiag";
            this.tabDiag.Size = new System.Drawing.Size(1069, 653);
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
            this.pnDiag.Size = new System.Drawing.Size(1069, 653);
            this.pnDiag.TabIndex = 0;
            this.theme1.SetTheme(this.pnDiag, "(default)");
            // 
            // tabFinish
            // 
            this.tabFinish.Controls.Add(this.pnFinish);
            this.tabFinish.Location = new System.Drawing.Point(1, 24);
            this.tabFinish.Name = "tabFinish";
            this.tabFinish.Size = new System.Drawing.Size(1069, 653);
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
            this.pnFinish.Size = new System.Drawing.Size(1069, 653);
            this.pnFinish.TabIndex = 0;
            this.theme1.SetTheme(this.pnFinish, "(default)");
            // 
            // tabLab
            // 
            this.tabLab.Controls.Add(this.pnLab);
            this.tabLab.Controls.Add(this.panel2);
            this.tabLab.Location = new System.Drawing.Point(1, 24);
            this.tabLab.Name = "tabLab";
            this.tabLab.Size = new System.Drawing.Size(1069, 653);
            this.tabLab.TabIndex = 4;
            this.tabLab.Text = "Lab Result";
            // 
            // pnLab
            // 
            this.pnLab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnLab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnLab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnLab.Location = new System.Drawing.Point(0, 36);
            this.pnLab.Name = "pnLab";
            this.pnLab.Size = new System.Drawing.Size(1069, 617);
            this.pnLab.TabIndex = 3;
            this.theme1.SetTheme(this.pnLab, "(default)");
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel2.Controls.Add(this.btnLabResultSearch);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtLabResultDate);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtLabResultHn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1069, 36);
            this.panel2.TabIndex = 2;
            this.theme1.SetTheme(this.panel2, "(default)");
            // 
            // btnLabResultSearch
            // 
            this.btnLabResultSearch.Location = new System.Drawing.Point(488, 5);
            this.btnLabResultSearch.Name = "btnLabResultSearch";
            this.btnLabResultSearch.Size = new System.Drawing.Size(28, 23);
            this.btnLabResultSearch.TabIndex = 736;
            this.btnLabResultSearch.Text = "...";
            this.theme1.SetTheme(this.btnLabResultSearch, "(default)");
            this.btnLabResultSearch.UseVisualStyleBackColor = true;
            this.btnLabResultSearch.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label1.Location = new System.Drawing.Point(246, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 735;
            this.label1.Text = "Date Start :";
            this.theme1.SetTheme(this.label1, "(default)");
            // 
            // txtLabResultDate
            // 
            this.txtLabResultDate.AllowSpinLoop = false;
            this.txtLabResultDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // 
            // 
            this.txtLabResultDate.Calendar.ArrowColor = System.Drawing.Color.Black;
            this.txtLabResultDate.Calendar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtLabResultDate.Calendar.DayNamesFont = new System.Drawing.Font("Tahoma", 8F);
            this.txtLabResultDate.Calendar.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtLabResultDate.Calendar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.txtLabResultDate.Calendar.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(71)))), ((int)(((byte)(47)))));
            this.txtLabResultDate.Calendar.SelectionForeColor = System.Drawing.Color.White;
            this.txtLabResultDate.Calendar.TitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.txtLabResultDate.Calendar.TitleFont = new System.Drawing.Font("Tahoma", 8F);
            this.txtLabResultDate.Calendar.TitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.txtLabResultDate.Calendar.TodayBorderColor = System.Drawing.Color.White;
            this.txtLabResultDate.Calendar.TrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtLabResultDate.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.txtLabResultDate.Culture = 1054;
            this.txtLabResultDate.CurrentTimeZone = false;
            this.txtLabResultDate.DateTimeInput = false;
            this.txtLabResultDate.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtLabResultDate.DisplayFormat.CustomFormat = "dd-MM-yyyy";
            this.txtLabResultDate.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate;
            this.txtLabResultDate.DisplayFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) 
            | C1.Win.C1Input.FormatInfoInheritFlags.CalendarType)));
            this.txtLabResultDate.EditFormat.CustomFormat = "dd-MM-yyyy";
            this.txtLabResultDate.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate;
            this.txtLabResultDate.EditFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.NullText | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd) 
            | C1.Win.C1Input.FormatInfoInheritFlags.CalendarType)));
            this.txtLabResultDate.EmptyAsNull = true;
            this.txtLabResultDate.GMTOffset = System.TimeSpan.Parse("00:00:00");
            this.txtLabResultDate.ImagePadding = new System.Windows.Forms.Padding(0);
            this.txtLabResultDate.Location = new System.Drawing.Point(325, 8);
            this.txtLabResultDate.Name = "txtLabResultDate";
            this.txtLabResultDate.ParseInfo.EmptyAsNull = false;
            this.txtLabResultDate.ParseInfo.Inherit = ((C1.Win.C1Input.ParseInfoInheritFlags)(((((((C1.Win.C1Input.ParseInfoInheritFlags.CaseSensitive | C1.Win.C1Input.ParseInfoInheritFlags.FormatType) 
            | C1.Win.C1Input.ParseInfoInheritFlags.CustomFormat) 
            | C1.Win.C1Input.ParseInfoInheritFlags.NullText) 
            | C1.Win.C1Input.ParseInfoInheritFlags.ErrorMessage) 
            | C1.Win.C1Input.ParseInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.ParseInfoInheritFlags.TrimEnd)));
            this.txtLabResultDate.Size = new System.Drawing.Size(142, 18);
            this.txtLabResultDate.TabIndex = 734;
            this.txtLabResultDate.Tag = null;
            this.theme1.SetTheme(this.txtLabResultDate, "(default)");
            this.txtLabResultDate.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label2.Location = new System.Drawing.Point(7, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 16);
            this.label2.TabIndex = 733;
            this.label2.Text = "key :";
            this.theme1.SetTheme(this.label2, "(default)");
            // 
            // txtLabResultHn
            // 
            this.txtLabResultHn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLabResultHn.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtLabResultHn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtLabResultHn.Location = new System.Drawing.Point(77, 6);
            this.txtLabResultHn.Name = "txtLabResultHn";
            this.txtLabResultHn.Size = new System.Drawing.Size(157, 20);
            this.txtLabResultHn.TabIndex = 732;
            this.txtLabResultHn.Tag = null;
            this.theme1.SetTheme(this.txtLabResultHn, "(default)");
            this.txtLabResultHn.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // tabSearch
            // 
            this.tabSearch.Controls.Add(this.pnSearch);
            this.tabSearch.Controls.Add(this.panel3);
            this.tabSearch.Location = new System.Drawing.Point(1, 24);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.Size = new System.Drawing.Size(1069, 653);
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
            this.pnSearch.Size = new System.Drawing.Size(1069, 617);
            this.pnSearch.TabIndex = 2;
            this.theme1.SetTheme(this.pnSearch, "(default)");
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel3.Controls.Add(this.chkLabFormA);
            this.panel3.Controls.Add(this.btnSearch);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.txtDateStart);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txtSearch);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1069, 36);
            this.panel3.TabIndex = 1;
            this.theme1.SetTheme(this.panel3, "(default)");
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
            // pnVisitBsp
            // 
            this.pnVisitBsp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnVisitBsp.Controls.Add(this.chkAll);
            this.pnVisitBsp.Controls.Add(this.label70);
            this.pnVisitBsp.Controls.Add(this.cboVisitBsp);
            this.pnVisitBsp.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnVisitBsp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnVisitBsp.Location = new System.Drawing.Point(0, 0);
            this.pnVisitBsp.Name = "pnVisitBsp";
            this.pnVisitBsp.Size = new System.Drawing.Size(1069, 29);
            this.pnVisitBsp.TabIndex = 0;
            this.theme1.SetTheme(this.pnVisitBsp, "(default)");
            // 
            // pnQue
            // 
            this.pnQue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnQue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnQue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnQue.Location = new System.Drawing.Point(0, 29);
            this.pnQue.Name = "pnQue";
            this.pnQue.Size = new System.Drawing.Size(1069, 624);
            this.pnQue.TabIndex = 0;
            this.theme1.SetTheme(this.pnQue, "(default)");
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label70.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label70.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label70.Location = new System.Drawing.Point(12, 5);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(55, 16);
            this.label70.TabIndex = 632;
            this.label70.Text = "Station :";
            this.theme1.SetTheme(this.label70, "(default)");
            // 
            // cboVisitBsp
            // 
            this.cboVisitBsp.AllowSpinLoop = false;
            this.cboVisitBsp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cboVisitBsp.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.cboVisitBsp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboVisitBsp.GapHeight = 0;
            this.cboVisitBsp.ImagePadding = new System.Windows.Forms.Padding(0);
            this.cboVisitBsp.ItemsDisplayMember = "";
            this.cboVisitBsp.ItemsValueMember = "";
            this.cboVisitBsp.Location = new System.Drawing.Point(92, 3);
            this.cboVisitBsp.Name = "cboVisitBsp";
            this.cboVisitBsp.Size = new System.Drawing.Size(250, 20);
            this.cboVisitBsp.Style.DropDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cboVisitBsp.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro;
            this.cboVisitBsp.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboVisitBsp.TabIndex = 631;
            this.cboVisitBsp.Tag = null;
            this.theme1.SetTheme(this.cboVisitBsp, "(default)");
            this.cboVisitBsp.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // chkAll
            // 
            this.chkAll.BackColor = System.Drawing.Color.Transparent;
            this.chkAll.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.chkAll.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.chkAll.Location = new System.Drawing.Point(348, 3);
            this.chkAll.Name = "chkAll";
            this.chkAll.Padding = new System.Windows.Forms.Padding(4, 1, 1, 1);
            this.chkAll.Size = new System.Drawing.Size(88, 24);
            this.chkAll.TabIndex = 633;
            this.chkAll.Text = "All";
            this.theme1.SetTheme(this.chkAll, "(default)");
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.Value = null;
            this.chkAll.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // FrmNurseView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 700);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sB);
            this.Name = "FrmNurseView";
            this.Text = "FrmNurseView";
            this.Load += new System.EventHandler(this.FrmNurseView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tC)).EndInit();
            this.tC.ResumeLayout(false);
            this.tabWaiting.ResumeLayout(false);
            this.tabDiag.ResumeLayout(false);
            this.tabFinish.ResumeLayout(false);
            this.tabLab.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnLabResultSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLabResultDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLabResultHn)).EndInit();
            this.tabSearch.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkLabFormA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).EndInit();
            this.sB.ResumeLayout(false);
            this.sB.PerformLayout();
            this.pnVisitBsp.ResumeLayout(false);
            this.pnVisitBsp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboVisitBsp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Themes.C1ThemeController theme1;
        private System.Windows.Forms.StatusStrip sB;
        private System.Windows.Forms.ToolStripStatusLabel sB1;
        private System.Windows.Forms.Panel panel1;
        private C1.Win.C1Command.C1DockingTab tC;
        private C1.Win.C1Command.C1DockingTabPage tabWaiting;
        private C1.Win.C1Command.C1DockingTabPage tabDiag;
        private C1.Win.C1Command.C1DockingTabPage tabFinish;
        private System.Windows.Forms.Panel pnDiag;
        private System.Windows.Forms.Panel pnFinish;
        private C1.Win.C1Command.C1DockingTabPage tabSearch;
        private C1.Win.C1Command.C1DockingTabPage tabLab;
        private System.Windows.Forms.Panel pnSearch;
        private System.Windows.Forms.Panel panel3;
        private C1.Win.C1Input.C1CheckBox chkLabFormA;
        private C1.Win.C1Input.C1Button btnSearch;
        private System.Windows.Forms.Label label11;
        private C1.Win.C1Input.C1DateEdit txtDateStart;
        private System.Windows.Forms.Label label4;
        private C1.Win.C1Input.C1TextBox txtSearch;
        private System.Windows.Forms.Panel pnLab;
        private System.Windows.Forms.Panel panel2;
        private C1.Win.C1Input.C1Button btnLabResultSearch;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1Input.C1DateEdit txtLabResultDate;
        private System.Windows.Forms.Label label2;
        private C1.Win.C1Input.C1TextBox txtLabResultHn;
        private System.Windows.Forms.Panel pnQue;
        private System.Windows.Forms.Panel pnVisitBsp;
        private System.Windows.Forms.Label label70;
        private C1.Win.C1Input.C1ComboBox cboVisitBsp;
        private C1.Win.C1Input.C1CheckBox chkAll;
    }
}