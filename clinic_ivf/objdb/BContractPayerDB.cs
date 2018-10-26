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
    public class BContractPayerDB
    {
        public object1.BContractPayer crp;
        ConnectDB conn;

        public List<object1.BContractPayer> lCrp;

        public BContractPayerDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lCrp = new List<object1.BContractPayer>();
            crp = new object1.BContractPayer();
            crp.b_contract_payer_id = "b_contract_payer_id";
            crp.contract_payer_description = "contract_payer_description";


            crp.pkField = "b_contract_payer_id";
            crp.table = "b_contract_plans";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select sex.*  " +
                "From " + crp.table + " sex " +
                " " +
                "Where sex." + crp.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select sex.* " +
                "From " + crp.table + " sex " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where sex." + crp.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public void getlSex()
        {
            //lDept = new List<Position>();
            lCrp.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                object1.BContractPayer itm1 = new object1.BContractPayer();
                itm1.b_contract_payer_id = row[crp.b_contract_payer_id].ToString();
                itm1.contract_payer_description = row[crp.contract_payer_description].ToString();

                lCrp.Add(itm1);
            }
        }
        public String getList(String id)
        {
            String re = "";
            foreach (object1.BContractPayer sex in lCrp)
            {
                if (sex.b_contract_payer_id.Equals(id))
                {
                    re = sex.contract_payer_description;
                    break;
                }
            }
            return re;
        }
        public C1ComboBox setCboAgent(C1ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectAll();
            //String aaa = "";
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            foreach (DataRow row in dt.Rows)
            {
                item = new ComboBoxItem();
                item.Text = row[crp.contract_payer_description].ToString();
                item.Value = row[crp.b_contract_payer_id].ToString();

                c.Items.Add(item);
            }
            return c;
        }
    }
}
