using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    class FSexDB
    {
        FSex sex;
        ConnectDB conn;
        public FSexDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            sex = new FSex();
            sex.f_sex_id = "f_sex_id";
            sex.sex_description = "sex_description";

            sex.pkField = "f_sex_id";
            sex.table = "f_sex";
        }
    }
}
