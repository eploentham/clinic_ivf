using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class LabRequest:Persistent
    {
        public String req_id { get; set; }
        public String req_code { get; set; }
        public String req_date { get; set; }
        public String hn_male { get; set; }
        public String name_male { get; set; }
        public String hn_female { get; set; }
        public String name_female { get; set; }
        public String status_req { get; set; }
        public String accept_date { get; set; }
        public String start_date { get; set; }
        public String result_date { get; set; }
        public String visit_id { get; set; }
        public String vn { get; set; }
        public String active { get; set; }
        public String remark { get; set; }
        public String date_create { get; set; }
        public String date_modi { get; set; }
        public String date_cancel { get; set; }
        public String user_create { get; set; }
        public String user_modi { get; set; }
        public String user_cancel { get; set; }
        public String item_id { get; set; }
        public String accept_staff_id { get; set; }
        public String start_staff_id { get; set; }
        public String result_staff_id { get; set; }
        public String doctor_id { get; set; }
        public String lab_id { get; set; }
        public String dob_female { get; set; }
        public String dob_male { get; set; }
        public String hn_donor { get; set; }
        public String name_donor { get; set; }
        public String dob_donor { get; set; }
        public String request_id { get; set; }
    }
}
