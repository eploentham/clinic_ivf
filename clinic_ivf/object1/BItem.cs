using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class BItem:Persistent
    {
        public String item_id { get; set; }
        public String item_code { get; set; }
        public String item_name_t { get; set; }
        public String item_name_e { get; set; }        
        public String item_sub_group_id { get; set; }
        public String item_common_name { get; set; }
        public String item_trade_name { get; set; }
        public String item_nick_name { get; set; }
        public String item_billing_subgroop_id { get; set; }
        public String item_secret { get; set; }
        public String active { get; set; }
        public String remark { get; set; }
        public String date_create { get; set; }
        public String date_modi { get; set; }
        public String date_cancel { get; set; }
        public String user_create { get; set; }
        public String user_modi { get; set; }
        public String user_cancel { get; set; }
        public String status_item { get; set; }
        public String item_master_id { get; set; }
        public String item_link_id { get; set; }
    }
}
