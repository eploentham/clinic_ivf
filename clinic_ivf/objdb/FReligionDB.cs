using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    class FReligionDB
    {
        FReligion fr;
        ConnectDB conn;
        public FReligionDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            fr = new FReligion();
            fr.f_patient_religion_id = "f_patient_religion_id";
            fr.patient_religion_description = "patient_religion_description";

            fr.pkField = "f_patient_religion_id";
            fr.table = "f_patient_religion";
        }
    }
}
