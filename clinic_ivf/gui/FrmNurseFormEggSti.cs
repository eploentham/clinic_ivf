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

        int colDay = 1, colDate = 2, colE2 = 3, colLH = 4, colFSH = 5, colProlactin = 6, colRt1=7, colRt2=8, colLt1=9, colLt2=10, colEndo=11, colMedi=12, colId=13, colEdit=14;

        Patient ptt;
        VisitOld vsOld;
        Visit vs;
        PatientOld pttOld;
        EggSti eggs;

        C1FlexGrid grfEggsd;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        static String filenamepic = "";
        Color color;
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
            color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            initGrfEggSti();

            btnGenEggSti.Click += BtnGenEggSti_Click;
            btnSave.Click += BtnSave_Click;

            setControl();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (txtId.Text.Equals(""))
            {
                MessageBox.Show("ID ไม่ถูกต้อง ", "");
                return;
            }
            ic.cStf.staff_id = "";
            FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            frm.ShowDialog(this);
            if (!ic.cStf.staff_id.Equals(""))
            {
                for (int i = 1; i <= 17; i++)
                {
                    if (grfEggsd.Rows[i][colEdit] == null) continue;
                    if (grfEggsd.Rows[i][colEdit].ToString().Equals("1"))
                    {
                        EggStiDay eggsd = new EggStiDay();
                        eggsd.egg_sti_day_id = grfEggsd.Rows[i][colId].ToString();
                        eggsd.egg_sti_id = txtId.Text;
                        eggsd.day1 = i.ToString();
                        eggsd.date = "";
                        eggsd.e2 = grfEggsd.Rows[i][colE2].ToString();
                        eggsd.lh = grfEggsd.Rows[i][colLH].ToString();
                        eggsd.active = "";
                        eggsd.remark = "";
                        eggsd.fsh = grfEggsd.Rows[i][colFSH].ToString();
                        eggsd.date_create = "";
                        eggsd.date_modi = "";
                        eggsd.date_cancel = "";
                        eggsd.user_create = "";
                        eggsd.user_modi = "";
                        eggsd.user_cancel = "";
                        eggsd.prolactin = grfEggsd.Rows[i][colProlactin].ToString();
                        eggsd.rt_ovary_1 = grfEggsd.Rows[i][colRt1].ToString();
                        eggsd.rt_ovary_2 = grfEggsd.Rows[i][colRt2].ToString();
                        eggsd.lt_ovary_1 = grfEggsd.Rows[i][colLt1].ToString();
                        eggsd.lt_ovary_2 = grfEggsd.Rows[i][colLt2].ToString();
                        eggsd.endo = grfEggsd.Rows[i][colEndo].ToString();
                        eggsd.medication = grfEggsd.Rows[i][colMedi].ToString();
                        ic.ivfDB.eggsdDB.insertLabOpuEmbryoDev(eggsd, ic.cStf.staff_id);
                    }
                    
                }
            }
        }

        private void initGrfEggSti()
        {
            grfEggsd = new C1FlexGrid();
            grfEggsd.Font = fEdit;
            grfEggsd.Dock = System.Windows.Forms.DockStyle.Fill;
            grfEggsd.Location = new System.Drawing.Point(0, 0);
            grfEggsd.ChangeEdit += GrfEggsd_ChangeEdit;

            //FilterRow fr = new FilterRow(grfExpn);

            pnEggSti.Controls.Add(grfEggsd);

            theme1.SetTheme(grfEggsd, "Office2010Blue");
        }

        private void GrfEggsd_ChangeEdit(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfEggsd.Row == null) return;
            if (grfEggsd.Row < 0) return;
            grfEggsd[grfEggsd.Row, colEdit] = "1";
            grfEggsd.Rows[grfEggsd.Row].StyleNew.BackColor = color;
        }

        private void setGrfEggStiDay()
        {
            //grfDept.Rows.Count = 7;
            grfEggsd.Clear();
            DataTable dt = new DataTable();

            dt = ic.ivfDB.eggsdDB.selectByEggStiId(txtId.Text);
            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfEggsd.Rows.Count = 1;
            grfEggsd.Cols.Count = 15;
            C1TextBox txt = new C1TextBox();
            C1ComboBox cboday3 = new C1ComboBox();
            C1ComboBox cboday3desc1 = new C1ComboBox();
            C1ComboBox cbomedi = new C1ComboBox();
            cboday3.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboday3.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboday3desc1.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboday3desc1.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbomedi.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbomedi.AutoCompleteSource = AutoCompleteSource.ListItems;
            ic.ivfDB.fdtDB.setCboEggStiRtOvary1(cboday3, "");
            ic.ivfDB.fdtDB.setCboEggStiRtOvary2(cboday3desc1, "");
            ic.ivfDB.fdtDB.setCboEggStiMedication(cbomedi, "");
            grfEggsd.Cols[colLt1].Editor = cboday3;
            grfEggsd.Cols[colLt2].Editor = cboday3desc1;
            grfEggsd.Cols[colRt1].Editor = cboday3;
            grfEggsd.Cols[colRt2].Editor = cboday3desc1;
            grfEggsd.Cols[colMedi].Editor = cbomedi;
            grfEggsd.Cols[colDay].Width = 40;
            grfEggsd.Cols[colDate].Width = 100;
            grfEggsd.Cols[colE2].Width = 70;
            grfEggsd.Cols[colLH].Width = 70;
            grfEggsd.Cols[colFSH].Width = 70;
            grfEggsd.Cols[colProlactin].Width = 70;
            grfEggsd.Cols[colRt1].Width = 120;
            grfEggsd.Cols[colRt2].Width = 70;
            grfEggsd.Cols[colLt1].Width = 120;
            grfEggsd.Cols[colLt2].Width = 70;
            grfEggsd.Cols[colEndo].Width = 70;
            grfEggsd.Cols[colMedi].Width = 120;

            grfEggsd.Cols[colE2].AllowSorting = false;
            grfEggsd.Cols[colLH].AllowSorting = false;
            grfEggsd.Cols[colFSH].AllowSorting = false;

            grfEggsd.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";
            grfEggsd.Cols[colDay].Caption = "day";
            grfEggsd.Cols[colDate].Caption = "date";
            grfEggsd.Cols[colE2].Caption = "E2";
            grfEggsd.Cols[colLH].Caption = "LH";
            grfEggsd.Cols[colFSH].Caption = "FSH";
            grfEggsd.Cols[colProlactin].Caption = "Prolactin";
            grfEggsd.Cols[colRt1].Caption = "Rt ovary";
            grfEggsd.Cols[colRt2].Caption = "Rt ovary";
            grfEggsd.Cols[colLt1].Caption = "Lt ovary";
            grfEggsd.Cols[colLt2].Caption = "Lt ovary";
            grfEggsd.Cols[colEndo].Caption = "Endo";
            grfEggsd.Cols[colMedi].Caption = "Medication";
            
            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            int i = 1;
            String staffId = "", checkId = "", dateday2 = "";
            foreach (DataRow row in dt.Rows)
            {
                Row row1 = grfEggsd.Rows.Add();
                //staffId = row[ic.ivfDB.opuEmDevDB.opuEmDev.staff_id].ToString();
                //checkId = row[ic.ivfDB.opuEmDevDB.opuEmDev.checked_id].ToString();
                row1[colId] = row[ic.ivfDB.eggsdDB.eggsd.egg_sti_day_id].ToString();
                row1[colDay] = row[ic.ivfDB.eggsdDB.eggsd.day1].ToString();
                row1[colDate] = row[ic.ivfDB.eggsdDB.eggsd.date].ToString();
                row1[colE2] = row[ic.ivfDB.eggsdDB.eggsd.e2].ToString();
                row1[colLH] = row[ic.ivfDB.eggsdDB.eggsd.lh].ToString();
                row1[colFSH] = row[ic.ivfDB.eggsdDB.eggsd.fsh].ToString();
                row1[colProlactin] = row[ic.ivfDB.eggsdDB.eggsd.prolactin].ToString();
                row1[colRt1] = row[ic.ivfDB.eggsdDB.eggsd.rt_ovary_1].ToString();
                row1[colRt2] = row[ic.ivfDB.eggsdDB.eggsd.rt_ovary_2].ToString();
                row1[colLt1] = row[ic.ivfDB.eggsdDB.eggsd.lt_ovary_1].ToString();
                row1[colLt2] = row[ic.ivfDB.eggsdDB.eggsd.lt_ovary_2].ToString();
                row1[colEndo] = row[ic.ivfDB.eggsdDB.eggsd.endo].ToString();
                row1[colMedi] = row[ic.ivfDB.eggsdDB.eggsd.medication].ToString();
                row1[colEdit] = "";
                row1[0] = i;
                i++;
            }
            grfEggsd.Rows.Add();
            grfEggsd.Cols[colId].Visible = false;
            grfEggsd.Cols[colEdit].Visible = false;
            //grfEggsd.Cols[colProlactin].Visible = false;
            grfEggsd.AutoClipboard = true;
        }
        private void BtnGenEggSti_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String lmpdate = "";
            DateTime lmpdate1 = new DateTime();
            lmpdate = ic.datetoDB(txtLmpDate.Text);
            if (!DateTime.TryParse(lmpdate, out lmpdate1))
            {
                MessageBox.Show("วันที่ LMP Date ไม่ถูกต้อง ", "");
                return;
            }
            if (MessageBox.Show("ต้องการ Day Egg Sti  \nวันที่ LMP Date "+txtLmpDate.Text, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                createEggSti();
                ic.cStf.staff_id = "";
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    int chk = 0;
                    String re = ic.ivfDB.eggsDB.insertEggSti(eggs, ic.cStf.staff_id);
                    if(int.TryParse(re, out chk))
                    {
                        txtId.Value = re;
                        lmpdate = ic.datetoDB(txtLmpDate.Text);
                        if(DateTime.TryParse(lmpdate, out lmpdate1))
                        {
                            for (int i = 1; i <= 17; i++)
                            {
                                lmpdate1 = lmpdate1.AddDays(1);
                                EggStiDay eggsd = new EggStiDay();
                                eggsd.egg_sti_day_id = "";
                                eggsd.egg_sti_id = re;
                                eggsd.day1 = i.ToString();
                                eggsd.date = ic.datetoDB(lmpdate1.Year.ToString()+"-"+lmpdate1.ToString("MM-dd"));
                                eggsd.e2 = "";
                                eggsd.lh = "";
                                eggsd.active = "";
                                eggsd.remark = "";
                                eggsd.fsh = "";
                                eggsd.date_create = "";
                                eggsd.date_modi = "";
                                eggsd.date_cancel = "";
                                eggsd.user_create = "";
                                eggsd.user_modi = "";
                                eggsd.user_cancel = "";
                                eggsd.prolactin = "";
                                eggsd.rt_ovary_1 = "";
                                eggsd.rt_ovary_2 = "";
                                eggsd.lt_ovary_1 = "";
                                eggsd.lt_ovary_2 = "";
                                eggsd.endo = "";
                                eggsd.medication = "";
                                ic.ivfDB.eggsdDB.insertLabOpuEmbryoDev(eggsd, ic.cStf.staff_id);
                            }
                        }
                        setControlEggSti();
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
            eggs.doctor_id = cboDoctor.SelectedItem == null ? "" : ((ComboBoxItem)cboDoctor.SelectedItem).Value;
        }

        private void setControl()
        {
            eggs = ic.ivfDB.eggsDB.selectByPk1(eggstiid);
            if (eggs.egg_sti_id.Equals(""))
            {
                setControl1();
                btnGenEggSti.Enabled = true;
                eggs = ic.ivfDB.eggsDB.selectByVsId(vsid);
                if (eggs.egg_sti_id.Equals(""))
                {
                    eggs = ic.ivfDB.eggsDB.selectByPttId(txtPttId.Text);
                    setControl1();
                }
                else
                {
                    setControl1();
                }
            }
            else
            {
                setControl1();
            }
            setControlEggSti();
        }
        private void setControlEggSti()
        {
            eggs = ic.ivfDB.eggsDB.selectByPk1(txtId.Text);
            txtLmpDate.Value = eggs.lmp_date;
            ic.setC1Combo(cboDoctor, eggs.doctor_id);
            setGrfEggStiDay();
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
            txtPttId.Value = ptt.t_patient_id;
            txtVsId.Value = vs.t_visit_id;

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
            sC.HeaderHeight = 0;
            tC.SelectedTab = tabEggSti;
        }
    }
}
