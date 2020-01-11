using C1.Win.C1SuperTooltip;
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
        Color color;
        public enum opuReport {OPUReport, OPUEmbryoDevReport, FETReport, FETEmbryoDevReport };
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
                if (!setEmailOPU(dt, FrmReport.flagEmbryoDev.onecolumn, FrmReport.flagEmbryoDevMore20.More20, filename)) return;
            }
            else if (!chkEmbryoFreez2Col.Checked && chkEmbryoDev20.Checked)
            {
                if (!setEmailOPU(dt, FrmReport.flagEmbryoDev.onecolumn, FrmReport.flagEmbryoDevMore20.Days2, filename)) return;
            }
            setEmailOPUPicEmbryo(dtEmbryo, filenameEmbryo);

            if (!File.Exists(filename))
            {
                lbEmail.Text = "ไม่พบ Attach File";
                return;
            }
            lbEmail.Text = "เริ่มส่ง Email";
            MailMessage mail = new MailMessage();
            
            txtEmailSubject.Value = "Routine LAB Result HN " + txtHnFeMale.Text + " Name " + txtNameFeMale.Text + " OPD Code " + txtOpuCode.Text + " Date " + System.DateTime.Now.ToString("dd/MM/") + System.DateTime.Now.Year;
            
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

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(ic.iniC.email_auth_user_lab_opu, ic.iniC.email_auth_pass_lab_opu);

            SmtpServer.EnableSsl = true;
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
            setExportOPU();
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
            else if (opureport == opuReport.FETEmbryoDevReport)
            {
                //printFETEmbryoDev();
            }
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
                            Image loadedImage = new Bitmap(stream);
                            String[] ext = path_pic.Split('.');
                            var extension = Path.GetExtension(path_pic);
                            var name = Path.GetFileNameWithoutExtension(path_pic); // Get the name only
                            //if (ext.Length > 0)
                            //{
                            String filename = name;
                            String no = "", filename1 = "",st="";
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
                        row["footer11"] = opu.remark_day2;
                        row["footer12"] = opu.remark_day3;
                        row["footer13"] = opu.remark_day5;
                        row["footer14"] = opu.remark_day6;
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
            if(opureport == opuReport.OPUReport || opureport == opuReport.OPUEmbryoDevReport)
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
                txtEmailSubject.Value = "Result LAB OPU " + DateTime.Now.ToString("dd/mm/") + DateTime.Now.Year + "Name " + txtNameMale.Text + " Name " + txtNameFeMale.Text + " OPU Code " + txtOpuCode.Text + " ";

                chkSendEmail.Checked = opu.status_opu.Equals("2") ? true : false;
                if (chkSendEmail.Checked)
                {
                    pnEmail.Visible = true;
                }
                else
                {
                    pnEmail.Visible = false;
                }
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
