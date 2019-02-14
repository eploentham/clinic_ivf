using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class OldJobSpecialDetailDB
    {
        public OldJobSpecialDetail ojsd;
        ConnectDB conn;

        public OldJobSpecialDetailDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            ojsd = new OldJobSpecialDetail();
            ojsd.ID = "ID";
            ojsd.VN = "VN";
            ojsd.SID = "SID";
            ojsd.SName = "SName";
            ojsd.Extra = "Extra";
            ojsd.Price = "Price";
            ojsd.Status = "Status";
            ojsd.PID = "PID";
            ojsd.PIDS = "PIDS";
            ojsd.W1UID = "W1UID";
            ojsd.W2UID = "W2UID";
            ojsd.W3UID = "W3UID";
            ojsd.W4UID = "W4UID";
            ojsd.FileName = "FileName";
            ojsd.status_req_accept = "status_req_accept";
            ojsd.req_id = "req_id";

            ojsd.table = "JobSpecialDetail";
            ojsd.pkField = "ID";
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select ojsd.* " +
                "From " + ojsd.table + " ojsd " +
                "Where ojsd." + ojsd.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByVN(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select ojsd.* " +
                "From " + ojsd.table + " ojsd " +
                "Where ojsd." + ojsd.VN + " ='" + copId + "' " +
                "Order By ojsd."+ ojsd.SID+ ",ojsd." + ojsd.ID;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
    }
}
