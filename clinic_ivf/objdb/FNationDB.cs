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
        public List<FNation> lfpn;
        public FNationDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lfpn = new List<FNation>();
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
            lfpn.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                FNation itm1 = new FNation();
                itm1.f_patient_nation_id = row[fpn.f_patient_nation_id].ToString();
                itm1.patient_nation_description = row[fpn.patient_nation_description].ToString();

                lfpn.Add(itm1);
            }
        }
        public String getList(String id)
        {
            String re = "";
            foreach (FNation sex in lfpn)
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
        public FPrefix selectByPk1(String copId)
        {
            FPrefix cop1 = new FPrefix();
            DataTable dt = new DataTable();
            String sql = "select fpn.* " +
                "From " + fpn.table + " fpn " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where fpn." + fpn.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setPrefix(dt);
            return cop1;
        }
        private FPrefix setPrefix(DataTable dt)
        {
            FPrefix dept1 = new FPrefix();
            if (dt.Rows.Count > 0)
            {
                dept1.f_patient_prefix_id = dt.Rows[0][fpn.f_patient_nation_id].ToString();
                dept1.patient_prefix_description = dt.Rows[0][fpn.patient_nation_description].ToString();
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
    }
}
