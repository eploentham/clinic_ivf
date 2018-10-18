using clinic_ivf.objdb;
using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    class FPatientDischargeStatusDB
    {
        FPatientDischargeStatus fds;
        ConnectDB conn;
        public FPatientDischargeStatusDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            fds = new FPatientDischargeStatus();
            fds.patient_discharge_status_description = "patient_discharge_status_description";
            fds.f_patient_discharge_status_id = "f_patient_discharge_status_id";

            fds.pkField = "f_patient_discharge_status_id";
            fds.table = "f_patient_discharge_status";
        }
    }
}
