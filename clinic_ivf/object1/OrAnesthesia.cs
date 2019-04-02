using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class OrAnesthesia:Persistent
    {
        public String anesthesia_id { get; set; }
        public String anesthesia_code { get; set; }
        public String anesthesia_code_ex { get; set; }
        public String anesthesia_name { get; set; }
        public String sort1 { get; set; }
    }
}
