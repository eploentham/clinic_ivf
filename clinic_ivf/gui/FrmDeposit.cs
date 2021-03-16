using C1.C1Pdf;
using C1.Win.C1Command;
using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1SuperTooltip;
using C1.Win.C1Themes;
using clinic_ivf.control;
using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.gui
{
    public class FrmDeposit:Form
    {
        IvfControl ic;
        Font fEdit, fEditB, fEdit3B, fEdit5B;
        C1DockingTab tcMain;
        C1DockingTabPage tabDeposit, tabWithDraw;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        C1PdfDocument pdfDoc;
        C1ThemeController theme1;

        Label lbtxtDepositCode, lbtxtDepositDate, lbtxtHn, lbtxtName, lbtxtDeposit, lbtxtRemark, lbtxtWithDrawCode, lbtxtWithDrawAmount, lbtxtWithDrawRemark, lbtxtWithDrawDate, lbtxtWithDrawHn, lbtxtWithDrawName, lbcboPackage, lbtxtWithDrawAmt, lbtxtWithDrawDeposit;
        C1DateEdit txtDepositDate, txtWithDrawDate;
        C1Button btnOPBKKSelect;
        C1TextBox txtDepositCode, txtHn, txtName, txtDeposit, txtRemark, txtId, txtWithDrawCode, txtWithDrawId, txtWithDrawAmount, txtWithDrawRemark, txtWithDrawHn, txtWithDrawVisitId, txtWithDrawName, txtWithDrawVn, txtWithDrawPttId, txtWithDrawAmt, txtWithDrawDeposit;
        C1Button btnSave, btnSearch, btnWithDrawSearch, btnWithDrawSave, btnNew;
        C1FlexGrid grfDeposit, grfWithDraw, grfDepositHn;
        C1CheckBox chkAll;
        RadioButton chkActive, chkUnActive, chkWithDrawActive, chkWithDrawUnActive;
        C1ComboBox cboPackage, cboPackageHn;
        Label lbcboPackageHn;
        String pttid = "", visitid="";
        Patient ptt;
        Visit vs;
        Boolean flagCashier = false, pageLoad = false;

        Deposit deposit;
        DepositWithDraw dwithdraw;
        int colCode = 1, colHn = 2, colName = 3, colDate = 4, colDeposit = 5, colAmount=6, colRemark = 7, colId=8, colPck=9;

        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetDefaultPrinter(string Printer);
        public FrmDeposit(IvfControl ic)
        {
            this.ic = ic;
            flagCashier = false;
            initConfig();
        }
        public FrmDeposit(IvfControl ic, String pttid, String visitid)
        {
            this.ic = ic;
            this.pttid = pttid;
            this.visitid = visitid;
            flagCashier = true;
            initConfig();
        }
        private void initConfig()
        {
            pageLoad = true;
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);
            deposit = new Deposit();
            dwithdraw = new DepositWithDraw();
            ptt = new Patient();
            vs = new Visit();
            theme1 = new C1ThemeController();
            theme1.Theme = ic.iniC.themeApplication;
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();

            initCompoment();
            ic.ivfDB.oPkgDB.setCboPackage(cboPackage, "");
            ic.ivfDB.oPkgDB.setCboPackage(cboPackageHn, "");
            txtDepositDate.Value = DateTime.Now.ToString("yyyy-MM-dd");

            this.Load += FrmDeport_Load;
            btnSave.Click += BtnSave_Click;
            grfDeposit.DoubleClick += GrfDeposit_DoubleClick;
            btnWithDrawSave.Click += BtnWithDrawSave_Click;
            btnNew.Click += BtnNew_Click;
            txtHn.KeyUp += TxtHn_KeyUp;
            btnSearch.Click += BtnSearch_Click;
            grfDepositHn.DoubleClick += GrfDepositHn_DoubleClick;
            txtDeposit.KeyPress += TxtDeposit_KeyPress;
            txtName.KeyPress += TxtName_KeyPress;
            cboPackage.DropDownClosed += CboPackage_DropDownClosed;
            txtWithDrawAmount.KeyPress += TxtWithDrawAmount_KeyPress;

            setControl();
            if (pttid.Length > 0)
            {
                chkAll.Checked = false;
            }
            setGrfDeposit(pttid, grfDeposit);
            setGrfDeposit(pttid, grfDepositHn);
            pageLoad = false;
        }

        private void TxtWithDrawAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            //throw new NotImplementedException();
            if (!chkWithDrawActive.Checked) chkWithDrawActive.Checked = true;
        }

        private void CboPackage_DropDownClosed(object sender, DropDownClosedEventArgs e)
        {
            //throw new NotImplementedException();
            if (pageLoad) return;

            txtDeposit.Focus();
        }

        private void TxtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //throw new NotImplementedException();
            if (txtName.Text.Trim().Length > 1)
            {
                sep.Clear();
            }
        }

        private void TxtDeposit_KeyPress(object sender, KeyPressEventArgs e)
        {
            //throw new NotImplementedException();
            decimal deposit = 0;
            if(decimal.TryParse(txtDeposit.Text.Trim(), out deposit))
            {
                sep.Clear();
            }
        }

        private void TxtDeposit_Enter(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            
        }

        private void GrfDepositHn_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfDepositHn.Row < 0) return;
            if (grfDepositHn.Col < 0) return;

            String id = "";
            id = grfDepositHn[grfDepositHn.Row, colId].ToString();
            setControlHn(id);
            setGrfWithDraw(txtId.Text.Trim());
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmSearchHn frm = new FrmSearchHn(ic, FrmSearchHn.StatusConnection.host, FrmSearchHn.StatusSearch.DonorSearch, FrmSearchHn.StatusSearchTable.PttSearch);
            frm.ShowDialog(this);
            if (!ic.sVsOld.PIDS.Trim().Equals("-"))
            {
                chkAll.Checked = false;         //  user ค้นหา ไม่ใช้การ ดึงข้อมูลทั้งหมด
                chkActive.Checked = true;
                txtHn.Value = ic.sVsOld.PIDS;
                setSearchPatient();
                txtRemark.Focus();
            }
        }

        private void TxtHn_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if(e.KeyCode == Keys.Enter)
            {
                setSearchPatient();
            }
        }
        private void setSearchPatient()
        {
            //Patient ptt = new Patient();
            if (txtHn.Text.Trim().IndexOf("/") > 0)
            {
                ptt = ic.ivfDB.pttDB.selectByHn(txtHn.Text.Trim().Substring(0, txtHn.Text.Trim().IndexOf(ic.hnspareyear)));
                txtHn.Value = ic.showHN(ptt.patient_hn, ptt.patient_year);
                txtName.Value = ptt.patient_name;

                txtWithDrawHn.Value = ic.showHN(ptt.patient_hn, ptt.patient_year);
                txtWithDrawName.Value = ptt.patient_name;

                setGrfDeposit(ptt.t_patient_id, grfDeposit);
            }
        }
        private void BtnNew_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            txtId.Value = "";
            txtDepositCode.Value = "";
            txtDepositDate.Value = "";
            txtDeposit.Value = "";
            txtHn.Value = "";
            txtName.Value = "";
            txtRemark.Value = "";
            cboPackage.Text = "";
            txtDepositDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
            ptt = new Patient();
            vs = new Visit();
        }
        private void setControlHn(String deposidid)
        {
            Deposit deposit = ic.ivfDB.depositDB.selectByPk(deposidid);
            Patient ptt = ic.ivfDB.pttDB.selectByPk1(deposit.t_patient_id);
            //vs = ic.ivfDB.vsDB.selectByPk1(visitid);

            txtWithDrawVisitId.Value = vs.t_visit_id;
            txtWithDrawVn.Value = vs.visit_vn;
            txtWithDrawHn.Value = ic.showHN(ptt.patient_hn, ptt.patient_year);
            txtWithDrawVisitId.Value = vs.t_visit_id;
            txtWithDrawPttId.Value = vs.t_patient_id;
            txtWithDrawName.Value = ptt.patient_name;
            txtWithDrawCode.Value = deposit.deposit_code;
            txtWithDrawDeposit.Value = deposit.deposit_amount;
            txtWithDrawAmt.Value = deposit.amount;
            txtWithDrawAmount.Value = "0";
            txtWithDrawRemark.Value = deposit.remark;
            txtId.Value = deposit.deposit_id;
            ic.setC1Combo(cboPackageHn, deposit.pck_id);
            txtWithDrawDate.Value = System.DateTime.Now.ToString("yyyy-MM-dd");
        }
        private void setControl()
        {
            chkAll.Checked = true;
            ptt = ic.ivfDB.pttDB.selectByPk1(pttid);
            vs = ic.ivfDB.vsDB.selectByPk1(visitid);

            txtId.Value = deposit.deposit_id;
            txtDepositCode.Value = deposit.deposit_code;
            txtDepositDate.Value = ic.datetoShow(deposit.deposit_date);
            txtDeposit.Value = deposit.deposit_amount;
            txtHn.Value = deposit.patient_hn;
            txtName.Value = deposit.deposit_name;
            txtRemark.Value = deposit.remark;
            if (deposit.active !=null && deposit.active.Equals("1"))
            {
                chkActive.Checked = true;
            }

            txtWithDrawVisitId.Value = vs.t_visit_id;
            txtWithDrawVn.Value = vs.visit_vn;
            txtWithDrawHn.Value = ic.showHN(ptt.patient_hn, ptt.patient_year);
            txtWithDrawVisitId.Value = vs.t_visit_id;
            txtWithDrawPttId.Value = vs.t_patient_id;
            txtWithDrawName.Value = ptt.patient_name;

            ic.setC1Combo(cboPackage, deposit.pck_id);

            if (txtHn.Text.Length > 0 && txtHn.Text.Trim().IndexOf(ic.hnspareyear) >0)
            {
                ptt = ic.ivfDB.pttDB.selectByHn(txtHn.Text.Trim().Substring(0, txtHn.Text.Trim().IndexOf(ic.hnspareyear)));
                txtHn.Value = ic.showHN(ptt.patient_hn, ptt.patient_year);
                txtName.Value = ptt.patient_name;

                txtWithDrawHn.Value = ic.showHN(ptt.patient_hn, ptt.patient_year);
                txtWithDrawName.Value = ptt.patient_name;

                vs = ic.ivfDB.vsDB.selectByPk1(visitid);
                txtWithDrawVisitId.Value = vs.t_visit_id;
                txtWithDrawVn.Value = vs.visit_vn;
            }
            if (txtId.Text.Length <= 0)
            {
                txtDepositDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }
        private void BtnWithDrawSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            decimal amt = 0, withdraw = 0;
            decimal.TryParse(txtWithDrawAmt.Text.Trim(), out amt);
            decimal.TryParse(txtWithDrawAmount.Text.Trim(), out withdraw);
            if (amt <= 0)
            {
                MessageBox.Show("Amount equal 0", "");
                return;
            }
            if (withdraw <= 0)
            {
                MessageBox.Show("WithDraw equal 0", "");
                return;
            }
            if (withdraw > amt)
            {
                MessageBox.Show("withdraw > Amount", "");
                return;
            }
            setWithDraw();
            String re = "";
            re = ic.ivfDB.dwitdrawDB.insertDepositWithDraw(dwithdraw, ic.userId);
            txtWithDrawId.Value = re;
            //ic.ivfDB.depositDB.updateAmount(txtId.Text.Trim(), dwithdraw.withdraw_amount);
            setGrfWithDraw(txtWithDrawPttId.Text.Trim());
            if (flagCashier)
            {
                ic.deposit = txtWithDrawAmount.Text.Trim();
                ic.dwithdrawid = re;
                this.Dispose();
            }
        }

        private void GrfDeposit_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfDeposit.Row < 0) return;
            if (grfDeposit.Col < 0) return;

            String id = "";
            id = grfDeposit[grfDeposit.Row, colId].ToString();
            txtId.Value = id;
            deposit = ic.ivfDB.depositDB.selectByPk(txtId.Text.Trim());
            setControl();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (chkUnActive.Checked)
            {
                if (MessageBox.Show("ต้องการ ยกเลิกรายการ  \n"+" "+txtHn.Text+" "+txtName.Text, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    String re = "";
                    re = ic.ivfDB.depositDB.voidDeposit(txtId.Text, ic.userId);
                    BtnNew_Click(null, null);
                }
            }
            else
            {
                Decimal chk = 0;
                if (txtDeposit.Text.Length <= 0)
                {
                    MessageBox.Show("ไม่พบจำนวนเงิน", "");
                    sep.SetError(txtDeposit, "ไม่พบจำนวนเงิน");
                    //sep.Clear();                
                    return;
                }
                if (!decimal.TryParse(txtDeposit.Text, out chk))
                {
                    MessageBox.Show("จำนวนเงิน error", "");
                    sep.SetError(txtDeposit, "จำนวนเงิน error");
                    return;
                }
                if (txtName.Text.Trim().Length <= 0)
                {
                    MessageBox.Show("ไม่พบชื่อ", "");
                    sep.SetError(txtName, "ไม่พบชื่อ");
                    return;
                }
                setDeposit();
                String re = "";
                re = ic.ivfDB.depositDB.insertDocScan(deposit, ic.userId);
                txtId.Value = re;
                //BtnNew_Click(null, null);
            }
            setGrfDeposit("", grfDeposit);

        }
        private void initCompomentTabWithDraw()
        {
            int gapLine = 25, gapX = 20, gapY = 20, xCol2 = 150, xCol20=130, xCol1 = 80, xCol3 = 330, xCol31=460, xcol32=540, xCol4 = 640, xcol41=660, xCol5 = 950;
            Size size = new Size();

            tabWithDraw = new C1DockingTabPage();
            tabWithDraw.Location = new System.Drawing.Point(1, 24);
            //tabScan.Name = "c1DockingTabPage1";
            tabWithDraw.Size = new System.Drawing.Size(667, 175);
            tabWithDraw.TabIndex = 0;
            tabWithDraw.Text = "WithDraw";
            tabWithDraw.Name = "tabWithDraw";
            tcMain.Controls.Add(tabWithDraw);

            lbtxtWithDrawCode = new Label();
            lbtxtWithDrawAmount = new Label();
            lbtxtWithDrawRemark = new Label();
            lbtxtWithDrawDate = new Label();
            lbtxtWithDrawHn = new Label();
            lbtxtWithDrawAmount = new Label();
            lbtxtWithDrawName = new Label();
            lbtxtWithDrawAmt = new Label();
            lbtxtWithDrawDeposit = new Label();

            txtWithDrawCode = new C1TextBox();
            txtWithDrawAmount = new C1TextBox();
            txtWithDrawDate = new C1DateEdit();
            txtWithDrawHn = new C1TextBox();
            txtWithDrawId = new C1TextBox();
            txtWithDrawVisitId = new C1TextBox();
            txtWithDrawRemark = new C1TextBox();
            txtWithDrawVisitId = new C1TextBox();
            txtWithDrawName = new C1TextBox();
            txtWithDrawVn = new C1TextBox();
            txtWithDrawVisitId = new C1TextBox();
            txtWithDrawPttId = new C1TextBox();
            txtWithDrawAmt = new C1TextBox();
            txtWithDrawDeposit = new C1TextBox();

            btnWithDrawSearch = new C1Button();
            btnWithDrawSave = new C1Button();

            chkWithDrawActive = new RadioButton();
            chkWithDrawUnActive = new RadioButton();
            lbcboPackageHn = new Label();
            cboPackageHn = new C1ComboBox();

            ic.setControlLabel(ref lbtxtWithDrawCode, fEdit, "code :", "lbtxtWithDrawCode", gapX, gapY);
            ic.setControlC1TextBox(ref txtWithDrawCode, fEdit, "txtWithDrawCode", 120, xCol20, gapY);
            ic.setControlLabel(ref lbtxtWithDrawDate, fEdit, "Date Withdraw :", "lbtxtWithDrawDate", xcol32, gapY);
            size = ic.MeasureString(lbtxtWithDrawDate);
            ic.setControlC1DateTimeEdit(ref txtWithDrawDate, "txtWithDrawDate", lbtxtWithDrawDate.Location.X + size.Width + 15, gapY);

            ic.setControlC1Button(ref btnWithDrawSave, fEdit, "Save", "btnWithDrawSave", txtWithDrawCode.Location.X+ txtWithDrawCode.Width+20, gapY-10);
            btnWithDrawSave.Width = 70;

            ic.setControlRadioBox(ref chkWithDrawActive, fEdit, "Active", "chkActive", btnWithDrawSave.Location.X + btnWithDrawSave.Width + 20, gapY);
            ic.setControlRadioBox(ref chkWithDrawUnActive, fEdit, "UnActive", "chkUnActive", chkWithDrawActive.Location.X + 80, gapY);

            gapY += gapLine;
            ic.setControlLabel(ref lbtxtWithDrawHn, fEdit, "HN :", "lbtxtWithDrawHn", gapX, gapY);
            ic.setControlC1TextBox(ref txtWithDrawHn, fEdit, "txtWithDrawHn", 120, xCol20, gapY);
            ic.setControlC1TextBox(ref txtWithDrawVn, fEdit, "txtWithDrawVn", 120, txtWithDrawHn.Location.X + txtWithDrawHn.Width + 20, gapY);
            ic.setControlC1Button(ref btnWithDrawSearch, fEdit, "...", "btnWithDrawSearch", txtWithDrawVn.Location.X + txtWithDrawVn.Width + 10, gapY - 4);

            btnWithDrawSearch.Width = 30;
            btnWithDrawSearch.Height = 25;
            ic.setControlLabel(ref lbtxtWithDrawDeposit, fEdit, "Deposit :", "lbtxtWithDrawDeposit", xcol32, gapY);
            ic.setControlC1TextBox(ref txtWithDrawDeposit, fEdit, "txtWithDrawDeposit", 120, xCol4, gapY);

            gapY += gapLine;
            ic.setControlLabel(ref lbtxtWithDrawName, fEdit, "Name :", "lbtxtWithDrawName", gapX, gapY);
            ic.setControlC1TextBox(ref txtWithDrawName, fEdit, "txtWithDrawName", 400, xCol20, gapY);
            //gapY += gapLine;
            ic.setControlLabel(ref lbtxtWithDrawAmt, fEdit, "Amount :", "lbtxtWithDrawAmt", xcol32, gapY);
            ic.setControlC1TextBox(ref txtWithDrawAmt, fEdit, "txtWithDrawAmt", 120, xCol4, gapY);

            //ic.setControlRadioBox(ref chkWithDrawActive, fEdit, "Active", "chkActive", xCol4, gapY);
            //ic.setControlRadioBox(ref chkWithDrawUnActive, fEdit, "UnActive", "chkUnActive", chkActive.Location.X + 80, gapY);

            gapY += gapLine;
            ic.setControlLabel(ref lbtxtWithDrawRemark, fEdit, "Remark :", "lbtxtWithDrawRemark", gapX, gapY);
            ic.setControlC1TextBox(ref txtWithDrawRemark, fEdit, "txtWithDrawRemark", 400, xCol20, gapY);
            //gapY += gapLine;
            ic.setControlLabel(ref lbtxtWithDrawAmount, fEdit, "WithDraw :", "lbtxtWithDrawAmount", xcol32, gapY);
            size = ic.MeasureString(lbtxtWithDrawAmount);
            ic.setControlC1TextBox(ref txtWithDrawAmount, fEdit, "txtWithDrawAmount", 120, xCol4, gapY);
            txtWithDrawAmount.NumericInput = true;
            txtWithDrawAmount.DataType = typeof(decimal);
            gapY += gapLine;
            ic.setControlLabel(ref lbcboPackageHn, fEdit, "Package :", "lbcboPackageHn", gapX, gapY);
            ic.setControlC1ComboBox(ref cboPackageHn, fEdit, "cboPackageHn", 500, xCol2, gapY);

            grfWithDraw = new C1FlexGrid();
            grfWithDraw.Name = "grfWithDraw";
            grfWithDraw.Font = fEdit;
            grfWithDraw.Dock = System.Windows.Forms.DockStyle.Bottom;
            grfWithDraw.Location = new System.Drawing.Point(0, 0);
            grfWithDraw.Rows.Count = 1;

            grfDepositHn = new C1FlexGrid();
            grfDepositHn.Name = "grfDepositHn";
            grfDepositHn.Font = fEdit;
            grfDepositHn.Dock = System.Windows.Forms.DockStyle.None;
            grfDepositHn.Location = new System.Drawing.Point(0, 0);
            grfDepositHn.Rows.Count = 1;

            tabWithDraw.Controls.Add(grfWithDraw);
            tabWithDraw.Controls.Add(btnWithDrawSave);
            tabWithDraw.Controls.Add(txtWithDrawRemark);
            tabWithDraw.Controls.Add(lbtxtWithDrawRemark);
            tabWithDraw.Controls.Add(txtWithDrawName);
            tabWithDraw.Controls.Add(lbtxtWithDrawName);
            tabWithDraw.Controls.Add(txtWithDrawAmount);
            tabWithDraw.Controls.Add(lbtxtWithDrawAmount);
            tabWithDraw.Controls.Add(btnWithDrawSearch);
            tabWithDraw.Controls.Add(txtWithDrawVn);
            tabWithDraw.Controls.Add(txtWithDrawHn);
            tabWithDraw.Controls.Add(lbtxtWithDrawHn);
            tabWithDraw.Controls.Add(txtWithDrawDate);
            tabWithDraw.Controls.Add(lbtxtWithDrawDate);
            tabWithDraw.Controls.Add(txtWithDrawCode);
            tabWithDraw.Controls.Add(lbtxtWithDrawCode);
            tabWithDraw.Controls.Add(chkWithDrawActive);
            tabWithDraw.Controls.Add(chkWithDrawUnActive);
            tabWithDraw.Controls.Add(grfDepositHn);
            tabWithDraw.Controls.Add(lbtxtWithDrawAmt);
            tabWithDraw.Controls.Add(txtWithDrawAmt);
            tabWithDraw.Controls.Add(lbtxtWithDrawDeposit);
            tabWithDraw.Controls.Add(txtWithDrawDeposit);
            tabWithDraw.Controls.Add(cboPackageHn);
            tabWithDraw.Controls.Add(lbcboPackageHn);
            //theme1.SetTheme(cboPackageHn, ic.iniC.themeApp);
        }
        private void initCompomentTabDeposit()
        {
            int gapLine = 25, gapX = 20, gapY = 20, xCol2 = 150, xCol1 = 80, xCol3 = 330, xCol4 = 640, xCol5 = 950;
            Size size = new Size();

            tabDeposit = new C1DockingTabPage();
            tabDeposit.Location = new System.Drawing.Point(1, 24);
            //tabScan.Name = "c1DockingTabPage1";
            tabDeposit.Size = new System.Drawing.Size(667, 175);
            tabDeposit.TabIndex = 0;
            tabDeposit.Text = "Deposit";
            tabDeposit.Name = "tabDeposit";
            tcMain.Controls.Add(tabDeposit);

            lbtxtDepositCode = new Label();
            lbtxtDepositDate = new Label();
            lbtxtHn = new Label();
            lbtxtName = new Label();
            lbtxtDeposit = new Label();
            lbtxtRemark = new Label();
            txtDepositDate = new C1DateEdit();
            txtDepositCode = new C1TextBox();
            txtHn = new C1TextBox();
            txtName = new C1TextBox();
            txtDeposit = new C1TextBox();
            txtRemark = new C1TextBox();
            btnSave = new C1Button();
            btnSearch = new C1Button();
            chkAll = new C1CheckBox();
            chkActive = new RadioButton();
            chkUnActive = new RadioButton();
            txtId = new C1TextBox();
            lbcboPackage = new Label();
            cboPackage = new C1ComboBox();
            btnNew = new C1Button();

            ic.setControlLabel(ref lbtxtDepositCode, fEdit, "code :", "lbtxtDepositCode", gapX, gapY);
            ic.setControlC1TextBox(ref txtDepositCode, fEdit, "txtDepositCode", 120, xCol2, gapY);
            ic.setControlC1CheckBox(ref chkAll, fEdit, "All", "chkAll", xCol4, gapY);
            //gapY += gapLine;
            ic.setControlLabel(ref lbtxtDepositDate, fEdit, "Date Deposit :", "lbtxtDepositDate", xCol3, gapY);
            size = ic.MeasureString(lbtxtDepositDate);
            ic.setControlC1DateTimeEdit(ref txtDepositDate, "txtDepositDate", lbtxtDepositDate.Location.X + size.Width + 15, gapY);
            gapY += gapLine;
            ic.setControlLabel(ref lbtxtHn, fEdit, "HN :", "lbtxtHn", gapX, gapY);
            ic.setControlC1TextBox(ref txtHn, fEdit, "txtHn", 120, xCol2, gapY);
            ic.setControlC1Button(ref btnSearch, fEdit, "...", "btnSearch", txtHn.Location.X + txtHn.Width + 10, gapY - 4);
            btnSearch.Width = 30;
            btnSearch.Height = 25;
            ic.setControlLabel(ref lbtxtDeposit, fEdit, "Deposit :", "lbtxtDeposit", xCol3, gapY);
            size = ic.MeasureString(lbtxtDeposit);
            ic.setControlC1TextBox(ref txtDeposit, fEdit, "txtDeposit", 120, txtDepositDate.Location.X, gapY);
            txtDeposit.NumericInput = true;
            txtDeposit.DataType = typeof(decimal);

            ic.setControlRadioBox(ref chkActive, fEdit, "Active", "chkActive", xCol4, gapY);
            ic.setControlRadioBox(ref chkUnActive, fEdit, "UnActive", "chkUnActive", chkActive.Location.X + 80, gapY);

            gapY += gapLine;
            ic.setControlLabel(ref lbtxtName, fEdit, "Name :", "lbtxtName", gapX, gapY);
            ic.setControlC1TextBox(ref txtName, fEdit, "txtName", 400, xCol2, gapY);
            //gapY += gapLine;

            gapY += gapLine;
            ic.setControlLabel(ref lbtxtRemark, fEdit, "Remark :", "lbtxtRemark", gapX, gapY);
            ic.setControlC1TextBox(ref txtRemark, fEdit, "txtRemark", 400, xCol2, gapY);
            //gapY += gapLine;
            ic.setControlC1Button(ref btnSave, fEdit, "Save", "btnSave", xCol4, gapY);
            btnSave.Width = 70;
            ic.setControlC1Button(ref btnNew, fEdit, "New", "btnNew", btnSave.Location.X+ btnSave.Width + 30, gapY);
            btnNew.Width = 70;
            gapY += gapLine;
            ic.setControlLabel(ref lbcboPackage, fEdit, "Package :", "lbcboPackage", gapX, gapY);
            ic.setControlC1ComboBox(ref cboPackage, "cboPackage", 400, xCol2, gapY);

            grfDeposit = new C1FlexGrid();
            grfDeposit.Name = "grfDeposit";
            grfDeposit.Font = fEdit;
            grfDeposit.Dock = System.Windows.Forms.DockStyle.Bottom;
            grfDeposit.Location = new System.Drawing.Point(0, 0);
            grfDeposit.Rows.Count = 1;

            tabDeposit.Controls.Add(grfDeposit);

            tabDeposit.Controls.Add(lbtxtDepositCode);
            tabDeposit.Controls.Add(txtDepositCode);
            tabDeposit.Controls.Add(lbtxtDepositDate);
            tabDeposit.Controls.Add(txtDepositDate);
            tabDeposit.Controls.Add(lbtxtHn);
            tabDeposit.Controls.Add(txtHn);
            tabDeposit.Controls.Add(lbtxtName);
            tabDeposit.Controls.Add(txtName);
            tabDeposit.Controls.Add(lbtxtDeposit);
            tabDeposit.Controls.Add(txtDeposit);
            tabDeposit.Controls.Add(lbtxtRemark);
            tabDeposit.Controls.Add(txtRemark);
            tabDeposit.Controls.Add(btnSave);
            tabDeposit.Controls.Add(btnSearch);
            tabDeposit.Controls.Add(chkAll);
            tabDeposit.Controls.Add(chkActive);
            tabDeposit.Controls.Add(chkUnActive);
            tabDeposit.Controls.Add(lbcboPackage);
            tabDeposit.Controls.Add(cboPackage);
            tabDeposit.Controls.Add(btnNew);
        }
        private void initCompoment()
        {
            tcMain = new C1DockingTab();
            tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            tcMain.Location = new System.Drawing.Point(0, 266);
            tcMain.Name = "tcMain";
            //tcMain.Size = new System.Drawing.Size(669, 200);
            tcMain.TabIndex = 0;
            tcMain.TabsSpacing = 5;
            tcMain.ShowCaption = false;

            initCompomentTabDeposit();
            initCompomentTabWithDraw();
            this.Controls.Add(tcMain);

            //theme1.SetTheme(this, ic.iniC.themeApp);
        }
        
        private void setWithDraw()
        {
            dwithdraw.active = "1";
            dwithdraw.deposit_id = txtId.Text.Trim();
            dwithdraw.withdraw_id = txtWithDrawId.Text.Trim();
            dwithdraw.withdraw_name = txtWithDrawName.Text.Trim();
            dwithdraw.withdraw_code = txtWithDrawCode.Text.Trim();
            dwithdraw.withdraw_date = ic.datetoDB(txtWithDrawDate.Text);
            dwithdraw.patient_hn = txtHn.Text.Trim();
            dwithdraw.remark = txtWithDrawRemark.Text.Trim();
            dwithdraw.withdraw_amount = txtWithDrawAmount.Text;
            dwithdraw.visit_vn = txtWithDrawVn.Text;
            dwithdraw.t_visit_id = txtWithDrawVisitId.Text;
            dwithdraw.t_patient_id = txtWithDrawPttId.Text.Trim();
        }
        private void setGrfDeposit(String pttid, C1FlexGrid grf)
        {
            DataTable dt = new DataTable();
            grf.Rows.Count = 1;
            grf.Cols.Count = 10;
            if (grf.Name.Equals("grfDepositHn"))
            {
                dt = ic.ivfDB.depositDB.selectByPttId(pttid);
            }
            else
            {
                if (chkAll.Checked)
                {
                    dt = ic.ivfDB.depositDB.selectAll();
                }
                else
                {
                    dt = ic.ivfDB.depositDB.selectByPttId(pttid);
                }
            }
            grf.Rows.Count = dt.Rows.Count + 1;
            grf.Cols[colCode].Width = 100;
            grf.Cols[colHn].Width = 100;
            grf.Cols[colName].Width = 200;
            grf.Cols[colDate].Width = 120;
            grf.Cols[colDeposit].Width = 120;
            grf.Cols[colRemark].Width = 300;
            grf.Cols[colPck].Width = 300;

            grf.Cols[colCode].Caption = "CODE";
            grf.Cols[colHn].Caption = "HN";
            grf.Cols[colName].Caption = "Name";
            grf.Cols[colDate].Caption = "Date";
            grf.Cols[colDeposit].Caption = "Deposit";
            grf.Cols[colRemark].Caption = "Remark";
            grf.Cols[colPck].Caption = "Package";
            grf.Cols[colAmount].Caption = "Amount";
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("ต้องการ Void Deposit", new EventHandler(ContextMenu_void_Deposit));
            grf.ContextMenu = menuGw;
            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                decimal deposit = 0, amount=0;
                decimal.TryParse(row["deposit_amount"].ToString(), out deposit);
                decimal.TryParse(row["amount"].ToString(), out amount);
                grf[i, 0] = i;
                grf[i, colId] = row["deposit_id"].ToString();
                grf[i, colCode] = row["deposit_code"].ToString();
                grf[i, colHn] = row["patient_hn"].ToString();
                grf[i, colName] = row["deposit_name"].ToString();
                grf[i, colDate] = ic.datetoShow(row["deposit_date"].ToString());
                grf[i, colDeposit] = deposit.ToString("#,###.00");
                grf[i, colRemark] = row["remark"].ToString();
                grf[i, colPck] = row["PackageName"].ToString();
                grf[i, colAmount] = amount.ToString("#,###.00");
                i++;
            }
            grf.Cols[colId].Visible = false;
            grf.Cols[colCode].AllowEditing = false;
            grf.Cols[colHn].AllowEditing = false;
            grf.Cols[colName].AllowEditing = false;
            grf.Cols[colDate].AllowEditing = false;
            grf.Cols[colDeposit].AllowEditing = false;
            grf.Cols[colRemark].AllowEditing = false;
            grf.Cols[colAmount].AllowEditing = false;
        }
        private void ContextMenu_void_Deposit(object sender, System.EventArgs e)
        {
            if (grfDeposit == null) return;
            if (grfDeposit.Row <= 0) return;
            if (grfDeposit.Col <= 0) return;

            if (MessageBox.Show("ต้องการ ยกเลิกรายการ  ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {

            }
        }
        private void setDeposit()
        {
            String doc = "", re = "";
            
            if (txtId.Text.Length <= 0)
            {
                doc = ic.ivfDB.copDB.genDepositDoc();
                deposit.deposit_code = doc;
                txtDepositCode.Value = doc;
            }
            deposit.active = "1";
            deposit.deposit_id = txtId.Text.Trim();
            deposit.deposit_name = txtName.Text.Trim();
            
            deposit.deposit_date = ic.datetoDB(txtDepositDate.Text);
            deposit.patient_hn = txtHn.Text.Trim();
            deposit.remark = txtRemark.Text.Trim();
            deposit.deposit_amount = txtDeposit.Text;
            deposit.t_patient_id = ptt.t_patient_id;
            deposit.pck_id = cboPackage.SelectedItem == null ? "" : ((ComboBoxItem)cboPackage.SelectedItem).Value;
        }
        private void setGrfWithDraw(String hn)
        {
            DataTable dt = new DataTable();
            grfWithDraw.Rows.Count = 1;
            grfWithDraw.Cols.Count = 9;
            
            dt = ic.ivfDB.dwitdrawDB.selectByDepositId(hn);

            grfWithDraw.Rows.Count = dt.Rows.Count + 1;
            grfWithDraw.Cols[colCode].Width = 100;
            grfWithDraw.Cols[colHn].Width = 100;
            grfWithDraw.Cols[colName].Width = 200;
            grfWithDraw.Cols[colDate].Width = 120;
            grfWithDraw.Cols[colDeposit].Width = 120;
            grfWithDraw.Cols[colRemark].Width = 300;

            grfWithDraw.Cols[colCode].Caption = "CODE";
            grfWithDraw.Cols[colHn].Caption = "VN";
            grfWithDraw.Cols[colName].Caption = "Name";
            grfWithDraw.Cols[colDate].Caption = "Date";
            grfWithDraw.Cols[colDeposit].Caption = "WithDraw";
            grfWithDraw.Cols[colRemark].Caption = "Remark";
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("Receive operation", new EventHandler(ContextMenu_void_Deposit));
            grfWithDraw.ContextMenu = menuGw;
            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                grfWithDraw[i, 0] = i;
                grfWithDraw[i, colId] = row["withdraw_id"].ToString();
                grfWithDraw[i, colCode] = row["withdraw_code"].ToString();
                grfWithDraw[i, colHn] = row["visit_vn"].ToString();
                grfWithDraw[i, colName] = row["withdraw_name"].ToString();
                grfWithDraw[i, colDate] = ic.datetoShow(row["withdraw_date"].ToString());
                grfWithDraw[i, colDeposit] = row["withdraw_amount"].ToString();
                grfWithDraw[i, colRemark] = row["remark"].ToString();
                i++;
            }
            grfWithDraw.Cols[colId].Visible = false;
            grfWithDraw.Cols[colCode].AllowEditing = false;
            grfWithDraw.Cols[colHn].AllowEditing = false;
            grfWithDraw.Cols[colName].AllowEditing = false;
            grfWithDraw.Cols[colDate].AllowEditing = false;
            grfWithDraw.Cols[colDeposit].AllowEditing = false;
            grfWithDraw.Cols[colRemark].AllowEditing = false;
        }
        
        private void FrmDeport_Load(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.Size = new Size(900, 900);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Top = 100;
            this.Left = this.Left - 200;
            grfDeposit.Height = this.Height - 300;
            grfDeposit.Top = 130;
            grfWithDraw.Height = this.Height - 430;
            grfWithDraw.Top = 400;
            grfDepositHn.Height = this.Height - 430 - (txtWithDrawAmount.Location.Y + 35) - 140;
            grfDepositHn.Top = txtWithDrawAmount.Location.Y + 65;
            grfDepositHn.Width = this.Width - 20;
            if (flagCashier)
            {
                tcMain.TabPages[0].Visible = false;
                tcMain.ShowTabs = false;
            }
            theme1.SetTheme(lbtxtHn, this.theme1.Theme);
            theme1.SetTheme(lbtxtWithDrawHn, this.theme1.Theme);
        }
    }
}