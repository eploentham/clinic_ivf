﻿using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1SuperTooltip;
using clinic_ivf.control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.gui
{
    public partial class FrmVisitView : Form
    {
        IvfControl ic;
        MainMenu menu;

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;

        int colID=1, colVN = 3, colHn = 2, colName = 4, colVsDate = 5, colVsTime=6, colVsEtime=7, colStatus=8;
        int colPttId = 1, colPttHn = 2, colPttName = 3, colPttRemark = 4;

        C1FlexGrid grfPtt;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        ContextMenu menuGw;

        public FrmVisitView(IvfControl ic, MainMenu m)
        {
            InitializeComponent();
            this.ic = ic;
            menu = m;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);

            //C1ThemeController.ApplicationTheme = ic.iniC.themeApplication;
            theme1.Theme = ic.iniC.themeApplication;
            theme1.SetTheme(sB, "BeigeOne");

            sB1.Text = "";
            bg = txtSearch.BackColor;
            fc = txtSearch.ForeColor;
            ff = txtSearch.Font;

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            chkHn.Checked = false;
            chkVisit.Checked = true;

            btnNew.Click += BtnNew_Click;
            txtSearch.KeyUp += TxtSearch_KeyUp;
            chkToday.CheckedChanged += ChkToday_CheckedChanged;

            initGrfPtt();
            setGrfPtt();
        }

        private void ChkToday_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setGrfPtt();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            VisitAdd("","", "","");
        }
        private void VisitAdd(String pttId, String vsId, String name, String pttOid)
        {
            long idold = 0, idnew = 0, id1=0, id2=0;
            long.TryParse(pttId, out id1);
            long.TryParse(pttOid, out id2);
            idnew = id1 > id2 ? id1 : id2;
            idold = id1 < id2 ? id2 : id1;
            
            FrmVisitAdd frm = new FrmVisitAdd(ic, pttId, vsId, pttOid);
            String txt = "";
            if (!name.Equals(""))
            {
                txt = "ป้อน Visit " + name;
            }
            else
            {
                txt = "ป้อน Visit ใหม่ ";
            }

            //frm.FormBorderStyle = FormBorderStyle.None;
            frm.ShowDialog(this);
            chkHn.Checked = false;
            chkVisit.Checked = true;
            txtSearch.Value = "";
            setGrfPtt();

            //menu.AddNewTab(frm, txt);
        }
        private void PatientEdit(String pttId, String vsId, String name, String pttOid)
        {
            long idold = 0, idnew = 0, id1 = 0, id2 = 0;
            long.TryParse(pttId, out id1);
            long.TryParse(pttOid, out id2);
            idnew = id1 > id2 ? id1 : id2;
            idold = id1 < id2 ? id2 : id1;

            FrmPatientAdd frm = new FrmPatientAdd(ic, pttId, "", pttOid);
            String txt = "";
            if (!name.Equals(""))
            {
                txt = "แก้ไข Patient " + name;
            }
            else
            {
                txt = "แก้ไข Patient ใหม่ ";
            }
            
            //frm.FormBorderStyle = FormBorderStyle.None;
            //frm.ShowDialog(this);
            //chkHn.Checked = false;
            //chkVisit.Checked = true;
            //txtSearch.Value = "";
            //setGrfPtt();

            menu.AddNewTab(frm, txt);
        }
        private void TxtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.Enter)
            {
                if (chkVisit.Checked)
                {
                    setGrfPtt();
                }
                else
                {
                    setGrfPttHn(txtSearch.Text);
                }
                
            }
            else
            {
                setGrfSearch();
            }
        }
        private void setGrfSearch()
        {
            if (txtSearch.Text.Length >= 2)
            {
                if (chkVisit.Checked)
                {
                    setGrfPtt();
                }
                else
                {
                    setGrfPttHn(txtSearch.Text);
                }
            }
        }
        private void initGrfPtt()
        {
            grfPtt = new C1FlexGrid();
            grfPtt.Font = fEdit;
            grfPtt.Dock = System.Windows.Forms.DockStyle.Fill;
            grfPtt.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            grfPtt.AfterRowColChange += GrfReq_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);

            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            
            gB.Controls.Add(grfPtt);

            theme1.SetTheme(grfPtt, "Office2010Blue");

        }
        private void GrfReq_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;
            String vn = "";

            //grfAddr.DataSource = xC.iniDB.addrDB.selectByTableId1(vn);
        }
        private void setGrfPtt()
        {
            if (ic.iniC.statusAppDonor.Equals("1"))
            {
                setGrfPttDonor(txtSearch.Text);
            }
            else
            {
                setGrfPtt(txtSearch.Text);
            }
        }
        private void setGrfPttDonor(String search)
        {
            //grfDept.Rows.Count = 7;
            grfPtt.Clear();
            DataTable dt = new DataTable();

            if (search.Equals(""))
            {
                //String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
                if (chkToday.Checked)
                {
                    dt = ic.ivfDB.vsDB.selectCurrentVisitNoVisit();
                }
                else
                {
                    dt = ic.ivfDB.vsDB.selectCurrentVisit();
                }
                
            }
            else
            {
                //grfPtt.DataSource = ic.ivfDB.vsOldDB.selectCurrentVisit(search);
            }

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfPtt.Rows.Count = dt.Rows.Count + 1;
            grfPtt.Cols.Count = 9;
            C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfPtt.Cols[colHn].Editor = txt;
            grfPtt.Cols[colName].Editor = txt;
            grfPtt.Cols[colVsDate].Editor = txt;

            grfPtt.Cols[colVN].Width = 120;
            grfPtt.Cols[colHn].Width = 120;
            grfPtt.Cols[colName].Width = 300;
            grfPtt.Cols[colVsDate].Width = 100;
            grfPtt.Cols[colVsTime].Width = 80;
            grfPtt.Cols[colVsEtime].Width = 80;
            grfPtt.Cols[colStatus].Width = 200;

            grfPtt.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfPtt.Cols[colVN].Caption = "VN";
            grfPtt.Cols[colHn].Caption = "HN";
            grfPtt.Cols[colName].Caption = "Name";
            grfPtt.Cols[colVsDate].Caption = "Date";
            grfPtt.Cols[colVsTime].Caption = "Time visit";
            grfPtt.Cols[colVsEtime].Caption = "Time finish";
            grfPtt.Cols[colStatus].Caption = "Status";

            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("&แก้ไข Visit", new EventHandler(ContextMenu_edit_vs_donor));
            menuGw.MenuItems.Add("&แก้ไข ประวัติ", new EventHandler(ContextMenu_edit_ptt));
            grfPtt.ContextMenu = menuGw;

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                grfPtt[i, 0] = i;
                grfPtt[i, colID] = row["id"].ToString();
                grfPtt[i, colVN] = row["VN"].ToString();
                grfPtt[i, colHn] = row["PIDS"].ToString();
                grfPtt[i, colName] = row["PName"].ToString();
                grfPtt[i, colVsDate] = ic.datetoShow(row["VDate"]);
                grfPtt[i, colVsTime] = row["VStartTime"].ToString();
                grfPtt[i, colVsEtime] = row["VEndTime"].ToString();
                grfPtt[i, colStatus] = row["VName"].ToString();
                //if (i % 2 == 0)
                //    grfPtt.Rows[i].StyleNew.BackColor = color;
                i++;
            }
            //menuGw = new ContextMenu();
            //grfPtt.ContextMenu = menuGw;
            grfPtt.Cols[colID].Visible = false;
            grfPtt.Cols[colVN].AllowEditing = false;
            grfPtt.Cols[colHn].AllowEditing = false;
            grfPtt.Cols[colName].AllowEditing = false;
            grfPtt.Cols[colVsDate].AllowEditing = false;
            grfPtt.Cols[colVsTime].AllowEditing = false;
            grfPtt.Cols[colVsEtime].AllowEditing = false;
            grfPtt.Cols[colStatus].AllowEditing = false;
            theme1.SetTheme(grfPtt, ic.theme);

        }
        private void setGrfPtt(String search)
        {
            //grfDept.Rows.Count = 7;
            //grfPtt.Clear();
            DataTable dt = new DataTable();
            
            if (search.Equals(""))
            {
                //String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
                dt = ic.ivfDB.ovsDB.selectCurrentVisit();
            }
            else
            {
                //grfPtt.DataSource = ic.ivfDB.vsOldDB.selectCurrentVisit(search);
            }

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfPtt.Rows.Count = 1;
            grfPtt.Rows.Count = dt.Rows.Count+1;
            grfPtt.Cols.Count = 9;
            //C1TextBox txt = new C1TextBox();
            ////C1ComboBox cboproce = new C1ComboBox();
            ////ic.ivfDB.itmDB.setCboItem(cboproce);
            //grfPtt.Cols[colHn].Editor = txt;
            //grfPtt.Cols[colName].Editor = txt;
            //grfPtt.Cols[colVsDate].Editor = txt;

            grfPtt.Cols[colVN].Width = 120;
            grfPtt.Cols[colHn].Width = 120;
            grfPtt.Cols[colName].Width = 300;
            grfPtt.Cols[colVsDate].Width = 100;
            grfPtt.Cols[colVsTime].Width = 80;
            grfPtt.Cols[colVsEtime].Width = 80;
            grfPtt.Cols[colStatus].Width = 200;

            grfPtt.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfPtt.Cols[colVN].Caption = "VN";
            grfPtt.Cols[colHn].Caption = "HN";
            grfPtt.Cols[colName].Caption = "Name";
            grfPtt.Cols[colVsDate].Caption = "Date";
            grfPtt.Cols[colVsTime].Caption = "Time visit";
            grfPtt.Cols[colVsEtime].Caption = "Time finish";
            grfPtt.Cols[colStatus].Caption = "Status";

            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("&ออก Visit", new EventHandler(ContextMenu_edit_vs));
            menuGw.MenuItems.Add("&แก้ไข ประวัติ", new EventHandler(ContextMenu_edit_ptt));
            grfPtt.ContextMenu = menuGw;

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            foreach(DataRow row in dt.Rows)
            {
                grfPtt[i, 0] = i;
                grfPtt[i, colID] = row["id"].ToString();
                grfPtt[i, colVN] = ic.showVN(row["VN"].ToString());
                grfPtt[i, colHn] = ic.showHN(row["patient_hn"].ToString(), row["patient_year"].ToString());
                grfPtt[i, colName] = row["PName"].ToString();
                grfPtt[i, colVsDate] = ic.datetoShow(row["VDate"]);
                grfPtt[i, colVsTime] = ic.timetoShow(row["VStartTime"].ToString());
                grfPtt[i, colVsEtime] = ic.timetoShow(row["VEndTime"].ToString());
                grfPtt[i, colStatus] = row["VName"].ToString();
                //if (i % 2 == 0)
                //    grfPtt.Rows[i].StyleNew.BackColor = color;
                i++;
            }
            //menuGw = new ContextMenu();
            //grfPtt.ContextMenu = menuGw;
            grfPtt.Cols[colID].Visible = false;
            grfPtt.Cols[colVN].AllowEditing = false;
            grfPtt.Cols[colHn].AllowEditing = false;
            grfPtt.Cols[colName].AllowEditing = false;
            grfPtt.Cols[colVsDate].AllowEditing = false;
            grfPtt.Cols[colVsTime].AllowEditing = false;
            grfPtt.Cols[colVsEtime].AllowEditing = false;
            grfPtt.Cols[colStatus].AllowEditing = false;
            theme1.SetTheme(grfPtt, ic.theme);

        }
        private void setGrfPttHn(String search)
        {
            //grfDept.Rows.Count = 7;
            grfPtt.Clear();
            grfPtt.DataSource = null;
            grfPtt.Rows.Count = 1;
            DataTable dt = new DataTable();
            if (search.Equals(""))
            {
                String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
                //grfPtt.DataSource = ic.ivfDB.pttDB.selectByDate1(date);
                //grfPtt.DataSource = ic.ivfDB.pttDB.selectByDate1(date);
            }
            else
            {
                //grfPtt.DataSource = ic.ivfDB.pttDB.selectBySearch(search);
                if (ic.iniC.statusAppDonor.Equals("1"))
                {
                    dt = ic.ivfDB.pttDB.selectBySearch(search);
                }
                else
                {
                    dt = ic.ivfDB.pttOldDB.selectBySearch(search);
                }
            }

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            //grfCu.Rows.Count = 41;
            //grfCu.Cols.Count = 4;
            C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfPtt.Cols[colPttHn].Editor = txt;
            grfPtt.Cols[colPttName].Editor = txt;
            grfPtt.Cols[colPttRemark].Editor = txt;

            grfPtt.Cols[colPttName].Width = 250;
            grfPtt.Cols[colPttHn].Width = 120;
            grfPtt.Cols[colPttRemark].Width = 300;

            grfPtt.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfPtt.Cols[colPttHn].Caption = "HN";
            grfPtt.Cols[colPttName].Caption = "Name";
            grfPtt.Cols[colPttRemark].Caption = "Remark";

            menuGw = new ContextMenu();
            menuGw.MenuItems.Add("&ออก Visit", new EventHandler(ContextMenu_edit_vs));
            menuGw.MenuItems.Add("&แก้ไข ประวัติ", new EventHandler(ContextMenu_edit_ptt));
            grfPtt.ContextMenu = menuGw;

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                Row row1 = grfPtt.Rows.Add();
                row1[0] = i;
                row1[colPttId] = row["PID"].ToString();
                row1[colPttHn] = row["PIDS"].ToString();
                row1[colPttName] = row["name"].ToString();
                row1[colPttRemark] = row["EmergencyPersonalContact"].ToString();
                if (i % 2 == 0)
                    grfPtt.Rows[i].StyleNew.BackColor = color;
                i++;
            }
            grfPtt.Cols[colPttId].Visible = false;
            grfPtt.Cols[colPttHn].AllowEditing = false;
            grfPtt.Cols[colPttName].AllowEditing = false;
            grfPtt.Cols[colPttRemark].AllowEditing = false;
            theme1.SetTheme(grfPtt, ic.theme);

        }
        private void ContextMenu_edit_vs_donor(object sender, System.EventArgs e)
        {
            String hn = "", name = "", vsid = "", vn = "";
            vsid = grfPtt[grfPtt.Row, colID] != null ? grfPtt[grfPtt.Row, colID].ToString() : "";
            vn = grfPtt[grfPtt.Row, colVN] != null ? grfPtt[grfPtt.Row, colVN].ToString() : "";
            hn = grfPtt[grfPtt.Row, colHn] != null ? grfPtt[grfPtt.Row, colHn].ToString() : "";
            name = grfPtt[grfPtt.Row, colPttName] != null ? grfPtt[grfPtt.Row, colPttName].ToString() : "";
            //if (MessageBox.Show("ต้องการ แก้ไข Patient  \n  hn number " + chk + " \n name " + name, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            //grfReq.Rows.Remove(grfReq.Row);
            if (ic.iniC.statusAppDonor.Equals("1"))
            {
                VisitAdd("", vsid, name, "");
            }
            else
            {
                VisitAdd("", vn, name, vsid);
            }
            //}
        }
        private void ContextMenu_edit_vs(object sender, System.EventArgs e)
        {
            String hn = "", name = "", pttid = "", vn="";
            pttid = grfPtt[grfPtt.Row, colID] != null ? grfPtt[grfPtt.Row, colID].ToString() : "";
            vn = grfPtt[grfPtt.Row, colVN] != null ? grfPtt[grfPtt.Row, colVN].ToString() : "";
            hn = grfPtt[grfPtt.Row, colHn] != null ? grfPtt[grfPtt.Row, colHn].ToString() : "";
            name = grfPtt[grfPtt.Row, colPttName] != null ? grfPtt[grfPtt.Row, colPttName].ToString() : "";
            //if (MessageBox.Show("ต้องการ แก้ไข Patient  \n  hn number " + chk + " \n name " + name, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            //grfReq.Rows.Remove(grfReq.Row);
            if (ic.iniC.statusAppDonor.Equals("1"))
            {
                VisitAdd(pttid, vn, name, "");
            }
            else
            {
                VisitAdd("", vn, name, pttid);
            }
            //}
        }
        private void ContextMenu_edit_ptt(object sender, System.EventArgs e)
        {
            String hn = "", name = "", pttid = "", vn = "";
            pttid = grfPtt[grfPtt.Row, colPttId] != null ? grfPtt[grfPtt.Row, colPttId].ToString() : "";
            vn = grfPtt[grfPtt.Row, colVN] != null ? grfPtt[grfPtt.Row, colVN].ToString() : "";
            hn = grfPtt[grfPtt.Row, colPttHn] != null ? grfPtt[grfPtt.Row, colPttHn].ToString() : "";
            name = grfPtt[grfPtt.Row, colName] != null ? grfPtt[grfPtt.Row, colName].ToString() : "";
            //if (MessageBox.Show("ต้องการ แก้ไข Patient  \n  hn number " + chk + " \n name " + name, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            //grfReq.Rows.Remove(grfReq.Row);
            if (ic.iniC.statusAppDonor.Equals("1"))
            {
                PatientEdit(pttid, vn, name, "");
            }
            else
            {
                PatientEdit("", vn, name, pttid);
            }
            //}
        }
        private void FrmVisitView_Load(object sender, EventArgs e)
        {
            theme1.SetTheme(groupBox1, ic.theme);
            theme1.SetTheme(gB, ic.theme);
            
            foreach (Control c in groupBox1.Controls)
            {
                theme1.SetTheme(c, ic.theme);
            }
            foreach (Control c in gB.Controls)
            {
                theme1.SetTheme(c, ic.theme);
            }
            btnNew.Hide();
        }
    }
}
