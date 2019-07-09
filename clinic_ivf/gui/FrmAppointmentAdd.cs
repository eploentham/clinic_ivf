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
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.gui
{
    /*
     * * 62-06-08  1  แก้นัด ให้ donor ไปใช้ของ patient
     * * 62-06-08  2  แก้ ให้ grfVisit ให้แสดง Patient Appointment คือให้ดึงตาม t_patient_id
     */
    public partial class FrmAppointmentAdd : Form
    {
        IvfControl ic;
        String pApmId = "", pttId = "", vsId = "", pid="", printerOld = "";

        C1FlexGrid grfpApmAll, grfpApm, grfpApmDayAll;
        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;
        PatientAppointment pApm;
        Patient ptt;
        AppointmentOld pApmO;
        PatientOld pttO;
        
        Visit vs;

        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        int colId = 1, colAppointment = 4, colDate = 2, colTime = 3, colDoctor = 5, colSp = 6, colNotice = 7, colE2 = 8, colLh = 9, colEndo = 10, colPrl = 10, colFsh = 11, colRt = 12, colLt = 13;
        Image imgCorr, imgTran;
        static String filenamepic = "";
        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetDefaultPrinter(string Printer);

        public FrmAppointmentAdd(IvfControl ic, String papmId, String pttid, String vsid, String pid)
        {
            InitializeComponent();
            this.ic = ic;
            pApmId = papmId;
            pttId = pttid;
            this.pid = pid;
            vsId = vsid;
            InitConfig();
        }
        private void InitConfig()
        {
            pApm = new PatientAppointment();
            ptt = new Patient();
            vs = new Visit();
            pApmO = new AppointmentOld();
            pttO = new PatientOld();
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);

            //theme1.SetTheme(sB, "BeigeOne");
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();

            sB1.Text = "";
            bg = txtHn.BackColor;
            fc = txtHn.ForeColor;
            ff = txtHn.Font;
            imgCorr = Resources.red_checkmark_png_16;
            imgTran = Resources.red_checkmark_png_51;
            ic.ivfDB.bspDB.setCboBsp(cboBsp, "");
            ic.ivfDB.dtrOldDB.setCboDoctor(cboDoctor, "");
            ic.ivfDB.pApmDB.setCboDoctorAnes(cboDtrAnes);

            cboTimepApm = ic.setCboApmTime(cboTimepApm);
            cboTvsTime = ic.setCboApmTime(cboTvsTime);
            cboOPUTime = ic.setCboApmTime(cboOPUTime);
            ic.setCboApmTime(cboETTime);
            ic.setCboApmTime(cboFETTime);
            ic.setCboApmTime(cboOPUTimeDonor);
            ic.setCboApmTime(cboTvsTimeDonor);

            txtDatepApm.Value = System.DateTime.Now.Year.ToString() + "-" + System.DateTime.Now.ToString("MM-dd");
            btnSave.Click += BtnSave_Click;
            txtDatepApm.ValueChanged += TxtDatepApm_ValueChanged;
            btnVoid.Click += BtnVoid_Click;
            chkOPU.CheckedChanged += ChkOPU_CheckedChanged;
            btnSearch.Click += BtnSearch_Click;
            chkTvs.CheckedChanged += ChkTvs_CheckedChanged;
            chkFET.CheckedChanged += ChkFET_CheckedChanged;
            chkET.CheckedChanged += ChkET_CheckedChanged;
            chkOther.CheckedChanged += ChkOther_CheckedChanged;
            chkOPUDonor.CheckedChanged += ChkOPUDonor_CheckedChanged;
            chkTvsDonor.CheckedChanged += ChkTvsDonor_CheckedChanged;
            btnPrint.Click += BtnPrint_Click;

            initGrfpApmAll();
            initGrfpApmVisit();
            initGrfpApmDayAll();
            
            setControl();
            setGrfpApmAll();
            setGrfpApmVisit();
            setGrfpApmDay();

            setTheme();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            PrinterSettings settings = new PrinterSettings();
            printerOld = settings.PrinterName;
            SetDefaultPrinter(ic.iniC.printerAppointment);

            FrmReport frm = new FrmReport(ic);
            DataTable dt = new DataTable();
            DataTable dtOld = new DataTable();
            dt = ic.ivfDB.pApmDB.selectAppointmentByPk(txtID.Text);
            dtOld = ic.ivfDB.pApmOldDB.selectAppointmentByPk(txtID.Text);

            String date1 = "";
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.pApmDB.pApm.patient_appointment_date].ToString());
            dt.Rows[0][ic.ivfDB.pApmDB.pApm.patient_appointment_date] = date1;

            frm.setAppointmentPatient(dt);
            frm.ShowDialog(this);

            SetDefaultPrinter(printerOld);
        }

        private void ChkTvsDonor_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            txtTvsDayDonor.Enabled = chkTvsDonor.Checked ? true : false;
            cboTvsTimeDonor.Enabled = chkTvsDonor.Checked ? true : false;
        }

        private void ChkOPUDonor_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            cboOPUTimeDonor.Enabled = chkOPUDonor.Checked ? true : false;
            cboDtrAnes.Enabled = chkOPUDonor.Checked ? true : false;
            
        }

        private void ChkOther_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            txtOther.Enabled = chkOther.Checked ? true : false;
        }

        private void ChkET_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //cboETTime
            cboETTime.Enabled = chkET.Checked ? true : false;
        }

        private void ChkFET_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //txtTvsDay.Enabled = chkTvs.Checked ? true : false;
            cboFETTime.Enabled = chkFET.Checked ? true : false;
        }

        private void TxtRemarkpApm_TextChanged(object sender, EventArgs e)
        {

        }

        private void setTheme()
        {
            theme1.SetTheme(groupBox1, ic.iniC.themeApplication);
            theme1.SetTheme(groupBox2, ic.iniC.themeApplication);
            theme1.SetTheme(groupBox3, ic.iniC.themeApplication);
            theme1.SetTheme(panel3, ic.iniC.themeApplication);
            theme1.SetTheme(panel2, ic.iniC.themeApplication);
            theme1.SetTheme(panel4, ic.iniC.themeApplication);
            theme1.SetTheme(splitContainer1, ic.iniC.themeApplication);
            foreach (Control ctl in groupBox1.Controls)
            {
                theme1.SetTheme(ctl, ic.iniC.themeApplication);
            }
            foreach (Control ctl in groupBox2.Controls)
            {
                theme1.SetTheme(ctl, ic.iniC.themeApplication);
            }
            foreach (Control ctl in groupBox3.Controls)
            {
                theme1.SetTheme(ctl, ic.iniC.themeApplication);
            }
            foreach (Control ctl in panel2.Controls)
            {
                theme1.SetTheme(ctl, ic.iniC.themeApplication);
            }
            foreach (Control ctl in tabPtt.Controls)
            {
                theme1.SetTheme(ctl, ic.iniC.themeApplication);
            }
            foreach (Control ctl in tabDonor.Controls)
            {
                theme1.SetTheme(ctl, ic.iniC.themeApplication);
            }
            foreach (Control ctl in tabVisit.Controls)
            {
                theme1.SetTheme(ctl, ic.iniC.themeApplication);
            }
            foreach (Control ctl in panel4.Controls)
            {
                try
                {
                    theme1.SetTheme(ctl, ic.iniC.themeApplication);
                }
                catch (Exception ex)
                {

                }

            }
        }
        private void ChkTvs_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            txtTvsDay.Enabled = chkTvs.Checked ? true : false;
            cboTvsTime.Enabled = chkTvs.Checked ? true : false;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmSearchHn frm = new FrmSearchHn(ic, FrmSearchHn.StatusConnection.host, FrmSearchHn.StatusSearch.PttSearch, FrmSearchHn.StatusSearchTable.VisitSearch);
            frm.ShowDialog(this);
            txtHn.Value = ic.sVsOld.PIDS;
            txtName.Value = ic.sVsOld.PName;
            txtPttId.Value = ic.sVsOld.PID;
        }

        private void ChkOPU_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            txtOPURemark.Enabled = chkOPU.Checked ? true : false;
            cboOPUTime.Enabled = chkOPU.Checked ? true : false;
            if (chkOPU.Checked)
            {
                txtRemarkpApm.Value = "Not Allow to drink or eat from (งดน้ำ งดอาหาร ตั้งแต่เวลา)";
            }
        }

        private void BtnVoid_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //if (btnVoid.Text.Equals("Confirm"))
            //{
                stt.Hide();
                btnVoid.Text = "Void";
                ic.cStf.staff_id = "";
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    if (ic.iniC.statusAppDonor.Equals("1"))
                    {
                        String re = ic.ivfDB.pApmDB.VoidPatientAppointment(txtID.Text, txtStfConfirmID.Text);
                        int chk = 0;
                        //Patient ptt1 = new Patient();
                        if (re.Equals("1")) // ตอน update
                        {
                            re = ic.ivfDB.vsDB.updateOpenStatusNurse(txtVsId.Text);
                            re = ic.ivfDB.vsDB.updateStatusVoidAppointment(txtVsId.Text);
                            setGrfpApmAll();
                            setGrfpApmVisit();
                            setGrfpApmDay();
                            //re = txtID.Text;
                            //setControlEnable(false);
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
                    //setPatient();
                    //String re = ic.ivfDB.pttDB.insertPatient(ptt, txtStfConfirmID.Text);
            //}
            //else
            //{
            //    ic.cStf.staff_id = "";
            //    FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            //    frm.ShowDialog(this);
            //    if (!ic.cStf.staff_id.Equals(""))
            //    {
            //        txtUserReq.Value = ic.cStf.staff_fname_t + " " + ic.cStf.staff_lname_t;
            //        txtStfConfirmID.Value = ic.cStf.staff_id;
            //        btnVoid.Text = "Confirm";
            //        //btnSave.Image = Resources.Add_ticket_24;
            //        stt.Show("<p><b>สวัสดี</b></p>คุณ " + ic.cStf.staff_fname_t + " " + ic.cStf.staff_lname_t + "<br> กรุณายินยันการ confirm อีกครั้ง", btnSave);
            //        btnVoid.Focus();
            //    }
            //    else
            //    {
            //        btnVoid.Text = "Void";
            //        //btnSave.Image = Resources.download_database24;
            //    }
            //}
        }

        private void TxtDatepApm_ValueChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setGrfpApmDay();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //if (btnSave.Text.Equals("Confirm"))
            //{
                
            //}
            //else
            //{
            ic.cStf.staff_id = "";
            String dt1 = "";
            DateTime dt = new DateTime();
            dt1 = txtDatepApm.Text;
            if (!DateTime.TryParse(dt1, out dt))
            {
                MessageBox.Show("วันนัด ไม่ถูกต้อง", "");
                return;
            }
            if (cboTimepApm.Text.Equals(""))
            {
                MessageBox.Show("เวลานัด ไม่ถูกต้อง", "");
                return;
            }
            FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            frm.ShowDialog(this);
            if (!ic.cStf.staff_id.Equals(""))
            {
                txtUserReq.Value = ic.cStf.staff_fname_t + " " + ic.cStf.staff_lname_t;
                txtStfConfirmID.Value = ic.cStf.staff_id;
                btnSave.Text = "Confirm";
                btnSave.Image = Resources.Add_ticket_24;
                stt.Show("<p><b>สวัสดี</b></p>คุณ " + ic.cStf.staff_fname_t + " " + ic.cStf.staff_lname_t + "<br> กรุณายินยันการ confirm อีกครั้ง", txtAppointment);
                btnSave.Focus();

                stt.Hide();
                String re = "";
                // check ว่า มี patient ยัง ถ้ายังไม่มี ให้ insert patient
                //เป็นการเอา ข้อมูลจาก database เดิม
                //Patient pttTemp = new Patient();
                //pttTemp = ic.ivfDB.pttDB.selectByIdOld(txtPttIdOld.Text);
                //if (pttTemp.t_patient_id.Equals(""))
                //{
                //    C1ComboBox cbo = new C1ComboBox();
                //    ic.ivfDB.fpnDB.setCboNation(cbo, "");

                //    pttO = ic.ivfDB.pttOldDB.selectByPk1(pttId);
                //    ic.setC1ComboByName(cbo, pttO.Nationality);
                //    pttTemp = new Patient();
                //    pttTemp = ic.ivfDB.pttDB.setPatient1(pttTemp);
                //    pttTemp.t_patient_id_old = pttO.PID;
                //    pttTemp.patient_hn = pttO.PIDS;
                //    pttTemp.patient_firstname_e = pttO.PName;
                //    pttTemp.patient_lastname_e = pttO.PSurname;
                //    pttTemp.patient_firstname = pttO.OName;
                //    pttTemp.patient_lastname = pttO.OSurname;
                //    pttTemp.f_patient_prefix_id = pttO.SurfixID;

                //    pttTemp.f_sex_id = pttO.SexID;
                //    pttTemp.passport = pttO.IDNumber;
                //    pttTemp.patient_birthday = ic.datetoDB(pttO.DateOfBirth);
                //    pttTemp.email = pttO.Email;
                //    pttTemp.f_patient_nation_id = cbo.SelectedItem == null ? "" : ((ComboBoxItem)cbo.SelectedItem).Value;
                //    String[] name = pttO.EmergencyPersonalContact.Split(' ');
                //    if (name.Length > 1)
                //    {
                //        pttTemp.patient_contact_firstname = name[0];
                //        pttTemp.patient_contact_lastname = name[1];
                //    }
                //    ic.ivfDB.oAgnDB.setCboAgent(cbo, "");
                //    ic.setC1Combo(cbo, pttO.AgentID);
                //    pttTemp.agent = cbo.SelectedItem == null ? "" : ((ComboBoxItem)cbo.SelectedItem).Value;
                //    String re1 = ic.ivfDB.pttDB.insertPatient(pttTemp, txtStfConfirmID.Text);
                //    ptt.t_patient_id = re1;
                //    txtPttId.Value = re1;
                //    //pttTemp.patient_birthday = pttO.DateOfBirth;
                //    //pttTemp.patient_birthday = pttO.DateOfBirth;
                //}
                setPatientAppointment();
                re = ic.ivfDB.pApmDB.insertPatientAppointment(pApm, txtStfConfirmID.Text);

                //txtID.Value = (!txtID.Text.Equals("") && re.Equals("1")) ? re : "";        //update
                long chk = 0;
                if (long.TryParse(re, out chk))
                {
                    txtID.Value = txtID.Text.Equals("") ? re : txtID.Text;
                    setAppointmentOld();
                    //if (!ic.iniC.statusAppDonor.Equals("1"))
                    //{
                    String re1 = ic.ivfDB.pApmOldDB.insertAppointmentOld(pApmO, txtStfConfirmID.Text);
                    //txtIDOld.Value = re1;
                    txtIDOld.Value = txtIDOld.Text.Equals("") ? re1 : txtIDOld.Text;
                    String re2 = ic.ivfDB.pApmDB.updateAppointmentIdOld(txtID.Text, re1);
                    //if (int.TryParse(re1, out chk))
                    //{
                    //if (txtID.Text.Equals(""))
                    //{
                    //    //PatientOld pttOld = new PatientOld();
                    //    //pttOld = ic.ivfDB.pttOldDB.selectByPk1(re1);
                    //    String re2 = ic.ivfDB.pttDB.updatePID(re, re1);
                    //    if (int.TryParse(re2, out chk))
                    //    {
                    //String re4 = ic.ivfDB.vsDB.updateCloseStatusNurse(txtVsId.Text);
                    String re3 = ic.ivfDB.vsDB.updateStatusAppointment(txtVsId.Text, txtID.Text);

                    btnSave.Text = "Save";
                    btnSave.Image = Resources.accept_database24;
                    //        txtID.Value = re;
                    //        txtPid.Focus();
                    //    }
                    //}
                    //}
                    //}

                    System.Threading.Thread.Sleep(500);
                    setGrfpApmAll();
                    setGrfpApmVisit();
                    setGrfpApmDay();
                    //this.Dispose();
                }
            }
            else
            {
                btnSave.Text = "Save";
                btnSave.Image = Resources.download_database24;
            }
            //}
        }

        private void setControl()
        {
            ptt = ic.ivfDB.pttDB.selectByPk1(pttId);
            vs = ic.ivfDB.vsDB.selectByPk1(vsId);
            pApm = ic.ivfDB.pApmDB.selectByPk1(pApmId);
            if (ptt.t_patient_id.Equals(""))
            {
                ptt = ic.ivfDB.pttDB.selectByIDold(pid);
            }
            txtPttId.Value = ptt.t_patient_id;
            txtVsId.Value = vs.t_visit_id;
            txtHn.Value = ptt.patient_hn;
            txtName.Value = ptt.Name;
            txtRemark.Value = ptt.remark;
            if (!pApm.t_patient_appointment_id.Equals(""))
            {
                txtDatepApm.Value = pApm.patient_appointment_date;
            }
            ic.setC1Combo(cboTimepApm, pApm.patient_appointment_time);
            ic.setC1Combo(cboBsp, pApm.patient_appointment_servicepoint);
            chkE2.Checked = pApm.e2.Equals("1") ? true : false;
            chkLh.Checked = pApm.lh.Equals("1") ? true : false;
            chkFsh.Checked = pApm.fsh.Equals("1") ? true : false;
            chkPrl.Checked = pApm.prl.Equals("1") ? true : false;
            chkTvs.Checked = pApm.tvs.Equals("1") ? true : false;

            chkRE2.Checked = pApm.repeat_e2.Equals("1") ? true : false;
            chkRLh.Checked = pApm.repeat_lh.Equals("1") ? true : false;
            chkRFsh.Checked = pApm.repeat_fsh.Equals("1") ? true : false;
            chkRPrl.Checked = pApm.repeat_prl.Equals("1") ? true : false;
            chkSperm.Checked = pApm.sperm_collect.Equals("1") ? true : false;
            //chkE2.Checked = pApm.e2.Equals("1") ? true : false;
            chkET.Checked = pApm.et.Equals("1") ? true : false;
            chkFET.Checked = pApm.fet.Equals("1") ? true : false;
            chkOther.Checked = pApm.e2.Equals("1") ? true : false;
            txtRemark.Value = pApm.remark;
            ic.setC1Combo(cboDoctor, pApm.patient_appointment_doctor);
            txtID.Value = pApm.t_patient_appointment_id;
            chkOPU.Checked = pApm.opu.Equals("1") ? true : false;
            ic.setC1Combo(cboDtrAnes, pApm.doctor_anes);
            cboDtrAnes.Enabled = chkOPU.Checked ? true : false;
            txtTvsDay.Value = pApm.tvs_day;
            txtTvsDay.Enabled = chkTvs.Checked ? true : false;
            ic.setC1Combo(cboTvsTime, pApm.tvs_time);
            ic.setC1Combo(cboOPUTime, pApm.opu_time);
            chkHormoneTest.Checked = pApm.hormone_test.Equals("1") ? true : false;
            chkHCG.Checked = pApm.beta_hgc.Equals("1") ? true : false;
            chkOther.Checked = pApm.other.Equals("1") ? true : false;
            txtOther.Value = pApm.other_remark;
            ic.setC1Combo(cboETTime, pApm.et_time);
            ic.setC1Combo(cboFETTime, pApm.fet_time);
            ic.setC1Combo(cboOPUTime, pApm.opu_time);
            ic.setC1Combo(cboTvsTime, pApm.tvs_time);
            txtTvsDay.Value = pApm.tvs_day;
            //chkOPU

            ChkTvs_CheckedChanged(null, null);
            ChkOPU_CheckedChanged(null, null);
            ChkFET_CheckedChanged(null, null);
            ChkET_CheckedChanged(null, null);
            ChkOther_CheckedChanged(null, null);
            ChkTvsDonor_CheckedChanged(null, null);
            ChkOPUDonor_CheckedChanged(null, null);

            //pttO = ic.ivfDB.pttOldDB.selectByPk1(pttId);  //  -1
            //txtPttIdOld.Value = pttO.PID;  //  -1
            //txtHn.Value = pttO.PIDS;  //  -1
            //txtName.Value = pttO.FullName;  //  -1

            txtOPURemark.Value = "Not Allow to drink or eat from (งดน้ำ งดอาหาร ตั้งแต่เวลา)";
            txtAppointment.Value = pApm.patient_appointment;

            if (pApm.patient_appointment_servicepoint.Equals("") && cboBsp.Items.Count>3)
            {
                cboBsp.SelectedIndex = 3;
            }
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
                setPic(new Bitmap(ic.ftpC.download(filenamepic)));
            }
            catch (Exception ex)
            {

            }
        }
        private void setPic(Bitmap bitmap)
        {
            m_picPhoto.Image = bitmap;
            m_picPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void initGrfpApmAll()
        {
            grfpApmAll = new C1FlexGrid();
            grfpApmAll.Font = fEdit;
            grfpApmAll.Dock = System.Windows.Forms.DockStyle.Fill;
            grfpApmAll.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            //grfpApmAll.ContextMenu = menuGw;
            panel5.Controls.Add(grfpApmAll);

            theme1.SetTheme(grfpApmAll, "Office2016Colorful");

        }
        private void initGrfpApmVisit()
        {
            grfpApm = new C1FlexGrid();
            grfpApm.Font = fEdit;
            grfpApm.Dock = System.Windows.Forms.DockStyle.Fill;
            grfpApm.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            //grfpApmAll.ContextMenu = menuGw;
            pnVisit.Controls.Add(grfpApm);

            theme1.SetTheme(grfpApm, "Office2016Colorful");

        }
        private void initGrfpApmDayAll()
        {
            grfpApmDayAll = new C1FlexGrid();
            grfpApmDayAll.Font = fEdit;
            grfpApmDayAll.Dock = System.Windows.Forms.DockStyle.Fill;
            grfpApmDayAll.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            //grfpApmAll.ContextMenu = menuGw;
            pnDay.Controls.Add(grfpApmDayAll);

            theme1.SetTheme(grfpApmDayAll, "Office2016Colorful");

        }
        private void setGrfpApmAll()
        {
            //grfDept.Rows.Count = 7;
            grfpApmAll.Clear();
            DataTable dt = new DataTable();

            dt = ic.ivfDB.pApmDB.selectByPtt(ptt.t_patient_id);

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfpApmAll.Rows.Count = 1;
            grfpApmAll.Cols.Count = 14;
            C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfpApmAll.Cols[colNotice].Editor = txt;
            grfpApmAll.Cols[colAppointment].Editor = txt;
            grfpApmAll.Cols[colDoctor].Editor = txt;
            Column colE21 = grfpApmAll.Cols[colE2];
            colE21.DataType = typeof(Image);
            Column colLh1 = grfpApmAll.Cols[colLh];
            colLh1.DataType = typeof(Image);
            Column colEndo1 = grfpApmAll.Cols[colEndo];
            colEndo1.DataType = typeof(Image);
            Column colPrl1 = grfpApmAll.Cols[colPrl];
            colPrl1.DataType = typeof(Image);
            Column colFsh1 = grfpApmAll.Cols[colFsh];
            colFsh1.DataType = typeof(Image);
            Column colRt1 = grfpApmAll.Cols[colRt];
            colRt1.DataType = typeof(Image);
            Column colLt1 = grfpApmAll.Cols[colLt];
            colLt1.DataType = typeof(Image);

            grfpApmAll.Cols[colDate].Width = 100;
            grfpApmAll.Cols[colTime].Width = 80;
            grfpApmAll.Cols[colAppointment].Width = 120;
            grfpApmAll.Cols[colDoctor].Width = 100;
            grfpApmAll.Cols[colSp].Width = 80;
            grfpApmAll.Cols[colNotice].Width = 200;
            grfpApmAll.Cols[colE2].Width = 60;
            grfpApmAll.Cols[colLh].Width = 60;
            grfpApmAll.Cols[colEndo].Width = 60;
            grfpApmAll.Cols[colPrl].Width = 60;
            grfpApmAll.Cols[colFsh].Width = 60;
            grfpApmAll.Cols[colRt].Width = 60;
            grfpApmAll.Cols[colLt].Width = 60;

            grfpApmAll.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfpApmAll.Cols[colDate].Caption = "Date";
            grfpApmAll.Cols[colTime].Caption = "time";
            grfpApmAll.Cols[colAppointment].Caption = "นัด";
            grfpApmAll.Cols[colDoctor].Caption = "Doctor";
            grfpApmAll.Cols[colSp].Caption = "จุดบริการ";
            grfpApmAll.Cols[colNotice].Caption = "แจ้ง";
            grfpApmAll.Cols[colE2].Caption = "E2";
            grfpApmAll.Cols[colLh].Caption = "LH";
            grfpApmAll.Cols[colEndo].Caption = "Endo";
            grfpApmAll.Cols[colPrl].Caption = "PRL";
            grfpApmAll.Cols[colFsh].Caption = "FSH";
            grfpApmAll.Cols[colRt].Caption = "Rt";
            grfpApmAll.Cols[colLt].Caption = "Lt";

            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("แก้ไข Appointment", new EventHandler(ContextMenu_edit_papm));
            grfpApmAll.ContextMenu = menuGw;

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                Row row1 = grfpApmAll.Rows.Add();
                row1[0] = i;
                row1[colId] = row[ic.ivfDB.pApmDB.pApm.t_patient_appointment_id].ToString();
                row1[colDate] = ic.datetoShow(row[ic.ivfDB.pApmDB.pApm.patient_appointment_date].ToString());
                row1[colTime] = row[ic.ivfDB.pApmDB.pApm.patient_appointment_time].ToString();
                row1[colAppointment] = row[ic.ivfDB.pApmDB.pApm.patient_appointment].ToString();
                row1[colDoctor] = row[ic.ivfDB.pApmDB.pApm.dtr_name];
                row1[colSp] = row["service_point_description"].ToString();
                row1[colNotice] = row[ic.ivfDB.pApmDB.pApm.patient_appointment_notice].ToString();

                //row1[colE2] = row[ic.ivfDB.pApmDB.pApm.e2].ToString();
                //row1[colLh] = row[ic.ivfDB.pApmDB.pApm.lh].ToString();
                //row1[colEndo] = row[ic.ivfDB.pApmDB.pApm.endo].ToString();
                //row1[colPrl] = row[ic.ivfDB.pApmDB.pApm.prl].ToString();
                //row1[colFsh] = row[ic.ivfDB.pApmDB.pApm.fsh].ToString();
                //row1[colRt] = row[ic.ivfDB.pApmDB.pApm.rt_ovary].ToString();
                //row1[colLt] = row[ic.ivfDB.pApmDB.pApm.lt_ovary].ToString();

                row1[colE2] = row[ic.ivfDB.pApmDB.pApm.e2] == null ? imgTran : row[ic.ivfDB.pApmDB.pApm.e2].ToString().Equals("1") ? imgCorr : imgTran;
                row1[colLh] = row[ic.ivfDB.pApmDB.pApm.lh] == null ? imgTran : row[ic.ivfDB.pApmDB.pApm.lh].ToString().Equals("1") ? imgCorr : imgTran;
                row1[colEndo] = row[ic.ivfDB.pApmDB.pApm.endo] == null ? imgTran : row[ic.ivfDB.pApmDB.pApm.endo].ToString().Equals("1") ? imgCorr : imgTran;
                row1[colPrl] = row[ic.ivfDB.pApmDB.pApm.prl] == null ? imgTran : row[ic.ivfDB.pApmDB.pApm.prl].ToString().Equals("1") ? imgCorr : imgTran;
                row1[colFsh] = row[ic.ivfDB.pApmDB.pApm.fsh] == null ? imgTran : row[ic.ivfDB.pApmDB.pApm.fsh].ToString().Equals("1") ? imgCorr : imgTran;
                row1[colRt] = row[ic.ivfDB.pApmDB.pApm.rt_ovary] == null ? imgTran : row[ic.ivfDB.pApmDB.pApm.rt_ovary].ToString().Equals("1") ? imgCorr : imgTran;
                row1[colLt] = row[ic.ivfDB.pApmDB.pApm.lt_ovary] == null ? imgTran : row[ic.ivfDB.pApmDB.pApm.lt_ovary].ToString().Equals("1") ? imgCorr : imgTran;
                //if (i % 2 == 0)
                //    grfPtt.Rows[i].StyleNew.BackColor = color;
                i++;
            }
            grfpApmAll.Cols[colE2].AllowEditing = false;
            grfpApmAll.Cols[colLh].AllowEditing = false;
            grfpApmAll.Cols[colEndo].AllowEditing = false;
            grfpApmAll.Cols[colPrl].AllowEditing = false;
            grfpApmAll.Cols[colFsh].AllowEditing = false;
            grfpApmAll.Cols[colRt].AllowEditing = false;
            grfpApmAll.Cols[colLt].AllowEditing = false;
            //menuGw = new ContextMenu();
            //grfpApmAll.ContextMenu = menuGw;
            grfpApmAll.Cols[colId].Visible = false;
            theme1.SetTheme(grfpApmAll, ic.theme);

        }
        private void setGrfpApmVisit()
        {
            //grfDept.Rows.Count = 7;
            grfpApm.Clear();
            DataTable dt = new DataTable();

            //dt = ic.ivfDB.pApmDB.selectByVisitId(vsId);     //-2
            dt = ic.ivfDB.pApmDB.selectByPtt(pttId);     //+2
            //if (dt.Rows.Count <= 0)     //-2
            //{     //-2
            //    VisitOld vsOld = new VisitOld();     //-2
            //    vsOld = ic.ivfDB.ovsDB.selectByPk1(vsId);     //-2
            //    Patient ptt = new Patient();     //-2
            //    ptt = ic.ivfDB.pttDB.selectByIdOld(vsOld.PID);     //-2
            //    dt = ic.ivfDB.pApmDB.selectByPtt(ptt.t_patient_id);     //-2
            //}     //-2

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfpApm.Rows.Count = 1;
            grfpApm.Cols.Count = 14;
            C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfpApm.Cols[colNotice].Editor = txt;
            grfpApm.Cols[colAppointment].Editor = txt;
            grfpApm.Cols[colDoctor].Editor = txt;
            Column colE21 = grfpApm.Cols[colE2];
            colE21.DataType = typeof(Image);
            Column colLh1 = grfpApm.Cols[colLh];
            colLh1.DataType = typeof(Image);
            Column colEndo1 = grfpApm.Cols[colEndo];
            colEndo1.DataType = typeof(Image);
            Column colPrl1 = grfpApm.Cols[colPrl];
            colPrl1.DataType = typeof(Image);
            Column colFsh1 = grfpApm.Cols[colFsh];
            colFsh1.DataType = typeof(Image);
            Column colRt1 = grfpApm.Cols[colRt];
            colRt1.DataType = typeof(Image);
            Column colLt1 = grfpApm.Cols[colLt];
            colLt1.DataType = typeof(Image);

            grfpApm.Cols[colDate].Width = 100;
            grfpApm.Cols[colTime].Width = 80;
            grfpApm.Cols[colAppointment].Width = 120;
            grfpApm.Cols[colDoctor].Width = 100;
            grfpApm.Cols[colSp].Width = 80;
            grfpApm.Cols[colNotice].Width = 200;
            grfpApm.Cols[colE2].Width = 50;
            grfpApm.Cols[colLh].Width = 50;
            grfpApm.Cols[colEndo].Width = 50;
            grfpApm.Cols[colPrl].Width = 50;
            grfpApm.Cols[colFsh].Width = 50;
            grfpApm.Cols[colRt].Width = 50;
            grfpApm.Cols[colLt].Width = 50;

            grfpApm.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfpApm.Cols[colDate].Caption = "Date";
            grfpApm.Cols[colTime].Caption = "time";
            grfpApm.Cols[colAppointment].Caption = "นัด";
            grfpApm.Cols[colDoctor].Caption = "Doctor";
            grfpApm.Cols[colSp].Caption = "จุดบริการ";
            grfpApm.Cols[colNotice].Caption = "แจ้ง";
            grfpApm.Cols[colE2].Caption = "E2";
            grfpApm.Cols[colLh].Caption = "LH";
            grfpApm.Cols[colEndo].Caption = "Endo";
            grfpApm.Cols[colPrl].Caption = "PRL";
            grfpApm.Cols[colFsh].Caption = "FSH";
            grfpApm.Cols[colRt].Caption = "Rt";
            grfpApm.Cols[colLt].Caption = "Lt";

            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("แก้ไข Appointment", new EventHandler(ContextMenu_edit));
            grfpApm.ContextMenu = menuGw;

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                Row row1 = grfpApm.Rows.Add();
                row1[0] = i;
                row1[colId] = row[ic.ivfDB.pApmDB.pApm.t_patient_appointment_id].ToString();
                row1[colDate] = ic.datetoShow(row[ic.ivfDB.pApmDB.pApm.patient_appointment_date].ToString());
                row1[colTime] = row[ic.ivfDB.pApmDB.pApm.patient_appointment_time].ToString();
                row1[colAppointment] = row[ic.ivfDB.pApmDB.pApm.patient_appointment].ToString();
                row1[colDoctor] = row[ic.ivfDB.pApmDB.pApm.dtr_name];
                row1[colSp] = row["service_point_description"].ToString();
                row1[colNotice] = row[ic.ivfDB.pApmDB.pApm.patient_appointment_notice].ToString();

                //row1[colE2] = row[ic.ivfDB.pApmDB.pApm.e2].ToString();
                //row1[colLh] = row[ic.ivfDB.pApmDB.pApm.lh].ToString();
                //row1[colEndo] = row[ic.ivfDB.pApmDB.pApm.endo].ToString();
                //row1[colPrl] = row[ic.ivfDB.pApmDB.pApm.prl].ToString();
                //row1[colFsh] = row[ic.ivfDB.pApmDB.pApm.fsh].ToString();
                //row1[colRt] = row[ic.ivfDB.pApmDB.pApm.rt_ovary].ToString();
                //row1[colLt] = row[ic.ivfDB.pApmDB.pApm.lt_ovary].ToString();
                row1[colE2] = row[ic.ivfDB.pApmDB.pApm.e2] == null ? imgTran : row[ic.ivfDB.pApmDB.pApm.e2].ToString().Equals("1") ? imgCorr : imgTran;
                row1[colLh] = row[ic.ivfDB.pApmDB.pApm.lh] == null ? imgTran : row[ic.ivfDB.pApmDB.pApm.lh].ToString().Equals("1") ? imgCorr : imgTran;
                row1[colEndo] = row[ic.ivfDB.pApmDB.pApm.endo] == null ? imgTran : row[ic.ivfDB.pApmDB.pApm.endo].ToString().Equals("1") ? imgCorr : imgTran;
                row1[colPrl] = row[ic.ivfDB.pApmDB.pApm.prl] == null ? imgTran : row[ic.ivfDB.pApmDB.pApm.prl].ToString().Equals("1") ? imgCorr : imgTran;
                row1[colFsh] = row[ic.ivfDB.pApmDB.pApm.fsh] == null ? imgTran : row[ic.ivfDB.pApmDB.pApm.fsh].ToString().Equals("1") ? imgCorr : imgTran;
                row1[colRt] = row[ic.ivfDB.pApmDB.pApm.rt_ovary] == null ? imgTran : row[ic.ivfDB.pApmDB.pApm.rt_ovary].ToString().Equals("1") ? imgCorr : imgTran;
                row1[colLt] = row[ic.ivfDB.pApmDB.pApm.lt_ovary] == null ? imgTran : row[ic.ivfDB.pApmDB.pApm.lt_ovary].ToString().Equals("1") ? imgCorr : imgTran;
                //if (i % 2 == 0)
                //    grfPtt.Rows[i].StyleNew.BackColor = color;
                i++;
            }
            //menuGw = new ContextMenu();
            //grfpApmVisit.ContextMenu = menuGw;
            grfpApm.Cols[colE2].AllowEditing = false;
            grfpApm.Cols[colLh].AllowEditing = false;
            grfpApm.Cols[colEndo].AllowEditing = false;
            grfpApm.Cols[colPrl].AllowEditing = false;
            grfpApm.Cols[colFsh].AllowEditing = false;
            grfpApm.Cols[colRt].AllowEditing = false;
            grfpApm.Cols[colLt].AllowEditing = false;
            grfpApm.Cols[colId].Visible = false;
            theme1.SetTheme(grfpApm, ic.theme);

        }
        private void ContextMenu_edit(object sender, System.EventArgs e)
        {
            String chk = "", name = "", id = "";
            id = grfpApm[grfpApm.Row, colId] != null ? grfpApm[grfpApm.Row, colId].ToString() : "";
            pApmId = id;
            setControl();
            
        }
        private void ContextMenu_edit_papm(object sender, System.EventArgs e)
        {
            String chk = "", name = "", id = "";
            id = grfpApmAll[grfpApmAll.Row, colId] != null ? grfpApmAll[grfpApmAll.Row, colId].ToString() : "";
            pApmId = id;
            setControl();

        }
        private void setGrfpApmDay()
        {
            //grfDept.Rows.Count = 7;
            grfpApmDayAll.Clear();
            DataTable dt = new DataTable();

            dt = ic.ivfDB.pApmDB.selectByDay(ic.datetoDB(txtDatepApm.Text), ic.datetoDB(txtDatepApm.Text));

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfpApmDayAll.Rows.Count = 1;
            grfpApmDayAll.Cols.Count = 14;
            C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfpApmDayAll.Cols[colNotice].Editor = txt;
            grfpApmDayAll.Cols[colAppointment].Editor = txt;
            grfpApmDayAll.Cols[colDoctor].Editor = txt;
            Column colE21 = grfpApmDayAll.Cols[colE2];
            colE21.DataType = typeof(Image);
            Column colLh1 = grfpApmDayAll.Cols[colLh];
            colLh1.DataType = typeof(Image);
            Column colEndo1 = grfpApmDayAll.Cols[colEndo];
            colEndo1.DataType = typeof(Image);
            Column colPrl1 = grfpApmDayAll.Cols[colPrl];
            colPrl1.DataType = typeof(Image);
            Column colFsh1 = grfpApmDayAll.Cols[colFsh];
            colFsh1.DataType = typeof(Image);
            Column colRt1 = grfpApmDayAll.Cols[colRt];
            colRt1.DataType = typeof(Image);
            Column colLt1 = grfpApmDayAll.Cols[colLt];
            colLt1.DataType = typeof(Image);

            grfpApmDayAll.Cols[colDate].Width = 100;
            grfpApmDayAll.Cols[colTime].Width = 80;
            grfpApmDayAll.Cols[colAppointment].Width = 120;
            grfpApmDayAll.Cols[colDoctor].Width = 100;
            grfpApmDayAll.Cols[colSp].Width = 80;
            grfpApmDayAll.Cols[colNotice].Width = 200;
            grfpApmDayAll.Cols[colE2].Width = 50;
            grfpApmDayAll.Cols[colLh].Width = 50;
            grfpApmDayAll.Cols[colEndo].Width = 50;
            grfpApmDayAll.Cols[colPrl].Width = 50;
            grfpApmDayAll.Cols[colFsh].Width = 50;
            grfpApmDayAll.Cols[colRt].Width = 50;
            grfpApmDayAll.Cols[colLt].Width = 50;

            grfpApmDayAll.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfpApmDayAll.Cols[colDate].Caption = "Date";
            grfpApmDayAll.Cols[colTime].Caption = "time";
            grfpApmDayAll.Cols[colAppointment].Caption = "นัด";
            grfpApmDayAll.Cols[colDoctor].Caption = "Doctor";
            grfpApmDayAll.Cols[colSp].Caption = "จุดบริการ";
            grfpApmDayAll.Cols[colNotice].Caption = "แจ้ง";
            grfpApmDayAll.Cols[colE2].Caption = "E2";
            grfpApmDayAll.Cols[colLh].Caption = "LH";
            grfpApmDayAll.Cols[colEndo].Caption = "Endo";
            grfpApmDayAll.Cols[colPrl].Caption = "PRL";
            grfpApmDayAll.Cols[colFsh].Caption = "FSH";
            grfpApmDayAll.Cols[colRt].Caption = "Rt";
            grfpApmDayAll.Cols[colLt].Caption = "Lt";

            //ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&ออก Visit", new EventHandler(ContextMenu_edit));
            //grfpApmDayAll.ContextMenu = menuGw;

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                Row row1 = grfpApmDayAll.Rows.Add();
                row1[0] = i;
                row1[colId] = row[ic.ivfDB.pApmDB.pApm.t_patient_appointment_id].ToString();
                row1[colDate] = ic.datetoShow(row[ic.ivfDB.pApmDB.pApm.patient_appointment_date].ToString());
                row1[colTime] = row[ic.ivfDB.pApmDB.pApm.patient_appointment_time].ToString();
                row1[colAppointment] = row[ic.ivfDB.pApmDB.pApm.patient_appointment].ToString();
                row1[colDoctor] = row[ic.ivfDB.pApmDB.pApm.dtr_name];
                row1[colSp] = row["service_point_description"].ToString();
                row1[colNotice] = row[ic.ivfDB.pApmDB.pApm.patient_appointment_notice].ToString();

                //row1[colE2] = row[ic.ivfDB.pApmDB.pApm.e2].ToString();
                //row1[colLh] = row[ic.ivfDB.pApmDB.pApm.lh].ToString();
                //row1[colEndo] = row[ic.ivfDB.pApmDB.pApm.endo].ToString();
                //row1[colPrl] = row[ic.ivfDB.pApmDB.pApm.prl].ToString();
                //row1[colFsh] = row[ic.ivfDB.pApmDB.pApm.fsh].ToString();
                //row1[colRt] = row[ic.ivfDB.pApmDB.pApm.rt_ovary].ToString();
                //row1[colLt] = row[ic.ivfDB.pApmDB.pApm.lt_ovary].ToString();
                row1[colE2] = row[ic.ivfDB.pApmDB.pApm.e2] == null ? imgTran : row[ic.ivfDB.pApmDB.pApm.e2].ToString().Equals("1") ? imgCorr : imgTran;
                row1[colLh] = row[ic.ivfDB.pApmDB.pApm.lh] == null ? imgTran : row[ic.ivfDB.pApmDB.pApm.lh].ToString().Equals("1") ? imgCorr : imgTran;
                row1[colEndo] = row[ic.ivfDB.pApmDB.pApm.endo] == null ? imgTran : row[ic.ivfDB.pApmDB.pApm.endo].ToString().Equals("1") ? imgCorr : imgTran;
                row1[colPrl] = row[ic.ivfDB.pApmDB.pApm.prl] == null ? imgTran : row[ic.ivfDB.pApmDB.pApm.prl].ToString().Equals("1") ? imgCorr : imgTran;
                row1[colFsh] = row[ic.ivfDB.pApmDB.pApm.fsh] == null ? imgTran : row[ic.ivfDB.pApmDB.pApm.fsh].ToString().Equals("1") ? imgCorr : imgTran;
                row1[colRt] = row[ic.ivfDB.pApmDB.pApm.rt_ovary] == null ? imgTran : row[ic.ivfDB.pApmDB.pApm.rt_ovary].ToString().Equals("1") ? imgCorr : imgTran;
                row1[colLt] = row[ic.ivfDB.pApmDB.pApm.lt_ovary] == null ? imgTran : row[ic.ivfDB.pApmDB.pApm.lt_ovary].ToString().Equals("1") ? imgCorr : imgTran;
                //if (i % 2 == 0)
                //    grfPtt.Rows[i].StyleNew.BackColor = color;
                i++;
            }
            //menuGw = new ContextMenu();
            //grfpApmDayAll.ContextMenu = menuGw;
            grfpApmDayAll.Cols[colE2].AllowEditing = false;
            grfpApmDayAll.Cols[colLh].AllowEditing = false;
            grfpApmDayAll.Cols[colEndo].AllowEditing = false;
            grfpApmDayAll.Cols[colPrl].AllowEditing = false;
            grfpApmDayAll.Cols[colFsh].AllowEditing = false;
            grfpApmDayAll.Cols[colRt].AllowEditing = false;
            grfpApmDayAll.Cols[colLt].AllowEditing = false;
            grfpApmDayAll.Cols[colId].Visible = false;
            theme1.SetTheme(grfpApmDayAll, ic.theme);

        }
        private void setAppointmentOld()
        {
            pApmO.ID = txtIDOld.Text;
            pApmO.PID = txtPttIdOld.Text;
            pApmO.PIDS = txtHn.Text;
            pApmO.AppDate = ic.datetoDB(txtDatepApm.Text);
            pApmO.AppTime = cboTimepApm.Text;
            pApmO.Doctor = cboDoctor.Text;
            pApmO.Comment = txtRemark.Text;
            pApmO.MobilePhoneNo = "";
            pApmO.DateOfBirth = ic.datetoDB(txtDob.Text);
            pApmO.HormoneTest= chkHormoneTest.Checked ? "1" : "0";
            pApmO.BetaHCG = chkHCG.Checked ? "1" : "0";
            pApmO.et = chkET.Checked ? "1" : "0";
            pApmO.OPU = chkOPU.Checked ? "1" : "0";
            pApmO.TVS = chkTvs.Checked ? "1" : "0";
            pApmO.sperm_colloect = chkSperm.Checked ? "1" : "0";
            pApmO.ET_FET = chkFET.Checked ? "1" : "0";
            pApmO.Other = chkOther.Checked ? "1" : "0";
            pApmO.et_time = cboETTime.Text;
            pApmO.ET_FET_Time = cboFETTime.Text;
            pApmO.tvs_time = cboTvsTime.Text;
            pApmO.OPUTime = cboOPUTime.Text;
            pApmO.day1 = txtTvsDay.Text;
            pApmO.OtherRemark = txtOther.Text;
            pApmO.Status = "1";
            pApmO.OPURemark = txtOPURemark.Text;
            pApmO.PatientName = txtName.Text;
            pApmO.PName = txtName.Text;
            pApmO.PSurname = ptt.patient_firstname_e;
        }
        private Boolean setPatientAppointment()
        {
            Boolean chk = false;
            pApm.t_patient_appointment_id = txtID.Text;
            pApm.t_patient_id = txtPttId.Text;
            pApm.patient_appoint_date_time = System.DateTime.Now.Year.ToString() + "-" + System.DateTime.Now.ToString("MM-dd");
            DateTime dt = new DateTime();
            if (DateTime.TryParse(txtDatepApm.Text, out dt))
            {
                pApm.patient_appointment_date = ic.datetoDB(txtDatepApm.Text);
            }
            else
            {
                chk = false;
            }
            if (cboTimepApm.Text.Equals(""))
            {
                chk = false;
            }
            pApm.patient_appointment_time = cboTimepApm.Text;
            pApm.patient_appointment = txtAppointment.Text;
            pApm.patient_appointment_doctor = cboDoctor.SelectedItem == null ? "" : ((ComboBoxItem)cboDoctor.SelectedItem).Value;
            pApm.patient_appointment_servicepoint = cboBsp.SelectedItem == null ? "" : ((ComboBoxItem)cboBsp.SelectedItem).Value;
            pApm.patient_appointment_notice = txtRemarkpApm.Text;
            pApm.patient_appointment_staff = txtStfConfirmID.Text;

            pApm.t_visit_id = txtVsId.Text;
            pApm.patient_appointment_auto_visit = "";
            pApm.b_visit_queue_setup_id = "";
            pApm.patient_appointment_status = "";
            pApm.patient_appointment_vn = "";
            pApm.patient_appointment_staff_record = "";
            pApm.patient_appointment_record_date_time = "";
            pApm.patient_appointment_staff_update = "";
            pApm.patient_appointment_update_date_time = "";
            pApm.patient_appointment_staff_cancel = "";
            pApm.patient_appointment_cancel_date_time = "";
            pApm.patient_appointment_active = "";
            pApm.r_rp1853_aptype_id = "";
            pApm.patient_appointment_end_time = "";
            pApm.appointment_confirm_date = "";
            pApm.change_appointment_cause = "";
            pApm.visit_id_make_appointment = "";
            pApm.patient_appointment_clinic = "";

            pApm.date_cancel = "";
            pApm.date_create = "";
            pApm.date_modi = "";
            pApm.user_cancel = "";
            pApm.user_create = "";
            pApm.user_modi = "";
            pApm.active = "1";

            pApm.remark = "";
            pApm.e2 = chkE2.Checked ? "1" : "0";
            pApm.beta_hgc = chkHCG.Checked ? "1" : "0";
            pApm.prl = chkPrl.Checked ? "1" : "0";
            pApm.lh = chkLh.Checked ? "1" : "0";
            pApm.fet = chkFET.Checked ? "1" : "0";
            pApm.hormone_test = chkHormoneTest.Checked ? "1" : "0";
            pApm.fsh = chkFsh.Checked ? "1" : "0";
            pApm.tvs = chkTvs.Checked ? "1" : "0";

            pApm.repeat_e2 = chkRE2.Checked ? "1" : "0";
            pApm.repeat_prl = chkRPrl.Checked ? "1" : "0";
            pApm.repeat_lh = chkRLh.Checked ? "1" : "0";
            pApm.repeat_fsh = chkRFsh.Checked ? "1" : "0";
            pApm.opu = chkOPU.Checked ? "1" : "0";
            pApm.doctor_anes = cboDtrAnes.Text;
            pApm.tvs_day = txtTvsDay.Text;
            pApm.tvs_time = cboTvsTime.Text;
            pApm.opu_time = cboOPUTime.Text;
            pApm.et_time = cboETTime.Text;
            pApm.fet_time = cboFETTime.Text;
            pApm.sperm_collect = chkSperm.Checked ? "1" : "0";
            pApm.other = chkOther.Checked ? "1" : "0";
            pApm.other_remark = txtOther.Text;
            pApm.et = chkET.Checked ? "1" : "0";
            //pApm.opu = chkET.Checked ? "1" : "0";
            return chk;
        }
        private void FrmAppointmentAdd_Load(object sender, EventArgs e)
        {
            tC.SelectedTab = tabVisit;
            tC1.SelectedTab = tabPtt;
            cboTimepApm.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboTimepApm.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
    }
}
