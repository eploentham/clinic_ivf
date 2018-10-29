using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class VisitQueueTransfer:Persistent
    {
        public String adm { get; set; }
        public String assign_date_time { get; set; }
        public String b_contract_plans_id { get; set; }
        public String b_service_point_id { get; set; }
        public String b_service_point_old_id { get; set; }
        public String billing_invoice_staff_record { get; set; }
        public String contact_join_namet { get; set; }
        public String contact_namet { get; set; }
        public String contract_plans_color { get; set; }
        public String contract_plans_description { get; set; }
        public String description { get; set; }
        public String doctor_tmp { get; set; }
        public String f_patient_prefix_id { get; set; }
        public String f_sex_id { get; set; }
        public String f_visit_type_id { get; set; }
        public String med { get; set; }
        public String order_drug_modifier { get; set; }
        public String order_staff_order { get; set; }
        public String patient_drugallergy { get; set; }
        public String patient_firstname { get; set; }
        public String patient_lastname { get; set; }
        public String scan { get; set; }
        public String scan_time { get; set; }
        public String service_point_description { get; set; }
        public String status_flow_opd { get; set; }
        public String t_patient_id { get; set; }
        public String t_visit_id { get; set; }
        public String t_visit_queue_transfer_id { get; set; }
        public String visit_begin_visit_time { get; set; }
        public String visit_count { get; set; }
        public String visit_financial_discharge_time { get; set; }
        public String visit_hn { get; set; }
        public String visit_locking { get; set; }
        public String visit_payment_staff_record { get; set; }
        public String visit_queue_map_queue { get; set; }
        public String visit_queue_setup_description { get; set; }
        public String visit_queue_setup_queue_color { get; set; }
        public String visit_queue_transfer_lab_status { get; set; }
        public String visit_service_staff_doctor { get; set; }
        public String visit_vn { get; set; }
        public String xray { get; set; }
    }
}
