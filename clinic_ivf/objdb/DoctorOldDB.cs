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
    public class DoctorOldDB
    {
        public DoctorOld dtrOld;
        ConnectDB conn;
        public List<DoctorOld> ldtrO;

        public DoctorOldDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            ldtrO = new List<DoctorOld>();
            dtrOld = new DoctorOld();
            dtrOld.ID = "ID";
            dtrOld.Name = "Name";
            dtrOld.TVS = "TVS";

            dtrOld.table = "Doctor";
            dtrOld.pkField = "ID";
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select dtrOld.* " +
                "From " + dtrOld.table + " dtrOld " +
                "Where dtrOld." + dtrOld.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select dtrOld.*  " +
                "From " + dtrOld.table + " dtrOld " ;
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public void getlDtr()
        {
            //lDept = new List<Position>();
            ldtrO.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                DoctorOld itm1 = new DoctorOld();
                itm1.ID = row[dtrOld.ID].ToString();
                itm1.Name = row[dtrOld.Name].ToString();
                itm1.TVS = row[dtrOld.TVS].ToString();
                
                ldtrO.Add(itm1);
            }
        }
        public String getlDtrIDByName(String data)
        {
            String re = "";
            //if (c.Items.Count == 0) return "";
            //c.SelectedIndex = c.SelectedItem == null ? 0 : c.SelectedIndex;
            foreach (DoctorOld item in ldtrO)
            {
                if (item.Name.Equals(data))
                {
                    //c.SelectedItem = item;
                    re = item.ID;
                    break;
                }
            }
            return re;
        }
        public String getlDtrNameByID(String data)
        {
            String re = "";
            //if (c.Items.Count == 0) return "";
            //c.SelectedIndex = c.SelectedItem == null ? 0 : c.SelectedIndex;
            foreach (DoctorOld item in ldtrO)
            {
                if (item.ID.Equals(data))
                {
                    //c.SelectedItem = item;
                    re = item.Name;
                    break;
                }
            }
            return re;
        }
        public void setCboDoctor(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectAll();
            int i = 0;
            if (ldtrO.Count <= 0) getlDtr();
            item = new ComboBoxItem();
            item.Value = "";
            item.Text = "";
            c.Items.Add(item);
            foreach (DoctorOld cus1 in ldtrO)
            {
                item = new ComboBoxItem();
                item.Value = cus1.ID;
                item.Text = cus1.Name;
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
