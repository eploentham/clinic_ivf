using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class EggStiDay:Persistent
    {
        public String egg_sti_day_id { get; set; }
        public String egg_sti_id { get; set; }
        public String day1 { get; set; }
        public String date { get; set; }
        public String e2 { get; set; }
        public String lh { get; set; }
        public String fsh { get; set; }
        public String prolactin { get; set; }
        public String rt_ovary_1 { get; set; }
        public String rt_ovary_2 { get; set; }
        public String lt_ovary_1 { get; set; }
        public String lt_ovary_2 { get; set; }
        public String endo { get; set; }
        public String medication { get; set; }
        public String active { get; set; }
        public String date_create { get; set; }
        public String date_modi { get; set; }
        public String date_cancel { get; set; }
        public String user_create { get; set; }
        public String user_modi { get; set; }
        public String user_cancel { get; set; }
    }
}
