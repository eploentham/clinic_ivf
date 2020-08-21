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
    public class LabFetDB
    {
        public LabFet fet;
        ConnectDB conn;
        public LabFetDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            fet = new LabFet();
            fet.fet_id = "fet_id";
            fet.fet_code = "fet_code";
            fet.hn_male = "hn_male";
            fet.hn_female = "hn_female";
            fet.name_male = "name_male";
            fet.name_female = "name_female";
            fet.dob_male = "dob_male";
            fet.dob_female = "dob_female";
            fet.doctor_id = "doctor_id";
            fet.proce_id = "proce_id";
            fet.fet_date = "fet_date";
            fet.freeze_date = "freeze_date";
            fet.freeze_no_of_freeze = "freeze_no_of_freeze";
            fet.freeze_stage_of_freeze = "freeze_stage_of_freeze";
            fet.thaw_date = "thaw_date";
            fet.thaw_no_of_thaw = "thaw_no_of_thaw";
            fet.thaw_no_of_survival = "thaw_no_of_survival";
            fet.thaw_no_of_remaining = "thaw_no_of_remaining";
            fet.media_date = "media_date";
            fet.media_lot_no = "media_lot_no";
            fet.media_exp = "media_exp";
            fet.media_thawing = "media_thawing";
            fet.embryo_for_et_no_of_et = "embryo_for_et_no_of_et";
            fet.embryo_for_et_day = "embryo_for_et_day";
            fet.embryo_for_et_date = "embryo_for_et_date";
            fet.embryo_for_et_assisted = "embryo_for_et_assisted";
            fet.embryo_for_et_remark = "embryo_for_et_remark";
            fet.embryo_for_et_volume = "embryo_for_et_volume";
            fet.embryo_for_et_catheter = "embryo_for_et_catheter";
            fet.embryo_for_et_doctor = "embryo_for_et_doctor";
            fet.embryo_for_et_embryologist_id = "embryo_for_et_embryologist_id";
            fet.embryo_for_et_number_of_transfer = "embryo_for_et_number_of_transfer";
            fet.embryo_for_et_number_of_freeze = "embryo_for_et_number_of_freeze";
            fet.embryo_for_et_number_of_discard = "embryo_for_et_number_of_discard";
            fet.embryologist_report_id = "embryologist_report_id";
            fet.embryologist_approve_id = "embryologist_approve_id";
            fet.date_create = "date_create";
            fet.date_modi = "date_modi";
            fet.date_cancel = "date_cancel";
            fet.user_create = "user_create";
            fet.user_modi = "user_modi";
            fet.user_cancel = "user_cancel";
            fet.active = "active";
            fet.remark = "remark";
            fet.req_id = "req_id";
            fet.status_fet = "status_fet";
            fet.save_patient_staff_id = "save_patient_staff_id";
            fet.save_maturation_staff_id = "save_maturation_staff_id";
            fet.save_fetilization_staff_id = "save_fetilization_staff_id";
            fet.save_sperm_prepa_staff_id = "save_sperm_prepa_staff_id";
            fet.save_embryo_freezing_day_0_staff_id = "save_embryo_freezing_day_0_staff_id";
            fet.save_embryo_freezing_day_1_staff_id = "save_embryo_freezing_day_1_staff_id";
            fet.save_embbryo_for_et_staff_id = "save_embbryo_for_et_staff_id";
            fet.date_pic_embryo = "date_pic_embryo";
            fet.hn_donor = "hn_donor";
            fet.name_donor = "name_donor";
            fet.dob_donor = "dob_donor";
            fet.approve_result_staff_id = "approve_result_staff_id";
            fet.status_approve_result_day1 = "status_approve_result_day1";
            fet.status_approve_result_day3 = "status_approve_result_day3";
            fet.status_approve_result_day5 = "status_approve_result_day5";
            fet.approve_result_day1_staff_id = "approve_result_day1_staff_id";
            fet.approve_result_day3_staff_id = "approve_result_day3_staff_id";
            fet.approve_result_day5_staff_id = "approve_result_day5_staff_id";
            fet.approve_result_day1_date = "approve_result_day1_date";
            fet.approve_result_day3_date = "approve_result_day3_date";
            fet.approve_result_day5_date = "approve_result_day5_date";
            fet.fet_time = "fet_time";
            fet.embryo_freez_freeze_media = "embryo_freez_freeze_media";
            fet.embryo_pic_day = "embryo_pic_day";
            fet.embryo_pic_day1 = "embryo_pic_day1";
            fet.remark1 = "remark1";
            fet.remark2 = "remark2";
            fet.freeze_date1 = "freeze_date1";
            fet.report = "report";

            fet.table = "lab_t_fet";
            fet.pkField = "fet_id";
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select fet.*,dtr.Name, proce.proce_name_t " +
                "From " + fet.table + " fet " +
                "Left Join Doctor dtr on dtr.ID = fet." + fet.doctor_id + " " +
                "LEft Join lab_b_procedure proce on proce.proce_id = fet.proce_id " +
                "Where fet." + fet.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public LabFet selectByPk1(String copId)
        {
            LabFet lbReq1 = new LabFet();
            DataTable dt = new DataTable();
            String sql = "select fet.*,dtr.Name, proce.proce_name_t " +
                "From " + fet.table + " fet " +
                "Left Join Doctor dtr on dtr.ID = fet." + fet.doctor_id + " " +
                "LEft Join lab_b_procedure proce on proce.proce_id = fet.proce_id " +
                "Where fet." + fet.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            lbReq1 = setLabFET(dt);
            return lbReq1;
        }
        public DataTable selectDistinctByRemark()
        {
            DataTable dt = new DataTable();
            String sql = "select distinct fet.remark " +
                "From " + fet.table + " fet " +
                "Where fet." + fet.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectDistinctByRemark1()
        {
            DataTable dt = new DataTable();
            String sql = "select distinct fet.remark1 " +
                "From " + fet.table + " fet " +
                "Where fet." + fet.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectDistinctByRemark2()
        {
            DataTable dt = new DataTable();
            String sql = "select distinct fet.remark2 " +
                "From " + fet.table + " fet " +
                "Where fet." + fet.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectDistinctByEtRemark()
        {
            DataTable dt = new DataTable();
            String sql = "select distinct fet."+fet.embryo_for_et_remark+" " +
                "From " + fet.table + " fet " +
                "Where fet." + fet.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectDistinctByEtCatheter()
        {
            DataTable dt = new DataTable();
            String sql = "select distinct fet." + fet.embryo_for_et_catheter + " " +
                "From " + fet.table + " fet " +
                "Where fet." + fet.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByStatusFinish(String datestart, String dateend)
        {
            DataTable dt = new DataTable();
            String sql = "select fet." + fet.fet_id + ", fet." + fet.fet_code + ",fet." + fet.hn_female + ",fet." + fet.name_female + ",fet." + fet.fet_date + ",fet." + fet.remark + "," + fet.hn_male + "," + fet.name_male + ", lab_b_procedure.proce_name_t " +
                "From " + fet.table + " fet " +
                "Left Join Doctor on Doctor.ID = fet.doctor_id " +
                "Left Join lab_b_procedure on fet.proce_id = lab_b_procedure.proce_id " +
                "Where fet." + fet.status_fet + " ='2' and fet." + fet.active + "='1' " +
                "and fet." + fet.fet_date + " >= '" + datestart + "' and fet." + fet.fet_date + " <= '" + dateend + "' " +
                //"Order By opu." + opu.opu_id + " " +
                //"Union " +
                //"select fet.fet_id , fet.fet_code ,fet.hn_female ,fet.name_female,fet.fet_date ,fet.remark, fet.hn_male, fet.name_male, lab_b_procedure.proce_name_t " +
                //"From lab_t_fet fet  " +
                //"Left Join Doctor on Doctor.ID = fet.doctor_id " +
                //"Left Join lab_b_procedure on fet.proce_id = lab_b_procedure.proce_id " +
                //"Where fet.status_fet ='1' and fet.active + '1' " +
                //"Order By fet.fet_id  ";
                "  ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByStatusProcess1()
        {
            DataTable dt = new DataTable();
            String sql = "select fet." + fet.fet_id + ", fet." + fet.fet_code + ",fet." + fet.hn_female + ",fet." + fet.name_female + ",fet." + fet.fet_date + ",fet." + fet.remark + "," + fet.hn_male + "," + fet.name_male + ", lab_b_procedure.proce_name_t " +
                "From " + fet.table + " fet " +
                "Left Join Doctor on Doctor.ID = fet.doctor_id " +
                "Left Join lab_b_procedure on fet.proce_id = lab_b_procedure.proce_id " +
                "Where fet." + fet.status_fet + " ='1' and fet." + fet.active + "='1' " +
                //"Order By opu." + opu.opu_id + " " +
                //"Union " +
                //"select fet.fet_id , fet.fet_code ,fet.hn_female ,fet.name_female,fet.fet_date ,fet.remark, fet.hn_male, fet.name_male, lab_b_procedure.proce_name_t " +
                //"From lab_t_fet fet  " +
                //"Left Join Doctor on Doctor.ID = fet.doctor_id " +
                //"Left Join lab_b_procedure on fet.proce_id = lab_b_procedure.proce_id " +
                //"Where fet.status_fet ='1' and fet.active + '1' " +
                //"Order By fet.fet_id  ";
                "  ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectBySearchHn(String search)
        {
            String wherehn = "";
            if (!search.Equals(""))
            {
                wherehn = "  (fet." + fet.hn_male + " like '%" + search + "%' and fet." + fet.active + "='1') or (fet." + fet.hn_female + " like '%" + search + "%' and fet." + fet.active + "='1') ";
            }
            DataTable dt = new DataTable();
            String sql = "select fet." + fet.fet_id + ", fet." + fet.fet_code + ",fet." + fet.hn_female + ",fet." + fet.name_female + ",fet." + fet.fet_date + ",fet." + fet.remark + "," + fet.hn_male + "," + fet.name_male + ", lab_b_procedure.proce_name_t " +
                "From " + fet.table + " fet " +
                "Left Join Doctor on Doctor.ID = fet.doctor_id " +
                "Left Join lab_b_procedure on fet.proce_id = lab_b_procedure.proce_id " +
                "Where  " + wherehn +
                //"Order By opu." + opu.opu_id + " " +
                //"Union " +
                //"select fet.fet_id , fet.fet_code ,fet.hn_female ,fet.name_female,fet.fet_date ,fet.remark, fet.hn_male, fet.name_male, lab_b_procedure.proce_name_t " +
                //"From lab_t_fet fet  " +
                //"Left Join Doctor on Doctor.ID = fet.doctor_id " +
                //"Left Join lab_b_procedure on fet.proce_id = lab_b_procedure.proce_id " +
                //"Where fet.status_fet ='1' and fet.active + '1' " +
                //"Order By fet.fet_id  ";
                "  ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public C1ComboBox setCboEtCatheter(C1ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectDistinctByEtCatheter();
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
                item.Text = row[fet.embryo_for_et_catheter].ToString();
                item.Value = i.ToString();

                c.Items.Add(item);
                i++;
            }
            return c;
        }
        public C1ComboBox setCboEtRemark(C1ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectDistinctByEtRemark();
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
                item.Text = row[fet.embryo_for_et_remark].ToString();
                item.Value = i.ToString();

                c.Items.Add(item);
                i++;
            }
            return c;
        }
        public C1ComboBox setCboRemark2(C1ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectDistinctByRemark2();
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
                item.Text = row[fet.remark2].ToString();
                item.Value = i.ToString();

                c.Items.Add(item);
                i++;
            }
            return c;
        }
        public C1ComboBox setCboRemark1(C1ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectDistinctByRemark1();
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
                item.Text = row[fet.remark1].ToString();
                item.Value = i.ToString();

                c.Items.Add(item);
                i++;
            }
            return c;
        }
        public C1ComboBox setCboRemark(C1ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectDistinctByRemark();
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
                item.Text = row[fet.remark].ToString();
                item.Value = i.ToString();

                c.Items.Add(item);
                i++;
            }
            return c;
        }
        private void chkNull(LabFet p)
        {
            long chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.fet_code = p.fet_code == null ? "" : p.fet_code;
            //p.embryo_freez_stage = p.embryo_freez_stage == null ? "" : p.embryo_freez_stage;
            //p.embryoid_freez_position = p.embryoid_freez_position == null ? "" : p.embryoid_freez_position;
            p.hn_male = p.hn_male == null ? "" : p.hn_male;
            p.hn_female = p.hn_female == null ? "" : p.hn_female;
            p.name_male = p.name_male == null ? "" : p.name_male;
            p.name_female = p.name_female == null ? "" : p.name_female;
            p.dob_male = p.dob_male == null ? "" : p.dob_male;
            p.dob_female = p.dob_female == null ? "" : p.dob_female;
            p.fet_date = p.fet_date == null ? "" : p.fet_date;
            p.date_pic_embryo = p.date_pic_embryo == null ? "" : p.date_pic_embryo;
            p.hn_donor = p.hn_donor == null ? "" : p.hn_donor;
            p.name_donor = p.name_donor == null ? "" : p.name_donor;
            p.embryo_freez_freeze_media = p.embryo_freez_freeze_media == null ? "" : p.embryo_freez_freeze_media;

            p.remark = p.remark == null ? "" : p.remark;
            //p.sort1 = p.sort1 == null ? "" : p.sort1;
            p.dob_donor = p.dob_donor == null ? "" : p.dob_donor;
            p.fet_time = p.fet_time == null ? "" : p.fet_time;
            p.embryo_pic_day = p.embryo_pic_day == null ? "" : p.embryo_pic_day;
            p.embryo_pic_day1 = p.embryo_pic_day1 == null ? "" : p.embryo_pic_day1;
            p.remark1 = p.remark1 == null ? "" : p.remark1;
            p.remark2 = p.remark2 == null ? "" : p.remark2;

            p.doctor_id = long.TryParse(p.doctor_id, out chk) ? chk.ToString() : "0";
            p.proce_id = long.TryParse(p.proce_id, out chk) ? chk.ToString() : "0";
            p.req_id = long.TryParse(p.req_id, out chk) ? chk.ToString() : "0";
            p.embryologist_approve_id = long.TryParse(p.embryologist_approve_id, out chk) ? chk.ToString() : "0";
            p.embryologist_report_id = long.TryParse(p.embryologist_report_id, out chk) ? chk.ToString() : "0";
            p.embryo_for_et_embryologist_id = long.TryParse(p.embryo_for_et_embryologist_id, out chk) ? chk.ToString() : "0";
            p.embryo_for_et_doctor = long.TryParse(p.embryo_for_et_doctor, out chk) ? chk.ToString() : "0";
            //p.status_lab = p.status_lab == null ? "0" : p.status_lab;
        }
        public String insert(LabFet p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            //fet.table = "lab_t_opu";
            sql = "Insert Into " + fet.table + " Set " +
                " " + fet.fet_code + " = '" + p.fet_code + "'" +
                //"," + fet.embryo_freez_stage + " = '" + p.embryo_freez_stage + "'" +
                //"," + fet.embryoid_freez_position + " = '" + p.embryoid_freez_position + "'" +
                "," + fet.hn_male + " = '" + p.hn_male.Replace("'", "''") + "'" +
                "," + fet.hn_female + " = '" + p.hn_female.Replace("'", "''") + "'" +
                "," + fet.name_male + " = '" + p.name_male.Replace("'", "''") + "'" +
                "," + fet.active + " = '" + p.active + "'" +
                "," + fet.remark + " = '" + p.remark + "'" +
                "," + fet.dob_female + " = '" + p.dob_female + "'" +
                "," + fet.name_female + " = '" + p.name_female + "'" +
                "," + fet.dob_male + " = '" + p.dob_male + "'" +
                "," + fet.fet_date + " = '" + p.fet_date + "'" +
                "," + fet.doctor_id + " = '" + p.doctor_id + "'" +
                "," + fet.proce_id + " = '" + p.proce_id + "'" +
                "," + fet.date_create + " = now()" +
                "," + fet.date_modi + " = '" + p.date_modi + "'" +
                "," + fet.date_cancel + " = '" + p.date_cancel + "'" +
                "," + fet.user_create + " = '" + userId + "'" +
                "," + fet.user_modi + " = '" + p.user_modi + "'" +
                "," + fet.user_cancel + " = '" + p.user_cancel + "'" +
                "," + fet.req_id + " = '" + p.req_id + "'" +
                "," + fet.status_fet + " = '1'" +
                "," + fet.date_pic_embryo + " = '" + p.date_pic_embryo + "'" +
                "," + fet.hn_donor + " = '" + p.hn_donor + "'" +
                "," + fet.name_donor + " = '" + p.name_donor + "'" +
                "," + fet.dob_donor + " = '" + p.dob_donor + "'" +
                "," + fet.fet_time + " = '" + p.fet_time + "'" +
                "," + fet.embryo_freez_freeze_media + " = '" + p.embryo_freez_freeze_media + "'" +
                "," + fet.remark1 + " = '" + p.remark1 + "'" +
                "," + fet.remark2 + " = '" + p.remark2 + "'" +
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
        public String update(LabFet p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + fet.table + " Set " +
                //" " + fet.opu_code + " = '" + p.opu_code + "'" +
                //" " + fet.embryo_freez_stage + " = '" + p.embryo_freez_stage.Replace("'", "''") + "'" +
                //"," + fet.embryoid_freez_position + " = '" + p.embryoid_freez_position + "'" +
                " " + fet.hn_male + " = '" + p.hn_male.Replace("'", "''") + "'" +
                "," + fet.hn_female + " = '" + p.hn_female.Replace("'", "''") + "'" +
                "," + fet.name_male + " = '" + p.name_male.Replace("'", "''") + "'" +
                "," + fet.dob_female + " = '" + p.dob_female.Replace("'", "''") + "'" +
                "," + fet.name_female + " = '" + p.name_female.Replace("'", "''") + "'" +
                "," + fet.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + fet.dob_male + " = '" + p.dob_male + "'" +
                "," + fet.fet_date + " = '" + p.fet_date + "'" +
                "," + fet.doctor_id + " = '" + p.doctor_id + "'" +
                "," + fet.proce_id + " = '" + p.proce_id + "'" +
                "," + fet.date_modi + " = now()" +
                "," + fet.user_modi + " = '" + userId + "' " +
                "," + fet.date_pic_embryo + " = '" + p.date_pic_embryo + "' " +
                "," + fet.hn_donor + " = '" + p.hn_donor + "' " +
                "," + fet.name_donor + " = '" + p.name_donor.Replace("'", "''") + "' " +
                "," + fet.dob_donor + " = '" + p.dob_donor + "'" +
                //"," + fet.embryo_freez_freeze_media + " = '" + p.embryo_freez_freeze_media + "'" +
                "Where " + fet.pkField + "='" + p.fet_id + "'";

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
        public String updateEmbryoEt(LabFet p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + fet.table + " Set " +

                " " + fet.embryo_for_et_no_of_et + " = '" + p.embryo_for_et_no_of_et.Replace("'", "''") + "'" +
                "," + fet.embryo_for_et_day + " = '" + p.embryo_for_et_day.Replace("'", "''") + "'" +
                "," + fet.embryo_for_et_date + " = '" + p.embryo_for_et_date.Replace("'", "''") + "'" +
                "," + fet.embryo_for_et_assisted + " = '" + p.embryo_for_et_assisted.Replace("'", "''") + "'" +
                "," + fet.embryo_for_et_volume + " = '" + p.embryo_for_et_volume.Replace("'", "''") + "'" +
                "," + fet.embryo_for_et_catheter + " = '" + p.embryo_for_et_catheter.Replace("'", "''") + "'" +
                "," + fet.embryo_for_et_doctor + " = '" + p.embryo_for_et_doctor + "'" +
                "," + fet.embryo_for_et_embryologist_id + " = '" + p.embryo_for_et_embryologist_id + "'" +
                "," + fet.embryologist_approve_id + " = '" + p.embryologist_approve_id + "'" +
                "," + fet.embryo_for_et_number_of_transfer + " = '" + p.embryo_for_et_number_of_transfer + "'" +
                "," + fet.embryo_for_et_number_of_freeze + " = '" + p.embryo_for_et_number_of_freeze + "'" +
                "," + fet.embryo_for_et_number_of_discard + " = '" + p.embryo_for_et_number_of_discard + "'" +
                "," + fet.embryologist_report_id + " = '" + p.embryologist_report_id + "'" +
                "," + fet.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + fet.embryo_for_et_remark + " = '" + p.embryo_for_et_remark.Replace("'", "''") + "'" +
                "," + fet.remark1 + " = '" + p.remark1.Replace("'", "''") + "'" +
                "," + fet.remark2 + " = '" + p.remark2.Replace("'", "''") + "'" +
                "Where " + fet.pkField + "='" + p.fet_id + "'"
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
        public String updateThawingNoofThaw(String noofthaw, String fetid, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            //chkNull(p);
            sql = "Update " + fet.table + " Set " +
                //" " + fet.opu_code + " = '" + p.opu_code + "'" +
                //" " + fet.embryo_freez_stage + " = '" + p.embryo_freez_stage.Replace("'", "''") + "'" +
                //"," + fet.embryoid_freez_position + " = '" + p.embryoid_freez_position + "'" +
                " " + fet.thaw_no_of_thaw + " = '" + noofthaw + "'" +
                //"," + fet.freeze_no_of_freeze + " = '" + p.freeze_no_of_freeze.Replace("'", "''") + "'" +
                //"," + fet.freeze_stage_of_freeze + " = '" + p.freeze_stage_of_freeze.Replace("'", "''") + "'" +
                //"," + fet.thaw_date + " = '" + p.thaw_date.Replace("'", "''") + "'" +
                //"," + fet.thaw_no_of_thaw + " = '" + p.thaw_no_of_thaw.Replace("'", "''") + "'" +
                //"," + fet.thaw_no_of_survival + " = '" + p.thaw_no_of_survival.Replace("'", "''") + "'" +
                //"," + fet.thaw_no_of_remaining + " = '" + p.thaw_no_of_remaining + "'" +
                //"," + fet.freeze_date1 + " = '" + p.freeze_date1 + "'" +
                //"," + fet.media_exp + " = '" + p.media_exp + "'" +
                //"," + fet.media_lot_no + " = '" + p.media_lot_no + "'" +
                //"," + fet.date_modi + " = now()" +
                //"," + fet.user_modi + " = '" + userId + "' " +
                //"," + fet.media_thawing + " = '" + p.media_thawing + "' " +
                //"," + fet.embryo_freez_freeze_media + " = '" + p.embryo_freez_freeze_media + "'" +
                "Where " + fet.pkField + "='" + fetid + "'";
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
        public String updateThawing(LabFet p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + fet.table + " Set " +
                //" " + fet.opu_code + " = '" + p.opu_code + "'" +
                //" " + fet.embryo_freez_stage + " = '" + p.embryo_freez_stage.Replace("'", "''") + "'" +
                //"," + fet.embryoid_freez_position + " = '" + p.embryoid_freez_position + "'" +
                " " + fet.freeze_date + " = '" + p.freeze_date.Replace("'", "''") + "'" +
                "," + fet.freeze_no_of_freeze + " = '" + p.freeze_no_of_freeze.Replace("'", "''") + "'" +
                "," + fet.freeze_stage_of_freeze + " = '" + p.freeze_stage_of_freeze.Replace("'", "''") + "'" +
                "," + fet.thaw_date + " = '" + p.thaw_date.Replace("'", "''") + "'" +
                "," + fet.thaw_no_of_thaw + " = '" + p.thaw_no_of_thaw.Replace("'", "''") + "'" +
                "," + fet.thaw_no_of_survival + " = '" + p.thaw_no_of_survival.Replace("'", "''") + "'" +
                "," + fet.thaw_no_of_remaining + " = '" + p.thaw_no_of_remaining + "'" +
                "," + fet.freeze_date1 + " = '" + p.freeze_date1 + "'" +
                "," + fet.media_exp + " = '" + p.media_exp + "'" +
                "," + fet.media_lot_no + " = '" + p.media_lot_no + "'" +
                "," + fet.date_modi + " = now()" +
                "," + fet.user_modi + " = '" + userId + "' " +
                "," + fet.media_thawing + " = '" + p.media_thawing + "' " +
                "," + fet.embryo_freez_freeze_media + " = '" + p.embryo_freez_freeze_media + "'" +
                "Where " + fet.pkField + "='" + p.fet_id + "'";
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
        public String updateEmbryoPicDay(String fetid, String day)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            
            sql = "Update " + fet.table + " Set " +
                " " + fet.embryo_pic_day + " = '" + day + "'" +                
                "Where " + fet.pkField + "='" + fetid + "'";
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
        public String updateEmbryoPicDay1(String fetid, String day)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Update " + fet.table + " Set " +
                " " + fet.embryo_pic_day1 + " = '" + day + "'" +
                "Where " + fet.pkField + "='" + fetid + "'";
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
        public String updateStatusFETApproveResult(String opuid, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            //chkNull(p);
            sql = "Update " + fet.table + " Set " +
                " " + fet.status_fet + " = '2'" +
                "," + fet.approve_result_staff_id + " = '" + userId + "'" +
                "Where " + fet.pkField + "='" + opuid + "'"
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
        public String VoidLabFET(String fetid, String userid)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Update " + fet.table + " Set " +
                " " + fet.active + " = '3'" +
                "," + fet.user_cancel + " = '"+ userid + "'" +
                "," + fet.date_cancel + " = now() " +
                "Where " + fet.pkField + "='" + fetid + "'";
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
        public String updateReport(String fetid, String filename, String userid)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Update " + fet.table + " Set " +
                " " + fet.report + " = '"+ filename+"' " +
                "Where " + fet.pkField + "='" + fetid + "'";
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
        public LabFet setLabFET(DataTable dt)
        {
            LabFet fet1 = new LabFet();
            if (dt.Rows.Count > 0)
            {
                //lbReq1.req_id = dt.Rows[0][lbReq.req_id].ToString();
                fet1.fet_id = dt.Rows[0][fet.fet_id].ToString();
                fet1.fet_code = dt.Rows[0][fet.fet_code].ToString();
                
                fet1.hn_male = dt.Rows[0][fet.hn_male].ToString();
                fet1.hn_female = dt.Rows[0][fet.hn_female].ToString();
                fet1.name_male = dt.Rows[0][fet.name_male].ToString();
                fet1.name_female = dt.Rows[0][fet.name_female].ToString();
                fet1.dob_male = dt.Rows[0][fet.dob_male].ToString();
                fet1.dob_female = dt.Rows[0][fet.dob_female].ToString();
                fet1.doctor_id = dt.Rows[0][fet.doctor_id].ToString();
                fet1.proce_id = dt.Rows[0][fet.proce_id].ToString();
                fet1.fet_date = dt.Rows[0][fet.fet_date].ToString();
                //opu1.no_of_opu = dt.Rows[0][fet.no_of_opu].ToString();
                

                fet1.embryo_for_et_no_of_et = dt.Rows[0][fet.embryo_for_et_no_of_et].ToString();
                fet1.embryo_for_et_day = dt.Rows[0][fet.embryo_for_et_day].ToString();
                fet1.embryo_for_et_date = dt.Rows[0][fet.embryo_for_et_date].ToString();
                fet1.embryo_for_et_assisted = dt.Rows[0][fet.embryo_for_et_assisted].ToString();
                fet1.embryo_for_et_remark = dt.Rows[0][fet.embryo_for_et_remark].ToString();
                fet1.embryo_for_et_volume = dt.Rows[0][fet.embryo_for_et_volume].ToString();
                fet1.embryo_for_et_catheter = dt.Rows[0][fet.embryo_for_et_catheter].ToString();
                fet1.embryo_for_et_doctor = dt.Rows[0][fet.embryo_for_et_doctor].ToString();
                fet1.embryo_for_et_embryologist_id = dt.Rows[0][fet.embryo_for_et_embryologist_id].ToString();
                fet1.embryo_for_et_number_of_transfer = dt.Rows[0][fet.embryo_for_et_number_of_transfer].ToString();
                fet1.embryo_for_et_number_of_freeze = dt.Rows[0][fet.embryo_for_et_number_of_freeze].ToString();
                fet1.embryo_for_et_number_of_discard = dt.Rows[0][fet.embryo_for_et_number_of_discard].ToString();
                fet1.embryologist_report_id = dt.Rows[0][fet.embryologist_report_id].ToString();
                fet1.embryologist_approve_id = dt.Rows[0][fet.embryologist_approve_id].ToString();
                fet1.date_create = dt.Rows[0][fet.date_create].ToString();
                fet1.date_modi = dt.Rows[0][fet.date_modi].ToString();
                fet1.date_cancel = dt.Rows[0][fet.date_cancel].ToString();
                fet1.user_create = dt.Rows[0][fet.user_create].ToString();
                fet1.user_modi = dt.Rows[0][fet.user_modi].ToString();
                fet1.user_cancel = dt.Rows[0][fet.user_cancel].ToString();
                fet1.active = dt.Rows[0][fet.active].ToString();
                fet1.remark = dt.Rows[0][fet.remark].ToString();
                
                fet1.req_id = dt.Rows[0][fet.req_id].ToString();
                fet1.status_fet = dt.Rows[0][fet.status_fet].ToString();
                fet1.doctor_name = dt.Rows[0]["Name"].ToString();
                fet1.proce_name = dt.Rows[0]["proce_name_t"].ToString();
                
                fet1.date_pic_embryo = dt.Rows[0][fet.date_pic_embryo].ToString();
                fet1.hn_donor = dt.Rows[0][fet.hn_donor].ToString();
                fet1.name_donor = dt.Rows[0][fet.name_donor].ToString();
                fet1.dob_donor = dt.Rows[0][fet.dob_donor].ToString();
                //fet1.approve_result_staff_id = dt.Rows[0][fet.approve_result_staff_id].ToString();
                //fet1.status_approve_result_day1 = dt.Rows[0][fet.status_approve_result_day1].ToString();
                //fet1.status_approve_result_day3 = dt.Rows[0][fet.status_approve_result_day3].ToString();
                //fet1.status_approve_result_day5 = dt.Rows[0][fet.status_approve_result_day5].ToString();
                //fet1.approve_result_day1_staff_id = dt.Rows[0][fet.approve_result_day1_staff_id].ToString();
                //fet1.approve_result_day3_staff_id = dt.Rows[0][fet.approve_result_day3_staff_id].ToString();
                //fet1.approve_result_day5_staff_id = dt.Rows[0][fet.approve_result_day5_staff_id].ToString();
                //fet1.approve_result_day1_date = dt.Rows[0][fet.approve_result_day1_date].ToString();
                fet1.remark1 = dt.Rows[0][fet.remark1].ToString();
                fet1.remark2 = dt.Rows[0][fet.remark2].ToString();
                fet1.fet_time = dt.Rows[0][fet.fet_time].ToString();

                fet1.freeze_date = dt.Rows[0][fet.freeze_date].ToString();
                fet1.freeze_no_of_freeze = dt.Rows[0][fet.freeze_no_of_freeze].ToString();
                fet1.freeze_stage_of_freeze = dt.Rows[0][fet.freeze_stage_of_freeze].ToString();
                fet1.thaw_date = dt.Rows[0][fet.thaw_date].ToString();
                fet1.thaw_no_of_thaw = dt.Rows[0][fet.thaw_no_of_thaw].ToString();
                fet1.thaw_no_of_survival = dt.Rows[0][fet.thaw_no_of_survival].ToString();
                fet1.thaw_no_of_remaining = dt.Rows[0][fet.thaw_no_of_remaining].ToString();
                fet1.media_date = dt.Rows[0][fet.media_date].ToString();
                fet1.media_lot_no = dt.Rows[0][fet.media_lot_no].ToString();
                fet1.media_exp = dt.Rows[0][fet.media_exp].ToString();
                fet1.media_thawing = dt.Rows[0][fet.media_thawing].ToString();
                fet1.embryo_freez_freeze_media = dt.Rows[0][fet.embryo_freez_freeze_media].ToString();
                fet1.embryo_pic_day = dt.Rows[0][fet.embryo_pic_day].ToString();
                fet1.embryo_pic_day1 = dt.Rows[0][fet.embryo_pic_day1].ToString();
                fet1.freeze_date1 = dt.Rows[0][fet.freeze_date1].ToString();
                fet1.report = dt.Rows[0][fet.report].ToString();
            }
            else
            {
                fet1.fet_id = "";
                fet1.fet_code = "";
                
                fet1.hn_male = "";
                fet1.hn_female = "";
                fet1.name_male = "";
                fet1.name_female = "";
                fet1.dob_male = "";
                fet1.dob_female = "";
                fet1.doctor_id = "";
                fet1.proce_id = "";
                fet1.fet_date = "";
                //opu1.no_of_opu = "";                

                fet1.embryo_for_et_no_of_et = "";
                fet1.embryo_for_et_day = "";
                fet1.embryo_for_et_date = "";
                fet1.embryo_for_et_assisted = "";
                fet1.embryo_for_et_remark = "";
                fet1.embryo_for_et_volume = "";
                fet1.embryo_for_et_catheter = "";
                fet1.embryo_for_et_doctor = "";
                fet1.embryo_for_et_embryologist_id = "";
                fet1.embryo_for_et_number_of_transfer = "";
                fet1.embryo_for_et_number_of_freeze = "";
                fet1.embryo_for_et_number_of_discard = "";
                fet1.embryologist_report_id = "";
                fet1.embryologist_approve_id = "";
                fet1.date_create = "";
                fet1.date_modi = "";
                fet1.date_cancel = "";
                fet1.user_create = "";
                fet1.user_modi = "";
                fet1.user_cancel = "";
                fet1.active = "";
                fet1.remark = "";

                
                fet1.req_id = "";
                fet1.status_fet = "";
                fet1.doctor_name = "";
                fet1.proce_name = "";
                fet1.doctor_name = "";
                fet1.proce_name = "";
                fet1.date_pic_embryo = "";
                fet1.hn_donor = "";
                fet1.name_donor = "";
                fet1.dob_donor = "";
                fet1.approve_result_staff_id = "";
                fet1.status_approve_result_day1 = "";
                fet1.status_approve_result_day3 = "";
                fet1.status_approve_result_day5 = "";
                fet1.approve_result_day1_staff_id = "";
                fet1.approve_result_day3_staff_id = "";
                fet1.approve_result_day5_staff_id = "";
                fet1.approve_result_day1_date = "";
                fet1.approve_result_day3_date = "";
                fet1.approve_result_day5_date = "";
                fet1.fet_time = "";

                fet1.freeze_date = "";
                fet1.freeze_no_of_freeze = "";
                fet1.freeze_stage_of_freeze = "";
                fet1.thaw_date = "";
                fet1.thaw_no_of_thaw = "";
                fet1.thaw_no_of_survival = "";
                fet1.thaw_no_of_remaining = "";
                fet1.media_date = "";
                fet1.media_lot_no = "";
                fet1.media_exp = "";
                fet1.media_thawing = "";
                fet1.embryo_freez_freeze_media = "";
                fet1.embryo_pic_day = "";
                fet1.embryo_pic_day1 = "";
                fet1.remark1 = "";
                fet1.remark2 = "";
                fet1.freeze_date1 = "";
                fet1.report = "";
            }

            return fet1;
        }
    }
}
