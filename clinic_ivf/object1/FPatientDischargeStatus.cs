using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class FPatientDischargeStatus:Persistent
    {
        public String f_patient_discharge_status_id { get; set; }
        public String patient_discharge_status_description { get; set; }
    }
}
