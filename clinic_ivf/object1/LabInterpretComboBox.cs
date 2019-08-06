using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class LabInterpretComboBox:Persistent
    {
        public String interpret_combobox_id { get; set; }
        public String interpret_combobox_name { get; set; }
        public String lab_id { get; set; }
        public String min_value { get; set; }
        public String max_value { get; set; }
        public String min_value_criteria { get; set; }
        public String max_value_criteria { get; set; }        
        public String sort1 { get; set; }
        public String interpret { get; set; }
    }
}
