using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class Position:Persistent
    {
        public String posi_id { get; set; }
        public String posi_code { get; set; }
        public String posi_name_t { get; set; }
        public String posi_name_e { get; set; }
        public String dept_id { get; set; }
        public String date_create { get; set; }
        public String date_modi { get; set; }
        public String date_cancel { get; set; }
        public String user_create { get; set; }
        public String user_modi { get; set; }
        public String user_cancel { get; set; }
        public String active { get; set; }
        public String remark { get; set; }
        public String sort1 { get; set; }
        public String status_doctor { get; set; }
    }
}
