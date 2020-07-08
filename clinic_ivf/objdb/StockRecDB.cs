using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class StockRecDB
    {
        public StockRec stkr;
        ConnectDB conn;
        public List<StockRec> lStkR;

        public StockRecDB(ConnectDB c)
        {
            this.conn = c;
            initConfig();
        }
        private void initConfig()
        {
            stkr = new StockRec();
            lStkR = new List<StockRec>();

            stkr.rec_id = "rec_id";
            stkr.rec_doc = "rec_doc";
            stkr.inv_ex = "inv_ex";
            stkr.description = "description";
            stkr.rec_date = "rec_date";
            stkr.inv_ex_date = "inv_ex_date";
            stkr.comp_id = "comp_id";
            stkr.vend_id = "vend_id";
            stkr.active = "active";
            stkr.remark = "remark";
            stkr.date_create = "date_create";
            stkr.date_modi = "date_modi";
            stkr.date_cancel = "date_cancel";
            stkr.user_create = "user_create";
            stkr.user_modi = "user_modi";
            stkr.user_cancel = "user_cancel";
            stkr.branch_id = "branch_id";
            stkr.status_stock = "status_stock";
            stkr.stock_sub_id = "stock_sub_id";

            stkr.table = "t_stock_rec";
            stkr.pkField = "rec_id";
        }
        public void getlBsp()
        {
            //lDept = new List<Position>();

            lStkR.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                StockRec itm1 = new StockRec();
                itm1.rec_id = row[stkr.rec_id].ToString();
                itm1.rec_doc = row[stkr.rec_doc].ToString();
                itm1.inv_ex = row[stkr.inv_ex].ToString();
                itm1.description = row[stkr.description].ToString();
                itm1.rec_date = row[stkr.rec_date].ToString();
                itm1.inv_ex_date = row[stkr.inv_ex_date].ToString();
                itm1.comp_id = row[stkr.comp_id].ToString();
                itm1.vend_id = row[stkr.vend_id].ToString();
                itm1.active = row[stkr.active].ToString();
                itm1.remark = row[stkr.remark].ToString();
                itm1.date_create = row[stkr.date_create].ToString();
                itm1.date_modi = row[stkr.date_modi].ToString();
                itm1.date_cancel = row[stkr.date_cancel].ToString();
                itm1.user_create = row[stkr.user_create].ToString();
                itm1.user_modi = row[stkr.user_modi].ToString();
                itm1.user_cancel = row[stkr.user_cancel].ToString();
                itm1.branch_id = row[stkr.branch_id].ToString();
                itm1.status_stock = row[stkr.status_stock].ToString();
                itm1.stock_sub_id = row[stkr.stock_sub_id].ToString();
                lStkR.Add(itm1);
            }
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + stkr.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                " Where dsc." + stkr.active + " ='1' " +
                "Order By rec_doc ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByYearId(String yearid)
        {
            //StockRec cop1 = new StockRec();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + stkr.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where year(dsc." + stkr.rec_date + ") ='" + yearid + "' and dsc." + stkr.active + "='1'" +
                "Order By rec_doc ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public StockRec selectByPk(String id)
        {
            StockRec cop1 = new StockRec();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + stkr.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + stkr.pkField + " ='" + id + "' " +
                "Order By rec_doc ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setDocScan(dt);
            return cop1;
        }
        public DataTable selectByPk1(String id)
        {
            StockRec cop1 = new StockRec();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + stkr.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + stkr.pkField + " ='" + id + "' " +
                "Order By rec_doc ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        
        private void chkNull(StockRec p)
        {
            long chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.description = p.description == null ? "" : p.description;
            p.rec_date = p.rec_date == null ? "" : p.rec_date;
            p.inv_ex_date = p.inv_ex_date == null ? "" : p.inv_ex_date;
            p.comp_id = p.comp_id == null ? "" : p.comp_id;
            p.vend_id = p.vend_id == null ? "" : p.vend_id;
            p.remark = p.remark == null ? "" : p.remark;
            p.branch_id = p.branch_id == null ? "" : p.branch_id;
            p.rec_doc = p.rec_doc == null ? "" : p.rec_doc;
            p.inv_ex = p.inv_ex == null ? "" : p.inv_ex;
            p.status_stock = p.status_stock == null ? "" : p.status_stock;


            p.comp_id = long.TryParse(p.comp_id, out chk) ? chk.ToString() : "0";
            p.vend_id = long.TryParse(p.vend_id, out chk) ? chk.ToString() : "0";
            p.branch_id = long.TryParse(p.branch_id, out chk) ? chk.ToString() : "0";
            p.stock_sub_id = long.TryParse(p.stock_sub_id, out chk) ? chk.ToString() : "0";
            //p.doctor_id = int.TryParse(p.doctor_id, out chk) ? chk.ToString() : "0";
        }
        public String insert(StockRec p, String userId)
        {
            String re = "";
            String sql = "";
            //DataTable dt = new DataTable();
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;
            chkNull(p);
            sql = "Insert Into " + stkr.table + " set " +
                "" + stkr.rec_doc + "= '" + p.rec_doc + "'" +
                "," + stkr.active + "= '" + p.active + "'" +
                "," + stkr.inv_ex + "= '" + p.inv_ex + "'" +
                "," + stkr.description + "= '" + p.description + "'" +
                "," + stkr.rec_date + "= '" + p.rec_date + "'" +
                "," + stkr.inv_ex_date + "= '" + p.inv_ex_date + "'" +
                "," + stkr.comp_id + "= '" + p.comp_id + "'" +
                "," + stkr.vend_id + "= '" + p.vend_id + "'" +
                "," + stkr.remark + "= '" + p.remark + "'" +
                "," + stkr.date_create + "= now()" +
                "," + stkr.date_modi + "= ''" +
                "," + stkr.date_cancel + "= ''" +
                "," + stkr.user_create + "= '" + userId + "'" +
                "," + stkr.user_modi + "= ''" +
                "," + stkr.user_cancel + "= ''" +
                "," + stkr.branch_id + "= '" + p.branch_id + "'" +
                "," + stkr.status_stock + "= '" + p.status_stock + "'" +
                "," + stkr.stock_sub_id + "= '" + p.stock_sub_id + "'" +
                "";
            try
            {
                re = conn.ExecuteNonQuery(conn.conn, sql);
                //conn.Open();
                //    conn.comStore.ExecuteNonQuery();
                //    re = (String)conn.comStore.Parameters["row_no1"].Value;
                //    //string retunvalue = (string)sqlcomm.Parameters["@b"].Value;
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
        public String update(StockRec p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            chkNull(p);
            sql = "Update " + stkr.table + " Set " +
                //" " + dsc.rec_doc + " = '" + p.rec_doc + "'" +
                " " + stkr.inv_ex + " = '" + p.inv_ex + "'" +
                "," + stkr.description + " = '" + p.description + "'" +
                "," + stkr.rec_date + " = '" + p.rec_date + "'" +
                "," + stkr.inv_ex_date + " = '" + p.inv_ex_date + "'" +
                "," + stkr.comp_id + " = '" + p.comp_id + "'" +
                "," + stkr.vend_id + " = '" + p.vend_id + "'" +
                "," + stkr.remark + " = '" + p.remark + "'" +
                "," + stkr.date_modi + " = now()" +
                "," + stkr.user_modi + " = '" + userId + "'" +
                "," + stkr.branch_id + " = '" + p.branch_id + "'" +
                "," + stkr.status_stock + " = '" + p.status_stock + "'" +
                "," + stkr.stock_sub_id + "= '" + p.stock_sub_id + "'" +
                "Where " + stkr.pkField + "='" + p.rec_id + "'"
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
        public String insertStockRec(StockRec p, String userId)
        {
            String re = "";

            if (p.rec_id.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
            }

            return re;
        }
        public String updateRecDoc(String id, String doc)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            //chkNull(p);

            sql = "Update " + stkr.table + " Set " +
                " " + stkr.rec_doc + " = '" + doc + "'" +
                "," + stkr.status_stock + " = '2'" +
                "Where " + stkr.pkField + "='" + id + "'"
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

            sql = "Update " + stkr.table + " Set " +
                " " + stkr.active + " = '3'" +
                "," + stkr.date_cancel + " = getdate()" +
                "," + stkr.user_cancel + " = '" + userId + "'" +
                "Where " + stkr.pkField + "='" + id + "'"
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
        public StockRec setDocScan(DataTable dt)
        {
            StockRec dgs1 = new StockRec();
            if (dt.Rows.Count > 0)
            {
                dgs1.rec_id = dt.Rows[0][stkr.rec_id].ToString();
                dgs1.rec_doc = dt.Rows[0][stkr.rec_doc].ToString();
                dgs1.inv_ex = dt.Rows[0][stkr.inv_ex].ToString();
                dgs1.description = dt.Rows[0][stkr.description].ToString();
                dgs1.rec_date = dt.Rows[0][stkr.rec_date].ToString();
                dgs1.inv_ex_date = dt.Rows[0][stkr.inv_ex_date].ToString();
                dgs1.comp_id = dt.Rows[0][stkr.comp_id].ToString();
                dgs1.vend_id = dt.Rows[0][stkr.vend_id].ToString();
                dgs1.active = dt.Rows[0][stkr.active].ToString();
                dgs1.remark = dt.Rows[0][stkr.remark].ToString();
                dgs1.date_create = dt.Rows[0][stkr.date_create].ToString();
                dgs1.date_modi = dt.Rows[0][stkr.date_modi].ToString();
                dgs1.date_cancel = dt.Rows[0][stkr.date_cancel].ToString();
                dgs1.user_create = dt.Rows[0][stkr.user_create].ToString();
                dgs1.user_modi = dt.Rows[0][stkr.user_modi].ToString();
                dgs1.user_cancel = dt.Rows[0][stkr.user_cancel].ToString();
                dgs1.branch_id = dt.Rows[0][stkr.branch_id].ToString();
                dgs1.status_stock = dt.Rows[0][stkr.status_stock].ToString();
                dgs1.stock_sub_id = dt.Rows[0][stkr.stock_sub_id].ToString();
            }
            else
            {
                setDocGroupScan(dgs1);
            }
            return dgs1;
        }
        public StockRec setDocGroupScan(StockRec dgs1)
        {
            dgs1.rec_id = "";
            dgs1.rec_doc = "";
            dgs1.inv_ex = "";
            dgs1.description = "";
            dgs1.rec_date = "";
            dgs1.inv_ex_date = "";
            dgs1.comp_id = "";
            dgs1.vend_id = "";
            dgs1.active = "";
            dgs1.remark = "";
            dgs1.date_create = "";
            dgs1.date_modi = "";
            dgs1.date_cancel = "";
            dgs1.user_create = "";
            dgs1.user_modi = "";
            dgs1.user_cancel = "";
            dgs1.branch_id = "";
            dgs1.status_stock = "";
            dgs1.stock_sub_id = "";
            return dgs1;
        }
    }
}
