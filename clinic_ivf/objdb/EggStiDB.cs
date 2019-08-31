using C1.Win.C1Input;
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
            eggs.t_patient_id = "t_patient_id";
            eggs.t_visit_id = "t_visit_id";
            eggs.egg_sti_date = "egg_sti_date";
            eggs.doctor_id = "doctor_id";
            eggs.status_abnormal = "status_abnormal";
            eggs.abnormal1 = "abnormal1";
            eggs.abnormal2 = "abnormal2";
            eggs.status_typing = "status_typing";
            eggs.status_typing_other = "status_typing_other";
            eggs.typing_other = "typing_other";
            eggs.status_infectious = "status_infectious";
            eggs.status_add_lab = "status_add_lab";
            eggs.add_lab = "add_lab";
            eggs.day_start = "day_start";

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

            p.t_patient_id = long.TryParse(p.t_patient_id, out chk) ? chk.ToString() : "0";
            p.t_visit_id = long.TryParse(p.t_visit_id, out chk) ? chk.ToString() : "0";
            p.doctor_id = long.TryParse(p.doctor_id, out chk) ? chk.ToString() : "0";
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
            p.egg_sti_date = p.egg_sti_date == null ? "" : p.egg_sti_date;
            p.status_abnormal = p.status_abnormal == null ? "0" : p.status_abnormal;
            p.abnormal1 = p.abnormal1 == null ? "" : p.abnormal1;
            p.abnormal2 = p.abnormal2 == null ? "" : p.abnormal2;
            p.status_typing = p.status_typing == null ? "0" : p.status_typing;
            p.status_typing_other = p.status_typing_other == null ? "0" : p.status_typing_other;
            p.typing_other = p.typing_other == null ? "" : p.typing_other;
            p.status_infectious = p.status_infectious == null ? "0" : p.status_infectious;
            p.status_add_lab = p.status_add_lab == null ? "0" : p.status_add_lab;
            p.add_lab = p.add_lab == null ? "" : p.add_lab;
            p.day_start = p.day_start == null ? "" : p.day_start;

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
                "," + eggs.user_create + "='" + userId + "@" + conn._IPAddress + "'" +
                "," + eggs.g + "='" + p.g.Replace("'", "''") + "'" +
                "," + eggs.opu_date + "='" + p.opu_date.Replace("'", "''") + "'" +
                "," + eggs.opu_time + "='" + p.opu_time.Replace("'", "''") + "'" +
                "," + eggs.et + "='" + p.et.Replace("'", "''") + "'" +
                "," + eggs.fet + "='" + p.fet.Replace("'", "''") + "'" +
                "," + eggs.bhcg_test + "='" + p.bhcg_test.Replace("'", "''") + "'" +
                "," + eggs.t_patient_id + "='" + p.t_patient_id + "'" +
                "," + eggs.t_visit_id + "='" + p.t_visit_id + "'" +
                "," + eggs.egg_sti_date + "='" + p.egg_sti_date + "'" +
                "," + eggs.doctor_id + "='" + p.doctor_id + "'" +
                "," + eggs.status_abnormal + "='" + p.status_abnormal + "'" +
                "," + eggs.abnormal1 + "='" + p.abnormal1 + "'" +
                "," + eggs.abnormal2 + "='" + p.abnormal2 + "'" +
                "," + eggs.status_typing + "='" + p.status_typing + "'" +
                "," + eggs.status_typing_other + "='" + p.status_typing_other + "'" +
                "," + eggs.typing_other + "='" + p.typing_other + "'" +
                "," + eggs.status_infectious + "='" + p.status_infectious + "'" +
                "," + eggs.status_add_lab + "='" + p.status_add_lab + "'" +
                "," + eggs.add_lab + "='" + p.add_lab + "'" +
                "," + eggs.day_start + "='" + p.day_start + "'" +
                " " +
                "";
            try
            {
                re = conn.ExecuteNonQuery(conn.conn, sql);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
                new LogWriter("Error insert EggSti " + sql);
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
                "," + eggs.t_patient_id + "='" + p.t_patient_id + "'" +
                "," + eggs.t_visit_id + "='" + p.t_visit_id + "'" +
                "," + eggs.egg_sti_date + "='" + p.egg_sti_date + "'" +
                "," + eggs.doctor_id + "='" + p.doctor_id + "'" +
                "," + eggs.status_abnormal + "='" + p.status_abnormal + "'" +
                "," + eggs.abnormal1 + "='" + p.abnormal1 + "'" +
                "," + eggs.abnormal2 + "='" + p.abnormal2 + "'" +
                "," + eggs.status_typing + "='" + p.status_typing + "'" +
                "," + eggs.status_typing_other + "='" + p.status_typing_other + "'" +
                "," + eggs.typing_other + "='" + p.typing_other + "'" +
                "," + eggs.status_infectious + "='" + p.status_infectious + "'" +
                "," + eggs.status_add_lab + "='" + p.status_add_lab + "'" +
                "," + eggs.add_lab + "='" + p.add_lab + "'" +
                "," + eggs.a + "='" + p.a + "'" +
                "," + eggs.day_start + "='" + p.day_start + "'" +
                "," + eggs.lmp_date + "='" + p.lmp_date + "'" +
                "," + eggs.date_modi + "=now()" +
                "," + eggs.user_modi + "='" + userId + "@" + conn._IPAddress + "'" +
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
        public String insertEggSti(EggSti p, String userId)
        {
            String re = "";

            if (p.egg_sti_id.Equals(""))
            {
                re = insert(p, userId);
            }
            else
            {
                re = update(p, userId);
            }

            return re;
        }
        public String VoidEggSti(String id, String userid)
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
        public DataTable selectDistinctByBhcgTest()
        {
            DataTable dt = new DataTable();
            String sql = "select distinct eggs." + eggs.bhcg_test + " " +
                "From " + eggs.table + " eggs " +
                "Where eggs." + eggs.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public C1ComboBox setCboBhcgTest(C1ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectDistinctByBhcgTest();
            //String aaa = "";
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                item = new ComboBoxItem();
                item.Text = row[eggs.bhcg_test].ToString();
                item.Value = i.ToString();

                c.Items.Add(item);
                i++;
            }
            return c;
        }
        public DataTable selectDistinctByAddLab()
        {
            DataTable dt = new DataTable();
            String sql = "select distinct eggs." + eggs.add_lab + " " +
                "From " + eggs.table + " eggs " +
                "Where eggs." + eggs.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public C1ComboBox setCboAddLab(C1ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectDistinctByAddLab();
            //String aaa = "";
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                item = new ComboBoxItem();
                item.Text = row[eggs.add_lab].ToString();
                item.Value = i.ToString();

                c.Items.Add(item);
                i++;
            }
            return c;
        }
        public DataTable selectByPatient(String pttid)
        {
            DataTable dt = new DataTable();
            String sql = "select eggs." + eggs.lmp_date + ",vs.visit_vn,"+eggs.egg_sti_id+" " +
                "From " + eggs.table + " eggs " +
                "Left Join t_visit vs on eggs."+eggs.t_visit_id + " = vs.t_visit_id " +
                "Where eggs." + eggs.active + "='1' and eggs."+eggs.t_patient_id+"='"+pttid+"'";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public C1ComboBox setCboPatient(C1ComboBox c, String pttid)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectByPatient(pttid);
            //String aaa = "";
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                item = new ComboBoxItem();
                item.Text = datetoShow(row[eggs.lmp_date].ToString())+" "+ row["visit_vn"].ToString();
                item.Value = row[eggs.egg_sti_id].ToString();

                c.Items.Add(item);
                i++;
            }
            return c;
        }
        public DataTable selectDistinctByTypingOther()
        {
            DataTable dt = new DataTable();
            String sql = "select distinct eggs." + eggs.typing_other + " " +
                "From " + eggs.table + " eggs " +
                "Where eggs." + eggs.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public C1ComboBox setCboTypingOther(C1ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectDistinctByTypingOther();
            //String aaa = "";
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                item = new ComboBoxItem();
                item.Text = row[eggs.typing_other].ToString();
                item.Value = i.ToString();

                c.Items.Add(item);
                i++;
            }
            return c;
        }
        public DataTable selectByPk(String pttId)
        {
            DataTable dt = new DataTable();
            String sql = "select eggs.* " +
                "From " + eggs.table + " eggs " +
                "Where eggs." + eggs.pkField + " ='" + pttId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public EggSti selectByPk1(String pttId)
        {
            EggSti cop1 = new EggSti();
            DataTable dt = new DataTable();
            String sql = "select eggs.* " +
                "From " + eggs.table + " eggs " +
                "Where eggs." + eggs.pkField + " ='" + pttId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setEggSti(dt);
            return cop1;
        }
        public EggSti selectByVsId(String pttId)
        {
            EggSti cop1 = new EggSti();
            DataTable dt = new DataTable();
            String sql = "select eggs.* " +
                "From " + eggs.table + " eggs " +
                "Where eggs." + eggs.t_visit_id + " ='" + pttId + "'  and eggs." + eggs.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setEggSti(dt);
            return cop1;
        }
        public EggSti selectByPttId(String pttId)
        {
            EggSti cop1 = new EggSti();
            DataTable dt = new DataTable();
            String sql = "select eggs.* " +
                "From " + eggs.table + " eggs " +
                "Where eggs." + eggs.t_patient_id + " ='" + pttId + "' and eggs."+eggs.active +"='1' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setEggSti(dt);
            return cop1;
        }
        private EggSti setEggSti(DataTable dt)
        {
            EggSti dept1 = new EggSti();
            if (dt.Rows.Count > 0)
            {
                dept1.egg_sti_id = dt.Rows[0][eggs.egg_sti_id].ToString();
                dept1.lmp_date = dt.Rows[0][eggs.lmp_date].ToString();
                dept1.nurse_t_egg_sticol = dt.Rows[0][eggs.nurse_t_egg_sticol].ToString();
                dept1.status_g = dt.Rows[0][eggs.status_g].ToString();
                dept1.p = dt.Rows[0][eggs.p].ToString();
                dept1.active = dt.Rows[0][eggs.active].ToString();
                dept1.remark = dt.Rows[0][eggs.remark].ToString();
                dept1.a = dt.Rows[0][eggs.a].ToString();
                dept1.date_create = dt.Rows[0][eggs.date_create].ToString();
                dept1.date_modi = dt.Rows[0][eggs.date_modi].ToString();
                dept1.date_cancel = dt.Rows[0][eggs.date_cancel].ToString();
                dept1.user_create = dt.Rows[0][eggs.user_create].ToString();
                dept1.user_modi = dt.Rows[0][eggs.user_modi].ToString();
                dept1.user_cancel = dt.Rows[0][eggs.user_cancel].ToString();
                dept1.g = dt.Rows[0][eggs.g].ToString();
                dept1.opu_date = dt.Rows[0][eggs.opu_date].ToString();
                dept1.opu_time = dt.Rows[0][eggs.opu_time].ToString();
                dept1.et = dt.Rows[0][eggs.et].ToString();
                dept1.fet = dt.Rows[0][eggs.fet].ToString();
                dept1.bhcg_test = dt.Rows[0][eggs.bhcg_test].ToString();
                dept1.t_patient_id = dt.Rows[0][eggs.t_patient_id].ToString();
                dept1.t_visit_id = dt.Rows[0][eggs.t_visit_id].ToString();
                dept1.egg_sti_date = dt.Rows[0][eggs.egg_sti_date].ToString();
                dept1.doctor_id = dt.Rows[0][eggs.doctor_id].ToString();
                dept1.status_abnormal = dt.Rows[0][eggs.status_abnormal].ToString();
                dept1.abnormal1 = dt.Rows[0][eggs.abnormal1].ToString();
                dept1.abnormal2 = dt.Rows[0][eggs.abnormal2].ToString();
                dept1.status_typing = dt.Rows[0][eggs.status_typing].ToString();
                dept1.status_typing_other = dt.Rows[0][eggs.status_typing_other].ToString();
                dept1.typing_other = dt.Rows[0][eggs.typing_other].ToString();
                dept1.status_infectious = dt.Rows[0][eggs.status_infectious].ToString();
                dept1.status_add_lab = dt.Rows[0][eggs.status_add_lab].ToString();
                dept1.add_lab = dt.Rows[0][eggs.add_lab].ToString();
                dept1.day_start = dt.Rows[0][eggs.day_start].ToString();
            }
            else
            {
                dept1.egg_sti_id = "";
                dept1.lmp_date = "";
                dept1.nurse_t_egg_sticol = "";
                dept1.status_g = "";
                dept1.p = "";
                dept1.active = "";
                dept1.remark = "";
                dept1.a = "";
                dept1.date_create = "";
                dept1.date_modi = "";
                dept1.date_cancel = "";
                dept1.user_create = "";
                dept1.user_modi = "";
                dept1.user_cancel = "";
                dept1.g = "";
                dept1.opu_date = "";
                dept1.opu_time = "";
                dept1.et = "";
                dept1.fet = "";
                dept1.bhcg_test = "";
                dept1.t_patient_id = "";
                dept1.t_visit_id = "";
                dept1.egg_sti_date = "";
                dept1.doctor_id = "";
                dept1.status_abnormal = "";
                dept1.abnormal1 = "";
                dept1.abnormal2 = "";
                dept1.status_typing = "";
                dept1.status_typing_other = "";
                dept1.typing_other = "";
                dept1.status_infectious = "";
                dept1.status_add_lab = "";
                dept1.add_lab = "";
                dept1.day_start = "";
            }
            return dept1;
        }
        public String datetoShow(Object dt)
        {
            DateTime dt1 = new DateTime();
            //MySqlDateTime dtm = new MySqlDateTime();
            String re = "";
            if (dt != null)
            {
                if (DateTime.TryParse(dt.ToString(), out dt1))
                {
                    if (dt1.Year < 1900) return "";
                    re = dt1.ToString("dd-MM-yyyy");
                }
            }
            return re;
        }
    }
}
