using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class Visit:Persistent
    {
        public String b_contract_plans_id { get; set; }
        public String b_ncd_group_id { get; set; }
        public String b_service_point_id { get; set; }
        public String b_visit_bed_id { get; set; }
        public String b_visit_clinic_id { get; set; }
        public String b_visit_office_id_refer_in { get; set; }
        public String b_visit_office_id_refer_out { get; set; }
        public String b_visit_room_id { get; set; }
        public String b_visit_ward_id { get; set; }
        public String contact_id { get; set; }
        public String contact_join_id { get; set; }
        public String contact_join_namet { get; set; }
        public String contact_namet { get; set; }
        public String f_emergency_status_id { get; set; }
        public String f_refer_cause_id { get; set; }
        public String f_trama_status_id { get; set; }
        public String f_transportation_type_id { get; set; }
        public String f_visit_ipd_discharge_status_id { get; set; }
        public String f_visit_ipd_discharge_type_id { get; set; }
        public String f_visit_opd_discharge_status_id { get; set; }
        public String f_visit_service_type_id { get; set; }
        public String f_visit_status_id { get; set; }
        public String f_visit_type_id { get; set; }
        public String ipd_discharge_doctor { get; set; }
        public String modify_discharge_datetime { get; set; }
        public String other_transportation { get; set; }
        public String prepare_discharge_date_time { get; set; }
        public String prepare_discharge_message { get; set; }
        public String service_location { get; set; }
        public String status_prepare_discharge { get; set; }
        public String surveillance_case_id { get; set; }
        public String t_patient_appointment_id { get; set; }
        public String t_patient_id { get; set; }
        public String t_visit_id { get; set; }
        public String visit_an { get; set; }
        public String visit_bed { get; set; }
        public String visit_begin_admit_date_time { get; set; }
        public String visit_begin_visit_time { get; set; }
        public String visit_cal_date_appointment { get; set; }
        public String visit_cause_appointment { get; set; }
        public String visit_deny_allergy { get; set; }
        public String visit_diagnosis_notice { get; set; }
        public String visit_doctor_discharge_status { get; set; }
        public String visit_doctor_reverse_date_time { get; set; }
        public String visit_dx { get; set; }
        public String visit_dx_stat { get; set; }
        public String visit_emergency_staff { get; set; }
        public String visit_financial_discharge_time { get; set; }
        public String visit_financial_record_date_time { get; set; }
        public String visit_financial_record_staff { get; set; }
        public String visit_financial_reverse_date_time { get; set; }
        public String visit_first_visit { get; set; }
        public String visit_have_admit { get; set; }
        public String visit_have_appointment { get; set; }
        public String visit_have_refer { get; set; }
        public String visit_have_scan_sn_dx { get; set; }
        public String visit_hn { get; set; }
        public String visit_hospital_service { get; set; }
        public String visit_ipd_discharge_date_time { get; set; }
        public String visit_ipd_discharge_status { get; set; }
        public String visit_ipd_reverse_date_time { get; set; }
        public String visit_ipd_staff_discharge { get; set; }
        public String visit_ipd_staff_reverse { get; set; }
        public String visit_lab_approve_staff { get; set; }
        public String visit_lab_status_id { get; set; }
        public String visit_lock_date_time { get; set; }
        public String visit_locking { get; set; }
        public String visit_modify_date_time { get; set; }
        public String visit_modify_staff { get; set; }
        public String visit_money_discharge_status { get; set; }
        public String visit_ncd { get; set; }
        public String visit_notice { get; set; }
        public String visit_observe { get; set; }
        public String visit_patient_age { get; set; }
        public String visit_patient_self_doctor { get; set; }
        public String visit_patient_type { get; set; }
        public String visit_pcu_service { get; set; }
        public String visit_pregnant { get; set; }
        public String visit_primary_symtom { get; set; }
        public String visit_queue { get; set; }
        public String visit_record_date_time { get; set; }
        public String visit_record_staff { get; set; }
        public String visit_staff_doctor_discharge { get; set; }
        public String visit_staff_doctor_discharge_date_time { get; set; }
        public String visit_staff_doctor_reverse { get; set; }
        public String visit_staff_financial_discharge { get; set; }
        public String visit_staff_financial_reverse { get; set; }
        public String visit_staff_lock { get; set; }
        public String visit_staff_observe { get; set; }
        public String visit_status_lab_approve { get; set; }
        public String visit_vn { get; set; }
        public String status_urge { get; set; }
        public String patient_hn_1 { get; set; }
        public String queue_id { get; set; }
        public String lmp { get; set; }
        public String height { get; set; }
        public String bw { get; set; }
        public String bp { get; set; }
    }
}
