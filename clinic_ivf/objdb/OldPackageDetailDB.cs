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
        List<OldPackageDetail> loPkgD;
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
            oPkgD.active = "active";
            oPkgD.qty_use = "qty_use";
            oPkgD.date_create = "date_create";
            oPkgD.date_modi = "date_modi";
            oPkgD.date_cancel = "date_cancel";
            oPkgD.user_create = "user_create";
            oPkgD.user_modi = "user_modi";
            oPkgD.user_cancel = "user_cancel";

            oPkgD.table = "PackageDetail";
            oPkgD.pkField = "ID";
            loPkgD = new List<OldPackageDetail>();
        }
        private void chkNull(OldPackageDetail p)
        {
            long chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.remark = p.remark == null ? "" : p.remark;

            p.ItemType = p.ItemType == null ? "" : p.ItemType;
            p.ItemName = p.ItemName == null ? "" : p.ItemName;
            //p.note_2 = p.note_2 == null ? "" : p.note_2;

            p.PCKID = long.TryParse(p.PCKID, out chk) ? chk.ToString() : "0";
            p.ItemID = long.TryParse(p.ItemID, out chk) ? chk.ToString() : "0";

            p.QTY = Decimal.TryParse(p.QTY, out chk1) ? chk1.ToString() : "0";
            p.qty_use = Decimal.TryParse(p.qty_use, out chk1) ? chk1.ToString() : "0";
        }
        public String insert(OldPackageDetail p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            sql = "Insert Into " + oPkgD.table + " Set " +
                " " + oPkgD.ItemType + " = '" + p.ItemType.Replace("'", "''") + "'" +
                "," + oPkgD.ItemName + "= '" + p.ItemName.Replace("'", "''") + "'" +
                "," + oPkgD.PCKID + "= '" + p.PCKID.Replace("'", "''") + "'" +
                //"," + oPkgD.date_create + "= now() " +
                //"," + note.date_cancel + "= '" + p.date_cancel + "'" +
                //"," + note.date_modi + "= '" + p.date_modi + "'" +
                //"," + note.user_cancel + "= '" + p.user_cancel + "'" +
                //"," + note.user_create + "= '" + userId + "'" +
                //"," + note.user_modi + "= '" + p.user_modi + "'" +
                "," + oPkgD.ItemID + "= '" + p.ItemID + "'" +
                "," + oPkgD.active + "= '" + p.active + "'" +
                "," + oPkgD.QTY + "= '" + p.QTY + "'" +
                "," + oPkgD.qty_use + "= '0'" +
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
        public String update(OldPackageDetail p, String userId)
        {
            String re = "";
            String sql = "";
            chkNull(p);

            sql = "Update " + oPkgD.table + " Set " +
                " " + oPkgD.ItemType + " = '" + p.ItemType.Replace("'", "''") + "'" +
                "," + oPkgD.ItemName + "= '" + p.ItemName.Replace("'", "''") + "'" +
                "," + oPkgD.PCKID + "= '" + p.PCKID.Replace("'", "''") + "'" +
                //"," + oPkgD.date_create + "= now() " +
                //"," + note.date_cancel + "= '" + p.date_cancel + "'" +
                //"," + note.date_modi + "= '" + p.date_modi + "'" +
                //"," + note.user_cancel + "= '" + p.user_cancel + "'" +
                //"," + note.user_create + "= '" + userId + "'" +
                //"," + note.user_modi + "= '" + p.user_modi + "'" +
                "," + oPkgD.ItemID + "= '" + p.ItemID + "'" +
                //"," + oPkgD.active + "= '" + p.active + "'" +
                "," + oPkgD.QTY + "= '" + p.QTY + "'" +
                "Where " + oPkgD.pkField + "='" + p.ID + "'";

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
        public String voidPackageDetail(String id, String userId)
        {
            String re = "";
            String sql = "";
            //chkNull(p);
            sql = "Update " + oPkgD.table + " Set " +
                " " + oPkgD.active + " = '3'" +
                "," + oPkgD.user_cancel + " = '"+ userId + "'" +
                "," + oPkgD.date_cancel + " = now() " +
                "Where " + oPkgD.pkField + "='" + id + "'";
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
            sql = "Update " + oPkgD.table + " Set " +
                " " + oPkgD.qty_use + " = "+ oPkgD.qty_use + " + "+ qtyuse + " " +
                //"," + oPkgD.user_cancel + " = '" + userId + "'" +
                //"," + oPkgD.date_cancel + " = now() " +
                "Where " + oPkgD.pkField + "='" + id + "'";
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
        public String insertPackageDetail(OldPackageDetail p, String userId)
        {
            String re = "";

            if (p.ID.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
            }
            return re;
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
                "Order By oPkgD." + oPkgD.ID;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByPkgId1(String pttId)
        {
            DataTable dt = new DataTable();
            String sql = "select oPkgD."+oPkgD.ID+ ",oPkgD." + oPkgD.ItemName+ ",oPkgD." + oPkgD.QTY+" " +
                "From " + oPkgD.table + " oPkgD " +
                "Where oPkgD." + oPkgD.PCKID + " ='" + pttId + "' and active = '1'" +
                "Order By oPkgD." + oPkgD.ItemName;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByPkgId2(String pttId)
        {
            DataTable dt = new DataTable();
            String sql = "select oPkgD." + oPkgD.ID 
                + ", case oPkgD." + oPkgD.ItemType + " when 'DUID' then 'Drug' when 'SID' then 'Special' when 'LID' then 'LAB' else oPkgD." + oPkgD.ItemType + " end as " + oPkgD.ItemType 
                + ",oPkgD." + oPkgD.ItemName + ",oPkgD." + oPkgD.QTY + ",oPkgD." + oPkgD.PCKID + ",oPkgD." + oPkgD.ItemID + ",oPkgD." + oPkgD.qty_use + " " +
                "From " + oPkgD.table + " oPkgD " +
                "Where oPkgD." + oPkgD.PCKID + " ='" + pttId + "' and active = '1'" +
                "Order By oPkgD." + oPkgD.ItemType + ",oPkgD." + oPkgD.ItemName;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public List<OldPackageDetail> selectListPackage(String pttId)
        {
            loPkgD.Clear();
            DataTable dt = new DataTable();
            String sql = "select oPkgD.*" + " " +
                "From " + oPkgD.table + " oPkgD " +
                "Where oPkgD." + oPkgD.PCKID + " ='" + pttId + "' and active = '1'" +
                "Order By oPkgD." + oPkgD.ItemName;
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                foreach(DataRow row in dt.Rows)
                {
                    OldPackageDetail ostkd1 = new OldPackageDetail();
                    ostkd1.ID = row[oPkgD.ID].ToString();
                    ostkd1.PCKID = row[oPkgD.PCKID].ToString();
                    ostkd1.ItemType = row[oPkgD.ItemType].ToString();
                    ostkd1.ItemName = row[oPkgD.ItemName].ToString();
                    ostkd1.ItemID = row[oPkgD.ItemID].ToString();
                    ostkd1.QTY = row[oPkgD.QTY].ToString();
                    ostkd1.active = row[oPkgD.active].ToString();
                    ostkd1.qty_use = row[oPkgD.qty_use].ToString();
                    loPkgD.Add(ostkd1);
                }
            }
            return loPkgD;
        }
        public OldPackageDetail setNote(DataTable dt)
        {
            OldPackageDetail ostkd1 = new OldPackageDetail();
            if (dt.Rows.Count > 0)
            {
                ostkd1.ID = dt.Rows[0][oPkgD.ID].ToString();
                ostkd1.PCKID = dt.Rows[0][oPkgD.PCKID].ToString();
                ostkd1.ItemType = dt.Rows[0][oPkgD.ItemType].ToString();
                ostkd1.ItemName = dt.Rows[0][oPkgD.ItemName].ToString();
                ostkd1.ItemID = dt.Rows[0][oPkgD.ItemID].ToString();
                ostkd1.QTY = dt.Rows[0][oPkgD.QTY].ToString();
                ostkd1.active = dt.Rows[0][oPkgD.active].ToString();
                ostkd1.qty_use = dt.Rows[0][oPkgD.qty_use].ToString();
            }
            else
            {
                setNote1(ostkd1);
            }
            return ostkd1;
        }
        private OldPackageDetail setNote1(OldPackageDetail stf1)
        {
            stf1.ID = "";
            stf1.PCKID = "";
            stf1.ItemType = "";
            stf1.ItemName = "";
            stf1.ItemID = "";
            stf1.QTY = "";
            stf1.active = "";
            stf1.qty_use = "";
            return stf1;
        }
    }
}
