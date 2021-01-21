using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class AccCashTransfer:Persistent
    {
        public String cash_transfer_id { get; set; }
        public String cash_transfer_code { get; set; }
        public String cash_transfer_name { get; set; }
        public String receipt_print { get; set; }
    }
}
