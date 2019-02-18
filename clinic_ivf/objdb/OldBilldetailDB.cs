using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class OldBilldetailDB
    {
        public OldBilldetail obilld;
        ConnectDB conn;

        public OldBilldetailDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            obilld = new OldBilldetail();
            obilld.ID= "ID";
            obilld.VN= "VN";
            obilld.Name= "Name";
            obilld.Extra= "Extra";
            obilld.Price= "Price";
            obilld.Total= "Total";
            obilld.GroupType= "GroupType";
            obilld.Comment= "Comment";

            obilld.table = "OldBilldetail";
            obilld.pkField = "ID";
        }


    }
}
