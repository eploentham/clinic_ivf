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
    public partial class FrmPharmaPttView : Form
    {
        IvfControl ic;
        MainMenu menu;

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;

        C1FlexGrid grfPtt;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        ContextMenu menuGw;

        int colVN = 1, colHn = 2, colName = 3, colVsDate = 4, colStatus = 5;

        public FrmPharmaPttView(IvfControl ic, MainMenu m)
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
            txtStartDate.Value = DateTime.Now;
            txtEndDate.Value = DateTime.Now;

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            chkHn.Checked = false;
            chkVisit.Checked = true;

            btnSerach.Click += BtnSerach_Click;

            initGrfPtt();
            
        }

        private void BtnSerach_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setGrfPttHn();
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

            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));

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
        private void setGrfPttHn()
        {
            //grfDept.Rows.Count = 7;
            grfPtt.Clear();
            grfPtt.DataSource = null;
            grfPtt.Cols.Count = 6;
            grfPtt.Rows.Count = 1;
            try
            {
                String startDate = "", endDate = "";
                DateTime dtStart = new DateTime();
                DateTime dtEnd = new DateTime();
                dtStart = (DateTime)txtStartDate.Value;
                dtEnd = (DateTime)txtEndDate.Value;
                DataTable dt = new DataTable();
                startDate = dtStart.Year + "-" + dtStart.ToString("MM-dd");
                endDate = dtEnd.Year + "-" + dtEnd.ToString("MM-dd");
                dt = ic.ivfDB.oJobpxDB.selectByDate(startDate, endDate, txtSearch.Text);
                //grfExpn.Rows.Count = dt.Rows.Count + 1;
                //grfCu.Rows.Count = 41;
                //grfCu.Cols.Count = 4;
                C1TextBox txt = new C1TextBox();
                //C1ComboBox cboproce = new C1ComboBox();
                //ic.ivfDB.itmDB.setCboItem(cboproce);
                grfPtt.Cols[colVN].Editor = txt;
                grfPtt.Cols[colHn].Editor = txt;
                grfPtt.Cols[colName].Editor = txt;
                grfPtt.Cols[colVsDate].Editor = txt;
                grfPtt.Cols[colStatus].Editor = txt;

                grfPtt.Cols[colVN].Width = 120;
                grfPtt.Cols[colHn].Width = 120;
                grfPtt.Cols[colName].Width = 300;
                grfPtt.Cols[colVsDate].Width = 120;
                grfPtt.Cols[colStatus].Width = 50;

                grfPtt.ShowCursor = true;
                //grdFlex.Cols[colID].Caption = "no";
                //grfDept.Cols[colCode].Caption = "รหัส";

                grfPtt.Cols[colVN].Caption = "VN";
                grfPtt.Cols[colHn].Caption = "HN";
                grfPtt.Cols[colName].Caption = "Name";
                grfPtt.Cols[colVsDate].Caption = "Date";
                grfPtt.Cols[colStatus].Caption = "Status";

                menuGw = new ContextMenu();
                menuGw.MenuItems.Add("&พิมพ์ Sticker", new EventHandler(ContextMenu_edit));
                grfPtt.ContextMenu = menuGw;

                Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
                //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
                //rg1.Style = grfBank.Styles["date"];
                //grfCu.Cols[colID].Visible = false;
                int i = 1;
                foreach (DataRow row in dt.Rows)
                {
                    Row row1 = grfPtt.Rows.Add();
                    row1[0] = i;
                    row1[colVN] = row["VN"].ToString();
                    row1[colHn] = row["PIDS"].ToString();
                    row1[colName] = row["name"].ToString();
                    row1[colVsDate] = ic.datetoShow(row["Date"].ToString());
                    row1[colStatus] = row["Status"].ToString();
                    if (i % 2 == 0)
                        grfPtt.Rows[i].StyleNew.BackColor = color;
                    i++;
                }
                //grfPtt.Cols[colVN].Visible = false;
                theme1.SetTheme(grfPtt, ic.theme);
            }
            catch (Exception ex)
            {
                MessageBox.Show(""+ex.Message, "Error");
            }
        }
        private void ContextMenu_edit(object sender, System.EventArgs e)
        {
            String hn = "", name = "", pttid = "", vn = "";
            //pttid = grfPtt[grfPtt.Row, colPttId] != null ? grfPtt[grfPtt.Row, colPttId].ToString() : "";
            vn = grfPtt[grfPtt.Row, colVN] != null ? grfPtt[grfPtt.Row, colVN].ToString() : "";
            hn = grfPtt[grfPtt.Row, colHn] != null ? grfPtt[grfPtt.Row, colHn].ToString() : "";
            name = grfPtt[grfPtt.Row, colName] != null ? grfPtt[grfPtt.Row, colName].ToString() : "";

            //if (MessageBox.Show("ต้องการ แก้ไข Patient  \n  hn number " + chk + " \n name " + name, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            //grfReq.Rows.Remove(grfReq.Row);
            //VisitAdd(pttid, vn, name, pttid);
            //}
            String date = "", date1 = "";
            date = DateTime.Now.Year + "-" + DateTime.Now.ToString("MM-dd");
            DataTable dt = new DataTable();
            date = "2018-11-05";
            date1 = "05-11-2018";
            dt = ic.ivfDB.jobpxdDB.selectByVN(vn);
            //if (dt.Rows.Count <= 0) return;

            FrmReport frm = new FrmReport(ic);
            frm.setStickerDrugReport(date, dt);
            frm.ShowDialog(this);
        }
        private void FrmPharmaPttView_Load(object sender, EventArgs e)
        {
            setGrfPttHn();
        }
    }
}
