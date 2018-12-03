using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1SuperTooltip;
using clinic_ivf.control;
using clinic_ivf.objdb;
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
    public partial class FrmSearchHn : Form
    {
        IvfControl ic;
        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;
        int colCuHn = 2, colCuVn1 = 1, colCuName = 3, colCuDate=4, colCuTime=5, colDept=6;

        C1FlexGrid grfCu, grfDay3, grfDay5, grfDay6;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        public enum StatusConnection {host, hostEx};
        StatusConnection statusconn;
        public FrmSearchHn(IvfControl ic, StatusConnection statusconn)
        {
            InitializeComponent();
            this.ic = ic;
            this.statusconn = statusconn;
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
            bg = txtHnMale.BackColor;
            fc = txtHnMale.ForeColor;
            ff = txtHnMale.Font;

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();

            btnOk.Click += BtnOk_Click;

            initGrfCu();
            setGrfCu();
            tC1.SelectedTab = tabCurrent;
            btnSearch.Click += BtnSearch_Click;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.sVsOld = new VisitOld();
            ic.sVsOld.PName = txtName.Text;
            ic.sVsOld.VN = txtVn.Text;
            ic.sVsOld.PIDS = txtHn.Text;
            Close();
            //return true;
        }

        private void initGrfCu()
        {
            grfCu = new C1FlexGrid();
            grfCu.Font = fEdit;
            grfCu.Dock = System.Windows.Forms.DockStyle.Fill;
            grfCu.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            grfCu.AfterRowColChange += GrfCu_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfCu.ContextMenu = menuGw;
            gbCu.Controls.Add(grfCu);

            theme1.SetTheme(grfCu, "Office2010Blue");
        }

        private void GrfCu_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;
            String vn = "";
            vn = grfCu[e.NewRange.r1, colCuVn1] != null ? grfCu[e.NewRange.r1, colCuVn1].ToString() : "";
            if (!vn.Equals(""))
            {
                ic.sVsOld = new VisitOld();
                ic.sVsOld.PName = grfCu[grfCu.Row, colCuName]!= null ? grfCu[grfCu.Row, colCuName].ToString() : "";
                ic.sVsOld.VN = grfCu[grfCu.Row, colCuVn1] != null ? grfCu[grfCu.Row, colCuVn1].ToString() : "";
                ic.sVsOld.PIDS = grfCu[grfCu.Row, colCuHn] != null ? grfCu[grfCu.Row, colCuHn].ToString() : "";

                txtHn.Value = ic.sVsOld.PIDS;
                txtName.Value = ic.sVsOld.PName;
                txtVn.Value = ic.sVsOld.VN;
            }
            //grfAddr.DataSource = xC.iniDB.addrDB.selectByTableId1(vn);
        }

        private void setGrfCu()
        {
            //grfDept.Rows.Count = 7;
            grfCu.Clear();
            DataTable dt = new DataTable();
            grfCu.DataSource = null;
            ConnectDB con = new ConnectDB(ic.iniC);
            //con.OpenConnectionEx();
            dt = ic.ivfDB.vsOldDB.selectCurrentVisit(con.connEx);
            //con.CloseConnectionEx();
            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfCu.Rows.Count = 1;
            grfCu.Cols.Count = 7;
            C1TextBox txt = new C1TextBox();
            C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfCu.Cols[colCuHn].Editor = txt;
            grfCu.Cols[colCuVn1].Editor = txt;
            grfCu.Cols[colCuName].Editor = txt;

            grfCu.Cols[colCuHn].Width = 100;
            grfCu.Cols[colCuVn1].Width = 100;
            grfCu.Cols[colCuName].Width = 280;
            grfCu.Cols[colCuDate].Width = 100;
            grfCu.Cols[colCuTime].Width = 80;
            grfCu.Cols[colDept].Width = 120;
            //grfCu.Cols[colCuTime].Width = 80;

            grfCu.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfCu.Cols[colCuHn].Caption = "HN";
            grfCu.Cols[colCuVn1].Caption = "VN";
            grfCu.Cols[colCuName].Caption = "Name";
            grfCu.Cols[colCuDate].Caption = "Date";
            grfCu.Cols[colCuTime].Caption = "Time";
            grfCu.Cols[colDept].Caption = "dept";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            for (int i = 0; i <= dt.Rows.Count-1; i++)
            {
                Row row = grfCu.Rows.Add();
                row[0] = i;
                row[colCuVn1] = dt.Rows[i]["VN"].ToString();
                row[colCuHn] = dt.Rows[i]["PIDS"].ToString();
                row[colCuName] = dt.Rows[i]["PName"].ToString();
                row[colCuDate] =  ic.datetoShow(dt.Rows[i]["VDate"].ToString());
                row[colCuTime] = dt.Rows[i]["VStartTime"].ToString();
                row[colDept] = dt.Rows[i]["VName"].ToString();
            }
            grfCu.Cols[colCuHn].AllowEditing = false;
            grfCu.Cols[colCuVn1].AllowEditing = false;
            grfCu.Cols[colCuName].AllowEditing = false;
            grfCu.Cols[colCuDate].AllowEditing = false;
            grfCu.Cols[colCuTime].AllowEditing = false;
            grfCu.Cols[colDept].AllowEditing = false;
        }
        private void FrmSearchHn_Load(object sender, EventArgs e)
        {
            
        }
    }
}
