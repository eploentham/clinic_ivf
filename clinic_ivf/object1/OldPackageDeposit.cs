using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class OldPackageDeposit:Persistent
    {
        public String PCKDPSID { get; set; }
        public String PCKSID { get; set; }
        public String PID { get; set; }
        public String ItemType { get; set; }
        public String ItemID { get; set; }
        public String ItemName { get; set; }
        public String QTY { get; set; }
        public String QTYused { get; set; }
        public String isPCKclosed { get; set; }
        
    }
}
