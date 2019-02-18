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
    public class OldCreditCardAccountDB
    {
        public OldCreditCardAccount occa;
        ConnectDB conn;
        public List<OldCreditCardAccount> lFpf;

        public OldCreditCardAccountDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            occa = new OldCreditCardAccount();
            occa.CreditCardID = "CreditCardID";
            occa.CreditCardName = "CreditCardName";
            occa.IntLock = "IntLock";

            occa.table = "OldCreditCardAccount";
            occa.pkField = "CreditCardID";
        }
        public DataTable selectByCreditCardName()
        {
            DataTable dt = new DataTable();
            String sql = "select occa." + occa.CreditCardID + ",occa." + occa.CreditCardName + " " +
                "From " + occa.table + " occa " +
                "Where active = '1' " +
                "Order By occa." + occa.CreditCardName;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select occa.*  " +
                "From " + occa.table + " occa " +
                " " +
                "Where occa." + occa.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public String getList(String id)
        {
            String re = "";
            if (lFpf.Count <= 0)
            {
                getlCreditCardAccount();
            }
            foreach (OldCreditCardAccount sex in lFpf)
            {
                if (sex.CreditCardID.Equals(id))
                {
                    re = sex.CreditCardName;
                    break;
                }
            }
            return re;
        }
        public void getlCreditCardAccount()
        {
            //lDept = new List<Position>();
            lFpf.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                OldCreditCardAccount itm1 = new OldCreditCardAccount();
                itm1.CreditCardID = row[occa.CreditCardID].ToString();
                itm1.CreditCardName = row[occa.CreditCardName].ToString();

                lFpf.Add(itm1);
            }
        }
        public C1ComboBox setCboCreditCardAccount(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectC1();
            //String aaa = "";
            if (lFpf.Count <= 0) getlCreditCardAccount();
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (OldCreditCardAccount row in lFpf)
            {
                item = new ComboBoxItem();
                item.Value = row.CreditCardID;
                item.Text = row.CreditCardName;
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
