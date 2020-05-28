using C1.C1Excel;
using C1.Win.C1FlexGrid;
using C1.Win.C1SuperTooltip;
using clinic_ivf.control;
using clinic_ivf.FlexGrid;
using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.gui
{
    public partial class FrmStockOnhand : Form
    {
        IvfControl ic;
        C1FlexGrid grfStk;

        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;
        Image imgCorr, imgTran;
        Color color;

        int colId = 1, colName = 2, colOnhand = 4, colUnit=3, colOrderPoint = 5, colOrderAmount = 6, colPrice = 7;
        Boolean pageLoad = false;
        public FrmStockOnhand(IvfControl ic)
        {
            InitializeComponent();
            this.ic = ic;
            initConfig();

            setGrfStk("");
        }
        private void initConfig()
        {
            pageLoad = true;
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);

            //C1ThemeController.ApplicationTheme = ic.iniC.themeApplication;
            theme1.Theme = ic.iniC.themeApplication;
            theme1.SetTheme(sB, "BeigeOne");
            cboStkSubName.SelectedIndexChanged += CboStkSubName_SelectedIndexChanged;

            ic.ivfDB.stknDB.setCboStockSubName(cboStkSubName);
            cboStkSubName.SelectedIndex = 0;
            initGrfStk();

            sB1.Text = "";
            pageLoad = false;
        }

        private void CboStkSubName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (pageLoad) return;
            String col = cboStkSubName.SelectedItem == null ? "" : ((ComboBoxItem)cboStkSubName.SelectedItem).Value;
            StockSubName stkn = new StockSubName();
            stkn = ic.ivfDB.stknDB.selectByPk(col);
            setGrfStk(stkn.stock_sub_column_name);
        }

        private void initGrfStk()
        {
            grfStk = new C1FlexGrid();
            grfStk.Font = fEdit;
            grfStk.Dock = System.Windows.Forms.DockStyle.Fill;
            grfStk.Location = new System.Drawing.Point(0, 0);

            //FilterRow2 fr = new FilterRow2(grfBloodLab);

            grfStk.DoubleClick += GrfStk_DoubleClick;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("Export Excel", new EventHandler(ContextMenu_export_grfstk));
            //if (flagedit.Equals("edit"))
            //{
            //    menuGw.MenuItems.Add("สั่งการ", new EventHandler(ContextMenu_order_bl_set));
            //}

            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfStk.ContextMenu = menuGw;
            pnStock.Controls.Add(grfStk);

            theme1.SetTheme(grfStk, "Office2010Red");

        }
        private void ContextMenu_export_grfstk(object sender, System.EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.DefaultExt = "xls";
            dlg.Filter = "Excel |*.xls";
            dlg.InitialDirectory = ic.iniC.pathSaveExcelAppointment;
            dlg.FileName = "*.xls";
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            // clear book
            C1XLBook _book = new C1XLBook();
            XLSheet sheet = _book.Sheets.Add("stock" + DateTime.Now.ToString("dd-MM-") + DateTime.Now.Year.ToString());

            ic.SaveSheet(grfStk, sheet, _book, false);

            _book.Sheets.SelectedIndex = 0;
            // save the book
            _book.Save(dlg.FileName);
            if (File.Exists(dlg.FileName))
            {
                //Process p = new Process();
                //p.StartInfo.FileName = dlg.FileName;
                //p.Start();
                string argument = "/select, \"" + dlg.FileName + "\"";
                Process.Start("explorer.exe", argument);
            }
        }
        private void setGrfStk(String column)
        {
            //grfDept.Rows.Count = 7;
            grfStk.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oStkdDB.selectAll2(column);
            //grfBloodLab.Rows.Count = dt.Rows.Count + 1;
            grfStk.Rows.Count = dt.Rows.Count + 1;
            //grfBloodLab.DataSource = dt;
            grfStk.Cols.Count = 8;

            //CellStyle cs = grfStk.Styles.Add("bool");
            //cs.DataType = typeof(bool);
            //cs.ImageAlign = ImageAlignEnum.LeftCenter;

            grfStk.Cols[colName].Width = 330;
            grfStk.Cols[colUnit].Width = 80;
            grfStk.Cols[colOrderPoint].Width = 80;
            grfStk.Cols[colOnhand].Width = 80;
            grfStk.Cols[colOrderPoint].Width = 80;
            grfStk.Cols[colOrderAmount].Width = 80;

            grfStk.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            //CellRange rg = grfStk.GetCellRange(2, colName, grfStk.Rows.Count - 1, colPrice);
            //rg.Style = cs;
            //rg.Style = grfStk.Styles["bool"];
            for (int col = 0; col < dt.Columns.Count; ++col)
            {
                grfStk.Cols[col + 1].DataType = dt.Columns[col].DataType;
                grfStk.Cols[col + 1].Caption = dt.Columns[col].ColumnName;
                grfStk.Cols[col + 1].Name = dt.Columns[col].ColumnName;
            }
            grfStk.Cols[colName].Caption = "Name";
            grfStk.Cols[colUnit].Caption = "Unit";
            grfStk.Cols[colOnhand].Caption = "On Hand";
            grfStk.Cols[colOrderPoint].Caption = "จุดสั่งซื้อ";
            grfStk.Cols[colOrderAmount].Caption = "จำนวนสั่งซื้อ";
            grfStk.Cols[colPrice].Caption = "Price";
            int i = 0;
            decimal aaa = 0;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    i++;
                    if (i == 1) continue;

                    Decimal.TryParse(row[ic.ivfDB.oStkdDB.ostkD.Price].ToString(), out aaa);
                    grfStk[i, colPrice] = aaa.ToString("#,##0");
                    grfStk[i, colId] = row[ic.ivfDB.oStkdDB.ostkD.DUID].ToString();
                    grfStk[i, colName] = row[ic.ivfDB.oStkdDB.ostkD.DUName].ToString();
                    grfStk[i, colUnit] = row[ic.ivfDB.oStkdDB.ostkD.UnitType].ToString();
                    grfStk[i, colOrderPoint] = row[ic.ivfDB.oStkdDB.ostkD.order_point + column].ToString();
                    grfStk[i, colOrderAmount] = row[ic.ivfDB.oStkdDB.ostkD.order_amount + column].ToString();
                    grfStk[i, colOnhand] = row[ic.ivfDB.oStkdDB.ostkD.on_hand + column].ToString();

                }
                catch (Exception ex)
                {
                    String err = "";
                }
            }
            CellNoteManager mgr = new CellNoteManager(grfStk);
            grfStk.Cols[colId].Visible = false;
            //grfBloodLab.Cols[colBlInclude].Visible = false;
            //grfBloodLab.Cols[colBlPrice].Visible = false;

            grfStk.Cols[colName].AllowEditing = false;
            grfStk.Cols[colOrderPoint].AllowEditing = false;
            grfStk.Cols[colOrderAmount].AllowEditing = false;
            grfStk.Cols[colOnhand].AllowEditing = false;

            FilterRow fr = new FilterRow(grfStk);
            grfStk.AllowFiltering = true;
            grfStk.AfterFilter += GrfStk_AfterFilter;
            //theme1.SetTheme(grfFinish, ic.theme);

        }

        private void GrfStk_AfterFilter(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            for (int col = grfStk.Cols.Fixed; col < grfStk.Cols.Count; ++col)
            {
                var filter = grfStk.Cols[col].ActiveFilter;
            }
        }

        private void GrfStk_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

        }

        private void FrmStockOnhand_Load(object sender, EventArgs e)
        {
            //ic.setC1Combo(cboStkSubName, "");
        }
    }
}
