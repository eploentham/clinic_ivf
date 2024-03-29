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
    public class FPatientRaceDB
    {
        FPatientRace fpr;
        ConnectDB conn;
        public FPatientRaceDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            fpr = new FPatientRace();
            fpr.f_patient_race_id = "f_patient_race_id";
            fpr.patient_race_description = "patient_race_description";

            fpr.pkField = "f_patient_race_id";
            fpr.table = "f_patient_race";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select fpr.*  " +
                "From " + fpr.table + " fpr " +
                " " +
                "Where fpr." + fpr.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select fpr.* " +
                "From " + fpr.table + " fpr " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where fpr." + fpr.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public FPrefix selectByPk1(String copId)
        {
            FPrefix cop1 = new FPrefix();
            DataTable dt = new DataTable();
            String sql = "select fpr.* " +
                "From " + fpr.table + " fpr " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where fpr." + fpr.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setPrefix(dt);
            return cop1;
        }
        private FPrefix setPrefix(DataTable dt)
        {
            FPrefix dept1 = new FPrefix();
            if (dt.Rows.Count > 0)
            {
                dept1.f_patient_prefix_id = dt.Rows[0][fpr.f_patient_race_id].ToString();
                dept1.patient_prefix_description = dt.Rows[0][fpr.patient_race_description].ToString();
            }

            return dept1;
        }
        public DataTable selectC1()
        {
            DataTable dt = new DataTable();
            String sql = "select fpr." + fpr.pkField + ",fpr." + fpr.patient_race_description + " " +
                "From " + fpr.table + " fpr " +
                " " +
                "Where fpr." + fpr.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public C1ComboBox setCboPrefix(C1ComboBox c)
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
                item.Text = row[fpr.patient_race_description].ToString();
                item.Value = row[fpr.f_patient_race_id].ToString();

                c.Items.Add(item);
            }
            return c;
        }
    }
}
