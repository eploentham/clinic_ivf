﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class LabResult:Persistent
    {
        public String result_id { get; set; }
        public String lis_id { get; set; }
        public String req_id { get; set; }
        public String visit_id { get; set; }
        public String patient_id { get; set; }
        public String lab_id { get; set; }
        public String result { get; set; }
        public String method { get; set; }
        public String unit { get; set; }        
        public String sort1 { get; set; }        
        public String staff_id_result { get; set; }
        public String staff_id_approve { get; set; }
        public String date_time_result { get; set; }
        public String date_time_approve { get; set; }
        public String normal_value { get; set; }
        public String interpret { get; set; }
        public String status_result { get; set; }
        public String row1 { get; set; }
        public String lot_input { get; set; }
        public String req_date_time { get; set; }
        public String date_time_receive { get; set; }
        public String reactive_message { get; set; }
        public String doctor_id { get; set; }
        public String date_time_collect { get; set; }
        public String remark_nurse { get; set; }
    }
}
