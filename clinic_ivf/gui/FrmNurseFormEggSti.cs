using C1.Win.C1FlexGrid;
using C1.Win.C1SuperTooltip;
using clinic_ivf.control;
using clinic_ivf.object1;
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
    public partial class FrmNurseFormEggSti : Form
    {
        IvfControl ic;
        MainMenu menu;
        //public C1DockingTabPage tab;

        String pttid = "", webcamname = "", vsid = "", flagedit = "", pApmId = "", vsidOld = "", eggstiid="";

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;

        Patient ptt;
        VisitOld vsOld;
        Visit vs;
        PatientOld pttOld;
        EggSti eggs;

        C1FlexGrid grfEggsd;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        static String filenamepic = "";
        public FrmNurseFormEggSti(IvfControl ic, MainMenu m, String eggstiid, String pttid, String vsid, String flagedit)
        {
            InitializeComponent();
            this.ic = ic;
            this.vsid = vsid;
            this.pttid = pttid;
            this.flagedit = flagedit;
            this.eggstiid = eggstiid;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);

            //C1ThemeController.ApplicationTheme = ic.iniC.themeApplication;
            theme1.Theme = ic.iniC.themeApplication;
            theme1.SetTheme(sB, "BeigeOne");
            //theme1.SetTheme(tabOrder, "MacSilver");
            ic.ivfDB.dtrOldDB.setCboDoctor(cboDoctor, "");

            sB1.Text = "";
            bg = txtHn.BackColor;
            fc = txtHn.ForeColor;
            ff = txtHn.Font;

            vsOld = new VisitOld();
            vs = new Visit();
            ptt = new Patient();
            pttOld = new PatientOld();
            eggs = new EggSti();
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();

            btnGenEggSti.Click += BtnGenEggSti_Click;

            setControl();
        }

        private void BtnGenEggSti_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ Day Egg Sti  ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                createEggSti();
                ic.cStf.staff_id = "";
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    int chk = 0;
                    String re = ic.ivfDB.eggsDB.insertLabOpuEmbryoDev(eggs, ic.cStf.staff_id);
                    if(int.TryParse(re, out chk))
                    {

                    }
                }
            }
            
        }
        private void createEggSti()
        {
            eggs.egg_sti_id = "";
            eggs.lmp_date = ic.datetoDB(txtLmpDate.Text);
            eggs.nurse_t_egg_sticol = "";
            eggs.status_g = "";
            eggs.p = "";
            eggs.active = "";
            eggs.remark = "";
            eggs.a = "";
            eggs.date_create = "";
            eggs.date_modi = "";
            eggs.date_cancel = "";
            eggs.user_create = "";
            eggs.user_modi = "";
            eggs.user_cancel = "";
            eggs.g = "";
            eggs.opu_date = "";
            eggs.opu_time = "";
            eggs.et = "";
            eggs.fet = "";
            eggs.bhcg_test = "";
            eggs.t_patient_id = txtPttId.Text;
            eggs.t_visit_id = txtVsId.Text;
            eggs.egg_sti_date = DateTime.Now.Year.ToString()+"-"+ DateTime.Now.ToString("MM-dd");
        }

        private void setControl()
        {
            eggs = ic.ivfDB.eggsDB.selectByPk1(eggstiid);
            if (eggs.egg_sti_id.Equals(""))
            {
                setControl1();
                btnGenEggSti.Enabled = true;
                eggs = ic.ivfDB.eggsDB.selectByVsId(vsid);
            }
            else
            {
                setControl1();
            }
            
        }
        private void setControl1()
        {
            txtId.Value = eggs.egg_sti_id;
            vsOld = ic.ivfDB.ovsDB.selectByPk1(vsid);
            pttOld = ic.ivfDB.pttOldDB.selectByPk1(vsOld.PID);
            vs = ic.ivfDB.vsDB.selectByPk1(vsid);
            ptt = ic.ivfDB.pttDB.selectByHn(vsOld.PIDS);
            ptt.patient_birthday = pttOld.DateOfBirth;
            txtHn.Value = vsOld.PIDS;
            txtVn.Value = vsOld.VN;
            txtPttNameE.Value = vsOld.PName;
            txtDob.Value = ic.datetoShow(pttOld.DateOfBirth) + " [" + ptt.AgeStringShort() + "]";
            txtAllergy.Value = ptt.allergy_description;
            txtPttPID.Value = pttOld.PID;
            txtVnOld.Value = vsOld.VN;
            txtSex.Value = ptt.f_sex_id.Equals("1") ? "ชาย" : "หญิง";
            txtBg.Value = ptt.f_patient_blood_group_id.Equals("2140000005") ? "O"
                : ptt.f_patient_blood_group_id.Equals("2140000002") ? "A" : ptt.f_patient_blood_group_id.Equals("2140000003") ? "B"
                : ptt.f_patient_blood_group_id.Equals("2140000004") ? "AB" : "ไม่ระบุ";
            txtVisitHeight.Value = vs.height;
            txtVisitBW.Value = vs.bw;
            txtVisitBP.Value = vs.bp;
            txtVisitPulse.Value = vs.pulse;
            chkChronic.Checked = ptt.status_congenial.Equals("1") ? true : false;
            stt.Show("<p><b>สวัสดี</b></p>คุณ " + ptt.congenital_diseases_description + "<br> กรุณา ป้อนรหัสผ่าน", chkChronic);
            if (!ptt.t_patient_id.Equals(""))
            {
                PatientImage pttI = new PatientImage();
                pttI = ic.ivfDB.pttImgDB.selectByPttIDStatus4(ptt.t_patient_id);
                filenamepic = pttI.image_path;
                Thread threadA = new Thread(new ParameterizedThreadStart(ExecuteA));
                threadA.Start();
            }
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
                String aaa = "images/" + txtPttPID.Text + "/" + txtPttPID.Text + "." + System.Drawing.Imaging.ImageFormat.Jpeg;
                //setPic(new Bitmap(ic.ftpC.download(filenamepic)));
                setPic(new Bitmap(ic.ftpC.download(aaa)));
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
        private void FrmNurseFormEggSti_Load(object sender, EventArgs e)
        {

        }
    }
}
