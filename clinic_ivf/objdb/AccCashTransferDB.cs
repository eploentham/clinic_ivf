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
    public class AccCashTransferDB
    {
        public AccCashTransfer act;
        ConnectDB conn;
        public List<AccCashTransfer> lFpf;

        public AccCashTransferDB(ConnectDB c)
        {
            this.conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lFpf = new List<AccCashTransfer>();
            act = new AccCashTransfer();
            act.cash_transfer_id = "cash_transfer_id";
            act.cash_transfer_code = "cash_transfer_code";
            act.cash_transfer_name = "cash_transfer_name";
            act.active = "active";
            act.remark = "remark";
            act.date_create = "date_create";
            act.date_modi = "date_modi";
            act.date_cancel = "date_cancel";
            act.user_create = "user_create";
            act.user_modi = "user_modi";
            act.user_cancel = "user_cancel";
            act.receipt_print = "receipt_print";

            act.table = "b_acc_cash_transfer";
            act.pkField = "cash_transfer_id";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select act.* " +
                "From " + act.table + " act " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                " Where act." + act.active + " ='1' " +
                "Order By act.cash_transfer_code ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public AccCashTransfer selectByPk(String id)
        {
            AccCashTransfer cop1 = new AccCashTransfer();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + act.table + " act " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + act.pkField + " ='" + id + "' " +
                "Order By closeday_date ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setAccCashTransfer(dt);
            return cop1;
        }
        public DataTable selectByPk1(String id)
        {
            AccCashTransfer cop1 = new AccCashTransfer();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + act.table + " act " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + act.pkField + " ='" + id + "' " +
                "Order By closeday_date ";
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
                AccCashTransfer itm1 = new AccCashTransfer();
                itm1.cash_transfer_id = row[act.cash_transfer_id].ToString();
                itm1.cash_transfer_code = row[act.cash_transfer_code].ToString();
                itm1.cash_transfer_name = row[act.cash_transfer_name].ToString();
                itm1.receipt_print = row[act.receipt_print].ToString();

                lFpf.Add(itm1);
            }
        }
        public C1ComboBox setCboAccCashTransfer(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectC1();
            //String aaa = "";
            if (lFpf.Count <= 0) getlActCashTransfer();
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (AccCashTransfer row in lFpf)
            {
                item = new ComboBoxItem();
                item.Value = row.cash_transfer_id;
                item.Text = row.cash_transfer_name;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    //c.SelectedItem = item.Value;
                    c.SelectedText = item.Text;
                    c.SelectedIndex = i + 1;
                }
                i++;
            }
            return c;
        }
        public AccCashTransfer setAccCashTransfer(DataTable dt)
        {
            AccCashTransfer dgs1 = new AccCashTransfer();
            if (dt.Rows.Count > 0)
            {
                dgs1.cash_transfer_id = dt.Rows[0][act.cash_transfer_id].ToString();
                dgs1.cash_transfer_code = dt.Rows[0][act.cash_transfer_code].ToString();
                dgs1.cash_transfer_name = dt.Rows[0][act.cash_transfer_name].ToString();
                dgs1.receipt_print = dt.Rows[0][act.receipt_print].ToString();
                dgs1.active = dt.Rows[0][act.active].ToString();
                dgs1.remark = dt.Rows[0][act.remark].ToString();
                dgs1.date_create = dt.Rows[0][act.date_create].ToString();
                dgs1.date_modi = dt.Rows[0][act.date_modi].ToString();
                dgs1.date_cancel = dt.Rows[0][act.date_cancel].ToString();
                dgs1.user_create = dt.Rows[0][act.user_create].ToString();
                dgs1.user_modi = dt.Rows[0][act.user_modi].ToString();
                dgs1.user_cancel = dt.Rows[0][act.user_cancel].ToString();
            }
            else
            {
                setAccCashTransfer(dgs1);
            }
            return dgs1;
        }
        public AccCashTransfer setAccCashTransfer(AccCashTransfer dgs1)
        {
            dgs1.cash_transfer_id = "";
            dgs1.cash_transfer_code = "";
            dgs1.cash_transfer_name = "";
            dgs1.active = "";
            dgs1.remark = "";
            dgs1.date_create = "";
            dgs1.date_modi = "";
            dgs1.date_cancel = "";
            dgs1.user_create = "";
            dgs1.user_modi = "";
            dgs1.user_cancel = "";
            dgs1.receipt_print = "";
            return dgs1;
        }
    }
}
