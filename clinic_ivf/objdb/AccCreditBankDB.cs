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
    public class AccCreditBankDB
    {
        public AccCreditBank act;
        ConnectDB conn;
        public List<AccCreditBank> lFpf;
        public AccCreditBankDB(ConnectDB c)
        {
            this.conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lFpf = new List<AccCreditBank>();
            act = new AccCreditBank();

            act.credit_bank_id = "credit_bank_id";
            act.credit_bank_name = "credit_bank_name";
            act.charge = "charge";
            act.active = "active";
            act.remark = "remark";
            act.date_create = "date_create";
            act.date_modi = "date_modi";
            act.date_cancel = "date_cancel";
            act.user_create = "user_create";
            act.user_modi = "user_modi";
            act.user_cancel = "user_cancel";

            act.table = "b_acc_credit_bank";
            act.pkField = "credit_bank_id";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select act.* " +
                "From " + act.table + " act " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                " Where act." + act.active + " ='1' " +
                "Order By act.credit_bank_name ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public AccCreditBank selectByPk(String id)
        {
            AccCreditBank cop1 = new AccCreditBank();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + act.table + " act " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + act.pkField + " ='" + id + "' " +
                "Order By credit_bank_id ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setAccCashTransfer(dt);
            return cop1;
        }
        public DataTable selectByPk1(String id)
        {
            AccCreditBank cop1 = new AccCreditBank();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + act.table + " act " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dsc." + act.pkField + " ='" + id + "' " +
                "Order By credit_bank_id ";
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
                AccCreditBank itm1 = new AccCreditBank();
                itm1.credit_bank_id = row[act.credit_bank_id].ToString();
                itm1.credit_bank_name = row[act.credit_bank_name].ToString();
                itm1.charge = row[act.charge].ToString();

                lFpf.Add(itm1);
            }
        }
        public C1ComboBox setCboAccCreditBank(C1ComboBox c, String selected)
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
            foreach (AccCreditBank row in lFpf)
            {
                item = new ComboBoxItem();
                item.Value = row.credit_bank_id;
                item.Text = row.credit_bank_name;
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
        public AccCreditBank setAccCashTransfer(DataTable dt)
        {
            AccCreditBank dgs1 = new AccCreditBank();
            if (dt.Rows.Count > 0)
            {
                dgs1.credit_bank_id = dt.Rows[0][act.credit_bank_id].ToString();
                dgs1.credit_bank_name = dt.Rows[0][act.credit_bank_name].ToString();
                dgs1.charge = dt.Rows[0][act.charge].ToString();
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
        public AccCreditBank setAccCashTransfer(AccCreditBank dgs1)
        {
            dgs1.credit_bank_id = "";
            dgs1.credit_bank_name = "";
            dgs1.charge = "";
            dgs1.active = "";
            dgs1.remark = "";
            dgs1.date_create = "";
            dgs1.date_modi = "";
            dgs1.date_cancel = "";
            dgs1.user_create = "";
            dgs1.user_modi = "";
            dgs1.user_cancel = "";
            return dgs1;
        }
    }
}
