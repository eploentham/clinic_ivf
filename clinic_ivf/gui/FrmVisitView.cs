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
    public partial class FrmVisitView : Form
    {
        IvfControl ic;
        MainMenu menu;

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;

        int colID=1, colVN = 2, colPttHn = 3, colPttName = 4, colVsDate = 5, colVsTime=6, colVsEtime=7, colStatus=8;

        C1FlexGrid grfPtt;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;

        public FrmVisitView(IvfControl ic, MainMenu m)
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

            sB1.Text = "";
            bg = txtSearch.BackColor;
            fc = txtSearch.ForeColor;
            ff = txtSearch.Font;

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();

            btnNew.Click += BtnNew_Click;
            txtSearch.KeyUp += TxtSearch_KeyUp;

            initGrfPtt();
            setGrfPtt("");
        }
        private void BtnNew_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            openPatientAdd("", "");
        }
        private void openPatientAdd(String pttId, String name)
        {
            FrmPatientAdd frm = new FrmPatientAdd(ic, pttId,"", "");
            String txt = "";
            if (!name.Equals(""))
            {
                txt = "ป้อน Patient " + name;
            }
            else
            {
                txt = "ป้อน Patient ใหม่ ";
            }

            frm.FormBorderStyle = FormBorderStyle.None;
            menu.AddNewTab(frm, txt);
        }
        private void TxtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.Enter)
            {
                setGrfPtt(txtSearch.Text);
            }
            else
            {
                if (txtSearch.Text.Length >= 2)
                {
                    setGrfPtt(txtSearch.Text);
                }
            }
        }

        private void initGrfPtt()
        {
            grfPtt = new C1FlexGrid();
            grfPtt.Font = fEdit;
            grfPtt.Dock = System.Windows.Forms.DockStyle.Fill;
            grfPtt.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            grfPtt.AfterRowColChange += GrfReq_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfPtt.ContextMenu = menuGw;
            gB.Controls.Add(grfPtt);

            theme1.SetTheme(grfPtt, "Office2010Blue");

        }
        private void GrfReq_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;
            String vn = "";

            //grfAddr.DataSource = xC.iniDB.addrDB.selectByTableId1(vn);
        }
        private void setGrfPtt(String search)
        {
            //grfDept.Rows.Count = 7;
            grfPtt.Clear();
            DataTable dt = new DataTable();
            if (search.Equals(""))
            {
                //String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
                dt = ic.ivfDB.vsOldDB.selectCurrentVisit();
            }
            else
            {
                //grfPtt.DataSource = ic.ivfDB.vsOldDB.selectCurrentVisit(search);
            }

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfPtt.Rows.Count = dt.Rows.Count+1;
            grfPtt.Cols.Count = 9;
            C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfPtt.Cols[colPttHn].Editor = txt;
            grfPtt.Cols[colPttName].Editor = txt;
            grfPtt.Cols[colVsDate].Editor = txt;

            grfPtt.Cols[colVN].Width = 120;
            grfPtt.Cols[colPttHn].Width = 120;
            grfPtt.Cols[colPttName].Width = 300;
            grfPtt.Cols[colVsDate].Width = 100;
            grfPtt.Cols[colVsTime].Width = 80;
            grfPtt.Cols[colVsEtime].Width = 80;
            grfPtt.Cols[colStatus].Width = 200;

            grfPtt.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfPtt.Cols[colVN].Caption = "VN";
            grfPtt.Cols[colPttHn].Caption = "HN";
            grfPtt.Cols[colPttName].Caption = "Name";
            grfPtt.Cols[colVsDate].Caption = "Date";
            grfPtt.Cols[colVsTime].Caption = "Time visit";
            grfPtt.Cols[colVsEtime].Caption = "Time finish";
            grfPtt.Cols[colStatus].Caption = "Status";

            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("&แก้ไข Patient", new EventHandler(ContextMenu_edit));
            grfPtt.ContextMenu = menuGw;

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            foreach(DataRow row in dt.Rows)
            {
                grfPtt[i, 0] = i;
                grfPtt[i, colID] = row["id"].ToString();
                grfPtt[i, colVN] = row["VN"].ToString();
                grfPtt[i, colPttHn] = row["PIDS"].ToString();
                grfPtt[i, colPttName] = row["PName"].ToString();
                grfPtt[i, colVsDate] = ic.datetoShow(row["VDate"]);
                grfPtt[i, colVsTime] = row["VStartTime"].ToString();
                grfPtt[i, colVsEtime] = row["VEndTime"].ToString();
                grfPtt[i, colStatus] = row["VName"].ToString();
                //if (i % 2 == 0)
                //    grfPtt.Rows[i].StyleNew.BackColor = color;
                i++;
            }
            grfPtt.Cols[colID].Visible = false;
            theme1.SetTheme(grfPtt, ic.theme);

        }
        private void ContextMenu_edit(object sender, System.EventArgs e)
        {
            String chk = "", name = "", id = "";
            id = grfPtt[grfPtt.Row, colVN] != null ? grfPtt[grfPtt.Row, colVN].ToString() : "";
            chk = grfPtt[grfPtt.Row, colPttHn] != null ? grfPtt[grfPtt.Row, colPttHn].ToString() : "";
            name = grfPtt[grfPtt.Row, colPttName] != null ? grfPtt[grfPtt.Row, colPttName].ToString() : "";
            //if (MessageBox.Show("ต้องการ แก้ไข Patient  \n  hn number " + chk + " \n name " + name, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            //grfReq.Rows.Remove(grfReq.Row);
            openPatientAdd(id, name);
            //}
        }
        private void FrmVisitView_Load(object sender, EventArgs e)
        {

        }
    }
}
