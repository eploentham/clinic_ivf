using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class LabFetDB
    {
        public LabFet fet;
        ConnectDB conn;
        public LabFetDB(ConnectDB c)
        {
            conn = c;
        }
    }
}
