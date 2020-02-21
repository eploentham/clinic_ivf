using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class OldSpecialItem:Persistent
    {
        public String SID { get; set; }
        public String SName { get; set; }
        public String Price { get; set; }
        public String W1GID { get; set; }
        public String W2GID { get; set; }
        public String W3GID { get; set; }
        public String W4GID { get; set; }
        public String isActive { get; set; }
        public String BillGroupID { get; set; }
        public String item_code { get; set; }

    }
}
