﻿using C1.Win.C1FlexGrid;
using clinic_ivf.control;
using clinic_ivf.FlexGrid;
using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.gui
{
    public partial class Form3 : Form
    {
        IvfControl ic;
        C1FlexGrid _flex = new C1FlexGrid();
        public Form3(IvfControl ic)
        {
            InitializeComponent();
            this.ic = ic;
            //initGrfNote();
        }
        private void initGrf()
        {
            //C1FlexGrid _flex = new C1FlexGrid();
            //_flex.Font = fEdit;
            _flex.Dock = System.Windows.Forms.DockStyle.Fill;
            _flex.Location = new System.Drawing.Point(0, 0);
            this.Controls.Add(_flex);

            String tableName = "InventoryManagement";
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\ComponentOne Samples\Common";
            string conn = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0}\\C1NWind.mdb";
            //return String.Format(conn, path);

            string connectionString = String.Format(conn, path);
            string commandText = $"select * from [{tableName}]";
            OleDbDataAdapter adapter = new OleDbDataAdapter(commandText, connectionString);
            DataTable table = new DataTable(tableName);
            
            adapter.Fill(table);
            //_flex.DataSource = table;
            _flex.Rows.Count = table.Rows.Count + 2;
            _flex.Cols.Count = table.Columns.Count + 1;

            // Set DataType, Caption, and Names
            // DataType and Name are used in FilterRow to apply Condition Filters
            for (int col = 0; col < table.Columns.Count; ++col)
            {
                _flex.Cols[col + 1].DataType = table.Columns[col].DataType;
                _flex.Cols[col + 1].Caption = table.Columns[col].ColumnName;
                _flex.Cols[col + 1].Name = table.Columns[col].ColumnName;
            }

            for (int row = 0; row < table.Rows.Count; ++row)
            {
                for (int col = 0; col < table.Columns.Count; ++col)
                {
                    _flex[row + 2, col + 1] = table.Rows[row][col];
                }
            }

            FilterRow filterRow = new FilterRow(_flex);
            _flex.AllowFiltering = true;

            _flex.AfterFilter += _flex_AfterFilter2;
            _flex.AfterRowColChange += _flex_AfterRowColChange1;
        }

        private void _flex_AfterRowColChange1(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void _flex_AfterFilter2(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void initGrfNote()
        {
            //grfNote = new C1FlexGrid();
            //grfNote.Font = fEdit;
            
            //_flex.Font = fEdit;
            _flex.Dock = System.Windows.Forms.DockStyle.Fill;
            _flex.Location = new System.Drawing.Point(0, 0);
            this.Controls.Add(_flex);

            DataTable dt = new DataTable();
            dt = ic.ivfDB.oSItmDB.selectBySpecialItem2();
            //grf.DataSource = dt;
            //_flex.Dock = System.Windows.Forms.DockStyle.Fill;
            //_flex.Location = new System.Drawing.Point(0, 0);
            //grf.Rows.Count = 10;
            
            int colBlId = 1, colBlName = 2, colBlQty = 3, colBlPrice = 4, colBlInclude = 5, colBlRemark = 6;

            int i = 0;
            decimal aaa = 0;
            _flex.Rows.Count = dt.Rows.Count + 2;
            _flex.Cols.Count = dt.Columns.Count + 3;

            //grf.Cols[col + 1].DataType = table.Columns[col].DataType;
            //grf.Cols[col + 1].Caption = table.Columns[col].ColumnName;
            //grf.Cols[colBlPrice].DataType = typeof(Decimal);
            //grf.Cols[colBlName].DataType = dt.Columns[ic.ivfDB.oSItmDB.sitm.SName].DataType;
            //grf.Cols[colBlQty].DataType = typeof(Decimal);
            //grf.Cols[colBlRemark].DataType = dt.Columns[ic.ivfDB.oSItmDB.sitm.SName].DataType;
            //grf.Cols[colBlId].DataType = typeof(Int32);

            _flex.Cols[colBlPrice].Caption = "Price";
            _flex.Cols[colBlName].Caption = "Name";
            _flex.Cols[colBlQty].Caption = "Qty";
            _flex.Cols[colBlRemark].Caption = "Remark";
            _flex.Cols[colBlId].Caption = "ID";
            //for (int col = 0; col < dt.Columns.Count; ++col)
            //{
            //grf.Cols[colBlId].DataType = dt.Columns["SID"].DataType;
            //grf.Cols[colBlId].Name = dt.Columns["SID"].ColumnName;
            //grf.Cols[colBlPrice].DataType = dt.Columns["Price"].DataType;
            //grf.Cols[colBlPrice].Name = dt.Columns["Price"].ColumnName;
            //grf.Cols[colBlName].DataType = dt.Columns["SName"].DataType;
            //grf.Cols[colBlName].Name = dt.Columns["SName"].ColumnName;
            //grf.Cols[colBlRemark].DataType = dt.Columns["bilgrpname"].DataType;
            //grf.Cols[colBlRemark].Name = dt.Columns["bilgrpname"].ColumnName;
            //}
            for (int col = 0; col < dt.Columns.Count; ++col)
            {
                _flex.Cols[col + 1].DataType = dt.Columns[col].DataType;
                //_flex.Cols[col + 1].Caption = dt.Columns[col].ColumnName;
                _flex.Cols[col + 1].Name = dt.Columns[col].ColumnName;
            }
            for (int row = 0; row < dt.Rows.Count; ++row)
            {
                for (int col = 0; col < dt.Columns.Count; ++col)
                {
                    _flex[row + 2, col + 1] = dt.Rows[row][col];
                }
            }
            //foreach (DataRow row in dt.Rows)
            //{
            //    try
            //    {
            //        i++;
            //        if (i == 1) continue;

            //        Decimal.TryParse(row[ic.ivfDB.oSItmDB.sitm.Price].ToString(), out aaa);
            //        grf[i, colBlPrice] = aaa.ToString("#,##0");
            //        grf[i, colBlId] = row[ic.ivfDB.oSItmDB.sitm.SID].ToString();
            //        grf[i, colBlName] = row[ic.ivfDB.oSItmDB.sitm.SName].ToString();
            //        grf[i, colBlQty] = "1";
            //        grf[i, colBlRemark] = row["bilgrpname"].ToString();
            //    }
            //    catch (Exception ex)
            //    {
            //        String err = "";
            //    }

            //}
            FilterRow fr = new FilterRow(_flex);
            _flex.AllowFiltering = true;
            _flex.AfterFilter += _flex_AfterFilter1;
            _flex.AfterRowColChange += _flex_AfterRowColChange;
            //grfImg.MouseDown += GrfImg_MouseDown;
            //grfNote.DoubleClick += GrfNote_DoubleClick;
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            //ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("Upload รูปบัตรประชาชน", new EventHandler(ContextMenu_grfimg_upload_ptt));
            //menuGw.MenuItems.Add("Upload สำเนาบัตรประชาชน ที่มีลายเซ็น", new EventHandler(ContextMenu_grfimg_upload_ptt));
            //menuGw.MenuItems.Add("Upload รูป Passport", new EventHandler(ContextMenu_grfimg_upload_ptt));
            //menuGw.MenuItems.Add("ยกเลิก", new EventHandler(ContextMenu_grfimg_Cancel));
            //grfImgOld.ContextMenu = menuGw;
            //pnNote.Controls.Add(grfNote);

            //theme1.SetTheme(grfNote, "Office2016Colorful");

        }

        private void _flex_AfterFilter1(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            var aaaa = "";
        }

        private void _flex_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            //throw new NotImplementedException();
            var sss = "";
        }

        private void Grf_AfterFilter(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            for (int col = _flex.Cols.Fixed; col < _flex.Cols.Count; ++col)
            {
                var filter = _flex.Cols[col].ActiveFilter;
            }
        }

        private void _flex_AfterFilter(object sender, EventArgs e)
        {
            for (int col = _flex.Cols.Fixed; col < _flex.Cols.Count; ++col)
            {
                var filter = _flex.Cols[col].ActiveFilter;
            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
