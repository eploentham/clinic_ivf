using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class StockReturnDetail:Persistent
    {
        public String return_detail_id { get; set; }
        public String return_id { get; set; }
        public String goods_id { get; set; }
        public String qty { get; set; }
        public String status_stock { get; set; }     
    }
}
