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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.gui
{
    public partial class FrmVisitAdd : Form
    {
        IvfControl ic;
        String pttId = "", webcamname = "", vsid="";
        Patient ptt;
        VisitOld vsOld;

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;
        FtpClient ff1;
        Bitmap img;
        Image image1;

        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        String filename = "";
        static String filenamepic = "", host = "", user = "", pass = "";

        public FrmVisitAdd(IvfControl ic, String pttid, String vsid)
        {
            InitializeComponent();
            this.vsid = vsid;
            this.ic = ic;
            this.pttId = pttid;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);

            //theme1.SetTheme(sB, "BeigeOne");
            
            sB1.Text = "";
            bg = txtPttNameE.BackColor;
            fc = txtPttNameE.ForeColor;
            ff = txtPttNameE.Font;
            ff1 = new FtpClient(ic.iniC.hostFTP, ic.iniC.userFTP, ic.iniC.passFTP);

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            image1 = null; 

            txtDob.Value = DateTime.Now.ToString("yyyy-MM-dd");
            ic.ivfDB.fpfDB.setCboPrefix(cboPrefix);
            ic.ivfDB.fmsDB.setCboMarriage(cboMarital);
            ic.ivfDB.fbgDB.setCboBloodGroup(cboBloodG);
            ic.ivfDB.fpnDB.setCboNation(CboNation);
            ic.ivfDB.fetDB.setCboEduca(CboEduca);
            ic.ivfDB.frcDB.setCboRace(cboRace);
            ic.ivfDB.frgDB.setCboReligion(cboRg);
            ic.setCboPttType(cboPttType);
            ic.ivfDB.bspDB.setCboBsp(cboBsp,"");

            btnVisit.Click += BtnVisit_Click;

            if (pttId.Equals(""))
            {

            }
            setControl(pttId);
            //setFocusColor();
            //initGrfImg();
            //setGrfImg("");

            //btnPrnSticker.Click += BtnPrnSticker_Click;
            //btnSave.Click += BtnSave_Click;
            //btnWebCamOn.Click += BtnWebCamOn_Click;
            //btnCapture.Click += BtnCapture_Click;
            //this.FormClosed += FrmPatientAdd_FormClosed;
            //btnPrvSticker.Click += BtnPrvSticker_Click;
            
            //setKeyEnter();
            
        }

        private void BtnVisit_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (btnVisit.Text.Equals("Confirm"))
            {
                stt.Hide();
                setVisitOld();
                String re = ic.ivfDB.vsOldDB.insertVisitOld(vsOld, txtStfConfirmID.Text);
                int chk = 0;
                if (int.TryParse(re, out chk))
                {
                    //if (!ic.iniC.statusAppDonor.Equals("1"))
                    //{
                    //String re1 = ic.ivfDB.pttOldDB.insertPatientOld(ptt, txtStfConfirmID.Text);
                    //if (int.TryParse(re1, out chk))
                    //{
                    //if (txtID.Text.Equals(""))
                    //{
                    //    //PatientOld pttOld = new PatientOld();
                    //    //pttOld = ic.ivfDB.pttOldDB.selectByPk1(re1);
                    //    String re2 = ic.ivfDB.pttDB.updatePID(re, re1);
                    //    if (int.TryParse(re2, out chk))
                    //    {
                    btnVisit.Text = "Save Visit";
                    btnVisit.Image = Resources.accept_database24;
                    //        txtID.Value = re;
                    //        txtPid.Focus();
                    //    }
                    //}
                    //}
                    //}


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
                    btnVisit.Text = "Confirm";
                    btnVisit.Image = Resources.Add_ticket_24;
                    stt.Show("<p><b>สวัสดี</b></p>คุณ " + ic.cStf.staff_fname_t + " " + ic.cStf.staff_lname_t + "<br> กรุณายินยันการ confirm อีกครั้ง", cboPttType);
                    btnVisit.Focus();
                }
                else
                {
                    btnVisit.Text = "new Visit";
                    btnVisit.Image = Resources.download_database24;
                }
            }
        }

        private void setControl(String pttid)
        {
            ptt = ic.ivfDB.pttDB.selectByPk1(pttid);
            
            txtHn.Value = ptt.patient_hn;
            txtPttId.Value = ptt.t_patient_id;
            txtPttName.Value = ptt.patient_firstname;
            txtPttLName.Value = ptt.patient_lastname;
            txtRemark.Value = ptt.remark;
            txtLineID.Value = ptt.line_id;
            txtEmail.Value = ptt.email;
            txtMobile1.Value = ptt.mobile1;
            txtMobile2.Value = ptt.mobile2;
            txtPid.Value = ptt.pid;
            txtPaasport.Value = ptt.passport;
                                   
            txtRemark.Value = ptt.remark;
            txtDob.Value = ptt.patient_birthday;
            
            ic.setC1Combo(cboPrefix, ptt.f_patient_prefix_id);
            ic.setC1Combo(cboSex, ptt.f_sex_id);
            ic.setC1Combo(cboMarital, ptt.f_patient_marriage_status_id);
            ic.setC1Combo(cboBloodG, ptt.f_patient_blood_group_id);
            ic.setC1Combo(CboNation, ptt.f_patient_nation_id);
            ic.setC1Combo(CboEduca, ptt.f_patient_education_type_id);
            ic.setC1Combo(cboRace, ptt.f_patient_race_id);
            ic.setC1Combo(cboRg, ptt.f_patient_religion_id);
            ic.setC1Combo(cboPttType, ptt.patient_type);
            //ic.setC1Combo(cboBsp, ptt.patient_type);

            //ic.setC1Combo(cboCouPrefix, ptt.f_patient_religion_id);
            //ic.setC1Combo(cboRg, ptt.f_patient_religion_id);
            //ic.setC1Combo(cboRg, ptt.f_patient_religion_id);
            chkChronic.Checked = ptt.status_chronic.Equals("1") ? true : false;
            chkDenyAllergy.Checked = ptt.status_deny_allergy.Equals("1") ? true : false;
            
            txtPttLNameE.Value = ptt.patient_lastname_e;
            txtPttNameE.Value = ptt.patient_firstname_e;

            filenamepic = txtHn.Text;
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

            ic.setC1Combo(cboAgent, ptt.agent);
            
            Thread threadA = new Thread(new ParameterizedThreadStart(ExecuteA));
            threadA.Start();
        }
        private void ExecuteA(Object obj)
        {
            //Console.WriteLine("Executing parameterless thread!");
            try
            {
                setPic(new Bitmap(ic.ftpC.download(DateTime.Now.Year.ToString() + "/" + filenamepic + "." + System.Drawing.Imaging.ImageFormat.Jpeg)));
            }
            catch (Exception ex)
            {

            }

        }
        private void setPic(Bitmap bitmap)
        {
            picPtt.Image = bitmap;
            picPtt.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void setVisitOld()
        {
            vsOld = new VisitOld();
            vsOld.VN = txtID.Text;
            vsOld.VSID = "165";
            vsOld.PID = txtPttId.Text;
            vsOld.PIDS = txtHn.Text;
            vsOld.PName = cboPrefix.Text +" "+txtPttNameE.Text+" "+txtPttLNameE.Text;
            vsOld.OName = "";
            vsOld.VDate = DateTime.Now.ToString("yyyy-MM-dd");
            vsOld.VStartTime = DateTime.Now.ToString("hh:MM:ss");
            vsOld.VEndTime = "";
            vsOld.VUpdateTime = "";
            vsOld.LVSID = "";
            vsOld.IntLock = "0";
        }
        private void FrmVisitAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
