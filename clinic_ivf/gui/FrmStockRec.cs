using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1SuperTooltip;
using clinic_ivf.control;
using clinic_ivf.object1;
using clinic_ivf.Properties;
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
    public partial class FrmStockRec : Form
    {
        IvfControl ic;
        C1FlexGrid grfStk;
        StockRec stkr;

        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;
        Image imgCorr, imgTran;
        Color color;

        int colId = 1, colName = 2, colQty = 4, colUnit = 3, colLotNo = 7, colExpDate = 6, colPrice = 5, colAmt = 8;
        Boolean pageLoad = false;
        List<OldStockDrug> lstkD;
        public FrmStockRec(IvfControl ic)
        {
            InitializeComponent();
            this.ic = ic;
            initConfig();
        }
        private void initConfig()
        {
            pageLoad = true;
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);

            //C1ThemeController.ApplicationTheme = ic.iniC.themeApplication;
            stkr = new StockRec();
            theme1.Theme = ic.iniC.themeApplication;
            theme1.SetTheme(sB, "BeigeOne");
            cboStkSubName.SelectedIndexChanged += CboStkSubName_SelectedIndexChanged;
            btnSave.Click += BtnSave_Click;

            ic.ivfDB.stknDB.setCboStockSubName(cboStkSubName);
            cboStkSubName.SelectedIndex = 0;
            initGrfStk();
            setGrfStockRec("");
            sB1.Text = "";
            lstkD = ic.ivfDB.oStkdDB.getlStf();
            pageLoad = false;
        }
        private void setStockDrug()
        {
            stkr.rec_id = "";
            stkr.rec_doc = "";
            stkr.inv_ex = "";
            stkr.description = "";
            stkr.rec_date = ic.datetoDB(txtRecDate.Text);
            stkr.inv_ex_date = "";
            stkr.comp_id = "";
            stkr.vend_id = "";
            stkr.active = "";
            stkr.remark = txtRemark.Text.Trim();
            stkr.date_create = "";
            stkr.date_modi = "";
            stkr.date_cancel = "";
            stkr.user_create = "";
            stkr.user_modi = "";
            stkr.user_cancel = "";
            stkr.branch_id = "";
            stkr.status_stock = "";
            stkr.stock_sub_id = cboStkSubName.SelectedItem == null ? "" : ((ComboBoxItem)cboStkSubName.SelectedItem).Value;
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setStockDrug();
                String re = ic.ivfDB.stkrDB.insertStockRec(stkr, ic.user.staff_id);
                int chk = 0;
                if (int.TryParse(re, out chk))
                {
                    foreach (Row row in grfStk.Rows)
                    {
                        StockRecDetail stkrd = new StockRecDetail();
                        stkrd.rec_detail_id = "";
                        stkrd.rec_id = "";
                        stkrd.goods_id = "";
                        stkrd.price = "";
                        stkrd.cost = "";
                        stkrd.qty = "";
                        stkrd.amount = "";
                        stkrd.unit_id = "";
                        stkrd.active = "";
                        stkrd.remark = "";
                        stkrd.date_create = "";
                        stkrd.date_modi = "";
                        stkrd.date_cancel = "";
                        stkrd.user_create = "";
                        stkrd.user_modi = "";
                        stkrd.user_cancel = "";
                        stkrd.status_stock = "1";

                    }
                    btnSave.Image = Resources.accept_database24;
                }
                else
                {
                    btnSave.Image = Resources.accept_database24;
                }
                //setGrfStockDrug();
            }
        }

        private void CboStkSubName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (pageLoad) return;
            String col = cboStkSubName.SelectedItem == null ? "" : ((ComboBoxItem)cboStkSubName.SelectedItem).Value;
            StockSubName stkn = new StockSubName();
            stkn = ic.ivfDB.stknDB.selectByPk(col);
            //setGrfStk(stkn.stock_sub_column_name);
        }
        private void initGrfStk()
        {
            grfStk = new C1FlexGrid();
            grfStk.Font = fEdit;
            grfStk.Dock = System.Windows.Forms.DockStyle.Fill;
            grfStk.Location = new System.Drawing.Point(0, 0);

            //FilterRow2 fr = new FilterRow2(grfBloodLab);

            grfStk.DoubleClick += GrfStk_DoubleClick;
            grfStk.AfterRowColChange += GrfStk_AfterRowColChange;
            grfStk.KeyUpEdit += GrfStk_KeyUpEdit;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //if (flagedit.Equals("edit"))
            //{
            //    menuGw.MenuItems.Add("สั่งการ", new EventHandler(ContextMenu_order_bl_set));
            //}

            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfStk.ContextMenu = menuGw;
            pnItem.Controls.Add(grfStk);

            theme1.SetTheme(grfStk, "Office2010Red");

        }

        private void GrfStk_KeyUpEdit(object sender, KeyEditEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.Col == colQty)
            {
                if (grfStk.Rows.Count == (grfStk.Row + 1)) grfStk.Rows.Count++;
                grfStk.Col = colName;
                grfStk.Row = grfStk.Rows.Count - 1;
            }
        }

        private void GrfStk_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            
        }
        private void GrfStk_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

        }
        private void setGrfStockRec(String id)
        {
            //grfDept.Rows.Count = 7;
                        
            grfStk.Cols.Count = 9;
            grfStk.Rows.Count = 2;
            grfStk.Cols[colId].Width = 80;

            grfStk.Cols[colPrice].Width = 80;
            grfStk.Cols[colName].Width = 300;
            grfStk.Cols[colQty].Width = 80;
            grfStk.Cols[colUnit].Width = 80;
            grfStk.Cols[colLotNo].Width = 100;
            grfStk.Cols[colExpDate].Width = 100;
            grfStk.Cols[colAmt].Width = 100;

            grfStk.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";
            CellStyle cs = grfStk.Styles.Add("date");
            cs.DataType = typeof(DateTime);
            
            grfStk.Cols[colExpDate].Style = cs;
            grfStk.Cols[colId].Caption = "รหัส";
            grfStk.Cols[colName].Caption = "ชื่อ";
            grfStk.Cols[colPrice].Caption = "ราคา";
            grfStk.Cols[colQty].Caption = "QTY";
            grfStk.Cols[colUnit].Caption = "หน่วย";
            grfStk.Cols[colLotNo].Caption = "LotNo";
            grfStk.Cols[colExpDate].Caption = "Expire Date";
            grfStk.Cols[colAmt].Caption = "รวมราคา";
            C1ComboBox cbo = new C1ComboBox();
            cbo = ic.ivfDB.oStkdDB.setCboStockDrug();
            cbo.DropDownClosed += Cbo_DropDownClosed;
            //cs.DataType = typeof(ComboBox);
            grfStk.Cols[colName].Editor = cbo;
            //grfStk.Cols[colName].Style = cs;
            //for (int col = 0; col < dt.Columns.Count; ++col)
            //{
            //    grfDrug.Cols[col + 1].DataType = dt.Columns[col].DataType;
            //    grfDrug.Cols[col + 1].Caption = dt.Columns[col].ColumnName;
            //    grfDrug.Cols[col + 1].Name = dt.Columns[col].ColumnName;
            //}
            grfStk.Cols[colId].Visible = false;
            grfStk.Cols[colPrice].Visible = false;
            grfStk.Cols[colUnit].AllowEditing = false;
            //grfStk.Cols[colQty].Visible = false;
            grfStk.SelectionMode = SelectionModeEnum.Cell;
            if (id.Length <= 0) return;
            DataTable dt = new DataTable();
            dt = ic.ivfDB.stkrdDB.selectByRecId(id);
            grfStk.Rows.Count = dt.Rows.Count+1;
            for (int i = 1; i < dt.Rows.Count; i++)
            {
                //Decimal price = 0;
                //Decimal.TryParse(grfPkg.Rows[i][colPrice].ToString(), out price);
                //grfPkg.Rows[i][colQty] = price.ToString("#,###.00");
                grfStk[i, 0] = i;
                if (i % 2 == 0)
                    grfStk.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            }
            
            //grfAgn.Cols[colS].Visible = false;
            //grfAgn.Cols[colRemark].Visible = false;
        }

        private void Cbo_DropDownClosed(object sender, DropDownClosedEventArgs e)
        {
            //throw new NotImplementedException();
            //MessageBox.Show("22", "");
            String id = "";
            ComboBoxItem item = new ComboBoxItem();
            item = (ComboBoxItem)((C1ComboBox)sender).SelectedItem;
            if (item == null) return;
            grfStk[grfStk.Row,colId] = item.Value;
            grfStk.Col = colQty;
            grfStk[grfStk.Row, colUnit] = ic.ivfDB.oStkdDB.getUnit(item.Value.Trim());
            grfStk[grfStk.Row, 0] = grfStk.Row;
            //col.Selected = true;
            //if (grfStk.Rows.Count == grfStk.Row+1) grfStk.Rows.Add();
            //item = (ComboBoxItem)item1;
            //item = (ComboBoxItem)item1;
        }

        private void FrmStockRec_Load(object sender, EventArgs e)
        {

        }
    }
}
