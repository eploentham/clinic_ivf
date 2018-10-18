using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    class FNationDB
    {
        FNation fn;
        ConnectDB conn;
        public FNationDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            fn = new FNation();
            fn.f_patient_nation_id = "f_patient_nation_id";
            fn.patient_nation_description = "patient_nation_description";

            fn.pkField = "f_patient_nation_id";
            fn.table = "f_patient_nation";
        }
    }
}
