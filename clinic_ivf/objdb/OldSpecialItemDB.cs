using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class OldSpecialItemDB
    {
        public OldSpecialItem sitm;
        ConnectDB conn;
        public List<OldSpecialItem> loBilg;

        public OldSpecialItemDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            loBilg = new List<OldSpecialItem>();
            sitm = new OldSpecialItem();
            sitm.SID= "SID";
            sitm.SName= "SName";
            sitm.Price= "Price";
            sitm.W1GID= "W1GID";
            sitm.W2GID= "W2GID";
            sitm.W3GID= "W3GID";
            sitm.W4GID= "W4GID";
            sitm.isActive= "isActive";
            sitm.BillGroupID= "BillGroupID";

            sitm.table = "SpecialItem";
            sitm.pkField = "SID";
        }
        public String getList(String id)
        {
            String re = "";
            if (loBilg.Count <= 0)
            {
                getlCreditCardAccount();
            }
            foreach (OldSpecialItem sex in loBilg)
            {
                if (sex.SID.Equals(id))
                {
                    re = sex.SName;
                    break;
                }
            }
            return re;
        }
        public String getBillGroupID(String id)
        {
            String re = "";
            if (loBilg.Count <= 0)
            {
                getlCreditCardAccount();
            }
            foreach (OldSpecialItem sex in loBilg)
            {
                if (sex.SID.Equals(id))
                {
                    re = sex.BillGroupID;
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
                OldSpecialItem itm1 = new OldSpecialItem();
                itm1.SID = row[sitm.SID].ToString();
                itm1.SName = row[sitm.SName].ToString();
                itm1.BillGroupID = row[sitm.BillGroupID].ToString();
                loBilg.Add(sitm);
            }
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select sitm.*  " +
                "From " + sitm.table + " sitm " +
                " " ;
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String pttId)
        {
            DataTable dt = new DataTable();
            String sql = "select sitm.* " +
                "From " + sitm.table + " sitm " +
                "Where sitm." + sitm.pkField + " ='" + pttId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public OldSpecialItem selectByPk1(String pttId)
        {
            OldSpecialItem labi1 = new OldSpecialItem();
            DataTable dt = new DataTable();
            String sql = "select sitm.* " +
                "From " + sitm.table + " sitm " +
                "Where sitm." + sitm.pkField + " ='" + pttId + "' ";
            dt = conn.selectData(conn.conn, sql);
            labi1 = setSpecialItem(dt);
            return labi1;
        }
        public DataTable selectBySpecialItem1()
        {
            DataTable dt = new DataTable();
            String sql = "select sitm." + sitm.SID + ",sitm." + sitm.SName + ",sitm." + sitm.Price + " " +
                "From " + sitm.table + " sitm " +
                "Where isActive = '1' " +
                "Order By sitm." + sitm.SName;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public OldSpecialItem setSpecialItem(DataTable dt)
        {
            OldSpecialItem sitm1 = new OldSpecialItem();
            if (dt.Rows.Count > 0)
            {
                sitm1.SID = dt.Rows[0][sitm.SID].ToString();
                sitm1.SName = dt.Rows[0][sitm.SName].ToString();
                sitm1.Price = dt.Rows[0][sitm.Price].ToString();
                sitm1.W1GID = dt.Rows[0][sitm.W1GID].ToString();
                sitm1.W2GID = dt.Rows[0][sitm.W2GID].ToString();
                sitm1.W3GID = dt.Rows[0][sitm.W3GID].ToString();
                sitm1.W4GID = dt.Rows[0][sitm.W4GID].ToString();
                sitm1.isActive = dt.Rows[0][sitm.isActive].ToString();
                sitm1.BillGroupID = dt.Rows[0][sitm.BillGroupID].ToString();
                
            }
            else
            {
                setSpecialItem1(sitm1);
            }
            return sitm1;
        }
        private OldSpecialItem setSpecialItem1(OldSpecialItem stf1)
        {
            stf1.SID = "";
            stf1.SName = "";
            stf1.Price = "";
            stf1.W1GID = "";
            stf1.W2GID = "";
            stf1.W3GID = "";
            stf1.W4GID = "";
            stf1.isActive = "";
            stf1.BillGroupID = "";
            
            return stf1;
        }
    }
}
