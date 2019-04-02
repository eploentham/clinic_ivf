using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class OrDiag:Persistent
    {
        public String diag_id { get; set; }
        public String diag_code { get; set; }
        public String diag_code_ex { get; set; }
        public String diag_name { get; set; }
        public String diag_group_id { get; set; }
        public String sort1 { get; set; }
    }
}
