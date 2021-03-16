using C1.Win.C1Input;
using C1.Win.C1Ribbon;
using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class TemplateDrugDB
    {
        public TemplateDrug tdrug;
        ConnectDB conn;
        public List<TemplateDrug> lFpf;

        public TemplateDrugDB(ConnectDB c)
        {
            this.conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lFpf = new List<TemplateDrug>();
            tdrug = new TemplateDrug();

            tdrug.temp_drug_id = "temp_drug_id";
            tdrug.temp_drug_name = "temp_drug_name";
            tdrug.drug_id = "drug_id";
            tdrug.usage_thai = "usage_thai";
            tdrug.usage_eng = "usage_eng";
            tdrug.qty = "qty";
            tdrug.staff_id = "staff_id";
            tdrug.sort1 = "sort1";
            tdrug.active = "active";
            tdrug.remark = "remark";
            tdrug.date_create = "date_create";
            tdrug.date_modi = "date_modi";
            tdrug.date_cancel = "date_cancel";
            tdrug.user_create = "user_create";
            tdrug.user_modi = "user_modi";
            tdrug.user_cancel = "user_cancel";

            tdrug.table = "b_template_drug";
            tdrug.pkField = "temp_drug_id";
        }
        public TemplateDrug selectByPk(String id)
        {
            TemplateDrug cop1 = new TemplateDrug();
            DataTable dt = new DataTable();
            String sql = "select tdrug.* " +
                "From " + tdrug.table + " tdrug " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where tdrug." + tdrug.pkField + " ='" + id + "' " +
                "Order By tdrug.sort1 ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setAccCashTransfer(dt);
            return cop1;
        }
        public DataTable selectByPk1(String id)
        {
            TemplateDrug cop1 = new TemplateDrug();
            DataTable dt = new DataTable();
            String sql = "select tdrug.* " +
                "From " + tdrug.table + " tdrug " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where tdrug." + tdrug.pkField + " ='" + id + "' " +
                "Order By tdrug.sort1 ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByTempDrugName(String stfidd)
        {
            TemplateDrug cop1 = new TemplateDrug();
            DataTable dt = new DataTable();
            String sql = "select distinct tdrug.temp_drug_name " +
                "From " + tdrug.table + " tdrug " +
                "Where tdrug." + tdrug.staff_id + " ='" + stfidd + "' and tdrug.active = '1' " +
                " ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public C1ComboBox setCboUsageT(C1ComboBox c, String stfid)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectByTempDrugName(stfid);
            //String aaa = "";
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                item = new ComboBoxItem();
                item.Text = row[tdrug.temp_drug_name].ToString();
                item.Value = row[tdrug.temp_drug_name].ToString();

                c.Items.Add(item);
                i++;
            }
            return c;
        }
        public RibbonComboBox setCboUsageT(RibbonComboBox c, String stfid)
        {
            DataTable dt = selectByTempDrugName(stfid);
            c.Items.Clear();
            c.Items.Add("");
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                c.Items.Add(row[tdrug.temp_drug_name].ToString());
                i++;
            }
            return c;
        }
        public void getlActCashTransfer(String stfid)
        {
            //lDept = new List<Position>();
            lFpf.Clear();
            DataTable dt = new DataTable();
            dt = selectByTempDrugName(stfid);
            foreach (DataRow row in dt.Rows)
            {
                TemplateDrug itm1 = new TemplateDrug();
                itm1.temp_drug_id = row[tdrug.temp_drug_id].ToString();
                itm1.temp_drug_name = row[tdrug.temp_drug_name].ToString();

                lFpf.Add(itm1);
            }
        }
        public DataTable selectByDtrId(String stfid, String tempdrugname)
        {
            String wherehn = "", wheretempdrugname="";
            DataTable dt = new DataTable();
            //if (stfid.Length > 0)
            //{
                wherehn = " and tdrug.staff_id = '" + stfid + "' ";
            //}
            //if (tempdrugname.Length > 0)
            //{
                wheretempdrugname = " and tdrug.temp_drug_name = '" + tempdrugname + "' ";
            //}
            String sql = "Select tdrug.*,stk.DUName  " +
                "From " + tdrug.table + " tdrug " +
                "Left Join StockDrug stk On tdrug.drug_id = stk.DUID " +
                " Where tdrug." + tdrug.active + " ='1' " + wherehn + wheretempdrugname +
                "Order By tdrug.temp_drug_id ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        private void chkNull(TemplateDrug p)
        {
            long chk = 0;
            decimal chk1 = 0;
            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.date_create = p.date_create == null ? "" : p.date_create;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.remark = p.remark == null ? "" : p.remark;

            p.temp_drug_name = p.temp_drug_name == null ? "" : p.temp_drug_name;
            p.usage_thai = p.usage_thai == null ? "" : p.usage_thai;
            p.usage_eng = p.usage_eng == null ? "" : p.usage_eng;
            p.qty = p.qty == null ? "" : p.qty;
            p.sort1 = p.sort1 == null ? "" : p.sort1;
            //p.remark = p.remark == null ? "" : p.remark;

            //p.deposit_amount = decimal.TryParse(p.deposit_amount, out chk1) ? chk1.ToString() : "0";
            p.drug_id = long.TryParse(p.drug_id, out chk) ? chk.ToString() : "0";
            p.staff_id = long.TryParse(p.staff_id, out chk) ? chk.ToString() : "0";
        }
        public String insert(TemplateDrug p, String userId)
        {
            String re = "";
            String sql = "";
            //DataTable dt = new DataTable();
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;
            chkNull(p);
            sql = "Insert Into " + tdrug.table + " set " +
                "" + tdrug.temp_drug_name + "= '" + p.temp_drug_name + "'" +
                "," + tdrug.active + "= '1'" +
                "," + tdrug.drug_id + "= '" + p.drug_id + "'" +
                "," + tdrug.remark + "= '" + p.remark.Replace("'", "''") + "'" +
                "," + tdrug.date_create + "= now()" +
                "," + tdrug.date_modi + "= ''" +
                "," + tdrug.date_cancel + "= ''" +
                "," + tdrug.user_create + "= '" + userId + "@" + conn._IPAddress + "'" +
                "," + tdrug.user_modi + "= ''" +
                "," + tdrug.user_cancel + "= ''" +
                "," + tdrug.usage_thai + "= '" + p.usage_thai.Replace("'", "''") + "'" +
                "," + tdrug.usage_eng + "= '" + p.usage_eng.Replace("'", "''") + "'" +
                "," + tdrug.qty + "= '" + p.qty + "'" +
                "," + tdrug.staff_id + "= '" + p.staff_id + "'" +
                "," + tdrug.sort1 + "= '" + p.sort1 + "'" +
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
        public String update(TemplateDrug p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            chkNull(p);
            sql = "Update " + tdrug.table + " Set " +
                "" + tdrug.temp_drug_name + "= '" + p.temp_drug_name + "'" +
                "," + tdrug.active + "= '1'" +
                "," + tdrug.drug_id + "= '" + p.drug_id + "'" +
                "," + tdrug.remark + "= '" + p.remark.Replace("'", "''") + "'" +
                "," + tdrug.date_modi + "= now()" +
                "," + tdrug.user_modi + "= '" + userId + "@" + conn._IPAddress + "'" +
                "," + tdrug.usage_thai + "= '" + p.usage_thai.Replace("'", "''") + "'" +
                "," + tdrug.usage_eng + "= '" + p.usage_eng.Replace("'", "''") + "'" +
                "," + tdrug.qty + "= '" + p.qty + "'" +
                "," + tdrug.staff_id + "= '" + p.staff_id + "'" +
                "," + tdrug.sort1 + "= '" + p.sort1 + "'" +
                "Where " + tdrug.pkField + "='" + p.temp_drug_id + "'"
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
        public String insertTemplateDrug(TemplateDrug p, String userId)
        {
            String re = "";
            //chkNull(p);
            if (p.temp_drug_id.Equals(""))
            {
                re = insert(p, userId);
            }
            else
            {
                re = update(p, userId);
            }

            return re;
        }
        public String voidTemplateDrug(String id, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            
            sql = "Update " + tdrug.table + " Set " +
                " " + tdrug.active + "= '3'" +
                "," + tdrug.date_cancel + "= now()" +
                "," + tdrug.user_cancel + "= '" + userId + "@" + conn._IPAddress + "'" +
                "Where " + tdrug.pkField + "='" + id + "'"
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
        public TemplateDrug setAccCashTransfer(DataTable dt)
        {
            TemplateDrug dgs1 = new TemplateDrug();
            if (dt.Rows.Count > 0)
            {
                dgs1.temp_drug_id = dt.Rows[0][tdrug.temp_drug_id].ToString();
                dgs1.temp_drug_name = dt.Rows[0][tdrug.temp_drug_name].ToString();
                dgs1.drug_id = dt.Rows[0][tdrug.drug_id].ToString();
                dgs1.active = dt.Rows[0][tdrug.active].ToString();
                dgs1.remark = dt.Rows[0][tdrug.remark].ToString();
                dgs1.date_create = dt.Rows[0][tdrug.date_create].ToString();
                dgs1.date_modi = dt.Rows[0][tdrug.date_modi].ToString();
                dgs1.date_cancel = dt.Rows[0][tdrug.date_cancel].ToString();
                dgs1.user_create = dt.Rows[0][tdrug.user_create].ToString();
                dgs1.user_modi = dt.Rows[0][tdrug.user_modi].ToString();
                dgs1.user_cancel = dt.Rows[0][tdrug.user_cancel].ToString();
                dgs1.usage_thai = dt.Rows[0][tdrug.usage_thai].ToString();
                dgs1.usage_eng = dt.Rows[0][tdrug.usage_eng].ToString();
                dgs1.qty = dt.Rows[0][tdrug.qty].ToString();
                dgs1.staff_id = dt.Rows[0][tdrug.staff_id].ToString();
                dgs1.sort1 = dt.Rows[0][tdrug.sort1].ToString();
            }
            else
            {
                setAccCashTransfer(dgs1);
            }
            return dgs1;
        }
        public TemplateDrug setAccCashTransfer(TemplateDrug dgs1)
        {
            dgs1.temp_drug_id = "";
            dgs1.temp_drug_name = "";
            dgs1.drug_id = "";
            dgs1.active = "";
            dgs1.remark = "";
            dgs1.date_create = "";
            dgs1.date_modi = "";
            dgs1.date_cancel = "";
            dgs1.user_create = "";
            dgs1.user_modi = "";
            dgs1.user_cancel = "";
            dgs1.usage_thai = "";
            dgs1.usage_eng = "";
            dgs1.qty = "";
            dgs1.staff_id = "";
            dgs1.sort1 = "";
            
            return dgs1;
        }
    }
}
