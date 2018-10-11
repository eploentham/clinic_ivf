using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class VisitOld:Persistent
    {
        public String VN { get; set; }
        public String VSID { get; set; }
        public String PID { get; set; }
        public String PIDS { get; set; }
        public String PName { get; set; }
        public String OName { get; set; }
        public String VDate { get; set; }
        public String VStartTime { get; set; }
        public String VEndTime { get; set; }
        public String VUpdateTime { get; set; }
        public String LVSID { get; set; }
        public String IntLock { get; set; }
    }
}
