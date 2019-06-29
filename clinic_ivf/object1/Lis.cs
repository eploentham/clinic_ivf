using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class Lis:Persistent
    {
        public String lis_id { get; set; }
        public String barcode { get; set; }
        public String req_id { get; set; }
        public String visit_vn { get; set; }
        public String visit_hn { get; set; }
        public String patient_name { get; set; }
        public String visit_id { get; set; }
        public String active { get; set; }
        public String remark { get; set; }
        public String date_create { get; set; }
        public String date_modi { get; set; }
        public String date_cancel { get; set; }
        public String user_create { get; set; }
        public String user_modi { get; set; }
        public String user_cancal { get; set; }
        public String message_lis { get; set; }
        public String statis_lis { get; set; }
        public String date_time_receive { get; set; }
        public String date_time_finish { get; set; }
        public String lab_id { get; set; }
    }
}
