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
        public FEducationTypeDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
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
        public FPrefix selectByPk1(String copId)
        {
            FPrefix cop1 = new FPrefix();
            DataTable dt = new DataTable();
            String sql = "select fet.* " +
                "From " + fet.table + " fet " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where fet." + fet.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setPrefix(dt);
            return cop1;
        }
        private FPrefix setPrefix(DataTable dt)
        {
            FPrefix dept1 = new FPrefix();
            if (dt.Rows.Count > 0)
            {
                dept1.f_patient_prefix_id = dt.Rows[0][fet.f_patient_education_type_id].ToString();
                dept1.patient_prefix_description = dt.Rows[0][fet.patient_education_type_description].ToString();
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
    }
}
