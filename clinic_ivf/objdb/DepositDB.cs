using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class DepositDB
    {
        ConnectDB conn;
        Deposit deposit;
        public List<Deposit> lFpf;
        public DepositDB(ConnectDB c)
        {
            this.conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lFpf = new List<Deposit>();
            deposit = new Deposit();

            deposit.deposit_id = "deposit_id";
            deposit.deposit_code = "deposit_code";
            deposit.deposit_date = "deposit_date";
            deposit.active = "active";
            deposit.remark = "remark";
            deposit.date_create = "date_create";
            deposit.date_modi = "date_modi";
            deposit.date_cancel = "date_cancel";
            deposit.user_create = "user_create";
            deposit.user_modi = "user_modi";
            deposit.user_cancel = "user_cancel";
            deposit.patient_hn = "patient_hn";
            deposit.deposit_name = "deposit_name";
            deposit.deposit_amount = "deposit_amount";
            deposit.remark = "remark";
            deposit.active = "active";
            deposit.status_deposit = "status_deposit";
            deposit.pck_id = "pck_id";
            deposit.amount = "amount";
            deposit.t_patient_id = "t_patient_id";

            deposit.table = "t_deposit";
            deposit.pkField = "deposit_id";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select deposit.* ,pck.PackageName " +
                "From " + deposit.table + " deposit " +
                "Left Join PackageHeader pck On deposit.pck_id = pck.PCKID " +
                " Where deposit." + deposit.active + " ='1' " +
                "Order By deposit.deposit_date ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByPttId(String pttid)
        {
            String wherehn = "";
            DataTable dt = new DataTable();
            if (pttid.Length > 0)
            {
                wherehn = " and t_patient_id = '" + pttid+"'";
            }
            String sql = "select deposit.*,pck.PackageName " +
                "From " + deposit.table + " deposit " +
                "Left Join PackageHeader pck On deposit.pck_id = pck.PCKID " +
                " Where deposit." + deposit.active + " ='1' " + wherehn +
                "Order By deposit.deposit_date ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public Deposit selectByPk(String id)
        {
            Deposit cop1 = new Deposit();
            DataTable dt = new DataTable();
            String sql = "select deposit.* " +
                "From " + deposit.table + " deposit " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where deposit." + deposit.pkField + " ='" + id + "' " +
                "Order By deposit.deposit_date ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setAccCashTransfer(dt);
            return cop1;
        }
        public DataTable selectByPk1(String id)
        {
            Deposit cop1 = new Deposit();
            DataTable dt = new DataTable();
            String sql = "select deposit.* " +
                "From " + deposit.table + " deposit " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where deposit." + deposit.pkField + " ='" + id + "' " +
                "Order By deposit.deposit_date ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public void getlActCashTransfer()
        {
            //lDept = new List<Position>();
            lFpf.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                Deposit itm1 = new Deposit();
                itm1.deposit_id = row[deposit.deposit_id].ToString();
                itm1.patient_hn = row[deposit.patient_hn].ToString();
                itm1.deposit_amount = row[deposit.deposit_amount].ToString();
                itm1.deposit_name = row[deposit.deposit_name].ToString();

                lFpf.Add(itm1);
            }
        }
        public String updateAmount(String depositid, String amount)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Update " + deposit.table + " Set " +
                " " + deposit.amount + " = " + deposit.amount + " -'" + amount + "' " +
                "Where " + deposit.deposit_id + "='" + depositid + "'";
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
        private void chkNull(Deposit p)
        {
            long chk = 0;
            decimal chk1 = 0;
            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.deposit_code = p.deposit_code == null ? "" : p.deposit_code;
            p.deposit_date = p.deposit_date == null ? "" : p.deposit_date;
            p.patient_hn = p.patient_hn == null ? "" : p.patient_hn;
            p.deposit_name = p.deposit_name == null ? "" : p.deposit_name;
            p.status_deposit = p.status_deposit == null ? "" : p.status_deposit;
            p.remark = p.remark == null ? "" : p.remark;

            p.deposit_amount = decimal.TryParse(p.deposit_amount, out chk1) ? chk1.ToString() : "0";
            p.pck_id = long.TryParse(p.pck_id, out chk) ? chk.ToString() : "0";
            p.t_patient_id = long.TryParse(p.t_patient_id, out chk) ? chk.ToString() : "0";
        }
        public String insert(Deposit p, String userId)
        {
            String re = "";
            String sql = "";
            //DataTable dt = new DataTable();
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;
            chkNull(p);
            sql = "Insert Into " + deposit.table + " set " +
                "" + deposit.deposit_code + "= '" + p.deposit_code + "'" +
                "," + deposit.active + "= '1'" +
                "," + deposit.deposit_date + "= '" + p.deposit_date + "'" +
                "," + deposit.remark + "= '" + p.remark.Replace("'", "''") + "'" +
                "," + deposit.date_create + "= now()" +
                "," + deposit.date_modi + "= ''" +
                "," + deposit.date_cancel + "= ''" +
                "," + deposit.user_create + "= '" + userId + "@" + conn._IPAddress + "'" +
                "," + deposit.user_modi + "= ''" +
                "," + deposit.user_cancel + "= ''" +
                "," + deposit.patient_hn + "= '" + p.patient_hn + "'" +
                "," + deposit.deposit_name + "= '" + p.deposit_name + "'" +
                "," + deposit.deposit_amount + "= '" + p.deposit_amount + "'" +
                "," + deposit.status_deposit + "= '" + p.status_deposit + "'" +
                "," + deposit.pck_id + "= '" + p.pck_id + "'" +
                "," + deposit.amount + "= '" + p.deposit_amount + "'" +
                "," + deposit.t_patient_id + "= '" + p.t_patient_id + "'" +
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
        public String update(Deposit p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            chkNull(p);
            sql = "Update " + deposit.table + " Set " +
                "" + deposit.deposit_code + "= '" + p.deposit_code + "'" +
                "," + deposit.active + "= '1'" +
                "," + deposit.deposit_date + "= '" + p.deposit_date + "'" +
                "," + deposit.remark + "= '" + p.remark.Replace("'", "''") + "'" +
                //"," + deposit.date_create + "= now()" +
                "," + deposit.date_modi + "= now()" +
                "," + deposit.date_cancel + "= ''" +
                "," + deposit.user_create + "= '" + userId + "@" + conn._IPAddress + "'" +
                "," + deposit.user_modi + "= ''" +
                "," + deposit.user_cancel + "= ''" +
                "," + deposit.patient_hn + "= '" + p.patient_hn + "'" +
                "," + deposit.deposit_name + "= '" + p.deposit_name + "'" +
                "," + deposit.deposit_amount + "= '" + p.deposit_amount + "'" +
                "," + deposit.status_deposit + "= '" + p.status_deposit + "'" +
                "," + deposit.pck_id + "= '" + p.pck_id + "'" +
                "," + deposit.t_patient_id + "= '" + p.t_patient_id + "'" +
                "Where " + deposit.pkField + "='" + p.deposit_id + "'"
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
        public String insertDocScan(Deposit p, String userId)
        {
            String re = "";
            //chkNull(p);
            if (p.deposit_id.Equals(""))
            {
                re = insert(p, userId);
            }
            else
            {
                re = update(p, userId);
            }

            return re;
        }

        public Deposit setAccCashTransfer(DataTable dt)
        {
            Deposit dgs1 = new Deposit();
            if (dt.Rows.Count > 0)
            {
                dgs1.deposit_id = dt.Rows[0][deposit.deposit_id].ToString();
                dgs1.deposit_code = dt.Rows[0][deposit.deposit_code].ToString();
                dgs1.deposit_date = dt.Rows[0][deposit.deposit_date].ToString();
                dgs1.active = dt.Rows[0][deposit.active].ToString();
                dgs1.remark = dt.Rows[0][deposit.remark].ToString();
                dgs1.date_create = dt.Rows[0][deposit.date_create].ToString();
                dgs1.date_modi = dt.Rows[0][deposit.date_modi].ToString();
                dgs1.date_cancel = dt.Rows[0][deposit.date_cancel].ToString();
                dgs1.user_create = dt.Rows[0][deposit.user_create].ToString();
                dgs1.user_modi = dt.Rows[0][deposit.user_modi].ToString();
                dgs1.user_cancel = dt.Rows[0][deposit.user_cancel].ToString();
                dgs1.patient_hn = dt.Rows[0][deposit.patient_hn].ToString();
                dgs1.deposit_name = dt.Rows[0][deposit.deposit_name].ToString();
                dgs1.deposit_amount = dt.Rows[0][deposit.deposit_amount].ToString();
                dgs1.status_deposit = dt.Rows[0][deposit.status_deposit].ToString();
                dgs1.pck_id = dt.Rows[0][deposit.pck_id].ToString();
                dgs1.amount = dt.Rows[0][deposit.amount].ToString();
                dgs1.t_patient_id = dt.Rows[0][deposit.t_patient_id].ToString();
            }
            else
            {
                setAccCashTransfer(dgs1);
            }
            return dgs1;
        }
        public Deposit setAccCashTransfer(Deposit dgs1)
        {
            dgs1.deposit_id = "";
            dgs1.deposit_code = "";
            dgs1.deposit_date = "";
            dgs1.active = "";
            dgs1.remark = "";
            dgs1.date_create = "";
            dgs1.date_modi = "";
            dgs1.date_cancel = "";
            dgs1.user_create = "";
            dgs1.user_modi = "";
            dgs1.user_cancel = "";
            dgs1.patient_hn = "";
            dgs1.deposit_name = "";
            dgs1.deposit_amount = "";
            dgs1.status_deposit = "";
            dgs1.pck_id = "";
            dgs1.amount = "";
            dgs1.t_patient_id = "";
            return dgs1;
        }
    }
}
