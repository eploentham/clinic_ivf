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
    public class BContractPlansDB
    {
        public BContractPlans crl;
        ConnectDB conn;

        public List<object1.BContractPlans> lCrl;
        public BContractPlansDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lCrl = new List<BContractPlans>();
            crl = new BContractPlans();
            crl.b_contract_id  = "b_contract_id";
            crl.b_contract_payer_id  = "b_contract_payer_id";
            crl.b_contract_plans_id  = "b_contract_plans_id";
            crl.active  = "active";
            crl.contract_plans_active_from  = "contract_plans_active_from";
            crl.contract_plans_active_to  = "contract_plans_active_to";
            crl.contract_plans_color  = "contract_plans_color";
            crl.contract_plans_description  = "contract_plans_description";
            crl.contract_plans_hide_company  = "contract_plans_hide_company";
            crl.contract_plans_money_limit  = "contract_plans_money_limit";
            crl.contract_plans_number  = "contract_plans_number";
            crl.contract_plans_pttype  = "contract_plans_pttype";
            crl.contract_plans_sort_index  = "contract_plans_sort_index";
            crl.r_rp1853_instype_id  = "r_rp1853_instype_id";
            
            crl.pkField = "b_contract_plans_id";
            crl.table = "b_contract_plans";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select crl.*  " +
                "From " + crl.table + " crl " +
                " " +
                "Where crl." + crl.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select crl.* " +
                "From " + crl.table + " crl " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where crl." + crl.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public void getlContractPlans()
        {
            //lDept = new List<Position>();
            lCrl.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                object1.BContractPlans itm1 = new object1.BContractPlans();
                itm1.b_contract_payer_id = row[crl.b_contract_payer_id].ToString();
                itm1.contract_plans_description = row[crl.contract_plans_description].ToString();

                lCrl.Add(itm1);
            }
        }
        public String getList(String id)
        {
            String re = "";
            foreach (object1.BContractPlans sex in lCrl)
            {
                if (sex.b_contract_payer_id.Equals(id))
                {
                    re = sex.contract_plans_description;
                    break;
                }
            }
            return re;
        }
        public C1ComboBox setCboContractPlans(C1ComboBox c)
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
                item.Text = row[crl.contract_plans_description].ToString();
                item.Value = row[crl.b_contract_plans_id].ToString();

                c.Items.Add(item);
            }
            return c;
        }
    }
}
