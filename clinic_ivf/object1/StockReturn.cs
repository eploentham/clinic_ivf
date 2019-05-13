using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class StockReturn:Persistent
    {
        public String return_id { get; set; }
        public String return_doc { get; set; }
        public String draw_id { get; set; }
        public String return_date { get; set; }
        public String description { get; set; }
        public String comp_id { get; set; }
        public String branch_id { get; set; }
        public String status_stock { get; set; }
        public String cust_id_return { get; set; }     
    }
}
