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
    public class OrTOperationDB
    {
        public OrTOperation orop;
        ConnectDB conn;

        public List<OrTOperation> lDept;

        public OrTOperationDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            orop = new OrTOperation();
            orop.or_id = "or_id";
            orop.or_code = "or_code";
            orop.or_req_id = "or_req_id";
            orop.patient_hn = "patient_hn";
            orop.patient_name = "patient_name";
            orop.remark = "remark";
            orop.date_create = "date_create";
            orop.date_modi = "date_modi";
            orop.date_cancel = "date_cancel";
            orop.user_create = "user_create";
            orop.user_modi = "user_modi";
            orop.user_cancel = "user_cancel";
            orop.active = "active";
            orop.doctor_anesthesia_id = "doctor_anesthesia_id";
            orop.doctor_surgical_id = "doctor_surgical_id";
            orop.or_date = "or_date";
            orop.or_time = "or_time";
            orop.status_or = "status_or";
            orop.b_service_point_id = "b_service_point_id";
            //orop.or_id = "or_id";
            orop.opera_id = "opera_id";
            orop.t_patient_id = "t_patient_id";
            orop.status_urgent = "status_urgent";
            orop.anesthesia_id = "anesthesia_id";
            orop.operation_name = "";
            orop.operation_group_name = "";
            orop.anesthesia_name = "";
            orop.surgeon = "";

            orop.table = "or_t_operation";
            orop.pkField = "or_id";

            lDept = new List<OrTOperation>();
            //getlDept();
        }
        private void chkNull(OrTOperation p)
        {
            long chk = 0;
            decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.or_code = p.or_code == null ? "" : p.or_code;
            //p.or_req_id = p.or_req_id == null ? "" : p.or_req_id;
            p.patient_hn = p.patient_hn == null ? "" : p.patient_hn;
            p.remark = p.remark == null ? "" : p.remark;
            p.patient_name = p.patient_name == null ? "" : p.patient_name;
            p.status_or = p.status_or == null ? "0" : p.status_or;
            p.status_urgent = p.status_urgent == null ? "0" : p.status_urgent;

            p.doctor_anesthesia_id = long.TryParse(p.doctor_anesthesia_id, out chk) ? chk.ToString() : "0";
            p.doctor_surgical_id = long.TryParse(p.doctor_surgical_id, out chk) ? chk.ToString() : "0";
            p.b_service_point_id = long.TryParse(p.b_service_point_id, out chk) ? chk.ToString() : "0";
            p.or_req_id = long.TryParse(p.or_req_id, out chk) ? chk.ToString() : "0";
            p.opera_id = long.TryParse(p.opera_id, out chk) ? chk.ToString() : "0";
            p.t_patient_id = long.TryParse(p.t_patient_id, out chk) ? chk.ToString() : "0";
            p.anesthesia_id = long.TryParse(p.anesthesia_id, out chk) ? chk.ToString() : "0";
        }
        public String insert(OrTOperation p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";

            chkNull(p);
            //orop.table = "or_t_operation";
            sql = "Insert Into " + orop.table + " Set " +
                "" + orop.or_code + " = '" + p.or_code + "' " +
                "," + orop.or_req_id + " = '" + p.or_req_id + "' " +
                "," + orop.patient_hn + " = '" + p.patient_hn.Replace("'", "''") + "' " +
                "," + orop.remark + " = '" + p.remark.Replace("'", "''") + "' " +
                "," + orop.date_create + " = now() " +
                "," + orop.date_modi + " = '" + p.date_modi + "' " +
                "," + orop.date_cancel + " = '" + p.date_cancel + "' " +
                "," + orop.user_create + " = '" + userId + "' " +
                "," + orop.user_modi + " = '" + p.user_modi + "' " +
                "," + orop.user_cancel + " = '" + p.user_cancel + "' " +
                "," + orop.active + " " + " = '" + p.active + "' " +
                "," + orop.patient_name + " " + " = '" + p.patient_name.Replace("'", "''") + "' " +
                "," + orop.doctor_anesthesia_id + " " + " = '" + p.doctor_anesthesia_id + "' " +
                "," + orop.doctor_surgical_id + " " + " = '" + p.doctor_surgical_id + "' " +
                "," + orop.or_date + " " + " = '" + p.or_date + "' " +
                "," + orop.or_time + " " + " = '" + p.or_time + "' " +
                "," + orop.status_or + " " + " = '" + p.status_or + "' " +
                "," + orop.b_service_point_id + " " + " = '" + p.b_service_point_id + "' " +
                //"," + orop.or_id + " " + " = '" + p.or_id + "' " +
                "," + orop.opera_id + " " + " = '" + p.opera_id + "' " +
                "," + orop.t_patient_id + " " + " = '" + p.t_patient_id + "' " +
                "," + orop.status_urgent + " " + " = '" + p.status_urgent + "' " +
                "," + orop.anesthesia_id + " " + " = '" + p.anesthesia_id + "' " +
                " ";
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
        public String update(OrTOperation p, String userId)
        {
            String re = "";
            String sql = "";
            long chk = 0;

            chkNull(p);

            sql = "Update " + orop.table + " Set " +
                "" + orop.or_code + " = '" + p.or_code + "' " +
                "," + orop.or_req_id + " = '" + p.or_req_id + "' " +
                "," + orop.patient_hn + " = '" + p.patient_hn.Replace("'", "''") + "' " +
                "," + orop.remark + " = '" + p.remark.Replace("'", "''") + "' " +
                "," + orop.date_create + " = now() " +
                "," + orop.date_modi + " = '" + p.date_modi + "' " +
                "," + orop.date_cancel + " = '" + p.date_cancel + "' " +
                "," + orop.user_create + " = '" + p.user_create + "' " +
                "," + orop.user_modi + " = '" + p.user_modi + "' " +
                "," + orop.user_cancel + " = '" + p.user_cancel + "' " +
                //"," + orreq.active + " " + " = '" + p.active + "' " +
                "," + orop.patient_name + " " + " = '" + p.patient_name + "' " +
                "," + orop.doctor_anesthesia_id + " " + " = '" + p.doctor_anesthesia_id + "' " +
                "," + orop.doctor_surgical_id + " " + " = '" + p.doctor_surgical_id + "' " +
                "," + orop.or_date + " " + " = '" + p.or_date + "' " +
                "," + orop.or_time + " " + " = '" + p.or_time + "' " +
                "," + orop.anesthesia_id + " " + " = '" + p.anesthesia_id + "' " +
                "," + orop.b_service_point_id + " " + " = '" + p.b_service_point_id + "' " +
                //"," + orop.or_id + " " + " = '" + p.or_id + "' " +
                "," + orop.opera_id + " " + " = '" + p.opera_id + "' " +
                "," + orop.t_patient_id + " " + " = '" + p.t_patient_id + "' " +
                "," + orop.status_urgent + " " + " = '" + p.status_urgent + "' " +
                "Where " + orop.pkField + "='" + p.or_id + "'"
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
        public String insertOrRequest(OrTOperation p, String userId)
        {
            String re = "";

            if (p.or_id.Equals(""))
            {
                re = insert(p, userId);
            }
            else
            {
                re = update(p, userId);
            }

            return re;
        }
        public String deleteAll()
        {
            DataTable dt = new DataTable();
            String sql = "Delete From  " + orop.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public String VoidOrRequest(String id, String userIdVoid)
        {
            DataTable dt = new DataTable();
            String sql = "Update " + orop.table + " Set " +
                "" + orop.active + "='3' " +
                "," + orop.date_cancel + "=now() " +
                "," + orop.user_cancel + "='" + userIdVoid + "' " +
                "Where " + orop.pkField + "='" + id + "'";
            conn.ExecuteNonQuery(conn.conn, sql);
            return "1";
        }
        public String UpdateStatusOrAccept(String id, String userIdVoid)
        {
            DataTable dt = new DataTable();
            String sql = "Update " + orop.table + " Set " +
                "" + orop.status_or + "='2' " +
                //"," + orreq.date_cancel + "=now() " +
                //"," + orreq.user_cancel + "='" + userIdVoid + "' " +
                "Where " + orop.pkField + "='" + id + "'";
            conn.ExecuteNonQuery(conn.conn, sql);
            return "1";
        }
        public DataTable selectDistinctByRemark()
        {
            DataTable dt = new DataTable();
            String sql = "select distinct orreq.remark " +
                "From " + orop.table + " orreq " +
                "Where opu." + orop.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public C1ComboBox setCboRemark(C1ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectDistinctByRemark();
            //String aaa = "";
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                item = new ComboBoxItem();
                item.Text = row[orop.remark].ToString();
                item.Value = i.ToString();

                c.Items.Add(item);
                i++;
            }
            return c;
        }
        public void getlOrRequest()
        {
            //lDept = new List<Position>();

            lDept.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                OrTOperation dept1 = new OrTOperation();
                dept1.or_id = row[orop.or_id].ToString();
                dept1.or_code = row[orop.or_code].ToString();
                dept1.or_req_id = row[orop.or_req_id].ToString();

                dept1.patient_hn = row[orop.patient_hn].ToString();
                //dept1.remark = row[ordg.remark].ToString();
                //dept1.date_create = row[ordg.date_create].ToString();
                //dept1.date_modi = row[ordg.date_modi].ToString();
                //dept1.date_cancel = row[ordg.date_cancel].ToString();
                //dept1.user_create = row[ordg.user_create].ToString();
                //dept1.user_modi = row[ordg.user_modi].ToString();
                //dept1.user_cancel = row[ordg.user_cancel].ToString();
                dept1.active = row[orop.active].ToString();
                lDept.Add(dept1);
            }
        }
        public String getIdByCode(String code)
        {
            String id = "";
            foreach (OrTOperation dept1 in lDept)
            {
                if (code.Trim().Equals(dept1.or_code.Trim()))
                {
                    id = dept1.or_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (OrTOperation dept1 in lDept)
            {
                if (name.Trim().Equals(dept1.or_req_id.Trim()))
                {
                    id = dept1.or_id;
                    break;
                }
            }
            return id;
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select ordg.*  " +
                "From " + orop.table + " ordg " +
                " " +
                "Where ordg." + orop.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectAll1()
        {
            DataTable dt = new DataTable();
            String sql = "select ordg.or_id, ordg.dept_code, ordg.dept_name_t, ordg.remark  " +
                "From " + orop.table + " ordg " +
                " " +
                "Where ordg." + orop.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPtt(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select orreq.* " +
                "From " + orop.table + " orreq " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where orreq." + orop.t_patient_id + " ='" + copId + "' and orreq." + orop.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByPtt1(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select orreq." + orop.or_id + ",orreq." + orop.patient_hn + ",orreq." + orop.or_req_id + ",ord.opera_name " +
                "From " + orop.table + " orreq " +
                "Left Join or_b_operation ord On orreq.opera_id = ord.opera_id " +
                //"Left Join or_b_diag ord On orreq.diag_id = ord.diag_id " +
                "Where orreq." + orop.t_patient_id + " ='" + copId + "' and orreq." + orop.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByStatusOperation()
        {
            DataTable dt = new DataTable();
            String sql = "select orreq." + orop.or_id + ",orreq." + orop.patient_hn + " , orreq.patient_name ,orreq." + orop.or_req_id +
                ",ord.opera_name, oranes.anesthesia_name, '' as age, bsp.service_point_description as service_point, " +
                "CONCAT(fpp.patient_prefix_description, stf.staff_fname_e, stf.staff_lname_e) as surgeon," +
                "anes.anesthesia_name as anesthesia, orreq.or_date as appointment_date, orreq.or_time as appointment_time,orreq.remark,ord.opera_name as operation," +
                "orreq.or_req_id as request_date, orreq.or_date, orreq.or_time  " +
                "From " + orop.table + " orreq " +
                "Left Join or_b_operation ord On orreq.opera_id = ord.opera_id " +
                "Left Join or_b_anesthesia oranes On orreq.anesthesia_id = oranes.anesthesia_id " +
                "Left Join b_service_point bsp On orreq.b_service_point_id = bsp.b_service_point_id " +
                "Left Join b_staff stf On orreq.doctor_surgical_id = stf.staff_id " +
                "Left Join f_patient_prefix fpp on stf.prefix_id = fpp.f_patient_prefix_id " +
                "Left Join or_b_anesthesia anes On orreq.anesthesia_id = anes.anesthesia_id " +
                //"Left Join or_b_operation opera On orreq.opera_id = opera.opera_id " +
                "Where orreq." + orop.status_or + " ='1' and orreq." + orop.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByOrAppointment(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select orreq." + orop.or_id + ",orreq." + orop.patient_hn + " as hn, orreq.patient_name as name,orreq." + orop.or_req_id +
                ",ord.opera_name, oranes.anesthesia_name, '' as age, bsp.service_point_description as service_point, " +
                "CONCAT(fpp.patient_prefix_description, stf.staff_fname_e, stf.staff_lname_e) as surgeon," +
                "anes.anesthesia_name as anesthesia, orreq.or_date as appointment_date, orreq.or_time as appointment_time,orreq.remark,ord.opera_name as operation,orreq.or_req_id as request_date  " +
                "From " + orop.table + " orreq " +
                "Left Join or_b_operation ord On orreq.opera_id = ord.opera_id " +
                "Left Join or_b_anesthesia oranes On orreq.anesthesia_id = oranes.anesthesia_id " +
                "Left Join b_service_point bsp On orreq.b_service_point_id = bsp.b_service_point_id " +
                "Left Join b_staff stf On orreq.doctor_surgical_id = stf.staff_id " +
                "Left Join f_patient_prefix fpp on stf.prefix_id = fpp.f_patient_prefix_id " +
                "Left Join or_b_anesthesia anes On orreq.anesthesia_id = anes.anesthesia_id " +
                //"Left Join or_b_operation opera On orreq.opera_id = opera.opera_id " +
                "Where orreq." + orop.pkField + " ='" + copId + "'  ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select ordg.* " +
                "From " + orop.table + " ordg " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where ordg." + orop.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public OrTOperation selectByPk1(String copId)
        {
            OrTOperation cop1 = new OrTOperation();
            DataTable dt = new DataTable();
            String sql = "select orreq.*,opera.opera_name,anes.anesthesia_name, " +
                "CONCAT(fpp.patient_prefix_description, stf.staff_fname_e, stf.staff_lname_e) as surgeon,ordg.opera_group_name " +
                "From " + orop.table + " orreq " +
                "Left Join or_b_operation opera On orreq.opera_id = opera.opera_id " +
                "Left Join or_b_operation_group ordg On opera.opera_group_id = ordg.opera_group_id " +
                "Left Join or_b_anesthesia anes On orreq.anesthesia_id = anes.anesthesia_id " +
                "Left Join b_staff stf On orreq.doctor_surgical_id = stf.staff_id " +
                "Left Join f_patient_prefix fpp on stf.prefix_id = fpp.f_patient_prefix_id " +
                "Where orreq." + orop.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setOrRequest(dt);
            return cop1;
        }
        private OrTOperation setOrRequest(DataTable dt)
        {
            OrTOperation dept1 = new OrTOperation();
            if (dt.Rows.Count > 0)
            {
                dept1.or_id = dt.Rows[0][orop.or_id].ToString();
                dept1.or_code = dt.Rows[0][orop.or_code].ToString();
                dept1.or_req_id = dt.Rows[0][orop.or_req_id].ToString();
                dept1.patient_hn = dt.Rows[0][orop.patient_hn].ToString();
                dept1.remark = dt.Rows[0][orop.remark].ToString();
                dept1.date_create = dt.Rows[0][orop.date_create].ToString();
                dept1.date_modi = dt.Rows[0][orop.date_modi].ToString();
                dept1.date_cancel = dt.Rows[0][orop.date_cancel].ToString();
                dept1.user_create = dt.Rows[0][orop.user_create].ToString();
                dept1.user_modi = dt.Rows[0][orop.user_modi].ToString();
                dept1.user_cancel = dt.Rows[0][orop.user_cancel].ToString();
                dept1.active = dt.Rows[0][orop.active].ToString();
                dept1.doctor_anesthesia_id = dt.Rows[0][orop.doctor_anesthesia_id].ToString();
                dept1.patient_name = dt.Rows[0][orop.patient_name].ToString();
                dept1.doctor_surgical_id = dt.Rows[0][orop.doctor_surgical_id].ToString();
                dept1.or_date = dt.Rows[0][orop.or_date].ToString();
                dept1.or_time = dt.Rows[0][orop.or_time].ToString();
                dept1.status_or = dt.Rows[0][orop.status_or].ToString();
                dept1.b_service_point_id = dt.Rows[0][orop.b_service_point_id].ToString();
                dept1.or_id = dt.Rows[0][orop.or_id].ToString();
                dept1.opera_id = dt.Rows[0][orop.opera_id].ToString();
                dept1.t_patient_id = dt.Rows[0][orop.t_patient_id].ToString();
                dept1.status_urgent = dt.Rows[0][orop.status_urgent].ToString();
                dept1.anesthesia_id = dt.Rows[0][orop.anesthesia_id].ToString();
                dept1.operation_name = dt.Rows[0]["opera_name"].ToString();
                dept1.operation_group_name = dt.Rows[0]["opera_group_name"].ToString();
                dept1.anesthesia_name = dt.Rows[0]["anesthesia_name"].ToString();
                dept1.surgeon = dt.Rows[0]["surgeon"].ToString();
            }
            else
            {
                dept1.or_id = "";
                dept1.or_code = "";
                dept1.or_req_id = "";

                dept1.patient_hn = "";
                dept1.remark = "";
                dept1.date_create = "";
                dept1.date_modi = "";
                dept1.date_cancel = "";
                dept1.user_create = "";
                dept1.user_modi = "";
                dept1.user_cancel = "";
                dept1.active = "";
                dept1.doctor_anesthesia_id = "";
                dept1.patient_name = "";
                dept1.doctor_surgical_id = "";
                dept1.or_date = "";
                dept1.or_time = "";
                dept1.status_or = "";
                dept1.b_service_point_id = "";
                dept1.or_id = "";
                dept1.opera_id = "";
                dept1.t_patient_id = "";
                dept1.status_urgent = "";
                dept1.anesthesia_id = "";
                dept1.operation_name = "";
                dept1.operation_group_name = "";
                dept1.anesthesia_name = "";
                dept1.surgeon = "";
            }

            return dept1;
        }
        public DataTable selectC1()
        {
            DataTable dt = new DataTable();
            String sql = "select ordg." + orop.pkField + ",ordg." + orop.or_req_id + " " +
                "From " + orop.table + " ordg " +
                " " +
                "Where ordg." + orop.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public C1ComboBox setC1CboDept(C1ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectC1();
            //String aaa = "";
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            foreach (DataRow row in dt.Rows)
            {
                item = new ComboBoxItem();
                item.Text = row[orop.or_req_id].ToString();
                item.Value = row[orop.or_id].ToString();

                c.Items.Add(item);
            }
            return c;
        }
    }
}
