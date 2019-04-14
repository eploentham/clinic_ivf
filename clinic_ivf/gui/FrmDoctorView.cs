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
    public partial class FrmDoctorView : Form
    {
        IvfControl ic;
        MainMenu menu;

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;

        C1FlexGrid grfQue, grfDiag, grfFinish, grfSearch, grfLab;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        Timer timer;
        int colID = 1, colVNshow = 2, colPttHn = 3, colPttName = 4, colVsDate = 5, colVsTime = 6, colVsEtime = 7, colStatus = 8, colPttId = 9, colVn = 10;
        int colSID = 1, colSVN = 2, colSPttHn = 3, colSPttName = 4, colSVsDate = 5, colSVsTime = 6, colSVsEtime = 7, colSStatus = 8, colSPttId = 9;
        int colRID = 1, colRVN = 2, colRPttHn = 3, colRPttName = 4, colRVsDate = 5, colRPttId = 6;

        public FrmDoctorView(IvfControl ic, MainMenu m)
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

            //btnNew.Click += BtnNew_Click;
            txtSearch.KeyUp += TxtSearch_KeyUp;
            //txtDateStart.ValueChanged += TxtDateStart_ValueChanged;
            txtDateStart.DropDownClosed += TxtDateStart_DropDownClosed;
            tC.SelectedTabChanged += TC_SelectedTabChanged;
            btnSearch.Click += BtnSearch_Click;
            //txtSearch.KeyUp += TxtSearch_KeyUp1;
            
            initGrfQue();
            setGrfQue();
            initGrfDiag();
            setGrfDiag("");
            initGrfFinish();
            setGrfFinish("");
            initGrfSearch();
            

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
        }

        private void TxtDateStart_DropDownClosed(object sender, C1.Win.C1Input.DropDownClosedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void TC_SelectedTabChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void TxtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
        }
        private void openDtrAdd1()
        {
            String chk = "", name = "", id = "", pttId = "";

            id = grfQue[grfQue.Row, colID] != null ? grfQue[grfQue.Row, colID].ToString() : "";
            pttId = grfQue[grfQue.Row, colPttId] != null ? grfQue[grfQue.Row, colPttId].ToString() : "";
            chk = grfQue[grfQue.Row, colPttHn] != null ? grfQue[grfQue.Row, colPttHn].ToString() : "";
            name = grfQue[grfQue.Row, colPttName] != null ? grfQue[grfQue.Row, colPttName].ToString() : "";
            //FrmNurseAdd frm = new FrmNurseAdd();
            //frm.ShowDialog(this);

            openDtrAdd(pttId, id, name);
        }
        private void openDtrAdd(String pttId, String vsid, String name)
        {
            FrmDoctorAdd frm = new FrmDoctorAdd(ic, menu, pttId, vsid);
            String txt = "";
            if (!name.Equals(""))
            {
                txt = " " + name;
            }

            frm.FormBorderStyle = FormBorderStyle.None;
            C1DockingTabPage tab = menu.AddNewTab(frm, txt);
            frm.tab = tab;
        }
        private void initGrfQue()
        {
            grfQue = new C1FlexGrid();
            grfQue.Font = fEdit;
            grfQue.Dock = System.Windows.Forms.DockStyle.Fill;
            grfQue.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            grfQue.AfterRowColChange += GrfQue_AfterRowColChange;
            grfQue.DoubleClick += GrfQue_DoubleClick;
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

        private void GrfQue_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfQue.Row < 0) return;
            openDtrAdd1();
            //String id = grfQue[grfQue.Row, colID] != null ? grfQue[grfQue.Row, colID].ToString() : "";
            //String name = grfQue[grfQue.Row, colPttName] != null ? grfQue[grfQue.Row, colPttName].ToString() : "";
            //String pttid = grfQue[grfQue.Row, colPttId] != null ? grfQue[grfQue.Row, colPttId].ToString() : "";
            //openDtrAdd(pttid,id, name);
        }

        private void GrfQue_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;
        }
        private void setGrfQue()
        {            
            //grfDept.Rows.Count = 7;
            grfQue.Clear();
            DataTable dt1 = new DataTable();
            DataTable dt = new DataTable();
            if (txtSearch.Text.Equals(""))
            {
                String date = "";
                DateTime dt11 = new DateTime();
                if (DateTime.TryParse(txtDateStart.Text, out dt11))
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
            grfQue.Cols[colVNshow].AllowEditing = false;
            grfQue.Cols[colPttHn].AllowEditing = false;
            grfQue.Cols[colPttName].AllowEditing = false;
            grfQue.Cols[colVsDate].AllowEditing = false;
            //theme1.SetTheme(grfQue, ic.theme);

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
        private void GrfDiag_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();

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
        private void FrmDoctorView_Load(object sender, EventArgs e)
        {

        }
    }
}
