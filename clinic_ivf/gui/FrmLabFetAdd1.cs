﻿using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1SuperTooltip;
using clinic_ivf.control;
using clinic_ivf.object1;
using clinic_ivf.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.gui
{
    public partial class FrmLabFetAdd1 : Form
    {
        IvfControl ic;
        String reqId = "", fetId = "";
        LabRequest lbReq;
        LabFet fet;

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;
        int colDay2ID = 1, colDay2Num = 2, colDay2Desc = 3, colDay2Desc1 = 4, colDay2Desc2 = 5, colDay2Edit = 6;
        int colDay3ID = 1, colDay3Num = 2, colDay3Desc = 3, colDay3Desc1 = 4, colDay3Desc2 = 5, colDay3Edit = 6;
        int colDay5ID = 1, colDay5Num = 2, colDay5Desc = 3, colDay5Desc1 = 4, colDay5Desc2 = 5, colDay5Edit = 6;
        int colDay6ID = 1, colDay6Num = 2, colDay6Desc = 3, colDay6Desc1 = 4, colDay6Desc2 = 5, colDay6Edit = 6;

        int colDay2ImgId = 1, colDay2ImgPic = 3, colDay2ImgNun = 2, colDay2ImgDesc0 = 4, colDay2PathPic = 5;

        C1FlexGrid grfDay2, grfDay3, grfDay5, grfDay6, grfDay2Img, grfDay3Img, grfDay5Img, grfDay6Img;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        Color color;
        Boolean flagDay2Img = false, flagDay3Img = false, flagDay5Img = false, flagDay6Img = false;
        Boolean grf2Focus = false, grf3Focus = false, grf5Focus = false, grf6Focus = false;
        private bool prefixSeen;

        public FrmLabFetAdd1(IvfControl ic, String reqid, String fetid)
        {
            InitializeComponent();
            this.ic = ic;
            reqId = reqid;
            fetId = fetid;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);

            //C1ThemeController.ApplicationTheme = ic.iniC.themeApplication;
            //theme1.Theme = C1ThemeController.ApplicationTheme;
            
            color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            cboRemark.DropDownOpened += CboRemark_DropDownOpened;
            cboRemark.DropDownClosed += CboRemark_DropDownClosed;
            
            sB1.Text = "";
            bg = txtHnFeMale.BackColor;
            fc = txtHnFeMale.ForeColor;
            ff = txtHnFeMale.Font;

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            fet = new LabFet();
            lbReq = new LabRequest();

            ic.ivfDB.proceDB.setCboLabProce(cboOpuProce, objdb.LabProcedureDB.StatusLab.FETProcedure);
            ic.ivfDB.dtrOldDB.setCboDoctor(cboDoctor, "");
            ic.ivfDB.stfDB.setCboEmbryologist(cboEmbryoForEtEmbryologist, "");
            ic.ivfDB.stfDB.setCboEmbryologist(cboEmbryologistAppv, "");
            ic.ivfDB.stfDB.setCboEmbryologist(cboEmbryologistReport, "");
            ic.ivfDB.stfDB.setCboEmbryologist(cboEmbryologistDay2, "");
            ic.ivfDB.stfDB.setCboEmbryologist(cboEmbryologistDay3, "");
            ic.ivfDB.stfDB.setCboEmbryologist(cboEmbryologistDay5, "");
            ic.ivfDB.stfDB.setCboEmbryologist(cboEmbryologistDay6, "");
            ic.ivfDB.stfDB.setCboEmbryologist(cboCheckedDay2, "");
            ic.ivfDB.stfDB.setCboEmbryologist(cboCheckedDay3, "");
            ic.ivfDB.stfDB.setCboEmbryologist(cboCheckedDay5, "");
            ic.ivfDB.stfDB.setCboEmbryologist(cboCheckedDay6, "");
            ic.ivfDB.fdtDB.setCboFETFreezeMedia(cboEmbryoFreezMedia);

            ic.ivfDB.opuDB.setCboRemark(cboRemark);

            //stt.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.Gold;

            setClick();

            setKeyPress();

            btnHnSearch.Click += BtnHnSearch_Click;
            btnDonorSearch.Click += BtnDonorSearch_Click;
            txtFreezeNo.KeyUp += TxtFreezeNo_KeyUp;

            setTheme();
            setFocusColor();
            initGrf();
            setControl();
            setGrf();

        }

        private void TxtFreezeNo_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.Enter)
            {
                int chk = 0;
                if(int.TryParse(txtFreezeNo.Text, out chk))
                {
                    if (MessageBox.Show("ต้องการ ให้เพิ่ม Embryo Development จำนวน " + chk + " Embryo", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                    {
                        String cnt = "", re = "";
                        ic.cStf.staff_id = "";
                        FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                        frm.ShowDialog(this);
                        if (!ic.cStf.staff_id.Equals(""))
                        {
                            FrmWaiting frmW = new FrmWaiting();
                            frmW.Show();
                            try
                            {
                                Boolean chkSave = false;
                                frmW.pB.Minimum = 1;
                                frmW.pB.Maximum = chk;
                                for (int i = 1; i <= chk; i++)
                                {
                                    LabOpuEmbryoDev opuEmDev = new LabOpuEmbryoDev();
                                    opuEmDev.opu_embryo_dev_id = "";
                                    opuEmDev.opu_fet_id = txtID.Text;
                                    opuEmDev.opu_embryo_dev_no = i.ToString();
                                    opuEmDev.desc0 = "";
                                    opuEmDev.active = "1";
                                    opuEmDev.remark = "";
                                    opuEmDev.path_pic = "";
                                    opuEmDev.date_create = "";
                                    opuEmDev.date_modi = "";
                                    opuEmDev.date_cancel = "";
                                    opuEmDev.user_create = ic.cStf.staff_id;
                                    opuEmDev.user_modi = "";
                                    opuEmDev.user_cancel = "";
                                    opuEmDev.desc1 = "";
                                    opuEmDev.desc2 = "";
                                    opuEmDev.desc3 = "";
                                    opuEmDev.day = "2";
                                    re = ic.ivfDB.opuEmDevDB.insertLabOpuEmbryoDev(opuEmDev, ic.cStf.staff_id);
                                    opuEmDev.day = "3";
                                    re = ic.ivfDB.opuEmDevDB.insertLabOpuEmbryoDev(opuEmDev, ic.cStf.staff_id);
                                    opuEmDev.day = "5";
                                    re = ic.ivfDB.opuEmDevDB.insertLabOpuEmbryoDev(opuEmDev, ic.cStf.staff_id);
                                    opuEmDev.day = "6";
                                    re = ic.ivfDB.opuEmDevDB.insertLabOpuEmbryoDev(opuEmDev, ic.cStf.staff_id);
                                    long chk1 = 0;
                                    if (long.TryParse(re, out chk1))
                                    {
                                        chkSave = true;
                                        //MessageBox.Show("Error", "");
                                    }
                                    else
                                    {
                                        chkSave = false;
                                    }
                                    frmW.pB.Value = i;
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                            finally
                            {
                                frmW.Dispose();
                            }
                            setGrfDay2();
                            setGrfDay3();
                            setGrfDay5();
                            setGrfDay6();
                            setGrfDay2Img();
                            setGrfDay3Img();
                            setGrfDay5Img();
                            setGrfDay6Img();
                        }
                    }
                }
            }
        }

        private void setTheme()
        {
            theme1.SetTheme(sB, "BeigeOne");
            theme1.SetTheme(this, ic.iniC.themeFET);
            theme1.SetTheme(groupBox1, ic.iniC.themeFET);
            theme1.SetTheme(groupBox3, ic.iniC.themeFET);
            theme1.SetTheme(groupBox4, ic.iniC.themeFET);
            theme1.SetTheme(groupBox5, ic.iniC.themeFET);
            theme1.SetTheme(groupBox7, ic.iniC.themeFET);
            theme1.SetTheme(groupBox2, ic.iniC.themeFET);
            theme1.SetTheme(c1CommandDock1, ic.iniC.themeFET);
            theme1.SetTheme(tC1, ic.iniC.themeFET);
            theme1.SetTheme(gbDay2, ic.iniC.themeFET);
            theme1.SetTheme(gbDay3, ic.iniC.themeFET);
            theme1.SetTheme(gbDay5, ic.iniC.themeFET);
            theme1.SetTheme(gbDay6, ic.iniC.themeFET);
            theme1.SetTheme(pn2, ic.iniC.themeFET);
            theme1.SetTheme(pn5, ic.iniC.themeFET);
            theme1.SetTheme(pn3, ic.iniC.themeFET);
            theme1.SetTheme(pn6, ic.iniC.themeFET);
            theme1.SetTheme(panel3, ic.iniC.themeFET);
            theme1.SetTheme(panel4, ic.iniC.themeFET);
            theme1.SetTheme(panel5, ic.iniC.themeFET);
            theme1.SetTheme(panel6, ic.iniC.themeFET);
            theme1.SetTheme(splitContainer1, ic.iniC.themeFET);
            theme1.SetTheme(splitContainer2, ic.iniC.themeFET);
            theme1.SetTheme(splitContainer3, ic.iniC.themeFET);
            theme1.SetTheme(splitContainer4, ic.iniC.themeFET);
            theme1.SetTheme(splitContainer5, ic.iniC.themeFET);

            foreach (Control ctl in groupBox1.Controls)
            {
                theme1.SetTheme(ctl, ic.iniC.themeFET);
            }
            foreach (Control ctl in groupBox3.Controls)
            {
                theme1.SetTheme(ctl, ic.iniC.themeFET);
            }
            foreach (Control ctl in groupBox4.Controls)
            {
                theme1.SetTheme(ctl, ic.iniC.themeFET);
            }
            foreach (Control ctl in groupBox5.Controls)
            {
                theme1.SetTheme(ctl, ic.iniC.themeFET);
            }
            foreach (Control ctl in groupBox7.Controls)
            {
                theme1.SetTheme(ctl, ic.iniC.themeFET);
            }
            //foreach (ComboBoxItemList ctl in cboOpuProce.Items) 
            //{
            //    theme1.SetTheme(ctl, ic.iniC.themeFET);
            //}
            foreach (Control ctl in pn2.Controls)
            {
                theme1.SetTheme(ctl, ic.iniC.themeFET);
            }
            foreach (Control ctl in pn3.Controls)
            {
                theme1.SetTheme(ctl, ic.iniC.themeFET);
            }
            foreach (Control ctl in pn5.Controls)
            {
                theme1.SetTheme(ctl, ic.iniC.themeFET);
            }
            foreach (Control ctl in pn6.Controls)
            {
                theme1.SetTheme(ctl, ic.iniC.themeFET);
            }
            foreach (Control ctl in panel3.Controls)
            {
                theme1.SetTheme(ctl, ic.iniC.themeFET);
            }
            foreach (Control ctl in panel4.Controls)
            {
                theme1.SetTheme(ctl, ic.iniC.themeFET);
            }
            foreach (Control ctl in panel5.Controls)
            {
                theme1.SetTheme(ctl, ic.iniC.themeFET);
            }
            foreach (Control ctl in panel6.Controls)
            {
                theme1.SetTheme(ctl, ic.iniC.themeFET);
            }
            //foreach (Control ctl in tC1.Controls)
            //{
            //    theme1.SetTheme(ctl, ic.iniC.themeFET);
            //}
            theme1.SetTheme(cboOpuProce, ic.iniC.themeFET);
            theme1.SetTheme(cboDoctor, ic.iniC.themeFET);
            theme1.SetTheme(cboRemark, ic.iniC.themeFET);
            //theme1.SetTheme(tC1, ic.iniC.themeFET);
        }
        private void CboRemark_DropDownClosed(object sender, DropDownClosedEventArgs e)
        {
            //throw new NotImplementedException();
            //theme1.SetTheme(cboRemark, "Office2016Black");
        }

        private void CboRemark_DropDownOpened(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //theme1.SetTheme(cboOpuProce, "ExpressionDark");
        }

        private void BtnDonorSearch_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmSearchHn frm = new FrmSearchHn(ic, FrmSearchHn.StatusConnection.hostEx, FrmSearchHn.StatusSearch.DonorSearch, FrmSearchHn.StatusSearchTable.VisitSearch);
            frm.ShowDialog(this);
            txtHnDonor.Value = ic.sVsOld.PIDS;
            txtNameDonor.Value = ic.sVsOld.PName;
        }
        private void BtnHnSearch_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmSearchHn frm = new FrmSearchHn(ic, FrmSearchHn.StatusConnection.host, FrmSearchHn.StatusSearch.PttSearch, FrmSearchHn.StatusSearchTable.VisitSearch);
            frm.ShowDialog(this);
            txtHnMale.Value = ic.sVsOld.PIDS;
            txtNameMale.Value = ic.sVsOld.PName;
        }
        private void setFocusColor()
        {
            this.txtHnFeMale.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtHnFeMale.Enter += new System.EventHandler(this.textBox_Enter);

            //this.txtPosiNameT.Leave += new System.EventHandler(this.textBox_Leave);
            //this.txtPosiNameT.Enter += new System.EventHandler(this.textBox_Enter);

            //this.txtRemark.Leave += new System.EventHandler(this.textBox_Leave);
            //this.txtRemark.Enter += new System.EventHandler(this.textBox_Enter);
        }
        private void textBox_Leave(object sender, EventArgs e)
        {
            C1TextBox a = (C1TextBox)sender;
            a.BackColor = bg;
            a.ForeColor = fc;
            a.Font = new Font(ff, FontStyle.Regular);
        }
        private void textBox_Enter(object sender, EventArgs e)
        {
            C1TextBox a = (C1TextBox)sender;
            a.BackColor = ic.cTxtFocus;
            a.Font = new Font(ff, FontStyle.Bold);
        }
        private void setGrf()
        {
            setGrfDay2();
            setGrfDay3();
            setGrfDay5();
            setGrfDay6();

            setGrfDay2Img();
            setGrfDay3Img();
            setGrfDay5Img();
            setGrfDay6Img();
        }
        private void setGrfDay2()
        {
            //grfDept.Rows.Count = 7;
            grfDay2.Clear();
            DataTable dt = new DataTable();

            dt = ic.ivfDB.opuEmDevDB.selectByOpuFetId_Day(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day2);
            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfDay2.Rows.Count = 1;
            grfDay2.Cols.Count = 7;
            C1TextBox txt = new C1TextBox();
            C1ComboBox cboday3 = new C1ComboBox();
            C1ComboBox cboday3desc1 = new C1ComboBox();
            cboday3.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboday3.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboday3desc1.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboday3desc1.AutoCompleteSource = AutoCompleteSource.ListItems;
            ic.ivfDB.fdtDB.setCboOPUStageDay3(cboday3, "");
            ic.ivfDB.fdtDB.setCboOPUStageDay3Desc1(cboday3desc1, "");
            grfDay2.Cols[colDay2ID].Editor = txt;
            grfDay2.Cols[colDay2Num].Editor = txt;
            grfDay2.Cols[colDay2Desc].Editor = cboday3;
            grfDay2.Cols[colDay2Desc1].Editor = cboday3desc1;
            grfDay2.Cols[colDay2Desc2].Editor = txt;

            grfDay2.Cols[colDay2Num].Width = 40;
            grfDay2.Cols[colDay2Desc].Width = 100;
            grfDay2.Cols[colDay2Desc1].Width = 50;
            grfDay2.Cols[colDay2Desc2].Width = 50;
            grfDay2.Cols[colDay2Desc].AllowSorting = false;
            grfDay2.Cols[colDay2Desc1].AllowSorting = false;
            grfDay2.Cols[colDay2Desc2].AllowSorting = false;

            grfDay2.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfDay2.Cols[colDay2Num].Caption = "no";
            grfDay2.Cols[colDay2Desc].Caption = "desc";
            grfDay2.Cols[colDay2Desc1].Caption = "desc1";
            grfDay2.Cols[colDay2Desc2].Caption = "desc2";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            int i = 1;
            String staffId = "", checkId = "", dateday2 = "";
            foreach (DataRow row in dt.Rows)
            {
                Row row1 = grfDay2.Rows.Add();
                staffId = row[ic.ivfDB.opuEmDevDB.opuEmDev.staff_id].ToString();
                checkId = row[ic.ivfDB.opuEmDevDB.opuEmDev.checked_id].ToString();
                dateday2 = row[ic.ivfDB.opuEmDevDB.opuEmDev.embryo_dev_date].ToString();
                row1[colDay2ID] = row[ic.ivfDB.opuEmDevDB.opuEmDev.opu_embryo_dev_id].ToString();
                row1[colDay2Num] = row[ic.ivfDB.opuEmDevDB.opuEmDev.opu_embryo_dev_no].ToString();
                row1[colDay2Desc] = row[ic.ivfDB.opuEmDevDB.opuEmDev.desc0].ToString();
                row1[colDay2Desc1] = row[ic.ivfDB.opuEmDevDB.opuEmDev.desc1].ToString();
                row1[colDay2Desc2] = row[ic.ivfDB.opuEmDevDB.opuEmDev.desc2].ToString();
                row1[0] = i;
                i++;
            }
            grfDay2.Rows.Add();
            grfDay2.Cols[colDay2ID].Visible = false;
            grfDay2.Cols[colDay2Num].Visible = false;
            ic.setC1Combo(cboEmbryologistDay2, staffId);
            ic.setC1Combo(cboCheckedDay2, checkId);
            txtDay2Date.Value = dateday2;
        }
        private void setGrfDay3()
        {
            //grfDept.Rows.Count = 7;
            grfDay3.Clear();
            DataTable dt = new DataTable();

            dt = ic.ivfDB.opuEmDevDB.selectByOpuFetId_Day(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day3);
            grfDay3.Rows.Count = 1;
            grfDay3.Cols.Count = 7;
            C1TextBox txt = new C1TextBox();
            C1ComboBox cboday3 = new C1ComboBox();
            C1ComboBox cboday3desc1 = new C1ComboBox();
            cboday3.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboday3.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboday3desc1.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboday3desc1.AutoCompleteSource = AutoCompleteSource.ListItems;
            ic.ivfDB.fdtDB.setCboOPUStageDay3(cboday3, "");
            ic.ivfDB.fdtDB.setCboOPUStageDay3Desc1(cboday3desc1, "");
            grfDay3.Cols[colDay3ID].Editor = txt;
            grfDay3.Cols[colDay3Num].Editor = txt;
            grfDay3.Cols[colDay3Desc].Editor = cboday3;
            grfDay3.Cols[colDay3Desc1].Editor = cboday3desc1;
            grfDay3.Cols[colDay3Desc2].Editor = txt;

            grfDay3.Cols[colDay3Num].Width = 40;
            grfDay3.Cols[colDay3Desc].Width = 100;
            grfDay3.Cols[colDay3Desc1].Width = 50;
            grfDay3.Cols[colDay3Desc2].Width = 50;
            grfDay3.Cols[colDay3Desc].AllowSorting = false;
            grfDay3.Cols[colDay3Desc1].AllowSorting = false;
            grfDay3.Cols[colDay3Desc2].AllowSorting = false;

            grfDay3.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfDay3.Cols[colDay3Num].Caption = "no";
            grfDay3.Cols[colDay3Desc].Caption = "desc";
            grfDay3.Cols[colDay3Desc1].Caption = "desc1";
            grfDay3.Cols[colDay3Desc2].Caption = "desc2";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            int i = 1;
            String staffId = "", checkId = "", dateday = "";
            foreach (DataRow row in dt.Rows)
            {
                Row row1 = grfDay3.Rows.Add();
                staffId = row[ic.ivfDB.opuEmDevDB.opuEmDev.staff_id].ToString();
                checkId = row[ic.ivfDB.opuEmDevDB.opuEmDev.checked_id].ToString();
                dateday = row[ic.ivfDB.opuEmDevDB.opuEmDev.embryo_dev_date].ToString();
                row1[colDay3ID] = row[ic.ivfDB.opuEmDevDB.opuEmDev.opu_embryo_dev_id].ToString();
                row1[colDay3Num] = row[ic.ivfDB.opuEmDevDB.opuEmDev.opu_embryo_dev_no].ToString();
                row1[colDay3Desc] = row[ic.ivfDB.opuEmDevDB.opuEmDev.desc0].ToString();
                row1[colDay3Desc1] = row[ic.ivfDB.opuEmDevDB.opuEmDev.desc1].ToString();
                row1[colDay3Desc2] = row[ic.ivfDB.opuEmDevDB.opuEmDev.desc2].ToString();
                row1[0] = i;
                i++;
            }
            grfDay3.Rows.Add();
            grfDay3.Cols[colDay3ID].Visible = false;
            grfDay3.Cols[colDay3Num].Visible = false;
            ic.setC1Combo(cboEmbryologistDay3, staffId);
            ic.setC1Combo(cboCheckedDay3, checkId);
            txtDay3Date.Value = dateday;
        }
        private void setGrfDay5()
        {
            //grfDept.Rows.Count = 7;
            grfDay5.Clear();
            DataTable dt = new DataTable();

            dt = ic.ivfDB.opuEmDevDB.selectByOpuFetId_Day(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day5);
            grfDay5.Rows.Count = 1;
            grfDay5.Cols.Count = 7;
            C1TextBox txt = new C1TextBox();
            C1ComboBox cboday5 = new C1ComboBox();
            C1ComboBox cboday3desc1 = new C1ComboBox();
            cboday5.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboday5.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboday3desc1.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboday3desc1.AutoCompleteSource = AutoCompleteSource.ListItems;
            ic.ivfDB.fdtDB.setCboOPUStageDay5(cboday5, "");
            ic.ivfDB.fdtDB.setCboOPUStageDay5Desc1(cboday3desc1, "");
            grfDay5.Cols[colDay5ID].Editor = txt;
            grfDay5.Cols[colDay5Num].Editor = txt;
            grfDay5.Cols[colDay5Desc].Editor = cboday5;
            grfDay5.Cols[colDay5Desc1].Editor = cboday3desc1;
            grfDay5.Cols[colDay5Desc2].Editor = txt;

            grfDay5.Cols[colDay5Num].Width = 40;
            grfDay5.Cols[colDay5Desc].Width = 100;
            grfDay5.Cols[colDay5Desc1].Width = 50;
            grfDay5.Cols[colDay5Desc2].Width = 50;

            grfDay5.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfDay5.Cols[colDay5Num].Caption = "no";
            grfDay5.Cols[colDay5Desc].Caption = "desc";
            grfDay5.Cols[colDay5Desc1].Caption = "desc1";
            grfDay5.Cols[colDay5Desc2].Caption = "desc2";
            grfDay5.Cols[colDay5Desc].AllowSorting = false;
            grfDay5.Cols[colDay5Desc1].AllowSorting = false;
            grfDay5.Cols[colDay5Desc2].AllowSorting = false;

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            int i = 1;
            String staffId = "", checkId = "", dateday = "";
            foreach (DataRow row in dt.Rows)
            {
                Row row1 = grfDay5.Rows.Add();
                staffId = row[ic.ivfDB.opuEmDevDB.opuEmDev.staff_id].ToString();
                checkId = row[ic.ivfDB.opuEmDevDB.opuEmDev.checked_id].ToString();
                dateday = row[ic.ivfDB.opuEmDevDB.opuEmDev.embryo_dev_date].ToString();
                row1[colDay5ID] = row[ic.ivfDB.opuEmDevDB.opuEmDev.opu_embryo_dev_id].ToString();
                row1[colDay5Num] = row[ic.ivfDB.opuEmDevDB.opuEmDev.opu_embryo_dev_no].ToString();
                row1[colDay5Desc] = row[ic.ivfDB.opuEmDevDB.opuEmDev.desc0].ToString();
                row1[colDay5Desc1] = row[ic.ivfDB.opuEmDevDB.opuEmDev.desc1].ToString();
                row1[colDay5Desc2] = row[ic.ivfDB.opuEmDevDB.opuEmDev.desc2].ToString();
                row1[0] = i;
                i++;
            }
            grfDay5.Rows.Add();
            grfDay5.Cols[colDay5ID].Visible = false;
            grfDay5.Cols[colDay5Num].Visible = false;
            ic.setC1Combo(cboEmbryologistDay5, staffId);
            ic.setC1Combo(cboCheckedDay5, checkId);
            txtDay5Date.Value = dateday;
        }
        private void setGrfDay6()
        {
            //grfDept.Rows.Count = 7;
            grfDay6.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.opuEmDevDB.selectByOpuFetId_Day(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day6);
            //grfExpn.DataSource = xC.xtDB.expndDB.selectAll1(cboYear.Text);
            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfDay6.Rows.Count = 1;
            grfDay6.Cols.Count = 7;
            C1TextBox txt = new C1TextBox();
            C1ComboBox cboday5 = new C1ComboBox();
            C1ComboBox cboday3desc1 = new C1ComboBox();
            cboday5.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboday5.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboday3desc1.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboday3desc1.AutoCompleteSource = AutoCompleteSource.ListItems;
            ic.ivfDB.fdtDB.setCboOPUStageDay5(cboday5, "");
            ic.ivfDB.fdtDB.setCboOPUStageDay5Desc1(cboday3desc1, "");
            grfDay6.Cols[colDay6ID].Editor = txt;
            grfDay6.Cols[colDay6Num].Editor = txt;
            grfDay6.Cols[colDay6Desc].Editor = cboday5;
            grfDay6.Cols[colDay6Desc1].Editor = cboday3desc1;
            grfDay6.Cols[colDay6Desc2].Editor = txt;

            grfDay6.Cols[colDay6Num].Width = 40;
            grfDay6.Cols[colDay6Desc].Width = 100;
            grfDay6.Cols[colDay6Desc1].Width = 50;
            grfDay6.Cols[colDay6Desc2].Width = 50;

            grfDay6.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfDay6.Cols[colDay6Num].Caption = "no";
            grfDay6.Cols[colDay6Desc].Caption = "desc";
            grfDay6.Cols[colDay6Desc1].Caption = "desc1";
            grfDay6.Cols[colDay6Desc2].Caption = "desc2";
            grfDay6.Cols[colDay6Desc].AllowSorting = false;
            grfDay6.Cols[colDay6Desc1].AllowSorting = false;
            grfDay6.Cols[colDay6Desc2].AllowSorting = false;

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            int i = 1;
            String staffId = "", checkId = "", dateday = "";
            foreach (DataRow row in dt.Rows)
            {
                Row row1 = grfDay6.Rows.Add();
                staffId = row[ic.ivfDB.opuEmDevDB.opuEmDev.staff_id].ToString();
                checkId = row[ic.ivfDB.opuEmDevDB.opuEmDev.checked_id].ToString();
                dateday = row[ic.ivfDB.opuEmDevDB.opuEmDev.embryo_dev_date].ToString();
                row1[colDay6ID] = row[ic.ivfDB.opuEmDevDB.opuEmDev.opu_embryo_dev_id].ToString();
                row1[colDay6Num] = row[ic.ivfDB.opuEmDevDB.opuEmDev.opu_embryo_dev_no].ToString();
                row1[colDay6Desc] = row[ic.ivfDB.opuEmDevDB.opuEmDev.desc0].ToString();
                row1[colDay6Desc1] = row[ic.ivfDB.opuEmDevDB.opuEmDev.desc1].ToString();
                row1[colDay6Desc2] = row[ic.ivfDB.opuEmDevDB.opuEmDev.desc2].ToString();
                row1[0] = i;
                i++;
            }
            grfDay6.Rows.Add();
            grfDay6.Cols[colDay2ID].Visible = false;
            grfDay6.Cols[colDay2Num].Visible = false;
            ic.setC1Combo(cboEmbryologistDay6, staffId);
            ic.setC1Combo(cboCheckedDay6, checkId);
            txtDay6Date.Value = dateday;
        }
        private void setControl()
        {
            try
            {
                if (!fetId.Equals(""))
                {
                    fet = ic.ivfDB.fetDB.selectByPk1(fetId);
                    lbReq = ic.ivfDB.lbReqDB.selectByPk1(fet.req_id);
                    DataTable dt = new DataTable();
                    dt = ic.ivfDB.opuEmDevDB.selectByOpuFetId_Day(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day2);
                    if (dt.Rows.Count > 0)
                    {
                        //txtMaturaNoofOpu.Enabled = false;
                    }
                    else
                    {
                        //setControlFirstTime(true);
                    }
                    setControl1();
                }
                else
                {
                    lbReq = ic.ivfDB.lbReqDB.selectByPk1(reqId);

                    txtHnFeMale.Value = lbReq.hn_female;
                    txtHnMale.Value = lbReq.hn_male;
                    txtNameFeMale.Value = lbReq.name_female;
                    txtNameMale.Value = lbReq.name_male;
                    txtLabReqCode.Value = lbReq.req_code;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "");
            }
        }
        private void setControl1()
        {
            txtID.Value = fet.fet_id;
            txtHnFeMale.Value = fet.hn_female;
            txtHnMale.Value = fet.hn_male;
            txtNameFeMale.Value = fet.name_female;
            txtNameMale.Value = fet.name_male;
            txtLabReqCode.Value = lbReq.req_code;
            txtDobFeMale.Value = fet.dob_female;
            txtDobMale.Value = fet.dob_male;
            ic.setC1Combo(cboDoctor, fet.doctor_id);
            txtFetDate.Value = fet.fet_date;
            ic.setC1Combo(cboOpuProce, fet.proce_id);
            txtFetCode.Value = fet.fet_code;
            txtHnDonor.Value = fet.hn_donor;
            txtNameDonor.Value = fet.name_donor;
            
            txtEmbryoForEtNO.Value = fet.embryo_for_et_no_of_et;
            txtEmbryoForEtDay.Value = fet.embryo_for_et_day;
            txtEmbryoForEtDate.Value = ic.datetoShow(fet.embryo_for_et_date);
            txtEmbryoForEtAsseted.Value = fet.embryo_for_et_assisted;
            txtEmbryoForEtVolume.Value = fet.embryo_for_et_volume;
            txtEmbryoForEtCatheter.Value = fet.embryo_for_et_catheter;
            txtEmbryoForEtDoctor.Value = fet.embryo_for_et_doctor;
            txtEmbryoForEtNumTran.Value = fet.embryo_for_et_number_of_transfer;
            txtEmbryoForEtNumFreeze.Value = fet.embryo_for_et_number_of_freeze;
            txtEmbryoForEtNumDiscard.Value = fet.embryo_for_et_number_of_discard;
            //cboEmbryoForEtEmbryologist.Value = opu.embryo_for_et_embryologist_id;
            //cboEmbryologistReport.Value = opu.embryologist_report_id;
            //cboEmbryologistAppv.Value = opu.embryologist_approve_id;
            ic.setC1Combo(cboEmbryologistAppv, fet.embryologist_approve_id);
            ic.setC1Combo(cboEmbryologistReport, fet.embryologist_report_id);
            ic.setC1Combo(cboEmbryoForEtEmbryologist, fet.embryo_for_et_embryologist_id);            

            //txtRemark.Value = opu.remark;
            ic.setC1ComboByName(cboRemark, fet.remark);
            txtDatePicEmbryo.Value = fet.date_pic_embryo;
            //CboEmbryoDay.Text = opu.emb

            txtDatePicEmbryo.Value = fet.date_pic_embryo;
            txtFreezeDate.Value = fet.freeze_date;
            txtFreezeNo.Value = fet.freeze_no_of_freeze;
            txtFreezeStage.Value = fet.freeze_stage_of_freeze;
            txtThawDate.Value = fet.thaw_date;
            txtThawNo.Value = fet.thaw_no_of_thaw;
            txtThawSurvival.Value = fet.thaw_no_of_survival;
            txtThawRemain.Value = fet.thaw_no_of_remaining;
            //txtMediaDate.Value = fet.media_date;
            ic.setC1Combo(cboEmbryoFreezMedia, fet.embryo_freez_freeze_media);
            txtMediaExp.Value = fet.media_exp;
            txtMediaLot.Value = fet.media_lot_no;
            txtMediaThawing.Value = fet.media_thawing;
        }
        private void initGrf()
        {
            initGrfDay2();
            initGrfDay3();
            initGrfDay5();
            initGrfDay6();
            initGrfDay2Img();
            initGrfDay3Img();
            initGrfDay5Img();
            initGrfDay6Img();
        }
        private void setClick()
        {
            btnSave.Click += BtnSave_Click;
            
            btnSaveEmbryoEt.Click += BtnSaveEmbryoEt_Click;
            
            btnSaveDay2.Click += BtnSaveDay2_Click;
            btnSaveDay3.Click += BtnSaveDay3_Click;
            btnSaveDay5.Click += BtnSaveDay5_Click;
            btnSaveDay6.Click += BtnSaveDay6_Click;
            //btnPrint.Click += BtnPrint_Click;
            tC1.DoubleClick += TC1_DoubleClick;
            tabDay2.DoubleClick += TabDay2_DoubleClick;
            btnSaveImg2.Click += BtnSaveImg2_Click;
            btnDay2ImgRef.Click += BtnDay2ImgRef_Click;
            tabDay3.DoubleClick += TabDay3_DoubleClick;
            tabDay5.DoubleClick += TabDay5_DoubleClick;
            tabDay6.DoubleClick += TabDay6_DoubleClick;
            btnDay3ImgRef.Click += BtnDay3ImgRef_Click;
            btnSaveImg3.Click += BtnSaveImg3_Click;
            btnSaveImg5.Click += BtnSaveImg5_Click;
            btnDay5ImgRef.Click += BtnDay5ImgRef_Click;
            btnSaveImg6.Click += BtnSaveImg6_Click;
            btnDay6ImgRef.Click += BtnDay6ImgRef_Click;
            btnPrintOpuEmbryoDev.Click += BtnPrintOpuEmbryoDev_Click;
        }
        private void setKeyPress()
        {
            
        }
        private void BtnPrintOpuEmbryoDev_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmLabOPUPrint frm = new FrmLabOPUPrint(ic, txtID.Text, FrmLabOPUPrint.opuReport.FETEmbryoDevReport);
            frm.ShowDialog(this);
        }
        private void BtnDay5ImgRef_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            grfDay5Img.AutoSizeCols();
            grfDay5Img.AutoSizeRows();
        }
        private void BtnDay6ImgRef_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            grfDay6Img.AutoSizeCols();
            grfDay6Img.AutoSizeRows();
        }
        private void BtnSaveImg3_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล Day 3 Embryo Development  ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                ic.cStf.staff_id = "";
                Boolean chkSave = false;
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    String re = "";
                    int i = 0;
                    FrmWaiting frmW = new FrmWaiting();
                    frmW.Show();
                    foreach (Row row in grfDay3Img.Rows)
                    {
                        try
                        {
                            String id = row[colDay2ImgId] != null ? row[colDay2ImgId].ToString() : "";
                            String path = row[colDay2PathPic] != null ? row[colDay2PathPic].ToString() : "";
                            String desc = row[colDay2ImgDesc0] != null ? row[colDay2ImgDesc0].ToString() : "";
                            String no = row[colDay2ImgNun] != null ? row[colDay2ImgNun].ToString() : "";
                            i++;
                            if (i == 1) continue;
                            if (!id.Equals(""))
                            {
                                if (no.Length > 0)
                                {
                                    String filename = "";
                                    String[] ext = path.Split('.');
                                    if (ext.Length > 1)
                                    {
                                        filename = txtFetCode.Text + "_day3_" + no + "." + ext[ext.Length - 1];
                                        re = ic.ivfDB.opuEmDevDB.updatePathPic(id, no, ic.iniC.folderFTP + "/" + txtFetCode.Text + "/" + filename, desc, ic.cStf.staff_id);
                                        long chk = 0;
                                        if (long.TryParse(re, out chk))
                                        {
                                            if (File.Exists(path))
                                            {
                                                ic.savePicOPUtoServer(txtFetCode.Text, filename, path);
                                            }
                                            grfDay3Img.Rows[i - 1].StyleNew.BackColor = color;
                                        }
                                    }
                                }
                            }
                            frmW.pB.Value = i;
                        }
                        catch (Exception ex)
                        {
                            frmW.lb.Text = ex.Message;
                        }
                        //i++;
                    }
                    frmW.Dispose();
                }
            }
        }
        private void BtnSaveImg5_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล Day 5 Embryo Development  ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                ic.cStf.staff_id = "";
                Boolean chkSave = false;
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    String re = "";
                    int i = 0;
                    FrmWaiting frmW = new FrmWaiting();
                    frmW.Show();
                    foreach (Row row in grfDay5Img.Rows)
                    {
                        try
                        {
                            String id = row[colDay2ImgId] != null ? row[colDay2ImgId].ToString() : "";
                            String path = row[colDay2PathPic] != null ? row[colDay2PathPic].ToString() : "";
                            String desc = row[colDay2ImgDesc0] != null ? row[colDay2ImgDesc0].ToString() : "";
                            String no = row[colDay2ImgNun] != null ? row[colDay2ImgNun].ToString() : "";
                            i++;
                            if (i == 1) continue;
                            if (!id.Equals(""))
                            {
                                if (no.Length > 0)
                                {
                                    String filename = "";
                                    String[] ext = path.Split('.');
                                    if (ext.Length > 1)
                                    {
                                        filename = txtFetCode.Text + "_day5_" + no + "." + ext[ext.Length - 1];
                                        re = ic.ivfDB.opuEmDevDB.updatePathPic(id, no, ic.iniC.folderFTP + "/" + txtFetCode.Text + "/" + filename, desc, ic.cStf.staff_id);
                                        long chk = 0;
                                        if (long.TryParse(re, out chk))
                                        {
                                            if (File.Exists(path))
                                            {
                                                ic.savePicOPUtoServer(txtFetCode.Text, filename, path);
                                            }
                                            grfDay5Img.Rows[i - 1].StyleNew.BackColor = color;
                                        }
                                    }
                                }
                            }
                            frmW.pB.Value = i;
                        }
                        catch (Exception ex)
                        {
                            frmW.lb.Text = ex.Message;
                        }
                        //i++;
                    }
                    frmW.Dispose();
                }
            }
        }
        private void BtnSaveImg6_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล Day 6 Embryo Development  ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                ic.cStf.staff_id = "";
                Boolean chkSave = false;
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    String re = "";
                    int i = 0;
                    FrmWaiting frmW = new FrmWaiting();
                    frmW.Show();
                    foreach (Row row in grfDay6Img.Rows)
                    {
                        try
                        {
                            String id = row[colDay2ImgId] != null ? row[colDay2ImgId].ToString() : "";
                            String path = row[colDay2PathPic] != null ? row[colDay2PathPic].ToString() : "";
                            String desc = row[colDay2ImgDesc0] != null ? row[colDay2ImgDesc0].ToString() : "";
                            String no = row[colDay2ImgNun] != null ? row[colDay2ImgNun].ToString() : "";
                            i++;
                            if (i == 1) continue;
                            if (!id.Equals(""))
                            {
                                if (no.Length > 0)
                                {
                                    String filename = "";
                                    String[] ext = path.Split('.');
                                    if (ext.Length > 1)
                                    {
                                        filename = txtFetCode.Text + "_day6_" + no + "." + ext[ext.Length - 1];
                                        re = ic.ivfDB.opuEmDevDB.updatePathPic(id, no, ic.iniC.folderFTP + "/" + txtFetCode.Text + "/" + filename, desc, ic.cStf.staff_id);
                                        long chk = 0;
                                        if (long.TryParse(re, out chk))
                                        {
                                            if (File.Exists(path))
                                            {
                                                ic.savePicOPUtoServer(txtFetCode.Text, filename, path);
                                            }
                                            grfDay6Img.Rows[i - 1].StyleNew.BackColor = color;
                                        }
                                    }
                                }
                            }
                            frmW.pB.Value = i;
                        }
                        catch (Exception ex)
                        {
                            frmW.lb.Text = ex.Message;
                        }

                        //i++;
                    }
                    frmW.Dispose();
                }
            }
        }
        private void BtnDay3ImgRef_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            grfDay3Img.AutoSizeCols();
            grfDay3Img.AutoSizeRows();
        }
        private void TabDay2_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (flagDay2Img)
            {
                MessageBox.Show("ได้เคยนำเข้าแล้ว กรุณานำเข้าที่ละรายการ", "");
                return;
            }
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images (*.BMP;*.JPG;*.Jepg;*.Png;*.GIF)|*.BMP;*.JPG;*.Jepg;*.Png;*.GIF|Pdf Files|*.pdf|All files (*.*)|*.*";
            ofd.Multiselect = true;
            ofd.Title = "My Image Browser";
            DialogResult dr = ofd.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                //FrmPatientUpPic frm = new FrmPatientUpPic(ofd.FileNames);
                //frm.ShowDialog(this);

                // Read the files

                //Row row1 = grfImg.Rows.Add();
                //CellRange rg1 = grfImg.GetCellRange(grfImg.Rows.Count-1, colImg);
                //FrmWaiting frmW = new FrmWaiting();
                //frmW.Show();

                int i = 1;
                grfDay2Img.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictRows;
                grfDay2Img.Cols[colDay2ImgPic].AllowMerging = true;
                //cc.Image
                Column col = grfDay2Img.Cols[colDay2ImgPic];
                col.DataType = typeof(Image);
                int ii = 0;
                foreach (String file in ofd.FileNames)
                {
                    // Create a PictureBox.
                    try
                    {
                        Image loadedImage, resizedImage;
                        String[] sur = file.Split('.');
                        String ex = "";
                        if (sur.Length == 2)
                        {
                            ex = sur[1];
                        }
                        if (!ex.Equals("pdf"))
                        {
                            loadedImage = Image.FromFile(file);
                            int originalWidth = loadedImage.Width;
                            int newWidth = 180;
                            resizedImage = loadedImage.GetThumbnailImage(newWidth, (newWidth * loadedImage.Height) / originalWidth, null, IntPtr.Zero);
                        }
                        else
                        {
                            resizedImage = Resources.pdf_symbol_80_2;
                        }
                        grfDay2Img.Cols[colDay2ImgPic].ImageAndText = true;
                        ii++;
                        //Row row1 = grfDay2Img.Rows[ii];
                        //int row = grfDay2Img.Rows.Count;

                        int hei = grfDay2Img.Rows.DefaultSize;
                        //grfImg.Rows[row-1].Height = hei*6;
                        //CellRange rg1 = grfDay2Img.GetCellRange(row - 1, colDay2ImgPic);

                        //PictureBox pb = new PictureBox();                        
                        grfDay2Img[ii, colDay2PathPic] = file;
                        //grfDay2Img[row - 1, colBtn] = "send";

                        grfDay2Img[ii, colDay2ImgPic] = resizedImage;

                        i++;
                        //frmW.pB.Value = i;
                    }
                    catch (SecurityException ex)
                    {
                        // The user lacks appropriate permissions to read files, discover paths, etc.
                        MessageBox.Show("Security error. Please contact your administrator for details.\n\nError message: " + ex.Message + "\n\nDetails (send to Support):\n\n" + ex.StackTrace);
                        //frmW.lb.Text = ""+ ex.Message;
                    }
                    catch (Exception ex)
                    {
                        // Could not load the image - probably related to Windows file system permissions.
                        MessageBox.Show("Cannot display the image: " + file.Substring(file.LastIndexOf('\\')) + ". You may not have permission to read the file, or it may be corrupt.\n\nReported error: " + ex.Message);
                        //frmW.lb.Text = "" + ex.Message;
                    }
                }
                //frmW.Dispose();
                grfDay2Img.AutoSizeCols();
                grfDay2Img.AutoSizeRows();
            }
        }
        private void TabDay3_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (flagDay3Img)
            {
                MessageBox.Show("ได้เคยนำเข้าแล้ว กรุณานำเข้าที่ละรายการ", "");
                return;
            }
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images (*.BMP;*.JPG;*.Jepg;*.Png;*.GIF)|*.BMP;*.JPG;*.Jepg;*.Png;*.GIF|Pdf Files|*.pdf|All files (*.*)|*.*";
            ofd.Multiselect = true;
            ofd.Title = "My Image Browser";
            DialogResult dr = ofd.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                //FrmPatientUpPic frm = new FrmPatientUpPic(ofd.FileNames);
                //frm.ShowDialog(this);

                // Read the files

                //Row row1 = grfImg.Rows.Add();
                //CellRange rg1 = grfImg.GetCellRange(grfImg.Rows.Count-1, colImg);
                int i = 1;
                grfDay3Img.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictRows;
                grfDay3Img.Cols[colDay2ImgPic].AllowMerging = true;
                //cc.Image
                Column col = grfDay3Img.Cols[colDay2ImgPic];
                col.DataType = typeof(Image);
                int ii = 0;
                foreach (String file in ofd.FileNames)
                {
                    // Create a PictureBox.
                    try
                    {
                        Image loadedImage, resizedImage;
                        String[] sur = file.Split('.');
                        String ex = "";
                        if (sur.Length == 2)
                        {
                            ex = sur[1];
                        }
                        if (!ex.Equals("pdf"))
                        {
                            loadedImage = Image.FromFile(file);
                            int originalWidth = loadedImage.Width;
                            int newWidth = 180;
                            resizedImage = loadedImage.GetThumbnailImage(newWidth, (newWidth * loadedImage.Height) / originalWidth, null, IntPtr.Zero);
                        }
                        else
                        {
                            resizedImage = Resources.pdf_symbol_80_2;
                        }
                        grfDay3Img.Cols[colDay2ImgPic].ImageAndText = true;
                        ii++;
                        //Row row1 = grfDay3Img.Rows.Add();
                        //int row = grfDay3Img.Rows.Count;

                        int hei = grfDay3Img.Rows.DefaultSize;
                        //grfImg.Rows[row-1].Height = hei*6;
                        //CellRange rg1 = grfDay2Img.GetCellRange(row - 1, colDay2ImgPic);

                        //PictureBox pb = new PictureBox();

                        grfDay3Img[ii, colDay2PathPic] = file;
                        //grfDay2Img[row - 1, colBtn] = "send";

                        grfDay3Img[ii, colDay2ImgPic] = resizedImage;

                        i++;
                    }
                    catch (SecurityException ex)
                    {
                        // The user lacks appropriate permissions to read files, discover paths, etc.
                        MessageBox.Show("Security error. Please contact your administrator for details.\n\n" +
                            "Error message: " + ex.Message + "\n\n" +
                            "Details (send to Support):\n\n" + ex.StackTrace
                        );
                    }
                    catch (Exception ex)
                    {
                        // Could not load the image - probably related to Windows file system permissions.
                        MessageBox.Show("Cannot display the image: " + file.Substring(file.LastIndexOf('\\'))
                            + ". You may not have permission to read the file, or " +
                            "it may be corrupt.\n\nReported error: " + ex.Message);
                    }
                }
                grfDay3Img.AutoSizeCols();
                grfDay3Img.AutoSizeRows();
            }
        }
        private void TabDay5_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (flagDay5Img)
            {
                MessageBox.Show("ได้เคยนำเข้าแล้ว กรุณานำเข้าที่ละรายการ", "");
                return;
            }
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images (*.BMP;*.JPG;*.Jepg;*.Png;*.GIF)|*.BMP;*.JPG;*.Jepg;*.Png;*.GIF|Pdf Files|*.pdf|All files (*.*)|*.*";
            ofd.Multiselect = true;
            ofd.Title = "My Image Browser";
            DialogResult dr = ofd.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                //FrmPatientUpPic frm = new FrmPatientUpPic(ofd.FileNames);
                //frm.ShowDialog(this);

                // Read the files

                //Row row1 = grfImg.Rows.Add();
                //CellRange rg1 = grfImg.GetCellRange(grfImg.Rows.Count-1, colImg);
                //FrmWaiting frmW = new FrmWaiting();
                //frmW.Show();

                int i = 1;
                grfDay5Img.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictRows;
                grfDay5Img.Cols[colDay2ImgPic].AllowMerging = true;
                //cc.Image
                Column col = grfDay5Img.Cols[colDay2ImgPic];
                col.DataType = typeof(Image);
                int ii = 0;
                foreach (String file in ofd.FileNames)
                {
                    // Create a PictureBox.
                    try
                    {
                        Image loadedImage, resizedImage;
                        String[] sur = file.Split('.');
                        String ex = "";
                        if (sur.Length == 2)
                        {
                            ex = sur[1];
                        }
                        if (!ex.Equals("pdf"))
                        {
                            loadedImage = Image.FromFile(file);
                            int originalWidth = loadedImage.Width;
                            int newWidth = 180;
                            resizedImage = loadedImage.GetThumbnailImage(newWidth, (newWidth * loadedImage.Height) / originalWidth, null, IntPtr.Zero);
                        }
                        else
                        {
                            resizedImage = Resources.pdf_symbol_80_2;
                        }
                        grfDay5Img.Cols[colDay2ImgPic].ImageAndText = true;
                        ii++;
                        //Row row1 = grfDay2Img.Rows[ii];
                        //int row = grfDay2Img.Rows.Count;

                        int hei = grfDay5Img.Rows.DefaultSize;
                        //grfImg.Rows[row-1].Height = hei*6;
                        //CellRange rg1 = grfDay2Img.GetCellRange(row - 1, colDay2ImgPic);

                        //PictureBox pb = new PictureBox();                        
                        grfDay5Img[ii, colDay2PathPic] = file;
                        //grfDay2Img[row - 1, colBtn] = "send";

                        grfDay5Img[ii, colDay2ImgPic] = resizedImage;

                        i++;
                        //frmW.pB.Value = i;
                    }
                    catch (SecurityException ex)
                    {
                        // The user lacks appropriate permissions to read files, discover paths, etc.
                        MessageBox.Show("Security error. Please contact your administrator for details.\n\nError message: " + ex.Message + "\n\nDetails (send to Support):\n\n" + ex.StackTrace);
                        //frmW.lb.Text = ""+ ex.Message;
                    }
                    catch (Exception ex)
                    {
                        // Could not load the image - probably related to Windows file system permissions.
                        MessageBox.Show("Cannot display the image: " + file.Substring(file.LastIndexOf('\\')) + ". You may not have permission to read the file, or it may be corrupt.\n\nReported error: " + ex.Message);
                        //frmW.lb.Text = "" + ex.Message;
                    }
                }
                //frmW.Dispose();
                grfDay5Img.AutoSizeCols();
                grfDay5Img.AutoSizeRows();
            }
        }
        private void TabDay6_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (flagDay5Img)
            {
                MessageBox.Show("ได้เคยนำเข้าแล้ว กรุณานำเข้าที่ละรายการ", "");
                return;
            }
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images (*.BMP;*.JPG;*.Jepg;*.Png;*.GIF)|*.BMP;*.JPG;*.Jepg;*.Png;*.GIF|Pdf Files|*.pdf|All files (*.*)|*.*";
            ofd.Multiselect = true;
            ofd.Title = "My Image Browser";
            DialogResult dr = ofd.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                //FrmPatientUpPic frm = new FrmPatientUpPic(ofd.FileNames);
                //frm.ShowDialog(this);

                // Read the files

                //Row row1 = grfImg.Rows.Add();
                //CellRange rg1 = grfImg.GetCellRange(grfImg.Rows.Count-1, colImg);
                //FrmWaiting frmW = new FrmWaiting();
                //frmW.Show();

                int i = 1;
                grfDay6Img.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictRows;
                grfDay6Img.Cols[colDay2ImgPic].AllowMerging = true;
                //cc.Image
                Column col = grfDay6Img.Cols[colDay2ImgPic];
                col.DataType = typeof(Image);
                int ii = 0;
                foreach (String file in ofd.FileNames)
                {
                    // Create a PictureBox.
                    try
                    {
                        Image loadedImage, resizedImage;
                        String[] sur = file.Split('.');
                        String ex = "";
                        if (sur.Length == 2)
                        {
                            ex = sur[1];
                        }
                        if (!ex.Equals("pdf"))
                        {
                            loadedImage = Image.FromFile(file);
                            int originalWidth = loadedImage.Width;
                            int newWidth = 180;
                            resizedImage = loadedImage.GetThumbnailImage(newWidth, (newWidth * loadedImage.Height) / originalWidth, null, IntPtr.Zero);
                        }
                        else
                        {
                            resizedImage = Resources.pdf_symbol_80_2;
                        }
                        grfDay6Img.Cols[colDay2ImgPic].ImageAndText = true;
                        ii++;
                        //Row row1 = grfDay2Img.Rows[ii];
                        //int row = grfDay2Img.Rows.Count;

                        int hei = grfDay6Img.Rows.DefaultSize;
                        //grfImg.Rows[row-1].Height = hei*6;
                        //CellRange rg1 = grfDay2Img.GetCellRange(row - 1, colDay2ImgPic);

                        //PictureBox pb = new PictureBox();                        
                        grfDay6Img[ii, colDay2PathPic] = file;
                        //grfDay2Img[row - 1, colBtn] = "send";

                        grfDay6Img[ii, colDay2ImgPic] = resizedImage;

                        i++;
                        //frmW.pB.Value = i;
                    }
                    catch (SecurityException ex)
                    {
                        // The user lacks appropriate permissions to read files, discover paths, etc.
                        MessageBox.Show("Security error. Please contact your administrator for details.\n\nError message: " + ex.Message + "\n\nDetails (send to Support):\n\n" + ex.StackTrace);
                        //frmW.lb.Text = ""+ ex.Message;
                    }
                    catch (Exception ex)
                    {
                        // Could not load the image - probably related to Windows file system permissions.
                        MessageBox.Show("Cannot display the image: " + file.Substring(file.LastIndexOf('\\')) + ". You may not have permission to read the file, or it may be corrupt.\n\nReported error: " + ex.Message);
                        //frmW.lb.Text = "" + ex.Message;
                    }
                }
                //frmW.Dispose();
                grfDay6Img.AutoSizeCols();
                grfDay6Img.AutoSizeRows();
            }
        }
        private void TC1_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

        }
        private void BtnPrint_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmLabOPUPrint frm = new FrmLabOPUPrint(ic, txtID.Text, FrmLabOPUPrint.opuReport.OPUReport);
            frm.ShowDialog(this);
        }
        private void BtnDay2ImgRef_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            grfDay2Img.AutoSizeCols();
            grfDay2Img.AutoSizeRows();
        }
        private void BtnSaveImg2_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล Day 2 Embryo Development  ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                ic.cStf.staff_id = "";
                Boolean chkSave = false;
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    String re = "";
                    int i = 0;
                    FrmWaiting frmW = new FrmWaiting();
                    frmW.Show();
                    foreach (Row row in grfDay2Img.Rows)
                    {
                        try
                        {
                            String id = row[colDay2ImgId] != null ? row[colDay2ImgId].ToString() : "";
                            String path = row[colDay2PathPic] != null ? row[colDay2PathPic].ToString() : "";
                            String desc = row[colDay2ImgDesc0] != null ? row[colDay2ImgDesc0].ToString() : "";
                            String no = row[colDay2ImgNun] != null ? row[colDay2ImgNun].ToString() : "";
                            i++;
                            if (i == 1) continue;
                            if (!id.Equals(""))
                            {
                                if (no.Length > 0)
                                {
                                    String filename = "";
                                    String[] ext = path.Split('.');
                                    if (ext.Length > 1)
                                    {
                                        filename = txtFetCode.Text + "_day2_" + no + "." + ext[ext.Length - 1];
                                        re = ic.ivfDB.opuEmDevDB.updatePathPic(id, no, ic.iniC.folderFTP + "/" + txtFetCode.Text + "/" + filename, desc, ic.cStf.staff_id);
                                        long chk = 0;
                                        if (long.TryParse(re, out chk))
                                        {
                                            if (File.Exists(path))
                                            {
                                                ic.savePicOPUtoServer(txtFetCode.Text, filename, path);
                                            }
                                            grfDay2Img.Rows[i - 1].StyleNew.BackColor = color;
                                        }
                                    }
                                }
                            }
                            frmW.pB.Value = i;
                        }
                        catch (Exception ex)
                        {
                            frmW.lb.Text = ex.Message;
                        }
                        //i++;
                    }
                    frmW.Dispose();
                }
            }
        }
        private void BtnSaveDay2_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //if (MessageBox.Show("ต้องการ บันทึกช้อมูล Day 2 Embryo Development  ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            ic.cStf.staff_id = "";
            Boolean chkSave = false;
            FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            frm.ShowDialog(this);
            if (!ic.cStf.staff_id.Equals(""))
            {
                //setOPUEmbryoFreezDay1();
                //String re = ic.ivfDB.opuDB.updateEmbryoFreezDay1(opu, ic.user.staff_id);
                String re = "";
                int i = 1;
                foreach (Row row in grfDay2.Rows)
                {
                    if (row[colDay2Edit] == null) continue;
                    if (row[colDay2Edit].ToString().Equals("1"))
                    {
                        if (row[colDay2Desc] == null) continue;

                        LabOpuEmbryoDev opuEmDev = new LabOpuEmbryoDev();
                        opuEmDev.opu_embryo_dev_id = row[colDay2ID] != null ? row[colDay2ID].ToString() : "";
                        opuEmDev.opu_fet_id = txtID.Text;
                        opuEmDev.day = "2";
                        opuEmDev.opu_embryo_dev_no = row[colDay2Num] != null ? row[colDay2Num].ToString() : i.ToString();
                        opuEmDev.desc0 = row[colDay2Desc].ToString();
                        opuEmDev.active = "1";
                        opuEmDev.remark = "";
                        opuEmDev.path_pic = "";
                        opuEmDev.date_create = "";
                        opuEmDev.date_modi = "";
                        opuEmDev.date_cancel = "";
                        opuEmDev.user_create = "";
                        opuEmDev.user_modi = "";
                        opuEmDev.user_cancel = "";
                        opuEmDev.desc1 = row[colDay2Desc1] != null ? row[colDay2Desc1].ToString() : "";
                        opuEmDev.desc2 = row[colDay2Desc2] != null ? row[colDay2Desc2].ToString() : "";
                        opuEmDev.desc3 = "";

                        opuEmDev.staff_id = cboEmbryologistDay2.SelectedItem == null ? "" : ((ComboBoxItem)cboEmbryologistDay2.SelectedItem).Value;
                        opuEmDev.checked_id = cboCheckedDay2.SelectedItem == null ? "" : ((ComboBoxItem)cboCheckedDay2.SelectedItem).Value;
                        opuEmDev.embryo_dev_date = ic.dateTimetoDB(txtDay2Date.Text);
                        re = ic.ivfDB.opuEmDevDB.insertLabOpuEmbryoDev(opuEmDev, ic.cStf.staff_id);
                        long chk = 0;
                        if (long.TryParse(re, out chk))
                        {
                            row[colDay2Edit] = "0";
                            chkSave = true;
                            //MessageBox.Show("Error", "");
                        }
                        else
                        {
                            chkSave = false;
                        }
                    }
                    i++;
                }

                long chk1 = 0;
                if (chkSave)
                {
                    setGrfDay2();
                    btnSaveDay2.Image = Resources.accept_database24;
                }
                else
                {
                    btnSaveDay2.Image = Resources.accept_database24;
                }
                if (cboEmbryologistDay2.SelectedItem != null)
                {
                    String staff_id = "";
                    staff_id = cboEmbryologistDay2.SelectedItem == null ? "" : ((ComboBoxItem)cboEmbryologistDay2.SelectedItem).Value;
                    String re1 = ic.ivfDB.opuEmDevDB.updateStff(txtID.Text, "2", staff_id);
                }
                if (cboCheckedDay2.SelectedItem != null)
                {
                    String check_id = "";
                    check_id = cboCheckedDay2.SelectedItem == null ? "" : ((ComboBoxItem)cboCheckedDay2.SelectedItem).Value;
                    String re1 = ic.ivfDB.opuEmDevDB.updateChecked(txtID.Text, "2", check_id);
                }
                DateTime dtday2 = new DateTime();
                if (DateTime.TryParse(txtDay2Date.Text, out dtday2))
                {
                    String dateday2 = "";
                    dateday2 = ic.dateTimetoDB1(dtday2);
                    String re1 = ic.ivfDB.opuEmDevDB.updateDevDate(txtID.Text, "2", dateday2);
                }
            }
            //}
        }
        private void BtnSaveDay3_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //if (MessageBox.Show("ต้องการ บันทึกช้อมูล Day 3 Embryo Development  ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            ic.cStf.staff_id = "";
            Boolean chkSave = false;
            FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            frm.ShowDialog(this);
            if (!ic.cStf.staff_id.Equals(""))
            {
                //setOPUEmbryoFreezDay1();
                //String re = ic.ivfDB.opuDB.updateEmbryoFreezDay1(opu, ic.user.staff_id);
                String re = "";
                int i = 1;
                foreach (Row row in grfDay3.Rows)
                {
                    if (row[colDay3Edit] == null) continue;
                    if (row[colDay3Edit].ToString().Equals("1"))
                    {
                        if (row[colDay3Desc] == null) continue;

                        LabOpuEmbryoDev opuEmDev = new LabOpuEmbryoDev();
                        opuEmDev.opu_embryo_dev_id = row[colDay3ID] != null ? row[colDay3ID].ToString() : "";
                        opuEmDev.opu_fet_id = txtID.Text;
                        opuEmDev.day = "3";
                        opuEmDev.opu_embryo_dev_no = row[colDay3Num] != null ? row[colDay3Num].ToString() : i.ToString();
                        opuEmDev.desc0 = row[colDay3Desc].ToString();
                        opuEmDev.active = "1";
                        opuEmDev.remark = "";
                        opuEmDev.path_pic = "";
                        opuEmDev.date_create = "";
                        opuEmDev.date_modi = "";
                        opuEmDev.date_cancel = "";
                        opuEmDev.user_create = "";
                        opuEmDev.user_modi = "";
                        opuEmDev.user_cancel = "";
                        opuEmDev.desc1 = row[colDay3Desc1] != null ? row[colDay3Desc1].ToString() : "";
                        opuEmDev.desc2 = row[colDay3Desc2] != null ? row[colDay3Desc2].ToString() : "";
                        opuEmDev.desc3 = "";

                        opuEmDev.staff_id = cboEmbryologistDay3.SelectedItem == null ? "" : ((ComboBoxItem)cboEmbryologistDay3.SelectedItem).Value;
                        opuEmDev.checked_id = cboCheckedDay3.SelectedItem == null ? "" : ((ComboBoxItem)cboCheckedDay3.SelectedItem).Value;
                        opuEmDev.embryo_dev_date = ic.dateTimetoDB(txtDay3Date.Text);
                        re = ic.ivfDB.opuEmDevDB.insertLabOpuEmbryoDev(opuEmDev, ic.cStf.staff_id);
                        long chk = 0;
                        if (long.TryParse(re, out chk))
                        {
                            row[colDay3Edit] = "0";
                            //MessageBox.Show("Error", "");
                            chkSave = true;
                        }
                        else
                        {
                            chkSave = false;
                        }
                    }
                    i++;
                }
                long chk1 = 0;
                if (chkSave)
                {
                    setGrfDay3();
                    btnSaveDay3.Image = Resources.accept_database24;
                }
                else
                {
                    btnSaveDay3.Image = Resources.accept_database24;
                }
                if (cboEmbryologistDay3.SelectedItem != null)
                {
                    String staff_id = "";
                    staff_id = cboEmbryologistDay3.SelectedItem == null ? "" : ((ComboBoxItem)cboEmbryologistDay3.SelectedItem).Value;
                    String re1 = ic.ivfDB.opuEmDevDB.updateStff(txtID.Text, "3", staff_id);
                }
                if (cboCheckedDay3.SelectedItem != null)
                {
                    String check_id = "";
                    check_id = cboCheckedDay3.SelectedItem == null ? "" : ((ComboBoxItem)cboCheckedDay3.SelectedItem).Value;
                    String re1 = ic.ivfDB.opuEmDevDB.updateChecked(txtID.Text, "3", check_id);
                }
                DateTime dtday3 = new DateTime();
                if (DateTime.TryParse(txtDay3Date.Text, out dtday3))
                {
                    String dateday3 = "";
                    dateday3 = ic.dateTimetoDB1(dtday3);
                    String re1 = ic.ivfDB.opuEmDevDB.updateDevDate(txtID.Text, "3", dateday3);
                }
            }
            //}
        }
        private void BtnSaveDay5_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //if (MessageBox.Show("ต้องการ บันทึกช้อมูล Day 5 Embryo Development  ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            ic.cStf.staff_id = "";
            Boolean chkSave = false;
            FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            frm.ShowDialog(this);
            if (!ic.cStf.staff_id.Equals(""))
            {
                //setOPUEmbryoFreezDay1();
                //String re = ic.ivfDB.opuDB.updateEmbryoFreezDay1(opu, ic.user.staff_id);
                String re = "";
                int i = 1;
                foreach (Row row in grfDay5.Rows)
                {
                    if (row[colDay5Edit] == null) continue;
                    if (row[colDay5Edit].ToString().Equals("1"))
                    {
                        if (row[colDay5Desc] == null) continue;

                        LabOpuEmbryoDev opuEmDev = new LabOpuEmbryoDev();
                        opuEmDev.opu_embryo_dev_id = row[colDay5ID] != null ? row[colDay5ID].ToString() : "";
                        opuEmDev.opu_fet_id = txtID.Text;
                        opuEmDev.day = "5";
                        opuEmDev.opu_embryo_dev_no = row[colDay5Num] != null ? row[colDay5Num].ToString() : i.ToString();
                        opuEmDev.desc0 = row[colDay5Desc].ToString();
                        opuEmDev.active = "1";
                        opuEmDev.remark = "";
                        opuEmDev.path_pic = "";
                        opuEmDev.date_create = "";
                        opuEmDev.date_modi = "";
                        opuEmDev.date_cancel = "";
                        opuEmDev.user_create = "";
                        opuEmDev.user_modi = "";
                        opuEmDev.user_cancel = "";
                        opuEmDev.desc1 = row[colDay5Desc1] != null ? row[colDay5Desc1].ToString() : "";
                        opuEmDev.desc2 = row[colDay5Desc2] != null ? row[colDay5Desc2].ToString() : "";
                        opuEmDev.desc3 = "";

                        opuEmDev.staff_id = cboEmbryologistDay5.SelectedItem == null ? "" : ((ComboBoxItem)cboEmbryologistDay5.SelectedItem).Value;
                        opuEmDev.checked_id = cboCheckedDay5.SelectedItem == null ? "" : ((ComboBoxItem)cboCheckedDay5.SelectedItem).Value;
                        opuEmDev.embryo_dev_date = ic.dateTimetoDB(txtDay5Date.Text);
                        re = ic.ivfDB.opuEmDevDB.insertLabOpuEmbryoDev(opuEmDev, ic.cStf.staff_id);
                        long chk = 0;
                        if (long.TryParse(re, out chk))
                        {
                            chkSave = true;
                            row[colDay5Edit] = "0";
                            //MessageBox.Show("Error", "");
                        }
                    }
                    i++;
                }
                long chk1 = 0;
                if (chkSave)
                {
                    setGrfDay5();
                    btnSaveDay5.Image = Resources.accept_database24;
                }
                else
                {
                    btnSaveDay5.Image = Resources.accept_database24;
                }
                if (cboEmbryologistDay5.SelectedItem != null)
                {
                    String staff_id = "";
                    staff_id = cboEmbryologistDay5.SelectedItem == null ? "" : ((ComboBoxItem)cboEmbryologistDay5.SelectedItem).Value;
                    String re1 = ic.ivfDB.opuEmDevDB.updateStff(txtID.Text, "5", staff_id);
                }
                if (cboCheckedDay5.SelectedItem != null)
                {
                    String check_id = "";
                    check_id = cboCheckedDay5.SelectedItem == null ? "" : ((ComboBoxItem)cboCheckedDay5.SelectedItem).Value;
                    String re1 = ic.ivfDB.opuEmDevDB.updateChecked(txtID.Text, "5", check_id);
                }
                DateTime dtday5 = new DateTime();
                if (DateTime.TryParse(txtDay5Date.Text, out dtday5))
                {
                    String dateday5 = "";
                    dateday5 = ic.dateTimetoDB1(dtday5);
                    String re1 = ic.ivfDB.opuEmDevDB.updateDevDate(txtID.Text, "5", dateday5);
                }
            }
            //}
        }
        private void BtnSaveDay6_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //if (MessageBox.Show("ต้องการ บันทึกช้อมูล Day 6 Embryo Development  ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            ic.cStf.staff_id = "";
            Boolean chkSave = false;
            FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            frm.ShowDialog(this);
            if (!ic.cStf.staff_id.Equals(""))
            {
                //setOPUEmbryoFreezDay1();
                //String re = ic.ivfDB.opuDB.updateEmbryoFreezDay1(opu, ic.user.staff_id);
                String re = "";
                int i = 1;
                foreach (Row row in grfDay6.Rows)
                {
                    if (row[colDay6Edit] == null) continue;
                    if (row[colDay6Edit].ToString().Equals("1"))
                    {
                        if (row[colDay6Desc] == null) continue;

                        LabOpuEmbryoDev opuEmDev = new LabOpuEmbryoDev();
                        opuEmDev.opu_embryo_dev_id = row[colDay6ID] != null ? row[colDay6ID].ToString() : "";
                        opuEmDev.opu_fet_id = txtID.Text;
                        opuEmDev.day = "6";
                        opuEmDev.opu_embryo_dev_no = row[colDay6Num] != null ? row[colDay6Num].ToString() : i.ToString();
                        opuEmDev.desc0 = row[colDay6Desc].ToString();
                        opuEmDev.active = "1";
                        opuEmDev.remark = "";
                        opuEmDev.path_pic = "";
                        opuEmDev.date_create = "";
                        opuEmDev.date_modi = "";
                        opuEmDev.date_cancel = "";
                        opuEmDev.user_create = "";
                        opuEmDev.user_modi = "";
                        opuEmDev.user_cancel = "";
                        opuEmDev.desc1 = row[colDay6Desc1] != null ? row[colDay6Desc1].ToString() : "";
                        opuEmDev.desc2 = row[colDay6Desc2] != null ? row[colDay6Desc2].ToString() : "";
                        opuEmDev.desc3 = "";

                        opuEmDev.staff_id = cboEmbryologistDay6.SelectedItem == null ? "" : ((ComboBoxItem)cboEmbryologistDay6.SelectedItem).Value;
                        opuEmDev.checked_id = cboCheckedDay6.SelectedItem == null ? "" : ((ComboBoxItem)cboCheckedDay6.SelectedItem).Value;
                        opuEmDev.embryo_dev_date = ic.dateTimetoDB(txtDay6Date.Text);
                        re = ic.ivfDB.opuEmDevDB.insertLabOpuEmbryoDev(opuEmDev, ic.cStf.staff_id);
                        long chk = 0;
                        if (long.TryParse(re, out chk))
                        {
                            chkSave = true;
                            row[colDay6Edit] = "0";
                            //MessageBox.Show("Error", "");
                        }
                    }
                    i++;
                }
                long chk1 = 0;
                if (chkSave)
                {
                    setGrfDay6();
                    btnSaveDay5.Image = Resources.accept_database24;
                }
                else
                {
                    btnSaveDay5.Image = Resources.accept_database24;
                }
                if (cboEmbryologistDay6.SelectedItem != null)
                {
                    String staff_id = "";
                    staff_id = cboEmbryologistDay6.SelectedItem == null ? "" : ((ComboBoxItem)cboEmbryologistDay6.SelectedItem).Value;
                    String re1 = ic.ivfDB.opuEmDevDB.updateStff(txtID.Text, "6", staff_id);
                }
                if (cboCheckedDay6.SelectedItem != null)
                {
                    String check_id = "";
                    check_id = cboCheckedDay6.SelectedItem == null ? "" : ((ComboBoxItem)cboCheckedDay6.SelectedItem).Value;
                    String re1 = ic.ivfDB.opuEmDevDB.updateChecked(txtID.Text, "6", check_id);
                }
                DateTime dtday6 = new DateTime();
                if (DateTime.TryParse(txtDay6Date.Text, out dtday6))
                {
                    String dateday6 = "";
                    dateday6 = ic.dateTimetoDB1(dtday6);
                    String re1 = ic.ivfDB.opuEmDevDB.updateDevDate(txtID.Text, "6", dateday6);
                }
            }
            //}
        }
        private void BtnSaveEmbryoEt_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //if (MessageBox.Show("ต้องการ บันทึกช้อมูล Embryo for ET ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            ic.cStf.staff_id = "";
            FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            frm.ShowDialog(this);
            if (!ic.cStf.staff_id.Equals(""))
            {
                setFETEmbryeEt();
                String re = ic.ivfDB.fetDB.updateEmbryoEt(fet, ic.user.staff_id);
                long chk1 = 0;
                if (long.TryParse(re, out chk1))
                {
                    btnSave.Image = Resources.accept_database24;
                }
                else
                {
                    btnSave.Image = Resources.accept_database24;
                }
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            ic.cStf.staff_id = "";
            FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            frm.ShowDialog(this);
            if (!ic.cStf.staff_id.Equals(""))
            {
                saveLabFET();
                //setFET();
                //String re = ic.ivfDB.fetDB.update(fet, ic.user.staff_id);
                //long chk1 = 0;
                //if (long.TryParse(re, out chk1))
                //{
                //    btnSave.Image = Resources.accept_database24;
                //}
                //else
                //{
                //    btnSave.Image = Resources.accept_database24;
                //}
            }
            //}
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // ...
            //if (prefixSeen)
            //{
            //    if (keyData == (Keys.Alt | Keys.Control | Keys.S))
            //    {
            //        MessageBox.Show("Got it!");
            //    }
            //    prefixSeen = false;
            //    return true;
            //}
            //if (keyData == (Keys.Alt | Keys.Control | Keys.K))
            //{
            //    prefixSeen = true;
            //    return true;
            //}
            switch (keyData)
            {
                case Keys.S | Keys.Control:
                    if (ic.user.status_module_lab.Equals("1"))
                    {
                        ic.cStf.staff_id = "";
                        Boolean chkSave = false;
                        FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                        frm.ShowDialog(this);
                        if (!ic.cStf.staff_id.Equals(""))
                        {
                            saveLabFET();
                        }
                    }

                    // ... Process Shift+Ctrl+Alt+B ...
                    //MessageBox.Show("1111", "");
                    return true; // signal that we've processed this key
                case Keys.C | Keys.Control:
                    //MessageBox.Show("2222 ", "");
                    String txt = "";
                    if (grf2Focus)
                    {
                        txt = grfDay2[grfDay2.Row, grfDay2.Col].ToString();
                    }
                    else if (grf3Focus)
                    {
                        txt = grfDay3[grfDay3.Row, grfDay3.Col].ToString();
                    }
                    else if (grf5Focus)
                    {
                        txt = grfDay5[grfDay5.Row, grfDay5.Col].ToString();
                    }
                    else if (grf6Focus)
                    {
                        txt = grfDay6[grfDay6.Row, grfDay6.Col].ToString();
                    }
                    if (!txt.Equals(""))
                    {
                        Clipboard.SetText(txt);
                    }
                    return true; // signal that we've processed this key
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void saveLabFET()
        {
            //calMotile();
            //calFertili();
            setFET();
            String re = ic.ivfDB.fetDB.update(fet, ic.user.staff_id);
            sB1.Text = "Save OPU";
            Application.DoEvents();
            long chk1 = 0;
            if (long.TryParse(re, out chk1))
            {
                setThawing();
                String re1 = ic.ivfDB.fetDB.updateThawing(fet, ic.user.staff_id);
                sB1.Text = "Save Thawing";
                Application.DoEvents();
                setFETEmbryeEt();
                String re2 = ic.ivfDB.fetDB.updateEmbryoEt(fet, ic.user.staff_id);
                sB1.Text = "Save EmbryoET";
                Application.DoEvents();
                //setOPUFertilization();
                //String re3 = ic.ivfDB.opuDB.updateFertili(opu, ic.user.staff_id);
                //sB1.Text = "Save Fertili";
                //Application.DoEvents();
                //setOPUEmbryoFreezDay0();
                //String r4 = ic.ivfDB.opuDB.updateEmbryoFreezDay0(opu, ic.user.staff_id);
                //sB1.Text = "Save Freez Day0";
                //Application.DoEvents();
                //setOPUEmbryoFreezDay1();
                //String r5 = ic.ivfDB.opuDB.updateEmbryoFreezDay1(opu, ic.user.staff_id);
                //sB1.Text = "Save Freez Day1";
                //Application.DoEvents();
                //setOPUSperm();
                //String re6 = ic.ivfDB.opuDB.updateSperm(opu, ic.user.staff_id);
                //sB1.Text = "Save Sperm";
                //Application.DoEvents();
                saveDay2();
                sB1.Text = "Save Day2";
                Application.DoEvents();
                saveDay3();
                sB1.Text = "Save Day3";
                Application.DoEvents();
                saveDay5();
                sB1.Text = "Save Day5";
                Application.DoEvents();
                saveDay6();
                sB1.Text = "Save OPU success";
                btnSave.Image = Resources.accept_database24;
            }
            else
            {
                btnSave.Image = Resources.accept_database24;
            }
        }
        private Boolean saveDay2()
        {
            Boolean chkSave = false;
            String staff_id = "", check_id = "", dateday2 = "";
            staff_id = cboEmbryologistDay2.SelectedItem == null ? "" : ((ComboBoxItem)cboEmbryologistDay2.SelectedItem).Value;
            String re1 = ic.ivfDB.opuEmDevDB.updateStff(txtID.Text, "2", staff_id);

            check_id = cboCheckedDay2.SelectedItem == null ? "" : ((ComboBoxItem)cboCheckedDay2.SelectedItem).Value;
            String re2 = ic.ivfDB.opuEmDevDB.updateChecked(txtID.Text, "2", check_id);

            DateTime dtday2 = new DateTime();
            if (DateTime.TryParse(txtDay2Date.Text, out dtday2))
            {
                dateday2 = ic.dateTimetoDB1(dtday2);
                String re3 = ic.ivfDB.opuEmDevDB.updateDevDate(txtID.Text, "2", dateday2);
            }
            //setOPUEmbryoFreezDay1();
            //String re = ic.ivfDB.opuDB.updateEmbryoFreezDay1(opu, ic.user.staff_id);
            String re = "";
            int i = 1;
            foreach (Row row in grfDay2.Rows)
            {
                if (row[colDay2Edit] == null) continue;
                if (row[colDay2Edit].ToString().Equals("1"))
                {
                    if (row[colDay2Desc] == null) continue;

                    LabOpuEmbryoDev opuEmDev = new LabOpuEmbryoDev();
                    opuEmDev.opu_embryo_dev_id = row[colDay2ID] != null ? row[colDay2ID].ToString() : "";
                    opuEmDev.opu_fet_id = txtID.Text;
                    opuEmDev.day = "2";
                    opuEmDev.opu_embryo_dev_no = row[colDay2Num] != null ? row[colDay2Num].ToString() : i.ToString();
                    opuEmDev.desc0 = row[colDay2Desc].ToString();
                    opuEmDev.active = "1";
                    opuEmDev.remark = "";
                    opuEmDev.path_pic = "";
                    opuEmDev.date_create = "";
                    opuEmDev.date_modi = "";
                    opuEmDev.date_cancel = "";
                    opuEmDev.user_create = "";
                    opuEmDev.user_modi = "";
                    opuEmDev.user_cancel = "";
                    opuEmDev.desc1 = row[colDay2Desc1] != null ? row[colDay2Desc1].ToString() : "";
                    opuEmDev.desc2 = row[colDay2Desc2] != null ? row[colDay2Desc2].ToString() : "";
                    opuEmDev.desc3 = "";

                    //opuEmDev.staff_id = cboEmbryologistDay2.SelectedItem == null ? "" : ((ComboBoxItem)cboEmbryologistDay2.SelectedItem).Value;
                    //opuEmDev.checked_id = cboCheckedDay2.SelectedItem == null ? "" : ((ComboBoxItem)cboCheckedDay2.SelectedItem).Value;
                    //opuEmDev.embryo_dev_date = ic.dateTimetoDB(txtDay2Date.Text);
                    opuEmDev.staff_id = "";
                    opuEmDev.checked_id = "";
                    opuEmDev.embryo_dev_date = "";
                    re = ic.ivfDB.opuEmDevDB.insertLabOpuEmbryoDev(opuEmDev, ic.cStf.staff_id);
                    long chk = 0;
                    if (long.TryParse(re, out chk))
                    {
                        row[colDay2Edit] = "0";
                        chkSave = true;
                        //MessageBox.Show("Error", "");
                    }
                    else
                    {
                        chkSave = false;
                    }
                }
                i++;
            }
            return chkSave;
        }
        private Boolean saveDay3()
        {
            Boolean chkSave = false;
            String staff_id = "", check_id = "", dateday3 = "";
            staff_id = cboEmbryologistDay3.SelectedItem == null ? "" : ((ComboBoxItem)cboEmbryologistDay3.SelectedItem).Value;
            String re1 = ic.ivfDB.opuEmDevDB.updateStff(txtID.Text, "3", staff_id);

            check_id = cboCheckedDay3.SelectedItem == null ? "" : ((ComboBoxItem)cboCheckedDay3.SelectedItem).Value;
            String re2 = ic.ivfDB.opuEmDevDB.updateChecked(txtID.Text, "3", check_id);
            DateTime dtday3 = new DateTime();
            if (DateTime.TryParse(txtDay3Date.Text, out dtday3))
            {
                dateday3 = ic.dateTimetoDB1(dtday3);
                String re3 = ic.ivfDB.opuEmDevDB.updateDevDate(txtID.Text, "3", dateday3);
            }
            //setOPUEmbryoFreezDay1();
            //String re = ic.ivfDB.opuDB.updateEmbryoFreezDay1(opu, ic.user.staff_id);
            String re = "";
            int i = 1;
            foreach (Row row in grfDay3.Rows)
            {
                if (row[colDay3Edit] == null) continue;
                if (row[colDay3Edit].ToString().Equals("1"))
                {
                    if (row[colDay3Desc] == null) continue;

                    LabOpuEmbryoDev opuEmDev = new LabOpuEmbryoDev();
                    opuEmDev.opu_embryo_dev_id = row[colDay3ID] != null ? row[colDay3ID].ToString() : "";
                    opuEmDev.opu_fet_id = txtID.Text;
                    opuEmDev.day = "3";
                    opuEmDev.opu_embryo_dev_no = row[colDay3Num] != null ? row[colDay3Num].ToString() : i.ToString();
                    opuEmDev.desc0 = row[colDay3Desc].ToString();
                    opuEmDev.active = "1";
                    opuEmDev.remark = "";
                    opuEmDev.path_pic = "";
                    opuEmDev.date_create = "";
                    opuEmDev.date_modi = "";
                    opuEmDev.date_cancel = "";
                    opuEmDev.user_create = "";
                    opuEmDev.user_modi = "";
                    opuEmDev.user_cancel = "";
                    opuEmDev.desc1 = row[colDay3Desc1] != null ? row[colDay3Desc1].ToString() : "";
                    opuEmDev.desc2 = row[colDay3Desc2] != null ? row[colDay3Desc2].ToString() : "";
                    opuEmDev.desc3 = "";

                    //opuEmDev.staff_id = cboEmbryologistDay3.SelectedItem == null ? "" : ((ComboBoxItem)cboEmbryologistDay3.SelectedItem).Value;
                    //opuEmDev.checked_id = cboCheckedDay3.SelectedItem == null ? "" : ((ComboBoxItem)cboCheckedDay3.SelectedItem).Value;
                    //opuEmDev.embryo_dev_date = ic.dateTimetoDB(txtDay3Date.Text);
                    opuEmDev.staff_id = "";
                    opuEmDev.checked_id = "";
                    opuEmDev.embryo_dev_date = "";
                    re = ic.ivfDB.opuEmDevDB.insertLabOpuEmbryoDev(opuEmDev, ic.cStf.staff_id);
                    long chk = 0;
                    if (long.TryParse(re, out chk))
                    {
                        row[colDay3Edit] = "0";
                        //MessageBox.Show("Error", "");
                        chkSave = true;
                    }
                    else
                    {
                        chkSave = false;
                    }
                }
                i++;
            }
            return chkSave;
        }
        private Boolean saveDay5()
        {
            Boolean chkSave = false;
            String staff_id = "", check_id = "", dateday5 = "";
            staff_id = cboEmbryologistDay5.SelectedItem == null ? "" : ((ComboBoxItem)cboEmbryologistDay5.SelectedItem).Value;
            String re1 = ic.ivfDB.opuEmDevDB.updateStff(txtID.Text, "5", staff_id);
            check_id = cboCheckedDay5.SelectedItem == null ? "" : ((ComboBoxItem)cboCheckedDay5.SelectedItem).Value;
            String re2 = ic.ivfDB.opuEmDevDB.updateChecked(txtID.Text, "5", check_id);
            DateTime dtday5 = new DateTime();
            if (DateTime.TryParse(txtDay5Date.Text, out dtday5))
            {
                dateday5 = ic.dateTimetoDB1(dtday5);
                String re3 = ic.ivfDB.opuEmDevDB.updateDevDate(txtID.Text, "5", dateday5);
            }

            //setOPUEmbryoFreezDay1();
            //String re = ic.ivfDB.opuDB.updateEmbryoFreezDay1(opu, ic.user.staff_id);
            String re = "";
            int i = 1;
            foreach (Row row in grfDay5.Rows)
            {
                if (row[colDay5Edit] == null) continue;
                if (row[colDay5Edit].ToString().Equals("1"))
                {
                    if (row[colDay5Desc] == null) continue;

                    LabOpuEmbryoDev opuEmDev = new LabOpuEmbryoDev();
                    opuEmDev.opu_embryo_dev_id = row[colDay5ID] != null ? row[colDay5ID].ToString() : "";
                    opuEmDev.opu_fet_id = txtID.Text;
                    opuEmDev.day = "5";
                    opuEmDev.opu_embryo_dev_no = row[colDay5Num] != null ? row[colDay5Num].ToString() : i.ToString();
                    opuEmDev.desc0 = row[colDay5Desc].ToString();
                    opuEmDev.active = "1";
                    opuEmDev.remark = "";
                    opuEmDev.path_pic = "";
                    opuEmDev.date_create = "";
                    opuEmDev.date_modi = "";
                    opuEmDev.date_cancel = "";
                    opuEmDev.user_create = "";
                    opuEmDev.user_modi = "";
                    opuEmDev.user_cancel = "";
                    opuEmDev.desc1 = row[colDay5Desc1] != null ? row[colDay5Desc1].ToString() : "";
                    opuEmDev.desc2 = row[colDay5Desc2] != null ? row[colDay5Desc2].ToString() : "";
                    opuEmDev.desc3 = "";

                    //opuEmDev.staff_id = cboEmbryologistDay5.SelectedItem == null ? "" : ((ComboBoxItem)cboEmbryologistDay5.SelectedItem).Value;
                    //opuEmDev.checked_id = cboCheckedDay5.SelectedItem == null ? "" : ((ComboBoxItem)cboCheckedDay5.SelectedItem).Value;
                    //opuEmDev.embryo_dev_date = ic.dateTimetoDB(txtDay5Date.Text);
                    opuEmDev.staff_id = "";
                    opuEmDev.checked_id = "";
                    opuEmDev.embryo_dev_date = "";
                    re = ic.ivfDB.opuEmDevDB.insertLabOpuEmbryoDev(opuEmDev, ic.cStf.staff_id);
                    long chk = 0;
                    if (long.TryParse(re, out chk))
                    {
                        chkSave = true;
                        row[colDay5Edit] = "0";
                        //MessageBox.Show("Error", "");
                    }
                }
                i++;
            }
            return chkSave;
        }
        private Boolean saveDay6()
        {
            Boolean chkSave = false;
            String staff_id = "", check_id = "", dateday6 = "";
            staff_id = cboEmbryologistDay6.SelectedItem == null ? "" : ((ComboBoxItem)cboEmbryologistDay6.SelectedItem).Value;
            String re1 = ic.ivfDB.opuEmDevDB.updateStff(txtID.Text, "6", staff_id);

            check_id = cboCheckedDay6.SelectedItem == null ? "" : ((ComboBoxItem)cboCheckedDay6.SelectedItem).Value;
            String re2 = ic.ivfDB.opuEmDevDB.updateChecked(txtID.Text, "6", check_id);

            DateTime dtday6 = new DateTime();
            if (DateTime.TryParse(txtDay6Date.Text, out dtday6))
            {
                dateday6 = ic.dateTimetoDB1(dtday6);
                String re3 = ic.ivfDB.opuEmDevDB.updateDevDate(txtID.Text, "6", dateday6);
            }
            //setOPUEmbryoFreezDay1();
            //String re = ic.ivfDB.opuDB.updateEmbryoFreezDay1(opu, ic.user.staff_id);
            String re = "";
            int i = 1;
            foreach (Row row in grfDay6.Rows)
            {
                if (row[colDay6Edit] == null) continue;
                if (row[colDay6Edit].ToString().Equals("1"))
                {
                    if (row[colDay6Desc] == null) continue;

                    LabOpuEmbryoDev opuEmDev = new LabOpuEmbryoDev();
                    opuEmDev.opu_embryo_dev_id = row[colDay6ID] != null ? row[colDay6ID].ToString() : "";
                    opuEmDev.opu_fet_id = txtID.Text;
                    opuEmDev.day = "6";
                    opuEmDev.opu_embryo_dev_no = row[colDay6Num] != null ? row[colDay6Num].ToString() : i.ToString();
                    opuEmDev.desc0 = row[colDay6Desc].ToString();
                    opuEmDev.active = "1";
                    opuEmDev.remark = "";
                    opuEmDev.path_pic = "";
                    opuEmDev.date_create = "";
                    opuEmDev.date_modi = "";
                    opuEmDev.date_cancel = "";
                    opuEmDev.user_create = "";
                    opuEmDev.user_modi = "";
                    opuEmDev.user_cancel = "";
                    opuEmDev.desc1 = row[colDay6Desc1] != null ? row[colDay6Desc1].ToString() : "";
                    opuEmDev.desc2 = row[colDay6Desc2] != null ? row[colDay6Desc2].ToString() : "";
                    opuEmDev.desc3 = "";

                    //opuEmDev.staff_id = cboEmbryologistDay6.SelectedItem == null ? "" : ((ComboBoxItem)cboEmbryologistDay6.SelectedItem).Value;
                    //opuEmDev.checked_id = cboCheckedDay6.SelectedItem == null ? "" : ((ComboBoxItem)cboCheckedDay6.SelectedItem).Value;
                    //opuEmDev.embryo_dev_date = ic.dateTimetoDB(txtDay6Date.Text);
                    opuEmDev.staff_id = "";
                    opuEmDev.checked_id = "";
                    opuEmDev.embryo_dev_date = "";
                    re = ic.ivfDB.opuEmDevDB.insertLabOpuEmbryoDev(opuEmDev, ic.cStf.staff_id);
                    long chk = 0;
                    if (long.TryParse(re, out chk))
                    {
                        chkSave = true;
                        row[colDay6Edit] = "0";
                        //MessageBox.Show("Error", "");
                    }
                }
                i++;
            }
            return chkSave;
        }
        private void setFET()
        {
            fet.fet_id = txtID.Text;
            fet.hn_female = txtHnFeMale.Text;
            fet.hn_male = txtHnMale.Text;
            fet.name_female = txtNameFeMale.Text;
            fet.name_male = txtNameMale.Text;
            //lbReq.req_code = txtLabReqCode.Text;
            fet.dob_female = ic.datetoDB(txtDobFeMale.Text);
            fet.dob_male = ic.datetoDB(txtDobMale.Text);
            
            fet.fet_date = ic.datetoDB(txtFetDate.Text);
            
            fet.doctor_id = cboDoctor.SelectedItem == null ? "" : ((ComboBoxItem)cboDoctor.SelectedItem).Value;
            fet.proce_id = cboOpuProce.SelectedItem == null ? "" : ((ComboBoxItem)cboOpuProce.SelectedItem).Value;
            fet.fet_code = txtFetCode.Text;
            fet.remark = cboRemark.Text;
            fet.embryo_for_et_remark = cboRemark.Text;
            fet.hn_donor = txtHnDonor.Text;
            fet.name_donor = txtNameDonor.Text;
            fet.date_pic_embryo = ic.datetoDB(txtDatePicEmbryo.Text);
            
        }
        private void setThawing()
        {
            fet.fet_id = txtID.Text;
            fet.freeze_date = ic.datetoDB(txtFreezeDate.Text);
            fet.freeze_no_of_freeze = txtFreezeNo.Text;
            fet.freeze_stage_of_freeze = txtFreezeStage.Text;
            fet.thaw_date = ic.datetoDB(txtThawDate.Text);
            fet.thaw_no_of_thaw = txtThawNo.Text;
            fet.thaw_no_of_survival = txtThawSurvival.Text;
            fet.thaw_no_of_remaining = txtThawRemain.Text;
            //fet.media_date = ic.datetoDB(txtMediaDate.Text);
            fet.embryo_freez_freeze_media = cboEmbryoFreezMedia.SelectedItem == null ? "" : ((ComboBoxItem)cboEmbryoFreezMedia.SelectedItem).Value;
            fet.media_exp = txtMediaExp.Text;
            fet.media_lot_no = txtMediaLot.Text;
            fet.media_thawing = txtMediaThawing.Text;
        }
        private void setFETEmbryeEt()
        {
            fet.fet_id = txtID.Text;
            fet.embryo_for_et_no_of_et = txtEmbryoForEtNO.Text;
            fet.embryo_for_et_day = txtEmbryoForEtDay.Text;
            fet.embryo_for_et_date = ic.datetoDB(txtEmbryoForEtDate.Text);
            fet.embryo_for_et_assisted = txtEmbryoForEtAsseted.Text;
            fet.embryo_for_et_volume = txtEmbryoForEtVolume.Text;
            fet.embryo_for_et_catheter = txtEmbryoForEtCatheter.Text;
            fet.embryo_for_et_doctor = txtEmbryoForEtDoctor.Text;

            fet.embryo_for_et_embryologist_id = cboEmbryoForEtEmbryologist.SelectedItem == null ? "0" : ((ComboBoxItem)cboEmbryoForEtEmbryologist.SelectedItem).Value;
            fet.embryologist_report_id = cboEmbryologistReport.SelectedItem == null ? "0" : ((ComboBoxItem)cboEmbryologistReport.SelectedItem).Value;
            fet.embryologist_approve_id = cboEmbryologistAppv.SelectedItem == null ? "0" : ((ComboBoxItem)cboEmbryologistAppv.SelectedItem).Value;

            //opu.remark = txtRemark.Text;
            fet.remark = cboRemark.Text;
            fet.embryo_for_et_number_of_transfer = txtEmbryoForEtNumTran.Text;
            fet.embryo_for_et_number_of_freeze = txtEmbryoForEtNumFreeze.Text;
            fet.embryo_for_et_number_of_discard = txtEmbryoForEtNumDiscard.Text;
            fet.embryo_for_et_remark = cboRemark.Text;
        }
        private void setGrfDay2Img()
        {
            grfDay2Img.Clear();
            grfDay2Img.DataSource = null;
            grfDay2Img.Rows.Count = 1;
            grfDay2Img.Cols.Count = 6;
            DataTable dt = new DataTable();
            dt = ic.ivfDB.opuEmDevDB.selectByOpuFetId_Day(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day2);

            C1TextBox txt = new C1TextBox();
            Button btn = new Button();
            btn.BackColor = Color.Gray;

            PictureBox img = new PictureBox();

            grfDay2Img.Cols[colDay2ImgId].Editor = txt;
            grfDay2Img.Cols[colDay2ImgNun].Editor = txt;
            grfDay2Img.Cols[colDay2ImgDesc0].Editor = txt;
            grfDay2Img.Cols[colDay2PathPic].Editor = txt;
            //grfDay2Img.Cols[colDay2ImgBtn].Editor = btn;
            grfDay2Img.Cols[colDay2ImgPic].Editor = img;

            grfDay2Img.Cols[colDay2ImgId].Width = 250;
            grfDay2Img.Cols[colDay2ImgPic].Width = 100;
            grfDay2Img.Cols[colDay2ImgDesc0].Width = 100;
            grfDay2Img.Cols[colDay2ImgNun].Width = 100;
            grfDay2Img.Cols[colDay2PathPic].Width = 100;

            grfDay2Img.ShowCursor = true;

            grfDay2Img.Cols[colDay2ImgNun].Caption = "No";
            grfDay2Img.Cols[colDay2ImgDesc0].Caption = "Desc1";
            grfDay2Img.Cols[colDay2PathPic].Caption = "pathpic";

            grfDay2Img.Cols[colDay2ImgPic].ImageAndText = false;

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            grfDay2Img.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictRows;
            grfDay2Img.Cols[colDay2ImgPic].AllowMerging = true;

            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                i++;
                Row row1 = grfDay2Img.Rows.Add();
                row1[colDay2ImgId] = row[ic.ivfDB.opuEmDevDB.opuEmDev.opu_embryo_dev_id].ToString();
                row1[colDay2ImgNun] = row[ic.ivfDB.opuEmDevDB.opuEmDev.opu_embryo_dev_no].ToString();
                row1[colDay2ImgDesc0] = row[ic.ivfDB.opuEmDevDB.opuEmDev.desc3].ToString();
                row1[colDay2PathPic] = row[ic.ivfDB.opuEmDevDB.opuEmDev.path_pic].ToString();

                if (row[ic.ivfDB.opuEmDevDB.opuEmDev.path_pic] != null && !row[ic.ivfDB.opuEmDevDB.opuEmDev.path_pic].ToString().Equals(""))
                {
                    //Thread threadA = new Thread(ExecuteA);
                    //threadA.Start("");
                    int ii = i;
                    new Thread(() =>
                    {
                        Thread.CurrentThread.IsBackground = true;
                        Image loadedImage = null, resizedImage;
                        String aaa = row[ic.ivfDB.opuEmDevDB.opuEmDev.path_pic].ToString();
                        FtpWebRequest ftpRequest = null;
                        FtpWebResponse ftpResponse = null;
                        Stream ftpStream = null;
                        int bufferSize = 2048;
                        MemoryStream stream = new MemoryStream();
                        string host = null;
                        string user = null;
                        string pass = null;     //iniC.hostFTP, iniC.userFTP, iniC.passFTP
                        host = ic.iniC.hostFTP; user = ic.iniC.userFTP; pass = ic.iniC.passFTP;
                        try
                        {
                            ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + aaa);
                            ftpRequest.Credentials = new NetworkCredential(user, pass);
                            ftpRequest.UseBinary = true;
                            ftpRequest.UsePassive = ic.ftpUsePassive;
                            ftpRequest.KeepAlive = true;
                            ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                            ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                            ftpStream = ftpResponse.GetResponseStream();
                            byte[] byteBuffer = new byte[bufferSize];
                            int bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
                            try
                            {
                                while (bytesRead > 0)
                                {
                                    stream.Write(byteBuffer, 0, bytesRead);
                                    bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());
                            }
                            loadedImage = new Bitmap(stream);
                            ftpStream.Close();
                            ftpResponse.Close();
                            ftpRequest = null;
                        }
                        catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                        grfDay2Img.Cols[colDay2ImgPic].ImageAndText = true;
                        if (loadedImage != null)
                        {
                            int originalWidth = loadedImage.Width;
                            int newWidth = 180;
                            resizedImage = loadedImage.GetThumbnailImage(newWidth, (newWidth * loadedImage.Height) / originalWidth, null, IntPtr.Zero);
                            Column col = grfDay2Img.Cols[colDay2ImgPic];
                            col.DataType = typeof(Image);
                            row1[colDay2ImgPic] = resizedImage;
                            flagDay2Img = true;
                        }
                    }).Start();
                }
            }
            grfDay2Img.Cols[colDay2ImgId].Visible = false;
            grfDay2Img.Cols[colDay2PathPic].Visible = false;
            //grfDay2Img.Cols[colDay2ImgPic].AllowEditing = false;
            grfDay2Img.AutoSizeCols();
            grfDay2Img.AutoSizeRows();
            theme1.SetTheme(grfDay2Img, ic.iniC.themeFET);
            grfDay2Img.Refresh();
        }

        private void initGrfDay2Img()
        {
            grfDay2Img = new C1FlexGrid();
            grfDay2Img.Font = fEdit;
            grfDay2Img.Dock = System.Windows.Forms.DockStyle.Fill;
            grfDay2Img.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            grfDay2Img.DoubleClick += GrfDay2Img_DoubleClick;
            //grfDay2.ChangeEdit += GrfDay2_ChangeEdit;
            //grfDay2.CellChanged += GrfDay2_CellChanged;
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("&Upload image", new EventHandler(ContextMenu_grfday2_upload));
            menuGw.MenuItems.Add("&Save description", new EventHandler(ContextMenu_grfday2_save));
            menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_grfday2_Cancel));
            grfDay2Img.ContextMenu = menuGw;
            pnGrf2Img.Controls.Add(grfDay2Img);

            theme1.SetTheme(grfDay2Img, ic.iniC.themeFET);
        }
        private void ContextMenu_grfday2_upload(object sender, System.EventArgs e)
        {
            String pathfile1 = grfDay2Img[grfDay2Img.Row, colDay2PathPic] != null ? grfDay2Img[grfDay2Img.Row, colDay2PathPic].ToString() : "";
            if (pathfile1.Length > 0)
            {
                MessageBox.Show("มีรูปภาพ อยู่แล้ว กรุณา ยกเลิก ก่อน Upload รูปใหม่ ", "");
                return;
            }

            if (MessageBox.Show("ต้องการ Upload image to server ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Images (*.BMP;*.JPG;*.Jepg;*.Png;*.GIF)|*.BMP;*.JPG;*.Jepg;*.Png;*.GIF|Pdf Files|*.pdf|All files (*.*)|*.*";
                ofd.Multiselect = false;
                ofd.Title = "My Image Browser";
                DialogResult dr = ofd.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    String id = grfDay2Img[grfDay2Img.Row, colDay2ImgId].ToString();
                    String pathfile = ofd.FileName;
                    String desc = grfDay2Img[grfDay2Img.Row, colDay2ImgDesc0] != null ? grfDay2Img[grfDay2Img.Row, colDay2ImgDesc0].ToString() : "";
                    String no = grfDay2Img[grfDay2Img.Row, colDay2ImgNun] != null ? grfDay2Img[grfDay2Img.Row, colDay2ImgNun].ToString() : "";
                    if (no.Length > 0)
                    {
                        ic.cStf.staff_id = "";
                        FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                        frm.ShowDialog(this);
                        if (!ic.cStf.staff_id.Equals(""))
                        {
                            String filename = "", re = "";
                            String[] ext = pathfile.Split('.');
                            if (ext.Length > 1)
                            {
                                filename = txtFetCode.Text + "_day2_" + no + "." + ext[ext.Length - 1];
                                re = ic.ivfDB.opuEmDevDB.updatePathPic(id, no, ic.iniC.folderFTP + "/" + txtFetCode.Text + "/" + filename, desc, ic.cStf.staff_id);
                                long chk = 0;
                                if (long.TryParse(re, out chk))
                                {
                                    ic.savePicOPUtoServer(txtFetCode.Text, filename, pathfile);
                                    grfDay2Img.Rows[grfDay2Img.Row].StyleNew.BackColor = color;
                                    setGrfDay2Img();
                                }
                            }
                        }
                    }
                }
            }
        }
        private void ContextMenu_grfday2_save(object sender, System.EventArgs e)
        {
            String id = grfDay2Img[grfDay2Img.Row, colDay2ImgId].ToString();
            String desc = grfDay2Img[grfDay2Img.Row, colDay2ImgDesc0].ToString();
            String num = grfDay2Img[grfDay2Img.Row, colDay2ImgNun].ToString();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล \n Number " + num + " description " + desc, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                ic.cStf.staff_id = "";
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    String re = ic.ivfDB.opuEmDevDB.updateNumDesc(id, num, desc, ic.user.staff_id);
                }
            }
        }
        private void ContextMenu_grfday2_Cancel(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("ต้องการ ยกเลิก ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                String id = grfDay2Img[grfDay2Img.Row, colDay2ImgId].ToString();
                ic.cStf.staff_id = "";
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    String pathfile = grfDay2Img[grfDay2Img.Row, colDay2PathPic].ToString();
                    String re = ic.ivfDB.opuEmDevDB.updatePathPic(id, "", "", "", ic.user.staff_id);
                    ic.delPicOPUtoServer(txtFetCode.Text, pathfile);
                    grfDay2Img[grfDay2Img.Row, colDay2PathPic] = "";
                }
            }
        }
        private void GrfDay2Img_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfDay2Img.Row < 0) return;
            if (grfDay2Img.Col == colDay2ImgPic)
            {
                //MessageBox.Show("a "+grfImg[grfImg.Row, colImg].ToString(), "");
                int row = 0;
                //int.TryParse(grfImg[grfImg.Row, colImg].ToString(), out row);
                int.TryParse(grfDay2Img.Row.ToString(), out row);
                //row *= 4;
                FrmShowImage frm = new FrmShowImage(ic, grfDay2Img[row, colDay2ID] != null ? grfDay2Img[row, colDay2ID].ToString() : "", "", grfDay2Img[row, colDay2PathPic].ToString(), FrmShowImage.statusModule.LabOPU);
                frm.ShowDialog(this);
            }
        }
        private void setGrfDay3Img()
        {
            grfDay3Img.Clear();
            grfDay3Img.DataSource = null;
            grfDay3Img.Rows.Count = 1;
            grfDay3Img.Cols.Count = 6;
            DataTable dt = new DataTable();
            dt = ic.ivfDB.opuEmDevDB.selectByOpuFetId_Day(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day3);

            C1TextBox txt = new C1TextBox();
            Button btn = new Button();
            btn.BackColor = Color.Gray;

            PictureBox img = new PictureBox();

            grfDay3Img.Cols[colDay2ImgId].Editor = txt;
            grfDay3Img.Cols[colDay2ImgNun].Editor = txt;
            grfDay3Img.Cols[colDay2ImgDesc0].Editor = txt;
            grfDay3Img.Cols[colDay2PathPic].Editor = txt;
            //grfDay2Img.Cols[colDay2ImgBtn].Editor = btn;
            grfDay3Img.Cols[colDay2ImgPic].Editor = img;

            grfDay3Img.Cols[colDay2ImgId].Width = 250;
            grfDay3Img.Cols[colDay2ImgPic].Width = 100;
            grfDay3Img.Cols[colDay2ImgDesc0].Width = 100;
            grfDay3Img.Cols[colDay2ImgNun].Width = 100;
            grfDay3Img.Cols[colDay2PathPic].Width = 100;

            grfDay3Img.ShowCursor = true;

            grfDay3Img.Cols[colDay2ImgNun].Caption = "No";
            grfDay3Img.Cols[colDay2ImgDesc0].Caption = "Desc1";
            grfDay3Img.Cols[colDay2PathPic].Caption = "pathpic";

            grfDay3Img.Cols[colDay2ImgPic].ImageAndText = false;

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            grfDay3Img.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictRows;
            grfDay3Img.Cols[colDay2ImgPic].AllowMerging = true;

            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                i++;
                Row row1 = grfDay3Img.Rows.Add();
                row1[colDay2ImgId] = row[ic.ivfDB.opuEmDevDB.opuEmDev.opu_embryo_dev_id].ToString();
                row1[colDay2ImgNun] = row[ic.ivfDB.opuEmDevDB.opuEmDev.opu_embryo_dev_no].ToString();
                row1[colDay2ImgDesc0] = row[ic.ivfDB.opuEmDevDB.opuEmDev.desc3].ToString();
                row1[colDay2PathPic] = row[ic.ivfDB.opuEmDevDB.opuEmDev.path_pic].ToString();

                if (row[ic.ivfDB.opuEmDevDB.opuEmDev.path_pic] != null && !row[ic.ivfDB.opuEmDevDB.opuEmDev.path_pic].ToString().Equals(""))
                {
                    //Thread threadA = new Thread(ExecuteA);
                    //threadA.Start("");
                    int ii = i;
                    new Thread(() =>
                    {
                        Thread.CurrentThread.IsBackground = true;
                        Image loadedImage = null, resizedImage;
                        String aaa = row[ic.ivfDB.opuEmDevDB.opuEmDev.path_pic].ToString();
                        FtpWebRequest ftpRequest = null;
                        FtpWebResponse ftpResponse = null;
                        Stream ftpStream = null;
                        int bufferSize = 2048;
                        MemoryStream stream = new MemoryStream();
                        string host = null;
                        string user = null;
                        string pass = null;     //iniC.hostFTP, iniC.userFTP, iniC.passFTP
                        host = ic.iniC.hostFTP; user = ic.iniC.userFTP; pass = ic.iniC.passFTP;
                        try
                        {
                            ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + aaa);
                            ftpRequest.Credentials = new NetworkCredential(user, pass);
                            ftpRequest.UseBinary = true;
                            ftpRequest.UsePassive = ic.ftpUsePassive;
                            ftpRequest.KeepAlive = true;
                            ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                            ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                            ftpStream = ftpResponse.GetResponseStream();
                            byte[] byteBuffer = new byte[bufferSize];
                            int bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
                            try
                            {
                                while (bytesRead > 0)
                                {
                                    stream.Write(byteBuffer, 0, bytesRead);
                                    bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());
                            }
                            loadedImage = new Bitmap(stream);
                            ftpStream.Close();
                            ftpResponse.Close();
                            ftpRequest = null;
                        }
                        catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                        grfDay3Img.Cols[colDay2ImgPic].ImageAndText = true;
                        if (loadedImage != null)
                        {
                            int originalWidth = loadedImage.Width;
                            int newWidth = 180;
                            resizedImage = loadedImage.GetThumbnailImage(newWidth, (newWidth * loadedImage.Height) / originalWidth, null, IntPtr.Zero);
                            Column col = grfDay3Img.Cols[colDay2ImgPic];
                            col.DataType = typeof(Image);
                            row1[colDay2ImgPic] = resizedImage;
                            flagDay3Img = true;
                        }

                    }).Start();
                }
            }
            grfDay3Img.Cols[colDay2ImgId].Visible = false;
            grfDay3Img.Cols[colDay2PathPic].Visible = false;
            //grfDay2Img.Cols[colDay2ImgPic].AllowEditing = false;
            grfDay3Img.AutoSizeCols();
            grfDay3Img.AutoSizeRows();
            theme1.SetTheme(grfDay3Img, ic.iniC.themeFET);
            grfDay3Img.Refresh();
        }

        private void initGrfDay3Img()
        {
            grfDay3Img = new C1FlexGrid();
            grfDay3Img.Font = fEdit;
            grfDay3Img.Dock = System.Windows.Forms.DockStyle.Fill;
            grfDay3Img.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            grfDay3Img.DoubleClick += GrfDay3Img_DoubleClick;
            //grfDay2.ChangeEdit += GrfDay2_ChangeEdit;
            //grfDay2.CellChanged += GrfDay2_CellChanged;
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("&Upload image", new EventHandler(ContextMenu_grfday3_upload));
            menuGw.MenuItems.Add("&Save description", new EventHandler(ContextMenu_grfday3_save));
            menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_grfday3_Cancel));
            grfDay3Img.ContextMenu = menuGw;
            pnGrf3Img.Controls.Add(grfDay3Img);

            theme1.SetTheme(grfDay3Img, ic.iniC.themeFET);
        }
        private void ContextMenu_grfday3_upload(object sender, System.EventArgs e)
        {
            String pathfile1 = grfDay3Img[grfDay3Img.Row, colDay2PathPic] != null ? grfDay3Img[grfDay3Img.Row, colDay2PathPic].ToString() : "";
            if (pathfile1.Length > 0)
            {
                MessageBox.Show("มีรูปภาพ อยู่แล้ว กรุณา ยกเลิก ก่อน Upload รูปใหม่ ", "");
                return;
            }

            if (MessageBox.Show("ต้องการ Upload image to server ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Images (*.BMP;*.JPG;*.Jepg;*.Png;*.GIF)|*.BMP;*.JPG;*.Jepg;*.Png;*.GIF|Pdf Files|*.pdf|All files (*.*)|*.*";
                ofd.Multiselect = false;
                ofd.Title = "My Image Browser";
                DialogResult dr = ofd.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    String id = grfDay3Img[grfDay3Img.Row, colDay2ImgId].ToString();
                    String pathfile = ofd.FileName;
                    String desc = grfDay3Img[grfDay3Img.Row, colDay2ImgDesc0] != null ? grfDay3Img[grfDay3Img.Row, colDay2ImgDesc0].ToString() : "";
                    String no = grfDay3Img[grfDay3Img.Row, colDay2ImgNun] != null ? grfDay3Img[grfDay3Img.Row, colDay2ImgNun].ToString() : "";
                    if (no.Length > 0)
                    {
                        ic.cStf.staff_id = "";
                        FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                        frm.ShowDialog(this);
                        if (!ic.cStf.staff_id.Equals(""))
                        {
                            String filename = "", re = "";
                            String[] ext = pathfile.Split('.');
                            if (ext.Length > 1)
                            {
                                filename = txtFetCode.Text + "_day2_" + no + "." + ext[ext.Length - 1];
                                re = ic.ivfDB.opuEmDevDB.updatePathPic(id, no, ic.iniC.folderFTP + "/" + txtFetCode.Text + "/" + filename, desc, ic.cStf.staff_id);
                                long chk = 0;
                                if (long.TryParse(re, out chk))
                                {
                                    ic.savePicOPUtoServer(txtFetCode.Text, filename, pathfile);
                                    grfDay3Img.Rows[grfDay3Img.Row].StyleNew.BackColor = color;
                                    setGrfDay3Img();
                                }
                            }
                        }
                    }
                }
            }
        }
        private void ContextMenu_grfday3_save(object sender, System.EventArgs e)
        {
            String id = grfDay3Img[grfDay3Img.Row, colDay2ImgId].ToString();
            String desc = grfDay3Img[grfDay3Img.Row, colDay2ImgDesc0].ToString();
            String num = grfDay3Img[grfDay3Img.Row, colDay2ImgNun].ToString();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล \n Number " + num + " description " + desc, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                ic.cStf.staff_id = "";
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    String re = ic.ivfDB.opuEmDevDB.updateNumDesc(id, num, desc, ic.user.staff_id);
                }
            }
        }
        private void ContextMenu_grfday3_Cancel(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("ต้องการ ยกเลิก ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                String id = grfDay3Img[grfDay3Img.Row, colDay2ImgId].ToString();
                ic.cStf.staff_id = "";
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    String pathfile = grfDay3Img[grfDay3Img.Row, colDay2PathPic].ToString();
                    String re = ic.ivfDB.opuEmDevDB.updatePathPic(id, "", "", "", ic.user.staff_id);
                    ic.delPicOPUtoServer(txtFetCode.Text, pathfile);
                }
            }
        }
        private void GrfDay3Img_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfDay3Img.Row < 0) return;
            if (grfDay3Img.Col == colDay2ImgPic)
            {
                //MessageBox.Show("a "+grfImg[grfImg.Row, colImg].ToString(), "");
                int row = 0;
                //int.TryParse(grfImg[grfImg.Row, colImg].ToString(), out row);
                int.TryParse(grfDay3Img.Row.ToString(), out row);
                //row *= 4;
                FrmShowImage frm = new FrmShowImage(ic, grfDay3Img[row, colDay2ID] != null ? grfDay3Img[row, colDay2ID].ToString() : "", "", grfDay3Img[row, colDay2PathPic].ToString(), FrmShowImage.statusModule.LabOPU);
                frm.ShowDialog(this);
            }
        }
        private void setGrfDay5Img()
        {
            grfDay5Img.Clear();
            grfDay5Img.DataSource = null;
            grfDay5Img.Rows.Count = 1;
            grfDay5Img.Cols.Count = 6;
            DataTable dt = new DataTable();
            dt = ic.ivfDB.opuEmDevDB.selectByOpuFetId_Day(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day5);

            C1TextBox txt = new C1TextBox();
            Button btn = new Button();
            btn.BackColor = Color.Gray;

            PictureBox img = new PictureBox();

            grfDay5Img.Cols[colDay2ImgId].Editor = txt;
            grfDay5Img.Cols[colDay2ImgNun].Editor = txt;
            grfDay5Img.Cols[colDay2ImgDesc0].Editor = txt;
            grfDay5Img.Cols[colDay2PathPic].Editor = txt;
            //grfDay2Img.Cols[colDay2ImgBtn].Editor = btn;
            grfDay5Img.Cols[colDay2ImgPic].Editor = img;

            grfDay5Img.Cols[colDay2ImgId].Width = 250;
            grfDay5Img.Cols[colDay2ImgPic].Width = 100;
            grfDay5Img.Cols[colDay2ImgDesc0].Width = 100;
            grfDay5Img.Cols[colDay2ImgNun].Width = 100;
            grfDay5Img.Cols[colDay2PathPic].Width = 100;

            grfDay5Img.ShowCursor = true;

            grfDay5Img.Cols[colDay2ImgNun].Caption = "No";
            grfDay5Img.Cols[colDay2ImgDesc0].Caption = "Desc1";
            grfDay5Img.Cols[colDay2PathPic].Caption = "pathpic";

            grfDay5Img.Cols[colDay2ImgPic].ImageAndText = false;

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            grfDay5Img.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictRows;
            grfDay5Img.Cols[colDay2ImgPic].AllowMerging = true;

            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                i++;
                Row row1 = grfDay5Img.Rows.Add();
                row1[colDay2ImgId] = row[ic.ivfDB.opuEmDevDB.opuEmDev.opu_embryo_dev_id].ToString();
                row1[colDay2ImgNun] = row[ic.ivfDB.opuEmDevDB.opuEmDev.opu_embryo_dev_no].ToString();
                row1[colDay2ImgDesc0] = row[ic.ivfDB.opuEmDevDB.opuEmDev.desc3].ToString();
                row1[colDay2PathPic] = row[ic.ivfDB.opuEmDevDB.opuEmDev.path_pic].ToString();

                if (row[ic.ivfDB.opuEmDevDB.opuEmDev.path_pic] != null && !row[ic.ivfDB.opuEmDevDB.opuEmDev.path_pic].ToString().Equals(""))
                {
                    //Thread threadA = new Thread(ExecuteA);
                    //threadA.Start("");
                    int ii = i;
                    new Thread(() =>
                    {
                        Thread.CurrentThread.IsBackground = true;
                        Image loadedImage = null, resizedImage;
                        String aaa = row[ic.ivfDB.opuEmDevDB.opuEmDev.path_pic].ToString();
                        FtpWebRequest ftpRequest = null;
                        FtpWebResponse ftpResponse = null;
                        Stream ftpStream = null;
                        int bufferSize = 2048;
                        MemoryStream stream = new MemoryStream();
                        string host = null;
                        string user = null;
                        string pass = null;     //iniC.hostFTP, iniC.userFTP, iniC.passFTP
                        host = ic.iniC.hostFTP; user = ic.iniC.userFTP; pass = ic.iniC.passFTP;
                        try
                        {
                            ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + aaa);
                            ftpRequest.Credentials = new NetworkCredential(user, pass);
                            ftpRequest.UseBinary = true;
                            ftpRequest.UsePassive = ic.ftpUsePassive;
                            ftpRequest.KeepAlive = true;
                            ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                            ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                            ftpStream = ftpResponse.GetResponseStream();
                            byte[] byteBuffer = new byte[bufferSize];
                            int bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
                            try
                            {
                                while (bytesRead > 0)
                                {
                                    stream.Write(byteBuffer, 0, bytesRead);
                                    bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());
                            }
                            loadedImage = new Bitmap(stream);
                            ftpStream.Close();
                            ftpResponse.Close();
                            ftpRequest = null;
                        }
                        catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                        grfDay5Img.Cols[colDay2ImgPic].ImageAndText = true;
                        if (loadedImage != null)
                        {
                            int originalWidth = loadedImage.Width;
                            int newWidth = 180;
                            resizedImage = loadedImage.GetThumbnailImage(newWidth, (newWidth * loadedImage.Height) / originalWidth, null, IntPtr.Zero);
                            Column col = grfDay5Img.Cols[colDay2ImgPic];
                            col.DataType = typeof(Image);
                            row1[colDay2ImgPic] = resizedImage;
                            flagDay5Img = true;
                        }

                    }).Start();
                }
            }
            grfDay5Img.Cols[colDay2ImgId].Visible = false;
            grfDay5Img.Cols[colDay2PathPic].Visible = false;
            //grfDay2Img.Cols[colDay2ImgPic].AllowEditing = false;
            grfDay5Img.AutoSizeCols();
            grfDay5Img.AutoSizeRows();
            theme1.SetTheme(grfDay5Img, ic.iniC.themeFET);
            grfDay5Img.Refresh();
        }

        private void initGrfDay5Img()
        {
            grfDay5Img = new C1FlexGrid();
            grfDay5Img.Font = fEdit;
            grfDay5Img.Dock = System.Windows.Forms.DockStyle.Fill;
            grfDay5Img.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            grfDay5Img.DoubleClick += GrfDay5Img_DoubleClick;
            //grfDay2.ChangeEdit += GrfDay2_ChangeEdit;
            //grfDay2.CellChanged += GrfDay2_CellChanged;
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("&Upload image", new EventHandler(ContextMenu_grfday5_upload));
            menuGw.MenuItems.Add("&Save description", new EventHandler(ContextMenu_grfday5_save));
            menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_grfday5_Cancel));
            grfDay5Img.ContextMenu = menuGw;
            pnGrf5Img.Controls.Add(grfDay5Img);

            theme1.SetTheme(grfDay5Img, ic.iniC.themeFET);
        }
        private void ContextMenu_grfday5_upload(object sender, System.EventArgs e)
        {
            String pathfile1 = grfDay5Img[grfDay5Img.Row, colDay2PathPic] != null ? grfDay5Img[grfDay5Img.Row, colDay2PathPic].ToString() : "";
            if (pathfile1.Length > 0)
            {
                MessageBox.Show("มีรูปภาพ อยู่แล้ว กรุณา ยกเลิก ก่อน Upload รูปใหม่ ", "");
                return;
            }

            if (MessageBox.Show("ต้องการ Upload image to server ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Images (*.BMP;*.JPG;*.Jepg;*.Png;*.GIF)|*.BMP;*.JPG;*.Jepg;*.Png;*.GIF|Pdf Files|*.pdf|All files (*.*)|*.*";
                ofd.Multiselect = false;
                ofd.Title = "My Image Browser";
                DialogResult dr = ofd.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    String id = grfDay5Img[grfDay5Img.Row, colDay2ImgId].ToString();
                    String pathfile = ofd.FileName;
                    String desc = grfDay5Img[grfDay5Img.Row, colDay2ImgDesc0] != null ? grfDay5Img[grfDay5Img.Row, colDay2ImgDesc0].ToString() : "";
                    String no = grfDay5Img[grfDay5Img.Row, colDay2ImgNun] != null ? grfDay5Img[grfDay5Img.Row, colDay2ImgNun].ToString() : "";
                    if (no.Length > 0)
                    {
                        ic.cStf.staff_id = "";
                        FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                        frm.ShowDialog(this);
                        if (!ic.cStf.staff_id.Equals(""))
                        {
                            String filename = "", re = "";
                            String[] ext = pathfile.Split('.');
                            if (ext.Length > 1)
                            {
                                filename = txtFetCode.Text + "_day2_" + no + "." + ext[ext.Length - 1];
                                re = ic.ivfDB.opuEmDevDB.updatePathPic(id, no, ic.iniC.folderFTP + "/" + txtFetCode.Text + "/" + filename, desc, ic.cStf.staff_id);
                                long chk = 0;
                                if (long.TryParse(re, out chk))
                                {
                                    ic.savePicOPUtoServer(txtFetCode.Text, filename, pathfile);
                                    grfDay5Img.Rows[grfDay5Img.Row].StyleNew.BackColor = color;
                                    setGrfDay5Img();
                                }
                            }
                        }
                    }
                }
            }
        }
        private void ContextMenu_grfday5_save(object sender, System.EventArgs e)
        {
            String id = grfDay5Img[grfDay5Img.Row, colDay2ImgId].ToString();
            String desc = grfDay5Img[grfDay5Img.Row, colDay2ImgDesc0].ToString();
            String num = grfDay5Img[grfDay5Img.Row, colDay2ImgNun].ToString();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล \n Number " + num + " description " + desc, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                ic.cStf.staff_id = "";
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    String re = ic.ivfDB.opuEmDevDB.updateNumDesc(id, num, desc, ic.user.staff_id);
                }
            }
        }
        private void ContextMenu_grfday5_Cancel(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("ต้องการ ยกเลิก ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                String id = grfDay5Img[grfDay5Img.Row, colDay2ImgId].ToString();
                ic.cStf.staff_id = "";
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    String pathfile = grfDay5Img[grfDay5Img.Row, colDay2PathPic].ToString();
                    String re = ic.ivfDB.opuEmDevDB.updatePathPic(id, "", "", "", ic.user.staff_id);
                    ic.delPicOPUtoServer(txtFetCode.Text, pathfile);
                }
            }
        }
        private void GrfDay5Img_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfDay5Img.Row < 0) return;
            if (grfDay5Img.Col == colDay2ImgPic)
            {
                //MessageBox.Show("a "+grfImg[grfImg.Row, colImg].ToString(), "");
                int row = 0;
                //int.TryParse(grfImg[grfImg.Row, colImg].ToString(), out row);
                int.TryParse(grfDay5Img.Row.ToString(), out row);
                //row *= 4;
                FrmShowImage frm = new FrmShowImage(ic, grfDay5Img[row, colDay2ID] != null ? grfDay5Img[row, colDay2ID].ToString() : "", "", grfDay5Img[row, colDay2PathPic].ToString(), FrmShowImage.statusModule.LabOPU);
                frm.ShowDialog(this);
            }
        }
        private void setGrfDay6Img()
        {
            grfDay6Img.Clear();
            grfDay6Img.DataSource = null;
            grfDay6Img.Rows.Count = 1;
            grfDay6Img.Cols.Count = 6;
            DataTable dt = new DataTable();
            dt = ic.ivfDB.opuEmDevDB.selectByOpuFetId_Day(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day6);

            C1TextBox txt = new C1TextBox();
            Button btn = new Button();
            btn.BackColor = Color.Gray;

            PictureBox img = new PictureBox();

            grfDay6Img.Cols[colDay2ImgId].Editor = txt;
            grfDay6Img.Cols[colDay2ImgNun].Editor = txt;
            grfDay6Img.Cols[colDay2ImgDesc0].Editor = txt;
            grfDay6Img.Cols[colDay2PathPic].Editor = txt;
            //grfDay2Img.Cols[colDay2ImgBtn].Editor = btn;
            grfDay6Img.Cols[colDay2ImgPic].Editor = img;

            grfDay6Img.Cols[colDay2ImgId].Width = 250;
            grfDay6Img.Cols[colDay2ImgPic].Width = 100;
            grfDay6Img.Cols[colDay2ImgDesc0].Width = 100;
            grfDay6Img.Cols[colDay2ImgNun].Width = 100;
            grfDay6Img.Cols[colDay2PathPic].Width = 100;

            grfDay6Img.ShowCursor = true;

            grfDay6Img.Cols[colDay2ImgNun].Caption = "No";
            grfDay6Img.Cols[colDay2ImgDesc0].Caption = "Desc1";
            grfDay6Img.Cols[colDay2PathPic].Caption = "pathpic";

            grfDay6Img.Cols[colDay2ImgPic].ImageAndText = false;

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            grfDay6Img.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictRows;
            grfDay6Img.Cols[colDay2ImgPic].AllowMerging = true;

            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                i++;
                Row row1 = grfDay6Img.Rows.Add();
                row1[colDay2ImgId] = row[ic.ivfDB.opuEmDevDB.opuEmDev.opu_embryo_dev_id].ToString();
                row1[colDay2ImgNun] = row[ic.ivfDB.opuEmDevDB.opuEmDev.opu_embryo_dev_no].ToString();
                row1[colDay2ImgDesc0] = row[ic.ivfDB.opuEmDevDB.opuEmDev.desc3].ToString();
                row1[colDay2PathPic] = row[ic.ivfDB.opuEmDevDB.opuEmDev.path_pic].ToString();

                if (row[ic.ivfDB.opuEmDevDB.opuEmDev.path_pic] != null && !row[ic.ivfDB.opuEmDevDB.opuEmDev.path_pic].ToString().Equals(""))
                {
                    //Thread threadA = new Thread(ExecuteA);
                    //threadA.Start("");
                    int ii = i;
                    new Thread(() =>
                    {
                        Thread.CurrentThread.IsBackground = true;
                        Image loadedImage = null, resizedImage;
                        String aaa = row[ic.ivfDB.opuEmDevDB.opuEmDev.path_pic].ToString();
                        FtpWebRequest ftpRequest = null;
                        FtpWebResponse ftpResponse = null;
                        Stream ftpStream = null;
                        int bufferSize = 2048;
                        MemoryStream stream = new MemoryStream();
                        string host = null;
                        string user = null;
                        string pass = null;     //iniC.hostFTP, iniC.userFTP, iniC.passFTP
                        host = ic.iniC.hostFTP; user = ic.iniC.userFTP; pass = ic.iniC.passFTP;
                        try
                        {
                            ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + aaa);
                            ftpRequest.Credentials = new NetworkCredential(user, pass);
                            ftpRequest.UseBinary = true;
                            ftpRequest.UsePassive = ic.ftpUsePassive;
                            ftpRequest.KeepAlive = true;
                            ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                            ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                            ftpStream = ftpResponse.GetResponseStream();
                            byte[] byteBuffer = new byte[bufferSize];
                            int bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
                            try
                            {
                                while (bytesRead > 0)
                                {
                                    stream.Write(byteBuffer, 0, bytesRead);
                                    bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());
                            }
                            loadedImage = new Bitmap(stream);
                            ftpStream.Close();
                            ftpResponse.Close();
                            ftpRequest = null;
                        }
                        catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                        grfDay6Img.Cols[colDay2ImgPic].ImageAndText = true;
                        if (loadedImage != null)
                        {
                            int originalWidth = loadedImage.Width;
                            int newWidth = 180;
                            resizedImage = loadedImage.GetThumbnailImage(newWidth, (newWidth * loadedImage.Height) / originalWidth, null, IntPtr.Zero);
                            Column col = grfDay6Img.Cols[colDay2ImgPic];
                            col.DataType = typeof(Image);
                            row1[colDay2ImgPic] = resizedImage;
                            flagDay6Img = true;
                        }

                    }).Start();
                }
            }
            grfDay6Img.Cols[colDay2ImgId].Visible = false;
            grfDay6Img.Cols[colDay2PathPic].Visible = false;
            //grfDay2Img.Cols[colDay2ImgPic].AllowEditing = false;
            grfDay6Img.AutoSizeCols();
            grfDay6Img.AutoSizeRows();
            theme1.SetTheme(grfDay6Img, ic.iniC.themeFET);
            grfDay6Img.Refresh();
        }

        private void initGrfDay6Img()
        {
            grfDay6Img = new C1FlexGrid();
            grfDay6Img.Font = fEdit;
            grfDay6Img.Dock = System.Windows.Forms.DockStyle.Fill;
            grfDay6Img.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            grfDay6Img.DoubleClick += GrfDay6Img_DoubleClick;
            //grfDay2.ChangeEdit += GrfDay2_ChangeEdit;
            //grfDay2.CellChanged += GrfDay2_CellChanged;
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("&Upload image", new EventHandler(ContextMenu_grfday6_upload));
            menuGw.MenuItems.Add("&Save description", new EventHandler(ContextMenu_grfday6_save));
            menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_grfday6_Cancel));
            grfDay6Img.ContextMenu = menuGw;
            pnGrf6Img.Controls.Add(grfDay6Img);

            theme1.SetTheme(grfDay6Img, ic.iniC.themeFET);
        }
        private void ContextMenu_grfday6_upload(object sender, System.EventArgs e)
        {
            String pathfile1 = grfDay6Img[grfDay6Img.Row, colDay2PathPic] != null ? grfDay6Img[grfDay6Img.Row, colDay2PathPic].ToString() : "";
            if (pathfile1.Length > 0)
            {
                MessageBox.Show("มีรูปภาพ อยู่แล้ว กรุณา ยกเลิก ก่อน Upload รูปใหม่ ", "");
                return;
            }

            if (MessageBox.Show("ต้องการ Upload image to server ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Images (*.BMP;*.JPG;*.Jepg;*.Png;*.GIF)|*.BMP;*.JPG;*.Jepg;*.Png;*.GIF|Pdf Files|*.pdf|All files (*.*)|*.*";
                ofd.Multiselect = false;
                ofd.Title = "My Image Browser";
                DialogResult dr = ofd.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    String id = grfDay6Img[grfDay6Img.Row, colDay2ImgId].ToString();
                    String pathfile = ofd.FileName;
                    String desc = grfDay6Img[grfDay6Img.Row, colDay2ImgDesc0] != null ? grfDay6Img[grfDay6Img.Row, colDay2ImgDesc0].ToString() : "";
                    String no = grfDay6Img[grfDay6Img.Row, colDay2ImgNun] != null ? grfDay6Img[grfDay6Img.Row, colDay2ImgNun].ToString() : "";
                    if (no.Length > 0)
                    {
                        ic.cStf.staff_id = "";
                        FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                        frm.ShowDialog(this);
                        if (!ic.cStf.staff_id.Equals(""))
                        {
                            String filename = "", re = "";
                            String[] ext = pathfile.Split('.');
                            //var name = Path.GetFileNameWithoutExtension(fileFullName); // Get the name only
                            var extension = Path.GetExtension(pathfile);
                            //if (ext.Length > 1)
                            //{
                            filename = txtFetCode.Text + "_day2_" + no + extension;
                            re = ic.ivfDB.opuEmDevDB.updatePathPic(id, no, ic.iniC.folderFTP + "/" + txtFetCode.Text + "/" + filename, desc, ic.cStf.staff_id);
                            long chk = 0;
                            if (long.TryParse(re, out chk))
                            {
                                ic.savePicOPUtoServer(txtFetCode.Text, filename, pathfile);
                                grfDay6Img.Rows[grfDay6Img.Row].StyleNew.BackColor = color;
                                setGrfDay6Img();
                            }
                            //}
                        }
                    }
                }
            }
        }
        private void ContextMenu_grfday6_save(object sender, System.EventArgs e)
        {
            String id = grfDay6Img[grfDay6Img.Row, colDay2ImgId].ToString();
            String desc = grfDay6Img[grfDay6Img.Row, colDay2ImgDesc0].ToString();
            String num = grfDay6Img[grfDay6Img.Row, colDay2ImgNun].ToString();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล \n Number " + num + " description " + desc, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                ic.cStf.staff_id = "";
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    String re = ic.ivfDB.opuEmDevDB.updateNumDesc(id, num, desc, ic.user.staff_id);
                }
            }
        }
        private void ContextMenu_grfday6_Cancel(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("ต้องการ ยกเลิก ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                String id = grfDay6Img[grfDay6Img.Row, colDay2ImgId].ToString();
                ic.cStf.staff_id = "";
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    String pathfile = grfDay6Img[grfDay6Img.Row, colDay2PathPic].ToString();
                    String re = ic.ivfDB.opuEmDevDB.updatePathPic(id, "", "", "", ic.user.staff_id);
                    ic.delPicOPUtoServer(txtFetCode.Text, pathfile);
                }
            }
        }
        private void GrfDay6Img_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfDay6Img.Row < 0) return;
            if (grfDay6Img.Col == colDay2ImgPic)
            {
                //MessageBox.Show("a "+grfImg[grfImg.Row, colImg].ToString(), "");
                int row = 0;
                //int.TryParse(grfImg[grfImg.Row, colImg].ToString(), out row);
                int.TryParse(grfDay6Img.Row.ToString(), out row);
                //row *= 4;
                FrmShowImage frm = new FrmShowImage(ic, grfDay6Img[row, colDay2ID] != null ? grfDay6Img[row, colDay2ID].ToString() : "", "", grfDay6Img[row, colDay2PathPic].ToString(), FrmShowImage.statusModule.LabOPU);
                frm.ShowDialog(this);
            }
        }
        private void initGrfDay2()
        {
            grfDay2 = new C1FlexGrid();
            grfDay2.Font = fEdit;
            grfDay2.Dock = System.Windows.Forms.DockStyle.Fill;
            grfDay2.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            grfDay2.AfterRowColChange += GrfDay2_AfterRowColChange;
            grfDay2.ChangeEdit += GrfDay2_ChangeEdit;
            grfDay2.CellChanged += GrfDay2_CellChanged;
            grfDay2.KeyDown += GrfDay2_KeyDown;
            grfDay2.GotFocus += GrfDay2_GotFocus;
            //ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&Upload image", new EventHandler(ContextMenu_grfday2_upload));
            //menuGw.MenuItems.Add("&Save description", new EventHandler(ContextMenu_grfday2_save));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_grfday2_Cancel));
            //grfDay2.ContextMenu = menuGw;
            pn2Grf.Controls.Add(grfDay2);

            theme1.SetTheme(grfDay2, ic.iniC.themeFET);
        }
        private void GrfDay2_GotFocus(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            grf2Focus = true;
            grf3Focus = false;
            grf5Focus = false;
            grf6Focus = false;
        }

        private void GrfDay2_KeyDown(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
            {
                grf2Focus = true;
                //String txt = "";
                //txt = grfDay2[grfDay2.Row, grfDay2.Col].ToString();
                //Clipboard.SetText(txt);
            }
            else if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
            {
                CellRange cr = grfDay2.Selection;
                cr.Data = Clipboard.GetText();
                CellRange cr1 = grfDay2.GetCellRange(cr.TopRow, colDay2Edit, cr.BottomRow, colDay2Edit);
                cr1.Data = "1";
                CellRange cr2 = grfDay2.GetCellRange(cr.TopRow, colDay2Num, cr.BottomRow, colDay2Desc2);
                cr2.StyleNew.BackColor = color;
            }
        }
        private void GrfDay2_ChangeEdit(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfDay2.Row == null) return;
            if (grfDay2.Row < 0) return;
            grfDay2[grfDay2.Row, colDay2Edit] = "1";
            grf2Focus = true;
            grf3Focus = false;
            grf5Focus = false;
            grf6Focus = false;
            grfDay2.Rows[grfDay2.Row].StyleNew.BackColor = color;
            if (grfDay2.Col == colDay2Desc)
            {
                if ((grfDay2.Row + 1) == grfDay2.Rows.Count)
                    grfDay2.Rows.Add();
            }
        }

        private void GrfDay2_CellChanged(object sender, RowColEventArgs e)
        {
            //throw new NotImplementedException();
            if (grfDay2.Row == null) return;
            if (grfDay2.Row < 0) return;

        }

        private void GrfDay2_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (grfDay2.Row == null) return;
            if (grfDay2.Row < 0) return;
            //if (grfDay2.Row == grfDay2.Rows.Count)
            //    grfDay2.Rows.Add();
        }

        private void initGrfDay6()
        {
            grfDay6 = new C1FlexGrid();
            grfDay6.Font = fEdit;
            grfDay6.Dock = System.Windows.Forms.DockStyle.Fill;
            grfDay6.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            grfDay6.ChangeEdit += GrfDay6_ChangeEdit;
            grfDay6.KeyDown += GrfDay6_KeyDown;
            grfDay6.GotFocus += GrfDay6_GotFocus;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfDay6.ContextMenu = menuGw;
            pn6Grf.Controls.Add(grfDay6);

            theme1.SetTheme(grfDay6, ic.iniC.themeFET);
        }
        private void GrfDay6_GotFocus(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            grf2Focus = false;
            grf3Focus = false;
            grf5Focus = false;
            grf6Focus = true;
        }

        private void GrfDay6_KeyDown(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
            {
                //String txt = "";
                //txt = grfDay6[grfDay6.Row, grfDay6.Col].ToString();
                //Clipboard.SetText(txt);
            }
            else if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
            {
                CellRange cr = grfDay6.Selection;
                cr.Data = Clipboard.GetText();
                CellRange cr1 = grfDay6.GetCellRange(cr.TopRow, colDay6Edit, cr.BottomRow, colDay6Edit);
                cr1.Data = "1";
                CellRange cr2 = grfDay6.GetCellRange(cr.TopRow, colDay6Num, cr.BottomRow, colDay6Desc2);
                cr2.StyleNew.BackColor = color;
            }
        }
        private void GrfDay6_ChangeEdit(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfDay6.Row == null) return;
            if (grfDay6.Row < 0) return;
            grfDay6[grfDay6.Row, colDay6Edit] = "1";
            grf2Focus = false;
            grf3Focus = false;
            grf5Focus = false;
            grf6Focus = true;
            grfDay6.Rows[grfDay6.Row].StyleNew.BackColor = color;
            if (grfDay6.Col == colDay6Desc)
            {
                if ((grfDay6.Row + 1) == grfDay6.Rows.Count)
                    grfDay6.Rows.Add();
            }
        }

        private void initGrfDay3()
        {
            grfDay3 = new C1FlexGrid();
            grfDay3.Font = fEdit;
            grfDay3.Dock = System.Windows.Forms.DockStyle.Fill;
            grfDay3.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            grfDay3.ChangeEdit += GrfDay3_ChangeEdit;
            grfDay3.KeyDown += GrfDay3_KeyDown;
            grfDay3.GotFocus += GrfDay3_GotFocus;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfDay3.ContextMenu = menuGw;
            pn3Grf.Controls.Add(grfDay3);

            theme1.SetTheme(grfDay3, ic.iniC.themeFET);
        }
        private void GrfDay3_GotFocus(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            grf2Focus = false;
            grf3Focus = true;
            grf5Focus = false;
            grf6Focus = false;
        }

        private void GrfDay3_KeyDown(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
            {
                //String txt = "";
                //txt = grfDay3[grfDay3.Row, grfDay3.Col].ToString();
                //Clipboard.SetText(txt);
            }
            else if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
            {
                CellRange cr = grfDay3.Selection;
                cr.Data = Clipboard.GetText();
                CellRange cr1 = grfDay3.GetCellRange(cr.TopRow, colDay3Edit, cr.BottomRow, colDay3Edit);
                cr1.Data = "1";
                CellRange cr2 = grfDay3.GetCellRange(cr.TopRow, colDay3Num, cr.BottomRow, colDay3Desc2);
                cr2.StyleNew.BackColor = color;
            }
        }
        private void GrfDay3_ChangeEdit(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfDay3.Row == null) return;
            if (grfDay3.Row < 0) return;
            grfDay3[grfDay3.Row, colDay3Edit] = "1";
            grf2Focus = false;
            grf3Focus = true;
            grf5Focus = false;
            grf6Focus = false;
            grfDay3.Rows[grfDay3.Row].StyleNew.BackColor = color;
            if (grfDay3.Col == colDay3Desc)
            {
                if ((grfDay3.Row + 1) == grfDay3.Rows.Count)
                    grfDay3.Rows.Add();
            }
        }

        private void initGrfDay5()
        {
            grfDay5 = new C1FlexGrid();
            grfDay5.Font = fEdit;
            grfDay5.Dock = System.Windows.Forms.DockStyle.Fill;
            grfDay5.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            grfDay5.ChangeEdit += GrfDay5_ChangeEdit;
            grfDay5.KeyDown += GrfDay5_KeyDown;
            grfDay5.GotFocus += GrfDay5_GotFocus;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfDay5.ContextMenu = menuGw;
            pn5Grf.Controls.Add(grfDay5);

            theme1.SetTheme(grfDay5, ic.iniC.themeFET);
            //theme1.SetTheme(grfDay6, "Office2016DarkGray");
        }
        private void GrfDay5_GotFocus(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            grf2Focus = false;
            grf3Focus = false;
            grf5Focus = true;
            grf6Focus = false;
        }

        private void GrfDay5_KeyDown(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
            {
                //String txt = "";
                //txt = grfDay5[grfDay5.Row, grfDay5.Col].ToString();
                //Clipboard.SetText(txt);
            }
            else if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
            {
                CellRange cr = grfDay5.Selection;
                cr.Data = Clipboard.GetText();
                CellRange cr1 = grfDay5.GetCellRange(cr.TopRow, colDay5Edit, cr.BottomRow, colDay5Edit);
                cr1.Data = "1";
                CellRange cr2 = grfDay5.GetCellRange(cr.TopRow, colDay5Num, cr.BottomRow, colDay5Desc2);
                cr2.StyleNew.BackColor = color;
            }
        }
        private void GrfDay5_ChangeEdit(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfDay5.Row == null) return;
            if (grfDay5.Row < 0) return;
            grfDay5[grfDay5.Row, colDay5Edit] = "1";
            grf2Focus = false;
            grf3Focus = false;
            grf5Focus = true;
            grf6Focus = false;
            grfDay5.Rows[grfDay5.Row].StyleNew.BackColor = color;
            if (grfDay5.Col == colDay5Desc)
            {
                if ((grfDay5.Row + 1) == grfDay5.Rows.Count)
                    grfDay5.Rows.Add();
            }
        }
        private void FrmLabFetAdd1_Load(object sender, EventArgs e)
        {
            if (ic.iniC.statusCheckDonor.Equals("1"))
            {
                label73.Hide();
                label72.Hide();
                //label88.Hide();
                txtHnDonor.Hide();
                txtNameDonor.Hide();
                //txtDobDonor.Hide();
                btnDonorSearch.Hide();
            }
        }
    }
}
