using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class LabOrderGroup:Persistent
    {
        public String lab_order_group_id { get; set; }
        public String lab_id { get; set; }
        public String sort1 { get; set; }
        public String lab_order_id { get; set; }
        public String qty { get; set; }
    }
}
