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
    public class FSexDB
    {
        FSex sex;
        ConnectDB conn;
        public List<FSex> lSex;
        public FSexDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lSex = new List<FSex>();
            sex = new FSex();
            sex.f_sex_id = "f_sex_id";
            sex.sex_description = "sex_description";
            sex.active = "active";

            sex.pkField = "f_sex_id";
            sex.table = "f_sex";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select sex.*  " +
                "From " + sex.table + " sex " +
                " " +
                "Where sex." + sex.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select sex.* " +
                "From " + sex.table + " sex " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where sex." + sex.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public FSex selectByPk1(String copId)
        {
            FSex cop1 = new FSex();
            DataTable dt = new DataTable();
            String sql = "select sex.* " +
                "From " + sex.table + " sex " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where sex." + sex.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setSex(dt);
            return cop1;
        }
        private FSex setSex(DataTable dt)
        {
            FSex dept1 = new FSex();
            if (dt.Rows.Count > 0)
            {
                dept1.f_sex_id = dt.Rows[0][sex.f_sex_id].ToString();
                dept1.sex_description = dt.Rows[0][sex.sex_description].ToString();
            }

            return dept1;
        }
        public DataTable selectC1()
        {
            DataTable dt = new DataTable();
            String sql = "select sex." + sex.pkField + ",sex." + sex.sex_description + " " +
                "From " + sex.table + " sex " +
                " " +
                "Where sex." + sex.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public void getlSex()
        {
            //lDept = new List<Position>();
            lSex.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                FSex itm1 = new FSex();
                itm1.f_sex_id = row[sex.f_sex_id].ToString();
                itm1.sex_description = row[sex.sex_description].ToString();

                lSex.Add(itm1);
            }
        }
        public String getList(String id)
        {
            String re = "";
            if (lSex.Count <= 0) getlSex();
            foreach (FSex sex in lSex)
            {
                if (sex.f_sex_id.Equals(id))
                {
                    re = sex.sex_description;
                    break;
                }
            }
            return re;
        }
        public C1ComboBox setCboSex(C1ComboBox c)
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
                item.Text = row[sex.sex_description].ToString();
                item.Value = row[sex.f_sex_id].ToString();

                c.Items.Add(item);
            }
            return c;
        }
        public C1ComboBox setCboSex(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectC1();
            if (lSex.Count <= 0) getlSex();
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (FSex row in lSex)
            {
                item = new ComboBoxItem();
                item.Value = row.f_sex_id;
                item.Text = row.sex_description;
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
