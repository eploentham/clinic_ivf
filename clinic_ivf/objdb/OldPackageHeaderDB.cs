using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class OldPackageHeaderDB
    {
        public OldPackageHeader oPkg;
        ConnectDB conn;

        public OldPackageHeaderDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            oPkg = new OldPackageHeader();
            oPkg.PCKID = "PCKID";
            oPkg.PackageName = "PackageName";
            oPkg.Price = "Price";

            oPkg.table = "PackageHeader";
            oPkg.pkField = "PCKID";
        }
        public DataTable selectByPk(String pttId)
        {
            DataTable dt = new DataTable();
            String sql = "select oPkg.* " +
                "From " + oPkg.table + " oPkg " +
                "Where oPkg." + oPkg.pkField + " ='" + pttId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select oPkg." + oPkg.PCKID + ",oPkg." + oPkg.PackageName + ",oPkg." + oPkg.Price + " " +
                "From " + oPkg.table + " oPkg " +
                "Where active = '1' " +
                "Order By oPkg." + oPkg.PackageName;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
    }
}
