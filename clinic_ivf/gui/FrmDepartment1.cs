using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1SuperTooltip;
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
    public partial class FrmDepartment1 : Form
    {
        IvfControl ic;
        Department dept;

        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;
        int colID = 1, colCode = 2, colName = 3, colRemark = 4, colE = 5, colS = 6, coledit = 7, colCnt = 7;

        C1FlexGrid grfDept;
        //C1TextBox txtPassword = new C1.Win.C1Input.C1TextBox();
        Boolean flagEdit = false;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        String userIdVoid = "";
        public FrmDepartment1(IvfControl ic)
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
            foreach(Control c in panel3.Controls)
            {
                theme1.SetTheme(c, "Office2013Red");
            }

            bg = txtDeptCode.BackColor;
            fc = txtDeptCode.ForeColor;
            ff = txtDeptCode.Font;
            
            txtPasswordVoid.KeyUp += TxtPasswordVoid_KeyUp;

            initGrfDept();
            setGrfDeptH();
            setControlEnable(false);
            setFocusColor();
            sB1.Text = "";
            btnVoid.Hide();
            txtPasswordVoid.Hide();
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            //stt.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.Gold;
        }
        
        private void initGrfDept()
        {
            grfDept = new C1FlexGrid();
            grfDept.Font = fEdit;
            grfDept.Dock = System.Windows.Forms.DockStyle.Fill;
            grfDept.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfDept);

            grfDept.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grfDept_AfterRowColChange);
            grfDept.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            grfDept.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);

            panel2.Controls.Add(this.grfDept);

            C1Theme theme = C1ThemeController.GetThemeByName("Office2013Red", false);
            C1ThemeController.ApplyThemeToObject(grfDept, theme);
        }
        private void setGrfDeptH()
        {

            //grfDept.Rows.Count = 7;

            grfDept.DataSource = ic.ivfDB.deptDB.selectAll1();
            grfDept.Cols.Count = colCnt;
            CellStyle cs = grfDept.Styles.Add("btn");
            cs.DataType = typeof(Button);
            //cs.ComboList = "|Tom|Dick|Harry";
            cs.ForeColor = Color.Navy;
            cs.Font = new Font(Font, FontStyle.Bold);
            cs = grfDept.Styles.Add("date");
            cs.DataType = typeof(DateTime);
            cs.Format = "dd-MMM-yy";
            cs.ForeColor = Color.DarkGoldenrod;

            grfDept.Cols[colE].Style = grfDept.Styles["btn"];
            grfDept.Cols[colS].Style = grfDept.Styles["date"];

            grfDept.Cols[colID].Width = 60;

            grfDept.Cols[colE].Width = 100;
            grfDept.Cols[colS].Width = 100;

            grfDept.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfDept.Cols[colCode].Caption = "รหัส";
            grfDept.Cols[colName].Caption = "ชื่อแผนก";
            grfDept.Cols[colRemark].Caption = "หมายเหตุ";
            //grfDept.Cols[coledit].Visible = false;
            if (grfDept.Rows.Count > 2)
            {
                //CellRange rg = grfDept.GetCellRange(2, colE);
                //rg.Style = grfDept.Styles["btn"];
                for (int i = 1; i < grfDept.Rows.Count; i++)
                {
                    grfDept[i, 0] = i;
                    if (i % 2 == 0)
                        grfDept.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
                }
            }

            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            grfDept.Cols[colID].Visible = false;
            grfDept.Cols[colE].Visible = false;
            grfDept.Cols[colS].Visible = false;
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
        
        private void chkVoid_Click(object sender, EventArgs e)
        {
            if (btnVoid.Visible)
            {
                btnVoid.Hide();
            }
            else
            {
                //btnVoid.Show();
                txtPasswordVoid.Show();
                txtPasswordVoid.Focus();
                //stt.Show("<p><b>ต้องการยกเลิก</b></p> <br> กรุณาป้อนรหัสผ่าน", txtPasswordVoid);
            }
        }

        private void btnVoid_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ต้องการ ยกเลิกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                ic.ivfDB.deptDB.VoidDepartment(txtID.Text, userIdVoid);
                setGrfDeptH();
            }
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
            chkVoid.Enabled = flag;
            btnEdit.Image = !flag ? Resources.lock24 : Resources.open24;
        }
        private void setDeptment()
        {
            dept.dept_id = txtID.Text;
            dept.depart_code = txtDeptCode.Text;
            dept.depart_name_t = txtDeptNameT.Text;
            dept.remark = txtRemark.Text;
        }
        private void grfDept_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;

            String deptId = "";
            deptId = grfDept[e.NewRange.r1, colID] != null ? grfDept[e.NewRange.r1, colID].ToString() : "";
            setControl(deptId);
            setControlEnable(false);
            //setControlAddr(addrId);
            //setControlAddrEnable(false);
        }
        private void grfDept_CellButtonClick(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {

        }
        private void grfDept_CellChanged(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            //if (e.Row == 0) return;
            //CellStyle cs = grfDept.Styles.Add("text");
            //cs.BackColor = Color.DimGray;
            //sB1.Text = grfDept[e.Row, e.Col].ToString();
            ////grfDept[e.Row, coledit] = "1";
            //grfDept.Rows[e.Row].Style = cs;
            //if((e.Row+1) == ((RowCollection)grfDept.Rows).Count)
            //{
            //    ((RowCollection)grfDept.Rows).Count = ((RowCollection)grfDept.Rows).Count + 1;
            //}
        }
        
        private void TxtPasswordVoid_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.Enter)
            {
                userIdVoid = ic.ivfDB.stfDB.selectByPasswordAdmin(txtPasswordVoid.Text.Trim());
                if (userIdVoid.Length>0)
                {
                    txtPasswordVoid.Hide();
                    btnVoid.Show();
                    //stt.Show("<p><b>ต้องการยกเลิก</b></p> <br> รหัสผ่านถูกต้อง", btnVoid);
                }
                else
                {
                    sep.SetError(txtPasswordVoid, "333");
                }
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            txtID.Value = "";
            txtDeptCode.Value = "";
            txtDeptNameT.Value = "";
            txtRemark.Value = "";
            chkVoid.Checked = false;
            btnVoid.Hide();
            flagEdit = true;
            setControlEnable(true);
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            flagEdit = true;
            setControlEnable(flagEdit);
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
                setGrfDeptH();
                //setGrdView();
                //this.Dispose();
            }
        }
        private void FrmDepartment1_Load(object sender, EventArgs e)
        {

        }
    }
}
