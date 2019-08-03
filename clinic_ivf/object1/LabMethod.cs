using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class LabMethod:Persistent
    {
        public String method_id { get; set; }
        public String method_code { get; set; }
        public String method_name { get; set; }
        public String sort1 { get; set; }
    }
}
