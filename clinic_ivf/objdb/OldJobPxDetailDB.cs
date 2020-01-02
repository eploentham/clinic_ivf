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
            oJpxd.row1 = "row1";

            oJpxd.table = "JobPxDetail";
            oJpxd.pkField = "ID";
        }
        private void chkNull(JobPxDetail p)
        {
            long chk = 0;
            decimal chk1 = 0;


            p.PIDS = p.PIDS == null ? "" : p.PIDS;
            p.DUName = p.DUName == null ? "" : p.DUName;
            p.Comment = p.Comment == null ? "NULL" : p.Comment;
            p.TUsage = p.TUsage == null ? "" : p.TUsage;
            p.EUsage = p.EUsage == null ? "" : p.EUsage;
            p.Comment = p.Comment.Equals("")? "NULL" : p.Comment;

            p.ID = long.TryParse(p.ID, out chk) ? chk.ToString() : "0";
            p.VN = long.TryParse(p.VN, out chk) ? chk.ToString() : "0";
            p.DUID = long.TryParse(p.DUID, out chk) ? chk.ToString() : "0";
            p.QTY = long.TryParse(p.QTY, out chk) ? chk.ToString() : "0";
            p.Extra = long.TryParse(p.Extra, out chk) ? chk.ToString() : "0";
            p.Status = long.TryParse(p.Status, out chk) ? chk.ToString() : "0";
            p.PID = long.TryParse(p.PID, out chk) ? chk.ToString() : "0";
            p.row1 = long.TryParse(p.row1, out chk) ? chk.ToString() : "0";

            p.Price = decimal.TryParse(p.Price, out chk1) ? chk1.ToString() : "0";
            //p.PIDS = decimal.TryParse(p.PIDS, out chk1) ? chk.ToString() : "0";
        }
        public String insert(JobPxDetail p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            //lbReq.form_a_id = "form_a_id";
            //p.req_code = genReqDoc();
            sql = "Insert Into " + oJpxd.table + " Set " +
                " " + oJpxd.VN + " = '" + p.VN + "'" +
                "," + oJpxd.DUID + "= '" + p.DUID + "'" +
                "," + oJpxd.QTY + "= '" + p.QTY + "'" +
                "," + oJpxd.Extra + "= '" + p.Extra.Replace("'", "''") + "'" +
                "," + oJpxd.Price + "= '" + p.Price.Replace("'", "''") + "'" +
                "," + oJpxd.Status + "= '" + p.Status + "'" +
                "," + oJpxd.PID + "= '" + p.PID + "'" +
                "," + oJpxd.PIDS + "= '" + p.PIDS + "'" +
                "," + oJpxd.DUName + "= '" + p.DUName.Replace("'", "''") + "'" +
                "," + oJpxd.Comment + "= '" + p.Comment.Replace("'", "''") + "'" +
                "," + oJpxd.TUsage + "= '" + p.TUsage.Replace("'", "''") + "'" +
                "," + oJpxd.EUsage + "= '" + p.EUsage.Replace("'", "''") + "'" +
                "," + oJpxd.row1 + "= '" + p.row1 + "'" +
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
        public String deleteByPk(String id)
        {
            DataTable dt = new DataTable();
            String re = "";
            String sql = "Delete From  " + oJpxd.table + " " +
                "Where " + oJpxd.pkField + "='" + id + "'";
            //re = conn.ExecuteNonQuery(conn.conn, sql);
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
            String sql = "select oJpxd.* " +
                "From " + oJpxd.table + " oJpxd " +
                "Where oJpxd." + oJpxd.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectExtra1ByVN(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select oJpxd.* " +
                "From " + oJpxd.table + " oJpxd " +
                "Where oJpxd." + oJpxd.VN + " ='" + copId + "' and Extra='1' " +
                "Order By oJpxd." + oJpxd.DUName;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectExtra0ByVN(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select oJpxd.* " +
                "From " + oJpxd.table + " oJpxd " +
                "Where oJpxd." + oJpxd.VN + " ='" + copId + "' and Extra='0' " +
                "Order By oJpxd." + oJpxd.DUName;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByPID(String pid)
        {
            DataTable dt = new DataTable();
            String sql = "select oJpxd.*,vs.visit_begin_visit_time " +
                "From " + oJpxd.table + " oJpxd " +
                "Left Join t_visit vs on oJpxd.VN = vs.visit_vn " +
                "Where oJpxd." + oJpxd.PID + " ='" + pid + "' " +
                "Order By oJpxd." + oJpxd.DUName;
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
        public String selectSumIncludePriceByVN(String copId)
        {
            String re = "0";
            DataTable dt = new DataTable();
            String sql = "select sum(oJpxd."+oJpxd.Price + "*" + oJpxd.QTY + ") as Include_Pkg_Price " +
                "From " + oJpxd.table + " oJpxd " +
                "Where oJpxd." + oJpxd.VN + " ='" + copId + "' and Extra='0' " 
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
            String sql = "select sum(oJpxd." + oJpxd.Price + "*" + oJpxd.QTY + ") as Extra_Pkg_Price " +
                "From " + oJpxd.table + " oJpxd " +
                "Where oJpxd." + oJpxd.VN + " ='" + copId + "' and Extra='1' "
                ;
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                re = dt.Rows[0]["Extra_Pkg_Price"] != null ? dt.Rows[0]["Extra_Pkg_Price"].ToString() : "0";
            }
            return re;
        }
    }
}
