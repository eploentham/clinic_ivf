using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class StockRecDetail:Persistent
    {
        public String rec_detail_id { get; set; }
        public String rec_id { get; set; }
        public String goods_id { get; set; }
        public String price { get; set; }
        public String cost { get; set; }
        public String qty { get; set; }
        public String amount { get; set; }
        public String unit_id { get; set; }
        public String status_stock { get; set; }
        public String row1 { get; set; }
        public String unit_name { get; set; }
        public String date_expire { get; set; }
        public String lot_no { get; set; }
    }
}
