using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class Prefix:Persistent
    {
        public String prefix_id { get; set; }
        public String prefix_code { get; set; }
        public String prefix_name_t { get; set; }
        public String prefix_name_e { get; set; }
    }
}
