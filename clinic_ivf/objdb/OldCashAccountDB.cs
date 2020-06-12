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
    public class OldCashAccountDB
    {
        public OldCashAccount oca;
        ConnectDB conn;
        public List<OldCashAccount> lFpf;

        public OldCashAccountDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            oca = new OldCashAccount();
            lFpf = new List<OldCashAccount>();
            oca.CashID = "CashID";
            oca.CashName = "CashName";
            oca.IntLock = "IntLock";
            oca.active = "active";
            oca.remark = "remark";
            oca.date_cancel = "date_cancel";
            oca.date_create = "date_create";
            oca.date_modi = "date_modi";
            oca.user_cancel = "user_cancel";
            oca.user_create = "user_create";
            oca.user_modi = "user_modi";

            oca.table = "CashAccount";
            oca.pkField = "CashID";
        }
        public String insert(OldCashAccount p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            p.CashName = p.CashName == null ? "" : p.CashName;

            sql = "Insert Into " + oca.table + " set " +
                " " + oca.CashName + " = '" + p.CashName.Replace("'", "''") + "'" +
                //"," + oca.agent_code + " = '" + p.agent_code.Replace("'", "''") + "'" +
                "," + oca.active + " = '1'" +
                "," + oca.date_create + " = now()" +
                "," + oca.user_create + " = '" + userId.Replace("'", "''") + "'" +
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
        public String update(OldCashAccount p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            p.CashName = p.CashName == null ? "" : p.CashName;


            sql = "Update " + oca.table + " Set " +
                " " + oca.CashName + " = '" + p.CashName.Replace("'", "''") + "'" +
                //"," + oca.agent_code + " = '" + p.agent_code.Replace("'", "''") + "'" +
                "," + oca.date_modi + " = now()" +
                "," + oca.user_modi + " = '" + userId.Replace("'", "''") + "'" +
                "Where " + oca.pkField + "='" + p.CashID + "'"
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
        public String insertCashAccount(OldCashAccount p, String userId)
        {
            String re = "";

            if (p.CashID.Equals(""))
            {
                re = insert(p, userId);
            }
            else
            {
                re = update(p, userId);
            }

            return re;
        }
        public String VoidCashAccount(String stfId, String userIdVoid)
        {
            DataTable dt = new DataTable();
            String sql = "Update " + oca.table + " Set " +
                "" + oca.active + "='3'" +
                "," + oca.date_cancel + "=now() " +
                "," + oca.user_cancel + "='" + userIdVoid + "' " +
                "Where " + oca.pkField + "='" + stfId + "'";
            String re = conn.ExecuteNonQuery(conn.conn, sql);

            return re;
        }
        public DataTable selectByCashCardName()
        {
            DataTable dt = new DataTable();
            String sql = "select oca." + oca.CashID + ",oca." + oca.CashName + " " +
                "From " + oca.table + " oca " +
                "Where active = '1' " +
                "Order By oca." + oca.CashID;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByCashCardName1()
        {
            DataTable dt = new DataTable();
            String sql = "select oca." + oca.CashID + ",oca." + oca.CashName + " " +
                "From " + oca.table + " oca " +
                "Where active = '1' " +
                "Order By oca." + oca.CashID;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select oca.*  " +
                "From " + oca.table + " oca " +
                " " +
                "Where oca." + oca.active + " ='1' "+
                "Order By oca." + oca.CashID; 
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select oca.* " +
                "From " + oca.table + " oca ";
            //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
            //"Where sex." + agnO.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public OldCashAccount selectByPk1(String copId)
        {
            OldCashAccount cop1 = new OldCashAccount();
            DataTable dt = new DataTable();
            String sql = "select oca.* " +
                "From " + oca.table + " oca " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where oca." + oca.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setCashAccount(dt);
            return cop1;
        }
        public String getList(String id)
        {
            String re = "";
            if (lFpf.Count <= 0)
            {
                getlCashAccount();
            }
            foreach (OldCashAccount sex in lFpf)
            {
                if (sex.CashID.Equals(id))
                {
                    re = sex.CashName;
                    break;
                }
            }
            return re;
        }
        public void getlCashAccount()
        {
            //lDept = new List<Position>();
            lFpf.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                OldCashAccount itm1 = new OldCashAccount();
                itm1.CashID = row[oca.CashID].ToString();
                itm1.CashName = row[oca.CashName].ToString();

                lFpf.Add(itm1);
            }
        }
        public C1ComboBox setCboCashAccount(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectC1();
            //String aaa = "";
            if (lFpf.Count <= 0) getlCashAccount();
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (OldCashAccount row in lFpf)
            {
                item = new ComboBoxItem();
                item.Value = row.CashID;
                item.Text = row.CashName;
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
        private OldCashAccount setCashAccount(DataTable dt)
        {
            OldCashAccount dept1 = new OldCashAccount();
            if (dt.Rows.Count > 0)
            {
                dept1.CashID = dt.Rows[0][oca.CashID].ToString();
                dept1.CashName = dt.Rows[0][oca.CashName].ToString();
                dept1.remark = dt.Rows[0][oca.remark].ToString();
                dept1.IntLock = dt.Rows[0][oca.IntLock].ToString();
            }
            else
            {
                dept1.CashID = "";
                dept1.CashName = "";
                dept1.remark = "";
                dept1.IntLock = "";
            }

            return dept1;
        }
    }
}
