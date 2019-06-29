using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
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
            obilld.item_id = "item_id";
            obilld.status = "status";
            obilld.pcksid = "pcksid";
            obilld.price1 = "price1";
            obilld.qty = "qty";
            obilld.bill_id = "bill_id";
            obilld.active = "active";
            obilld.remark = "remark";
            obilld.sort1 = "sort1";
            obilld.date_cancel = "date_cancel";
            obilld.date_create = "date_create";
            obilld.date_modi = "date_modi";
            obilld.user_cancel = "user_cancel";
            obilld.user_create = "user_create";
            obilld.user_modi = "user_modi";
            obilld.closeday_id = "closeday_id";
            obilld.bill_group_id = "bill_group_id";

            obilld.table = "BillDetail";
            obilld.pkField = "ID";
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select obilld.* " +
                "From " + obilld.table + " obilld " +
                "Where obilld." + obilld.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByVN(String vn)
        {
            DataTable dt = new DataTable();
            String wherehn = "";

            String sql = "SELECT obilld.*  " +
                " " +
                "From " + obilld.table + " obilld " +
                "Where obilld.VN = '" + vn + "' and obilld."+ obilld.active+"='1'";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public String selectSumPriceByBilId(String bilid, String bilgrpid)
        {
            DataTable dt = new DataTable();
            String amt = "";

            String sql = "SELECT sum(obilld."+obilld.Price+") as amount " +
                " " +
                "From " + obilld.table + " obilld " +
                "Where obilld." + obilld.bill_id + "='" + bilid + "' and obilld."+obilld.bill_group_id+"='"+bilgrpid+"' and obilld." + obilld.active + "='1' and obilld.pcksid > 0 ";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                amt = dt.Rows[0]["amount"].ToString();
            }
            return amt;
        }
        public DataTable selectByPIDPkgsID(String pid, String pkgsid)
        {
            DataTable dt = new DataTable();
            String wherehn = "";

            String sql = "SELECT obilld.*  " +
                " " +
                "From " + obilld.table + " obilld " +
                "Left Join Visit ovs on obilld." + obilld.VN + "=ovs.VN " +
                "Where ovs.PID='" + pid + "' and obilld." + obilld.pcksid + "='" + pkgsid + "' and obilld." + obilld.active + "='1'";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByPIDPkgID(String pid, String pkgid)
        {
            DataTable dt = new DataTable();
            String wherehn = "";

            String sql = "SELECT obilld.*  " +
                " " +
                "From " + obilld.table + " obilld " +
                "Left Join Visit ovs on obilld."+ obilld.VN +"=ovs.VN " +
                "Where ovs.PID='" + pid + "' and obilld."+ obilld.item_id+"='" + pkgid + "' and obilld." + obilld.active + "='1'";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByPIDPkgID1(String pid, String pkgid)
        {
            DataTable dt = new DataTable();
            String wherehn = "";

            String sql = "SELECT obilld.*  " +
                " " +
                "From " + obilld.table + " obilld " +
                "Left Join Visit ovs on obilld." + obilld.VN + "=ovs.VN " +
                "Where ovs.PID='" + pid + "' and obilld." + obilld.item_id + "='" + pkgid + "' and obilld." + obilld.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        private void chkNull(OldBilldetail p)
        {
            long chk = 0;
            decimal chk1 = 0;


            p.Name = p.Name == null ? "" : p.Name;
            p.GroupType = p.GroupType == null ? "" : p.GroupType;
            p.Comment = p.Comment == null ? "" : p.Comment;
            p.status = p.status == null ? "0" : p.status;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.date_create = p.date_create == null ? "" : p.date_create;
            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.remark = p.remark == null ? "" : p.remark;
            p.sort1 = p.sort1 == null ? "" : p.sort1;

            p.bill_id = long.TryParse(p.bill_id, out chk) ? chk.ToString() : "0";
            p.Extra = long.TryParse(p.Extra, out chk) ? chk.ToString() : "0";
            p.VN = long.TryParse(p.VN, out chk) ? chk.ToString() : "0";
            p.item_id = long.TryParse(p.item_id, out chk) ? chk.ToString() : "0";
            p.pcksid = long.TryParse(p.pcksid, out chk) ? chk.ToString() : "0";
            p.closeday_id = long.TryParse(p.closeday_id, out chk) ? chk.ToString() : "0";
            p.bill_group_id = long.TryParse(p.bill_group_id, out chk) ? chk.ToString() : "0";

            p.Price = decimal.TryParse(p.Price, out chk1) ? chk1.ToString() : "0";            
            p.Total = decimal.TryParse(p.Total, out chk1) ? chk1.ToString() : "0";
            p.price1 = decimal.TryParse(p.price1, out chk1) ? chk1.ToString() : "0";
            p.qty = decimal.TryParse(p.qty, out chk1) ? chk1.ToString() : "0";

        }
        public String insert(OldBilldetail p, String userId)
        {
            String re = "";
            String sql = "";
            //p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            //lbReq.form_a_id = "form_a_id";
            //p.req_code = genReqDoc();
            sql = "Insert Into " + obilld.table + " Set " +
                " " + obilld.VN + " = '" + p.VN + "'" +
                "," + obilld.Name + "= '" + p.Name.Replace("'", "''") + "'" +
                "," + obilld.Extra + "= '" + p.Extra + "'" +
                "," + obilld.Price + "= '" + p.Price + "'" +
                "," + obilld.Total + "= '" + p.Total + "'" +
                "," + obilld.GroupType + "= '" + p.GroupType + "'" +
                "," + obilld.Comment + "= '" + p.Comment.Replace("'", "''") + "'" +
                "," + obilld.item_id + "= '" + p.item_id + "'" +
                "," + obilld.status + "= '" + p.status + "'" +
                "," + obilld.pcksid + "= '" + p.pcksid + "'" +
                "," + obilld.price1 + "= '" + p.price1 + "'" +
                "," + obilld.qty + "= '" + p.qty + "'" +
                "," + obilld.date_cancel + "= ''" +
                "," + obilld.date_create + "= now() " +
                "," + obilld.date_modi + "= ''" +
                "," + obilld.user_cancel + "= ''" +
                "," + obilld.user_create + "= '" + userId + "'" +
                "," + obilld.user_modi + "= ''" +
                "," + obilld.remark + "= '" + p.remark + "'" +
                "," + obilld.sort1 + "= '" + p.sort1 + "'" +
                "," + obilld.active + "= '1'" +
                "," + obilld.bill_id + "= '" + p.bill_id + "'" +
                "," + obilld.closeday_id + "= '0'" +
                "," + obilld.bill_group_id + "= '" + p.bill_group_id + "'" +
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
        public String update(OldBilldetail p, String userId)
        {
            String re = "";
            String sql = "";
            chkNull(p);

            sql = "Update " + obilld.table + " Set " +
                " " + obilld.Name + " = '" + p.Name.Replace("'", "''") + "'" +
                "," + obilld.Extra + " = '" + p.Extra + "'" +
                "," + obilld.Price + " = '" + p.Price + "'" +
                "," + obilld.Total + " = '" + p.Total + "'" +
                "," + obilld.GroupType + " = '" + p.GroupType + "'" +
                "," + obilld.Comment + " = '" + p.Comment.Replace("'", "''") + "'" +
                "," + obilld.item_id + " = '" + p.item_id + "'" +
                "," + obilld.status + " = '" + p.status + "'" +
                "," + obilld.pcksid + " = '" + p.pcksid + "'" +
                "," + obilld.price1 + "= '" + p.price1 + "'" +
                "," + obilld.qty + "= '" + p.qty + "'" +
                "," + obilld.date_modi + "= now() " +
                "," + obilld.user_modi + "= '" + userId + "'" +
                "," + obilld.remark + "= '" + p.remark + "'" +
                "," + obilld.bill_group_id + "= '" + p.bill_group_id + "'" +
                "Where " + obilld.pkField + "='" + p.ID + "'"
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
        public String insertBillDetail(OldBilldetail p, String userId)
        {
            String re = "";

            if (p.ID.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                //re = update(p, "");
            }
            return re;
        }
        public String updateCloseDayId(String cldid)
        {
            String re = "";
            String sql = "";
            //chkNull(p);

            sql = "Update " + obilld.table + " Set " +                                
                " " + obilld.closeday_id + "= '" + cldid + "'" +
                "Where " + obilld.closeday_id + "='0'";
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
        public String voidBillDetailByVN(String vn, String userId)
        {
            String re = "";
            String sql = "";
            //chkNull(p);

            sql = "Update " + obilld.table + " Set " +
                " " + obilld.active + " = '3'" +
                "," + obilld.date_modi + "= now() " +
                "," + obilld.user_modi + "= '" + userId + "'" +
                "Where " + obilld.VN + "='" + vn + "'";
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
        public String voidBillDetailBybildid(String bildid, String userId)
        {
            String re = "";
            String sql = "";
            //chkNull(p);

            sql = "Update " + obilld.table + " Set " +
                " " + obilld.active + " = '3'" +
                "," + obilld.date_modi + "= now() " +
                "," + obilld.user_modi + "= '" + userId + "'" +
                "Where " + obilld.ID + "='" + bildid + "'";
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
        public String delete(String vn)
        {
            String re = "";
            String sql = "";

            sql = "Delete From " + obilld.table + " Where " +
                " " + obilld.VN + " = '" + vn + "'"
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
        public String deletePk(String id)
        {
            String re = "";
            String sql = "";

            sql = "Delete From " + obilld.table + " Where " +
                " " + obilld.pkField + " = '" + id + "'"
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
