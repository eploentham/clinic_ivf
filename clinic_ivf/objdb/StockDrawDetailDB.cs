using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class StockDrawDetailDB
    {
        public StockDrawDetail dsc;
        ConnectDB conn;
        public List<StockDrawDetail> lDgs;

        public StockDrawDetailDB(ConnectDB c)
        {
            this.conn = c;
            initConfig();
        }
        private void initConfig()
        {
            dsc = new StockDrawDetail();
            lDgs = new List<StockDrawDetail>();

            dsc.draw_detail_id = "draw_detail_id";
            dsc.draw_id = "draw_id";
            dsc.goods_id = "goods_id";
            dsc.price = "price";
            dsc.cost = "cost";
            dsc.qty = "qty";
            dsc.amount = "amount";
            dsc.unit_id = "unit_id";
            dsc.active = "active";
            dsc.remark = "remark";
            dsc.date_create = "date_create";
            dsc.date_modi = "date_modi";
            dsc.date_cancel = "date_cancel";
            dsc.user_create = "user_create";
            dsc.user_modi = "user_modi";
            dsc.user_cancel = "user_cancel";
            dsc.hn = "hn";
            dsc.status_stock = "status_stock";            

            dsc.table = "t_doc_scan";
            dsc.pkField = "draw_detail_id";
        }
        public void getlBsp()
        {
            //lDept = new List<Position>();

            lDgs.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                StockDrawDetail itm1 = new StockDrawDetail();
                itm1.draw_detail_id = row[dsc.draw_detail_id].ToString();
                itm1.draw_id = row[dsc.draw_id].ToString();
                itm1.goods_id = row[dsc.goods_id].ToString();
                itm1.price = row[dsc.price].ToString();
                itm1.cost = row[dsc.cost].ToString();
                itm1.qty = row[dsc.qty].ToString();
                itm1.amount = row[dsc.amount].ToString();
                itm1.unit_id = row[dsc.unit_id].ToString();
                itm1.active = row[dsc.active].ToString();
                itm1.remark = row[dsc.remark].ToString();
                itm1.date_create = row[dsc.date_create].ToString();
                itm1.date_modi = row[dsc.date_modi].ToString();
                itm1.date_cancel = row[dsc.date_cancel].ToString();
                itm1.user_create = row[dsc.user_create].ToString();
                itm1.user_modi = row[dsc.user_modi].ToString();
                itm1.user_cancel = row[dsc.user_cancel].ToString();
                itm1.hn = row[dsc.hn].ToString();
                itm1.status_stock = row[dsc.status_stock].ToString();
                
                lDgs.Add(itm1);
            }
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + dsc.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                " Where dsc." + dsc.active + " ='1' " +
                "Order By draw_id ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByHn(String id)
        {
            //StockDrawDetail cop1 = new StockDrawDetail();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + dsc.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + dsc.qty + " ='" + id + "' and dsc." + dsc.active + "='1'" +
                "Order By draw_id ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public StockDrawDetail selectByPk(String id)
        {
            StockDrawDetail cop1 = new StockDrawDetail();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + dsc.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + dsc.pkField + " ='" + id + "' " +
                "Order By draw_id ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setDocScan(dt);
            return cop1;
        }
        public DataTable selectByPk1(String id)
        {
            StockDrawDetail cop1 = new StockDrawDetail();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + dsc.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + dsc.pkField + " ='" + id + "' " +
                "Order By draw_id ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByVn(String qty, String amount, String vsDate)
        {
            StockDrawDetail cop1 = new StockDrawDetail();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + dsc.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + dsc.qty + " ='" + qty + "' and dsc." + dsc.amount + "='" + amount + "' and dsc." + dsc.unit_id + "='" + vsDate + "' and dsc." + dsc.active + "='1'" +
                "Order By draw_id ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByVn(String qty, String hn)
        {
            StockDrawDetail cop1 = new StockDrawDetail();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + dsc.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + dsc.qty + " ='" + qty + "' and dsc." + dsc.amount + "='" + hn + "' and dsc." + dsc.active + "='1'" +
                "Order By draw_id ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public String selectRowNoByHn(String qty, String docgid)
        {
            String re = "0", re1 = "";
            int chk = 0;
            StockDrawDetail cop1 = new StockDrawDetail();
            DataTable dt = new DataTable();
            String sql = "select max(" + dsc.goods_id + ") as " + dsc.goods_id + " " +
                "From " + dsc.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + dsc.qty + " ='" + qty + "' and dsc." + dsc.draw_id + "='" + docgid + "' " +
                "  ";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                re1 = dt.Rows[0][dsc.goods_id].ToString();
                int.TryParse(re1, out chk);
                chk++;
                re = chk.ToString();
            }
            return re;
        }
        public String selectRowNoByHnVn(String qty, String amount, String docgid)
        {
            String re = "0", re1 = "";
            int chk = 0;
            StockDrawDetail cop1 = new StockDrawDetail();
            DataTable dt = new DataTable();
            String sql = "select max(" + dsc.goods_id + ") as " + dsc.goods_id + " " +
                "From " + dsc.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + dsc.qty + " ='" + qty + "' and dsc." + dsc.draw_id + "='" + docgid + "' and dsc." + dsc.amount + "='" + amount + "' " +
                "  ";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                re1 = dt.Rows[0][dsc.goods_id].ToString();
                int.TryParse(re1, out chk);
                chk++;
                re = chk.ToString();
            }
            return re;
        }
        private void chkNull(StockDrawDetail p)
        {
            long chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
                        
            p.remark = p.remark == null ? "" : p.remark;
            p.hn = p.hn == null ? "" : p.hn;
            p.status_stock = p.status_stock == null ? "" : p.status_stock;
            

            p.draw_id = long.TryParse(p.draw_id, out chk) ? chk.ToString() : "0";
            p.goods_id = long.TryParse(p.goods_id, out chk) ? chk.ToString() : "0";
            p.unit_id = long.TryParse(p.unit_id, out chk) ? chk.ToString() : "0";

            p.price = Decimal.TryParse(p.price, out chk1) ? chk1.ToString() : "0";
            p.cost = Decimal.TryParse(p.cost, out chk1) ? chk1.ToString() : "0";
            p.qty = Decimal.TryParse(p.qty, out chk1) ? chk1.ToString() : "0";
            p.amount = Decimal.TryParse(p.amount, out chk1) ? chk1.ToString() : "0";
        }
        public String insert(StockDrawDetail p, String userId)
        {
            String re = "";
            String sql = "";
            //DataTable dt = new DataTable();
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;
            chkNull(p);
            sql = "Insert Into " + dsc.table + " set " +
                "" + dsc.draw_id + "= '" + p.draw_id + "'" +
                "," + dsc.active + "= '" + p.active + "'" +
                "," + dsc.goods_id + "= '" + p.goods_id + "'" +
                "," + dsc.price + "= '" + p.price + "'" +
                "," + dsc.cost + "= '" + p.cost + "'" +
                "," + dsc.qty + "= '" + p.qty + "'" +
                "," + dsc.amount + "= '" + p.amount + "'" +
                "," + dsc.unit_id + "= '" + p.unit_id + "'" +
                "," + dsc.remark + "= '" + p.remark + "'" +
                "," + dsc.date_create + "= now()" +
                "," + dsc.date_modi + "= ''" +
                "," + dsc.date_cancel + "= ''" +
                "," + dsc.user_create + "= '" + userId + "'" +
                "," + dsc.user_modi + "= ''" +
                "," + dsc.user_cancel + "= ''" +
                "," + dsc.hn + "= '" + p.hn + "'" +
                "," + dsc.status_stock + "= '" + p.status_stock + "'" +
                
                "";
            try
            {
                re = conn.ExecuteNonQuery(conn.conn, sql);                
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
            }
            finally
            {
                conn.conn.Close();
                //conn.comStore.Dispose();
            }
            return re;
        }
        public String update(StockDrawDetail p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            chkNull(p);
            sql = "Update " + dsc.table + " Set " +
                " " + dsc.draw_id + " = '" + p.draw_id + "'" +
                "," + dsc.goods_id + " = '" + p.goods_id + "'" +
                "," + dsc.price + " = '" + p.price + "'" +
                "," + dsc.cost + " = '" + p.cost + "'" +
                "," + dsc.qty + " = '" + p.qty + "'" +
                "," + dsc.amount + " = '" + p.amount + "'" +
                "," + dsc.unit_id + " = '" + p.unit_id + "'" +
                "," + dsc.remark + " = '" + p.remark + "'" +
                "," + dsc.date_modi + " = now()" +
                "," + dsc.user_modi + " = '" + userId + "'" +
                "," + dsc.hn + " = '" + p.hn + "'" +
                "," + dsc.status_stock + " = '" + p.status_stock + "'" +
                
                "Where " + dsc.pkField + "='" + p.draw_detail_id + "'"
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
        public String insertDocScan(StockDrawDetail p, String userId)
        {
            String re = "";

            if (p.draw_detail_id.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
            }

            return re;
        }
        public String updateImagepath(String cost, String id)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            //chkNull(p);
            sql = "Update " + dsc.table + " Set " +
                " " + dsc.cost + " = '" + cost + "'" +
                "Where " + dsc.pkField + "='" + id + "'"
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
        public String voidDocScan(String id, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Update " + dsc.table + " Set " +
                " " + dsc.active + " = '3'" +
                "," + dsc.date_cancel + " = getdate()" +
                "," + dsc.user_cancel + " = '" + userId + "'" +
                "Where " + dsc.pkField + "='" + id + "'"
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
        public StockDrawDetail setDocScan(DataTable dt)
        {
            StockDrawDetail dgs1 = new StockDrawDetail();
            if (dt.Rows.Count > 0)
            {
                dgs1.draw_detail_id = dt.Rows[0][dsc.draw_detail_id].ToString();
                dgs1.draw_id = dt.Rows[0][dsc.draw_id].ToString();
                dgs1.goods_id = dt.Rows[0][dsc.goods_id].ToString();
                dgs1.price = dt.Rows[0][dsc.price].ToString();
                dgs1.cost = dt.Rows[0][dsc.cost].ToString();
                dgs1.qty = dt.Rows[0][dsc.qty].ToString();
                dgs1.amount = dt.Rows[0][dsc.amount].ToString();
                dgs1.unit_id = dt.Rows[0][dsc.unit_id].ToString();
                dgs1.active = dt.Rows[0][dsc.active].ToString();
                dgs1.remark = dt.Rows[0][dsc.remark].ToString();
                dgs1.date_create = dt.Rows[0][dsc.date_create].ToString();
                dgs1.date_modi = dt.Rows[0][dsc.date_modi].ToString();
                dgs1.date_cancel = dt.Rows[0][dsc.date_cancel].ToString();
                dgs1.user_create = dt.Rows[0][dsc.user_create].ToString();
                dgs1.user_modi = dt.Rows[0][dsc.user_modi].ToString();
                dgs1.user_cancel = dt.Rows[0][dsc.user_cancel].ToString();
                dgs1.hn = dt.Rows[0][dsc.hn].ToString();
                dgs1.status_stock = dt.Rows[0][dsc.status_stock].ToString();
                
            }
            else
            {
                setDocGroupScan(dgs1);
            }
            return dgs1;
        }
        public StockDrawDetail setDocGroupScan(StockDrawDetail dgs1)
        {
            dgs1.draw_detail_id = "";
            dgs1.draw_id = "";
            dgs1.goods_id = "";
            dgs1.price = "";
            dgs1.cost = "";
            dgs1.qty = "";
            dgs1.amount = "";
            dgs1.unit_id = "";
            dgs1.active = "";
            dgs1.remark = "";
            dgs1.date_create = "";
            dgs1.date_modi = "";
            dgs1.date_cancel = "";
            dgs1.user_create = "";
            dgs1.user_modi = "";
            dgs1.user_cancel = "";
            dgs1.hn = "";
            dgs1.status_stock = "";
            
            return dgs1;
        }
    }
}
