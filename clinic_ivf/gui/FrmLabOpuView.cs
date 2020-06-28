using C1.Win.C1FlexGrid;
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
    public partial class FrmLabOpuView : Form
    {
        IvfControl ic;
        MainMenu menu;

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;
        int colRqId = 1, colOPUDate = 2, colOPUTime = 3, colRqHnMale = 4, colRqNameMale = 5, colRqHn = 6, colRqName = 7, colRqHnDonor = 8, colRqNameDonor = 9, colDtrName = 10, colRqRemark = 11, colRqReqNum = 12, colRqDate = 13, colRqVn = 14, colRqLabName=15, colOpuId=16, colOPUTimeModi=17, colFormAId=18;
        //int colPcId = 1, colPcOpuNum = 2, colPcHn = 3, colPcPttName = 4, colPcDate = 5, colPcRemark = 6;
        int colPcId = 1, colPcDate = 2, colPcHnMale = 3, colPcNameMale = 4, colPcHn = 5, colPcPttName = 6, colProceName = 7, colPcRemark = 8, colPcOpuNum = 9;
        int colFiId = 1, colFiDate = 2, colFiHnMale = 3, colFiNameMale = 4, colFiHn = 5, colFiPttName = 6, colFiProceName = 7, colFiRemark = 8, colFiOpuNum = 9;

        C1FlexGrid grfReq, grfProc, grfSearch, grfFinish;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        LabOpu opu;
        Timer timer;

        public FrmLabOpuView(IvfControl ic, MainMenu m)
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
            //btnSearchA.Click += BtnSearchA_Click;
            txtSearch.KeyUp += TxtSearch_KeyUp;
            btnSearchF.Click += BtnSearchF_Click;
            //btnOPU.Click += BtnOPU_Click;
            //btnFet.Click += BtnFet_Click;

            initGrfReq();
            initGrfProc();
            initGrfFinish();
            setGrfReq();
            setGrfProc("");
            setGrfFinish();
            initGrfSearch();
        }

        private void BtnSearchF_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setGrfFinish();
        }

        private void BtnFet_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String txt = "";
            txt = "ป้อน LAB FET ใหม่ ";
            FrmLabFetAdd3 frm = new FrmLabFetAdd3(ic, "", "");
            frm.FormBorderStyle = FormBorderStyle.None;
            menu.AddNewTab(frm, txt);
        }

        private void BtnOPU_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmLabOPUAdd2 frm = new FrmLabOPUAdd2(ic, "", "");
            String txt = "";
            txt = "ป้อน LAB OPU ใหม่ ";

            frm.FormBorderStyle = FormBorderStyle.None;
            menu.AddNewTab(frm, txt);
        }

        private void TxtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.Enter)
            {
                setGrfSearch(txtSearch.Text);
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
            setGrfProc("");
        }
        private void initGrfSearch()
        {
            grfSearch = new C1FlexGrid();
            grfSearch.Font = fEdit;
            grfSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            grfSearch.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            grfSearch.AfterRowColChange += GrfSearch_AfterRowColChange;
            grfSearch.DoubleClick += GrfSearch_DoubleClick;
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("ป้อน LAB OPU/FET", new EventHandler(ContextMenu_proc_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfSearch.ContextMenu = menuGw;
            pnSearch.Controls.Add(grfSearch);

            theme1.SetTheme(grfSearch, "Office2010Blue");
        }

        private void GrfSearch_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String chk = "", name = "", id = "";
            id = grfSearch[grfSearch.Row, colPcId] != null ? grfSearch[grfSearch.Row, colPcId].ToString() : "";
            chk = grfSearch[grfSearch.Row, colPcOpuNum] != null ? grfSearch[grfSearch.Row, colPcOpuNum].ToString() : "";
            name = grfSearch[grfSearch.Row, colPcPttName] != null ? grfSearch[grfSearch.Row, colPcPttName].ToString() : "";
            openLabOPUAdd(id, name);
        }

        private void GrfSearch_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();

        }

        private void setGrfSearch(String search)
        {
            grfSearch.DataSource = null;
            grfSearch.Rows.Count = 0;
            DataTable dt = new DataTable();

            dt = ic.ivfDB.opuDB.selectBySearchHn(search);

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            if (dt.Rows.Count <= 1)
            {
                grfSearch.Rows.Count = dt.Rows.Count + 2;
            }
            else
            {
                grfSearch.Rows.Count = dt.Rows.Count + 1;
            }
            grfSearch.Cols.Count = 10;
            //C1TextBox txt = new C1TextBox();
            ////C1ComboBox cboproce = new C1ComboBox();
            ////ic.ivfDB.itmDB.setCboItem(cboproce);
            //grfSearch.Cols[colPcOpuNum].Editor = txt;
            //grfSearch.Cols[colPcHn].Editor = txt;
            //grfSearch.Cols[colPcPttName].Editor = txt;
            //grfSearch.Cols[colPcDate].Editor = txt;
            //grfSearch.Cols[colPcRemark].Editor = txt;

            grfSearch.Cols[colPcOpuNum].Width = 120;
            grfSearch.Cols[colPcHn].Width = 120;
            grfSearch.Cols[colPcPttName].Width = 280;
            grfSearch.Cols[colPcDate].Width = 100;
            grfSearch.Cols[colPcRemark].Width = 200;
            grfSearch.Cols[colPcHnMale].Width = 120;
            grfSearch.Cols[colPcNameMale].Width = 280;
            grfSearch.Cols[colProceName].Width = 200;

            grfSearch.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfSearch.Cols[colPcOpuNum].Caption = "OPU number";
            grfSearch.Cols[colPcHn].Caption = "HN female";
            grfSearch.Cols[colPcPttName].Caption = "Patient Name";
            grfSearch.Cols[colPcDate].Caption = "OPU Date";
            grfSearch.Cols[colPcRemark].Caption = "Remark";

            grfSearch.Cols[colPcHnMale].Caption = "HN Male";
            grfSearch.Cols[colPcNameMale].Caption = "Patient Male";
            grfSearch.Cols[colProceName].Caption = "Procedure";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            //for (int col = 0; col < dt.Columns.Count; ++col)
            //{
            //    grfSearch.Cols[col + 1].DataType = dt.Columns[col].DataType;
            //    //grfSearch.Cols[col + 1].Caption = dt.Columns[col].ColumnName;
            //    grfSearch.Cols[col + 1].Name = dt.Columns[col].ColumnName;
            //}
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                i++;
                //if (i == 1) continue;
                //Row row1 = grfSearch.Rows.Add();
                grfSearch[i, colPcId] = row[ic.ivfDB.opuDB.opu.opu_id].ToString();
                grfSearch[i, colPcOpuNum] = row[ic.ivfDB.opuDB.opu.opu_code].ToString();
                grfSearch[i, colPcHn] = row[ic.ivfDB.opuDB.opu.hn_female].ToString();
                grfSearch[i, colPcPttName] = row[ic.ivfDB.opuDB.opu.name_female].ToString();
                grfSearch[i, colPcDate] = ic.datetoShow(row[ic.ivfDB.opuDB.opu.opu_date].ToString());
                grfSearch[i, colPcRemark] = row[ic.ivfDB.opuDB.opu.remark].ToString();
                grfSearch[i, colPcHnMale] = row[ic.ivfDB.opuDB.opu.hn_male].ToString();
                grfSearch[i, colPcNameMale] = row[ic.ivfDB.opuDB.opu.name_male].ToString();
                grfSearch[i, colProceName] = row["proce_name_t"].ToString();
                //row1[colRqRemark] = row[ic.ivfDB.lbReqDB.lbReq.remark].ToString();
                //row1[colOpuId] = "";
                //row1[colDtrName] = row["dtr_name"].ToString();
                grfSearch[i, 0] = (i - 1);

            }
            grfSearch.Cols[colRqId].Visible = false;
            grfSearch.Cols[colPcOpuNum].AllowEditing = false;
            grfSearch.Cols[colPcHn].AllowEditing = false;
            grfSearch.Cols[colPcPttName].AllowEditing = false;
            grfSearch.Cols[colPcDate].AllowEditing = false;
            grfSearch.Cols[colPcRemark].AllowEditing = false;
            grfSearch.Cols[colPcHnMale].AllowEditing = false;
            grfSearch.Cols[colPcNameMale].AllowEditing = false;
            grfSearch.Cols[colProceName].AllowEditing = false;
            //grfReq.Cols[coldt].Visible = false;
            //if (grfSearch.Rows.Count > 2)
            //{
            //    FilterRow fr = new FilterRow(grfSearch);
            //    grfSearch.AllowFiltering = true;
            //    grfSearch.AfterFilter += GrfProc_AfterFilter;
            //}
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
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("ป้อน LAB OPU/FET", new EventHandler(ContextMenu_edit));
            menuGw.MenuItems.Add("รับทราบการเปลี่ยนแปลงเวลา", new EventHandler(ContextMenu_Gw_time_modi));
            menuGw.MenuItems.Add("Lab Form A", new EventHandler(ContextMenu_grfreq_lab_form_a));
            menuGw.MenuItems.Add("Lab Form Day1", new EventHandler(ContextMenu_grfreq_lab_form_day1));
            grfReq.ContextMenu = menuGw;
            pnReq.Controls.Add(grfReq);

            theme1.SetTheme(grfReq, "Office2010Blue");
        }
        private void ContextMenu_grfreq_lab_form_day1(object sender, System.EventArgs e)
        {
            String chk = "", name = "", id = "", formaid = "", vn="", hn="";
            id = grfReq[grfReq.Row, colRqId] != null ? grfReq[grfReq.Row, colRqId].ToString() : "";
            formaid = grfReq[grfReq.Row, colFormAId] != null ? grfReq[grfReq.Row, colFormAId].ToString() : "";
            vn = grfReq[grfReq.Row, colRqVn] != null ? grfReq[grfReq.Row, colRqVn].ToString() : "";
            hn = grfReq[grfReq.Row, colRqHn] != null ? grfReq[grfReq.Row, colRqHn].ToString() : "";
            Visit vs = new Visit();
            vs = ic.ivfDB.vsDB.selectByVn(vn);
            FrmLabFormDay1 frm = new FrmLabFormDay1(ic, formaid, hn, vn, vs.t_visit_id, "view");

            frm.ShowDialog(this);
        }
        private void ContextMenu_grfreq_lab_form_a(object sender, System.EventArgs e)
        {
            String chk = "", name = "", id = "", formaid = "";
            id = grfReq[grfReq.Row, colRqId] != null ? grfReq[grfReq.Row, colRqId].ToString() : "";
            formaid = grfReq[grfReq.Row, colFormAId] != null ? grfReq[grfReq.Row, colFormAId].ToString() : "";
            
            FrmLabFormA frm = new FrmLabFormA(ic, formaid, "", "", "", "view");

            frm.ShowDialog(this);
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
            String chk = "", name="", id="", formaid="";
            
            id = grfReq[grfReq.Row, colRqId] != null ? grfReq[grfReq.Row, colRqId].ToString() : "";
            formaid = grfReq[grfReq.Row, colFormAId] != null ? grfReq[grfReq.Row, colFormAId].ToString() : "";
            chk = grfReq[grfReq.Row, colRqReqNum] != null ? grfReq[grfReq.Row, colRqReqNum].ToString() : "";
            name = grfReq[grfReq.Row, colRqName] != null ? grfReq[grfReq.Row, colRqName].ToString() : "";
            //if (MessageBox.Show("ต้องการ ป้อน LAB OPU  \n  req number " + chk+" \n name "+ name, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
                //grfReq.Rows.Remove(grfReq.Row);
                Cursor curOld;
                curOld = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                openLabOPUNew(id, name, formaid);
                setGrfReq();
                setGrfProc("");
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
            grfReq.DataSource = null;
            //grfReq.Clear();
            DataTable dt = new DataTable();
            DateTime datestart, dateend;
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
            dt = ic.ivfDB.lbReqDB.selectByStatusOPURequest();
            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfReq.Rows.Count = 1;
            grfReq.Cols.Count = 19;
            //C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            //grfReq.Cols[colRqReqNum].Editor = txt;
            //grfReq.Cols[colRqHn].Editor = txt;
            //grfReq.Cols[colRqVn].Editor = txt;
            //grfReq.Cols[colRqName].Editor = txt;

            grfReq.Cols[colRqHn].Width = 100;
            grfReq.Cols[colRqVn].Width = 120;
            grfReq.Cols[colRqName].Width = 280;
            grfReq.Cols[colRqDate].Width = 100;
            grfReq.Cols[colDtrName].Width = 200;
            grfReq.Cols[colRqRemark].Width = 200;
            grfReq.Cols[colRqLabName].Width = 80;
            grfReq.Cols[colOPUDate].Width = 100;
            grfReq.Cols[colOPUTime].Width = 70;
            grfReq.Cols[colOPUTimeModi].Width = 70;
            grfReq.Cols[colRqHnMale].Width = 100;
            grfReq.Cols[colRqNameMale].Width = 280;
            grfReq.Cols[colRqHnDonor].Width = 100;
            grfReq.Cols[colRqNameDonor].Width = 280;
            grfReq.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfReq.Cols[colRqReqNum].Caption = "req number";
            grfReq.Cols[colRqHn].Caption = "HN";
            grfReq.Cols[colRqVn].Caption = "VN";
            grfReq.Cols[colRqName].Caption = "Name";
            grfReq.Cols[colRqDate].Caption = "Date Req";
            grfReq.Cols[colRqRemark].Caption = "Remark";
            grfReq.Cols[colDtrName].Caption = "Doctor";
            grfReq.Cols[colRqLabName].Caption = "Lab Name";
            grfReq.Cols[colOPUDate].Caption = "OPU Date";
            grfReq.Cols[colOPUTime].Caption = "OPU Time";
            grfReq.Cols[colOPUTimeModi].Caption = "opu time old";
            grfReq.Cols[colRqHnMale].Caption = "HN male";
            grfReq.Cols[colRqNameMale].Caption = "Name male";
            grfReq.Cols[colRqHnDonor].Caption = "HN donor";
            grfReq.Cols[colRqNameDonor].Caption = "Name donor";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            String chk = "";
            foreach (DataRow row in dt.Rows)
            {
                Row row1 = grfReq.Rows.Add();
                row1[colFormAId] = row[ic.ivfDB.lFormaDB.lformA.form_a_id].ToString();
                row1[colRqId] = row[ic.ivfDB.lFormaDB.lformA.req_id_opu].ToString();
                row1[colRqReqNum] = row[ic.ivfDB.lFormaDB.lformA.form_a_code].ToString();
                row1[colRqHn] = row[ic.ivfDB.lbReqDB.lbReq.hn_female].ToString();
                row1[colRqVn] = row[ic.ivfDB.lFormaDB.lformA.vn_old].ToString();
                row1[colRqName] = row[ic.ivfDB.lbReqDB.lbReq.name_female].ToString();
                row1[colRqDate] = ic.datetoShow(row[ic.ivfDB.lFormaDB.lformA.form_a_date].ToString());
                row1[colRqRemark] = row["form_a_remark"].ToString();
                row1[colOPUDate] = ic.datetoShow(row[ic.ivfDB.lFormaDB.lformA.opu_date].ToString());
                row1[colOPUTime] = row[ic.ivfDB.lFormaDB.lformA.opu_time].ToString();
                row1[colOPUTimeModi] = row[ic.ivfDB.lFormaDB.lformA.opu_time_modi].ToString();
                row1[colRqLabName] = row["SName"].ToString();
                row1[colRqHnMale] = row["hn_male"].ToString();
                row1[colRqNameMale] = row["name_male"].ToString();
                row1[colRqHnDonor] = row["hn_donor"].ToString();
                row1[colRqNameDonor] = row["name_donor"].ToString();
                if (row["SName"].ToString().Trim().Equals("OPU"))
                {
                    row1[colRqRemark] = row["opu_remark"].ToString()+" "+row["form_a_remark"].ToString();
                }
                else if (row["SName"].ToString().Equals("FET"))
                {
                    row1[colRqRemark] = row["fet_remark"].ToString() + " " + row["form_a_remark"].ToString();
                }
                row1[colOpuId] = "";
                row1[colDtrName] = row["dtr_name"].ToString();
                row1[0] = i;
                if (row[ic.ivfDB.lbReqDB.lbReq.hn_female].ToString().Equals("HN-90106/62"))
                {
                    chk = "";
                }
                String txt1 = "";
                if (row["status_opu_active"].ToString().Equals("1"))
                {
                    if (row["status_wait_confirm_opu_date"].ToString().Equals("2"))
                    {
                        //grfReq.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
                        txt1 = "confirm วัน เวลา OPU จากทาง พยาบาล " + row["form_a_remark"].ToString();
                        if (row[ic.ivfDB.lFormaDB.lformA.status_opu_time_modi].ToString().Equals("1"))
                        {
                            txt1 = txt1 + " มีการเปลี่ยนแปลง เวลา OPU จาก " + row[ic.ivfDB.lFormaDB.lformA.opu_time_modi].ToString() + " -> " + row[ic.ivfDB.lFormaDB.lformA.opu_time].ToString();
                        }
                        
                        CellNote note = new CellNote(txt1);
                        CellRange rg = grfReq.GetCellRange(i, colRqHn);
                        rg.UserData = note;
                        grfReq.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(ic.iniC.grfRowGreen);
                    }
                    else if (row["status_wait_confirm_opu_date"].ToString().Equals("1"))
                    {
                        txt1 = "รอ confirm วัน เวลา OPU จากทาง พยาบาล " + row["form_a_remark"].ToString();
                        if (row[ic.ivfDB.lFormaDB.lformA.status_opu_time_modi].ToString().Equals("1"))
                        {
                            txt1 = txt1 + " มีการเปลี่ยนแปลง เวลา OPU จาก " + row[ic.ivfDB.lFormaDB.lformA.opu_time_modi].ToString() + " -> " + row[ic.ivfDB.lFormaDB.lformA.opu_time].ToString();
                        }
                        CellNote note = new CellNote(txt1);
                        CellRange rg = grfReq.GetCellRange(i, colRqHn);
                        rg.UserData = note;
                        grfReq.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(ic.iniC.grfRowYellow);
                    }
                }
                else if (row["status_opu_active"].ToString().Equals("2"))
                {
                    txt1 = "Wait " + row["opu_wait_remark"].ToString() +" "+ row["form_a_remark"].ToString();
                    if (row[ic.ivfDB.lFormaDB.lformA.status_opu_time_modi].ToString().Equals("1"))
                    {
                        txt1 = txt1 + " มีการเปลี่ยนแปลง เวลา OPU จาก " + row[ic.ivfDB.lFormaDB.lformA.opu_time_modi].ToString() + " -> " + row[ic.ivfDB.lFormaDB.lformA.opu_time].ToString();
                    }
                    CellNote note = new CellNote(txt1);
                    CellRange rg = grfReq.GetCellRange(i, colRqHn);
                    rg.UserData = note;
                    grfReq.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(ic.iniC.grfRowYellow);
                }
                else if (row["status_opu_active"].ToString().Equals("3"))
                {
                    txt1 = "Void " + row["opu_wait_remark"].ToString() + " " + row["form_a_remark"].ToString();
                    if (row[ic.ivfDB.lFormaDB.lformA.status_opu_time_modi].ToString().Equals("1"))
                    {
                        txt1 = txt1 + " มีการเปลี่ยนแปลง เวลา OPU จาก " + row[ic.ivfDB.lFormaDB.lformA.opu_time_modi].ToString() + " -> " + row[ic.ivfDB.lFormaDB.lformA.opu_time].ToString();
                    }
                    CellNote note = new CellNote(txt1);
                    CellRange rg = grfReq.GetCellRange(i, colRqHn);
                    rg.UserData = note;
                    grfReq.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(ic.iniC.grfRowRed);
                }
                i++;
            }
            grfReq.Cols[colRqId].Visible = false;
            grfReq.Cols[colRqVn].Visible = false;
            grfReq.Cols[colFormAId].Visible = false;

            grfReq.Cols[colRqReqNum].AllowEditing = false;
            grfReq.Cols[colRqHn].AllowEditing = false;
            grfReq.Cols[colRqVn].AllowEditing = false;
            grfReq.Cols[colRqName].AllowEditing = false;
            grfReq.Cols[colRqDate].AllowEditing = false;
            grfReq.Cols[colRqRemark].AllowEditing = false;
            grfReq.Cols[colOPUDate].AllowEditing = false;
            grfReq.Cols[colOPUTime].AllowEditing = false;
            grfReq.Cols[colOPUTimeModi].AllowEditing = false;
            grfReq.Cols[colRqLabName].AllowEditing = false;
            grfReq.Cols[colRqHnMale].AllowEditing = false;
            grfReq.Cols[colRqNameMale].AllowEditing = false;
            grfReq.Cols[colRqHnDonor].AllowEditing = false;
            grfReq.Cols[colRqNameDonor].AllowEditing = false;
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
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("ป้อน LAB OPU/FET", new EventHandler(ContextMenu_proc_edit));
            menuGw.MenuItems.Add("Lab Form A", new EventHandler(ContextMenu_grfproc_lab_form_a));
            menuGw.MenuItems.Add("Lab Form Day1", new EventHandler(ContextMenu_grfprec_lab_form_day1));
            grfProc.ContextMenu = menuGw;
            panel2.Controls.Add(grfProc);

            theme1.SetTheme(grfProc, "Office2010Blue");
        }
        private void ContextMenu_grfprec_lab_form_day1(object sender, System.EventArgs e)
        {
            String chk = "", name = "", id = "", formaid = "", vn = "", hn = "";
            id = grfProc[grfProc.Row, colRqId] != null ? grfProc[grfProc.Row, colRqId].ToString() : "";
            //formaid = grfProc[grfProc.Row, colFormAId] != null ? grfProc[grfProc.Row, colFormAId].ToString() : "";
            LabOpu opu = new LabOpu();
            LabRequest req = new LabRequest();
            opu = ic.ivfDB.opuDB.selectByPk1(formaid);
            req = ic.ivfDB.lbReqDB.selectByPk1(opu.req_id);
            FrmLabFormDay1 frm = new FrmLabFormDay1(ic, "", "", vn, "", "view");

            frm.ShowDialog(this);
        }
        private void ContextMenu_grfproc_lab_form_a(object sender, System.EventArgs e)
        {
            String chk = "", name = "", id = "", formaid = "";
            id = grfProc[grfProc.Row, colRqId] != null ? grfProc[grfProc.Row, colRqId].ToString() : "";
            formaid = grfProc[grfProc.Row, colPcId] != null ? grfProc[grfProc.Row, colPcId].ToString() : "";
            //formaid = grfReq[grfReq.Row, colFormAId] != null ? grfReq[grfReq.Row, colFormAId].ToString() : "";
            //formaid = grfReq[grfReq.Row, colFormAId] != null ? grfReq[grfReq.Row, colFormAId].ToString() : "";
            //grfReq.Cols[colRqHn].Caption = "HN";
            //grfReq.Cols[colRqVn].Caption = "VN";
            LabOpu opu = new LabOpu();
            LabRequest req = new LabRequest();
            opu = ic.ivfDB.opuDB.selectByPk1(formaid);
            req = ic.ivfDB.lbReqDB.selectByPk1(opu.req_id);
            FrmLabFormA frm = new FrmLabFormA(ic, req.form_a_id, "", "", "", "view");

            frm.ShowDialog(this);
        }
        private void GrfProc_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ContextMenu_proc_edit(null, null);
        }
        
        private void setGrfProc(String search)
        {
            grfProc.DataSource = null;
            grfProc.Clear();
            DataTable dt = new DataTable();
            
            dt = ic.ivfDB.opuDB.selectByStatusProcess1(search);
            
            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            if (dt.Rows.Count <= 1)
            {
                grfProc.Rows.Count = dt.Rows.Count + 2;
            }
            else
            {
                grfProc.Rows.Count = dt.Rows.Count + 1;
            }
            grfProc.Cols.Count = 10;
            //C1TextBox txt = new C1TextBox();
            ////C1ComboBox cboproce = new C1ComboBox();
            ////ic.ivfDB.itmDB.setCboItem(cboproce);
            //grfProc.Cols[colPcOpuNum].Editor = txt;
            //grfProc.Cols[colPcHn].Editor = txt;
            //grfProc.Cols[colPcPttName].Editor = txt;
            //grfProc.Cols[colPcDate].Editor = txt;
            //grfProc.Cols[colPcRemark].Editor = txt;

            grfProc.Cols[colPcOpuNum].Width = 120;
            grfProc.Cols[colPcHn].Width = 120;
            grfProc.Cols[colPcPttName].Width = 280;
            grfProc.Cols[colPcDate].Width = 100;
            grfProc.Cols[colPcRemark].Width = 200;
            grfProc.Cols[colPcHnMale].Width = 120;
            grfProc.Cols[colPcNameMale].Width = 280;
            grfProc.Cols[colProceName].Width = 200;

            grfProc.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfProc.Cols[colPcOpuNum].Caption = "OPU number";
            grfProc.Cols[colPcHn].Caption = "HN female";
            grfProc.Cols[colPcPttName].Caption = "Patient Name";
            grfProc.Cols[colPcDate].Caption = "OPU Date";
            grfProc.Cols[colPcRemark].Caption = "Remark";

            grfProc.Cols[colPcHnMale].Caption = "HN Male";
            grfProc.Cols[colPcNameMale].Caption = "Patient Male";
            grfProc.Cols[colProceName].Caption = "Procedure";

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
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                i++;
                if (i == 1) continue;
                //Row row1 = grfProc.Rows.Add();
                grfProc[i, colPcId] = row[ic.ivfDB.opuDB.opu.opu_id].ToString();
                grfProc[i, colPcOpuNum] = row[ic.ivfDB.opuDB.opu.opu_code].ToString();
                grfProc[i, colPcHn] = row[ic.ivfDB.opuDB.opu.hn_female].ToString();
                grfProc[i, colPcPttName] = row[ic.ivfDB.opuDB.opu.name_female].ToString();
                grfProc[i, colPcDate] = ic.datetoShow(row[ic.ivfDB.opuDB.opu.opu_date].ToString());
                grfProc[i, colPcRemark] = row[ic.ivfDB.opuDB.opu.remark].ToString();
                grfProc[i, colPcHnMale] = row[ic.ivfDB.opuDB.opu.hn_male].ToString();
                grfProc[i, colPcNameMale] = row[ic.ivfDB.opuDB.opu.name_male].ToString();
                grfProc[i, colProceName] = row["proce_name_t"].ToString();
                //row1[colRqRemark] = row[ic.ivfDB.lbReqDB.lbReq.remark].ToString();
                //row1[colOpuId] = "";
                //row1[colDtrName] = row["dtr_name"].ToString();
                grfProc[i, 0] = (i-1);
                
            }
            grfProc.Cols[colRqId].Visible = false;
            grfProc.Cols[colPcOpuNum].AllowEditing = false;
            grfProc.Cols[colPcHn].AllowEditing = false;
            grfProc.Cols[colPcPttName].AllowEditing = false;
            grfProc.Cols[colPcDate].AllowEditing = false;
            grfProc.Cols[colPcRemark].AllowEditing = false;
            grfProc.Cols[colPcHnMale].AllowEditing = false;
            grfProc.Cols[colPcNameMale].AllowEditing = false;
            grfProc.Cols[colProceName].AllowEditing = false;
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
            //for (int col = grfProc.Cols.Fixed; col < grfProc.Cols.Count; ++col)
            //{
            //    var filter = grfProc.Cols[col].ActiveFilter;
            //}
        }

        private void GrfProc_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();

        }
        private void ContextMenu_proc_edit(object sender, System.EventArgs e)
        {
            String chk = "", name = "", id = "";
            id = grfProc[grfProc.Row, colPcId] != null ? grfProc[grfProc.Row, colPcId].ToString() : "";
            chk = grfProc[grfProc.Row, colPcOpuNum] != null ? grfProc[grfProc.Row, colPcOpuNum].ToString() : "";
            name = grfProc[grfProc.Row, colPcPttName] != null ? grfProc[grfProc.Row, colPcPttName].ToString() : "";
            //if (MessageBox.Show("ต้องการ ป้อน LAB OPU  \n  opu number " + chk + " \n name " + name, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
                //grfReq.Rows.Remove(grfReq.Row);
                Cursor curOld;
                curOld = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                openLabOPUAdd(id, name);
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
            menuGw.MenuItems.Add("Lab Form A", new EventHandler(ContextMenu_grffinish_lab_form_a));
            menuGw.MenuItems.Add("Lab Form Day1", new EventHandler(ContextMenu_grffinish_lab_form_day1));
            grfFinish.ContextMenu = menuGw;
            gbFinish.Controls.Add(grfFinish);

            theme1.SetTheme(grfFinish, "Office2010Blue");
        }
        private void ContextMenu_grffinish_lab_form_day1(object sender, System.EventArgs e)
        {
            String chk = "", name = "", id = "", formaid = "", vn = "", hn = "";
            id = grfFinish[grfFinish.Row, colRqId] != null ? grfFinish[grfFinish.Row, colRqId].ToString() : "";
            //formaid = grfFinish[grfFinish.Row, colFormAId] != null ? grfFinish[grfFinish.Row, colFormAId].ToString() : "";
            vn = grfFinish[grfFinish.Row, colRqVn] != null ? grfFinish[grfFinish.Row, colRqVn].ToString() : "";
            hn = grfFinish[grfFinish.Row, colRqHn] != null ? grfFinish[grfFinish.Row, colRqHn].ToString() : "";
            Visit vs = new Visit();
            vs = ic.ivfDB.vsDB.selectByVn(vn);
            FrmLabFormDay1 frm = new FrmLabFormDay1(ic, formaid, hn, vn, vs.t_visit_id, "view");

            frm.ShowDialog(this);
        }
        private void ContextMenu_grffinish_lab_form_a(object sender, System.EventArgs e)
        {
            String chk = "", name = "", id = "", formaid = "";
            id = grfFinish[grfFinish.Row, colRqId] != null ? grfFinish[grfFinish.Row, colRqId].ToString() : "";
            formaid = grfFinish[grfFinish.Row, colPcId] != null ? grfFinish[grfFinish.Row, colPcId].ToString() : "";
            LabOpu opu = new LabOpu();
            LabRequest req = new LabRequest();
            opu = ic.ivfDB.opuDB.selectByPk1(formaid);
            req = ic.ivfDB.lbReqDB.selectByPk1(opu.req_id);
            FrmLabFormA frm = new FrmLabFormA(ic, req.form_a_id, "", "", "", "view");

            frm.ShowDialog(this);
        }
        private void GrfFinish_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String chk = "", name = "", id = "";
            id = grfFinish[grfFinish.Row, colPcId] != null ? grfFinish[grfFinish.Row, colPcId].ToString() : "";
            chk = grfFinish[grfFinish.Row, colPcOpuNum] != null ? grfFinish[grfFinish.Row, colPcOpuNum].ToString() : "";
            Cursor curOld;
            curOld = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            openLabOPUAdd(id, name);
            this.Cursor = curOld;
        }

        private void GrfFinish_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();

        }
        private void setGrfFinish()
        {
            grfFinish.DataSource = null;
            grfFinish.Clear();
            DataTable dt = new DataTable();
            String datestart = "", dateend = "";
            datestart = ic.datetoDB(txtFiDateStart.Text);
            dateend = ic.datetoDB(txtFiDateEnd.Text);
            dt = ic.ivfDB.opuDB.selectByStatusFinish(datestart, dateend);
            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            if (dt.Rows.Count <= 1)
            {
                grfFinish.Rows.Count = dt.Rows.Count + 1;
            }
            else
            {
                grfFinish.Rows.Count = dt.Rows.Count + 2;
            }
            grfFinish.Cols.Count = 10;
            //C1TextBox txt = new C1TextBox();
            ////C1ComboBox cboproce = new C1ComboBox();
            ////ic.ivfDB.itmDB.setCboItem(cboproce);
            //grfProc.Cols[colPcOpuNum].Editor = txt;
            //grfProc.Cols[colPcHn].Editor = txt;
            //grfProc.Cols[colPcPttName].Editor = txt;
            //grfProc.Cols[colPcDate].Editor = txt;
            //grfProc.Cols[colPcRemark].Editor = txt;

            grfFinish.Cols[colPcOpuNum].Width = 120;
            grfFinish.Cols[colPcHn].Width = 120;
            grfFinish.Cols[colPcPttName].Width = 280;
            grfFinish.Cols[colPcDate].Width = 100;
            grfFinish.Cols[colPcRemark].Width = 200;
            grfFinish.Cols[colPcHnMale].Width = 120;
            grfFinish.Cols[colPcNameMale].Width = 280;
            grfFinish.Cols[colProceName].Width = 200;

            grfFinish.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfFinish.Cols[colPcOpuNum].Caption = "OPU number";
            grfFinish.Cols[colPcHn].Caption = "HN female";
            grfFinish.Cols[colPcPttName].Caption = "Patient Name";
            grfFinish.Cols[colPcDate].Caption = "OPU Date";
            grfFinish.Cols[colPcRemark].Caption = "Remark";

            grfFinish.Cols[colPcHnMale].Caption = "HN Male";
            grfFinish.Cols[colPcNameMale].Caption = "Patient Male";
            grfFinish.Cols[colProceName].Caption = "Procedure";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            for (int col = 0; col < dt.Columns.Count; ++col)
            {
                grfFinish.Cols[col + 1].DataType = dt.Columns[col].DataType;
                //grfProc.Cols[col + 1].Caption = dt.Columns[col].ColumnName;
                grfFinish.Cols[col + 1].Name = dt.Columns[col].ColumnName;
            }
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                //if (i == 1) continue;
                //Row row1 = grfProc.Rows.Add();
                grfFinish[i, colPcId] = row[ic.ivfDB.opuDB.opu.opu_id].ToString();
                grfFinish[i, colPcOpuNum] = row[ic.ivfDB.opuDB.opu.opu_code].ToString();
                grfFinish[i, colPcHn] = row[ic.ivfDB.opuDB.opu.hn_female].ToString();
                grfFinish[i, colPcPttName] = row[ic.ivfDB.opuDB.opu.name_female].ToString();
                grfFinish[i, colPcDate] = ic.datetoShow(row[ic.ivfDB.opuDB.opu.opu_date].ToString());
                grfFinish[i, colPcRemark] = row[ic.ivfDB.opuDB.opu.remark].ToString();
                grfFinish[i, colPcHnMale] = row[ic.ivfDB.opuDB.opu.hn_male].ToString();
                grfFinish[i, colPcNameMale] = row[ic.ivfDB.opuDB.opu.name_male].ToString();
                grfFinish[i, colProceName] = row["proce_name_t"].ToString();
                //row1[colRqRemark] = row[ic.ivfDB.lbReqDB.lbReq.remark].ToString();
                //row1[colOpuId] = "";
                //row1[colDtrName] = row["dtr_name"].ToString();
                grfFinish[i, 0] = (i - 1);
                i++;

            }
            grfFinish.Cols[colRqId].Visible = false;
            grfFinish.Cols[colPcOpuNum].AllowEditing = false;
            grfFinish.Cols[colPcHn].AllowEditing = false;
            grfFinish.Cols[colPcPttName].AllowEditing = false;
            grfFinish.Cols[colPcDate].AllowEditing = false;
            grfFinish.Cols[colPcRemark].AllowEditing = false;
            grfFinish.Cols[colPcHnMale].AllowEditing = false;
            grfFinish.Cols[colPcNameMale].AllowEditing = false;
            grfFinish.Cols[colProceName].AllowEditing = false;
            //grfReq.Cols[coldt].Visible = false;
            if (grfFinish.Rows.Count > 2)
            {
                FilterRow fr = new FilterRow(grfFinish);
                grfFinish.AllowFiltering = true;
                grfFinish.AfterFilter += GrfFinish_AfterFilter;
            }
        }

        private void GrfFinish_AfterFilter(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            openLabOPUNew("","","");
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
        private void openLabOPUAdd(String opdId, String name)
        {
            //FrmLabOPUAdd frm = new FrmLabOPUAdd(ic, "", opdId);
            FrmLabOPUAdd2 frm = new FrmLabOPUAdd2(ic, "", opdId);
            String txt = "";
            if (!name.Equals(""))
            {
                txt = "ป้อน LAB OPU " + name;
            }
            else
            {
                txt = "ป้อน LAB OPU ใหม่ ";
            }
            frm.FormBorderStyle = FormBorderStyle.None;
            menu.AddNewTab(frm, txt);
        }
        private void openLabOPUNew(String reqId, String name, String formaid)
        {
            ic.cStf.staff_id = "";
            FrmPasswordConfirm frm1 = new FrmPasswordConfirm(ic);
            frm1.ShowDialog(this);
            if (!ic.cStf.staff_id.Equals(""))
            {
                String re = ic.ivfDB.lbReqDB.UpdateStatusRequestProcess(reqId, ic.cStf.staff_id);
                long chk1 = 0;
                if (long.TryParse(re, out chk1))
                {
                    if(grfReq.Row <=0)
                    {
                        MessageBox.Show("ไม่พบ request id", "");
                        return;
                    }
                    if(grfReq[grfReq.Row, colRqLabName].ToString().Trim().Equals("OPU"))
                    {
                        LabOpu opu1 = ic.ivfDB.setOPU(reqId, formaid);
                        String re1 = ic.ivfDB.opuDB.insert(opu1, ic.cStf.staff_id);
                        //ic.ivfDB.
                        if (long.TryParse(re1, out chk1))
                        {
                            //FrmLabOPUAdd frm = new FrmLabOPUAdd(ic, "", re1);
                            FrmLabOPUAdd2 frm = new FrmLabOPUAdd2(ic, "", re1);
                            String txt = "";
                            if (!name.Equals(""))
                            {
                                txt = "ป้อน LAB OPU " + name;
                            }
                            else
                            {
                                txt = "ป้อน LAB OPU ใหม่ ";
                            }

                            frm.FormBorderStyle = FormBorderStyle.None;
                            menu.AddNewTab(frm, txt);
                        }
                    }
                    else
                    {
                        LabFet fet1 = ic.ivfDB.setFET(reqId);
                        String re1 = ic.ivfDB.fetDB.insert(fet1, ic.cStf.staff_id);
                        if (long.TryParse(re1, out chk1))
                        {
                            //FrmLabOPUAdd frm = new FrmLabOPUAdd(ic, "", re1);
                            FrmLabFetAdd3 frm = new FrmLabFetAdd3(ic, "", re1);
                            String txt = "";
                            if (!name.Equals(""))
                            {
                                txt = "ป้อน LAB FET " + name;
                            }
                            else
                            {
                                txt = "ป้อน LAB FET ใหม่ ";
                            }

                            frm.FormBorderStyle = FormBorderStyle.None;
                            menu.AddNewTab(frm, txt);
                        }
                    }
                }
            }
        }
        private void FrmLabOpuView_Load(object sender, EventArgs e)
        {
            tcLabView.SelectedTab = tabLabAccept;
            if (ic.iniC.statusCheckDonor.Equals("0"))
            {
                //c1SplitButton1.Hide();
            }
        }
    }
}
