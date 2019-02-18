using clinic_ivf.object1;
using System;
using System.Collections.Generic;
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
        }
    }
}
