﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class OldJobPxDetail:Persistent
    {
        public String ID { get; set; }
        public String VN { get; set; }
        public String DUID { get; set; }
        public String QTY { get; set; }
        public String Extra { get; set; }
        public String Price { get; set; }
        public String Status { get; set; }
        public String PID { get; set; }
        public String PIDS { get; set; }
        public String DUName { get; set; }
        public String Comment { get; set; }
        public String TUsage { get; set; }
        public String EUsage { get; set; }
        public String row1 { get; set; }
        public String price1 { get; set; }
        public String pckdid { get; set; }
        public String status_print { get; set; }
        public String status_up_stock { get; set; }
        public String pharmacy_finish_date_time { get; set; }
        public String pharmacy_sticker_date_time { get; set; }
    }
}
