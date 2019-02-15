using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class OldPackageDepositDetailDB
    {
        public PackageDepositDetail oPkgdpd;
        ConnectDB conn;

        public OldPackageDepositDetailDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            oPkgdpd = new PackageDepositDetail();
            oPkgdpd.ID = "ID";
            oPkgdpd.PCKDPSID = "PCKDPSID";
            oPkgdpd.JobDetailID = "JobDetailID";
            oPkgdpd.VN = "VN";
            oPkgdpd.QTYused = "QTYused";
            oPkgdpd.Date = "Date";
            oPkgdpd.PCKSID = "PCKSID";
            oPkgdpd.isPCKclosed = "isPCKclosed";

            oPkgdpd.table = "PackageDepositDetail";
            oPkgdpd.pkField = "ID";
        }
        public String updateStatusDPS(String pkgid)
        {
        //    $uSq1 = "UPDATE PackageDeposit SET isPCKclosed = 1 WHERE PCKSID = '$PCKSID'";
        //$uSq2 = "UPDATE PackageDepositDetail SET isPCKclosed = 1 WHERE PCKSID = '$PCKSID'";
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Update " + oPkgdpd.table + " Set " +
                " " + oPkgdpd.isPCKclosed + " = '1'" +
                "Where " + oPkgdpd.PCKSID + "='" + pkgid + "'"
                ;
            try
            {
                re = conn.ExecuteNonQuery(conn.conn, sql);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
            }

            return re;
        }
    }
}
