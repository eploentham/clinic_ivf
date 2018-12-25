
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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
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
        String pttId = "", pttOldId="", vsoldId="", webcamname="";
        Patient ptt;
        PatientOld pttO1;

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;
        int colID = 1, colHn = 2, colImg = 3, colDesc = 4, colDesc2 = 5, colDesc3 = 6, colPathPic = 7, colBtn=8, colStatus=9;
        int colVsID = 1, colVsHn = 2, colVsVisitDate = 3, colVsVisitTime=4, colVsStatus=5;
        int colpApmId = 1, colpApmDate = 2, colpApmTime = 3, colpApmRemark = 4;

        //C1FlexGrid grfDay2, grfDay3, grfDay5, grfDay6;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;

        FilterInfoCollection webcanDevice;
        FtpClient ff1;
        Bitmap img;
        Image image1;
        C1FlexGrid grfImg, grfVs, grfpApm;

        String filename = "", picIDCard="pic_id_card.jpg";
        static String filenamepic = "", host="", user="", pass="";
        Color color;
        Boolean flagImg = false, flagReadCard=false, flagHavOldPttNoPtt=false;
        String _CardReaderTFK2700 = "";
        enum NID_FIELD
        {
            NID_Number,   //1234567890123#

            TITLE_T,    //Thai title#
            NAME_T,     //Thai name#
            MIDNAME_T,  //Thai mid name#
            SURNAME_T,  //Thai surname#

            TITLE_E,    //Eng title#
            NAME_E,     //Eng name#
            MIDNAME_E,  //Eng mid name#
            SURNAME_E,  //Eng surname#

            HOME_NO,    //12/34#
            MOO,        //10#
            TROK,       //ตรอกxxx#
            SOI,        //ซอยxxx#
            ROAD,       //ถนนxxx#
            TUMBON,     //ตำบลxxx#
            AMPHOE,     //อำเภอxxx#
            PROVINCE,   //จังหวัดxxx#

            GENDER,     //1#			//1=male,2=female

            BIRTH_DATE, //25200131#	    //YYYYMMDD 
            ISSUE_PLACE,//xxxxxxx#      //
            ISSUE_DATE, //25580131#     //YYYYMMDD 
            EXPIRY_DATE,//25680130      //YYYYMMDD 
            ISSUE_NUM,  //12345678901234 //14-Char
            END
        };
        RDNID mRDNIDWRAPPER = new RDNID();
        string StartupPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                
        public FrmPatientAdd(IvfControl ic, String pttid, String pttoldid, String vsoldid)
        {
            InitializeComponent();
            this.ic = ic;
            pttId = pttid;
            vsoldId = vsoldid;
            pttOldId = pttoldid;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);
            
            //theme1.SetTheme(sB, "BeigeOne");
            barcode.BackColor = this.BackColor;

            sB1.Text = "";
            bg = txtPttNameE.BackColor;
            fc = txtPttNameE.ForeColor;
            ff = txtPttNameE.Font;
            ff1 = new FtpClient(ic.iniC.hostFTP, ic.iniC.userFTP, ic.iniC.passFTP);

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            ptt = new Patient();
            image1 = null;
            try
            {
                color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
                webcanDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                ic.video = new VideoCaptureDevice();
                foreach (FilterInfo device in webcanDevice)
                {
                    webcamname = device.Name;
                    //video.NewFrame += Video_NewFrame;
                }
                if (File.Exists(picIDCard))
                {
                    File.Delete(picIDCard);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(" no camera Found\n" + ex.Message);
            }

            txtDob.Value = DateTime.Now.ToString("yyyy-MM-dd");
            ic.ivfDB.fpfDB.setCboPrefix(cboPrefix,"");
            ic.ivfDB.fmsDB.setCboMarriage(cboMarital, "");
            ic.ivfDB.fbgDB.setCboBloodGroup(cboBloodG, "");
            ic.ivfDB.fpnDB.setCboNation(CboNation, "");
            ic.ivfDB.fetDB.setCboEduca(CboEduca, "");
            ic.ivfDB.frcDB.setCboRace(cboRace, "");
            ic.ivfDB.frgDB.setCboReligion(cboRg, "");

            ic.ivfDB.fpfDB.setCboPrefix(cboCouPrefix, "");
            ic.ivfDB.fpfDB.setCboPrefix(cboName1Prefix, "");
            ic.ivfDB.fpfDB.setCboPrefix(cboName1Prefix, "");

            ic.ivfDB.fpfDB.setCboPrefix(cboCouPrefix, "");
            ic.ivfDB.fpfDB.setCboPrefix(cboName1Prefix, "");
            ic.ivfDB.crlDB.setCboContractPlans(cboCrl);

            ic.ivfDB.frlDB.setCboRelation(cboCouRel, "");
            ic.ivfDB.frlDB.setCboRelation(cboName1Rl, "");
            ic.ivfDB.agnOldDB.setCboAgent(cboAgent, "");
            //ic.ivfDB.agnOldDB.setCboAgent(comboBox1);
            ic.ivfDB.sexDB.setCboSex(cboSex, "");
            ic.setCboPttType(cboPttType);
            ic.setCboPttGroup(cboPttGroup);

            cboAgent.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboAgent.AutoCompleteMode = AutoCompleteMode.Suggest;

            initGrfpApm();
            setControl();
            setFocusColor();
            initGrfImg();
            setGrfImg();
            initGrfVs();
            setGrfVs();
            
            //setGrfpApmDonor("");

            btnPrnSticker.Click += BtnPrnSticker_Click;
            btnSave.Click += BtnSave_Click;
            btnWebCamOn.Click += BtnWebCamOn_Click;
            btnCapture.Click += BtnCapture_Click;
            this.FormClosed += FrmPatientAdd_FormClosed;
            btnPrvSticker.Click += BtnPrvSticker_Click;
            btnSavePic.Click += BtnSavePic_Click;
            tC1.DoubleClick += TC1_DoubleClick;
            btnVisit.Click += BtnVisit_Click;
            txtHeight.KeyPress += TxtHeight_KeyPress;
            btnVoid.Click += BtnVoid_Click;
            chkOR.CheckedChanged += ChkOR_CheckedChanged;
            chkCongenital.CheckedChanged += ChkCongenital_CheckedChanged;
            chkDenyAllergy.CheckedChanged += ChkDenyAllergy_CheckedChanged;
            btnApm.Click += BtnApm_Click;
            btnSmartcard.Click += BtnSmartcard_Click;

            setKeyEnter();

            btnCapture.Enabled = false;
            cboAgent.Left = txtAgent.Left;
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
            picPtt.SizeMode = PictureBoxSizeMode.StretchImage;
            
            //btnSavePic.Enabled = false;
        }
        public static string GetCurrentExecutingDirectory(System.Reflection.Assembly assembly)
        {
            string filePath = new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).LocalPath;
            return Path.GetDirectoryName(filePath);
        }
        private void BtnSmartcard_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ReadCard();
        }

        private void BtnApm_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmAppointmentDonorAdd frm = new FrmAppointmentDonorAdd(ic, "", txtID.Text, "");
            frm.ShowDialog(this);
            setGrfpApmDonor(txtID.Text);
        }

        private void ChkDenyAllergy_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            txtAllergyDesc.Enabled = chkDenyAllergy.Checked ? true : false;
            txtAllergyDesc.Focus();
        }

        private void ChkCongenital_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            txtCongenital.Enabled = chkCongenital.Checked ? true : false;
            txtCongenital.Focus();
        }

        private void ChkOR_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            txtORDescription.Enabled = chkOR.Checked ? true : false;
            txtORDescription.Focus();
        }

        private void setControlEnable(Boolean flag)
        {
            txtHn.Enabled = flag;
            txtPid.Enabled = flag;
            txtPaasport.Enabled = flag;
            txtPttNameE.Enabled = flag;
            txtPttLNameE.Enabled = flag;
            txtPttName.Enabled = flag;
            txtPttLName.Enabled = flag;
            txtDob.Enabled = flag;
            txtMobile1.Enabled = flag;
            txtMobile2.Enabled = flag;
            txtLineID.Enabled = flag;
            txtRemark.Enabled = flag;
            txtEmail.Enabled = flag;
            txtORDescription.Enabled = flag;
            txtCongenital.Enabled = flag;
            txtNickName.Enabled = flag;
            txtHeight.Enabled = flag;
            txtAgent.Enabled = flag;

            btnSave.Enabled = flag;
            btnEdit.Enabled = flag;
            btnWebCamOn.Enabled = flag;
            btnCapture.Enabled = flag;
            btnSavePic.Enabled = flag;
            btnVoid.Enabled = flag;
            btnPrint.Enabled = flag;

            cboSex.Enabled = flag;
            cboMarital.Enabled = flag;
            cboBloodG.Enabled = flag;
            CboEduca.Enabled = flag;
            CboNation.Enabled = flag;
            cboRace.Enabled = flag;
            cboCouRel.Enabled = flag;
            cboRg.Enabled = flag;
            cboPttType.Enabled = flag;
            cboPttGroup.Enabled = flag;
            cboAgent.Enabled = flag;

            chkOPU.Enabled = flag;
            chkOR.Enabled = flag;
            chkCongenital.Enabled = flag;
            chkDenyAllergy.Enabled = flag;
            chkChronic.Enabled = flag;
        }
        private void BtnVoid_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (btnVoid.Text.Equals("Confirm"))
            {
                stt.Hide();
                setPatient();
                btnVoid.Text = "Void";
                //String re = ic.ivfDB.pttDB.insertPatient(ptt, txtStfConfirmID.Text);
                if (ic.iniC.statusAppDonor.Equals("1"))
                {
                    String re = ic.ivfDB.pttDB.VoidPatient(txtID.Text, txtStfConfirmID.Text);
                    int chk = 0;
                    Patient ptt1 = new Patient();
                    if (re.Equals("1")) // ตอน update
                    {
                        //re = txtID.Text;
                        setControlEnable(false);
                    }
                }
                else
                {
                    //String re = ic.ivfDB.pttOldDB.insertPatientOld(ptt, txtStfConfirmID.Text);
                    //int chk = 0;
                    //if (int.TryParse(re, out chk))
                    //{
                        
                    //}
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
                    btnVoid.Text = "Confirm";
                    //btnSave.Image = Resources.Add_ticket_24;
                    stt.Show("<p><b>สวัสดี</b></p>คุณ " + ic.cStf.staff_fname_t + " " + ic.cStf.staff_lname_t + "<br> กรุณายินยันการ confirm อีกครั้ง", btnWebCamOn);
                    btnVoid.Focus();
                }
                else
                {
                    btnVoid.Text = "Void";
                    //btnSave.Image = Resources.download_database24;
                }
            }
        }

        private void TxtHeight_KeyPress(object sender, KeyPressEventArgs e)
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
        }

        private void BtnVisit_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmVisitAdd frm = new FrmVisitAdd(ic, txtID.Text, "", txtIdOld.Text);
            try
            {
                frm.ShowDialog(this);
            }
            catch(Exception ex)
            {

            }
            
            setGrfVs();
        }

        private void TC1_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if(tC1.SelectedTab == tabImage)
            {
                //MessageBox.Show("aaa", "");
                //OpenFileDialog ofd = new OpenFileDialog();
                //ofd.Filter = "Images (*.BMP;*.JPG;*.Jepg;*.Png;*.GIF)|*.BMP;*.JPG;*.Jepg;*.Png;*.GIF|Pdf Files|*.pdf|All files (*.*)|*.*";
                //ofd.Multiselect = true;
                //ofd.Title = "My Image Browser";
                //DialogResult dr = ofd.ShowDialog();
                //if (dr == System.Windows.Forms.DialogResult.OK)
                //{
                //    //FrmPatientUpPic frm = new FrmPatientUpPic(ofd.FileNames);
                //    //frm.ShowDialog(this);

                //    // Read the files

                //    //Row row1 = grfImg.Rows.Add();
                //    //CellRange rg1 = grfImg.GetCellRange(grfImg.Rows.Count-1, colImg);
                //    int i = 1;
                //    grfImg.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictRows;
                //    grfImg.Cols[colImg].AllowMerging = true;
                //    //cc.Image
                //    Column col = grfImg.Cols[colImg];
                //    col.DataType = typeof(Image);
                //    foreach (String file in ofd.FileNames)
                //    {
                //        // Create a PictureBox.
                //        try
                //        {
                //            Image loadedImage, resizedImage;
                //            String[] sur = file.Split('.');
                //            String ex = "";
                //            if (sur.Length == 2)
                //            {
                //                ex = sur[1];
                //            }
                //            if (!ex.Equals("pdf"))
                //            {
                //                loadedImage = Image.FromFile(file);
                //                int originalWidth = loadedImage.Width;
                //                int newWidth = 180;
                //                resizedImage = loadedImage.GetThumbnailImage(newWidth, (newWidth * loadedImage.Height) / originalWidth, null, IntPtr.Zero);
                //            }
                //            else
                //            {
                //                resizedImage = Resources.pdf_symbol_80_2;
                //            }
                //            grfImg.Cols[colImg].ImageAndText = true;
                //            Row row1 = grfImg.Rows.Add();
                //            int row = grfImg.Rows.Count;

                //            int hei = grfImg.Rows.DefaultSize;
                //            //grfImg.Rows[row-1].Height = hei*6;
                //            CellRange rg1 = grfImg.GetCellRange(row - 1, colImg);

                //            //PictureBox pb = new PictureBox();                            

                //            grfImg[row - 1, colPathPic] = file;
                //            grfImg[row - 1, colBtn] = "send";

                //            grfImg[row - 1, colImg] = resizedImage;

                //            i++;
                //        }
                //        catch (SecurityException ex)
                //        {
                //            // The user lacks appropriate permissions to read files, discover paths, etc.
                //            MessageBox.Show("Security error. Please contact your administrator for details.\n\n" +
                //                "Error message: " + ex.Message + "\n\n" +
                //                "Details (send to Support):\n\n" + ex.StackTrace
                //            );
                //        }
                //        catch (Exception ex)
                //        {
                //            // Could not load the image - probably related to Windows file system permissions.
                //            MessageBox.Show("Cannot display the image: " + file.Substring(file.LastIndexOf('\\'))
                //                + ". You may not have permission to read the file, or " +
                //                "it may be corrupt.\n\nReported error: " + ex.Message);
                //        }
                //    }
                //    grfImg.AutoSizeCols();
                //    grfImg.AutoSizeRows();
                //}
                //grfImg.Cols[colDesc].Visible = true;
                //grfImg.Cols[colDesc2].Visible = false;
                //grfImg.Cols[colDesc3].Visible = false;
                //grfImg.Cols[colHn].Visible = false;
                //grfImg.Cols[colPathPic].Visible = true;
                //grfImg.Cols[colBtn].Visible = false;
                grfImg.AutoSizeCols();
                grfImg.AutoSizeRows();
            }
        }

        private void BtnSavePic_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String folder = "";
            folder = DateTime.Now.Year.ToString();
            image1 = picPtt.Image;
            //image1.Save(@"temppic.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            ic.savePicPatienttoServer(txtIdOld.Text, image1);
            //ic.ftpC.upload("DefaultDocument.pdf", @"D:\\source\\ivf\\clinic_ivf\\clinic_ivf\\doc\\DefaultDocument.pdf");
        }

        private void setKeyEnter()
        {
            txtPid.KeyUp += TxtPid_KeyUp;
            txtPaasport.KeyUp += TxtPid_KeyUp;
            txtPttNameE.KeyUp += TxtPid_KeyUp;
            txtPttLNameE.KeyUp += TxtPid_KeyUp;
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
                    txtPttNameE.Focus();
                }
                else if (sender.Equals(txtPttNameE))
                {
                    txtPttLNameE.Focus();
                }
                else if (sender.Equals(txtPttLNameE))
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
                    CboEduca.Focus();
                }
                else if (sender.Equals(CboNation))
                {
                    cboRace.Focus();
                }
                else if (sender.Equals(CboEduca))
                {
                    CboNation.Focus();
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
                    cboCouPrefix.Focus();
                }
                else if (sender.Equals(cboCouPrefix))
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
                    cboCouRel.Focus();
                }
                else if (sender.Equals(cboCouRel))
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
                else if (sender.Equals(txtContMobile1))
                {
                    cboName1Rl.Focus();
                }
                else if (sender.Equals(cboName1Rl))
                {
                    txtDrugAllergy.Focus();
                }
                else if (sender.Equals(txtDrugAllergy))
                {
                    txtContract.Focus();
                }
                else if (sender.Equals(cboCrl))
                {
                    txtEmerContact.Focus();
                }
                else if (sender.Equals(txtContract))
                {
                    txtInsurance.Focus();
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
                //String re = ic.ivfDB.pttDB.insertPatient(ptt, txtStfConfirmID.Text);
                if (ic.iniC.statusAppDonor.Equals("1"))
                {
                    String re = ic.ivfDB.pttDB.insertPatient(ptt, txtStfConfirmID.Text);
                    long chk = 0;
                    Patient ptt1 = new Patient();
                    if (re.Equals("1")) // ตอน update
                    {
                        re = txtID.Text;
                    }
                    if (flagReadCard)
                    {
                        PatientImage ptti = new PatientImage();
                        ptti.patient_image_id = "";
                        ptti.t_patient_id = re;
                        ptti.t_visit_id = "";
                        ptti.desc1 = "รูป ภาพถ่ายจากบัตรประชาชน";
                        ptti.desc2 = "";
                        ptti.desc3 = "";
                        ptti.desc4 = "";
                        ptti.active = "1";
                        ptti.remark = "";
                        ptti.date_create = "";
                        ptti.date_modi = "";
                        ptti.date_cancel = "";
                        ptti.user_create = "";
                        ptti.user_modi = "";
                        ptti.user_cancel = "";
                        ptti.image_path = "images/" + txtHn.Text.Replace("-", "") + "/" + picIDCard;
                        ptti.status_image = "4";
                        String rere = ic.ivfDB.pttImgDB.insertpatientImage(ptti, ic.cStf.staff_id);
                        //long chk = 0;
                        if (long.TryParse(rere, out chk))
                        {
                            filename = picIDCard;
                            ic.savePicOPUtoServer(txtHn.Text.Replace("-", ""), filename, picIDCard);
                            grfImg.Rows[grfImg.Row].StyleNew.BackColor = color;
                            setGrfImg();
                            if (File.Exists(picIDCard))
                            {
                                File.Delete(picIDCard);
                            }
                        }
                        flagReadCard = false;
                    }
                    ptt1 = ic.ivfDB.pttDB.selectByPk1(re);
                    txtID.Value = re;
                    txtPid.Focus();
                    txtHn.Value = ptt1.patient_hn;
                    barcode.Text = txtHn.Text;
                    btnSave.Text = "Save";
                    btnSave.Image = Resources.accept_database24;
                }
                else
                {
                    ptt.t_patient_id_old = txtIdOld.Text;
                    String[] name = txtEmerContact.Text.Split(' ');
                    if (name.Length > 0)
                    {
                        ptt.patient_contact_firstname = name[0];
                        ptt.patient_contact_lastname = name[1];
                    }

                    String re = ic.ivfDB.pttOldDB.insertPatientOld(ptt, txtStfConfirmID.Text);
                    long chk = 0;
                    if (long.TryParse(re, out chk))
                    {
                        if (re.Equals("1")) // ตอน update
                        {
                            re = ptt.t_patient_id_old;
                        }
                        if (!ic.iniC.statusAppDonor.Equals("1"))
                        {
                            //String re1 = ic.ivfDB.pttOldDB.insertPatientOld(ptt, txtStfConfirmID.Text);
                            String re1 = ic.ivfDB.pttDB.insertPatient(ptt, txtStfConfirmID.Text);
                            if (long.TryParse(re1, out chk))
                            {
                                if (re1.Equals("1")) // ตอน update
                                {
                                    re1 = txtID.Text;
                                }
                                
                                if (flagReadCard)
                                {
                                    PatientImage ptti = new PatientImage();
                                    ptti.patient_image_id = "";
                                    ptti.t_patient_id = re1;
                                    ptti.t_visit_id = "";
                                    ptti.desc1 = "รูป ภาพถ่ายจากบัตรประชาชน";
                                    ptti.desc2 = "";
                                    ptti.desc3 = "";
                                    ptti.desc4 = "";
                                    ptti.active = "1";
                                    ptti.remark = "";
                                    ptti.date_create = "";
                                    ptti.date_modi = "";
                                    ptti.date_cancel = "";
                                    ptti.user_create = "";
                                    ptti.user_modi = "";
                                    ptti.user_cancel = "";
                                    ptti.image_path = "images/" + txtHn.Text.Replace("-", "") + "/" + picIDCard;
                                    ptti.status_image = "4";
                                    re = ic.ivfDB.pttImgDB.insertpatientImage(ptti, ic.cStf.staff_id);
                                    //long chk = 0;
                                    if (long.TryParse(re, out chk))
                                    {
                                        ic.savePicOPUtoServer(txtHn.Text.Replace("-", ""), filename, picIDCard);
                                        grfImg.Rows[grfImg.Row].StyleNew.BackColor = color;
                                        setGrfImg();
                                        if (File.Exists(picIDCard))
                                        {
                                            File.Delete(picIDCard);
                                        }
                                    }
                                    flagReadCard = false;
                                }

                                PatientOld pttOld = new PatientOld();
                                pttOld = ic.ivfDB.pttOldDB.selectByPk1(re);
                                String re2 = ic.ivfDB.pttDB.updatePID(re1, re, pttOld.PIDS);
                                if (long.TryParse(re2, out chk))
                                {
                                    btnSave.Text = "Save";
                                    btnSave.Image = Resources.accept_database24;
                                    txtID.Value = re;
                                    txtPid.Focus();
                                    txtHn.Value = pttOld.PIDS;
                                    barcode.Text = txtHn.Text;
                                    if(tabVisit.Enabled == false)
                                    {
                                        tabVisit.Enabled = true;
                                        flagHavOldPttNoPtt = false;
                                    }
                                }
                                
                            }
                        }
                        //System.Threading.Thread.Sleep(2000);
                        //this.Dispose();
                    }
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
                DateTime dt = new DateTime();
                dt = (DateTime)txtDob.Value;
                age = ptt.AgeStringShort();
                //DateTime dt = txtDob.Text;
                //createPDFSticker(txtHn.Text, cboPrefix.Text + " " + txtPttNameE.Text + " " + txtPttLNameE.Text + "\n  DOB " + ic.datetoDB(txtDob.Text) + "\n  AGE " + age);
                createPDFSticker(txtHn.Text, cboPrefix.Text + " " + txtPttNameE.Text + " " + txtPttLNameE.Text + "\n  DOB " + dt.ToString("dd-MM-yyyy") + "\n  AGE " + age);
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
                createPDFSticker(txtHn.Text, cboPrefix.Text+" "+ txtPttNameE.Text+" "+txtPttLNameE.Text+"\n  DOB "+ ic.datetoDB(txtDob.Text)+"\n  AGE "+ age);
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

            this.txtPttNameE.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtPttNameE.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtPttLNameE.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtPttLNameE.Enter += new System.EventHandler(this.textBox_Enter);

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

            this.txtFatherMobile.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtFatherMobile.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtMotherFname.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtMotherFname.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtMotherLname.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtMotherLname.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtMotherMobile.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtMotherMobile.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtCouFname.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtCouFname.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtCouLname.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtCouLname.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtCouMobile.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtCouMobile.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtContMobile1.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtContMobile1.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtContFname1.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtContFname1.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtContLname1.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtContLname1.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtDrugAllergy.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtDrugAllergy.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtContract.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtContract.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtInsurance.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtInsurance.Enter += new System.EventHandler(this.textBox_Enter);

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

            this.cboCrl.Leave += new System.EventHandler(this.textBox_Leave);
            this.cboCrl.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtInsurance.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtInsurance.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtORDescription.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtORDescription.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtCongenital.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtCongenital.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtAllergyDesc.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtAllergyDesc.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtNickName.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtNickName.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtHeight.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtHeight.Enter += new System.EventHandler(this.textBox_Enter);

            //this.txtRemark.Leave += new System.EventHandler(this.textBox_Leave);
            //this.txtRemark.Enter += new System.EventHandler(this.textBox_Enter);

            //this.txtAgent.Leave += new System.EventHandler(this.textBox_Leave);
            //this.txtAgent.Enter += new System.EventHandler(this.textBox_Enter);

            //this.txtHeight.Leave += new System.EventHandler(this.textBox_Leave);
            //this.txtHeight.Enter += new System.EventHandler(this.textBox_Enter);
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
        private void initGrfImg()
        {
            grfImg = new C1FlexGrid();
            grfImg.Font = fEdit;
            grfImg.Dock = System.Windows.Forms.DockStyle.Fill;
            grfImg.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            grfImg.AfterRowColChange += GrfImg_AfterRowColChange;
            grfImg.MouseDown += GrfImg_MouseDown;
            grfImg.DoubleClick += GrfImg_DoubleClick;
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("Upload รูปบัตรประชาชน", new EventHandler(ContextMenu_grfimg_upload_ptt));
            menuGw.MenuItems.Add("Upload สำเนาบัตรประชาชน ที่มีลายเซ็น", new EventHandler(ContextMenu_grfimg_upload_ptt));
            menuGw.MenuItems.Add("Upload รูป Passport", new EventHandler(ContextMenu_grfimg_upload_ptt));
            menuGw.MenuItems.Add("ยกเลิก", new EventHandler(ContextMenu_grfimg_Cancel));
            grfImg.ContextMenu = menuGw;
            pnImage.Controls.Add(grfImg);

            theme1.SetTheme(grfImg, "Office2016Colorful");

        }
        private void ContextMenu_grfimg_upload_ptt(object sender, System.EventArgs e)
        {
            if (grfImg.Row < 0) return;
            
            String pathfile1 = grfImg[grfImg.Row, colPathPic] != null ? grfImg[grfImg.Row, colPathPic].ToString() : "";
            if (pathfile1.Length > 0)
            {
                MessageBox.Show("มีรูปภาพ อยู่แล้ว กรุณา ยกเลิก ก่อน Upload รูปใหม่ ", "");
                return;
            }

            if (MessageBox.Show("ต้องการ Upload image to server ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Images (*.BMP;*.JPG;*.Jepg;*.Png;*.GIF)|*.BMP;*.JPG;*.Jepg;*.Png;*.GIF|Pdf Files|*.pdf|All files (*.*)|*.*";
                ofd.Multiselect = false;
                ofd.Title = "My Image Browser";
                DialogResult dr = ofd.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    String id = grfImg[grfImg.Row, colID] != null ? grfImg[grfImg.Row, colID].ToString(): "";
                    String pathfile = ofd.FileName;
                    String desc = grfImg[grfImg.Row, colDesc] != null ? grfImg[grfImg.Row, colDesc].ToString() : "";
                    String no = grfImg[grfImg.Row, colHn] != null ? grfImg[grfImg.Row, colHn].ToString() : "";
                    if (pathfile.Length > 0)
                    {
                        ic.cStf.staff_id = "";
                        FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                        frm.ShowDialog(this);
                        if (!ic.cStf.staff_id.Equals(""))
                        {
                            String filename = "", re = "", status="";
                            String[] ext = pathfile.Split('.');
                            if (ext.Length > 1)
                            {
                                MenuItem aa = (MenuItem)sender;
                                status = aa.Text.Equals("Upload รูปบัตรประชาชน") ? "1" : aa.Text.Equals("Upload สำเนาบัตรประชาชน ที่มีลายเซ็น") ? "2" : aa.Text.Equals("Upload รูป Passport") ? "3" : "";
                                filename =  txtHn.Text.Replace("-", "") + "_"+ status + "." + ext[ext.Length - 1];
                                PatientImage ptti = new PatientImage();
                                ptti.patient_image_id = id;
                                ptti.t_patient_id = txtID.Text;
                                ptti.t_visit_id = "";
                                ptti.desc1 = desc;
                                ptti.desc2 = "";
                                ptti.desc3 = "";
                                ptti.desc4 = "";
                                ptti.active = "1";
                                ptti.remark = "";
                                ptti.date_create = "";
                                ptti.date_modi = "";
                                ptti.date_cancel = "";
                                ptti.user_create = "";
                                ptti.user_modi = "";
                                ptti.user_cancel = "";
                                ptti.image_path = "images/" + txtHn.Text.Replace("-", "") + "/" + filename;
                                ptti.status_image = "1";
                                re = ic.ivfDB.pttImgDB.insertpatientImage(ptti, ic.cStf.staff_id);
                                long chk = 0;
                                if (long.TryParse(re, out chk))
                                {
                                    ic.savePicOPUtoServer(txtHn.Text.Replace("-",""), filename, pathfile);
                                    grfImg.Rows[grfImg.Row].StyleNew.BackColor = color;
                                    setGrfImg();
                                }
                            }
                        }
                    }
                }
            }
        }
        private void ContextMenu_grfimg_Cancel(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("ต้องการ ยกเลิก ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                String id = grfImg[grfImg.Row, colID].ToString();
                ic.cStf.staff_id = "";
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    String pathfile = grfImg[grfImg.Row, colPathPic].ToString();
                    String re = ic.ivfDB.opuEmDevDB.updatePathPic(id, "", "", "", ic.user.staff_id);
                    ic.delPicOPUtoServer(txtHn.Text.Replace("-", ""), pathfile);
                }
            }
        }
        private void GrfImg_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfImg.Row < 0) return;
            if (grfImg.Col == colImg)
            {
                //MessageBox.Show("a "+grfImg[grfImg.Row, colImg].ToString(), "");
                int row = 0;
                //int.TryParse(grfImg[grfImg.Row, colImg].ToString(), out row);
                int.TryParse(grfImg.Row.ToString(), out row);
                //row *= 4;
                FrmShowImage frm = new FrmShowImage(ic, grfImg[row, colID] !=null? grfImg[row, colID].ToString():"", pttOldId,grfImg[row, colPathPic].ToString(), FrmShowImage.statusModule.Patient);
                frm.ShowDialog(this);
            }
        }

        private void GrfImg_MouseDown(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
            if (grfImg.MouseCol < 0) return;
            if (grfImg.Cols[grfImg.MouseCol].Editor is Button)
            {
                //Current cell enters in edit mode, and button is clicked
                SendKeys.Send("{ENTER}");
                SendKeys.Send("{ENTER}");
            }
        }
        private void BtnEditor_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(String.Format("Button clicked in - Row : {0}, column : {1}.", grfImg.MouseRow.ToString(), grfImg.MouseCol.ToString()));
        }
        private void GrfImg_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;
        }
        private void setGrfImg()
        {
            grfImg.Clear();
            grfImg.DataSource = null;
            grfImg.Rows.Count = 2;
            grfImg.Cols.Count = 10;
            DataTable dt = new DataTable();
            dt = ic.ivfDB.pttImgDB.selectByPttID(pttId);
            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            //grfCu.Rows.Count = 41;
            //grfCu.Cols.Count = 4;
            C1TextBox txt = new C1TextBox();
            Button btn = new Button();
            btn.BackColor = Color.Gray;
            btn.Click += BtnEditor_Click;
            PictureBox img = new PictureBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfImg.Cols[colHn].Editor = txt;
            grfImg.Cols[colDesc].Editor = txt;
            grfImg.Cols[colDesc2].Editor = txt;
            grfImg.Cols[colDesc3].Editor = txt;
            grfImg.Cols[colBtn].Editor = btn;
            grfImg.Cols[colImg].Editor = img;

            grfImg.Cols[colHn].Width = 250;
            grfImg.Cols[colImg].Width = 100;
            grfImg.Cols[colDesc].Width = 100;
            grfImg.Cols[colDesc2].Width = 100;
            grfImg.Cols[colDesc3].Width = 100;
            grfImg.Cols[colBtn].Width = 50;
            grfImg.Cols[colPathPic].Width = 100;

            grfImg.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfImg.Cols[colHn].Caption = "HN";
            grfImg.Cols[colDesc].Caption = "Desc1";
            grfImg.Cols[colDesc2].Caption = "Desc2";
            grfImg.Cols[colDesc3].Caption = "Desc3";
            grfImg.Cols[colBtn].Caption = "send";

            //Hashtable ht = new Hashtable();
            //foreach (DataRow dr in dt.Rows)
            //{
            //    ht.Add(dr["CategoryID"], LoadImage(dr["Picture"] as byte[]));
            //}
            //grfImg.Cols[colImg].ImageMap = ht;
            grfImg.Cols[colImg].ImageAndText = false;

            //ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข Patient", new EventHandler(ContextMenu_edit));
            //grfImg.ContextMenu = menuGw;

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                i++;
                Row row1 = grfImg.Rows.Add();
                row1[colID] = row[ic.ivfDB.pttImgDB.pttI.patient_image_id].ToString();
                row1[colDesc] = row[ic.ivfDB.pttImgDB.pttI.desc1].ToString();
                row1[colPathPic] = row[ic.ivfDB.pttImgDB.pttI.image_path].ToString();
                row1[colStatus] = row[ic.ivfDB.pttImgDB.pttI.status_image].ToString();
                grfImg[i, 0] = i;
                if (row[ic.ivfDB.pttImgDB.pttI.image_path] != null && !row[ic.ivfDB.pttImgDB.pttI.image_path].ToString().Equals(""))
                {
                    int ii = i;
                    new Thread(() =>
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
                            ftpRequest.UsePassive = false;
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
                        grfImg.Cols[colImg].ImageAndText = true;
                        if (loadedImage != null)
                        {
                            int originalWidth = loadedImage.Width;
                            int newWidth = 180;
                            resizedImage = loadedImage.GetThumbnailImage(newWidth, (newWidth * loadedImage.Height) / originalWidth, null, IntPtr.Zero);
                            Column col = grfImg.Cols[colImg];
                            col.DataType = typeof(Image);
                            row1[colImg] = resizedImage;
                            flagImg = true;
                        }
                    }).Start();
                }
                //if (i % 2 == 0)
                    //grfPtt.Rows[i].StyleNew.BackColor = color;
            }
            grfImg.Cols[colID].Visible = false;
            //grfImg.Cols[colPathPic].Visible = false;
            grfImg.Cols[colImg].AllowEditing = false;
            grfImg.AutoSizeCols();
            grfImg.AutoSizeRows();
            theme1.SetTheme(grfImg, "Office2016Colorful");

        }
        private void ContextMenu_edit(object sender, System.EventArgs e)
        {
            String chk = "", name = "", id = "";
            //id = grfPtt[grfPtt.Row, colPttId] != null ? grfPtt[grfPtt.Row, colPttId].ToString() : "";
            //chk = grfPtt[grfPtt.Row, colPttHn] != null ? grfPtt[grfPtt.Row, colPttHn].ToString() : "";
            //name = grfPtt[grfPtt.Row, colPttName] != null ? grfPtt[grfPtt.Row, colPttName].ToString() : "";
            //if (MessageBox.Show("ต้องการ แก้ไข Patient  \n  hn number " + chk + " \n name " + name, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            //grfReq.Rows.Remove(grfReq.Row);
            //openPatientAdd(id, name);
            //}
        }
        static Image LoadImage(byte[] picData)
        {
            // make sure this is an embedded object
            const int bmData = 78;
            if (picData == null || picData.Length < bmData + 2) return null;
            if (picData[0] != 0x15 || picData[1] != 0x1c) return null;

            // we only handle bitmaps for now
            if (picData[bmData] != 'B' || picData[bmData + 1] != 'M') return null;

            // load the picture
            Image img = null;
            try
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream(picData, bmData, picData.Length - bmData);
                img = Image.FromStream(ms);
            }
            catch { }

            // return what we got
            return img;
        }
        private void initGrfVs()
        {
            grfVs = new C1FlexGrid();
            grfVs.Font = fEdit;
            grfVs.Dock = System.Windows.Forms.DockStyle.Fill;
            grfVs.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            grfVs.AfterRowColChange += GrfImg_AfterRowColChange;
            grfVs.MouseDown += GrfImg_MouseDown;
            grfVs.DoubleClick += GrfImg_DoubleClick;
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfVs.ContextMenu = menuGw;
            pnVisit.Controls.Add(grfVs);

            theme1.SetTheme(grfVs, "Office2016DarkGray");

        }
        private void setGrfVs()
        {
            if (ic.iniC.statusAppDonor.Equals("1"))
            {
                setGrfVsDonor(txtHn.Text);
            }
            else
            {
                setGrfVs(txtHn.Text);
            }
        }
        private void setGrfVsDonor(String search)
        {
            grfVs.Clear();
            grfVs.Rows.Count = 1;
            grfVs.Cols.Count = 6;
            DataTable dt = ic.ivfDB.vsDB.selectByHN(search);

            grfVs.Rows.Count = dt.Rows.Count + 1;
            //grfCu.Rows.Count = 41;
            //grfCu.Cols.Count = 4;
            C1TextBox txt = new C1TextBox();
            //Button btn = new Button();
            //btn.BackColor = Color.Gray;
            //btn.Click += BtnEditor_Click;
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfVs.Cols[colVsID].Editor = txt;
            grfVs.Cols[colVsHn].Editor = txt;
            grfVs.Cols[colVsVisitDate].Editor = txt;
            grfVs.Cols[colVsVisitTime].Editor = txt;
            //grfImg.Cols[colBtn].Editor = btn;

            grfVs.Cols[colVsID].Width = 250;
            grfVs.Cols[colVsHn].Width = 100;
            grfVs.Cols[colVsVisitDate].Width = 100;
            grfVs.Cols[colVsVisitTime].Width = 100;
            grfVs.Cols[colVsStatus].Width = 250;
            //grfImg.Cols[colBtn].Width = 50;
            //grfImg.Cols[colPathPic].Width = 100;

            grfVs.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfVs.Cols[colVsID].Caption = "VN";
            grfVs.Cols[colVsHn].Caption = "HN";
            grfVs.Cols[colVsVisitDate].Caption = "visit date";
            grfVs.Cols[colVsVisitTime].Caption = "visit time";
            grfVs.Cols[colVsStatus].Caption = "Status";

            //Hashtable ht = new Hashtable();
            //foreach (DataRow dr in dt.Rows)
            //{
            //    ht.Add(dr["CategoryID"], LoadImage(dr["Picture"] as byte[]));
            //}
            //grfImg.Cols[colImg].ImageMap = ht;
            //grfVs.Cols[colImg].ImageAndText = false;

            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("&แก้ไข Patient", new EventHandler(ContextMenu_edit));
            grfVs.ContextMenu = menuGw;

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                grfVs[i, colVsID] = row[ic.ivfDB.vsOldDB.vsold.VN].ToString();
                grfVs[i, colVsHn] = row[ic.ivfDB.vsOldDB.vsold.PIDS].ToString();
                grfVs[i, colVsVisitDate] = ic.datetoShow(row[ic.ivfDB.vsOldDB.vsold.VDate]);
                grfVs[i, colVsVisitTime] = row[ic.ivfDB.vsOldDB.vsold.VStartTime].ToString();
                grfVs[i, colVsStatus] = row["VName"].ToString();
                grfVs[i, 0] = i;
                i++;
                //if (i % 2 == 0)
                //grfPtt.Rows[i].StyleNew.BackColor = color;
            }
            //grfVs.Cols[colID].Visible = false;
            //grfImg.Cols[colPathPic].Visible = false;
            grfVs.Cols[colImg].AllowEditing = false;
            grfVs.AutoSizeCols();
            grfVs.AutoSizeRows();
            theme1.SetTheme(grfImg, "Office2016DarkGray");
        }
        private void setGrfVs(String search)
        {
            grfVs.Clear();
            grfVs.Rows.Count = 1;
            grfVs.Cols.Count = 6;
            DataTable dt = ic.ivfDB.vsOldDB.selectByHN(search);

            grfVs.Rows.Count = dt.Rows.Count + 1;
            //grfCu.Rows.Count = 41;
            //grfCu.Cols.Count = 4;
            C1TextBox txt = new C1TextBox();
            //Button btn = new Button();
            //btn.BackColor = Color.Gray;
            //btn.Click += BtnEditor_Click;
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfVs.Cols[colVsID].Editor = txt;
            grfVs.Cols[colVsHn].Editor = txt;
            grfVs.Cols[colVsVisitDate].Editor = txt;
            grfVs.Cols[colVsVisitTime].Editor = txt;
            //grfImg.Cols[colBtn].Editor = btn;

            grfVs.Cols[colVsID].Width = 250;
            grfVs.Cols[colVsHn].Width = 100;
            grfVs.Cols[colVsVisitDate].Width = 100;
            grfVs.Cols[colVsVisitTime].Width = 100;
            grfVs.Cols[colVsStatus].Width = 250;
            //grfImg.Cols[colBtn].Width = 50;
            //grfImg.Cols[colPathPic].Width = 100;

            grfVs.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfVs.Cols[colVsID].Caption = "VN";
            grfVs.Cols[colVsHn].Caption = "HN";
            grfVs.Cols[colVsVisitDate].Caption = "visit date";
            grfVs.Cols[colVsVisitTime].Caption = "visit time";
            grfVs.Cols[colVsStatus].Caption = "Status";

            //Hashtable ht = new Hashtable();
            //foreach (DataRow dr in dt.Rows)
            //{
            //    ht.Add(dr["CategoryID"], LoadImage(dr["Picture"] as byte[]));
            //}
            //grfImg.Cols[colImg].ImageMap = ht;
            //grfVs.Cols[colImg].ImageAndText = false;

            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("&แก้ไข Patient", new EventHandler(ContextMenu_edit));
            grfVs.ContextMenu = menuGw;

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            foreach(DataRow row in dt.Rows)
            {
                grfVs[i, colVsID] = row[ic.ivfDB.vsOldDB.vsold.VN].ToString();
                grfVs[i, colVsHn] = row[ic.ivfDB.vsOldDB.vsold.PIDS].ToString();
                grfVs[i, colVsVisitDate] = ic.datetoShow(row[ic.ivfDB.vsOldDB.vsold.VDate]);
                grfVs[i, colVsVisitTime] = row[ic.ivfDB.vsOldDB.vsold.VStartTime].ToString();
                grfVs[i, colVsStatus] = row["VName"].ToString();
                grfVs[i, 0] = i;
                i++;
                //if (i % 2 == 0)
                //grfPtt.Rows[i].StyleNew.BackColor = color;
            }
            //grfVs.Cols[colID].Visible = false;
            //grfImg.Cols[colPathPic].Visible = false;
            grfVs.Cols[colImg].AllowEditing = false;
            grfVs.AutoSizeCols();
            grfVs.AutoSizeRows();
            theme1.SetTheme(grfImg, "Office2016DarkGray");

        }
        private void initGrfpApm()
        {
            grfpApm = new C1FlexGrid();
            grfpApm.Font = fEdit;
            grfpApm.Dock = System.Windows.Forms.DockStyle.Fill;
            grfpApm.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            //grfVs.AfterRowColChange += GrfImg_AfterRowColChange;
            //grfVs.MouseDown += GrfImg_MouseDown;
            //grfVs.DoubleClick += GrfImg_DoubleClick;
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfpApm.ContextMenu = menuGw;
            pnApm.Controls.Add(grfpApm);

            theme1.SetTheme(grfpApm, "Office2016DarkGray");

        }
        private void setGrfpApmDonor(String search)
        {
            grfpApm.Clear();
            grfpApm.Rows.Count = 1;
            grfpApm.Cols.Count = 5;
            DataTable dt = ic.ivfDB.pApmDB.selectByPtt(search);

            grfpApm.Rows.Count = dt.Rows.Count + 1;
            //grfCu.Rows.Count = 41;
            //grfCu.Cols.Count = 4;
            C1TextBox txt = new C1TextBox();
            //Button btn = new Button();
            //btn.BackColor = Color.Gray;
            //btn.Click += BtnEditor_Click;
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfpApm.Cols[colpApmId].Editor = txt;
            grfpApm.Cols[colpApmDate].Editor = txt;
            grfpApm.Cols[colpApmTime].Editor = txt;
            grfpApm.Cols[colpApmRemark].Editor = txt;
            //grfImg.Cols[colBtn].Editor = btn;

            grfpApm.Cols[colpApmId].Width = 250;
            grfpApm.Cols[colpApmDate].Width = 100;
            grfpApm.Cols[colpApmTime].Width = 100;
            grfpApm.Cols[colpApmRemark].Width = 300;
            //grfpApm.Cols[colVsStatus].Width = 250;
            //grfImg.Cols[colBtn].Width = 50;
            //grfImg.Cols[colPathPic].Width = 100;

            grfpApm.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfpApm.Cols[colpApmDate].Caption = "Date";
            grfpApm.Cols[colpApmTime].Caption = "Time";
            grfpApm.Cols[colpApmRemark].Caption = "Remark";
            
            //Hashtable ht = new Hashtable();
            //foreach (DataRow dr in dt.Rows)
            //{
            //    ht.Add(dr["CategoryID"], LoadImage(dr["Picture"] as byte[]));
            //}
            //grfImg.Cols[colImg].ImageMap = ht;
            //grfVs.Cols[colImg].ImageAndText = false;

            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("&แก้ไข Appointment", new EventHandler(ContextMenu_edit_papm));
            grfpApm.ContextMenu = menuGw;

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                String appn = "";
                appn = ic.ivfDB.genAppointmentRemarkPttDonor(row);
                grfpApm[i, colpApmId] = row[ic.ivfDB.pApmDB.pApm.t_patient_appointment_id].ToString();
                grfpApm[i, colpApmDate] = ic.datetoShow(row[ic.ivfDB.pApmDB.pApm.patient_appointment_date]);
                grfpApm[i, colpApmTime] = row[ic.ivfDB.pApmDB.pApm.patient_appointment_time].ToString();
                //grfpApm[i, colpApmRemark] = row[ic.ivfDB.pApmDB.pApm.remark].ToString();
                grfpApm[i, colpApmRemark] = appn;

                grfpApm[i, 0] = i;
                i++;
                //if (i % 2 == 0)
                //grfPtt.Rows[i].StyleNew.BackColor = color;
            }
            grfpApm.Cols[colpApmId].Visible = false;
            //grfImg.Cols[colPathPic].Visible = false;
            //grfpApm.Cols[colImg].AllowEditing = false;
            //grfpApm.AutoSizeCols();
            //grfpApm.AutoSizeRows();
            theme1.SetTheme(grfpApm, "Office2016DarkGray");
        }
        private void ContextMenu_edit_papm(object sender, System.EventArgs e)
        {
            String chk = "", name = "", id = "";
            id = grfpApm[grfpApm.Row, colpApmId] != null ? grfpApm[grfpApm.Row, colpApmId].ToString() : "";
            FrmAppointmentDonorAdd frm = new FrmAppointmentDonorAdd(ic, id, txtID.Text,"");
            frm.ShowDialog(this);
            frm.Dispose();
            setGrfpApmDonor(txtID.Text);
        }
        private void setControlDonor(String pttid, String pid)
        {
            ptt = ic.ivfDB.pttDB.setPatient1(ptt);
            if (!pttid.Equals(""))
            {
                ptt = ic.ivfDB.pttDB.selectByPk1(pttid);
            }
            else
            {
                if (!pid.Equals(""))
                {
                    ptt = ic.ivfDB.pttDB.selectByPID(pid);
                }
            }

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
            txtAllergyDesc.Enabled = chkDenyAllergy.Checked ? true : false;

            barcode.Text = txtHn.Text;
            filenamepic = txtHn.Text;
            txtContract.Value = ptt.contract;
            txtInsurance.Value = ptt.insurance;
            txtContFname1.Value = ptt.patient_contact_firstname;
            txtContLname1.Value = ptt.patient_contact_lastname;
            txtContMobile1.Value = ptt.patient_contact_mobile_phone;
            txtPttLNameE.Value = ptt.patient_lastname_e;
            txtPttNameE.Value = ptt.patient_firstname_e;
            txtAddrNo.Value = ptt.patient_house;
            txtMoo.Value = ptt.patient_moo;
            txtRoad.Value = ptt.patient_road;
            
            ic.setC1Combo(cboCouPrefix, ptt.patient_couple_f_patient_prefix_id);
            ic.setC1Combo(cboName1Rl, ptt.patient_contact_f_patient_relation_id);
            ic.setC1Combo(cboCouRel, ptt.patient_coulpe_f_patient_relation_id);
            ic.setC1Combo(cboCrl, ptt.b_contract_plans_id);
            txtAgent.Value = ptt.agent;

            chkOPU.Checked = ptt.status_opu.Equals("1") ? true : false;
            txtNickName.Value = ptt.patient_nickname;
            chkOR.Checked = ptt.status_or.Equals("1") ? true : false;
            txtORDescription.Enabled = chkOR.Checked ? true : false;
            chkCongenital.Checked = ptt.status_congenial.Equals("1") ? true : false;
            txtCongenital.Enabled = chkCongenital.Checked ? true : false;
            txtORDescription.Value = ptt.or_description;
            txtCongenital.Value = ptt.congenital_diseases_description;
            txtHeight.Value = ptt.patient_height;
            txtAllergyDesc.Value = ptt.allergy_description;
            chkStatusG.Checked = ptt.status_g.Equals("1") ? true : false;
            txtG.Value = ptt.g;
            txtP.Value = ptt.p;
            txtA.Value = ptt.a;
            setGrfpApmDonor(ptt.t_patient_id);
            //txtEmail.Value = pttO.Email;
        }
        private void setControlPatient(Patient ptt)
        {
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
            txtContract.Value = ptt.contract;
            txtInsurance.Value = ptt.insurance;
            txtContFname1.Value = ptt.patient_contact_firstname;
            txtContLname1.Value = ptt.patient_contact_lastname;
            txtContMobile1.Value = ptt.patient_contact_mobile_phone;
            txtPttLNameE.Value = ptt.patient_lastname_e;
            txtPttNameE.Value = ptt.patient_firstname_e;
            txtAddrNo.Value = ptt.patient_house;
            txtMoo.Value = ptt.patient_moo;
            txtRoad.Value = ptt.patient_road;


            ic.setC1Combo(cboCouPrefix, ptt.patient_couple_f_patient_prefix_id);
            ic.setC1Combo(cboName1Rl, ptt.patient_contact_f_patient_relation_id);
            ic.setC1Combo(cboCouRel, ptt.patient_coulpe_f_patient_relation_id);
            ic.setC1Combo(cboCrl, ptt.b_contract_plans_id);
            ic.setC1Combo(cboAgent, ptt.agent);
            txtNickName.Value = ptt.patient_nickname;
            //txtNickName.Value = ptt.patient_nickname;
            chkOR.Checked = ptt.status_or.Equals("1") ? true : false;
            chkCongenital.Checked = ptt.status_congenial.Equals("1") ? true : false;
            txtORDescription.Value = ptt.or_description;
            txtCongenital.Value = ptt.congenital_diseases_description;
            txtHeight.Value = ptt.patient_height;
            txtAllergyDesc.Value = ptt.allergy_description;
            txtEmerContact.Value = ptt.patient_contact_firstname + " " + ptt.patient_contact_lastname;
        }
        private void setControlPtt(String pttid)
        {
            ptt = ic.ivfDB.pttDB.selectByPk1(pttid);
            if (ptt.t_patient_id.Equals(""))
            {
                ptt = ic.ivfDB.pttDB.selectByIDold(pttid);
            }

            if (ptt.t_patient_id.Equals(""))
            {
                btnWebCamOn.Enabled = false;
            }
            setControlPatient(ptt);

            PatientOld pttO = new PatientOld();
            VisitOld vsOld = new VisitOld();
            if (pttid.Equals(""))
            {
                vsOld = ic.ivfDB.vsOldDB.selectByPk1(vsoldId);
                pttid = vsOld.PID;
            }

            pttO = ic.ivfDB.pttOldDB.selectByPk1(pttid);
            if (pttO.PID.Equals(""))
            {
                btnWebCamOn.Enabled = false;
            }
            else
            {
                btnWebCamOn.Enabled = true;
            }
            txtHn.Value = pttO.PIDS;
            txtIdOld.Value = pttO.PID;
            txtPttNameE.Value = pttO.PName;
            txtPttLNameE.Value = pttO.PSurname;
            txtPttName.Value = pttO.OName;
            txtPttLName.Value = pttO.OSurname;
            txtContFname1.Value = pttO.EmergencyPersonalContact;
            txtDob.Value = pttO.DateOfBirth;
            ic.setC1Combo(cboAgent, pttO.AgentID);
            ic.setC1Combo(cboPttType, pttO.PatientTypeID);
            ic.setC1Combo(cboCrl, pttO.PaymentID);
            ic.setC1Combo(cboSex, pttO.SexID);
            ic.setC1Combo(cboMarital, pttO.MaritalID);
            ic.setC1Combo(cboRg, pttO.Religion);
            cboProv.Value = pttO.Province;
            cboDist.Value = pttO.District;
            txtAddrNo.Value = pttO.Address;
            txtMoo.Value = pttO.Moo;
            txtRoad.Value = pttO.Road;
            if (pttO.IDNumber.Length == 10)
            {

            }
            //txtPid.Value = pttO.IDNumber.Length == 10 ? pttO.IDNumber : "";
            //txtPaasport.Value = pttO.IDNumber.Length != 10 ? pttO.IDNumber : "";
            //txtPid.Value = pttO.IDNumber;
            //cboName1Rl.Text = pttO.RelationshipID;
            ic.setC1Combo(cboName1Rl, pttO.RelationshipID);
            barcode.Text = txtHn.Text;
            txtEmail.Value = pttO.Email;
            ic.setC1Combo(cboPrefix, pttO.SurfixID);
            txtEmerContact.Value = pttO.EmergencyPersonalContact;
            if (txtID.Text.Equals("") && !pttid.Equals(""))
            {
                Patient id1 = ic.ivfDB.pttDB.selectByIDold(pttid);
                txtID.Value = id1.t_patient_id;
                if (!id1.t_patient_id.Equals(""))
                {
                    setControlPatient(id1);
                    flagHavOldPttNoPtt = false;
                    tabVisit.Enabled = true;
                }
                else
                {
                    flagHavOldPttNoPtt = true;
                    tabVisit.Enabled = false;
                }
            }
        }
        private void setControl()
        {
            //pttO1 = new PatientOld();
            //pttO1 = ic.ivfDB.pttOldDB.selectByPk1(pttid);
            if (ic.iniC.statusAppDonor.Equals("1"))
            {
                setControlDonor(pttId,"");
            }
            else
            {
                setControlPtt(pttOldId);
            }

            //ptt.patient_couple_f_patient_prefix_id = cboCouRel.SelectedItem

            //host = ic.iniC.hostFTP;
            //user = ic.iniC.userFTP;
            //pass = ic.iniC.passFTP;
            //MemoryStream stream = new MemoryStream();
            //stream = ic.ftpC.download(DateTime.Now.Year.ToString()+"/"+txtHn.Text+"."+ System.Drawing.Imaging.ImageFormat.Jpeg);
            ////image1 = new Image();
            //Bitmap bitmap = new Bitmap(stream);
            ////image1 = bitmap;
            //picPtt.Image = bitmap;
            //picPtt.SizeMode = PictureBoxSizeMode.StretchImage;
            PatientImage pttI = new PatientImage();
            pttI = ic.ivfDB.pttImgDB.selectByPttIDStatus4(txtID.Text);
            filenamepic = pttI.image_path;
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
                
                setPic(new Bitmap(ic.ftpC.download(filenamepic)));
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
            if (ic.iniC.statusAppDonor.Equals("1"))
            {
                ptt.patient_hn = txtID.Text.Equals("") ? ic.ivfDB.copDB.genHNDoc() : txtHn.Text;
            }
            else
            {
                ptt.patient_hn = txtHn.Text;
            }
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
            ptt.patient_contact_firstname = txtContFname1.Text;
            ptt.patient_contact_lastname = txtContLname1.Text;
            ptt.patient_contact_mobile_phone = txtContMobile1.Text;
            ptt.patient_couple_f_patient_prefix_id = cboCouPrefix.SelectedItem == null ? "" : ((ComboBoxItem)cboCouPrefix.SelectedItem).Value;
            ptt.patient_contact_f_patient_relation_id = cboName1Rl.SelectedItem == null ? "" : ((ComboBoxItem)cboName1Rl.SelectedItem).Value;
            ptt.patient_coulpe_f_patient_relation_id = cboCouRel.SelectedItem == null ? "" : ((ComboBoxItem)cboCouRel.SelectedItem).Value;
            ptt.b_contract_plans_id = cboCrl.SelectedItem == null ? "" : ((ComboBoxItem)cboCrl.SelectedItem).Value;
            
            if (ic.iniC.statusAppDonor.Equals("1"))
            {
                ptt.agent = txtAgent.Text;
            }
            else
            {
                ptt.agent = cboAgent.SelectedItem == null ? "" : ((ComboBoxItem)cboAgent.SelectedItem).Value;
            }

            ptt.status_opu = chkOPU.Checked == true ? "1" : "0";
            ptt.patient_nickname = txtNickName.Text;
            ptt.status_or = chkOR.Checked == true ? "1" : "0";
            ptt.status_congenial = chkCongenital.Checked == true ? "1" : "0";
            ptt.or_description = txtORDescription.Text;
            ptt.congenital_diseases_description = txtCongenital.Text;
            ptt.patient_height = txtHeight.Text;
            ptt.allergy_description = txtAllergyDesc.Text;
            ptt.status_g = chkStatusG.Checked == true ? "1" : "0";
            ptt.g = txtG.Text;
            ptt.p = txtP.Text;
            ptt.a = txtA.Text;
            //String[] name = txtEmerContact.Text.Split(' ');
            //if (name.Length > 0)
            //{
            //    ptt.patient_contact_firstname = name[0];
            //    ptt.patient_contact_lastname = name[1];
            //}
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
            try
            {
                String[] aaa = text.Split('\n');
                if (aaa[0].Length >= 33)
                {
                    text = aaa[0]+"\n"+" "+aaa[1] + " " + aaa[2];
                }
            }
            catch (Exception ex)
            {

            }
            
            // create pdf document
            _c1pdf.Clear();
            _c1pdf.DocumentInfo.Title = "";
            _c1pdf.PaperKind = System.Drawing.Printing.PaperKind.A4;
            sB.Text = "Creating pdf document...";

            // add title
            Font titleFont = new Font("Tahoma", 24, FontStyle.Bold);
            Font bodyFont = new Font("Tahoma", 9);
            Font bodyFontB = new Font("Tahoma", 12);
            RectangleF rcPage = GetPageRect();
            RectangleF rc = RenderParagraph(_c1pdf.DocumentInfo.Title, titleFont, rcPage, rcPage, false);
            //rc.Y += titleFont.Size + 6;
            //rc.Height = rcPage.Height - rc.Y;

            // create three columns for the text
            RectangleF rcLeft1 = rc;
            int chk = 0;
            //ic.iniC.sticker_donor_start_y = "30";
            //ic.iniC.sticker_donor_barcode_gap_y = "5";
            //ic.iniC.sticker_donor_barcode_height = "25";
            rcLeft1.Width = int.TryParse(ic.iniC.sticker_donor_width, out chk) ? chk : 120;
            rcLeft1.Height = int.TryParse(ic.iniC.sticker_donor_height, out chk) ? chk : 90;
            //ic.iniC.sticker_donor_start_y = "33";     // 38
            rcLeft1.Y = int.TryParse(ic.iniC.sticker_donor_start_y, out chk) ? chk : 63;
            rcLeft1.X = int.TryParse(ic.iniC.sticker_donor_start_x, out chk) ? chk : 52;
            RectangleF rcRight = rcLeft1;
            
            RectangleF rcMiddle = rcLeft1;
            //rcMiddle.X = rcPage.Right - rcMiddle.Width - rcMiddle.Width - 55;
            int.TryParse(ic.iniC.sticker_donor_gap, out chk);
            rcMiddle.X = rcLeft1.Right + chk;
            rcRight.X = rcMiddle.Right + chk;
            RectangleF rcBarcode1 = RenderParagraph("", titleFont, rcLeft1, rcLeft1, false);
            rcBarcode1.Height = int.TryParse(ic.iniC.sticker_donor_barcode_height, out chk) ? chk : 40;
            rcBarcode1.Width = rcLeft1.Width - (int.TryParse(ic.iniC.barcode_width_minus, out chk) ? chk :10);
            rcBarcode1.X = rcLeft1.X;
            rcBarcode1.X = rcBarcode1.X + (int.TryParse(ic.iniC.sticker_donor_barcode_gap_x, out chk) ? chk : 5);
            //rcBarcode1.Y = rcBarcode1.Y + (int.TryParse(ic.iniC.sticker_donor_barcode_gap_y, out chk) ? chk : 30);
            rcBarcode1.Y = rcLeft1.Height - rcBarcode1.Height + (int.TryParse(ic.iniC.sticker_donor_barcode_gap_y, out chk) ? chk : 30);
            RectangleF rcBarcodeM = rcBarcode1;
            RectangleF rcBarcodeR = rcBarcode1;
            rcBarcodeM.X = rcMiddle.X + (int.TryParse(ic.iniC.sticker_donor_barcode_gap_x, out chk) ? chk : 5);
            rcBarcodeR.X = rcRight.X + (int.TryParse(ic.iniC.sticker_donor_barcode_gap_x, out chk) ? chk : 5);
            //rcMiddle.X = 180;
            // start with left column
            //rc = rcLeft;

            // render string spanning columns and pages
            for (int i=1;i<=9 ;i++)
            {
                // render as much as will fit into the rectangle
                //rc.Inflate(-3, -3);
                int nextChar = _c1pdf.DrawString(hn, bodyFontB, Brushes.Black, rcLeft1);
                //int nextChar2 = _c1pdf.DrawString("\n ", bodyFont, Brushes.Black, rcLeft1);
                int nextChar1 = _c1pdf.DrawString("\n"+text, bodyFont, Brushes.Black, rcLeft1);
                _c1pdf.DrawImage(img, rcBarcode1);
                //rc.Inflate(+3, +3);
                //_c1pdf.DrawRectangle(Pens.Silver, rcLeft1);

                _c1pdf.DrawString(hn, bodyFontB, Brushes.Black, rcMiddle);
                _c1pdf.DrawString("\n" + text, bodyFont, Brushes.Black, rcMiddle);
                _c1pdf.DrawImage(img, rcBarcodeM);
                if (ic.iniC.status_show_border.Equals("1"))
                {
                    _c1pdf.DrawRectangle(Pens.Silver, rcMiddle);
                }
                

                _c1pdf.DrawString(hn, bodyFontB, Brushes.Black, rcRight);
                _c1pdf.DrawString("\n" + text, bodyFont, Brushes.Black, rcRight);
                _c1pdf.DrawImage(img, rcBarcodeR);
                //_c1pdf.DrawRectangle(Pens.Silver, rcRight);

                rcLeft1.Y += int.TryParse(ic.iniC.sticker_donor_height, out chk) ? chk : 120;
                rcMiddle.Y += int.TryParse(ic.iniC.sticker_donor_height, out chk) ? chk : 120;
                rcRight.Y += int.TryParse(ic.iniC.sticker_donor_height, out chk) ? chk : 120;
                rcBarcode1.Y += int.TryParse(ic.iniC.sticker_donor_height, out chk) ? chk : 120;
                rcBarcodeM.Y += int.TryParse(ic.iniC.sticker_donor_height, out chk) ? chk : 120;
                rcBarcodeR.Y += int.TryParse(ic.iniC.sticker_donor_height, out chk) ? chk : 120;
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
        static string aByteToString(byte[] b)
        {
            Encoding ut = Encoding.GetEncoding(874); // 874 for Thai langauge
            int i;
            for (i = 0; b[i] != 0; i++) ;

            string s = ut.GetString(b);
            s = s.Substring(0, i);
            return s;
        }
        protected int ReadCard()
        {
            try
            {
                byte[] Licinfo = new byte[1024];
                RDNID.getLicenseInfoRD(Licinfo);
                m_lblDLXInfo.Text = aByteToString(Licinfo);
                //String strTerminal = m_ListReaderCard.GetItemText(m_ListReaderCard.SelectedItem);
                _CardReaderTFK2700 = ic.ListCardReader();
                String strTerminal = _CardReaderTFK2700;
                IntPtr obj = ic.selectReader(strTerminal);

                Int32 nInsertCard = 0;
                nInsertCard = RDNID.connectCardRD(obj);
                if (nInsertCard != 0)
                {
                    String m;
                    m = String.Format(" error no {0} ", nInsertCard);
                    MessageBox.Show(m);

                    RDNID.disconnectCardRD(obj);
                    RDNID.deselectReaderRD(obj);
                    return nInsertCard;
                }

                byte[] id = new byte[30];
                int res = RDNID.getNIDNumberRD(obj, id);
                if (res != DefineConstants.NID_SUCCESS)
                    return res;
                String NIDNum = aByteToString(id);

                byte[] data = new byte[1024];
                res = RDNID.getNIDTextRD(obj, data, data.Length);
                if (res != DefineConstants.NID_SUCCESS)
                    return res;

                String NIDData = aByteToString(data);
                if (NIDData == "")
                {
                    MessageBox.Show("Read Text error");
                }
                else
                {
                    string[] fields = NIDData.Split('#');
                    if (txtID.Text.Equals(""))
                    {
                        txtPid.Value = NIDNum;
                        String fullname = fields[(int)NID_FIELD.TITLE_T] + " " +
                                            fields[(int)NID_FIELD.NAME_T] + " " +
                                            fields[(int)NID_FIELD.MIDNAME_T] + " " +
                                            fields[(int)NID_FIELD.SURNAME_T];
                        //m_txtFullNameT.Text = fullname;
                        txtPttName.Value = fields[(int)NID_FIELD.NAME_T] + " " + fields[(int)NID_FIELD.MIDNAME_T] + " ";
                        txtPttLName.Value = fields[(int)NID_FIELD.SURNAME_T];
                        txtPttNameE.Value = fields[(int)NID_FIELD.NAME_E] + " " + fields[(int)NID_FIELD.MIDNAME_E] + " ";
                        txtPttLNameE.Value = fields[(int)NID_FIELD.SURNAME_E];
                        //fullname = fields[(int)NID_FIELD.TITLE_E] + " " +
                        //                    fields[(int)NID_FIELD.NAME_E] + " " +
                        //                    fields[(int)NID_FIELD.MIDNAME_E] + " " +
                        //                    fields[(int)NID_FIELD.SURNAME_E];
                        //m_txtFullNameE.Text = fullname;

                        //m_txtBrithDate.Text = ic._yyyymmdd_(fields[(int)NID_FIELD.BIRTH_DATE]);
                        String dob = fields[(int)NID_FIELD.BIRTH_DATE];
                        if (dob.Length >= 8)
                        {
                            dob = dob.Substring(0, 4) + "-" + dob.Substring(4, 2) + "-" + dob.Substring(dob.Length - 2);
                            txtDob.Value = dob;
                        }
                        txtAddrNo.Value = fields[(int)NID_FIELD.HOME_NO];
                        txtMoo.Value = fields[(int)NID_FIELD.MOO];
                        txtRoad.Value = fields[(int)NID_FIELD.TROK] + " " + fields[(int)NID_FIELD.SOI] + " " + fields[(int)NID_FIELD.ROAD] + " " + fields[(int)NID_FIELD.TUMBON] + " " + fields[(int)NID_FIELD.AMPHOE] + " " + fields[(int)NID_FIELD.PROVINCE];
                        
                        ;
                        if (fields[(int)NID_FIELD.GENDER] == "1")
                        {
                            //m_txtGender.Text = "ชาย";
                            cboSex.SelectedIndex = 1;
                            cboPrefix.Text = "Mr.";
                        }
                        else
                        {
                            //m_txtGender.Text = "หญิง";
                            cboSex.SelectedIndex = 2;
                            cboPrefix.Text = "Miss";
                        }
                        byte[] NIDPicture = new byte[1024 * 5];
                        int imgsize = NIDPicture.Length;
                        res = RDNID.getNIDPhotoRD(obj, NIDPicture, out imgsize);
                        if (res != DefineConstants.NID_SUCCESS)
                            return res;

                        byte[] byteImage = NIDPicture;
                        if (byteImage == null)
                        {
                            MessageBox.Show("Read Photo error");
                        }
                        else
                        {
                            //m_picPhoto
                            Image img = Image.FromStream(new MemoryStream(byteImage));
                            //Bitmap MyImage = new Bitmap(img, m_picPhoto.Width - 2, m_picPhoto.Height - 2);
                            Bitmap MyImage = new Bitmap(img, picPtt.Width - 2, picPtt.Height - 2);
                            //m_picPhoto.Image = (Image)MyImage;
                            picPtt.Image = (Image)MyImage;
                            setControlDonor("", txtPid.Text);
                            if (txtID.Text.Equals(""))
                            {
                                img.Save(picIDCard, ImageFormat.Jpeg);
                                flagReadCard = true;
                            }
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("ต้องการ เปลี่ยนแปลงข้อมูล \nโดบให้ยึด ข้อมูลจาก บัตรประชาชน\n"
                            + txtPid.Text +"="+ NIDNum+"\n"
                            + txtPttName.Text + "=" + fields[(int)NID_FIELD.NAME_T] + " " + fields[(int)NID_FIELD.MIDNAME_T] + " " + "\n"
                            + txtPttLName.Text + "=" + fields[(int)NID_FIELD.SURNAME_T] + "\n"
                            + txtPttNameE.Text + "=" + fields[(int)NID_FIELD.NAME_E] + " " + fields[(int)NID_FIELD.MIDNAME_E] + " " + "\n"
                            + txtPttLNameE.Text + "=" + fields[(int)NID_FIELD.SURNAME_E] + "\n", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                        {
                            flagReadCard = true;
                            txtPttName.Value = fields[(int)NID_FIELD.NAME_T] + " " + fields[(int)NID_FIELD.MIDNAME_T] + " ";
                            txtPttLName.Value = fields[(int)NID_FIELD.SURNAME_T];
                            txtPttNameE.Value = fields[(int)NID_FIELD.NAME_E] + " " + fields[(int)NID_FIELD.MIDNAME_E] + " ";
                            txtPttLNameE.Value = fields[(int)NID_FIELD.SURNAME_E];
                            String dob = fields[(int)NID_FIELD.BIRTH_DATE];
                            if (dob.Length >= 8)
                            {
                                dob = dob.Substring(0, 4) + "-" + dob.Substring(4, 2) + "-" + dob.Substring(dob.Length - 2);
                                txtDob.Value = dob;
                            }
                            txtAddrNo.Value = fields[(int)NID_FIELD.HOME_NO];
                            txtMoo.Value = fields[(int)NID_FIELD.MOO];
                            txtRoad.Value = fields[(int)NID_FIELD.TROK] + " " + fields[(int)NID_FIELD.SOI] + " " + fields[(int)NID_FIELD.ROAD] + " " + fields[(int)NID_FIELD.TUMBON] + " " + fields[(int)NID_FIELD.AMPHOE] + " " + fields[(int)NID_FIELD.PROVINCE];

                            ;
                            if (fields[(int)NID_FIELD.GENDER] == "1")
                            {
                                //m_txtGender.Text = "ชาย";
                                cboSex.SelectedIndex = 1;
                                //cboPrefix.Text = "Mr.";
                                //cboPrefix.SelectedText = "Mr.";
                                ic.setC1ComboByName(cboPrefix, "Mr.");
                            }
                            else
                            {
                                //m_txtGender.Text = "หญิง";
                                cboSex.SelectedIndex = 2;
                                //cboPrefix.Text = "Miss";
                                //cboPrefix.SelectedText = "Miss";
                                ic.setC1ComboByName(cboPrefix, "Miss");

                            }
                            byte[] NIDPicture = new byte[1024 * 5];
                            int imgsize = NIDPicture.Length;
                            res = RDNID.getNIDPhotoRD(obj, NIDPicture, out imgsize);
                            if (res != DefineConstants.NID_SUCCESS)
                                return res;

                            byte[] byteImage = NIDPicture;
                            if (byteImage == null)
                            {
                                MessageBox.Show("Read Photo error");
                            }
                            else
                            {
                                //m_picPhoto
                                Image img = Image.FromStream(new MemoryStream(byteImage));
                                //Bitmap MyImage = new Bitmap(img, m_picPhoto.Width - 2, m_picPhoto.Height - 2);
                                Bitmap MyImage = new Bitmap(img, picPtt.Width - 2, picPtt.Height - 2);
                                //m_picPhoto.Image = (Image)MyImage;
                                picPtt.Image = (Image)MyImage;
                                //setControlDonor("", txtPid.Text);
                                //if (txtID.Text.Equals(""))
                                //{
                                    img.Save(picIDCard, ImageFormat.Jpeg);
                                    flagReadCard = true;
                                //}
                            }
                        }
                        
                    }
                }

                

                RDNID.disconnectCardRD(obj);
                RDNID.deselectReaderRD(obj);
            }
            catch(Exception ex)
            {
                MessageBox.Show("ReadCard " + ex.Message, "");
            }
            
            return 0;
        }
        private void FrmPatientAdd_Load(object sender, EventArgs e)
        {
            if (ic.iniC.statusAppDonor.Equals("1"))
            {
                tC1.SelectedTab = tabFamily;
            }
            else
            {
                tC1.SelectedTab = tabAddress;
            }
            splitMain.Panel1MinSize = 260;
            splitMain.SplitterDistance = int.Parse(ic.iniC.patientaddpanel1weight);
            if (ic.iniC.statusAppDonor.Equals("1"))
            {
                theme1.SetTheme(sB, ic.theme);
            }
            else
            {
                theme1.SetTheme(sB, "Office2010Red");
            }
            txtMoo.Value = System.DateTime.Now.Year.ToString();
            //_CardReaderTFK2700 = ic.ListCardReader();
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
