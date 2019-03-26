using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class OldPackageDetailDB
    {
        public OldPackageDetail oPkgD;
        ConnectDB conn;

        public OldPackageDetailDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            oPkgD = new OldPackageDetail();
            oPkgD.ID= "ID";
            oPkgD.PCKID= "PCKID";
            oPkgD.ItemType= "ItemType";
            oPkgD.ItemName= "ItemName";
            oPkgD.ItemID= "ItemID";
            oPkgD.QTY= "QTY";

            oPkgD.table = "PackageDetail";
            oPkgD.pkField = "ID";
        }
        public DataTable selectByPk(String pttId)
        {
            DataTable dt = new DataTable();
            String sql = "select oPkgD.* " +
                "From " + oPkgD.table + " oPkgD " +
                "Where oPkgD." + oPkgD.pkField + " ='" + pttId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByPkgId(String pttId)
        {
            DataTable dt = new DataTable();
            String sql = "select oPkgD.* " +
                "From " + oPkgD.table + " oPkgD " +
                "Where oPkgD." + oPkgD.PCKID + " ='" + pttId + "' and active = '1'" +
                "Order By oPkgD." + oPkgD.ItemName; ;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByPkgId1(String pttId)
        {
            DataTable dt = new DataTable();
            String sql = "select oPkgD."+oPkgD.ID+ ",oPkgD." + oPkgD.ItemName+ ",oPkgD." + oPkgD.QTY+" " +
                "From " + oPkgD.table + " oPkgD " +
                "Where oPkgD." + oPkgD.PCKID + " ='" + pttId + "' and active = '1'" +
                "Order By oPkgD." + oPkgD.ItemName; ;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
    }
}
