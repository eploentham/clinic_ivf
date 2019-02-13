using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class LabOpu:Persistent
    {
        public String opu_id { get; set; }
        public String opu_code { get; set; }
        public String embryo_freez_stage { get; set; }
        public String embryoid_freez_position { get; set; }
        public String hn_male { get; set; }
        public String hn_female { get; set; }
        public String name_male { get; set; }
        public String name_female { get; set; }
        public String dob_male { get; set; }
        public String dob_female { get; set; }
        public String doctor_id { get; set; }
        public String proce_id { get; set; }
        public String opu_date { get; set; }
        //public String no_of_opu { get; set; }
        public String matura_date { get; set; }
        public String matura_m_ii { get; set; }
        public String matura_m_i { get; set; }
        public String matura_gv { get; set; }
        public String matura_abmormal { get; set; }
        public String matura_dead { get; set; }
        public String fertili_date { get; set; }
        public String fertili_2_pn { get; set; }
        public String fertili_1_pn { get; set; }
        public String fertili_3_pn { get; set; }
        public String fertili_4_pn { get; set; }
        public String fertili_no_pn { get; set; }
        public String fertili_dead { get; set; }
        public String sperm_date { get; set; }
        public String sperm_volume { get; set; }
        public String sperm_count { get; set; }
        public String sperm_count_total { get; set; }
        public String sperm_motile { get; set; }
        public String sperm_motile_total { get; set; }
        public String sperm_motility { get; set; }
        public String sperm_fresh_sperm { get; set; }
        public String sperm_frozen_sperm { get; set; }
        public String embryo_freez_date_0 { get; set; }
        public String embryo_freez_day_0 { get; set; }
        public String embryo_freez_no_og_0 { get; set; }
        public String embryo_freez_no_of_straw_0 { get; set; }
        public String embryo_freez_mothod_0 { get; set; }
        public String embryo_freez_freeze_media_0 { get; set; }
        public String embryo_freez_position_0 { get; set; }
        public String embryo_freez_stage_0 { get; set; }
        public String embryo_for_et_no_of_et { get; set; }
        public String embryo_for_et_day { get; set; }
        public String embryo_for_et_date { get; set; }
        public String embryo_for_et_assisted { get; set; }
        public String embryo_for_et_remark { get; set; }
        public String embryo_for_et_volume { get; set; }
        public String embryo_for_et_catheter { get; set; }
        public String embryo_for_et_doctor { get; set; }
        public String embryo_for_et_embryologist_id { get; set; }
        public String embryo_for_et_number_of_transfer { get; set; }
        public String embryo_for_et_number_of_freeze { get; set; }
        public String embryo_for_et_number_of_discard { get; set; }
        public String embryologist_report_id { get; set; }
        public String embryologist_approve_id { get; set; }
        public String date_create { get; set; }
        public String date_modi { get; set; }
        public String date_cancel { get; set; }
        public String user_create { get; set; }
        public String user_modi { get; set; }
        public String user_cancel { get; set; }
        public String active { get; set; }
        public String remark { get; set; }

        public String embryo_freez_date_1 { get; set; }
        public String embryo_freez_day_1 { get; set; }
        public String embryo_freez_no_og_1 { get; set; }
        public String embryo_freez_no_of_straw_1 { get; set; }
        public String embryo_freez_mothod_1 { get; set; }
        public String embryo_freez_freeze_media_1 { get; set; }
        public String embryo_freez_position_1 { get; set; }
        public String embryo_freez_stage_1 { get; set; }

        public String embryo_freez_date_2 { get; set; }
        public String embryo_freez_day_2 { get; set; }
        public String embryo_freez_no_og_2 { get; set; }
        public String embryo_freez_no_of_straw_2 { get; set; }
        public String embryo_freez_mothod_2 { get; set; }
        public String embryo_freez_freeze_media_2 { get; set; }
        public String embryo_freez_position_2 { get; set; }
        public String embryo_freez_stage_2{ get; set; }

        public String embryo_freez_date_3 { get; set; }
        public String embryo_freez_day_3 { get; set; }
        public String embryo_freez_no_og_3 { get; set; }
        public String embryo_freez_no_of_straw_3 { get; set; }
        public String embryo_freez_mothod_3 { get; set; }
        public String embryo_freez_freeze_media_3 { get; set; }
        public String embryo_freez_position_3 { get; set; }
        public String embryo_freez_stage_3 { get; set; }

        public String embryo_freez_date_4 { get; set; }
        public String embryo_freez_day_4 { get; set; }
        public String embryo_freez_no_og_4 { get; set; }
        public String embryo_freez_no_of_straw_4 { get; set; }
        public String embryo_freez_mothod_4 { get; set; }
        public String embryo_freez_freeze_media_4 { get; set; }
        public String embryo_freez_position_4 { get; set; }
        public String embryo_freez_stage_4 { get; set; }

        public String embryo_freez_date_5 { get; set; }
        public String embryo_freez_day_5 { get; set; }
        public String embryo_freez_no_og_5 { get; set; }
        public String embryo_freez_no_of_straw_5 { get; set; }
        public String embryo_freez_mothod_5 { get; set; }
        public String embryo_freez_freeze_media_5 { get; set; }
        public String embryo_freez_position_5 { get; set; }
        public String embryo_freez_stage_5 { get; set; }

        public String embryo_freez_date_6 { get; set; }
        public String embryo_freez_day_6 { get; set; }
        public String embryo_freez_no_og_6 { get; set; }
        public String embryo_freez_no_of_straw_6 { get; set; }
        public String embryo_freez_mothod_6 { get; set; }
        public String embryo_freez_freeze_media_6 { get; set; }
        public String embryo_freez_position_6 { get; set; }
        public String embryo_freez_stage_6 { get; set; }
        public String req_id { get; set; }
        public String status_opu { get; set; }

        public String doctor_name { get; set; }
        public String proce_name { get; set; }

        public String matura_no_of_opu { get; set; }
        public String matura_post_mat { get; set; }
        public String date_pic_embryo { get; set; }
        public String hn_donor { get; set; }
        public String name_donor { get; set; }
        public String remark_1 { get; set; }
        public String dob_donor { get; set; }
        public String approve_result_staff_id { get; set; }
        public String status_approve_result_day1 { get; set; }
        public String status_approve_result_day3 { get; set; }
        public String status_approve_result_day5 { get; set; }
        public String approve_result_day1_staff_id { get; set; }
        public String approve_result_day3_staff_id { get; set; }
        public String approve_result_day5_staff_id { get; set; }
        public String approve_result_day1_date { get; set; }
        public String approve_result_day3_date { get; set; }
        public String approve_result_day5_date { get; set; }
        public String opu_time { get; set; }
    }
}
