namespace clinic_ivf.gui
{
    partial class FrmCashAccount
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
            this.tabCash = new C1.Win.C1Command.C1DockingTabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCaPasswordVoid = new C1.Win.C1Input.C1TextBox();
            this.chkCaVoid = new C1.Win.C1Input.C1CheckBox();
            this.btnCaVoid = new C1.Win.C1Input.C1Button();
            this.btnCaSave = new C1.Win.C1Input.C1Button();
            this.btnCaNew = new C1.Win.C1Input.C1Button();
            this.btnCaEdit = new C1.Win.C1Input.C1Button();
            this.txtCaRemark = new C1.Win.C1Input.C1TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCaNameT = new C1.Win.C1Input.C1TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCaID = new C1.Win.C1Input.C1TextBox();
            this.pnCash = new System.Windows.Forms.Panel();
            this.tabCredit = new C1.Win.C1Command.C1DockingTabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtCrPasswordVoid = new C1.Win.C1Input.C1TextBox();
            this.chkCrVoid = new C1.Win.C1Input.C1CheckBox();
            this.btnCrVoid = new C1.Win.C1Input.C1Button();
            this.btnCrSave = new C1.Win.C1Input.C1Button();
            this.btnCrNew = new C1.Win.C1Input.C1Button();
            this.btnCrEdit = new C1.Win.C1Input.C1Button();
            this.txtCrRemark = new C1.Win.C1Input.C1TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCrNameT = new C1.Win.C1Input.C1TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCrID = new C1.Win.C1Input.C1TextBox();
            this.pnCredit = new System.Windows.Forms.Panel();
            this.sB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tC)).BeginInit();
            this.tC.SuspendLayout();
            this.tabCash.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCaPasswordVoid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCaVoid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCaVoid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCaSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCaNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCaEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCaRemark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCaNameT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCaID)).BeginInit();
            this.tabCredit.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrPasswordVoid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCrVoid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCrVoid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCrSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCrNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCrEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrRemark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrNameT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrID)).BeginInit();
            this.SuspendLayout();
            // 
            // sB
            // 
            this.sB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sB1});
            this.sB.Location = new System.Drawing.Point(0, 604);
            this.sB.Name = "sB";
            this.sB.Size = new System.Drawing.Size(942, 22);
            this.sB.TabIndex = 11;
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
            this.tC.Controls.Add(this.tabCash);
            this.tC.Controls.Add(this.tabCredit);
            this.tC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tC.HotTrack = true;
            this.tC.Location = new System.Drawing.Point(0, 0);
            this.tC.Name = "tC";
            this.tC.Size = new System.Drawing.Size(942, 604);
            this.tC.TabIndex = 12;
            this.tC.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Fit;
            this.tC.TabsShowFocusCues = false;
            this.tC.TabsSpacing = 2;
            this.tC.TabStyle = C1.Win.C1Command.TabStyleEnum.Office2007;
            this.theme1.SetTheme(this.tC, "(default)");
            // 
            // tabCash
            // 
            this.tabCash.Controls.Add(this.panel1);
            this.tabCash.Controls.Add(this.pnCash);
            this.tabCash.Location = new System.Drawing.Point(1, 24);
            this.tabCash.Name = "tabCash";
            this.tabCash.Size = new System.Drawing.Size(940, 579);
            this.tabCash.TabIndex = 0;
            this.tabCash.Text = "Cash Account";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.txtCaPasswordVoid);
            this.panel1.Controls.Add(this.chkCaVoid);
            this.panel1.Controls.Add(this.btnCaVoid);
            this.panel1.Controls.Add(this.btnCaSave);
            this.panel1.Controls.Add(this.btnCaNew);
            this.panel1.Controls.Add(this.btnCaEdit);
            this.panel1.Controls.Add(this.txtCaRemark);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtCaNameT);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtCaID);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel1.Location = new System.Drawing.Point(469, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(471, 579);
            this.panel1.TabIndex = 1;
            this.theme1.SetTheme(this.panel1, "(default)");
            // 
            // txtCaPasswordVoid
            // 
            this.txtCaPasswordVoid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCaPasswordVoid.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtCaPasswordVoid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtCaPasswordVoid.Location = new System.Drawing.Point(275, 198);
            this.txtCaPasswordVoid.Name = "txtCaPasswordVoid";
            this.txtCaPasswordVoid.PasswordChar = '*';
            this.txtCaPasswordVoid.Size = new System.Drawing.Size(78, 20);
            this.txtCaPasswordVoid.TabIndex = 271;
            this.txtCaPasswordVoid.Tag = null;
            this.theme1.SetTheme(this.txtCaPasswordVoid, "(default)");
            this.txtCaPasswordVoid.Visible = false;
            this.txtCaPasswordVoid.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // chkCaVoid
            // 
            this.chkCaVoid.BackColor = System.Drawing.Color.Transparent;
            this.chkCaVoid.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.chkCaVoid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkCaVoid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkCaVoid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.chkCaVoid.Location = new System.Drawing.Point(264, 168);
            this.chkCaVoid.Name = "chkCaVoid";
            this.chkCaVoid.Padding = new System.Windows.Forms.Padding(4, 1, 1, 1);
            this.chkCaVoid.Size = new System.Drawing.Size(155, 24);
            this.chkCaVoid.TabIndex = 270;
            this.chkCaVoid.Text = "ต้องการยกเลิกรายการ";
            this.theme1.SetTheme(this.chkCaVoid, "(default)");
            this.chkCaVoid.UseVisualStyleBackColor = true;
            this.chkCaVoid.Value = null;
            this.chkCaVoid.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // btnCaVoid
            // 
            this.btnCaVoid.Image = global::clinic_ivf.Properties.Resources.trash24;
            this.btnCaVoid.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCaVoid.Location = new System.Drawing.Point(425, 179);
            this.btnCaVoid.Name = "btnCaVoid";
            this.btnCaVoid.Size = new System.Drawing.Size(83, 39);
            this.btnCaVoid.TabIndex = 269;
            this.btnCaVoid.Text = "ยกเลิกช้อมูล";
            this.btnCaVoid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.theme1.SetTheme(this.btnCaVoid, "(default)");
            this.btnCaVoid.UseVisualStyleBackColor = true;
            this.btnCaVoid.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // btnCaSave
            // 
            this.btnCaSave.Image = global::clinic_ivf.Properties.Resources.accept_database24;
            this.btnCaSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCaSave.Location = new System.Drawing.Point(425, 223);
            this.btnCaSave.Name = "btnCaSave";
            this.btnCaSave.Size = new System.Drawing.Size(83, 39);
            this.btnCaSave.TabIndex = 268;
            this.btnCaSave.Text = "บันทึกช้อมูล";
            this.btnCaSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.theme1.SetTheme(this.btnCaSave, "(default)");
            this.btnCaSave.UseVisualStyleBackColor = true;
            this.btnCaSave.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // btnCaNew
            // 
            this.btnCaNew.Image = global::clinic_ivf.Properties.Resources.custom_reports24;
            this.btnCaNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCaNew.Location = new System.Drawing.Point(425, 24);
            this.btnCaNew.Name = "btnCaNew";
            this.btnCaNew.Size = new System.Drawing.Size(83, 39);
            this.btnCaNew.TabIndex = 267;
            this.btnCaNew.Text = "เพิ่มช้อมูล";
            this.btnCaNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.theme1.SetTheme(this.btnCaNew, "(default)");
            this.btnCaNew.UseVisualStyleBackColor = true;
            this.btnCaNew.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // btnCaEdit
            // 
            this.btnCaEdit.Image = global::clinic_ivf.Properties.Resources.lock24;
            this.btnCaEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCaEdit.Location = new System.Drawing.Point(425, 69);
            this.btnCaEdit.Name = "btnCaEdit";
            this.btnCaEdit.Size = new System.Drawing.Size(83, 39);
            this.btnCaEdit.TabIndex = 266;
            this.btnCaEdit.Text = "แก้ไขช้อมูล";
            this.btnCaEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.theme1.SetTheme(this.btnCaEdit, "(default)");
            this.btnCaEdit.UseVisualStyleBackColor = true;
            this.btnCaEdit.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // txtCaRemark
            // 
            this.txtCaRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCaRemark.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtCaRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtCaRemark.Location = new System.Drawing.Point(123, 104);
            this.txtCaRemark.Name = "txtCaRemark";
            this.txtCaRemark.Size = new System.Drawing.Size(207, 20);
            this.txtCaRemark.TabIndex = 265;
            this.txtCaRemark.Tag = null;
            this.theme1.SetTheme(this.txtCaRemark, "(default)");
            this.txtCaRemark.Visible = false;
            this.txtCaRemark.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label3.Location = new System.Drawing.Point(26, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 264;
            this.label3.Text = "หมายเหตุ :";
            this.theme1.SetTheme(this.label3, "(default)");
            this.label3.Visible = false;
            // 
            // txtCaNameT
            // 
            this.txtCaNameT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCaNameT.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtCaNameT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtCaNameT.Location = new System.Drawing.Point(123, 78);
            this.txtCaNameT.Name = "txtCaNameT";
            this.txtCaNameT.Size = new System.Drawing.Size(207, 20);
            this.txtCaNameT.TabIndex = 263;
            this.txtCaNameT.Tag = null;
            this.theme1.SetTheme(this.txtCaNameT, "(default)");
            this.txtCaNameT.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label2.Location = new System.Drawing.Point(26, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 262;
            this.label2.Text = "ชื่อ Cash :";
            this.theme1.SetTheme(this.label2, "(default)");
            // 
            // txtCaID
            // 
            this.txtCaID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCaID.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtCaID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtCaID.Location = new System.Drawing.Point(336, 18);
            this.txtCaID.Name = "txtCaID";
            this.txtCaID.Size = new System.Drawing.Size(30, 20);
            this.txtCaID.TabIndex = 261;
            this.txtCaID.Tag = null;
            this.theme1.SetTheme(this.txtCaID, "(default)");
            this.txtCaID.Visible = false;
            this.txtCaID.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // pnCash
            // 
            this.pnCash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnCash.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnCash.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnCash.Location = new System.Drawing.Point(0, 0);
            this.pnCash.Name = "pnCash";
            this.pnCash.Size = new System.Drawing.Size(469, 579);
            this.pnCash.TabIndex = 0;
            this.theme1.SetTheme(this.pnCash, "(default)");
            // 
            // tabCredit
            // 
            this.tabCredit.Controls.Add(this.panel2);
            this.tabCredit.Controls.Add(this.pnCredit);
            this.tabCredit.Location = new System.Drawing.Point(1, 24);
            this.tabCredit.Name = "tabCredit";
            this.tabCredit.Size = new System.Drawing.Size(940, 579);
            this.tabCredit.TabIndex = 1;
            this.tabCredit.Text = "Credit Account";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel2.Controls.Add(this.txtCrPasswordVoid);
            this.panel2.Controls.Add(this.chkCrVoid);
            this.panel2.Controls.Add(this.btnCrVoid);
            this.panel2.Controls.Add(this.btnCrSave);
            this.panel2.Controls.Add(this.btnCrNew);
            this.panel2.Controls.Add(this.btnCrEdit);
            this.panel2.Controls.Add(this.txtCrRemark);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtCrNameT);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtCrID);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel2.Location = new System.Drawing.Point(469, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(471, 579);
            this.panel2.TabIndex = 2;
            this.theme1.SetTheme(this.panel2, "(default)");
            // 
            // txtCrPasswordVoid
            // 
            this.txtCrPasswordVoid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCrPasswordVoid.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtCrPasswordVoid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtCrPasswordVoid.Location = new System.Drawing.Point(274, 199);
            this.txtCrPasswordVoid.Name = "txtCrPasswordVoid";
            this.txtCrPasswordVoid.PasswordChar = '*';
            this.txtCrPasswordVoid.Size = new System.Drawing.Size(78, 20);
            this.txtCrPasswordVoid.TabIndex = 271;
            this.txtCrPasswordVoid.Tag = null;
            this.theme1.SetTheme(this.txtCrPasswordVoid, "(default)");
            this.txtCrPasswordVoid.Visible = false;
            this.txtCrPasswordVoid.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // chkCrVoid
            // 
            this.chkCrVoid.BackColor = System.Drawing.Color.Transparent;
            this.chkCrVoid.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.chkCrVoid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkCrVoid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkCrVoid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.chkCrVoid.Location = new System.Drawing.Point(250, 169);
            this.chkCrVoid.Name = "chkCrVoid";
            this.chkCrVoid.Padding = new System.Windows.Forms.Padding(4, 1, 1, 1);
            this.chkCrVoid.Size = new System.Drawing.Size(155, 24);
            this.chkCrVoid.TabIndex = 270;
            this.chkCrVoid.Text = "ต้องการยกเลิกรายการ";
            this.theme1.SetTheme(this.chkCrVoid, "(default)");
            this.chkCrVoid.UseVisualStyleBackColor = true;
            this.chkCrVoid.Value = null;
            this.chkCrVoid.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // btnCrVoid
            // 
            this.btnCrVoid.Image = global::clinic_ivf.Properties.Resources.trash24;
            this.btnCrVoid.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCrVoid.Location = new System.Drawing.Point(411, 180);
            this.btnCrVoid.Name = "btnCrVoid";
            this.btnCrVoid.Size = new System.Drawing.Size(83, 39);
            this.btnCrVoid.TabIndex = 269;
            this.btnCrVoid.Text = "ยกเลิกช้อมูล";
            this.btnCrVoid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.theme1.SetTheme(this.btnCrVoid, "(default)");
            this.btnCrVoid.UseVisualStyleBackColor = true;
            this.btnCrVoid.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // btnCrSave
            // 
            this.btnCrSave.Image = global::clinic_ivf.Properties.Resources.accept_database24;
            this.btnCrSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCrSave.Location = new System.Drawing.Point(411, 224);
            this.btnCrSave.Name = "btnCrSave";
            this.btnCrSave.Size = new System.Drawing.Size(83, 39);
            this.btnCrSave.TabIndex = 268;
            this.btnCrSave.Text = "บันทึกช้อมูล";
            this.btnCrSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.theme1.SetTheme(this.btnCrSave, "(default)");
            this.btnCrSave.UseVisualStyleBackColor = true;
            this.btnCrSave.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // btnCrNew
            // 
            this.btnCrNew.Image = global::clinic_ivf.Properties.Resources.custom_reports24;
            this.btnCrNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCrNew.Location = new System.Drawing.Point(411, 25);
            this.btnCrNew.Name = "btnCrNew";
            this.btnCrNew.Size = new System.Drawing.Size(83, 39);
            this.btnCrNew.TabIndex = 267;
            this.btnCrNew.Text = "เพิ่มช้อมูล";
            this.btnCrNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.theme1.SetTheme(this.btnCrNew, "(default)");
            this.btnCrNew.UseVisualStyleBackColor = true;
            this.btnCrNew.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // btnCrEdit
            // 
            this.btnCrEdit.Image = global::clinic_ivf.Properties.Resources.lock24;
            this.btnCrEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCrEdit.Location = new System.Drawing.Point(411, 70);
            this.btnCrEdit.Name = "btnCrEdit";
            this.btnCrEdit.Size = new System.Drawing.Size(83, 39);
            this.btnCrEdit.TabIndex = 266;
            this.btnCrEdit.Text = "แก้ไขช้อมูล";
            this.btnCrEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.theme1.SetTheme(this.btnCrEdit, "(default)");
            this.btnCrEdit.UseVisualStyleBackColor = true;
            this.btnCrEdit.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // txtCrRemark
            // 
            this.txtCrRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCrRemark.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtCrRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtCrRemark.Location = new System.Drawing.Point(109, 105);
            this.txtCrRemark.Name = "txtCrRemark";
            this.txtCrRemark.Size = new System.Drawing.Size(207, 20);
            this.txtCrRemark.TabIndex = 265;
            this.txtCrRemark.Tag = null;
            this.theme1.SetTheme(this.txtCrRemark, "(default)");
            this.txtCrRemark.Visible = false;
            this.txtCrRemark.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label1.Location = new System.Drawing.Point(12, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 264;
            this.label1.Text = "หมายเหตุ :";
            this.theme1.SetTheme(this.label1, "(default)");
            this.label1.Visible = false;
            // 
            // txtCrNameT
            // 
            this.txtCrNameT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCrNameT.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtCrNameT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtCrNameT.Location = new System.Drawing.Point(109, 79);
            this.txtCrNameT.Name = "txtCrNameT";
            this.txtCrNameT.Size = new System.Drawing.Size(207, 20);
            this.txtCrNameT.TabIndex = 263;
            this.txtCrNameT.Tag = null;
            this.theme1.SetTheme(this.txtCrNameT, "(default)");
            this.txtCrNameT.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label4.Location = new System.Drawing.Point(12, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 16);
            this.label4.TabIndex = 262;
            this.label4.Text = "ชื่อ Credit :";
            this.theme1.SetTheme(this.label4, "(default)");
            // 
            // txtCrID
            // 
            this.txtCrID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCrID.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtCrID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtCrID.Location = new System.Drawing.Point(322, 19);
            this.txtCrID.Name = "txtCrID";
            this.txtCrID.Size = new System.Drawing.Size(30, 20);
            this.txtCrID.TabIndex = 261;
            this.txtCrID.Tag = null;
            this.theme1.SetTheme(this.txtCrID, "(default)");
            this.txtCrID.Visible = false;
            this.txtCrID.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // pnCredit
            // 
            this.pnCredit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnCredit.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnCredit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnCredit.Location = new System.Drawing.Point(0, 0);
            this.pnCredit.Name = "pnCredit";
            this.pnCredit.Size = new System.Drawing.Size(469, 579);
            this.pnCredit.TabIndex = 1;
            this.theme1.SetTheme(this.pnCredit, "(default)");
            // 
            // FrmCashAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 626);
            this.Controls.Add(this.tC);
            this.Controls.Add(this.sB);
            this.Name = "FrmCashAccount";
            this.Text = "FrmCashAccount";
            this.Load += new System.EventHandler(this.FrmCashAccount_Load);
            this.sB.ResumeLayout(false);
            this.sB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tC)).EndInit();
            this.tC.ResumeLayout(false);
            this.tabCash.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCaPasswordVoid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCaVoid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCaVoid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCaSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCaNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCaEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCaRemark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCaNameT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCaID)).EndInit();
            this.tabCredit.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrPasswordVoid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCrVoid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCrVoid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCrSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCrNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCrEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrRemark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrNameT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip sB;
        private System.Windows.Forms.ToolStripStatusLabel sB1;
        private C1.Win.C1Themes.C1ThemeController theme1;
        private C1.Win.C1Command.C1DockingTab tC;
        private C1.Win.C1Command.C1DockingTabPage tabCash;
        private System.Windows.Forms.Panel pnCash;
        private C1.Win.C1Command.C1DockingTabPage tabCredit;
        private System.Windows.Forms.Panel pnCredit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private C1.Win.C1Input.C1TextBox txtCaPasswordVoid;
        private C1.Win.C1Input.C1CheckBox chkCaVoid;
        private C1.Win.C1Input.C1Button btnCaVoid;
        private C1.Win.C1Input.C1Button btnCaSave;
        private C1.Win.C1Input.C1Button btnCaNew;
        private C1.Win.C1Input.C1Button btnCaEdit;
        private C1.Win.C1Input.C1TextBox txtCaRemark;
        private System.Windows.Forms.Label label3;
        private C1.Win.C1Input.C1TextBox txtCaNameT;
        private System.Windows.Forms.Label label2;
        private C1.Win.C1Input.C1TextBox txtCaID;
        private C1.Win.C1Input.C1TextBox txtCrPasswordVoid;
        private C1.Win.C1Input.C1CheckBox chkCrVoid;
        private C1.Win.C1Input.C1Button btnCrVoid;
        private C1.Win.C1Input.C1Button btnCrSave;
        private C1.Win.C1Input.C1Button btnCrNew;
        private C1.Win.C1Input.C1Button btnCrEdit;
        private C1.Win.C1Input.C1TextBox txtCrRemark;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1Input.C1TextBox txtCrNameT;
        private System.Windows.Forms.Label label4;
        private C1.Win.C1Input.C1TextBox txtCrID;
    }
}