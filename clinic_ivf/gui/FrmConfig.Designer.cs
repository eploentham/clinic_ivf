namespace clinic_ivf.gui
{
    partial class FrmConfig
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
            this.btnLabLis = new C1.Win.C1Input.C1Button();
            this.lbPath = new C1.Win.C1Input.C1Label();
            this.txtFilename = new C1.Win.C1Input.C1TextBox();
            this.btnLabLisRmove = new C1.Win.C1Input.C1Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnLabLis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilename)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLabLisRmove)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLabLisRmove);
            this.groupBox1.Controls.Add(this.txtFilename);
            this.groupBox1.Controls.Add(this.lbPath);
            this.groupBox1.Controls.Add(this.btnLabLis);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LAB LIS";
            // 
            // btnLabLis
            // 
            this.btnLabLis.Image = global::clinic_ivf.Properties.Resources.laboratory_test_lab_medical_biology_research_tube_glass_chemical_48;
            this.btnLabLis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLabLis.Location = new System.Drawing.Point(47, 19);
            this.btnLabLis.Name = "btnLabLis";
            this.btnLabLis.Size = new System.Drawing.Size(257, 65);
            this.btnLabLis.TabIndex = 0;
            this.btnLabLis.Text = "run auto start LAB LIS servicve";
            this.btnLabLis.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLabLis.UseVisualStyleBackColor = true;
            // 
            // lbPath
            // 
            this.lbPath.AutoSize = true;
            this.lbPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbPath.Location = new System.Drawing.Point(337, 19);
            this.lbPath.Name = "lbPath";
            this.lbPath.Size = new System.Drawing.Size(51, 13);
            this.lbPath.TabIndex = 1;
            this.lbPath.Tag = null;
            // 
            // txtFilename
            // 
            this.txtFilename.Location = new System.Drawing.Point(369, 35);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(136, 18);
            this.txtFilename.TabIndex = 1;
            this.txtFilename.Tag = null;
            this.txtFilename.Value = "ivf_lis";
            // 
            // btnLabLisRmove
            // 
            this.btnLabLisRmove.Image = global::clinic_ivf.Properties.Resources.Remove_ticket_24;
            this.btnLabLisRmove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLabLisRmove.Location = new System.Drawing.Point(537, 19);
            this.btnLabLisRmove.Name = "btnLabLisRmove";
            this.btnLabLisRmove.Size = new System.Drawing.Size(257, 65);
            this.btnLabLisRmove.TabIndex = 2;
            this.btnLabLisRmove.Text = "remove start LAB LIS servicve";
            this.btnLabLisRmove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLabLisRmove.UseVisualStyleBackColor = true;
            // 
            // FrmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmConfig";
            this.Text = "FrmConfig";
            this.Load += new System.EventHandler(this.FrmConfig_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnLabLis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilename)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLabLisRmove)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private C1.Win.C1Input.C1Button btnLabLis;
        private C1.Win.C1Input.C1Label lbPath;
        private C1.Win.C1Input.C1TextBox txtFilename;
        private C1.Win.C1Input.C1Button btnLabLisRmove;
    }
}