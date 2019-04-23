using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class EggStiDB
    {
        public EggSti eggs;
        ConnectDB conn;
        public List<EggSti> lStf;
        public enum Day1 { Day2, Day3, Day5, Day6 }

        public EggStiDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            eggs = new EggSti();
            eggs.egg_sti_id = "egg_sti_id";
            eggs.lmp_date = "lmp_date";
            eggs.nurse_t_egg_sticol = "nurse_t_egg_sticol";
            eggs.status_g = "status_g";
            eggs.p = "p";
            eggs.active = "active";
            eggs.remark = "remark";
            eggs.a = "a";
            eggs.date_create = "date_create";
            eggs.date_modi = "date_modi";
            eggs.date_cancel = "date_cancel";
            eggs.user_create = "user_create";
            eggs.user_modi = "user_modi";
            eggs.user_cancel = "user_cancel";
            eggs.g = "g";
            eggs.opu_date = "opu_date";
            eggs.opu_time = "opu_time";
            eggs.et = "et";
            eggs.fet = "fet";
            eggs.bhcg_test = "bhcg_test";

            eggs.table = "nurse_t_egg_sti";
            eggs.pkField = "egg_sti_id";

            lStf = new List<EggSti>();
        }
        private void chkNull(EggSti p)
        {
            long chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            //p.lmp_date = long.TryParse(p.lmp_date, out chk) ? chk.ToString() : "0";
            //p.status_g = long.TryParse(p.status_g, out chk) ? chk.ToString() : "0";
            //p.et = long.TryParse(p.et, out chk) ? chk.ToString() : "0";
            //p.fet = long.TryParse(p.fet, out chk) ? chk.ToString() : "0";

            p.nurse_t_egg_sticol = p.nurse_t_egg_sticol == null ? "0" : p.nurse_t_egg_sticol;
            p.p = p.p == null ? "" : p.p;
            p.active = p.active == null ? "" : p.active;
            p.remark = p.remark == null ? "" : p.remark;
            p.a = p.a == null ? "" : p.a;
            p.g = p.g == null ? "" : p.g;
            p.opu_date = p.opu_date == null ? "" : p.opu_date;
            p.opu_time = p.opu_time == null ? "" : p.opu_time;
            p.bhcg_test = p.bhcg_test == null ? "" : p.bhcg_test;
            p.lmp_date = p.lmp_date == null ? "" : p.lmp_date;
            p.status_g = p.status_g == null ? "" : p.status_g;
            p.et = p.et == null ? "" : p.et;
            p.fet = p.fet == null ? "" : p.fet;

            //p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
        }
        public String insert(EggSti p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            //opuEmDev.p = "p";
            sql = "Insert Into " + eggs.table + " Set " +
                " " + eggs.lmp_date + "='" + p.lmp_date + "'" +
                "," + eggs.nurse_t_egg_sticol + "='" + p.nurse_t_egg_sticol + "'" +
                "," + eggs.status_g + "='" + p.status_g + "'" +
                "," + eggs.p + "='" + p.p.Replace("'", "''") + "'" +
                "," + eggs.active + "='" + p.active + "'" +
                "," + eggs.remark + "='" + p.remark.Replace("'", "''") + "'" +
                "," + eggs.a + "='" + p.a + "'" +
                "," + eggs.date_create + "=now()" +
                "," + eggs.user_create + "='" + userId + "'" +
                "," + eggs.g + "='" + p.g.Replace("'", "''") + "'" +
                "," + eggs.opu_date + "='" + p.opu_date.Replace("'", "''") + "'" +
                "," + eggs.opu_time + "='" + p.opu_time.Replace("'", "''") + "'" +
                "," + eggs.et + "='" + p.et.Replace("'", "''") + "'" +
                "," + eggs.fet + "='" + p.fet.Replace("'", "''") + "'" +
                "," + eggs.bhcg_test + "='" + p.bhcg_test.Replace("'", "''") + "'" +
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
        public String update(EggSti p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + eggs.table + " Set " +
                " " + eggs.nurse_t_egg_sticol + " = '" + p.nurse_t_egg_sticol + "'" +
                "," + eggs.status_g + " = '" + p.status_g.Replace("'", "''") + "'" +
                "," + eggs.p + " = '" + p.p.Replace("'", "''") + "'" +
                "," + eggs.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + eggs.g + " = '" + p.g.Replace("'", "''") + "'" +
                "," + eggs.opu_date + " = '" + p.opu_date.Replace("'", "''") + "'" +
                "," + eggs.opu_time + " = '" + p.opu_time.Replace("'", "''") + "'" +
                "," + eggs.et + " = '" + p.et.Replace("'", "''") + "'" +
                "," + eggs.fet + "='" + p.fet.Replace("'", "''") + "'" +
                "," + eggs.bhcg_test + "='" + p.bhcg_test.Replace("'", "''") + "'" +
                "Where " + eggs.pkField + "='" + p.egg_sti_id + "'"
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
        public String insertLabOpuEmbryoDev(EggSti p, String userId)
        {
            String re = "";

            if (p.egg_sti_id.Equals(""))
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
            sql = "Update " + eggs.table + " Set " +
                " " + eggs.active + " = '3'" +
                "," + eggs.date_cancel + " = now()" +
                "," + eggs.user_cancel + " = '" + userid + "'" +
                "Where " + eggs.pkField + "='" + id + "'";
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
        public String updateStff(String opufetid, String nurse_t_egg_sticol, String staffid)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            sql = "Update " + eggs.table + " Set " +
                " " + eggs.et + " = '" + staffid + "'" +
                "Where " + eggs.lmp_date + "='" + opufetid + "' and " + eggs.nurse_t_egg_sticol + "='" + nurse_t_egg_sticol + "'";
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
        public String updateChecked(String opufetid, String nurse_t_egg_sticol, String checkedid)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            sql = "Update " + eggs.table + " Set " +
                " " + eggs.fet + " = '" + checkedid + "'" +
                "Where " + eggs.lmp_date + "='" + opufetid + "' and " + eggs.nurse_t_egg_sticol + "='" + nurse_t_egg_sticol + "'";
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
        public String updateDevDate(String opufetid, String nurse_t_egg_sticol, String devdate)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            sql = "Update " + eggs.table + " Set " +
                " " + eggs.bhcg_test + " = '" + devdate + "'" +
                "Where " + eggs.lmp_date + "='" + opufetid + "' and " + eggs.nurse_t_egg_sticol + "='" + nurse_t_egg_sticol + "'";
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
        public String updatePathPic(String id, String num, String filename, String opu_time, String userid)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            sql = "Update " + eggs.table + " Set " +
                " " + eggs.opu_time + " = '" + opu_time + "'" +
                "," + eggs.a + " = '" + filename + "'" +
                //"," + opuEmDev.status_g + " = '" + num + "'" +
                "," + eggs.user_modi + " = '" + userid + "'" +
                "," + eggs.date_modi + " = now() " +
                "Where " + eggs.pkField + "='" + id + "'";
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
        public String updateNumDesc(String id, String num, String opu_time, String userid)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            sql = "Update " + eggs.table + " Set " +
                " " + eggs.opu_time + " = '" + opu_time + "'" +
                //"," + opuEmDev.status_g + " = '" + num + "'" +
                "," + eggs.user_modi + " = '" + userid + "'" +
                "," + eggs.date_modi + " = now() " +
                "Where " + eggs.pkField + "='" + id + "'";
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
    }
}
