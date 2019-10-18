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
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
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

        int colID = 1, colVNshow = 2, colPttHn = 3, colPttName = 4, colPttHn1=5, colPttName1=6, colPttHn2=7, colPttName2=8, colVsAgent=9, colVsDate = 10, colVsTime = 11, colVsEtime = 12, colStatus = 13, colPttId=14, colVn=15, colDtr=16, colPID=17, colFormAId=18, colFormACode=19, colStatusOPU=20, colStatusFet=21, colStatusAna=22, colStatusFreezing=23, colStatusPesa=24, colStatusIUI=25;
        int colSID = 1, colSVN = 2, colSPttHn = 3, colSPttName = 4, colSVsDate = 5, colSVsTime = 6, colSVsEtime = 7, colSStatus = 8, colSPttId = 9;
        int colRID = 1, colRVN = 2, colRPttHn = 3, colRPttName = 4, colRVsDate = 5, colRPttId = 6;
        int colLID = 1, colLVNShow = 2, colLPttHnFemale = 3, colLPttNameFemale = 4, colLPttHnMale = 5, colLPttNameMale = 6, colLlabname = 7, colLStatus = 8, colLLGID=9;

        C1FlexGrid grfQue, grfDiag, grfFinish, grfSearch, grfLab;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        Timer timer;
        String printerOld = "";

        Boolean pageLoad = false;
        Image imgCorr, imgTran;
        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetDefaultPrinter(string Printer);
        public FrmNurseView(IvfControl ic, MainMenu m)
        {
            InitializeComponent();
            this.ic = ic;
            menu = m;
            initConfig();
        }
        private void initConfig()
        {
            pageLoad = true;
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
            imgCorr = Resources.red_checkmark_png_16;
            imgTran = Resources.red_checkmark_png_51;

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();

            txtDateStart.Value = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            //txtLabResultDate.Value = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            //btnNew.Click += BtnNew_Click;
            txtSearch.KeyUp += TxtSearch_KeyUp;
            //txtDateStart.ValueChanged += TxtDateStart_ValueChanged;
            txtDateStart.DropDownClosed += TxtDateStart_DropDownClosed;
            tC.SelectedTabChanged += TC_SelectedTabChanged;
            btnSearch.Click += BtnSearch_Click;
            //txtSearch.KeyUp += TxtSearch_KeyUp1;
            //txtLabResultDate.KeyUp += TxtLabResultDate_KeyUp;
            chkAll.CheckedChanged += ChkAll_CheckedChanged;
            cboVisitBsp.SelectedItemChanged += CboVisitBsp_SelectedItemChanged;
            btnLabResultSearch.Click += BtnLabResultSearch_Click;

            ic.ivfDB.bspDB.setCboBsp(cboVisitBsp, ic.iniC.service_point_id);

            initGrfQue();
            setGrfQue();
            initGrfDiag();
            setGrfDiag("");
            initGrfFinish();
            setGrfFinish();
            initGrfSearch();
            initGrfLab();
            setGrfLab("");

            int timerlab = 0;
            int.TryParse(ic.iniC.timerlabreqaccept, out timerlab);
            timer = new Timer();
            timer.Interval = timerlab * 1000;
            timer.Tick += Timer_Tick;
            timer.Enabled = true;
            pageLoad = false;
        }

        private void BtnLabResultSearch_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setGrfLab(txtLabResultHn.Text);
        }

        private void CboVisitBsp_SelectedItemChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (pageLoad) return;
            setGrfQue();
        }

        private void ChkAll_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setGrfQue();
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
            //if (e.KeyCode == Keys.Enter)
            //{
            //    setGrfLab(txtLabResultHn.Text.Trim());
            //}
        }

        private void TxtSearch_KeyUp1(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            
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
            //if (txtDateStart.Text.Equals(""))
            //{
            //    grfQue.Rows.Count = 1;
            //    grfFinish.Rows.Count = 1;
            //    return;
            //}
            //setGrfQue();
            //setGrfFinish();
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
            else if(tC.SelectedTab == tabSearch)
            {
                txtSearch.Focus();
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
                //if (txtDateStart.Text.Equals(""))
                //{
                //    if (tabWaiting.IsSelected)
                //    {

                //    }
                //    else if (tabDiag.IsSelected)
                //    {

                //    }
                //    else if (tabFinish.IsSelected)
                //    {
                //        setGrfFinish();
                //    }
                //}
                //else
                //{
                //    setGrfQue(txtSearch.Text);
                //}
                //if (e.KeyCode == Keys.Enter)
                //{
                setGrfSearch(txtSearch.Text.Trim());
                //}
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
                        //setGrfQue(txtSearch.Text);    //62-08-15
                        setGrfSearch(txtSearch.Text);    //62-08-15
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
            grfFinish.Name = "grfFinish";
            //FilterRow fr = new FilterRow(grfExpn);

            grfFinish.AfterRowColChange += GrfFinish_AfterRowColChange;
            grfFinish.DoubleClick += GrfFinish_DoubleClick;
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

        private void GrfFinish_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ContextMenu_order_finish(null, null);
        }

        private void GrfFinish_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();

        }
        public void setGrfFinishPublic()
        {
            setGrfFinish();
        }
        private void setGrfFinish()
        {
            if (ic.iniC.statusAppDonor.Equals("1"))
            {
                setGrfFinishDonor(txtSearch.Text);
            }
            else
            {
                //setGrfFinish(txtSearch.Text);
                setGrfFinish("");
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
            grfFinish.Cols.Count = 18;
            C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            //grfFinish.Cols[colPttHn].Editor = txt;
            //grfFinish.Cols[colPttName].Editor = txt;
            //grfFinish.Cols[colVsDate].Editor = txt;

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
            menuGw.MenuItems.Add("&Receive operation", new EventHandler(ContextMenu_order_finish));
            menuGw.MenuItems.Add("&LAB request FORM A", new EventHandler(ContextMenu_LAB_req_formA_Ptt_finish));
            menuGw.MenuItems.Add("LAB Form Day1", new EventHandler(ContextMenu_Form_day1));
            //menuGw.MenuItems.Add("&Order Entry", new EventHandler(ContextMenu_Apm));
            menuGw.MenuItems.Add("&Edit Appointment", new EventHandler(ContextMenu_Finish_Apm));
            //menuGw.MenuItems.Add("&Cancel Receive", new EventHandler(ContextMenu_Apm));
            MenuItem addDevice = new MenuItem("[Form Print]");
            menuGw.MenuItems.Add(addDevice);
            //menuGw.MenuItems.Add("Print Pre-Operation Check List", new EventHandler(ContextMenu_prn_check_list_finish));
            //menuGw.MenuItems.Add("Print Autherization Form", new EventHandler(ContextMenu_prn_authen_sign_finish));
            addDevice.MenuItems.Add(new MenuItem("Pre-Operation Check List", new EventHandler(ContextMenu_prn_check_list_finish)));
            addDevice.MenuItems.Add(new MenuItem("Autherization Form", new EventHandler(ContextMenu_prn_authen_sign_finish)));
            addDevice.MenuItems.Add(new MenuItem("Order OPU", new EventHandler(ContextMenu_prn_order_opu_grfFinish)));
            addDevice.MenuItems.Add(new MenuItem("Order ET, FET", new EventHandler(ContextMenu_prn_order_et_fet_grfFinish)));
            addDevice.MenuItems.Add(new MenuItem("Post Operation Note", new EventHandler(ContextMenu_prn_operation_note_grfFinish)));
            addDevice.MenuItems.Add(new MenuItem("Patient Medical History", new EventHandler(ContextMenu_prn_pmh_grfFinish)));
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
                    grfFinish[i, colVNshow] = ic.showVN(row["VN"].ToString());
                    grfFinish[i, colPttHn] = row["PIDS"].ToString();
                    grfFinish[i, colPttName] = row["PName"].ToString();
                    grfFinish[i, colVsDate] = ic.datetoShow(row["VDate"]);
                    grfFinish[i, colVsTime] = row["VStartTime"].ToString();
                    grfFinish[i, colVsEtime] = row["VEndTime"].ToString();
                    grfFinish[i, colStatus] = row["VName"].ToString();
                    grfFinish[i, colPttId] = row["PID"].ToString();
                    grfFinish[i, colVn] = row["VN"].ToString();
                    grfFinish[i, colPID] = row["PID"].ToString();
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
            grfFinish.Cols[colPID].Visible = false;

            grfFinish.Cols[colVNshow].AllowEditing = false;
            grfFinish.Cols[colPttHn].AllowEditing = false;
            grfFinish.Cols[colPttName].AllowEditing = false;
            grfFinish.Cols[colVsDate].AllowEditing = false;
            grfFinish.Cols[colVsTime].AllowEditing = false;
            grfFinish.Cols[colVsEtime].AllowEditing = false;
            grfFinish.Cols[colStatus].AllowEditing = false;
            grfFinish.Cols[colPttId].AllowEditing = false;
            //theme1.SetTheme(grfFinish, ic.theme);

        }
        private void setGrfFinish(String search)
        {
            //grfDept.Rows.Count = 7;
            grfFinish.Clear();
            DataTable dt = new DataTable();
            if (search.Equals(""))
            {
                String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
                //dt = ic.ivfDB.ovsDB.selectByStatusNurseFinish(ic.datetoDB(txtDateStart.Text));
                dt = ic.ivfDB.ovsDB.selectByStatusNurseFinish(date);
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
            grfFinish.Cols.Count = 25;
            //C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            //grfFinish.Cols[colPttHn].Editor = txt;
            //grfFinish.Cols[colPttName].Editor = txt;
            //grfFinish.Cols[colVsDate].Editor = txt;

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
            //menuGw.MenuItems.Add("&Order Entry", new EventHandler(ContextMenu_Apm));
            menuGw.MenuItems.Add("&Edit Appointment", new EventHandler(ContextMenu_Apm_Finish));
            //menuGw.MenuItems.Add("&Cancel Receive", new EventHandler(ContextMenu_Apm));
            
            MenuItem addDevice = new MenuItem("[Form Print]");
            menuGw.MenuItems.Add(addDevice);
            //menuGw.MenuItems.Add("Print Pre-Operation Check List", new EventHandler(ContextMenu_prn_check_list_finish));
            //menuGw.MenuItems.Add("Print Autherization Form", new EventHandler(ContextMenu_prn_authen_sign_finish));
            addDevice.MenuItems.Add(new MenuItem("Pre-Operation Check List", new EventHandler(ContextMenu_prn_check_list_finish)));
            addDevice.MenuItems.Add(new MenuItem("Autherization Form", new EventHandler(ContextMenu_prn_authen_sign_finish)));
            addDevice.MenuItems.Add(new MenuItem("Order OPU", new EventHandler(ContextMenu_prn_order_opu_grfFinish)));
            addDevice.MenuItems.Add(new MenuItem("Order ET, FET", new EventHandler(ContextMenu_prn_order_et_fet_grfFinish)));
            addDevice.MenuItems.Add(new MenuItem("Post Operation Note", new EventHandler(ContextMenu_prn_operation_note_grfFinish)));
            addDevice.MenuItems.Add(new MenuItem("Patient Medical History", new EventHandler(ContextMenu_prn_pmh_grfFinish)));
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
                grfFinish[i, colVNshow] = ic.showVN(row["VN"].ToString());
                grfFinish[i, colPttHn] = row["PIDS"].ToString();
                grfFinish[i, colPttName] = row["PName"].ToString();
                grfFinish[i, colVsDate] = ic.datetoShow(row["VDate"]);
                grfFinish[i, colVsTime] = row["VStartTime"].ToString();
                grfFinish[i, colVsEtime] = row["VEndTime"].ToString();
                grfFinish[i, colStatus] = row["VName"].ToString();
                grfFinish[i, colPttId] = row["PID"].ToString();
                grfFinish[i, colVn] = row["VN"].ToString();
                grfFinish[i, colPID] = row["PID"].ToString();
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
            grfFinish.Cols[colPID].Visible = false;

            grfFinish.Cols[colVNshow].AllowEditing = false;
            grfFinish.Cols[colPttHn].AllowEditing = false;
            grfFinish.Cols[colPttName].AllowEditing = false;
            grfFinish.Cols[colVsDate].AllowEditing = false;
            grfFinish.Cols[colVsTime].AllowEditing = false;
            grfFinish.Cols[colVsEtime].AllowEditing = false;
            grfFinish.Cols[colStatus].AllowEditing = false;
            //grfFinish.Cols[colVsEtime].AllowEditing = false;
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
            grfDiag.Cols.Count = 16;
            C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            //grfDiag.Cols[colPttHn].Editor = txt;
            //grfDiag.Cols[colPttName].Editor = txt;
            //grfDiag.Cols[colVsDate].Editor = txt;

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

            grfSearch.DoubleClick += GrfSearch_DoubleClick;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            grfSearch.ContextMenu = menuGw;
            pnSearch.Controls.Add(grfSearch);
            grfSearch.Rows.Count = 1;
            theme1.SetTheme(pnSearch, "Office2010Red");

        }

        private void GrfSearch_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ContextMenu_grfSearch(null, null);
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
                //if (chkLabFormA.Checked)
                //{
                //dt = ic.ivfDB.ovsDB.selectByHNLike(search);
                if (chkPrnSticker.Checked)
                {
                    dt = ic.ivfDB.pttDB.selectByHNLike(search);
                }
                else
                {
                    dt = ic.ivfDB.vsDB.selectByHNLikeLabFormA(search);
                }
                //}
                //else
                //{
                //    dt = ic.ivfDB.ovsDB.selectByHNLike(search);
                //}
                //grfPtt.DataSource = ic.ivfDB.vsOldDB.selectCurrentVisit(search);
            }

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfSearch.Rows.Count = dt.Rows.Count + 1;
            grfSearch.Cols.Count = 26;
            //C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            //grfSearch.Cols[colPttHn].Editor = txt;
            //grfSearch.Cols[colPttName].Editor = txt;
            //grfSearch.Cols[colVsDate].Editor = txt;
            Column colOPU = grfSearch.Cols[colStatusOPU];
            colOPU.DataType = typeof(Image);
            Column colFET = grfSearch.Cols[colStatusFet];
            colFET.DataType = typeof(Image);
            Column colAna = grfSearch.Cols[colStatusAna];
            colAna.DataType = typeof(Image);
            Column colFreezing = grfSearch.Cols[colStatusFreezing];
            colFreezing.DataType = typeof(Image);
            Column colPesa = grfSearch.Cols[colStatusPesa];
            colPesa.DataType = typeof(Image);
            Column colIUI = grfSearch.Cols[colStatusIUI];
            colIUI.DataType = typeof(Image);

            grfSearch.Cols[colVNshow].Width = 80;
            grfSearch.Cols[colPttHn].Width = 100;
            grfSearch.Cols[colPttName].Width = 270;
            grfSearch.Cols[colVsDate].Width = 100;
            grfSearch.Cols[colVsTime].Width = 80;
            grfSearch.Cols[colVsEtime].Width = 80;
            grfSearch.Cols[colStatus].Width = 200;
            grfSearch.Cols[colPttHn1].Width = 100;
            grfSearch.Cols[colPttName1].Width = 220;
            grfSearch.Cols[colPttHn2].Width = 100;
            grfSearch.Cols[colPttName2].Width = 220;
            grfSearch.Cols[colFormACode].Width = 80;
            grfSearch.Cols[colStatusOPU].Width = 60;
            grfSearch.Cols[colStatusFet].Width = 60;
            grfSearch.Cols[colStatusAna].Width = 60;
            grfSearch.Cols[colStatusFreezing].Width = 60;
            grfSearch.Cols[colStatusPesa].Width = 60;
            grfSearch.Cols[colStatusIUI].Width = 60;
            grfSearch.Cols[colFormAId].Width = 40;
            grfSearch.Cols[colDtr].Width = 80;

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
            grfSearch.Cols[colPttHn1].Caption = "Hn 1";
            grfSearch.Cols[colPttName1].Caption = "Name Hn1";
            grfSearch.Cols[colPttHn2].Caption = "Hn 2";
            grfSearch.Cols[colPttName2].Caption = "Name Hn2";
            grfSearch.Cols[colFormACode].Caption = "Lab Form A";
            grfSearch.Cols[colDtr].Caption = "Doctor";
            grfSearch.Cols[colStatusOPU].Caption = "OPU";
            grfSearch.Cols[colStatusFet].Caption = "FET";
            grfSearch.Cols[colStatusAna].Caption = "SA";
            grfSearch.Cols[colStatusFreezing].Caption = "SF";
            grfSearch.Cols[colStatusPesa].Caption = "PESA";
            grfSearch.Cols[colStatusIUI].Caption = "IUI";
            grfSearch.Cols[colVsAgent].Caption = "Agent";

            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&receive operation", new EventHandler(ContextMenu_Apm));
            //menuGw.MenuItems.Add("&receive operation", new EventHandler(ContextMenu_Apm));
            if (!chkPrnSticker.Checked)     // สั่ง LAB ไม่ได้ เพราะ ไม่มี visit_id
            {
                menuGw.MenuItems.Add("&LAB request FORM A", new EventHandler(ContextMenu_LAB_req_formA_Ptt_search));
                menuGw.MenuItems.Add("LAB Form Day1", new EventHandler(ContextMenu_Form_day1));
            }
            //menuGw.MenuItems.Add("&Add Appointment", new EventHandler(ContextMenu_Apm_Ptt));
            //menuGw.MenuItems.Add("&Cancel Receive", new EventHandler(ContextMenu_Apm_Ptt));
            //menuGw.MenuItems.Add("&No Appointment Close Operation", new EventHandler(ContextMenu_NO_Apm_Ptt));
            MenuItem addDevice = new MenuItem("[Form Print]");
            menuGw.MenuItems.Add(addDevice);
            addDevice.MenuItems.Add(new MenuItem("Pre-Operation Check List", new EventHandler(ContextMenu_prn_check_list_grfSearch)));
            addDevice.MenuItems.Add(new MenuItem("Autherization Form", new EventHandler(ContextMenu_prn_authen_sign_grfSearch)));
            addDevice.MenuItems.Add(new MenuItem("Order OPU", new EventHandler(ContextMenu_prn_order_opu_grfSearch)));
            addDevice.MenuItems.Add(new MenuItem("Order ET, FET", new EventHandler(ContextMenu_prn_order_et_fet_grfSearch)));
            addDevice.MenuItems.Add(new MenuItem("Post Operation Note", new EventHandler(ContextMenu_prn_operation_note_grfSearch)));
            addDevice.MenuItems.Add(new MenuItem("Patient Medical History", new EventHandler(ContextMenu_prn_pmh_grfSearch)));
            addDevice.MenuItems.Add(new MenuItem("Print Sticker VN", new EventHandler(ContextMenu_prn_sticker_vn)));
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
                grfSearch[i, colVNshow] = ic.showVN(row["VN"].ToString());
                grfSearch[i, colPttHn] = row["PIDS"].ToString();
                grfSearch[i, colPttName] = row["PName"].ToString();
                grfSearch[i, colVsDate] = ic.datetoShow(row["VDate"]);
                //grfSearch[i, colVsTime] = row["VStartTime"].ToString();
                grfSearch[i, colDtr] = row["dtr_name"].ToString();
                
                grfSearch[i, colPttId] = row["t_patient_id"].ToString();
                grfSearch[i, colVn] = row["VN"].ToString();
                grfSearch[i, colFormAId] = row["form_a_id"].ToString();
                grfSearch[i, colFormACode] = row["form_a_code"].ToString();
                grfSearch[i, colPttHn1] = row["patient_hn_1"].ToString();
                grfSearch[i, colPttName1] = row["name_1"].ToString();
                grfSearch[i, colPttHn2] = row["patient_hn_2"].ToString();
                grfSearch[i, colPttName2] = row["name_2"].ToString();
                //grfSearch[i, colVsAgent] = row["AgentName"].ToString();

                grfSearch[i, colStatusOPU] = row[ic.ivfDB.lFormaDB.lformA.status_opu_active].ToString().Equals("1") ? imgCorr : imgTran;
                grfSearch[i, colStatusFet] = row[ic.ivfDB.lFormaDB.lformA.status_fet].ToString().Equals("1") ? imgCorr : imgTran;
                grfSearch[i, colStatusAna] = row[ic.ivfDB.lFormaDB.lformA.status_sperm_analysis].ToString().Equals("1") ? imgCorr : imgTran;
                grfSearch[i, colStatusFreezing] = row[ic.ivfDB.lFormaDB.lformA.status_sperm_freezing].ToString().Equals("1") ? imgCorr : imgTran;
                grfSearch[i, colStatusPesa] = row[ic.ivfDB.lFormaDB.lformA.status_sperm_pesa].ToString().Equals("1") ? imgCorr : imgTran;
                grfSearch[i, colStatusIUI] = row[ic.ivfDB.lFormaDB.lformA.status_sperm_iui].ToString().Equals("1") ? imgCorr : imgTran;
                grfSearch[i, colVsAgent] = row["AgentName"].ToString();
                if (!row[ic.ivfDB.ovsDB.vsold.form_a_id].ToString().Equals("0") && !row[ic.ivfDB.ovsDB.vsold.form_a_id].ToString().Equals(""))
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
            grfSearch.Cols[colStatus].Visible = false;
            grfSearch.Cols[colVsEtime].Visible = false;
            grfSearch.Cols[colVsTime].Visible = false;
            grfSearch.Cols[colVn].Visible = false;
            grfSearch.Cols[colFormAId].Visible = false;
            grfSearch.Cols[colPttId].Visible = false;
            grfSearch.Cols[colPID].Visible = false;

            grfSearch.Cols[colVNshow].AllowEditing = false;
            grfSearch.Cols[colPttHn].AllowEditing = false;
            grfSearch.Cols[colPttName].AllowEditing = false;
            grfSearch.Cols[colVsDate].AllowEditing = false;
            grfSearch.Cols[colVsTime].AllowEditing = false;
            grfSearch.Cols[colVsEtime].AllowEditing = false;
            grfSearch.Cols[colStatus].AllowEditing = false;
            grfSearch.Cols[colPttId].AllowEditing = false;
            grfSearch.Cols[colDtr].AllowEditing = false;
            grfSearch.Cols[colStatusOPU].AllowEditing = false;
            grfSearch.Cols[colStatusFet].AllowEditing = false;
            grfSearch.Cols[colStatusAna].AllowEditing = false;
            grfSearch.Cols[colStatusFreezing].AllowEditing = false;
            grfSearch.Cols[colStatusPesa].AllowEditing = false;
            grfSearch.Cols[colStatusIUI].AllowEditing = false;
            grfSearch.Cols[colVsAgent].AllowEditing = false;
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
            grfLab.DoubleClick += GrfLab_DoubleClick;
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

        private void GrfLab_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ContextMenu_Result_Lab_OPU(null, null);
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
                if (DateTime.TryParse(txtLabResultDate.Text, out dt11))
                {
                    date = dt11.Year + "-" + dt11.ToString("MM-dd");
                    dt = ic.ivfDB.lbReqDB.selectByStatusResult(date, date,"");
                }
                else
                {
                    dt = ic.ivfDB.lbReqDB.selectByStatusResult(date, date, "");
                }
            }
            else
            {
                String date1 = "";
                DateTime dt11 = new DateTime();
                DateTime.TryParse(txtLabResultDate.Text, out dt11);
                date1 = dt11.Year.ToString()+"-"+ dt11.ToString("MM-dd");

                dt = ic.ivfDB.lbReqDB.selectByStatusResult("", "",search);
                //grfPtt.DataSource = ic.ivfDB.vsOldDB.selectCurrentVisit(search);
            }

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfLab.Rows.Count = dt.Rows.Count + 1;
            grfLab.Cols.Count = 10;
            //C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            //grfLab.Cols[colPttHn].Editor = txt;
            //grfLab.Cols[colPttName].Editor = txt;
            //grfLab.Cols[colVsDate].Editor = txt;

            grfLab.Cols[colLVNShow].Width = 80;
            grfLab.Cols[colLPttHnFemale].Width = 120;
            grfLab.Cols[colLPttNameFemale].Width = 200;
            grfLab.Cols[colLPttHnMale].Width = 100;
            grfLab.Cols[colLPttNameMale].Width = 200;
            grfLab.Cols[colLlabname].Width = 120;
            //grfLab.Cols[colStatus].Width = 200;

            grfLab.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfLab.Cols[colLVNShow].Caption = "VN";
            grfLab.Cols[colLPttHnFemale].Caption = "HN Female";
            grfLab.Cols[colLPttNameFemale].Caption = "Name Female";
            grfLab.Cols[colLlabname].Caption = "LAB";
            grfLab.Cols[colLPttHnMale].Caption = "HN Male";
            grfLab.Cols[colLPttNameMale].Caption = "Name Male";
            //grfLab.Cols[colStatus].Caption = "Status";

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
                grfLab[i, colLID] = row["req_id"].ToString();
                grfLab[i, colLVNShow] = ic.showVN(row["vn"].ToString());
                grfLab[i, colLPttHnFemale] = row["hn_female"].ToString();
                grfLab[i, colLPttNameFemale] = row["name_female"].ToString();
                grfLab[i, colLPttHnMale] = row["hn_male"].ToString();
                grfLab[i, colLPttNameMale] = row["name_male"].ToString();
                grfLab[i, colLlabname] = row["LName"].ToString();
                grfLab[i, colLLGID] = row["LGID"].ToString();
                if (row["item_id"].ToString().Equals("18")){      //"Sperm Analysis" 
                    grfLab[i, colLStatus] = "1";
                }
                else if (row["item_id"].ToString().Equals("14"))   //"Sperm Freezing" 
                {
                    grfLab[i, colLStatus] = "2";
                }
                else if (row["item_id"].ToString().Equals("66"))
                {
                    grfLab[i, colLStatus] = "3";
                }
                else if (row["item_id"].ToString().Equals("88"))
                {
                    grfLab[i, colLStatus] = "4";
                }
                else if (row["item_id"].ToString().Equals("112"))        //OPU
                {
                    grfLab[i, colLStatus] = "5";
                }
                else if (row["item_id"].ToString().Equals("22"))        //FET
                {
                    grfLab[i, colLStatus] = "6";
                }
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
            grfLab.Cols[colLID].Visible = false;
            grfLab.Cols[colLLGID].Visible = false;

            grfLab.Cols[colLVNShow].AllowEditing = false;
            grfLab.Cols[colLPttHnFemale].AllowEditing = false;
            grfLab.Cols[colLPttNameFemale].AllowEditing = false;
            grfLab.Cols[colLPttHnMale].AllowEditing = false;
            grfLab.Cols[colLPttNameMale].AllowEditing = false;
            grfLab.Cols[colLlabname].AllowEditing = false;
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
            grfQue.Name = "grfQue";

            //FilterRow fr = new FilterRow(grfExpn);

            grfQue.AfterRowColChange += GrfReq_AfterRowColChange;
            grfQue.DoubleClick += GrfQue_DoubleClick;
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
            openNurseAdd1();
        }

        private void GrfReq_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;
            String vn = "";

            //grfAddr.DataSource = xC.iniDB.addrDB.selectByTableId1(vn);
        }
        public void setGrfQuePublic()
        {
            setGrfQue();
        }
        private void setGrfQue()
        {
            if (pageLoad == true)
                return;
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
                //dt = ic.ivfDB.vsDB.selectByStatusNurseWaiting(ic.datetoDB(txtDateStart.Text));
                if (chkAll.Checked)
                {
                    dt = ic.ivfDB.ovsDB.selectByReceptionSend1();
                }
                else
                {
                    dt = ic.ivfDB.ovsDB.selectByReceptionSendBsp1(cboVisitBsp.SelectedItem == null ? "" : ((ComboBoxItem)cboVisitBsp.SelectedItem).Value);
                }
            }
            else
            {
                //grfPtt.DataSource = ic.ivfDB.vsOldDB.selectCurrentVisit(search);
            }

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfQue.Rows.Count = dt.Rows.Count + 1;
            grfQue.Cols.Count = 18;
            //C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            //grfQue.Cols[colPttHn].Editor = txt;
            //grfQue.Cols[colPttName].Editor = txt;
            //grfQue.Cols[colVsDate].Editor = txt;

            grfQue.Cols[colVNshow].Width = 80;
            grfQue.Cols[colPttHn].Width = 100;
            grfQue.Cols[colPttName].Width = 270;
            grfQue.Cols[colVsDate].Width = 100;
            grfQue.Cols[colVsTime].Width = 80;
            grfQue.Cols[colVsEtime].Width = 80;
            grfQue.Cols[colStatus].Width = 200;
            grfQue.Cols[colPttHn1].Width = 100;
            grfQue.Cols[colPttName1].Width = 250;
            grfQue.Cols[colPttHn2].Width = 100;
            grfQue.Cols[colPttName2].Width = 250;
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
            grfQue.Cols[colPttHn1].Caption = "Hn 1";
            grfQue.Cols[colPttName1].Caption = "Name Hn2";
            grfQue.Cols[colPttHn2].Caption = "Hn 2";
            grfQue.Cols[colPttName2].Caption = "Name Hn2";
            grfQue.Cols[colVsAgent].Caption = "Agent";

            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("&receive operation", new EventHandler(ContextMenu_order));
            //menuGw.MenuItems.Add("&Order Entry", new EventHandler(ContextMenu_order));
            menuGw.MenuItems.Add("&LAB request FORM A", new EventHandler(ContextMenu_LAB_req_formA));
            menuGw.MenuItems.Add("&Add Appointment", new EventHandler(ContextMenu_Apm));
            menuGw.MenuItems.Add("&Cancel Receive", new EventHandler(ContextMenu_Apm));
            //menuGw.MenuItems.Add("&No Appointment Close Operation", new EventHandler(ContextMenu_NO_Apm));
            MenuItem addDevice = new MenuItem("[Form Print]");
            menuGw.MenuItems.Add(addDevice);
            addDevice.MenuItems.Add(new MenuItem("Pre-Operation Check List", new EventHandler(ContextMenu_prn_check_list)));
            addDevice.MenuItems.Add(new MenuItem("Autherization Form", new EventHandler(ContextMenu_prn_authen_sign)));
            addDevice.MenuItems.Add(new MenuItem("Order OPU", new EventHandler(ContextMenu_prn_order_opu)));
            addDevice.MenuItems.Add(new MenuItem("Order ET, FET", new EventHandler(ContextMenu_prn_order_et_fet)));
            addDevice.MenuItems.Add(new MenuItem("Post Operation Note", new EventHandler(ContextMenu_prn_operation_note)));
            addDevice.MenuItems.Add(new MenuItem("Patient Medical History", new EventHandler(ContextMenu_prn_pmh)));
            addDevice.MenuItems.Add(new MenuItem("Print Sticker VN", new EventHandler(ContextMenu_prn_sticker_vn_grfque)));
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
                    grfQue[i, colVNshow] = ic.showVN(row["VN"].ToString());
                    grfQue[i, colPttHn] = row["PIDS"].ToString();
                    grfQue[i, colPttName] = row["PName"].ToString();
                    grfQue[i, colVsDate] = ic.datetoShow(row["VDate"]);
                    grfQue[i, colVsTime] = ic.timetoShow(row["VStartTime"]);
                    grfQue[i, colVsEtime] = row["VEndTime"].ToString();
                    grfQue[i, colStatus] = row["VName"].ToString();
                    grfQue[i, colPttId] = row["t_patient_id"].ToString();
                    grfQue[i, colPttHn1] = row["patient_hn_1"].ToString();
                    grfQue[i, colPttName1] = row["name_1"].ToString();
                    grfQue[i, colPttHn2] = row["patient_hn_2"].ToString();
                    grfQue[i, colPttName2] = row["name_2"].ToString();
                    grfQue[i, colVn] = row["VN"].ToString();
                    grfQue[i, colPID] = row["PID"].ToString();
                    grfQue[i, colVsAgent] = row["AgentName"].ToString();
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
            grfQue.Cols[colPID].Visible = false;

            grfQue.Cols[colVNshow].AllowEditing = false;
            grfQue.Cols[colPttHn].AllowEditing = false;
            grfQue.Cols[colPttName].AllowEditing = false;
            grfQue.Cols[colVsDate].AllowEditing = false;
            grfQue.Cols[colVsTime].AllowEditing = false;
            grfQue.Cols[colPttHn1].AllowEditing = false;
            grfQue.Cols[colPttName1].AllowEditing = false;
            grfQue.Cols[colPttHn2].AllowEditing = false;
            grfQue.Cols[colPttName2].AllowEditing = false;
            //grfQue.Cols[colDtr].AllowEditing = false;
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
                if(chkAll.Checked)
                    dt = ic.ivfDB.ovsDB.selectByReceptionSend1();
                else
                    dt = ic.ivfDB.ovsDB.selectByReceptionSendBsp1(cboVisitBsp.SelectedItem == null ? "" : ((ComboBoxItem)cboVisitBsp.SelectedItem).Value);
            }
            else
            {
                //grfPtt.DataSource = ic.ivfDB.vsOldDB.selectCurrentVisit(search);
            }

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfQue.Rows.Count = dt.Rows.Count + 1;
            grfQue.Cols.Count = 18;
            C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            //grfQue.Cols[colPttHn].Editor = txt;
            //grfQue.Cols[colPttName].Editor = txt;
            //grfQue.Cols[colVsDate].Editor = txt;

            grfQue.Cols[colVNshow].Width = 80;
            grfQue.Cols[colPttHn].Width = 120;
            grfQue.Cols[colPttName].Width = 300;
            grfQue.Cols[colVsDate].Width = 100;
            grfQue.Cols[colVsTime].Width = 80;
            grfQue.Cols[colVsEtime].Width = 80;
            grfQue.Cols[colStatus].Width = 200;
            grfQue.Cols[colPttHn1].Width = 100;
            grfQue.Cols[colPttName1].Width = 250;
            grfQue.Cols[colPttHn2].Width = 100;
            grfQue.Cols[colPttName2].Width = 250;

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
            grfQue.Cols[colPttHn1].Caption = "Hn 1";
            grfQue.Cols[colPttName1].Caption = "Name Hn2";
            grfQue.Cols[colPttHn2].Caption = "Hn 2";
            grfQue.Cols[colPttName2].Caption = "Name Hn2";

            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&receive operation", new EventHandler(ContextMenu_Apm));
            menuGw.MenuItems.Add("receive operation", new EventHandler(ContextMenu_order));
            menuGw.MenuItems.Add("LAB request FORM A", new EventHandler(ContextMenu_LAB_req_formA_Ptt));
            menuGw.MenuItems.Add("LAB FORM DAY1", new EventHandler(ContextMenu_LAB_req_form_day1));
            menuGw.MenuItems.Add("Egg Sti ", new EventHandler(ContextMenu_egg_sti));
            menuGw.MenuItems.Add("&Add Appointment", new EventHandler(ContextMenu_Apm_Ptt));
            menuGw.MenuItems.Add("&Cancel Receive", new EventHandler(ContextMenu_Void_Ptt));
            //menuGw.MenuItems.Add("&No Appointment Close Operation", new EventHandler(ContextMenu_NO_Apm_Ptt));
            
            //menuGw.MenuItems.Add("Print Autherization Form", new EventHandler(ContextMenu_prn_authen_sign));
            MenuItem addDevice = new MenuItem("[Form Print]");
            menuGw.MenuItems.Add(addDevice);
            addDevice.MenuItems.Add(new MenuItem("Pre-Operation Check List", new EventHandler(ContextMenu_prn_check_list)));
            addDevice.MenuItems.Add(new MenuItem("Autherization Form", new EventHandler(ContextMenu_prn_authen_sign)));
            addDevice.MenuItems.Add(new MenuItem("Order OPU", new EventHandler(ContextMenu_prn_order_opu)));
            addDevice.MenuItems.Add(new MenuItem("Order ET, FET", new EventHandler(ContextMenu_prn_order_et_fet)));
            addDevice.MenuItems.Add(new MenuItem("Post Operation Note", new EventHandler(ContextMenu_prn_operation_note)));
            addDevice.MenuItems.Add(new MenuItem("Patient Medical History", new EventHandler(ContextMenu_prn_pmh)));
            addDevice.MenuItems.Add(new MenuItem("Print Sticker VN", new EventHandler(ContextMenu_prn_sticker_vn_grfque)));
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
                grfQue[i, colPttId] = row["t_patient_id"].ToString();
                grfQue[i, colDtr] = row["dtrname"].ToString();
                grfQue[i, colPttHn1] = row["patient_hn_1"].ToString();
                grfQue[i, colPttName1] = row["name_1"].ToString();
                grfQue[i, colPttHn2] = row["patient_hn_2"].ToString();
                grfQue[i, colPttName2] = row["name_2"].ToString();
                grfQue[i, colPID] = row["PID"].ToString();
                grfQue[i, colVsAgent] = row["AgentName"].ToString();
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
            grfQue.Cols[colPttId].Visible = false;

            grfQue.Cols[colVNshow].AllowEditing = false;
            grfQue.Cols[colPttHn].AllowEditing = false;
            grfQue.Cols[colPttName].AllowEditing = false;
            grfQue.Cols[colVsDate].AllowEditing = false;
            grfQue.Cols[colVsTime].AllowEditing = false;
            grfQue.Cols[colDtr].AllowEditing = false;
            grfQue.Cols[colPttHn1].AllowEditing = false;
            grfQue.Cols[colPttName1].AllowEditing = false;
            grfQue.Cols[colPttHn2].AllowEditing = false;
            grfQue.Cols[colPttName2].AllowEditing = false;
            grfQue.Cols[colVsAgent].AllowEditing = false;
            //theme1.SetTheme(grfQue, ic.theme);

        }
        private void ContextMenu_egg_sti(object sender, System.EventArgs e)
        {
            SetDefaultPrinter(ic.iniC.printerA4);

            String chk = "", name = "", vsid = "", pttId = "";
            if (grfQue.Row < 0) return;
            vsid = grfQue[grfQue.Row, colID] != null ? grfQue[grfQue.Row, colID].ToString() : "";
            pttId = grfQue[grfQue.Row, colPttId] != null ? grfQue[grfQue.Row, colPttId].ToString() : "";
            chk = grfQue[grfQue.Row, colPttHn] != null ? grfQue[grfQue.Row, colPttHn].ToString() : "";
            name = grfQue[grfQue.Row, colPttName] != null ? grfQue[grfQue.Row, colPttName].ToString() : "";
            //reqid = ic.ivfDB.oJsDB.selectByStatusOPU(vsid);
            //if (!reqid.Equals(""))
            //{
            openEggStiAdd(pttId, vsid, name,"");

        }
        private void ContextMenu_prn_authen_sign_finish(object sender, System.EventArgs e)
        {
            SetDefaultPrinter(ic.iniC.printerA4);
            try
            {
                String chk = "", name = "", vsid = "", pttId = "", hn = "";

                vsid = grfQue[grfQue.Row, colID] != null ? grfQue[grfQue.Row, colID].ToString() : "";
                pttId = grfQue[grfQue.Row, colPttId] != null ? grfQue[grfQue.Row, colPttId].ToString() : "";
                name = grfQue[grfQue.Row, colPttName] != null ? grfQue[grfQue.Row, colPttName].ToString() : "";
                hn = grfQue[grfQue.Row, colPttHn] != null ? grfQue[grfQue.Row, colPttHn].ToString() : "";
                FrmPrintCritiAnes frm = new FrmPrintCritiAnes(ic, hn, name, vsid);
                frm.ShowDialog(this);
                ic.logw.WriteLog("g", "Print Authen Sign (Finish)");
            }
            catch(Exception ex)
            {
                ic.logw.WriteLog("e", "Print Authen Sign (Finish) err" + ex.Message);
                MessageBox.Show(ex.Message, "");
            }
            
        }
        private void ContextMenu_prn_check_list_finish(object sender, System.EventArgs e)
        {
            SetDefaultPrinter(ic.iniC.printerA4);
            try
            {
                String chk = "", name = "", vsid = "", pttId = "", hn = "";

                vsid = grfFinish[grfFinish.Row, colID] != null ? grfFinish[grfFinish.Row, colID].ToString() : "";
                pttId = grfFinish[grfFinish.Row, colPttId] != null ? grfFinish[grfFinish.Row, colPttId].ToString() : "";
                name = grfFinish[grfFinish.Row, colPttName] != null ? grfFinish[grfFinish.Row, colPttName].ToString() : "";
                hn = grfFinish[grfFinish.Row, colPttHn] != null ? grfFinish[grfFinish.Row, colPttHn].ToString() : "";
                Patient ptt = new Patient();
                ptt = ic.ivfDB.pttDB.selectByHn(hn);
                Patient ptt2 = new Patient();
                ptt2 = ic.ivfDB.pttDB.selectByHn(ptt.patient_hn_2);
                FrmReport frm = new FrmReport(ic);
                frm.setOpdCheckList(name, hn, ptt.AgeStringShort() + " [" + ic.datetoShow(ptt.patient_birthday) + "]", ptt2.Name + " " + ptt2.patient_hn + " " + ptt2.AgeStringShort() + " [" + ic.datetoShow(ptt2.patient_birthday) + "]");
                frm.ShowDialog(this);
                ic.logw.WriteLog("g", "Print Check List (Finish)");
            }
            catch(Exception ex)
            {
                ic.logw.WriteLog("e", "Print Check List (Finish) err" + ex.Message);
                MessageBox.Show(ex.Message, "");
            }
        }
        private void ContextMenu_prn_authen_sign(object sender, System.EventArgs e)
        {
            SetDefaultPrinter(ic.iniC.printerA4);
            try
            {
                String chk = "", name = "", vsid = "", pttId = "", hn = "";

                vsid = grfQue[grfQue.Row, colID] != null ? grfQue[grfQue.Row, colID].ToString() : "";
                pttId = grfQue[grfQue.Row, colPttId] != null ? grfQue[grfQue.Row, colPttId].ToString() : "";
                name = grfQue[grfQue.Row, colPttName] != null ? grfQue[grfQue.Row, colPttName].ToString() : "";
                hn = grfQue[grfQue.Row, colPttHn] != null ? grfQue[grfQue.Row, colPttHn].ToString() : "";
                FrmPrintCritiAnes frm = new FrmPrintCritiAnes(ic, hn, name, vsid);
                frm.ShowDialog(this);
                ic.logw.WriteLog("g", "Print Authen Sign (Queue)");
            }
            catch(Exception ex)
            {
                ic.logw.WriteLog("e", "Print Authen Sign (Queue) err" + ex.Message);
                MessageBox.Show(ex.Message, "");
            }
            
        }
        private void ContextMenu_prn_authen_sign_grfSearch(object sender, System.EventArgs e)
        {
            SetDefaultPrinter(ic.iniC.printerA4);
            try
            {
                String chk = "", name = "", vsid = "", pttId = "", hn = "";

                vsid = grfSearch[grfSearch.Row, colID] != null ? grfSearch[grfSearch.Row, colID].ToString() : "";
                pttId = grfSearch[grfSearch.Row, colPttId] != null ? grfSearch[grfSearch.Row, colPttId].ToString() : "";
                name = grfSearch[grfSearch.Row, colPttName] != null ? grfSearch[grfSearch.Row, colPttName].ToString() : "";
                hn = grfSearch[grfSearch.Row, colPttHn] != null ? grfSearch[grfSearch.Row, colPttHn].ToString() : "";

                FrmPrintCritiAnes frm = new FrmPrintCritiAnes(ic, hn, name, vsid);
                frm.ShowDialog(this);
                ic.logw.WriteLog("g", "Print Authen Sign (Search)");
            }
            catch (Exception ex)
            {
                ic.logw.WriteLog("e", "Print Authen Sign (Search) err" + ex.Message);
                MessageBox.Show(ex.Message, "");
            }
            
        }
        private void ContextMenu_prn_check_list(object sender, System.EventArgs e)
        {
            SetDefaultPrinter(ic.iniC.printerA4);
            try
            {
                String chk = "", name = "", vsid = "", pttId = "", hn = "";

                vsid = grfQue[grfQue.Row, colID] != null ? grfQue[grfQue.Row, colID].ToString() : "";
                pttId = grfQue[grfQue.Row, colPttId] != null ? grfQue[grfQue.Row, colPttId].ToString() : "";
                hn = grfQue[grfQue.Row, colPttHn] != null ? grfQue[grfQue.Row, colPttHn].ToString() : "";
                name = grfQue[grfQue.Row, colPttName] != null ? grfQue[grfQue.Row, colPttName].ToString() : "";
                Patient ptt = new Patient();
                ptt = ic.ivfDB.pttDB.selectByHn(hn);
                Patient ptt2 = new Patient();
                ptt2 = ic.ivfDB.pttDB.selectByHn(ptt.patient_hn_2);
                FrmReport frm = new FrmReport(ic);
                frm.setOpdCheckList(name, hn, ptt.AgeStringShort() + " [" + ic.datetoShow(ptt.patient_birthday) + "]", ptt2.Name + " " + ptt2.patient_hn + " " + ptt2.AgeStringShort() + " [" + ic.datetoShow(ptt2.patient_birthday) + "]");
                frm.ShowDialog(this);
                ic.logw.WriteLog("g", "Print Check List (Queue)");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "");
                ic.logw.WriteLog("e", "Print Check List (Queue) err" + ex.Message);
            }
            
        }
        private void ContextMenu_prn_check_list_grfSearch(object sender, System.EventArgs e)
        {
            SetDefaultPrinter(ic.iniC.printerA4);
            try
            {
                String chk = "", name = "", vsid = "", pttId = "", hn = "";
                hn = grfSearch[grfSearch.Row, colPttHn] != null ? grfSearch[grfSearch.Row, colPttHn].ToString() : "";
                vsid = grfSearch[grfSearch.Row, colID] != null ? grfSearch[grfSearch.Row, colID].ToString() : "";
                pttId = grfSearch[grfSearch.Row, colPttId] != null ? grfSearch[grfSearch.Row, colPttId].ToString() : "";
                name = grfSearch[grfSearch.Row, colPttName] != null ? grfSearch[grfSearch.Row, colPttName].ToString() : "";
                Patient ptt = new Patient();
                ptt = ic.ivfDB.pttDB.selectByHn(hn);
                Patient ptt2 = new Patient();
                ptt2 = ic.ivfDB.pttDB.selectByHn(ptt.patient_hn_2);
                FrmReport frm = new FrmReport(ic);
                frm.setOpdCheckList(name, hn, ptt.AgeStringShort() + " [" + ic.datetoShow(ptt.patient_birthday) + "]", ptt2.Name + " " + ptt2.patient_hn + " " + ptt2.AgeStringShort() + " [" + ic.datetoShow(ptt2.patient_birthday) + "]");
                frm.ShowDialog(this);
                ic.logw.WriteLog("g", "Print Check List (Search)");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "");
                ic.logw.WriteLog("e", "Print Check List (Search) err " + ex.Message);
            }
            
        }
        private void ContextMenu_prn_order_opu_grfSearch(object sender, System.EventArgs e)
        {
            SetDefaultPrinter(ic.iniC.printerA4);
            try
            {
                String chk = "", name = "", vsid = "", pttId = "", hn = "";

                vsid = grfSearch[grfSearch.Row, colID] != null ? grfSearch[grfSearch.Row, colID].ToString() : "";
                pttId = grfSearch[grfSearch.Row, colPttId] != null ? grfSearch[grfSearch.Row, colPttId].ToString() : "";
                name = grfSearch[grfSearch.Row, colPttName] != null ? grfSearch[grfSearch.Row, colPttName].ToString() : "";
                hn = grfSearch[grfSearch.Row, colPttHn] != null ? grfSearch[grfSearch.Row, colPttHn].ToString() : "";
                Patient ptt = new Patient();
                ptt = ic.ivfDB.pttDB.selectByHn(hn);
                FrmReport frm = new FrmReport(ic);
                frm.setOpdOrderOPU(name, hn, ptt.AgeStringShort() + " [" + ic.datetoShow(ptt.patient_birthday) + "]");
                frm.ShowDialog(this);
                ic.logw.WriteLog("g", "Print Order OPU (Search)");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "");
                ic.logw.WriteLog("e", "Print Order OPU (Search) err " + ex.Message);
            }
            
        }
        private void ContextMenu_prn_order_opu_grfFinish(object sender, System.EventArgs e)
        {
            SetDefaultPrinter(ic.iniC.printerA4);
            try
            {
                String chk = "", name = "", vsid = "", pttId = "", hn = "";

                vsid = grfFinish[grfFinish.Row, colID] != null ? grfFinish[grfFinish.Row, colID].ToString() : "";
                pttId = grfFinish[grfFinish.Row, colPttId] != null ? grfFinish[grfFinish.Row, colPttId].ToString() : "";
                name = grfFinish[grfFinish.Row, colPttName] != null ? grfFinish[grfFinish.Row, colPttName].ToString() : "";
                hn = grfFinish[grfFinish.Row, colPttHn] != null ? grfFinish[grfFinish.Row, colPttHn].ToString() : "";
                Patient ptt = new Patient();
                ptt = ic.ivfDB.pttDB.selectByHn(hn);
                FrmReport frm = new FrmReport(ic);
                frm.setOpdOrderOPU(name, hn, ptt.AgeStringShort() + " [" + ic.datetoShow(ptt.patient_birthday) + "]");
                frm.ShowDialog(this);
                ic.logw.WriteLog("g", "Print Order OPU (Finish)");
            }
            catch (Exception ex)
            {
                ic.logw.WriteLog("e", "Print Order OPU (Finish) err " + ex.Message);
                MessageBox.Show(ex.Message, "");
            }
            
        }
        private void ContextMenu_prn_order_opu(object sender, System.EventArgs e)
        {
            SetDefaultPrinter(ic.iniC.printerA4);
            try
            {
                String chk = "", name = "", vsid = "", pttId = "", hn = "";

                vsid = grfQue[grfQue.Row, colID] != null ? grfQue[grfQue.Row, colID].ToString() : "";
                pttId = grfQue[grfQue.Row, colPttId] != null ? grfQue[grfQue.Row, colPttId].ToString() : "";
                name = grfQue[grfQue.Row, colPttName] != null ? grfQue[grfQue.Row, colPttName].ToString() : "";
                hn = grfQue[grfQue.Row, colPttHn] != null ? grfQue[grfQue.Row, colPttHn].ToString() : "";
                Patient ptt = new Patient();
                ptt = ic.ivfDB.pttDB.selectByHn(hn);
                FrmReport frm = new FrmReport(ic);
                frm.setOpdOrderOPU(name, hn, ptt.AgeStringShort() + " [" + ic.datetoShow(ptt.patient_birthday) + "]");
                frm.ShowDialog(this);
                ic.logw.WriteLog("g", "Print Order OPU (Queue)");
            }
            catch (Exception ex)
            {
                ic.logw.WriteLog("e", "Print Order OPU (Queue) err " + ex.Message);
                MessageBox.Show(ex.Message, "");
            }
            
        }
        private void ContextMenu_prn_order_et_fet_grfSearch(object sender, System.EventArgs e)
        {
            SetDefaultPrinter(ic.iniC.printerA4);
            try
            {
                String chk = "", name = "", vsid = "", pttId = "", hn = "";

                vsid = grfSearch[grfSearch.Row, colID] != null ? grfSearch[grfSearch.Row, colID].ToString() : "";
                pttId = grfSearch[grfSearch.Row, colPttId] != null ? grfSearch[grfSearch.Row, colPttId].ToString() : "";
                name = grfSearch[grfSearch.Row, colPttName] != null ? grfSearch[grfSearch.Row, colPttName].ToString() : "";
                hn = grfSearch[grfSearch.Row, colPttHn] != null ? grfSearch[grfSearch.Row, colPttHn].ToString() : "";
                Patient ptt = new Patient();
                ptt = ic.ivfDB.pttDB.selectByHn(hn);
                FrmReport frm = new FrmReport(ic);
                frm.setOpdOrderETFET(name, hn, ptt.AgeStringShort() + " [" + ic.datetoShow(ptt.patient_birthday) + "]");
                frm.ShowDialog(this);
                ic.logw.WriteLog("g", "Print Order ET FET (Search)");
            }
            catch (Exception ex)
            {
                ic.logw.WriteLog("e", "Print Order ET FET (Search) err " + ex.Message);
                MessageBox.Show(ex.Message, "");
            }
            
        }
        private void ContextMenu_prn_order_et_fet_grfFinish(object sender, System.EventArgs e)
        {
            SetDefaultPrinter(ic.iniC.printerA4);
            try
            {
                String chk = "", name = "", vsid = "", pttId = "", hn = "";

                vsid = grfFinish[grfFinish.Row, colID] != null ? grfFinish[grfFinish.Row, colID].ToString() : "";
                pttId = grfFinish[grfFinish.Row, colPttId] != null ? grfFinish[grfFinish.Row, colPttId].ToString() : "";
                name = grfFinish[grfFinish.Row, colPttName] != null ? grfFinish[grfFinish.Row, colPttName].ToString() : "";
                hn = grfFinish[grfFinish.Row, colPttHn] != null ? grfFinish[grfFinish.Row, colPttHn].ToString() : "";
                Patient ptt = new Patient();
                ptt = ic.ivfDB.pttDB.selectByHn(hn);
                FrmReport frm = new FrmReport(ic);
                frm.setOpdOrderETFET(name, hn, ptt.AgeStringShort() + " [" + ic.datetoShow(ptt.patient_birthday) + "]");
                frm.ShowDialog(this);
                ic.logw.WriteLog("g", "Print Order ET FET (Finish)");
            }
            catch (Exception ex)
            {
                ic.logw.WriteLog("e", "Print Order ET FET (Finish) err " + ex.Message);
                MessageBox.Show(ex.Message, "");
            }
            
        }
        private void ContextMenu_prn_order_et_fet(object sender, System.EventArgs e)
        {
            SetDefaultPrinter(ic.iniC.printerA4);
            try
            {
                String chk = "", name = "", vsid = "", pttId = "", hn = "";

                vsid = grfQue[grfQue.Row, colID] != null ? grfQue[grfQue.Row, colID].ToString() : "";
                pttId = grfQue[grfQue.Row, colPttId] != null ? grfQue[grfQue.Row, colPttId].ToString() : "";
                name = grfQue[grfQue.Row, colPttName] != null ? grfQue[grfQue.Row, colPttName].ToString() : "";
                hn = grfQue[grfQue.Row, colPttHn] != null ? grfQue[grfQue.Row, colPttHn].ToString() : "";
                Patient ptt = new Patient();
                ptt = ic.ivfDB.pttDB.selectByHn(hn);
                FrmReport frm = new FrmReport(ic);
                frm.setOpdOrderETFET(name, hn, ptt.AgeStringShort() + " [" + ic.datetoShow(ptt.patient_birthday) + "]");
                frm.ShowDialog(this);
                ic.logw.WriteLog("g", "Print Order ET FET (Queue)");
            }
            catch (Exception ex)
            {
                ic.logw.WriteLog("e", "Print Order ET FET (Queue) err " + ex.Message);
                MessageBox.Show(ex.Message, "");
            }
            
        }
        private void ContextMenu_prn_operation_note_grfSearch(object sender, System.EventArgs e)
        {
            SetDefaultPrinter(ic.iniC.printerA4);
            try
            {
                String chk = "", name = "", vsid = "", pttId = "", hn = "";

                vsid = grfSearch[grfSearch.Row, colID] != null ? grfSearch[grfSearch.Row, colID].ToString() : "";
                pttId = grfSearch[grfSearch.Row, colPttId] != null ? grfSearch[grfSearch.Row, colPttId].ToString() : "";
                name = grfSearch[grfSearch.Row, colPttName] != null ? grfSearch[grfSearch.Row, colPttName].ToString() : "";
                hn = grfSearch[grfSearch.Row, colPttHn] != null ? grfSearch[grfSearch.Row, colPttHn].ToString() : "";
                Patient ptt = new Patient();
                ptt = ic.ivfDB.pttDB.selectByHn(hn);
                FrmReport frm = new FrmReport(ic);
                frm.setOpdpostoperationnote(name, hn, ptt.AgeStringShort() + " [" + ic.datetoShow(ptt.patient_birthday) + "]");
                frm.ShowDialog(this);
                ic.logw.WriteLog("g", "Print Print Operation Note (Search)");
            }
            catch (Exception ex)
            {
                ic.logw.WriteLog("e", "Print Operation Note (Search) err " + ex.Message);
                MessageBox.Show(ex.Message, "");
            }
            
        }
        private void ContextMenu_prn_operation_note_grfFinish(object sender, System.EventArgs e)
        {
            SetDefaultPrinter(ic.iniC.printerA4);
            try
            {
                String chk = "", name = "", vsid = "", pttId = "", hn = "";

                vsid = grfFinish[grfFinish.Row, colID] != null ? grfFinish[grfFinish.Row, colID].ToString() : "";
                pttId = grfFinish[grfFinish.Row, colPttId] != null ? grfFinish[grfFinish.Row, colPttId].ToString() : "";
                name = grfFinish[grfFinish.Row, colPttName] != null ? grfFinish[grfFinish.Row, colPttName].ToString() : "";
                hn = grfFinish[grfFinish.Row, colPttHn] != null ? grfFinish[grfFinish.Row, colPttHn].ToString() : "";
                Patient ptt = new Patient();
                ptt = ic.ivfDB.pttDB.selectByHn(hn);
                FrmReport frm = new FrmReport(ic);
                frm.setOpdpostoperationnote(name, hn, ptt.AgeStringShort() + " [" + ic.datetoShow(ptt.patient_birthday) + "]");
                frm.ShowDialog(this);
                ic.logw.WriteLog("g", "Print Print Operation Note (Finish)");
            }
            catch (Exception ex)
            {
                ic.logw.WriteLog("e", "Print Operation Note (Finish) err " + ex.Message);
                MessageBox.Show(ex.Message, "");
            }
            
        }
        private void ContextMenu_prn_operation_note(object sender, System.EventArgs e)
        {
            SetDefaultPrinter(ic.iniC.printerA4);
            try
            {
                String chk = "", name = "", vsid = "", pttId = "", hn = "";

                vsid = grfQue[grfQue.Row, colID] != null ? grfQue[grfQue.Row, colID].ToString() : "";
                pttId = grfQue[grfQue.Row, colPttId] != null ? grfQue[grfQue.Row, colPttId].ToString() : "";
                name = grfQue[grfQue.Row, colPttName] != null ? grfQue[grfQue.Row, colPttName].ToString() : "";
                hn = grfQue[grfQue.Row, colPttHn] != null ? grfQue[grfQue.Row, colPttHn].ToString() : "";
                Patient ptt = new Patient();
                ptt = ic.ivfDB.pttDB.selectByHn(hn);
                FrmReport frm = new FrmReport(ic);
                frm.setOpdpostoperationnote(name, hn, ptt.AgeStringShort() + " [" + ic.datetoShow(ptt.patient_birthday) + "]");
                frm.ShowDialog(this);
                ic.logw.WriteLog("g", "Print Print Operation Note (Queue)");
            }
            catch (Exception ex)
            {
                ic.logw.WriteLog("e", "Print Operation Note (Queue) err " + ex.Message);
                MessageBox.Show(ex.Message, "");
            }
            
        }
        private void ContextMenu_prn_pmh_grfFinish(object sender, System.EventArgs e)
        {
            SetDefaultPrinter(ic.iniC.printerA4);
            try
            {
                String chk = "", name = "", vsid = "", pttId = "", hn = "";

                vsid = grfFinish[grfFinish.Row, colID] != null ? grfFinish[grfFinish.Row, colID].ToString() : "";
                pttId = grfFinish[grfFinish.Row, colPttId] != null ? grfFinish[grfFinish.Row, colPttId].ToString() : "";
                name = grfFinish[grfFinish.Row, colPttName] != null ? grfFinish[grfFinish.Row, colPttName].ToString() : "";
                hn = grfFinish[grfFinish.Row, colPttHn] != null ? grfFinish[grfFinish.Row, colPttHn].ToString() : "";
                FrmReport frm = new FrmReport(ic);
                frm.setPatientMedicalHistory(name, hn);
                frm.ShowDialog(this);
                ic.logw.WriteLog("g", "Print Print Patient History (Finish)");
            }
            catch (Exception ex)
            {
                ic.logw.WriteLog("e", "Print Operation History (Finish) err " + ex.Message);
                MessageBox.Show(ex.Message, "");
            }
            
        }
        private void ContextMenu_prn_pmh_grfSearch(object sender, System.EventArgs e)
        {
            SetDefaultPrinter(ic.iniC.printerA4);
            try
            {
                String chk = "", name = "", vsid = "", pttId = "", hn = "";

                vsid = grfSearch[grfSearch.Row, colID] != null ? grfSearch[grfSearch.Row, colID].ToString() : "";
                pttId = grfSearch[grfSearch.Row, colPttId] != null ? grfSearch[grfSearch.Row, colPttId].ToString() : "";
                name = grfSearch[grfSearch.Row, colPttName] != null ? grfSearch[grfSearch.Row, colPttName].ToString() : "";
                hn = grfSearch[grfSearch.Row, colPttHn] != null ? grfSearch[grfSearch.Row, colPttHn].ToString() : "";
                FrmReport frm = new FrmReport(ic);
                frm.setPatientMedicalHistory(name, hn);
                frm.ShowDialog(this);
                ic.logw.WriteLog("g", "Print Print Patient History (Search)");
            }
            catch (Exception ex)
            {
                ic.logw.WriteLog("e", "Print Operation History (Search) err " + ex.Message);
                MessageBox.Show(ex.Message, "");
            }
            
        }
        private void ContextMenu_prn_sticker_vn_grfque(object sender, System.EventArgs e)
        {
            String chk = "", name = "", vsid = "", pttId = "", hn = "", vn = "";

            vsid = grfQue[grfQue.Row, colID] != null ? grfQue[grfQue.Row, colID].ToString() : "";
            pttId = grfQue[grfQue.Row, colPttId] != null ? grfQue[grfQue.Row, colPttId].ToString() : "";
            name = grfQue[grfQue.Row, colPttName] != null ? grfQue[grfQue.Row, colPttName].ToString() : "";
            hn = grfQue[grfQue.Row, colPttHn] != null ? grfQue[grfQue.Row, colPttHn].ToString() : "";
            vn = grfQue[grfQue.Row, colVn] != null ? grfQue[grfQue.Row, colVn].ToString() : "";
            try
            {
                PrinterSettings settings = new PrinterSettings();
                printerOld = settings.PrinterName;
                SetDefaultPrinter(ic.iniC.printerSticker);

                Visit vs = new Visit();
                vs = ic.ivfDB.vsDB.selectByPk1(vsid);
                Patient ptt = new Patient();
                ptt = ic.ivfDB.pttDB.selectByPk1(vs.t_patient_id);

                DataTable dt = new DataTable();
                dt.Columns.Add("hn", typeof(String));
                dt.Columns.Add("name", typeof(String));
                dt.Columns.Add("age", typeof(String));
                dt.Columns.Add("vn", typeof(String));
                DataRow row11 = dt.NewRow();
                row11["hn"] = ptt.patient_hn;
                row11["name"] = ptt.Name;
                row11["age"] = "Age " + ptt.AgeStringShort() + " [" + ic.datetoShow(ptt.patient_birthday) + "]";
                row11["vn"] = vs.visit_vn;
                dt.Rows.Add(row11);
                FrmReport frm = new FrmReport(ic);
                frm.setStickerPatientThemal(dt);
                frm.ShowDialog(this);
                SetDefaultPrinter(printerOld);
            }
            catch (Exception ex)
            {
                ic.logw.WriteLog("e", "Print ContextMenu_prn_sticker_vn_grfque err " + ex.Message);
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void ContextMenu_prn_sticker_vn(object sender, System.EventArgs e)
        {
            String chk = "", name = "", vsid = "", pttId = "", hn = "", vn="";

            vsid = grfSearch[grfSearch.Row, colID] != null ? grfSearch[grfSearch.Row, colID].ToString() : "";
            pttId = grfSearch[grfSearch.Row, colPttId] != null ? grfSearch[grfSearch.Row, colPttId].ToString() : "";
            name = grfSearch[grfSearch.Row, colPttName] != null ? grfSearch[grfSearch.Row, colPttName].ToString() : "";
            hn = grfSearch[grfSearch.Row, colPttHn] != null ? grfSearch[grfSearch.Row, colPttHn].ToString() : "";
            vn = grfSearch[grfSearch.Row, colVn] != null ? grfSearch[grfSearch.Row, colVn].ToString() : "";
            try
            {
                PrinterSettings settings = new PrinterSettings();
                printerOld = settings.PrinterName;
                SetDefaultPrinter(ic.iniC.printerSticker);
                if (chkPrnSticker.Checked)
                {
                    Patient ptt = new Patient();
                    ptt = ic.ivfDB.pttDB.selectByPk1(pttId);
                    DataTable dt = new DataTable();
                    dt.Columns.Add("hn", typeof(String));
                    dt.Columns.Add("name", typeof(String));
                    dt.Columns.Add("age", typeof(String));
                    dt.Columns.Add("vn", typeof(String));
                    DataRow row11 = dt.NewRow();
                    row11["hn"] = ptt.patient_hn;
                    row11["name"] = ptt.Name;
                    String age = "";
                    age = ptt.AgeStringShort();
                    if (age.Length > 0)
                    {
                        String[] txt = age.Split('.');
                        int age1 = 0;
                        int.TryParse(txt[0], out age1);
                        if (age1 > 500)
                        {
                            ic.logw.WriteLog("e", "Print ContextMenu_prn_sticker_vn hn " + ptt.patient_hn + " dob " + ptt.patient_birthday + " " + ptt.AgeStringShort());
                            MessageBox.Show("วัน เดือน ปี เกิด ไม่ถูกต้อง", "");
                            return;
                        }
                    }
                    row11["age"] = "Age " + ptt.AgeStringShort() + " [" + ic.datetoShow(ptt.patient_birthday) + "]";
                    row11["vn"] = ptt.t_patient_id;
                    dt.Rows.Add(row11);
                    FrmReport frm = new FrmReport(ic);
                    frm.setStickerPatientThemal(dt);
                    frm.ShowDialog(this);
                }
                else
                {
                    Visit vs = new Visit();
                    vs = ic.ivfDB.vsDB.selectByPk1(vsid);
                    Patient ptt = new Patient();
                    ptt = ic.ivfDB.pttDB.selectByPk1(vs.t_patient_id);

                    DataTable dt = new DataTable();
                    dt.Columns.Add("hn", typeof(String));
                    dt.Columns.Add("name", typeof(String));
                    dt.Columns.Add("age", typeof(String));
                    dt.Columns.Add("vn", typeof(String));
                    DataRow row11 = dt.NewRow();
                    row11["hn"] = ptt.patient_hn;
                    row11["name"] = ptt.Name;
                    String age = "";
                    age = ptt.AgeStringShort();
                    if (age.Length > 0)
                    {
                        String[] txt = age.Split('.');
                        int age1 = 0;
                        int.TryParse(txt[0], out age1);
                        if (age1 > 500)
                        {
                            ic.logw.WriteLog("e", "Print ContextMenu_prn_sticker_vn hn " + ptt.patient_hn+" dob "+ ptt.patient_birthday+" "+ ptt.AgeStringShort());
                            MessageBox.Show("วัน เดือน ปี เกิด ไม่ถูกต้อง", "");
                            return;
                        }
                    }
                    row11["age"] = "Age " + ptt.AgeStringShort() + " [" + ic.datetoShow(ptt.patient_birthday) + "]";
                    row11["vn"] = vs.visit_vn;
                    dt.Rows.Add(row11);
                    FrmReport frm = new FrmReport(ic);
                    frm.setStickerPatientThemal(dt);
                    frm.ShowDialog(this);
                }
                
                SetDefaultPrinter(printerOld);
            }
            catch (Exception ex)
            {
                ic.logw.WriteLog("e", "Print ContextMenu_prn_sticker_vn err " + ex.Message);
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void ContextMenu_prn_pmh(object sender, System.EventArgs e)
        {
            String chk = "", name = "", vsid = "", pttId = "", hn = "";

            vsid = grfQue[grfQue.Row, colID] != null ? grfQue[grfQue.Row, colID].ToString() : "";
            pttId = grfQue[grfQue.Row, colPttId] != null ? grfQue[grfQue.Row, colPttId].ToString() : "";
            name = grfQue[grfQue.Row, colPttName] != null ? grfQue[grfQue.Row, colPttName].ToString() : "";
            hn = grfQue[grfQue.Row, colPttHn] != null ? grfQue[grfQue.Row, colPttHn].ToString() : "";
            FrmReport frm = new FrmReport(ic);
            frm.setPatientMedicalHistory(name, hn);
            frm.ShowDialog(this);
        }
        //private void ContextMenu_prn_pmh_donor(object sender, System.EventArgs e)
        //{
        //    String chk = "", name = "", vsid = "", pttId = "", hn = "";

        //    vsid = grfQue[grfQue.Row, colID] != null ? grfQue[grfQue.Row, colID].ToString() : "";
        //    pttId = grfQue[grfQue.Row, colPttId] != null ? grfQue[grfQue.Row, colPttId].ToString() : "";
        //    name = grfQue[grfQue.Row, colPttName] != null ? grfQue[grfQue.Row, colPttName].ToString() : "";
        //    hn = grfQue[grfQue.Row, colPttHn] != null ? grfQue[grfQue.Row, colPttHn].ToString() : "";
        //    FrmReport frm = new FrmReport(ic);
        //    frm.setPatientMedicalHistory(name, hn);
        //    frm.ShowDialog(this);
        //}
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
            if (MessageBox.Show("ต้องการ NO Operation    \n  hn number " + chk + " \n name " + name, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                String re = "";
                ic.cStf.staff_id = "";
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    re = ic.ivfDB.vsDB.updateCloseStatusNurseNoOperation(vsid, ic.cStf.staff_id);
                    ic.ivfDB.ovsDB.updateStatusVoidVisit(vsid);
                }
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
                ic.cStf.staff_id = "";
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    re = ic.ivfDB.vsDB.updateCloseStatusNurseNoOperation(vsid, ic.cStf.staff_id);
                }
                setGrfQue();
            }
        }
        private void ContextMenu_Result_Lab_OPU(object sender, System.EventArgs e)
        {
            String chk = "", namef = "", reqid = "", pttId = "", status="", namem = "", name="", lgid="";
            if (grfLab.Row < 0) return;

            reqid = grfLab[grfLab.Row, colLID] != null ? grfLab[grfLab.Row, colLID].ToString() : "";
            namef = grfLab[grfLab.Row, colLPttNameFemale] != null ? grfLab[grfLab.Row, colLPttNameFemale].ToString() : "";
            namem = grfLab[grfLab.Row, colLPttNameMale] != null ? grfLab[grfLab.Row, colLPttNameMale].ToString() : "";
            status = grfLab[grfLab.Row, colLStatus] != null ? grfLab[grfLab.Row, colLStatus].ToString() : "";
            lgid = grfLab[grfLab.Row, colLLGID] != null ? grfLab[grfLab.Row, colLLGID].ToString() : "";
            LabRequest req = new LabRequest();
            req = ic.ivfDB.lbReqDB.selectByPk1(reqid);
            if (namef.Equals(""))
            {
                name = namem;
            }
            else
            {
                name = namef;
            }

            if (status.Equals("5"))
            {
                LabOpu opu = new LabOpu();
                opu = ic.ivfDB.opuDB.selectByReqID(req.req_id);
                //FrmLabOPUAdd2 frm = new FrmLabOPUAdd2(ic,"", opu.opu_id);
                FrmNurseOPUView frm = new FrmNurseOPUView(ic, "", opu.opu_id);
                String txt = "";
                if (!namef.Equals(""))
                {
                    txt = "ผลLAB OPU " + name;
                }
                frm.FormBorderStyle = FormBorderStyle.None;
                menu.AddNewTab(frm, txt);
            }
            else if (status.Equals("1"))
            {
                LabSperm lsperm = new LabSperm();
                lsperm = ic.ivfDB.lspermDB.selectByReqId(reqid);
                FrmLabSpermAdd frm = new FrmLabSpermAdd(ic, reqid, lsperm.sperm_id, "nurse_view");
                String txt = "";
                if (!name.Equals(""))
                {
                    txt = "ผลLAB SPERM " + name;
                }
                frm.FormBorderStyle = FormBorderStyle.None;
                menu.AddNewTab(frm, txt);
            }
            else
            {
                if (lgid.Equals("1"))
                {
                    String resid = "";
                    resid = ic.ivfDB.lbresDB.selectLabBloodByReqId(reqid);
                    FrmLabBloodAdd frm = new FrmLabBloodAdd(ic, resid);
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(this);
                    
                }
            }
            //pttId = grfLab[grfLab.Row, colPttId] != null ? grfLab[grfLab.Row, colPttId].ToString() : "";
            //chk = grfLab[grfLab.Row, colPttHn] != null ? grfLab[grfLab.Row, colPttHn].ToString() : "";
            //name = grfLab[grfLab.Row, colPttName] != null ? grfLab[grfLab.Row, colPttName].ToString() : "";
            //FrmNurseAdd frm = new FrmNurseAdd();
            //frm.ShowDialog(this);
            //openApmAdd(pttId, vsid, name);

        }
        private void ContextMenu_LAB_req_formA_Ptt_finish(object sender, System.EventArgs e)
        {
            String chk = "", name = "", vsid = "", pttId = "", vn="";
            if (grfFinish.Row < 0) return;
            vsid = grfFinish[grfFinish.Row, colID] != null ? grfFinish[grfFinish.Row, colID].ToString() : "";
            pttId = grfFinish[grfFinish.Row, colPttId] != null ? grfFinish[grfFinish.Row, colPttId].ToString() : "";
            chk = grfFinish[grfFinish.Row, colPttHn] != null ? grfFinish[grfFinish.Row, colPttHn].ToString() : "";
            name = grfFinish[grfFinish.Row, colPttName] != null ? grfFinish[grfFinish.Row, colPttName].ToString() : "";
            vn = grfFinish[grfFinish.Row, colVn] != null ? grfFinish[grfFinish.Row, colVn].ToString() : "";
            //reqid = ic.ivfDB.oJsDB.selectByStatusOPU(vsid);
            //if (!reqid.Equals(""))
            //{
            FrmLabFormA frm = new FrmLabFormA(ic, "", pttId, vsid, vn);
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
            String chk = "", name = "", vsid = "", pttId = "", hn="", vn="";
            if (grfSearch.Row < 0) return;
            vsid = grfSearch[grfSearch.Row, colSID] != null ? grfSearch[grfSearch.Row, colSID].ToString() : "";
            vn = grfSearch[grfSearch.Row, colVn] != null ? grfSearch[grfSearch.Row, colVn].ToString() : "";
            pttId = grfSearch[grfSearch.Row, colPttId] != null ? grfSearch[grfSearch.Row, colPttId].ToString() : "";
            hn = grfSearch[grfSearch.Row, colPttHn] != null ? grfSearch[grfSearch.Row, colPttHn].ToString() : "";
            chk = grfSearch[grfSearch.Row, colPttHn] != null ? grfSearch[grfSearch.Row, colPttHn].ToString() : "";
            name = grfSearch[grfSearch.Row, colPttName] != null ? grfSearch[grfSearch.Row, colPttName].ToString() : "";
            
            FrmLabFormA frm = new FrmLabFormA(ic, "", pttId, vsid, vn);
            frm.ShowDialog(this);
            setGrfSearch(txtSearch.Text.Trim());
            
        }
        private void ContextMenu_LAB_req_formA_Ptt(object sender, System.EventArgs e)
        {
            String chk = "", name = "", vsid = "", pttId = "", vn="";
            if (grfQue.Row < 0) return;
            vsid = grfQue[grfQue.Row, colID] != null ? grfQue[grfQue.Row, colID].ToString() : "";
            pttId = grfQue[grfQue.Row, colPttId] != null ? grfQue[grfQue.Row, colPttId].ToString() : "";
            chk = grfQue[grfQue.Row, colPttHn] != null ? grfQue[grfQue.Row, colPttHn].ToString() : "";
            name = grfQue[grfQue.Row, colPttName] != null ? grfQue[grfQue.Row, colPttName].ToString() : "";
            vn = grfQue[grfQue.Row, colVn] != null ? grfQue[grfQue.Row, colVn].ToString() : "";
            //reqid = ic.ivfDB.oJsDB.selectByStatusOPU(vsid);
            //if (!reqid.Equals(""))
            //{
            FrmLabFormA frm = new FrmLabFormA(ic, "", pttId, vsid, vn);
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
            String chk = "", name = "", vsid = "", pttId = "", vn="", pid="";

            vn = grfQue[grfQue.Row, colVn] != null ? grfQue[grfQue.Row, colVn].ToString() : "";
            vsid = grfQue[grfQue.Row, colID] != null ? grfQue[grfQue.Row, colID].ToString() : "";
            pid = grfQue[grfQue.Row, colPID] != null ? grfQue[grfQue.Row, colPID].ToString() : "";
            pttId = grfQue[grfQue.Row, colPttId] != null ? grfQue[grfQue.Row, colPttId].ToString() : "";
            chk = grfQue[grfQue.Row, colPttHn] != null ? grfQue[grfQue.Row, colPttHn].ToString() : "";
            name = grfQue[grfQue.Row, colPttName] != null ? grfQue[grfQue.Row, colPttName].ToString() : "";
            //FrmNurseAdd frm = new FrmNurseAdd();
            //frm.ShowDialog(this);
            //openApmAdd(pttId, vsid, name);
            //if (MessageBox.Show("ต้องการป้อน LAB request FORM A\n  hn number " + chk + " \n name " + name, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
                FrmLabFormA frm = new FrmLabFormA(ic,"", pttId, vsid, vn);
                frm.ShowDialog(this);
                //grfReq.Rows.Remove(grfReq.Row);
                //openPatientAdd(id, name);
            //}
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
        private void ContextMenu_Void_Ptt(object sender, System.EventArgs e)
        {
            String chk = "", name = "", vn = "", pttId = "", order="";
            Boolean chkOrer = false;
            if (grfQue.Row < 0) return;
            vn = grfQue[grfQue.Row, colID] != null ? grfQue[grfQue.Row, colID].ToString() : "";
            pttId = grfQue[grfQue.Row, colPttId] != null ? grfQue[grfQue.Row, colPttId].ToString() : "";
            chk = grfQue[grfQue.Row, colPttHn] != null ? grfQue[grfQue.Row, colPttHn].ToString() : "";
            name = grfQue[grfQue.Row, colPttName] != null ? grfQue[grfQue.Row, colPttName].ToString() : "";

            DataTable dtbl = new DataTable();
            DataTable dtse = new DataTable();
            DataTable dtpx = new DataTable();
            DataTable dtpkg = new DataTable();

            dtbl = ic.ivfDB.oJlabdDB.selectByVN(vn);
            dtse = ic.ivfDB.ojsdDB.selectByVN(vn);
            dtpx = ic.ivfDB.oJpxdDB.selectByVN(vn);
            //dtpkg = ic.ivfDB.opkgsDB.selectByVN(vn);
            dtpkg = ic.ivfDB.opkgsDB.selectByPID(pttId);    // ต้องดึงตาม HN เพราะ ถ้ามีงวดการชำระ 
            if (dtbl.Rows.Count > 0)
            {
                chkOrer = true;
                order = "Blood lab";
            }
            if (dtse.Rows.Count > 0)
            {
                chkOrer = true;
                order += " ,Special Item";
            }
            if (dtpx.Rows.Count > 0)
            {
                chkOrer = true;
                order += " ,Drug";
            }
            if (dtpkg.Rows.Count > 0)
            {
                chkOrer = true;
                order += " ,Package";
            }
            if (chkOrer)
            {
                MessageBox.Show("มีรายการ Order "+ order, "");
                return;
            }
            if (MessageBox.Show("ต้องการ ยกเลิก Visit  \n  hn number " + chk + " \n name " + name, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                String re = "";
                Visit vs = new Visit();
                //vs = ic.ivfDB.vsDB.selectByVn(vsid);
                ic.cStf.staff_id = "";
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    re = ic.ivfDB.vsDB.updateStatusVoidVisitByVN(vn, ic.cStf.staff_id);
                    ic.ivfDB.ovsDB.updateStatusVoidVisit(vn);
                }
                setGrfQue();
            }
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
            String chk = "", name = "", vsid = "", pttId = "",pid="";
            if (grfQue.Row < 0) return;
            vsid = grfQue[grfQue.Row, colID] != null ? grfQue[grfQue.Row, colID].ToString() : "";
            pttId = grfQue[grfQue.Row, colPttId] != null ? grfQue[grfQue.Row, colPttId].ToString() : "";
            pid = grfQue[grfQue.Row, colPID] != null ? grfQue[grfQue.Row, colPID].ToString() : "";
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
        private void ContextMenu_grfSearch(object sender, System.EventArgs e)
        {
            String chk = "", name = "", vn = "", pttId = "", pid = "";

            vn = grfSearch[grfSearch.Row, colVn] != null ? grfSearch[grfSearch.Row, colVn].ToString() : "";
            pttId = grfSearch[grfSearch.Row, colPttId] != null ? grfSearch[grfSearch.Row, colPttId].ToString() : "";
            pid = grfSearch[grfSearch.Row, colPID] != null ? grfSearch[grfSearch.Row, colPID].ToString() : "";
            chk = grfSearch[grfSearch.Row, colPttHn] != null ? grfSearch[grfSearch.Row, colPttHn].ToString() : "";
            name = grfSearch[grfSearch.Row, colPttName] != null ? grfSearch[grfSearch.Row, colPttName].ToString() : "";
            //FrmNurseAdd frm = new FrmNurseAdd();
            //frm.ShowDialog(this);

            openNurseAdd(pttId, vn, name, "view",pid);
            //if (MessageBox.Show("ต้องการ แก้ไข Patient  \n  hn number " + chk + " \n name " + name, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            //grfReq.Rows.Remove(grfReq.Row);
            //openPatientAdd(id, name);
            //}
        }
        private void ContextMenu_order_finish(object sender, System.EventArgs e)
        {
            String chk = "", name = "", vn = "", pttId = "", pid = "";

            vn = grfFinish[grfFinish.Row, colVn] != null ? grfFinish[grfFinish.Row, colVn].ToString() : "";
            pttId = grfFinish[grfFinish.Row, colPttId] != null ? grfFinish[grfFinish.Row, colPttId].ToString() : "";
            pid = grfFinish[grfFinish.Row, colPID] != null ? grfFinish[grfFinish.Row, colPID].ToString() : "";
            chk = grfFinish[grfFinish.Row, colPttHn] != null ? grfFinish[grfFinish.Row, colPttHn].ToString() : "";
            name = grfFinish[grfFinish.Row, colPttName] != null ? grfFinish[grfFinish.Row, colPttName].ToString() : "";
            //FrmNurseAdd frm = new FrmNurseAdd();
            //frm.ShowDialog(this);

            openNurseAdd(pttId, vn, name, "view",pid);
            //if (MessageBox.Show("ต้องการ แก้ไข Patient  \n  hn number " + chk + " \n name " + name, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            //grfReq.Rows.Remove(grfReq.Row);
            //openPatientAdd(id, name);
            //}
        }
        private void openNurseAdd1()
        {
            String chk = "", name = "", id = "", pttId = "", vn="", pid="";

            id = grfQue[grfQue.Row, colID] != null ? grfQue[grfQue.Row, colID].ToString() : "";
            pttId = grfQue[grfQue.Row, colPttId] != null ? grfQue[grfQue.Row, colPttId].ToString() : "";
            pid = grfQue[grfQue.Row, colPID] != null ? grfQue[grfQue.Row, colPID].ToString() : "";
            chk = grfQue[grfQue.Row, colPttHn] != null ? grfQue[grfQue.Row, colPttHn].ToString() : "";
            name = grfQue[grfQue.Row, colPttName] != null ? grfQue[grfQue.Row, colPttName].ToString() : "";
            vn = grfQue[grfQue.Row, colVn] != null ? grfQue[grfQue.Row, colVn].ToString() : "";
            //FrmNurseAdd frm = new FrmNurseAdd();
            //frm.ShowDialog(this);

            openNurseAdd(pttId, vn, name, "edit", pid);
        }
        private void ContextMenu_order(object sender, System.EventArgs e)
        {
            openNurseAdd1();
            //if (MessageBox.Show("ต้องการ แก้ไข Patient  \n  hn number " + chk + " \n name " + name, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            //grfReq.Rows.Remove(grfReq.Row);
            //openPatientAdd(id, name);
            //}
        }
        private void openEggStiAdd(String pttId, String vsid, String name, String flagview)
        {
            FrmNurseFormEggSti frm = new FrmNurseFormEggSti(ic, menu,"", pttId, vsid, flagview);
            String txt = "";
            if (!name.Equals(""))
            {
                txt = " " + name;
            }

            frm.FormBorderStyle = FormBorderStyle.None;
            menu.AddNewTab(frm, txt);
        }
        private void openNurseAdd(String pttId, String vn, String name, String flagview, String pid)
        {
            FrmNurseAdd2 frm = new FrmNurseAdd2(ic, menu, pttId, vn, flagview, pid);
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
                //FrmAppointmentDonorAdd frm = new FrmAppointmentDonorAdd(ic, "", pttId, vsid);
                FrmAppointmentAdd frm = new FrmAppointmentAdd(ic, "", pttId, vsid, pttId);
                frm.ShowDialog(this);
            }
            else
            {
                FrmAppointmentAdd frm = new FrmAppointmentAdd(ic, "", pttId, vsid, pttId);
                frm.ShowDialog(this);
            }
        }
        private void FrmNurseView_Load(object sender, EventArgs e)
        {
            tC.SelectedTab = tabWaiting;
            chkAll.Checked = true;
            sB1.Text = "Date " + ic.cop.day + "-" + ic.cop.month + "-" + ic.cop.year + " Server " + ic.iniC.hostDB + "/" + ic.iniC.nameDB + " FTP " + ic.iniC.hostFTP + "/" + ic.iniC.folderFTP;
        }
    }
}
