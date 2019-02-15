using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class OldPackageSoldDB
    {
        public OldPackageSold opkgs;
        ConnectDB conn;

        public OldPackageSoldDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            opkgs = new OldPackageSold();
            opkgs.PCKSID = "PCKSID";
            opkgs.PID = "PID";
            opkgs.SellThruID = "SellThruID";
            opkgs.PCKID = "PCKID";
            opkgs.PackageName = "PackageName";
            opkgs.Price = "Price";
            opkgs.Date = "Date";
            opkgs.PaymentTimes = "PaymentTimes";
            opkgs.Status = "Status";
            opkgs.Payment1 = "Payment1";
            opkgs.Payment2 = "Payment2";
            opkgs.Payment3 = "Payment3";
            opkgs.Payment4 = "Payment4";
            opkgs.P1BDetailID = "P1BDetailID";
            opkgs.P2BDetailID = "P2BDetailID";
            opkgs.P3BDetailID = "P3BDetailID";
            opkgs.P4BDetailID = "P4BDetailID";
            opkgs.VN = "VN";

            opkgs.table = "PackageSold";
            opkgs.pkField = "PCKSID";
        }
        private void chkNull(OldPackageSold p)
        {
            decimal chk = 0;
            long chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.PackageName = p.PackageName == null ? "" : p.PackageName;
            p.Date = p.Date == null ? "" : p.Date;
            p.Status = p.Status == null ? "0" : p.Status;

            p.PID = long.TryParse(p.PID, out chk1) ? chk1.ToString() : "0";
            p.SellThruID = long.TryParse(p.SellThruID, out chk1) ? chk1.ToString() : "0";
            p.PCKID = long.TryParse(p.PCKID, out chk1) ? chk1.ToString() : "0";
            
            p.PaymentTimes = long.TryParse(p.PaymentTimes, out chk1) ? chk1.ToString() : "0";
            p.P1BDetailID = long.TryParse(p.P1BDetailID, out chk1) ? chk1.ToString() : "0";
            p.P2BDetailID = long.TryParse(p.P2BDetailID, out chk1) ? chk1.ToString() : "0";
            p.P3BDetailID = long.TryParse(p.P3BDetailID, out chk1) ? chk1.ToString() : "0";
            p.P4BDetailID = long.TryParse(p.P4BDetailID, out chk1) ? chk1.ToString() : "0";
            p.VN = long.TryParse(p.VN, out chk1) ? chk1.ToString() : "0";

            p.Price = decimal.TryParse(p.Price, out chk) ? chk.ToString() : "0";
            p.Payment1 = decimal.TryParse(p.Payment1, out chk) ? chk.ToString() : "0";
            p.Payment2 = decimal.TryParse(p.Payment2, out chk) ? chk.ToString() : "0";
            p.Payment3 = decimal.TryParse(p.Payment3, out chk) ? chk.ToString() : "0";
            p.Payment4 = decimal.TryParse(p.Payment4, out chk) ? chk.ToString() : "0";
        }
        public String insert(OldPackageSold p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            //lbReq.form_a_id = "form_a_id";
            //p.req_code = genReqDoc();
            sql = "Insert Into " + opkgs.table + " Set " +
                " " + opkgs.PID + " = '" + p.PID + "'" +
                "," + opkgs.SellThruID + "= '" + p.SellThruID + "'" +
                "," + opkgs.PCKID + "= '" + p.PCKID + "'" +
                "," + opkgs.PackageName + "= '" + p.PackageName.Replace("'", "''") + "'" +
                "," + opkgs.Price + "= '" + p.Price.Replace("'", "''") + "'" +
                "," + opkgs.Date + "= '" + p.Date + "'" +
                "," + opkgs.PaymentTimes + "= '" + p.PaymentTimes + "'" +
                "," + opkgs.Status + "= '" + p.Status + "'" +
                "," + opkgs.Payment1 + "= '" + p.Payment1 + "'" +
                "," + opkgs.Payment2 + "= '" + p.Payment2 + "'" +
                "," + opkgs.Payment3 + "= '" + p.Payment3 + "'" +
                "," + opkgs.Payment4 + "= '" + p.Payment4 + "'" +
                "," + opkgs.P1BDetailID + "= '" + p.P1BDetailID + "'" +
                "," + opkgs.P2BDetailID + "= '" + p.P2BDetailID + "'" +
                "," + opkgs.P3BDetailID + "= '" + p.P3BDetailID + "'" +
                "," + opkgs.P4BDetailID + "= '" + p.P4BDetailID + "'" +
                "," + opkgs.VN + "= '" + p.VN + "'" +
                
                "";
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
        public String updateStatus3(String pkgid)
        {
            //$this->db->query("UPDATE PackageSold Set Status='3' Where PCKSID='".$PCKSID."'");
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Update " + opkgs.table + " Set " +
                " " + opkgs.Status + " = '3'" +
                "Where " + opkgs.PCKSID + "='" + pkgid + "'"
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
        public String delePackage(String pkgid)
        {
            //$this->db->query('delete from PackageSold Where PCKSID="' . $ID . '"');
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Delete From " + opkgs.table + "  " +                
                "Where " + opkgs.PCKSID + "='" + pkgid + "'"
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
