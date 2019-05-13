﻿using C1.Win.C1FlexGrid;
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

            sB1.Text = "";
            pageLoad = false;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                //setStockDrug();
                String re = ic.ivfDB.stkrDB.insertDocScan(stkr, ic.user.staff_id);
                int chk = 0;
                if (int.TryParse(re, out chk))
                {
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

        private void GrfStk_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

        }
        private void setGrfStockRec(String id)
        {
            //grfDept.Rows.Count = 7;

            grfStk.DataSource = ic.ivfDB.stkrdDB.selectByVn(id);
            grfStk.Cols.Count = 5;

            grfStk.Cols[colId].Width = 80;

            grfStk.Cols[colPrice].Width = 80;
            grfStk.Cols[colName].Width = 440;
            grfStk.Cols[colQty].Width = 80;
            grfStk.Cols[colUnit].Width = 80;
            grfStk.Cols[colLotNo].Width = 100;
            grfStk.Cols[colExpDate].Width = 100;
            grfStk.Cols[colAmt].Width = 100;

            grfStk.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfStk.Cols[colId].Caption = "รหัส";
            grfStk.Cols[colName].Caption = "ชื่อ";
            grfStk.Cols[colPrice].Caption = "ราคา";
            grfStk.Cols[colQty].Caption = "QTY";
            grfStk.Cols[colUnit].Caption = "หน่วย";
            grfStk.Cols[colLotNo].Caption = "LotNo";
            grfStk.Cols[colExpDate].Caption = "Expire Date";
            grfStk.Cols[colAmt].Caption = "รวมราคา";
            //for (int col = 0; col < dt.Columns.Count; ++col)
            //{
            //    grfDrug.Cols[col + 1].DataType = dt.Columns[col].DataType;
            //    grfDrug.Cols[col + 1].Caption = dt.Columns[col].ColumnName;
            //    grfDrug.Cols[col + 1].Name = dt.Columns[col].ColumnName;
            //}
            for (int i = 1; i < grfStk.Rows.Count; i++)
            {
                //Decimal price = 0;
                //Decimal.TryParse(grfPkg.Rows[i][colPrice].ToString(), out price);
                //grfPkg.Rows[i][colQty] = price.ToString("#,###.00");
                grfStk[i, 0] = i;
                if (i % 2 == 0)
                    grfStk.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            }
            grfStk.Cols[colId].Visible = false;
            grfStk.Cols[colQty].Visible = false;

            //grfAgn.Cols[colS].Visible = false;
            //grfAgn.Cols[colRemark].Visible = false;
        }
        private void FrmStockRec_Load(object sender, EventArgs e)
        {

        }
    }
}
