using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class LabResultDB
    {
        public LabResult labR;
        ConnectDB conn;
        public List<LabResult> lDgs;

        public LabResultDB(ConnectDB c)
        {
            this.conn = c;
            initConfig();
        }
        private void initConfig()
        {
            labR = new LabResult();
            lDgs = new List<LabResult>();

            labR.result_id = "result_id";
            labR.lis_id = "lis_id";
            labR.req_id = "req_id";
            labR.visit_id = "visit_id";
            labR.patient_id = "patient_id";
            labR.lab_id = "lab_id";
            labR.result = "result";
            labR.method = "method";
            labR.active = "active";
            labR.remark = "remark";
            labR.date_create = "date_create";
            labR.date_modi = "date_modi";
            labR.date_cancel = "date_cancel";
            labR.user_create = "user_create";
            labR.user_modi = "user_modi";
            labR.user_cancel = "user_cancel";
            labR.unit = "unit";
            labR.sort1 = "sort1";
            labR.staff_id_result = "staff_id_result";
            labR.staff_id_approve = "staff_id_approve";
            labR.date_time_result = "date_time_result";
            labR.date_time_approve = "date_time_approve";
            labR.normal_value = "normal_value";
            labR.interpret = "interpret";

            labR.table = "lab_t_result";
            labR.pkField = "result_id";
        }
        public void getlBsp()
        {
            //lDept = new List<Position>();

            lDgs.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                LabResult itm1 = new LabResult();
                itm1.result_id = row[labR.result_id].ToString();
                itm1.lis_id = row[labR.lis_id].ToString();
                itm1.req_id = row[labR.req_id].ToString();
                itm1.visit_id = row[labR.visit_id].ToString();
                itm1.patient_id = row[labR.patient_id].ToString();
                itm1.lab_id = row[labR.lab_id].ToString();
                itm1.result = row[labR.result].ToString();
                itm1.method = row[labR.method].ToString();
                itm1.active = row[labR.active].ToString();
                itm1.remark = row[labR.remark].ToString();
                itm1.date_create = row[labR.date_create].ToString();
                itm1.date_modi = row[labR.date_modi].ToString();
                itm1.date_cancel = row[labR.date_cancel].ToString();
                itm1.user_create = row[labR.user_create].ToString();
                itm1.user_modi = row[labR.user_modi].ToString();
                itm1.user_cancel = row[labR.user_cancel].ToString();
                itm1.unit = row[labR.unit].ToString();
                itm1.sort1 = row[labR.sort1].ToString();
                itm1.staff_id_result = row[labR.staff_id_result].ToString();
                itm1.staff_id_approve = row[labR.staff_id_approve].ToString();
                itm1.date_time_result = row[labR.date_time_result].ToString();
                itm1.date_time_approve = row[labR.date_time_approve].ToString();
                itm1.normal_value = row[labR.normal_value].ToString();
                itm1.interpret = row[labR.interpret].ToString();
                lDgs.Add(itm1);
            }
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + labR.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                " Where dsc." + labR.active + " ='1' " +
                "Order By lis_id ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByHn(String id)
        {
            //LabResult cop1 = new LabResult();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + labR.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + labR.lab_id + " ='" + id + "' and dsc." + labR.active + "='1'" +
                "Order By lis_id ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public LabResult selectByPk(String id)
        {
            LabResult cop1 = new LabResult();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + labR.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + labR.pkField + " ='" + id + "' " +
                "Order By lis_id ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setLabResult(dt);
            return cop1;
        }
        public DataTable selectByPk1(String id)
        {
            LabResult cop1 = new LabResult();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + labR.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + labR.pkField + " ='" + id + "' " +
                "Order By lis_id ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByVn(String lab_id, String result, String vsDate)
        {
            LabResult cop1 = new LabResult();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + labR.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + labR.lab_id + " ='" + lab_id + "' and dsc." + labR.result + "='" + result + "' and dsc." + labR.method + "='" + vsDate + "' and dsc." + labR.active + "='1'" +
                "Order By lis_id ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByVn(String lab_id, String unit)
        {
            LabResult cop1 = new LabResult();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + labR.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + labR.lab_id + " ='" + lab_id + "' and dsc." + labR.result + "='" + unit + "' and dsc." + labR.active + "='1'" +
                "Order By lis_id ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public String selectRowNoByHn(String lab_id, String docgid)
        {
            String re = "0", re1 = "";
            int chk = 0;
            LabResult cop1 = new LabResult();
            DataTable dt = new DataTable();
            String sql = "select max(" + labR.req_id + ") as " + labR.req_id + " " +
                "From " + labR.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + labR.lab_id + " ='" + lab_id + "' and dsc." + labR.lis_id + "='" + docgid + "' " +
                "  ";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                re1 = dt.Rows[0][labR.req_id].ToString();
                int.TryParse(re1, out chk);
                chk++;
                re = chk.ToString();
            }
            return re;
        }
        public String selectRowNoByHnVn(String lab_id, String result, String docgid)
        {
            String re = "0", re1 = "";
            int chk = 0;
            LabResult cop1 = new LabResult();
            DataTable dt = new DataTable();
            String sql = "select max(" + labR.req_id + ") as " + labR.req_id + " " +
                "From " + labR.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + labR.lab_id + " ='" + lab_id + "' and dsc." + labR.lis_id + "='" + docgid + "' and dsc." + labR.result + "='" + result + "' " +
                "  ";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                re1 = dt.Rows[0][labR.req_id].ToString();
                int.TryParse(re1, out chk);
                chk++;
                re = chk.ToString();
            }
            return re;
        }
        private void chkNull(LabResult p)
        {
            long chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.visit_id = p.visit_id == null ? "" : p.visit_id;
            //p.patient_id = p.patient_id == null ? "" : p.patient_id;
            //p.lab_id = p.lab_id == null ? "" : p.lab_id;
            p.result = p.result == null ? "" : p.result;
            p.method = p.method == null ? "" : p.method;
            p.remark = p.remark == null ? "" : p.remark;
            p.unit = p.unit == null ? "" : p.unit;
            p.interpret = p.interpret == null ? "" : p.interpret;
            //p.normal_value = p.normal_value == null ? "" : p.normal_value;
            p.date_time_result = p.date_time_result == null ? "" : p.date_time_result;
            p.date_time_approve = p.date_time_approve == null ? "" : p.date_time_approve;
            p.normal_value = p.normal_value == null ? "" : p.normal_value;

            p.lis_id = long.TryParse(p.lis_id, out chk) ? chk.ToString() : "0";
            p.req_id = long.TryParse(p.req_id, out chk) ? chk.ToString() : "0";
            p.sort1 = long.TryParse(p.sort1, out chk) ? chk.ToString() : "0";
            p.staff_id_result = long.TryParse(p.staff_id_result, out chk) ? chk.ToString() : "0";
            p.staff_id_approve = long.TryParse(p.staff_id_approve, out chk) ? chk.ToString() : "0";
            p.lab_id = long.TryParse(p.lab_id, out chk) ? chk.ToString() : "0";
            p.patient_id = long.TryParse(p.patient_id, out chk) ? chk.ToString() : "0";
            p.visit_id = long.TryParse(p.visit_id, out chk) ? chk.ToString() : "0";
        }
        public String insert(LabResult p, String userId)
        {
            String re = "";
            String sql = "";
            //DataTable dt = new DataTable();
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;
            chkNull(p);
            sql = "Insert Into " + labR.table + " set " +
                "" + labR.lis_id + "= '" + p.lis_id + "'" +
                "," + labR.active + "= '" + p.active + "'" +
                "," + labR.req_id + "= '" + p.req_id + "'" +
                "," + labR.visit_id + "= '" + p.visit_id + "'" +
                "," + labR.patient_id + "= '" + p.patient_id + "'" +
                "," + labR.lab_id + "= '" + p.lab_id + "'" +
                "," + labR.result + "= '" + p.result + "'" +
                "," + labR.method + "= '" + p.method + "'" +
                "," + labR.remark + "= '" + p.remark + "'" +
                "," + labR.date_create + "= now()" +
                "," + labR.date_modi + "= ''" +
                "," + labR.date_cancel + "= ''" +
                "," + labR.user_create + "= '" + userId + "@" + conn._IPAddress + "'" +
                "," + labR.user_modi + "= ''" +
                "," + labR.user_cancel + "= ''" +
                "," + labR.unit + "= '" + p.unit + "'" +
                "," + labR.sort1 + "= '" + p.sort1 + "'" +
                "," + labR.staff_id_result + "= '" + p.staff_id_result + "'" +
                "," + labR.staff_id_approve + "= '" + p.staff_id_approve + "'" +
                "," + labR.date_time_result + "= '" + p.date_time_result + "'" +
                "," + labR.date_time_approve + " " + "= '" + p.date_time_approve + "'" +
                "," + labR.normal_value + " " + "= '" + p.normal_value + "'" +
                "," + labR.interpret + " " + "= '" + p.interpret + "'" +
                //"," + labR.unit + " " + "= '" + p.unit + "'" +
                "";
            try
            {
                //    conn.comStore = new System.Data.SqlClient.SqlCommand();
                //    conn.comStore.Connection = conn.conn;
                //    conn.comStore.CommandText = "insert_doc_scan";
                //    conn.comStore.CommandType = CommandType.StoredProcedure;
                //    conn.comStore.Parameters.AddWithValue("lis_id", p.lis_id);
                //    conn.comStore.Parameters.AddWithValue("visit_id", p.visit_id);
                //    conn.comStore.Parameters.AddWithValue("lab_id", p.lab_id);
                //    conn.comStore.Parameters.AddWithValue("result", p.result);
                //    conn.comStore.Parameters.AddWithValue("remark", p.remark);
                //    conn.comStore.Parameters.AddWithValue("user_create", userId);
                //    conn.comStore.Parameters.AddWithValue("unit", p.unit);
                //    conn.comStore.Parameters.AddWithValue("sort1", p.sort1);
                //    conn.comStore.Parameters.AddWithValue("staff_id_result", p.staff_id_result);
                //    conn.comStore.Parameters.AddWithValue("staff_id_approve", p.staff_id_approve);
                //    conn.comStore.Parameters.AddWithValue("date_time_result", p.date_time_result);
                //    conn.comStore.Parameters.AddWithValue("ext", p.patient_id);
                //    conn.comStore.Parameters.AddWithValue("method", p.method);
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
        public String update(LabResult p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            chkNull(p);
            sql = "Update " + labR.table + " Set " +
                " " + labR.lis_id + " = '" + p.lis_id + "'" +
                "," + labR.req_id + " = '" + p.req_id + "'" +
                "," + labR.visit_id + " = '" + p.visit_id + "'" +
                "," + labR.patient_id + " = '" + p.patient_id + "'" +
                "," + labR.lab_id + " = '" + p.lab_id + "'" +
                "," + labR.result + " = '" + p.result + "'" +
                "," + labR.method + " = '" + p.method + "'" +
                "," + labR.remark + " = '" + p.remark + "'" +
                "," + labR.date_modi + " = now()" +
                "," + labR.user_modi + " = '" + userId + "'" +
                "," + labR.unit + " = '" + p.unit + "'" +
                "," + labR.sort1 + " = '" + p.sort1 + "'" +
                "," + labR.staff_id_result + " = '" + p.staff_id_result + "'" +
                "," + labR.staff_id_approve + " = '" + p.staff_id_approve + "'" +
                "," + labR.date_time_result + " = '" + p.date_time_result + "'" +
                "," + labR.date_time_approve + " = '" + p.date_time_approve + "'" +
                "," + labR.normal_value + " = '" + p.normal_value + "'" +
                //"," + labR.normal_value + " " + "= '" + p.normal_value + "'" +
                "," + labR.interpret + " " + "= '" + p.interpret + "'" +
                "Where " + labR.pkField + "='" + p.result_id + "'"
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
        public String insertLabResult(LabResult p, String userId)
        {
            String re = "";

            if (p.result_id.Equals(""))
            {
                re = insert(p, userId);
            }
            else
            {
                re = update(p, userId);
            }

            return re;
        }
        public String updateImagepath(String patient_id, String id)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            //chkNull(p);
            sql = "Update " + labR.table + " Set " +
                " " + labR.patient_id + " = '" + patient_id + "'" +
                "Where " + labR.pkField + "='" + id + "'"
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
        public String voidLabResult(String id, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Update " + labR.table + " Set " +
                " " + labR.active + " = '3'" +
                "," + labR.date_cancel + " = now()" +
                "," + labR.user_cancel + " = '" + userId + "'" +
                "Where " + labR.pkField + "='" + id + "'"
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
        public LabResult setLabResult(DataTable dt)
        {
            LabResult dgs1 = new LabResult();
            if (dt.Rows.Count > 0)
            {
                dgs1.result_id = dt.Rows[0][labR.result_id].ToString();
                dgs1.lis_id = dt.Rows[0][labR.lis_id].ToString();
                dgs1.req_id = dt.Rows[0][labR.req_id].ToString();
                dgs1.visit_id = dt.Rows[0][labR.visit_id].ToString();
                dgs1.patient_id = dt.Rows[0][labR.patient_id].ToString();
                dgs1.lab_id = dt.Rows[0][labR.lab_id].ToString();
                dgs1.result = dt.Rows[0][labR.result].ToString();
                dgs1.method = dt.Rows[0][labR.method].ToString();
                dgs1.active = dt.Rows[0][labR.active].ToString();
                dgs1.remark = dt.Rows[0][labR.remark].ToString();
                dgs1.date_create = dt.Rows[0][labR.date_create].ToString();
                dgs1.date_modi = dt.Rows[0][labR.date_modi].ToString();
                dgs1.date_cancel = dt.Rows[0][labR.date_cancel].ToString();
                dgs1.user_create = dt.Rows[0][labR.user_create].ToString();
                dgs1.user_modi = dt.Rows[0][labR.user_modi].ToString();
                dgs1.user_cancel = dt.Rows[0][labR.user_cancel].ToString();
                dgs1.unit = dt.Rows[0][labR.unit].ToString();
                dgs1.sort1 = dt.Rows[0][labR.sort1].ToString();
                dgs1.staff_id_result = dt.Rows[0][labR.staff_id_result].ToString();
                dgs1.staff_id_approve = dt.Rows[0][labR.staff_id_approve].ToString();
                dgs1.date_time_result = dt.Rows[0][labR.date_time_result].ToString();
                dgs1.date_time_approve = dt.Rows[0][labR.date_time_approve].ToString();
                dgs1.normal_value = dt.Rows[0][labR.date_time_approve].ToString();
            }
            else
            {
                setLabResult(dgs1);
            }
            return dgs1;
        }
        public LabResult setLabResult(LabResult dgs1)
        {
            dgs1.result_id = "";
            dgs1.lis_id = "";
            dgs1.req_id = "";
            dgs1.visit_id = "";
            dgs1.patient_id = "";
            dgs1.lab_id = "";
            dgs1.result = "";
            dgs1.method = "";
            dgs1.active = "";
            dgs1.remark = "";
            dgs1.date_create = "";
            dgs1.date_modi = "";
            dgs1.date_cancel = "";
            dgs1.user_create = "";
            dgs1.user_modi = "";
            dgs1.user_cancel = "";
            dgs1.unit = "";
            dgs1.sort1 = "";
            dgs1.staff_id_result = "";
            dgs1.staff_id_approve = "";
            dgs1.date_time_result = "";
            dgs1.date_time_approve = "";
            dgs1.normal_value = "";
            return dgs1;
        }
    }
}
