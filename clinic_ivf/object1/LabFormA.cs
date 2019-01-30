using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class LabFormA:Persistent
    {
        public String form_a_id { get; set; }
        public String t_patient_id { get; set; }
        public String t_visit_id { get; set; }
        public String opu_date { get; set; }
        public String no_of_oocyte_rt { get; set; }
        public String no_of_oocyte_lt { get; set; }
        public String status_fresh_sperm { get; set; }
        public String status_frozen_sperm { get; set; }
        public String status_sperm_ha { get; set; }
        public String status_pgs { get; set; }
        public String status_ngs { get; set; }
        public String ngs_day { get; set; }
        public String status_embryo_tranfer { get; set; }
        public String embryo_tranfer_fresh_cycle { get; set; }
        public String embryo_tranfer_frozen_cycle { get; set; }
        public String status_embryo_freezing { get; set; }
        public String embryo_freezing_day { get; set; }
        public String embryo_tranfer_date { get; set; }
        public String status_et_no_to_tranfer { get; set; }
        public String status_fet { get; set; }
        public String fet_no { get; set; }
        public String fet_no_date_freezing { get; set; }
        public String status_embryo_glue { get; set; }
        public String status_fet1 { get; set; }
        public String fet1_no { get; set; }
        public String fet1_no_date_freezing { get; set; }
        public String status_sperm_analysis { get; set; }
        public String status_spern_freezing { get; set; }
        public String pasa_tese_date { get; set; }
        public String iui_date { get; set; }
        public String lab_t_form_acol { get; set; }
        public String sperm_analysis_date_start { get; set; }
        public String sperm_analysis_date_end { get; set; }
        public String spern_freezing_date_start { get; set; }
        public String spern_freezing_date_end { get; set; }
        public String active { get; set; }
        public String remark { get; set; }
        public String date_create { get; set; }
        public String date_modi { get; set; }
        public String date_cancel { get; set; }
        public String user_create { get; set; }
        public String user_modi { get; set; }
        public String user_cancel { get; set; }
        public String vn_old { get; set; }
        public String hn_old { get; set; }
        public String form_a_code { get; set; }
        public String status_assist_hatching { get; set; }
        public String hn_male { get; set; }
        public String hn_female { get; set; }
        public String name_male { get; set; }
        public String name_female { get; set; }
        public String fresh_sperm_collect_time { get; set; }
        public String fresh_sperm_end_time { get; set; }
        public String doctor_id { get; set; }
        public String form_a_date { get; set; }
        public String hn_donor { get; set; }
        public String name_donor { get; set; }
        public String dob_donor { get; set; }
        public String dob_female { get; set; }
        public String dob_male { get; set; }
        public String y_selection { get; set; }
        public String x_selection { get; set; }
        public String status_wait_confirm_day1 { get; set; }
        public String status_wait_confirm_opu_date { get; set; }
        public String req_id_opu { get; set; }
        public String req_id_et { get; set; }
        public String req_id_fet { get; set; }
        public String req_id_iui { get; set; }
        public String req_id_pesa_tese { get; set; }
        public String opu_time { get; set; }
        public String status_opu_active { get; set; }
        public String opu_wait_remark { get; set; }
        public String opu_remark { get; set; }
        public String fet_remark { get; set; }
        public String status_fet_active { get; set; }
        public String fet_wait_remark { get; set; }
        public String status_wait_confirm_fet_date { get; set; }
        public String opu_time_modi { get; set; }
        public String status_opu_time_modi { get; set; }
    }
}
