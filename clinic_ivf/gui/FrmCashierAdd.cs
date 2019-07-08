using C1.Win.C1Command;
using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
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
    public partial class FrmCashierAdd : Form
    {
        IvfControl ic;
        MainMenu menu;
        public C1DockingTabPage tab;
        public FrmCashierView frmCashView;
        String billid = "", pttid = "", vsid = "", vsidOld = "";
        OldBillheader obilh;
        VisitOld ovs;
        PatientOld optt;
        Patient ptt;
        Visit vs;

        C1FlexGrid grfBillD;
        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;
        Color color;
        String vnold = "", printerOld = "";

        C1SuperTooltip stt;
        C1SuperErrorProvider sep;

        int colId = 1, colName = 2, colprice=3, colqty=4, colAmt = 5, colDiscount = 6, colNetAmt = 7, colGrpName=8, colBilId=9, colInclude=10, colStatus=11;
        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetDefaultPrinter(string Printer);
        public FrmCashierAdd(IvfControl ic, MainMenu m, String billid, String vnold, String flagedit)
        {
            InitializeComponent();
            menu = m;
            this.ic = ic;
            this.vnold = vnold;
            this.billid = billid;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);
            ovs = new VisitOld();
            optt = new PatientOld();
            ptt = new Patient();

            //C1ThemeController.ApplicationTheme = ic.iniC.themeApplication;
            //theme1.Theme = C1ThemeController.ApplicationTheme;
            theme1.SetTheme(sB, "BeigeOne");
            color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);

            sB1.Text = "";
            bg = txtHn.BackColor;
            fc = txtHn.ForeColor;
            ff = txtHn.Font;
            ic.ivfDB.ocaDB.setCboCashAccount(cboAccCash, "");
            ic.ivfDB.occa.setCboCreditCardAccount(cboAccCredit, "");
            ic.ivfDB.obilgDB.setCboGroupType(cboGrpType, "0");
            txtCreditCharge.Value = ic.iniC.creditCharge;

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();

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
            //txtTotalCash.KeyPress += TxtTotalCash_KeyPress;
            //txtTotalCredit.KeyPress += TxtTotalCredit_KeyPress;

            ChkDiscountPer_CheckedChanged(null, null);
            initGrfBillD();
            setChkDiscount(false);
            setControl();
            //ic.ivfDB.copDB.cop = ic.ivfDB.copDB.selectByCode2("001");
            //year = DateTime.Now.ToString("yyyy");

            //MessageBox.Show(DateTime.Now.ToString("yyyy"), "");
            //MessageBox.Show(DateTime.Now.ToString("MM"), "");
            //MessageBox.Show(DateTime.Now.ToString("dd"), "");
        }
        private void BtnPrnReceipt_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String cashid1 = "", creditid1="";
            cashid1 = cboAccCash.SelectedItem == null ? "" : ((ComboBoxItem)cboAccCash.SelectedItem).Value;
            creditid1 = cboAccCredit.SelectedItem == null ? "" : ((ComboBoxItem)cboAccCredit.SelectedItem).Value;
            if(cashid1.Length == 0 && creditid1.Length == 0)
            {
                MessageBox.Show("ยังไม่ได้เลือก ประเภทบัญชี", "");
                return;
            }
            Decimal totalcredit = 0, totalcash=0, total=0, discount=0;
            if(Decimal.TryParse(txtTotalCredit.Text.Replace(",", ""), out totalcredit))
            {
                if (creditid1.Equals("") && totalcredit>0)
                {
                    MessageBox.Show("มียอด credit ไม่ยังไม่ได้เลือก ประเภทบัญชี", "");
                    return;
                }
            }
            if (Decimal.TryParse(txtTotalCash.Text.Replace(",", ""), out totalcash))
            {
                if (cashid1.Equals("") && totalcash >0)
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

            DataTable dt = new DataTable();
            DataTable dtprn = new DataTable();
            DataTable dtpgk = new DataTable();
            Decimal amt = 0, sumprice = 0, price1 = 0, cash = 0, credit = 0;
            long amt1 = 0;
            String amt2 = "", billNo = "", billExtNo = "", payby = "", date = "", year = "", month = "", day = "", billFormat = "";
            long.TryParse(amt.ToString(), out amt1);
            dt = ic.ivfDB.printBill(txtVn.Text, ref amt, ref payby);

            String receiptno = "", billnoex1 = "";
            receiptno = ic.ivfDB.obilhDB.selectReceiptNoByVN(ovs.VN);
            //billnoex1 = ic.ivfDB.obilhDB.selectBillNoExByVN(ovs.VN);
            if (receiptno.Length <= 0)
            {
                billNo = ic.ivfDB.copDB.genReceiptDoc(ref year, ref month, ref day);
                billExtNo = ic.ivfDB.copDB.genReceiptExtDoc();
                String cashid = cboAccCash.SelectedItem == null ? "" : ((ComboBoxItem)cboAccCash.SelectedItem).Value;
                String creditid = cboAccCredit.SelectedItem == null ? "" : ((ComboBoxItem)cboAccCredit.SelectedItem).Value;
                //ic.ivfDB.obilhDB.updateReceiptNo(txtVn.Text, billNo, txtTotalCash.Text.Replace(",",""), txtTotalCredit.Text.Replace(",", ""), txtCreditCardNumber.Text, cashid, creditid);
                ic.ivfDB.obilhDB.updateReceiptNoByBillId(txtBillId.Text, billNo, txtTotalCash.Text.Replace(",", ""), txtTotalCredit.Text.Replace(",", "")
                    , txtCreditCardNumber.Text, cashid, creditid, total.ToString(), discount.ToString(),txtPayName.Text);

                //OldBillheader obill = new OldBillheader();
                String billno2 = ic.ivfDB.obilhDB.selectBillNoByVN(txtVn.Text);
                if (billno2.Equals(""))
                {
                    String billNo1 = ic.ivfDB.copDB.genBillingDoc(ref year, ref month, ref day);
                    String billExtNo1 = ic.ivfDB.copDB.genBillingExtDoc();
                    //ic.ivfDB.obilhDB.updateBillNo(txtVn.Text, billNo1);
                    ic.ivfDB.obilhDB.updateBillNoByBillId(txtBillId.Text, billNo1);
                }

                //dtpgk = ic.ivfDB.opkgsDB.selectByVN1(txtVn.Text);
                dtpgk = ic.ivfDB.opkgsDB.selectByPID(ovs.PID);    // ต้องดึงตาม HN เพราะ ถ้ามีงวดการชำระ 
                foreach (DataRow row in dtpgk.Rows)
                {
                    String times = "";
                    Decimal price = 0;
                    //row["PaymentTimes"].GetType()
                    times = row["payment_times"].ToString();
                    ic.ivfDB.updatePackagePaymentComplete(ovs.PID, row["PCKID"].ToString());
                    if (Decimal.TryParse(row["Payment1"].ToString(), out price) && row["P1BDetailID"].ToString().Equals("0"))
                    {
                        ic.ivfDB.opkgsDB.updateP1BillNo(row["PCKSID"].ToString(), billNo.Replace(ic.cop.prefix_receipt_doc, ""));
                        //times = "1";
                    }
                    else if (Decimal.TryParse(row["Payment2"].ToString(), out price) && row["P2BDetailID"].ToString().Equals("0"))
                    {
                        ic.ivfDB.opkgsDB.updateP2BillNo(row["PCKSID"].ToString(), billNo.Replace(ic.cop.prefix_receipt_doc, ""));
                    }
                    else if (Decimal.TryParse(row["Payment3"].ToString(), out price) && row["P3BDetailID"].ToString().Equals("0"))
                    {
                        ic.ivfDB.opkgsDB.updateP3BillNo(row["PCKSID"].ToString(), billNo.Replace(ic.cop.prefix_receipt_doc, ""));
                    }
                    else if (Decimal.TryParse(row["Payment4"].ToString(), out price) && row["P4BDetailID"].ToString().Equals("0"))
                    {
                        ic.ivfDB.opkgsDB.updateP4BillNo(row["PCKSID"].ToString(), billNo.Replace(ic.cop.prefix_receipt_doc, ""));
                    }
                }
            }
            else
            {
                billNo = receiptno;
                billExtNo = billnoex1;
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

            String re = ic.ivfDB.ovsDB.updateStatusCashierFinish(txtVn.Text);
            amt2 = ic.NumberToCurrencyTextThaiBaht(amt, MidpointRounding.AwayFromZero);
            Decimal.TryParse(txtTotalCash.Text, out cash);
            Decimal.TryParse(txtTotalCredit.Text, out credit);
            if ((cash > 0) && (credit <= 0))
            {
                payby = "เงินสด/Cash ";
            }
            else if ((credit > 0) && (cash <= 0))
            {
                payby = "เครดิตการ์ด/Credit Card ";
            }
            else if ((credit > 0) && (cash > 0))
            {
                payby = "เงินสด และเครดิตการ์ด/Cash & Credit Card ";
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
            frm.setPrintBill(dtprn, txtHn.Text, txtPttNameE.Text, amt2, amt.ToString("#,###.00"), billNo, day + "/" + month + "/" + year, payby,"ใบเสร็จ/Receipt", sumprice.ToString("#,###.00"));
            frm.ShowDialog(this);
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
                obilld.item_id = "67";      // form table specialitem
                obilld.status = "special";
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
                else
                {
                    Decimal.TryParse(txtAmt.Text, out nettotal);
                    if (!chkDiscountCash.Checked)
                    {
                        Decimal.TryParse(txtDiscountAmt.Text, out discountper);
                        discount = (nettotal * discountper / 100);
                        txtDiscount.Value = discount;
                    }
                }
                obilld.Price = "-" + txtDiscount.Text.Replace(",", "");
                obilld.Total = "-" + txtDiscount.Text.Replace(",", "");
                obilld.Comment = "";
                obilld.bill_group_id = "99";            // form table billgroup
                obilld.GroupType = "Discount";

                long chk = 0;
                String re = ic.ivfDB.obildDB.insertBillDetail(obilld, "");
                if (long.TryParse(re, out chk))
                {
                    txtDiscount.Value = "";
                    pnDiscount.Enabled = false;
                    panel3.Enabled = false;
                    chkDiscount.Enabled = false;
                    txtDiscount.Enabled = false;
                    setGrfBillD();
                    calTotal();
                    calTotalCredit();
                }
            }
            else
            {
                txtDiscount.Value = "";
                pnDiscount.Enabled = true;
                panel3.Enabled = true;
                chkDiscount.Enabled = true;
                txtDiscount.Enabled = true;
                foreach(Row row in grfBillD.Rows)
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
                calTotal();
                calTotalCredit();
            }
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
            obilld.item_id = "98";            // form table specialitem
            obilld.GroupType = "OtherService";
            obilld.status = "special";
            obilld.bill_group_id = "102";            // form table billgroup
            ic.ivfDB.obildDB.insertBillDetail(obilld, ic.userId);
            setGrfBillD();
            calTotal();
            calTotalCredit();
            txtPayCreditCard.Value = "";
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //txtVsId.Value = vs.t_visit_id;
            String re = ic.ivfDB.ovsDB.updateStatusCashierFinish(txtVn.Text);
            String re1 = ic.ivfDB.vsDB.updateCloseStatusCashier(txtVsId.Text);
            frmCashView.setGrfQuePublic();
            frmCashView.setGrfFinishPublic();
            menu.removeTab(tab);
        }

        private void BtnCalBack_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.ivfDB.accountsendtonurse(txtVn.Text, ic.userId);
            VisitOld ovs = new VisitOld();
            ovs = ic.ivfDB.ovsDB.selectByPk1(txtVnOld.Text);
            if (ovs.VSID.Equals("115"))
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

            DataTable dt = new DataTable();
            DataTable dtprn = new DataTable();
            DataTable dtpgk = new DataTable();
            Decimal amt = 0, sumprice=0, price1=0, cash=0, credit=0;
            long amt1 = 0;
            String amt2 = "", billNo="", billExtNo="", payby="", date="", year="", month="", day="", billFormat="";
            long.TryParse(amt.ToString(), out amt1);
            dt = ic.ivfDB.printBill(txtVn.Text,ref amt, ref payby);

            String billno1 = "", billnoex1="";
            billno1 = ic.ivfDB.obilhDB.selectBillNoByVN(ovs.VN);
            billnoex1 = ic.ivfDB.obilhDB.selectBillNoExByVN(ovs.VN);
            if (billno1.Length <= 0)
            {
                billNo = ic.ivfDB.copDB.genBillingDoc(ref year, ref month, ref day);
                billExtNo = ic.ivfDB.copDB.genBillingExtDoc();
                ic.ivfDB.obilhDB.updateBillNo(txtVn.Text, billNo);

                dtpgk = ic.ivfDB.opkgsDB.selectByPID(ovs.PID);    // ต้องดึงตาม HN เพราะ ถ้ามีงวดการชำระ 
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
                    ic.ivfDB.updatePackagePaymentComplete(ovs.PID, row["PCKSID"].ToString());
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
            frm.setPrintBill(dtprn, txtHn.Text, txtPttNameE.Text, amt2, amt.ToString("#,###.00"), billNo, day+"/"+month+"/"+year, payby,"ใบแจ้งหนี้/Bill", sumprice.ToString("#,###.00"));
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
            calTotalCredit();
        }

        private void TxtDiscount_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calTotal();
        }

        private void TxtAmt_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calTotal();
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
            ovs = ic.ivfDB.ovsDB.selectByPk1(vnold);
            optt = ic.ivfDB.pttOldDB.selectByPk1(ovs.PID);
            ptt = ic.ivfDB.pttDB.selectByHn(ovs.PIDS);
            vs = ic.ivfDB.vsDB.selectByVn(ovs.VN);
            //obilh = ic.ivfDB.obilhDB.selectByVN(ovs.VN);
            ptt.patient_birthday = optt.DateOfBirth;

            txtHn.Value = optt.PIDS;
            txtPttNameE.Value = optt.FullName;
            txtDob.Value = ic.datetoShow(optt.DateOfBirth) + " [" + ptt.AgeStringShort() + "]";
            txtHnOld.Value = optt.PIDS;
            txtVnOld.Value = vsidOld;
            txtPttId.Value = optt.PID;
            txtVsId.Value = vs.t_visit_id;
            txtVnOld.Value = ovs.VN;
            txtHnOld.Value = ovs.PIDS;
            txtVn.Value = ovs.VN;
            txtVnShow.Value = ic.showVN(ovs.VN);
            txtAllergy.Value = ptt.allergy_description;
            txtSex.Value = ptt.f_sex_id.Equals("1") ? "ชาย" : "หญิง";
            txtBg.Value = ptt.f_patient_blood_group_id.Equals("2140000005") ? "O"
                : ptt.f_patient_blood_group_id.Equals("2140000002") ? "A" : ptt.f_patient_blood_group_id.Equals("2140000003") ? "B"
                : ptt.f_patient_blood_group_id.Equals("2140000004") ? "AB" : "ไม่ระบุ";
            txtAgent.Value = ic.ivfDB.oAgnDB.getList(ptt.agent);
            setGrfBillD();
            calTotal();
            calTotalCredit();
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
            menuGw.MenuItems.Add("ออก บิล", new EventHandler(ContextMenu_edit_bill));
            menuGw.MenuItems.Add("ส่งกลับ", new EventHandler(ContextMenu_send_back));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfBillD.ContextMenu = menuGw;
            grfBillD.SubtotalPosition = SubtotalPositionEnum.BelowData;
            pnBillD.Controls.Add(grfBillD);

            theme1.SetTheme(grfBillD, "Office2010Red");

            //theme1.SetTheme(tabDiag, "Office2010Blue");
            //theme1.SetTheme(tabFinish, "Office2010Blue");

        }

        private void GrfBillD_AfterDataRefresh(object sender, ListChangedEventArgs e)
        {
            //throw new NotImplementedException();
            UpdateTotals();
        }
        private void ContextMenu_edit_bill(object sender, System.EventArgs e)
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
                ic.ivfDB.obildDB.voidBillDetailBybildid(bildid, ic.cStf.staff_id);
                setGrfBillD();
            }
        }
        private void ContextMenu_send_back(object sender, System.EventArgs e)
        {
            String chk = "", name = "", id = "";

            
        }
        private void setGrfBillD()
        {
            //grfDept.Rows.Count = 7;
            grfBillD.Clear();
            DataTable dt1 = new DataTable();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.obildDB.selectByVN(txtVnOld.Text);
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
            menuGw.MenuItems.Add("ยกเลิก รายการ", new EventHandler(ContextMenu_edit_bill));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfBillD.ContextMenu = menuGw;

            grfBillD.Rows.Count = dt.Rows.Count + 2;
            grfBillD.Cols.Count = 12;
            C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfBillD.Cols[colName].Editor = txt;
            grfBillD.Cols[colAmt].Editor = txt;
            grfBillD.Cols[colDiscount].Editor = txt;
            grfBillD.Cols[colNetAmt].Editor = txt;

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
        private void calTotal()
        {
            Decimal amt = 0, total = 0, discount=0;
            Decimal.TryParse(txtAmt.Text, out amt);
            Decimal.TryParse(txtDiscount.Text, out discount);
            //Decimal.TryParse(txtAmt.Text, out amt);
            total = amt - discount;
            txtTotal.Value = total.ToString("#,###.00");
            String cashid1 = "", creditid1 = "";
            cashid1 = cboAccCash.SelectedItem == null ? "" : ((ComboBoxItem)cboAccCash.SelectedItem).Value;
            creditid1 = cboAccCredit.SelectedItem == null ? "" : ((ComboBoxItem)cboAccCredit.SelectedItem).Value;
            if (cashid1.Length > 0)
            {
                txtTotalCash.Value = total;
                txtTotalCredit.Value = "0";
            }
            else if (creditid1.Length > 0)
            {
                txtTotalCash.Value = "0";
                txtTotalCredit.Value = total;
            }
            
        }
        private void calTotalCredit()
        {
            Decimal total = 0, cash=0, credit=0, per=0, paycredit=0;
            Decimal.TryParse(txtTotal.Text, out total);
            Decimal.TryParse(txtTotalCash.Text, out cash);
            Decimal.TryParse(txtTotalCredit.Text, out credit);
            Decimal.TryParse(txtCreditCharge.Text, out per);
            if (credit > 0)
            {
                //credit = total - cash;
                paycredit = credit * per / 100;
                txtTotalCredit.Value = credit.ToString("0.00");
                txtPayCreditCard.Value = paycredit.ToString("0.00");
            }
            
        }
        private void calTotalCash()
        {
            Decimal total = 0, cash = 0, credit = 0, per = 0, paycredit = 0;
            Decimal.TryParse(txtTotal.Text, out total);
            Decimal.TryParse(txtTotalCredit.Text, out credit);
            Decimal.TryParse(txtCreditCharge.Text, out per);
            cash = total - credit;
            paycredit = credit * per / 100;
            txtTotalCash.Value = cash.ToString("0.00");
            txtPayCreditCard.Value = paycredit.ToString("0.00");
        }
        private void FrmCashierAdd_Load(object sender, EventArgs e)
        {
            String date = "";
            date = DateTime.Now.Year + "-" + DateTime.Now.ToString("MM-dd");
            menu.Text = ic.iniC.statusAppDonor.Equals("1") ? "โปรแกรมClinic IVF Donor " + "สวัสดี คุณ " + ic.user.staff_fname_t + " " + ic.user.staff_lname_t + " Update 2019-06-27 "
                : "โปรแกรมClinic IVF " + "สวัสดี คุณ " + ic.user.staff_fname_t + " " + ic.user.staff_lname_t + " Update 2019-06-27 format date " + date
                + " [" + ic.ivfDB.copDB.cop.day + "-" + ic.ivfDB.copDB.cop.month + "-" + ic.ivfDB.copDB.cop.year + "]";
            //sB1.Text = "Date " + ic.cop.day + "-" + ic.cop.month + "-" + ic.cop.year + " Server " + ic.iniC.hostDB + " FTP " + ic.iniC.hostFTP;
            sB1.Text = "Date " + ic.cop.day + "-" + ic.cop.month + "-" + ic.cop.year + " Server " + ic.iniC.hostDB + " FTP " + ic.iniC.hostFTP + "/" + ic.iniC.folderFTP;
        }
    }
}
