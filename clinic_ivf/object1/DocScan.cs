﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class DocScan:Persistent
    {
        public String doc_scan_id { get; set; }
        public String doc_group_id { get; set; }
        public String row_no { get; set; }
        public String host_ftp { get; set; }
        public String image_path { get; set; }
        public String hn { get; set; }
        public String vn { get; set; }
        public String visit_date { get; set; }
        public String active { get; set; }
        public String remark { get; set; }
        public String date_create { get; set; }
        public String date_modi { get; set; }
        public String date_cancel { get; set; }
        public String user_create { get; set; }
        public String user_modi { get; set; }
        public String user_cancel { get; set; }
        public String an { get; set; }
        public String doc_group_sub_id { get; set; }
        public String pre_no { get; set; }
        public String an_date { get; set; }
        public String status_ipd { get; set; }
        public String an_cnt { get; set; }
        public String folder_ftp { get; set; }
        public String status_record { get; set; }
    }
}
