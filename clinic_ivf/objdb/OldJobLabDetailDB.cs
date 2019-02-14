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

            jlabD.table = "JobLabDetail";
            jlabD.pkField = "ID";
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
                "Where jlabD." + jlabD.VN + " ='" + pttId + "' and active = '1'" +
                "Order By jlabD." + jlabD.LID; ;
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
    }
}
