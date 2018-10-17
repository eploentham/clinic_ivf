using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class LabOpuDB
    {
        public LabOpu opu;
        ConnectDB conn;

        public LabOpuDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            opu = new LabOpu();
            opu.opu_id = "opu_id";
            opu.opu_code = "opu_code";
            opu.embryo_freez_stage = "embryo_freez_stage";
            opu.embryoid_freez_position = "embryoid_freez_position";
            opu.hn_male = "hn_male";
            opu.hn_female = "hn_female";
            opu.name_male = "name_male";
            opu.name_female = "name_female";
            opu.dob_male = "dob_male";
            opu.dob_female = "dob_female";
            opu.doctor_id = "doctor_id";
            opu.proce_id = "proce_id";
            opu.opu_date = "opu_date";
            opu.no_of_opu = "no_of_opu";
            opu.matura_date = "matura_date";
            opu.matura_m_ii = "matura_m_ii";
            opu.matura_m_i = "matura_m_i";
            opu.matura_gv = "matura_gv";
            opu.matura_abmormal = "matura_abmormal";
            opu.matura_dead = "matura_dead";
            opu.fertili_date = "fertili_date";
            opu.fertili_2_pn = "fertili_2_pn";
            opu.fertili_1_pn = "fertili_1_pn";
            opu.fertili_3_pn = "fertili_3_pn";
            opu.fertili_4_pn = "fertili_4_pn";
            opu.fertili_no_pn = "fertili_no_pn";
            opu.fertili_dead = "fertili_dead";
            opu.sperm_date = "sperm_date";
            opu.sperm_vloume = "sperm_vloume";
            opu.sperm_count = "sperm_count";
            opu.sperm_count_total = "sperm_count_total";
            opu.sperm_motile = "sperm_motile";
            opu.sperm_motile_total = "sperm_motile_total";
            opu.sperm_motility = "sperm_motility";
            opu.sperm_fresh_sperm = "sperm_fresh_sperm";
            opu.sperm_frozen_sperm = "sperm_frozen_sperm";
            opu.embryo_freez_date_0 = "embryo_freez_date_0";
            opu.embryo_freez_day_0 = "embryo_freez_day_0";
            opu.embryo_freez_no_og_0 = "embryo_freez_no_og_0";
            opu.embryo_freez_no_of_straw_0 = "embryo_freez_no_of_straw_0";
            opu.embryo_freez_mothod_0 = "embryo_freez_mothod_0";
            opu.embryo_freez_freeze_media_0 = "embryo_freez_freeze_media_0";
            opu.embryo_freez_position_0 = "embryo_freez_position_0";
            opu.embryo_freez_stage_0 = "embryo_freez_stage_0";

            opu.embryo_for_et_no_of_et = "embryo_for_et_no_of_et";
            opu.embbryo_for_et_day = "embbryo_for_et_day";
            opu.embbryo_for_et_date = "embbryo_for_et_date";
            opu.embbryo_for_et_assisted = "embbryo_for_et_assisted";
            opu.embbryo_for_et_remark = "embbryo_for_et_remark";
            opu.embbryo_for_et_volume = "embbryo_for_et_volume";
            opu.embbryo_for_et_catheter = "embbryo_for_et_catheter";
            opu.embbryo_for_et_doctor = "embbryo_for_et_doctor";
            opu.embbryo_for_et_embryologist_id = "embbryo_for_et_embryologist_id";
            opu.embbryo_for_et_number_of_transfer = "embbryo_for_et_number_of_transfer";
            opu.embbryo_for_et_number_of_freeze = "embbryo_for_et_number_of_freeze";
            opu.embbryo_for_et_number_of_discard = "embbryo_for_et_number_of_discard";
            opu.embryologist_report_id = "embryologist_report_id";
            opu.embryologist_approve_id = "embryologist_approve_id";
            opu.date_create = "date_create";
            opu.date_modi = "date_modi";
            opu.date_cancel = "date_cancel";
            opu.user_create = "user_create";
            opu.user_modi = "user_modi";
            opu.user_cancel = "user_cancel";
            opu.active = "active";
            opu.remark = "remark";

            opu.embryo_freez_date_1 = "embryo_freez_date_1";
            opu.embryo_freez_day_1 = "embryo_freez_day_1";
            opu.embryo_freez_no_og_1 = "embryo_freez_no_og_1";
            opu.embryo_freez_no_of_straw_1 = "embryo_freez_no_of_straw_1";
            opu.embryo_freez_mothod_1 = "embryo_freez_mothod_1";
            opu.embryo_freez_freeze_media_1 = "embryo_freez_freeze_media_1";
            opu.embryo_freez_position_1 = "embryo_freez_position_1";
            opu.embryo_freez_stage_1 = "embryo_freez_stage_1";

            opu.embryo_freez_date_2 = "embryo_freez_date_2";
            opu.embryo_freez_day_2 = "embryo_freez_day_2";
            opu.embryo_freez_no_og_2 = "embryo_freez_no_og_2";
            opu.embryo_freez_no_of_straw_2 = "embryo_freez_no_of_straw_2";
            opu.embryo_freez_mothod_2 = "embryo_freez_mothod_2";
            opu.embryo_freez_freeze_media_2 = "embryo_freez_freeze_media_2";
            opu.embryo_freez_position_2 = "embryo_freez_position_2";
            opu.embryo_freez_stage_2 = "embryo_freez_stage_2";

            opu.embryo_freez_date_3 = "embryo_freez_date_3";
            opu.embryo_freez_day_3 = "embryo_freez_day_3";
            opu.embryo_freez_no_og_3 = "embryo_freez_no_og_3";
            opu.embryo_freez_no_of_straw_3 = "embryo_freez_no_of_straw_3";
            opu.embryo_freez_mothod_3 = "embryo_freez_mothod_3";
            opu.embryo_freez_freeze_media_3 = "embryo_freez_freeze_media_3";
            opu.embryo_freez_position_3 = "embryo_freez_position_3";
            opu.embryo_freez_stage_3 = "embryo_freez_stage_3";

            opu.embryo_freez_date_4 = "embryo_freez_date_4";
            opu.embryo_freez_day_4 = "embryo_freez_day_4";
            opu.embryo_freez_no_og_4 = "embryo_freez_no_og_4";
            opu.embryo_freez_no_of_straw_4 = "embryo_freez_no_of_straw_4";
            opu.embryo_freez_mothod_4 = "embryo_freez_mothod_4";
            opu.embryo_freez_freeze_media_4 = "embryo_freez_freeze_media_4";
            opu.embryo_freez_position_4 = "embryo_freez_position_4";
            opu.embryo_freez_stage_4 = "embryo_freez_stage_4";

            opu.embryo_freez_date_5 = "embryo_freez_date_5";
            opu.embryo_freez_day_5 = "embryo_freez_day_5";
            opu.embryo_freez_no_og_5 = "embryo_freez_no_og_5";
            opu.embryo_freez_no_of_straw_5 = "embryo_freez_no_of_straw_5";
            opu.embryo_freez_mothod_5 = "embryo_freez_mothod_5";
            opu.embryo_freez_freeze_media_5 = "embryo_freez_freeze_media_5";
            opu.embryo_freez_position_5 = "embryo_freez_position_5";
            opu.embryo_freez_stage_5 = "embryo_freez_stage_5";

            opu.embryo_freez_date_6 = "embryo_freez_date_6";
            opu.embryo_freez_day_6 = "embryo_freez_day_6";
            opu.embryo_freez_no_og_6 = "embryo_freez_no_og_6";
            opu.embryo_freez_no_of_straw_6 = "embryo_freez_no_of_straw_6";
            opu.embryo_freez_mothod_6 = "embryo_freez_mothod_6";
            opu.embryo_freez_freeze_media_6 = "embryo_freez_freeze_media_6";
            opu.embryo_freez_position_6 = "embryo_freez_position_6";
            opu.embryo_freez_stage_6 = "embryo_freez_stage_6";
            opu.req_id = "req_id";
        }
        private void chkNull(LabOpu p)
        {
            int chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.opu_code = p.opu_code == null ? "" : p.opu_code;
            p.embryo_freez_stage = p.embryo_freez_stage == null ? "" : p.embryo_freez_stage;
            p.embryoid_freez_position = p.embryoid_freez_position == null ? "" : p.embryoid_freez_position;
            p.hn_male = p.hn_male == null ? "" : p.hn_male;
            p.hn_female = p.hn_female == null ? "" : p.hn_female;
            p.name_male = p.name_male == null ? "" : p.name_male;
            p.name_female = p.name_female == null ? "" : p.name_female;
            p.dob_male = p.dob_male == null ? "" : p.dob_male;
            p.dob_female = p.dob_female == null ? "" : p.dob_female;
            p.opu_date = p.opu_date == null ? "" : p.opu_date;
            //p.sort1 = p.sort1 == null ? "" : p.sort1;
            //p.sort1 = p.sort1 == null ? "" : p.sort1;

            p.remark = p.remark == null ? "" : p.remark;
            //p.sort1 = p.sort1 == null ? "" : p.sort1;

            p.doctor_id = int.TryParse(p.doctor_id, out chk) ? chk.ToString() : "0";
            p.proce_id = int.TryParse(p.proce_id, out chk) ? chk.ToString() : "0";
            p.req_id = int.TryParse(p.req_id, out chk) ? chk.ToString() : "0";

            //p.status_lab = p.status_lab == null ? "0" : p.status_lab;
        }
        public String insert(LabOpu p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            sql = "Insert Into " + opu.table + "(" + opu.opu_code + "," + opu.embryo_freez_stage + "," + opu.embryoid_freez_position + "," +
                opu.hn_male + "," + opu.hn_female + "," + opu.name_male + "," +
                opu.active + "," + opu.remark + "," + opu.dob_female + "," +
                opu.name_female + "," + opu.dob_male + "," + opu.opu_date + "," +
                opu.doctor_id + "," + opu.proce_id + "," +
                opu.date_create + "," + opu.date_modi + "," + opu.date_cancel + "," +
                opu.user_create + "," + opu.user_modi + "," + opu.user_cancel + ", " +
                opu.req_id + "," +
                ") " +
                "Values ('" + p.opu_code + "','" + p.embryo_freez_stage + "','" + p.embryoid_freez_position + "'," +
                "'" + p.hn_male.Replace("'", "''") + "','" + p.hn_female.Replace("'", "''") + "','" + p.name_male + "'," +
                "'" + p.active + "','" + p.remark + "','" + p.dob_female + "'," +
                "'" + p.name_female + "','" + p.dob_male + "','" + p.opu_date + "'," +
                "'" + p.doctor_id + "','" + p.proce_id + "'," +
                "now(),'" + p.date_modi + "','" + p.date_cancel + "'," +
                "'" + userId + "','" + p.user_modi + "','" + p.user_cancel + "', " +
                "'" + p.req_id + "' " +
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
        public String update(LabOpu p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + opu.table + " Set " +
                " " + opu.opu_code + " = '" + p.opu_code + "'" +
                "," + opu.embryo_freez_stage + " = '" + p.embryo_freez_stage.Replace("'", "''") + "'" +
                "," + opu.embryoid_freez_position + " = '" + p.embryoid_freez_position + "'" +
                "," + opu.hn_male + " = '" + p.hn_male.Replace("'", "''") + "'" +
                "," + opu.hn_female + " = '" + p.hn_female.Replace("'", "''") + "'" +
                "," + opu.name_male + " = '" + p.name_male.Replace("'", "''") + "'" +
                "," + opu.dob_female + " = '" + p.dob_female.Replace("'", "''") + "'" +
                "," + opu.name_female + " = '" + p.name_female.Replace("'", "''") + "'" +
                "," + opu.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + opu.dob_male + " = '" + p.dob_male + "'" +
                "," + opu.opu_date + " = '" + p.opu_date + "'" +
                "," + opu.doctor_id + " = '" + p.doctor_id + "'" +
                "," + opu.proce_id + " = '" + p.proce_id + "'" + 
                "," + opu.date_modi + " = now()" +
                "," + opu.user_modi + " = '" + userId + "' " +                
                "Where " + opu.pkField + "='" + p.opu_id + "'"
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
    }
}
