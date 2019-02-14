using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class OldGroupDrugDetail:Persistent
    {
        public String ID { get; set; }
        public String GDID { get; set; }
        public String DUID { get; set; }
        public String DUName { get; set; }
        public String QTY { get; set; }

    }
}
