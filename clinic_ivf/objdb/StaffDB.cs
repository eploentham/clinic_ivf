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
    public class StaffDB
    {
        public Staff stf;
        ConnectDB conn;

        public List<Staff> lStf;

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
            stf.prefix_name_t = "prefix_name_t";
            stf.status_admin = "status_admin";
            stf.status_module_imp_job = "status_module_imp_job";
            stf.status_module_exp_job = "status_module_exp_job";
            stf.status_module_other_job = "status_module_other_job";
            stf.posi_name_t = "posi_name_t";
            stf.dept_name_t = "dept_name_t";
            stf.dept_id = "dept_id";
            stf.status_expense_appv = "status_expense_appv";
            stf.status_expense_draw = "status_expense_draw";
            stf.status_expense_pay = "status_expense_pay";
            stf.password_confirm = "password_confirm";

            stf.table = "b_staff";
            stf.pkField = "staff_id";

            lStf = new List<Staff>();
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
                //cus1.c = row[dept.dept_parent_id].ToString();
                //cus1.remark = row[dept.remark].ToString();
                //cus1.date_create = row[dept.date_create].ToString();
                //cus1.date_modi = row[dept.date_modi].ToString();
                //cus1.date_cancel = row[dept.date_cancel].ToString();
                //cus1.user_create = row[dept.user_create].ToString();
                //cus1.user_modi = row[dept.user_modi].ToString();
                //cus1.user_cancel = row[dept.user_cancel].ToString();
                //cus1.active = row[dept.active].ToString();
                lStf.Add(stf1);
            }
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
            int chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.prefix_id = int.TryParse(p.prefix_id, out chk) ? chk.ToString() : "0";
            p.posi_id = int.TryParse(p.posi_id, out chk) ? chk.ToString() : "0";
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


            p.status_admin = p.status_admin == null ? "0" : p.status_admin;
            p.status_module_imp_job = p.status_module_imp_job == null ? "0" : p.status_module_imp_job;
            p.status_module_exp_job = p.status_module_exp_job == null ? "0" : p.status_module_exp_job;
            p.status_admin = p.status_admin.Equals("") ? "0" : p.status_admin;
            p.status_module_imp_job = p.status_module_imp_job.Equals("") ? "0" : p.status_module_imp_job;
            p.status_module_exp_job = p.status_module_exp_job.Equals("") ? "0" : p.status_module_exp_job;
            p.status_module_other_job = p.status_module_other_job.Equals("") ? "0" : p.status_module_other_job;
            p.status_expense_appv = p.status_expense_appv == null ? "0" : p.status_expense_appv;
            p.status_expense_draw = p.status_expense_draw == null ? "0" : p.status_expense_draw;
            p.status_expense_pay = p.status_expense_pay == null ? "0" : p.status_expense_pay;
            //p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
        }
        public String insert(Staff p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            sql = "Insert Into " + stf.table + "(" + stf.staff_code + "," + stf.username + "," + stf.prefix_id + "," +
                stf.staff_fname_t + "," + stf.staff_fname_e + "," + stf.password1 + "," +
                stf.active + "," + stf.remark + "," + stf.priority + "," +
                stf.tele + "," + stf.mobile + "," + stf.fax + "," +
                stf.email + "," + stf.posi_id + "," + stf.posi_name + "," +
                stf.date_create + "," + stf.date_modi + "," + stf.date_cancel + "," +
                stf.user_create + "," + stf.user_modi + "," + stf.user_cancel + "," +
                stf.staff_lname_t + "," + stf.staff_lname_e + ", " + stf.pid + "," +
                stf.logo + ", " + stf.posi_id + ", " + stf.dept_name + "," +
                stf.status_admin + ", " + stf.status_module_imp_job + "," + stf.status_module_exp_job + "," +
                stf.status_module_other_job + "," +
                stf.status_expense_appv + "," + stf.status_expense_draw + "," + stf.status_expense_pay + " " +
                ") " +
                "Values ('" + p.staff_code + "','" + p.username + "','" + p.prefix_id + "'," +
                "'" + p.staff_fname_t.Replace("'", "''") + "','" + p.staff_fname_e.Replace("'", "''") + "','" + p.password1 + "'," +
                "'" + p.active + "','" + p.remark + "','" + p.priority + "'," +
                "'" + p.tele + "','" + p.mobile + "','" + p.fax + "'," +
                "'" + p.email + "','" + p.posi_id + "','" + p.posi_name + "'," +
                "now(),'" + p.date_modi + "','" + p.date_cancel + "'," +
                "'" + userId + "','" + p.user_modi + "','" + p.user_cancel + "', " +
                "'" + p.staff_lname_t.Replace("'", "''") + "','" + p.staff_lname_e.Replace("'", "''") + "','" + p.pid + "'," +
                "'" + p.logo + "','" + p.posi_id + "','" + p.dept_name.Replace("'", "''") + "'," +
                "'" + p.status_admin + "','" + p.status_module_imp_job + "','" + p.status_module_exp_job.Replace("'", "''") + "'," +
                "'" + p.status_module_other_job.Replace("'", "''") + "'," +
                "'" + p.status_expense_appv + "','" + p.status_expense_draw + "','" + p.status_expense_pay.Replace("'", "''") + "' " +
                ")";
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
                "," + stf.password1 + " = '" + p.password1.Replace("'", "''") + "'" +
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
                "," + stf.status_admin + " = '" + p.status_admin.Replace("'", "''") + "' " +
                "," + stf.status_module_imp_job + " = '" + p.status_module_imp_job.Replace("'", "''") + "' " +
                "," + stf.status_module_exp_job + " = '" + p.status_module_exp_job.Replace("'", "''") + "' " +
                "," + stf.status_module_other_job + " = '" + p.status_module_other_job.Replace("'", "''") + "' " +
                "," + stf.status_expense_appv + " = '" + p.status_expense_appv.Replace("'", "''") + "' " +
                "," + stf.status_expense_draw + " = '" + p.status_expense_draw.Replace("'", "''") + "' " +
                "," + stf.status_expense_pay + " = '" + p.status_expense_pay.Replace("'", "''") + "' " +
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
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select cop.*  " +
                "From " + stf.table + " cop " +
                " " +
                "Where cop." + stf.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectAll1()
        {
            DataTable dt = new DataTable();
            String sql = "Select stf.staff_id, stf.staff_code, concat( stf.staff_fname_t, ' ' , stf.staff_lname_t) as name" +
                ", stf.mobile, stf.email, stf.posi_name " +
                ", stf.dept_name, stf.remark, stf.pid, '' as dept_name_t, '' as posi_name_t " +
                "From " + stf.table + " stf " +
                //"Left Join b_prefix pfx On stf.prefix_id = pfx.prefix_id " +
                "Where stf." + stf.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select stf.* " +
                "From " + stf.table + " stf " +
                "Where stf." + stf.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public Staff selectByPk1(String copId)
        {
            Staff stf1 = new Staff();
            DataTable dt = new DataTable();
            String sql = "select stf.* " +
                "From " + stf.table + " stf " +
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
            String sql = "select stf.*, pfx.prefix_name_t, '' as dept_name_t, '' as posi_name_t " +
                "From " + stf.table + " stf " +
                "Left Join b_prefix pfx On stf.prefix_id = pfx.prefix_id " +
                "Where LOWER(stf." + stf.staff_code + ") like '" + copId.ToLower() + "%'  ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        

        public Staff selectByUsername(String username)
        {
            Staff cop1 = new Staff();
            DataTable dt = new DataTable();
            String sql = "select stf.*, pfx.prefix_name_t, '' as dept_name_t, '' as posi_name_t " +
                "From " + stf.table + " stf " +
                "Left Join b_prefix pfx On stf.prefix_id = pfx.prefix_id " +
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
                "Where stf." + stf.password1 + " ='" + pass + "' and " + stf.status_admin + "='2'";
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
            String sql = "select stf.*, pfx.prefix_name_t, '' as dept_name_t, '' as posi_name_t  " +
                "From " + stf.table + " stf " +
                "Left Join b_prefix pfx On stf.prefix_id = pfx.prefix_id " +
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
            String sql = "select stf.*, pfx.prefix_name_t, '' as dept_name_t, '' as posi_name_t  " +
                "From " + stf.table + " stf " +
                "Left Join b_prefix pfx On stf.prefix_id = pfx.prefix_id " +
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
            String sql = "select stf.*, pfx.prefix_name_t, '' as dept_name_t, '' as posi_name_t " +
                "From " + stf.table + " stf " +
                "Left Join b_prefix pfx On stf.prefix_id = pfx.prefix_id " +
                "Where stf." + stf.username + " ='" + username + "' and " + stf.password1 + "='" + password1 + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setStaff(dt);
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
                stf1.posi_id = dt.Rows[0][stf.posi_id].ToString();
                stf1.dept_name = dt.Rows[0][stf.dept_name].ToString();
                stf1.prefix_name_t = dt.Rows[0][stf.prefix_name_t] != null ? dt.Rows[0][stf.prefix_name_t].ToString():"";
                stf1.status_admin = dt.Rows[0][stf.status_admin] != null ? dt.Rows[0][stf.status_admin].ToString():"";
                stf1.status_module_imp_job = dt.Rows[0][stf.status_module_imp_job] != null ? dt.Rows[0][stf.status_module_imp_job].ToString():"";
                stf1.status_module_exp_job = dt.Rows[0][stf.status_module_exp_job] != null ? dt.Rows[0][stf.status_module_exp_job].ToString():"";
                stf1.status_module_other_job = dt.Rows[0][stf.status_module_other_job] != null ? dt.Rows[0][stf.status_module_other_job].ToString():"";
                stf1.posi_name = dt.Rows[0][stf.posi_name].ToString();
                stf1.dept_name_t = dt.Rows[0][stf.dept_name_t] != null ? dt.Rows[0][stf.dept_name_t].ToString() : "";
                stf1.posi_name_t = dt.Rows[0][stf.posi_name_t] != null ? dt.Rows[0][stf.posi_name_t].ToString() : "";
                stf1.status_expense_appv = dt.Rows[0][stf.status_expense_appv] != null ? dt.Rows[0][stf.status_expense_appv].ToString() : "";
                stf1.status_expense_draw = dt.Rows[0][stf.status_expense_draw] != null ? dt.Rows[0][stf.status_expense_draw].ToString() : "";
                stf1.status_expense_pay = dt.Rows[0][stf.status_expense_pay] != null ? dt.Rows[0][stf.status_expense_pay].ToString() : "";
                stf1.password_confirm = dt.Rows[0][stf.password_confirm] != null ? dt.Rows[0][stf.password_confirm].ToString() : "";
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
            stf1.status_module_imp_job = "0";
            stf1.status_module_exp_job = "0";
            stf1.status_module_other_job = "0";
            stf1.status_expense_appv = "0";
            stf1.status_expense_draw = "0";
            stf1.status_expense_pay = "0";
            stf1.password_confirm = "";
            return stf1;
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
                item.Text = cus1.staff_fname_t + " " + cus1.staff_lname_t;
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
    }
}
