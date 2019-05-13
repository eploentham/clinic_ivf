using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class StockDrawDetail:Persistent
    {
        public String draw_detail_id { get; set; }
        public String draw_id { get; set; }
        public String goods_id { get; set; }
        public String price { get; set; }
        public String cost { get; set; }
        public String qty { get; set; }
        public String amount { get; set; }
        public String unit_id { get; set; }
        public String hn { get; set; }
        public String status_stock { get; set; }
    }
}
