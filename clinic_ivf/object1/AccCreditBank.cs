using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class AccCreditBank:Persistent
    {
        public String credit_bank_id { get; set; }
        public String credit_bank_name { get; set; }
        public String charge { get; set; }
    }
}
