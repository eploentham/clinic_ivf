using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class LabPrescription:Persistent
    {
        public String presc_id { get; set; }
        public String opu_fet_id { get; set; }
        public String presc_date { get; set; }
        public String pkg_id { get; set; }
        public String status_embryo_freezing { get; set; }
        public String embryo_freezing { get; set; }
        public String embryo_straws { get; set; }
        public String embryo_straws_extra { get; set; }
        public String status_ngs { get; set; }
        public String embryo_ngs { get; set; }
        public String embryo_ngs_extra { get; set; }
        public String status_pgs { get; set; }
        public String embryo_pgs { get; set; }
        public String embryo_pgs_extra { get; set; }
        public String status_day6 { get; set; }
        public String status_assisted_hatching { get; set; }
        public String status_ha { get; set; }
        public String status_sperm_selection { get; set; }
        public String status_sperm_precaution { get; set; }
        public String status_embryo_glue { get; set; }
        public String status_embryo_remaining { get; set; }
        public String embryo_remaining { get; set; }
        public String status_discard_all { get; set; }
        public String staff_id { get; set; }
        public String checkby_id { get; set; }
        public String sperm_selection { get; set; }
        public String sperm_precaution { get; set; }
        public String visit_hn { get; set; }
    }
}
