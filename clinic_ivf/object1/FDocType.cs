using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class FDocType:Persistent
    {
        public String doc_type_id { get; set; }
        public String doc_type_code { get; set; }
        public String doc_type_name { get; set; }
        public String active { get; set; }
        public String status_combo { get; set; }
        
    }
}
