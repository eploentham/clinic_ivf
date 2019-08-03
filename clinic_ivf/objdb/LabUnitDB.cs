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
    public class LabUnitDB
    {
        public LabUnit lbM;
        ConnectDB conn;
        public List<LabUnit> llbM;

        public LabUnitDB(ConnectDB c)
        {
            this.conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lbM = new LabUnit();
            llbM = new List<LabUnit>();

            lbM.active = "active";
            lbM.date_cancel = "date_cancel";
            lbM.date_create = "date_create";
            lbM.date_modi = "date_modi";
            lbM.user_cancel = "user_cancel";
            lbM.user_create = "user_create";
            lbM.user_modi = "user_modi";
            lbM.remark = "remark";
            lbM.sort1 = "sort1";

            lbM.lab_unit_name = "lab_unit_name";
            lbM.lab_unit_id = "lab_unit_id";
            //lbM.remark = "remark";
            lbM.lab_unit_code = "lab_unit_code";

            lbM.table = "lab_b_method";
            lbM.pkField = "lab_unit_id";
        }
        public void getlBsp()
        {
            //lDept = new List<Position>();

            llbM.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                LabUnit itm1 = new LabUnit();
                itm1.active = row[lbM.active].ToString();
                itm1.lab_unit_name = row[lbM.lab_unit_name].ToString();
                itm1.lab_unit_id = row[lbM.lab_unit_id].ToString();
                itm1.remark = row[lbM.remark].ToString();
                itm1.lab_unit_code = row[lbM.lab_unit_code].ToString();

                //itm1.is_ipd = row[bsp.is_ipd].ToString();
                llbM.Add(itm1);
            }
        }
        public String getIdDgs(String name)
        {
            String re = "";
            foreach (LabUnit row in llbM)
            {
                if (row.lab_unit_name.Trim().Equals(name.Trim()))
                {
                    re = row.lab_unit_id;
                    break;
                }
            }
            return re;
        }
        public String getNameDgs(String id)
        {
            String re = "";
            foreach (LabUnit row in llbM)
            {
                if (row.lab_unit_id.Trim().Equals(id.Trim()))
                {
                    re = row.lab_unit_name;
                    break;
                }
            }
            return re;
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + lbM.table + " dgs " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                " Where dgs." + lbM.active + " ='1' " +
                "Order By lab_unit_id ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }

        public LabUnit selectByPk(String id)
        {
            LabUnit cop1 = new LabUnit();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + lbM.table + " dgs " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dgs." + lbM.pkField + " ='" + id + "' " +
                "Order By lab_unit_id ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setLabUnit(dt);
            return cop1;
        }
        public DataTable selectByPk1(String id)
        {
            LabUnit cop1 = new LabUnit();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + lbM.table + " dgs " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dgs." + lbM.pkField + " ='" + id + "' " +
                "Order By lab_unit_id ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        private void chkNull(LabUnit p)
        {
            long chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.lab_unit_code = p.lab_unit_code == null ? "" : p.lab_unit_code;
            p.lab_unit_name = p.lab_unit_name == null ? "" : p.lab_unit_name;
            p.sort1 = p.sort1 == null ? "" : p.sort1;

        }
        public String insert(LabUnit p, String userId)
        {
            String re = "";
            String sql = "";
            //DataTable dt = new DataTable();
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;
            chkNull(p);
            sql = "Insert Into " + lbM.table + " set " +
                "" + lbM.lab_unit_code + "= '" + p.lab_unit_code.Replace("'", "''") + "'" +
                "," + lbM.active + "= '" + p.active + "'" +
                "," + lbM.lab_unit_name + "= '" + p.lab_unit_name.Replace("'", "''") + "'" +
                "," + lbM.remark + "= '" + p.remark.Replace("'", "''") + "'" +
                "," + lbM.sort1 + "= '" + p.sort1.Replace("'", "''") + "'" +
                "," + lbM.date_create + "= now()" +
                "," + lbM.date_modi + "= ''" +
                "," + lbM.date_cancel + "= ''" +
                "," + lbM.user_create + "= '" + userId + "@" + conn._IPAddress + "'" +
                "," + lbM.user_modi + "= ''" +
                "," + lbM.user_cancel + "= ''" +
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
        public String update(LabUnit p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Update " + lbM.table + " Set " +
                " " + lbM.lab_unit_name + " = '" + p.lab_unit_name.Replace("'", "''") + "'" +
                "," + lbM.lab_unit_code + " = '" + p.lab_unit_code.Replace("'", "''") + "'" +
                "," + lbM.remark + "= '" + p.remark.Replace("'", "''") + "'" +
                "," + lbM.sort1 + "= '" + p.sort1.Replace("'", "''") + "'" +
                "Where " + lbM.pkField + "='" + p.lab_unit_id + "'"
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
        public String insertLabUnit(LabUnit p, String userId)
        {
            String re = "";

            if (p.lab_unit_id.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
            }

            return re;
        }
        public LabUnit setLabUnit(DataTable dt)
        {
            LabUnit dgs1 = new LabUnit();
            if (dt.Rows.Count > 0)
            {
                dgs1.lab_unit_id = dt.Rows[0][lbM.lab_unit_id].ToString();
                dgs1.lab_unit_name = dt.Rows[0][lbM.lab_unit_name].ToString();
                dgs1.remark = dt.Rows[0][lbM.remark].ToString();
                dgs1.active = dt.Rows[0][lbM.active].ToString();
                dgs1.lab_unit_code = dt.Rows[0][lbM.lab_unit_code].ToString();
                dgs1.date_cancel = dt.Rows[0][lbM.date_cancel].ToString();
                dgs1.date_create = dt.Rows[0][lbM.date_create].ToString();
                dgs1.date_modi = dt.Rows[0][lbM.date_modi].ToString();
                dgs1.user_cancel = dt.Rows[0][lbM.user_cancel].ToString();
                dgs1.user_create = dt.Rows[0][lbM.user_create].ToString();
                dgs1.user_modi = dt.Rows[0][lbM.user_modi].ToString();
                dgs1.sort1 = dt.Rows[0][lbM.sort1].ToString();
                //dgs1.lab_unit_code = dt.Rows[0][lbM.lab_unit_code].ToString();
            }
            else
            {
                setLabUnit(dgs1);
            }
            return dgs1;
        }
        public LabUnit setLabUnit(LabUnit dgs1)
        {
            dgs1.active = "";
            dgs1.remark = "";
            dgs1.lab_unit_name = "";
            dgs1.lab_unit_id = "";
            dgs1.lab_unit_code = "";
            dgs1.date_cancel = "";
            dgs1.date_create = "";
            dgs1.date_modi = "";
            dgs1.user_cancel = "";
            dgs1.user_create = "";
            dgs1.user_modi = "";
            dgs1.sort1 = "";
            return dgs1;
        }
        public void setCboLabUnit(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectAll();
            int i = 0;
            if (llbM.Count <= 0) getlBsp();
            item = new ComboBoxItem();
            item.Value = "";
            item.Text = "";
            c.Items.Add(item);
            foreach (LabUnit cus1 in llbM)
            {
                item = new ComboBoxItem();
                item.Value = cus1.lab_unit_id;
                item.Text = cus1.lab_unit_name;
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
