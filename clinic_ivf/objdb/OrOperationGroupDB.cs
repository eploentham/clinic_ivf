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
    public class OrOperationGroupDB
    {
        public OrOperationGroup ordg;
        ConnectDB conn;

        public List<OrOperationGroup> lDept;

        public OrOperationGroupDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            ordg = new OrOperationGroup();
            ordg.opera_group_id = "opera_group_id";
            ordg.opera_group_code = "opera_group_code";
            ordg.opera_group_name = "opera_group_name";
            
            ordg.status_or_opera_req = "status_or_opera_req";
            ordg.remark = "remark";
            ordg.date_create = "date_create";
            ordg.date_modi = "date_modi";
            ordg.date_cancel = "date_cancel";
            ordg.user_create = "user_create";
            ordg.user_modi = "user_modi";
            ordg.user_cancel = "user_cancel";
            ordg.active = "active";
            ordg.sort1 = "sort1";
            ordg.status_or_us = "status_or_us";

            ordg.table = "or_b_operation_group";
            ordg.pkField = "opera_group_id";

            lDept = new List<OrOperationGroup>();
            //getlDept();
        }
        public String insert(OrOperationGroup p, String userId)
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
            p.opera_group_code = p.opera_group_code == null ? "" : p.opera_group_code;
            p.opera_group_name = p.opera_group_name == null ? "" : p.opera_group_name;
            p.status_or_opera_req = p.status_or_opera_req == null ? "0" : p.status_or_opera_req;
            p.remark = p.remark == null ? "" : p.remark;
            p.sort1 = p.sort1 == null ? "" : p.sort1;
            p.status_or_us = p.status_or_us == null ? "0" : p.status_or_us;

            sql = "Insert Into " + ordg.table + " Set " +
                "" + ordg.opera_group_code + " = '" + p.opera_group_code +"' "+
                "," + ordg.opera_group_name + " = '" + p.opera_group_name.Replace("'", "''") + "' " +
                "," + ordg.status_or_opera_req + " = '" + p.status_or_opera_req + "' " +
                "," + ordg.remark + " = '" + p.remark.Replace("'", "''") + "' " +
                "," + ordg.date_create + " = now() " +
                "," + ordg.date_modi + " = '" + p.date_modi + "' " +
                "," + ordg.date_cancel + " = '" + p.date_cancel + "' " +
                "," + ordg.user_create + " = '" + p.user_create + "' " +
                "," + ordg.user_modi + " = '" + p.user_modi + "' " +
                "," + ordg.user_cancel + " = '" + p.user_cancel + "' " +
                "," + ordg.active + " " + " = '" + p.active + "' " +
                "," + ordg.sort1 + " " + " = '" + p.sort1 + "' " +
                "," + ordg.status_or_us + " " + " = '" + p.status_or_us + "' " +
                " " ;
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
        public String update(OrOperationGroup p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.opera_group_code = p.opera_group_code == null ? "" : p.opera_group_code;
            p.opera_group_name = p.opera_group_name == null ? "" : p.opera_group_name;
            p.status_or_opera_req = p.status_or_opera_req == null ? "0" : p.status_or_opera_req;
            p.remark = p.remark == null ? "" : p.remark;
            p.sort1 = p.sort1 == null ? "" : p.sort1;
            p.status_or_us = p.status_or_us == null ? "0" : p.status_or_us;

            sql = "Update " + ordg.table + " Set " +
                "" + ordg.opera_group_code + " = '" + p.opera_group_code + "' " +
                "," + ordg.opera_group_name + " = '" + p.opera_group_name.Replace("'", "''") + "' " +
                "," + ordg.status_or_opera_req + " = '" + p.status_or_opera_req + "' " +
                "," + ordg.remark + " = '" + p.remark.Replace("'", "''") + "' " +
                "," + ordg.date_modi + " = now() " +                
                "," + ordg.user_modi + " = '" + p.user_modi + "' " +
                "," + ordg.active + " " + " = '" + p.active + "' " +
                "," + ordg.sort1 + " " + " = '" + p.sort1 + "' " +
                "," + ordg.status_or_us + " " + " = '" + p.status_or_us + "' " +
                "Where " + ordg.pkField + "='" + p.opera_group_id + "'"
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
        public String insertOrDiagGroup(OrOperationGroup p, String userId)
        {
            String re = "";

            if (p.opera_group_id.Equals(""))
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
            String sql = "Delete From  " + ordg.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public String VoidOrDiagGroup(String deptId, String userIdVoid)
        {
            DataTable dt = new DataTable();
            String sql = "Update " + ordg.table + " Set " +
                "" + ordg.active + "='3' " +
                "," + ordg.date_cancel + "=now() " +
                "," + ordg.user_cancel + "='" + userIdVoid + "' " +
                "Where " + ordg.pkField + "='" + deptId + "'";
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
                OrOperationGroup dept1 = new OrOperationGroup();
                dept1.opera_group_id = row[ordg.opera_group_id].ToString();
                dept1.opera_group_code = row[ordg.opera_group_code].ToString();
                dept1.opera_group_name = row[ordg.opera_group_name].ToString();
                
                dept1.status_or_opera_req = row[ordg.status_or_opera_req].ToString();
                //dept1.remark = row[ordg.remark].ToString();
                //dept1.date_create = row[ordg.date_create].ToString();
                //dept1.date_modi = row[ordg.date_modi].ToString();
                //dept1.date_cancel = row[ordg.date_cancel].ToString();
                //dept1.user_create = row[ordg.user_create].ToString();
                //dept1.user_modi = row[ordg.user_modi].ToString();
                //dept1.user_cancel = row[ordg.user_cancel].ToString();
                dept1.active = row[ordg.active].ToString();
                lDept.Add(dept1);
            }
        }
        public String getIdByCode(String code)
        {
            String id = "";
            foreach (OrOperationGroup dept1 in lDept)
            {
                if (code.Trim().Equals(dept1.opera_group_code.Trim()))
                {
                    id = dept1.opera_group_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (OrOperationGroup dept1 in lDept)
            {
                if (name.Trim().Equals(dept1.opera_group_name.Trim()))
                {
                    id = dept1.opera_group_id;
                    break;
                }
            }
            return id;
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select ordg.*  " +
                "From " + ordg.table + " ordg " +
                " " +
                "Where ordg." + ordg.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectAll1()
        {
            DataTable dt = new DataTable();
            String sql = "select ordg.opera_group_id, ordg.opera_group_code, ordg.opera_group_name, ordg.remark  " +
                "From " + ordg.table + " ordg " +
                " " +
                "Where ordg." + ordg.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select ordg.* " +
                "From " + ordg.table + " ordg " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where ordg." + ordg.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public OrOperationGroup selectByPk1(String copId)
        {
            OrOperationGroup cop1 = new OrOperationGroup();
            DataTable dt = new DataTable();
            String sql = "select ordg.* " +
                "From " + ordg.table + " ordg " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where ordg." + ordg.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setOrDiagGroup(dt);
            return cop1;
        }
        private OrOperationGroup setOrDiagGroup(DataTable dt)
        {
            OrOperationGroup dept1 = new OrOperationGroup();
            if (dt.Rows.Count > 0)
            {
                dept1.opera_group_id = dt.Rows[0][ordg.opera_group_id].ToString();
                dept1.opera_group_code = dt.Rows[0][ordg.opera_group_code].ToString();
                dept1.opera_group_name = dt.Rows[0][ordg.opera_group_name].ToString();
                dept1.status_or_opera_req = dt.Rows[0][ordg.status_or_opera_req].ToString();
                dept1.remark = dt.Rows[0][ordg.remark].ToString();
                dept1.date_create = dt.Rows[0][ordg.date_create].ToString();
                dept1.date_modi = dt.Rows[0][ordg.date_modi].ToString();
                dept1.date_cancel = dt.Rows[0][ordg.date_cancel].ToString();
                dept1.user_create = dt.Rows[0][ordg.user_create].ToString();
                dept1.user_modi = dt.Rows[0][ordg.user_modi].ToString();
                dept1.user_cancel = dt.Rows[0][ordg.user_cancel].ToString();
                dept1.active = dt.Rows[0][ordg.active].ToString();
                dept1.sort1 = dt.Rows[0][ordg.sort1].ToString();
                dept1.status_or_us = dt.Rows[0][ordg.status_or_us].ToString();
            }
            else
            {
                dept1.opera_group_id = "";
                dept1.opera_group_code = "";
                dept1.opera_group_name = "";

                dept1.status_or_opera_req = "";
                dept1.remark = "";
                dept1.date_create = "";
                dept1.date_modi = "";
                dept1.date_cancel = "";
                dept1.user_create = "";
                dept1.user_modi = "";
                dept1.user_cancel = "";
                dept1.active = "";
                dept1.sort1 = "";
                dept1.status_or_us = "";
            }

            return dept1;
        }
        public DataTable selectC1()
        {
            DataTable dt = new DataTable();
            String sql = "select ordg." + ordg.pkField + ",ordg." + ordg.opera_group_name + " " +
                "From " + ordg.table + " ordg " +
                " " +
                "Where ordg." + ordg.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public C1ComboBox setC1CboDiagGroup(C1ComboBox c)
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
                item.Text = row[ordg.opera_group_name].ToString();
                item.Value = row[ordg.opera_group_id].ToString();

                c.Items.Add(item);
            }
            return c;
        }
    }
}
