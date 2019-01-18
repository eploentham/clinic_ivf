using clinic_ivf.object1;
using MySql.Data.MySqlClient;
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
            vsold.form_a_id = "form_a_id";

            vsold.table = "Visit";
            vsold.pkField = "VN";
        }
        private void chkNull(VisitOld p)
        {
            int chk = 0;
            Int64 chk1 = 0;

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
            p.PID = Int64.TryParse(p.PID, out chk1) ? chk1.ToString() : "0";
            p.VN = Int64.TryParse(p.VN, out chk1) ? chk1.ToString() : "0";
            p.VSID = int.TryParse(p.VSID, out chk) ? chk.ToString() : "0";
            p.form_a_id = int.TryParse(p.form_a_id, out chk) ? chk.ToString() : "0";
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
                vsold.IntLock + "," + vsold.VN + "," + vsold.VSID + " " +
                ") " +
                "Values ('" + p.PID + "','" + p.PIDS.Replace("'", "''") + "','" + p.PName + "'," +
                "'" + p.OName + "','" + p.VDate.Replace("'", "''") + "','" + p.VStartTime + "'," +
                "'" + p.VEndTime + "','" + p.VUpdateTime + "','" + p.LVSID + "'," +
                "'" + p.IntLock + "','" + p.VN + "','" + p.VSID + "' " +
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
                "," + vsold.VDate + " = '" + p.VDate + "' " +
                
                "Where " + vsold.pkField + "='" + p.VN + "'"
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
        public String updateVEndTimeNull(String vn)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            
            sql = "Update " + vsold.table + " Set " +
                " " + vsold.VEndTime + " = null " +
                "Where " + vsold.pkField + "='" + vn + "'";
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
        public String updateFormA(String vn, String formaid)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Update " + vsold.table + " Set " +
                " " + vsold.form_a_id + " = '"+ formaid + "' " +
                "Where " + vsold.pkField + "='" + vn + "'";
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

            if (p.VN.Equals(""))
            {
                p.VN = genVN();
                re = insert(p, userId);
                if (re.Equals("1"))
                {
                    re = p.VN;
                }
            }
            else
            {
                re = update(p, userId);
                if (re.Equals("1"))
                {
                    re = p.VN;
                }
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
        public VisitOld selectByPk1(String copId)
        {
            VisitOld cop1 = new VisitOld();
            DataTable dt = new DataTable();
            String sql = "select vsold.* " +
                "From " + vsold.table + " vsold " +
                "Where vsold." + vsold.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setVisitOld(dt);
            return cop1;
        }
        public DataTable selectLikeByHN(String hn, MySqlConnection con)
        {
            DataTable dt = new DataTable();
            //String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            String sql = "select vsold.VN as id,vsold.VN, vsold.PIDS, vsold.PName, vsold.VDate, vsold.VStartTime, vsold.VEndTime, VStatus.VName, vsold.VSID, Patient.DateOfBirth as dob " +
                "From " + vsold.table + " vsold " +
                "Left Join VStatus on  VStatus.VSID = vsold.VSID " +
                "Left Join Patient on  vsold.PID = Patient.PID  " +
                "Where vsold." + vsold.PIDS + " like ('%" + hn + "%') " +
                "Order By vsold.VN ";
            dt = conn.selectData(con, sql);

            return dt;
        }
        public DataTable selectByHN(String hn)
        {
            DataTable dt = new DataTable();
            //String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            String sql = "select vsold.VN as id,vsold.VN, vsold.PIDS, vsold.PName, vsold.VDate, vsold.VStartTime, vsold.VEndTime, VStatus.VName, vsold.VSID, Patient.DateOfBirth as dob " +
                ",vsold.form_a_id " +
                "From " + vsold.table + " vsold " +
                "Left Join VStatus on  VStatus.VSID = vsold.VSID " +
                "Left Join Patient on  vsold.PID = Patient.PID " +
                "Where vsold." + vsold.PIDS + " ='" + hn + "' " +
                "Order By vsold.VN ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectCurrentVisit()
        {
            DataTable dt = new DataTable();
            String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            String sql = "select vsold.VN as id,vsold.VN, vsold.PIDS, vsold.PName, vsold.VDate, vsold.VStartTime, vsold.VEndTime, VStatus.VName, vsold.VSID, Patient.DateOfBirth as dob " +
                ",vsold.form_a_id " +
                "From " + vsold.table + " vsold " +
                "Left Join VStatus on  VStatus.VSID = vsold.VSID " +
                "Left Join Patient on  vsold.PID = Patient.PID " +
                "Where vsold." + vsold.VDate + " ='"+ date + "' " +
                "Order By vsold.VDate, vsold.VStartTime";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectCurrentVisit(MySqlConnection con)
        {
            DataTable dt = new DataTable();
            String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            String sql = "select vsold.VN as id,vsold.VN, vsold.PIDS, vsold.PName, vsold.VDate, vsold.VStartTime, vsold.VEndTime, VStatus.VName, vsold.VSID, Patient.DateOfBirth as dob " +
                "From " + vsold.table + " vsold " +
                "Left Join VStatus on  VStatus.VSID = vsold.VSID " +
                "Left Join Patient on  vsold.PID = Patient.PID " +
                "Where vsold." + vsold.VDate + " ='" + date + "' " +
                "Order By vsold.VDate, vsold.VStartTime";
            dt = conn.selectData(con, sql);

            return dt;
        }
        public DataTable selectByStatusNurseWaiting()
        {
            DataTable dt = new DataTable();
            String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            String sql = "select vsold.VN as id,vsold.VN, vsold.PIDS, vsold.PName, vsold.VDate, vsold.VStartTime, vsold.VEndTime, VStatus.VName, vsold.VSID, vsold.PID, Patient.DateOfBirth as dob" +
                ",vsold.form_a_id  " +
                "From " + vsold.table + " vsold " +
                "Left Join VStatus on  VStatus.VSID = vsold.VSID " +
                "Left Join Patient on  vsold.PID = Patient.PID " +
                "Where vsold." + vsold.VDate + " ='" + date + "' and vsold.VSID = '110' " +
                "Order By vsold.VDate, vsold.VStartTime";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByDate(String date)
        {
            DataTable dt = new DataTable();
            //String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            String sql = "select vsold.VN as id,vsold.VN, vsold.PIDS, vsold.PName, vsold.VDate, vsold.VStartTime, vsold.VEndTime, VStatus.VName, vsold.VSID, vsold.PID, Patient.DateOfBirth as dob" +
                ",vsold.form_a_id " +
                "From " + vsold.table + " vsold " +
                "Left Join VStatus on  VStatus.VSID = vsold.VSID " +
                "Left Join Patient on  vsold.PID = Patient.PID " +
                "Where vsold." + vsold.VDate + " ='" + date + "' and vsold.VSID = '110' " +
                "Order By vsold.VDate, vsold.VStartTime";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByStatusNurseDiag()
        {
            DataTable dt = new DataTable();
            String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            String sql = "select vsold.VN as id,vsold.VN, vsold.PIDS, vsold.PName, vsold.VDate, vsold.VStartTime, vsold.VEndTime, VStatus.VName, vsold.VSID, vsold.PID, Patient.DateOfBirth as dob " +
                ",vsold.form_a_id " +
                "From " + vsold.table + " vsold " +
                "Left Join VStatus on  VStatus.VSID = vsold.VSID " +
                "Left Join Patient on  vsold.PID = Patient.PID " +
                "Where vsold." + vsold.VDate + " ='" + date + "' and vsold.VSID in ('115','144','135','112','113','114') " +
                "Order By vsold.VDate, vsold.VStartTime";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByStatusNurseFinish()
        {
            DataTable dt = new DataTable();
            String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            String sql = "select vsold.VN as id,vsold.VN, vsold.PIDS, vsold.PName, vsold.VDate, vsold.VStartTime, vsold.VEndTime, VStatus.VName, vsold.VSID, vsold.PID, Patient.DateOfBirth as dob " +
                ",vsold.form_a_id " +
                "From " + vsold.table + " vsold " +
                "Left Join VStatus on  VStatus.VSID = vsold.VSID " +
                "Left Join Patient on  vsold.PID = Patient.PID " +
                "Where vsold." + vsold.VDate + " ='" + date + "' and vsold.VSID in ('999','166','165') " +
                "Order By vsold.VDate, vsold.VStartTime";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public String genVN()
        {
            DataTable dt = new DataTable();
            Int64 year = (DateTime.Now.Year * 1000);
            String sql = "select max(VN) as VN from Visit ";
            Int64 max = 0, vn=0;
            
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                Int64.TryParse(dt.Rows[0]["VN"].ToString(), out max);
            }
            if (max > year)
            {
                vn = max + 1;
            }
            else
            {
                vn += year;
            }
            return vn.ToString();
        }
        public VisitOld setVisitOld(DataTable dt)
        {
            VisitOld vsold1 = new VisitOld();
            if (dt.Rows.Count > 0)
            {
                vsold1.VN = dt.Rows[0][vsold.VN].ToString();
                vsold1.VSID = dt.Rows[0][vsold.VSID].ToString();
                vsold1.PID = dt.Rows[0][vsold.PID].ToString();
                vsold1.PIDS = dt.Rows[0][vsold.PIDS].ToString();
                vsold1.PName = dt.Rows[0][vsold.PName].ToString();
                vsold1.OName = dt.Rows[0][vsold.OName].ToString();
                vsold1.VDate = dt.Rows[0][vsold.VDate].ToString();
                vsold1.VStartTime = dt.Rows[0][vsold.VStartTime].ToString();
                vsold1.VEndTime = dt.Rows[0][vsold.VEndTime].ToString();
                vsold1.VUpdateTime = dt.Rows[0][vsold.VUpdateTime].ToString();
                vsold1.LVSID = dt.Rows[0][vsold.LVSID].ToString();
                vsold1.IntLock = dt.Rows[0][vsold.IntLock].ToString();
                vsold1.form_a_id = dt.Rows[0][vsold.form_a_id].ToString();
            }
            else
            {
                setVisitOld1(vsold1);
            }
            return vsold1;
        }
        private VisitOld setVisitOld1(VisitOld stf1)
        {
            stf1.VN = "";
            stf1.VSID = "";
            stf1.PID = "";
            stf1.PIDS = "";
            stf1.PName = "";
            stf1.OName = "";
            stf1.VDate = "";
            stf1.VStartTime = "";
            stf1.VEndTime = "";
            stf1.VUpdateTime = "";
            stf1.LVSID = "";
            stf1.IntLock = "";
            stf1.form_a_id = "";
            return stf1;
        }
    }
}
