using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    class FEducationTypeDB
    {
        FEducationType fet;
        ConnectDB conn;
        public FEducationTypeDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            fet = new FEducationType();
            fet.patient_education_type_description = "patient_education_type_description";
            fet.patient_education_type_description = "patient_education_type_description"; ;
            fet.f_patient_education_type_id = "f_patient_education_type_id";

            fet.pkField = "f_patient_education_type_id";
            fet.table = "f_patient_education_type";
        }
    }
}
