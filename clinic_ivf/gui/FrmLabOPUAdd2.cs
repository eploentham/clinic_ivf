using C1.Win.C1Command;
using C1.Win.C1Document;
using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1SuperTooltip;
using C1.Win.FlexViewer;
using clinic_ivf.control;
using clinic_ivf.object1;
using clinic_ivf.Properties;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.gui
{
    /*
     *          0012        OPU, FET การแก้ไขรูป และข้อมความ
     */
    public partial class FrmLabOPUAdd2 : Form
    {
        IvfControl ic;
        String reqId = "", opuId = "";
        LabRequest lbReq;
        LabOpu opu;

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;
        int colDay2ID = 1, colDay2Num = 2, colDay2Desc = 3, colDay2Desc1 = 4, colDay2Desc2 = 5, colDay2Edit = 6, colDay2StatusBio=7;
        int colDay3ID = 1, colDay3Num = 2, colDay3Desc = 3, colDay3Desc1 = 4, colDay3Desc2 = 5, colDay3Edit = 6;
        int colDay5ID = 1, colDay5Num = 2, colDay5Desc = 3, colDay5Desc1 = 4, colDay5Desc2 = 5, colDay5Edit = 6;
        int colDay6ID = 1, colDay6Num = 2, colDay6Desc = 3, colDay6Desc1 = 4, colDay6Desc2 = 5, colDay6Edit = 6;

        int colDay2ImgId = 1, colDay2ImgPic = 3, colDay2ImgNun = 2, colDay2ImgDesc0 = 4, colDay2PathPic = 5, colDay2ImgDesc1 = 6, colDay2ImgEdit=8, noofOPU=0;

        C1FlexGrid grfDay2, grfDay3, grfDay5, grfDay6, grfDay2Img, grfDay3Img, grfDay5Img, grfDay6Img;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        Color color;
        Boolean flagDay2Img = false, flagDay3Img = false, flagDay5Img = false, flagDay6Img = false;
        Boolean grf2Focus = false, grf3Focus = false, grf5Focus = false, grf6Focus = false;
        private bool prefixSeen;
        String theme2 = "Office2007Blue";       //Office2016Black       BeigeOne
        String flagEdit = "";
        Image imgCorr, imgTran, imgFinish;
        FrmLabPrescription frmlabPresc;

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        internal static extern IntPtr GetFocus();
        public FrmLabOPUAdd2(IvfControl ic, String reqid, String opuid)
        {
            InitializeComponent();
            this.ic = ic;
            reqId = reqid;
            opuId = opuid;

            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);

            //C1ThemeController.ApplicationTheme = ic.iniC.themeApplication;
            //theme1.Theme = C1ThemeController.ApplicationTheme;
            theme1.SetTheme(sB, "BeigeOne");
            color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);

            sB1.Text = "";
            bg = txtHnFeMale.BackColor;
            fc = txtHnFeMale.ForeColor;
            ff = txtHnFeMale.Font;

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            opu = new LabOpu();
            lbReq = new LabRequest();
            imgCorr = Resources.red_checkmark_png_16;
            imgTran = Resources.red_checkmark_png_51;
            imgFinish = Resources.OK_24;

            ic.ivfDB.proceDB.setCboLabProce(cboOpuProce, objdb.LabProcedureDB.StatusLab.OPUProcedure);//cboEmbryoForEtDoctor
            ic.ivfDB.dtrOldDB.setCboDoctor(cboDoctor, "");
            ic.ivfDB.dtrOldDB.setCboDoctor(cboEmbryoForEtDoctor, "");
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

            ic.ivfDB.fdtDB.setCboOPUMethod(cboEmbryoFreezMethod0);
            ic.ivfDB.fdtDB.setCboOPUMethod(cboEmbryoFreezMethod1);
            ic.ivfDB.fdtDB.setCboOPUStage(cboEmbryoFreezStage0, "");
            ic.ivfDB.fdtDB.setCboOPUStage(cboEmbryoFreezStage1, "");
            ic.ivfDB.fdtDB.setCboOPUFreezeMedia(cboEmbryoFreezMedia0);
            ic.ivfDB.fdtDB.setCboOPUFreezeMedia(cboEmbryoFreezMedia1);
            ic.setCboDay(CboEmbryoFreezDay0, "");
            ic.setCboDay(CboEmbryoFreezDay1, "");
            ic.ivfDB.opuDB.setCboRemark(cboRemark);
            ic.ivfDB.opuDB.setCboRemark1(cboRemark1);
            ic.ivfDB.opuDB.setCboRemarkDay2(cboRemarkDay2);
            ic.ivfDB.opuDB.setCboRemarkDay3(cboRemarkDay3);
            ic.ivfDB.opuDB.setCboRemarkDay5(cboRemarkDay5);
            ic.ivfDB.opuDB.setCboRemarkDay6(cboRemarkDay6);

            //stt.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.Gold;

            setClick();
            txtMaturaNoofOpu1.KeyUp += TxtMaturaNoofOpu_KeyUp;       //txtMaturaNoofOpu
            txtMaturaDate.DropDownClosed += TxtMaturaDate_DropDownClosed;
            txtMaturaDate.KeyUp += TxtMaturaDate_KeyUp;
            txtMaturaMii.KeyUp += TxtMaturaDate_KeyUp;
            txtMaturaMi.KeyUp += TxtMaturaDate_KeyUp;
            txtMaturaGv.KeyUp += TxtMaturaDate_KeyUp;
            txtMaturaPostMat.KeyUp += TxtMaturaDate_KeyUp;
            txtMaturaAbnor.KeyUp += TxtMaturaDate_KeyUp;
            txtMaturaDead.KeyUp += TxtMaturaDate_KeyUp;
            txtFertiliDate.KeyUp += TxtFertiliDate_KeyUp;
            txtFertili2Pn.KeyUp += TxtFertiliDate_KeyUp;
            txtFertili1Pn.KeyUp += TxtFertiliDate_KeyUp;
            txtFertili3Pn.KeyUp += TxtFertiliDate_KeyUp;
            txtFertili4Pn.KeyUp += TxtFertiliDate_KeyUp;
            txtFertiliNoPn.KeyUp += TxtFertiliDate_KeyUp;
            txtFertiliDead.KeyUp += TxtFertiliDate_KeyUp;
            txtSpermDate.KeyUp += TxtSpermDate_KeyUp;
            txtSpermCnt.KeyUp += TxtSpermDate_KeyUp;
            txtSpermTotalCnt.KeyUp += TxtSpermDate_KeyUp;
            txtSpermMoti.KeyUp += TxtSpermDate_KeyUp;
            txtSpermMotiTotal.KeyUp += TxtSpermDate_KeyUp;
            txtSpermMotility.KeyUp += TxtSpermDate_KeyUp;
            txtSpermVol.KeyUp += TxtSpermDate_KeyUp;
            txtEmbryoFreezNoOg0.KeyUp += TxtEmbryoFreezNoOg0_KeyUp;
            txtEmbryoFreezNoStraw0.KeyUp += TxtEmbryoFreezNoOg0_KeyUp;
            txtEmbryoFreezNoOg1.KeyUp += TxtEmbryoFreezNoOg0_KeyUp;
            txtEmbryoFreezNoStraw1.KeyUp += TxtEmbryoFreezNoOg0_KeyUp;
            txtEmbryoForEtNO.KeyUp += TxtEmbryoForEtNO_KeyUp;

            txtFertili2PnAdd.KeyUp += TxtFertiliDate_KeyUp;
            setKeyPress();
            
            btnResultDay1.MouseMove += BtnResultDay1_MouseMove;
            btnResultDay3.MouseMove += BtnResultDay3_MouseMove;
            btnResultDay5.MouseMove += BtnResultDay5_MouseMove;
            btnSaveImg6Copy.Click += BtnSaveImg6Copy_Click;
            btnSaveDay6Copy.Click += BtnSaveDay6Copy_Click;
            btnResultDay5View.Click += BtnResultDay5View_Click;
            btnResultDay6.Click += BtnResultDay6_Click;
            btnResultDay6View.Click += BtnResultDay6View_Click;

            setFocusColor();
            initGrf();
            setControl();
            setGrf();
            setTheme();
            char c = '\u00B5';
            label86.Text = c.ToString()+"l";

            if (!ic.user.status_module_lab.Equals("1"))
            {
                btnSave.Enabled = false;
                btnSaveMatura.Enabled = false;
                btnSaveFertili.Enabled = false;
                btnSaveSperm.Enabled = false;
                btnSaveEmbryoFreezDay0.Enabled = false;
                btnSaveEmbryoFreezDay1.Enabled = false;
                btnSaveDay2.Enabled = false;
                btnSaveDay3.Enabled = false;
                btnSaveDay5.Enabled = false;
                btnSaveDay6.Enabled = false;
                btnSaveEmbryoEt.Enabled = false;
                btnSaveImg2.Enabled = false;
                btnSaveImg3.Enabled = false;
                btnSaveImg5.Enabled = false;
                btnSaveImg6.Enabled = false;

            }
            btnSaveDay2.Hide();
            btnSaveDay3.Hide();
            btnSaveDay5.Hide();
            btnSaveDay6.Hide();
            btnSaveMatura.Hide();
            btnSaveFertili.Hide();
            btnSaveSperm.Hide();
            btnSaveEmbryoFreezDay0.Hide();
            btnSaveEmbryoFreezDay1.Hide();
            btnSaveEmbryoEt.Hide();
            btnResultDay1View.Hide();

            Panel pnlabPresc = new Panel();
            pnlabPresc.Dock = DockStyle.Fill;
            pnlabPresc.BackColor = Color.Red;

            frmlabPresc = new FrmLabPrescription(ic, "",txtID.Text,txtHnMale.Text);
            frmlabPresc.FormBorderStyle = FormBorderStyle.None;
            frmlabPresc.Dock = DockStyle.Fill;
            frmlabPresc.TopLevel = false;

            pnlabPresc.Controls.Add(frmlabPresc);
            tabPresc.Controls.Add(pnlabPresc);
            frmlabPresc.Show();
        }

        private void BtnResultDay6View_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.showResultDay(txtID.Text.Trim(), "6", this);
        }

        private void BtnResultDay6_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.cStf.staff_id = "";
            Boolean chkSave = false;
            //FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            //frm.ShowDialog(this);
            //if (!ic.cStf.staff_id.Equals(""))
            //{
                ic.statusResultDay6 = "";
                ic.opu_report_day6 = "";
                FrmLabOPUPrint frmPrn = new FrmLabOPUPrint(ic, txtID.Text, FrmLabOPUPrint.opuReport.ResultDay6);
                frmPrn.ShowDialog(this);
                if (ic.statusResultDay6.Equals("1"))
                {
                    long chk1 = 0;
                    String re = ic.ivfDB.opuDB.updateStatusOPUApproveResultDay6(txtID.Text, ic.user.staff_id);
                    if (long.TryParse(re, out chk1))
                    {
                        LabRequest req = new LabRequest();
                        req = ic.ivfDB.lbReqDB.selectByPk1(opu.req_id);
                        String re1 = ic.ivfDB.lbReqDB.UpdateStatusRequestResult(req.req_id, ic.cStf.staff_id);
                        if (long.TryParse(re1, out chk1))
                        {
                            opu = ic.ivfDB.opuDB.selectByPk1(txtID.Text);
                            MessageBox.Show("ส่งผล LAB OPU Day6 ให้ทางพยาบาล เรียบร้อย ", "");       //clinic_ivf.Properties.Resources.Female_user_accept_24
                            btnApproveResult.Image = Resources.Female_user_accept_24;
                        }
                    }
                }
            //}
        }
        private void BtnSaveDay6Copy_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmWaiting frmW = new FrmWaiting();
            frmW.Show();

            try
            {
                DataTable dtDay5 = new DataTable();
                DataTable dtDay6 = new DataTable();
                dtDay6 = ic.ivfDB.opuEmDevDB.selectByOpuFetId_Day(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day6);
                int i = -1;
                foreach (Row row in grfDay6Img.Rows)
                {
                    i++;
                    String id = "", filename = "", re = "", noday6 = "", remotefile = "", re1 = "";
                    id = row[colDay2ImgId] != null ? row[colDay2ImgId].ToString() : "";

                    noday6 = row[colDay2ImgNun] != null ? row[colDay2ImgNun].ToString() : "";
                    int noday61 = 0;
                    if (!int.TryParse(noday6, out noday61)) continue;
                    if (id.Equals("")) continue;

                    dtDay5 = ic.ivfDB.opuEmDevDB.selectByOpuFetId_Day(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day5, noday61.ToString());
                    if (dtDay5.Rows.Count > 0)
                    {
                        //if (dtDay5.Rows[0][ic.ivfDB.opuEmDevDB.opuEmDev.path_pic].ToString().Equals(""))
                        //{
                        //    continue;
                        //}
                        
                        String desc0 = dtDay5.Rows[0][ic.ivfDB.opuEmDevDB.opuEmDev.desc0].ToString();
                        String desc1 = dtDay5.Rows[0][ic.ivfDB.opuEmDevDB.opuEmDev.desc1].ToString();
                        String desc2 = dtDay5.Rows[0][ic.ivfDB.opuEmDevDB.opuEmDev.desc2].ToString();
                        String desc3 = dtDay5.Rows[0][ic.ivfDB.opuEmDevDB.opuEmDev.desc3].ToString();
                        String desc4 = dtDay5.Rows[0][ic.ivfDB.opuEmDevDB.opuEmDev.desc4].ToString();
                        String desc5 = dtDay5.Rows[0][ic.ivfDB.opuEmDevDB.opuEmDev.desc5].ToString();
                        String no = "";
                        long chk = 0;
                        re = ic.ivfDB.opuEmDevDB.updateDesc012345(id, desc0, desc1, desc2, desc3, desc4, desc5);
                        if (long.TryParse(re, out chk))
                        {
                            //ic.savePicOPUtoServer(txtOpuCode.Text, filename, pathfile);
                            
                        }
                    }
                }
                setGrfDay6();
            }
            catch (Exception ex)
            {
                String err = "";
            }
            finally
            {
                frmW.Dispose();
                setGrfDay6Img();
            }
        }

        private void TxtMaturaDate_DropDownClosed(object sender, DropDownClosedEventArgs e)
        {
            //throw new NotImplementedException();
            setTxtmaturaDate();
        }

        private void BtnSaveImg6Copy_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmWaiting frmW = new FrmWaiting();
            frmW.Show();

            try
            {
                DataTable dtDay5 = new DataTable();
                DataTable dtDay6 = new DataTable();
                dtDay6 = ic.ivfDB.opuEmDevDB.selectByOpuFetId_Day(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day6);
                int i = -1;
                foreach (Row row in grfDay6Img.Rows)
                {
                    i++;
                    String id = "", filename = "", re = "", noday6 = "", remotefile = "", re1="";
                    id = row[colDay2ImgId] != null ? row[colDay2ImgId].ToString() : "";
                    
                    noday6 = row[colDay2ImgNun] != null ? row[colDay2ImgNun].ToString() : "";
                    int noday61 = 0;
                    if (!int.TryParse(noday6, out noday61)) continue;
                    if (id.Equals("")) continue;

                    dtDay5 = ic.ivfDB.opuEmDevDB.selectByOpuFetId_Day(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day5, noday61.ToString());
                    if(dtDay5.Rows.Count > 0)
                    {
                        if (dtDay5.Rows[0][ic.ivfDB.opuEmDevDB.opuEmDev.path_pic].ToString().Equals(""))
                        {
                            continue;
                        }
                        //String statusBio = row[colDay2StatusBio] == imgFinish ? "1" : "0";
                        //String desc1 = row[colDay2ImgDesc1] != null ? row[colDay2ImgDesc1].ToString() : "";
                        //String desc = row[colDay2ImgDesc0] != null ? row[colDay2ImgDesc0].ToString() : "";
                        //String no = row[colDay2ImgNun] != null ? row[colDay2ImgNun].ToString() : "";
                        String statusBio = dtDay5.Rows[0][ic.ivfDB.opuEmDevDB.opuEmDev.status_biopsy_ngs].ToString();
                        String desc1 = dtDay5.Rows[0][ic.ivfDB.opuEmDevDB.opuEmDev.desc4].ToString();
                        String desc = dtDay5.Rows[0][ic.ivfDB.opuEmDevDB.opuEmDev.desc3].ToString();
                        String no = "";
                        filename = dtDay5.Rows[0][ic.ivfDB.opuEmDevDB.opuEmDev.path_pic].ToString();
                        remotefile = filename.Replace("day5", "day6");
                        re = ic.ivfDB.opuEmDevDB.updatePathPic(id, noday6, remotefile, ic.cStf.staff_id);
                        re1 = ic.ivfDB.opuEmDevDB.updatePathPicNoPic(id, "", desc, desc1, ic.cStf.staff_id, statusBio);       // +0012
                        long chk = 0;
                        if (long.TryParse(re, out chk))
                        {
                            //ic.savePicOPUtoServer(txtOpuCode.Text, filename, pathfile);
                            MemoryStream ms = null;
                            ms = ic.ftpC.download(ic.iniC.hostFTP, filename);
                            if (ms.Length <= 0) return;
                            ms.Seek(0, SeekOrigin.Begin);
                            ic.ftpC.upload(remotefile, ms);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                String err = "";
            }
            finally
            {
                frmW.Dispose();
                setGrfDay6Img();
            }
        }

        private void BtnResultDay5_MouseMove(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
            if (!opu.status_approve_result_day5.Equals(""))
            {
                string text = "";
                StringBuilder tip = new StringBuilder();

                // append general 'get help' tip
                tip.AppendFormat("<b>{0}</b> options.", "ได้ส่ง ผลLAB day5 ไป เมื่อวันที่ " + ic.datetoShow(opu.approve_result_day5_date));
                tip.AppendFormat("<b>{0}</b> options.", "staff " + ic.ivfDB.stfDB.getStaffNameBylStf(opu.approve_result_day5_staff_id));
                tip.Append("<hr noshade size=1 color=lightBlue>");
                tip.AppendFormat("<table><tr><td><img src='{0}'><td>{1}</table>", "res://helpToolStripButton.Image", "Press <b>F1</b> for more help.");

                text = tip.ToString();
                stt.SetToolTip(btnResultDay3, text);
            }
        }

        private void BtnResultDay3_MouseMove(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
            if (!opu.status_approve_result_day3.Equals(""))
            {
                string text = "";
                StringBuilder tip = new StringBuilder();

                // append general 'get help' tip
                tip.AppendFormat("<b>{0}</b> options.", "ได้ส่ง ผลLAB day3 ไป เมื่อวันที่ " + ic.datetoShow(opu.approve_result_day3_date));
                tip.AppendFormat("<b>{0}</b> options.", "staff " + ic.ivfDB.stfDB.getStaffNameBylStf(opu.approve_result_day3_staff_id));
                tip.Append("<hr noshade size=1 color=lightBlue>");
                tip.AppendFormat("<table><tr><td><img src='{0}'><td>{1}</table>", "res://helpToolStripButton.Image", "Press <b>F1</b> for more help.");

                text = tip.ToString();
                stt.SetToolTip(btnResultDay3, text);
            }
        }

        private void BtnResultDay1_MouseMove(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
            if (!opu.status_approve_result_day1.Equals(""))
            {
                string text = "";
                StringBuilder tip = new StringBuilder();

                // append general 'get help' tip
                tip.AppendFormat("<b>{0}</b> options.", "ได้ส่ง ผลLAB day1 ไป เมื่อวันที่ "+ic.datetoShow(opu.approve_result_day1_date));
                tip.AppendFormat("<b>{0}</b> options.", "staff " + ic.ivfDB.stfDB.getStaffNameBylStf(opu.approve_result_day1_staff_id));
                tip.Append("<hr noshade size=1 color=lightBlue>");
                tip.AppendFormat("<table><tr><td><img src='{0}'><td>{1}</table>", "res://helpToolStripButton.Image", "Press <b>F1</b> for more help.");

                text = tip.ToString();
                stt.SetToolTip(btnResultDay1, text);
            }
        }
        private void BtnResultDay5View_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.showResultDay(txtID.Text.Trim(), "5", this);
        }
        private void BtnResultDay5_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //if (MessageBox.Show("ต้องการ ส่งผล LAB OPU Day 5 ให้ทางพยาบาล  ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            //ic.cStf.staff_id = "";
            //Boolean chkSave = false;
            //FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            //frm.ShowDialog(this);
            //if (!ic.cStf.staff_id.Equals(""))
            //{
            //ic.cStf.staff_id = "";
            //Boolean chkSave = false;
            //FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            //frm.ShowDialog(this);
            //if (!ic.cStf.staff_id.Equals(""))
            //{
                ic.statusResultDay5 = "";
                ic.opu_report_day5 = "";
                FrmLabOPUPrint frmPrn = new FrmLabOPUPrint(ic, txtID.Text, FrmLabOPUPrint.opuReport.ResultDay5);
                frmPrn.ShowDialog(this);
                if (ic.statusResultDay5.Equals("1"))
                {
                    long chk1 = 0;
                    String re = ic.ivfDB.opuDB.updateStatusOPUApproveResultDay5(txtID.Text, ic.user.staff_id);
                    if (long.TryParse(re, out chk1))
                    {
                        LabRequest req = new LabRequest();
                        req = ic.ivfDB.lbReqDB.selectByPk1(opu.req_id);
                        String re1 = ic.ivfDB.lbReqDB.UpdateStatusRequestResult(req.req_id, ic.cStf.staff_id);
                        if (long.TryParse(re1, out chk1))
                        {
                            opu = ic.ivfDB.opuDB.selectByPk1(txtID.Text);
                            MessageBox.Show("ส่งผล LAB OPU Day5 ให้ทางพยาบาล เรียบร้อย ", "");       //clinic_ivf.Properties.Resources.Female_user_accept_24
                            btnApproveResult.Image = Resources.Female_user_accept_24;
                        }
                    }
                }
            //}
                
                //}
            //}
        }
        private void BtnResultDay3View_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.showResultDay(txtID.Text.Trim(), "3", this);
        }
        private void BtnResultDay3_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //if (MessageBox.Show("ต้องการ ส่งผล LAB OPU Day 3 ให้ทางพยาบาล  ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            ic.cStf.staff_id = "";
            Boolean chkSave = false;
            //FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            //frm.ShowDialog(this);
            //if (!ic.cStf.staff_id.Equals(""))
            //{
                ic.statusResult = "";
                ic.opu_report_day3 = "";
                FrmLabOPUPrint frmPrn = new FrmLabOPUPrint(ic, txtID.Text, FrmLabOPUPrint.opuReport.ResultDay3);
                frmPrn.ShowDialog(this);
                if (ic.statusResult.Equals("1"))
                {
                    long chk1 = 0;
                    String re = ic.ivfDB.opuDB.updateStatusOPUApproveResultDay3(txtID.Text, ic.user.staff_id);
                    if (long.TryParse(re, out chk1))
                    {
                        LabRequest req = new LabRequest();
                        req = ic.ivfDB.lbReqDB.selectByPk1(opu.req_id);
                        String re1 = ic.ivfDB.lbReqDB.UpdateStatusRequestResult(req.req_id, ic.cStf.staff_id);
                        if (long.TryParse(re1, out chk1))
                        {
                            opu.report_day3 = ic.opu_report_day3;
                            MessageBox.Show("ส่งผล LAB OPU Day3 ให้ทางพยาบาล เรียบร้อย ", "");       //clinic_ivf.Properties.Resources.Female_user_accept_24
                            btnApproveResult.Image = Resources.Female_user_accept_24;
                        }
                    }
                }
            //}
            //}
        }
        private String setExportDay1()
        {
            Boolean chk = true;
            DataTable dt = new DataTable();
            CrystalReportViewer cryLab;
            cryLab = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ReportDocument rpt = new ReportDocument();
            String filename = "", directory="", ext=".pdf";
            directory = AppDomain.CurrentDomain.BaseDirectory;
            filename = directory+"report\\" +DateTime.Now.Ticks.ToString()+ ext;
            
            try
            {
                dt = ic.ivfDB.setOPUReport(txtID.Text, "2", "3", true);     //ต้องการดึงเพื่อส่ง day1 
                rpt.Load("lab_opu_day1.rpt");
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                rpt.SetParameterValue("line2", "โทรศัพท์ " + ic.cop.tele);
                rpt.SetParameterValue("report_name", "Summary of OPU Report");

                cryLab.ReportSource = rpt;
                cryLab.Refresh();
                //lbEmail.Text = "สร้าง Report เรียบร้อย";
                Application.DoEvents();
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                    System.Threading.Thread.Sleep(200);
                    Application.DoEvents();
                }
                Application.DoEvents();
                ExportOptions CrExportOptions;
                DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                CrDiskFileDestinationOptions.DiskFileName = filename;
                CrExportOptions = rpt.ExportOptions;
                {
                    CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                    CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                    CrExportOptions.FormatOptions = CrFormatTypeOptions;
                }
                //lbEmail.Text = "Export Report";
                Application.DoEvents();
                rpt.Export();
                System.Threading.Thread.Sleep(200);
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                chk = false;
                //chk = ex.Message.ToString();
                new LogWriter("e", "FrmLabOPUAdd2 setExportDay1 " + ex.Message);
                MessageBox.Show("error " + ex.Message, "");
            }
            
            return filename;
        }
        private void BtnResultDay1_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //if (MessageBox.Show("ต้องการ ส่งผล LAB OPU Day 1 ให้ทางพยาบาล  ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            ic.cStf.staff_id = "";
            Boolean chkSave = false;
            //FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            //frm.ShowDialog(this);
            //if (!ic.cStf.staff_id.Equals(""))
            //{
                ic.statusResultDay1 = "";
                ic.opu_report_day1 = "";
                FrmLabOPUPrint frmPrn = new FrmLabOPUPrint(ic, txtID.Text, FrmLabOPUPrint.opuReport.ResultDay1);
                frmPrn.ShowDialog(this);
                if (ic.statusResultDay1.Equals("1"))
                {
                    //FrmWaiting frmW = new FrmWaiting();
                    //frmW.Show();
                    long chk1 = 0;
                    //String filename = setExportDay1();
                    //String filename1 = Path.GetFileName(filename);
                    //if (File.Exists(filename))       // -0012
                    //{       // -0012
                        //ic.savePicOPUtoServer(txtOpuCode.Text, filename1, filename);       // -0012
                        //String re = ic.ivfDB.opuDB.updateStatusOPUApproveResultDay1(txtID.Text, filename1, ic.user.staff_id);
                        //opu.report_day1 = filename1;
                        //if (long.TryParse(re, out chk1))
                        //{
                        //    LabRequest req = new LabRequest();
                        //    req = ic.ivfDB.lbReqDB.selectByPk1(opu.req_id);
                        //    String re1 = ic.ivfDB.lbReqDB.UpdateStatusRequestResult(req.req_id, ic.cStf.staff_id);

                        //    if (long.TryParse(re1, out chk1))
                            //{
                                MessageBox.Show("ส่งผล LAB OPU Day1 ให้ทางพยาบาล เรียบร้อย ", "");       //clinic_ivf.Properties.Resources.Female_user_accept_24
                                btnApproveResult.Image = Resources.Female_user_accept_24;
                        //    }
                        //}
                    //}
                    //frmW.Dispose();
                }
            //}
            //}
        }
        private void BtnApproveResult_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //if (MessageBox.Show("ต้องการ ส่งผล LAB OPU ให้ทางพยาบาล  ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
                ic.cStf.staff_id = "";
                Boolean chkSave = false;
                //FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                //frm.ShowDialog(this);
                //if (!ic.cStf.staff_id.Equals(""))
                //{
                long chk1 = 0;
                String re = ic.ivfDB.opuDB.updateStatusOPUApproveResult(txtID.Text, ic.user.staff_id);
                if (long.TryParse(re, out chk1))
                {
                    LabRequest req = new LabRequest();
                    req = ic.ivfDB.lbReqDB.selectByPk1(opu.req_id);
                    String re1 = ic.ivfDB.lbReqDB.UpdateStatusRequestResult(req.req_id, ic.cStf.staff_id);
                    if (long.TryParse(re1, out chk1))
                    {
                        //MessageBox.Show("ส่งผล LAB OPU ให้ทางพยาบาล เรียบร้อย ", "");       //clinic_ivf.Properties.Resources.Female_user_accept_24
                        btnApproveResult.Image = Resources.Female_user_accept_24;
                    }
                }
                //}
            //}
        }

        private void setTheme()
        {
            theme1.SetTheme(sB, "BeigeOne");
            theme1.SetTheme(this, theme2);
            theme1.SetTheme(groupBox1, theme2);
            theme1.SetTheme(groupBox3, theme2);
            theme1.SetTheme(groupBox4, theme2);
            theme1.SetTheme(groupBox5, theme2);
            theme1.SetTheme(groupBox7, theme2);
            theme1.SetTheme(groupBox2, theme2);
            theme1.SetTheme(c1CommandDock2, theme2);
            theme1.SetTheme(tC1, theme2);
            theme1.SetTheme(gbDay2, theme2);
            theme1.SetTheme(gbDay3, theme2);
            theme1.SetTheme(gbDay5, theme2);
            theme1.SetTheme(gbDay6, theme2);
            theme1.SetTheme(panel3, theme2);
            theme1.SetTheme(panel4, theme2);
            theme1.SetTheme(panel5, theme2);
            theme1.SetTheme(panel6, theme2);

            theme1.SetTheme(pn2, theme2);
            theme1.SetTheme(pn5, theme2);
            theme1.SetTheme(pn3, theme2);
            theme1.SetTheme(pn6, theme2);
            theme1.SetTheme(pnGrf2Img, theme2);
            theme1.SetTheme(pnGrf3Img, theme2);
            theme1.SetTheme(pnGrf5Img, theme2);
            theme1.SetTheme(pnGrf6Img, theme2);
            theme1.SetTheme(pn2Grf, theme2);
            theme1.SetTheme(pn3Grf, theme2);
            theme1.SetTheme(pn5Grf, theme2);
            theme1.SetTheme(pn6Grf, theme2);
            //theme1.SetTheme(groupBox2, theme2);
            theme1.SetTheme(groupBox3, theme2);
            theme1.SetTheme(groupBox4, theme2);
            theme1.SetTheme(groupBox5, theme2);
            theme1.SetTheme(groupBox6, theme2);
            theme1.SetTheme(groupBox8, theme2);
            theme1.SetTheme(panel4, theme2);
            //theme1.SetTheme(panel5, theme2);
            theme1.SetTheme(panel6, theme2);
            theme1.SetTheme(splitContainer1, theme2);
            theme1.SetTheme(splitContainer2, theme2);
            theme1.SetTheme(splitContainer3, theme2);
            //theme1.SetTheme(splitContainer4, theme2);
            //theme1.SetTheme(splitContainer5, theme2);

            foreach (Control ctl in groupBox1.Controls)
            {
                theme1.SetTheme(ctl, theme2);
            }
            foreach (Control ctl in groupBox3.Controls)
            {
                theme1.SetTheme(ctl, theme2);
            }
            foreach (Control ctl in groupBox4.Controls)
            {
                theme1.SetTheme(ctl, theme2);
            }
            foreach (Control ctl in groupBox5.Controls)
            {
                theme1.SetTheme(ctl, theme2);
            }
            foreach (Control ctl in groupBox7.Controls)
            {
                theme1.SetTheme(ctl, theme2);
            }
            foreach (Control ctl in groupBox2.Controls)
            {
                theme1.SetTheme(ctl, theme2);
            }
            //foreach (ComboBoxItemList ctl in cboOpuProce.Items) 
            //{
            //    theme1.SetTheme(ctl, theme2);
            //}
            foreach (Control ctl in pn2.Controls)
            {
                theme1.SetTheme(ctl, theme2);
            }
            foreach (Control ctl in pn3.Controls)
            {
                theme1.SetTheme(ctl, theme2);
            }
            foreach (Control ctl in pn5.Controls)
            {
                theme1.SetTheme(ctl, theme2);
            }
            foreach (Control ctl in pn6.Controls)
            {
                theme1.SetTheme(ctl, theme2);
            }
            foreach (Control ctl in panel3.Controls)
            {
                theme1.SetTheme(ctl, theme2);
            }
            foreach (Control ctl in panel4.Controls)
            {
                theme1.SetTheme(ctl, theme2);
            }
            foreach (Control ctl in panel5.Controls)
            {
                theme1.SetTheme(ctl, theme2);
            }
            foreach (Control ctl in panel6.Controls)
            {
                theme1.SetTheme(ctl, theme2);
            }
            foreach (Control ctl in pn2.Controls)
            {
                theme1.SetTheme(ctl, theme2);
            }
            foreach (Control ctl in pn3.Controls)
            {
                theme1.SetTheme(ctl, theme2);
            }
            foreach (Control ctl in pn5.Controls)
            {
                theme1.SetTheme(ctl, theme2);
            }
            foreach (Control ctl in pn6.Controls)
            {
                theme1.SetTheme(ctl, theme2);
            }
            foreach (Control ctl in pnGrf2Img.Controls)
            {
                theme1.SetTheme(ctl, theme2);
            }
            foreach (Control ctl in pnGrf3Img.Controls)
            {
                theme1.SetTheme(ctl, theme2);
            }
            foreach (Control ctl in pnGrf5Img.Controls)
            {
                theme1.SetTheme(ctl, theme2);
            }
            foreach (Control ctl in pnGrf6Img.Controls)
            {
                theme1.SetTheme(ctl, theme2);
            }
            foreach (Control ctl in groupBox6.Controls)
            {
                theme1.SetTheme(ctl, theme2);
            }
            foreach (Control ctl in groupBox8.Controls)
            {
                theme1.SetTheme(ctl, theme2);
            }
            theme1.SetTheme(cboOpuProce, theme2);
            theme1.SetTheme(cboDoctor, theme2);
            theme1.SetTheme(cboRemark, theme2);
            theme1.SetTheme(cboRemark1, theme2);
            theme1.SetTheme(grfDay2, theme2);
            theme1.SetTheme(grfDay3, theme2);
            theme1.SetTheme(grfDay5, theme2);
            theme1.SetTheme(grfDay6, theme2);
        }
        private Control GetFocusedControl()
        {
            Control focusedControl = null;
            // To get hold of the focused control:
            IntPtr focusedHandle = GetFocus();
            if (focusedHandle != IntPtr.Zero)
                // Note that if the focused Control is not a .Net control, then this will return null.
                focusedControl = Control.FromHandle(focusedHandle);
            return focusedControl;
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
                case Keys.V | Keys.Control:
                    Control ctl1 = new Control();
                    ctl1 = GetFocusedControl();
                    if (ctl1 is C1ComboBox)
                    {
                        C1ComboBox ccc = (C1ComboBox)ctl1;
                        ccc.Text = Clipboard.GetText();
                        //Clipboard.SetText(ccc.SelectedText);
                    }
                    else if(ctl1 is C1TextBox)
                    {
                        C1TextBox ccc = (C1TextBox)ctl1;
                        ccc.Value = Clipboard.GetText();
                    }
                    return true;
                case Keys.S | Keys.Control :
                    if (ic.user.status_module_lab.Equals("1"))
                    {
                        ic.cStf.staff_id = "";
                        Boolean chkSave = false;
                        //FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                        //frm.ShowDialog(this);
                        //if (!ic.cStf.staff_id.Equals(""))
                        //{
                            saveLabOPU();
                        //}
                    }
                        
                    // ... Process Shift+Ctrl+Alt+B ...
                    //MessageBox.Show("1111", "");
                    return true; // signal that we've processed this key
                case Keys.C | Keys.Control :
                    //MessageBox.Show("2222 ", "");
                    String txt = "";
                    //Clipboard.SetText(Clipboard.GetText());
                    Control ctl = new Control();
                    ctl = GetFocusedControl();
                    txt = ctl.Text;
                    if(ctl is C1FlexGrid)
                    {
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
                    }
                    else if(ctl is C1ComboBox)
                    {
                        C1ComboBox ccc = (C1ComboBox)ctl;
                        Clipboard.SetText(ccc.SelectedText);
                    }
                    else if (ctl is C1TextBox)
                    {
                        C1TextBox ccc = (C1TextBox)ctl;
                        Clipboard.SetText(ccc.SelectedText);
                    }
                        //Application.OpenForms["FrmLabOPUAdd2"].Focus();
                        //var container = control as IContainerControl;
                        //while (container != null)
                        //{
                        //    control = container.ActiveControl;
                        //    container = control as IContainerControl;
                        //}

                        //else if (grf6Focus)
                        //{
                        //    txt = grfDay6[grfDay6.Row, grfDay6.Col].ToString();
                        //}
                        //else if (this.Controls is C1ComboBox)
                        //{
                        //    txt = grfDay6[grfDay6.Row, grfDay6.Col].ToString();
                        //}

                        return true; // signal that we've processed this key
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void TxtEmbryoForEtNO_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if ((e.KeyCode == Keys.Enter))
            {
                if (sender.Equals(txtEmbryoForEtNO))
                {
                    txtEmbryoForEtDay.Focus();
                }
                else if (sender.Equals(txtEmbryoForEtDay))
                {
                    txtEmbryoForEtDate.Focus();
                }
                else if (sender.Equals(txtEmbryoForEtDate))
                {
                    txtEmbryoForEtVolume.Focus();
                }
                else if (sender.Equals(txtEmbryoForEtVolume))
                {
                    txtEmbryoForEtCatheter.Focus();
                }
                else if (sender.Equals(txtEmbryoForEtCatheter))
                {
                    txtEmbryoForEtDoctor.Focus();
                }
                else if (sender.Equals(txtEmbryoForEtDoctor))
                {
                    txtEmbryoForEtNumTran.Focus();
                }
                else if (sender.Equals(txtEmbryoForEtNumTran))
                {
                    txtEmbryoForEtNumFreeze.Focus();
                }
                else if (sender.Equals(txtEmbryoForEtNumFreeze))
                {
                    txtEmbryoForEtAsseted.Focus();
                }
                else if (sender.Equals(txtEmbryoForEtAsseted))
                {
                    //txtRemark.Focus();
                }
            }
        }

        private void TxtEmbryoFreezNoOg0_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if ((e.KeyCode == Keys.Enter))
            {
                if (sender.Equals(txtEmbryoFreezNoOg0))
                {
                    txtEmbryoFreezNoStraw0.Focus();
                }
                else if (sender.Equals(txtEmbryoFreezNoStraw0))
                {
                    txtEmbryoFreezPosi0.Focus();
                }
                else if (sender.Equals(txtEmbryoFreezNoOg1))
                {
                    txtEmbryoFreezNoStraw1.Focus();
                }
                else if (sender.Equals(txtEmbryoFreezNoStraw1))
                {
                    txtEmbryoFreezPosi1.Focus();
                }
            }
        }

        private void TxtSpermDate_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if ((e.KeyCode == Keys.Enter))
            {
                if (sender.Equals(txtSpermDate))
                {
                    txtSpermVol.Focus();
                }
                else if (sender.Equals(txtSpermVol))
                {
                    txtSpermCnt.Focus();
                }
                else if (sender.Equals(txtSpermCnt))
                {
                    //txtSpermTotalCnt.Focus();
                    txtSpermMotility.Focus();
                }
                //else if (sender.Equals(txtSpermTotalCnt))
                //{
                //    txtSpermMoti.Focus();
                //}
                //else if (sender.Equals(txtSpermMoti))
                //{
                //    txtSpermMotiTotal.Focus();
                //}
                //else if (sender.Equals(txtSpermMotiTotal))
                //{
                //    txtSpermMotility.Focus();
                //}
            }
        }
        private Boolean calFertili()
        {
            Boolean re = true;
            int ferti = 0, sum=0, pn2=0,pn1=0,pn3=0,pn4=0,nopn=0, dead=0;
            if(int.TryParse(txtMaturaMii.Text, out ferti))
            {
                int.TryParse(txtFertili2Pn.Text, out pn2);
                int.TryParse(txtFertili1Pn.Text, out pn1);
                int.TryParse(txtFertili3Pn.Text, out pn3);
                int.TryParse(txtFertili4Pn.Text, out pn4);
                int.TryParse(txtFertiliNoPn.Text, out nopn);
                int.TryParse(txtFertiliDead.Text, out dead);
                sum = pn2 + pn1 + pn3 +pn4 + nopn + dead;
                if(ferti != sum)
                {
                    MessageBox.Show("ผลรวมของ Fertili ไม่เท่ากับ Matura MII", "");
                }
                re = false;
            }
            else
            {
                re = false;
                MessageBox.Show("ไม่สามารถหาผลรวมของค่า Fertitli ได้", "");
            }
            return re;
        }
        private void TxtFertiliDate_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if ((e.KeyCode == Keys.Enter))
            {
                if (sender.Equals(txtFertiliDate))
                {
                    txtFertili2Pn.Focus();
                }
                else if (sender.Equals(txtFertili2Pn))
                {
                    //if (chkNoofOPU())
                    //{
                        createEmbryoDev(txtFertili2Pn.Text);

                        setControlFirstTime(true);
                    //}
                    txtFertili1Pn.Focus();
                }
                else if (sender.Equals(txtFertili2PnAdd))
                {
                    //if (chkNoofOPU())
                    //{
                    int chk = 0;
                    int.TryParse(txtFertili2PnAdd.Text, out chk);
                    if (chk > 0)
                    {
                        createEmbryoDevAdd(txtFertili2PnAdd.Text);
                        setGrfAll();
                    }
                    else if(chk<0)
                    {
                        minusEmbryoDev(txtFertili2PnAdd.Text);
                        setGrfAll();
                    }

                    setControlFirstTime(true);
                    //}
                    txtFertili1Pn.Focus();
                }
                else if (sender.Equals(txtFertili1Pn))
                {
                    txtFertili3Pn.Focus();
                }
                else if (sender.Equals(txtFertili3Pn))
                {
                    txtFertili4Pn.Focus();
                }
                else if (sender.Equals(txtFertili4Pn))
                {
                    txtFertiliNoPn.Focus();
                }
                else if (sender.Equals(txtFertiliNoPn))
                {
                    txtFertiliDead.Focus();
                }
                else if (sender.Equals(txtFertiliDead))
                {
                    calFertili();
                }
            }
        }
        private void setTxtmaturaDate()
        {
            DateTime dt = new DateTime();
            if (DateTime.TryParse(txtMaturaDate.Text, out dt))
            {
                txtFertiliDate.Value = dt.AddDays(1);
                txtSpermDate.Value = dt;
                txtDay2Date.Value = dt.AddDays(2);
                txtDay3Date.Value = dt.AddDays(3);
                txtDay5Date.Value = dt.AddDays(5);
                txtDay6Date.Value = dt.AddDays(6);
            }
            txtMaturaMii.Focus();
        }
        private void TxtMaturaDate_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if ((e.KeyCode == Keys.Enter))
            {
                if (sender.Equals(txtMaturaDate))
                {
                    setTxtmaturaDate();
                }
                else if (sender.Equals(txtMaturaMii))
                {
                    calMaturation();
                    txtMaturaMi.Focus();
                }
                else if (sender.Equals(txtMaturaMi))
                {
                    calMaturation();
                    txtMaturaGv.Focus();
                }
                else if (sender.Equals(txtMaturaGv))
                {
                    calMaturation();
                    txtMaturaPostMat.Focus();
                }
                else if (sender.Equals(txtMaturaPostMat))
                {
                    calMaturation();
                    txtMaturaAbnor.Focus();
                }
                else if (sender.Equals(txtMaturaAbnor))
                {
                    calMaturation();
                    txtMaturaDead.Focus();
                }
            }
        }

        private void setClick()
        {
            btnSave.Click += BtnSave_Click;
            btnSaveMatura.Click += BtnSaveMatura_Click;
            btnSaveFertili.Click += BtnSaveFertili_Click;
            btnSaveSperm.Click += BtnSaveSperm_Click;
            btnSaveEmbryoEt.Click += BtnSaveEmbryoEt_Click;
            btnSaveEmbryoFreezDay0.Click += BtnSaveEmbryoFreezDay0_Click;
            btnSaveEmbryoFreezDay1.Click += BtnSaveEmbryoFreezDay1_Click;
            btnSaveDay2.Click += BtnSaveDay2_Click;
            btnSaveDay3.Click += BtnSaveDay3_Click;
            btnSaveDay5.Click += BtnSaveDay5_Click;
            btnSaveDay6.Click += BtnSaveDay6_Click;
            btnPrint.Click += BtnPrint_Click;
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
            btnVoidEmbryo.Click += BtnVoidEmbryo_Click;

            btnHnSearch.Click += BtnHnSearch_Click;
            btnDonorSearch.Click += BtnDonorSearch_Click;
            btnApproveResult.Click += BtnApproveResult_Click;
            btnResultDay1.Click += BtnResultDay1_Click;
            btnResultDay3.Click += BtnResultDay3_Click;
            btnResultDay5.Click += BtnResultDay5_Click;
            btnResultDay1View.Click += BtnResultDay1View;
            btnResultDay3View.Click += BtnResultDay3View_Click;
        }
        
        private void BtnResultDay1View(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.showResultDay(txtID.Text.Trim(),"1",this);
        }
        
        private void BtnVoidEmbryo_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.cStf.staff_id = "";
            FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            frm.ShowDialog(this);
            if (!ic.cStf.staff_id.Equals(""))
            {
                ic.ivfDB.opuEmDevDB.VoidLabOpuEmbryoDevByOPUFET(txtID.Text, ic.cStf.staff_id);
                ic.ivfDB.opuDB.updateFertiliAdd(txtID.Text, "0");
                setGrf();
            }
        }

        private void setKeyPress()
        {
            txtMaturaMii.KeyPress += TxtMaturaMii_KeyPress;
            txtMaturaMi.KeyPress += TxtMaturaMii_KeyPress;
            txtMaturaGv.KeyPress += TxtMaturaMii_KeyPress;
            txtMaturaNoofOpu.KeyPress += TxtMaturaNoofOpu_KeyPress;
            txtMaturaPostMat.KeyPress += TxtMaturaMii_KeyPress;
            txtMaturaAbnor.KeyPress += TxtMaturaMii_KeyPress;
            txtMaturaDead.KeyPress += TxtMaturaMii_KeyPress;

            txtFertili2Pn.KeyPress += TxtMaturaMii_KeyPress;
            txtFertili1Pn.KeyPress += TxtMaturaMii_KeyPress;
            txtFertili3Pn.KeyPress += TxtMaturaMii_KeyPress;
            txtFertili4Pn.KeyPress += TxtMaturaMii_KeyPress;
            txtFertiliNoPn.KeyPress += TxtMaturaMii_KeyPress;
            txtFertiliDead.KeyPress += TxtMaturaMii_KeyPress;

            txtSpermVol.KeyPress += TxtMaturaMii_KeyPress;
            txtSpermCnt.KeyPress += TxtMaturaMii_KeyPress;
            txtSpermTotalCnt.KeyPress += TxtMaturaMii_KeyPress;
            txtSpermMoti.KeyPress += TxtMaturaMii_KeyPress;
            txtSpermMotiTotal.KeyPress += TxtMaturaMii_KeyPress;
            txtSpermMotility.KeyPress += TxtMaturaMii_KeyPress;

            txtEmbryoFreezNoOg0.KeyPress += TxtMaturaMii_KeyPress;
            txtEmbryoFreezNoStraw0.KeyPress += TxtMaturaMii_KeyPress;
            txtEmbryoFreezNoOg1.KeyPress += TxtMaturaMii_KeyPress;
            txtEmbryoFreezNoStraw1.KeyPress += TxtMaturaMii_KeyPress;
            txtFertili1Pn.KeyPress += TxtMaturaMii_KeyPress;
            txtFertili1Pn.KeyPress += TxtMaturaMii_KeyPress;
            txtFertili1Pn.KeyPress += TxtMaturaMii_KeyPress;
            txtSpermVol.KeyUp += TxtSpermVol_KeyUp;
            txtSpermCnt.KeyUp += TxtSpermCnt_KeyUp;
            txtSpermMotility.KeyUp += TxtSpermMotility_KeyUp;
        }

        private void TxtSpermMotility_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calMotile();
        }

        private void TxtSpermCnt_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calSperm();
            calMotile();
        }

        private void TxtSpermVol_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calSperm();
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

        private void TabDay6_DoubleClick(object sender, EventArgs e)
        {
            if (grfDay6Img == null)
            {
                MessageBox.Show("ยังไม่ได้เลือก ลำดับ row", "");
                return;
            }
            //throw new NotImplementedException();
            //if (flagDay6Img)
            //{
            //    MessageBox.Show("ได้เคยนำเข้าแล้ว กรุณานำเข้าที่ละรายการ", "");
            //    return;
            //}
            if (grfDay6Img.Row <= 0)
            {
                MessageBox.Show("ลำดับ row ไม่ถูกต้อง", "");
                return;
            }
            int row = 0;
            row = grfDay6Img.Row - 1;
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
                //int ii = 0;
                int ii = row;
                foreach (String file in ofd.FileNames)
                {
                    // Create a PictureBox.
                    try
                    {
                        Image loadedImage, resizedImage;
                        String ext = Path.GetExtension(file);
                        String ex = "";
                        //if (sur.Length == 2)
                        //{
                        //    ex = sur[1];
                        //}
                        if (!ext.ToLower().Equals(".pdf"))
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

                        String id = grfDay6Img[ii, colDay2ImgId] != null ? grfDay6Img[ii, colDay2ImgId].ToString() : "";
                        String desc = grfDay6Img[ii, colDay2ImgDesc0] != null ? grfDay6Img[ii, colDay2ImgDesc0].ToString() : "";
                        String no = grfDay6Img[ii, colDay2ImgNun] != null ? grfDay6Img[ii, colDay2ImgNun].ToString() : "";
                        String desc1 = grfDay6Img[ii, colDay2ImgDesc1] != null ? grfDay6Img[ii, colDay2ImgDesc1].ToString() : "";
                        String path = grfDay6Img[ii, colDay2PathPic] != null ? grfDay6Img[ii, colDay2PathPic].ToString() : "";
                        if (id.Equals("")) continue;
                        if (no.Length > 0)
                        {
                            String filename = "";

                            filename = txtOpuCode.Text + "_day6_" + no + ext;
                            String re = ic.ivfDB.opuEmDevDB.updatePathPic(id, no, ic.iniC.folderFTP + "/" + txtOpuCode.Text + "/" + filename, desc, desc1, ic.cStf.staff_id);
                            long chk = 0;
                            if (long.TryParse(re, out chk))
                            {
                                if (File.Exists(path))       // -0012
                                {       // -0012
                                    ic.savePicOPUtoServer(txtOpuCode.Text, filename, path);       // -0012
                                }
                            }
                        }

                        i++;
                        //frmW.pB.Value = i;
                    }
                    catch (System.Security.SecurityException ex)
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

        private void TabDay5_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfDay5Img == null)
            {
                MessageBox.Show("ยังไม่ได้เลือก ลำดับ row", "");
                return;
            }
            //if (flagDay5Img)
            //{
            //    MessageBox.Show("ได้เคยนำเข้าแล้ว กรุณานำเข้าที่ละรายการ", "");
            //    return;
            //}
            if (grfDay5Img.Row <= 0)
            {
                MessageBox.Show("ลำดับ row ไม่ถูกต้อง", "");
                return;
            }
            int row = 0;
            row = grfDay5Img.Row - 1;
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
                //int ii = 0;
                int ii = row;
                foreach (String file in ofd.FileNames)
                {
                    // Create a PictureBox.
                    try
                    {
                        Image loadedImage, resizedImage;
                        String ext = Path.GetExtension(file);
                        String ex = "";
                        //if (sur.Length == 2)
                        //{
                        //    ex = sur[1];
                        //}
                        if (!ext.ToLower().Equals(".pdf"))
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

                        String id = grfDay5Img[ii, colDay2ImgId] != null ? grfDay5Img[ii, colDay2ImgId].ToString() : "";
                        String desc = grfDay5Img[ii, colDay2ImgDesc0] != null ? grfDay5Img[ii, colDay2ImgDesc0].ToString() : "";
                        String no = grfDay5Img[ii, colDay2ImgNun] != null ? grfDay5Img[ii, colDay2ImgNun].ToString() : "";
                        String desc1 = grfDay5Img[ii, colDay2ImgDesc1] != null ? grfDay5Img[ii, colDay2ImgDesc1].ToString() : "";
                        String path = grfDay5Img[ii, colDay2PathPic] != null ? grfDay5Img[ii, colDay2PathPic].ToString() : "";
                        if (id.Equals("")) continue;
                        if (no.Length > 0)
                        {
                            String filename = "";

                            filename = txtOpuCode.Text + "_day5_" + no + ext;
                            String re = ic.ivfDB.opuEmDevDB.updatePathPic(id, no, ic.iniC.folderFTP + "/" + txtOpuCode.Text + "/" + filename, desc, desc1, ic.cStf.staff_id);
                            long chk = 0;
                            if (long.TryParse(re, out chk))
                            {
                                if (File.Exists(path))       // -0012
                                {       // -0012
                                    ic.savePicOPUtoServer(txtOpuCode.Text, filename, path);       // -0012
                                }
                            }
                        }

                        i++;
                        //frmW.pB.Value = i;
                    }
                    catch (System.Security.SecurityException ex)
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
        private void BtnDonorSearch_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.sVsOld.PIDS = "";
            ic.sVsOld.PName = "";
            FrmSearchHn frm = new FrmSearchHn(ic, FrmSearchHn.StatusConnection.hostEx, FrmSearchHn.StatusSearch.DonorSearch, FrmSearchHn.StatusSearchTable.VisitSearch);
            frm.ShowDialog(this);
            txtHnDonor.Value = ic.sVsOld.PIDS;
            txtNameDonor.Value = ic.sVsOld.PName;
        }
        private void BtnHnSearch_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.sVsOld.PIDS = "";
            ic.sVsOld.PName = "";
            FrmSearchHn frm = new FrmSearchHn(ic, FrmSearchHn.StatusConnection.host, FrmSearchHn.StatusSearch.PttSearch, FrmSearchHn.StatusSearchTable.PttSearch);
            frm.ShowDialog(this);
            txtHnMale.Value = ic.sVsOld.PIDS;
            txtNameMale.Value = ic.sVsOld.PName;
        }

        private void TxtMaturaNoofOpu_KeyPress(object sender, KeyPressEventArgs e)
        {
            //throw new NotImplementedException();
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as C1TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void TxtMaturaMii_KeyPress(object sender, KeyPressEventArgs e)
        {
            //throw new NotImplementedException();
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as C1TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '-') && ((sender as C1TextBox).Text.Length == 0))
            {
                e.Handled = false;
            }
            //if ((sender == txtSpermVol) || (sender == txtSpermCnt))
            //{
            //    calSperm();
            //}
            //if ((sender == txtSpermMotility) || (sender == txtSpermCnt))
            //{
            //    calMotile();
            //}
        }
        private void calSperm()
        {
            Decimal vol = 0, cnt = 0, total = 0;
            Decimal.TryParse(txtSpermVol.Text, out vol);
            Decimal.TryParse(txtSpermCnt.Text, out cnt);
            //int.TryParse(txtSpermVol.Text, out vol);
            total = vol * cnt;
            int chk = 0;
            //if(int.TryParse(total.ToString(), out chk))
            //{
            //    txtSpermTotalCnt.Value = chk;
            //}
            //else
            //{
            //    txtSpermTotalCnt.Value = Decimal.ToInt32(total);
            //}
            txtSpermTotalCnt.Value = Math.Round(total,2);
        }
        private void calMotile()
        {
            Decimal motility = 0, cnt = 0, total = 0, vol=0, motile=0;
            Decimal.TryParse(txtSpermVol.Text, out vol);
            Decimal.TryParse(txtSpermMotility.Text, out motility);
            Decimal.TryParse(txtSpermCnt.Text, out cnt);
            //int.TryParse(txtSpermVol.Text, out vol);
            motile = (motility * cnt) / 100;
            total = motile * vol;
            //txtSpermMoti.Value = motile.ToString().Replace(".0","");
            //txtSpermMotiTotal.Value = total.ToString().Replace(".0", "");
            txtSpermMoti.Value = Math.Round(motile, 2);
            txtSpermMotiTotal.Value = Math.Round(total, 2);
        }
        private Boolean chkNoofOPU()
        {
            Boolean chk = true;
            String txt = "";
            try
            {
                String[] ext = txtMaturaNoofOpu1.Text.Split(',');
                int rt = 0, lt = 0;
                if (!int.TryParse(ext[0], out rt))
                {
                    chk = false;
                    txt += "Rt ไม่ถูกต้อง ";
                }
                if (!int.TryParse(ext[1], out lt))
                {
                    chk = false;
                    txt += "Lt ไม่ถูกต้อง ";
                }
                if (!chk)
                {
                    MessageBox.Show("ข้อมูล No of OPU ไม่ถูกต้อง \n" + txt, "");
                }
            }
            catch (Exception ex)
            {
                chk = false;
            }
            return chk;
        }
        private void createEmbryoDevClear(String num)
        {
            int rt = 0, lt = 0, cntDay2 = 0, embryoNo = 0;
            //if (int.TryParse(ext[0], out rt))
            //{
            if (int.TryParse(num, out embryoNo))
            {
                //embryoNo = txtFertili2Pn.Text;
                //txtMaturaNoofOpu.Value = embryoNo.ToString() + "["+ txtMaturaNoofOpu1.Text+"]";
                String cnt = "", re = "";
                cnt = ic.ivfDB.opuEmDevDB.selectCntByOpuFetId_Day(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day2);
                if (int.TryParse(cnt, out cntDay2))
                {
                    //if (cntDay2 < embryoNo)
                    //{
                    //    int aaa = 0;
                    //    aaa = embryoNo - cntDay2;
                    //    if (aaa > 0)
                    //    {
                    Boolean chkSave = false;
                    if (MessageBox.Show("ต้องการ  Embryo Development new จำนวน " + embryoNo + " Embryo ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                    {
                        ic.cStf.staff_id = "";
                        //FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                        //frm.ShowDialog(this);
                        //if (!ic.cStf.staff_id.Equals(""))
                        //{
                            FrmWaiting frmW = new FrmWaiting();
                            frmW.Show();
                            try
                            {
                                setOPUMatura();
                                re = ic.ivfDB.opuDB.updateMatura(opu, ic.user.staff_id);

                                frmW.pB.Minimum = 1;
                                frmW.pB.Maximum = embryoNo;
                                for (int i = 1; i <= embryoNo; i++)
                                {
                                    LabOpuEmbryoDev opuEmDev = new LabOpuEmbryoDev();
                                    opuEmDev.opu_embryo_dev_id = "";
                                    opuEmDev.opu_fet_id = txtID.Text;
                                    opuEmDev.opu_embryo_dev_no = (cntDay2 + i).ToString();
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
                                    long chk = 0;
                                    if (long.TryParse(re, out chk))
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
                        //}
                        ic.ivfDB.opuDB.updateFertiliAdd(txtID.Text, embryoNo.ToString());
                    }
                    //}

                    //}
                }
            }
        }
        private void minusEmbryoDev(String num)
        {
            int rt = 0, lt = 0, cntDay2 = 0, embryoNo = 0;
            if (int.TryParse(num, out embryoNo))
            {
                String cnt = "", re = "";
                cnt = ic.ivfDB.opuEmDevDB.VoidLabOpuEmbryoDevMax(txtID.Text, ic.user.staff_id);
            }
        }
        private void createEmbryoDevAdd(String num)
        {
            int rt = 0, lt = 0, cntDay2 = 0, embryoNo = 0;
            //if (int.TryParse(ext[0], out rt))
            //{
            if (int.TryParse(num, out embryoNo))
            {
                //embryoNo = txtFertili2Pn.Text;
                //txtMaturaNoofOpu.Value = embryoNo.ToString() + "["+ txtMaturaNoofOpu1.Text+"]";
                String cnt = "", re = "";
                cnt = ic.ivfDB.opuEmDevDB.selectCntByOpuFetId_Day(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day2);
                if (int.TryParse(cnt, out cntDay2))
                {
                    //if (cntDay2 < embryoNo)
                    //{
                    //    int aaa = 0;
                    //    aaa = embryoNo - cntDay2;
                    //    if (aaa > 0)
                    //    {
                            Boolean chkSave = false;
                            if (MessageBox.Show("ต้องการ ให้เพิ่ม Embryo Development จำนวน " + embryoNo + " Embryo ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                            {
                                ic.cStf.staff_id = "";
                                //FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                                //frm.ShowDialog(this);
                                //if (!ic.cStf.staff_id.Equals(""))
                                //{
                                    FrmWaiting frmW = new FrmWaiting();
                                    frmW.Show();
                                    try
                                    {
                                        setOPUMatura();
                                        re = ic.ivfDB.opuDB.updateMatura(opu, ic.user.staff_id);

                                        frmW.pB.Minimum = 1;
                                        frmW.pB.Maximum = embryoNo;
                                        for (int i = 1; i <= embryoNo; i++)
                                        {
                                    String staff_id = "", check_id = "", dateday3 = "";
                                    LabOpuEmbryoDev opuEmDev = new LabOpuEmbryoDev();
                                            opuEmDev.opu_embryo_dev_id = "";
                                            opuEmDev.opu_fet_id = txtID.Text;
                                            opuEmDev.opu_embryo_dev_no = (cntDay2 + i).ToString();
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
                                    staff_id = cboEmbryologistDay2.SelectedItem == null ? "" : ((ComboBoxItem)cboEmbryologistDay2.SelectedItem).Value;
                                    opuEmDev.staff_id = staff_id;
                                    check_id = cboCheckedDay2.SelectedItem == null ? "" : ((ComboBoxItem)cboCheckedDay2.SelectedItem).Value;
                                    opuEmDev.checked_id = check_id;
                                    DateTime dtday3 = new DateTime();
                                    if (DateTime.TryParse(txtDay2Date.Text, out dtday3))
                                    {
                                        dateday3 = ic.dateTimetoDB1(dtday3);
                                    }
                                    dateday3 = ic.dateTimetoDB1(dtday3);
                                    opuEmDev.embryo_dev_date = dateday3;
                                    opuEmDev.day = "2";
                                            re = ic.ivfDB.opuEmDevDB.insertLabOpuEmbryoDev(opuEmDev, ic.cStf.staff_id);

                                    staff_id = cboEmbryologistDay3.SelectedItem == null ? "" : ((ComboBoxItem)cboEmbryologistDay3.SelectedItem).Value;
                                    opuEmDev.staff_id = staff_id;
                                    check_id = cboCheckedDay3.SelectedItem == null ? "" : ((ComboBoxItem)cboCheckedDay3.SelectedItem).Value;
                                    opuEmDev.checked_id = check_id;
                                    //DateTime dtday3 = new DateTime();
                                    if (DateTime.TryParse(txtDay3Date.Text, out dtday3))
                                    {
                                        dateday3 = ic.dateTimetoDB1(dtday3);
                                    }
                                    dateday3 = ic.dateTimetoDB1(dtday3);
                                    opuEmDev.embryo_dev_date = dateday3;
                                    opuEmDev.day = "3";
                                            re = ic.ivfDB.opuEmDevDB.insertLabOpuEmbryoDev(opuEmDev, ic.cStf.staff_id);

                                    staff_id = cboEmbryologistDay5.SelectedItem == null ? "" : ((ComboBoxItem)cboEmbryologistDay5.SelectedItem).Value;
                                    opuEmDev.staff_id = staff_id;
                                    check_id = cboCheckedDay5.SelectedItem == null ? "" : ((ComboBoxItem)cboCheckedDay5.SelectedItem).Value;
                                    opuEmDev.checked_id = check_id;
                                    //DateTime dtday3 = new DateTime();
                                    if (DateTime.TryParse(txtDay5Date.Text, out dtday3))
                                    {
                                        dateday3 = ic.dateTimetoDB1(dtday3);
                                    }
                                    dateday3 = ic.dateTimetoDB1(dtday3);
                                    opuEmDev.embryo_dev_date = dateday3;
                                    opuEmDev.day = "5";
                                            re = ic.ivfDB.opuEmDevDB.insertLabOpuEmbryoDev(opuEmDev, ic.cStf.staff_id);

                                    staff_id = cboEmbryologistDay6.SelectedItem == null ? "" : ((ComboBoxItem)cboEmbryologistDay6.SelectedItem).Value;
                                    opuEmDev.staff_id = staff_id;
                                    check_id = cboCheckedDay6.SelectedItem == null ? "" : ((ComboBoxItem)cboCheckedDay6.SelectedItem).Value;
                                    opuEmDev.checked_id = check_id;
                                    //DateTime dtday3 = new DateTime();
                                    if (DateTime.TryParse(txtDay6Date.Text, out dtday3))
                                    {
                                        dateday3 = ic.dateTimetoDB1(dtday3);
                                    }
                                    dateday3 = ic.dateTimetoDB1(dtday3);
                                    opuEmDev.embryo_dev_date = dateday3;
                                    opuEmDev.day = "6";
                                            re = ic.ivfDB.opuEmDevDB.insertLabOpuEmbryoDev(opuEmDev, ic.cStf.staff_id);
                                            long chk = 0;
                                            if (long.TryParse(re, out chk))
                                            {
                                                chkSave = true;
                                                //MessageBox.Show("Error", "");
                                            }
                                            else
                                            {
                                                chkSave = false;
                                            }
                                    String re2 = ic.ivfDB.opuDB.updateRemarkDay2(txtID.Text, cboRemarkDay2.Text);
                                    String re3 = ic.ivfDB.opuDB.updateRemarkDay3(txtID.Text, cboRemarkDay3.Text);
                                    String re5 = ic.ivfDB.opuDB.updateRemarkDay5(txtID.Text, cboRemarkDay5.Text);
                                    String re6 = ic.ivfDB.opuDB.updateRemarkDay6(txtID.Text, cboRemarkDay6.Text);
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
                                    setGrfAll();
                                //}
                        ic.ivfDB.opuDB.updateFertiliAdd(txtID.Text, embryoNo.ToString());
                            }
                        //}

                    //}
                }
            }
        }
        private void setGrfAll()
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
        private void createEmbryoDev(String num)
        {
            //String[] ext = txtMaturaNoofOpu1.Text.Split(',');
            int rt = 0, lt = 0, cntDay2 = 0, embryoNo = 0;
            //if (int.TryParse(ext[0], out rt))
            //{
            if (int.TryParse(num, out embryoNo))
            {
                //embryoNo = txtFertili2Pn.Text;
                    //txtMaturaNoofOpu.Value = embryoNo.ToString() + "["+ txtMaturaNoofOpu1.Text+"]";
                    String cnt = "", re = "";
                cnt = ic.ivfDB.opuEmDevDB.selectCntByOpuFetId_Day(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day2);
                if (int.TryParse(cnt, out cntDay2))
                {
                    if (cntDay2 <  embryoNo)
                    {
                        int aaa = 0;
                        aaa = embryoNo - cntDay2;
                        if (aaa > 0)
                        {
                            Boolean chkSave = false;
                            if (MessageBox.Show("ต้องการ ให้เพิ่ม Embryo Development จำนวน " + aaa + " Embryo ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                            {
                                ic.cStf.staff_id = "";
                                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                                //frm.ShowDialog(this);
                                //if (!ic.cStf.staff_id.Equals(""))
                                //{
                                    FrmWaiting frmW = new FrmWaiting();
                                    frmW.Show();
                                    try
                                    {
                                        setOPUMatura();
                                        re = ic.ivfDB.opuDB.updateMatura(opu, ic.user.staff_id);

                                        frmW.pB.Minimum = 1;
                                        frmW.pB.Maximum = aaa;
                                        for (int i = 1; i <= aaa; i++)
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
                                            long chk = 0;
                                            if (long.TryParse(re, out chk))
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
                                //}
                                ic.ivfDB.opuDB.updateFertili(txtID.Text, embryoNo.ToString());
                                ic.ivfDB.opuDB.updateFertiliAdd(txtID.Text, "0");
                            }
                        }

                    }
                }
            }
            //}

        }
        private void TxtMaturaNoofOpu_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.Enter)
            {
                if (chkNoofOPU())
                {
                    int rt = 0, lt = 0, embryoNo = 0;
                    String[] ext = txtMaturaNoofOpu1.Text.Split(',');
                    int.TryParse(ext[0], out rt);
                    int.TryParse(ext[1], out lt);
                    embryoNo = rt + lt;
                    //txtMaturaNoofOpu.Value = embryoNo.ToString() + "[" + txtMaturaNoofOpu1.Text + "]";
                    txtMaturaNoofOpu.Value = embryoNo.ToString() + "[Rt=" + rt + ",Lt=" + lt + "]";
                    //    createEmbryoDev();

                    //    setControlFirstTime(true);
                }
                txtMaturaDate.Focus();
            }
        }

        private void BtnPrintOpuEmbryoDev_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmLabOPUPrint frm = new FrmLabOPUPrint(ic, txtID.Text, FrmLabOPUPrint.opuReport.OPUEmbryoDevReport);
            frm.ShowDialog(this);
        }

        private void BtnDay6ImgRef_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            grfDay6Img.AutoSizeCols();
            grfDay6Img.AutoSizeRows();
        }

        private void BtnSaveImg6_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //if (MessageBox.Show("ต้องการ บันทึกช้อมูล Day 6 Embryo Development  ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            //ic.cStf.staff_id = "";
            //FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            //frm.ShowDialog(this);
            Boolean chkSave = false;
            ic.cStf.staff_id = ic.userId;
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
                        String desc1 = row[colDay2ImgDesc1] != null ? row[colDay2ImgDesc1].ToString() : "";
                        String statusBio = row[colDay2StatusBio] == imgFinish ? "1" : "0";
                        String statusEdit = row[colDay2ImgEdit] != null ? row[colDay2ImgEdit].ToString() : "";
                        i++;
                        if (i == 1) continue;
                        if (statusEdit.Length <= 0) continue;
                        if (!id.Equals(""))
                        {
                            if (no.Length > 0)
                            {
                                String filename = "";
                                String[] ext = path.Split('.');
                                if (ext.Length > 1)
                                {
                                    filename = txtOpuCode.Text + "_day6_" + no + "." + ext[ext.Length - 1];
                                    //re = ic.ivfDB.opuEmDevDB.updatePathPic(id, no, ic.iniC.folderFTP + "/" + txtOpuCode.Text + "/" + filename, desc, desc1, ic.cStf.staff_id);       // -0012
                                    re = ic.ivfDB.opuEmDevDB.updatePathPicNoPic(id, no, desc, desc1, ic.cStf.staff_id, statusBio);       // +0012
                                    long chk = 0;
                                    if (long.TryParse(re, out chk))
                                    {
                                        //if (File.Exists(path))       // -0012
                                        //    ic.savePicOPUtoServer(txtOpuCode.Text, filename, path);       // -0012
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
            //}
        }

        private void BtnDay5ImgRef_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            grfDay5Img.AutoSizeCols();
            grfDay5Img.AutoSizeRows();
        }

        private void BtnSaveImg5_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //if (MessageBox.Show("ต้องการ บันทึกช้อมูล Day 5 Embryo Development  ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
                Boolean chkSave = false;
                //ic.cStf.staff_id = "";
                //FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                //frm.ShowDialog(this);
            ic.cStf.staff_id = ic.userId;
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
                        String desc1 = row[colDay2ImgDesc1] != null ? row[colDay2ImgDesc1].ToString() : "";
                        String statusBio = row[colDay2StatusBio] == imgFinish ? "1" : "0";
                        String statusEdit = row[colDay2ImgEdit] != null ? row[colDay2ImgEdit].ToString() : "";
                        i++;
                        if (i == 1) continue;
                        if (statusEdit.Length <= 0) continue;
                        if (!id.Equals(""))
                        {
                            if (no.Length > 0)
                            {
                                String filename = "";
                                String[] ext = path.Split('.');
                                if (ext.Length > 1)
                                {
                                    filename = txtOpuCode.Text + "_day5_" + no + "." + ext[ext.Length - 1];
                                    //re = ic.ivfDB.opuEmDevDB.updatePathPic(id, no, ic.iniC.folderFTP + "/" + txtOpuCode.Text + "/" + filename, desc, desc1, ic.cStf.staff_id);       // -0012
                                    re = ic.ivfDB.opuEmDevDB.updatePathPicNoPic(id, no, desc, desc1, ic.cStf.staff_id, statusBio);       // +0012
                                    long chk = 0;
                                    if (long.TryParse(re, out chk))
                                    {
                                        //if (File.Exists(path))       // -0012
                                        //    ic.savePicOPUtoServer(txtOpuCode.Text, filename, path);       // -0012
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
            //}
        }

        private void BtnSaveImg3_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //if (MessageBox.Show("ต้องการ บันทึกช้อมูล Day 3 Embryo Development  ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
                Boolean chkSave = false;
                //ic.cStf.staff_id = "";
                //FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                //frm.ShowDialog(this);
            ic.cStf.staff_id = ic.userId;
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
                        String desc1 = row[colDay2ImgDesc1] != null ? row[colDay2ImgDesc1].ToString() : "";
                        String statusBio = row[colDay2StatusBio] == imgFinish ? "1" : "0";
                        String statusEdit = row[colDay2ImgEdit] != null ? row[colDay2ImgEdit].ToString() : "";
                        i++;
                        if (i == 1) continue;
                        if (statusEdit.Length <= 0) continue;
                        if (!id.Equals(""))
                        {
                            if (no.Length > 0)
                            {
                                String filename = "";
                                String[] ext = path.Split('.');
                                if (ext.Length > 1)
                                {
                                    filename = txtOpuCode.Text + "_day3_" + no + "." + ext[ext.Length - 1];
                                    //re = ic.ivfDB.opuEmDevDB.updatePathPic(id, no, ic.iniC.folderFTP + "/" + txtOpuCode.Text + "/" + filename, desc, desc1, ic.cStf.staff_id);       // -0012
                                    re = ic.ivfDB.opuEmDevDB.updatePathPicNoPic(id, no, desc, desc1, ic.cStf.staff_id, statusBio);       // +0012
                                    long chk = 0;
                                    if (long.TryParse(re, out chk))
                                    {
                                        //if (File.Exists(path))       // -0012
                                        //{       // -0012
                                        //    ic.savePicOPUtoServer(txtOpuCode.Text, filename, path);       // -0012
                                        //}       // -0012
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
            //}
        }

        private void BtnDay3ImgRef_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            grfDay3Img.AutoSizeCols();
            grfDay3Img.AutoSizeRows();
        }

        private void TabDay3_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfDay3Img == null)
            {
                MessageBox.Show("ยังไม่ได้เลือก ลำดับ row", "");
                return;
            }
            //if (flagDay3Img)
            //{
            //    MessageBox.Show("ได้เคยนำเข้าแล้ว กรุณานำเข้าที่ละรายการ", "");
            //    return;
            //}
            if (grfDay3Img.Row <= 0)
            {
                MessageBox.Show("ลำดับ row ไม่ถูกต้อง", "");
                return;
            }
            int row = 0;
            row = grfDay3Img.Row - 1;
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
                int ii = row;
                foreach (String file in ofd.FileNames)
                {
                    // Create a PictureBox.
                    try
                    {
                        Image loadedImage, resizedImage;
                        String ext = Path.GetExtension(file);
                        String ex = "";
                        //if (sur.Length == 2)
                        //{
                        //    ex = sur[1];
                        //}
                        if (!ext.ToLower().Equals(".pdf"))
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

                        String id = grfDay3Img[ii, colDay2ImgId] != null ? grfDay3Img[ii, colDay2ImgId].ToString() : "";
                        String desc = grfDay3Img[ii, colDay2ImgDesc0] != null ? grfDay3Img[ii, colDay2ImgDesc0].ToString() : "";
                        String no = grfDay3Img[ii, colDay2ImgNun] != null ? grfDay3Img[ii, colDay2ImgNun].ToString() : "";
                        String desc1 = grfDay3Img[ii, colDay2ImgDesc1] != null ? grfDay3Img[ii, colDay2ImgDesc1].ToString() : "";
                        String path = grfDay3Img[ii, colDay2PathPic] != null ? grfDay3Img[ii, colDay2PathPic].ToString() : "";
                        if (id.Equals("")) continue;
                        if (no.Length > 0)
                        {
                            String filename = "";

                            filename = txtOpuCode.Text + "_day3_" + no + ext;
                            String re = ic.ivfDB.opuEmDevDB.updatePathPic(id, no, ic.iniC.folderFTP + "/" + txtOpuCode.Text + "/" + filename, desc, desc1, ic.cStf.staff_id);
                            long chk = 0;
                            if (long.TryParse(re, out chk))
                            {
                                if (File.Exists(path))       // -0012
                                {       // -0012
                                    ic.savePicOPUtoServer(txtOpuCode.Text, filename, path);       // -0012
                                }
                            }
                        }

                        i++;
                    }
                    catch (System.Security.SecurityException ex)
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

        private void BtnDay2ImgRef_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            grfDay2Img.AutoSizeCols();
            grfDay2Img.AutoSizeRows();
        }

        private void BtnSaveImg2_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //if (MessageBox.Show("ต้องการ บันทึกช้อมูล Day 2 Embryo Development  ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
                Boolean chkSave = false;
                //ic.cStf.staff_id = "";
                //FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                //frm.ShowDialog(this);
            ic.cStf.staff_id = ic.userId;
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
                        String desc1 = row[colDay2ImgDesc1] != null ? row[colDay2ImgDesc1].ToString() : "";
                        String statusBio = row[colDay2StatusBio] == imgFinish ? "1" : "0";
                        String statusEdit = row[colDay2ImgEdit] != null ? row[colDay2ImgEdit].ToString() : "";
                        i++;
                        if (i == 1) continue;
                        if (statusEdit.Length<=0) continue;
                        if (!id.Equals(""))
                        {
                            if (no.Length > 0)
                            {
                                String filename = "";
                                String[] ext = path.Split('.');
                                if (ext.Length > 1)
                                {
                                    filename = txtOpuCode.Text + "_day2_" + no + "." + ext[ext.Length - 1];
                                    //re = ic.ivfDB.opuEmDevDB.updatePathPic(id, no, ic.iniC.folderFTP + "/" + txtOpuCode.Text + "/" + filename, desc, desc1, ic.cStf.staff_id);       // -0012
                                    re = ic.ivfDB.opuEmDevDB.updatePathPicNoPic(id, no, desc, desc1, ic.cStf.staff_id, statusBio);       // +0012
                                    long chk = 0;
                                    if (long.TryParse(re, out chk))
                                    {
                                        //if (File.Exists(path))           // -0012
                                        //ic.savePicOPUtoServer(txtOpuCode.Text, filename, path);       // -0012
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
            //}
        }

        private void TabDay2_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //if (flagDay2Img)
            //{
            //    MessageBox.Show("ได้เคยนำเข้าแล้ว กรุณานำเข้าที่ละรายการ", ""); day copy image day 5  st#
            //    return;
            //}
            if (grfDay2Img == null)
            {
                MessageBox.Show("ยังไม่ได้เลือก ลำดับ row", "");
                return;
            }
            if (grfDay2Img.Row <=0 )
            {
                MessageBox.Show("ลำดับ row ไม่ถูกต้อง", "");
                return;
            }
            int row = 0;
            row = grfDay2Img.Row - 1;

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
                //int ii = 0;
                int ii = row;
                foreach (String file in ofd.FileNames)
                {
                    // Create a PictureBox.
                    try
                    {
                        if (ii > grfDay2Img.Rows.Count) break;
                        Image loadedImage, resizedImage;
                        String ext = Path.GetExtension(file);
                        String ex = "";
                        //if (sur.Length == 2)
                        //{
                        //    ex = sur[1];
                        //}
                        if (!ext.ToLower().Equals(".pdf"))
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

                        String id = grfDay2Img[ii, colDay2ImgId] != null ? grfDay2Img[ii, colDay2ImgId].ToString() : "";
                        String desc = grfDay2Img[ii, colDay2ImgDesc0] != null ? grfDay2Img[ii, colDay2ImgDesc0].ToString() : "";
                        String no = grfDay2Img[ii, colDay2ImgNun] != null ? grfDay2Img[ii, colDay2ImgNun].ToString() : "";
                        String desc1 = grfDay2Img[ii, colDay2ImgDesc1] != null ? grfDay2Img[ii, colDay2ImgDesc1].ToString() : "";
                        String path = grfDay2Img[ii, colDay2PathPic] != null ? grfDay2Img[ii, colDay2PathPic].ToString() : "";
                        if (id.Equals("")) continue;
                        if (no.Length > 0)
                        {
                            String filename = "";

                            filename = txtOpuCode.Text + "_day2_" + no + ext;
                            String re = ic.ivfDB.opuEmDevDB.updatePathPic(id, no, ic.iniC.folderFTP + "/" + txtOpuCode.Text + "/" + filename, desc, desc1, ic.cStf.staff_id);
                            long chk = 0;
                            if (long.TryParse(re, out chk))
                            {
                                if (File.Exists(path))       // -0012
                                {       // -0012
                                    ic.savePicOPUtoServer(txtOpuCode.Text, filename, path);       // -0012
                                }
                            }
                        }

                        i++;
                        //frmW.pB.Value = i;
                    }
                    catch (System.Security.SecurityException ex)
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
            String re4 = ic.ivfDB.opuDB.updateRemarkDay6(txtID.Text, cboRemarkDay6.Text);
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
        private void BtnSaveDay6_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //if (MessageBox.Show("ต้องการ บันทึกช้อมูล Day 6 Embryo Development  ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            ic.cStf.staff_id = "";
            Boolean chkSave = false;
            //FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            //frm.ShowDialog(this);
            //if (!ic.cStf.staff_id.Equals(""))
            //{
                chkSave = saveDay6();
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
                
            //}
            //}
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
            String re4 = ic.ivfDB.opuDB.updateRemarkDay5(txtID.Text, cboRemarkDay5.Text);
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
                    opuEmDev.staff_id = staff_id;
                    opuEmDev.checked_id = check_id;
                    opuEmDev.embryo_dev_date = dateday5;
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
        private void BtnSaveDay5_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //if (MessageBox.Show("ต้องการ บันทึกช้อมูล Day 5 Embryo Development  ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            ic.cStf.staff_id = "";
            Boolean chkSave = false;
            //FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            //frm.ShowDialog(this);
            //if (!ic.cStf.staff_id.Equals(""))
            //{
                chkSave = saveDay5();
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
                
            //}
            //}
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
            String re4 = ic.ivfDB.opuDB.updateRemarkDay3(txtID.Text, cboRemarkDay3.Text);
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
        private void BtnSaveDay3_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //if (MessageBox.Show("ต้องการ บันทึกช้อมูล Day 3 Embryo Development  ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            ic.cStf.staff_id = "";
            Boolean chkSave = false;
            //FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            //frm.ShowDialog(this);
            //if (!ic.cStf.staff_id.Equals(""))
            //{
                chkSave = saveDay3();
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
                
            //}
            //}
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
            String re4 = ic.ivfDB.opuDB.updateRemarkDay2(txtID.Text, cboRemarkDay2.Text);
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
        private void BtnSaveDay2_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //if (MessageBox.Show("ต้องการ บันทึกช้อมูล Day 2 Embryo Development  ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            //ic.cStf.staff_id = "";
            //FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            //frm.ShowDialog(this);
            Boolean chkSave = false;
            ic.cStf.staff_id = ic.userId;
            if (!ic.cStf.staff_id.Equals(""))
            {
                chkSave = saveDay2();

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
                
            }
            //}
        }

        private void BtnSaveEmbryoFreezDay1_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //if (MessageBox.Show("ต้องการ บันทึกช้อมูล Embryo for Freezing Day1 ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            //ic.cStf.staff_id = "";
            //FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            //frm.ShowDialog(this);
            ic.cStf.staff_id = ic.userId;
            if (!ic.cStf.staff_id.Equals(""))
            {
                setOPUEmbryoFreezDay1();
                String re = ic.ivfDB.opuDB.updateEmbryoFreezDay1(opu, ic.user.staff_id);
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
            //}
        }

        private void BtnSaveEmbryoFreezDay0_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //if (MessageBox.Show("ต้องการ บันทึกช้อมูล Embryo for Freezing Day0 ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            //ic.cStf.staff_id = "";
            //FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            //frm.ShowDialog(this);
            ic.cStf.staff_id = ic.userId;
            if (!ic.cStf.staff_id.Equals(""))
            {
                setOPUEmbryoFreezDay0();
                String re = ic.ivfDB.opuDB.updateEmbryoFreezDay0(opu, ic.user.staff_id);
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
            //}
        }

        private void BtnSaveEmbryoEt_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //if (MessageBox.Show("ต้องการ บันทึกช้อมูล Embryo for ET ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            //ic.cStf.staff_id = "";
            //FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            //frm.ShowDialog(this);
            ic.cStf.staff_id = ic.userId;
            if (!ic.cStf.staff_id.Equals(""))
            {
                setOPUEmbryeEt();
                String re = ic.ivfDB.opuDB.updateEmbryoEt(opu, ic.user.staff_id);
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
        //}

        private void BtnSaveSperm_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //if (MessageBox.Show("ต้องการ บันทึกช้อมูล Sperm Preparation ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            //ic.cStf.staff_id = "";
            //FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            //frm.ShowDialog(this);
            ic.cStf.staff_id = ic.userId;
            if (!ic.cStf.staff_id.Equals(""))
            {
                setOPUSperm();
                String re = ic.ivfDB.opuDB.updateSperm(opu, ic.user.staff_id);
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
            //}
        }

        private void BtnSaveFertili_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //if (MessageBox.Show("ต้องการ บันทึกช้อมูล Fertilization ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            //ic.cStf.staff_id = "";
            //FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            //frm.ShowDialog(this);
            calFertili();
            ic.cStf.staff_id = ic.userId;
            if (!ic.cStf.staff_id.Equals(""))
            {
                setOPUFertilization();
                String re = ic.ivfDB.opuDB.updateFertili(opu, ic.user.staff_id);
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
            //}
        }

        private void BtnSaveMatura_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //if (MessageBox.Show("ต้องการ บันทึกช้อมูล Maturation ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            //ic.cStf.staff_id = "";
            //FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            //frm.ShowDialog(this);
            ic.cStf.staff_id = ic.userId;
            if (!ic.cStf.staff_id.Equals(""))
            {
                setOPUMatura();
                String re = ic.ivfDB.opuDB.updateMatura(opu, ic.user.staff_id);
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
            //}
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
        private void setControlFirstTime(Boolean flag)
        {
            txtMaturaDate.Enabled = flag;
            txtMaturaMii.Enabled = flag;
            txtMaturaMi.Enabled = flag;
            txtMaturaGv.Enabled = flag;
            txtMaturaPostMat.Enabled = flag;
            txtMaturaAbnor.Enabled = flag;
            txtMaturaDead.Enabled = flag;
            txtMaturaNoofOpu1.Enabled = flag;
            txtFertili2PnAdd.Enabled = flag;

            //groupBox3.Enabled = flag;
            groupBox4.Enabled = flag;
            groupBox5.Enabled = flag;
            groupBox7.Enabled = flag;
            gbDay2.Enabled = flag;
            gbDay3.Enabled = flag;
            gbDay5.Enabled = flag;
            gbDay6.Enabled = flag;
            pnGrf6Img.Enabled = flag;
            pnGrf5Img.Enabled = flag;
            pnGrf3Img.Enabled = flag;
            pnGrf2Img.Enabled = flag;
            grfDay2.Enabled = flag;
            grfDay3.Enabled = flag;
            grfDay5.Enabled = flag;
            grfDay6.Enabled = flag;
            grfDay6Img.Enabled = flag;
            grfDay5Img.Enabled = flag;
            grfDay3Img.Enabled = flag;
            grfDay2Img.Enabled = flag;

            btnPrintOpuEmbryoDev.Enabled = flag;
            btnPrint.Enabled = flag;
            txtFertiliDate.Enabled = flag;
            txtFertili1Pn.Enabled = flag;
            txtFertili3Pn.Enabled = flag;
            txtFertili4Pn.Enabled = flag;
            txtFertiliNoPn.Enabled = flag;
            txtFertiliDead.Enabled = flag;
            //txtFertiliDate.Enabled = flag;
            txtFertili2Pn.Enabled = true;

            btnSaveMatura.Enabled = flag;
            btnSaveFertili.Enabled = flag;
            btnSaveSperm.Enabled = flag;
            btnSaveEmbryoFreezDay1.Enabled = false;
            btnResultDay1.Enabled = flag;
        }
        private void setControl()
        {
            try
            {
                if (!opuId.Equals(""))
                {
                    opu = ic.ivfDB.opuDB.selectByPk1(opuId);
                    lbReq = ic.ivfDB.lbReqDB.selectByPk1(opu.req_id);
                    setControl1();
                    DataTable dt = new DataTable();
                    dt = ic.ivfDB.opuEmDevDB.selectByOpuFetId_Day(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day2);
                    if (dt.Rows.Count > 0)
                    {
                        txtMaturaNoofOpu.Enabled = false;
                    }
                    else
                    {
                        setControlFirstTime(false);
                    }
                }
                else
                {
                    lbReq = ic.ivfDB.lbReqDB.selectByPk1(reqId);

                    txtHnFeMale.Value = lbReq.hn_female;
                    txtHnMale.Value = lbReq.hn_male;
                    txtNameFeMale.Value = lbReq.name_female;
                    txtNameMale.Value = lbReq.name_male;
                    txtLabReqCode.Value = lbReq.req_code;
                    setControlFirstTime(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "");
            }
        }
        private void setControl1()
        {
            txtID.Value = opu.opu_id;
            txtHnFeMale.Value = opu.hn_female;
            txtHnMale.Value = opu.hn_male;
            txtNameFeMale.Value = opu.name_female;
            txtNameMale.Value = opu.name_male;
            txtLabReqCode.Value = lbReq.req_code;
            txtDobFeMale.Value = opu.dob_female;
            txtDobMale.Value = opu.dob_male;
            ic.setC1Combo(cboDoctor, opu.doctor_id);
            ic.setC1Combo(cboEmbryoForEtDoctor, opu.embryo_for_et_doctor);
            txtOpuDate.Value = opu.opu_date;
            ic.setC1Combo(cboOpuProce, opu.proce_id);
            txtOpuCode.Value = opu.opu_code;
            txtHnDonor.Value = opu.hn_donor;
            txtNameDonor.Value = opu.name_donor;
            txtDobDonor.Value = opu.dob_donor;

            txtMaturaNoofOpu.Value = opu.matura_no_of_opu;
            try
            {
                String[] ext = opu.matura_no_of_opu.Split('[');
                int rt = 0, lt = 0;
                int.TryParse(ext[0], out rt);
                //int.TryParse(ext[1], out lt);

                txtMaturaNoofOpu1.Value = rt;
            }
            catch (Exception ex)
            {

            }

            txtMaturaDate.Value = opu.matura_date;
            txtMaturaMii.Value = opu.matura_m_ii;
            txtMaturaMi.Value = opu.matura_m_i;
            txtMaturaGv.Value = opu.matura_gv;
            txtMaturaPostMat.Value = opu.matura_post_mat;
            txtMaturaAbnor.Value = opu.matura_abmormal;
            txtMaturaDead.Value = opu.matura_dead;

            txtFertiliDate.Value = opu.fertili_date;
            txtFertili2Pn.Value = opu.fertili_2_pn;
            txtFertili1Pn.Value = opu.fertili_1_pn;
            txtFertili3Pn.Value = opu.fertili_3_pn;
            txtFertili4Pn.Value = opu.fertili_4_pn;
            txtFertiliNoPn.Value = opu.fertili_no_pn;
            txtFertiliDead.Value = opu.fertili_dead;

            txtSpermDate.Value = opu.sperm_date;
            txtSpermVol.Value = opu.sperm_volume;
            txtSpermCnt.Value = opu.sperm_count;
            txtSpermTotalCnt.Value = opu.sperm_count_total;
            txtSpermMoti.Value = opu.sperm_motile;
            txtSpermMotiTotal.Value = opu.sperm_motile_total;
            txtSpermMotility.Value = opu.sperm_motility;
            chkSpermFresh.Value = opu.sperm_fresh_sperm.Equals("1") ? true : false;
            chkSpermFrozen.Value = opu.sperm_frozen_sperm.Equals("1") ? true : false;
            txtEmbryoForEtNO.Value = opu.embryo_for_et_no_of_et;
            txtEmbryoForEtDay.Value = opu.embryo_for_et_day;
            txtEmbryoForEtDate.Value = ic.datetoShow(opu.embryo_for_et_date);
            txtEmbryoForEtAsseted.Value = opu.embryo_for_et_assisted;
            txtEmbryoForEtVolume.Value = opu.embryo_for_et_volume;
            txtEmbryoForEtCatheter.Value = opu.embryo_for_et_catheter;
            //txtEmbryoForEtDoctor.Value = opu.embryo_for_et_doctor;
            txtEmbryoForEtNumTran.Value = opu.embryo_for_et_number_of_transfer;
            txtEmbryoForEtNumFreeze.Value = opu.embryo_for_et_number_of_freeze;
            txtEmbryoForEtNumDiscard.Value = opu.embryo_for_et_number_of_discard;
            //cboEmbryoForEtEmbryologist.Value = opu.embryo_for_et_embryologist_id;
            //cboEmbryologistReport.Value = opu.embryologist_report_id;
            //cboEmbryologistAppv.Value = opu.embryologist_approve_id;
            ic.setC1Combo(cboEmbryologistAppv, opu.embryologist_approve_id);
            ic.setC1Combo(cboEmbryologistReport, opu.embryologist_report_id);
            ic.setC1Combo(cboEmbryoForEtEmbryologist, opu.embryo_for_et_embryologist_id);
            ic.setC1Combo(CboEmbryoFreezDay0, opu.embryo_freez_day_0);
            ic.setC1Combo(CboEmbryoFreezDay1, opu.embryo_freez_day_1);
            txtEmbryoFreezDate0.Value = opu.embryo_freez_date_0;
            txtEmbryoFreezDate1.Value = opu.embryo_freez_date_1;
            //txtEmbryoFreezStage0.Value = opu.embryo_freez_stage_0;
            ic.setC1Combo(cboEmbryoFreezStage0, opu.embryo_freez_stage_0);
            //txtEmbryoFreezStage1.Value = opu.embryo_freez_stage_1;
            ic.setC1Combo(cboEmbryoFreezStage1, opu.embryo_freez_stage_1);
            txtEmbryoFreezNoOg0.Value = opu.embryo_freez_no_og_0;
            txtEmbryoFreezNoOg1.Value = opu.embryo_freez_no_og_1;
            txtEmbryoFreezNoStraw0.Value = opu.embryo_freez_no_of_straw_0;
            txtEmbryoFreezNoStraw1.Value = opu.embryo_freez_no_of_straw_1;
            txtEmbryoFreezPosi0.Value = opu.embryo_freez_position_0;
            txtEmbryoFreezPosi1.Value = opu.embryo_freez_position_1;
            //txtEmbryoFreezMethod0.Value = opu.embryo_freez_mothod_0;
            //txtEmbryoFreezMethod1.Value = opu.embryo_freez_mothod_1;
            ic.setC1Combo(cboEmbryoFreezMethod1, opu.embryo_freez_mothod_1);
            ic.setC1Combo(cboEmbryoFreezMethod0, opu.embryo_freez_mothod_0);
            ic.setC1Combo(cboEmbryoFreezMedia0, opu.embryo_freez_freeze_media_0);
            ic.setC1Combo(cboEmbryoFreezMedia1, opu.embryo_freez_freeze_media_1);

            //ic.setC1Combo(cboRemarkDay2, opu.remark_day2);
            //ic.setC1Combo(cboRemarkDay3, opu.remark_day3);
            //ic.setC1Combo(cboRemarkDay5, opu.remark_day5);
            //ic.setC1Combo(cboRemarkDay6, opu.remark_day6);
            //txtEmbryoFreezMedia0.Value = opu.embryo_freez_freeze_media_0;
            //txtEmbryoFreezMedia1.Value = opu.embryo_freez_freeze_media_1;

            //txtRemark.Value = opu.remark;
            ic.setC1ComboByName(cboRemark, opu.remark);
            ic.setC1ComboByName(cboRemark1, opu.remark_1);
            ic.setC1ComboByName(cboRemarkDay2, opu.remark_day2);
            ic.setC1ComboByName(cboRemarkDay3, opu.remark_day3);
            ic.setC1ComboByName(cboRemarkDay5, opu.remark_day5);
            ic.setC1ComboByName(cboRemarkDay6, opu.remark_day6);
            txtDatePicEmbryo.Value = opu.date_pic_embryo;
            //CboEmbryoDay.Text = opu.emb
            if (opu.status_opu.Equals("2"))
            {
                btnApproveResult.Image = Resources.Female_user_accept_24;
                btnApproveResult.Text = "Finish";
                String appr = "";
                appr = ic.ivfDB.stfDB.getStaffNameBylStf(opu.approve_result_staff_id);
                txtApproveResult.Value = appr;
            }
            else
            {
                btnApproveResult.Image = Resources.Female_user_add_24;
                btnApproveResult.Text = "Finish";
            }
            txtOpuTime.Value = opu.opu_time;
            
            btnResultDay1View.Visible = opu.status_approve_result_day1.Equals("1") ? true : false;
            btnResultDay3View.Visible = opu.status_approve_result_day3.Equals("1") ? true : false;
            txtFertili2PnAdd.Value = opu.fertili_2_pn_add;
        }
        private void calMaturation()
        {
            sep.Clear();
            int mii = 0, mi = 0, gv = 0, postmat = 0, abnor = 0, dead = 0, noofopu=0, total=0;
            int.TryParse(txtMaturaMii.Text, out mii);
            int.TryParse(txtMaturaMi.Text, out mi);
            int.TryParse(txtMaturaGv.Text, out gv);
            int.TryParse(txtMaturaPostMat.Text, out postmat);
            int.TryParse(txtMaturaAbnor.Text, out abnor);
            int.TryParse(txtMaturaDead.Text, out dead);
            String[] chk = txtMaturaNoofOpu1.Text.Split(',');
            if (chk.Length > 1)
            {
                int chk1 = 0, chk2 = 0;
                int.TryParse(chk[0], out chk1);
                int.TryParse(chk[1], out chk2);
                int.TryParse((chk1 + chk2).ToString(), out noofopu);
            }
            else
            {
                int.TryParse(txtMaturaNoofOpu1.Text, out noofopu);
            }
            if (noofopu < mii)
            {
                sep.SetError(txtMaturaMii, "aaa");
                return;
            }
            if (noofopu < (mii + mi))
            {
                sep.SetError(txtMaturaMi, "aaa");
                return;
            }
            if (noofopu < (mii+mi+gv))
            {
                sep.SetError(txtMaturaGv, "aaa");
                return;
            }
            if (noofopu < (mii+mi+gv+postmat))
            {
                sep.SetError(txtMaturaPostMat, "aaa");
                return;
            }
            if (noofopu < (mii+mi+gv+postmat+abnor))
            {
                sep.SetError(txtMaturaAbnor, "aaa");
                return;
            }
            if (noofopu < (mii+mi+gv+postmat+abnor+dead))
            {
                sep.SetError(txtMaturaDead, "aaa");
                return;
            }
            total = mii + mi + gv + postmat + abnor + dead;
            if (noofopu < total)
            {

            }
        }
        private void setOPU()
        {
            opu.opu_id = txtID.Text;
            opu.hn_female = txtHnFeMale.Text;
            opu.hn_male = txtHnMale.Text;
            opu.name_female = txtNameFeMale.Text;
            opu.name_male = txtNameMale.Text;
            //lbReq.req_code = txtLabReqCode.Text;
            opu.dob_female = ic.datetoDB(txtDobFeMale.Text);
            opu.dob_male = ic.datetoDB(txtDobMale.Text);
            //ComboBoxItem item = new ComboBoxItem();
            //if (cboDoctor.SelectedItem != null)
            //{
            //    item = (ComboBoxItem)cboDoctor.SelectedItem;
            //    opu.doctor_id = item.Value;
            //}
            //else
            //{
            //    opu.doctor_id = "0";
            //}
            opu.opu_date = ic.datetoDB(txtOpuDate.Text);
            //if (cboDoctor.SelectedItem != null)
            //{
            //    item = (ComboBoxItem)cboOpuProce.SelectedItem;
            //    opu.proce_id = item.Value;
            //}
            //else
            //{
            //    opu.proce_id = "0";
            //}
            opu.doctor_id = cboDoctor.SelectedItem == null ? "" : ((ComboBoxItem)cboDoctor.SelectedItem).Value;
            opu.proce_id = cboOpuProce.SelectedItem == null ? "" : ((ComboBoxItem)cboOpuProce.SelectedItem).Value;
            opu.opu_code = txtOpuCode.Text;
            opu.remark = cboRemark.Text;
            opu.embryo_for_et_remark = cboRemark.Text;
            opu.hn_donor = txtHnDonor.Text;
            opu.name_donor = txtNameDonor.Text;
            opu.date_pic_embryo = ic.datetoDB(txtDatePicEmbryo.Text);
            opu.remark_1 = cboRemark1.Text;
            opu.dob_donor = ic.datetoDB(txtDobDonor.Text);
        }
        private void setOPUMatura()
        {
            opu.opu_id = txtID.Text;
            opu.matura_no_of_opu = txtMaturaNoofOpu.Text;
            opu.matura_date = ic.datetoDB(txtMaturaDate.Text);
            opu.matura_m_ii = txtMaturaMii.Text;
            opu.matura_m_i = txtMaturaMi.Text;
            opu.matura_gv = txtMaturaGv.Text;
            opu.matura_post_mat = txtMaturaPostMat.Text;
            opu.matura_abmormal = txtMaturaAbnor.Text;
            opu.matura_dead = txtMaturaDead.Text;
        }
        private void setOPUFertilization()
        {
            opu.opu_id = txtID.Text;
            opu.fertili_date = ic.datetoDB(txtFertiliDate.Text);
            opu.fertili_2_pn = txtFertili2Pn.Text;
            opu.fertili_1_pn = txtFertili1Pn.Text;
            opu.fertili_3_pn = txtFertili3Pn.Text;
            opu.fertili_4_pn = txtFertili4Pn.Text;
            opu.fertili_no_pn = txtFertiliNoPn.Text;
            opu.fertili_dead = txtFertiliDead.Text;
            //opu.matura_dead = txtMaturaDead.Text;
        }
        private void setOPUSperm()
        {
            opu.opu_id = txtID.Text;
            opu.sperm_date = ic.datetoDB(txtSpermDate.Text);
            opu.sperm_volume = txtSpermVol.Text;
            opu.sperm_count = txtSpermCnt.Text;
            opu.sperm_count_total = txtSpermTotalCnt.Text;
            opu.sperm_motile = txtSpermMoti.Text;
            opu.sperm_motile_total = txtSpermMotiTotal.Text;
            opu.sperm_motility = txtSpermMotility.Text;
            opu.sperm_fresh_sperm = chkSpermFresh.Checked ? "1" : "0";
            opu.sperm_frozen_sperm = chkSpermFrozen.Checked ? "1" : "0";
        }
        private void setOPUEmbryeEt()
        {
            opu.opu_id = txtID.Text;
            opu.embryo_for_et_no_of_et = txtEmbryoForEtNO.Text;
            opu.embryo_for_et_day = txtEmbryoForEtDay.Text;
            opu.embryo_for_et_date = ic.datetoDB(txtEmbryoForEtDate.Text);
            opu.embryo_for_et_assisted = txtEmbryoForEtAsseted.Text;
            opu.embryo_for_et_volume = txtEmbryoForEtVolume.Text;
            opu.embryo_for_et_catheter = txtEmbryoForEtCatheter.Text;
            //opu.embryo_for_et_doctor = txtEmbryoForEtDoctor.Text;

            opu.embryo_for_et_doctor = cboEmbryoForEtDoctor.SelectedItem == null ? "0" : ((ComboBoxItem)cboEmbryoForEtDoctor.SelectedItem).Value;
            opu.embryo_for_et_embryologist_id = cboEmbryoForEtEmbryologist.SelectedItem == null ? "0" : ((ComboBoxItem)cboEmbryoForEtEmbryologist.SelectedItem).Value;
            opu.embryologist_report_id = cboEmbryologistReport.SelectedItem == null ? "0" : ((ComboBoxItem)cboEmbryologistReport.SelectedItem).Value;
            opu.embryologist_approve_id = cboEmbryologistAppv.SelectedItem == null ? "0" : ((ComboBoxItem)cboEmbryologistAppv.SelectedItem).Value;

            //opu.remark = txtRemark.Text;
            opu.remark = cboRemark.Text;
            opu.embryo_for_et_number_of_transfer = txtEmbryoForEtNumTran.Text;
            opu.embryo_for_et_number_of_freeze = txtEmbryoForEtNumFreeze.Text;
            opu.embryo_for_et_number_of_discard = txtEmbryoForEtNumDiscard.Text;
            opu.embryo_for_et_remark = cboRemark.Text;
            opu.remark_1 = cboRemark1.Text;
        }
        private void setOPUEmbryoFreezDay1()
        {
            opu.opu_id = txtID.Text;
            //ComboBoxItem item = new ComboBoxItem();
            //if (CboEmbryoFreezDay1.SelectedItem != null)
            //{
            //    item = (ComboBoxItem)CboEmbryoFreezDay1.SelectedItem;
            //    opu.embryo_freez_day_1 = item.Value;
            //}
            //else
            //{
            //    opu.embryo_freez_day_1 = "0";
            //}
            opu.embryo_freez_day_1 = CboEmbryoFreezDay1.SelectedItem == null ? "" : ((ComboBoxItem)CboEmbryoFreezDay1.SelectedItem).Value;
            opu.embryo_freez_date_1 = ic.datetoDB(txtEmbryoFreezDate1.Text);
            //opu.embryo_freez_stage_1 = txtEmbryoFreezStage1.Text;

            //if (cboEmbryoFreezStage1.SelectedItem != null)
            //{
            //    item = (ComboBoxItem)cboEmbryoFreezStage1.SelectedItem;
            //    opu.embryo_freez_stage_1 = item.Value;
            //}
            //else
            //{
            //    opu.embryo_freez_stage_1 = "0";
            //}
            opu.embryo_freez_stage_1 = cboEmbryoFreezStage1.SelectedItem == null ? "" : ((ComboBoxItem)cboEmbryoFreezStage1.SelectedItem).Value;
            opu.embryo_freez_no_og_1 = txtEmbryoFreezNoOg1.Text;
            opu.embryo_freez_no_of_straw_1 = txtEmbryoFreezNoStraw1.Text;
            opu.embryo_freez_position_1 = txtEmbryoFreezPosi1.Text;
            //opu.embryo_freez_mothod_1 = txtEmbryoFreezMethod1.Text;
            //if (cboEmbryoFreezMethod1.SelectedItem != null)
            //{
            //    item = (ComboBoxItem)cboEmbryoFreezMethod1.SelectedItem;
            //    opu.embryo_freez_mothod_1 = item.Value;
            //}
            //else
            //{
            //    opu.embryo_freez_stage_1 = "0";
            //}
            opu.embryo_freez_mothod_1 = cboEmbryoFreezMethod1.SelectedItem == null ? "" : ((ComboBoxItem)cboEmbryoFreezMethod1.SelectedItem).Value;
            //if (cboEmbryoFreezMedia1.SelectedItem != null)
            //{
            //    item = (ComboBoxItem)cboEmbryoFreezMedia1.SelectedItem;
            //    opu.embryo_freez_freeze_media_1 = item.Value;
            //}
            //else
            //{
            //    opu.embryo_freez_freeze_media_1 = "0";
            //}
            opu.embryo_freez_freeze_media_1 = cboEmbryoFreezMedia1.SelectedItem == null ? "" : ((ComboBoxItem)cboEmbryoFreezMedia1.SelectedItem).Value;
            //opu.embryo_freez_freeze_media_1 = txtEmbryoFreezMedia1.Text;
            //opu.matura_dead = txtMaturaDead.Text;
        }
        private void setOPUEmbryoFreezDay0()
        {
            opu.opu_id = txtID.Text;
            //ComboBoxItem item = new ComboBoxItem();
            //if (CboEmbryoFreezDay0.SelectedItem != null)
            //{
            //    item = (ComboBoxItem)CboEmbryoFreezDay0.SelectedItem;
            //    opu.embryo_freez_day_0 = item.Value;
            //}
            //else
            //{
            //    opu.embryo_freez_day_0 = "0";
            //}
            opu.embryo_freez_day_0 = CboEmbryoFreezDay0.SelectedItem == null ? "" : ((ComboBoxItem)CboEmbryoFreezDay0.SelectedItem).Value;
            opu.embryo_freez_date_0 = ic.datetoDB(txtEmbryoFreezDate0.Text);
            //opu.embryo_freez_stage_0 = txtEmbryoFreezStage0.Text;
            //if (cboEmbryoFreezStage0.SelectedItem != null)
            //{
            //    item = (ComboBoxItem)cboEmbryoFreezStage0.SelectedItem;
            //    opu.embryo_freez_stage_0 = item.Value;
            //}
            //else
            //{
            //    opu.embryo_freez_stage_0 = "0";
            //}
            opu.embryo_freez_stage_0 = cboEmbryoFreezStage0.SelectedItem == null ? "" : ((ComboBoxItem)cboEmbryoFreezStage0.SelectedItem).Value;
            opu.embryo_freez_no_og_0 = txtEmbryoFreezNoOg0.Text;
            opu.embryo_freez_no_of_straw_0 = txtEmbryoFreezNoStraw0.Text;
            opu.embryo_freez_position_0 = txtEmbryoFreezPosi0.Text;
            //opu.embryo_freez_mothod_0 = txtEmbryoFreezMethod0.Text;
            //if (cboEmbryoFreezMethod0.SelectedItem != null)
            //{
            //    item = (ComboBoxItem)cboEmbryoFreezMethod0.SelectedItem;
            //    opu.embryo_freez_mothod_0 = item.Value;
            //}
            //else
            //{
            //    opu.embryo_freez_mothod_0 = "0";
            //}
            opu.embryo_freez_mothod_0 = cboEmbryoFreezMethod0.SelectedItem == null ? "" : ((ComboBoxItem)cboEmbryoFreezMethod0.SelectedItem).Value;
            //if (cboEmbryoFreezMedia0.SelectedItem != null)
            //{
            //    item = (ComboBoxItem)cboEmbryoFreezMedia0.SelectedItem;
            //    opu.embryo_freez_freeze_media_0 = item.Value;
            //}
            //else
            //{
            //    opu.embryo_freez_freeze_media_0 = "0";
            //}
            opu.embryo_freez_freeze_media_0 = cboEmbryoFreezMedia0.SelectedItem == null ? "" : ((ComboBoxItem)cboEmbryoFreezMedia0.SelectedItem).Value;
            //opu.embryo_freez_freeze_media_0 = txtEmbryoFreezMedia0.Text;
            //opu.matura_dead = txtMaturaDead.Text;
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            ic.cStf.staff_id = "";
            //FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            //frm.ShowDialog(this);
            //if (!ic.cStf.staff_id.Equals(""))
            //{
                saveLabOPU();
                //setOPU();
                //String re = ic.ivfDB.opuDB.update(opu, ic.user.staff_id);
                //long chk1 = 0;
                //if (long.TryParse(re, out chk1))
                //{
                //    btnSave.Image = Resources.accept_database24;
                //}
                //else
                //{
                //    btnSave.Image = Resources.accept_database24;
                //}
            //}
            //}
        }
        private void saveLabOPU()
        {
            calMotile();
            calFertili();
            setOPU();
            String re = ic.ivfDB.opuDB.update(opu, ic.user.staff_id);
            sB1.Text = "Save OPU";
            Application.DoEvents();
            long chk1 = 0;
            if (long.TryParse(re, out chk1))
            {
                Boolean chkSave = false;
                setOPUEmbryeEt();
                String re1 = ic.ivfDB.opuDB.updateEmbryoEt(opu, ic.user.staff_id);
                sB1.Text = "Save ET";
                Application.DoEvents();
                setOPUMatura();
                String re2 = ic.ivfDB.opuDB.updateMatura(opu, ic.user.staff_id);
                sB1.Text = "Save Matura";
                Application.DoEvents();
                setOPUFertilization();
                String re3 = ic.ivfDB.opuDB.updateFertili(opu, ic.user.staff_id);
                sB1.Text = "Save Fertili";
                Application.DoEvents();
                setOPUEmbryoFreezDay0();
                String r4 = ic.ivfDB.opuDB.updateEmbryoFreezDay0(opu, ic.user.staff_id);
                sB1.Text = "Save Freez Day0";
                Application.DoEvents();
                setOPUEmbryoFreezDay1();
                String r5 = ic.ivfDB.opuDB.updateEmbryoFreezDay1(opu, ic.user.staff_id);
                sB1.Text = "Save Freez Day1";
                Application.DoEvents();
                setOPUSperm();
                String re6 = ic.ivfDB.opuDB.updateSperm(opu, ic.user.staff_id);
                sB1.Text = "Save Sperm";
                Application.DoEvents();
                chkSave = saveDay2() ? setGrfDay2() : false;
                BtnSaveImg2_Click(null, null);
                sB1.Text = "Save Day2";
                Application.DoEvents();
                chkSave = false;
                chkSave = saveDay3() ? setGrfDay3() : false;
                BtnSaveImg3_Click(null, null);
                sB1.Text = "Save Day3";
                Application.DoEvents();
                chkSave = false;
                chkSave = saveDay5() ? setGrfDay5() : false;
                BtnSaveImg5_Click(null, null);
                sB1.Text = "Save Day5";
                Application.DoEvents();
                chkSave = false;
                chkSave = saveDay6() ? setGrfDay6() : false;
                BtnSaveImg6_Click(null, null);
                sB1.Text = "Save OPU success";
                btnSave.Image = Resources.accept_database24;
            }
            else
            {
                btnSave.Image = Resources.accept_database24;
            }
        }
        private void setGrfDay2Img()
        {
            grfDay2Img.Clear();
            grfDay2Img.DataSource = null;
            grfDay2Img.Rows.Count = 1;
            grfDay2Img.Cols.Count = 9;
            DataTable dt = new DataTable();
            dt = ic.ivfDB.opuEmDevDB.selectByOpuFetId_Day(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day2);

            //C1TextBox txt = new C1TextBox();
            //Button btn = new Button();
            //btn.BackColor = Color.Gray;

            PictureBox img = new PictureBox();

            //grfDay2Img.Cols[colDay2ImgId].Editor = txt;
            //grfDay2Img.Cols[colDay2ImgNun].Editor = txt;
            //grfDay2Img.Cols[colDay2ImgDesc0].Editor = txt;
            //grfDay2Img.Cols[colDay2PathPic].Editor = txt;
            //grfDay2Img.Cols[colDay2ImgBtn].Editor = btn;
            grfDay2Img.Cols[colDay2ImgPic].Editor = img;
            //grfDay2Img.Cols[colDay2StatusBio].Editor = img;
            Column colCashier = grfDay2Img.Cols[colDay2StatusBio];
            colCashier.DataType = typeof(Image);

            grfDay2Img.Cols[colDay2ImgId].Width = 250;
            grfDay2Img.Cols[colDay2ImgPic].Width = 100;
            grfDay2Img.Cols[colDay2ImgDesc0].Width = 100;
            grfDay2Img.Cols[colDay2ImgNun].Width = 100;
            grfDay2Img.Cols[colDay2PathPic].Width = 100;
            grfDay2Img.Cols[colDay2StatusBio].Width = 50;

            grfDay2Img.ShowCursor = true;

            grfDay2Img.Cols[colDay2ImgNun].Caption = "No";
            grfDay2Img.Cols[colDay2ImgDesc0].Caption = "st#";
            grfDay2Img.Cols[colDay2PathPic].Caption = "pathpic";
            grfDay2Img.Cols[colDay2ImgDesc1].Caption = "Desc4";
            grfDay2Img.Cols[colDay2StatusBio].Caption = "Freeze";

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
                row1[colDay2ImgDesc1] = row[ic.ivfDB.opuEmDevDB.opuEmDev.desc4].ToString();
                row1[colDay2StatusBio] = row[ic.ivfDB.opuEmDevDB.opuEmDev.status_biopsy_ngs].ToString().Equals("1") ? imgFinish : imgTran;
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
            grfDay2Img.Cols[colDay2ImgEdit].Visible = false;
            grfDay2Img.Cols[colDay2ImgPic].AllowEditing = false;
            grfDay2Img.Cols[colDay2StatusBio].AllowEditing = false;
            grfDay2Img.AutoSizeCols();
            grfDay2Img.AutoSizeRows();
            grfDay2Img.Cols[colDay2StatusBio].AllowSorting = false;
            grfDay2Img.Cols[colDay2ImgNun].AllowSorting = false;
            grfDay2Img.Cols[colDay2ImgDesc0].AllowSorting = false;
            grfDay2Img.Cols[colDay2PathPic].AllowSorting = false;
            grfDay2Img.Cols[colDay2ImgDesc1].AllowSorting = false;
            grfDay2Img.Cols[colDay2StatusBio].AllowSorting = false;
            grfDay2Img.Cols[colDay2ImgDesc1].AllowSorting = false;
            theme1.SetTheme(grfDay2Img, "Office2016Colorful");
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
            grfDay2Img.KeyUp += GrfDay2Img_KeyUp;
            grfDay2Img.ChangeEdit += GrfDay2Img_ChangeEdit;
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("&Upload image", new EventHandler(ContextMenu_grfday2_upload));
            menuGw.MenuItems.Add("&Save description", new EventHandler(ContextMenu_grfday2_save));
            menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_grfday2_Cancel));
            grfDay2Img.ContextMenu = menuGw;
            pnGrf2Img.Controls.Add(grfDay2Img);

            theme1.SetTheme(grfDay2Img, "Office2010Blue");
        }

        private void GrfDay2Img_ChangeEdit(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            grfDay2Img[grfDay2Img.Row, colDay2ImgEdit] = "1";
            grfDay2Img.Rows[grfDay2Img.Row].StyleNew.BackColor = color;
        }

        private void GrfDay2Img_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.Delete)
            {
                ContextMenu_grfday2_Cancel(null, null);
            }
        }

        private void ContextMenu_grfday2_upload(object sender, System.EventArgs e)
        {
            String pathfile1 = grfDay2Img[grfDay2Img.Row, colDay2PathPic] != null ? grfDay2Img[grfDay2Img.Row, colDay2PathPic].ToString() : "";
            if (pathfile1.Length > 0)
            {
                MessageBox.Show("มีรูปภาพ อยู่แล้ว กรุณา ยกเลิก ก่อน Upload รูปใหม่ ", "");
                return;
            }

            //if (MessageBox.Show("ต้องการ Upload image to server ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
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
                        //FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                        //frm.ShowDialog(this);
                        //if (!ic.cStf.staff_id.Equals(""))
                        //{
                            String filename = "", re = "";
                            String[] ext = pathfile.Split('.');
                            if (ext.Length > 1)
                            {
                                filename = txtOpuCode.Text + "_day2_" + no + "." + ext[ext.Length - 1];
                                re = ic.ivfDB.opuEmDevDB.updatePathPic(id, no, ic.iniC.folderFTP + "/" + txtOpuCode.Text + "/" + filename, desc, ic.cStf.staff_id);
                                long chk = 0;
                                if (long.TryParse(re, out chk))
                                {
                                    ic.savePicOPUtoServer(txtOpuCode.Text, filename, pathfile);
                                    grfDay2Img.Rows[grfDay2Img.Row].StyleNew.BackColor = color;
                                    setGrfDay2Img();
                                }
                            }
                        //}
                    }
                }
            //}
        }
        private void ContextMenu_grfday2_save(object sender, System.EventArgs e)
        {
            String id = grfDay2Img[grfDay2Img.Row, colDay2ImgId].ToString();
            String desc = grfDay2Img[grfDay2Img.Row, colDay2ImgDesc0].ToString();
            String num = grfDay2Img[grfDay2Img.Row, colDay2ImgNun].ToString();
            //if (MessageBox.Show("ต้องการ บันทึกช้อมูล \n Number " + num + " description " + desc, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
                ic.cStf.staff_id = "";
                //FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                //frm.ShowDialog(this);
                //if (!ic.cStf.staff_id.Equals(""))
                //{
                    String re = ic.ivfDB.opuEmDevDB.updateNumDesc(id, num, desc, ic.user.staff_id);
                //}
            //}
        }
        private void ContextMenu_grfday2_Cancel(object sender, System.EventArgs e)
        {
            //if (MessageBox.Show("ต้องการ ยกเลิก ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
                String id = grfDay2Img[grfDay2Img.Row, colDay2ImgId].ToString();
                //ic.cStf.staff_id = "";
                //FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                //frm.ShowDialog(this);
                //if (!ic.cStf.staff_id.Equals(""))
                //{
                    String pathfile = grfDay2Img[grfDay2Img.Row, colDay2PathPic].ToString();
                    String re = ic.ivfDB.opuEmDevDB.updatePathPic(id, "", "", "", ic.user.staff_id);
                    ic.delPicOPUtoServer(txtOpuCode.Text, pathfile);
                    grfDay2Img[grfDay2Img.Row, colDay2PathPic] = "";
                    grfDay2Img[grfDay2Img.Row, colDay2ImgPic] = null;
                //}
            //}
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
            else if (grfDay2Img.Col == colDay2StatusBio)
            {
                int row = 0;
                int.TryParse(grfDay2Img.Row.ToString(), out row);
                if (grfDay2Img[row, colDay2StatusBio] == imgFinish)
                {
                    grfDay2Img[row, colDay2StatusBio] = imgTran;
                }
                else
                {
                    grfDay2Img[row, colDay2StatusBio] = imgFinish;
                }
                grfDay2Img[grfDay2Img.Row, colDay2ImgEdit] = "1";
                grfDay2Img.Rows[grfDay2Img.Row].StyleNew.BackColor = color;
                //setGrfDay2ImgFreezing();
            }
        }
        private void setGrfDay2ImgFreezing()
        {
            int i = 1;
            foreach (Row row in grfDay2Img.Rows)
            {
                if (row[colDay2ImgDesc0].ToString().Equals("st#")) continue;
                row[colDay2ImgDesc0] = "";
                if (row[colDay2StatusBio] == imgFinish)
                {
                    row[colDay2ImgDesc0] = i;
                    i++;
                }
            }
        }
        private Boolean setGrfDay3Img()
        {
            grfDay3Img.Clear();
            grfDay3Img.DataSource = null;
            grfDay3Img.Rows.Count = 1;
            grfDay3Img.Cols.Count = 9;
            DataTable dt = new DataTable();
            dt = ic.ivfDB.opuEmDevDB.selectByOpuFetId_Day(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day3);

            //C1TextBox txt = new C1TextBox();
            //Button btn = new Button();
            //btn.BackColor = Color.Gray;

            PictureBox img = new PictureBox();

            //grfDay3Img.Cols[colDay2ImgId].Editor = txt;
            //grfDay3Img.Cols[colDay2ImgNun].Editor = txt;
            //grfDay3Img.Cols[colDay2ImgDesc0].Editor = txt;
            //grfDay3Img.Cols[colDay2PathPic].Editor = txt;
            //grfDay2Img.Cols[colDay2ImgBtn].Editor = btn;
            grfDay3Img.Cols[colDay2ImgPic].Editor = img;
            //grfDay3Img.Cols[colDay2StatusBio].Editor = img;
            Column colCashier = grfDay3Img.Cols[colDay2StatusBio];
            colCashier.DataType = typeof(Image);

            grfDay3Img.Cols[colDay2ImgId].Width = 250;
            grfDay3Img.Cols[colDay2ImgPic].Width = 100;
            grfDay3Img.Cols[colDay2ImgDesc0].Width = 100;
            grfDay3Img.Cols[colDay2ImgNun].Width = 100;
            grfDay3Img.Cols[colDay2PathPic].Width = 100;
            grfDay3Img.Cols[colDay2StatusBio].Width = 50;

            grfDay3Img.ShowCursor = true;

            grfDay3Img.Cols[colDay2ImgNun].Caption = "No";
            grfDay3Img.Cols[colDay2ImgDesc0].Caption = "st#";
            grfDay3Img.Cols[colDay2PathPic].Caption = "pathpic";
            grfDay3Img.Cols[colDay2ImgDesc1].Caption = "Desc4";
            grfDay3Img.Cols[colDay2StatusBio].Caption = "Freeze";

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
                row1[colDay2ImgDesc1] = row[ic.ivfDB.opuEmDevDB.opuEmDev.desc4].ToString();
                row1[colDay2StatusBio] = row[ic.ivfDB.opuEmDevDB.opuEmDev.status_biopsy_ngs].ToString().Equals("1") ? imgFinish : imgTran;
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
            grfDay3Img.Cols[colDay2ImgEdit].Visible = false;
            grfDay3Img.Cols[colDay2ImgPic].AllowEditing = false;
            grfDay3Img.Cols[colDay2StatusBio].AllowEditing = false;
            grfDay3Img.AutoSizeCols();
            grfDay3Img.AutoSizeRows();
            grfDay3Img.Cols[colDay2StatusBio].AllowSorting = false;
            grfDay3Img.Cols[colDay2ImgNun].AllowSorting = false;
            grfDay3Img.Cols[colDay2ImgDesc0].AllowSorting = false;
            grfDay3Img.Cols[colDay2PathPic].AllowSorting = false;
            grfDay3Img.Cols[colDay2ImgDesc1].AllowSorting = false;
            grfDay3Img.Cols[colDay2StatusBio].AllowSorting = false;
            theme1.SetTheme(grfDay3Img, "Office2016Colorful");
            grfDay3Img.Refresh();

            return true;
        }

        private void initGrfDay3Img()
        {
            grfDay3Img = new C1FlexGrid();
            grfDay3Img.Font = fEdit;
            grfDay3Img.Dock = System.Windows.Forms.DockStyle.Fill;
            grfDay3Img.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            grfDay3Img.DoubleClick += GrfDay3Img_DoubleClick;
            grfDay3Img.KeyUp += GrfDay3Img_KeyUp;
            grfDay3Img.ChangeEdit += GrfDay3Img_ChangeEdit;
            //grfDay2.CellChanged += GrfDay2_CellChanged;
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("&Upload image", new EventHandler(ContextMenu_grfday3_upload));
            menuGw.MenuItems.Add("&Save description", new EventHandler(ContextMenu_grfday3_save));
            menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_grfday3_Cancel));
            grfDay3Img.ContextMenu = menuGw;
            pnGrf3Img.Controls.Add(grfDay3Img);

            theme1.SetTheme(grfDay3Img, "Office2010Blue");
        }

        private void GrfDay3Img_ChangeEdit(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            grfDay3Img[grfDay3Img.Row, colDay2ImgEdit] = "1";
            grfDay3Img.Rows[grfDay3Img.Row].StyleNew.BackColor = color;
        }

        private void GrfDay3Img_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.Delete)
            {
                ContextMenu_grfday3_Cancel(null, null);
            }
        }

        private void ContextMenu_grfday3_upload(object sender, System.EventArgs e)
        {
            String pathfile1 = grfDay3Img[grfDay3Img.Row, colDay2PathPic] != null ? grfDay3Img[grfDay3Img.Row, colDay2PathPic].ToString() : "";
            if (pathfile1.Length > 0)
            {
                MessageBox.Show("มีรูปภาพ อยู่แล้ว กรุณา ยกเลิก ก่อน Upload รูปใหม่ ", "");
                return;
            }

            //if (MessageBox.Show("ต้องการ Upload image to server ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
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
                        //FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                        //frm.ShowDialog(this);
                        //if (!ic.cStf.staff_id.Equals(""))
                        //{
                            String filename = "", re = "";
                            String[] ext = pathfile.Split('.');
                            if (ext.Length > 1)
                            {
                                filename = txtOpuCode.Text + "_day3_" + no + "." + ext[ext.Length - 1];
                                re = ic.ivfDB.opuEmDevDB.updatePathPic(id, no, ic.iniC.folderFTP + "/" + txtOpuCode.Text + "/" + filename, desc, ic.cStf.staff_id);
                                long chk = 0;
                                if (long.TryParse(re, out chk))
                                {
                                    ic.savePicOPUtoServer(txtOpuCode.Text, filename, pathfile);
                                    grfDay3Img.Rows[grfDay3Img.Row].StyleNew.BackColor = color;
                                    setGrfDay3Img();
                                }
                            }
                        //}
                    }
                }
            //}
        }
        private void ContextMenu_grfday3_save(object sender, System.EventArgs e)
        {
            String id = grfDay3Img[grfDay3Img.Row, colDay2ImgId].ToString();
            String desc = grfDay3Img[grfDay3Img.Row, colDay2ImgDesc0].ToString();
            String num = grfDay3Img[grfDay3Img.Row, colDay2ImgNun].ToString();
            //if (MessageBox.Show("ต้องการ บันทึกช้อมูล \n Number " + num + " description " + desc, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
                ic.cStf.staff_id = "";
                //FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                //frm.ShowDialog(this);
                //if (!ic.cStf.staff_id.Equals(""))
                //{
                    String re = ic.ivfDB.opuEmDevDB.updateNumDesc(id, num, desc, ic.user.staff_id);
                //}
            //}
        }
        private void ContextMenu_grfday3_Cancel(object sender, System.EventArgs e)
        {
            //if (MessageBox.Show("ต้องการ ยกเลิก ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
                String id = grfDay3Img[grfDay3Img.Row, colDay2ImgId].ToString();
                //ic.cStf.staff_id = "";
                //FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                //frm.ShowDialog(this);
                //if (!ic.cStf.staff_id.Equals(""))
                //{
                    String pathfile = grfDay3Img[grfDay3Img.Row, colDay2PathPic].ToString();
                    String re = ic.ivfDB.opuEmDevDB.updatePathPic(id, "", "", "", ic.user.staff_id);
                    ic.delPicOPUtoServer(txtOpuCode.Text, pathfile);
                    grfDay3Img[grfDay3Img.Row, colDay2PathPic] = "";
                    grfDay3Img[grfDay3Img.Row, colDay2ImgPic] = null;
            //    }
            //}
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
            else if (grfDay3Img.Col == colDay2StatusBio)
            {
                int row = 0;
                int.TryParse(grfDay3Img.Row.ToString(), out row);
                if (grfDay3Img[row, colDay2StatusBio] == imgFinish)
                {
                    grfDay3Img[row, colDay2StatusBio] = imgTran;
                }
                else
                {
                    grfDay3Img[row, colDay2StatusBio] = imgFinish;
                }
                grfDay3Img[grfDay3Img.Row, colDay2ImgEdit] = "1";
                grfDay3Img.Rows[grfDay3Img.Row].StyleNew.BackColor = color;
                //setGrfDay3ImgFreezing();
            }
        }
        private void setGrfDay3ImgFreezing()
        {
            int i = 1;
            foreach (Row row in grfDay3Img.Rows)
            {
                if (row[colDay2ImgDesc0].ToString().Equals("st#")) continue;
                row[colDay2ImgDesc0] = "";
                if (row[colDay2StatusBio] == imgFinish)
                {
                    row[colDay2ImgDesc0] = i;
                    //row[colDay2ImgDesc1] = "day3";
                    i++;
                }
            }
        }
        private void setGrfDay5Img()
        {
            grfDay5Img.Clear();
            grfDay5Img.DataSource = null;
            grfDay5Img.Rows.Count = 1;
            grfDay5Img.Cols.Count = 9;
            DataTable dt = new DataTable();
            dt = ic.ivfDB.opuEmDevDB.selectByOpuFetId_Day(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day5);

            //C1TextBox txt = new C1TextBox();
            //Button btn = new Button();
            //btn.BackColor = Color.Gray;

            PictureBox img = new PictureBox();

            //grfDay5Img.Cols[colDay2ImgId].Editor = txt;
            //grfDay5Img.Cols[colDay2ImgNun].Editor = txt;
            //grfDay5Img.Cols[colDay2ImgDesc0].Editor = txt;
            //grfDay5Img.Cols[colDay2PathPic].Editor = txt;
            //grfDay2Img.Cols[colDay2ImgBtn].Editor = btn;
            grfDay5Img.Cols[colDay2ImgPic].Editor = img;
            //grfDay5Img.Cols[colDay2StatusBio].Editor = img;
            Column colCashier = grfDay5Img.Cols[colDay2StatusBio];
            colCashier.DataType = typeof(Image);

            grfDay5Img.Cols[colDay2ImgId].Width = 250;
            grfDay5Img.Cols[colDay2ImgPic].Width = 100;
            grfDay5Img.Cols[colDay2ImgDesc0].Width = 100;
            grfDay5Img.Cols[colDay2ImgNun].Width = 100;
            grfDay5Img.Cols[colDay2PathPic].Width = 100;
            grfDay5Img.Cols[colDay2StatusBio].Width = 50;

            grfDay5Img.ShowCursor = true;

            grfDay5Img.Cols[colDay2ImgNun].Caption = "No";
            grfDay5Img.Cols[colDay2ImgDesc0].Caption = "st#";
            grfDay5Img.Cols[colDay2PathPic].Caption = "pathpic";
            grfDay5Img.Cols[colDay2ImgDesc1].Caption = "Desc4";
            grfDay5Img.Cols[colDay2StatusBio].Caption = "Freeze";

            grfDay5Img.Cols[colDay2ImgPic].ImageAndText = false;
            grfDay5Img.Cols[colDay2StatusBio].ImageAndText = false;

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            grfDay5Img.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictRows;
            grfDay5Img.Cols[colDay2ImgPic].AllowMerging = true;

            int i = 0;
            //grfDay5Img.Rows.Count = dt.Rows.Count;
            foreach (DataRow row in dt.Rows)
            {
                i++;
                Row row1 = grfDay5Img.Rows.Add();
                //Row row1 = grfDay5Img.Rows[i+1];
                row1[colDay2ImgId] = row[ic.ivfDB.opuEmDevDB.opuEmDev.opu_embryo_dev_id].ToString();
                row1[colDay2ImgNun] = row[ic.ivfDB.opuEmDevDB.opuEmDev.opu_embryo_dev_no].ToString();
                row1[colDay2ImgDesc0] = row[ic.ivfDB.opuEmDevDB.opuEmDev.desc3].ToString();
                row1[colDay2PathPic] = row[ic.ivfDB.opuEmDevDB.opuEmDev.path_pic].ToString();
                row1[colDay2ImgDesc1] = row[ic.ivfDB.opuEmDevDB.opuEmDev.desc4].ToString();
                row1[colDay2StatusBio] = row[ic.ivfDB.opuEmDevDB.opuEmDev.status_biopsy_ngs].ToString().Equals("1") ? imgFinish : imgTran;
                
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
            grfDay5Img.Cols[colDay2ImgEdit].Visible = false;
            grfDay5Img.Cols[colDay2ImgPic].AllowEditing = false;
            grfDay5Img.Cols[colDay2StatusBio].AllowEditing = false;
            grfDay5Img.AutoSizeCols();
            grfDay5Img.AutoSizeRows();
            grfDay5Img.Cols[colDay2StatusBio].AllowSorting = false;
            grfDay5Img.Cols[colDay2ImgNun].AllowSorting = false;
            grfDay5Img.Cols[colDay2ImgDesc0].AllowSorting = false;
            grfDay5Img.Cols[colDay2PathPic].AllowSorting = false;
            grfDay5Img.Cols[colDay2ImgDesc1].AllowSorting = false;
            grfDay5Img.Cols[colDay2StatusBio].AllowSorting = false;
            theme1.SetTheme(grfDay5Img, "Office2016Colorful");
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
            grfDay5Img.KeyUp += GrfDay5Img_KeyUp;
            grfDay5Img.ChangeEdit += GrfDay5Img_ChangeEdit;
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("&Upload image", new EventHandler(ContextMenu_grfday5_upload));
            menuGw.MenuItems.Add("&Save description", new EventHandler(ContextMenu_grfday5_save));
            menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_grfday5_Cancel));
            grfDay5Img.ContextMenu = menuGw;
            pnGrf5Img.Controls.Add(grfDay5Img);

            theme1.SetTheme(grfDay5Img, "Office2010Blue");
        }

        private void GrfDay5Img_ChangeEdit(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            grfDay5Img[grfDay5Img.Row, colDay2ImgEdit] = "1";
            grfDay5Img.Rows[grfDay5Img.Row].StyleNew.BackColor = color;
        }

        private void GrfDay5Img_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.Delete)
            {
                ContextMenu_grfday5_Cancel(null, null);
            }
        }

        private void ContextMenu_grfday5_upload(object sender, System.EventArgs e)
        {
            String pathfile1 = grfDay5Img[grfDay5Img.Row, colDay2PathPic] != null ? grfDay5Img[grfDay5Img.Row, colDay2PathPic].ToString() : "";
            if (pathfile1.Length > 0)
            {
                MessageBox.Show("มีรูปภาพ อยู่แล้ว กรุณา ยกเลิก ก่อน Upload รูปใหม่ ", "");
                return;
            }

            //if (MessageBox.Show("ต้องการ Upload image to server ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
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
                        //FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                        //frm.ShowDialog(this);
                        //if (!ic.cStf.staff_id.Equals(""))
                        //{
                            String filename = "", re = "";
                            String[] ext = pathfile.Split('.');
                            if (ext.Length > 1)
                            {
                                filename = txtOpuCode.Text + "_day5_" + no + "." + ext[ext.Length - 1];
                                re = ic.ivfDB.opuEmDevDB.updatePathPic(id, no, ic.iniC.folderFTP + "/" + txtOpuCode.Text + "/" + filename, desc, ic.cStf.staff_id);
                                long chk = 0;
                                if (long.TryParse(re, out chk))
                                {
                                    ic.savePicOPUtoServer(txtOpuCode.Text, filename, pathfile);
                                    grfDay5Img.Rows[grfDay5Img.Row].StyleNew.BackColor = color;
                                    setGrfDay5Img();
                                }
                            }
                        //}
                    }
                }
            //}
        }
        private void ContextMenu_grfday5_save(object sender, System.EventArgs e)
        {
            String id = grfDay5Img[grfDay5Img.Row, colDay2ImgId].ToString();
            String desc = grfDay5Img[grfDay5Img.Row, colDay2ImgDesc0].ToString();
            String num = grfDay5Img[grfDay5Img.Row, colDay2ImgNun].ToString();
            //if (MessageBox.Show("ต้องการ บันทึกช้อมูล \n Number " + num + " description " + desc, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
                ic.cStf.staff_id = "";
                //FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                //frm.ShowDialog(this);
                //if (!ic.cStf.staff_id.Equals(""))
                //{
                    String re = ic.ivfDB.opuEmDevDB.updateNumDesc(id, num, desc, ic.user.staff_id);
                //}
            //}
        }
        private void ContextMenu_grfday5_Cancel(object sender, System.EventArgs e)
        {
            //if (MessageBox.Show("ต้องการ ยกเลิก ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
                String id = grfDay5Img[grfDay5Img.Row, colDay2ImgId].ToString();
                //ic.cStf.staff_id = "";
                //FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                //frm.ShowDialog(this);
                //if (!ic.cStf.staff_id.Equals(""))
                //{
                    String pathfile = grfDay5Img[grfDay5Img.Row, colDay2PathPic].ToString();
                    String re = ic.ivfDB.opuEmDevDB.updatePathPic(id, "", "", "", ic.user.staff_id);
                    ic.delPicOPUtoServer(txtOpuCode.Text, pathfile);
                    grfDay5Img[grfDay5Img.Row, colDay2PathPic] = "";
                    grfDay5Img[grfDay5Img.Row, colDay2ImgPic] = null;
            //    }
            //}
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
            else if (grfDay5Img.Col == colDay2StatusBio)
            {
                int row = 0;
                int.TryParse(grfDay5Img.Row.ToString(), out row);
                if (grfDay5Img[row, colDay2StatusBio] == imgFinish)
                {
                    grfDay5Img[row, colDay2StatusBio] = imgTran;
                    grfDay5Img[row, colDay2ImgDesc1] = "";
                    grfDay6Img[row, colDay2StatusBio] = imgTran;
                    grfDay6Img[row, colDay2ImgDesc1] = "";
                }
                else
                {
                    grfDay5Img[row, colDay2StatusBio] = imgFinish;
                    grfDay5Img[row, colDay2ImgDesc1] = "day5";
                    grfDay6Img[row, colDay2StatusBio] = imgFinish;
                    grfDay6Img[row, colDay2ImgDesc1] = "day5";
                }
                grfDay5Img[grfDay5Img.Row, colDay2ImgEdit] = "1";
                grfDay5Img.Rows[grfDay5Img.Row].StyleNew.BackColor = color;
                grfDay6Img[grfDay6Img.Row, colDay2ImgEdit] = "1";
                grfDay6Img[grfDay6Img.Row, colDay2ImgDesc1] = grfDay5Img[grfDay5Img.Row, colDay2ImgDesc1];
                grfDay6Img.Rows[grfDay6Img.Row].StyleNew.BackColor = color;
                //setGrfDay5ImgFreezing();
                //grfDay5Img.Refresh();
            }
        }
        private void setGrfDay5ImgFreezing()
        {
            int i = 1;
            //foreach (Row row in grfDay5Img.Rows)
            //{
            //    if (row[colDay2ImgDesc0].ToString().Equals("st#")) continue;
            //    row[colDay2ImgDesc0] = "";
            //}
            foreach (Row row in grfDay5Img.Rows)
            {
                if (row[colDay2ImgDesc0].ToString().Equals("st#")) continue;
                row[colDay2ImgDesc0] = "";
                if (row[colDay2StatusBio] == imgFinish)
                {
                    row[colDay2ImgDesc0] = i;
                    row[colDay2ImgDesc1] = "day5";
                    i++;
                }
            }
        }
        private void setGrfDay6Img()
        {
            grfDay6Img.Clear();
            grfDay6Img.DataSource = null;
            grfDay6Img.Rows.Count = 1;
            grfDay6Img.Cols.Count = 9;
            DataTable dt = new DataTable();
            dt = ic.ivfDB.opuEmDevDB.selectByOpuFetId_Day(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day6);

            //C1TextBox txt = new C1TextBox();
            //Button btn = new Button();
            //btn.BackColor = Color.Gray;

            PictureBox img = new PictureBox();

            //grfDay6Img.Cols[colDay2ImgId].Editor = txt;
            //grfDay6Img.Cols[colDay2ImgNun].Editor = txt;
            //grfDay6Img.Cols[colDay2ImgDesc0].Editor = txt;
            //grfDay6Img.Cols[colDay2PathPic].Editor = txt;
            //grfDay2Img.Cols[colDay2ImgBtn].Editor = btn;
            grfDay6Img.Cols[colDay2ImgPic].Editor = img;
            //grfDay6Img.Cols[colDay2StatusBio].Editor = img;
            Column colCashier = grfDay6Img.Cols[colDay2StatusBio];
            colCashier.DataType = typeof(Image);

            grfDay6Img.Cols[colDay2ImgId].Width = 250;
            grfDay6Img.Cols[colDay2ImgPic].Width = 100;
            grfDay6Img.Cols[colDay2ImgDesc0].Width = 100;
            grfDay6Img.Cols[colDay2ImgNun].Width = 100;
            grfDay6Img.Cols[colDay2PathPic].Width = 100;
            grfDay6Img.Cols[colDay2StatusBio].Width = 50;

            grfDay6Img.ShowCursor = true;

            grfDay6Img.Cols[colDay2ImgNun].Caption = "No";
            grfDay6Img.Cols[colDay2ImgDesc0].Caption = "st#";
            grfDay6Img.Cols[colDay2PathPic].Caption = "pathpic";
            grfDay6Img.Cols[colDay2ImgDesc1].Caption = "Desc4";
            grfDay6Img.Cols[colDay2StatusBio].Caption = "Freeze";

            grfDay6Img.Cols[colDay2ImgPic].ImageAndText = false;
            grfDay6Img.Cols[colDay2StatusBio].ImageAndText = false;

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
                row1[colDay2ImgDesc1] = row[ic.ivfDB.opuEmDevDB.opuEmDev.desc4].ToString();
                row1[colDay2StatusBio] = row[ic.ivfDB.opuEmDevDB.opuEmDev.status_biopsy_ngs].ToString().Equals("1") ? imgFinish : imgTran;

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
            grfDay6Img.Cols[colDay2ImgEdit].Visible = false;
            grfDay6Img.Cols[colDay2ImgPic].AllowEditing = false;
            grfDay6Img.Cols[colDay2StatusBio].AllowEditing = false;
            grfDay6Img.AutoSizeCols();
            grfDay6Img.AutoSizeRows();
            grfDay6Img.Cols[colDay2StatusBio].AllowSorting = false;
            grfDay6Img.Cols[colDay2ImgNun].AllowSorting = false;
            grfDay6Img.Cols[colDay2ImgDesc0].AllowSorting = false;
            grfDay6Img.Cols[colDay2PathPic].AllowSorting = false;
            grfDay6Img.Cols[colDay2ImgDesc1].AllowSorting = false;
            grfDay6Img.Cols[colDay2StatusBio].AllowSorting = false;
            theme1.SetTheme(grfDay6Img, "Office2016Colorful");
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
            grfDay6Img.KeyUp += GrfDay6Img_KeyUp;
            grfDay6Img.ChangeEdit += GrfDay6Img_ChangeEdit;
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("&Upload image", new EventHandler(ContextMenu_grfday6_upload));
            menuGw.MenuItems.Add("&Save description", new EventHandler(ContextMenu_grfday6_save));
            menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_grfday6_Cancel));
            grfDay6Img.ContextMenu = menuGw;
            pnGrf6Img.Controls.Add(grfDay6Img);

            theme1.SetTheme(grfDay6Img, "Office2010Blue");
        }

        private void GrfDay6Img_ChangeEdit(object sender, EventArgs e)
        {
            //throw new NotImplementedException();grfDay6Img[grfDay6Img.Row, colDay2ImgEdit] = "1";
            grfDay6Img[grfDay6Img.Row, colDay2ImgEdit] = "1";
            grfDay6Img.Rows[grfDay6Img.Row].StyleNew.BackColor = color;
        }

        private void GrfDay6Img_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.Delete)
            {
                ContextMenu_grfday6_Cancel(null, null);
            }
        }

        private void ContextMenu_grfday6_upload(object sender, System.EventArgs e)
        {
            String pathfile1 = grfDay6Img[grfDay6Img.Row, colDay2PathPic] != null ? grfDay6Img[grfDay6Img.Row, colDay2PathPic].ToString() : "";
            if (pathfile1.Length > 0)
            {
                MessageBox.Show("มีรูปภาพ อยู่แล้ว กรุณา ยกเลิก ก่อน Upload รูปใหม่ ", "");
                return;
            }

            //if (MessageBox.Show("ต้องการ Upload image to server ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
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
                        //FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                        //frm.ShowDialog(this);
                        //if (!ic.cStf.staff_id.Equals(""))
                        //{
                            String filename = "", re = "";
                            String[] ext = pathfile.Split('.');
                            //var name = Path.GetFileNameWithoutExtension(fileFullName); // Get the name only
                            var extension = Path.GetExtension(pathfile);
                            //if (ext.Length > 1)
                            //{
                            filename = txtOpuCode.Text + "_day6_" + no + extension;
                            re = ic.ivfDB.opuEmDevDB.updatePathPic(id, no, ic.iniC.folderFTP + "/" + txtOpuCode.Text + "/" + filename, desc, ic.cStf.staff_id);
                            long chk = 0;
                            if (long.TryParse(re, out chk))
                            {
                                ic.savePicOPUtoServer(txtOpuCode.Text, filename, pathfile);
                                grfDay6Img.Rows[grfDay6Img.Row].StyleNew.BackColor = color;
                                setGrfDay6Img();
                            }
                            //}
                        //}
                    }
                }
            //}
        }
        private void ContextMenu_grfday6_save(object sender, System.EventArgs e)
        {
            String id = grfDay6Img[grfDay6Img.Row, colDay2ImgId].ToString();
            String desc = grfDay6Img[grfDay6Img.Row, colDay2ImgDesc0].ToString();
            String num = grfDay6Img[grfDay6Img.Row, colDay2ImgNun].ToString();
            //if (MessageBox.Show("ต้องการ บันทึกช้อมูล \n Number " + num + " description " + desc, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
                ic.cStf.staff_id = "";
                //FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                //frm.ShowDialog(this);
                //if (!ic.cStf.staff_id.Equals(""))
                //{
                    String re = ic.ivfDB.opuEmDevDB.updateNumDesc(id, num, desc, ic.user.staff_id);
                //}
            //}
        }
        private void ContextMenu_grfday6_Cancel(object sender, System.EventArgs e)
        {
            //if (MessageBox.Show("ต้องการ ยกเลิก ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            String id = grfDay6Img[grfDay6Img.Row, colDay2ImgId].ToString();
                //ic.cStf.staff_id = "";
                //FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                //frm.ShowDialog(this);
                //if (!ic.cStf.staff_id.Equals(""))
                //{
            String pathfile = grfDay6Img[grfDay6Img.Row, colDay2PathPic].ToString();
            String re = ic.ivfDB.opuEmDevDB.updatePathPic(id, "", "", "", ic.user.staff_id);
            ic.delPicOPUtoServer(txtOpuCode.Text, pathfile);
            grfDay6Img[grfDay6Img.Row, colDay2PathPic] = "";
            grfDay6Img[grfDay6Img.Row, colDay2ImgPic] = null;
            //    }
            //}
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
            else if (grfDay6Img.Col == colDay2StatusBio)
            {
                int row = 0;
                int.TryParse(grfDay6Img.Row.ToString(), out row);
                if(grfDay6Img[row,colDay2StatusBio] == imgFinish)
                {
                    grfDay6Img[row, colDay2StatusBio] = imgTran;
                    grfDay6Img[row, colDay2ImgDesc1] = "";
                }
                else
                {
                    grfDay6Img[row, colDay2StatusBio] = imgFinish;
                    grfDay6Img[row, colDay2ImgDesc1] = "day6";
                }
                grfDay6Img[grfDay6Img.Row, colDay2ImgEdit] = "1";
                grfDay6Img.Rows[grfDay6Img.Row].StyleNew.BackColor = color;
                //setGrfDay6ImgFreezing();
            }
        }
        private void setGrfDay6ImgFreezing()
        {
            int i = 1;            
            foreach (Row row in grfDay6Img.Rows)
            {
                if (row[colDay2ImgDesc0].ToString().Equals("st#")) continue;
                row[colDay2ImgDesc0] = "";
                if (row[colDay2StatusBio] == imgFinish)
                {
                    row[colDay2ImgDesc0] = i;
                    //row[colDay2ImgDesc1] = "day6";
                    i++;
                }
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

            theme1.SetTheme(grfDay2, "Office2010Blue");
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
            int ferti = 0, fertiaddmore = 0;
            int.TryParse(txtFertili2Pn.Text, out ferti);
            int.TryParse(txtFertili2PnAdd.Text, out fertiaddmore);
            if (grfDay2.Row > (ferti + fertiaddmore)) return;
            grfDay2[grfDay2.Row, colDay2Edit] = "1";
            grf2Focus = true;
            grf3Focus = false;
            grf5Focus = false;
            grf6Focus = false;
            //grfDay2[grfDay2.Row, 0] = "1";
            //grfDay2.Rows[grfDay2.Row].
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

            theme1.SetTheme(grfDay6, "Office2010Blue");
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
            int ferti = 0, fertiaddmore = 0;
            int.TryParse(txtFertili2Pn.Text, out ferti);
            int.TryParse(txtFertili2PnAdd.Text, out fertiaddmore);
            if (grfDay2.Row > (ferti + fertiaddmore)) return;
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

            theme1.SetTheme(grfDay3, "Office2010Silver");
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
            int ferti = 0, fertiaddmore = 0;
            int.TryParse(txtFertili2Pn.Text, out ferti);
            int.TryParse(txtFertili2PnAdd.Text, out fertiaddmore);
            if (grfDay2.Row > (ferti + fertiaddmore)) return;
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
            grfDay5.DoubleClick += GrfDay5_DoubleClick;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfDay5.ContextMenu = menuGw;
            pn5Grf.Controls.Add(grfDay5);

            theme1.SetTheme(grfDay5, "Office2010Red");
            //theme1.SetTheme(grfDay6, "Office2016DarkGray");
        }

        private void GrfDay5_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfDay5 == null) return;
            if (grfDay5.Col <= 0) return;
            if (grfDay5.Row <= 0) return;

            if (grfDay5.Col == colDay5ID)
            {
                grfDay6[grfDay5.Row, colDay6Num] = grfDay5[grfDay5.Row, colDay5Num];
                grfDay6[grfDay5.Row, colDay6Desc] = grfDay5[grfDay5.Row, colDay5Desc];
                grfDay6[grfDay5.Row, colDay6Desc1] = grfDay5[grfDay5.Row, colDay5Desc1];
                grfDay6[grfDay5.Row, colDay6Desc2] = grfDay5[grfDay5.Row, colDay5Desc2];
                //grfDay6[grfDay5.Row, colDay6Edit] = "1";
                grfDay6.Rows[grfDay5.Row].StyleNew.BackColor = color;
            }
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
            int ferti = 0, fertiaddmore = 0;
            int.TryParse(txtFertili2Pn.Text, out ferti);
            int.TryParse(txtFertili2PnAdd.Text, out fertiaddmore);
            if (grfDay2.Row > (ferti + fertiaddmore)) return;
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

        private Boolean setGrfDay2()
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
            grfDay2.Cols[colDay2Desc1].Width = 70;
            grfDay2.Cols[colDay2Desc2].Width = 70;
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
            String staffId = "", checkId="", dateday2="";
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
            grfDay2.Cols[colDay2Edit].Visible = false;
            grfDay2.Cols[colDay2Num].AllowSorting = false;
            grfDay2.Cols[colDay2Desc].AllowSorting = false;
            grfDay2.Cols[colDay2Desc1].AllowSorting = false;
            grfDay2.Cols[colDay2Desc2].AllowSorting = false;
            ic.setC1Combo(cboEmbryologistDay2, staffId);
            ic.setC1Combo(cboCheckedDay2, checkId);
            txtDay2Date.Value = dateday2;
            grfDay2.AutoClipboard = true;
            return true;
        }
        private Boolean setGrfDay3()
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
            grfDay3.Cols[colDay3Desc1].Width = 70;
            grfDay3.Cols[colDay3Desc2].Width = 70;
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
            grfDay3.Cols[colDay3Edit].Visible = false;
            grfDay3.Cols[colDay3Num].AllowSorting = false;
            grfDay3.Cols[colDay3Desc].AllowSorting = false;
            grfDay3.Cols[colDay3Desc1].AllowSorting = false;
            grfDay3.Cols[colDay3Desc2].AllowSorting = false;
            ic.setC1Combo(cboEmbryologistDay3, staffId);
            ic.setC1Combo(cboCheckedDay3, checkId);
            txtDay3Date.Value = dateday;
            grfDay3.AutoClipboard = true;

            return true;
        }
        private Boolean setGrfDay5()
        {
            //grfDept.Rows.Count = 7;
            grfDay5.Clear();
            DataTable dt = new DataTable();

            dt = ic.ivfDB.opuEmDevDB.selectByOpuFetId_Day(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day5);
            grfDay5.Rows.Count = 1;
            grfDay5.Cols.Count = 7;
            //Button btn = new Button();
            //C1TextBox txt = new C1TextBox();
            C1ComboBox cboday5 = new C1ComboBox();
            C1ComboBox cboday3desc1 = new C1ComboBox();
            cboday5.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboday5.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboday3desc1.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboday3desc1.AutoCompleteSource = AutoCompleteSource.ListItems;
            ic.ivfDB.fdtDB.setCboOPUStageDay5(cboday5, "");
            ic.ivfDB.fdtDB.setCboOPUStageDay5Desc1(cboday3desc1, "");
            //grfDay5.Cols[colDay5ID].Editor = txt;
            //grfDay5.Cols[colDay5Num].Editor = txt;
            grfDay5.Cols[colDay5Desc].Editor = cboday5;
            grfDay5.Cols[colDay5Desc1].Editor = cboday3desc1;
            //grfDay5.Cols[colDay5Desc2].Editor = txt;
            //grfDay5.Cols[colDay5Copy].Editor = btn;

            grfDay5.Cols[colDay5Num].Width = 40;
            grfDay5.Cols[colDay5Desc].Width = 100;
            grfDay5.Cols[colDay5Desc1].Width = 70;
            grfDay5.Cols[colDay5Desc2].Width = 70;
            //grfDay5.Cols[colDay5Copy].Width = 30;

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
            grfDay5.Cols[colDay5Edit].Visible = false;
            grfDay5.Cols[colDay6Num].AllowSorting = false;
            grfDay5.Cols[colDay5Desc].AllowSorting = false;
            grfDay5.Cols[colDay5Desc1].AllowSorting = false;
            grfDay5.Cols[colDay5Desc2].AllowSorting = false;
            ic.setC1Combo(cboEmbryologistDay5, staffId);
            ic.setC1Combo(cboCheckedDay5, checkId);
            txtDay5Date.Value = dateday;
            grfDay5.AutoClipboard = true;

            return true;
        }
        private Boolean setGrfDay6()
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
            grfDay6.Cols[colDay6Desc1].Width = 70;
            grfDay6.Cols[colDay6Desc2].Width = 70;

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
            grfDay6.Cols[colDay6Edit].Visible = false;
            grfDay6.Cols[colDay6Num].AllowSorting = false;
            grfDay6.Cols[colDay6Desc].AllowSorting = false;
            grfDay6.Cols[colDay6Desc1].AllowSorting = false;
            grfDay6.Cols[colDay6Desc2].AllowSorting = false;
            ic.setC1Combo(cboEmbryologistDay6, staffId);
            ic.setC1Combo(cboCheckedDay6, checkId);
            txtDay6Date.Value = dateday;
            grfDay6.AutoClipboard = true;

            return true;
        }
        private void AddTipsToToolStrip(ToolStrip toolStrip)
        {
            // do not show the default tooltips
            toolStrip.ShowItemToolTips = false;

            // att Html tooltips to each item in the toolStrip
            foreach (ToolStripItem item in toolStrip.Items)
            {
                // get tooltip text
                string text = item.ToolTipText;
                if (text != null && text.Length > 0)
                {
                    // get tooltip image
                    string image = string.Empty;
                    if (item.Image != null)
                    {
                        string imageName = item.Name + ".Image";
                        image = "res://" + imageName;
                    }

                    // build tip
                    StringBuilder tip = new StringBuilder();
                    //tip.AppendFormat("<table><tr><td><img src='{0}'><td style='font:bold 11pt Tahoma'>{1}</table>", image, System.Web.HttpUtility.HtmlEncode(text));

                    //// append general 'get help' tip
                    //if (item != this.helpToolStripButton)
                    //{
                    //    tip.Append("<hr noshade size=1 color=lightBlue>");
                    //    tip.AppendFormat("<table><tr><td><img src='{0}'><td>{1}</table>",
                    //        "res://helpToolStripButton.Image",
                    //        "Press <b>F1</b> for more help.");
                    //}

                    // assign tooltip to item
                    stt.SetToolTip(item, tip.ToString());
                }
            }
        }
        private void FrmLabOPUAdd2_Load(object sender, EventArgs e)
        {
            //if (ic.iniC.statusCheckDonor.Equals("1"))
            //{
            //    label73.Hide();
            //    label72.Hide();
            //    label88.Hide();
            //    txtHnDonor.Hide();
            //    txtNameDonor.Hide();
            //    txtDobDonor.Hide();
            //    btnDonorSearch.Hide();
            //}
            sB1.Text = "Date " + ic.cop.day + "-" + ic.cop.month + "-" + ic.cop.year + " Server " + ic.iniC.hostDB + " FTP " + ic.iniC.hostFTP + "/" + ic.iniC.folderFTP;
        }
    }
}
