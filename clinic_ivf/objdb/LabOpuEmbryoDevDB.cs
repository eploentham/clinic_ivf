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

            p.day = p.day == null ? "0" : p.day;
            p.desc0 = p.desc0 == null ? "" : p.desc0;
            p.active = p.active == null ? "" : p.active;
            p.remark = p.remark == null ? "" : p.remark;
            p.path_pic = p.path_pic == null ? "" : p.path_pic;
            p.desc1 = p.desc1 == null ? "" : p.desc1;
            p.desc2 = p.desc2 == null ? "" : p.desc2;
            p.desc3 = p.desc3 == null ? "" : p.desc3;
            
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
            sql = "Insert Into " + opuEmDev.table + "(" + opuEmDev.opu_fet_id + "," + opuEmDev.day + "," + opuEmDev.opu_embryo_dev_no + "," +
                opuEmDev.desc0 + "," + opuEmDev.active + "," + opuEmDev.remark + "," +
                opuEmDev.path_pic + "," + opuEmDev.date_create + "," + opuEmDev.user_create + "," +
                opuEmDev.desc1 + "," + opuEmDev.desc2 + "," + opuEmDev.desc3 + "," +
                opuEmDev.staff_id + " " +

                ") " +
                "Values ('" + p.opu_fet_id + "','" + p.day + "','" + p.opu_embryo_dev_no + "'," +
                "'" + p.desc0.Replace("'", "''") + "','" + p.active.Replace("'", "''") + "','" + p.remark + "'," +
                "'" + p.path_pic + "',now(),'" + userId + "'," +
                "'" + p.desc1 + "','" + p.desc2 + "','" + p.desc3 + "'," +
                "'" + p.staff_id + "' " +
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
                //"," + opuEmDev.posi_id + " = '" + p.status_module_lab.Replace("'", "''") + "' " +
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
        public String updatePathPic(String id, String pathpic, String desc3)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            sql = "Update " + opuEmDev.table + " Set " +
                " " + opuEmDev.path_pic + " = '" + pathpic + "'" +
                "," + opuEmDev.desc3 + " = '" + pathpic + "'" +
                "Where " + opuEmDev.pkField + "='" + desc3 + "'";
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
    }
}
