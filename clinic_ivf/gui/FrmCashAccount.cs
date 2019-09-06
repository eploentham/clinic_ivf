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
    public partial class FrmCashAccount : Form
    {
        IvfControl ic;
        OldCashAccount oca;

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;
        Color color;

        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        C1FlexGrid grfAgn;
        Boolean flagEdit = false;
        String userIdVoid = "";
        int colCaID = 1, colCaName = 2, colCaRemark = 3;
        int colCrID = 1, colCrName = 2, colCrRemark = 3;

        public FrmCashAccount(IvfControl ic)
        {
            InitializeComponent();
            this.ic = ic;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);

            //C1ThemeController.ApplicationTheme = ic.iniC.themeApplication;
            //theme1.Theme = C1ThemeController.ApplicationTheme;
            theme1.SetTheme(sB, "BeigeOne");
            color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();

            btnCaEdit.Click += BtnCaEdit_Click;
            btnCaSave.Click += BtnCaSave_Click;

            initGrfCa();
        }
        private void BtnCaSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setCashAccount();
                String re = ic.ivfDB.ocaDB.insertCashAccount(oca, ic.user.staff_id);
                long chk = 0;
                if (long.TryParse(re, out chk))
                {
                    ic.ivfDB.ocaDB.getlCashAccount();
                    btnCaSave.Image = Resources.accept_database24;
                }
                else
                {
                    btnCaSave.Image = Resources.accept_database24;
                }
                setGrfCa();
                setControlCaEnable(false);
                //this.Dispose();
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            txtCaID.Value = "";            
            txtCaNameT.Value = "";
            txtCaRemark.Value = "";
            chkCaVoid.Checked = false;
            btnCaVoid.Hide();
            flagEdit = true;
            setControlCaEnable(true);
        }
        private void BtnCaEdit_Click(object sender, EventArgs e)
        {
            flagEdit = true;
            setControlCaEnable(flagEdit);
        }
        private void btnVoid_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ต้องการ ยกเลิกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                ic.ivfDB.posiDB.VoidPosition(txtCaID.Text, userIdVoid);
                setGrfCa();
            }
        }
        private void setControlCaEnable(Boolean flag)
        {
            //txtID.Enabled = flag;
            
            txtCaNameT.Enabled = flag;
            txtCaRemark.Enabled = flag;
            chkCaVoid.Enabled = flag;
            btnCaEdit.Image = !flag ? Resources.lock24 : Resources.open24;
        }
        private void setFocusColor()
        {
            //this.txtAgnCode.Leave += new System.EventHandler(this.textBox_Leave);
            //this.txtAgnCode.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtCaNameT.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtCaNameT.Enter += new System.EventHandler(this.textBox_Enter);

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
        private void textBox_Enter(object sender, EventArgs e)
        {
            C1TextBox a = (C1TextBox)sender;
            a.BackColor = ic.cTxtFocus;
            a.Font = new Font(ff, FontStyle.Bold);
        }
        private void setControlCa(String posiId)
        {
            oca = ic.ivfDB.ocaDB.selectByPk1(posiId);
            txtCaID.Value = oca.CashID;            
            txtCaNameT.Value = oca.CashName;
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
        private void TxtPasswordVoid_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.Enter)
            {
                userIdVoid = ic.ivfDB.stfDB.selectByPasswordAdmin(txtCaPasswordVoid.Text.Trim());
                if (userIdVoid.Length > 0)
                {
                    txtCaPasswordVoid.Hide();
                    btnCaVoid.Show();
                    //stt.Show("<p><b>ต้องการยกเลิก</b></p> <br> รหัสผ่านถูกต้อง", btnVoid);
                }
                else
                {
                    sep.SetError(txtCaPasswordVoid, "333");
                }
            }
        }
        private void setCashAccount()
        {
            oca.CashID = txtCaID.Text;
            oca.CashName = txtCaNameT.Text;
            //oca.agent_code = txtAgnCode.Text;
            //posi.posi_name_e = txtPosiNameE.Text;
            //agn.remark = txtRemark.Text;
            //posi.status_doctor = chkStatusDoctor.Checked == true ? "1" : "0";
            //posi.status_embryologist = chkEmbryologist.Checked == true ? "1" : "0";
        }
        private void setGrfCa()
        {
            //grfDept.Rows.Count = 7;
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oAgnDB.selectAll1();
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

            grfAgn.Cols[colCaID].Width = 80;

            //grfAgn.Cols[colCode].Width = 80;
            grfAgn.Cols[colCaName].Width = 300;

            grfAgn.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            //grfAgn.Cols[colCode].Caption = "รหัส";
            grfAgn.Cols[colCaName].Caption = "Cash";
            //grfAgn.Cols[colRemark].Caption = "หมายเหตุ";

            //grfDept.Cols[coledit].Visible = false;
            //CellRange rg = grfAgn.GetCellRange(2, colE);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                grfAgn[i, 0] = (i+1);
                grfAgn[i, colCaID] = dt.Rows[i][ic.ivfDB.ocaDB.oca.CashID].ToString();
                grfAgn[i, colCaName] = dt.Rows[i][ic.ivfDB.ocaDB.oca.CashName].ToString();
                grfAgn[i, colCaRemark] = dt.Rows[i][ic.ivfDB.ocaDB.oca.remark].ToString();
                if (i % 2 == 0)
                    grfAgn.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            }
            grfAgn.Cols[colCaID].Visible = false;
            //grfAgn.Cols[colRemark].Visible = false;
            //grfAgn.Cols[colS].Visible = false;
            //grfAgn.Cols[colRemark].Visible = false;
        }
        private void initGrfCa()
        {
            grfAgn = new C1FlexGrid();
            grfAgn.Font = fEdit;
            grfAgn.Dock = System.Windows.Forms.DockStyle.Fill;
            grfAgn.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfPosi);

            grfAgn.AfterRowColChange += GrfCa_AfterRowColChange;
            //grfAgn.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellButtonClick);
            //grfAgn.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellChanged);

            panel1.Controls.Add(this.grfAgn);

            C1Theme theme = C1ThemeController.GetThemeByName("Office2013Red", false);
            C1ThemeController.ApplyThemeToObject(grfAgn, theme);
        }

        private void GrfCa_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;

            String deptId = "";
            deptId = grfAgn[e.NewRange.r1, colCaID] != null ? grfAgn[e.NewRange.r1, colCaID].ToString() : "";
            setControlCa(deptId);
            setControlCaEnable(false);
        }

        private void FrmCashAccount_Load(object sender, EventArgs e)
        {

        }
    }
}
