using C1.C1Excel;
using C1.Win.C1Command;
using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1SuperTooltip;
using clinic_ivf.control;
using clinic_ivf.object1;
using clinic_ivf.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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

        int colID = 1, colVNshow = 2, colVN = 12, colPttHn = 3, colPttName = 4, colVsDate = 5, colVsTime = 6, colVsEtime = 7, colVsAgent=8, colStatus = 9, colPttId = 10, colStatusNurse = 11, colStatusCashier = 12, colBillId=13, colAgentId=14;
        int colCldId = 1, colCldBillNo = 2, colCldReceiptNo = 3, colCldDate = 4, colCldHn = 5, colCldName = 6, colCldPkg1 = 7, colCldPkg2 = 8, colCldPkg3 = 9, colCldPkg4 = 10, colCldPkg5 = 11, colCldPkg6 = 12, colCldPkgFreezing = 13, colCldPkgOther=14, colCldDiscount = 15;
        int colCldExtraDay6 = 16, colCldLabAll = 17, colCldLabBlood = 18, colCldMedInc = 19, colCldMedExtra=20, colCldTVS = 21, colCldDtrfee = 22, colCldEquipment = 23, colCldOtherService = 24;
        int colCldAmount = 25, colCldAmount1 = 26, colCldInc=27, colCldExt=28, colCldVn =29, colCldBillId=30;
        int colBildId = 1, colBildName = 2, colBildprice = 3, colBildqty = 4, colBildAmt = 5, colBildDiscount = 6, colBildNetAmt = 7, colBildGrpName = 8, colBildBilId = 9, colBildInclude = 10, colBildStatus = 11, colBildItmId=12;
        int colRptId = 1, colRptVnShow = 2, colRptVn = 3, colRptHn = 4, colRptPttName = 5, colRptVsDate = 6, colRptDOB = 7, colRptFormACode = 8, colRptOPU = 9, colRptFET = 10, colRptSpermAna = 11, colRptSpermFreezing = 12, colRptSpermIUI = 13, colRptSpermPESA = 14, colRptName_1 = 15, colRptName_2 = 16, colRptDtr = 17, colRptAgent = 18;

        C1FlexGrid grfQue, grfFinish, grfSearch, grfCld, grfBilD, grfRptCri, grfRpt;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        C1DateEdit txtRptDateStart1;
        C1DateEdit txtRptDateEnd1;
        Timer timer;
        Closeday cld;
        Image imgCorr, imgTran, imgFinish;
        Form frmRpt;
        String rptid = "";

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
            frmRpt = new Form();

            cld = new Closeday();
            imgCorr = Resources.red_checkmark_png_16;
            imgTran = Resources.red_checkmark_png_51;
            imgFinish = Resources.OK_24;
            cboRpt = ic.setCboCldReport(cboRpt);

            tC.SelectedTabChanged += TC_SelectedTabChanged;
            btnSearch.Click += BtnSearch_Click;
            btnSaveCld.Click += BtnSaveCld_Click;
            btnRptOk.Click += BtnRptOk_Click;
            btnExcel.Click += BtnExcel_Click;
            btnRpt.Click += BtnRpt_Click;

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
            txtRptDateStart.Value = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            txtRptDateEnd.Value = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");

            initGrfQue();
            initGrfFinish();
            setGrfQue();
            setGrfFinish();
            initGrfSearch();
            setGrfSearch();
            initGrfCloseDay();
            initGrfBillD();
            initGrfRpt();
            setGrfRpt();
            setHideRptCri();
            initGrfRptView();
            createFrmRpt01();
            int timerlab = 0;
            int.TryParse(ic.iniC.timerlabreqaccept, out timerlab);
            timer = new Timer();
            timer.Interval = timerlab * 1000;
            timer.Tick += Timer_Tick;
            timer.Enabled = true;
        }
        private void createFrmRpt01()
        {
            Size size = new Size();
            txtRptDateStart1 = new C1DateEdit();
            txtRptDateEnd1 = new C1DateEdit();

            frmRpt.WindowState = FormWindowState.Normal;
            frmRpt.StartPosition = FormStartPosition.CenterScreen;
            frmRpt.Size = new Size(600, 400);
            Panel pn = new Panel();
            pn.Dock = DockStyle.Fill;
            frmRpt.Controls.Add(pn);
            int gapx = 10, gapy = 10;

            Label lbRptDateStart = new Label();
            Label lbRptDateEnd = new Label();
            C1Button btnRptPrint = new C1Button();

            txtRptDateStart1.Font = fEdit;
            txtRptDateEnd1.Font = fEdit;
            txtRptDateStart1.DateTimeInput = false;
            txtRptDateEnd1.DateTimeInput = false;
            txtRptDateStart1.CurrentTimeZone = false;
            txtRptDateEnd1.CurrentTimeZone = false;
            txtRptDateStart1.DisplayFormat.FormatType = FormatTypeEnum.ShortDate;
            txtRptDateEnd1.DisplayFormat.FormatType = FormatTypeEnum.ShortDate;
            txtRptDateStart1.DisplayFormat.CalendarType = C1.Win.C1Input.CalendarType.GregorianCalendar;
            txtRptDateEnd1.DisplayFormat.CalendarType = C1.Win.C1Input.CalendarType.GregorianCalendar;
            txtRptDateStart1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate;
            txtRptDateEnd1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate;
            txtRptDateStart1.EditFormat.CalendarType = C1.Win.C1Input.CalendarType.GregorianCalendar;
            txtRptDateEnd1.EditFormat.CalendarType = C1.Win.C1Input.CalendarType.GregorianCalendar;
            txtRptDateStart1.Size = new System.Drawing.Size(133, 18);
            txtRptDateEnd1.Size = new System.Drawing.Size(133, 18);
            txtRptDateStart1.EmptyAsNull = true;
            txtRptDateEnd1.EmptyAsNull = true;
            txtRptDateStart1.AllowSpinLoop = false;
            txtRptDateEnd1.AllowSpinLoop = false;
            txtRptDateStart1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtRptDateEnd1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtRptDateStart1.Calendar.ArrowColor = System.Drawing.Color.Black;
            txtRptDateEnd1.Calendar.ArrowColor = System.Drawing.Color.Black;

            txtRptDateStart1.Name = "txtRptDateStart";
            txtRptDateStart1.Size = new System.Drawing.Size(133, 18);
            txtRptDateStart1.TabIndex = 510;
            txtRptDateStart1.Tag = null;
            theme1.SetTheme(this.txtRptDateStart1, "(default)");
            txtRptDateStart1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;


            txtRptDateStart1.Value = DateTime.Now;
            txtRptDateEnd1.Value = DateTime.Now;

            lbRptDateStart.Font = fEdit;
            lbRptDateEnd.Font = fEdit;

            txtRptDateEnd1.Location = new Point(gapx, gapy);
            lbRptDateStart.Location = new Point(gapx, gapy);

            lbRptDateStart.Text = "Start Date";
            size = ic.MeasureString(lbRptDateStart);
            txtRptDateStart1.Location = new Point(gapx + size.Width + 10, gapy);
            lbRptDateEnd.Text = "End Date";
            lbRptDateEnd.Location = new Point(txtRptDateStart1.Location.X + txtRptDateStart1.Width + 10, gapy);
            size = ic.MeasureString(lbRptDateEnd);
            txtRptDateEnd1.Location = new Point(gapx + lbRptDateEnd.Location.X + size.Width + 10, gapy);
            btnRptPrint.Text = "Print";
            btnRptPrint.Font = fEdit;
            btnRptPrint.Size = new Size(200, 60);
            btnRptPrint.Location = new Point(gapx + lbRptDateEnd.Location.X + size.Width + 10, gapy + 30);
            btnRptPrint.Click += BtnRptPrint_Click;

            pn.Controls.Add(txtRptDateStart1);
            pn.Controls.Add(txtRptDateEnd1);
            pn.Controls.Add(lbRptDateStart);
            pn.Controls.Add(lbRptDateEnd);
            pn.Controls.Add(btnRptPrint);
        }
        private void BtnRpt_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String rpt = "";
            rpt = cboRpt.SelectedItem != null ? cboRpt.SelectedItem.ToString() : "";
            if (rpt.Equals("BillDetailExcel"))
            {
                frmRpt.ShowDialog(this);
            }
        }

        private void BtnRptPrint_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.DefaultExt = "xls";
            dlg.Filter = "Excel |*.xls";
            dlg.InitialDirectory = ic.iniC.pathSaveExcelAppointment;
            dlg.FileName = "*.xls";
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            // clear book
            C1XLBook _book = new C1XLBook();
            String rpt = "", datestart="", dateend="", filename="";
            DataTable dt = new DataTable();
            //txtRptDateStart.Value = DateTime.Now;
            //txtRptDateEnd.Value = DateTime.Now;
            datestart = ic.datetoDB(txtRptDateStart1.Text); 
            dateend = ic.datetoDB(txtRptDateEnd1.Text);
            rpt = cboRpt.SelectedItem != null ? cboRpt.SelectedItem.ToString() : "";
            if (rpt.Equals("BillDetailExcel"))
            {
                dt = ic.ivfDB.obildDB.selectByDate(datestart, dateend);
                filename = "billdetail-"+ datestart+"-"+ dateend;
            }
            XLSheet sheet = _book.Sheets.Add(datestart+"-"+ dateend);
            ic.SaveSheetDataTable(dt, sheet, _book, false);
            //ic.SaveSheet(grfCld, sheet, _book, false);
            //}

            // save selected sheet index
            _book.Sheets.SelectedIndex = 0;

            // save the book
            _book.Save(dlg.FileName);
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.DefaultExt = "xls";
            dlg.FileName = "*.xls";
            dlg.Filter = "Excel Files | *.xls";
            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            // save grid as sheet in the book
            FileFlags flags = FileFlags.IncludeFixedCells;
            grfRpt.SaveGrid(dlg.FileName, FileFormatEnum.Excel, flags);
        }

        private void BtnRptOk_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (rptid.Equals("rptcashier001"))
            {
                setGrfRpt001();
            }
            else if (rptid.Equals("rptcashier002"))
            {
                setGrfRpt002();
            }
            else if (rptid.Equals("rptcashier003"))
            {
                setGrfRpt003();
            }
            else if (rptid.Equals("rptcashier004"))
            {
                setGrfRpt004();
            }
        }
        private void setGrfRpt004()
        {
            String rpt = "", dateStart = "", dateEnd = "";
            dateStart = ic.datetoDB(txtRptDateStart.Text);
            dateEnd = ic.datetoDB(txtRptDateEnd.Text);
            DataTable dt = new DataTable();

            //grfRpt.Clear();
            grfRpt.Rows.Count = 1;
            dt = ic.ivfDB.obilhDB.selectByDate(dateStart, dateEnd);

            //grfRpt.DataSource = dt;
            int colDate = 1, colHn = 2, colVn = 3, colName=4, colReceiptNo = 5, colNettotal = 6, colAccType = 7, colAccName = 8, colAgentName=9, colAgentId=10, colAccId=11, colBillId=12, colCash=13, colCredit=14;
            grfRpt.Rows.Count = dt.Rows.Count + 1;
            grfRpt.Cols.Count = 15;

            grfRpt.Cols[colDate].Width = 100;
            grfRpt.Cols[colHn].Width = 110;
            grfRpt.Cols[colVn].Width = 110;
            grfRpt.Cols[colName].Width = 200;
            grfRpt.Cols[colReceiptNo].Width = 120;
            grfRpt.Cols[colNettotal].Width = 120;
            grfRpt.Cols[colAccType].Width = 85;
            grfRpt.Cols[colAccName].Width = 200;
            grfRpt.Cols[colAgentName].Width = 200;
            grfRpt.Cols[colCash].Width = 120;
            grfRpt.Cols[colCredit].Width = 120;
            grfRpt.Cols[colDate].Caption = "Date";
            grfRpt.Cols[colHn].Caption = "HN";
            grfRpt.Cols[colVn].Caption = "VN";
            grfRpt.Cols[colName].Caption = "Name";
            grfRpt.Cols[colReceiptNo].Caption = "Receip no";
            grfRpt.Cols[colNettotal].Caption = "Total";
            grfRpt.Cols[colAccType].Caption = "Type";
            grfRpt.Cols[colAccName].Caption = "Acc Name";
            grfRpt.Cols[colAgentName].Caption = "Agent";
            grfRpt.Cols[colCash].Caption = "Cash";
            grfRpt.Cols[colCredit].Caption = "Credit";
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                String cash = "", credit = "";
                Decimal cash1 = 0, credit1 = 0;
                cash = row["cash"].ToString();
                credit = row["credit"].ToString();
                Decimal.TryParse(cash, out cash1);
                Decimal.TryParse(credit, out credit1);

                grfRpt[i, 0] = i;
                grfRpt[i, colBillId] = row["bill_id"].ToString();
                grfRpt[i, colName] = row["Pname"].ToString();
                grfRpt[i, colDate] = ic.datetoShow(row["Date"].ToString());
                grfRpt[i, colHn] = row["PIDS"].ToString();
                grfRpt[i, colVn] = row["VN"].ToString();
                grfRpt[i, colReceiptNo] = row["receipt_no"].ToString();
                grfRpt[i, colNettotal] = row["Total"].ToString();
                if ((cash1 > 0) && (credit1 > 0))
                {
                    grfRpt[i, colAccType] = "Cash/Credit";
                    grfRpt[i, colAccName] = row["CashName"].ToString()+"/"+ row["CreditName"].ToString();
                    grfRpt[i, colAccId] = row["CashID"].ToString()+","+ row["CreditCardID"].ToString();
                }
                else if ((cash1 == 0) && (credit1 == 0))
                {
                    grfRpt[i, colAccType] = "";
                    grfRpt[i, colAccName] = "";
                    grfRpt[i, colAccId] = "";
                }
                else
                {
                    if (cash1 > 0)
                    {
                        grfRpt[i, colAccType] = "Cash";
                        grfRpt[i, colAccName] = row["CashName"].ToString();
                        grfRpt[i, colAccId] = row["CashID"].ToString();
                    }
                    else
                    {
                        grfRpt[i, colAccType] = "Credit";
                        grfRpt[i, colAccName] = row["CreditName"].ToString();
                        grfRpt[i, colAccId] = row["CreditCardID"].ToString();
                    }
                }
                
                
                grfRpt[i, colAgentName] = row["AgentName"].ToString();
                grfRpt[i, colAgentId] = row["agent_id"].ToString();
                grfRpt[i, colCash] = row["cash"].ToString();
                grfRpt[i, colCredit] = row["credit"].ToString();

                i++;
            }
            grfRpt.Cols[colAgentId].Visible = false;
            grfRpt.Cols[colAccId].Visible = false;
            grfRpt.Cols[colBillId].Visible = false;
            //grfRpt.Cols[colBillId].Visible = false;
            grfRpt.Cols[colDate].AllowEditing = false;
            grfRpt.Cols[colHn].AllowEditing = false;
            grfRpt.Cols[colVn].AllowEditing = false;
            grfRpt.Cols[colReceiptNo].AllowEditing = false;
            grfRpt.Cols[colNettotal].AllowEditing = false;
            grfRpt.Cols[colAccType].AllowEditing = false;
            grfRpt.Cols[colAccName].AllowEditing = false;
            grfRpt.Cols[colAgentName].AllowEditing = false;
            grfRpt.Cols[colCash].AllowEditing = false;
            grfRpt.Cols[colCredit].AllowEditing = false;
        }
        private void setGrfRpt003()
        {
            String rpt = "", dateStart = "", dateEnd = "";
            dateStart = ic.datetoDB(txtRptDateStart.Text);
            dateEnd = ic.datetoDB(txtRptDateEnd.Text);

            DataTable dt = new DataTable();
            DataTable dtCa = new DataTable();
            DataTable dtCr = new DataTable();
            //grfRpt.Clear();
            dtCa = ic.ivfDB.ocaDB.selectAll();
            dtCr = ic.ivfDB.ocrDB.selectAll();

            dt.Columns.Add("acc_id", typeof(String));
            dt.Columns.Add("acc_name", typeof(String));
            dt.Columns.Add("nettoal", typeof(String));
            foreach(DataRow drow in dtCa.Rows)
            {
                DataRow rowDt = dt.Rows.Add();
                rowDt["acc_id"] = drow[ic.ivfDB.ocaDB.oca.CashID].ToString();
                rowDt["acc_name"] = drow[ic.ivfDB.ocaDB.oca.CashName].ToString();
            }
            foreach (DataRow drow in dtCr.Rows)
            {
                DataRow rowDt = dt.Rows.Add();
                rowDt["acc_id"] = drow[ic.ivfDB.ocrDB.occa.CreditCardID].ToString();
                rowDt["acc_name"] = drow[ic.ivfDB.ocrDB.occa.CreditCardName].ToString();
            }
            grfRpt.DataSource = dt;
        }
        private void setGrfRpt002()
        {
            String rpt = "", dateStart = "", dateEnd = "";
            int cntCash = 0, cntCredit = 0;
            dateStart = ic.datetoDB(txtRptDateStart.Text);
            dateEnd = ic.datetoDB(txtRptDateEnd.Text);
            //grfRpt.Clear();
            grfRpt.Rows.Count = 1;
            grfRpt.Cols.Count = 4;
            grfRpt.Cols[1].Caption = "Date";
            grfRpt.Cols[2].Caption = "HN";
            grfRpt.Cols[3].Caption = "Name";
            grfRpt.Cols[1].AllowEditing = false;
            grfRpt.Cols[2].AllowEditing = false;
            grfRpt.Cols[3].AllowEditing = false;
            DataTable dt = new DataTable();
            dt = ic.ivfDB.ocaDB.selectByCashCardName();
            cntCash = dt.Rows.Count;
            foreach (DataRow row in dt.Rows)
            {
                Column col = grfRpt.Cols.Add();
                col.Caption = row["CashName"].ToString();
                col.AllowEditing = false;
            }
            dt = ic.ivfDB.ocrDB.selectByCreditCardName1();
            cntCredit = dt.Rows.Count;
            foreach (DataRow row in dt.Rows)
            {
                Column col = grfRpt.Cols.Add();
                col.Caption = row["CreditCardName"].ToString();
                col.AllowEditing = false;
            }
            
            grfRpt.Refresh();
            grfRpt.AutoSizeCols();
            dt = ic.ivfDB.obilhDB.selectByDate(dateStart, dateEnd);
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                grfRpt[i, 1] = ic.datetoShow(row["Date"].ToString());
                grfRpt[i, 2] = row["PIDS"].ToString();
                grfRpt[i, 3] = row["PName"].ToString();
                

            }
        }
        private void setGrfRpt001()
        {
            String rpt = "", dateStart = "", dateEnd = "";
            //rpt = cboRpt.SelectedItem != null ? ((ComboBoxItem)cboRpt.SelectedItem).Value : "";
            //if (rpt.Equals(""))
            //{
            //    MessageBox.Show("ไม่พบ ชื่อ Report", "");
            //}
            dateStart = ic.datetoDB(txtRptDateStart.Text);
            dateEnd = ic.datetoDB(txtRptDateEnd.Text);
            grfRpt.Clear();
            grfRpt.Cols.Count = 19;
            DataTable dt = new DataTable();
            dt = ic.ivfDB.vsDB.selectByRpt(dateStart, dateEnd);
            Column colOPU = grfRpt.Cols[colRptOPU];
            colOPU.DataType = typeof(Image);
            Column colFET = grfRpt.Cols[colRptFET];
            colFET.DataType = typeof(Image);
            Column colAna = grfRpt.Cols[colRptSpermAna];
            colAna.DataType = typeof(Image);
            Column colFreez = grfRpt.Cols[colRptSpermFreezing];
            colFreez.DataType = typeof(Image);
            Column colIUI = grfRpt.Cols[colRptSpermIUI];
            colIUI.DataType = typeof(Image);
            Column colPESA = grfRpt.Cols[colRptSpermPESA];
            colPESA.DataType = typeof(Image);
            //Column colCashier = grfRpt.Cols[colRptOPU];
            //colCashier.DataType = typeof(Image);

            grfRpt.Rows.Count = 1;
            grfRpt.Rows.Count = dt.Rows.Count + 1;

            grfRpt.Cols[colRptVnShow].Width = 80;
            grfRpt.Cols[colRptHn].Width = 120;
            grfRpt.Cols[colRptPttName].Width = 280;
            grfRpt.Cols[colRptVsDate].Width = 100;
            grfRpt.Cols[colRptDOB].Width = 100;
            grfRpt.Cols[colRptFormACode].Width = 80;
            grfRpt.Cols[colRptOPU].Width = 80;
            grfRpt.Cols[colRptFET].Width = 80;
            grfRpt.Cols[colRptSpermAna].Width = 80;
            grfRpt.Cols[colRptSpermFreezing].Width = 80;
            grfRpt.Cols[colRptSpermIUI].Width = 80;
            grfRpt.Cols[colRptSpermPESA].Width = 80;
            grfRpt.Cols[colRptName_1].Width = 80;
            grfRpt.Cols[colRptName_2].Width = 80;
            grfRpt.Cols[colRptDtr].Width = 80;
            grfRpt.Cols[colRptAgent].Width = 80;
            //grfRpt.Cols[colVNshow].Width = 80;

            grfRpt.Cols[colRptVnShow].Caption = "VN";
            grfRpt.Cols[colRptHn].Caption = "HN";
            grfRpt.Cols[colRptPttName].Caption = "Patient Name";
            grfRpt.Cols[colRptVsDate].Caption = "Date";
            grfRpt.Cols[colRptDOB].Caption = "DOB";
            grfRpt.Cols[colRptFormACode].Caption = "code";
            grfRpt.Cols[colRptOPU].Caption = "OPU";
            grfRpt.Cols[colRptFET].Caption = "FET";
            grfRpt.Cols[colRptSpermAna].Caption = "Sperm.A";
            grfRpt.Cols[colRptSpermFreezing].Caption = "Sperm.F";
            grfRpt.Cols[colRptSpermIUI].Caption = "Sperm.IUI";
            grfRpt.Cols[colRptSpermPESA].Caption = "Sperm.PESA";
            grfRpt.Cols[colRptName_1].Caption = "Name_1";
            grfRpt.Cols[colRptName_2].Caption = "Name_2";
            grfRpt.Cols[colRptDtr].Caption = "Doctor";
            grfRpt.Cols[colRptAgent].Caption = "Agent";

            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    grfRpt[i, 0] = i;
                    grfRpt[i, colRptId] = row["t_visit_id"].ToString();
                    grfRpt[i, colRptVn] = row["visit_vn"].ToString();
                    grfRpt[i, colRptVnShow] = ic.showVN(row["visit_vn"].ToString());
                    grfRpt[i, colRptHn] = row["visit_hn"].ToString();
                    grfRpt[i, colRptPttName] = row["ptt_name"].ToString();
                    grfRpt[i, colRptVsDate] = ic.datetoShow(row["visit_begin_visit_time"].ToString());
                    grfRpt[i, colRptDOB] = ic.datetoShow(row["patient_birthday"].ToString());
                    grfRpt[i, colRptFormACode] = row["form_a_code"].ToString();
                    grfRpt[i, colRptOPU] = row["status_opu_active"].ToString().Equals("1") ? imgFinish : imgTran;
                    grfRpt[i, colRptFET] = row["status_fet_active"].ToString().Equals("1") ? imgFinish : imgTran;
                    grfRpt[i, colRptSpermAna] = row["status_sperm_analysis"].ToString().Equals("1") ? imgFinish : imgTran;
                    grfRpt[i, colRptSpermFreezing] = row["status_sperm_freezing"].ToString().Equals("1") ? imgFinish : imgTran;
                    grfRpt[i, colRptSpermIUI] = row["status_sperm_iui"].ToString().Equals("1") ? imgFinish : imgTran;
                    grfRpt[i, colRptSpermPESA] = row["status_sperm_pesa"].ToString().Equals("1") ? imgFinish : imgTran;
                    grfRpt[i, colRptName_1] = row["name_1"].ToString();
                    grfRpt[i, colRptName_2] = row["name_2"].ToString();
                    grfRpt[i, colRptDtr] = row["dtr_name"].ToString();
                    grfRpt[i, colRptAgent] = row["AgentName"].ToString();
                    i++;
                }
                catch (Exception ex)
                {

                }
            }
            grfRpt.Cols[colRptId].Visible = false;
            grfRpt.Cols[colRptVn].Visible = false;
            grfRpt.Cols[colRptVnShow].AllowEditing = false;
            grfRpt.Cols[colRptHn].AllowEditing = false;
            grfRpt.Cols[colRptPttName].AllowEditing = false;
            grfRpt.Cols[colRptVsDate].AllowEditing = false;
            grfRpt.Cols[colRptDOB].AllowEditing = false;
            grfRpt.Cols[colRptFormACode].AllowEditing = false;
            grfRpt.Cols[colRptOPU].AllowEditing = false;
            grfRpt.Cols[colRptFET].AllowEditing = false;
            grfRpt.Cols[colRptSpermAna].AllowEditing = false;
            grfRpt.Cols[colRptSpermFreezing].AllowEditing = false;
            grfRpt.Cols[colRptSpermIUI].AllowEditing = false;
            grfRpt.Cols[colRptSpermPESA].AllowEditing = false;
            grfRpt.Cols[colRptName_1].AllowEditing = false;
            grfRpt.Cols[colRptName_2].AllowEditing = false;
            grfRpt.Cols[colRptDtr].AllowEditing = false;
            grfRpt.Cols[colRptAgent].AllowEditing = false;
            grfRpt.AutoSizeRows();
            //grfRpt.Cols[colVNshow].AllowEditing = false;
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
                            cldd.amt_package = row[colCldPkg1] != null ? row[colCldPkg1].ToString() : "0";
                            cldd.amt_medicine = row[colCldMedInc] != null ? row[colCldMedInc].ToString() : "0";
                            cldd.active = "";
                            cldd.remark = "";
                            cldd.date_create = "";
                            cldd.date_modi = "";
                            cldd.date_cancel = "";
                            cldd.user_create = "";
                            cldd.user_modi = "";
                            cldd.user_cancel = "";
                            cldd.amt_doctor_fee = row[colCldDtrfee] != null ? row[colCldDtrfee].ToString() : "0";
                            cldd.amt_lab_1 = row[colCldLabAll] != null ? row[colCldLabAll].ToString() : "0";
                            cldd.amt_lab_2 = row[colCldLabBlood] != null ? row[colCldLabBlood].ToString() : "0";
                            //cldd.amt_nurse_fee = row[colCldNurfee] != null ? row[colCldNurfee].ToString() : "0";
                            //cldd.amt_treatments = row[colCldTreat] != null ? row[colCldTreat].ToString() : "0";
                            cldd.discount = row[colCldDiscount] != null ? row[colCldDiscount].ToString() : "0";
                            cldd.amt_other = row[colCldOtherService] != null ? row[colCldOtherService].ToString() : "0";
                            cldd.amount = row[colCldAmount] != null ? row[colCldAmount].ToString() : "0";
                            cldd.bill_id = row[colCldBillId] != null ? row[colCldBillId].ToString() : "0" ;
                            String re1 = "";
                            re1 = ic.ivfDB.clddDB.insertClosedayDetail(cldd, ic.cStf.staff_id);
                        }
                    }
                    ic.ivfDB.obilhDB.updateCloseDayId(txtCldId.Text);
                    ic.ivfDB.obildDB.updateCloseDayId(txtCldId.Text);
                    ic.ivfDB.vsDB.updateCloseDayId(txtCldId.Text);
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
            txtTotalCash.Value = amt.ToString("#,###.00");
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
            grfCld.Cols.Count = 31;

            grfCld.Cols[colCldBillNo].Width = 100;
            grfCld.Cols[colCldReceiptNo].Width = 100;
            grfCld.Cols[colCldDate].Width = 100;
            grfCld.Cols[colCldHn].Width = 100;
            grfCld.Cols[colCldName].Width = 200;
            grfCld.Cols[colCldPkg1].Width = 100;
            grfCld.Cols[colCldPkg2].Width = 100;
            grfCld.Cols[colCldPkg3].Width = 100;
            grfCld.Cols[colCldPkg4].Width = 100;
            grfCld.Cols[colCldPkg5].Width = 100;
            grfCld.Cols[colCldPkg6].Width = 100;
            grfCld.Cols[colCldPkgFreezing].Width = 100;
            grfCld.Cols[colCldExtraDay6].Width = 100;
            grfCld.Cols[colCldMedInc].Width = 90;
            grfCld.Cols[colCldMedExtra].Width = 90;
            grfCld.Cols[colCldDtrfee].Width = 90;
            grfCld.Cols[colCldLabAll].Width = 90;
            grfCld.Cols[colCldLabBlood].Width = 90;
            grfCld.Cols[colCldTVS].Width = 90;
            grfCld.Cols[colCldEquipment].Width = 90;
            grfCld.Cols[colCldDiscount].Width = 90;
            grfCld.Cols[colCldOtherService].Width = 90;
            grfCld.Cols[colCldAmount].Width = 90;
            grfCld.Cols[colCldAmount1].Width = 90;
            grfCld.Cols[colCldPkgOther].Width = 100;

            grfCld.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfCld.Cols[colCldBillNo].Caption = "Bill NO";
            grfCld.Cols[colCldReceiptNo].Caption = "Receipt NO";
            grfCld.Cols[colCldDate].Caption = "Date";
            grfCld.Cols[colCldHn].Caption = "HN";
            grfCld.Cols[colCldName].Caption = "Name";
            grfCld.Cols[colCldPkg1].Caption = "Package ICSI";
            grfCld.Cols[colCldPkg2].Caption = "Package FET";
            grfCld.Cols[colCldPkg3].Caption = "Package TESE/PESA";
            grfCld.Cols[colCldPkg4].Caption = "Package NGS";
            grfCld.Cols[colCldPkg5].Caption = "Package PGD";
            grfCld.Cols[colCldPkg6].Caption = "Package Frozen Sperm";
            grfCld.Cols[colCldPkgFreezing].Caption = "Freezing";
            grfCld.Cols[colCldExtraDay6].Caption = "ExtraDay6";
            grfCld.Cols[colCldMedInc].Caption = "Medicine In";
            grfCld.Cols[colCldMedExtra].Caption = "Medicine Ex";
            grfCld.Cols[colCldDtrfee].Caption = "Doctor fee";
            grfCld.Cols[colCldLabAll].Caption = "Lab Other";
            grfCld.Cols[colCldLabBlood].Caption = "Blood Lab";
            grfCld.Cols[colCldTVS].Caption = "TVS";
            grfCld.Cols[colCldEquipment].Caption = "Equipment";
            grfCld.Cols[colCldDiscount].Caption = "Discount";
            grfCld.Cols[colCldOtherService].Caption = "Other";
            grfCld.Cols[colCldAmount].Caption = "Total";
            grfCld.Cols[colCldAmount1].Caption = "Amount";
            grfCld.Cols[colCldInc].Caption = "Include";
            grfCld.Cols[colCldExt].Caption = "Extra";
            grfCld.Cols[colCldPkgOther].Caption = "Package Other";

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
                String receiptno = "", debug="";
                receiptno = row[ic.ivfDB.obilhDB.obillh.receipt_no].ToString();
                if (receiptno.Equals("RE630600053"))
                {
                    debug = "";
                }

                String bilid = row[ic.ivfDB.obilhDB.obillh.bill_id].ToString();
                String pkg1 = "", pkg2 = "", pkg3 = "", pkg4 = "", pkg5 = "", pkg6 = "", pkglabfreezing="", extraday6="", laball="", labblood="", tvs="",equipment="", amt="", pkgother="", pkgall="", specialall="", extra="";
                String amtmedinc ="", amtdtrfee="", amtlab1="", amtlab2="", amtnurfee="", amttreat="", amtdiscount="",amtother="", include="", amtmedext="";
                Decimal pkg11 = 0, pkg21 = 0, pkg31 = 0, pkg41 = 0, pkg51 = 0, pkg61 = 0, pkglabfreezing1=0, extraday61=0, laball1=0, labblood1=0,tvs1=0, equipment1=0, amt1=0, amtmedext1=0;
                Decimal amtmed1 = 0, amtdtrfee1 = 0, amtlab11 = 0, amtlab21 = 0, amtnurfee1 = 0, amttreat1 = 0, amtdiscount1 = 0, amtother1 = 0, total=0, pkgother1=0, pkgall1=0, specialall1=0, include1=0, pkgall2=0, extra1=0;
                String pkgicsi = "2570000001,2570000002, 2570000003, 2570000020, 2570000025, 2570000037";
                String pkgfet = "2570000006,2570000024, 2570000026";
                String pkgpesa = "2570000011";
                String pkgngs = "2570000039, 2570000038, 2570000040, 2570000045, 2570000046, 2570000044";
                String pkgpgd = "2570000008";
                String pkgsperm = "2570000017";
                //String itmfreezing = "2580000000, 2580000001,2580000002,2580000003,2580000004,2580000005,2580000006";
                String pkgfreezing = "2570000009, 2570000007,2570000010,2570000032";
                String itmextraday6 = "2640000000";
                String itmlabboood = "1";
                String itmtvs = "42640000005,2640000059,2640000036,2640000100,2640000179,2640000039,2640000175,2640000096";
                String itmequipment = "2590000001,2590000002,2590000003,2590000004";
                pkg1 = ic.ivfDB.obildDB.selectSumPriceByBilIdItmId(bilid, pkgicsi);
                Decimal.TryParse(pkg1, out pkg11);
                pkg2 = ic.ivfDB.obildDB.selectSumPriceByBilIdItmId(bilid, pkgfet);
                Decimal.TryParse(pkg2, out pkg21);
                pkg3 = ic.ivfDB.obildDB.selectSumPriceByBilIdItmId(bilid, pkgpesa);
                Decimal.TryParse(pkg3, out pkg31);
                pkg4 = ic.ivfDB.obildDB.selectSumPriceByBilIdItmId(bilid, pkgngs);
                Decimal.TryParse(pkg4, out pkg41);
                pkg5 = ic.ivfDB.obildDB.selectSumPriceByBilIdItmId(bilid, pkgpgd);
                Decimal.TryParse(pkg5, out pkg51);
                pkg6 = ic.ivfDB.obildDB.selectSumPriceByBilIdItmId(bilid, pkgsperm);
                Decimal.TryParse(pkg6, out pkg61);
                pkgall = ic.ivfDB.obildDB.selectSumPriceByBilIdBillGroup(bilid, "2650000000");
                Decimal.TryParse(pkgall, out pkgall1);
                specialall = ic.ivfDB.obildDB.selectSumPriceByBilIdBillGroup(bilid, "2650000090");      //2650000090
                Decimal.TryParse(specialall, out specialall1);

                //labfreezing = ic.ivfDB.obildDB.selectSumPriceByBilIdItmId(bilid, pkgfreezing);
                pkglabfreezing = ic.ivfDB.obildDB.selectSumPriceByBilIdItmId(bilid, pkgfreezing);
                Decimal.TryParse(pkglabfreezing, out pkglabfreezing1);
                extraday6 = ic.ivfDB.obildDB.selectSumPriceByBilIdItmId(bilid, itmextraday6);
                Decimal.TryParse(extraday6, out extraday61);
                laball = ic.ivfDB.obildDB.selectSumPriceExtraByLabAll(bilid);
                Decimal.TryParse(laball, out laball1);
                //labblood = ic.ivfDB.obildDB.selectSumPriceByLabGroup(bilid, itmlabboood);
                labblood = ic.ivfDB.obildDB.selectSumPriceExtraByLabGroup(bilid, itmlabboood);
                Decimal.TryParse(labblood, out labblood1);
                //tvs = ic.ivfDB.obildDB.selectSumPriceByBilIdItmId(bilid, itmtvs);
                tvs = ic.ivfDB.obildDB.selectSumPriceExtraByBilIdItmId(bilid, itmtvs);
                Decimal.TryParse(tvs, out tvs1);
                //equipment = ic.ivfDB.obildDB.selectSumPriceByBilIdItmId(bilid, itmequipment);
                equipment = ic.ivfDB.obildDB.selectSumPriceByBilIdBillGroup(bilid, "2650000006");
                Decimal.TryParse(equipment, out equipment1);
                amt = ic.ivfDB.obildDB.selectSumPriceByBilId(bilid);
                Decimal.TryParse(amt, out amt1);

                amtmedinc = ic.ivfDB.obildDB.selectSumPriceIncludeByBilId1(bilid, "2650000001");
                Decimal.TryParse(amtmedinc, out amtmed1);
                amtmedext = ic.ivfDB.obildDB.selectSumPriceExtraByBilId1(bilid, "2650000001");
                Decimal.TryParse(amtmedext, out amtmedext1);

                amtdtrfee = ic.ivfDB.obildDB.selectSumPriceByBilId1(bilid, "2650000002");
                Decimal.TryParse(amtdtrfee, out amtdtrfee1);

                //include = ic.ivfDB.obildDB.selectSumPriceIncludeByBilId(bilid);
                //Decimal.TryParse(include, out include1);

                extra = ic.ivfDB.obildDB.selectSumPriceExtraByBilId(bilid);
                Decimal.TryParse(extra, out extra1);

                //amtlab1 = ic.ivfDB.obildDB.selectSumPriceByBilId1(bilid, "3");
                //Decimal.TryParse(amtlab1, out amtlab11);

                //amtlab2 = ic.ivfDB.obildDB.selectSumPriceByBilId1(bilid, "4");
                //Decimal.TryParse(amtlab2, out amtlab21);

                //amtnurfee = ic.ivfDB.obildDB.selectSumPriceByBilId1(bilid, "5");
                //Decimal.TryParse(amtnurfee, out amtnurfee1);

                //amttreat = ic.ivfDB.obildDB.selectSumPriceByBilId1(bilid, "90");
                //Decimal.TryParse(amttreat, out amttreat1);

                amtdiscount = ic.ivfDB.obildDB.selectSumPriceByBilId1(bilid, "2650000099");
                Decimal.TryParse(amtdiscount, out amtdiscount1);

                amtother = ic.ivfDB.obildDB.selectSumPriceByBilId1(bilid, "2650000102");
                Decimal.TryParse(amtother, out amtother1);
                                
                //total = pkg11 + pkg21 + pkg31 + pkg41 + pkg51 + pkg61 + labfreezing1 + extraday61 + laball1 + amtmed1 + amtdtrfee1 + amtdiscount1 + amtother1-include1;
                
                String rc = "";
                rc = row[ic.ivfDB.obilhDB.obillh.receipt_no].ToString();
                pkgother1 = pkgall1 - pkg11 - pkg21 - pkg31 - pkg41 - pkg51 - pkg61 - pkglabfreezing1;
                pkgall2 = pkg11 + pkg21 + pkg31 + pkg41 + pkg51 + pkg61 + pkgother1;
                total = pkgall1 + extra1 + amtdiscount1;

                grfCld[i, 0] = i;
                grfCld[i, colCldId] = "";
                grfCld[i, colCldBillId] = row[ic.ivfDB.obilhDB.obillh.bill_id].ToString();
                grfCld[i, colCldBillNo] = row[ic.ivfDB.obilhDB.obillh.BillNo].ToString();
                grfCld[i, colCldReceiptNo] = row[ic.ivfDB.obilhDB.obillh.receipt_no].ToString();
                grfCld[i, colCldDate] = ic.datetoShow(row[ic.ivfDB.obilhDB.obillh.Date].ToString());
                grfCld[i, colCldHn] = row[ic.ivfDB.obilhDB.obillh.PIDS].ToString();
                grfCld[i, colCldName] = row[ic.ivfDB.obilhDB.obillh.PName].ToString();
                grfCld[i, colCldPkg1] = pkg11.ToString("#,###.00");
                grfCld[i, colCldPkg2] = pkg21.ToString("#,###.00");
                grfCld[i, colCldPkg3] = pkg31.ToString("#,###.00");
                grfCld[i, colCldPkg4] = pkg41.ToString("#,###.00");
                grfCld[i, colCldPkg5] = pkg51.ToString("#,###.00");
                grfCld[i, colCldPkg6] = pkg61.ToString("#,###.00");
                grfCld[i, colCldPkgFreezing] = pkglabfreezing1.ToString("#,###.00");
                grfCld[i, colCldExtraDay6] = extraday61.ToString("#,###.00");
                //grfCld[i, colCldLabAll] = (laball1 - labblood1) > 0 ? (laball1 - labblood1).ToString("#,###.00") : laball1.ToString("#,###.00");
                grfCld[i, colCldLabAll] = (laball1 - labblood1).ToString("#,###.00");
                grfCld[i, colCldLabBlood] = labblood1.ToString("#,###.00");
                grfCld[i, colCldMedInc] = amtmed1.ToString("#,###.00");
                grfCld[i, colCldMedExtra] = amtmedext1.ToString("#,###.00");
                grfCld[i, colCldTVS] = tvs1.ToString("#,###.00");
                grfCld[i, colCldDtrfee] = amtdtrfee1.ToString("#,###.00");
                grfCld[i, colCldEquipment] = equipment1.ToString("#,###.00");

                //grfCld[i, colCldMed] = amtmed1.ToString("#,###.00");
                //grfCld[i, colCldDtrfee] = amtdtrfee1.ToString("#,###.00");
                //grfCld[i, colCldLabAll] = amtlab11.ToString("#,###.00");
                //grfCld[i, colCldLabBlood] = amtlab21.ToString("#,###.00");
                //grfCld[i, colCldNurfee] = amtnurfee1.ToString("#,###.00");
                //grfCld[i, colCldTreat] = amttreat1.ToString("#,###.00");
                grfCld[i, colCldDiscount] = amtdiscount1.ToString("#,###.00");
                grfCld[i, colCldOtherService] = amtother1.ToString("#,###.00");
                grfCld[i, colCldAmount] = total.ToString("#,###.00");
                grfCld[i, colCldAmount1] = amt1.ToString("#,###.00");
                grfCld[i, colCldInc] = pkgall1.ToString("#,###.00");
                extra1 = extra1 + amtdiscount1; // extra 
                grfCld[i, colCldExt] = extra1.ToString("#,###.00");

                grfCld[i, colCldPkgOther] = pkgother1.ToString("#,###.00");
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
            grfCld.Cols[colCldBillNo].Visible = false;
            grfCld.Cols[colCldVn].Visible = false;
            //grfCld.Cols[colStatusNurse].Visible = false;
            //grfCld.Cols[colStatusCashier].Visible = false;

            grfCld.Cols[colCldBillNo].AllowEditing = false;
            grfCld.Cols[colCldReceiptNo].AllowEditing = false;
            grfCld.Cols[colCldDate].AllowEditing = false;
            grfCld.Cols[colCldHn].AllowEditing = false;
            grfCld.Cols[colCldName].AllowEditing = false;
            grfCld.Cols[colCldPkg1].AllowEditing = false;
            grfCld.Cols[colCldPkg2].AllowEditing = false;
            grfCld.Cols[colCldPkg3].AllowEditing = false;
            grfCld.Cols[colCldPkg4].AllowEditing = false;
            grfCld.Cols[colCldPkg5].AllowEditing = false;
            grfCld.Cols[colCldPkg6].AllowEditing = false;
            grfCld.Cols[colCldPkgFreezing].AllowEditing = false;
            grfCld.Cols[colCldExtraDay6].AllowEditing = false;
            grfCld.Cols[colCldTVS].AllowEditing = false;
            grfCld.Cols[colCldEquipment].AllowEditing = false;
            grfCld.Cols[colCldMedInc].AllowEditing = false;
            grfCld.Cols[colCldDtrfee].AllowEditing = false;
            grfCld.Cols[colCldLabAll].AllowEditing = false;
            grfCld.Cols[colCldLabBlood].AllowEditing = false;
            grfCld.Cols[colCldMedExtra].AllowEditing = false;
            //grfCld.Cols[colCldTreat].AllowEditing = false;
            grfCld.Cols[colCldDiscount].AllowEditing = false;
            grfCld.Cols[colCldOtherService].AllowEditing = false;
            grfCld.Cols[colCldAmount].AllowEditing = false;
            grfCld.Cols[colCldAmount1].Visible = false;
            //theme1.SetTheme(grfQue, ic.theme);
        }
        private void initGrfCloseDay()
        {
            grfCld = new C1FlexGrid();
            grfCld.Font = fEdit;
            grfCld.Dock = System.Windows.Forms.DockStyle.Fill;
            grfCld.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            //grfCld.DoubleClick += GrfCld_DoubleClick;
            grfCld.Click += GrfCld_Click;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("Export Excel", new EventHandler(ContextMenu_export_closeday));
            ////menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            ////menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfCld.ContextMenu = menuGw;
            pnCldDetail.Controls.Add(grfCld);

            theme1.SetTheme(grfCld, "Office2010Red");

            //theme1.SetTheme(tabDiag, "Office2010Blue");
            //theme1.SetTheme(tabFinish, "Office2010Blue");
        }

        private void GrfCld_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfCld.Row < 0) return;
            if (grfCld.Col < 0) return;
            String bilid = "";
            bilid = grfCld[grfCld.Row, colCldBillId].ToString();
            setGrfBillD(bilid);
        }

        private void ContextMenu_export_closeday(object sender, System.EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.DefaultExt = "xls";
            dlg.Filter = "Excel |*.xls";
            dlg.InitialDirectory = ic.iniC.pathSaveExcelAppointment;
            dlg.FileName = "*.xls";
            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            // clear book
            C1XLBook _book = new C1XLBook();
            //_book.Clear();
            //_book.Sheets.Clear();

            // copy grids to book sheets
            //foreach (TabPage pg in _tab.TabPages)
            //{
            //    C1FlexGrid grid = pg.Controls[0] as C1FlexGrid;
            XLSheet sheet = _book.Sheets.Add("closeday"+DateTime.Now.ToString("dd-MM-")+ DateTime.Now.Year.ToString());
            
            ic.SaveSheet(grfCld, sheet, _book, false);
            //}
            
            // save selected sheet index
            _book.Sheets.SelectedIndex = 0;

            // save the book
            _book.Save(dlg.FileName);
            if (File.Exists(dlg.FileName))
            {
                //Process p = new Process();
                //p.StartInfo.FileName = dlg.FileName;
                //p.Start();
                string argument = "/select, \"" + dlg.FileName + "\"";
                Process.Start("explorer.exe", argument);
            }

        }
        private void GrfCld_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfCld.Row < 0) return;
            if (grfCld.Col < 0) return;
            String bilid = "";
            bilid = grfCld[grfCld.Row, colCldBillId].ToString();
            setGrfBillD(bilid);
        }

        private void setGrfBillD(String bilid)
        {
            //grfDept.Rows.Count = 7;
            grfBilD.Clear();
            DataTable dt1 = new DataTable();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.obildDB.selectByBillId(bilid);
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
            grfBilD.Rows.Count = dt.Rows.Count + 2;
            grfBilD.Cols.Count = 13;
            C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfBilD.Cols[colBildName].Editor = txt;
            grfBilD.Cols[colBildAmt].Editor = txt;
            grfBilD.Cols[colBildDiscount].Editor = txt;
            grfBilD.Cols[colBildNetAmt].Editor = txt;

            grfBilD.Cols[colBildName].Width = 360;
            grfBilD.Cols[colBildAmt].Width = 120;
            grfBilD.Cols[colBildDiscount].Width = 120;
            grfBilD.Cols[colBildNetAmt].Width = 120;
            grfBilD.Cols[colBildGrpName].Width = 120;
            grfBilD.Cols[colBildprice].Width = 100;
            grfBilD.Cols[colBildqty].Width = 80;
            grfBilD.Cols[colBildItmId].Width = 80;

            grfBilD.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfBilD.Cols[colBildName].Caption = "รายการ";
            grfBilD.Cols[colBildAmt].Caption = "จำนวนเงิน";
            grfBilD.Cols[colBildDiscount].Caption = "ส่วนลด";
            grfBilD.Cols[colBildNetAmt].Caption = "คงเหลือ";
            grfBilD.Cols[colBildGrpName].Caption = "group name";
            grfBilD.Cols[colBildprice].Caption = "Price";
            grfBilD.Cols[colBildqty].Caption = "QTY";

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
                    Decimal price = 0, qty = 1, price1 = 0;
                    Decimal.TryParse(row[ic.ivfDB.obildDB.obilld.Price].ToString(), out price);
                    Decimal.TryParse(row[ic.ivfDB.obildDB.obilld.qty].ToString(), out qty);
                    Decimal.TryParse(row[ic.ivfDB.obildDB.obilld.price1].ToString(), out price1);
                    grfBilD[i, 0] = i;
                    grfBilD[i, colBildId] = row[ic.ivfDB.obildDB.obilld.ID].ToString();
                    grfBilD[i, colBildName] = row[ic.ivfDB.obildDB.obilld.Name].ToString();
                    grfBilD[i, colBildAmt] = price.ToString("#,###.00");
                    grfBilD[i, colBildDiscount] = "";
                    if (row["Extra"].ToString().Equals("1"))
                    {
                        grfBilD[i, colBildNetAmt] = price.ToString("#,###.00");
                    }
                    else
                    {
                        if (row[ic.ivfDB.obildDB.obilld.GroupType].ToString().Equals("Package"))
                        {
                            grfBilD[i, colBildNetAmt] = price.ToString("#,###.00");
                        }
                        else
                        {
                            grfBilD[i, colBildNetAmt] = "0.00";
                        }
                    }

                    grfBilD[i, colBildGrpName] = row[ic.ivfDB.obildDB.obilld.GroupType].ToString();
                    grfBilD[i, colBildInclude] = row["Extra"].ToString().Equals("1") ? "Extra" : "Include";
                    grfBilD[i, colBildStatus] = row["status"].ToString();
                    grfBilD[i, colBildprice] = price1.ToString("#,###.00");
                    grfBilD[i, colBildqty] = qty.ToString("#,###.00");
                    grfBilD[i, colBildItmId] = row[ic.ivfDB.obildDB.obilld.item_id].ToString();
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
            CellNoteManager mgr = new CellNoteManager(grfBilD);
            grfBilD.Cols[colBildBilId].Visible = false;
            grfBilD.Cols[colBildId].Visible = false;
            grfBilD.Cols[colBildDiscount].AllowEditing = false;
            grfBilD.Cols[colBildAmt].AllowEditing = false;
            grfBilD.Cols[colBildNetAmt].AllowEditing = false;
            grfBilD.Cols[colBildGrpName].AllowEditing = false;
            grfBilD.Cols[colBildInclude].AllowEditing = false;
            grfBilD.Cols[colBildItmId].AllowEditing = false;
            //theme1.SetTheme(grfQue, ic.theme);
            //Decimal amt = 0;
            //amt = calAmt();
            //txtAmt.Value = amt.ToString("#,###.00");
        }
        
        private void initGrfBillD()
        {
            grfBilD = new C1FlexGrid();
            grfBilD.Font = fEdit;
            grfBilD.Dock = System.Windows.Forms.DockStyle.Fill;
            grfBilD.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            //grfSearch.DoubleClick += GrfSearch_DoubleClick;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            //ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("ออก บิล", new EventHandler(ContextMenu_edit_billSearch));
            //menuGw.MenuItems.Add("ส่งกลับ", new EventHandler(ContextMenu_send_back));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            //grfSearch.ContextMenu = menuGw;
            pnCldDetailBillD.Controls.Add(grfBilD);

            theme1.SetTheme(grfBilD, "Office2010Red");

            //theme1.SetTheme(tabDiag, "Office2010Blue");
            //theme1.SetTheme(tabFinish, "Office2010Blue");
        }
        private void initGrfRptView()
        {
            grfRpt = new C1FlexGrid();
            grfRpt.Font = fEdit;
            grfRpt.Dock = System.Windows.Forms.DockStyle.Fill;
            grfRpt.Location = new System.Drawing.Point(0, 0);
            //grfRptCri.Click += GrfRpt_Click;

            pnReportView.Controls.Add(grfRpt);

            theme1.SetTheme(grfRpt, "Office2010Red");

        }
        private void initGrfRpt()
        {
            grfRptCri = new C1FlexGrid();
            grfRptCri.Font = fEdit;
            grfRptCri.Dock = System.Windows.Forms.DockStyle.Fill;
            grfRptCri.Location = new System.Drawing.Point(0, 0);
            grfRptCri.Click += GrfRpt_Click;

            pnReportItem.Controls.Add(grfRptCri);

            theme1.SetTheme(grfRptCri, "Office2010Red");
            
        }
        private void setHideRptCri()
        {
            pnReportCri001.Hide();
        }
        private void GrfRpt_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfRptCri == null) return;
            if (grfRptCri.Row <= 0) return;
            if (grfRptCri.Col <= 0) return;
            rptid = "";
            grfRpt.Rows.Count = 1;
            setHideRptCri();
            rptid = grfRptCri[grfRptCri.Row, 1].ToString();
            if (rptid.Length > 0)
            {
                if (rptid.Equals("rptcashier001"))
                {
                    pnReportCri001.Show();
                }
                else if (rptid.Equals("rptcashier002"))
                {
                    pnReportCri001.Show();
                }
                else if (rptid.Equals("rptcashier003"))
                {
                    pnReportCri001.Show();
                }
                else if (rptid.Equals("rptcashier004"))
                {
                    pnReportCri001.Show();
                }
            }
            else if (rptid.Length > 0)
            {
                if (rptid.Equals("rptcashier002"))
                {
                    pnReportCri001.Show();
                }
            }
        }
        private void setGrfRpt()
        {
            //grfDept.Rows.Count = 7;
            grfRptCri.Clear();

            grfRptCri.Rows.Count = 2;
            grfRptCri.Cols.Count = 3;
            C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);

            grfRptCri.Cols[1].Width = 80;
            grfRptCri.Cols[2].Width = 420;

            grfRptCri.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfRptCri.Cols[2].Caption = "Report Name";
            
            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            
            int i = 1;

            grfRptCri[i, 0] = i;
            grfRptCri[i, 1] = "rptcashier001";
            grfRptCri[i, 2] = "List คนไข้ประจำวัน";
            i++;
            Row row = grfRptCri.Rows.Add();
            row[1] = "rptcashier002";
            row[2] = "รายงานประจำวัน ตามเครื่องรูดบัตร 1";
            row = grfRptCri.Rows.Add();
            row[1] = "rptcashier003";
            row[2] = "รายงานประจำวัน ตามเครื่องรูดบัตร 2";
            row = grfRptCri.Rows.Add();
            row[1] = "rptcashier004";
            row[2] = "รายงานประจำวัน ตามเครื่องรูดบัตร 3";

            //    grfPtt.Rows[i].StyleNew.BackColor = color;
            i++;
            
            CellNoteManager mgr = new CellNoteManager(grfRptCri);
            grfRptCri.Cols[1].Visible = false;
            //grfRpt.Cols[colVN].Visible = false;
            //grfRpt.Cols[colBillId].Visible = false;
            grfRptCri.Cols[2].AllowEditing = false;
            
            //theme1.SetTheme(grfQue, ic.theme);

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
            grfFinish.Rows.Count = 1;
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
            menuGw.MenuItems.Add("&ยกเลิก บิล", new EventHandler(ContextMenu_edit_billVoid));
            grfFinish.ContextMenu = menuGw;

            grfFinish.Rows.Count = dt.Rows.Count + 1;
            grfFinish.Cols.Count = 15;
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
                grfFinish[i, colBillId] = row["bill_id"].ToString();
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
        private void ContextMenu_edit_billVoid(object sender, System.EventArgs e)
        {
            String billid = "", name = "", id = "";

            id = grfFinish[grfFinish.Row, colID] != null ? grfFinish[grfFinish.Row, colID].ToString() : "";     //billid
            name = grfFinish[grfFinish.Row, colPttName] != null ? grfFinish[grfFinish.Row, colPttName].ToString() : "";
            billid = grfFinish[grfFinish.Row, colBillId] != null ? grfFinish[grfFinish.Row, colBillId].ToString() : "";

            //openBillNew(id, name, "noedit", billid);
            ic.cStf.staff_id = "";
            FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            frm.ShowDialog(this);
            if (!ic.cStf.staff_id.Equals(""))
            {
                ic.ivfDB.VoidBill(id, ic.cStf.staff_id);
                //String billid1 = ic.ivfDB.getBill(id, ic.cStf.staff_id);
                //ic.ivfDB.updatePackagePaymentComplete(ovs.PID, row["PCKSID"].ToString());
                ic.ivfDB.opkgsDB.updateStatus1(billid);
                String re1 = ic.ivfDB.vsDB.updateOpenStatusCashierByVn(id);
                ic.ivfDB.nurseFinish(id, ic.cStf.staff_id);        // +0015
                setGrfFinish();
            }
        }
        private void ContextMenu_edit_bill(object sender, System.EventArgs e)
        {
            String chk = "", name = "", id = "", vn="", agentid="";

            id = grfQue[grfQue.Row, colID] != null ? grfQue[grfQue.Row, colID].ToString() : "";
            vn = grfQue[grfQue.Row, colVN] != null ? grfQue[grfQue.Row, colVN].ToString() : "";
            name = grfQue[grfQue.Row, colPttName] != null ? grfQue[grfQue.Row, colPttName].ToString() : "";
            agentid = grfQue[grfQue.Row, colAgentId] != null ? grfQue[grfQue.Row, colAgentId].ToString() : "";
            String billid = ic.getBillVN(id, agentid, ic.userId);
            String re1 = ic.ivfDB.vsDB.updateOpenStatusCashierByVn(id);
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
            grfQue.Cols.Count = 15;
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
                grfQue[i, colVsAgent] = row["AgentName"].ToString();
                grfQue[i, colBillId] = "";
                grfQue[i, colAgentId] = row["agent"].ToString();
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
            grfQue.Cols[colAgentId].Visible = false;
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
            spCld.Width = 370;
            c1SplitContainer3.HeaderHeight = 0;
            sB1.Text = "Date " + ic.cop.day + "-" + ic.cop.month + "-" + ic.cop.year + " Server " + ic.iniC.hostDB + "/" + ic.iniC.nameDB + " FTP " + ic.iniC.hostFTP + "/" + ic.iniC.folderFTP;
            tC.SelectedTab = tabQue;
        }
    }
}
