using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.object1
{
    public class BContractPayer:Persistent
    {
        public String b_contract_payer_id { get; set; }
        public String contract_payer_number { get; set; }
        public String contract_payer_description { get; set; }
        public String contract_payer_active { get; set; }
    }
}
