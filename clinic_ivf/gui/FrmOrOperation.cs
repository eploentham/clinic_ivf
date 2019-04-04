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
    public partial class FrmOrOperation : Form
    {
        IvfControl ic;
        OrOperation ord;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;
        int colID = 1, colCode = 2, colName = 3, colCnt = 4;

        C1FlexGrid grfReq;

        //C1TextBox txtPassword = new C1.Win.C1Input.C1TextBox();
        Boolean flagEdit = false;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;

        String userIdVoid = "";
        public FrmOrOperation(IvfControl x)
        {
            InitializeComponent();
            ic = x;
            initConfig();
        }
        private void initConfig()
        {
            ord = new OrOperation();

            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);

            C1ThemeController.ApplicationTheme = ic.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;
            theme1.SetTheme(sB, "BeigeOne");
            foreach (Control c in panel2.Controls)
            {
                theme1.SetTheme(c, "Office2013Red");
            }

            bg = txtGiagGrpCode.BackColor;
            fc = txtGiagGrpCode.ForeColor;
            ff = txtGiagGrpCode.Font;

            btnNew.Click += BtnNew_Click;
            btnSave.Click += BtnSave_Click;
            btnEdit.Click += BtnEdit_Click;
            ic.ivfDB.ordgDB.setC1CboDiagGroup(cboFetDay);

            initGrfPosi();
            setGrfPosi();
            setControlEnable(false);
            setFocusColor();
            sB1.Text = "";
            btnVoid.Hide();
            txtPasswordVoid.Hide();
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
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
                String re = ic.ivfDB.ordDB.insertOrDiag(ord, ic.user.staff_id);
                long chk = 0;
                if (long.TryParse(re, out chk))
                {
                    //ic.ivfDB.ordgDB.get();
                    btnSave.Image = Resources.accept_database24;
                }
                else
                {
                    btnSave.Image = Resources.accept_database24;
                }
                setGrfPosi();
                setControlEnable(false);
                //this.Dispose();
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            txtID.Value = "";
            txtGiagGrpCode.Value = "";
            txtGiagGrpName.Value = "";
            flagEdit = true;
            setControlEnable(flagEdit);
        }
        private void initGrfPosi()
        {
            grfReq = new C1FlexGrid();
            grfReq.Font = fEdit;
            grfReq.Dock = System.Windows.Forms.DockStyle.Fill;
            grfReq.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfPosi);

            grfReq.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grfPosi_AfterRowColChange);
            //grfAgn.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellButtonClick);
            //grfAgn.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellChanged);

            panel1.Controls.Add(this.grfReq);

            C1Theme theme = C1ThemeController.GetThemeByName("Office2013Red", false);
            C1ThemeController.ApplyThemeToObject(grfReq, theme);
        }
        private void grfPosi_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;

            String deptId = "";
            deptId = grfReq[e.NewRange.r1, colID] != null ? grfReq[e.NewRange.r1, colID].ToString() : "";
            setControl(deptId);
            setControlEnable(false);
            //setControlAddr(addrId);
            //setControlAddrEnable(false);
        }
        private void setGrfPosi()
        {
            //grfDept.Rows.Count = 7;

            grfReq.DataSource = ic.ivfDB.ordDB.selectAll1();
            grfReq.Cols.Count = colCnt;

            grfReq.Cols[colID].Width = 80;

            grfReq.Cols[colCode].Width = 80;
            grfReq.Cols[colName].Width = 300;

            grfReq.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfReq.Cols[colCode].Caption = "รหัส";
            grfReq.Cols[colName].Caption = "ชื่อ Diagnosis ";

            for (int i = 1; i < grfReq.Rows.Count; i++)
            {
                grfReq[i, 0] = i;
                if (i % 2 == 0)
                    grfReq.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            }
            grfReq.Cols[colID].Visible = false;
            //grfAgn.Cols[colE].Visible = false;
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
            this.txtGiagGrpCode.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtGiagGrpCode.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtGiagGrpName.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtGiagGrpName.Enter += new System.EventHandler(this.textBox_Enter);

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
            ord = ic.ivfDB.ordDB.selectByPk1(posiId);
            txtID.Value = ord.opera_id;
            txtGiagGrpCode.Value = ord.opera_code;
            txtGiagGrpName.Value = ord.opera_name;
            //cboFetDay.Value = ord.diag_group_id;
            ic.setC1Combo(cboFetDay, ord.opera_group_id);
            //txtPosiNameT.Value = agn.posi_name_t;
            //txtRemark.Value = agn.remark;
            //if (posi.status_doctor.Equals("1"))
            //{
            //chkSendtoOr.Checked = ord.status_or_diag_req.Equals("1") ? true : false;
            //chkOrUs.Checked = ord.status_or_us.Equals("1") ? true : false;

        }
        private void setControlEnable(Boolean flag)
        {
            //txtID.Enabled = flag;
            txtGiagGrpCode.Enabled = flag;
            txtGiagGrpName.Enabled = flag;
            txtRemark.Enabled = flag;
            chkVoid.Enabled = flag;
            //chkOrUs.Enabled = flag;
            //chkSendtoOr.Enabled = flag;
            btnEdit.Image = !flag ? Resources.lock24 : Resources.open24;
        }
        private void setAgent()
        {
            ord.opera_id = txtID.Text;
            ord.opera_name = txtGiagGrpName.Text;
            ord.opera_code = txtGiagGrpCode.Text;
            ord.opera_group_id = cboFetDay.SelectedItem == null ? "" : ((ComboBoxItem)cboFetDay.SelectedItem).Value;
            //posi.posi_name_e = txtPosiNameE.Text;
            //agn.remark = txtRemark.Text;
            //ord.status_or_diag_req = chkSendtoOr.Checked == true ? "1" : "0";
            //ord.status_or_us = chkOrUs.Checked == true ? "1" : "0";
        }
        private void FrmOrDiag_Load(object sender, EventArgs e)
        {

        }
    }
}
