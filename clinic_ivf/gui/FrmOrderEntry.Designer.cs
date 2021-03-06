﻿namespace clinic_ivf.gui
{
    partial class FrmOrderEntry
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.c1TextBox4 = new C1.Win.C1Input.C1TextBox();
            this.c1TextBox3 = new C1.Win.C1Input.C1TextBox();
            this.c1TextBox2 = new C1.Win.C1Input.C1TextBox();
            this.c1TextBox1 = new C1.Win.C1Input.C1TextBox();
            this.chkChronic = new C1.Win.C1Input.C1CheckBox();
            this.chkDenyAllergy = new C1.Win.C1Input.C1CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.txtPttName = new C1.Win.C1Input.C1TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPttNameE = new C1.Win.C1Input.C1TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHn = new C1.Win.C1Input.C1TextBox();
            this.gbSelect = new System.Windows.Forms.GroupBox();
            this.tC = new C1.Win.C1Command.C1DockingTab();
            this.tabDrug = new C1.Win.C1Command.C1DockingTabPage();
            this.tabLab = new C1.Win.C1Command.C1DockingTabPage();
            this.tabApp = new C1.Win.C1Command.C1DockingTabPage();
            this.tabCert = new C1.Win.C1Command.C1DockingTabPage();
            this.gbOrder = new System.Windows.Forms.GroupBox();
            this.sB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1TextBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1TextBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1TextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1TextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkChronic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDenyAllergy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPttName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPttNameE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHn)).BeginInit();
            this.gbSelect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tC)).BeginInit();
            this.tC.SuspendLayout();
            this.SuspendLayout();
            // 
            // sB
            // 
            this.sB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sB1});
            this.sB.Location = new System.Drawing.Point(0, 663);
            this.sB.Name = "sB";
            this.sB.Size = new System.Drawing.Size(917, 22);
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
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.c1TextBox4);
            this.groupBox1.Controls.Add(this.c1TextBox3);
            this.groupBox1.Controls.Add(this.c1TextBox2);
            this.groupBox1.Controls.Add(this.c1TextBox1);
            this.groupBox1.Controls.Add(this.chkChronic);
            this.groupBox1.Controls.Add(this.chkDenyAllergy);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label54);
            this.groupBox1.Controls.Add(this.txtPttName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPttNameE);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtHn);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(917, 99);
            this.groupBox1.TabIndex = 528;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Patient";
            this.theme1.SetTheme(this.groupBox1, "(default)");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label2.Location = new System.Drawing.Point(14, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 16);
            this.label2.TabIndex = 691;
            this.label2.Text = "VN :";
            this.theme1.SetTheme(this.label2, "(default)");
            // 
            // c1TextBox4
            // 
            this.c1TextBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.c1TextBox4.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.c1TextBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.c1TextBox4.Location = new System.Drawing.Point(53, 49);
            this.c1TextBox4.Name = "c1TextBox4";
            this.c1TextBox4.Size = new System.Drawing.Size(146, 24);
            this.c1TextBox4.TabIndex = 690;
            this.c1TextBox4.Tag = null;
            this.theme1.SetTheme(this.c1TextBox4, "(default)");
            this.c1TextBox4.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // c1TextBox3
            // 
            this.c1TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.c1TextBox3.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.c1TextBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.c1TextBox3.Location = new System.Drawing.Point(585, 65);
            this.c1TextBox3.Name = "c1TextBox3";
            this.c1TextBox3.Size = new System.Drawing.Size(73, 20);
            this.c1TextBox3.TabIndex = 689;
            this.c1TextBox3.Tag = null;
            this.theme1.SetTheme(this.c1TextBox3, "(default)");
            this.c1TextBox3.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // c1TextBox2
            // 
            this.c1TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.c1TextBox2.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.c1TextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.c1TextBox2.Location = new System.Drawing.Point(713, 41);
            this.c1TextBox2.Name = "c1TextBox2";
            this.c1TextBox2.Size = new System.Drawing.Size(107, 20);
            this.c1TextBox2.TabIndex = 688;
            this.c1TextBox2.Tag = null;
            this.theme1.SetTheme(this.c1TextBox2, "(default)");
            this.c1TextBox2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // c1TextBox1
            // 
            this.c1TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.c1TextBox1.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.c1TextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.c1TextBox1.Location = new System.Drawing.Point(713, 20);
            this.c1TextBox1.Name = "c1TextBox1";
            this.c1TextBox1.Size = new System.Drawing.Size(107, 20);
            this.c1TextBox1.TabIndex = 687;
            this.c1TextBox1.Tag = null;
            this.theme1.SetTheme(this.c1TextBox1, "(default)");
            this.c1TextBox1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // chkChronic
            // 
            this.chkChronic.BackColor = System.Drawing.Color.Transparent;
            this.chkChronic.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.chkChronic.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkChronic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkChronic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkChronic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.chkChronic.Location = new System.Drawing.Point(287, 67);
            this.chkChronic.Name = "chkChronic";
            this.chkChronic.Padding = new System.Windows.Forms.Padding(4, 1, 1, 1);
            this.chkChronic.Size = new System.Drawing.Size(88, 24);
            this.chkChronic.TabIndex = 685;
            this.chkChronic.Text = "มีโรคเรื้อรัง";
            this.theme1.SetTheme(this.chkChronic, "(default)");
            this.chkChronic.UseVisualStyleBackColor = true;
            this.chkChronic.Value = null;
            this.chkChronic.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // chkDenyAllergy
            // 
            this.chkDenyAllergy.BackColor = System.Drawing.Color.Transparent;
            this.chkDenyAllergy.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.chkDenyAllergy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkDenyAllergy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkDenyAllergy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDenyAllergy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.chkDenyAllergy.Location = new System.Drawing.Point(388, 67);
            this.chkDenyAllergy.Name = "chkDenyAllergy";
            this.chkDenyAllergy.Padding = new System.Windows.Forms.Padding(4, 1, 1, 1);
            this.chkDenyAllergy.Size = new System.Drawing.Size(104, 24);
            this.chkDenyAllergy.TabIndex = 684;
            this.chkDenyAllergy.Text = "ปฎิเสธการแพ้ยา";
            this.theme1.SetTheme(this.chkDenyAllergy, "(default)");
            this.chkDenyAllergy.UseVisualStyleBackColor = true;
            this.chkDenyAllergy.Value = null;
            this.chkDenyAllergy.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label10.Location = new System.Drawing.Point(498, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 16);
            this.label10.TabIndex = 683;
            this.label10.Text = "Blood Group :";
            this.theme1.SetTheme(this.label10, "(default)");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label5.Location = new System.Drawing.Point(664, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 16);
            this.label5.TabIndex = 682;
            this.label5.Text = "Sex :";
            this.theme1.SetTheme(this.label5, "(default)");
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label11.Location = new System.Drawing.Point(664, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 16);
            this.label11.TabIndex = 679;
            this.label11.Text = "DOB :";
            this.theme1.SetTheme(this.label11, "(default)");
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label54.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label54.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label54.Location = new System.Drawing.Point(205, 43);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(79, 16);
            this.label54.TabIndex = 678;
            this.label54.Text = "Thai/China :";
            this.theme1.SetTheme(this.label54, "(default)");
            // 
            // txtPttName
            // 
            this.txtPttName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPttName.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtPttName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtPttName.Location = new System.Drawing.Point(287, 41);
            this.txtPttName.Name = "txtPttName";
            this.txtPttName.Size = new System.Drawing.Size(371, 20);
            this.txtPttName.TabIndex = 676;
            this.txtPttName.Tag = null;
            this.theme1.SetTheme(this.txtPttName, "(default)");
            this.txtPttName.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label1.Location = new System.Drawing.Point(205, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 675;
            this.label1.Text = "Name :";
            this.theme1.SetTheme(this.label1, "(default)");
            // 
            // txtPttNameE
            // 
            this.txtPttNameE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPttNameE.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtPttNameE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtPttNameE.Location = new System.Drawing.Point(287, 20);
            this.txtPttNameE.Name = "txtPttNameE";
            this.txtPttNameE.Size = new System.Drawing.Size(371, 20);
            this.txtPttNameE.TabIndex = 672;
            this.txtPttNameE.Tag = null;
            this.theme1.SetTheme(this.txtPttNameE, "(default)");
            this.txtPttNameE.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label4.Location = new System.Drawing.Point(11, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 16);
            this.label4.TabIndex = 622;
            this.label4.Text = "HN :";
            this.theme1.SetTheme(this.label4, "(default)");
            // 
            // txtHn
            // 
            this.txtHn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHn.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtHn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtHn.Location = new System.Drawing.Point(52, 19);
            this.txtHn.Name = "txtHn";
            this.txtHn.Size = new System.Drawing.Size(146, 24);
            this.txtHn.TabIndex = 621;
            this.txtHn.Tag = null;
            this.theme1.SetTheme(this.txtHn, "(default)");
            this.txtHn.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // gbSelect
            // 
            this.gbSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gbSelect.Controls.Add(this.tC);
            this.gbSelect.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbSelect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.gbSelect.Location = new System.Drawing.Point(0, 99);
            this.gbSelect.Name = "gbSelect";
            this.gbSelect.Size = new System.Drawing.Size(917, 353);
            this.gbSelect.TabIndex = 529;
            this.gbSelect.TabStop = false;
            this.gbSelect.Text = "groupBox2";
            this.theme1.SetTheme(this.gbSelect, "(default)");
            // 
            // tC
            // 
            this.tC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tC.Controls.Add(this.tabDrug);
            this.tC.Controls.Add(this.tabLab);
            this.tC.Controls.Add(this.tabApp);
            this.tC.Controls.Add(this.tabCert);
            this.tC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tC.HotTrack = true;
            this.tC.Location = new System.Drawing.Point(3, 16);
            this.tC.Name = "tC";
            this.tC.SelectedIndex = 2;
            this.tC.Size = new System.Drawing.Size(911, 334);
            this.tC.TabIndex = 0;
            this.tC.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Fit;
            this.tC.TabsShowFocusCues = false;
            this.tC.TabsSpacing = 2;
            this.tC.TabStyle = C1.Win.C1Command.TabStyleEnum.Office2007;
            this.theme1.SetTheme(this.tC, "(default)");
            // 
            // tabDrug
            // 
            this.tabDrug.Location = new System.Drawing.Point(1, 24);
            this.tabDrug.Name = "tabDrug";
            this.tabDrug.Size = new System.Drawing.Size(909, 309);
            this.tabDrug.TabIndex = 0;
            this.tabDrug.Text = "Medicine &Supplies";
            // 
            // tabLab
            // 
            this.tabLab.Location = new System.Drawing.Point(1, 24);
            this.tabLab.Name = "tabLab";
            this.tabLab.Size = new System.Drawing.Size(909, 309);
            this.tabLab.TabIndex = 1;
            this.tabLab.Text = "Order LAB";
            // 
            // tabApp
            // 
            this.tabApp.Location = new System.Drawing.Point(1, 24);
            this.tabApp.Name = "tabApp";
            this.tabApp.Size = new System.Drawing.Size(909, 309);
            this.tabApp.TabIndex = 2;
            this.tabApp.Text = "Appointment";
            // 
            // tabCert
            // 
            this.tabCert.Location = new System.Drawing.Point(1, 24);
            this.tabCert.Name = "tabCert";
            this.tabCert.Size = new System.Drawing.Size(909, 309);
            this.tabCert.TabIndex = 3;
            this.tabCert.Text = "Medical Certificate";
            // 
            // gbOrder
            // 
            this.gbOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gbOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.gbOrder.Location = new System.Drawing.Point(0, 452);
            this.gbOrder.Name = "gbOrder";
            this.gbOrder.Size = new System.Drawing.Size(917, 211);
            this.gbOrder.TabIndex = 530;
            this.gbOrder.TabStop = false;
            this.gbOrder.Text = "groupBox3";
            this.theme1.SetTheme(this.gbOrder, "(default)");
            // 
            // FrmOrderEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 685);
            this.Controls.Add(this.gbOrder);
            this.Controls.Add(this.gbSelect);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.sB);
            this.Name = "FrmOrderEntry";
            this.Text = "FrmOrderEntry";
            this.sB.ResumeLayout(false);
            this.sB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1TextBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1TextBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1TextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1TextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkChronic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDenyAllergy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPttName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPttNameE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHn)).EndInit();
            this.gbSelect.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tC)).EndInit();
            this.tC.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip sB;
        private System.Windows.Forms.ToolStripStatusLabel sB1;
        private C1.Win.C1Themes.C1ThemeController theme1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private C1.Win.C1Input.C1TextBox txtHn;
        private System.Windows.Forms.Label label54;
        private C1.Win.C1Input.C1TextBox txtPttName;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1Input.C1TextBox txtPttNameE;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private C1.Win.C1Input.C1CheckBox chkChronic;
        private C1.Win.C1Input.C1CheckBox chkDenyAllergy;
        private C1.Win.C1Input.C1TextBox c1TextBox3;
        private C1.Win.C1Input.C1TextBox c1TextBox2;
        private C1.Win.C1Input.C1TextBox c1TextBox1;
        private System.Windows.Forms.Label label2;
        private C1.Win.C1Input.C1TextBox c1TextBox4;
        private System.Windows.Forms.GroupBox gbSelect;
        private System.Windows.Forms.GroupBox gbOrder;
        private C1.Win.C1Command.C1DockingTab tC;
        private C1.Win.C1Command.C1DockingTabPage tabDrug;
        private C1.Win.C1Command.C1DockingTabPage tabLab;
        private C1.Win.C1Command.C1DockingTabPage tabApp;
        private C1.Win.C1Command.C1DockingTabPage tabCert;
    }
}