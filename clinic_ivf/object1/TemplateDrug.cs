using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class TemplateDrug:Persistent
    {
        public String temp_drug_id { get; set; }
        public String temp_drug_name { get; set; }
        public String drug_id { get; set; }
        public String usage_thai { get; set; }
        public String usage_eng { get; set; }
        public String qty { get; set; }
        public String staff_id { get; set; }
        public String sort1 { get; set; }
    }
}
