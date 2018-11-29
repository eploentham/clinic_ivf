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
    public class FDocTypeDB
    {
        public FDocType fdt;
        ConnectDB conn;

        public FDocTypeDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            fdt = new FDocType();
            fdt.doc_type_id = "doc_type_id";
            fdt.doc_type_code = "doc_type_code";
            fdt.doc_type_name = "doc_type_name";
            fdt.active = "active";
            fdt.status_combo = "status_combo";

            fdt.table = "f_doc_type";
            fdt.pkField = "doc_type_id";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select fdt.*  " +
                "From " + fdt.table + " fdt " +
                " " +
                "Where fdt." + fdt.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectOPUMethod()
        {
            DataTable dt = new DataTable();
            String sql = "select fdt.*  " +
                "From " + fdt.table + " fdt " +
                " " +
                "Where fdt." + fdt.active + " ='1' and fdt."+fdt.status_combo+ "='opu_method'";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectOPUStage()
        {
            DataTable dt = new DataTable();
            String sql = "select fdt.*  " +
                "From " + fdt.table + " fdt " +
                " " +
                "Where fdt." + fdt.active + " ='1' and fdt." + fdt.status_combo + "='opu_stage'";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select fdt.* " +
                "From " + fdt.table + " fdt " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where fdt." + fdt.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public FDocType selectByPk1(String copId)
        {
            FDocType cop1 = new FDocType();
            DataTable dt = new DataTable();
            String sql = "select fdt.* " +
                "From " + fdt.table + " fpf " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where fdt." + fdt.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setFDocType(dt);
            return cop1;
        }
        private FDocType setFDocType(DataTable dt)
        {
            FDocType dept1 = new FDocType();
            if (dt.Rows.Count > 0)
            {
                dept1.doc_type_id = dt.Rows[0][fdt.doc_type_id].ToString();
                dept1.doc_type_code = dt.Rows[0][fdt.doc_type_code].ToString();
                dept1.doc_type_name = dt.Rows[0][fdt.doc_type_name].ToString();
                dept1.active = dt.Rows[0][fdt.active].ToString();
                dept1.status_combo = dt.Rows[0][fdt.status_combo].ToString();
            }
            else
            {
                fdt.doc_type_id = "";
                fdt.doc_type_code = "";
                fdt.doc_type_name = "";
                fdt.active = "";
                fdt.status_combo = "";
            }
            return dept1;
        }
        public C1ComboBox setCboOPUMethod(C1ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectOPUMethod();
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
                item.Text = row[fdt.doc_type_name].ToString();
                item.Value = row[fdt.doc_type_id].ToString();

                c.Items.Add(item);
            }
            return c;
        }
        public C1ComboBox setCboOPUStage(C1ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectOPUStage();
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
                item.Text = row[fdt.doc_type_name].ToString();
                item.Value = row[fdt.doc_type_id].ToString();

                c.Items.Add(item);
            }
            return c;
        }
    }
}
