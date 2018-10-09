using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class LabProcedure:Persistent
    {
        public String active { get; set; }
        public String date_cancel { get; set; }
        public String date_crete { get; set; }
        public String date_modi { get; set; }
        public String proce_code { get; set; }
        public String proce_id { get; set; }
        public String proce_name_e { get; set; }
        public String proce_name_t { get; set; }
        public String remark { get; set; }
        public String user_cancel { get; set; }
        public String user_create { get; set; }
        public String user_modi { get; set; }
        public String status_lab { get; set; }
        public String sort1 { get; set; }
        
    }
}
