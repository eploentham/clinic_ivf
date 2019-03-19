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
    public class FNationDB
    {
        FNation fpn;
        ConnectDB conn;
        public List<FNation> lFpn;
        public FNationDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lFpn = new List<FNation>();
            fpn = new FNation();
            fpn.f_patient_nation_id = "f_patient_nation_id";
            fpn.patient_nation_description = "patient_nation_description";
            fpn.active = "active";

            fpn.pkField = "f_patient_nation_id";
            fpn.table = "f_patient_nation";
        }
        public void getlFNation()
        {
            //lDept = new List<Position>();
            lFpn.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                FNation itm1 = new FNation();
                itm1.f_patient_nation_id = row[fpn.f_patient_nation_id].ToString();
                itm1.patient_nation_description = row[fpn.patient_nation_description].ToString();

                lFpn.Add(itm1);
            }
        }
        public String getList(String id)
        {
            String re = "";
            if (lFpn.Count <= 0)
            {
                getlFNation();
            }
            foreach (FNation sex in lFpn)
            {
                if (sex.f_patient_nation_id.Equals(id))
                {
                    re = sex.patient_nation_description;
                    break;
                }
            }
            return re;
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select fpn.*  " +
                "From " + fpn.table + " fpn " +
                " " +
                "Where fpn." + fpn.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select fpn.* " +
                "From " + fpn.table + " fpn " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where fpn." + fpn.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public FNation selectByPk1(String copId)
        {
            FNation cop1 = new FNation();
            DataTable dt = new DataTable();
            String sql = "select fpn.* " +
                "From " + fpn.table + " fpn " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where fpn." + fpn.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setNation(dt);
            return cop1;
        }
        private FNation setNation(DataTable dt)
        {
            FNation dept1 = new FNation();
            if (dt.Rows.Count > 0)
            {
                dept1.f_patient_nation_id = dt.Rows[0][fpn.f_patient_nation_id].ToString();
                dept1.patient_nation_description = dt.Rows[0][fpn.patient_nation_description].ToString();
            }
            else
            {
                dept1.f_patient_nation_id = "";
                dept1.patient_nation_description = "";
            }

            return dept1;
        }
        public DataTable selectC1()
        {
            DataTable dt = new DataTable();
            String sql = "select fpn." + fpn.pkField + ",fpn." + fpn.patient_nation_description + " " +
                "From " + fpn.table + " fpn " +
                " " +
                "Where fpn." + fpn.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public C1ComboBox setCboNation(C1ComboBox c)
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
                item.Text = row[fpn.patient_nation_description].ToString();
                item.Value = row[fpn.f_patient_nation_id].ToString();

                c.Items.Add(item);
            }
            return c;
        }
        public C1ComboBox setCboNation(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectC1();
            if (lFpn.Count <= 0) getlFNation();
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (FNation row in lFpn)
            {
                item = new ComboBoxItem();
                item.Value = row.f_patient_nation_id;
                item.Text = row.patient_nation_description;
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
