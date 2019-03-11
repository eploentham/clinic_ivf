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
    public class BItemDB
    {
        public BItem itm;
        ConnectDB conn;
        public List<BItem> lItm;
        public BItemDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            itm = new BItem();
            lItm = new List<BItem>();
            itm.item_id = "item_id";
            itm.item_code = "item_code";
            itm.item_name_t = "item_name_t";
            itm.item_name_e = "item_name_e";
            itm.item_sub_group_id = "item_sub_group_id";
            itm.item_common_name = "item_common_name";
            itm.item_trade_name = "item_trade_name";
            itm.item_nick_name = "item_nick_name";
            itm.item_billing_subgroop_id = "item_billing_subgroop_id";
            itm.item_secret = "item_secret";
            itm.active = "active";
            itm.remark = "remark";

            itm.date_create = "date_create";
            itm.date_modi = "date_modi";
            itm.date_cancel = "date_cancel";
            itm.user_create = "user_create";
            itm.user_modi = "user_modi";

            itm.table = "b_item";
            itm.pkField = "item_id";
        }
        private void chkNull(BItem p)
        {
            int chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.item_code = p.item_code == null ? "" : p.item_code;
            p.item_name_t = p.item_name_t == null ? "" : p.item_name_t;
            p.item_nick_name = p.item_nick_name == null ? "" : p.item_nick_name;
            p.item_secret = p.item_secret == null ? "" : p.item_secret;
            p.item_name_e = p.item_name_e == null ? "" : p.item_name_e;
            p.item_common_name = p.item_common_name == null ? "" : p.item_common_name;
            p.remark = p.remark == null ? "" : p.remark;

            p.item_sub_group_id = int.TryParse(p.item_sub_group_id, out chk) ? chk.ToString() : "0";
            p.item_billing_subgroop_id = int.TryParse(p.item_billing_subgroop_id, out chk) ? chk.ToString() : "0";
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select stf.* " +
                "From " + itm.table + " stf " +
                "Where stf." + itm.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select cop.*  " +
                "From " + itm.table + " cop " +
                " " +
                "Where cop." + itm.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public void getlStf()
        {
            //lDept = new List<Position>();

            lItm.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                BItem itm1 = new BItem();
                itm1.item_id = row[itm.item_id].ToString();
                itm1.item_code = row[itm.item_code].ToString();
                itm1.item_name_t = row[itm.item_name_t].ToString();
                itm1.item_name_e = row[itm.item_name_e].ToString();
                itm1.item_sub_group_id = row[itm.item_sub_group_id].ToString();
                itm1.item_common_name = row[itm.item_common_name].ToString();
                itm1.item_trade_name = row[itm.item_trade_name].ToString();
                itm1.item_nick_name = row[itm.item_nick_name].ToString();
                itm1.item_billing_subgroop_id = row[itm.item_billing_subgroop_id].ToString();
                itm1.item_secret = row[itm.item_secret].ToString();
                itm1.active = row[itm.active].ToString();
                itm1.remark = row[itm.remark].ToString();
                itm1.date_create = row[itm.date_create].ToString();
                itm1.date_modi = row[itm.date_modi].ToString();
                itm1.date_cancel = row[itm.date_cancel].ToString();
                itm1.user_create = row[itm.user_create].ToString();
                itm1.user_modi = row[itm.user_modi].ToString();
                //itm1.remark = row[itm.remark].ToString();
                lItm.Add(itm1);
            }
        }
        public void setCboItem(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectAll();
            int i = 0;
            if (lItm.Count <= 0) getlStf();
            item = new ComboBoxItem();
            item.Value = "";
            item.Text = "";
            c.Items.Add(item);
            foreach (BItem cus1 in lItm)
            {
                item = new ComboBoxItem();
                item.Value = cus1.item_id;
                item.Text = cus1.item_name_t;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    //c.SelectedItem = item.Value;
                    c.SelectedText = item.Text;
                    c.SelectedIndex = i + 1;
                }
                i++;
            }
        }
    }
}
