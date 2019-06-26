using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class Closeday:Persistent
    {
        public String closeday_id { get; set; }
        public String closeday_date { get; set; }
        public String cnt_patient { get; set; }
        public String amt_cash { get; set; }
        public String amt_credit_card { get; set; }
        public String amount { get; set; }
        public String expense_1 { get; set; }
        public String expense_2 { get; set; }
        public String expense_3 { get; set; }
        public String expense_4 { get; set; }
        public String expense_5 { get; set; }
        public String total_cash { get; set; }
        public String deposit { get; set; }

    }
}
