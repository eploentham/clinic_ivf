using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class BContractPlans:Persistent
    {
        public String b_contract_id { get; set; }
        public String b_contract_payer_id { get; set; }
        public String b_contract_plans_id { get; set; }
        public String active { get; set; }
        public String contract_plans_active_from { get; set; }
        public String contract_plans_active_to { get; set; }
        public String contract_plans_color { get; set; }
        public String contract_plans_description { get; set; }
        public String contract_plans_hide_company { get; set; }
        public String contract_plans_money_limit { get; set; }
        public String contract_plans_number { get; set; }
        public String contract_plans_pttype { get; set; }
        public String contract_plans_sort_index { get; set; }
        public String r_rp1853_instype_id { get; set; }
    }
}
