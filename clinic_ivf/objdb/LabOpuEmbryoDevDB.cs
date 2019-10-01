using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class LabOpuEmbryoDevDB
    {
        public LabOpuEmbryoDev opuEmDev;
        ConnectDB conn;
        public List<LabOpuEmbryoDev> lStf;
        public enum Day1 { Day2, Day3, Day5, Day6}

        public LabOpuEmbryoDevDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            opuEmDev = new LabOpuEmbryoDev();
            opuEmDev.opu_embryo_dev_id = "opu_embryo_dev_id";
            opuEmDev.opu_fet_id = "opu_fet_id";
            opuEmDev.day = "day";
            opuEmDev.opu_embryo_dev_no = "opu_embryo_dev_no";
            opuEmDev.desc0 = "desc0";
            opuEmDev.active = "active";
            opuEmDev.remark = "remark";
            opuEmDev.path_pic = "path_pic";
            opuEmDev.date_create = "date_create";
            opuEmDev.date_modi = "date_modi";
            opuEmDev.date_cancel = "date_cancel";
            opuEmDev.user_create = "user_create";
            opuEmDev.user_modi = "user_modi";
            opuEmDev.user_cancel = "user_cancel";
            opuEmDev.desc1 = "desc1";
            opuEmDev.desc2 = "desc2";
            opuEmDev.desc3 = "desc3";
            opuEmDev.staff_id = "staff_id";
            opuEmDev.checked_id = "checked_id";
            opuEmDev.embryo_dev_date = "embryo_dev_date";
            opuEmDev.desc4 = "desc4";

            opuEmDev.table = "lab_t_opu_embryo_dev";
            opuEmDev.pkField = "opu_embryo_dev_id";

            lStf = new List<LabOpuEmbryoDev>();
        }
        private void chkNull(LabOpuEmbryoDev p)
        {
            long chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.opu_fet_id = long.TryParse(p.opu_fet_id, out chk) ? chk.ToString() : "0";
            p.opu_embryo_dev_no = long.TryParse(p.opu_embryo_dev_no, out chk) ? chk.ToString() : "0";
            p.staff_id = long.TryParse(p.staff_id, out chk) ? chk.ToString() : "0";
            p.checked_id = long.TryParse(p.checked_id, out chk) ? chk.ToString() : "0";

            p.day = p.day == null ? "0" : p.day;
            p.desc0 = p.desc0 == null ? "" : p.desc0;
            p.active = p.active == null ? "" : p.active;
            p.remark = p.remark == null ? "" : p.remark;
            p.path_pic = p.path_pic == null ? "" : p.path_pic;
            p.desc1 = p.desc1 == null ? "" : p.desc1;
            p.desc2 = p.desc2 == null ? "" : p.desc2;
            p.desc3 = p.desc3 == null ? "" : p.desc3;
            p.embryo_dev_date = p.embryo_dev_date == null ? "" : p.embryo_dev_date;
            p.desc4 = p.desc4 == null ? "" : p.desc4;

            //p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
        }
        public String insert(LabOpuEmbryoDev p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            //opuEmDev.desc0 = "desc0";
            sql = "Insert Into " + opuEmDev.table + " Set " + 
                " " + opuEmDev.opu_fet_id + "='"+ p.opu_fet_id + "'" +
                "," + opuEmDev.day + "='" + p.day + "'" +
                "," + opuEmDev.opu_embryo_dev_no + "='" + p.opu_embryo_dev_no + "'" +
                "," + opuEmDev.desc0 + "='" + p.desc0.Replace("'", "''") + "'" +
                "," + opuEmDev.active + "='" + p.active + "'" +
                "," + opuEmDev.remark + "='" + p.remark + "'" +
                "," + opuEmDev.path_pic + "='" + p.path_pic + "'" +
                "," + opuEmDev.date_create + "=now()" +
                "," + opuEmDev.user_create + "='" + userId + "'" +
                "," + opuEmDev.desc1 + "='" + p.desc1.Replace("'", "''") + "'" +
                "," + opuEmDev.desc2 + "='" + p.desc2.Replace("'", "''") + "'" +
                "," + opuEmDev.desc3 + "='" + p.desc3.Replace("'", "''") + "'" +
                "," + opuEmDev.staff_id + "='" + p.staff_id + "'" +
                "," + opuEmDev.checked_id + "='" + p.checked_id + "'" +
                "," + opuEmDev.embryo_dev_date + "='" + p.embryo_dev_date + "'" +
                "," + opuEmDev.desc4 + "='" + p.desc4.Replace("'", "''") + "'" +
                " " +
               
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
        public String update(LabOpuEmbryoDev p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + opuEmDev.table + " Set " +
                " " + opuEmDev.day + " = '" + p.day + "'" +
                "," + opuEmDev.opu_embryo_dev_no + " = '" + p.opu_embryo_dev_no.Replace("'", "''") + "'" +
                "," + opuEmDev.desc0 + " = '" + p.desc0 + "'" +
                "," + opuEmDev.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + opuEmDev.desc1 + " = '" + p.desc1.Replace("'", "''") + "'" +
                "," + opuEmDev.desc2 + " = '" + p.desc2.Replace("'", "''") + "'" +
                "," + opuEmDev.desc3 + " = '" + p.desc3.Replace("'", "''") + "'" +
                "," + opuEmDev.staff_id + " = '" + p.staff_id + "'" +
                "," + opuEmDev.checked_id + "='" + p.checked_id + "'" +
                "," + opuEmDev.embryo_dev_date + "='" + p.embryo_dev_date + "'" +
                "," + opuEmDev.desc4 + "='" + p.desc4.Replace("'", "''") + "'" +
                "Where " + opuEmDev.pkField + "='" + p.opu_embryo_dev_id + "'"
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
        public String insertLabOpuEmbryoDev(LabOpuEmbryoDev p, String userId)
        {
            String re = "";

            if (p.opu_embryo_dev_id.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
            }

            return re;
        }
        public String VoidLabOpuEmbryoDev(String id, String userid)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            sql = "Update " + opuEmDev.table + " Set " +
                " " + opuEmDev.active + " = '3'" +
                "," + opuEmDev.date_cancel + " = now()" +
                "," + opuEmDev.user_cancel + " = '"+ userid + "'" +
                "Where " + opuEmDev.pkField + "='" + id + "'";
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
        public String updateStff(String opufetid, String day, String staffid)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            sql = "Update " + opuEmDev.table + " Set " +
                " " + opuEmDev.staff_id + " = '" + staffid + "'" +
                "Where " + opuEmDev.opu_fet_id + "='" + opufetid + "' and "+opuEmDev.day + "='"+day+"'";
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
        public String updateChecked(String opufetid, String day, String checkedid)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            sql = "Update " + opuEmDev.table + " Set " +
                " " + opuEmDev.checked_id + " = '" + checkedid + "'" +
                "Where " + opuEmDev.opu_fet_id + "='" + opufetid + "' and " + opuEmDev.day + "='" + day + "'";
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
        public String updateDevDate(String opufetid, String day, String devdate)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            sql = "Update " + opuEmDev.table + " Set " +
                " " + opuEmDev.embryo_dev_date + " = '" + devdate + "'" +
                "Where " + opuEmDev.opu_fet_id + "='" + opufetid + "' and " + opuEmDev.day + "='" + day + "'";
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
        public String updatePathPic(String id, String num, String filename, String userid)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            sql = "Update " + opuEmDev.table + " Set " +                
                " " + opuEmDev.path_pic + " = '" + filename + "'" +
                //"," + opuEmDev.opu_embryo_dev_no + " = '" + num + "'" +
                "," + opuEmDev.user_modi + " = '" + userid + "'" +
                "," + opuEmDev.date_modi + " = now() " +
                "Where " + opuEmDev.pkField + "='" + id + "'";
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
        public String updatePathPic(String id, String num, String filename, String desc3, String userid)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            sql = "Update " + opuEmDev.table + " Set " +
                " " + opuEmDev.desc3 + " = '" + desc3 + "'" +
                "," + opuEmDev.path_pic + " = '" + filename + "'" +
                //"," + opuEmDev.opu_embryo_dev_no + " = '" + num + "'" +
                "," + opuEmDev.user_modi + " = '" + userid + "'" +
                "," + opuEmDev.date_modi + " = now() " +
                "Where " + opuEmDev.pkField + "='" + id + "'";
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
        public String updatePathPic(String id, String num, String filename, String desc3, String desc4, String userid)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            sql = "Update " + opuEmDev.table + " Set " +
                " " + opuEmDev.desc3 + " = '" + desc3.Replace("'", "''") + "'" +
                "," + opuEmDev.path_pic + " = '" + filename + "'" +
                "," + opuEmDev.desc4 + " = '" + desc4.Replace("'","''") + "'" +
                "," + opuEmDev.user_modi + " = '" + userid + "'" +
                "," + opuEmDev.date_modi + " = now() " +
                "Where " + opuEmDev.pkField + "='" + id + "'";
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
        public String updateNumDesc(String id, String num, String desc3, String userid)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            sql = "Update " + opuEmDev.table + " Set " +                
                " " + opuEmDev.desc3 + " = '" + desc3 + "'" +
                //"," + opuEmDev.opu_embryo_dev_no + " = '" + num + "'" +
                "," + opuEmDev.user_modi + " = '" + userid + "'" +
                "," + opuEmDev.date_modi + " = now() " +
                "Where " + opuEmDev.pkField + "='" + id + "'";
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
        public String selectCntByOpuFetId_Day(String opufetid, Day1 day1)
        {
            DataTable dt = new DataTable();
            String day = "", re="";
            if (day1 == Day1.Day2)
            {
                day = "2";
            }
            else if (day1 == Day1.Day3)
            {
                day = "3";
            }
            else if (day1 == Day1.Day5)
            {
                day = "5";
            }
            else if (day1 == Day1.Day6)
            {
                day = "6";
            }
            String sql = "select count(1) as cnt  " +
                "From " + opuEmDev.table + " opuEmDev " +
                " " +
                "Where opuEmDev." + opuEmDev.active + " ='1' and " + opuEmDev.opu_fet_id + "='" + opufetid + "' and " + opuEmDev.day + "='" + day + "' " +
                "Order By opuEmDev." + opuEmDev.opu_embryo_dev_id;

            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                re = dt.Rows[0]["cnt"].ToString();
            }
            return re;
        }
        public DataTable selectByOpuFetId_Day(String opufetid, Day1 day1, String no)
        {
            DataTable dt = new DataTable();
            String day = "";
            if (day1 == Day1.Day2)
            {
                day = "2";
            }
            else if (day1 == Day1.Day3)
            {
                day = "3";
            }
            else if (day1 == Day1.Day5)
            {
                day = "5";
            }
            else if (day1 == Day1.Day6)
            {
                day = "6";
            }
            String sql = "select opuEmDev.*  " +
                "From " + opuEmDev.table + " opuEmDev " +
                " " +
                "Where opuEmDev." + opuEmDev.active + " ='1' and " + opuEmDev.opu_fet_id + "='" + opufetid + "' and " + opuEmDev.day + "='" + day + "' and " + opuEmDev.opu_embryo_dev_no+"='" + no + "' " +
                "Order By opuEmDev." + opuEmDev.opu_embryo_dev_id;

            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByOpuFetId_Day(String opufetid, Day1 day1)
        {
            DataTable dt = new DataTable();
            String day = "";
            if(day1 == Day1.Day2)
            {
                day = "2";
            }
            else if (day1 == Day1.Day3)
            {
                day = "3";
            }
            else if (day1 == Day1.Day5)
            {
                day = "5";
            }
            else if (day1 == Day1.Day6)
            {
                day = "6";
            }
            String sql = "select opuEmDev.*  " +
                "From " + opuEmDev.table + " opuEmDev " +
                " " +
                "Where opuEmDev." + opuEmDev.active + " ='1' and "+ opuEmDev.opu_fet_id+"='"+opufetid+"' and "+ opuEmDev.day+"='"+day+"' " +
                "Order By opuEmDev." + opuEmDev.opu_embryo_dev_id;

            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByOpuFetId_DayPrint(String opufetid, Day1 day1)
        {
            DataTable dt = new DataTable();
            String day = "";
            if (day1 == Day1.Day2)
            {
                day = "2";
            }
            else if (day1 == Day1.Day3)
            {
                day = "3";
            }
            else if (day1 == Day1.Day5)
            {
                day = "5";
            }
            else if (day1 == Day1.Day6)
            {
                day = "6";
            }
            String sql = "select opu.hn_male, opu.hn_female, opu.name_male, opu.name_female, proce.proce_name_t as procedure1, dtr.Name as doctor, opuEmDev.embryo_dev_date as opu_date " +
                ", opuEmDev.day as day1, opuEmDev.opu_embryo_dev_no as no1, opuEmDev.desc0  as no1_desc0, opuEmDev.path_pic as no1_pathpic, opuEmDev.desc1 as no1_desc1" +
                ", opuEmDev.desc2 as no1_desc2, opuEmDev.desc3 as no1_desc3, opu.opu_id, opu.opu_code, 'Number of transfer' as footer1" +
                ", 'Number of Freeze' as footer2,'Number of Discard' as footer3, opu.remark as footer4,'' as footer5, 'st# = straw number' as footer6 " +
                ", opu.embryo_for_et_number_of_transfer, opu.embryo_for_et_number_of_freeze,opu.embryo_for_et_number_of_discard, opuEmDev.desc4 as no1_desc4  " +
                "From " + opuEmDev.table + " opuEmDev " +
                "Left Join lab_t_opu opu on opu.opu_id = opuEmDev.opu_fet_id " +
                "Left Join lab_b_procedure proce on proce.proce_id = opu.proce_id " +
                "Left Join Doctor dtr on dtr.ID = opu.doctor_id " +
                "Where opuEmDev." + opuEmDev.active + " ='1' and " + opuEmDev.opu_fet_id + "='" + opufetid + "' and " + opuEmDev.day + "='" + day + "' " +
                "and length(opuEmDev.path_pic) > 0 " +
                "Order By opuEmDev." + opuEmDev.opu_embryo_dev_id;

            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByFetFetId_DayPrint(String opufetid, Day1 day1)
        {
            DataTable dt = new DataTable();
            String day = "";
            if (day1 == Day1.Day2)
            {
                day = "2";
            }
            else if (day1 == Day1.Day3)
            {
                day = "3";
            }
            else if (day1 == Day1.Day5)
            {
                day = "5";
            }
            else if (day1 == Day1.Day6)
            {
                day = "6";
            }
            String sql = "select fet.hn_male, fet.hn_female, fet.name_male, fet.name_female, proce.proce_name_t as procedure1, dtr.Name as doctor, opuEmDev.embryo_dev_date as fet_date " +
                ", opuEmDev.day as day1, opuEmDev.opu_embryo_dev_no as no1, opuEmDev.desc0  as no1_desc0, opuEmDev.path_pic as no1_pathpic, opuEmDev.desc1 as no1_desc1" +
                ", opuEmDev.desc2 as no1_desc2, opuEmDev.desc3 as no1_desc3, fet.fet_id, fet.fet_code, 'Number of transfer' as footer1" +
                ", 'Number of Freeze' as footer2,'Number of Discard' as footer3, fet.remark as footer4,'' as footer5, 'st# = straw number' as footer6 " +
                ", fet.embryo_for_et_number_of_transfer, fet.embryo_for_et_number_of_freeze,fet.embryo_for_et_number_of_discard, opuEmDev.desc4 as no1_desc4  " +
                "From " + opuEmDev.table + " opuEmDev " +
                "Left Join lab_t_fet fet on fet.fet_id = opuEmDev.opu_fet_id " +
                "Left Join lab_b_procedure proce on proce.proce_id = fet.proce_id " +
                "Left Join Doctor dtr on dtr.ID = fet.doctor_id " +
                "Where opuEmDev." + opuEmDev.active + " ='1' and " + opuEmDev.opu_fet_id + "='" + opufetid + "' and " + opuEmDev.day + "='" + day + "' " +
                "and length(opuEmDev.path_pic) > 0 " +
                "Order By opuEmDev." + opuEmDev.opu_embryo_dev_id;

            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
    }
}
