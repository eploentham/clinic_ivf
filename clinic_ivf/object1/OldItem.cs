using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class OldItem:Persistent
    {
        public String id { get; set; }
        public String item_type_id { get; set; }
        public String item_type { get; set; }
        public String item_name { get; set; }
        public String total_price { get; set; }
        public String total_qty { get; set; }
        public String unit_price { get; set; }
        public String average_price { get; set; }
        public String DUID { get; set; }
        public String DUID_QTY { get; set; }
        public String item_code { get; set; }
        public String item_common_name { get; set; }
        public String item_trade_name { get; set; }

    }
}
