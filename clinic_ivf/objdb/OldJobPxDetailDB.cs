using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    /*
     * 63-10-27     0020    เรื่อง		เลิก insert table Visit
     * 63-10-23     0021    ให้เริ่ม HN ใหม่ แต่ให้ใช้ข้อมูลเก่า
     */
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
            oJpxd.row1 = "row1";
            oJpxd.price1 = "price1";
            oJpxd.pckdid = "pckdid";
            oJpxd.status_print = "status_print";
            oJpxd.status_up_stock = "status_up_stock";
            oJpxd.pharmacy_finish_date_time = "pharmacy_finish_date_time";

            oJpxd.table = "JobPxDetail";
            oJpxd.pkField = "ID";
        }
        private void chkNull(OldJobPxDetail p)
        {
            long chk = 0;
            decimal chk1 = 0;

            p.PIDS = p.PIDS == null ? "" : p.PIDS;
            p.DUName = p.DUName == null ? "" : p.DUName;
            p.Comment = p.Comment == null ? "NULL" : p.Comment;
            p.TUsage = p.TUsage == null ? "" : p.TUsage;
            p.EUsage = p.EUsage == null ? "" : p.EUsage;
            p.Comment = p.Comment.Equals("")? "NULL" : p.Comment;
            p.status_print = p.status_print == null ? "0" : p.status_print;
            p.status_up_stock = p.status_up_stock == null ? "0" : p.status_up_stock;

            p.ID = long.TryParse(p.ID, out chk) ? chk.ToString() : "0";
            p.VN = long.TryParse(p.VN, out chk) ? chk.ToString() : "0";
            p.DUID = long.TryParse(p.DUID, out chk) ? chk.ToString() : "0";
            p.QTY = long.TryParse(p.QTY.Replace(".00",""), out chk) ? chk.ToString() : "0";
            p.Extra = long.TryParse(p.Extra, out chk) ? chk.ToString() : "0";
            p.Status = long.TryParse(p.Status, out chk) ? chk.ToString() : "0";
            p.PID = long.TryParse(p.PID, out chk) ? chk.ToString() : "0";
            p.row1 = long.TryParse(p.row1, out chk) ? chk.ToString() : "0";
            p.pckdid = long.TryParse(p.pckdid, out chk) ? chk.ToString() : "0";

            p.Price = decimal.TryParse(p.Price, out chk1) ? chk1.ToString() : "0";
            p.price1 = decimal.TryParse(p.price1, out chk1) ? chk1.ToString() : "0";
        }
        public String insert(OldJobPxDetail p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            //lbReq.form_a_id = "form_a_id";
            //p.req_code = genReqDoc();
            sql = "Insert Into " + oJpxd.table + " Set " +
                " " + oJpxd.VN + " = '" + p.VN + "'" +
                "," + oJpxd.DUID + "= '" + p.DUID + "'" +
                "," + oJpxd.QTY + "= '" + p.QTY + "'" +
                "," + oJpxd.Extra + "= '" + p.Extra.Replace("'", "''") + "'" +
                "," + oJpxd.Price + "= '" + p.Price.Replace("'", "''") + "'" +
                "," + oJpxd.Status + "= '" + p.Status + "'" +
                "," + oJpxd.PID + "= '" + p.PID + "'" +
                "," + oJpxd.PIDS + "= '" + p.PIDS + "'" +
                "," + oJpxd.DUName + "= '" + p.DUName.Replace("'", "''") + "'" +
                "," + oJpxd.Comment + "= '" + p.Comment.Replace("'", "''") + "'" +
                "," + oJpxd.TUsage + "= '" + p.TUsage.Replace("'", "''") + "'" +
                "," + oJpxd.EUsage + "= '" + p.EUsage.Replace("'", "''") + "'" +
                "," + oJpxd.row1 + "= '" + p.row1 + "'" +
                "," + oJpxd.price1 + "= '" + p.price1 + "'" +
                "," + oJpxd.pckdid + "= '" + p.pckdid + "'" +
                "," + oJpxd.status_print + "= '" + p.status_print + "'" +
                "," + oJpxd.status_up_stock + "= '" + p.status_up_stock + "'" +
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
            String sql = "Delete From  " + oJpxd.table + " " +
                "Where " + oJpxd.pkField + "='" + id + "'";
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
        public String deleteByPkgsId(String pkgsid)
        {
            DataTable dt = new DataTable();
            String re = "";
            String sql = "Delete From  " + oJpxd.table + " " +
                "Where " + oJpxd.pckdid + "='" + pkgsid + "'";
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
        public String updateStatusUpStockOKByVN(String vn)
        {
            DataTable dt = new DataTable();
            String re = "";
            String sql = "Update " + oJpxd.table + " " +
                "Set " + oJpxd.status_up_stock + " = '1' " +
                "Where " + oJpxd.VN + "='" + vn + "'";
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
        public String updateStatusUpStockOKByID(String pxdid)
        {
            DataTable dt = new DataTable();
            String re = "";
            String sql = "Update " + oJpxd.table + " " +
                "Set " + oJpxd.status_up_stock + " = '1' " +
                "Where " + oJpxd.ID + "='" + pxdid + "'";
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
        public String updateStatusFinishByVN(String vn)
        {
            DataTable dt = new DataTable();
            String re = "";
            String sql = "Update " + oJpxd.table + " " +
                "Set " + oJpxd.pharmacy_finish_date_time + " = now() " +
                "Where " + oJpxd.VN + "='" + vn + "'";
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
        public String updateStatusPrintOKByVN(String vn)
        {
            DataTable dt = new DataTable();
            String re = "";
            String sql = "Update " + oJpxd.table + " " +
                "Set " + oJpxd.status_print+" = '1' " +
                oJpxd.pharmacy_sticker_date_time + " = now() " +
                "Where " + oJpxd.VN + "='" + vn + "'";
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
        public String updateStatusPrintOKByID(String pxdid)
        {
            DataTable dt = new DataTable();
            String re = "";
            String sql = "Update " + oJpxd.table + " " +
                "Set " + oJpxd.status_print + " = '1' " +
                oJpxd.pharmacy_sticker_date_time + " = now() " +
                "Where " + oJpxd.ID + "='" + pxdid + "'";
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
        public String updateUsageEByID(String pxdid, String usage)
        {
            DataTable dt = new DataTable();
            String re = "";
            String sql = "Update " + oJpxd.table + " " +
                "Set " + oJpxd.EUsage + " = '"+usage.Replace("'","''")+"' " +
                "Where " + oJpxd.ID + "='" + pxdid + "'";
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
        public String updateUsageTByID(String pxdid, String usage)
        {
            DataTable dt = new DataTable();
            String re = "";
            String sql = "Update " + oJpxd.table + " " +
                "Set " + oJpxd.TUsage + " = '" + usage.Replace("'", "''") + "' " +
                "Where " + oJpxd.ID + "='" + pxdid + "'";
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
            String sql = "select oJpxd.* " +
                "From " + oJpxd.table + " oJpxd " +
                "Where oJpxd." + oJpxd.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectExtra1ByVN(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select oJpxd.* " +
                "From " + oJpxd.table + " oJpxd " +
                "Where oJpxd." + oJpxd.VN + " ='" + copId + "' and Extra='1' " +
                "Order By oJpxd." + oJpxd.DUName;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectExtra0ByVN(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select oJpxd.* " +
                "From " + oJpxd.table + " oJpxd " +
                "Where oJpxd." + oJpxd.VN + " ='" + copId + "' and Extra='0' " +
                "Order By oJpxd." + oJpxd.DUName;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByPID(String pid)
        {
            DataTable dt = new DataTable();
            String sql = "select oJpxd.*,vs.visit_begin_visit_time " +
                "From " + oJpxd.table + " oJpxd " +
                "Left Join t_visit vs on oJpxd.VN = vs.visit_vn " +
                "Where oJpxd." + oJpxd.PID + " ='" + pid + "' " +
                "Order By oJpxd." + oJpxd.DUName;
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
        public DataTable selectSumQtyByVN(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select oJpxd.DUID,oJpxd.ID,oJpxd.DUName,oJpxd.Price,sum(oJpxd.QTY) as QTY,oJpxd.TUsage,oJpxd.EUsage,oJpxd.Extra,oJpxd.row1 " +
                "From " + oJpxd.table + " oJpxd " +
                "Where oJpxd." + oJpxd.VN + " ='" + copId + "' " +
                //"Group By oJpxd.DUID " +
                "Group By oJpxd.DUID ,oJpxd.ID,oJpxd.DUName,oJpxd.Price,oJpxd.TUsage,oJpxd.EUsage,oJpxd.Extra,oJpxd.row1 "+
                "Order By oJpxd." + oJpxd.DUName;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByDate(String startdate, String endate)
        {
            DataTable dt = new DataTable();
            String sql = "select oJpxd.DUID,oJpxd.ID,oJpxd.DUName,oJpxd.Price,sum(oJpxd.QTY) as QTY,oJpxd.TUsage,oJpxd.EUsage,oJpxd.Extra,oJpxd.row1, ptt.patient_name,JobPx.Date, JobPx.PIDS,oJpxd.Status, oJpxd.pharmacy_finish_date_time, ptt.patient_year " +
                "From " + oJpxd.table + " oJpxd " +
                "inner join JobPx on JobPx.VN = oJpxd.VN " +
                "inner join t_patient ptt on JobPx.PID = ptt.t_patient_id " +
                "inner join t_visit vs on JobPx.VN = vs.visit_vn " +
                "Where JobPx.Date >='" + startdate + " 00:00:00' and JobPx.Date <='" + endate+ " 23:59:59' " +
                //"Group By oJpxd.DUID " +
                "Group By oJpxd.pharmacy_finish_date_time,ptt.patient_name, oJpxd.DUID ,oJpxd.ID,oJpxd.DUName,oJpxd.Price,oJpxd.TUsage,oJpxd.EUsage,oJpxd.Extra,oJpxd.row1,oJpxd.Status " +
                "Order By oJpxd.pharmacy_finish_date_time, oJpxd." + oJpxd.DUName;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByVN1FreqTH(String vn)
        {
            DataTable dt = new DataTable();
            String wherehn = "";
            //if (!vn.Equals(""))
            //{
            //    wherehn = " and jobpxD." + jobpxD.PIDS + " like '%" + vn + "%'";
            //}
            //String sql = "SELECT CONCAT(IFNULL(SurfixName.SurfixName,''),' ', ptt.PName,' ',ptt.PSurname) as patient_name, jobpxD.PIDS as hn, DATE_FORMAT(now(),''), jobpxD.TUsage as frequency " +
            //    ", jobpxD.DUName as drug_name, sum(jobpxD.QTY) as qty, jobpxD.DUID, JobPx.Date,StockDrug.UnitType as unit_name " +
            //    "From " + oJpxd.table + " jobpxD " +
            //    "left join JobPx on JobPx.VN = jobpxD.VN " +
            //    "left join Patient ptt on ptt.PIDS = JobPx.PIDS " +
            //    "left join SurfixName on SurfixName.SurfixID = ptt.SurfixID " +
            //    "left join StockDrug on StockDrug.DUID =  jobpxD.DUID " +
            //    "Where JobPx.VN = '" + vn + "' " +
            //    "group by patient_name,hn,frequency, jobpxD.DUName , jobpxD.DUID, JobPx.Date, unit_name  ";
            String sql = "SELECT ptt.patient_name, concat(jobpxD.PIDS,'/',ptt.patient_year) as hn, DATE_FORMAT(now(),''), jobpxD.TUsage as frequency " +
                ", jobpxD.DUName as drug_name, sum(jobpxD.QTY) as qty, jobpxD.DUID, JobPx.Date,StockDrug.UnitType as unit_name " +
                "From " + oJpxd.table + " jobpxD " +
                "left join JobPx on JobPx.VN = jobpxD.VN " +
                //"left join Patient ptt on ptt.PIDS = JobPx.PIDS " +
                //"left join Patient ptt on ptt.t_patient_id = JobPx.PID " +        //-0020
                "left join t_patient ptt on ptt.t_patient_id = JobPx.PID " +          //+0020
                //"left join SurfixName on SurfixName.SurfixID = ptt.SurfixID " +
                "left join StockDrug on StockDrug.DUID =  jobpxD.DUID " +
                "Where JobPx.VN = '" + vn + "' " +
                "group by patient_name,hn,frequency, jobpxD.DUName , jobpxD.DUID, JobPx.Date, unit_name  ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByVN1FreqEN(String vn)
        {
            DataTable dt = new DataTable();
            String wherehn = "";
            //if (!vn.Equals(""))
            //{
            //    wherehn = " and jobpxD." + jobpxD.PIDS + " like '%" + vn + "%'";
            //}
            //String sql = "SELECT CONCAT(IFNULL(SurfixName.SurfixName,''),' ', ptt.PName,' ',ptt.PSurname) as patient_name, jobpxD.PIDS as hn, DATE_FORMAT(now(),''), jobpxD.EUsage as frequency " +
            //    ", jobpxD.DUName as drug_name, sum(jobpxD.QTY) as qty, jobpxD.DUID, JobPx.Date,StockDrug.UnitType as unit_name " +
            //    "From " + oJpxd.table + " jobpxD " +
            //    "left join JobPx on JobPx.VN = jobpxD.VN " +
            //    "left join Patient ptt on ptt.PIDS = JobPx.PIDS " +
            //    "left join SurfixName on SurfixName.SurfixID = ptt.SurfixID " +
            //    "left join StockDrug on StockDrug.DUID =  jobpxD.DUID " +
            //    "Where JobPx.VN = '" + vn + "' " +
            //    "group by jobpxD.DUName ";
            String sql = "SELECT ptt.patient_name, concat(jobpxD.PIDS,'/',ptt.patient_year) as hn, DATE_FORMAT(now(),''), jobpxD.EUsage as frequency " +
                ", jobpxD.DUName as drug_name, sum(jobpxD.QTY) as qty, jobpxD.DUID, JobPx.Date,StockDrug.UnitType as unit_name " +
                "From " + oJpxd.table + " jobpxD " +
                "left join JobPx on JobPx.VN = jobpxD.VN " +
                //"left join Patient ptt on ptt.PIDS = JobPx.PIDS " +
                "left join t_patient ptt on ptt.t_patient_id = JobPx.PID " +
                //"left join SurfixName on SurfixName.SurfixID = ptt.SurfixID " +
                "left join StockDrug on StockDrug.DUID =  jobpxD.DUID " +
                "Where JobPx.VN = '" + vn + "' " +
                "group by patient_name,hn,frequency, jobpxD.DUName , jobpxD.DUID, JobPx.Date, unit_name  ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectBypxidFreqTH(String pxdid)
        {
            DataTable dt = new DataTable();
            String wherehn = "";
            //if (!vn.Equals(""))
            //{
            //    wherehn = " and jobpxD." + jobpxD.PIDS + " like '%" + vn + "%'";
            //}
            //String sql = "SELECT CONCAT(IFNULL(SurfixName.SurfixName,''),' ', ptt.PName,' ',ptt.PSurname) as patient_name, jobpxD.PIDS as hn, DATE_FORMAT(now(),''), jobpxD.TUsage as frequency " +   //-0020
            String sql = "SELECT ptt.patient_name, jobpxD.PIDS as hn, DATE_FORMAT(now(),''), jobpxD.TUsage as frequency " +     //+0020
                ", jobpxD.DUName as drug_name, jobpxD.QTY as qty, jobpxD.DUID, JobPx.Date,StockDrug.UnitType as unit_name " +
                "From " + oJpxd.table + " jobpxD " +
                "left join JobPx on JobPx.VN = jobpxD.VN " +
                //"left join Patient ptt on ptt.PIDS = JobPx.PIDS " +       //-0020
                "left join t_patient ptt on ptt.t_patient_id = JobPx.PID " +         //+0020
                //"left join SurfixName on SurfixName.SurfixID = ptt.SurfixID " +
                "left join StockDrug on StockDrug.DUID =  jobpxD.DUID " +
                "Where jobpxD.ID in (" + pxdid + ") ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectBypxidFreqEN(String pxdid)
        {
            DataTable dt = new DataTable();
            String wherehn = "";
            //if (!vn.Equals(""))
            //{
            //    wherehn = " and jobpxD." + jobpxD.PIDS + " like '%" + vn + "%'";
            //}
            String sql = "SELECT ptt.patient_name, jobpxD.PIDS as hn, DATE_FORMAT(now(),''), jobpxD.EUsage as frequency " +
                ", jobpxD.DUName as drug_name, jobpxD.QTY as qty, jobpxD.DUID, JobPx.Date,StockDrug.UnitType as unit_name " +
                "From " + oJpxd.table + " jobpxD " +
                "left join JobPx on JobPx.VN = jobpxD.VN " +
                //"left join Patient ptt on ptt.PIDS = JobPx.PIDS " +           //-0020
                "left join t_patient ptt on ptt.PID = JobPx.PID " +             //+0020
                //"left join SurfixName on SurfixName.SurfixID = ptt.SurfixID " +       //-0020
                "left join StockDrug on StockDrug.DUID =  jobpxD.DUID " +
                "Where jobpxD.ID in (" + pxdid + ") ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByVN2(String vn)
        {
            DataTable dt = new DataTable();
            String wherehn = "";
            //if (!vn.Equals(""))
            //{
            //    wherehn = " and jobpxD." + jobpxD.PIDS + " like '%" + vn + "%'";
            //}
            String sql = "SELECT CONCAT(IFNULL(SurfixName.SurfixName,''),' ', ptt.PName,' ',ptt.PSurname) as patient_name, jobpxD.PIDS as hn, DATE_FORMAT(now(),''), jobpxD.TUsage as frequency " +
                ", jobpxD.DUName as drug_name, jobpxD.QTY as qty, jobpxD.DUID, JobPx.Date,StockDrug.DUName as unitname " +
                "From " + oJpxd.table + " jobpxD " +
                "left join JobPx on JobPx.VN = jobpxD.VN " +
                //"left join Patient ptt on ptt.PIDS = JobPx.PIDS " +                   //-0020
                "left join t_patient ptt on ptt.PID = JobPx.PID " +
                //"left join SurfixName on SurfixName.SurfixID = ptt.SurfixID " +       //-0020
                "left join StockDrug on StockDrug.DUID =  jobpxD.DUID " +
                "Where JobPx.VN = '" + vn + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public String selectSumIncludePriceByVN(String vn)
        {
            String re = "0";
            DataTable dt = new DataTable();
            String sql = "select sum(oJpxd."+oJpxd.Price + "*" + oJpxd.QTY + ") as Include_Pkg_Price " +
                "From " + oJpxd.table + " oJpxd " +
                "Where oJpxd." + oJpxd.VN + " ='" + vn + "' and Extra='0' " 
                ;
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                re = dt.Rows[0]["Include_Pkg_Price"] != null ? dt.Rows[0]["Include_Pkg_Price"].ToString() : "0";
            }
            return re;
        }
        public String selectSumIncludePriceCashierOldProgramByVN(String copId)
        {
            String re = "0";
            DataTable dt = new DataTable();
            String sql = "select sum(oJpxd." + oJpxd.Price + ") as Include_Pkg_Price " +
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
        public String selectSumExtraPriceByVN(String vn)
        {
            String re = "0";
            DataTable dt = new DataTable();
            String sql = "select sum(oJpxd." + oJpxd.Price + "*" + oJpxd.QTY + ") as Extra_Pkg_Price " +
                "From " + oJpxd.table + " oJpxd " +
                "Where oJpxd." + oJpxd.VN + " ='" + vn + "' and Extra='1' "
                ;
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                re = dt.Rows[0]["Extra_Pkg_Price"] != null ? dt.Rows[0]["Extra_Pkg_Price"].ToString() : "0";
            }
            return re;
        }
        public String selectSumExtraPriceCashierOldProgramByVN(String copId)
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
