﻿using clinic_ivf.object1;
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

            if (p.VN.Equals(""))
            {
                p.VN = genVN();
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
            String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            String sql = "select vsold.VN as id,vsold.VN, vsold.PIDS, vsold.PName, vsold.VDate, vsold.VStartTime, vsold.VEndTime, VStatus.VName, vsold.VSID " +
                "From " + vsold.table + " vsold " +
                "Left Join VStatus on  VStatus.VSID = vsold.VSID " +
                " " +
                "Where vsold." + vsold.VDate + " ='"+ date + "' ";
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

    }
}
