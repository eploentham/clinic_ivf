
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
        FtpClient ff1;
        Bitmap img;
        Image image1;

        String filename = "";
        static String filenamepic = "", host="", user="", pass="";
        
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
            
            //theme1.SetTheme(sB, "BeigeOne");
            barcode.BackColor = this.BackColor;

            sB1.Text = "";
            bg = txtPttName.BackColor;
            fc = txtPttName.ForeColor;
            ff = txtPttName.Font;
            ff1 = new FtpClient(ic.iniC.hostFTP, ic.iniC.userFTP, ic.iniC.passFTP);

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
            ic.ivfDB.fpfDB.setCboPrefix(cboPrefix);
            ic.ivfDB.fmsDB.setCboMarriage(cboMarital);
            ic.ivfDB.fbgDB.setCboBloodGroup(cboBloodG);
            ic.ivfDB.fpnDB.setCboNation(CboNation);
            ic.ivfDB.fetDB.setCboEduca(CboEduca);
            ic.ivfDB.frcDB.setCboRace(cboRace);
            ic.ivfDB.frgDB.setCboReligion(cboRg);
<<<<<<< HEAD
            ic.ivfDB.fpDB.setCboPrefix(cboCouPrefix);
            ic.ivfDB.fpDB.setCboPrefix(cboName1Prefix);
            ic.ivfDB.fpDB.setCboPrefix(cboName1Prefix);
=======
            ic.ivfDB.fpfDB.setCboPrefix(cboCouPrefix);
            ic.ivfDB.fpfDB.setCboPrefix(cboName1Prefix);
            ic.ivfDB.fpfDB.setCboPrefix(cboName2Prefix);
>>>>>>> 9ed44180a1f2199164640c36ed21f7a602a68966
            ic.ivfDB.frlDB.setCboRelation(cboCouRel);
            ic.ivfDB.frlDB.setCboRelation(cboName1Rl);
            ic.ivfDB.agnOldDB.setCboAgent(cboAgent);
            ic.ivfDB.sexDB.setCboSex(cboSex);
            ic.setCboPttType(cboPttType);
            ic.setCboPttGroup(cboPttGroup);

            setControl(pttId);
            setFocusColor();

            btnPrnSticker.Click += BtnPrnSticker_Click;
            btnSave.Click += BtnSave_Click;
            btnWebCamOn.Click += BtnWebCamOn_Click;
            btnCapture.Click += BtnCapture_Click;
            this.FormClosed += FrmPatientAdd_FormClosed;
            btnPrvSticker.Click += BtnPrvSticker_Click;
            btnSavePic.Click += BtnSavePic_Click; ;
            setKeyEnter();

            btnCapture.Enabled = false;
            if (ic.iniC.statusAppDonor.Equals("1"))
            {
                txtAgent.Show();
                cboAgent.Hide();
            }
            else
            {
                txtAgent.Hide();
                cboAgent.Show();
            }
            //picPtt.Load("54158.jpg");
            //picPtt.SizeMode = PictureBoxSizeMode.StretchImage;
            //btnSavePic.Enabled = false;
        }

        private void BtnSavePic_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String folder = "";
            folder = DateTime.Now.Year.ToString();
            image1 = picPtt.Image;
            //image1.Save(@"temppic.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            ic.saveFilePatienttoServer(txtHn.Text, image1);
            //ic.ftpC.upload("DefaultDocument.pdf", @"D:\\source\\ivf\\clinic_ivf\\clinic_ivf\\doc\\DefaultDocument.pdf");
        }

        private void setKeyEnter()
        {
            txtPid.KeyUp += TxtPid_KeyUp;
            txtPaasport.KeyUp += TxtPid_KeyUp;
            txtPttName.KeyUp += TxtPid_KeyUp;
            txtPttLName.KeyUp += TxtPid_KeyUp;
            txtDob.KeyUp += TxtPid_KeyUp;
            cboSex.KeyUp += TxtPid_KeyUp;
            cboMarital.KeyUp += TxtPid_KeyUp;
            txtMobile1.KeyUp += TxtPid_KeyUp;
            txtMobile2.KeyUp += TxtPid_KeyUp;
            txtLineID.KeyUp += TxtPid_KeyUp;
            txtRemark.KeyUp += TxtPid_KeyUp;
            cboBloodG.KeyUp += TxtPid_KeyUp;
            CboNation.KeyUp += TxtPid_KeyUp;
            CboEduca.KeyUp += TxtPid_KeyUp;
            cboRace.KeyUp += TxtPid_KeyUp;
            cboRg.KeyUp += TxtPid_KeyUp;
            txtEmail.KeyUp += TxtPid_KeyUp;
            txtFatherFname.KeyUp += TxtPid_KeyUp;
            txtFatherLname.KeyUp += TxtPid_KeyUp;
            txtFatherMobile.KeyUp += TxtPid_KeyUp;
            txtMotherFname.KeyUp += TxtPid_KeyUp;
            txtMotherLname.KeyUp += TxtPid_KeyUp;
            txtMotherMobile.KeyUp += TxtPid_KeyUp;
            txtCouFname.KeyUp += TxtPid_KeyUp;
            txtCouLname.KeyUp += TxtPid_KeyUp;
            txtCouMobile.KeyUp += TxtPid_KeyUp;
            cboName1Prefix.KeyUp += TxtPid_KeyUp;
            txtContFname1.KeyUp += TxtPid_KeyUp;
            txtContLname1.KeyUp += TxtPid_KeyUp;
            txtContMobile1.KeyUp += TxtPid_KeyUp;
            //cboName2Prefix.KeyUp += TxtPid_KeyUp;
            //txtContFname2.KeyUp += TxtPid_KeyUp;
            //txtContLname2.KeyUp += TxtPid_KeyUp;
            //txtContMobile2.KeyUp += TxtPid_KeyUp;
            txtDrugAllergy.KeyUp += TxtPid_KeyUp;
            
        }
        private void TxtPid_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if ((e.KeyCode == Keys.Enter))
            {
                if (sender.Equals(txtPid))
                {
                    txtPaasport.Focus();
                }
                else if (sender.Equals(txtPaasport))
                {
                    txtPttName.Focus();
                }
                else if (sender.Equals(txtPttName))
                {
                    txtPttLName.Focus();
                }
                else if (sender.Equals(txtPttLName))
                {
                    txtDob.Focus();
                }
                else if (sender.Equals(txtDob))
                {
                    cboSex.Focus();
                }
                else if (sender.Equals(cboSex))
                {
                    cboMarital.Focus();
                }
                else if (sender.Equals(cboMarital))
                {
                    txtMobile1.Focus();
                }
                else if (sender.Equals(txtMobile1))
                {
                    txtMobile2.Focus();
                }
                else if (sender.Equals(txtMobile2))
                {
                    txtLineID.Focus();
                }
                else if (sender.Equals(txtLineID))
                {
                    txtRemark.Focus();
                }
                else if (sender.Equals(txtRemark))
                {
                    cboBloodG.Focus();
                }
                else if (sender.Equals(cboBloodG))
                {
                    CboNation.Focus();
                }
                else if (sender.Equals(CboNation))
                {
                    CboEduca.Focus();
                }
                else if (sender.Equals(CboEduca))
                {
                    cboRace.Focus();
                }
                else if (sender.Equals(cboRace))
                {
                    cboRg.Focus();
                }
                else if (sender.Equals(cboRg))
                {
                    txtEmail.Focus();
                }
                else if (sender.Equals(txtEmail))
                {
                    txtFatherFname.Focus();
                }
                else if (sender.Equals(txtFatherFname))
                {
                    txtFatherLname.Focus();
                }
                else if (sender.Equals(txtFatherLname))
                {
                    txtFatherMobile.Focus();
                }
                else if (sender.Equals(txtFatherMobile))
                {
                    txtMotherFname.Focus();
                }
                else if (sender.Equals(txtMotherFname))
                {
                    txtMotherLname.Focus();
                }
                else if (sender.Equals(txtMotherLname))
                {
                    txtMotherMobile.Focus();
                }
                else if (sender.Equals(txtMotherMobile))
                {
                    txtCouFname.Focus();
                }
                else if (sender.Equals(txtCouFname))
                {
                    txtCouLname.Focus();
                }
                else if (sender.Equals(txtCouLname))
                {
                    txtCouMobile.Focus();
                }
                else if (sender.Equals(txtCouMobile))
                {
                    cboName1Prefix.Focus();
                }
                else if (sender.Equals(cboName1Prefix))
                {
                    txtContFname1.Focus();
                }
                else if (sender.Equals(txtContFname1))
                {
                    txtContLname1.Focus();
                }
                else if (sender.Equals(txtContLname1))
                {
                    txtContMobile1.Focus();
                }
                
                //else if (sender.Equals(txtContMobile2))
                //{
                //    txtDrugAllergy.Focus();
                //}
            }
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
                    btnSave.Text = "Save";
                    btnSave.Image = Resources.accept_database24;
                    txtID.Value = re;
                    txtPid.Focus();
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
                    btnSave.Focus();
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
                String age = "";
                age = ptt.AgeStringShort();
                //DateTime dt = txtDob.Text;
                createPDFSticker(txtHn.Text, cboPrefix.Text + " " + txtPttName.Text + " " + txtPttLName.Text + "\n  DOB " + ic.datetoDB(txtDob.Text) + "\n  AGE " + age);
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
                String age = "";
                //DateTime dtB;
                //if(DateTime.TryParse(ptt.patient_birthday,out dtB))
                //{
                //    Age age1 = new Age(dtB);
                //    age = age1.AgeString;
                //}
                age = ptt.AgeStringShort();
                createPDFSticker(txtHn.Text, cboPrefix.Text+" "+ txtPttName.Text+" "+txtPttLName.Text+"\n  DOB "+ ic.datetoDB(txtDob.Text)+"\n  AGE "+ age);
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

            

            this.txtContMobile1.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtContMobile1.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtContFname1.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtContFname1.Enter += new System.EventHandler(this.textBox_Enter);

            

            this.txtContLname1.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtContLname1.Enter += new System.EventHandler(this.textBox_Enter);

            

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
            if (ptt.t_patient_id.Equals(""))
            {
                btnWebCamOn.Enabled = false;
            }
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
            txtAgent.Value = ptt.agent;
            txtDrugAllergy.Value = ptt.patient_drugallergy;
            txtRemark.Value = ptt.remark;
            txtDob.Value = ptt.patient_birthday;
            txtFatherMobile.Value = ptt.patient_father_mobile;
            txtMotherMobile.Value = ptt.patient_mother_mobile;
            txtCouMobile.Value = ptt.patient_couple_mobile;

            ic.setC1Combo(cboPrefix, ptt.f_patient_prefix_id);
            ic.setC1Combo(cboSex, ptt.f_sex_id);
            ic.setC1Combo(cboMarital, ptt.f_patient_marriage_status_id);
            ic.setC1Combo(cboBloodG, ptt.f_patient_blood_group_id);
            ic.setC1Combo(CboNation, ptt.f_patient_nation_id);
            ic.setC1Combo(CboEduca, ptt.f_patient_education_type_id);
            ic.setC1Combo(cboRace, ptt.f_patient_race_id);
            ic.setC1Combo(cboRg, ptt.f_patient_religion_id);
            ic.setC1Combo(cboPttType, ptt.patient_type);
            ic.setC1Combo(cboPttGroup, ptt.patient_group);
            ic.setC1Combo(cboName1Prefix, ptt.patient_contact_f_patient_prefix_id);
            //ic.setC1Combo(cboCouPrefix, ptt.f_patient_religion_id);
            //ic.setC1Combo(cboRg, ptt.f_patient_religion_id);
            //ic.setC1Combo(cboRg, ptt.f_patient_religion_id);
            chkChronic.Checked = ptt.status_chronic.Equals("1") ? true : false;
            chkDenyAllergy.Checked = ptt.status_deny_allergy.Equals("1") ? true : false;
            barcode.Text = txtHn.Text;
            filenamepic = txtHn.Text;
            host = ic.iniC.hostFTP;
            user = ic.iniC.userFTP;
            pass = ic.iniC.passFTP;
            //MemoryStream stream = new MemoryStream();
            //stream = ic.ftpC.download(DateTime.Now.Year.ToString()+"/"+txtHn.Text+"."+ System.Drawing.Imaging.ImageFormat.Jpeg);
            ////image1 = new Image();
            //Bitmap bitmap = new Bitmap(stream);
            ////image1 = bitmap;
            //picPtt.Image = bitmap;
            //picPtt.SizeMode = PictureBoxSizeMode.StretchImage;
            if (ic.iniC.statusAppDonor.Equals("1"))
            {
                txtAgent.Text = ptt.agent;
            }
            else
            {
                ic.setC1Combo(cboAgent, ptt.agent);
            }
            Thread threadA = new Thread(new ParameterizedThreadStart(ExecuteA));
            threadA.Start();
        }
        private void ExecuteA(Object obj)
        {
            //Console.WriteLine("Executing parameterless thread!");
            try
            {
                //MemoryStream stream = new MemoryStream();
                //FtpClient ftp = new FtpClient(host, user, pass);
                //stream = ic.ftpC.download(DateTime.Now.Year.ToString() + "/" + filenamepic + "." + System.Drawing.Imaging.ImageFormat.Jpeg);
                //Bitmap bitmap = new Bitmap(stream);
                //Bitmap bitmap = new Bitmap(ic.ftpC.download(DateTime.Now.Year.ToString() + "/" + filenamepic + "." + System.Drawing.Imaging.ImageFormat.Jpeg));
                //picPtt.Image = bitmap;
                //picPtt.SizeMode = PictureBoxSizeMode.StretchImage;
                //setPic(bitmap);
                setPic(new Bitmap(ic.ftpC.download(DateTime.Now.Year.ToString() + "/" + filenamepic + "." + System.Drawing.Imaging.ImageFormat.Jpeg)));
            }
            catch(Exception ex)
            {

            }
            
        }
        private void setPic(Bitmap bitmap)
        {
            picPtt.Image = bitmap;
            picPtt.SizeMode = PictureBoxSizeMode.StretchImage;
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
            ptt.f_patient_education_type_id = CboEduca.SelectedItem == null ? "" : ((ComboBoxItem)CboEduca.SelectedItem).Value;

            ptt.status_deny_allergy = chkDenyAllergy.Checked == true ? "1" : "0";
            ptt.status_chronic = chkChronic.Checked == true ? "1" : "0";

            ptt.patient_group = cboPttGroup.SelectedItem == null ? "" : ((ComboBoxItem)cboPttGroup.SelectedItem).Value;
            ptt.patient_type = cboPttType.SelectedItem == null ? "" : ((ComboBoxItem)cboPttType.SelectedItem).Value;
            ptt.agent = txtAgent.Text;
            ptt.patient_drugallergy = txtDrugAllergy.Text;
            ptt.patient_father_mobile = txtFatherMobile.Text;
            ptt.patient_mother_mobile = txtMotherMobile.Text;
            ptt.patient_couple_mobile = txtCouMobile.Text;
            ptt.patient_birthday = ic.datetoDB(txtDob.Text);
            ptt.f_patient_prefix_id = cboPrefix.SelectedItem == null ? "" : ((ComboBoxItem)cboPrefix.SelectedItem).Value;
            ptt.patient_contact_f_patient_prefix_id = cboName1Prefix.SelectedItem == null ? "" : ((ComboBoxItem)cboName1Prefix.SelectedItem).Value;

            ptt.patient_firstname_e = txtPttNameE.Text;
            ptt.patient_lastname_e = txtPttLNameE.Text;
            ptt.contract = txtContract.Text;
            ptt.insurance = txtInsurance.Text;
<<<<<<< HEAD
            if (ic.iniC.statusAppDonor.Equals("1"))
            {
                ptt.agent = txtAgent.Text;
            }
            else
            {
                ptt.agent = cboAgent.SelectedItem == null ? "" : ((ComboBoxItem)cboAgent.SelectedItem).Value;
            }
=======
            ptt.patient_contact_firstname = txtContFname1.Text;
            ptt.patient_contact_lastname = txtContLname1.Text;
>>>>>>> 9ed44180a1f2199164640c36ed21f7a602a68966
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
        public void createPDFSticker(String hn, String txt)
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
            Font bodyFontB = new Font("Tahoma", 12);
            RectangleF rcPage = GetPageRect();
            RectangleF rc = RenderParagraph(_c1pdf.DocumentInfo.Title, titleFont, rcPage, rcPage, false);
            rc.Y += titleFont.Size + 6;
            rc.Height = rcPage.Height - rc.Y;

            // create three columns for the text
            RectangleF rcLeft1 = rc;
            int chk = 0;
            //rcLeft.Width = rcPage.Width / 2 - 12;
            rcLeft1.Width = int.TryParse(ic.iniC.sticker_donor_width, out chk) ? chk : 120;
            rcLeft1.Height = int.TryParse(ic.iniC.sticker_donor_height, out chk) ? chk : 90;
            rcLeft1.Y = int.TryParse(ic.iniC.sticker_donor_start_y, out chk) ? chk : 60;
            RectangleF rcRight = rcLeft1;
            rcRight.X = rcPage.Right - rcRight.Width;

            RectangleF rcMiddle = rcLeft1;
            rcMiddle.X = rcPage.Right - rcMiddle.Width - rcMiddle.Width - 55;
            RectangleF rcBarcode1 = RenderParagraph("", titleFont, rcPage, rcPage, false);
            rcBarcode1.Height = int.TryParse(ic.iniC.sticker_donor_barcode_height, out chk) ? chk : 40;
            rcBarcode1.Width = rcLeft1.Width - 10;
            rcBarcode1.X = rcBarcode1.X + (int.TryParse(ic.iniC.sticker_donor_barcode_gap_x, out chk) ? chk : 5);
            rcBarcode1.Y = rcBarcode1.Y + (int.TryParse(ic.iniC.sticker_donor_barcode_gap_y, out chk) ? chk : 30);
            RectangleF rcBarcodeM = rcBarcode1;
            RectangleF rcBarcodeR = rcBarcode1;
            rcBarcodeM.X = rcMiddle.X + (int.TryParse(ic.iniC.sticker_donor_barcode_gap_x, out chk) ? chk : 5);
            rcBarcodeR.X = rcRight.X + (int.TryParse(ic.iniC.sticker_donor_barcode_gap_x, out chk) ? chk : 5);
            //rcMiddle.X = 180;
            // start with left column
            //rc = rcLeft;

            // render string spanning columns and pages
            for (int i=1;i<=10 ;i++)
            {
                // render as much as will fit into the rectangle
                rc.Inflate(-3, -3);
                int nextChar = _c1pdf.DrawString(hn, bodyFontB, Brushes.Black, rcLeft1);
                int nextChar1 = _c1pdf.DrawString("\n"+text, bodyFont, Brushes.Black, rcLeft1);
                _c1pdf.DrawImage(img, rcBarcode1);
                rc.Inflate(+3, +3);
                _c1pdf.DrawRectangle(Pens.Silver, rcLeft1);

                _c1pdf.DrawString(hn, bodyFontB, Brushes.Black, rcMiddle);
                _c1pdf.DrawString("\n" + text, bodyFont, Brushes.Black, rcMiddle);
                _c1pdf.DrawImage(img, rcBarcodeM);
                _c1pdf.DrawRectangle(Pens.Silver, rcMiddle);

                _c1pdf.DrawString(hn, bodyFontB, Brushes.Black, rcRight);
                _c1pdf.DrawString("\n" + text, bodyFont, Brushes.Black, rcRight);
                _c1pdf.DrawImage(img, rcBarcodeR);
                _c1pdf.DrawRectangle(Pens.Silver, rcRight);

                rcLeft1.Y += int.TryParse(ic.iniC.sticker_donor_width, out chk) ? chk : 120;
                rcMiddle.Y += int.TryParse(ic.iniC.sticker_donor_width, out chk) ? chk : 120;
                rcRight.Y += int.TryParse(ic.iniC.sticker_donor_width, out chk) ? chk : 120;
                rcBarcode1.Y += int.TryParse(ic.iniC.sticker_donor_width, out chk) ? chk : 120;
                rcBarcodeM.Y += int.TryParse(ic.iniC.sticker_donor_width, out chk) ? chk : 120;
                rcBarcodeR.Y += int.TryParse(ic.iniC.sticker_donor_width, out chk) ? chk : 120;
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
            if (ic.iniC.statusAppDonor.Equals("1"))
            {
                theme1.SetTheme(sB, ic.theme);
            }
            else
            {
                theme1.SetTheme(sB, "Office2010Red");
            }
            //theme1.SetTheme(splitContainer1, ic.theme);
            //theme1.SetTheme(splitContainer2, ic.theme);
            //theme1.SetTheme(grfDay2, ic.theme);
            //theme1.SetTheme(grfDay2, ic.theme);
            //theme1.SetTheme(grfDay2, ic.theme);
            //theme1.SetTheme(grfDay2, ic.theme);
            //foreach (Control c in groupBox1.Controls)
            //{
            //    theme1.SetTheme(c, ic.theme);
            //}
            //foreach (Control c in gB.Controls)
            //{
            //    theme1.SetTheme(c, ic.theme);
            //}
        }
    }
}
