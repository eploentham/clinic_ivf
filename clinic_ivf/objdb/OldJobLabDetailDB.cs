using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class OldJobLabDetailDB
    {
        public OldJobLabDetail jlabD;
        ConnectDB conn;

        public OldJobLabDetailDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            jlabD = new OldJobLabDetail();
            jlabD.ID = "ID";
            jlabD.VN = "VN";
            jlabD.LID = "LID";
            jlabD.Extra = "Extra";
            jlabD.Price = "Price";
            jlabD.Status = "Status";
            jlabD.PID = "PID";
            jlabD.PIDS = "PIDS";
            jlabD.LName = "LName";
            jlabD.SP1V = "SP1V";
            jlabD.SP2V = "SP2V";
            jlabD.SP3V = "SP3V";
            jlabD.SP4V = "SP4V";
            jlabD.SP5V = "SP5V";
            jlabD.SP6V = "SP6V";
            jlabD.SP7V = "SP7V";
            jlabD.SubItem = "SubItem";
            jlabD.FileName = "FileName";
            jlabD.Worker1 = "Worker1";
            jlabD.Worker2 = "Worker2";
            jlabD.Worker3 = "Worker3";
            jlabD.Worker4 = "Worker4";
            jlabD.LGID = "LGID";
            jlabD.QTY = "QTY";
            jlabD.row1 = "row1";
            jlabD.status_show_qty = "status_show_qty";

            jlabD.table = "JobLabDetail";
            jlabD.pkField = "ID";
        }
        private void chkNull(OldJobLabDetail p)
        {
            long chk = 0;
            decimal chk1 = 0;


            p.PIDS = p.PIDS == null ? "" : p.PIDS;
            p.VN = p.VN == null ? "" : p.VN;
            p.FileName = p.FileName == null ? "" : p.FileName;
            p.Worker1 = p.Worker1 == null ? "" : p.Worker1;
            p.Worker2 = p.Worker2 == null ? "" : p.Worker2;
            p.Worker3 = p.Worker3 == null ? "" : p.Worker3;
            p.Worker4 = p.Worker4 == null ? "" : p.Worker4;
            p.SP1V = p.SP1V == null ? "" : p.SP1V;
            p.SP2V = p.SP2V == null ? "" : p.SP2V;
            p.SP3V = p.SP3V == null ? "" : p.SP3V;
            p.SP4V = p.SP4V == null ? "" : p.SP4V;
            p.SP5V = p.SP5V == null ? "" : p.SP5V;
            p.SP6V = p.SP6V == null ? "" : p.SP6V;
            p.SP7V = p.SP7V == null ? "" : p.SP7V;
            p.Extra = p.Extra == null ? "" : p.Extra;
            p.status_show_qty = p.status_show_qty == null ? "0" : p.status_show_qty;

            p.LGID = long.TryParse(p.LGID, out chk) ? chk.ToString() : "0";
            p.QTY = long.TryParse(p.QTY, out chk) ? chk.ToString() : "0";
            p.SubItem = long.TryParse(p.SubItem, out chk) ? chk.ToString() : "0";
            p.PID = long.TryParse(p.PID, out chk) ? chk.ToString() : "0";
            p.Status = long.TryParse(p.Status, out chk) ? chk.ToString() : "0";
            p.Extra = long.TryParse(p.Extra, out chk) ? chk.ToString() : "0";
            p.PID = long.TryParse(p.PID, out chk) ? chk.ToString() : "0";
            p.row1 = long.TryParse(p.row1, out chk) ? chk.ToString() : "0";

            p.Price = decimal.TryParse(p.Price, out chk1) ? chk1.ToString() : "0";
            //p.PIDS = decimal.TryParse(p.PIDS, out chk1) ? chk.ToString() : "0";
        }
        public String insert(OldJobLabDetail p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            //lbReq.form_a_id = "form_a_id";
            //p.req_code = genReqDoc();
            sql = "Insert Into " + jlabD.table + " Set " +
                " " + jlabD.VN + " = '" + p.VN + "'" +
                "," + jlabD.LID + "= '" + p.LID + "'" +
                "," + jlabD.Extra + "= '" + p.Extra + "'" +
                "," + jlabD.Price + "= '" + p.Price + "'" +
                "," + jlabD.Status + "= '" + p.Status + "'" +
                "," + jlabD.PID + "= '" + p.PID + "'" +
                "," + jlabD.PIDS + "= '" + p.PIDS + "'" +
                "," + jlabD.LName + "= '" + p.LName.Replace("'", "''") + "'" +
                "," + jlabD.SP1V + "= '" + p.SP1V.Replace("'", "''") + "'" +
                "," + jlabD.SP2V + "= '" + p.SP2V.Replace("'", "''") + "'" +
                "," + jlabD.SP3V + "= '" + p.SP3V.Replace("'", "''") + "'" +
                "," + jlabD.SP4V + "= '" + p.SP4V.Replace("'", "''") + "'" +
                "," + jlabD.SP5V + "= '" + p.SP5V.Replace("'", "''") + "'" +
                "," + jlabD.SP6V + "= '" + p.SP6V.Replace("'", "''") + "'" +
                "," + jlabD.SP7V + "= '" + p.SP7V.Replace("'", "''") + "'" +
                "," + jlabD.SubItem + "= '" + p.SubItem + "'" +
                "," + jlabD.FileName + "= '" + p.FileName.Replace("'", "''") + "'" +
                "," + jlabD.Worker1 + "= '" + p.Worker1.Replace("'", "''") + "'" +
                "," + jlabD.Worker2 + "= '" + p.Worker2.Replace("'", "''") + "'" +
                "," + jlabD.Worker3 + "= '" + p.Worker3.Replace("'", "''") + "'" +
                "," + jlabD.Worker4 + "= '" + p.Worker4.Replace("'", "''") + "'" +
                "," + jlabD.LGID + "= '" + p.LGID.Replace("'", "''") + "'" +
                "," + jlabD.QTY + "= '" + p.QTY.Replace("'", "''") + "'" +
                "," + jlabD.row1 + "= '" + p.row1.Replace("'", "''") + "'" +
                "," + jlabD.status_show_qty + "= '" + p.status_show_qty.Replace("'", "''") + "'" +
                "";
            try
            {
                if (sql.IndexOf("SubItem= '0'") > 0)
                {
                    sql = sql.Replace("SubItem= '0'", "SubItem = null");
                }
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
            String sql = "Delete From  " + jlabD.table+" "+
                "Where "+ jlabD.pkField+"='"+id+"'";
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
        public DataTable selectByPk(String pttId)
        {
            DataTable dt = new DataTable();
            String sql = "select jlabD.* " +
                "From " + jlabD.table + " jlabD " +
                "Where jlabD." + jlabD.pkField + " ='" + pttId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByVN(String pttId)
        {
            DataTable dt = new DataTable();
            String sql = "select jlabD.* " +
                "From " + jlabD.table + " jlabD " +
                //"Left Join labItem li on jlabD.LID = li.LID " +
                "Where jlabD." + jlabD.VN + " ='" + pttId + "' and jlabD.active = '1'" +
                "Order By jlabD." + jlabD.LID;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectBillExtra0ByVN(String pttId)
        {
            DataTable dt = new DataTable();
            String sql = "select jlabD.* " +
                "From " + jlabD.table + " jlabD " +
                //"Left Join labItem li on jlabD.LID = li.LID " +
                "Where jlabD." + jlabD.VN + " ='" + pttId + "' and Extra='0' and SubItem is null " +
                "Order By jlabD." + jlabD.LID;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectBillExtra1ByVN(String pttId)
        {
            DataTable dt = new DataTable();
            String sql = "select jlabD.* " +
                "From " + jlabD.table + " jlabD " +
                //"Left Join labItem li on jlabD.LID = li.LID " +
                "Where jlabD." + jlabD.VN + " ='" + pttId + "' and Extra='1' and SubItem is null " +
                "Order By jlabD." + jlabD.LID;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public String selectSumIncludePriceByVN(String copId)
        {
            String re = "0";
            DataTable dt = new DataTable();
            String sql = "select sum(jlabD." + jlabD.Price + ") as Include_Pkg_Price " +
                "From " + jlabD.table + " jlabD " +
                "Where jlabD." + jlabD.VN + " ='" + copId + "' and Extra='0' "
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
            String sql = "select sum(jlabD." + jlabD.Price + ") as Extra_Pkg_Price " +
                "From " + jlabD.table + " jlabD " +
                "Where jlabD." + jlabD.VN + " ='" + copId + "' and Extra='1' "
                ;
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                re = dt.Rows[0]["Extra_Pkg_Price"] != null ? dt.Rows[0]["Extra_Pkg_Price"].ToString() : "0";
            }
            return re;
        }
        public String selectByStatusSememAnalysis(String vn)
        {
            String re = "";
            DataTable dt = new DataTable();
            String sql = "Select jlabD.ID  " +
                "From " + jlabD.table + " jlabD " +
                "Where jlabD." + jlabD.Status + " ='1' and jlabD.LID in (14) " +
                "and jlabD.VN ='" + vn + "' " +
                "Order By jlabD.ID";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                re = dt.Rows[0]["ID"].ToString();
            }
            return re;
        }
        public String selectByStatusSememFreezing(String vn)
        {
            String re = "";
            DataTable dt = new DataTable();
            String sql = "Select jlabD.ID  " +
                "From " + jlabD.table + " jlabD " +
                "Where jlabD." + jlabD.Status + " ='1' and jlabD.LID in (18) " +
                "and jlabD.VN ='" + vn + "' " +
                "Order By jlabD.ID";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                re = dt.Rows[0]["ID"].ToString();
            }
            return re;
        }
        public String selectByStatusPesa(String vn)
        {
            String re = "";
            DataTable dt = new DataTable();
            String sql = "Select jlabD.ID  " +
                "From " + jlabD.table + " jlabD " +
                "Where jlabD." + jlabD.Status + " ='1' and jlabD.LID in (66) " +
                "and jlabD.VN ='" + vn + "' " +
                "Order By jlabD.ID";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                re = dt.Rows[0]["ID"].ToString();
            }
            return re;
        }
    }
}
