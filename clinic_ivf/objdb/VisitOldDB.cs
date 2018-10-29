using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class VisitOldDB
    {
        public VisitOld vsold;
        ConnectDB conn;

        public VisitOldDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            vsold = new VisitOld();
            vsold.VN = "VN";
            vsold.VSID = "VSID";
            vsold.PID = "PID";
            vsold.PIDS = "PIDS";
            vsold.PName = "PName";
            vsold.OName = "OName";
            vsold.VDate = "VDate";
            vsold.VStartTime = "VStartTime";
            vsold.VEndTime = "VEndTime";
            vsold.VUpdateTime = "VUpdateTime";
            vsold.LVSID = "LVSID";
            vsold.IntLock = "IntLock";

            vsold.table = "Visit";
            vsold.pkField = "VN";
        }
        private void chkNull(VisitOld p)
        {
            int chk = 0;

            //p.VN = p.VN == null ? "" : p.VN;
            //p.VSID = p.VSID == null ? "" : p.VSID;
            //p.PID = p.PID == null ? "" : p.PID;
            p.PIDS = p.PIDS == null ? "" : p.PIDS;
            p.PName = p.PName == null ? "" : p.PName;

            p.OName = p.OName == null ? "" : p.OName;
            p.VDate = p.VDate == null ? "" : p.VDate;
            p.VStartTime = p.VStartTime == null ? "" : p.VStartTime;
            p.VEndTime = p.VEndTime == null ? "" : p.VEndTime;
            p.VUpdateTime = p.VUpdateTime == null ? "" : p.VUpdateTime;
            //p.LVSID = p.LVSID == null ? "" : p.LVSID;
            //p.IntLock = p.IntLock == null ? "" : p.IntLock;

            p.IntLock = int.TryParse(p.IntLock, out chk) ? chk.ToString() : "0";
            p.LVSID = int.TryParse(p.LVSID, out chk) ? chk.ToString() : "0";
            //p.PIDS = int.TryParse(p.PIDS, out chk) ? chk.ToString() : "0";
            p.PID = int.TryParse(p.PID, out chk) ? chk.ToString() : "0";
            p.VN = int.TryParse(p.VN, out chk) ? chk.ToString() : "0";
            p.VSID = int.TryParse(p.VSID, out chk) ? chk.ToString() : "0";
        }
        public String insert(VisitOld p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            sql = "Insert Into " + vsold.table + "(" + vsold.PID + "," + vsold.PIDS + "," + vsold.PName + "," +
                vsold.OName + "," + vsold.VDate + "," + vsold.VStartTime + "," +
                vsold.VEndTime + "," + vsold.VUpdateTime + "," + vsold.LVSID + "," +
                vsold.IntLock + " " +
                ") " +
                "Values ('" + p.PID + "','" + p.PIDS.Replace("'", "''") + "','" + p.PName + "'," +
                "'" + p.OName + "','" + p.VDate.Replace("'", "''") + "','" + p.VStartTime + "'," +
                "'" + p.VEndTime + "','" + p.VUpdateTime + "','" + p.LVSID + "'," +
                "'" + p.IntLock + "' " +
                ")";
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
        public String update(VisitOld p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;


            chkNull(p);
            sql = "Update " + vsold.table + " Set " +
                " " + vsold.PName + " = '" + p.PName + "'" +
                "," + vsold.OName + " = '" + p.OName.Replace("'", "''") + "'" +
                "," + vsold.VDate + " = '" + p.VDate + "'" +
                
                "Where " + vsold.pkField + "='" + p.PID + "'"
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
        public String insertVisitOld(VisitOld p, String userId)
        {
            String re = "";

            if (p.PID.Equals(""))
            {
                re = insert(p, userId);
            }
            else
            {
                re = update(p, userId);
            }

            return re;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select vsold.* " +
                "From " + vsold.table + " vsold " +
                "Where vsold." + vsold.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectCurrentVisit()
        {
            DataTable dt = new DataTable();
            String sql = "select vsold.PIDS,vsold.VN, vsold.PName, vsold.VDate, vsold.VStartTime  " +
                "From " + vsold.table + " vsold " +
                " " +
                "Where vsold." + vsold.VSID + " <>'999' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
    }
}
