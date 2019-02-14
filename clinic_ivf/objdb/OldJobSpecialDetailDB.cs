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
        public String selectSumIncludePriceByVN(String copId)
        {
            String re = "0";
            DataTable dt = new DataTable();
            String sql = "select sum(ojsd." + ojsd.Price + ") as Include_Pkg_Price " +
                "From " + ojsd.table + " ojsd " +
                "Where ojsd." + ojsd.VN + " ='" + copId + "' and Extra='0' "
                ;
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                re = dt.Rows[0]["Include_Pkg_Price"] != null ? dt.Rows[0]["Include_Pkg_Price"].ToString() : "0";
            }
            return re;
        }
        public String selectSumExtraPriceByVN(String copId)
        {
            String re = "0";
            DataTable dt = new DataTable();
            String sql = "select sum(ojsd." + ojsd.Price + ") as Extra_Pkg_Price " +
                "From " + ojsd.table + " ojsd " +
                "Where ojsd." + ojsd.VN + " ='" + copId + "' and Extra='1' "
                ;
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                re = dt.Rows[0]["Extra_Pkg_Price"] != null ? dt.Rows[0]["Extra_Pkg_Price"].ToString() : "0";
            }
            return re;
        }
        public String updateStatusCloseJobSpecial(String vn)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Update " + ojsd.table + " Set " +
                " " + ojsd.Status + " = '2'" +
                "Where " + ojsd.VN + "='" + vn + "'"
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
    }
}
