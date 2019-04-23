using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class EggSti:Persistent
    {
        public String egg_sti_id { get; set; }
        public String lmp_date { get; set; }
        public String nurse_t_egg_sticol { get; set; }
        public String status_g { get; set; }
        public String p { get; set; }
        public String a { get; set; }
        public String g { get; set; }
        public String opu_date { get; set; }
        public String opu_time { get; set; }
        public String et { get; set; }
        public String fet { get; set; }
        public String bhcg_test { get; set; }
    }
}
