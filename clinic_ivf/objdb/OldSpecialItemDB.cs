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

        public OldSpecialItemDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
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
    }
}
