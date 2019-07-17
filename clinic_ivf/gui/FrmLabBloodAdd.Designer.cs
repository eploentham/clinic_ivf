namespace clinic_ivf.gui
{
    partial class FrmLabBloodAdd
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSex = new C1.Win.C1Input.C1TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPttId = new C1.Win.C1Input.C1TextBox();
            this.txtVsId = new C1.Win.C1Input.C1TextBox();
            this.txtVn = new C1.Win.C1Input.C1TextBox();
            this.txtVnShow = new C1.Win.C1Input.C1TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPrintSf = new C1.Win.C1Input.C1Button();
            this.btnSfApproveResult = new C1.Win.C1Input.C1Button();
            this.btnSfSave = new C1.Win.C1Input.C1Button();
            this.label1 = new System.Windows.Forms.Label();
            this.c1DateEdit1 = new C1.Win.C1Input.C1DateEdit();
            this.label109 = new System.Windows.Forms.Label();
            this.txtSfReportDate = new C1.Win.C1Input.C1DateEdit();
            this.cboEmbryologistAppv = new C1.Win.C1Input.C1ComboBox();
            this.cboEmbryologistReport = new C1.Win.C1Input.C1ComboBox();
            this.label61 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.txtDobFeMale = new C1.Win.C1Input.C1DateEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new C1.Win.C1Input.C1TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHn = new C1.Win.C1Input.C1TextBox();
            this.pnProc = new System.Windows.Forms.Panel();
            this.theme1 = new C1.Win.C1Themes.C1ThemeController();
            this.sB = new System.Windows.Forms.StatusStrip();
            this.sB1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPttId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVsId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVnShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrintSf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSfApproveResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSfSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1DateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSfReportDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmbryologistAppv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmbryologistReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDobFeMale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).BeginInit();
            this.sB.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtSex);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtPttId);
            this.panel1.Controls.Add(this.txtVsId);
            this.panel1.Controls.Add(this.txtVn);
            this.panel1.Controls.Add(this.txtVnShow);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnPrintSf);
            this.panel1.Controls.Add(this.btnSfApproveResult);
            this.panel1.Controls.Add(this.btnSfSave);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.c1DateEdit1);
            this.panel1.Controls.Add(this.label109);
            this.panel1.Controls.Add(this.txtSfReportDate);
            this.panel1.Controls.Add(this.cboEmbryologistAppv);
            this.panel1.Controls.Add(this.cboEmbryologistReport);
            this.panel1.Controls.Add(this.label61);
            this.panel1.Controls.Add(this.label60);
            this.panel1.Controls.Add(this.txtDobFeMale);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtHn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1136, 130);
            this.panel1.TabIndex = 0;
            // 
            // txtSex
            // 
            this.txtSex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSex.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtSex.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtSex.Location = new System.Drawing.Point(488, 56);
            this.txtSex.Name = "txtSex";
            this.txtSex.Size = new System.Drawing.Size(69, 20);
            this.txtSex.TabIndex = 973;
            this.txtSex.Tag = null;
            this.theme1.SetTheme(this.txtSex, "(default)");
            this.txtSex.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label6.Location = new System.Drawing.Point(338, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 16);
            this.label6.TabIndex = 972;
            this.label6.Text = "Sex :";
            this.theme1.SetTheme(this.label6, "(default)");
            // 
            // txtPttId
            // 
            this.txtPttId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPttId.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtPttId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtPttId.Location = new System.Drawing.Point(654, 60);
            this.txtPttId.Name = "txtPttId";
            this.txtPttId.Size = new System.Drawing.Size(30, 20);
            this.txtPttId.TabIndex = 970;
            this.txtPttId.Tag = null;
            this.theme1.SetTheme(this.txtPttId, "(default)");
            this.txtPttId.Visible = false;
            this.txtPttId.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // txtVsId
            // 
            this.txtVsId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVsId.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtVsId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtVsId.Location = new System.Drawing.Point(623, 61);
            this.txtVsId.Name = "txtVsId";
            this.txtVsId.Size = new System.Drawing.Size(30, 20);
            this.txtVsId.TabIndex = 969;
            this.txtVsId.Tag = null;
            this.theme1.SetTheme(this.txtVsId, "(default)");
            this.txtVsId.Visible = false;
            this.txtVsId.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // txtVn
            // 
            this.txtVn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVn.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtVn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtVn.Location = new System.Drawing.Point(578, 57);
            this.txtVn.Name = "txtVn";
            this.txtVn.Size = new System.Drawing.Size(41, 24);
            this.txtVn.TabIndex = 971;
            this.txtVn.Tag = null;
            this.theme1.SetTheme(this.txtVn, "(default)");
            this.txtVn.Value = "select pttI.* From t_patient_image pttI Where pttI.t_patient_id =\'2080006675\' and" +
    " active=\'1\'  and pttI.dept_id=\'1090000002\' and pttI.status_document=\'2\' Order By" +
    " patient_image_id";
            this.txtVn.Visible = false;
            this.txtVn.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // txtVnShow
            // 
            this.txtVnShow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVnShow.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtVnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtVnShow.Location = new System.Drawing.Point(94, 76);
            this.txtVnShow.Name = "txtVnShow";
            this.txtVnShow.Size = new System.Drawing.Size(126, 24);
            this.txtVnShow.TabIndex = 968;
            this.txtVnShow.Tag = null;
            this.theme1.SetTheme(this.txtVnShow, "(default)");
            this.txtVnShow.Value = "select pttI.* From t_patient_image pttI Where pttI.t_patient_id =\'2080006675\' and" +
    " active=\'1\'  and pttI.dept_id=\'1090000002\' and pttI.status_document=\'2\' Order By" +
    " patient_image_id";
            this.txtVnShow.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label3.Location = new System.Drawing.Point(9, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 16);
            this.label3.TabIndex = 967;
            this.label3.Text = "VN :";
            this.theme1.SetTheme(this.label3, "(default)");
            // 
            // btnPrintSf
            // 
            this.btnPrintSf.Image = global::clinic_ivf.Properties.Resources.print;
            this.btnPrintSf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintSf.Location = new System.Drawing.Point(848, 60);
            this.btnPrintSf.Name = "btnPrintSf";
            this.btnPrintSf.Size = new System.Drawing.Size(126, 34);
            this.btnPrintSf.TabIndex = 868;
            this.btnPrintSf.Text = "Print  ";
            this.btnPrintSf.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrintSf.UseVisualStyleBackColor = true;
            this.btnPrintSf.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // btnSfApproveResult
            // 
            this.btnSfApproveResult.Image = global::clinic_ivf.Properties.Resources.Female_user_add_24;
            this.btnSfApproveResult.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSfApproveResult.Location = new System.Drawing.Point(992, 14);
            this.btnSfApproveResult.Name = "btnSfApproveResult";
            this.btnSfApproveResult.Size = new System.Drawing.Size(128, 39);
            this.btnSfApproveResult.TabIndex = 815;
            this.btnSfApproveResult.Text = "Finish";
            this.btnSfApproveResult.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSfApproveResult.UseVisualStyleBackColor = true;
            this.btnSfApproveResult.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // btnSfSave
            // 
            this.btnSfSave.Image = global::clinic_ivf.Properties.Resources.download_database24;
            this.btnSfSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSfSave.Location = new System.Drawing.Point(891, 13);
            this.btnSfSave.Name = "btnSfSave";
            this.btnSfSave.Size = new System.Drawing.Size(83, 39);
            this.btnSfSave.TabIndex = 814;
            this.btnSfSave.Text = "บันทึกช้อมูล";
            this.btnSfSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSfSave.UseVisualStyleBackColor = true;
            this.btnSfSave.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label1.Location = new System.Drawing.Point(660, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 813;
            this.label1.Text = "Datetime :";
            // 
            // c1DateEdit1
            // 
            this.c1DateEdit1.AllowSpinLoop = false;
            this.c1DateEdit1.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.c1DateEdit1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // 
            // 
            this.c1DateEdit1.Calendar.Font = new System.Drawing.Font("Tahoma", 8F);
            this.c1DateEdit1.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.System;
            this.c1DateEdit1.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.c1DateEdit1.Culture = 1054;
            this.c1DateEdit1.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.c1DateEdit1.DisplayFormat.CalendarType = C1.Win.C1Input.CalendarType.GregorianCalendar;
            this.c1DateEdit1.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDateShortTime;
            this.c1DateEdit1.DisplayFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText) 
            | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.c1DateEdit1.EditFormat.CalendarType = C1.Win.C1Input.CalendarType.GregorianCalendar;
            this.c1DateEdit1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDateShortTime;
            this.c1DateEdit1.EditFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText) 
            | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.c1DateEdit1.EmptyAsNull = true;
            this.c1DateEdit1.ImagePadding = new System.Windows.Forms.Padding(0);
            this.c1DateEdit1.Location = new System.Drawing.Point(734, 36);
            this.c1DateEdit1.Name = "c1DateEdit1";
            this.c1DateEdit1.Size = new System.Drawing.Size(151, 18);
            this.c1DateEdit1.TabIndex = 812;
            this.c1DateEdit1.Tag = null;
            this.c1DateEdit1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label109
            // 
            this.label109.AutoSize = true;
            this.label109.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label109.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label109.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label109.Location = new System.Drawing.Point(660, 15);
            this.label109.Name = "label109";
            this.label109.Size = new System.Drawing.Size(68, 16);
            this.label109.TabIndex = 811;
            this.label109.Text = "Datetime :";
            // 
            // txtSfReportDate
            // 
            this.txtSfReportDate.AllowSpinLoop = false;
            this.txtSfReportDate.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.txtSfReportDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // 
            // 
            this.txtSfReportDate.Calendar.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtSfReportDate.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.System;
            this.txtSfReportDate.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.txtSfReportDate.Culture = 1054;
            this.txtSfReportDate.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtSfReportDate.DisplayFormat.CalendarType = C1.Win.C1Input.CalendarType.GregorianCalendar;
            this.txtSfReportDate.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDateShortTime;
            this.txtSfReportDate.DisplayFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText) 
            | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.txtSfReportDate.EditFormat.CalendarType = C1.Win.C1Input.CalendarType.GregorianCalendar;
            this.txtSfReportDate.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDateShortTime;
            this.txtSfReportDate.EditFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText) 
            | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.txtSfReportDate.EmptyAsNull = true;
            this.txtSfReportDate.ImagePadding = new System.Windows.Forms.Padding(0);
            this.txtSfReportDate.Location = new System.Drawing.Point(734, 13);
            this.txtSfReportDate.Name = "txtSfReportDate";
            this.txtSfReportDate.Size = new System.Drawing.Size(151, 18);
            this.txtSfReportDate.TabIndex = 810;
            this.txtSfReportDate.Tag = null;
            this.txtSfReportDate.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // cboEmbryologistAppv
            // 
            this.cboEmbryologistAppv.AllowSpinLoop = false;
            this.cboEmbryologistAppv.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboEmbryologistAppv.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboEmbryologistAppv.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.cboEmbryologistAppv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cboEmbryologistAppv.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.cboEmbryologistAppv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboEmbryologistAppv.GapHeight = 0;
            this.cboEmbryologistAppv.ImagePadding = new System.Windows.Forms.Padding(0);
            this.cboEmbryologistAppv.ItemsDisplayMember = "";
            this.cboEmbryologistAppv.ItemsValueMember = "";
            this.cboEmbryologistAppv.Location = new System.Drawing.Point(488, 35);
            this.cboEmbryologistAppv.Name = "cboEmbryologistAppv";
            this.cboEmbryologistAppv.Size = new System.Drawing.Size(165, 20);
            this.cboEmbryologistAppv.Style.DropDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cboEmbryologistAppv.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro;
            this.cboEmbryologistAppv.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboEmbryologistAppv.TabIndex = 548;
            this.cboEmbryologistAppv.Tag = null;
            this.cboEmbryologistAppv.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // cboEmbryologistReport
            // 
            this.cboEmbryologistReport.AllowSpinLoop = false;
            this.cboEmbryologistReport.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboEmbryologistReport.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboEmbryologistReport.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.cboEmbryologistReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cboEmbryologistReport.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.cboEmbryologistReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboEmbryologistReport.GapHeight = 0;
            this.cboEmbryologistReport.ImagePadding = new System.Windows.Forms.Padding(0);
            this.cboEmbryologistReport.ItemsDisplayMember = "";
            this.cboEmbryologistReport.ItemsValueMember = "";
            this.cboEmbryologistReport.Location = new System.Drawing.Point(488, 12);
            this.cboEmbryologistReport.Name = "cboEmbryologistReport";
            this.cboEmbryologistReport.Size = new System.Drawing.Size(165, 20);
            this.cboEmbryologistReport.Style.DropDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cboEmbryologistReport.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro;
            this.cboEmbryologistReport.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboEmbryologistReport.TabIndex = 547;
            this.cboEmbryologistReport.Tag = null;
            this.cboEmbryologistReport.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label61.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label61.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label61.Location = new System.Drawing.Point(338, 37);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(147, 16);
            this.label61.TabIndex = 546;
            this.label61.Text = "Embryologist approve :";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label60.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label60.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label60.Location = new System.Drawing.Point(339, 14);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(131, 16);
            this.label60.TabIndex = 545;
            this.label60.Text = "Embryologist report :";
            // 
            // txtDobFeMale
            // 
            this.txtDobFeMale.AllowSpinLoop = false;
            this.txtDobFeMale.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.txtDobFeMale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // 
            // 
            this.txtDobFeMale.Calendar.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtDobFeMale.Calendar.VisualStyle = C1.Win.C1Input.VisualStyle.System;
            this.txtDobFeMale.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.txtDobFeMale.Culture = 1054;
            this.txtDobFeMale.CurrentTimeZone = false;
            this.txtDobFeMale.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtDobFeMale.DisplayFormat.CalendarType = C1.Win.C1Input.CalendarType.GregorianCalendar;
            this.txtDobFeMale.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate;
            this.txtDobFeMale.DisplayFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText) 
            | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.txtDobFeMale.EditFormat.CalendarType = C1.Win.C1Input.CalendarType.GregorianCalendar;
            this.txtDobFeMale.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate;
            this.txtDobFeMale.EditFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText) 
            | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.txtDobFeMale.EmptyAsNull = true;
            this.txtDobFeMale.GMTOffset = System.TimeSpan.Parse("00:00:00");
            this.txtDobFeMale.ImagePadding = new System.Windows.Forms.Padding(0);
            this.txtDobFeMale.Location = new System.Drawing.Point(95, 56);
            this.txtDobFeMale.Name = "txtDobFeMale";
            this.txtDobFeMale.Size = new System.Drawing.Size(207, 18);
            this.txtDobFeMale.TabIndex = 540;
            this.txtDobFeMale.Tag = null;
            this.txtDobFeMale.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label5.Location = new System.Drawing.Point(9, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 16);
            this.label5.TabIndex = 539;
            this.label5.Text = "day of birth :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label2.Location = new System.Drawing.Point(9, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 538;
            this.label2.Text = "name :";
            // 
            // txtName
            // 
            this.txtName.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtName.Location = new System.Drawing.Point(95, 34);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(207, 20);
            this.txtName.TabIndex = 537;
            this.txtName.Tag = null;
            this.txtName.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label4.Location = new System.Drawing.Point(9, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 16);
            this.label4.TabIndex = 536;
            this.label4.Text = "HN  :";
            // 
            // txtHn
            // 
            this.txtHn.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.txtHn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHn.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtHn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtHn.Location = new System.Drawing.Point(95, 12);
            this.txtHn.Name = "txtHn";
            this.txtHn.Size = new System.Drawing.Size(207, 20);
            this.txtHn.TabIndex = 535;
            this.txtHn.Tag = null;
            this.txtHn.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // pnProc
            // 
            this.pnProc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnProc.Location = new System.Drawing.Point(0, 130);
            this.pnProc.Name = "pnProc";
            this.pnProc.Size = new System.Drawing.Size(1136, 624);
            this.pnProc.TabIndex = 1;
            // 
            // theme1
            // 
            this.theme1.Theme = "Office2013Red";
            // 
            // sB
            // 
            this.sB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sB1});
            this.sB.Location = new System.Drawing.Point(0, 732);
            this.sB.Name = "sB";
            this.sB.Size = new System.Drawing.Size(1136, 22);
            this.sB.TabIndex = 11;
            this.sB.Text = "statusStrip1";
            // 
            // sB1
            // 
            this.sB1.Name = "sB1";
            this.sB1.Size = new System.Drawing.Size(118, 17);
            this.sB1.Text = "toolStripStatusLabel1";
            // 
            // FrmLabBloodAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 754);
            this.Controls.Add(this.sB);
            this.Controls.Add(this.pnProc);
            this.Controls.Add(this.panel1);
            this.Name = "FrmLabBloodAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmLabBloodAdd";
            this.Load += new System.EventHandler(this.FrmLabBloodAdd_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPttId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVsId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVnShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrintSf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSfApproveResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSfSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1DateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSfReportDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmbryologistAppv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmbryologistReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDobFeMale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).EndInit();
            this.sB.ResumeLayout(false);
            this.sB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnProc;
        private C1.Win.C1Input.C1DateEdit txtDobFeMale;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private C1.Win.C1Input.C1TextBox txtName;
        private System.Windows.Forms.Label label4;
        private C1.Win.C1Input.C1TextBox txtHn;
        private C1.Win.C1Input.C1ComboBox cboEmbryologistAppv;
        private C1.Win.C1Input.C1ComboBox cboEmbryologistReport;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1Input.C1DateEdit c1DateEdit1;
        private System.Windows.Forms.Label label109;
        private C1.Win.C1Input.C1DateEdit txtSfReportDate;
        private C1.Win.C1Input.C1Button btnSfApproveResult;
        private C1.Win.C1Input.C1Button btnSfSave;
        private C1.Win.C1Input.C1Button btnPrintSf;
        private C1.Win.C1Themes.C1ThemeController theme1;
        private System.Windows.Forms.StatusStrip sB;
        private System.Windows.Forms.ToolStripStatusLabel sB1;
        private C1.Win.C1Input.C1TextBox txtVnShow;
        private System.Windows.Forms.Label label3;
        private C1.Win.C1Input.C1TextBox txtPttId;
        private C1.Win.C1Input.C1TextBox txtVsId;
        private C1.Win.C1Input.C1TextBox txtVn;
        private C1.Win.C1Input.C1TextBox txtSex;
        private System.Windows.Forms.Label label6;
    }
}