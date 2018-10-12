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
    public partial class FrmLabReqAccept : Form
    {
        IvfControl ic;
        MainMenu menu;

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;
        int colRqId = 1, colRqReqNum = 2, colRqHn = 3, colRqVn = 4, colRqName = 5, colRqDate = 6, colRqRemark = 7;

        C1FlexGrid grfReq;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;

        public FrmLabReqAccept(IvfControl ic, MainMenu m)
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
            bg = txtHn.BackColor;
            fc = txtHn.ForeColor;
            ff = txtHn.Font;

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();

            //btnNew.Click += BtnNew_Click;

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
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("&รับ request", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfReq.ContextMenu = menuGw;
            gB.Controls.Add(grfReq);

            theme1.SetTheme(grfReq, "Office2010Blue");
        }
        private void ContextMenu_edit(object sender, System.EventArgs e)
        {
            String chk = "", name = "", id = "";
            id = grfReq[grfReq.Row, colRqId] != null ? grfReq[grfReq.Row, colRqId].ToString() : "";
            chk = grfReq[grfReq.Row, colRqReqNum] != null ? grfReq[grfReq.Row, colRqReqNum].ToString() : "";
            name = grfReq[grfReq.Row, colRqName] != null ? grfReq[grfReq.Row, colRqName].ToString() : "";
            if (MessageBox.Show("ต้องการ รับ request  \n  req number " + chk + " \n name " + name, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                //grfReq.Rows.Remove(grfReq.Row);
                openLabOPUAdd(id, name);
            }
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
            //grfDept.Rows.Count = 7;
            grfReq.Clear();
            DataTable dt = new DataTable();

            grfReq.DataSource = ic.ivfDB.lbReqDB.selectByReq1();
            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            //grfCu.Rows.Count = 41;
            //grfCu.Cols.Count = 4;
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
            //grfReq.Cols[colCuTime].Width = 80;

            grfReq.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfReq.Cols[colRqReqNum].Caption = "req number";
            grfReq.Cols[colRqHn].Caption = "HN";
            grfReq.Cols[colRqVn].Caption = "VN";
            grfReq.Cols[colRqName].Caption = "Name";
            grfReq.Cols[colRqDate].Caption = "Date";
            grfReq.Cols[colRqRemark].Caption = "Remark";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            for (int i = 1; i <= grfReq.Rows.Count - 1; i++)
            {
                grfReq[i, 0] = i;
            }
            grfReq.Cols[colRqId].Visible = false;
        }
        private void openLabOPUAdd(String reqId, String name)
        {
            FrmLabOPUAdd frm = new FrmLabOPUAdd(ic, reqId);
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
        private void FrmLabReqAccept_Load(object sender, EventArgs e)
        {

        }
    }
}
