using C1.Win.C1Input;
using clinic_ivf.objdb;
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
    public class FPrefixDB
    {
        FPrefix fp;
        ConnectDB conn;
        public FPrefixDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            fp = new FPrefix();
            fp.active = "active";
            fp.f_patient_prefix_id = "f_patient_prefix_id";
            fp.f_sex_id = "f_sex_id";            
            fp.patient_prefix_description = "patient_prefix_description";
            fp.active = "active";

            fp.pkField = "f_patient_prefix_id";
            fp.table = "f_patient_prefix";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select dept.*  " +
                "From " + fp.table + " dept " +
                " " +
                "Where dept." + fp.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select dept.* " +
                "From " + fp.table + " dept " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where dept." + fp.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public FPrefix selectByPk1(String copId)
        {
            FPrefix cop1 = new FPrefix();
            DataTable dt = new DataTable();
            String sql = "select dept.* " +
                "From " + fp.table + " dept " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where dept." + fp.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setPrefix(dt);
            return cop1;
        }
        private FPrefix setPrefix(DataTable dt)
        {
            FPrefix dept1 = new FPrefix();
            if (dt.Rows.Count > 0)
            {
                dept1.f_patient_prefix_id = dt.Rows[0][fp.f_patient_prefix_id].ToString();
                dept1.patient_prefix_description = dt.Rows[0][fp.patient_prefix_description].ToString();                
            }

            return dept1;
        }
        public DataTable selectC1()
        {
            DataTable dt = new DataTable();
            String sql = "select dept." + fp.pkField + ",dept." + fp.patient_prefix_description + " " +
                "From " + fp.table + " dept " +
                " " +
                "Where dept." + fp.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public C1ComboBox setCboPrefix(C1ComboBox c)
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
                item.Text = row[fp.patient_prefix_description].ToString();
                item.Value = row[fp.f_patient_prefix_id].ToString();

                c.Items.Add(item);
            }
            return c;
        }
    }
}
