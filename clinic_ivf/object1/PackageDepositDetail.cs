using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class PackageDepositDetail:Persistent
    {
        public String ID { get; set; }
        public String PCKDPSID { get; set; }
        public String JobDetailID { get; set; }
        public String VN { get; set; }
        public String QTYused { get; set; }
        public String Date { get; set; }
        public String PCKSID { get; set; }
        public String isPCKclosed { get; set; }

    }
}
