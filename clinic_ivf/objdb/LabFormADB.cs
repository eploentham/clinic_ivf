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
    public class LabFormADB
    {
        public LabFormA lformA;
        ConnectDB conn;

        public LabFormADB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lformA = new LabFormA();
            lformA.form_a_id= "form_a_id";
            lformA.t_patient_id= "t_patient_id";
            lformA.t_visit_id= "t_visit_id";
            lformA.opu_date= "opu_date";
            lformA.no_of_oocyte_rt= "no_of_oocyte_rt";
            lformA.no_of_oocyte_lt= "no_of_oocyte_lt";
            lformA.status_fresh_sperm= "status_fresh_sperm";
            lformA.status_frozen_sperm= "status_frozen_sperm";
            lformA.status_sperm_ha= "status_sperm_ha";
            lformA.status_pgs= "status_pgs";
            lformA.status_ngs= "status_ngs";
            lformA.ngs_day= "ngs_day";
            lformA.status_embryo_tranfer= "status_embryo_tranfer";
            lformA.embryo_tranfer_fresh_cycle= "embryo_tranfer_fresh_cycle";
            lformA.embryo_tranfer_frozen_cycle= "embryo_tranfer_frozen_cycle";
            lformA.status_embryo_freezing= "status_embryo_freezing";
            lformA.embryo_freezing_day= "embryo_freezing_day";
            lformA.embryo_tranfer_date= "embryo_tranfer_date";
            lformA.status_et_no_to_tranfer= "status_et_no_to_tranfer";
            lformA.status_fet= "status_fet";
            lformA.fet_no= "fet_no";
            lformA.fet_no_date_freezing= "fet_no_date_freezing";
            lformA.status_embryo_glue= "status_embryo_glue";
            lformA.status_fet1= "status_fet1";
            lformA.fet1_no= "fet1_no";
            lformA.fet1_no_date_freezing= "fet1_no_date_freezing";
            lformA.status_sperm_analysis= "status_sperm_analysis";
            lformA.status_spern_freezing= "status_spern_freezing";
            lformA.pasa_tese_date= "pasa_tese_date";
            lformA.iui_date= "iui_date";
            lformA.lab_t_form_acol= "lab_t_form_acol";
            lformA.sperm_analysis_date_start= "sperm_analysis_date_start";
            lformA.sperm_analysis_date_end= "sperm_analysis_date_end";
            lformA.spern_freezing_date_start= "spern_freezing_date_start";
            lformA.spern_freezing_date_end= "spern_freezing_date_end";
            lformA.active= "active";
            lformA.remark= "remark";
            lformA.date_create= "date_create";
            lformA.date_modi= "date_modi";
            lformA.date_cancel= "date_cancel";
            lformA.user_create= "user_create";
            lformA.user_modi= "user_modi";
            lformA.user_cancel= "user_cancel";
            lformA.vn_old= "vn_old";
            lformA.hn_old= "hn_old";
            lformA.form_a_code = "form_a_code";
            lformA.status_assist_hatching = "status_assist_hatching";
            lformA.hn_male = "hn_male";
            lformA.hn_female = "hn_female";
            lformA.name_male = "name_male";
            lformA.name_female = "name_female";
            lformA.fresh_sperm_collect_time = "fresh_sperm_collect_time";
            lformA.fresh_sperm_end_time = "fresh_sperm_end_time";
            lformA.doctor_id = "doctor_id";
            lformA.form_a_date = "form_a_date";
            lformA.hn_donor = "hn_donor";
            lformA.name_donor = "name_donor";
            lformA.dob_donor = "dob_donor";
            lformA.dob_female = "dob_female";
            lformA.dob_male = "dob_male";
            lformA.y_selection = "y_selection";
            lformA.x_selection = "x_selection";
            lformA.status_wait_confirm_day1 = "status_wait_confirm_day1";
            lformA.status_wait_confirm_opu_date = "status_wait_confirm_opu_date";
            lformA.req_id_et = "req_id_et";
            lformA.req_id_fet = "req_id_fet";
            lformA.req_id_iui = "req_id_iui";
            lformA.req_id_opu = "req_id_opu";
            lformA.req_id_pesa_tese = "req_id_pesa_tese";
            lformA.opu_time = "opu_time";
            lformA.status_opu_active = "status_opu_active";
            lformA.opu_wait_remark = "opu_wait_remark";
            lformA.opu_remark = "opu_remark";
            lformA.fet_remark = "fet_remark";

            lformA.pkField = "form_a_id";
            lformA.table = "lab_t_form_a";

        }
        private void chkNull(LabFormA p)
        {
            long chk = 0;
            decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.opu_date = p.opu_date == null ? "" : p.opu_date;
            p.no_of_oocyte_rt = p.no_of_oocyte_rt == null ? "" : p.no_of_oocyte_rt;
            p.no_of_oocyte_lt = p.no_of_oocyte_lt == null ? "" : p.no_of_oocyte_lt;
            p.status_fresh_sperm = p.status_fresh_sperm == null ? "" : p.status_fresh_sperm;
            p.status_frozen_sperm = p.status_frozen_sperm == null ? "" : p.status_frozen_sperm;
            p.status_sperm_ha = p.status_sperm_ha == null ? "" : p.status_sperm_ha;
            p.status_pgs = p.status_pgs == null ? "" : p.status_pgs;
            p.status_ngs = p.status_ngs == null ? "" : p.status_ngs;
            //p.t_visit_id = p.t_visit_id == null ? "" : p.t_visit_id;
            p.ngs_day = p.ngs_day == null ? "" : p.ngs_day;
            p.status_embryo_tranfer = p.status_embryo_tranfer == null ? "" : p.status_embryo_tranfer;
            p.embryo_tranfer_fresh_cycle = p.embryo_tranfer_fresh_cycle == null ? "" : p.embryo_tranfer_fresh_cycle;
            p.embryo_tranfer_frozen_cycle = p.embryo_tranfer_frozen_cycle == null ? "" : p.embryo_tranfer_frozen_cycle;
            p.status_embryo_freezing = p.status_embryo_freezing == null ? "" : p.status_embryo_freezing;
            p.embryo_freezing_day = p.embryo_freezing_day == null ? "" : p.embryo_freezing_day;
            p.embryo_tranfer_date = p.embryo_tranfer_date == null ? "" : p.embryo_tranfer_date;
            p.status_et_no_to_tranfer = p.status_et_no_to_tranfer == null ? "" : p.status_et_no_to_tranfer;
            p.status_fet = p.status_fet == null ? "" : p.status_fet;
            p.fet_no = p.fet_no == null ? "" : p.fet_no;
            p.fet_no_date_freezing = p.fet_no_date_freezing == null ? "" : p.fet_no_date_freezing;
            p.status_embryo_glue = p.status_embryo_glue == null ? "" : p.status_embryo_glue;
            p.status_fet1 = p.status_fet1 == null ? "" : p.status_fet1;
            p.fet1_no = p.fet1_no == null ? "" : p.fet1_no;
            p.fet1_no_date_freezing = p.fet1_no_date_freezing == null ? "" : p.fet1_no_date_freezing;
            p.status_sperm_analysis = p.status_sperm_analysis == null ? "" : p.status_sperm_analysis;
            p.status_spern_freezing = p.status_spern_freezing == null ? "" : p.status_spern_freezing;
            p.pasa_tese_date = p.pasa_tese_date == null ? "" : p.pasa_tese_date;
            p.iui_date = p.iui_date == null ? "" : p.iui_date;
            p.lab_t_form_acol = p.lab_t_form_acol == null ? "" : p.lab_t_form_acol;
            p.sperm_analysis_date_start = p.sperm_analysis_date_start == null ? "" : p.sperm_analysis_date_start;
            p.sperm_analysis_date_end = p.sperm_analysis_date_end == null ? "" : p.sperm_analysis_date_end;
            p.spern_freezing_date_start = p.spern_freezing_date_start == null ? "" : p.spern_freezing_date_start;
            p.spern_freezing_date_end = p.spern_freezing_date_end == null ? "" : p.spern_freezing_date_end;
            p.active = p.active == null ? "" : p.active;
            p.remark = p.remark == null ? "" : p.remark;
            p.hn_old = p.hn_old == null ? "" : p.hn_old;
            p.form_a_code = p.form_a_code == null ? "" : p.form_a_code;
            p.status_assist_hatching = p.status_assist_hatching == null ? "" : p.status_assist_hatching;
            p.hn_male = p.hn_male == null ? "" : p.hn_male;
            p.hn_female = p.hn_female == null ? "" : p.hn_female;
            p.name_male = p.name_male == null ? "" : p.name_male;
            p.name_female = p.name_female == null ? "" : p.name_female;
            p.fresh_sperm_collect_time = p.fresh_sperm_collect_time == null ? "" : p.fresh_sperm_collect_time;
            p.fresh_sperm_end_time = p.fresh_sperm_end_time == null ? "" : p.fresh_sperm_end_time;
            p.form_a_date = p.form_a_date == null ? "" : p.form_a_date;
            p.hn_donor = p.hn_donor == null ? "" : p.hn_donor;
            p.name_donor = p.name_donor == null ? "" : p.name_donor;
            p.dob_donor = p.dob_donor == null ? "" : p.dob_donor;
            p.dob_female = p.dob_female == null ? "" : p.dob_female;
            p.dob_male = p.dob_male == null ? "" : p.dob_male;
            p.y_selection = p.y_selection == null ? "0" : p.y_selection;
            p.x_selection = p.x_selection == null ? "0" : p.x_selection;
            p.status_wait_confirm_day1 = p.status_wait_confirm_day1 == null ? "0" : p.status_wait_confirm_day1;
            p.status_wait_confirm_opu_date = p.status_wait_confirm_opu_date == null ? "0" : p.status_wait_confirm_opu_date;
            p.opu_time = p.opu_time == null ? "" : p.opu_time;
            p.status_opu_active = p.status_opu_active == null ? "0" : p.status_opu_active;
            p.opu_wait_remark = p.opu_wait_remark == null ? "" : p.opu_wait_remark;
            p.opu_remark = p.opu_remark == null ? "" : p.opu_remark;
            p.fet_remark = p.fet_remark == null ? "" : p.fet_remark;
            //p.fet = p.fet == null ? "0" : p.fet;
            //p.hormone_test = p.hormone_test == null ? "0" : p.hormone_test;
            //p.other = p.other == null ? "0" : p.other;
            //p.beta_hgc = p.beta_hgc == null ? "0" : p.beta_hgc;
            //p.patient_appointment_doctor = p.patient_appointment_doctor == null ? "0" : p.patient_appointment_doctor;
            //p.sperm_collect = p.sperm_collect == null ? "0" : p.sperm_collect;

            p.t_patient_id = long.TryParse(p.t_patient_id, out chk) ? chk.ToString() : "0";
            p.t_visit_id = long.TryParse(p.t_visit_id, out chk) ? chk.ToString() : "0";
            p.vn_old = long.TryParse(p.vn_old, out chk) ? chk.ToString() : "0";
            p.doctor_id = long.TryParse(p.doctor_id, out chk) ? chk.ToString() : "0";
            p.req_id_et = long.TryParse(p.req_id_et, out chk) ? chk.ToString() : "0";
            p.req_id_fet = long.TryParse(p.req_id_fet, out chk) ? chk.ToString() : "0";
            p.req_id_iui = long.TryParse(p.req_id_iui, out chk) ? chk.ToString() : "0";
            p.req_id_opu = long.TryParse(p.req_id_opu, out chk) ? chk.ToString() : "0";
            p.req_id_pesa_tese = long.TryParse(p.req_id_pesa_tese, out chk) ? chk.ToString() : "0";

        }
        public String insert(LabFormA p, String userId)
        {
            String re = "";
            String sql = "";

            chkNull(p);
            try
            {
                sql = "Insert Into " + lformA.table + " " +
                    "Set " + lformA.t_patient_id + "='" + p.t_patient_id + "'" +                    
                    "," + lformA.t_visit_id + "='" + p.t_visit_id + "'" +
                    "," + lformA.opu_date + "='" + p.opu_date + "'" +
                    "," + lformA.no_of_oocyte_rt + "='" + p.no_of_oocyte_rt + "'" +
                    "," + lformA.no_of_oocyte_lt + "='" + p.no_of_oocyte_lt + "'" +
                    "," + lformA.status_fresh_sperm + "='" + p.status_fresh_sperm + "'" +
                    "," + lformA.status_frozen_sperm + "='" + p.status_frozen_sperm + "'" +
                    "," + lformA.status_sperm_ha + "='" + p.status_sperm_ha + "'" +
                    "," + lformA.status_pgs + "='" + p.status_pgs + "'" +
                    "," + lformA.status_ngs + "='" + p.status_ngs + "'" +
                    "," + lformA.ngs_day + "='" + p.ngs_day + "'" +
                    "," + lformA.status_embryo_tranfer + "='" + p.status_embryo_tranfer + "'" +
                    "," + lformA.embryo_tranfer_fresh_cycle + "='" + p.embryo_tranfer_fresh_cycle + "'" +
                    "," + lformA.embryo_tranfer_frozen_cycle + "='" + p.embryo_tranfer_frozen_cycle + "'" +
                    "," + lformA.status_embryo_freezing + "='" + p.status_embryo_freezing + "'" +
                    "," + lformA.embryo_freezing_day + "='" + p.embryo_freezing_day + "'" +
                    "," + lformA.embryo_tranfer_date + "='" + p.embryo_tranfer_date + "'" +
                    "," + lformA.status_et_no_to_tranfer + "='" + p.status_et_no_to_tranfer + "'" +
                    "," + lformA.status_fet + "='" + p.status_fet + "'" +
                    "," + lformA.fet_no + "='" + p.fet_no + "'" +
                    "," + lformA.fet_no_date_freezing + "='" + p.fet_no_date_freezing + "'" +
                    "," + lformA.status_embryo_glue + "='" + p.status_embryo_glue + "'" +
                    "," + lformA.status_fet1 + "='" + p.status_fet1 + "'" +
                    "," + lformA.fet1_no + "='" + p.fet1_no + "'" +
                    "," + lformA.fet1_no_date_freezing + "='" + p.fet1_no_date_freezing + "'" +
                    "," + lformA.status_sperm_analysis + "='" + p.status_sperm_analysis + "'" +
                    "," + lformA.status_spern_freezing + "='" + p.status_spern_freezing + "'" +
                    "," + lformA.pasa_tese_date + "='" + p.pasa_tese_date + "'" +
                    "," + lformA.iui_date + "='" + p.iui_date + "'" +
                    "," + lformA.lab_t_form_acol + "='" + p.lab_t_form_acol + "'" +
                    "," + lformA.sperm_analysis_date_start + "='" + p.sperm_analysis_date_start + "'" +
                    "," + lformA.sperm_analysis_date_end + "='" + p.sperm_analysis_date_end + "'" +
                    "," + lformA.spern_freezing_date_start + "='" + p.spern_freezing_date_start + "'" +
                    "," + lformA.spern_freezing_date_end + "='" + p.spern_freezing_date_end + "'" +
                    "," + lformA.active + "='" + p.active + "' " +
                    "," + lformA.remark + "='" + p.remark + "' " +
                    "," + lformA.date_create + "=now() " +
                    "," + lformA.date_modi + "='" + p.date_modi + "' " +

                    "," + lformA.date_cancel + "='" + p.date_cancel + "' " +
                    "," + lformA.user_create + "='" + userId + "' " +
                    "," + lformA.user_modi + "='" + p.user_modi + "' " +
                    "," + lformA.user_cancel + "='" + p.user_cancel + "' " +
                    "," + lformA.vn_old + "='" + p.vn_old + "' " +
                    "," + lformA.hn_old + "='" + p.hn_old + "' " +
                    "," + lformA.form_a_code + "='" + p.form_a_code + "' " +
                    "," + lformA.status_assist_hatching + "='" + p.status_assist_hatching + "' " +
                    "," + lformA.hn_male + "='" + p.hn_male + "' " +
                    "," + lformA.hn_female + "='" + p.hn_female + "' " +
                    "," + lformA.name_male + "='" + p.name_male + "' " +
                    "," + lformA.name_female + "='" + p.name_female + "' " +
                    "," + lformA.fresh_sperm_collect_time + "='" + p.fresh_sperm_collect_time + "' " +
                    "," + lformA.fresh_sperm_end_time + "='" + p.fresh_sperm_end_time + "' " +
                    "," + lformA.doctor_id + "='" + p.doctor_id + "' " +
                    "," + lformA.form_a_date + "='" + p.form_a_date + "' " +
                    "," + lformA.hn_donor + "='" + p.hn_donor + "' " +
                    "," + lformA.name_donor + "='" + p.name_donor + "' " +
                    "," + lformA.dob_donor + "='" + p.dob_donor + "' " +
                    "," + lformA.dob_female + "='" + p.dob_female + "' " +
                    "," + lformA.dob_male + "='" + p.dob_male + "' " +
                    "," + lformA.y_selection + "='" + p.y_selection + "' " +
                    "," + lformA.x_selection + "='" + p.x_selection + "' " +
                    "," + lformA.status_wait_confirm_day1 + "='" + p.status_wait_confirm_day1 + "' " +
                    "," + lformA.status_wait_confirm_opu_date + "='" + p.status_wait_confirm_opu_date + "' " +
                    "," + lformA.req_id_et + "='" + p.req_id_et + "' " +
                    "," + lformA.req_id_fet + "='" + p.req_id_fet + "' " +
                    "," + lformA.req_id_iui + "='" + p.req_id_iui + "' " +
                    "," + lformA.req_id_opu + "='" + p.req_id_opu + "' " +
                    "," + lformA.req_id_pesa_tese + "='" + p.req_id_pesa_tese + "' " +
                    "," + lformA.opu_time + "='" + p.opu_time + "' " +
                    "," + lformA.status_opu_active + "='" + p.status_opu_active + "' " +
                    "," + lformA.opu_wait_remark + "='" + p.opu_wait_remark + "' " +
                    "," + lformA.opu_remark + "='" + p.opu_remark + "' " +
                    "," + lformA.fet_remark + "='" + p.fet_remark + "' " +
                    "";
                re = conn.ExecuteNonQuery(conn.conn, sql);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
            }
            return re;
        }
        public String update(LabFormA p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + lformA.table + " " +
                //" Set "+lformA.patient_appoint_date_time + "='"+p.patient_appoint_date_time + "' " +
                "Set " + lformA.t_patient_id + "='" + p.t_patient_id.Replace("'", "''") + "' " +
                "," + lformA.t_visit_id + "='" + p.t_visit_id + "'" +
                    "," + lformA.opu_date + "='" + p.opu_date + "'" +
                    "," + lformA.no_of_oocyte_rt + "='" + p.no_of_oocyte_rt + "'" +
                    "," + lformA.no_of_oocyte_lt + "='" + p.no_of_oocyte_lt + "'" +
                    "," + lformA.status_fresh_sperm + "='" + p.status_fresh_sperm + "'" +
                    "," + lformA.status_frozen_sperm + "='" + p.status_frozen_sperm + "'" +
                    "," + lformA.status_sperm_ha + "='" + p.status_sperm_ha + "'" +
                    "," + lformA.status_pgs + "='" + p.status_pgs + "'" +
                    "," + lformA.status_ngs + "='" + p.status_ngs + "'" +
                    "," + lformA.ngs_day + "='" + p.ngs_day + "'" +
                    "," + lformA.status_embryo_tranfer + "='" + p.status_embryo_tranfer + "'" +
                    "," + lformA.embryo_tranfer_fresh_cycle + "='" + p.embryo_tranfer_fresh_cycle + "'" +
                    "," + lformA.embryo_tranfer_frozen_cycle + "='" + p.embryo_tranfer_frozen_cycle + "'" +
                    "," + lformA.status_embryo_freezing + "='" + p.status_embryo_freezing + "'" +
                    "," + lformA.embryo_freezing_day + "='" + p.embryo_freezing_day + "'" +
                    "," + lformA.embryo_tranfer_date + "='" + p.embryo_tranfer_date + "'" +
                    "," + lformA.status_et_no_to_tranfer + "='" + p.status_et_no_to_tranfer + "'" +
                    "," + lformA.status_fet + "='" + p.status_fet + "'" +
                    "," + lformA.fet_no + "='" + p.fet_no + "'" +
                    "," + lformA.fet_no_date_freezing + "='" + p.fet_no_date_freezing + "'" +
                    "," + lformA.status_embryo_glue + "='" + p.status_embryo_glue + "'" +
                    "," + lformA.status_fet1 + "='" + p.status_fet1 + "'" +
                    "," + lformA.fet1_no + "='" + p.fet1_no + "'" +
                    "," + lformA.fet1_no_date_freezing + "='" + p.fet1_no_date_freezing + "'" +
                    "," + lformA.status_sperm_analysis + "='" + p.status_sperm_analysis + "'" +
                    "," + lformA.status_spern_freezing + "='" + p.status_spern_freezing + "'" +
                    "," + lformA.pasa_tese_date + "='" + p.pasa_tese_date + "'" +
                    "," + lformA.iui_date + "='" + p.iui_date + "'" +
                    "," + lformA.lab_t_form_acol + "='" + p.lab_t_form_acol + "'" +
                    "," + lformA.sperm_analysis_date_start + "='" + p.sperm_analysis_date_start + "'" +
                    "," + lformA.sperm_analysis_date_end + "='" + p.sperm_analysis_date_end + "'" +
                    "," + lformA.spern_freezing_date_start + "='" + p.spern_freezing_date_start + "'" +
                    "," + lformA.spern_freezing_date_end + "='" + p.spern_freezing_date_end + "'" +
                    "," + lformA.active + "='" + p.active + "' " +
                    "," + lformA.remark + "='" + p.remark.Replace("'", "''") + "' " +
                    "," + lformA.date_modi + "=now() " +
                    "," + lformA.user_modi + "='" + userId + "' " +
                    "," + lformA.vn_old + "='" + p.vn_old + "' " +
                    "," + lformA.hn_old + "='" + p.hn_old + "' " +
                    //"," + lformA.form_a_code + "='" + p.form_a_code + "' " +
                    "," + lformA.status_assist_hatching + "='" + p.status_assist_hatching + "' " +
                    "," + lformA.hn_male + "='" + p.hn_male + "' " +
                    "," + lformA.hn_female + "='" + p.hn_female + "' " +
                    "," + lformA.name_male + "='" + p.name_male + "' " +
                    "," + lformA.name_female + "='" + p.name_female + "' " +
                    "," + lformA.fresh_sperm_collect_time + "='" + p.fresh_sperm_collect_time + "' " +
                    "," + lformA.fresh_sperm_end_time + "='" + p.fresh_sperm_end_time + "' " +
                    "," + lformA.doctor_id + "='" + p.doctor_id + "' " +
                    "," + lformA.form_a_date + "='" + p.form_a_date + "' " +
                    "," + lformA.hn_donor + "='" + p.hn_donor + "' " +
                    "," + lformA.name_donor + "='" + p.name_donor + "' " +
                    "," + lformA.dob_donor + "='" + p.dob_donor + "' " +
                    "," + lformA.dob_female + "='" + p.dob_female + "' " +
                    "," + lformA.dob_male + "='" + p.dob_male + "' " +
                    "," + lformA.y_selection + "='" + p.y_selection + "' " +
                    "," + lformA.x_selection + "='" + p.x_selection + "' " +
                    "," + lformA.status_wait_confirm_day1 + "='" + p.status_wait_confirm_day1 + "' " +
                    "," + lformA.status_wait_confirm_opu_date + "='" + p.status_wait_confirm_opu_date + "' " +
                    "," + lformA.opu_time + "='" + p.opu_time + "' " +
                    "," + lformA.status_opu_active + "='" + p.status_opu_active + "' " +
                    "," + lformA.opu_wait_remark + "='" + p.opu_wait_remark + "' " +
                    "," + lformA.opu_remark + "='" + p.opu_remark + "' " +
                    "," + lformA.fet_remark + "='" + p.fet_remark + "' " +
                " Where " + lformA.pkField + " = '" + p.form_a_id + "' "
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
        public String insertLabFormA(LabFormA p, String userId)
        {
            String re = "";

            if (p.form_a_id.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
            }

            return re;
        }
        public String updateReqIdOPU(String id, String reqid)
        {
            String re = "";
            String sql = "";
            
            sql = "Update " + lformA.table + " " +
                //" Set "+lformA.patient_appoint_date_time + "='"+p.patient_appoint_date_time + "' " +
                "Set " + lformA.req_id_opu + "='" + reqid + "' " +                    
                " Where " + lformA.pkField + " = '" + id + "' ";
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
        public String updateReqIdFet(String id, String reqid)
        {
            String re = "";
            String sql = "";

            sql = "Update " + lformA.table + " " +
                //" Set "+lformA.patient_appoint_date_time + "='"+p.patient_appoint_date_time + "' " +
                "Set " + lformA.req_id_fet + "='" + reqid + "' " +
                " Where " + lformA.pkField + " = '" + id + "' ";
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
        public String updateReqIdET(String id, String reqid)
        {
            String re = "";
            String sql = "";

            sql = "Update " + lformA.table + " " +
                //" Set "+lformA.patient_appoint_date_time + "='"+p.patient_appoint_date_time + "' " +
                "Set " + lformA.req_id_et + "='" + reqid + "' " +
                " Where " + lformA.pkField + " = '" + id + "' ";
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
        public String updateReqIdIUI(String id, String reqid)
        {
            String re = "";
            String sql = "";

            sql = "Update " + lformA.table + " " +
                //" Set "+lformA.patient_appoint_date_time + "='"+p.patient_appoint_date_time + "' " +
                "Set " + lformA.req_id_iui + "='" + reqid + "' " +
                " Where " + lformA.pkField + " = '" + id + "' ";
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
        public String updateReqIdPESATESE(String id, String reqid)
        {
            String re = "";
            String sql = "";

            sql = "Update " + lformA.table + " " +
                //" Set "+lformA.patient_appoint_date_time + "='"+p.patient_appoint_date_time + "' " +
                "Set " + lformA.req_id_pesa_tese + "='" + reqid + "' " +
                " Where " + lformA.pkField + " = '" + id + "' ";
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
        public DataTable selectReportByPk(String pttId)
        {
            DataTable dt = new DataTable();
            String sql = "select lformA.*,CONCAT(IFNULL(sfn.SurfixName,''),' ', ptt_f.PName ,' ',ptt_f.PSurname ) as name_female  " +
                ",CONCAT(IFNULL(sfnm.SurfixName,''),' ', ptt_m.PName ,' ',ptt_m.PSurname ) as name_male, dtr.Name as doctor_name " +
                "From " + lformA.table + " lformA " +
                "Left Join Patient as ptt_f on ptt_f.PIDS = lformA.hn_female " +
                "Left Join SurfixName sfn on sfn.SurfixID = ptt_f.SurfixID " +
                "Left Join Patient as ptt_m on ptt_m.PIDS = lformA.hn_male " +
                "Left Join SurfixName sfnm on sfnm.SurfixID = ptt_m.SurfixID " +
                "Left Join Doctor as dtr on dtr.ID = lformA.doctor_id " +
                "Where lformA." + lformA.pkField + " ='" + pttId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByPk(String pttId)
        {
            DataTable dt = new DataTable();
            String sql = "select lformA.* " +
                "From " + lformA.table + " lformA " +
                "Where lformA." + lformA.pkField + " ='" + pttId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public LabFormA selectByPk1(String pttId)
        {
            LabFormA cop1 = new LabFormA();
            DataTable dt = new DataTable();
            String sql = "select lformA.* " +
                "From " + lformA.table + " lformA " +
                "Where lformA." + lformA.pkField + " ='" + pttId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setLabFormA(dt);
            return cop1;
        }
        public LabFormA selectByVnOld(String pttId)
        {
            LabFormA cop1 = new LabFormA();
            DataTable dt = new DataTable();
            String sql = "select lformA.* " +
                "From " + lformA.table + " lformA " +
                "Where lformA." + lformA.vn_old + " ='" + pttId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setLabFormA(dt);
            return cop1;
        }
        public DataTable selectDistinctByRemark()
        {
            DataTable dt = new DataTable();
            String sql = "select distinct lformA.remark " +
                "From " + lformA.table + " lformA " +
                "Where lformA." + lformA.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public C1ComboBox setCboRemark(C1ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectDistinctByRemark();
            //String aaa = "";
            ComboBoxItem item1 = new ComboBoxItem();
            //item1.Text = "";
            //item1.Value = "";
            c.Items.Clear();
            //c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                item = new ComboBoxItem();
                item.Text = row[lformA.remark].ToString();
                item.Value = i.ToString();

                c.Items.Add(item);
                i++;
            }
            return c;
        }
        public DataTable selectDistinctByOPUWaitRemark()
        {
            DataTable dt = new DataTable();
            String sql = "select distinct lformA.opu_wait_remark " +
                "From " + lformA.table + " lformA " +
                "Where lformA." + lformA.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public C1ComboBox setCboOPUWaitRemark(C1ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectDistinctByOPUWaitRemark();
            //String aaa = "";
            ComboBoxItem item1 = new ComboBoxItem();
            //item1.Text = "";
            //item1.Value = "";
            c.Items.Clear();
            //c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                item = new ComboBoxItem();
                item.Text = row[lformA.opu_wait_remark].ToString();
                item.Value = i.ToString();

                c.Items.Add(item);
                i++;
            }
            return c;
        }
        public LabFormA setLabFormA(DataTable dt)
        {
            LabFormA vs1 = new LabFormA();
            if (dt.Rows.Count > 0)
            {
                vs1.form_a_id = dt.Rows[0][lformA.form_a_id].ToString();
                vs1.t_patient_id = dt.Rows[0][lformA.t_patient_id].ToString();
                vs1.t_visit_id = dt.Rows[0][lformA.t_visit_id].ToString();
                vs1.opu_date = dt.Rows[0][lformA.opu_date].ToString();
                vs1.no_of_oocyte_rt = dt.Rows[0][lformA.no_of_oocyte_rt].ToString();
                vs1.no_of_oocyte_lt = dt.Rows[0][lformA.no_of_oocyte_lt].ToString();
                vs1.status_fresh_sperm = dt.Rows[0][lformA.status_fresh_sperm].ToString();
                vs1.status_frozen_sperm = dt.Rows[0][lformA.status_frozen_sperm].ToString();
                vs1.status_sperm_ha = dt.Rows[0][lformA.status_sperm_ha].ToString();
                vs1.status_pgs = dt.Rows[0][lformA.status_pgs].ToString();
                vs1.status_ngs = dt.Rows[0][lformA.status_ngs].ToString();
                vs1.ngs_day = dt.Rows[0][lformA.ngs_day].ToString();
                vs1.status_embryo_tranfer = dt.Rows[0][lformA.status_embryo_tranfer].ToString();
                vs1.embryo_tranfer_fresh_cycle = dt.Rows[0][lformA.embryo_tranfer_fresh_cycle].ToString();
                vs1.embryo_tranfer_frozen_cycle = dt.Rows[0][lformA.embryo_tranfer_frozen_cycle].ToString();
                vs1.status_embryo_freezing = dt.Rows[0][lformA.status_embryo_freezing].ToString();
                vs1.embryo_freezing_day = dt.Rows[0][lformA.embryo_freezing_day].ToString();
                vs1.embryo_tranfer_date = dt.Rows[0][lformA.embryo_tranfer_date].ToString();
                vs1.status_et_no_to_tranfer = dt.Rows[0][lformA.status_et_no_to_tranfer].ToString();
                vs1.status_fet = dt.Rows[0][lformA.status_fet].ToString();
                vs1.fet_no = dt.Rows[0][lformA.fet_no].ToString();
                vs1.fet_no_date_freezing = dt.Rows[0][lformA.fet_no_date_freezing].ToString();
                vs1.status_embryo_glue = dt.Rows[0][lformA.status_embryo_glue].ToString();
                vs1.status_fet1 = dt.Rows[0][lformA.status_fet1].ToString();
                vs1.fet1_no = dt.Rows[0][lformA.fet1_no].ToString();
                vs1.fet1_no_date_freezing = dt.Rows[0][lformA.fet1_no_date_freezing].ToString();
                vs1.status_sperm_analysis = dt.Rows[0][lformA.status_sperm_analysis].ToString();
                vs1.status_spern_freezing = dt.Rows[0][lformA.status_spern_freezing].ToString();
                vs1.pasa_tese_date = dt.Rows[0][lformA.pasa_tese_date].ToString();
                vs1.iui_date = dt.Rows[0][lformA.iui_date].ToString();
                vs1.lab_t_form_acol = dt.Rows[0][lformA.lab_t_form_acol].ToString();
                vs1.sperm_analysis_date_start = dt.Rows[0][lformA.sperm_analysis_date_start].ToString();
                vs1.sperm_analysis_date_end = dt.Rows[0][lformA.sperm_analysis_date_end].ToString();
                vs1.spern_freezing_date_start = dt.Rows[0][lformA.spern_freezing_date_start].ToString();
                vs1.spern_freezing_date_end = dt.Rows[0][lformA.spern_freezing_date_end].ToString();
                vs1.active = dt.Rows[0][lformA.active].ToString();
                vs1.remark = dt.Rows[0][lformA.remark].ToString();
                vs1.date_create = dt.Rows[0][lformA.date_create].ToString();
                vs1.date_modi = dt.Rows[0][lformA.date_modi].ToString();
                vs1.date_cancel = dt.Rows[0][lformA.date_cancel].ToString();
                vs1.user_create = dt.Rows[0][lformA.user_create].ToString();
                vs1.user_modi = dt.Rows[0][lformA.user_modi].ToString();
                vs1.user_cancel = dt.Rows[0][lformA.user_cancel].ToString();
                vs1.vn_old = dt.Rows[0][lformA.vn_old].ToString();
                vs1.hn_old = dt.Rows[0][lformA.hn_old].ToString();
                vs1.form_a_code = dt.Rows[0][lformA.form_a_code].ToString();
                vs1.status_assist_hatching = dt.Rows[0][lformA.status_assist_hatching].ToString();
                vs1.hn_male = dt.Rows[0][lformA.hn_male].ToString();
                vs1.hn_female = dt.Rows[0][lformA.hn_female].ToString();
                vs1.name_male = dt.Rows[0][lformA.name_male].ToString();
                vs1.name_female = dt.Rows[0][lformA.name_female].ToString();
                vs1.fresh_sperm_collect_time = dt.Rows[0][lformA.fresh_sperm_collect_time].ToString();
                vs1.fresh_sperm_end_time = dt.Rows[0][lformA.fresh_sperm_end_time].ToString();
                vs1.doctor_id = dt.Rows[0][lformA.doctor_id].ToString();
                vs1.form_a_date = dt.Rows[0][lformA.form_a_date].ToString();
                vs1.hn_donor = dt.Rows[0][lformA.hn_donor].ToString();
                vs1.name_donor = dt.Rows[0][lformA.name_donor].ToString();
                vs1.dob_donor = dt.Rows[0][lformA.dob_donor].ToString();
                vs1.dob_female = dt.Rows[0][lformA.dob_female].ToString();
                vs1.dob_male = dt.Rows[0][lformA.dob_male].ToString();
                vs1.y_selection = dt.Rows[0][lformA.y_selection].ToString();
                vs1.x_selection = dt.Rows[0][lformA.x_selection].ToString();
                vs1.status_wait_confirm_day1 = dt.Rows[0][lformA.status_wait_confirm_day1].ToString();
                vs1.status_wait_confirm_opu_date = dt.Rows[0][lformA.status_wait_confirm_opu_date].ToString();
                vs1.req_id_et = dt.Rows[0][lformA.req_id_et].ToString();
                vs1.req_id_fet = dt.Rows[0][lformA.req_id_fet].ToString();
                vs1.req_id_iui = dt.Rows[0][lformA.req_id_iui].ToString();
                vs1.req_id_opu = dt.Rows[0][lformA.req_id_opu].ToString();
                vs1.req_id_pesa_tese = dt.Rows[0][lformA.req_id_pesa_tese].ToString();
                vs1.opu_time = dt.Rows[0][lformA.opu_time].ToString();
                vs1.status_opu_active = dt.Rows[0][lformA.status_opu_active].ToString();
                vs1.opu_wait_remark = dt.Rows[0][lformA.opu_wait_remark].ToString();
                vs1.opu_remark = dt.Rows[0][lformA.opu_remark].ToString();
                vs1.fet_remark = dt.Rows[0][lformA.fet_remark].ToString();
            }
            else
            {
                setLabFormA1(vs1);
            }
            return vs1;
        }
        public LabFormA setLabFormA1(LabFormA lforma1)
        {
            lforma1.form_a_id = "";
            lforma1.t_patient_id = "";
            lforma1.t_visit_id = "";
            lforma1.opu_date = "";
            lforma1.no_of_oocyte_rt = "";
            lforma1.no_of_oocyte_lt = "";
            lforma1.status_fresh_sperm = "";
            lforma1.status_frozen_sperm = "";
            lforma1.status_sperm_ha = "";
            lforma1.status_pgs = "";
            lforma1.status_ngs = "";
            lforma1.ngs_day = "";
            lforma1.status_embryo_tranfer = "";
            lforma1.embryo_tranfer_fresh_cycle = "";
            lforma1.embryo_tranfer_frozen_cycle = "";
            lforma1.status_embryo_freezing = "";
            lforma1.embryo_freezing_day = "";
            lforma1.embryo_tranfer_date = "";
            lforma1.status_et_no_to_tranfer = "";
            lforma1.status_fet = "";
            lforma1.fet_no = "";
            lforma1.fet_no_date_freezing = "";
            lforma1.status_embryo_glue = "";
            lforma1.status_fet1 = "";
            lforma1.fet1_no = "";
            lforma1.fet1_no_date_freezing = "";
            lforma1.status_sperm_analysis = "";
            lforma1.status_spern_freezing = "";
            lforma1.pasa_tese_date = "";
            lforma1.iui_date = "";
            lforma1.lab_t_form_acol = "";
            lforma1.sperm_analysis_date_start = "";
            lforma1.sperm_analysis_date_end = "";
            lforma1.spern_freezing_date_start = "";
            lforma1.spern_freezing_date_end = "";
            lforma1.active = "";
            lforma1.remark = "";
            lforma1.date_create = "";
            lforma1.date_modi = "";
            lforma1.date_cancel = "";
            lforma1.user_create = "";
            lforma1.user_modi = "";
            lforma1.user_cancel = "";
            lforma1.vn_old = "";
            lforma1.hn_old = "";
            lforma1.form_a_code = "";
            lforma1.status_assist_hatching = "";
            lforma1.hn_male = "";
            lforma1.hn_female = "";
            lforma1.name_male = "";
            lforma1.name_female = "";
            lforma1.fresh_sperm_collect_time = "";
            lforma1.fresh_sperm_end_time = "";
            lforma1.doctor_id = "";
            lforma1.form_a_date = "";
            lforma1.hn_donor = "";
            lforma1.name_donor = "";
            lforma1.dob_donor = "";
            lforma1.dob_female = "";
            lforma1.dob_male = "";
            lforma1.y_selection = "";
            lforma1.x_selection = "";
            lforma1.status_wait_confirm_day1 = "";
            lforma1.status_wait_confirm_opu_date = "";
            lforma1.req_id_et = "";
            lforma1.req_id_fet = "";
            lforma1.req_id_iui = "";
            lforma1.req_id_opu = "";
            lforma1.req_id_pesa_tese = "";
            lforma1.opu_time = "";
            lforma1.status_opu_active = "";
            lforma1.opu_wait_remark = "";
            lforma1.opu_remark = "";
            lforma1.fet_remark = "";
            return lforma1;
        }
    }
}
