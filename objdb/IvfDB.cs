using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class IvfDB
    {
        ConnectDB conn;

        public StaffDB stfDB;

        public IvfDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            Console.WriteLine("ivfDB start");
            stfDB = new StaffDB(conn);
            
            Console.WriteLine("ivfDB end");
        }
    }
}
