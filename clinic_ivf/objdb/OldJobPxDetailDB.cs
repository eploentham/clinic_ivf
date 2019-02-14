﻿using clinic_ivf.object1;
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

            oJpxd.table = "JobPxDetail";
            oJpxd.pkField = "ID";
        }
        private void chkNull(JobPxDetail p)
        {
            long chk = 0;
            decimal chk1 = 0;


            p.PIDS = p.PIDS == null ? "" : p.PIDS;
            p.DUName = p.DUName == null ? "" : p.DUName;
            p.Comment = p.Comment == null ? "" : p.Comment;
            p.TUsage = p.TUsage == null ? "" : p.TUsage;
            p.EUsage = p.EUsage == null ? "" : p.EUsage;

            p.ID = long.TryParse(p.ID, out chk) ? chk.ToString() : "0";
            p.VN = long.TryParse(p.VN, out chk) ? chk.ToString() : "0";
            p.DUID = long.TryParse(p.DUID, out chk) ? chk.ToString() : "0";
            p.QTY = long.TryParse(p.QTY, out chk) ? chk.ToString() : "0";
            p.Extra = long.TryParse(p.Extra, out chk) ? chk.ToString() : "0";
            p.Status = long.TryParse(p.Status, out chk) ? chk.ToString() : "0";
            p.PID = long.TryParse(p.PID, out chk) ? chk.ToString() : "0";
            //p.PIDS = long.TryParse(p.PIDS, out chk) ? chk.ToString() : "0";

            p.Price = decimal.TryParse(p.Price, out chk1) ? chk.ToString() : "0";
            //p.PIDS = decimal.TryParse(p.PIDS, out chk1) ? chk.ToString() : "0";
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
            String sql = "select sum(oJpxd."+oJpxd.Price+ ") as Include_Pkg_Price " +
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
            String sql = "select sum(oJpxd." + oJpxd.Price + ") as Extra_Pkg_Price " +
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
