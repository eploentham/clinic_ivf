using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
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
            oPkgdp.date_cancel = "date_cancel";
            oPkgdp.date_create = "date_create";
            oPkgdp.date_modi = "date_modi";
            oPkgdp.user_cancel = "user_cancel";
            oPkgdp.user_create = "user_create";
            oPkgdp.user_modi = "user_modi";
            oPkgdp.remark = "remark";
            oPkgdp.active = "active";

            oPkgdp.table = "PackageDeposit";
            oPkgdp.pkField = "PCKDPSID";
        }
        public DataTable selectByPkgId2(String pttId)
        {
            DataTable dt = new DataTable();
            String sql = "select oPkgdp." + oPkgdp.PCKDPSID
                + ", case oPkgdp." + oPkgdp.ItemType + " when 'DUID' then 'Drug' when 'SID' then 'Special' when 'LID' then 'LAB' else oPkgdp." + oPkgdp.ItemType + " end as " + oPkgdp.ItemType
                + ",oPkgdp." + oPkgdp.ItemName + ",oPkgdp." + oPkgdp.QTY + ",oPkgdp." + oPkgdp.PCKSID + ",oPkgdp." + oPkgdp.ItemID + ",oPkgdp." + oPkgdp.QTYused + " " +
                "From " + oPkgdp.table + " oPkgdp " +
                "Where oPkgdp." + oPkgdp.PCKSID + " ='" + pttId + "' and active = '1'" +
                "Order By oPkgdp." + oPkgdp.ItemType + ",oPkgdp." + oPkgdp.ItemName;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        private void chkNull(OldPackageDeposit p)
        {
            long chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.remark = p.remark == null ? "" : p.remark;
            p.ItemType = p.ItemType == null ? "0" : p.ItemType;

            p.isPCKclosed = p.isPCKclosed == null ? "" : p.isPCKclosed;
            p.ItemName = p.ItemName == null ? "" : p.ItemName;

            p.PCKSID = long.TryParse(p.PCKSID, out chk) ? chk.ToString() : "0";
            p.PID = long.TryParse(p.PID, out chk) ? chk.ToString() : "0";
            p.ItemID = long.TryParse(p.ItemID, out chk) ? chk.ToString() : "0";
            //p.b_service_point_id = long.TryParse(p.b_service_point_id, out chk) ? chk.ToString() : "0";

        }
        public String insert(OldPackageDeposit p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            sql = "Insert Into " + oPkgdp.table + " Set " +
                " " + oPkgdp.PCKSID + " = '" + p.PCKSID + "'" +
                "," + oPkgdp.PID + "= '" + p.PID + "'" +
                "," + oPkgdp.remark + "= '" + p.remark.Replace("'", "''") + "'" +
                "," + oPkgdp.date_create + "= now() " +
                "," + oPkgdp.date_cancel + "= '" + p.date_cancel + "'" +
                "," + oPkgdp.date_modi + "= '" + p.date_modi + "'" +
                "," + oPkgdp.user_cancel + "= '" + p.user_cancel + "'" +
                "," + oPkgdp.user_create + "= '" + userId + "'" +
                "," + oPkgdp.user_modi + "= '" + p.user_modi + "'" +
                "," + oPkgdp.ItemType + "= '" + p.ItemType + "'" +
                "," + oPkgdp.active + "= '" + p.active + "'" +
                "," + oPkgdp.ItemID + "= '" + p.ItemID + "'" +
                "," + oPkgdp.ItemName + "= '" + p.ItemName.Replace("'","''") + "'" +
                "," + oPkgdp.QTY + "= '" + p.QTY + "'" +
                "," + oPkgdp.QTYused + "= '" + p.QTYused + "'" +
                "," + oPkgdp.isPCKclosed + "= '" + p.isPCKclosed + "'" +
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
        public String update(OldPackageDeposit p, String userId)
        {
            String re = "";
            String sql = "";
            chkNull(p);

            sql = "Update " + oPkgdp.table + " Set " +
                " " + oPkgdp.PCKSID + " = '" + p.PCKSID + "'" +
                "," + oPkgdp.PID + "= '" + p.PID + "'" +
                "," + oPkgdp.remark + "= '" + p.remark.Replace("'", "''") + "'" +
                "," + oPkgdp.date_create + "= now() " +
                "," + oPkgdp.date_cancel + "= '" + p.date_cancel + "'" +
                "," + oPkgdp.date_modi + "= '" + p.date_modi + "'" +
                "," + oPkgdp.user_cancel + "= '" + p.user_cancel + "'" +
                "," + oPkgdp.user_create + "= '" + userId + "'" +
                "," + oPkgdp.user_modi + "= '" + p.user_modi + "'" +
                "," + oPkgdp.ItemType + "= '" + p.ItemType + "'" +
                "," + oPkgdp.active + "= '" + p.active + "'" +
                "," + oPkgdp.ItemID + "= '" + p.ItemID + "'" +
                "," + oPkgdp.ItemName + "= '" + p.ItemName.Replace("'", "''") + "'" +
                "," + oPkgdp.QTY + "= '" + p.QTY + "'" +
                "," + oPkgdp.QTYused + "= '" + p.QTYused + "'" +
                "," + oPkgdp.isPCKclosed + "= '" + p.isPCKclosed + "'" +
                "Where " + oPkgdp.pkField + "='" + p.PCKDPSID + "'";

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
        public String insertPackageDeposit(OldPackageDeposit p, String userId)
        {
            String re = "";

            if (p.PCKDPSID.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
            }

            return re;
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
        public String upDateQtyUse(String id, String qtyuse)
        {
            String re = "";
            String sql = "";
            //chkNull(p);
            sql = "Update " + oPkgdp.table + " Set " +
                " " + oPkgdp.QTYused + " = " + oPkgdp.QTYused + " + " + qtyuse + " " +
                //"," + oPkgD.user_cancel + " = '" + userId + "'" +
                //"," + oPkgD.date_cancel + " = now() " +
                "Where " + oPkgdp.pkField + "='" + id + "'";
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
        public String voidPackageDeposit(String pid)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            sql = "Update " + oPkgdp.table + " Set " +
                " " + oPkgdp.active + " = '3'" +
                "Where " + oPkgdp.PID + "='" + pid + "'";
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
        public OldPackageDeposit setNote(DataTable dt)
        {
            OldPackageDeposit ostkd1 = new OldPackageDeposit();
            if (dt.Rows.Count > 0)
            {
                ostkd1.active = dt.Rows[0][oPkgdp.active].ToString();
                ostkd1.date_cancel = dt.Rows[0][oPkgdp.date_cancel].ToString();
                ostkd1.date_create = dt.Rows[0][oPkgdp.date_create].ToString();
                ostkd1.date_modi = dt.Rows[0][oPkgdp.date_modi].ToString();
                ostkd1.remark = dt.Rows[0][oPkgdp.remark].ToString();
                ostkd1.user_cancel = dt.Rows[0][oPkgdp.user_cancel].ToString();
                ostkd1.user_create = dt.Rows[0][oPkgdp.user_create].ToString();
                ostkd1.user_modi = dt.Rows[0][oPkgdp.user_modi].ToString();
                ostkd1.PCKDPSID = dt.Rows[0][oPkgdp.PCKDPSID].ToString();
                ostkd1.PCKSID = dt.Rows[0][oPkgdp.PCKSID].ToString();
                ostkd1.PID = dt.Rows[0][oPkgdp.PID].ToString();
                ostkd1.ItemType = dt.Rows[0][oPkgdp.ItemType].ToString();
                ostkd1.ItemID = dt.Rows[0][oPkgdp.ItemID].ToString();
                ostkd1.ItemName = dt.Rows[0][oPkgdp.ItemName].ToString();
                ostkd1.QTY = dt.Rows[0][oPkgdp.QTY].ToString();
                ostkd1.QTYused = dt.Rows[0][oPkgdp.QTYused].ToString();
                ostkd1.isPCKclosed = dt.Rows[0][oPkgdp.isPCKclosed].ToString();
            }
            else
            {
                setNote1(ostkd1);
            }
            return ostkd1;
        }
        private OldPackageDeposit setNote1(OldPackageDeposit stf1)
        {
            stf1.active = "";
            stf1.date_cancel = "";
            stf1.date_create = "";
            stf1.date_modi = "";
            stf1.remark = "";
            stf1.user_cancel = "";
            stf1.user_create = "";
            stf1.user_modi = "";
            stf1.PCKDPSID = "";
            stf1.PCKSID = "";
            stf1.PID = "";
            stf1.ItemType = "";
            stf1.ItemID = "";
            stf1.ItemName = "";
            stf1.QTY = "";
            stf1.QTYused = "";
            stf1.isPCKclosed = "";
            return stf1;
        }
    }
}
