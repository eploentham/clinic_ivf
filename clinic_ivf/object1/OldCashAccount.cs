using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class OldCashAccount:Persistent
    {
        public String CashID { get; set; }
        public String CashName { get; set; }
        public String IntLock { get; set; }
        public String active { get; set; }
        public String receipt_print { get; set; }
    }
}
