using AForge.Video.DirectShow;
using C1.C1Pdf;
using C1.Win.C1Document;
using C1.Win.C1Document.Export;
using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1SuperTooltip;
using clinic_ivf.control;
using clinic_ivf.object1;
using clinic_ivf.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.gui
{
    public partial class FrmPatientAdd : Form
    {
        IvfControl ic;
        String pttId = "", webcamname="";
        Patient ptt;

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;
        int colID = 1, colNum = 2, colDesc = 3, colDesc2 = 4, colDesc3 = 5;
        
        C1FlexGrid grfDay2, grfDay3, grfDay5, grfDay6;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;

        FilterInfoCollection webcanDevice;
        
        Bitmap img;
        Image image1;

        String filename = "";
        
        public FrmPatientAdd(IvfControl ic, String pttid)
        {
            InitializeComponent();
            this.ic = ic;
            pttId = pttid;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);
            
            theme1.SetTheme(sB, "BeigeOne");
            barcode.BackColor = this.BackColor;

            sB1.Text = "";
            bg = txtPttName.BackColor;
            fc = txtPttName.ForeColor;
            ff = txtPttName.Font;

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            image1 = null;
            try
            {
                webcanDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                ic.video = new VideoCaptureDevice();
                foreach (FilterInfo device in webcanDevice)
                {
                    webcamname = device.Name;
                    //video.NewFrame += Video_NewFrame;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(" no camera Found\n" + ex.Message);
            }

            txtDob.Value = DateTime.Now.ToString("yyyy-MM-dd");
            ic.ivfDB.fpDB.setCboPrefix(cboPrefix);
            ic.ivfDB.fmsDB.setCboMarriage(cboMarital);
            ic.ivfDB.fbgDB.setCboBloodGroup(cboBloodG);
            ic.ivfDB.fpnDB.setCboNation(CboNation);
            ic.ivfDB.fetDB.setCboEduca(CboEduca);
            ic.ivfDB.frcDB.setCboRace(cboRace);
            ic.ivfDB.frgDB.setCboReligion(cboRg);
            ic.ivfDB.fpDB.setCboPrefix(cboCouPrefix);
            ic.ivfDB.fpDB.setCboPrefix(cboName1Prefix);
            ic.ivfDB.fpDB.setCboPrefix(cboName2Prefix);
            ic.ivfDB.frlDB.setCboRelation(cboCouRel);
            ic.ivfDB.frlDB.setCboRelation(cboName1Rl);
            ic.ivfDB.frlDB.setCboRelation(cboName2Rl);
            ic.ivfDB.sexDB.setCboSex(cboSex);

            setControl(pttId);
            setFocusColor();

            btnPrnSticker.Click += BtnPrnSticker_Click;
            btnSave.Click += BtnSave_Click;
            btnWebCamOn.Click += BtnWebCamOn_Click;
            btnCapture.Click += BtnCapture_Click;
            this.FormClosed += FrmPatientAdd_FormClosed;
            btnPrvSticker.Click += BtnPrvSticker_Click;

            btnCapture.Enabled = false;
            btnSavePic.Enabled = false;
        }
        
        private void FrmPatientAdd_FormClosed(object sender, FormClosedEventArgs e)
        {
            //throw new NotImplementedException();
            Exit();
        }
        private void TakePic()
        {
            //myPlayer.SoundLocation = appPath + "\\camera.wav";
            //myPlayer.Play();
            //listView1.Items.Clear();
            //imageList1.Images.Clear();
            image1 = (Image)img.Clone();
            if (image1 == null)
            {
            }
            else
            {
                ic.video.Stop();
                btnSavePic.Enabled = true;
                //img = (Bitmap)eventArgs.Frame.Clone();
                //picPtt.Image = img;
            }

            image1 = null;
            //loadimages();
        }
        private void BtnCapture_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            TakePic();
        }

        private void BtnWebCamOn_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();            
            try
            {
                ic.video = new VideoCaptureDevice(webcanDevice[0].MonikerString);
                ic.video.NewFrame += Video_NewFrame;
                ic.video.Start();
                btnCapture.Enabled = true;
                btnSavePic.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry there is no camera Found\n" + ex.Message);
            }
        }

        private void Video_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            //throw new NotImplementedException();
            img = (Bitmap)eventArgs.Frame.Clone();
            picPtt.Image = img;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            //    setPatient();
            //    String re = ic.ivfDB.pttDB.insertPatient(ptt, ic.user.staff_id);
            //    int chk = 0;
            //    if (int.TryParse(re, out chk))
            //    {
            //        //ic.ivfDB.stfDB.getlStf();
            //        btnSave.Image = Resources.accept_database24;
            //    }
            //    else
            //    {
            //        btnSave.Image = Resources.accept_database24;
            //    }
            //    //setGrfStfH();
            //    //setControlEnable(false);
            //    //this.Dispose();
            //}
            if (btnSave.Text.Equals("Confirm"))
            {
                stt.Hide();
                setPatient();
                String re = ic.ivfDB.pttDB.insertPatient(ptt, txtStfConfirmID.Text);
                int chk = 0;
                if (int.TryParse(re, out chk))
                {
                    btnSave.Image = Resources.accept_database24;
                    txtID.Value = re;
                    //System.Threading.Thread.Sleep(2000);
                    //this.Dispose();
                }
            }
            else
            {
                ic.cStf.staff_id = "";
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    txtUserReq.Value = ic.cStf.staff_fname_t + " " + ic.cStf.staff_lname_t;
                    txtStfConfirmID.Value = ic.cStf.staff_id;
                    btnSave.Text = "Confirm";
                    btnSave.Image = Resources.Add_ticket_24;
                    stt.Show("<p><b>สวัสดี</b></p>คุณ " + ic.cStf.staff_fname_t + " " + ic.cStf.staff_lname_t + "<br> กรุณายินยันการ confirm อีกครั้ง", btnWebCamOn);
                }
                else
                {
                    btnSave.Text = "Save";
                    btnSave.Image = Resources.download_database24;
                }
            }
        }
        private void BtnPrvSticker_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            filename = "flow.pdf";
            try
            {
                createPDFSticker(cboPrefix.Text + " " + txtPttName.Text + " " + txtPttLName.Text + "\n" + txtDob.Text);
                //cPdf.LoadFromFile(filename);
                //cPdf.lo(filename);
                //break;
            }
            catch (PdfPasswordException)
            {
                string password = PasswordForm.DoEnterPassword(filename);
                if (password == null)
                    return;
                cPdf.Credential.Password = password;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            FrmPrintPreview frm = new FrmPrintPreview(ic, filename);
            frm.ShowDialog(this);
        }
        private void BtnPrnSticker_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //MessageBox.Show("aaaa", "");
            filename = "flow.pdf";            
            try
            {
                createPDFSticker(cboPrefix.Text+" "+ txtPttName.Text+" "+txtPttLName.Text+"\n"+txtDob.Text);
                cPdf.LoadFromFile(filename);
                //cPdf.lo(filename);
                //break;
            }
            catch (PdfPasswordException)
            {
                string password = PasswordForm.DoEnterPassword(filename);
                if (password == null)
                    return;
                cPdf.Credential.Password = password;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //}
            // execute action            
            DoPrint(cPdf);
        }
        private void setFocusColor()
        {
            this.txtHn.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtHn.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtPid.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtPid.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtPaasport.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtPaasport.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtPttName.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtPttName.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtPttLName.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtPttLName.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtMobile1.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtMobile1.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtMobile2.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtMobile2.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtLineID.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtLineID.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtRemark.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtRemark.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtEmail.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtEmail.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtFatherFname.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtFatherFname.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtFatherLname.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtFatherLname.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtMotherFname.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtMotherFname.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtMotherLname.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtMotherLname.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtCouFname.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtCouFname.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtCouLname.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtCouLname.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtContMobile2.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtContMobile2.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtContMobile1.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtContMobile1.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtContFname1.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtContFname1.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtContFname2.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtContFname2.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtContLname1.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtContLname1.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtContLname2.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtContLname2.Enter += new System.EventHandler(this.textBox_Enter);

            this.cboBloodG.Leave += new System.EventHandler(this.textBox_Leave);
            this.cboBloodG.Enter += new System.EventHandler(this.textBox_Enter);

            this.cboCouPrefix.Leave += new System.EventHandler(this.textBox_Leave);
            this.cboCouPrefix.Enter += new System.EventHandler(this.textBox_Enter);

            this.cboCouRel.Leave += new System.EventHandler(this.textBox_Leave);
            this.cboCouRel.Enter += new System.EventHandler(this.textBox_Enter);

            this.CboEduca.Leave += new System.EventHandler(this.textBox_Leave);
            this.CboEduca.Enter += new System.EventHandler(this.textBox_Enter);

            this.cboMarital.Leave += new System.EventHandler(this.textBox_Leave);
            this.cboMarital.Enter += new System.EventHandler(this.textBox_Enter);

            this.cboName1Prefix.Leave += new System.EventHandler(this.textBox_Leave);
            this.cboName1Prefix.Enter += new System.EventHandler(this.textBox_Enter);

            this.cboName1Rl.Leave += new System.EventHandler(this.textBox_Leave);
            this.cboName1Rl.Enter += new System.EventHandler(this.textBox_Enter);

            this.cboName2Prefix.Leave += new System.EventHandler(this.textBox_Leave);
            this.cboName2Prefix.Enter += new System.EventHandler(this.textBox_Enter);

            this.cboName2Rl.Leave += new System.EventHandler(this.textBox_Leave);
            this.cboName2Rl.Enter += new System.EventHandler(this.textBox_Enter);

            this.CboNation.Leave += new System.EventHandler(this.textBox_Leave);
            this.CboNation.Enter += new System.EventHandler(this.textBox_Enter);

            this.cboPrefix.Leave += new System.EventHandler(this.textBox_Leave);
            this.cboPrefix.Enter += new System.EventHandler(this.textBox_Enter);

            this.cboRace.Leave += new System.EventHandler(this.textBox_Leave);
            this.cboRace.Enter += new System.EventHandler(this.textBox_Enter);

            this.cboRg.Leave += new System.EventHandler(this.textBox_Leave);
            this.cboRg.Enter += new System.EventHandler(this.textBox_Enter);

            this.cboSex.Leave += new System.EventHandler(this.textBox_Leave);
            this.cboSex.Enter += new System.EventHandler(this.textBox_Enter);
            //this.txtPid1.Enter += new System.EventHandler(this.textBox_Enter);
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
        private void Exit()
        {
            if (ic.video != null && ic.video.IsRunning)
            {
                ic.video.SignalToStop();
                ic.video.WaitForStop();
                ic.video.Stop();
                ic.video = null;
            }
        }
        private void setControl(String pttid)
        {
            ptt = ic.ivfDB.pttDB.selectByPk1(pttid);
            txtHn.Value = ptt.patient_hn;
            txtID.Value = ptt.t_patient_id;
            txtPttName.Value = ptt.patient_firstname;
            txtPttLName.Value = ptt.patient_lastname;
            txtRemark.Value = ptt.remark;
            txtLineID.Value = ptt.line_id;
            txtEmail.Value = ptt.email;
            txtMobile1.Value = ptt.mobile1;
            txtMobile2.Value = ptt.mobile2;
            txtPid.Value = ptt.pid;
            txtPaasport.Value = ptt.passport;
            txtFatherFname.Value = ptt.patient_father_firstname;
            txtFatherLname.Value = ptt.patient_father_lastname;
            txtMotherFname.Value = ptt.patient_mother_firstname;
            txtMotherLname.Value = ptt.patient_mother_lastname;
            txtCouFname.Value = ptt.patient_couple_firstname;
            txtCouLname.Value = ptt.patient_couple_lastname;

            ic.setC1Combo(cboPrefix, ptt.f_patient_prefix_id);
            ic.setC1Combo(cboSex, ptt.f_sex_id);
            ic.setC1Combo(cboMarital, ptt.f_patient_marriage_status_id);
            ic.setC1Combo(cboBloodG, ptt.f_patient_blood_group_id);
            ic.setC1Combo(CboNation, ptt.f_patient_nation_id);
            ic.setC1Combo(CboEduca, ptt.f_patient_education_type_id);
            ic.setC1Combo(cboRace, ptt.f_patient_race_id);
            ic.setC1Combo(cboRg, ptt.f_patient_religion_id);
            //ic.setC1Combo(cboCouPrefix, ptt.f_patient_religion_id);
            //ic.setC1Combo(cboRg, ptt.f_patient_religion_id);
            //ic.setC1Combo(cboRg, ptt.f_patient_religion_id);
            //ic.setC1Combo(cboRg, ptt.f_patient_religion_id);
            //ic.setC1Combo(cboRg, ptt.f_patient_religion_id);
            //ic.setC1Combo(cboRg, ptt.f_patient_religion_id);
            chkChronic.Checked = ptt.status_chronic.Equals("1") ? true : false;
            chkDenyAllergy.Checked = ptt.status_deny_allergy.Equals("1") ? true : false;
            barcode.Text = txtHn.Text;
        }
        private void setPatient()
        {
            ptt.t_patient_id = txtID.Text;
            
            ptt.patient_hn = txtID.Text.Equals("") ? ic.ivfDB.copDB.genHNDoc() : txtHn.Text;
            ptt.patient_firstname = txtPttName.Text;
            ptt.patient_lastname = txtPttLName.Text;
            ptt.remark = txtRemark.Text;
            ptt.line_id = txtLineID.Text;
            ptt.email = txtEmail.Text;
            ptt.mobile1 = txtMobile1.Text;
            ptt.mobile2 = txtMobile2.Text;
            ptt.pid = txtPid.Text;
            ptt.passport = txtPaasport.Text;
            ptt.patient_father_firstname = txtFatherFname.Text;
            ptt.patient_father_lastname = txtFatherLname.Text;
            ptt.patient_mother_firstname = txtMotherFname.Text;
            ptt.patient_mother_lastname = txtMotherLname.Text;
            ptt.patient_couple_firstname = txtCouFname.Text;
            ptt.patient_couple_lastname = txtCouLname.Text;
            ptt.patient_record_date_time = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd HH:mm:ss");

            ptt.f_sex_id = cboSex.SelectedItem == null ? "" : ((ComboBoxItem)cboSex.SelectedItem).Value;
            ptt.f_patient_marriage_status_id = cboMarital.SelectedItem == null ? "" : ((ComboBoxItem)cboMarital.SelectedItem).Value;
            ptt.f_patient_blood_group_id = cboBloodG.SelectedItem == null ? "" : ((ComboBoxItem)cboBloodG.SelectedItem).Value;
            ptt.f_patient_nation_id = CboNation.SelectedItem == null ? "" : ((ComboBoxItem)CboNation.SelectedItem).Value;
            ptt.f_patient_race_id = cboRace.SelectedItem == null ? "" : ((ComboBoxItem)cboRace.SelectedItem).Value;
            ptt.f_patient_religion_id = cboRg.SelectedItem == null ? "" : ((ComboBoxItem)cboRg.SelectedItem).Value;

            ptt.status_deny_allergy = chkDenyAllergy.Checked == true ? "1" : "0";
            ptt.status_chronic = chkChronic.Checked == true ? "1" : "0";
        }
        private void DoPrint(C1PdfDocumentSource pds)
        {
            if (printDialog1.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                C1PrintOptions po = new C1PrintOptions();
                po.PrinterSettings = printDialog1.PrinterSettings;
                pds.Print(po);
                MessageBox.Show(this, "Document was successfully printed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DoExport(C1PdfDocumentSource pds, ExportProvider ep)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.DefaultExt = "." + ep.DefaultExtension;
            savefile.FileName = Path.GetFileName(filename) + "." + ep.DefaultExtension;
            savefile.Filter = string.Format("{0} (*.{1})|*.{1}|All files (*.*)|*.*", ep.FormatName, ep.DefaultExtension);
            if (savefile.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                var exporter = ep.NewExporter();
                exporter.ShowOptions = false;
                exporter.FileName = savefile.FileName;
                if (exporter.ShowOptionsDialog())
                {
                    pds.Export(exporter);
                    MessageBox.Show(this, "Document was successfully exported.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void createPDFSticker(String txt)
        {
            //C1DocumentSource cPdf = new C1DocumentSource();
            // load long string from resource file
            string text = "Resource not found...";
            //Assembly a = Assembly.GetExecutingAssembly();
            //foreach (string res in a.GetManifestResourceNames())
            //{
            //    if (res.ToLower().IndexOf("flow.txt") > -1)
            //    {
            //        StreamReader sr = new StreamReader(a.GetManifestResourceStream(res));
            //        text = sr.ReadToEnd();
            //    }
            //}
            text = txt;
            text = text.Replace("\t", "   ");
            Image img = barcode.Image;
            //text = string.Format("{0}\r\n\r\n---oOoOoOo---\r\n\r\n{0}", text);

            // create pdf document
            _c1pdf.Clear();
            _c1pdf.DocumentInfo.Title = "";
            sB.Text = "Creating pdf document...";

            // add title
            Font titleFont = new Font("Tahoma", 24, FontStyle.Bold);
            Font bodyFont = new Font("Tahoma", 9);
            RectangleF rcPage = GetPageRect();
            RectangleF rc = RenderParagraph(_c1pdf.DocumentInfo.Title, titleFont, rcPage, rcPage, false);
            rc.Y += titleFont.Size + 6;
            rc.Height = rcPage.Height - rc.Y;

            // create two columns for the text
            RectangleF rcLeft = rc;
            //rcLeft.Width = rcPage.Width / 2 - 12;
            rcLeft.Width = 120;
            rcLeft.Height = 90;
            rcLeft.Y = 60;
            RectangleF rcRight = rcLeft;
            rcRight.X = rcPage.Right - rcRight.Width;

            RectangleF rcMiddle = rcLeft;
            rcMiddle.X = rcPage.Right - rcMiddle.Width - rcMiddle.Width - 55;
            RectangleF rcBarcode = RenderParagraph("", titleFont, rcPage, rcPage, false);
            rcBarcode.Height = 30;
            //rcMiddle.X = 180;
            // start with left column
            //rc = rcLeft;

            // render string spanning columns and pages
            for (int i=1;i<=10 ;i++ )
            {
                // render as much as will fit into the rectangle
                rc.Inflate(-3, -3);
                int nextChar = _c1pdf.DrawString(text, bodyFont, Brushes.Black, rcLeft);
                _c1pdf.DrawImage(img, rcBarcode);
                rc.Inflate(+3, +3);
                _c1pdf.DrawRectangle(Pens.Silver, rcLeft);
                

                _c1pdf.DrawString(text, bodyFont, Brushes.Black, rcMiddle);
                _c1pdf.DrawRectangle(Pens.Silver, rcMiddle);


                _c1pdf.DrawString(text, bodyFont, Brushes.Black, rcRight);
                _c1pdf.DrawRectangle(Pens.Silver, rcRight);

                rcLeft.Y += 120;
                rcMiddle.Y += 120;
                rcRight.Y += 120;
                rcBarcode.Y += 120;
                // break when done
                //if (nextChar >= text.Length)
                //    break;

                // get rid of the part that was rendered
                //text = text.Substring(nextChar);

                // switch to right-side rectangle
                //if (rc.Left == rcLeft.Left)
                //{
                //    rc = rcRight;
                //}
                //else // switch to left-side rectangle on the next page
                //{
                //    _c1pdf.NewPage();
                //    rc = rcLeft;
                //}
            }

            // save and show pdf document
            sB.Text = "Saving pdf document...";
            string fileName = Path.GetDirectoryName(Application.ExecutablePath) + @"\flow.pdf";
            _c1pdf.Save(fileName);
            Thread.Sleep(1000);
            //Process.Start(fileName);
        }
        internal RectangleF GetPageRect()
        {
            RectangleF rcPage = _c1pdf.PageRectangle;
            rcPage.Inflate(-72, -72);
            return rcPage;
        }
        internal RectangleF RenderParagraph(string text, Font font, RectangleF rcPage, RectangleF rc, bool outline, bool linkTarget)
        {
            // if it won't fit this page, do a page break
            rc.Height = _c1pdf.MeasureString(text, font, rc.Width).Height;
            if (rc.Bottom > rcPage.Bottom)
            {
                _c1pdf.NewPage();
                rc.Y = rcPage.Top;
            }

            // draw the string
            _c1pdf.DrawString(text, font, Brushes.Black, rc);

            // show bounds (mainly to check word wrapping)
            //_c1pdf.DrawRectangle(Pens.Sienna, rc);

            // add headings to outline
            if (outline)
            {
                _c1pdf.DrawLine(Pens.Black, rc.X, rc.Y, rc.Right, rc.Y);
                _c1pdf.AddBookmark(text, 0, rc.Y);
            }

            // add link target
            if (linkTarget)
            {
                _c1pdf.AddTarget(text, rc);
            }

            // update rectangle for next time
            rc.Offset(0, rc.Height);
            return rc;
        }
        internal RectangleF RenderParagraph(string text, Font font, RectangleF rcPage, RectangleF rc, bool outline)
        {
            return RenderParagraph(text, font, rcPage, rc, outline, false);
        }
        internal RectangleF RenderParagraph(string text, Font font, RectangleF rcPage, RectangleF rc)
        {
            return RenderParagraph(text, font, rcPage, rc, false, false);
        }
        private void FrmPatientAdd_Load(object sender, EventArgs e)
        {
            tC1.SelectedTab = tabFamily;
        }
    }
}
