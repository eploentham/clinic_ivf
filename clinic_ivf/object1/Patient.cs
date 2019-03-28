using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class Patient:Persistent
    {
        public String t_patient_id { get; set; }
        public String patient_hn { get; set; }
        public String f_patient_prefix_id { get; set; }
        public String patient_firstname { get; set; }
        public String patient_lastname { get; set; }
        public String patient_xn { get; set; }
        public String f_sex_id { get; set; }
        public String patient_birthday { get; set; }
        public String patient_house { get; set; }
        public String patient_road { get; set; }
        public String patient_moo { get; set; }
        public String patient_tambon { get; set; }
        public String patient_amphur { get; set; }
        public String patient_changwat { get; set; }
        public String f_patient_marriage_status_id { get; set; }
        public String f_patient_occupation_id { get; set; }
        public String f_patient_race_id { get; set; }
        public String f_patient_nation_id { get; set; }
        public String f_patient_religion_id { get; set; }
        public String f_patient_education_type_id { get; set; }
        public String f_patient_family_status_id { get; set; }
        public String patient_father_firstname { get; set; }
        public String patient_mother_firstname { get; set; }
        public String patient_couple_firstname { get; set; }
        public String patient_move_in_date_time { get; set; }
        public String f_patient_discharge_status_id { get; set; }
        public String patient_discharge_date_time { get; set; }
        public String f_patient_blood_group_id { get; set; }
        public String f_patient_foreigner_id { get; set; }
        public String f_patient_area_status_id { get; set; }
        public String patient_father_pid { get; set; }
        public String patient_mather_pid { get; set; }
        public String patient_couple_pid { get; set; }
        public String patient_community_status { get; set; }
        public String patient_private_doctor { get; set; }
        public String pid { get; set; }
        public String patient_mother_lastname { get; set; }
        public String patient_father_lastname { get; set; }
        public String patient_couple_lastname { get; set; }
        public String mobile1 { get; set; }
        public String f_patient_relation_id { get; set; }
        public String patient_contact_phone_number { get; set; }
        public String patient_contact_sex_id { get; set; }
        public String patient_contact_house { get; set; }
        public String patient_contact_moo { get; set; }
        public String patient_contact_changwat { get; set; }
        public String patient_contact_amphur { get; set; }
        public String patient_contact_tambon { get; set; }
        public String patient_contact_road { get; set; }
        public String patient_contact_firstname { get; set; }
        public String patient_contact_lastname { get; set; }
        public String patient_birthday_true { get; set; }
        public String patient_merged { get; set; }
        public String patient_record_date_time { get; set; }
        public String patient_update_date_time { get; set; }
        public String patient_staff_record { get; set; }
        public String patient_staff_modify { get; set; }
        public String patient_staff_cancel { get; set; }
        public String patient_active { get; set; }
        public String patient_drugallergy { get; set; }
        public String patient_language_for_print { get; set; }
        public String mobile2 { get; set; }
        public String patient_contact_mobile_phone { get; set; }
        public String patient_has_home_in_pcu { get; set; }
        public String t_health_family_id { get; set; }
        public String patient_other_country_address { get; set; }
        public String patient_is_other_country { get; set; }
        public String contact_id { get; set; }
        public String contact_namet { get; set; }
        public String remark1 { get; set; }
        public String remark2 { get; set; }
        public String contact_join_id { get; set; }
        public String contact_join_namet { get; set; }
        public String ss_patient_hn { get; set; }
        public String patient_soi { get; set; }
        public String patient_contact_soi { get; set; }
        public String status_chronic { get; set; }
        public String status_hiv { get; set; }
        public String patient_status_hiv { get; set; }
        public String status_deny_allergy { get; set; }
        public String latitude { get; set; }
        public String longitude { get; set; }
        public String t_person_id { get; set; }
        public String patient_patient_email { get; set; }
        public String patient_contact_email { get; set; }
        public String picture_profile { get; set; }
        public String line_id { get; set; }
        public String email { get; set; }
        public String passport { get; set; }
        public String patient_type { get; set; }
        public String patient_group { get; set; }
        public String agent { get; set; }
        public String status_convert { get; set; }
        public String patient_father_mobile { get; set; }
        public String patient_mother_mobile { get; set; }
        public String patient_couple_mobile { get; set; }
        public String patient_firstname_e { get; set; }
        public String patient_lastname_e { get; set; }
        public String contract { get; set; }

        public String insurance { get; set; }//patient_contact_f_patient_prefix_id
        public String patient_contact_f_patient_prefix_id { get; set; }
        public String patient_couple_f_patient_prefix_id { get; set; }
        public String patient_contact_f_patient_relation_id { get; set; }
        public String patient_coulpe_f_patient_relation_id { get; set; }
        public String b_contract_plans_id { get; set; }
        public String t_patient_id_old { get; set; }
        public String Name { get; set; }
        public String status_opu { get; set; }
        public String patient_nickname { get; set; }
        public String patient_height { get; set; }
        public String status_or { get; set; }
        public String or_description { get; set; }
        public String status_congenial { get; set; }
        public String congenital_diseases_description { get; set; }
        public String allergy_description { get; set; }
        public String status_g { get; set; }
        public String p { get; set; }
        public String a { get; set; }
        public String g { get; set; }

        public String emercontact { get; set; }
        public String patient_country { get; set; }
        public String addr { get; set; }
        public String patient_hn_couple { get; set; }
        public String doctor_id { get; set; }
        public Age age = new Age(DateTime.Now);
        public String AgeString()
        {            
            String re = "";
            DateTime dtB;
            if (DateTime.TryParse(patient_birthday, out dtB))
            {
                age = new Age(dtB);
                re = age.AgeString;
            }
            return re;
        }
        public String AgeStringShort()
        {
            String re = "";
            DateTime dtB;
            if (DateTime.TryParse(patient_birthday, out dtB))
            {
                age = new Age(dtB);
                //re = age.AgeString.Replace("Years", "Y").Replace("Year", "Y").Replace("Months", "M").Replace("Month", "M").Replace("Days", "D").Replace("Day", "D");
                re = age.Years+"."+age.Months+"."+age.Days;
            }
            return re;
        }

    }
}
