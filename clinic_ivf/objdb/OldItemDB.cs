using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class OldItemDB
    {
        public OldItem oitm;
        ConnectDB conn;
        public List<OldItem> loItm;

        public OldItemDB(ConnectDB c)
        {
            conn = c;

        }
        private void initConfig()
        {
            oitm = new OldItem();
            loItm = new List<OldItem>();
            oitm.id = "id";
            oitm.item_type_id = "item_type_id";
            oitm.item_type = "item_type";
            oitm.item_name = "item_name";
            oitm.total_price = "total_price";
            oitm.total_qty = "total_qty";
            oitm.unit_price = "unit_price";
            oitm.average_price = "average_price";
            oitm.DUID = "DUID";
            oitm.DUID_QTY = "DUID_QTY";
            oitm.active = "active";
            oitm.item_code = "item_code";
            oitm.item_common_name = "item_common_name";
            oitm.item_trade_name = "item_trade_name";

            oitm.date_create = "date_create";
            oitm.date_modi = "date_modi";
            oitm.date_cancel = "date_cancel";
            oitm.user_create = "user_create";
            oitm.user_modi = "user_modi";

            oitm.table = "b_item";
            oitm.pkField = "id";
        }
        private void chkNull(OldItem p)
        {
            long chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            //p.item_type_id = p.item_type_id == null ? "" : p.item_type_id;
            p.item_type = p.item_type == null ? "" : p.item_type;
            //p.average_price = p.average_price == null ? "" : p.average_price;
            p.item_trade_name = p.item_trade_name == null ? "" : p.item_trade_name;
            p.item_name = p.item_name == null ? "" : p.item_name;
            p.item_common_name = p.item_common_name == null ? "" : p.item_common_name;
            p.item_code = p.item_code == null ? "" : p.item_code;

            p.total_price = Decimal.TryParse(p.total_price, out chk1) ? chk.ToString() : "0";
            p.unit_price = Decimal.TryParse(p.unit_price, out chk1) ? chk.ToString() : "0";
            p.average_price = Decimal.TryParse(p.average_price, out chk1) ? chk.ToString() : "0";
            p.total_price = Decimal.TryParse(p.total_price, out chk1) ? chk.ToString() : "0";


            p.DUID = long.TryParse(p.DUID, out chk) ? chk.ToString() : "0";
            p.item_type_id = long.TryParse(p.item_type_id, out chk) ? chk.ToString() : "0";
            p.total_qty = long.TryParse(p.total_qty, out chk) ? chk.ToString() : "0";
            p.DUID_QTY = long.TryParse(p.DUID_QTY, out chk) ? chk.ToString() : "0";
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select oitm.* " +
                "From " + oitm.table + " oitm " +
                "Where oitm." + oitm.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select oitm.*  " +
                "From " + oitm.table + " oitm " +
                " " +
                "Where oitm." + oitm.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public void getloItm()
        {
            //lDept = new List<Position>();

            loItm.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                OldItem itm1 = new OldItem();
                itm1.id = row[oitm.id].ToString();
                itm1.item_type_id = row[oitm.item_type_id].ToString();
                itm1.item_type = row[oitm.item_type].ToString();
                itm1.item_name = row[oitm.item_name].ToString();
                itm1.total_price = row[oitm.total_price].ToString();
                itm1.total_qty = row[oitm.total_qty].ToString();
                itm1.unit_price = row[oitm.unit_price].ToString();
                itm1.average_price = row[oitm.average_price].ToString();
                itm1.DUID = row[oitm.DUID].ToString();
                itm1.DUID_QTY = row[oitm.DUID_QTY].ToString();
                itm1.active = row[oitm.active].ToString();
                itm1.item_code = row[oitm.item_code].ToString();
                itm1.date_create = row[oitm.date_create].ToString();
                itm1.date_modi = row[oitm.date_modi].ToString();
                itm1.date_cancel = row[oitm.date_cancel].ToString();
                itm1.user_create = row[oitm.user_create].ToString();
                itm1.user_modi = row[oitm.user_modi].ToString();
                //itm1.item_code = row[oitm.item_code].ToString();
                loItm.Add(itm1);
            }
        }
    }
}
