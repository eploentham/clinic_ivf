﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class OldJobSpecialDetail:Persistent
    {
        public String ID { get; set; }
        public String VN { get; set; }
        public String SID { get; set; }
        public String SName { get; set; }
        public String Extra { get; set; }
        public String Price { get; set; }
        public String Status { get; set; }
        public String PID { get; set; }
        public String PIDS { get; set; }
        public String W1UID { get; set; }
        public String W2UID { get; set; }
        public String W3UID { get; set; }
        public String W4UID { get; set; }
        public String FileName { get; set; }
    }
}