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
