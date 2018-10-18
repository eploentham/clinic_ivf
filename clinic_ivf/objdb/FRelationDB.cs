using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    class FRelationDB
    {
        FRelation fr;
        ConnectDB conn;
        public FRelationDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            fr = new FRelation();
            fr.f_patient_relation_id = "f_patient_relation_id";
            fr.patient_relation_description = "patient_relation_description";

            fr.pkField = "f_patient_relation_id";
            fr.table = "f_patient_relation";
        }
    }
}
