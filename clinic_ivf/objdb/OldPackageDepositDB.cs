using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class OldPackageDepositDB
    {
        public OldPackageDeposit oPkgdp;
        ConnectDB conn;

        public OldPackageDepositDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            oPkgdp = new OldPackageDeposit();
            oPkgdp.PCKDPSID = "PCKDPSID";
            oPkgdp.PCKSID = "PCKSID";
            oPkgdp.PID = "PID";
            oPkgdp.ItemType = "ItemType";
            oPkgdp.ItemID = "ItemID";
            oPkgdp.ItemName = "ItemName";
            oPkgdp.QTY = "QTY";
            oPkgdp.QTYused = "QTYused";
            oPkgdp.isPCKclosed = "isPCKclosed";

            oPkgdp.table = "PackageDeposit";
            oPkgdp.pkField = "PCKDPSID";
        }
        public String updateStatusDPS(String pkgid)
        {
        //    $uSq1 = "UPDATE PackageDeposit SET isPCKclosed = 1 WHERE PCKSID = '$PCKSID'";
        //$uSq2 = "UPDATE PackageDepositDetail SET isPCKclosed = 1 WHERE PCKSID = '$PCKSID'";
        //$this->db->query($uSq1);
        //$this->db->query($uSq2);
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Update " + oPkgdp.table + " Set " +
                " " + oPkgdp.isPCKclosed + " = '1'" +
                "Where " + oPkgdp.PCKSID + "='" + pkgid + "'"
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
