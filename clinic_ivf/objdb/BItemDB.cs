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
            itm.user_cancel = "user_cancel";
            itm.status_item = "status_item";
            itm.item_master_id = "item_master_id";
            itm.item_link_id = "item_link_id";

            itm.table = "b_item";
            itm.pkField = "item_id";
        }
        private void chkNull(BItem p)
        {
            long chk = 0;

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
            p.item_trade_name = p.item_trade_name == null ? "" : p.item_trade_name;

            p.item_sub_group_id = long.TryParse(p.item_sub_group_id, out chk) ? chk.ToString() : "0";
            p.item_billing_subgroop_id = long.TryParse(p.item_billing_subgroop_id, out chk) ? chk.ToString() : "0";
            p.status_item = long.TryParse(p.status_item, out chk) ? chk.ToString() : "0";
            p.item_master_id = long.TryParse(p.item_master_id, out chk) ? chk.ToString() : "0";
            p.item_link_id = long.TryParse(p.item_link_id, out chk) ? chk.ToString() : "0";
        }
        public String insert(BItem p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            long chk = 0;

            chkNull(p);
            //lbReq.form_a_id = "form_a_id";
            //p.req_code = genReqDoc();
            sql = "Insert Into " + itm.table + " Set " +
                " " + itm.item_code + " = '" + p.item_code.Replace("'", "''") + "'" +
                "," + itm.item_name_t + "= '" + p.item_name_t.Replace("'", "''") + "'" +
                "," + itm.item_name_e + "= '" + p.item_name_e.Replace("'", "''") + "'" +
                "," + itm.item_sub_group_id + "= '" + p.item_sub_group_id + "'" +
                "," + itm.item_common_name + "= '" + p.item_common_name.Replace("'", "''") + "'" +
                "," + itm.item_trade_name + "= '" + p.item_trade_name.Replace("'", "''") + "'" +
                "," + itm.item_nick_name + "= '" + p.item_nick_name.Replace("'", "''") + "'" +
                "," + itm.item_billing_subgroop_id + "= '" + p.item_billing_subgroop_id + "'" +
                "," + itm.item_secret + "= '" + p.item_secret + "'" +
                "," + itm.active + "= '" + p.active + "'" +
                "," + itm.remark + "= '" + p.remark + "'" +
                "," + itm.date_create + "= now()" +
                "," + itm.user_create + "= '" + userId + "'" +
                "," + itm.status_item + "= '" + p.status_item + "'" +
                "," + itm.item_master_id + "= '" + p.item_master_id + "'" +
                "," + itm.item_link_id + "= '" + p.item_link_id + "'" +
                "";
            try
            {
                re = conn.ExecuteNonQuery(conn.conn, sql);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
            }

            return re;
        }
        public String updateCodeLinkMaster(String id, String code, String masid, String linkid, String userId)
        {
            String re = "", sql = "";
            sql = "Update " + itm.table + " Set " +
                " " + itm.item_code + " = '" + code + "'" +
                "," + itm.user_modi + "= '" + userId + "'" +
                "," + itm.date_modi + "= now()" +
                "," + itm.item_master_id + "= '" + masid + "'" +
                "," + itm.item_link_id + "= '" + linkid + "'" +
                "Where " + itm.pkField + "='" + id + "'";
            try
            {
                re = conn.ExecuteNonQuery(conn.conn, sql);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
            }

            return re;
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
        public DataTable selectAllEx()
        {
            DataTable dt = new DataTable();
            String sql = "select cop.*  " +
                "From " + itm.table + " cop " +
                " " +
                "Where cop." + itm.active + " ='1' ";
            dt = conn.selectData(conn.connEx, sql);

            return dt;
        }
        public String selectCount()
        {
            DataTable dt = new DataTable();
            String re = "";
            String sql = "select count(1) as cnt  " +
                "From " + itm.table + " cop " +
                " " +
                "Where cop." + itm.active + " ='1' ";
            dt = conn.selectData(conn.connEx, sql);
            if (dt.Rows.Count > 0)
            {
                re = dt.Rows[0]["cnt"].ToString();
            }
            return re;
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
