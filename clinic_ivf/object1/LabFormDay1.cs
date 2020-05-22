using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class LabFormDay1:Persistent
    {
        public String form_day1_id { get; set; }
        public String t_patient_id { get; set; }
        public String t_visit_id { get; set; }
        public String day1_date { get; set; }
        public String form_day1_code { get; set; }
        public String hn_male { get; set; }
        public String hn_female { get; set; }
        public String name_male { get; set; }
        public String name_female { get; set; }
        public String hn_donor { get; set; }
        public String name_donor { get; set; }
        public String day1_remark { get; set; }
        public String dob_male { get; set; }
        public String dob_female { get; set; }
        public String dob_donor { get; set; }
        public String status_no_biopsy { get; set; }
        public String status_biopsy_pgs { get; set; }
        public String status_biopsy_ngs { get; set; }
        public String status_biopsy_ngs_7_pair { get; set; }
        public String status_biopsy_ngs_23_pair { get; set; }
        public String biopsy_pgs_min { get; set; }
        public String biopsy_pgs_max { get; set; }
        public String biopsy_ngs_min { get; set; }
        public String biopsy_ngs_max { get; set; }
        public String status_embryo_freezing_day { get; set; }
        public String embryo_freezing_day { get; set; }
        public String embryo_freezing_day_max { get; set; }
        public String status_stage_blastocyst { get; set; }
        public String status_stage_morula { get; set; }
        public String status_stage_cleavage { get; set; }
        public String status_embryo_tranfer { get; set; }
        public String status_embryo_tranfer_day { get; set; }
        public String status_embryo_tranfer_embryo_glue { get; set; }
        public String status_discard_all { get; set; }
        public String status_remark { get; set; }
        public String remark_other { get; set; }
        public String form_a_id { get; set; }
        public String fertili_2_pn { get; set; }
    }
}
