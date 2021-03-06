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
    public class FRelationDB
    {
        FRelation frl;
        ConnectDB conn;
        public List<FRelation> lFrl;
        public FRelationDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lFrl = new List<FRelation>();
            frl = new FRelation();
            frl.f_patient_relation_id = "f_patient_relation_id";
            frl.patient_relation_description = "patient_relation_description";
            frl.active = "active";

            frl.pkField = "f_patient_relation_id";
            frl.table = "f_patient_relation";
        }
        public void getlFRelation()
        {
            //lDept = new List<Position>();
            lFrl.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                FRelation itm1 = new FRelation();
                itm1.f_patient_relation_id = row[frl.f_patient_relation_id].ToString();
                itm1.patient_relation_description = row[frl.patient_relation_description].ToString();

                lFrl.Add(itm1);
            }
        }
        public String getList(String id)
        {
            String re = "";
            if (lFrl.Count <= 0)
            {
                getlFRelation();
            }
            foreach (FRelation sex in lFrl)
            {
                if (sex.f_patient_relation_id.Equals(id))
                {
                    re = sex.patient_relation_description;
                    break;
                }
            }
            return re;
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select frl.*  " +
                "From " + frl.table + " frl " +
                " " +
                "Where frl." + frl.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select frl.* " +
                "From " + frl.table + " frl " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where frl." + frl.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public FPrefix selectByPk1(String copId)
        {
            FPrefix cop1 = new FPrefix();
            DataTable dt = new DataTable();
            String sql = "select frl.* " +
                "From " + frl.table + " frl " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where frl." + frl.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setPrefix(dt);
            return cop1;
        }
        private FPrefix setPrefix(DataTable dt)
        {
            FPrefix dept1 = new FPrefix();
            if (dt.Rows.Count > 0)
            {
                dept1.f_patient_prefix_id = dt.Rows[0][frl.f_patient_relation_id].ToString();
                dept1.patient_prefix_description = dt.Rows[0][frl.patient_relation_description].ToString();
            }

            return dept1;
        }
        public DataTable selectC1()
        {
            DataTable dt = new DataTable();
            String sql = "select frl." + frl.pkField + ",frl." + frl.patient_relation_description + " " +
                "From " + frl.table + " frl " +
                " " +
                "Where frl." + frl.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public C1ComboBox setCboRelation(C1ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectC1();
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
                item.Text = row[frl.patient_relation_description].ToString();
                item.Value = row[frl.f_patient_relation_id].ToString();

                c.Items.Add(item);
            }
            return c;
        }
        public C1ComboBox setCboRelation(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectC1();
            if (lFrl.Count <= 0) getlFRelation();
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (FRelation row in lFrl)
            {
                item = new ComboBoxItem();
                item.Value = row.f_patient_relation_id;
                item.Text = row.patient_relation_description;
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
    }
}
