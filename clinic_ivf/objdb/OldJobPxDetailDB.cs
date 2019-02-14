using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class OldJobPxDetailDB
    {
        public OldJobPxDetail oJpxd;
        ConnectDB conn;

        public OldJobPxDetailDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            oJpxd = new OldJobPxDetail();
            oJpxd.ID = "ID";
            oJpxd.VN = "VN";
            oJpxd.DUID = "DUID";
            oJpxd.QTY = "QTY";
            oJpxd.Extra = "Extra";
            oJpxd.Price = "Price";
            oJpxd.Status = "Status";
            oJpxd.PID = "PID";
            oJpxd.PIDS = "PIDS";
            oJpxd.DUName = "DUName";
            oJpxd.Comment = "Comment";
            oJpxd.TUsage = "TUsage";
            oJpxd.EUsage = "EUsage";

            oJpxd.table = "JobPxDetail";
            oJpxd.pkField = "ID";
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select oJpxd.* " +
                "From " + oJpxd.table + " oJpxd " +
                "Where oJpxd." + oJpxd.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByVN(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select oJpxd.* " +
                "From " + oJpxd.table + " oJpxd " +
                "Where oJpxd." + oJpxd.VN + " ='" + copId + "' " +
                "Order By oJpxd."+oJpxd.DUName;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
    }
}
