namespace clinic_ivf.gui
{
    partial class FrmNurseLabNote
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboRemark = new C1.Win.C1Input.C1ComboBox();
            this.btnSave = new C1.Win.C1Input.C1Button();
            ((System.ComponentModel.ISupportInitialize)(this.cboRemark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Note :";
            // 
            // cboRemark
            // 
            this.cboRemark.AllowSpinLoop = false;
            this.cboRemark.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.cboRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cboRemark.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.cboRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboRemark.GapHeight = 0;
            this.cboRemark.ImagePadding = new System.Windows.Forms.Padding(0);
            this.cboRemark.ItemsDisplayMember = "";
            this.cboRemark.ItemsValueMember = "";
            this.cboRemark.Location = new System.Drawing.Point(106, 16);
            this.cboRemark.Name = "cboRemark";
            this.cboRemark.Size = new System.Drawing.Size(426, 24);
            this.cboRemark.Style.DropDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cboRemark.Style.DropDownBorderColor = System.Drawing.Color.Gainsboro;
            this.cboRemark.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboRemark.TabIndex = 922;
            this.cboRemark.Tag = null;
            this.cboRemark.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::clinic_ivf.Properties.Resources.download_database24;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(449, 59);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 39);
            this.btnSave.TabIndex = 925;
            this.btnSave.Text = "บันทึกช้อมูล";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // FrmNurseLabNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 206);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cboRemark);
            this.Controls.Add(this.label1);
            this.Name = "FrmNurseLabNote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmNurseLabNote";
            this.Load += new System.EventHandler(this.FrmNurseLabNote_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboRemark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private C1.Win.C1Input.C1ComboBox cboRemark;
        private C1.Win.C1Input.C1Button btnSave;
    }
}