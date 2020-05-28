using C1.Win.C1Input;
using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class StockSubNameDB
    {
        public StockSubName stkn;
        ConnectDB conn;
        public List<StockSubName> lDgs;
        public StockSubNameDB(ConnectDB c)
        {
            this.conn = c;
            initConfig();
        }
        private void initConfig()
        {
            stkn = new StockSubName();
            lDgs = new List<StockSubName>();

            stkn.stock_sub_id = "stock_sub_id";
            stkn.stock_sub_name = "stock_sub_name";
            stkn.sort1 = "sort1";
            stkn.active = "active";
            stkn.remark = "remark";
            stkn.date_create = "date_create";
            stkn.date_modi = "date_modi";
            stkn.date_cancel = "date_cancel";
            stkn.user_create = "user_create";
            stkn.user_modi = "user_modi";
            stkn.user_cancel = "user_cancel";

            stkn.table = "b_stock_sub";
            stkn.pkField = "stock_sub_id";
        }
        public void getlBsp()
        {
            //lDept = new List<Position>();

            lDgs.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                StockSubName itm1 = new StockSubName();
                itm1.stock_sub_id = row[stkn.stock_sub_id].ToString();
                itm1.stock_sub_name = row[stkn.stock_sub_name].ToString();
                itm1.stock_sub_column_name = row[stkn.stock_sub_column_name].ToString();
                itm1.sort1 = row[stkn.sort1].ToString();
                itm1.active = row[stkn.active].ToString();
                itm1.remark = row[stkn.remark].ToString();
                itm1.date_create = row[stkn.date_create].ToString();
                itm1.date_modi = row[stkn.date_modi].ToString();
                itm1.date_cancel = row[stkn.date_cancel].ToString();
                itm1.user_create = row[stkn.user_create].ToString();
                itm1.user_modi = row[stkn.user_modi].ToString();
                itm1.user_cancel = row[stkn.user_cancel].ToString();                
                lDgs.Add(itm1);
            }
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + stkn.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                " Where dsc." + stkn.active + " ='1' " +
                "Order By sort1 ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }        
        public StockSubName selectByPk(String id)
        {
            StockSubName cop1 = new StockSubName();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + stkn.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + stkn.pkField + " ='" + id + "' " +
                "Order By stock_sub_name ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setDocScan(dt);
            return cop1;
        }
        public DataTable selectByPk1(String id)
        {
            StockSubName cop1 = new StockSubName();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + stkn.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + stkn.pkField + " ='" + id + "' " +
                "Order By stock_sub_name ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        private void chkNull(StockSubName p)
        {
            long chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.sort1 = p.sort1 == null ? "" : p.sort1;
            
            p.remark = p.remark == null ? "" : p.remark;            

            p.stock_sub_name = long.TryParse(p.stock_sub_name, out chk) ? chk.ToString() : "0";
            p.stock_sub_column_name = long.TryParse(p.stock_sub_column_name, out chk) ? chk.ToString() : "0";
            
        }
        public String insert(StockSubName p, String userId)
        {
            String re = "";
            String sql = "";
            //DataTable dt = new DataTable();
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;
            chkNull(p);
            sql = "Insert Into " + stkn.table + " set " +
                "" + stkn.stock_sub_name + "= '" + p.stock_sub_name + "'" +
                "," + stkn.active + "= '" + p.active + "'" +
                "," + stkn.sort1 + "= '" + p.sort1 + "'" +
                "," + stkn.remark + "= '" + p.remark + "'" +
                "," + stkn.date_create + "= now()" +
                "," + stkn.date_modi + "= ''" +
                "," + stkn.date_cancel + "= ''" +
                "," + stkn.user_create + "= '" + userId + "'" +
                "," + stkn.user_modi + "= ''" +
                "," + stkn.user_cancel + "= ''" +
                "";
            try
            {
                //    conn.comStore = new System.Data.SqlClient.SqlCommand();
                //    conn.comStore.Connection = conn.conn;
                //    conn.comStore.CommandText = "insert_doc_scan";
                //    conn.comStore.CommandType = CommandType.StoredProcedure;
                //    conn.comStore.Parameters.AddWithValue("stock_sub_name", p.stock_sub_name);
                //    conn.comStore.Parameters.AddWithValue("sort1", p.sort1);
                //    conn.comStore.Parameters.AddWithValue("hn", p.hn);
                //    conn.comStore.Parameters.AddWithValue("vn", p.vn);
                //    conn.comStore.Parameters.AddWithValue("remark", p.remark);
                //    conn.comStore.Parameters.AddWithValue("user_create", userId);
                //    conn.comStore.Parameters.AddWithValue("an", p.an);
                //    conn.comStore.Parameters.AddWithValue("doc_group_sub_id", p.doc_group_sub_id);
                //    conn.comStore.Parameters.AddWithValue("pre_no", p.pre_no);
                //    conn.comStore.Parameters.AddWithValue("an_date", p.an_date);
                //    conn.comStore.Parameters.AddWithValue("status_ipd", p.status_ipd);
                //    conn.comStore.Parameters.AddWithValue("ext", p.image_path);
                //    conn.comStore.Parameters.AddWithValue("visit_date", p.visit_date);
                //    SqlParameter retval =  conn.comStore.Parameters.Add("row_no1", SqlDbType.VarChar, 50);
                //    retval.Value = "";
                //    retval.Direction = ParameterDirection.Output;

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
        public String update(StockSubName p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            chkNull(p);
            sql = "Update " + stkn.table + " Set " +
                " " + stkn.stock_sub_name + " = '" + p.stock_sub_name + "'" +
                "," + stkn.sort1 + " = '" + p.sort1 + "'" +
                "," + stkn.remark + " = '" + p.remark + "'" +
                "," + stkn.date_modi + " = now()" +
                "," + stkn.user_modi + " = '" + userId + "'" +
                "Where " + stkn.pkField + "='" + p.stock_sub_id + "'"
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
        public String insertDocScan(StockSubName p, String userId)
        {
            String re = "";

            if (p.stock_sub_id.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
            }

            return re;
        }
        public String voidDocScan(String id, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Update " + stkn.table + " Set " +
                " " + stkn.active + " = '3'" +
                "," + stkn.date_cancel + " = getdate()" +
                "," + stkn.user_cancel + " = '" + userId + "'" +
                "Where " + stkn.pkField + "='" + id + "'"
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
        public C1ComboBox setCboStockSubName(C1ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectAll();
            //String aaa = "";
            //ComboBoxItem item1 = new ComboBoxItem();
            ComboBoxItem item2 = new ComboBoxItem();
            //item1.Text = "";
            //item1.Value = "";
            c.Items.Clear();
            //c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                item = new ComboBoxItem();
                item.Text = row[stkn.stock_sub_name].ToString();
                item.Value = row[stkn.stock_sub_id].ToString();
                if (i == 0)
                {
                    item2.Text = row[stkn.stock_sub_name].ToString();
                    item2.Value = row[stkn.stock_sub_id].ToString();
                }
                c.Items.Add(item);
                i++;
            }

            c.SelectedItem = item2;
            return c;
        }
        public StockSubName setDocScan(DataTable dt)
        {
            StockSubName dgs1 = new StockSubName();
            if (dt.Rows.Count > 0)
            {
                dgs1.stock_sub_id = dt.Rows[0][stkn.stock_sub_id].ToString();
                dgs1.stock_sub_name = dt.Rows[0][stkn.stock_sub_name].ToString();
                dgs1.sort1 = dt.Rows[0][stkn.sort1].ToString();
                
                dgs1.active = dt.Rows[0][stkn.active].ToString();
                dgs1.remark = dt.Rows[0][stkn.remark].ToString();
                dgs1.date_create = dt.Rows[0][stkn.date_create].ToString();
                dgs1.date_modi = dt.Rows[0][stkn.date_modi].ToString();
                dgs1.date_cancel = dt.Rows[0][stkn.date_cancel].ToString();
                dgs1.user_create = dt.Rows[0][stkn.user_create].ToString();
                dgs1.user_modi = dt.Rows[0][stkn.user_modi].ToString();
                dgs1.user_cancel = dt.Rows[0][stkn.user_cancel].ToString();
                
            }
            else
            {
                setDocGroupScan(dgs1);
            }
            return dgs1;
        }
        public StockSubName setDocGroupScan(StockSubName dgs1)
        {
            dgs1.stock_sub_id = "";
            dgs1.stock_sub_name = "";
            dgs1.sort1 = "";
            
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
