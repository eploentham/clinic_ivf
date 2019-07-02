using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class LisDB
    {
        public Lis lis;
        ConnectDB conn;
        public List<Lis> lDgs;

        public LisDB(ConnectDB c)
        {
            this.conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lis = new Lis();
            lDgs = new List<Lis>();

            lis.lis_id = "lis_id";
            lis.barcode = "barcode";
            lis.req_id = "req_id";
            lis.visit_vn = "visit_vn";
            lis.visit_hn = "visit_hn";
            lis.patient_name = "patient_name";
            lis.visit_id = "visit_id";
            lis.message_lis = "message_lis";
            lis.active = "active";
            lis.remark = "remark";
            lis.date_create = "date_create";
            lis.date_modi = "date_modi";
            lis.date_cancel = "date_cancel";
            lis.user_create = "user_create";
            lis.user_modi = "user_modi";
            lis.user_cancel = "user_cancel";
            lis.statis_lis = "status_lis";
            lis.date_time_receive = "date_time_receive";
            lis.date_time_finish = "date_time_finish";
            lis.lab_id = "lab_id";
            //lis.status_ipd = "status_ipd";
            //lis.an_cnt = "an_cnt";
            //lis.folder_ftp = "folder_ftp";

            lis.table = "lab_t_lis";
            lis.pkField = "lis_id";
        }
        public void getlBsp()
        {
            //lDept = new List<Position>();

            lDgs.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                Lis itm1 = new Lis();
                itm1.lis_id = row[lis.lis_id].ToString();
                itm1.barcode = row[lis.barcode].ToString();
                itm1.req_id = row[lis.req_id].ToString();
                itm1.visit_vn = row[lis.visit_vn].ToString();
                itm1.visit_hn = row[lis.visit_hn].ToString();
                itm1.patient_name = row[lis.patient_name].ToString();
                itm1.visit_id = row[lis.visit_id].ToString();
                itm1.message_lis = row[lis.message_lis].ToString();
                itm1.active = row[lis.active].ToString();
                itm1.remark = row[lis.remark].ToString();
                itm1.date_create = row[lis.date_create].ToString();
                itm1.date_modi = row[lis.date_modi].ToString();
                itm1.date_cancel = row[lis.date_cancel].ToString();
                itm1.user_create = row[lis.user_create].ToString();
                itm1.user_modi = row[lis.user_modi].ToString();
                itm1.user_cancel = row[lis.user_cancel].ToString();
                itm1.statis_lis = row[lis.statis_lis].ToString();
                itm1.date_time_receive = row[lis.date_time_receive].ToString();
                itm1.date_time_finish = row[lis.date_time_finish].ToString();
                itm1.lab_id = row[lis.lab_id].ToString();
                //itm1.status_ipd = row[lis.status_ipd].ToString();
                //itm1.an_cnt = row[lis.an_cnt].ToString();
                lDgs.Add(itm1);
            }
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + lis.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                " Where dsc." + lis.active + " ='1' " +
                "Order By barcode ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByHn(String id)
        {
            //Lis cop1 = new Lis();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + lis.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + lis.patient_name + " ='" + id + "' and dsc." + lis.active + "='1'" +
                "Order By barcode ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public Lis selectByPk(String id)
        {
            Lis cop1 = new Lis();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + lis.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + lis.pkField + " ='" + id + "' " +
                "Order By barcode ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setLis(dt);
            return cop1;
        }
        public DataTable selectByPk1(String id)
        {
            Lis cop1 = new Lis();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + lis.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + lis.pkField + " ='" + id + "' " +
                "Order By barcode ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByVn(String patient_name, String visit_id, String vsDate)
        {
            Lis cop1 = new Lis();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + lis.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + lis.patient_name + " ='" + patient_name + "' and dsc." + lis.visit_id + "='" + visit_id + "' and dsc." + lis.message_lis + "='" + vsDate + "' and dsc." + lis.active + "='1'" +
                "Order By barcode ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByVn(String patient_name, String statis_lis)
        {
            Lis cop1 = new Lis();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + lis.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + lis.patient_name + " ='" + patient_name + "' and dsc." + lis.visit_id + "='" + statis_lis + "' and dsc." + lis.active + "='1'" +
                "Order By barcode ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public String selectRowNoByHn(String patient_name, String docgid)
        {
            String re = "0", re1 = "";
            int chk = 0;
            Lis cop1 = new Lis();
            DataTable dt = new DataTable();
            String sql = "select max(" + lis.req_id + ") as " + lis.req_id + " " +
                "From " + lis.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + lis.patient_name + " ='" + patient_name + "' and dsc." + lis.barcode + "='" + docgid + "' " +
                "  ";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                re1 = dt.Rows[0][lis.req_id].ToString();
                int.TryParse(re1, out chk);
                chk++;
                re = chk.ToString();
            }
            return re;
        }
        public String selectRowNoByHnVn(String patient_name, String visit_id, String docgid)
        {
            String re = "0", re1 = "";
            int chk = 0;
            Lis cop1 = new Lis();
            DataTable dt = new DataTable();
            String sql = "select max(" + lis.req_id + ") as " + lis.req_id + " " +
                "From " + lis.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + lis.patient_name + " ='" + patient_name + "' and dsc." + lis.barcode + "='" + docgid + "' and dsc." + lis.visit_id + "='" + visit_id + "' " +
                "  ";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                re1 = dt.Rows[0][lis.req_id].ToString();
                int.TryParse(re1, out chk);
                chk++;
                re = chk.ToString();
            }
            return re;
        }
        private void chkNull(Lis p)
        {
            long chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.visit_vn = p.visit_vn == null ? "" : p.visit_vn;
            p.visit_hn = p.visit_hn == null ? "" : p.visit_hn;
            p.patient_name = p.patient_name == null ? "" : p.patient_name;
            p.visit_id = p.visit_id == null ? "" : p.visit_id;
            p.message_lis = p.message_lis == null ? "" : p.message_lis;
            p.remark = p.remark == null ? "" : p.remark;
            p.statis_lis = p.statis_lis == null ? "0" : p.statis_lis;
            p.date_time_finish = p.date_time_finish == null ? "" : p.date_time_finish;
            p.lab_id = p.lab_id == null ? "" : p.lab_id;
            p.date_time_receive = p.date_time_receive == null ? "" : p.date_time_receive;
            p.barcode = p.barcode == null ? "" : p.barcode;
            //p.statis_lis = p.statis_lis == null ? "0" : p.statis_lis;

            p.barcode = long.TryParse(p.barcode, out chk) ? chk.ToString() : "0";
            p.req_id = long.TryParse(p.req_id, out chk) ? chk.ToString() : "0";
            p.lab_id = long.TryParse(p.lab_id, out chk) ? chk.ToString() : "0";
            //p.date_time_finish = int.TryParse(p.date_time_finish, out chk) ? chk.ToString() : "0";
            //p.doctor_id = int.TryParse(p.doctor_id, out chk) ? chk.ToString() : "0";
        }
        public String insert(Lis p, String userId)
        {
            String re = "";
            String sql = "";
            //DataTable dt = new DataTable();
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;
            chkNull(p);
            //lis.statis_lis = "status_lis";
            sql = "Insert Into " + lis.table + " set " +
                "" + lis.barcode + "= '" + p.barcode + "'" +
                "," + lis.active + "= '" + p.active + "'" +
                "," + lis.req_id + "= '" + p.req_id + "'" +
                "," + lis.visit_vn + "= '" + p.visit_vn + "'" +
                "," + lis.visit_hn + "= '" + p.visit_hn + "'" +
                "," + lis.patient_name + "= '" + p.patient_name + "'" +
                "," + lis.visit_id + "= '" + p.visit_id + "'" +
                "," + lis.message_lis + "= '" + p.message_lis + "'" +
                "," + lis.remark + "= '" + p.remark + "'" +
                "," + lis.date_create + "= now()" +
                "," + lis.date_modi + "= ''" +
                "," + lis.date_cancel + "= ''" +
                "," + lis.user_create + "= '" + userId + "'" +
                "," + lis.user_modi + "= ''" +
                "," + lis.user_cancel + "= ''" +
                "," + lis.statis_lis + "= '" + p.statis_lis + "'" +
                "," + lis.date_time_receive + "= '" + p.date_time_receive + "'" +
                "," + lis.date_time_finish + "= '" + p.date_time_finish + "'" +
                "," + lis.lab_id + "= '" + p.lab_id + "'" +
                //"," + lis.status_ipd + "= '" + p.status_ipd + "'" +
                //"," + lis.an_cnt + " " + "= '" + p.an_cnt + "'" +
                //"," + lis.folder_ftp + " " + "= '" + p.folder_ftp + "'" +
                "";
            try
            {
                //    conn.comStore = new System.Data.SqlClient.SqlCommand();
                //    conn.comStore.Connection = conn.conn;
                //    conn.comStore.CommandText = "insert_doc_scan";
                //    conn.comStore.CommandType = CommandType.StoredProcedure;
                //    conn.comStore.Parameters.AddWithValue("barcode", p.barcode);
                //    conn.comStore.Parameters.AddWithValue("visit_vn", p.visit_vn);
                //    conn.comStore.Parameters.AddWithValue("patient_name", p.patient_name);
                //    conn.comStore.Parameters.AddWithValue("visit_id", p.visit_id);
                //    conn.comStore.Parameters.AddWithValue("remark", p.remark);
                //    conn.comStore.Parameters.AddWithValue("user_create", userId);
                //    conn.comStore.Parameters.AddWithValue("statis_lis", p.statis_lis);
                //    conn.comStore.Parameters.AddWithValue("date_time_receive", p.date_time_receive);
                //    conn.comStore.Parameters.AddWithValue("date_time_finish", p.date_time_finish);
                //    conn.comStore.Parameters.AddWithValue("lab_id", p.lab_id);
                //    conn.comStore.Parameters.AddWithValue("status_ipd", p.status_ipd);
                //    conn.comStore.Parameters.AddWithValue("ext", p.visit_hn);
                //    conn.comStore.Parameters.AddWithValue("message_lis", p.message_lis);
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
        public String update(Lis p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            chkNull(p);
            sql = "Update " + lis.table + " Set " +
                " " + lis.barcode + " = '" + p.barcode + "'" +
                "," + lis.req_id + " = '" + p.req_id + "'" +
                "," + lis.visit_vn + " = '" + p.visit_vn + "'" +
                "," + lis.visit_hn + " = '" + p.visit_hn + "'" +
                "," + lis.patient_name + " = '" + p.patient_name + "'" +
                "," + lis.visit_id + " = '" + p.visit_id + "'" +
                "," + lis.message_lis + " = '" + p.message_lis + "'" +
                "," + lis.remark + " = '" + p.remark + "'" +
                "," + lis.date_modi + " = now()" +
                "," + lis.user_modi + " = '" + userId + "'" +
                "," + lis.statis_lis + " = '" + p.statis_lis + "'" +
                "," + lis.date_time_receive + " = '" + p.date_time_receive + "'" +
                "," + lis.date_time_finish + " = '" + p.date_time_finish + "'" +
                "," + lis.lab_id + " = '" + p.lab_id + "'" +
                //"," + lis.status_ipd + " = '" + p.status_ipd + "'" +
                //"," + lis.an_cnt + " = '" + p.an_cnt + "'" +
                //"," + lis.folder_ftp + " = '" + p.folder_ftp + "'" +
                "Where " + lis.pkField + "='" + p.lis_id + "'"
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
        public String insertLis(Lis p, String userId)
        {
            String re = "";

            if (p.lis_id.Equals(""))
            {
                re = insert(p, userId);
                updateBarcode(re);
            }
            else
            {
                re = update(p, userId);
            }

            return re;
        }
        public String updateBarcode(String id)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            //chkNull(p);
            if (id.Length >= 6)
            {
                re = id.Substring(id.Length - 6);
            }

            sql = "Update " + lis.table + " Set " +
                " " + lis.barcode + " = '" + re + "'" +
                "Where " + lis.pkField + "='" + id + "'"
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
        public String voidLis(String id, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Update " + lis.table + " Set " +
                " " + lis.active + " = '3'" +
                "," + lis.date_cancel + " = now()" +
                "," + lis.user_cancel + " = '" + userId + "'" +
                "Where " + lis.pkField + "='" + id + "'"
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
        public Lis setLis(DataTable dt)
        {
            Lis dgs1 = new Lis();
            if (dt.Rows.Count > 0)
            {
                dgs1.lis_id = dt.Rows[0][lis.lis_id].ToString();
                dgs1.barcode = dt.Rows[0][lis.barcode].ToString();
                dgs1.req_id = dt.Rows[0][lis.req_id].ToString();
                dgs1.visit_vn = dt.Rows[0][lis.visit_vn].ToString();
                dgs1.visit_hn = dt.Rows[0][lis.visit_hn].ToString();
                dgs1.patient_name = dt.Rows[0][lis.patient_name].ToString();
                dgs1.visit_id = dt.Rows[0][lis.visit_id].ToString();
                dgs1.message_lis = dt.Rows[0][lis.message_lis].ToString();
                dgs1.active = dt.Rows[0][lis.active].ToString();
                dgs1.remark = dt.Rows[0][lis.remark].ToString();
                dgs1.date_create = dt.Rows[0][lis.date_create].ToString();
                dgs1.date_modi = dt.Rows[0][lis.date_modi].ToString();
                dgs1.date_cancel = dt.Rows[0][lis.date_cancel].ToString();
                dgs1.user_create = dt.Rows[0][lis.user_create].ToString();
                dgs1.user_modi = dt.Rows[0][lis.user_modi].ToString();
                dgs1.user_cancel = dt.Rows[0][lis.user_cancel].ToString();
                dgs1.statis_lis = dt.Rows[0][lis.statis_lis].ToString();
                dgs1.date_time_receive = dt.Rows[0][lis.date_time_receive].ToString();
                dgs1.date_time_finish = dt.Rows[0][lis.date_time_finish].ToString();
                dgs1.lab_id = dt.Rows[0][lis.lab_id].ToString();
                //dgs1.status_ipd = dt.Rows[0][lis.status_ipd].ToString();
                //dgs1.an_cnt = dt.Rows[0][lis.an_cnt].ToString();
                //dgs1.folder_ftp = dt.Rows[0][lis.an_cnt].ToString();
            }
            else
            {
                setLis1(dgs1);
            }
            return dgs1;
        }
        public Lis setLis1(Lis dgs1)
        {
            dgs1.lis_id = "";
            dgs1.barcode = "";
            dgs1.req_id = "";
            dgs1.visit_vn = "";
            dgs1.visit_hn = "";
            dgs1.patient_name = "";
            dgs1.visit_id = "";
            dgs1.message_lis = "";
            dgs1.active = "";
            dgs1.remark = "";
            dgs1.date_create = "";
            dgs1.date_modi = "";
            dgs1.date_cancel = "";
            dgs1.user_create = "";
            dgs1.user_modi = "";
            dgs1.user_cancel = "";
            dgs1.statis_lis = "";
            dgs1.date_time_receive = "";
            dgs1.date_time_finish = "";
            dgs1.lab_id = "";
            //dgs1.status_ipd = "";
            //dgs1.an_cnt = "";
            //dgs1.folder_ftp = "";
            return dgs1;
        }
    }
}
