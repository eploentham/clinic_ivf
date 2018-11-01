using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
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
    public partial class FrmAppoinmentView : Form
    {
        IvfControl ic;
        MainMenu menu;

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;

        int colID = 1, colpttId = 2, colPttHn = 3, colVsTime = 5, colVsDate = 4, colVsDoctor = 6, colStatus = 7, colVsPttName=8, colVsMobile=9, colVsAppn=10;

        C1FlexGrid grfPtt;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;

        public FrmAppoinmentView(IvfControl ic, MainMenu m)
        {
            InitializeComponent();
            this.ic = ic;
            this.menu = m;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);

            //C1ThemeController.ApplicationTheme = ic.iniC.themeApplication;
            theme1.Theme = ic.iniC.themeApplication;
            theme1.SetTheme(sB, "BeigeOne");

            sB1.Text = "";
            bg = txtHn.BackColor;
            fc = txtHn.ForeColor;
            ff = txtHn.Font;

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            txtDateStart.Value = DateTime.Now.ToString("yyyy-MM-dd");
            txtDateEnd.Value = DateTime.Now.ToString("yyyy-MM-dd");
            ic.ivfDB.dtrOldDB.setCboBsp(cboDoctor,"");

            btnSearch.Click += BtnSearch_Click;
            txtSearch.KeyUp += TxtSearch_KeyUp;
            btnNew.Click += BtnNew_Click;

            initGrfPtt();
            setGrfPtt();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmAppointmentAdd frm = new FrmAppointmentAdd();
            frm.ShowDialog(this);

        }

        private void TxtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();

        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

        }
        private void initGrfPtt()
        {
            grfPtt = new C1FlexGrid();
            grfPtt.Font = fEdit;
            grfPtt.Dock = System.Windows.Forms.DockStyle.Fill;
            grfPtt.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            grfPtt.AfterRowColChange += GrfPtt_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfPtt.ContextMenu = menuGw;
            gb.Controls.Add(grfPtt);

            theme1.SetTheme(grfPtt, "Office2010Blue");

        }

        private void GrfPtt_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();

        }
        private void setGrfPtt()
        {
            //grfDept.Rows.Count = 7;
            grfPtt.Clear();
            DataTable dt = new DataTable();
            DateTime datestart, dateend;
            String datestart1="", dateend1="";
            if (DateTime.TryParse(txtDateStart.Text, out datestart))
            {
                datestart1 = datestart.ToString("yyyy-MM-dd");
            }
            if(DateTime.TryParse(txtDateEnd.Text, out dateend))
            {
                dateend1 = dateend.ToString("yyyy-MM-dd");
            }
            
                //String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            dt = ic.ivfDB.appnOldDB.selectByDateDtr(datestart1, dateend1, cboDoctor.Text);
            

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfPtt.Rows.Count = 1;
            grfPtt.Cols.Count = 11;
            C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfPtt.Cols[colPttHn].Editor = txt;
            grfPtt.Cols[colVsDate].Editor = txt;
            grfPtt.Cols[colVsTime].Editor = txt;
            grfPtt.Cols[colVsDoctor].Editor = txt;
            grfPtt.Cols[colStatus].Editor = txt;
            grfPtt.Cols[colVsPttName].Editor = txt;
            grfPtt.Cols[colVsMobile].Editor = txt;
            grfPtt.Cols[colVsAppn].Editor = txt;

            grfPtt.Cols[colPttHn].Width = 120;
            grfPtt.Cols[colVsDate].Width = 120;
            grfPtt.Cols[colVsTime].Width = 60;
            grfPtt.Cols[colVsAppn].Width = 200;
            grfPtt.Cols[colVsDoctor].Width = 80;
            grfPtt.Cols[colStatus].Width = 80;
            grfPtt.Cols[colVsPttName].Width = 200;
            grfPtt.Cols[colVsMobile].Width = 100;            

            grfPtt.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfPtt.Cols[colPttHn].Caption = "HN";
            grfPtt.Cols[colVsDate].Caption = "Date";
            grfPtt.Cols[colVsTime].Caption = "TIME";
            grfPtt.Cols[colVsAppn].Caption = "Appointment";
            grfPtt.Cols[colVsDoctor].Caption = "Doctor";
            grfPtt.Cols[colStatus].Caption = "status";
            grfPtt.Cols[colVsPttName].Caption = "Name";
            grfPtt.Cols[colVsMobile].Caption = "Mobile";

            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("&แก้ไข Patient", new EventHandler(ContextMenu_edit));
            grfPtt.ContextMenu = menuGw;

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                Row row1 = grfPtt.Rows.Add();
                String hormo="", tvs="", opu="", fet="", beta="", other="", appn = "";
                hormo = row[ic.ivfDB.appnOldDB.appnOld.HormoneTest].ToString().Equals("1") ? "Hormone Test " : "";
                tvs = row[ic.ivfDB.appnOldDB.appnOld.TVS].ToString().Equals("1") ? "TVS " : "";
                opu = row[ic.ivfDB.appnOldDB.appnOld.OPU].ToString().Equals("1") ? "OPU " + row[ic.ivfDB.appnOldDB.appnOld.OPUTime] != null ? row[ic.ivfDB.appnOldDB.appnOld.OPUTime].ToString()+ row[ic.ivfDB.appnOldDB.appnOld.OPURemark]!=null ? row[ic.ivfDB.appnOldDB.appnOld.OPURemark].ToString() : "" : "" : "";
                beta = row[ic.ivfDB.appnOldDB.appnOld.BetaHCG].ToString().Equals("1") ? "Beta HCG " : "";
                fet = row[ic.ivfDB.appnOldDB.appnOld.ET_FET].ToString().Equals("1") ? "ET/FET " + row[ic.ivfDB.appnOldDB.appnOld.ET_FET_Time] != null ? row[ic.ivfDB.appnOldDB.appnOld.ET_FET_Time].ToString() : "" : "";
                other = row[ic.ivfDB.appnOldDB.appnOld.Other].ToString().Equals("1") ? "Other " + row[ic.ivfDB.appnOldDB.appnOld.OtherRemark] != null ? row[ic.ivfDB.appnOldDB.appnOld.OtherRemark].ToString() : "" : "";
                appn = hormo + tvs + opu + beta + fet + other;
                row1[0] = i;
                row1[colID] = row[ic.ivfDB.appnOldDB.appnOld.ID].ToString();
                row1[colpttId] = row[ic.ivfDB.appnOldDB.appnOld.PID].ToString();
                row1[colPttHn] = row[ic.ivfDB.appnOldDB.appnOld.PIDS].ToString();
                row1[colVsTime] = row[ic.ivfDB.appnOldDB.appnOld.AppTime].ToString();
                row1[colVsDate] = ic.datetoShow(row[ic.ivfDB.appnOldDB.appnOld.AppDate]);
                row1[colVsDoctor] = row[ic.ivfDB.appnOldDB.appnOld.Doctor].ToString();
                row1[colStatus] = row[ic.ivfDB.appnOldDB.appnOld.Status].ToString();
                row1[colVsPttName] = row[ic.ivfDB.appnOldDB.appnOld.PatientName].ToString();
                row1[colVsMobile] = row[ic.ivfDB.appnOldDB.appnOld.MobilePhoneNo].ToString();
                row1[colVsAppn] = appn;
                //if (i % 2 == 0)
                //    grfPtt.Rows[i].StyleNew.BackColor = color;
                i++;
            }
            grfPtt.Cols[colID].Visible = false;
            grfPtt.Cols[colpttId].Visible = false;
            theme1.SetTheme(grfPtt, ic.theme);

        }
        private void ContextMenu_edit(object sender, System.EventArgs e)
        {
            String chk = "", name = "", id = "";
            id = grfPtt[grfPtt.Row, colpttId] != null ? grfPtt[grfPtt.Row, colpttId].ToString() : "";
            chk = grfPtt[grfPtt.Row, colPttHn] != null ? grfPtt[grfPtt.Row, colPttHn].ToString() : "";
            name = grfPtt[grfPtt.Row, colVsPttName] != null ? grfPtt[grfPtt.Row, colVsPttName].ToString() : "";
            //if (MessageBox.Show("ต้องการ แก้ไข Patient  \n  hn number " + chk + " \n name " + name, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            //grfReq.Rows.Remove(grfReq.Row);
            //openPatientAdd(id, name);
            //}
        }
        private void FrmAppoinmentView_Load(object sender, EventArgs e)
        {

        }
    }
}
