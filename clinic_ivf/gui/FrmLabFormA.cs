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
    public partial class FrmLabFormA : Form
    {
        IvfControl ic;
        String lformaId = "", pttid="", vsid="", vsidOld="";
        LabFormA lFormA;

        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        String statusOPU = "", statusFET = "";

        public FrmLabFormA(IvfControl ic, String lformaId, String pttid, String vsid, String vsidOld)
        {
            InitializeComponent();
            this.ic = ic;
            this.lformaId = lformaId;
            this.vsid = vsid;
            this.pttid = pttid;
            this.vsidOld = vsidOld;
            //this.reqid = reqid;
            initConfig();
        }
        private void initConfig()
        {
            lFormA = new LabFormA();
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();

            ic.ivfDB.dtrOldDB.setCboDoctor(cboDoctor, "");
            ic.ivfDB.lFormaDB.setCboRemark(cboRemark);
            ic.ivfDB.lFormaDB.setCboOPUWaitRemark(cboOPUWaitRemark);
            ic.setCboDay(cboFetDay, "");
            ic.setCboDay(cboFet1Day, "");
            txtFormADate.Value = DateTime.Now.Year + "-" + DateTime.Now.ToString("MM-dd");
            setControl();

            btnSave.Click += BtnSave_Click;
            chkNgs.CheckedChanged += ChkNgs_CheckedChanged;
            //chkEmbryoTranfer.CheckedChanged += ChkEmbryoTranfer_CheckedChanged;
            chkEmbryoTranfer.CheckStateChanged += ChkEmbryoTranfer_CheckStateChanged;
            chkEmbryoFreezing.CheckStateChanged += ChkEmbryoFresh_CheckStateChanged;
            chkFET.CheckedChanged += ChkFET_CheckedChanged;
            chkSpermAnalysis.CheckStateChanged += ChkSpermAnalysis_CheckStateChanged;
            chkSpermFreezing.CheckStateChanged += ChkSpermFreezing_CheckStateChanged;
            chkFreshSprem.CheckStateChanged += ChkFreshSprem_CheckStateChanged;
            btnMaleSearch.Click += BtnMaleSearch_Click;
            btnPrint.Click += BtnPrint_Click;
            btmDonorSearch.Click += BtmDonorSearch_Click;
            btnFemaleSearch.Click += BtnFemaleSearch_Click;
            chkFrozenSperm.CheckStateChanged += ChkFrozenSperm_CheckStateChanged;
            btnPrintOPU.Click += BtnPrintOPU_Click;
            btnPrintFet.Click += BtnPrintFet_Click;
            chkNgs.Click += ChkNgs_Click;
            chkNoNgs.Click += ChkNoNgs_Click;

            ChkEmbryoTranfer_CheckStateChanged(null, null);
            ChkNgs_CheckedChanged(null, null);
            ChkEmbryoFresh_CheckStateChanged(null, null);
            ChkFET_CheckedChanged(null, null);
            ChkSpermAnalysis_CheckStateChanged(null, null);
            ChkSpermFreezing_CheckStateChanged(null, null);
            
            chkOPUActive.CheckedChanged += ChkOPUActive_CheckedChanged;
            chkOPUUnActive.CheckedChanged += ChkOPUUnActive_CheckedChanged;
            chkOPUActiveWait.CheckedChanged += ChkOPUActiveWait_CheckedChanged;
            ChkOPUActive_CheckedChanged(null, null);
            chkFetActive.CheckedChanged += ChkFetActive_CheckedChanged;
            chkFetUnActive.CheckedChanged += ChkFetUnActive_CheckedChanged;
            chkFetActiveWait.CheckedChanged += ChkFetActiveWait_CheckedChanged;
            ChkFetActive_CheckedChanged(null, null);
            
            chkOpuTimeModi.CheckedChanged += ChkOpuTimeModi_CheckedChanged;
            chkOpuTimeModi.Checked = false;
            ChkOpuTimeModi_CheckedChanged(null, null);
            ChkFrozenSperm_CheckStateChanged(null, null);
            chkOPUActive.Checked = true;
            chkFetActive.Checked = true;
            chkConfirmFetDate.Checked = true;
            chkWaitOpuDate.Checked = true;
            //statusOPU = ic.ivfDB.oJsDB.chkByOPU(vsidOld);
            //statusFET = ic.ivfDB.oJsDB.chkByFET(vsidOld);
            statusOPU = "-";
            statusFET = "-";
            if (statusOPU.Equals(""))
            {
                gbOPU.Enabled = false;
            }
            if (statusFET.Equals(""))
            {
                gbETFET.Enabled = false;
            }
            //lbMessage.Hide();
            lbMessage1.Text = "";
            sB1.Text = "";
        }

        private void ChkNoNgs_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (chkNoNgs.Checked) chkNoNgs.Checked = false;
        }

        private void ChkNgs_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (chkNgs.Checked) chkNgs.Checked = false;
        }

        private void BtnPrintFet_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmReport frm = new FrmReport(ic);
            DataTable dt = new DataTable();
            dt = ic.ivfDB.lFormaDB.selectReportByPk(txtID.Text);
            String date1 = "", txt1 = "";
            if (dt.Rows.Count <= 0) return;
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.lFormaDB.lformA.opu_date].ToString());
            dt.Rows[0][ic.ivfDB.lFormaDB.lformA.opu_date] = date1.Replace("-", "/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.lFormaDB.lformA.embryo_freezing_day].ToString());
            dt.Rows[0][ic.ivfDB.lFormaDB.lformA.embryo_freezing_day] = date1.Replace("-", "/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.lFormaDB.lformA.embryo_tranfer_date].ToString());
            dt.Rows[0][ic.ivfDB.lFormaDB.lformA.embryo_tranfer_date] = date1.Replace("-", "/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.lFormaDB.lformA.fet1_no_date_freezing].ToString());
            dt.Rows[0][ic.ivfDB.lFormaDB.lformA.fet1_no_date_freezing] = date1.Replace("-", "/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.lFormaDB.lformA.dob_male].ToString());
            dt.Rows[0][ic.ivfDB.lFormaDB.lformA.dob_male] = date1.Replace("-", "/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.lFormaDB.lformA.dob_female].ToString());
            dt.Rows[0][ic.ivfDB.lFormaDB.lformA.dob_female] = date1.Replace("-", "/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.lFormaDB.lformA.spern_freezing_date_start].ToString());
            dt.Rows[0][ic.ivfDB.lFormaDB.lformA.spern_freezing_date_start] = date1.Replace("-", "/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.lFormaDB.lformA.spern_freezing_date_end].ToString());
            dt.Rows[0][ic.ivfDB.lFormaDB.lformA.spern_freezing_date_end] = date1.Replace("-", "/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.lFormaDB.lformA.iui_date].ToString());
            dt.Rows[0][ic.ivfDB.lFormaDB.lformA.iui_date] = date1.Replace("-", "/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.lFormaDB.lformA.pasa_tese_date].ToString());
            dt.Rows[0][ic.ivfDB.lFormaDB.lformA.pasa_tese_date] = date1.Replace("-", "/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.lFormaDB.lformA.sperm_analysis_date_start].ToString());
            dt.Rows[0][ic.ivfDB.lFormaDB.lformA.sperm_analysis_date_start] = date1.Replace("-", "/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.lFormaDB.lformA.sperm_analysis_date_end].ToString());
            dt.Rows[0][ic.ivfDB.lFormaDB.lformA.sperm_analysis_date_end] = date1.Replace("-", "/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.lFormaDB.lformA.fet_no_date_freezing].ToString());
            dt.Rows[0][ic.ivfDB.lFormaDB.lformA.fet_no_date_freezing] = date1.Replace("-", "/");
            if (dt.Rows[0]["status_wait_confirm_opu_date"].ToString().Equals("1"))
            {
                txt1 = "รอ confirm วัน เวลา OPU จากทาง พยาบาล";
            }
            dt.Columns.Add("note1", typeof(String));
            dt.Rows[0]["note1"] = txt1;
            frm.setLabFormAFetReport(dt);
            frm.ShowDialog(this);
        }

        private void BtnPrintOPU_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmReport frm = new FrmReport(ic);
            DataTable dt = new DataTable();
            dt = ic.ivfDB.lFormaDB.selectReportByPk(txtID.Text);
            String date1 = "", txt1 = "";
            if (dt.Rows.Count <= 0) return;
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.lFormaDB.lformA.opu_date].ToString());
            dt.Rows[0][ic.ivfDB.lFormaDB.lformA.opu_date] = date1.Replace("-", "/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.lFormaDB.lformA.embryo_freezing_day].ToString());
            dt.Rows[0][ic.ivfDB.lFormaDB.lformA.embryo_freezing_day] = date1.Replace("-", "/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.lFormaDB.lformA.embryo_tranfer_date].ToString());
            dt.Rows[0][ic.ivfDB.lFormaDB.lformA.embryo_tranfer_date] = date1.Replace("-", "/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.lFormaDB.lformA.fet1_no_date_freezing].ToString());
            dt.Rows[0][ic.ivfDB.lFormaDB.lformA.fet1_no_date_freezing] = date1.Replace("-", "/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.lFormaDB.lformA.dob_male].ToString());
            dt.Rows[0][ic.ivfDB.lFormaDB.lformA.dob_male] = date1.Replace("-", "/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.lFormaDB.lformA.dob_female].ToString());
            dt.Rows[0][ic.ivfDB.lFormaDB.lformA.dob_female] = date1.Replace("-", "/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.lFormaDB.lformA.spern_freezing_date_start].ToString());
            dt.Rows[0][ic.ivfDB.lFormaDB.lformA.spern_freezing_date_start] = date1.Replace("-", "/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.lFormaDB.lformA.spern_freezing_date_end].ToString());
            dt.Rows[0][ic.ivfDB.lFormaDB.lformA.spern_freezing_date_end] = date1.Replace("-", "/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.lFormaDB.lformA.iui_date].ToString());
            dt.Rows[0][ic.ivfDB.lFormaDB.lformA.iui_date] = date1.Replace("-", "/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.lFormaDB.lformA.pasa_tese_date].ToString());
            dt.Rows[0][ic.ivfDB.lFormaDB.lformA.pasa_tese_date] = date1.Replace("-", "/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.lFormaDB.lformA.sperm_analysis_date_start].ToString());
            dt.Rows[0][ic.ivfDB.lFormaDB.lformA.sperm_analysis_date_start] = date1.Replace("-", "/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.lFormaDB.lformA.sperm_analysis_date_end].ToString());
            dt.Rows[0][ic.ivfDB.lFormaDB.lformA.sperm_analysis_date_end] = date1.Replace("-", "/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.lFormaDB.lformA.fet_no_date_freezing].ToString());
            dt.Rows[0][ic.ivfDB.lFormaDB.lformA.fet_no_date_freezing] = date1.Replace("-", "/");
            if (dt.Rows[0]["status_wait_confirm_opu_date"].ToString().Equals("1"))
            {
                txt1 = "รอ confirm วัน เวลา OPU จากทาง พยาบาล";
            }
            dt.Columns.Add("note1", typeof(String));
            dt.Rows[0]["note1"] = txt1;
            frm.setLabFormAOPUReport(dt);
            frm.ShowDialog(this);
        }

        private void ChkFrozenSperm_CheckStateChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (chkFrozenSperm.Checked)
            {
                txtFrozenSpermDate.Enabled = true;
            }
            else
            {
                txtFrozenSpermDate.Enabled = false;
            }
        }                

        private void BtnFemaleSearch_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.sVsOld.PIDS = "";
            ic.sVsOld.PName = "";
            FrmSearchHn frm = new FrmSearchHn(ic, FrmSearchHn.StatusConnection.host, FrmSearchHn.StatusSearch.PttSearch, FrmSearchHn.StatusSearchTable.PttSearch);
            frm.ShowDialog(this);
            txtHnFeMale.Value = ic.sVsOld.PIDS;
            txtNameFeMale.Value = ic.sVsOld.PName;
            txtDobFeMale.Value = ic.sVsOld.dob;
        }

        private void ChkOpuTimeModi_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (chkOpuTimeModi.Checked)
            {
                txtOPUTimeModi.Show();
                label33.Show();
                txtOPUTimeModi.Value = txtOPUTime.Text;
            }
            else
            {
                txtOPUTimeModi.Hide();
                label33.Hide();
            }
        }

        private void ChkFetActiveWait_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            chkFetWaitRemark();
        }

        private void ChkFetUnActive_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            chkFetWaitRemark();
        }

        private void ChkFetActive_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            chkFetWaitRemark();
        }

        private void ChkOPUActiveWait_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            chkOPUWaitRemark();
        }

        private void ChkOPUUnActive_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            chkOPUWaitRemark();
        }

        private void ChkOPUActive_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            chkOPUWaitRemark();
        }
        private void chkFetWaitRemark()
        {
            if (chkFetActive.Checked)
            {
                cboFetWaitRemark.Hide();
            }
            else if (chkFetUnActive.Checked)
            {
                cboFetWaitRemark.Show();
            }
            else if (chkFetActiveWait.Checked)
            {
                cboFetWaitRemark.Show();
            }
        }
        private void chkOPUWaitRemark()
        {
            if (chkOPUActive.Checked)
            {
                cboOPUWaitRemark.Hide();
            }
            else if (chkOPUUnActive.Checked)
            {
                cboOPUWaitRemark.Show();
            }
            else if (chkOPUActiveWait.Checked)
            {
                cboOPUWaitRemark.Show();
            }
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

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmReport frm = new FrmReport(ic);
            DataTable dt = new DataTable();
            dt = ic.ivfDB.lFormaDB.selectReportByPk(txtID.Text);
            String date1 = "", txt1 = "";
            if (dt.Rows.Count <= 0) return;
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.lFormaDB.lformA.opu_date].ToString());
            dt.Rows[0][ic.ivfDB.lFormaDB.lformA.opu_date] = date1.Replace("-","/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.lFormaDB.lformA.embryo_freezing_day].ToString());
            dt.Rows[0][ic.ivfDB.lFormaDB.lformA.embryo_freezing_day] = date1.Replace("-", "/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.lFormaDB.lformA.embryo_tranfer_date].ToString());
            dt.Rows[0][ic.ivfDB.lFormaDB.lformA.embryo_tranfer_date] = date1.Replace("-", "/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.lFormaDB.lformA.fet1_no_date_freezing].ToString());
            dt.Rows[0][ic.ivfDB.lFormaDB.lformA.fet1_no_date_freezing] = date1.Replace("-", "/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.lFormaDB.lformA.dob_male].ToString());
            dt.Rows[0][ic.ivfDB.lFormaDB.lformA.dob_male] = date1.Replace("-", "/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.lFormaDB.lformA.dob_female].ToString());
            dt.Rows[0][ic.ivfDB.lFormaDB.lformA.dob_female] = date1.Replace("-", "/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.lFormaDB.lformA.spern_freezing_date_start].ToString());
            dt.Rows[0][ic.ivfDB.lFormaDB.lformA.spern_freezing_date_start] = date1.Replace("-", "/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.lFormaDB.lformA.spern_freezing_date_end].ToString());
            dt.Rows[0][ic.ivfDB.lFormaDB.lformA.spern_freezing_date_end] = date1.Replace("-", "/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.lFormaDB.lformA.iui_date].ToString());
            dt.Rows[0][ic.ivfDB.lFormaDB.lformA.iui_date] = date1.Replace("-", "/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.lFormaDB.lformA.pasa_tese_date].ToString());
            dt.Rows[0][ic.ivfDB.lFormaDB.lformA.pasa_tese_date] = date1.Replace("-", "/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.lFormaDB.lformA.sperm_analysis_date_start].ToString());
            dt.Rows[0][ic.ivfDB.lFormaDB.lformA.sperm_analysis_date_start] = date1.Replace("-", "/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.lFormaDB.lformA.sperm_analysis_date_end].ToString());
            dt.Rows[0][ic.ivfDB.lFormaDB.lformA.sperm_analysis_date_end] = date1.Replace("-","/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.lFormaDB.lformA.fet_no_date_freezing].ToString());
            dt.Rows[0][ic.ivfDB.lFormaDB.lformA.fet_no_date_freezing] = date1.Replace("-", "/");
            if (dt.Rows[0]["status_wait_confirm_opu_date"].ToString().Equals("1"))
            {
                txt1 = "รอ confirm วัน เวลา OPU จากทาง พยาบาล";
            }
            dt.Columns.Add("note1", typeof(String));
            dt.Rows[0]["note1"] = txt1;
            frm.setLabFormAReport(dt);
            frm.ShowDialog(this);
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

        private void setLabFormA()
        {
            lFormA.form_a_id = txtID.Text;
            if (lFormA.form_a_id.Equals(""))
            {
                lFormA.form_a_code = ic.ivfDB.copDB.genFormADoc();
            }
            else
            {
                lFormA.form_a_code = txtLabFormACode.Text;
            }
            lFormA.t_patient_id = txtPttId.Text;
            lFormA.t_visit_id = txtVsId.Text;
            lFormA.opu_date = ic.datetoDB(txtOPUDate.Text);
            lFormA.no_of_oocyte_rt = txtNoofOocyteRt.Text;
            lFormA.no_of_oocyte_lt = txtNoofOocyteLt.Text;
            lFormA.status_fresh_sperm = chkFreshSprem.Checked ? "1" : "0";
            lFormA.status_frozen_sperm = chkFrozenSperm.Checked ? "1" : "0";
            lFormA.status_sperm_ha = chkSpermHa.Checked ? "1" : "0";
            lFormA.status_pgs = chkPgs.Checked ? "1" : "0";
            lFormA.status_ngs = chkNgs.Checked ? "1" : "0";
            //lFormA.status_frozen_sperm = "";
            lFormA.ngs_day = chkNgs.Checked ? chkNgsDay3.Checked ? "3": "5" : "0";
            lFormA.status_embryo_tranfer = chkEmbryoTranfer.Checked ? "1" : "0";
            lFormA.embryo_tranfer_fresh_cycle = chkEmbryoTranfer.Checked ? chkEmbryoTranferFresh.Checked ? "1" : "2" : "0";
            lFormA.embryo_tranfer_frozen_cycle = "";
            lFormA.status_embryo_freezing = chkEmbryoFreezing.Checked ? "1" : "0";
            lFormA.embryo_freezing_day = chkEmbryoFreezing.Checked ? chkEmbryoFreezingDay1.Checked ? "1" : chkEmbryoFreezingDay3.Checked ? "3" : chkEmbryoFreezingDay2.Checked ? "2" : "5" : "0";
            lFormA.embryo_tranfer_date =  ic.datetoDB(txtEmbryoTranferDate.Text);
            lFormA.status_et_no_to_tranfer = chkETNotoTranfer.Checked ? "1" : "0";
            lFormA.status_fet = chkFET.Checked ? "1" : "0";
            lFormA.fet_no = txtFETNo.Text;
            lFormA.fet_no_date_freezing = ic.datetoDB(txtFETNoDateFreezing.Text);
            lFormA.status_embryo_glue = chkEmbryoGlue.Checked ? "1" : "0";
            lFormA.status_fet1 = "";
            lFormA.fet1_no = txtFET1No.Text;
            lFormA.fet1_no_date_freezing = txtFET1NoDateFreezing.Text;
            lFormA.status_sperm_analysis = chkSpermAnalysis.Checked ? "1" : "0";
            lFormA.status_spern_freezing = chkSpermFreezing.Checked ? "1" : "0";
            lFormA.pasa_tese_date = txtPasaTeseDate.Text;
            lFormA.iui_date = txtIUIDate.Text;
            lFormA.lab_t_form_acol = "";
            lFormA.sperm_analysis_date_start = ic.datetoDB(txtSpermAnalysisDateStart.Text) +" "+ txtSpermAnalysisTimeStart.Text.Trim();
            lFormA.sperm_analysis_date_end = txtSpermAnalysisDateEnd.Text;
            lFormA.spern_freezing_date_start = ic.datetoDB(txtSpermFreezingDateStart.Text) + " " + txtSpermFreezingTimeStart.Text.Trim();
            lFormA.spern_freezing_date_end = txtSpermFreezingDateEnd.Text;
            lFormA.active = "1";
            lFormA.remark = "";
            lFormA.date_create = "";
            lFormA.date_modi = "";
            lFormA.date_cancel = "";
            lFormA.user_create = "";
            lFormA.user_modi = "";
            lFormA.user_cancel = "";
            lFormA.vn_old = txtVnOld.Text;
            lFormA.hn_old = txtHnOld.Text;
            lFormA.status_assist_hatching = chkAssistHatching.Checked ? "1" : "0";
            lFormA.hn_female = txtHnFeMale.Text;
            lFormA.hn_male = txtHnMale.Text;
            lFormA.name_female = txtNameFeMale.Text;
            lFormA.name_male = txtNameMale.Text;
            lFormA.fresh_sperm_collect_time = txtFreshSpermColTime.Text;
            lFormA.fresh_sperm_end_time = txtFreshSpermEndTime.Text;
            lFormA.doctor_id = cboDoctor.SelectedItem == null ? "" : ((ComboBoxItem)cboDoctor.SelectedItem).Value;
            lFormA.form_a_date = ic.datetoDB(txtFormADate.Text);
            lFormA.remark = cboRemark.Text;
            lFormA.hn_donor = txtHnDonor.Text;
            lFormA.name_donor = txtNameDonor.Text;
            lFormA.dob_donor = ic.datetoDB(txtDonorDob.Text);
            lFormA.dob_female = ic.datetoDB(txtDobFeMale.Text);
            lFormA.dob_male = ic.datetoDB(txtDobMale.Text);
            lFormA.y_selection = chkYselet.Checked ? "1" : "0";
            lFormA.x_selection = chkXselet.Checked ? "1" : "0";
            lFormA.status_wait_confirm_day1 = chkWaitDay1.Checked ? "1" : "0";
            lFormA.status_wait_confirm_opu_date = chkConfirmOpuDate.Checked ? "2" : chkWaitOpuDate.Checked ? "1" : "0";
            lFormA.opu_time = txtOPUTime.Text;
            lFormA.status_opu_active = chkOPUActive.Checked ? "1" : chkOPUUnActive.Checked ? "3" : chkOPUActiveWait.Checked ? "2": "0";
            lFormA.opu_wait_remark = cboOPUWaitRemark.Text;
            lFormA.opu_remark = txtOPURemark.Text;
            lFormA.fet_remark = txtFETRemark.Text;
            lFormA.fet_wait_remark = cboFetWaitRemark.Text;
            lFormA.status_fet_active = chkFetActive.Checked ? "1" : chkFetUnActive.Checked ? "3" : chkFetActiveWait.Checked ? "2" : "0";
            lFormA.status_wait_confirm_fet_date = chkConfirmFetDate.Checked ? "2" : chkWaitFetDate.Checked ? "1" : "0";
            lFormA.opu_time_modi = txtOPUTimeModi.Text;
            lFormA.status_opu_time_modi = chkOpuTimeModi.Checked ? "1" : "0";
            lFormA.fet_day = cboFetDay.SelectedItem == null ? "" : ((ComboBoxItem)cboFetDay.SelectedItem).Value;
            lFormA.fet1_day = cboFet1Day.SelectedItem == null ? "" : ((ComboBoxItem)cboFet1Day.SelectedItem).Value;
            lFormA.frozen_sperm_date = ic.datetoDB(txtFrozenSpermDate.Text);
            lFormA.staff_req_id = txtStfConfirmID.Text;
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (btnSave.Text.Equals("Confirm"))
            {
                
            }
            else
            {
                if (chkNgs.Checked && chkNgsDay3.Checked == false && chkNgsDay5.Checked == false)
                {
                    MessageBox.Show("กรุณาเลือก Biopsy Day", "");
                    return;
                }
                if (chkEmbryoTranfer.Checked && chkEmbryoTranferFresh.Checked == false && chkEmbryoTranferFrozen.Checked == false)
                {
                    MessageBox.Show("กรุณาเลือก Embryo Tranfer", "");
                    return;
                }
                if (chkEmbryoFreezing.Checked && chkEmbryoFreezingDay1.Checked == false && chkEmbryoFreezingDay2.Checked == false && chkEmbryoFreezingDay3.Checked == false && chkEmbryoFreezingDay5.Checked == false)
                {
                    MessageBox.Show("กรุณาเลือก Embryo Freezing", "");
                    return;
                }
                if (chkFreshSprem.Checked && txtFreshSpermColTime.Text.Equals("") && txtFreshSpermEndTime.Text.Equals(""))
                {
                    MessageBox.Show("กรุณาเลือก Fresh Sperm", "");
                    //return;
                }
                ic.cStf.staff_id = "";
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    txtUserReq.Value = ic.cStf.staff_fname_e + " " + ic.cStf.staff_lname_e;
                    txtStfConfirmID.Value = ic.cStf.staff_id;
                    btnSave.Text = "Confirm";
                    btnSave.Image = Resources.Add_ticket_24;
                    stt.Show("<p><b>สวัสดี</b></p>คุณ " + ic.cStf.staff_fname_t + " " + ic.cStf.staff_lname_t + "<br> กรุณายินยันการ confirm อีกครั้ง", btnPrint);
                    //btnSave.Focus();
                    stt.Hide();
                    String re = "", reqid = "";

                    setLabFormA();
                    re = ic.ivfDB.lFormaDB.insertLabFormA(lFormA, txtStfConfirmID.Text);
                    DateTime dt = new DateTime();
                    String dt1 = "";
                    //if(DateTime.TryParse(ic.datetoDB(txtOPUDate.Text), out dt))
                    //{
                    //    dt1 = ic.datetoDB(txtOPUDate.Text);
                    //}
                    if (txtID.Text.Equals(""))
                    {
                        LabRequest lbReq = new LabRequest();
                        if ((gbOPU.Enabled && chkWaitOpuDate.Checked) || (gbOPU.Enabled && chkConfirmOpuDate.Checked))
                        {
                            String dtrid = "";
                            dtrid = cboDoctor.SelectedItem == null ? "" : ((ComboBoxItem)cboDoctor.SelectedItem).Value;
                            reqid = ic.ivfDB.oJsDB.selectByStatusOPU(txtVnOld.Text);
                            lbReq = ic.ivfDB.setLabRequest(txtNameFeMale.Text, txtVnOld.Text, dtrid, cboRemark.Text, txtHnOld.Text, ic.datetoDB(txtDobFeMale.Text), reqid, "112", txtHnMale.Text, txtNameMale.Text, txtHnDonor.Text, txtNameDonor.Text);
                            lbReq.form_a_id = re;
                            String re1 = ic.ivfDB.lbReqDB.insertLabRequest(lbReq, txtStfConfirmID.Text);
                            String re2 = ic.ivfDB.lFormaDB.updateReqIdOPU(re, re1);
                        }

                        if (chkETNotoTranfer.Checked || chkFET.Checked)
                        {
                            String dtrid = "";
                            dtrid = cboDoctor.SelectedItem == null ? "" : ((ComboBoxItem)cboDoctor.SelectedItem).Value;
                            reqid = "";
                            lbReq = new LabRequest();
                            reqid = ic.ivfDB.oJsDB.selectByStatusFET(txtVnOld.Text);
                            lbReq = ic.ivfDB.setLabRequest(txtNameFeMale.Text, txtVnOld.Text, dtrid, cboRemark.Text, txtHnOld.Text, ic.datetoDB(txtDobFeMale.Text), reqid, "160", txtHnMale.Text, txtNameMale.Text, txtHnDonor.Text, txtNameDonor.Text);
                            lbReq.form_a_id = re;
                            String re2 = ic.ivfDB.lbReqDB.insertLabRequest(lbReq, txtStfConfirmID.Text);
                            if (chkFET.Checked)
                            {
                                String re3 = ic.ivfDB.lFormaDB.updateReqIdFet(re, re2);
                            }
                        }
                    }
                    else
                    {
                        //String re1 = ic.ivfDB.lbReqDB.insertLabRequest(lbReq, txtStfConfirmID.Text);
                    }
                    //txtID.Value = (!txtID.Text.Equals("") && re.Equals("1")) ? re : "";        //update
                    long chk = 0;
                    if (long.TryParse(re, out chk))
                    {
                        txtID.Value = txtID.Text.Equals("") ? re : txtID.Text;
                        ic.ivfDB.ovsDB.updateFormA(txtVnOld.Text, txtID.Text);
                        //txtID.Value = re;
                        btnSave.Text = "Save";
                        btnSave.Image = Resources.accept_database24;
                        System.Threading.Thread.Sleep(500);
                    }
                }
                else
                {
                    btnSave.Text = "Save";
                    btnSave.Image = Resources.download_database24;
                }
            }
        }

        private void ChkFreshSprem_CheckStateChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            pnFreshSprem.Enabled = chkFreshSprem.CheckState == CheckState.Checked ? true : false;
        }

        private void ChkSpermFreezing_CheckStateChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            pnSpermFreezing.Enabled = chkSpermFreezing.CheckState == CheckState.Checked ? true : false;
        }

        private void ChkSpermAnalysis_CheckStateChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            pnSpermAnalysis.Enabled = chkSpermAnalysis.CheckState == CheckState.Checked ? true : false;
        }

        private void ChkFET_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            pnFET.Enabled = chkFET.Checked ? true : false;
        }

        private void ChkEmbryoFresh_CheckStateChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            gbEmbryoFresh.Enabled = chkEmbryoFreezing.CheckState == CheckState.Checked ? true : false;
        }

        private void ChkEmbryoTranfer_CheckStateChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            gbEmbryoTranfer.Enabled = chkEmbryoTranfer.CheckState == CheckState.Checked ? true : false;
        }

        private void ChkNgs_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            gbNgs.Enabled = chkNgs.Checked ? true : false;
        }

        private void setControl()
        {
            lFormA = ic.ivfDB.lFormaDB.selectByPk1(lformaId);
            if (lFormA.form_a_id.Equals(""))
            {
                lFormA = ic.ivfDB.lFormaDB.selectByVnOld(vsidOld);
            }
            if (!lFormA.form_a_id.Equals(""))
            {
                setControl1();
            }
            else
            {
                if (!pttid.Equals(""))
                {
                    Patient ptt = new Patient();
                    ptt = ic.ivfDB.pttDB.selectByPk1(pttid);
                    txtHnFeMale.Value = ptt.patient_hn;
                    txtNameFeMale.Value = ptt.Name;
                    //txtDobFeMale.Value = ptt.d
                    if (ptt.t_patient_id.Equals(""))
                    {
                        PatientOld pttO = new PatientOld();
                        Visit vs = new Visit();
                        Patient pttD = new Patient();
                        pttO = ic.ivfDB.pttOldDB.selectByPk1(pttid);
                        vs = ic.ivfDB.vsDB.selectByPk1(vsid);
                        
                        txtHnFeMale.Value = pttO.PIDS;
                        txtNameFeMale.Value = pttO.FullName;
                        txtDobFeMale.Value = pttO.DateOfBirth;
                        txtHnOld.Value = pttO.PIDS;
                        txtVnOld.Value = vsidOld;
                        if (!vs.patient_hn_1.Equals(""))
                        {
                            pttD = ic.ivfDB.pttDB.selectExByPk1(vs.patient_hn_1);
                            txtHnDonor.Value = vs.patient_hn_1;
                            txtNameDonor.Value = pttD.patient_firstname_e + " " + pttD.patient_lastname_e;
                        }
                        else
                        {

                        }
                    }
                }
            }
        }
        private void setControl1()
        {
            txtID.Value = lFormA.form_a_id;
            txtLabFormACode.Value = lFormA.form_a_code;
            txtPttId.Value = lFormA.t_patient_id;
            txtVsId.Value = lFormA.t_visit_id;
            txtVnOld.Value = lFormA.vn_old;
            txtHnOld.Value = lFormA.hn_old;
            txtHnFeMale.Value = lFormA.hn_female;
            txtNameFeMale.Value = lFormA.name_female;
            txtNameMale.Value = lFormA.name_male;
            txtHnMale.Value = lFormA.hn_male;
            //txtLabFormACode.Value = lFormA.form_a_code;

            txtOPUDate.Value = lFormA.opu_date;
            txtNoofOocyteLt.Value = lFormA.no_of_oocyte_lt;
            txtNoofOocyteRt.Value = lFormA.no_of_oocyte_rt;
            chkFreshSprem.Checked = lFormA.status_fresh_sperm.Equals("1") ? true : false;
            txtFreshSpermColTime.Value = lFormA.fresh_sperm_collect_time;
            txtFreshSpermEndTime.Value = lFormA.fresh_sperm_end_time;
            chkFrozenSperm.Checked = lFormA.status_frozen_sperm.Equals("1") ? true : false;
            chkSpermHa.Checked = lFormA.status_sperm_ha.Equals("1") ? true : false;
            chkPgs.Checked = lFormA.status_pgs.Equals("1") ? true : false;
            chkNgs.Checked = lFormA.status_ngs.Equals("1") ? true : false;
            chkNgsDay3.Checked = lFormA.ngs_day.Equals("3") ? true : false;
            chkNgsDay5.Checked = lFormA.ngs_day.Equals("5") ? true : false;
            chkEmbryoTranfer.Checked = lFormA.status_embryo_tranfer.Equals("1") ? true : false;
            chkEmbryoTranferFresh.Checked = lFormA.embryo_tranfer_fresh_cycle.Equals("1") ? true : false;
            chkEmbryoTranferFrozen.Checked = lFormA.embryo_tranfer_fresh_cycle.Equals("2") ? true : false;
            chkEmbryoFreezing.Checked = lFormA.status_embryo_freezing.Equals("1") ? true : false;
            chkEmbryoFreezingDay1.Checked = lFormA.embryo_freezing_day.Equals("1") ? true : false;
            chkEmbryoFreezingDay3.Checked = lFormA.embryo_freezing_day.Equals("3") ? true : false;
            chkEmbryoFreezingDay5.Checked = lFormA.embryo_freezing_day.Equals("5") ? true : false;
            chkEmbryoFreezingDay2.Checked = lFormA.embryo_freezing_day.Equals("2") ? true : false;

            txtEmbryoTranferDate.Value = lFormA.embryo_tranfer_date;
            chkETNotoTranfer.Checked = lFormA.status_et_no_to_tranfer.Equals("1") ? true : false;
            chkFET.Checked = lFormA.status_fet.Equals("1") ? true : false;
            txtFETNo.Value = lFormA.fet_no;
            txtFET1No.Value = lFormA.fet1_no;
            txtFETNoDateFreezing.Value = lFormA.fet_no_date_freezing;
            txtFET1NoDateFreezing.Value = lFormA.fet1_no_date_freezing;
            chkEmbryoGlue.Checked = lFormA.status_embryo_glue.Equals("1") ? true : false;
            chkAssistHatching.Checked = lFormA.status_assist_hatching.Equals("1") ? true : false;

            chkSpermAnalysis.Checked = lFormA.status_sperm_analysis.Equals("1") ? true : false;
            chkSpermFreezing.Checked = lFormA.status_spern_freezing.Equals("1") ? true : false;
            txtSpermAnalysisDateStart.Value = lFormA.sperm_analysis_date_start;
            if (lFormA.sperm_analysis_date_start.Length > 5)
            {
                txtSpermAnalysisTimeStart.Value = lFormA.sperm_analysis_date_start.Substring(lFormA.sperm_analysis_date_start.Length-5);
            }
            txtSpermAnalysisDateEnd.Value = lFormA.sperm_analysis_date_end;
            txtSpermFreezingDateStart.Value = lFormA.spern_freezing_date_start;
            if (lFormA.spern_freezing_date_start.Length > 5)
            {
                txtSpermFreezingTimeStart.Value = lFormA.spern_freezing_date_start.Substring(lFormA.spern_freezing_date_start.Length - 5);
            }
            txtSpermFreezingDateEnd.Value = lFormA.spern_freezing_date_end;
            txtPasaTeseDate.Value = lFormA.pasa_tese_date;
            txtIUIDate.Value = lFormA.iui_date;
            ic.setC1Combo(cboDoctor, lFormA.doctor_id);
            txtFormADate.Value = lFormA.form_a_date;
            cboRemark.Value = lFormA.remark;
            txtHnDonor.Value = lFormA.hn_donor;
            txtNameDonor.Value = lFormA.name_donor;
            txtDonorDob.Value = lFormA.dob_donor;
            txtDobFeMale.Value = lFormA.dob_female;
            txtDobMale.Value = lFormA.dob_male;
            chkYselet.Checked = lFormA.y_selection.Equals("1") ? true : false;
            chkXselet.Checked = lFormA.x_selection.Equals("1") ? true : false;
            chkWaitDay1.Checked = lFormA.status_wait_confirm_day1.Equals("1") ? true : false;
            chkWaitOpuDate.Checked = lFormA.status_wait_confirm_opu_date.Equals("1") ? true : false;
            chkConfirmOpuDate.Checked = lFormA.status_wait_confirm_opu_date.Equals("2") ? true : false;
            txtOPUTime.Value = lFormA.opu_time;

            chkOPUActive.Checked = lFormA.status_opu_active.Equals("1") ? true : false;
            chkOPUUnActive.Checked = lFormA.status_opu_active.Equals("3") ? true : false;
            chkOPUActiveWait.Checked = lFormA.status_opu_active.Equals("2") ? true : false;
            cboOPUWaitRemark.Value = lFormA.opu_wait_remark;
            txtOPURemark.Value = lFormA.opu_remark;
            txtFETRemark.Value = lFormA.fet_remark;
            chkFetActiveWait.Checked = lFormA.status_fet_active.Equals("2") ? true : false;     //chkWaitFetDate
            chkFetActive.Checked = lFormA.status_fet_active.Equals("1") ? true : false;
            chkFetUnActive.Checked = lFormA.status_fet_active.Equals("3") ? true : false;
            cboFetWaitRemark.Value = lFormA.fet_wait_remark;
            chkWaitFetDate.Checked = lFormA.status_wait_confirm_fet_date.Equals("1") ? true : false;
            chkConfirmFetDate.Checked = lFormA.status_wait_confirm_fet_date.Equals("2") ? true : false;
            txtOPUTimeModi.Value = lFormA.opu_time_modi;
            if (lFormA.status_opu_time_modi.Equals("2"))
            {
                lbMessage.Visible = true;
                lbMessage.Show();
                lbMessage.Text = "LAB ได้รับทราบ การแก้ไขเวลา OPU Time ";
                lbMessage.ForeColor = Color.Black;

            }
            else if (lFormA.status_opu_time_modi.Equals("1"))
            {
                lbMessage.Visible = true;
                lbMessage.Show();
                lbMessage.Text = "รอ LAB รับทราบ แก้ไขเวลา OPU Time ";
                lbMessage.ForeColor = Color.Red;
            }
            else
            {
                lbMessage.Visible = false;
                lbMessage.Hide();
                lbMessage.Text = "";
                lbMessage.ForeColor = Color.Black;
            }
            txtFrozenSpermDate.Value = lFormA.frozen_sperm_date;
            ic.setC1Combo(cboFetDay, lFormA.fet_day);
            ic.setC1Combo(cboFet1Day, lFormA.fet1_day);
            txtUserReq.Value = lFormA.staff_req_id;
            //txtDobFeMale.Value = lFormA.dob_female;
            //txtDobMale.Value = lFormA.dob_male;

        }
        private void FrmLabOPUReq_Load(object sender, EventArgs e)
        {

        }
    }
}
