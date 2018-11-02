using C1.Win.C1Input;
using C1.Win.C1SuperTooltip;
using clinic_ivf.control;
using clinic_ivf.objdb;
using clinic_ivf.object1;
using clinic_ivf.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.gui
{
    public partial class Login : Form
    {
        public String LogonSuccessful = "";
        Staff stf;

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;

        IvfControl ic;
        FrmSplash splash;

        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        StaffDB stfDB;

        public Login(IvfControl ic, FrmSplash splash)
        {
            InitializeComponent();
            this.ic = ic;
            this.splash = splash;
            initConfig();
        }
        private void initConfig()
        {
            txtUserName.KeyUp += TxtUserName_KeyUp;
            txtUserName.LostFocus += TxtUserName_LostFocus;
            txtUserName.Enter += TxtUserName_Enter;
            txtPassword.KeyUp += TxtPassword_KeyUp;
            txtPassword.Enter += TxtUserName_Enter;
            btnOk.Click += BtnOk_Click;
            bg = txtUserName.BackColor;
            fc = txtUserName.ForeColor;

            //theme1.SetTheme(panel1, "Office2013Red");
            //theme1.SetTheme(label2, "Office2010Blue");
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            stfDB = new StaffDB(ic.conn);
            //stt.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.Gold;
            //stt.
        }

        //private void TxtPassword_Enter(object sender, EventArgs e)
        //{
        //    //throw new NotImplementedException();
        //    C1TextBox a = (C1TextBox)sender;
        //    a.BackColor = ic.cTxtFocus;
        //}

        private void TxtUserName_Enter(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            C1TextBox a = (C1TextBox)sender;
            a.BackColor = ic.cTxtFocus;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            stf = stfDB.selectByLogin(txtUserName.Text, txtPassword.Text);
            if (stf.staff_fname_t.Length > 0)
            {
                ic.userId = stf.staff_id;
                ic.user = stf;
                ic.conn.user = stf;
                LogonSuccessful = "1";
                this.Dispose();
            }
            else
            {
                //stt.Show("ไม่พบ username หรือ password", txtPassword);
                sep.SetError(txtPassword, "333");
                LogonSuccessful = "0";
            }
        }

        private void TxtUserName_LostFocus(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            C1TextBox a = (C1TextBox)sender;
            a.BackColor = bg;
            //a.ForeColor = fc;
            //a.Font = new Font(ff, FontStyle.Regular);
            chkLogin();
        }

        private void TxtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.Enter)
            {
                btnOk.Focus();
            }
        }

        private void TxtUserName_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.Enter)
            {
                chkLogin();
            }
        }
        private void chkLogin()
        {
            Staff stf1 = new Staff();
            
            stf1 = stfDB.selectByUsername(txtUserName.Text);
            if (stf1.staff_fname_t.Length > 0)
            {
                btnOk.Image = Resources.Accept_Male_User24;
                stt.Show("<p><b>สวัสดี</b></p>คุณ " + stf1.staff_fname_t + " " + stf1.staff_lname_t + "<br> กรุณา ป้อนรหัสผ่าน", txtUserName);

                //stt.SetToolTip(txtUserName, "<p><b>สวัสดี</b></p>คุณ " + stf1.staff_fname_t + " " + stf1.staff_lname_t + "<br> กรุณา ป้อนรหัสผ่าน");
                sep.Clear();
                txtPassword.Focus();
            }
            else
            {
                btnOk.Image = Resources.Male_User_Warning24;
                //stt.Show("ไม่พบ username ", txtUserName);
                //stt.SetToolTip(txtUserName, "ไม่พบ username ");
                sep.SetError(txtUserName, "333");
            }
        }
        private void Login_Load(object sender, EventArgs e)
        {
            //if (ic.iniC.statusAppDonor.Equals("1"))
            //{
            theme1.SetTheme(this, ic.theme);
            theme1.SetTheme(panel1, ic.theme);
            foreach (Control c in panel1.Controls)
            {
                theme1.SetTheme(c,ic.theme);
            }
            bg = txtUserName.BackColor;
            fc = txtUserName.ForeColor;
            //}
            //else
            //{
            //    theme1.SetTheme(this, "Office2007Blue");
            //    theme1.SetTheme(panel1, "Office2007Blue");
            //    foreach (Control c in panel1.Controls)
            //    {
            //        theme1.SetTheme(c, "Office2007Blue");
            //    }
            //}
        }
    }
}
