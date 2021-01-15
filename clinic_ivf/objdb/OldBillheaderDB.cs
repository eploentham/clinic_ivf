using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    /*
     * 620628       ห้าม update หรือลงข้อมูลในช่อง receiptno เพราะใช้ในการดึง closeday ให้ค่าเป็น null ถ้ามี ใบเสร็จ ค่อ update เลขที่ใบเสร็จ
     */ 
    public class OldBillheaderDB
    {
        public OldBillheader obillh;
        ConnectDB conn;

        public OldBillheaderDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            obillh = new OldBillheader();
            obillh.bill_id = "bill_id";
            obillh.VN = "VN";
            obillh.BillNo = "BillNo";
            obillh.PName = "PName";
            obillh.Date = "Date";
            obillh.Time = "Time";
            obillh.PID = "PID";
            obillh.PIDS = "PIDS";
            obillh.Include_Pkg_Price = "Include_Pkg_Price";
            obillh.Extra_Pkg_Price = "Extra_Pkg_Price";
            obillh.Total = "Total";
            obillh.Discount = "Discount";
            obillh.CreditCardType = "CreditCardType";
            obillh.CreditCardNumber = "CreditCardNumber";
            obillh.Status = "Status";
            obillh.CreditAgent = "CreditAgent";
            obillh.OName = "OName";
            obillh.BID = "BID";
            obillh.PaymentBy = "PaymentBy";
            obillh.CashID = "CashID";
            obillh.CreditCardID = "CreditCardID";
            obillh.SepCash = "SepCash";
            obillh.SepCredit = "SepCredit";
            obillh.ExtBillNo = "ExtBillNo";
            obillh.IntLock = "IntLock";
            obillh.receipt_cover_no = "receipt_cover_no";
            obillh.receipt_no = "receipt_no";
            
            obillh.active = "active";
            obillh.remark = "remark";
            obillh.date_cancel = "date_cancel";
            obillh.date_create = "date_create";
            obillh.date_modi = "date_modi";
            obillh.user_cancel = "user_cancel";
            obillh.user_create = "user_create";
            obillh.user_modi = "user_modi";
            obillh.cash = "cash";
            obillh.credit = "credit";
            obillh.closeday_id = "closeday_id";
            obillh.receipt1_no = "receipt1_no";
            obillh.include_lab = "include_lab";
            obillh.ext_lab = "ext_lab";
            obillh.include_special = "include_special";
            obillh.ext_special = "ext_special";
            obillh.include_package = "include_package";
            obillh.ext_package = "ext_package";
            obillh.total1 = "total1";
            obillh.agent_id = "agent_id";            

            obillh.table = "BillHeader";
            obillh.pkField = "VN";
        }
        public OldBillheader selectByPk1(String copId)
        {
            OldBillheader cop1 = new OldBillheader();
            DataTable dt = new DataTable();
            String sql = "select obillh.* " +
                "From " + obillh.table + " obillh " +
                "Where obillh." + obillh.bill_id + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setBill(dt);
            return cop1;
        }
        public OldBillheader selectByPk2(String copId)
        {
            OldBillheader cop1 = new OldBillheader();
            DataTable dt = new DataTable();
            String sql = "select obillh.* " +
                "From " + obillh.table + " obillh " +
                "Where obillh." + obillh.pkField + " ='" + copId + "' " +
                "and obillh.active = '1' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setBill(dt);
            return cop1;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select obillh.* " +
                "From " + obillh.table + " obillh " +
                "Where obillh." + obillh.pkField + " ='" + copId + "' " +
                "and obillh.active = '1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectCashCloseDay()
        {
            String cnt = "";
            DataTable dt = new DataTable();
            String sql = "select sum("+obillh.cash+ ") as cash,sum(" + obillh.credit + ") as credit  " +
                "From " + obillh.table + " obillh " +
                "Where obillh." + obillh.closeday_id + " ='0' and obillh." + obillh.active + " = '1' ";
            dt = conn.selectData(conn.conn, sql);
            //if (dt.Rows.Count >= 1)
            //{
            //    cnt = dt.Rows[0]["cnt"].ToString();
            //}
            return dt;
        }
        public DataTable selectByCloseDay()
        {
            String cnt = "";
            DataTable dt = new DataTable();
            String sql = "select obillh.*, Agent.AgentName " +
                "From " + obillh.table + " obillh " +
                "Left Join Agent on obillh.agent_id = Agent.AgentID " +
                "Where obillh." + obillh.closeday_id + " ='0' and obillh." + obillh.active + " = '1' and obillh."+obillh.receipt_no +" is not null " +
                "Order By obillh." + obillh.receipt_no;
            dt = conn.selectData(conn.conn, sql);
            //if (dt.Rows.Count >= 1)
            //{
            //    cnt = dt.Rows[0]["cnt"].ToString();
            //}
            return dt;
        }
        public DataTable selectByVN(String vn)
        {
            DataTable dt = new DataTable();
            String wherehn = "";

            String sql = "SELECT CONCAT(IFNULL(SurfixName.SurfixName,''),' ', ptt.PName,' ',ptt.PSurname) as patient_name, obillh.PIDS as hn, DATE_FORMAT(now(),'')  " +
                ",  " +
                "From " + obillh.table + " obillh " +
                "left join Patient ptt on ptt.PIDS = obillh.PIDS " +
                "left join SurfixName on SurfixName.SurfixID = ptt.SurfixID " +
                "Where JobPx.VN = '" + vn + "'  and obillh." + obillh.active + "='1'";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByDate(String startdate, String enddate)
        {
            DataTable dt = new DataTable();
            String wherehn = "";

            //String sql = "SELECT bill.bill_id, bill.Date, bill.VN, bill.Pname, bill.PIDS, bill.Total, ifnull(bill.status,'') as status,bill.CashID, bill.CreditCardID, ifnull(cash.CashName,'') as CashName,ifnull(credit.CreditCardName,'') as CreditName   " +
            //    ", bill.Include_Pkg_Price, bill.Extra_Pkg_Price, bill.Discount,bill.receipt_no, bill.agent_id, agen.AgentName, cash, credit,bill.receipt1_no " +
            //    "From " + obillh.table + " bill " +
            //    "Left Join CashAccount cash on bill.CashID = cash.CashID " +
            //    "Left Join CreditCardAccount credit on bill.CreditCardID = credit.CreditCardID " +
            //    "Inner Join Agent agen on bill.agent_id = agen.AgentID " +
            //    "Where bill.Date >= '"+startdate+ "' and bill.Date <= '" + enddate + "' and bill.active = '1' and length(bill.receipt_no) > 0 ";
            String sql = "SELECT bill.bill_id, bill.Date, bill.VN, bill.Pname, bill.PIDS, bill.Total, ifnull(bill.status,'') as status,bill.CashID, bill.CreditCardID, ifnull(cash.CashName,'') as CashName,ifnull(credit.CreditCardName,'') as CreditName   " +
                ", bill.Include_Pkg_Price, bill.Extra_Pkg_Price, bill.Discount,bill.receipt_no, bill.agent_id, agen.AgentName, cash, credit,bill.receipt1_no " +
                "From " + obillh.table + " bill " +
                "Left Join CashAccount cash on bill.CashID = cash.CashID " +
                "Left Join CreditCardAccount credit on bill.CreditCardID = credit.CreditCardID " +
                "Inner Join Agent agen on bill.agent_id = agen.AgentID " +
                "Where bill.Date >= '" + startdate + "' and bill.Date <= '" + enddate + "' and bill.active = '1'  ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public String selectReceiptNoByVN(String vn)
        {
            DataTable dt = new DataTable();
            String billno = "";

            String sql = "SELECT receipt_no " +
                "  " +
                "From " + obillh.table + " obillh " +
                //"left join Patient ptt on ptt.PIDS = obillh.PIDS " +
                //"left join SurfixName on SurfixName.SurfixID = ptt.SurfixID " +
                "Where obillh.VN = '" + vn + "'  and obillh." + obillh.active + "='1'";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                billno = dt.Rows[0]["receipt_no"].ToString();
            }
            return billno;
        }
        public String selectCloseDay()
        {
            String amt = "", sql="";
            sql = "Select sum(";


            return amt;
        }
        public String selectBillNoByVN(String vn)
        {
            DataTable dt = new DataTable();
            String billno = "";

            String sql = "SELECT BillNo " +
                "  " +
                "From " + obillh.table + " obillh " +
                //"left join Patient ptt on ptt.PIDS = obillh.PIDS " +
                //"left join SurfixName on SurfixName.SurfixID = ptt.SurfixID " +
                "Where obillh.VN = '" + vn + "'  and obillh." + obillh.active + "='1'";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                billno = dt.Rows[0]["BillNo"].ToString();
            }
            return billno;
        }
        public String selectBillNoExByVN(String vn)
        {
            DataTable dt = new DataTable();
            String billno = "";

            String sql = "SELECT ExtBillNo " +
                "  " +
                "From " + obillh.table + " obillh " +
                //"left join Patient ptt on ptt.PIDS = obillh.PIDS " +
                //"left join SurfixName on SurfixName.SurfixID = ptt.SurfixID " +
                "Where obillh.VN = '" + vn + "' and obillh." + obillh.active +"='1'";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                billno = dt.Rows[0]["ExtBillNo"].ToString();
            }
            return billno;
        }
        public String selectMaxBill()
        {
            String re = "";
            DataTable dt = new DataTable();
            String sql = "select max(obillh." + obillh.BillNo + ") as " + obillh.BillNo +
                "From " + obillh.table + " obillh ";                
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                re = dt.Rows[0][obillh.BillNo].ToString();
            }
            return re;
        }
        private void chkNull(OldBillheader p)
        {
            long chk = 0;
            decimal chk1 = 0;


            p.PIDS = p.PIDS == null ? "" : p.PIDS;
            p.BillNo = p.BillNo == null ? "" : p.BillNo;
            p.Date = p.Date == null ? "" : p.Date;
            p.Time = p.Time == null ? "" : p.Time;
            //p.CreditCardType = p.CreditCardType == null ? "0" : p.CreditCardType;
            p.CreditCardNumber = p.CreditCardNumber == null ? "" : p.CreditCardNumber;
            //p.Status = p.Status == null ? "" : p.Status;
            p.OName = p.OName == null ? "" : p.OName;
            p.PaymentBy = p.PaymentBy == null ? "" : p.PaymentBy;
            p.ExtBillNo = p.ExtBillNo == null ? "" : p.ExtBillNo;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.date_create = p.date_create == null ? "" : p.date_create;
            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.remark = p.remark == null ? "" : p.remark;

            p.CreditCardType = long.TryParse(p.CreditCardType, out chk) ? chk.ToString() : "0";
            p.CreditAgent = long.TryParse(p.CreditAgent, out chk) ? chk.ToString() : "0";
            p.VN = long.TryParse(p.VN, out chk) ? chk.ToString() : "0";
            p.Status = long.TryParse(p.Status, out chk) ? chk.ToString() : "0";
            p.BID = long.TryParse(p.BID, out chk) ? chk.ToString() : "0";
            p.CashID = long.TryParse(p.CashID, out chk) ? chk.ToString() : "0";
            p.CreditCardID = long.TryParse(p.CreditCardID, out chk) ? chk.ToString() : "0";
            p.PID = long.TryParse(p.PID, out chk) ? chk.ToString() : "0";
            p.IntLock = long.TryParse(p.IntLock, out chk) ? chk.ToString() : "0";
            p.closeday_id = long.TryParse(p.closeday_id, out chk) ? chk.ToString() : "0";
            p.agent_id = long.TryParse(p.agent_id, out chk) ? chk.ToString() : "0";

            p.Include_Pkg_Price = decimal.TryParse(p.Include_Pkg_Price, out chk1) ? chk1.ToString() : "0";
            p.Extra_Pkg_Price = decimal.TryParse(p.Extra_Pkg_Price, out chk1) ? chk1.ToString() : "0";
            p.Total = decimal.TryParse(p.Total, out chk1) ? chk1.ToString() : "0";
            p.Discount = decimal.TryParse(p.Discount, out chk1) ? chk1.ToString() : "0";
            p.SepCash = decimal.TryParse(p.SepCash, out chk1) ? chk1.ToString() : "0";
            p.SepCredit = decimal.TryParse(p.SepCredit, out chk1) ? chk1.ToString() : "0";
            p.cash = decimal.TryParse(p.cash, out chk1) ? chk1.ToString() : "0";
            p.credit = decimal.TryParse(p.credit, out chk1) ? chk1.ToString() : "0";
        }
        public String insert(OldBillheader p, String userId)
        {
            String re = "";
            String sql = "";
            //p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            //lbReq.form_a_id = "form_a_id";
            //p.req_code = genReqDoc();
            sql = "Insert Into " + obillh.table + " Set " +
                " " + obillh.VN + " = '" + p.VN + "'" +
                "," + obillh.BillNo + "= '" + p.BillNo + "'" +
                "," + obillh.PName + "= '" + p.PName + "'" +
                "," + obillh.Date + "= '" + p.Date.Replace("'", "''") + "'" +
                "," + obillh.Time + "= '" + p.Time.Replace("'", "''") + "'" +
                "," + obillh.PID + "= '" + p.PID + "'" +
                //"," + obillh.active + "= '" + p.active + "'" +
                //"," + obillh.remark + "= '" + p.remark + "'" +
                "," + obillh.PIDS + "= '" + p.PIDS + "'" +
                "," + obillh.Include_Pkg_Price + "= '" + p.Include_Pkg_Price + "'" +
                "," + obillh.Extra_Pkg_Price + "= '" + p.Extra_Pkg_Price + "'" +
                "," + obillh.Total + "= '" + p.Total + "'" +
                "," + obillh.Discount + "= '" + p.Discount + "'" +
                "," + obillh.CreditCardType + "= '" + p.CreditCardType + "'" +
                "," + obillh.CreditCardNumber + "= '" + p.CreditCardNumber + "'" +
                "," + obillh.date_create + "= now()" +
                "," + obillh.date_modi + "= ''" +
                "," + obillh.date_cancel + "= ''" +
                "," + obillh.user_create + "= '" + userId + "@" + conn._IPAddress + "'" +
                "," + obillh.user_modi + "= ''" +
                "," + obillh.user_cancel + "= ''" +
                "," + obillh.Status + "= '" + p.Status + "'" +
                "," + obillh.CreditAgent + "= '" + p.CreditAgent + "'" +
                "," + obillh.OName + "= '" + p.OName + "'" +
                "," + obillh.BID + " = '" + p.BID + "'" +
                "," + obillh.PaymentBy + " = '" + p.PaymentBy + "'" +
                "," + obillh.CashID + " = '" + p.CashID + "'" +
                "," + obillh.CreditCardID + " = '" + p.CreditCardID + "'" +
                "," + obillh.SepCash + " = '" + p.SepCash + "'" +
                "," + obillh.SepCredit + " = '" + p.SepCredit + "'" +
                "," + obillh.ExtBillNo + " = '" + p.ExtBillNo + "'" +
                "," + obillh.IntLock + " = '" + p.IntLock + "' " +
                "," + obillh.active + " = '1' " +
                "," + obillh.include_lab + " = '" + p.include_lab + "' " +
                "," + obillh.ext_lab + " = '" + p.ext_lab + "' " +
                "," + obillh.include_special + " = '" + p.include_special + "' " +
                "," + obillh.ext_special + " = '" + p.ext_special + "' " +
                "," + obillh.include_package + " = '" + p.include_package + "' " +
                "," + obillh.ext_package + " = '" + p.ext_package + "' " +
                "," + obillh.total1 + " = '" + p.total1 + "' " +
                "," + obillh.agent_id + " = '" + p.agent_id + "' " +
                "," + obillh.closeday_id + " = '0' " +
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
        public String update(OldBillheader p, String userId)
        {
            String re = "";
            String sql = "";
            chkNull(p);

            //sql = "Update " + proce.table + " Set " +
            //    " " + proce.proce_code + " = '" + p.proce_code + "'" +
            //    "," + proce.proce_name_t + " = '" + p.proce_name_t.Replace("'", "''") + "'" +
            //    "," + proce.status_lab + " = '" + p.status_lab + "'" +
            //    "," + proce.proce_name_e + " = '" + p.proce_name_e + "'" +
            //    "," + proce.remark + " = '" + p.remark.Replace("'", "''") + "'" +
            //    "," + proce.date_modi + " = now()" +
            //    "," + proce.user_modi + " = '" + userId + "'" +
            //    "Where " + proce.pkField + "='" + p.proce_id + "'"
            //    ;

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
        public String insertBillHeader(OldBillheader p, String userId)
        {
            String re = "";

            //if (p.VN.Equals(""))
            //{
                re = insert(p, userId);
            //}
            //else
            //{
            //    //re = update(p, "");
            //}

            return re;
        }
        public String delete(String vn)
        {
            String re = "";
            String sql = "";
            sql = "Delete From " + obillh.table + " Where " +
                " " + obillh.VN + " = '" + vn + "'";
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
        public String voidBillById(String bilid, String userId)
        {
            String re = "", sql = "";
            sql = "Update " + obillh.table + " set " +
                "" + obillh.active + "='3' " +
                "," + obillh.user_modi + "='" + userId + "' " +
                "," + obillh.date_modi + "= now() " +
                "Where " + obillh.bill_id + "='" + bilid + "' ";
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
        public String voidBillByVN(String vn, String userId)
        {
            String re = "", sql = "";
            sql = "Update " + obillh.table + " set " +
                "" + obillh.active + "='3' " +
                "," + obillh.user_modi + "='" + userId + "' " +
                "," + obillh.date_modi + "= now() " +
                "Where " + obillh.VN + "='" + vn + "' ";
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
        public String updateCloseDayId(String cldid)
        {
            String re = "", sql = "";

            sql = "Update " + obillh.table + " set " +
                "" + obillh.closeday_id + "='" + cldid + "' " +
                //"," + opkgs.Payment1 + "='" + pay + "' " +
                "Where " + obillh.closeday_id + "='0' ";
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
        public String updateBillNo(String vn, String billno)
        {
            String re = "", sql = "";

            sql = "Update " + obillh.table + " set " +
                "" + obillh.BillNo + "='" + billno + "' " +
                //"," + opkgs.Payment1 + "='" + pay + "' " +
                "Where " + obillh.VN + "='" + vn + "' ";
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
        public String updateBillNoByBillId(String billid, String billno)
        {
            String re = "", sql = "";

            sql = "Update " + obillh.table + " set " +
                "" + obillh.BillNo + "='" + billno + "' " +
                //"," + opkgs.Payment1 + "='" + pay + "' " +
                "Where " + obillh.bill_id + "='" + billid + "' ";
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
        public String updateReceiptNo(String vn, String billno, String cash, String credit, String creditnumber, String cashid, String creditid)
        {
            String re = "", sql = "";
            long chk = 0;
            cashid = long.TryParse(cashid, out chk) ? chk.ToString() : "0";
            creditid = long.TryParse(creditid, out chk) ? chk.ToString() : "0";

            sql = "Update " + obillh.table + " set " +
                "" + obillh.receipt_no + "='" + billno + "' " +
                "," + obillh.cash + "='" + cash + "' " +
                "," + obillh.credit + "='" + credit + "' " +
                "," + obillh.CreditCardNumber + "='" + creditnumber + "' " +
                "," + obillh.CashID + "='" + cashid + "' " +
                "," + obillh.CreditCardID + "='" + creditid + "' " +
                "Where " + obillh.VN + "='" + vn + "' ";
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
        public String updateReceiptNoByBillId(String billid, String billno, String cash, String credit, String creditnumber, String cashid
            , String creditid, String total, String discount, String paymentby)
        {
            String re = "", sql = "";
            long chk = 0;
            cashid = long.TryParse(cashid, out chk) ? chk.ToString() : "0";
            creditid = long.TryParse(creditid, out chk) ? chk.ToString() : "0";

            sql = "Update " + obillh.table + " set " +
                "" + obillh.receipt_no + "='" + billno + "' " +
                "," + obillh.cash + "='" + cash + "' " +
                "," + obillh.credit + "='" + credit + "' " +
                "," + obillh.CreditCardNumber + "='" + creditnumber + "' " +
                "," + obillh.CashID + "='" + cashid + "' " +
                "," + obillh.CreditCardID + "='" + creditid + "' " +
                "," + obillh.Total + "='" + total + "' " +
                "," + obillh.Discount + "='" + discount + "' " +
                "," + obillh.PaymentBy + "='" + paymentby.Replace("'","''") + "' " +
                "Where " + obillh.bill_id + "='" + billid + "' ";
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
        public String updateReceipt1NoByBillId(String billid, String billno)
        {
            String re = "", sql = "";
            long chk = 0;            

            sql = "Update " + obillh.table + " set " +
                "" + obillh.receipt1_no + "='" + billno + "' " +
                "Where " + obillh.bill_id + "='" + billid + "' ";
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
        public OldBillheader setBill(DataTable dt)
        {
            OldBillheader vsold1 = new OldBillheader();
            if (dt.Rows.Count > 0)
            {
                vsold1.bill_id = dt.Rows[0][obillh.bill_id].ToString();
                vsold1.VN = dt.Rows[0][obillh.VN].ToString();
                vsold1.BillNo = dt.Rows[0][obillh.BillNo].ToString();
                vsold1.PName = dt.Rows[0][obillh.PName].ToString();
                vsold1.Date = dt.Rows[0][obillh.Date].ToString();
                vsold1.Time = dt.Rows[0][obillh.Time].ToString();
                vsold1.PID = dt.Rows[0][obillh.PID].ToString();
                vsold1.PIDS = dt.Rows[0][obillh.PIDS].ToString();
                vsold1.Include_Pkg_Price = dt.Rows[0][obillh.Include_Pkg_Price].ToString();
                vsold1.Extra_Pkg_Price = dt.Rows[0][obillh.Extra_Pkg_Price].ToString();
                vsold1.Total = dt.Rows[0][obillh.Total].ToString();
                vsold1.Discount = dt.Rows[0][obillh.Discount].ToString();
                vsold1.CreditCardType = dt.Rows[0][obillh.CreditCardType].ToString();
                vsold1.CreditCardNumber = dt.Rows[0][obillh.CreditCardNumber].ToString();
                vsold1.Status = dt.Rows[0][obillh.Status].ToString();
                vsold1.CreditAgent = dt.Rows[0][obillh.CreditAgent].ToString();
                vsold1.OName = dt.Rows[0][obillh.OName].ToString();
                vsold1.BID = dt.Rows[0][obillh.BID].ToString();
                vsold1.PaymentBy = dt.Rows[0][obillh.PaymentBy].ToString();
                vsold1.CashID = dt.Rows[0][obillh.CashID].ToString();
                vsold1.CreditCardID = dt.Rows[0][obillh.CreditCardID].ToString();
                vsold1.SepCash = dt.Rows[0][obillh.SepCash].ToString();
                vsold1.SepCredit = dt.Rows[0][obillh.SepCredit].ToString();
                vsold1.ExtBillNo = dt.Rows[0][obillh.ExtBillNo].ToString();
                vsold1.IntLock = dt.Rows[0][obillh.IntLock].ToString();
                vsold1.receipt_cover_no = dt.Rows[0][obillh.receipt_cover_no].ToString();
                vsold1.receipt_no = dt.Rows[0][obillh.receipt_no].ToString();

                vsold1.active = dt.Rows[0][obillh.active].ToString();
                vsold1.remark = dt.Rows[0][obillh.remark].ToString();
                vsold1.date_cancel = dt.Rows[0][obillh.date_cancel].ToString();
                vsold1.date_create = dt.Rows[0][obillh.date_create].ToString();
                vsold1.date_modi = dt.Rows[0][obillh.date_modi].ToString();
                vsold1.user_cancel = dt.Rows[0][obillh.user_cancel].ToString();
                vsold1.user_create = dt.Rows[0][obillh.user_create].ToString();
                vsold1.user_modi = dt.Rows[0][obillh.user_modi].ToString();
                vsold1.cash = dt.Rows[0][obillh.cash].ToString();
                vsold1.credit = dt.Rows[0][obillh.credit].ToString();
                vsold1.closeday_id = dt.Rows[0][obillh.closeday_id].ToString();
                vsold1.receipt1_no = dt.Rows[0][obillh.receipt1_no].ToString();
                vsold1.include_lab = dt.Rows[0][obillh.include_lab].ToString();
                vsold1.ext_lab = dt.Rows[0][obillh.ext_lab].ToString();
                vsold1.include_special = dt.Rows[0][obillh.include_special].ToString();
                vsold1.ext_special = dt.Rows[0][obillh.ext_special].ToString();
                vsold1.include_package = dt.Rows[0][obillh.include_package].ToString();
                vsold1.ext_package = dt.Rows[0][obillh.ext_package].ToString();
                vsold1.total1 = dt.Rows[0][obillh.total1].ToString();
                vsold1.agent_id = dt.Rows[0][obillh.agent_id].ToString();
            }
            else
            {
                setBill(vsold1);
            }
            return vsold1;
        }
        private OldBillheader setBill(OldBillheader stf1)
        {
            stf1.bill_id = "";
            stf1.VN = "";
            stf1.BillNo = "";
            stf1.PName = "";
            stf1.Date = "";
            stf1.Time = "";
            stf1.PID = "";
            stf1.PIDS = "";
            stf1.Include_Pkg_Price = "";
            stf1.Extra_Pkg_Price = "";
            stf1.Total = "";
            stf1.Discount = "";
            stf1.CreditCardType = "";
            stf1.CreditCardNumber = "";
            stf1.Status = "";
            stf1.CreditAgent = "";
            stf1.OName = "";
            stf1.BID = "";
            stf1.PaymentBy = "";
            stf1.CashID = "";
            stf1.CreditCardID = "";
            stf1.SepCash = "";
            stf1.SepCredit = "";
            stf1.ExtBillNo = "";
            stf1.IntLock = "";
            stf1.receipt_cover_no = "";
            stf1.receipt_no = "";

            stf1.active = "";
            stf1.remark = "";
            stf1.date_cancel = "";
            stf1.date_create = "";
            stf1.date_modi = "";
            stf1.user_cancel = "";
            stf1.user_create = "";
            stf1.user_modi = "";
            stf1.cash = "";
            stf1.credit = "";
            stf1.closeday_id = "";
            stf1.receipt1_no = "";
            stf1.include_lab = "";
            stf1.ext_lab = "";
            stf1.include_special = "";
            stf1.ext_special = "";
            stf1.include_package = "";
            stf1.ext_package = "";
            stf1.total1 = "";
            stf1.agent_id = "";
            return stf1;
        }
    }
}
