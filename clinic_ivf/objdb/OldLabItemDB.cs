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
    public class OldLabItemDB
    {
        public OldLabItem labI;
        ConnectDB conn;
        public List<OldLabItem> lolItm;
        public OldLabItemDB(ConnectDB c)
        {
            conn = c;
            
            initConfig();
        }
        private void initConfig()
        {
            lolItm = new List<OldLabItem>();
            labI = new OldLabItem();
            labI.LID = "LID";
            labI.LGID = "LGID";
            labI.LName = "LName";
            labI.WorkTime = "WorkTime";
            labI.Price = "Price";
            labI.SP1N = "SP1N";
            labI.SP1T = "SP1T";
            labI.SP2N = "SP2N";
            labI.SP2T = "SP2T";
            labI.SP3N = "SP3N";
            labI.SP3T = "SP3T";
            labI.SP4N = "SP4N";
            labI.SP4T = "SP4T";
            labI.SP5N = "SP5N";
            labI.SP5T = "SP5T";
            labI.SP6N = "SP6N";
            labI.SP6T = "SP6T";
            labI.SP7N = "SP7N";
            labI.SP7T = "SP7T";
            labI.SubItem = "SubItem";
            labI.WorkerGroup1 = "WorkerGroup1";
            labI.WorkerGroup2 = "WorkerGroup2";
            labI.WorkerGroup3 = "WorkerGroup3";
            labI.WorkerGroup4 = "WorkerGroup4";
            labI.QTY = "QTY";
            labI.active = "active";
            labI.status_show_qty = "status_show_qty";
            labI.status_order_group = "status_order_group";
            labI.unit = "unit";
            labI.normal_vaule = "normal_vaule";
            labI.method = "method";
            labI.status_outlab = "status_outlab";
            labI.num_barcode = "num_barcode";
            labI.lab_unit_id = "lab_unit_id";
            labI.method_id = "method_id";
            labI.datatype_decimal = "datatype_decimal";
            labI.status_datatype_result = "status_datatype_result";
            labI.status_interpret = "status_interpret";
            labI.remark = "remark";
            labI.lis_max_value = "lis_max_value";
            labI.lis_min_value = "lis_min_value";
            labI.status_send_request = "status_send_request";
            labI.sort1 = "sort1";
            labI.item_code = "item_code";
            labI.date_cancel = "date_cancel";
            labI.date_create = "date_create";
            labI.date_modi = "date_modi";
            labI.user_cancel = "user_cancel";
            labI.user_create = "user_create";
            labI.user_modi = "user_modi";

            labI.table = "LabItem";
            labI.pkField = "LID";
        }
        public DataTable selectAllEx()
        {
            DataTable dt = new DataTable();
            String sql = "select labI." + labI.LID + " as id,labI." + labI.LName + " as name," + labI.item_code + " as code " +
                "From " + labI.table + " labI " +
                "Where " + labI.active + " ='1' ";
            dt = conn.selectData(conn.connEx, sql);
            return dt;
        }
        public DataTable selectAll2()
        {
            DataTable dt = new DataTable();
            String sql = "select labI." + labI.LID + " as id,labI." + labI.LName + " as name," + labI.item_code + " as code " +
                "From " + labI.table + " labI " +
                "Left Join LabItemGroup labg on labI." + labI.LGID + "=labg.LGID " +
                "Where labI." + labI.active + " ='1' " +
                "Order By " + labI.LName;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select labI."+ labI.LID+","+ labI.item_code+","+ labI.LName+" " +
                "From " + labI.table + " labI " +
                "Where " + labI.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectAll1()
        {
            DataTable dt = new DataTable();
            String sql = "select labI.* "+
                "From " + labI.table + " labI " +
                "Left Join LabItemGroup labg on labI."+labI.LGID+"=labg.LGID " +
                "Where labI." + labI.active + " ='1' " +
                "Order By "+labI.LName;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectAll3()
        {
            DataTable dt = new DataTable();
            String sql = "select labI.LID, labI.LName, labI.Price " +
                "From " + labI.table + " labI " +
                "Left Join LabItemGroup labg on labI." + labI.LGID + "=labg.LGID " +
                "Where labI." + labI.active + " ='1' " +
                "Order By " + labI.LName;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByPk(String pttId)
        {
            DataTable dt = new DataTable();
            String sql = "select labI.* " +
                "From " + labI.table + " labI " +
                "Where labI." + labI.pkField + " ='" + pttId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public OldLabItem selectByPk1(String pttId)
        {
            OldLabItem labi1 = new OldLabItem();
            DataTable dt = new DataTable();
            String sql = "select labI.* " +
                "From " + labI.table + " labI " +
                "Where labI." + labI.pkField + " ='" + pttId + "' ";
            dt = conn.selectData(conn.conn, sql);
            labi1 = setLabItem(dt);
            return labi1;
        }
        public DataTable selectByBloodLab1()
        {
            DataTable dt = new DataTable();
            String sql = "select labI."+labI.LID+ ",labI." + labI.LName+ ", '1' as qty,labI." + labI.Price + ", " +labI.status_order_group+" "+
                "From " + labI.table + " labI " +
                "Where labI." + labI.LGID + " ='1' and " + labI.SubItem + "='0'  and active = '1' " +
                "Order By labI." + labI.LName;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByBloodLab()
        {
            DataTable dt = new DataTable();
            String sql = "select labI.* " +
                "From " + labI.table + " labI " +
                "Where labI." + labI.LGID + " ='1' and "+labI.SubItem+ "='0'  and active = '1' " +
                "Order By labI."+labI.LName;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByHormoneLab1()
        {
            DataTable dt = new DataTable();
            String sql = "select labI." + labI.LID + ",labI." + labI.LName + ",labI." + labI.Price + " " +
                "From " + labI.table + " labI " +
                "Where labI." + labI.LGID + " ='2' and " + labI.SubItem + "='0'  and active = '1' " +
                "Order By labI." + labI.LName;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByHormoneLab()
        {
            DataTable dt = new DataTable();
            String sql = "select labI.* " +
                "From " + labI.table + " labI " +
                "Where labI." + labI.LGID + " ='2' and " + labI.SubItem + "='0'  and active = '1' " +
                "Order By labI." + labI.LName;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectBySpermLab()
        {
            DataTable dt = new DataTable();
            String sql = "select labI.* " +
                "From " + labI.table + " labI " +
                "Where labI." + labI.LGID + " ='3' and " + labI.SubItem + "='0'  and active = '1' " +
                "Order By labI." + labI.LName;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectBySpermLab1()
        {
            DataTable dt = new DataTable();
            String sql = "select labI." + labI.LID + ",labI." + labI.LName + ",labI." + labI.Price + " " +
                "From " + labI.table + " labI " +
                "Where labI." + labI.LGID + " ='3' and " + labI.SubItem + "='0'  and active = '1' " +
                "Order By labI." + labI.LName;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByEmbryoLab()
        {
            DataTable dt = new DataTable();
            String sql = "select labI.* " +
                "From " + labI.table + " labI " +
                "Where labI." + labI.LGID + " ='4' and " + labI.SubItem + "='0'  and active = '1' " +
                "Order By labI." + labI.LName;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByEmbryoLab1()
        {
            DataTable dt = new DataTable();
            String sql = "select labI." + labI.LID + ",labI." + labI.LName + ",labI." + labI.Price + " " +
                "From " + labI.table + " labI " +
                "Where labI." + labI.LGID + " ='4' and " + labI.SubItem + "='0' and active = '1' " +
                "Order By labI." + labI.LName;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByGeneticLab()
        {
            DataTable dt = new DataTable();
            String sql = "select labI.* " +
                "From " + labI.table + " labI " +
                "Where labI." + labI.LGID + " ='5' and " + labI.SubItem + "='0'  and active = '1' " +
                "Order By labI." + labI.LName;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByGeneticLab1()
        {
            DataTable dt = new DataTable();
            String sql = "select labI." + labI.LID + ",labI." + labI.LName + ",labI." + labI.Price + " " +
                "From " + labI.table + " labI " +
                "Where labI." + labI.LGID + " ='5' and " + labI.SubItem + "='0'  and active = '1' " +
                "Order By labI." + labI.LName;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public void getloLabItem()
        {
            //lDept = new List<Position>();
            lolItm.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                OldLabItem itm1 = new OldLabItem();
                itm1.LID = row[labI.LID].ToString();
                itm1.LGID = row[labI.LGID].ToString();
                itm1.LName = row[labI.LName].ToString();
                itm1.WorkTime = row[labI.WorkTime].ToString();
                itm1.Price = row[labI.Price].ToString();
                itm1.QTY = row[labI.QTY].ToString();
                
                lolItm.Add(itm1);
            }
        }

        private void chkNull(OldLabItem p)
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

            p.LName = p.LName == null ? "" : p.LName;
            p.SP1N = p.SP1N == null ? "" : p.SP1N;
            p.SP1T = p.SP1T == null ? "" : p.SP1T;
            p.SP2N = p.SP2N == null ? "" : p.SP2N;
            p.SP2T = p.SP2T == null ? "" : p.SP2T;
            p.SP3N = p.SP3N == null ? "" : p.SP3N;
            p.SP3T = p.SP3T == null ? "" : p.SP3T;
            p.SP4N = p.SP4N == null ? "" : p.SP4N;
            p.SP4T = p.SP4T == null ? "" : p.SP4T;
            p.SP5N = p.SP5N == null ? "" : p.SP5N;
            p.SP5T = p.SP5T == null ? "" : p.SP5T;
            p.SP6N = p.SP6N == null ? "" : p.SP6N;
            p.SP6T = p.SP6T == null ? "" : p.SP6T;
            p.SP7N = p.SP7N == null ? "" : p.SP7N;
            p.SP7T = p.SP7T == null ? "" : p.SP7T;
            p.WorkerGroup1 = p.WorkerGroup1 == null ? "" : p.WorkerGroup1;
            p.WorkerGroup2 = p.WorkerGroup2 == null ? "" : p.WorkerGroup2;
            p.WorkerGroup3 = p.WorkerGroup3 == null ? "" : p.WorkerGroup3;
            p.WorkerGroup4 = p.WorkerGroup4 == null ? "" : p.WorkerGroup4;
            p.active = p.active == null ? "" : p.active;
            p.method = p.method == null ? "" : p.method;
            p.unit = p.unit == null ? "" : p.unit;
            p.normal_vaule = p.normal_vaule == null ? "" : p.normal_vaule;
            p.num_barcode = p.num_barcode == null ? "0" : p.num_barcode;
            p.status_datatype_result = p.status_datatype_result == null ? "0" : p.status_datatype_result;
            p.datatype_decimal = p.datatype_decimal == null ? "0" : p.datatype_decimal;
            p.remark = p.remark == null ? "" : p.remark;
            p.lis_max_value = p.lis_max_value == null ? "" : p.lis_max_value;
            p.lis_min_value = p.lis_min_value == null ? "" : p.lis_min_value;

            p.status_show_qty = p.status_show_qty == null ? "0" : p.status_show_qty;
            p.status_order_group = p.status_order_group == null ? "0" : p.status_order_group;
            p.status_outlab = p.status_outlab == null ? "0" : p.status_outlab;
            p.status_interpret = p.status_interpret.Equals("") ? "0" : p.status_interpret;
            p.status_send_request = p.status_send_request.Equals("") ? "0" : p.status_send_request;
            p.sort1 = p.sort1.Equals("") ? "999999999" : p.sort1;

            p.LGID = long.TryParse(p.LGID, out chk) ? chk.ToString() : "0";
            p.SubItem = long.TryParse(p.SubItem, out chk) ? chk.ToString() : "0";
            p.QTY = long.TryParse(p.QTY, out chk) ? chk.ToString() : "1";
            p.lab_unit_id = long.TryParse(p.lab_unit_id, out chk) ? chk.ToString() : "0";
            p.method_id = long.TryParse(p.method_id, out chk) ? chk.ToString() : "0";

            p.Price = Decimal.TryParse(p.Price, out chk1) ? chk1.ToString() : "0";
            //p.QTY = Decimal.TryParse(p.QTY, out chk1) ? chk1.ToString() : "0";
            //p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            if (p.QTY.Equals("0")) p.QTY = "1";
        }
        public String insert(OldLabItem p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            //lbReq.form_a_id = "form_a_id";
            //p.req_code = genReqDoc();
            sql = "Insert Into " + labI.table + " Set " +
                " " + labI.LName + " = '" + p.LName.Replace("'", "''") + "'" +
                "," + labI.Price + "= '" + p.Price + "'" +
                "," + labI.WorkTime + "= '" + p.WorkTime + "'" +
                "," + labI.SP1N + "= '" + p.SP1N + "'" +
                "," + labI.SP1T + "= '" + p.SP1T + "'" +
                "," + labI.SP2N + "= '" + p.SP2N + "'" +
                "," + labI.SP2T + "= '" + p.SP2T + "'" +
                "," + labI.SP3N + "= '" + p.SP3N + "'" +
                "," + labI.SP3T + "= '" + p.SP3T + "'" +
                "," + labI.SP4N + "= '" + p.SP4N + "'" +
                "," + labI.SP4T + "= '" + p.SP4T + "'" +
                "," + labI.SP5N + "= '" + p.SP5N + "'" +
                "," + labI.SP5T + "= '" + p.SP5T + "'" +
                "," + labI.SP6N + "= '" + p.SP6N + "'" +
                "," + labI.SP6T + "= '" + p.SP6T + "'" +
                "," + labI.SP7N + "= '" + p.SP7N + "'" +
                "," + labI.SP7T + "= '" + p.SP7T + "'" +
                "," + labI.SubItem + "= '" + p.SubItem + "'" +
                "," + labI.WorkerGroup1 + "= '" + p.WorkerGroup1 + "'" +
                "," + labI.WorkerGroup2 + "= '" + p.WorkerGroup2 + "'" +
                "," + labI.WorkerGroup3 + "= '" + p.WorkerGroup3 + "'" +
                "," + labI.WorkerGroup4 + "= '" + p.WorkerGroup4 + "'" +
                "," + labI.QTY + "= '" + p.QTY + "'" +
                "," + labI.active + "= '1'" +
                "," + labI.LGID + "= '"+p.LGID+"'" +
                "," + labI.status_show_qty + "= '" + p.status_show_qty + "'" +
                "," + labI.status_order_group + "= '" + p.status_order_group + "'" +
                "," + labI.normal_vaule + "= '" + p.normal_vaule.Replace("'", "''") + "'" +
                "," + labI.method + "= '" + p.method.Replace("'", "''") + "'" +
                "," + labI.unit + "= '" + p.unit.Replace("'", "''") + "'" +
                "," + labI.status_outlab + "= '" + p.status_outlab.Replace("'", "''") + "'" +
                "," + labI.num_barcode + "= '" + p.num_barcode.Replace("'", "''") + "'" +
                "," + labI.lab_unit_id + "= '" + p.lab_unit_id.Replace("'", "''") + "'" +
                "," + labI.method_id + "= '" + p.method_id.Replace("'", "''") + "'" +
                "," + labI.status_datatype_result + "= '" + p.status_datatype_result.Replace("'", "''") + "'" +
                "," + labI.datatype_decimal + "= '" + p.datatype_decimal.Replace("'", "''") + "'" +
                "," + labI.status_interpret + "= '" + p.status_interpret.Replace("'", "''") + "'" +
                "," + labI.remark + "= '" + p.remark.Replace("'", "''") + "'" +
                "," + labI.lis_max_value + "= '" + p.lis_max_value.Replace("'", "''") + "'" +
                "," + labI.lis_min_value + "= '" + p.lis_min_value.Replace("'", "''") + "'" +
                "," + labI.status_send_request + "= '" + p.status_send_request.Replace("'", "''") + "'" +
                "," + labI.sort1 + "= '" + p.sort1.Replace("'", "''") + "'" +
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
        public String update(OldLabItem p, String userId)
        {
            String re = "";
            String sql = "";
            chkNull(p);

            sql = "Update " + labI.table + " Set " +
                " " + labI.LName + " = '" + p.LName.Replace("'", "''") + "'" +
                "," + labI.Price + "= '" + p.Price + "'" +
                //"," + labI.WorkTime + "= '" + p.WorkTime + "'" +
                //"," + labI.SP1N + "= '" + p.SP1N + "'" +
                //"," + labI.SP1T + "= '" + p.SP1T + "'" +
                //"," + labI.SP2N + "= '" + p.SP2N + "'" +
                //"," + labI.SP2T + "= '" + p.SP2T + "'" +
                //"," + labI.SP3N + "= '" + p.SP3N + "'" +
                //"," + labI.SP3T + "= '" + p.SP3T + "'" +
                //"," + labI.SP4N + "= '" + p.SP4N + "'" +
                //"," + labI.SP4T + "= '" + p.SP4T + "'" +
                //"," + labI.SP5N + "= '" + p.SP5N + "'" +
                //"," + labI.SP5T + "= '" + p.SP5T + "'" +
                //"," + labI.SP6N + "= '" + p.SP6N + "'" +
                //"," + labI.SP6T + "= '" + p.SP6T + "'" +
                //"," + labI.SP7N + "= '" + p.SP7N + "'" +
                //"," + labI.SP7T + "= '" + p.SP7T + "'" +
                "," + labI.status_interpret + "= '" + p.status_interpret + "'" +
                "," + labI.status_datatype_result + "= '" + p.status_datatype_result + "'" +
                "," + labI.datatype_decimal + "= '" + p.datatype_decimal + "'" +
                "," + labI.lab_unit_id + "= '" + p.lab_unit_id + "'" +
                "," + labI.method_id + "= '" + p.method_id + "'" +
                "," + labI.QTY + "= '" + p.QTY + "'" +
                "," + labI.LGID + "= '" + p.LGID + "'" +
                "," + labI.status_show_qty + "= '" + p.status_show_qty + "'" +
                "," + labI.status_order_group + "= '" + p.status_order_group + "'" +
                "," + labI.normal_vaule + "= '" + p.normal_vaule.Replace("'", "''") + "'" +
                "," + labI.method + "= '" + p.method.Replace("'", "''") + "'" +
                "," + labI.unit + "= '" + p.unit.Replace("'", "''") + "'" +
                "," + labI.status_outlab + "= '" + p.status_outlab.Replace("'", "''") + "'" +
                "," + labI.num_barcode + "= '" + p.num_barcode.Replace("'", "''") + "'" +
                "," + labI.remark + "= '" + p.remark.Replace("'", "''") + "'" +
                "," + labI.lis_max_value + "= '" + p.lis_max_value.Replace("'", "''") + "'" +
                "," + labI.lis_min_value + "= '" + p.lis_min_value.Replace("'", "''") + "'" +
                "," + labI.status_send_request + "= '" + p.status_send_request.Replace("'", "''") + "'" +
                "," + labI.sort1 + "= '" + p.sort1.Replace("'", "''") + "'" +
                "Where " + labI.pkField + "='" + p.LID + "'";
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
        public String updateCode(String id, String code, String userId)
        {
            String re = "", sql = "";
            sql = "Update " + labI.table + " Set " +
                " " + labI.item_code + " = '" + code + "'" +
                "," + labI.user_modi + "= '" + userId + "'" +
                "," + labI.date_modi + "= now() " +
                "Where " + labI.pkField + "='" + id + "'";
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
        public String updateCodeEx(String id, String code, String userId)
        {
            String re = "", sql = "";
            sql = "Update " + labI.table + " Set " +
                " " + labI.item_code + " = '" + code + "'" +
                "," + labI.user_modi + "= '" + userId + "'" +
                "," + labI.date_modi + "= now() " +
                "Where " + labI.pkField + "='" + id + "'";
            try
            {
                re = conn.ExecuteNonQuery(conn.connEx, sql);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
            }

            return re;
        }
        public String insertLabItem(OldLabItem p, String userId)
        {
            String re = "";

            if (p.LID.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
            }

            return re;
        }
        public void setCboLabItem(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectWard();
            int i = 0;
            if (lolItm.Count <= 0) getloLabItem();
            item = new ComboBoxItem();
            item.Value = "";
            item.Text = "";
            c.Items.Add(item);
            foreach (OldLabItem cus1 in lolItm)
            {
                item = new ComboBoxItem();
                item.Value = cus1.LID;
                item.Text = cus1.LName + " " + cus1.LName;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    //c.SelectedItem = item.Value;
                    c.SelectedText = item.Text;
                    c.SelectedIndex = i + 1;
                }
                i++;
            }
        }
        public OldLabItem setLabItem(DataTable dt)
        {
            OldLabItem vsold1 = new OldLabItem();
            if (dt.Rows.Count > 0)
            {
                vsold1.LID = dt.Rows[0][labI.LID].ToString();
                vsold1.LGID = dt.Rows[0][labI.LGID].ToString();
                vsold1.LName = dt.Rows[0][labI.LName].ToString();
                vsold1.WorkTime = dt.Rows[0][labI.WorkTime].ToString();
                vsold1.Price = dt.Rows[0][labI.Price].ToString();
                vsold1.SP1N = dt.Rows[0][labI.SP1N].ToString();
                vsold1.SP2N = dt.Rows[0][labI.SP2N].ToString();
                vsold1.SP3N = dt.Rows[0][labI.SP3N].ToString();
                vsold1.SP4N = dt.Rows[0][labI.SP4N].ToString();
                vsold1.SP5N = dt.Rows[0][labI.SP5N].ToString();
                vsold1.SP6N = dt.Rows[0][labI.SP6N].ToString();
                vsold1.SP7N = dt.Rows[0][labI.SP7N].ToString();
                vsold1.SP1T = dt.Rows[0][labI.SP1T].ToString();
                vsold1.SP2T = dt.Rows[0][labI.SP2T].ToString();
                vsold1.SP3T = dt.Rows[0][labI.SP3T].ToString();
                vsold1.SP4T = dt.Rows[0][labI.SP4T].ToString();
                vsold1.SP5T = dt.Rows[0][labI.SP5T].ToString();
                vsold1.SP6T = dt.Rows[0][labI.SP6T].ToString();
                vsold1.SP7T = dt.Rows[0][labI.SP7T].ToString();
                vsold1.SubItem = dt.Rows[0][labI.SubItem].ToString();
                vsold1.WorkerGroup1 = dt.Rows[0][labI.WorkerGroup1].ToString();
                vsold1.WorkerGroup2 = dt.Rows[0][labI.WorkerGroup2].ToString();
                vsold1.WorkerGroup3 = dt.Rows[0][labI.WorkerGroup3].ToString();
                vsold1.WorkerGroup4 = dt.Rows[0][labI.WorkerGroup4].ToString();
                vsold1.QTY = dt.Rows[0][labI.QTY].ToString();
                vsold1.status_show_qty = dt.Rows[0][labI.status_show_qty].ToString();
                vsold1.status_order_group = dt.Rows[0][labI.status_order_group].ToString();
                vsold1.unit = dt.Rows[0][labI.unit].ToString();
                vsold1.normal_vaule = dt.Rows[0][labI.normal_vaule].ToString();
                vsold1.method = dt.Rows[0][labI.method].ToString();
                vsold1.status_outlab = dt.Rows[0][labI.status_outlab].ToString();
                vsold1.num_barcode = dt.Rows[0][labI.num_barcode].ToString();
                vsold1.method_id = dt.Rows[0][labI.method_id].ToString();
                vsold1.lab_unit_id = dt.Rows[0][labI.lab_unit_id].ToString();
                vsold1.status_datatype_result = dt.Rows[0][labI.status_datatype_result].ToString();
                vsold1.datatype_decimal = dt.Rows[0][labI.datatype_decimal].ToString();
                vsold1.status_interpret = dt.Rows[0][labI.status_interpret].ToString();
                vsold1.remark = dt.Rows[0][labI.remark].ToString();
                vsold1.lis_max_value = dt.Rows[0][labI.lis_max_value].ToString();
                vsold1.lis_min_value = dt.Rows[0][labI.lis_min_value].ToString();
                vsold1.status_send_request = dt.Rows[0][labI.status_send_request].ToString();
                vsold1.sort1 = dt.Rows[0][labI.sort1].ToString();
                vsold1.item_code = dt.Rows[0][labI.item_code].ToString();
            }
            else
            {
                setLabItem1(vsold1);
            }
            return vsold1;
        }
        private OldLabItem setLabItem1(OldLabItem stf1)
        {
            stf1.LID = "";
            stf1.LGID = "";
            stf1.LName = "";
            stf1.WorkTime = "";
            stf1.Price = "";
            stf1.SP1N = "";
            stf1.SP1T = "";
            stf1.SP2N = "";
            stf1.SP2T = "";
            stf1.SP3N = "";
            stf1.SP3T = "";
            stf1.SP4N = "";
            stf1.SP4T = "";
            stf1.SP5N = "";
            stf1.SP5T = "";
            stf1.SP6N = "";
            stf1.SP6T = "";
            stf1.SP7N = "";
            stf1.SP7T = "";
            stf1.SubItem = "";
            stf1.WorkerGroup1 = "";
            stf1.WorkerGroup2 = "";
            stf1.WorkerGroup3 = "";
            stf1.WorkerGroup4 = "";
            stf1.QTY = "";
            stf1.status_show_qty = "";
            stf1.status_order_group = "";
            stf1.method = "";
            stf1.unit = "";
            stf1.normal_vaule = "";
            stf1.status_outlab = "";
            stf1.num_barcode = "";
            stf1.lab_unit_id = "";
            stf1.method_id = "";
            stf1.status_datatype_result = "";
            stf1.datatype_decimal = "";
            stf1.status_interpret = "";
            stf1.remark = "";
            stf1.lis_min_value = "";
            stf1.lis_max_value = "";
            stf1.status_send_request = "";
            stf1.sort1 = "";
            stf1.item_code = "";
            return stf1;
        }
    }
}
