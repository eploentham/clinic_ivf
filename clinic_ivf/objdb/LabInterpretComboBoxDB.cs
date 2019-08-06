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
    public class LabInterpretComboBoxDB
    {
        public LabInterpretComboBox lbM;
        ConnectDB conn;
        public List<LabInterpretComboBox> llbM;

        public LabInterpretComboBoxDB(ConnectDB c)
        {
            this.conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lbM = new LabInterpretComboBox();
            llbM = new List<LabInterpretComboBox>();

            lbM.active = "active";
            lbM.date_cancel = "date_cancel";
            lbM.date_create = "date_create";
            lbM.date_modi = "date_modi";
            lbM.user_cancel = "user_cancel";
            lbM.user_create = "user_create";
            lbM.user_modi = "user_modi";
            lbM.remark = "remark";
            lbM.sort1 = "sort1";

            lbM.interpret_combobox_id = "interpret_combobox_id";
            lbM.interpret_combobox_name = "interpret_combobox_name";
            lbM.lab_id = "lab_id";
            lbM.min_value = "min_value";
            lbM.max_value = "max_value";
            lbM.min_value_criteria = "min_value_criteria";
            lbM.max_value_criteria = "max_value_criteria";
            lbM.interpret = "interpret";

            lbM.table = "lab_b_interpret_combobox";
            lbM.pkField = "interpret_combobox_name";
        }
        public void getlBsp(String labid)
        {
            //lDept = new List<Position>();

            llbM.Clear();
            DataTable dt = new DataTable();
            dt = selectAll(labid);
            foreach (DataRow row in dt.Rows)
            {
                LabInterpretComboBox itm1 = new LabInterpretComboBox();
                itm1.active = row[lbM.active].ToString();
                itm1.interpret_combobox_id = row[lbM.interpret_combobox_id].ToString();
                itm1.interpret_combobox_name = row[lbM.interpret_combobox_name].ToString();
                itm1.remark = row[lbM.remark].ToString();

                //itm1.is_ipd = row[bsp.is_ipd].ToString();
                llbM.Add(itm1);
            }
        }
        public String getIdByName(String labid)
        {
            String re = "";
            if (llbM.Count <= 0) getlBsp(labid);
            foreach (LabInterpretComboBox row in llbM)
            {
                if (row.interpret_combobox_id.Trim().Equals(labid.Trim()))
                {
                    re = row.interpret_combobox_name;
                    break;
                }
            }
            return re;
        }
        public String getNameById(String id)
        {
            String re = "";
            if (llbM.Count <= 0) getlBsp(id);
            foreach (LabInterpretComboBox row in llbM)
            {
                if (row.interpret_combobox_name.Trim().Equals(id.Trim()))
                {
                    re = row.interpret_combobox_id;
                    break;
                }
            }
            return re;
        }
        public DataTable selectAll(String labid)
        {
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + lbM.table + " dgs " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                " Where dgs." + lbM.active + " ='1' and dgs.lab_id = '" + labid + "' " +
                "Order By interpret_combobox_name ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }

        public LabInterpretComboBox selectByPk(String id)
        {
            LabInterpretComboBox cop1 = new LabInterpretComboBox();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + lbM.table + " dgs " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dgs." + lbM.pkField + " ='" + id + "' " +
                "Order By interpret_combobox_name ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setLabInterpretComboBox(dt);
            return cop1;
        }
        public DataTable selectByPk1(String id)
        {
            LabInterpretComboBox cop1 = new LabInterpretComboBox();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + lbM.table + " dgs " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dgs." + lbM.pkField + " ='" + id + "' " +
                "Order By interpret_combobox_name ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        private void chkNull(LabInterpretComboBox p)
        {
            long chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.interpret_combobox_name = p.interpret_combobox_name == null ? "" : p.interpret_combobox_name;
            p.sort1 = p.sort1 == null ? "" : p.sort1;
            p.min_value_criteria = p.min_value_criteria == null ? "" : p.min_value_criteria;
            p.max_value_criteria = p.max_value_criteria == null ? "" : p.max_value_criteria;
            p.interpret = p.interpret == null ? "" : p.interpret;

            p.lab_id = long.TryParse(p.lab_id, out chk) ? chk.ToString() : "0";
            p.min_value = Decimal.TryParse(p.min_value, out chk1) ? chk1.ToString() : "0";
            p.max_value = Decimal.TryParse(p.max_value, out chk1) ? chk1.ToString() : "0";
            //p.min_value_criteria = long.TryParse(p.min_value_criteria, out chk) ? chk.ToString() : "0";
            //p.max_value_criteria = long.TryParse(p.max_value_criteria, out chk) ? chk.ToString() : "0";

        }
        public String insert(LabInterpretComboBox p, String userId)
        {
            String re = "";
            String sql = "";
            //DataTable dt = new DataTable();
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;
            chkNull(p);
            sql = "Insert Into " + lbM.table + " set " +
                " " + lbM.active + "= '1'" +
                "," + lbM.interpret_combobox_name + "= '" + p.interpret_combobox_name.Replace("'", "''") + "'" +
                "," + lbM.remark + "= '" + p.remark.Replace("'", "''") + "'" +
                "," + lbM.sort1 + "= '" + p.sort1.Replace("'", "''") + "'" +
                "," + lbM.date_create + "= now()" +
                "," + lbM.date_modi + "= ''" +
                "," + lbM.date_cancel + "= ''" +
                "," + lbM.user_create + "= '" + userId + "@" + conn._IPAddress + "'" +
                "," + lbM.user_modi + "= ''" +
                "," + lbM.user_cancel + "= ''" +
                "," + lbM.lab_id + " = '" + p.lab_id.Replace("'", "''") + "'" +
                "," + lbM.min_value_criteria + " = '" + p.min_value_criteria.Replace("'", "''") + "'" +
                "," + lbM.max_value_criteria + " = '" + p.max_value_criteria.Replace("'", "''") + "'" +
                "," + lbM.min_value + " = '" + p.min_value.Replace("'", "''") + "'" +
                "," + lbM.max_value + " = '" + p.max_value.Replace("'", "''") + "'" +
                "," + lbM.interpret + " = '" + p.interpret.Replace("'", "''") + "'" +
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
        public String update(LabInterpretComboBox p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Update " + lbM.table + " Set " +
                " " + lbM.interpret_combobox_name + " = '" + p.interpret_combobox_name.Replace("'", "''") + "'" +
                "," + lbM.remark + "= '" + p.remark.Replace("'", "''") + "'" +
                "," + lbM.lab_id + " = '" + p.lab_id.Replace("'", "''") + "'" +
                "," + lbM.min_value_criteria + " = '" + p.min_value_criteria.Replace("'", "''") + "'" +
                "," + lbM.max_value_criteria + " = '" + p.max_value_criteria.Replace("'", "''") + "'" +
                "," + lbM.min_value + " = '" + p.min_value.Replace("'", "''") + "'" +
                "," + lbM.max_value + " = '" + p.max_value.Replace("'", "''") + "'" +
                "," + lbM.interpret + " = '" + p.interpret.Replace("'", "''") + "'" +
                "Where " + lbM.pkField + "='" + p.interpret_combobox_id + "'"
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
        public String insertLabInterpretComboBox(LabInterpretComboBox p, String userId)
        {
            String re = "";

            if (p.interpret_combobox_id.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
            }

            return re;
        }
        public String voidLabInterPret(String id, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Update " + lbM.table + " Set " +
                " " + lbM.active + " = '3'" +
                "," + lbM.date_cancel + " = now() " +
                "Where " + lbM.pkField + "='" + id + "'"
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
        public LabInterpretComboBox setLabInterpretComboBox(DataTable dt)
        {
            LabInterpretComboBox dgs1 = new LabInterpretComboBox();
            if (dt.Rows.Count > 0)
            {
                dgs1.interpret_combobox_name = dt.Rows[0][lbM.interpret_combobox_name].ToString();
                dgs1.interpret_combobox_id = dt.Rows[0][lbM.interpret_combobox_id].ToString();
                dgs1.remark = dt.Rows[0][lbM.remark].ToString();
                dgs1.active = dt.Rows[0][lbM.active].ToString();
                dgs1.date_cancel = dt.Rows[0][lbM.date_cancel].ToString();
                dgs1.date_create = dt.Rows[0][lbM.date_create].ToString();
                dgs1.date_modi = dt.Rows[0][lbM.date_modi].ToString();
                dgs1.user_cancel = dt.Rows[0][lbM.user_cancel].ToString();
                dgs1.user_create = dt.Rows[0][lbM.user_create].ToString();
                dgs1.user_modi = dt.Rows[0][lbM.user_modi].ToString();
                dgs1.sort1 = dt.Rows[0][lbM.sort1].ToString();
                dgs1.lab_id = dt.Rows[0][lbM.lab_id].ToString();
                dgs1.min_value = dt.Rows[0][lbM.min_value].ToString();
                dgs1.max_value = dt.Rows[0][lbM.max_value].ToString();
                dgs1.min_value_criteria = dt.Rows[0][lbM.min_value_criteria].ToString();
                dgs1.max_value_criteria = dt.Rows[0][lbM.max_value_criteria].ToString();
                dgs1.interpret = dt.Rows[0][lbM.interpret].ToString();
            }
            else
            {
                setLabInterpretComboBox(dgs1);
            }
            return dgs1;
        }
        public LabInterpretComboBox setLabInterpretComboBox(LabInterpretComboBox dgs1)
        {
            dgs1.active = "";
            dgs1.remark = "";
            dgs1.interpret_combobox_id = "";
            dgs1.interpret_combobox_name = "";

            dgs1.date_cancel = "";
            dgs1.date_create = "";
            dgs1.date_modi = "";
            dgs1.user_cancel = "";
            dgs1.user_create = "";
            dgs1.user_modi = "";
            dgs1.sort1 = "";
            dgs1.lab_id = "";
            dgs1.min_value = "";
            dgs1.max_value = "";
            dgs1.min_value_criteria = "";
            dgs1.max_value_criteria = "";
            dgs1.interpret = "";
            return dgs1;
        }
        public void setCboLabInterpretComboBox(C1ComboBox c, String selected, String labid)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectAll();
            int i = 0;
            getlBsp(labid);
            item = new ComboBoxItem();
            item.Value = "";
            item.Text = "";
            c.Items.Add(item);
            foreach (LabInterpretComboBox cus1 in llbM)
            {
                item = new ComboBoxItem();
                item.Value = cus1.interpret_combobox_id;
                item.Text = cus1.interpret;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    //c.SelectedItem = item.Value;
                    c.SelectedText = item.Text;
                    c.SelectedIndex = i + 1;
                }
                i++;
            }
        }
    }
}
