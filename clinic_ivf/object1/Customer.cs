using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class Customer:Persistent
    {
        public String cust_id { get; set; }
        public String org_id { get; set; }
        public String cust_code { get; set; }
        public String cust_name_t { get; set; }
        public String cust_name_e { get; set; }        
        public String address_t { get; set; }
        public String address_e { get; set; }
        public String addr { get; set; }
        public String amphur_id { get; set; }
        public String district_id { get; set; }
        public String province_id { get; set; }
        public String zipcode { get; set; }
        public String sale_id { get; set; }
        public String sale_name_t { get; set; }
        public String fax { get; set; }
        public String tele { get; set; }
        public String email { get; set; }
        public String tax_id { get; set; }        
        public String contact_name1 { get; set; }
        public String contact_name2 { get; set; }
        public String contact_name1_tel { get; set; }
        public String contact_name2_tel { get; set; }        
        public String remark2 { get; set; }
        public String po_due_period { get; set; }
        public String taddr1 { get; set; }
        public String taddr2 { get; set; }
        public String taddr3 { get; set; }
        public String taddr4 { get; set; }
        public String eaddr1 { get; set; }
        public String eaddr2 { get; set; }
        public String eaddr3 { get; set; }
        public String eaddr4 { get; set; }
        public String sort1 { get; set; }
        public String status_cust { get; set; }
        public String status_imp { get; set; }
        public String status_exp { get; set; }
        public String status_fwd { get; set; }
        public String status_cons_imp { get; set; }
        public String status_cons_exp { get; set; }
        public String status_supp { get; set; }
        public String status_insr { get; set; }
        public String status_company { get; set; }
        public String status_vendor { get; set; }
        public String web_site1 { get; set; }
        public String web_site2 { get; set; }
        public String web_site3 { get; set; }
        public String insr_id { get; set; }
        public String status_truck { get; set; }
        public String status_container_yard { get; set; }
        
    }
}
