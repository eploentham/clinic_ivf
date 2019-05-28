namespace clinic_ivf.gui
{
    partial class FrmLabItem
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
            this.sCMain = new C1.Win.C1SplitContainer.C1SplitContainer();
            this.c1SplitterPanel1 = new C1.Win.C1SplitContainer.C1SplitterPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.c1SplitterPanel2 = new C1.Win.C1SplitContainer.C1SplitterPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrice = new C1.Win.C1Input.C1TextBox();
            this.txtID = new C1.Win.C1Input.C1TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboDocGroupName = new C1.Win.C1Input.C1ComboBox();
            this.txtDocGroupSubName = new C1.Win.C1Input.C1TextBox();
            this.txtPasswordVoid = new C1.Win.C1Input.C1TextBox();
            this.btnSave = new C1.Win.C1Input.C1Button();
            this.btnNew = new C1.Win.C1Input.C1Button();
            this.btnEdit = new C1.Win.C1Input.C1Button();
            this.chkVoid = new C1.Win.C1Input.C1CheckBox();
            this.btnVoid = new C1.Win.C1Input.C1Button();
            this.chkShowQty = new C1.Win.C1Input.C1CheckBox();
            this.sB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sCMain)).BeginInit();
            this.sCMain.SuspendLayout();
            this.c1SplitterPanel1.SuspendLayout();
            this.c1SplitterPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDocGroupName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocGroupSubName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswordVoid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkVoid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVoid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowQty)).BeginInit();
            this.SuspendLayout();
            // 
            // sB
            // 
            this.sB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sB1});
            this.sB.Location = new System.Drawing.Point(0, 689);
            this.sB.Name = "sB";
            this.sB.Size = new System.Drawing.Size(1094, 22);
            this.sB.TabIndex = 6;
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
            // sCMain
            // 
            this.sCMain.AutoSizeElement = C1.Framework.AutoSizeElement.Both;
            this.sCMain.BackColor = System.Drawing.Color.White;
            this.sCMain.CollapsingAreaColor = System.Drawing.Color.White;
            this.sCMain.CollapsingCueColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.sCMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sCMain.FixedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(189)))), ((int)(((byte)(182)))));
            this.sCMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.sCMain.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.sCMain.HeaderLineWidth = 1;
            this.sCMain.Location = new System.Drawing.Point(0, 0);
            this.sCMain.Name = "sCMain";
            this.sCMain.Panels.Add(this.c1SplitterPanel1);
            this.sCMain.Panels.Add(this.c1SplitterPanel2);
            this.sCMain.Size = new System.Drawing.Size(1094, 689);
            this.sCMain.SplitterColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(189)))), ((int)(((byte)(182)))));
            this.sCMain.SplitterMovingColor = System.Drawing.Color.Black;
            this.sCMain.TabIndex = 7;
            this.theme1.SetTheme(this.sCMain, "(default)");
            this.sCMain.UseParentVisualStyle = false;
            // 
            // c1SplitterPanel1
            // 
            this.c1SplitterPanel1.Collapsible = true;
            this.c1SplitterPanel1.Controls.Add(this.panel1);
            this.c1SplitterPanel1.Dock = C1.Win.C1SplitContainer.PanelDockStyle.Left;
            this.c1SplitterPanel1.Location = new System.Drawing.Point(0, 21);
            this.c1SplitterPanel1.Name = "c1SplitterPanel1";
            this.c1SplitterPanel1.Size = new System.Drawing.Size(538, 668);
            this.c1SplitterPanel1.TabIndex = 0;
            this.c1SplitterPanel1.Text = "Panel 1";
            this.c1SplitterPanel1.Width = 545;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(538, 668);
            this.panel1.TabIndex = 0;
            this.theme1.SetTheme(this.panel1, "(default)");
            // 
            // c1SplitterPanel2
            // 
            this.c1SplitterPanel2.Controls.Add(this.panel2);
            this.c1SplitterPanel2.Height = 689;
            this.c1SplitterPanel2.Location = new System.Drawing.Point(549, 21);
            this.c1SplitterPanel2.Name = "c1SplitterPanel2";
            this.c1SplitterPanel2.Size = new System.Drawing.Size(545, 668);
            this.c1SplitterPanel2.TabIndex = 1;
            this.c1SplitterPanel2.Text = "Panel 2";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel2.Controls.Add(this.chkShowQty);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtPrice);
            this.panel2.Controls.Add(this.txtID);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cboDocGroupName);
            this.panel2.Controls.Add(this.txtDocGroupSubName);
            this.panel2.Controls.Add(this.txtPasswordVoid);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnNew);
            this.panel2.Controls.Add(this.btnEdit);
            this.panel2.Controls.Add(this.chkVoid);
            this.panel2.Controls.Add(this.btnVoid);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(545, 668);
            this.panel2.TabIndex = 0;
            this.theme1.SetTheme(this.panel2, "(default)");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label3.Location = new System.Drawing.Point(12, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 16);
            this.label3.TabIndex = 572;
            this.label3.Text = "Price :";
            this.theme1.SetTheme(this.label3, "(default)");
            // 
            // txtPrice
            // 
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrice.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtPrice.Location = new System.Drawing.Point(125, 110);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(140, 20);
            this.txtPrice.TabIndex = 573;
            this.txtPrice.Tag = null;
            this.theme1.SetTheme(this.txtPrice, "(default)");
            this.txtPrice.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // txtID
            // 
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtID.Location = new System.Drawing.Point(322, 24);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(30, 20);
            this.txtID.TabIndex = 561;
            this.txtID.Tag = null;
            this.theme1.SetTheme(this.txtID, "(default)");
            this.txtID.Visible = false;
            this.txtID.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label1.Location = new System.Drawing.Point(12, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 571;
            this.label1.Text = "Lab Group :";
            this.theme1.SetTheme(this.label1, "(default)");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label2.Location = new System.Drawing.Point(12, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 16);
            this.label2.TabIndex = 562;
            this.label2.Text = "Lab Item Name :";
            this.theme1.SetTheme(this.label2, "(default)");
            // 
            // cboDocGroupName
            // 
            this.cboDocGroupName.AllowSpinLoop = false;
            this.cboDocGroupName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboDocGroupName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cboDocGroupName.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.cboDocGroupName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboDocGroupName.GapHeight = 0;
            this.cboDocGroupName.ImagePadding = new System.Windows.Forms.Padding(0);
            this.cboDocGroupName.ItemsDisplayMember = "";
            this.cboDocGroupName.ItemsValueMember = "";
            this.cboDocGroupName.Location = new System.Drawing.Point(125, 58);
            this.cboDocGroupName.Name = "cboDocGroupName";
            this.cboDocGroupName.Size = new System.Drawing.Size(381, 20);
            this.cboDocGroupName.Style.DropDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cboDocGroupName.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro;
            this.cboDocGroupName.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboDocGroupName.TabIndex = 570;
            this.cboDocGroupName.Tag = null;
            this.theme1.SetTheme(this.cboDocGroupName, "(default)");
            this.cboDocGroupName.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // txtDocGroupSubName
            // 
            this.txtDocGroupSubName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDocGroupSubName.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtDocGroupSubName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtDocGroupSubName.Location = new System.Drawing.Point(125, 84);
            this.txtDocGroupSubName.Name = "txtDocGroupSubName";
            this.txtDocGroupSubName.Size = new System.Drawing.Size(381, 20);
            this.txtDocGroupSubName.TabIndex = 563;
            this.txtDocGroupSubName.Tag = null;
            this.theme1.SetTheme(this.txtDocGroupSubName, "(default)");
            this.txtDocGroupSubName.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // txtPasswordVoid
            // 
            this.txtPasswordVoid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPasswordVoid.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtPasswordVoid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtPasswordVoid.Location = new System.Drawing.Point(250, 281);
            this.txtPasswordVoid.Name = "txtPasswordVoid";
            this.txtPasswordVoid.PasswordChar = '*';
            this.txtPasswordVoid.Size = new System.Drawing.Size(78, 20);
            this.txtPasswordVoid.TabIndex = 569;
            this.txtPasswordVoid.Tag = null;
            this.theme1.SetTheme(this.txtPasswordVoid, "(default)");
            this.txtPasswordVoid.Visible = false;
            this.txtPasswordVoid.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::clinic_ivf.Properties.Resources.accept_database24;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(407, 395);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 39);
            this.btnSave.TabIndex = 564;
            this.btnSave.Text = "บันทึกช้อมูล";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.theme1.SetTheme(this.btnSave, "(default)");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // btnNew
            // 
            this.btnNew.Image = global::clinic_ivf.Properties.Resources.custom_reports24;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(407, 118);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(83, 39);
            this.btnNew.TabIndex = 568;
            this.btnNew.Text = "เพิ่มช้อมูล";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.theme1.SetTheme(this.btnNew, "(default)");
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::clinic_ivf.Properties.Resources.lock24;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(407, 163);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(83, 39);
            this.btnEdit.TabIndex = 565;
            this.btnEdit.Text = "แก้ไขช้อมูล";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.theme1.SetTheme(this.btnEdit, "(default)");
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // chkVoid
            // 
            this.chkVoid.BackColor = System.Drawing.Color.Transparent;
            this.chkVoid.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.chkVoid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkVoid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkVoid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.chkVoid.Location = new System.Drawing.Point(250, 252);
            this.chkVoid.Name = "chkVoid";
            this.chkVoid.Padding = new System.Windows.Forms.Padding(4, 1, 1, 1);
            this.chkVoid.Size = new System.Drawing.Size(155, 24);
            this.chkVoid.TabIndex = 567;
            this.chkVoid.Text = "ต้องการยกเลิกรายการ";
            this.theme1.SetTheme(this.chkVoid, "(default)");
            this.chkVoid.UseVisualStyleBackColor = true;
            this.chkVoid.Value = null;
            this.chkVoid.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // btnVoid
            // 
            this.btnVoid.Image = global::clinic_ivf.Properties.Resources.trash24;
            this.btnVoid.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVoid.Location = new System.Drawing.Point(407, 351);
            this.btnVoid.Name = "btnVoid";
            this.btnVoid.Size = new System.Drawing.Size(83, 39);
            this.btnVoid.TabIndex = 566;
            this.btnVoid.Text = "ยกเลิกช้อมูล";
            this.btnVoid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.theme1.SetTheme(this.btnVoid, "(default)");
            this.btnVoid.UseVisualStyleBackColor = true;
            this.btnVoid.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // chkShowQty
            // 
            this.chkShowQty.BackColor = System.Drawing.Color.Transparent;
            this.chkShowQty.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.chkShowQty.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkShowQty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkShowQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.chkShowQty.Location = new System.Drawing.Point(125, 136);
            this.chkShowQty.Name = "chkShowQty";
            this.chkShowQty.Padding = new System.Windows.Forms.Padding(4, 1, 1, 1);
            this.chkShowQty.Size = new System.Drawing.Size(203, 24);
            this.chkShowQty.TabIndex = 574;
            this.chkShowQty.Text = "ต้องการให้แสดง qty ที่การเงิน";
            this.theme1.SetTheme(this.chkShowQty, "(default)");
            this.chkShowQty.UseVisualStyleBackColor = true;
            this.chkShowQty.Value = null;
            this.chkShowQty.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // FrmLabItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 711);
            this.Controls.Add(this.sCMain);
            this.Controls.Add(this.sB);
            this.Name = "FrmLabItem";
            this.Text = "FrmLabItem";
            this.Load += new System.EventHandler(this.FrmLabItem_Load);
            this.sB.ResumeLayout(false);
            this.sB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sCMain)).EndInit();
            this.sCMain.ResumeLayout(false);
            this.c1SplitterPanel1.ResumeLayout(false);
            this.c1SplitterPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDocGroupName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocGroupSubName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswordVoid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkVoid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVoid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowQty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip sB;
        private System.Windows.Forms.ToolStripStatusLabel sB1;
        private C1.Win.C1Themes.C1ThemeController theme1;
        private C1.Win.C1SplitContainer.C1SplitContainer sCMain;
        private C1.Win.C1SplitContainer.C1SplitterPanel c1SplitterPanel1;
        private System.Windows.Forms.Panel panel1;
        private C1.Win.C1SplitContainer.C1SplitterPanel c1SplitterPanel2;
        private System.Windows.Forms.Panel panel2;
        private C1.Win.C1Input.C1TextBox txtID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private C1.Win.C1Input.C1ComboBox cboDocGroupName;
        private C1.Win.C1Input.C1TextBox txtDocGroupSubName;
        private C1.Win.C1Input.C1TextBox txtPasswordVoid;
        private C1.Win.C1Input.C1Button btnSave;
        private C1.Win.C1Input.C1Button btnNew;
        private C1.Win.C1Input.C1Button btnEdit;
        private C1.Win.C1Input.C1CheckBox chkVoid;
        private C1.Win.C1Input.C1Button btnVoid;
        private System.Windows.Forms.Label label3;
        private C1.Win.C1Input.C1TextBox txtPrice;
        private C1.Win.C1Input.C1CheckBox chkShowQty;
    }
}