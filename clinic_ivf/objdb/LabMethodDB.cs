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
    public class LabMethodDB
    {
        public LabMethod lbM;
        ConnectDB conn;
        public List<LabMethod> llbM;

        public LabMethodDB(ConnectDB c)
        {
            this.conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lbM = new LabMethod();
            llbM = new List<LabMethod>();

            lbM.active = "active";
            lbM.date_cancel = "date_cancel";
            lbM.date_create = "date_create";
            lbM.date_modi = "date_modi";
            lbM.user_cancel = "user_cancel";
            lbM.user_create = "user_create";
            lbM.user_modi = "user_modi";
            lbM.remark = "remark";
            lbM.sort1 = "sort1";

            lbM.method_name = "method_name";
            lbM.method_id = "method_id";
            //lbM.remark = "remark";
            lbM.method_code = "method_code";

            lbM.table = "lab_b_method";
            lbM.pkField = "method_id";
        }
        public void getlBsp()
        {
            //lDept = new List<Position>();

            llbM.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                LabMethod itm1 = new LabMethod();
                itm1.active = row[lbM.active].ToString();
                itm1.method_name = row[lbM.method_name].ToString();
                itm1.method_id = row[lbM.method_id].ToString();
                itm1.remark = row[lbM.remark].ToString();
                itm1.method_code = row[lbM.method_code].ToString();

                //itm1.is_ipd = row[bsp.is_ipd].ToString();
                llbM.Add(itm1);
            }
        }
        public String getIdDgs(String name)
        {
            String re = "";
            foreach (LabMethod row in llbM)
            {
                if (row.method_name.Trim().Equals(name.Trim()))
                {
                    re = row.method_id;
                    break;
                }
            }
            return re;
        }
        public String getNameDgs(String id)
        {
            String re = "";
            foreach (LabMethod row in llbM)
            {
                if (row.method_id.Trim().Equals(id.Trim()))
                {
                    re = row.method_name;
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
                "Order By method_id ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }

        public LabMethod selectByPk(String id)
        {
            LabMethod cop1 = new LabMethod();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + lbM.table + " dgs " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dgs." + lbM.pkField + " ='" + id + "' " +
                "Order By method_id ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setLabMethod(dt);
            return cop1;
        }
        public DataTable selectByPk1(String id)
        {
            LabMethod cop1 = new LabMethod();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + lbM.table + " dgs " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dgs." + lbM.pkField + " ='" + id + "' " +
                "Order By method_id ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        private void chkNull(LabMethod p)
        {
            long chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.method_code = p.method_code == null ? "" : p.method_code;
            p.method_name = p.method_name == null ? "" : p.method_name;
            p.sort1 = p.sort1 == null ? "" : p.sort1;            

        }
        public String insert(LabMethod p, String userId)
        {
            String re = "";
            String sql = "";
            //DataTable dt = new DataTable();
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;
            chkNull(p);
            sql = "Insert Into " + lbM.table + " set " +
                "" + lbM.method_code + "= '" + p.method_code.Replace("'", "''") + "'" +
                "," + lbM.active + "= '" + p.active + "'" +
                "," + lbM.method_name + "= '" + p.method_name.Replace("'", "''") + "'" +
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
        public String update(LabMethod p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Update " + lbM.table + " Set " +
                " " + lbM.method_name + " = '" + p.method_name.Replace("'", "''") + "'" +
                "," + lbM.method_code + " = '" + p.method_code.Replace("'", "''") + "'" +
                "," + lbM.remark + "= '" + p.remark.Replace("'", "''") + "'" +
                "," + lbM.sort1 + "= '" + p.sort1.Replace("'", "''") + "'" +
                "Where " + lbM.pkField + "='" + p.method_id + "'"
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
        public String insertLabMethod(LabMethod p, String userId)
        {
            String re = "";

            if (p.method_id.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
            }

            return re;
        }
        public LabMethod setLabMethod(DataTable dt)
        {
            LabMethod dgs1 = new LabMethod();
            if (dt.Rows.Count > 0)
            {
                dgs1.method_id = dt.Rows[0][lbM.method_id].ToString();
                dgs1.method_name = dt.Rows[0][lbM.method_name].ToString();
                dgs1.remark = dt.Rows[0][lbM.remark].ToString();
                dgs1.active = dt.Rows[0][lbM.active].ToString();
                dgs1.method_code = dt.Rows[0][lbM.method_code].ToString();
                dgs1.date_cancel = dt.Rows[0][lbM.date_cancel].ToString();
                dgs1.date_create = dt.Rows[0][lbM.date_create].ToString();
                dgs1.date_modi = dt.Rows[0][lbM.date_modi].ToString();
                dgs1.user_cancel = dt.Rows[0][lbM.user_cancel].ToString();
                dgs1.user_create = dt.Rows[0][lbM.user_create].ToString();
                dgs1.user_modi = dt.Rows[0][lbM.user_modi].ToString();
                dgs1.sort1 = dt.Rows[0][lbM.sort1].ToString();
                //dgs1.method_code = dt.Rows[0][lbM.method_code].ToString();
            }
            else
            {
                setLabMethod(dgs1);
            }
            return dgs1;
        }
        public LabMethod setLabMethod(LabMethod dgs1)
        {
            dgs1.active = "";
            dgs1.remark = "";
            dgs1.method_name = "";
            dgs1.method_id = "";
            dgs1.method_code = "";
            dgs1.date_cancel = "";
            dgs1.date_create = "";
            dgs1.date_modi = "";
            dgs1.user_cancel = "";
            dgs1.user_create = "";
            dgs1.user_modi = "";
            dgs1.sort1 = "";
            return dgs1;
        }
        public void setCboLabMethod(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectAll();
            int i = 0;
            if (llbM.Count <= 0) getlBsp();
            item = new ComboBoxItem();
            item.Value = "";
            item.Text = "";
            c.Items.Add(item);
            foreach (LabMethod cus1 in llbM)
            {
                item = new ComboBoxItem();
                item.Value = cus1.method_id;
                item.Text = cus1.method_name;
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
