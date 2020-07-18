using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class Address:Persistent
    {
        public String address_id { get; set; }
        public String address_code { get; set; }
        public String line_t1 { get; set; }
        public String line_t2 { get; set; }
        public String line_t3 { get; set; }
        public String line_t4 { get; set; }
        public String line_e1 { get; set; }
        public String line_e2 { get; set; }
        public String line_e3 { get; set; }
        public String line_e4 { get; set; }
        public String prov_id { get; set; }
        public String amphur_id { get; set; }
        public String district_id { get; set; }
        public String zipcode { get; set; }
        public String email { get; set; }
        public String email2 { get; set; }
        public String tele { get; set; }
        public String mobile { get; set; }
        public String fax { get; set; }
        public String remark { get; set; }
        public String address_type_id { get; set; }
        public String table_id { get; set; }
        public String address_name { get; set; }
        public String contact_id { get; set; }
        public String contact_id2 { get; set; }
        public String contact_name1 { get; set; }
        public String contact_name2 { get; set; }
        public String contact_name_tel1 { get; set; }
        public String contact_name_tel2 { get; set; }

        public String web_site1 { get; set; }
        public String web_site2 { get; set; }
        public String google_map { get; set; }
        public String status_defalut_customer { get; set; }
        public String remark2 { get; set; }
        public String time_open_close { get; set; }
        public String time_open_close_over_time { get; set; }
        public String web_site3 { get; set; }
        public String map_pic_path { get; set; }
        public String over_time { get; set; }
        public String rate_over_time { get; set; }
        public String status_place_addr { get; set; }
        public String status_container_yard { get; set; }
        public String status_tax { get; set; }
    }
}
