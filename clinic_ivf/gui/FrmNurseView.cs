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
    public partial class FrmNurseView : Form
    {
        IvfControl ic;
        MainMenu menu;

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;

        int colID = 1, colVNshow = 2, colPttHn = 3, colPttName = 4, colVsDate = 5, colVsTime = 6, colVsEtime = 7, colStatus = 8, colPttId=9, colVn=10;
        int colSID = 1, colSVN = 2, colSPttHn = 3, colSPttName = 4, colSVsDate = 5, colSVsTime = 6, colSVsEtime = 7, colSStatus = 8, colSPttId = 9;
        int colRID = 1, colRVN = 2, colRPttHn = 3, colRPttName = 4, colRVsDate = 5, colRPttId = 6;

        C1FlexGrid grfQue, grfDiag, grfFinish, grfSearch, grfLab;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        Timer timer;

        public FrmNurseView(IvfControl ic, MainMenu m)
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

            txtDateStart.Value = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            txtLabResultDate.Value = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            //btnNew.Click += BtnNew_Click;
            txtSearch.KeyUp += TxtSearch_KeyUp;
            //txtDateStart.ValueChanged += TxtDateStart_ValueChanged;
            txtDateStart.DropDownClosed += TxtDateStart_DropDownClosed;
            tC.SelectedTabChanged += TC_SelectedTabChanged;
            btnSearch.Click += BtnSearch_Click;
            txtSearch.KeyUp += TxtSearch_KeyUp1;
            txtLabResultDate.KeyUp += TxtLabResultDate_KeyUp;

            initGrfQue();
            setGrfQue();
            initGrfDiag();
            setGrfDiag("");
            initGrfFinish();
            setGrfFinish();
            initGrfSearch();
            initGrfLab();

            int timerlab = 0;
            int.TryParse(ic.iniC.timerlabreqaccept, out timerlab);
            timer = new Timer();
            timer.Interval = timerlab * 1000;
            timer.Tick += Timer_Tick;
            timer.Enabled = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setGrfQue();
            //setGrfSearch(txtSearch.Text.Trim());
        }

        private void TxtLabResultDate_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.Enter)
            {
                setGrfLab(txtLabResultHn.Text.Trim());
            }
        }

        private void TxtSearch_KeyUp1(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if(e.KeyCode == Keys.Enter)
            {
                setGrfSearch(txtSearch.Text.Trim());
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //if (chkLabFormA.Checked)
            //{
            //    setGrfSearch(txtSearch.Text.Trim());
            //}
            //else
            //{
            //    if (tC.SelectedTab == tabFinish)
            //    {
            //        setGrfFinish();
            //    }
            //    else if (tC.SelectedTab == tabWaiting)
            //    {
            //        setGrfQue();
            //    }
            //}
            setGrfSearch(txtSearch.Text);
        }

        private void TxtDateStart_DropDownClosed(object sender, DropDownClosedEventArgs e)
        {
            //throw new NotImplementedException();
            if (txtDateStart.Text.Equals(""))
            {
                grfQue.Rows.Count = 1;
                grfFinish.Rows.Count = 1;
                return;
            }
            setGrfQue();
            setGrfFinish();
        }

        private void TC_SelectedTabChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if(tC.SelectedTab == tabFinish)
            {
                setGrfQue();
                setGrfDiag("");
                setGrfFinish();
            }
        }

        //private void TxtDateStart_ValueChanged(object sender, EventArgs e)
        //{
        //    //throw new NotImplementedException();
        //    //txtDateStart.Text
        //    setGrfQue();
        //    setGrfFinish();
        //}

        private void TxtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.Enter)
            {
                if (txtDateStart.Text.Equals(""))
                {
                    if (tabWaiting.IsSelected)
                    {

                    }
                    else if (tabDiag.IsSelected)
                    {

                    }
                    else if (tabFinish.IsSelected)
                    {
                        setGrfFinish();
                    }
                }
                else
                {
                    setGrfQue(txtSearch.Text);
                }
            }
            else
            {
                if (txtSearch.Text.Length > 3)
                {
                    if (chkLabFormA.Checked)
                    {
                        setGrfSearch(txtSearch.Text);
                    }
                    else
                    {
                        setGrfQue(txtSearch.Text);
                    }
                }
            }
        }
        private void initGrfFinish()
        {
            grfFinish = new C1FlexGrid();
            grfFinish.Font = fEdit;
            grfFinish.Dock = System.Windows.Forms.DockStyle.Fill;
            grfFinish.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            grfFinish.AfterRowColChange += GrfFinish_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfFinish.ContextMenu = menuGw;
            pnFinish.Controls.Add(grfFinish);

            theme1.SetTheme(grfFinish, "Office2010Green");
            //theme1.SetTheme(tC, "Office2010Blue");
            //theme1.SetTheme(tabDiag, "Office2010Blue");
            //theme1.SetTheme(tabFinish, "Office2010Blue");

        }

        private void GrfFinish_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();

        }
        private void setGrfFinish()
        {
            if (ic.iniC.statusAppDonor.Equals("1"))
            {
                setGrfFinishDonor(txtSearch.Text);
            }
            else
            {
                setGrfFinish(txtSearch.Text);
            }
        }
        private void setGrfFinishDonor(String search)
        {
            //grfDept.Rows.Count = 7;
            grfFinish.Clear();
            DataTable dt = new DataTable();
            if (search.Equals(""))
            {
                //String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
                dt = ic.ivfDB.vsDB.selectByStatusNurseFinish(ic.datetoDB(txtDateStart.Text));
            }
            else
            {
                //grfPtt.DataSource = ic.ivfDB.vsOldDB.selectCurrentVisit(search);
                if (txtDateStart.Text.Equals(""))
                {

                }
            }

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfFinish.Rows.Count = dt.Rows.Count + 1;
            grfFinish.Cols.Count = 10;
            C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfFinish.Cols[colPttHn].Editor = txt;
            grfFinish.Cols[colPttName].Editor = txt;
            grfFinish.Cols[colVsDate].Editor = txt;

            grfFinish.Cols[colVNshow].Width = 120;
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

            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("&receive operation", new EventHandler(ContextMenu_Apm));
            menuGw.MenuItems.Add("&Order Entry", new EventHandler(ContextMenu_Apm));
            menuGw.MenuItems.Add("&Edit Appointment", new EventHandler(ContextMenu_Finish_Apm));
            menuGw.MenuItems.Add("&Cancel Receive", new EventHandler(ContextMenu_Apm));
            
            grfFinish.ContextMenu = menuGw;

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    grfFinish[i, 0] = i;
                    grfFinish[i, colID] = row["id"].ToString();
                    grfFinish[i, colVNshow] = row["VN"].ToString();
                    grfFinish[i, colPttHn] = row["PIDS"].ToString();
                    grfFinish[i, colPttName] = row["PName"].ToString();
                    grfFinish[i, colVsDate] = ic.datetoShow(row["VDate"]);
                    grfFinish[i, colVsTime] = row["VStartTime"].ToString();
                    grfFinish[i, colVsEtime] = row["VEndTime"].ToString();
                    grfFinish[i, colStatus] = row["VName"].ToString();
                    grfFinish[i, colPttId] = row["PID"].ToString();
                    if (row[ic.ivfDB.vsDB.vs.visit_have_appointment].ToString().Equals("1"))
                    {
                        String txt1 = "";
                        txt1 = "นัดวันที่  "+ic.datetoShow(row["patient_appointment_date"].ToString())+" "+ row["patient_appointment_time"].ToString() + " " + row["patient_appointment"].ToString();
                        CellNote note = new CellNote(txt1);
                        CellRange rg = grfFinish.GetCellRange(i, colVNshow);
                        rg.UserData = note;
                    }
                    //if (i % 2 == 0)
                    //    grfPtt.Rows[i].StyleNew.BackColor = color;
                    i++;
                }
                catch(Exception ex)
                {

                }
                
            }
            CellNoteManager mgr = new CellNoteManager(grfFinish);
            grfFinish.Cols[colID].Visible = false;
            grfFinish.Cols[colPttId].Visible = false;
            //theme1.SetTheme(grfFinish, ic.theme);

        }
        private void setGrfFinish(String search)
        {
            //grfDept.Rows.Count = 7;
            grfFinish.Clear();
            DataTable dt = new DataTable();
            if (search.Equals(""))
            {
                //String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
                dt = ic.ivfDB.ovsDB.selectByStatusNurseFinish(ic.datetoDB(txtDateStart.Text));
            }
            else
            {
                //grfPtt.DataSource = ic.ivfDB.vsOldDB.selectCurrentVisit(search);
                if (txtDateStart.Text.Equals(""))
                {
                    dt = ic.ivfDB.ovsDB.selectByStatusNurseFinishLike(search);
                }
            }

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfFinish.Rows.Count = dt.Rows.Count + 1;
            grfFinish.Cols.Count = 10;
            C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfFinish.Cols[colPttHn].Editor = txt;
            grfFinish.Cols[colPttName].Editor = txt;
            grfFinish.Cols[colVsDate].Editor = txt;

            grfFinish.Cols[colVNshow].Width = 120;
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

            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("Receive operation", new EventHandler(ContextMenu_order_finish));
            menuGw.MenuItems.Add("&LAB request FORM A", new EventHandler(ContextMenu_LAB_req_formA_Ptt_finish));
            menuGw.MenuItems.Add("LAB Form Day1", new EventHandler(ContextMenu_Form_day1));
            menuGw.MenuItems.Add("&Order Entry", new EventHandler(ContextMenu_Apm));
            menuGw.MenuItems.Add("&Edit Appointment", new EventHandler(ContextMenu_Apm_Finish));
            menuGw.MenuItems.Add("&Cancel Receive", new EventHandler(ContextMenu_Apm));
            menuGw.MenuItems.Add("Print Pre-Operation Check List", new EventHandler(ContextMenu_prn_check_list_finish));
            menuGw.MenuItems.Add("Print Autherization Form", new EventHandler(ContextMenu_prn_authen_sign_finish));
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
                grfFinish[i, colVNshow] = row["VN"].ToString();
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
                    CellRange rg = grfFinish.GetCellRange(i, colVNshow);
                    rg.UserData = note;
                }
                //if (i % 2 == 0)
                //    grfPtt.Rows[i].StyleNew.BackColor = color;
                i++;
            }
            CellNoteManager mgr = new CellNoteManager(grfFinish);
            grfFinish.Cols[colID].Visible = false;
            grfFinish.Cols[colPttId].Visible = false;
            //theme1.SetTheme(grfFinish, ic.theme);

        }
        private void initGrfDiag()
        {
            grfDiag = new C1FlexGrid();
            grfDiag.Font = fEdit;
            grfDiag.Dock = System.Windows.Forms.DockStyle.Fill;
            grfDiag.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            grfDiag.AfterRowColChange += GrfDiag_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfDiag.ContextMenu = menuGw;
            pnDiag.Controls.Add(grfDiag);

            theme1.SetTheme(grfDiag, "Office2010Blue");
            //theme1.SetTheme(tC, "Office2010Blue");
            //theme1.SetTheme(tabDiag, "Office2010Blue");
            //theme1.SetTheme(tabFinish, "Office2010Blue");

        }

        private void GrfDiag_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();

        }
        private void setGrfDiag(String search)
        {
            //grfDept.Rows.Count = 7;
            grfDiag.Clear();
            DataTable dt = new DataTable();
            if (search.Equals(""))
            {
                //String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
                dt = ic.ivfDB.ovsDB.selectByStatusNurseDiag();
            }
            else
            {
                //grfPtt.DataSource = ic.ivfDB.vsOldDB.selectCurrentVisit(search);
            }

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfDiag.Rows.Count = dt.Rows.Count + 1;
            grfDiag.Cols.Count = 9;
            C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfDiag.Cols[colPttHn].Editor = txt;
            grfDiag.Cols[colPttName].Editor = txt;
            grfDiag.Cols[colVsDate].Editor = txt;

            grfDiag.Cols[colVNshow].Width = 120;
            grfDiag.Cols[colPttHn].Width = 120;
            grfDiag.Cols[colPttName].Width = 300;
            grfDiag.Cols[colVsDate].Width = 100;
            grfDiag.Cols[colVsTime].Width = 80;
            grfDiag.Cols[colVsEtime].Width = 80;
            grfDiag.Cols[colStatus].Width = 200;

            grfDiag.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfDiag.Cols[colVNshow].Caption = "VN";
            grfDiag.Cols[colPttHn].Caption = "HN";
            grfDiag.Cols[colPttName].Caption = "Name";
            grfDiag.Cols[colVsDate].Caption = "Date";
            grfDiag.Cols[colVsTime].Caption = "Time visit";
            grfDiag.Cols[colVsEtime].Caption = "Time finish";
            grfDiag.Cols[colStatus].Caption = "Status";

            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("Receive operation", new EventHandler(ContextMenu_order));
            menuGw.MenuItems.Add("&Order Entry", new EventHandler(ContextMenu_Apm));
            menuGw.MenuItems.Add("&Add Appointment", new EventHandler(ContextMenu_Apm));
            menuGw.MenuItems.Add("&Cancel Receive", new EventHandler(ContextMenu_Apm));
            grfDiag.ContextMenu = menuGw;

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                grfDiag[i, 0] = i;
                grfDiag[i, colID] = row["id"].ToString();
                grfDiag[i, colVNshow] = row["VN"].ToString();
                grfDiag[i, colPttHn] = row["PIDS"].ToString();
                grfDiag[i, colPttName] = row["PName"].ToString();
                grfDiag[i, colVsDate] = ic.datetoShow(row["VDate"]);
                grfDiag[i, colVsTime] = row["VStartTime"].ToString();
                grfDiag[i, colVsEtime] = row["VEndTime"].ToString();
                grfDiag[i, colStatus] = row["VName"].ToString();
                //if (i % 2 == 0)
                //    grfPtt.Rows[i].StyleNew.BackColor = color;
                i++;
            }
            grfDiag.Cols[colID].Visible = false;
            //theme1.SetTheme(grfDiag, ic.theme);

        }
        private void initGrfSearch()
        {
            grfSearch = new C1FlexGrid();
            grfSearch.Font = fEdit;
            grfSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            grfSearch.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            //grfSearch.AfterRowColChange += GrfReq_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            grfSearch.ContextMenu = menuGw;
            pnSearch.Controls.Add(grfSearch);
            grfSearch.Rows.Count = 1;
            theme1.SetTheme(pnSearch, "Office2010Red");

        }
        private void setGrfSearch(String search)
        {
            //grfDept.Rows.Count = 7;
            tC.SelectedTab = tabSearch;
            grfSearch.Clear();
            DataTable dt1 = new DataTable();
            DataTable dt = new DataTable();
            if (search.Equals(""))
            {
                String date = "";
                DateTime dt11 = new DateTime();
                if (DateTime.TryParse(txtDateStart.Text, out dt11))
                {
                    date = dt11.Year + "-" + dt11.ToString("MM-dd");
                    dt = ic.ivfDB.ovsDB.selectByHnFormA(date);
                }
            }
            else
            {
                dt = ic.ivfDB.ovsDB.selectByHNLike(search);
                //grfPtt.DataSource = ic.ivfDB.vsOldDB.selectCurrentVisit(search);
            }

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfSearch.Rows.Count = dt.Rows.Count + 1;
            grfSearch.Cols.Count = 10;
            C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfSearch.Cols[colPttHn].Editor = txt;
            grfSearch.Cols[colPttName].Editor = txt;
            grfSearch.Cols[colVsDate].Editor = txt;

            grfSearch.Cols[colVNshow].Width = 120;
            grfSearch.Cols[colPttHn].Width = 120;
            grfSearch.Cols[colPttName].Width = 300;
            grfSearch.Cols[colVsDate].Width = 100;
            grfSearch.Cols[colVsTime].Width = 80;
            grfSearch.Cols[colVsEtime].Width = 80;
            grfSearch.Cols[colStatus].Width = 200;

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

            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&receive operation", new EventHandler(ContextMenu_Apm));
            //menuGw.MenuItems.Add("&receive operation", new EventHandler(ContextMenu_Apm));
            menuGw.MenuItems.Add("&LAB request FORM A", new EventHandler(ContextMenu_LAB_req_formA_Ptt_search));
            menuGw.MenuItems.Add("LAB Form Day1", new EventHandler(ContextMenu_Form_day1));
            //menuGw.MenuItems.Add("&Add Appointment", new EventHandler(ContextMenu_Apm_Ptt));
            //menuGw.MenuItems.Add("&Cancel Receive", new EventHandler(ContextMenu_Apm_Ptt));
            //menuGw.MenuItems.Add("&No Appointment Close Operation", new EventHandler(ContextMenu_NO_Apm_Ptt));
            grfSearch.ContextMenu = menuGw;

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                grfSearch[i, 0] = i;
                grfSearch[i, colID] = row["id"].ToString();
                grfSearch[i, colVNshow] = row["VN"].ToString();
                grfSearch[i, colPttHn] = row["PIDS"].ToString();
                grfSearch[i, colPttName] = row["PName"].ToString();
                grfSearch[i, colVsDate] = ic.datetoShow(row["VDate"]);
                grfSearch[i, colVsTime] = row["VStartTime"].ToString();
                grfSearch[i, colVsEtime] = row["VEndTime"].ToString();
                grfSearch[i, colStatus] = row["VName"].ToString();
                grfSearch[i, colPttId] = row["PID"].ToString();
                if (!row[ic.ivfDB.ovsDB.vsold.form_a_id].ToString().Equals("0"))
                {
                    CellNote note = new CellNote("ส่ง Lab Request Foam A");
                    CellRange rg = grfSearch.GetCellRange(i, colVNshow);
                    rg.UserData = note;
                }
                //if (i % 2 == 0)
                //    grfPtt.Rows[i].StyleNew.BackColor = color;
                i++;
            }
            CellNoteManager mgr = new CellNoteManager(grfSearch);
            grfSearch.Cols[colID].Visible = false;
            //theme1.SetTheme(grfQue, ic.theme);

        }
        private void ContextMenu_Form_day1(object sender, System.EventArgs e)
        {
            String vnold = "";
            vnold = grfSearch[grfSearch.Row, colID].ToString();
            FrmLabFormDay1 frm = new FrmLabFormDay1(ic,"","","", vnold);
            frm.ShowDialog(this);
        }
        private void initGrfLab()
        {
            grfLab = new C1FlexGrid();
            grfLab.Font = fEdit;
            grfLab.Dock = System.Windows.Forms.DockStyle.Fill;
            grfLab.Location = new System.Drawing.Point(0, 0);
            grfLab.Rows.Count = 1;
            //FilterRow fr = new FilterRow(grfExpn);

            grfLab.AfterRowColChange += GrfLab_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfLab.ContextMenu = menuGw;
            pnLab.Controls.Add(grfLab);

            theme1.SetTheme(grfLab, "Office2007Blue");

            theme1.SetTheme(pnLab, "Office2007Blue");
            //theme1.SetTheme(tabFinish, "Office2010Blue");

        }
        private void setGrfLab(String search)
        {
            //grfDept.Rows.Count = 7;
            grfLab.Clear();
            DataTable dt1 = new DataTable();
            DataTable dt = new DataTable();
            if (search.Equals(""))
            {
                String date = "";
                DateTime dt11 = new DateTime();
                if (DateTime.TryParse(txtDateStart.Text, out dt11))
                {
                    date = dt11.Year + "-" + dt11.ToString("MM-dd");
                    dt = ic.ivfDB.lbReqDB.selectByStatusResult(date, date,"");
                }
            }
            else
            {
                String date1 = "";
                DateTime dt11 = new DateTime();
                DateTime.TryParse(txtLabResultDate.Text, out dt11);
                date1 = dt11.Year.ToString()+"-"+ dt11.ToString("MM-dd");
                dt = ic.ivfDB.lbReqDB.selectByStatusResult(date1, date1,search);
                //grfPtt.DataSource = ic.ivfDB.vsOldDB.selectCurrentVisit(search);
            }

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfLab.Rows.Count = dt.Rows.Count + 1;
            grfLab.Cols.Count = 10;
            C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfLab.Cols[colPttHn].Editor = txt;
            grfLab.Cols[colPttName].Editor = txt;
            grfLab.Cols[colVsDate].Editor = txt;

            grfLab.Cols[colVNshow].Width = 120;
            grfLab.Cols[colPttHn].Width = 120;
            grfLab.Cols[colPttName].Width = 300;
            grfLab.Cols[colVsDate].Width = 100;
            grfLab.Cols[colVsTime].Width = 80;
            grfLab.Cols[colVsEtime].Width = 80;
            grfLab.Cols[colStatus].Width = 200;

            grfLab.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfLab.Cols[colVNshow].Caption = "VN";
            grfLab.Cols[colPttHn].Caption = "HN";
            grfLab.Cols[colPttName].Caption = "Name";
            grfLab.Cols[colVsDate].Caption = "Date";
            grfLab.Cols[colVsTime].Caption = "Time visit";
            grfLab.Cols[colVsEtime].Caption = "Time finish";
            grfLab.Cols[colStatus].Caption = "Status";

            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&receive operation", new EventHandler(ContextMenu_Apm));
            menuGw.MenuItems.Add("Result LAB OPU", new EventHandler(ContextMenu_Result_Lab_OPU));
            //menuGw.MenuItems.Add("&LAB request FORM A", new EventHandler(ContextMenu_LAB_req_formA_Ptt));
            //menuGw.MenuItems.Add("&Add Appointment", new EventHandler(ContextMenu_Apm_Ptt));
            //menuGw.MenuItems.Add("&Cancel Receive", new EventHandler(ContextMenu_Apm_Ptt));
            //menuGw.MenuItems.Add("&No Appointment Close Operation", new EventHandler(ContextMenu_NO_Apm_Ptt));
            grfLab.ContextMenu = menuGw;

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                grfLab[i, 0] = i;
                grfLab[i, colRID] = row["req_id"].ToString();
                grfLab[i, colRVN] = row["VN"].ToString();
                grfLab[i, colRPttHn] = row["PIDS"].ToString();
                grfLab[i, colRPttName] = row["PName"].ToString();
                //grfLab[i, colVsDate] = ic.datetoShow(row["VDate"]);
                //grfLab[i, colVsTime] = row["VStartTime"].ToString();
                //grfLab[i, colVsEtime] = row["VEndTime"].ToString();
                //grfLab[i, colStatus] = row["VName"].ToString();
                //grfLab[i, colPttId] = row["PID"].ToString();
                //if (!row[ic.ivfDB.vsOldDB.vsold.form_a_id].ToString().Equals("0"))
                //{
                //    CellNote note = new CellNote("ส่ง Lab Request Foam A");
                //    CellRange rg = grfLab.GetCellRange(i, colVN);
                //    rg.UserData = note;
                //}
                //if (i % 2 == 0)
                //    grfPtt.Rows[i].StyleNew.BackColor = color;
                i++;
            }
            CellNoteManager mgr = new CellNoteManager(grfLab);
            grfLab.Cols[colRID].Visible = false;
            grfLab.Cols[colRVN].AllowEditing = false;
            grfLab.Cols[colRPttHn].AllowEditing = false;
            grfLab.Cols[colRPttName].AllowEditing = false;
            //theme1.SetTheme(grfQue, ic.theme);

        }
        private void GrfLab_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();

        }

        private void initGrfQue()
        {
            grfQue = new C1FlexGrid();
            grfQue.Font = fEdit;
            grfQue.Dock = System.Windows.Forms.DockStyle.Fill;
            grfQue.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            grfQue.AfterRowColChange += GrfReq_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfQue.ContextMenu = menuGw;
            pnQue.Controls.Add(grfQue);

            theme1.SetTheme(grfQue, "Office2010Red");
            
            //theme1.SetTheme(tabDiag, "Office2010Blue");
            //theme1.SetTheme(tabFinish, "Office2010Blue");
            
        }
        private void GrfReq_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;
            String vn = "";

            //grfAddr.DataSource = xC.iniDB.addrDB.selectByTableId1(vn);
        }
        private void setGrfQue()
        {
            if (ic.iniC.statusAppDonor.Equals("1"))
            {
                setGrfQueDonor(txtSearch.Text);
            }
            else
            {
                setGrfQue(txtSearch.Text);
            }
        }
        private void setGrfQueDonor(String search)
        {
            //grfDept.Rows.Count = 7;
            grfQue.Clear();
            DataTable dt = new DataTable();
            if (search.Equals(""))
            {
                String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
                //MessageBox.Show("date "+date, "");
                String date1 = ic.datetoDB(txtDateStart.Text);
                //MessageBox.Show("date1"+date1, "date "+date);
                dt = ic.ivfDB.vsDB.selectByStatusNurseWaiting(ic.datetoDB(txtDateStart.Text));
            }
            else
            {
                //grfPtt.DataSource = ic.ivfDB.vsOldDB.selectCurrentVisit(search);
            }

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfQue.Rows.Count = dt.Rows.Count + 1;
            grfQue.Cols.Count = 10;
            C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfQue.Cols[colPttHn].Editor = txt;
            grfQue.Cols[colPttName].Editor = txt;
            grfQue.Cols[colVsDate].Editor = txt;

            grfQue.Cols[colVNshow].Width = 120;
            grfQue.Cols[colPttHn].Width = 120;
            grfQue.Cols[colPttName].Width = 300;
            grfQue.Cols[colVsDate].Width = 100;
            grfQue.Cols[colVsTime].Width = 80;
            grfQue.Cols[colVsEtime].Width = 80;
            grfQue.Cols[colStatus].Width = 200;

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

            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("&receive operation", new EventHandler(ContextMenu_Apm));
            menuGw.MenuItems.Add("&Order Entry", new EventHandler(ContextMenu_order));
            menuGw.MenuItems.Add("&LAB request FORM A", new EventHandler(ContextMenu_LAB_req_formA));
            menuGw.MenuItems.Add("&Add Appointment", new EventHandler(ContextMenu_Apm));
            menuGw.MenuItems.Add("&Cancel Receive", new EventHandler(ContextMenu_Apm));
            menuGw.MenuItems.Add("&No Appointment Close Operation", new EventHandler(ContextMenu_NO_Apm));
            
            grfQue.ContextMenu = menuGw;

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    grfQue[i, 0] = i;
                    grfQue[i, colID] = row["id"].ToString();
                    grfQue[i, colVNshow] = row["VN"].ToString();
                    grfQue[i, colPttHn] = row["PIDS"].ToString();
                    grfQue[i, colPttName] = row["PName"].ToString();
                    grfQue[i, colVsDate] = ic.datetoShow(row["VDate"]);
                    grfQue[i, colVsTime] = ic.timetoShow(row["VStartTime"]);
                    grfQue[i, colVsEtime] = row["VEndTime"].ToString();
                    grfQue[i, colStatus] = row["VName"].ToString();
                    grfQue[i, colPttId] = row["PID"].ToString();
                    //if (i % 2 == 0)
                    //    grfPtt.Rows[i].StyleNew.BackColor = color;
                    i++;
                }
                catch (Exception ex)
                {

                }
            }
            grfQue.Cols[colID].Visible = false;
            grfQue.Cols[colPttId].Visible = false;
            grfQue.Cols[colStatus].Visible = false;
            //theme1.SetTheme(grfQue, ic.theme);

        }
        private void setGrfQue(String search)
        {
            //grfDept.Rows.Count = 7;
            grfQue.Clear();
            DataTable dt1 = new DataTable();
            DataTable dt = new DataTable();
            if (search.Equals(""))
            {
                String date = "";
                DateTime dt11 = new  DateTime();
                if(DateTime.TryParse(txtDateStart.Text, out dt11))
                {
                    //dt11 = dt11.AddDays(-1);
                    date = dt11.Year + "-" + dt11.ToString("MM-dd");
                    //dt = ic.ivfDB.ovsDB.selectByDate(date);
                }
                dt = ic.ivfDB.ovsDB.selectByReceptionSend();
            }
            else
            {
                //grfPtt.DataSource = ic.ivfDB.vsOldDB.selectCurrentVisit(search);
            }

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfQue.Rows.Count = dt.Rows.Count + 1;
            grfQue.Cols.Count = 11;
            C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfQue.Cols[colPttHn].Editor = txt;
            grfQue.Cols[colPttName].Editor = txt;
            grfQue.Cols[colVsDate].Editor = txt;

            grfQue.Cols[colVNshow].Width = 80;
            grfQue.Cols[colPttHn].Width = 120;
            grfQue.Cols[colPttName].Width = 300;
            grfQue.Cols[colVsDate].Width = 100;
            grfQue.Cols[colVsTime].Width = 80;
            grfQue.Cols[colVsEtime].Width = 80;
            grfQue.Cols[colStatus].Width = 200;

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

            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&receive operation", new EventHandler(ContextMenu_Apm));
            menuGw.MenuItems.Add("receive operation", new EventHandler(ContextMenu_order));
            menuGw.MenuItems.Add("LAB request FORM A", new EventHandler(ContextMenu_LAB_req_formA_Ptt));
            menuGw.MenuItems.Add("LAB FORM DAY1", new EventHandler(ContextMenu_LAB_req_form_day1));
            menuGw.MenuItems.Add("&Add Appointment", new EventHandler(ContextMenu_Apm_Ptt));
            menuGw.MenuItems.Add("&Cancel Receive", new EventHandler(ContextMenu_Apm_Ptt));
            menuGw.MenuItems.Add("&No Appointment Close Operation", new EventHandler(ContextMenu_NO_Apm_Ptt));
            menuGw.MenuItems.Add("Print Pre-Operation Check List", new EventHandler(ContextMenu_prn_check_list));
            menuGw.MenuItems.Add("Print Autherization Form", new EventHandler(ContextMenu_prn_authen_sign));
            grfQue.ContextMenu = menuGw;

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
                grfQue[i, colVn] = row["VN"].ToString();
                grfQue[i, colPttHn] = row["PIDS"].ToString();
                grfQue[i, colPttName] = row["PName"].ToString();
                grfQue[i, colVsDate] = ic.datetoShow(row["VDate"]);
                grfQue[i, colVsTime] = row["VStartTime"].ToString();
                grfQue[i, colVsEtime] = row["VEndTime"].ToString();
                grfQue[i, colStatus] = row["VName"].ToString();
                grfQue[i, colPttId] = row["PID"].ToString();
                if (!row[ic.ivfDB.ovsDB.vsold.form_a_id].ToString().Equals("0"))
                {
                    CellNote note = new CellNote("ส่ง Lab Request Foam A");
                    CellRange rg = grfQue.GetCellRange(i, colVNshow);
                    rg.UserData = note;
                }
                //if (i % 2 == 0)
                //    grfPtt.Rows[i].StyleNew.BackColor = color;
                i++;
            }
            CellNoteManager mgr = new CellNoteManager(grfQue);
            grfQue.Cols[colID].Visible = false;
            grfQue.Cols[colVn].Visible = false;
            //theme1.SetTheme(grfQue, ic.theme);

        }
        private void ContextMenu_prn_authen_sign_finish(object sender, System.EventArgs e)
        {
            String chk = "", name = "", vsid = "", pttId = "", hn = "";

            vsid = grfQue[grfQue.Row, colID] != null ? grfQue[grfQue.Row, colID].ToString() : "";
            pttId = grfQue[grfQue.Row, colPttId] != null ? grfQue[grfQue.Row, colPttId].ToString() : "";
            name = grfQue[grfQue.Row, colPttName] != null ? grfQue[grfQue.Row, colPttName].ToString() : "";
            hn = grfQue[grfQue.Row, colPttHn] != null ? grfQue[grfQue.Row, colPttHn].ToString() : "";
            FrmReport frm = new FrmReport(ic);
            frm.setOpdAuthenSign(name, hn);
            frm.ShowDialog(this);
        }
        private void ContextMenu_prn_check_list_finish(object sender, System.EventArgs e)
        {
            String chk = "", name = "", vsid = "", pttId = "";

            vsid = grfQue[grfQue.Row, colID] != null ? grfQue[grfQue.Row, colID].ToString() : "";
            pttId = grfQue[grfQue.Row, colPttId] != null ? grfQue[grfQue.Row, colPttId].ToString() : "";
            name = grfQue[grfQue.Row, colPttName] != null ? grfQue[grfQue.Row, colPttName].ToString() : "";
            FrmReport frm = new FrmReport(ic);
            frm.setOpdCheckList(name);
            frm.ShowDialog(this);
        }
        private void ContextMenu_prn_authen_sign(object sender, System.EventArgs e)
        {
            String chk = "", name = "", vsid = "", pttId = "", hn="";

            vsid = grfQue[grfQue.Row, colID] != null ? grfQue[grfQue.Row, colID].ToString() : "";
            pttId = grfQue[grfQue.Row, colPttId] != null ? grfQue[grfQue.Row, colPttId].ToString() : "";
            name = grfQue[grfQue.Row, colPttName] != null ? grfQue[grfQue.Row, colPttName].ToString() : "";
            hn = grfQue[grfQue.Row, colPttHn] != null ? grfQue[grfQue.Row, colPttHn].ToString() : "";
            FrmReport frm = new FrmReport(ic);
            frm.setOpdAuthenSign(name, hn);
            frm.ShowDialog(this);
        }
        private void ContextMenu_prn_check_list(object sender, System.EventArgs e)
        {
            String chk = "", name = "", vsid = "", pttId = "";

            vsid = grfQue[grfQue.Row, colID] != null ? grfQue[grfQue.Row, colID].ToString() : "";
            pttId = grfQue[grfQue.Row, colPttId] != null ? grfQue[grfQue.Row, colPttId].ToString() : "";
            name = grfQue[grfQue.Row, colPttName] != null ? grfQue[grfQue.Row, colPttName].ToString() : "";
            FrmReport frm = new FrmReport(ic);
            frm.setOpdCheckList(name);
            frm.ShowDialog(this);
        }
        private void ContextMenu_Finish_Apm(object sender, System.EventArgs e)
        {
            String chk = "", name = "", vsid = "", pttId = "";

            vsid = grfFinish[grfFinish.Row, colID] != null ? grfFinish[grfFinish.Row, colID].ToString() : "";
            pttId = grfFinish[grfFinish.Row, colPttId] != null ? grfFinish[grfFinish.Row, colPttId].ToString() : "";
            chk = grfFinish[grfFinish.Row, colPttHn] != null ? grfFinish[grfFinish.Row, colPttHn].ToString() : "";
            name = grfFinish[grfFinish.Row, colPttName] != null ? grfFinish[grfFinish.Row, colPttName].ToString() : "";
            //FrmNurseAdd frm = new FrmNurseAdd();
            //frm.ShowDialog(this);
            openApmAdd(pttId, vsid, name);
            //if (MessageBox.Show("ต้องการ แก้ไข Patient  \n  hn number " + chk + " \n name " + name, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            //grfReq.Rows.Remove(grfReq.Row);
            //openPatientAdd(id, name);
            //}
        }
        private void ContextMenu_NO_Apm(object sender, System.EventArgs e)
        {
            String chk = "", name = "", vsid = "", pttId = "";

            vsid = grfQue[grfQue.Row, colID] != null ? grfQue[grfQue.Row, colID].ToString() : "";
            pttId = grfQue[grfQue.Row, colPttId] != null ? grfQue[grfQue.Row, colPttId].ToString() : "";
            chk = grfQue[grfQue.Row, colPttHn] != null ? grfQue[grfQue.Row, colPttHn].ToString() : "";
            name = grfQue[grfQue.Row, colPttName] != null ? grfQue[grfQue.Row, colPttName].ToString() : "";
            //FrmNurseAdd frm = new FrmNurseAdd();
            //frm.ShowDialog(this);
            //openApmAdd(pttId, vsid, name);
            if (MessageBox.Show("ต้องการ Close Operation    \n  hn number " + chk + " \n name " + name, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                String re = "";
                re = ic.ivfDB.vsDB.updateCloseStatusNurse(vsid);
                if (re.Equals("1"))
                {
                    setGrfQue();
                }                
            }
        }
        private void ContextMenu_NO_Apm_Ptt(object sender, System.EventArgs e)
        {
            String chk = "", name = "", vsid = "", pttId = "";
            if (grfQue.Row < 0) return;
            vsid = grfQue[grfQue.Row, colID] != null ? grfQue[grfQue.Row, colID].ToString() : "";
            pttId = grfQue[grfQue.Row, colPttId] != null ? grfQue[grfQue.Row, colPttId].ToString() : "";
            chk = grfQue[grfQue.Row, colPttHn] != null ? grfQue[grfQue.Row, colPttHn].ToString() : "";
            name = grfQue[grfQue.Row, colPttName] != null ? grfQue[grfQue.Row, colPttName].ToString() : "";
            //FrmNurseAdd frm = new FrmNurseAdd();
            //frm.ShowDialog(this);
            //openApmAdd(pttId, vsid, name);
            if (MessageBox.Show("ต้องการ Close Operation    \n  hn number " + chk + " \n name " + name, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                String re = "";
                re = ic.ivfDB.vsDB.updateCloseStatusNurse(vsid);
                if (re.Equals("1"))
                {
                    setGrfQue();
                }
            }
        }
        private void ContextMenu_Result_Lab_OPU(object sender, System.EventArgs e)
        {
            String chk = "", name = "", reqid = "", pttId = "";
            if (grfLab.Row < 0) return;

            reqid = grfLab[grfLab.Row, colRID] != null ? grfLab[grfLab.Row, colRID].ToString() : "";
            LabRequest req = new LabRequest();
            req = ic.ivfDB.lbReqDB.selectByPk1(reqid);
            LabOpu opu = new LabOpu();
            opu = ic.ivfDB.opuDB.selectByPk1(req.req_id);
            FrmLabOPUAdd2 frm = new FrmLabOPUAdd2(ic,"", opu.opu_id);
            String txt = "";
            if (!name.Equals(""))
            {
                txt = " " + name;
            }

            frm.FormBorderStyle = FormBorderStyle.None;
            menu.AddNewTab(frm, txt);
            //pttId = grfLab[grfLab.Row, colPttId] != null ? grfLab[grfLab.Row, colPttId].ToString() : "";
            //chk = grfLab[grfLab.Row, colPttHn] != null ? grfLab[grfLab.Row, colPttHn].ToString() : "";
            //name = grfLab[grfLab.Row, colPttName] != null ? grfLab[grfLab.Row, colPttName].ToString() : "";
            //FrmNurseAdd frm = new FrmNurseAdd();
            //frm.ShowDialog(this);
            //openApmAdd(pttId, vsid, name);

        }
        private void ContextMenu_LAB_req_formA_Ptt_finish(object sender, System.EventArgs e)
        {
            String chk = "", name = "", vsid = "", pttId = "";
            if (grfFinish.Row < 0) return;
            vsid = grfFinish[grfFinish.Row, colID] != null ? grfFinish[grfFinish.Row, colID].ToString() : "";
            pttId = grfFinish[grfFinish.Row, colPttId] != null ? grfFinish[grfFinish.Row, colPttId].ToString() : "";
            chk = grfFinish[grfFinish.Row, colPttHn] != null ? grfFinish[grfFinish.Row, colPttHn].ToString() : "";
            name = grfFinish[grfFinish.Row, colPttName] != null ? grfFinish[grfFinish.Row, colPttName].ToString() : "";
            //reqid = ic.ivfDB.oJsDB.selectByStatusOPU(vsid);
            //if (!reqid.Equals(""))
            //{
                FrmLabFormA frm = new FrmLabFormA(ic, "", pttId, "", vsid);
                frm.ShowDialog(this);
                setGrfFinish("");
            //}
                //FrmNurseAdd frm = new FrmNurseAdd();
                //frm.ShowDialog(this);
                //openApmAdd(pttId, vsid, name);
            //if (MessageBox.Show("ต้องการป้อน LAB request FORM A\n  hn number " + chk + " \n name " + name, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
                
                //grfReq.Rows.Remove(grfReq.Row);
                //openPatientAdd(id, name);
            //}
        }
        private void ContextMenu_LAB_req_formA_Ptt_search(object sender, System.EventArgs e)
        {
            String chk = "", name = "", vsid = "", pttId = "";
            if (grfSearch.Row < 0) return;
            vsid = grfSearch[grfSearch.Row, colSID] != null ? grfSearch[grfSearch.Row, colSID].ToString() : "";
            pttId = grfSearch[grfSearch.Row, colPttId] != null ? grfSearch[grfSearch.Row, colPttId].ToString() : "";
            chk = grfSearch[grfSearch.Row, colPttHn] != null ? grfSearch[grfSearch.Row, colPttHn].ToString() : "";
            name = grfSearch[grfSearch.Row, colPttName] != null ? grfSearch[grfSearch.Row, colPttName].ToString() : "";
            
            FrmLabFormA frm = new FrmLabFormA(ic, "", pttId, "", vsid);
            frm.ShowDialog(this);
            setGrfSearch(txtSearch.Text.Trim());
            
        }
        private void ContextMenu_LAB_req_formA_Ptt(object sender, System.EventArgs e)
        {
            String chk = "", name = "", vsid = "", pttId = "";
            if (grfQue.Row < 0) return;
            vsid = grfQue[grfQue.Row, colID] != null ? grfQue[grfQue.Row, colID].ToString() : "";
            pttId = grfQue[grfQue.Row, colPttId] != null ? grfQue[grfQue.Row, colPttId].ToString() : "";
            chk = grfQue[grfQue.Row, colPttHn] != null ? grfQue[grfQue.Row, colPttHn].ToString() : "";
            name = grfQue[grfQue.Row, colPttName] != null ? grfQue[grfQue.Row, colPttName].ToString() : "";
            //reqid = ic.ivfDB.oJsDB.selectByStatusOPU(vsid);
            //if (!reqid.Equals(""))
            //{
                FrmLabFormA frm = new FrmLabFormA(ic, "", pttId, "", vsid);
                frm.ShowDialog(this);
                setGrfQue();
            //}
            //FrmNurseAdd frm = new FrmNurseAdd();ContextMenu_LAB_req_form_day1
            //frm.ShowDialog(this);
            //openApmAdd(pttId, vsid, name);
            //if (MessageBox.Show("ต้องการป้อน LAB request FORM A\n  hn number " + chk + " \n name " + name, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{

            //grfReq.Rows.Remove(grfReq.Row);
            //openPatientAdd(id, name);
            //}
        }
        private void ContextMenu_LAB_req_form_day1(object sender, System.EventArgs e)
        {
            String chk = "", name = "", vsid = "", pttId = "";
            if (grfQue.Row < 0) return;
            vsid = grfQue[grfQue.Row, colID] != null ? grfQue[grfQue.Row, colID].ToString() : "";
            pttId = grfQue[grfQue.Row, colPttId] != null ? grfQue[grfQue.Row, colPttId].ToString() : "";
            chk = grfQue[grfQue.Row, colPttHn] != null ? grfQue[grfQue.Row, colPttHn].ToString() : "";
            name = grfQue[grfQue.Row, colPttName] != null ? grfQue[grfQue.Row, colPttName].ToString() : "";
            //reqid = ic.ivfDB.oJsDB.selectByStatusOPU(vsid);
            //if (!reqid.Equals(""))
            //{
            FrmLabFormDay1 frm = new FrmLabFormDay1(ic, "", pttId, "", vsid);
            frm.ShowDialog(this);
            setGrfQue();
            
        }
        private void ContextMenu_LAB_req_formA(object sender, System.EventArgs e)
        {
            String chk = "", name = "", vsid = "", pttId = "";

            vsid = grfQue[grfQue.Row, colID] != null ? grfQue[grfQue.Row, colID].ToString() : "";
            pttId = grfQue[grfQue.Row, colPttId] != null ? grfQue[grfQue.Row, colPttId].ToString() : "";
            chk = grfQue[grfQue.Row, colPttHn] != null ? grfQue[grfQue.Row, colPttHn].ToString() : "";
            name = grfQue[grfQue.Row, colPttName] != null ? grfQue[grfQue.Row, colPttName].ToString() : "";
            //FrmNurseAdd frm = new FrmNurseAdd();
            //frm.ShowDialog(this);
            //openApmAdd(pttId, vsid, name);
            if (MessageBox.Show("ต้องการป้อน LAB request FORM A\n  hn number " + chk + " \n name " + name, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                FrmLabFormA frm = new FrmLabFormA(ic,"", pttId, vsid, "");
                frm.ShowDialog(this);
                //grfReq.Rows.Remove(grfReq.Row);
                //openPatientAdd(id, name);
            }
        }
        private void ContextMenu_Apm_Finish(object sender, System.EventArgs e)
        {
            String chk = "", name = "", vsid = "", pttId = "";
            if (grfFinish.Row < 0) return;

            vsid = grfFinish[grfFinish.Row, colID] != null ? grfFinish[grfFinish.Row, colID].ToString() : "";
            pttId = grfFinish[grfFinish.Row, colPttId] != null ? grfFinish[grfFinish.Row, colPttId].ToString() : "";
            chk = grfFinish[grfFinish.Row, colPttHn] != null ? grfFinish[grfFinish.Row, colPttHn].ToString() : "";
            name = grfFinish[grfFinish.Row, colPttName] != null ? grfFinish[grfFinish.Row, colPttName].ToString() : "";
            //FrmNurseAdd frm = new FrmNurseAdd();
            //frm.ShowDialog(this);
            openApmAdd(pttId, vsid, name);
            //if (MessageBox.Show("ต้องการ แก้ไข Patient  \n  hn number " + chk + " \n name " + name, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            //grfReq.Rows.Remove(grfReq.Row);
            //openPatientAdd(id, name);
            //}
        }
        private void ContextMenu_Apm(object sender, System.EventArgs e)
        {
            String chk = "", name = "", vsid = "", pttId="";
            if (grfQue.Row < 0) return;

            vsid = grfQue[grfQue.Row, colID] != null ? grfQue[grfQue.Row, colID].ToString() : "";
            pttId = grfQue[grfQue.Row, colPttId] != null ? grfQue[grfQue.Row, colPttId].ToString() : "";
            chk = grfQue[grfQue.Row, colPttHn] != null ? grfQue[grfQue.Row, colPttHn].ToString() : "";
            name = grfQue[grfQue.Row, colPttName] != null ? grfQue[grfQue.Row, colPttName].ToString() : "";
            //FrmNurseAdd frm = new FrmNurseAdd();
            //frm.ShowDialog(this);
            openApmAdd(pttId, vsid, name);
            //if (MessageBox.Show("ต้องการ แก้ไข Patient  \n  hn number " + chk + " \n name " + name, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            //grfReq.Rows.Remove(grfReq.Row);
            //openPatientAdd(id, name);
            //}
        }
        private void ContextMenu_Apm_Ptt(object sender, System.EventArgs e)
        {
            String chk = "", name = "", vsid = "", pttId = "";
            if (grfQue.Row < 0) return;
            vsid = grfQue[grfQue.Row, colID] != null ? grfQue[grfQue.Row, colID].ToString() : "";
            pttId = grfQue[grfQue.Row, colPttId] != null ? grfQue[grfQue.Row, colPttId].ToString() : "";
            chk = grfQue[grfQue.Row, colPttHn] != null ? grfQue[grfQue.Row, colPttHn].ToString() : "";
            name = grfQue[grfQue.Row, colPttName] != null ? grfQue[grfQue.Row, colPttName].ToString() : "";
            //FrmNurseAdd frm = new FrmNurseAdd();
            //frm.ShowDialog(this);
            openApmAdd(pttId, vsid, name);
            //if (MessageBox.Show("ต้องการ แก้ไข Patient  \n  hn number " + chk + " \n name " + name, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            //grfReq.Rows.Remove(grfReq.Row);
            //openPatientAdd(id, name);
            //}
        }
        private void ContextMenu_order_finish(object sender, System.EventArgs e)
        {
            String chk = "", name = "", vn = "", pttId = "";

            vn = grfFinish[grfFinish.Row, colVNshow] != null ? grfFinish[grfFinish.Row, colVNshow].ToString() : "";
            pttId = grfFinish[grfFinish.Row, colPttId] != null ? grfFinish[grfFinish.Row, colPttId].ToString() : "";
            chk = grfFinish[grfFinish.Row, colPttHn] != null ? grfFinish[grfFinish.Row, colPttHn].ToString() : "";
            name = grfFinish[grfFinish.Row, colPttName] != null ? grfFinish[grfFinish.Row, colPttName].ToString() : "";
            //FrmNurseAdd frm = new FrmNurseAdd();
            //frm.ShowDialog(this);

            openNurseAdd(pttId, vn, name, "view");
            //if (MessageBox.Show("ต้องการ แก้ไข Patient  \n  hn number " + chk + " \n name " + name, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            //grfReq.Rows.Remove(grfReq.Row);
            //openPatientAdd(id, name);
            //}
        }
        private void ContextMenu_order(object sender, System.EventArgs e)
        {
            String chk = "", name = "", id = "", pttId = "";

            id = grfQue[grfQue.Row, colID] != null ? grfQue[grfQue.Row, colID].ToString() : "";
            pttId = grfQue[grfQue.Row, colPttId] != null ? grfQue[grfQue.Row, colPttId].ToString() : "";
            chk = grfQue[grfQue.Row, colPttHn] != null ? grfQue[grfQue.Row, colPttHn].ToString() : "";
            name = grfQue[grfQue.Row, colPttName] != null ? grfQue[grfQue.Row, colPttName].ToString() : "";
            //FrmNurseAdd frm = new FrmNurseAdd();
            //frm.ShowDialog(this);

            openNurseAdd(pttId, id, name, "edit");
            //if (MessageBox.Show("ต้องการ แก้ไข Patient  \n  hn number " + chk + " \n name " + name, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            //grfReq.Rows.Remove(grfReq.Row);
            //openPatientAdd(id, name);
            //}
        }
        private void openNurseAdd(String pttId, String vsid, String name, String flagview)
        {
            FrmNurseAdd frm = new FrmNurseAdd(ic, menu, pttId, vsid, flagview);
            String txt = "";
            if (!name.Equals(""))
            {
                txt = " " + name;
            }            

            frm.FormBorderStyle = FormBorderStyle.None;
            C1DockingTabPage tab = menu.AddNewTab(frm, txt);
            frm.tab = tab;
        }
        private void openApmAdd(String pttId, String vsid, String name)
        {
            if (ic.iniC.statusAppDonor.Equals("1"))
            {
                FrmAppointmentDonorAdd frm = new FrmAppointmentDonorAdd(ic, "", pttId, vsid);
                frm.ShowDialog(this);
            }
            else
            {
                FrmAppointmentAdd frm = new FrmAppointmentAdd(ic, "", pttId, vsid);
                frm.ShowDialog(this);
            }
        }
        private void FrmNurseView_Load(object sender, EventArgs e)
        {
            tC.SelectedTab = tabWaiting;
        }
    }
}
