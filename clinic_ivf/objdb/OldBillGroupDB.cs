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
    public class OldBillGroupDB
    {
        OldBillGroup obilg;
        ConnectDB conn;
        public List<OldBillGroup> loBilg;

        public OldBillGroupDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            obilg = new OldBillGroup();
            loBilg = new List<OldBillGroup>();
            obilg.ID = "ID";
            obilg.Name = "Name";
            obilg.status_discount = "status_discount";
            obilg.active = "active";

            obilg.table = "BillGroup";
            obilg.pkField = "ID";
        }
        public DataTable selectByCreditCardName()
        {
            DataTable dt = new DataTable();
            String sql = "select obilg." + obilg.ID + ",obilg." + obilg.Name + " " +
                "From " + obilg.table + " obilg " +
                "Where active = '1' " +
                "Order By obilg." + obilg.Name;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select obilg.*  " +
                "From " + obilg.table + " obilg " +
                " " +
                "Where obilg." + obilg.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public String getList(String id)
        {
            String re = "";
            if (loBilg.Count <= 0)
            {
                getlCreditCardAccount();
            }
            foreach (OldBillGroup sex in loBilg)
            {
                if (sex.ID.Equals(id))
                {
                    re = sex.Name;
                    break;
                }
            }
            return re;
        }
        public void getlCreditCardAccount()
        {
            //lDept = new List<Position>();
            loBilg.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                OldBillGroup itm1 = new OldBillGroup();
                itm1.ID = row[obilg.ID].ToString();
                itm1.Name = row[obilg.Name].ToString();

                loBilg.Add(itm1);
            }
        }
        public C1ComboBox setCboGroupType(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectC1();
            //String aaa = "";
            if (loBilg.Count <= 0) getlCreditCardAccount();
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (OldBillGroup row in loBilg)
            {
                item = new ComboBoxItem();
                item.Value = row.ID;
                item.Text = row.Name;
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
