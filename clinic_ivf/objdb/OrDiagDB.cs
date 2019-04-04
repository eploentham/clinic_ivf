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
    public class OrDiagDB
    {
        public OrDiag ord;
        ConnectDB conn;

        public List<OrDiag> lDept;

        public OrDiagDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            ord = new OrDiag();
            ord.diag_id = "diag_id";
            ord.diag_code = "diag_code";
            ord.diag_code_ex = "diag_code_ex";
            ord.diag_name = "diag_name";
            ord.diag_group_id = "diag_group_id";
            ord.remark = "remark";
            ord.date_create = "date_create";
            ord.date_modi = "date_modi";
            ord.date_cancel = "date_cancel";
            ord.user_create = "user_create";
            ord.user_modi = "user_modi";
            ord.user_cancel = "user_cancel";
            ord.active = "active";
            ord.sort1 = "sort1";

            ord.table = "or_b_diag";
            ord.pkField = "diag_id";

            lDept = new List<OrDiag>();
            //getlDept();
        }
        public String insert(OrDiag p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            long chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.diag_code = p.diag_code == null ? "" : p.diag_code;
            p.diag_code_ex = p.diag_code_ex == null ? "" : p.diag_code_ex;
            p.diag_name = p.diag_name == null ? "0" : p.diag_name;
            p.remark = p.remark == null ? "" : p.remark;
            p.sort1 = p.sort1 == null ? "" : p.sort1;
            p.diag_group_id = long.TryParse(p.diag_group_id, out chk) ? chk.ToString() : "0";

            sql = "Insert Into " + ord.table + " Set " +
                "" + ord.diag_code + " = '" + p.diag_code + "' " +
                "," + ord.diag_code_ex + " = '" + p.diag_code_ex + "' " +
                "," + ord.diag_name + " = '" + p.diag_name.Replace("'", "''") + "' " +
                "," + ord.remark + " = '" + p.remark.Replace("'", "''") + "' " +
                "," + ord.date_create + " = now() " +
                "," + ord.date_modi + " = '" + p.date_modi + "' " +
                "," + ord.date_cancel + " = '" + p.date_cancel + "' " +
                "," + ord.user_create + " = '" + p.user_create + "' " +
                "," + ord.user_modi + " = '" + p.user_modi + "' " +
                "," + ord.user_cancel + " = '" + p.user_cancel + "' " +
                "," + ord.active + " " + " = '" + p.active + "' " +
                "," + ord.sort1 + " " + " = '" + p.sort1 + "' " +
                "," + ord.diag_group_id + " " + " = '" + p.diag_group_id + "' " +
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
        public String update(OrDiag p, String userId)
        {
            String re = "";
            String sql = "";
            long chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.diag_code = p.diag_code == null ? "" : p.diag_code;
            p.diag_code_ex = p.diag_code_ex == null ? "" : p.diag_code_ex;
            p.diag_name = p.diag_name == null ? "0" : p.diag_name;
            p.remark = p.remark == null ? "" : p.remark;
            p.sort1 = p.sort1 == null ? "" : p.sort1;
            p.diag_group_id = long.TryParse(p.diag_group_id, out chk) ? chk.ToString() : "0";

            sql = "Update " + ord.table + " Set " +
                "" + ord.diag_code + " = '" + p.diag_code + "' " +
                "," + ord.diag_code_ex + " = '" + p.diag_code_ex + "' " +
                "," + ord.diag_name + " = '" + p.diag_name.Replace("'", "''") + "' " +
                "," + ord.remark + " = '" + p.remark.Replace("'", "''") + "' " +
                "," + ord.date_create + " = now() " +
                "," + ord.date_modi + " = '" + p.date_modi + "' " +
                "," + ord.date_cancel + " = '" + p.date_cancel + "' " +
                "," + ord.user_create + " = '" + p.user_create + "' " +
                "," + ord.user_modi + " = '" + p.user_modi + "' " +
                "," + ord.user_cancel + " = '" + p.user_cancel + "' " +
                "," + ord.active + " " + " = '" + p.active + "' " +
                "," + ord.sort1 + " " + " = '" + p.sort1 + "' " +
                "," + ord.diag_group_id + " " + " = '" + p.diag_group_id + "' " +
                "Where " + ord.pkField + "='" + p.diag_id + "'"
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
        public String insertOrDiag(OrDiag p, String userId)
        {
            String re = "";

            if (p.diag_id.Equals(""))
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
            String sql = "Delete From  " + ord.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public String VoidOrDiagGroup(String deptId, String userIdVoid)
        {
            DataTable dt = new DataTable();
            String sql = "Update " + ord.table + " Set " +
                "" + ord.active + "='3' " +
                "," + ord.date_cancel + "=now() " +
                "," + ord.user_cancel + "='" + userIdVoid + "' " +
                "Where " + ord.pkField + "='" + deptId + "'";
            conn.ExecuteNonQuery(conn.conn, sql);
            return "1";
        }
        public void getlOrDiag()
        {
            //lDept = new List<Position>();

            lDept.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                OrDiag dept1 = new OrDiag();
                dept1.diag_id = row[ord.diag_id].ToString();
                dept1.diag_code = row[ord.diag_code].ToString();
                dept1.diag_code_ex = row[ord.diag_code_ex].ToString();

                dept1.diag_name = row[ord.diag_name].ToString();
                //dept1.remark = row[ordg.remark].ToString();
                //dept1.date_create = row[ordg.date_create].ToString();
                //dept1.date_modi = row[ordg.date_modi].ToString();
                //dept1.date_cancel = row[ordg.date_cancel].ToString();
                //dept1.user_create = row[ordg.user_create].ToString();
                //dept1.user_modi = row[ordg.user_modi].ToString();
                //dept1.user_cancel = row[ordg.user_cancel].ToString();
                dept1.active = row[ord.active].ToString();
                lDept.Add(dept1);
            }
        }
        public String getIdByCode(String code)
        {
            String id = "";
            foreach (OrDiag dept1 in lDept)
            {
                if (code.Trim().Equals(dept1.diag_code.Trim()))
                {
                    id = dept1.diag_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (OrDiag dept1 in lDept)
            {
                if (name.Trim().Equals(dept1.diag_code_ex.Trim()))
                {
                    id = dept1.diag_id;
                    break;
                }
            }
            return id;
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select ordg.*  " +
                "From " + ord.table + " ordg " +
                " " +
                "Where ordg." + ord.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectAll1()
        {
            DataTable dt = new DataTable();
            String sql = "select ord.diag_id, ord.diag_code, ord.diag_name  " +
                "From " + ord.table + " ord " +
                " " +
                "Where ord." + ord.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByGroup(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select ordg.* " +
                "From " + ord.table + " ordg " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where ordg." + ord.diag_group_id + " ='" + copId + "' and "+ord.active+"='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByGroup1(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select ord." + ord.diag_id+ ",ord." + ord.diag_code+ ",ord." + ord.diag_name+ ",ord." + ord.diag_group_id + ",ordg.diag_group_name " +
                "From " + ord.table + " ord " +
                "Left Join or_b_diag_group ordg On ord.diag_group_id = ordg.diag_group_id " +
                "Where ord." + ord.diag_group_id + " ='" + copId + "' and ord." + ord.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select ordg.* " +
                "From " + ord.table + " ordg " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where ordg." + ord.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public OrDiag selectByPk1(String copId)
        {
            OrDiag cop1 = new OrDiag();
            DataTable dt = new DataTable();
            String sql = "select ordg.* " +
                "From " + ord.table + " ordg " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where ordg." + ord.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setOrDiag(dt);
            return cop1;
        }
        private OrDiag setOrDiag(DataTable dt)
        {
            OrDiag dept1 = new OrDiag();
            if (dt.Rows.Count > 0)
            {
                dept1.diag_id = dt.Rows[0][ord.diag_id].ToString();
                dept1.diag_code = dt.Rows[0][ord.diag_code].ToString();
                dept1.diag_code_ex = dt.Rows[0][ord.diag_code_ex].ToString();
                dept1.diag_name = dt.Rows[0][ord.diag_name].ToString();
                dept1.remark = dt.Rows[0][ord.remark].ToString();
                dept1.date_create = dt.Rows[0][ord.date_create].ToString();
                dept1.date_modi = dt.Rows[0][ord.date_modi].ToString();
                dept1.date_cancel = dt.Rows[0][ord.date_cancel].ToString();
                dept1.user_create = dt.Rows[0][ord.user_create].ToString();
                dept1.user_modi = dt.Rows[0][ord.user_modi].ToString();
                dept1.user_cancel = dt.Rows[0][ord.user_cancel].ToString();
                dept1.active = dt.Rows[0][ord.active].ToString();
                dept1.sort1 = dt.Rows[0][ord.sort1].ToString();
                dept1.diag_group_id = dt.Rows[0][ord.diag_group_id].ToString();
            }
            else
            {
                dept1.diag_id = "";
                dept1.diag_code = "";
                dept1.diag_code_ex = "";

                dept1.diag_name = "";
                dept1.remark = "";
                dept1.date_create = "";
                dept1.date_modi = "";
                dept1.date_cancel = "";
                dept1.user_create = "";
                dept1.user_modi = "";
                dept1.user_cancel = "";
                dept1.active = "";
                dept1.sort1 = "";
                dept1.diag_group_id = "";
            }

            return dept1;
        }
        public DataTable selectC1()
        {
            DataTable dt = new DataTable();
            String sql = "select ordg." + ord.pkField + ",ordg." + ord.diag_code_ex + " " +
                "From " + ord.table + " ordg " +
                " " +
                "Where ordg." + ord.active + " ='1' ";
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
                item.Text = row[ord.diag_code_ex].ToString();
                item.Value = row[ord.diag_id].ToString();

                c.Items.Add(item);
            }
            return c;
        }
    }
}
