using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    class FMarriageDB
    {
        FMarriageStatus fm;
        ConnectDB conn;
        public FMarriageDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            fm = new FMarriageStatus();
            fm.f_patient_marriage_status_id = "f_patient_marriage_status_id";
            fm.patient_marriage_status_description = "patient_marriage_status_description";

            fm.pkField = "f_patient_marriage_status_id";
            fm.table = "f_patient_marriage_status";
        }
    }
}
