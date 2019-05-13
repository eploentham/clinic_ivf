using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class StockRecDetailDB
    {
        public StockRecDetail stkrd;
        ConnectDB conn;
        public List<StockRecDetail> lStkrD;

        public StockRecDetailDB(ConnectDB c)
        {
            this.conn = c;
            initConfig();
        }
        private void initConfig()
        {
            stkrd = new StockRecDetail();
            lStkrD = new List<StockRecDetail>();

            stkrd.rec_detail_id = "rec_detail_id";
            stkrd.rec_id = "rec_id";
            stkrd.goods_id = "goods_id";
            stkrd.price = "price";
            stkrd.cost = "cost";
            stkrd.qty = "qty";
            stkrd.amount = "amount";
            stkrd.unit_id = "unit_id";
            stkrd.active = "active";
            stkrd.remark = "remark";
            stkrd.date_create = "date_create";
            stkrd.date_modi = "date_modi";
            stkrd.date_cancel = "date_cancel";
            stkrd.user_create = "user_create";
            stkrd.user_modi = "user_modi";
            stkrd.user_cancel = "user_cancel";
            stkrd.status_stock = "status_stock";

            stkrd.table = "t_stock_rec_detail";
            stkrd.pkField = "rec_detail_id";
        }
        public void getlBsp()
        {
            //lDept = new List<Position>();

            lStkrD.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                StockRecDetail itm1 = new StockRecDetail();
                itm1.rec_detail_id = row[stkrd.rec_detail_id].ToString();
                itm1.rec_id = row[stkrd.rec_id].ToString();
                itm1.goods_id = row[stkrd.goods_id].ToString();
                itm1.price = row[stkrd.price].ToString();
                itm1.cost = row[stkrd.cost].ToString();
                itm1.qty = row[stkrd.qty].ToString();
                itm1.amount = row[stkrd.amount].ToString();
                itm1.unit_id = row[stkrd.unit_id].ToString();
                itm1.active = row[stkrd.active].ToString();
                itm1.remark = row[stkrd.remark].ToString();
                itm1.date_create = row[stkrd.date_create].ToString();
                itm1.date_modi = row[stkrd.date_modi].ToString();
                itm1.date_cancel = row[stkrd.date_cancel].ToString();
                itm1.user_create = row[stkrd.user_create].ToString();
                itm1.user_modi = row[stkrd.user_modi].ToString();
                itm1.user_cancel = row[stkrd.user_cancel].ToString();
                itm1.status_stock = row[stkrd.status_stock].ToString();
                
                lStkrD.Add(itm1);
            }
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + stkrd.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                " Where dsc." + stkrd.active + " ='1' " +
                "Order By rec_id ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByHn(String id)
        {
            //StockRecDetail cop1 = new StockRecDetail();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + stkrd.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + stkrd.qty + " ='" + id + "' and dsc." + stkrd.active + "='1'" +
                "Order By rec_id ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public StockRecDetail selectByPk(String id)
        {
            StockRecDetail cop1 = new StockRecDetail();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + stkrd.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + stkrd.pkField + " ='" + id + "' " +
                "Order By rec_id ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setDocScan(dt);
            return cop1;
        }
        public DataTable selectByPk1(String id)
        {
            StockRecDetail cop1 = new StockRecDetail();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + stkrd.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + stkrd.pkField + " ='" + id + "' " +
                "Order By rec_id ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByVn(String recid)
        {
            StockRecDetail cop1 = new StockRecDetail();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + stkrd.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + stkrd.qty + " ='" + recid + "' and dsc." + stkrd.active + "='1'" +
                "Order By rec_id ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        
        private void chkNull(StockRecDetail p)
        {
            long chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
                        
            p.unit_id = p.unit_id == null ? "" : p.unit_id;
            p.remark = p.remark == null ? "" : p.remark;
            p.status_stock = p.status_stock == null ? "" : p.status_stock;

            p.rec_id = long.TryParse(p.rec_id, out chk) ? chk.ToString() : "0";
            p.goods_id = long.TryParse(p.goods_id, out chk) ? chk.ToString() : "0";
            p.unit_id = long.TryParse(p.unit_id, out chk) ? chk.ToString() : "0";

            p.price = Decimal.TryParse(p.price, out chk1) ? chk1.ToString() : "0";
            p.cost = Decimal.TryParse(p.cost, out chk1) ? chk1.ToString() : "0";
            p.qty = Decimal.TryParse(p.qty, out chk1) ? chk1.ToString() : "0";
            p.amount = Decimal.TryParse(p.amount, out chk1) ? chk1.ToString() : "0";
        }
        public String insert(StockRecDetail p, String userId)
        {
            String re = "";
            String sql = "";
            //DataTable dt = new DataTable();
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;
            chkNull(p);
            sql = "Insert Into " + stkrd.table + " set " +
                "" + stkrd.rec_id + "= '" + p.rec_id + "'" +
                "," + stkrd.active + "= '" + p.active + "'" +
                "," + stkrd.goods_id + "= '" + p.goods_id + "'" +
                "," + stkrd.price + "= '" + p.price + "'" +
                "," + stkrd.cost + "= '" + p.cost + "'" +
                "," + stkrd.qty + "= '" + p.qty + "'" +
                "," + stkrd.amount + "= '" + p.amount + "'" +
                "," + stkrd.unit_id + "= '" + p.unit_id + "'" +
                "," + stkrd.remark + "= '" + p.remark + "'" +
                "," + stkrd.date_create + "= now()" +
                "," + stkrd.date_modi + "= ''" +
                "," + stkrd.date_cancel + "= ''" +
                "," + stkrd.user_create + "= '" + userId + "'" +
                "," + stkrd.user_modi + "= ''" +
                "," + stkrd.user_cancel + "= ''" +
                "," + stkrd.status_stock + "= '" + p.status_stock + "'" +
                
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
        public String update(StockRecDetail p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            chkNull(p);
            sql = "Update " + stkrd.table + " Set " +
                " " + stkrd.rec_id + " = '" + p.rec_id + "'" +
                "," + stkrd.goods_id + " = '" + p.goods_id + "'" +
                "," + stkrd.price + " = '" + p.price + "'" +
                "," + stkrd.cost + " = '" + p.cost + "'" +
                "," + stkrd.qty + " = '" + p.qty + "'" +
                "," + stkrd.amount + " = '" + p.amount + "'" +
                "," + stkrd.unit_id + " = '" + p.unit_id + "'" +
                "," + stkrd.remark + " = '" + p.remark + "'" +
                "," + stkrd.date_modi + " = now()" +
                "," + stkrd.user_modi + " = '" + userId + "'" +
                "," + stkrd.status_stock + " = '" + p.status_stock + "'" +
                
                "Where " + stkrd.pkField + "='" + p.rec_detail_id + "'"
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
        public String insertDocScan(StockRecDetail p, String userId)
        {
            String re = "";

            if (p.rec_detail_id.Equals(""))
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
            sql = "Update " + stkrd.table + " Set " +
                " " + stkrd.cost + " = '" + cost + "'" +
                "Where " + stkrd.pkField + "='" + id + "'"
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

            sql = "Update " + stkrd.table + " Set " +
                " " + stkrd.active + " = '3'" +
                "," + stkrd.date_cancel + " = getdate()" +
                "," + stkrd.user_cancel + " = '" + userId + "'" +
                "Where " + stkrd.pkField + "='" + id + "'"
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
        public StockRecDetail setDocScan(DataTable dt)
        {
            StockRecDetail dgs1 = new StockRecDetail();
            if (dt.Rows.Count > 0)
            {
                dgs1.rec_detail_id = dt.Rows[0][stkrd.rec_detail_id].ToString();
                dgs1.rec_id = dt.Rows[0][stkrd.rec_id].ToString();
                dgs1.goods_id = dt.Rows[0][stkrd.goods_id].ToString();
                dgs1.price = dt.Rows[0][stkrd.price].ToString();
                dgs1.cost = dt.Rows[0][stkrd.cost].ToString();
                dgs1.qty = dt.Rows[0][stkrd.qty].ToString();
                dgs1.amount = dt.Rows[0][stkrd.amount].ToString();
                dgs1.unit_id = dt.Rows[0][stkrd.unit_id].ToString();
                dgs1.active = dt.Rows[0][stkrd.active].ToString();
                dgs1.remark = dt.Rows[0][stkrd.remark].ToString();
                dgs1.date_create = dt.Rows[0][stkrd.date_create].ToString();
                dgs1.date_modi = dt.Rows[0][stkrd.date_modi].ToString();
                dgs1.date_cancel = dt.Rows[0][stkrd.date_cancel].ToString();
                dgs1.user_create = dt.Rows[0][stkrd.user_create].ToString();
                dgs1.user_modi = dt.Rows[0][stkrd.user_modi].ToString();
                dgs1.user_cancel = dt.Rows[0][stkrd.user_cancel].ToString();
                dgs1.status_stock = dt.Rows[0][stkrd.status_stock].ToString();
                
            }
            else
            {
                setDocGroupScan(dgs1);
            }
            return dgs1;
        }
        public StockRecDetail setDocGroupScan(StockRecDetail dgs1)
        {
            dgs1.rec_detail_id = "";
            dgs1.rec_id = "";
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
            dgs1.status_stock = "";
            
            return dgs1;
        }
    }
}
