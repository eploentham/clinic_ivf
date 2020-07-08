using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class StockCardEndYearDB
    {
        public StockCardEndYear stkc;
        ConnectDB conn;
        public List<StockCardEndYear> lstkc;

        public StockCardEndYearDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lstkc = new List<StockCardEndYear>();
            stkc = new StockCardEndYear();
            stkc.stock_endyear_id = "stock_endyear_id";
            stkc.year_id = "year_id";
            stkc.item_id = "item_id";
            stkc.price = "price";
            stkc.qty = "qty";
            stkc.remark = "remark";
            stkc.sort1 = "sort1";
            stkc.date_cancel = "date_cancel";
            stkc.date_create = "date_create";
            stkc.date_modi = "date_modi";
            stkc.user_cancel = "user_cancel";
            stkc.user_create = "user_create";
            stkc.user_modi = "user_modi";
            stkc.host_id = "host_id";
            stkc.branch_id = "branch_id";
            stkc.device_id = "device_id";
            stkc.weight = "weight";
            stkc.rec_draw_sale_id = "rec_draw_sale_id";
            stkc.status_rec_draw = "status_rec_draw";
            stkc.rec_draw_sale_date = "rec_draw_sale_date";
            stkc.onhand = "onhand";
            stkc.host_id = "host_id";
            stkc.branch_id = "branch_id";
            stkc.device_id = "device_id";
            stkc.active = "active";
            stkc.remark1 = "remark1";
            stkc.description = "description";
            stkc.doc_no = "doc_no";

            stkc.pkField = "stock_endyear_id";
            stkc.table = "t_stock_endyear";
        }
        public DataTable selectByYear(String yearId)
        {
            DataTable dt = new DataTable();
            String sql = "select stkc.* " +
                "From " + stkc.table + " stkc " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where stkc." + stkc.year_id + " ='" + yearId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        private void chkNull(StockCardEndYear p)
        {
            long chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.host_id = p.host_id == null ? "" : p.host_id;
            p.branch_id = p.branch_id == null ? "" : p.branch_id;
            p.device_id = p.device_id == null ? "" : p.device_id;

            p.price = p.price == null ? "" : p.price;
            p.item_id = p.item_id == null ? "" : p.item_id;

            p.remark = p.remark == null ? "" : p.remark;
            p.remark = p.remark == null ? "" : p.remark;
            p.remark = p.remark == null ? "" : p.remark;
            p.remark = p.remark == null ? "" : p.remark;
            p.remark = p.remark == null ? "" : p.remark;

            p.rec_draw_sale_id = long.TryParse(p.rec_draw_sale_id, out chk) ? chk.ToString() : "0";
            p.rec_draw_sale_date = long.TryParse(p.rec_draw_sale_date, out chk) ? chk.ToString() : "0";
            p.status_rec_draw = long.TryParse(p.status_rec_draw, out chk) ? chk.ToString() : "0";

            p.price = Decimal.TryParse(p.price, out chk1) ? chk1.ToString() : "0";
            p.item_id = Decimal.TryParse(p.item_id, out chk1) ? chk1.ToString() : "0";
            p.onhand = Decimal.TryParse(p.onhand, out chk1) ? chk1.ToString() : "0";
        }
        public String insert(StockCardEndYear p, String userId)
        {
            String re = "";
            String sql = "";
            p.qty = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            sql = "Insert Into " + stkc.table + " set " +
                " " + stkc.item_id + " = '" + p.item_id + "'" +
                "," + stkc.price + " = '" + p.price.Replace("'", "''") + "'" +
                "," + stkc.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + stkc.date_create + " = now()" +
                "," + stkc.onhand + " = '" + p.onhand + "'" +
                "," + stkc.user_create + " = '" + userId + "' " +
                "," + stkc.host_id + " = '" + p.host_id + "' " +
                "," + stkc.branch_id + " = '" + p.branch_id + "' " +
                "," + stkc.device_id + " = '" + p.device_id + "' " +
                "," + stkc.rec_draw_sale_id + " = '" + p.rec_draw_sale_id + "' " +
                "," + stkc.sort1 + " = '" + p.sort1 + "' " +
                " ";
            try
            {
                re = conn.ExecuteNonQuery(conn.conn, sql);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
            }

            return re;
        }
        public String update(StockCardEndYear p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + stkc.table + " Set " +
                " " + stkc.item_id + " = '" + p.item_id + "'" +
                "," + stkc.price + " = '" + p.price.Replace("'", "''") + "'" +
                "," + stkc.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + stkc.date_modi + " = now()" +
                "," + stkc.user_modi + " = '" + userId + "' " +
                "," + stkc.host_id + " = '" + p.host_id + "' " +
                "," + stkc.branch_id + " = '" + p.branch_id + "' " +
                "," + stkc.device_id + " = '" + p.device_id + "' " +
                "," + stkc.sort1 + " = '" + p.sort1 + "' " +
                "," + stkc.onhand + " = '" + p.onhand + "' " +
                "Where " + stkc.pkField + "='" + p.stock_endyear_id + "'"
                ;

            try
            {
                re = conn.ExecuteNonQuery(conn.conn, sql);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
            }

            return re;
        }
        public String insertStockCardEndYear(StockCardEndYear p, String userId)
        {
            String re = "";

            if (p.stock_endyear_id.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
            }

            return re;
        }
        private StockCardEndYear setStockCardEndYear(DataTable dt)
        {
            StockCardEndYear dept1 = new StockCardEndYear();
            if (dt.Rows.Count > 0)
            {
                dept1.stock_endyear_id = dt.Rows[0][stkc.stock_endyear_id].ToString();
                dept1.year_id = dt.Rows[0][stkc.year_id].ToString();
                dept1.item_id = dt.Rows[0][stkc.item_id].ToString();
                dept1.price = dt.Rows[0][stkc.price].ToString();
                dept1.weight = dt.Rows[0][stkc.weight] != null ? dt.Rows[0][stkc.weight].ToString() : "";
                dept1.item_id = dt.Rows[0][stkc.item_id] != null ? dt.Rows[0][stkc.item_id].ToString() : "";
                dept1.remark = dt.Rows[0][stkc.remark] != null ? dt.Rows[0][stkc.remark].ToString() : "";
                dept1.date_create = dt.Rows[0][stkc.date_create] != null ? dt.Rows[0][stkc.date_create].ToString() : "";
                dept1.date_modi = dt.Rows[0][stkc.date_modi] != null ? dt.Rows[0][stkc.date_modi].ToString() : "";
                dept1.date_cancel = dt.Rows[0][stkc.date_cancel] != null ? dt.Rows[0][stkc.date_cancel].ToString() : "";
                dept1.user_create = dt.Rows[0][stkc.user_create] != null ? dt.Rows[0][stkc.user_create].ToString() : "";
                dept1.user_modi = dt.Rows[0][stkc.user_modi] != null ? dt.Rows[0][stkc.user_modi].ToString() : "";
                dept1.user_cancel = dt.Rows[0][stkc.user_cancel] != null ? dt.Rows[0][stkc.user_cancel].ToString() : "";
                dept1.qty = dt.Rows[0][stkc.qty] != null ? dt.Rows[0][stkc.qty].ToString() : "";
                dept1.sort1 = dt.Rows[0][stkc.sort1] != null ? dt.Rows[0][stkc.sort1].ToString() : "";
                dept1.price = dt.Rows[0][stkc.price] != null ? dt.Rows[0][stkc.price].ToString() : "";
                dept1.rec_draw_sale_id = dt.Rows[0][stkc.rec_draw_sale_id] != null ? dt.Rows[0][stkc.rec_draw_sale_id].ToString() : "";
                dept1.rec_draw_sale_date = dt.Rows[0][stkc.rec_draw_sale_date] != null ? dt.Rows[0][stkc.rec_draw_sale_date].ToString() : "";
                dept1.status_rec_draw = dt.Rows[0][stkc.status_rec_draw] != null ? dt.Rows[0][stkc.status_rec_draw].ToString() : "";
                dept1.onhand = dt.Rows[0][stkc.onhand] != null ? dt.Rows[0][stkc.onhand].ToString() : "";
            }
            else
            {
                dept1.stock_endyear_id = "";
                dept1.year_id = "";
                dept1.item_id = "";
                dept1.price = "";
                dept1.weight = "";
                dept1.remark = "";
                dept1.date_create = "";
                dept1.date_modi = "";
                dept1.date_cancel = "";
                dept1.user_create = "";
                dept1.user_modi = "";
                dept1.user_cancel = "";
                dept1.qty = "";
                dept1.sort1 = "";
                dept1.price = "";
                dept1.item_id = "";
                dept1.rec_draw_sale_id = "";
                dept1.status_rec_draw = "";
                dept1.rec_draw_sale_date = "";
                dept1.onhand = "";
            }

            return dept1;
        }
    }
}
