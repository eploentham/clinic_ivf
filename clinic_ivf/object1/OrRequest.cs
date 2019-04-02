using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class OrRequest:Persistent
    {
        public String or_req_id { get; set; }
        public String or_req_code { get; set; }
        public String or_req_date { get; set; }
        public String patient_hn { get; set; }
        public String patient_name { get; set; }
        public String doctor_anesthesia_id { get; set; }
        public String doctor_surgical_id { get; set; }
        public String or_date { get; set; }
        public String or_time { get; set; }
        public String status_or { get; set; }
        public String b_service_point_id { get; set; }
        public String or_id { get; set; }

    }
}
