﻿using C1.C1Excel;
using C1.Win.C1Command;
using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1SuperTooltip;
using clinic_ivf.control;
using clinic_ivf.objdb;
using clinic_ivf.object1;
using clinic_ivf.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.gui
{
    /*
     * 62-06-20     003     หน้าจอทำนัด มีหลายหน้าจอ และมีการเรียกใช้ หลายที่
     * 
     * 63-10-23     0021    ให้เริ่ม HN ใหม่ แต่ให้ใช้ข้อมูลเก่า
     */
    public partial class FrmAppointmentView : Form
    {
        IvfControl ic;
        MainMenu menu;

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;

        //int colID = 1, colpttId = 2, colVsTime = 3, colPttHn = 4, colVsCode = 5, colVsPttName = 6, colVsDoctor = 7, colVsSperm = 8, colVsDay6 = 9, colVsDay7 = 10, colVsDay8 = 11, colVsDay9=12, colVsDay10=13, colVsDay11=14;
        //int colVsTVS = 15, colVsPesa = 16, colVsSpermF = 17, colVsSpermSA=18, colVsOPU = 19, colVsET = 20, colVsFET=21, colVsHCG = 22, colVsSpermOPU = 23, colVsTrans = 24, colVsANC = 25, colVsAnes = 26;
        //int colVSE2 = 27, colVSLh = 28, colVSPrl = 29, colVSFsh = 30, colVsAgent=31, colVsRemark = 32, colVsStatus=33, colConn=34, colStfCreate=35,colStfModi=36, colStfSave=37;

        //int colID = 1, colpttId = 2, colVsTime = 3, colPttHn = 4, colVsCode = 5, colVsPttName = 6, colVsDoctor = 7, colVsSperm = 8, colVsDay6 = 9, colVsDay7 = 10, colVsDay8 = 11, colVsDay9 = 12, colVsDay10 = 13, colVsDay11 = 14;
        //int colVSE2 = 15, colVSLh = 16, colVsTVS = 17, colVsPesa = 18, colVsSpermF = 19, colVsSpermSA = 20, colVsSpermOPU = 21, colVsOPU = 22, colVsET = 23, colVsFET = 24, colVsHCG = 25, colVsTrans = 26, colVsANC = 27, colVsAnes = 28;
        //int colVSPrl = 29, colVSFsh = 30, colVsAgent = 31, colVsRemark = 32, colVsStatus = 33, colConn = 34, colStfCreate = 35, colStfModi = 36, colStfSave = 37;

        int colID = 1, colpttId = 2, colVsTime = 3, colPttHn = 4, colVsCode = 5, colVsPttName = 6, colVsDoctor = 7, colVsSperm = 8, colVsDay6 = 9, colVsDay7 = 10, colVsDay8 = 11, colVsDay9 = 12, colVsDay10 = 13, colVsDay11 = 14;
        int colVsTVS = 15, colVsPesa = 16, colVsSpermF = 17, colVsSpermSA = 18, colVsSpermOPU = 19, colVsOPU = 20, colVsET = 21, colVsFET = 22, colVsHCG = 23, colVsTrans = 24, colVsANC = 25, colVsAnes = 26;
        int colVSE2 = 27, colVSLh = 28, colVSPrl = 29, colVSFsh = 30, colVsAgent = 31, colVsRemark = 32, colVsStatus = 33, colConn = 34, colStfCreate = 35, colStfModi = 36, colStfSave = 37, colConsult=38;

        int colpApmPttId = 1,colpApmPttName = 2;

        C1FlexGrid grfPtt;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        Image imgCorr, imgTran;
        public FrmAppointmentView(IvfControl ic, MainMenu m)
        {
            InitializeComponent();
            this.ic = ic;
            this.menu = m;
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
            bg = txtHn.BackColor;
            fc = txtHn.ForeColor;
            ff = txtHn.Font;

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            
            imgCorr = Resources.red_checkmark_png_16;
            imgTran = Resources.red_checkmark_png_51;
            txtDateStart.Value = DateTime.Now.ToString("yyyy-MM-dd");
            txtDateEnd.Value = DateTime.Now.ToString("yyyy-MM-dd");
            ic.ivfDB.dtrOldDB.setCboDoctor(cboDoctor,"");

            btnSearch.Click += BtnSearch_Click;
            txtSearch.KeyUp += TxtSearch_KeyUp;
            btnNew.Click += BtnNew_Click;
            tC.DoubleClick += TC_DoubleClick;
            btnPrnDonor.Click += BtnPrnDonor_Click;
            btnPrnPtt.Click += BtnPrnPtt_Click;
            btnPrint.Click += BtnPrint_Click;
            btnExcel.Click += BtnExcel_Click;
            //txtDateStart.ValueChanged += TxtDateStart_ValueChanged;
            //txtDateStart.

            //initTcDtr1();
            //initTcDtr();
            initGrfPtt();
            //setGrfPtt();
            setGrf();
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.DefaultExt = "xls";
            dlg.Filter = "Excel |*.xls";
            dlg.InitialDirectory = ic.iniC.pathSaveExcelAppointment;
            dlg.FileName = "*.xls";
            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            // clear book
            C1XLBook _book = new C1XLBook();
            //_book.Clear();
            //_book.Sheets.Clear();

            // copy grids to book sheets
            //foreach (TabPage pg in _tab.TabPages)
            //{
            //    C1FlexGrid grid = pg.Controls[0] as C1FlexGrid;
            XLSheet sheet = _book.Sheets.Add("Appointment");
            ic.SaveSheet(grfPtt, sheet, _book, false);
            //}

            // save selected sheet index
            _book.Sheets.SelectedIndex = 0;

            // save the book
            _book.Save(dlg.FileName);
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

        }
        private void BtnPrnPtt_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmReport frm = new FrmReport(ic);
            DataTable dt = new DataTable();
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
            dateend1 = datestart1;
            
            dt = ic.ivfDB.pApmOldDB.selectByDateDtr(datestart1, dateend1, cboDoctor.Text);
            
            frm.setAppoitmentDailyReport(dt);
            frm.ShowDialog(this);
        }

        private void BtnPrnDonor_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmReport frm = new FrmReport(ic);
            DataTable dt = new DataTable();
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
            dateend1 = datestart1;
            
            dt = ic.ivfDB.pApmDB.selectByDay(datestart1, dateend1);
            
                
            frm.setAppoitmentDailyReport(dt);
            frm.ShowDialog(this);
        }

        private void TC_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            try
            {
                C1DockingTab tabpage = (C1DockingTab)sender;
                if (tC.SelectedTab.Text.Equals(tabpage.Text))
                {
                    using (Form form = new Form())
                    {
                        form.Text = "Copy ...";
                        TextBox txt = new TextBox();
                        txt.Dock = DockStyle.Fill;
                        txt.Multiline = true;
                        form.Controls.Add(txt);
                        form.Size = new Size(600, 600);
                        String txt1 = "";
                        Boolean chk = false;
                        foreach(Control con in tabpage.Controls)
                        {
                            if (con is C1DockingTabPage)
                            {
                                if (tabpage.Text.Equals("ทั้งหมด"))
                                {
                                    foreach (Control con1 in con.Controls)
                                    {
                                        if (con1 is Panel)
                                        {
                                            //C1FlexGrid aa = (C1FlexGrid)con1;
                                            foreach (Control con2 in con1.Controls)
                                            {
                                                if (con2 is C1FlexGrid)
                                                {
                                                    C1FlexGrid aa = (C1FlexGrid)con2;
                                                    foreach (Row row in aa.Rows)
                                                    {
                                                        txt1 += row[colpApmPttName].ToString() + Environment.NewLine;
                                                    }
                                                    chk = true;
                                                    break;
                                                }
                                            }
                                        }
                                        //txt1 += row[colpApmPttName].ToString() + Environment.NewLine;
                                    }
                                }
                                else
                                {
                                    foreach (Control con1 in con.Controls)
                                    {
                                        txt1 = "";
                                        if (con1 is C1FlexGrid)
                                        {
                                            C1FlexGrid aa = (C1FlexGrid)con1;
                                            //txt1 = aa.Name;
                                            String id = "";
                                            id = ic.ivfDB.dtrOldDB.getlDtrIDByName(tabpage.Text);
                                            if (id.Equals(aa.Name.Replace("grf","")))
                                            {
                                                foreach (Row row in aa.Rows)
                                                {
                                                    txt1 += row[colpApmPttName].ToString() + Environment.NewLine;
                                                }
                                                chk = true;
                                            }
                                        }
                                    }
                                }
                            }
                            if (chk) break;
                        }
                        txt.Text = tabpage.Text+"["+ txtDateStart .Text+ "]"+Environment.NewLine+txt1;
                        // form.Controls.Add(...);
                        form.StartPosition = FormStartPosition.CenterScreen;
                        form.ShowDialog();
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void TxtDateStart_ValueChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (ic.iniC.statusAppDonor.Equals(""))
            {
                //FrmAppointmentDonorAdd frm = new FrmAppointmentDonorAdd(ic, "", "", "");
                FrmAppointmentAdd frm = new FrmAppointmentAdd(ic, "", "", "", "");
                frm.ShowDialog(this);
            }
            else
            {
                FrmAppointmentAdd frm = new FrmAppointmentAdd(ic, "", "", "","");
                frm.ShowDialog(this);
            }

        }

        private void TxtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();

        }
        private void setSearch()
        {
            Cursor curOld = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            gb.Visible = false;
            tC.Visible = false;
            try
            {
                setGrf();
            }
            catch(Exception ex)
            {

            }
            gb.Visible = true;
            tC.Visible = true;
            this.Cursor = curOld;
        }
        private void setGrf()
        {
            DataTable dtApmOld = new DataTable();
            DataTable dtApm = new DataTable();
            ConnectDB con = new ConnectDB(ic.iniC);
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
            dateend1 = datestart1;

            if (ic.iniC.statusAppDonor.Equals("1"))
            {
                dtApm = ic.ivfDB.pApmDB.selectByDay(datestart1, dateend1);
                dtApmOld = ic.ivfDB.pApmDB.selectByDay(con.connEx, datestart1, dateend1);
                //dtApmOld = ic.ivfDB.pApmOldDB.selectByDateDtr(con.connEx, datestart1, dateend1, cboDoctor.Text);
            }
            else
            {
                dtApm = ic.ivfDB.pApmDB.selectByDay(datestart1, dateend1);
                //dtApmOld = ic.ivfDB.pApmDB.selectByDay(con.connEx, datestart1, dateend1);           //-0021   ไม่มี โปรแกรม donor
                //dtApmOld = ic.ivfDB.pApmOldDB.selectByDateDtr(datestart1, dateend1, cboDoctor.Text);
            }

            setGrfPtt(con, dtApmOld, dtApm);
            initTcDtr1(dtApmOld, dtApm);
            
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setSearch();
        }
        private void initTcDtr1(DataTable dtAll, DataTable dtDAll)
        {
            String datestart1 = "", dateend1 = "";
            DateTime datestart, dateend;
            if (DateTime.TryParse(txtDateStart.Text, out datestart))
            {
                datestart1 = datestart.ToString("yyyy-MM-dd");
            }
            else
            {
                datestart1 = ic.datetoDB(txtDateStart.Text);
            }
            dateend1 = datestart1;
            //foreach(C1DockingTabPage tab in tC.TabPages)
            //{
            //    if (!tab.Name.Equals("tabAll"))
            //    {
            //        tC.TabPages.Remove(tab);
            //    }
            //}
            int cnt = 0;
            cnt = tC.TabCount;
            for (int i = 0; i < cnt; i++)
            {
                C1DockingTabPage tab;
                tC.SelectedIndex = tC.TabCount;
                tab = tC.SelectedTab;
                if (!tab.Name.Equals("tabAll"))
                {
                    tC.TabPages.Remove(tab);
                }
            }
            foreach(Control aaa in pnAll.Controls)
            {
                if(aaa is C1FlexGrid)
                {
                    pnAll.Controls.Remove(aaa);
                }
            }
            DataTable dt = new DataTable();
            DataTable dtD = new DataTable();
            C1TextBox txt = new C1TextBox();
            C1FlexGrid grfAll = new C1FlexGrid();
            grfAll = new C1FlexGrid();
            grfAll.Font = fEdit;
            grfAll.Dock = DockStyle.Fill;
            grfAll.Rows.Count = 1;
            grfAll.Cols.Count = 3;
            grfAll.Cols[colpApmPttName].Editor = txt;
            grfAll.Cols[colpApmPttName].Width = 850;
            grfAll.Cols[colpApmPttName].Caption = "Description";
            grfAll.Name = "grfAll";
            grfAll.Cols[colpApmPttId].Visible = false;
            grfAll.AllowSorting = AllowSortingEnum.None;
            pnAll.Controls.Add(grfAll);
            foreach (DataRow row1 in dtAll.Rows)
            {
                String appn = "";
                appn = ic.ivfDB.genAppointmentRemarkPtt1(row1);
                Row rowAll = grfAll.Rows.Add();
                rowAll[colpApmPttName] = appn;
                rowAll[0] = (grfAll.Rows.Count - 1);
            }
            foreach (DataRow row1 in dtDAll.Rows)
            {
                String appn = "";
                //appn = ic.ivfDB.genAppointmentRemarkPttDonor(row1);           // -003
                appn = ic.ivfDB.genAppointmentRemarkPtt1(row1);         //      +003
                Row rowAll = grfAll.Rows.Add();
                rowAll[colpApmPttName] = appn;
                rowAll[0] = (grfAll.Rows.Count - 1);
            }

            if (ic.iniC.statusAppDonor.Equals("1"))
            {
                dtD = ic.ivfDB.pApmDB.selectByDayGroupByDtr(datestart1, dateend1);
                dt = ic.ivfDB.pApmOldDB.selectByDateDtrGroupByDtr(ic.conn.connEx, datestart1, dateend1);
            }
            else
            {
                dtD = ic.ivfDB.pApmDB.selectByDayGroupByDtr(ic.conn.connEx,datestart1, dateend1);
                dt = ic.ivfDB.pApmOldDB.selectByDateDtrGroupByDtr(datestart1, dateend1);
            }
            foreach (DataRow row in dt.Rows)
            {
                String name = row["dtr_name"].ToString();
                String id = row["patient_appointment_doctor"].ToString();
                Boolean chk = false;
                
                foreach (DataRow rowD in dtD.Rows)
                {
                    String nameD = rowD["dtr_name"].ToString();
                    String idD = rowD["patient_appointment_doctor"].ToString();
                    if (!nameD.ToLower().Equals(name.ToLower()))
                    {
                        chk = true;
                    }
                    else
                    {
                        chk = false;
                        break;
                    }
                }
                if (chk)
                {
                    //DataRow rowN = new DataRow();
                    DataRow rowN = dtD.Rows.Add();
                    rowN["dtr_name"] = name;
                    row["patient_appointment_doctor"] = id.Equals("") ? "0" : id;
                }
            }

            foreach (DataRow row in dtD.Rows)
            {
                C1DockingTabPage tabpage = new C1DockingTabPage();
                C1FlexGrid grf = new C1FlexGrid();
                grf = new C1FlexGrid();
                grf.Font = fEdit;
                grf.Dock = DockStyle.Fill;
                grf.Rows.Count = 1;
                grf.Cols.Count = 3;
                grf.Name = "grf"+row["patient_appointment_doctor"].ToString();
                grf.AllowSorting = AllowSortingEnum.None;
                grf.Cols[colpApmPttName].Editor = txt;
                grf.Cols[colpApmPttName].Width = 520;
                grf.Cols[colpApmPttName].Caption = "Description";
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                String dtrid = "";
                dtrid = row["patient_appointment_doctor"].ToString();
                if (ic.iniC.statusAppDonor.Equals("1"))
                {
                    dt1 = ic.ivfDB.pApmDB.selectByDayDtrId(ic.conn.conn, datestart1, dateend1, dtrid);
                    //dt2 = ic.ivfDB.pApmOldDB.selectByDateDtr(ic.conn.connEx, datestart1, dateend1, dtrid);        //   -   แก้ให้เหลือแต่ t_appointment   62-08-22
                    dt2 = ic.ivfDB.pApmDB.selectByDayDtrId(ic.conn.connEx, datestart1, dateend1, dtrid);        //   +   แก้ให้เหลือแต่ t_appointment   62-08-22
                }
                else
                {

                }
                //int i = 1;
                foreach (DataRow row1 in dt2.Rows)
                {
                    String appn = "";
                    //String hormo = "", tvs = "", opu = "", fet = "", beta = "", other = "", appn = "";
                    //hormo = row1[ic.ivfDB.appnOldDB.appnOld.HormoneTest].ToString().Equals("1") ? "Hormone Test " : "";
                    //tvs = row1[ic.ivfDB.appnOldDB.appnOld.TVS].ToString().Equals("1") ? "TVS " : "";
                    //opu = row1[ic.ivfDB.appnOldDB.appnOld.OPU].ToString().Equals("1") ? row1[ic.ivfDB.appnOldDB.appnOld.OPUTime] != null ? "OPU ["+ row1[ic.ivfDB.appnOldDB.appnOld.OPUTime].ToString() +"]": "OPU " + row1[ic.ivfDB.appnOldDB.appnOld.OPUTime].ToString() : "" ;
                    //beta = row1[ic.ivfDB.appnOldDB.appnOld.BetaHCG].ToString().Equals("1") ? "Beta HCG " : "";
                    //fet = row1[ic.ivfDB.appnOldDB.appnOld.ET_FET].ToString().Equals("1") ? row1[ic.ivfDB.appnOldDB.appnOld.ET_FET_Time] != null ? "ET/FET [" + row1[ic.ivfDB.appnOldDB.appnOld.ET_FET_Time].ToString() + "]": "ET/FET" : "";
                    //other = row1[ic.ivfDB.appnOldDB.appnOld.Other].ToString().Equals("1") ? row1[ic.ivfDB.appnOldDB.appnOld.OtherRemark] != null ? "Other " + row1[ic.ivfDB.appnOldDB.appnOld.OtherRemark].ToString() : "Other " : "";
                    //appn = row1["aaa"].ToString() + " " + hormo + " " + tvs + " " + opu + " " + beta + " " + fet + " " + other;
                    //appn = ic.ivfDB.genAppointmentRemarkPtt(row1);        //   -   แก้ให้เหลือแต่ t_appointment   62-08-22
                    appn = ic.ivfDB.genAppointmentRemarkPtt1(row1);        //   +   แก้ให้เหลือแต่ t_appointment   62-08-22
                    //Row rowAll = grfAll.Rows.Add();
                    //rowAll[colpApmPttName] = appn+ " " + row1["PatientName"].ToString();
                    //rowAll[0] = (grfAll.Rows.Count-1);

                    Row rowdtr = grf.Rows.Add();
                    rowdtr[colpApmPttName] = appn;
                    rowdtr[0] = (grf.Rows.Count-1);
                    //i++;
                }
                //i = 1;
                foreach (DataRow row1 in dt1.Rows)
                {
                    String appn = "";
                    //String e2="", lh="", prl="", fsh = "", appn = "", opu="";
                    //e2 = row1[ic.ivfDB.pApmDB.pApm.e2].ToString().Equals("1") ? "E2 " : "";
                    //lh = row1[ic.ivfDB.pApmDB.pApm.lh].ToString().Equals("1") ? "LH " : "";
                    //prl = row1[ic.ivfDB.pApmDB.pApm.prl].ToString().Equals("1") ? "PRL " : "";
                    //fsh = row1[ic.ivfDB.pApmDB.pApm.fsh].ToString().Equals("1") ? "FSH " : "";
                    //opu = row1[ic.ivfDB.pApmDB.pApm.opu].ToString().Equals("1") ? "OPU " + row1[ic.ivfDB.pApmDB.pApm.doctor_anes] != null ? row1[ic.ivfDB.pApmDB.pApm.doctor_anes].ToString() : "" : "";
                    //appn = row1[ic.ivfDB.pApmDB.pApm.patient_appointment_time].ToString()+" "+e2 + " " + lh + " " + prl + " " + fsh;
                    //appn = ic.ivfDB.genAppointmentRemarkPttDonor(row1);//    -  แก้ให้เหลือแต่ t_appointment   62-08-22
                    appn = ic.ivfDB.genAppointmentRemarkPtt1(row1);//    +  แก้ให้เหลือแต่ t_appointment   62-08-22
                    Row rowdtr = grf.Rows.Add();
                    rowdtr[colpApmPttName] = appn;
                    rowdtr[0] = (grf.Rows.Count-1);

                    //Row rowAll = grfAll.Rows.Add();
                    //rowAll[colpApmPttName] = appn + " " + row1["PatientName"].ToString();
                    //rowAll[0] = (grfAll.Rows.Count-1);
                    //i++;
                }
                grf.Cols[colpApmPttId].Visible = false;
                tabpage.Controls.Add(grf);
                String dtrName = row["dtr_name"].ToString();
                if (dtrName.Equals(""))
                {
                    dtrName = "Dr.No Name";
                }
                tabpage.Text = dtrName;
                //tabpage.Name
                theme1.SetTheme(grf, "Office2010Blue");
                //tab.Name
                tC.TabPages.Add(tabpage);
            }
        }
        
        private void initTcDtr()
        {
            String datestart1 = "", dateend1 = "";
            DateTime datestart, dateend;
            if (DateTime.TryParse(txtDateStart.Text, out datestart))
            {
                datestart1 = datestart.ToString("yyyy-MM-dd");
            }
            else
            {
                datestart1 = ic.datetoDB(txtDateStart.Text);
            }
            dateend1 = datestart1;
            DataTable dt = new DataTable();
            DataTable dtD = new DataTable();            
            
            if (ic.iniC.statusAppDonor.Equals("1"))
            {
                dtD = ic.ivfDB.pApmDB.selectByDayGroupByDtr(datestart1, dateend1);
            }
            else
            {

            }
            C1DockingTab tcDtr = new C1DockingTab();
            tcDtr.Font = fEdit;
            tcDtr.Dock = DockStyle.Fill;            
            theme1.SetTheme(tcDtr, "Office2013Red");
            Int32 cnt = 0;
            cnt = dtD.Rows.Count;
            if (cnt > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    //if (i > (cnt-1)) continue;
                    C1DockingTabPage tabpage = new C1DockingTabPage();
                    tabpage.Name = "tab" + i;
                    //tabpage.Text = "dtr_name";
                    tabpage.Text = dtD.Rows[i]["dtr_name"].ToString();
                    //theme1.SetTheme(tab, "Office2016Colorful");
                    tcDtr.Controls.Add(tabpage);
                    //tcDtr.TabPages.Add(dtD.Rows[i]["dtr_name"].ToString());
                    C1FlexGrid grf;
                    grf = new C1FlexGrid();
                    grf.Font = fEdit;
                    grf.Dock = DockStyle.Fill;
                    ////grf.Location = new Point(0, 0);
                    //grf.Name = "grf" + i;
                    tabpage.Controls.Add(grf);
                    //theme1.SetTheme(grf, "Office2010Blue");
                    //tcDtr.Controls.Add(new C1DockingTabPage());
                }
            }            
            pnDtr.Controls.Add(tcDtr);
        }
        private void initGrfPtt()
        {
            grfPtt = new C1FlexGrid();
            grfPtt.Font = fEdit;
            grfPtt.Name = "grfPff";
            grfPtt.Dock = System.Windows.Forms.DockStyle.Fill;
            grfPtt.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);
            
            grfPtt.AfterRowColChange += GrfPtt_AfterRowColChange;
            grfPtt.DoubleClick += GrfPtt_DoubleClick;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfPtt.ContextMenu = menuGw;
            pmpAmp.Controls.Add(grfPtt);

            theme1.SetTheme(grfPtt, "Office2010Blue");

        }

        private void GrfPtt_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

            if (grfPtt.Row <= 0) return;
            if (grfPtt.Col <= 0) return;
            
            if (grfPtt.Col == colVsDoctor)
            {
                //MessageBox.Show("", "aaa");
                //byte[] data = (byte[])grfPtt[grfPtt.Row, colVsDoctor];
                //MemoryStream stream = new MemoryStream(data);
                //Bitmap bitmap = new Bitmap(stream);
                //Image aaa = bitmap;
                if (grfPtt[grfPtt.Row, colVsDoctor] == null)
                {
                    grfPtt[grfPtt.Row, colVsDoctor] = imgCorr;
                }
                else
                {
                    var bitmap = grfPtt[grfPtt.Row, colVsDoctor];
                    if(compare((Bitmap)imgCorr, (Bitmap)bitmap))
                    {
                        grfPtt[grfPtt.Row, colVsDoctor] = imgTran;
                    }
                    else
                    {
                        grfPtt[grfPtt.Row, colVsDoctor] = imgCorr;
                    }
                    //if (grfPtt[grfPtt.Row, colVsDoctor] == null || grfPtt[grfPtt.Row, colVsDoctor].ToString().Equals(""))
                    //{
                    //    grfPtt[grfPtt.Row, colVsDoctor] = imgCorr;
                    //}
                    //else
                    //{
                    //    grfPtt[grfPtt.Row, colVsDoctor] = imgTran;
                    //}
                }
            }
            else if (grfPtt.Col == colVsOPU)
            {
                if (grfPtt[grfPtt.Row, colVsOPU] == null)
                {
                    grfPtt[grfPtt.Row, colVsOPU] = imgCorr;
                }
                else
                {
                    var bitmap = grfPtt[grfPtt.Row, colVsOPU];
                    if (compare((Bitmap)imgCorr, (Bitmap)bitmap))
                    {
                        grfPtt[grfPtt.Row, colVsOPU] = imgTran;
                    }
                    else
                    {
                        grfPtt[grfPtt.Row, colVsOPU] = imgCorr;
                    }
                }
            }
            else if (grfPtt.Col == colVsTVS)
            {
                if (grfPtt[grfPtt.Row, colVsTVS] == null)
                {
                    grfPtt[grfPtt.Row, colVsTVS] = imgCorr;
                }
                else
                {
                    var bitmap = grfPtt[grfPtt.Row, colVsTVS];
                    if (compare((Bitmap)imgCorr, (Bitmap)bitmap))
                    {
                        grfPtt[grfPtt.Row, colVsTVS] = imgTran;
                    }
                    else
                    {
                        grfPtt[grfPtt.Row, colVsTVS] = imgCorr;
                    }
                }
            }
            else if (grfPtt.Col == colVsDay9)
            {
                if (grfPtt[grfPtt.Row, colVsDay9] == null)
                {
                    grfPtt[grfPtt.Row, colVsDay9] = imgCorr;
                }
                else
                {
                    var bitmap = grfPtt[grfPtt.Row, colVsDay9];
                    if (compare((Bitmap)imgCorr, (Bitmap)bitmap))
                    {
                        grfPtt[grfPtt.Row, colVsDay9] = imgTran;
                    }
                    else
                    {
                        grfPtt[grfPtt.Row, colVsDay9] = imgCorr;
                    }
                }
            }
            else if (grfPtt.Col == colVsDay10)
            {
                if (grfPtt[grfPtt.Row, colVsDay10] == null)
                {
                    grfPtt[grfPtt.Row, colVsDay10] = imgCorr;
                }
                else
                {
                    var bitmap = grfPtt[grfPtt.Row, colVsDay10];
                    if (compare((Bitmap)imgCorr, (Bitmap)bitmap))
                    {
                        grfPtt[grfPtt.Row, colVsDay10] = imgTran;
                    }
                    else
                    {
                        grfPtt[grfPtt.Row, colVsDay10] = imgCorr;
                    }
                }
            }
            else if (grfPtt.Col == colVsHCG)
            {
                if (grfPtt[grfPtt.Row, colVsHCG] == null)
                {
                    grfPtt[grfPtt.Row, colVsHCG] = imgCorr;
                }
                else
                {
                    var bitmap = grfPtt[grfPtt.Row, colVsHCG];
                    if (compare((Bitmap)imgCorr, (Bitmap)bitmap))
                    {
                        grfPtt[grfPtt.Row, colVsHCG] = imgTran;
                    }
                    else
                    {
                        grfPtt[grfPtt.Row, colVsHCG] = imgCorr;
                    }
                }
            }
            else if (grfPtt.Col == colVsSperm)
            {
                if (grfPtt[grfPtt.Row, colVsSperm] == null)
                {
                    grfPtt[grfPtt.Row, colVsSperm] = imgCorr;
                }
                else
                {
                    var bitmap = grfPtt[grfPtt.Row, colVsSperm];
                    if (compare((Bitmap)imgCorr, (Bitmap)bitmap))
                    {
                        grfPtt[grfPtt.Row, colVsSperm] = imgTran;
                    }
                    else
                    {
                        grfPtt[grfPtt.Row, colVsSperm] = imgCorr;
                    }
                }
            }
            else if (grfPtt.Col == colVsPesa)
            {
                if (grfPtt[grfPtt.Row, colVsPesa] == null)
                {
                    grfPtt[grfPtt.Row, colVsPesa] = imgCorr;
                }
                else
                {
                    var bitmap = grfPtt[grfPtt.Row, colVsPesa];
                    if (compare((Bitmap)imgCorr, (Bitmap)bitmap))
                    {
                        grfPtt[grfPtt.Row, colVsPesa] = imgTran;
                    }
                    else
                    {
                        grfPtt[grfPtt.Row, colVsPesa] = imgCorr;
                    }
                }
            }
            else if (grfPtt.Col == colVsSpermF)
            {
                if (grfPtt[grfPtt.Row, colVsSpermF] == null)
                {
                    grfPtt[grfPtt.Row, colVsSpermF] = imgCorr;
                }
                else
                {
                    var bitmap = grfPtt[grfPtt.Row, colVsSpermF];
                    if (compare((Bitmap)imgCorr, (Bitmap)bitmap))
                    {
                        grfPtt[grfPtt.Row, colVsSpermF] = imgTran;
                    }
                    else
                    {
                        grfPtt[grfPtt.Row, colVsSpermF] = imgCorr;
                    }
                }
            }
            else if (grfPtt.Col == colVsET)
            {
                if (grfPtt[grfPtt.Row, colVsET] == null)
                {
                    grfPtt[grfPtt.Row, colVsET] = imgCorr;
                }
                else
                {
                    var bitmap = grfPtt[grfPtt.Row, colVsET];
                    if (compare((Bitmap)imgCorr, (Bitmap)bitmap))
                    {
                        grfPtt[grfPtt.Row, colVsET] = imgTran;
                    }
                    else
                    {
                        grfPtt[grfPtt.Row, colVsET] = imgCorr;
                    }
                }
            }
            //grfPtt.Renderer ;
            grfPtt.Redraw = true;
            grfPtt.Refresh();
            //grfPtt.AutoSizeCols();
            //grfPtt.AutoSizeRows();
        }
        private bool compare(Bitmap bmp1, Bitmap bmp2)
        {
            bool equals = true;
            bool flag = true;  //Inner loop isn't broken

            //Test to see if we have the same size of image
            if (bmp1.Size == bmp2.Size)
            {
                for (int x = 0; x < bmp1.Width; ++x)
                {
                    for (int y = 0; y < bmp1.Height; ++y)
                    {
                        if (bmp1.GetPixel(x, y) != bmp2.GetPixel(x, y))
                        {
                            equals = false;
                            flag = false;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        break;
                    }
                }
            }
            else
            {
                equals = false;
            }
            return equals;
        }
        private void GrfPtt_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();

        }
        private void setGrfPtt1()
        {
            grfPtt.Rows.Count = 2;
            grfPtt.Cols.Count = 39;
            grfPtt.Rows.Fixed = 2;
            grfPtt.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.FixedOnly;
            grfPtt.AllowMergingFixed = C1.Win.C1FlexGrid.AllowMergingEnum.Free;
            grfPtt.AllowSorting = AllowSortingEnum.None;

            grfPtt.Rows[0].AllowMerging = true;
            grfPtt.Rows[1].AllowMerging = true;
            for (int j = 0; j < grfPtt.Cols.Count; j++)
            {
                grfPtt.Cols[j].AllowMerging = true;
            }

            //C1TextBox txt = new C1TextBox();
            PictureBox img = new PictureBox();
            Image img1;
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            //grfPtt.Cols[colPttHn].Editor = txt;
            //grfPtt.Cols[colVsCode].Editor = txt;
            //grfPtt.Cols[colVsTime].Editor = txt;
            //grfPtt.Cols[colVsPttName].Editor = txt;
            //grfPtt.Cols[colVsDoctor].Editor = txt;
            //grfPtt.Cols[colVsDoctor].ImageAndText = false;
            //grfPtt.Cols[colVsSperm].Editor = txt;
            //grfPtt.Cols[colVsDay6].Editor = txt;
            //grfPtt.Cols[colVsDay7].Editor = txt;
            //grfPtt.Cols[colVsDay8].Editor = txt;
            //grfPtt.Cols[colVsDay9].Editor = txt;
            //grfPtt.Cols[colVsDay10].Editor = txt;
            //grfPtt.Cols[colVsTVS].Editor = txt;
            //grfPtt.Cols[colVsPesa].Editor = txt;
            //grfPtt.Cols[colVsSpermF].Editor = txt;
            //grfPtt.Cols[colVsOPU].Editor = txt;
            //grfPtt.Cols[colVsET].Editor = txt;
            //grfPtt.Cols[colVsHCG].Editor = txt;
            //grfPtt.Cols[colVsSpermOPU].Editor = txt;
            //grfPtt.Cols[colVsTrans].Editor = txt;
            //grfPtt.Cols[colVsANC].Editor = txt;
            //grfPtt.Cols[colVsAnes].Editor = txt;
            //grfPtt.Cols[colVsRemark].Editor = txt;
            //grfPtt.Cols[colVsAppn].Editor = txt;
            //Column col = grfPtt.Cols[colVsDoctor];
            //col.DataType = typeof(Image);
            Column colOPU = grfPtt.Cols[colVsOPU];
            colOPU.DataType = typeof(Image);
            Column colTVS = grfPtt.Cols[colVsTVS];
            colTVS.DataType = typeof(Image);
            Column colDay6 = grfPtt.Cols[colVsDay6];
            colDay6.DataType = typeof(Image);
            Column colDay7 = grfPtt.Cols[colVsDay7];
            colDay7.DataType = typeof(Image);
            Column colDay8 = grfPtt.Cols[colVsDay8];
            colDay8.DataType = typeof(Image);
            Column colDay9 = grfPtt.Cols[colVsDay9];
            colDay9.DataType = typeof(Image);
            Column colDay10 = grfPtt.Cols[colVsDay10];
            colDay10.DataType = typeof(Image);
            Column colDay11 = grfPtt.Cols[colVsDay11];
            colDay11.DataType = typeof(Image);

            Column colHCG = grfPtt.Cols[colVsHCG];
            colHCG.DataType = typeof(Image);

            Column colSperm = grfPtt.Cols[colVsSperm];
            colSperm.DataType = typeof(Image);
            Column colEndo = grfPtt.Cols[colVsPesa];
            colEndo.DataType = typeof(Image);
            Column colDC = grfPtt.Cols[colVsSpermF];
            colDC.DataType = typeof(Image);
            Column colET = grfPtt.Cols[colVsET];
            colET.DataType = typeof(Image);
            Column colE2 = grfPtt.Cols[colVSE2];
            colE2.DataType = typeof(Image);
            Column colLh = grfPtt.Cols[colVSLh];
            colLh.DataType = typeof(Image);
            Column colPrl = grfPtt.Cols[colVSPrl];
            colPrl.DataType = typeof(Image);
            Column colFsh = grfPtt.Cols[colVSFsh];
            colFsh.DataType = typeof(Image);
            Column colFET = grfPtt.Cols[colVsFET];
            colFET.DataType = typeof(Image);
            Column colSpermOPU = grfPtt.Cols[colVsSpermOPU];
            colSpermOPU.DataType = typeof(Image);
            Column colSpermSA = grfPtt.Cols[colVsSpermSA];
            colSpermSA.DataType = typeof(Image);
            Column colConsult1 = grfPtt.Cols[colConsult];
            colConsult1.DataType = typeof(Image);

            grfPtt.Cols[colPttHn].Width = 100;
            grfPtt.Cols[colVsCode].Width = 60;
            grfPtt.Cols[colVsTime].Width = 60;
            grfPtt.Cols[colVsPttName].Width = 200;
            grfPtt.Cols[colVsDoctor].Width = 80;
            grfPtt.Cols[colVsSperm].Width = 60;
            grfPtt.Cols[colVsDay6].Width = 60;
            grfPtt.Cols[colVsDay7].Width = 60;
            grfPtt.Cols[colVsDay8].Width = 60;
            grfPtt.Cols[colVsDay9].Width = 60;
            grfPtt.Cols[colVsDay10].Width = 60;
            grfPtt.Cols[colVsTVS].Width = 60;
            grfPtt.Cols[colVsPesa].Width = 60;
            grfPtt.Cols[colVsSpermF].Width = 60;
            grfPtt.Cols[colVsOPU].Width = 60;
            grfPtt.Cols[colVsET].Width = 60;
            grfPtt.Cols[colVsHCG].Width = 60;
            grfPtt.Cols[colVsSpermOPU].Width = 60;
            grfPtt.Cols[colVsTrans].Width = 60;
            grfPtt.Cols[colVsANC].Width = 60;
            grfPtt.Cols[colVsAnes].Width = 100;
            grfPtt.Cols[colVsRemark].Width = 200;
            grfPtt.Cols[colVSE2].Width = 60;
            grfPtt.Cols[colVSLh].Width = 60;
            grfPtt.Cols[colVSPrl].Width = 60;
            grfPtt.Cols[colVSFsh].Width = 60;
            grfPtt.Cols[colVsFET].Width = 60;
            grfPtt.Cols[colVsDay11].Width = 60;
            grfPtt.Cols[colVsAgent].Width = 80;
            grfPtt.Cols[colStfCreate].Width = 80;
            grfPtt.Cols[colStfModi].Width = 80;
            grfPtt.Cols[colStfSave].Width = 80;
            grfPtt.Cols[colVsSpermSA].Width = 60;
            grfPtt.Cols[colConsult].Width = 60;

            grfPtt.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfPtt.Cols[colPttHn].Caption = "HN";
            grfPtt.Cols[colVsCode].Caption = "Code";
            grfPtt.Cols[colVsTime].Caption = "Time";
            grfPtt.Cols[colVsPttName].Caption = "Name";
            //grfPtt.Cols[colVsPttName].Caption = "Doctor";
            grfPtt.Cols[colVsDoctor].Caption = "Consult";
            grfPtt.Cols[colVsSperm].Caption = "Sperm";
            grfPtt.Cols[colVsDay6].Caption = "Day6";
            grfPtt.Cols[colVsDay7].Caption = "Day7";
            grfPtt.Cols[colVsDay8].Caption = "Day8";
            grfPtt.Cols[colVsDay9].Caption = "Day9";
            grfPtt.Cols[colVsDay10].Caption = "Day10";
            grfPtt.Cols[colVsDay11].Caption = "Day11";
            grfPtt.Cols[colVsTVS].Caption = "TVS";
            grfPtt.Cols[colVsPesa].Caption = "PESA";
            grfPtt.Cols[colVsSpermF].Caption = "Sp.Fz";
            grfPtt.Cols[colVsOPU].Caption = "OPU";
            grfPtt.Cols[colVsET].Caption = "ET";
            grfPtt.Cols[colVsHCG].Caption = "HCG";
            grfPtt.Cols[colVsSpermOPU].Caption = "Sp OPU";
            grfPtt.Cols[colVsTrans].Caption = "Trans";
            grfPtt.Cols[colVsANC].Caption = "ANC";
            grfPtt.Cols[colVsAnes].Caption = "Anes";
            grfPtt.Cols[colVsRemark].Caption = "Remark";
            grfPtt.Cols[colVSE2].Caption = "E2";
            grfPtt.Cols[colVSLh].Caption = "LH";
            grfPtt.Cols[colVSPrl].Caption = "PRL";
            grfPtt.Cols[colVSFsh].Caption = "FSH";
            grfPtt.Cols[colVsFET].Caption = "FET";
            grfPtt.Cols[colVsAgent].Caption = "Agent";
            grfPtt.Cols[colVsSpermSA].Caption = "Sp.SA";
            grfPtt.Cols[colConsult].Caption = "Consult";
            //grfPtt.Cols[celStfSave].Caption = "FET";

            CellRange rng1 = grfPtt.GetCellRange(0, colVsTime, 1, colVsTime);
            rng1.Data = "Time";
            CellRange rng2 = grfPtt.GetCellRange(0, colPttHn, 1, colPttHn);
            rng2.Data = "HN";
            CellRange rng3 = grfPtt.GetCellRange(0, colVsCode, 1, colVsCode);
            rng3.Data = "Code";
            CellRange rng4 = grfPtt.GetCellRange(0, colVsPttName, 1, colVsPttName);
            rng4.Data = "Name";
            CellRange rng5 = grfPtt.GetCellRange(0, colVsTVS, 1, colVsTVS);
            rng5.Data = "TVS";
            CellRange rng6 = grfPtt.GetCellRange(0, colVsSpermF, 1, colVsSpermF);
            rng6.Data = "Sp.Fz";
            CellRange rng7 = grfPtt.GetCellRange(0, colVsOPU, 1, colVsOPU);
            rng7.Data = "OPU";
            CellRange rng8 = grfPtt.GetCellRange(0, colVsET, 1, colVsET);
            rng8.Data = "ET";
            CellRange rng9 = grfPtt.GetCellRange(0, colVsSpermOPU, 1, colVsSpermOPU);
            rng9.Data = "Sp OPU";
            CellRange rng10 = grfPtt.GetCellRange(0, colVsANC, 1, colVsANC);
            rng10.Data = "ANC";
            CellRange rng11 = grfPtt.GetCellRange(0, colVsAnes, 1, colVsAnes);
            rng11.Data = "Anes";
            CellRange rng12 = grfPtt.GetCellRange(0, colVsRemark, 1, colVsRemark);
            rng12.Data = "Remark";
            CellRange rng13 = grfPtt.GetCellRange(0, colVsFET, 1, colVsFET);
            rng13.Data = "FET";
            CellRange rng14 = grfPtt.GetCellRange(0, colVSE2, 1, colVSE2);
            rng14.Data = "E2";
            CellRange rng15 = grfPtt.GetCellRange(0, colVSLh, 1, colVSLh);
            rng15.Data = "LH";
            CellRange rng16 = grfPtt.GetCellRange(0, colVSPrl, 1, colVSPrl);
            rng16.Data = "Prl";
            CellRange rng17 = grfPtt.GetCellRange(0, colVSFsh, 1, colVSFsh);
            rng17.Data = "FSH";
            CellRange rng18 = grfPtt.GetCellRange(0, colVsAgent, 1, colVsAgent);
            rng18.Data = "Agent";
            CellRange rng19 = grfPtt.GetCellRange(0, colStfCreate, 1, colStfCreate);
            rng19.Data = "stf create";
            CellRange rng20 = grfPtt.GetCellRange(0, colStfModi, 1, colStfModi);
            rng20.Data = "stf modi";
            CellRange rng21= grfPtt.GetCellRange(0, colStfSave, 1, colStfSave);
            rng21.Data = "stf save";
            CellRange rng22 = grfPtt.GetCellRange(0, colVsSpermSA, 1, colVsSpermSA);
            rng22.Data = "Sp.SA";
            //CellRange rng23 = grfPtt.GetCellRange(0, colConsult, 1, colConsult);
            //rng22.Data = "Consult";

            grfPtt[1, colVsDoctor] = "Dr.";
            grfPtt[1, colVsSperm] = "Collect";
            grfPtt[1, colVsSpermF] = "Sp.Fz";
            grfPtt[1, colVsDay6] = "Bld/TVS";
            grfPtt[1, colVsDay7] = "Bld/TVS.";
            grfPtt[1, colVsDay8] = "Bld/TVS";
            grfPtt[1, colVsDay9] = "Bld/TVS.";
            grfPtt[1, colVsDay10] = "Bld/TVS";
            grfPtt[1, colVsDay11] = "Bld/TVS.";
            //grfPtt[1, colVsPesa] = "PESA";
            grfPtt[1, colVsHCG] = "HCG";
            grfPtt[1, colVsTrans] = "Sperm";
            grfPtt[1, colVsSpermOPU] = "Sp OPU";
            grfPtt[1, colVsAgent] = "Agent";
            grfPtt[1, colStfCreate] = "stf create";
            grfPtt[1, colStfModi] = "stf modi";
            grfPtt[1, colStfSave] = "stf save";
            grfPtt[1, colVsPesa] = "TESE";
            grfPtt[1, colConsult] = "Consult";
        }
        private void setGrfPtt(ConnectDB con, DataTable dtApmOld, DataTable dtApm)
        {
            //grfDept.Rows.Count = 7;
            grfPtt.Clear();
            //DataTable dt = new DataTable();
            //DataTable dtD = new DataTable();
            //ConnectDB con = new ConnectDB(ic.iniC);

            //DateTime datestart, dateend;
            //String datestart1="", dateend1="";
            //if (DateTime.TryParse(txtDateStart.Text, out datestart))
            //{
            //    datestart1 = datestart.ToString("yyyy-MM-dd");
            //}
            //else
            //{
            //    datestart1 = ic.datetoDB(txtDateStart.Text);
            //}
            //dateend1 = datestart1;
            //if(DateTime.TryParse(txtDateEnd.Text, out dateend))
            //{
            //    dateend1 = dateend.ToString("yyyy-MM-dd");
            //}
            //else
            //{
            //    dateend1 = ic.datetoDB(txtDateEnd.Text);
            //}
            //String date = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
            //if (ic.iniC.statusAppDonor.Equals("1"))
            //{
            //    dtD = ic.ivfDB.pApmDB.selectByDay(datestart1, dateend1);
            //    dt = ic.ivfDB.appnOldDB.selectByDateDtr(con.connEx, datestart1, dateend1, cboDoctor.Text);
            //}
            //else
            //{
            //    dtD = ic.ivfDB.pApmDB.selectByDay(con.connEx,datestart1, dateend1);
            //    dt = ic.ivfDB.appnOldDB.selectByDateDtr(datestart1, dateend1, cboDoctor.Text);
            //}

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            setGrfPtt1();
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("&แก้ไข Appointment", new EventHandler(ContextMenu_edit));
            grfPtt.ContextMenu = menuGw;

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            //foreach (DataRow row in dtApmOld.Rows)
            //{
            //    Row row1 = grfPtt.Rows.Add();
            //    String hormo="", tvs="", opu="", fet="", beta="", other="", appn = "";
            //    hormo = row[ic.ivfDB.pApmOldDB.pApmO.HormoneTest].ToString().Equals("1") ? "Hormone Test " : "";
            //    tvs = row[ic.ivfDB.pApmOldDB.pApmO.TVS].ToString().Equals("1") ? "TVS " : "";
            //    opu = row[ic.ivfDB.pApmOldDB.pApmO.OPU].ToString().Equals("1") ? "OPU " + row[ic.ivfDB.pApmOldDB.pApmO.OPUTime] != null ? row[ic.ivfDB.pApmOldDB.pApmO.OPUTime].ToString()+ row[ic.ivfDB.pApmOldDB.pApmO.OPURemark]!=null ? row[ic.ivfDB.pApmOldDB.pApmO.OPURemark].ToString() : "" : "" : "";
            //    beta = row[ic.ivfDB.pApmOldDB.pApmO.BetaHCG].ToString().Equals("1") ? "Beta HCG " : "";
            //    fet = row[ic.ivfDB.pApmOldDB.pApmO.ET_FET].ToString().Equals("1") ? "ET/FET " + row[ic.ivfDB.pApmOldDB.pApmO.ET_FET_Time] != null ? row[ic.ivfDB.pApmOldDB.pApmO.ET_FET_Time].ToString() : "" : "";
            //    other = row[ic.ivfDB.pApmOldDB.pApmO.Other].ToString().Equals("1") ? "Other " + row[ic.ivfDB.pApmOldDB.pApmO.OtherRemark] != null ? row[ic.ivfDB.pApmOldDB.pApmO.OtherRemark].ToString() : "" : "";
            //    appn = hormo + tvs + opu + beta + fet + other;

            //    row1[0] = i;
            //    row1[colID] = row[ic.ivfDB.pApmOldDB.pApmO.ID].ToString();
            //    row1[colVsPttName] = row[ic.ivfDB.pApmOldDB.pApmO.PatientName].ToString();
            //    row1[colpttId] = row[ic.ivfDB.pApmOldDB.pApmO.PID].ToString();
            //    row1[colPttHn] = row[ic.ivfDB.pApmOldDB.pApmO.PIDS].ToString();
            //    row1[colVsTime] = row[ic.ivfDB.pApmOldDB.pApmO.AppTime].ToString();
            //    row1[colVsCode] = "";
            //    row1[colVsDoctor] = row[ic.ivfDB.pApmOldDB.pApmO.Doctor].ToString();
            //    row1[colVsStatus] = "1";
            //    //row1[colVsTVS] = row[ic.ivfDB.pApmOldDB.pApmO.TVS].ToString().Equals("1") ? imgCorr : imgTran;
            //    //row1[colVsET] = row[ic.ivfDB.pApmOldDB.pApmO.ET_FET].ToString().Equals("1") ? imgCorr : imgTran;
            //    //row1[colVsHCG] = row[ic.ivfDB.pApmOldDB.pApmO.BetaHCG].ToString().Equals("1") ? imgCorr : imgTran;
            //    row1[colVsOPU] = row[ic.ivfDB.pApmOldDB.pApmO.OPU].ToString().Equals("1") ? imgCorr : imgTran;
            //    if (row[ic.ivfDB.pApmOldDB.pApmO.OPU].ToString().Equals("1"))
            //    {
            //        CellNote note = new CellNote(opu);
            //        CellRange rg = grfPtt.GetCellRange(grfPtt.Rows.Count - 1, colVsOPU);
            //        rg.UserData = note;
            //    }
            //    if (row[ic.ivfDB.pApmOldDB.pApmO.BetaHCG].ToString().Equals("1"))
            //    {
            //        CellNote note = new CellNote(beta);
            //        CellRange rg = grfPtt.GetCellRange(grfPtt.Rows.Count - 1, colVsHCG);
            //        rg.UserData = note;
            //        //row1[colVsHCG] = imgCorr;
            //    }
            //    //if (row[ic.ivfDB.appnOldDB.appnOld.TVS].ToString().Equals("1"))
            //    //{
            //    //    row1[colVsTVS] = imgCorr;
            //    //}
            //    //else
            //    //{
            //    //    row1[colVsTVS] = imgTran;
            //    //}
            //    //row1[colVsSperm] = "";
            //    //row1[colVsDay6] = "";
            //    //row1[colVsDay7] = "";
            //    //row1[colVsDay8] = "";
            //    //row1[colVsDay9] = "";
            //    //row1[colVsDay10] = "";
            //    ////row1[colVsTVS] = "";
            //    ///
            //    //row1[colVsPesa] = "";
            //    //row1[colVsPRP] = "";
            //    //if (row[ic.ivfDB.appnOldDB.appnOld.OPU].ToString().Equals("1"))
            //    //{
            //    //    row1[colVsOPU] = imgCorr;
            //    //}
            //    //else
            //    //{
            //    //    row1[colVsOPU] = imgTran;
            //    //}
                
            //    //row1[colVsET_FET] = "";
            //    //row1[colVsHCG] = "";
            //    //row1[colVsDC] = "";
            //    //row1[colVsTrans] = "";
            //    //row1[colVsANC] = "";
            //    ////row1[colVsAnes] = row[ic.ivfDB.appnOldDB.appnOld.Doctor].ToString();
            //    //row1[colVsAnes] = "";
            //    //row1[colVsRemark] = "";
                                
            //    //if (i % 2 == 0)
            //    //    grfPtt.Rows[i].StyleNew.BackColor = color;
            //    i++;
            //}
            foreach (DataRow row in dtApm.Rows)
            {
                String hormo = "", tvs = "", opu = "", fet = "", beta = "", other = "", appn = "";
                int chk = 0;
                Row row1 = grfPtt.Rows.Add();
                row1[0] = i;
                row1[colID] = row[ic.ivfDB.pApmDB.pApm.t_patient_appointment_id].ToString();
                row1[colVsPttName] = row["PatientName"].ToString();
                row1[colpttId] = row[ic.ivfDB.pApmDB.pApm.t_patient_id].ToString();
                //row1[colPttHn] = row["patient_hn"].ToString();        //-0021
                row1[colPttHn] = row["pids"].ToString();        //+0021
                row1[colVsTime] = row[ic.ivfDB.pApmDB.pApm.patient_appointment_time].ToString();

                opu = row[ic.ivfDB.pApmDB.pApm.opu].ToString().Equals("1") ? "OPU " + row[ic.ivfDB.pApmDB.pApm.opu_time] != null ? row[ic.ivfDB.pApmDB.pApm.opu_time].ToString() : "" : "";

                //row1[colVsTVS] = row[ic.ivfDB.pApmDB.pApm.tvs].ToString();
                //row1[colVsOPU] = row[ic.ivfDB.pApmDB.pApm.opu].ToString();
                row1[colVsAnes] = row[ic.ivfDB.pApmDB.pApm.doctor_anes].ToString();
                row1[colVsDoctor] = row[ic.ivfDB.pApmDB.pApm.dtr_name].ToString();
                row1[colVsSperm] = row[ic.ivfDB.pApmDB.pApm.sperm_collect].ToString().Equals("1") ? imgCorr : imgTran;
                row1[colVsSpermF] = row[ic.ivfDB.pApmDB.pApm.sperm_freezing].ToString().Equals("1") ? imgCorr : imgTran;
                row1[colVSE2] = row[ic.ivfDB.pApmDB.pApm.e2].ToString().Equals("1") ? imgCorr : imgTran;
                row1[colVSLh] = row[ic.ivfDB.pApmDB.pApm.lh].ToString().Equals("1") ? imgCorr : imgTran;
                row1[colVSPrl] = row[ic.ivfDB.pApmDB.pApm.prl].ToString().Equals("1") ? imgCorr : imgTran;
                row1[colVSFsh] = row[ic.ivfDB.pApmDB.pApm.fsh].ToString().Equals("1") ? imgCorr : imgTran;
                row1[colVsTVS] = row[ic.ivfDB.pApmDB.pApm.tvs].ToString().Equals("1") ? imgCorr : imgTran;
                row1[colVsOPU] = row[ic.ivfDB.pApmDB.pApm.opu].ToString().Equals("1") ? imgCorr : imgTran;
                row1[colVsET] = row[ic.ivfDB.pApmDB.pApm.et].ToString().Equals("1") ? imgCorr : imgTran;
                row1[colVsFET] = row[ic.ivfDB.pApmDB.pApm.fet].ToString().Equals("1") ? imgCorr : imgTran;
                row1[colVsHCG] = row[ic.ivfDB.pApmDB.pApm.beta_hgc].ToString().Equals("1") ? imgCorr : imgTran;
                row1[colVsPesa] = row[ic.ivfDB.pApmDB.pApm.pesa].ToString().Equals("1") ? imgCorr : imgTran;
                row1[colVsSpermOPU] = row[ic.ivfDB.pApmDB.pApm.sperm_opu].ToString().Equals("1") ? imgCorr : imgTran;
                row1[colVsRemark] = row[ic.ivfDB.pApmDB.pApm.patient_appointment].ToString();
                row1[colVsAgent] = row["AgentName"].ToString();
                row1[colVsSpermSA] = row[ic.ivfDB.pApmDB.pApm.sperm_sa].ToString().Equals("1") ? imgCorr : imgTran;
                row1[colConsult] = row[ic.ivfDB.pApmDB.pApm.consult].ToString().Equals("1") ? imgCorr : imgTran;
                String stf = "";
                stf = row[ic.ivfDB.pApmDB.pApm.user_create].ToString();
                if (stf.IndexOf("@") >= 0)
                {
                    stf = stf.Substring(0, stf.IndexOf("@"));
                    row1[colStfCreate] = ic.ivfDB.stfDB.getStaffNameBylStf(stf);
                }
                
                stf = "";
                stf = row[ic.ivfDB.pApmDB.pApm.user_modi].ToString();
                if (stf.IndexOf("@") >= 0)
                {
                    stf = stf.Substring(0, stf.IndexOf("@"));
                    row1[colStfModi] = ic.ivfDB.stfDB.getStaffNameBylStf(stf);
                }
                
                stf = "";
                stf = row[ic.ivfDB.pApmDB.pApm.patient_appointment_staff_record].ToString();
                if (stf.IndexOf("@") >= 0)
                {
                    stf = stf.Substring(0, stf.IndexOf("@"));
                    row1[colStfSave] = ic.ivfDB.stfDB.getStaffNameBylStf(stf);
                }
                if (!row[ic.ivfDB.pApmDB.pApm.tvs_day].ToString().Equals(""))
                {
                    CellNote note = new CellNote("Day "+row[ic.ivfDB.pApmDB.pApm.tvs_day].ToString()+" [Time "+ row[ic.ivfDB.pApmDB.pApm.tvs_time].ToString()+"]");
                    CellRange rg = grfPtt.GetCellRange(grfPtt.Rows.Count - 1, colVsTVS);
                    rg.UserData = note;
                }
                if (!row[ic.ivfDB.pApmDB.pApm.opu_time].ToString().Equals(""))
                {
                    CellNote note = new CellNote(" [Time " + row[ic.ivfDB.pApmDB.pApm.opu_time].ToString() + "]");
                    CellRange rg = grfPtt.GetCellRange(grfPtt.Rows.Count - 1, colVsOPU);
                    rg.UserData = note;
                }
                if (row[ic.ivfDB.pApmDB.pApm.opu].ToString().Equals("1"))
                {
                    CellNote note = new CellNote(opu);
                    CellRange rg = grfPtt.GetCellRange(grfPtt.Rows.Count - 1, colVsOPU);
                    rg.UserData = note;
                }
                if (row[ic.ivfDB.pApmDB.pApm.beta_hgc].ToString().Equals("1"))
                {
                    CellNote note = new CellNote(beta);
                    CellRange rg = grfPtt.GetCellRange(grfPtt.Rows.Count - 1, colVsHCG);
                    rg.UserData = note;
                    //row1[colVsHCG] = imgCorr;
                }
                if (!row[ic.ivfDB.pApmDB.pApm.fet_time].ToString().Equals(""))
                {
                    CellNote note = new CellNote(" [Time " + row[ic.ivfDB.pApmDB.pApm.fet_time].ToString() + "]");
                    CellRange rg = grfPtt.GetCellRange(grfPtt.Rows.Count - 1, colVsFET);
                    rg.UserData = note;
                }
                if (int.TryParse(row[ic.ivfDB.pApmDB.pApm.tvs_day].ToString(), out chk))
                {
                    if (chk == 6)
                    {
                        row1[colVsDay6] = imgCorr;
                    }
                    else if (chk == 7)
                    {
                        row1[colVsDay7] = imgCorr;
                    }
                    else if (chk == 8)
                    {
                        row1[colVsDay8] = imgCorr;
                    }
                    else if (chk == 9)
                    {
                        row1[colVsDay9] = imgCorr;
                    }
                    else if (chk == 10)
                    {
                        row1[colVsDay10] = imgCorr;
                    }
                    else if (chk == 11)
                    {
                        row1[colVsDay11] = imgCorr;
                    }
                }
                row1[colConn] = "con";
                row1[colVsStatus] = "2";
                i++;
            }

            //foreach (DataRow row in dtApmOld.Rows)        //-0021
            //{        //-0021
            //    String hormo = "", tvs = "", opu = "", fet = "", beta = "", other = "", appn = "";        //-0021
            //    int chk = 0;        //-0021
            //    Row row1 = grfPtt.Rows.Add();        //-0021
            //    row1[0] = i;        //-0021
            //    row1[colID] = row[ic.ivfDB.pApmDB.pApm.t_patient_appointment_id].ToString();        //-0021
            //    row1[colVsPttName] = row["PatientName"].ToString();        //-0021
            //    row1[colpttId] = row[ic.ivfDB.pApmDB.pApm.t_patient_id].ToString();        //-0021
            //    //row1[colPttHn] = row["patient_hn"].ToString();        //-0021        //-0021
            //    row1[colPttHn] = row["pids"].ToString();          //+0021        //-0021
            //    row1[colVsTime] = row[ic.ivfDB.pApmDB.pApm.patient_appointment_time].ToString().Trim();        //-0021

            //    opu = row[ic.ivfDB.pApmDB.pApm.opu].ToString().Equals("1") ? "OPU " + row[ic.ivfDB.pApmDB.pApm.opu_time] != null ? row[ic.ivfDB.pApmDB.pApm.opu_time].ToString() : "" : "";        //-0021

            //    //row1[colVsTVS] = row[ic.ivfDB.pApmDB.pApm.tvs].ToString();        //-0021
            //    //row1[colVsOPU] = row[ic.ivfDB.pApmDB.pApm.opu].ToString();        //-0021
            //    row1[colVsAnes] = row[ic.ivfDB.pApmDB.pApm.doctor_anes].ToString();        //-0021
            //    row1[colVsDoctor] = row[ic.ivfDB.pApmDB.pApm.dtr_name].ToString();        //-0021
            //    row1[colVsSperm] = row[ic.ivfDB.pApmDB.pApm.sperm_collect].ToString().Equals("1") ? imgCorr : imgTran;        //-0021
            //    row1[colVSE2] = row[ic.ivfDB.pApmDB.pApm.e2].ToString().Equals("1") ? imgCorr : imgTran;        //-0021
            //    row1[colVSLh] = row[ic.ivfDB.pApmDB.pApm.lh].ToString().Equals("1") ? imgCorr : imgTran;        //-0021        //-0021
            //    row1[colVSPrl] = row[ic.ivfDB.pApmDB.pApm.prl].ToString().Equals("1") ? imgCorr : imgTran;        //-0021
            //    row1[colVSFsh] = row[ic.ivfDB.pApmDB.pApm.fsh].ToString().Equals("1") ? imgCorr : imgTran;        //-0021
            //    row1[colVsTVS] = row[ic.ivfDB.pApmDB.pApm.tvs].ToString().Equals("1") ? imgCorr : imgTran;        //-0021
            //    row1[colVsOPU] = row[ic.ivfDB.pApmDB.pApm.opu].ToString().Equals("1") ? imgCorr : imgTran;        //-0021
            //    row1[colVsET] = row[ic.ivfDB.pApmDB.pApm.et].ToString().Equals("1") ? imgCorr : imgTran;        //-0021
            //    row1[colVsFET] = row[ic.ivfDB.pApmDB.pApm.fet].ToString().Equals("1") ? imgCorr : imgTran;        //-0021
            //    row1[colVsHCG] = row[ic.ivfDB.pApmDB.pApm.beta_hgc].ToString().Equals("1") ? imgCorr : imgTran;        //-0021
            //    row1[colVsPesa] = row[ic.ivfDB.pApmDB.pApm.pesa].ToString().Equals("1") ? imgCorr : imgTran;        //-0021
            //    row1[colVsSpermF] = row[ic.ivfDB.pApmDB.pApm.sperm_freezing].ToString().Equals("1") ? imgCorr : imgTran;        //-0021
            //    row1[colVsSpermOPU] = row[ic.ivfDB.pApmDB.pApm.sperm_opu].ToString().Equals("1") ? imgCorr : imgTran;        //-0021
            //    row1[colVsRemark] = row[ic.ivfDB.pApmDB.pApm.patient_appointment].ToString();        //-0021
            //    row1[colVsAgent] = row["AgentName"].ToString();        //-0021
            //    row1[colVsSpermSA] = row[ic.ivfDB.pApmDB.pApm.sperm_sa].ToString().Equals("1") ? imgCorr : imgTran;        //-0021
            //    row1[colConsult] = row[ic.ivfDB.pApmDB.pApm.consult].ToString().Equals("1") ? imgCorr : imgTran;        //-0021
            //    String stf = "";        //-0021
            //    stf = row[ic.ivfDB.pApmDB.pApm.user_create].ToString();        //-0021
            //    if (stf.IndexOf("@") >= 0)        //-0021
            //    {        //-0021
            //        stf = stf.Substring(0, stf.IndexOf("@"));        //-0021

            //        row1[colStfCreate] = ic.ivfDB.stfDB.getStaffNameBylStfEx(stf);  // ต้องเป็น ex เพราะ เป็นข้อมูลจากอีก database หนึ่ง        //-0021
            //    }        //-0021

            //    stf = "";        //-0021
            //    stf = row[ic.ivfDB.pApmDB.pApm.user_modi].ToString();        //-0021
            //    if (stf.IndexOf("@") >= 0)        //-0021
            //    {        //-0021
            //        stf = stf.Substring(0, stf.IndexOf("@"));        //-0021
            //        row1[colStfModi] = ic.ivfDB.stfDB.getStaffNameBylStfEx(stf);  // ต้องเป็น ex เพราะ เป็นข้อมูลจากอีก database หนึ่ง        //-0021
            //    }        //-0021

            //    stf = "";        //-0021
            //    stf = row[ic.ivfDB.pApmDB.pApm.patient_appointment_staff_record].ToString();        //-0021
            //    if (stf.IndexOf("@") >= 0)        //-0021
            //    {        //-0021
            //        stf = stf.Substring(0, stf.IndexOf("@"));        //-0021
            //        row1[colStfSave] = ic.ivfDB.stfDB.getStaffNameBylStfEx(stf);  // ต้องเป็น ex เพราะ เป็นข้อมูลจากอีก database หนึ่ง        //-0021
            //    }        //-0021

            //    if (!row[ic.ivfDB.pApmDB.pApm.tvs_day].ToString().Equals(""))        //-0021
            //    {        //-0021
            //        CellNote note = new CellNote("Day " + row[ic.ivfDB.pApmDB.pApm.tvs_day].ToString() + " [Time " + row[ic.ivfDB.pApmDB.pApm.tvs_time].ToString() + "]");        //-0021
            //        CellRange rg = grfPtt.GetCellRange(grfPtt.Rows.Count - 1, colVsTVS);        //-0021
            //        rg.UserData = note;        //-0021
            //    }        //-0021
            //    if (!row[ic.ivfDB.pApmDB.pApm.opu_time].ToString().Equals(""))        //-0021
            //    {        //-0021
            //        CellNote note = new CellNote(" [Time " + row[ic.ivfDB.pApmDB.pApm.opu_time].ToString() + "]");        //-0021
            //        CellRange rg = grfPtt.GetCellRange(grfPtt.Rows.Count - 1, colVsOPU);        //-0021
            //        rg.UserData = note;        //-0021
            //    }        //-0021
            //    if (row[ic.ivfDB.pApmDB.pApm.opu].ToString().Equals("1"))        //-0021
            //    {        //-0021
            //        CellNote note = new CellNote(opu);        //-0021
            //        CellRange rg = grfPtt.GetCellRange(grfPtt.Rows.Count - 1, colVsOPU);        //-0021
            //        rg.UserData = note;        //-0021
            //    }        //-0021
            //    if (row[ic.ivfDB.pApmDB.pApm.beta_hgc].ToString().Equals("1"))        //-0021
            //    {        //-0021
            //        CellNote note = new CellNote(beta);        //-0021
            //        CellRange rg = grfPtt.GetCellRange(grfPtt.Rows.Count - 1, colVsHCG);        //-0021
            //        rg.UserData = note;        //-0021
            //        //row1[colVsHCG] = imgCorr;        //-0021
            //    }        //-0021
            //    if (!row[ic.ivfDB.pApmDB.pApm.fet_time].ToString().Equals(""))        //-0021
            //    {        //-0021
            //        CellNote note = new CellNote(" [Time " + row[ic.ivfDB.pApmDB.pApm.fet_time].ToString() + "]");        //-0021
            //        CellRange rg = grfPtt.GetCellRange(grfPtt.Rows.Count - 1, colVsFET);        //-0021
            //        rg.UserData = note;        //-0021
            //    }        //-0021
            //    if (int.TryParse(row[ic.ivfDB.pApmDB.pApm.tvs_day].ToString(), out chk))        //-0021
            //    {        //-0021
            //        if (chk == 6)        //-0021
            //        {        //-0021
            //            row1[colVsDay6] = imgCorr;        //-0021
            //        }        //-0021
            //        else if (chk == 7)        //-0021
            //        {        //-0021
            //            row1[colVsDay7] = imgCorr;        //-0021
            //        }        //-0021
            //        else if (chk == 8)        //-0021
            //        {        //-0021
            //            row1[colVsDay8] = imgCorr;        //-0021
            //        }        //-0021
            //        else if (chk == 9)        //-0021
            //        {        //-0021
            //            row1[colVsDay9] = imgCorr;        //-0021
            //        }        //-0021
            //        else if (chk == 10)        //-0021
            //        {        //-0021
            //            row1[colVsDay10] = imgCorr;        //-0021
            //        }        //-0021
            //        else if (chk == 11)        //-0021
            //        {        //-0021
            //            row1[colVsDay11] = imgCorr;        //-0021
            //        }        //-0021
            //    }        //-0021
            //    row1[colConn] = "conEx";        //-0021
            //    row1[colVsStatus] = "2";        //-0021
            //    i++;        //-0021
            //}        //-0021
            CellNoteManager mgr = new CellNoteManager(grfPtt);
            grfPtt.Cols[colVsDay9].AllowEditing = false;
            grfPtt.Cols[colVsDay10].AllowEditing = false;
            grfPtt.Cols[colVsHCG].AllowEditing = false;
            grfPtt.Cols[colVsET].AllowEditing = false;
            grfPtt.Cols[colVsSpermF].AllowEditing = false;
            grfPtt.Cols[colVsPesa].AllowEditing = false;
            grfPtt.Cols[colVsTVS].AllowEditing = false;
            grfPtt.Cols[colVsDoctor].AllowEditing = true;
            grfPtt.Cols[colVsSperm].AllowEditing = true;
            grfPtt.Cols[colVsOPU].AllowEditing = false;
            grfPtt.Cols[colVsAgent].AllowEditing = false;

            grfPtt.Cols[colID].Visible = false;
            grfPtt.Cols[colpttId].Visible = false;
            grfPtt.Cols[colVsStatus].Visible = false;
            //grfPtt.Cols[colVsPesa].Visible = false;
            grfPtt.Cols[colVsCode].Visible = false;
            grfPtt.Cols[colVsDay8].Visible = true;
            grfPtt.Cols[colVsDoctor].Visible = false;
            grfPtt.Cols[colVsTrans].Visible = false;
            grfPtt.Cols[colConn].Visible = false;

            grfPtt.Cols[colVsSperm].Visible = false;
            grfPtt.Cols[colVsAnes].Visible = false;

            grfPtt.Cols[colVsDay6].Visible = false;
            grfPtt.Cols[colVsDay7].Visible = false;
            grfPtt.Cols[colVsDay8].Visible = false;
            grfPtt.Cols[colVsDay9].Visible = false;
            grfPtt.Cols[colVsDay10].Visible = false;
            grfPtt.Cols[colVsDay11].Visible = false;
            //grfPtt.Cols[colVsDay11].Visible = false;
            //grfPtt.Cols[colVsDay11].Visible = false;

            if (ic.user.status_admin.Equals("2"))
            {
                grfPtt.Cols[colStfCreate].Visible = true;
                grfPtt.Cols[colStfModi].Visible = true;
                grfPtt.Cols[colStfSave].Visible = true;
                //grfPtt.Cols[colStfModi].Visible = true;
            }
            else
            {
                grfPtt.Cols[colStfCreate].Visible = false;
                grfPtt.Cols[colStfModi].Visible = false;
                grfPtt.Cols[colStfSave].Visible = false;
                //grfPtt.Cols[colStfModi].Visible = false;
            }
            //grfPtt.Cols[colConn].Visible = false;
            theme1.SetTheme(grfPtt, ic.theme);

        }
        private void ContextMenu_edit(object sender, System.EventArgs e)
        {
            String pttId = "", name = "", id = "",conn="";
            id = grfPtt[grfPtt.Row, colID] != null ? grfPtt[grfPtt.Row, colID].ToString() : "";
            pttId = grfPtt[grfPtt.Row, colpttId] != null ? grfPtt[grfPtt.Row, colpttId].ToString() : "";
            name = grfPtt[grfPtt.Row, colVsPttName] != null ? grfPtt[grfPtt.Row, colVsPttName].ToString() : "";
            conn = grfPtt[grfPtt.Row, colConn] != null ? grfPtt[grfPtt.Row, colConn].ToString() : "";
            if (conn.Equals("conEx") || conn.Equals(""))
            {
                MessageBox.Show("เป็น Appointment คนละโปรแกรม", "");
                return;
            }
            if (id.Equals("") || conn.Equals("0"))
            {
                MessageBox.Show("ID ไม่ถูกต้อง", "");
                return;
            }
            //FrmAppointmentDonorAdd frm = new FrmAppointmentDonorAdd(ic, id, pttId, "");       //  -3
            FrmAppointmentAdd frm = new FrmAppointmentAdd(ic, id, pttId, "","");       //  +3
            frm.ShowDialog(this);
            setGrf();
            //if (MessageBox.Show("ต้องการ แก้ไข Patient  \n  hn number " + chk + " \n name " + name, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            //grfReq.Rows.Remove(grfReq.Row);
            //openPatientAdd(id, name);
            //}
        }
        private void FrmAppoinmentView_Load(object sender, EventArgs e)
        {
            theme1.SetTheme(groupBox1, ic.theme);
            theme1.SetTheme(gb, ic.theme);
            foreach (Control c in groupBox1.Controls)
            {
                theme1.SetTheme(c, ic.theme);
            }
            foreach (Control c in gb.Controls)
            {
                theme1.SetTheme(c, ic.theme);
            }
        }
    }
}
