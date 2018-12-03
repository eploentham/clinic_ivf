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
        String pttId = "", webcamname = "", vsid="", pttOid="";
        Patient ptt;
        PatientOld pttO;
        VisitOld vsOld;
        Visit vs;

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

        public FrmVisitAdd(IvfControl ic, String pttid, String vsid, String pttoid)
        {
            InitializeComponent();
            this.vsid = vsid;
            this.ic = ic;
            this.pttId = pttid;
            this.pttOid = pttoid;
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
            ic.ivfDB.fpfDB.setCboPrefix(cboPrefix,"");
            ic.ivfDB.fmsDB.setCboMarriage(cboMarital, "");
            ic.ivfDB.fbgDB.setCboBloodGroup(cboBloodG, "");
            ic.ivfDB.fpnDB.setCboNation(CboNation, "");
            ic.ivfDB.fetDB.setCboEduca(CboEduca, "");
            ic.ivfDB.frcDB.setCboRace(cboRace, "");
            ic.ivfDB.frgDB.setCboReligion(cboRg, "");
            ic.setCboPttType(cboPttType);
            ic.ivfDB.bspDB.setCboBsp(cboBsp,"");
            ic.ivfDB.agnOldDB.setCboAgent(cboAgent, "");

            btnVisit.Click += BtnVisit_Click;
            btnHnSearch.Click += BtnHnSearch_Click;
            tC.SelectedTabChanged += TC_SelectedTabChanged;
            btnPrnCheckList1.Click += BtnPrnCheckList1_Click;

            if (pttId.Equals(""))
            {

            }
            setControl(pttId, pttOid);
            txtAgent.Left = cboAgent.Left;
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

        private void BtnPrnCheckList1_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmReport frm = new FrmReport(ic);
            DataTable dt = new DataTable();
            dt = ic.ivfDB.vsDB.selectByCheckList1(txtPttId.Text, txtID.Text);
            frm.setVisitCheckList1Report(dt);
            frm.ShowDialog(this);
        }

        private void TC_SelectedTabChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if(tC.SelectedTab == tabCheckList1)
            {
                chkDenyAllergy1.Checked = chkDenyAllergy.Checked;
                chkOPU1.Checked = chkOPU.Checked;
                chkOR1.Checked = chkOR.Checked;
                chkCongenital1.Checked = chkCongenital.Checked;
                txtCongenital1.Value = txtCongenital1.Text;
                txtNickName1.Value = txtNickName.Text;
                txtMobile11.Value = txtMobile1.Text;
                txtHeight1.Value = txtHeight.Text;
                txtBP1.Value = txtBP.Text;
                txtBW1.Value = txtBW1.Text;
                txtLMP1.Value = txtLMP.Text;
                txtAgent1.Value = txtAgent.Text;
                txtNickName1.Value = txtNickName.Text;
            }
        }

        private void BtnHnSearch_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmSearchHn frm = new FrmSearchHn(ic, FrmSearchHn.StatusConnection.hostEx);
            frm.ShowDialog(this);
            txtHnFemale.Value = ic.sVsOld.PIDS;
            label32.Text = ic.sVsOld.PName;
        }

        private void BtnVisit_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (btnVisit.Text.Equals("Confirm"))
            {
                stt.Hide();
                
                String re = "";
                if (ic.iniC.statusAppDonor.Equals("1"))
                {
                    setVisit();
                    re = ic.ivfDB.vsDB.insertVisit(vs, txtStfConfirmID.Text);
                }
                else
                {
                    setVisitOld();
                    re = ic.ivfDB.vsOldDB.insertVisitOld(vsOld, txtStfConfirmID.Text);
                }
                long chk = 0;
                if (long.TryParse(re, out chk))
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
                    txtID.Value = re;
                    btnVisit.Text = "Save Visit";
                    btnVisit.Image = Resources.accept_database24;
                    //        txtID.Value = re;
                    //        txtPid.Focus();
                    //    }
                    //}
                    //}
                    //}
                    
                    System.Threading.Thread.Sleep(500);
                    this.Dispose();
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

        private void setControl(String pttid, String pttOid)
        {
            if (ic.iniC.statusAppDonor.Equals("1"))
            {
                ptt = ic.ivfDB.pttDB.selectByPk1(pttid);
                if (ptt.t_patient_id.Equals(""))
                {
                    ptt = ic.ivfDB.pttDB.selectByIDold(pttid);
                }

                txtHn.Value = ptt.patient_hn;
                txtPttId.Value = ptt.t_patient_id;
                txtPttName.Value = ptt.patient_firstname;
                txtPttLName.Value = ptt.patient_lastname;
                txtPttNameE.Value = ptt.patient_firstname_e;
                txtPttLNameE.Value = ptt.patient_lastname_e;
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
                ic.setC1Combo(cboAgent, ptt.agent);
                txtAgent.Value = ptt.agent;
                txtAgent1.Value = ptt.agent;
                //ic.setC1Combo(cboBsp, ptt.patient_type);cboAgent

                //ic.setC1Combo(cboCouPrefix, ptt.f_patient_religion_id);
                //ic.setC1Combo(cboRg, ptt.f_patient_religion_id);
                //ic.setC1Combo(cboRg, ptt.f_patient_religion_id);
                chkChronic.Checked = ptt.status_chronic.Equals("1") ? true : false;
                chkDenyAllergy.Checked = ptt.status_deny_allergy.Equals("1") ? true : false;
                chkDenyAllergy1.Checked = chkDenyAllergy.Checked;
                chkOPU.Checked = ptt.status_opu.Equals("1") ? true : false;
                chkOPU1.Checked = chkOPU.Checked;
                chkOR.Checked = ptt.status_or.Equals("1") ? true : false;
                chkOR1.Checked = chkOR.Checked;
                chkCongenital.Checked = ptt.status_congenial.Equals("1") ? true : false;
                chkCongenital1.Checked = chkCongenital.Checked;
                txtCongenital.Value = ptt.congenital_diseases_description;
                txtCongenital1.Value = ptt.congenital_diseases_description;
                txtORDescription1.Value = ptt.or_description;
                stt.SetToolTip(chkOR, ptt.or_description);
                stt.SetToolTip(chkOR, ptt.or_description);
                txtNickName.Value = ptt.patient_nickname;
                txtNickName1.Value = txtNickName.Text;
                txtMobile11.Value = txtMobile1.Text;
                txtHeight.Value = ptt.patient_height;
                txtHeight1.Value = txtHeight.Text;
                
                vs = ic.ivfDB.vsDB.selectByPk1(vsid);
                txtID.Value = vs.t_visit_id;
                ic.setC1Combo(cboBsp, vs.b_service_point_id);
                txtComment.Value = vs.visit_notice;
                txtBP.Value = vs.bp;
                txtBW.Value = vs.bw;
                txtBP1.Value = txtBP.Text;
                txtBW1.Value = txtBW1.Text;
                //txtHnFemale.Text = 
            }
            else
            {
                pttO = ic.ivfDB.pttOldDB.selectByPk1(pttOid);
                txtHn.Value = pttO.PIDS;
                txtPttId.Value = pttO.PID;
                txtPttNameE.Value = pttO.PName;
                txtPttLNameE.Value = pttO.PSurname;
                
                txtIdOld.Value = pttO.PID;

                txtPttName.Value = pttO.OName;
                txtPttLName.Value = pttO.OSurname;
                //txtContFname1.Value = pttO.EmergencyPersonalContact;
                txtDob.Value = pttO.DateOfBirth;
                ic.setC1Combo(cboAgent, pttO.AgentID);
                ic.setC1Combo(cboPttType, pttO.PatientTypeID);
                //ic.setC1Combo(cboCrl, pttO.PaymentID);
                ic.setC1Combo(cboSex, pttO.SexID);
                ic.setC1Combo(cboMarital, pttO.MaritalID);
                ic.setC1Combo(cboRg, pttO.Religion);
                
                if (pttO.IDNumber.Length == 10)
                {

                }
                //txtPid.Value = pttO.IDNumber.Length == 10 ? pttO.IDNumber : "";
                //txtPaasport.Value = pttO.IDNumber.Length != 10 ? pttO.IDNumber : "";
                txtPid.Value = pttO.IDNumber;
                //cboName1Rl.Text = pttO.RelationshipID;
                //ic.setC1Combo(cboName1Rl, pttO.RelationshipID);
                //barcode.Text = txtHn.Text;
                txtEmail.Value = pttO.Email;
                
                filenamepic = txtHn.Text;

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
            vsOld.VSID = "110";
            vsOld.PID = txtPttId.Text;
            vsOld.PIDS = txtHn.Text;
            vsOld.PName = cboPrefix.Text +" "+txtPttNameE.Text+" "+txtPttLNameE.Text;
            vsOld.OName = "";
            vsOld.VDate = DateTime.Now.Year.ToString()+"-"+ DateTime.Now.ToString("MM-dd");
            vsOld.VStartTime = DateTime.Now.ToString("hh:mm:ss");
            vsOld.VEndTime = "";
            vsOld.VUpdateTime = "";
            vsOld.LVSID = "";
            vsOld.IntLock = "0";
        }
        private void setVisit()
        {
            vs = new Visit();
            vs = ic.ivfDB.vsDB.setVisit1(vs);
            vs.t_visit_id = txtID.Text;
            vs.visit_hn = txtHn.Text;
            vs.t_patient_id = txtPttId.Text;
            vs.b_service_point_id = cboBsp.SelectedItem == null ? "" : ((ComboBoxItem)cboBsp.SelectedItem).Value;
            vs.visit_notice = txtComment.Text;
            vs.visit_begin_visit_time = DateTime.Now.Year.ToString() + "-" + DateTime.Now.ToString("MM-dd hh:mm:ss");
            vs.visit_vn = ic.ivfDB.copDB.genVNDoc();
            vs.remark = txtRemark.Text;
            vs.f_visit_status_id = "1";
            vs.visit_record_staff = txtStfConfirmID.Text;
            
            vs.f_visit_type_id = ic.iniC.statusAppDonor.Equals("1") ? "2" : "1";
            vs.status_urge = chkUrge.Checked ? "1" : "0";
            vs.patient_hn_1 = txtHnFemale.Text;
            vs.lmp = ic.datetoDB(txtLMP.Text);
            vs.height = txtHeight.Text;

            vs.bw = txtBW.Text;
            vs.bp = txtBP.Text;
            vs.queue_id = ic.ivfDB.copDB.genQueueDoc();
            //vs.visit_notice = txtComment.Text;            
        }
        private void FrmVisitAdd_Load(object sender, EventArgs e)
        {
            tC.SelectedTab = tabVisit;
            if (cboBsp.Items.Count > 0)
                cboBsp.SelectedIndex = 3;
        }
    }
}
