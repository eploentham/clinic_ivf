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
    public class OrAnesthesiaDB
    {
        public OrAnesthesia oranes;
        ConnectDB conn;

        public List<OrAnesthesia> lDept;

        public OrAnesthesiaDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            oranes = new OrAnesthesia();
            oranes.anesthesia_id = "anesthesia_id";
            oranes.anesthesia_code = "anesthesia_code";
            oranes.anesthesia_code_ex = "anesthesia_code_ex";

            oranes.anesthesia_name = "anesthesia_name";
            oranes.remark = "remark";
            oranes.date_create = "date_create";
            oranes.date_modi = "date_modi";
            oranes.date_cancel = "date_cancel";
            oranes.user_create = "user_create";
            oranes.user_modi = "user_modi";
            oranes.user_cancel = "user_cancel";
            oranes.active = "active";
            oranes.sort1 = "sort1";

            oranes.table = "or_b_anesthesia";
            oranes.pkField = "anesthesia_id";

            lDept = new List<OrAnesthesia>();
            //getlDept();
        }
        public String insert(OrAnesthesia p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.anesthesia_code = p.anesthesia_code == null ? "" : p.anesthesia_code;
            p.anesthesia_code_ex = p.anesthesia_code_ex == null ? "" : p.anesthesia_code_ex;
            p.anesthesia_name = p.anesthesia_name == null ? "0" : p.anesthesia_name;
            p.remark = p.remark == null ? "" : p.remark;
            p.sort1 = p.sort1 == null ? "" : p.sort1;

            sql = "Insert Into " + oranes.table + " Set " +
                "" + oranes.anesthesia_code + " = '" + p.anesthesia_code + "' " +
                "," + oranes.anesthesia_code_ex + " = '" + p.anesthesia_code_ex + "' " +
                "," + oranes.anesthesia_name + " = '" + p.anesthesia_name + "' " +
                "," + oranes.remark + " = '" + p.remark + "' " +
                "," + oranes.date_create + " = now() " +
                "," + oranes.date_modi + " = '" + p.date_modi + "' " +
                "," + oranes.date_cancel + " = '" + p.date_cancel + "' " +
                "," + oranes.user_create + " = '" + p.user_create + "' " +
                "," + oranes.user_modi + " = '" + p.user_modi + "' " +
                "," + oranes.user_cancel + " = '" + p.user_cancel + "' " +
                "," + oranes.active + " " + " = '" + p.active + "' " +
                "," + oranes.sort1 + " " + " = '" + p.sort1 + "' " +
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
        public String update(OrAnesthesia p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.anesthesia_code = p.anesthesia_code == null ? "" : p.anesthesia_code;
            p.anesthesia_code_ex = p.anesthesia_code_ex == null ? "" : p.anesthesia_code_ex;
            p.anesthesia_name = p.anesthesia_name == null ? "0" : p.anesthesia_name;
            p.remark = p.remark == null ? "" : p.remark;
            p.sort1 = p.sort1 == null ? "" : p.sort1;

            sql = "Update " + oranes.table + " Set " +
                "" + oranes.anesthesia_code + " = '" + p.anesthesia_code + "' " +
                "," + oranes.anesthesia_code_ex + " = '" + p.anesthesia_code_ex + "' " +
                "," + oranes.anesthesia_name + " = '" + p.anesthesia_name.Replace("'", "''") + "' " +
                "," + oranes.remark + " = '" + p.remark.Replace("'", "''") + "' " +
                "," + oranes.date_modi + " = now() " +               
                "," + oranes.user_modi + " = '" + p.user_modi + "' " +
                "," + oranes.active + " " + " = '" + p.active + "' " +
                "," + oranes.sort1 + " " + " = '" + p.sort1 + "' " +
                "Where " + oranes.pkField + "='" + p.anesthesia_id + "'"
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
        public String insertOrDiagGroup(OrAnesthesia p, String userId)
        {
            String re = "";

            if (p.anesthesia_id.Equals(""))
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
            String sql = "Delete From  " + oranes.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public String VoidOrDiagGroup(String deptId, String userIdVoid)
        {
            DataTable dt = new DataTable();
            String sql = "Update " + oranes.table + " Set " +
                "" + oranes.active + "='3' " +
                "," + oranes.date_cancel + "=now() " +
                "," + oranes.user_cancel + "='" + userIdVoid + "' " +
                "Where " + oranes.pkField + "='" + deptId + "'";
            conn.ExecuteNonQuery(conn.conn, sql);
            return "1";
        }
        public void getlOrDiagGroup()
        {
            //lDept = new List<Position>();

            lDept.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                OrAnesthesia dept1 = new OrAnesthesia();
                dept1.anesthesia_id = row[oranes.anesthesia_id].ToString();
                dept1.anesthesia_code = row[oranes.anesthesia_code].ToString();
                dept1.anesthesia_code_ex = row[oranes.anesthesia_code_ex].ToString();

                dept1.anesthesia_name = row[oranes.anesthesia_name].ToString();
                //dept1.remark = row[ordg.remark].ToString();
                //dept1.date_create = row[ordg.date_create].ToString();
                //dept1.date_modi = row[ordg.date_modi].ToString();
                //dept1.date_cancel = row[ordg.date_cancel].ToString();
                //dept1.user_create = row[ordg.user_create].ToString();
                //dept1.user_modi = row[ordg.user_modi].ToString();
                //dept1.user_cancel = row[ordg.user_cancel].ToString();
                dept1.active = row[oranes.active].ToString();
                lDept.Add(dept1);
            }
        }
        public String getIdByCode(String code)
        {
            String id = "";
            foreach (OrAnesthesia dept1 in lDept)
            {
                if (code.Trim().Equals(dept1.anesthesia_code.Trim()))
                {
                    id = dept1.anesthesia_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (OrAnesthesia dept1 in lDept)
            {
                if (name.Trim().Equals(dept1.anesthesia_code_ex.Trim()))
                {
                    id = dept1.anesthesia_id;
                    break;
                }
            }
            return id;
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select ordg.*  " +
                "From " + oranes.table + " ordg " +
                " " +
                "Where ordg." + oranes.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectAll1()
        {
            DataTable dt = new DataTable();
            String sql = "select ordg.anesthesia_id, ordg.dept_code, ordg.dept_name_t, ordg.remark  " +
                "From " + oranes.table + " ordg " +
                " " +
                "Where ordg." + oranes.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select ordg.* " +
                "From " + oranes.table + " ordg " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where ordg." + oranes.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public OrAnesthesia selectByPk1(String copId)
        {
            OrAnesthesia cop1 = new OrAnesthesia();
            DataTable dt = new DataTable();
            String sql = "select ordg.* " +
                "From " + oranes.table + " ordg " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where ordg." + oranes.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setOrDiagGroup(dt);
            return cop1;
        }
        private OrAnesthesia setOrDiagGroup(DataTable dt)
        {
            OrAnesthesia dept1 = new OrAnesthesia();
            if (dt.Rows.Count > 0)
            {
                dept1.anesthesia_id = dt.Rows[0][oranes.anesthesia_id].ToString();
                dept1.anesthesia_code = dt.Rows[0][oranes.anesthesia_code].ToString();
                dept1.anesthesia_code_ex = dt.Rows[0][oranes.anesthesia_code_ex].ToString();
                dept1.anesthesia_name = dt.Rows[0][oranes.anesthesia_name].ToString();
                dept1.remark = dt.Rows[0][oranes.remark].ToString();
                dept1.date_create = dt.Rows[0][oranes.date_create].ToString();
                dept1.date_modi = dt.Rows[0][oranes.date_modi].ToString();
                dept1.date_cancel = dt.Rows[0][oranes.date_cancel].ToString();
                dept1.user_create = dt.Rows[0][oranes.user_create].ToString();
                dept1.user_modi = dt.Rows[0][oranes.user_modi].ToString();
                dept1.user_cancel = dt.Rows[0][oranes.user_cancel].ToString();
                dept1.active = dt.Rows[0][oranes.active].ToString();
                dept1.sort1 = dt.Rows[0][oranes.sort1].ToString();
            }
            else
            {
                dept1.anesthesia_id = "";
                dept1.anesthesia_code = "";
                dept1.anesthesia_code_ex = "";

                dept1.anesthesia_name = "";
                dept1.remark = "";
                dept1.date_create = "";
                dept1.date_modi = "";
                dept1.date_cancel = "";
                dept1.user_create = "";
                dept1.user_modi = "";
                dept1.user_cancel = "";
                dept1.active = "";
                dept1.sort1 = "";
            }

            return dept1;
        }
        public DataTable selectC1()
        {
            DataTable dt = new DataTable();
            String sql = "select ordg." + oranes.pkField + ",ordg." + oranes.anesthesia_code_ex + " " +
                "From " + oranes.table + " ordg " +
                " " +
                "Where ordg." + oranes.active + " ='1' ";
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
                item.Text = row[oranes.anesthesia_code_ex].ToString();
                item.Value = row[oranes.anesthesia_id].ToString();

                c.Items.Add(item);
            }
            return c;
        }
    }
}
