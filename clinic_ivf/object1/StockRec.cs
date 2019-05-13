using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class StockRec:Persistent
    {
        public String rec_id { get; set; }
        public String rec_doc { get; set; }
        public String inv_ex { get; set; }
        public String description { get; set; }
        public String rec_date { get; set; }
        public String inv_ex_date { get; set; }
        public String comp_id { get; set; }
        public String vend_id { get; set; }
        public String branch_id { get; set; }
        public String status_stock { get; set; }


    }
}
