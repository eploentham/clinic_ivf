using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class StockReturnDetailDB
    {
        public StockReturnDetail dsc;
        ConnectDB conn;
        public List<StockReturnDetail> lDgs;

        public StockReturnDetailDB(ConnectDB c)
        {
            this.conn = c;
            initConfig();
        }
        private void initConfig()
        {
            dsc = new StockReturnDetail();
            lDgs = new List<StockReturnDetail>();

            dsc.return_detail_id = "return_detail_id";
            dsc.return_id = "return_id";
            dsc.goods_id = "goods_id";
            dsc.qty = "qty";
            dsc.status_stock = "status_stock";
            
            dsc.active = "active";
            dsc.remark = "remark";
            dsc.date_create = "date_create";
            dsc.date_modi = "date_modi";
            dsc.date_cancel = "date_cancel";
            dsc.user_create = "user_create";
            dsc.user_modi = "user_modi";
            dsc.user_cancel = "user_cancel";
            

            dsc.table = "t_doc_scan";
            dsc.pkField = "return_detail_id";
        }
        public void getlBsp()
        {
            //lDept = new List<Position>();

            lDgs.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                StockReturnDetail itm1 = new StockReturnDetail();
                itm1.return_detail_id = row[dsc.return_detail_id].ToString();
                itm1.return_id = row[dsc.return_id].ToString();
                itm1.goods_id = row[dsc.goods_id].ToString();
                itm1.qty = row[dsc.qty].ToString();
                itm1.status_stock = row[dsc.status_stock].ToString();
                
                itm1.active = row[dsc.active].ToString();
                itm1.remark = row[dsc.remark].ToString();
                itm1.date_create = row[dsc.date_create].ToString();
                itm1.date_modi = row[dsc.date_modi].ToString();
                itm1.date_cancel = row[dsc.date_cancel].ToString();
                itm1.user_create = row[dsc.user_create].ToString();
                itm1.user_modi = row[dsc.user_modi].ToString();
                itm1.user_cancel = row[dsc.user_cancel].ToString();
                
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
                "Order By return_id ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        
        public StockReturnDetail selectByPk(String id)
        {
            StockReturnDetail cop1 = new StockReturnDetail();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + dsc.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + dsc.pkField + " ='" + id + "' " +
                "Order By return_id ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setDocScan(dt);
            return cop1;
        }
        public DataTable selectByPk1(String id)
        {
            StockReturnDetail cop1 = new StockReturnDetail();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + dsc.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + dsc.pkField + " ='" + id + "' " +
                "Order By return_id ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        
        private void chkNull(StockReturnDetail p)
        {
            long chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.qty = p.qty == null ? "" : p.qty;
            p.status_stock = p.status_stock == null ? "" : p.status_stock;
            
            p.remark = p.remark == null ? "" : p.remark;            

            p.return_id = long.TryParse(p.return_id, out chk) ? chk.ToString() : "0";
            p.goods_id = long.TryParse(p.goods_id, out chk) ? chk.ToString() : "0";            
        }
        public String insert(StockReturnDetail p, String userId)
        {
            String re = "";
            String sql = "";
            //DataTable dt = new DataTable();
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;
            chkNull(p);
            sql = "Insert Into " + dsc.table + " set " +
                "" + dsc.return_id + "= '" + p.return_id + "'" +
                "," + dsc.active + "= '" + p.active + "'" +
                "," + dsc.goods_id + "= '" + p.goods_id + "'" +
                "," + dsc.qty + "= '" + p.qty + "'" +
                "," + dsc.status_stock + "= '" + p.status_stock + "'" +
                
                "," + dsc.remark + "= '" + p.remark + "'" +
                "," + dsc.date_create + "= now()" +
                "," + dsc.date_modi + "= ''" +
                "," + dsc.date_cancel + "= ''" +
                "," + dsc.user_create + "= '" + userId + "'" +
                "," + dsc.user_modi + "= ''" +
                "," + dsc.user_cancel + "= ''" +
                
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
        public String update(StockReturnDetail p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            chkNull(p);
            sql = "Update " + dsc.table + " Set " +
                " " + dsc.return_id + " = '" + p.return_id + "'" +
                "," + dsc.goods_id + " = '" + p.goods_id + "'" +
                "," + dsc.qty + " = '" + p.qty + "'" +
                "," + dsc.status_stock + " = '" + p.status_stock + "'" +
                
                "," + dsc.remark + " = '" + p.remark + "'" +
                "," + dsc.date_modi + " = now()" +
                "," + dsc.user_modi + " = '" + userId + "'" +
                
                "Where " + dsc.pkField + "='" + p.return_detail_id + "'"
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
        public String insertDocScan(StockReturnDetail p, String userId)
        {
            String re = "";

            if (p.return_detail_id.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
            }

            return re;
        }
        public String updateImagepath(String status_stock, String id)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            //chkNull(p);
            sql = "Update " + dsc.table + " Set " +
                " " + dsc.status_stock + " = '" + status_stock + "'" +
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
        public StockReturnDetail setDocScan(DataTable dt)
        {
            StockReturnDetail dgs1 = new StockReturnDetail();
            if (dt.Rows.Count > 0)
            {
                dgs1.return_detail_id = dt.Rows[0][dsc.return_detail_id].ToString();
                dgs1.return_id = dt.Rows[0][dsc.return_id].ToString();
                dgs1.goods_id = dt.Rows[0][dsc.goods_id].ToString();
                dgs1.qty = dt.Rows[0][dsc.qty].ToString();
                dgs1.status_stock = dt.Rows[0][dsc.status_stock].ToString();
                
                dgs1.active = dt.Rows[0][dsc.active].ToString();
                dgs1.remark = dt.Rows[0][dsc.remark].ToString();
                dgs1.date_create = dt.Rows[0][dsc.date_create].ToString();
                dgs1.date_modi = dt.Rows[0][dsc.date_modi].ToString();
                dgs1.date_cancel = dt.Rows[0][dsc.date_cancel].ToString();
                dgs1.user_create = dt.Rows[0][dsc.user_create].ToString();
                dgs1.user_modi = dt.Rows[0][dsc.user_modi].ToString();
                dgs1.user_cancel = dt.Rows[0][dsc.user_cancel].ToString();
                
            }
            else
            {
                setDocGroupScan(dgs1);
            }
            return dgs1;
        }
        public StockReturnDetail setDocGroupScan(StockReturnDetail dgs1)
        {
            dgs1.return_detail_id = "";
            dgs1.return_id = "";
            dgs1.goods_id = "";
            dgs1.qty = "";
            dgs1.status_stock = "";
            
            dgs1.active = "";
            dgs1.remark = "";
            dgs1.date_create = "";
            dgs1.date_modi = "";
            dgs1.date_cancel = "";
            dgs1.user_create = "";
            dgs1.user_modi = "";
            dgs1.user_cancel = "";
            
            return dgs1;
        }
    }
}
