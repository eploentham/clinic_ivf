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
    public partial class FrmAgent : Form
    {
        IvfControl ic;
        OldAgent agn;

        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;
        int colID = 1, colCode = 2, colName = 3, colRemark = 4, colE = 5, colS = 6, coledit = 7, colCnt = 7;

        C1FlexGrid grfAgn;

        //C1TextBox txtPassword = new C1.Win.C1Input.C1TextBox();
        Boolean flagEdit = false;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;

        String userIdVoid = "";

        public FrmAgent(IvfControl x)
        {
            InitializeComponent();
            ic = x;
            initConfig();
        }
        private void initConfig()
        {
            agn = new OldAgent();
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);

            C1ThemeController.ApplicationTheme = ic.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;
            theme1.SetTheme(sB, "BeigeOne");
            foreach (Control c in panel2.Controls)
            {
                theme1.SetTheme(c, "Office2013Red");
            }

            bg = txtAgnCode.BackColor;
            fc = txtAgnCode.ForeColor;
            ff = txtAgnCode.Font;
            txtPasswordVoid.KeyUp += TxtPasswordVoid_KeyUp;
            btnNew.Click += BtnNew_Click;
            btnSave.Click += BtnSave_Click;
            btnEdit.Click += BtnEdit_Click;
            btnClose.Click += BtnClose_Click;
            btnVoid.Click += BtnVoid_Click;

            initGrfAgent();
            setGrfAgent();
            setControlEnable(false);
            setFocusColor();
            sB1.Text = "";
            btnVoid.Hide();
            txtPasswordVoid.Hide();
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            //stt.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.Gold;
        }

        private void BtnVoid_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ ยกเลิกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                ic.ivfDB.posiDB.VoidPosition(txtID.Text, userIdVoid);
                setGrfAgent();
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.email = txtAgnEmail.Text;
            Close();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            flagEdit = true;
            setControlEnable(flagEdit);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setAgent();
                String re = ic.ivfDB.oAgnDB.insertAgent(agn, ic.user.staff_id);
                long chk = 0;
                if (long.TryParse(re, out chk))
                {
                    ic.ivfDB.oAgnDB.getlAgent();
                    btnSave.Image = Resources.accept_database24;
                }
                else
                {
                    btnSave.Image = Resources.accept_database24;
                }
                setGrfAgent();
                setControlEnable(false);
                //this.Dispose();
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            txtID.Value = "";
            txtAgnCode.Value = "";
            txtAgnNameT.Value = "";
            flagEdit = true;
            setControlEnable(flagEdit);
        }

        private void initGrfAgent()
        {
            grfAgn = new C1FlexGrid();
            grfAgn.Font = fEdit;
            grfAgn.Dock = System.Windows.Forms.DockStyle.Fill;
            grfAgn.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfPosi);

            grfAgn.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grfPosi_AfterRowColChange);
            //grfAgn.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellButtonClick);
            //grfAgn.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellChanged);

            panel1.Controls.Add(this.grfAgn);

            C1Theme theme = C1ThemeController.GetThemeByName("Office2013Red", false);
            C1ThemeController.ApplyThemeToObject(grfAgn, theme);
        }
        private void setGrfAgent()
        {
            //grfDept.Rows.Count = 7;

            grfAgn.DataSource = ic.ivfDB.oAgnDB.selectAll1();
            grfAgn.Cols.Count = 4;
            //CellStyle cs = grfAgn.Styles.Add("btn");
            //cs.DataType = typeof(Button);
            ////cs.ComboList = "|Tom|Dick|Harry";
            //cs.ForeColor = Color.Navy;
            //cs.Font = new Font(Font, FontStyle.Bold);
            //cs = grfAgn.Styles.Add("date");
            //cs.DataType = typeof(DateTime);
            //cs.Format = "dd-MMM-yy";
            //cs.ForeColor = Color.DarkGoldenrod;

            //grfAgn.Cols[colE].Style = grfAgn.Styles["btn"];
            //grfAgn.Cols[colS].Style = grfAgn.Styles["date"];

            grfAgn.Cols[colID].Width = 80;

            grfAgn.Cols[colCode].Width = 80;
            grfAgn.Cols[colName].Width = 300;

            grfAgn.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfAgn.Cols[colCode].Caption = "รหัส";
            grfAgn.Cols[colName].Caption = "ชื่อAgent";
            //grfAgn.Cols[colRemark].Caption = "หมายเหตุ";

            //grfDept.Cols[coledit].Visible = false;
            CellRange rg = grfAgn.GetCellRange(2, colE);
            for (int i = 1; i < grfAgn.Rows.Count; i++)
            {
                grfAgn[i, 0] = i;
                if (i % 2 == 0)
                    grfAgn.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            }
            grfAgn.Cols[colID].Visible = false;
            //grfAgn.Cols[colRemark].Visible = false;
            //grfAgn.Cols[colS].Visible = false;
            //grfAgn.Cols[colRemark].Visible = false;
        }
        private void textBox_Enter(object sender, EventArgs e)
        {
            C1TextBox a = (C1TextBox)sender;
            a.BackColor = ic.cTxtFocus;
            a.Font = new Font(ff, FontStyle.Bold);
        }
        private void setFocusColor()
        {
            this.txtAgnCode.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtAgnCode.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtAgnNameT.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtAgnNameT.Enter += new System.EventHandler(this.textBox_Enter);

            //this.txtRemark.Leave += new System.EventHandler(this.textBox_Leave);
            //this.txtRemark.Enter += new System.EventHandler(this.textBox_Enter);
        }
        private void textBox_Leave(object sender, EventArgs e)
        {
            C1TextBox a = (C1TextBox)sender;
            a.BackColor = bg;
            a.ForeColor = fc;
            a.Font = new Font(ff, FontStyle.Regular);
        }
        private void setControl(String posiId)
        {
            agn = ic.ivfDB.oAgnDB.selectByPk1(posiId);
            txtID.Value = agn.agentid;
            txtAgnCode.Value = agn.agent_code;
            txtAgnNameT.Value = agn.agentname;
            txtAgnEmail.Value = agn.agent_email;
            //txtPosiNameT.Value = agn.posi_name_t;
            //txtRemark.Value = agn.remark;
            //if (posi.status_doctor.Equals("1"))
            //{
            //    chkStatusDoctor.Checked = true;
            //}
            //else
            //{
            //    chkStatusDoctor.Checked = false;
            //}
            //if (posi.status_embryologist.Equals("1"))
            //{
            //    chkEmbryologist.Checked = true;
            //}
            //else
            //{
            //    chkEmbryologist.Checked = false;
            //}
        }
        private void setControlEnable(Boolean flag)
        {
            //txtID.Enabled = flag;
            txtAgnCode.Enabled = flag;
            txtAgnNameT.Enabled = flag;
            txtRemark.Enabled = flag;
            chkVoid.Enabled = flag;
            btnEdit.Image = !flag ? Resources.lock24 : Resources.open24;
        }
        private void setAgent()
        {
            agn.agentid = txtID.Text;
            agn.agentname = txtAgnNameT.Text;
            agn.agent_code = txtAgnCode.Text;
            agn.agent_email = txtAgnEmail.Text;
            //agn.remark = txtRemark.Text;
            //posi.status_doctor = chkStatusDoctor.Checked == true ? "1" : "0";
            //posi.status_embryologist = chkEmbryologist.Checked == true ? "1" : "0";
        }
        private void grfPosi_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;

            String deptId = "";
            deptId = grfAgn[e.NewRange.r1, colID] != null ? grfAgn[e.NewRange.r1, colID].ToString() : "";
            setControl(deptId);
            setControlEnable(false);
            //setControlAddr(addrId);
            //setControlAddrEnable(false);
        }
        private void grfPosi_CellButtonClick(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {

        }
        private void grfPosi_CellChanged(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
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
        private void btnNew_Click(object sender, EventArgs e)
        {
            txtID.Value = "";
            txtAgnCode.Value = "";
            txtAgnNameT.Value = "";
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
        private void btnVoid_Click(object sender, EventArgs e)
        {
            
        }
        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
        //    {
        //        setAgent();
        //        String re = ic.ivfDB.oAgnDB.insertAgent(agn, ic.user.staff_id);
        //        int chk = 0;
        //        if (int.TryParse(re, out chk))
        //        {
        //            btnSave.Image = Resources.accept_database24;
        //        }
        //        else
        //        {
        //            btnSave.Image = Resources.accept_database24;
        //        }
        //        setGrfAgent();
        //        //setGrdView();
        //        //this.Dispose();
        //    }
        //}
        private void chkVoid_Click(object sender, EventArgs e)
        {
            if (btnVoid.Visible)
            {
                btnVoid.Hide();
            }
            else
            {
                txtPasswordVoid.Show();
                txtPasswordVoid.Focus();
                //stt.Show("<p><b>ต้องการยกเลิก</b></p> <br> กรุณาป้อนรหัสผ่าน", txtPasswordVoid);
            }
        }
        private void FrmAgent_Load(object sender, EventArgs e)
        {

        }
    }
}
