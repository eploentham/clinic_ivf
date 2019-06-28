using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class ClosedayDB
    {
        public Closeday cld;
        ConnectDB conn;

        public ClosedayDB(ConnectDB c)
        {
            this.conn = c;
            initConfig();
        }
        private void initConfig()
        {
            cld = new Closeday();

            cld.closeday_id = "closeday_id";
            cld.closeday_date = "closeday_date";
            cld.cnt_patient = "cnt_patient";
            cld.amt_cash = "amt_cash";
            cld.amt_credit_card = "amt_credit_card";
            cld.amount = "amount";
            cld.expense_1 = "expense_1";
            cld.expense_2 = "expense_2";
            cld.active = "active";
            cld.remark = "remark";
            cld.date_create = "date_create";
            cld.date_modi = "date_modi";
            cld.date_cancel = "date_cancel";
            cld.user_create = "user_create";
            cld.user_modi = "user_modi";
            cld.user_cancel = "user_cancel";
            cld.expense_3 = "expense_3";
            cld.expense_4 = "expense_4";
            cld.expense_5 = "expense_5";
            cld.total_cash = "total_cash";
            cld.deposit = "deposit";

            cld.table = "t_closeday";
            cld.pkField = "closeday_id";
        }
        
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + cld.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                " Where dsc." + cld.active + " ='1' " +
                "Order By closeday_date ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        
        public Closeday selectByPk(String id)
        {
            Closeday cop1 = new Closeday();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + cld.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + cld.pkField + " ='" + id + "' " +
                "Order By closeday_date ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setCloseday(dt);
            return cop1;
        }
        public DataTable selectByPk1(String id)
        {
            Closeday cop1 = new Closeday();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + cld.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + cld.pkField + " ='" + id + "' " +
                "Order By closeday_date ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        
        private void chkNull(Closeday p)
        {
            decimal chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;                        

            p.closeday_date = p.closeday_date == null ? "" : p.closeday_date;            

            p.expense_1 = decimal.TryParse(p.expense_1, out chk) ? chk.ToString() : "0";
            p.expense_2 = decimal.TryParse(p.expense_2, out chk) ? chk.ToString() : "0";
            p.expense_4 = decimal.TryParse(p.expense_4, out chk) ? chk.ToString() : "0";
            p.expense_3 = decimal.TryParse(p.expense_3, out chk) ? chk.ToString() : "0";
            p.expense_5 = decimal.TryParse(p.expense_5, out chk) ? chk.ToString() : "0";
            p.amount = decimal.TryParse(p.amount, out chk) ? chk.ToString() : "0";
            p.amt_credit_card = decimal.TryParse(p.amt_credit_card, out chk) ? chk.ToString() : "0";
            p.amt_cash = decimal.TryParse(p.amt_cash, out chk) ? chk.ToString() : "0";
            p.cnt_patient = decimal.TryParse(p.cnt_patient, out chk) ? chk.ToString() : "0";
            p.deposit = decimal.TryParse(p.deposit, out chk) ? chk.ToString() : "0";
            p.total_cash = decimal.TryParse(p.total_cash, out chk) ? chk.ToString() : "0";
        }
        public String insert(Closeday p, String userId)
        {
            String re = "";
            String sql = "";
            //DataTable dt = new DataTable();
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;
            chkNull(p);
            sql = "Insert Into " + cld.table + " set " +
                "" + cld.closeday_date + "= '" + p.closeday_date + "'" +
                "," + cld.active + "= '" + p.active + "'" +
                "," + cld.cnt_patient + "= '" + p.cnt_patient + "'" +
                "," + cld.amt_cash + "= '" + p.amt_cash + "'" +
                "," + cld.amt_credit_card + "= '" + p.amt_credit_card + "'" +
                "," + cld.amount + "= '" + p.amount + "'" +
                "," + cld.expense_1 + "= '" + p.expense_1 + "'" +
                "," + cld.expense_2 + "= '" + p.expense_2 + "'" +
                "," + cld.remark + "= '" + p.remark + "'" +
                "," + cld.date_create + "= now()" +
                "," + cld.date_modi + "= ''" +
                "," + cld.date_cancel + "= ''" +
                "," + cld.user_create + "= '" + userId + "'" +
                "," + cld.user_modi + "= ''" +
                "," + cld.user_cancel + "= ''" +
                "," + cld.expense_3 + "= '" + p.expense_3 + "'" +
                "," + cld.expense_4 + "= '" + p.expense_4 + "'" +
                "," + cld.expense_5 + "= '" + p.expense_5 + "'" +
                "," + cld.total_cash + "= '" + p.total_cash + "'" +
                "," + cld.deposit + "= '" + p.deposit + "'" +
                "";
            try
            {
                re = conn.ExecuteNonQuery(conn.conn, sql);                
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
        public String update(Closeday p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            chkNull(p);
            sql = "Update " + cld.table + " Set " +
                " " + cld.closeday_date + " = '" + p.closeday_date + "'" +
                "," + cld.cnt_patient + " = '" + p.cnt_patient + "'" +
                "," + cld.amt_cash + " = '" + p.amt_cash + "'" +
                "," + cld.amt_credit_card + " = '" + p.amt_credit_card + "'" +
                "," + cld.amount + " = '" + p.amount + "'" +
                "," + cld.expense_1 + " = '" + p.expense_1 + "'" +
                "," + cld.expense_2 + " = '" + p.expense_2 + "'" +
                "," + cld.remark + " = '" + p.remark + "'" +
                "," + cld.date_modi + " = now()" +
                "," + cld.user_modi + " = '" + userId + "'" +
                "," + cld.expense_3 + " = '" + p.expense_3 + "'" +
                "," + cld.expense_4 + " = '" + p.expense_4 + "'" +
                "," + cld.expense_5 + " = '" + p.expense_5 + "'" +
                "," + cld.total_cash + " = '" + p.total_cash + "'" +
                "," + cld.deposit + " = '" + p.deposit + "'" +
                "Where " + cld.pkField + "='" + p.closeday_id + "'"
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
        public String insertCloseday(Closeday p, String userId)
        {
            String re = "";

            if (p.closeday_id.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
            }

            return re;
        }
        public String updateImagepath(String amt_credit_card, String id)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            //chkNull(p);
            sql = "Update " + cld.table + " Set " +
                " " + cld.amt_credit_card + " = '" + amt_credit_card + "'" +
                "Where " + cld.pkField + "='" + id + "'"
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
        public String voidCloseday(String id, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Update " + cld.table + " Set " +
                " " + cld.active + " = '3'" +
                "," + cld.date_cancel + " = now()" +
                "," + cld.user_cancel + " = '" + userId + "'" +
                "Where " + cld.pkField + "='" + id + "'"
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
        public Closeday setCloseday(DataTable dt)
        {
            Closeday dgs1 = new Closeday();
            if (dt.Rows.Count > 0)
            {
                dgs1.closeday_id = dt.Rows[0][cld.closeday_id].ToString();
                dgs1.closeday_date = dt.Rows[0][cld.closeday_date].ToString();
                dgs1.cnt_patient = dt.Rows[0][cld.cnt_patient].ToString();
                dgs1.amt_cash = dt.Rows[0][cld.amt_cash].ToString();
                dgs1.amt_credit_card = dt.Rows[0][cld.amt_credit_card].ToString();
                dgs1.amount = dt.Rows[0][cld.amount].ToString();
                dgs1.expense_1 = dt.Rows[0][cld.expense_1].ToString();
                dgs1.expense_2 = dt.Rows[0][cld.expense_2].ToString();
                dgs1.active = dt.Rows[0][cld.active].ToString();
                dgs1.remark = dt.Rows[0][cld.remark].ToString();
                dgs1.date_create = dt.Rows[0][cld.date_create].ToString();
                dgs1.date_modi = dt.Rows[0][cld.date_modi].ToString();
                dgs1.date_cancel = dt.Rows[0][cld.date_cancel].ToString();
                dgs1.user_create = dt.Rows[0][cld.user_create].ToString();
                dgs1.user_modi = dt.Rows[0][cld.user_modi].ToString();
                dgs1.user_cancel = dt.Rows[0][cld.user_cancel].ToString();
                dgs1.expense_3 = dt.Rows[0][cld.expense_3].ToString();
                dgs1.expense_4 = dt.Rows[0][cld.expense_4].ToString();
                dgs1.expense_5 = dt.Rows[0][cld.expense_5].ToString();
                dgs1.total_cash = dt.Rows[0][cld.total_cash].ToString();
                dgs1.deposit = dt.Rows[0][cld.deposit].ToString();
            }
            else
            {
                setDocGroupScan(dgs1);
            }
            return dgs1;
        }
        public Closeday setDocGroupScan(Closeday dgs1)
        {
            dgs1.closeday_id = "";
            dgs1.closeday_date = "";
            dgs1.cnt_patient = "";
            dgs1.amt_cash = "";
            dgs1.amt_credit_card = "";
            dgs1.amount = "";
            dgs1.expense_1 = "";
            dgs1.expense_2 = "";
            dgs1.active = "";
            dgs1.remark = "";
            dgs1.date_create = "";
            dgs1.date_modi = "";
            dgs1.date_cancel = "";
            dgs1.user_create = "";
            dgs1.user_modi = "";
            dgs1.user_cancel = "";
            dgs1.expense_3 = "";
            dgs1.expense_4 = "";
            dgs1.expense_5 = "";
            dgs1.total_cash = "";
            dgs1.deposit = "";
            return dgs1;
        }
    }
}
