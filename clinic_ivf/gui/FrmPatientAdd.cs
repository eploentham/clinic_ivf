using AForge.Video.DirectShow;
using C1.Win.C1FlexGrid;
using C1.Win.C1SuperTooltip;
using clinic_ivf.control;
using clinic_ivf.object1;
using clinic_ivf.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

            btnPrnSticker.Click += BtnPrnSticker_Click;
            btnSave.Click += BtnSave_Click;
            btnWebCamOn.Click += BtnWebCamOn_Click;
            btnCapture.Click += BtnCapture_Click;
            this.FormClosed += FrmPatientAdd_FormClosed;

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
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setPatient();
                String re = ic.ivfDB.pttDB.insertPatient(ptt, ic.user.staff_id);
                int chk = 0;
                if (int.TryParse(re, out chk))
                {
                    //ic.ivfDB.stfDB.getlStf();
                    btnSave.Image = Resources.accept_database24;
                }
                else
                {
                    btnSave.Image = Resources.accept_database24;
                }
                //setGrfStfH();
                //setControlEnable(false);
                //this.Dispose();
            }
        }

        private void BtnPrnSticker_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            MessageBox.Show("aaaa", "");
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

            //stf.dept_id = cboDept.SelectedItem == null ? "" : ((ComboBoxItem)cboDept.SelectedItem).Value;
        }

        private void FrmPatientAdd_Load(object sender, EventArgs e)
        {
            tC1.SelectedTab = tabFamily;
        }
    }
}
