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
    public class OldCashAccountDB
    {
        public OldCashAccount oca;
        ConnectDB conn;
        public List<OldCashAccount> lFpf;

        public OldCashAccountDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            oca = new OldCashAccount();
            lFpf = new List<OldCashAccount>();
            oca.CashID = "CashID";
            oca.CashName = "CashName";
            oca.IntLock = "IntLock";
            oca.active = "active";

            oca.table = "CashAccount";
            oca.pkField = "CashID";
        }
        public DataTable selectByCreditCardName()
        {
            DataTable dt = new DataTable();
            String sql = "select oca." + oca.CashID + ",oca." + oca.CashName + " " +
                "From " + oca.table + " oca " +
                "Where active = '1' " +
                "Order By oca." + oca.CashName;
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select oca.*  " +
                "From " + oca.table + " oca " +
                " " +
                "Where oca." + oca.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public String getList(String id)
        {
            String re = "";
            if (lFpf.Count <= 0)
            {
                getlCashAccount();
            }
            foreach (OldCashAccount sex in lFpf)
            {
                if (sex.CashID.Equals(id))
                {
                    re = sex.CashName;
                    break;
                }
            }
            return re;
        }
        public void getlCashAccount()
        {
            //lDept = new List<Position>();
            lFpf.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                OldCashAccount itm1 = new OldCashAccount();
                itm1.CashID = row[oca.CashID].ToString();
                itm1.CashName = row[oca.CashName].ToString();

                lFpf.Add(itm1);
            }
        }
        public C1ComboBox setCboCashAccount(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectC1();
            //String aaa = "";
            if (lFpf.Count <= 0) getlCashAccount();
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (OldCashAccount row in lFpf)
            {
                item = new ComboBoxItem();
                item.Value = row.CashID;
                item.Text = row.CashName;
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