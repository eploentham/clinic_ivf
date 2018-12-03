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
    public class FBloodGroupDB
    {
        FBloodGroup fbg;
        ConnectDB conn;
        public List<FBloodGroup> lFbg;
        public FBloodGroupDB(ConnectDB connorc_ma)
        {
            conn = connorc_ma;
            initConfig();
        }
        private void initConfig()
        {
            lFbg = new List<FBloodGroup>();
            fbg = new FBloodGroup();
            fbg.f_patient_blood_group_id = "f_patient_blood_group_id";
            fbg.patient_blood_group_description = "patient_blood_group_description";
            fbg.active = "active";

            fbg.pkField = "f_patient_blood_group_id";
            fbg.table = "f_patient_blood_group";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select fbg.*  " +
                "From " + fbg.table + " fbg " +
                " " +
                "Where fbg." + fbg.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select fbg.* " +
                "From " + fbg.table + " fbg " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where fbg." + fbg.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public FBloodGroup selectByPk1(String copId)
        {
            FBloodGroup cop1 = new FBloodGroup();
            DataTable dt = new DataTable();
            String sql = "select fbg.* " +
                "From " + fbg.table + " fbg " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where fbg." + fbg.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setBloodGroup(dt);
            return cop1;
        }
        public void getlFBloodGroup()
        {
            //lDept = new List<Position>();
            lFbg.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                FBloodGroup itm1 = new FBloodGroup();
                itm1.f_patient_blood_group_id = row[fbg.f_patient_blood_group_id].ToString();
                itm1.patient_blood_group_description = row[fbg.patient_blood_group_description].ToString();

                lFbg.Add(itm1);
            }
        }
        private FBloodGroup setBloodGroup(DataTable dt)
        {
            FBloodGroup dept1 = new FBloodGroup();
            if (dt.Rows.Count > 0)
            {
                dept1.f_patient_blood_group_id = dt.Rows[0][fbg.f_patient_blood_group_id].ToString();
                dept1.patient_blood_group_description = dt.Rows[0][fbg.patient_blood_group_description].ToString();
            }

            return dept1;
        }
        public DataTable selectC1()
        {
            DataTable dt = new DataTable();
            String sql = "select fbg." + fbg.pkField + ",fbg." + fbg.patient_blood_group_description + " " +
                "From " + fbg.table + " fbg " +
                " " +
                "Where fbg." + fbg.active + " ='1' ";
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
                item.Text = row[fbg.patient_blood_group_description].ToString();
                item.Value = row[fbg.f_patient_blood_group_id].ToString();

                c.Items.Add(item);
            }
            return c;
        }
        public C1ComboBox setCboBloodGroup(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectC1();
            if (lFbg.Count <= 0) getlFBloodGroup();
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (FBloodGroup row in lFbg)
            {
                item = new ComboBoxItem();
                item.Value = row.f_patient_blood_group_id;
                item.Text = row.patient_blood_group_description;
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
