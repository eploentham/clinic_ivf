using C1.Win.C1Command;
using C1.Win.C1Document;
using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1SplitContainer;
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
    public partial class FrmNurseOPUView : Form
    {
        IvfControl ic;
        String reqId = "", opuId = "";
        LabRequest lbReq;
        LabOpu opu;

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;
        int colDay2ID = 1, colDay2Num = 2, colDay2Desc = 3, colDay2Desc1 = 4, colDay2Desc2 = 5, colDay2Edit = 6;
        int colDay3ID = 1, colDay3Num = 2, colDay3Desc = 3, colDay3Desc1 = 4, colDay3Desc2 = 5, colDay3Edit = 6;
        int colDay5ID = 1, colDay5Num = 2, colDay5Desc = 3, colDay5Desc1 = 4, colDay5Desc2 = 5, colDay5Edit = 6;
        int colDay6ID = 1, colDay6Num = 2, colDay6Desc = 3, colDay6Desc1 = 4, colDay6Desc2 = 5, colDay6Edit = 6;

        int colDay2ImgId = 1, colDay2ImgPic = 3, colDay2ImgNun = 2, colDay2ImgDesc0 = 4, colDay2PathPic = 5, colDay2ImgDesc1 = 6;

        C1FlexGrid grfDay2, grfDay3, grfDay5, grfDay6, grfDay2Img, grfDay3Img, grfDay5Img, grfDay6Img;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        C1DockingTab tCday3, tCday5, tCday6;
        C1DockingTabPage tabDay3Rpt, tabDay3Embryo, tabDay5Rpt, tabDay5Embryo, tabDay6Rpt, tabDay6Embryo;
        C1SplitterPanel scPnDay3, scTcDay3, scPnDay5, scTcDay5, scPnDay6, scTcDay6;
        C1SplitContainer sCDay3, sCDay5, sCDay6;
        Label lbDay3EmailTo, lbDay3EmailSubject, lbDay3EmailStatus, lbDay5EmailTo, lbDay5EmailSubject, lbDay5EmailStatus, lbDay6EmailTo, lbDay6EmailSubject, lbDay6EmailStatus;
        C1TextBox txtDay3EmailTo, txtDay3EmailSubject, txtDay5EmailTo, txtDay5EmailSubject, txtDay6EmailTo, txtDay6EmailSubject;
        MemoryStream streamDay3 = null, streamEmbryoDay3 = null, streamDay5 = null, streamEmbryoDay5 = null, streamDay6 = null, streamEmbryoDay6 = null;

        Color color;
        Boolean flagDay2Img = false, flagDay3Img = false, flagDay5Img = false, flagDay6Img = false;
        Boolean grf2Focus = false, grf3Focus = false, grf5Focus = false, grf6Focus = false;
        private bool prefixSeen;
        String theme2 = "Office2007Blue";       //Office2016Black       BeigeOne
        String flagEdit = "", body="";
        List<LinkedResource> theEmailImage1 = new List<LinkedResource>();
        SmtpClient SmtpServer;
        public FrmNurseOPUView(IvfControl ic, String reqid, String opuid)
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
            SmtpServer = new SmtpClient("smtp.gmail.com");

            sB1.Text = "";
            bg = txtHnFeMale.BackColor;
            fc = txtHnFeMale.ForeColor;
            ff = txtHnFeMale.Font;

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            
            opu = new LabOpu();
            lbReq = new LabRequest();
            ic.setCboDayEmbryoDev(cboEmbryoDev1, "");
            ic.setCboDayEmbryoDev(cboEmbryoDev2, "");

            btnPrintOpuEmbryoDev.Click += BtnPrintOpuEmbryoDev_Click;
            btnPrint.Click += BtnPrint_Click;
            btnSendEmail.Click += BtnSendEmail_Click;
            btnResult.Click += BtnResult_Click;
            SmtpServer.SendCompleted += SmtpServer_SendCompleted;
            tCResult.SelectedIndexChanged += TCResult_SelectedIndexChanged;

            ic.ivfDB.proceDB.setCboLabProce(cboOpuProce, objdb.LabProcedureDB.StatusLab.OPUProcedure);//cboEmbryoForEtDoctor
            ic.ivfDB.dtrOldDB.setCboDoctor(cboDoctor, "");
            //ic.ivfDB.dtrOldDB.setCboDoctor(cboEmbryoForEtDoctor, "");
            //ic.ivfDB.stfDB.setCboEmbryologist(cboEmbryoForEtEmbryologist, "");
            //ic.ivfDB.stfDB.setCboEmbryologist(cboEmbryologistAppv, "");
            //ic.ivfDB.stfDB.setCboEmbryologist(cboEmbryologistReport, "");
            //ic.ivfDB.stfDB.setCboEmbryologist(cboEmbryologistDay2, "");
            //ic.ivfDB.stfDB.setCboEmbryologist(cboEmbryologistDay3, "");
            //ic.ivfDB.stfDB.setCboEmbryologist(cboEmbryologistDay5, "");
            //ic.ivfDB.stfDB.setCboEmbryologist(cboEmbryologistDay6, "");
            //ic.ivfDB.stfDB.setCboEmbryologist(cboCheckedDay2, "");
            //ic.ivfDB.stfDB.setCboEmbryologist(cboCheckedDay3, "");
            //ic.ivfDB.stfDB.setCboEmbryologist(cboCheckedDay5, "");
            //ic.ivfDB.stfDB.setCboEmbryologist(cboCheckedDay6, "");

            //ic.ivfDB.fdtDB.setCboOPUMethod(cboEmbryoFreezMethod0);
            //ic.ivfDB.fdtDB.setCboOPUMethod(cboEmbryoFreezMethod1);
            //ic.ivfDB.fdtDB.setCboOPUStage(cboEmbryoFreezStage0, "");
            //ic.ivfDB.fdtDB.setCboOPUStage(cboEmbryoFreezStage1, "");
            //ic.ivfDB.fdtDB.setCboOPUFreezeMedia(cboEmbryoFreezMedia0);
            //ic.ivfDB.fdtDB.setCboOPUFreezeMedia(cboEmbryoFreezMedia1);
            //ic.setCboDay(CboEmbryoFreezDay0, "");
            //ic.setCboDay(CboEmbryoFreezDay1, "");
            //ic.ivfDB.opuDB.setCboRemark(cboRemark);
            //ic.ivfDB.opuDB.setCboRemark1(cboRemark1);

            //stt.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.Gold;

            //initGrf();
            setControl();
            //setGrf();
            theme1.SetTheme(tCResult, theme2);
            theme1.SetTheme(groupBox1, theme2);
            foreach (Control ctl in groupBox1.Controls)
            {
                theme1.SetTheme(ctl, theme2);
            }
            theme1.SetTheme(this, theme2);
            theme1.SetTheme(c1SplitContainer1, theme2);
            theme1.SetTheme(c1SplitContainer1, theme2);
            //setTheme();
            char c = '\u00B5';
            label86.Text = c.ToString() + "l";
            btnSendEmail.Enabled = false;
            if (!ic.user.status_module_lab.Equals("1"))
            {
                                

            }
            tCResult.TabPages[0].TabVisible = false;
            tCResult.TabPages[1].TabVisible = false;
            tCResult.TabPages[2].TabVisible = false;
            tCResult.TabPages[3].TabVisible = false;
            tCResult.TabPages[4].TabVisible = false;
            //tCResult.ta
        }

        private void TCResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if(tCResult.SelectedTab == tabDay3)
            {
                if (scPnDay3 == null) return;
                scPnDay3.SizeRatio = 0;
            }
            else if (tCResult.SelectedTab == tabDay5)
            {
                if (scPnDay3 == null) return;
                scPnDay5.SizeRatio = 0;
            }
            if (tCResult.SelectedTab == tabDay6)
            {
                if (scPnDay6 == null) return;
                scPnDay6.SizeRatio = 0;
            }
        }

        private void BtnResult_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //sendHtmlEmail1();
            setPrepareEmail(false);
            btnSendEmail.Enabled = true;
        }

        private void BtnSendEmail_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //setEmail(true);
            //DataTable dtembryo6 = ic.ivfDB.opuEmDevDB.selectByOpuFetId_DayPrint(opu.opu_id, objdb.LabOpuEmbryoDevDB.Day1.Day6);
            //DataTable dtExport = new DataTable();
            //dtExport = ic.ivfDB.setOPUReport(opu.opu_id, "6", "", true);
            //ReportDocument rpt;
            //CrystalReportViewer crv = new CrystalReportViewer();
            //rpt = new ReportDocument();
            //rpt.Load("lab_opu_embryo_dev.rpt");
            //rpt.SetDataSource(dtExport);
            //crv.ReportSource = rpt;

            //crv.Refresh();
            //rpt.Load(Application.StartupPath + "\\lab_opu_embryo_dev.rpt");
            //rd.Load("StudentReg.rpt");

            //crv.ReportSource = rpt;
            //crv.Refresh();
            //if (File.Exists("embryo.pdf"))
            //    File.Delete("embryo.pdf");
            //crv.
            //crv.ExportReport();
            //rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "embryo.pdf");
            //try
            //{
            //    //DiskFileDestinationOptions FileOption = New DiskFileDestinationOptions();
            //    ExportOptions CrExportOptions;
            //    DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
            //    PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
            //    CrDiskFileDestinationOptions.DiskFileName = System.IO.Directory.GetCurrentDirectory() + "\\embryo.pdf";
            //    CrExportOptions = rpt.ExportOptions;
                
            //    CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
            //    CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
            //    CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
            //    CrExportOptions.FormatOptions = CrFormatTypeOptions;
            //    //CrExportOptions.ExportDestinationOptions = FileOption;
            //    //rpt.ExportOptions = CrExportOptions;
            //    rpt.ExportToDisk(ExportFormatType.PortableDocFormat, System.IO.Directory.GetCurrentDirectory() + "\\embryo.pdf");
            //    rpt.Export();
                
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("eploentham@gmail.com");
            mail.To.Add(txtEmailTo.Text);
            mail.Subject = txtEmailSubject.Text;
            //mail.Body = "Test send email";

            mail.IsBodyHtml = true;
            if (File.Exists("opu.pdf"))
            {
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment("opu.pdf");
                mail.Attachments.Add(attachment);
            }
            if (File.Exists("embryo.pdf"))
            {
                System.Net.Mail.Attachment attachment1;
                attachment1 = new System.Net.Mail.Attachment("embryo.pdf");
                mail.Attachments.Add(attachment1);
            }

            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
            mail.AlternateViews.Add(htmlView);
            
            //foreach (LinkedResource linkimg in theEmailImage1)
            //{
            //    htmlView.LinkedResources.Add(linkimg);
            //}

            SmtpServer.Port = int.Parse(ic.iniC.email_port); ;
            SmtpServer.Credentials = new System.Net.NetworkCredential(ic.iniC.email_auth_user, ic.iniC.email_auth_pass);

            SmtpServer.EnableSsl = Boolean.Parse(ic.iniC.email_ssl);
            SmtpServer.Send(mail);
            
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmLabOPUPrint frm = new FrmLabOPUPrint(ic, txtID.Text, FrmLabOPUPrint.opuReport.OPUReport);
            frm.ShowDialog(this);
        }

        private void BtnPrintOpuEmbryoDev_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmLabOPUPrint frm = new FrmLabOPUPrint(ic, txtID.Text, FrmLabOPUPrint.opuReport.OPUEmbryoDevReport);
            frm.ShowDialog(this);
        }
        private void setPrepareEmail(Boolean flagEmail)
        {
            FrmWaiting frmW = new FrmWaiting();
            frmW.Show();
            try
            {
                int i = 0;
                LabOpuEmbryoDev embryo = new LabOpuEmbryoDev();
                String path = System.IO.Directory.GetCurrentDirectory() + "\\pic";
                bool folderExists = Directory.Exists(path);
                if (!folderExists)
                    Directory.CreateDirectory(path);
                System.IO.DirectoryInfo di = new DirectoryInfo(path);
                foreach (FileInfo file in di.GetFiles())
                {
                    file.IsReadOnly = false;
                    file.Delete();
                }

                DataTable dtembryo6 = ic.ivfDB.opuEmDevDB.selectByOpuFetId_DayPrint(opu.opu_id, objdb.LabOpuEmbryoDevDB.Day1.Day6);
                DataTable dtembryo5 = ic.ivfDB.opuEmDevDB.selectByOpuFetId_DayPrint(opu.opu_id, objdb.LabOpuEmbryoDevDB.Day1.Day5);
                DataTable dtembryo3 = ic.ivfDB.opuEmDevDB.selectByOpuFetId_DayPrint(opu.opu_id, objdb.LabOpuEmbryoDevDB.Day1.Day3);
                DataTable dtembryo2 = ic.ivfDB.opuEmDevDB.selectByOpuFetId_DayPrint(opu.opu_id, objdb.LabOpuEmbryoDevDB.Day1.Day2);
                if (dtembryo6.Rows.Count > 0)
                {
                    frmW.pB.Minimum = 1;
                    frmW.pB.Maximum = dtembryo6.Rows.Count;
                    foreach (DataRow row in dtembryo6.Rows)
                    {
                        String path_pic = "", opuCode = "";
                        path_pic = row["no1_pathpic"] != null ? row["no1_pathpic"].ToString() : "";
                        opuCode = row["opu_code"] != null ? row["opu_code"].ToString() : "";
                        if (!path_pic.Equals(""))
                        {
                            MemoryStream stream = ic.ftpC.download(path_pic);
                            if (stream.Length <= 0) continue;
                            Image loadedImage = new Bitmap(stream);
                            Image resizedImage;
                            String[] ext = path_pic.Split('.');
                            var extension = Path.GetExtension(path_pic);
                            var name = Path.GetFileNameWithoutExtension(path_pic); // Get the name only
                                                                                   //if (ext.Length > 0)
                                                                                   //{
                            String filename = name;
                            String no = "", filename1 = "", st = "";
                            no = filename.Substring(filename.Length - 2);
                            no = no.Replace("_", "");
                            filename1 = path + "\\" + "embryo_dev_" + no + extension;
                            if (File.Exists(filename1))
                            {
                                File.Delete(filename1);
                                System.Threading.Thread.Sleep(200);
                            }

                            int newWidth = 280;
                            int originalWidth = loadedImage.Width;
                            resizedImage = loadedImage.GetThumbnailImage(newWidth, (newWidth * loadedImage.Height) / originalWidth, null, IntPtr.Zero);
                            resizedImage.Save(filename1);
                            row["no1_pathpic"] = filename1;
                            //st = row["no1_desc2"].ToString();
                            st = row["no1_desc3"].ToString();
                            row["no1_desc2"] = "st# " + st;
                            row["no1_desc3"] = row["no1_desc4"].ToString();
                            resizedImage.Dispose();
                            loadedImage.Dispose();
                            //}
                        }
                        i++;
                        frmW.pB.Value = i;
                    }
                    //sendHtmlEmail("eploentham@gmail.com", txtEmailTo.Text,  "Ekapop Ploentham", txtEmailSubject.Text, dtembryo6);
                    sendHtmlEmail1("eploentham@gmail.com", txtEmailTo.Text, "Ekapop Ploentham", txtEmailSubject.Text, dtembryo6, "6");
                    //System.IO.DirectoryInfo di1 = new DirectoryInfo(path);
                    //foreach (FileInfo file in di1.GetFiles())
                    //{
                    //    file.Delete();
                    //}
                }

                setReportOPU();
                setReportEmbryo();

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "");
            }
            finally
            {
                frmW.Dispose();
            }
        }
        private void setReportEmbryo()
        {
            //FrmReport frm = new FrmReport(ic);
            DataTable dt = new DataTable();
            FrmWaiting frmW = new FrmWaiting();
            frmW.Show();
            try
            {
                //MessageBox.Show("aaaaa", "");
                int i = 0;
                String day = "";
                day = cboEmbryoDev1.SelectedItem == null ? "" : ((ComboBoxItem)cboEmbryoDev1.SelectedItem).Value;
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
                            row["no1_desc2"] = "st# " + st;
                            row["no1_desc3"] = row["no1_desc4"].ToString();
                            //}
                        }
                        i++;
                        frmW.pB.Value = i;
                    }
                }
                String date1 = "";
                date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.opuDB.opu.opu_date].ToString());
                dt.Rows[0][ic.ivfDB.opuDB.opu.opu_date] = date1.Replace("-", "/");

                String chk = "", printerDefault = "";
                ReportDocument rpt = new ReportDocument();
                try
                {
                    rpt.Load("lab_opu_embryo_dev.rpt");
                    rpt.SetDataSource(dt);
                    rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                    rpt.SetParameterValue("line2", "โทรศัพท์ " + ic.cop.tele);
                    rpt.SetParameterValue("report_name", " Embryo development");
                    //rpt.SetParameterValue("date1", "" + date1);
                    this.cryEmbryo.ReportSource = rpt;
                    this.cryEmbryo.Refresh();

                    if (File.Exists("embryo.pdf"))
                    {
                        File.Delete("embryo.pdf");
                        System.Threading.Thread.Sleep(200);
                    }

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
                    chk = ex.Message.ToString();
                    MessageBox.Show("error " + ex.Message, "");
                }
                //MessageBox.Show("bbbbbb", "");
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "");
            }
            finally
            {
                frmW.Dispose();
            }
            //frm.ShowDialog(this);
        }
        private void setReportOPU()
        {
            DataTable dt = new DataTable();
            dt = ic.ivfDB.setOPUReport(txtID.Text, "6", "6", true);
            String chk = "", printerDefault = "";
            ReportDocument rpt = new ReportDocument();
            try
            {
                //rpt.Load("lab_opu.rpt");
                if (!chkEmbryoFreez2Col.Checked)
                {
                    if (!chkEmbryoDev20.Checked)
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
                    if (!chkEmbryoDev20.Checked)
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
                rpt.SetParameterValue("line2", "Tele " + ic.cop.tele);
                rpt.SetParameterValue("report_name", " Summary of OPU Report");
                //rpt.SetParameterValue("date1", "" + date1);
                this.cryOpu.ReportSource = rpt;
                this.cryOpu.Refresh();

                if (File.Exists("opu.pdf"))
                {
                    File.Delete("opu.pdf");
                    System.Threading.Thread.Sleep(200);
                }

                ExportOptions CrExportOptions;
                DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                CrDiskFileDestinationOptions.DiskFileName = "opu.pdf";
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
                chk = ex.Message.ToString();
                MessageBox.Show("error " + ex.Message, "");
            }
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
            //theme1.SetTheme(c1CommandDock2, theme2);
            theme1.SetTheme(tCResult, theme2);
            theme1.SetTheme(gbDay2, theme2);
            theme1.SetTheme(gbDay3, theme2);
            theme1.SetTheme(gbDay5, theme2);
            theme1.SetTheme(gbDay6, theme2);
            theme1.SetTheme(panel3, theme2);
            theme1.SetTheme(panel4, theme2);
            theme1.SetTheme(panel5, theme2);
            //theme1.SetTheme(panel6, theme2);

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
            //theme1.SetTheme(panel6, theme2);c1SplitContainer1
            theme1.SetTheme(c1SplitContainer1, theme2);
            theme1.SetTheme(c1SplitContainer2, theme2);
            theme1.SetTheme(c1SplitContainer3, theme2);
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
            //foreach (Control ctl in panel6.Controls)
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
            //theme1.SetTheme(grfDay2, theme2);
            //theme1.SetTheme(grfDay3, theme2);
            //theme1.SetTheme(grfDay5, theme2);
            //theme1.SetTheme(grfDay6, theme2);
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
        private void initGrfDay2()
        {
            grfDay2 = new C1FlexGrid();
            grfDay2.Font = fEdit;
            grfDay2.Dock = System.Windows.Forms.DockStyle.Fill;
            grfDay2.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            
            //ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&Upload image", new EventHandler(ContextMenu_grfday2_upload));
            //menuGw.MenuItems.Add("&Save description", new EventHandler(ContextMenu_grfday2_save));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_grfday2_Cancel));
            //grfDay2.ContextMenu = menuGw;
            pn2Grf.Controls.Add(grfDay2);

            theme1.SetTheme(grfDay2, "Office2010Blue");
        }
        private void initGrfDay3()
        {
            grfDay3 = new C1FlexGrid();
            grfDay3.Font = fEdit;
            grfDay3.Dock = System.Windows.Forms.DockStyle.Fill;
            grfDay3.Location = new System.Drawing.Point(0, 0);
                        
            pn3Grf.Controls.Add(grfDay3);

            theme1.SetTheme(grfDay3, "Office2010Silver");
        }
        private void initGrfDay5()
        {
            grfDay5 = new C1FlexGrid();
            grfDay5.Font = fEdit;
            grfDay5.Dock = System.Windows.Forms.DockStyle.Fill;
            grfDay5.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);
            
            pn5Grf.Controls.Add(grfDay5);

            theme1.SetTheme(grfDay5, "Office2010Red");
            //theme1.SetTheme(grfDay6, "Office2016DarkGray");
        }
        private void initGrfDay6()
        {
            grfDay6 = new C1FlexGrid();
            grfDay6.Font = fEdit;
            grfDay6.Dock = System.Windows.Forms.DockStyle.Fill;
            grfDay6.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);
                        
            pn6Grf.Controls.Add(grfDay6);

            theme1.SetTheme(grfDay6, "Office2010Blue");
        }
        private void initGrfDay2Img()
        {
            grfDay2Img = new C1FlexGrid();
            grfDay2Img.Font = fEdit;
            grfDay2Img.Dock = System.Windows.Forms.DockStyle.Fill;
            grfDay2Img.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);
            
            pnGrf2Img.Controls.Add(grfDay2Img);

            theme1.SetTheme(grfDay2Img, "Office2010Blue");
        }
        private void initGrfDay3Img()
        {
            grfDay3Img = new C1FlexGrid();
            grfDay3Img.Font = fEdit;
            grfDay3Img.Dock = System.Windows.Forms.DockStyle.Fill;
            grfDay3Img.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);
            
            pnGrf3Img.Controls.Add(grfDay3Img);

            theme1.SetTheme(grfDay3Img, "Office2010Blue");
        }
        private void initGrfDay5Img()
        {
            grfDay5Img = new C1FlexGrid();
            grfDay5Img.Font = fEdit;
            grfDay5Img.Dock = System.Windows.Forms.DockStyle.Fill;
            grfDay5Img.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);
            
            pnGrf5Img.Controls.Add(grfDay5Img);

            theme1.SetTheme(grfDay5Img, "Office2010Blue");
        }
        private void initGrfDay6Img()
        {
            grfDay6Img = new C1FlexGrid();
            grfDay6Img.Font = fEdit;
            grfDay6Img.Dock = System.Windows.Forms.DockStyle.Fill;
            grfDay6Img.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);
            
            pnGrf6Img.Controls.Add(grfDay6Img);

            theme1.SetTheme(grfDay6Img, "Office2010Blue");
        }
        private void setControl()
        {
            try
            {
                if (!opuId.Equals(""))
                {
                    tabOPU.Hide();
                    tabEmail.Hide();
                    tabImage.Hide();
                    opu = ic.ivfDB.opuDB.selectByPk1(opuId);
                    lbReq = ic.ivfDB.lbReqDB.selectByPk1(opu.req_id);
                    setControl1();
                    setControlDay1();
                    setControlDay3();
                    setControlDay5();
                    setControlDay6();
                    DataTable dt = new DataTable();
                    dt = ic.ivfDB.opuEmDevDB.selectByOpuFetId_Day(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day2);
                    if (dt.Rows.Count > 0)
                    {
                        txtMaturaNoofOpu.Enabled = false;
                    }
                    else
                    {
                        //setControlFirstTime(false);
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
                    //setControlFirstTime(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "");
            }
        }
        private void setControlDay1()
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
            C1PdfDocumentSource pds = new C1PdfDocumentSource();
            MemoryStream stream;
            FtpClient ftpc = new FtpClient(ic.iniC.hostFTP, ic.iniC.userFTP, ic.iniC.passFTP, ic.ftpUsePassive);
            //ftpC.upload(iniC.folderFTP + "/" + opuCode + "/" + filename, pathFile);
            stream = ftpc.download(ic.iniC.folderFTP + "//" + opu.opu_code + "//" + opu.report_day1);
            stream.Seek(0, SeekOrigin.Begin);
            pds.LoadFromStream(stream);
            day1View.Ribbon.Minimized = true;
            //pds.LoadFromFile(filename1);
            day1View.DocumentSource = pds;
            tabDay1.Controls.Add(day1View);
        }
        private void setControlDay3()
        {
            
            int gapY = 50, gapX = 20, gapLine = 0, gapColName = 120;
            Size size = new Size();
            
            C1Button btnEmailSendDay3, btnEmailListDay3;
            
            C1FlexViewer day3View = new C1FlexViewer();
            C1FlexViewer day3Embryo = new C1FlexViewer();
            
            Panel pnEmailDay3 = new Panel();

            tCday3 = new C1DockingTab();
            tabDay3Rpt = new C1DockingTabPage();
            tabDay3Embryo = new C1DockingTabPage();
            scPnDay3 = new C1.Win.C1SplitContainer.C1SplitterPanel();
            scTcDay3 = new C1.Win.C1SplitContainer.C1SplitterPanel();
            sCDay3 = new C1.Win.C1SplitContainer.C1SplitContainer();

            pnEmailDay3.SuspendLayout();
            tCday3.SuspendLayout();
            tabDay3Rpt.SuspendLayout();
            tabDay3Embryo.SuspendLayout();
            day3View.SuspendLayout();
            day3Embryo.SuspendLayout();
            sCDay3.SuspendLayout();
            scTcDay3.SuspendLayout();
            scPnDay3.SuspendLayout();

            lbDay3EmailTo = new Label();
            lbDay3EmailTo.Text = "Email TO :";
            lbDay3EmailTo.Font = fEdit;
            lbDay3EmailTo.Location = new System.Drawing.Point(gapX, 5);
            lbDay3EmailTo.AutoSize = true;
            lbDay3EmailTo.Name = "lbEmailTo";
            txtDay3EmailTo = new C1TextBox();
            txtDay3EmailTo.Font = fEdit;
            txtDay3EmailTo.Name = "txtDay3EmailTo";
            txtDay3EmailTo.Location = new System.Drawing.Point(gapColName, lbDay3EmailTo.Location.Y);
            txtDay3EmailTo.Size = new Size(320, 20);
            txtDay3EmailTo.Value = ic.iniC.email_to_lab_opu;
            gapLine += gapY;
            lbDay3EmailSubject = new Label();
            lbDay3EmailSubject.Text = "Subject :";
            lbDay3EmailSubject.Font = fEdit;
            lbDay3EmailSubject.Location = new System.Drawing.Point(gapX, gapLine);
            lbDay3EmailSubject.AutoSize = true;
            lbDay3EmailSubject.Name = "lbEmailSubject";
            txtDay3EmailSubject = new C1TextBox();
            txtDay3EmailSubject.Font = fEdit;
            txtDay3EmailSubject.Name = "txtDay3EmailSubject";
            txtDay3EmailSubject.Location = new System.Drawing.Point(gapColName, lbDay3EmailSubject.Location.Y);
            txtDay3EmailSubject.Size = new Size(620, 20);

            btnEmailListDay3 = new C1Button();
            btnEmailListDay3.Image = null;
            btnEmailListDay3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnEmailListDay3.Location = new System.Drawing.Point(txtDay3EmailTo.Location.X + txtDay3EmailTo.Width+20, lbDay3EmailTo.Location.Y);
            btnEmailListDay3.Name = "btnEmailListDay3";
            btnEmailListDay3.Size = new System.Drawing.Size(40, 25);
            btnEmailListDay3.TabIndex = 761;
            btnEmailListDay3.Text = "...";
            btnEmailListDay3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            theme1.SetTheme(btnEmailListDay3, "(default)");
            btnEmailListDay3.UseVisualStyleBackColor = true;
            btnEmailListDay3.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;

            btnEmailSendDay3 = new C1Button();
            btnEmailSendDay3.Image = global::clinic_ivf.Properties.Resources.download_database24;
            btnEmailSendDay3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnEmailSendDay3.Location = new System.Drawing.Point(btnEmailListDay3.Location.X + btnEmailListDay3.Width+80, lbDay3EmailTo.Location.Y);
            btnEmailSendDay3.Name = "btnEmailSendDay3";
            btnEmailSendDay3.Size = new System.Drawing.Size(94, 45);
            btnEmailSendDay3.TabIndex = 761;
            btnEmailSendDay3.Text = "Send Email";
            btnEmailSendDay3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            theme1.SetTheme(btnEmailSendDay3, "(default)");
            btnEmailSendDay3.UseVisualStyleBackColor = true;
            btnEmailSendDay3.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            btnEmailSendDay3.Click += BtnEmailSendDay3_Click;

            lbDay3EmailStatus = new Label();
            lbDay3EmailStatus.Text = "...";
            lbDay3EmailStatus.Font = fEdit;
            lbDay3EmailStatus.Location = new System.Drawing.Point(btnEmailSendDay3.Location.X + btnEmailSendDay3.Width +20, btnEmailSendDay3.Location.Y);
            lbDay3EmailStatus.AutoSize = true;
            lbDay3EmailStatus.Name = "lbDay3EmailStatus";

            pnEmailDay3.Dock = DockStyle.Fill;
            pnEmailDay3.Name = "pnEmailDay3";
            pnEmailDay3.Controls.Add(lbDay3EmailTo);
            pnEmailDay3.Controls.Add(txtDay3EmailTo);
            pnEmailDay3.Controls.Add(lbDay3EmailSubject);
            pnEmailDay3.Controls.Add(txtDay3EmailSubject);
            pnEmailDay3.Controls.Add(btnEmailListDay3);
            pnEmailDay3.Controls.Add(btnEmailSendDay3);
            pnEmailDay3.Controls.Add(lbDay3EmailStatus);

            scPnDay3.Collapsible = true;
            scPnDay3.Dock = C1.Win.C1SplitContainer.PanelDockStyle.Bottom;
            scPnDay3.Location = new System.Drawing.Point(0, 21);
            scPnDay3.Name = "scPnDay3";
            scPnDay3.Controls.Add(pnEmailDay3);
            scPnDay3.ClientSize = new Size(20, 80);


            scTcDay3.Collapsible = false;
            scTcDay3.Dock = C1.Win.C1SplitContainer.PanelDockStyle.Top;
            scTcDay3.Location = new System.Drawing.Point(0, 21);
            scTcDay3.Name = "scTcDay3";
            scTcDay3.Controls.Add(tCday3);
            sCDay3.AutoSizeElement = C1.Framework.AutoSizeElement.Both;
            sCDay3.Name = "sCDay3";
            sCDay3.Dock = System.Windows.Forms.DockStyle.Fill;
            sCDay3.Panels.Add(scPnDay3);
            sCDay3.Panels.Add(scTcDay3);

            //pnEmai.BackColor = Color.Red;

            sCDay3.HeaderHeight = 0;
            scTcDay3.SizeRatio = 0;

            tCday3.Dock = System.Windows.Forms.DockStyle.Fill;
            tCday3.HotTrack = true;
            tCday3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            tCday3.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Fit;
            tCday3.TabsShowFocusCues = true;
            tCday3.Alignment = TabAlignment.Top;
            tCday3.SelectedTabBold = true;
            tCday3.Name = "tCday3";
            tabDay3Rpt.Name = "tabDay3Rpt";
            tabDay3Rpt.TabIndex = 0;
            tabDay3Rpt.Text = "Report Day3";
            tabDay3Embryo.Name = "tabDay3Embryo";
            tabDay3Embryo.TabIndex = 0;
            tabDay3Embryo.Text = "Embryo Day3";
            tCday3.Controls.Add(tabDay3Rpt);
            tCday3.Controls.Add(tabDay3Embryo);

            day3View = new C1FlexViewer();
            day3View.AutoScrollMargin = new System.Drawing.Size(0, 0);
            day3View.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            day3View.Dock = System.Windows.Forms.DockStyle.Fill;
            day3View.Location = new System.Drawing.Point(0, 0);
            day3View.Name = "day3View";
            day3View.Size = new System.Drawing.Size(1065, 790);
            day3View.TabIndex = 0;
            day3View.Ribbon.Minimized = true;
            C1PdfDocumentSource pds = new C1PdfDocumentSource();
            //MemoryStream stream;
            FtpClient ftpc = new FtpClient(ic.iniC.hostFTP, ic.iniC.userFTP, ic.iniC.passFTP, ic.ftpUsePassive);
            //ftpC.upload(iniC.folderFTP + "/" + opuCode + "/" + filename, pathFile);
            streamDay3 = ftpc.download(ic.iniC.folderFTP + "//" + opu.opu_code + "//" + opu.report_day3);
            streamDay3.Seek(0, SeekOrigin.Begin);
            pds.LoadFromStream(streamDay3);
            
            day3Embryo = new C1FlexViewer();
            day3Embryo.AutoScrollMargin = new System.Drawing.Size(0, 0);
            day3Embryo.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            day3Embryo.Dock = System.Windows.Forms.DockStyle.Fill;
            day3Embryo.Location = new System.Drawing.Point(0, 0);
            day3Embryo.Name = "day3Embryo";
            day3Embryo.Size = new System.Drawing.Size(1065, 790);
            day3Embryo.TabIndex = 0;
            day3Embryo.Ribbon.Minimized = true;
            C1PdfDocumentSource pdsEmbryo = new C1PdfDocumentSource();
            
            String ext = "", filename = "";
            ext = Path.GetExtension(opu.report_day3);
            filename = Path.GetFileNameWithoutExtension(opu.report_day3);
            streamEmbryoDay3 = ftpc.download(ic.iniC.folderFTP + "//" + opu.opu_code + "//" + filename + "_embryo_day3" + ext);
            streamEmbryoDay3.Seek(0, SeekOrigin.Begin);
            pdsEmbryo.LoadFromStream(streamEmbryoDay3);
            tabDay3Rpt.Controls.Add(day3View);
            tabDay3Embryo.Controls.Add(day3Embryo);

            //pds.LoadFromFile(filename1);
            day3View.ResumeLayout(false);
            day3Embryo.ResumeLayout(false);
            
            tabDay3Rpt.ResumeLayout(false);
            tabDay3Embryo.ResumeLayout(false);
            tCday3.ResumeLayout(false);
            
            scPnDay3.ResumeLayout(false);
            scTcDay3.ResumeLayout(false);
            sCDay3.ResumeLayout(false);
            pnEmailDay3.ResumeLayout(false);

            day3View.PerformLayout();
            day3Embryo.PerformLayout();
            
            tabDay3Rpt.PerformLayout();
            tabDay3Embryo.PerformLayout();
            tCday3.PerformLayout();
            
            scPnDay3.PerformLayout();
            scTcDay3.PerformLayout();
            sCDay3.PerformLayout();
            pnEmailDay3.PerformLayout();

            day3View.DocumentSource = pds;
            day3Embryo.DocumentSource = pdsEmbryo;
            tabDay3.Controls.Add(sCDay3);
        }
        private void BtnEmailSendDay3_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            sendEmail("day3");
        }
        private void sendEmail(String flagDay)
        {
            Label lb = new Label();
            C1TextBox txtsubject = new C1TextBox();
            C1TextBox txtTo = new C1TextBox();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(ic.iniC.email_form_lab_opu);
            if (flagDay.Equals("day3"))
            {
                lb = lbDay3EmailStatus;
                lbDay3EmailStatus.Text = "เริ่มส่ง Email";
                txtsubject = txtDay3EmailTo;
                txtTo = txtDay3EmailTo;
                if (streamDay3 != null)
                {
                    streamDay3.Seek(0, SeekOrigin.Begin);
                    System.Net.Mail.Attachment attachment;
                    System.Net.Mime.ContentType contentType = new System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Application.Pdf);
                    attachment = new System.Net.Mail.Attachment(streamDay3, contentType);
                    attachment.ContentDisposition.FileName = "opu_day3.pdf";
                    mail.Attachments.Add(attachment);
                }
                if (streamEmbryoDay3 != null)
                {
                    streamEmbryoDay3.Seek(0, SeekOrigin.Begin);
                    System.Net.Mail.Attachment attachment;
                    System.Net.Mime.ContentType contentType = new System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Application.Pdf);
                    attachment = new System.Net.Mail.Attachment(streamEmbryoDay3, contentType);
                    attachment.ContentDisposition.FileName = "opu_day3_embryo.pdf";
                    mail.Attachments.Add(attachment);
                }
            }
            else if (flagDay.Equals("day5"))
            {
                lb = lbDay5EmailStatus;
                lbDay5EmailStatus.Text = "เริ่มส่ง Email";
                Application.DoEvents();
                mail.To.Add(txtDay5EmailTo.Text);
                mail.Subject = lbDay5EmailSubject.Text;
                if (streamDay5 != null)
                {
                    streamDay5.Seek(0, SeekOrigin.Begin);
                    System.Net.Mail.Attachment attachment;
                    System.Net.Mime.ContentType contentType = new System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Application.Pdf);
                    attachment = new System.Net.Mail.Attachment(streamDay5, contentType);
                    attachment.ContentDisposition.FileName = "opu_day5.pdf";
                    mail.Attachments.Add(attachment);
                }
                if (streamEmbryoDay5 != null)
                {
                    streamEmbryoDay5.Seek(0, SeekOrigin.Begin);
                    System.Net.Mail.Attachment attachment;
                    System.Net.Mime.ContentType contentType = new System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Application.Pdf);
                    attachment = new System.Net.Mail.Attachment(streamEmbryoDay5, contentType);
                    attachment.ContentDisposition.FileName = "opu_day5_embryo.pdf";
                    mail.Attachments.Add(attachment);
                }
            }
            else if (flagDay.Equals("day6"))
            {
                lb = lbDay6EmailStatus;
                lbDay6EmailStatus.Text = "เริ่มส่ง Email";
                Application.DoEvents();
                mail.To.Add(txtDay6EmailTo.Text);
                mail.Subject = lbDay6EmailSubject.Text;
                if (streamDay6 != null)
                {
                    streamDay6.Seek(0, SeekOrigin.Begin);
                    System.Net.Mail.Attachment attachment;
                    System.Net.Mime.ContentType contentType = new System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Application.Pdf);
                    attachment = new System.Net.Mail.Attachment(streamDay6, contentType);
                    attachment.ContentDisposition.FileName = "opu_day6.pdf";
                    mail.Attachments.Add(attachment);
                }
                if (streamEmbryoDay6 != null)
                {
                    streamEmbryoDay6.Seek(0, SeekOrigin.Begin);
                    System.Net.Mail.Attachment attachment;
                    System.Net.Mime.ContentType contentType = new System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Application.Pdf);
                    attachment = new System.Net.Mail.Attachment(streamEmbryoDay6, contentType);
                    attachment.ContentDisposition.FileName = "opu_day6_embryo.pdf";
                    mail.Attachments.Add(attachment);
                }
            }
            Application.DoEvents();
            mail.To.Add(txtDay3EmailTo.Text);
            mail.Subject = lbDay3EmailSubject.Text;
            
            Application.DoEvents();
                        
            mail.Body = "";

            mail.IsBodyHtml = true;
            
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString("", null, "text/html");
            mail.AlternateViews.Add(htmlView);

            //foreach (LinkedResource linkimg in theEmailImage1)
            //{
            //    htmlView.LinkedResources.Add(linkimg);
            //}

            SmtpServer.Port = int.Parse(ic.iniC.email_port);
            SmtpServer.Credentials = new System.Net.NetworkCredential(ic.iniC.email_auth_user, ic.iniC.email_auth_pass);
            //SmtpServer.UseDefaultCredentials = true;
            SmtpServer.EnableSsl = Boolean.Parse(ic.iniC.email_ssl);
            SmtpServer.Send(mail);
            
            lb.Text = "ส่ง Email เรียบร้อย";
            Application.DoEvents();
        }
        private void setControlDay5()
        {
            int gapY = 50, gapX = 20, gapLine = 0, gapColName = 120;
            Size size = new Size();

            C1Button btnEmailSendDay5, btnEmailListDay5;

            C1FlexViewer day5View = new C1FlexViewer();
            C1FlexViewer day5Embryo = new C1FlexViewer();

            Panel pnEmailDay5 = new Panel();

            tCday5 = new C1DockingTab();
            tabDay5Rpt = new C1DockingTabPage();
            tabDay5Embryo = new C1DockingTabPage();
            scPnDay5 = new C1.Win.C1SplitContainer.C1SplitterPanel();
            scTcDay5 = new C1.Win.C1SplitContainer.C1SplitterPanel();
            sCDay5 = new C1.Win.C1SplitContainer.C1SplitContainer();

            pnEmailDay5.SuspendLayout();
            tCday5.SuspendLayout();
            tabDay5Rpt.SuspendLayout();
            tabDay5Embryo.SuspendLayout();
            day5View.SuspendLayout();
            day5Embryo.SuspendLayout();
            sCDay5.SuspendLayout();
            scTcDay5.SuspendLayout();
            scPnDay5.SuspendLayout();

            lbDay5EmailTo = new Label();
            lbDay5EmailTo.Text = "Email TO :";
            lbDay5EmailTo.Font = fEdit;
            lbDay5EmailTo.Location = new System.Drawing.Point(gapX, 5);
            lbDay5EmailTo.AutoSize = true;
            lbDay5EmailTo.Name = "lbEmailTo";
            txtDay5EmailTo = new C1TextBox();
            txtDay5EmailTo.Font = fEdit;
            txtDay5EmailTo.Name = "txtEmailTo";
            txtDay5EmailTo.Location = new System.Drawing.Point(gapColName, lbDay5EmailTo.Location.Y);
            txtDay5EmailTo.Size = new Size(320, 20);
            txtDay5EmailTo.Value = ic.iniC.email_to_lab_opu;
            gapLine += gapY;
            lbDay5EmailSubject = new Label();
            lbDay5EmailSubject.Text = "Subject :";
            lbDay5EmailSubject.Font = fEdit;
            lbDay5EmailSubject.Location = new System.Drawing.Point(gapX, gapLine);
            lbDay5EmailSubject.AutoSize = true;
            lbDay5EmailSubject.Name = "lbDay5EmailSubject";
            txtDay5EmailSubject = new C1TextBox();
            txtDay5EmailSubject.Font = fEdit;
            txtDay5EmailSubject.Name = "txttxtDay5EmailSubjectEmailSubject";
            txtDay5EmailSubject.Location = new System.Drawing.Point(gapColName, lbDay5EmailSubject.Location.Y);
            txtDay5EmailSubject.Size = new Size(620, 20);

            btnEmailListDay5 = new C1Button();
            btnEmailListDay5.Image = null;
            btnEmailListDay5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnEmailListDay5.Location = new System.Drawing.Point(txtDay3EmailTo.Location.X + txtDay3EmailTo.Width + 20, lbDay3EmailTo.Location.Y);
            btnEmailListDay5.Name = "btnEmailListDay5";
            btnEmailListDay5.Size = new System.Drawing.Size(40, 25);
            btnEmailListDay5.TabIndex = 761;
            btnEmailListDay5.Text = "...";
            btnEmailListDay5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            theme1.SetTheme(btnEmailListDay5, "(default)");
            btnEmailListDay5.UseVisualStyleBackColor = true;
            btnEmailListDay5.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;

            btnEmailSendDay5 = new C1Button();
            btnEmailSendDay5.Image = global::clinic_ivf.Properties.Resources.download_database24;
            btnEmailSendDay5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnEmailSendDay5.Location = new System.Drawing.Point(btnEmailListDay5.Location.X + btnEmailListDay5.Width + 80, lbDay3EmailTo.Location.Y);
            btnEmailSendDay5.Name = "btnEmailSendDay5";
            btnEmailSendDay5.Size = new System.Drawing.Size(94, 45);
            btnEmailSendDay5.TabIndex = 761;
            btnEmailSendDay5.Text = "Send Email";
            btnEmailSendDay5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            theme1.SetTheme(btnEmailSendDay5, "(default)");
            btnEmailSendDay5.UseVisualStyleBackColor = true;
            btnEmailSendDay5.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            btnEmailSendDay5.Click += BtnEmailSendDay5_Click;

            lbDay5EmailStatus = new Label();
            lbDay5EmailStatus.Text = "...";
            lbDay5EmailStatus.Font = fEdit;
            lbDay5EmailStatus.Location = new System.Drawing.Point(btnEmailSendDay5.Location.X + btnEmailSendDay5.Width + 20, btnEmailSendDay5.Location.Y);
            lbDay5EmailStatus.AutoSize = true;
            lbDay5EmailStatus.Name = "lbDay5EmailStatus";

            pnEmailDay5.Dock = DockStyle.Fill;
            pnEmailDay5.Name = "pnEmai";
            pnEmailDay5.Controls.Add(lbDay5EmailTo);
            pnEmailDay5.Controls.Add(txtDay5EmailTo);
            pnEmailDay5.Controls.Add(lbDay5EmailSubject);
            pnEmailDay5.Controls.Add(txtDay5EmailSubject);
            pnEmailDay5.Controls.Add(btnEmailListDay5);
            pnEmailDay5.Controls.Add(btnEmailSendDay5);
            pnEmailDay5.Controls.Add(lbDay5EmailStatus);

            scPnDay5.Collapsible = true;
            scPnDay5.Dock = C1.Win.C1SplitContainer.PanelDockStyle.Bottom;
            scPnDay5.Location = new System.Drawing.Point(0, 21);
            scPnDay5.Name = "scPnDay5";
            scPnDay5.Controls.Add(pnEmailDay5);
            scPnDay5.ClientSize = new Size(20, 80);


            scTcDay5.Collapsible = false;
            scTcDay5.Dock = C1.Win.C1SplitContainer.PanelDockStyle.Top;
            scTcDay5.Location = new System.Drawing.Point(0, 21);
            scTcDay5.Name = "scTcDay5";
            scTcDay5.Controls.Add(tCday5);
            sCDay5.AutoSizeElement = C1.Framework.AutoSizeElement.Both;
            sCDay5.Name = "sCDay5";
            sCDay5.Dock = System.Windows.Forms.DockStyle.Fill;
            sCDay5.Panels.Add(scPnDay5);
            sCDay5.Panels.Add(scTcDay5);

            //pnEmai.BackColor = Color.Red;

            sCDay5.HeaderHeight = 0;
            scTcDay5.SizeRatio = 0;

            tCday5.Dock = System.Windows.Forms.DockStyle.Fill;
            tCday5.HotTrack = true;
            tCday5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            tCday5.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Fit;
            tCday5.TabsShowFocusCues = true;
            tCday5.Alignment = TabAlignment.Top;
            tCday5.SelectedTabBold = true;
            tCday5.Name = "tCday5";
            tabDay5Rpt.Name = "tabDay5Rpt";
            tabDay5Rpt.TabIndex = 0;
            tabDay5Rpt.Text = "Report Day5";
            tabDay5Embryo.Name = "tabDay5Embryo";
            tabDay5Embryo.TabIndex = 0;
            tabDay5Embryo.Text = "Embryo Day5";
            tCday5.Controls.Add(tabDay5Rpt);
            tCday5.Controls.Add(tabDay5Embryo);

            day5View = new C1FlexViewer();
            day5View.AutoScrollMargin = new System.Drawing.Size(0, 0);
            day5View.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            day5View.Dock = System.Windows.Forms.DockStyle.Fill;
            day5View.Location = new System.Drawing.Point(0, 0);
            day5View.Name = "day5View";
            day5View.Size = new System.Drawing.Size(1065, 790);
            day5View.TabIndex = 0;
            day5View.Ribbon.Minimized = true;
            C1PdfDocumentSource pds = new C1PdfDocumentSource();
            //MemoryStream stream;
            FtpClient ftpc = new FtpClient(ic.iniC.hostFTP, ic.iniC.userFTP, ic.iniC.passFTP, ic.ftpUsePassive);
            //ftpC.upload(iniC.folderFTP + "/" + opuCode + "/" + filename, pathFile);
            streamDay5 = ftpc.download(ic.iniC.folderFTP + "//" + opu.opu_code + "//" + opu.report_day5);
            streamDay5.Seek(0, SeekOrigin.Begin);
            pds.LoadFromStream(streamDay5);

            day5Embryo = new C1FlexViewer();
            day5Embryo.AutoScrollMargin = new System.Drawing.Size(0, 0);
            day5Embryo.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            day5Embryo.Dock = System.Windows.Forms.DockStyle.Fill;
            day5Embryo.Location = new System.Drawing.Point(0, 0);
            day5Embryo.Name = "day5Embryo";
            day5Embryo.Size = new System.Drawing.Size(1065, 790);
            day5Embryo.TabIndex = 0;
            day5Embryo.Ribbon.Minimized = true;
            C1PdfDocumentSource pdsEmbryo = new C1PdfDocumentSource();

            String ext = "", filename = "";
            ext = Path.GetExtension(opu.report_day5);
            filename = Path.GetFileNameWithoutExtension(opu.report_day5);
            streamEmbryoDay5 = ftpc.download(ic.iniC.folderFTP + "//" + opu.opu_code + "//" + filename + "_embryo_day5" + ext);
            streamEmbryoDay5.Seek(0, SeekOrigin.Begin);
            pdsEmbryo.LoadFromStream(streamEmbryoDay5);
            tabDay5Rpt.Controls.Add(day5View);
            tabDay5Embryo.Controls.Add(day5Embryo);

            //pds.LoadFromFile(filename1);
            day5View.ResumeLayout(false);
            day5Embryo.ResumeLayout(false);

            tabDay5Rpt.ResumeLayout(false);
            tabDay5Embryo.ResumeLayout(false);
            tCday5.ResumeLayout(false);

            scPnDay5.ResumeLayout(false);
            scTcDay5.ResumeLayout(false);
            sCDay5.ResumeLayout(false);
            pnEmailDay5.ResumeLayout(false);

            day5View.PerformLayout();
            day5Embryo.PerformLayout();

            tabDay5Rpt.PerformLayout();
            tabDay5Embryo.PerformLayout();
            tCday5.PerformLayout();

            scPnDay5.PerformLayout();
            scTcDay5.PerformLayout();
            sCDay5.PerformLayout();
            pnEmailDay5.PerformLayout();

            day5View.DocumentSource = pds;
            day5Embryo.DocumentSource = pdsEmbryo;
            tabDay5.Controls.Add(sCDay5);
        }
        private void BtnEmailSendDay5_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            sendEmail("day5");
        }
        private void setControlDay6()
        {
            int gapY = 50, gapX = 20, gapLine = 0, gapColName = 120;
            Size size = new Size();

            C1Button btnEmailSendDay6, btnEmailListDay6;

            C1FlexViewer day6View = new C1FlexViewer();
            C1FlexViewer day6Embryo = new C1FlexViewer();

            Panel pnEmailDay6 = new Panel();

            tCday6 = new C1DockingTab();
            tabDay6Rpt = new C1DockingTabPage();
            tabDay6Embryo = new C1DockingTabPage();
            scPnDay6 = new C1.Win.C1SplitContainer.C1SplitterPanel();
            scTcDay6 = new C1.Win.C1SplitContainer.C1SplitterPanel();
            sCDay6 = new C1.Win.C1SplitContainer.C1SplitContainer();

            pnEmailDay6.SuspendLayout();
            tCday6.SuspendLayout();
            tabDay6Rpt.SuspendLayout();
            tabDay6Embryo.SuspendLayout();
            day6View.SuspendLayout();
            day6Embryo.SuspendLayout();
            sCDay6.SuspendLayout();
            scTcDay6.SuspendLayout();
            scPnDay6.SuspendLayout();

            lbDay6EmailTo = new Label();
            lbDay6EmailTo.Text = "Email TO :";
            lbDay6EmailTo.Font = fEdit;
            lbDay6EmailTo.Location = new System.Drawing.Point(gapX, 5);
            lbDay6EmailTo.AutoSize = true;
            lbDay6EmailTo.Name = "lbDay6EmailTo";
            txtDay6EmailTo = new C1TextBox();
            txtDay6EmailTo.Font = fEdit;
            txtDay6EmailTo.Name = "txtDay6EmailTo";
            txtDay6EmailTo.Location = new System.Drawing.Point(gapColName, lbDay6EmailTo.Location.Y);
            txtDay6EmailTo.Size = new Size(320, 20);
            txtDay6EmailTo.Value = ic.iniC.email_to_lab_opu;
            gapLine += gapY;
            lbDay6EmailSubject = new Label();
            lbDay6EmailSubject.Text = "Subject :";
            lbDay6EmailSubject.Font = fEdit;
            lbDay6EmailSubject.Location = new System.Drawing.Point(gapX, gapLine);
            lbDay6EmailSubject.AutoSize = true;
            lbDay6EmailSubject.Name = "lbDay6EmailSubject";
            txtDay6EmailSubject = new C1TextBox();
            txtDay6EmailSubject.Font = fEdit;
            txtDay6EmailSubject.Name = "txtDay6EmailSubject";
            txtDay6EmailSubject.Location = new System.Drawing.Point(gapColName, lbDay6EmailSubject.Location.Y);
            txtDay6EmailSubject.Size = new Size(620, 20);

            btnEmailListDay6 = new C1Button();
            btnEmailListDay6.Image = null;
            btnEmailListDay6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnEmailListDay6.Location = new System.Drawing.Point(txtDay6EmailTo.Location.X + txtDay6EmailTo.Width + 20, lbDay6EmailTo.Location.Y);
            btnEmailListDay6.Name = "btnEmailListDay6";
            btnEmailListDay6.Size = new System.Drawing.Size(40, 25);
            btnEmailListDay6.TabIndex = 761;
            btnEmailListDay6.Text = "...";
            btnEmailListDay6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            theme1.SetTheme(btnEmailListDay6, "(default)");
            btnEmailListDay6.UseVisualStyleBackColor = true;
            btnEmailListDay6.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;

            btnEmailSendDay6 = new C1Button();
            btnEmailSendDay6.Image = global::clinic_ivf.Properties.Resources.download_database24;
            btnEmailSendDay6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnEmailSendDay6.Location = new System.Drawing.Point(btnEmailListDay6.Location.X + btnEmailListDay6.Width + 80, lbDay3EmailTo.Location.Y);
            btnEmailSendDay6.Name = "btnEmailSendDay6";
            btnEmailSendDay6.Size = new System.Drawing.Size(94, 45);
            btnEmailSendDay6.TabIndex = 761;
            btnEmailSendDay6.Text = "Send Email";
            btnEmailSendDay6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            theme1.SetTheme(btnEmailSendDay6, "(default)");
            btnEmailSendDay6.UseVisualStyleBackColor = true;
            btnEmailSendDay6.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            btnEmailSendDay6.Click += BtnEmailSendDay6_Click;

            lbDay6EmailStatus = new Label();
            lbDay6EmailStatus.Text = "...";
            lbDay6EmailStatus.Font = fEdit;
            lbDay6EmailStatus.Location = new System.Drawing.Point(btnEmailSendDay6.Location.X + btnEmailSendDay6.Width + 20, btnEmailSendDay6.Location.Y);
            lbDay6EmailStatus.AutoSize = true;
            lbDay6EmailStatus.Name = "lbDay6EmailStatus";

            pnEmailDay6.Dock = DockStyle.Fill;
            pnEmailDay6.Name = "pnEmailDay6";
            pnEmailDay6.Controls.Add(lbDay6EmailTo);
            pnEmailDay6.Controls.Add(txtDay6EmailTo);
            pnEmailDay6.Controls.Add(lbDay6EmailSubject);
            pnEmailDay6.Controls.Add(txtDay6EmailSubject);
            pnEmailDay6.Controls.Add(btnEmailListDay6);
            pnEmailDay6.Controls.Add(btnEmailSendDay6);
            pnEmailDay6.Controls.Add(lbDay6EmailStatus);

            scPnDay6.Collapsible = true;
            scPnDay6.Dock = C1.Win.C1SplitContainer.PanelDockStyle.Bottom;
            scPnDay6.Location = new System.Drawing.Point(0, 21);
            scPnDay6.Name = "scPnDay6";
            scPnDay6.Controls.Add(pnEmailDay6);
            scPnDay6.ClientSize = new Size(20, 80);


            scTcDay6.Collapsible = false;
            scTcDay6.Dock = C1.Win.C1SplitContainer.PanelDockStyle.Top;
            scTcDay6.Location = new System.Drawing.Point(0, 21);
            scTcDay6.Name = "scTcDay6";
            scTcDay6.Controls.Add(tCday6);
            sCDay6.AutoSizeElement = C1.Framework.AutoSizeElement.Both;
            sCDay6.Name = "sCDay6";
            sCDay6.Dock = System.Windows.Forms.DockStyle.Fill;
            sCDay6.Panels.Add(scPnDay6);
            sCDay6.Panels.Add(scTcDay6);

            //pnEmai.BackColor = Color.Red;

            sCDay6.HeaderHeight = 0;
            scTcDay6.SizeRatio = 0;

            tCday6.Dock = System.Windows.Forms.DockStyle.Fill;
            tCday6.HotTrack = true;
            tCday6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            tCday6.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Fit;
            tCday6.TabsShowFocusCues = true;
            tCday6.Alignment = TabAlignment.Top;
            tCday6.SelectedTabBold = true;
            tCday6.Name = "tCday6";
            tabDay6Rpt.Name = "tabDay6Rpt";
            tabDay6Rpt.TabIndex = 0;
            tabDay6Rpt.Text = "Report Day6";
            tabDay6Embryo.Name = "tabDay6Embryo";
            tabDay6Embryo.TabIndex = 0;
            tabDay6Embryo.Text = "Embryo Day6";
            tCday6.Controls.Add(tabDay6Rpt);
            tCday6.Controls.Add(tabDay6Embryo);

            day6View = new C1FlexViewer();
            day6View.AutoScrollMargin = new System.Drawing.Size(0, 0);
            day6View.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            day6View.Dock = System.Windows.Forms.DockStyle.Fill;
            day6View.Location = new System.Drawing.Point(0, 0);
            day6View.Name = "day3View";
            day6View.Size = new System.Drawing.Size(1065, 790);
            day6View.TabIndex = 0;
            day6View.Ribbon.Minimized = true;
            C1PdfDocumentSource pds = new C1PdfDocumentSource();
            //MemoryStream stream;
            FtpClient ftpc = new FtpClient(ic.iniC.hostFTP, ic.iniC.userFTP, ic.iniC.passFTP, ic.ftpUsePassive);
            //ftpC.upload(iniC.folderFTP + "/" + opuCode + "/" + filename, pathFile);
            streamDay6 = ftpc.download(ic.iniC.folderFTP + "//" + opu.opu_code + "//" + opu.report_day6);
            streamDay6.Seek(0, SeekOrigin.Begin);
            pds.LoadFromStream(streamDay6);

            day6Embryo = new C1FlexViewer();
            day6Embryo.AutoScrollMargin = new System.Drawing.Size(0, 0);
            day6Embryo.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            day6Embryo.Dock = System.Windows.Forms.DockStyle.Fill;
            day6Embryo.Location = new System.Drawing.Point(0, 0);
            day6Embryo.Name = "day6Embryo";
            day6Embryo.Size = new System.Drawing.Size(1065, 790);
            day6Embryo.TabIndex = 0;
            day6Embryo.Ribbon.Minimized = true;
            C1PdfDocumentSource pdsEmbryo = new C1PdfDocumentSource();

            String ext = "", filename = "";
            ext = Path.GetExtension(opu.report_day3);
            filename = Path.GetFileNameWithoutExtension(opu.report_day6);
            streamEmbryoDay6 = ftpc.download(ic.iniC.folderFTP + "//" + opu.opu_code + "//" + filename + "_embryo_day6" + ext);
            streamEmbryoDay6.Seek(0, SeekOrigin.Begin);
            pdsEmbryo.LoadFromStream(streamEmbryoDay6);
            tabDay6Rpt.Controls.Add(day6View);
            tabDay6Embryo.Controls.Add(day6Embryo);

            //pds.LoadFromFile(filename1);
            day6View.ResumeLayout(false);
            day6Embryo.ResumeLayout(false);

            tabDay6Rpt.ResumeLayout(false);
            tabDay6Embryo.ResumeLayout(false);
            tCday6.ResumeLayout(false);

            scPnDay6.ResumeLayout(false);
            scTcDay6.ResumeLayout(false);
            sCDay6.ResumeLayout(false);
            pnEmailDay6.ResumeLayout(false);

            day6View.PerformLayout();
            day6Embryo.PerformLayout();

            tabDay6Rpt.PerformLayout();
            tabDay6Embryo.PerformLayout();
            tCday6.PerformLayout();

            scPnDay6.PerformLayout();
            scTcDay6.PerformLayout();
            sCDay6.PerformLayout();
            pnEmailDay6.PerformLayout();

            day6View.DocumentSource = pds;
            day6Embryo.DocumentSource = pdsEmbryo;
            tabDay6.Controls.Add(sCDay6);
            //tabDay6.Controls.Add(tC1);
        }
        private void BtnEmailSendDay6_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            sendEmail("day6");
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
            grfDay2.Cols[colDay2Edit].Visible = false;
            ic.setC1Combo(cboEmbryologistDay2, staffId);
            ic.setC1Combo(cboCheckedDay2, checkId);
            txtDay2Date.Value = dateday2;
            grfDay2.AutoClipboard = true;
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
            ic.setC1Combo(cboEmbryologistDay3, staffId);
            ic.setC1Combo(cboCheckedDay3, checkId);
            txtDay3Date.Value = dateday;
            grfDay3.AutoClipboard = true;
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
            grfDay5.Cols[colDay5Desc1].Width = 70;
            grfDay5.Cols[colDay5Desc2].Width = 70;

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
            ic.setC1Combo(cboEmbryologistDay5, staffId);
            ic.setC1Combo(cboCheckedDay5, checkId);
            txtDay5Date.Value = dateday;
            grfDay5.AutoClipboard = true;
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
            ic.setC1Combo(cboEmbryologistDay6, staffId);
            ic.setC1Combo(cboCheckedDay6, checkId);
            txtDay6Date.Value = dateday;
            grfDay6.AutoClipboard = true;
        }
        private void setGrfDay2Img()
        {
            grfDay2Img.Clear();
            grfDay2Img.DataSource = null;
            grfDay2Img.Rows.Count = 1;
            grfDay2Img.Cols.Count = 7;
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
            grfDay2Img.Cols[colDay2ImgDesc1].Caption = "Desc2";

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
            theme1.SetTheme(grfDay2Img, "Office2016Colorful");
            grfDay2Img.Refresh();
        }
        private void setGrfDay3Img()
        {
            grfDay3Img.Clear();
            grfDay3Img.DataSource = null;
            grfDay3Img.Rows.Count = 1;
            grfDay3Img.Cols.Count = 7;
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
            grfDay3Img.Cols[colDay2ImgDesc1].Caption = "Desc2";

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
            theme1.SetTheme(grfDay3Img, "Office2016Colorful");
            grfDay3Img.Refresh();
        }
        private void setGrfDay5Img()
        {
            grfDay5Img.Clear();
            grfDay5Img.DataSource = null;
            grfDay5Img.Rows.Count = 1;
            grfDay5Img.Cols.Count = 7;
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
            grfDay5Img.Cols[colDay2ImgDesc1].Caption = "Desc2";

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
                row1[colDay2ImgDesc1] = row[ic.ivfDB.opuEmDevDB.opuEmDev.desc4].ToString();

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
            theme1.SetTheme(grfDay5Img, "Office2016Colorful");
            grfDay5Img.Refresh();
        }
        private void setGrfDay6Img()
        {
            grfDay6Img.Clear();
            grfDay6Img.DataSource = null;
            grfDay6Img.Rows.Count = 1;
            grfDay6Img.Cols.Count = 7;
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
            grfDay6Img.Cols[colDay2ImgDesc1].Caption = "Desc2";

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
                row1[colDay2ImgDesc1] = row[ic.ivfDB.opuEmDevDB.opuEmDev.desc4].ToString();

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
            theme1.SetTheme(grfDay6Img, "Office2016Colorful");
            grfDay6Img.Refresh();
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
                String[] ext = opu.matura_no_of_opu.Split(',');
                int rt = 0, lt = 0;
                int.TryParse(ext[0], out rt);
                int.TryParse(ext[1], out lt);

                //txtMaturaNoofOpu1.Value = rt + lt;
            }
            catch (Exception ex)
            {

            }

            //txtMaturaDate.Value = opu.matura_date;
            //txtMaturaMii.Value = opu.matura_m_ii;
            //txtMaturaMi.Value = opu.matura_m_i;
            //txtMaturaGv.Value = opu.matura_gv;
            //txtMaturaPostMat.Value = opu.matura_post_mat;
            //txtMaturaAbnor.Value = opu.matura_abmormal;
            //txtMaturaDead.Value = opu.matura_dead;

            //txtFertiliDate.Value = opu.fertili_date;
            //txtFertili2Pn.Value = opu.fertili_2_pn;
            //txtFertili1Pn.Value = opu.fertili_1_pn;
            //txtFertili3Pn.Value = opu.fertili_3_pn;
            //txtFertili4Pn.Value = opu.fertili_4_pn;
            //txtFertiliNoPn.Value = opu.fertili_no_pn;
            //txtFertiliDead.Value = opu.fertili_dead;

            //txtSpermDate.Value = opu.sperm_date;
            //txtSpermVol.Value = opu.sperm_volume;
            //txtSpermCnt.Value = opu.sperm_count;
            //txtSpermTotalCnt.Value = opu.sperm_count_total;
            //txtSpermMoti.Value = opu.sperm_motile;
            //txtSpermMotiTotal.Value = opu.sperm_motile_total;
            //txtSpermMotility.Value = opu.sperm_motility;
            //chkSpermFresh.Value = opu.sperm_fresh_sperm.Equals("1") ? true : false;
            //chkSpermFrozen.Value = opu.sperm_frozen_sperm.Equals("1") ? true : false;
            //txtEmbryoForEtNO.Value = opu.embryo_for_et_no_of_et;
            //txtEmbryoForEtDay.Value = opu.embryo_for_et_day;
            //txtEmbryoForEtDate.Value = ic.datetoShow(opu.embryo_for_et_date);
            //txtEmbryoForEtAsseted.Value = opu.embryo_for_et_assisted;
            //txtEmbryoForEtVolume.Value = opu.embryo_for_et_volume;
            //txtEmbryoForEtCatheter.Value = opu.embryo_for_et_catheter;
            ////txtEmbryoForEtDoctor.Value = opu.embryo_for_et_doctor;
            //txtEmbryoForEtNumTran.Value = opu.embryo_for_et_number_of_transfer;
            //txtEmbryoForEtNumFreeze.Value = opu.embryo_for_et_number_of_freeze;
            //txtEmbryoForEtNumDiscard.Value = opu.embryo_for_et_number_of_discard;
            ////cboEmbryoForEtEmbryologist.Value = opu.embryo_for_et_embryologist_id;
            ////cboEmbryologistReport.Value = opu.embryologist_report_id;
            ////cboEmbryologistAppv.Value = opu.embryologist_approve_id;
            //ic.setC1Combo(cboEmbryologistAppv, opu.embryologist_approve_id);
            //ic.setC1Combo(cboEmbryologistReport, opu.embryologist_report_id);
            //ic.setC1Combo(cboEmbryoForEtEmbryologist, opu.embryo_for_et_embryologist_id);
            //ic.setC1Combo(CboEmbryoFreezDay0, opu.embryo_freez_day_0);
            //ic.setC1Combo(CboEmbryoFreezDay1, opu.embryo_freez_day_1);
            //txtEmbryoFreezDate0.Value = opu.embryo_freez_date_0;
            //txtEmbryoFreezDate1.Value = opu.embryo_freez_date_1;
            ////txtEmbryoFreezStage0.Value = opu.embryo_freez_stage_0;
            //ic.setC1Combo(cboEmbryoFreezStage0, opu.embryo_freez_stage_0);
            ////txtEmbryoFreezStage1.Value = opu.embryo_freez_stage_1;
            //ic.setC1Combo(cboEmbryoFreezStage1, opu.embryo_freez_stage_1);
            //txtEmbryoFreezNoOg0.Value = opu.embryo_freez_no_og_0;
            //txtEmbryoFreezNoOg1.Value = opu.embryo_freez_no_og_1;
            //txtEmbryoFreezNoStraw0.Value = opu.embryo_freez_no_of_straw_0;
            //txtEmbryoFreezNoStraw1.Value = opu.embryo_freez_no_of_straw_1;
            //txtEmbryoFreezPosi0.Value = opu.embryo_freez_position_0;
            //txtEmbryoFreezPosi1.Value = opu.embryo_freez_position_1;
            ////txtEmbryoFreezMethod0.Value = opu.embryo_freez_mothod_0;
            ////txtEmbryoFreezMethod1.Value = opu.embryo_freez_mothod_1;
            //ic.setC1Combo(cboEmbryoFreezMethod1, opu.embryo_freez_mothod_1);
            //ic.setC1Combo(cboEmbryoFreezMethod0, opu.embryo_freez_mothod_0);
            //ic.setC1Combo(cboEmbryoFreezMedia0, opu.embryo_freez_freeze_media_0);
            //ic.setC1Combo(cboEmbryoFreezMedia1, opu.embryo_freez_freeze_media_1);
            ////txtEmbryoFreezMedia0.Value = opu.embryo_freez_freeze_media_0;
            ////txtEmbryoFreezMedia1.Value = opu.embryo_freez_freeze_media_1;

            ////txtRemark.Value = opu.remark;
            //ic.setC1ComboByName(cboRemark, opu.remark);
            //ic.setC1ComboByName(cboRemark1, opu.remark_1);
            //txtDatePicEmbryo.Value = opu.date_pic_embryo;
            ////CboEmbryoDay.Text = opu.emb
            //if (opu.status_opu.Equals("2"))
            //{                
            //    String appr = "";
            //    appr = ic.ivfDB.stfDB.getStaffNameBylStf(opu.approve_result_staff_id);
            //    txtApproveResult.Value = appr;
            //}
            //else
            //{

            //}
            txtOpuTime.Value = opu.opu_time;
        }
        private void sendHtmlEmail1(string from_Email, string to_Email, string from_Name, string Subject, DataTable dt, String day)
        {
            try
            {
                int imgrow = 0, imgcol=0;
                String tdimg = "", tdimg1 = "", tr="<tr>",tr1="</tr>";
                String path = System.IO.Directory.GetCurrentDirectory() + "\\pic";
                bool folderExists = Directory.Exists(path);
                
                if (folderExists)
                {
                    System.IO.DirectoryInfo di = new DirectoryInfo(path);
                    foreach (FileInfo file in di.GetFiles())
                    {
                        LinkedResource theEmailImage2 = new LinkedResource(file.FullName);
                        theEmailImage2.ContentId = "img_" + imgrow.ToString();
                        theEmailImage1.Add(theEmailImage2);
                        String desc0 = "", desc1 = "", desc2 = "", st = "", desc4 = "";
                        foreach (DataRow row in dt.Rows)
                        {
                            if (file.FullName.Equals(row["no1_pathpic"].ToString()))
                            {
                                desc0 = row["no1_desc0"] != null ? row["no1_desc0"].ToString() : "";
                                desc1 = row["no1_desc1"] != null ? row["no1_desc1"].ToString() : "";
                                desc2 = row["no1_desc2"] != null ? row["no1_desc2"].ToString() : "";
                                st = row["no1_desc3"] != null ? row["no1_desc3"].ToString() : "";
                                desc4 = row["no1_desc4"] != null ? row["no1_desc4"].ToString() : "";
                                break;
                            }
                        }
                        if (imgcol == 0)
                        {
                            tr = "<tr>";
                            tr1 = "";
                        }
                        else if (imgcol == 3)
                        {
                            tr = "";
                            tr1 = "</tr>";
                            imgcol = 0;
                        }
                        else
                        {
                            tr = "";
                            tr1 = "";
                            if (imgrow == dt.Rows.Count)
                            {
                                tr1 = "</tr>";
                            }
                        }
                        tdimg += tr+"<td style='' font-style:arial; color:maroon; font-weight:bold''>" +
                            "<table><tr><td>" + (imgrow + 1) + "</td></tr>" +
                            "<tr><td>" + desc0 + "</td></tr>" +
                            "<tr><td>" + desc1 + "</td></tr>" +
                            "<tr> <td><img src=cid:img_" + imgrow.ToString() + "></td></tr>" +
                            "<tr><td>" + st + "</td></tr>" +
                            "</table></td>"+ tr1;
                        tdimg1 += tr + "<td style='' font-style:arial; color:maroon; font-weight:bold''>" +
                            "<table><tr><td>" + (imgrow + 1) + "</td></tr>" +
                            "<tr><td>" + desc0 + "</td></tr>" +
                            "<tr><td>" + desc1 + "</td></tr>" +
                            "<tr> <td><img src='" + file.FullName + "'></td></tr>" +
                            "<tr><td>" + st + "</td></tr>" +
                            "</table></td>" + tr1;
                        //tdimg += "<td style='' font-style:arial; color:maroon; font-weight:bold''> <img src=cid:img_" + imgrow.ToString() + "></td>";
                        imgrow++;
                        imgcol++;
                        //file.IsReadOnly = true;
                    }
                }
                //body = "<html><body><p>Embryo development Day " + day + "111</p> </br>" +
                //    "<table width='100%'><tr>" + tdimg + "</tr></table> </body> </html>";
                //String body1 = "<html><body><p>Embryo development Day " + day + "111</p> </br>" +
                //    "<table width='100%'><tr>" + tdimg1 + "</tr></table> </body> </html>";
                String pageHeader = "", header="", procedure="", doctor="", opudate="", hn_female="", hn_male="", name_female="", name_male="", matura="", ferti="",sperm="", freezing0="", freezing1="", opu1="";
                String spermfrezing = "", et="", emreport="", etapprove="", report="", approve="", css="", txtbody="";
                css = "<style> " +
                    "p.dotted { border - style: dotted; } " +
                    "p.dashed { border - style: dashed; } " +
                    "p.solid { border - style: solid; } " +
                    "p.double { border - style: double; } " +
                    "p.groove { border - style: groove; } " +
                    "p.ridge { border - style: ridge; } " +
                    "p.inset { border - style: inset; } " +
                    "p.outset { border - style: outset; } " +
                    "p.none { border - style: none; } " +
                    "p.hidden { border - style: hidden; } " +
                    "p.mix { border - style: dotted dashed solid double; } " +
                    "td.dashed { border - style: dashed; } " +
                    "td.groove_left { border - style: none none none groove; } " +
                    "td.groove_right { border - style: none groove none none; } " +
                    "td.groove_top { border - style: groove none none none; } " +
                    "td.groove_botton { border - style: none none groove none; } " +
                    "td.groove_left_top { border - style: groove none none groove; } " +
                    "td.groove_right_top { border - style: groove groove none none; } " +
                    "td.groove_left_botton { border - style: none none groove groove; } " +
                    "td.groove_right_botton { border - style: none groove groove none; } " +
                    "</ style > ";
                procedure = dt.Rows[0]["procedure1"].ToString();
                doctor = dt.Rows[0]["doctor"].ToString();
                opudate = dt.Rows[0]["opu_date"].ToString();
                hn_female = dt.Rows[0]["hn_female"].ToString();
                hn_male = dt.Rows[0]["hn_male"].ToString();
                name_female = dt.Rows[0]["name_female"].ToString();
                name_male = dt.Rows[0]["name_male"].ToString();
                matura = "<table>" +
                    "<tr><td colspan='2'>Maturation</td></tr>" +
                    "<tr><td>No of OPU :</td><td>" +opu.matura_no_of_opu+"</td></tr>" +
                    "<tr><td>Date time :</td><td>" + opu.matura_no_of_opu + "</td></tr>" +
                    "<tr><td>M II :</td><td>" + opu.matura_m_ii + "</td></tr>" +
                    "<tr><td>M I :</td><td>" + opu.matura_m_i + "</td></tr>" +
                    "<tr><td>GV :</td><td>" + opu.matura_gv + "</td></tr>" +
                    "<tr><td>Post mature :</td><td>" + opu.matura_post_mat + "</td></tr>" +
                    "<tr><td>Abnormal :</td><td>" + opu.matura_abmormal + "</td></tr>" +
                    "<tr><td>Dead :</td><td>" + opu.matura_dead + "</td></tr>" +
                    "</table>";
                ferti = "<table>" +
                    "<tr><td colspan='2'>Fertilization</td></tr>" +
                    "<tr><td>Date time :</td><td>" + opu.fertili_date + "</td></tr>" +
                    "<tr><td>2 PN :</td><td>" + opu.fertili_2_pn + "</td></tr>" +
                    "<tr><td>1 PN :</td><td>" + opu.fertili_1_pn + "</td></tr>" +
                    "<tr><td>3 PN :</td><td>" + opu.fertili_3_pn + "</td></tr>" +
                    "<tr><td>4 PN :</td><td>" + opu.fertili_4_pn + "</td></tr>" +
                    "<tr><td>No PN :</td><td>" + opu.fertili_no_pn + "</td></tr>" +
                    "<tr><td>Dead :</td><td>" + opu.fertili_dead + "</td></tr>" +
                    "<tr><td></td><td></td></tr>" +
                    "</table>";
                if (opu.sperm_frozen_sperm.Equals("1"))
                {
                    spermfrezing = "Frozen sperm";
                }
                else if (opu.sperm_fresh_sperm.Equals("1"))
                {
                    spermfrezing = "Fresh sperm";
                }
                else
                {
                    spermfrezing = "-";
                }
                sperm = "<table width='100%'>" +
                    "<tr><td colspan='2'>Sperm preparation</td></tr>" +
                    "<tr><td>Date time :</td><td>" + opu.sperm_date + "</td></tr>" +
                    "<tr><td>Volume :</td><td>" + opu.sperm_volume + "</td></tr>" +
                    "<tr><td>Count :</td><td>" + opu.sperm_count + "</td></tr>" +
                    "<tr><td>Total count :</td><td>" + opu.sperm_count_total + "</td></tr>" +
                    "<tr><td>Motile :</td><td>" + opu.sperm_motile + "</td></tr>" +
                    "<tr><td>Total Motile :</td><td>" + opu.sperm_motile_total + "</td></tr>" +
                    "<tr><td>Motility :</td><td>" + opu.sperm_motility + "</td></tr>" +
                    "<tr><td></td><td>" + spermfrezing + "</td></tr>" +
                    "</table>";
                etapprove = ic.ivfDB.stfDB.getStaffNameBylStf(opu.embryo_for_et_embryologist_id);
                emreport = ic.ivfDB.stfDB.getStaffNameBylStf(opu.embryologist_approve_id);
                report = ic.ivfDB.stfDB.getStaffNameBylStf(opu.embryologist_report_id);
                approve = ic.ivfDB.stfDB.getStaffNameBylStf(opu.embryologist_approve_id);
                et = "<table width='100%'>" +
                    "<tr><td colspan='6'>Embryo for ET</td></tr>" +
                    "<tr><td>No. of ET :</td><td>" + opu.embryo_for_et_no_of_et + "</td><td>ET Volume :</td><td>" + opu.embryo_for_et_volume + "</td><td>Number of Tranfer :</td><td>" + opu.embryo_for_et_number_of_transfer + "</td></tr>" +
                    "<tr><td>Day :</td><td>" + opu.embryo_for_et_day + "</td><td>ET Catheter :</td><td>" + opu.embryo_for_et_catheter + "</td><td>Number of Freeze :</td><td>" + opu.embryo_for_et_number_of_freeze + "</td></tr>" +
                    "<tr><td>Date time :</td><td>" + opu.embryo_for_et_date + "</td><td>ET Doctor :</td><td>" + opu.embryo_for_et_doctor + "</td><td>Number Discard :</td><td>" + opu.embryo_for_et_number_of_discard + "</td></tr>" +
                    "<tr><td>Assisted Hatching :</td><td>" + opu.embryo_for_et_assisted + "</td><td>ET Embryologist :</td><td>" + etapprove + "</td><td></td><td></td></tr>" +
                    "<tr><td>Remark :</td><td>" + opu.embryo_for_et_remark + "</td></tr>" +
                    "<tr><td>Embryologist report :</td><td>" + report + "</td><td>Embryologist approve :</td><td>" + approve + "</td></tr>" +
                    "</table>";

                txtbody = "<p align='left'>" + txtEmailBody.Text.Replace("\r\n","<br>") + "</br></p> </br>";
                opu1 = "<table width='100%'><tr><td>" + matura+"</td><td>"+ ferti + "</td><td>" + sperm + "</td></tr></table>";
                pageHeader = "<p align='center'>Embryo development Day " + day + "</p> </br>";
                header = "<table>" +
                    "<tr><td class='groove_left_top'>Name Female :</td><td>" + name_female + "</td><td>Hn :</td><td class='groove_right_top'>" + hn_female + "</td></tr>" +
                    "<tr><td class='groove_left'>Name Male :</td><td>" + name_male + "</td><td>Hn :</td><td class='groove_groove_rightleft'>" + hn_male + "</td></tr>" +
                    "<tr><td class='groove_left'>Doctor :</td><td>" + doctor + "</td><td></td><td class='groove_right'></td></tr>" +
                    "<tr><td class='groove_left_botton'>Procedure :</td><td>" + procedure + "</td><td>Date time :</td><td class='groove_right_botton'>" + opudate + "</td></tr>" +
                    "</table>";
                body = "<html><body>"+ pageHeader+ txtbody + header + opu1 +
                    "<table width='100%'><tr><td></td><td></td><td></td><td></td></tr>" + tdimg + "</table> " + et +
                    "</body> </html>";
                String body1 = "<html><body>"+ pageHeader + header + opu1 +
                   "<table width='100%'>" + tdimg1 + "</table> " + et+
                   "</body> </html>";
                c1SuperLabel1.Text = body1;                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void SmtpServer_SendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //throw new NotImplementedException();
            MessageBox.Show("mail send");
        }

        protected void sendHtmlEmail(string from_Email, string to_Email, string from_Name, string Subject, DataTable dt)
        {
            //create an instance of new mail message
            int imgrow = 0;
            String tdimg = "";
            String path = System.IO.Directory.GetCurrentDirectory() + "\\pic";
            bool folderExists = Directory.Exists(path);
            List<LinkedResource> theEmailImage1 = new List<LinkedResource>();
            if (folderExists)
            {
                System.IO.DirectoryInfo di = new DirectoryInfo(path);
                foreach (FileInfo file in di.GetFiles())
                {
                    LinkedResource theEmailImage2 = new LinkedResource(file.FullName);
                    theEmailImage2.ContentId = "img_"+ imgrow.ToString();
                    theEmailImage1.Add(theEmailImage2);
                    String desc0 = "", desc1 = "", desc2 = "", desc3 = "", desc4="";
                    foreach(DataRow row in dt.Rows)
                    {
                        if (file.Name.Equals(row["path_pic"].ToString()))
                        {
                            desc0 = row["no1_desc0"] != null ? row["no1_desc0"].ToString() : "";
                            desc1 = row["no1_desc1"] != null ? row["no1_desc1"].ToString() : "";
                            desc2 = row["no1_desc2"] != null ? row["no1_desc2"].ToString() : "";
                            desc3 = row["no1_desc3"] != null ? row["no1_desc3"].ToString() : "";
                            desc4 = row["no1_desc4"] != null ? row["no1_desc4"].ToString() : "";
                        }
                    }
                    tdimg += "<td style='' font-style:arial; color:maroon; font-weight:bold''>" +
                        "<table><tr><td>"+(imgrow+1) +"</td></tr>" +
                        "<tr><td>" + desc0 + "</td></tr>" +
                        "<tr><td>" + desc1 + "</td></tr>" +
                        "<tr> <img src=cid:img_" + imgrow.ToString() + "></tr>" +
                        "<tr><td>" + desc3 + "</td></tr>" +
                        "</table></td>";
                    imgrow++;
                }
            }
            string body = @"<html>
                                  <body>
                                    <table width='100%'>
                                    <tr>
                                        "+ tdimg + " </tr></table> </body> </html>";
            MailMessage mail = new MailMessage();

            //set the HTML format to true
            mail.IsBodyHtml = true;
            body = "<html><body> <table width='100%'><tr><td>Embryo development Day 6</td></tr></table> </body> </html>";
            //create Alrternative HTML view
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");

            //Add Image
            //LinkedResource theEmailImage = new LinkedResource("E:\\IMG_3332.jpg");
            //theEmailImage.ContentId = "myImageID";

            //Add the Image to the Alternate view
            //htmlView.LinkedResources.Add(theEmailImage);
            //foreach(LinkedResource linkimg in theEmailImage1)
            //{
            //    htmlView.LinkedResources.Add(linkimg);
            //}

            //Add view to the Email Message
            mail.AlternateViews.Add(htmlView);

            //set the "from email" address and specify a friendly 'from' name
            mail.From = new MailAddress(from_Email, from_Name);

            //set the "to" email address
            mail.To.Add(to_Email);

            //set the Email subject
            mail.Subject = Subject;

            //set the SMTP info
            System.Net.NetworkCredential cred = new System.Net.NetworkCredential("eploentham@gmail.com", "Singcamma1*");
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 465);
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = true;
            
            smtp.Credentials = cred;
            smtp.Port = 465;
            
            //send the email
            smtp.Send(mail);
        }
        private void FrmNurseOPUView_Load(object sender, EventArgs e)
        {
            c1SplitContainer1.HeaderHeight = 0;
            c1SplitContainer2.HeaderHeight = 0;
            c1SplitContainer3.HeaderHeight = 0;
            tCResult.SelectedTab = tabDay0;
        }
    }
}
