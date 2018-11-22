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
    public class LabProcedureDB
    {
        public LabProcedure proce;
        ConnectDB conn;

        public enum StatusLab { OPUProcedure, FETProcedure };
        public LabProcedureDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            proce = new LabProcedure();
            proce.proce_id = "proce_id";
            proce.proce_code = "proce_code";
            proce.proce_name_t = "proce_name_t";
            proce.status_lab = "status_lab";    //1=opu, 2=fet
            proce.proce_name_e = "proce_name_e";
            proce.remark = "remark";
            proce.date_create = "date_create";
            proce.date_modi = "date_modi";
            proce.date_cancel = "date_cancel";
            proce.user_create = "user_create";
            proce.user_modi = "user_modi";
            proce.user_cancel = "user_cancel";
            proce.active = "active";
            proce.sort1 = "sort1";

            proce.table = "lab_b_procedure";
            proce.pkField = "proce_id";

            //lDept = new List<LabProcedure>();
            //getlDept();
        }
        private void chkNull(LabProcedure p)
        {
            int chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.proce_code = p.proce_code == null ? "" : p.proce_code;
            p.proce_name_e = p.proce_name_e == null ? "" : p.proce_name_e;
            p.proce_name_t = p.proce_name_t == null ? "" : p.proce_name_t;
            p.remark = p.remark == null ? "" : p.remark;
            p.sort1 = p.sort1 == null ? "" : p.sort1;

            p.status_lab = p.status_lab == null ? "0" : p.status_lab;
        }
        public String insert(LabProcedure p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";

            chkNull(p);
            
            sql = "Insert Into " + proce.table + "(" + proce.proce_code + "," + proce.proce_name_t + "," + proce.status_lab + "," +
                proce.proce_name_e + "," + proce.remark + "," + proce.date_create + "," +
                proce.date_modi + "," + proce.date_cancel + "," + proce.user_create + "," +
                proce.user_modi + "," + proce.user_cancel + "," + proce.active + " " +
                ") " +
                "Values ('" + p.proce_code + "','" + p.proce_name_t.Replace("'", "''") + "','" + p.status_lab + "'," +
                "'" + p.proce_name_e + "','" + p.remark.Replace("'", "''") + "',now()," +
                "'" + p.date_modi + "','" + p.date_cancel + "','" + userId + "'," +
                "'" + p.user_modi + "','" + p.user_cancel + "','" + p.active + "' " +
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
        public String update(LabProcedure p, String userId)
        {
            String re = "";
            String sql = "";
            chkNull(p);

            sql = "Update " + proce.table + " Set " +
                " " + proce.proce_code + " = '" + p.proce_code + "'" +
                "," + proce.proce_name_t + " = '" + p.proce_name_t.Replace("'", "''") + "'" +
                "," + proce.status_lab + " = '" + p.status_lab + "'" +
                "," + proce.proce_name_e + " = '" + p.proce_name_e + "'" +
                "," + proce.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + proce.date_modi + " = now()" +
                "," + proce.user_modi + " = '" + userId + "'" +
                "Where " + proce.pkField + "='" + p.proce_id + "'"
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
        public String insertLabProcedure(LabProcedure p, String userId)
        {
            String re = "";

            if (p.proce_id.Equals(""))
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
            String sql = "Delete From  " + proce.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public String VoidLabProcedure(String deptId, String userIdVoid)
        {
            DataTable dt = new DataTable();
            String sql = "Update " + proce.table + " Set " +
                "" + proce.active + "='3' " +
                "," + proce.date_cancel + "=now() " +
                "," + proce.user_cancel + "='" + userIdVoid + "' " +
                "Where " + proce.pkField + "='" + deptId + "'";
            conn.ExecuteNonQuery(conn.conn, sql);
            return "1";
        }
        //public void getlDept()
        //{
        //    //lDept = new List<Position>();

        //    lDept.Clear();
        //    DataTable dt = new DataTable();
        //    dt = selectAll();
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        LabProcedure dept1 = new LabProcedure();
        //        dept1.proce_id = row[proce.proce_id].ToString();
        //        dept1.proce_code = row[proce.proce_code].ToString();
        //        dept1.proce_name_t = row[proce.proce_name_t].ToString();
        //        dept1.status_lab = row[proce.status_lab].ToString();
        //        dept1.proce_name_e = row[proce.proce_name_e].ToString();
        //        //dept1.remark = row[dept.remark].ToString();
        //        //dept1.date_create = row[dept.date_create].ToString();
        //        //dept1.date_modi = row[dept.date_modi].ToString();
        //        //dept1.date_cancel = row[dept.date_cancel].ToString();
        //        //dept1.user_create = row[dept.user_create].ToString();
        //        //dept1.user_modi = row[dept.user_modi].ToString();
        //        //dept1.user_cancel = row[dept.user_cancel].ToString();
        //        dept1.active = row[proce.active].ToString();
        //        lDept.Add(dept1);
        //    }
        //}
        //public String getIdByCode(String code)
        //{
        //    String id = "";
        //    foreach (LabProcedure dept1 in lDept)
        //    {
        //        if (code.Trim().Equals(dept1.proce_code.Trim()))
        //        {
        //            id = dept1.proce_id;
        //            break;
        //        }
        //    }
        //    return id;
        //}
        //public String getIdByName(String name)
        //{
        //    String id = "";
        //    foreach (LabProcedure dept1 in lDept)
        //    {
        //        if (name.Trim().Equals(dept1.proce_name_t.Trim()))
        //        {
        //            id = dept1.proce_id;
        //            break;
        //        }
        //    }
        //    return id;
        //}
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select dept.*  " +
                "From " + proce.table + " dept " +
                " " +
                "Where dept." + proce.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectAll1(StatusLab statuslab)
        {
            DataTable dt = new DataTable();
            String sql = "";
            if(statuslab == StatusLab.OPUProcedure)
            {
                sql = "select dept.proce_id, dept.proce_code, dept.proce_name_t, dept.remark  " +
                "From " + proce.table + " dept " +
                " " +
                "Where dept." + proce.active + " ='1' and dept."+ proce.status_lab+"='OPU'";
            }
            else if (statuslab == StatusLab.FETProcedure)
            {
                sql = "select dept.proce_id, dept.proce_code, dept.proce_name_t, dept.remark  " +
                "From " + proce.table + " dept " +
                " " +
                "Where dept." + proce.active + " ='1' and dept." + proce.status_lab + "='FET'";
            }
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select dept.* " +
                "From " + proce.table + " dept " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where dept." + proce.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public LabProcedure selectByPk1(String copId)
        {
            LabProcedure cop1 = new LabProcedure();
            DataTable dt = new DataTable();
            String sql = "select dept.* " +
                "From " + proce.table + " dept " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where dept." + proce.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setLabProcedure(dt);
            return cop1;
        }
        private LabProcedure setLabProcedure(DataTable dt)
        {
            LabProcedure proce1 = new LabProcedure();
            if (dt.Rows.Count > 0)
            {
                proce1.proce_id = dt.Rows[0][proce.proce_id].ToString();
                proce1.proce_code = dt.Rows[0][proce.proce_code].ToString();
                proce1.proce_name_t = dt.Rows[0][proce.proce_name_t].ToString();
                proce1.status_lab = dt.Rows[0][proce.status_lab].ToString();
                proce1.proce_name_e = dt.Rows[0][proce.proce_name_e].ToString();
                proce1.remark = dt.Rows[0][proce.remark].ToString();
                proce1.date_create = dt.Rows[0][proce.date_create].ToString();
                proce1.date_modi = dt.Rows[0][proce.date_modi].ToString();
                proce1.date_cancel = dt.Rows[0][proce.date_cancel].ToString();
                proce1.user_create = dt.Rows[0][proce.user_create].ToString();
                proce1.user_modi = dt.Rows[0][proce.user_modi].ToString();
                proce1.user_cancel = dt.Rows[0][proce.user_cancel].ToString();
                proce1.active = dt.Rows[0][proce.active].ToString();
            }

            return proce1;
        }
        public DataTable selectC1(StatusLab statuslab)
        {
            DataTable dt = new DataTable();
            String sql = "";
            if (statuslab == StatusLab.OPUProcedure)
            {
                sql = "select proce." + proce.pkField + ",proce." + proce.proce_name_t + " " +
                    "From " + proce.table + " proce " +
                    " " +
                    "Where proce." + proce.active + " ='1'  and proce." + proce.status_lab + "='OPU'";
            }
            else if (statuslab == StatusLab.FETProcedure)
            {
                sql = "select proce." + proce.pkField + ",proce." + proce.proce_name_t + " " +
                    "From " + proce.table + " proce " +
                    " " +
                    "Where proce." + proce.active + " ='1'  and proce." + proce.status_lab + "='FET'";
            }
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public C1ComboBox setCboLabProce(C1ComboBox c, StatusLab statuslab)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectC1(statuslab);
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
                item.Text = row[proce.proce_name_t].ToString();
                item.Value = row[proce.proce_id].ToString();

                c.Items.Add(item);
            }
            return c;
        }
    }
}
