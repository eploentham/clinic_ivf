using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    class FBloodGroupDB
    {
        FBloodGroup fbg;
        ConnectDB conn;
        public FBloodGroupDB(ConnectDB connorc_ma)
        {
            conn = connorc_ma;
            initConfig();
        }
        private void initConfig()
        {
            fbg = new FBloodGroup();
            fbg.f_patient_blood_group_id = "f_patient_blood_group_id";
            fbg.patient_blood_group_description = "patient_blood_group_description";

            fbg.pkField = "f_patient_blood_group_id";
            fbg.table = "f_patient_blood_group";
        }
    }
}
