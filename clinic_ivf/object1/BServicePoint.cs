using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class BServicePoint:Persistent
    {
        public String b_service_point_id { get; set; }
        public String service_point_number { get; set; }
        public String service_point_description { get; set; }
        public String f_service_group_id { get; set; }
        public String f_service_subgroup_id { get; set; }
        public String active { get; set; }
        public String service_point_check { get; set; }
        public String service_point_operation_room { get; set; }
        public String service_point_color { get; set; }
        public String alert_send_opdcard { get; set; }
        public String is_ipd { get; set; }
    }
}
