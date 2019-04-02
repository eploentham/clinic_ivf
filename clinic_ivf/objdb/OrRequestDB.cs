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
    public class OrRequestDB
    {
        public OrRequest orreq;
        ConnectDB conn;

        public List<OrRequest> lDept;

        public OrRequestDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            orreq = new OrRequest();
            orreq.or_req_id = "or_req_id";
            orreq.or_req_code = "or_req_code";
            orreq.or_req_date = "or_req_date";
            orreq.patient_hn = "patient_hn";
            orreq.patient_name = "patient_name";
            orreq.remark = "remark";
            orreq.date_create = "date_create";
            orreq.date_modi = "date_modi";
            orreq.date_cancel = "date_cancel";
            orreq.user_create = "user_create";
            orreq.user_modi = "user_modi";
            orreq.user_cancel = "user_cancel";
            orreq.active = "active";
            orreq.doctor_anesthesia_id = "doctor_anesthesia_id";
            orreq.doctor_surgical_id = "doctor_surgical_id";
            orreq.or_date = "or_date";
            orreq.or_time = "or_time";
            orreq.status_or = "status_or";
            orreq.b_service_point_id = "b_service_point_id";
            orreq.or_id = "or_id";

            orreq.table = "or_t_request";
            orreq.pkField = "or_req_id";

            lDept = new List<OrRequest>();
            //getlDept();
        }
        private void chkNull(OrRequest p)
        {
            long chk = 0;
            decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.or_req_code = p.or_req_code == null ? "" : p.or_req_code;
            p.or_req_date = p.or_req_date == null ? "" : p.or_req_date;
            p.patient_hn = p.patient_hn == null ? "" : p.patient_hn;
            p.remark = p.remark == null ? "" : p.remark;
            p.patient_name = p.patient_name == null ? "" : p.patient_name;
            p.status_or = p.status_or == null ? "0" : p.status_or;

            p.doctor_anesthesia_id = long.TryParse(p.doctor_anesthesia_id, out chk) ? chk.ToString() : "0";
            p.doctor_surgical_id = long.TryParse(p.doctor_surgical_id, out chk) ? chk.ToString() : "0";
            p.b_service_point_id = long.TryParse(p.b_service_point_id, out chk) ? chk.ToString() : "0";
            p.or_id = long.TryParse(p.or_id, out chk) ? chk.ToString() : "0";
            //p.patient_name = long.TryParse(p.patient_name, out chk) ? chk.ToString() : "0";

        }
        public String insert(OrRequest p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";

            chkNull(p);
            sql = "Insert Into " + orreq.table + " Set " +
                "" + orreq.or_req_code + " = '" + p.or_req_code + "' " +
                "," + orreq.or_req_date + " = '" + p.or_req_date + "' " +
                "," + orreq.patient_hn + " = '" + p.patient_hn.Replace("'", "''") + "' " +
                "," + orreq.remark + " = '" + p.remark.Replace("'", "''") + "' " +
                "," + orreq.date_create + " = now() " +
                "," + orreq.date_modi + " = '" + p.date_modi + "' " +
                "," + orreq.date_cancel + " = '" + p.date_cancel + "' " +
                "," + orreq.user_create + " = '" + p.user_create + "' " +
                "," + orreq.user_modi + " = '" + p.user_modi + "' " +
                "," + orreq.user_cancel + " = '" + p.user_cancel + "' " +
                "," + orreq.active + " " + " = '" + p.active + "' " +
                "," + orreq.patient_name + " " + " = '" + p.patient_name.Replace("'", "''") + "' " +
                "," + orreq.doctor_anesthesia_id + " " + " = '" + p.doctor_anesthesia_id + "' " +
                "," + orreq.doctor_surgical_id + " " + " = '" + p.doctor_surgical_id + "' " +
                "," + orreq.or_date + " " + " = '" + p.or_date + "' " +
                "," + orreq.or_time + " " + " = '" + p.or_time + "' " +
                "," + orreq.status_or + " " + " = '" + p.status_or + "' " +
                "," + orreq.b_service_point_id + " " + " = '" + p.b_service_point_id + "' " +
                "," + orreq.or_id + " " + " = '" + p.or_id + "' " +
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
        public String update(OrRequest p, String userId)
        {
            String re = "";
            String sql = "";
            long chk = 0;

            chkNull(p);

            sql = "Update " + orreq.table + " Set " +
                "" + orreq.or_req_code + " = '" + p.or_req_code + "' " +
                "," + orreq.or_req_date + " = '" + p.or_req_date + "' " +
                "," + orreq.patient_hn + " = '" + p.patient_hn.Replace("'", "''") + "' " +
                "," + orreq.remark + " = '" + p.remark.Replace("'", "''") + "' " +
                "," + orreq.date_create + " = now() " +
                "," + orreq.date_modi + " = '" + p.date_modi + "' " +
                "," + orreq.date_cancel + " = '" + p.date_cancel + "' " +
                "," + orreq.user_create + " = '" + p.user_create + "' " +
                "," + orreq.user_modi + " = '" + p.user_modi + "' " +
                "," + orreq.user_cancel + " = '" + p.user_cancel + "' " +
                "," + orreq.active + " " + " = '" + p.active + "' " +
                "," + orreq.patient_name + " " + " = '" + p.patient_name + "' " +
                "," + orreq.doctor_anesthesia_id + " " + " = '" + p.doctor_anesthesia_id + "' " +
                "," + orreq.doctor_surgical_id + " " + " = '" + p.doctor_surgical_id + "' " +
                "," + orreq.or_date + " " + " = '" + p.or_date + "' " +
                "," + orreq.or_time + " " + " = '" + p.or_time + "' " +
                "," + orreq.status_or + " " + " = '" + p.status_or + "' " +
                "," + orreq.b_service_point_id + " " + " = '" + p.b_service_point_id + "' " +
                "," + orreq.or_id + " " + " = '" + p.or_id + "' " +
                "Where " + orreq.pkField + "='" + p.or_req_id + "'"
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
        public String insertOrRequest(OrRequest p, String userId)
        {
            String re = "";

            if (p.or_req_id.Equals(""))
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
            String sql = "Delete From  " + orreq.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public String VoidOrRequest(String deptId, String userIdVoid)
        {
            DataTable dt = new DataTable();
            String sql = "Update " + orreq.table + " Set " +
                "" + orreq.active + "='3' " +
                "," + orreq.date_cancel + "=now() " +
                "," + orreq.user_cancel + "='" + userIdVoid + "' " +
                "Where " + orreq.pkField + "='" + deptId + "'";
            conn.ExecuteNonQuery(conn.conn, sql);
            return "1";
        }
        public void getlOrRequest()
        {
            //lDept = new List<Position>();

            lDept.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                OrRequest dept1 = new OrRequest();
                dept1.or_req_id = row[orreq.or_req_id].ToString();
                dept1.or_req_code = row[orreq.or_req_code].ToString();
                dept1.or_req_date = row[orreq.or_req_date].ToString();

                dept1.patient_hn = row[orreq.patient_hn].ToString();
                //dept1.remark = row[ordg.remark].ToString();
                //dept1.date_create = row[ordg.date_create].ToString();
                //dept1.date_modi = row[ordg.date_modi].ToString();
                //dept1.date_cancel = row[ordg.date_cancel].ToString();
                //dept1.user_create = row[ordg.user_create].ToString();
                //dept1.user_modi = row[ordg.user_modi].ToString();
                //dept1.user_cancel = row[ordg.user_cancel].ToString();
                dept1.active = row[orreq.active].ToString();
                lDept.Add(dept1);
            }
        }
        public String getIdByCode(String code)
        {
            String id = "";
            foreach (OrRequest dept1 in lDept)
            {
                if (code.Trim().Equals(dept1.or_req_code.Trim()))
                {
                    id = dept1.or_req_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (OrRequest dept1 in lDept)
            {
                if (name.Trim().Equals(dept1.or_req_date.Trim()))
                {
                    id = dept1.or_req_id;
                    break;
                }
            }
            return id;
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select ordg.*  " +
                "From " + orreq.table + " ordg " +
                " " +
                "Where ordg." + orreq.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectAll1()
        {
            DataTable dt = new DataTable();
            String sql = "select ordg.or_req_id, ordg.dept_code, ordg.dept_name_t, ordg.remark  " +
                "From " + orreq.table + " ordg " +
                " " +
                "Where ordg." + orreq.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select ordg.* " +
                "From " + orreq.table + " ordg " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where ordg." + orreq.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public OrRequest selectByPk1(String copId)
        {
            OrRequest cop1 = new OrRequest();
            DataTable dt = new DataTable();
            String sql = "select ordg.* " +
                "From " + orreq.table + " ordg " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where ordg." + orreq.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setOrRequest(dt);
            return cop1;
        }
        private OrRequest setOrRequest(DataTable dt)
        {
            OrRequest dept1 = new OrRequest();
            if (dt.Rows.Count > 0)
            {
                dept1.or_req_id = dt.Rows[0][orreq.or_req_id].ToString();
                dept1.or_req_code = dt.Rows[0][orreq.or_req_code].ToString();
                dept1.or_req_date = dt.Rows[0][orreq.or_req_date].ToString();
                dept1.patient_hn = dt.Rows[0][orreq.patient_hn].ToString();
                dept1.remark = dt.Rows[0][orreq.remark].ToString();
                dept1.date_create = dt.Rows[0][orreq.date_create].ToString();
                dept1.date_modi = dt.Rows[0][orreq.date_modi].ToString();
                dept1.date_cancel = dt.Rows[0][orreq.date_cancel].ToString();
                dept1.user_create = dt.Rows[0][orreq.user_create].ToString();
                dept1.user_modi = dt.Rows[0][orreq.user_modi].ToString();
                dept1.user_cancel = dt.Rows[0][orreq.user_cancel].ToString();
                dept1.active = dt.Rows[0][orreq.active].ToString();
                dept1.doctor_anesthesia_id = dt.Rows[0][orreq.doctor_anesthesia_id].ToString();
                dept1.patient_name = dt.Rows[0][orreq.patient_name].ToString();
                dept1.doctor_surgical_id = dt.Rows[0][orreq.doctor_surgical_id].ToString();
                dept1.or_date = dt.Rows[0][orreq.or_date].ToString();
                dept1.or_time = dt.Rows[0][orreq.or_time].ToString();
                dept1.status_or = dt.Rows[0][orreq.status_or].ToString();
                dept1.b_service_point_id = dt.Rows[0][orreq.b_service_point_id].ToString();
                dept1.or_id = dt.Rows[0][orreq.or_id].ToString();
                //dept1.patient_name = dt.Rows[0][orreq.patient_name].ToString();
            }
            else
            {
                dept1.or_req_id = "";
                dept1.or_req_code = "";
                dept1.or_req_date = "";

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
            }

            return dept1;
        }
        public DataTable selectC1()
        {
            DataTable dt = new DataTable();
            String sql = "select ordg." + orreq.pkField + ",ordg." + orreq.or_req_date + " " +
                "From " + orreq.table + " ordg " +
                " " +
                "Where ordg." + orreq.active + " ='1' ";
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
                item.Text = row[orreq.or_req_date].ToString();
                item.Value = row[orreq.or_req_id].ToString();

                c.Items.Add(item);
            }
            return c;
        }
    }
}
