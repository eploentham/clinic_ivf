using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class OldCreditCardAccount:Persistent
    {
        public String CreditCardID { get; set; }
        public String CreditCardName { get; set; }
        public String IntLock { get; set; }
        public String receipt_print { get; set; }
    }
}
