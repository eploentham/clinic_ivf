using C1.Win.C1Input;
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
            ostkD.active = "active";
            ostkD.drug_caution = "drug_caution";
            ostkD.drug_description = "drug_description";
            ostkD.instruction_id = "instruction_id";
            ostkD.frequency_id = "frequency_id";
            ostkD.drug_caution_e = "drug_caution_e";
            ostkD.drug_frequency_e = "drug_frequency_e";
            ostkD.item_sub_group_id = "item_sub_group_id";
            ostkD.on_hand = "on_hand";
            ostkD.order_point = "order_point";
            ostkD.order_amount = "order_amount";
            ostkD.on_hand_sub_1 = "on_hand_sub_1";
            ostkD.order_point_sub_1 = "order_point_sub_1";
            ostkD.order_amount_sub_1 = "order_amount_sub_1";
            ostkD.on_hand_sub_2 = "on_hand_sub_2";
            ostkD.order_point_sub_2 = "order_point_sub_2";
            ostkD.order_amount_sub_2 = "order_amount_sub_2";
            ostkD.on_hand_sub_3 = "on_hand_sub_3";
            ostkD.order_point_sub_3 = "order_point_sub_3";
            ostkD.order_amount_sub_3 = "order_amount_sub_3";

            ostkD.table = "StockDrug";
            ostkD.pkField = "DUID";
        }
        private void chkNull(OldStockDrug p)
        {
            long chk = 0;
            Decimal chk1 = 0;

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
            p.drug_caution = p.drug_caution == null ? "" : p.drug_caution;
            p.drug_description = p.drug_description == null ? "" : p.drug_description;
            p.drug_caution_e = p.drug_caution_e == null ? "" : p.drug_caution_e;
            p.drug_frequency_e = p.drug_frequency_e == null ? "" : p.drug_frequency_e;

            //p.Alert = p.Alert == null ? "0" : p.Alert;
            //p.QTY = p.QTY == null ? "0" : p.QTY;
            //p.PendingQTY = p.PendingQTY == null ? "0" : p.PendingQTY;
            //p.Price = p.Price.Equals("") ? "0" : p.Price;

            p.Alert = long.TryParse(p.Alert, out chk) ? chk.ToString() : "0";
            p.QTY = long.TryParse(p.QTY, out chk) ? chk.ToString() : "0";
            p.PendingQTY = long.TryParse(p.PendingQTY, out chk) ? chk.ToString() : "0";
            p.instruction_id = long.TryParse(p.instruction_id, out chk) ? chk.ToString() : "0";
            p.frequency_id = long.TryParse(p.frequency_id, out chk) ? chk.ToString() : "0";
            p.item_sub_group_id = long.TryParse(p.item_sub_group_id, out chk) ? chk.ToString() : "0";

            p.Price = Decimal.TryParse(p.Price, out chk1) ? chk1.ToString() : "0";
            p.on_hand = Decimal.TryParse(p.on_hand, out chk1) ? chk1.ToString() : "0";
            p.order_point = Decimal.TryParse(p.order_point, out chk1) ? chk1.ToString() : "0";
            p.order_amount = Decimal.TryParse(p.order_amount, out chk1) ? chk1.ToString() : "0";
            p.on_hand_sub_1 = Decimal.TryParse(p.on_hand_sub_1, out chk1) ? chk1.ToString() : "0";
            p.order_point_sub_1 = Decimal.TryParse(p.order_point_sub_1, out chk1) ? chk1.ToString() : "0";
            p.order_amount_sub_1 = Decimal.TryParse(p.order_amount_sub_1, out chk1) ? chk1.ToString() : "0";
            p.on_hand_sub_2 = Decimal.TryParse(p.on_hand_sub_2, out chk1) ? chk1.ToString() : "0";
            p.order_point_sub_2 = Decimal.TryParse(p.order_point_sub_2, out chk1) ? chk1.ToString() : "0";
            p.order_amount_sub_2 = Decimal.TryParse(p.order_amount_sub_2, out chk1) ? chk1.ToString() : "0";
            p.on_hand_sub_3 = Decimal.TryParse(p.on_hand_sub_3, out chk1) ? chk1.ToString() : "0";
            p.order_point_sub_3 = Decimal.TryParse(p.order_point_sub_3, out chk1) ? chk1.ToString() : "0";
            p.order_amount_sub_3 = Decimal.TryParse(p.order_amount_sub_3, out chk1) ? chk1.ToString() : "0";

            //p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
        }
        public String insert(OldStockDrug p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            //lbReq.form_a_id = "form_a_id";
            //p.req_code = genReqDoc();
            sql = "Insert Into " + ostkD.table + " Set " +
                " " + ostkD.DUName + " = '" + p.DUName.Replace("'", "''") + "'" +
                "," + ostkD.EUsage + "= '" + p.EUsage.Replace("'", "''") + "'" +
                "," + ostkD.TUsage + "= '" + p.TUsage.Replace("'", "''") + "'" +
                "," + ostkD.UnitType + "= '" + p.UnitType.Replace("'", "''") + "'" +
                "," + ostkD.Alert + "= '" + p.Alert.Replace("'", "''") + "'" +
                "," + ostkD.QTY + "= '" + p.QTY + "'" +                
                "," + ostkD.PendingQTY + "= '" + p.PendingQTY + "'" +
                "," + ostkD.Price + "= '" + p.Price + "'" +
                "," + ostkD.drug_caution + "= '" + p.drug_caution + "'" +
                "," + ostkD.drug_description + "= '" + p.drug_description + "'" +
                "," + ostkD.instruction_id + "= '" + p.instruction_id + "'" +
                "," + ostkD.frequency_id + "= '" + p.frequency_id + "'" +
                "," + ostkD.drug_caution_e + "= '" + p.drug_caution_e + "'" +
                "," + ostkD.drug_frequency_e + "= '" + p.drug_frequency_e + "'" +
                "," + ostkD.item_sub_group_id + "= '" + p.item_sub_group_id + "'" +
                "," + ostkD.on_hand + "= '" + p.on_hand + "'" +
                "," + ostkD.order_point + "= '" + p.order_point + "'" +
                "," + ostkD.order_amount + "= '" + p.order_amount + "'" +
                "," + ostkD.on_hand_sub_1 + "= '" + p.on_hand_sub_1 + "'" +
                "," + ostkD.order_point_sub_1 + "= '" + p.order_point_sub_1 + "'" +
                "," + ostkD.order_amount_sub_1 + "= '" + p.order_amount_sub_1 + "'" +
                "," + ostkD.on_hand_sub_2 + "= '" + p.on_hand_sub_2 + "'" +
                "," + ostkD.order_point_sub_2 + "= '" + p.order_point_sub_2 + "'" +
                "," + ostkD.order_amount_sub_2 + "= '" + p.order_amount_sub_2 + "'" +
                "," + ostkD.on_hand_sub_3 + "= '" + p.on_hand_sub_3 + "'" +
                "," + ostkD.order_point_sub_3 + "= '" + p.order_point_sub_3 + "'" +
                "," + ostkD.order_amount_sub_3 + "= '" + p.order_amount_sub_3 + "'" +

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
        public String update(OldStockDrug p, String userId)
        {
            String re = "";
            String sql = "";
            chkNull(p);

            sql = "Update " + ostkD.table + " Set " +
                " " + ostkD.DUName + " = '" + p.DUName.Replace("'", "''") + "'" +
                "," + ostkD.EUsage + "= '" + p.EUsage.Replace("'", "''") + "'" +
                "," + ostkD.TUsage + "= '" + p.TUsage.Replace("'", "''") + "'" +
                "," + ostkD.UnitType + "= '" + p.UnitType.Replace("'", "''") + "'" +
                "," + ostkD.Alert + "= '" + p.Alert.Replace("'", "''") + "'" +
                "," + ostkD.QTY + "= '" + p.QTY + "'" +
                "," + ostkD.PendingQTY + "= '" + p.PendingQTY + "'" +
                //"," + ostkD.Price + "= '" + p.Price + "'" +
                "," + ostkD.drug_caution + "= '" + p.drug_caution + "'" +
                "," + ostkD.drug_description + "= '" + p.drug_description + "'" +
                "," + ostkD.instruction_id + "= '" + p.instruction_id + "'" +
                "," + ostkD.frequency_id + "= '" + p.frequency_id + "'" +
                "," + ostkD.drug_caution_e + "= '" + p.drug_caution_e + "'" +
                "," + ostkD.drug_frequency_e + "= '" + p.drug_frequency_e + "'" +
                "," + ostkD.item_sub_group_id + "= '" + p.item_sub_group_id + "'" +
                //"," + ostkD.drug_caution_e + "= '" + p.drug_caution_e + "'" +
                "Where " +ostkD.pkField+"='"+p.DUID+"'";

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
        public String insertStockDrug(OldStockDrug p, String userId)
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
        public DataTable selectAll2(String column)
        {
            DataTable dt = new DataTable();
            String sql = "select ostkD.DUID,ostkD.DUName,ostkD.UnitType,ostkD.Price,ostkD.on_hand"+ column + ",ostkD.order_point" + column + ",ostkD.order_amount" + column + "  " +
                "From " + ostkD.table + " ostkD " +
                "Where ostkD." + ostkD.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select ostkD.*  " +
                "From " + ostkD.table + " ostkD " +
                "Where ostkD." + ostkD.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectAll1()
        {
            DataTable dt = new DataTable();
            String sql = "select ostkD."+ ostkD.DUID+","+ ostkD.DUName+","+ ostkD.Price+" " +
                "From " + ostkD.table + " ostkD " +
                "Where ostkD." + ostkD.active + " ='1' " +
                "Order By "+ostkD.DUName;
            dt = conn.selectData(conn.conn, sql);
            return dt;
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
            String sql = "select ostkD." + ostkD.DUID + ",ostkD." + ostkD.DUName + ",ostkD." + ostkD.Price + ", '' as qty, ostkD.EUsage, ostkD.TUsage " +
                "From " + ostkD.table + " ostkD " +
                "Where active = '1' " +
                "Order By ostkD." + ostkD.DUName;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectDistinctByUnit()
        {
            DataTable dt = new DataTable();
            String sql = "select distinct ostkD." + ostkD.UnitType + " " +
                "From " + ostkD.table + " ostkD " +
                "Where ostkD." + ostkD.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public C1ComboBox setCboUnit(C1ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectDistinctByUnit();
            //String aaa = "";
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                item = new ComboBoxItem();
                item.Text = row[ostkD.UnitType].ToString();
                item.Value = i.ToString();

                c.Items.Add(item);
                i++;
            }
            return c;
        }
        public DataTable selectDistinctByUsageT()
        {
            DataTable dt = new DataTable();
            String sql = "select distinct ostkD." + ostkD.TUsage + " " +
                "From " + ostkD.table + " ostkD " +
                "Where ostkD." + ostkD.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public C1ComboBox setCboUsageT(C1ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectDistinctByUsageT();
            //String aaa = "";
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                item = new ComboBoxItem();
                item.Text = row[ostkD.TUsage].ToString();
                item.Value = i.ToString();

                c.Items.Add(item);
                i++;
            }
            return c;
        }
        public DataTable selectDistinctByUsageE()
        {
            DataTable dt = new DataTable();
            String sql = "select distinct ostkD." + ostkD.EUsage + " " +
                "From " + ostkD.table + " ostkD " +
                "Where ostkD." + ostkD.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public C1ComboBox setCboUsageE(C1ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectDistinctByUsageE();
            //String aaa = "";
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                item = new ComboBoxItem();
                item.Text = row[ostkD.EUsage].ToString();
                item.Value = i.ToString();

                c.Items.Add(item);
                i++;
            }
            return c;
        }
        public C1ComboBox setCboStockDrug(C1ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectAll();
            //String aaa = "";
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                item = new ComboBoxItem();
                item.Text = row[ostkD.DUName].ToString();
                item.Value = row[ostkD.DUID].ToString();

                c.Items.Add(item);
                i++;
            }
            return c;
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
