using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class StockDraw:Persistent
    {
        public String draw_id { get; set; }
        public String draw_doc { get; set; }
        public String inv_ex { get; set; }
        public String description { get; set; }
        public String draw_date { get; set; }
        public String comp_id { get; set; }
        public String vend_id { get; set; }
        public String branch_id_draw { get; set; }
        public String cust_id_rec { get; set; }
        public String status_stock { get; set; }
     
    }
}
