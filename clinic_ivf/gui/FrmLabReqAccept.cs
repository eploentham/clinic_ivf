﻿using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1SuperTooltip;
using clinic_ivf.control;
using clinic_ivf.object1;
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
    public partial class FrmLabReqAccept : Form
    {
        IvfControl ic;
        MainMenu menu;

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;
        int colRqId = 1, colRqReqNum = 2, colRqHn = 3, colRqVn = 4, colRqName = 5, colPttName=6, colRqDate = 7, colRqRemark = 8;

        C1FlexGrid grfReq;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;

        public FrmLabReqAccept(IvfControl ic, MainMenu m)
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
            txtDateEnd.Value = System.DateTime.Now;
            txtDateStart.Value = System.DateTime.Now;

            sB1.Text = "";
            bg = txtHn.BackColor;
            fc = txtHn.ForeColor;
            ff = txtHn.Font;

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();

            //btnNew.Click += BtnNew_Click;
            btnSearch.Click += BtnSearch_Click;

            initGrfReq();
            setGrfReq();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setGrfReq();
        }

        private void initGrfReq()
        {
            grfReq = new C1FlexGrid();
            grfReq.Font = fEdit;
            grfReq.Dock = System.Windows.Forms.DockStyle.Fill;
            grfReq.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            grfReq.AfterRowColChange += GrfReq_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("&รับ request", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfReq.ContextMenu = menuGw;
            gB.Controls.Add(grfReq);

            theme1.SetTheme(grfReq, "Office2010Blue");
        }
        private void ContextMenu_edit(object sender, System.EventArgs e)
        {
            String chk = "", name = "", id = "";
            id = grfReq[grfReq.Row, colRqId] != null ? grfReq[grfReq.Row, colRqId].ToString() : "";
            chk = grfReq[grfReq.Row, colRqReqNum] != null ? grfReq[grfReq.Row, colRqReqNum].ToString() : "";
            name = grfReq[grfReq.Row, colRqName] != null ? grfReq[grfReq.Row, colRqName].ToString() : "";
            if (MessageBox.Show("ต้องการ รับ request  \n  req number " + chk + " \n name " + name, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                //grfReq.Rows.Remove(grfReq.Row);
                acceptLabOPUAdd(id, name);
            }
        }
        private void GrfReq_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;
            String vn = "";

            //grfAddr.DataSource = xC.iniDB.addrDB.selectByTableId1(vn);
        }
        private void setGrfReq()
        {
            String startdate = "", enddate = "";
            DateTime datestart, dateend;
            String datestart1 = "", dateend1 = "";
            if (DateTime.TryParse(txtDateStart.Text, out datestart))
            {
                datestart1 = datestart.ToString("yyyy-MM-dd");
            }
            else
            {
                datestart1 = ic.datetoDB(txtDateStart.Text);
            }
            if (DateTime.TryParse(txtDateEnd.Text, out datestart))
            {
                dateend1 = datestart.ToString("yyyy-MM-dd");
            }
            else
            {
                dateend1 = ic.datetoDB(txtDateEnd.Text);
            }
            grfReq.Clear();
            grfReq.Cols.Count = 9;
            grfReq.Rows.Count = 1;
            DataTable dt = new DataTable();
            grfReq.DataSource = null;
            dt = ic.ivfDB.oJsDB.selectByStatusUnAccept1(datestart1, dateend1);
            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            //grfCu.Rows.Count = 41;
            //grfCu.Cols.Count = 4;
            C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfReq.Cols[colRqReqNum].Editor = txt;
            grfReq.Cols[colRqHn].Editor = txt;
            grfReq.Cols[colRqVn].Editor = txt;
            grfReq.Cols[colRqName].Editor = txt;

            grfReq.Cols[colRqHn].Width = 120;
            grfReq.Cols[colRqVn].Width = 120;
            grfReq.Cols[colRqName].Width = 120;
            grfReq.Cols[colRqDate].Width = 100;
            grfReq.Cols[colPttName].Width = 200;

            grfReq.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfReq.Cols[colRqReqNum].Caption = "req number";
            grfReq.Cols[colRqHn].Caption = "HN";
            grfReq.Cols[colRqVn].Caption = "VN";
            grfReq.Cols[colRqName].Caption = "LAB Name";
            grfReq.Cols[colPttName].Caption = "Patient Name";
            grfReq.Cols[colRqDate].Caption = "Date";
            grfReq.Cols[colRqRemark].Caption = "Remark";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                Row row1 = grfReq.Rows.Add();
                row1[colRqId] = row["ID"].ToString();
                row1[colRqReqNum] = row["ID"].ToString();
                row1[colRqHn] = row["PIDS"].ToString();
                row1[colRqVn] = row["VN"].ToString();
                row1[colRqName] = row["SName"].ToString();
                row1[colPttName] = row["pttname"].ToString();
                row1[colRqDate] = ic.datetoShow(row["Date"].ToString());
                row1[0] = i;
                i++;
            }
            grfReq.Cols[colRqId].Visible = false;
            grfReq.Cols[colRqVn].Visible = false;
        }
        private void acceptLabOPUAdd(String reqId, String name)
        {
            ic.cStf.staff_id = "";
            FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            frm.ShowDialog(this);
            if (!ic.cStf.staff_id.Equals(""))
            {
                String re = ic.ivfDB.lbReqDB.UpdateStatusRequestAccept(reqId, ic.cStf.staff_id);
                int chk = 0;
                if (int.TryParse(re, out chk))
                {
                    LabOpu opu = new LabOpu();
                    LabRequest lbreq = new LabRequest();
                    lbreq = ic.ivfDB.lbReqDB.selectByPk1(reqId);
                    opu.opu_id = "";
                    opu.opu_code = ic.ivfDB.copDB.genOPUDoc();
                    opu.embryo_freez_stage = "";
                    opu.embryoid_freez_position = "";
                    opu.hn_male = "";
                    opu.hn_female = lbreq.hn_female;
                    opu.name_male = "";
                    opu.name_female = lbreq.name_female;
                    opu.remark = "";
                    opu.dob_female = "";
                    opu.dob_male = "";
                    opu.doctor_id = "";
                    opu.proce_id = "";
                    opu.opu_date = System.DateTime.Now.ToString("yyyy-MM-dd");
                    opu.req_id = reqId;

                    setGrfReq();
                    FrmLabOPUAdd frm1 = new FrmLabOPUAdd(ic, reqId);
                    String txt = "";
                    if (!name.Equals(""))
                    {
                        txt = "ป้อน LAB OPU " + name;
                    }
                    else
                    {
                        txt = "ป้อน LAB OPU ใหม่ ";
                    }

                    frm1.FormBorderStyle = FormBorderStyle.None;
                    menu.AddNewTab(frm1, txt);
                }
                else
                {
                    MessageBox.Show("ไม่สามารถ update status accept", "error");
                }
                
            }
        }
        private void FrmLabReqAccept_Load(object sender, EventArgs e)
        {

        }
    }
}
