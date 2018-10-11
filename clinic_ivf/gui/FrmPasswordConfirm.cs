using C1.Win.C1Input;
using C1.Win.C1Themes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using clinic_ivf.control;

namespace clinic_ivf.gui
{
    public partial class FrmPasswordConfirm:Form
    {
        IvfControl xC;

        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;

        Label label1 = new System.Windows.Forms.Label();
        C1TextBox txtPassword = new C1.Win.C1Input.C1TextBox();
        C1ThemeController theme1;
        public FrmPasswordConfirm(IvfControl x)
        {
            xC = x;
            initControl();
        }
        private void initControl()
        {
            this.Width = 250;
            this.Height = 120;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            label1 = new System.Windows.Forms.Label();
            txtPassword = new C1.Win.C1Input.C1TextBox();
            theme1 = new C1.Win.C1Themes.C1ThemeController();
            theme1.Theme = "Office2013Red";

            C1ThemeController.ApplicationTheme = xC.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;

            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            label1.Location = new System.Drawing.Point(10, 20);
            //label1.Size = new System.Drawing.Size(68, 16);
            label1.TabIndex = 0;
            label1.Text = "รหัสผ่าน :";

            txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtPassword.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            txtPassword.Location = new System.Drawing.Point(80, 20);
            txtPassword.Name = "txtContFNameE";
            txtPassword.Size = new System.Drawing.Size(100, 20);
            txtPassword.TabIndex = 84;
            txtPassword.Tag = null;
            txtPassword.PasswordChar = '*';
            txtPassword.KeyUp += new KeyEventHandler(this.txtPassword_KeyUp);
            theme1.SetTheme(this.txtPassword, "(default)");


            this.StartPosition = FormStartPosition.CenterParent;

            this.Controls.Add(label1);
            this.Controls.Add(txtPassword);
        }
        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtPassword.Text.Length >= 4)
            {
                MessageBox.Show("Password "+txtPassword.Text, "");
                this.Dispose();
            }
        }
    }
}
