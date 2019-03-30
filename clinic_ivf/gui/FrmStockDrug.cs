using C1.Win.C1FlexGrid;
using C1.Win.C1SuperTooltip;
using C1.Win.C1Themes;
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
    public partial class FrmStockDrug : Form
    {
        IvfControl ic;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;
        int colID = 1, colName = 2, colPrice = 3, colQty = 4;
        int coldID = 1, coldName = 2, coldQty = 3;

        Boolean flagEdit = false;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        C1FlexGrid grfDrug;

        OldStockDrug sdrk;

        String userIdVoid = "";

        public FrmStockDrug(IvfControl x)
        {
            InitializeComponent();
            ic = x;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);

            C1ThemeController.ApplicationTheme = ic.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;
            theme1.SetTheme(sB, "BeigeOne");
            foreach (Control c in panel2.Controls)
            {
                theme1.SetTheme(c, "Office2013Red");
            }

            sB1.Text = "";
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();

            sdrk = new OldStockDrug();

            initGrfStockDrug();
            setGrfStockDrug();
        }
        private void setControl(String posiId)
        {
            sdrk = ic.ivfDB.oStkdDB.selectByPk1(posiId);
            txtID.Value = sdrk.DUID;
            txtDrgName.Value = sdrk.DUName;
            txtRemark.Value = sdrk.remark;
            //setGrfPkgD(txtID.Text);
        }
        private void setControlEnable(Boolean flag)
        {
            //txtID.Enabled = flag;
            txtDrgCode.Enabled = flag;
            txtDrgName.Enabled = flag;
            txtRemark.Enabled = flag;
            tC.Enabled = flag;
            //panel4.Enabled = flag;            
        }
        private void initGrfStockDrug()
        {
            grfDrug = new C1FlexGrid();
            grfDrug.Font = fEdit;
            grfDrug.Dock = System.Windows.Forms.DockStyle.Fill;
            grfDrug.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfPosi);

            grfDrug.AfterRowColChange += GrfPkg_AfterRowColChange;
            //grfAgn.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellButtonClick);
            //grfAgn.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellChanged);

            panel1.Controls.Add(this.grfDrug);

            C1Theme theme = C1ThemeController.GetThemeByName("Office2013Red", false);
            C1ThemeController.ApplyThemeToObject(grfDrug, theme);
        }
        private void GrfPkg_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;
            String id = "";
            id = grfDrug[grfDrug.Row, colID] != null ? grfDrug[grfDrug.Row, colID].ToString() : "";
            setControl(id);
        }
        private void setGrfStockDrug()
        {
            //grfDept.Rows.Count = 7;

            grfDrug.DataSource = ic.ivfDB.oStkdDB.selectAll1();
            grfDrug.Cols.Count = 5;

            grfDrug.Cols[colID].Width = 80;

            grfDrug.Cols[colPrice].Width = 80;
            grfDrug.Cols[colName].Width = 440;

            grfDrug.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfDrug.Cols[colID].Caption = "รหัส";
            grfDrug.Cols[colName].Caption = "ชื่อPackage";
            grfDrug.Cols[colPrice].Caption = "ราคา";

            for (int i = 1; i < grfDrug.Rows.Count; i++)
            {
                //Decimal price = 0;
                //Decimal.TryParse(grfPkg.Rows[i][colPrice].ToString(), out price);
                //grfPkg.Rows[i][colQty] = price.ToString("#,###.00");
                grfDrug[i, 0] = i;
                if (i % 2 == 0)
                    grfDrug.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            }
            grfDrug.Cols[colID].Visible = false;
            grfDrug.Cols[colQty].Visible = false;
            //grfAgn.Cols[colS].Visible = false;
            //grfAgn.Cols[colRemark].Visible = false;
        }
        private void FrmStockDrug_Load(object sender, EventArgs e)
        {

        }
    }
}
