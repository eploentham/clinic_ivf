﻿using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class OldJobLabDB
    {
        public OldJobLab ojlab;
        ConnectDB conn;

        public OldJobLabDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            ojlab = new OldJobLab();
            
            ojlab.VN = "VN";
            ojlab.Status = "Status";
            ojlab.Include_Pkg_Price = "Include_Pkg_Price";
            ojlab.Extra_Pkg_Price = "Extra_Pkg_Price";
            ojlab.Total_Price = "Total_Price";
            ojlab.Date = "Date";
            ojlab.PID = "PID";
            ojlab.PIDS = "PIDS";

            ojlab.table = "JobLab";
            ojlab.pkField = "VN";
        }
        public String updateIncludePriceFormDetail(String inprice, String exprice, String vn)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            Decimal inprice1 = 0, exprice1 = 0, total = 0; ;
            Decimal.TryParse(inprice, out inprice1);
            Decimal.TryParse(exprice, out exprice1);
            total = inprice1 + exprice1;
            sql = "Update " + ojlab.table + " Set " +
                " " + ojlab.Include_Pkg_Price + " = '" + inprice1 + "'" +
                "," + ojlab.Extra_Pkg_Price + " = '" + exprice1 + "'" +
                "," + ojlab.Total_Price + " = '" + total + "'" +
                //"," + ojlab.Status + " = '2'" +
                "Where " + ojlab.VN + "='" + vn + "'"
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
        public String updateStatusCloseJobLab(String vn)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Update " + ojlab.table + " Set " +
                " " + ojlab.Status + " = '999'" +
                "Where " + ojlab.VN + "='" + vn + "'"
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
        
        public String setJobLab(String vn, String hn, String pid)
        {
        //    $query = $this->db->query('select VN from JobLab Where VN="'. $VN. '"');
        //  $date = date("Y-m-d", time());
        //    if ($query->num_rows() == 0) {
        //    $PID = $this->session->userdata['PID'];
        //    $PIDS = $this->session->userdata['PIDS'];
        //    $this->db->query('insert into JobLab set VN="'. $VN. '", Status="114", date="'. $date. '", PID="'. $PID. '", PIDS="'. $PIDS. '"');
        //        return 1;
        //    } else {
        //        return 0;
        //    };
            DataTable dt = new DataTable();
            String re = "", sql = "";
            sql = "select " + ojlab.VN + " from " + ojlab.table + " Where " + ojlab.VN + "='" + vn + "'";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count <= 0)
            {
                sql = "insert into " + ojlab.table + " set VN='" + vn + "'" +
                    ", Status='114'" +
                    ", date=date(now()) " +
                    ", PID='" + pid + "'" +
                    ", PIDS='" + hn + "' ";
                try
                {
                    re = conn.ExecuteNonQuery(conn.conn, sql);
                }
                catch (Exception ex)
                {
                    sql = ex.Message + " " + ex.InnerException;
                }
            }

            return re;
        }
    }
}
