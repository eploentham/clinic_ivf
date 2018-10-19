using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    class FOccupationDB
    {
        FOccupation fo;
        ConnectDB conn;
        public FOccupationDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            fo = new FOccupation();
            fo.f_patient_occupation_id = "f_patient_occupation_id";
            fo.patient_occupation_description = "patient_occupation_description";
            fo.active = "active";

            fo.pkField = "f_patient_occupation_id";
            fo.table = "f_patient_occupation";
        }
    }
}
