using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class StockCardEndYear:Persistent
    {
        public String stock_endyear_id { get; set; }
        public String year_id { get; set; }
        public String item_id { get; set; }
        public String price { get; set; }
        public String qty { get; set; }
        public String weight { get; set; }
        public String rec_draw_sale_id { get; set; }
        public String status_rec_draw { get; set; }
        public String rec_draw_sale_date { get; set; }
        public String active { get; set; }
        public String date_create { get; set; }
        public String date_modi { get; set; }
        public String date_cancel { get; set; }
        public String user_create { get; set; }
        public String user_modi { get; set; }
        public String user_cancel { get; set; }
        public String remark { get; set; }
        public String sort1 { get; set; }
        public String onhand { get; set; }
        public String host_id { get; set; }
        public String branch_id { get; set; }
        public String device_id { get; set; }
        public String remark1 { get; set; }
        public String description { get; set; }
        public String doc_no { get; set; }
    }
}
