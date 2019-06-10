using C1.Win.C1FlexGrid;
using C1.Win.C1SuperTooltip;
using clinic_ivf.control;
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

        int colReqId = 1, colReqLabName = 2, colReqHn = 3, colReqVnShow = 4, colReqDate = 5, colReqName = 6, colReqlabId=7, colReqJoblabId=8, colReqVn=9;
        
        Timer timer;

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
            txtDateEnd.Value = System.DateTime.Now;
            txtDateStart.Value = System.DateTime.Now;
            txtFiDateEnd.Value = System.DateTime.Now;
            txtFiDateStart.Value = System.DateTime.Now;
            //C1ThemeController.ApplicationTheme = ic.iniC.themeApplication;
            theme1.Theme = ic.iniC.themeApplication;
            theme1.SetTheme(sB, "BeigeOne");

            sB1.Text = "";
            bg = txtHn.BackColor;
            fc = txtHn.ForeColor;
            ff = txtHn.Font;

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
            menuGw.MenuItems.Add("ป้อน LAB OPU/FET", new EventHandler(ContextMenu_edit));
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
            String chk = "", name = "", id = "";

            //id = grfReq[grfReq.Row, colRqId] != null ? grfReq[grfReq.Row, colRqId].ToString() : "";
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
            dt = ic.ivfDB.lbReqDB.selectByStatusUnAccept3(datestart1, dateend1);
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

            grfReq.Cols[colReqLabName].Width = 200;
            grfReq.Cols[colReqHn].Width = 120;
            grfReq.Cols[colReqVnShow].Width = 80;
            grfReq.Cols[colReqDate].Width = 100;
            grfReq.Cols[colReqName].Width = 200;
            grfReq.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfReq.Cols[colReqLabName].Caption = "Lab Name";
            grfReq.Cols[colReqHn].Caption = "HN";
            grfReq.Cols[colReqVnShow].Caption = "VN";
            grfReq.Cols[colReqDate].Caption = "Dae";
            grfReq.Cols[colReqName].Caption = "Name";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            String chk = "";
            foreach (DataRow row in dt.Rows)
            {
                Row row1 = grfReq.Rows.Add();
                //row1[colRqId] = row[ic.ivfDB.lbReqDB.lbReq.req_id].ToString();
                //row1[colRqReqNum] = row[ic.ivfDB.lbReqDB.lbReq.req_code].ToString();
                //row1[colRqHn] = row[ic.ivfDB.lbReqDB.lbReq.hn_female].ToString();
                //row1[colRqVn] = row[ic.ivfDB.lbReqDB.lbReq.vn].ToString();
                //row1[colRqName] = row[ic.ivfDB.lbReqDB.lbReq.name_female].ToString();
                //row1[colRqDate] = ic.datetoShow(row[ic.ivfDB.lbReqDB.lbReq.req_date].ToString());
                //row1[colRqRemark] = row["form_a_remark"].ToString();
                //row1[colOPUDate] = ic.datetoShow(row[ic.ivfDB.lFormaDB.lformA.opu_date].ToString());
                //row1[colOPUTime] = row[ic.ivfDB.lFormaDB.lformA.opu_time].ToString();
                //row1[colOPUTimeModi] = row[ic.ivfDB.lFormaDB.lformA.opu_time_modi].ToString();
                //row1[colRqLabName] = row["SName"].ToString();
                //row1[colRqHnMale] = row["hn_male"].ToString();
                //row1[colRqNameMale] = row["name_male"].ToString();
                //row1[colRqHnDonor] = row["hn_donor"].ToString();
                //row1[colRqNameDonor] = row["name_donor"].ToString();
                
                i++;
            }
            //grfReq.Cols[colRqId].Visible = false;
            //grfReq.Cols[colRqVn].Visible = false;
            //grfReq.Cols[colRqReqNum].AllowEditing = false;
            //grfReq.Cols[colRqHn].AllowEditing = false;
            //grfReq.Cols[colRqVn].AllowEditing = false;
            //grfReq.Cols[colRqName].AllowEditing = false;
            //grfReq.Cols[colRqDate].AllowEditing = false;
            //grfReq.Cols[colRqRemark].AllowEditing = false;
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

        }
    }
}
