using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1SuperTooltip;
using clinic_ivf.control;
using clinic_ivf.object1;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
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

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;
        Color color;
        int colImgID = 1, colImgHn = 2, colImgImg = 3, colImgDesc = 4, colImgDesc2 = 5, colImgDesc3 = 6, colImgPathPic = 7, colImgBtn = 8, colImgStatus = 9, colImgDoctor = 10;

        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        String theme2 = "Office2007Blue";
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
            //this.flagEdit = flagEdit;
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

            sB1.Text = "";
            bg = txtHnFeMale.BackColor;
            fc = txtHnFeMale.ForeColor;
            ff = txtHnFeMale.Font;
            ic.ivfDB.dtrOldDB.setCboDoctor(cboDoctor, "");
            ic.ivfDB.dtrOldDB.setCboDoctor(cboSfDoctor, "");
            ic.ivfDB.dtrOldDB.setCboDoctor(cboPeDoctor, "");
            ic.ivfDB.dtrOldDB.setCboDoctor(cboIuiDoctor, "");

            ic.ivfDB.fdtDB.setCboSpermAnalysisAppearance(cboAppearance);
            ic.ivfDB.fdtDB.setCboSpermAnalysisAppearance(cboLiquefaction);
            ic.ivfDB.fdtDB.setCboSpermAnalysisAppearance(cboViscosity);
            ic.ivfDB.fdtDB.setCboSpermAnalysisAppearance(cboSfAppearance);
            ic.ivfDB.fdtDB.setCboSpermAnalysisAppearance(cboSfLiquefaction);
            ic.ivfDB.fdtDB.setCboSpermAnalysisAppearance(cboSfViscosity);
            ic.ivfDB.fdtDB.setCboSpermAnalysisAppearance(cboPeAppearance);
            ic.ivfDB.fdtDB.setCboSpermAnalysisAppearance(cboPeLiquefaction);
            ic.ivfDB.fdtDB.setCboSpermAnalysisAppearance(cboPeViscosity);
            ic.ivfDB.fdtDB.setCboSpermAnalysisAppearance(cboIuiAppearance);
            ic.ivfDB.fdtDB.setCboSpermAnalysisAppearance(cboIuiLiquefaction);
            ic.ivfDB.fdtDB.setCboSpermAnalysisAppearance(cboIuiViscosity);
            ic.ivfDB.fdtDB.setCboSpermAnalysisWbc(cboSfWbc);
            ic.ivfDB.fdtDB.setCboSpermAnalysisNoofVail(cboSfNoofVail);

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

            txtSfAbstinenceday.KeyUp += TxtSfAbstinenceday_KeyUp;
            txtAbstinenceday.KeyUp += TxtAbstinenceday_KeyUp;

            txtVolume.KeyUp += TxtVolume_KeyUp;
            txtCount.KeyUp += TxtCount_KeyUp;
            txtSfVolume.KeyUp += TxtSfVolume_KeyUp;
            txtSfCount.KeyUp += TxtSfCount_KeyUp;
            
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

            txtMotility4.KeyUp += TxtMotility4_KeyUp;
            txtMotility3.KeyUp += TxtMotility3_KeyUp;
            txtHead1.KeyUp += TxtHead1_KeyUp;
            txtNeck1.KeyUp += TxtNeck1_KeyUp;
            txtTail1.KeyUp += TxtTail1_KeyUp;
            txtPh.KeyUp += TxtPh_KeyUp;

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            lsperm = new LabSperm();
            lbReq = new LabRequest();

            setControl();
            setTheme();
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
                if (long.TryParse(re, out chk))
                {
                    pnEmailAddSubject.Enabled = true;
                }
            }
        }

        private void BtnIuiSendEmail_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

        }

        private void BtnSendEmail_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmWaiting frmW = new FrmWaiting();
            frmW.Show();
            String filename = "", datetick = "";
            if (!Directory.Exists("report"))
            {
                Directory.CreateDirectory("report");
            }
            datetick = DateTime.Now.Ticks.ToString();
            filename = "report\\sperm_analysis_" + datetick + ".pdf";
            if (!setReportSpermAnalysis(filename))
            {
                return;
            }
            frmW.Dispose();

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(txtEmailTo.Text);
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

            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
            mail.AlternateViews.Add(htmlView);

            foreach (LinkedResource linkimg in theEmailImage1)
            {
                htmlView.LinkedResources.Add(linkimg);
            }

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(ic.iniC.email_auth_user, ic.iniC.email_auth_pass);

            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
        }

        private void TxtPh_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();

        }

        private void TxtTail1_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calMorphology();
        }

        private void TxtNeck1_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calMorphology();
            if (e.KeyCode == Keys.Enter)
            {
                txtTail1.Focus();
            }
        }

        private void TxtHead1_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calMorphology();
            if (e.KeyCode == Keys.Enter)
            {
                txtNeck1.Focus();
            }
        }

        private void TxtMotility3_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calMotility();
            calMotile();
            if (e.KeyCode == Keys.Enter)
            {
                txtMotility2.Focus();
            }
        }

        private void TxtMotility4_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calMotility();
            calMotile();
            if (e.KeyCode == Keys.Enter)
            {
                txtMotility3.Focus();
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
            String filename = "", datetick="";
            if (!Directory.Exists("report"))
            {
                Directory.CreateDirectory("report");
            }
            datetick = DateTime.Now.Ticks.ToString();
            filename = "report\\sperm_freezing_"+ datetick + ".pdf";
            if (!setReportSpermFreezing(filename))
            {
                return;
            }
            frmW.Dispose();

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(txtSfEmailTo.Text);
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

            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
            mail.AlternateViews.Add(htmlView);

            foreach (LinkedResource linkimg in theEmailImage1)
            {
                htmlView.LinkedResources.Add(linkimg);
            }

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(ic.iniC.email_auth_user, ic.iniC.email_auth_pass);

            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
        }

        private void TxtViability_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.Enter)
            {
                txtSfVolume.Focus();
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

        private void TxtSfTail1_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calSfMorphology();
        }

        private void TxtSfNeck1_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calSfMorphology();
            if (e.KeyCode == Keys.Enter)
            {
                txtSfTail1.Focus();
            }
        }

        private void TxtSfHead1_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calSfMorphology();
            if (e.KeyCode == Keys.Enter)
            {
                txtSfNeck1.Focus();
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

        private void TxtSfCount_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calSfTotalCount();
            calSfMotile();
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
                txtSfCount.Focus();
            }
        }

        private void TxtVolume_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            calTotalCount();
            calMotile();
        }
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
        private void calSfMotility()
        {
            Decimal pr = 0, nr = 0, motility=0;
            int motility1 = 0;
            Decimal.TryParse(txtSfMotility4.Text, out pr);
            Decimal.TryParse(txtSfMotility3.Text, out nr);
            motility = pr + nr;
            int.TryParse(motility.ToString(), out motility1);
            txtSfMotility.Value = motility1;
            txtSfViability.Value = motility1 + 7;
        }
        private void calMotility()
        {
            Decimal pr = 0, nr = 0, motility = 0;
            int motility1 = 0;
            Decimal.TryParse(txtMotility4.Text, out pr);
            Decimal.TryParse(txtMotility3.Text, out nr);
            motility = pr + nr;
            int.TryParse(motility.ToString(), out motility1);
            txtMotility.Value = motility1;
            txtViability.Value = motility1 + 7;
        }
        private void calSfMotile()
        {
            Decimal motilitysf = 0, cntsf = 0, motile=0, vol=0, totalmotile=0;
            int motile1 = 0, totalmotile1=0;
            Decimal.TryParse(txtSfMotility.Text, out motilitysf);
            Decimal.TryParse(txtSfCount.Text, out cntsf);
            Decimal.TryParse(txtSfVolume.Text, out vol);
            motile = (motilitysf * cntsf) / 100;
            motile = Math.Round(motile);
            int.TryParse(motile.ToString(), out motile1);
            txtSfMotile.Value = motile1;

            totalmotile = motile * vol;
            totalmotile = Math.Round(totalmotile);
            int.TryParse(totalmotile.ToString(), out totalmotile1);
            txtSfTotalMotile.Value = totalmotile1;
        }
        private void calMotile()
        {
            Decimal motilitysf = 0, cntsf = 0, motile = 0, vol = 0, totalmotile = 0;
            int motile1 = 0, totalmotile1 = 0;
            Decimal.TryParse(txtMotility.Text, out motilitysf);
            Decimal.TryParse(txtCount.Text, out cntsf);
            Decimal.TryParse(txtVolume.Text, out vol);
            motile = (motilitysf * cntsf) / 100;
            motile = Math.Round(motile);
            int.TryParse(motile.ToString(), out motile1);
            txtMotile.Value = motile1;

            totalmotile = motile * vol;
            totalmotile = Math.Round(totalmotile);
            int.TryParse(totalmotile.ToString(), out totalmotile1);
            txtTotalMotile.Value = totalmotile1;
        }
        private void calSfTotalCount()
        {
            Decimal vol = 0, cnt = 0, totalcnt=0;
            int totalcnt1 = 0;
            Decimal.TryParse(txtSfVolume.Text, out vol);
            Decimal.TryParse(txtSfCount.Text, out cnt);
            totalcnt = vol * cnt;
            totalcnt = Math.Round(totalcnt);
            int.TryParse(totalcnt.ToString(), out totalcnt1);
            txtSfTotalCount.Value = totalcnt1;
        }
        private void calTotalCount()
        {
            Decimal vol = 0, cnt = 0, totalcnt = 0;
            int totalcnt1 = 0;
            Decimal.TryParse(txtVolume.Text, out vol);
            Decimal.TryParse(txtCount.Text, out cnt);
            totalcnt = vol * cnt;
            totalcnt = Math.Round(totalcnt);
            int.TryParse(totalcnt.ToString(), out totalcnt1);
            txtTotalCount.Value = totalcnt1;
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
                    txtWbc.Focus();
                }
                else if (sender.Equals(txtWbc))
                {
                    txtNormal.Focus();
                }
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
            String date1 = dt.Rows[0]["date_report"].ToString();
            String date2 = dt.Rows[0]["date_approve"].ToString();
            String datemale = dt.Rows[0]["dob_male"].ToString();
            date1 = ic.datetimetoShow(dt.Rows[0]["date_report"]);
            date2 = ic.datetimetoShow(dt.Rows[0]["date_approve"]);
            dt.Rows[0]["date_report"] = date1;
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
            String date1 = dt.Rows[0]["date_report"].ToString();
            String date2 = dt.Rows[0]["date_approve"].ToString();
            String datemale = dt.Rows[0]["dob_male"].ToString();
            date1 = ic.datetimetoShow(dt.Rows[0]["date_report"]);
            date2 = ic.datetimetoShow(dt.Rows[0]["date_approve"]);
            dt.Rows[0]["date_report"] = date1;
            dt.Rows[0]["date_approve"] = date2;

            datemale = ic.datetoShow(dt.Rows[0]["dob_male"]);
            dt.Rows[0]["dob_male"] = datemale;
            frm.setSpermSa(dt);
            frm.ShowDialog(this);
        }

        private void BtnPrintSf_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmReport frm = new FrmReport(ic);
            DataTable dt = new DataTable();
            dt = ic.ivfDB.lspermDB.selectByPk(txtSfID.Text);
            String date1 = dt.Rows[0]["date_report"].ToString();
            String date2 = dt.Rows[0]["date_approve"].ToString();
            String datemale = dt.Rows[0]["dob_male"].ToString();
            date1 = ic.datetimetoShow(dt.Rows[0]["date_report"]);
            date2 = ic.datetimetoShow(dt.Rows[0]["date_approve"]);
            dt.Rows[0]["date_report"] = date1;
            dt.Rows[0]["date_approve"] = date2;

            datemale = ic.datetoShow(dt.Rows[0]["dob_male"]);
            dt.Rows[0]["dob_male"] = datemale;
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

        private void BtnPeSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
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

        private void BtnSfSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            int pr = 0, nr = 0, im = 0, normal = 0, abnormal = 0; ;
            int.TryParse(txtSfMotility4.Text, out pr);
            int.TryParse(txtSfMotility3.Text, out nr);
            int.TryParse(txtSfMotility2.Text, out im);
            if ((pr + nr + im) != 100)
            {
                MessageBox.Show("ผลรวม Progessive + Non-progessive + mmotility ไม่เท่ากับ 100", "");
                return;
            }
            int.TryParse(txtSfNormal.Text, out normal);
            int.TryParse(txtSfAbnormal.Text, out abnormal);
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
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
        private void setControlAnalysisReadOnly(Boolean flag)
        {
            txtHnFeMale.ReadOnly = !flag;
            txtHnMale.ReadOnly = !flag;
            txtNameFeMale.ReadOnly = !flag;
            txtNameMale.ReadOnly = !flag;
            txtLabReqCode.ReadOnly = !flag;
            txtDobFeMale.ReadOnly = !flag;
            txtDobMale.ReadOnly = !flag;
            cboDoctor.ReadOnly = !flag;
            cboAppearance.ReadOnly = !flag;
            cboLiquefaction.ReadOnly = !flag;
            cboViscosity.ReadOnly = !flag;

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
            txtWbc.ReadOnly = !flag;
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
            txtSfViability.ReadOnly = !flag;
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
        private void setControl()
        {
            lsperm = ic.ivfDB.lspermDB.selectByPk1(spermId);
            lbReq = ic.ivfDB.lbReqDB.selectByPk1(lsperm.req_id);
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
            }
            else if (lsperm.status_lab_sperm.Equals("4"))
            {
                setControlIui();
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
            txtDobFeMale.Value = lsperm.dob_female;
            txtDobMale.Value = lsperm.dob_male;
            ic.setC1Combo(cboDoctor, lsperm.doctor_id);
            ic.setC1Combo(cboAppearance, lsperm.appearance);
            ic.setC1Combo(cboLiquefaction, lsperm.liquefaction);
            ic.setC1Combo(cboViscosity, lsperm.viscosity);

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
            txtWbc.Value = lsperm.wbc;
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
            txtEmailSubject.Value = "Result LAB Sperm Analysis HN " + txtSfHnMale.Text + " Name " + txtSfNameMale.Text+" ["+ txtLabReqCode.Text+"]";
        }
        private void setControlSpermFreezing()
        {
            txtSfID.Value = lsperm.sperm_id;
            txtSfHnFeMale.Value = lsperm.hn_female;
            txtSfHnMale.Value = lsperm.hn_male;
            txtSfNameFeMale.Value = lsperm.name_female;
            txtSfNameMale.Value = lsperm.name_male;
            txtSfLabReqCode.Value = lbReq.req_code;
            txtSfDobFeMale.Value = lsperm.dob_female;
            txtSfDobMale.Value = lsperm.dob_male;
            ic.setC1Combo(cboSfDoctor, lsperm.doctor_id);
            ic.setC1Combo(cboSfAppearance, lsperm.appearance);
            ic.setC1Combo(cboSfLiquefaction, lsperm.liquefaction);
            ic.setC1Combo(cboSfViscosity, lsperm.viscosity);
            ic.setC1Combo(cboSfEmbryologistAppv, lsperm.staff_id_approve);
            ic.setC1Combo(cboSfEmbryologistReport, lsperm.staff_id_report);
            ic.setC1Combo(cboSfEmbryologistReport, lsperm.staff_id_report);
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
            txtSfEmailSubject.Value = "Result LAB Sperm Freezing HN "+txtSfHnMale.Text+" Name "+txtSfNameMale.Text + " [" + txtSfLabReqCode.Text + "]";

            if (!lsperm.status_lab.Equals("5"))
            {
                pnEmailAddSubject.Enabled = false;
            }
        }
        private void setControlPesa()
        {
            txtPeID.Value = lsperm.sperm_id;
            txtPeHnFeMale.Value = lsperm.hn_female;
            txtPeHnMale.Value = lsperm.hn_male;
            txtPeNameFeMale.Value = lsperm.name_female;
            txtPeNameMale.Value = lsperm.name_male;
            txtPeLabReqCode.Value = lbReq.req_code;
            txtPeDobFeMale.Value = lsperm.dob_female;
            txtPeDobMale.Value = lsperm.dob_male;
            ic.setC1Combo(cboPeDoctor, lsperm.doctor_id);
            ic.setC1Combo(cboPeAppearance, lsperm.appearance);
            ic.setC1Combo(cboPeLiquefaction, lsperm.liquefaction);
            ic.setC1Combo(cboPeViscosity, lsperm.viscosity);

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
        }
        private void setControlIui()
        {
            txtIuiID.Value = lsperm.sperm_id;
            txtIuiHnFeMale.Value = lsperm.hn_female;
            txtIuiHnMale.Value = lsperm.hn_male;
            txtIuiNameFeMale.Value = lsperm.name_female;
            txtIuiNameMale.Value = lsperm.name_male;
            txtIuiLabReqCode.Value = lbReq.req_code;
            txtIuiDobFeMale.Value = lsperm.dob_female;
            txtIuiDobMale.Value = lsperm.dob_male;
            ic.setC1Combo(cboIuiDoctor, lsperm.doctor_id);
            ic.setC1Combo(cboIuiAppearance, lsperm.appearance);
            ic.setC1Combo(cboIuiLiquefaction, lsperm.liquefaction);
            ic.setC1Combo(cboIuiViscosity, lsperm.viscosity);

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
            lsperm.wbc = txtWbc.Text;
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
            lsperm.remark = cboSfRemark.Text;
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
            lsperm.total_motile = txtTotalMotile.Text;
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
            lsperm.staff_id_report = cboEmbryologistReport.SelectedItem == null ? "0" : ((ComboBoxItem)cboEmbryologistReport.SelectedItem).Value;
            lsperm.staff_id_approve = cboEmbryologistAppv.SelectedItem == null ? "0" : ((ComboBoxItem)cboEmbryologistAppv.SelectedItem).Value;
            lsperm.date_approve = ic.datetoDB(txtPeApproveDate.Text);
            lsperm.date_report = ic.datetoDB(txtPeReportDate.Text);
            lsperm.remark = cboPeRemark.Text;
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

            lsperm.volume1 = txtIuiVolumePost.Text;
            lsperm.count1 = txtIuiCountPost.Text;
            lsperm.total_count = txtIuiTotalCountPost.Text;
            lsperm.motile = txtIuiMotilePost.Text;
            lsperm.motility = txtIuiMotilityPost.Text;
            lsperm.total_motile = txtIuiTotalMotilePost.Text;
            lsperm.motility_rate_4 = txtIuiMotility4Post.Text;
            lsperm.motility_rate_3 = txtIuiMotility3Post.Text;
            lsperm.motility_rate_2 = txtIuiMotility2Post.Text;
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
            lsperm.staff_id_report = cboEmbryologistReport.SelectedItem == null ? "0" : ((ComboBoxItem)cboEmbryologistReport.SelectedItem).Value;
            lsperm.staff_id_approve = cboEmbryologistAppv.SelectedItem == null ? "0" : ((ComboBoxItem)cboEmbryologistAppv.SelectedItem).Value;
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
            }
            else if (lsperm.status_lab_sperm.Equals("4"))
            {
                theme2 = "Office2007Blue";
            }
            theme1.SetTheme(sB, "BeigeOne");
            //theme1.SetTheme(this, theme2);
            //theme1.SetTheme(groupBox1, theme2);
            //theme1.SetTheme(pnSememAnalysis, theme2);
            //theme1.SetTheme(panel6, theme2);
            //theme1.SetTheme(groupBox2, theme2);
            //foreach (Control ctl in pnSememAnalysis.Controls)
            //{
            //    if (ctl is C1PictureBox) continue;
            //    theme1.SetTheme(ctl, theme2);
            //}
            //foreach (Control ctl in groupBox1.Controls)
            //{
            //    if (ctl is C1PictureBox) continue;
            //    theme1.SetTheme(ctl, theme2);
            //}
            //foreach (Control ctl in panel6.Controls)
            //{
            //    if (ctl is C1PictureBox) continue;
            //    theme1.SetTheme(ctl, theme2);
            //}
            //foreach (Control ctl in groupBox2.Controls)
            //{
            //    if (ctl is C1PictureBox) continue;
            //    theme1.SetTheme(ctl, theme2);
            //}
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
                pnSfEmailView.Controls.Add(grfImg);
            }
            else if (lsperm.status_lab_sperm.Equals("2"))
            {
                pnEmailView.Controls.Add(grfImg);
            }
            else if (lsperm.status_lab_sperm.Equals("3"))
            {
                pnIuiEmailView.Controls.Add(grfImg);
            }
            else if (lsperm.status_lab_sperm.Equals("4"))
            {
                pnSfEmailView.Controls.Add(grfImg);
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
            
        }
    }
}
