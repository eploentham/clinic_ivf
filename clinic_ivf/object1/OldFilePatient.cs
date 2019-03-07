using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class OldFilePatient:Persistent
    {
        public String ID { get; set; }
        public String PID { get; set; }
        public String Filename { get; set; }
        public String OrderFileNumber { get; set; }
        public String DateTreatment { get; set; }

    }
}
