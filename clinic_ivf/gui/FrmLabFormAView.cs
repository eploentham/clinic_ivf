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
    public partial class FrmLabFormAView : Form
    {
        IvfControl ic;
        MainMenu menu;

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;
        int colID = 1, colVN = 2, colPttHn = 3, colPttName = 4, colVsDate = 5, colVsTime = 6, colVsEtime = 7, colStatus = 8, colPttId = 9;

        C1FlexGrid grfQue;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        public FrmLabFormAView(IvfControl ic, MainMenu m)
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
            txtDateStart.Value = DateTime.Now;
            txtDateEnd.Value = DateTime.Now;
            //theme1.SetTheme(tC, "Office2010Blue");
            sB1.Text = "";
            bg = txtDateStart.BackColor;
            fc = txtDateStart.ForeColor;
            ff = txtDateStart.Font;

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            btnNew.Click += BtnNew_Click;
            btnSearch.Click += BtnSearch_Click;
            initGrfQue();
            setGrfQue();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setGrfQue();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmLabFormA frm = new FrmLabFormA(ic, "", "", "", "");
            frm.ShowDialog(this);
        }

        private void initGrfQue()
        {
            grfQue = new C1FlexGrid();
            grfQue.Font = fEdit;
            grfQue.Dock = System.Windows.Forms.DockStyle.Fill;
            grfQue.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            grfQue.AfterRowColChange += GrfReq_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            
            grfQue.ContextMenu = menuGw;
            groupBox2.Controls.Add(grfQue);

            theme1.SetTheme(grfQue, "Office2010Red");

        }
        private void GrfReq_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;
            String vn = "";

            //grfAddr.DataSource = xC.iniDB.addrDB.selectByTableId1(vn);
        }
        private void setGrfQue()
        {
            //grfDept.Rows.Count = 7;
            grfQue.Clear();
            DataTable dt1 = new DataTable();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.lFormaDB.selectReportByDate(ic.datetoDB(txtDateStart.Text), ic.datetoDB(txtDateEnd.Text), txtSearch.Text.Trim());
            //if (search.Equals(""))
            //{
            //    String date = "";
            //    DateTime dt11 = new DateTime();
            //    if (DateTime.TryParse(txtDateStart.Text, out dt11))
            //    {
            //        date = dt11.Year + "-" + dt11.ToString("MM-dd");
            //        dt = ic.ivfDB.vsOldDB.selectByDate(date);
            //    }
            //}
            //else
            //{
            //    //grfPtt.DataSource = ic.ivfDB.vsOldDB.selectCurrentVisit(search);
            //}

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfQue.Rows.Count = dt.Rows.Count + 1;
            grfQue.Cols.Count = 10;
            C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfQue.Cols[colPttHn].Editor = txt;
            grfQue.Cols[colPttName].Editor = txt;
            grfQue.Cols[colVsDate].Editor = txt;

            grfQue.Cols[colVN].Width = 120;
            grfQue.Cols[colPttHn].Width = 120;
            grfQue.Cols[colPttName].Width = 300;
            grfQue.Cols[colVsDate].Width = 100;
            grfQue.Cols[colVsTime].Width = 80;
            grfQue.Cols[colVsEtime].Width = 80;
            grfQue.Cols[colStatus].Width = 200;

            grfQue.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfQue.Cols[colVN].Caption = "VN";
            grfQue.Cols[colPttHn].Caption = "HN";
            grfQue.Cols[colPttName].Caption = "Name";
            grfQue.Cols[colVsDate].Caption = "Date";
            grfQue.Cols[colVsTime].Caption = "Time visit";
            grfQue.Cols[colVsEtime].Caption = "Time finish";
            grfQue.Cols[colStatus].Caption = "Status";

            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&receive operation", new EventHandler(ContextMenu_Apm));
            //menuGw.MenuItems.Add("&receive operation", new EventHandler(ContextMenu_Apm));
            //menuGw.MenuItems.Add("&LAB request FORM A", new EventHandler(ContextMenu_LAB_req_formA_Ptt));
            //menuGw.MenuItems.Add("&Add Appointment", new EventHandler(ContextMenu_Apm_Ptt));
            //menuGw.MenuItems.Add("&Cancel Receive", new EventHandler(ContextMenu_Apm_Ptt));
            //menuGw.MenuItems.Add("&No Appointment Close Operation", new EventHandler(ContextMenu_NO_Apm_Ptt));
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
                grfQue[i, colVN] = row["VN"].ToString();
                grfQue[i, colPttHn] = row["PIDS"].ToString();
                grfQue[i, colPttName] = row["PName"].ToString();
                grfQue[i, colVsDate] = ic.datetoShow(row["VDate"]);
                grfQue[i, colVsTime] = row["VStartTime"].ToString();
                grfQue[i, colVsEtime] = row["VEndTime"].ToString();
                grfQue[i, colStatus] = row["VName"].ToString();
                grfQue[i, colPttId] = row["PID"].ToString();
                if (!row[ic.ivfDB.vsOldDB.vsold.form_a_id].ToString().Equals("0"))
                {
                    CellNote note = new CellNote("ส่ง Lab Request Foam A");
                    CellRange rg = grfQue.GetCellRange(i, colVN);
                    rg.UserData = note;
                }
                //if (i % 2 == 0)
                //    grfPtt.Rows[i].StyleNew.BackColor = color;
                i++;
            }
            CellNoteManager mgr = new CellNoteManager(grfQue);
            grfQue.Cols[colID].Visible = false;
            //theme1.SetTheme(grfQue, ic.theme);

        }
        private void FrmLabFormAView_Load(object sender, EventArgs e)
        {

        }
    }
}
