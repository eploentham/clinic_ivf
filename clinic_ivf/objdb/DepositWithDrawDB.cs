using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class DepositWithDrawDB
    {
        ConnectDB conn;
        DepositWithDraw dwithdraw;
        public List<DepositWithDraw> lFpf;

        public DepositWithDrawDB(ConnectDB c)
        {
            this.conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lFpf = new List<DepositWithDraw>();
            dwithdraw = new DepositWithDraw();

            dwithdraw.withdraw_id = "withdraw_id";
            dwithdraw.deposit_id = "deposit_id";
            dwithdraw.withdraw_code = "withdraw_code";
            dwithdraw.withdraw_date = "withdraw_date";
            dwithdraw.active = "active";
            dwithdraw.remark = "remark";
            dwithdraw.date_create = "date_create";
            dwithdraw.date_modi = "date_modi";
            dwithdraw.date_cancel = "date_cancel";
            dwithdraw.user_create = "user_create";
            dwithdraw.user_modi = "user_modi";
            dwithdraw.user_cancel = "user_cancel";
            dwithdraw.patient_hn = "patient_hn";
            dwithdraw.withdraw_name = "withdraw_name";
            dwithdraw.withdraw_amount = "withdraw_amount";
            dwithdraw.remark = "remark";
            dwithdraw.active = "active";
            dwithdraw.t_visit_id = "t_visit_id";
            dwithdraw.visit_vn = "visit_vn";
            dwithdraw.t_patient_id = "t_patient_id";

            dwithdraw.table = "t_deposit_withdraw";
            dwithdraw.pkField = "withdraw_id";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select dwithdraw.* " +
                "From " + dwithdraw.table + " dwithdraw " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                " Where dwithdraw." + dwithdraw.active + " ='1' " +
                "Order By dwithdraw.withdraw_date ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByDepositId(String depositid)
        {
            String wherehn = "";
            DataTable dt = new DataTable();
            if (depositid.Length > 0)
            {
                wherehn = " and deposit_id = '" + depositid + "'";
            }
            String sql = "select dwithdraw.* " +
                "From " + dwithdraw.table + " dwithdraw " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                " Where dwithdraw." + dwithdraw.active + " ='1' " + wherehn +
                "Order By dwithdraw.withdraw_date ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DepositWithDraw selectByPk(String id)
        {
            DepositWithDraw cop1 = new DepositWithDraw();
            DataTable dt = new DataTable();
            String sql = "select dwithdraw.* " +
                "From " + dwithdraw.table + " dwithdraw " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dwithdraw." + dwithdraw.pkField + " ='" + id + "' " +
                "Order By dwithdraw.withdraw_date ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setAccCashTransfer(dt);
            return cop1;
        }
        public DataTable selectByPk1(String id)
        {
            DepositWithDraw cop1 = new DepositWithDraw();
            DataTable dt = new DataTable();
            String sql = "select dwithdraw.* " +
                "From " + dwithdraw.table + " dwithdraw " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dwithdraw." + dwithdraw.pkField + " ='" + id + "' " +
                "Order By dwithdraw.withdraw_date ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        private void chkNull(DepositWithDraw p)
        {
            long chk = 0;
            decimal chk1 = 0;
            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.withdraw_code = p.withdraw_code == null ? "" : p.withdraw_code;
            p.withdraw_date = p.withdraw_date == null ? "" : p.withdraw_date;
            p.patient_hn = p.patient_hn == null ? "" : p.patient_hn;
            p.withdraw_name = p.withdraw_name == null ? "" : p.withdraw_name;
            p.visit_vn = p.visit_vn == null ? "" : p.visit_vn;
            p.remark = p.remark == null ? "" : p.remark;

            p.withdraw_amount = decimal.TryParse(p.withdraw_amount, out chk1) ? chk1.ToString() : "0";

            p.deposit_id = long.TryParse(p.deposit_id, out chk) ? chk.ToString() : "0";
            p.t_visit_id = long.TryParse(p.t_visit_id, out chk) ? chk.ToString() : "0";
            p.t_patient_id = long.TryParse(p.t_patient_id, out chk) ? chk.ToString() : "0";
        }
        public String insert(DepositWithDraw p, String userId)
        {
            String re = "";
            String sql = "";
            //DataTable dt = new DataTable();
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;
            chkNull(p);
            sql = "Insert Into " + dwithdraw.table + " set " +
                "" + dwithdraw.withdraw_code + "= '" + p.withdraw_code + "'" +
                "," + dwithdraw.active + "= '1'" +
                //"," + dwithdraw.withdraw_code + "= '" + p.withdraw_code + "'" +
                "," + dwithdraw.remark + "= '" + p.remark.Replace("'", "''") + "'" +
                "," + dwithdraw.date_create + "= now()" +
                "," + dwithdraw.date_modi + "= ''" +
                "," + dwithdraw.date_cancel + "= ''" +
                "," + dwithdraw.user_create + "= '" + userId + "@" + conn._IPAddress + "'" +
                "," + dwithdraw.user_modi + "= ''" +
                "," + dwithdraw.user_cancel + "= ''" +
                "," + dwithdraw.patient_hn + "= '" + p.patient_hn + "'" +
                "," + dwithdraw.visit_vn + "= '" + p.visit_vn + "'" +
                "," + dwithdraw.withdraw_amount + "= '" + p.withdraw_amount + "'" +
                "," + dwithdraw.t_visit_id + "= '" + p.t_visit_id + "'" +
                "," + dwithdraw.deposit_id + "= '" + p.deposit_id + "'" +
                "," + dwithdraw.t_patient_id + "= '" + p.t_patient_id + "'" +
                "";
            try
            {
                re = conn.ExecuteNonQuery(conn.conn, sql);
                //conn.Open();
                //    conn.comStore.ExecuteNonQuery();
                //    re = (String)conn.comStore.Parameters["row_no1"].Value;
                //    //string retunvalue = (string)sqlcomm.Parameters["@b"].Value;
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
            }
            finally
            {
                conn.conn.Close();
                //conn.comStore.Dispose();
            }
            return re;
        }
        public String update(DepositWithDraw p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            chkNull(p);
            sql = "Update " + dwithdraw.table + " Set " +
                "" + dwithdraw.withdraw_code + "= '" + p.withdraw_code + "'" +
                "," + dwithdraw.active + "= '1'" +
                "," + dwithdraw.withdraw_code + "= '" + p.withdraw_code + "'" +
                "," + dwithdraw.remark + "= '" + p.remark.Replace("'", "''") + "'" +
                "," + dwithdraw.date_modi + "= now()" +
                "," + dwithdraw.user_modi + "= '" + userId + "@" + conn._IPAddress + "'" +
                "," + dwithdraw.patient_hn + "= '" + p.patient_hn + "'" +
                "," + dwithdraw.visit_vn + "= '" + p.visit_vn + "'" +
                "," + dwithdraw.withdraw_amount + "= '" + p.withdraw_amount + "'" +
                "," + dwithdraw.t_visit_id + "= '" + p.t_visit_id + "'" +
                "," + dwithdraw.deposit_id + "= '" + p.deposit_id + "'" +
                "," + dwithdraw.t_patient_id + "= '" + p.t_patient_id + "'" +
                "Where " + dwithdraw.pkField + "='" + p.deposit_id + "'"
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
        public String insertDocScan(DepositWithDraw p, String userId)
        {
            String re = "";
            //chkNull(p);
            if (p.withdraw_id.Equals(""))
            {
                re = insert(p, userId);
            }
            else
            {
                re = update(p, userId);
            }

            return re;
        }
        public DepositWithDraw setAccCashTransfer(DataTable dt)
        {
            DepositWithDraw dgs1 = new DepositWithDraw();
            if (dt.Rows.Count > 0)
            {
                dgs1.withdraw_id = dt.Rows[0][dwithdraw.withdraw_id].ToString();
                dgs1.deposit_id = dt.Rows[0][dwithdraw.deposit_id].ToString();
                dgs1.withdraw_code = dt.Rows[0][dwithdraw.withdraw_code].ToString();
                dgs1.withdraw_date = dt.Rows[0][dwithdraw.withdraw_date].ToString();
                dgs1.active = dt.Rows[0][dwithdraw.active].ToString();
                dgs1.remark = dt.Rows[0][dwithdraw.remark].ToString();
                dgs1.date_create = dt.Rows[0][dwithdraw.date_create].ToString();
                dgs1.date_modi = dt.Rows[0][dwithdraw.date_modi].ToString();
                dgs1.date_cancel = dt.Rows[0][dwithdraw.date_cancel].ToString();
                dgs1.user_create = dt.Rows[0][dwithdraw.user_create].ToString();
                dgs1.user_modi = dt.Rows[0][dwithdraw.user_modi].ToString();
                dgs1.user_cancel = dt.Rows[0][dwithdraw.user_cancel].ToString();
                dgs1.patient_hn = dt.Rows[0][dwithdraw.patient_hn].ToString();
                dgs1.withdraw_name = dt.Rows[0][dwithdraw.withdraw_name].ToString();
                dgs1.withdraw_amount = dt.Rows[0][dwithdraw.withdraw_amount].ToString();
                dgs1.visit_vn = dt.Rows[0][dwithdraw.visit_vn].ToString();
                dgs1.t_visit_id = dt.Rows[0][dwithdraw.t_visit_id].ToString();
                dgs1.t_patient_id = dt.Rows[0][dwithdraw.t_patient_id].ToString();
            }
            else
            {
                setAccCashTransfer(dgs1);
            }
            return dgs1;
        }
        public DepositWithDraw setAccCashTransfer(DepositWithDraw dgs1)
        {
            dgs1.withdraw_id = "";
            dgs1.deposit_id = "";
            dgs1.withdraw_code = "";
            dgs1.withdraw_date = "";
            dgs1.active = "";
            dgs1.remark = "";
            dgs1.date_create = "";
            dgs1.date_modi = "";
            dgs1.date_cancel = "";
            dgs1.user_create = "";
            dgs1.user_modi = "";
            dgs1.user_cancel = "";
            dgs1.patient_hn = "";
            dgs1.withdraw_name = "";
            dgs1.withdraw_amount = "";
            dgs1.visit_vn = "";
            dgs1.t_visit_id = "";
            dgs1.t_patient_id = "";
            return dgs1;
        }
    }
}
