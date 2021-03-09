using C1.Win.C1Command;
using C1.Win.C1Document;
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
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static clinic_ivf.gui.FrmReport;

namespace clinic_ivf.gui
{
    public partial class FrmLabOPUPrint : Form
    {
        IvfControl ic;
        String reqId = "", opuId = "";
        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;

        LabOpu opu;
        LabFet fet;

        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        C1Button btnPreview;
        CheckBox chkRptEmbryo;
        Color color;
        public enum opuReport {OPUReport, OPUEmbryoDevReport, ResultDay3, FETEmbryoDevReport, ResultDay1, ResultDay5, ResultDay6, ResultDay0, ResultDay2 };
        opuReport opureport;
        List<LinkedResource> theEmailImage1 = new List<LinkedResource>();
        SmtpClient SmtpServer;
        String aaa = "₀₁₂₃₄₅₆₇₈₉";

        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetDefaultPrinter(string Printer);
        public FrmLabOPUPrint(IvfControl ic, String opuid, opuReport opureport)
        {
            InitializeComponent();
            this.ic = ic;
            opuId = opuid;
            this.opureport = opureport;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);
            theme1.SetTheme(sB, "BeigeOne");
            color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);

            opu = new LabOpu();
            fet = new LabFet();
            setControl();

            sB1.Text = "";
            bg = txtHnFeMale.BackColor;
            fc = txtHnFeMale.ForeColor;
            ff = txtHnFeMale.Font;
            
            ic.setCboDayEmbryoDev(cboEmbryoDev1, "");
            ic.setCboDayEmbryoDev(cboEmbryoDev2, "");
            ic.setCboDayEmbryoDev(cboEmbryoDev3, "");
            SmtpServer = new SmtpClient("smtp.gmail.com");

            if (opureport == opuReport.OPUEmbryoDevReport)
            {
                groupBox2.Hide();
                label7.Hide();
                cboEmbryoDev2.Hide();
                chkEmbryoDev20.Hide();
                label1.Text = "Day :";
            }
            else if (opureport == opuReport.FETEmbryoDevReport)
            {
                groupBox2.Hide();
                chkEmbryoDev20.Hide();
                label7.Hide();
                cboEmbryoDev2.Hide();
            }
            else if (opureport == opuReport.ResultDay3)
            {
                //pnEmail.Hide();
                chkSendEmail.Hide();
                //btnPrint.Hide();
                btnExport.Text = "ส่งผล Day3";
                btnPrint.Text = "Preview Day3";
                //btnPreview = new C1Button();
                //btnPreview.Name = "btnPreview";
                //btnPreview.Size = btnExport.Size;
                //btnPreview.Location = new System.Drawing.Point(btnExport.Location.X, btnExport.Location.Y + btnExport.Size.Height + 10);
                //btnPreview.Text = "Preview";
                ////btnPreview.them
                //btnPreview.Click += BtnPreview_Click;
                //groupBox1.Controls.Add(btnPreview);
                chkRptEmbryo = new CheckBox();
            }
            else if (opureport == opuReport.ResultDay2)
            {
                chkSendEmail.Hide();
                btnExport.Text = "ส่งผล Day2";
                btnPrint.Text = "Preview Day2";
                chkRptEmbryo = new CheckBox();
            }
            else if (opureport == opuReport.ResultDay5)
            {
                //pnEmail.Hide();
                if (!opu.status_opu.Equals("2"))
                {
                    //pnEmail.Hide();
                }
                chkSendEmail.Hide();
                //btnPrint.Hide();
                btnExport.Text = "ส่งผล Day5";
                btnPrint.Text = "Preview Day5";
                
                chkRptEmbryo = new CheckBox();
            }
            else if (opureport == opuReport.ResultDay6)
            {
                if (!opu.status_opu.Equals("2"))
                {
                    //pnEmail.Hide();
                }
                chkSendEmail.Hide();
                //btnPrint.Hide();
                btnExport.Text = "ส่งผล Day6";
                btnPrint.Text = "Preview Day6";

                chkRptEmbryo = new CheckBox();
            }
            else if (opureport == opuReport.ResultDay1)
            {
                //pnEmail.Hide();
                //chkSendEmail.Hide();
                btnExport.Text = "ส่งผล Day1";
                btnPrint.Text = "Preview Day1";
                                
                chkRptEmbryo = new CheckBox();
            }
            else if (opureport == opuReport.ResultDay0)
            {
                btnExport.Text = "ส่งผล Day0";
                btnPrint.Text = "Preview Day0";
                chkRptEmbryo = new CheckBox();
            }
            
            else
            {
                groupBox2.Show();
            }
            btnPrint.Click += BtnPrint_Click;
            btnExport.Click += BtnExport_Click;
            btnSendEmail.Click += BtnSendEmail_Click;
            chkEmbryoDev20.CheckedChanged += ChkEmbryoDev20_CheckedChanged;
            lbEmail.Hide();
            cryLab.Hide();
            cryLabEmbryo.Hide();
            pnReport.Hide();
        }

        private void BtnPreview_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

        }

        private void BtnSendEmail_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            pnReport.Hide();
            SetDefaultPrinter(ic.iniC.printerA4);
            lbEmail.Show();
            lbEmail.Text = "เตรียม Email";
            String filename = "", datetick = "", filenameEmbryo = "";
            DataTable dt = new DataTable();
            DataTable dtEmbryo = new DataTable();
            if (!Directory.Exists("report"))
            {
                Directory.CreateDirectory("report");
            }
            datetick = DateTime.Now.Ticks.ToString();
            filename = "report\\lab_opu_" + datetick + ".pdf";
            filenameEmbryo = "report\\lab_opu_embryo_" + datetick + ".pdf";
            lbEmail.Text = "เตรียม Report";
            Application.DoEvents();
            if (opureport == opuReport.ResultDay1)
            {
                filename = setExportDay1("preview");
            }
            else
            {
                if (opureport == opuReport.OPUReport)
                {
                    FrmWaiting frmW = new FrmWaiting();
                    frmW.Show();
                    dt = printOPUReport("");
                    frmW.Dispose();
                    dtEmbryo = printOPUEmbryoDev("");
                }
                else if (opureport == opuReport.OPUEmbryoDevReport)
                {
                    dt = printOPUEmbryoDev("");
                }
                else
                {
                    FrmWaiting frmW = new FrmWaiting();
                    frmW.Show();
                    dt = printOPUReport("");
                    frmW.Dispose();
                    dtEmbryo = printOPUEmbryoDev("");
                }
                if (chkEmbryoFreez2Col.Checked && chkEmbryoDev20.Checked)
                {
                    if (!setEmailOPU(dt, FrmReport.flagEmbryoDev.twocolumn, FrmReport.flagEmbryoDevMore20.More20, filename)) return;
                }
                else if (chkEmbryoFreez2Col.Checked && !chkEmbryoDev20.Checked)
                {
                    if (!setEmailOPU(dt, FrmReport.flagEmbryoDev.twocolumn, FrmReport.flagEmbryoDevMore20.Days2, filename)) return;
                }
                else if (!chkEmbryoFreez2Col.Checked && !chkEmbryoDev20.Checked)
                {
                    if (!setEmailOPU(dt, FrmReport.flagEmbryoDev.onecolumn, FrmReport.flagEmbryoDevMore20.Days2, filename)) return;
                }
                else if (!chkEmbryoFreez2Col.Checked && chkEmbryoDev20.Checked)
                {
                    if (!setEmailOPU(dt, FrmReport.flagEmbryoDev.onecolumn, FrmReport.flagEmbryoDevMore20.More20, filename)) return;
                }
                setEmailOPUPicEmbryo(dtEmbryo, filenameEmbryo);
            }
            

            if (!File.Exists(filename))
            {
                lbEmail.Text = "ไม่พบ Attach File";
                return;
            }
            lbEmail.Text = "เริ่มส่ง Email";
            MailMessage mail = new MailMessage();

            //txtEmailSubject.Value = "Routine LAB Result HN " + txtHnFeMale.Text + " Name " + txtNameFeMale.Text + " OPD Code " + txtOpuCode.Text + " Date " + System.DateTime.Now.ToString("dd/MM/") + System.DateTime.Now.Year;
            //txtEmailSubject.Value = "OPU Date "  + System.DateTime.Now.ToString("dd/MM/") + System.DateTime.Now.Year;

            mail.From = new MailAddress(ic.iniC.email_form_lab_opu);
            mail.To.Add(txtEmailTo.Text);
            mail.Subject = txtEmailSubject.Text;
            mail.Body = txtBody.Text;

            mail.IsBodyHtml = true;
            if (File.Exists(filename))
            {
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(filename);
                mail.Attachments.Add(attachment);
            }
            if (File.Exists(filenameEmbryo))
            {
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(filenameEmbryo);
                mail.Attachments.Add(attachment);
            }

            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(txtBody.Text, null, "text/html");
            mail.AlternateViews.Add(htmlView);

            foreach (LinkedResource linkimg in theEmailImage1)
            {
                htmlView.LinkedResources.Add(linkimg);
            }

            SmtpServer.Port = int.Parse(ic.iniC.email_port);
            SmtpServer.Credentials = new System.Net.NetworkCredential(ic.iniC.email_auth_user_lab_opu, ic.iniC.email_auth_pass_lab_opu);
            //SmtpServer.UseDefaultCredentials = true;
            SmtpServer.EnableSsl = Boolean.Parse(ic.iniC.email_ssl);
            SmtpServer.Send(mail);
            lbEmail.Text = "ส่ง Email เรียบร้อย";
        }
        private Boolean setEmailOPU(DataTable dt, flagEmbryoDev flagembryodev, flagEmbryoDevMore20 flagembryodevmore20, String filename)
        {
            if (dt == null) return false;
            Boolean chk = true;
            CrystalReportViewer cryLab;
            cryLab = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ReportDocument rpt = new ReportDocument();
            try
            {
                lbEmail.Text = "สร้าง Report";
                dt.Columns.Add("date_time_result", typeof(String));
                dt.Columns.Add("date_time_approve", typeof(String));
                String date1 = "", date2 = "", reqid="";
                //String date1 = dt.Rows[0]["date_time_result"].ToString();
                //String date2 = dt.Rows[0]["date_time_approve"].ToString();
                LabRequest lreq = new LabRequest();
                lreq = ic.ivfDB.lbReqDB.selectByPk1(opu.req_id);
                
                date1 = ic.datetimetoShow(lreq.result_date);
                date2 = ic.datetimetoShow(lreq.start_date);
                dt.Rows[0]["date_time_result"] = date1;
                dt.Rows[0]["date_time_approve"] = date2;
                if (flagembryodev == flagEmbryoDev.onecolumn)
                {
                    if (flagembryodevmore20 == flagEmbryoDevMore20.Days2)
                    {
                        rpt.Load("lab_opu.rpt");
                    }
                    else
                    {
                        rpt.Load("lab_opu_more_20.rpt");
                    }
                }
                else
                {
                    if (flagembryodevmore20 == flagEmbryoDevMore20.Days2)
                    {
                        rpt.Load("lab_opu_freeze_2_column.rpt");
                    }
                    else
                    {
                        rpt.Load("lab_opu_freeze_2_column_more_20.rpt");
                    }
                }
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                rpt.SetParameterValue("line2", "โทรศัพท์ " + ic.cop.tele);
                rpt.SetParameterValue("report_name", " Summary of OPU Report");
                //rpt.SetDataSource(dt);
                
                this.cryLab.ReportSource = rpt;
                this.cryLab.Refresh();
                lbEmail.Text = "สร้าง Report เรียบร้อย";
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                    System.Threading.Thread.Sleep(200);
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
                lbEmail.Text = "Export Report";
                Application.DoEvents();
                rpt.Export();
                System.Threading.Thread.Sleep(200);
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                chk = false;
                //chk = ex.Message.ToString();
                new LogWriter("e", "FrmLabOPUPrint setEmailOPU " + ex.Message);
                MessageBox.Show("error " + ex.Message, "");
            }
            return chk;
        }
        private Boolean setEmailOPUPicEmbryo(DataTable dt, String filename)
        {
            if (dt == null) return false;
            Boolean chk = true;
            CrystalReportViewer cryLab;
            cryLab = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ReportDocument rpt = new ReportDocument();
            try
            {
                lbEmail.Text = "สร้าง Report";
                Application.DoEvents();
                dt.Columns.Add("date_time_result", typeof(String));
                dt.Columns.Add("date_time_approve", typeof(String));
                String date1 = "", date2 = "", reqid = "";
                //String date1 = dt.Rows[0]["date_time_result"].ToString();
                //String date2 = dt.Rows[0]["date_time_approve"].ToString();
                LabRequest lreq = new LabRequest();
                lreq = ic.ivfDB.lbReqDB.selectByPk1(opu.req_id);

                date1 = ic.datetimetoShow(lreq.result_date);
                date2 = ic.datetimetoShow(lreq.start_date);
                dt.Rows[0]["date_time_result"] = date1;
                dt.Rows[0]["date_time_approve"] = date2;

                rpt.Load("lab_opu_embryo_dev.rpt");
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                rpt.SetParameterValue("line2", "โทรศัพท์ " + ic.cop.tele);
                rpt.SetParameterValue("report_name", " Embryo development");

                this.cryLab.ReportSource = rpt;
                this.cryLab.Refresh();
                lbEmail.Text = "สร้าง Report เรียบร้อย";
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
                lbEmail.Text = "Export Report";
                Application.DoEvents();
                rpt.Export();
                System.Threading.Thread.Sleep(200);
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                chk = false;
                //chk = ex.Message.ToString();
                new LogWriter("e", "FrmLabOPUPrint setEmailOPUPicEmbryo " + ex.Message);
                MessageBox.Show("error " + ex.Message, "");
            }
            return chk;
        }
        private void BtnExport_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if(opureport == opuReport.ResultDay3)
            {
                FrmWaiting frmW = new FrmWaiting();
                frmW.Show();
                setExportDay3("");
                frmW.Dispose();
                Application.DoEvents();
                System.Threading.Thread.Sleep(200);
                this.Dispose();
            }
            else if (opureport == opuReport.ResultDay5)
            {
                FrmWaiting frmW = new FrmWaiting();
                frmW.Show();
                setExportDay5("");
                frmW.Dispose();
                Application.DoEvents();
                System.Threading.Thread.Sleep(200);
                this.Dispose();
            }
            else if (opureport == opuReport.ResultDay6)
            {
                FrmWaiting frmW = new FrmWaiting();
                frmW.Show();
                setExportDay6("");
                frmW.Dispose();
                Application.DoEvents();
                System.Threading.Thread.Sleep(200);
                this.Dispose();
            }
            else if (opureport == opuReport.ResultDay1)
            {
                FrmWaiting frmW = new FrmWaiting();
                frmW.Show();
                setExportDay1("");
                frmW.Dispose();
                Application.DoEvents();
                System.Threading.Thread.Sleep(200);
                this.Dispose();
            }
            else if (opureport == opuReport.ResultDay0)
            {
                FrmWaiting frmW = new FrmWaiting();
                frmW.Show();
                setExportDay0("");
                frmW.Dispose();
                Application.DoEvents();
                System.Threading.Thread.Sleep(200);
                this.Dispose();
            }
            else if (opureport == opuReport.ResultDay2)
            {
                FrmWaiting frmW = new FrmWaiting();
                frmW.Show();
                setExportDay2("");
                frmW.Dispose();
                Application.DoEvents();
                System.Threading.Thread.Sleep(200);
                this.Dispose();
            }
            else
            {
                setExportOPU();
            }
        }
        private String setExportDay6(String flagPreview)
        {
            ReportDocument rpt;
            CrystalReportViewer crv = new CrystalReportViewer();
            String filename = "", directory = "", ext = ".pdf", datetick = "";
            directory = AppDomain.CurrentDomain.BaseDirectory;
            datetick = DateTime.Now.Ticks.ToString();
            filename = directory + "report\\" + datetick + ext;
            rpt = new ReportDocument();
            DataTable dt = new DataTable();
            dt = printOPUReport("");
            if (dt == null) return "";
            try
            {
                String rptname = setRptName();
                rpt.Load(rptname);
                crv.ReportSource = rpt;
                //System.Threading.Thread.Sleep(200);
                crv.Refresh();
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                rpt.SetParameterValue("line2", "โทรศัพท์ " + ic.cop.tele);
                rpt.SetParameterValue("report_name", "Summary of OPU Report");
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
                //Application.DoEvents();
                //System.Threading.Thread.Sleep(200);
                rpt.Export();
                //Application.DoEvents();
                //System.Threading.Thread.Sleep(200);
                //new LogWriter("d", "FrmLabOPUPrint rpt.Export(); "+ filename);
                String filenameembryo = directory + "report\\" + datetick + "_embryo_day6" + ext;
                DataTable dtEmbryo = new DataTable();
                dtEmbryo = printOPUEmbryoDev("");
                setEmailOPUPicEmbryo(dtEmbryo, filenameembryo);
                Application.DoEvents();
                //System.Threading.Thread.Sleep(100);
                if (flagPreview.Equals("preview")) return filename;
                if (File.Exists(filename))
                {
                    long chk1 = 0;
                    String filename1 = Path.GetFileName(filename);
                    //new LogWriter("d", "FrmLabOPUPrint ic.savePicOPUtoServer(txtOpuCode.Text, filename1, filename); opu.opu_code, filename1 " + opu.opu_code+" " + filename1);
                    ic.savePicOPUtoServer(txtOpuCode.Text, filename1, filename);
                    String re = ic.ivfDB.opuDB.updateStatusOPUApproveResultDay6(txtID.Text, filename1, ic.user.staff_id);
                    opu.report_day6 = filename1;
                    ic.opu_report_day6 = filename1;
                    if (long.TryParse(re, out chk1))
                    {
                        LabRequest req = new LabRequest();
                        req = ic.ivfDB.lbReqDB.selectByPk1(opu.req_id);
                        String re1 = ic.ivfDB.lbReqDB.UpdateStatusRequestResult(req.req_id, ic.user.staff_id);

                        if (long.TryParse(re1, out chk1))
                        {
                            ic.statusResult = "1";
                            //MessageBox.Show("ส่งผล LAB OPU Day3 ให้ทางพยาบาล เรียบร้อย ", "");       //clinic_ivf.Properties.Resources.Female_user_accept_24
                            //btnApproveResult.Image = Resources.Female_user_accept_24;
                        }
                    }
                }
                //Report Embryo
                
                if (File.Exists(filename))
                {
                    long chk1 = 0;
                    String filename1 = Path.GetFileName(filename);
                    ic.savePicOPUtoServer(txtOpuCode.Text, filename1, filename);

                }
            }
            catch (Exception ex)
            {
                new LogWriter("e", "FrmLabOPUPrint BtnExport_Click " + ex.Message);
                MessageBox.Show(ex.ToString());
            }
            return "";
        }
        private String setRptName()
        {
            String rptname = "";
            if (chkEmbryoDev20.Checked && chkEmbryoFreez2Col.Checked)// more20_oneday, two_column
            {
                //rpt.Load("lab_opu_freeze_2_column.rpt");
                //rpt.Load("lab_opu_freeze_2_column_more_20.rpt");
                rptname = "lab_opu_freeze_2_column_more_20.rpt";
            }
            else if (!chkEmbryoDev20.Checked && chkEmbryoFreez2Col.Checked)// two_day, two_column
            {
                //rpt.Load("lab_opu_freeze_2_column_more_20.rpt");
                //rpt.Load("lab_opu_freeze_2_column.rpt");
                rptname = "lab_opu_freeze_2_column.rpt";
            }
            else if (chkEmbryoDev20.Checked && !chkEmbryoFreez2Col.Checked)   // more20_oneday, one_column
            {
                //rpt.Load("lab_opu_more_20.rpt");
                rptname = "lab_opu_more_20.rpt";
            }
            else if (!chkEmbryoDev20.Checked && !chkEmbryoFreez2Col.Checked)   // two_day, one_column
            {
                //rpt.Load("lab_opu_more_20.rpt");
                //rpt.Load("lab_opu.rpt");
                rptname = "lab_opu.rpt";
            }
            else
            {

            }
            return rptname;
        }
        private String setExportDay5(String flagPreview)
        {
            ReportDocument rpt;
            CrystalReportViewer crv = new CrystalReportViewer();
            String filename = "", directory = "", ext = ".pdf", datetick = "";
            directory = AppDomain.CurrentDomain.BaseDirectory;
            datetick = DateTime.Now.Ticks.ToString();
            filename = directory + "report\\" + datetick + ext;
            rpt = new ReportDocument();
            DataTable dt = new DataTable();
            dt = printOPUReport("");
            if (dt == null) return "";
            try
            {
                String rptname = setRptName();
                rpt.Load(rptname);
                crv.ReportSource = rpt;
                //System.Threading.Thread.Sleep(200);
                crv.Refresh();
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                rpt.SetParameterValue("line2", "โทรศัพท์ " + ic.cop.tele);
                rpt.SetParameterValue("report_name", "Summary of OPU Report");
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
                //Application.DoEvents();
                //System.Threading.Thread.Sleep(200);
                //new LogWriter("d", "FrmLabOPUPrint rpt.Export(); "+ filename);
                String filenameembryo = directory + "report\\" + datetick + "_embryo_day5" + ext;
                DataTable dtEmbryo = new DataTable();
                dtEmbryo = printOPUEmbryoDev("");
                setEmailOPUPicEmbryo(dtEmbryo, filenameembryo);
                Application.DoEvents();
                //System.Threading.Thread.Sleep(100);
                if (flagPreview.Equals("preview")) return filename;
                if (File.Exists(filename))
                {
                    long chk1 = 0;
                    String filename1 = Path.GetFileName(filename);
                    //new LogWriter("d", "FrmLabOPUPrint ic.savePicOPUtoServer(txtOpuCode.Text, filename1, filename); opu.opu_code, filename1 " + opu.opu_code+" " + filename1);
                    ic.savePicOPUtoServer(txtOpuCode.Text, filename1, filename);
                    String re = ic.ivfDB.opuDB.updateStatusOPUApproveResultDay5(txtID.Text, filename1, ic.user.staff_id);
                    opu.report_day5 = filename1;
                    ic.opu_report_day5 = filename1;
                    if (long.TryParse(re, out chk1))
                    {
                        LabRequest req = new LabRequest();
                        req = ic.ivfDB.lbReqDB.selectByPk1(opu.req_id);
                        String re1 = ic.ivfDB.lbReqDB.UpdateStatusRequestResult(req.req_id, ic.user.staff_id);

                        if (long.TryParse(re1, out chk1))
                        {
                            ic.statusResult = "1";
                            //MessageBox.Show("ส่งผล LAB OPU Day3 ให้ทางพยาบาล เรียบร้อย ", "");       //clinic_ivf.Properties.Resources.Female_user_accept_24
                            //btnApproveResult.Image = Resources.Female_user_accept_24;
                        }
                    }
                }
                //Report Embryo
                
                if (File.Exists(filenameembryo))
                {
                    long chk1 = 0;
                    String filename1 = Path.GetFileName(filenameembryo);
                    ic.savePicOPUtoServer(txtOpuCode.Text, filename1, filenameembryo);

                }
            }
            catch (Exception ex)
            {
                new LogWriter("e", "FrmLabOPUPrint BtnExport_Click " + ex.Message);
                MessageBox.Show(ex.ToString());
            }
            return "";
        }
        private String setExportDay3(String flagPreview)
        {
            ReportDocument rpt;
            CrystalReportViewer crv = new CrystalReportViewer();
            String filename = "", directory = "", ext = ".pdf", datetick="";
            directory = AppDomain.CurrentDomain.BaseDirectory;
            datetick = DateTime.Now.Ticks.ToString();
            filename = directory + "report\\" + datetick + ext;
            rpt = new ReportDocument();
            DataTable dt = new DataTable();
            dt = printOPUReport("");
            try
            {
                String rptname = setRptName();
                rpt.Load(rptname);
                crv.ReportSource = rpt;
                //System.Threading.Thread.Sleep(200);
                crv.Refresh();
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                rpt.SetParameterValue("line2", "โทรศัพท์ " + ic.cop.tele);
                rpt.SetParameterValue("report_name", "Summary of OPU Report");
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
                //Application.DoEvents();
                //System.Threading.Thread.Sleep(200);
                //new LogWriter("d", "FrmLabOPUPrint rpt.Export(); "+ filename);


                String filenameembryo = directory + "report\\" + datetick + "_embryo_day3" + ext;
                DataTable dtEmbryo = new DataTable();
                dtEmbryo = printOPUEmbryoDev("");
                setEmailOPUPicEmbryo(dtEmbryo, filenameembryo);
                //Application.DoEvents();
                //System.Threading.Thread.Sleep(200);
                if (flagPreview.Equals("preview")) return filename;
                                
                if (File.Exists(filename))
                {
                    long chk1 = 0;
                    String filename1 = Path.GetFileName(filename);
                    //new LogWriter("d", "FrmLabOPUPrint ic.savePicOPUtoServer(txtOpuCode.Text, filename1, filename); opu.opu_code, filename1 " + opu.opu_code+" " + filename1);
                    ic.savePicOPUtoServer(txtOpuCode.Text, filename1, filename);
                    String re = ic.ivfDB.opuDB.updateStatusOPUApproveResultDay3(txtID.Text, filename1, ic.user.staff_id);
                    opu.report_day3 = filename1;
                    ic.opu_report_day3 = filename1;
                    if (long.TryParse(re, out chk1))
                    {
                        LabRequest req = new LabRequest();
                        req = ic.ivfDB.lbReqDB.selectByPk1(opu.req_id);
                        String re1 = ic.ivfDB.lbReqDB.UpdateStatusRequestResult(req.req_id, ic.user.staff_id);

                        if (long.TryParse(re1, out chk1))
                        {
                            ic.statusResult = "1";
                            //MessageBox.Show("ส่งผล LAB OPU Day3 ให้ทางพยาบาล เรียบร้อย ", "");       //clinic_ivf.Properties.Resources.Female_user_accept_24
                            //btnApproveResult.Image = Resources.Female_user_accept_24;
                        }
                    }
                }
                if (File.Exists(filenameembryo))
                {
                    long chk1 = 0;
                    String filename1 = Path.GetFileName(filenameembryo);
                    ic.savePicOPUtoServer(txtOpuCode.Text, filename1, filenameembryo);
                }

                //Report Embryo

            }
            catch (Exception ex)
            {
                new LogWriter("e", "FrmLabOPUPrint BtnExport_Click " + ex.Message);
                MessageBox.Show(ex.ToString());
            }
            return "";
        }
        private String setExportDay2(String flagPreview)
        {
            ReportDocument rpt;
            CrystalReportViewer crv = new CrystalReportViewer();
            String filename = "", directory = "", ext = ".pdf", datetick = "";
            directory = AppDomain.CurrentDomain.BaseDirectory;
            datetick = DateTime.Now.Ticks.ToString();
            filename = directory + "report\\" + datetick + ext;
            rpt = new ReportDocument();
            DataTable dt = new DataTable();
            dt = printOPUReport("");
            try
            {
                String rptname = setRptName();
                rpt.Load(rptname);
                crv.ReportSource = rpt;
                //System.Threading.Thread.Sleep(200);
                crv.Refresh();
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                rpt.SetParameterValue("line2", "โทรศัพท์ " + ic.cop.tele);
                rpt.SetParameterValue("report_name", "Summary of OPU Report");
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
                //Application.DoEvents();
                //System.Threading.Thread.Sleep(200);
                //new LogWriter("d", "FrmLabOPUPrint rpt.Export(); "+ filename);

                //Report Embryo
                String filenameembryo = directory + "report\\" + datetick + "_embryo_day2" + ext;
                DataTable dtEmbryo = new DataTable();
                dtEmbryo = printOPUEmbryoDev("");
                setEmailOPUPicEmbryo(dtEmbryo, filenameembryo);
                //Application.DoEvents();
                //System.Threading.Thread.Sleep(200);
                

                if (flagPreview.Equals("preview")) return filename;
                if (File.Exists(filename))
                {
                    long chk1 = 0;
                    String filename1 = Path.GetFileName(filename);
                    //new LogWriter("d", "FrmLabOPUPrint ic.savePicOPUtoServer(txtOpuCode.Text, filename1, filename); opu.opu_code, filename1 " + opu.opu_code+" " + filename1);
                    ic.savePicOPUtoServer(txtOpuCode.Text, filename1, filename);
                    String re = ic.ivfDB.opuDB.updateStatusOPUApproveResultDay2(txtID.Text, filename1, ic.user.staff_id);
                    opu.report_day2 = filename1;
                    ic.opu_report_day2 = filename1;
                    if (long.TryParse(re, out chk1))
                    {
                        LabRequest req = new LabRequest();
                        req = ic.ivfDB.lbReqDB.selectByPk1(opu.req_id);
                        String re1 = ic.ivfDB.lbReqDB.UpdateStatusRequestResult(req.req_id, ic.user.staff_id);

                        if (long.TryParse(re1, out chk1))
                        {
                            ic.statusResult = "1";
                            //MessageBox.Show("ส่งผล LAB OPU Day3 ให้ทางพยาบาล เรียบร้อย ", "");       //clinic_ivf.Properties.Resources.Female_user_accept_24
                            //btnApproveResult.Image = Resources.Female_user_accept_24;
                        }
                    }
                }
                if (File.Exists(filenameembryo))
                {
                    long chk1 = 0;
                    String filename1 = Path.GetFileName(filenameembryo);
                    ic.savePicOPUtoServer(txtOpuCode.Text, filename1, filenameembryo);
                }
            }
            catch (Exception ex)
            {
                new LogWriter("e", "FrmLabOPUPrint BtnExport_Click " + ex.Message);
                MessageBox.Show(ex.ToString());
            }
            return "";
        }
        private String setExportDay1(String flagPreview)
        {
            Boolean chk = true;
            DataTable dt = new DataTable();
            CrystalReportViewer cryLab;
            cryLab = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ReportDocument rpt = new ReportDocument();
            String filename = "", directory = "", ext = ".pdf";
            directory = AppDomain.CurrentDomain.BaseDirectory;
            filename = directory + "report\\" + DateTime.Now.Ticks.ToString() + ext;

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
            if (flagPreview.Equals("preview")) return filename;

            if (File.Exists(filename))
            {
                long chk1 = 0;
                String filename1 = Path.GetFileName(filename);
                //new LogWriter("d", "FrmLabOPUPrint ic.savePicOPUtoServer(txtOpuCode.Text, filename1, filename); opu.opu_code, filename1 " + opu.opu_code+" " + filename1);
                ic.savePicOPUtoServer(txtOpuCode.Text, filename1, filename);
                String re = ic.ivfDB.opuDB.updateStatusOPUApproveResultDay1(txtID.Text, filename1, ic.user.staff_id);
                opu.report_day1 = filename1;
                ic.opu_report_day1 = filename1;
                if (long.TryParse(re, out chk1))
                {
                    LabRequest req = new LabRequest();
                    req = ic.ivfDB.lbReqDB.selectByPk1(opu.req_id);
                    String re1 = ic.ivfDB.lbReqDB.UpdateStatusRequestResult(req.req_id, ic.user.staff_id.Length<=0 ? "0": ic.user.staff_id);

                    if (long.TryParse(re1, out chk1))
                    {
                        ic.statusResultDay1 = "1";
                        //MessageBox.Show("ส่งผล LAB OPU Day3 ให้ทางพยาบาล เรียบร้อย ", "");       //clinic_ivf.Properties.Resources.Female_user_accept_24
                        //btnApproveResult.Image = Resources.Female_user_accept_24;
                    }
                }
            }
            return "";
        }
        private String setExportDay0(String flagPreview)
        {
            Boolean chk = true;
            DataTable dt = new DataTable();
            CrystalReportViewer cryLab;
            cryLab = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ReportDocument rpt = new ReportDocument();
            String filename = "", directory = "", ext = ".pdf";
            directory = AppDomain.CurrentDomain.BaseDirectory;
            filename = directory + "report\\" + DateTime.Now.Ticks.ToString() + ext;

            try
            {
                dt = ic.ivfDB.setOPUReport(txtID.Text, "2", "3", true);     //ต้องการดึงเพื่อส่ง day1 
                foreach(DataRow drow in dt.Rows)
                {
                    drow["fertili_date"] = drow["fertili_date"] != null ? drow["fertili_date"].ToString().Equals("") ? "-" : drow["fertili_date"].ToString():"-";
                    drow["sperm_date"] = drow["sperm_date"] != null ? drow["sperm_date"].ToString().Equals("") ? "-" : drow["sperm_date"].ToString() : "-";
                    drow["embryo_freez_day_0"] = drow["embryo_freez_day_0"] != null ? drow["embryo_freez_day_0"].ToString().Equals("") ? "0" : drow["embryo_freez_day_0"].ToString() : "0";
                }
                rpt.Load("lab_opu_day0.rpt");
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
                new LogWriter("e", "FrmLabOPUAdd2 setExportDay0 " + ex.Message);
                MessageBox.Show("error " + ex.Message, "");
            }
            if (flagPreview.Equals("preview")) return filename;

            if (File.Exists(filename))
            {
                long chk1 = 0;
                String filename1 = Path.GetFileName(filename);
                //new LogWriter("d", "FrmLabOPUPrint ic.savePicOPUtoServer(txtOpuCode.Text, filename1, filename); opu.opu_code, filename1 " + opu.opu_code+" " + filename1);
                ic.savePicOPUtoServer(txtOpuCode.Text, filename1, filename);
                String re = ic.ivfDB.opuDB.updateStatusOPUApproveResultDay0(txtID.Text, filename1, ic.user.staff_id);
                opu.report_day0 = filename1;
                ic.opu_report_day0 = filename1;
                if (long.TryParse(re, out chk1))
                {
                    LabRequest req = new LabRequest();
                    req = ic.ivfDB.lbReqDB.selectByPk1(opu.req_id);
                    String re1 = ic.ivfDB.lbReqDB.UpdateStatusRequestResult(req.req_id, ic.user.staff_id);

                    if (long.TryParse(re1, out chk1))
                    {
                        ic.statusResultDay0 = "1";
                        //MessageBox.Show("ส่งผล LAB OPU Day3 ให้ทางพยาบาล เรียบร้อย ", "");       //clinic_ivf.Properties.Resources.Female_user_accept_24
                        //btnApproveResult.Image = Resources.Female_user_accept_24;
                    }
                }
            }
            return "";
        }
        private void setExportOPU()
        {
            DataTable dt = new DataTable();
            dt = ic.ivfDB.setOPUReport(txtID.Text, cboEmbryoDev1.Text, cboEmbryoDev2.Text, chkEmbryoDev20.Checked);
            try
            {
                ReportDocument rpt;
                CrystalReportViewer crv = new CrystalReportViewer();
                rpt = new ReportDocument();
                rpt.Load("lab_opu_more_20.rpt");
                crv.ReportSource = rpt;

                crv.Refresh();
                //rpt.Load(Application.StartupPath + "\\lab_opu_embryo_dev.rpt");
                //rd.Load("StudentReg.rpt");
                rpt.SetDataSource(dt);
                //crv.ReportSource = rd;
                //crv.Refresh();
                if (File.Exists("embryo.pdf"))
                    File.Delete("embryo.pdf");

                ExportOptions CrExportOptions;
                DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                CrDiskFileDestinationOptions.DiskFileName = "embryo.pdf";
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
                MessageBox.Show(ex.ToString());
            }
        }
        private void ChkEmbryoDev20_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (chkEmbryoDev20.Checked)
            {
                cboEmbryoDev2.Enabled = false;
            }
            else
            {
                cboEmbryoDev2.Enabled = true;
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (opureport == opuReport.OPUReport)
            {
                printOPUReport("print");
            }
            else if (opureport == opuReport.OPUEmbryoDevReport)
            {
                printOPUEmbryoDev("print");
            }
            else if (opureport == opuReport.ResultDay6)
            {
                FrmWaiting frmW = new FrmWaiting();
                frmW.Show();
                String filename = "";
                filename = setExportDay6("preview");
                if (File.Exists(filename))
                {
                    ic.showResultDay(txtID.Text.Trim(),"6",this, filename);
                }
                frmW.Dispose();
            }
            else if (opureport == opuReport.ResultDay5)
            {
                FrmWaiting frmW = new FrmWaiting();
                frmW.Show();
                String filename = "";
                filename = setExportDay5("preview");
                if (File.Exists(filename))
                {
                    ic.showResultDay(txtID.Text.Trim(), "5", this, filename);
                }
                frmW.Dispose();
            }
            else if (opureport == opuReport.ResultDay3)
            {
                FrmWaiting frmW = new FrmWaiting();
                frmW.Show();
                String filename = "";
                filename = setExportDay3("preview");
                if (File.Exists(filename))
                {
                    ic.showResultDay(txtID.Text.Trim(), "3", this, filename);
                }
                frmW.Dispose();

                //ic.showResultDay(txtID.Text.Trim(), "3", this);
            }
            else if (opureport == opuReport.ResultDay2)
            {
                FrmWaiting frmW = new FrmWaiting();
                frmW.Show();
                String filename = "";
                filename = setExportDay2("preview");
                if (File.Exists(filename))
                {
                    ic.showResultDay(txtID.Text.Trim(), "2", this, filename);
                }
                //printFETEmbryoDev();
                frmW.Dispose();
            }
            else if (opureport == opuReport.ResultDay1)
            {
                String filename = "";
                filename = setExportDay1("preview");
                if (File.Exists(filename))
                {
                    createForm(filename);
                }
            }
            else if (opureport == opuReport.ResultDay0)
            {
                String filename = "";
                filename = setExportDay0("preview");
                if (File.Exists(filename))
                {
                    createForm(filename);
                }
            }
            
            else if (opureport == opuReport.FETEmbryoDevReport)
            {
                //printFETEmbryoDev();
            }
        }
        private void createForm(String filename)
        {
            Form frm = new Form();
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

            pds.LoadFromFile(filename);

            //pds.LoadFromFile(filename1);

            day1View.DocumentSource = pds;
            frm.Controls.Add(day1View);
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog(this);
        }
        private void printFETEmbryoDev()
        {
            //FrmReport frm = new FrmReport(ic);
            //DataTable dt = new DataTable();
            //FrmWaiting frmW = new FrmWaiting();
            //frmW.Show();
            //try
            //{
            //    int i = 0;
            //    String day = "";
            //    LabFet fet = new LabFet();
            //    fet = ic.ivfDB.fetDB.selectByPk1(txtID.Text);
            //    day = cboEmbryoDev1.SelectedItem == null ? "" : ((ComboBoxItem)cboEmbryoDev1.SelectedItem).Value;
            //    if (day.Equals("2"))
            //    {
            //        dt = ic.ivfDB.opuEmDevDB.selectByFetFetId_DayPrint(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day2);
            //    }
            //    else if (day.Equals("3"))
            //    {
            //        dt = ic.ivfDB.opuEmDevDB.selectByFetFetId_DayPrint(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day3);
            //    }
            //    else if (day.Equals("5"))
            //    {
            //        dt = ic.ivfDB.opuEmDevDB.selectByFetFetId_DayPrint(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day5);
            //    }
            //    else if (day.Equals("6"))
            //    {
            //        dt = ic.ivfDB.opuEmDevDB.selectByFetFetId_DayPrint(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day6);
            //    }
            //    if (dt.Rows.Count > 0)
            //    {
            //        frmW.pB.Minimum = 1;
            //        frmW.pB.Maximum = dt.Rows.Count;
            //        foreach (DataRow row in dt.Rows)
            //        {
            //            String path_pic = "", opuCode = "";
            //            path_pic = row["no1_pathpic"] != null ? row["no1_pathpic"].ToString() : "";
            //            opuCode = row["fet_code"] != null ? row["fet_code"].ToString() : "";
            //            if (!path_pic.Equals(""))
            //            {
            //                MemoryStream stream = ic.ftpC.download(path_pic);
            //                Image loadedImage = new Bitmap(stream);
            //                String[] ext = path_pic.Split('.');
            //                var extension = Path.GetExtension(path_pic);
            //                var name = Path.GetFileNameWithoutExtension(path_pic); // Get the name only
            //                //if (ext.Length > 0)
            //                //{
            //                String filename = name;
            //                String no = "", filename1 = "", st = "";
            //                no = filename.Substring(filename.Length - 2);
            //                no = no.Replace("_", "");
            //                filename1 = "embryo_dev_" + no + extension;
            //                if (File.Exists(filename1))
            //                {
            //                    File.Delete(filename1);
            //                    System.Threading.Thread.Sleep(200);
            //                }
            //                loadedImage.Save(filename1);
            //                row["no1_pathpic"] = System.IO.Directory.GetCurrentDirectory() + "\\" + filename1;
            //                //st = row["no1_desc2"].ToString();
            //                st = row["no1_desc3"].ToString();
            //                row["no1_desc2"] = "st# " + st;
            //                row["no1_desc3"] = row["no1_desc4"].ToString();
            //                //}footer11
            //            }
            //            //row["footer11"] = opu.remark_day2;
            //            //row["footer12"] = opu.remark_day3;
            //            //row["footer13"] = opu.remark_day5;
            //            //row["footer14"] = opu.remark_day6;
            //            //row["footer15"] = "";
            //            //row["footer16"] = "";
            //            i++;
            //            frmW.pB.Value = i;
            //        }
            //    }
            //    String date1 = "";
            //    date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.fetDB.fet.fet_date].ToString());
            //    dt.Rows[0][ic.ivfDB.fetDB.fet.fet_date] = date1.Replace("-", "/");

            //    frm.setFETEmbryoDevReport(dt);

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("" + ex.Message, "");
            //}
            //finally
            //{
            //    frmW.Dispose();
            //}
            //frm.ShowDialog(this);
        }
        private DataTable printOPUReport(String flagPrint)
        {
            DataTable dt = new DataTable();
            DataTable dtchkday2 = new DataTable();
            if (cboEmbryoDev2.Text.Trim().Equals("3"))
            {
                dtchkday2 = ic.ivfDB.opuEmDevDB.selectByOpuFetId_Day(opuId, objdb.LabOpuEmbryoDevDB.Day1.Day3);
            }
            else if (cboEmbryoDev2.Text.Trim().Equals("5"))
            {
                dtchkday2 = ic.ivfDB.opuEmDevDB.selectByOpuFetId_Day(opuId, objdb.LabOpuEmbryoDevDB.Day1.Day5);
            }
            if (cboEmbryoDev2.Text.Trim().Equals("6"))
            {
                dtchkday2 = ic.ivfDB.opuEmDevDB.selectByOpuFetId_Day(opuId, objdb.LabOpuEmbryoDevDB.Day1.Day6);
            }
            else if (cboEmbryoDev2.Text.Trim().Equals("2"))
            {
                dtchkday2 = ic.ivfDB.opuEmDevDB.selectByOpuFetId_Day(opuId, objdb.LabOpuEmbryoDevDB.Day1.Day2);
            }
            //if (dtchkday2.Rows.Count <= 0)
            //{
            //    MessageBox.Show("Day2 no data ", "");
            //    return dt;
            //}
            FrmReport frm = new FrmReport(ic);
            dt = ic.ivfDB.setOPUReport(txtID.Text, cboEmbryoDev1.Text, cboEmbryoDev2.Text, chkEmbryoDev20.Checked);
            if (dt == null) return null;
            if (chkEmbryoFreez2Col.Checked)
            {
                if (flagPrint.Equals("print"))
                {
                    if (chkEmbryoDev20.Checked)
                    {
                        frm.setOPUReport(dt, FrmReport.flagEmbryoDev.twocolumn, FrmReport.flagEmbryoDevMore20.More20);
                    }
                    else
                    {
                        frm.setOPUReport(dt, FrmReport.flagEmbryoDev.twocolumn, FrmReport.flagEmbryoDevMore20.Days2);
                    }
                }
            }
            else
            {
                if (flagPrint.Equals("print"))
                {
                    if (chkEmbryoDev20.Checked)
                    {
                        frm.setOPUReport(dt, FrmReport.flagEmbryoDev.onecolumn, FrmReport.flagEmbryoDevMore20.More20);
                    }
                    else
                    {
                        frm.setOPUReport(dt, FrmReport.flagEmbryoDev.onecolumn, FrmReport.flagEmbryoDevMore20.Days2);
                    }
                }
            }
            //dt.AcceptChanges();
            if (flagPrint.Equals("print"))
            {
                frm.ShowDialog(this);
            }
            else
            {
                frm.Dispose();
            }
            return dt;
            //frm.setOPUReport(dt);
        }
        private DataTable printOPUEmbryoDev(String flagPrint)
        {
            FrmReport frm = new FrmReport(ic);
            DataTable dt = new DataTable();
            FrmWaiting frmW = new FrmWaiting();
            frmW.Show();
            try
            {
                //MessageBox.Show("aaaaa", "");
                int i = 0;
                String day = "";
                LabOpu opu = new LabOpu();
                opu = ic.ivfDB.opuDB.selectByPk1(txtID.Text);
                if (flagPrint.Equals("print"))
                {
                    day = cboEmbryoDev1.SelectedItem == null ? "" : ((ComboBoxItem)cboEmbryoDev1.SelectedItem).Value;
                }
                else if (flagPrint.Equals("day3"))
                {
                    day = "3";
                }
                else if (opureport == opuReport.ResultDay2)
                {
                    day = "2";
                }
                else
                {
                    day = cboEmbryoDev3.SelectedItem == null ? "" : ((ComboBoxItem)cboEmbryoDev3.SelectedItem).Value;
                }
                
                if (!day.Equals("2"))
                {
                    if (!day.Equals("3"))
                    {
                        if (!day.Equals("5"))
                        {
                            if (!day.Equals("6"))
                            {
                                MessageBox.Show("ไม่พบ day ของ ส่ง email Embryo Development", "");
                            }
                        }
                    }
                }
                if (day.Equals("2"))
                {
                    dt = ic.ivfDB.opuEmDevDB.selectByOpuFetId_DayPrint(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day2);
                }
                else if (day.Equals("3"))
                {
                    dt = ic.ivfDB.opuEmDevDB.selectByOpuFetId_DayPrint(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day3);
                }
                else if (day.Equals("5"))
                {
                    dt = ic.ivfDB.opuEmDevDB.selectByOpuFetId_DayPrint(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day5);
                }
                else if (day.Equals("6"))
                {
                    dt = ic.ivfDB.opuEmDevDB.selectByOpuFetId_DayPrint(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day6);
                }
                dt.Columns.Add("footer11", typeof(String));
                dt.Columns.Add("footer12", typeof(String));
                dt.Columns.Add("footer13", typeof(String));
                dt.Columns.Add("footer14", typeof(String));
                dt.Columns.Add("footer15", typeof(String));
                dt.Columns.Add("footer16", typeof(String));
                if (dt.Rows.Count > 0)
                {
                    frmW.pB.Minimum = 1;
                    frmW.pB.Maximum = dt.Rows.Count;
                    foreach (DataRow row in dt.Rows)
                    {
                        String path_pic = "", opuCode = "";
                        path_pic = row["no1_pathpic"] != null ? row["no1_pathpic"].ToString() : "";
                        opuCode = row["opu_code"] != null ? row["opu_code"].ToString() : "";
                        if (!path_pic.Equals(""))
                        {
                            MemoryStream stream = ic.ftpC.download(path_pic);
                            try
                            {
                                Image loadedImage = new Bitmap(stream);
                                String[] ext = path_pic.Split('.');
                                var extension = Path.GetExtension(path_pic);
                                var name = Path.GetFileNameWithoutExtension(path_pic); // Get the name only
                                                                                       //if (ext.Length > 0)
                                                                                       //{
                                String filename = name;
                                String no = "", filename1 = "", st = "";
                                no = filename.Substring(filename.Length - 2);
                                no = no.Replace("_", "");
                                filename1 = "embryo_dev_" + no + extension;
                                if (File.Exists(filename1))
                                {
                                    File.Delete(filename1);
                                    System.Threading.Thread.Sleep(200);
                                }
                                loadedImage.Save(filename1);
                                row["no1_pathpic"] = System.IO.Directory.GetCurrentDirectory() + "\\" + filename1;
                                //st = row["no1_desc2"].ToString();
                                st = row["no1_desc3"].ToString();
                                if (st.Length >= 1)
                                {
                                    row["no1_desc2"] = "st# " + st;
                                }
                                else
                                {
                                    row["no1_desc2"] = "";
                                }
                                row["no1_desc3"] = row["no1_desc4"].ToString();
                                //}footer11
                            }
                            catch (Exception ex)
                            {

                            }
                            
                        }
                        //row["footer11"] = opu.remark_day2;
                        //row["footer12"] = opu.remark_day3;
                        //row["footer13"] = opu.remark_day5;
                        //row["footer14"] = opu.remark_day6;
                        row["footer15"] = "";
                        row["footer16"] = "";
                        if(day.Equals("6"))
                        {
                            row["footer5"] = opu.remark_1;
                        }
                        i++;
                        frmW.pB.Value = i;
                    }
                }
                String date1 = "";
                date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.opuDB.opu.opu_date].ToString());
                dt.Rows[0][ic.ivfDB.opuDB.opu.opu_date] = date1.Replace("-", "/");

                frm.setOPUEmbryoDevReport(dt);
                //MessageBox.Show("bbbbbb", "");
            }
            catch (Exception ex)
            {
                ic.logw.WriteLog("e", "error printOPUEmbryoDev " + ex.Message);
                MessageBox.Show("" + ex.Message, "");
            }
            finally
            {
                frmW.Dispose();
            }
            if (flagPrint.Equals("print"))
            {
                frm.ShowDialog(this);
            }
            else
            {
                frm.Dispose();
            }
            return dt;
        }
        private void setControl()
        {
            if(opureport == opuReport.OPUReport || opureport == opuReport.OPUEmbryoDevReport || opureport == opuReport.ResultDay3)
            {
                opu = ic.ivfDB.opuDB.selectByPk1(opuId);
                txtID.Value = opu.opu_id;
                txtHnFeMale.Value = opu.hn_female;
                txtHnMale.Value = opu.hn_male;
                txtNameFeMale.Value = opu.name_female;
                txtNameMale.Value = opu.name_male;
                txtOpuCode.Value = opu.opu_code;
                txtEmailTo.Value = ic.iniC.email_to_lab_opu;
                //txtEmailSubject.Value = "Result LAB OPU HN " + txtHnFeMale.Text + " Name " + txtNameFeMale.Text + " OPU Code " + txtOpuCode.Text + " ";
                txtEmailSubject.Value = "OPU Date " + DateTime.Now.ToString("dd/MM/") + DateTime.Now.Year + " " + txtNameMale.Text + " " + txtNameFeMale.Text ;

                //chkSendEmail.Checked = opu.status_opu.Equals("2") ? true : false;
                chkSendEmail.Checked = true;
                if (chkSendEmail.Checked)
                {
                    pnEmail.Visible = true;
                }
                else
                {
                    pnEmail.Visible = false;
                }
            }
            else if (opureport == opuReport.ResultDay2)
            {
                opu = ic.ivfDB.opuDB.selectByPk1(opuId);
                txtID.Value = opu.opu_id;
                txtHnFeMale.Value = opu.hn_female;
                txtHnMale.Value = opu.hn_male;
                txtNameFeMale.Value = opu.name_female;
                txtNameMale.Value = opu.name_male;
                txtOpuCode.Value = opu.opu_code;
                txtEmailTo.Value = ic.iniC.email_to_lab_opu;
                //txtEmailSubject.Value = "Result LAB OPU HN " + txtHnFeMale.Text + " Name " + txtNameFeMale.Text + " OPU Code " + txtOpuCode.Text + " ";
                txtEmailSubject.Value = "OPU Date " + DateTime.Now.ToString("dd/MM/") + DateTime.Now.Year + " " + txtNameMale.Text + " " + txtNameFeMale.Text;

                //chkSendEmail.Checked = opu.status_opu.Equals("2") ? true : false;
                cboEmbryoDev1.Value = "2";
                cboEmbryoDev2.Value = "2";
                cboEmbryoDev3.Value = "2";
                chkSendEmail.Checked = true;
                if (chkSendEmail.Checked)
                {
                    pnEmail.Visible = true;
                }
                else
                {
                    pnEmail.Visible = false;
                }
            }
            else if (opureport == opuReport.ResultDay6)
            {
                opu = ic.ivfDB.opuDB.selectByPk1(opuId);
                txtID.Value = opu.opu_id;
                txtHnFeMale.Value = opu.hn_female;
                txtHnMale.Value = opu.hn_male;
                txtNameFeMale.Value = opu.name_female;
                txtNameMale.Value = opu.name_male;
                txtOpuCode.Value = opu.opu_code;
                txtEmailTo.Value = ic.iniC.email_to_lab_opu;
                //txtEmailSubject.Value = "Result LAB OPU HN " + txtHnFeMale.Text + " Name " + txtNameFeMale.Text + " OPU Code " + txtOpuCode.Text + " ";
                txtEmailSubject.Value = "OPU Date " + DateTime.Now.ToString("dd/MM/") + DateTime.Now.Year + " " + txtNameMale.Text + " " + txtNameFeMale.Text;

                //chkSendEmail.Checked = opu.status_opu.Equals("2") ? true : false;
                chkSendEmail.Checked = true;
                if (chkSendEmail.Checked)
                {
                    pnEmail.Visible = true;
                }
                else
                {
                    pnEmail.Visible = false;
                }
            }
            else if (opureport == opuReport.ResultDay5)
            {
                opu = ic.ivfDB.opuDB.selectByPk1(opuId);
                txtID.Value = opu.opu_id;
                txtHnFeMale.Value = opu.hn_female;
                txtHnMale.Value = opu.hn_male;
                txtNameFeMale.Value = opu.name_female;
                txtNameMale.Value = opu.name_male;
                txtOpuCode.Value = opu.opu_code;
                txtEmailTo.Value = ic.iniC.email_to_lab_opu;
                //txtEmailSubject.Value = "Result LAB OPU HN " + txtHnFeMale.Text + " Name " + txtNameFeMale.Text + " OPU Code " + txtOpuCode.Text + " ";
                txtEmailSubject.Value = "OPU Date " + DateTime.Now.ToString("dd/MM/") + DateTime.Now.Year + " " + txtNameMale.Text + " " + txtNameFeMale.Text;

                //chkSendEmail.Checked = opu.status_opu.Equals("2") ? true : false;
                chkSendEmail.Checked = true;
                if (chkSendEmail.Checked)
                {
                    pnEmail.Visible = true;
                }
                else
                {
                    pnEmail.Visible = false;
                }
            }
            else if(opureport == opuReport.ResultDay1)
            {
                opu = ic.ivfDB.opuDB.selectByPk1(opuId);
                txtID.Value = opu.opu_id;
                txtHnFeMale.Value = opu.hn_female;
                txtHnMale.Value = opu.hn_male;
                txtNameFeMale.Value = opu.name_female;
                txtNameMale.Value = opu.name_male;
                txtOpuCode.Value = opu.opu_code;
                txtEmailTo.Value = ic.iniC.email_to_lab_opu;
                //txtEmailSubject.Value = "Result LAB OPU HN " + txtHnFeMale.Text + " Name " + txtNameFeMale.Text + " OPU Code " + txtOpuCode.Text + " ";
                txtEmailSubject.Value = "Day1 " + ic.datetoShow(opu.fertili_date) + " " + txtNameMale.Text + " & " + txtNameFeMale.Text;

                //chkSendEmail.Checked = opu.status_opu.Equals("2") ? true : false;
                chkSendEmail.Checked = true;
                if (chkSendEmail.Checked)
                {
                    pnEmail.Visible = true;
                }
                else
                {
                    pnEmail.Visible = false;
                }
                groupBox2.Hide();
                groupBox3.Hide();
                
                pnEmail.Show();
                cboEmbryoDev3.Hide();
                label8.Hide();
            }
            else if (opureport == opuReport.ResultDay0)
            {
                opu = ic.ivfDB.opuDB.selectByPk1(opuId);
                txtID.Value = opu.opu_id;
                txtHnFeMale.Value = opu.hn_female;
                txtHnMale.Value = opu.hn_male;
                txtNameFeMale.Value = opu.name_female;
                txtNameMale.Value = opu.name_male;
                txtOpuCode.Value = opu.opu_code;
                txtEmailTo.Value = ic.iniC.email_to_lab_opu;
                //txtEmailSubject.Value = "Result LAB OPU HN " + txtHnFeMale.Text + " Name " + txtNameFeMale.Text + " OPU Code " + txtOpuCode.Text + " ";
                txtEmailSubject.Value = "Day1 " + ic.datetoShow(opu.fertili_date) + " " + txtNameMale.Text + " & " + txtNameFeMale.Text;

                //chkSendEmail.Checked = opu.status_opu.Equals("2") ? true : false;
                chkSendEmail.Checked = true;
                if (chkSendEmail.Checked)
                {
                    pnEmail.Visible = true;
                }
                else
                {
                    pnEmail.Visible = false;
                }
                groupBox2.Hide();
                groupBox3.Hide();
                
                pnEmail.Show();
                cboEmbryoDev3.Hide();
                label8.Hide();
            }
            
            else
            {
                fet = ic.ivfDB.fetDB.selectByPk1(opuId);
                txtID.Value = fet.fet_id;
                txtHnFeMale.Value = fet.hn_female;
                txtHnMale.Value = fet.hn_male;
                txtNameFeMale.Value = fet.name_female;
                txtNameMale.Value = fet.name_male;
                txtOpuCode.Value = fet.fet_code;
            }
        }
        private void FrmLabOPUPrint_Load(object sender, EventArgs e)
        {

        }
    }
}
