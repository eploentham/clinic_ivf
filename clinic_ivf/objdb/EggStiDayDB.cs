using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class EggStiDayDB
    {
        public EggStiDay eggsd;
        ConnectDB conn;
        public List<EggStiDay> lStf;
        public enum Day1 { Day2, Day3, Day5, Day6 }

        public EggStiDayDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            eggsd = new EggStiDay();
            eggsd.egg_sti_day_id = "egg_sti_day_id";
            eggsd.egg_sti_id = "egg_sti_id";
            eggsd.day1 = "day1";
            eggsd.date = "date";
            eggsd.e2 = "e2";
            eggsd.lh = "lh";
            eggsd.active = "active";
            eggsd.remark = "remark";
            eggsd.fsh = "fsh";
            eggsd.date_create = "date_create";
            eggsd.date_modi = "date_modi";
            eggsd.date_cancel = "date_cancel";
            eggsd.user_create = "user_create";
            eggsd.user_modi = "user_modi";
            eggsd.user_cancel = "user_cancel";
            eggsd.prolactin = "prolactin";
            eggsd.rt_ovary_1 = "rt_ovary_1";
            eggsd.rt_ovary_2 = "rt_ovary_2";
            eggsd.lt_ovary_1 = "lt_ovary_1";
            eggsd.lt_ovary_2 = "lt_ovary_2";
            eggsd.endo = "endo";
            eggsd.medication = "medication";
            eggsd.medication2 = "medication2";

            eggsd.table = "nurse_t_egg_sti_day";
            eggsd.pkField = "egg_sti_day_id";

            lStf = new List<EggStiDay>();
        }
        private void chkNull(EggStiDay p)
        {
            long chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            //p.day = long.TryParse(p.day, out chk) ? chk.ToString() : "0";
            //p.e2 = long.TryParse(p.e2, out chk) ? chk.ToString() : "0";
            //p.lt_ovary_1 = long.TryParse(p.lt_ovary_1, out chk) ? chk.ToString() : "0";
            p.egg_sti_id = long.TryParse(p.egg_sti_id, out chk) ? chk.ToString() : "0";

            p.date = p.date == null ? "0" : p.date;
            p.lh = p.lh == null ? "" : p.lh;
            p.active = p.active == null ? "" : p.active;
            p.remark = p.remark == null ? "" : p.remark;
            p.fsh = p.fsh == null ? "" : p.fsh;
            p.prolactin = p.prolactin == null ? "" : p.prolactin;
            p.rt_ovary_1 = p.rt_ovary_1 == null ? "" : p.rt_ovary_1;
            p.rt_ovary_2 = p.rt_ovary_2 == null ? "" : p.rt_ovary_2;
            p.endo = p.endo == null ? "" : p.endo;
            p.day1 = p.day1 == null ? "" : p.day1;
            p.e2 = p.e2 == null ? "" : p.e2;
            p.lt_ovary_1 = p.lt_ovary_1 == null ? "" : p.lt_ovary_1;
            p.lt_ovary_2 = p.lt_ovary_2 == null ? "" : p.lt_ovary_2;

            p.medication = p.medication == null ? "" : p.medication;
            p.medication2 = p.medication2 == null ? "" : p.medication2;
        }
        public String insert(EggStiDay p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;
            //eggsd.day1 = "day1";
            //eggsd.table = "nurse_t_egg_sti_day";

            chkNull(p);
            //opuEmDev.p = "p";
            sql = "Insert Into " + eggsd.table + " Set " +
                " " + eggsd.day1 + "='" + p.day1 + "'" +
                "," + eggsd.date + "='" + p.date + "'" +
                "," + eggsd.e2 + "='" + p.e2 + "'" +
                "," + eggsd.lh + "='" + p.lh.Replace("'", "''") + "'" +
                "," + eggsd.active + "='" + p.active + "'" +
                "," + eggsd.remark + "='" + p.remark.Replace("'", "''") + "'" +
                "," + eggsd.fsh + "='" + p.fsh + "'" +
                "," + eggsd.date_create + "=now()" +
                "," + eggsd.user_create + "='" + userId + "@" + conn._IPAddress + "'" +
                "," + eggsd.prolactin + "='" + p.prolactin.Replace("'", "''") + "'" +
                "," + eggsd.rt_ovary_1 + "='" + p.rt_ovary_1.Replace("'", "''") + "'" +
                "," + eggsd.rt_ovary_2 + "='" + p.rt_ovary_2.Replace("'", "''") + "'" +
                "," + eggsd.lt_ovary_1 + "='" + p.lt_ovary_1.Replace("'", "''") + "'" +
                "," + eggsd.lt_ovary_2 + "='" + p.lt_ovary_2.Replace("'", "''") + "'" +
                "," + eggsd.endo + "='" + p.endo.Replace("'", "''") + "'" +
                "," + eggsd.egg_sti_id + "='" + p.egg_sti_id + "'" +
                "," + eggsd.medication + "='" + p.medication + "'" +
                "," + eggsd.medication2 + "='" + p.medication2 + "'" +
                " " +

                "";
            try
            {
                re = conn.ExecuteNonQuery(conn.conn, sql);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
                new LogWriter("Error insert EggStiDay " + sql);
            }

            return re;
        }
        public String update(EggStiDay p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + eggsd.table + " Set " +
                " " + eggsd.date + " = '" + p.date + "'" +
                "," + eggsd.e2 + " = '" + p.e2.Replace("'", "''") + "'" +
                "," + eggsd.lh + " = '" + p.lh.Replace("'", "''") + "'" +
                "," + eggsd.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + eggsd.prolactin + " = '" + p.prolactin.Replace("'", "''") + "'" +
                "," + eggsd.rt_ovary_1 + " = '" + p.rt_ovary_1.Replace("'", "''") + "'" +
                "," + eggsd.rt_ovary_2 + " = '" + p.rt_ovary_2.Replace("'", "''") + "'" +
                "," + eggsd.lt_ovary_1 + " = '" + p.lt_ovary_1.Replace("'", "''") + "'" +
                "," + eggsd.lt_ovary_2 + "='" + p.lt_ovary_2.Replace("'", "''") + "'" +
                "," + eggsd.endo + "='" + p.endo.Replace("'", "''") + "'" +
                "," + eggsd.fsh + "='" + p.fsh.Replace("'", "''") + "'" +
                //"," + eggsd.egg_sti_id + "='" + p.egg_sti_id + "'" +
                "," + eggsd.medication + "='" + p.medication.Replace("'", "''") + "'" +
                "," + eggsd.medication2 + "='" + p.medication2.Replace("'", "''") + "'" +
                "," + eggsd.date_modi + "=now()" +
                "," + eggsd.user_modi + "='" + userId + "@" + conn._IPAddress + "'" +
                "Where " + eggsd.pkField + "='" + p.egg_sti_day_id + "'"
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
        public String update1(EggStiDay p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + eggsd.table + " Set " +
                //" " + eggsd.date + " = '" + p.date + "'" +
                " " + eggsd.e2 + " = '" + p.e2.Replace("'", "''") + "'" +
                "," + eggsd.lh + " = '" + p.lh.Replace("'", "''") + "'" +
                "," + eggsd.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + eggsd.prolactin + " = '" + p.prolactin.Replace("'", "''") + "'" +
                "," + eggsd.rt_ovary_1 + " = '" + p.rt_ovary_1.Replace("'", "''") + "'" +
                "," + eggsd.rt_ovary_2 + " = '" + p.rt_ovary_2.Replace("'", "''") + "'" +
                "," + eggsd.lt_ovary_1 + " = '" + p.lt_ovary_1.Replace("'", "''") + "'" +
                "," + eggsd.lt_ovary_2 + "='" + p.lt_ovary_2.Replace("'", "''") + "'" +
                "," + eggsd.endo + "='" + p.endo.Replace("'", "''") + "'" +
                "," + eggsd.fsh + "='" + p.fsh.Replace("'", "''") + "'" +
                "," + eggsd.medication + "='" + p.medication.Replace("'", "''") + "'" +
                "," + eggsd.medication2 + "='" + p.medication2.Replace("'", "''") + "'" +
                "," + eggsd.date_modi + "=now()" +
                "," + eggsd.user_modi + "='" + userId + "@" + conn._IPAddress + "'" +
                "Where " + eggsd.pkField + "='" + p.egg_sti_day_id + "'"
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
        public String insertEggStiDay(EggStiDay p, String userId)
        {
            String re = "";

            if (p.egg_sti_day_id.Equals(""))
            {
                re = insert(p, userId);
            }
            else
            {
                re = update1(p, userId);
            }

            return re;
        }
        public String VoidEggSti(String id, String userid)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            sql = "Update " + eggsd.table + " Set " +
                " " + eggsd.active + " = '3'" +
                "," + eggsd.date_cancel + " = now()" +
                "," + eggsd.user_cancel + " = '" + userid + "@" + conn._IPAddress + "'" +
                "Where " + eggsd.egg_sti_id + "='" + id + "'";
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
        public String VoidEggStiDay(String id, String userid)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            sql = "Update " + eggsd.table + " Set " +
                " " + eggsd.active + " = '3'" +
                "," + eggsd.date_cancel + " = now()" +
                "," + eggsd.user_cancel + " = '" + userid + "@" + conn._IPAddress + "'" +
                "Where " + eggsd.pkField + "='" + id + "'";
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
        public String updateStff(String opufetid, String date, String staffid)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            sql = "Update " + eggsd.table + " Set " +
                " " + eggsd.lt_ovary_1 + " = '" + staffid + "'" +
                "Where " + eggsd.day1 + "='" + opufetid + "' and " + eggsd.date + "='" + date + "'";
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
        public String updateChecked(String opufetid, String date, String checkedid)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            sql = "Update " + eggsd.table + " Set " +
                " " + eggsd.lt_ovary_2 + " = '" + checkedid + "'" +
                "Where " + eggsd.day1 + "='" + opufetid + "' and " + eggsd.date + "='" + date + "'";
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
        public String updateDevDate(String opufetid, String date, String devdate)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            sql = "Update " + eggsd.table + " Set " +
                " " + eggsd.endo + " = '" + devdate + "'" +
                "Where " + eggsd.day1 + "='" + opufetid + "' and " + eggsd.date + "='" + date + "'";
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
        public String updatePathPic(String id, String num, String filename, String rt_ovary_2, String userid)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            sql = "Update " + eggsd.table + " Set " +
                " " + eggsd.rt_ovary_2 + " = '" + rt_ovary_2 + "'" +
                "," + eggsd.fsh + " = '" + filename + "'" +
                //"," + opuEmDev.e2 + " = '" + num + "'" +
                "," + eggsd.user_modi + " = '" + userid + "'" +
                "," + eggsd.date_modi + " = now() " +
                "Where " + eggsd.pkField + "='" + id + "'";
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
        public String updateNumDesc(String id, String num, String rt_ovary_2, String userid)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            sql = "Update " + eggsd.table + " Set " +
                " " + eggsd.rt_ovary_2 + " = '" + rt_ovary_2 + "'" +
                //"," + opuEmDev.e2 + " = '" + num + "'" +
                "," + eggsd.user_modi + " = '" + userid + "'" +
                "," + eggsd.date_modi + " = now() " +
                "Where " + eggsd.pkField + "='" + id + "'";
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
        public DataTable selectByPk(String pttId)
        {
            DataTable dt = new DataTable();
            String sql = "select eggsd.* " +
                "From " + eggsd.table + " eggsd " +
                "Where eggsd." + eggsd.pkField + " ='" + pttId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public EggStiDay selectByPk1(String pttId)
        {
            EggStiDay cop1 = new EggStiDay();
            DataTable dt = new DataTable();
            String sql = "select eggsd.* " +
                "From " + eggsd.table + " eggsd " +
                "Where eggsd." + eggsd.pkField + " ='" + pttId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setEggSti(dt);
            return cop1;
        }
        public DataTable selectByEggStiId(String pttId)
        {
            DataTable dt = new DataTable();
            String sql = "select eggsd.* " +
                "From " + eggsd.table + " eggsd " +
                "Where eggsd." + eggsd.egg_sti_id + " ='" + pttId + "' and eggsd."+eggsd.active+"='1' " +
                "Order By "+eggsd.egg_sti_day_id;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        private EggStiDay setEggSti(DataTable dt)
        {
            EggStiDay dept1 = new EggStiDay();
            if (dt.Rows.Count > 0)
            {
                dept1.egg_sti_day_id = dt.Rows[0][eggsd.egg_sti_day_id].ToString();
                dept1.egg_sti_id = dt.Rows[0][eggsd.egg_sti_id].ToString();
                dept1.day1 = dt.Rows[0][eggsd.day1].ToString();
                dept1.date = dt.Rows[0][eggsd.date].ToString();
                dept1.e2 = dt.Rows[0][eggsd.e2].ToString();
                dept1.lh = dt.Rows[0][eggsd.lh].ToString();
                dept1.active = dt.Rows[0][eggsd.active].ToString();
                dept1.remark = dt.Rows[0][eggsd.remark].ToString();
                dept1.fsh = dt.Rows[0][eggsd.fsh].ToString();
                dept1.date_create = dt.Rows[0][eggsd.date_create].ToString();
                dept1.date_modi = dt.Rows[0][eggsd.date_modi].ToString();
                dept1.date_cancel = dt.Rows[0][eggsd.date_cancel].ToString();
                dept1.user_create = dt.Rows[0][eggsd.user_create].ToString();
                dept1.user_modi = dt.Rows[0][eggsd.user_modi].ToString();
                dept1.user_cancel = dt.Rows[0][eggsd.user_cancel].ToString();
                dept1.prolactin = dt.Rows[0][eggsd.prolactin].ToString();
                dept1.rt_ovary_1 = dt.Rows[0][eggsd.rt_ovary_1].ToString();
                dept1.rt_ovary_2 = dt.Rows[0][eggsd.rt_ovary_2].ToString();
                dept1.lt_ovary_1 = dt.Rows[0][eggsd.lt_ovary_1].ToString();
                dept1.lt_ovary_2 = dt.Rows[0][eggsd.lt_ovary_2].ToString();
                dept1.endo = dt.Rows[0][eggsd.endo].ToString();
                dept1.medication = dt.Rows[0][eggsd.medication].ToString();
                dept1.medication2 = dt.Rows[0][eggsd.medication2].ToString();
            }
            else
            {
                dept1.egg_sti_day_id = "";
                dept1.egg_sti_id = "";
                dept1.day1 = "";
                dept1.date = "";
                dept1.e2 = "";
                dept1.lh = "";
                dept1.active = "";
                dept1.remark = "";
                dept1.fsh = "";
                dept1.date_create = "";
                dept1.date_modi = "";
                dept1.date_cancel = "";
                dept1.user_create = "";
                dept1.user_modi = "";
                dept1.user_cancel = "";
                dept1.prolactin = "";
                dept1.rt_ovary_1 = "";
                dept1.rt_ovary_2 = "";
                dept1.lt_ovary_1 = "";
                dept1.lt_ovary_2 = "";
                dept1.endo = "";
                dept1.medication = "";
                dept1.medication2 = "";
            }
            return dept1;
        }
    }
}
