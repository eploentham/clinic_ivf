using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class OldBilldetail:Persistent
    {
        public String ID { get; set; }
        public String VN { get; set; }
        public String Name { get; set; }
        public String Extra { get; set; }
        public String Price { get; set; }
        public String Total { get; set; }
        public String GroupType { get; set; }
        public String Comment { get; set; }
        public String item_id { get; set; }
        public String status { get; set; }
        public String pcksid { get; set; }
        public String price1 { get; set; }
        public String qty { get; set; }
        public String bill_id { get; set; }
        public String sort1 { get; set; }
        public String closeday_id { get; set; }
    }
}
