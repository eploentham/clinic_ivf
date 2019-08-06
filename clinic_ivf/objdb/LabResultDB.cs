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
        public LabResult lbRes;
        ConnectDB conn;
        public List<LabResult> lDgs;

        public LabResultDB(ConnectDB c)
        {
            this.conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lbRes = new LabResult();
            lDgs = new List<LabResult>();

            lbRes.result_id = "result_id";
            lbRes.lis_id = "lis_id";
            lbRes.req_id = "req_id";
            lbRes.visit_id = "visit_id";
            lbRes.patient_id = "patient_id";
            lbRes.lab_id = "lab_id";
            lbRes.result = "result";
            lbRes.method = "method";
            lbRes.active = "active";
            lbRes.remark = "remark";
            lbRes.date_create = "date_create";
            lbRes.date_modi = "date_modi";
            lbRes.date_cancel = "date_cancel";
            lbRes.user_create = "user_create";
            lbRes.user_modi = "user_modi";
            lbRes.user_cancel = "user_cancel";
            lbRes.unit = "unit";
            lbRes.sort1 = "sort1";
            lbRes.staff_id_result = "staff_id_result";
            lbRes.staff_id_approve = "staff_id_approve";
            lbRes.date_time_result = "date_time_result";
            lbRes.date_time_approve = "date_time_approve";
            lbRes.normal_value = "normal_value";
            lbRes.interpret = "interpret";
            lbRes.status_result = "status_result";
            lbRes.row1 = "row1";

            lbRes.table = "lab_t_result";
            lbRes.pkField = "result_id";
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
                itm1.result_id = row[lbRes.result_id].ToString();
                itm1.lis_id = row[lbRes.lis_id].ToString();
                itm1.req_id = row[lbRes.req_id].ToString();
                itm1.visit_id = row[lbRes.visit_id].ToString();
                itm1.patient_id = row[lbRes.patient_id].ToString();
                itm1.lab_id = row[lbRes.lab_id].ToString();
                itm1.result = row[lbRes.result].ToString();
                itm1.method = row[lbRes.method].ToString();
                itm1.active = row[lbRes.active].ToString();
                itm1.remark = row[lbRes.remark].ToString();
                itm1.date_create = row[lbRes.date_create].ToString();
                itm1.date_modi = row[lbRes.date_modi].ToString();
                itm1.date_cancel = row[lbRes.date_cancel].ToString();
                itm1.user_create = row[lbRes.user_create].ToString();
                itm1.user_modi = row[lbRes.user_modi].ToString();
                itm1.user_cancel = row[lbRes.user_cancel].ToString();
                itm1.unit = row[lbRes.unit].ToString();
                itm1.sort1 = row[lbRes.sort1].ToString();
                itm1.staff_id_result = row[lbRes.staff_id_result].ToString();
                itm1.staff_id_approve = row[lbRes.staff_id_approve].ToString();
                itm1.date_time_result = row[lbRes.date_time_result].ToString();
                itm1.date_time_approve = row[lbRes.date_time_approve].ToString();
                itm1.normal_value = row[lbRes.normal_value].ToString();
                itm1.interpret = row[lbRes.interpret].ToString();
                itm1.status_result = row[lbRes.status_result].ToString();
                itm1.row1 = row[lbRes.row1].ToString();
                lDgs.Add(itm1);
            }
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + lbRes.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                " Where dsc." + lbRes.active + " ='1' " +
                "Order By lis_id ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByHn(String id)
        {
            //LabResult cop1 = new LabResult();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + lbRes.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + lbRes.lab_id + " ='" + id + "' and dsc." + lbRes.active + "='1'" +
                "Order By lis_id ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public LabResult selectByPk(String id)
        {
            LabResult cop1 = new LabResult();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + lbRes.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + lbRes.pkField + " ='" + id + "' " +
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
                "From " + lbRes.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + lbRes.pkField + " ='" + id + "' " +
                "Order By lis_id ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByVn(String lab_id, String result, String vsDate)
        {
            LabResult cop1 = new LabResult();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + lbRes.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + lbRes.lab_id + " ='" + lab_id + "' and dsc." + lbRes.result + "='" + result + "' and dsc." + lbRes.method + "='" + vsDate + "' and dsc." + lbRes.active + "='1'" +
                "Order By lis_id ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByVn(String lab_id, String unit)
        {
            LabResult cop1 = new LabResult();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + lbRes.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + lbRes.lab_id + " ='" + lab_id + "' and dsc." + lbRes.result + "='" + unit + "' and dsc." + lbRes.active + "='1'" +
                "Order By lis_id ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectLabBloodByProcess(String vsid)
        {
            DataTable dt = new DataTable();
            String sql = "select lbRes.*, LabItem.LName,LabItem.lab_unit_id,LabItem.method_id, LabItem.status_datatype_result,LabItem.datatype_decimal,LabItem.status_interpret " +
                " " +
                "From " + lbRes.table + " lbRes " +
                "Left Join LabItem on lbRes." + lbRes.lab_id + " = LabItem.LID " +
                //"Left Join lab_b_unit on LabItem.lab_unit_id = lab_b_unit.lab_unit_id " +
                //"Left Join lab_b_method on LabItem.method_id = lab_b_method.method_id " +
                "Where lbRes." + lbRes.status_result + " in ('1','2')  and lbRes.visit_id = '"+vsid+"'" +
                "Order By lbRes." + lbRes.req_id;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectLabBloodByVsId(String vsid)
        {
            DataTable dt = new DataTable();
            String sql = "select lbRes.result, LabItem.LName as lab_name,LabItem.lab_unit_id,LabItem.method_id,lab_b_unit.lab_unit_name as unit,lab_b_method.method_name as method " +
                " " +
                "From " + lbRes.table + " lbRes " +
                "Left Join LabItem on lbRes." + lbRes.lab_id + " = LabItem.LID " +
                "Left Join lab_b_unit on LabItem.lab_unit_id = lab_b_unit.lab_unit_id " +
                "Left Join lab_b_method on LabItem.method_id = lab_b_method.method_id " +
                "Where lbRes." + lbRes.status_result + " ='2'  and lbRes.visit_id = '" + vsid + "'" +
                "Order By lbRes." + lbRes.req_id;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectLabBloodByFinish(String datestart, String dateend)
        {
            DataTable dt = new DataTable();
            String sql = "select lbRes.*, LabItem.LName, ptt.patient_hn" +
                ", CONCAT(IFNULL(fpp.patient_prefix_description,''),' ', ptt.patient_firstname_e ,' ',ptt.patient_lastname_e)  as pname " +
                "From " + lbRes.table + " lbRes " +
                "Left Join LabItem on lbRes." + lbRes.lab_id + " = LabItem.LID " +
                "Left Join t_visit vs on lbRes.visit_id = vs.t_visit_id " +
                "Left Join t_patient ptt on vs.t_patient_id = ptt.t_patient_id " +
                "Left join f_patient_prefix fpp on fpp.f_patient_prefix_id = ptt.f_patient_prefix_id " +
                "Where lbRes." + lbRes.status_result + " ='2' and LabItem.LGID='1' and vs.visit_begin_visit_time >= '" + datestart+ " 00:00:00' and vs.visit_begin_visit_time <= '" + dateend+" 23:59:59' " +
                "Order By lbRes." + lbRes.req_id;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectLabBloodByProcess()
        {
            DataTable dt = new DataTable();
            String sql = "select lbRes.*, LabItem.LName, ptt.patient_hn" +
                ", CONCAT(IFNULL(fpp.patient_prefix_description,''),' ', ptt.patient_firstname_e ,' ',ptt.patient_lastname_e)  as pname " +
                "From " + lbRes.table + " lbRes " +
                "Left Join LabItem on lbRes." + lbRes.lab_id + " = LabItem.LID " +
                "Left Join t_visit vs on lbRes.visit_id = vs.t_visit_id " +
                "Left Join t_patient ptt on vs.t_patient_id = ptt.t_patient_id " +
                "Left join f_patient_prefix fpp on fpp.f_patient_prefix_id = ptt.f_patient_prefix_id " +
                "Where lbRes." + lbRes.status_result + " ='1' and LabItem.LGID='1' " +
                "Order By lbRes." + lbRes.req_id;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public String selectRowNoByHnVn(String lab_id, String result, String docgid)
        {
            String re = "0", re1 = "";
            int chk = 0;
            LabResult cop1 = new LabResult();
            DataTable dt = new DataTable();
            String sql = "select max(" + lbRes.req_id + ") as " + lbRes.req_id + " " +
                "From " + lbRes.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + lbRes.lab_id + " ='" + lab_id + "' and dsc." + lbRes.lis_id + "='" + docgid + "' and dsc." + lbRes.result + "='" + result + "' " +
                "  ";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                re1 = dt.Rows[0][lbRes.req_id].ToString();
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
            p.status_result = p.status_result == null ? "0" : p.status_result;
            p.row1 = p.row1 == null ? "0" : p.row1;

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
            sql = "Insert Into " + lbRes.table + " set " +
                "" + lbRes.lis_id + "= '" + p.lis_id + "'" +
                "," + lbRes.active + "= '" + p.active + "'" +
                "," + lbRes.req_id + "= '" + p.req_id + "'" +
                "," + lbRes.visit_id + "= '" + p.visit_id + "'" +
                "," + lbRes.patient_id + "= '" + p.patient_id + "'" +
                "," + lbRes.lab_id + "= '" + p.lab_id + "'" +
                "," + lbRes.result + "= '" + p.result + "'" +
                "," + lbRes.method + "= '" + p.method + "'" +
                "," + lbRes.remark + "= '" + p.remark + "'" +
                "," + lbRes.date_create + "= now()" +
                "," + lbRes.date_modi + "= ''" +
                "," + lbRes.date_cancel + "= ''" +
                "," + lbRes.user_create + "= '" + userId + "@" + conn._IPAddress + "'" +
                "," + lbRes.user_modi + "= ''" +
                "," + lbRes.user_cancel + "= ''" +
                "," + lbRes.unit + "= '" + p.unit + "'" +
                "," + lbRes.sort1 + "= '" + p.sort1 + "'" +
                "," + lbRes.staff_id_result + "= '" + p.staff_id_result + "'" +
                "," + lbRes.staff_id_approve + "= '" + p.staff_id_approve + "'" +
                "," + lbRes.date_time_result + "= '" + p.date_time_result + "'" +
                "," + lbRes.date_time_approve + " " + "= '" + p.date_time_approve + "'" +
                "," + lbRes.normal_value + " " + "= '" + p.normal_value + "'" +
                "," + lbRes.interpret + " " + "= '" + p.interpret + "'" +
                "," + lbRes.status_result + " " + "= '" + p.status_result + "'" +
                "," + lbRes.row1 + " " + "= '" + p.row1 + "'" +
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
            sql = "Update " + lbRes.table + " Set " +
                " " + lbRes.lis_id + " = '" + p.lis_id + "'" +
                "," + lbRes.req_id + " = '" + p.req_id + "'" +
                "," + lbRes.visit_id + " = '" + p.visit_id + "'" +
                "," + lbRes.patient_id + " = '" + p.patient_id + "'" +
                "," + lbRes.lab_id + " = '" + p.lab_id + "'" +
                "," + lbRes.result + " = '" + p.result + "'" +
                "," + lbRes.method + " = '" + p.method + "'" +
                "," + lbRes.remark + " = '" + p.remark + "'" +
                "," + lbRes.date_modi + " = now()" +
                "," + lbRes.user_modi + " = '" + userId + "'" +
                "," + lbRes.unit + " = '" + p.unit + "'" +
                "," + lbRes.sort1 + " = '" + p.sort1 + "'" +
                "," + lbRes.staff_id_result + " = '" + p.staff_id_result + "'" +
                "," + lbRes.staff_id_approve + " = '" + p.staff_id_approve + "'" +
                "," + lbRes.date_time_result + " = '" + p.date_time_result + "'" +
                "," + lbRes.date_time_approve + " = '" + p.date_time_approve + "'" +
                "," + lbRes.normal_value + " = '" + p.normal_value + "'" +
                //"," + labR.normal_value + " " + "= '" + p.normal_value + "'" +
                "," + lbRes.interpret + " " + "= '" + p.interpret + "'" +
                "," + lbRes.status_result + " " + "= '" + p.status_result + "'" +
                "," + lbRes.row1 + " " + "= '" + p.row1 + "'" +
                "Where " + lbRes.pkField + "='" + p.result_id + "'"
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
        public String updateResult(String result, String stfappid, String stfresid, String dateapp, String dateres,String resid)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            //chkNull(p);
            sql = "Update " + lbRes.table + " Set " +
                " " + lbRes.result + " = '" + result + "'" +
                "," + lbRes.staff_id_approve + " = '" + stfappid + "'" +
                "," + lbRes.staff_id_result + " = '" + stfresid + "'" +
                "," + lbRes.date_time_approve + " = '" + dateapp + "'" +
                "," + lbRes.date_time_result + " = '" + dateres + "'" +
                //"," + lbRes.status_result + " = '2'" +
                "Where " + lbRes.pkField + "='" + resid + "'"
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
        public String updateResultFinish(String vsid)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            //chkNull(p);
            sql = "Update " + lbRes.table + " Set " +
                " " + lbRes.status_result + " = '2'" +
                "Where " + lbRes.visit_id + "='" + vsid + "'"
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

            sql = "Update " + lbRes.table + " Set " +
                " " + lbRes.active + " = '3'" +
                "," + lbRes.date_cancel + " = now()" +
                "," + lbRes.user_cancel + " = '" + userId + "'" +
                "Where " + lbRes.pkField + "='" + id + "'"
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
                dgs1.result_id = dt.Rows[0][lbRes.result_id].ToString();
                dgs1.lis_id = dt.Rows[0][lbRes.lis_id].ToString();
                dgs1.req_id = dt.Rows[0][lbRes.req_id].ToString();
                dgs1.visit_id = dt.Rows[0][lbRes.visit_id].ToString();
                dgs1.patient_id = dt.Rows[0][lbRes.patient_id].ToString();
                dgs1.lab_id = dt.Rows[0][lbRes.lab_id].ToString();
                dgs1.result = dt.Rows[0][lbRes.result].ToString();
                dgs1.method = dt.Rows[0][lbRes.method].ToString();
                dgs1.active = dt.Rows[0][lbRes.active].ToString();
                dgs1.remark = dt.Rows[0][lbRes.remark].ToString();
                dgs1.date_create = dt.Rows[0][lbRes.date_create].ToString();
                dgs1.date_modi = dt.Rows[0][lbRes.date_modi].ToString();
                dgs1.date_cancel = dt.Rows[0][lbRes.date_cancel].ToString();
                dgs1.user_create = dt.Rows[0][lbRes.user_create].ToString();
                dgs1.user_modi = dt.Rows[0][lbRes.user_modi].ToString();
                dgs1.user_cancel = dt.Rows[0][lbRes.user_cancel].ToString();
                dgs1.unit = dt.Rows[0][lbRes.unit].ToString();
                dgs1.sort1 = dt.Rows[0][lbRes.sort1].ToString();
                dgs1.staff_id_result = dt.Rows[0][lbRes.staff_id_result].ToString();
                dgs1.staff_id_approve = dt.Rows[0][lbRes.staff_id_approve].ToString();
                dgs1.date_time_result = dt.Rows[0][lbRes.date_time_result].ToString();
                dgs1.date_time_approve = dt.Rows[0][lbRes.date_time_approve].ToString();
                dgs1.normal_value = dt.Rows[0][lbRes.date_time_approve].ToString();
                dgs1.status_result = dt.Rows[0][lbRes.status_result].ToString();
                dgs1.row1 = dt.Rows[0][lbRes.row1].ToString();
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
            dgs1.status_result = "";
            dgs1.row1 = "";
            return dgs1;
        }
    }
}
