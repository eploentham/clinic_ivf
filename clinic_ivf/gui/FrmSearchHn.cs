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
    /*
     * 63-10-23     0021    ให้เริ่ม HN ใหม่ แต่ให้ใช้ข้อมูลเก่า
     */
    public partial class FrmSearchHn : Form
    {
        IvfControl ic;
        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;
        int colCuHnShow = 2, colCuVnShow = 1, colCuName = 3, colCuDate=4, colCuTime=5, colDept=6, colDOb=7, colCuPttYear=8, colCuPttHn=9, colCuVn=10;

        C1FlexGrid grfCu, grfHn, grfDay5, grfDay6;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        public enum StatusConnection {host, hostEx};
        public enum StatusSearch { PttSearch, DonorSearch };
        public enum StatusSearchTable { PttSearch, VisitSearch };
        StatusConnection statusconn;
        StatusSearch statussearch;
        StatusSearchTable statussearchtable;
        public FrmSearchHn(IvfControl ic, StatusConnection statusconn, StatusSearch statussearch, StatusSearchTable statussearchtable)
        {
            InitializeComponent();
            this.ic = ic;
            this.statusconn = statusconn;
            this.statussearch = statussearch;
            this.statussearchtable = statussearchtable;
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
            txtHn.Value = "-";
            txtName.Value = "-";

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();

            btnOk.Click += BtnOk_Click;

            initGrfCu();
            initGrfHn();
            setGrfCu();
            tC1.SelectedTab = tabCurrent;
            btnSearch.Click += BtnSearch_Click;
            txtHnMale.KeyUp += TxtHnMale_KeyUp;
            tC1.Click += TC1_Click;
            txtHnMale.Focus();
        }

        private void TC1_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if(tC1.SelectedTab == tabSearch)
            {
                txtHn.Value = "-";
                txtName.Value = "-";
                txtHnMale.Focus();
            }
        }

        private void TxtHnMale_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if(txtHnMale.Text.Length >= 4)
            {
                setGrfHn(txtHnMale.Text.Trim());
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setGrfHn(txtHnMale.Text.Trim());
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.sVsOld = new VisitOld();
            ic.sVsOld.PName = txtName.Text;
            ic.sVsOld.VN = txtVn.Text;
            ic.sVsOld.PIDS = txtHn.Text;
            ic.sVsOld.dob = txtDOB.Text;
            ic.sVsOld.patient_year = txtPttYear.Text;
            ic.sVsOld.patient_hn = txtPttHn.Text;
            Close();
            //return true;
        }
        private void initGrfHn()
        {
            grfHn = new C1FlexGrid();
            grfHn.Font = fEdit;
            grfHn.Dock = System.Windows.Forms.DockStyle.Fill;
            grfHn.Location = new System.Drawing.Point(0, 0);
            grfHn.Rows.Count = 1;
            //FilterRow fr = new FilterRow(grfExpn);

            grfHn.AfterRowColChange += GrfHn_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();

            grfHn.ContextMenu = menuGw;
            gbHn.Controls.Add(grfHn);

            theme1.SetTheme(grfHn, "Office2010Red");
        }
        private void GrfHn_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;
            String vn = "", hn="";

            if (statussearchtable == StatusSearchTable.VisitSearch)
            {
                vn = grfHn[e.NewRange.r1, colCuVn] != null ? grfHn[e.NewRange.r1, colCuVn].ToString() : "";
                if (!vn.Equals(""))
                {
                    ic.sVsOld = new VisitOld();
                    ic.sVsOld.PName = grfHn[grfHn.Row, colCuName] != null ? grfHn[grfHn.Row, colCuName].ToString() : "";
                    ic.sVsOld.VN = grfHn[grfHn.Row, colCuVn] != null ? grfHn[grfHn.Row, colCuVn].ToString() : "";
                    ic.sVsOld.PIDS = grfHn[grfHn.Row, colCuHnShow] != null ? grfHn[grfHn.Row, colCuHnShow].ToString() : "";
                    ic.sVsOld.dob = grfHn[grfHn.Row, colDOb] != null ? grfHn[grfHn.Row, colDOb].ToString() : "";
                    ic.sVsOld.patient_year = grfHn[grfHn.Row, colCuPttYear] != null ? grfHn[grfHn.Row, colCuPttYear].ToString() : "";
                    ic.sVsOld.patient_hn = grfHn[grfHn.Row, colCuPttHn] != null ? grfHn[grfHn.Row, colCuPttHn].ToString() : "";

                    txtHn.Value = ic.sVsOld.PIDS;
                    txtName.Value = ic.sVsOld.PName;
                    txtVn.Value = ic.sVsOld.VN;
                    txtDOB.Value = ic.sVsOld.dob;
                    txtPttHn.Value = ic.sVsOld.patient_hn;
                    txtPttYear.Value = ic.sVsOld.patient_year;
                }
                else
                {

                }
            }
            else if(statussearchtable == StatusSearchTable.PttSearch)
            {
                hn = grfHn[e.NewRange.r1, colCuHnShow] != null ? grfHn[e.NewRange.r1, colCuHnShow].ToString() : "";
                if (!hn.Equals(""))
                {
                    ic.sVsOld = new VisitOld();
                    ic.sVsOld.PName = grfHn[grfHn.Row, colCuName] != null ? grfHn[grfHn.Row, colCuName].ToString() : "";
                    ic.sVsOld.VN = "";
                    ic.sVsOld.PIDS = grfHn[grfHn.Row, colCuHnShow] != null ? grfHn[grfHn.Row, colCuHnShow].ToString() : "";
                    ic.sVsOld.dob = grfHn[grfHn.Row, colDOb] != null ? grfHn[grfHn.Row, colDOb].ToString() : "";
                    ic.sVsOld.patient_year = grfHn[grfHn.Row, colCuPttYear] != null ? grfHn[grfHn.Row, colCuPttYear].ToString() : "";
                    ic.sVsOld.patient_hn = grfHn[grfHn.Row, colCuPttHn] != null ? grfHn[grfHn.Row, colCuPttHn].ToString() : "";

                    txtHn.Value = ic.sVsOld.PIDS;
                    txtName.Value = ic.sVsOld.PName;
                    txtVn.Value = ic.sVsOld.VN;
                    txtDOB.Value = ic.sVsOld.dob;
                    txtPttHn.Value = ic.sVsOld.patient_hn;
                    txtPttYear.Value = ic.sVsOld.patient_year;
                }
            }
            //grfAddr.DataSource = xC.iniDB.addrDB.selectByTableId1(vn);
        }
        private void setGrfHn(String hn)
        {
            //grfDept.Rows.Count = 7;
            //grfHn.Clear();
            DataTable dt = new DataTable();
            grfHn.DataSource = null;
            ConnectDB con = new ConnectDB(ic.iniC);
            //con.OpenConnectionEx();
            if (ic.iniC.statusAppDonor.Equals("1"))
            {
                //dt = ic.ivfDB.ovsDB.selectCurrentVisit(con.connEx);
                //dt = ic.ivfDB.ovsDB.selectCurrentVisit(con.conn);
                if (statussearchtable == StatusSearchTable.VisitSearch)
                {
                    dt = ic.ivfDB.ovsDB.selectLikeByHN(hn, ic.conn.conn);
                }
                else
                {
                    dt = ic.ivfDB.pttDB.selectBySearch1(hn);
                }
            }
            else
            {
                //if (hn.Equals(""))         //-0021
                //{         //-0021
                //    dt = ic.ivfDB.ovsDB.selectCurrentVisit(ic.conn.conn);         //-0021
                //}         //-0021
                //else         //-0021
                //{         //-0021
                //if(statusconn == StatusConnection.hostEx)         //-0021
                //{         //-0021
                //    dt = ic.ivfDB.vsDB.selectByHNEx(hn);         //-0021
                //}         //-0021
                //else         //-0021
                //{         //-0021
                //    if (statussearchtable == StatusSearchTable.VisitSearch)         //-0021
                //    {         //-0021
                //        dt = ic.ivfDB.vsDB.selectLikeByHN(hn);         //-0021
                //    }         //-0021
                //    else         //-0021
                //    {         //-0021
                dt = ic.ivfDB.pttDB.selectBySearch1(hn);         //-0021
                //    }         //-0021
                //}         //-0021
                //dt = ic.ivfDB.vsDB.selectLikeByHNSearch(hn);
                //}         //-0021
            }
            if (dt.Rows.Count <= 0)
            {
                dt = ic.ivfDB.pttDB.selectBySearch1(hn);
            }
            //con.CloseConnectionEx();
            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfHn.Rows.Count = 1;
            grfHn.Cols.Count = 11;
            //C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            //grfHn.Cols[colCuHn].Editor = txt;
            //grfHn.Cols[colCuVn1].Editor = txt;
            //grfHn.Cols[colCuName].Editor = txt;

            grfHn.Cols[colCuHnShow].Width = 100;
            grfHn.Cols[colCuVnShow].Width = 100;
            grfHn.Cols[colCuName].Width = 280;
            grfHn.Cols[colCuDate].Width = 100;
            grfHn.Cols[colCuTime].Width = 80;
            grfHn.Cols[colDept].Width = 120;
            //grfHn.Cols[colCuTime].Width = 80;

            grfHn.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfHn.Cols[colCuHnShow].Caption = "HN";
            grfHn.Cols[colCuVnShow].Caption = "VN";
            grfHn.Cols[colCuName].Caption = "Name";
            grfHn.Cols[colCuDate].Caption = "Date";
            grfHn.Cols[colCuTime].Caption = "Time";
            grfHn.Cols[colDept].Caption = "dept";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfHn.Cols[colID].Visible = false;
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                Row row = grfHn.Rows.Add();
                row[0] = i;
                row[colCuVnShow] = ic.showVN(dt.Rows[i]["VN"].ToString());
                row[colCuHnShow] = ic.showHN(dt.Rows[i]["PIDS"].ToString(), dt.Rows[i]["patient_year"].ToString());
                row[colCuName] = dt.Rows[i]["PName"].ToString();
                row[colCuDate] = ic.datetoShow(dt.Rows[i]["VDate"].ToString());
                row[colCuTime] = ic.timetoShow(dt.Rows[i]["VStartTime"].ToString());
                row[colDept] = dt.Rows[i]["VName"].ToString();
                row[colDOb] = ic.datetoShow(dt.Rows[i]["dob"].ToString());
                row[colCuPttYear] = dt.Rows[i]["patient_year"].ToString();
                row[colCuPttHn] = dt.Rows[i]["patient_hn"].ToString();
                row[colCuVn] = dt.Rows[i]["VN"].ToString();
            }
            grfHn.Cols[colCuHnShow].AllowEditing = false;
            grfHn.Cols[colCuVnShow].AllowEditing = false;
            grfHn.Cols[colCuName].AllowEditing = false;
            grfHn.Cols[colCuDate].AllowEditing = false;
            grfHn.Cols[colCuTime].AllowEditing = false;
            grfHn.Cols[colDept].AllowEditing = false;
            grfHn.Cols[colDOb].AllowEditing = false;
            //grfHn.Cols[colDOb].Visible = false;
            grfHn.Cols[colCuPttYear].Visible = false;
            grfHn.Cols[colCuPttHn].Visible = false;
            grfHn.Cols[colCuVn].Visible = false;
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
            
            grfCu.ContextMenu = menuGw;
            gbCu.Controls.Add(grfCu);

            theme1.SetTheme(grfCu, "Office2010Blue");
        }

        private void GrfCu_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;
            String vn = "", hn="";
            vn = grfCu[e.NewRange.r1, colCuVn] != null ? grfCu[e.NewRange.r1, colCuVn].ToString() : "";
            hn = grfCu[e.NewRange.r1, colCuHnShow] != null ? grfCu[e.NewRange.r1, colCuHnShow].ToString() : "";
            if (!hn.Equals(""))
            {
                ic.sVsOld = new VisitOld();
                ic.sVsOld.PName = grfCu[grfCu.Row, colCuName]!= null ? grfCu[grfCu.Row, colCuName].ToString() : "";
                ic.sVsOld.VN = grfCu[grfCu.Row, colCuVn] != null ? grfCu[grfCu.Row, colCuVn].ToString() : "";
                ic.sVsOld.PIDS = grfCu[grfCu.Row, colCuHnShow] != null ? grfCu[grfCu.Row, colCuHnShow].ToString() : "";
                ic.sVsOld.dob = grfCu[grfCu.Row, colDOb] != null ? grfCu[grfCu.Row, colDOb].ToString() : "";
                ic.sVsOld.patient_year = grfCu[grfCu.Row, colCuPttYear] != null ? grfCu[grfCu.Row, colCuPttYear].ToString() : "";
                ic.sVsOld.patient_hn = grfCu[grfCu.Row, colCuPttHn] != null ? grfCu[grfCu.Row, colCuPttHn].ToString() : "";

                txtHn.Value = ic.sVsOld.PIDS;
                txtName.Value = ic.sVsOld.PName;
                txtVn.Value = ic.sVsOld.VN;
                txtDOB.Value = ic.sVsOld.dob;
                txtPttHn.Value = ic.sVsOld.patient_hn;
                txtPttYear.Value = ic.sVsOld.patient_year;
            }
            //grfAddr.DataSource = xC.iniDB.addrDB.selectByTableId1(vn);
        }
        private void setGrfCu()
        {
            //grfDept.Rows.Count = 7;
            //grfCu.Clear();
            DataTable dt = new DataTable();
            grfCu.DataSource = null;
            ConnectDB con = new ConnectDB(ic.iniC);
            con.OpenConnectionEx();
            //if (ic.iniC.statusAppDonor.Equals("1"))       //-0020
            //{       //-0020
            //    dt = ic.ivfDB.ovsDB.selectCurrentVisit(con.connEx);       //-0020
            //}       //-0020
            //else       //-0020
            //{       //-0020
            //if (statusconn == StatusConnection.hostEx)       //-0020
            //{       //-0020
            dt = ic.ivfDB.vsDB.selectCurrentVisitEx();
            //}       //-0020
            //else       //-0020
            //{       //-0020
            //    dt = ic.ivfDB.ovsDB.selectCurrentVisit(con.conn);       //-0020
            //}       //-0020
            //}       //-0020

            //con.CloseConnectionEx();
            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfCu.Rows.Count = 1;
            grfCu.Cols.Count = 11;
            //C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            //grfCu.Cols[colCuHn].Editor = txt;
            //grfCu.Cols[colCuVn1].Editor = txt;
            //grfCu.Cols[colCuName].Editor = txt;

            grfCu.Cols[colCuHnShow].Width = 100;
            grfCu.Cols[colCuVnShow].Width = 100;
            grfCu.Cols[colCuName].Width = 280;
            grfCu.Cols[colCuDate].Width = 100;
            grfCu.Cols[colCuTime].Width = 80;
            grfCu.Cols[colDept].Width = 120;
            //grfCu.Cols[colCuTime].Width = 80;

            grfCu.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfCu.Cols[colCuHnShow].Caption = "HN";
            grfCu.Cols[colCuVnShow].Caption = "VN";
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
                row[colCuVnShow] = ic.showVN(dt.Rows[i]["VN"].ToString());
                row[colCuHnShow] = ic.showHN( dt.Rows[i]["PIDS"].ToString(), dt.Rows[i]["patient_year"].ToString());
                row[colCuName] = dt.Rows[i]["PName"].ToString();
                row[colCuDate] =  ic.datetoShow(dt.Rows[i]["VDate"].ToString());
                row[colCuTime] = dt.Rows[i]["VStartTime"].ToString();
                row[colDept] = dt.Rows[i]["VName"].ToString();
                row[colDOb] = ic.datetoShow(dt.Rows[i]["dob"].ToString());
                row[colCuPttYear] = dt.Rows[i]["patient_year"].ToString();
                row[colCuPttHn] = dt.Rows[i]["patient_hn"].ToString();
                row[colCuVn] = dt.Rows[i]["VN"].ToString();
            }
            grfCu.Cols[colCuHnShow].AllowEditing = false;
            grfCu.Cols[colCuVnShow].AllowEditing = false;
            grfCu.Cols[colCuName].AllowEditing = false;
            grfCu.Cols[colCuDate].AllowEditing = false;
            grfCu.Cols[colCuTime].AllowEditing = false;
            grfCu.Cols[colDept].AllowEditing = false;
            grfCu.Cols[colDOb].Visible = false;
            grfCu.Cols[colCuPttYear].Visible = false;
            grfCu.Cols[colCuPttHn].Visible = false;
            grfCu.Cols[colCuVn].Visible = false;
        }
        private void FrmSearchHn_Load(object sender, EventArgs e)
        {
            tC1.SelectedTab = tabSearch;
            if (statussearchtable == StatusSearchTable.VisitSearch)
            {
                tC1.SelectedTab = tabSearch;
                txtHnMale.Focus();
            }
        }
    }
}
