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
    public class OldAgentDB
    {
        public OldAgent oAgn;
        ConnectDB conn;

        public List<OldAgent> loAgn;

        public OldAgentDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            loAgn = new List<OldAgent>();
            oAgn = new OldAgent();
            oAgn.agentid = "AgentID";
            oAgn.agentname = "AgentName";
            oAgn.date_cancel = "date_cancel";
            oAgn.date_create = "date_create";
            oAgn.date_modi = "date_modi";
            oAgn.user_cancel = "user_cancel";
            oAgn.user_create = "user_create";
            oAgn.user_modi = "user_modi";
            oAgn.active = "active";

            oAgn.pkField = "AgentID";
            oAgn.table = "Agent";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select agnO."+oAgn.agentid+ ",agnO." + oAgn.agentname +
                " From " + oAgn.table + " agnO " +
                " ";
                //"Where agnO." + agnO.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select agnO.* " +
                "From " + oAgn.table + " agnO ";
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                //"Where sex." + agnO.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public OldAgent selectByPk1(String copId)
        {
            OldAgent cop1 = new OldAgent();
            DataTable dt = new DataTable();
            String sql = "select oAgn.* " +
                "From " + oAgn.table + " oAgn " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where oAgn." + oAgn.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setAgent(dt);
            return cop1;
        }
        public void getlAgent()
        {
            //lDept = new List<Position>();
            loAgn.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                OldAgent itm1 = new OldAgent();
                itm1.agentid = row[oAgn.agentid].ToString();
                itm1.agentname = row[oAgn.agentname].ToString();

                loAgn.Add(itm1);
            }
        }
        public String getList(String id)
        {
            String re = "";
            re = id;
            if (loAgn.Count <= 0)
            {
                getlAgent();
            }
            foreach (OldAgent sex in loAgn)
            {
                if (sex.agentid.Equals(id))
                {
                    re = sex.agentname;
                    break;
                }
            }
            return re;
        }
        public String insert(OldAgent p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;
            
            p.agentname = p.agentname == null ? "" : p.agentname;

            sql = "Insert Into " + oAgn.table + "(" + oAgn.agentname + " " +
                ") " +
                "Values ('" + p.agentname.Replace("'", "''") +"'" +
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
        public String update(OldAgent p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            
            p.agentname = p.agentname == null ? "" : p.agentname;
            

            sql = "Update " + oAgn.table + " Set " +                
                " " + oAgn.agentname + " = '" + p.agentname.Replace("'", "''") + "'" +                
                "Where " + oAgn.pkField + "='" + p.agentid + "'"
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
        public String insertAgent(OldAgent p, String userId)
        {
            String re = "";

            if (p.agentid.Equals(""))
            {
                re = insert(p, userId);
            }
            else
            {
                re = update(p, userId);
            }

            return re;
        }
        public String VoidAgent(String stfId, String userIdVoid)
        {
            DataTable dt = new DataTable();
            String sql = "Update " + oAgn.table + " Set " +
                "" + oAgn.active + "='3'" +
                "," + oAgn.date_cancel + "=now() " +
                "," + oAgn.user_cancel + "='" + userIdVoid + "' " +
                "Where " + oAgn.pkField + "='" + stfId + "'";
            conn.ExecuteNonQuery(conn.conn, sql);

            return "1";
        }
        public C1ComboBox setCboAgent(C1ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectAll();
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
                item.Text = row[oAgn.agentname].ToString();
                item.Value = row[oAgn.agentid].ToString();

                c.Items.Add(item);
            }
            return c;
        }
        public ComboBox setCboAgent(ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectAll();
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
                item.Text = row[oAgn.agentname].ToString();
                item.Value = row[oAgn.agentid].ToString();

                c.Items.Add(item);
            }
            return c;
        }
        public C1ComboBox setCboAgent(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectC1();
            if (loAgn.Count <= 0) getlAgent();
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (OldAgent row in loAgn)
            {
                item = new ComboBoxItem();
                item.Value = row.agentid;
                item.Text = row.agentname;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    //c.SelectedItem = item.Value;
                    c.SelectedText = item.Text;
                    c.SelectedIndex = i + 1;
                }
                i++;
            }
            return c;
        }
        private OldAgent setAgent(DataTable dt)
        {
            OldAgent dept1 = new OldAgent();
            if (dt.Rows.Count > 0)
            {
                dept1.agentid = dt.Rows[0][oAgn.agentid].ToString();
                dept1.agentname = dt.Rows[0][oAgn.agentname].ToString();
            }
            else
            {
                dept1.agentid = "";
                dept1.agentname = "";
            }

            return dept1;
        }
    }
}
