using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class OldGroupDrugHeaderDB
    {
        public OldGroupDrugHeader oGuh;
        ConnectDB conn;

        public OldGroupDrugHeaderDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            oGuh = new OldGroupDrugHeader();
            oGuh.GDID = "GDID";
            oGuh.GroupName = "GroupName";

            oGuh.table = "GroupDrugHeader";
            oGuh.pkField = "GDID";
        }
        public DataTable selectByGrpDrugH1()
        {
            DataTable dt = new DataTable();
            String sql = "select oGuh." + oGuh.GDID + ",oGuh." + oGuh.GroupName + " " +
                "From " + oGuh.table + " oGuh " +
                "Where active = '1' " +
                "Order By oGuh." + oGuh.GroupName;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
    }
}
