using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1SuperTooltip;
using clinic_ivf.control;
using clinic_ivf.object1;
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

            btnPrintOpuEmbryoDev.Click += BtnPrintOpuEmbryoDev_Click;
            btnPrint.Click += BtnPrint_Click;
            btnSendEmail.Click += BtnSendEmail_Click;
            btnResult.Click += BtnResult_Click;
            SmtpServer.SendCompleted += SmtpServer_SendCompleted;

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

            //stt.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.Gold;
            
            initGrf();
            setControl();
            setGrf();
            setTheme();
            char c = '\u00B5';
            label86.Text = c.ToString() + "l";
            btnSendEmail.Enabled = false;
            if (!ic.user.status_module_lab.Equals("1"))
            {
                                

            }
        }

        private void BtnResult_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //sendHtmlEmail1();
            setEmail(false);
            btnSendEmail.Enabled = true;
        }

        private void BtnSendEmail_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //setEmail(true);
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("eploentham@gmail.com");
            mail.To.Add("eploentham@outlook.co.th");
            mail.Subject = "Result OPU2";
            //mail.Body = "Test send email";

            mail.IsBodyHtml = true;
            //MemoryStream stream = new MemoryStream();
            //StreamWriter writer = new StreamWriter(stream);
            //writer.Write(body);
            //writer.Flush();
            //stream.Position = 0;
            //richTextBox1.LoadFile(stream, RichTextBoxStreamType.PlainText);

            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
            mail.AlternateViews.Add(htmlView);
            //Add Image
            //LinkedResource theEmailImage = new LinkedResource(path+ "\\embryo_dev_1.jpg");
            //theEmailImage.ContentId = "myImageID";
            //htmlView.LinkedResources.Add(theEmailImage);
            foreach (LinkedResource linkimg in theEmailImage1)
            {
                htmlView.LinkedResources.Add(linkimg);
            }
            //System.Net.Mail.Attachment attachment;
            //attachment = new System.Net.Mail.Attachment(txtAttachment.Text);
            //mail.Attachments.Add(attachment);

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("eploentham@gmail.com", "Singcamma1*");

            SmtpServer.EnableSsl = true;
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
        private void setEmail(Boolean flagEmail)
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
            theme1.SetTheme(grfDay2, theme2);
            theme1.SetTheme(grfDay3, theme2);
            theme1.SetTheme(grfDay5, theme2);
            theme1.SetTheme(grfDay6, theme2);
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
            //txtEmbryoFreezMedia0.Value = opu.embryo_freez_freeze_media_0;
            //txtEmbryoFreezMedia1.Value = opu.embryo_freez_freeze_media_1;

            //txtRemark.Value = opu.remark;
            ic.setC1ComboByName(cboRemark, opu.remark);
            ic.setC1ComboByName(cboRemark1, opu.remark_1);
            txtDatePicEmbryo.Value = opu.date_pic_embryo;
            //CboEmbryoDay.Text = opu.emb
            if (opu.status_opu.Equals("2"))
            {                
                String appr = "";
                appr = ic.ivfDB.stfDB.getStaffNameBylStf(opu.approve_result_staff_id);
                txtApproveResult.Value = appr;
            }
            else
            {
                
            }
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
                        if ((imgcol == 3) || (imgcol == 0))
                        {
                            tr = "<tr>";
                            tr1 = "</tr>";
                        }
                        else
                        {
                            tr = "";
                            tr1 = "";
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
                        file.IsReadOnly = true;
                    }
                }
                //body = "<html><body><p>Embryo development Day " + day + "111</p> </br>" +
                //    "<table width='100%'><tr>" + tdimg + "</tr></table> </body> </html>";
                //String body1 = "<html><body><p>Embryo development Day " + day + "111</p> </br>" +
                //    "<table width='100%'><tr>" + tdimg1 + "</tr></table> </body> </html>";
                body = "<html><body><p>Embryo development Day " + day + "111</p> </br>" +
                    "<table width='100%'>" + tdimg + "</table> </body> </html>";
                String body1 = "<html><body><p>Embryo development Day " + day + "111</p> </br>" +
                    "<table width='100%'>" + tdimg1 + "</table> </body> </html>";
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
            tCResult.SelectedTab = tabOPU;
        }
    }
}
