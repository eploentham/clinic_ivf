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
    public class AgentOldDB
    {
        public AgentOld agnO;
        ConnectDB conn;

        public List<AgentOld> lAgnO;

        public AgentOldDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lAgnO = new List<AgentOld>();
            agnO = new AgentOld();
            agnO.agentid = "AgentID";
            agnO.agentname = "AgentName";


            agnO.pkField = "AgentID";
            agnO.table = "Agent";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select agnO.*  " +
                "From " + agnO.table + " agnO " +
                " ";
                //"Where agnO." + agnO.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select agnO.* " +
                "From " + agnO.table + " agnO ";
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                //"Where sex." + agnO.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public void getlAgent()
        {
            //lDept = new List<Position>();
            lAgnO.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                AgentOld itm1 = new AgentOld();
                itm1.agentid = row[agnO.agentid].ToString();
                itm1.agentname = row[agnO.agentname].ToString();

                lAgnO.Add(itm1);
            }
        }
        public String getList(String id)
        {
            String re = "";
            foreach (AgentOld sex in lAgnO)
            {
                if (sex.agentid.Equals(id))
                {
                    re = sex.agentname;
                    break;
                }
            }
            return re;
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
                item.Text = row[agnO.agentname].ToString();
                item.Value = row[agnO.agentid].ToString();

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
                item.Text = row[agnO.agentname].ToString();
                item.Value = row[agnO.agentid].ToString();

                c.Items.Add(item);
            }
            return c;
        }
        public C1ComboBox setCboAgent(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectC1();
            if (lAgnO.Count <= 0) getlAgent();
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (AgentOld row in lAgnO)
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
    }
}
