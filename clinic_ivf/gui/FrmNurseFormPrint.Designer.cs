namespace clinic_ivf.gui
{
    partial class FrmNurseFormPrint
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFinish = new C1.Win.C1Input.C1Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboOperation = new C1.Win.C1Input.C1ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboAnes = new C1.Win.C1Input.C1ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboDoctor = new C1.Win.C1Input.C1ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDob = new C1.Win.C1Input.C1TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHn = new C1.Win.C1Input.C1TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPttNameE = new C1.Win.C1Input.C1TextBox();
            this.c1CheckBox7 = new C1.Win.C1Input.C1CheckBox();
            this.chkPrnPmh = new C1.Win.C1Input.C1CheckBox();
            this.chkOperaNote = new C1.Win.C1Input.C1CheckBox();
            this.chkOrdFET = new C1.Win.C1Input.C1CheckBox();
            this.chkOrdOPU = new C1.Win.C1Input.C1CheckBox();
            this.chkAuthenSign = new C1.Win.C1Input.C1CheckBox();
            this.chkPrnCheckList = new C1.Win.C1Input.C1CheckBox();
            this.lbPrinter = new System.Windows.Forms.Label();
            this.lbPrint1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnFinish)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboOperation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAnes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDoctor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDob)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPttNameE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1CheckBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPrnPmh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOperaNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOrdFET)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOrdOPU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAuthenSign)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPrnCheckList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbPrint1);
            this.groupBox1.Controls.Add(this.lbPrinter);
            this.groupBox1.Controls.Add(this.btnFinish);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtDob);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtHn);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtPttNameE);
            this.groupBox1.Controls.Add(this.c1CheckBox7);
            this.groupBox1.Controls.Add(this.chkPrnPmh);
            this.groupBox1.Controls.Add(this.chkOperaNote);
            this.groupBox1.Controls.Add(this.chkOrdFET);
            this.groupBox1.Controls.Add(this.chkOrdOPU);
            this.groupBox1.Controls.Add(this.chkAuthenSign);
            this.groupBox1.Controls.Add(this.chkPrnCheckList);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(694, 338);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "เลือกรายการ";
            // 
            // btnFinish
            // 
            this.btnFinish.Image = global::clinic_ivf.Properties.Resources.Add_ticket_24;
            this.btnFinish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFinish.Location = new System.Drawing.Point(580, 288);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(80, 31);
            this.btnFinish.TabIndex = 941;
            this.btnFinish.Text = "OK";
            this.btnFinish.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboOperation);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cboAnes);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cboDoctor);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(309, 145);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(370, 112);
            this.groupBox2.TabIndex = 940;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Autherization Form";
            // 
            // cboOperation
            // 
            this.cboOperation.AllowSpinLoop = false;
            this.cboOperation.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.cboOperation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cboOperation.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.cboOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboOperation.GapHeight = 0;
            this.cboOperation.ImagePadding = new System.Windows.Forms.Padding(0);
            this.cboOperation.Items.Add("OPU");
            this.cboOperation.Items.Add("PESA/TESE");
            this.cboOperation.Items.Add(" ");
            this.cboOperation.ItemsDisplayMember = "";
            this.cboOperation.ItemsValueMember = "";
            this.cboOperation.Location = new System.Drawing.Point(98, 71);
            this.cboOperation.Name = "cboOperation";
            this.cboOperation.Size = new System.Drawing.Size(253, 20);
            this.cboOperation.Style.DropDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cboOperation.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro;
            this.cboOperation.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboOperation.TabIndex = 943;
            this.cboOperation.Tag = null;
            this.cboOperation.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label5.Location = new System.Drawing.Point(9, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 16);
            this.label5.TabIndex = 942;
            this.label5.Text = "Opearation :";
            // 
            // cboAnes
            // 
            this.cboAnes.AllowSpinLoop = false;
            this.cboAnes.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.cboAnes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cboAnes.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.cboAnes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboAnes.GapHeight = 0;
            this.cboAnes.ImagePadding = new System.Windows.Forms.Padding(0);
            this.cboAnes.ItemsDisplayMember = "";
            this.cboAnes.ItemsValueMember = "";
            this.cboAnes.Location = new System.Drawing.Point(98, 45);
            this.cboAnes.Name = "cboAnes";
            this.cboAnes.Size = new System.Drawing.Size(253, 20);
            this.cboAnes.Style.DropDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cboAnes.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro;
            this.cboAnes.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboAnes.TabIndex = 941;
            this.cboAnes.Tag = null;
            this.cboAnes.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label1.Location = new System.Drawing.Point(9, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 940;
            this.label1.Text = "Anesthesia :";
            // 
            // cboDoctor
            // 
            this.cboDoctor.AllowSpinLoop = false;
            this.cboDoctor.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.cboDoctor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cboDoctor.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.cboDoctor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboDoctor.GapHeight = 0;
            this.cboDoctor.ImagePadding = new System.Windows.Forms.Padding(0);
            this.cboDoctor.ItemsDisplayMember = "";
            this.cboDoctor.ItemsValueMember = "";
            this.cboDoctor.Location = new System.Drawing.Point(98, 19);
            this.cboDoctor.Name = "cboDoctor";
            this.cboDoctor.Size = new System.Drawing.Size(253, 20);
            this.cboDoctor.Style.DropDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cboDoctor.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro;
            this.cboDoctor.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboDoctor.TabIndex = 939;
            this.cboDoctor.Tag = null;
            this.cboDoctor.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label3.Location = new System.Drawing.Point(9, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 16);
            this.label3.TabIndex = 938;
            this.label3.Text = "Doctor :";
            // 
            // txtDob
            // 
            this.txtDob.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.txtDob.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDob.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtDob.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtDob.Location = new System.Drawing.Point(119, 75);
            this.txtDob.Name = "txtDob";
            this.txtDob.Size = new System.Drawing.Size(156, 20);
            this.txtDob.TabIndex = 937;
            this.txtDob.Tag = null;
            this.txtDob.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label11.Location = new System.Drawing.Point(30, 77);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 16);
            this.label11.TabIndex = 936;
            this.label11.Text = "DOB :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label4.Location = new System.Drawing.Point(30, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 16);
            this.label4.TabIndex = 935;
            this.label4.Text = "HN :";
            // 
            // txtHn
            // 
            this.txtHn.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.txtHn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHn.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtHn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtHn.Location = new System.Drawing.Point(119, 45);
            this.txtHn.Name = "txtHn";
            this.txtHn.Size = new System.Drawing.Size(146, 24);
            this.txtHn.TabIndex = 934;
            this.txtHn.Tag = null;
            this.txtHn.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label2.Location = new System.Drawing.Point(30, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 933;
            this.label2.Text = "Name :";
            // 
            // txtPttNameE
            // 
            this.txtPttNameE.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.txtPttNameE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPttNameE.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtPttNameE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtPttNameE.Location = new System.Drawing.Point(119, 19);
            this.txtPttNameE.Name = "txtPttNameE";
            this.txtPttNameE.Size = new System.Drawing.Size(253, 20);
            this.txtPttNameE.TabIndex = 932;
            this.txtPttNameE.Tag = null;
            this.txtPttNameE.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // c1CheckBox7
            // 
            this.c1CheckBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.c1CheckBox7.Enabled = false;
            this.c1CheckBox7.Location = new System.Drawing.Point(119, 295);
            this.c1CheckBox7.Name = "c1CheckBox7";
            this.c1CheckBox7.Size = new System.Drawing.Size(204, 24);
            this.c1CheckBox7.TabIndex = 6;
            this.c1CheckBox7.Text = "Print Sticker VN";
            this.c1CheckBox7.UseVisualStyleBackColor = true;
            this.c1CheckBox7.Value = null;
            // 
            // chkPrnPmh
            // 
            this.chkPrnPmh.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkPrnPmh.Location = new System.Drawing.Point(119, 265);
            this.chkPrnPmh.Name = "chkPrnPmh";
            this.chkPrnPmh.Size = new System.Drawing.Size(204, 24);
            this.chkPrnPmh.TabIndex = 5;
            this.chkPrnPmh.Text = "Patient Medical History";
            this.chkPrnPmh.UseVisualStyleBackColor = true;
            this.chkPrnPmh.Value = null;
            // 
            // chkOperaNote
            // 
            this.chkOperaNote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkOperaNote.Location = new System.Drawing.Point(119, 235);
            this.chkOperaNote.Name = "chkOperaNote";
            this.chkOperaNote.Size = new System.Drawing.Size(184, 24);
            this.chkOperaNote.TabIndex = 4;
            this.chkOperaNote.Text = "Post Operation Note";
            this.chkOperaNote.UseVisualStyleBackColor = true;
            this.chkOperaNote.Value = null;
            // 
            // chkOrdFET
            // 
            this.chkOrdFET.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkOrdFET.Location = new System.Drawing.Point(119, 205);
            this.chkOrdFET.Name = "chkOrdFET";
            this.chkOrdFET.Size = new System.Drawing.Size(184, 24);
            this.chkOrdFET.TabIndex = 3;
            this.chkOrdFET.Text = "Order ET, FET";
            this.chkOrdFET.UseVisualStyleBackColor = true;
            this.chkOrdFET.Value = null;
            // 
            // chkOrdOPU
            // 
            this.chkOrdOPU.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkOrdOPU.Location = new System.Drawing.Point(119, 175);
            this.chkOrdOPU.Name = "chkOrdOPU";
            this.chkOrdOPU.Size = new System.Drawing.Size(184, 24);
            this.chkOrdOPU.TabIndex = 2;
            this.chkOrdOPU.Text = "Order OPU";
            this.chkOrdOPU.UseVisualStyleBackColor = true;
            this.chkOrdOPU.Value = null;
            // 
            // chkAuthenSign
            // 
            this.chkAuthenSign.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkAuthenSign.Location = new System.Drawing.Point(119, 145);
            this.chkAuthenSign.Name = "chkAuthenSign";
            this.chkAuthenSign.Size = new System.Drawing.Size(156, 24);
            this.chkAuthenSign.TabIndex = 1;
            this.chkAuthenSign.Text = "Autherization Form";
            this.chkAuthenSign.UseVisualStyleBackColor = true;
            this.chkAuthenSign.Value = null;
            // 
            // chkPrnCheckList
            // 
            this.chkPrnCheckList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkPrnCheckList.Location = new System.Drawing.Point(119, 115);
            this.chkPrnCheckList.Name = "chkPrnCheckList";
            this.chkPrnCheckList.Size = new System.Drawing.Size(184, 24);
            this.chkPrnCheckList.TabIndex = 0;
            this.chkPrnCheckList.Text = "Pre-Operation Check List";
            this.chkPrnCheckList.UseVisualStyleBackColor = true;
            this.chkPrnCheckList.Value = null;
            // 
            // lbPrinter
            // 
            this.lbPrinter.AutoSize = true;
            this.lbPrinter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lbPrinter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrinter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.lbPrinter.Location = new System.Drawing.Point(318, 77);
            this.lbPrinter.Name = "lbPrinter";
            this.lbPrinter.Size = new System.Drawing.Size(11, 16);
            this.lbPrinter.TabIndex = 944;
            this.lbPrinter.Text = ".";
            // 
            // lbPrint1
            // 
            this.lbPrint1.AutoSize = true;
            this.lbPrint1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lbPrint1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrint1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.lbPrint1.Location = new System.Drawing.Point(318, 104);
            this.lbPrint1.Name = "lbPrint1";
            this.lbPrint1.Size = new System.Drawing.Size(11, 16);
            this.lbPrint1.TabIndex = 945;
            this.lbPrint1.Text = ".";
            // 
            // FrmNurseFormPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 348);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmNurseFormPrint";
            this.Text = "FrmNurseFormPrint";
            this.Load += new System.EventHandler(this.FrmNurseFormPrint_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnFinish)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboOperation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAnes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDoctor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDob)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPttNameE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1CheckBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPrnPmh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOperaNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOrdFET)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOrdOPU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAuthenSign)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPrnCheckList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private C1.Win.C1Input.C1CheckBox chkPrnPmh;
        private C1.Win.C1Input.C1CheckBox chkOperaNote;
        private C1.Win.C1Input.C1CheckBox chkOrdFET;
        private C1.Win.C1Input.C1CheckBox chkOrdOPU;
        private C1.Win.C1Input.C1CheckBox chkAuthenSign;
        private C1.Win.C1Input.C1CheckBox chkPrnCheckList;
        private C1.Win.C1Input.C1CheckBox c1CheckBox7;
        private C1.Win.C1Input.C1TextBox txtDob;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private C1.Win.C1Input.C1TextBox txtHn;
        private System.Windows.Forms.Label label2;
        private C1.Win.C1Input.C1TextBox txtPttNameE;
        private System.Windows.Forms.GroupBox groupBox2;
        private C1.Win.C1Input.C1ComboBox cboDoctor;
        private System.Windows.Forms.Label label3;
        private C1.Win.C1Input.C1ComboBox cboOperation;
        private System.Windows.Forms.Label label5;
        private C1.Win.C1Input.C1ComboBox cboAnes;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1Input.C1Button btnFinish;
        private System.Windows.Forms.Label lbPrinter;
        private System.Windows.Forms.Label lbPrint1;
    }
}