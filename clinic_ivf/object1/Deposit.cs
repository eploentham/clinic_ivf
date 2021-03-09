using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class Deposit:Persistent
    {
        public String deposit_id { get; set; }
        public String deposit_code { get; set; }
        public String deposit_date { get; set; }
        public String patient_hn { get; set; }
        public String deposit_name { get; set; }
        public String deposit_amount { get; set; }        
        public String status_deposit { get; set; }
        public String pck_id { get; set; }
        public String amount { get; set; }
        public String t_patient_id { get; set; }
    }
}
