using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1SuperTooltip;
using C1.Win.C1Themes;
using clinic_ivf.control;
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
    public partial class FrmLabOpuProce : Form
    {
        IvfControl ic;
        LabProcedure proce;

        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;
        int colID = 1, colCode = 2, colName = 3, colRemark = 4, colE = 5, colS = 6, coledit = 7, colCnt = 7;

        C1FlexGrid grfProce;
        //C1TextBox txtPassword = new C1.Win.C1Input.C1TextBox();
        Boolean flagEdit = false;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        String userIdVoid = "";
        //public enum StatusLab { OPUProcedure, FETProcedure};
        objdb.LabProcedureDB.StatusLab statusLab;

        public FrmLabOpuProce(IvfControl ic, objdb.LabProcedureDB.StatusLab statuslab)
        {
            InitializeComponent();
            this.ic = ic;
            statusLab = statuslab;
            initConfig();
        }
        private void initConfig()
        {
            proce = new LabProcedure();
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);

            C1ThemeController.ApplicationTheme = ic.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;
            theme1.SetTheme(sB, "BeigeOne");
            foreach (Control c in panel3.Controls)
            {
                theme1.SetTheme(c, "Office2013Red");
            }

            bg = txtProceCode.BackColor;
            fc = txtProceCode.ForeColor;
            ff = txtProceCode.Font;

            txtPasswordVoid.KeyUp += TxtPasswordVoid_KeyUp;
            chkVoid.Click += ChkVoid_Click;
            btnVoid.Click += BtnVoid_Click;
            btnNew.Click += BtnNew_Click;
            btnEdit.Click += BtnEdit_Click;
            btnSave.Click += BtnSave_Click;

            initGrfDept();
            setGrfDeptH();
            setControlEnable(false);
            setFocusColor();
            sB1.Text = "";
            btnVoid.Hide();
            txtPasswordVoid.Hide();
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            label1.Hide();
            txtProceCode.Hide();
            //stt.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.Gold;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setDeptment();
                String re = ic.ivfDB.proceDB.insertLabProcedure(proce, ic.user.staff_id);
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

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            flagEdit = true;
            setControlEnable(flagEdit);
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            txtID.Value = "";
            txtProceCode.Value = "";
            txtProceNameT.Value = "";
            txtRemark.Value = "";
            chkVoid.Checked = false;
            btnVoid.Hide();
            flagEdit = true;
            setControlEnable(true);
        }

        private void BtnVoid_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ ยกเลิกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                ic.ivfDB.proceDB.VoidLabProcedure(txtID.Text, userIdVoid);
                setGrfDeptH();
            }
        }

        private void ChkVoid_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
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
        private void TxtPasswordVoid_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.Enter)
            {
                userIdVoid = ic.ivfDB.stfDB.selectByPasswordAdmin(txtPasswordVoid.Text.Trim());
                if (userIdVoid.Length > 0)
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
        private void initGrfDept()
        {
            grfProce = new C1FlexGrid();
            grfProce.Font = fEdit;
            grfProce.Dock = System.Windows.Forms.DockStyle.Fill;
            grfProce.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfDept);

            grfProce.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grfProce_AfterRowColChange);
            grfProce.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfProce_CellButtonClick);
            grfProce.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfProce_CellChanged);

            panel2.Controls.Add(this.grfProce);

            C1Theme theme = C1ThemeController.GetThemeByName("Office2013Red", false);
            C1ThemeController.ApplyThemeToObject(grfProce, theme);
        }
        private void setGrfDeptH()
        {

            //grfDept.Rows.Count = 7;            
            grfProce.DataSource = ic.ivfDB.proceDB.selectAll1(statusLab);
            
            grfProce.Cols.Count = colCnt;
            CellStyle cs = grfProce.Styles.Add("btn");
            cs.DataType = typeof(Button);
            //cs.ComboList = "|Tom|Dick|Harry";
            cs.ForeColor = Color.Navy;
            cs.Font = new Font(Font, FontStyle.Bold);
            cs = grfProce.Styles.Add("date");
            cs.DataType = typeof(DateTime);
            cs.Format = "dd-MMM-yy";
            cs.ForeColor = Color.DarkGoldenrod;

            grfProce.Cols[colE].Style = grfProce.Styles["btn"];
            grfProce.Cols[colS].Style = grfProce.Styles["date"];

            grfProce.Cols[colName].Width = 300;

            grfProce.Cols[colE].Width = 100;
            grfProce.Cols[colS].Width = 100;

            grfProce.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfProce.Cols[colCode].Caption = "รหัส";
            if (statusLab == objdb.LabProcedureDB.StatusLab.OPUProcedure)
            {
                grfProce.Cols[colName].Caption = "ชื่อ OPU Procedure";
                label2.Text = grfProce.Cols[colName].Caption;
            }
            else if (statusLab == objdb.LabProcedureDB.StatusLab.FETProcedure)
            {
                grfProce.Cols[colName].Caption = "ชื่อ FET Procedure";
                label2.Text = grfProce.Cols[colName].Caption;
            }
            grfProce.Cols[colRemark].Caption = "หมายเหตุ";
            //grfDept.Cols[coledit].Visible = false;
            if (grfProce.Rows.Count > 2)
            {
                //CellRange rg = grfDept.GetCellRange(2, colE);
                //rg.Style = grfDept.Styles["btn"];
                for (int i = 1; i < grfProce.Rows.Count; i++)
                {
                    grfProce[i, 0] = i;
                    if (i % 2 == 0)
                        grfProce.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
                }
            }

            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            grfProce.Cols[colID].Visible = false;
            grfProce.Cols[colE].Visible = false;
            grfProce.Cols[colS].Visible = false;
            grfProce.Cols[colCode].Visible = false;
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
            this.txtProceCode.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtProceCode.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtProceNameT.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtProceNameT.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtRemark.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtRemark.Enter += new System.EventHandler(this.textBox_Enter);
        }
        private void setControl(String deptId)
        {
            proce = ic.ivfDB.proceDB.selectByPk1(deptId);
            txtID.Value = proce.proce_id;
            txtProceCode.Value = proce.proce_code;
            txtProceNameT.Value = proce.proce_name_t;
            txtRemark.Value = proce.remark;
        }
        private void setControlEnable(Boolean flag)
        {
            //txtID.Enabled = flag;
            txtProceCode.Enabled = flag;
            txtProceNameT.Enabled = flag;
            txtRemark.Enabled = flag;
            chkVoid.Enabled = flag;
            btnEdit.Image = !flag ? Resources.lock24 : Resources.open24;
        }
        private void setDeptment()
        {
            proce.proce_id = txtID.Text;
            proce.proce_code = txtProceCode.Text;
            proce.proce_name_t = txtProceNameT.Text;
            proce.remark = txtRemark.Text;
            if (statusLab == objdb.LabProcedureDB.StatusLab.OPUProcedure)
            {
                proce.status_lab = "OPU";
            }
            else if (statusLab == objdb.LabProcedureDB.StatusLab.FETProcedure)
            {
                proce.status_lab = "FET";
            }
        }
        private void grfProce_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;

            String deptId = "";
            deptId = grfProce[e.NewRange.r1, colID] != null ? grfProce[e.NewRange.r1, colID].ToString() : "";
            setControl(deptId);
            setControlEnable(false);
            //setControlAddr(addrId);
            //setControlAddrEnable(false);
        }
        private void grfProce_CellButtonClick(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {

        }
        private void grfProce_CellChanged(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
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
        private void FrmLabOpuProce_Load(object sender, EventArgs e)
        {

        }
    }
}
