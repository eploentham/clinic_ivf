using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class Note1:Persistent
    {
        public String note_id { get; set; }
        public String note_1 { get; set; }
        public String note_2 { get; set; }
        public String t_patient_id { get; set; }
        public String b_service_point_id { get; set; }
        public String status_all { get; set; }
    }
}
