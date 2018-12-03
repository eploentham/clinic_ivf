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
    public class FRaceDB
    {
        FRace frac;
        ConnectDB conn;
        public List<FRace> lFrac;
        public FRaceDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lFrac = new List<FRace>();
            frac = new FRace();
            frac.f_patient_race_id = "f_patient_race_id";
            frac.patient_race_description = "patient_race_description";
            frac.active = "active";

            frac.pkField = "f_patient_race_id";
            frac.table = "f_patient_race";
        }
        public void getlFRace()
        {
            //lDept = new List<Position>();
            lFrac.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                FRace itm1 = new FRace();
                itm1.f_patient_race_id = row[frac.f_patient_race_id].ToString();
                itm1.patient_race_description = row[frac.patient_race_description].ToString();

                lFrac.Add(itm1);
            }
        }
        public String getList(String id)
        {
            String re = "";
            if (lFrac.Count <= 0)
            {
                getlFRace();
            }
            foreach (FRace sex in lFrac)
            {
                if (sex.f_patient_race_id.Equals(id))
                {
                    re = sex.patient_race_description;
                    break;
                }
            }
            return re;
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select fpn.*  " +
                "From " + frac.table + " fpn " +
                " " +
                "Where fpn." + frac.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select fpn.* " +
                "From " + frac.table + " fpn " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where fpn." + frac.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public FPrefix selectByPk1(String copId)
        {
            FPrefix cop1 = new FPrefix();
            DataTable dt = new DataTable();
            String sql = "select fpn.* " +
                "From " + frac.table + " fpn " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where fpn." + frac.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setPrefix(dt);
            return cop1;
        }
        private FPrefix setPrefix(DataTable dt)
        {
            FPrefix dept1 = new FPrefix();
            if (dt.Rows.Count > 0)
            {
                dept1.f_patient_prefix_id = dt.Rows[0][frac.f_patient_race_id].ToString();
                dept1.patient_prefix_description = dt.Rows[0][frac.patient_race_description].ToString();
            }

            return dept1;
        }
        public DataTable selectC1()
        {
            DataTable dt = new DataTable();
            String sql = "select fpn." + frac.pkField + ",fpn." + frac.patient_race_description + " " +
                "From " + frac.table + " fpn " +
                " " +
                "Where fpn." + frac.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public C1ComboBox setCboRace(C1ComboBox c)
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
                item.Text = row[frac.patient_race_description].ToString();
                item.Value = row[frac.f_patient_race_id].ToString();

                c.Items.Add(item);
            }
            return c;
        }
        public C1ComboBox setCboRace(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectC1();
            if (lFrac.Count <= 0) getlFRace();
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (FRace row in lFrac)
            {
                item = new ComboBoxItem();
                item.Value = row.f_patient_race_id;
                item.Text = row.patient_race_description;
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
