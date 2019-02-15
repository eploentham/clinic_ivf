using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class OldStockDrugDB
    {
        public OldStockDrug ostkD;
        ConnectDB conn;
        public OldStockDrugDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            ostkD = new OldStockDrug();
            ostkD.DUID= "DUID";
            ostkD.DUName= "DUName";
            ostkD.EUsage= "EUsage";
            ostkD.TUsage= "TUsage";
            ostkD.UnitType= "UnitType";
            ostkD.Alert= "Alert";
            ostkD.QTY= "QTY";
            ostkD.PendingQTY= "PendingQTY";
            ostkD.Price= "Price";

            ostkD.table = "StockDrug";
            ostkD.pkField = "DUID";
        }
        private void chkNull(OldStockDrug p)
        {
            int chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            //p.prefix_id = int.TryParse(p.prefix_id, out chk) ? chk.ToString() : "0";
            //p.posi_id = int.TryParse(p.posi_id, out chk) ? chk.ToString() : "0";
            //p.posi_id = int.TryParse(p.posi_id, out chk) ? chk.ToString() : "0";

            p.DUName = p.DUName == null ? "" : p.DUName;
            p.EUsage = p.EUsage == null ? "" : p.EUsage;
            p.TUsage = p.TUsage == null ? "" : p.TUsage;
            p.UnitType = p.UnitType == null ? "" : p.UnitType;            

            p.Alert = p.Alert == null ? "0" : p.Alert;
            p.QTY = p.QTY == null ? "0" : p.QTY;
            p.PendingQTY = p.PendingQTY == null ? "0" : p.PendingQTY;
            p.Price = p.Price.Equals("") ? "0" : p.Price;
            
            //p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select ostkD.*  " +
                "From " + ostkD.table + " ostkD " +
                "Where ostkD." + ostkD.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public OldStockDrug selectByPk1(String copId)
        {
            OldStockDrug stf1 = new OldStockDrug();
            DataTable dt = new DataTable();
            String sql = "select ostkD.*  " +
                "From " + ostkD.table + " ostkD " +
                "Where ostkD." + ostkD.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            stf1 = setStockDrug(dt);
            return stf1;
        }
        public DataTable selectBySockDrug1()
        {
            DataTable dt = new DataTable();
            String sql = "select ostkD." + ostkD.DUID + ",ostkD." + ostkD.DUName + ",ostkD." + ostkD.Price + " " +
                "From " + ostkD.table + " ostkD " +
                "Where active = '1' " +
                "Order By ostkD." + ostkD.DUName;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public OldStockDrug setStockDrug(DataTable dt)
        {
            OldStockDrug ostkd1 = new OldStockDrug();
            if (dt.Rows.Count > 0)
            {
                ostkd1.DUID = dt.Rows[0][ostkD.DUID].ToString();
                ostkd1.DUName = dt.Rows[0][ostkD.DUName].ToString();
                ostkd1.EUsage = dt.Rows[0][ostkD.EUsage].ToString();
                ostkd1.TUsage = dt.Rows[0][ostkD.TUsage].ToString();
                ostkd1.UnitType = dt.Rows[0][ostkD.UnitType].ToString();
                ostkd1.Alert = dt.Rows[0][ostkD.Alert].ToString();
                ostkd1.QTY = dt.Rows[0][ostkD.QTY].ToString();
                ostkd1.PendingQTY = dt.Rows[0][ostkD.PendingQTY].ToString();
                ostkd1.Price = dt.Rows[0][ostkD.Price].ToString();
                
            }
            else
            {
                setStockDrug1(ostkd1);
            }
            return ostkd1;
        }
        private OldStockDrug setStockDrug1(OldStockDrug stf1)
        {
            stf1.DUID = "";
            stf1.DUName = "";
            stf1.EUsage = "";
            stf1.TUsage = "";
            stf1.UnitType = "";
            stf1.Alert = "";
            stf1.QTY = "";
            stf1.PendingQTY = "";
            stf1.Price = "";
            
            return stf1;
        }
    }
}
