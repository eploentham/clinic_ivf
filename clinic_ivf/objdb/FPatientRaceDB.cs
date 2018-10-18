using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    class FPatientRaceDB
    {
        FPatientRace fn;
        ConnectDB conn;
        public FPatientRaceDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            fn = new FPatientRace();
            fn.f_patient_race_id = "f_patient_race_id";
            fn.patient_race_description = "patient_race_description";

            fn.pkField = "f_patient_race_id";
            fn.table = "f_patient_race";
        }
    }
}
