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

                String re = "",re1="";
                long chk = 0;
                re1 = ic.ivfDB.lisDB.insertLis(lis, ic.cStf.staff_id);
                if(long.TryParse(re1, out chk))
                {
                    re = ic.ivfDB.lbReqDB.UpdateStatusRequestAccept(id, ic.cStf.staff_id);
                    chk = 0;
                    if (long.TryParse(re, out chk))
                    {
                        try
                        {
                            SetDefaultPrinter(ic.iniC.printerSticker);

                            Visit vs = new Visit();
                            vs = ic.ivfDB.vsDB.selectByPk1(lis.visit_id);
                            Patient ptt = new Patient();
                            ptt = ic.ivfDB.pttDB.selectByPk1(vs.t_patient_id);
                            Lis lis1 = new Lis();
                            lis1 = ic.ivfDB.lisDB.selectByPk(re1);

                            DataTable dt = new DataTable();
                            dt.Columns.Add("hn", typeof(String));
                            dt.Columns.Add("name", typeof(String));
                            dt.Columns.Add("age", typeof(String));
                            dt.Columns.Add("vn", typeof(String));
                            DataRow row11 = dt.NewRow();
                            row11["hn"] = ptt.patient_hn;
                            row11["name"] = ptt.Name;
                            row11["age"] = "Age " + ptt.AgeStringShort() + " [" + ic.datetoShow(ptt.patient_birthday) + "]";
                            row11["vn"] = lis1.barcode;
                            dt.Rows.Add(row11);
                            FrmReport frm = new FrmReport(ic);
                            frm.setStickerPatientThemal(dt);
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

        }

        private void FrmLabBloodView_Load(object sender, EventArgs e)
        {
            tcLabView.SelectedTab = tabLabAccept;
        }
    }
}
