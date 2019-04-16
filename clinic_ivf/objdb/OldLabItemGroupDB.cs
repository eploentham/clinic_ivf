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
    public class OldLabItemGroupDB
    {
        OldLabItemGroup labG;
        ConnectDB conn;
        public List<OldLabItemGroup> llabG;
        public OldLabItemGroupDB(ConnectDB connorc_ma)
        {
            conn = connorc_ma;
            initConfig();
        }
        private void initConfig()
        {
            llabG = new List<OldLabItemGroup>();
            labG = new OldLabItemGroup();
            labG.LGID = "LGID";
            labG.LGName = "LGName";
            labG.active = "active";

            labG.pkField = "LGID";
            labG.table = "LabItemGroup";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select fbg.*  " +
                "From " + labG.table + " fbg " +
                " " +
                "Where fbg." + labG.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select fbg.* " +
                "From " + labG.table + " fbg " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where fbg." + labG.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public OldLabItemGroup selectByPk1(String copId)
        {
            OldLabItemGroup cop1 = new OldLabItemGroup();
            DataTable dt = new DataTable();
            String sql = "select fbg.* " +
                "From " + labG.table + " fbg " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where fbg." + labG.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setBloodGroup(dt);
            return cop1;
        }
        public void getlFBloodGroup()
        {
            //lDept = new List<Position>();
            llabG.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                OldLabItemGroup itm1 = new OldLabItemGroup();
                itm1.LGID = row[labG.LGID].ToString();
                itm1.LGName = row[labG.LGName].ToString();

                llabG.Add(itm1);
            }
        }
        private OldLabItemGroup setBloodGroup(DataTable dt)
        {
            OldLabItemGroup dept1 = new OldLabItemGroup();
            if (dt.Rows.Count > 0)
            {
                dept1.LGID = dt.Rows[0][labG.LGID].ToString();
                dept1.LGName = dt.Rows[0][labG.LGName].ToString();
            }

            return dept1;
        }
        public DataTable selectC1()
        {
            DataTable dt = new DataTable();
            String sql = "select fbg." + labG.pkField + ",fbg." + labG.LGName + " " +
                "From " + labG.table + " fbg " +
                " " +
                "Where fbg." + labG.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public C1ComboBox setCboBloodGroup(C1ComboBox c)
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
                item.Text = row[labG.LGName].ToString();
                item.Value = row[labG.LGID].ToString();

                c.Items.Add(item);
            }
            return c;
        }
        public C1ComboBox setCboBloodGroup(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectC1();
            if (llabG.Count <= 0) getlFBloodGroup();
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (OldLabItemGroup row in llabG)
            {
                item = new ComboBoxItem();
                item.Value = row.LGID;
                item.Text = row.LGName;
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
