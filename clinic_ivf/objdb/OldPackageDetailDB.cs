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
            oPkgD.active = "active";

            oPkgD.table = "PackageDetail";
            oPkgD.pkField = "ID";
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

            p.QTY = Decimal.TryParse(p.QTY, out chk1) ? chk.ToString() : "0";

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
                //"," + note.status_all + "= '" + p.status_all + "'" +
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
        public String insertNote(OldPackageDetail p, String userId)
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
        public OldPackageDetail setNote(DataTable dt)
        {
            OldPackageDetail ostkd1 = new OldPackageDetail();
            if (dt.Rows.Count > 0)
            {
                ostkd1.active = dt.Rows[0][note.active].ToString();
                ostkd1.date_cancel = dt.Rows[0][note.date_cancel].ToString();
                ostkd1.date_create = dt.Rows[0][note.date_create].ToString();
                ostkd1.date_modi = dt.Rows[0][note.date_modi].ToString();
                ostkd1.note_1 = dt.Rows[0][note.note_1].ToString();
                ostkd1.note_2 = dt.Rows[0][note.note_2].ToString();
                ostkd1.note_id = dt.Rows[0][note.note_id].ToString();
                ostkd1.remark = dt.Rows[0][note.remark].ToString();
                ostkd1.t_patient_id = dt.Rows[0][note.t_patient_id].ToString();
                ostkd1.user_cancel = dt.Rows[0][note.user_cancel].ToString();
                ostkd1.user_create = dt.Rows[0][note.user_create].ToString();
                ostkd1.user_modi = dt.Rows[0][note.user_modi].ToString();
                ostkd1.status_all = dt.Rows[0][note.status_all].ToString();
            }
            else
            {
                setNote1(ostkd1);
            }
            return ostkd1;
        }
        private Note1 setNote1(OldPackageDetail stf1)
        {
            stf1.active = "";
            stf1.date_cancel = "";
            stf1.date_create = "";
            stf1.date_modi = "";
            stf1.note_1 = "";
            stf1.note_2 = "";
            stf1.note_id = "";
            stf1.remark = "";
            stf1.t_patient_id = "";
            stf1.user_cancel = "";
            stf1.user_create = "";
            stf1.user_modi = "";
            stf1.status_all = "";
            return stf1;
        }
    }
}
