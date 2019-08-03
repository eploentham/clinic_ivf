using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class LabUnit:Persistent
    {
        public String lab_unit_id { get; set; }
        public String lab_unit_code { get; set; }
        public String lab_unit_name { get; set; }
        public String sort1 { get; set; }
    }
}
