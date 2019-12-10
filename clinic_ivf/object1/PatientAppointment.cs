using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class PatientAppointment:Persistent
    {
        public String t_patient_appointment_id { get; set; }
        public String t_patient_id { get; set; }
        public String patient_appoint_date_time { get; set; }
        public String patient_appointment_date { get; set; }
        public String patient_appointment_time { get; set; }
        public String patient_appointment { get; set; }
        public String patient_appointment_doctor { get; set; }
        public String patient_appointment_servicepoint { get; set; }
        public String patient_appointment_notice { get; set; }
        public String patient_appointment_staff { get; set; }
        public String t_visit_id { get; set; }
        public String patient_appointment_auto_visit { get; set; }
        public String b_visit_queue_setup_id { get; set; }
        public String patient_appointment_status { get; set; }
        public String patient_appointment_vn { get; set; }
        public String patient_appointment_staff_record { get; set; }
        public String patient_appointment_record_date_time { get; set; }
        public String patient_appointment_staff_update { get; set; }
        public String patient_appointment_update_date_time { get; set; }
        public String patient_appointment_staff_cancel { get; set; }
        public String patient_appointment_cancel_date_time { get; set; }
        public String patient_appointment_active { get; set; }
        public String r_rp1853_aptype_id { get; set; }
        public String patient_appointment_end_time { get; set; }
        public String appointment_confirm_date { get; set; }
        public String change_appointment_cause { get; set; }
        public String visit_id_make_appointment { get; set; }
        public String patient_appointment_clinic { get; set; }
        public String e2 { get; set; }
        public String lh { get; set; }
        public String endo { get; set; }
        public String prl { get; set; }
        public String fsh { get; set; }
        public String rt_ovary { get; set; }
        public String lt_ovary { get; set; }
        public String dtr_name { get; set; }
        public String tvs { get; set; }
        public String repeat_e2 { get; set; }
        public String repeat_lh { get; set; }
        public String repeat_prl { get; set; }
        public String repeat_fsh { get; set; }
        public String opu { get; set; }
        public String doctor_anes { get; set; }
        public String tvs_day { get; set; }
        public String tvs_time { get; set; }
        public String opu_time { get; set; }
        public String et { get; set; }
        public String et_time { get; set; }
        public String fet { get; set; }
        public String fet_time { get; set; }
        public String hormone_test { get; set; }
        public String other { get; set; }
        public String beta_hgc { get; set; }
        public String other_remark { get; set; }
        public String sperm_collect { get; set; }
        public String appoitment_id_old { get; set; }
        public String sperm_freezing { get; set; }
        public String sperm_opu { get; set; }
        public String pesa { get; set; }
        public String sperm_sa { get; set; }
        public String opu_remark { get; set; }
        public String status_convert { get; set; }
        public String patient_hn_papm { get; set; }
    }
}
