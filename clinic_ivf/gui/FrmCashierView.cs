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

        int colID = 1, colVN = 2, colPttHn = 3, colPttName = 4, colVsDate = 5, colVsTime = 6, colVsEtime = 7, colStatus = 8, colPttId = 9, colStatusNurse = 10, colStatusCashier = 11;

        C1FlexGrid grfQue, grfFinish, grfSearch;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        Timer timer;

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

            tC.SelectedTabChanged += TC_SelectedTabChanged;

            initGrfQue();
            initGrfFinish();
            setGrfQue();
            setGrfFinish();

            int timerlab = 0;
            int.TryParse(ic.iniC.timerlabreqaccept, out timerlab);
            timer = new Timer();
            timer.Interval = timerlab * 1000;
            timer.Tick += Timer_Tick;
            timer.Enabled = true;
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
        }
        
        private void Timer_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setGrfQue();
            //setGrfSearch(txtSearch.Text.Trim());
        }
        private void initGrfFinish()
        {
            grfFinish = new C1FlexGrid();
            grfFinish.Font = fEdit;
            grfFinish.Dock = System.Windows.Forms.DockStyle.Fill;
            grfFinish.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            //grfQue.AfterRowColChange += GrfReq_AfterRowColChange;
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
            grfFinish.Cols.Count = 10;
            C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfFinish.Cols[colPttHn].Editor = txt;
            grfFinish.Cols[colPttName].Editor = txt;
            grfFinish.Cols[colVsDate].Editor = txt;

            grfFinish.Cols[colVN].Width = 120;
            grfFinish.Cols[colPttHn].Width = 120;
            grfFinish.Cols[colPttName].Width = 300;
            grfFinish.Cols[colVsDate].Width = 100;
            grfFinish.Cols[colVsTime].Width = 80;
            grfFinish.Cols[colVsEtime].Width = 80;
            grfFinish.Cols[colStatus].Width = 200;

            grfFinish.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfFinish.Cols[colVN].Caption = "VN";
            grfFinish.Cols[colPttHn].Caption = "HN";
            grfFinish.Cols[colPttName].Caption = "Name";
            grfFinish.Cols[colVsDate].Caption = "Date";
            grfFinish.Cols[colVsTime].Caption = "Time visit";
            grfFinish.Cols[colVsEtime].Caption = "Time finish";
            grfFinish.Cols[colStatus].Caption = "Status";

            //menuGw.MenuItems.Add("&receive operation", new EventHandler(ContextMenu_Apm));
            //menuGw.MenuItems.Add("receive operation", new EventHandler(ContextMenu_order));
            //menuGw.MenuItems.Add("&LAB request FORM A", new EventHandler(ContextMenu_LAB_req_formA_Ptt));
            //menuGw.MenuItems.Add("&Add Appointment", new EventHandler(ContextMenu_Apm_Ptt));
            //menuGw.MenuItems.Add("&Cancel Receive", new EventHandler(ContextMenu_Apm_Ptt));
            //menuGw.MenuItems.Add("&No Appointment Close Operation", new EventHandler(ContextMenu_NO_Apm_Ptt));
            grfFinish.ContextMenu = menuGw;

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                grfFinish[i, 0] = i;
                grfFinish[i, colID] = row["id"].ToString();
                grfFinish[i, colVN] = row["VN"].ToString();
                grfFinish[i, colPttHn] = row["PIDS"].ToString();
                grfFinish[i, colPttName] = row["PName"].ToString();
                grfFinish[i, colVsDate] = ic.datetoShow(row["VDate"]);
                grfFinish[i, colVsTime] = row["VStartTime"].ToString();
                grfFinish[i, colVsEtime] = row["VEndTime"].ToString();
                grfFinish[i, colStatus] = row["VName"].ToString();
                grfFinish[i, colPttId] = row["PID"].ToString();
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
        private void ContextMenu_edit_billfinish(object sender, System.EventArgs e)
        {
            String chk = "", name = "", id = "";

            id = grfFinish[grfFinish.Row, colID] != null ? grfFinish[grfFinish.Row, colID].ToString() : "";
            name = grfFinish[grfFinish.Row, colPttName] != null ? grfFinish[grfFinish.Row, colPttName].ToString() : "";
            
            openBillNew(id, name);
        }
        private void ContextMenu_edit_bill(object sender, System.EventArgs e)
        {
            String chk = "", name = "", id = "", vn="";

            id = grfQue[grfQue.Row, colID] != null ? grfQue[grfQue.Row, colID].ToString() : "";
            vn = grfQue[grfQue.Row, colVN] != null ? grfQue[grfQue.Row, colVN].ToString() : "";
            name = grfQue[grfQue.Row, colPttName] != null ? grfQue[grfQue.Row, colPttName].ToString() : "";
            ic.getBillVN(id);
            openBillNew(id, name);
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
            dt = ic.ivfDB.ovsDB.selectByStatusCashierWaiting();
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
            grfQue.Cols.Count = 12;
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

            grfQue.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfQue.Cols[colVN].Caption = "VN";
            grfQue.Cols[colPttHn].Caption = "HN";
            grfQue.Cols[colPttName].Caption = "Name";
            grfQue.Cols[colVsDate].Caption = "Date";
            grfQue.Cols[colVsTime].Caption = "Time visit";
            grfQue.Cols[colVsEtime].Caption = "Time finish";
            grfQue.Cols[colStatus].Caption = "Status";
            grfQue.Cols[colStatusNurse].Caption = "Nurse";
            grfQue.Cols[colStatusCashier].Caption = "Cashier";

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
                grfQue[i, colVN] = ic.showVN(row["VN"].ToString());
                grfQue[i, colPttHn] = row["PIDS"].ToString();
                grfQue[i, colPttName] = row["PName"].ToString();
                grfQue[i, colVsDate] = ic.datetoShow(row["VDate"]);
                grfQue[i, colVsTime] = row["VStartTime"].ToString();
                grfQue[i, colVsEtime] = row["VEndTime"].ToString();
                grfQue[i, colStatus] = row["VName"].ToString();
                grfQue[i, colPttId] = row["PID"].ToString();
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
            grfQue.Cols[colVN].AllowEditing = false;
            grfQue.Cols[colPttHn].AllowEditing = false;
            grfQue.Cols[colPttName].AllowEditing = false;
            grfQue.Cols[colVsDate].AllowEditing = false;
            grfQue.Cols[colVsTime].AllowEditing = false;
            grfQue.Cols[colVsEtime].AllowEditing = false;
            grfQue.Cols[colStatus].AllowEditing = false;
            //theme1.SetTheme(grfQue, ic.theme);

        }
        private void openBillNew(String reqId, String name)
        {
            FrmCashierAdd frm = new FrmCashierAdd(ic, menu, "", reqId);
            frm.FormBorderStyle = FormBorderStyle.None;
            C1DockingTabPage tab = menu.AddNewTab(frm, name);
            frm.tab = tab;
            frm.frmCashView = this;
        }
        private void FrmCashierView_Load(object sender, EventArgs e)
        {

        }
    }
}
