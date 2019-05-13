using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class StockReturnDB
    {
        public StockReturn dsc;
        ConnectDB conn;
        public List<StockReturn> lDgs;

        public StockReturnDB(ConnectDB c)
        {
            this.conn = c;
            initConfig();
        }
        private void initConfig()
        {
            dsc = new StockReturn();
            lDgs = new List<StockReturn>();

            dsc.return_id = "return_id";
            dsc.return_doc = "return_doc";
            dsc.draw_id = "draw_id";
            dsc.return_date = "return_date";
            dsc.description = "description";
            dsc.comp_id = "comp_id";
            dsc.branch_id = "branch_id";
            dsc.status_stock = "status_stock";
            dsc.active = "active";
            dsc.remark = "remark";
            dsc.date_create = "date_create";
            dsc.date_modi = "date_modi";
            dsc.date_cancel = "date_cancel";
            dsc.user_create = "user_create";
            dsc.user_modi = "user_modi";
            dsc.user_cancel = "user_cancel";
            dsc.cust_id_return = "cust_id_return";

            dsc.table = "t_doc_scan";
            dsc.pkField = "return_id";
        }
        public void getlBsp()
        {
            //lDept = new List<Position>();

            lDgs.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                StockReturn itm1 = new StockReturn();
                itm1.return_id = row[dsc.return_id].ToString();
                itm1.return_doc = row[dsc.return_doc].ToString();
                itm1.draw_id = row[dsc.draw_id].ToString();
                itm1.return_date = row[dsc.return_date].ToString();
                itm1.description = row[dsc.description].ToString();
                itm1.comp_id = row[dsc.comp_id].ToString();
                itm1.branch_id = row[dsc.branch_id].ToString();
                itm1.status_stock = row[dsc.status_stock].ToString();
                itm1.active = row[dsc.active].ToString();
                itm1.remark = row[dsc.remark].ToString();
                itm1.date_create = row[dsc.date_create].ToString();
                itm1.date_modi = row[dsc.date_modi].ToString();
                itm1.date_cancel = row[dsc.date_cancel].ToString();
                itm1.user_create = row[dsc.user_create].ToString();
                itm1.user_modi = row[dsc.user_modi].ToString();
                itm1.user_cancel = row[dsc.user_cancel].ToString();
                itm1.cust_id_return = row[dsc.cust_id_return].ToString();
                
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
                "Order By return_doc ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByHn(String id)
        {
            //StockReturn cop1 = new StockReturn();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + dsc.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + dsc.comp_id + " ='" + id + "' and dsc." + dsc.active + "='1'" +
                "Order By return_doc ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public StockReturn selectByPk(String id)
        {
            StockReturn cop1 = new StockReturn();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + dsc.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + dsc.pkField + " ='" + id + "' " +
                "Order By return_doc ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setDocScan(dt);
            return cop1;
        }
        public DataTable selectByPk1(String id)
        {
            StockReturn cop1 = new StockReturn();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + dsc.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + dsc.pkField + " ='" + id + "' " +
                "Order By return_doc ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByVn(String comp_id, String branch_id, String vsDate)
        {
            StockReturn cop1 = new StockReturn();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + dsc.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + dsc.comp_id + " ='" + comp_id + "' and dsc." + dsc.branch_id + "='" + branch_id + "' and dsc." + dsc.status_stock + "='" + vsDate + "' and dsc." + dsc.active + "='1'" +
                "Order By return_doc ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByVn(String comp_id, String cust_id_return)
        {
            StockReturn cop1 = new StockReturn();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + dsc.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + dsc.comp_id + " ='" + comp_id + "' and dsc." + dsc.branch_id + "='" + cust_id_return + "' and dsc." + dsc.active + "='1'" +
                "Order By return_doc ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public String selectRowNoByHn(String comp_id, String docgid)
        {
            String re = "0", re1 = "";
            int chk = 0;
            StockReturn cop1 = new StockReturn();
            DataTable dt = new DataTable();
            String sql = "select max(" + dsc.draw_id + ") as " + dsc.draw_id + " " +
                "From " + dsc.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + dsc.comp_id + " ='" + comp_id + "' and dsc." + dsc.return_doc + "='" + docgid + "' " +
                "  ";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                re1 = dt.Rows[0][dsc.draw_id].ToString();
                int.TryParse(re1, out chk);
                chk++;
                re = chk.ToString();
            }
            return re;
        }
        public String selectRowNoByHnVn(String comp_id, String branch_id, String docgid)
        {
            String re = "0", re1 = "";
            int chk = 0;
            StockReturn cop1 = new StockReturn();
            DataTable dt = new DataTable();
            String sql = "select max(" + dsc.draw_id + ") as " + dsc.draw_id + " " +
                "From " + dsc.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + dsc.comp_id + " ='" + comp_id + "' and dsc." + dsc.return_doc + "='" + docgid + "' and dsc." + dsc.branch_id + "='" + branch_id + "' " +
                "  ";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                re1 = dt.Rows[0][dsc.draw_id].ToString();
                int.TryParse(re1, out chk);
                chk++;
                re = chk.ToString();
            }
            return re;
        }
        private void chkNull(StockReturn p)
        {
            long chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.return_date = p.return_date == null ? "" : p.return_date;
            p.description = p.description == null ? "" : p.description;
            p.comp_id = p.comp_id == null ? "" : p.comp_id;
            p.branch_id = p.branch_id == null ? "" : p.branch_id;
            p.status_stock = p.status_stock == null ? "" : p.status_stock;
            p.remark = p.remark == null ? "" : p.remark;
            p.cust_id_return = p.cust_id_return == null ? "" : p.cust_id_return;
            p.return_doc = p.return_doc == null ? "" : p.return_doc;

            p.branch_id = long.TryParse(p.branch_id, out chk) ? chk.ToString() : "0";
            p.draw_id = long.TryParse(p.draw_id, out chk) ? chk.ToString() : "0";
            p.comp_id = long.TryParse(p.comp_id, out chk) ? chk.ToString() : "0";
            p.cust_id_return = long.TryParse(p.cust_id_return, out chk) ? chk.ToString() : "0";
            //p.doctor_id = int.TryParse(p.doctor_id, out chk) ? chk.ToString() : "0";
        }
        public String insert(StockReturn p, String userId)
        {
            String re = "";
            String sql = "";
            //DataTable dt = new DataTable();
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;
            chkNull(p);
            sql = "Insert Into " + dsc.table + " set " +
                "" + dsc.return_doc + "= '" + p.return_doc + "'" +
                "," + dsc.active + "= '" + p.active + "'" +
                "," + dsc.draw_id + "= '" + p.draw_id + "'" +
                "," + dsc.return_date + "= '" + p.return_date + "'" +
                "," + dsc.description + "= '" + p.description + "'" +
                "," + dsc.comp_id + "= '" + p.comp_id + "'" +
                "," + dsc.branch_id + "= '" + p.branch_id + "'" +
                "," + dsc.status_stock + "= '" + p.status_stock + "'" +
                "," + dsc.remark + "= '" + p.remark + "'" +
                "," + dsc.date_create + "= now()" +
                "," + dsc.date_modi + "= ''" +
                "," + dsc.date_cancel + "= ''" +
                "," + dsc.user_create + "= '" + userId + "'" +
                "," + dsc.user_modi + "= ''" +
                "," + dsc.user_cancel + "= ''" +
                "," + dsc.cust_id_return + "= '" + p.cust_id_return + "'" +
                
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
        public String update(StockReturn p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            chkNull(p);
            sql = "Update " + dsc.table + " Set " +
                " " + dsc.return_doc + " = '" + p.return_doc + "'" +
                "," + dsc.draw_id + " = '" + p.draw_id + "'" +
                "," + dsc.return_date + " = '" + p.return_date + "'" +
                "," + dsc.description + " = '" + p.description + "'" +
                "," + dsc.comp_id + " = '" + p.comp_id + "'" +
                "," + dsc.branch_id + " = '" + p.branch_id + "'" +
                "," + dsc.status_stock + " = '" + p.status_stock + "'" +
                "," + dsc.remark + " = '" + p.remark + "'" +
                "," + dsc.date_modi + " = now()" +
                "," + dsc.user_modi + " = '" + userId + "'" +
                "," + dsc.cust_id_return + " = '" + p.cust_id_return + "'" +
                
                "Where " + dsc.pkField + "='" + p.return_id + "'"
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
        public String insertDocScan(StockReturn p, String userId)
        {
            String re = "";

            if (p.return_id.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
            }

            return re;
        }
        public String updateImagepath(String description, String id)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            //chkNull(p);
            sql = "Update " + dsc.table + " Set " +
                " " + dsc.description + " = '" + description + "'" +
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
        public StockReturn setDocScan(DataTable dt)
        {
            StockReturn dgs1 = new StockReturn();
            if (dt.Rows.Count > 0)
            {
                dgs1.return_id = dt.Rows[0][dsc.return_id].ToString();
                dgs1.return_doc = dt.Rows[0][dsc.return_doc].ToString();
                dgs1.draw_id = dt.Rows[0][dsc.draw_id].ToString();
                dgs1.return_date = dt.Rows[0][dsc.return_date].ToString();
                dgs1.description = dt.Rows[0][dsc.description].ToString();
                dgs1.comp_id = dt.Rows[0][dsc.comp_id].ToString();
                dgs1.branch_id = dt.Rows[0][dsc.branch_id].ToString();
                dgs1.status_stock = dt.Rows[0][dsc.status_stock].ToString();
                dgs1.active = dt.Rows[0][dsc.active].ToString();
                dgs1.remark = dt.Rows[0][dsc.remark].ToString();
                dgs1.date_create = dt.Rows[0][dsc.date_create].ToString();
                dgs1.date_modi = dt.Rows[0][dsc.date_modi].ToString();
                dgs1.date_cancel = dt.Rows[0][dsc.date_cancel].ToString();
                dgs1.user_create = dt.Rows[0][dsc.user_create].ToString();
                dgs1.user_modi = dt.Rows[0][dsc.user_modi].ToString();
                dgs1.user_cancel = dt.Rows[0][dsc.user_cancel].ToString();
                dgs1.cust_id_return = dt.Rows[0][dsc.cust_id_return].ToString();
                
            }
            else
            {
                setDocGroupScan(dgs1);
            }
            return dgs1;
        }
        public StockReturn setDocGroupScan(StockReturn dgs1)
        {
            dgs1.return_id = "";
            dgs1.return_doc = "";
            dgs1.draw_id = "";
            dgs1.return_date = "";
            dgs1.description = "";
            dgs1.comp_id = "";
            dgs1.branch_id = "";
            dgs1.status_stock = "";
            dgs1.active = "";
            dgs1.remark = "";
            dgs1.date_create = "";
            dgs1.date_modi = "";
            dgs1.date_cancel = "";
            dgs1.user_create = "";
            dgs1.user_modi = "";
            dgs1.user_cancel = "";
            dgs1.cust_id_return = "";
            
            return dgs1;
        }
    }
}
