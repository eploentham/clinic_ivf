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
    public class FReligionDB
    {
        FReligion frg;
        ConnectDB conn;
        public List<FReligion> lFrl;
        public FReligionDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lFrl = new List<FReligion>();
            frg = new FReligion();
            frg.f_patient_religion_id = "f_patient_religion_id";
            frg.patient_religion_description = "patient_religion_description";
            frg.active = "active";

            frg.pkField = "f_patient_religion_id";
            frg.table = "f_patient_religion";
        }
        public void getlFRelation()
        {
            //lDept = new List<Position>();
            lFrl.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                FReligion itm1 = new FReligion();
                itm1.f_patient_religion_id = row[frg.f_patient_religion_id].ToString();
                itm1.patient_religion_description = row[frg.patient_religion_description].ToString();

                lFrl.Add(itm1);
            }
        }
        public String getList(String id)
        {
            String re = "";
            if (lFrl.Count <= 0)
            {
                getlFRelation();
            }
            foreach (FReligion sex in lFrl)
            {
                if (sex.f_patient_religion_id.Equals(id))
                {
                    re = sex.patient_religion_description;
                    break;
                }
            }
            return re;
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select frg.*  " +
                "From " + frg.table + " frg " +
                " " +
                "Where frg." + frg.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select frg.* " +
                "From " + frg.table + " frg " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where frg." + frg.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public FPrefix selectByPk1(String copId)
        {
            FPrefix cop1 = new FPrefix();
            DataTable dt = new DataTable();
            String sql = "select frg.* " +
                "From " + frg.table + " frg " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where frg." + frg.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setPrefix(dt);
            return cop1;
        }
        private FPrefix setPrefix(DataTable dt)
        {
            FPrefix dept1 = new FPrefix();
            if (dt.Rows.Count > 0)
            {
                dept1.f_patient_prefix_id = dt.Rows[0][frg.f_patient_religion_id].ToString();
                dept1.patient_prefix_description = dt.Rows[0][frg.patient_religion_description].ToString();
            }

            return dept1;
        }
        public DataTable selectC1()
        {
            DataTable dt = new DataTable();
            String sql = "select frg." + frg.pkField + ",frg." + frg.patient_religion_description + " " +
                "From " + frg.table + " frg " +
                " " +
                "Where frg." + frg.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public C1ComboBox setCboReligion(C1ComboBox c)
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
                item.Text = row[frg.patient_religion_description].ToString();
                item.Value = row[frg.f_patient_religion_id].ToString();

                c.Items.Add(item);
            }
            return c;
        }
    }
}
