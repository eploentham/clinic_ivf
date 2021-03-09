using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class DepositWithDraw:Persistent
    {
        public String withdraw_id { get; set; }
        public String deposit_id { get; set; }
        public String withdraw_code { get; set; }
        public String withdraw_date { get; set; }
        public String patient_hn { get; set; }
        public String visit_vn { get; set; }
        public String t_visit_id { get; set; }
        public String withdraw_name { get; set; }
        public String withdraw_amount { get; set; }
        public String t_patient_id { get; set; }

    }
}
