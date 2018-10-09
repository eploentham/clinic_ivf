using C1.Win.C1Input;
using C1.Win.C1Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using clinic_ivf.control;
using clinic_ivf.object1;
using clinic_ivf.Properties;

namespace clinic_ivf.gui
{
    public partial class FrmDepartmentS : Form
    {
        IvfControl ic;
        Department dept;

        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;
        int colID = 1, colCode = 2, colName = 3, colRemark = 4, colE = 5, colS = 6, coledit = 7, colCnt = 7;

        Boolean flagEdit = false;

        public FrmDepartmentS(IvfControl ic)
        {
            InitializeComponent();
            this.ic = ic;
            initConfig();
        }        

        private void initConfig()
        {
            dept = new Department();
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);

            C1ThemeController.ApplicationTheme = ic.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;
            theme1.SetTheme(sB, "BeigeOne");
            foreach (Control c in panel1.Controls)
            {
                theme1.SetTheme(c, "Office2013Red");
            }

            bg = txtDeptCode.BackColor;
            fc = txtDeptCode.ForeColor;
            ff = txtDeptCode.Font;

            
            setControlEnable(false);
            setFocusColor();
            setControl(ic.deptID);
            sB1.Text = "";
            btnVoid.Hide();
        }        

        private void textBox_Enter(object sender, EventArgs e)
        {
            C1TextBox a = (C1TextBox)sender;
            a.BackColor = ic.cTxtFocus;
            a.Font = new Font(ff, FontStyle.Bold);
        }        

        private void textBox_Leave(object sender, EventArgs e)
        {
            C1TextBox a = (C1TextBox)sender;
            a.BackColor = bg;
            a.ForeColor = fc;
            a.Font = new Font(ff, FontStyle.Regular);
        }
        private void setFocusColor()
        {
            this.txtDeptCode.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtDeptCode.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtDeptNameT.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtDeptNameT.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtRemark.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtRemark.Enter += new System.EventHandler(this.textBox_Enter);
        }
        private void setControl(String deptId)
        {
            dept = ic.ivfDB.deptDB.selectByPk1(deptId);
            txtID.Value = dept.dept_id;
            txtDeptCode.Value = dept.depart_code;
            txtDeptNameT.Value = dept.depart_name_t;
            txtRemark.Value = dept.remark;
        }
        private void setControlEnable(Boolean flag)
        {
            //txtID.Enabled = flag;
            txtDeptCode.Enabled = flag;
            txtDeptNameT.Enabled = flag;
            txtRemark.Enabled = flag;
        }
        private void setDeptment()
        {
            dept.dept_id = txtID.Text;
            dept.depart_code = txtDeptCode.Text;
            dept.depart_name_t = txtDeptNameT.Text;
            dept.remark = txtRemark.Text;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtID.Value = "";
            txtDeptCode.Value = "";
            txtDeptNameT.Value = "";
            txtRemark.Value = "";
            chkVoid.Checked = false;
            btnVoid.Hide();
            setControlEnable(true);
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            flagEdit = flagEdit ? false : true;
            setControlEnable(flagEdit);
        }
        private void btnVoid_Click(object sender, EventArgs e)
        {
            
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setDeptment();
                String re = ic.ivfDB.deptDB.insertDepartment(dept, ic.user.staff_id);
                int chk = 0;
                if (int.TryParse(re, out chk))
                {
                    btnSave.Image = Resources.accept_database24;
                }
                else
                {
                    btnSave.Image = Resources.accept_database24;
                }
                //setGrfDeptH();
                //setGrdView();
                //this.Dispose();
            }
        }
        private void chkVoid_Click(object sender, EventArgs e)
        {
            if (btnVoid.Visible)
            {
                btnVoid.Hide();
            }
            else
            {
                btnVoid.Show();
            }
        }
        private void FrmDepartmentS_Load(object sender, EventArgs e)
        {

        }
    }
}
