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
            lFpf = new List<OldCreditCardAccount>();
            occa.CreditCardID = "CreditCardID";
            occa.CreditCardName = "CreditCardName";
            occa.IntLock = "IntLock";
            occa.active = "active";
            occa.remark = "remark";
            occa.date_cancel = "date_cancel";
            occa.date_create = "date_create";
            occa.date_modi = "date_create";
            occa.user_cancel = "user_cancel";
            occa.user_create = "user_create";
            occa.user_modi = "user_modi";

            occa.table = "CreditCardAccount";
            occa.pkField = "CreditCardID";
        }
        public String insert(OldCreditCardAccount p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            p.CreditCardName = p.CreditCardName == null ? "" : p.CreditCardName;

            sql = "Insert Into " + occa.table + " set " +
                " " + occa.CreditCardName + " = '" + p.CreditCardName.Replace("'", "''") + "'" +
                //"," + oca.agent_code + " = '" + p.agent_code.Replace("'", "''") + "'" +
                "," + occa.active + " = '1'" +
                "," + occa.date_create + " = now()" +
                "," + occa.user_create + " = '" + userId.Replace("'", "''") + "'" +
                " ";
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
        public String update(OldCreditCardAccount p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            p.CreditCardName = p.CreditCardName == null ? "" : p.CreditCardName;


            sql = "Update " + occa.table + " Set " +
                " " + occa.CreditCardName + " = '" + p.CreditCardName.Replace("'", "''") + "'" +
                //"," + oca.agent_code + " = '" + p.agent_code.Replace("'", "''") + "'" +
                "," + occa.date_modi + " = now()" +
                "," + occa.user_modi + " = '" + userId.Replace("'", "''") + "' " +
                "Where " + occa.pkField + "='" + p.CreditCardID + "'"
                ;

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
        public String insertCreditAccount(OldCreditCardAccount p, String userId)
        {
            String re = "";

            if (p.CreditCardID.Equals(""))
            {
                re = insert(p, userId);
            }
            else
            {
                re = update(p, userId);
            }

            return re;
        }
        public String VoidCreditAccount(String stfId, String userIdVoid)
        {
            DataTable dt = new DataTable();
            String sql = "Update " + occa.table + " Set " +
                "" + occa.active + "='3'" +
                "," + occa.date_cancel + "=now() " +
                "," + occa.user_cancel + "='" + userIdVoid + "' " +
                "Where " + occa.pkField + "='" + stfId + "'";
            String re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
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
        public DataTable selectByCreditCardName1()
        {
            DataTable dt = new DataTable();
            String sql = "select occa." + occa.CreditCardID + ",occa." + occa.CreditCardName + " " +
                "From " + occa.table + " occa " +
                "Where active = '1' " +
                "Order By occa." + occa.CreditCardID;
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
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select occa.* " +
                "From " + occa.table + " occa ";
            //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
            //"Where sex." + agnO.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public OldCreditCardAccount selectByPk1(String copId)
        {
            OldCreditCardAccount cop1 = new OldCreditCardAccount();
            DataTable dt = new DataTable();
            String sql = "select occa.* " +
                "From " + occa.table + " occa " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where occa." + occa.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setCreditAccount(dt);
            return cop1;
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
        private OldCreditCardAccount setCreditAccount(DataTable dt)
        {
            OldCreditCardAccount dept1 = new OldCreditCardAccount();
            if (dt.Rows.Count > 0)
            {
                dept1.CreditCardID = dt.Rows[0][occa.CreditCardID].ToString();
                dept1.CreditCardName = dt.Rows[0][occa.CreditCardName].ToString();
                dept1.remark = dt.Rows[0][occa.remark].ToString();
                dept1.IntLock = dt.Rows[0][occa.IntLock].ToString();
            }
            else
            {
                dept1.CreditCardID = "";
                dept1.CreditCardName = "";
                dept1.remark = "";
                dept1.IntLock = "";
            }

            return dept1;
        }
    }
}
