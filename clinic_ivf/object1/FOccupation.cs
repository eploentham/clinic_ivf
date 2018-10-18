using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class FOccupation:Persistent
    {
        public String patient_occupation_description { get; set; }
        public String f_patient_occupation_active { get; set; }
        public String f_patient_occupation_id { get; set; }
    }
}
