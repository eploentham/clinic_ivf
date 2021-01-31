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
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.gui
{
    /*
     * 63-10-27     0020        เรื่อง		เลิก insert table Visit
     */
    public partial class FrmPharmaView : Form
    {
        IvfControl ic;
        MainMenu menu;

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;

        C1FlexGrid grfQue, grfFinish, grfSearch, grfRptName, grfRpt;

        int colID = 1, colVNshow = 2, colPttHn = 3, colPttName = 4, colVsDate = 5, colVsTime = 6, colVsEtime = 7, colStatus = 8, colPttId = 9, colVn = 10, colDtr = 11, colStatusNurse = 12, colStatusCashier = 13;

        C1SuperTooltip stt;
        C1SuperErrorProvider sep;

        C1DockingTabPage tabReport;
        C1SplitterPanel scRptLeft, scRptRight, scRptReportName, scRptReportCriteria;
        C1SplitContainer sCRpt, sCRptReport;
        C1Button btnOk, btnExcel;
        Label lbtxtRptDateStart, lbtxtRptDateEnd;
        C1DateEdit txtRptDateStart, txtRptDateEnd;

        int colRptDrugDailyTime = 1, colRptDrugDailyDrugCode = 2, colRptDrugDailyDrugName = 3, colRptDrugDailyPttHn = 4, colRptDrugDailyPttName = 5, colRptDrugDailyQty = 6;

        Boolean pageLoad = false;
        Timer timer;
        public FrmPharmaView(IvfControl ic, MainMenu m)
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
            //theme1.SetTheme(tC, "Office2010Blue");
            sB1.Text = "";
            bg = txtSearch.BackColor;
            fc = txtSearch.ForeColor;
            ff = txtSearch.Font;

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();

            tabReport = new C1DockingTabPage();
            tabReport.Location = new System.Drawing.Point(1, 24);
            //tabScan.Name = "c1DockingTabPage1";
            tabReport.Size = new System.Drawing.Size(667, 175);
            tabReport.TabIndex = 0;
            tabReport.Text = "Report";
            tabReport.Name = "tabReport";
            tC.Controls.Add(tabReport);
            sCRpt = new C1.Win.C1SplitContainer.C1SplitContainer();
            scRptLeft = new C1.Win.C1SplitContainer.C1SplitterPanel();
            scRptRight = new C1.Win.C1SplitContainer.C1SplitterPanel();
            sCRptReport = new C1.Win.C1SplitContainer.C1SplitContainer();
            scRptReportName = new C1.Win.C1SplitContainer.C1SplitterPanel();
            scRptReportCriteria = new C1.Win.C1SplitContainer.C1SplitterPanel();
            sCRpt.SuspendLayout();
            scRptRight.SuspendLayout();
            scRptLeft.SuspendLayout();
            sCRptReport.SuspendLayout();
            scRptReportName.SuspendLayout();
            scRptReportCriteria.SuspendLayout();

            scRptLeft.Collapsible = true;
            scRptLeft.Dock = C1.Win.C1SplitContainer.PanelDockStyle.Left;
            scRptLeft.Location = new System.Drawing.Point(0, 21);
            scRptLeft.Name = "scRptLeft";
            scRptLeft.Controls.Add(sCRptReport);
            scRptLeft.ClientSize = new Size(20, 80);
            scRptLeft.Collapsible = true;
            scRptLeft.SizeRatio = 15;

            scRptRight.Collapsible = false;
            scRptRight.Dock = C1.Win.C1SplitContainer.PanelDockStyle.Right;
            scRptRight.Location = new System.Drawing.Point(0, 21);
            scRptRight.Name = "scRptRight";
            //scRptRight.Controls.Add(day0View);

            sCRpt.AutoSizeElement = C1.Framework.AutoSizeElement.Both;
            sCRpt.Name = "sCRpt";
            sCRpt.Dock = System.Windows.Forms.DockStyle.Fill;
            sCRpt.Panels.Add(scRptLeft);
            sCRpt.Panels.Add(scRptRight);
            tabReport.Controls.Add(sCRpt);

            scRptReportCriteria.Collapsible = true;
            scRptReportCriteria.Dock = C1.Win.C1SplitContainer.PanelDockStyle.Bottom;
            scRptReportCriteria.Location = new System.Drawing.Point(0, 21);
            scRptReportCriteria.Name = "scRptReportCriteria";
            //scRptLeft.Controls.Add(pnEmailDay0);
            scRptReportCriteria.ClientSize = new Size(20, 80);
            scRptReportCriteria.Collapsible = true;
            scRptReportCriteria.SizeRatio = 25;

            scRptReportName.Collapsible = false;
            scRptReportName.Dock = C1.Win.C1SplitContainer.PanelDockStyle.Top;
            scRptReportName.Location = new System.Drawing.Point(0, 21);
            scRptReportName.Name = "scRptReportName";

            sCRptReport.AutoSizeElement = C1.Framework.AutoSizeElement.Both;
            sCRptReport.Name = "sCRptReport";
            sCRptReport.Dock = System.Windows.Forms.DockStyle.Fill;
            sCRptReport.Panels.Add(scRptReportCriteria);
            sCRptReport.Panels.Add(scRptReportName);


            scRptLeft.ResumeLayout(false);
            scRptRight.ResumeLayout(false);
            sCRpt.ResumeLayout(false);
            scRptReportCriteria.ResumeLayout(false);
            scRptReportName.ResumeLayout(false);
            sCRptReport.ResumeLayout(false);
            scRptLeft.PerformLayout();
            scRptRight.PerformLayout();
            sCRpt.PerformLayout();
            scRptReportCriteria.PerformLayout();
            scRptReportName.PerformLayout();
            sCRptReport.PerformLayout();

            //txtDateStart.Value = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            txtDateStart.Value = "";
            cboVisitBsp.SelectedItemChanged += CboVisitBsp_SelectedItemChanged;
            ic.ivfDB.bspDB.setCboBsp(cboVisitBsp, ic.iniC.service_point_id);

            //btnNew.Click += BtnNew_Click;
            txtSearch.KeyUp += TxtSearch_KeyUp;
            //txtDateStart.ValueChanged += TxtDateStart_ValueChanged;
            txtDateStart.DropDownClosed += TxtDateStart_DropDownClosed;
            tC.SelectedTabChanged += TC_SelectedTabChanged;
            btnSearch.Click += BtnSearch_Click;

            initGrfQue();
            
            initGrfFinish();
            
            initGrfSearch();
            initGrfRptName();
            initGrfRpt();

            int timerlab = 0;
            int.TryParse(ic.iniC.timerlabreqaccept, out timerlab);
            timer = new Timer();
            timer.Interval = timerlab * 1000;
            timer.Tick += Timer_Tick;
            timer.Enabled = true;
            timer.Start();

            pageLoad = false;
        }
        private void CboVisitBsp_SelectedItemChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (pageLoad) return;
            setGrfQue();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setGrfQue();
            //setGrfSearch(txtSearch.Text.Trim());
        }
        private void initGrfRptName()
        {
            grfRptName = new C1FlexGrid();
            grfRptName.Font = fEdit;
            grfRptName.Dock = System.Windows.Forms.DockStyle.Fill;
            grfRptName.Location = new System.Drawing.Point(0, 0);
            grfRptName.Rows.Count = 2;
            grfRptName.Cols.Count = 2;
            grfRptName.Cols[1].Width = 300;
            grfRptName.Cols[1].Caption = "Report Name";
            
            
            grfRptName[1, 0] = 1;
            grfRptName[1, 1] = "รายงานการจ่ายยา";
            grfRptName.Cols[1].AllowEditing = false;
            grfRptName.Click += GrfRptName_Click;
            //FilterRow fr = new FilterRow(grfExpn);

            //grfSearch.DoubleClick += GrfSearch_DoubleClick;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            //ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //grfRptName.ContextMenu = menuGw;
            scRptReportName.Controls.Add(grfRptName);
            //grfRptName.Rows.Count = 1;
            theme1.SetTheme(grfRptName, "Office2010Red");

        }

        private void GrfRptName_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfRptName.Row == 1)
            {
                initComponentRptDrugDaily();
            }
        }
        private void initComponentRptDrugDaily()
        {
            int gapLine = 25, gapX = 20, gapY = 20, xCol2 = 130, xCol1 = 80, xCol3 = 330, xCol4 = 640, xCol5 = 950;
            Size size = new Size();

            //gapY += gapLine;
            scRptReportCriteria.Controls.Clear();
            lbtxtRptDateStart = new Label();
            txtRptDateStart = new C1DateEdit();
            lbtxtRptDateEnd = new Label();
            txtRptDateEnd = new C1DateEdit();
            btnOk = new C1Button();
            ic.setControlLabel(ref lbtxtRptDateStart, fEdit, "วันที่เริ่มต้น :", "lbtxtRptDateStart", gapX, gapY);
            size = ic.MeasureString(lbtxtRptDateStart);
            ic.setControlC1DateTimeEdit(ref txtRptDateStart, "txtRptDateStart", xCol2, gapY);

            gapY += gapLine;
            ic.setControlLabel(ref lbtxtRptDateEnd, fEdit, "วันที่สิ้นสุด :", "lbtxtRptDateEnd", gapX, gapY);
            size = ic.MeasureString(lbtxtRptDateEnd);
            ic.setControlC1DateTimeEdit(ref txtRptDateEnd, "txtRptDateEnd", xCol2, gapY);

            gapY += gapLine;
            ic.setControlC1Button(ref btnOk, fEdit, "OK", "btnOk", xCol1-40, gapY);
            ic.setControlC1Button(ref btnExcel, fEdit, "Excel", "btnExcel", xCol2, gapY);

            btnOk.Click += BtnOk_Click;

            scRptReportCriteria.Controls.Add(lbtxtRptDateStart);
            scRptReportCriteria.Controls.Add(txtRptDateStart);
            scRptReportCriteria.Controls.Add(lbtxtRptDateEnd);
            scRptReportCriteria.Controls.Add(txtRptDateEnd);
            scRptReportCriteria.Controls.Add(btnOk);
            scRptReportCriteria.Controls.Add(btnExcel);
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfRptName.Row == 1)
            {
                setGrfRptDrugDaily();
            }
        }
        private void setGrfRptDrugDaily()
        {
            String startdate = "", enddate = "";
            DataTable dt = new DataTable();
            DateTime startdate1 = new DateTime();
            DateTime enddate1 = new DateTime();
            DateTime.TryParse(txtRptDateStart.Text, out startdate1);
            DateTime.TryParse(txtRptDateEnd.Text, out enddate1);
            startdate = startdate1.ToString("yyyy-MM-dd", new CultureInfo("en-US"));
            enddate = enddate1.ToString("yyyy-MM-dd", new CultureInfo("en-US"));
            dt = ic.ivfDB.oJpxdDB.selectByDate(startdate, enddate);
            grfRpt.Rows.Count = 1;
            grfRpt.Rows.Count = dt.Rows.Count + 1;
            grfRpt.Cols.Count = 7;

            grfRpt.Cols[colRptDrugDailyDrugCode].Width = 80;
            grfRpt.Cols[colRptDrugDailyDrugName].Width = 300;
            grfRpt.Cols[colRptDrugDailyPttHn].Width = 100;
            grfRpt.Cols[colRptDrugDailyPttName].Width = 300;
            grfRpt.Cols[colRptDrugDailyQty].Width = 80;
            grfRpt.Cols[colRptDrugDailyTime].Width = 140;
            grfRpt.Cols[colRptDrugDailyTime].Caption = "TIME";
            grfRpt.Cols[colRptDrugDailyQty].Caption = "QTY";
            grfRpt.Cols[colRptDrugDailyPttName].Caption = "Patient Name";
            grfRpt.Cols[colRptDrugDailyPttHn].Caption = "HN";
            grfRpt.Cols[colRptDrugDailyDrugName].Caption = "NAME";
            grfRpt.Cols[colRptDrugDailyDrugCode].Caption = "CODE";
            grfRpt.Cols[colRptDrugDailyTime].Caption = "Date ";
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&receive operation", new EventHandler(ContextMenu_Apm));
            grfRpt.ContextMenu = menuGw;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                grfRpt[i, colRptDrugDailyDrugCode] = row["DUID"].ToString();
                grfRpt[i, colRptDrugDailyDrugName] = row["DUName"].ToString();
                grfRpt[i, colRptDrugDailyPttHn] = ic.showHN(row["PIDS"].ToString(), row["patient_year"].ToString());
                grfRpt[i, colRptDrugDailyPttName] = row["patient_name"].ToString();
                grfRpt[i, colRptDrugDailyQty] = row["QTY"].ToString();
                grfRpt[i, colRptDrugDailyTime] = ic.datetimetoShow(row["pharmacy_finish_date_time"].ToString());
                i++;
            }
            grfRpt.Cols[colRptDrugDailyDrugCode].AllowEditing = false;
            grfRpt.Cols[colRptDrugDailyDrugName].AllowEditing = false;
            grfRpt.Cols[colRptDrugDailyPttHn].AllowEditing = false;
            grfRpt.Cols[colRptDrugDailyPttName].AllowEditing = false;
            grfRpt.Cols[colRptDrugDailyQty].AllowEditing = false;
            grfRpt.Cols[colRptDrugDailyTime].AllowEditing = false;
        }
        private void initGrfRpt()
        {
            grfRpt = new C1FlexGrid();
            grfRpt.Font = fEdit;
            grfRpt.Dock = System.Windows.Forms.DockStyle.Fill;
            grfRpt.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            //grfSearch.DoubleClick += GrfSearch_DoubleClick;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            //ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //grfSearch.ContextMenu = menuGw;
            scRptRight.Controls.Add(grfRpt);
            grfRpt.Rows.Count = 1;
            theme1.SetTheme(grfRpt, "Office2010Red");

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
            openNurseAdd3();
        }

        private void initGrfQue()
        {
            grfQue = new C1FlexGrid();
            grfQue.Font = fEdit;
            grfQue.Dock = System.Windows.Forms.DockStyle.Fill;
            grfQue.Location = new System.Drawing.Point(0, 0);

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
        private void openNurseAdd1()
        {
            String chk = "", name = "", id = "", pttId = "";

            id = grfQue[grfQue.Row, colID] != null ? grfQue[grfQue.Row, colID].ToString() : "";
            pttId = grfQue[grfQue.Row, colPttId] != null ? grfQue[grfQue.Row, colPttId].ToString() : "";
            chk = grfQue[grfQue.Row, colPttHn] != null ? grfQue[grfQue.Row, colPttHn].ToString() : "";
            name = grfQue[grfQue.Row, colPttName] != null ? grfQue[grfQue.Row, colPttName].ToString() : "";
            //FrmNurseAdd frm = new FrmNurseAdd();
            //frm.ShowDialog(this);
            ic.ivfDB.vsDB.updateStatusPharmacyProcess(id);
            openNurseAdd(pttId, id, name, "edit");
        }
        private void openNurseAdd3()
        {
            String chk = "", name = "", id = "", pttId = "";

            id = grfSearch[grfSearch.Row, colID] != null ? grfSearch[grfSearch.Row, colID].ToString() : "";
            pttId = grfSearch[grfSearch.Row, colPttId] != null ? grfSearch[grfSearch.Row, colPttId].ToString() : "";
            chk = grfSearch[grfSearch.Row, colPttHn] != null ? grfSearch[grfSearch.Row, colPttHn].ToString() : "";
            name = grfSearch[grfSearch.Row, colPttName] != null ? grfSearch[grfSearch.Row, colPttName].ToString() : "";
            //FrmNurseAdd frm = new FrmNurseAdd();
            //frm.ShowDialog(this);

            openNurseAdd(pttId, id, name, "noedit");
        }
        private void openNurseAdd2()
        {
            String chk = "", name = "", id = "", pttId = "";

            id = grfFinish[grfFinish.Row, colID] != null ? grfFinish[grfFinish.Row, colID].ToString() : "";
            pttId = grfFinish[grfFinish.Row, colPttId] != null ? grfFinish[grfFinish.Row, colPttId].ToString() : "";
            chk = grfFinish[grfFinish.Row, colPttHn] != null ? grfFinish[grfFinish.Row, colPttHn].ToString() : "";
            name = grfFinish[grfFinish.Row, colPttName] != null ? grfFinish[grfFinish.Row, colPttName].ToString() : "";
            //FrmNurseAdd frm = new FrmNurseAdd();
            //frm.ShowDialog(this);

            openNurseAdd(pttId, id, name, "noedit");
        }
        private void openNurseAdd(String pttId, String vsid, String name, String flagview)
        {
            FrmPharmaAdd frm = new FrmPharmaAdd(ic, menu, pttId, vsid, flagview);
            String txt = "";
            if (!name.Equals(""))
            {
                txt = "Pharmacy " + name;
            }

            frm.FormBorderStyle = FormBorderStyle.None;
            C1DockingTabPage tab = menu.AddNewTab(frm, txt);
            frm.tab = tab;
            frm.frmPharView = this;
        }
        private void initGrfFinish()
        {
            grfFinish = new C1FlexGrid();
            grfFinish.Font = fEdit;
            grfFinish.Dock = System.Windows.Forms.DockStyle.Fill;
            grfFinish.Location = new System.Drawing.Point(0, 0);

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
            openNurseAdd2();
        }

        private void GrfFinish_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();

        }
        private void TxtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.Enter)
            {
                setGrfSearch(txtSearch.Text.Trim());                
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
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            
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
            if (tC.SelectedTab == tabFinish)
            {
                setGrfQue();
                setGrfFinish();
            }
            else if (tC.SelectedTab == tabWaiting)
            {
                setGrfQue();
                //setGrfFinish();
            }
        }
        public void setGrfQuePublic()
        {
            setGrfQue();
        }
        private void setGrfQue()
        {
            //if (pageLoad == true)
            //    return;            
            setGrfQue(txtSearch.Text);            
        }
        private void setGrfQue(String search)
        {
            //grfDept.Rows.Count = 7;
            //grfQue.Clear();
            DataTable dt1 = new DataTable();
            DataTable dt = new DataTable();
            if (search.Equals(""))
            {
                String date = "";
                DateTime dt11 = new DateTime();
                if (DateTime.TryParse(txtDateStart.Text, out dt11))
                {
                    //dt11 = dt11.AddDays(-1);
                    date = dt11.Year + "-" + dt11.ToString("MM-dd");
                    //dt = ic.ivfDB.ovsDB.selectByDate(date);
                }
                if (chkAll.Checked)
                    //dt = ic.ivfDB.ovsDB.selectByReceptionSend();      //      -0020   
                                                                      //dt = ic.ivfDB.vsDB.selectByReceptionSend();        //      +0020                else
                    //dt = ic.ivfDB.ovsDB.selectByStatusCashierFinish(cboVisitBsp.SelectedItem == null ? "" : ((ComboBoxItem)cboVisitBsp.SelectedItem).Value);      //      -0020
                    dt = ic.ivfDB.vsDB.selectByStatusCashierFinish();        //      +0020
            }
            else
            {
                //grfPtt.DataSource = ic.ivfDB.vsOldDB.selectCurrentVisit(search);
            }

            grfQue.Rows.Count = 1;
            grfQue.Rows.Count = dt.Rows.Count + 1;
            grfQue.Cols.Count = 14;
            //C1TextBox txt = new C1TextBox();
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
            grfQue.Cols[colStatusNurse].Width = 50;
            grfQue.Cols[colStatusCashier].Width = 55;

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
                grfQue[i, colPttHn] = ic.showHN(row["PIDS"].ToString(), row["patient_year"].ToString());
                grfQue[i, colPttName] = row["PName"].ToString();
                grfQue[i, colVsDate] = ic.datetoShow(row["VDate"]);
                grfQue[i, colVsTime] = ic.timetoShow(row["VStartTime"].ToString());
                grfQue[i, colVsEtime] = ic.timetoShow(row["VEndTime"].ToString());
                grfQue[i, colStatus] = row["VName"].ToString();
                grfQue[i, colPttId] = row["PID"].ToString();
                grfQue[i, colDtr] = row["dtrname"].ToString();
                grfQue[i, colStatusNurse] = row["status_nurse"].ToString();
                grfQue[i, colStatusCashier] = row["status_cashier"].ToString();
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
            //theme1.SetTheme(grfQue, ic.theme);

        }
        private void setGrfFinish(String search)
        {
            //grfDept.Rows.Count = 7;
            //grfFinish.Clear();
            DataTable dt = new DataTable();
            //if (search.Equals(""))        //-0020
            //{        //-0020
            String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
                //dt = ic.ivfDB.ovsDB.selectByStatusNurseFinish(ic.datetoDB(txtDateStart.Text));        //-0020
            dt = ic.ivfDB.vsDB.selectByStatusPhamacyFinish(date);           //+0020
            //}        //-0020
            //else        //-0020
            //{        //-0020
            //    //grfPtt.DataSource = ic.ivfDB.vsOldDB.selectCurrentVisit(search);
            //    if (txtDateStart.Text.Equals(""))        //-0020
            //    {        //-0020
            //        dt = ic.ivfDB.ovsDB.selectByStatusNurseFinishLike(search);        //-0020
            //    }        //-0020
            //}        //-0020

            grfFinish.Rows.Count = 1;
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
                grfFinish[i, colVNshow] = ic.showVN(row["VN"].ToString());
                grfFinish[i, colPttHn] = ic.showHN(row["PIDS"].ToString(), row["patient_year"].ToString());
                grfFinish[i, colPttName] = row["PName"].ToString();
                grfFinish[i, colVsDate] = ic.datetoShow(row["VDate"]);
                grfFinish[i, colVsTime] = ic.timetoShow(row["VStartTime"].ToString());
                grfFinish[i, colVsEtime] = ic.timetoShow(row["VEndTime"].ToString());
                grfFinish[i, colStatus] = row["VName"].ToString();
                grfFinish[i, colPttId] = row["PID"].ToString();
                grfFinish[i, colVn] = row["VN"].ToString();
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
            grfFinish.Cols[colVn].Visible = false;
            grfFinish.Cols[colDtr].Visible = false;
            grfFinish.Cols[colStatusNurse].Visible = false;
            grfFinish.Cols[colStatusCashier].Visible = false;

            grfFinish.Cols[colVNshow].AllowEditing = false;
            grfFinish.Cols[colPttHn].AllowEditing = false;
            grfFinish.Cols[colPttName].AllowEditing = false;
            grfFinish.Cols[colVsDate].AllowEditing = false;
            grfFinish.Cols[colVsTime].AllowEditing = false;
            grfFinish.Cols[colVsEtime].AllowEditing = false;
            grfFinish.Cols[colStatus].AllowEditing = false;
            //theme1.SetTheme(grfFinish, ic.theme);

        }
        private void setGrfSearch(String search)
        {
            //grfDept.Rows.Count = 7;
            tC.SelectedTab = tabSearch;
            //grfSearch.Clear();
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
                dt = ic.ivfDB.vsDB.selectByStatusCashierSearch(txtSearch.Text, ic.datetoDB(txtDateStart.Text));        //+0020
                //grfPtt.DataSource = ic.ivfDB.vsOldDB.selectCurrentVisit(search);
            }

            grfSearch.Rows.Count = 1;
            grfSearch.Rows.Count = dt.Rows.Count + 1;
            grfSearch.Cols.Count = 10;
            //C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            //grfSearch.Cols[colPttHn].Editor = txt;
            //grfSearch.Cols[colPttName].Editor = txt;
            //grfSearch.Cols[colVsDate].Editor = txt;

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
                grfSearch[i, colVsTime] = ic.timetoShow(row["VStartTime"].ToString());
                grfSearch[i, colVsEtime] = ic.timetoShow(row["VEndTime"].ToString());
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

            grfSearch.Cols[colVNshow].AllowEditing = false;
            grfSearch.Cols[colPttHn].AllowEditing = false;
            grfSearch.Cols[colPttName].AllowEditing = false;
            grfSearch.Cols[colVsDate].AllowEditing = false;
            grfSearch.Cols[colVsTime].AllowEditing = false;
            grfSearch.Cols[colVsEtime].AllowEditing = false;
            grfSearch.Cols[colStatus].AllowEditing = false;
            grfSearch.Cols[colPttId].AllowEditing = false;
            //theme1.SetTheme(grfQue, ic.theme);

        }
        public void setGrfFinishPublic()
        {
            setGrfFinish();
        }
        private void setGrfFinish()
        {            
            setGrfFinish(txtSearch.Text);
        }
        private void FrmPharmaView_Load(object sender, EventArgs e)
        {
            tC.SelectedTab = tabWaiting;
            chkAll.Checked = false;
            setGrfQue();
            setGrfFinish();
            theme1.SetTheme(tC, ic.theme);
            txtDateStart.ErrorInfo.C1SuperErrorProvider = sep;
        }
    }
}
