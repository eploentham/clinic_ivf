namespace clinic_ivf.gui
{
    partial class FrmLabReqAdd
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboUserReq = new C1.Win.C1Input.C1ComboBox();
            this.txtReqCode = new C1.Win.C1Input.C1TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new C1.Win.C1Input.C1TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVn = new C1.Win.C1Input.C1TextBox();
            this.btnSearch = new C1.Win.C1Input.C1Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHn = new C1.Win.C1Input.C1TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboLabReq = new C1.Win.C1Input.C1ComboBox();
            this.txtReqDate = new C1.Win.C1Input.C1DateEdit();
            this.label11 = new System.Windows.Forms.Label();
            this.btnReq = new C1.Win.C1Input.C1Button();
            this.sB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboUserReq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReqCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLabReq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReqDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReq)).BeginInit();
            this.SuspendLayout();
            // 
            // sB
            // 
            this.sB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sB1});
            this.sB.Location = new System.Drawing.Point(0, 169);
            this.sB.Name = "sB";
            this.sB.Size = new System.Drawing.Size(724, 22);
            this.sB.TabIndex = 9;
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(724, 169);
            this.panel1.TabIndex = 11;
            this.theme1.SetTheme(this.panel1, "(default)");
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cboUserReq);
            this.groupBox1.Controls.Add(this.txtReqCode);
            this.groupBox1.Controls.Add(this.label47);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtVn);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtHn);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboLabReq);
            this.groupBox1.Controls.Add(this.txtReqDate);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.btnReq);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(724, 169);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            this.theme1.SetTheme(this.groupBox1, "(default)");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label7.Location = new System.Drawing.Point(394, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 16);
            this.label7.TabIndex = 543;
            this.label7.Text = "user Request :";
            this.theme1.SetTheme(this.label7, "(default)");
            // 
            // cboUserReq
            // 
            this.cboUserReq.AllowSpinLoop = false;
            this.cboUserReq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cboUserReq.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.cboUserReq.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboUserReq.GapHeight = 0;
            this.cboUserReq.ImagePadding = new System.Windows.Forms.Padding(0);
            this.cboUserReq.ItemsDisplayMember = "";
            this.cboUserReq.ItemsValueMember = "";
            this.cboUserReq.Location = new System.Drawing.Point(494, 121);
            this.cboUserReq.Name = "cboUserReq";
            this.cboUserReq.Size = new System.Drawing.Size(207, 20);
            this.cboUserReq.Style.DropDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cboUserReq.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro;
            this.cboUserReq.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboUserReq.TabIndex = 542;
            this.cboUserReq.Tag = null;
            this.theme1.SetTheme(this.cboUserReq, "(default)");
            this.cboUserReq.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // txtReqCode
            // 
            this.txtReqCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReqCode.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtReqCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtReqCode.Location = new System.Drawing.Point(122, 18);
            this.txtReqCode.Name = "txtReqCode";
            this.txtReqCode.Size = new System.Drawing.Size(207, 20);
            this.txtReqCode.TabIndex = 541;
            this.txtReqCode.Tag = null;
            this.theme1.SetTheme(this.txtReqCode, "(default)");
            this.txtReqCode.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label47.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label47.Location = new System.Drawing.Point(16, 22);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(38, 16);
            this.label47.TabIndex = 540;
            this.label47.Text = "เลขที่ :";
            this.theme1.SetTheme(this.label47, "(default)");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label3.Location = new System.Drawing.Point(16, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 535;
            this.label3.Text = "name :";
            this.theme1.SetTheme(this.label3, "(default)");
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtName.Location = new System.Drawing.Point(122, 100);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(207, 20);
            this.txtName.TabIndex = 534;
            this.txtName.Tag = null;
            this.theme1.SetTheme(this.txtName, "(default)");
            this.txtName.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label2.Location = new System.Drawing.Point(16, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 16);
            this.label2.TabIndex = 533;
            this.label2.Text = "VN :";
            this.theme1.SetTheme(this.label2, "(default)");
            // 
            // txtVn
            // 
            this.txtVn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVn.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtVn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtVn.Location = new System.Drawing.Point(122, 121);
            this.txtVn.Name = "txtVn";
            this.txtVn.Size = new System.Drawing.Size(207, 20);
            this.txtVn.TabIndex = 532;
            this.txtVn.Tag = null;
            this.theme1.SetTheme(this.txtVn, "(default)");
            this.txtVn.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(335, 78);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(28, 23);
            this.btnSearch.TabIndex = 531;
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
            this.label4.Location = new System.Drawing.Point(16, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 16);
            this.label4.TabIndex = 530;
            this.label4.Text = "HN :";
            this.theme1.SetTheme(this.label4, "(default)");
            // 
            // txtHn
            // 
            this.txtHn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHn.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtHn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtHn.Location = new System.Drawing.Point(122, 79);
            this.txtHn.Name = "txtHn";
            this.txtHn.Size = new System.Drawing.Size(207, 20);
            this.txtHn.TabIndex = 529;
            this.txtHn.Tag = null;
            this.theme1.SetTheme(this.txtHn, "(default)");
            this.txtHn.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label1.Location = new System.Drawing.Point(16, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 528;
            this.label1.Text = "Lab Request :";
            this.theme1.SetTheme(this.label1, "(default)");
            // 
            // cboLabReq
            // 
            this.cboLabReq.AllowSpinLoop = false;
            this.cboLabReq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cboLabReq.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.cboLabReq.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboLabReq.GapHeight = 0;
            this.cboLabReq.ImagePadding = new System.Windows.Forms.Padding(0);
            this.cboLabReq.ItemsDisplayMember = "";
            this.cboLabReq.ItemsValueMember = "";
            this.cboLabReq.Location = new System.Drawing.Point(122, 58);
            this.cboLabReq.Name = "cboLabReq";
            this.cboLabReq.Size = new System.Drawing.Size(207, 20);
            this.cboLabReq.Style.DropDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cboLabReq.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro;
            this.cboLabReq.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboLabReq.TabIndex = 527;
            this.cboLabReq.Tag = null;
            this.theme1.SetTheme(this.cboLabReq, "(default)");
            this.cboLabReq.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // txtReqDate
            // 
            this.txtReqDate.AllowSpinLoop = false;
            this.txtReqDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtReqDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // 
            // 
            this.txtReqDate.Calendar.ArrowColor = System.Drawing.Color.Black;
            this.txtReqDate.Calendar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtReqDate.Calendar.DayNamesFont = new System.Drawing.Font("Tahoma", 8F);
            this.txtReqDate.Calendar.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtReqDate.Calendar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.txtReqDate.Calendar.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(71)))), ((int)(((byte)(47)))));
            this.txtReqDate.Calendar.SelectionForeColor = System.Drawing.Color.White;
            this.txtReqDate.Calendar.TitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.txtReqDate.Calendar.TitleFont = new System.Drawing.Font("Tahoma", 8F);
            this.txtReqDate.Calendar.TitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.txtReqDate.Calendar.TodayBorderColor = System.Drawing.Color.White;
            this.txtReqDate.Calendar.TrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtReqDate.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.txtReqDate.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtReqDate.ImagePadding = new System.Windows.Forms.Padding(0);
            this.txtReqDate.Location = new System.Drawing.Point(122, 39);
            this.txtReqDate.Name = "txtReqDate";
            this.txtReqDate.ReadOnly = true;
            this.txtReqDate.Size = new System.Drawing.Size(168, 18);
            this.txtReqDate.TabIndex = 512;
            this.txtReqDate.Tag = null;
            this.theme1.SetTheme(this.txtReqDate, "(default)");
            this.txtReqDate.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label11.Location = new System.Drawing.Point(16, 39);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 16);
            this.label11.TabIndex = 511;
            this.label11.Text = "Date Request :";
            this.theme1.SetTheme(this.label11, "(default)");
            // 
            // btnReq
            // 
            this.btnReq.Location = new System.Drawing.Point(591, 32);
            this.btnReq.Name = "btnReq";
            this.btnReq.Size = new System.Drawing.Size(110, 31);
            this.btnReq.TabIndex = 0;
            this.btnReq.Text = "requert";
            this.btnReq.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.theme1.SetTheme(this.btnReq, "(default)");
            this.btnReq.UseVisualStyleBackColor = true;
            this.btnReq.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // FrmLabReqAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 191);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sB);
            this.Name = "FrmLabReqAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmLabReqAdd";
            this.Load += new System.EventHandler(this.FrmLabReqAdd_Load);
            this.sB.ResumeLayout(false);
            this.sB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboUserReq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReqCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLabReq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReqDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReq)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip sB;
        private System.Windows.Forms.ToolStripStatusLabel sB1;
        private C1.Win.C1Themes.C1ThemeController theme1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private C1.Win.C1Input.C1ComboBox cboUserReq;
        private C1.Win.C1Input.C1TextBox txtReqCode;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label3;
        private C1.Win.C1Input.C1TextBox txtName;
        private System.Windows.Forms.Label label2;
        private C1.Win.C1Input.C1TextBox txtVn;
        private C1.Win.C1Input.C1Button btnSearch;
        private System.Windows.Forms.Label label4;
        private C1.Win.C1Input.C1TextBox txtHn;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1Input.C1ComboBox cboLabReq;
        private C1.Win.C1Input.C1DateEdit txtReqDate;
        private System.Windows.Forms.Label label11;
        private C1.Win.C1Input.C1Button btnReq;
    }
}