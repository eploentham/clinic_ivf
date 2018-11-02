using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class PatientImage:Persistent
    {
        public String patient_image_id { get; set; }
        public String t_patient_id { get; set; }
        public String t_visit_id { get; set; }
        public String desc1 { get; set; }
        public String desc2 { get; set; }
        public String desc3 { get; set; }
        public String desc4 { get; set; }
        public String active { get; set; }
        public String remark { get; set; }
        public String date_create { get; set; }
        public String date_modi { get; set; }
        public String date_cancel { get; set; }
        public String user_create { get; set; }
        public String user_modi { get; set; }
        public String user_cancel { get; set; }
        public String image_path { get; set; }
        public String status_image { get; set; }
    }
}
