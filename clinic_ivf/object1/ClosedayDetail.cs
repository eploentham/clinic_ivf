using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class ClosedayDetail:Persistent
    {
        public String closeday_detail_id { get; set; }
        public String closeday_id { get; set; }
        public String bill_no { get; set; }
        public String bill_date { get; set; }
        public String patient_hn { get; set; }
        public String patient_name { get; set; }
        public String amt_package { get; set; }
        public String amt_medicine { get; set; }
        public String amt_doctor_fee { get; set; }
        public String amt_lab_1 { get; set; }
        public String amt_lab_2 { get; set; }
        public String amt_nurse_fee { get; set; }
        public String amt_treatments { get; set; }
        public String discount { get; set; }
        public String amt_other { get; set; }
        public String amount { get; set; }
        public String bill_id { get; set; }

    }
}
