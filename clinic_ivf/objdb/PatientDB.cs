using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class PatientDB
    {
        Patient ptt;
        ConnectDB conn;

        public PatientDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            ptt = new Patient();
            ptt.t_patient_id  = "t_patient_id";
            ptt.patient_hn  = "patient_hn";
            ptt.f_patient_prefix_id  = "f_patient_prefix_id";
            ptt.patient_firstname  = "patient_firstname";
            ptt.patient_lastname  = "patient_lastname";
            ptt.patient_xn  = "patient_xn";
            ptt.f_sex_id  = "f_sex_id";
            ptt.patient_birthday  = "patient_birthday";
            ptt.patient_house  = "patient_house";
            ptt.patient_road  = "patient_road";
            ptt.patient_moo  = "patient_moo";
            ptt.patient_tambon  = "patient_tambon";
            ptt.patient_amphur  = "patient_amphur";
            ptt.patient_changwat  = "patient_changwat";
            ptt.f_patient_marriage_status_id  = "f_patient_marriage_status_id";
            ptt.f_patient_occupation_id  = "f_patient_occupation_id";
            ptt.f_patient_race_id  = "f_patient_race_id";
            ptt.f_patient_nation_id  = "f_patient_nation_id";
            ptt.f_patient_religion_id  = "f_patient_religion_id";
            ptt.f_patient_education_type_id  = "f_patient_education_type_id";
            ptt.f_patient_family_status_id  = "f_patient_family_status_id";
            ptt.patient_father_firstname  = "patient_father_firstname";
            ptt.patient_mother_firstname  = "patient_mother_firstname";
            ptt.patient_couple_firstname  = "patient_couple_firstname";
            ptt.patient_move_in_date_time  = "patient_move_in_date_time";
            ptt.f_patient_discharge_status_id  = "f_patient_discharge_status_id";
            ptt.patient_discharge_date_time  = "patient_discharge_date_time";
            ptt.f_patient_blood_group_id  = "f_patient_blood_group_id";
            ptt.f_patient_foreigner_id  = "f_patient_foreigner_id";
            ptt.f_patient_area_status_id  = "f_patient_area_status_id";
            ptt.patient_father_pid  = "patient_father_pid";
            ptt.patient_mather_pid  = "patient_mather_pid";
            ptt.patient_couple_pid  = "patient_couple_pid";
            ptt.patient_community_status  = "patient_community_status";
            ptt.patient_private_doctor  = "patient_private_doctor";
            ptt.patient_pid  = "patient_pid";
            ptt.patient_mother_lastname  = "patient_mother_lastname";
            ptt.patient_father_lastname  = "patient_father_lastname";
            ptt.patient_couple_lastname  = "patient_couple_lastname";
            ptt.patient_phone_number  = "patient_phone_number";
            ptt.f_patient_relation_id  = "f_patient_relation_id";
            ptt.patient_contact_phone_number  = "patient_contact_phone_number";
            ptt.patient_contact_sex_id  = "patient_contact_sex_id";
            ptt.patient_contact_house  = "patient_contact_house";
            ptt.patient_contact_moo  = "patient_contact_moo";
            ptt.patient_contact_changwat  = "patient_contact_changwat";
            ptt.patient_contact_amphur  = "patient_contact_amphur";
            ptt.patient_contact_tambon  = "patient_contact_tambon";
            ptt.patient_contact_road  = "patient_contact_road";
            ptt.patient_contact_firstname  = "patient_contact_firstname";
            ptt.patient_contact_lastname  = "patient_contact_lastname";
            ptt.patient_birthday_true  = "patient_birthday_true";
            ptt.patient_merged  = "patient_merged";
            ptt.patient_record_date_time  = "patient_record_date_time";
            ptt.patient_update_date_time  = "patient_update_date_time";
            ptt.patient_staff_record  = "patient_staff_record";
            ptt.patient_staff_modify  = "patient_staff_modify";
            ptt.patient_staff_cancel  = "patient_staff_cancel";
            ptt.patient_active  = "patient_active";
            ptt.patient_drugallergy  = "patient_drugallergy";
            ptt.patient_language_for_print  = "patient_language_for_print";
            ptt.patient_patient_mobile_phone  = "patient_patient_mobile_phone";
            ptt.patient_contact_mobile_phone  = "patient_contact_mobile_phone";
            ptt.patient_has_home_in_pcu  = "patient_has_home_in_pcu";
            ptt.t_health_family_id  = "t_health_family_id";
            ptt.patient_other_country_address  = "patient_other_country_address";
            ptt.patient_is_other_country  = "patient_is_other_country";
            ptt.contact_id  = "contact_id";
            ptt.contact_namet  = "contact_namet";
            ptt.remark1  = "remark1";
            ptt.remark2  = "remark2";
            ptt.contact_join_id  = "contact_join_id";
            ptt.contact_join_namet  = "contact_join_namet";
            ptt.ss_patient_hn  = "ss_patient_hn";
            ptt.patient_soi  = "patient_soi";
            ptt.patient_contact_soi  = "patient_contact_soi";
            ptt.status_chronic  = "status_chronic";
            ptt.status_hiv  = "status_hiv";
            ptt.patient_status_hiv  = "patient_status_hiv";
            ptt.status_deny_allergy  = "status_deny_allergy";
            ptt.latitude  = "latitude";
            ptt.longitude  = "longitude";
            ptt.t_person_id  = "t_person_id";
            ptt.patient_patient_email  = "patient_patient_email";
            ptt.patient_contact_email  = "patient_contact_email";
            ptt.picture_profile  = "picture_profile";
        }
    }
}
