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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.gui
{
    public partial class FrmLabFormDay1 : Form
    {
        IvfControl ic;
        String lformDay1Id = "", pttid = "", vsid = "", vsidOld = "", flag="";
        LabFormDay1 lFormDay1;
        LabOpu opu;
        VisitOld ovs;
        PatientOld optt;
        Patient ptt;
        Visit vs;

        C1SuperTooltip stt;
        C1SuperErrorProvider sep;

        public FrmLabFormDay1(IvfControl ic, String ldormday1Id, String pttid, String vsid, String vn)
        {
            InitializeComponent();
            this.ic = ic;
            this.pttid = pttid;
            this.vsid = vsid;
            this.vsidOld = vn;
            this.lformDay1Id = ldormday1Id;
            initConfig();
        }
        public FrmLabFormDay1(IvfControl ic, String ldormday1Id, String pttid, String vsid, String vn, String flag)
        {
            InitializeComponent();
            this.ic = ic;
            this.pttid = pttid;
            this.vsid = vsid;
            this.vsidOld = vn;
            this.lformDay1Id = ldormday1Id;
            this.flag = flag;
            initConfig();
        }
        private void initConfig()
        {
            lFormDay1 = new LabFormDay1();
            opu = new LabOpu();
            ptt = new Patient();
            ovs = new VisitOld();
            vs = new Visit();

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            ic.ivfDB.dtrOldDB.setCboDoctor(cboDoctor, "");
            ic.ivfDB.lformDay1DB.setCboRemark(cboRemark);
            ic.setCboDay(cboEmbryoFreezingDay, "");

            setControl();

            chkBiopsy.CheckedChanged += ChkBiopsy_CheckedChanged;
            chkEmbryoFreezingDay.CheckedChanged += ChkEmbryoFreezingDay_CheckedChanged;
            chkBlastocyst.CheckedChanged += ChkBlastocyst_CheckedChanged;
            chkEmbryoTransferFresh.CheckedChanged += ChkEmbryoTransferFresh_CheckedChanged;
            btnPrint.Click += BtnPrint_Click;
            chkPgsMin.CheckedChanged += ChkPgsMin_CheckedChanged;
            chkNgs.CheckedChanged += ChkNgs_CheckedChanged;
            btmDonorSearch.Click += BtmDonorSearch_Click;
            btnMaleSearch.Click += BtnMaleSearch_Click;
            btnSave.Click += BtnSave_Click;

            ChkBiopsy_CheckedChanged(null, null);
            ChkEmbryoFreezingDay_CheckedChanged(null, null);
            ChkBlastocyst_CheckedChanged(null, null);
            ChkEmbryoTransferFresh_CheckedChanged(null, null);
            ChkPgsMin_CheckedChanged(null, null);
            ChkNgs_CheckedChanged(null, null);

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.cStf.staff_id = "";
            FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            frm.ShowDialog(this);
            if (!ic.cStf.staff_id.Equals(""))
            {
                setLabFormDay1();
                String re = "";
                long chk = 0;
                re = ic.ivfDB.lformDay1DB.insertLabFormday1(lFormDay1, ic.cStf.staff_id);
                if(long.TryParse(re, out chk))
                {
                    if (chk > 1)
                    {
                        LabFormDay1 formday1 = new LabFormDay1();
                        formday1 = ic.ivfDB.lformDay1DB.selectByPk1(re);
                        txtFormDay1Code.Value = formday1.form_day1_code;
                    }
                }
            }
        }

        private void setControl()
        {
            lFormDay1 = ic.ivfDB.lformDay1DB.selectByPk1(lformDay1Id);
            vs = ic.ivfDB.vsDB.selectByPk1(vsid);
            ptt = ic.ivfDB.pttDB.selectByPk1(pttid);
            if (lFormDay1.form_day1_id.Equals(""))
            {
                lFormDay1 = ic.ivfDB.lformDay1DB.selectByVsId(vs.t_visit_id);
            }
            if (!lFormDay1.form_day1_id.Equals("")) //  found
            {
                LabRequest req = new LabRequest();
                //opu = ic.ivfDB.opuDB.selectByReqID(req.req_id);
                setControl1();
            }
            else// Not found
            {
                ovs = ic.ivfDB.ovsDB.selectByPk1(vsidOld);
                
                txtHnFeMale.Value = ptt.patient_hn;
                txtNameFeMale.Value = ptt.Name;
                txtDobFeMale.Value = ptt.AgeString();
                txtHnMale.Value = ptt.patient_hn_couple;
                txtNameMale.Value = ptt.patient_couple_firstname;
                txtPttId.Value = ptt.t_patient_id;
                txtVsId.Value = vs.t_visit_id;
                txtAgent.Value = ic.ivfDB.oAgnDB.getAgentNameById(ptt.agent);
                ic.setC1Combo(cboDoctor, vs.doctor_id);
                txtFormDay1Date.Value = DateTime.Now.Year.ToString() + "-" + DateTime.Now.ToString("MM-dd");
                if (ic.iniC.statusAppDonor.Equals("1"))
                {
                    if (ptt.f_sex_id.Equals("1"))//male
                    {
                        Patient ptt1 = new Patient();
                        ptt1 = ic.ivfDB.pttDB.selectByHn(ptt.patient_hn_1);
                        txtHnMale.Value = ptt.patient_hn;
                        txtNameMale.Value = ptt.Name;
                        txtHnFeMale.Value = ptt.patient_hn_1;
                        txtNameFeMale.Value = ptt1.Name;
                        txtDobFeMale.Value = ptt1.patient_birthday;
                        txtDobMale.Value = ptt.patient_birthday;
                    }
                    else if (ptt.f_sex_id.Equals("2"))//female
                    {
                        if (!ptt.patient_hn_1.Equals("") && !ptt.patient_hn_2.Equals(""))    // record donor
                        {
                            txtHnFeMale.Value = ptt.patient_hn_1;
                            txtHnMale.Value = ptt.patient_hn_2;
                            txtHnDonor.Value = ptt.patient_hn;
                            txtNameDonor.Value = ptt.Name;
                            Patient ptt1 = new Patient();
                            ptt1 = ic.ivfDB.pttDB.selectByHn(ptt.patient_hn_1);
                            txtNameFeMale.Value = ptt1.Name;
                            Patient ptt2 = new Patient();
                            ptt2 = ic.ivfDB.pttDB.selectByHn(ptt.patient_hn_2);
                            txtNameMale.Value = ptt2.Name;
                            txtDobFeMale.Value = ptt1.patient_birthday;
                            txtDobMale.Value = ptt2.patient_birthday;
                        }
                        else if (ptt.patient_hn_1.Equals("") && !ptt.patient_hn_2.Equals(""))   // record female
                        {
                            Patient ptt1 = new Patient();
                            ptt1 = ic.ivfDB.pttDB.selectByHn(ptt.patient_hn_2);
                            txtHnMale.Value = ptt.patient_hn_2;
                            txtNameMale.Value = ptt1.Name;
                            txtHnFeMale.Value = ptt.patient_hn;
                            txtNameFeMale.Value = ptt.Name;
                            txtDobMale.Value = ptt1.patient_birthday;
                            txtDobFeMale.Value = ptt.patient_birthday;
                        }
                    }
                }
                else
                {
                    if (ptt.f_sex_id.Equals("1"))//male
                    {
                        Patient ptt1 = new Patient();
                        ptt1 = ic.ivfDB.pttDB.selectByHn(ptt.patient_hn_1);
                        txtHnMale.Value = ptt.patient_hn;
                        txtNameMale.Value = ptt.Name;
                        txtHnFeMale.Value = ptt.patient_hn_1;
                        txtNameFeMale.Value = ptt1.Name;
                        txtDobMale.Value = ptt.patient_birthday;
                        txtDobFeMale.Value = ptt1.patient_birthday;
                    }
                    else if (ptt.f_sex_id.Equals("2"))//female
                    {
                        Patient ptt2 = new Patient();
                        ptt2 = ic.ivfDB.pttDB.selectByHn(ptt.patient_hn_2);
                        txtHnMale.Value = ptt.patient_hn_2;
                        txtNameMale.Value = ptt2.Name;
                        txtHnFeMale.Value = ptt.patient_hn;
                        txtNameFeMale.Value = ptt.Name;
                        txtDobMale.Value = ptt2.patient_birthday;
                        txtDobFeMale.Value = ptt.patient_birthday;
                    }
                }
            }
        }
        private void setControl1()
        {
            txtID.Value = lFormDay1.form_day1_id;
            //txtLabFormACode.Value = lFormA.form_a_code;
            txtPttId.Value = lFormDay1.t_patient_id;
            txtVsId.Value = lFormDay1.t_visit_id;
            //txtVnOld.Value = lFormDay1.vn_old;
            //txtHnOld.Value = lFormDay1.hn_old;
            txtHnFeMale.Value = lFormDay1.hn_female;
            txtNameFeMale.Value = lFormDay1.name_female;
            txtNameMale.Value = lFormDay1.name_male;
            txtHnMale.Value = lFormDay1.hn_male;
            txtDobFeMale.Value = lFormDay1.dob_female;
            txtDobMale.Value = lFormDay1.dob_male;
            txtFormDay1Code.Value = lFormDay1.form_day1_code;
            txtFormDay1Date.Value = lFormDay1.day1_date;
            //ic.setC1Combo(cboDoctor, lFormDay1.d);

            //txtFertili2Pn.Value = opu.fertili_2_pn;
            txtFertili2Pn.Value = lFormDay1.fertili_2_pn;
            //ic.setC1Combo(cboDoctor, lFormDay1.doctor_id);
            txtLabFormACode.Value = lFormDay1.form_day1_code;
            chkNoBiopsy.Checked = lFormDay1.status_no_biopsy.Equals("1") ? true : false;
            chkBiopsy.Checked = lFormDay1.status_no_biopsy.Equals("2") ? true : false;
            chkPgsMin.Checked = lFormDay1.status_biopsy_pgs.Equals("1") ? true : false;
            chkNgs.Checked = lFormDay1.status_biopsy_ngs.Equals("1") ? true : false;
            chkNgs7Pair.Checked = lFormDay1.status_biopsy_ngs_7_pair.Equals("1") ? true : false;
            chkNgs23Pair.Checked = lFormDay1.status_biopsy_ngs_23_pair.Equals("1") ? true : false;
            txtNgsMin.Value = lFormDay1.biopsy_ngs_min;
            txtNgsMax.Value = lFormDay1.biopsy_ngs_max;
            chkEmbryoFreezingDay.Checked = lFormDay1.embryo_freezing_day.Equals("1") ? true : false;
            ic.setC1Combo(cboEmbryoFreezingDay, lFormDay1.embryo_freezing_day);
            txtEmbryoFreezingEmbryoMax.Value = lFormDay1.embryo_freezing_day_max;
            chkBlastocyst.Checked = lFormDay1.status_stage_blastocyst.Equals("1") ? true : false;
            chkMorula.Checked = lFormDay1.status_stage_morula.Equals("1") ? true : false;
            chkEmbryoTransferFresh.Checked = lFormDay1.status_embryo_tranfer.Equals("1") ? true : false;
            chkEmbryoGlue.Checked = lFormDay1.status_embryo_tranfer_embryo_glue.Equals("1") ? true : false;
            chkEmbryoTransferFreshDay3.Checked = lFormDay1.status_embryo_tranfer_day.Equals("3") ? true : false;
            chkEmbryoTransferFreshDay5.Checked = lFormDay1.status_embryo_tranfer_day.Equals("5") ? true : false;
            chkDiscard.Checked = lFormDay1.status_discard_all.Equals("1") ? true : false;
            
            Patient ptt = new Patient();
            ptt = ic.ivfDB.pttDB.selectByPk1(pttid);
            Patient ptt2 = new Patient();
            ptt2 = ic.ivfDB.pttDB.selectByHn(ptt.patient_hn_2);
            txtHnFeMale.Value = ptt2.patient_hn;
            txtNameFeMale.Value = ptt2.Name;
            txtDobFeMale.Value = ptt2.patient_birthday;
            
            //cboRemark.Text = lFormDay1.remark;
            ic.setC1ComboByName(cboRemark, lFormDay1.remark);
        }
        private void setLabFormDay1()
        {
            lFormDay1.form_day1_id = txtID.Text;
            //txtLabFormACode.Value = lFormA.form_a_code;
            lFormDay1.t_patient_id = txtPttId.Text;
            lFormDay1.t_visit_id = txtVsId.Text;
            //txtVnOld.Value = lFormDay1.vn_old;
            //txtHnOld.Value = lFormDay1.hn_old;
            lFormDay1.hn_female = txtHnFeMale.Text;
            lFormDay1.name_female = txtNameFeMale.Text;
            lFormDay1.name_male = txtNameMale.Text;
            lFormDay1.hn_male = txtHnMale.Text;
            lFormDay1.dob_female = ic.datetoDB(txtDobFeMale.Text);
            lFormDay1.dob_male = ic.datetoDB(txtDobMale.Text);
            lFormDay1.form_day1_code = txtFormDay1Code.Text.Trim().Equals("") ? ic.ivfDB.copDB.genFormADay1Doc() : txtFormDay1Code.Text.Trim();
            lFormDay1.day1_date = ic.datetoDB(txtFormDay1Date.Text);
            //ic.setC1Combo(cboDoctor, lFormDay1.doctor_id);

            //txtFertili2Pn.Value = opu.fertili_2_pn;
            lFormDay1.fertili_2_pn = txtFertili2Pn.Text;
            //ic.setC1Combo(cboDoctor, lFormDay1.doctor_id);
            //lFormDay1.form_day1_code = txtLabFormACode.Text;
            lFormDay1.status_no_biopsy = chkNoBiopsy.Checked ? "1" : "2";
            //lFormDay1.status_no_biopsy = chkBiopsy.Checked ? "2" : "1";
            lFormDay1.status_biopsy_pgs = chkPgsMin.Checked ? "1" : "0";
            //lFormDay1.status_biopsy_pgs = chkPgsMin.Checked ? "1" : "0";
            lFormDay1.status_biopsy_ngs = chkNgs.Checked ? "1" : "0";
            lFormDay1.status_biopsy_ngs_7_pair = chkNgs7Pair.Checked ? "1" : "0";
            lFormDay1.status_biopsy_ngs_23_pair = chkNgs23Pair.Checked ? "1" : "0";
            lFormDay1.biopsy_ngs_min = txtNgsMin.Text;
            lFormDay1.biopsy_ngs_max = txtNgsMax.Text;
            lFormDay1.embryo_freezing_day = chkEmbryoFreezingDay.Checked ? "1" : "0";
            //ic.setC1Combo(cboEmbryoFreezingDay, lFormDay1.embryo_freezing_day);
            lFormDay1.embryo_freezing_day = cboEmbryoFreezingDay.SelectedItem == null ? "" : ((ComboBoxItem)cboEmbryoFreezingDay.SelectedItem).Value;
            lFormDay1.embryo_freezing_day_max = txtEmbryoFreezingEmbryoMax.Text;
            lFormDay1.status_stage_blastocyst = chkBlastocyst.Checked ? "1" : "0";
            lFormDay1.status_stage_morula = chkMorula.Checked ? "1" : "0";
            lFormDay1.status_embryo_tranfer = chkEmbryoTransferFresh.Checked ? "1": "0";
            lFormDay1.status_embryo_tranfer_embryo_glue = chkEmbryoGlue.Checked ? "1" : "0";
            lFormDay1.status_embryo_tranfer_day = chkEmbryoTransferFreshDay3.Checked ? "3" : "5";
            //chkEmbryoTransferFreshDay5.Checked = lFormDay1.status_embryo_tranfer_day.Equals("5") ? true : false;
            lFormDay1.status_discard_all = chkDiscard.Checked ? "1" : "0";

            lFormDay1.remark = cboRemark.Text;
        }
        private void BtnMaleSearch_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.sVsOld.PIDS = "";
            ic.sVsOld.PName = "";
            FrmSearchHn frm = new FrmSearchHn(ic, FrmSearchHn.StatusConnection.host, FrmSearchHn.StatusSearch.PttSearch, FrmSearchHn.StatusSearchTable.PttSearch);
            frm.ShowDialog(this);
            txtHnMale.Value = ic.sVsOld.PIDS;
            txtNameMale.Value = ic.sVsOld.PName;
            txtDobMale.Value = ic.sVsOld.dob;
        }

        private void BtmDonorSearch_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.sVsOld.PIDS = "";
            ic.sVsOld.PName = "";
            ic.sVsOld.dob = "";
            FrmSearchHn frm = new FrmSearchHn(ic, FrmSearchHn.StatusConnection.hostEx, FrmSearchHn.StatusSearch.DonorSearch, FrmSearchHn.StatusSearchTable.VisitSearch);
            frm.ShowDialog(this);
            txtHnDonor.Value = ic.sVsOld.PIDS;
            txtNameDonor.Value = ic.sVsOld.PName;
            txtDonorDob.Value = ic.sVsOld.dob;
        }

        private void ChkNgs_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (chkNgs.Checked)
            {
                chkNgs7Pair.Enabled = true;
                chkNgs23Pair.Enabled = true;
                txtNgsMin.Enabled = true;
                txtNgsMax.Enabled = true;
                label13.Enabled = true;
                label14.Enabled = true;
                label12.Enabled = true;
            }
            else
            {
                chkNgs7Pair.Enabled = false;
                chkNgs23Pair.Enabled = false;
                txtNgsMin.Enabled = false;
                txtNgsMax.Enabled = false;
                label13.Enabled = false;
                label14.Enabled = false;
                label12.Enabled = false;
                chkNgs7Pair.Checked = false;
                chkNgs23Pair.Checked = false;
            }
        }

        private void ChkPgsMin_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (chkPgsMin.Checked)
            {
                txtPgsMin.Enabled = true;
                txtPgsMax.Enabled = true;
                label9.Enabled = true;
                label11.Enabled = true;
            }
            else
            {
                txtPgsMin.Enabled = false;
                txtPgsMax.Enabled = false;
                label9.Enabled = false;
                label11.Enabled = false;
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            DataTable dt = new DataTable();

            //dt.NewRow();
            //DataRow toInsert = dt.NewRow();
            dt.Rows.InsertAt(dt.NewRow(), 0);
            dt.Columns.Add("form_day1_id", typeof(String));
            dt.Columns.Add("hn_female", typeof(String));
            dt.Columns.Add("name_female", typeof(String));
            dt.Columns.Add("hn_male", typeof(String));
            dt.Columns.Add("name_male", typeof(String));
            dt.Columns.Add("dob_female", typeof(String));
            dt.Columns.Add("dob_male", typeof(String));
            dt.Columns.Add("doctor_name", typeof(String));
            dt.Columns.Add("date_request", typeof(String));
            dt.Columns.Add("fertili_2_pn", typeof(String));
            dt.Columns.Add("status_biopsy", typeof(String));
            dt.Columns.Add("pgs", typeof(String));
            dt.Columns.Add("ngs", typeof(String));
            dt.Columns.Add("pgs_min", typeof(String));
            dt.Columns.Add("pgs_max", typeof(String));
            dt.Columns.Add("ngs_7_pair", typeof(String));
            dt.Columns.Add("ngs_23_pair", typeof(String));
            dt.Columns.Add("ngs_min", typeof(String));
            dt.Columns.Add("ngs_max", typeof(String));
            dt.Columns.Add("embryo_freezing_day", typeof(String));
            dt.Columns.Add("embryo_freezing_embryo", typeof(String));
            dt.Columns.Add("blastocyst", typeof(String));
            dt.Columns.Add("morula", typeof(String));
            dt.Columns.Add("cleavage", typeof(String));
            dt.Columns.Add("embryo_transfer_fresh_cycle", typeof(String));
            dt.Columns.Add("embryo_glue", typeof(String));
            dt.Columns.Add("embryo_transfer_fresh_day3", typeof(String));
            dt.Columns.Add("embryo_transfer_fresh_day5", typeof(String));
            dt.Columns.Add("discard", typeof(String));
            dt.Columns.Add("remark", typeof(String));
            dt.Columns.Add("embryo_freezing_embryo_max", typeof(String));
            //dt.Columns.Add("", typeof(String));
            //dt.Columns.Add("", typeof(String));
            //dt.Columns.Add("", typeof(String));
            dt.Rows[0]["form_day1_id"] = "";
            dt.Rows[0]["hn_female"] = txtHnFeMale.Text;
            dt.Rows[0]["name_female"] = txtNameFeMale.Text;
            dt.Rows[0]["hn_male"] = txtHnMale.Text;
            dt.Rows[0]["name_male"] = txtNameMale.Text;
            dt.Rows[0]["dob_female"] = txtDobFeMale.Text;
            dt.Rows[0]["dob_male"] = txtDobMale.Text;
            dt.Rows[0]["doctor_name"] = cboDoctor.SelectedItem == null ? "" : ((ComboBoxItem)cboDoctor.SelectedItem).Value;
            dt.Rows[0]["date_request"] = "";
            dt.Rows[0]["fertili_2_pn"] = txtFertili2Pn.Text;
            dt.Rows[0]["status_biopsy"] = chkBiopsy.Checked == true ? "1" : "0";
            dt.Rows[0]["pgs"] = chkPgsMin.Checked == true ? "1" : "0";
            dt.Rows[0]["ngs"] = chkNgs.Checked == true ? "1" : "0";
            dt.Rows[0]["pgs_min"] = txtPgsMin.Text;
            dt.Rows[0]["pgs_max"] = txtPgsMax.Text;
            dt.Rows[0]["ngs_7_pair"] = chkNgs7Pair.Checked == true ? "1" : "0";
            dt.Rows[0]["ngs_23_pair"] = chkNgs23Pair.Checked == true ? "1" : "0";
            dt.Rows[0]["ngs_min"] = txtNgsMin.Text;
            dt.Rows[0]["ngs_max"] = txtNgsMax.Text;
            dt.Rows[0]["embryo_freezing_day"]= chkEmbryoFreezingDay.Checked == true ? "1" : "0";
            dt.Rows[0]["embryo_freezing_embryo"]= cboEmbryoFreezingDay.SelectedItem == null ? "" : ((ComboBoxItem)cboEmbryoFreezingDay.SelectedItem).Value;
            dt.Rows[0]["blastocyst"] = chkBlastocyst.Checked == true ? "1" : "0";
            dt.Rows[0]["morula"] = chkMorula.Checked == true ? "1" : "0";
            dt.Rows[0]["cleavage"] = chkCleavage.Checked == true ? "1" : "0";
            dt.Rows[0]["embryo_transfer_fresh_cycle"] = chkEmbryoTransferFresh.Checked == true ? "1" : "0";
            dt.Rows[0]["embryo_glue"] = chkEmbryoGlue.Checked == true ? "1" : "0";
            dt.Rows[0]["embryo_transfer_fresh_day3"] = chkEmbryoTransferFreshDay3.Checked == true ? "1" : "0";
            dt.Rows[0]["embryo_transfer_fresh_day5"] = chkEmbryoTransferFreshDay5.Checked == true ? "1" : "0";
            dt.Rows[0]["discard"] = chkDiscard.Checked == true ? "1" : "0";
            dt.Rows[0]["remark"] = cboRemark.Text;
            dt.Rows[0]["embryo_freezing_embryo_max"] = txtEmbryoFreezingEmbryoMax.Text;
            //dt.Rows[0][""]
            FrmReport frm = new FrmReport(ic);
            frm.setLabFormDay1Report(dt);
            frm.ShowDialog(this);
        }
        private void ChkEmbryoTransferFresh_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (chkEmbryoTransferFresh.Checked)
            {
                pnEmbryoTransferFresh.Enabled = true;
            }
            else
            {
                pnEmbryoTransferFresh.Enabled = false;
                chkEmbryoTransferFreshDay3.Checked = false;
                chkEmbryoTransferFreshDay5.Checked = false;
            }
        }

        private void ChkBlastocyst_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (chkBlastocyst.Checked)
            {
                pnBlastocyst.Enabled = true;
                chkBlastocystEarly.Checked = true;
            }
            else
            {
                pnBlastocyst.Enabled = false;
                chkBlastocystEarly.Checked = false;
            }
        }

        private void ChkEmbryoFreezingDay_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (chkEmbryoFreezingDay.Checked)
            {
                cboEmbryoFreezingDay.Enabled = true;
                txtEmbryoFreezingEmbryoMax.Enabled = true;
                label15.Enabled = true;
                label16.Enabled = true;
            }
            else
            {
                cboEmbryoFreezingDay.Enabled = false;
                txtEmbryoFreezingEmbryoMax.Enabled = false;
                label15.Enabled = false;
                label16.Enabled = false;
            }
        }

        private void ChkBiopsy_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (chkBiopsy.Checked)
            {
                pnBiopsy.Enabled = true;
            }
            else
            {
                pnBiopsy.Enabled = false;
            }
        }

        private void FrmLabFormDay1_Load(object sender, EventArgs e)
        {

        }
    }
}
