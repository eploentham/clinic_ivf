using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1SuperTooltip;
using C1.Win.C1Themes;
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
    public partial class FrmLabFetAdd : Form
    {
        IvfControl ic;
        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;
        int colID = 1, colNum = 2, colDesc = 3;

        C1FlexGrid grfDay3, grfDay5;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        //objdb.LabProcedureDB.StatusLab statusLab;

        public FrmLabFetAdd(IvfControl ic)
        {
            InitializeComponent();
            this.ic = ic;
            
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);

            C1ThemeController.ApplicationTheme = ic.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;
            theme1.SetTheme(sB, "BeigeOne");

            sB1.Text = "";

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            //stt.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.Gold;
            ic.ivfDB.proceDB.setCboLabProce(cboFetProce, objdb.LabProcedureDB.StatusLab.FETProcedure);

            initGrfDay3();
            initGrfDay5();
            //initGrfDay6();
            setGrfDay3();
            setGrfDay5();
            //setGrfDay6();
        }
        private void initGrfDay3()
        {
            grfDay3 = new C1FlexGrid();
            grfDay3.Font = fEdit;
            grfDay3.Dock = System.Windows.Forms.DockStyle.Fill;
            grfDay3.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            //grfExpn.AfterRowColChange += GrfExpn_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfDay3.ContextMenu = menuGw;
            gbDay3.Controls.Add(grfDay3);

            theme1.SetTheme(grfDay3, "Office2010Blue");
        }
        private void initGrfDay5()
        {
            grfDay5 = new C1FlexGrid();
            grfDay5.Font = fEdit;
            grfDay5.Dock = System.Windows.Forms.DockStyle.Fill;
            grfDay5.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            //grfExpn.AfterRowColChange += GrfExpn_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfDay5.ContextMenu = menuGw;
            gbDay5.Controls.Add(grfDay5);

            theme1.SetTheme(grfDay5, "Office2010Silver");
        }
        private void setGrfDay3()
        {
            //grfDept.Rows.Count = 7;
            grfDay3.Clear();
            DataTable dt = new DataTable();

            //grfExpn.DataSource = xC.xtDB.expndDB.selectAll1(cboYear.Text);
            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfDay3.Rows.Count = 30;
            grfDay3.Cols.Count = 4;
            C1TextBox txt = new C1TextBox();
            //txt.dat

            grfDay3.Cols[colID].Editor = txt;
            grfDay3.Cols[colNum].Editor = txt;
            grfDay3.Cols[colDesc].Editor = txt;

            grfDay3.Cols[colNum].Width = 40;
            grfDay3.Cols[colDesc].Width = 150;

            grfDay3.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfDay3.Cols[colNum].Caption = "no";
            grfDay3.Cols[colDesc].Caption = "desc";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            grfDay3.Cols[colID].Visible = false;

        }
        private void setGrfDay5()
        {
            //grfDept.Rows.Count = 7;
            grfDay5.Clear();
            DataTable dt = new DataTable();

            //grfExpn.DataSource = xC.xtDB.expndDB.selectAll1(cboYear.Text);
            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfDay5.Rows.Count = 30;
            grfDay5.Cols.Count = 4;
            C1TextBox txt = new C1TextBox();
            //txt.dat

            grfDay5.Cols[colID].Editor = txt;
            grfDay5.Cols[colNum].Editor = txt;
            grfDay5.Cols[colDesc].Editor = txt;

            grfDay5.Cols[colNum].Width = 40;
            grfDay5.Cols[colDesc].Width = 150;

            grfDay5.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfDay5.Cols[colNum].Caption = "no";
            grfDay5.Cols[colDesc].Caption = "desc";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            grfDay5.Cols[colID].Visible = false;

        }
        private void FrmLabFetAdd_Load(object sender, EventArgs e)
        {
            spMain.Panel1MinSize = 120;
            spMain.SplitterDistance = 120;
        }
    }
}
