using C1.Win.C1FlexGrid;
using C1.Win.C1SuperTooltip;
using clinic_ivf.control;
using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.gui
{
    public partial class FrmLabBloodView : Form
    {
        IvfControl ic;
        MainMenu menu;

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;

        C1FlexGrid grfReq, grfProc, grfSearch, grfFinish;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;

        int colReqId = 1, colReqLabName = 2, colReqHn = 3, colReqPttName=4, colReqVnShow = 5, colReqDate = 6, colReqTime=7, colReqVn=8;
        int colRsId = 1, colRsLabName = 2, colRsHn=3, colRsPttName=4, colRsMethod = 5, colRsResult = 6, colRsInterpret = 7, colRsUnit = 8, colRsNormal = 9, colRsRemark = 10, colRsLabId = 11, colRsReqId = 12;

        Timer timer;
        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetDefaultPrinter(string Printer);
        public FrmLabBloodView(IvfControl ic, MainMenu m)
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

            int timerlab = 0;
            int.TryParse(ic.iniC.timerlabreqaccept, out timerlab);
            timer = new Timer();
            timer.Interval = timerlab * 1000;
            timer.Tick += Timer_Tick;
            timer.Enabled = true;

            initGrfReq();
            setGrfReq();
            initGrfProc();
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
            grfReq.DoubleClick += GrfReq_DoubleClick;
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("รับ request พิมพ์ Sticker", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("รับทราบการเปลี่ยนแปลงเวลา", new EventHandler(ContextMenu_Gw_time_modi));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfReq.ContextMenu = menuGw;
            pnReq.Controls.Add(grfReq);

            theme1.SetTheme(grfReq, "Office2010Blue");
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
            //menuGw.MenuItems.Add("รับ request พิมพ์ Sticker", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("รับทราบการเปลี่ยนแปลงเวลา", new EventHandler(ContextMenu_Gw_time_modi));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            //grfProc.ContextMenu = menuGw;
            pnProc.Controls.Add(grfProc);

            theme1.SetTheme(grfProc, "Office2010Blue");
        }
        private void setGrfProc()
        {
            grfProc.DataSource = null;
            grfProc.Clear();
            DataTable dt = new DataTable();

            //dt = ic.ivfDB.lbReqDB.selectByStatusReqAccept();
            dt = ic.ivfDB.lbresDB.selectLabBloodByProcess();
            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfProc.Rows.Count = 1;
            grfProc.Cols.Count = 13;
            //C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            //grfReq.Cols[colRqReqNum].Editor = txt;
            //grfReq.Cols[colRqHn].Editor = txt;
            //grfReq.Cols[colRqVn].Editor = txt;
            //grfReq.Cols[colRqName].Editor = txt;

            grfProc.Cols[colRsLabName].Width = 200;
            grfProc.Cols[colRsMethod].Width = 100;
            grfProc.Cols[colRsResult].Width = 100;
            grfProc.Cols[colRsInterpret].Width = 100;
            grfProc.Cols[colRsUnit].Width = 80;
            grfProc.Cols[colRsNormal].Width = 100;
            grfProc.Cols[colRsRemark].Width = 200;
            grfProc.Cols[colRsHn].Width = 100;
            grfProc.Cols[colRsPttName].Width = 200;
            grfProc.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfProc.Cols[colRsLabName].Caption = "Name";
            grfProc.Cols[colRsMethod].Caption = "Method";
            grfProc.Cols[colRsResult].Caption = "Result";
            grfProc.Cols[colRsInterpret].Caption = "Interpret";
            grfProc.Cols[colRsUnit].Caption = "Unit";
            grfProc.Cols[colRsNormal].Caption = "Normal";
            grfProc.Cols[colRsRemark].Caption = "Remark";
            grfProc.Cols[colRsHn].Caption = "HN";
            grfProc.Cols[colRsPttName].Caption = "Patient Name";
            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            String chk = "";
            foreach (DataRow row in dt.Rows)
            {
                Row row1 = grfProc.Rows.Add();
                row1[colRsId] = row[ic.ivfDB.lbresDB.lbRes.result_id].ToString();
                row1[colRsLabName] = row[ic.ivfDB.oLabiDB.labI.LName].ToString();

                row1[colRsMethod] = row[ic.ivfDB.lbresDB.lbRes.method].ToString();
                row1[colRsResult] = row[ic.ivfDB.lbresDB.lbRes.result].ToString();
                row1[colRsInterpret] = row[ic.ivfDB.lbresDB.lbRes.interpret].ToString();
                
                row1[colRsUnit] = row[ic.ivfDB.lbresDB.lbRes.unit].ToString();
                row1[colRsNormal] = row[ic.ivfDB.lbresDB.lbRes.normal_value].ToString();
                row1[colRsRemark] = row[ic.ivfDB.lbresDB.lbRes.remark].ToString();
                row1[colRsLabId] = row[ic.ivfDB.lbresDB.lbRes.lab_id].ToString();
                row1[colRsReqId] = row[ic.ivfDB.lbresDB.lbRes.req_id].ToString();
                row1[colRsHn] = row["patient_hn"].ToString();
                row1[colRsPttName] = row["pname"].ToString();
                //row1[colOPUTimeModi] = row[ic.ivfDB.lFormaDB.lformA.opu_time_modi].ToString();
                //row1[colRqLabName] = row["SName"].ToString();
                //row1[colRqHnMale] = row["hn_male"].ToString();
                //row1[colRqNameMale] = row["name_male"].ToString();
                //row1[colRqHnDonor] = row["hn_donor"].ToString();
                //row1[colRqNameDonor] = row["name_donor"].ToString();

                i++;
            }
            grfProc.Cols[colRsId].Visible = false;
            grfProc.Cols[colRsLabId].Visible = false;
            grfProc.Cols[colRsReqId].Visible = false;

            grfProc.Cols[colRsLabName].AllowEditing = false;
            grfProc.Cols[colRsMethod].AllowEditing = false;
            grfProc.Cols[colRsResult].AllowEditing = false;
            grfProc.Cols[colRsInterpret].AllowEditing = false;
            grfProc.Cols[colRsUnit].AllowEditing = false;
            grfProc.Cols[colRsNormal].AllowEditing = false;
            grfProc.Cols[colRsRemark].AllowEditing = false;
            grfProc.Cols[colRsHn].AllowEditing = false;
            grfProc.Cols[colRsPttName].AllowEditing = false;
            //grfReq.Cols[coldt].Visible = false;
        }
        private void GrfProc_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfProc.Row <= 0) return;
            if (grfProc.Col <= 0) return;
            String id = "";
            id = grfProc[grfProc.Row, colRsId] != null ? grfProc[grfProc.Row, colRsId].ToString() : "";
            FrmLabBloodAdd frm = new FrmLabBloodAdd(ic, id);
            frm.ShowDialog(this);
        }

        private void GrfProc_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();

        }

        private void GrfReq_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ContextMenu_edit(null, null);
        }

        private void GrfReq_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;
        }
        private void ContextMenu_edit(object sender, System.EventArgs e)
        {
            String chk1 = "", name = "", id = "";
            if (grfReq.Row < 0) return;
            id = grfReq[grfReq.Row, colReqId] != null ? grfReq[grfReq.Row, colReqId].ToString() : "";
            if (id.Length <= 0) return;
            ic.cStf.staff_id = "";
            FrmPasswordConfirm frm1 = new FrmPasswordConfirm(ic);
            frm1.ShowDialog(this);
            if (!ic.cStf.staff_id.Equals(""))
            {
                LabRequest lbreq = new LabRequest();
                lbreq = ic.ivfDB.lbReqDB.selectByPk1(id);
                if (lbreq.req_id.Length <= 0) return;
                
                Lis lis = new Lis();
                lis.lis_id = "";
                lis.barcode = "";
                lis.req_id = lbreq.req_id;
                lis.visit_vn = lbreq.vn;
                
                if (lbreq.name_female.Length > 0)
                {
                    lis.patient_name = lbreq.name_female;
                    lis.visit_hn = lbreq.hn_female;
                }
                else
                {
                    lis.patient_name = lbreq.name_male;
                    lis.visit_hn = lbreq.hn_male;
                }
                
                lis.visit_id = lbreq.visit_id;
                lis.message_lis = "";
                lis.active = "";
                lis.remark = "";
                lis.date_create = "";
                lis.date_modi = "";
                lis.date_cancel = "";
                lis.user_create = "";
                lis.user_modi = "";
                lis.user_cancel = "";
                lis.statis_lis = "";
                lis.date_time_receive = "";
                lis.date_time_finish = "";
                lis.lab_id = lbreq.item_id;

                String re = "",re1="", re2="";
                long chk = 0, chk2=0;
                re1 = ic.ivfDB.lisDB.insertLis(lis, ic.cStf.staff_id);
                if(long.TryParse(re1, out chk))
                {
                    LabResult lbRes = new LabResult();

                    lbRes.result_id = "";
                    lbRes.lis_id = re1;
                    lbRes.req_id = lbreq.req_id;
                    lbRes.visit_id = lbreq.visit_id;
                    lbRes.patient_id = "";
                    lbRes.lab_id = lbreq.item_id;
                    lbRes.result = "";
                    lbRes.method = "";
                    lbRes.active = "";
                    lbRes.remark = "";
                    lbRes.date_create = "";
                    lbRes.date_modi = "";
                    lbRes.date_cancel = "";
                    lbRes.user_create = "";
                    lbRes.user_modi = "";
                    lbRes.user_cancel = "";
                    lbRes.unit = "";
                    lbRes.sort1 = "";
                    lbRes.staff_id_result = "";
                    lbRes.staff_id_approve = "";
                    lbRes.date_time_result = "";
                    lbRes.date_time_approve = "";
                    lbRes.normal_value = "";
                    lbRes.interpret = "";
                    lbRes.status_result = "1";
                    lbRes.row1 = "0";
                    re2 = ic.ivfDB.lbresDB.insertLabResult(lbRes, ic.cStf.staff_id);
                    if (long.TryParse(re2, out chk2))
                    {
                        re = ic.ivfDB.lbReqDB.UpdateStatusRequestAccept(id, ic.cStf.staff_id);
                        chk = 0;
                        if (long.TryParse(re, out chk))
                        {
                            try
                            {
                                SetDefaultPrinter(ic.iniC.printerSticker);

                                Lis lis1 = new Lis();
                                lis1 = ic.ivfDB.lisDB.selectByPk(re1);
                                Visit vs = new Visit();
                                vs = ic.ivfDB.vsDB.selectByVn(lis1.visit_vn);
                                Patient ptt = new Patient();
                                ptt = ic.ivfDB.pttDB.selectByPk1(vs.t_patient_id);

                                DataTable dt = new DataTable();
                                dt.Columns.Add("hn", typeof(String));
                                dt.Columns.Add("name", typeof(String));
                                dt.Columns.Add("age", typeof(String));
                                dt.Columns.Add("vn", typeof(String));
                                DataRow row11 = dt.NewRow();
                                row11["hn"] = lis1.visit_hn;
                                row11["name"] = lis1.patient_name;
                                row11["age"] = "Age " + ptt.AgeStringShort() + " [" + ic.datetoShow(ptt.patient_birthday) + "]";
                                row11["vn"] = lis1.barcode;
                                dt.Rows.Add(row11);
                                FrmReport frm = new FrmReport(ic);
                                frm.setStickerPatientThemalLIS(dt);
                                frm.ShowDialog(this);
                                SetDefaultPrinter(ic.iniC.printerSticker);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                }

            }
            setGrfReq();
            //chk = grfReq[grfReq.Row, colRqReqNum] != null ? grfReq[grfReq.Row, colRqReqNum].ToString() : "";
            //name = grfReq[grfReq.Row, colRqName] != null ? grfReq[grfReq.Row, colRqName].ToString() : "";
            ////if (MessageBox.Show("ต้องการ ป้อน LAB OPU  \n  req number " + chk+" \n name "+ name, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            ////{
            ////grfReq.Rows.Remove(grfReq.Row);
            //Cursor curOld;
            //curOld = this.Cursor;
            //this.Cursor = Cursors.WaitCursor;
            //openLabOPUNew(id, name);
            //setGrfReq();
            //setGrfProc("");
            //this.Cursor = curOld;
            //}
        }
        private void setGrfReq()
        {
            grfReq.DataSource = null;
            grfReq.Clear();
            grfReq.Rows.Count = 0;
            DataTable dt = new DataTable();
            
            //dt = ic.ivfDB.lbReqDB.selectByStatusReqAccept();
            dt = ic.ivfDB.lbReqDB.selectLabBloodByReq1();
            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfReq.Rows.Count = 1;
            grfReq.Cols.Count = 9;
            //C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            //grfReq.Cols[colRqReqNum].Editor = txt;
            //grfReq.Cols[colRqHn].Editor = txt;
            //grfReq.Cols[colRqVn].Editor = txt;
            //grfReq.Cols[colRqName].Editor = txt;

            grfReq.Cols[colReqLabName].Width = 200;
            grfReq.Cols[colReqHn].Width = 120;
            grfReq.Cols[colReqVnShow].Width = 80;
            grfReq.Cols[colReqDate].Width = 100;
            grfReq.Cols[colReqPttName].Width = 200;
            grfReq.Cols[colReqTime].Width = 70;
            grfReq.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfReq.Cols[colReqLabName].Caption = "Lab Name";
            grfReq.Cols[colReqHn].Caption = "HN";
            grfReq.Cols[colReqVnShow].Caption = "VN";
            grfReq.Cols[colReqDate].Caption = "Date";
            grfReq.Cols[colReqPttName].Caption = "Name";
            grfReq.Cols[colReqTime].Caption = "Time";
            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            String chk = "";
            foreach (DataRow row in dt.Rows)
            {
                Row row1 = grfReq.Rows.Add();
                row1[colReqId] = row[ic.ivfDB.lbReqDB.lbReq.req_id].ToString();
                row1[colReqLabName] = row[ic.ivfDB.oLabiDB.labI.LName].ToString();
                
                row1[colReqVnShow] = ic.showVN(row[ic.ivfDB.lbReqDB.lbReq.vn].ToString());
                row1[colReqVn] = row[ic.ivfDB.lbReqDB.lbReq.vn].ToString();
                row1[colReqDate] = ic.datetoShow(row[ic.ivfDB.lbReqDB.lbReq.req_date].ToString());
                if (row[ic.ivfDB.lbReqDB.lbReq.name_female].ToString().Length > 0)
                {
                    row1[colReqHn] = row[ic.ivfDB.lbReqDB.lbReq.hn_female].ToString();
                    row1[colReqPttName] = row[ic.ivfDB.lbReqDB.lbReq.name_female].ToString();
                }
                else
                {
                    row1[colReqHn] = row[ic.ivfDB.lbReqDB.lbReq.hn_male].ToString();
                    row1[colReqPttName] = row[ic.ivfDB.lbReqDB.lbReq.name_male].ToString();
                }
                row1[colReqTime] = ic.timetoShow(row[ic.ivfDB.lbReqDB.lbReq.date_create].ToString());
                //row1[colOPUTime] = row[ic.ivfDB.lFormaDB.lformA.opu_time].ToString();
                //row1[colOPUTimeModi] = row[ic.ivfDB.lFormaDB.lformA.opu_time_modi].ToString();
                //row1[colRqLabName] = row["SName"].ToString();
                //row1[colRqHnMale] = row["hn_male"].ToString();
                //row1[colRqNameMale] = row["name_male"].ToString();
                //row1[colRqHnDonor] = row["hn_donor"].ToString();
                //row1[colRqNameDonor] = row["name_donor"].ToString();
                
                i++;
            }
            grfReq.Cols[colReqId].Visible = false;
            grfReq.Cols[colReqVn].Visible = false;
            grfReq.Cols[colReqLabName].AllowEditing = false;
            grfReq.Cols[colReqVnShow].AllowEditing = false;
            grfReq.Cols[colReqDate].AllowEditing = false;
            grfReq.Cols[colReqHn].AllowEditing = false;
            grfReq.Cols[colReqPttName].AllowEditing = false;
            grfReq.Cols[colReqTime].AllowEditing = false;
            //grfReq.Cols[colOPUDate].AllowEditing = false;
            //grfReq.Cols[colOPUTime].AllowEditing = false;
            //grfReq.Cols[colOPUTimeModi].AllowEditing = false;
            //grfReq.Cols[colRqLabName].AllowEditing = false;
            //grfReq.Cols[colRqHnMale].AllowEditing = false;
            //grfReq.Cols[colRqNameMale].AllowEditing = false;
            //grfReq.Cols[colRqHnDonor].AllowEditing = false;
            //grfReq.Cols[colRqNameDonor].AllowEditing = false;
            //CellNoteManager mgr = new CellNoteManager(grfReq);
            //grfReq.Cols[coldt].Visible = false;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setGrfReq();
            setGrfProc();
        }

        private void FrmLabBloodView_Load(object sender, EventArgs e)
        {
            tcLabView.SelectedTab = tabLabAccept;
        }
    }
}
