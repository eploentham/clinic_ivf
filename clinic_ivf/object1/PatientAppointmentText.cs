using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class PatientAppointmentText:Persistent
    {
        public String patient_appointment_text_id { get; set; }
        public String patient_appointment_date { get; set; }
        public String doctor_name { get; set; }
        public String appointment_text { get; set; }
    }
}
