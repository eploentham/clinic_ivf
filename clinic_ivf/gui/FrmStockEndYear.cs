using C1.C1Excel;
using C1.Win.C1Command;
using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1Themes;
using clinic_ivf.control;
using clinic_ivf.FlexGrid;
using clinic_ivf.object1;
using System;
using System.Collections.Generic;
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
    public class FrmStockEndYear:Form
    {
        IvfControl ic;
        C1FlexGrid grf2019;
        Font fEdit, fEditB;
        Color bg, fc;
        Boolean pageLoad = false;
        Panel pnTop, pnBody;
        C1ThemeController theme1;
        C1Button btnNew, btnSave;
        C1DockingTab tC1;
        C1DockingTabPage tab2019;
        //C1DockingTabPage tabOnhand;

        Label lbYear, lbStkSubName;
        C1ComboBox cboYear, cboStkSubName;
        MainMenu menu;
        int colStkId = 1, colStkName = 2, colStkOnhand = 3, colStkUnit=4, colStkStatus = 5, colStkRemark = 6;
        
        public FrmStockEndYear(IvfControl ic, MainMenu m)
        {
            this.ic = ic;
            menu = m;
            InitComponent();
            initConfig();
        }
        private void InitComponent()
        {
            int gapY = 30, gapX = 20, gapLine = 5, gapColName = 70;
            Size size = new Size();

            theme1 = new C1ThemeController();
            theme1.Theme = ic.iniC.themeApplication;
            pnTop = new Panel();
            pnTop.Dock = DockStyle.Top;
            pnTop.Size = new Size(20, 60);
            pnBody = new Panel();
            pnBody.Dock = DockStyle.Fill;
            pnTop.SuspendLayout();
            pnBody.SuspendLayout();
            this.SuspendLayout();

            lbYear = new Label();
            lbYear.Text = "Year :";
            lbYear.Font = fEdit;
            lbYear.Location = new System.Drawing.Point(gapX, gapLine);
            lbYear.AutoSize = true;
            lbYear.Name = "lbYear";
            size = ic.MeasureString(lbYear);
            cboYear = new C1ComboBox();
            cboYear.AllowSpinLoop = false;
            cboYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            cboYear.Font = fEdit;
            cboYear.GapHeight = 0;
            cboYear.ImagePadding = new System.Windows.Forms.Padding(0);
            cboYear.ItemsDisplayMember = "";
            cboYear.ItemsValueMember = "";
            cboYear.Location = new System.Drawing.Point(size.Width + 20, lbYear.Location.Y);
            cboYear.Name = "cboYear";
            cboYear.Size = new System.Drawing.Size(184, 20);
            cboYear.TabIndex = 562;
            cboYear.Tag = null;
            theme1.SetTheme(cboYear, "(default)");
            cboYear.VisualStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            cboYear.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            cboYear.Location = new Point(gapColName, lbYear.Location.Y);

            btnNew = new C1Button();
            btnNew.Name = "btnNew";
            btnNew.Text = "New 2019";
            btnNew.Font = this.fEdit;
            size = ic.MeasureString(btnNew);
            btnNew.Size = new Size(100, 40);
            btnNew.Location = new Point(cboYear.Location.X + cboYear.Width + 40, lbYear.Location.Y);
            btnNew.Click += BtnNew_Click;

            btnSave = new C1Button();
            btnSave.Name = "btnSave";
            btnSave.Text = "Save 2019";
            btnSave.Font = this.fEdit;
            size = ic.MeasureString(btnSave);
            btnSave.Size = new Size(100, 40);
            btnSave.Location = new Point(btnNew.Location.X + btnNew.Width + 40, lbYear.Location.Y);
            btnSave.Click += BtnSave_Click;

            tC1 = new C1DockingTab();
            tC1.Dock = System.Windows.Forms.DockStyle.Fill;
            tC1.HotTrack = true;
            tC1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            tC1.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Fit;
            tC1.TabsShowFocusCues = true;
            tC1.Alignment = TabAlignment.Top;
            tC1.SelectedTabBold = true;
            tC1.Name = "tC1";
            tC1.CanCloseTabs = true;

            tab2019 = new C1DockingTabPage();
            tC1.SuspendLayout();
            tab2019.SuspendLayout();

            tab2019.Name = "tabOnhand";
            tab2019.TabIndex = 0;
            tab2019.Text = "Onhand";
            theme1.SetTheme(tC1, ic.theme);

            pnTop.Controls.Add(lbYear);
            pnTop.Controls.Add(cboYear);
            pnTop.Controls.Add(lbStkSubName);
            //pnTop.Controls.Add(cboStkSubName);
            pnTop.Controls.Add(btnNew);
            pnTop.Controls.Add(btnSave);
            this.Controls.Add(pnBody);
            this.Controls.Add(pnTop);
            tC1.Controls.Add(tab2019);
            pnBody.Controls.Add(tC1);
            theme1.SetTheme(pnBody, ic.iniC.themeApp);
            theme1.SetTheme(pnTop, "Office2010Red");

            pnTop.ResumeLayout(false);
            pnBody.ResumeLayout(false);
            tC1.ResumeLayout(false);
            tab2019.ResumeLayout(false);
            this.ResumeLayout(false);
            pnBody.PerformLayout();
            pnTop.PerformLayout();
            tC1.PerformLayout();
            tab2019.PerformLayout();
            this.PerformLayout();
        }
        private void initConfig()
        {
            pageLoad = true;
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);
            ic.setCboYear(cboYear);
            initGrfStk();
            cboYear.SelectedIndexChanged += CboYear_SelectedIndexChanged;
            pageLoad = false;
        }

        private void CboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setGrf2019();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.ivfDB.stkeDB.DeleteAll("");
            foreach(Row row in grf2019.Rows)
            {
                if (row[colStkStatus] == null) continue;
                if (row[colStkStatus].ToString().Equals("onhand"))
                {
                    StockCardEndYear stke = new StockCardEndYear();
                    stke.stock_endyear_id = "";
                    stke.year_id = "2019";
                    stke.item_id = row[colStkId].ToString();

                    stke.unit_name = row[colStkUnit] != null ? row[colStkUnit].ToString() : "";
                    stke.onhand = row[colStkOnhand] != null ? row[colStkOnhand].ToString(): "0";
                    stke.active = "1";
                    stke.remark = row[colStkRemark] != null ? row[colStkRemark].ToString() : "";
                    String re = ic.ivfDB.stkeDB.insertStockCardEndYear(stke, "");
                    long chk = 0;
                }
            }
        }
        private void BtnNew_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setGrf2019New();
        }
        
        private void initGrfStk()
        {
            grf2019 = new C1FlexGrid();
            grf2019.Font = fEdit;
            grf2019.Dock = System.Windows.Forms.DockStyle.Fill;
            grf2019.Location = new System.Drawing.Point(0, 0);
            grf2019.Rows.Count = 1;

            //FilterRow2 fr = new FilterRow2(grfBloodLab);

            grf2019.DoubleClick += Grf2019_DoubleClick;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("Export Excel", new EventHandler(ContextMenu_export_grf2019));
            //if (flagedit.Equals("edit"))
            //{
            //    menuGw.MenuItems.Add("สั่งการ", new EventHandler(ContextMenu_order_bl_set));
            //}

            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grf2019.ContextMenu = menuGw;
            tab2019.Controls.Add(grf2019);

            theme1.SetTheme(grf2019, "Office2010Red");

        }

        private void Grf2019_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grf2019.Row < 0) return;
            if (grf2019.Col < 0) return;

            if(grf2019[grf2019.Row, colStkStatus].Equals("onhand"))
            {
                grf2019[grf2019.Row, colStkStatus] = "NO";
            }
            else
            {
                grf2019[grf2019.Row, colStkStatus] = "onhand";
            }
        }
        private void setGrf2019()
        {
            //grfDept.Rows.Count = 7;
            //grf2019.Clear();
            grf2019.Rows.Count = 1;
            DataTable dt = new DataTable();
            dt = ic.ivfDB.stkeDB.selectByYear(cboYear.Text);
            //grfBloodLab.Rows.Count = dt.Rows.Count + 1;
            grf2019.Rows.Count = dt.Rows.Count + 1;
            //grfBloodLab.DataSource = dt;
            grf2019.Cols.Count = 7;

            //CellStyle cs = grf2019.Styles.Add("bool");
            //cs.DataType = typeof(bool);
            //cs.ImageAlign = ImageAlignEnum.LeftCenter;

            grf2019.Cols[colStkName].Width = 330;
            grf2019.Cols[colStkOnhand].Width = 80;
            grf2019.Cols[colStkStatus].Width = 80;
            grf2019.Cols[colStkRemark].Width = 80;
            grf2019.Cols[colStkUnit].Width = 80;

            grf2019.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            //CellRange rg = grf2019.GetCellRange(2, colName, grf2019.Rows.Count - 1, colPrice);
            //rg.Style = cs;
            //rg.Style = grf2019.Styles["bool"];
            for (int col = 0; col < dt.Columns.Count; ++col)
            {
                grf2019.Cols[col + 1].DataType = dt.Columns[col].DataType;
                grf2019.Cols[col + 1].Caption = dt.Columns[col].ColumnName;
                grf2019.Cols[col + 1].Name = dt.Columns[col].ColumnName;
            }
            grf2019.Cols[colStkName].Caption = "Name";
            grf2019.Cols[colStkOnhand].Caption = "On Hand";
            grf2019.Cols[colStkStatus].Caption = "Status";
            grf2019.Cols[colStkRemark].Caption = "หมายเหตุ";
            grf2019.Cols[colStkUnit].Caption = "unit";
            int i = 0;
            decimal aaa = 0;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    i++;
                    if (i == 1) continue;
                    //if (i == 2) continue;
                    grf2019[i, 0] = (i - 1);
                    //Decimal.TryParse(row[ic.ivfDB.oStkdDB.ostkD.Price].ToString(), out aaa);
                    grf2019[i, colStkName] = row["DUName"].ToString();
                    grf2019[i, colStkId] = row[ic.ivfDB.stkeDB.stkc.item_id].ToString();
                    grf2019[i, colStkOnhand] = row[ic.ivfDB.stkeDB.stkc.onhand].ToString();
                    grf2019[i, colStkUnit] = row[ic.ivfDB.stkeDB.stkc.unit_name].ToString();
                    grf2019[i, colStkStatus] = "onhand";
                    grf2019[i, colStkRemark] = row[ic.ivfDB.stkeDB.stkc.remark].ToString();

                }
                catch (Exception ex)
                {
                    String err = "";
                }
            }
            CellNoteManager mgr = new CellNoteManager(grf2019);
            grf2019.Cols[colStkId].Visible = false;
            //grfBloodLab.Cols[colBlInclude].Visible = false;
            //grfBloodLab.Cols[colBlPrice].Visible = false;

            grf2019.Cols[colStkName].AllowEditing = false;
            grf2019.Cols[colStkStatus].AllowEditing = false;

            FilterRow fr = new FilterRow(grf2019);
            grf2019.AllowFiltering = true;
            grf2019.AfterFilter += Grf2019_AfterFilter;
            //theme1.SetTheme(grfFinish, ic.theme);

        }
        private void setGrf2019New()
        {
            //grfDept.Rows.Count = 7;
            //grf2019.Clear();
            grf2019.Rows.Count = 1;
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oStkdDB.selectAllOnhand();
            //grfBloodLab.Rows.Count = dt.Rows.Count + 1;
            grf2019.Rows.Count = dt.Rows.Count + 1;
            //grfBloodLab.DataSource = dt;
            grf2019.Cols.Count = 7;

            //CellStyle cs = grf2019.Styles.Add("bool");
            //cs.DataType = typeof(bool);
            //cs.ImageAlign = ImageAlignEnum.LeftCenter;

            grf2019.Cols[colStkName].Width = 330;
            grf2019.Cols[colStkOnhand].Width = 80;
            grf2019.Cols[colStkStatus].Width = 80;
            grf2019.Cols[colStkRemark].Width = 80;
            grf2019.Cols[colStkUnit].Width = 80;

            grf2019.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            //CellRange rg = grf2019.GetCellRange(2, colName, grf2019.Rows.Count - 1, colPrice);
            //rg.Style = cs;
            //rg.Style = grf2019.Styles["bool"];
            for (int col = 0; col < dt.Columns.Count; ++col)
            {
                grf2019.Cols[col + 1].DataType = dt.Columns[col].DataType;
                grf2019.Cols[col + 1].Caption = dt.Columns[col].ColumnName;
                grf2019.Cols[col + 1].Name = dt.Columns[col].ColumnName;
            }
            grf2019.Cols[colStkName].Caption = "Name";
            grf2019.Cols[colStkOnhand].Caption = "On Hand";
            grf2019.Cols[colStkStatus].Caption = "Status";
            grf2019.Cols[colStkRemark].Caption = "หมายเหตุ";
            grf2019.Cols[colStkUnit].Caption = "unit";

            int i = 0;
            decimal aaa = 0;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    i++;
                    if (i == 1) continue;
                    //if (i == 2) continue;
                    grf2019[i, 0] = (i - 1);
                    //Decimal.TryParse(row[ic.ivfDB.oStkdDB.ostkD.Price].ToString(), out aaa);
                    grf2019[i, colStkName] = row[ic.ivfDB.oStkdDB.ostkD.DUName].ToString();
                    grf2019[i, colStkId] = row[ic.ivfDB.oStkdDB.ostkD.DUID].ToString();
                    grf2019[i, colStkOnhand] = row[ic.ivfDB.oStkdDB.ostkD.on_hand].ToString();
                    grf2019[i, colStkUnit] = row[ic.ivfDB.oStkdDB.ostkD.UnitType].ToString();
                    grf2019[i, colStkStatus] = "onhand";
                    grf2019[i, colStkRemark] = "";

                }
                catch (Exception ex)
                {
                    String err = "";
                }
            }
            CellNoteManager mgr = new CellNoteManager(grf2019);
            grf2019.Cols[colStkId].Visible = false;
            //grfBloodLab.Cols[colBlInclude].Visible = false;
            //grfBloodLab.Cols[colBlPrice].Visible = false;

            grf2019.Cols[colStkName].AllowEditing = false;
            grf2019.Cols[colStkStatus].AllowEditing = false;

            FilterRow fr = new FilterRow(grf2019);
            grf2019.AllowFiltering = true;
            grf2019.AfterFilter += Grf2019_AfterFilter;
            //theme1.SetTheme(grfFinish, ic.theme);

        }

        private void Grf2019_AfterFilter(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            for (int col = grf2019.Cols.Fixed; col < grf2019.Cols.Count; ++col)
            {
                var filter = grf2019.Cols[col].ActiveFilter;
            }
        }

        private void ContextMenu_export_grf2019(object sender, System.EventArgs e)
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
            XLSheet sheet = _book.Sheets.Add("stockendyear" + DateTime.Now.ToString("dd-MM-") + DateTime.Now.Year.ToString());

            ic.SaveSheet(grf2019, sheet, _book, false);

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
    }
}
