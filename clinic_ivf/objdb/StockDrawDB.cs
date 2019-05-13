using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class StockDrawDB
    {
        public StockDraw dsc;
        ConnectDB conn;
        public List<StockDraw> lDgs;

        public StockDrawDB(ConnectDB c)
        {
            this.conn = c;
            initConfig();
        }
        private void initConfig()
        {
            dsc = new StockDraw();
            lDgs = new List<StockDraw>();

            dsc.draw_id = "draw_id";
            dsc.draw_doc = "draw_doc";
            dsc.inv_ex = "inv_ex";
            dsc.description = "description";
            dsc.draw_date = "draw_date";
            dsc.comp_id = "comp_id";
            dsc.vend_id = "vend_id";
            dsc.branch_id_draw = "branch_id_draw";
            dsc.active = "active";
            dsc.remark = "remark";
            dsc.date_create = "date_create";
            dsc.date_modi = "date_modi";
            dsc.date_cancel = "date_cancel";
            dsc.user_create = "user_create";
            dsc.user_modi = "user_modi";
            dsc.user_cancel = "user_cancel";
            dsc.cust_id_rec = "cust_id_rec";
            dsc.status_stock = "status_stock";

            dsc.table = "t_stock_draw";
            dsc.pkField = "draw_id";
        }
        public void getlBsp()
        {
            //lDept = new List<Position>();

            lDgs.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                StockDraw itm1 = new StockDraw();
                itm1.draw_id = row[dsc.draw_id].ToString();
                itm1.draw_doc = row[dsc.draw_doc].ToString();
                itm1.inv_ex = row[dsc.inv_ex].ToString();
                itm1.description = row[dsc.description].ToString();
                itm1.draw_date = row[dsc.draw_date].ToString();
                itm1.comp_id = row[dsc.comp_id].ToString();
                itm1.vend_id = row[dsc.vend_id].ToString();
                itm1.branch_id_draw = row[dsc.branch_id_draw].ToString();
                itm1.active = row[dsc.active].ToString();
                itm1.remark = row[dsc.remark].ToString();
                itm1.date_create = row[dsc.date_create].ToString();
                itm1.date_modi = row[dsc.date_modi].ToString();
                itm1.date_cancel = row[dsc.date_cancel].ToString();
                itm1.user_create = row[dsc.user_create].ToString();
                itm1.user_modi = row[dsc.user_modi].ToString();
                itm1.user_cancel = row[dsc.user_cancel].ToString();
                itm1.cust_id_rec = row[dsc.cust_id_rec].ToString();
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
                "Order By draw_doc ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByHn(String id)
        {
            //StockDraw cop1 = new StockDraw();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + dsc.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + dsc.comp_id + " ='" + id + "' and dsc." + dsc.active + "='1'" +
                "Order By draw_doc ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public StockDraw selectByPk(String id)
        {
            StockDraw cop1 = new StockDraw();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + dsc.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + dsc.pkField + " ='" + id + "' " +
                "Order By draw_doc ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setDocScan(dt);
            return cop1;
        }
        public DataTable selectByPk1(String id)
        {
            StockDraw cop1 = new StockDraw();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + dsc.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + dsc.pkField + " ='" + id + "' " +
                "Order By draw_doc ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByVn(String comp_id, String vend_id, String vsDate)
        {
            StockDraw cop1 = new StockDraw();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + dsc.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + dsc.comp_id + " ='" + comp_id + "' and dsc." + dsc.vend_id + "='" + vend_id + "' and dsc." + dsc.branch_id_draw + "='" + vsDate + "' and dsc." + dsc.active + "='1'" +
                "Order By draw_doc ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByVn(String comp_id, String cust_id_rec)
        {
            StockDraw cop1 = new StockDraw();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + dsc.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + dsc.comp_id + " ='" + comp_id + "' and dsc." + dsc.vend_id + "='" + cust_id_rec + "' and dsc." + dsc.active + "='1'" +
                "Order By draw_doc ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }        
        private void chkNull(StockDraw p)
        {
            long chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.description = p.description == null ? "" : p.description;
            p.draw_date = p.draw_date == null ? "" : p.draw_date;
            p.comp_id = p.comp_id == null ? "" : p.comp_id;
            p.vend_id = p.vend_id == null ? "" : p.vend_id;
            p.branch_id_draw = p.branch_id_draw == null ? "" : p.branch_id_draw;
            p.remark = p.remark == null ? "" : p.remark;
            p.cust_id_rec = p.cust_id_rec == null ? "" : p.cust_id_rec;
            p.draw_doc = p.draw_doc == null ? "" : p.draw_doc;
            p.inv_ex = p.inv_ex == null ? "" : p.inv_ex;
            p.status_stock = p.status_stock == null ? "" : p.status_stock;
            

            p.comp_id = long.TryParse(p.comp_id, out chk) ? chk.ToString() : "0";
            p.vend_id = long.TryParse(p.vend_id, out chk) ? chk.ToString() : "0";
            p.branch_id_draw = long.TryParse(p.branch_id_draw, out chk) ? chk.ToString() : "0";
            p.cust_id_rec = long.TryParse(p.cust_id_rec, out chk) ? chk.ToString() : "0";
            //p.doctor_id = int.TryParse(p.doctor_id, out chk) ? chk.ToString() : "0";
        }
        public String insert(StockDraw p, String userId)
        {
            String re = "";
            String sql = "";
            //DataTable dt = new DataTable();
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;
            chkNull(p);
            sql = "Insert Into " + dsc.table + " set " +
                "" + dsc.draw_doc + "= '" + p.draw_doc + "'" +
                "," + dsc.active + "= '" + p.active + "'" +
                "," + dsc.inv_ex + "= '" + p.inv_ex + "'" +
                "," + dsc.description + "= '" + p.description + "'" +
                "," + dsc.draw_date + "= '" + p.draw_date + "'" +
                "," + dsc.comp_id + "= '" + p.comp_id + "'" +
                "," + dsc.vend_id + "= '" + p.vend_id + "'" +
                "," + dsc.branch_id_draw + "= '" + p.branch_id_draw + "'" +
                "," + dsc.remark + "= '" + p.remark + "'" +
                "," + dsc.date_create + "= now()" +
                "," + dsc.date_modi + "= ''" +
                "," + dsc.date_cancel + "= ''" +
                "," + dsc.user_create + "= '" + userId + "'" +
                "," + dsc.user_modi + "= ''" +
                "," + dsc.user_cancel + "= ''" +
                "," + dsc.cust_id_rec + "= '" + p.cust_id_rec + "'" +
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
        public String update(StockDraw p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            chkNull(p);
            sql = "Update " + dsc.table + " Set " +
                //" " + dsc.draw_doc + " = '" + p.draw_doc + "'" +
                "," + dsc.inv_ex + " = '" + p.inv_ex + "'" +
                "," + dsc.description + " = '" + p.description + "'" +
                "," + dsc.draw_date + " = '" + p.draw_date + "'" +
                "," + dsc.comp_id + " = '" + p.comp_id + "'" +
                "," + dsc.vend_id + " = '" + p.vend_id + "'" +
                "," + dsc.branch_id_draw + " = '" + p.branch_id_draw + "'" +
                "," + dsc.remark + " = '" + p.remark + "'" +
                "," + dsc.date_modi + " = now()" +
                "," + dsc.user_modi + " = '" + userId + "'" +
                "," + dsc.cust_id_rec + " = '" + p.cust_id_rec + "'" +
                "," + dsc.status_stock + " = '" + p.status_stock + "'" +
                
                "Where " + dsc.pkField + "='" + p.draw_id + "'"
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
        public String insertDocScan(StockDraw p, String userId)
        {
            String re = "";

            if (p.draw_id.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
            }

            return re;
        }
        public String updateImagepath(String draw_date, String id)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            //chkNull(p);
            sql = "Update " + dsc.table + " Set " +
                " " + dsc.draw_date + " = '" + draw_date + "'" +
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
        public StockDraw setDocScan(DataTable dt)
        {
            StockDraw dgs1 = new StockDraw();
            if (dt.Rows.Count > 0)
            {
                dgs1.draw_id = dt.Rows[0][dsc.draw_id].ToString();
                dgs1.draw_doc = dt.Rows[0][dsc.draw_doc].ToString();
                dgs1.inv_ex = dt.Rows[0][dsc.inv_ex].ToString();
                dgs1.description = dt.Rows[0][dsc.description].ToString();
                dgs1.draw_date = dt.Rows[0][dsc.draw_date].ToString();
                dgs1.comp_id = dt.Rows[0][dsc.comp_id].ToString();
                dgs1.vend_id = dt.Rows[0][dsc.vend_id].ToString();
                dgs1.branch_id_draw = dt.Rows[0][dsc.branch_id_draw].ToString();
                dgs1.active = dt.Rows[0][dsc.active].ToString();
                dgs1.remark = dt.Rows[0][dsc.remark].ToString();
                dgs1.date_create = dt.Rows[0][dsc.date_create].ToString();
                dgs1.date_modi = dt.Rows[0][dsc.date_modi].ToString();
                dgs1.date_cancel = dt.Rows[0][dsc.date_cancel].ToString();
                dgs1.user_create = dt.Rows[0][dsc.user_create].ToString();
                dgs1.user_modi = dt.Rows[0][dsc.user_modi].ToString();
                dgs1.user_cancel = dt.Rows[0][dsc.user_cancel].ToString();
                dgs1.cust_id_rec = dt.Rows[0][dsc.cust_id_rec].ToString();
                dgs1.status_stock = dt.Rows[0][dsc.status_stock].ToString();
                
            }
            else
            {
                setDocGroupScan(dgs1);
            }
            return dgs1;
        }
        public StockDraw setDocGroupScan(StockDraw dgs1)
        {
            dgs1.draw_id = "";
            dgs1.draw_doc = "";
            dgs1.inv_ex = "";
            dgs1.description = "";
            dgs1.draw_date = "";
            dgs1.comp_id = "";
            dgs1.vend_id = "";
            dgs1.branch_id_draw = "";
            dgs1.active = "";
            dgs1.remark = "";
            dgs1.date_create = "";
            dgs1.date_modi = "";
            dgs1.date_cancel = "";
            dgs1.user_create = "";
            dgs1.user_modi = "";
            dgs1.user_cancel = "";
            dgs1.cust_id_rec = "";
            dgs1.status_stock = "";
            
            return dgs1;
        }
    }
}
