using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
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
            ptt.pid  = "pid";
            ptt.patient_mother_lastname  = "patient_mother_lastname";
            ptt.patient_father_lastname  = "patient_father_lastname";
            ptt.patient_couple_lastname  = "patient_couple_lastname";
            ptt.mobile1  = "mobile1";
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
            ptt.mobile2  = "mobile2";
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

            ptt.date_cancel = "date_cancel";
            ptt.date_create = "date_create";
            ptt.date_modi = "date_modi";
            ptt.user_cancel = "user_cancel";
            ptt.user_create = "user_create";
            ptt.user_modi = "user_modi";
            ptt.active = "active";
            ptt.line_id = "line_id";
            ptt.email = "email";
            ptt.passport = "passport";
            ptt.remark = "remark";
            ptt.patient_type = "patient_type";
            ptt.patient_group = "patient_group";
            ptt.agent = "agent";
            ptt.status_convert = "status_convert";
            ptt.patient_father_mobile = "patient_father_mobile";
            ptt.patient_mother_mobile = "patient_mother_mobile";
            ptt.patient_couple_mobile = "patient_couple_mobile";
            ptt.patient_firstname_e = "patient_firstname_e";
            ptt.patient_lastname_e = "patient_lastname_e";
            ptt.contract = "contract";
            ptt.insurance = "insurance";
            ptt.patient_contact_f_patient_prefix_id = "patient_contact_f_patient_prefix_id";
            ptt.patient_couple_f_patient_prefix_id = "patient_couple_f_patient_prefix_id";

            ptt.patient_contact_f_patient_relation_id = "patient_contact_f_patient_relation_id";
            ptt.patient_coulpe_f_patient_relation_id = "patient_coulpe_f_patient_relation_id";
            ptt.b_contract_plans_id = "b_contract_plans_id";
            ptt.t_patient_id_old = "t_patient_id_old";

            ptt.pkField = "t_patient_id";
            ptt.table = "t_patient";
        }
        private void chkNull(Patient p)
        {
            int chk = 0;
            decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.patient_hn = p.patient_hn == null ? "" : p.patient_hn;
            p.patient_firstname = p.patient_firstname == null ? "" : p.patient_firstname;
            p.patient_lastname = p.patient_lastname == null ? "" : p.patient_lastname;
            p.patient_xn = p.patient_xn == null ? "" : p.patient_xn;
            p.patient_birthday = p.patient_birthday == null ? "" : p.patient_birthday;
            p.patient_house = p.patient_house == null ? "" : p.patient_house;
            p.patient_road = p.patient_road == null ? "" : p.patient_road;
            p.patient_moo = p.patient_moo == null ? "" : p.patient_moo;
            p.patient_tambon = p.patient_tambon == null ? "" : p.patient_tambon;
            p.patient_amphur = p.patient_amphur == null ? "" : p.patient_amphur;
            p.patient_changwat = p.patient_changwat == null ? "" : p.patient_changwat;
            p.patient_father_firstname = p.patient_father_firstname == null ? "" : p.patient_father_firstname;
            p.patient_mother_firstname = p.patient_mother_firstname == null ? "" : p.patient_mother_firstname;
            p.patient_couple_firstname = p.patient_couple_firstname == null ? "" : p.patient_couple_firstname;
            p.patient_move_in_date_time = p.patient_move_in_date_time == null ? "" : p.patient_move_in_date_time;
            p.patient_discharge_date_time = p.patient_discharge_date_time == null ? "" : p.patient_discharge_date_time;
            p.patient_father_pid = p.patient_father_pid == null ? "" : p.patient_father_pid;
            p.patient_mather_pid = p.patient_mather_pid == null ? "" : p.patient_mather_pid;
            p.patient_couple_pid = p.patient_couple_pid == null ? "" : p.patient_couple_pid;
            p.patient_community_status = p.patient_community_status == null ? "" : p.patient_community_status;
            p.patient_private_doctor = p.patient_private_doctor == null ? "" : p.patient_private_doctor;
            p.pid = p.pid == null ? "" : p.pid;
            p.patient_mother_lastname = p.patient_mother_lastname == null ? "" : p.patient_mother_lastname;
            p.patient_father_lastname = p.patient_father_lastname == null ? "" : p.patient_father_lastname;
            p.patient_couple_lastname = p.patient_couple_lastname == null ? "" : p.patient_couple_lastname;
            p.mobile1 = p.mobile1 == null ? "" : p.mobile1;
            p.patient_contact_phone_number = p.patient_contact_phone_number == null ? "" : p.patient_contact_phone_number;
            p.patient_contact_house = p.patient_contact_house == null ? "" : p.patient_contact_house;
            p.patient_contact_moo = p.patient_contact_moo == null ? "" : p.patient_contact_moo;
            p.patient_contact_changwat = p.patient_contact_changwat == null ? "" : p.patient_contact_changwat;
            p.patient_contact_amphur = p.patient_contact_amphur == null ? "" : p.patient_contact_amphur;
            p.patient_contact_tambon = p.patient_contact_tambon == null ? "" : p.patient_contact_tambon;
            p.patient_contact_road = p.patient_contact_road == null ? "" : p.patient_contact_road;
            p.patient_contact_firstname = p.patient_contact_firstname == null ? "" : p.patient_contact_firstname;
            p.patient_contact_lastname = p.patient_contact_lastname == null ? "" : p.patient_contact_lastname;
            p.patient_birthday_true = p.patient_birthday_true == null ? "" : p.patient_birthday_true;
            p.patient_merged = p.patient_merged == null ? "" : p.patient_merged;
            p.patient_record_date_time = p.patient_record_date_time == null ? "" : p.patient_record_date_time;
            p.patient_update_date_time = p.patient_update_date_time == null ? "" : p.patient_update_date_time;
            p.patient_staff_record = p.patient_staff_record == null ? "" : p.patient_staff_record;
            p.patient_staff_modify = p.patient_staff_modify == null ? "" : p.patient_staff_modify;
            p.patient_staff_cancel = p.patient_staff_cancel == null ? "" : p.patient_staff_cancel;
            p.patient_active = p.patient_active == null ? "" : p.patient_active;
            p.patient_drugallergy = p.patient_drugallergy == null ? "" : p.patient_drugallergy;
            p.patient_language_for_print = p.patient_language_for_print == null ? "" : p.patient_language_for_print;
            p.mobile2 = p.mobile2 == null ? "" : p.mobile2;
            p.patient_contact_mobile_phone = p.patient_contact_mobile_phone == null ? "" : p.patient_contact_mobile_phone;
            p.patient_has_home_in_pcu = p.patient_has_home_in_pcu == null ? "" : p.patient_has_home_in_pcu;
            p.patient_other_country_address = p.patient_other_country_address == null ? "" : p.patient_other_country_address;
            p.patient_is_other_country = p.patient_is_other_country == null ? "" : p.patient_is_other_country;
            p.contact_namet = p.contact_namet == null ? "" : p.contact_namet;
            p.contact_join_namet = p.contact_join_namet == null ? "" : p.contact_join_namet;
            p.ss_patient_hn = p.ss_patient_hn == null ? "" : p.ss_patient_hn;
            p.patient_soi = p.patient_soi == null ? "" : p.patient_soi;
            p.patient_contact_soi = p.patient_contact_soi == null ? "" : p.patient_contact_soi;
            p.status_chronic = p.status_chronic == null ? "" : p.status_chronic;
            p.status_hiv = p.status_hiv == null ? "" : p.status_hiv;
            p.patient_status_hiv = p.patient_status_hiv == null ? "" : p.patient_status_hiv;
            p.status_deny_allergy = p.status_deny_allergy == null ? "" : p.status_deny_allergy;
            p.line_id = p.line_id == null ? "" : p.line_id;
            p.email = p.email == null ? "" : p.email;
            p.patient_patient_email = p.patient_patient_email == null ? "" : p.patient_patient_email;
            p.patient_contact_email = p.patient_contact_email == null ? "" : p.patient_contact_email;
            p.picture_profile = p.picture_profile == null ? "" : p.picture_profile;
            p.passport = p.passport == null ? "" : p.passport;
            p.remark2 = p.remark2 == null ? "" : p.remark2;
            p.remark1 = p.remark1 == null ? "" : p.remark1;
            p.remark = p.remark == null ? "" : p.remark;
            p.patient_group = p.patient_group == null ? "" : p.patient_group;
            p.patient_type = p.patient_type == null ? "" : p.patient_type;
            p.agent = p.agent == null ? "" : p.agent;
            p.status_convert = p.status_convert == null ? "" : p.status_convert;
            p.patient_mother_mobile = p.patient_mother_mobile == null ? "" : p.patient_mother_mobile;
            p.patient_couple_mobile = p.patient_couple_mobile == null ? "" : p.patient_couple_mobile;
            p.patient_father_mobile = p.patient_father_mobile == null ? "" : p.patient_father_mobile;
            p.patient_firstname_e = p.patient_firstname_e == null ? "" : p.patient_firstname_e;
            p.patient_lastname_e = p.patient_lastname_e == null ? "" : p.patient_lastname_e;
            p.contract = p.contract == null ? "" : p.contract;
            p.insurance = p.insurance == null ? "" : p.insurance;

            p.f_patient_prefix_id = int.TryParse(p.f_patient_prefix_id, out chk) ? chk.ToString() : "0";
            p.f_sex_id = int.TryParse(p.f_sex_id, out chk) ? chk.ToString() : "0";
            p.f_patient_marriage_status_id = int.TryParse(p.f_patient_marriage_status_id, out chk) ? chk.ToString() : "0";
            p.f_patient_occupation_id = int.TryParse(p.f_patient_occupation_id, out chk) ? chk.ToString() : "0";
            p.f_patient_race_id = int.TryParse(p.f_patient_race_id, out chk) ? chk.ToString() : "0";
            p.f_patient_nation_id = int.TryParse(p.f_patient_nation_id, out chk) ? chk.ToString() : "0";
            p.f_patient_religion_id = int.TryParse(p.f_patient_religion_id, out chk) ? chk.ToString() : "0";
            p.f_patient_education_type_id = int.TryParse(p.f_patient_education_type_id, out chk) ? chk.ToString() : "0";
            p.f_patient_family_status_id = int.TryParse(p.f_patient_family_status_id, out chk) ? chk.ToString() : "0";
            p.f_patient_discharge_status_id = int.TryParse(p.f_patient_discharge_status_id, out chk) ? chk.ToString() : "0";
            p.f_patient_blood_group_id = int.TryParse(p.f_patient_blood_group_id, out chk) ? chk.ToString() : "0";
            p.f_patient_foreigner_id = int.TryParse(p.f_patient_foreigner_id, out chk) ? chk.ToString() : "0";
            p.f_patient_area_status_id = int.TryParse(p.f_patient_area_status_id, out chk) ? chk.ToString() : "0";
            p.f_patient_relation_id = int.TryParse(p.f_patient_relation_id, out chk) ? chk.ToString() : "0";
            p.patient_contact_sex_id = int.TryParse(p.patient_contact_sex_id, out chk) ? chk.ToString() : "0";
            p.t_health_family_id = int.TryParse(p.t_health_family_id, out chk) ? chk.ToString() : "0";
            p.contact_id = int.TryParse(p.contact_id, out chk) ? chk.ToString() : "0";
            p.contact_join_id = int.TryParse(p.contact_join_id, out chk) ? chk.ToString() : "0";
            p.t_person_id = int.TryParse(p.t_person_id, out chk) ? chk.ToString() : "0";
            p.patient_contact_f_patient_prefix_id = int.TryParse(p.patient_contact_f_patient_prefix_id, out chk) ? chk.ToString() : "0";
            p.patient_couple_f_patient_prefix_id = int.TryParse(p.patient_couple_f_patient_prefix_id, out chk) ? chk.ToString() : "0";
            p.patient_contact_f_patient_relation_id = int.TryParse(p.patient_contact_f_patient_relation_id, out chk) ? chk.ToString() : "0";
            p.patient_coulpe_f_patient_relation_id = int.TryParse(p.patient_coulpe_f_patient_relation_id, out chk) ? chk.ToString() : "0";
            p.b_contract_plans_id = int.TryParse(p.b_contract_plans_id, out chk) ? chk.ToString() : "0";
            p.t_patient_id_old = int.TryParse(p.t_patient_id_old, out chk) ? chk.ToString() : "0";

            p.latitude = decimal.TryParse(p.latitude, out chk1) ? chk1.ToString() : "0";
            p.longitude = decimal.TryParse(p.longitude, out chk1) ? chk1.ToString() : "0";
        }
        public String insert(Patient p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;
            //p.date_create = "";
            chkNull(p);
            
            try
            {
                sql = "Insert Into " + ptt.table + "(" + ptt.patient_hn + "," + ptt.patient_firstname + "," + ptt.patient_lastname + "," +
                ptt.patient_xn + "," + ptt.patient_birthday + "," + ptt.patient_house + "," +
                ptt.active + "," + ptt.remark + "," + ptt.patient_road + "," +
                ptt.patient_moo + "," + ptt.patient_tambon + "," + ptt.patient_amphur + "," +
                ptt.patient_changwat + "," + ptt.patient_father_firstname + "," + ptt.patient_mother_firstname + "," +
                ptt.date_create + "," + ptt.date_modi + "," + ptt.date_cancel + ", " +
                ptt.user_create + "," + ptt.user_modi + "," + ptt.user_cancel + ", " +
                ptt.patient_couple_firstname + "," + ptt.patient_move_in_date_time + "," + ptt.patient_discharge_date_time + "," +
                ptt.patient_father_pid + "," + ptt.patient_mather_pid + "," + ptt.patient_couple_pid + "," +
                ptt.patient_community_status + "," + ptt.patient_private_doctor + "," + ptt.pid + "," +
                ptt.patient_mother_lastname + "," + ptt.patient_father_lastname + "," + ptt.patient_couple_lastname + "," +
                ptt.mobile1 + "," + ptt.patient_contact_phone_number + "," + ptt.patient_contact_house + "," +
                ptt.patient_contact_moo + "," + ptt.patient_contact_changwat + "," + ptt.patient_contact_amphur + "," +
                ptt.patient_contact_tambon + "," + ptt.patient_contact_road + "," + ptt.patient_contact_firstname + "," +
                ptt.patient_contact_lastname + "," + ptt.patient_birthday_true + "," + ptt.patient_merged + "," +
                ptt.patient_record_date_time + "," + ptt.patient_update_date_time + "," + ptt.patient_staff_record + "," +
                ptt.patient_staff_modify + "," + ptt.patient_staff_cancel + "," + ptt.patient_active + "," +
                ptt.patient_drugallergy + "," + ptt.patient_language_for_print + "," + ptt.mobile2 + "," +
                ptt.patient_contact_mobile_phone + "," + ptt.patient_has_home_in_pcu + "," + ptt.patient_other_country_address + "," +
                ptt.patient_is_other_country + "," + ptt.contact_namet + "," + ptt.contact_join_namet + "," +
                ptt.ss_patient_hn + "," + ptt.patient_soi + "," + ptt.patient_contact_soi + "," +
                ptt.status_chronic + "," + ptt.status_hiv + "," + ptt.patient_status_hiv + "," +
                ptt.status_deny_allergy + "," + ptt.latitude + "," + ptt.longitude + "," +
                ptt.patient_patient_email + "," + ptt.patient_contact_email + "," + ptt.picture_profile + "," +
                ptt.remark2 + "," + ptt.remark1 + "," + ptt.f_patient_prefix_id + "," +
                ptt.f_sex_id + "," + ptt.f_patient_marriage_status_id + "," + ptt.f_patient_occupation_id + "," +
                ptt.f_patient_race_id + "," + ptt.f_patient_nation_id + "," + ptt.f_patient_religion_id + "," +
                ptt.f_patient_education_type_id + "," + ptt.f_patient_family_status_id + "," + ptt.f_patient_discharge_status_id + "," +
                ptt.f_patient_blood_group_id + "," + ptt.f_patient_foreigner_id + "," + ptt.f_patient_area_status_id + "," +
                ptt.f_patient_relation_id + "," + ptt.patient_contact_sex_id + "," + ptt.t_health_family_id + "," +
                ptt.contact_id + "," + ptt.contact_join_id + "," + ptt.t_person_id + ", " +
                ptt.line_id + "," + ptt.email + "," + ptt.passport + ", " +
                ptt.patient_type + "," + ptt.patient_group + "," + ptt.agent + "," +
                ptt.status_convert + "," + ptt.patient_firstname_e + "," + ptt.patient_lastname_e + "," +
                ptt.contract + "," + ptt.insurance + "," + ptt.patient_contact_f_patient_prefix_id + "," +
                ptt.patient_couple_f_patient_prefix_id + "," + ptt.patient_contact_f_patient_relation_id + "," + ptt.patient_coulpe_f_patient_relation_id + "," +
                ptt.b_contract_plans_id + "," + ptt.patient_father_mobile + "," + ptt.patient_mother_mobile + "," +
                ptt.patient_couple_mobile + ","+ ptt.t_patient_id_old + " " +
                ") " +
                "Values ('" + p.patient_hn + "','" + p.patient_firstname.Replace("'", "''") + "','" + p.patient_lastname.Replace("'", "''") + "'," +
                "'" + p.patient_xn.Replace("'", "''") + "','" + p.patient_birthday.Replace("'", "''") + "','" + p.patient_house.Replace("'", "''") + "'," +
                "'" + p.active + "','" + p.remark.Replace("'", "''") + "','" + p.patient_road.Replace("'", "''") + "'," +
                "'" + p.patient_moo.Replace("'", "''") + "','" + p.patient_tambon + "','" + p.patient_amphur + "'," +
                "'" + p.patient_changwat + "','" + p.patient_father_firstname.Replace("'", "''") + "','" + p.patient_mother_firstname.Replace("'", "''") + "'," +
                "now(),'" + p.date_modi + "','" + p.date_cancel + "', " +
                "'" + userId + "','" + p.user_modi + "','" + p.user_cancel + "', " +
                "'" + p.patient_couple_firstname.Replace("'", "''") + "','" + p.patient_move_in_date_time + "','" + p.patient_discharge_date_time + "'," +
                "'" + p.patient_father_pid + "','" + p.patient_mather_pid + "','" + p.patient_couple_pid + "'," +
                "'" + p.patient_community_status + "','" + p.patient_private_doctor + "','" + p.pid + "'," +
                "'" + p.patient_mother_lastname.Replace("'", "''") + "','" + p.patient_father_lastname.Replace("'", "''") + "','" + p.patient_couple_lastname.Replace("'", "''") + "'," +
                "'" + p.mobile1 + "','" + p.patient_contact_phone_number + "','" + p.patient_contact_house + "'," +
                "'" + p.patient_contact_moo.Replace("'", "''") + "','" + p.patient_contact_changwat + "','" + p.patient_contact_amphur + "'," +
                "'" + p.patient_contact_tambon.Replace("'", "''") + "','" + p.patient_contact_road.Replace("'", "''") + "','" + p.patient_contact_firstname.Replace("'", "''") + "'," +
                "'" + p.patient_contact_lastname.Replace("'", "''") + "','" + p.patient_birthday_true + "','" + p.patient_merged + "'," +
                "'" + p.patient_record_date_time + "','" + p.patient_update_date_time + "','" + p.patient_staff_record + "'," +
                "'" + p.patient_staff_modify + "','" + p.patient_staff_cancel + "','" + p.patient_active + "'," +
                "'" + p.patient_drugallergy.Replace("'", "''") + "','" + p.patient_language_for_print + "','" + p.mobile2.Replace("'", "''") + "'," +
                "'" + p.patient_contact_mobile_phone + "','" + p.patient_has_home_in_pcu.Replace("'", "''") + "','" + p.patient_other_country_address.Replace("'", "''") + "'," +
                "'" + p.patient_is_other_country + "','" + p.contact_namet + "','" + p.contact_join_namet.Replace("'", "''") + "'," +
                "'" + p.ss_patient_hn + "','" + p.patient_soi + "','" + p.patient_contact_soi.Replace("'", "''") + "'," +
                "'" + p.status_chronic + "','" + p.status_hiv + "','" + p.patient_status_hiv + "'," +
                "'" + p.status_deny_allergy + "','" + p.latitude + "','" + p.longitude + "'," +
                "'" + p.patient_patient_email + "','" + p.patient_contact_email + "','" + p.picture_profile + "'," +
                "'" + p.remark2 + "','" + p.remark1 + "','" + p.f_patient_prefix_id + "'," +
                "'" + p.f_sex_id + "','" + p.f_patient_marriage_status_id + "','" + p.f_patient_occupation_id + "'," +
                "'" + p.f_patient_race_id + "','" + p.f_patient_nation_id + "','" + p.f_patient_religion_id + "'," +
                "'" + p.f_patient_education_type_id + "','" + p.f_patient_family_status_id + "','" + p.f_patient_discharge_status_id + "'," +
                "'" + p.f_patient_blood_group_id + "','" + p.f_patient_foreigner_id + "','" + p.f_patient_area_status_id + "'," +
                "'" + p.f_patient_relation_id + "','" + p.patient_contact_sex_id + "','" + p.t_health_family_id + "'," +
                "'" + p.contact_id + "','" + p.contact_join_id + "','" + p.t_person_id + "', " +
                "'" + p.line_id + "','" + p.email + "','" + p.passport + "', " +
                "'" + p.patient_type.Replace("'", "''") + "','" + p.patient_group.Replace("'", "''") + "','" + p.agent.Replace("'", "''") + "', " +
                "'" + p.status_convert.Replace("'", "''") + "','" + p.patient_firstname_e.Replace("'", "''") + "','" + p.patient_lastname_e.Replace("'", "''") + "', " +
                "'" + p.contract.Replace("'", "''") + "','" + p.insurance.Replace("'", "''") + "','" + p.patient_contact_f_patient_prefix_id + "', " +
                "'" + p.patient_couple_f_patient_prefix_id.Replace("'", "''") + "','" + p.patient_contact_f_patient_relation_id.Replace("'", "''") + "','" + p.patient_coulpe_f_patient_relation_id.Replace("'", "''") + "', " +
                "'" + p.b_contract_plans_id.Replace("'", "''") + "','" +p.patient_father_mobile+"','"+p.patient_mother_mobile+"', "+
                "'" + p.patient_couple_mobile+"','" + p.t_patient_id_old + "' " +
                ")";

                re = conn.ExecuteNonQuery(conn.conn, sql);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
            }
            return re;
        }
        public String insertPatient(Patient p, String userId)
        {
            String re = "";

            if (p.t_patient_id.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
            }

            return re;
        }
        public String update(Patient p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            sql = "Update "+ptt.table + " " +
                //" Set "+ptt.patient_hn + "='"+p.patient_hn + "' " +
                "Set " + ptt.patient_firstname + "='" + p.patient_firstname.Replace("'", "''") + "' " +
                "," + ptt.patient_lastname + "='" + p.patient_lastname.Replace("'", "''") + "' " +
                "," + ptt.patient_birthday + "='" + p.patient_birthday + "' " +
                "," + ptt.patient_xn + "='" + p.patient_xn + "' " +
                "," + ptt.patient_house + "='" + p.patient_house.Replace("'", "''") + "' " +
                "," + ptt.remark + "='" + p.remark.Replace("'", "''") + "' " +
                "," + ptt.patient_road + "='" + p.patient_road.Replace("'", "''") + "' " +
                "," + ptt.patient_moo + "='" + p.patient_moo.Replace("'", "''") + "' " +
                "," + ptt.patient_tambon + "='" + p.patient_tambon + "' " +
                "," + ptt.patient_amphur + "='" + p.patient_amphur + "' " +
                "," + ptt.patient_changwat + "='" + p.patient_changwat + "' " +
                "," + ptt.patient_father_firstname + "='" + p.patient_father_firstname.Replace("'", "''") + "' " +
                "," + ptt.patient_mother_firstname + "='" + p.patient_mother_firstname.Replace("'", "''") + "' " +
                "," + ptt.patient_couple_firstname + "='" + p.patient_couple_firstname.Replace("'", "''") + "' " +
                "," + ptt.pid + "='" + p.pid + "' " +
                "," + ptt.patient_mother_lastname + "='" + p.patient_mother_lastname.Replace("'", "''") + "' " +
                "," + ptt.patient_father_lastname + "='" + p.patient_father_lastname.Replace("'", "''") + "' " +
                "," + ptt.patient_couple_lastname + "='" + p.patient_couple_lastname.Replace("'", "''") + "' " +
                "," + ptt.mobile1 + "='" + p.mobile1 + "' " +
                "," + ptt.mobile2 + "='" + p.mobile2 + "' " +
                "," + ptt.line_id + "='" + p.line_id + "' " +
                "," + ptt.email + "='" + p.email + "' " +
                "," + ptt.passport + "='" + p.passport + "' " +
                "," + ptt.patient_type + "='" + p.patient_type + "' " +
                "," + ptt.patient_group + "='" + p.patient_group + "' " +
                "," + ptt.agent + "='" + p.agent.Replace("'", "''") + "' " +
                "," + ptt.f_patient_prefix_id + "='" + p.f_patient_prefix_id + "' " +
                "," + ptt.remark1 + "='" + p.remark1.Replace("'", "''") + "' " +
                "," + ptt.remark2 + "='" + p.remark2.Replace("'", "''") + "' " +
                "," + ptt.status_deny_allergy + "='" + p.status_deny_allergy + "' " +
                "," + ptt.status_chronic + "='" + p.status_chronic + "' " +
                "," + ptt.patient_drugallergy + "='" + p.patient_drugallergy.Replace("'", "''") + "' " +
                "," + ptt.f_patient_blood_group_id + "='" + p.f_patient_blood_group_id + "' " +
                "," + ptt.f_patient_nation_id + "='" + p.f_patient_nation_id + "' " +
                "," + ptt.f_patient_education_type_id + "='" + p.f_patient_education_type_id + "' " +
                "," + ptt.f_patient_religion_id + "='" + p.f_patient_religion_id + "' " +
                "," + ptt.f_patient_race_id + "='" + p.f_patient_race_id + "' " +
                "," + ptt.patient_group + "='" + p.patient_group + "' " +
                "," + ptt.patient_mother_mobile + "='" + p.patient_mother_mobile + "' " +
                "," + ptt.patient_father_mobile + "='" + p.patient_father_mobile + "' " +
                "," + ptt.patient_couple_mobile + "='" + p.patient_couple_mobile + "' " +
                "," + ptt.f_patient_marriage_status_id + "='" + p.f_patient_marriage_status_id + "' " +
                "," + ptt.f_sex_id + "='" + p.f_sex_id + "' " +
                "," + ptt.patient_firstname_e + "='" + p.patient_firstname_e.Replace("'", "''") + "' " +
                "," + ptt.patient_lastname_e + "='" + p.patient_lastname_e.Replace("'", "''") + "' " +
                "," + ptt.contract + "='" + p.contract.Replace("'", "''") + "' " +
                "," + ptt.insurance + "='" + p.insurance.Replace("'", "''") + "' " +
                "," + ptt.patient_contact_f_patient_prefix_id + "='" + p.patient_contact_f_patient_prefix_id.Replace("'", "''") + "' " +
                "," + ptt.patient_couple_f_patient_prefix_id + "='" + p.patient_couple_f_patient_prefix_id.Replace("'", "''") + "' " +
                "," + ptt.patient_contact_firstname + "='" + p.patient_contact_firstname.Replace("'", "''") + "' " +
                "," + ptt.patient_contact_lastname + "='" + p.patient_contact_lastname.Replace("'", "''") + "' " +
                "," + ptt.patient_contact_mobile_phone + "='" + p.patient_contact_mobile_phone.Replace("'", "''") + "' " +
                "," + ptt.patient_contact_f_patient_relation_id + "='" + p.patient_contact_f_patient_relation_id.Replace("'", "''") + "' " +
                "," + ptt.patient_coulpe_f_patient_relation_id + "='" + p.patient_coulpe_f_patient_relation_id.Replace("'", "''") + "' " +
                "," + ptt.b_contract_plans_id + "='" + p.b_contract_plans_id.Replace("'", "''") + "' " +
                " Where " +ptt.pkField + " = '" + p.t_patient_id + "' "
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
        public String updateFamily(Patient p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + ptt.table + " " +
                " Set " + ptt.patient_father_firstname + "='" + p.patient_father_firstname + "' " +
                "," + ptt.patient_father_lastname + "='" + p.patient_father_lastname+ "' " +
                "," + ptt.patient_lastname + "='" + p.patient_lastname + "' " +
                "," + ptt.patient_birthday + "='" + p.patient_birthday + "' " +
                "," + ptt.patient_xn + "='" + p.patient_xn + "' " +
                "," + ptt.patient_house + "='" + p.patient_house + "' " +
                "," + ptt.remark + "='" + p.remark + "' " +
                "," + ptt.patient_road + "='" + p.patient_road + "' " +
                "," + ptt.patient_moo + "='" + p.patient_moo + "' " +
                "," + ptt.patient_tambon + "='" + p.patient_tambon + "' " +
                "," + ptt.patient_amphur + "='" + p.patient_amphur + "' " +
                "," + ptt.patient_changwat + "='" + p.patient_changwat + "' " +
                "," + ptt.patient_father_firstname + "='" + p.patient_father_firstname + "' " +
                "," + ptt.patient_mother_firstname + "='" + p.patient_mother_firstname + "' " +
                "," + ptt.patient_couple_firstname + "='" + p.patient_couple_firstname + "' " +
                "," + ptt.pid + "='" + p.pid + "' " +
                "," + ptt.patient_mother_lastname + "='" + p.patient_mother_lastname + "' " +
                "," + ptt.patient_father_lastname + "='" + p.patient_father_lastname + "' " +
                "," + ptt.patient_couple_lastname + "='" + p.patient_couple_lastname + "' " +
                "," + ptt.mobile1 + "='" + p.mobile1 + "' " +
                "," + ptt.mobile2 + "='" + p.mobile2 + "' " +
                "," + ptt.line_id + "='" + p.line_id + "' " +
                "," + ptt.email + "='" + p.email + "' " +
                "," + ptt.passport + "='" + p.passport + "' " +
                "," + ptt.patient_type + "='" + p.patient_type + "' " +
                "," + ptt.patient_group + "='" + p.patient_group + "' " +
                "," + ptt.agent + "='" + p.agent + "' " +
                "," + ptt.f_patient_prefix_id + "='" + p.f_patient_prefix_id + "' " +
                "," + ptt.remark1 + "='" + p.remark1 + "' " +
                "," + ptt.remark2 + "='" + p.remark2 + "' " +
                "," + ptt.status_deny_allergy + "='" + p.status_deny_allergy + "' " +
                "," + ptt.status_chronic + "='" + p.status_chronic + "' " +
                "," + ptt.patient_drugallergy + "='" + p.patient_drugallergy + "' " +
                "," + ptt.f_patient_blood_group_id + "='" + p.f_patient_blood_group_id + "' " +
                "," + ptt.f_patient_nation_id + "='" + p.f_patient_nation_id + "' " +
                "," + ptt.f_patient_education_type_id + "='" + p.f_patient_education_type_id + "' " +
                "," + ptt.f_patient_religion_id + "='" + p.f_patient_religion_id + "' " +
                "," + ptt.f_patient_race_id + "='" + p.f_patient_race_id + "' " +
                "," + ptt.patient_group + "='" + p.patient_group + "' " +
                "," + ptt.patient_type + "='" + p.patient_type + "' " +
                " Where " + ptt.pkField + " = '" + p.t_patient_id + "' "
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
        public String VoidPatient(String pttId, String userIdVoid)
        {
            DataTable dt = new DataTable();
            String sql = "Update " + ptt.table + " Set " +
                "" + ptt.active + "='3'" +
                "," + ptt.date_cancel + "=now() " +
                "," + ptt.user_cancel + "='" + userIdVoid + "' " +
                "Where " + ptt.pkField + "='" + pttId + "'";
            conn.ExecuteNonQuery(conn.conn, sql);

            return "1";
        }
        public String updatePID(String pttId, String pid)
        {
            DataTable dt = new DataTable();
            String sql = "Update " + ptt.table + " Set " +
                "" + ptt.t_patient_id_old + "='"+ pid + "' " +                
                "Where " + ptt.pkField + "='" + pttId + "'";
            conn.ExecuteNonQuery(conn.conn, sql);

            return "1";
        }
        public DataTable selectByPk(String pttId)
        {
            DataTable dt = new DataTable();
            String sql = "select ptt.* " +
                "From " + ptt.table + " ptt " +
                "Where ptt." + ptt.pkField + " ='" + pttId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public Patient selectByPk1(String pttId)
        {
            Patient cop1 = new Patient();
            DataTable dt = new DataTable();
            String sql = "select ptt.* " +
                "From " + ptt.table + " ptt " +
                "Where ptt." + ptt.pkField + " ='" + pttId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setPatient(dt);
            return cop1;
        }
        public DataTable selectByDate(String date)
        {
            DataTable dt = new DataTable();
            String sql = "select ptt.* " +
                "From " + ptt.table + " ptt " +
                "Where ptt." + ptt.patient_record_date_time + " >='" + date + " 00:00:00' and ptt." + ptt.patient_record_date_time + " <='" + date + " 23:59:59'";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByDate1(String date)
        {
            DataTable dt = new DataTable();
            String sql = "select ptt."+ptt.t_patient_id+",ptt."+ptt.patient_hn+ ",CONCAT(ptt." + ptt.patient_firstname+",' ',ptt."+ptt.patient_lastname+") as name,ptt."+ptt.remark+" " +
                "From " + ptt.table + " ptt " +
                "Left join f_patient_prefix fpp on fpp.f_patient_prefix_id = ptt.f_patient_prefix_id " +
                "Where ptt." + ptt.patient_record_date_time + " >='" + date + " 00:00:00' and ptt." + ptt.patient_record_date_time + " <='" + date + " 23:59:59' " +
                "Order By ptt." + ptt.patient_record_date_time;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectBySearch(String search)
        {
            DataTable dt = new DataTable();
            String whereHN = "", whereName="", wherepid="", wherepassport="", wherenameE="";
            if (!search.Equals(""))
            {
                whereHN = " ptt."+ptt.patient_hn+" like '%"+search.Trim().ToUpper()+"%'";
            }
            if (!search.Equals(""))
            {
                String[] txt = search.Split(' ');
                if (txt.Length == 2)
                {
                    whereName = " or ( lcase(ptt." + ptt.patient_firstname + ") like '%" + txt[0].Trim().ToLower() + "%') and ( lcase(ptt." + ptt.patient_lastname + ") like '%" + txt[1].Trim().ToLower() + "%')";
                    wherenameE = " or ( lcase(ptt." + ptt.patient_firstname_e + ") like '%" + txt[0].Trim().ToLower() + "%') and ( lcase(ptt." + ptt.patient_lastname_e + ") like '%" + txt[1].Trim().ToLower() + "%')";
                }
                else if (txt.Length == 1)
                {
                    whereName = " or ( lcase(ptt." + ptt.patient_firstname + ") like '%" + txt[0].Trim().ToLower() + "%') or ( lcase(ptt." + ptt.patient_lastname + ") like '%" + txt[0].Trim().ToLower() + "%')";
                    wherenameE = " or ( lcase(ptt." + ptt.patient_firstname_e + ") like '%" + txt[0].Trim().ToLower() + "%') or ( lcase(ptt." + ptt.patient_lastname_e + ") like '%" + txt[0].Trim().ToLower() + "%')";
                }
                else
                {
                    whereName = " or ( lcase(ptt." + ptt.patient_firstname + ") like '%" + search.Trim().ToLower() + "%') or ( lcase(ptt." + ptt.patient_lastname + ") like '%" + search.Trim().ToLower() + "%')";
                    wherenameE = " or ( lcase(ptt." + ptt.patient_firstname_e + ") like '%" + search.Trim().ToLower() + "%') or ( lcase(ptt." + ptt.patient_lastname_e + ") like '%" + search.Trim().ToLower() + "%')";
                }
            }
            if (!search.Equals(""))
            {
                wherepid = " or ( ptt." + ptt.pid + " like '%" + search.Trim() + "%' )";
            }
            if (!search.Equals(""))
            {
                wherepassport = " or ( ptt." + ptt.passport + " like '%" + search.Trim() + "%' )";
            }
            String sql = "select ptt." + ptt.t_patient_id + ",ptt." + ptt.patient_hn + ",CONCAT(IFNULL(fpp.patient_prefix_description,''),' ', ptt." + ptt.patient_firstname + ",' ',ptt." + ptt.patient_lastname + ") as name,ptt." + ptt.remark + " " +
                "From " + ptt.table + " ptt " +
                "Left join f_patient_prefix fpp on fpp.f_patient_prefix_id = ptt.f_patient_prefix_id " +
                "Where " + whereHN + whereName + wherepid+ wherenameE;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public Patient setPatient(DataTable dt)
        {
            Patient ptt1 = new Patient();
            if (dt.Rows.Count > 0)
            {
                ptt1.t_patient_id = dt.Rows[0][ptt.t_patient_id].ToString();
                ptt1.patient_hn = dt.Rows[0][ptt.patient_hn].ToString();
                ptt1.f_patient_prefix_id = dt.Rows[0][ptt.f_patient_prefix_id].ToString();
                ptt1.patient_firstname = dt.Rows[0][ptt.patient_firstname].ToString();
                ptt1.patient_lastname = dt.Rows[0][ptt.patient_lastname].ToString();
                ptt1.patient_xn = dt.Rows[0][ptt.patient_xn].ToString();
                ptt1.f_sex_id = dt.Rows[0][ptt.f_sex_id].ToString();
                ptt1.patient_birthday = dt.Rows[0][ptt.patient_birthday].ToString();
                ptt1.patient_house = dt.Rows[0][ptt.patient_house].ToString();
                ptt1.patient_road = dt.Rows[0][ptt.patient_road].ToString();
                ptt1.patient_moo = dt.Rows[0][ptt.patient_moo].ToString();
                ptt1.patient_tambon = dt.Rows[0][ptt.patient_tambon].ToString();
                ptt1.patient_amphur = dt.Rows[0][ptt.patient_amphur].ToString();
                ptt1.patient_changwat = dt.Rows[0][ptt.patient_changwat].ToString();
                ptt1.f_patient_marriage_status_id = dt.Rows[0][ptt.f_patient_marriage_status_id].ToString();
                ptt1.f_patient_occupation_id = dt.Rows[0][ptt.f_patient_occupation_id].ToString();
                ptt1.f_patient_race_id = dt.Rows[0][ptt.f_patient_race_id].ToString();
                ptt1.f_patient_nation_id = dt.Rows[0][ptt.f_patient_nation_id].ToString();
                ptt1.f_patient_religion_id = dt.Rows[0][ptt.f_patient_religion_id].ToString();
                ptt1.f_patient_education_type_id = dt.Rows[0][ptt.f_patient_education_type_id].ToString();
                ptt1.f_patient_family_status_id = dt.Rows[0][ptt.f_patient_family_status_id].ToString();
                ptt1.patient_father_firstname = dt.Rows[0][ptt.patient_father_firstname].ToString();
                ptt1.patient_mother_firstname = dt.Rows[0][ptt.patient_mother_firstname].ToString();
                ptt1.patient_couple_firstname = dt.Rows[0][ptt.patient_couple_firstname].ToString();
                ptt1.patient_move_in_date_time = dt.Rows[0][ptt.patient_move_in_date_time].ToString();
                ptt1.f_patient_discharge_status_id = dt.Rows[0][ptt.f_patient_discharge_status_id].ToString();
                ptt1.patient_discharge_date_time = dt.Rows[0][ptt.patient_discharge_date_time].ToString();
                ptt1.f_patient_blood_group_id = dt.Rows[0][ptt.f_patient_blood_group_id].ToString();
                ptt1.f_patient_foreigner_id = dt.Rows[0][ptt.f_patient_foreigner_id].ToString();
                ptt1.f_patient_area_status_id = dt.Rows[0][ptt.f_patient_area_status_id].ToString();
                ptt1.patient_father_pid = dt.Rows[0][ptt.patient_father_pid].ToString();
                ptt1.patient_mather_pid = dt.Rows[0][ptt.patient_mather_pid].ToString();
                ptt1.patient_couple_pid = dt.Rows[0][ptt.patient_couple_pid].ToString();
                ptt1.patient_community_status = dt.Rows[0][ptt.patient_community_status].ToString();
                ptt1.patient_private_doctor = dt.Rows[0][ptt.patient_private_doctor].ToString();
                ptt1.pid = dt.Rows[0][ptt.pid].ToString();
                ptt1.patient_mother_lastname = dt.Rows[0][ptt.patient_mother_lastname].ToString();
                ptt1.patient_father_lastname = dt.Rows[0][ptt.patient_father_lastname].ToString();
                ptt1.patient_couple_lastname = dt.Rows[0][ptt.patient_couple_lastname].ToString();
                ptt1.mobile1 = dt.Rows[0][ptt.mobile1].ToString();
                ptt1.f_patient_relation_id = dt.Rows[0][ptt.f_patient_relation_id].ToString();
                ptt1.patient_contact_phone_number = dt.Rows[0][ptt.patient_contact_phone_number].ToString();
                ptt1.patient_contact_sex_id = dt.Rows[0][ptt.patient_contact_sex_id].ToString();
                ptt1.patient_contact_house = dt.Rows[0][ptt.patient_contact_house].ToString();
                ptt1.patient_contact_moo = dt.Rows[0][ptt.patient_contact_moo].ToString();
                ptt1.patient_contact_changwat = dt.Rows[0][ptt.patient_contact_changwat].ToString();
                ptt1.patient_contact_amphur = dt.Rows[0][ptt.patient_contact_amphur].ToString();
                ptt1.patient_contact_tambon = dt.Rows[0][ptt.patient_contact_tambon].ToString();
                ptt1.patient_contact_road = dt.Rows[0][ptt.patient_contact_road].ToString();
                ptt1.patient_contact_firstname = dt.Rows[0][ptt.patient_contact_firstname].ToString();
                ptt1.patient_contact_lastname = dt.Rows[0][ptt.patient_contact_lastname].ToString();
                ptt1.patient_birthday_true = dt.Rows[0][ptt.patient_birthday_true].ToString();
                ptt1.patient_merged = dt.Rows[0][ptt.patient_merged].ToString();
                ptt1.patient_record_date_time = dt.Rows[0][ptt.patient_record_date_time].ToString();
                ptt1.patient_update_date_time = dt.Rows[0][ptt.patient_update_date_time].ToString();
                ptt1.patient_staff_record = dt.Rows[0][ptt.patient_staff_record].ToString();
                ptt1.patient_staff_modify = dt.Rows[0][ptt.patient_staff_modify].ToString();
                ptt1.patient_staff_cancel = dt.Rows[0][ptt.patient_staff_cancel].ToString();
                ptt1.patient_active = dt.Rows[0][ptt.patient_active].ToString();
                ptt1.patient_drugallergy = dt.Rows[0][ptt.patient_drugallergy].ToString();
                ptt1.patient_language_for_print = dt.Rows[0][ptt.patient_language_for_print].ToString();
                ptt1.mobile2 = dt.Rows[0][ptt.mobile2].ToString();
                ptt1.patient_contact_mobile_phone = dt.Rows[0][ptt.patient_contact_mobile_phone].ToString();
                ptt1.patient_has_home_in_pcu = dt.Rows[0][ptt.patient_has_home_in_pcu].ToString();
                ptt1.t_health_family_id = dt.Rows[0][ptt.t_health_family_id].ToString();
                ptt1.patient_other_country_address = dt.Rows[0][ptt.patient_other_country_address].ToString();
                ptt1.patient_is_other_country = dt.Rows[0][ptt.patient_is_other_country].ToString();
                ptt1.contact_id = dt.Rows[0][ptt.contact_id].ToString();
                ptt1.contact_namet = dt.Rows[0][ptt.contact_namet].ToString();
                ptt1.remark1 = dt.Rows[0][ptt.remark1].ToString();
                ptt1.remark2 = dt.Rows[0][ptt.remark2].ToString();
                ptt1.contact_join_id = dt.Rows[0][ptt.contact_join_id].ToString();
                ptt1.contact_join_namet = dt.Rows[0][ptt.contact_join_namet].ToString();
                ptt1.ss_patient_hn = dt.Rows[0][ptt.ss_patient_hn].ToString();
                ptt1.patient_soi = dt.Rows[0][ptt.patient_soi].ToString();
                ptt1.patient_contact_soi = dt.Rows[0][ptt.patient_contact_soi].ToString();
                ptt1.status_chronic = dt.Rows[0][ptt.status_chronic].ToString();
                ptt1.status_hiv = dt.Rows[0][ptt.status_hiv].ToString();
                ptt1.patient_status_hiv = dt.Rows[0][ptt.patient_status_hiv].ToString();
                ptt1.status_deny_allergy = dt.Rows[0][ptt.status_deny_allergy].ToString();
                ptt1.latitude = dt.Rows[0][ptt.latitude].ToString();
                ptt1.longitude = dt.Rows[0][ptt.longitude].ToString();
                ptt1.t_person_id = dt.Rows[0][ptt.t_person_id].ToString();
                ptt1.patient_patient_email = dt.Rows[0][ptt.patient_patient_email].ToString();
                ptt1.patient_contact_email = dt.Rows[0][ptt.patient_contact_email].ToString();
                ptt1.picture_profile = dt.Rows[0][ptt.picture_profile].ToString();

                ptt1.date_cancel = dt.Rows[0][ptt.date_cancel].ToString();
                ptt1.date_create = dt.Rows[0][ptt.date_create].ToString();
                ptt1.date_modi = dt.Rows[0][ptt.date_modi].ToString();
                ptt1.user_cancel = dt.Rows[0][ptt.user_cancel].ToString();
                ptt1.user_create = dt.Rows[0][ptt.user_create].ToString();
                ptt1.user_modi = dt.Rows[0][ptt.user_modi].ToString();
                ptt1.active = dt.Rows[0][ptt.active].ToString();
                ptt1.line_id = dt.Rows[0][ptt.line_id].ToString();
                ptt1.email = dt.Rows[0][ptt.email].ToString();
                ptt1.passport = dt.Rows[0][ptt.passport].ToString();
                ptt1.patient_group = dt.Rows[0][ptt.patient_group].ToString();
                ptt1.patient_type = dt.Rows[0][ptt.patient_type].ToString();
                ptt1.agent = dt.Rows[0][ptt.agent].ToString();
                ptt1.remark = dt.Rows[0][ptt.remark].ToString();
                ptt1.mobile2 = dt.Rows[0][ptt.mobile2].ToString();
                ptt1.patient_father_mobile = dt.Rows[0][ptt.patient_father_mobile].ToString();
                ptt1.patient_mother_mobile = dt.Rows[0][ptt.patient_mother_mobile].ToString();
                ptt1.patient_couple_mobile = dt.Rows[0][ptt.patient_couple_mobile].ToString();
                ptt1.f_patient_marriage_status_id = dt.Rows[0][ptt.f_patient_marriage_status_id].ToString();
                ptt1.patient_firstname_e = dt.Rows[0][ptt.patient_firstname_e].ToString();
                ptt1.patient_lastname_e = dt.Rows[0][ptt.patient_lastname_e].ToString();
                ptt1.contract = dt.Rows[0][ptt.contract].ToString();
                ptt1.insurance = dt.Rows[0][ptt.insurance].ToString();
                ptt1.patient_contact_f_patient_prefix_id = dt.Rows[0][ptt.patient_contact_f_patient_prefix_id].ToString();
                ptt1.patient_couple_f_patient_prefix_id = dt.Rows[0][ptt.patient_couple_f_patient_prefix_id].ToString();
                ptt1.patient_contact_f_patient_relation_id = dt.Rows[0][ptt.patient_contact_f_patient_relation_id].ToString();
                ptt1.patient_coulpe_f_patient_relation_id = dt.Rows[0][ptt.patient_coulpe_f_patient_relation_id].ToString();
                ptt1.b_contract_plans_id = dt.Rows[0][ptt.b_contract_plans_id].ToString();
            }
            else
            {
                setPatient1(ptt1);
            }
            return ptt1;
        }
        private Patient setPatient1(Patient stf1)
        {
            stf1.t_patient_id = "";
            stf1.patient_hn = "";
            stf1.f_patient_prefix_id = "";
            stf1.patient_firstname = "";
            stf1.patient_lastname = "";
            stf1.patient_xn = "";
            stf1.f_sex_id = "";
            stf1.patient_birthday = "";
            stf1.patient_house = "";
            stf1.patient_road = "";
            stf1.patient_moo = "";
            stf1.patient_tambon = "";
            stf1.patient_amphur = "";
            stf1.patient_changwat = "";
            stf1.f_patient_marriage_status_id = "";
            stf1.f_patient_occupation_id = "";
            stf1.f_patient_race_id = "";
            stf1.f_patient_nation_id = "";
            stf1.f_patient_religion_id = "";
            stf1.f_patient_education_type_id = "";
            stf1.f_patient_family_status_id = "";
            stf1.patient_father_firstname = "";
            stf1.patient_mother_firstname = "";
            stf1.patient_couple_firstname = "";
            stf1.patient_move_in_date_time = "";
            stf1.f_patient_discharge_status_id = "";
            stf1.patient_discharge_date_time = "";
            stf1.f_patient_blood_group_id = "";
            stf1.f_patient_foreigner_id = "";
            stf1.f_patient_area_status_id = "";
            stf1.patient_father_pid = "";
            stf1.patient_mather_pid = "";
            stf1.patient_couple_pid = "";
            stf1.patient_community_status = "";
            stf1.patient_private_doctor = "";
            stf1.pid = "";
            stf1.patient_mother_lastname = "";
            stf1.patient_father_lastname = "";
            stf1.patient_couple_lastname = "";
            stf1.mobile1 = "";
            stf1.f_patient_relation_id = "";
            stf1.patient_contact_phone_number = "";
            stf1.patient_contact_sex_id = "";
            stf1.patient_contact_house = "";
            stf1.patient_contact_moo = "";
            stf1.patient_contact_changwat = "";
            stf1.patient_contact_amphur = "";
            stf1.patient_contact_tambon = "";
            stf1.patient_contact_road = "";
            stf1.patient_contact_firstname = "";
            stf1.patient_contact_lastname = "";
            stf1.patient_birthday_true = "";
            stf1.patient_merged = "";
            stf1.patient_record_date_time = "";
            stf1.patient_update_date_time = "";
            stf1.patient_staff_record = "";
            stf1.patient_staff_modify = "";
            stf1.patient_staff_cancel = "";
            stf1.patient_active = "";
            stf1.patient_drugallergy = "";
            stf1.patient_language_for_print = "";
            stf1.mobile2 = "";
            stf1.patient_contact_mobile_phone = "";
            stf1.patient_has_home_in_pcu = "";
            stf1.t_health_family_id = "";
            stf1.patient_other_country_address = "";
            stf1.patient_is_other_country = "";
            stf1.contact_id = "";
            stf1.contact_namet = "";
            stf1.remark1 = "";
            stf1.remark2 = "";
            stf1.contact_join_id = "";
            stf1.contact_join_namet = "";
            stf1.ss_patient_hn = "";
            stf1.patient_soi = "";
            stf1.patient_contact_soi = "";
            stf1.status_chronic = "";
            stf1.status_hiv = "";
            stf1.patient_status_hiv = "";
            stf1.status_deny_allergy = "";
            stf1.latitude = "";
            stf1.longitude = "";
            stf1.t_person_id = "";
            stf1.patient_patient_email = "";
            stf1.patient_contact_email = "";
            stf1.picture_profile = "";

            stf1.date_cancel = "";
            stf1.date_create = "";
            stf1.date_modi = "";
            stf1.user_cancel = "";
            stf1.user_create = "";
            stf1.user_modi = "";
            stf1.active = "";
            stf1.line_id = "";
            stf1.email = "";
            stf1.passport = "";
            stf1.patient_type = "";
            stf1.patient_group = "";
            stf1.agent = "";
            stf1.remark = "";
            stf1.patient_father_mobile = "";
            stf1.patient_mother_mobile = "";
            stf1.patient_couple_mobile = "";
            stf1.patient_firstname_e = "";
            stf1.patient_lastname_e = "";
            stf1.contract = "";
            stf1.insurance = "";
            stf1.patient_contact_f_patient_prefix_id = "";
            stf1.patient_couple_f_patient_prefix_id = "";
            stf1.patient_contact_f_patient_relation_id = "";
            stf1.patient_coulpe_f_patient_relation_id = "";
            stf1.b_contract_plans_id = "";
            return stf1;
        }
    }
}
