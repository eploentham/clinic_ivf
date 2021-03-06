﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class Department:Persistent
    {
        public String dept_id { get; set; }
        public String depart_code { get; set; }
        public String depart_name_t { get; set; }
        public String comp_id { get; set; }
        public String dept_parent_id { get; set; }
        public String remark { get; set; }
        public String date_create { get; set; }
        public String date_modi { get; set; }
        public String date_cancel { get; set; }
        public String user_create { get; set; }
        public String user_modi { get; set; }
        public String user_cancel { get; set; }
        public String active { get; set; }
        public String sort1 { get; set; }
    }
}
