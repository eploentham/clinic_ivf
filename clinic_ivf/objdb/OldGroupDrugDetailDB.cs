using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class OldGroupDrugDetailDB
    {
        public OldGroupDrugDetail oGuD;
        ConnectDB conn;

        public OldGroupDrugDetailDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            oGuD = new OldGroupDrugDetail();
            oGuD.ID= "ID";
            oGuD.GDID= "GDID";
            oGuD.DUID= "DUID";
            oGuD.DUName= "DUName";
            oGuD.QTY= "QTY";

            oGuD.table = "GroupDrugDetail";
            oGuD.pkField = "ID";
        }
        public DataTable selectByPk(String pttId)
        {
            DataTable dt = new DataTable();
            String sql = "select oGuD.* " +
                "From " + oGuD.table + " oGuD " +
                "Where oGuD." + oGuD.pkField + " ='" + pttId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByGdId(String id)
        {
            DataTable dt = new DataTable();
            String sql = "select oGuD.* " +
                "From " + oGuD.table + " oGuD " +
                "Where oGuD." + oGuD.GDID + " ='" + id + "' and active = '1' " +
                "Order By oGuD." + oGuD.DUName;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
    }
}
