using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using clinic_ivf.object1;

namespace clinic_ivf.objdb
{
    public class PrefixDB
    {
        public Prefix pfx;
        ConnectDB conn;

        public PrefixDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            pfx = new Prefix();
            pfx.prefix_id = "prefix_id";
            pfx.prefix_code = "prefix_code";
            pfx.prefix_name_t = "prefix_name_t";
            pfx.prefix_name_e = "prefix_name_e";
            pfx.active = "active";
            pfx.remark = "remark";
            pfx.user_cancel = "user_cancel";
            pfx.user_create = "user_create";
            pfx.user_modi = "user_modi";
            pfx.date_cancel = "date_cancel";
            pfx.date_create = "date_create";
            pfx.date_modi = "date_modi";

            pfx.table = "b_prefix";
            pfx.pkField = "prefix_id";
        }
        public String insert(Prefix p)
        {
            String re = "", sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            sql = "Insert Into " + pfx.table + "(" + pfx.prefix_code + "," + pfx.prefix_name_t + "," + pfx.prefix_name_e + "," +
                pfx.active + "," + pfx.remark + ", " + pfx.date_create + " " +
                ") " +
                "Values ('" + p.prefix_code + "','" + p.prefix_name_t + "','" + p.prefix_name_e + "'," +
                "'" + p.active + "','" + p.remark + "', now() " +
                ")";
            re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
        }
        public String update(Prefix p)
        {
            String re = "", sql = "";

            sql = "Update " + pfx.table + " Set " +
                " " + pfx.prefix_code + "='" + p.prefix_code + "' " +
                "," + pfx.prefix_name_e + "='" + p.prefix_name_e.Replace("'", "''") + "' " +
                "," + pfx.prefix_name_t + "='" + p.prefix_name_t.Replace("'", "''") + "' " +
                "," + pfx.remark + "='" + p.remark.Replace("'", "''") + "' " +
                "," + pfx.date_modi + "=now() " +
                "Where " + pfx.prefix_id + "='" + p.prefix_id + "'"
                ;
            re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
        }
        public String insertPrefix(Prefix p)
        {
            String re = "";

            if (p.prefix_id.Equals(""))
            {
                re = insert(p);
            }
            else
            {
                re = update(p);
            }
            return re;
        }
        public String voidPrefix(String id)
        {
            String re = "", sql = "";

            sql = "Update " + pfx.table + " Set " +
                " " + pfx.active + "='3' " +
                "," + pfx.date_cancel + "=now() " +
                "Where " + pfx.prefix_id + "='" + id + "'"
                ;
            re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
        }

        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select pfx.*  " +
                "From " + pfx.table + " pfx " +
                " " +
                "Where pfx." + pfx.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectC1()
        {
            DataTable dt = new DataTable();
            String sql = "select pfx."+pfx.pkField+",pfx."+pfx.prefix_name_t +" "+
                "From " + pfx.table + " pfx " +
                " " +
                "Where pfx." + pfx.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public ComboBox setCboPrefix(ComboBox c)
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
            foreach(DataRow row in dt.Rows)
            {
                item = new ComboBoxItem();
                item.Text = row[pfx.prefix_name_t].ToString();
                item.Value = row[pfx.prefix_id].ToString();
                
                c.Items.Add(item);
            }
            return c;
        }
    }
}
