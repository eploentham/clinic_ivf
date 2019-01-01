﻿using C1.Win.C1SuperTooltip;
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

        public FrmLabFormA(IvfControl ic, String lformaId, String pttid, String vsid, String vsidOld)
        {
            InitializeComponent();
            this.ic = ic;
            this.lformaId = lformaId;
            this.vsid = vsid;
            this.pttid = pttid;
            this.vsidOld = vsidOld;
            initConfig();
        }
        private void initConfig()
        {
            lFormA = new LabFormA();
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();

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
            ChkEmbryoTranfer_CheckStateChanged(null, null);
            ChkNgs_CheckedChanged(null, null);
            ChkEmbryoFresh_CheckStateChanged(null, null);
            ChkFET_CheckedChanged(null, null);
            ChkSpermAnalysis_CheckStateChanged(null, null);
            ChkSpermFreezing_CheckStateChanged(null, null);
        }
        private void setLabFormA()
        {
            lFormA.form_a_id = txtID.Text;
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
            lFormA.ngs_day = chkNgs.Checked ? chkNgsDay3.Checked ? "3": "5" : "0";
            lFormA.status_embryo_tranfer = chkEmbryoTranfer.Checked ? "1" : "0";
            lFormA.embryo_tranfer_fresh_cycle = chkEmbryoTranfer.Checked ? chkEmbryoTranferFresh.Checked ? "1" : "2" : "0";
            lFormA.embryo_tranfer_frozen_cycle = "";
            lFormA.status_embryo_freezing = chkEmbryoFreezing.Checked ? "1" : "0";
            lFormA.embryo_freezing_day = chkEmbryoFreezing.Checked ? chkEmbryoFreezingDay1.Checked ? "1" : chkEmbryoFreezingDay3.Checked ? "3" : "5" : "0";
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
            lFormA.sperm_analysis_date_start = ic.datetoDB(txtSpermAnalysisDateStart.Text);
            lFormA.sperm_analysis_date_end = ic.datetoDB(txtSpermAnalysisDateEnd.Text);
            lFormA.spern_freezing_date_start = ic.datetoDB(txtSpermFreezingDateStart.Text);
            lFormA.spern_freezing_date_end = ic.datetoDB(txtSpermFreezingDateEnd.Text);
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
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (btnSave.Text.Equals("Confirm"))
            {
                stt.Hide();
                String re = "";
                
                setLabFormA();
                re = ic.ivfDB.lFormaDB.insertLabFormA(lFormA, txtStfConfirmID.Text);

                //txtID.Value = (!txtID.Text.Equals("") && re.Equals("1")) ? re : "";        //update
                long chk = 0;
                if (long.TryParse(re, out chk))
                {
                    txtID.Value = txtID.Text.Equals("") ? re : txtID.Text;
                                        
                    txtID.Value = re;
                    btnSave.Text = "Save";
                    btnSave.Image = Resources.accept_database24;
                    

                    System.Threading.Thread.Sleep(500);
                    
                }
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
                if (chkEmbryoFreezing.Checked && chkEmbryoFreezingDay1.Checked == false && chkEmbryoFreezingDay3.Checked == false && chkEmbryoFreezingDay5.Checked == false)
                {
                    MessageBox.Show("กรุณาเลือก Embryo Freezing", "");
                    return;
                }
                if (chkFreshSprem.Checked && txtFreshSpermColTime.Text.Equals("") && txtFreshSpermEndTime.Text.Equals(""))
                {
                    
                    MessageBox.Show("กรุณาเลือก Fresh Sperm", "");
                    return;
                }
                ic.cStf.staff_id = "";
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    txtUserReq.Value = ic.cStf.staff_fname_t + " " + ic.cStf.staff_lname_t;
                    txtStfConfirmID.Value = ic.cStf.staff_id;
                    btnSave.Text = "Confirm";
                    btnSave.Image = Resources.Add_ticket_24;
                    stt.Show("<p><b>สวัสดี</b></p>คุณ " + ic.cStf.staff_fname_t + " " + ic.cStf.staff_lname_t + "<br> กรุณายินยันการ confirm อีกครั้ง", btnPrint);
                    btnSave.Focus();
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
                    if (ptt.t_patient_id.Equals(""))
                    {
                        PatientOld pttO = new PatientOld();
                        pttO = ic.ivfDB.pttOldDB.selectByPk1(pttid);
                        txtHnFeMale.Value = pttO.PIDS;
                        txtNameFeMale.Value = pttO.FullName;
                        txtHnOld.Value = pttO.PIDS;
                    }
                }
            }
        }
        private void setControl1()
        {
            txtID.Value = lFormA.form_a_id;
            txtPttId.Value = lFormA.t_patient_id;
            txtVsId.Value = lFormA.t_visit_id;
            txtVnOld.Value = lFormA.vn_old;
            txtHnOld.Value = lFormA.hn_old;
            txtHnFeMale.Value = lFormA.hn_female;
            txtNameFeMale.Value = lFormA.name_female;
            txtNameMale.Value = lFormA.name_male;
            txtHnMale.Value = lFormA.hn_male;
            txtLabFormACode.Value = lFormA.form_a_code;

            txtOPUDate.Value = lFormA.opu_date;
            txtNoofOocyteLt.Value = lFormA.no_of_oocyte_lt;
            txtNoofOocyteRt.Value = lFormA.no_of_oocyte_rt;
            chkFreshSprem.Checked = lFormA.status_fresh_sperm.Equals("1") ? true : false;
            txtFreshSpermColTime.Value = lFormA.fresh_sperm_collect_time;
            txtFreshSpermEndTime.Value = lFormA.fresh_sperm_end_time;
            chkFrozenSperm.Checked = lFormA.status_fresh_sperm.Equals("1") ? true : false;
            chkSpermHa.Checked = lFormA.status_sperm_ha.Equals("1") ? true : false;
            chkPgs.Checked = lFormA.status_pgs.Equals("1") ? true : false;
            chkNgs.Checked = lFormA.status_ngs.Equals("1") ? true : false;
            chkNgsDay3.Checked = lFormA.ngs_day.Equals("3") ? true : false;
            chkNgsDay5.Checked = lFormA.ngs_day.Equals("5") ? true : false;
            chkEmbryoTranfer.Checked = lFormA.status_embryo_tranfer.Equals("1") ? true : false;
            chkEmbryoTranferFresh.Checked = lFormA.embryo_tranfer_fresh_cycle.Equals("1") ? true : false;
            chkEmbryoTranferFrozen.Checked = lFormA.embryo_tranfer_frozen_cycle.Equals("1") ? true : false;
            chkEmbryoFreezing.Checked = lFormA.status_embryo_freezing.Equals("5") ? true : false;
            chkEmbryoFreezingDay1.Checked = lFormA.embryo_freezing_day.Equals("1") ? true : false;
            chkEmbryoFreezingDay3.Checked = lFormA.embryo_freezing_day.Equals("3") ? true : false;
            chkEmbryoFreezingDay5.Checked = lFormA.embryo_freezing_day.Equals("5") ? true : false;

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
            txtSpermAnalysisDateEnd.Value = lFormA.sperm_analysis_date_end;
            txtSpermFreezingDateStart.Value = lFormA.spern_freezing_date_start;
            txtSpermFreezingDateEnd.Value = lFormA.spern_freezing_date_end;
            txtPasaTeseDate.Value = lFormA.pasa_tese_date;
            txtIUIDate.Value = lFormA.iui_date;

        }
        private void FrmLabOPUReq_Load(object sender, EventArgs e)
        {

        }
    }
}
