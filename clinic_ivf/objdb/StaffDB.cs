using C1.Win.C1Input;
using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.objdb
{
    public class StaffDB
    {
        public Staff stf;
        ConnectDB conn;

        public List<Staff> lStf, lStfEx;
        public List<Staff> ldtr;

        public StaffDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            stf = new Staff();
            stf.staff_id = "staff_id";
            stf.staff_code = "staff_code";
            stf.username = "username";
            stf.prefix_id = "prefix_id";
            stf.staff_fname_t = "staff_fname_t";
            stf.staff_fname_e = "staff_fname_e";
            stf.staff_lname_t = "staff_lname_t";
            stf.staff_lname_e = "staff_lname_e";
            stf.password1 = "password1";
            stf.active = "active";
            stf.remark = "remark";
            stf.priority = "priority";
            stf.tele = "tele";
            stf.mobile = "mobile";
            stf.fax = "fax";
            stf.email = "email";
            stf.posi_id = "posi_id";
            stf.posi_name = "posi_name";
            stf.date_create = "date_create";
            stf.date_modi = "date_modi";
            stf.date_cancel = "date_cancel";
            stf.user_create = "user_create";
            stf.user_modi = "user_modi";
            stf.user_cancel = "user_cancel";
            stf.pid = "pid";
            stf.logo = "logo";
            stf.posi_id = "posi_id";
            stf.dept_name = "dept_name";
            stf.prefix_name_t = "patient_prefix_description";
            stf.status_admin = "status_admin";
            stf.status_module_reception = "status_module_reception";
            stf.status_module_nurse = "status_module_nurse";
            stf.status_module_doctor = "status_module_doctor";
            stf.posi_name_t = "posi_name_t";
            stf.dept_name_t = "dept_name_t";
            stf.dept_id = "dept_id";
            stf.status_expense_appv = "status_expense_appv";
            stf.status_expense_draw = "status_expense_draw";
            stf.status_expense_pay = "status_expense_pay";
            stf.password_confirm = "password_confirm";
            stf.status_module_pharmacy = "status_module_pharmacy";
            stf.status_module_lab = "status_module_lab";
            stf.status_module_cashier = "status_module_cashier";
            stf.status_module_medicalrecord = "status_module_medicalrecord";
            stf.status_doctor = "status_doctor";
            stf.doctor_id = "doctor_id";
            stf.doctor_id_old = "doctor_id_old";

            stf.table = "b_staff";
            stf.pkField = "staff_id";

            lStf = new List<Staff>();
            ldtr = new List<Staff>();
            lStfEx = new List<Staff>();
        }
        public void getlStfEx()
        {
            //lDept = new List<Position>();

            lStfEx.Clear();
            DataTable dt = new DataTable();
            dt = selectAllEx();
            foreach (DataRow row in dt.Rows)
            {
                Staff stf1 = new Staff();
                stf1.staff_id = row[stf.staff_id].ToString();
                stf1.staff_code = row[stf.staff_code].ToString();
                stf1.staff_fname_t = row[stf.staff_fname_t].ToString();
                stf1.staff_lname_t = row[stf.staff_lname_t].ToString();
                stf1.staff_fname_e = row[stf.staff_fname_e].ToString();
                stf1.staff_lname_e = row[stf.staff_lname_e].ToString();
                stf1.doctor_id_old = row[stf.doctor_id_old].ToString();
                stf1.doctor_id = row[stf.doctor_id].ToString();
                //cus1.date_cancel = row[dept.date_cancel].ToString();
                //cus1.user_create = row[dept.user_create].ToString();
                //cus1.user_modi = row[dept.user_modi].ToString();
                //cus1.user_cancel = row[dept.user_cancel].ToString();
                //cus1.active = row[dept.active].ToString();
                lStfEx.Add(stf1);
            }
        }
        public void getlStf()
        {
            //lDept = new List<Position>();

            lStf.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                Staff stf1 = new Staff();
                stf1.staff_id = row[stf.staff_id].ToString();
                stf1.staff_code = row[stf.staff_code].ToString();
                stf1.staff_fname_t = row[stf.staff_fname_t].ToString();
                stf1.staff_lname_t = row[stf.staff_lname_t].ToString();
                stf1.staff_fname_e = row[stf.staff_fname_e].ToString();
                stf1.staff_lname_e = row[stf.staff_lname_e].ToString();
                stf1.doctor_id_old = row[stf.doctor_id_old].ToString();
                stf1.doctor_id = row[stf.doctor_id].ToString();
                stf1.name_lab = row["name"].ToString() + " " + row[stf.doctor_id].ToString();
                stf1.prefix_name_t = row[stf.user_create].ToString();
                stf1.name_full = row["name"].ToString();
                //cus1.user_cancel = row[dept.user_cancel].ToString();
                //cus1.active = row[dept.active].ToString();
                lStf.Add(stf1);
            }
        }
        public String getIdByIdOld(String code)
        {
            String id = "";
            if (lStf.Count <= 0) getlStf();
            foreach (Staff stf1 in lStf)
            {
                if (code.Trim().Equals(stf1.doctor_id_old))
                {
                    id = stf1.staff_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByCode(String code)
        {
            String id = "";
            foreach (Staff stf1 in lStf)
            {
                if (code.Trim().Equals(stf1.staff_code))
                {
                    id = stf1.staff_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByNameSurname(String name)
        {
            String id = "";
            String[] name1 = name.Split(' ');
            if (name1.Length == 2)
            {
                foreach (Staff stf1 in lStf)
                {
                    if (name1[0].Trim().Equals(stf1.staff_fname_t))
                    {
                        if (name1[1].Trim().Equals(stf1.staff_lname_e))
                        {
                            id = stf1.staff_id;
                            break;
                        }
                        //id = stf1.staff_id;
                        //break;
                    }
                }
            }
            
            return id;
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (Staff stf1 in lStf)
            {
                if (name.Trim().Equals(stf1.staff_fname_t))
                {
                    id = stf1.staff_id;
                    break;
                }
            }
            return id;
        }
        private void chkNull(Staff p)
        {
            long chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            //p.prefix_id = int.TryParse(p.prefix_id, out chk) ? chk.ToString() : "0";
            //p.posi_id = int.TryParse(p.posi_id, out chk) ? chk.ToString() : "0";
            //p.posi_id = int.TryParse(p.posi_id, out chk) ? chk.ToString() : "0";

            p.staff_code = p.staff_code == null ? "" : p.staff_code;
            p.username = p.username == null ? "" : p.username;
            p.staff_fname_t = p.staff_fname_t == null ? "" : p.staff_fname_t;
            p.staff_fname_e = p.staff_fname_e == null ? "" : p.staff_fname_e;
            p.password1 = p.password1 == null ? "" : p.password1;
            p.remark = p.remark == null ? "" : p.remark;
            p.priority = p.priority == null ? "" : p.priority;
            p.tele = p.tele == null ? "" : p.tele;
            p.mobile = p.mobile == null ? "" : p.mobile;
            p.fax = p.fax == null ? "" : p.fax;
            p.email = p.email == null ? "" : p.email;
            p.posi_name = p.posi_name == null ? "" : p.posi_name;
            p.posi_id = p.posi_id == null ? "" : p.posi_id;
            p.staff_lname_t = p.staff_lname_t == null ? "" : p.staff_lname_t;
            p.staff_lname_e = p.staff_lname_e == null ? "" : p.staff_lname_e;
            p.pid = p.pid == null ? "" : p.pid;
            p.logo = p.logo == null ? "" : p.logo;
            p.dept_name = p.dept_name == null ? "" : p.dept_name;
            p.doctor_id = p.doctor_id == null ? "" : p.doctor_id;
            p.doctor_id_old = p.doctor_id_old == null ? "" : p.doctor_id_old;

            p.status_admin = p.status_admin == null ? "0" : p.status_admin;
            p.status_module_reception = p.status_module_reception == null ? "0" : p.status_module_reception;
            p.status_module_nurse = p.status_module_nurse == null ? "0" : p.status_module_nurse;
            p.status_admin = p.status_admin.Equals("") ? "0" : p.status_admin;
            p.status_module_reception = p.status_module_reception.Equals("") ? "0" : p.status_module_reception;
            p.status_module_nurse = p.status_module_nurse.Equals("") ? "0" : p.status_module_nurse;
            p.status_module_doctor = p.status_module_doctor.Equals("") ? "0" : p.status_module_doctor;
            p.status_expense_appv = p.status_expense_appv == null ? "0" : p.status_expense_appv;
            p.status_expense_draw = p.status_expense_draw == null ? "0" : p.status_expense_draw;
            p.status_expense_pay = p.status_expense_pay == null ? "0" : p.status_expense_pay;
            p.status_module_pharmacy = p.status_module_pharmacy == null ? "0" : p.status_module_pharmacy;
            p.status_module_lab = p.status_module_lab == null ? "0" : p.status_module_lab;
            p.status_module_cashier = p.status_module_cashier == null ? "0" : p.status_module_cashier;
            p.status_module_medicalrecord = p.status_module_medicalrecord == null ? "0" : p.status_module_medicalrecord;
            p.status_doctor = p.status_doctor == null ? "0" : p.status_doctor;

            p.posi_id = long.TryParse(p.posi_id, out chk) ? chk.ToString() : "0";
            p.dept_id = long.TryParse(p.dept_id, out chk) ? chk.ToString() : "0";
            p.prefix_id = long.TryParse(p.prefix_id, out chk) ? chk.ToString() : "0";
        }
        public String insert(Staff p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            //sql = "Insert Into " + stf.table + "(" + stf.staff_code + "," + stf.username + "," + stf.prefix_id + "," +
            //    stf.staff_fname_t + "," + stf.staff_fname_e + "," + stf.password1 + "," +
            //    stf.active + "," + stf.remark + "," + stf.priority + "," +
            //    stf.tele + "," + stf.mobile + "," + stf.fax + "," +
            //    stf.email + "," + stf.posi_id + "," + stf.posi_name + "," +
            //    stf.date_create + "," + stf.date_modi + "," + stf.date_cancel + "," +
            //    stf.user_create + "," + stf.user_modi + "," + stf.user_cancel + "," +
            //    stf.staff_lname_t + "," + stf.staff_lname_e + ", " + stf.pid + "," +
            //    stf.logo + ", " + stf.dept_name + "," +
            //    stf.status_admin + ", " + stf.status_module_reception + "," + stf.status_module_nurse + "," +
            //    stf.status_module_doctor + "," +
            //    stf.status_expense_appv + "," + stf.status_expense_draw + "," + stf.status_expense_pay + ", " +
            //    stf.status_module_pharmacy + "," + stf.status_module_lab + ","  + stf.dept_id + "," +
            //    stf.status_module_cashier + "," + stf.status_module_medicalrecord + " " +
            //    ") " +
            //    "Values ('" + p.staff_code + "','" + p.username + "','" + p.prefix_id + "'," +
            //    "'" + p.staff_fname_t.Replace("'", "''") + "','" + p.staff_fname_e.Replace("'", "''") + "','" + p.password1 + "'," +
            //    "'" + p.active + "','" + p.remark + "','" + p.priority + "'," +
            //    "'" + p.tele + "','" + p.mobile + "','" + p.fax + "'," +
            //    "'" + p.email + "','" + p.posi_id + "','" + p.posi_name + "'," +
            //    "now(),'" + p.date_modi + "','" + p.date_cancel + "'," +
            //    "'" + userId + "','" + p.user_modi + "','" + p.user_cancel + "', " +
            //    "'" + p.staff_lname_t.Replace("'", "''") + "','" + p.staff_lname_e.Replace("'", "''") + "','" + p.pid + "'," +
            //    "'" + p.logo + "','"  + p.dept_name.Replace("'", "''") + "'," +
            //    "'" + p.status_admin + "','" + p.status_module_reception + "','" + p.status_module_nurse.Replace("'", "''") + "'," +
            //    "'" + p.status_module_doctor.Replace("'", "''") + "'," +
            //    "'" + p.status_expense_appv + "','" + p.status_expense_draw + "','" + p.status_expense_pay.Replace("'", "''") + "'," +
            //    "'" + p.status_module_pharmacy + "','" + p.status_module_lab + "','" + p.dept_id + "'," +
            //    "'" + p.status_module_cashier + "','" + p.status_module_medicalrecord + "' " +
            //    ")";
            sql = "Insert Into " + stf.table + " set " +
                " " + stf.staff_code + "='" + p.staff_code + "' " +
                "," + stf.username + "='" + p.username + "' " +
                "," + stf.prefix_id + "='" + p.prefix_id + "' " +
                "," + stf.staff_fname_t + "='" + p.staff_fname_t.Replace("'", "''") + "' " +
                "," + stf.staff_fname_e + "='" + p.staff_fname_e.Replace("'", "''") + "' " +
                "," + stf.password1 + "='" + p.password1 + "' " +
                "," + stf.active + "='" + p.active + "' " +
                "," + stf.remark + "='" + p.remark.Replace("'", "''") + "' " +
                "," + stf.priority + "='" + p.priority + "' " +
                "," + stf.tele + "='" + p.tele + "' " +
                "," + stf.mobile + "='" + p.mobile + "' " +
                "," + stf.fax + "='" + p.fax + "' " +
                "," + stf.email + "='" + p.email + "' " +
                "," + stf.posi_id + "='" + p.posi_id + "' " +
                "," + stf.posi_name + "='" + p.posi_name.Replace("'", "''") + "' " +
                "," + stf.date_create + "=now() " +
                "," + stf.date_modi + "='" + p.date_modi + "' " +
                "," + stf.date_cancel + "='" + p.date_cancel + "' " +
                "," + stf.user_create + "='" + userId + "' " +
                "," + stf.user_modi + "='" + p.user_modi + "' " +
                "," + stf.user_cancel + "='" + p.user_cancel + "' " +
                "," + stf.staff_lname_t + "='" + p.staff_lname_t.Replace("'", "''") + "' " +
                "," + stf.staff_lname_e + "='" + p.staff_lname_e.Replace("'", "''") + "' " +
                ", " + stf.pid + "='" + p.pid + "' " +
                "," + stf.logo + "='" + p.logo + "' " +
                ", " + stf.dept_name + "='" + p.dept_name.Replace("'", "''") + "' " +
                "," + stf.status_admin + "='" + p.status_admin + "' " +
                ", " + stf.status_module_reception + "='" + p.status_module_reception + "' " +
                "," + stf.status_module_nurse + "='" + p.status_module_nurse + "' " +
                "," + stf.status_module_doctor + "='" + p.status_module_doctor + "' " +
                "," + stf.status_expense_appv + "='" + p.status_expense_appv + "' " +
                "," + stf.status_expense_draw + "='" + p.status_expense_draw + "' " +
                "," + stf.status_expense_pay + "='" + p.status_expense_pay + "' " +
                ", " + stf.status_module_pharmacy + "='" + p.status_module_pharmacy + "' " +
                "," + stf.status_module_lab + "='" + p.status_module_lab + "' " +
                "," + stf.dept_id + "='" + p.dept_id + "' " +
                "," + stf.status_module_cashier + "='" + p.status_module_cashier + "' " +
                "," + stf.status_module_medicalrecord + "='" + p.status_module_medicalrecord + "' " +
                "," + stf.status_doctor + "='" + p.status_doctor + "' " +
                "," + stf.doctor_id + "='" + p.doctor_id + "' "+
                "," + stf.doctor_id_old + "='" + p.doctor_id_old + "' "+
                "";
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
        public String update(Staff p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + stf.table + " Set " +
                " " + stf.staff_code + " = '" + p.staff_code + "'" +
                "," + stf.username + " = '" + p.username.Replace("'", "''") + "'" +
                "," + stf.prefix_id + " = '" + p.prefix_id + "'" +
                "," + stf.staff_fname_t + " = '" + p.staff_fname_t.Replace("'", "''") + "'" +
                "," + stf.staff_fname_e + " = '" + p.staff_fname_e.Replace("'", "''") + "'" +
                "," + stf.staff_lname_t + " = '" + p.staff_lname_t.Replace("'", "''") + "'" +
                "," + stf.staff_lname_e + " = '" + p.staff_lname_e.Replace("'", "''") + "'" +
                //"," + stf.password1 + " = '" + p.password1.Replace("'", "''") + "'" +
                "," + stf.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + stf.priority + " = '" + p.priority + "'" +
                "," + stf.tele + " = '" + p.tele + "'" +
                "," + stf.mobile + " = '" + p.mobile + "'" +
                "," + stf.fax + " = '" + p.fax + "'" +
                "," + stf.email + " = '" + p.email + "'" +
                "," + stf.posi_id + " = '" + p.posi_id + "'" +
                "," + stf.posi_name + " = '" + p.posi_name.Replace("'", "''") + "'" +
                "," + stf.date_modi + " = now()" +
                "," + stf.pid + " = '" + p.pid + "'" +
                "," + stf.logo + " = '" + p.logo + "' " +
                "," + stf.user_modi + " = '" + userId + "' " +
                "," + stf.dept_id + " = '" + p.dept_id + "' " +
                "," + stf.dept_name + " = '" + p.dept_name.Replace("'", "''") + "' " +
                "," + stf.status_admin + " = '" + p.status_admin + "' " +
                "," + stf.status_module_reception + " = '" + p.status_module_reception + "' " +
                "," + stf.status_module_nurse + " = '" + p.status_module_nurse + "' " +
                "," + stf.status_module_doctor + " = '" + p.status_module_doctor + "' " +
                "," + stf.status_expense_appv + " = '" + p.status_expense_appv + "' " +
                "," + stf.status_expense_draw + " = '" + p.status_expense_draw + "' " +
                "," + stf.status_expense_pay + " = '" + p.status_expense_pay + "' " +
                "," + stf.status_module_pharmacy + " = '" + p.status_module_pharmacy + "' " +
                "," + stf.status_module_lab + " = '" + p.status_module_lab + "' " +
                "," + stf.status_module_cashier + " = '" + p.status_module_cashier + "' " +
                "," + stf.status_module_medicalrecord + " = '" + p.status_module_medicalrecord + "' " +
                "," + stf.status_doctor + " = '" + p.status_doctor + "' " +
                "," + stf.doctor_id + " = '" + p.doctor_id + "' " +
                "," + stf.doctor_id_old + "='" + p.doctor_id_old + "' " +
                "Where " + stf.pkField + "='" + p.staff_id + "'"
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
        public String insertStaff(Staff p, String userId)
        {
            String re = "";

            if (p.staff_id.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
            }

            return re;
        }
        public String deleteAll()
        {
            DataTable dt = new DataTable();
            String sql = "Delete From  " + stf.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public String updatePassword(String stfId, String password1)
        {
            //DataTable dt = new DataTable();
            String re = "";
            String sql = "Update " + stf.table + " Set " + stf.password1 + "='" + password1 + "' " +
                "Where " + stf.pkField + "='" + stfId + "'";
            //conn.ExecuteNonQuery(conn.conn, sql);
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
        public String updatePasswordConfirm(String stfId, String password1)
        {
            //DataTable dt = new DataTable();
            String re = "";
            String sql = "Update " + stf.table + " Set " + stf.password_confirm + "='" + password1 + "' " +
                "Where " + stf.pkField + "='" + stfId + "'";
            //conn.ExecuteNonQuery(conn.conn, sql);
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
        public String VoidStaff(String stfId, String userIdVoid)
        {
            DataTable dt = new DataTable();
            String sql = "Update " + stf.table + " Set " +
                "" + stf.active + "='3'" +
                "," + stf.date_cancel + "=now() " +
                "," + stf.user_cancel + "='" + userIdVoid + "' " +
                "Where " + stf.pkField + "='" + stfId + "'";
            conn.ExecuteNonQuery(conn.conn, sql);

            return "1";
        }
        
        public DataTable selectAllEmbryo()
        {
            DataTable dt = new DataTable();
            String sql = "select stf.*  " +
                "From " + stf.table + " stf " +
                "LEft Join b_position posi on posi.posi_id = stf.posi_id " +
                " " +
                "Where stf." + stf.active + " ='1' and posi.status_embryologist = '1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectAllEx()
        {
            DataTable dt = new DataTable();
            String sql = "select cop.*  " +
                "From " + stf.table + " cop " +
                " " +
                "Where cop." + stf.active + " ='1' ";
            dt = conn.selectData(conn.connEx, sql);

            return dt;
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select stf.*, concat(pfx.patient_prefix_description, ' ', stf.staff_fname_e, ' ' , stf.staff_lname_e) as name  " +
                "From " + stf.table + " stf " +
                "Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where stf." + stf.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectAllDoctor()
        {
            DataTable dt = new DataTable();
            String sql = "Select stf.staff_id, stf.doctor_id, concat(pfx.patient_prefix_description, ' ', stf.staff_fname_e, ' ' , stf.staff_lname_e) as name " +               
                "From " + stf.table + " stf " +
                "Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where stf." + stf.active + " ='1' and stf."+stf.status_doctor+"='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectAll1()
        {
            DataTable dt = new DataTable();
            String sql = "Select stf.staff_id, stf.staff_code, concat( stf.staff_fname_e, ' ' , stf.staff_lname_e) as name" +
                ", stf.mobile, stf.email, stf.posi_name " +
                ", stf.dept_name, stf.remark, stf.pid, '' as dept_name_t, '' as posi_name_t " +
                "From " + stf.table + " stf " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.prefix_id " +
                "Where stf." + stf.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select stf.*, pfx.prefix_name_t, '' as dept_name_t, '' as posi_name_t  " +
                "From " + stf.table + " stf " +
                "Left Join b_prefix pfx On stf.prefix_id = pfx.prefix_id " +
                "Where stf." + stf.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public Staff selectByPk1(String copId)
        {
            Staff stf1 = new Staff();
            DataTable dt = new DataTable();
            String sql = "select stf.*, pfx.patient_prefix_description, '' as dept_name_t, '' as posi_name_t  " +
                "From " + stf.table + " stf " +
                "Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where stf." + stf.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            stf1 = setStaff(dt);
            return stf1;
        }
        
        public DataTable selectCSByCodeLike(String copId)
        {
            DataTable dt = new DataTable();
            String cusId = "";
            //String sql = "select stf.staff_id, stf.staff_code, pfx.prefix_name_t,stf.staff_fname_t , stf.staff_lname_t, posi.posi_name_t, dept.dept_name_t " +
            //    "From " + stf.table + " stf " +
            //    "Left Join b_prefix pfx On stf.prefix_id = pfx.prefix_id " +
            //    "Left Join b_position posi On stf.posi_id = posi.posi_id " +
            //    "Left Join b_department dept On stf.dept_id = dept.dept_id " +
            //    "Where LOWER(stf." + stf.staff_code + ") like '" + copId.ToLower() + "%'  ";
            String sql = "select stf.*, pfx.patient_prefix_description, '' as dept_name_t, '' as posi_name_t " +
                "From " + stf.table + " stf " +
                "Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where LOWER(stf." + stf.staff_code + ") like '" + copId.ToLower() + "%'  ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }

        public Staff selectByUsername(String username)
        {
            Staff cop1 = new Staff();
            DataTable dt = new DataTable();
            String sql = "select stf.*, pfx.patient_prefix_description, '' as dept_name_t, '' as posi_name_t " +
                "From " + stf.table + " stf " +
                "Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where stf." + stf.username + " ='" + username + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setStaff(dt);
            return cop1;
        }
        public String selectByPasswordAdmin(String pass)
        {
            Staff cop1 = new Staff();
            DataTable dt = new DataTable();
            String sql = "select stf.* " +
                "From " + stf.table + " stf " +
                //"Left Join b_prefix pfx On stf.prefix_id = pfx.prefix_id " +
                "Where stf." + stf.password_confirm + " ='" + pass + "' and " + stf.status_admin + "='2'";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0][stf.staff_id].ToString();
            }
            else
            {
                return "";
            }
        }
        public String selectByPasswordConfirm(String pass)
        {
            Staff cop1 = new Staff();
            DataTable dt = new DataTable();
            String sql = "select stf.*, pfx.patient_prefix_description, '' as dept_name_t, '' as posi_name_t  " +
                "From " + stf.table + " stf " +
                "Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where stf." + stf.password_confirm + " ='" + pass + "' ";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0][stf.staff_id].ToString();
            }
            else
            {
                return "";
            }
        }
        public Staff selectByPasswordConfirm1(String pass)
        {
            Staff cop1 = new Staff();
            DataTable dt = new DataTable();
            String sql = "select stf.*, pfx.patient_prefix_description, '' as dept_name_t, '' as posi_name_t  " +
                "From " + stf.table + " stf " +
                "Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where stf." + stf.password_confirm + " ='" + pass + "' ";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                cop1 = setStaff(dt);
                return cop1;
            }
            else
            {
                return setStaff1(cop1);
            }
        }
        public Staff selectByLogin(String username, String password1)
        {
            Staff cop1 = new Staff();
            DataTable dt = new DataTable();
            try
            {
                cop1 = setStaff1(cop1);
                if (username == null)
                {
                    return cop1;
                }
                if (password1 == null)
                {
                    return cop1;
                }
                if (username.Equals(""))
                {
                    return cop1;
                }
                if (password1.Equals(""))
                {
                    return cop1;
                }
                String sql = "select stf.*, pfx.patient_prefix_description, '' as dept_name_t, '' as posi_name_t " +
                    "From " + stf.table + " stf " +
                    "Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                    "Where stf." + stf.username + " ='" + username + "' and " + stf.password1 + "='" + password1 + "' ";
                dt = conn.selectData(conn.conn, sql);
                cop1 = setStaff(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(""+ex.Message, "error");
            }
            
            return cop1;
        }
        public Staff setStaff(DataTable dt)
        {
            Staff stf1 = new Staff();
            if (dt.Rows.Count > 0)
            {
                stf1.staff_id = dt.Rows[0][stf.staff_id].ToString();
                stf1.staff_code = dt.Rows[0][stf.staff_code].ToString();
                stf1.username = dt.Rows[0][stf.username].ToString();
                stf1.prefix_id = dt.Rows[0][stf.prefix_id].ToString();
                stf1.staff_fname_t = dt.Rows[0][stf.staff_fname_t].ToString();
                stf1.staff_fname_e = dt.Rows[0][stf.staff_fname_e].ToString();
                stf1.staff_lname_t = dt.Rows[0][stf.staff_lname_t].ToString();
                stf1.staff_lname_e = dt.Rows[0][stf.staff_lname_e].ToString();
                stf1.password1 = dt.Rows[0][stf.password1].ToString();
                stf1.active = dt.Rows[0][stf.active].ToString();
                stf1.remark = dt.Rows[0][stf.remark].ToString();
                stf1.priority = dt.Rows[0][stf.priority].ToString();
                stf1.tele = dt.Rows[0][stf.tele].ToString();
                stf1.mobile = dt.Rows[0][stf.mobile].ToString();
                stf1.fax = dt.Rows[0][stf.fax].ToString();
                stf1.email = dt.Rows[0][stf.email].ToString();
                stf1.posi_id = dt.Rows[0][stf.posi_id].ToString();
                stf1.posi_name = dt.Rows[0][stf.posi_name].ToString();
                stf1.date_create = dt.Rows[0][stf.date_create].ToString();
                stf1.date_modi = dt.Rows[0][stf.date_modi].ToString();
                stf1.date_cancel = dt.Rows[0][stf.date_cancel].ToString();
                stf1.user_create = dt.Rows[0][stf.user_create].ToString();
                stf1.user_modi = dt.Rows[0][stf.user_modi].ToString();
                stf1.user_cancel = dt.Rows[0][stf.user_cancel].ToString();
                stf1.pid = dt.Rows[0][stf.pid].ToString();
                stf1.logo = dt.Rows[0][stf.logo].ToString();
                //stf1.posi_id = dt.Rows[0][stf.posi_id].ToString();
                stf1.dept_id = dt.Rows[0][stf.dept_id].ToString();
                stf1.dept_name = dt.Rows[0][stf.dept_name].ToString();
                stf1.prefix_name_t = dt.Rows[0]["patient_prefix_description"] != null ? dt.Rows[0]["patient_prefix_description"].ToString():"";
                stf1.status_admin = dt.Rows[0][stf.status_admin] != null ? dt.Rows[0][stf.status_admin].ToString():"";
                stf1.status_module_reception = dt.Rows[0][stf.status_module_reception] != null ? dt.Rows[0][stf.status_module_reception].ToString():"0";
                stf1.status_module_nurse = dt.Rows[0][stf.status_module_nurse] != null ? dt.Rows[0][stf.status_module_nurse].ToString():"0";
                stf1.status_module_doctor = dt.Rows[0][stf.status_module_doctor] != null ? dt.Rows[0][stf.status_module_doctor].ToString():"0";
                stf1.posi_name = dt.Rows[0][stf.posi_name].ToString();
                stf1.dept_name_t = dt.Rows[0][stf.dept_name_t] != null ? dt.Rows[0][stf.dept_name_t].ToString() : "";
                stf1.posi_name_t = dt.Rows[0][stf.posi_name_t] != null ? dt.Rows[0][stf.posi_name_t].ToString() : "";
                stf1.status_expense_appv = dt.Rows[0][stf.status_expense_appv] != null ? dt.Rows[0][stf.status_expense_appv].ToString() : "";
                stf1.status_expense_draw = dt.Rows[0][stf.status_expense_draw] != null ? dt.Rows[0][stf.status_expense_draw].ToString() : "";
                stf1.status_expense_pay = dt.Rows[0][stf.status_expense_pay] != null ? dt.Rows[0][stf.status_expense_pay].ToString() : "";
                stf1.password_confirm = dt.Rows[0][stf.password_confirm] != null ? dt.Rows[0][stf.password_confirm].ToString() : "";

                stf1.status_module_pharmacy = dt.Rows[0][stf.status_module_pharmacy] != null ? dt.Rows[0][stf.status_module_pharmacy].ToString() : "0";
                stf1.status_module_lab = dt.Rows[0][stf.status_module_lab] != null ? dt.Rows[0][stf.status_module_lab].ToString() : "0";
                stf1.status_module_cashier = dt.Rows[0][stf.status_module_cashier] != null ? dt.Rows[0][stf.status_module_cashier].ToString() : "0";
                stf1.status_module_medicalrecord = dt.Rows[0][stf.status_module_medicalrecord] != null ? dt.Rows[0][stf.status_module_medicalrecord].ToString() : "0";

                //foreach (DataRow row in dt.Rows)
                //{
                //    foreach (DataColumn col in dt.Columns)
                //    {
                //        object value = row[col.ColumnName];
                //    }
                //}

                stf1.status_doctor = dt.Rows[0][stf.status_doctor] != null ? dt.Rows[0][stf.status_doctor].ToString() : "0";
                stf1.doctor_id = dt.Rows[0][stf.doctor_id] != null ? dt.Rows[0][stf.doctor_id].ToString() : "0";
                stf1.doctor_id_old = dt.Rows[0][stf.doctor_id_old] != null ? dt.Rows[0][stf.doctor_id_old].ToString() : "0";
                stf1.name_full = stf1.staff_fname_e + " " + stf1.staff_lname_e;
            }
            else
            {
                setStaff1(stf1);
            }
            return stf1;
        }
        private Staff setStaff1(Staff stf1)
        {
            stf1.staff_id = "";
            stf1.staff_code = "";
            stf1.username = "";
            stf1.prefix_id = "";
            stf1.staff_fname_t = "";
            stf1.staff_fname_e = "";
            stf1.staff_lname_t = "";
            stf1.staff_lname_e = "";
            stf1.password1 = "";
            stf1.active = "";
            stf1.remark = "";
            stf1.priority = "";
            stf1.tele = "";
            stf1.mobile = "";
            stf1.fax = "";
            stf1.email = "";
            stf1.posi_id = "";
            stf1.posi_name = "";
            stf1.date_create = "";
            stf1.date_modi = "";
            stf1.date_cancel = "";
            stf1.user_create = "";
            stf1.user_modi = "";
            stf1.user_cancel = "";
            stf1.pid = "";
            stf1.logo = "";
            stf1.posi_id = "";
            stf1.dept_name = "";
            stf1.prefix_name_t = "";
            stf1.status_admin = "0";
            stf1.status_module_reception = "0";
            stf1.status_module_nurse = "0";
            stf1.status_module_doctor = "0";
            stf1.status_expense_appv = "0";
            stf1.status_expense_draw = "0";
            stf1.status_expense_pay = "0";
            stf1.password_confirm = "";
            stf1.status_module_pharmacy = "0";
            stf1.status_module_lab = "0";
            stf1.status_module_cashier = "0";
            stf1.status_module_medicalrecord = "0";
            stf1.status_doctor = "0";
            stf1.doctor_id = "0";
            stf1.doctor_id_old = "0";
            stf1.name_full = "";
            return stf1;
        }
        public String getStaffNameBylStfEx(String selected)
        {
            String re = "";
            int i = 0;
            if (lStfEx.Count <= 0) getlStfEx();
            foreach (Staff cus1 in lStfEx)
            {
                if (cus1.staff_id.Equals(selected))
                {
                    re = cus1.staff_fname_e + " " + cus1.staff_lname_e;
                    break;
                }
                i++;
            }
            return re;
        }
        public String getStaffNameBylStfLab(String selected)
        {
            String re = "";
            int i = 0;
            if (lStf.Count <= 0) getlStf();
            foreach (Staff cus1 in lStf)
            {
                if (cus1.staff_id.Equals(selected))
                {
                    re = cus1.name_lab;
                    break;
                }
                i++;
            }
            return re;
        }
        public String getStaffNameBylStf(String selected)
        {
            String re = "";
            int i = 0;
            if (lStf.Count <= 0) getlStf();            
            foreach (Staff cus1 in lStf)
            {
                if (cus1.staff_id.Equals(selected))
                {
                    re = cus1.staff_fname_e + " " + cus1.staff_lname_e;
                    break;
                }
                i++;
            }
            return re;
        }
        public String getDoctorBylStf(String selected)
        {
            String re = "";
            int i = 0;
            if (lStf.Count <= 0) getlStf();
            foreach (Staff cus1 in lStf)
            {
                if (cus1.doctor_id_old.Equals(selected))
                {
                    re = cus1.name_full;
                    break;
                }
                i++;
            }
            return re;
        }
        public void setCboStaff(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectWard();
            int i = 0;
            if (lStf.Count <= 0) getlStf();
            item = new ComboBoxItem();
            item.Value = "";
            item.Text = "";
            c.Items.Add(item);
            foreach (Staff cus1 in lStf)
            {
                item = new ComboBoxItem();
                item.Value = cus1.staff_id;
                item.Text = cus1.staff_fname_e + " " + cus1.staff_lname_e;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    //c.SelectedItem = item.Value;
                    c.SelectedText = item.Text;
                    c.SelectedIndex = i + 1;
                }
                i++;
            }
        }
        public void setCboEmbryologist(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectAllEmbryo();
            int i = 0;
            
            item = new ComboBoxItem();
            item.Value = "";
            item.Text = "";
            c.Items.Add(item);
            foreach (DataRow row in dt.Rows)
            {
                item = new ComboBoxItem();
                item.Value = row[stf.staff_id].ToString();
                item.Text = row[stf.staff_fname_e].ToString() + " " + row[stf.staff_lname_e].ToString();
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    //c.SelectedItem = item.Value;
                    c.SelectedText = item.Text;
                    c.SelectedIndex = i + 1;
                }
                i++;
            }
            if (selected.Equals(""))
            {
                if (c.Items.Count > 0)
                {
                    c.SelectedIndex = 0;
                }
            }
        }
        public void setCboDoctor(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectAllDoctor();
            int i = 0;

            item = new ComboBoxItem();
            item.Value = "";
            item.Text = "";
            c.Items.Add(item);
            foreach (DataRow row in dt.Rows)
            {
                item = new ComboBoxItem();
                item.Value = row[stf.staff_id].ToString();
                item.Text = row["name"].ToString() ;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    //c.SelectedItem = item.Value;
                    c.SelectedText = item.Text;
                    c.SelectedIndex = i + 1;
                }
                i++;
            }
            if (selected.Equals(""))
            {
                if (c.Items.Count > 0)
                {
                    c.SelectedIndex = 0;
                }
            }
        }
    }
}
