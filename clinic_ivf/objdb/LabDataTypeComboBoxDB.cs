﻿using C1.Win.C1Input;
using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_ivf.objdb
{
    public class LabDataTypeComboBoxDB
    {
        public LabDataTypeComboBox lbM;
        ConnectDB conn;
        public List<LabDataTypeComboBox> llbM;

        public LabDataTypeComboBoxDB(ConnectDB c)
        {
            this.conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lbM = new LabDataTypeComboBox();
            llbM = new List<LabDataTypeComboBox>();

            lbM.active = "active";
            lbM.date_cancel = "date_cancel";
            lbM.date_create = "date_create";
            lbM.date_modi = "date_modi";
            lbM.user_cancel = "user_cancel";
            lbM.user_create = "user_create";
            lbM.user_modi = "user_modi";
            lbM.remark = "remark";
            lbM.sort1 = "sort1";
            lbM.lab_id = "lab_id";

            lbM.datatype_combobox_id = "datatype_combobox_id";
            lbM.datatype_combobox_name = "datatype_combobox_name";
            lbM.status_datatype = "status_datatype";

            lbM.table = "lab_b_datatype_combobox";
            lbM.pkField = "datatype_combobox_name";
        }
        public void getlBsp(String labid)
        {
            //lDept = new List<Position>();

            llbM.Clear();
            DataTable dt = new DataTable();
            dt = selectAll(labid);
            foreach (DataRow row in dt.Rows)
            {
                LabDataTypeComboBox itm1 = new LabDataTypeComboBox();
                itm1.active = row[lbM.active].ToString();
                itm1.datatype_combobox_id = row[lbM.datatype_combobox_id].ToString();
                itm1.datatype_combobox_name = row[lbM.datatype_combobox_name].ToString();
                itm1.remark = row[lbM.remark].ToString();

                //itm1.is_ipd = row[bsp.is_ipd].ToString();
                llbM.Add(itm1);
            }
        }
        public String getIdByName(String name)
        {
            String re = "";
            if (llbM.Count <= 0) getlBsp("");
            foreach (LabDataTypeComboBox row in llbM)
            {
                if (row.datatype_combobox_id.Trim().Equals(name.Trim()))
                {
                    re = row.datatype_combobox_name;
                    break;
                }
            }
            return re;
        }
        public String getNameById(String id)
        {
            String re = "";
            if (llbM.Count <= 0) getlBsp("");
            foreach (LabDataTypeComboBox row in llbM)
            {
                if (row.datatype_combobox_name.Trim().Equals(id.Trim()))
                {
                    re = row.datatype_combobox_id;
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
                " Where dgs." + lbM.active + " ='1' and dgs.lab_id = '"+ labid+"' " +
                "Order By sort1 ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }

        public LabDataTypeComboBox selectByPk(String id)
        {
            LabDataTypeComboBox cop1 = new LabDataTypeComboBox();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + lbM.table + " dgs " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dgs." + lbM.pkField + " ='" + id + "' " +
                "Order By datatype_combobox_name ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setLabDataTypeComboBox(dt);
            return cop1;
        }
        public DataTable selectByPk1(String id)
        {
            LabDataTypeComboBox cop1 = new LabDataTypeComboBox();
            DataTable dt = new DataTable();
            String sql = "select * " +
                "From " + lbM.table + " dgs " +
                //"Left Join f_patient_prefix pfx On stf.prefix_id = pfx.f_patient_prefix_id " +
                "Where dgs." + lbM.pkField + " ='" + id + "' " +
                "Order By datatype_combobox_name ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        private void chkNull(LabDataTypeComboBox p)
        {
            long chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.datatype_combobox_name = p.datatype_combobox_name == null ? "" : p.datatype_combobox_name;            
            p.sort1 = p.sort1 == null ? "" : p.sort1;

            p.lab_id = long.TryParse(p.lab_id, out chk) ? chk.ToString() : "0";

        }
        public String insert(LabDataTypeComboBox p, String userId)
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
                "," + lbM.datatype_combobox_name + "= '" + p.datatype_combobox_name.Replace("'", "''") + "'" +
                "," + lbM.remark + "= '" + p.remark.Replace("'", "''") + "'" +
                "," + lbM.sort1 + "= '" + p.sort1.Replace("'", "''") + "'" +
                "," + lbM.date_create + "= now()" +
                "," + lbM.date_modi + "= ''" +
                "," + lbM.date_cancel + "= ''" +
                "," + lbM.user_create + "= '" + userId + "@" + conn._IPAddress + "'" +
                "," + lbM.user_modi + "= ''" +
                "," + lbM.user_cancel + "= ''" +
                "," + lbM.status_datatype + " = '" + p.status_datatype.Replace("'", "''") + "'" +
                "," + lbM.lab_id + " = '" + p.lab_id.Replace("'", "''") + "'" +
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
        public String update(LabDataTypeComboBox p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Update " + lbM.table + " Set " +
                " " + lbM.datatype_combobox_name + " = '" + p.datatype_combobox_name.Replace("'", "''") + "'" +
                "," + lbM.remark + "= '" + p.remark.Replace("'", "''") + "'" +
                "," + lbM.lab_id + "= '" + p.lab_id.Replace("'", "''") + "'" +
                "Where " + lbM.pkField + "='" + p.datatype_combobox_id + "'"
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
        public String insertLabDataTypeComboBox(LabDataTypeComboBox p, String userId)
        {
            String re = "";

            if (p.datatype_combobox_id.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
            }

            return re;
        }
        public LabDataTypeComboBox setLabDataTypeComboBox(DataTable dt)
        {
            LabDataTypeComboBox dgs1 = new LabDataTypeComboBox();
            if (dt.Rows.Count > 0)
            {
                dgs1.datatype_combobox_name = dt.Rows[0][lbM.datatype_combobox_name].ToString();
                dgs1.datatype_combobox_id = dt.Rows[0][lbM.datatype_combobox_id].ToString();
                dgs1.remark = dt.Rows[0][lbM.remark].ToString();
                dgs1.active = dt.Rows[0][lbM.active].ToString();                
                dgs1.date_cancel = dt.Rows[0][lbM.date_cancel].ToString();
                dgs1.date_create = dt.Rows[0][lbM.date_create].ToString();
                dgs1.date_modi = dt.Rows[0][lbM.date_modi].ToString();
                dgs1.user_cancel = dt.Rows[0][lbM.user_cancel].ToString();
                dgs1.user_create = dt.Rows[0][lbM.user_create].ToString();
                dgs1.user_modi = dt.Rows[0][lbM.user_modi].ToString();
                dgs1.sort1 = dt.Rows[0][lbM.sort1].ToString();
                dgs1.status_datatype = dt.Rows[0][lbM.status_datatype].ToString();
                dgs1.lab_id = dt.Rows[0][lbM.lab_id].ToString();
            }
            else
            {
                setLabDataTypeComboBox(dgs1);
            }
            return dgs1;
        }
        public LabDataTypeComboBox setLabDataTypeComboBox(LabDataTypeComboBox dgs1)
        {
            dgs1.active = "";
            dgs1.remark = "";
            dgs1.datatype_combobox_id = "";
            dgs1.datatype_combobox_name = "";
            
            dgs1.date_cancel = "";
            dgs1.date_create = "";
            dgs1.date_modi = "";
            dgs1.user_cancel = "";
            dgs1.user_create = "";
            dgs1.user_modi = "";
            dgs1.sort1 = "";
            dgs1.status_datatype = "";
            dgs1.lab_id = "";
            return dgs1;
        }
        public String setCboLabDataTypeComboBox1(String labid)
        {
            String re = "";
            getlBsp(labid);
           
            foreach (LabDataTypeComboBox cus1 in llbM)
            {
                re += cus1.datatype_combobox_name+"|";
            }
            return re;
        }
        public void setCboLabDataTypeComboBox(C1ComboBox c, String selected, String labid)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectAll();
            int i = 0;

            c.Items.Clear();
            getlBsp(labid);
            item = new ComboBoxItem();
            item.Value = "";
            item.Text = "";
            c.Items.Add(item);
            foreach (LabDataTypeComboBox cus1 in llbM)
            {
                item = new ComboBoxItem();
                item.Value = cus1.datatype_combobox_id;
                item.Text = cus1.datatype_combobox_name;
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
