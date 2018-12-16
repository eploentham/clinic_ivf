using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class AppointmentOld:Persistent
    {
        public String ID { get; set; }
        public String PID { get; set; }
        public String PIDS { get; set; }
        public String AppTime { get; set; }
        public String AppDate { get; set; }
        public String Doctor { get; set; }
        public String Status { get; set; }
        public String PatientName { get; set; }
        public String MobilePhoneNo { get; set; }
        public String PName { get; set; }
        public String PSurname { get; set; }
        public String DateOfBirth { get; set; }
        public String HormoneTest { get; set; }
        public String TVS { get; set; }
        public String OPU { get; set; }
        public String OPUTime { get; set; }
        public String OPURemark { get; set; }
        public String ET_FET { get; set; }
        public String ET_FET_Time { get; set; }
        public String BetaHCG { get; set; }
        public String Other { get; set; }
        public String OtherRemark { get; set; }
        public String Comment { get; set; }
        public String e2 { get; set; }
        public String lh { get; set; }
        public String endo { get; set; }
        public String prl { get; set; }
        public String fsh { get; set; }
        public String rt_ovary { get; set; }
        public String lt_ovary { get; set; }
        public String day1 { get; set; }
        public String et { get; set; }
        public String et_time { get; set; }
        public String tvs_time { get; set; }
    }
}
