﻿using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1SuperTooltip;
using clinic_ivf.control;
using clinic_ivf.FlexGrid;
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
    /*
     * 64-02-27     0027     เรื่อง		หน้าจอ labspermview ใส่ รหัสผิด
     * */
    public partial class FrmLabSpermView : Form
    {
        IvfControl ic;
        MainMenu menu;

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;
        int colRqId = 1, colOPUDate = 2, colOPUTime = 3, colRqLabName = 4, colRqHnMale = 5, colRqNameMale = 6, colRqHn = 7, colRqName =8, colDtrName = 9, colRqRemark = 10, colRqReqNum = 11, colRqDate = 12, colRqVn = 13, colOpuId = 14, colRqStatusSperm = 15;
        //int colPcId = 1, colPcOpuNum = 2, colPcHn = 3, colPcPttName = 4, colPcDate = 5, colPcRemark = 6;
        int colPcId = 1, colPcDate = 2, colPcTime=3, colPcHnMale = 4, colPcNameMale = 5, colPcSpermName = 6, colPcRemark = 7, colPcStatusSperm=8, colPcDtfName=9;
        int colFiId = 1, colFiDate = 2, colFiHnMale = 3, colFiNameMale = 4, colFiHn = 5, colFiPttName = 6, colFiProceName = 7, colFiRemark = 8, colFiOpuNum = 9;

        C1FlexGrid grfReq, grfProc, grfSearch, grfFinish;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        LabOpu opu;
        Timer timer;

        public FrmLabSpermView(IvfControl ic, MainMenu m)
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
            //txtDateEnd.Value = System.DateTime.Now;
            //txtDateStart.Value = System.DateTime.Now;
            txtFiDateEnd.Value = System.DateTime.Now;
            txtFiDateStart.Value = System.DateTime.Now;
            //C1ThemeController.ApplicationTheme = ic.iniC.themeApplication;
            theme1.Theme = ic.iniC.themeApplication;
            theme1.SetTheme(sB, "BeigeOne");

            sB1.Text = "";
            bg = txtSearch.BackColor;
            fc = txtSearch.ForeColor;
            ff = txtSearch.Font;

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            opu = new LabOpu();

            int timerlab = 0;
            int.TryParse(ic.iniC.timerlabreqaccept, out timerlab);
            timer = new Timer();
            timer.Interval = timerlab * 1000;
            timer.Tick += Timer_Tick;
            timer.Enabled = true;

            //btnNew.Click += BtnNew_Click;
            btnSearchF.Click += BtnSearchF_Click;
            txtSearch.KeyUp += TxtSearch_KeyUp;
            tcLabView.TabClick += TcLabView_TabClick;
            tcLabView.SelectedTabChanged += TcLabView_SelectedTabChanged;
            btnSearch.Click += BtnSearch_Click;
            //btnAna.Click += BtnAna_Click;
            //btnFreezing.Click += BtnFreezing_Click;
            //btnPesa.Click += BtnPesa_Click;
            //btnIui.Click += BtnIui_Click;

            initGrfReq();
            initGrfProc();
            initGrfFinish();
            //setGrfReq();
            //setGrfProc();
            //setGrfFinish();
            initGrfSearch();   //111
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setGrfSearch();
        }

        private void TcLabView_SelectedTabChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (tcLabView.SelectedTab == tabLabAccept)
            {
                setGrfReq();
            }
            else if (tcLabView.SelectedTab == tabProcess)
            {
                setGrfProc();
            }
            else if (tcLabView.SelectedTab == tabLabFinish)
            {
                setGrfFinish();
            }
            else if (tcLabView.SelectedTab == tabSearch)
            {
                txtSearch.Focus();
            }
        }

        private void TcLabView_TabClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if(tcLabView.SelectedTab == tabProcess)
            {
                setGrfProc();
            }
            else if (tcLabView.SelectedTab == tabLabFinish)
            {
                setGrfFinish();
            }
            else if (tcLabView.SelectedTab == tabLabAccept)
            {
                setGrfReq();
            }
        }
        private void BtnSearchF_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setGrfFinish();
        }

        private void BtnIui_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmLabSpermAdd frm = new FrmLabSpermAdd(ic, "", "", "4");
            frm.StatusSperm = "4";
            String txt = "";
            txt = "ป้อน LAB Sperm IUI ";
            frm.FormBorderStyle = FormBorderStyle.None;
            
            menu.AddNewTab(frm, txt);
        }

        private void BtnPesa_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmLabSpermAdd frm = new FrmLabSpermAdd(ic, "", "", "3");
            frm.StatusSperm = "3";
            String txt = "";
            txt = "ป้อน LAB Sperm PESA ";
            frm.FormBorderStyle = FormBorderStyle.None;
            
            menu.AddNewTab(frm, txt);
        }

        private void BtnFreezing_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmLabSpermAdd frm = new FrmLabSpermAdd(ic, "", "", "1");
            String txt = "";
            txt = "ป้อน LAB Sperm Freezing ";
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.StatusSperm = "2";
            menu.AddNewTab(frm, txt);
        }

        private void BtnAna_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmLabSpermAdd frm = new FrmLabSpermAdd(ic, "", "", "2");
            String txt = "";            
            txt = "ป้อน LAB Sperm Analysis ";
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.StatusSperm = "1";
            menu.AddNewTab(frm, txt);
        }

        private void TxtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.Enter)
            {
                setGrfSearch();
            }
        }

        private void BtnSearchA_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setGrfReq();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setGrfReq();
            setGrfProc();
        }
        private void initGrfSearch()
        {
            grfSearch = new C1FlexGrid();
            grfSearch.Font = fEdit;
            grfSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            grfSearch.Location = new System.Drawing.Point(0, 0);
            grfSearch.Rows.Count = 2;
            //FilterRow fr = new FilterRow(grfExpn);

            //grfSearch.AfterRowColChange += GrfReq_AfterRowColChange;
            grfSearch.DoubleClick += GrfSearch_DoubleClick;
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            //ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("ป้อน LAB OPU/FET", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("รับทราบการเปลี่ยนแปลงเวลา", new EventHandler(ContextMenu_Gw_time_modi));
            ////menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            //grfReq.ContextMenu = menuGw;
            pnSearch.Controls.Add(grfSearch);

            theme1.SetTheme(grfSearch, "Office2010Blue");
        }

        private void GrfSearch_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfSearch.Row <= 0) return;
            if (grfSearch.Col <= 0) return;
            String chk = "", name = "", id = "";
            id = grfSearch[grfSearch.Row, colPcId] != null ? grfSearch[grfSearch.Row, colPcId].ToString() : "";
            chk = grfSearch[grfSearch.Row, colPcStatusSperm] != null ? grfSearch[grfSearch.Row, colPcStatusSperm].ToString() : "";
            name = grfSearch[grfSearch.Row, colPcNameMale] != null ? grfSearch[grfSearch.Row, colPcNameMale].ToString() : "";
            //if (MessageBox.Show("ต้องการ ป้อน LAB OPU  \n  opu number " + chk + " \n name " + name, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            //grfReq.Rows.Remove(grfReq.Row);
            Cursor curOld;
            curOld = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            openLabOPUAdd(id, name, chk.Equals("2") ? " Analysis " : chk.Equals("1") ? " Freezing " : chk.Equals("3") ? " PESA " : " IUI ", chk);
            this.Cursor = curOld;
        }

        private void setGrfSearch()
        {
            grfSearch.DataSource = null;
            //grfSearch.Clear();
            DataTable dt = new DataTable();

            dt = ic.ivfDB.lspermDB.selectByStatusFinishHN(txtSearch.Text.Trim());
            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfSearch.Rows.Count = 1;
            grfSearch.Cols.Count = 16;
            C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            //grfSearch.Cols[colPcOpuNum].Editor = txt;
            //grfSearch.Cols[colPcHn].Editor = txt;
            //grfSearch.Cols[colPcPttName].Editor = txt;
            //grfSearch.Cols[colPcDate].Editor = txt;
            //grfSearch.Cols[colPcRemark].Editor = txt;

            grfSearch.Cols[colPcDate].Width = 120;
            grfSearch.Cols[colPcHnMale].Width = 120;
            grfSearch.Cols[colPcNameMale].Width = 200;
            grfSearch.Cols[colPcSpermName].Width = 200;
            grfSearch.Cols[colPcRemark].Width = 200;
            grfSearch.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfSearch.Cols[colPcDate].Caption = "Date";
            grfSearch.Cols[colPcHnMale].Caption = "HN";
            grfSearch.Cols[colPcNameMale].Caption = "Name";
            grfSearch.Cols[colPcSpermName].Caption = "LAB";
            grfSearch.Cols[colPcRemark].Caption = "Reamrk";
            grfSearch.Cols[colPcTime].Caption = "Time";
            //grfSearch.Cols[colRqRemark].Caption = "Remark";
            //grfSearch.Cols[colDtrName].Caption = "Doctor";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                Row row1 = grfSearch.Rows.Add();
                row1[colPcId] = row[ic.ivfDB.lspermDB.lsperm.sperm_id].ToString();
                //row1[colRqReqNum] = "";
                row1[colPcHnMale] = row[ic.ivfDB.lspermDB.lsperm.hn_male].ToString();
                //row1[colRqVn] = "";
                row1[colPcNameMale] = row[ic.ivfDB.lspermDB.lsperm.name_male].ToString();
                //row1[colRqDate] = "";
                row1[colPcRemark] = row[ic.ivfDB.lspermDB.lsperm.remark].ToString();
                if (row[ic.ivfDB.lspermDB.lsperm.status_lab_sperm].ToString().Equals("1"))
                {
                    row1[colPcDate] = ic.datetoShow(row[ic.ivfDB.lspermDB.lsperm.sperm_analysis_date_start].ToString());
                    row1[colPcTime] = ic.timetoShow(row[ic.ivfDB.lspermDB.lsperm.sperm_analysis_date_start].ToString());
                }
                else if (row[ic.ivfDB.lspermDB.lsperm.status_lab_sperm].ToString().Equals("2"))
                {
                    row1[colPcDate] = ic.datetoShow(row[ic.ivfDB.lspermDB.lsperm.spern_freezing_date_start].ToString());
                    row1[colPcTime] = ic.timetoShow(row[ic.ivfDB.lspermDB.lsperm.spern_freezing_date_start].ToString());
                }
                else if (row[ic.ivfDB.lspermDB.lsperm.status_lab_sperm].ToString().Equals("3"))
                {
                    row1[colPcDate] = ic.datetoShow(row[ic.ivfDB.lspermDB.lsperm.pasa_tese_date].ToString());
                    //row1[colOPUTime] = ic.timetoShow(row[ic.ivfDB.lspermDB.lsperm.sperm_analysis_date_start].ToString());
                }
                else if (row[ic.ivfDB.lspermDB.lsperm.status_lab_sperm].ToString().Equals("4"))
                {
                    row1[colPcDate] = ic.datetoShow(row[ic.ivfDB.lspermDB.lsperm.iui_date].ToString());
                    //row1[colOPUTime] = ic.timetoShow(row[ic.ivfDB.lspermDB.lsperm.sperm_analysis_date_start].ToString());
                }
                row1[colPcStatusSperm] = row[ic.ivfDB.lspermDB.lsperm.status_lab_sperm].ToString();
                row1[colPcSpermName] = row[ic.ivfDB.lspermDB.lsperm.status_lab_sperm].ToString().Equals("2") ? "Sperm Freezing"
                    : row[ic.ivfDB.lspermDB.lsperm.status_lab_sperm].ToString().Equals("1") ? "Sperm Analysis"
                    : row[ic.ivfDB.lspermDB.lsperm.status_lab_sperm].ToString().Equals("3") ? " PESA"
                    : row[ic.ivfDB.lspermDB.lsperm.status_lab_sperm].ToString().Equals("4") ? " IUI " : "";
                //row1[colRqHnMale] = row[ic.ivfDB.lspermDB.lsperm.hn_male].ToString();
                //row1[colRqNameMale] = row[ic.ivfDB.lspermDB.lsperm.name_male].ToString();
                row1[colPcDtfName] = row["dtr_name"].ToString();
                //row1[colOpuId] = "";
                //row1[colDtrName] = row["dtr_name"].ToString();
                row1[0] = (i - 1);
                i++;
            }
            grfSearch.Cols[colPcId].Visible = false;
            //grfReq.Cols[coldt].Visible = false;
            grfSearch.Cols[colPcDate].AllowEditing = false;
            grfSearch.Cols[colPcRemark].AllowEditing = false;
            grfSearch.Cols[colPcHnMale].AllowEditing = false;
            grfSearch.Cols[colPcNameMale].AllowEditing = false;
            grfSearch.Cols[colPcSpermName].AllowEditing = false;
            grfSearch.Cols[colPcTime].AllowEditing = false;
        }
        private void initGrfReq()
        {
            grfReq = new C1FlexGrid();
            grfReq.Font = fEdit;
            grfReq.Dock = System.Windows.Forms.DockStyle.Fill;
            grfReq.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            grfReq.AfterRowColChange += GrfReq_AfterRowColChange;
            grfReq.DoubleClick += GrfReq_DoubleClick;
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            //ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("ป้อน LAB OPU/FET", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("รับทราบการเปลี่ยนแปลงเวลา", new EventHandler(ContextMenu_Gw_time_modi));
            ////menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            //grfReq.ContextMenu = menuGw;
            gB.Controls.Add(grfReq);

            theme1.SetTheme(grfReq, "Office2010Blue");
        }

        private void GrfReq_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ContextMenu_edit(null, null);
        }

        private void ContextMenu_Gw_time_modi(object sender, System.EventArgs e)
        {
            String chk = "", name = "", id = "";

            id = grfReq[grfReq.Row, colRqId] != null ? grfReq[grfReq.Row, colRqId].ToString() : "";
            chk = grfReq[grfReq.Row, colRqReqNum] != null ? grfReq[grfReq.Row, colRqReqNum].ToString() : "";
            name = grfReq[grfReq.Row, colRqName] != null ? grfReq[grfReq.Row, colRqName].ToString() : "";
            FrmLabOPUTimeModi frm = new FrmLabOPUTimeModi(ic, id, id);
            frm.ShowDialog(this);
        }
        private void ContextMenu_edit(object sender, System.EventArgs e)
        {
            String chk = "", name = "", id = "";

            id = grfReq[grfReq.Row, colRqId] != null ? grfReq[grfReq.Row, colRqId].ToString() : "";
            chk = grfReq[grfReq.Row, colRqStatusSperm] != null ? grfReq[grfReq.Row, colRqStatusSperm].ToString() : "";
            name = grfReq[grfReq.Row, colRqName] != null ? grfReq[grfReq.Row, colRqName].ToString() : "";
            //if (MessageBox.Show("ต้องการ ป้อน LAB OPU  \n  req number " + chk+" \n name "+ name, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            //grfReq.Rows.Remove(grfReq.Row);
            Cursor curOld;
            curOld = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            //openLabSpermNew(id, name, chk.Equals("2") ? " Analysis " : chk.Equals("1") ? " Freezing " : chk.Equals("3") ? " PESA " : " IUI ");        //-0027
            openLabSpermNew(id, name, chk.Equals("1") ? " Analysis " : chk.Equals("2") ? " Freezing " : chk.Equals("3") ? " PESA " : " IUI ");        //+0027
            setGrfReq();
            setGrfProc();
            this.Cursor = curOld;
            //}
        }
        private void GrfReq_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;
            String vn = "";

            //grfAddr.DataSource = xC.iniDB.addrDB.selectByTableId1(vn);
        }
        private void setGrfReq()
        {
            //grfReq.DataSource = null;
            //grfReq.Clear();
            DataTable dt = new DataTable();
            //DateTime datestart, dateend;
            String datestart1 = "", dateend1 = "";
            //if (DateTime.TryParse(txtDateStart.Text, out datestart))
            //{
            //    datestart1 = datestart.ToString("yyyy-MM-dd");
            //}
            //else
            //{
            //    datestart1 = ic.datetoDB(txtDateStart.Text);
            //}
            //if (DateTime.TryParse(txtDateEnd.Text, out datestart))
            //{
            //    dateend1 = datestart.ToString("yyyy-MM-dd");
            //}
            //else
            //{
            //    dateend1 = ic.datetoDB(txtDateEnd.Text);
            //}
            //dt = ic.ivfDB.lbReqDB.selectByStatusReqAccept();
            //dt = ic.ivfDB.lbReqDB.selectBySpermStatusUnAccept(datestart1, dateend1);
            dt = ic.ivfDB.lbReqDB.selectBySpermStatusUnAccept();
            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfReq.Rows.Count = 1;
            grfReq.Cols.Count = 18;
            //C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            //grfReq.Cols[colRqReqNum].Editor = txt;
            //grfReq.Cols[colRqHn].Editor = txt;
            //grfReq.Cols[colRqVn].Editor = txt;
            //grfReq.Cols[colRqName].Editor = txt;

            grfReq.Cols[colRqHn].Width = 100;
            grfReq.Cols[colRqVn].Width = 120;
            grfReq.Cols[colRqName].Width = 200;
            grfReq.Cols[colRqDate].Width = 100;
            grfReq.Cols[colDtrName].Width = 200;
            grfReq.Cols[colRqRemark].Width = 200;
            grfReq.Cols[colRqLabName].Width = 120;
            grfReq.Cols[colOPUDate].Width = 100;
            grfReq.Cols[colOPUTime].Width = 70;
            grfReq.Cols[colRqStatusSperm].Width = 70;
            grfReq.Cols[colRqHnMale].Width = 100;
            grfReq.Cols[colRqNameMale].Width = 200;
            //grfReq.Cols[colRqHnDonor].Width = 100;
            //grfReq.Cols[colRqNameDonor].Width = 280;
            grfReq.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfReq.Cols[colRqReqNum].Caption = "req number";
            grfReq.Cols[colRqHn].Caption = "HN Female";
            grfReq.Cols[colRqVn].Caption = "VN";
            grfReq.Cols[colRqName].Caption = "Name Female";
            grfReq.Cols[colRqDate].Caption = "Date Req";
            grfReq.Cols[colRqRemark].Caption = "Remark";
            grfReq.Cols[colDtrName].Caption = "Doctor";
            grfReq.Cols[colRqLabName].Caption = "Lab Name";
            grfReq.Cols[colOPUDate].Caption = " Date";
            grfReq.Cols[colOPUTime].Caption = " Time";
            grfReq.Cols[colRqStatusSperm].Caption = "status sperm";
            grfReq.Cols[colRqHnMale].Caption = "HN male";
            grfReq.Cols[colRqNameMale].Caption = "Name male";
            //grfReq.Cols[colRqHnDonor].Caption = "HN donor";
            //grfReq.Cols[colRqNameDonor].Caption = "Name donor";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            String chk = "";
            foreach (DataRow row in dt.Rows)
            {
                Row row1 = grfReq.Rows.Add();
                row1[colRqId] = row[ic.ivfDB.lbReqDB.lbReq.req_id].ToString();
                row1[colRqReqNum] = row[ic.ivfDB.lbReqDB.lbReq.req_code].ToString();
                //row1[colRqHn] = row[ic.ivfDB.lbReqDB.lbReq.hn_female].ToString();
                //row1[colRqHn] = row["hn_male"].ToString();
                row1[colRqHn] = row["patient_hn_1"].ToString();
                row1[colRqVn] = row[ic.ivfDB.lbReqDB.lbReq.vn].ToString();
                //row1[colRqName] = row[ic.ivfDB.lbReqDB.lbReq.name_female].ToString();
                row1[colRqName] = row["patient_name_hn_1"].ToString();
                row1[colRqDate] = ic.datetoShow(row[ic.ivfDB.lbReqDB.lbReq.req_date].ToString());
                //String remark = "";
                //remark = row["form_a_remark"].ToString();
                //if (row["item_id"].ToString().Equals("2630000014"))
                //{
                //    remark += row["sperm_sa_remark"].ToString();
                //}
                //else if (row["item_id"].ToString().Equals("2630000018"))
                //{
                //    remark += row["sperm_freezing_remark"].ToString();
                //}
                //row1[colRqRemark] = remark;

                row1[colOPUDate] = ic.datetoShow(row[ic.ivfDB.lFormaDB.lformA.sperm_analysis_date_start].ToString());
                row1[colOPUTime] = ic.timetoShow(row[ic.ivfDB.lFormaDB.lformA.sperm_analysis_date_start].ToString());
                //row1[colRqStatusSperm] = row[ic.ivfDB.lbReqDB.lbReq.sta].ToString();
                row1[colRqLabName] = row["LName"].ToString();
                //row1[colRqHnMale] = row["hn_male"].ToString();
                //row1[colRqNameMale] = row["name_male"].ToString();

                //row1[colRqHnMale] = row["patient_hn_1"].ToString();        //-0027
                //row1[colRqNameMale] = row["patient_name_hn_1"].ToString();        //-0027
                row1[colRqHnMale] = row["visit_hn"].ToString();         //+0027
                row1[colRqNameMale] = row["patient_name"].ToString();         //+0027
                //row1[colRqStatusSperm] = row["item_id"].ToString().Equals("2630000014") ? "Sperm Analysis"        //-0027
                //    : row["item_id"].ToString().Equals("18") ? "Sperm Freezing"        //-0027
                //    : row["item_id"].ToString().Equals("2630000066") ? "PESA/TESE"        //-0027
                //    : row["item_id"].ToString().Equals("88") ? "IUI" : "";        //-0027
                //row1[colRqStatusSperm] = row["item_id"].ToString().Equals("2630000014") ? "2"   //"Sperm Freezing"         //-0027
                //    : row["item_id"].ToString().Equals("2630000018") ? "1"      //"Sperm Analysis"         //-0027
                //    : row["item_id"].ToString().Equals("2630000066") ? "3"        //-0027
                //    : row["item_id"].ToString().Equals("26300000196") ? "4" : "";        //-0027
                row1[colRqStatusSperm] = row["item_id"].ToString().Equals("2630000014") ? "1"   //"Sperm Analysis"         //+0027
                    : row["item_id"].ToString().Equals("2630000018") ? "2"      //"Sperm Freezing"          //+0027
                    : row["item_id"].ToString().Equals("2630000066") ? "3"
                    : row["item_id"].ToString().Equals("26300000196") ? "4" : "";
                if (row1[colRqStatusSperm].ToString().Equals("1"))      // sperm analysis
                {
                    row1[colOPUDate] = ic.datetoShow(row[ic.ivfDB.lFormaDB.lformA.sperm_analysis_date_start].ToString());
                    row1[colOPUTime] = ic.timetoShow(row[ic.ivfDB.lFormaDB.lformA.sperm_analysis_date_start].ToString());
                    row1[colRqRemark] = row["sperm_sa_remark"].ToString();
                }
                else if (row1[colRqStatusSperm].ToString().Equals("2"))      // sperm Freezing
                {
                    row1[colOPUDate] = ic.datetoShow(row[ic.ivfDB.lFormaDB.lformA.sperm_freezing_date_start].ToString());
                    row1[colOPUTime] = ic.timetoShow(row[ic.ivfDB.lFormaDB.lformA.sperm_freezing_date_start].ToString());
                    row1[colRqRemark] = row["sperm_freezing_remark"].ToString();
                }
                else if (row1[colRqStatusSperm].ToString().Equals("3"))      // sperm Pesa
                {
                    row1[colOPUDate] = ic.datetoShow(row[ic.ivfDB.lFormaDB.lformA.pasa_tese_date].ToString());
                    //row1[colOPUTime] = ic.timetoShow(row[ic.ivfDB.lFormaDB.lformA.sperm_freezing_date_start].ToString());
                }
                else if (row1[colRqStatusSperm].ToString().Equals("4"))      // sperm IUI
                {
                    //row1[colOPUDate] = ic.datetoShow(row[ic.ivfDB.lFormaDB.lformA.iui_date].ToString());
                    row1[colOPUDate] = ic.datetoShow(row[ic.ivfDB.lFormaDB.lformA.sperm_iui_date].ToString());
                    row1[colOPUTime] = ic.timetoShow(row[ic.ivfDB.lFormaDB.lformA.sperm_iui_start_time].ToString());
                    //row1[colOPUTime] = ic.timetoShow(row[ic.ivfDB.lFormaDB.lformA.sperm_freezing_date_start].ToString());
                }//row1[colRqHnDonor] = row["hn_donor"].ToString();
                 //row1[colRqNameDonor] = row["name_donor"].ToString();
                if (row["LName"].ToString().Trim().Equals("OPU"))
                {
                    row1[colRqRemark] = row["opu_remark"].ToString() + " " + row["form_a_remark"].ToString();
                }
                else if (row["LName"].ToString().Equals("FET"))
                {
                    row1[colRqRemark] = row["fet_remark"].ToString() + " " + row["form_a_remark"].ToString();
                }
                row1[colOpuId] = "";
                row1[colDtrName] = row["dtr_name"].ToString();
                row1[0] = i;
                if (row1[colRqHnMale].ToString().Equals("BH6200130"))
                {
                    chk = "";
                }
                String txt1 = "";
                //if (row["status_opu_active"].ToString().Equals("1"))
                //{
                //    if (row["status_wait_confirm_opu_date"].ToString().Equals("2"))
                //    {
                //        //grfReq.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
                //        txt1 = "confirm วัน เวลา OPU จากทาง พยาบาล " + row["form_a_remark"].ToString();
                //        if (row[ic.ivfDB.lFormaDB.lformA.status_opu_time_modi].ToString().Equals("1"))
                //        {
                //            txt1 = txt1 + " มีการเปลี่ยนแปลง เวลา OPU จาก " + row[ic.ivfDB.lFormaDB.lformA.opu_time_modi].ToString() + " -> " + row[ic.ivfDB.lFormaDB.lformA.opu_time].ToString();
                //        }

                //        CellNote note = new CellNote(txt1);
                //        CellRange rg = grfReq.GetCellRange(i, colRqHn);
                //        rg.UserData = note;
                //        grfReq.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(ic.iniC.grfRowGreen);
                //    }
                //    else if (row["status_wait_confirm_opu_date"].ToString().Equals("1"))
                //    {
                //        txt1 = "รอ confirm วัน เวลา OPU จากทาง พยาบาล " + row["form_a_remark"].ToString();
                //        if (row[ic.ivfDB.lFormaDB.lformA.status_opu_time_modi].ToString().Equals("1"))
                //        {
                //            txt1 = txt1 + " มีการเปลี่ยนแปลง เวลา OPU จาก " + row[ic.ivfDB.lFormaDB.lformA.opu_time_modi].ToString() + " -> " + row[ic.ivfDB.lFormaDB.lformA.opu_time].ToString();
                //        }
                //        CellNote note = new CellNote(txt1);
                //        CellRange rg = grfReq.GetCellRange(i, colRqHn);
                //        rg.UserData = note;
                //        grfReq.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(ic.iniC.grfRowYellow);
                //    }
                //}
                //else if (row["status_opu_active"].ToString().Equals("2"))
                //{
                //    txt1 = "Wait " + row["opu_wait_remark"].ToString() + " " + row["form_a_remark"].ToString();
                //    if (row[ic.ivfDB.lFormaDB.lformA.status_opu_time_modi].ToString().Equals("1"))
                //    {
                //        txt1 = txt1 + " มีการเปลี่ยนแปลง เวลา OPU จาก " + row[ic.ivfDB.lFormaDB.lformA.opu_time_modi].ToString() + " -> " + row[ic.ivfDB.lFormaDB.lformA.opu_time].ToString();
                //    }
                //    CellNote note = new CellNote(txt1);
                //    CellRange rg = grfReq.GetCellRange(i, colRqHn);
                //    rg.UserData = note;
                //    grfReq.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(ic.iniC.grfRowYellow);
                //}
                //else if (row["status_opu_active"].ToString().Equals("3"))
                //{
                //    txt1 = "Void " + row["opu_wait_remark"].ToString() + " " + row["form_a_remark"].ToString();
                //    if (row[ic.ivfDB.lFormaDB.lformA.status_opu_time_modi].ToString().Equals("1"))
                //    {
                //        txt1 = txt1 + " มีการเปลี่ยนแปลง เวลา OPU จาก " + row[ic.ivfDB.lFormaDB.lformA.opu_time_modi].ToString() + " -> " + row[ic.ivfDB.lFormaDB.lformA.opu_time].ToString();
                //    }
                //    CellNote note = new CellNote(txt1);
                //    CellRange rg = grfReq.GetCellRange(i, colRqHn);
                //    rg.UserData = note;
                //    grfReq.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(ic.iniC.grfRowRed);
                //}
                i++;
            }
            grfReq.Cols[colRqId].Visible = false;
            grfReq.Cols[colRqVn].Visible = false;
            grfReq.Cols[colRqReqNum].AllowEditing = false;
            grfReq.Cols[colRqHn].AllowEditing = false;
            grfReq.Cols[colRqVn].AllowEditing = false;
            grfReq.Cols[colRqName].AllowEditing = false;
            grfReq.Cols[colRqDate].AllowEditing = false;
            grfReq.Cols[colRqRemark].AllowEditing = false;
            grfReq.Cols[colOPUDate].AllowEditing = false;
            grfReq.Cols[colOPUTime].AllowEditing = false;
            grfReq.Cols[colRqStatusSperm].AllowEditing = false;
            grfReq.Cols[colRqLabName].AllowEditing = false;
            grfReq.Cols[colRqHnMale].AllowEditing = false;
            grfReq.Cols[colRqNameMale].AllowEditing = false;
            //grfReq.Cols[colRqHnDonor].AllowEditing = false;
            //grfReq.Cols[colRqNameDonor].AllowEditing = false;
            CellNoteManager mgr = new CellNoteManager(grfReq);
            //grfReq.Cols[coldt].Visible = false;
        }
        private void initGrfProc()
        {
            grfProc = new C1FlexGrid();
            grfProc.Font = fEdit;
            grfProc.Dock = System.Windows.Forms.DockStyle.Fill;
            grfProc.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            grfProc.AfterRowColChange += GrfProc_AfterRowColChange;
            grfProc.DoubleClick += GrfProc_DoubleClick;
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            //ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("ป้อน LAB OPU/FET", new EventHandler(ContextMenu_proc_edit));
            ////menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            ////menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            //grfProc.ContextMenu = menuGw;
            panel2.Controls.Add(grfProc);

            theme1.SetTheme(grfProc, "Office2010Blue");
        }

        private void GrfProc_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ContextMenu_proc_edit(null, null);
        }

        private void setGrfProc()
        {
            grfProc.DataSource = null;
            //grfProc.Clear();
            DataTable dt = new DataTable();
            grfProc.Rows.Count = 0;
            dt = ic.ivfDB.lspermDB.selectByStatusProcess1();
            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            
            grfProc.Rows.Count = 1;            
            grfProc.Cols.Count = 10;
            //C1TextBox txt = new C1TextBox();
            ////C1ComboBox cboproce = new C1ComboBox();
            ////ic.ivfDB.itmDB.setCboItem(cboproce);
            //grfProc.Cols[colPcOpuNum].Editor = txt;
            //grfProc.Cols[colPcHn].Editor = txt;
            //grfProc.Cols[colPcPttName].Editor = txt;
            //grfProc.Cols[colPcDate].Editor = txt;
            //grfProc.Cols[colPcRemark].Editor = txt;

            grfProc.Cols[colPcDate].Width = 120;
            grfProc.Cols[colPcHnMale].Width = 120;
            grfProc.Cols[colPcNameMale].Width = 200;
            grfProc.Cols[colPcSpermName].Width = 200;
            grfProc.Cols[colPcRemark].Width = 200;
            //grfProc.Cols[colRqLabName].Width = 120;
            //grfProc.Cols[colOPUDate].Width = 120;
            //grfProc.Cols[colOPUTime].Width = 80;
            //grfProc.Cols[colRqHnMale].Width = 120;
            //grfProc.Cols[colRqNameMale].Width = 200;

            grfProc.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfProc.Cols[colPcDate].Caption = "Date";
            grfProc.Cols[colPcHnMale].Caption = "HN";
            grfProc.Cols[colPcNameMale].Caption = "Patient Name";
            grfProc.Cols[colPcSpermName].Caption = "LAB";
            grfProc.Cols[colPcRemark].Caption = "Reamrk";
            grfProc.Cols[colPcTime].Caption = "Time";
            //grfProc.Cols[colRqRemark].Caption = "Remark";
            //grfProc.Cols[colDtrName].Caption = "Doctor";
            //grfProc.Cols[colRqLabName].Caption = "Lab Name";
            //grfProc.Cols[colOPUDate].Caption = " Date";
            //grfProc.Cols[colOPUTime].Caption = " Time";
            //grfProc.Cols[colRqStatusSperm].Caption = "opu time old";
            //grfProc.Cols[colRqHnMale].Caption = "HN male";
            //grfProc.Cols[colRqNameMale].Caption = "Name male";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            //for (int col = 0; col < dt.Columns.Count; ++col)
            //{
            //    grfProc.Cols[col + 1].DataType = dt.Columns[col].DataType;
            //    //grfProc.Cols[col + 1].Caption = dt.Columns[col].ColumnName;
            //    grfProc.Cols[col + 1].Name = dt.Columns[col].ColumnName;
            //}
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                Row row1 = grfProc.Rows.Add();
                row1[colPcId] = row[ic.ivfDB.lspermDB.lsperm.sperm_id].ToString();
                //row1[colRqReqNum] = "";
                row1[colPcHnMale] = row[ic.ivfDB.lspermDB.lsperm.hn_male].ToString();
                //row1[colRqVn] = "";
                row1[colPcNameMale] = row[ic.ivfDB.lspermDB.lsperm.name_male].ToString();
                //row1[colRqDate] = "";
                row1[colPcRemark] = row[ic.ivfDB.lspermDB.lsperm.remark].ToString();
                if (row[ic.ivfDB.lspermDB.lsperm.status_lab_sperm].ToString().Equals("1"))
                {
                    row1[colPcDate] = ic.datetoShow(row[ic.ivfDB.lspermDB.lsperm.sperm_analysis_date_start].ToString());
                    row1[colPcTime] = ic.timetoShow(row[ic.ivfDB.lspermDB.lsperm.sperm_analysis_date_start].ToString());
                }
                else if (row[ic.ivfDB.lspermDB.lsperm.status_lab_sperm].ToString().Equals("2"))
                {
                    row1[colPcDate] = ic.datetoShow(row[ic.ivfDB.lspermDB.lsperm.spern_freezing_date_start].ToString());
                    row1[colPcTime] = ic.timetoShow(row[ic.ivfDB.lspermDB.lsperm.spern_freezing_date_start].ToString());
                }
                else if (row[ic.ivfDB.lspermDB.lsperm.status_lab_sperm].ToString().Equals("3"))
                {
                    row1[colPcDate] = ic.datetoShow(row[ic.ivfDB.lspermDB.lsperm.pasa_tese_date].ToString());
                    //row1[colOPUTime] = ic.timetoShow(row[ic.ivfDB.lspermDB.lsperm.sperm_analysis_date_start].ToString());
                }
                else if (row[ic.ivfDB.lspermDB.lsperm.status_lab_sperm].ToString().Equals("4"))
                {
                    row1[colPcDate] = ic.datetoShow(row[ic.ivfDB.lspermDB.lsperm.iui_date].ToString());
                    //row1[colOPUTime] = ic.timetoShow(row[ic.ivfDB.lspermDB.lsperm.sperm_analysis_date_start].ToString());
                }
                row1[colPcStatusSperm] = row[ic.ivfDB.lspermDB.lsperm.status_lab_sperm].ToString();
                row1[colPcSpermName] = row[ic.ivfDB.lspermDB.lsperm.status_lab_sperm].ToString().Equals("2") ? "Sperm Freezing" 
                    : row[ic.ivfDB.lspermDB.lsperm.status_lab_sperm].ToString().Equals("1") ? "Sperm Analysis"
                    : row[ic.ivfDB.lspermDB.lsperm.status_lab_sperm].ToString().Equals("3") ? " PESA" 
                    : row[ic.ivfDB.lspermDB.lsperm.status_lab_sperm].ToString().Equals("4") ? " IUI " : "";
                //row1[colRqHnMale] = row[ic.ivfDB.lspermDB.lsperm.hn_male].ToString();
                //row1[colRqNameMale] = row[ic.ivfDB.lspermDB.lsperm.name_male].ToString();
                row1[colPcDtfName] = row["dtr_name"].ToString();
                //row1[colOpuId] = "";
                //row1[colDtrName] = row["dtr_name"].ToString();
                row1[0] = i;
                i++;
            }
            grfProc.Cols[colPcId].Visible = false;
            //grfProc.Cols[colRqStatusSperm].Visible = false;
            //grfProc.Cols[colOpuId].Visible = false;
            //grfProc.Cols[colRqVn].Visible = false;
            //grfProc.Cols[colPcOpuNum].AllowEditing = false;
            //grfProc.Cols[colPcHn].AllowEditing = false;
            //grfProc.Cols[colPcPttName].AllowEditing = false;
            grfProc.Cols[colPcDate].AllowEditing = false;
            grfProc.Cols[colPcRemark].AllowEditing = false;
            grfProc.Cols[colPcHnMale].AllowEditing = false;
            grfProc.Cols[colPcNameMale].AllowEditing = false;
            grfProc.Cols[colPcSpermName].AllowEditing = false;
            grfProc.Cols[colPcTime].AllowEditing = false;
            //grfReq.Cols[coldt].Visible = false;
            //if (grfProc.Rows.Count > 2)
            //{
            //    FilterRow fr = new FilterRow(grfProc);
            //    grfProc.AllowFiltering = true;
            //    grfProc.AfterFilter += GrfProc_AfterFilter;
            //}
        }

        private void GrfProc_AfterFilter(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            for (int col = grfProc.Cols.Fixed; col < grfProc.Cols.Count; ++col)
            {
                var filter = grfProc.Cols[col].ActiveFilter;
            }
        }

        private void GrfProc_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();

        }
        private void ContextMenu_proc_edit(object sender, System.EventArgs e)
        {
            String chk = "", name = "", id = "";
            id = grfProc[grfProc.Row, colPcId] != null ? grfProc[grfProc.Row, colPcId].ToString() : "";
            chk = grfProc[grfProc.Row, colPcStatusSperm] != null ? grfProc[grfProc.Row, colPcStatusSperm].ToString() : "";
            name = grfProc[grfProc.Row, colPcNameMale] != null ? grfProc[grfProc.Row, colPcNameMale].ToString() : "";
            //if (MessageBox.Show("ต้องการ ป้อน LAB OPU  \n  opu number " + chk + " \n name " + name, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            //grfReq.Rows.Remove(grfReq.Row);
            Cursor curOld;
            curOld = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            openLabOPUAdd(id, name, chk.Equals("2") ? " Analysis " : chk.Equals("1") ? " Freezing " : chk.Equals("3") ? " PESA " : " IUI ", chk);
            this.Cursor = curOld;
            //}
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
            menuGw.MenuItems.Add("ป้อน LAB OPU/FET", new EventHandler(ContextMenu_proc_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfFinish.ContextMenu = menuGw;
            gbFinish.Controls.Add(grfFinish);

            theme1.SetTheme(grfFinish, "Office2010Blue");
        }

        private void GrfFinish_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfFinish.Row <= 0) return;
            if (grfFinish.Col <= 0) return;
            String chk = "", name = "", id = "";
            id = grfFinish[grfFinish.Row, colPcId] != null ? grfFinish[grfFinish.Row, colPcId].ToString() : "";
            chk = grfFinish[grfFinish.Row, colPcStatusSperm] != null ? grfFinish[grfFinish.Row, colPcStatusSperm].ToString() : "";
            name = grfFinish[grfFinish.Row, colPcNameMale] != null ? grfFinish[grfFinish.Row, colPcNameMale].ToString() : "";
            //if (MessageBox.Show("ต้องการ ป้อน LAB OPU  \n  opu number " + chk + " \n name " + name, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            //grfReq.Rows.Remove(grfReq.Row);
            Cursor curOld;
            curOld = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            openLabOPUAdd(id, name, chk.Equals("2") ? " Analysis " : chk.Equals("1") ? " Freezing " : chk.Equals("3") ? " PESA " : " IUI ", chk);
            this.Cursor = curOld;
        }

        private void GrfFinish_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();

        }
        private void setGrfFinish()
        {
            grfFinish.DataSource = null;
            //grfFinish.Clear();
            //grfFinish.Rows.Count = 0;
            DataTable dt = new DataTable();
            String datestart = "", dateend = "";
            datestart = ic.datetoDB(txtFiDateStart.Text);
            dateend = ic.datetoDB(txtFiDateEnd.Text);
            dt = ic.ivfDB.lspermDB.selectByStatusFinish(datestart, dateend);
            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            //if (dt.Rows.Count <= 1)
            //{
            grfFinish.Rows.Count = 1;
            //}
            //else
            //{
            //    grfFinish.Rows.Count = dt.Rows.Count + 1;
            //}
            grfFinish.Cols.Count = 10;
            //C1TextBox txt = new C1TextBox();
            ////C1ComboBox cboproce = new C1ComboBox();
            ////ic.ivfDB.itmDB.setCboItem(cboproce);
            //grfProc.Cols[colPcOpuNum].Editor = txt;
            //grfProc.Cols[colPcHn].Editor = txt;
            //grfProc.Cols[colPcPttName].Editor = txt;
            //grfProc.Cols[colPcDate].Editor = txt;
            //grfProc.Cols[colPcRemark].Editor = txt;

            //grfFinish.Cols[colPcOpuNum].Width = 120;
            //grfFinish.Cols[colPcHn].Width = 120;
            //grfFinish.Cols[colPcPttName].Width = 280;
            grfFinish.Cols[colPcDate].Width = 120;
            grfFinish.Cols[colPcHnMale].Width = 120;
            grfFinish.Cols[colPcNameMale].Width = 200;
            grfFinish.Cols[colPcSpermName].Width = 200;
            grfFinish.Cols[colPcRemark].Width = 200;

            grfFinish.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfFinish.Cols[colPcDate].Caption = "Date";
            grfFinish.Cols[colPcHnMale].Caption = "HN";
            grfFinish.Cols[colPcNameMale].Caption = "Patient Name";
            grfFinish.Cols[colPcSpermName].Caption = "LAB";
            grfFinish.Cols[colPcRemark].Caption = "Remark";
            grfFinish.Cols[colPcTime].Caption = "Time";

            //grfFinish.Cols[colPcHnMale].Caption = "HN Male";
            //grfFinish.Cols[colPcNameMale].Caption = "Patient Male";
            //grfFinish.Cols[colPcSpermName].Caption = "Procedure";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            //for (int col = 0; col < dt.Columns.Count; ++col)
            //{
            //    grfFinish.Cols[col + 1].DataType = dt.Columns[col].DataType;
            //    //grfProc.Cols[col + 1].Caption = dt.Columns[col].ColumnName;
            //    grfFinish.Cols[col + 1].Name = dt.Columns[col].ColumnName;
            //}
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                Row row1 = grfFinish.Rows.Add();
                row1[colPcId] = row[ic.ivfDB.lspermDB.lsperm.sperm_id].ToString();
                //row1[colRqReqNum] = "";
                row1[colPcHnMale] = row[ic.ivfDB.lspermDB.lsperm.hn_male].ToString();
                //row1[colRqVn] = "";
                row1[colPcNameMale] = row[ic.ivfDB.lspermDB.lsperm.name_male].ToString();
                //row1[colRqDate] = "";
                row1[colPcRemark] = row[ic.ivfDB.lspermDB.lsperm.remark].ToString();
                if (row[ic.ivfDB.lspermDB.lsperm.status_lab_sperm].ToString().Equals("1"))
                {
                    row1[colPcDate] = ic.datetoShow(row[ic.ivfDB.lspermDB.lsperm.sperm_analysis_date_start].ToString());
                    row1[colPcTime] = ic.timetoShow(row[ic.ivfDB.lspermDB.lsperm.sperm_analysis_date_start].ToString());
                }
                else if (row[ic.ivfDB.lspermDB.lsperm.status_lab_sperm].ToString().Equals("2"))
                {
                    row1[colPcDate] = ic.datetoShow(row[ic.ivfDB.lspermDB.lsperm.spern_freezing_date_start].ToString());
                    row1[colPcTime] = ic.timetoShow(row[ic.ivfDB.lspermDB.lsperm.spern_freezing_date_start].ToString());
                }
                else if (row[ic.ivfDB.lspermDB.lsperm.status_lab_sperm].ToString().Equals("3"))
                {
                    row1[colPcDate] = ic.datetoShow(row[ic.ivfDB.lspermDB.lsperm.pasa_tese_date].ToString());
                    //row1[colOPUTime] = ic.timetoShow(row[ic.ivfDB.lspermDB.lsperm.sperm_analysis_date_start].ToString());
                }
                else if (row[ic.ivfDB.lspermDB.lsperm.status_lab_sperm].ToString().Equals("4"))
                {
                    row1[colPcDate] = ic.datetoShow(row[ic.ivfDB.lspermDB.lsperm.iui_date].ToString());
                    //row1[colOPUTime] = ic.timetoShow(row[ic.ivfDB.lspermDB.lsperm.sperm_analysis_date_start].ToString());
                }
                row1[colPcStatusSperm] = row[ic.ivfDB.lspermDB.lsperm.status_lab_sperm].ToString();
                row1[colPcSpermName] = row[ic.ivfDB.lspermDB.lsperm.status_lab_sperm].ToString().Equals("2") ? "Sperm Freezing"
                    : row[ic.ivfDB.lspermDB.lsperm.status_lab_sperm].ToString().Equals("1") ? "Sperm Analysis"
                    : row[ic.ivfDB.lspermDB.lsperm.status_lab_sperm].ToString().Equals("3") ? " PESA"
                    : row[ic.ivfDB.lspermDB.lsperm.status_lab_sperm].ToString().Equals("4") ? " IUI " : "";
                //row1[colRqHnMale] = row[ic.ivfDB.lspermDB.lsperm.hn_male].ToString();
                //row1[colRqNameMale] = row[ic.ivfDB.lspermDB.lsperm.name_male].ToString();
                row1[colPcDtfName] = row["dtr_name"].ToString();
                //row1[colOpuId] = "";
                //row1[colDtrName] = row["dtr_name"].ToString();
                row1[0] = i;
                i++;

            }
            grfFinish.Cols[colPcId].Visible = false;
            //grfFinish.Cols[colPcOpuNum].AllowEditing = false;
            //grfFinish.Cols[colPcHn].AllowEditing = false;
            //grfFinish.Cols[colPcPttName].AllowEditing = false;
            grfFinish.Cols[colPcDate].AllowEditing = false;
            grfFinish.Cols[colPcRemark].AllowEditing = false;
            grfFinish.Cols[colPcHnMale].AllowEditing = false;
            grfFinish.Cols[colPcNameMale].AllowEditing = false;
            grfFinish.Cols[colPcSpermName].AllowEditing = false;
            grfFinish.Cols[colPcTime].AllowEditing = false;
            //grfReq.Cols[coldt].Visible = false;
            //if (grfFinish.Rows.Count > 2)
            //{
            //    FilterRow fr = new FilterRow(grfFinish);
            //    grfFinish.AllowFiltering = true;
            //    grfFinish.AfterFilter += GrfFinish_AfterFilter;
            //}
        }

        private void GrfFinish_AfterFilter(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            openLabSpermNew("", "","");
        }
        private void setOPU1(String reqid)
        {
            LabRequest lbreq = new LabRequest();
            lbreq = ic.ivfDB.lbReqDB.selectByPk1(reqid);
            opu.opu_id = "";
            opu.opu_code = ic.ivfDB.copDB.genOPUDoc();
            opu.embryo_freez_stage = "";
            opu.embryoid_freez_position = "";
            opu.hn_male = "";
            opu.hn_female = lbreq.hn_female;
            opu.name_male = "";
            opu.name_female = lbreq.name_female;
            opu.remark = lbreq.remark;
            opu.dob_female = "";
            opu.dob_male = "";
            opu.doctor_id = lbreq.doctor_id;
            opu.proce_id = "";
            opu.opu_date = DateTime.Now.Year.ToString() + "-" + System.DateTime.Now.ToString("MM-dd");
            opu.req_id = reqid;
        }
        private void openLabOPUAdd(String opdId, String name, String labname, String statusSperm)
        {
            //FrmLabOPUAdd frm = new FrmLabOPUAdd(ic, "", opdId);
            FrmLabSpermAdd frm = new FrmLabSpermAdd(ic, "", opdId, statusSperm, "edit");
            String txt = "";
            if (!name.Equals(""))
            {
                txt = "ป้อน LAB Sperm " + labname+" " + name;
            }
            else
            {
                txt = "ป้อน LAB Sperm ใหม่ ";
            }
            frm.FormBorderStyle = FormBorderStyle.None;
            menu.AddNewTab(frm, txt);
        }
        private void openLabSpermNew(String reqId, String name, String labname)
        {
            ic.cStf.staff_id = "";
            FrmPasswordConfirm frm1 = new FrmPasswordConfirm(ic);
            frm1.ShowDialog(this);
            if (!ic.cStf.staff_id.Equals(""))
            {
                //FrmLabSpermAdd frm = new FrmLabSpermAdd(ic,"","");
                //String txt = "";
                //txt = "ป้อน LAB Sperm " + name;
                //frm.FormBorderStyle = FormBorderStyle.None;
                //menu.AddNewTab(frm, txt);
                LabRequest req = new LabRequest();
                req = ic.ivfDB.lbReqDB.selectByPk1(reqId);
                if(req.status_req.Equals("2") || req.status_req.Equals("4"))
                {
                    // มีคนอื่น double click รับ request ไปแล้ว  ที่ ดัก status เพราะ กัน รับ request แล้ว เกิด record ซ้อนกัน 2 record
                }
                else
                {
                    String re = ic.ivfDB.lbReqDB.UpdateStatusRequestProcess(reqId, ic.cStf.staff_id);
                    long chk1 = 0;
                    if (long.TryParse(re, out chk1))
                    {
                        if (grfReq.Row <= 0)
                        {
                            MessageBox.Show("ไม่พบ request id", "");
                            return;
                        }
                        LabSperm fet1 = ic.ivfDB.setSperm(reqId, grfReq[grfReq.Row, colRqStatusSperm].ToString());
                        String re1 = ic.ivfDB.lspermDB.insert(fet1, ic.cStf.staff_id);
                        if (long.TryParse(re1, out chk1))
                        {
                            //FrmLabOPUAdd frm = new FrmLabOPUAdd(ic, "", re1);
                            FrmLabSpermAdd frm = new FrmLabSpermAdd(ic, "", re1, "edit");
                            String txt = "";
                            if (!name.Equals(""))
                            {
                                txt = "ป้อน LAB Sperm " + name;
                            }
                            else
                            {
                                txt = "ป้อน LAB Sperm ใหม่ ";
                            }

                            frm.FormBorderStyle = FormBorderStyle.None;
                            menu.AddNewTab(frm, txt);
                        }
                    }
                }
            }
        }
        private void FrmLabSpermView_Load(object sender, EventArgs e)
        {
            tcLabView.SelectedTab = tabLabAccept;
            //if (ic.iniC.statusCheckDonor.Equals("0"))
            //{
            //    c1SplitButton1.Hide();
            //}
        }
    }
}
