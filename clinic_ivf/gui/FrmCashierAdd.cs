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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.gui
{
    public partial class FrmCashierAdd : Form
    {
        IvfControl ic;
        String billhid = "", pttid = "", vsid = "", vsidOld = "";
        OldBillheader obilh;
        VisitOld ovs;
        PatientOld optt;

        C1FlexGrid grfBillD;
        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;
        Color color;
        String vnold = "";

        C1SuperTooltip stt;
        C1SuperErrorProvider sep;

        int colId = 1, colName = 2, colAmt = 3, colDiscount = 4, colNetAmt = 5, colGrpName=6, colBilId=7;
        public FrmCashierAdd(IvfControl ic, String billid, String vnold)
        {
            InitializeComponent();
            this.ic = ic;
            this.vnold = vnold;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);
            ovs = new VisitOld();
            optt = new PatientOld();

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
            btnClose.Click += BtnClose_Click;
            txtCreditCharge.KeyUp += TxtCreditCharge_KeyUp;
            //txtTotalCash.KeyPress += TxtTotalCash_KeyPress;
            //txtTotalCredit.KeyPress += TxtTotalCredit_KeyPress;

            ChkDiscountPer_CheckedChanged(null, null);
            initGrfBillD();
            setChkDiscount(false);
            setControl();
            
        }

        private void TxtCreditCharge_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calTotalCash();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.printBill(txtVn.Text);
            FrmReport frm = new FrmReport(ic);
            frm.setPrintBill(dt);
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

        private void ChkDiscount_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setChkDiscount(chkDiscount.Checked);
        }

        private void setControl()
        {
            ovs = ic.ivfDB.ovsDB.selectByPk1(vnold);
            optt = ic.ivfDB.pttOldDB.selectByPk1(ovs.PID);
            txtHn.Value = optt.PIDS;
            txtPttNameE.Value = optt.FullName;
            txtDob.Value = optt.DateOfBirth;
            txtHnOld.Value = optt.PIDS;
            txtVnOld.Value = vsidOld;
            txtPttId.Value = optt.PID;
            txtVsId.Value = ovs.VN;
            txtVnOld.Value = ovs.VN;
            txtHnOld.Value = ovs.PIDS;

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
            menuGw.MenuItems.Add("ออก บิล", new EventHandler(ContextMenu_edit_bill));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfBillD.ContextMenu = menuGw;

            grfBillD.Rows.Count = dt.Rows.Count + 2;
            grfBillD.Cols.Count = 8;
            C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfBillD.Cols[colName].Editor = txt;
            grfBillD.Cols[colAmt].Editor = txt;
            grfBillD.Cols[colDiscount].Editor = txt;
            grfBillD.Cols[colNetAmt].Editor = txt;

            grfBillD.Cols[colName].Width = 300;
            grfBillD.Cols[colAmt].Width = 120;
            grfBillD.Cols[colDiscount].Width = 120;
            grfBillD.Cols[colNetAmt].Width = 120;
            grfBillD.Cols[colGrpName].Width = 120;

            grfBillD.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfBillD.Cols[colName].Caption = "รายการ";
            grfBillD.Cols[colAmt].Caption = "จำนวนเงิน";
            grfBillD.Cols[colDiscount].Caption = "ส่วนลด";
            grfBillD.Cols[colNetAmt].Caption = "คงเหลือ";
            grfBillD.Cols[colGrpName].Caption = "group name";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                grfBillD[i, 0] = i;
                grfBillD[i, colId] = row[ic.ivfDB.obildDB.obilld.ID].ToString();
                grfBillD[i, colName] = row[ic.ivfDB.obildDB.obilld.Name].ToString();
                grfBillD[i, colAmt] = row[ic.ivfDB.obildDB.obilld.Price].ToString();
                grfBillD[i, colDiscount] = "";
                grfBillD[i, colNetAmt] = row[ic.ivfDB.obildDB.obilld.Total].ToString();
                grfBillD[i, colGrpName] = row[ic.ivfDB.obildDB.obilld.GroupType].ToString();
                //if (!row[ic.ivfDB.vsOldDB.vsold.form_a_id].ToString().Equals("0"))
                //{
                //    CellNote note = new CellNote("ส่ง Lab Request Foam A");
                //    CellRange rg = grfBillD.GetCellRange(i, colVN);
                //    rg.UserData = note;
                //}
                //if (i % 2 == 0)
                //    grfPtt.Rows[i].StyleNew.BackColor = color;
                i++;
            }
            CellNoteManager mgr = new CellNoteManager(grfBillD);
            grfBillD.Cols[colBilId].Visible = false;
            grfBillD.Cols[colId].Visible = false;
            grfBillD.Cols[colDiscount].AllowEditing = false;
            grfBillD.Cols[colAmt].AllowEditing = false;
            grfBillD.Cols[colNetAmt].AllowEditing = false;
            grfBillD.Cols[colGrpName].AllowEditing = false;
            //theme1.SetTheme(grfQue, ic.theme);
            txtAmt.Value = calAmt().ToString("0.00");
        }
        private Decimal calAmt()
        {
            Decimal amt = 0, amt1=0;
            String chk = "";
            foreach (Row row in grfBillD.Rows)
            {
                if (row[colName] == null) continue;
                if (row[colName].ToString().Equals("")) continue;
                chk = row[colNetAmt].ToString();
                Decimal.TryParse(chk, out amt);
                amt1 += amt;
            }
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
        }
        private void calTotal()
        {
            Decimal amt = 0, total = 0, discount=0;
            Decimal.TryParse(txtAmt.Text, out amt);
            Decimal.TryParse(txtDiscount.Text, out discount);
            //Decimal.TryParse(txtAmt.Text, out amt);
            total = amt - discount;
            txtTotal.Value = total.ToString("0.00");
            txtTotalCash.Value = total.ToString("0.00");
            txtTotalCredit.Value = "0";
        }
        private void calTotalCredit()
        {
            Decimal total = 0, cash=0, credit=0, per=0, paycredit=0;
            Decimal.TryParse(txtTotal.Text, out total);
            Decimal.TryParse(txtTotalCash.Text, out cash);
            Decimal.TryParse(txtCreditCharge.Text, out per);
            credit = total - cash;
            paycredit = credit * per / 100;
            txtTotalCredit.Value = credit.ToString("0.00");
            txtPayCreditCard.Value = paycredit.ToString("0.00");
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

        }
    }
}
