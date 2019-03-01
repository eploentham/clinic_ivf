using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using C1.Win.C1Input;
using clinic_ivf.object1;

namespace clinic_ivf.objdb
{
    public class PositionDB
    {
        public Position posi;
        ConnectDB conn;

        public List<Position> lDept;

        public PositionDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            posi = new Position();
            posi.posi_id = "posi_id";
            posi.posi_code = "posi_code";
            posi.posi_name_t = "posi_name_t";
            posi.posi_name_e = "posi_name_e";
            //posi.dept_parent_id = "dept_parent_id";
            posi.remark = "remark";
            posi.date_create = "date_create";
            posi.date_modi = "date_modi";
            posi.date_cancel = "date_cancel";
            posi.user_create = "user_create";
            posi.user_modi = "user_modi";
            posi.user_cancel = "user_cancel";
            posi.active = "active";
            posi.sort1 = "sort1";
            posi.status_doctor = "status_doctor";
            posi.status_embryologist = "status_embryologist";

            posi.table = "b_position";
            posi.pkField = "posi_id";

            lDept = new List<Position>();
            //getlPosi();
        }
        public String insert(Position p, String userId)
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
            p.posi_name_e = p.posi_name_e == null ? "" : p.posi_name_e;
            p.posi_name_t = p.posi_name_t == null ? "" : p.posi_name_t;
            p.sort1 = p.sort1 == null ? "" : p.sort1;
            p.remark = p.remark == null ? "" : p.remark;
            p.status_embryologist = p.status_embryologist == null ? "" : p.status_embryologist;

            //p.posi_name_e = int.TryParse(p.comp_id, out chk) ? chk.ToString() : "0";
            p.posi_id = int.TryParse(p.posi_id, out chk) ? chk.ToString() : "0";
            p.status_doctor = int.TryParse(p.status_doctor, out chk) ? chk.ToString() : "0";
            //p.status_embryologist = int.TryParse(p.status_embryologist, out chk) ? chk.ToString() : "0";

            sql = "Insert Into " + posi.table + "(" + posi.posi_code + "," + posi.posi_name_t + "," + posi.posi_name_e + "," +
                posi.sort1 + "," + posi.remark + "," + posi.date_create + "," +
                posi.date_modi + "," + posi.date_cancel + "," + posi.user_create + "," +
                posi.user_modi + "," + posi.user_cancel + "," + posi.active + ", " +
                posi.status_doctor + "," + posi.status_embryologist + " " +
                ") " +
                "Values ('" + p.posi_code + "','" + p.posi_name_t.Replace("'", "''") + "','" + p.posi_name_e + "'," +
                "'" + p.sort1 + "','" + p.remark.Replace("'", "''") + "',now()," +
                "'" + p.date_modi + "','" + p.date_cancel + "','" + userId + "'," +
                "'" + p.user_modi + "','" + p.user_cancel + "','" + p.active + "', " +
                "'" + p.status_doctor + "','" + p.status_embryologist + "' " +
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
        public String update(Position p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.posi_name_e = p.posi_name_e == null ? "" : p.posi_name_e;
            p.posi_name_t = p.posi_name_t == null ? "" : p.posi_name_t;
            p.sort1 = p.sort1 == null ? "" : p.sort1;
            p.remark = p.remark == null ? "" : p.remark;
            p.status_embryologist = p.status_embryologist == null ? "0" : p.status_embryologist;
            //p.comp_id = int.TryParse(p.comp_id, out chk) ? chk.ToString() : "0";
            p.posi_id = int.TryParse(p.posi_id, out chk) ? chk.ToString() : "0";
            p.status_doctor = int.TryParse(p.status_doctor, out chk) ? chk.ToString() : "0";

            sql = "Update " + posi.table + " Set " +
                " " + posi.posi_code + " = '" + p.posi_code + "'" +
                "," + posi.posi_name_t + " = '" + p.posi_name_t.Replace("'", "''") + "'" +
                "," + posi.posi_name_e + " = '" + p.posi_name_e + "'" +
                //"," + posi.dept_parent_id + " = '" + p.dept_parent_id + "'" +
                "," + posi.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + posi.date_modi + " = now()" +
                "," + posi.user_modi + " = '" + userId + "'" +
                "," + posi.status_doctor + " = '" + p.status_doctor + "'" +
                "," + posi.status_embryologist + " = '" + p.status_embryologist + "'" +
                "Where " + posi.pkField + "='" + p.posi_id + "'"
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
        public String insertPosition(Position p, String userId)
        {
            String re = "";

            if (p.posi_id.Equals(""))
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
            String sql = "Delete From  " + posi.table;
            conn.ExecuteNonQuery(conn.conn, sql);

            return "";
        }
        public String VoidPosition(String posiId, String userIdVoid)
        {
            DataTable dt = new DataTable();
            String sql = "Update  " + posi.table+" Set " +
                ""+posi.active +"='3' " +
                ","+posi.date_cancel+"=now() " +
                ","+ posi.user_cancel+"='"+ userIdVoid+"' " +
                "Where "+posi.pkField+"='"+posiId+"'";
            conn.ExecuteNonQuery(conn.conn, sql);

            return "1";
        }
        public void getlPosi()
        {
            //lDept = new List<Position>();

            lDept.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                Position dept1 = new Position();
                dept1.posi_id = row[posi.posi_id].ToString();
                dept1.posi_code = row[posi.posi_code].ToString();
                dept1.posi_name_t = row[posi.posi_name_t].ToString();
                //dept1.comp_id = row[posi.comp_id].ToString();
                //dept1.dept_parent_id = row[posi.dept_parent_id].ToString();
                //dept1.remark = row[posi.remark].ToString();
                //dept1.date_create = row[posi.date_create].ToString();
                //dept1.date_modi = row[posi.date_modi].ToString();
                //dept1.date_cancel = row[posi.date_cancel].ToString();
                //dept1.user_create = row[posi.user_create].ToString();
                //dept1.user_modi = row[posi.user_modi].ToString();
                //dept1.user_cancel = row[posi.user_cancel].ToString();
                dept1.active = row[posi.active].ToString();
                lDept.Add(dept1);
            }
        }
        public String getIdByCode(String code)
        {
            String id = "";
            foreach (Position dept1 in lDept)
            {
                if (code.Trim().Equals(dept1.posi_code.Trim()))
                {
                    id = dept1.posi_id;
                    break;
                }
            }
            return id;
        }
        public String getIdByName(String name)
        {
            String id = "";
            foreach (Position dept1 in lDept)
            {
                if (name.Trim().Equals(dept1.posi_name_t.Trim()))
                {
                    id = dept1.posi_id;
                    break;
                }
            }
            return id;
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select posi.*  " +
                "From " + posi.table + " posi " +
                " " +
                "Where posi." + posi.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectAll1()
        {
            DataTable dt = new DataTable();
            String sql = "select posi.posi_id, posi.posi_code, posi.posi_name_t, posi.remark  " +
                "From " + posi.table + " posi " +
                " " +
                "Where posi." + posi.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select posi.* " +
                "From " + posi.table + " posi " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where posi." + posi.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public Position selectByPk1(String copId)
        {
            Position cop1 = new Position();
            DataTable dt = new DataTable();
            String sql = "select posi.* " +
                "From " + posi.table + " posi " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where posi." + posi.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setPosition(dt);
            return cop1;
        }
        private Position setPosition(DataTable dt)
        {
            Position dept1 = new Position();
            if (dt.Rows.Count > 0)
            {
                dept1.posi_id = dt.Rows[0][posi.posi_id].ToString();
                dept1.posi_code = dt.Rows[0][posi.posi_code].ToString();
                dept1.posi_name_t = dt.Rows[0][posi.posi_name_t].ToString();
                dept1.posi_name_e = dt.Rows[0][posi.posi_name_e] != null ? dt.Rows[0][posi.posi_name_e].ToString() : "";
                dept1.status_doctor = dt.Rows[0][posi.status_doctor] != null ? dt.Rows[0][posi.status_doctor].ToString() : "";
                dept1.remark = dt.Rows[0][posi.remark] != null ? dt.Rows[0][posi.remark].ToString() : "";
                dept1.date_create = dt.Rows[0][posi.date_create] != null ? dt.Rows[0][posi.date_create].ToString() : "";
                dept1.date_modi = dt.Rows[0][posi.date_modi] != null ? dt.Rows[0][posi.date_modi].ToString() : "";
                dept1.date_cancel = dt.Rows[0][posi.date_cancel] != null ? dt.Rows[0][posi.date_cancel].ToString() : "";
                dept1.user_create = dt.Rows[0][posi.user_create] != null ? dt.Rows[0][posi.user_create].ToString() : "";
                dept1.user_modi = dt.Rows[0][posi.user_modi] != null ? dt.Rows[0][posi.user_modi].ToString() : "";
                dept1.user_cancel = dt.Rows[0][posi.user_cancel] != null ? dt.Rows[0][posi.user_cancel].ToString() : "";
                dept1.active = dt.Rows[0][posi.active] != null ? dt.Rows[0][posi.active].ToString() : "";
                dept1.sort1 = dt.Rows[0][posi.sort1] != null ? dt.Rows[0][posi.sort1].ToString() : "";
                dept1.status_embryologist = dt.Rows[0][posi.status_embryologist] != null ? dt.Rows[0][posi.status_embryologist].ToString() : "";
            }
            else
            {
                dept1.posi_code = "";
                dept1.posi_name_t = "";
                dept1.posi_name_e = "";
                //posi.dept_parent_id = "dept_parent_id";
                dept1.remark = "";
                dept1.date_create = "";
                dept1.date_modi = "";
                dept1.date_cancel = "";
                dept1.user_create = "";
                dept1.user_modi = "";
                dept1.user_cancel = "";
                dept1.active = "";
                dept1.sort1 = "";
                dept1.status_doctor = "";
                dept1.status_embryologist = "";
            }

            return dept1;
        }
        public DataTable selectC1()
        {
            DataTable dt = new DataTable();
            String sql = "select posi." + posi.pkField + ",posi." + posi.posi_name_t + " " +
                "From " + posi.table + " posi " +
                " " +
                "Where posi." + posi.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public C1ComboBox setC1CboPosi(C1ComboBox c)
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
                item.Text = row[posi.posi_name_t].ToString();
                item.Value = row[posi.posi_id].ToString();

                c.Items.Add(item);
            }
            return c;
        }
    }
}
