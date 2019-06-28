using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class ClosedayDetailDB
    {
        public ClosedayDetail cldd;
        ConnectDB conn;

        public ClosedayDetailDB(ConnectDB c)
        {
            this.conn = c;
            initConfig();
        }
        private void initConfig()
        {
            cldd = new ClosedayDetail();

            cldd.closeday_detail_id = "closeday_detail_id";
            cldd.closeday_id = "closeday_id";
            cldd.bill_no = "bill_no";
            cldd.bill_date = "bill_date";
            cldd.patient_hn = "patient_hn";
            cldd.patient_name = "patient_name";
            cldd.amt_package = "amt_package";
            cldd.amt_medicine = "amt_medicine";
            cldd.active = "active";
            cldd.remark = "remark";
            cldd.date_create = "date_create";
            cldd.date_modi = "date_modi";
            cldd.date_cancel = "date_cancel";
            cldd.user_create = "user_create";
            cldd.user_modi = "user_modi";
            cldd.user_cancel = "user_cancel";
            cldd.amt_doctor_fee = "amt_doctor_fee";
            cldd.amt_lab_1 = "amt_lab_1";
            cldd.amt_lab_2 = "amt_lab_2";
            cldd.amt_nurse_fee = "amt_nurse_fee";
            cldd.amt_treatments = "amt_treatments";
            cldd.discount = "discount";
            cldd.amt_other = "amt_other";
            cldd.amount = "amount";
            cldd.bill_id = "bill_id";

            cldd.table = "t_closeday_detail";
            cldd.pkField = "closeday_detail_id";
        }

        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + cldd.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                " Where dsc." + cldd.active + " ='1' " +
                "Order By closeday_detail_id ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }

        public ClosedayDetail selectByPk(String id)
        {
            ClosedayDetail cop1 = new ClosedayDetail();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + cldd.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + cldd.pkField + " ='" + id + "' " +
                "Order By closeday_detail_id ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setClosedayDetail(dt);
            return cop1;
        }
        public DataTable selectByPk1(String id)
        {
            ClosedayDetail cop1 = new ClosedayDetail();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + cldd.table + " dsc " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + cldd.pkField + " ='" + id + "' " +
                "Order By closeday_detail_id ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }

        private void chkNull(ClosedayDetail p)
        {
            decimal chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.patient_name = p.patient_name == null ? "" : p.patient_name;
            p.patient_hn = p.patient_hn == null ? "" : p.patient_hn;
            p.bill_no = p.bill_no == null ? "" : p.bill_no;
            p.bill_date = p.bill_date == null ? "" : p.bill_date;

            p.closeday_id = p.closeday_id == null ? "0" : p.closeday_id;
            p.bill_id = p.bill_id == null ? "0" : p.bill_id;

            p.amt_package = decimal.TryParse(p.amt_package, out chk) ? chk.ToString() : "0";
            p.amt_medicine = decimal.TryParse(p.amt_medicine, out chk) ? chk.ToString() : "0";
            p.amt_lab_1 = decimal.TryParse(p.amt_lab_1, out chk) ? chk.ToString() : "0";
            p.amt_doctor_fee = decimal.TryParse(p.amt_doctor_fee, out chk) ? chk.ToString() : "0";
            p.amt_lab_2 = decimal.TryParse(p.amt_lab_2, out chk) ? chk.ToString() : "0";
            p.amt_nurse_fee = decimal.TryParse(p.amt_nurse_fee, out chk) ? chk.ToString() : "0";
            p.amt_treatments = decimal.TryParse(p.amt_treatments, out chk) ? chk.ToString() : "0";
            p.discount = decimal.TryParse(p.discount, out chk) ? chk.ToString() : "0";
            p.amt_other = decimal.TryParse(p.amt_other, out chk) ? chk.ToString() : "0";
            p.amount = decimal.TryParse(p.amount, out chk) ? chk.ToString() : "0";
        }
        public String insert(ClosedayDetail p, String userId)
        {
            String re = "";
            String sql = "";
            //DataTable dt = new DataTable();
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;
            chkNull(p);
            sql = "Insert Into " + cldd.table + " set " +
                "" + cldd.closeday_id + "= '" + p.closeday_id + "'" +
                "," + cldd.active + "= '" + p.active + "'" +
                "," + cldd.bill_no + "= '" + p.bill_no + "'" +
                "," + cldd.bill_date + "= '" + p.bill_date + "'" +
                "," + cldd.patient_hn + "= '" + p.patient_hn + "'" +
                "," + cldd.patient_name + "= '" + p.patient_name + "'" +
                "," + cldd.amt_package + "= '" + p.amt_package + "'" +
                "," + cldd.amt_medicine + "= '" + p.amt_medicine + "'" +
                "," + cldd.remark + "= '" + p.remark + "'" +
                "," + cldd.date_create + "= now()" +
                "," + cldd.date_modi + "= ''" +
                "," + cldd.date_cancel + "= ''" +
                "," + cldd.user_create + "= '" + userId + "'" +
                "," + cldd.user_modi + "= ''" +
                "," + cldd.user_cancel + "= ''" +
                "," + cldd.amt_doctor_fee + "= '" + p.amt_doctor_fee + "'" +
                "," + cldd.amt_lab_1 + "= '" + p.amt_lab_1 + "'" +
                "," + cldd.amt_lab_2 + "= '" + p.amt_lab_2 + "'" +
                "," + cldd.amt_nurse_fee + "= '" + p.amt_nurse_fee + "'" +
                "," + cldd.amt_treatments + "= '" + p.amt_treatments + "'" +
                "," + cldd.discount + "= '" + p.discount + "'" +
                "," + cldd.amt_other + "= '" + p.amt_other + "'" +
                "," + cldd.amount + "= '" + p.amount + "'" +
                "," + cldd.bill_id + "= '" + p.bill_id + "'" +
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
        public String update(ClosedayDetail p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            chkNull(p);
            sql = "Update " + cldd.table + " Set " +
                " " + cldd.closeday_id + " = '" + p.closeday_id + "'" +
                "," + cldd.bill_no + " = '" + p.bill_no + "'" +
                "," + cldd.bill_date + " = '" + p.bill_date + "'" +
                "," + cldd.patient_hn + " = '" + p.patient_hn + "'" +
                "," + cldd.patient_name + " = '" + p.patient_name + "'" +
                "," + cldd.amt_package + " = '" + p.amt_package + "'" +
                "," + cldd.amt_medicine + " = '" + p.amt_medicine + "'" +
                "," + cldd.remark + " = '" + p.remark + "'" +
                "," + cldd.date_modi + " = now()" +
                "," + cldd.user_modi + " = '" + userId + "'" +
                "," + cldd.amt_doctor_fee + " = '" + p.amt_doctor_fee + "'" +
                "," + cldd.amt_lab_1 + " = '" + p.amt_lab_1 + "'" +
                "," + cldd.amt_lab_2 + " = '" + p.amt_lab_2 + "'" +
                "," + cldd.amt_nurse_fee + " = '" + p.amt_nurse_fee + "'" +
                "," + cldd.amt_treatments + " = '" + p.amt_treatments + "'" +
                "," + cldd.discount + " = '" + p.discount + "'" +
                "," + cldd.amt_other + " = '" + p.amt_other + "'" +
                "," + cldd.amount + " = '" + p.amount + "'" +
                "," + cldd.bill_id + " = '" + p.bill_id + "'" +
                "Where " + cldd.pkField + "='" + p.closeday_detail_id + "'"
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
        public String insertClosedayDetail(ClosedayDetail p, String userId)
        {
            String re = "";

            if (p.closeday_detail_id.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
            }

            return re;
        }
        public String updateImagepath(String patient_hn, String id)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            //chkNull(p);
            sql = "Update " + cldd.table + " Set " +
                " " + cldd.closeday_detail_id + " = '" + patient_hn + "'" +
                "Where " + cldd.pkField + "='" + id + "'"
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

            sql = "Update " + cldd.table + " Set " +
                " " + cldd.active + " = '3'" +
                "," + cldd.date_cancel + " = now()" +
                "," + cldd.user_cancel + " = '" + userId + "'" +
                "Where " + cldd.pkField + "='" + id + "'"
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
        public ClosedayDetail setClosedayDetail(DataTable dt)
        {
            ClosedayDetail dgs1 = new ClosedayDetail();
            if (dt.Rows.Count > 0)
            {
                dgs1.closeday_detail_id = dt.Rows[0][cldd.closeday_detail_id].ToString();
                dgs1.closeday_id = dt.Rows[0][cldd.closeday_id].ToString();
                dgs1.bill_no = dt.Rows[0][cldd.bill_no].ToString();
                dgs1.bill_date = dt.Rows[0][cldd.bill_date].ToString();
                dgs1.patient_hn = dt.Rows[0][cldd.patient_hn].ToString();
                dgs1.patient_name = dt.Rows[0][cldd.patient_name].ToString();
                dgs1.amt_package = dt.Rows[0][cldd.amt_package].ToString();
                dgs1.amt_medicine = dt.Rows[0][cldd.amt_medicine].ToString();
                dgs1.active = dt.Rows[0][cldd.active].ToString();
                dgs1.remark = dt.Rows[0][cldd.remark].ToString();
                dgs1.date_create = dt.Rows[0][cldd.date_create].ToString();
                dgs1.date_modi = dt.Rows[0][cldd.date_modi].ToString();
                dgs1.date_cancel = dt.Rows[0][cldd.date_cancel].ToString();
                dgs1.user_create = dt.Rows[0][cldd.user_create].ToString();
                dgs1.user_modi = dt.Rows[0][cldd.user_modi].ToString();
                dgs1.user_cancel = dt.Rows[0][cldd.user_cancel].ToString();
                dgs1.amt_doctor_fee = dt.Rows[0][cldd.amt_doctor_fee].ToString();
                dgs1.amt_lab_1 = dt.Rows[0][cldd.amt_lab_1].ToString();
                dgs1.amt_lab_2 = dt.Rows[0][cldd.amt_lab_2].ToString();
                dgs1.amt_nurse_fee = dt.Rows[0][cldd.amt_nurse_fee].ToString();
                dgs1.amt_treatments = dt.Rows[0][cldd.amt_treatments].ToString();
                dgs1.discount = dt.Rows[0][cldd.discount].ToString();
                dgs1.amt_other = dt.Rows[0][cldd.amt_other].ToString();
                dgs1.amount = dt.Rows[0][cldd.amount].ToString();
                dgs1.bill_id = dt.Rows[0][cldd.bill_id].ToString();
            }
            else
            {
                setDocGroupScan(dgs1);
            }
            return dgs1;
        }
        public ClosedayDetail setDocGroupScan(ClosedayDetail dgs1)
        {
            dgs1.closeday_detail_id = "";
            dgs1.closeday_id = "";
            dgs1.bill_no = "";
            dgs1.bill_date = "";
            dgs1.patient_hn = "";
            dgs1.patient_name = "";
            dgs1.amt_package = "";
            dgs1.amt_medicine = "";
            dgs1.active = "";
            dgs1.remark = "";
            dgs1.date_create = "";
            dgs1.date_modi = "";
            dgs1.date_cancel = "";
            dgs1.user_create = "";
            dgs1.user_modi = "";
            dgs1.user_cancel = "";
            dgs1.amt_doctor_fee = "";
            dgs1.amt_lab_1 = "";
            dgs1.amt_lab_2 = "";
            dgs1.amt_nurse_fee = "";
            dgs1.amt_treatments = "";
            dgs1.discount = "";
            dgs1.amt_other = "";
            dgs1.amount = "";
            dgs1.bill_id = "";
            return dgs1;
        }
    }
}
