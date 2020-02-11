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
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.gui
{
    public partial class FrmLabBloodAdd : Form
    {
        IvfControl ic;

        String resId = "", body = "";
        LabRequest lbReq;
        LabResult lbRes;
        Patient ptt;
        Visit vs;

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;
        Color color;
        int colRsId = 1, colRsLabName = 2, colRsMethod = 3, colRsResult = 4, colRsInterpret = 5, colRsReactive=6, colRsUnit = 7, colRsNormal = 8, colRsRemark = 9, colRsLabId = 10, colRsReqId = 11, colRsEdit = 12, colRsLotInput = 13, colRsRemarkNurse=14;

        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        C1FlexGrid grfProc;

        String theme2 = "Office2007Blue";
        public String StatusSperm = "";
        SmtpClient SmtpServer;
        List<LinkedResource> theEmailImage1 = new List<LinkedResource>();
        Boolean flagView = false;
        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetDefaultPrinter(string Printer);
        public FrmLabBloodAdd(IvfControl ic, String resid)
        {
            InitializeComponent();
            this.ic = ic;
            resId = resid;

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
            btnApproveResult.Click += BtnApproveResult_Click;
            btnPrintHormone.Click += BtnPrintHormone_Click;
            btnSendEmail.Click += BtnSendEmailHormone_Click;
            btnPrintInfectious.Click += BtnPrintInfectious_Click;
            btnAgentEmail.Click += BtnAgentEmail_Click;
            btnSendEmailInfectious.Click += BtnSendEmailInfectious_Click;

            sB1.Text = "";
            bg = txtHn.BackColor;
            fc = txtHn.ForeColor;
            ff = txtHn.Font;

            ic.ivfDB.stfDB.setCboEmbryologist(cboEmbryologistAppv, "");
            ic.ivfDB.stfDB.setCboEmbryologist(cboEmbryologistReport, "");
            ic.ivfDB.stfDB.setCboDoctor(cboDoctor, "");

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            lbRes = new LabResult();
            lbReq = new LabRequest();
            ptt = new Patient();
            vs = new Visit();
            lbEmail.Text = "";
            initGrfProc();
            setControl();
        }

        private void BtnSendEmailInfectious_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            lbEmail.Text = "เตรียม Email";
            FrmWaiting frmW = new FrmWaiting();
            frmW.Show();
            String filename = "", datetick = "";
            if (!Directory.Exists("report"))
            {
                Directory.CreateDirectory("report");
            }
            datetick = DateTime.Now.Ticks.ToString();
            filename = "report\\lab_blood_" + datetick + ".pdf";
            lbEmail.Text = "เตรียม Report";
            if (!setReportLabBloodInfectious(filename))
            {
                return;
            }
            frmW.Dispose();
            lbEmail.Text = "เริ่มส่ง Email";
            MailMessage mail = new MailMessage();
            txtEmailSubject.Value = "Routine LAB Result HN " + txtHn.Text + " Name " + txtPttNameE.Text + " [VN " + txtVnShow.Text + "] Infectious Report Date " + System.DateTime.Now.ToString("dd/MM/") + System.DateTime.Now.Year;
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
            lbEmail.Text = "ส่ง Email เรียบร้อย";
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

        private void BtnPrintInfectious_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            SetDefaultPrinter(ic.iniC.printerA4);
            FrmReport frm = new FrmReport(ic);
            DataTable dt = new DataTable();
            dt = ic.ivfDB.lbresDB.selectLabBloodByVsIdInfectious(txtVsId.Text);
            dt.Columns.Add("patient_name", typeof(String));
            dt.Columns.Add("patient_hn", typeof(String));
            dt.Columns.Add("patient_dob", typeof(String));
            dt.Columns.Add("patient_sex", typeof(String));
            dt.Columns.Add("line1", typeof(String));
            dt.Columns.Add("line2", typeof(String));
            dt.Columns.Add("line3", typeof(String));
            dt.Columns.Add("sign_reporter", typeof(String));
            dt.Columns.Add("sign_approved", typeof(String));
            String date1 = "", collectdate = "", receivedate = "", reporter = "", approved = "", reportername = "", approvedname = "";
            Staff stf = new Staff();
            reporter = ic.ivfDB.stfDB.getIdByNameSurname(cboEmbryologistReport.Text);
            approved = ic.ivfDB.stfDB.getIdByNameSurname(cboEmbryologistAppv.Text);
            stf = ic.ivfDB.stfDB.selectByPk1(reporter);
            reportername = stf.prefix_name_t + " " + stf.staff_fname_e + " " + stf.staff_lname_e + " " + stf.doctor_id;
            stf = ic.ivfDB.stfDB.selectByPk1(approved);
            approvedname = stf.prefix_name_t + " " + stf.staff_fname_e + " " + stf.staff_lname_e + " " + stf.doctor_id;
            foreach (DataRow row in dt.Rows)
            {
                collectdate = row[ic.ivfDB.lbresDB.lbRes.req_date_time].ToString();
                receivedate = row[ic.ivfDB.lbresDB.lbRes.date_time_receive].ToString();
                row["patient_hn"] = txtHn.Text;
                row["patient_name"] = txtPttNameE.Text.ToUpper();
                row["patient_dob"] = txtDob.Text;
                row["patient_sex"] = txtSex.Text;
                row["sign_reporter"] = System.IO.Directory.GetCurrentDirectory() + "\\" + reporter + ".jpg";
                row["sign_approved"] = System.IO.Directory.GetCurrentDirectory() + "\\" + approved + ".jpg";
                if (ptt.f_sex_id.Equals("2") && (!ptt.patient_hn_1.Equals("") && !ptt.patient_hn_2.Equals("")))     // เป็น female และ เป็น donor  ไม่ต้องพิมพ์ หัว บริษัท
                {
                    row["line1"] = "";
                    row["line2"] = "";
                    row["line3"] = "";
                }
                else
                {
                    row["line1"] = ic.cop.comp_name_t;
                    row["line2"] = ic.cop.addr1;
                    row["line3"] = ic.cop.addr2;
                }
            }
            frm.setLabBloodReportInfectious(dt, txtHn.Text, txtPttNameE.Text, txtDob.Text, txtSex.Text, reportername, approvedname, txtReportDate.Text, txtApprovDate.Text, ic.datetimetoShow(collectdate), ic.datetimetoShow(receivedate));
            frm.ShowDialog(this);
        }
        private Boolean setReportLabBloodInfectious(String filename)
        {
            Boolean chk1 = true;
            DataTable dt = new DataTable();
            dt = ic.ivfDB.lbresDB.selectLabBloodByVsIdInfectious(txtVsId.Text);
            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("ไม่พบข้อมูล", "");
                return false;
            }
            dt.Columns.Add("patient_name", typeof(String));
            dt.Columns.Add("patient_hn", typeof(String));
            dt.Columns.Add("patient_dob", typeof(String));
            dt.Columns.Add("patient_sex", typeof(String));
            dt.Columns.Add("line1", typeof(String));
            dt.Columns.Add("line2", typeof(String));
            dt.Columns.Add("line3", typeof(String));
            dt.Columns.Add("sign_reporter", typeof(String));
            dt.Columns.Add("sign_approved", typeof(String));
            String chk = "", printerDefault = "";
            String amh = "", collectdate = "", receivedate = "", reporter = "", approved = "", reportername = "", approvedname = "";
            Staff stf = new Staff();
            //lbRes = ic.ivfDB.lbresDB.selectByPk(resId);
            reporter = ic.ivfDB.stfDB.getIdByNameSurname(cboEmbryologistReport.Text);
            approved = ic.ivfDB.stfDB.getIdByNameSurname(cboEmbryologistAppv.Text);
            stf = ic.ivfDB.stfDB.selectByPk1(reporter);
            reportername = stf.prefix_name_t + " " + stf.staff_fname_e + " " + stf.staff_lname_e+" "+ stf.doctor_id;
            stf = ic.ivfDB.stfDB.selectByPk1(approved);
            approvedname = stf.prefix_name_t + " " + stf.staff_fname_e + " " + stf.staff_lname_e + " " + stf.doctor_id;
            foreach (DataRow row in dt.Rows)
            {
                collectdate = row[ic.ivfDB.lbresDB.lbRes.req_date_time].ToString();
                receivedate = row[ic.ivfDB.lbresDB.lbRes.date_time_receive].ToString();
                if (row["LID"].ToString().Equals("10"))
                {
                    amh = "1";
                }
                else
                {
                    //amh = "0";
                }
                row["patient_hn"] = txtHn.Text;
                row["patient_name"] = txtPttNameE.Text.ToUpper();
                row["patient_dob"] = txtDob.Text;
                row["patient_sex"] = txtSex.Text;
                row["sign_reporter"] = System.IO.Directory.GetCurrentDirectory() + "\\" + reporter + ".jpg";
                row["sign_approved"] = System.IO.Directory.GetCurrentDirectory() + "\\" + approved + ".jpg";
                if (ptt.f_sex_id.Equals("2") && (!ptt.patient_hn_1.Equals("") && !ptt.patient_hn_2.Equals("")))     // เป็น female และ เป็น donor  ไม่ต้องพิมพ์ หัว บริษัท
                {
                    row["line1"] = "";
                    row["line2"] = "";
                    row["line3"] = "";
                }
                else
                {
                    row["line1"] = ic.cop.comp_name_t;
                    row["line2"] = ic.cop.addr1;
                    row["line3"] = ic.cop.addr2;
                }
            }
            ReportDocument rpt = new ReportDocument();
            try
            {
                lbEmail.Text = "สร้าง Report";
                String date1 = dt.Rows[0]["date_time_result"].ToString();
                String date2 = dt.Rows[0]["date_time_approve"].ToString();
                date1 = ic.datetimetoShow(dt.Rows[0]["date_time_result"]);
                date2 = ic.datetimetoShow(dt.Rows[0]["date_time_approve"]);
                dt.Rows[0]["date_time_result"] = date1;
                dt.Rows[0]["date_time_approve"] = date2;
                
                rpt.Load("lab_blood_form2.rpt");
                //rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                //rpt.SetParameterValue("line2", ic.cop.addr1);
                //rpt.SetParameterValue("line3", ic.cop.addr2);
                
                rpt.SetDataSource(dt);
                //rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                //rpt.SetParameterValue("line2", ic.cop.addr1);
                //rpt.SetParameterValue("line3", ic.cop.addr2);
                //rpt.SetParameterValue("hn", txtHn.Text);
                //rpt.SetParameterValue("name", txtPttNameE.Text);
                //rpt.SetParameterValue("dob", txtDob.Text);
                //rpt.SetParameterValue("sex", txtSex.Text);
                rpt.SetParameterValue("report_by", reportername);
                rpt.SetParameterValue("approve_by", approvedname);
                rpt.SetParameterValue("report_date", txtReportDate.Text);
                rpt.SetParameterValue("approve_date", txtApprovDate.Text);
                rpt.SetParameterValue("collect_date", ic.datetimetoShow(collectdate));
                rpt.SetParameterValue("receive_date", ic.datetimetoShow(receivedate));
                //rpt.SetParameterValue("report_name", " Summary of OPU Report");
                //rpt.SetParameterValue("date1", "" + date1);
                this.cryLab.ReportSource = rpt;
                this.cryLab.Refresh();
                lbEmail.Text = "สร้าง Report เรียบร้อย";
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
                lbEmail.Text = "Export Report";
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
        private Boolean setReportLabBloodHormone(String filename)
        {
            Boolean chk1 = true;
            DataTable dt = new DataTable();
            dt = ic.ivfDB.lbresDB.selectLabBloodByVsIdHormone(txtVsId.Text);
            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("ไม่พบข้อมูล", "");
                return false;
            }
            dt.Columns.Add("patient_name", typeof(String));
            dt.Columns.Add("patient_hn", typeof(String));
            dt.Columns.Add("patient_dob", typeof(String));
            dt.Columns.Add("patient_sex", typeof(String));
            dt.Columns.Add("line1", typeof(String));
            dt.Columns.Add("line2", typeof(String));
            dt.Columns.Add("line3", typeof(String));
            dt.Columns.Add("sign_reporter", typeof(String));
            dt.Columns.Add("sign_approved", typeof(String));
            String chk = "", printerDefault = "";
            String amh = "", collectdate = "", receivedate = "", reporter = "", approved = "", reportername = "", approvedname = "";
            Staff stf = new Staff();
            //lbRes = ic.ivfDB.lbresDB.selectByPk(resId);
            reporter = ic.ivfDB.stfDB.getIdByNameSurname(cboEmbryologistReport.Text);
            approved = ic.ivfDB.stfDB.getIdByNameSurname(cboEmbryologistAppv.Text);
            stf = ic.ivfDB.stfDB.selectByPk1(reporter);
            reportername = stf.prefix_name_t + " " + stf.staff_fname_e + " " + stf.staff_lname_e + " " + stf.doctor_id;
            stf = ic.ivfDB.stfDB.selectByPk1(approved);
            approvedname = stf.prefix_name_t + " " + stf.staff_fname_e + " " + stf.staff_lname_e + " " + stf.doctor_id;
            foreach (DataRow row in dt.Rows)
            {
                collectdate = row[ic.ivfDB.lbresDB.lbRes.req_date_time].ToString();
                receivedate = row[ic.ivfDB.lbresDB.lbRes.date_time_receive].ToString();
                if (row["LID"].ToString().Equals("10"))
                {
                    amh = "1";
                }
                else
                {
                    //amh = "0";
                }
                row["patient_hn"] = txtHn.Text;
                row["patient_name"] = txtPttNameE.Text.ToUpper();
                row["patient_dob"] = txtDob.Text;
                row["patient_sex"] = txtSex.Text;
                row["sign_reporter"] = System.IO.Directory.GetCurrentDirectory() + "\\" + reporter + ".jpg";
                row["sign_approved"] = System.IO.Directory.GetCurrentDirectory() + "\\" + approved + ".jpg";
                if (ptt.f_sex_id.Equals("2") && (!ptt.patient_hn_1.Equals("") && !ptt.patient_hn_2.Equals("")))     // เป็น female และ เป็น donor  ไม่ต้องพิมพ์ หัว บริษัท
                {
                    row["line1"] = "";
                    row["line2"] = "";
                    row["line3"] = "";
                }
                else
                {
                    row["line1"] = ic.cop.comp_name_t;
                    row["line2"] = ic.cop.addr1;
                    row["line3"] = ic.cop.addr2;
                }
            }
            ReportDocument rpt = new ReportDocument();
            try
            {
                lbEmail.Text = "สร้าง Report";
                String date1 = dt.Rows[0]["date_time_result"].ToString();
                String date2 = dt.Rows[0]["date_time_approve"].ToString();
                date1 = ic.datetimetoShow(dt.Rows[0]["date_time_result"]);
                date2 = ic.datetimetoShow(dt.Rows[0]["date_time_approve"]);
                dt.Rows[0]["date_time_result"] = date1;
                dt.Rows[0]["date_time_approve"] = date2;
                if (amh.Equals("1"))
                {
                    rpt.Load("lab_blood_form1_amh.rpt");
                }
                else
                {
                    rpt.Load("lab_blood_form1.rpt");
                }
                //rpt.Load("lab_blood_form1.rpt");
                if (ptt.f_sex_id.Equals("2") && (!ptt.patient_hn_1.Equals("") && !ptt.patient_hn_2.Equals("")))     // เป็น female และ เป็น donor  ไม่ต้องพิมพ์ หัว บริษัท
                {
                    //rpt.SetParameterValue("line1", "");
                    //rpt.SetParameterValue("line2", "");
                    //rpt.SetParameterValue("line3", "");
                }
                else
                {
                    //rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                    //rpt.SetParameterValue("line2", ic.cop.addr1);
                    //rpt.SetParameterValue("line3", ic.cop.addr2);
                    //rpt.SetParameterValue("aaaa", ic.cop.comp_name_t);
                    //rpt.SetParameterValue("bbbb", ic.cop.addr1);
                    //rpt.SetParameterValue("cccc", ic.cop.addr2);
                }
                rpt.SetDataSource(dt);
                //rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                //rpt.SetParameterValue("line2", ic.cop.addr1);
                //rpt.SetParameterValue("line3", ic.cop.addr2);
                //rpt.SetParameterValue("hn", txtHn.Text);
                //rpt.SetParameterValue("name", txtPttNameE.Text);
                //rpt.SetParameterValue("dob", txtDob.Text);
                //rpt.SetParameterValue("sex", txtSex.Text);
                rpt.SetParameterValue("report_by", reportername);
                rpt.SetParameterValue("approve_by", approvedname);
                rpt.SetParameterValue("report_date", txtReportDate.Text);
                rpt.SetParameterValue("approve_date", txtApprovDate.Text);
                rpt.SetParameterValue("collect_date", ic.datetimetoShow(collectdate));
                rpt.SetParameterValue("receive_date", ic.datetimetoShow(receivedate));
                //rpt.SetParameterValue("report_name", " Summary of OPU Report");
                //rpt.SetParameterValue("date1", "" + date1);
                this.cryLab.ReportSource = rpt;
                this.cryLab.Refresh();
                lbEmail.Text = "สร้าง Report เรียบร้อย";
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                    System.Threading.Thread.Sleep(200);
                    Application.DoEvents();
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
                lbEmail.Text = "Export Report";
                rpt.Export();
                System.Threading.Thread.Sleep(200);
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                chk1 = false;
                chk = ex.Message.ToString();
                MessageBox.Show("error " + ex.Message, "");
            }
            return chk1;
        }
        private void BtnSendEmailHormone_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //FrmReport frm = new FrmReport(ic);
            //DataTable dt = new DataTable();
            //dt = ic.ivfDB.lbresDB.selectLabBloodByVsId(txtVsId.Text);
            //String date1 = dt.Rows[0]["date_report"].ToString();
            //String date2 = dt.Rows[0]["date_approve"].ToString();
            //date1 = ic.datetimetoShow(dt.Rows[0]["date_report"]);
            //date2 = ic.datetimetoShow(dt.Rows[0]["date_approve"]);
            //dt.Rows[0]["date_report"] = date1;
            //dt.Rows[0]["date_approve"] = date2;
            ////FrmWaiting frmW = new FrmWaiting();
            ////frmW.Show();
            //frm.setSpermSf(dt);
            //frm.ShowDialog(this);
            SetDefaultPrinter(ic.iniC.printerA4);
            String amh = "";
            DataTable dt = new DataTable();
            dt = ic.ivfDB.lbresDB.selectLabBloodByVsIdHormone(txtVsId.Text);
            foreach (DataRow row in dt.Rows)
            {
                if (row["LID"].ToString().Equals("10"))
                {
                    amh = "1";
                }
                else
                {
                    //amh = "0";
                }
            }
            lbEmail.Text = "เตรียม Email";
            FrmWaiting frmW = new FrmWaiting();
            frmW.Show();
            String filename = "", datetick = "";
            if (!Directory.Exists("report"))
            {
                Directory.CreateDirectory("report");
            }
            datetick = DateTime.Now.Ticks.ToString();
            filename = "report\\lab_blood_" + datetick + ".pdf";
            lbEmail.Text = "เตรียม Report";
            if (!setReportLabBloodHormone(filename))
            {
                return;
            }
            frmW.Dispose();
            if (!File.Exists(filename))
            {
                lbEmail.Text = "ไม่พบ Attach File";
                return;
            }
            lbEmail.Text = "เริ่มส่ง Email";
            MailMessage mail = new MailMessage();
            if (amh.Equals("1"))
            {
                txtEmailSubject.Value = "Routine LAB Result HN " + txtHn.Text.ToUpper() + " Name " + txtPttNameE.Text + " [VN " + txtVnShow.Text + "] Hormone & AMH Report Date " + System.DateTime.Now.ToString("dd/MM/") + System.DateTime.Now.Year;
            }
            else
            {
                txtEmailSubject.Value = "Routine LAB Result HN " + txtHn.Text.ToUpper() + " Name " + txtPttNameE.Text + " [VN " + txtVnShow.Text + "] Hormone Report Date " + System.DateTime.Now.ToString("dd/MM/") + System.DateTime.Now.Year;
            }
            
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
            lbEmail.Text = "ส่ง Email เรียบร้อย";
        }

        private void BtnPrintHormone_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmReport frm = new FrmReport(ic);
            DataTable dt = new DataTable();
            dt = ic.ivfDB.lbresDB.selectLabBloodByVsIdHormone(txtVsId.Text);
            dt.Columns.Add("patient_name", typeof(String));
            dt.Columns.Add("patient_hn", typeof(String));
            dt.Columns.Add("patient_dob", typeof(String));
            dt.Columns.Add("patient_sex", typeof(String));
            dt.Columns.Add("line1", typeof(String));
            dt.Columns.Add("line2", typeof(String));
            dt.Columns.Add("line3", typeof(String));
            dt.Columns.Add("sign_reporter", typeof(String));
            dt.Columns.Add("sign_approved", typeof(String));
            String amh = "", collectdate="", receivedate="", reporter="", approved="", reportername="", approvedname="";
            Staff stf = new Staff();
            //lbRes = ic.ivfDB.lbresDB.selectByPk(resId);
            reporter = ic.ivfDB.stfDB.getIdByNameSurname(cboEmbryologistReport.Text);
            approved = ic.ivfDB.stfDB.getIdByNameSurname(cboEmbryologistAppv.Text);
            stf = ic.ivfDB.stfDB.selectByPk1(reporter);
            reportername = stf.prefix_name_t+" "+stf.staff_fname_e+" "+stf.staff_lname_e + " " + stf.doctor_id;
            stf = ic.ivfDB.stfDB.selectByPk1(approved);
            approvedname = stf.prefix_name_t + " " + stf.staff_fname_e + " " + stf.staff_lname_e + " " + stf.doctor_id;
            foreach (DataRow row in dt.Rows)
            {
                collectdate = row[ic.ivfDB.lbresDB.lbRes.date_time_collect].ToString();
                receivedate = row[ic.ivfDB.lbresDB.lbRes.date_time_receive].ToString();
                if (row["LID"].ToString().Equals("10"))
                {
                    amh =  "1";
                }
                else
                {
                    //amh = "0";
                }
                row["patient_hn"] = txtHn.Text;
                row["patient_name"] = txtPttNameE.Text.ToUpper();
                row["patient_dob"] = txtDob.Text;
                row["patient_sex"] = txtSex.Text;
                row["sign_reporter"] = System.IO.Directory.GetCurrentDirectory() + "\\" + reporter + ".jpg";
                row["sign_approved"] = System.IO.Directory.GetCurrentDirectory() + "\\" + approved + ".jpg";
                if (ptt.f_sex_id.Equals("2") && (!ptt.patient_hn_1.Equals("") && !ptt.patient_hn_2.Equals("")))     // เป็น female และ เป็น donor  ไม่ต้องพิมพ์ หัว บริษัท
                {
                    row["line1"] = "";
                    row["line2"] = "";
                    row["line3"] = "";
                }
                else
                {
                    row["line1"] = ic.cop.comp_name_t;
                    row["line2"] = ic.cop.addr1;
                    row["line3"] = ic.cop.addr2;
                }
            }
            String date1 = "";
            if (ptt.f_sex_id.Equals("2") && (!ptt.patient_hn_1.Equals("") && !ptt.patient_hn_2.Equals("")))     // เป็น female และ เป็น donor  ไม่ต้องพิมพ์ หัว บริษัท
            {
                frm.setLabBloodReportHormone(dt, txtHn.Text, txtPttNameE.Text.ToUpper(), txtDob.Text, txtSex.Text, reportername, approvedname, txtReportDate.Text, txtApprovDate.Text, "1", amh, ic.datetimetoShow(collectdate), ic.datetimetoShow(receivedate));
            }
            else
            {
                frm.setLabBloodReportHormone(dt, txtHn.Text, txtPttNameE.Text.ToUpper(), txtDob.Text, txtSex.Text, reportername, approvedname, txtReportDate.Text, txtApprovDate.Text,"", amh, ic.datetimetoShow(collectdate), ic.datetimetoShow(receivedate));
            }
            
            frm.ShowDialog(this);
        }

        private void BtnApproveResult_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.ivfDB.lbresDB.updateResultFinish(txtVsId.Text);
            tC.SelectedTab = tabEmail;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String stfapp = "", stfrpt = "", dateapp = "", daterpt = "", datecollect="", datereceive="";
            DateTime daterpt1 = new DateTime();
            DateTime dateapp1 = new DateTime();
            DateTime datecollect1 = new DateTime();
            DateTime datereceive1 = new DateTime();
            stfrpt = cboEmbryologistReport.SelectedItem == null ? "" : ((ComboBoxItem)cboEmbryologistReport.SelectedItem).Value;
            stfapp = cboEmbryologistAppv.SelectedItem == null ? "" : ((ComboBoxItem)cboEmbryologistAppv.SelectedItem).Value;
            daterpt = ic.dateTimetoDB1(txtReportDate.Text);
            dateapp = ic.dateTimetoDB1(txtApprovDate.Text);
            datecollect = ic.dateTimetoDB1(txtCollectTime.Text);
            datereceive = ic.dateTimetoDB1(txtReceiveTime.Text);

            Staff stf = new Staff();
            stf = ic.ivfDB.stfDB.selectByPk1(stfrpt);
            if (stf.staff_id.Equals(""))
            {
                MessageBox.Show("ไม่พบ รายชื่อพนักงาน Report", "");
                return;
            }
            stf = ic.ivfDB.stfDB.selectByPk1(stfapp);
            if (stf.staff_id.Equals(""))
            {
                MessageBox.Show("ไม่พบ รายชื่อพนักงาน Approve", "");
                return;
            }
            if(!DateTime.TryParse(daterpt, out daterpt1))
            {
                MessageBox.Show("Report Datetime ไม่ถูกต้อง", "");
                return;
            }
            if (!DateTime.TryParse(dateapp, out dateapp1))
            {
                MessageBox.Show("Approve Datetime ไม่ถูกต้อง", "");
                return;
            }
            if (!DateTime.TryParse(datecollect, out datecollect1))
            {
                MessageBox.Show("Collect time ไม่ถูกต้อง", "");
                return;
            }
            if (!DateTime.TryParse(datereceive, out datereceive1))
            {
                MessageBox.Show("Receive time ไม่ถูกต้อง", "");
                return;
            }
            String lotInput = "";
            foreach(Row row in grfProc.Rows)
            {
                String id = "", edit = "", result="", interpret="", remark, lotinput="", reactive="";
                id = row[colRsId] != null ? row[colRsId].ToString() : "";
                if (id.Equals("")) continue;
                edit = row[colRsEdit] != null ? row[colRsEdit].ToString() : "";
                result = row[colRsResult] != null ? row[colRsResult].ToString() : "";
                interpret = row[colRsInterpret] != null ? row[colRsInterpret].ToString() : "";
                remark = row[colRsRemark] != null ? row[colRsRemark].ToString() : "";
                lotinput = row[colRsLotInput] != null ? row[colRsLotInput].ToString() : "";
                reactive = row[colRsReactive] != null ? row[colRsReactive].ToString() : "";
                String re1 = ic.ivfDB.lbresDB.updateResultDate(stfapp, stfrpt, dateapp, daterpt, datecollect, datereceive, id);
                if (edit.Equals("1") && !result.Equals(""))
                {
                    if (lotinput.Equals(""))
                    {
                        lotinput = ic.ivfDB.lbresDB.selectLotInput(txtVsId.Text);
                        int chk1 = 0;
                        if(int.TryParse(lotinput, out chk1))
                        {
                            lotinput = (chk1 + 1).ToString();
                        }
                    }
                    String re = ic.ivfDB.lbresDB.updateResult(result, interpret, remark, lotinput, reactive, id);
                    long chk = 0;
                    if(long.TryParse(re, out chk))
                    {

                    }
                }
            }
        }
        private void setControl()
        {
            lbRes = ic.ivfDB.lbresDB.selectByPk(resId);
            vs = ic.ivfDB.vsDB.selectByPk1(lbRes.visit_id);
            ptt = ic.ivfDB.pttDB.selectByPk1(vs.t_patient_id);

            txtVn.Value = vs.visit_vn;
            txtPttId.Value = ptt.t_patient_id;
            txtVsId.Value = vs.t_visit_id;

            txtVnShow.Value = ic.showVN(vs.visit_vn);
            txtHn.Value = ptt.patient_hn;
            txtPttNameE.Value = ptt.Name.ToUpper();
            txtDob.Value = ic.datetoShow(ptt.patient_birthday) + " [" + ptt.AgeStringShort() + "]";
            txtSex.Value = ptt.f_sex_id.Equals("1") ? "Male" : "Female";

            ic.setC1Combo(cboEmbryologistAppv, lbRes.staff_id_approve);
            ic.setC1Combo(cboEmbryologistReport, lbRes.staff_id_result);
            ic.setC1Combo(cboDoctor, ic.ivfDB.stfDB.getIdByIdOld(lbRes.doctor_id));

            txtApprovDate.Value = lbRes.date_time_approve;
            txtReportDate.Value = lbRes.date_time_result;
            //if (lbRes.date_time_collect.Equals(""))
            //{
            //    txtCollectTime.Value = DateTime.Now.Year+"-"+DateTime.Now.ToString("MM-dd");
            //}
            //else
            //{
            txtCollectTime.Value = lbRes.date_time_collect;
            //}
            //if (lbRes.date_time_receive.Equals(""))
            //{
            //    txtReceiveTime.Value = lbRes.req_date_time;
            //}
            //else
            //{
            txtReceiveTime.Value = lbRes.date_time_receive;
            //}
            

            txtEmailTo.Value = ic.iniC.email_to_sperm_freezing;
            txtEmailSubject.Value = "Result LAB Blood HN " + txtHn.Text + " Name " + txtPttNameE.Text + "Sex "+txtSex.Text+ " [VN " + txtVnShow.Text + "]";

            if (ic.user.dept_id.Equals("1090000005"))
            {
                setControlView(true);
                flagView = false;
            }
            else
            {
                flagView = true;
                if (ic.user.status_admin.Equals("2"))
                {
                    setControlView(true);
                }
                else
                {
                    setControlView(false);
                }
            }
            setGrfProc();
            
        }
        private void setControlView(Boolean flag)
        {
            txtHn.Enabled = flag;
            txtPttNameE.Enabled = flag;
            txtDob.Enabled = flag;
            cboEmbryologistAppv.Enabled = flag;
            cboEmbryologistReport.Enabled = flag;
            txtSex.Enabled = flag;
            txtReportDate.Enabled = flag;
            txtApprovDate.Enabled = flag;
            btnSave.Visible = flag;
            btnApproveResult.Visible = flag;

        }
        private void initGrfProc()
        {
            grfProc = new C1FlexGrid();
            grfProc.Font = fEdit;
            grfProc.Dock = System.Windows.Forms.DockStyle.Fill;
            grfProc.Location = new System.Drawing.Point(0, 0);
            grfProc.ChangeEdit += GrfProc_ChangeEdit;
            grfProc.AfterRowColChange += GrfProc_AfterRowColChange;
            grfProc.AfterEdit += GrfProc_AfterEdit;
            //FilterRow fr = new FilterRow(grfExpn);
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_lab_Cancel));
            grfProc.ContextMenu = menuGw;
            pnProc.Controls.Add(grfProc);

            theme1.SetTheme(grfProc, "Office2010Blue");
        }
        private void ContextMenu_lab_Cancel(object sender, System.EventArgs e)
        {
            String reqid = "", resid = "", statusresult = "";
            //reqid = grfProc[grfProc.Row, colRsLabReqId] != null ? grfProc[grfProc.Row, colRsLabReqId].ToString() : "";
            resid = grfProc[grfProc.Row, colRsId] != null ? grfProc[grfProc.Row, colRsId].ToString() : "";
            ic.cStf.staff_id = "";
            FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            frm.ShowDialog(this);
            if (!ic.cStf.staff_id.Equals(""))
            {
                ic.ivfDB.VoidLabReult(resid, ic.cStf.staff_id);
                setGrfProc();
            }
        }
        private void GrfProc_AfterEdit(object sender, RowColEventArgs e)
        {
            //throw new NotImplementedException();
            if (grfProc.Row <= 0) return;
            if (grfProc.Col <= 0) return;
            if (grfProc.Col == colRsResult)
            {
                String resid = "", labid = "", result = "", result2="";
                result = grfProc[grfProc.Row, colRsResult] != null ? grfProc[grfProc.Row, colRsResult].ToString().Trim() : "";
                if (result.Equals("w"))
                {
                    grfProc[grfProc.Row, colRsInterpret] = "Wait for Result";
                }
                else
                {
                    Decimal result1 = 0;
                    OldLabItem labI = new OldLabItem();
                    resid = grfProc[grfProc.Row, colRsId] != null ? grfProc[grfProc.Row, colRsId].ToString() : "";
                    labid = grfProc[grfProc.Row, colRsLabId] != null ? grfProc[grfProc.Row, colRsLabId].ToString() : "";

                    labI = ic.ivfDB.oLabiDB.selectByPk1(labid);
                    if (labI.LID.Length <= 0) return;
                    if (labI.status_interpret.Equals("1"))
                    {
                        if(result.Equals(""))
                        {
                            grfProc[grfProc.Row, colRsInterpret] = "";
                        }
                        if (result.IndexOf("<") >= 0 || (result.IndexOf(">") >= 0))
                        {
                            result2 = result.Replace("<", "").Replace(">", "");
                            if((result.IndexOf("<") >= 0) && result.Trim().Equals(labI.lis_min_value))
                            {
                                String temp = "";
                                int chk = 0;
                                if(int.TryParse(labI.datatype_decimal, out chk))
                                {
                                    for (int i = 0; i < chk-1; i++)
                                    {
                                        temp += "0";
                                    }
                                    temp += "1";
                                }
                                temp = "." + temp;
                                decimal temp1 = 0, temp2=0, temp3=0;
                                Decimal.TryParse(result2, out temp3);
                                if (Decimal.TryParse(temp, out temp1))
                                {
                                    temp2 = temp3 - temp1;
                                    result2 = temp2.ToString();
                                }
                            }
                            else if ((result.IndexOf(">") >= 0) && result.Trim().Equals(labI.lis_max_value))
                            {
                                String temp = "";
                                int chk = 0;
                                if (int.TryParse(labI.datatype_decimal, out chk))
                                {
                                    for (int i = 0; i < chk - 1; i++)
                                    {
                                        temp += "0";
                                    }
                                    temp += "1";
                                }
                                temp = "." + temp;
                                decimal temp1 = 0, temp2 = 0, temp3 = 0;
                                Decimal.TryParse(result2, out temp3);
                                if (Decimal.TryParse(temp, out temp1))
                                {
                                    temp2 = temp3 + temp1;
                                    result2 = temp2.ToString();
                                }
                            }
                        }
                        else
                        {
                            result2 = result;
                        }
                        if (!Decimal.TryParse(result2, out result1)) return;
                        String interpret = "";
                        interpret = ic.ivfDB.lbinDB.selectInterpret(labid, result1.ToString());
                        if (interpret.Equals("@@"))       // ถ้าไม่เจอ น่าจะเป็น min
                        {
                            interpret = ic.ivfDB.lbinDB.selectInterpretMin(labid, result1.ToString());
                            if (interpret.Equals(""))       // ถ้าไม่เจออีก น่าจะเป็น max
                            {
                                interpret = ic.ivfDB.lbinDB.selectInterpretMax(labid, result1.ToString());
                            }
                        }
                        String[] interpret1;
                        interpret1 = interpret.Split('@');
                        if (interpret1.Length == 3)
                        {
                            grfProc[grfProc.Row, colRsInterpret] = interpret1[0];
                            grfProc[grfProc.Row, colRsReactive] = interpret1[1];
                            grfProc[grfProc.Row, colRsRemark] = interpret1[2];
                        }
                        else
                        {
                            grfProc[grfProc.Row, colRsInterpret] = result;
                            grfProc[grfProc.Row, colRsRemark] = "";
                        }
                    }
                    else
                    {
                        grfProc[grfProc.Row, colRsInterpret] = result;
                    }
                }
                
                grfProc[grfProc.Row, colRsEdit] = "1";
                grfProc.Rows[grfProc.Row].StyleNew.BackColor = color;
            }
        }

        private void GrfProc_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            
            
        }

        private void setGrfProc()
        {
            //grfDept.Rows.Count = 7;
            grfProc.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.lbresDB.selectLabBloodByProcess(lbRes.visit_id);
            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfProc.Rows.Count = dt.Rows.Count + 1;
            //grfSperm.DataSource = dt;
            grfProc.Cols.Count = 15;
            CellStyle cs = grfProc.Styles.Add("bool");
            cs.DataType = typeof(bool);
            cs.ImageAlign = ImageAlignEnum.LeftCenter;

            C1ComboBox cboMethod = new C1ComboBox();
            cboMethod.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboMethod.AutoCompleteSource = AutoCompleteSource.ListItems;
            ic.ivfDB.lbmDB.setCboLabMethod(cboMethod, "");
            C1ComboBox cboUnit = new C1ComboBox();
            cboUnit.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboUnit.AutoCompleteSource = AutoCompleteSource.ListItems;
            ic.ivfDB.lbuDB.setCboLabUnit(cboUnit, "");

            grfProc.Cols[colRsMethod].Editor = cboMethod;
            grfProc.Cols[colRsUnit].Editor = cboUnit;
            grfProc.Cols[colRsLabName].Width = 200;
            grfProc.Cols[colRsMethod].Width = 100;
            grfProc.Cols[colRsResult].Width = 100;
            grfProc.Cols[colRsInterpret].Width = 150;
            grfProc.Cols[colRsUnit].Width = 100;
            grfProc.Cols[colRsNormal].Width = 100;
            grfProc.Cols[colRsRemark].Width = 200;
            grfProc.Cols[colRsReactive].Width = 150;
            grfProc.Cols[colRsRemarkNurse].Width = 150;
            //grfProc.Cols[colBlQty].Width = 60;

            grfProc.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfProc.Cols[colRsLabName].Caption = "Name";
            grfProc.Cols[colRsMethod].Caption = "Method";
            grfProc.Cols[colRsResult].Caption = "Result";
            grfProc.Cols[colRsInterpret].Caption = "Interpret";
            grfProc.Cols[colRsUnit].Caption = "Unit";
            grfProc.Cols[colRsNormal].Caption = "Normal";
            grfProc.Cols[colRsRemark].Caption = "Remark";
            grfProc.Cols[colRsReactive].Caption = "Reactive";
            grfProc.Cols[colRsRemarkNurse].Caption = "Remark Nurse";

            //CellRange rg = grfProc.GetCellRange(1, colBlInclude, grfProc.Rows.Count - 1, colBlInclude);
            //rg.Style = cs;
            //rg.Style = grfProc.Styles["bool"];

            int i = 0;
            decimal aaa = 0;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    i++;
                    //if (i == 1) continue;
                    //Decimal.TryParse(row[ic.ivfDB.oLabiDB.labI.Price].ToString(), out aaa);
                    grfProc[i, colRsId] = row[ic.ivfDB.lbresDB.lbRes.result_id].ToString();
                    grfProc[i, colRsLabName] = row[ic.ivfDB.oLabiDB.labI.LName].ToString();
                    grfProc[i, colRsMethod] =  ic.ivfDB.lbmDB.getNameById(row[ic.ivfDB.oLabiDB.labI.method_id].ToString());
                    grfProc[i, colRsRemark] = row[ic.ivfDB.lbresDB.lbRes.remark].ToString();
                    grfProc[i, colRsLotInput] = row[ic.ivfDB.lbresDB.lbRes.lot_input].ToString();
                    if (row[ic.ivfDB.oLabiDB.labI.status_datatype_result].ToString().Equals("4"))       // combobox
                    {
                        C1ComboBox cbo = new C1ComboBox();
                        cbo.AutoCompleteMode = AutoCompleteMode.Suggest;
                        cbo.AutoCompleteSource = AutoCompleteSource.ListItems;
                        ic.ivfDB.lbDtDB.setCboLabDataTypeComboBox(cbo, "", row[ic.ivfDB.lbresDB.lbRes.lab_id].ToString());

                        CellRange cr = grfProc.GetCellRange(i, colRsResult, i, colRsResult);
                        //cr.Style = grfProc.Styles["emp"];
                        cr.StyleNew.Editor = cbo;
                        //CellStyle cs1 = grfProc.Styles.Add("bool");
                        //cr.Style = cs1;
                    }
                    else if (row[ic.ivfDB.oLabiDB.labI.status_datatype_result].ToString().Equals("2"))      // integer
                    {
                    //    C1ComboBox cbo = new C1ComboBox();
                    //    cbo.AutoCompleteMode = AutoCompleteMode.Suggest;
                    //    cbo.AutoCompleteSource = AutoCompleteSource.ListItems;
                    //    ic.ivfDB.lbinDB.setCboLabInterpretComboBox(cbo, "", row[ic.ivfDB.lbresDB.lbRes.lab_id].ToString());
                        
                        CellRange cr = grfProc.GetCellRange(i, colRsResult, i, colRsResult);
                        //cr.StyleNew.Editor = cbo;
                        CellStyle cs1 = grfProc.Styles.Add("integer");
                        cs.DataType = typeof(int);
                        cs.ForeColor = Color.CornflowerBlue;
                        cr.Style = cs1;
                    }
                    else if (row[ic.ivfDB.oLabiDB.labI.status_datatype_result].ToString().Equals("3"))      // decimal
                    {
                        CellRange cr = grfProc.GetCellRange(i, colRsResult, i, colRsResult);
                        //cr.StyleNew.Editor = cbo;
                        CellStyle cs1 = grfProc.Styles.Add("decimal");
                        cs.DataType = typeof(decimal);
                        cs.ForeColor = Color.DarkGreen;
                        cr.Style = cs1;
                    }
                    grfProc[i, colRsResult] = row[ic.ivfDB.lbresDB.lbRes.result].ToString();
                    grfProc[i, colRsInterpret] = row[ic.ivfDB.lbresDB.lbRes.interpret].ToString();
                    grfProc[i, colRsUnit] = ic.ivfDB.lbuDB.getNameById(row[ic.ivfDB.oLabiDB.labI.lab_unit_id].ToString());
                    grfProc[i, colRsNormal] = row[ic.ivfDB.lbresDB.lbRes.normal_value].ToString();
                    grfProc[i, colRsRemark] = row[ic.ivfDB.lbresDB.lbRes.remark].ToString();
                    grfProc[i, colRsLabId] = row[ic.ivfDB.oLabiDB.labI.LID].ToString();
                    grfProc[i, colRsReactive] = row[ic.ivfDB.lbresDB.lbRes.reactive_message].ToString();
                    grfProc[i, colRsRemarkNurse] = row[ic.ivfDB.lbresDB.lbRes.remark_nurse].ToString();
                    grfProc[i, colRsEdit] = "";
                    //grfSgrfProcperm[i, colBlQty] = "1";
                    row[0] = (i - 2);
                }
                catch (Exception ex)
                {
                    String err = "";
                }
            }
            CellNoteManager mgr = new CellNoteManager(grfProc);
            grfProc.Cols[colRsId].Visible = false;
            grfProc.Cols[colRsLabId].Visible = false;
            grfProc.Cols[colRsReqId].Visible = false;
            grfProc.Cols[colRsEdit].Visible = false;
            grfProc.Cols[colRsLotInput].Visible = false;

            grfProc.Cols[colRsLabName].AllowEditing = false;
            //grfProc.Cols[colRsMethod].AllowEditing = false;
            //grfProc.Cols[colRsResult].AllowEditing = false;
            //grfProc.Cols[colRsInterpret].AllowEditing = false;
            grfProc.Cols[colRsEdit].AllowEditing = false;
            grfProc.Cols[colRsNormal].AllowEditing = false;
            grfProc.Cols[colRsRemark].AllowEditing = true;

            grfProc.Cols[colRsRemark].AllowEditing = !flagView;
            grfProc.Cols[colRsResult].AllowEditing = !flagView;
            grfProc.Cols[colRsInterpret].AllowEditing = !flagView;
            grfProc.Cols[colRsReactive].AllowEditing = !flagView;
            grfProc.Cols[colRsUnit].AllowEditing = !flagView;
            grfProc.Cols[colRsMethod].AllowEditing = !flagView;
            grfProc.Cols[colRsRemarkNurse].AllowEditing = false;
            //theme1.SetTheme(grfFinish, ic.theme);

        }
        private void GrfProc_ChangeEdit(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            grfProc[grfProc.Row, colRsEdit] = "1";
            grfProc.Rows[grfProc.Row].StyleNew.BackColor = color;
        }

        private void FrmLabBloodAdd_Load(object sender, EventArgs e)
        {
            tC.SelectedTab = tabResult;
        }
    }
}
