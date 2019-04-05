using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class OrTOperation:Persistent
    {
        public String or_id { get; set; }
        public String or_code { get; set; }
        public String or_req_id { get; set; }
        public String patient_hn { get; set; }
        public String patient_name { get; set; }
        public String doctor_anesthesia_id { get; set; }
        public String doctor_surgical_id { get; set; }
        public String or_date { get; set; }
        public String or_time { get; set; }
        public String status_or { get; set; }
        public String opera_id { get; set; }
        public String t_patient_id { get; set; }
        public String b_service_point_id { get; set; }
        
        public String status_urgent { get; set; }
        public String anesthesia_id { get; set; }
        public String operation_name { get; set; }
        public String anesthesia_name { get; set; }
        public String surgeon { get; set; }
        public String operation_group_name { get; set; }
    }
}
