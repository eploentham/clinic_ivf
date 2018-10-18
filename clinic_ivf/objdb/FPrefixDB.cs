using clinic_ivf.objdb;
using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    class FPrefixDB
    {
        FPrefix fp;
        ConnectDB conn;
        public FPrefixDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            fp = new FPrefix();
            fp.active = "active";
            fp.f_patient_prefix_id = "f_patient_prefix_id";
            fp.f_sex_id = "f_sex_id";            
            fp.patient_prefix_description = "patient_prefix_description";

            fp.pkField = "f_patient_prefix_id";
            fp.table = "f_patient_prefix";
        }
    }
}
