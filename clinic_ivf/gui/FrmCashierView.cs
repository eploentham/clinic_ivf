﻿using C1.Win.C1Command;
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
    public partial class FrmCashierView : Form
    {
        IvfControl ic;
        MainMenu menu;

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;

        int colID = 1, colVNshow = 2, colVN = 12, colPttHn = 3, colPttName = 4, colVsDate = 5, colVsTime = 6, colVsEtime = 7, colVsAgent=8, colStatus = 9, colPttId = 10, colStatusNurse = 11, colStatusCashier = 12, colBillId=13;
        int colCldId = 1, colCldBillNo = 2, colCldReceiptNo=3, colCldDate = 4, colCldHn = 5, colCldName = 6, colCldPkg = 7, colCldMed = 8, colCldDtrfee = 9, colCldLab1 = 10, colCldLab2 = 11, colCldNurfee = 12, colCldTreat = 13, colCldDiscount = 14, colCldOther = 15, colCldAmount = 16, colCldVn=17, colCldBillId=18;

        C1FlexGrid grfQue, grfFinish, grfSearch, grfCld;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        Timer timer;
        Closeday cld;

        public FrmCashierView(IvfControl ic, MainMenu m)
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
            theme1.Theme = ic.iniC.themeApplication;
            theme1.SetTheme(sB, "BeigeOne");
            theme1.SetTheme(tC, "Office2010Blue");
            sB1.Text = "";
            bg = txtSearch.BackColor;
            fc = txtSearch.ForeColor;
            ff = txtSearch.Font;

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();

            cld = new Closeday();
            

            tC.SelectedTabChanged += TC_SelectedTabChanged;
            btnSearch.Click += BtnSearch_Click;
            btnSaveCld.Click += BtnSaveCld_Click;

            txtExp1.KeyUp += TxtExp1_KeyUp;
            txtExp2.KeyUp += TxtExp2_KeyUp;
            txtExp3.KeyUp += TxtExp3_KeyUp;
            txtExp4.KeyUp += TxtExp4_KeyUp;
            txtExp5.KeyUp += TxtExp5_KeyUp;
            txtDeposit.KeyUp += TxtDeposit_KeyUp;
            txtAmtCash.KeyUp += TxtAmtCash_KeyUp;
            txtAmtCredit.KeyUp += TxtAmtCredit_KeyUp;
            txtAmt.KeyUp += TxtAmt_KeyUp;

            txtCldDate.Value = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");

            initGrfQue();
            initGrfFinish();
            setGrfQue();
            setGrfFinish();
            initGrfSearch();
            setGrfSearch();
            initGrfCloseDay();

            int timerlab = 0;
            int.TryParse(ic.iniC.timerlabreqaccept, out timerlab);
            timer = new Timer();
            timer.Interval = timerlab * 1000;
            timer.Tick += Timer_Tick;
            timer.Enabled = true;
        }

        private void TxtAmt_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calTotalCash();
        }

        private void BtnSaveCld_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String date = "";
            date = DateTime.Now.ToString("dd/MM/") + DateTime.Now.Year;
            if (MessageBox.Show("ต้องการปิดวัน\n  ประจำวันที่ " + date + " " , "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                ic.cStf.staff_id = "";
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    FrmWaiting frmW = new FrmWaiting();
                    frmW.Show();

                    long chk = 0;
                    String re = "";
                    setCloseDay();
                    re = ic.ivfDB.cldDB.insertCloseday(cld, ic.cStf.staff_id);
                    if(long.TryParse(re, out chk))
                    {
                        if (txtCldId.Text.Equals(""))
                        {
                            txtCldId.Value = re;
                        }
                        foreach(Row row in grfCld.Rows)
                        {
                            if (row[colCldBillNo].ToString().Equals("Bill NO")) continue;
                            if (row[colCldId] == null) continue;
                            if (row[colCldBillId].ToString().Equals("")) continue;
                            ClosedayDetail cldd = new ClosedayDetail();
                            cldd.closeday_detail_id = row[colCldId] != null ? row[colCldId].ToString() : "";
                            cldd.closeday_id = txtCldId.Text;
                            cldd.bill_no = row[colCldBillNo] != null ? row[colCldBillNo].ToString() : "";
                            cldd.bill_date = row[colCldDate] != null ? row[colCldDate].ToString() : "";
                            cldd.patient_hn = row[colCldHn] != null ? row[colCldHn].ToString() : "";
                            cldd.patient_name = row[colCldName] != null ? row[colCldName].ToString() : "";
                            cldd.amt_package = row[colCldPkg] != null ? row[colCldPkg].ToString() : "0";
                            cldd.amt_medicine = row[colCldMed] != null ? row[colCldMed].ToString() : "0";
                            cldd.active = "";
                            cldd.remark = "";
                            cldd.date_create = "";
                            cldd.date_modi = "";
                            cldd.date_cancel = "";
                            cldd.user_create = "";
                            cldd.user_modi = "";
                            cldd.user_cancel = "";
                            cldd.amt_doctor_fee = row[colCldDtrfee] != null ? row[colCldDtrfee].ToString() : "0";
                            cldd.amt_lab_1 = row[colCldLab1] != null ? row[colCldLab1].ToString() : "0";
                            cldd.amt_lab_2 = row[colCldLab2] != null ? row[colCldLab2].ToString() : "0";
                            cldd.amt_nurse_fee = row[colCldNurfee] != null ? row[colCldNurfee].ToString() : "0";
                            cldd.amt_treatments = row[colCldTreat] != null ? row[colCldTreat].ToString() : "0";
                            cldd.discount = row[colCldDiscount] != null ? row[colCldDiscount].ToString() : "0";
                            cldd.amt_other = row[colCldOther] != null ? row[colCldOther].ToString() : "0";
                            cldd.amount = row[colCldAmount] != null ? row[colCldAmount].ToString() : "0";
                            cldd.bill_id = row[colCldBillId] != null ? row[colCldBillId].ToString() : "0" ;
                            String re1 = "";
                            re1 = ic.ivfDB.clddDB.insertClosedayDetail(cldd, ic.cStf.staff_id);
                        }
                    }
                    ic.ivfDB.obilhDB.updateCloseDayId(txtCldId.Text);
                    ic.ivfDB.obildDB.updateCloseDayId(txtCldId.Text);
                    ic.ivfDB.genCloseDayBill(txtCldId.Text);
                    frmW.Dispose();
                    MessageBox.Show("ปิดวัน" + date + " เรียบร้อย", "");
                }
            }
        }        
        private void setCloseDay()
        {
            cld.closeday_id = txtCldId.Text;
            cld.closeday_date = ic.datetoDB(txtCldDate.Text);
            cld.cnt_patient = txtCntPtt.Text;
            cld.amt_cash = txtAmtCash.Text;
            cld.amt_credit_card = txtAmtCredit.Text;
            cld.amount = txtAmt.Text;
            cld.expense_1 = txtExp1.Text;
            cld.expense_2 = txtExp2.Text;
            cld.active = "1";
            cld.remark = txtRemark.Text;
            cld.date_create = "";
            cld.date_modi = "";
            cld.date_cancel = "";
            cld.user_create = "";
            cld.user_modi = "";
            cld.user_cancel = "";
            cld.expense_3 = txtExp3.Text;
            cld.expense_4 = txtExp4.Text;
            cld.expense_5 = txtExp5.Text;
            cld.total_cash = txtTotalCash.Text;
            cld.deposit = txtDeposit.Text;
        }
        private void TxtAmtCredit_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calAmt();
            calTotalCash();
        }

        private void TxtAmtCash_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calAmt();
            calTotalCash();
        }

        private void TxtDeposit_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calTotalCash();
        }

        private void TxtExp5_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calTotalCash();
        }

        private void TxtExp4_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calTotalCash();
        }

        private void TxtExp3_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calTotalCash();
        }

        private void TxtExp2_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calTotalCash();
        }

        private void TxtExp1_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calTotalCash();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setGrfSearch();
        }
        private void TC_SelectedTabChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (tC.SelectedTab == tabFinish)
            {
                setGrfFinish();
            }
            else if (tC.SelectedTab == tabQue)
            {
                setGrfQue();
            }
            else if (tC.SelectedTab == tabCloseDay)
            {
                FrmWaiting frmW = new FrmWaiting();
                frmW.Show();

                setControlCld();
                setGrfCloseDay();

                frmW.Dispose();
            }
        }
        private void calAmt()
        {
            Decimal cash1 = 0, credit1 = 0, amt=0;
            Decimal.TryParse(txtAmtCash.Text.Replace(",", ""), out cash1);
            Decimal.TryParse(txtAmtCredit.Text.Replace(",", ""), out credit1);
            amt = cash1 + credit1;
            txtAmt.Value = amt.ToString("#,###.00");
        }
        private void calTotalCash()
        {
            Decimal cash1 = 0, credit1 = 0, amt = 0, exp1=0, exp2 = 0, exp3 = 0, exp4 = 0, exp5 = 0, deposit=0,total=0;
            Decimal.TryParse(txtAmtCash.Text.Replace(",",""), out cash1);
            Decimal.TryParse(txtAmtCredit.Text.Replace(",", ""), out credit1);
            Decimal.TryParse(txtAmt.Text.Replace(",", ""), out amt);
            Decimal.TryParse(txtExp5.Text.Replace(",", ""), out exp5);
            Decimal.TryParse(txtExp1.Text.Replace(",", ""), out exp1);
            Decimal.TryParse(txtExp2.Text.Replace(",", ""), out exp2);
            Decimal.TryParse(txtExp3.Text.Replace(",", ""), out exp3);
            Decimal.TryParse(txtExp4.Text.Replace(",", ""), out exp4);
            Decimal.TryParse(txtDeposit.Text.Replace(",", ""), out deposit);

            total = amt - exp1 - exp2 - exp3 - exp4 - exp5 + deposit;
            txtTotalCash.Value = total.ToString("#,###.00");
        }
        private void setControlCld()
        {
            String cntvs = "", cash="", credit="";
            Decimal cash1 = 0, credit1 = 0,amt=0;
            DataTable dt = new DataTable();
            cntvs = ic.ivfDB.vsDB.selectCloseDay();
            txtCntPtt.Value = cntvs;
            dt = ic.ivfDB.obilhDB.selectCashCloseDay();
            if (dt.Rows.Count > 0)
            {
                cash = dt.Rows[0]["cash"].ToString();
                credit = dt.Rows[0]["credit"].ToString();
            }
            Decimal.TryParse(cash, out cash1);
            Decimal.TryParse(credit, out credit1);
            txtAmtCash.Value = cash1.ToString("#,###.00");
            txtAmtCredit.Value = credit1.ToString("#,###.00");
            amt = cash1 + credit1;
            txtAmt.Value = amt.ToString("#,###.00");
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setGrfQue();
            //setGrfSearch(txtSearch.Text.Trim());
        }
        private void setGrfCloseDay()
        {
            //grfDept.Rows.Count = 7;
            grfCld.Clear();
            DataTable dt1 = new DataTable();
            DataTable dt = new DataTable();
            String date = "";

            dt = ic.ivfDB.obilhDB.selectByCloseDay();

            grfCld.Rows.Count = dt.Rows.Count + 1;
            grfCld.Cols.Count = 19;

            grfCld.Cols[colCldBillNo].Width = 100;
            grfCld.Cols[colCldReceiptNo].Width = 100;
            grfCld.Cols[colCldDate].Width = 120;
            grfCld.Cols[colCldHn].Width = 80;
            grfCld.Cols[colCldName].Width = 200;
            grfCld.Cols[colCldPkg].Width = 100;
            grfCld.Cols[colCldMed].Width = 100;
            grfCld.Cols[colCldDtrfee].Width = 100;
            grfCld.Cols[colCldLab1].Width = 100;
            grfCld.Cols[colCldLab2].Width = 100;
            grfCld.Cols[colCldNurfee].Width = 100;
            grfCld.Cols[colCldTreat].Width = 100;
            grfCld.Cols[colCldDiscount].Width = 100;
            grfCld.Cols[colCldOther].Width = 100;
            grfCld.Cols[colCldAmount].Width = 100;

            grfCld.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfCld.Cols[colCldBillNo].Caption = "Bill NO";
            grfCld.Cols[colCldReceiptNo].Caption = "Receipt NO";
            grfCld.Cols[colCldDate].Caption = "Date";
            grfCld.Cols[colCldHn].Caption = "HN";
            grfCld.Cols[colCldName].Caption = "Name";
            grfCld.Cols[colCldPkg].Caption = "Package";
            grfCld.Cols[colCldMed].Caption = "Medicine";
            grfCld.Cols[colCldDtrfee].Caption = "Doctor fee";
            grfCld.Cols[colCldLab1].Caption = "Lab 1";
            grfCld.Cols[colCldLab2].Caption = "Lab 2";
            grfCld.Cols[colCldNurfee].Caption = "Nuring fee";
            grfCld.Cols[colCldTreat].Caption = "Treatment";
            grfCld.Cols[colCldDiscount].Caption = "Discount";
            grfCld.Cols[colCldOther].Caption = "Other";
            grfCld.Cols[colCldAmount].Caption = "Total";

            //menuGw.MenuItems.Add("&receive operation", new EventHandler(ContextMenu_Apm));
            //menuGw.MenuItems.Add("receive operation", new EventHandler(ContextMenu_order));
            //menuGw.MenuItems.Add("&LAB request FORM A", new EventHandler(ContextMenu_LAB_req_formA_Ptt));
            //menuGw.MenuItems.Add("&Add Appointment", new EventHandler(ContextMenu_Apm_Ptt));
            //menuGw.MenuItems.Add("&Cancel Receive", new EventHandler(ContextMenu_Apm_Ptt));
            //menuGw.MenuItems.Add("&No Appointment Close Operation", new EventHandler(ContextMenu_NO_Apm_Ptt));
            //grfSearch.ContextMenu = menuGw;

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                String bilid = row[ic.ivfDB.obilhDB.obillh.bill_id].ToString();
                String amtpkg = "", amtmed="", amtdtrfee="", amtlab1="", amtlab2="", amtnurfee="", amttreat="", amtdiscount="",amtother="";
                Decimal amtpkg1 = 0, amtmed1 = 0, amtdtrfee1 = 0, amtlab11 = 0, amtlab21 = 0, amtnurfee1 = 0, amttreat1 = 0, amtdiscount1 = 0, amtother1 = 0, total=0;
                amtpkg = ic.ivfDB.obildDB.selectSumPriceByBilId(bilid, "0");
                Decimal.TryParse(amtpkg, out amtpkg1);

                amtmed = ic.ivfDB.obildDB.selectSumPriceByBilId(bilid, "1");
                Decimal.TryParse(amtmed, out amtmed1);

                amtdtrfee = ic.ivfDB.obildDB.selectSumPriceByBilId(bilid, "2");
                Decimal.TryParse(amtdtrfee, out amtdtrfee1);

                amtlab1 = ic.ivfDB.obildDB.selectSumPriceByBilId(bilid, "3");
                Decimal.TryParse(amtlab1, out amtlab11);

                amtlab2 = ic.ivfDB.obildDB.selectSumPriceByBilId(bilid, "4");
                Decimal.TryParse(amtlab2, out amtlab21);

                amtnurfee = ic.ivfDB.obildDB.selectSumPriceByBilId(bilid, "5");
                Decimal.TryParse(amtnurfee, out amtnurfee1);

                amttreat = ic.ivfDB.obildDB.selectSumPriceByBilId(bilid, "90");
                Decimal.TryParse(amttreat, out amttreat1);

                amtdiscount = ic.ivfDB.obildDB.selectSumPriceByBilId(bilid, "99");
                Decimal.TryParse(amtdiscount, out amtdiscount1);

                amtother = ic.ivfDB.obildDB.selectSumPriceByBilId(bilid, "99");
                Decimal.TryParse(amtother, out amtother1);

                total = amtpkg1 + amtmed1 + amtdtrfee1 + amtlab11 + amtlab21 + amtnurfee1 + amttreat1 + amtdiscount1 + amtother1;

                grfCld[i, 0] = i;
                grfCld[i, colCldId] = "";
                grfCld[i, colCldBillId] = row[ic.ivfDB.obilhDB.obillh.bill_id].ToString();
                grfCld[i, colCldBillNo] = row[ic.ivfDB.obilhDB.obillh.BillNo].ToString();
                grfCld[i, colCldReceiptNo] = row[ic.ivfDB.obilhDB.obillh.receipt_no].ToString();
                grfCld[i, colCldDate] = ic.datetoShow(row[ic.ivfDB.obilhDB.obillh.Date].ToString());
                grfCld[i, colCldHn] = row[ic.ivfDB.obilhDB.obillh.PIDS].ToString();
                grfCld[i, colCldName] = row[ic.ivfDB.obilhDB.obillh.PName].ToString();
                grfCld[i, colCldPkg] = amtpkg1.ToString("#,###.00");
                grfCld[i, colCldMed] = amtmed1.ToString("#,###.00");
                grfCld[i, colCldDtrfee] = amtdtrfee1.ToString("#,###.00");
                grfCld[i, colCldLab1] = amtlab11.ToString("#,###.00");
                grfCld[i, colCldLab2] = amtlab21.ToString("#,###.00");
                grfCld[i, colCldNurfee] = amtnurfee1.ToString("#,###.00");
                grfCld[i, colCldTreat] = amttreat1.ToString("#,###.00");
                grfCld[i, colCldDiscount] = amtdiscount1.ToString("#,###.00");
                grfCld[i, colCldOther] = amtother1.ToString("#,###.00");
                grfCld[i, colCldAmount] = total.ToString("#,###.00");
                //grfCld[i, colBillId] = "";
                //if (!row[ic.ivfDB.ovsDB.vsold.form_a_id].ToString().Equals("0"))
                //{
                //CellNote note = new CellNote("ส่ง Lab Request Foam A");
                //CellRange rg = grfFinish.GetCellRange(i, colVN);
                //rg.UserData = note;
                //}
                //if (i % 2 == 0)
                //    grfPtt.Rows[i].StyleNew.BackColor = color;
                i++;
            }
            CellNoteManager mgr = new CellNoteManager(grfSearch);
            grfCld.Cols[colCldId].Visible = false;
            grfCld.Cols[colCldBillId].Visible = false;
            //grfCld.Cols[colPttId].Visible = false;
            //grfCld.Cols[colBillId].Visible = false;
            //grfCld.Cols[colStatusNurse].Visible = false;
            //grfCld.Cols[colStatusCashier].Visible = false;

            grfCld.Cols[colCldBillNo].AllowEditing = false;
            grfCld.Cols[colCldReceiptNo].AllowEditing = false;
            grfCld.Cols[colCldDate].AllowEditing = false;
            grfCld.Cols[colCldHn].AllowEditing = false;
            grfCld.Cols[colCldName].AllowEditing = false;
            grfCld.Cols[colCldPkg].AllowEditing = false;
            grfCld.Cols[colCldMed].AllowEditing = false;
            grfCld.Cols[colCldDtrfee].AllowEditing = false;
            grfCld.Cols[colCldLab1].AllowEditing = false;
            grfCld.Cols[colCldLab2].AllowEditing = false;
            grfCld.Cols[colCldNurfee].AllowEditing = false;
            grfCld.Cols[colCldTreat].AllowEditing = false;
            grfCld.Cols[colCldDiscount].AllowEditing = false;
            grfCld.Cols[colCldOther].AllowEditing = false;
            grfCld.Cols[colCldAmount].AllowEditing = false;
            //theme1.SetTheme(grfQue, ic.theme);
        }
        private void initGrfCloseDay()
        {
            grfCld = new C1FlexGrid();
            grfCld.Font = fEdit;
            grfCld.Dock = System.Windows.Forms.DockStyle.Fill;
            grfCld.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            //grfQue.DoubleClick += GrfQue_DoubleClick;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            //ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("ออก บิล", new EventHandler(ContextMenu_edit_bill));
            ////menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            ////menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            //grfCld.ContextMenu = menuGw;
            pnCldDetail.Controls.Add(grfCld);

            theme1.SetTheme(grfCld, "Office2010Red");

            //theme1.SetTheme(tabDiag, "Office2010Blue");
            //theme1.SetTheme(tabFinish, "Office2010Blue");

        }
        private void initGrfSearch()
        {
            grfSearch = new C1FlexGrid();
            grfSearch.Font = fEdit;
            grfSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            grfSearch.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            grfSearch.DoubleClick += GrfSearch_DoubleClick;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            //ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("ออก บิล", new EventHandler(ContextMenu_edit_billSearch));
            //menuGw.MenuItems.Add("ส่งกลับ", new EventHandler(ContextMenu_send_back));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            //grfSearch.ContextMenu = menuGw;
            pnSearch.Controls.Add(grfSearch);

            theme1.SetTheme(grfSearch, "Office2010Red");

            //theme1.SetTheme(tabDiag, "Office2010Blue");
            //theme1.SetTheme(tabFinish, "Office2010Blue");
        }

        private void GrfSearch_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfSearch.Row <= 0) return;
            ContextMenu_edit_billSearch(null, null);
        }
        private void setGrfSearch()
        {
            //grfDept.Rows.Count = 7;
            grfSearch.Clear();
            DataTable dt1 = new DataTable();
            DataTable dt = new DataTable();
            String date = "";
            
            dt = ic.ivfDB.ovsDB.selectByStatusCashierSearch(txtSearch.Text, ic.datetoDB(txtDateStart.Text));
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
            menuGw.MenuItems.Add("ออก บิล", new EventHandler(ContextMenu_edit_billSearch));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfSearch.ContextMenu = menuGw;

            grfSearch.Rows.Count = dt.Rows.Count + 1;
            grfSearch.Cols.Count = 14;
            C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfSearch.Cols[colPttHn].Editor = txt;
            grfSearch.Cols[colPttName].Editor = txt;
            grfSearch.Cols[colVsDate].Editor = txt;

            grfSearch.Cols[colVNshow].Width = 80;
            grfSearch.Cols[colPttHn].Width = 120;
            grfSearch.Cols[colPttName].Width = 300;
            grfSearch.Cols[colVsDate].Width = 100;
            grfSearch.Cols[colVsTime].Width = 80;
            grfSearch.Cols[colVsEtime].Width = 80;
            grfSearch.Cols[colStatus].Width = 200;
            //grfSearch.Cols[colVsAgent].Width = 150;

            grfSearch.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfSearch.Cols[colVNshow].Caption = "VN";
            grfSearch.Cols[colPttHn].Caption = "HN";
            grfSearch.Cols[colPttName].Caption = "Name";
            grfSearch.Cols[colVsDate].Caption = "Date";
            grfSearch.Cols[colVsTime].Caption = "Time visit";
            grfSearch.Cols[colVsEtime].Caption = "Time finish";
            grfSearch.Cols[colStatus].Caption = "Status";
            grfSearch.Cols[colPttId].Caption = "colPttId";
            grfSearch.Cols[colStatusNurse].Caption = "colStatusNurse";
            grfSearch.Cols[colStatusCashier].Caption = "colStatusCashier";
            //grfSearch.Cols[colVsAgent].Caption = "Agent";

            //menuGw.MenuItems.Add("&receive operation", new EventHandler(ContextMenu_Apm));
            //menuGw.MenuItems.Add("receive operation", new EventHandler(ContextMenu_order));
            //menuGw.MenuItems.Add("&LAB request FORM A", new EventHandler(ContextMenu_LAB_req_formA_Ptt));
            //menuGw.MenuItems.Add("&Add Appointment", new EventHandler(ContextMenu_Apm_Ptt));
            //menuGw.MenuItems.Add("&Cancel Receive", new EventHandler(ContextMenu_Apm_Ptt));
            //menuGw.MenuItems.Add("&No Appointment Close Operation", new EventHandler(ContextMenu_NO_Apm_Ptt));
            //grfSearch.ContextMenu = menuGw;

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                grfSearch[i, 0] = i;
                grfSearch[i, colID] = row["id"].ToString();
                grfSearch[i, colVNshow] = ic.showVN(row["VN"].ToString());
                grfSearch[i, colVN] = row["VN"].ToString();
                grfSearch[i, colPttHn] = row["PIDS"].ToString();
                grfSearch[i, colPttName] = row["PName"].ToString();
                grfSearch[i, colVsDate] = ic.datetoShow(row["VDate"]);
                grfSearch[i, colVsTime] = row["VStartTime"].ToString();
                grfSearch[i, colVsEtime] = row["VEndTime"].ToString();
                grfSearch[i, colStatus] = row["VName"].ToString();
                grfSearch[i, colPttId] = row["PID"].ToString();
                grfSearch[i, colBillId] = "";
                if (!row[ic.ivfDB.ovsDB.vsold.form_a_id].ToString().Equals("0"))
                {
                    //CellNote note = new CellNote("ส่ง Lab Request Foam A");
                    //CellRange rg = grfFinish.GetCellRange(i, colVN);
                    //rg.UserData = note;
                }
                //if (i % 2 == 0)
                //    grfPtt.Rows[i].StyleNew.BackColor = color;
                i++;
            }
            CellNoteManager mgr = new CellNoteManager(grfSearch);
            grfSearch.Cols[colID].Visible = false;
            grfSearch.Cols[colVN].Visible = false;
            grfSearch.Cols[colPttId].Visible = false;
            grfSearch.Cols[colBillId].Visible = false;
            grfSearch.Cols[colStatusNurse].Visible = false;
            grfSearch.Cols[colStatusCashier].Visible = false;
            grfSearch.Cols[colVNshow].AllowEditing = false;
            grfSearch.Cols[colPttHn].AllowEditing = false;
            grfSearch.Cols[colPttName].AllowEditing = false;
            grfSearch.Cols[colVsDate].AllowEditing = false;
            grfSearch.Cols[colVsTime].AllowEditing = false;
            grfSearch.Cols[colVsEtime].AllowEditing = false;
            grfSearch.Cols[colStatus].AllowEditing = false;
            grfSearch.Cols[colVsAgent].AllowEditing = false;
            //theme1.SetTheme(grfQue, ic.theme);
        }
        private void initGrfFinish()
        {
            grfFinish = new C1FlexGrid();
            grfFinish.Font = fEdit;
            grfFinish.Dock = System.Windows.Forms.DockStyle.Fill;
            grfFinish.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            grfFinish.DoubleClick += GrfFinish_DoubleClick;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("ออก บิล", new EventHandler(ContextMenu_edit_billfinish));
            menuGw.MenuItems.Add("ส่งกลับ", new EventHandler(ContextMenu_send_back));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfFinish.ContextMenu = menuGw;
            pnFinish.Controls.Add(grfFinish);

            theme1.SetTheme(grfFinish, "Office2010Red");

            //theme1.SetTheme(tabDiag, "Office2010Blue");
            //theme1.SetTheme(tabFinish, "Office2010Blue");
        }
        private void GrfFinish_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfFinish.Row <= 0) return;
            ContextMenu_edit_billfinish(null, null);
        }

        public void setGrfFinishPublic()
        {
            setGrfFinish();
        }
        private void setGrfFinish()
        {
            //grfDept.Rows.Count = 7;
            grfFinish.Clear();
            DataTable dt1 = new DataTable();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.ovsDB.selectByStatusCashierFinish();
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
            menuGw.MenuItems.Add("ออก บิล", new EventHandler(ContextMenu_edit_billfinish));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfFinish.ContextMenu = menuGw;

            grfFinish.Rows.Count = dt.Rows.Count + 1;
            grfFinish.Cols.Count = 14;
            C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfFinish.Cols[colPttHn].Editor = txt;
            grfFinish.Cols[colPttName].Editor = txt;
            grfFinish.Cols[colVsDate].Editor = txt;

            grfFinish.Cols[colVNshow].Width = 80;
            grfFinish.Cols[colPttHn].Width = 120;
            grfFinish.Cols[colPttName].Width = 300;
            grfFinish.Cols[colVsDate].Width = 100;
            grfFinish.Cols[colVsTime].Width = 80;
            grfFinish.Cols[colVsEtime].Width = 80;
            grfFinish.Cols[colStatus].Width = 200;

            grfFinish.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfFinish.Cols[colVNshow].Caption = "VN";
            grfFinish.Cols[colPttHn].Caption = "HN";
            grfFinish.Cols[colPttName].Caption = "Name";
            grfFinish.Cols[colVsDate].Caption = "Date";
            grfFinish.Cols[colVsTime].Caption = "Time visit";
            grfFinish.Cols[colVsEtime].Caption = "Time finish";
            grfFinish.Cols[colStatus].Caption = "Status";
            grfFinish.Cols[colPttId].Caption = "colPttId";
            grfFinish.Cols[colStatusNurse].Caption = "colStatusNurse";
            grfFinish.Cols[colStatusCashier].Caption = "colStatusCashier";

            //menuGw.MenuItems.Add("&receive operation", new EventHandler(ContextMenu_Apm));
            //menuGw.MenuItems.Add("receive operation", new EventHandler(ContextMenu_order));
            //menuGw.MenuItems.Add("&LAB request FORM A", new EventHandler(ContextMenu_LAB_req_formA_Ptt));
            //menuGw.MenuItems.Add("&Add Appointment", new EventHandler(ContextMenu_Apm_Ptt));
            //menuGw.MenuItems.Add("&Cancel Receive", new EventHandler(ContextMenu_Apm_Ptt));
            //menuGw.MenuItems.Add("&No Appointment Close Operation", new EventHandler(ContextMenu_NO_Apm_Ptt));
            //grfFinish.ContextMenu = menuGw;

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                grfFinish[i, 0] = i;
                grfFinish[i, colID] = row["id"].ToString();
                grfFinish[i, colVNshow] = ic.showVN(row["VN"].ToString());
                grfFinish[i, colVN] = row["VN"].ToString();
                grfFinish[i, colPttHn] = row["PIDS"].ToString();
                grfFinish[i, colPttName] = row["PName"].ToString();
                grfFinish[i, colVsDate] = ic.datetoShow(row["VDate"]);
                grfFinish[i, colVsTime] = row["VStartTime"].ToString();
                grfFinish[i, colVsEtime] = row["VEndTime"].ToString();
                grfFinish[i, colStatus] = row["VName"].ToString();
                grfFinish[i, colPttId] = row["PID"].ToString();
                grfFinish[i, colBillId] = "";
                if (!row[ic.ivfDB.ovsDB.vsold.form_a_id].ToString().Equals("0"))
                {
                    CellNote note = new CellNote("ส่ง Lab Request Foam A");
                    CellRange rg = grfFinish.GetCellRange(i, colVN);
                    rg.UserData = note;
                }
                //if (i % 2 == 0)
                //    grfPtt.Rows[i].StyleNew.BackColor = color;
                i++;
            }
            CellNoteManager mgr = new CellNoteManager(grfFinish);
            grfFinish.Cols[colID].Visible = false;
            grfFinish.Cols[colVN].Visible = false;
            grfFinish.Cols[colPttId].Visible = false;
            grfFinish.Cols[colBillId].Visible = false;
            grfFinish.Cols[colStatusNurse].Visible = false;
            grfFinish.Cols[colStatusCashier].Visible = false;
            grfFinish.Cols[colVNshow].AllowEditing = false;
            grfFinish.Cols[colPttHn].AllowEditing = false;
            grfFinish.Cols[colPttName].AllowEditing = false;
            grfFinish.Cols[colVsDate].AllowEditing = false;
            grfFinish.Cols[colVsTime].AllowEditing = false;
            grfFinish.Cols[colVsEtime].AllowEditing = false;
            grfFinish.Cols[colStatus].AllowEditing = false;
            //theme1.SetTheme(grfQue, ic.theme);

        }
        private void initGrfQue()
        {
            grfQue = new C1FlexGrid();
            grfQue.Font = fEdit;
            grfQue.Dock = System.Windows.Forms.DockStyle.Fill;
            grfQue.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            grfQue.DoubleClick += GrfQue_DoubleClick;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("ออก บิล", new EventHandler(ContextMenu_edit_bill));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfQue.ContextMenu = menuGw;
            pnQue.Controls.Add(grfQue);

            theme1.SetTheme(grfQue, "Office2010Red");

            //theme1.SetTheme(tabDiag, "Office2010Blue");
            //theme1.SetTheme(tabFinish, "Office2010Blue");

        }

        private void GrfQue_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfQue.Row <= 0) return;
            ContextMenu_edit_bill(null, null);
        }

        private void ContextMenu_send_back(object sender, System.EventArgs e)
        {
            String chk = "", name = "", id = "";

        }
        private void ContextMenu_edit_billSearch(object sender, System.EventArgs e)
        {
            String billid = "", name = "", id = "";

            id = grfSearch[grfSearch.Row, colID] != null ? grfSearch[grfSearch.Row, colID].ToString() : "";
            name = grfSearch[grfSearch.Row, colPttName] != null ? grfSearch[grfSearch.Row, colPttName].ToString() : "";
            billid = grfSearch[grfSearch.Row, colPttName] != null ? grfSearch[grfSearch.Row, colPttName].ToString() : "";

            openBillNew(id, name, "noedit", billid);
        }
        private void ContextMenu_edit_billfinish(object sender, System.EventArgs e)
        {
            String billid = "", name = "", id = "";

            id = grfFinish[grfFinish.Row, colID] != null ? grfFinish[grfFinish.Row, colID].ToString() : "";
            name = grfFinish[grfFinish.Row, colPttName] != null ? grfFinish[grfFinish.Row, colPttName].ToString() : "";
            billid = grfFinish[grfFinish.Row, colPttName] != null ? grfFinish[grfFinish.Row, colPttName].ToString() : "";

            openBillNew(id, name, "noedit", billid);
        }
        private void ContextMenu_edit_bill(object sender, System.EventArgs e)
        {
            String chk = "", name = "", id = "", vn="";

            id = grfQue[grfQue.Row, colID] != null ? grfQue[grfQue.Row, colID].ToString() : "";
            vn = grfQue[grfQue.Row, colVN] != null ? grfQue[grfQue.Row, colVN].ToString() : "";
            name = grfQue[grfQue.Row, colPttName] != null ? grfQue[grfQue.Row, colPttName].ToString() : "";
            String billid = ic.getBillVN(id, ic.userId);
            openBillNew(id, name,"edit", billid);
        }
        public void setGrfQuePublic()
        {
            setGrfQue();
        }
        private void setGrfQue()
        {
            //grfDept.Rows.Count = 7;
            grfQue.Clear();
            DataTable dt1 = new DataTable();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.ovsDB.selectByStatusCashierWaiting1();
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
            //ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("ออก บิล", new EventHandler(ContextMenu_edit_bill));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            //grfQue.ContextMenu = menuGw;

            grfQue.Rows.Count = dt.Rows.Count + 1;
            grfQue.Cols.Count = 14;
            C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfQue.Cols[colPttHn].Editor = txt;
            grfQue.Cols[colPttName].Editor = txt;
            grfQue.Cols[colVsDate].Editor = txt;

            grfQue.Cols[colVN].Width = 80;
            grfQue.Cols[colPttHn].Width = 120;
            grfQue.Cols[colPttName].Width = 300;
            grfQue.Cols[colVsDate].Width = 100;
            grfQue.Cols[colVsTime].Width = 80;
            grfQue.Cols[colVsEtime].Width = 80;
            grfQue.Cols[colStatus].Width = 200;
            grfQue.Cols[colStatusNurse].Width = 50;
            grfQue.Cols[colStatusCashier].Width = 55;
            grfQue.Cols[colVsAgent].Width = 150;

            grfQue.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfQue.Cols[colVNshow].Caption = "VN";
            grfQue.Cols[colPttHn].Caption = "HN";
            grfQue.Cols[colPttName].Caption = "Name";
            grfQue.Cols[colVsDate].Caption = "Date";
            grfQue.Cols[colVsTime].Caption = "Time visit";
            grfQue.Cols[colVsEtime].Caption = "Time finish";
            grfQue.Cols[colStatus].Caption = "Status";
            grfQue.Cols[colStatusNurse].Caption = "Nurse";
            grfQue.Cols[colStatusCashier].Caption = "Cashier";
            grfQue.Cols[colVsAgent].Caption = "Agent";

            //menuGw.MenuItems.Add("&receive operation", new EventHandler(ContextMenu_Apm));
            //menuGw.MenuItems.Add("receive operation", new EventHandler(ContextMenu_order));
            //menuGw.MenuItems.Add("&LAB request FORM A", new EventHandler(ContextMenu_LAB_req_formA_Ptt));
            //menuGw.MenuItems.Add("&Add Appointment", new EventHandler(ContextMenu_Apm_Ptt));
            //menuGw.MenuItems.Add("&Cancel Receive", new EventHandler(ContextMenu_Apm_Ptt));
            //menuGw.MenuItems.Add("&No Appointment Close Operation", new EventHandler(ContextMenu_NO_Apm_Ptt));
            //grfQue.ContextMenu = menuGw;

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                grfQue[i, 0] = i;
                grfQue[i, colID] = row["id"].ToString();
                grfQue[i, colVNshow] = ic.showVN(row["VN"].ToString());
                grfQue[i, colVN] = row["VN"].ToString();
                grfQue[i, colPttHn] = row["PIDS"].ToString();
                grfQue[i, colPttName] = row["PName"].ToString();
                grfQue[i, colVsDate] = ic.datetoShow(row["VDate"]);
                grfQue[i, colVsTime] = row["VStartTime"].ToString();
                grfQue[i, colVsEtime] = row["VEndTime"].ToString();
                grfQue[i, colStatus] = row["VName"].ToString();
                grfQue[i, colPttId] = row["PID"].ToString();
                grfQue[i, colVsAgent] = row["agent"].ToString();
                grfQue[i, colBillId] = "";
                //grfQue[i, colStatusNurse] = row["status_nurse"] != null ? row["status_nurse"].ToString() : "";
                //grfQue[i, colStatusCashier] = row["status_cashier"] != null ? row["status_cashier"].ToString() : "";
                //if (!row[ic.ivfDB.ovsDB.vsold.form_a_id].ToString().Equals("0"))
                //{
                //    CellNote note = new CellNote("ส่ง Lab Request Foam A");
                //    CellRange rg = grfQue.GetCellRange(i, colVN);
                //    rg.UserData = note;
                //}
                //if (i % 2 == 0)
                //    grfPtt.Rows[i].StyleNew.BackColor = color;
                i++;
            }
            CellNoteManager mgr = new CellNoteManager(grfQue);
            grfQue.Cols[colID].Visible = false;
            grfQue.Cols[colVN].Visible = false;
            grfQue.Cols[colBillId].Visible = false;
            grfQue.Cols[colVNshow].AllowEditing = false;
            grfQue.Cols[colPttHn].AllowEditing = false;
            grfQue.Cols[colPttName].AllowEditing = false;
            grfQue.Cols[colVsDate].AllowEditing = false;
            grfQue.Cols[colVsTime].AllowEditing = false;
            grfQue.Cols[colVsEtime].AllowEditing = false;
            grfQue.Cols[colStatus].AllowEditing = false;
            //theme1.SetTheme(grfQue, ic.theme);

        }
        private void openBillNew(String vnold, String name, String flag, String billid)
        {
            FrmCashierAdd frm = new FrmCashierAdd(ic, menu, billid, vnold, flag);
            frm.FormBorderStyle = FormBorderStyle.None;
            C1DockingTabPage tab = menu.AddNewTab(frm, name);
            frm.tab = tab;
            frm.frmCashView = this;
        }
        private void FrmCashierView_Load(object sender, EventArgs e)
        {
            spCloseDay.HeaderHeight = 0;
        }
    }
}
