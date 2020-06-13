using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class OldJobLabDetailDB
    {
        public OldJobLabDetail jlabD;
        ConnectDB conn;

        public OldJobLabDetailDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            jlabD = new OldJobLabDetail();
            jlabD.ID = "ID";
            jlabD.VN = "VN";
            jlabD.LID = "LID";
            jlabD.Extra = "Extra";
            jlabD.Price = "Price";
            jlabD.Status = "Status";
            jlabD.PID = "PID";
            jlabD.PIDS = "PIDS";
            jlabD.LName = "LName";
            jlabD.SP1V = "SP1V";
            jlabD.SP2V = "SP2V";
            jlabD.SP3V = "SP3V";
            jlabD.SP4V = "SP4V";
            jlabD.SP5V = "SP5V";
            jlabD.SP6V = "SP6V";
            jlabD.SP7V = "SP7V";
            jlabD.SubItem = "SubItem";
            jlabD.FileName = "FileName";
            jlabD.Worker1 = "Worker1";
            jlabD.Worker2 = "Worker2";
            jlabD.Worker3 = "Worker3";
            jlabD.Worker4 = "Worker4";
            jlabD.LGID = "LGID";
            jlabD.QTY = "QTY";
            jlabD.row1 = "row1";
            jlabD.status_show_qty = "status_show_qty";
            jlabD.status_nurse = "status_nurse";
            jlabD.status_cashier = "status_cashier";
            jlabD.status_result = "status_result";
            jlabD.result = "result";
            jlabD.method = "method";
            jlabD.unit = "unit";
            jlabD.result_remark = "result_remark";
            jlabD.normal_value = "normal_value";
            jlabD.date_cancel = "date_cancel";
            jlabD.date_create = "date_create";
            jlabD.date_modi = "date_modi";
            jlabD.user_cancel = "user_cancel";
            jlabD.user_create = "user_create";
            jlabD.user_modi = "user_modi";
            jlabD.status_amt = "status_amt";
            jlabD.status_order_group = "status_order_group";
            jlabD.lab_order_id = "lab_order_id";
            jlabD.req_id = "req_id";
            jlabD.price1 = "price1";
            jlabD.pckdid = "pckdid";

            jlabD.table = "JobLabDetail";
            jlabD.pkField = "ID";
        }
        private void chkNull(OldJobLabDetail p)
        {
            long chk = 0;
            decimal chk1 = 0;


            p.PIDS = p.PIDS == null ? "" : p.PIDS;
            p.VN = p.VN == null ? "" : p.VN;
            p.FileName = p.FileName == null ? "" : p.FileName;
            p.Worker1 = p.Worker1 == null ? "" : p.Worker1;
            p.Worker2 = p.Worker2 == null ? "" : p.Worker2;
            p.Worker3 = p.Worker3 == null ? "" : p.Worker3;
            p.Worker4 = p.Worker4 == null ? "" : p.Worker4;
            p.SP1V = p.SP1V == null ? "" : p.SP1V;
            p.SP2V = p.SP2V == null ? "" : p.SP2V;
            p.SP3V = p.SP3V == null ? "" : p.SP3V;
            p.SP4V = p.SP4V == null ? "" : p.SP4V;
            p.SP5V = p.SP5V == null ? "" : p.SP5V;
            p.SP6V = p.SP6V == null ? "" : p.SP6V;
            p.SP7V = p.SP7V == null ? "" : p.SP7V;
            p.Extra = p.Extra == null ? "" : p.Extra;
            p.result = p.result == null ? "" : p.result;
            p.method = p.method == null ? "" : p.method;
            p.unit = p.unit == null ? "" : p.unit;
            p.result_remark = p.result_remark == null ? "" : p.result_remark;
            p.normal_value = p.normal_value == null ? "" : p.normal_value;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.date_create = p.date_create == null ? "" : p.date_create;
            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;

            p.status_show_qty = p.status_show_qty == null ? "0" : p.status_show_qty;
            p.status_nurse = p.status_nurse == null ? "0" : p.status_nurse;
            p.status_cashier = p.status_cashier == null ? "0" : p.status_cashier;
            p.status_result = p.status_result == null ? "0" : p.status_result;
            p.status_amt = p.status_amt == null ? "1" : p.status_amt;
            p.status_order_group = p.status_order_group == null ? "0" : p.status_order_group;

            p.LGID = long.TryParse(p.LGID, out chk) ? chk.ToString() : "0";
            p.QTY = long.TryParse(p.QTY, out chk) ? chk.ToString() : "0";
            p.SubItem = long.TryParse(p.SubItem, out chk) ? chk.ToString() : "0";
            p.PID = long.TryParse(p.PID, out chk) ? chk.ToString() : "0";
            p.Status = long.TryParse(p.Status, out chk) ? chk.ToString() : "0";
            p.Extra = long.TryParse(p.Extra, out chk) ? chk.ToString() : "0";
            p.PID = long.TryParse(p.PID, out chk) ? chk.ToString() : "0";
            p.row1 = long.TryParse(p.row1, out chk) ? chk.ToString() : "0";
            p.lab_order_id = long.TryParse(p.lab_order_id, out chk) ? chk.ToString() : "0";
            p.req_id = long.TryParse(p.req_id, out chk) ? chk.ToString() : "0";
            p.pckdid = long.TryParse(p.pckdid, out chk) ? chk.ToString() : "0";

            p.Price = decimal.TryParse(p.Price, out chk1) ? chk1.ToString() : "0";
            p.price1 = decimal.TryParse(p.price1, out chk1) ? chk1.ToString() : "0";
        }
        public String insert(OldJobLabDetail p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            //lbReq.form_a_id = "form_a_id";
            //p.req_code = genReqDoc();
            sql = "Insert Into " + jlabD.table + " Set " +
                " " + jlabD.VN + " = '" + p.VN + "'" +
                "," + jlabD.LID + "= '" + p.LID + "'" +
                "," + jlabD.Extra + "= '" + p.Extra + "'" +
                "," + jlabD.Price + "= '" + p.Price + "'" +
                "," + jlabD.Status + "= '" + p.Status + "'" +
                "," + jlabD.PID + "= '" + p.PID + "'" +
                "," + jlabD.PIDS + "= '" + p.PIDS + "'" +
                "," + jlabD.LName + "= '" + p.LName.Replace("'", "''") + "'" +
                "," + jlabD.SP1V + "= '" + p.SP1V.Replace("'", "''") + "'" +
                "," + jlabD.SP2V + "= '" + p.SP2V.Replace("'", "''") + "'" +
                "," + jlabD.SP3V + "= '" + p.SP3V.Replace("'", "''") + "'" +
                "," + jlabD.SP4V + "= '" + p.SP4V.Replace("'", "''") + "'" +
                "," + jlabD.SP5V + "= '" + p.SP5V.Replace("'", "''") + "'" +
                "," + jlabD.SP6V + "= '" + p.SP6V.Replace("'", "''") + "'" +
                "," + jlabD.SP7V + "= '" + p.SP7V.Replace("'", "''") + "'" +
                "," + jlabD.SubItem + "= '" + p.SubItem + "'" +
                "," + jlabD.FileName + "= '" + p.FileName.Replace("'", "''") + "'" +
                "," + jlabD.Worker1 + "= '" + p.Worker1.Replace("'", "''") + "'" +
                "," + jlabD.Worker2 + "= '" + p.Worker2.Replace("'", "''") + "'" +
                "," + jlabD.Worker3 + "= '" + p.Worker3.Replace("'", "''") + "'" +
                "," + jlabD.Worker4 + "= '" + p.Worker4.Replace("'", "''") + "'" +
                "," + jlabD.LGID + "= '" + p.LGID.Replace("'", "''") + "'" +
                "," + jlabD.QTY + "= '" + p.QTY.Replace("'", "''") + "'" +
                "," + jlabD.row1 + "= '" + p.row1.Replace("'", "''") + "'" +
                "," + jlabD.status_show_qty + "= '" + p.status_show_qty.Replace("'", "''") + "'" +
                "," + jlabD.status_nurse + "= '" + p.status_nurse.Replace("'", "''") + "'" +
                "," + jlabD.status_cashier + "= '" + p.status_cashier.Replace("'", "''") + "'" +
                "," + jlabD.status_result + "= '" + p.status_result.Replace("'", "''") + "'" +
                "," + jlabD.result + "= '" + p.result.Replace("'", "''") + "'" +
                "," + jlabD.method + "= '" + p.method.Replace("'", "''") + "'" +
                "," + jlabD.unit + "= '" + p.unit.Replace("'", "''") + "'" +
                "," + jlabD.result_remark + "= '" + p.result_remark.Replace("'", "''") + "'" +
                "," + jlabD.normal_value + "= '" + p.normal_value.Replace("'", "''") + "'" +
                "," + jlabD.date_cancel + "= ''" +
                "," + jlabD.date_create + "= now()" +
                "," + jlabD.date_modi + "= ''" +
                "," + jlabD.user_cancel + "= ''" +
                "," + jlabD.user_create + "= '" + userId + "'" +
                "," + jlabD.user_modi + "= ''" +
                "," + jlabD.status_amt + "= '" + p.status_amt.Replace("'", "''") + "'" +
                "," + jlabD.status_order_group + "= '" + p.status_order_group.Replace("'", "''") + "'" +
                "," + jlabD.lab_order_id + "= '" + p.lab_order_id + "'" +
                "," + jlabD.price1 + "= '" + p.price1 + "'" +
                "," + jlabD.pckdid + "= '" + p.pckdid + "'" +
                "";
            try
            {
                if (sql.IndexOf("SubItem= '0'") > 0)
                {
                    sql = sql.Replace("SubItem= '0'", "SubItem = null");
                }
                re = conn.ExecuteNonQuery(conn.conn, sql);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
            }

            return re;
        }
        public String deleteByPk(String id)
        {
            DataTable dt = new DataTable();
            String re = "";
            String sql = "Delete From  " + jlabD.table+" "+
                "Where "+ jlabD.pkField+"='"+id+"'";
            //re = conn.ExecuteNonQuery(conn.conn, sql);
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
        public String deleteByPkgsId(String pkgsid)
        {
            DataTable dt = new DataTable();
            String re = "";
            String sql = "Delete From  " + jlabD.table + " " +
                "Where " + jlabD.pckdid + "='" + pkgsid + "'";
            //re = conn.ExecuteNonQuery(conn.conn, sql);
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
        public String updateReqId(String reqid,String id)
        {
            DataTable dt = new DataTable();
            String re = "";
            String sql = "Update  " + jlabD.table + " Set " +
                "" + jlabD.req_id + "='" + reqid+"' " +
                "Where " + jlabD.pkField + "='" + id + "'";
            //re = conn.ExecuteNonQuery(conn.conn, sql);
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
        public OldJobLabDetail selectByPk1(String pttId)
        {
            DataTable dt = new DataTable();
            OldJobLabDetail ojld = new OldJobLabDetail();
            String sql = "select jlabD.* " +
                "From " + jlabD.table + " jlabD " +
                "Where jlabD." + jlabD.pkField + " ='" + pttId + "' ";
            dt = conn.selectData(conn.conn, sql);
            ojld = setJobLabDetail(dt);
            return ojld;
        }
        public DataTable selectByPk(String pttId)
        {
            DataTable dt = new DataTable();
            String sql = "select jlabD.* " +
                "From " + jlabD.table + " jlabD " +
                "Where jlabD." + jlabD.pkField + " ='" + pttId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByPID(String pttId)
        {
            DataTable dt = new DataTable();
            String sql = "select jlabD.*,vs.visit_begin_visit_time " +
                "From " + jlabD.table + " jlabD " +
                "Left Join t_visit vs on jlabD.VN = vs.visit_vn " +
                "Where jlabD." + jlabD.PID + " ='" + pttId + "' and jlabD.active = '1'" +
                "Order By jlabD." + jlabD.LID;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByVN(String pttId)
        {
            DataTable dt = new DataTable();
            String sql = "select jlabD.* " +
                "From " + jlabD.table + " jlabD " +
                //"Left Join labItem li on jlabD.LID = li.LID " +
                "Where jlabD." + jlabD.VN + " ='" + pttId + "' and jlabD.active = '1'" +
                "Order By jlabD." + jlabD.LID;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByVNnoReq(String vn)
        {
            DataTable dt = new DataTable();
            String sql = "select jlabD.* " +
                "From " + jlabD.table + " jlabD " +
                "Left Join LabItem li on jlabD.LID = li.LID " +
                "Where jlabD." + jlabD.VN + " ='" + vn + "' and jlabD.active = '1' and jlabD.req_id = 0 and li.status_outlab = '0' and li.status_send_request = '0' " +
                "Order By li.sort1, jlabD." + jlabD.LID;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectBillExtra0ByVN(String pttId)
        {
            DataTable dt = new DataTable();
            String sql = "select jlabD.* " +
                "From " + jlabD.table + " jlabD " +
                //"Left Join labItem li on jlabD.LID = li.LID " +
                "Where jlabD." + jlabD.VN + " ='" + pttId + "' and Extra='0' and SubItem is null and status_amt = '1' " +
                "Order By jlabD." + jlabD.LID;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectBillExtra1ByVN(String pttId)
        {
            DataTable dt = new DataTable();
            String sql = "select jlabD.* " +
                "From " + jlabD.table + " jlabD " +
                //"Left Join labItem li on jlabD.LID = li.LID " +
                "Where jlabD." + jlabD.VN + " ='" + pttId + "' and Extra='1' and SubItem is null and status_amt = '1' " +
                "Order By jlabD." + jlabD.LID;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public String selectSumIncludePriceByVN(String copId)
        {
            String re = "0";
            DataTable dt = new DataTable();
            String sql = "select sum(jlabD." + jlabD.Price + "*" + jlabD.QTY + ") as Include_Pkg_Price " +
                "From " + jlabD.table + " jlabD " +
                "Where jlabD." + jlabD.VN + " ='" + copId + "' and Extra='0' and status_amt = '1' "
                ;
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                re = dt.Rows[0]["Include_Pkg_Price"] != null ? dt.Rows[0]["Include_Pkg_Price"].ToString() : "0";
            }
            return re;
        }
        public String selectSumIncludePriceByVNOldProgram(String copId)
        {
            String re = "0";
            DataTable dt = new DataTable();
            String sql = "select sum(jlabD." + jlabD.Price + ") as Include_Pkg_Price " +
                "From " + jlabD.table + " jlabD " +
                "Where jlabD." + jlabD.VN + " ='" + copId + "' and Extra='0' and status_amt = '1' "
                ;
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                re = dt.Rows[0]["Include_Pkg_Price"] != null ? dt.Rows[0]["Include_Pkg_Price"].ToString() : "0";
            }
            return re;
        }
        public String selectSumExtraPriceByVN(String copId)
        {
            String re = "0";
            DataTable dt = new DataTable();
            String sql = "select sum(jlabD." + jlabD.Price + "*" + jlabD.QTY + ") as Extra_Pkg_Price " +
                "From " + jlabD.table + " jlabD " +
                "Where jlabD." + jlabD.VN + " ='" + copId + "' and Extra='1' and status_amt = '1' "
                ;
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                re = dt.Rows[0]["Extra_Pkg_Price"] != null ? dt.Rows[0]["Extra_Pkg_Price"].ToString() : "0";
            }
            return re;
        }
        public String selectSumExtraPriceByVNOldProgram(String copId)
        {
            String re = "0";
            DataTable dt = new DataTable();
            String sql = "select sum(jlabD." + jlabD.Price + ") as Extra_Pkg_Price " +
                "From " + jlabD.table + " jlabD " +
                "Where jlabD." + jlabD.VN + " ='" + copId + "' and Extra='1' and status_amt = '1' "
                ;
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                re = dt.Rows[0]["Extra_Pkg_Price"] != null ? dt.Rows[0]["Extra_Pkg_Price"].ToString() : "0";
            }
            return re;
        }
        public String selectByStatusSememAnalysis(String vn)
        {
            String re = "";
            DataTable dt = new DataTable();
            String sql = "Select jlabD.ID  " +
                "From " + jlabD.table + " jlabD " +
                "Where jlabD." + jlabD.Status + " ='1' and jlabD.LID in (14) " +
                "and jlabD.VN ='" + vn + "' " +
                "Order By jlabD.ID";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                re = dt.Rows[0]["ID"].ToString();
            }
            return re;
        }
        public String selectByStatusSememFreezing(String vn)
        {
            String re = "";
            DataTable dt = new DataTable();
            String sql = "Select jlabD.ID  " +
                "From " + jlabD.table + " jlabD " +
                "Where jlabD." + jlabD.Status + " ='1' and jlabD.LID in (18) " +
                "and jlabD.VN ='" + vn + "' " +
                "Order By jlabD.ID";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                re = dt.Rows[0]["ID"].ToString();
            }
            return re;
        }
        public String selectByStatusPesa(String vn)
        {
            String re = "";
            DataTable dt = new DataTable();
            String sql = "Select jlabD.ID  " +
                "From " + jlabD.table + " jlabD " +
                "Where jlabD." + jlabD.Status + " ='1' and jlabD.LID in (66) " +
                "and jlabD.VN ='" + vn + "' " +
                "Order By jlabD.ID";
            dt = conn.selectData(conn.conn, sql);
            if (dt.Rows.Count > 0)
            {
                re = dt.Rows[0]["ID"].ToString();
            }
            return re;
        }
        public OldJobLabDetail setJobLabDetail(DataTable dt)
        {
            OldJobLabDetail lbReq1 = new OldJobLabDetail();
            if (dt.Rows.Count > 0)
            {
                lbReq1.ID = dt.Rows[0][jlabD.ID].ToString();
                lbReq1.VN = dt.Rows[0][jlabD.VN].ToString();
                lbReq1.LID = dt.Rows[0][jlabD.LID].ToString();
                lbReq1.Extra = dt.Rows[0][jlabD.Extra].ToString();
                lbReq1.Price = dt.Rows[0][jlabD.Price].ToString();
                lbReq1.Status = dt.Rows[0][jlabD.Status].ToString();
                lbReq1.PID = dt.Rows[0][jlabD.PID].ToString();
                lbReq1.PIDS = dt.Rows[0][jlabD.PIDS].ToString();
                lbReq1.LName = dt.Rows[0][jlabD.LName].ToString();
                lbReq1.SP1V = dt.Rows[0][jlabD.SP1V].ToString();
                lbReq1.SP2V = dt.Rows[0][jlabD.SP2V].ToString();
                lbReq1.SP3V = dt.Rows[0][jlabD.SP3V].ToString();
                lbReq1.SP4V = dt.Rows[0][jlabD.SP4V].ToString();
                lbReq1.SP5V = dt.Rows[0][jlabD.SP5V].ToString();
                lbReq1.SP6V = dt.Rows[0][jlabD.SP6V].ToString();
                lbReq1.SP7V = dt.Rows[0][jlabD.SP7V].ToString();
                lbReq1.SubItem = dt.Rows[0][jlabD.SubItem].ToString();
                lbReq1.FileName = dt.Rows[0][jlabD.FileName].ToString();
                lbReq1.Worker1 = dt.Rows[0][jlabD.Worker1].ToString();
                lbReq1.Worker2 = dt.Rows[0][jlabD.Worker2].ToString();
                lbReq1.Worker3 = dt.Rows[0][jlabD.Worker3].ToString();
                lbReq1.Worker4 = dt.Rows[0][jlabD.Worker4].ToString();
                lbReq1.LGID = dt.Rows[0][jlabD.LGID].ToString();
                lbReq1.QTY = dt.Rows[0][jlabD.QTY].ToString();
                lbReq1.row1 = dt.Rows[0][jlabD.row1].ToString();
                lbReq1.status_show_qty = dt.Rows[0][jlabD.status_show_qty].ToString();
                lbReq1.status_nurse = dt.Rows[0][jlabD.status_nurse].ToString();
                lbReq1.status_cashier = dt.Rows[0][jlabD.status_cashier].ToString();
                lbReq1.status_result = dt.Rows[0][jlabD.status_result].ToString();
                lbReq1.result = dt.Rows[0][jlabD.result].ToString();
                lbReq1.method = dt.Rows[0][jlabD.method].ToString();
                lbReq1.unit = dt.Rows[0][jlabD.unit].ToString();
                lbReq1.result_remark = dt.Rows[0][jlabD.result_remark].ToString();
                lbReq1.normal_value = dt.Rows[0][jlabD.normal_value].ToString();
                lbReq1.date_cancel = dt.Rows[0][jlabD.date_cancel].ToString();
                lbReq1.date_create = dt.Rows[0][jlabD.date_create].ToString();
                lbReq1.date_modi = dt.Rows[0][jlabD.date_modi].ToString();
                lbReq1.user_cancel = dt.Rows[0][jlabD.user_cancel].ToString();
                lbReq1.user_modi = dt.Rows[0][jlabD.user_modi].ToString();
                lbReq1.status_amt = dt.Rows[0][jlabD.status_amt].ToString();
                lbReq1.status_order_group = dt.Rows[0][jlabD.status_order_group].ToString();
                lbReq1.lab_order_id = dt.Rows[0][jlabD.lab_order_id].ToString();
                lbReq1.req_id = dt.Rows[0][jlabD.req_id].ToString();
                lbReq1.price1 = dt.Rows[0][jlabD.price1].ToString();
                lbReq1.pckdid = dt.Rows[0][jlabD.pckdid].ToString();
            }
            else
            {
                lbReq1.ID = "";
                lbReq1.VN = "N";
                lbReq1.LID = "";
                lbReq1.Extra = "";
                lbReq1.Price = "";
                lbReq1.Status = "";
                lbReq1.PID = "";
                lbReq1.PIDS = "";
                lbReq1.LName = "";
                lbReq1.SP1V = "";
                lbReq1.SP2V = "";
                lbReq1.SP3V = "";
                lbReq1.SP4V = "";
                lbReq1.SP5V = "";
                lbReq1.SP6V = "";
                lbReq1.SP7V = "";
                lbReq1.SubItem = "";
                lbReq1.FileName = "";
                lbReq1.Worker1 = "";
                lbReq1.Worker2 = "";
                lbReq1.Worker3 = "";
                lbReq1.Worker4 = "";
                lbReq1.LGID = "";
                lbReq1.QTY = "";
                lbReq1.row1 = "";
                lbReq1.status_show_qty = "";
                lbReq1.status_nurse = "";
                lbReq1.status_cashier = "";
                lbReq1.status_result = "";
                lbReq1.result = "";
                lbReq1.method = "";
                lbReq1.unit = "";
                lbReq1.result_remark = "";
                lbReq1.normal_value = "";
                lbReq1.date_cancel = "";
                lbReq1.date_create = "";
                lbReq1.date_modi = "";
                lbReq1.user_cancel = "";
                lbReq1.user_create = "";
                lbReq1.user_modi = "";
                lbReq1.status_amt = "";
                lbReq1.status_order_group = "";
                lbReq1.lab_order_id = "";
                lbReq1.req_id = "";
                lbReq1.price1 = "";
                lbReq1.pckdid = "";
            }

            return lbReq1;
        }
    }
}
