using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class LabOpuEmbryoDev:Persistent
    {
        public String opu_embryo_dev_id { get; set; }
        public String opu_fet_id { get; set; }
        public String day { get; set; }
        public String opu_embryo_dev_no { get; set; }
        public String desc0 { get; set; }
        public String active { get; set; }
        public String remark { get; set; }
        public String path_pic { get; set; }
        public String date_create { get; set; }
        public String date_modi { get; set; }
        public String date_cancel { get; set; }
        public String user_create { get; set; }
        public String user_modi { get; set; }
        public String user_cancel { get; set; }
        public String desc1 { get; set; }
        public String desc2 { get; set; }
        public String desc3 { get; set; }
        public String staff_id { get; set; }
        public String checked_id { get; set; }
        public String embryo_dev_date { get; set; }
        public String desc4 { get; set; }
        public String desc5 { get; set; }
        public String status_biopsy_ngs { get; set; }
    }
}
