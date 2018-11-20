using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class OldJobSpecialDB
    {
        public OldJobSpecial oJS;
        ConnectDB conn;
        public OldJobSpecialDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            oJS = new OldJobSpecial();
            oJS.VN = "VN";            
            oJS.Status = "Status";
            oJS.Include_Pkg_Price = "Include_Pkg_Price";
            oJS.Extra_Pkg_Price = "Extra_Pkg_Price";
            oJS.Total_Price = "Total_Price";
            oJS.Date = "Date";
            oJS.PID = "PID";
            oJS.PIDS = "PIDS";            

            oJS.table = "JobSpecial";
            oJS.pkField = "VN";
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select oJS.* " +
                "From " + oJS.table + " oJS " +
                "Where oJS." + oJS.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByStatusUnAccept1(String startdate, String enddate)
        {
            DataTable dt = new DataTable();
            String sql = "Select oJS.*, oJSd.SName, oJSd.SID, oJSd.ID, concat(SurfixName.SurfixName,' ',ptt.PName,' ',ptt.PSurname) as pttname  " +
                "From " + oJS.table + " oJS " +
                "Left Join JobSpecialDetail oJSd on oJS.Vn = oJSd.Vn " +
                "Left Join Patient ptt on ptt.PID = oJS.PID " +
                "Left Join SurfixName on SurfixName.SurfixID = ptt.SurfixID " +
                "Where oJS." + oJS.Status + " ='1' and oJSd.SID=112 " +
                "and oJS.Date >= '"+startdate+ "' and oJS.Date <='"+enddate+"'";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public OldJobSpecial selectByPk1(String copId)
        {
            OldJobSpecial cop1 = new OldJobSpecial();
            DataTable dt = new DataTable();
            String sql = "select oJS.* " +
                "From " + oJS.table + " oJS " +
                "Where oJS." + oJS.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setVisitOld(dt);
            return cop1;
        }
        public OldJobSpecial setVisitOld(DataTable dt)
        {
            OldJobSpecial vsold1 = new OldJobSpecial();
            if (dt.Rows.Count > 0)
            {
                vsold1.VN = dt.Rows[0][oJS.VN].ToString();
                vsold1.Status = dt.Rows[0][oJS.Status].ToString();
                vsold1.Include_Pkg_Price = dt.Rows[0][oJS.Include_Pkg_Price].ToString();
                vsold1.Extra_Pkg_Price = dt.Rows[0][oJS.Extra_Pkg_Price].ToString();
                vsold1.Total_Price = dt.Rows[0][oJS.Total_Price].ToString();
                vsold1.Date = dt.Rows[0][oJS.Date].ToString();
                vsold1.PID = dt.Rows[0][oJS.PID].ToString();
                vsold1.PIDS = dt.Rows[0][oJS.PIDS].ToString();
            }
            else
            {
                setVisitOld1(vsold1);
            }
            return vsold1;
        }
        private OldJobSpecial setVisitOld1(OldJobSpecial stf1)
        {
            stf1.VN = "";
            stf1.Status = "";
            stf1.Include_Pkg_Price = "";
            stf1.Extra_Pkg_Price = "";
            stf1.Total_Price = "";
            stf1.Date = "";
            stf1.PID = "";
            stf1.PIDS = "";

            return stf1;
        }
    }
}
