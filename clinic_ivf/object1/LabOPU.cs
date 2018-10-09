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
        public String no_of_opu { get; set; }
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
        public String sperm_vloume { get; set; }
        public String sperm_count { get; set; }
        public String sperm_count_total { get; set; }
        public String sperm_motile { get; set; }
        public String sperm_motile_total { get; set; }
        public String sperm_motility { get; set; }
        public String sperm_fresh_sperm { get; set; }
        public String sperm_frozen_sperm { get; set; }
        public String embryo_freez_date { get; set; }
        public String embryo_freez_day { get; set; }
        public String embryo_freez_no_og { get; set; }
        public String embryo_freez_no_of_straw { get; set; }
        public String embryo_freez_mothod { get; set; }
        public String embryo_freez_freeze_media { get; set; }
        public String embryo_for_et_no_of_et { get; set; }
        public String embbryo_for_et_day { get; set; }
        public String embbryo_for_et_date { get; set; }
        public String embbryo_for_et_assisted { get; set; }
        public String embbryo_for_et_remark { get; set; }
        public String embbryo_for_et_volume { get; set; }
        public String embbryo_for_et_catheter { get; set; }
        public String embbryo_for_et_doctor { get; set; }
        public String embbryo_for_et_embryologist_id { get; set; }
        public String embbryo_for_et_number_of_transfer { get; set; }
        public String embbryo_for_et_number_of_freeze { get; set; }
        public String embbryo_for_et_number_of_discard { get; set; }
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
    }
}
