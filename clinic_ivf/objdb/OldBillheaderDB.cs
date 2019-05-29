using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
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
            obillh.bill_id = "bill_id";

            obillh.table = "BillHeader";
            obillh.pkField = "VN";
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select obillh.* " +
                "From " + obillh.table + " obillh " +
                "Where obillh." + obillh.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
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
            //p.EUsage = p.EUsage == null ? "" : p.EUsage;
            //p.EUsage = p.EUsage == null ? "" : p.EUsage;

            p.CreditCardType = long.TryParse(p.CreditCardType, out chk) ? chk.ToString() : "0";
            p.CreditAgent = long.TryParse(p.CreditAgent, out chk) ? chk.ToString() : "0";
            p.VN = long.TryParse(p.VN, out chk) ? chk.ToString() : "0";
            p.Status = long.TryParse(p.Status, out chk) ? chk.ToString() : "0";
            p.BID = long.TryParse(p.BID, out chk) ? chk.ToString() : "0";
            p.CashID = long.TryParse(p.CashID, out chk) ? chk.ToString() : "0";
            p.CreditCardID = long.TryParse(p.CreditCardID, out chk) ? chk.ToString() : "0";
            p.PID = long.TryParse(p.PID, out chk) ? chk.ToString() : "0";
            p.IntLock = long.TryParse(p.IntLock, out chk) ? chk.ToString() : "0";

            p.Include_Pkg_Price = decimal.TryParse(p.Include_Pkg_Price, out chk1) ? chk.ToString() : "0";
            p.Extra_Pkg_Price = decimal.TryParse(p.Extra_Pkg_Price, out chk1) ? chk.ToString() : "0";
            p.Total = decimal.TryParse(p.Total, out chk1) ? chk.ToString() : "0";
            p.Discount = decimal.TryParse(p.Discount, out chk1) ? chk.ToString() : "0";
            p.SepCash = decimal.TryParse(p.SepCash, out chk1) ? chk.ToString() : "0";
            p.SepCredit = decimal.TryParse(p.SepCredit, out chk1) ? chk.ToString() : "0";
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
                "," + obillh.user_create + "= '" + userId + "'" +
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
                re = insert(p, "");
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
        public String updateReceiptNo(String vn, String billno)
        {
            String re = "", sql = "";

            sql = "Update " + obillh.table + " set " +
                "" + obillh.receipt_no + "='" + billno + "' " +
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
    }
}
