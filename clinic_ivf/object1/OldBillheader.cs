using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class OldBillheader:Persistent
    {
        public String VN { get; set; }
        public String BillNo { get; set; }
        public String PName { get; set; }
        public String Date { get; set; }
        public String Time { get; set; }
        public String PID { get; set; }
        public String PIDS { get; set; }
        public String Include_Pkg_Price { get; set; }
        public String Extra_Pkg_Price { get; set; }
        public String Total { get; set; }
        public String Discount { get; set; }
        public String CreditCardType { get; set; }
        public String CreditCardNumber { get; set; }
        public String Status { get; set; }
        public String CreditAgent { get; set; }
        public String OName { get; set; }
        public String BID { get; set; }
        public String PaymentBy { get; set; }
        public String CashID { get; set; }
        public String CreditCardID { get; set; }
        public String SepCash { get; set; }
        public String SepCredit { get; set; }
        public String ExtBillNo { get; set; }
        public String IntLock { get; set; }
        public String receipt_no { get; set; }
        public String receipt_cover_no { get; set; }
        public String bill_id { get; set; }
        public String cash { get; set; }
        public String credit { get; set; }
        public String closeday_id { get; set; }
        public String receipt1_no { get; set; }
    }
}
