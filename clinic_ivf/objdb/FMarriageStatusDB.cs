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
    public class FMarriageStatusDB
    {
        FMarriageStatus fms;
        ConnectDB conn;
        public List<FMarriageStatus> lFms;
        public FMarriageStatusDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lFms = new List<FMarriageStatus>();
            fms = new FMarriageStatus();
            fms.f_patient_marriage_status_id = "f_patient_marriage_status_id";
            fms.patient_marriage_status_description = "patient_marriage_status_description";
            fms.active = "active";

            fms.pkField = "f_patient_marriage_status_id";
            fms.table = "f_patient_marriage_status";
        }
        public void getlFMarriage()
        {
            //lDept = new List<Position>();
            lFms.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                FMarriageStatus itm1 = new FMarriageStatus();
                itm1.f_patient_marriage_status_id = row[fms.f_patient_marriage_status_id].ToString();
                itm1.patient_marriage_status_description = row[fms.patient_marriage_status_description].ToString();

                lFms.Add(itm1);
            }
        }
        public String getList(String id)
        {
            String re = "";
            if (lFms.Count <= 0)
            {
                getlFMarriage();
            }
            foreach (FMarriageStatus sex in lFms)
            {
                if (sex.f_patient_marriage_status_id.Equals(id))
                {
                    re = sex.patient_marriage_status_description;
                    break;
                }
            }
            return re;
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select fms.*  " +
                "From " + fms.table + " fms " +
                " " +
                "Where fms." + fms.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select fms.* " +
                "From " + fms.table + " fms " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where fms." + fms.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public FPrefix selectByPk1(String copId)
        {
            FPrefix cop1 = new FPrefix();
            DataTable dt = new DataTable();
            String sql = "select fms.* " +
                "From " + fms.table + " fms " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where fms." + fms.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setMarriageStatus(dt);
            return cop1;
        }
        private FPrefix setMarriageStatus(DataTable dt)
        {
            FPrefix dept1 = new FPrefix();
            if (dt.Rows.Count > 0)
            {
                dept1.f_patient_prefix_id = dt.Rows[0][fms.f_patient_marriage_status_id].ToString();
                dept1.patient_prefix_description = dt.Rows[0][fms.patient_marriage_status_description].ToString();
            }

            return dept1;
        }
        public DataTable selectC1()
        {
            DataTable dt = new DataTable();
            String sql = "select fms." + fms.pkField + ",fms." + fms.patient_marriage_status_description + " " +
                "From " + fms.table + " fms " +
                " " +
                "Where fms." + fms.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public C1ComboBox setCboMarriage(C1ComboBox c)
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
                item.Text = row[fms.patient_marriage_status_description].ToString();
                item.Value = row[fms.f_patient_marriage_status_id].ToString();

                c.Items.Add(item);
            }
            return c;
        }
        public C1ComboBox setCboMarriage(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectC1();
            if (lFms.Count <= 0) getlFMarriage();
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (FMarriageStatus row in lFms)
            {
                item = new ComboBoxItem();
                item.Value = row.f_patient_marriage_status_id;
                item.Text = row.patient_marriage_status_description;
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
