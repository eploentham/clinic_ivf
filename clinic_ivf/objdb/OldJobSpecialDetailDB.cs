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
            ojsd.row1 = "row1";
            ojsd.qty = "qty";
            ojsd.bill_group_id = "bill_group_id";
            ojsd.price1 = "price1";

            ojsd.table = "JobSpecialDetail";
            ojsd.pkField = "ID";
        }
        private void chkNull(OldJobSpecialDetail p)
        {
            long chk = 0;
            decimal chk1 = 0;
            
            p.SName = p.SName == null ? "" : p.SName;
            //p.Extra = p.Extra == null ? "0" : p.Extra;
            p.Status = p.Status == null ? "" : p.Status;
            p.PIDS = p.PIDS == null ? "" : p.PIDS;
            p.status_req_accept = p.status_req_accept == null ? "" : p.status_req_accept;            

            p.SID = long.TryParse(p.SID, out chk) ? chk.ToString() : "0";
            p.VN = long.TryParse(p.VN, out chk) ? chk.ToString() : "0";
            p.PID = long.TryParse(p.PID, out chk) ? chk.ToString() : "0";
            p.PIDS = long.TryParse(p.PIDS, out chk) ? chk.ToString() : "0";
            p.W1UID = long.TryParse(p.W1UID, out chk) ? chk.ToString() : "0";
            p.W2UID = long.TryParse(p.W2UID, out chk) ? chk.ToString() : "0";
            p.W3UID = long.TryParse(p.W3UID, out chk) ? chk.ToString() : "0";
            p.W4UID = long.TryParse(p.W4UID, out chk) ? chk.ToString() : "0";
            p.req_id = long.TryParse(p.req_id, out chk) ? chk.ToString() : "0";
            p.Extra = long.TryParse(p.Extra, out chk) ? chk.ToString() : "0";
            p.row1 = long.TryParse(p.row1, out chk) ? chk.ToString() : "0";
            p.qty = long.TryParse(p.qty, out chk) ? chk.ToString() : "0";
            p.bill_group_id = long.TryParse(p.bill_group_id, out chk) ? chk.ToString() : "0";

            p.Price = decimal.TryParse(p.Price, out chk1) ? chk1.ToString() : "0";
            p.price1 = decimal.TryParse(p.price1, out chk1) ? chk1.ToString() : "0";
        }
        public String insert(OldJobSpecialDetail p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            //lbReq.form_a_id = "form_a_id";
            //p.req_code = genReqDoc();
            sql = "Insert Into " + ojsd.table + " Set " +
                " " + ojsd.VN + " = '" + p.VN + "'" +
                "," + ojsd.SID + "= '" + p.SID + "'" +
                "," + ojsd.SName + "= '" + p.SName.Replace("'", "''") + "'" +
                "," + ojsd.Extra + "= '" + p.Extra + "'" +
                "," + ojsd.Price + "= '" + p.Price + "'" +
                "," + ojsd.Status + "= '" + p.Status + "'" +
                "," + ojsd.PID + "= '" + p.PID + "'" +
                "," + ojsd.PIDS + "= '" + p.PIDS.Replace("'", "''") + "'" +
                "," + ojsd.W1UID + "= '" + p.W1UID.Replace("'", "''") + "'" +
                "," + ojsd.W2UID + "= '" + p.W2UID.Replace("'", "''") + "'" +
                "," + ojsd.W3UID + "= '" + p.W3UID.Replace("'", "''") + "'" +
                "," + ojsd.W4UID + "= '" + p.W4UID.Replace("'", "''") + "'" +
                "," + ojsd.FileName + "= '" + p.FileName.Replace("'", "''") + "'" +
                "," + ojsd.status_req_accept + "= '" + p.status_req_accept.Replace("'", "''") + "'" +
                "," + ojsd.req_id + "= '" + p.req_id.Replace("'", "''") + "'" +
                "," + ojsd.row1 + "= '" + p.row1.Replace("'", "''") + "'" +
                "," + ojsd.qty + "= '" + p.qty + "'" +
                "," + ojsd.bill_group_id + "= '" + p.bill_group_id + "'" +
                "," + ojsd.price1 + "= '" + p.price1 + "'" +
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
            String sql = "Delete From  " + ojsd.table + " " +
                "Where " + ojsd.pkField + "='" + id + "'";
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
            String sql = "select ojsd.* " +
                "From " + ojsd.table + " ojsd " +
                "Where ojsd." + ojsd.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectExtra1ByVN(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select ojsd.* " +
                "From " + ojsd.table + " ojsd " +
                "Where ojsd." + ojsd.VN + " ='" + copId + "' and Extra='1' " +
                "Order By ojsd." + ojsd.SID + ",ojsd." + ojsd.ID;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectExtra0ByVN(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select ojsd.* " +
                "From " + ojsd.table + " ojsd " +
                "Where ojsd." + ojsd.VN + " ='" + copId + "' and Extra='0' " +
                "Order By ojsd." + ojsd.SID + ",ojsd." + ojsd.ID;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByPID(String pid)
        {
            DataTable dt = new DataTable();
            String sql = "select ojsd.*,vs.visit_begin_visit_time " +
                "From " + ojsd.table + " ojsd " +
                "Left Join t_visit vs on ojsd.VN = vs.visit_vn " +
                "Where ojsd." + ojsd.PID + " ='" + pid + "' " +
                "Order By ojsd." + ojsd.SID + ",ojsd." + ojsd.ID;
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
