using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class OldStockDrug:Persistent
    {
        public String DUID { get; set; }
        public String DUName { get; set; }
        public String EUsage { get; set; }
        public String TUsage { get; set; }
        public String UnitType { get; set; }
        public String Alert { get; set; }
        public String QTY { get; set; }
        public String PendingQTY { get; set; }
        public String Price { get; set; }

    }
}
