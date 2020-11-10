using C1.Win.C1Document;
using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1SuperTooltip;
using C1.Win.FlexViewer;
using clinic_ivf.control;
using clinic_ivf.object1;
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
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.gui
{
    public partial class FrmLabSpermAdd : Form
    {
        IvfControl ic;
        String reqId = "", spermId = "", body = "";
        LabRequest lbReq;
        LabSperm lsperm;
        LabFormA lforma;

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;
        Color color;
        int colImgID = 1, colImgHn = 2, colImgImg = 3, colImgDesc = 4, colImgDesc2 = 5, colImgDesc3 = 6, colImgPathPic = 7, colImgBtn = 8, colImgStatus = 9, colImgDoctor = 10;

        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        String theme2 = "Office2007Blue", flagEdit1="";
        public String StatusSperm = "";
        SmtpClient SmtpServer;
        List<LinkedResource> theEmailImage1 = new List<LinkedResource>();
        C1FlexGrid grfImg;

        Boolean flagEdit = false, flagImg=false;
        public FrmLabSpermAdd(IvfControl ic, String reqid, String spermId, String flagEdit)
        {
            InitializeComponent();
            this.ic = ic;
            reqId = reqid;
            this.spermId = spermId;
            //this.flagEdit = flagEdit;
            if (flagEdit.Equals("edit"))
            {
                this.flagEdit = true;
            }
            else
            {
                this.flagEdit = false;
                if (StatusSperm.Equals("1"))
                {
                    c1SplitterPanel3.Hide();
                }
                else if (StatusSperm.Equals("2"))
                {
                    c1SplitterPanel1.Hide();
                }
                else if (StatusSperm.Equals("3"))
                {
                    c1SplitterPanel7.Hide();
                }
                else if (StatusSperm.Equals("4"))
                {
                    //tC.SelectedTab = TabSpermIUI;
                }
                
            }
            initConfig();
        }
        public FrmLabSpermAdd(IvfControl ic, String reqid, String spermId, String StatusSperm, String flagEdit)
        {
            InitializeComponent();
            this.ic = ic;
            reqId = reqid;
            this.spermId = spermId;
            this.StatusSperm = StatusSperm;
            this.flagEdit1 = flagEdit;
            if (flagEdit.Equals("edit"))
            {
                this.flagEdit = true;
            }
            else
            {
                this.flagEdit = false;
            }
            if (ic.iniC.statusCheckDonor.Equals("1"))
            {
                lsperm = new LabSperm();
                lsperm.status_lab_sperm = StatusSperm;
                if (StatusSperm.Equals("1"))
                {
                    tC.SelectedTab = tabSpermFreezing;
                }
                else if (StatusSperm.Equals("2"))
                {
                    tC.SelectedTab = tabSememAna;
                }
                else if (StatusSperm.Equals("3"))
                {
                    tC.SelectedTab = tabSememPESA;
                }
                else if (StatusSperm.Equals("4"))
                {
                    tC.SelectedTab = TabSpermIUI;
                }
            }
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
            SmtpServer = new SmtpClient("smtp.gmail.com");

            btnSave.Click += BtnSave_Click;
            btnSfSave.Click += BtnSfSave_Click;
            btnPeSave.Click += BtnPeSave_Click;
            btnIuiSave.Click += BtnIuiSave_Click;
            btnPrintSf.Click += BtnPrintSf_Click;
            btnPrintSa.Click += BtnPrintSa_Click;
            btnPrintPesa.Click += BtnPrintPesa_Click;
            btnPrintIui.Click += BtnPrintIui_Click;
            btnAgentEmail.Click += BtnAgentEmail_Click;
            btnSfAgentEmail.Click += BtnSfAgentEmail_Click;
            btnPeSendEmail.Click += BtnPeSendEmail_Click;

            sB1.Text = "";
            bg = txtHnFeMale.BackColor;
            fc = txtHnFeMale.ForeColor;
            ff = txtHnFeMale.Font;
            ic.ivfDB.dtrOldDB.setCboDoctor(cboDoctor, "");
            ic.ivfDB.dtrOldDB.setCboDoctor(cboSfDoctor, "");
            ic.ivfDB.dtrOldDB.setCboDoctor(cboPeDoctor, "");
            ic.ivfDB.dtrOldDB.setCboDoctor(cboIuiDoctor, "");

            //ic.ivfDB.fdtDB.setCboSpermAnalysisAppearanceNew(cboAppearance);
            ic.ivfDB.fdtDB.setCboSpermAnalysisAppearance(cboAppearance);
            ic.ivfDB.fdtDB.setCboSpermAnalysisLiquefaction(cboLiquefaction);
            ic.ivfDB.fdtDB.setCboSpermAnalysisLiquefaction(cboViscosity);
            ic.ivfDB.fdtDB.setCboSpermAnalysisAppearance(cboSfAppearance);
            ic.ivfDB.fdtDB.setCboSpermAnalysisLiquefaction(cboSfLiquefaction);
            ic.ivfDB.fdtDB.setCboSpermAnalysisLiquefaction(cboSfViscosity);
            ic.ivfDB.fdtDB.setCboSpermAnalysisAppearance(cboPeAppearance);
            ic.ivfDB.fdtDB.setCboSpermAnalysisAppearance(cboPeLiquefaction);
            ic.ivfDB.fdtDB.setCboSpermAnalysisAppearance(cboPeViscosity);
            ic.ivfDB.fdtDB.setCboSpermAnalysisAppearance(cboIuiAppearance);
            ic.ivfDB.fdtDB.setCboSpermAnalysisAppearance(cboIuiLiquefaction);
            ic.ivfDB.fdtDB.setCboSpermAnalysisAppearance(cboIuiViscosity);
            ic.ivfDB.fdtDB.setCboSpermAnalysisWbc(cboSfWbc);
            ic.ivfDB.fdtDB.setCboSpermAnalysisNoofVail(cboSfNoofVail);
            ic.ivfDB.fdtDB.setCboSpermAnalysisWbc(cboWbc);

            ic.ivfDB.stfDB.setCboEmbryologist(cboEmbryologistAppv, "");
            ic.ivfDB.stfDB.setCboEmbryologist(cboEmbryologistReport, "");
            ic.ivfDB.stfDB.setCboEmbryologist(cboSfEmbryologistAppv, "");
            ic.ivfDB.stfDB.setCboEmbryologist(cboSfEmbryologistReport, "");
            ic.ivfDB.stfDB.setCboEmbryologist(cboPeEmbryologistAppv, "");
            ic.ivfDB.stfDB.setCboEmbryologist(cboPeEmbryologistReport, "");
            ic.ivfDB.stfDB.setCboEmbryologist(cboIuiEmbryologistAppv, "");
            ic.ivfDB.stfDB.setCboEmbryologist(cboIuiEmbryologistReport, "");
            //ic.setCboSpermAppearance(cboSfAppearance);
            //ic.setCboSpermAppearance(cboSfLiquefaction);
            //ic.setCboSpermAppearance(cboSfViscosity);
            
            txtAbstinenceday.KeyUp += TxtAbstinenceday_KeyUp;
            txtVolume.KeyUp += TxtVolume_KeyUp;
            txtCount.KeyUp += TxtCount_KeyUp;

            txtPeVolume.KeyUp += TxtPeVolume_KeyUp;
            txtPeCount.KeyUp += TxtPeCount_KeyUp;
            txtPeAbstinenceday.KeyUp += TxtPeAbstinenceday_KeyUp;
            txtPeMotility4.KeyUp += TxtPeMotility4_KeyUp;
            txtPeMotility3.KeyUp += TxtPeMotility3_KeyUp;
            txtIuiVolume.KeyUp += TxtIuiVolume_KeyUp;
            txtIuiCount.KeyUp += TxtIuiCount_KeyUp;
            txtIuiMotility4.KeyUp += TxtIuiMotility4_KeyUp;
            txtIuiMotility3.KeyUp += TxtIuiMotility3_KeyUp;
            txtIuiAbstinenceday.KeyUp += TxtIuiAbstinenceday_KeyUp;
            txtIuiMotility.KeyUp += TxtIuiMotility_KeyUp;
            txtPeMotility.KeyUp += TxtPeMotility_KeyUp;

            txtIuiVolumePost.KeyUp += TxtIuiVolumePost_KeyUp;
            txtIuiCountPost.KeyUp += TxtIuiCountPost_KeyUp;
            txtIuiMotilityPost.KeyUp += TxtIuiMotilityPost_KeyUp;
            txtIuiMotility4Post.KeyUp += TxtIuiMotility4Post_KeyUp;
            txtIuiMotility3Post.KeyUp += TxtIuiMotility3Post_KeyUp;

            //txtPeTail1.KeyUp += TxtPeTail1_KeyUp;
            txtPePh.KeyUp += TxtPePh_KeyUp;
            //txtPeNormal.KeyUp += TxtPeNormal_KeyUp;
            
            txtSfVolume.KeyUp += TxtSfVolume_KeyUp;
            txtSfCount.KeyUp += TxtSfCount_KeyUp;
            txtSfAbstinenceday.KeyUp += TxtSfAbstinenceday_KeyUp;
            txtSfMotility4.KeyUp += TxtSfMotility4_KeyUp;
            txtSfMotility3.KeyUp += TxtSfMotility3_KeyUp;
            txtSfHead1.KeyUp += TxtSfHead1_KeyUp;
            txtSfNeck1.KeyUp += TxtSfNeck1_KeyUp;
            txtSfTail1.KeyUp += TxtSfTail1_KeyUp;
            txtSfPh.KeyUp += TxtSfPh_KeyUp;
            txtViability.KeyUp += TxtViability_KeyUp;
            btnSfSendEmail.Click += BtnSfSendEmail_Click;
            btnSendEmail.Click += BtnSendEmail_Click;
            SmtpServer.SendCompleted += SmtpServer_SendCompleted;
            btnIuiSendEmail.Click += BtnIuiSendEmail_Click;
            btnSfApproveResult.Click += BtnSfApproveResult_Click;
            btnApproveResult.Click += BtnApproveResult_Click;
            btnIuiApproveResult.Click += BtnIuiApproveResult_Click;
            btnPeApproveResult.Click += BtnPeApproveResult_Click;

            txtMotility4.KeyUp += TxtMotility4_KeyUp;
            txtMotility3.KeyUp += TxtMotility3_KeyUp;
            txtHead1.KeyUp += TxtHead1_KeyUp;
            txtNeck1.KeyUp += TxtNeck1_KeyUp;
            txtTail1.KeyUp += TxtTail1_KeyUp;
            txtPh.KeyUp += TxtPh_KeyUp;
            txtPeVial.KeyUp += TxtPeVial_KeyUp;
            txtPeRecive.KeyUp += TxtPeRecive_KeyUp;
            txtPeExam.KeyUp += TxtPeExam_KeyUp;
            txtPeFinish.KeyUp += TxtPeFinish_KeyUp;


            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            lsperm = new LabSperm();
            lbReq = new LabRequest();
            lforma = new LabFormA();
            lbEmail.Hide();
            lbSfEmail.Hide();

            setControl();
            //setTheme();
            //if (!flagEdit)
            //{
            //    if (lsperm.status_lab_sperm.Equals("1"))
            //    {
            //        c1SplitterPanel3.Hide();
            //    }
            //    else if (lsperm.status_lab_sperm.Equals("2"))
            //    {
            //        c1SplitterPanel1.Hide();
            //    }
            //    else if (lsperm.status_lab_sperm.Equals("3"))
            //    {
            //        c1SplitterPanel7.Hide();
            //    }
            //    else if (lsperm.status_lab_sperm.Equals("4"))
            //    {
            //        //tC.SelectedTab = TabSpermIUI;
            //    }
            //}
        }

        private void TxtPeFinish_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.Enter)
            {
                txtPeApproveResult.Focus();
            }
        }

        private void TxtPeExam_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.Enter)
            {
                txtPeFinish.Focus();
            }
        }
        private void TxtPeRecive_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.Enter)
            {
                txtPeExam.Focus();
            }
        }

        private void TxtPeVial_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if(e.KeyCode == Keys.Enter)
            {
                txtPeEjacula.Focus();
            }
        }

        private void BtnPeApproveResult_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.cStf.staff_id = "";
            FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            frm.ShowDialog(this);
            if (!ic.cStf.staff_id.Equals(""))
            {
                long chk = 0;
                String re = "", re1 = "";
                re = ic.ivfDB.lbReqDB.UpdateStatusRequestResult(lbReq.req_id, ic.cStf.staff_id);
                re1 = ic.ivfDB.lspermDB.updateStatusLabFinish(lsperm.sperm_id, ic.cStf.staff_id);
                //setExport(txtPeID.Text, "");

                String filename = "", datetick = "";
                datetick = DateTime.Now.Ticks.ToString();
                filename = "report\\sperm_pesa_" + datetick + ".pdf";
                if (!Directory.Exists("report"))
                {
                    Directory.CreateDirectory("report");
                }
                if (!setReportSpermPESA1("", filename))
                {
                    return;
                }
                if (File.Exists(filename))
                {
                    long chk1 = 0;
                    String filename1 = Path.GetFileName(filename);
                    ic.savePicOPUtoServer("sperm_" + txtPeID.Text, filename1, filename);
                    ic.ivfDB.lspermDB.updateReportFile(txtPeID.Text, filename1);
                    createReport();
                }

                StringBuilder tip = new StringBuilder();
                // append general 'get help' tip
                tip.AppendFormat("<b>{0}</b> options.", "ได้ส่ง ผลLAB PESA ") ;
                tip.Append("<hr noshade size=1 color=lightBlue>");
                tip.AppendFormat("<table><tr><td><img src='{0}'><td>{1}</table>", "res://helpToolStripButton.Image", "Press <b>F1</b> for more help.");                
                stt.SetToolTip(btnPeApproveResult, tip.ToString());

                if (long.TryParse(re, out chk))
                {
                    panel13.Enabled = true;
                }
            }
        }

        private void TxtIuiMotility3Post_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            Decimal pr = 0, nr = 0, motility = 0;
            Decimal.TryParse(txtIuiMotility4Post.Text, out pr);
            Decimal.TryParse(txtIuiMotility3Post.Text, out nr);
            Decimal.TryParse(txtIuiMotilityPost.Text, out motility);
            if ((pr + nr) != motility)
            {
                sep.SetError(txtIuiMotility3Post, "!= Motility");
            }
            if ((pr + nr) == motility)
            {
                sep.Clear();
            }
            if (e.KeyCode == Keys.Enter)
            {
                txtIuiEjacula.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtIuiMotility4Post.Focus();
            }
        }

        private void TxtIuiMotility4Post_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            Decimal pr = 0, nr = 0, motility = 0;
            Decimal.TryParse(txtIuiMotility4Post.Text, out pr);
            Decimal.TryParse(txtIuiMotility3Post.Text, out nr);
            Decimal.TryParse(txtIuiMotilityPost.Text, out motility);
            if ((pr + nr) != motility)
            {
                sep.SetError(txtIuiMotility4Post, "!= Motility");
            }
            if ((pr + nr) == motility)
            {
                sep.Clear();
            }
            calIUIMotilityPost();
            calIUIMotilePost();
            calIUIIMPost();
            if (e.KeyCode == Keys.Enter)
            {
                txtIuiMotility3Post.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtIuiMotilityPost.Focus();
            }
        }

        private void TxtIuiMotilityPost_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calIUIMotilePost();
            calIUIMotilityPost();
            if (e.KeyCode == Keys.Enter)
            {
                txtIuiMotility4Post.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtIuiCountPost.Focus();
            }
        }

        private void TxtIuiCountPost_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calIUITotalCountPost();
            calIUIMotilePost();
            if (e.KeyCode == Keys.Enter)
            {
                //txtIuiMotilityPost.Focus();
                txtIuiMotility4Post.Focus();
            }
        }

        private void TxtIuiVolumePost_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calIUITotalCountPost();
            calIUIMotilePost();
            if (e.KeyCode == Keys.Enter)
            {
                txtIuiCountPost.Focus();
            }
        }

        private void TxtPeMotility_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            //Decimal motility = 0, im=0;
            //Decimal.TryParse(txtPeMotility.Text, out motility);
            //im = 100 - motility;
            //im = Math.Round(motility, ic.spermFreezingDecimal, MidpointRounding.AwayFromZero);
            //txtPeMotility2.Value = im;
            calPESAMotile();
            calPESAMotility();
            if (e.KeyCode == Keys.Enter)
            {
                txtPeMotility4.Focus();
            }
            else if(e.KeyCode == Keys.Up)
            {
                txtPeCount.Focus();
            }
        }

        private void TxtIuiMotility_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calIUIMotile();
            calIUIMotility();
            if (e.KeyCode == Keys.Enter)
            {
                txtIuiMotility4.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtIuiCount.Focus();
            }
        }

        private void TxtIuiAbstinenceday_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if ((e.KeyCode == Keys.Enter))
            {
                cboIuiAppearance.Focus();
            }
        }

        private void BtnIuiApproveResult_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.cStf.staff_id = "";
            FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            frm.ShowDialog(this);
            if (!ic.cStf.staff_id.Equals(""))
            {
                long chk = 0;
                String re = "", re1 = "";
                re = ic.ivfDB.lbReqDB.UpdateStatusRequestResult(lbReq.req_id, ic.cStf.staff_id);
                re1 = ic.ivfDB.lspermDB.updateStatusLabFinish(lsperm.sperm_id, ic.cStf.staff_id);
                //setExport(txtIuiID.Text, "");

                String filename = "", datetick = "";
                datetick = DateTime.Now.Ticks.ToString();
                filename = "report\\sperm_iui_" + datetick + ".pdf";
                if (!Directory.Exists("report"))
                {
                    Directory.CreateDirectory("report");
                }
                if (!setReportSpermIUI("", filename))
                {
                    return;
                }
                if (File.Exists(filename))
                {
                    long chk1 = 0;
                    String filename1 = Path.GetFileName(filename);
                    ic.savePicOPUtoServer("sperm_" + txtIuiID.Text, filename1, filename);
                    ic.ivfDB.lspermDB.updateReportFile(txtIuiID.Text, filename1);
                    createReport();
                }

                StringBuilder tip = new StringBuilder();
                // append general 'get help' tip
                tip.AppendFormat("<b>{0}</b> options.", "ได้ส่ง ผลLAB IUI ");
                tip.Append("<hr noshade size=1 color=lightBlue>");
                tip.AppendFormat("<table><tr><td><img src='{0}'><td>{1}</table>", "res://helpToolStripButton.Image", "Press <b>F1</b> for more help.");
                stt.SetToolTip(btnIuiApproveResult, tip.ToString());
                if (long.TryParse(re, out chk))
                {
                    panel12.Enabled = true;
                }
            }
        }
        private void BtnApproveResult_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.cStf.staff_id = "";
            FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            frm.ShowDialog(this);
            if (!ic.cStf.staff_id.Equals(""))
            {
                long chk = 0;
                String re = "", re1 = "";
                re = ic.ivfDB.lbReqDB.UpdateStatusRequestResult(lbReq.req_id, ic.cStf.staff_id);
                re1 = ic.ivfDB.lspermDB.updateStatusLabFinish(lsperm.sperm_id, ic.cStf.staff_id);
                String filename = "", datetick = "";
                datetick = DateTime.Now.Ticks.ToString();
                filename = "report\\sperm_analysis_" + datetick + ".pdf";
                if (!Directory.Exists("report"))
                {
                    Directory.CreateDirectory("report");
                }
                if (!setReportSpermAnalysis1("", filename))
                {
                    return;
                }
                if (File.Exists(filename))
                {
                    long chk1 = 0;
                    String filename1 = Path.GetFileName(filename);
                    ic.savePicOPUtoServer("sperm_" + txtID.Text, filename1, filename);
                    ic.ivfDB.lspermDB.updateReportFile(txtID.Text, filename1);
                    createReport();
                }
                StringBuilder tip = new StringBuilder();
                // append general 'get help' tip
                tip.AppendFormat("<b>{0}</b> options.", "ได้ส่ง ผลLAB Sperm ");
                tip.Append("<hr noshade size=1 color=lightBlue>");
                tip.AppendFormat("<table><tr><td><img src='{0}'><td>{1}</table>", "res://helpToolStripButton.Image", "Press <b>F1</b> for more help.");
                stt.SetToolTip(btnApproveResult, tip.ToString());
                if (long.TryParse(re, out chk))
                {
                    panel5.Enabled = true;
                }
            }
        }



        //private void TxtPeNormal_KeyUp(object sender, KeyEventArgs e)
        //{
        //    //throw new NotImplementedException();
        //    int normal = 0, abnor = 0;
        //    int.TryParse(txtPeNormal.Text.Trim(), out normal);
        //    txtPeAbnormal.Value = (100 - normal);
        //}

        private void TxtPeMotility2_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calPESAMotility();
        }

        private void BtnSfAgentEmail_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.email = "";
            FrmAgent frm = new FrmAgent(ic);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog(this);
            txtSfEmailTo.Value = ic.email;
        }

        private void BtnAgentEmail_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.email = "";
            FrmAgent frm = new FrmAgent(ic);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog(this);
            txtEmailTo.Value = ic.email;
        }

        private void BtnSfApproveResult_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.cStf.staff_id = "";
            FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            frm.ShowDialog(this);
            if (!ic.cStf.staff_id.Equals(""))
            {
                long chk = 0;
                String re = "",re1="";
                re = ic.ivfDB.lbReqDB.UpdateStatusRequestResult(lbReq.req_id, ic.cStf.staff_id);
                re1 = ic.ivfDB.lspermDB.updateStatusLabFinish(lsperm.sperm_id, ic.cStf.staff_id);
                //setExport(txtSfID.Text, "");

                String filename = "", datetick = "";
                datetick = DateTime.Now.Ticks.ToString();
                filename = "report\\sperm_freezing_" + datetick + ".pdf";
                if (!Directory.Exists("report"))
                {
                    Directory.CreateDirectory("report");
                }
                if (!setReportSpermFreezing1("", filename))
                {
                    return;
                }
                if (File.Exists(filename))
                {
                    long chk1 = 0;
                    String filename1 = Path.GetFileName(filename);
                    ic.savePicOPUtoServer("sperm_" + txtSfID.Text, filename1, filename);
                    ic.ivfDB.lspermDB.updateReportFile(txtSfID.Text, filename1);
                    createReport();
                }

                StringBuilder tip = new StringBuilder();
                // append general 'get help' tip
                tip.AppendFormat("<b>{0}</b> options.", "ได้ส่ง ผลLAB SF ");
                tip.Append("<hr noshade size=1 color=lightBlue>");
                tip.AppendFormat("<table><tr><td><img src='{0}'><td>{1}</table>", "res://helpToolStripButton.Image", "Press <b>F1</b> for more help.");
                stt.SetToolTip(btnSfApproveResult, tip.ToString());
                if (long.TryParse(re, out chk))
                {
                    pnEmailAddSubject.Enabled = true;
                }
            }
        }

        private void BtnIuiSendEmail_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmWaiting frmW = new FrmWaiting();
            frmW.Show();
            lbPeEmail.Show();
            lbPeEmail.Text = "เตรียม Email";
            Application.DoEvents();
            String filename = "", datetick = "";
            if (!Directory.Exists("report"))
            {
                Directory.CreateDirectory("report");
            }
            datetick = DateTime.Now.Ticks.ToString();
            filename = "report\\sperm_iui_" + datetick + ".pdf";
            lbPeEmail.Text = "เตรียม Email Report";
            Application.DoEvents();
            if (!setReportSpermIUI("", filename))
            {
                return;
            }
            frmW.Dispose();

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(ic.iniC.email_auth_user);
            mail.To.Add(c1TextBox2.Text);
            mail.Subject = c1TextBox1.Text;
            mail.Body = c1TextBox3.Text;

            mail.IsBodyHtml = true;
            if (File.Exists(filename))
            {
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(filename);
                mail.Attachments.Add(attachment);
            }
            lbPeEmail.Text = "เตรียม Email Attach File";
            Application.DoEvents();
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
            mail.AlternateViews.Add(htmlView);

            foreach (LinkedResource linkimg in theEmailImage1)
            {
                htmlView.LinkedResources.Add(linkimg);
            }
            lbPeEmail.Text = "Send Email";
            Application.DoEvents();
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(ic.iniC.email_auth_user, ic.iniC.email_auth_pass);

            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
            lbPeEmail.Text = "ส่ง Email เรียบร้อย";
            Application.DoEvents();
        }
        private void BtnPeSendEmail_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmWaiting frmW = new FrmWaiting();
            frmW.Show();
            lbPeEmail.Show();
            lbPeEmail.Text = "เตรียม Email";
            Application.DoEvents();
            String filename = "", datetick = "";
            if (!Directory.Exists("report"))
            {
                Directory.CreateDirectory("report");
            }
            datetick = DateTime.Now.Ticks.ToString();
            filename = "report\\sperm_pesa_" + datetick + ".pdf";
            lbPeEmail.Text = "เตรียม Email Report";
            Application.DoEvents();
            if (!setReportSpermPESA1("", filename))
            {
                return;
            }
            frmW.Dispose();

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(txtPeEmailTo.Text);
            mail.To.Add(txtPeEmailTo.Text);
            mail.Subject = txtPeEmailSubject.Text;
            mail.Body = txtPeEmailBody.Text;

            mail.IsBodyHtml = true;
            if (File.Exists(filename))
            {
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(filename);
                mail.Attachments.Add(attachment);
            }
            lbPeEmail.Text = "เตรียม Email Attach File";
            Application.DoEvents();
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
            mail.AlternateViews.Add(htmlView);

            foreach (LinkedResource linkimg in theEmailImage1)
            {
                htmlView.LinkedResources.Add(linkimg);
            }
            lbPeEmail.Text = "Send Email";
            Application.DoEvents();
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(ic.iniC.email_auth_user, ic.iniC.email_auth_pass);

            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
            lbPeEmail.Text = "ส่ง Email เรียบร้อย";
            Application.DoEvents();
        }
        private void BtnSendEmail_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmWaiting frmW = new FrmWaiting();
            frmW.Show();
            lbEmail.Show();
            lbEmail.Text = "เตรียม Email";
            Application.DoEvents();
            String filename = "", datetick = "";
            if (!Directory.Exists("report"))
            {
                Directory.CreateDirectory("report");
            }
            datetick = DateTime.Now.Ticks.ToString();
            filename = "report\\sperm_analysis_" + datetick + ".pdf";
            lbEmail.Text = "เตรียม Email Report";
            Application.DoEvents();
            if (!setReportSpermAnalysis1("",filename))
            {
                return;
            }
            frmW.Dispose();

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(ic.iniC.email_auth_user);
            mail.To.Add(txtEmailTo.Text);
            mail.Subject = txtEmailSubject.Text;
            mail.Body = txtEmailBody.Text;

            mail.IsBodyHtml = true;
            if (File.Exists(filename))
            {
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(filename);
                mail.Attachments.Add(attachment);
            }
            lbEmail.Text = "เตรียม Email Attach File";
            Application.DoEvents();
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
            mail.AlternateViews.Add(htmlView);

            foreach (LinkedResource linkimg in theEmailImage1)
            {
                htmlView.LinkedResources.Add(linkimg);
            }
            lbEmail.Text = "Send Email";
            Application.DoEvents();
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(ic.iniC.email_auth_user, ic.iniC.email_auth_pass);

            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
            lbEmail.Text = "ส่ง Email เรียบร้อย";
            Application.DoEvents();
        }

        private void TxtPh_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();

        }

        private void TxtTail1_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (flagEdit)
            {
                calMorphology();
            }
        }

        private void TxtNeck1_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (flagEdit)
            {
                calMorphology();
                if (e.KeyCode == Keys.Enter)
                {
                    txtTail1.Focus();
                }
            }
        }

        private void TxtHead1_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (flagEdit)
            {
                calMorphology();
                if (e.KeyCode == Keys.Enter)
                {
                    txtNeck1.Focus();
                }
            }
        }

        private void TxtMotility3_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (flagEdit)
            {
                calMotility();
                calMotile();
                if (e.KeyCode == Keys.Enter)
                {
                    txtMotility2.Focus();
                }
            }
        }

        private void TxtMotility4_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (flagEdit)
            {
                calMotility();
                calMotile();
                if (e.KeyCode == Keys.Enter)
                {
                    txtMotility3.Focus();
                }
            }
        }

        private void SmtpServer_SendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //throw new NotImplementedException();
            MessageBox.Show("mail send");
        }
        private Boolean setReportSpermAnalysis(String filename)
        {
            Boolean chk1 = true;
            DataTable dt = new DataTable();
            dt = ic.ivfDB.lspermDB.selectByPk(txtID.Text);
            String chk = "", printerDefault = "";
            ReportDocument rpt = new ReportDocument();
            try
            {
                String date1 = dt.Rows[0]["date_report"].ToString();
                String date2 = dt.Rows[0]["date_approve"].ToString();
                date1 = ic.datetimetoShow(dt.Rows[0]["date_report"]);
                date2 = ic.datetimetoShow(dt.Rows[0]["date_approve"]);
                dt.Rows[0]["date_report"] = date1;
                dt.Rows[0]["date_approve"] = date2;
                String appearance = "", appearancetext = "";
                appearance = dt.Rows[0]["appearance"].ToString();
                appearancetext = dt.Rows[0]["appearance_text"].ToString();
                if (appearancetext.Length > 0)
                {
                    //dt.Rows[0]["appearance"] = appearancetext;
                    dt.Rows[0]["doc_type_name_app"] = appearancetext;
                }

                rpt.Load("lab_sperm_sa.rpt");

                rpt.SetDataSource(dt);
                rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                rpt.SetParameterValue("line2", ic.cop.addr1);
                rpt.SetParameterValue("line3", ic.cop.addr2);
                //rpt.SetParameterValue("report_name", " Summary of OPU Report");
                //rpt.SetParameterValue("date1", "" + date1);
                this.crySperm.ReportSource = rpt;
                this.crySperm.Refresh();

                if (File.Exists(filename))
                {
                    File.Delete(filename);
                    System.Threading.Thread.Sleep(200);
                }

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

                rpt.Export();
            }
            catch (Exception ex)
            {
                chk1 = false;
                chk = ex.Message.ToString();
                MessageBox.Show("error " + ex.Message, "");
            }
            return chk1;
        }
        private Boolean setReportSpermFreezing(String filename)
        {
            Boolean chk1 = true;
            DataTable dt = new DataTable();
            dt = ic.ivfDB.lspermDB.selectByPk(txtSfID.Text);
            String chk = "", printerDefault = "";
            ReportDocument rpt = new ReportDocument();
            try
            {
                String date1 = dt.Rows[0]["date_report"].ToString();
                String date2 = dt.Rows[0]["date_approve"].ToString();
                date1 = ic.datetimetoShow(dt.Rows[0]["date_report"]);
                date2 = ic.datetimetoShow(dt.Rows[0]["date_approve"]);
                dt.Rows[0]["date_report"] = date1;
                dt.Rows[0]["date_approve"] = date2;
                String appearance = "", appearancetext = "";
                appearance = dt.Rows[0]["appearance"].ToString();
                appearancetext = dt.Rows[0]["appearance_text"].ToString();
                if (appearancetext.Length > 0)
                {
                    //dt.Rows[0]["appearance"] = appearancetext;
                    dt.Rows[0]["doc_type_name_app"] = appearancetext;
                }

                rpt.Load("lab_sperm_sf.rpt");

                rpt.SetDataSource(dt);
                rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                rpt.SetParameterValue("line2", ic.cop.addr1);
                rpt.SetParameterValue("line3", ic.cop.addr2);
                //rpt.SetParameterValue("report_name", " Summary of OPU Report");
                //rpt.SetParameterValue("date1", "" + date1);
                this.crySperm.ReportSource = rpt;
                this.crySperm.Refresh();

                if (File.Exists(filename))
                {
                    File.Delete(filename);
                    System.Threading.Thread.Sleep(200);
                }

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

                rpt.Export();
            }
            catch (Exception ex)
            {
                chk1 = false;
                chk = ex.Message.ToString();
                MessageBox.Show("error " + ex.Message, "");
            }
            return chk1;
        }
        private void BtnSfSendEmail_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmWaiting frmW = new FrmWaiting();
            frmW.Show();
            lbSfEmail.Show();
            lbSfEmail.Text = "เตรียม Email";
            Application.DoEvents();
            String filename = "", datetick="";
            if (!Directory.Exists("report"))
            {
                Directory.CreateDirectory("report");
            }
            datetick = DateTime.Now.Ticks.ToString();
            filename = "report\\sperm_freezing_"+ datetick + ".pdf";
            lbSfEmail.Text = "เตรียม Email Report";
            Application.DoEvents();
            if (!setReportSpermFreezing1("",filename))
            {
                return;
            }
            frmW.Dispose();

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(ic.iniC.email_auth_user);
            mail.To.Add(txtSfEmailTo.Text);
            mail.Subject = txtSfEmailSubject.Text;
            mail.Body = txtSfEmailBody.Text;

            mail.IsBodyHtml = true;
            if (File.Exists(filename))
            {
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(filename);
                mail.Attachments.Add(attachment);
            }
            lbSfEmail.Text = "เตรียม Email Attach File";
            Application.DoEvents();
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
            mail.AlternateViews.Add(htmlView);

            foreach (LinkedResource linkimg in theEmailImage1)
            {
                htmlView.LinkedResources.Add(linkimg);
            }
            lbSfEmail.Text = "Send Email";
            Application.DoEvents();
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(ic.iniC.email_auth_user, ic.iniC.email_auth_pass);

            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
            lbSfEmail.Text = "ส่ง Email เรียบร้อย";
            Application.DoEvents();
        }

        private void TxtViability_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.Enter)
            {
                txtSfVolume.Focus();
            }
        }
        private void TxtPePh_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.Enter)
            {
                //txtSfViability.Focus();
                txtPeVolume.Focus();
            }
        }
        private void TxtSfPh_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if(e.KeyCode == Keys.Enter)
            {
                //txtSfViability.Focus();
                txtSfVolume.Focus();
            }
        }
        //private void TxtPeTail1_KeyUp(object sender, KeyEventArgs e)
        //{
        //    //throw new NotImplementedException();
        //    calPeMorphology();
        //}
        private void TxtSfTail1_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calSfMorphology();
        }
        //private void TxtPeNeck1_KeyUp(object sender, KeyEventArgs e)
        //{
        //    //throw new NotImplementedException();
        //    calPeMorphology();
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        txtPeTail1.Focus();
        //    }
        //}
        private void TxtSfNeck1_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calSfMorphology();
            if (e.KeyCode == Keys.Enter)
            {
                txtSfTail1.Focus();
            }
        }
        //private void TxtPeHead1_KeyUp(object sender, KeyEventArgs e)
        //{
        //    //throw new NotImplementedException();
        //    calPeMorphology();
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        txtPeNeck1.Focus();
        //    }
        //}
        private void TxtSfHead1_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calSfMorphology();
            if (e.KeyCode == Keys.Enter)
            {
                txtSfNeck1.Focus();
            }
        }
        private void TxtPeMotility3_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            //calPeMotility();
            //calPESAMotile();
            Decimal pr = 0, nr = 0, motility = 0;
            Decimal.TryParse(txtPeMotility4.Text, out pr);
            Decimal.TryParse(txtPeMotility3.Text, out nr);
            Decimal.TryParse(txtPeMotility.Text, out motility);
            if ((pr + nr) != motility)
            {
                sep.SetError(txtPeMotility3, "!= Motility");
            }
            if ((pr + nr) == motility)
            {
                sep.Clear();
            }
            calPeMotility();
            calPESAMotile();
            calPESAIM();
            if (e.KeyCode == Keys.Enter)
            {
                txtPeVial.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtPeMotility4.Focus();
            }
        }
        private void TxtSfMotility3_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calSfMotility();
            calSfMotile();
            if (e.KeyCode == Keys.Enter)
            {
                txtSfMotility2.Focus();
            }
        }
        private void TxtPeMotility4_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            //calPeMotility();
            //calPESAMotile();


            Decimal pr = 0, nr = 0, motility = 0;
            Decimal.TryParse(txtPeMotility4.Text, out pr);
            Decimal.TryParse(txtPeMotility3.Text, out nr);
            Decimal.TryParse(txtPeMotility.Text, out motility);
            if ((pr + nr) != motility)
            {
                sep.SetError(txtPeMotility4, "!= Motility");
            }
            if ((pr + nr) == motility)
            {
                sep.Clear();
            }
            calPeMotility();
            calPESAMotile();
            calPESAIM();
            if (e.KeyCode == Keys.Enter)
            {
                txtPeMotility3.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtPeMotility.Focus();
            }
        }
        private void TxtIuiMotility3_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            //calIUIMotility();
            //calIUIMotile();
            //if (e.KeyCode == Keys.Enter)
            //{
            //    txtIuiMotility2.Focus();
            //}
            Decimal pr = 0, nr = 0, motility = 0;
            Decimal.TryParse(txtIuiMotility4.Text, out pr);
            Decimal.TryParse(txtIuiMotility3.Text, out nr);
            Decimal.TryParse(txtIuiMotility.Text, out motility);
            if ((pr + nr) != motility)
            {
                sep.SetError(txtIuiMotility3, "!= Motility");
            }
            if ((pr + nr) == motility)
            {
                sep.Clear();
            }
            calIUIMotility();
            calIUIMotile();
            calIUIIM();
            if (e.KeyCode == Keys.Enter)
            {
                txtIuiVolumePost.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtIuiMotility4.Focus();
            }
        }
        private void TxtSfMotility4_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calSfMotility();
            calSfMotile();
            if(e.KeyCode == Keys.Enter)
            {
                txtSfMotility3.Focus();
            }
        }
        private void TxtIuiMotility4_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            //calIUIMotility();
            //calIUIMotile();
            //if (e.KeyCode == Keys.Enter)
            //{
            //    txtIuiMotility3.Focus();
            //}
            //else if (e.KeyCode == Keys.Up)
            //{
            //    txtIuiMotility.Focus();
            //}
            Decimal pr = 0, nr = 0, motility = 0;
            Decimal.TryParse(txtIuiMotility4.Text, out pr);
            Decimal.TryParse(txtIuiMotility3.Text, out nr);
            Decimal.TryParse(txtIuiMotility.Text, out motility);
            if ((pr + nr) != motility)
            {
                sep.SetError(txtIuiMotility4, "!= Motility");
            }
            if ((pr + nr) == motility)
            {
                sep.Clear();
            }
            calIUIMotility();
            calIUIMotile();
            calIUIIM();
            if (e.KeyCode == Keys.Enter)
            {
                txtIuiMotility3.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtIuiMotility.Focus();
            }
        }
        private void TxtPeCount_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calPESATotalCount();
            calPESAMotile();
            if (e.KeyCode == Keys.Enter)
            {
                //txtPeMotility.Focus();
                txtPeMotility4.Focus();
            }
        }

        private void TxtPeVolume_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calPESATotalCount();
            calPESAMotile();
            if (e.KeyCode == Keys.Enter)
            {
                txtPeCount.Focus();
            }
        }
        private void TxtSfCount_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calSfTotalCount();
            calSfMotile();
            if (e.KeyCode == Keys.Enter)
            {
                txtSfMotility4.Focus();
            }
        }

        private void TxtSfVolume_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calSfTotalCount();
            calSfMotile();
            if (e.KeyCode == Keys.Enter)
            {
                txtSfCount.Focus();
            }
        }

        private void TxtCount_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calTotalCount();
            calMotile();
            if (e.KeyCode == Keys.Enter)
            {
                txtMotility4.Focus();
            }
        }
        private void TxtIuiCount_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calIUITotalCount();
            calIUIMotile();
            if (e.KeyCode == Keys.Enter)
            {
                //txtIuiMotility.Focus();
                txtIuiMotility4.Focus();
            }
        }
        private void TxtVolume_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calTotalCount();
            calMotile();
            if (e.KeyCode == Keys.Enter)
            {
                txtCount.Focus();
            }
        }
        private void TxtIuiVolume_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calIUITotalCount();
            calIUIMotile();
            if (e.KeyCode == Keys.Enter)
            {
                txtIuiCount.Focus();
            }
        }
        //private void calPeMorphology()
        //{
        //    Decimal head1 = 0, neck1 = 0, tail1 = 0, head = 0, neck = 0, tail = 0, total1 = 0, abnormal = 0;
        //    int head11 = 0, neck11 = 0, tail11 = 0;
        //    Decimal.TryParse(txtPeHead1.Text, out head1);
        //    Decimal.TryParse(txtPeNeck1.Text, out neck1);
        //    Decimal.TryParse(txtPeTail1.Text, out tail1);
        //    total1 = head1 + neck1 + tail1;

        //    calSfAbNormal();
        //    Decimal.TryParse(txtPeAbnormal.Text, out abnormal);
        //    if (total1 <= 0) return;
        //    head = (abnormal * head1) / total1;
        //    neck = (abnormal * neck1) / total1;
        //    tail = (abnormal * tail1) / total1;
        //    head = Math.Round(head);
        //    neck = Math.Round(neck);
        //    tail = Math.Round(tail);
        //    int.TryParse(head.ToString(), out head11);
        //    int.TryParse(neck.ToString(), out neck11);
        //    int.TryParse(tail.ToString(), out tail11);

        //    if ((head11 + neck11 + tail11) != abnormal)
        //    {
        //        Decimal.TryParse(txtPeHead1.Text, out head1);
        //        head = (abnormal * head1) / total1;
        //        neck = (abnormal * neck1) / total1;
        //        tail = (abnormal * tail1) / total1;
        //        Decimal headtemp = 0, necktemp = 0, tailtemp = 0;
        //        int headtemp1 = 0, necktemp1 = 0, tailtemp1 = 0;
        //        headtemp1 = Decimal.ToInt16(head);
        //        headtemp = head - headtemp1;
        //        necktemp1 = Decimal.ToInt16(neck);
        //        necktemp = neck - necktemp1;
        //        tailtemp1 = Decimal.ToInt16(tail);
        //        tailtemp = tail - tailtemp1;
        //        if (headtemp < necktemp)
        //        {
        //            if (headtemp < tailtemp)
        //            {
        //                int.TryParse(headtemp1.ToString(), out head11);
        //            }
        //            else
        //            {
        //                int.TryParse(tailtemp1.ToString(), out tail11);
        //            }
        //        }
        //        else
        //        {
        //            if (necktemp < tailtemp)
        //            {
        //                int.TryParse(necktemp1.ToString(), out neck11);
        //            }
        //            else
        //            {
        //                int.TryParse(tailtemp1.ToString(), out tail11);
        //            }
        //        }
        //        //head = Math.Round(head);
        //    }
        //    txtPeHead.Value = head11;
        //    txtPeNeck.Value = neck11;
        //    txtPeTail.Value = tail11;
        //}
        private void calSfMorphology()
        {
            Decimal head1 = 0, neck1 = 0, tail1 = 0, head=0, neck=0, tail=0, total1=0, abnormal=0;
            int head11 = 0, neck11=0, tail11=0;
            Decimal.TryParse(txtSfHead1.Text, out head1);
            Decimal.TryParse(txtSfNeck1.Text, out neck1);
            Decimal.TryParse(txtSfTail1.Text, out tail1);
            total1 = head1 + neck1 + tail1;

            calSfAbNormal();
            Decimal.TryParse(txtSfAbnormal.Text, out abnormal);
            if (total1 <= 0) return;
            head = (abnormal * head1) / total1;
            neck = (abnormal * neck1) / total1;
            tail = (abnormal * tail1) / total1;
            head = Math.Round(head);
            neck = Math.Round(neck);
            tail = Math.Round(tail);
            int.TryParse(head.ToString(), out head11);
            int.TryParse(neck.ToString(), out neck11);
            int.TryParse(tail.ToString(), out tail11);

            if((head11+ neck11+ tail11) != abnormal)
            {
                Decimal.TryParse(txtSfHead1.Text, out head1);
                head = (abnormal * head1) / total1;
                neck = (abnormal * neck1) / total1;
                tail = (abnormal * tail1) / total1;
                Decimal headtemp = 0, necktemp = 0, tailtemp = 0;
                int headtemp1 = 0, necktemp1 = 0, tailtemp1 = 0;
                headtemp1 = Decimal.ToInt16(head);
                headtemp = head - headtemp1;
                necktemp1 = Decimal.ToInt16(neck);
                necktemp = neck - necktemp1;
                tailtemp1 = Decimal.ToInt16(tail);
                tailtemp = tail - tailtemp1;
                if(headtemp < necktemp)
                {
                    if (headtemp < tailtemp)
                    {
                        int.TryParse(headtemp1.ToString(), out head11);
                    }
                    else
                    {
                        int.TryParse(tailtemp1.ToString(), out tail11);
                    }
                }
                else
                {
                    if (necktemp < tailtemp)
                    {
                        int.TryParse(necktemp1.ToString(), out neck11);
                    }
                    else
                    {
                        int.TryParse(tailtemp1.ToString(), out tail11);
                    }
                }
                //head = Math.Round(head);
            }
            txtSfHead.Value = head11;
            txtSfNeck.Value = neck11;
            txtSfTail.Value = tail11;
        }
        private void calMorphology()
        {
            Decimal head1 = 0, neck1 = 0, tail1 = 0, head = 0, neck = 0, tail = 0, total1 = 0, abnormal = 0;
            int head11 = 0, neck11 = 0, tail11 = 0;
            Decimal.TryParse(txtHead1.Text, out head1);
            Decimal.TryParse(txtNeck1.Text, out neck1);
            Decimal.TryParse(txtTail1.Text, out tail1);
            total1 = head1 + neck1 + tail1;

            calAbNormal();
            Decimal.TryParse(txtAbnormal.Text, out abnormal);
            if (total1 <= 0) return;
            head = (abnormal * head1) / total1;
            neck = (abnormal * neck1) / total1;
            tail = (abnormal * tail1) / total1;
            head = Math.Round(head);
            neck = Math.Round(neck);
            tail = Math.Round(tail);
            int.TryParse(head.ToString(), out head11);
            int.TryParse(neck.ToString(), out neck11);
            int.TryParse(tail.ToString(), out tail11);

            if ((head11 + neck11 + tail11) != abnormal)
            {
                Decimal.TryParse(txtHead1.Text, out head1);
                head = (abnormal * head1) / total1;
                neck = (abnormal * neck1) / total1;
                tail = (abnormal * tail1) / total1;
                Decimal headtemp = 0, necktemp = 0, tailtemp = 0;
                int headtemp1 = 0, necktemp1 = 0, tailtemp1 = 0;
                headtemp1 = Decimal.ToInt16(head);
                headtemp = head - headtemp1;
                necktemp1 = Decimal.ToInt16(neck);
                necktemp = neck - necktemp1;
                tailtemp1 = Decimal.ToInt16(tail);
                tailtemp = tail - tailtemp1;
                if (headtemp < necktemp)
                {
                    if (headtemp < tailtemp)
                    {
                        int.TryParse(headtemp1.ToString(), out head11);
                    }
                    else
                    {
                        int.TryParse(tailtemp1.ToString(), out tail11);
                    }
                }
                else
                {
                    if (necktemp < tailtemp)
                    {
                        int.TryParse(necktemp1.ToString(), out neck11);
                    }
                    else
                    {
                        int.TryParse(tailtemp1.ToString(), out tail11);
                    }
                }
                //head = Math.Round(head);
            }
            txtHead.Value = head11;
            txtNeck.Value = neck11;
            txtTail.Value = tail11;
        }
        private void calSfAbNormal()
        {
            Decimal head = 0, neck = 0, tail = 0, abnormal=0, normal=0;
            int abnormal1 = 0;
            //Decimal.TryParse(txtSfHead.Text, out head);
            //Decimal.TryParse(txtSfNeck.Text, out neck);
            //Decimal.TryParse(txtSfTail.Text, out tail);
            //abnormal = head + neck + tail;

            Decimal.TryParse(txtSfNormal.Text, out normal);
            //int.TryParse(abnormal.ToString(), out abnormal1);
            txtSfAbnormal.Value = 100 - normal;
        }
        private void calAbNormal()
        {
            Decimal head = 0, neck = 0, tail = 0, abnormal = 0, normal = 0;
            int abnormal1 = 0;
            //Decimal.TryParse(txtSfHead.Text, out head);
            //Decimal.TryParse(txtSfNeck.Text, out neck);
            //Decimal.TryParse(txtSfTail.Text, out tail);
            //abnormal = head + neck + tail;

            Decimal.TryParse(txtNormal.Text, out normal);
            //int.TryParse(abnormal.ToString(), out abnormal1);
            txtAbnormal.Value = 100 - normal;
        }
        private void calPeMotility()
        {
            Decimal pr = 0, nr = 0, motility = 0;
            Decimal motility1 = 0;
            Decimal.TryParse(txtPeMotility4.Text, out pr);
            Decimal.TryParse(txtPeMotility3.Text, out nr);
            motility = pr + nr;
            Decimal.TryParse(motility.ToString(), out motility1);
            txtPeMotility.Value = motility1;
            txtPeViability.Value = motility1 + 7;
        }
        private void calSfMotility()
        {
            Decimal pr = 0, nr = 0, motility=0;
            Decimal motility1 = 0;
            Decimal.TryParse(txtSfMotility4.Text, out pr);
            Decimal.TryParse(txtSfMotility3.Text, out nr);
            motility = pr + nr;
            Decimal.TryParse(motility.ToString(), out motility1);
            txtSfMotility.Value = motility1;
            txtSfViability.Value = motility1 + 7;
        }
        private void calIUIMotilityPost()
        {
            Decimal pr = 0, nr = 0, motility = 0;
            Decimal motility1 = 0;
            Decimal.TryParse(txtIuiMotility4Post.Text, out pr);
            Decimal.TryParse(txtIuiMotility3Post.Text, out nr);
            motility = pr + nr;
            Decimal.TryParse(motility.ToString(), out motility1);
            txtIuiMotilityPost.Value = motility1;
            //txtSfViability.Value = motility1 + 7;
            //Decimal motility = 0, im = 0;
            //Decimal.TryParse(txtIuiMotilityPost.Text, out motility);
            //im = 100 - motility;
            //im = Math.Round(im, ic.spermFreezingDecimal, MidpointRounding.AwayFromZero);
            //txtIuiMotility2Post.Value = im;
        }
        private void calIUIMotility()
        {
            Decimal pr = 0, nr = 0, motility = 0;
            Decimal motility1 = 0;
            Decimal.TryParse(txtIuiMotility4.Text, out pr);
            Decimal.TryParse(txtIuiMotility3.Text, out nr);
            motility = pr + nr;
            Decimal.TryParse(motility.ToString(), out motility1);
            txtIuiMotility.Value = motility1;
            //txtSfViability.Value = motility1 + 7;

            //Decimal motility = 0, im = 0;
            //Decimal.TryParse(txtIuiMotility.Text, out motility);
            //im = 100 - motility;
            //im = Math.Round(im, ic.spermFreezingDecimal, MidpointRounding.AwayFromZero);
            //txtIuiMotility2.Value = im;
        }
        private void calMotility()
        {
            Decimal pr = 0, nr = 0, motility = 0;
            Decimal motility1 = 0;
            Decimal.TryParse(txtMotility4.Text, out pr);
            Decimal.TryParse(txtMotility3.Text, out nr);
            motility = pr + nr;
            Decimal.TryParse(motility.ToString(), out motility1);
            txtMotility.Value = motility1;
            txtViability.Value = motility1 + 7;
        }
        private void calSfTotalCount()
        {
            Decimal vol = 0, cnt = 0, totalcnt = 0;
            Decimal totalcnt1 = 0;
            Decimal.TryParse(txtSfVolume.Text, out vol);
            Decimal.TryParse(txtSfCount.Text, out cnt);
            totalcnt = vol * cnt;
            totalcnt = Math.Round(totalcnt,ic.spermFreezingDecimal, MidpointRounding.AwayFromZero);
            //Decimal.TryParse(totalcnt.ToString(), out totalcnt1);
            txtSfTotalCount.Value = totalcnt;
        }
        private void calPESATotalCount()
        {
            Decimal vol = 0, cnt = 0, totalcnt = 0;
            Decimal totalcnt1 = 0;
            Decimal.TryParse(txtPeVolume.Text, out vol);
            Decimal.TryParse(txtPeCount.Text, out cnt);
            totalcnt = vol * cnt;
            totalcnt = Math.Round(totalcnt, ic.spermFreezingDecimal, MidpointRounding.AwayFromZero);
            //Decimal.TryParse(totalcnt.ToString(), out totalcnt1);
            txtPeTotalCount.Value = totalcnt;
        }
        private void calPeMotile()
        {
            Decimal motilitysf = 0, cntsf = 0, motile = 0, vol = 0, totalmotile = 0;
            Decimal motile1 = 0, totalmotile1 = 0;
            Decimal.TryParse(txtPeMotility.Text, out motilitysf);
            Decimal.TryParse(txtPeCount.Text, out cntsf);
            Decimal.TryParse(txtPeVolume.Text, out vol);
            motile = (motilitysf * cntsf) / 100;
            motile = Math.Round(motile, ic.spermFreezingDecimal, MidpointRounding.AwayFromZero);
            Decimal.TryParse(motile.ToString(), out motile1);
            txtPeMotile.Value = motile1;

            totalmotile = motile * vol;
            totalmotile = Math.Round(totalmotile, ic.spermFreezingDecimal, MidpointRounding.AwayFromZero);
            Decimal.TryParse(totalmotile.ToString(), out totalmotile1);
            txtPeTotalMotile.Value = totalmotile1;
        }
        private void calSfMotile()
        {
            Decimal motilitysf = 0, cntsf = 0, motile=0, vol=0, totalmotile=0;
            Decimal motile1 = 0, totalmotile1=0;
            Decimal.TryParse(txtSfMotility.Text, out motilitysf);
            Decimal.TryParse(txtSfCount.Text, out cntsf);
            Decimal.TryParse(txtSfVolume.Text, out vol);
            motile = (motilitysf * cntsf) / 100;
            motile = Math.Round(motile, ic.spermFreezingDecimal, MidpointRounding.AwayFromZero);
            Decimal.TryParse(motile.ToString(), out motile1);
            txtSfMotile.Value = motile1;

            totalmotile = motile * vol;
            totalmotile = Math.Round(totalmotile, ic.spermFreezingDecimal, MidpointRounding.AwayFromZero);
            Decimal.TryParse(totalmotile.ToString(), out totalmotile1);
            txtSfTotalMotile.Value = totalmotile1;
        }
        private void calIuiMotile()
        {
            Decimal motilitysf = 0, cntsf = 0, motile = 0, vol = 0, totalmotile = 0;
            Decimal motile1 = 0, totalmotile1 = 0;
            Decimal.TryParse(txtIuiMotility.Text, out motilitysf);
            Decimal.TryParse(txtIuiCount.Text, out cntsf);
            Decimal.TryParse(txtIuiVolume.Text, out vol);
            motile = (motilitysf * cntsf) / 100;
            motile = Math.Round(motile, ic.spermFreezingDecimal, MidpointRounding.AwayFromZero);
            Decimal.TryParse(motile.ToString(), out motile1);
            txtIuiMotile.Value = motile1;

            totalmotile = motile * vol;
            totalmotile = Math.Round(totalmotile, ic.spermFreezingDecimal, MidpointRounding.AwayFromZero);
            Decimal.TryParse(totalmotile.ToString(), out totalmotile1);
            txtIuiTotalMotile.Value = totalmotile1;
        }
        private void calPESAMotile()
        {
            Decimal motilityPe = 0, cntPe = 0, motile = 0, vol = 0, totalmotile = 0;
            Decimal motile1 = 0, totalmotile1 = 0;
            Decimal.TryParse(txtPeMotility.Text, out motilityPe);
            Decimal.TryParse(txtPeCount.Text, out cntPe);
            Decimal.TryParse(txtPeVolume.Text, out vol);
            motile = (motilityPe * cntPe) / 100;
            motile = Math.Round(motile, ic.spermFreezingDecimal, MidpointRounding.AwayFromZero);
            Decimal.TryParse(motile.ToString(), out motile1);
            txtPeMotile.Value = motile1;

            totalmotile = motile * vol;
            totalmotile = Math.Round(totalmotile, ic.spermFreezingDecimal, MidpointRounding.AwayFromZero);
            Decimal.TryParse(totalmotile.ToString(), out totalmotile1);
            txtPeTotalMotile.Value = totalmotile1;
        }
        private void calPESAMotility()
        {
            Decimal pr = 0, nr = 0;
            Decimal motility2 = 0;

            Decimal motility = 0, im = 0;
            Decimal.TryParse(txtPeMotility.Text, out motility);
            im = 100 - motility;
            im = Math.Round(im, ic.spermFreezingDecimal, MidpointRounding.AwayFromZero);
            txtPeMotility2.Value = im;

            Decimal.TryParse(txtPeMotility4.Text, out pr);
            Decimal.TryParse(txtPeMotility3.Text, out nr);
            motility2 = pr + nr;
            //Decimal.TryParse(txtPeMotility2.Text, out motility2);
            //txtPeMotility.Value = 100 - motility2;
            txtPeViability.Value = motility + 7;
        }
        private void calIUIIM()
        {
            Decimal pr = 0, nr = 0;
            Decimal motility2 = 0;

            Decimal motility = 0, im = 0;
            Decimal.TryParse(txtIuiMotility.Text, out motility);
            im = 100 - motility;
            im = Math.Round(im, ic.spermFreezingDecimal, MidpointRounding.AwayFromZero);
            txtIuiMotility2.Value = im;

            //Decimal.TryParse(txtPeMotility4.Text, out pr);
            //Decimal.TryParse(txtPeMotility3.Text, out nr);
            //motility2 = pr + nr;
            ////Decimal.TryParse(txtPeMotility2.Text, out motility2);
            //txtIuiMotility.Value = 100 - motility2;
            //txtIuViability.Value = motility + /*7*/;
        }
        private void calIUIIMPost()
        {
            Decimal pr = 0, nr = 0;
            Decimal motility2 = 0;

            Decimal motility = 0, im = 0;
            Decimal.TryParse(txtIuiMotilityPost.Text, out motility);
            im = 100 - motility;
            im = Math.Round(im, ic.spermFreezingDecimal, MidpointRounding.AwayFromZero);
            txtIuiMotility2Post.Value = im;
        }
        private void calPESAIM()
        {
            Decimal pr = 0, nr = 0;
            Decimal motility2 = 0;

            Decimal motility = 0, im = 0;
            Decimal.TryParse(txtPeMotility.Text, out motility);
            im = 100 - motility;
            im = Math.Round(im, ic.spermFreezingDecimal, MidpointRounding.AwayFromZero);
            txtPeMotility2.Value = im;

            //Decimal.TryParse(txtPeMotility4.Text, out pr);
            //Decimal.TryParse(txtPeMotility3.Text, out nr);
            //motility2 = pr + nr;
            //Decimal.TryParse(txtPeMotility2.Text, out motility2);
            //txtPeMotility.Value = 100 - motility2;
            txtPeViability.Value = motility + 7;
        }
        private void calIUITotalCountPost()
        {
            Decimal vol = 0, cnt = 0, totalcnt = 0;
            Decimal totalcnt1 = 0;
            Decimal.TryParse(txtIuiVolumePost.Text, out vol);
            Decimal.TryParse(txtIuiCountPost.Text, out cnt);
            totalcnt = vol * cnt;
            totalcnt = Math.Round(totalcnt, ic.spermFreezingDecimal, MidpointRounding.AwayFromZero);
            //Decimal.TryParse(totalcnt.ToString(), out totalcnt1);
            txtIuiTotalCountPost.Value = totalcnt;
        }
        private void calIUITotalCount()
        {
            Decimal vol = 0, cnt = 0, totalcnt = 0;
            Decimal totalcnt1 = 0;
            Decimal.TryParse(txtIuiVolume.Text, out vol);
            Decimal.TryParse(txtIuiCount.Text, out cnt);
            totalcnt = vol * cnt;
            totalcnt = Math.Round(totalcnt, ic.spermFreezingDecimal, MidpointRounding.AwayFromZero);
            //Decimal.TryParse(totalcnt.ToString(), out totalcnt1);
            txtIuiTotalCount.Value = totalcnt;
        }
        private void calTotalCount()
        {
            Decimal vol = 0, cnt = 0, totalcnt = 0;
            Decimal totalcnt1 = 0;
            Decimal.TryParse(txtVolume.Text, out vol);
            Decimal.TryParse(txtCount.Text, out cnt);
            totalcnt = vol * cnt;
            totalcnt = Math.Round(totalcnt, ic.spermFreezingDecimal, MidpointRounding.AwayFromZero);
            //Decimal.TryParse(totalcnt.ToString(), out totalcnt1);
            txtTotalCount.Value = totalcnt;
        }
        private void calMotile()
        {
            Decimal motilitysf = 0, cntsf = 0, motile = 0, vol = 0, totalmotile = 0;
            Decimal motile1 = 0, totalmotile1 = 0;
            Decimal.TryParse(txtMotility.Text, out motilitysf);
            Decimal.TryParse(txtCount.Text, out cntsf);
            Decimal.TryParse(txtVolume.Text, out vol);
            motile = (motilitysf * cntsf) / 100;
            motile = Math.Round(motile, ic.spermFreezingDecimal, MidpointRounding.AwayFromZero);
            Decimal.TryParse(motile.ToString(), out motile1);
            txtMotile.Value = motile1;

            totalmotile = motile * vol;
            totalmotile = Math.Round(totalmotile, ic.spermFreezingDecimal, MidpointRounding.AwayFromZero);
            Decimal.TryParse(totalmotile.ToString(), out totalmotile1);
            txtTotalMotile.Value = totalmotile1;
        }
        private void calIUIMotile()
        {
            Decimal motilitysf = 0, cntsf = 0, motile = 0, vol = 0, totalmotile = 0;
            Decimal motile1 = 0, totalmotile1 = 0;
            Decimal.TryParse(txtIuiMotility.Text, out motilitysf);
            Decimal.TryParse(txtIuiCount.Text, out cntsf);
            Decimal.TryParse(txtIuiVolume.Text, out vol);
            motile = (motilitysf * cntsf) / 100;
            motile = Math.Round(motile, ic.spermFreezingDecimal, MidpointRounding.AwayFromZero);
            Decimal.TryParse(motile.ToString(), out motile1);
            txtIuiMotile.Value = motile1;

            totalmotile = motile * vol;
            totalmotile = Math.Round(totalmotile, ic.spermFreezingDecimal, MidpointRounding.AwayFromZero);
            Decimal.TryParse(totalmotile.ToString(), out totalmotile1);
            txtIuiTotalMotile.Value = totalmotile1;
        }
        private void calIUIMotilePost()
        {
            Decimal motilitysf = 0, cntsf = 0, motile = 0, vol = 0, totalmotile = 0;
            Decimal motile1 = 0, totalmotile1 = 0;
            Decimal.TryParse(txtIuiMotilityPost.Text, out motilitysf);
            Decimal.TryParse(txtIuiCountPost.Text, out cntsf);
            Decimal.TryParse(txtIuiVolumePost.Text, out vol);
            motile = (motilitysf * cntsf) / 100;
            motile = Math.Round(motile, ic.spermFreezingDecimal, MidpointRounding.AwayFromZero);
            Decimal.TryParse(motile.ToString(), out motile1);
            txtIuiMotilePost.Value = motile1;

            totalmotile = motile * vol;
            totalmotile = Math.Round(totalmotile, ic.spermFreezingDecimal, MidpointRounding.AwayFromZero);
            Decimal.TryParse(totalmotile.ToString(), out totalmotile1);
            txtIuiTotalMotilePost.Value = totalmotile1;
        }
        private void TxtAbstinenceday_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if ((e.KeyCode == Keys.Enter))
            {
                if (sender.Equals(txtAbstinenceday))
                {
                    cboAppearance.Focus();
                }
                else if (sender.Equals(txtPh))
                {
                    txtViability.Focus();
                }
                else if (sender.Equals(txtViability))
                {
                    txtVolume.Focus();
                }
                else if (sender.Equals(txtVolume))
                {
                    txtCount.Focus();
                }
                else if (sender.Equals(txtCount))
                {
                    txtTotalCount.Focus();
                }
                else if (sender.Equals(txtTotalCount))
                {
                    txtMotile.Focus();
                }
                else if (sender.Equals(txtMotile))
                {
                    txtTotalMotile.Focus();
                }
                else if (sender.Equals(txtTotalMotile))
                {
                    txtMotility.Focus();
                }
                else if (sender.Equals(txtMotility))
                {
                    txtMotility4.Focus();
                }
                else if (sender.Equals(txtMotility4))
                {
                    txtMotility3.Focus();
                }
                else if (sender.Equals(txtMotility3))
                {
                    txtMotility2.Focus();
                }
                else if (sender.Equals(txtMotility2))
                {
                    //txtWbc.Focus();
                }
                //else if (sender.Equals(txtWbc))
                //{
                //    txtNormal.Focus();
                //}
                else if (sender.Equals(txtNormal))
                {
                    txtAbnormal.Focus();
                }
                else if (sender.Equals(txtAbnormal))
                {
                    txtHead.Focus();
                }
                else if (sender.Equals(txtHead))
                {
                    txtNeck.Focus();
                }
                else if (sender.Equals(txtNeck))
                {
                    txtTail.Focus();
                }
                else if (sender.Equals(txtTail))
                {
                    txtEjacula.Focus();
                }
                else if (sender.Equals(txtEjacula))
                {
                    txtRecive.Focus();
                }
                else if (sender.Equals(txtRecive))
                {
                    txtExam.Focus();
                }
                else if (sender.Equals(txtExam))
                {
                    txtFinish.Focus();
                }
                else if (sender.Equals(txtFinish))
                {
                    btnSave.Focus();
                }
                //else if (sender.Equals(txtExam))
                //{
                //    txtSfViability.Focus();
                //}
            }
        }
        private void TxtPeAbstinenceday_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if ((e.KeyCode == Keys.Enter))
            {
                if (sender.Equals(txtPeAbstinenceday))
                {
                    cboPeAppearance.Focus();
                }
                else if (sender.Equals(txtPePh))
                {
                    txtPeViability.Focus();
                }
                else if (sender.Equals(txtPeViability))
                {
                    txtPeVolume.Focus();
                }
                else if (sender.Equals(txtPeVolume))
                {
                    txtPeCount.Focus();
                }
                else if (sender.Equals(txtPeCount))
                {
                    //txtSfTotalCount.Focus();
                    txtPeMotility4.Focus();
                }
                else if (sender.Equals(txtPeTotalCount))
                {
                    txtPeMotile.Focus();
                }
                else if (sender.Equals(txtPeMotile))
                {
                    txtPeTotalMotile.Focus();
                }
                else if (sender.Equals(txtPeTotalMotile))
                {
                    txtPeMotility.Focus();
                }
                else if (sender.Equals(txtPeMotility))
                {
                    txtPeMotility4.Focus();
                }
                else if (sender.Equals(txtPeMotility4))
                {
                    txtPeMotility3.Focus();
                }
                else if (sender.Equals(txtPeMotility3))
                {
                    txtPeMotility2.Focus();
                }
                else if (sender.Equals(txtPeMotility2))
                {
                    //txtPeNormal.Focus();
                }
                //else if (sender.Equals(txtSfWbc))
                //{
                //    txtSfNormal.Focus();
                //}
                //else if (sender.Equals(txtPeNormal))
                //{
                //    //txtSfAbnormal.Focus();
                //    txtPeHead1.Focus();
                //}
                //else if (sender.Equals(txtPeAbnormal))
                //{
                //    txtPeHead.Focus();
                //}
                //else if (sender.Equals(txtPeHead1))
                //{
                //    txtPeNeck1.Focus();
                //}
                //else if (sender.Equals(txtPeNeck1))
                //{
                //    txtPeTail1.Focus();
                //}
                //else if (sender.Equals(txtPeTail))
                //{
                //    txtPeEjacula.Focus();
                //}
                //else if (sender.Equals(txtSfVial))
                //{
                //    txtSfEjacula.Focus();
                //}
                else if (sender.Equals(txtPeEjacula))
                {
                    txtPeRecive.Focus();
                }
                else if (sender.Equals(txtPeRecive))
                {
                    txtPeExam.Focus();
                }
                else if (sender.Equals(txtPeExam))
                {
                    txtPeFinish.Focus();
                }
                else if (sender.Equals(txtPeFinish))
                {
                    btnPeSave.Focus();
                }
            }
        }
        private void TxtSfAbstinenceday_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if ((e.KeyCode == Keys.Enter))
            {
                if (sender.Equals(txtSfAbstinenceday))
                {
                    cboSfAppearance.Focus();
                }
                else if (sender.Equals(txtSfPh))
                {
                    txtSfViability.Focus();
                }
                else if (sender.Equals(txtSfViability))
                {
                    txtSfVolume.Focus();
                }
                else if (sender.Equals(txtSfVolume))
                {
                    txtSfCount.Focus();
                }
                else if (sender.Equals(txtSfCount))
                {
                    //txtSfTotalCount.Focus();
                    txtSfMotility4.Focus();
                }
                else if (sender.Equals(txtSfTotalCount))
                {
                    txtSfMotile.Focus();
                }
                else if (sender.Equals(txtSfMotile))
                {
                    txtSfTotalMotile.Focus();
                }
                else if (sender.Equals(txtSfTotalMotile))
                {
                    txtSfMotility.Focus();
                }
                else if (sender.Equals(txtSfMotility))
                {
                    txtSfMotility4.Focus();
                }
                else if (sender.Equals(txtSfMotility4))
                {
                    txtSfMotility3.Focus();
                }
                else if (sender.Equals(txtSfMotility3))
                {
                    txtSfMotility2.Focus();
                }
                else if (sender.Equals(txtSfMotility2))
                {
                    txtSfNormal.Focus();
                }
                //else if (sender.Equals(txtSfWbc))
                //{
                //    txtSfNormal.Focus();
                //}
                else if (sender.Equals(txtSfNormal))
                {
                    //txtSfAbnormal.Focus();
                    txtSfHead1.Focus();
                }
                else if (sender.Equals(txtSfAbnormal))
                {
                    txtSfHead.Focus();
                }
                else if (sender.Equals(txtSfHead1))
                {
                    txtSfNeck1.Focus();
                }
                else if (sender.Equals(txtSfNeck1))
                {
                    txtSfTail1.Focus();
                }
                else if (sender.Equals(txtSfTail))
                {
                    txtSfEjacula.Focus();
                }
                //else if (sender.Equals(txtSfVial))
                //{
                //    txtSfEjacula.Focus();
                //}
                else if (sender.Equals(txtSfEjacula))
                {
                    txtSfRecive.Focus();
                }
                else if (sender.Equals(txtSfRecive))
                {
                    txtSfExam.Focus();
                }
                else if (sender.Equals(txtSfExam))
                {
                    txtSfFinish.Focus();
                }
                else if (sender.Equals(txtSfFinish))
                {
                    btnSfSave.Focus();
                }
            }
        }

        private void BtnPrintIui_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmReport frm = new FrmReport(ic);
            DataTable dt = new DataTable();
            dt = ic.ivfDB.lspermDB.selectByPk(txtIuiID.Text);
            //FrmWaiting frmW = new FrmWaiting();
            //frmW.Show();
            frm.setSpermIui(dt);
            frm.ShowDialog(this);
        }

        private void BtnPrintPesa_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmReport frm = new FrmReport(ic);
            DataTable dt = new DataTable();
            dt = ic.ivfDB.lspermDB.selectByPk(txtPeID.Text);
            ////dt.Columns.Add("no_of_vial", typeof(String));
            String date1 = ic.datetoShow(dt.Rows[0]["date_report"].ToString());
            String date2 = ic.datetoShow(dt.Rows[0]["date_approve"].ToString());
            String datemale = dt.Rows[0]["dob_male"].ToString();
            //date1 = ic.datetimetoShow(dt.Rows[0]["date_report"]);
            //date2 = ic.datetimetoShow(dt.Rows[0]["date_approve"]);
            dt.Rows[0]["date_report"] = date1;
            dt.Rows[0]["date_approve"] = date2;
            String noofvial = "";
            noofvial = dt.Rows[0]["no_of_vail"].ToString();
            dt.Rows[0]["no_of_vial"] = noofvial;
            dt.Rows[0]["date_approve"] = date2;
            datemale = ic.datetoShow(dt.Rows[0]["dob_male"]);
            dt.Rows[0]["dob_male"] = datemale;
            //FrmWaiting frmW = new FrmWaiting();
            //frmW.Show();
            frm.setSpermPesa(dt);
            frm.ShowDialog(this);
        }

        private void BtnPrintSa_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmReport frm = new FrmReport(ic);
            DataTable dt = new DataTable();
            dt = ic.ivfDB.lspermDB.selectByPk(txtID.Text);
            //FrmWaiting frmW = new FrmWaiting();
            //frmW.Show();
            String date1 = ic.datetoShow(dt.Rows[0]["date_report"].ToString());
            String date2 = ic.datetoShow(dt.Rows[0]["date_approve"].ToString());
            String datemale = dt.Rows[0]["dob_male"].ToString();
            //date1 = ic.datetimetoShow(dt.Rows[0]["date_report"]);
            //date2 = ic.datetimetoShow(dt.Rows[0]["date_approve"]);
            dt.Rows[0]["date_report"] = date1;
            dt.Rows[0]["date_approve"] = date2;

            datemale = ic.datetoShow(dt.Rows[0]["dob_male"]);
            dt.Rows[0]["dob_male"] = datemale;
            String appearance = "", appearancetext = "";
            appearance = dt.Rows[0]["appearance"].ToString();
            appearancetext = dt.Rows[0]["appearance_text"].ToString();
            if (appearancetext.Length > 0)
            {
                //dt.Rows[0]["appearance"] = appearancetext;
                dt.Rows[0]["doc_type_name_app"] = appearancetext;
            }
            frm.setSpermSa(dt);
            frm.ShowDialog(this);
        }
        private Boolean setReportSpermPESA1(String flag, String filename)
        {
            Boolean chk1 = true;
            DataTable dt = new DataTable();
            dt = ic.ivfDB.lspermDB.selectByPk(txtPeID.Text);
            //FrmWaiting frmW = new FrmWaiting();
            //frmW.Show();
            String date1 = ic.datetoShow(dt.Rows[0]["date_report"].ToString());
            String date2 = ic.datetoShow(dt.Rows[0]["date_approve"].ToString());
            String datemale = dt.Rows[0]["dob_male"].ToString();
            //date1 = ic.datetimetoShow(dt.Rows[0]["date_report"]);
            //date2 = ic.datetimetoShow(dt.Rows[0]["date_approve"]);
            dt.Rows[0]["date_report"] = date1;
            dt.Rows[0]["date_approve"] = date2;
            String noofvial = "";
            noofvial = dt.Rows[0]["no_of_vail"].ToString();
            dt.Rows[0]["no_of_vial"] = noofvial;

            datemale = ic.datetoShow(dt.Rows[0]["dob_male"]);
            dt.Rows[0]["dob_male"] = datemale;
            String appearance = "", appearancetext = "", chk = "";
            appearance = dt.Rows[0]["appearance"].ToString();
            appearancetext = dt.Rows[0]["appearance_text"].ToString();
            if (appearancetext.Length > 0)
            {
                //dt.Rows[0]["appearance"] = appearancetext;
                dt.Rows[0]["doc_type_name_app"] = appearancetext;
            }
            String stf2 = "";
            stf2 = dt.Rows[0]["doctorname"].ToString();
            String[] stf22 = stf2.Split(' ');
            stf2 = (stf22.Length > 2) ? stf22[0] + " " + stf22[1] + " " + stf22[2].Substring(0, 1) + "." : stf2;
            dt.Rows[0]["doctorname"] = stf2;
            if (flag.Equals("print"))
            {
                FrmReport frm = new FrmReport(ic);
                frm.setSpermSa(dt);
                frm.ShowDialog(this);
            }
            else
            {
                try
                {
                    ReportDocument rpt = new ReportDocument();
                    rpt.Load("lab_sperm_pesa.rpt");

                    rpt.SetDataSource(dt);
                    rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                    rpt.SetParameterValue("line2", ic.cop.addr1);
                    rpt.SetParameterValue("line3", ic.cop.addr2);
                    //rpt.SetParameterValue("report_name", " Summary of OPU Report");
                    //rpt.SetParameterValue("date1", "" + date1);
                    this.crySperm.ReportSource = rpt;
                    this.crySperm.Refresh();

                    if (File.Exists(filename))
                    {
                        File.Delete(filename);
                        System.Threading.Thread.Sleep(200);
                    }

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

                    rpt.Export();
                }
                catch (Exception ex)
                {
                    chk1 = false;
                    chk = ex.Message.ToString();
                    MessageBox.Show("error " + ex.Message, "");
                }
            }
            return chk1;
        }
        private Boolean setReportSpermIUI(String flag, String filename)
        {
            Boolean chk1 = true;
            DataTable dt = new DataTable();
            dt = ic.ivfDB.lspermDB.selectByPk(txtIuiID.Text);
            //FrmWaiting frmW = new FrmWaiting();
            //frmW.Show();
            String date1 = ic.datetoShow(dt.Rows[0]["date_report"].ToString());
            String date2 = ic.datetoShow(dt.Rows[0]["date_approve"].ToString());
            String datemale = dt.Rows[0]["dob_male"].ToString();
            //date1 = ic.datetimetoShow(dt.Rows[0]["date_report"]);
            //date2 = ic.datetimetoShow(dt.Rows[0]["date_approve"]);
            dt.Rows[0]["date_report"] = date1;
            dt.Rows[0]["date_approve"] = date2;
            String noofvial = "";
            noofvial = dt.Rows[0]["no_of_vail"].ToString();
            dt.Rows[0]["no_of_vial"] = noofvial;

            datemale = ic.datetoShow(dt.Rows[0]["dob_male"]);
            dt.Rows[0]["dob_male"] = datemale;
            String appearance = "", appearancetext = "", chk = "";
            appearance = dt.Rows[0]["appearance"].ToString();
            appearancetext = dt.Rows[0]["appearance_text"].ToString();
            if (appearancetext.Length > 0)
            {
                //dt.Rows[0]["appearance"] = appearancetext;
                dt.Rows[0]["doc_type_name_app"] = appearancetext;
            }
            String stf2 = "";
            stf2 = dt.Rows[0]["doctorname"].ToString();
            String[] stf22 = stf2.Split(' ');
            stf2 = (stf22.Length > 2) ? stf22[0] + " " + stf22[1] + " " + stf22[2].Substring(0, 1) + "." : stf2;
            dt.Rows[0]["doctorname"] = stf2;
            if (flag.Equals("print"))
            {
                FrmReport frm = new FrmReport(ic);
                frm.setSpermSa(dt);
                frm.ShowDialog(this);
            }
            else
            {
                try
                {
                    ReportDocument rpt = new ReportDocument();
                    rpt.Load("lab_sperm_iui.rpt");

                    rpt.SetDataSource(dt);
                    rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                    rpt.SetParameterValue("line2", ic.cop.addr1);
                    rpt.SetParameterValue("line3", ic.cop.addr2);
                    //rpt.SetParameterValue("report_name", " Summary of OPU Report");
                    //rpt.SetParameterValue("date1", "" + date1);
                    this.crySperm.ReportSource = rpt;
                    this.crySperm.Refresh();

                    if (File.Exists(filename))
                    {
                        File.Delete(filename);
                        System.Threading.Thread.Sleep(200);
                    }

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

                    rpt.Export();
                }
                catch (Exception ex)
                {
                    chk1 = false;
                    chk = ex.Message.ToString();
                    MessageBox.Show("error " + ex.Message, "");
                }
            }
            return chk1;
        }
        private Boolean setReportSpermAnalysis1(String flag, String filename)
        {
            Boolean chk1 = true;
            DataTable dt = new DataTable();
            dt = ic.ivfDB.lspermDB.selectByPk(txtID.Text);
            //FrmWaiting frmW = new FrmWaiting();
            //frmW.Show();
            String date1 = ic.datetoShow(dt.Rows[0]["date_report"].ToString());
            String date2 = ic.datetoShow(dt.Rows[0]["date_approve"].ToString());
            String datemale = dt.Rows[0]["dob_male"].ToString();
            //date1 = ic.datetimetoShow(dt.Rows[0]["date_report"]);
            //date2 = ic.datetimetoShow(dt.Rows[0]["date_approve"]);
            dt.Rows[0]["date_report"] = date1;
            dt.Rows[0]["date_approve"] = date2;

            datemale = ic.datetoShow(dt.Rows[0]["dob_male"]);
            dt.Rows[0]["dob_male"] = datemale;
            String appearance = "", appearancetext = "", chk="";
            appearance = dt.Rows[0]["appearance"].ToString();
            appearancetext = dt.Rows[0]["appearance_text"].ToString();
            if (appearancetext.Length > 0)
            {
                //dt.Rows[0]["appearance"] = appearancetext;
                dt.Rows[0]["doc_type_name_app"] = appearancetext;
            }
            String stf2 = "";
            stf2 = dt.Rows[0]["doctorname"].ToString();
            String[] stf22 = stf2.Split(' ');
            stf2 = (stf22.Length > 2) ? stf22[0] + " " + stf22[1] + " " + stf22[2].Substring(0, 1) + "." : stf2;
            dt.Rows[0]["doctorname"] = stf2;
            if (flag.Equals("print"))
            {
                FrmReport frm = new FrmReport(ic);
                frm.setSpermSa(dt);
                frm.ShowDialog(this);
            }
            else
            {
                try 
                { 
                    ReportDocument rpt = new ReportDocument();
                    rpt.Load("lab_sperm_sa.rpt");

                    rpt.SetDataSource(dt);
                    rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                    rpt.SetParameterValue("line2", ic.cop.addr1);
                    rpt.SetParameterValue("line3", ic.cop.addr2);
                    //rpt.SetParameterValue("report_name", " Summary of OPU Report");
                    //rpt.SetParameterValue("date1", "" + date1);
                    this.crySperm.ReportSource = rpt;
                    this.crySperm.Refresh();

                    if (File.Exists(filename))
                    {
                        File.Delete(filename);
                        System.Threading.Thread.Sleep(200);
                    }

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

                    rpt.Export();
                }
                catch (Exception ex)
                {
                    chk1 = false;
                    chk = ex.Message.ToString();
                    MessageBox.Show("error " + ex.Message, "");
                }
        }
            return chk1;
        }
        private Boolean setReportSpermFreezing1(String flag,String filename)
        {
            Boolean chk1 = true;
            DataTable dt = new DataTable();
            dt = ic.ivfDB.lspermDB.selectByPk(txtSfID.Text);
            String date1 = ic.datetoShow(dt.Rows[0]["date_report"].ToString());
            String date2 = ic.datetoShow(dt.Rows[0]["date_approve"].ToString());
            String datemale = dt.Rows[0]["dob_male"].ToString();
            //date1 = ic.datetimetoShow(dt.Rows[0]["date_report"]);
            //date2 = ic.datetimetoShow(dt.Rows[0]["date_approve"]);
            dt.Rows[0]["date_report"] = date1;
            dt.Rows[0]["date_approve"] = date2;

            datemale = ic.datetoShow(dt.Rows[0]["dob_male"]);
            dt.Rows[0]["dob_male"] = datemale;
            String appearance = "", appearancetext = "";
            appearance = dt.Rows[0]["appearance"].ToString();
            appearancetext = dt.Rows[0]["appearance_text"].ToString();
            if (appearancetext.Length > 0)
            {
                //dt.Rows[0]["appearance"] = appearancetext;
                dt.Rows[0]["doc_type_name_app"] = appearancetext;
            }
            String stf2 = "", chk = "";
            stf2 = dt.Rows[0]["doctorname"].ToString();
            String[] stf22 = stf2.Split(' ');
            stf2 = (stf22.Length > 2) ? stf22[0] + " " + stf22[1] + " " + stf22[2].Substring(0, 1) + "." : stf2;
            dt.Rows[0]["doctorname"] = stf2;
            //FrmWaiting frmW = new FrmWaiting();
            //frmW.Show();
            if (flag.Equals("print"))
            {
                FrmReport frm = new FrmReport(ic);
                frm.setSpermSf(dt);
                frm.ShowDialog(this);
            }
            else
            {
                try { 
                    ReportDocument rpt = new ReportDocument();
                    rpt.Load("lab_sperm_sf.rpt");

                    rpt.SetDataSource(dt);
                    rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                    rpt.SetParameterValue("line2", ic.cop.addr1);
                    rpt.SetParameterValue("line3", ic.cop.addr2);
                    //rpt.SetParameterValue("report_name", " Summary of OPU Report");
                    //rpt.SetParameterValue("date1", "" + date1);
                    this.crySperm.ReportSource = rpt;
                    this.crySperm.Refresh();

                    if (File.Exists(filename))
                    {
                        File.Delete(filename);
                        System.Threading.Thread.Sleep(200);
                    }

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

                    rpt.Export();
                }
                catch (Exception ex)
                {
                    chk1 = false;
                    chk = ex.Message.ToString();
                    MessageBox.Show("error " + ex.Message, "");
                }
            }
            return chk1;
        }
        private void BtnPrintSf_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmReport frm = new FrmReport(ic);
            DataTable dt = new DataTable();
            dt = ic.ivfDB.lspermDB.selectByPk(txtSfID.Text);
            String date1 = ic.datetoShow(dt.Rows[0]["date_report"].ToString());
            String date2 = ic.datetoShow(dt.Rows[0]["date_approve"].ToString());
            String datemale = dt.Rows[0]["dob_male"].ToString();
            //date1 = ic.datetimetoShow(dt.Rows[0]["date_report"]);
            //date2 = ic.datetimetoShow(dt.Rows[0]["date_approve"]);

            dt.Rows[0]["date_report"] = date1;
            dt.Rows[0]["date_approve"] = date2;

            datemale = ic.datetoShow(dt.Rows[0]["dob_male"]);
            dt.Rows[0]["dob_male"] = datemale;
            String appearance = "", appearancetext="";
            appearance = dt.Rows[0]["appearance"].ToString();
            appearancetext = dt.Rows[0]["appearance_text"].ToString();
            if (appearancetext.Length>0)
            {
                //dt.Rows[0]["appearance"] = appearancetext;
                dt.Rows[0]["doc_type_name_app"] = appearancetext;
            }
            String stf2 = "";
            stf2 = dt.Rows[0]["doctorname"].ToString();
            String[] stf22 = stf2.Split(' ');
            stf2 = (stf22.Length > 2) ? stf22[0] + " " + stf22[1] + " " + stf22[2].Substring(0, 1) + "." : stf2;
            dt.Rows[0]["doctorname"] = stf2;
            //FrmWaiting frmW = new FrmWaiting();
            //frmW.Show();
            frm.setSpermSf(dt);
            frm.ShowDialog(this);
        }

        private void BtnIuiSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.cStf.staff_id = "";
            FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            frm.ShowDialog(this);
            if (!ic.cStf.staff_id.Equals(""))
            {
                long chk = 0, chk1 = 0, max = 0;
                setSpermIui();
                String re = ic.ivfDB.lspermDB.insertLabSperm(lsperm, ic.cStf.staff_id);
                if (long.TryParse(re, out chk))
                {
                    sB1.Text = "Save IUI done";
                }
            }
        }
        private void savePESA()
        {
            ic.cStf.staff_id = "";
            FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            frm.ShowDialog(this);
            if (!ic.cStf.staff_id.Equals(""))
            {
                long chk = 0, chk1 = 0, max = 0;
                setSpermPesa();
                String re = ic.ivfDB.lspermDB.insertLabSperm(lsperm, ic.cStf.staff_id);
                if (long.TryParse(re, out chk))
                {
                    sB1.Text = "Save PESA done";
                }
            }
        }
        private void BtnPeSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            savePESA();
        }
        private void saveSF()
        {
            Decimal pr = 0, nr = 0, im = 0, normal = 0, abnormal = 0; ;
            Decimal.TryParse(txtSfMotility4.Text, out pr);
            Decimal.TryParse(txtSfMotility3.Text, out nr);
            Decimal.TryParse(txtSfMotility2.Text, out im);
            if ((pr + nr + im) != 100)
            {
                MessageBox.Show("ผลรวม Progessive + Non-progessive + mmotility ไม่เท่ากับ 100", "");
                return;
            }
            Decimal.TryParse(txtSfNormal.Text, out normal);
            Decimal.TryParse(txtSfAbnormal.Text, out abnormal);
            if ((normal + abnormal) != 100)
            {
                MessageBox.Show("ผลรวม Normal + Abnormal ไม่เท่ากับ 100", "");
                return;
            }

            ic.cStf.staff_id = "";
            FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            frm.ShowDialog(this);
            if (!ic.cStf.staff_id.Equals(""))
            {
                long chk = 0, chk1 = 0, max = 0;
                setSpermFreezing();
                String re = ic.ivfDB.lspermDB.insertLabSperm(lsperm, ic.cStf.staff_id);
                if (long.TryParse(re, out chk))
                {
                    sB1.Text = "Save Freezing done";
                }
            }
        }
        private void BtnSfSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            saveSF();
        }
        private void saveSA()
        {
            ic.cStf.staff_id = "";
            FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            frm.ShowDialog(this);
            if (!ic.cStf.staff_id.Equals(""))
            {
                long chk = 0, chk1 = 0, max = 0;
                setSperm();
                String re = ic.ivfDB.lspermDB.insertLabSperm(lsperm, ic.cStf.staff_id);
                if (long.TryParse(re, out chk))
                {
                    sB1.Text = "Save done";
                }
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            saveSA();
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSfEmailBody_TextChanged(object sender, EventArgs e)
        {

        }

        private void sCFreezing_Click(object sender, EventArgs e)
        {

        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.S | Keys.Control:
                    if (StatusSperm.Equals("1"))        //Freezing
                    {
                        saveSF();
                    }
                    else if (StatusSperm.Equals("2"))   //Analysis
                    {
                        saveSA();
                    }
                    else if (StatusSperm.Equals("3"))   //PESA
                    {
                        savePESA();
                    }
                    else if (StatusSperm.Equals("4"))
                    {

                    }
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void setControlAnalysisReadOnly(Boolean flag)
        {
            txtHnFeMale.ReadOnly = !flag;
            txtHnMale.ReadOnly = !flag;
            txtNameFeMale.ReadOnly = !flag;
            txtNameMale.ReadOnly = !flag;
            txtLabReqCode.ReadOnly = !flag;
            txtLabFormACode.ReadOnly = !flag;
            txtDobFeMale.ReadOnly = !flag;
            txtDobMale.ReadOnly = !flag;
            cboDoctor.ReadOnly = !flag;
            cboAppearance.ReadOnly = !flag;
            cboLiquefaction.ReadOnly = !flag;
            cboViscosity.ReadOnly = !flag;
            cboWbc.ReadOnly = !flag;

            txtSpermDate.ReadOnly = !flag;
            txtAbstinenceday.ReadOnly = !flag;
            txtPh.ReadOnly = !flag;
            txtViability.ReadOnly = !flag;
            txtVolume.ReadOnly  = !flag;
            txtCount.ReadOnly = !flag;
            txtTotalCount.ReadOnly = !flag;
            txtMotile.ReadOnly = !flag;
            txtMotility.ReadOnly = !flag;
            txtTotalMotile.ReadOnly = !flag;
            txtMotility4.ReadOnly = !flag;
            txtMotility3.ReadOnly = !flag;
            txtMotility2.ReadOnly = !flag;
            //txtMotility1.Value = lsperm.motility_rate_1;
            //txtWbc.ReadOnly = !flag;
            txtEjacula.ReadOnly = !flag;
            txtRecive.ReadOnly = !flag;
            txtExam.ReadOnly = !flag;
            txtFinish.ReadOnly = !flag;
            txtNormal.ReadOnly = !flag;
            txtAbnormal.ReadOnly = !flag;
            txtHead.ReadOnly = !flag;
            txtNeck.ReadOnly = !flag;
            txtTail.ReadOnly = !flag;
            txtApproveResult.ReadOnly = !flag;
            txtApproveDate.ReadOnly = !flag;
            //txtSpermTime.Value = lsperm.time;
            cboRemark.ReadOnly = !flag;

            btnSave.Visible = flag;
            btnApproveResult.Visible = flag;
            //ic.setC1ComboByName(cboRemark, lsperm.remark);
        }
        private void setControlSpermFreezingReadOnly(Boolean flag)
        {
            //txtSfID.Value = lsperm.sperm_id;
            txtSfHnFeMale.ReadOnly = !flag;
            txtSfHnMale.ReadOnly = !flag;
            txtSfNameFeMale.ReadOnly = !flag;
            txtSfNameMale.ReadOnly = !flag;
            txtSfLabReqCode.ReadOnly = !flag;
            txtSfLabFormACode.ReadOnly = !flag;
            txtSfDobFeMale.ReadOnly = !flag;
            txtSfDobMale.ReadOnly = !flag;
            cboSfDoctor.ReadOnly = !flag;
            cboSfAppearance.ReadOnly = !flag;
            cboSfLiquefaction.ReadOnly = !flag;
            cboSfViscosity.ReadOnly = !flag;
            cboSfEmbryologistAppv.ReadOnly = !flag;
            cboSfEmbryologistReport.ReadOnly = !flag;
            cboSfEmbryologistReport.ReadOnly = !flag;
            cboSfWbc.ReadOnly = !flag;
            cboSfNoofVail.ReadOnly = !flag;

            txtSfSpermDate.ReadOnly = !flag;
            txtSfAbstinenceday.ReadOnly = !flag;
            txtSfPh.ReadOnly = !flag;
            //txtSfViability.ReadOnly = !flag;
            txtSfVolume.ReadOnly = !flag;
            txtSfCount.ReadOnly = !flag;
            txtSfTotalCount.ReadOnly = !flag;
            txtSfMotile.ReadOnly = !flag;
            txtSfMotility.ReadOnly = !flag;
            txtSfTotalMotile.ReadOnly = !flag;
            txtSfMotility4.ReadOnly = !flag;
            txtSfMotility3.ReadOnly = !flag;
            txtSfMotility2.ReadOnly = !flag;
            //txtSfVial.Value = lsperm.no_of_vail;
            //txtSfWbc.Value = lsperm.wbc;
            txtSfEjacula.ReadOnly = !flag;
            txtSfRecive.ReadOnly = !flag;
            txtSfExam.ReadOnly = !flag;
            txtSfFinish.ReadOnly = !flag;
            txtSfNormal.ReadOnly = !flag;
            txtSfAbnormal.ReadOnly = !flag;
            txtSfHead.ReadOnly = !flag;
            txtSfNeck.ReadOnly = !flag;
            txtSfTail.ReadOnly = !flag;
            txtSfApproveResult.ReadOnly = !flag;
            txtSfApproveDate.ReadOnly = !flag;
            //txtSpermTime.Value = lsperm.time;
            cboSfRemark.ReadOnly = !flag; ;
            //ic.setC1ComboByName(cboSfRemark, lsperm.remark);

            txtSfHead1.ReadOnly = !flag;
            txtSfNeck1.ReadOnly = !flag;
            txtSfTail1.ReadOnly = !flag;

            btnSfSave.Visible = flag;
            btnSfApproveResult.Visible = flag;
            //txtSfEmailTo.ReadOnly = ic.iniC.email_to_sperm_freezing;
            //txtSfEmailSubject.ReadOnly = "Result LAB Sperm Freezing HN " + txtSfHnMale.Text + " Name " + txtSfNameMale.Text + " [" + txtSfLabReqCode.Text + "]";

            //if (!lsperm.status_lab.Equals("5"))
            //{
            //    pnEmailAddSubject.Enabled = false;
            //}

        }
        private void setControlSpermPESAReadOnly(Boolean flag)
        {
            //txtSfID.Value = lsperm.sperm_id;
            txtPeHnFeMale.ReadOnly = !flag;
            txtPeHnMale.ReadOnly = !flag;
            txtPeNameFeMale.ReadOnly = !flag;
            txtPeNameMale.ReadOnly = !flag;
            txtPeLabReqCode.ReadOnly = !flag;
            txtPeLabFormACode.ReadOnly = !flag;
            txtPeDobFeMale.ReadOnly = !flag;
            txtPeDobMale.ReadOnly = !flag;
            cboPeDoctor.ReadOnly = !flag;
            cboPeAppearance.ReadOnly = !flag;
            cboPeLiquefaction.ReadOnly = !flag;
            cboPeViscosity.ReadOnly = !flag;
            cboPeEmbryologistAppv.ReadOnly = !flag;
            cboPeEmbryologistReport.ReadOnly = !flag;
            cboPeEmbryologistReport.ReadOnly = !flag;
            //cboPeWbc.ReadOnly = !flag;
            //cboPeNoofVail.ReadOnly = !flag;

            txtPeSpermDate.ReadOnly = !flag;
            txtPeAbstinenceday.ReadOnly = !flag;
            txtPePh.ReadOnly = !flag;
            //txtSfViability.ReadOnly = !flag;
            txtPeVolume.ReadOnly = !flag;
            txtPeCount.ReadOnly = !flag;
            txtPeTotalCount.ReadOnly = !flag;
            txtPeMotile.ReadOnly = !flag;
            txtPeMotility.ReadOnly = !flag;
            txtPeTotalMotile.ReadOnly = !flag;
            txtPeMotility4.ReadOnly = !flag;
            txtPeMotility3.ReadOnly = !flag;
            txtPeMotility2.ReadOnly = !flag;
            //txtSfVial.Value = lsperm.no_of_vail;
            //txtSfWbc.Value = lsperm.wbc;
            txtPeEjacula.ReadOnly = !flag;
            txtPeRecive.ReadOnly = !flag;
            txtPeExam.ReadOnly = !flag;
            txtPeFinish.ReadOnly = !flag;
            //txtPeNormal.ReadOnly = !flag;
            //txtPeAbnormal.ReadOnly = !flag;
            //txtPeHead.ReadOnly = !flag;
            //txtPeNeck.ReadOnly = !flag;
            //txtPeTail.ReadOnly = !flag;
            txtPeApproveResult.ReadOnly = !flag;
            txtPeApproveDate.ReadOnly = !flag;
            //txtSpermTime.Value = lsperm.time;
            cboPeRemark.ReadOnly = !flag; ;
            //ic.setC1ComboByName(cboSfRemark, lsperm.remark);

            //txtPeHead1.ReadOnly = !flag;
            //txtPeNeck1.ReadOnly = !flag;
            //txtPeTail1.ReadOnly = !flag;

            btnPeSave.Visible = flag;
            btnPeApproveResult.Visible = flag;
            //txtSfEmailTo.ReadOnly = ic.iniC.email_to_sperm_freezing;
            //txtSfEmailSubject.ReadOnly = "Result LAB Sperm Freezing HN " + txtSfHnMale.Text + " Name " + txtSfNameMale.Text + " [" + txtSfLabReqCode.Text + "]";

            //if (!lsperm.status_lab.Equals("5"))
            //{
            //    pnEmailAddSubject.Enabled = false;
            //}

        }
        private void setControlSpermIUIReadOnly(Boolean flag)
        {
            //txtSfID.Value = lsperm.sperm_id;
            txtIuiHnFeMale.ReadOnly = !flag;
            txtIuiHnMale.ReadOnly = !flag;
            txtIuiNameFeMale.ReadOnly = !flag;
            txtIuiNameMale.ReadOnly = !flag;
            txtIuiLabReqCode.ReadOnly = !flag;
            txtIuiLabFormACode.ReadOnly = !flag;
            txtIuiDobFeMale.ReadOnly = !flag;
            txtIuiDobMale.ReadOnly = !flag;
            cboIuiDoctor.ReadOnly = !flag;
            cboIuiAppearance.ReadOnly = !flag;
            cboIuiLiquefaction.ReadOnly = !flag;
            cboIuiViscosity.ReadOnly = !flag;
            cboIuiEmbryologistAppv.ReadOnly = !flag;
            cboIuiEmbryologistReport.ReadOnly = !flag;
            cboIuiEmbryologistReport.ReadOnly = !flag;
            //cboPeWbc.ReadOnly = !flag;
            //cboPeNoofVail.ReadOnly = !flag;

            txtIuiSpermDate.ReadOnly = !flag;
            txtIuiAbstinenceday.ReadOnly = !flag;
            //txtIuiPh.ReadOnly = !flag;
            //txtSfViability.ReadOnly = !flag;
            txtIuiVolume.ReadOnly = !flag;
            txtIuiCount.ReadOnly = !flag;
            txtIuiTotalCount.ReadOnly = !flag;
            txtIuiMotile.ReadOnly = !flag;
            txtIuiMotility.ReadOnly = !flag;
            txtIuiTotalMotile.ReadOnly = !flag;
            txtIuiMotility4.ReadOnly = !flag;
            txtIuiMotility3.ReadOnly = !flag;
            txtIuiMotility2.ReadOnly = !flag;

            txtIuiVolumePost.ReadOnly = !flag;
            txtIuiCountPost.ReadOnly = !flag;
            txtIuiTotalCountPost.ReadOnly = !flag;
            txtIuiMotilePost.ReadOnly = !flag;
            txtIuiMotilityPost.ReadOnly = !flag;
            txtIuiTotalMotilePost.ReadOnly = !flag;
            txtIuiMotility4Post.ReadOnly = !flag;
            txtIuiMotility3Post.ReadOnly = !flag;
            txtIuiMotility2Post.ReadOnly = !flag;

            //txtSfVial.Value = lsperm.no_of_vail;
            //txtSfWbc.Value = lsperm.wbc;
            txtIuiEjacula.ReadOnly = !flag;
            txtIuiRecive.ReadOnly = !flag;
            txtIuiExam.ReadOnly = !flag;
            txtIuiFinish.ReadOnly = !flag;
            //txtPeNormal.ReadOnly = !flag;
            //txtPeAbnormal.ReadOnly = !flag;
            //txtPeHead.ReadOnly = !flag;
            //txtPeNeck.ReadOnly = !flag;
            //txtPeTail.ReadOnly = !flag;
            txtIuiApproveResult.ReadOnly = !flag;
            txtIuiApproveDate.ReadOnly = !flag;
            //txtSpermTime.Value = lsperm.time;
            cboIuiRemark.ReadOnly = !flag; ;
            //ic.setC1ComboByName(cboSfRemark, lsperm.remark);
            //txtIuiEjacula.ReadOnly
            //txtPeHead1.ReadOnly = !flag;
            //txtPeNeck1.ReadOnly = !flag;
            //txtPeTail1.ReadOnly = !flag;

            btnIuiSave.Visible = flag;
            btnIuiApproveResult.Visible = flag;
            //txtSfEmailTo.ReadOnly = ic.iniC.email_to_sperm_freezing;
            //txtSfEmailSubject.ReadOnly = "Result LAB Sperm Freezing HN " + txtSfHnMale.Text + " Name " + txtSfNameMale.Text + " [" + txtSfLabReqCode.Text + "]";

            //if (!lsperm.status_lab.Equals("5"))
            //{
            //    pnEmailAddSubject.Enabled = false;
            //}

        }
        private void setControl()
        {
            lsperm = ic.ivfDB.lspermDB.selectByPk1(spermId);
            lbReq = ic.ivfDB.lbReqDB.selectByPk1(lsperm.req_id);
            lforma = ic.ivfDB.lFormaDB.selectByPk1(lsperm.form_a_id);
            ic.setC1Combo(cboEmbryologistAppv, lsperm.staff_id_report);
            ic.setC1Combo(cboEmbryologistReport, lsperm.staff_id_approve);

            Visit vs = new Visit();
            Patient ptt = new Patient();
            vs = ic.ivfDB.vsDB.selectByPk1(lbReq.visit_id);
            ptt = ic.ivfDB.pttDB.selectByPk1(vs.t_patient_id);
            txtPttId.Value = vs.t_patient_id;
            txtPttIdOld.Value = ptt.t_patient_id_old;

            txtSfApproveDate.Value = lsperm.date_approve;
            txtSfReportDate.Value = lsperm.date_report;
            txtApproveDate.Value = lsperm.date_approve;
            txtReportDate.Value = lsperm.date_report;
            txtPeApproveDate.Value = lsperm.date_approve;
            txtPeReportDate.Value = lsperm.date_report;
            txtIuiApproveDate.Value = lsperm.date_approve;
            txtIuiReportDate.Value = lsperm.date_report;
            //if (ic.iniC.statusCheckDonor.Equals("1"))
            //{
            //    lsperm = new LabSperm();
            //    lsperm.status_lab_sperm = StatusSperm;
            //}
            if (lsperm.status_lab_sperm.Equals("1"))
            {
                setControlSpermFreezing();
                setControlSpermFreezingReadOnly(flagEdit);
            }
            else if (lsperm.status_lab_sperm.Equals("2"))
            {
                setControlAnalysis();
                setControlAnalysisReadOnly(flagEdit);
            }
            else if (lsperm.status_lab_sperm.Equals("3"))
            {
                setControlPesa();
                setControlSpermPESAReadOnly(flagEdit);
            }
            else if (lsperm.status_lab_sperm.Equals("4"))
            {
                setControlIui();
                setControlSpermIUIReadOnly(flagEdit);
            }
            initGrfImg();
            setGrfImg();
        }
        private void setControlAnalysis()
        {
            txtID.Value = lsperm.sperm_id;
            //txtPttId.Value = lsperm.
            txtHnFeMale.Value = lsperm.hn_female;
            txtHnMale.Value = lsperm.hn_male;
            txtNameFeMale.Value = lsperm.name_female;
            txtNameMale.Value = lsperm.name_male;
            txtLabReqCode.Value = lbReq.req_code;
            txtLabFormACode.Value = lforma.form_a_code;
            txtDobFeMale.Value = lsperm.dob_female;
            txtDobMale.Value = lsperm.dob_male;
            ic.setC1Combo(cboDoctor, lsperm.doctor_id);
            ic.setC1Combo(cboAppearance, lsperm.appearance);
            ic.setC1Combo(cboLiquefaction, lsperm.liquefaction);
            ic.setC1Combo(cboViscosity, lsperm.viscosity);
            ic.setC1Combo(cboWbc, lsperm.wbc);

            txtSpermDate.Value = ic.datetoDB(lsperm.sperm_date);
            txtAbstinenceday.Value = lsperm.abstinence_day;
            txtPh.Value = lsperm.ph;
            txtViability.Value = lsperm.viability;
            txtVolume.Value = lsperm.volume1;
            txtCount.Value = lsperm.count1;
            txtTotalCount.Value = lsperm.total_count;
            txtMotile.Value = lsperm.motile;
            txtMotility.Value = lsperm.motility;
            txtTotalMotile.Value = lsperm.total_motile;
            txtMotility4.Value = lsperm.motility_rate_4;
            txtMotility3.Value = lsperm.motility_rate_3;
            txtMotility2.Value = lsperm.motility_rate_2;
            //txtMotility1.Value = lsperm.motility_rate_1;
            //txtWbc.Value = lsperm.wbc;
            txtEjacula.Value = lsperm.ejaculation_time;
            txtRecive.Value = lsperm.recive_time;
            txtExam.Value = lsperm.examination_time;
            txtFinish.Value = lsperm.finish_time;
            txtNormal.Value = lsperm.morphology_normal;
            txtAbnormal.Value = lsperm.morphology_abnormal;
            txtHead.Value = lsperm.morphology_head_defect;
            txtNeck.Value = lsperm.morphology_neck_defect;
            txtTail.Value = lsperm.morphology_tail_defect;
            txtApproveResult.Value = lsperm.staff_id_approve;
            txtApproveDate.Value = lsperm.date_approve;
            //txtSpermTime.Value = lsperm.time;
            ic.ivfDB.lspermDB.setCboRemark(cboRemark);
            ic.setC1ComboByName(cboRemark, lsperm.remark);
            txtEmailTo.Value = ic.iniC.email_to_sperm_freezing;
            txtEmailSubject.Value = "Report Sperm analysis " + DateTime.Now.ToString("dd/MM/") + DateTime.Now.Year + " " + txtNameMale.Text;
            if (!lsperm.status_lab.Equals("5"))
            {
                if (flagEdit1.Equals(""))
                {
                    pnEmailAddSubject.Enabled = true;
                }
                else
                {
                    pnEmailAddSubject.Enabled = false;
                }
            }
            lbSpSaRemark.Text = lforma.sperm_sa_remark;
            txtSpermTime.Value = lsperm.sperm_time;
            //if (lsperm.appearance_text.Length > 0)
            //{
            //    cboAppearance.Text = lsperm.appearance_text;
            //}
        }
        private void setControlSpermFreezing()
        {
            txtSfID.Value = lsperm.sperm_id;
            txtSfHnFeMale.Value = lsperm.hn_female;
            txtSfHnMale.Value = lsperm.hn_male;
            txtSfNameFeMale.Value = lsperm.name_female;
            txtSfNameMale.Value = lsperm.name_male;
            txtSfLabReqCode.Value = lbReq.req_code;
            txtSfLabFormACode.Value = lforma.form_a_code;

            txtSfDobFeMale.Value = lsperm.dob_female;
            txtSfDobMale.Value = lsperm.dob_male;
            ic.setC1Combo(cboSfDoctor, lsperm.doctor_id);
            ic.setC1Combo(cboSfAppearance, lsperm.appearance);
            ic.setC1Combo(cboSfLiquefaction, lsperm.liquefaction);
            ic.setC1Combo(cboSfViscosity, lsperm.viscosity);
            ic.setC1Combo(cboSfEmbryologistAppv, lsperm.staff_id_approve);
            ic.setC1Combo(cboSfEmbryologistReport, lsperm.staff_id_report);
            //ic.setC1Combo(cboSfEmbryologistReport, lsperm.staff_id_report);
            ic.setC1Combo(cboSfWbc, lsperm.wbc);
            ic.setC1Combo(cboSfNoofVail, lsperm.no_of_vail);

            txtSfSpermDate.Value = lsperm.sperm_date;
            txtSfAbstinenceday.Value = lsperm.abstinence_day;
            txtSfPh.Value = lsperm.ph;
            txtSfViability.Value = lsperm.viability;
            txtSfVolume.Value = lsperm.volume1;
            txtSfCount.Value = lsperm.count1;
            txtSfTotalCount.Value = lsperm.total_count;
            txtSfMotile.Value = lsperm.motile;
            txtSfMotility.Value = lsperm.motility;
            txtSfTotalMotile.Value = lsperm.total_motile;
            txtSfMotility4.Value = lsperm.motility_rate_4;
            txtSfMotility3.Value = lsperm.motility_rate_3;
            txtSfMotility2.Value = lsperm.motility_rate_2;
            //txtSfVial.Value = lsperm.no_of_vail;
            //txtSfWbc.Value = lsperm.wbc;
            txtSfEjacula.Value = lsperm.ejaculation_time;
            txtSfRecive.Value = lsperm.recive_time;
            txtSfExam.Value = lsperm.examination_time;
            txtSfFinish.Value = lsperm.finish_time;
            txtSfNormal.Value = lsperm.morphology_normal;
            txtSfAbnormal.Value = lsperm.morphology_abnormal;
            txtSfHead.Value = lsperm.morphology_head_defect;
            txtSfNeck.Value = lsperm.morphology_neck_defect;
            txtSfTail.Value = lsperm.morphology_tail_defect;
            txtSfApproveResult.Value = ic.ivfDB.stfDB.getStaffNameBylStf(lsperm.staff_id_approve);
            txtSfApproveDate.Value = lsperm.date_approve;
            //txtSpermTime.Value = lsperm.time;
            ic.ivfDB.lspermDB.setCboRemark(cboSfRemark);
            ic.setC1ComboByName(cboSfRemark, lsperm.remark);

            txtSfHead1.Value = lsperm.morphology_head_defect1;
            txtSfNeck1.Value = lsperm.morphology_neck_defect1;
            txtSfTail1.Value = lsperm.morphology_tail_defect1;

            txtSfEmailTo.Value = ic.iniC.email_to_sperm_freezing;
            txtSfEmailSubject.Value = "Report Sperm Freezing "+ DateTime.Now.ToString("dd/MM/") + DateTime.Now.Year +" "+txtSfNameMale.Text ;

            if (!lsperm.status_lab.Equals("5"))
            {
                if (flagEdit1.Equals(""))
                {
                    panel5.Enabled = true;
                    txtEmailBody.Enabled = true;
                }
                else
                {
                    panel5.Enabled = false;
                    txtEmailBody.Enabled = false;
                }
            }
            lbSpFzRemark.Text = lforma.sperm_freezing_remark;
            if (lsperm.appearance_text.Length > 0)
            {
                cboSfAppearance.Value = lsperm.appearance_text;
            }
            txtSfSpermTime.Value = lsperm.sperm_time;
        }
        private void setControlPesa()
        {
            txtPeID.Value = lsperm.sperm_id;
            txtPeHnFeMale.Value = lsperm.hn_female;
            txtPeHnMale.Value = lsperm.hn_male;
            txtPeNameFeMale.Value = lsperm.name_female;
            txtPeNameMale.Value = lsperm.name_male;
            txtPeLabReqCode.Value = lbReq.req_code;
            txtPeLabFormACode.Value = lforma.form_a_code;
            txtPeDobFeMale.Value = lsperm.dob_female;
            txtPeDobMale.Value = lsperm.dob_male;
            ic.setC1Combo(cboPeDoctor, lsperm.doctor_id);
            ic.setC1Combo(cboPeAppearance, lsperm.appearance);
            ic.setC1Combo(cboPeLiquefaction, lsperm.liquefaction);
            ic.setC1Combo(cboPeViscosity, lsperm.viscosity);
            ic.setC1Combo(cboPeEmbryologistAppv, lsperm.staff_id_approve);
            ic.setC1Combo(cboPeEmbryologistReport, lsperm.staff_id_report);

            txtPeSpermDate.Value = lsperm.sperm_date;
            txtPeAbstinenceday.Value = lsperm.abstinence_day;
            txtPePh.Value = lsperm.ph;
            txtPeViability.Value = lsperm.viability;
            txtPeVolume.Value = lsperm.volume1;
            txtPeCount.Value = lsperm.count1;
            txtPeTotalCount.Value = lsperm.total_count;
            txtPeMotile.Value = lsperm.motile;
            txtPeMotility.Value = lsperm.motility;
            txtPeTotalMotile.Value = lsperm.total_motile;
            txtPeMotility4.Value = lsperm.motility_rate_4;
            txtPeMotility3.Value = lsperm.motility_rate_3;
            txtPeMotility2.Value = lsperm.motility_rate_2;
            //txtMotility1.Value = lsperm.motility_rate_1;
            txtPeVial.Value = lsperm.no_of_vail;
            txtPeEjacula.Value = lsperm.ejaculation_time;
            txtPeRecive.Value = lsperm.recive_time;
            txtPeExam.Value = lsperm.examination_time;
            txtPeFinish.Value = lsperm.finish_time;
            
            //txtPeNormal.Value = lsperm.morphology_normal;
            //txtPeAbnormal.Value = lsperm.morphology_abnormal;
            //txtPeHead.Value = lsperm.morphology_head_defect;
            //txtPeNeck.Value = lsperm.morphology_neck_defect;
            //txtPeTail.Value = lsperm.morphology_tail_defect;
            txtPeApproveResult.Value = lsperm.staff_id_approve;
            txtPeApproveDate.Value = lsperm.date_approve;
            //txtSpermTime.Value = lsperm.time;
            ic.ivfDB.lspermDB.setCboRemark(cboPeRemark);
            ic.setC1ComboByName(cboPeRemark, lsperm.remark);
            txtPeEmailTo.Value = ic.iniC.email_to_sperm_freezing;
            txtPeEmailSubject.Value = "Report Sperm PESA/TESE " + DateTime.Now.ToString("dd/MM/") + DateTime.Now.Year + " " + txtPeNameMale.Text;
            //txtPeSpermTime.Value = lsperm.examination_time;
            if (!lsperm.status_lab.Equals("5"))
            {
                if (flagEdit1.Equals(""))
                {
                    //pnPeEmailAddSubject.Enabled = true;
                }
                else
                {
                    //pnPeEmailAddSubject.Enabled = false;
                }
            }
            txtPeSpermTime.Value = lsperm.sperm_time;
        }
        private void setControlIui()
        {
            txtIuiID.Value = lsperm.sperm_id;
            txtIuiHnFeMale.Value = lsperm.hn_female;
            txtIuiHnMale.Value = lsperm.hn_male;
            txtIuiNameFeMale.Value = lsperm.name_female;
            txtIuiNameMale.Value = lsperm.name_male;
            txtIuiLabReqCode.Value = lbReq.req_code;
            txtIuiLabFormACode.Value = lforma.form_a_code;
            txtIuiDobFeMale.Value = lsperm.dob_female;
            txtIuiDobMale.Value = lsperm.dob_male;
            ic.setC1Combo(cboIuiDoctor, lsperm.doctor_id);
            ic.setC1Combo(cboIuiAppearance, lsperm.appearance);
            ic.setC1Combo(cboIuiLiquefaction, lsperm.liquefaction);
            ic.setC1Combo(cboIuiViscosity, lsperm.viscosity);
            ic.setC1Combo(cboIuiEmbryologistAppv, lsperm.staff_id_approve);
            ic.setC1Combo(cboIuiEmbryologistReport, lsperm.staff_id_report);

            txtIuiSpermDate.Value = lsperm.sperm_date;
            txtIuiAbstinenceday.Value = lsperm.abstinence_day;
            //txtIuiPh.Value = lsperm.ph;
            //txtIuiViability.Value = lsperm.viability;
            txtIuiVolume.Value = lsperm.volume1;
            txtIuiCount.Value = lsperm.count1;
            txtIuiTotalCount.Value = lsperm.total_count;
            txtIuiMotile.Value = lsperm.motile;
            txtIuiMotility.Value = lsperm.motility;
            txtIuiTotalMotile.Value = lsperm.total_motile;
            txtIuiMotility4.Value = lsperm.motility_rate_4;
            txtIuiMotility3.Value = lsperm.motility_rate_3;
            txtIuiMotility2.Value = lsperm.motility_rate_2;

            txtIuiVolumePost.Value = lsperm.volume1;
            txtIuiCountPost.Value = lsperm.count1;
            txtIuiTotalCountPost.Value = lsperm.total_count;
            txtIuiMotilePost.Value = lsperm.motile;
            txtIuiMotilityPost.Value = lsperm.motility;
            txtIuiTotalMotilePost.Value = lsperm.total_motile;
            txtIuiMotility4Post.Value = lsperm.motility_rate_4;
            txtIuiMotility3Post.Value = lsperm.motility_rate_3;
            txtIuiMotility2Post.Value = lsperm.motility_rate_2;
            //txtMotility1.Value = lsperm.motility_rate_1;
            //txtIuiWbc.Value = lsperm.wbc;
            txtIuiEjacula.Value = lsperm.ejaculation_time;
            txtIuiRecive.Value = lsperm.recive_time;
            txtIuiExam.Value = lsperm.examination_time;
            txtIuiFinish.Value = lsperm.finish_time;
            //txtIuiNormal.Value = lsperm.morphology_normal;
            //txtIuiAbnormal.Value = lsperm.morphology_abnormal;
            //txtIuiHead.Value = lsperm.morphology_head_defect;
            //txtIuiNeck.Value = lsperm.morphology_neck_defect;
            //txtIuiTail.Value = lsperm.morphology_tail_defect;
            txtIuiApproveResult.Value = lsperm.staff_id_approve;
            txtIuiApproveDate.Value = lsperm.date_approve;
            //txtSpermTime.Value = lsperm.time;

            txtIuiVolumePost.Value = lsperm.post_volume1;
            txtIuiCountPost.Value = lsperm.post_count;
            txtIuiTotalCountPost.Value = lsperm.post_total_count;
            txtIuiMotilePost.Value = lsperm.post_motile;
            txtIuiTotalMotilePost.Value = lsperm.post_total_motile;
            txtIuiMotility4Post.Value = lsperm.post_motility_rate_4;
            txtIuiMotility3Post.Value = lsperm.post_motility_rate_3;
            txtIuiMotility2Post.Value = lsperm.post_motility_rate_2;
            txtIuiMotilityPost.Value = lsperm.post_motility;
            ic.ivfDB.lspermDB.setCboRemark(cboIuiRemark);
            ic.setC1ComboByName(cboIuiRemark, lsperm.remark);
            c1TextBox2.Value = ic.iniC.email_to_sperm_freezing;
            c1TextBox1.Value = "Report Sperm IUI " + DateTime.Now.ToString("dd/MM/") + DateTime.Now.Year + " " + txtIuiNameMale.Text;
            txtIuiSpermTime.Value = lsperm.sperm_time;
        }
        private void setSperm()
        {
            lsperm.sperm_id = txtID.Text;
            lsperm.hn_female = txtHnFeMale.Text;
            lsperm.hn_male = txtHnMale.Text;
            lsperm.name_female = txtNameFeMale.Text;
            lsperm.name_male = txtNameMale.Text;
            lbReq.req_code = txtLabReqCode.Text;
            lsperm.dob_female = ic.datetoDB(txtDobFeMale.Text);
            lsperm.dob_male = ic.datetoDB(txtDobMale.Text);
            lsperm.doctor_id = cboDoctor.SelectedItem == null ? "" : ((ComboBoxItem)cboDoctor.SelectedItem).Value;
            lsperm.appearance = cboAppearance.SelectedItem == null ? "" : ((ComboBoxItem)cboAppearance.SelectedItem).Value;
            lsperm.liquefaction = cboLiquefaction.SelectedItem == null ? "" : ((ComboBoxItem)cboLiquefaction.SelectedItem).Value;
            lsperm.viscosity = cboViscosity.SelectedItem == null ? "" : ((ComboBoxItem)cboViscosity.SelectedItem).Value;

            lsperm.sperm_date = ic.datetoDB(txtSpermDate.Text);
            lsperm.abstinence_day = txtAbstinenceday.Text;
            lsperm.ph = txtPh.Text;
            lsperm.viability = txtViability.Text;
            lsperm.volume1 = txtVolume.Text;
            lsperm.count1 = txtCount.Text;
            lsperm.total_count = txtTotalCount.Text;
            lsperm.motile = txtMotile.Text;
            lsperm.motility = txtMotility.Text;
            lsperm.motility_rate_4 = txtMotility4.Text;
            lsperm.motility_rate_3 = txtMotility3.Text;
            lsperm.motility_rate_2 = txtMotility2.Text;
            lsperm.total_motile = txtTotalMotile.Text;
            //lsperm.no_of_vail = txtSfVial.Text;
            //lsperm.wbc = txtWbc.Text;
            lsperm.ejaculation_time = txtEjacula.Text;
            lsperm.recive_time = txtRecive.Text;
            lsperm.examination_time = txtExam.Text;
            lsperm.finish_time = txtFinish.Text;
            lsperm.morphology_normal = txtNormal.Text;
            lsperm.morphology_abnormal = txtAbnormal.Text;
            lsperm.morphology_head_defect = txtHead.Text;
            lsperm.morphology_neck_defect = txtNeck.Text;
            lsperm.morphology_tail_defect = txtTail.Text;
            lsperm.staff_id_approve = txtApproveResult.Text;
            lsperm.date_approve = txtApproveDate.Text;
            lsperm.staff_id_report = cboEmbryologistReport.SelectedItem == null ? "0" : ((ComboBoxItem)cboEmbryologistReport.SelectedItem).Value;
            lsperm.staff_id_approve = cboEmbryologistAppv.SelectedItem == null ? "0" : ((ComboBoxItem)cboEmbryologistAppv.SelectedItem).Value;
            lsperm.date_approve = ic.datetoDB(txtApproveDate.Text);
            lsperm.date_report = ic.datetoDB(txtReportDate.Text);
            lsperm.remark = cboRemark.Text;
            lsperm.appearance_text = cboAppearance.Text.Trim();
            String bbb = "";
            //aaa = ic.getC1Combo(cboSfNoofVail, cboSfNoofVail.Text);
            bbb = ic.getC1Combo(cboWbc, cboWbc.Text);
            //lsperm.wbc = cboSfWbc.SelectedItem == null ? "0" : ((ComboBoxItem)cboSfWbc.SelectedItem).Value;
            //lsperm.no_of_vail = cboSfNoofVail.SelectedItem == null ? "0" : ((ComboBoxItem)cboSfNoofVail.SelectedItem).Value;
            lsperm.wbc = bbb;
            lsperm.sperm_time = txtSpermTime.Text;
        }
        private void setSpermFreezing()
        {
            lsperm.sperm_id = txtSfID.Text;
            lsperm.hn_female = txtSfHnFeMale.Text;
            lsperm.hn_male = txtSfHnMale.Text;
            lsperm.name_female = txtSfNameFeMale.Text;
            lsperm.name_male = txtSfNameMale.Text;
            lbReq.req_code = txtSfLabReqCode.Text;
            lsperm.dob_female = ic.datetoDB(txtSfDobFeMale.Text);
            lsperm.dob_male = ic.datetoDB(txtSfDobMale.Text);
            lsperm.doctor_id = cboSfDoctor.SelectedItem == null ? "" : ((ComboBoxItem)cboSfDoctor.SelectedItem).Value;
            lsperm.appearance = cboSfAppearance.SelectedItem == null ? "" : ((ComboBoxItem)cboSfAppearance.SelectedItem).Value;
            lsperm.liquefaction = cboSfLiquefaction.SelectedItem == null ? "" : ((ComboBoxItem)cboSfLiquefaction.SelectedItem).Value;
            lsperm.viscosity = cboSfViscosity.SelectedItem == null ? "" : ((ComboBoxItem)cboSfViscosity.SelectedItem).Value;

            lsperm.sperm_date = ic.datetoDB(txtSfSpermDate.Text);
            lsperm.abstinence_day = txtSfAbstinenceday.Text;
            lsperm.ph = txtSfPh.Text;
            lsperm.viability = txtSfViability.Text;
            lsperm.volume1 = txtSfVolume.Text;
            lsperm.count1 = txtSfCount.Text;
            lsperm.total_count = txtSfTotalCount.Text;
            lsperm.motile = txtSfMotile.Text;
            lsperm.motility = txtSfMotility.Text;
            lsperm.total_motile = txtSfTotalMotile.Text;
            lsperm.motility_rate_4 = txtSfMotility4.Text;
            lsperm.motility_rate_3 = txtSfMotility3.Text;
            lsperm.motility_rate_2 = txtSfMotility2.Text;
            //lsperm.no_of_vail = txtSfVial.Text;
            //lsperm.wbc = txtSfWbc.Text;
            lsperm.ejaculation_time = txtSfEjacula.Text;
            lsperm.recive_time = txtSfRecive.Text;
            lsperm.examination_time = txtSfExam.Text;
            lsperm.finish_time = txtSfFinish.Text;
            lsperm.morphology_normal = txtSfNormal.Text;
            lsperm.morphology_abnormal = txtSfAbnormal.Text;
            lsperm.morphology_head_defect = txtSfHead.Text;
            lsperm.morphology_neck_defect = txtSfNeck.Text;
            lsperm.morphology_tail_defect = txtSfTail.Text;
            lsperm.staff_id_approve = txtSfApproveResult.Text;
            //lsperm.date_approve = ic.dateTimetoDB(txtSfApproveDate.Text);
            lsperm.staff_id_report = cboSfEmbryologistReport.SelectedItem == null ? "0" : ((ComboBoxItem)cboSfEmbryologistReport.SelectedItem).Value;
            lsperm.staff_id_approve = cboSfEmbryologistAppv.SelectedItem == null ? "0" : ((ComboBoxItem)cboSfEmbryologistAppv.SelectedItem).Value;
            lsperm.date_approve = ic.dateTimetoDB(txtSfApproveDate.Text);
            lsperm.date_report = ic.dateTimetoDB(txtSfReportDate.Text);
            lsperm.remark = cboSfRemark.Text;

            lsperm.morphology_head_defect1 = txtSfHead1.Text;
            lsperm.morphology_neck_defect1 = txtSfNeck1.Text;
            lsperm.morphology_tail_defect1 = txtSfTail1.Text;
            String aaa = "", bbb="";
            aaa = ic.getC1Combo(cboSfNoofVail, cboSfNoofVail.Text);
            bbb = ic.getC1Combo(cboSfWbc, cboSfWbc.Text);
            //lsperm.wbc = cboSfWbc.SelectedItem == null ? "0" : ((ComboBoxItem)cboSfWbc.SelectedItem).Value;
            //lsperm.no_of_vail = cboSfNoofVail.SelectedItem == null ? "0" : ((ComboBoxItem)cboSfNoofVail.SelectedItem).Value;
            lsperm.wbc = bbb;
            lsperm.no_of_vail = aaa;
            lsperm.appearance_text = cboSfAppearance.Text.Trim();
            lsperm.sperm_time = txtSfSpermTime.Text;
        }
        private void setSpermPesa()
        {
            lsperm.sperm_id = txtPeID.Text;
            lsperm.hn_female = txtPeHnFeMale.Text;
            lsperm.hn_male = txtPeHnMale.Text;
            lsperm.name_female = txtPeNameFeMale.Text;
            lsperm.name_male = txtPeNameMale.Text;
            lbReq.req_code = txtPeLabReqCode.Text;
            lsperm.dob_female = ic.datetoDB(txtPeDobFeMale.Text);
            lsperm.dob_male = ic.datetoDB(txtPeDobMale.Text);
            lsperm.doctor_id = cboPeDoctor.SelectedItem == null ? "" : ((ComboBoxItem)cboPeDoctor.SelectedItem).Value;
            lsperm.appearance = cboPeAppearance.SelectedItem == null ? "" : ((ComboBoxItem)cboPeAppearance.SelectedItem).Value;
            lsperm.liquefaction = cboPeLiquefaction.SelectedItem == null ? "" : ((ComboBoxItem)cboPeLiquefaction.SelectedItem).Value;
            lsperm.viscosity = cboPeViscosity.SelectedItem == null ? "" : ((ComboBoxItem)cboPeViscosity.SelectedItem).Value;

            lsperm.sperm_date = ic.datetoDB(txtPeSpermDate.Text);
            lsperm.abstinence_day = txtPeAbstinenceday.Text;
            lsperm.ph = txtPePh.Text;
            lsperm.viability = txtPeViability.Text;
            lsperm.volume1 = txtPeVolume.Text;
            lsperm.count1 = txtPeCount.Text;
            lsperm.total_count = txtPeTotalCount.Text;
            lsperm.motile = txtPeMotile.Text;
            lsperm.motility = txtPeMotility.Text;
            lsperm.total_motile = txtPeTotalMotile.Text;
            lsperm.motility_rate_4 = txtPeMotility4.Text;
            lsperm.motility_rate_3 = txtPeMotility3.Text;
            lsperm.motility_rate_2 = txtPeMotility2.Text;
            lsperm.no_of_vail = txtPeVial.Text;
            //lsperm.wbc = txtPeWbc.Text;
            lsperm.ejaculation_time = txtPeEjacula.Text;
            lsperm.recive_time = txtPeRecive.Text;
            lsperm.examination_time = txtPeExam.Text;
            lsperm.finish_time = txtPeFinish.Text;
            //lsperm.morphology_normal = txtPeNormal.Text;
            //lsperm.morphology_abnormal = txtPeAbnormal.Text;
            //lsperm.morphology_head_defect = txtPeHead.Text;
            //lsperm.morphology_neck_defect = txtPeNeck.Text;
            //lsperm.morphology_tail_defect = txtPeTail.Text;
            lsperm.staff_id_approve = txtPeApproveResult.Text;
            lsperm.date_approve = txtPeApproveDate.Text;
            lsperm.staff_id_report = cboPeEmbryologistReport.SelectedItem == null ? "0" : ((ComboBoxItem)cboPeEmbryologistReport.SelectedItem).Value;
            lsperm.staff_id_approve = cboPeEmbryologistAppv.SelectedItem == null ? "0" : ((ComboBoxItem)cboPeEmbryologistAppv.SelectedItem).Value;
            lsperm.date_approve = ic.datetoDB(txtPeApproveDate.Text);
            lsperm.date_report = ic.datetoDB(txtPeReportDate.Text);
            lsperm.remark = cboPeRemark.Text;
            lsperm.sperm_time = txtPeSpermTime.Text;
        }
        private void setSpermIui()
        {
            lsperm.sperm_id = txtIuiID.Text;
            lsperm.hn_female = txtIuiHnFeMale.Text;
            lsperm.hn_male = txtIuiHnMale.Text;
            lsperm.name_female = txtIuiNameFeMale.Text;
            lsperm.name_male = txtIuiNameMale.Text;
            lbReq.req_code = txtIuiLabReqCode.Text;
            lsperm.dob_female = ic.datetoDB(txtIuiDobFeMale.Text);
            lsperm.dob_male = ic.datetoDB(txtIuiDobMale.Text);
            lsperm.doctor_id = cboIuiDoctor.SelectedItem == null ? "" : ((ComboBoxItem)cboIuiDoctor.SelectedItem).Value;
            lsperm.appearance = cboIuiAppearance.SelectedItem == null ? "" : ((ComboBoxItem)cboIuiAppearance.SelectedItem).Value;
            lsperm.liquefaction = cboIuiLiquefaction.SelectedItem == null ? "" : ((ComboBoxItem)cboIuiLiquefaction.SelectedItem).Value;
            lsperm.viscosity = cboIuiViscosity.SelectedItem == null ? "" : ((ComboBoxItem)cboIuiViscosity.SelectedItem).Value;

            lsperm.sperm_date = ic.datetoDB(txtIuiSpermDate.Text);
            lsperm.abstinence_day = txtIuiAbstinenceday.Text;
            //lsperm.ph = txtIuiPh.Text;
            //lsperm.viability = txtIuiViability.Text;
            lsperm.volume1 = txtIuiVolume.Text;
            lsperm.count1 = txtIuiCount.Text;
            lsperm.total_count = txtIuiTotalCount.Text;
            lsperm.motile = txtIuiMotile.Text;
            lsperm.motility = txtIuiMotility.Text;
            lsperm.motility_rate_4 = txtIuiMotility4.Text;
            lsperm.motility_rate_3 = txtIuiMotility3.Text;
            lsperm.motility_rate_2 = txtIuiMotility2.Text;
            lsperm.total_motile = txtIuiTotalMotile.Text;

            //lsperm.volume1 = txtIuiVolumePost.Text;
            //lsperm.count1 = txtIuiCountPost.Text;
            //lsperm.total_count = txtIuiTotalCountPost.Text;
            //lsperm.motile = txtIuiMotilePost.Text;
            //lsperm.motility = txtIuiMotilityPost.Text;
            //lsperm.total_motile = txtIuiTotalMotilePost.Text;
            //lsperm.motility_rate_4 = txtIuiMotility4Post.Text;
            //lsperm.motility_rate_3 = txtIuiMotility3Post.Text;
            //lsperm.motility_rate_2 = txtIuiMotility2Post.Text;
            //lsperm.no_of_vail = txtSfVial.Text;
            //lsperm.wbc = txtIuiWbc.Text;
            lsperm.ejaculation_time = txtIuiEjacula.Text;
            lsperm.recive_time = txtIuiRecive.Text;
            lsperm.examination_time = txtIuiExam.Text;
            lsperm.finish_time = txtIuiFinish.Text;
            //lsperm.morphology_normal = txtIuiNormal.Text;
            //lsperm.morphology_abnormal = txtIuiAbnormal.Text;
            //lsperm.morphology_head_defect = txtIuiHead.Text;
            //lsperm.morphology_neck_defect = txtIuiNeck.Text;
            //lsperm.morphology_tail_defect = txtIuiTail.Text;
            lsperm.staff_id_approve = txtIuiApproveResult.Text;
            lsperm.date_approve = txtIuiApproveDate.Text;
            lsperm.staff_id_report = cboIuiEmbryologistReport.SelectedItem == null ? "0" : ((ComboBoxItem)cboIuiEmbryologistReport.SelectedItem).Value;
            lsperm.staff_id_approve = cboIuiEmbryologistAppv.SelectedItem == null ? "0" : ((ComboBoxItem)cboIuiEmbryologistAppv.SelectedItem).Value;
            lsperm.date_approve = ic.datetoDB(txtIuiApproveDate.Text);
            lsperm.date_report = ic.datetoDB(txtIuiReportDate.Text);

            lsperm.post_volume1 = txtIuiVolumePost.Text;
            lsperm.post_count = txtIuiCountPost.Text;
            lsperm.post_total_count = txtIuiTotalCountPost.Text;
            lsperm.post_motile = txtIuiMotilePost.Text;
            lsperm.post_total_motile = txtIuiTotalMotilePost.Text;
            lsperm.post_motility_rate_4 = txtIuiMotility4Post.Text;
            lsperm.post_motility_rate_3 = txtIuiMotility3Post.Text;
            lsperm.post_motility_rate_2 = txtIuiMotility2Post.Text;
            lsperm.post_motility = txtIuiMotilityPost.Text;
            lsperm.remark = cboIuiRemark.Text;
            lsperm.sperm_time = txtIuiSpermTime.Text;
        }
        private void setTheme()
        {
            //theme2 = "Office2007Blue";
            if (lsperm.status_lab_sperm.Equals("1"))
            {
                theme2 = "Office2013Red";
                theme2 = "Office2016Colorful";
                theme1.SetTheme(this, theme2);
                theme1.SetTheme(panel7, theme2);
                theme1.SetTheme(groupBox3, theme2);
                theme1.SetTheme(groupBox4, theme2);
                foreach (Control ctl in panel7.Controls)
                {
                    if (ctl is C1PictureBox) continue;
                    theme1.SetTheme(ctl, theme2);
                }
                foreach (Control ctl in groupBox3.Controls)
                {
                    if (ctl is C1PictureBox) continue;
                    theme1.SetTheme(ctl, theme2);
                }
                foreach (Control ctl in groupBox4.Controls)
                {
                    if (ctl is C1PictureBox) continue;
                    theme1.SetTheme(ctl, theme2);
                }
            }
            else if (lsperm.status_lab_sperm.Equals("2"))
            {
                theme2 = "Office2007Blue";
                theme1.SetTheme(this, theme2);
                theme1.SetTheme(groupBox1, theme2);
                theme1.SetTheme(pnSememAnalysis, theme2);
                theme1.SetTheme(panel6, theme2);
                theme1.SetTheme(groupBox2, theme2);
                foreach (Control ctl in pnSememAnalysis.Controls)
                {
                    if (ctl is C1PictureBox) continue;
                    theme1.SetTheme(ctl, theme2);
                }
                foreach (Control ctl in groupBox1.Controls)
                {
                    if (ctl is C1PictureBox) continue;
                    theme1.SetTheme(ctl, theme2);
                }
                foreach (Control ctl in panel6.Controls)
                {
                    if (ctl is C1PictureBox) continue;
                    theme1.SetTheme(ctl, theme2);
                }
                foreach (Control ctl in groupBox2.Controls)
                {
                    if (ctl is C1PictureBox) continue;
                    theme1.SetTheme(ctl, theme2);
                }
            }
            else if (lsperm.status_lab_sperm.Equals("3"))
            {
                theme2 = "Office2010Barbie";
                theme1.SetTheme(this, theme2);
                theme1.SetTheme(panel9, theme2);
                theme1.SetTheme(groupBox5, theme2);
                foreach (Control ctl in panel9.Controls)
                {
                    if (ctl is C1PictureBox) continue;
                    theme1.SetTheme(ctl, theme2);
                }
                foreach (Control ctl in groupBox5.Controls)
                {
                    if (ctl is C1PictureBox) continue;
                    theme1.SetTheme(ctl, theme2);
                }
                //foreach (Control ctl in groupBox7.Controls)
                //{
                //    if (ctl is C1PictureBox) continue;
                //    theme1.SetTheme(ctl, theme2);
                //}
            }
            else if (lsperm.status_lab_sperm.Equals("4"))
            {
                theme2 = "BeigeOne";
                theme1.SetTheme(sB, "BeigeOne");
                theme1.SetTheme(this, theme2);
                theme1.SetTheme(panel11, theme2);
                theme1.SetTheme(panel12, theme2);
                theme1.SetTheme(c1TextBox3, theme2);
                theme1.SetTheme(pnIuiEmailView, theme2);
                theme1.SetTheme(groupBox6, theme2);
                //theme1.SetTheme(c1Ribbon3, theme2);
                foreach (Control ctl in panel11.Controls)
                {
                    if (ctl is C1PictureBox) continue;
                    theme1.SetTheme(ctl, theme2);
                }
                foreach (Control ctl in groupBox6.Controls)
                {
                    if (ctl is C1PictureBox) continue;
                    theme1.SetTheme(ctl, theme2);
                }
                //foreach (Control ctl in c1Ribbon3.Controls)
                //{
                //    if (ctl is C1PictureBox) continue;
                //    theme1.SetTheme(ctl, theme2);
                //}
                foreach (Control ctl in panel12.Controls)
                {
                    if (ctl is C1PictureBox) continue;
                    //    theme1.SetTheme(ctl, theme2);
                }
            }
        }
        private void initGrfImg()
        {
            grfImg = new C1FlexGrid();
            grfImg.Font = fEdit;
            grfImg.Dock = System.Windows.Forms.DockStyle.Fill;
            grfImg.Location = new System.Drawing.Point(0, 0);

            grfImg.DoubleClick += GrfImg_DoubleClick;
            if (lsperm.status_lab_sperm.Equals("1"))
            {
                //pnSfEmailView.Controls.Add(grfImg);
            }
            else if (lsperm.status_lab_sperm.Equals("2"))
            {
                //pnEmailView.Controls.Add(grfImg);
            }
            else if (lsperm.status_lab_sperm.Equals("3"))
            {
                //pnIuiEmailView.Controls.Add(grfImg);
            }
            else if (lsperm.status_lab_sperm.Equals("4"))
            {
                //pnSfEmailView.Controls.Add(grfImg);
            }
            

            theme1.SetTheme(grfImg, "Office2016Colorful");

        }

        private void GrfImg_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfImg.Row < 0) return;
            if (grfImg.Col == colImgImg && grfImg.Row > 1)
            {
                //MessageBox.Show("a "+grfImg[grfImg.Row, colImg].ToString(), "");
                int row = 0;
                //int.TryParse(grfImg[grfImg.Row, colImg].ToString(), out row);
                int.TryParse(grfImg.Row.ToString(), out row);
                //row *= 4;
                FrmShowImage frm = new FrmShowImage(ic, grfImg[row, colImgID] != null ? grfImg[row, colImgID].ToString() : "", txtPttIdOld.Text, grfImg[row, colImgPathPic] != null ? grfImg[row, colImgPathPic].ToString() : "", FrmShowImage.statusModule.Patient);
                frm.ShowDialog(this);
            }
            if(grfImg.Row == 1)
            {
                grfImg.AutoSizeCols();
                grfImg.AutoSizeRows();
            }
        }
        private void setGrfImg()
        {
            grfImg.Clear();
            grfImg.DataSource = null;
            grfImg.Rows.Count = 2;
            grfImg.Cols.Count = 10;

            Button btn = new Button();
            btn.BackColor = Color.Gray;

            grfImg.Cols[colImgBtn].Editor = btn;
            //grfImg.Cols[colImg].Editor = img;

            grfImg.Cols[colImgHn].Width = 250;
            grfImg.Cols[colImgImg].Width = 100;
            grfImg.Cols[colImgDesc].Width = 100;
            grfImg.Cols[colImgDesc2].Width = 100;
            grfImg.Cols[colImgDesc3].Width = 100;
            grfImg.Cols[colImgBtn].Width = 50;
            grfImg.Cols[colImgPathPic].Width = 100;

            grfImg.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfImg.Cols[colImgHn].Caption = "HN";
            grfImg.Cols[colImgDesc].Caption = "Desc1";
            grfImg.Cols[colImgDesc2].Caption = "Desc2";
            grfImg.Cols[colImgDesc3].Caption = "Desc3";
            grfImg.Cols[colImgBtn].Caption = "send";

            //Hashtable ht = new Hashtable();
            //foreach (DataRow dr in dt.Rows)
            //{
            //    ht.Add(dr["CategoryID"], LoadImage(dr["Picture"] as byte[]));
            //}
            //grfImg.Cols[colImg].ImageMap = ht;
            //grfImg.Cols[colImg].ImageAndText = false;

            //ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข Patient", new EventHandler(ContextMenu_edit));
            //grfImg.ContextMenu = menuGw;

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            if (txtPttId.Text.Equals(""))
                return;
            DataTable dt = new DataTable();
            dt = ic.ivfDB.pttImgDB.selectByPttIDDept(txtPttId.Text, "1090000001");
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                i++;
                Row row1 = grfImg.Rows.Add();
                row1[colImgID] = row[ic.ivfDB.pttImgDB.pttI.patient_image_id].ToString();
                row1[colImgDesc] = row[ic.ivfDB.pttImgDB.pttI.desc1].ToString();
                row1[colImgPathPic] = row[ic.ivfDB.pttImgDB.pttI.image_path].ToString();
                row1[colImgStatus] = row[ic.ivfDB.pttImgDB.pttI.status_image].ToString();
                String statusdoc = "";
                statusdoc = row[ic.ivfDB.pttImgDB.pttI.status_document].ToString();
                grfImg[i, 0] = i;
                if (row[ic.ivfDB.pttImgDB.pttI.image_path] != null && !row[ic.ivfDB.pttImgDB.pttI.image_path].ToString().Equals(""))
                {
                    int ii = i;
                    Thread pump = new Thread(() =>
                    {
                        Thread.CurrentThread.IsBackground = true;
                        Image loadedImage = null, resizedImage;
                        String aaa = row[ic.ivfDB.pttImgDB.pttI.image_path].ToString();
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
                            //ftpRequest.UsePassive = false;
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
                                MessageBox.Show("setGrfImgPatient 1 " + ex.Message + "\n " + aaa, "host " + ic.iniC.hostFTP + " user " + user + " pas  " + pass);
                            }
                            if (statusdoc.Equals("1"))
                            {
                                loadedImage = new Bitmap(stream);
                            }
                            ftpStream.Close();
                            ftpResponse.Close();
                            ftpRequest = null;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                            MessageBox.Show("setGrfImgPatient 2 " + ex.Message + "\n " + aaa, "host " + ic.iniC.hostFTP + " user " + user + " pas  " + pass);
                        }
                        //grfImg.Cols[colImg].ImageAndText = true;
                        if (loadedImage != null)
                        {
                            int originalWidth = loadedImage.Width;
                            int newWidth = 180;
                            resizedImage = loadedImage.GetThumbnailImage(newWidth, (newWidth * loadedImage.Height) / originalWidth, null, IntPtr.Zero);
                            Column col = grfImg.Cols[colImgImg];
                            col.DataType = typeof(Image);
                            row1[colImgImg] = resizedImage;
                            flagImg = true;
                            //grfImg.AutoSizeCols();
                            //grfImg.AutoSizeRows();
                        }
                    });
                    pump.Start();
                    //pump.Join();
                    //grfImg.AutoSizeCols();
                    //grfImg.AutoSizeRows();
                }
                //if (i % 2 == 0)
                //grfPtt.Rows[i].StyleNew.BackColor = color;
            }
            grfImg.Cols[colImgID].Visible = false;
            //grfImg.Cols[colPathPic].Visible = false;
            grfImg.Cols[colImgImg].AllowEditing = false;
            grfImg.Cols[colImgImg].AllowSorting = false;
            grfImg.Cols[colImgDesc].AllowSorting = false;
            grfImg.Cols[colImgPathPic].AllowSorting = false;
            //grfImg.AutoSizeCols();
            grfImg.AutoSizeRows();
            theme1.SetTheme(grfImg, "Office2016Colorful");
            grfImg.AutoSizeCols();
            grfImg.AutoSizeRows();
        }
        private String setExport(String spermid, String flagPreview)
        {
            ReportDocument rpt;
            CrystalReportViewer crv = new CrystalReportViewer();
            String filename = "", directory = "", ext = ".pdf", datetick = "";
            directory = AppDomain.CurrentDomain.BaseDirectory;
            datetick = DateTime.Now.Ticks.ToString();
            filename = directory + "report\\" + datetick + ext;
            rpt = new ReportDocument();
            DataTable dt = new DataTable();
            //dt = printOPUReport("");
            dt = ic.ivfDB.lspermDB.selectByPk(spermid);
            try
            {
                String rptname = "";
                if (StatusSperm.Equals("1"))// sperm Freezing
                {
                    rptname = "lab_sperm_sf.rpt";
                }
                else if (StatusSperm.Equals("2"))// sperm analysis
                {
                    rptname = "lab_sperm_sa.rpt";
                }
                else if (StatusSperm.Equals("3"))// sperm Pesa
                {
                    rptname = "lab_sperm_pesa.rpt";
                }
                else if (StatusSperm.Equals("4"))// sperm IUI
                {
                    rptname = "lab_sperm_iui.rpt";
                }
                rpt.Load(rptname);
                crv.ReportSource = rpt;
                //System.Threading.Thread.Sleep(200);
                crv.Refresh();
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                rpt.SetParameterValue("line2", "โทรศัพท์ " + ic.cop.tele);
                rpt.SetParameterValue("line3", ic.cop.addr2);
                Application.DoEvents();
                if (File.Exists(filename))
                    File.Delete(filename);

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
                Application.DoEvents();
                //System.Threading.Thread.Sleep(200);
                rpt.Export();
                
                if (File.Exists(filename))
                {
                    long chk1 = 0;
                    String filename1 = Path.GetFileName(filename);
                    ic.savePicOPUtoServer(spermid, filename1, filename);
                    ic.ivfDB.lspermDB.updateReportFile(spermid, filename1);
                }
            }
            catch (Exception ex)
            {
                new LogWriter("e", "FrmLabOPUPrint BtnExport_Click " + ex.Message);
                MessageBox.Show(ex.ToString());
            }
            return "";
        }
        private void createReport()
        {
            C1FlexViewer day1View = new C1FlexViewer();
            day1View = new C1FlexViewer();
            day1View.AutoScrollMargin = new System.Drawing.Size(0, 0);
            day1View.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            day1View.Dock = System.Windows.Forms.DockStyle.Fill;
            day1View.Location = new System.Drawing.Point(0, 0);
            day1View.Name = "c1FlexViewer1";
            day1View.Size = new System.Drawing.Size(1065, 790);
            day1View.TabIndex = 0;
            day1View.Ribbon.Minimized = true;
            C1PdfDocumentSource pds = new C1PdfDocumentSource();
            if (lsperm.report.Length > 0)
            {
                MemoryStream stream = ic.ftpC.download(ic.iniC.folderFTP +"//sperm_"+lsperm.sperm_id+"//"+ lsperm.report);
                pds.LoadFromStream(stream);
            }

            //pds.LoadFromFile(filename1);

            day1View.DocumentSource = pds;

            if (lsperm.status_lab_sperm.Equals("1"))      // sperm Freezing
            {
                panel14.Controls.Add(day1View);
                panel14.Height = 800;
            }
            else if (lsperm.status_lab_sperm.Equals("2"))      // sperm analysis
            {
                pnEmailView.Controls.Add(day1View);
                pnEmailView.Height = 800;
            }
            else if (lsperm.status_lab_sperm.Equals("3"))      // sperm Pesa
            {
                pnPeEmailView.Controls.Add(day1View);
                pnPeEmailView.Height = 800;
            }
            else if (lsperm.status_lab_sperm.Equals("4"))      // sperm IUI
            {
                pnIuiEmailView.Controls.Add(day1View);
                pnIuiEmailView.Height = 800;
            }
            day1View.Show();
            day1View.BringToFront();
        }
        private void FrmLabSpermAdd_Load(object sender, EventArgs e)
        {
            tC.SelectedTab = tabSpermFreezing;
            sCAnalysis.HeaderHeight = 0;
            sCIui.HeaderHeight = 0;
            sCPesa.HeaderHeight = 0;
            sCFreezing.HeaderHeight = 0;
            tC.ShowTabs = false;
            if (lsperm.status_lab_sperm.Equals("1"))      // sperm Freezing
            {
                tC.SelectedTab = tabSpermFreezing;
            }
            else if (lsperm.status_lab_sperm.Equals("2"))      // sperm analysis
            {
                tC.SelectedTab = tabSememAna;
            }
            else if (lsperm.status_lab_sperm.Equals("3"))      // sperm Pesa
            {
                tC.SelectedTab = tabSememPESA;
            }
            else if (lsperm.status_lab_sperm.Equals("4"))      // sperm IUI
            {
                tC.SelectedTab = TabSpermIUI;
            }
            setTheme();
            createReport();
        }
    }
}
