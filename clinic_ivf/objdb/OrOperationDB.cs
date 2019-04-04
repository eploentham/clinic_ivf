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
    public class OrOperationDB
    {
        public OrOperation ord;
        ConnectDB conn;

        public List<OrOperation> lDept;

        public OrOperationDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            ord = new OrOperation();
            ord.opera_id = "opera_id";
            ord.opera_code = "opera_code";
            ord.opera_code_ex = "opera_code_ex";
            ord.opera_name = "opera_name";
            ord.opera_group_id = "opera_group_id";
            ord.remark = "remark";
            ord.date_create = "date_create";
            ord.date_modi = "date_modi";
            ord.date_cancel = "date_cancel";
            ord.user_create = "user_create";
            ord.user_modi = "user_modi";
            ord.user_cancel = "user_cancel";
            ord.active = "active";
            ord.sort1 = "sort1";

            ord.table = "or_b_operation";
            ord.pkField = "opera_id";

            lDept = new List<OrOperation>();
            //getlDept();
        }
        public String insert(OrOperation p, String userId)
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
            p.opera_code = p.opera_code == null ? "" : p.opera_code;
            p.opera_code_ex = p.opera_code_ex == null ? "" : p.opera_code_ex;
            p.opera_name = p.opera_name == null ? "0" : p.opera_name;
            p.remark = p.remark == null ? "" : p.remark;
            p.sort1 = p.sort1 == null ? "" : p.sort1;
            p.opera_group_id = long.TryParse(p.opera_group_id, out chk) ? chk.ToString() : "0";

            sql = "Insert Into " + ord.table + " Set " +
                "" + ord.opera_code + " = '" + p.opera_code + "' " +
                "," + ord.opera_code_ex + " = '" + p.opera_code_ex + "' " +
                "," + ord.opera_name + " = '" + p.opera_name.Replace("'", "''") + "' " +
                "," + ord.remark + " = '" + p.remark.Replace("'", "''") + "' " +
                "," + ord.date_create + " = now() " +
                "," + ord.date_modi + " = '" + p.date_modi + "' " +
                "," + ord.date_cancel + " = '" + p.date_cancel + "' " +
                "," + ord.user_create + " = '" + p.user_create + "' " +
                "," + ord.user_modi + " = '" + p.user_modi + "' " +
                "," + ord.user_cancel + " = '" + p.user_cancel + "' " +
                "," + ord.active + " " + " = '" + p.active + "' " +
                "," + ord.sort1 + " " + " = '" + p.sort1 + "' " +
                "," + ord.opera_group_id + " " + " = '" + p.opera_group_id + "' " +
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
        public String update(OrOperation p, String userId)
        {
            String re = "";
            String sql = "";
            long chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.opera_code = p.opera_code == null ? "" : p.opera_code;
            p.opera_code_ex = p.opera_code_ex == null ? "" : p.opera_code_ex;
            p.opera_name = p.opera_name == null ? "0" : p.opera_name;
            p.remark = p.remark == null ? "" : p.remark;
            p.sort1 = p.sort1 == null ? "" : p.sort1;
            p.opera_group_id = long.TryParse(p.opera_group_id, out chk) ? chk.ToString() : "0";

            sql = "Update " + ord.table + " Set " +
                "" + ord.opera_code + " = '" + p.opera_code + "' " +
                "," + ord.opera_code_ex + " = '" + p.opera_code_ex + "' " +
                "," + ord.opera_name + " = '" + p.opera_name.Replace("'", "''") + "' " +
                "," + ord.remark + " = '" + p.remark.Replace("'", "''") + "' " +
                "," + ord.date_create + " = now() " +
                "," + ord.date_modi + " = '" + p.date_modi + "' " +
                "," + ord.date_cancel + " = '" + p.date_cancel + "' " +
                "," + ord.user_create + " = '" + p.user_create + "' " +
                "," + ord.user_modi + " = '" + p.user_modi + "' " +
                "," + ord.user_cancel + " = '" + p.user_cancel + "' " +
                "," + ord.active + " " + " = '" + p.active + "' " +
                "," + ord.sort1 + " " + " = '" + p.sort1 + "' " +
                "," + ord.opera_group_id + " " + " = '" + p.opera_group_id + "' " +
                "Where " + ord.pkField + "='" + p.opera_id + "'"
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
        public String insertOrDiag(OrOperation p, String userId)
        {
            String re = "";

            if (p.opera_id.Equals(""))
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
                OrOperation dept1 = new OrOperation();
                dept1.opera_id = row[ord.opera_id].ToString();
                dept1.opera_code = row[ord.opera_code].ToString();
                dept1.opera_code_ex = row[ord.opera_code_ex].ToString();

                dept1.opera_name = row[ord.opera_name].ToString();
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
            foreach (OrOperation dept1 in lDept)
            {
                if (code.Trim().Equals(dept1.opera_code.Trim()))
                {
                    id = dept1.opera_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (OrOperation dept1 in lDept)
            {
                if (name.Trim().Equals(dept1.opera_code_ex.Trim()))
                {
                    id = dept1.opera_id;
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
            String sql = "select ord.opera_id, ord.opera_code, ord.opera_name  " +
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
                "Where ordg." + ord.opera_group_id + " ='" + copId + "' and "+ord.active+"='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByGroup1(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select ord." + ord.opera_id+ ",ord." + ord.opera_code+ ",ord." + ord.opera_name+ ",ord." + ord.opera_group_id + ",ordg.opera_group_name " +
                "From " + ord.table + " ord " +
                "Left Join or_b_operation_group ordg On ord.opera_group_id = ordg.opera_group_id " +
                "Where ord." + ord.opera_group_id + " ='" + copId + "' and ord." + ord.active + "='1' ";
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
        public OrOperation selectByPk1(String copId)
        {
            OrOperation cop1 = new OrOperation();
            DataTable dt = new DataTable();
            String sql = "select ordg.* " +
                "From " + ord.table + " ordg " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where ordg." + ord.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setOrDiag(dt);
            return cop1;
        }
        private OrOperation setOrDiag(DataTable dt)
        {
            OrOperation dept1 = new OrOperation();
            if (dt.Rows.Count > 0)
            {
                dept1.opera_id = dt.Rows[0][ord.opera_id].ToString();
                dept1.opera_code = dt.Rows[0][ord.opera_code].ToString();
                dept1.opera_code_ex = dt.Rows[0][ord.opera_code_ex].ToString();
                dept1.opera_name = dt.Rows[0][ord.opera_name].ToString();
                dept1.remark = dt.Rows[0][ord.remark].ToString();
                dept1.date_create = dt.Rows[0][ord.date_create].ToString();
                dept1.date_modi = dt.Rows[0][ord.date_modi].ToString();
                dept1.date_cancel = dt.Rows[0][ord.date_cancel].ToString();
                dept1.user_create = dt.Rows[0][ord.user_create].ToString();
                dept1.user_modi = dt.Rows[0][ord.user_modi].ToString();
                dept1.user_cancel = dt.Rows[0][ord.user_cancel].ToString();
                dept1.active = dt.Rows[0][ord.active].ToString();
                dept1.sort1 = dt.Rows[0][ord.sort1].ToString();
                dept1.opera_group_id = dt.Rows[0][ord.opera_group_id].ToString();
            }
            else
            {
                dept1.opera_id = "";
                dept1.opera_code = "";
                dept1.opera_code_ex = "";

                dept1.opera_name = "";
                dept1.remark = "";
                dept1.date_create = "";
                dept1.date_modi = "";
                dept1.date_cancel = "";
                dept1.user_create = "";
                dept1.user_modi = "";
                dept1.user_cancel = "";
                dept1.active = "";
                dept1.sort1 = "";
                dept1.opera_group_id = "";
            }

            return dept1;
        }
        public DataTable selectC1()
        {
            DataTable dt = new DataTable();
            String sql = "select ordg." + ord.pkField + ",ordg." + ord.opera_code_ex + " " +
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
                item.Text = row[ord.opera_code_ex].ToString();
                item.Value = row[ord.opera_id].ToString();

                c.Items.Add(item);
            }
            return c;
        }
    }
}
