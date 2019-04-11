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
    public partial class Form3 : Form
    {
        IvfControl ic;

        public Form3(IvfControl ic)
        {
            InitializeComponent();
            this.ic = ic;
            initGrfNote();
        }
        private void initGrfNote()
        {
            //grfNote = new C1FlexGrid();
            //grfNote.Font = fEdit;
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

            //grf.Cols[colBlPrice].Name = "Price";
            //grf.Cols[colBlName].Name = "Name";
            //grf.Cols[colBlQty].Name = "Qty";
            //grf.Cols[colBlRemark].Name = "Remark";
            //grf.Cols[colBlId].Name = "ID";
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
                _flex.Cols[col + 1].Caption = dt.Columns[col].ColumnName;
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
            
        }
        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
