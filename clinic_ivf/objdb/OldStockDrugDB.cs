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
    }
}
