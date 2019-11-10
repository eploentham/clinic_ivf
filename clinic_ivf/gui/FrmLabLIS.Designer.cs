namespace clinic_ivf.gui
{
    partial class FrmLabLIS
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLabLIS));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuShow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.c1Label1 = new C1.Win.C1Input.C1Label();
            this.BtnConnect = new C1.Win.C1Input.C1Button();
            this.cboPORT = new C1.Win.C1Input.C1ComboBox();
            this.cboBAUDRATE = new C1.Win.C1Input.C1ComboBox();
            this.c1Label2 = new C1.Win.C1Input.C1Label();
            this.cboSTOPBIT = new C1.Win.C1Input.C1ComboBox();
            this.c1Label3 = new C1.Win.C1Input.C1Label();
            this.c1Label4 = new C1.Win.C1Input.C1Label();
            this.cboDATABIT = new C1.Win.C1Input.C1ComboBox();
            this.c1Label5 = new C1.Win.C1Input.C1Label();
            this.cboParity = new C1.Win.C1Input.C1ComboBox();
            this.c1Label6 = new C1.Win.C1Input.C1Label();
            this.cboHandshake = new C1.Win.C1Input.C1ComboBox();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnConnect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPORT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBAUDRATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSTOPBIT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDATABIT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboParity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboHandshake)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuShow,
            this.menuExit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(104, 48);
            // 
            // menuShow
            // 
            this.menuShow.Name = "menuShow";
            this.menuShow.Size = new System.Drawing.Size(103, 22);
            this.menuShow.Text = "Show";
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(103, 22);
            this.menuExit.Text = "Exit";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.c1Label6);
            this.groupBox1.Controls.Add(this.cboHandshake);
            this.groupBox1.Controls.Add(this.c1Label5);
            this.groupBox1.Controls.Add(this.cboParity);
            this.groupBox1.Controls.Add(this.c1Label4);
            this.groupBox1.Controls.Add(this.cboDATABIT);
            this.groupBox1.Controls.Add(this.c1Label3);
            this.groupBox1.Controls.Add(this.cboSTOPBIT);
            this.groupBox1.Controls.Add(this.c1Label2);
            this.groupBox1.Controls.Add(this.cboBAUDRATE);
            this.groupBox1.Controls.Add(this.cboPORT);
            this.groupBox1.Controls.Add(this.BtnConnect);
            this.groupBox1.Controls.Add(this.c1Label1);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(966, 209);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Config";
            // 
            // c1Label1
            // 
            this.c1Label1.AutoSize = true;
            this.c1Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.c1Label1.Location = new System.Drawing.Point(12, 30);
            this.c1Label1.Name = "c1Label1";
            this.c1Label1.Size = new System.Drawing.Size(43, 13);
            this.c1Label1.TabIndex = 0;
            this.c1Label1.Tag = null;
            // 
            // BtnConnect
            // 
            this.BtnConnect.Location = new System.Drawing.Point(885, 130);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(75, 23);
            this.BtnConnect.TabIndex = 1;
            this.BtnConnect.Text = "Close";
            this.BtnConnect.UseVisualStyleBackColor = true;
            // 
            // cboPORT
            // 
            this.cboPORT.AllowSpinLoop = false;
            this.cboPORT.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.cboPORT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cboPORT.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.cboPORT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboPORT.GapHeight = 0;
            this.cboPORT.ImagePadding = new System.Windows.Forms.Padding(0);
            this.cboPORT.ItemsDisplayMember = "";
            this.cboPORT.ItemsValueMember = "";
            this.cboPORT.Location = new System.Drawing.Point(92, 23);
            this.cboPORT.Name = "cboPORT";
            this.cboPORT.Size = new System.Drawing.Size(139, 24);
            this.cboPORT.Style.DropDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cboPORT.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro;
            this.cboPORT.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboPORT.TabIndex = 531;
            this.cboPORT.Tag = null;
            this.cboPORT.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // cboBAUDRATE
            // 
            this.cboBAUDRATE.AllowSpinLoop = false;
            this.cboBAUDRATE.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.cboBAUDRATE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cboBAUDRATE.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.cboBAUDRATE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboBAUDRATE.GapHeight = 0;
            this.cboBAUDRATE.ImagePadding = new System.Windows.Forms.Padding(0);
            this.cboBAUDRATE.ItemsDisplayMember = "";
            this.cboBAUDRATE.ItemsValueMember = "";
            this.cboBAUDRATE.Location = new System.Drawing.Point(92, 53);
            this.cboBAUDRATE.Name = "cboBAUDRATE";
            this.cboBAUDRATE.Size = new System.Drawing.Size(139, 24);
            this.cboBAUDRATE.Style.DropDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cboBAUDRATE.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro;
            this.cboBAUDRATE.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboBAUDRATE.TabIndex = 532;
            this.cboBAUDRATE.Tag = null;
            this.cboBAUDRATE.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // c1Label2
            // 
            this.c1Label2.AutoSize = true;
            this.c1Label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.c1Label2.Location = new System.Drawing.Point(12, 60);
            this.c1Label2.Name = "c1Label2";
            this.c1Label2.Size = new System.Drawing.Size(75, 13);
            this.c1Label2.TabIndex = 533;
            this.c1Label2.Tag = null;
            // 
            // cboSTOPBIT
            // 
            this.cboSTOPBIT.AllowSpinLoop = false;
            this.cboSTOPBIT.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.cboSTOPBIT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cboSTOPBIT.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.cboSTOPBIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboSTOPBIT.GapHeight = 0;
            this.cboSTOPBIT.ImagePadding = new System.Windows.Forms.Padding(0);
            this.cboSTOPBIT.ItemsDisplayMember = "";
            this.cboSTOPBIT.ItemsValueMember = "";
            this.cboSTOPBIT.Location = new System.Drawing.Point(92, 113);
            this.cboSTOPBIT.Name = "cboSTOPBIT";
            this.cboSTOPBIT.Size = new System.Drawing.Size(139, 24);
            this.cboSTOPBIT.Style.DropDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cboSTOPBIT.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro;
            this.cboSTOPBIT.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboSTOPBIT.TabIndex = 534;
            this.cboSTOPBIT.Tag = null;
            this.cboSTOPBIT.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // c1Label3
            // 
            this.c1Label3.AutoSize = true;
            this.c1Label3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.c1Label3.Location = new System.Drawing.Point(12, 120);
            this.c1Label3.Name = "c1Label3";
            this.c1Label3.Size = new System.Drawing.Size(62, 13);
            this.c1Label3.TabIndex = 535;
            this.c1Label3.Tag = null;
            // 
            // c1Label4
            // 
            this.c1Label4.AutoSize = true;
            this.c1Label4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.c1Label4.Location = new System.Drawing.Point(12, 90);
            this.c1Label4.Name = "c1Label4";
            this.c1Label4.Size = new System.Drawing.Size(62, 13);
            this.c1Label4.TabIndex = 537;
            this.c1Label4.Tag = null;
            // 
            // cboDATABIT
            // 
            this.cboDATABIT.AllowSpinLoop = false;
            this.cboDATABIT.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.cboDATABIT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cboDATABIT.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.cboDATABIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboDATABIT.GapHeight = 0;
            this.cboDATABIT.ImagePadding = new System.Windows.Forms.Padding(0);
            this.cboDATABIT.ItemsDisplayMember = "";
            this.cboDATABIT.ItemsValueMember = "";
            this.cboDATABIT.Location = new System.Drawing.Point(92, 83);
            this.cboDATABIT.Name = "cboDATABIT";
            this.cboDATABIT.Size = new System.Drawing.Size(139, 24);
            this.cboDATABIT.Style.DropDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cboDATABIT.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro;
            this.cboDATABIT.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboDATABIT.TabIndex = 536;
            this.cboDATABIT.Tag = null;
            this.cboDATABIT.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // c1Label5
            // 
            this.c1Label5.AutoSize = true;
            this.c1Label5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.c1Label5.Location = new System.Drawing.Point(12, 150);
            this.c1Label5.Name = "c1Label5";
            this.c1Label5.Size = new System.Drawing.Size(39, 13);
            this.c1Label5.TabIndex = 539;
            this.c1Label5.Tag = null;
            // 
            // cboParity
            // 
            this.cboParity.AllowSpinLoop = false;
            this.cboParity.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.cboParity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cboParity.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.cboParity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboParity.GapHeight = 0;
            this.cboParity.ImagePadding = new System.Windows.Forms.Padding(0);
            this.cboParity.ItemsDisplayMember = "";
            this.cboParity.ItemsValueMember = "";
            this.cboParity.Location = new System.Drawing.Point(92, 143);
            this.cboParity.Name = "cboParity";
            this.cboParity.Size = new System.Drawing.Size(139, 24);
            this.cboParity.Style.DropDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cboParity.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro;
            this.cboParity.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboParity.TabIndex = 538;
            this.cboParity.Tag = null;
            this.cboParity.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // c1Label6
            // 
            this.c1Label6.AutoSize = true;
            this.c1Label6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.c1Label6.Location = new System.Drawing.Point(12, 180);
            this.c1Label6.Name = "c1Label6";
            this.c1Label6.Size = new System.Drawing.Size(68, 13);
            this.c1Label6.TabIndex = 541;
            this.c1Label6.Tag = null;
            // 
            // cboHandshake
            // 
            this.cboHandshake.AllowSpinLoop = false;
            this.cboHandshake.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.cboHandshake.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cboHandshake.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.cboHandshake.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboHandshake.GapHeight = 0;
            this.cboHandshake.ImagePadding = new System.Windows.Forms.Padding(0);
            this.cboHandshake.ItemsDisplayMember = "";
            this.cboHandshake.ItemsValueMember = "";
            this.cboHandshake.Location = new System.Drawing.Point(92, 173);
            this.cboHandshake.Name = "cboHandshake";
            this.cboHandshake.Size = new System.Drawing.Size(139, 24);
            this.cboHandshake.Style.DropDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cboHandshake.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro;
            this.cboHandshake.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboHandshake.TabIndex = 540;
            this.cboHandshake.Tag = null;
            this.cboHandshake.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // FrmLabLIS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 609);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLabLIS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmLabLIS";
            this.Load += new System.EventHandler(this.FrmLabLIS_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnConnect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPORT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBAUDRATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSTOPBIT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDATABIT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboParity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboHandshake)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuShow;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.GroupBox groupBox1;
        private C1.Win.C1Input.C1Button BtnConnect;
        private C1.Win.C1Input.C1Label c1Label1;
        private C1.Win.C1Input.C1ComboBox cboPORT;
        private C1.Win.C1Input.C1Label c1Label2;
        private C1.Win.C1Input.C1ComboBox cboBAUDRATE;
        private C1.Win.C1Input.C1Label c1Label3;
        private C1.Win.C1Input.C1ComboBox cboSTOPBIT;
        private C1.Win.C1Input.C1Label c1Label4;
        private C1.Win.C1Input.C1ComboBox cboDATABIT;
        private C1.Win.C1Input.C1Label c1Label5;
        private C1.Win.C1Input.C1ComboBox cboParity;
        private C1.Win.C1Input.C1Label c1Label6;
        private C1.Win.C1Input.C1ComboBox cboHandshake;
    }
}