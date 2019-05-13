namespace clinic_ivf.gui
{
    partial class FrmStockOnhand
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
            this.sB = new System.Windows.Forms.StatusStrip();
            this.sB1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnStock = new System.Windows.Forms.Panel();
            this.cboStkSubName = new C1.Win.C1Input.C1ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).BeginInit();
            this.sB.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboStkSubName)).BeginInit();
            this.SuspendLayout();
            // 
            // theme1
            // 
            this.theme1.Theme = "Office2013Red";
            // 
            // sB
            // 
            this.sB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.sB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sB1});
            this.sB.Location = new System.Drawing.Point(0, 692);
            this.sB.Name = "sB";
            this.sB.Size = new System.Drawing.Size(1112, 22);
            this.sB.TabIndex = 530;
            this.sB.Text = "statusStrip1";
            this.theme1.SetTheme(this.sB, "(default)");
            // 
            // sB1
            // 
            this.sB1.Name = "sB1";
            this.sB1.Size = new System.Drawing.Size(118, 17);
            this.sB1.Text = "toolStripStatusLabel1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.cboStkSubName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1112, 42);
            this.panel1.TabIndex = 531;
            this.theme1.SetTheme(this.panel1, "(default)");
            // 
            // pnStock
            // 
            this.pnStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnStock.Location = new System.Drawing.Point(0, 42);
            this.pnStock.Name = "pnStock";
            this.pnStock.Size = new System.Drawing.Size(1112, 650);
            this.pnStock.TabIndex = 532;
            this.theme1.SetTheme(this.pnStock, "(default)");
            // 
            // cboStkSubName
            // 
            this.cboStkSubName.AllowSpinLoop = false;
            this.cboStkSubName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cboStkSubName.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.cboStkSubName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboStkSubName.GapHeight = 0;
            this.cboStkSubName.ImagePadding = new System.Windows.Forms.Padding(0);
            this.cboStkSubName.ItemsDisplayMember = "";
            this.cboStkSubName.ItemsValueMember = "";
            this.cboStkSubName.Location = new System.Drawing.Point(66, 10);
            this.cboStkSubName.Name = "cboStkSubName";
            this.cboStkSubName.Size = new System.Drawing.Size(253, 20);
            this.cboStkSubName.Style.DropDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cboStkSubName.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro;
            this.cboStkSubName.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboStkSubName.TabIndex = 923;
            this.cboStkSubName.Tag = null;
            this.theme1.SetTheme(this.cboStkSubName, "(default)");
            this.cboStkSubName.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label3.Location = new System.Drawing.Point(6, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 922;
            this.label3.Text = "แผนก :";
            this.theme1.SetTheme(this.label3, "(default)");
            // 
            // FrmStockOnhand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 714);
            this.Controls.Add(this.pnStock);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sB);
            this.Name = "FrmStockOnhand";
            this.Text = "FrmStockOnhand";
            this.Load += new System.EventHandler(this.FrmStockOnhand_Load);
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).EndInit();
            this.sB.ResumeLayout(false);
            this.sB.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboStkSubName)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Themes.C1ThemeController theme1;
        private System.Windows.Forms.StatusStrip sB;
        private System.Windows.Forms.ToolStripStatusLabel sB1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnStock;
        private C1.Win.C1Input.C1ComboBox cboStkSubName;
        private System.Windows.Forms.Label label3;
    }
}