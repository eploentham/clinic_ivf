using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class OldJobLab:Persistent
    {
        public String VN { get; set; }
        public String Status { get; set; }
        public String Include_Pkg_Price { get; set; }
        public String Extra_Pkg_Price { get; set; }
        public String Total_Price { get; set; }
        public String Date { get; set; }
        public String PID { get; set; }
        public String PIDS { get; set; }
    }
}
