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
    public class FEducationTypeDB
    {
        FEducationType fet;
        ConnectDB conn;
        public List<FEducationType> lFet;
        public FEducationTypeDB(ConnectDB c)
        {
            conn = c;
            
            initConfig();
        }
        private void initConfig()
        {
            lFet = new List<FEducationType>();
            fet = new FEducationType();
            fet.patient_education_type_description = "patient_education_type_description"; ;
            fet.f_patient_education_type_id = "f_patient_education_type_id";
            fet.active = "active";

            fet.pkField = "f_patient_education_type_id";
            fet.table = "f_patient_education_type";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select fet.*  " +
                "From " + fet.table + " fet " +
                " " +
                "Where fet." + fet.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select fet.* " +
                "From " + fet.table + " fet " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where fet." + fet.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public FEducationType selectByPk1(String copId)
        {
            FEducationType cop1 = new FEducationType();
            DataTable dt = new DataTable();
            String sql = "select fet.* " +
                "From " + fet.table + " fet " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where fet." + fet.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setEduca(dt);
            return cop1;
        }
        private FEducationType setEduca(DataTable dt)
        {
            FEducationType dept1 = new FEducationType();
            if (dt.Rows.Count > 0)
            {
                dept1.f_patient_education_type_id = dt.Rows[0][fet.f_patient_education_type_id].ToString();
                dept1.patient_education_type_description = dt.Rows[0][fet.patient_education_type_description].ToString();
            }

            return dept1;
        }
        public DataTable selectC1()
        {
            DataTable dt = new DataTable();
            String sql = "select fet." + fet.pkField + ",fet." + fet.patient_education_type_description + " " +
                "From " + fet.table + " fet " +
                " " +
                "Where fet." + fet.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public void getlFEducationType()
        {
            //lDept = new List<Position>();
            lFet.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                FEducationType itm1 = new FEducationType();
                itm1.f_patient_education_type_id = row[fet.f_patient_education_type_id].ToString();
                itm1.patient_education_type_description = row[fet.patient_education_type_description].ToString();

                lFet.Add(itm1);
            }
        }
        public C1ComboBox setCboEduca(C1ComboBox c)
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
                item.Text = row[fet.patient_education_type_description].ToString();
                item.Value = row[fet.f_patient_education_type_id].ToString();

                c.Items.Add(item);
            }
            return c;
        }
        public C1ComboBox setCboEduca(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectC1();
            if (lFet.Count <= 0) getlFEducationType();
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (FEducationType row in lFet)
            {
                item = new ComboBoxItem();
                item.Value = row.f_patient_education_type_id;
                item.Text = row.patient_education_type_description;
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
