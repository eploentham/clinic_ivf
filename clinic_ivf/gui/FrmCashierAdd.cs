using C1.Win.C1Command;
using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1SplitContainer;
using C1.Win.C1SuperTooltip;
using clinic_ivf.control;
using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.gui
{
    /*
     * 62-07-16     0007        Cashier	ลง table BillDetail ไม่ได้เอา bill_id ลงด้วย
     * 63-10-27     0020        เรื่อง		เลิก insert table Visit
     * 
     */
    public partial class FrmCashierAdd : Form
    {
        IvfControl ic;
        MainMenu menu;
        public C1DockingTabPage tab;
        public FrmCashierView frmCashView;
        String billid = "", pttid = "", vsid = "", vsidOld = "", vn = "", printerOld = "", receiptno = "", flagedit = "";
        OldBillheader obilh;
        //VisitOld ovs;
        PatientOld optt;
        Patient ptt;
        Visit vs;

        C1FlexGrid grfBillD, grfOrder, grfReceipt, grfPkgPayPeriod;
        Font fEdit, fEditB, ff, ffB;
        Color bg, fc, color;

        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        Panel pnOrder, pnBill;
        OldCashAccount oca;
        OldCreditCardAccount ocr;

        int colId = 1, colName = 2, colprice=3, colqty=4, colAmt = 5, colDiscount = 6, colNetAmt = 7, colGrpName=8, colBilId=9, colInclude=10, colStatus=11;
        int colOrdid = 1, colOrdDate = 2, colOrdlpid = 3, colOrdName = 4, colOrdPrice = 5, colOrdPrice1 = 6, colOrdQty = 7, colOrdstatus = 8, colOrdrow1 = 9, colOrditmid = 10, colOrdInclude = 11, colOrdAmt = 12, colOrdUsE = 13, colOrdUsT = 14, colOrdOrderId = 15, colOrdStatusAmt = 16, colOrdStatusOrdGrp = 17;
        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetDefaultPrinter(string Printer);
        public static PrinterSettings Printer_Settings = new System.Drawing.Printing.PrinterSettings();
        /// <summary>
        /// Get or Sets the session's Default Printer
        /// </summary>
        public static string Session_DefaultPrinter
        {
            get { return Printer_Settings.PrinterName; }
            set
            {
                SetDefaultPrinter(value);
                Printer_Settings.DefaultPageSettings.PrinterSettings.PrinterName = value;
                Printer_Settings.PrinterName = value;
            }
        }
        public FrmCashierAdd(IvfControl ic, MainMenu m, String billid, String vnold, String flagedit)
        {
            InitializeComponent();
            menu = m;
            this.ic = ic;
            this.vn = vnold;
            this.billid = billid;
            this.flagedit = flagedit;
            initConfig();
        }
        public FrmCashierAdd(IvfControl ic, MainMenu m, String billid, String vnold, String flagedit, String receiptno)
        {
            InitializeComponent();
            menu = m;
            this.ic = ic;
            this.vn = vnold;
            this.billid = billid;
            this.flagedit = flagedit;
            this.receiptno = receiptno;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);
            //ovs = new VisitOld();
            optt = new PatientOld();
            ptt = new Patient();
            obilh = new OldBillheader();

            //C1ThemeController.ApplicationTheme = ic.iniC.themeApplication;
            //theme1.Theme = C1ThemeController.ApplicationTheme;
            theme1.SetTheme(sB, "BeigeOne");
            color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);

            sB1.Text = "";
            bg = txtHn.BackColor;
            fc = txtHn.ForeColor;
            ff = txtHn.Font;
            ic.ivfDB.ocaDB.setCboCashAccount(cboAccCash, "");
            ic.ivfDB.ocrDB.setCboCreditCardAccount(cboAccCredit, "");
            ic.ivfDB.actDB.setCboAccCashTransfer(cboAccCashTransfer, "");
            ic.ivfDB.obilgDB.setCboGroupType(cboGrpType, "0");
            ic.ivfDB.acbDB.setCboAccCreditBank(cboCreditBank,"");
            txtCreditCharge.Value = ic.iniC.creditCharge;

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            oca = new OldCashAccount();
            ocr = new OldCreditCardAccount();

            chkDiscount.CheckedChanged += ChkDiscount_CheckedChanged;
            chkDiscountPer.CheckedChanged += ChkDiscountPer_CheckedChanged;
            //txtAmt.KeyPress += TxtAmt_KeyPress;
            txtDiscount.KeyPress += TxtDiscount_KeyPress;
            txtAmt.KeyUp += TxtAmt_KeyUp;
            txtDiscount.KeyUp += TxtDiscount_KeyUp;
            txtTotalCash.KeyUp += TxtTotalCash_KeyUp;
            txtTotalCredit.KeyUp += TxtTotalCredit_KeyUp;
            btnPrnBill.Click += BtnPrnBill_Click;
            txtCreditCharge.KeyUp += TxtCreditCharge_KeyUp;
            btnCalBack.Click += BtnCalBack_Click;
            btnClose.Click += BtnClose_Click;
            btnChargeAdd.Click += BtnChargeAdd_Click;
            btnDiscountAdd.Click += BtnDiscountAdd_Click;
            txtDiscountAmt.KeyUp += TxtDiscountAmt_KeyUp;
            chkDiscountCash.Click += ChkDiscountCash_Click;
            chkDiscountPer.Click += ChkDiscountPer_Click;
            btnPrnReceipt.Click += BtnPrnReceipt_Click;
            btnPayPeriod.Click += BtnPayPeriod_Click;
            btnItmAdd.Click += BtnItmAdd_Click;
            btnDeposit.Click += BtnDeposit_Click;
            //txtTotalCash.KeyPress += TxtTotalCash_KeyPress;
            //txtTotalCredit.KeyPress += TxtTotalCredit_KeyPress;

            ChkDiscountPer_CheckedChanged(null, null);
            initGrf();
            initGrfBillD();
            initGrfOrder();
            initGrfReceipt();
            initGrfPkgPayPeriod();
            setChkDiscount(false);
            setControl();
            setGrfOrder(vs.visit_vn);
            setGrfReceipt();        //ช้า
            setGrfPkgPayPeriod();
            //ic.ivfDB.copDB.cop = ic.ivfDB.copDB.selectByCode2("001");
            //year = DateTime.Now.ToString("yyyy");

            //MessageBox.Show(DateTime.Now.ToString("yyyy"), "");
            //MessageBox.Show(DateTime.Now.ToString("MM"), "");
            //MessageBox.Show(DateTime.Now.ToString("dd"), "");
        }

        private void BtnDeposit_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.deposit = "";
            ic.dwithdrawid = "";
            FrmDeposit frm = new FrmDeposit(ic, txtPttId.Text.Trim(), txtVsId.Text.Trim());
            frm.FormBorderStyle = FormBorderStyle.FixedSingle;
            frm.WindowState = FormWindowState.Normal;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog(this);
            if (ic.dwithdrawid.Length > 0)
            {
                OldBilldetail obilld = new OldBilldetail();
                obilld.ID = "";
                obilld.VN = txtVn.Text;
                obilld.Name = "OtherService discount ";
                obilld.Extra = "1";
                obilld.item_id = "2640000191";      // form table specialitem
                obilld.status = "special";
                obilld.qty = "1";
                obilld.Price = "-" + ic.deposit.Replace(",", "");
                obilld.Total = "-" + ic.deposit.Replace(",", "");
                obilld.price1 = "-" + ic.deposit.Replace(",", "");
                obilld.Comment = ic.dwithdrawid;
                obilld.bill_group_id = "2650000099";            // form table billgroup
                obilld.GroupType = "Discount";
                obilld.bill_id = txtBillId.Text;
                long chk = 0;
                String re = ic.ivfDB.obildDB.insertBillDetail(obilld, "");
                if (long.TryParse(re, out chk))
                {
                    setGrfBillD();
                    calTotal("");
                    calTotalCredit("");
                }
            }
        }

        private void BtnItmAdd_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

        }

        private void initGrf()
        {
            C1SplitterPanel scOrder = new C1.Win.C1SplitContainer.C1SplitterPanel();
            C1SplitterPanel scBill = new C1.Win.C1SplitContainer.C1SplitterPanel();
            C1SplitContainer sC = new C1.Win.C1SplitContainer.C1SplitContainer();
            pnOrder = new Panel();
            pnOrder.Dock = DockStyle.Fill;
            pnOrder.Name = "pnOrder";
            pnBill = new Panel();
            pnBill.Dock = DockStyle.Fill;
            pnBill.Name = "pnBill";

            sC.SuspendLayout();
            scOrder.SuspendLayout();
            scBill.SuspendLayout();
            pnOrder.SuspendLayout();
            pnBill.SuspendLayout();

            scOrder.Collapsible = true;
            scOrder.Dock = C1.Win.C1SplitContainer.PanelDockStyle.Right;
            scOrder.Location = new System.Drawing.Point(0, 21);
            scOrder.Name = "scOrder";
            scOrder.Controls.Add(pnOrder);
            scBill.Collapsible = true;
            scBill.Dock = C1.Win.C1SplitContainer.PanelDockStyle.Left;
            scBill.Location = new System.Drawing.Point(0, 21);
            scBill.Name = "scBill";
            scBill.Controls.Add(pnBill);
            sC.AutoSizeElement = C1.Framework.AutoSizeElement.Both;
            sC.Name = "sC";
            sC.Dock = System.Windows.Forms.DockStyle.Fill;
            sC.Panels.Add(scOrder);
            sC.Panels.Add(scBill);
            
            sC.HeaderHeight = 20;
            scOrder.SizeRatio = 2;

            scBill.ResumeLayout(false);
            scOrder.ResumeLayout(false);
            sC.ResumeLayout(false);
            pnBill.ResumeLayout(false);
            pnOrder.ResumeLayout(false);
            pnBill.PerformLayout();
            pnOrder.PerformLayout();
            scBill.PerformLayout();
            scOrder.PerformLayout();
            sC.PerformLayout();

            pnBillD.Controls.Add(sC);
        }
        private void BtnPayPeriod_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            int gapY = 30, gapX = 20, gapLine = 0, gapColName = 120;
            Size size = new Size();

            Form frm = new Form();
            frm.WindowState = FormWindowState.Normal;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Size = new Size(400, 400);
            Label lbPeriod1, lbPeriod2, lbPeriod3, lbPeriod4;
            C1TextBox txtPeriod1, txtPeriod2, txtPeriod3, txtPeriod4;
            lbPeriod1 = new Label();
            lbPeriod1.Text = "งวด 1.";
            lbPeriod1.Font = fEdit;
            lbPeriod1.Location = new System.Drawing.Point(gapX, 5);
            lbPeriod1.AutoSize = true;
            lbPeriod1.Name = "lbPeriod1";
            txtPeriod1 = new C1TextBox();
            txtPeriod1.Font = fEdit;
            txtPeriod1.Name = "txtPeriod1";
            txtPeriod1.Location = new System.Drawing.Point(gapColName, lbPeriod1.Location.Y);
            txtPeriod1.Size = new Size(120, 20);
            gapLine += gapY;
            lbPeriod2 = new Label();
            lbPeriod2.Text = "งวด 2.";
            lbPeriod2.Font = fEdit;
            lbPeriod2.Location = new System.Drawing.Point(gapX, gapLine);
            lbPeriod2.AutoSize = true;
            lbPeriod2.Name = "lbPeriod2";
            txtPeriod2 = new C1TextBox();
            txtPeriod2.Font = fEdit;
            txtPeriod2.Name = "txtPeriod2";
            txtPeriod2.Location = new System.Drawing.Point(gapColName, lbPeriod2.Location.Y);
            txtPeriod2.Size = new Size(120, 20);
            gapLine += gapY;

            frm.Controls.Add(lbPeriod1);
            frm.Controls.Add(txtPeriod1);
            frm.Controls.Add(lbPeriod2);
            frm.Controls.Add(txtPeriod2);
            frm.ShowDialog(this);
        }

        private void BtnPrnReceipt_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.cStf.staff_id = "";
            FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            frm.ShowDialog(this);
            if (!ic.cStf.staff_id.Equals(""))
            {
                String cashid1 = "", creditid1 = "", transferid = "";
                cashid1 = cboAccCash.SelectedItem == null ? "" : ((ComboBoxItem)cboAccCash.SelectedItem).Value;
                creditid1 = cboAccCredit.SelectedItem == null ? "" : ((ComboBoxItem)cboAccCredit.SelectedItem).Value;
                transferid = cboAccCashTransfer.SelectedItem == null ? "" : ((ComboBoxItem)cboAccCashTransfer.SelectedItem).Value;
                if (cashid1.Length == 0 && creditid1.Length == 0 && transferid.Length == 0)
                {
                    MessageBox.Show("ยังไม่ได้เลือก ประเภทบัญชี", "");
                    return;
                }
                String flag = "";
                if (cashid1.Length > 0)
                {
                    oca = ic.ivfDB.ocaDB.selectByPk1(cashid1);
                    //flag = oca.IntLock.Equals("1") ? "2" : "1";
                    flag = oca.IntLock;
                }
                else if (creditid1.Length > 0 && !creditid1.Equals("0"))
                {
                    ocr = ic.ivfDB.ocrDB.selectByPk1(creditid1);
                    //flag = ocr.IntLock.Equals("1") ? "2" : "1";
                    flag = ocr.IntLock;
                }
                else if (transferid.Length > 0)
                {
                    AccCashTransfer act = ic.ivfDB.actDB.selectByPk(transferid);
                    //flag = ocr.IntLock.Equals("1") ? "2" : "1";
                    if (act.Equals("2760000002"))
                    {
                        flag = "2";
                    }
                    
                }
                //if (flag.Equals("1"))
                if (flag.Equals("0"))
                {
                    printReceipt("");
                }
                else
                {
                    //printReceipt("");
                    printReceipt("2");
                    //printReceipt("2");
                }
                ic.ivfDB.vsDB.updateStatusCashierFinish(txtVn.Text);
            }
        }
        private void printReceipt(String flagExtra)
        {
            String cashid1 = "", creditid1 = "", transferid="", creditbankik="";
            cashid1 = cboAccCash.SelectedItem == null ? "" : ((ComboBoxItem)cboAccCash.SelectedItem).Value;
            creditid1 = cboAccCredit.SelectedItem == null ? "" : ((ComboBoxItem)cboAccCredit.SelectedItem).Value;
            transferid = cboAccCashTransfer.SelectedItem == null ? "" : ((ComboBoxItem)cboAccCashTransfer.SelectedItem).Value;
            creditbankik = cboCreditBank.SelectedItem == null ? "" : ((ComboBoxItem)cboCreditBank.SelectedItem).Value;
            //cboCreditBank
            if (cashid1.Length == 0 && creditid1.Length == 0 && transferid.Length == 0)
            {
                MessageBox.Show("ยังไม่ได้เลือก ประเภทบัญชี", "");
                return;
            }

            Decimal totalcredit = 0, totalcash = 0, total = 0, discount = 0, totaltransfer=0;
            Decimal.TryParse(txtTotalCredit.Text.Replace(",", ""), out totalcredit);
            Decimal.TryParse(txtTotalCash.Text.Replace(",", ""), out totalcash);
            Decimal.TryParse(txtTotalTransfer.Text.Replace(",", ""), out totaltransfer);

            if (cashid1.Equals("") && totalcash > 0)
            {
                MessageBox.Show("มียอด cash ไม่ยังไม่ได้เลือก ประเภทบัญชี", "");
                return;
            }
            if (!cashid1.Equals("") && totalcash <= 0)
            {
                if (!cboAccCash.Text.Equals("-"))
                {
                    MessageBox.Show("มียอด cash แต่ไม่ได้ป้อน จำนวนเงิน", "");
                    txtTotalCash.Focus();
                    return;
                }
            }
            if (creditid1.Equals("") && totalcredit > 0)
            {
                MessageBox.Show("มียอด credit ไม่ยังไม่ได้เลือก ประเภทบัญชี", "");
                return;
            }
            if (!creditid1.Equals("") && totalcredit <= 0)
            {
                if (!cboAccCredit.Text.Equals("-"))
                {
                    MessageBox.Show("มียอด credit แต่ไม่ได้ป้อน จำนวนเงิน", "");
                    txtTotalCash.Focus();
                    return;
                }
            }
            if (transferid.Equals("") && totaltransfer > 0)
            {
                MessageBox.Show("มียอด transfer ไม่ยังไม่ได้เลือก ประเภทบัญชี", "");
                return;
            }
            if (!transferid.Equals("") && totaltransfer <= 0)
            {
                MessageBox.Show("มียอด transfer แต่ไม่ได้ป้อน จำนวนเงิน", "");
                txtTotalCash.Focus();
                return;
            }
            if (Decimal.TryParse(txtDiscount.Text.Replace(",", ""), out discount))
            {
                //if (creditid1.Equals(""))
                //{
                //    MessageBox.Show("มียอด discount ไม่ยังไม่ได้เลือก ประเภทบัญชี", "");
                //    return;
                //}
            }
            total = totalcash + totalcredit+ totaltransfer;
            if (total <= 0)
            {
                MessageBox.Show("ไม่ได้ป้อน จำนวนเงิน", "");
                txtTotalCash.Focus();
                return;
            }
            PrinterSettings settings = new PrinterSettings();
            printerOld = settings.PrinterName;
            SetDefaultPrinter(ic.iniC.printerBill);
            settings.PrinterName = ic.iniC.printerBill;

            //string stashPrinterName = Session_DefaultPrinter;
            //Session_DefaultPrinter = ic.iniC.printerBill;

            DataTable dt = new DataTable();
            DataTable dtprn = new DataTable();
            DataTable dtpgk = new DataTable();
            Decimal amt = 0, sumprice = 0, price1 = 0, cash = 0, credit = 0;
            long amt1 = 0;
            String amt2 = "", billNo = "", billExtNo = "", payby = "", date = "", year = "", month = "", day = "", billFormat = "", receiptno11 = "", billnoex1 = "", agentId = "";
            long.TryParse(amt.ToString(), out amt1);
            
            if (receiptno.Length > 0)
            {
                dt = ic.ivfDB.printBill(txtVn.Text, ref amt, ref payby, txtBillId.Text);
                receiptno11 = receiptno;
            }
            else
            {
                dt = ic.ivfDB.printBill(txtVn.Text, ref amt, ref payby, "");
                //receiptno11 = ic.ivfDB.obilhDB.selectReceiptNoByVN(ovs.VN);           //      -0020
                receiptno11 = ic.ivfDB.obilhDB.selectReceiptNoByVN(vs.visit_vn);             //      +0020
            }
            //billnoex1 = ic.ivfDB.obilhDB.selectBillNoExByVN(ovs.VN);
            //new LogWriter("e", "printReceipt receiptno " + receiptno);
            if (flagExtra.Equals("2") && !flagedit.Equals("noedit")) receiptno11 = "";      //พิมพ์ ใบเสร็จ 2 ชุด
            if (receiptno11.Length <= 0)
            {
                //new LogWriter("e", "printReceipt flagExtra "+ flagExtra);
                if(flagExtra.Length > 0)
                {
                    billExtNo = ic.ivfDB.copDB.genReceiptExtDoc();
                }
                
                billNo = ic.ivfDB.copDB.genReceiptDoc(ref year, ref month, ref day, flagExtra);
                //String cashid = cboAccCash.SelectedItem == null ? "" : ((ComboBoxItem)cboAccCash.SelectedItem).Value;
                //String creditid = cboAccCredit.SelectedItem == null ? "" : ((ComboBoxItem)cboAccCredit.SelectedItem).Value;
                //String cashtransferid = cboAccCashTransfer.SelectedItem == null ? "" : ((ComboBoxItem)cboAccCashTransfer.SelectedItem).Value;
                //ic.ivfDB.obilhDB.updateReceiptNo(txtVn.Text, billNo, txtTotalCash.Text.Replace(",",""), txtTotalCredit.Text.Replace(",", ""), txtCreditCardNumber.Text, cashid, creditid);
                if (flagExtra.Equals("2"))
                {
                    ic.ivfDB.obilhDB.updateReceipt1NoByBillId(txtBillId.Text, billNo, totalcash.ToString(), totalcredit.ToString()
                    , txtCreditCardNumber.Text, cashid1, creditid1, total.ToString(), discount.ToString(), txtPayName.Text, totaltransfer.ToString(), transferid, creditbankik);
                }
                else
                {
                    //ic.ivfDB.obilhDB.updateReceiptNoByBillId(txtBillId.Text, billNo, txtTotalCash.Text.Replace(",", ""), txtTotalCredit.Text.Replace(",", "")
                    //, txtCreditCardNumber.Text, cashid1, creditid1, total.ToString(), discount.ToString(), txtPayName.Text, totaltransfer.ToString(), transferid);
                    ic.ivfDB.obilhDB.updateReceiptNoByBillId(txtBillId.Text, billNo, totalcash.ToString(), totalcredit.ToString()
                    , txtCreditCardNumber.Text, cashid1, creditid1, total.ToString(), discount.ToString(), txtPayName.Text, totaltransfer.ToString(), transferid, creditbankik);
                    //OldBillheader obill = new OldBillheader();
                }
                
                String billno2 = ic.ivfDB.obilhDB.selectBillNoByVN(txtVn.Text);
                if (billno2.Equals(""))
                {
                    String billNo1 = ic.ivfDB.copDB.genBillingDoc(ref year, ref month, ref day);
                    String billExtNo1 = ic.ivfDB.copDB.genBillingExtDoc();
                    //ic.ivfDB.obilhDB.updateBillNo(txtVn.Text, billNo1);
                    ic.ivfDB.obilhDB.updateBillNoByBillId(txtBillId.Text, billNo1);
                }

                //dtpgk = ic.ivfDB.opkgsDB.selectByVN1(txtVn.Text);
                //dtpgk = ic.ivfDB.opkgsDB.selectByPID(ovs.PID);    // ต้องดึงตาม HN เพราะ ถ้ามีงวดการชำระ          //      -0020
                dtpgk = ic.ivfDB.opkgsDB.selectByPID(vs.t_patient_id);    // ต้องดึงตาม HN เพราะ ถ้ามีงวดการชำระ            //      +0020
                foreach (DataRow row in dtpgk.Rows)
                {
                    String times = "";
                    Decimal price = 0;
                    //row["PaymentTimes"].GetType()
                    times = row["payment_times"].ToString();
                    //ic.ivfDB.updatePackagePaymentComplete(ovs.PID, row["PCKSID"].ToString());          //      -0020
                    ic.ivfDB.updatePackagePaymentComplete(vs.t_patient_id, row["PCKSID"].ToString());            //      +0020
                    if (Decimal.TryParse(row["Payment1"].ToString(), out price) && row["P1BDetailID"].ToString().Equals("0"))
                    {
                        ic.ivfDB.opkgsDB.updateP1BillNo(row["PCKSID"].ToString(), billNo.Replace(ic.cop.prefix_receipt_doc, "").Replace(ic.cop.prefix_receipt1_doc, ""));
                        //times = "1";
                    }
                    else if (Decimal.TryParse(row["Payment2"].ToString(), out price) && row["P2BDetailID"].ToString().Equals("0"))
                    {
                        ic.ivfDB.opkgsDB.updateP2BillNo(row["PCKSID"].ToString(), billNo.Replace(ic.cop.prefix_receipt_doc, "").Replace(ic.cop.prefix_receipt1_doc, ""));
                    }
                    else if (Decimal.TryParse(row["Payment3"].ToString(), out price) && row["P3BDetailID"].ToString().Equals("0"))
                    {
                        ic.ivfDB.opkgsDB.updateP3BillNo(row["PCKSID"].ToString(), billNo.Replace(ic.cop.prefix_receipt_doc, "").Replace(ic.cop.prefix_receipt1_doc, ""));
                    }
                    else if (Decimal.TryParse(row["Payment4"].ToString(), out price) && row["P4BDetailID"].ToString().Equals("0"))
                    {
                        ic.ivfDB.opkgsDB.updateP4BillNo(row["PCKSID"].ToString(), billNo.Replace(ic.cop.prefix_receipt_doc, "").Replace(ic.cop.prefix_receipt1_doc, ""));
                    }
                }
            }
            else
            {
                if (flagExtra.Equals("2") && flagedit.Equals("noedit"))
                {
                    billNo = obilh.receipt1_no;
                    billExtNo = billnoex1;
                }
                else
                {
                    billNo = receiptno11;
                    billExtNo = billnoex1;
                }
            }
            //dtprn.Columns.Add("col1", typeof(String));
            //dtprn.Columns.Add("col2", typeof(String));
            //dtprn.Columns.Add("col3", typeof(String));
            //dtprn.Columns.Add("col4", typeof(String));
            //dtprn.Columns.Add("sort1", typeof(String));
            //dtprn.Columns.Add("fond_bold", typeof(String));
            //dtprn.Columns.Add("grp", typeof(String));
            //dtprn.Columns.Add("grp_name", typeof(String));
            dtprn = dt.Clone();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    //DataRow row = dtprn.NewRow();
                    row["original"] = "1";
                    dtprn.ImportRow(row);

                    int page = 0;
                    
                    row["original"] = "2";
                    Decimal.TryParse(row["col2"].ToString().Replace(",", ""), out price1);
                    sumprice += price1;
                    dtprn.ImportRow(row);
                    if (flagExtra.Equals("2"))
                    {
                        row["original"] = "3";
                        //row["original"] = "2";
                        dtprn.ImportRow(row);
                    }
                }
            }
            else
            {
                DataRow row11 = dtprn.NewRow();
                row11["col1"] = "";
                row11["col2"] = "0.00";
                row11["col3"] = "";
                row11["col4"] = "0.00";
                row11["sort1"] = "";
                row11["fond_bold"] = "1";
                row11["grp"] = "3";
                row11["grp_name"] = "";
                row11["original"] = "1";
                dtprn.Rows.Add(row11);
            }

            //String re = ic.ivfDB.ovsDB.updateStatusCashierFinish(txtVn.Text);     // -0020
            String re1 = ic.ivfDB.vsDB.updateCloseStatusCashier(txtVsId.Text);     // +0020

            amt2 = ic.NumberToCurrencyTextThaiBaht(amt, MidpointRounding.AwayFromZero);
            //Decimal.TryParse(txtTotalCash.Text, out cash);
            //Decimal.TryParse(txtTotalCredit.Text, out credit);
            if ((totalcash > 0) && (totalcredit <= 0) && (totaltransfer <= 0))
            {
                payby = "เงินสด/Cash ";
            }
            else if ((totalcash <= 0) && (totalcredit > 0) && (totaltransfer <= 0))
            {
                payby = "เครดิตการ์ด/Credit Card ";
            }
            else if ((totalcash > 0) && (totalcredit > 0) && (totaltransfer <= 0))
            {
                payby = "เงินสด และเครดิตการ์ด/Cash & Credit Card ";
            }
            else if ((totalcash > 0) && (totalcredit <= 0) && (totaltransfer > 0))
            {
                payby = "เงินสด และเงินโอน/Cash & Cash Transfer ";
            }
            else if ((totalcash <= 0) && (totalcredit > 0) && (totaltransfer > 0))
            {
                payby = "เครดิตการ์ด และเงินโอน/Credit Card & Cash Transfer ";
            }
            else if ((totalcash > 0) && (totalcredit > 0) && (totaltransfer > 0))
            {
                payby = "เงินสด และเครดิตการ์ด และเงินโอน/Cash & Credit Card & Cash Transfer ";
            }
            else if ((totalcash <= 0) && (totalcredit <= 0) && (totaltransfer > 0))
            {
                payby = "เงินโอน/Cash Transfer ";
            }
            else
            {
                payby = "unknow payment";
            }
            if (billNo.Length > 5)
            {
                billFormat = billNo.Substring(billNo.Length - 5);
                billNo = billNo.Substring(0, billNo.Length - 5) + "-" + billFormat;
            }
            String cardname = "";
            cardname = cboCreditBank.Text.Replace("-","");
            if (cboCreditBank.Text.Replace("-", "").Length > 0)
            {
                cardname = cboCreditBank.Text.Replace("-", "");
            }


            //deposit process
            setBillIdDeposit();


            //day = DateTime.Now.ToString("dd"); 
            //month = DateTime.Now.ToString("MM");
            //year = DateTime.Now.ToString("yyyy");
            day = ic.cop.day;
            month = ic.cop.month;
            year = ic.cop.year;
            String datecreate = "", timecreate="";
            datecreate = obilh.date_create;
            DateTime dtdatecreate = new DateTime();
            if(DateTime.TryParse(datecreate, out dtdatecreate))
            {
                timecreate = dtdatecreate.ToString("HH:mm");
            }
            String billdate = ic.datetoShow(obilh.Date);
            btnPrnReceipt.Enabled = false;
            FrmReport frm = new FrmReport(ic);
            new LogWriter("e", "printReceipt billNo " + billNo);
            //frm.setPrintBill(dtprn, txtHn.Text, txtPttNameE.Text, amt2, amt.ToString("#,###.00"), billNo, day + "/" + month + "/" + year, payby, "ใบเสร็จ/Receipt", sumprice.ToString("#,###.00"), flagExtra);
            frm.setPrintBill(dtprn, txtHn.Text, txtPttNameE.Text, amt2, amt.ToString("#,###.00"), billNo, billdate+" "+ timecreate, payby, "ใบเสร็จ/Receipt", sumprice.ToString("#,###.00"), flagExtra, cardname);
            frm.Show(this);
        }
        private void ChkDiscountPer_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            txtDiscount.Value = "";
            if (chkDiscountPer.Checked)
            {
                panel3.Enabled = true;
            }
        }

        private void ChkDiscountCash_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            txtDiscount.Value = "";
            if (chkDiscountCash.Checked)
            {
                panel3.Enabled = false;
            }
        }

        private void TxtDiscountAmt_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if(e.KeyCode == Keys.Enter)
            {
                if (chkDiscountCash.Checked)
                {
                    if (chkDiscountAll.Checked)
                    {
                        
                    }
                    else
                    {

                    }
                }
                else
                {
                    Decimal discount = 0, discountper = 0;
                    Decimal.TryParse(txtDiscountAmt.Text, out discountper);
                    if (chkDiscountAll.Checked)
                    {
                        Decimal amt = 0;
                        Decimal.TryParse(txtAmt.Text, out amt);
                        discount = amt * (discountper / 100);
                        //txtDiscount.Value = discount.ToString();
                    }
                    else
                    {
                        Decimal netamt = 0;
                        foreach (Row row in grfBillD.Rows)
                        {
                            String amt1 = "", grp="", name="";
                            Decimal amt = 0;
                            try
                            {
                                grp = row[colGrpName].ToString();
                                amt1 = row[colAmt].ToString();
                                name = row[colName].ToString();
                                if (grp.Equals("OtherService") && name.Equals("OtherService"))
                                {

                                }
                                else if(grp.Equals(cboGrpType.Text))
                                {
                                    if(Decimal.TryParse(amt1, out amt))
                                    {
                                        netamt += amt;
                                    }
                                }
                            }
                            catch(Exception ex)
                            {

                            }
                        }
                        discount = netamt * (discountper / 100);
                    }
                    txtDiscount.Value = discount.ToString();
                }
            }
        }

        private void BtnDiscountAdd_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if(txtDiscount.Enabled == true)
            {
                OldBilldetail obilld = new OldBilldetail();
                obilld.ID = "";
                obilld.VN = txtVn.Text;
                obilld.Name = "OtherService discount ";
                obilld.Extra = "1";
                obilld.item_id = "2640000067";      // form table specialitem
                obilld.status = "special";
                obilld.qty = "1";
                //obilld.GroupType = "OtherService";
                Decimal nettotal = 0, discountper=0, discount=0;
                if (chkDiscountAll.Checked)
                {
                    Decimal.TryParse(txtAmt.Text, out nettotal);
                    if (!chkDiscountCash.Checked)
                    {
                        Decimal.TryParse(txtDiscountAmt.Text, out discountper);
                        discount = (nettotal * discountper / 100);
                        txtDiscount.Value = discount;
                    }
                }
                else if (chkDiscountCash.Checked)
                {
                    Decimal.TryParse(txtAmt.Text, out nettotal);
                    //if (!chkDiscountCash.Checked)
                    //{
                        //Decimal.TryParse(txtDiscountAmt.Text, out discountper);
                        //discount = (nettotal * discountper / 100);
                        //txtDiscount.Value = discount;
                    //}
                }
                else
                {
                    Decimal.TryParse(txtAmt.Text, out nettotal);
                    if (!chkDiscountCash.Checked)
                    {
                        Decimal.TryParse(txtDiscountAmt.Text, out discountper);
                        discount = (nettotal * discountper / 100);
                        txtDiscount.Value = discount;
                    }
                    String grpt = "";
                    Decimal amtg11 = 0;
                    grpt = cboGrpType.Text;
                    foreach (Row row in grfBillD.Rows)
                    {
                        String grp = "";
                        if (row[colGrpName] == null) continue;
                        grp = row[colGrpName].ToString();
                        if (grp.ToLower().Equals(cboGrpType.Text.Trim().ToLower()))
                        {
                            String amtg = "";
                            amtg = row[colNetAmt].ToString();
                            Decimal amtg1 = 0;
                            Decimal.TryParse(amtg,out amtg1);
                            amtg11 += amtg1;
                        }
                    }
                    discount = (amtg11 * discountper / 100);
                    txtDiscount.Value = discount;

                }
                obilld.Price = "-" + txtDiscount.Text.Replace(",", "");
                obilld.Total = "-" + txtDiscount.Text.Replace(",", "");
                obilld.price1 = "-" + txtDiscount.Text.Replace(",", "");
                obilld.Comment = "";
                obilld.bill_group_id = "2650000099";            // form table billgroup
                obilld.GroupType = "Discount";
                obilld.bill_id = txtBillId.Text;
                long chk = 0;
                String re = ic.ivfDB.obildDB.insertBillDetail(obilld, "");
                if (long.TryParse(re, out chk))
                {
                    setDescountDisable();
                    setGrfBillD();
                    calTotal("");
                    calTotalCredit("");
                }
            }
            else
            {
                setDescountEnable();
                foreach (Row row in grfBillD.Rows)
                {
                    try
                    {
                        String name = row[colName].ToString().Trim();
                        String id = row[colId].ToString().Trim();
                        if (name.Equals("OtherService discount"))
                        {
                            String re = ic.ivfDB.obildDB.deletePk(id);
                            //grfBillD.Rows.Remove(row);
                            //break;
                        }
                    }
                    catch(Exception ex)
                    {

                    }
                }
                setGrfBillD();
                calTotal("");
                calTotalCredit("");
            }
        }
        private void setDescountEnable()
        {
            txtDiscount.Value = "";
            pnDiscount.Enabled = true;
            panel3.Enabled = true;
            chkDiscount.Enabled = true;
            txtDiscount.Enabled = true;
        }
        private void setDescountDisable()
        {
            txtDiscount.Value = "";
            pnDiscount.Enabled = false;
            panel3.Enabled = false;
            chkDiscount.Enabled = false;
            txtDiscount.Enabled = false;
        }
        private void BtnChargeAdd_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            OldBilldetail obilld = new OldBilldetail();
            obilld.ID = "";
            obilld.VN = txtVn.Text;
            obilld.Name = "OtherService ";
            obilld.Extra = "1";
            
            obilld.Price = txtPayCreditCard.Text.Replace(",","");
            obilld.Total = txtPayCreditCard.Text.Replace(",", "");
            obilld.Comment = "";
            obilld.pcksid = "0";
            obilld.item_id = "2640000098";            // form table specialitem
            obilld.GroupType = "OtherService";
            obilld.status = "special";
            obilld.bill_group_id = "2650000102";            // form table billgroup
            obilld.bill_id = txtBillId.Text;        //  +0007
            obilld.price1 = txtPayCreditCard.Text.Replace(",", "");
            ic.ivfDB.obildDB.insertBillDetail(obilld, ic.userId);
            setGrfBillD();
            Decimal credit = 0;
            Decimal.TryParse(txtTotalCredit.Text, out credit);
            calTotal("charge");
            calTotalCredit("charge");
            txtPayCreditCard.Value = "";
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //txtVsId.Value = vs.t_visit_id;
            //String re = ic.ivfDB.ovsDB.updateStatusCashierFinish(txtVn.Text);         //      -0020
            String re1 = ic.ivfDB.vsDB.updateCloseStatusCashier(txtVsId.Text);
            frmCashView.setGrfQuePublic();
            frmCashView.setGrfFinishPublic();
            menu.removeTab(tab);
        }

        private void BtnCalBack_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.ivfDB.accountsendtonurse(txtVn.Text, ic.userId);
            //VisitOld ovs = new VisitOld();        // -0020
            //ovs = ic.ivfDB.ovsDB.selectByPk1(txtVnOld.Text);      //      --0020
            Visit vs = new Visit();     //  +0020
            vs = ic.ivfDB.vsDB.selectByVn(txtVn.Text);     //  +0020
            if (vs.vsid.Equals("115"))
            {
                frmCashView.setGrfQuePublic();
                frmCashView.setGrfFinishPublic();
                menu.removeTab(tab);
            }
        }
        private void TxtCreditCharge_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calTotalCash();
        }

        private void BtnPrnBill_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String cashid1 = "", creditid1 = "";
            cashid1 = cboAccCash.SelectedItem == null ? "" : ((ComboBoxItem)cboAccCash.SelectedItem).Value;
            creditid1 = cboAccCredit.SelectedItem == null ? "" : ((ComboBoxItem)cboAccCredit.SelectedItem).Value;
            Decimal totalcredit = 0, totalcash = 0, total = 0, discount = 0;
            if (Decimal.TryParse(txtTotalCredit.Text.Replace(",", ""), out totalcredit))
            {
                if (creditid1.Equals("") && totalcredit > 0)
                {
                    MessageBox.Show("มียอด credit ไม่ยังไม่ได้เลือก ประเภทบัญชี", "");
                    return;
                }
            }
            if (Decimal.TryParse(txtTotalCash.Text.Replace(",", ""), out totalcash))
            {
                if (cashid1.Equals("") && totalcash > 0)
                {
                    MessageBox.Show("มียอด cash ไม่ยังไม่ได้เลือก ประเภทบัญชี", "");
                    return;
                }
            }
            if (Decimal.TryParse(txtDiscount.Text.Replace(",", ""), out discount))
            {
                //if (creditid1.Equals(""))
                //{
                //    MessageBox.Show("มียอด discount ไม่ยังไม่ได้เลือก ประเภทบัญชี", "");
                //    return;
                //}
            }
            total = totalcash + totalcredit;

            PrinterSettings settings = new PrinterSettings();
            printerOld = settings.PrinterName;
            SetDefaultPrinter(ic.iniC.printerBill);
            Application.DoEvents();
            DataTable dt = new DataTable();
            DataTable dtprn = new DataTable();
            DataTable dtpgk = new DataTable();
            Decimal amt = 0, sumprice=0, price1=0, cash=0, credit=0;
            long amt1 = 0;
            String amt2 = "", billNo="", billExtNo="", payby="", date="", year="", month="", day="", billFormat="";
            long.TryParse(amt.ToString(), out amt1);
            dt = ic.ivfDB.printBill(txtVn.Text,ref amt, ref payby,"");

            String billno1 = "", billnoex1="";
            //billno1 = ic.ivfDB.obilhDB.selectBillNoByVN(ovs.VN);                  //      -0020
            //billnoex1 = ic.ivfDB.obilhDB.selectBillNoExByVN(ovs.VN);                  //      -0020
            billno1 = ic.ivfDB.obilhDB.selectBillNoByVN(vs.visit_vn);                    //          +0020
            billnoex1 = ic.ivfDB.obilhDB.selectBillNoExByVN(vs.visit_vn);                    //          +0020
            if (billno1.Length <= 0)
            {
                billNo = ic.ivfDB.copDB.genBillingDoc(ref year, ref month, ref day);
                billExtNo = ic.ivfDB.copDB.genBillingExtDoc();
                ic.ivfDB.obilhDB.updateBillNo(txtVn.Text, billNo);

                //dtpgk = ic.ivfDB.opkgsDB.selectByPID(ovs.PID);    // ต้องดึงตาม HN เพราะ ถ้ามีงวดการชำระ              //      -0020
                dtpgk = ic.ivfDB.opkgsDB.selectByPID(vs.t_patient_id);    // ต้องดึงตาม HN เพราะ ถ้ามีงวดการชำระ                //      +0020
                foreach (DataRow row in dtpgk.Rows)
                {
                    String times = "";
                    Decimal price = 0;
                    //row["PaymentTimes"].GetType()
                    times = row["payment_times"].ToString();
                    if (Decimal.TryParse(row["Payment1"].ToString(), out price) && row["P1BDetailID"].ToString().Equals("0"))
                    {
                        ic.ivfDB.opkgsDB.updateP1BillNo(row["PCKSID"].ToString(), billNo.Replace(ic.cop.prefix_billing_doc, ""));
                        //times = "1";
                    }
                    else if (Decimal.TryParse(row["Payment2"].ToString(), out price) && row["P2BDetailID"].ToString().Equals("0"))
                    {
                        ic.ivfDB.opkgsDB.updateP2BillNo(row["PCKSID"].ToString(), billNo.Replace(ic.cop.prefix_billing_doc, ""));
                    }
                    else if (Decimal.TryParse(row["Payment3"].ToString(), out price) && row["P3BDetailID"].ToString().Equals("0"))
                    {
                        ic.ivfDB.opkgsDB.updateP3BillNo(row["PCKSID"].ToString(), billNo.Replace(ic.cop.prefix_billing_doc, ""));
                    }
                    else if (Decimal.TryParse(row["Payment4"].ToString(), out price) && row["P4BDetailID"].ToString().Equals("0"))
                    {
                        ic.ivfDB.opkgsDB.updateP4BillNo(row["PCKSID"].ToString(), billNo.Replace(ic.cop.prefix_billing_doc, ""));
                    }
                    //ic.ivfDB.updatePackagePaymentComplete(ovs.PID, row["PCKSID"].ToString());         //      -0020
                    ic.ivfDB.updatePackagePaymentComplete(vs.t_patient_id, row["PCKSID"].ToString());           //      +0020
                }
            }
            else
            {
                billNo = billno1;
                billExtNo = billnoex1;
            }
            
            //dtpgk = ic.ivfDB.opkgsDB.selectByVN1(txtVn.Text);
            
            //dtprn.Columns.Add("col1", typeof(String));
            //dtprn.Columns.Add("col2", typeof(String));
            //dtprn.Columns.Add("col3", typeof(String));
            //dtprn.Columns.Add("col4", typeof(String));
            //dtprn.Columns.Add("sort1", typeof(String));
            //dtprn.Columns.Add("fond_bold", typeof(String));
            //dtprn.Columns.Add("grp", typeof(String));
            //dtprn.Columns.Add("grp_name", typeof(String));
            dtprn = dt.Clone();
            if (dtprn.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    //DataRow row = dtprn.NewRow();
                    row["original"] = "1";
                    dtprn.ImportRow(row);
                    row["original"] = "2";
                    Decimal.TryParse(row["col2"].ToString().Replace(",", ""), out price1);
                    sumprice += price1;
                    dtprn.ImportRow(row);
                }
            }
            else
            {
                DataRow row11 = dtprn.NewRow();
                row11["col1"] = "";
                row11["col2"] = "0.00";
                row11["col3"] = "";
                row11["col4"] = "0.00";
                row11["sort1"] = "";
                row11["fond_bold"] = "1";
                row11["grp"] = "3";
                row11["grp_name"] = "";
                row11["original"] = "1";
                dtprn.Rows.Add(row11);
            }
            
            //ic.ivfDB.ovsDB.updateStatusCashierFinish(txtVn.Text);
            //ic.ivfDB.ovsDB.updateStatusCashierFinish(txtVn.Text);
            amt2 = ic.NumberToCurrencyText(amt, MidpointRounding.AwayFromZero);
            Decimal.TryParse(txtTotalCash.Text, out cash);
            Decimal.TryParse(txtTotalCredit.Text, out credit);
            if ((cash>0) && (credit<=0))
            {
                payby = "ชำระเงินโดย เงินสด/Cash ";
            }
            else if ((credit > 0) && (cash <= 0))
            {
                payby = "ชำระเงินโดย เครดิตการ์ด/Credit Card ";
            }
            else if ((credit > 0) && (cash > 0))
            {
                payby = "ชำระเงินโดย เงินสด และเครดิตการ์ด/Cash & Credit Card ";
            }
            else
            {
                payby = "unknow payment";
            }
            if (billNo.Length > 5)
            {
                billFormat = billNo.Substring(billNo.Length - 5);
                billNo = billNo.Substring(0, billNo.Length - 5) + "-" + billFormat;
            }
            //day = DateTime.Now.ToString("dd");
            //month = DateTime.Now.ToString("MM");
            //year = DateTime.Now.ToString("yyyy");
            day = ic.cop.day;
            month = ic.cop.month;
            year = ic.cop.year;
            FrmReport frm = new FrmReport(ic);
            frm.setPrintBill(dtprn, txtHn.Text, txtPttNameE.Text, amt2, amt.ToString("#,###.00"), billNo, day+"/"+month+"/"+year, payby,"ใบแจ้งหนี้/Bill", sumprice.ToString("#,###.00"),"","");
            frm.ShowDialog(this);
            
        }

        private void TxtTotalCredit_KeyPress(object sender, KeyPressEventArgs e)
        {
            //throw new NotImplementedException();
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            //{
            //    e.Handled = true;
            //}

            //// only allow one decimal point
            //if ((e.KeyChar == '.') && ((sender as C1TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
            //if ((e.KeyChar == '-') && ((sender as C1TextBox).Text.Length == 0))
            //{
            //    e.Handled = false;
            //}
        }

        private void TxtTotalCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            //throw new NotImplementedException();
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            //{
            //    e.Handled = true;
            //}

            //// only allow one decimal point
            //if ((e.KeyChar == '.') && ((sender as C1TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
            //if ((e.KeyChar == '-') && ((sender as C1TextBox).Text.Length == 0))
            //{
            //    e.Handled = false;
            //}
        }

        private void TxtTotalCredit_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calTotalCash();
        }

        private void TxtTotalCash_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.Delete)
            {
                //calTotalCash();
                txtTotalCash.Value = "0.00";
                decimal txt = 0;
                decimal.TryParse(txtTotal.Text, out txt);
                txtTotalCredit.Value = txt;
                calTotalCredit("");
            }
            else
            {
                calTotalCredit("");
            }
        }

        private void TxtDiscount_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calTotal("");
        }

        private void TxtAmt_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calTotal("");
        }

        private void TxtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void TxtAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //throw new NotImplementedException();
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as C1TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '-') && ((sender as C1TextBox).Text.Length == 0))
            {
                e.Handled = false;
            }
        }
        private void ChkDiscountPer_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            txtDiscountAmt.Enabled = chkDiscountPer.Checked ? true : false;
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ChkDiscount_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setChkDiscount(chkDiscount.Checked);
        }

        private void setControl()
        {
            txtBillId.Value = billid;
            //ovs = ic.ivfDB.ovsDB.selectByPk1(vnold);      //      -0020
            vs = ic.ivfDB.vsDB.selectByVn(vn);      //      +0020
            //optt = ic.ivfDB.pttOldDB.selectByPk1(ovs.PID);      //      -0020
            //ptt = ic.ivfDB.pttDB.selectByHn(ovs.PIDS);      //      -0020
            ptt = ic.ivfDB.pttDB.selectByPk1(vs.t_patient_id);      //      +0020
            //vs = ic.ivfDB.vsDB.selectByVn(ovs.VN);
            if (receiptno.Length > 0)
            {
                obilh = ic.ivfDB.obilhDB.selectByPk1(txtBillId.Text);
            }
            else
            {
                //obilh = ic.ivfDB.obilhDB.selectByPk2(ovs.VN);      //      -0020
                obilh = ic.ivfDB.obilhDB.selectByPk2(vs.visit_vn);      //      +0020
            }
            //ptt.patient_birthday = optt.DateOfBirth;      //      -0020

            txtHn.Value = ic.showHN(ptt.patient_hn, ptt.patient_year);
            //txtPttNameE.Value = vs.patient_name;
            txtPttNameE.Value = ptt.patient_name;
            txtDob.Value = ic.datetoShow(ptt.patient_birthday) + " [" + ptt.AgeStringShort() + "]";
            //txtHnOld.Value = optt.PIDS;      //      -0020
            //txtVnOld.Value = vsidOld;      //      -0020
            txtHnOld.Value = ptt.t_patient_id;      //      +0020
            txtVnOld.Value = vs.t_visit_id;      //      +0020
            //txtPttId.Value = optt.PID;      //      -0020
            txtPttId.Value = ptt.t_patient_id;      //      +0020
            txtVsId.Value = vs.t_visit_id;
            //txtVnOld.Value = ovs.VN;      //      -0020
            //txtHnOld.Value = ovs.PIDS;      //      -0020
            //txtVn.Value = ovs.VN;      //      -0020

            txtVnOld.Value = vs.visit_vn;      //      +0020
            txtHnOld.Value = vs.visit_hn;      //      +0020
            txtVn.Value = vs.visit_vn;      //      +0020
            txtReceiptNo.Value = receiptno;
            //txtPttName.Value = ic.ivfDB.fpfDB.getList(ptt.f_patient_prefix_id) + " " + ptt.patient_firstname + " " + ptt.patient_lastname;
            if (ptt.patient_firstname.Length>0)
            {
                txtPttName.Value = ic.ivfDB.fpfDB.getList1(ptt.f_patient_prefix_id) + " " + ptt.patient_firstname + " " + ptt.patient_lastname;
            }
            txtVnShow.Value = ic.showVN(vs.visit_vn);
            txtAllergy.Value = ptt.allergy_description;
            txtSex.Value = ptt.f_sex_id.Equals("1") ? "ชาย" : "หญิง";
            txtBg.Value = ptt.f_patient_blood_group_id.Equals("2140000005") ? "O"
                : ptt.f_patient_blood_group_id.Equals("2140000002") ? "A" : ptt.f_patient_blood_group_id.Equals("2140000003") ? "B"
                : ptt.f_patient_blood_group_id.Equals("2140000004") ? "AB" : "ไม่ระบุ";
            txtAgent.Value = ic.ivfDB.oAgnDB.getAgentNameById(ptt.agent);
            if (flagedit.Equals("noedit"))
            {
                txtTotalCash.Value = obilh.cash;
                txtTotal.Value = obilh.Total;
                txtDiscount.Value = obilh.Discount;
                //txtAmt.Value = obilh.total1;
                //cboAccCash.Text = "";
                txtTotalCredit.Value = obilh.credit;
                txtPayCreditCard.Value = "";
                txtCreditCardNumber.Value = obilh.CreditCardNumber;
                txtTotalTransfer.Value = obilh.cash_transfer;
                txtCreditCharge.Value = obilh.charge;
                //cboAccCredit.Text = "";
                ic.setC1Combo(cboAccCash, obilh.CashID);
                ic.setC1Combo(cboAccCredit, obilh.CreditCardID);
                ic.setC1Combo(cboCreditBank, obilh.credit_bank_id);
                ic.setC1Combo(cboAccCashTransfer, obilh.cash_transfer_id);
            }

            FrmLabPrescription frm = new FrmLabPrescription(ic, "", "", ptt.patient_hn);
            //frm.WindowState = FormWindowState.Maximized;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            frm.Show();
            tabLabPrescription.Controls.Add(frm);

            setGrfBillD();
            calTotal("");
            calTotalCredit("");
        }
        private void initGrfPkgPayPeriod()
        {
            grfPkgPayPeriod = new C1FlexGrid();
            grfPkgPayPeriod.Font = fEdit;
            grfPkgPayPeriod.Dock = System.Windows.Forms.DockStyle.Fill;
            grfPkgPayPeriod.Location = new System.Drawing.Point(0, 0);
            grfPkgPayPeriod.Rows.Count = 1;
            grfPkgPayPeriod.Cols.Count=6;
            grfPkgPayPeriod.Cols[1].Caption = "งวด 1";
            grfPkgPayPeriod.Cols[2].Caption = "งวด 2";
            grfPkgPayPeriod.Cols[3].Caption = "งวด 3";
            grfPkgPayPeriod.Cols[4].Caption = "งวด 4";
            grfPkgPayPeriod.Cols[5].Caption = "รวม";
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("บันทึกข้อมูล", new EventHandler(ContextMenu_pkgpayperiod_save));
            menuGw.MenuItems.Add("Clear ข้อมูล ใหม่", new EventHandler(ContextMenu_pkgpayperiod_clearnew));
            grfPkgPayPeriod.ContextMenu = menuGw;
            grfPkgPayPeriod.AfterEdit += GrfPkgPayPeriod_AfterEdit;
            grfPkgPayPeriod.KeyUp += GrfPkgPayPeriod_KeyUp;

            grfPkgPayPeriod.SubtotalPosition = SubtotalPositionEnum.BelowData;
            panel4.Controls.Add(grfPkgPayPeriod);

            theme1.SetTheme(grfPkgPayPeriod, "RainerOrange");

        }

        private void GrfPkgPayPeriod_AfterEdit(object sender, RowColEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.Col == 1 || e.Col == 2 || e.Col == 3 || e.Col == 4)
            {
                if (grfPkgPayPeriod == null) return;
                if (grfPkgPayPeriod.Row < 1) return;
                if (grfPkgPayPeriod.Col < 0) return;
                if (grfPkgPayPeriod[grfPkgPayPeriod.Row, 1] == null) return;
                if (grfPkgPayPeriod[grfPkgPayPeriod.Row, 2] == null) return;
                if (grfPkgPayPeriod[grfPkgPayPeriod.Row, 3] == null) return;
                if (grfPkgPayPeriod[grfPkgPayPeriod.Row, 4] == null) return;

                Decimal amt = 0, period1 = 0, period2 = 0, period3 = 0, period4 = 0, pkgamt = 0;
                Decimal.TryParse(grfPkgPayPeriod[grfPkgPayPeriod.Row, 1].ToString(), out period1);
                Decimal.TryParse(grfPkgPayPeriod[grfPkgPayPeriod.Row, 2].ToString(), out period2);
                Decimal.TryParse(grfPkgPayPeriod[grfPkgPayPeriod.Row, 3].ToString(), out period3);
                Decimal.TryParse(grfPkgPayPeriod[grfPkgPayPeriod.Row, 4].ToString(), out period4);
                Decimal.TryParse(grfPkgPayPeriod[grfPkgPayPeriod.Row, 8].ToString(), out pkgamt);
                if (grfPkgPayPeriod.Col == 1)
                {
                    period2 = pkgamt - period1;
                    grfPkgPayPeriod[grfPkgPayPeriod.Row, 2] = period2.ToString();
                    grfPkgPayPeriod[grfPkgPayPeriod.Row, 3] = "0";
                    grfPkgPayPeriod[grfPkgPayPeriod.Row, 4] = "0";
                }
                else if (grfPkgPayPeriod.Col == 2)
                {
                    period3 = pkgamt - period1 - period2;
                    grfPkgPayPeriod[grfPkgPayPeriod.Row, 3] = period3.ToString();
                    grfPkgPayPeriod[grfPkgPayPeriod.Row, 4] = "0";
                }
                else if (grfPkgPayPeriod.Col == 3)
                {
                    period4 = pkgamt - period1 - period2 - period3;
                    grfPkgPayPeriod[grfPkgPayPeriod.Row, 4] = period4.ToString();
                }
                amt = period1 + period2 + period3 + period4;
                grfPkgPayPeriod[grfPkgPayPeriod.Row, 5] = amt;
            }
        }

        private void GrfPkgPayPeriod_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            
        }
        private void ContextMenu_pkgpayperiod_clearnew(object sender, System.EventArgs e)
        {
            if (grfPkgPayPeriod == null) return;
            if (grfPkgPayPeriod.Row <= 0) return;
            if (grfPkgPayPeriod.Col <= 0) return;
            String pkgsid = "", payment;

            pkgsid = grfPkgPayPeriod[grfPkgPayPeriod.Row, 7].ToString();
            payment = grfPkgPayPeriod[grfPkgPayPeriod.Row, 8].ToString();
            OldPackageSold opkgs = new OldPackageSold();
            opkgs = ic.ivfDB.opkgsDB.selectByPk1(pkgsid);
            String re1 = ic.ivfDB.opkgsDB.updateClearNew(pkgsid, payment);

            String re = ic.ivfDB.obildDB.updatePaymentPeriod(txtVn.Text, pkgsid, payment, opkgs.payment_name);
            setGrfPkgPayPeriod();
            //setGrfBillD();
            setControl();
        }
        private void ContextMenu_pkgpayperiod_save(object sender, System.EventArgs e)
        {
            if (grfPkgPayPeriod == null) return;
            if (grfPkgPayPeriod.Row <= 0) return;
            if (grfPkgPayPeriod.Col <= 0) return;

            String pkgsid = "";
            Decimal amt = 0, period1=0, period2=0, period3=0, period4=0, payment1=0,payment2=0,payment3=0, payment4=0, pkgsamt=0;
            Boolean chkPayment = false;

            pkgsid = grfPkgPayPeriod[grfPkgPayPeriod.Row, 7].ToString();
            Decimal.TryParse(txtAmt.Text.Trim(), out amt);
            Decimal.TryParse(grfPkgPayPeriod[grfPkgPayPeriod.Row, 1].ToString(), out period1);
            Decimal.TryParse(grfPkgPayPeriod[grfPkgPayPeriod.Row, 2].ToString(), out period2);
            Decimal.TryParse(grfPkgPayPeriod[grfPkgPayPeriod.Row, 3].ToString(), out period3);
            Decimal.TryParse(grfPkgPayPeriod[grfPkgPayPeriod.Row, 4].ToString(), out period4);

            OldPackageSold pkgs = new OldPackageSold();
            pkgs = ic.ivfDB.opkgsDB.selectByPk1(pkgsid);
            Decimal.TryParse(pkgs.Price, out pkgsamt);
            //if (pkgs.P1BDetailID.Length > 0) chkPayment = true;
            //if (pkgs.P2BDetailID.Length > 0) chkPayment = true;
            //if (pkgs.P3BDetailID.Length > 0) chkPayment = true;
            //if (pkgs.P4BDetailID.Length > 0) chkPayment = true;
            if (Decimal.TryParse(pkgs.P1BDetailID, out payment1) && payment1 > 0) chkPayment = true;
            if (Decimal.TryParse(pkgs.P2BDetailID, out payment2) && payment2 > 0) chkPayment = true;
            if (Decimal.TryParse(pkgs.P3BDetailID, out payment3) && payment3 > 0) chkPayment = true;
            if (Decimal.TryParse(pkgs.P4BDetailID, out payment4) && payment4 > 0) chkPayment = true;

            if (chkPayment)
            {
                MessageBox.Show("มีการรับชำระไปแล้ว ", "");
                return;
            }
            if ((period1 + period2+ period3+ period4) < pkgsamt)
            {
                MessageBox.Show("ยอดรับชำระ น้อยกว่า ยอด BILL ", "");
                return;
            }
            String re1 = "", re2 = "", re3 = "", re4 = "", name = "", pkgname = "", time="", re5="";
            pkgname = grfPkgPayPeriod[grfPkgPayPeriod.Row, 9].ToString();
            name = period4 > 0 ? pkgname + " 1/4" : period3 > 0 ? pkgname + " 1/3" : period2 > 0 ? pkgname + " 1/2" : pkgname;
            time = period4 > 0 ? "4" : period3 > 0 ? "3" : period2 > 0 ? "2" : "1";
            re1 = ic.ivfDB.opkgsDB.updatePayment1(pkgsid, period1.ToString());
            re2 = ic.ivfDB.opkgsDB.updatePayment2(pkgsid, period2.ToString());
            re3 = ic.ivfDB.opkgsDB.updatePayment3(pkgsid, period3.ToString());
            re4 = ic.ivfDB.opkgsDB.updatePayment4(pkgsid, period4.ToString());
            re5 = ic.ivfDB.opkgsDB.updatePaymentTime(pkgsid, time);
            String re = ic.ivfDB.obildDB.updatePaymentPeriod(txtVn.Text, pkgsid, period1.ToString(), name);
            long chk = 0;
            if(long.TryParse(re, out chk))
            {
                setGrfBillD();
                calTotal("");
                calTotalCredit("");
            }
        }
        private void setGrfPkgPayPeriod()
        {
            DataTable dt = new DataTable();
            grfPkgPayPeriod.Rows.Count = 1;
            grfPkgPayPeriod.Cols.Count = 10;
            grfPkgPayPeriod.Cols[1].Width = 100;
            grfPkgPayPeriod.Cols[2].Width = 100;
            grfPkgPayPeriod.Cols[3].Width = 100;
            grfPkgPayPeriod.Cols[4].Width = 100;
            grfPkgPayPeriod.Cols[5].Width = 100;
            grfPkgPayPeriod.Cols[6].Width = 100;
            grfPkgPayPeriod.Cols[9].Width = 200;
            grfPkgPayPeriod.Cols[1].Caption = "งวด 1";
            grfPkgPayPeriod.Cols[2].Caption = "งวด 2";
            grfPkgPayPeriod.Cols[3].Caption = "งวด 3";
            grfPkgPayPeriod.Cols[4].Caption = "งวด 4";
            grfPkgPayPeriod.Cols[5].Caption = "รวม";
            //dt = ic.ivfDB.opkgsDB.selectByPID1(ptt.t_patient_id_old);         //      -0020
            dt = ic.ivfDB.opkgsDB.selectByPID1(ptt.t_patient_id);           //      +0020
            foreach (DataRow row in dt.Rows)
            {
                Row row1 = grfPkgPayPeriod.Rows.Add();
                Decimal pay1 = 0, pay2= 0, pay3= 0, pay4= 0;
                Decimal.TryParse(row["Payment1"].ToString(), out pay1);
                row1[1] = pay1.ToString("#,###.00");
                Decimal.TryParse(row["Payment2"].ToString(), out pay2);
                row1[2] = pay2.ToString("#,###.00");
                Decimal.TryParse(row["Payment3"].ToString(), out pay3);
                row1[3] = pay3.ToString("#,###.00");
                Decimal.TryParse(row["Payment4"].ToString(), out pay4);
                row1[4] = pay4.ToString("#,###.00");

                row1[5] = (pay1 + pay2 + pay3 + pay4);
                row1[6] = row["Status"].ToString();
                row1[7] = row["PCKSID"].ToString();
                row1[8] = row["Price"].ToString();
                row1[9] = row["PackageName"].ToString();
                int period1 = 0, period2 = 0, period3 = 0, period4 = 0;
                if(int.TryParse(row["P1BDetailID"].ToString(), out period1))
                {
                    CellNote note = new CellNote(period1.ToString());
                    CellRange rg = grfPkgPayPeriod.GetCellRange(grfPkgPayPeriod.Rows.Count-1, 1);
                    rg.UserData = "เลขที่ใบเสร็จ "+note;
                }
                if (int.TryParse(row["P2BDetailID"].ToString(), out period2))
                {
                    CellNote note = new CellNote(period2.ToString());
                    CellRange rg = grfPkgPayPeriod.GetCellRange(grfPkgPayPeriod.Rows.Count-1, 1);
                    rg.UserData = "เลขที่ใบเสร็จ " + note;
                }
                if (int.TryParse(row["P3BDetailID"].ToString(), out period3))
                {
                    CellNote note = new CellNote(period3.ToString());
                    CellRange rg = grfPkgPayPeriod.GetCellRange(grfPkgPayPeriod.Rows.Count-1, 1);
                    rg.UserData = "เลขที่ใบเสร็จ " + note;
                }
                if (int.TryParse(row["P4BDetailID"].ToString(), out period4))
                {
                    CellNote note = new CellNote(period4.ToString());
                    CellRange rg = grfPkgPayPeriod.GetCellRange(grfPkgPayPeriod.Rows.Count-1, 1);
                    rg.UserData = "เลขที่ใบเสร็จ " + note;
                }
            }
            CellNoteManager mgr = new CellNoteManager(grfPkgPayPeriod);
            grfPkgPayPeriod.Cols[1].AllowSorting = false;
            grfPkgPayPeriod.Cols[2].AllowSorting = false;
            grfPkgPayPeriod.Cols[3].AllowSorting = false;
            grfPkgPayPeriod.Cols[4].AllowSorting = false;
            grfPkgPayPeriod.Cols[5].AllowSorting = false;
            grfPkgPayPeriod.Cols[6].Visible = false;
            grfPkgPayPeriod.Cols[7].Visible = false;
            //grfPkgPayPeriod.Cols[8].Visible = false;
        }
        private void initGrfReceipt()
        {
            grfReceipt = new C1FlexGrid();
            grfReceipt.Font = fEdit;
            grfReceipt.Dock = System.Windows.Forms.DockStyle.Fill;
            grfReceipt.Location = new System.Drawing.Point(0, 0);

            grfReceipt.SubtotalPosition = SubtotalPositionEnum.BelowData;
            tabReceipt.Controls.Add(grfReceipt);

            theme1.SetTheme(grfReceipt, "Windows8Blue");

        }
        private void setGrfReceipt()
        {
            DataTable dt = new DataTable();
            DataTable dtprn = new DataTable();
            DataTable dtpgk = new DataTable();
            Decimal amt = 0;
            String payby = "";
            grfReceipt.Rows.Count = 1;
            grfReceipt.Cols.Count = 6;
            grfReceipt.Cols[1].Width = 300;
            grfReceipt.Cols[2].Width = 100;
            if (receiptno.Length > 0)
            {
                dt = ic.ivfDB.printBill(txtVn.Text, ref amt, ref payby,receiptno);
            }
            else
            {
                dt = ic.ivfDB.printBill(txtVn.Text, ref amt, ref payby,"");
            }
            
            foreach (DataRow row in dt.Rows)
            {
                Row row1 = grfReceipt.Rows.Add();
                row1[1] = row["col1"].ToString();
                row1[2] = row["col2"].ToString();
            }
        }
        private void initGrfOrder()
        {
            grfOrder = new C1FlexGrid();
            grfOrder.Font = fEdit;
            grfOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            grfOrder.Location = new System.Drawing.Point(0, 0);
            
            grfOrder.SubtotalPosition = SubtotalPositionEnum.BelowData;
            pnOrder.Controls.Add(grfOrder);

            theme1.SetTheme(grfOrder, "VS2013Tan");

        }
        private void setGrfOrder(String vn)
        {
            //grfDept.Rows.Count = 7;
            grfOrder.Clear();
            DataTable dtAll = new DataTable();
            DataTable dtbl = new DataTable();
            DataTable dtse = new DataTable();
            DataTable dtpx = new DataTable();
            DataTable dtpkg = new DataTable();

            dtbl = ic.ivfDB.oJlabdDB.selectByVN(vn);
            dtse = ic.ivfDB.ojsdDB.selectByVN(vn);
            dtpx = ic.ivfDB.oJpxdDB.selectByVN(vn);
            //dtpkg = ic.ivfDB.opkgsDB.selectByVN(vn);
            dtpkg = ic.ivfDB.opkgsDB.selectByPID(ptt.t_patient_id_old);    // ต้องดึงตาม HN เพราะ ถ้ามีงวดการชำระ 

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            //grfEmbryo.Rows.Count = dt.Rows.Count + 1;

            dtAll.Columns.Add("id", typeof(String));
            dtAll.Columns.Add("lgid", typeof(String));
            dtAll.Columns.Add("name", typeof(String));
            dtAll.Columns.Add("price", typeof(String));
            dtAll.Columns.Add("qty", typeof(String));
            dtAll.Columns.Add("status", typeof(String));
            dtAll.Columns.Add("row1", typeof(int));
            dtAll.Columns.Add("itmid", typeof(String));
            dtAll.Columns.Add("extra", typeof(String));
            dtAll.Columns.Add("usage", typeof(String));
            dtAll.Columns.Add("lab_order_id", typeof(String));
            dtAll.Columns.Add("status_amt", typeof(String));
            dtAll.Columns.Add("status_order_group", typeof(String));
            dtAll.Columns.Add("price1", typeof(String));
            dtAll.Columns.Add("pckdid", typeof(String));
            int i = 0;
            foreach (DataRow row in dtbl.Rows)
            {
                DataRow row1 = dtAll.NewRow();
                row1["id"] = row["ID"];
                row1["itmid"] = row["LID"];
                row1["lgid"] = row["LGID"];
                row1["name"] = row["LName"];
                row1["price"] = row["Price"];
                row1["qty"] = row["QTY"];
                row1["row1"] = row["row1"];
                row1["extra"] = row["Extra"];
                row1["usage"] = "";
                row1["lab_order_id"] = row["lab_order_id"];
                row1["status_amt"] = row["status_amt"];
                row1["status_order_group"] = row["status_order_group"];
                row1["price1"] = row["price1"];
                row1["pckdid"] = row["pckdid"];
                if (row["LGID"].ToString().Equals("1"))
                {
                    row1["status"] = "bloodlab";
                }
                else if (row["LGID"].ToString().Equals("2"))
                {
                    row1["status"] = "";
                }
                else if (row["LGID"].ToString().Equals("3"))
                {
                    row1["status"] = "Sperm Lab";
                }
                else if (row["LGID"].ToString().Equals("4"))
                {
                    row1["status"] = "Embryo Lab";
                }
                else if (row["LGID"].ToString().Equals("5"))
                {
                    row1["status"] = "Genetic Lab";
                }
                dtAll.Rows.InsertAt(row1, i);
                i++;
            }
            foreach (DataRow row in dtse.Rows)
            {
                DataRow row1 = dtAll.NewRow();
                row1["id"] = row["ID"];
                row1["itmid"] = row["SID"];
                row1["lgid"] = "";
                row1["name"] = row["SName"];
                row1["price"] = row["Price"];
                row1["qty"] = row["qty"];
                row1["status"] = "specialitem";
                row1["row1"] = row["row1"];
                row1["extra"] = row["Extra"];
                row1["usage"] = "";
                row1["lab_order_id"] = "0";
                row1["status_amt"] = "1";
                row1["status_order_group"] = "0";
                row1["price1"] = row["price1"];
                row1["pckdid"] = row["pckdid"];
                dtAll.Rows.InsertAt(row1, i);
                i++;
            }
            foreach (DataRow row in dtpx.Rows)
            {
                DataRow row1 = dtAll.NewRow();
                row1["id"] = row["ID"];
                row1["itmid"] = row["DUID"];
                row1["lgid"] = "";
                row1["name"] = row["DUName"];
                row1["price"] = row["Price"];
                row1["qty"] = row["QTY"];
                row1["status"] = "px";
                row1["row1"] = row["row1"];
                row1["extra"] = row["Extra"];
                row1["usage"] = row["TUsage"];
                row1["lab_order_id"] = "0";
                row1["status_amt"] = "1";
                row1["status_order_group"] = "0";
                row1["price1"] = row["price1"];
                row1["pckdid"] = row["pckdid"];
                dtAll.Rows.InsertAt(row1, i);
                i++;

            }

            foreach (DataRow row in dtpkg.Rows)
            {
                String bill1 = "", bill2 = "", bill3 = "", bill4 = "", times = "", name = "";
                Decimal price = 0, pay1 = 0, pay2 = 0, pay3 = 0, pay4 = 0, pay = 0;
                Decimal.TryParse(row["price"].ToString(), out price);
                Decimal.TryParse(row["payment1"].ToString(), out pay1);
                Decimal.TryParse(row["payment2"].ToString(), out pay2);
                Decimal.TryParse(row["payment3"].ToString(), out pay3);
                Decimal.TryParse(row["payment4"].ToString(), out pay4);
                times = row["payment_times"].ToString();
                bill1 = row["P1BDetailID"].ToString();
                bill2 = row["P2BDetailID"].ToString();
                bill3 = row["P3BDetailID"].ToString();
                bill4 = row["P4BDetailID"].ToString();
                name = row["PackageName"].ToString();
                if (price > 0)
                {
                    if ((pay1 > 0) && bill1.Equals("0"))
                    {
                        pay = pay1;
                        name += "1/" + times;
                    }
                    else if ((pay2 > 0) && bill2.Equals("0"))
                    {
                        pay = pay2;
                        name += "2/" + times;
                    }
                    else if ((pay3 > 0) && bill3.Equals("0"))
                    {
                        pay = pay3;
                        name += "3/" + times;
                    }
                    else if ((pay4 > 0) && bill4.Equals("0"))
                    {
                        pay = pay4;
                        name += "4/" + times;
                    }
                    DataRow row1 = dtAll.NewRow();
                    row1["id"] = row["PCKSID"];
                    row1["itmid"] = row["PCKID"];
                    row1["lgid"] = "";
                    row1["name"] = name;
                    row1["price"] = pay;
                    row1["qty"] = "1";
                    row1["status"] = "package";
                    row1["row1"] = row["row1"];
                    row1["extra"] = "0";
                    row1["usage"] = "";
                    row1["lab_order_id"] = "0";
                    row1["status_amt"] = "1";
                    row1["status_order_group"] = "0";
                    row1["price1"] = pay;
                    row1["pckdid"] = "";
                    dtAll.Rows.InsertAt(row1, i);
                    i++;
                }
                //setTabPkg(row["PCKSID"].ToString(), row["PackageName"].ToString());
            }
            dtAll.DefaultView.Sort = "row1";
            DataView view = dtAll.DefaultView;
            view.Sort = "row1 ASC";
            DataTable sortedDate = view.ToTable();
            //grfOrder.DataSource = dtAll;
            grfOrder.Cols.Count = 18;
            //C1TextBox txt = new C1TextBox();
            //C1CheckBox chk = new C1CheckBox();
            //chk.Text = "Include Package";
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            //grfOrder.Cols[1].Editor = txt;
            //grfOrder.Cols[colOrderPrice].Editor = txt;
            //grfOrder.Cols[colOrderQTY].Editor = txt;
            //grfOrder.Cols[colRxId].Editor = txt;

            grfOrder.Cols[colOrdName].Width = 280;
            grfOrder.Cols[colOrdPrice].Width = 100;
            grfOrder.Cols[colOrdQty].Width = 80;
            grfOrder.Cols[colOrdUsT].Width = 100;

            grfOrder.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfOrder.Cols[colOrdName].Caption = "Name";
            if (ic.iniC.statusCashierOldProgram.Equals("1"))
            {
                grfOrder.Cols[colOrdPrice].Caption = "SumPrice";
                grfOrder.Cols[colOrdPrice1].Caption = "Price1";
            }
            else
            {
                grfOrder.Cols[colOrdPrice].Caption = "Price";
                grfOrder.Cols[colOrdPrice1].Caption = "Price1";
            }
            //grfOrder.Cols[colOrdPrice1].Caption = "Price";
            grfOrder.Cols[colOrdQty].Caption = "QTY";
            grfOrder.Cols[colOrdInclude].Caption = "Include Package";
            grfOrder.Cols[colOrdUsT].Caption = "Usage";
            grfOrder.Cols[colOrdAmt].Caption = "Amount";
            //grfOrder.SubtotalPosition = SubtotalPositionEnum.BelowData;
            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            i = 1;
            grfOrder.Rows.Count = 1;
            Decimal inc = 0, ext = 0;
            foreach (DataRow row in sortedDate.Rows)
            {
                try
                {
                    Decimal price = 0, qty = 0, price1 = 0;
                    Row row1 = grfOrder.Rows.Add();
                    row1[colOrdid] = row["id"].ToString();
                    row1[colOrdlpid] = row["lgid"].ToString();
                    row1[colOrdName] = row["name"].ToString();
                    row1[colOrdUsT] = row["usage"].ToString();
                    //row1[colOrdQty] = row["qty"].ToString();
                    row1[colOrdstatus] = row["status"].ToString();
                    row1[colOrdrow1] = row["row1"].ToString();
                    row1[colOrditmid] = row["itmid"].ToString();
                    row1[colOrdInclude] = row["extra"].ToString().Equals("1") ? "Extra" : "Include";

                    Decimal.TryParse(row["price"].ToString(), out price);
                    Decimal.TryParse(row["price1"].ToString(), out price1);
                    Decimal.TryParse(row["qty"].ToString(), out qty);
                    row1[colOrdPrice] = price.ToString("#,###.00");
                    row1[colOrdPrice1] = price1.ToString("#,###.00");
                    row1[colOrdQty] = qty.ToString("#,###.00");
                    row1[colOrdAmt] = (price * qty).ToString("#,###.00");
                    if (row["status_amt"].ToString().Equals("1"))
                    {
                        if (row["extra"].ToString().Equals("1"))
                        {
                            if (ic.iniC.statusCashierOldProgram.Equals("1"))
                            {
                                ext += price;
                            }
                            else
                            {
                                ext += (price1 * qty);
                            }
                        }
                        else
                        {
                            if (row["status"].ToString().Equals("package"))
                            {
                                if (ic.iniC.statusCashierOldProgram.Equals("1"))
                                {
                                    inc += price;
                                }
                                else
                                {
                                    inc += (price1 * qty);
                                }
                            }
                        }
                    }

                    if (ic.iniC.statusCashierOldProgram.Equals("1"))
                    {
                        row1[colOrdAmt] = price.ToString("#,###.00");
                    }
                    else
                    {
                        row1[colOrdAmt] = (price1 * qty).ToString("#,###.00");
                    }
                    row1[colOrdOrderId] = row["lab_order_id"].ToString();
                    row1[colOrdStatusAmt] = row["status_amt"].ToString();
                    row1[colOrdStatusOrdGrp] = row["status_order_group"].ToString();
                    row1[0] = i;
                    if (row["status"].ToString().Equals("package"))
                        row1.StyleNew.BackColor = Color.FromArgb(143, 200, 127);
                    else if (row["status"].ToString().Equals("specialitem"))
                        row1.StyleNew.BackColor = Color.FromArgb(244, 222, 242);
                    else if (row["status"].ToString().Equals("bloodlab"))
                        row1.StyleNew.BackColor = Color.FromArgb(253, 233, 233);
                    else if (row["status"].ToString().Equals("Sperm Lab"))
                        row1.StyleNew.BackColor = Color.FromArgb(244, 252, 232);
                    else if (row["status"].ToString().Equals("Embryo Lab"))
                        row1.StyleNew.BackColor = Color.FromArgb(218, 237, 255);
                    else if (row["status"].ToString().Equals("Genetic Lab"))
                        row1.StyleNew.BackColor = Color.FromArgb(255, 255, 231);
                    else if (row["status"].ToString().Equals("px"))
                        row1.StyleNew.BackColor = Color.FromArgb(224, 224, 224);
                    if (row["pckdid"].ToString().Length > 1)
                    {
                        CellNote note = new CellNote("Package " + row["pckdid"].ToString());
                        CellRange rg = grfOrder.GetCellRange(i, colOrdName);
                        rg.UserData = note;
                    }
                    i++;
                }
                catch (Exception ex)
                {
                    String err = "";
                }
            }
            //rowOrder = grfOrder.Rows.Count;
            CellNoteManager mgr = new CellNoteManager(grfOrder);
            grfOrder.Cols[colOrdrow1].Visible = false;
            grfOrder.Cols[colOrdlpid].Visible = false;
            grfOrder.Cols[colOrdid].Visible = false;
            //grfOrder.Cols[colOrdstatus].Visible = false;
            grfOrder.Cols[colOrditmid].Visible = false;
            if (ic.iniC.statusCashierOldProgram.Equals("1"))
            {
                grfOrder.Cols[colOrdPrice].Visible = false;
                grfOrder.Cols[colOrdPrice1].Visible = true;
            }
            else
            {
                grfOrder.Cols[colOrdPrice].Visible = true;
                grfOrder.Cols[colOrdPrice1].Visible = false;
            }
            grfOrder.Cols[colOrdUsE].Visible = false;
            grfOrder.Cols[colOrdDate].Visible = false;

            grfOrder.Cols[colOrdUsT].AllowEditing = false;
            grfOrder.Cols[colOrdName].AllowEditing = false;
            grfOrder.Cols[colOrdPrice].AllowEditing = false;
            grfOrder.Cols[colOrdQty].AllowEditing = false;
            grfOrder.Cols[colOrdOrderId].AllowEditing = false;
            grfOrder.Cols[colOrdStatusAmt].AllowEditing = false;
            grfOrder.Cols[colOrdStatusOrdGrp].AllowEditing = false;

        }
        private void initGrfBillD()
        {
            grfBillD = new C1FlexGrid();
            grfBillD.Font = fEdit;
            grfBillD.Dock = System.Windows.Forms.DockStyle.Fill;
            grfBillD.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            //grfQue.AfterRowColChange += GrfReq_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            grfBillD.AfterDataRefresh += GrfBillD_AfterDataRefresh;
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("ออก บิล", new EventHandler(ContextMenu_void_bill));
            menuGw.MenuItems.Add("ส่งกลับ", new EventHandler(ContextMenu_send_back));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfBillD.ContextMenu = menuGw;
            grfBillD.SubtotalPosition = SubtotalPositionEnum.BelowData;
            pnBill.Controls.Add(grfBillD);

            theme1.SetTheme(grfBillD, "Office2010Red");

            //theme1.SetTheme(tabDiag, "Office2010Blue");
            //theme1.SetTheme(tabFinish, "Office2010Blue");

        }

        private void GrfBillD_AfterDataRefresh(object sender, ListChangedEventArgs e)
        {
            //throw new NotImplementedException();
            UpdateTotals();
        }
        private void ContextMenu_void_bill(object sender, System.EventArgs e)
        {
            if (grfBillD.Row <= 0) return;
            String bildid = "";
            //if (grfBillD[grfBillD.Row, colId] == null) return;
            bildid = grfBillD[grfBillD.Row, colId] != null ? grfBillD[grfBillD.Row, colId].ToString() : "";
            ic.cStf.staff_id = "";
            FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            frm.ShowDialog(this);
            if (!ic.cStf.staff_id.Equals(""))
            {
                OldBilldetail bild = new OldBilldetail();
                bild = ic.ivfDB.obildDB.selectByPk1(bildid);
                ic.ivfDB.obildDB.voidBillDetailBybildid(bildid, ic.cStf.staff_id);
                if (bild.item_id.Equals("2640000191"))        // check deposit
                {
                    DepositWithDraw dwithdraw = new DepositWithDraw();
                    dwithdraw = ic.ivfDB.dwitdrawDB.selectByPk(bild.Comment.Trim());
                    if (dwithdraw.withdraw_id.Length > 0)
                    {
                        String re = ic.ivfDB.dwitdrawDB.voidDepositWithDraw(dwithdraw.withdraw_id, ic.userId);
                        //String re1 = ic.ivfDB.depositDB.updateAmountVoidWithDraw(dwithdraw.deposit_id, dwithdraw.withdraw_amount);
                    }
                }
                setGrfBillD();
                if (bild.item_id.Equals("2640000098"))      //OtherService service charge
                {
                    txtPayCreditCard.Value = "";
                    decimal amt = 0;
                    decimal.TryParse(txtAmt.Text, out amt);
                    txtTotal.Value = amt;
                    txtTotalCredit.Value = 0;
                }
                if (bild.item_id.Equals("2640000067"))      //OtherService Discount
                {
                    setDescountEnable();
                }
            }
        }
        private void setBillIdDeposit()
        {
            try
            {
                foreach (Row row in grfBillD.Rows)
                {
                    String bildid = "";
                    bildid = row[colId] != null ? row[colId].ToString() : "";
                    if (bildid.Length <= 0) continue;
                    OldBilldetail bild = new OldBilldetail();
                    bild = ic.ivfDB.obildDB.selectByPk1(bildid);
                    //ic.ivfDB.obildDB.voidBillDetailBybildid(bildid, ic.cStf.staff_id);
                    if (bild.item_id.Equals("2640000191"))        // check deposit
                    {
                        DepositWithDraw dwithdraw = new DepositWithDraw();
                        dwithdraw = ic.ivfDB.dwitdrawDB.selectByPk(bild.Comment.Trim());
                        if (dwithdraw.withdraw_id.Length > 0 & dwithdraw.bill_id.Length <= 0)//never withdraw amount
                        {
                            String re = ic.ivfDB.dwitdrawDB.updateBillId(dwithdraw.withdraw_id, txtBillId.Text.Trim());
                            String re1 = ic.ivfDB.depositDB.updateAmount(dwithdraw.deposit_id, dwithdraw.withdraw_amount);

                        }
                    }
                }
            }
            catch(Exception ex)
            {
                ic.logw.WriteLog("e", "FrmCashierAdd setBillIdDeposit error "+ex.Message);
            }
        }
        private void ContextMenu_send_back(object sender, System.EventArgs e)
        {
            String chk = "", name = "", id = "";
            
        }
        private void setGrfBillD()
        {
            //grfDept.Rows.Count = 7;
            //grfBillD.Clear();
            DataTable dt1 = new DataTable();
            DataTable dt = new DataTable();
            if (receiptno.Length > 0)
            {
                dt = ic.ivfDB.obildDB.selectByBillId1(txtBillId.Text);
            }
            else
            {
                //dt = ic.ivfDB.obildDB.selectByVN(txtVnOld.Text);      //          -0020
                dt = ic.ivfDB.obildDB.selectByVN(txtVn.Text);           //      +0020
            }
            //if (search.Equals(""))
            //{
            //    String date = "";
            //    DateTime dt11 = new DateTime();
            //    if (DateTime.TryParse(txtDateStart.Text, out dt11))
            //    {
            //        //dt11 = dt11.AddDays(-1);
            //        date = dt11.Year + "-" + dt11.ToString("MM-dd");

            //    }
            //}
            //else
            //{
            //    //grfPtt.DataSource = ic.ivfDB.vsOldDB.selectCurrentVisit(search);
            //}

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("ยกเลิก รายการ", new EventHandler(ContextMenu_void_bill));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfBillD.ContextMenu = menuGw;
            grfBillD.Rows.Count = 1;
            grfBillD.Rows.Count = dt.Rows.Count + 2;
            grfBillD.Cols.Count = 12;
            //C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            //grfBillD.Cols[colName].Editor = txt;
            //grfBillD.Cols[colAmt].Editor = txt;
            //grfBillD.Cols[colDiscount].Editor = txt;
            //grfBillD.Cols[colNetAmt].Editor = txt;

            grfBillD.Cols[colName].Width = 360;
            grfBillD.Cols[colAmt].Width = 120;
            grfBillD.Cols[colDiscount].Width = 120;
            grfBillD.Cols[colNetAmt].Width = 120;
            grfBillD.Cols[colGrpName].Width = 120;
            grfBillD.Cols[colprice].Width = 100;
            grfBillD.Cols[colqty].Width = 80;

            grfBillD.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfBillD.Cols[colName].Caption = "รายการ";
            grfBillD.Cols[colAmt].Caption = "จำนวนเงิน";
            grfBillD.Cols[colDiscount].Caption = "ส่วนลด";
            grfBillD.Cols[colNetAmt].Caption = "คงเหลือ";
            grfBillD.Cols[colGrpName].Caption = "group name";
            grfBillD.Cols[colprice].Caption = "Price";
            grfBillD.Cols[colqty].Caption = "QTY";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            Decimal inc = 0, ext = 0;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    Decimal price = 0, qty = 1, price1=0;
                    Decimal.TryParse(row[ic.ivfDB.obildDB.obilld.Price].ToString(), out price);
                    Decimal.TryParse(row[ic.ivfDB.obildDB.obilld.qty].ToString(), out qty);
                    Decimal.TryParse(row[ic.ivfDB.obildDB.obilld.price1].ToString(), out price1);
                    grfBillD[i, 0] = i;
                    grfBillD[i, colId] = row[ic.ivfDB.obildDB.obilld.ID].ToString();
                    grfBillD[i, colName] = row[ic.ivfDB.obildDB.obilld.Name].ToString();
                    grfBillD[i, colAmt] = price.ToString("#,###.00");
                    grfBillD[i, colDiscount] = "";
                    if (row["Extra"].ToString().Equals("1"))
                    {
                        grfBillD[i, colNetAmt] = price.ToString("#,###.00");
                    }
                    else
                    {
                        if (row[ic.ivfDB.obildDB.obilld.GroupType].ToString().Equals("Package"))
                        {
                            grfBillD[i, colNetAmt] = price.ToString("#,###.00");
                        }
                        else
                        {
                            grfBillD[i, colNetAmt] = "0.00";
                        }
                    }
                    
                    grfBillD[i, colGrpName] = row[ic.ivfDB.obildDB.obilld.GroupType].ToString();
                    grfBillD[i, colInclude] = row["Extra"].ToString().Equals("1") ? "Extra" : "Include";
                    grfBillD[i, colStatus] = row["status"].ToString();
                    grfBillD[i, colprice] = price1.ToString("#,###.00");
                    grfBillD[i, colqty] = qty.ToString("#,###.00");
                    //if (!row[ic.ivfDB.vsOldDB.vsold.form_a_id].ToString().Equals("0"))
                    //{
                    //    CellNote note = new CellNote("ส่ง Lab Request Foam A");
                    //    CellRange rg = grfBillD.GetCellRange(i, colVN);
                    //    rg.UserData = note;
                    //}
                    //if (i % 2 == 0)
                    //    grfPtt.Rows[i].StyleNew.BackColor = color;
                    //if (row["Extra"].ToString().Equals("1"))
                    //{
                    //    ext += (price * qty);
                    //}
                    //else
                    //{
                    //    if (row["status"].ToString().Equals("package"))
                    //    {
                    //        inc += (price * qty);
                    //    }
                    //}
                    i++;
                }
                catch (Exception ex)
                {
                    String err = "";
                }
            }
            CellNoteManager mgr = new CellNoteManager(grfBillD);
            grfBillD.Cols[colBilId].Visible = false;
            grfBillD.Cols[colId].Visible = false;
            grfBillD.Cols[colDiscount].AllowEditing = false;
            grfBillD.Cols[colAmt].AllowEditing = false;
            grfBillD.Cols[colNetAmt].AllowEditing = false;
            grfBillD.Cols[colGrpName].AllowEditing = false;
            grfBillD.Cols[colInclude].AllowEditing = false;
            grfBillD.Cols[colDiscount].AllowSorting = false;
            grfBillD.Cols[colAmt].AllowSorting = false;
            grfBillD.Cols[colNetAmt].AllowSorting = false;
            grfBillD.Cols[colGrpName].AllowSorting = false;
            grfBillD.Cols[colInclude].AllowSorting = false;
            //grfBillD.Cols[colDiscount].AllowSorting = false;
            //grfBillD.Cols[colDiscount].AllowSorting = false;
            //theme1.SetTheme(grfQue, ic.theme);
            Decimal amt = 0;
            amt = calAmt();
            txtAmt.Value = amt.ToString("#,###.00");
        }
        private Decimal calAmt()
        {
            Decimal amt = 0, amt1=0, inc = 0, ext = 0;
            String chk = "";
            foreach (Row row in grfBillD.Rows)
            {
                Decimal price = 0, qty = 1;
                if (row[colName] == null) continue;
                if (row[colName].ToString().Equals("")) continue;
                if (row[colInclude] == null) continue;
                chk = row[colNetAmt].ToString();
                Decimal.TryParse(chk, out amt);
                //amt1 += amt;
                if (row[colInclude].ToString().Equals("Extra"))
                {
                    ext += (amt * qty);
                }
                else
                {
                    if (row[colStatus].ToString().Equals("package"))
                    {
                        inc += (amt * qty);
                    }
                }
            }
            amt1 = ext + inc;
            return amt1;
        }
        private void UpdateTotals()
        {
            // clear existing totals
            grfBillD.Subtotal(AggregateEnum.Clear);
            grfBillD.Subtotal(AggregateEnum.Sum, 0,-1, colNetAmt);
            //grfBillD.Subtotal(AggregateEnum.Sum, 0, -1, colAmt, " d");

        }
        private void setChkDiscount(Boolean flag)
        {
            txtDiscount.Enabled = flag;
            pnDiscount.Enabled = flag;
            panel3.Enabled = false;
        }
        private void calTotal(String flagcharge)
        {
            Decimal amt = 0, total = 0, discount=0, total11=0;
            Decimal.TryParse(txtAmt.Text, out amt);
            Decimal.TryParse(txtDiscount.Text, out discount);
            Decimal.TryParse(txtTotalCredit.Text, out total11);
            //Decimal.TryParse(txtAmt.Text, out amt);
            total = amt - discount;
            txtTotal.Value = total.ToString("#,###.00");
            String cashid1 = "", creditid1 = "", transfer1="";
            cashid1 = cboAccCash.SelectedItem == null ? "" : ((ComboBoxItem)cboAccCash.SelectedItem).Value;
            creditid1 = cboAccCredit.SelectedItem == null ? "" : ((ComboBoxItem)cboAccCredit.SelectedItem).Value;
            transfer1 = cboAccCashTransfer.SelectedItem == null ? "" : ((ComboBoxItem)cboAccCashTransfer.SelectedItem).Value;
            if ((cashid1.Length > 0) && (creditid1.Length > 0) && (transfer1.Length > 0))
            {
                //txtTotalCash.Value = total;
                //txtTotalCredit.Value = "0";
            }
            else if ((cashid1.Length > 0) && (creditid1.Length == 0) && (transfer1.Length == 0))
            {
                txtTotalCash.Value = total;
                //txtTotalCredit.Value = "0";
            }
            else if ((creditid1.Length > 0) && (cashid1.Length == 0) && (transfer1.Length == 0))
            {
                //txtTotalCash.Value = "0";
                if (flagcharge.Length == 0)
                {
                    txtTotalCredit.Value = total;
                }
            }
            else if ((transfer1.Length > 0) && (cashid1.Length == 0) && (creditid1.Length == 0 || creditid1.Equals("0")))
            {
                //txtTotalCash.Value = "0";
                txtTotalTransfer.Value = total;
                
            }
        }
        private void calTotalCredit(String flagcharge)
        {
            Decimal total = 0, cash=0, credit=0, per=0, paycredit=0;
            Decimal.TryParse(txtTotal.Text, out total);
            Decimal.TryParse(txtTotalCash.Text, out cash);
            Decimal.TryParse(txtTotalCredit.Text, out credit);
            Decimal.TryParse(txtCreditCharge.Text, out per);
            if (credit > 0)
            {
                credit = total - cash;
                paycredit = credit * per / 100;
                txtTotalCredit.Value = credit.ToString("0.00");
                txtPayCreditCard.Value = paycredit.ToString("0.00");
                if (flagcharge.Length == 0)
                {
                    txtTotalCash.Value = total - credit;
                }
            }
        }
        private void calTotalCash()
        {
            Decimal total = 0, cash = 0, credit = 0, per = 0, paycredit = 0, transfer=0;
            Decimal.TryParse(txtTotal.Text, out total);
            Decimal.TryParse(txtTotalCredit.Text, out credit);
            Decimal.TryParse(txtTotalTransfer.Text, out transfer);
            Decimal.TryParse(txtCreditCharge.Text, out per);
            cash = total - credit - transfer;
            paycredit = credit * per / 100;
            txtTotalCash.Value = cash.ToString("0.00");
            txtPayCreditCard.Value = paycredit.ToString("0.00");
        }
        private void FrmCashierAdd_Load(object sender, EventArgs e)
        {
            String date = "";
            date = DateTime.Now.Year + "-" + DateTime.Now.ToString("MM-dd");
            menu.Text = ic.iniC.statusAppDonor.Equals("1") ? "โปรแกรมClinic IVF Donor " + "สวัสดี คุณ " + ic.user.staff_fname_t + " " + ic.user.staff_lname_t + " Update 2020-11-26 "
                : "โปรแกรมClinic IVF " + "สวัสดี คุณ " + ic.user.staff_fname_t + " " + ic.user.staff_lname_t + " Update 2020-11-26 format date " + date
                + " [" + ic.ivfDB.copDB.cop.day + "-" + ic.ivfDB.copDB.cop.month + "-" + ic.ivfDB.copDB.cop.year + "]";
            //sB1.Text = "Date " + ic.cop.day + "-" + ic.cop.month + "-" + ic.cop.year + " Server " + ic.iniC.hostDB + " FTP " + ic.iniC.hostFTP;
            sB1.Text = "Date " + ic.cop.day + "-" + ic.cop.month + "-" + ic.cop.year + " Server " + ic.iniC.hostDB + " FTP " + ic.iniC.hostFTP + "/" + ic.iniC.folderFTP;
            tC1.SelectedTab = tabBillItem;
            int pn4width = 0;
            pn4width = Screen.PrimaryScreen.Bounds.Width - panel4.Location.X;
            panel4.Height = panel2.Height;
            panel4.BackColor = Color.Khaki;
            panel4.Width = pn4width-50;
            panel4.Top = 0;
        }
    }
}
