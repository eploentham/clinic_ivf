using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class OrOperationGroup:Persistent
    {
        public String opera_group_id { get; set; }
        public String opera_group_code { get; set; }
        public String opera_group_name { get; set; }
        public String status_or_opera_req { get; set; }
        public String sort1 { get; set; }
        public String status_or_us { get; set; }
    }
}
