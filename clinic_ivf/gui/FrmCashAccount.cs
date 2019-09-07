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
        OldCreditCardAccount ocr;
        MainMenu menu;

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;
        Color color;

        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        C1FlexGrid grfCa, grfCr;
        Boolean flagEdit = false;
        String userIdVoid = "";
        int colCaID = 1, colCaName = 2, colCaRemark = 3;
        int colCrID = 1, colCrName = 2, colCrRemark = 3;

        public FrmCashAccount(IvfControl ic, MainMenu m)
        {
            InitializeComponent();
            this.ic = ic;
            menu = m;
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
            oca = new OldCashAccount();
            ocr = new OldCreditCardAccount();

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            btnCaVoid.Hide();
            btnCrVoid.Hide();

            btnCaNew.Click += BtnNew_Click;
            btnCaEdit.Click += BtnCaEdit_Click;
            btnCaSave.Click += BtnCaSave_Click;
            btnCaVoid.Click += BtnCaVoid_Click;

            btnCrNew.Click += BtnCrNew_Click;
            btnCrEdit.Click += BtnCrEdit_Click;
            btnCrVoid.Click += BtnCrVoid_Click;
            btnCrSave.Click += BtnCrSave_Click;
            chkCaVoid.Click += ChkCaVoid_Click;
            chkCrVoid.Click += ChkCrVoid_Click;
            txtCaPasswordVoid.KeyUp += TxtCaPasswordVoid_KeyUp;
            txtCrPasswordVoid.KeyUp += TxtCrPasswordVoid_KeyUp;

            initGrfCa();
            initGrfCr();
            setGrfCa();
            setGrfCr();
        }

        private void BtnCaVoid_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ ยกเลิกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                ic.ivfDB.ocaDB.VoidCashAccount(txtCaID.Text, userIdVoid);
                setGrfCa();
            }
        }

        private void TxtCrPasswordVoid_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.Enter)
            {
                userIdVoid = ic.ivfDB.stfDB.selectByPasswordAdmin(txtCrPasswordVoid.Text.Trim());
                if (userIdVoid.Length > 0)
                {
                    txtCrPasswordVoid.Hide();
                    btnCrVoid.Show();
                    //stt.Show("<p><b>ต้องการยกเลิก</b></p> <br> รหัสผ่านถูกต้อง", btnVoid);
                }
                else
                {
                    sep.SetError(txtCaPasswordVoid, "333");
                }
            }
        }

        private void TxtCaPasswordVoid_KeyUp(object sender, KeyEventArgs e)
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

        private void ChkCrVoid_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (btnCrVoid.Visible)
            {
                btnCrVoid.Hide();
            }
            else
            {
                txtCrPasswordVoid.Show();
                txtCrPasswordVoid.Focus();
                //stt.Show("<p><b>ต้องการยกเลิก</b></p> <br> กรุณาป้อนรหัสผ่าน", txtPasswordVoid);
            }
        }

        private void ChkCaVoid_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (btnCaVoid.Visible)
            {
                btnCaVoid.Hide();
            }
            else
            {
                txtCaPasswordVoid.Show();
                txtCaPasswordVoid.Focus();
                //stt.Show("<p><b>ต้องการยกเลิก</b></p> <br> กรุณาป้อนรหัสผ่าน", txtPasswordVoid);
            }
        }

        private void BtnCrSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setCreditAccount();
                String re = ic.ivfDB.ocrDB.insertCashAccount(ocr, ic.user.staff_id);
                long chk = 0;
                if (long.TryParse(re, out chk))
                {
                    ic.ivfDB.ocrDB.getlCreditCardAccount();
                    btnCrSave.Image = Resources.accept_database24;
                }
                else
                {
                    btnCrSave.Image = Resources.accept_database24;
                }
                setGrfCa();
                setControlCrEnable(false);
                //this.Dispose();
            }
        }

        private void BtnCrVoid_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ ยกเลิกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                ic.ivfDB.ocrDB.VoidCashAccount(txtCaID.Text, userIdVoid);
                setGrfCr();
            }
        }

        private void BtnCrEdit_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            flagEdit = true;
            setControlCrEnable(flagEdit);
        }

        private void BtnCrNew_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            txtCrID.Value = "";
            txtCrNameT.Value = "";
            txtCrRemark.Value = "";
            chkCrVoid.Checked = false;
            btnCrVoid.Hide();
            flagEdit = true;
            setControlCrEnable(true);
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
        private void BtnNew_Click(object sender, EventArgs e)
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
        private void setControlCrEnable(Boolean flag)
        {
            //txtID.Enabled = flag;

            txtCrNameT.Enabled = flag;
            txtCrRemark.Enabled = flag;
            chkCrVoid.Enabled = flag;
            btnCrEdit.Image = !flag ? Resources.lock24 : Resources.open24;
        }
        private void setControlCaEnable(Boolean flag)
        {
            //txtID.Enabled = flag;
            
            txtCaNameT.Enabled = flag;
            txtCaRemark.Enabled = flag;
            chkCaVoid.Enabled = flag;
            btnCaEdit.Image = !flag ? Resources.lock24 : Resources.open24;
        }
        private void setCrFocusColor()
        {
            //this.txtAgnCode.Leave += new System.EventHandler(this.textBox_Leave);
            //this.txtAgnCode.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtCrNameT.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtCrNameT.Enter += new System.EventHandler(this.textBox_Enter);

            //this.txtRemark.Leave += new System.EventHandler(this.textBox_Leave);
            //this.txtRemark.Enter += new System.EventHandler(this.textBox_Enter);
        }
        private void setCaFocusColor()
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
        }
        private void setControlCr(String posiId)
        {
            ocr = ic.ivfDB.ocrDB.selectByPk1(posiId);
            txtCrID.Value = ocr.CreditCardID;
            txtCrNameT.Value = ocr.CreditCardName;
        }
        private void setCashAccount()
        {
            oca.CashID = txtCaID.Text;
            oca.CashName = txtCaNameT.Text;
        }
        private void setCreditAccount()
        {
            ocr.CreditCardID = txtCrID.Text;
            ocr.CreditCardName = txtCrNameT.Text;
        }
        private void setGrfCa()
        {
            //grfDept.Rows.Count = 7;
            DataTable dt = new DataTable();
            dt = ic.ivfDB.ocaDB.selectAll();
            grfCa.Cols.Count = 4;
            grfCa.Rows.Count = 0;
            grfCa.Rows.Count = dt.Rows.Count+1;

            grfCa.Cols[colCaID].Width = 80;

            //grfAgn.Cols[colCode].Width = 80;
            grfCa.Cols[colCaName].Width = 200;

            grfCa.ShowCursor = true;

            //grfAgn.Cols[colCode].Caption = "รหัส";
            grfCa.Cols[colCrName].Caption = "Cash";
            //grfAgn.Cols[colRemark].Caption = "หมายเหตุ";
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                grfCa[i+1, 0] = (i+1);
                grfCa[i + 1, colCaID] = dt.Rows[i][ic.ivfDB.ocaDB.oca.CashID].ToString();
                grfCa[i + 1, colCaName] = dt.Rows[i][ic.ivfDB.ocaDB.oca.CashName].ToString();
                grfCa[i + 1, colCaRemark] = dt.Rows[i][ic.ivfDB.ocaDB.oca.remark].ToString();
                if (i % 2 == 0)
                    grfCa.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            }
            grfCa.Cols[colCaID].Visible = false;
            //grfAgn.Cols[colRemark].Visible = false;
            //grfAgn.Cols[colS].Visible = false;
            //grfAgn.Cols[colRemark].Visible = false;
        }
        private void initGrfCa()
        {
            grfCa = new C1FlexGrid();
            grfCa.Font = fEdit;
            grfCa.Dock = System.Windows.Forms.DockStyle.Fill;
            grfCa.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfPosi);

            grfCa.AfterRowColChange += GrfCa_AfterRowColChange;
            //grfAgn.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellButtonClick);
            //grfAgn.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellChanged);

            pnCash.Controls.Add(this.grfCa);

            C1Theme theme = C1ThemeController.GetThemeByName("Office2013Red", false);
            C1ThemeController.ApplyThemeToObject(grfCa, theme);
        }

        private void GrfCa_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;

            String deptId = "";
            deptId = grfCa[e.NewRange.r1, colCaID] != null ? grfCa[e.NewRange.r1, colCaID].ToString() : "";
            setControlCa(deptId);
            setControlCaEnable(false);
        }
        private void initGrfCr()
        {
            grfCr = new C1FlexGrid();
            grfCr.Font = fEdit;
            grfCr.Dock = System.Windows.Forms.DockStyle.Fill;
            grfCr.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfPosi);

            grfCr.AfterRowColChange += GrfCr_AfterRowColChange;
            //grfAgn.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellButtonClick);
            //grfAgn.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellChanged);

            pnCredit.Controls.Add(this.grfCr);

            C1Theme theme = C1ThemeController.GetThemeByName("Office2013Red", false);
            C1ThemeController.ApplyThemeToObject(grfCa, theme);
        }

        private void GrfCr_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;

            String deptId = "";
            deptId = grfCr[e.NewRange.r1, colCrID] != null ? grfCr[e.NewRange.r1, colCrID].ToString() : "";
            setControlCr(deptId);
            setControlCrEnable(false);
        }

        private void setGrfCr()
        {
            //grfDept.Rows.Count = 7;
            DataTable dt = new DataTable();
            dt = ic.ivfDB.ocrDB.selectAll();
            grfCr.Cols.Count = 4;
            grfCr.Rows.Count = 0;
            grfCr.Rows.Count = dt.Rows.Count + 1;

            grfCr.Cols[colCaID].Width = 80;

            //grfAgn.Cols[colCode].Width = 80;
            grfCr.Cols[colCaName].Width = 200;

            grfCr.ShowCursor = true;

            //grfAgn.Cols[colCode].Caption = "รหัส";
            grfCr.Cols[colCaName].Caption = "Credit";
            //grfAgn.Cols[colRemark].Caption = "หมายเหตุ";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                grfCr[i+1, 0] = (i + 1);
                grfCr[i + 1, colCaID] = dt.Rows[i][ic.ivfDB.ocrDB.occa.CreditCardID].ToString();
                grfCr[i + 1, colCaName] = dt.Rows[i][ic.ivfDB.ocrDB.occa.CreditCardName].ToString();
                grfCr[i + 1, colCaRemark] = dt.Rows[i][ic.ivfDB.ocrDB.occa.remark].ToString();
                if (i % 2 == 0)
                    grfCr.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            }
            grfCr.Cols[colCaID].Visible = false;
            //grfAgn.Cols[colRemark].Visible = false;
            //grfAgn.Cols[colS].Visible = false;
            //grfAgn.Cols[colRemark].Visible = false;
        }
        private void FrmCashAccount_Load(object sender, EventArgs e)
        {

        }
    }
}
