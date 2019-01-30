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
    public partial class FrmLabOpuView : Form
    {
        IvfControl ic;
        MainMenu menu;

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;
        int colRqId = 1, colRqReqNum = 2, colRqHn = 3, colRqVn = 4, colRqName = 5, colRqLabName=6, colRqDate = 7, colRqRemark = 8, colOpuId=9, colDtrName=10, colOPUDate=11, colOPUTime=12, colOPUTimeModi=13;
        int colPcId = 1, colPcOpuNum = 2, colPcHn = 3, colPcPttName = 4, colPcDate = 5, colPcRemark = 6;

        C1FlexGrid grfReq, grfProc;
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
            txtDateEnd.Value = System.DateTime.Now;
            txtDateStart.Value = System.DateTime.Now;
            //C1ThemeController.ApplicationTheme = ic.iniC.themeApplication;
            theme1.Theme = ic.iniC.themeApplication;
            theme1.SetTheme(sB, "BeigeOne");

            sB1.Text = "";
            bg = txtHn.BackColor;
            fc = txtHn.ForeColor;
            ff = txtHn.Font;

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            opu = new LabOpu();

            int timerlab = 0;
            int.TryParse(ic.iniC.timerlabreqaccept, out timerlab);
            timer = new Timer();
            timer.Interval = timerlab * 1000;
            timer.Tick += Timer_Tick;
            timer.Enabled = true;

            btnNew.Click += BtnNew_Click;
            btnSearchA.Click += BtnSearchA_Click;

            initGrfReq();
            initGrfProc();
            setGrfReq();
            setGrfProc();
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
        private void initGrfReq()
        {
            grfReq = new C1FlexGrid();
            grfReq.Font = fEdit;
            grfReq.Dock = System.Windows.Forms.DockStyle.Fill;
            grfReq.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            grfReq.AfterRowColChange += GrfReq_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("ป้อน LAB OPU/FET", new EventHandler(ContextMenu_edit));
            menuGw.MenuItems.Add("รับทราบการเปลี่ยนแปลงเวลา", new EventHandler(ContextMenu_Gw_time_modi));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfReq.ContextMenu = menuGw;
            gB.Controls.Add(grfReq);

            theme1.SetTheme(grfReq, "Office2010Blue");
        }
        private void ContextMenu_Gw_time_modi(object sender, System.EventArgs e)
        {
            String chk = "", name = "", id = "";

            id = grfReq[grfReq.Row, colRqId] != null ? grfReq[grfReq.Row, colRqId].ToString() : "";
            chk = grfReq[grfReq.Row, colRqReqNum] != null ? grfReq[grfReq.Row, colRqReqNum].ToString() : "";
            name = grfReq[grfReq.Row, colRqName] != null ? grfReq[grfReq.Row, colRqName].ToString() : "";
            FrmMabOPUTimeModi frm = new FrmMabOPUTimeModi(ic, id, id);
            frm.ShowDialog(this);
        }
        private void ContextMenu_edit(object sender, System.EventArgs e)
        {
            String chk = "", name="", id="";
            
            id = grfReq[grfReq.Row, colRqId] != null ? grfReq[grfReq.Row, colRqId].ToString() : "";
            chk = grfReq[grfReq.Row, colRqReqNum] != null ? grfReq[grfReq.Row, colRqReqNum].ToString() : "";
            name = grfReq[grfReq.Row, colRqName] != null ? grfReq[grfReq.Row, colRqName].ToString() : "";
            //if (MessageBox.Show("ต้องการ ป้อน LAB OPU  \n  req number " + chk+" \n name "+ name, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
                //grfReq.Rows.Remove(grfReq.Row);
                Cursor curOld;
                curOld = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                openLabOPUNew(id, name);
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
            grfReq.DataSource = null;
            grfReq.Clear();
            DataTable dt = new DataTable();
            DateTime datestart, dateend;
            String datestart1 = "", dateend1 = "";
            if (DateTime.TryParse(txtDateStart.Text, out datestart))
            {
                datestart1 = datestart.ToString("yyyy-MM-dd");
            }
            else
            {
                datestart1 = ic.datetoDB(txtDateStart.Text);
            }
            if (DateTime.TryParse(txtDateEnd.Text, out datestart))
            {
                dateend1 = datestart.ToString("yyyy-MM-dd");
            }
            else
            {
                dateend1 = ic.datetoDB(txtDateEnd.Text);
            }
            //dt = ic.ivfDB.lbReqDB.selectByStatusReqAccept();
            dt = ic.ivfDB.oJsDB.selectByStatusUnAccept2(datestart1, dateend1);
            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfReq.Rows.Count = 1;
            grfReq.Cols.Count = 14;
            C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfReq.Cols[colRqReqNum].Editor = txt;
            grfReq.Cols[colRqHn].Editor = txt;
            grfReq.Cols[colRqVn].Editor = txt;
            grfReq.Cols[colRqName].Editor = txt;

            grfReq.Cols[colRqHn].Width = 120;
            grfReq.Cols[colRqVn].Width = 120;
            grfReq.Cols[colRqName].Width = 280;
            grfReq.Cols[colRqDate].Width = 100;
            grfReq.Cols[colDtrName].Width = 200;
            grfReq.Cols[colRqRemark].Width = 200;
            grfReq.Cols[colRqLabName].Width = 120;
            grfReq.Cols[colOPUDate].Width = 100;
            grfReq.Cols[colOPUTime].Width = 60;
            grfReq.Cols[colOPUTimeModi].Width = 60;
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
                row1[colRqHn] = row[ic.ivfDB.lbReqDB.lbReq.hn_female].ToString();
                row1[colRqVn] = row[ic.ivfDB.lbReqDB.lbReq.vn].ToString();
                row1[colRqName] = row[ic.ivfDB.lbReqDB.lbReq.name_female].ToString();
                row1[colRqDate] = row[ic.ivfDB.lbReqDB.lbReq.req_date].ToString();
                row1[colRqRemark] = row["form_a_remark"].ToString();
                row1[colOPUDate] = ic.datetoShow(row[ic.ivfDB.lFormaDB.lformA.opu_date].ToString());
                row1[colOPUTime] = row[ic.ivfDB.lFormaDB.lformA.opu_time].ToString();
                row1[colOPUTimeModi] = row[ic.ivfDB.lFormaDB.lformA.opu_time_modi].ToString();
                row1[colRqLabName] = row["SName"].ToString();
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
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("ป้อน LAB OPU/FET", new EventHandler(ContextMenu_proc_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfProc.ContextMenu = menuGw;
            panel2.Controls.Add(grfProc);

            theme1.SetTheme(grfProc, "Office2010Blue");
        }
        private void setGrfProc()
        {
            grfProc.DataSource = null;
            grfProc.Clear();
            DataTable dt = new DataTable();

            dt = ic.ivfDB.opuDB.selectByStatusProcess1();
            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfProc.Rows.Count = 1;
            grfProc.Cols.Count = 7;
            C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfProc.Cols[colPcOpuNum].Editor = txt;
            grfProc.Cols[colPcHn].Editor = txt;
            grfProc.Cols[colPcPttName].Editor = txt;
            grfProc.Cols[colPcDate].Editor = txt;
            grfProc.Cols[colPcRemark].Editor = txt;

            grfProc.Cols[colPcOpuNum].Width = 120;
            grfProc.Cols[colPcHn].Width = 120;
            grfProc.Cols[colPcPttName].Width = 280;
            grfProc.Cols[colPcDate].Width = 100;
            grfProc.Cols[colPcRemark].Width = 200;
            //grfProc.Cols[colRqRemark].Width = 200;
            grfProc.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfProc.Cols[colPcOpuNum].Caption = "OPU number";
            grfProc.Cols[colPcHn].Caption = "HN female";
            grfProc.Cols[colPcPttName].Caption = "Patient Name";
            grfProc.Cols[colPcDate].Caption = "OPU Date";
            grfProc.Cols[colPcRemark].Caption = "Remark";
            //grfProc.Cols[colRqRemark].Caption = "Remark";
            //grfProc.Cols[colDtrName].Caption = "Doctor";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                Row row1 = grfProc.Rows.Add();
                row1[colPcId] = row[ic.ivfDB.opuDB.opu.opu_id].ToString();
                row1[colPcOpuNum] = row[ic.ivfDB.opuDB.opu.opu_code].ToString();
                row1[colPcHn] = row[ic.ivfDB.opuDB.opu.hn_female].ToString();
                row1[colPcPttName] = row[ic.ivfDB.opuDB.opu.name_female].ToString();
                row1[colPcDate] = ic.datetoShow(row[ic.ivfDB.opuDB.opu.opu_date].ToString());
                row1[colPcRemark] = row[ic.ivfDB.opuDB.opu.remark].ToString();
                //row1[colRqRemark] = row[ic.ivfDB.lbReqDB.lbReq.remark].ToString();
                //row1[colOpuId] = "";
                //row1[colDtrName] = row["dtr_name"].ToString();
                row1[0] = i;
                i++;
            }
            grfProc.Cols[colRqId].Visible = false;
            //grfReq.Cols[coldt].Visible = false;
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
        private void BtnNew_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            openLabOPUNew("","");
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
        private void openLabOPUNew(String reqId, String name)
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
                    if(grfReq[grfReq.Row, colRqLabName].ToString().Trim().Equals("OPU"))
                    {
                        LabOpu opu1 = ic.ivfDB.setOPU(reqId);
                        String re1 = ic.ivfDB.opuDB.insert(opu1, ic.cStf.staff_id);
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
                            FrmLabFetAdd1 frm = new FrmLabFetAdd1(ic, "", re1);
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
        }
    }
}
