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
            obilld.pckid = "pckid";

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
        public OldBilldetail selectByPk1(String copId)
        {
            DataTable dt = new DataTable();
            OldBilldetail obilld1 = new OldBilldetail();
            String sql = "select obilld.* " +
                "From " + obilld.table + " obilld " +
                "Where obilld." + obilld.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            obilld1 = setBillD(dt);
            return obilld1;
        }
        public DataTable selectByBillId(String bilid)
        {
            DataTable dt = new DataTable();
            String wherehn = "";

            String sql = "SELECT obilld.*  " +
                " " +
                "From " + obilld.table + " obilld " +
                "Where obilld.bill_id = '" + bilid + "' and obilld." + obilld.active + "='1'";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByBillId1(String bilid)
        {
            DataTable dt = new DataTable();
            String wherehn = "";

            String sql = "SELECT obilld.*  " +
                " " +
                "From " + obilld.table + " obilld " +
                "Where obilld.bill_id = '" + bilid + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByDate(String datestart, String dateend)
        {
            DataTable dt = new DataTable();
            String wherehn = "";

            String sql = "SELECT obilld.id, bill.bill_id, bill.receipt_no, bill.BillNo, bill.receipt_cover_no  " +
                ", obilld.status,obilld.bill_group_id, billg.Name , obilld.item_id, obilld.bill_id, obilld.price1, obilld.Price, obilld.qty" +
                ", obilld.pcksid, pkg.PackageName, lab.LName, labg.LGName, drug.DUName, spec.SName " +
                "From " + obilld.table + " obilld " +
                "inner join BillHeader bill on bill.bill_id = obilld.bill_id " +
                "inner join BillGroup billg on obilld.bill_group_id = billg.ID " +
                //"Left Join PackageSold pkgs on obilld.pcksid = pkgs.PCKSID " +
                "Left join PackageHeader pkg on obilld.item_id = pkg.PCKID and obilld.status = 'package' " +
                "Left join LabItem lab on obilld.item_id = lab.LID and obilld.status = 'lab' " +
                "Left Join LabItemGroup labg on lab.LGID = labg.LGID " +
                "Left Join StockDrug drug on obilld.item_id = drug.DUID and obilld.status = 'drug' " +
                "Left Join SpecialItem spec on obilld.item_id = spec.SID and obilld.status = 'special' " +
                "Where bill.Date >= '" + datestart + "' and bill.Date <= '" + dateend + "' and obilld." + obilld.active + "= '1' and bill.active = '1' " +
                "Order By bill.bill_id, obilld.ID ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByHn(String hn)
        {
            DataTable dt = new DataTable();
            String wherehn = "";

            String sql = "SELECT pkg.PCKID, obilld.item_id, obilld.bill_id, obilld.price1, obilld.Price, obilld.qty" +
                ", obilld.pcksid, pkg.PackageName, lab.LName, labg.LGName, drug.DUName, spec.SName, obilld.Extra, bill.Date, bill.Time " +
                "From " + obilld.table + " obilld " +
                "inner join BillHeader bill on bill.bill_id = obilld.bill_id " +
                "inner join BillGroup billg on obilld.bill_group_id = billg.ID " +
                //"Left Join PackageSold pkgs on obilld.pcksid = pkgs.PCKSID " +
                "Left join PackageHeader pkg on obilld.item_id = pkg.PCKID and obilld.status = 'package' " +
                "Left join LabItem lab on obilld.item_id = lab.LID and obilld.status = 'lab' " +
                "Left Join LabItemGroup labg on lab.LGID = labg.LGID " +
                "Left Join StockDrug drug on obilld.item_id = drug.DUID and obilld.status = 'drug' " +
                "Left Join SpecialItem spec on obilld.item_id = spec.SID and obilld.status = 'special' " +
                "Where bill.PIDS >= '" + hn + "' and obilld." + obilld.active + "= '1' and bill.active = '1' " +
                "Order By bill.bill_id, obilld.ID ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectItemByHn(String hn)
        {
            DataTable dt = new DataTable();
            String wherehn = "";

            String sql = "SELECT pkg.PCKID, obilld.item_id, obilld.bill_id, obilld.price1, obilld.Price, obilld.qty" +
                ", obilld.pcksid, pkg.PackageName, lab.LName, labg.LGName, drug.DUName, spec.SName, obilld.Extra, bill.Date, bill.Time " +
                "From " + obilld.table + " obilld " +
                "inner join BillHeader bill on bill.bill_id = obilld.bill_id " +
                "inner join BillGroup billg on obilld.bill_group_id = billg.ID " +
                "Left join PackageHeader pkg on obilld.item_id = pkg.PCKID and obilld.status = 'package' " +
                "Left join LabItem lab on obilld.item_id = lab.LID and obilld.status = 'lab' " +
                "Left Join LabItemGroup labg on lab.LGID = labg.LGID " +
                "Left Join StockDrug drug on obilld.item_id = drug.DUID and obilld.status = 'drug' " +
                "Left Join SpecialItem spec on obilld.item_id = spec.SID and obilld.status = 'special' " +
                "Where bill.PIDS >= '" + hn + "' and obilld." + obilld.active + "= '1' and bill.active = '1' " +
                "Order By bill.bill_id, obilld.ID ";
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
        public String selectSumPriceByBilIdItmId(String bilid, String itmid)
        {
            DataTable dt = new DataTable();
            String amt = "";

            String sql = "SELECT sum(obilld." + obilld.Price + ") as amount " +
                " " +
                "From " + obilld.table + " obilld " +
                "Where obilld." + obilld.bill_id + "='" + bilid + "' and obilld." + obilld.item_id + " in (" + itmid + ") and obilld." + obilld.active + "='1'  ";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                amt = dt.Rows[0]["amount"].ToString();
            }
            return amt;
        }
        public String selectSumPriceExtraByBilIdItmId(String bilid, String itmid)
        {
            DataTable dt = new DataTable();
            String amt = "";

            String sql = "SELECT sum(obilld." + obilld.Price + ") as amount " +
                " " +
                "From " + obilld.table + " obilld " +
                "Where obilld." + obilld.bill_id + "='" + bilid + "' and obilld." + obilld.item_id + " in (" + itmid + ") and obilld." + obilld.active + "='1'  and obilld.Extra = '1' ";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                amt = dt.Rows[0]["amount"].ToString();
            }
            return amt;
        }
        public String selectSumPriceByBilIdBillGroup(String bilid, String billgrpid)
        {
            DataTable dt = new DataTable();
            String amt = "";

            String sql = "SELECT sum(obilld." + obilld.Price + ") as amount " +
                " " +
                "From " + obilld.table + " obilld " +
                "Where obilld." + obilld.bill_id + "='" + bilid + "' and obilld.bill_group_id = '"+ billgrpid + "' and obilld." + obilld.active + "='1'  ";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                amt = dt.Rows[0]["amount"].ToString();
            }
            return amt;
        }
        public String selectSumPriceByBilId(String bilid)
        {
            DataTable dt = new DataTable();
            String amt = "";

            String sql = "SELECT sum(obilld." + obilld.Price + ") as amount " +
                " " +
                "From " + obilld.table + " obilld " +
                "Where obilld." + obilld.bill_id + "='" + bilid + "' and  obilld." + obilld.active + "='1'  ";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                amt = dt.Rows[0]["amount"].ToString();
            }
            return amt;
        }
        public String selectSumPriceIncludeByBilId(String bilid)
        {
            DataTable dt = new DataTable();
            String amt = "";

            String sql = "SELECT sum(obilld." + obilld.Price + ") as amount " +
                " " +
                "From " + obilld.table + " obilld " +
                "Where obilld." + obilld.bill_id + "='" + bilid + "' and  obilld." + obilld.active + "='1' and obilld.Extra = '0' and obilld.status <> 'package' ";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                amt = dt.Rows[0]["amount"].ToString();
            }
            return amt;
        }
        public String selectSumPriceExtraByBilId(String bilid)
        {
            DataTable dt = new DataTable();
            String amt = "";

            String sql = "SELECT sum(obilld." + obilld.Price + ") as amount " +
                " " +
                "From " + obilld.table + " obilld " +
                "Where obilld." + obilld.bill_id + "='" + bilid + "' and  obilld." + obilld.active + "='1' and obilld.Extra = '1' and obilld.status <> 'package' and obilld.Price >0 ";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                amt = dt.Rows[0]["amount"].ToString();
            }
            return amt;
        }
        public String selectSumPriceByLabAll(String bilid)
        {
            DataTable dt = new DataTable();
            String amt = "";

            String sql = "SELECT sum(obilld." + obilld.Price + ") as amount " +
                " " +
                "From " + obilld.table + " obilld " +
                "Where obilld." + obilld.bill_id + "='" + bilid + "' and obilld." + obilld.bill_group_id + " in ('2650000003','2650000004') and obilld." + obilld.active + "='1'  ";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                amt = dt.Rows[0]["amount"].ToString();
            }
            return amt;
        }
        public String selectSumPriceExtraByLabAll(String bilid)
        {
            DataTable dt = new DataTable();
            String amt = "";

            String sql = "SELECT sum(obilld." + obilld.Price + ") as amount " +
                " " +
                "From " + obilld.table + " obilld " +
                "Where obilld." + obilld.bill_id + "='" + bilid + "' and obilld." + obilld.bill_group_id + " in ('2650000003','2650000004') and obilld." + obilld.active + "='1' and obilld.Extra = '1' ";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                amt = dt.Rows[0]["amount"].ToString();
            }
            return amt;
        }
        public String selectSumPriceByLabGroup(String bilid, String labgroup)
        {
            DataTable dt = new DataTable();
            String amt = "";

            String sql = "SELECT sum(obilld." + obilld.Price + ") as amount " +
                " " +
                "From " + obilld.table + " obilld " +
                "inner join LabItem lab on obilld." + obilld.item_id+" = lab.LID " +
                "inner join LabItemGroup labg on lab.LGID = labg.LGID " +
                "Where obilld." + obilld.bill_id + "='" + bilid + "' and obilld." + obilld.status + " = 'lab' and obilld." + obilld.active + "='1' and labg.LGID = '"+labgroup+"'";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                amt = dt.Rows[0]["amount"].ToString();
            }
            return amt;
        }
        public String selectSumPriceExtraByLabGroup(String bilid, String labgroup)
        {
            DataTable dt = new DataTable();
            String amt = "";

            String sql = "SELECT sum(obilld." + obilld.Price + ") as amount " +
                " " +
                "From " + obilld.table + " obilld " +
                "inner join LabItem lab on obilld." + obilld.item_id + " = lab.LID " +
                "inner join LabItemGroup labg on lab.LGID = labg.LGID " +
                "Where obilld." + obilld.bill_id + "='" + bilid + "' and obilld." + obilld.status + " = 'lab' and obilld." + obilld.active + "='1' and labg.LGID = '" + labgroup + "' and obilld.Extra = '1' ";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                amt = dt.Rows[0]["amount"].ToString();
            }
            return amt;
        }
        public String selectSumPriceByBilIdItmId(String bilid, String bilgrpid, String itmId)
        {
            DataTable dt = new DataTable();
            String amt = "";

            String sql = "SELECT sum(obilld." + obilld.Price + ") as amount " +
                " " +
                "From " + obilld.table + " obilld " +
                "Where obilld." + obilld.bill_id + "='" + bilid + "' and obilld." + obilld.bill_group_id + "='" + bilgrpid + "' and obilld." + obilld.active + "='1' and obilld.pcksid > 0 ";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                amt = dt.Rows[0]["amount"].ToString();
            }
            return amt;
        }
        public String selectSumPriceByBilId1(String bilid, String bilgrpid)
        {
            DataTable dt = new DataTable();
            String amt = "";

            String sql = "SELECT sum(obilld." + obilld.Price + ") as amount " +
                " " +
                "From " + obilld.table + " obilld " +
                "Where obilld." + obilld.bill_id + "='" + bilid + "' and obilld." + obilld.bill_group_id + "='" + bilgrpid + "' and obilld." + obilld.active + "='1'  ";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                amt = dt.Rows[0]["amount"].ToString();
            }
            return amt;
        }
        public String selectSumPriceIncludeByBilId1(String bilid, String bilgrpid)
        {
            DataTable dt = new DataTable();
            String amt = "";

            String sql = "SELECT sum(obilld." + obilld.Price + ") as amount " +
                " " +
                "From " + obilld.table + " obilld " +
                "Where obilld." + obilld.bill_id + "='" + bilid + "' and obilld." + obilld.bill_group_id + "='" + bilgrpid + "' and obilld." + obilld.active + "='1' and obilld.Extra = '0'  ";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                amt = dt.Rows[0]["amount"].ToString();
            }
            return amt;
        }
        public String selectSumPriceExtraByBilId1(String bilid, String bilgrpid)
        {
            DataTable dt = new DataTable();
            String amt = "";

            String sql = "SELECT sum(obilld." + obilld.Price + ") as amount " +
                " " +
                "From " + obilld.table + " obilld " +
                "Where obilld." + obilld.bill_id + "='" + bilid + "' and obilld." + obilld.bill_group_id + "='" + bilgrpid + "' and obilld." + obilld.active + "='1' and obilld.Extra = '1'  ";
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
            p.pckid = long.TryParse(p.pckid, out chk) ? chk.ToString() : "0";

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
            long chk = 0;

            chkNull(p);
            if (userId == null) userId = "";
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
                "," + obilld.user_create + "= '" + userId + "@" + conn._IPAddress + "'" +
                "," + obilld.user_modi + "= ''" +
                "," + obilld.remark + "= '" + p.remark + "'" +
                "," + obilld.sort1 + "= '" + p.sort1 + "'" +
                "," + obilld.active + "= '1'" +
                "," + obilld.bill_id + "= '" + p.bill_id + "'" +
                "," + obilld.closeday_id + "= '0'" +
                "," + obilld.bill_group_id + "= '" + p.bill_group_id + "'" +
                "," + obilld.pckid + "= '" + p.pckid + "'" +
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
                re = insert(p, userId);
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
        public String updatePaymentPeriod(String vn, String pkgsid, String amt)
        {
            DataTable dt = new DataTable();
            String sql = "", re = "";
            //dt = selectByVN(vn);
            sql = "Update " + obilld.table + " Set " +
                " " + obilld.Price + "= '" + amt + "'" +
                "," + obilld.price1 + "= '" + amt + "'" +
                "," + obilld.Total + "= '" + amt + "'" +
                "Where " + obilld.VN + "='" + vn + "' and " + obilld.pcksid + " = '" + pkgsid + "' ";
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
        public String updatePaymentPeriod(String vn, String pkgsid, String amt, String name)
        {
            DataTable dt = new DataTable();
            String sql = "", re="";
            //dt = selectByVN(vn);
            sql = "Update " + obilld.table + " Set " +
                " " + obilld.Price + "= '" + amt + "'" +
                "," + obilld.price1 + "= '" + amt + "'" +
                "," + obilld.Total + "= '" + amt + "'" +
                "," + obilld.Name + "= '" + name + "'" +
                "Where " + obilld.VN + "='" + vn + "' and "+obilld.pcksid +" = '"+pkgsid+"' ";
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
        public OldBilldetail setBillD(DataTable dt)
        {
            OldBilldetail obilld1 = new OldBilldetail();
            if (dt.Rows.Count > 0)
            {
                obilld1 = new OldBilldetail();
                obilld1.ID = dt.Rows[0][obilld.ID].ToString();
                obilld1.VN = dt.Rows[0][obilld.VN].ToString();
                obilld1.Name = dt.Rows[0][obilld.Name].ToString();
                obilld1.Extra = dt.Rows[0][obilld.Extra].ToString();
                obilld1.Price = dt.Rows[0][obilld.Price].ToString();
                obilld1.Total = dt.Rows[0][obilld.Total].ToString();
                obilld1.GroupType = dt.Rows[0][obilld.GroupType].ToString();
                obilld1.Comment = dt.Rows[0][obilld.Comment].ToString();
                obilld1.item_id = dt.Rows[0][obilld.item_id].ToString();
                obilld1.status = dt.Rows[0][obilld.status].ToString();
                obilld1.pcksid = dt.Rows[0][obilld.pcksid].ToString();
                obilld1.price1 = dt.Rows[0][obilld.price1].ToString();
                obilld1.qty = dt.Rows[0][obilld.qty].ToString();
                obilld1.bill_id = dt.Rows[0][obilld.bill_id].ToString();
                obilld1.active = dt.Rows[0][obilld.active].ToString();
                obilld1.remark = dt.Rows[0][obilld.remark].ToString();
                obilld1.sort1 = dt.Rows[0][obilld.sort1].ToString();
                obilld1.date_cancel = dt.Rows[0][obilld.date_cancel].ToString();
                obilld1.date_create = dt.Rows[0][obilld.date_create].ToString();
                obilld1.date_modi = dt.Rows[0][obilld.date_modi].ToString();
                obilld1.user_cancel = dt.Rows[0][obilld.user_cancel].ToString();
                obilld1.user_create = dt.Rows[0][obilld.user_create].ToString();
                obilld1.user_modi = dt.Rows[0][obilld.user_modi].ToString();
                obilld1.closeday_id = dt.Rows[0][obilld.closeday_id].ToString();
                obilld1.bill_group_id = dt.Rows[0][obilld.bill_group_id].ToString();
                obilld1.pckid = dt.Rows[0][obilld.pckid].ToString();
            }
            else
            {
                setBillD(obilld1);
            }
            return obilld1;
        }
        private OldBilldetail setBillD(OldBilldetail obilld1)
        {
            obilld1.ID = "";
            obilld1.VN = "";
            obilld1.Name = "";
            obilld1.Extra = "";
            obilld1.Price = "";
            obilld1.Total = "";
            obilld1.GroupType = "";
            obilld1.Comment = "";
            obilld1.item_id = "";
            obilld1.status = "";
            obilld1.pcksid = "";
            obilld1.price1 = "";
            obilld1.qty = "";
            obilld1.bill_id = "";
            obilld1.active = "";
            obilld1.remark = "";
            obilld1.sort1 = "";
            obilld1.date_cancel = "";
            obilld1.date_create = "";
            obilld1.date_modi = "";
            obilld1.user_cancel = "";
            obilld1.user_create = "";
            obilld1.user_modi = "";
            obilld1.closeday_id = "";
            obilld1.bill_group_id = "";
            obilld1.pckid = "";
            return obilld1;
        }
    }
}
