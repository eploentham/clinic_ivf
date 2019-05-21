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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.gui
{
    public partial class FrmLabSpermAdd : Form
    {
        IvfControl ic;
        String reqId = "", spermId = "";
        LabRequest lbReq;
        LabSperm lsperm;

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;
        Color color;

        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        String theme2 = "Office2007Blue";
        public String StatusSperm = "";

        public FrmLabSpermAdd(IvfControl ic, String reqid, String spermId)
        {
            InitializeComponent();
            this.ic = ic;
            reqId = reqid;
            this.spermId = spermId;

            initConfig();
        }
        public FrmLabSpermAdd(IvfControl ic, String reqid, String spermId, String StatusSperm)
        {
            InitializeComponent();
            this.ic = ic;
            reqId = reqid;
            this.spermId = spermId;
            this.StatusSperm = StatusSperm;

            if (ic.iniC.statusCheckDonor.Equals("1"))
            {
                lsperm = new LabSperm();
                lsperm.status_lab_sperm = StatusSperm;
                if (StatusSperm.Equals("1"))
                {
                    tC.SelectedTab = tabSpermFreezing;
                }
                else if (StatusSperm.Equals("2"))
                {
                    tC.SelectedTab = tabSememAna;
                }
                else if (StatusSperm.Equals("3"))
                {
                    tC.SelectedTab = tabSememPESA;
                }
                else if (StatusSperm.Equals("4"))
                {
                    tC.SelectedTab = TabSpermIUI;
                }
            }
            initConfig();
            
        }
        private void initConfig()
        {
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);

            //C1ThemeController.ApplicationTheme = ic.iniC.themeApplication;
            //theme1.Theme = C1ThemeController.ApplicationTheme;
            theme1.SetTheme(sB, "BeigeOne");
            color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            btnSave.Click += BtnSave_Click;
            btnSfSave.Click += BtnSfSave_Click;
            btnPeSave.Click += BtnPeSave_Click;
            btnIuiSave.Click += BtnIuiSave_Click;
            btnPrintSf.Click += BtnPrintSf_Click;
            btnPrintSa.Click += BtnPrintSa_Click;
            btnPrintPesa.Click += BtnPrintPesa_Click;
            btnPrintIui.Click += BtnPrintIui_Click;

            sB1.Text = "";
            bg = txtHnFeMale.BackColor;
            fc = txtHnFeMale.ForeColor;
            ff = txtHnFeMale.Font;
            ic.ivfDB.dtrOldDB.setCboDoctor(cboDoctor, "");
            ic.ivfDB.fdtDB.setCboSpermAnalysisAppearance(cboAppearance);
            ic.ivfDB.fdtDB.setCboSpermAnalysisAppearance(cboLiquefaction);
            ic.ivfDB.fdtDB.setCboSpermAnalysisAppearance(cboViscosity);
            ic.ivfDB.fdtDB.setCboSpermAnalysisAppearance(cboSfAppearance);
            ic.ivfDB.fdtDB.setCboSpermAnalysisAppearance(cboSfLiquefaction);
            ic.ivfDB.fdtDB.setCboSpermAnalysisAppearance(cboSfViscosity);
            ic.ivfDB.fdtDB.setCboSpermAnalysisAppearance(cboPeAppearance);
            ic.ivfDB.fdtDB.setCboSpermAnalysisAppearance(cboPeLiquefaction);
            ic.ivfDB.fdtDB.setCboSpermAnalysisAppearance(cboPeViscosity);
            ic.ivfDB.fdtDB.setCboSpermAnalysisAppearance(cboIuiAppearance);
            ic.ivfDB.fdtDB.setCboSpermAnalysisAppearance(cboIuiLiquefaction);
            ic.ivfDB.fdtDB.setCboSpermAnalysisAppearance(cboIuiViscosity);

            ic.ivfDB.stfDB.setCboEmbryologist(cboEmbryologistAppv, "");
            ic.ivfDB.stfDB.setCboEmbryologist(cboEmbryologistReport, "");
            ic.ivfDB.stfDB.setCboEmbryologist(cboSfEmbryologistAppv, "");
            ic.ivfDB.stfDB.setCboEmbryologist(cboSfEmbryologistReport, "");
            ic.ivfDB.stfDB.setCboEmbryologist(cboPeEmbryologistAppv, "");
            ic.ivfDB.stfDB.setCboEmbryologist(cboPeEmbryologistReport, "");
            ic.ivfDB.stfDB.setCboEmbryologist(cboIuiEmbryologistAppv, "");
            ic.ivfDB.stfDB.setCboEmbryologist(cboIuiEmbryologistReport, "");
            txtSfAbstinenceday.KeyUp += TxtSfAbstinenceday_KeyUp;
            txtAbstinenceday.KeyUp += TxtAbstinenceday_KeyUp;

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            lsperm = new LabSperm();
            lbReq = new LabRequest();

            setControl();
            setTheme();
        }

        private void TxtAbstinenceday_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if ((e.KeyCode == Keys.Enter))
            {
                if (sender.Equals(txtAbstinenceday))
                {
                    cboAppearance.Focus();
                }
                else if (sender.Equals(txtPh))
                {
                    txtViability.Focus();
                }
                else if (sender.Equals(txtViability))
                {
                    txtVolume.Focus();
                }
                else if (sender.Equals(txtVolume))
                {
                    txtCount.Focus();
                }
                else if (sender.Equals(txtCount))
                {
                    txtTotalCount.Focus();
                }
                else if (sender.Equals(txtTotalCount))
                {
                    txtMotile.Focus();
                }
                else if (sender.Equals(txtMotile))
                {
                    txtTotalMotile.Focus();
                }
                else if (sender.Equals(txtTotalMotile))
                {
                    txtMotility.Focus();
                }
                else if (sender.Equals(txtMotility))
                {
                    txtMotility4.Focus();
                }
                else if (sender.Equals(txtMotility4))
                {
                    txtMotility3.Focus();
                }
                else if (sender.Equals(txtMotility3))
                {
                    txtMotility2.Focus();
                }
                else if (sender.Equals(txtMotility2))
                {
                    txtWbc.Focus();
                }
                else if (sender.Equals(txtWbc))
                {
                    txtNormal.Focus();
                }
                else if (sender.Equals(txtNormal))
                {
                    txtAbnormal.Focus();
                }
                else if (sender.Equals(txtAbnormal))
                {
                    txtHead.Focus();
                }
                else if (sender.Equals(txtHead))
                {
                    txtNeck.Focus();
                }
                else if (sender.Equals(txtNeck))
                {
                    txtTail.Focus();
                }
                else if (sender.Equals(txtTail))
                {
                    txtEjacula.Focus();
                }
                else if (sender.Equals(txtEjacula))
                {
                    txtRecive.Focus();
                }
                else if (sender.Equals(txtRecive))
                {
                    txtExam.Focus();
                }
                else if (sender.Equals(txtExam))
                {
                    txtFinish.Focus();
                }
                else if (sender.Equals(txtFinish))
                {
                    btnSave.Focus();
                }
                //else if (sender.Equals(txtExam))
                //{
                //    txtSfViability.Focus();
                //}
            }
        }

        private void TxtSfAbstinenceday_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if ((e.KeyCode == Keys.Enter))
            {
                if (sender.Equals(txtSfAbstinenceday))
                {
                    cboSfAppearance.Focus();
                }
                else if (sender.Equals(txtSfPh))
                {
                    txtSfViability.Focus();
                }
                else if (sender.Equals(txtSfViability))
                {
                    txtSfVolume.Focus();
                }
                else if (sender.Equals(txtSfVolume))
                {
                    txtSfCount.Focus();
                }
                else if (sender.Equals(txtSfCount))
                {
                    txtSfTotalCount.Focus();
                }
                else if (sender.Equals(txtSfTotalCount))
                {
                    txtSfMotile.Focus();
                }
                else if (sender.Equals(txtSfMotile))
                {
                    txtSfTotalMotile.Focus();
                }
                else if (sender.Equals(txtSfTotalMotile))
                {
                    txtSfMotility.Focus();
                }
                else if (sender.Equals(txtSfMotility))
                {
                    txtSfMotility4.Focus();
                }
                else if (sender.Equals(txtSfMotility4))
                {
                    txtSfMotility3.Focus();
                }
                else if (sender.Equals(txtSfMotility3))
                {
                    txtSfMotility2.Focus();
                }
                else if (sender.Equals(txtSfMotility2))
                {
                    txtSfWbc.Focus();
                }
                else if (sender.Equals(txtSfWbc))
                {
                    txtSfNormal.Focus();
                }
                else if (sender.Equals(txtSfNormal))
                {
                    txtSfAbnormal.Focus();
                }
                else if (sender.Equals(txtSfAbnormal))
                {
                    txtSfHead.Focus();
                }
                else if (sender.Equals(txtSfHead))
                {
                    txtSfNeck.Focus();
                }
                else if (sender.Equals(txtSfNeck))
                {
                    txtSfTail.Focus();
                }
                else if (sender.Equals(txtSfTail))
                {
                    txtSfVial.Focus();
                }
                else if (sender.Equals(txtSfVial))
                {
                    txtSfEjacula.Focus();
                }
                else if (sender.Equals(txtSfEjacula))
                {
                    txtSfRecive.Focus();
                }
                else if (sender.Equals(txtSfRecive))
                {
                    txtSfExam.Focus();
                }
                else if (sender.Equals(txtSfExam))
                {
                    txtSfFinish.Focus();
                }
                else if (sender.Equals(txtSfFinish))
                {
                    btnSfSave.Focus();
                }
            }
        }

        private void BtnPrintIui_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmReport frm = new FrmReport(ic);
            DataTable dt = new DataTable();
            dt = ic.ivfDB.lspermDB.selectByPk(txtIuiID.Text);
            //FrmWaiting frmW = new FrmWaiting();
            //frmW.Show();
            frm.setSpermIui(dt);
            frm.ShowDialog(this);
        }

        private void BtnPrintPesa_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmReport frm = new FrmReport(ic);
            DataTable dt = new DataTable();
            dt = ic.ivfDB.lspermDB.selectByPk(txtPeID.Text);
            //FrmWaiting frmW = new FrmWaiting();
            //frmW.Show();
            frm.setSpermPesa(dt);
            frm.ShowDialog(this);
        }

        private void BtnPrintSa_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmReport frm = new FrmReport(ic);
            DataTable dt = new DataTable();
            dt = ic.ivfDB.lspermDB.selectByPk(txtID.Text);
            //FrmWaiting frmW = new FrmWaiting();
            //frmW.Show();
            frm.setSpermSa(dt);
            frm.ShowDialog(this);
        }

        private void BtnPrintSf_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmReport frm = new FrmReport(ic);
            DataTable dt = new DataTable();
            dt = ic.ivfDB.lspermDB.selectByPk(txtSfID.Text);
            //FrmWaiting frmW = new FrmWaiting();
            //frmW.Show();
            frm.setSpermSf(dt);
            frm.ShowDialog(this);
        }

        private void BtnIuiSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.cStf.staff_id = "";
            FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            frm.ShowDialog(this);
            if (!ic.cStf.staff_id.Equals(""))
            {
                long chk = 0, chk1 = 0, max = 0;
                setSpermIui();
                String re = ic.ivfDB.lspermDB.insertLabSperm(lsperm, ic.cStf.staff_id);
                if (long.TryParse(re, out chk))
                {
                    sB1.Text = "Save IUI done";
                }
            }
        }

        private void BtnPeSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.cStf.staff_id = "";
            FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            frm.ShowDialog(this);
            if (!ic.cStf.staff_id.Equals(""))
            {
                long chk = 0, chk1 = 0, max = 0;
                setSpermPesa();
                String re = ic.ivfDB.lspermDB.insertLabSperm(lsperm, ic.cStf.staff_id);
                if (long.TryParse(re, out chk))
                {
                    sB1.Text = "Save PESA done";
                }
            }
        }

        private void BtnSfSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.cStf.staff_id = "";
            FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            frm.ShowDialog(this);
            if (!ic.cStf.staff_id.Equals(""))
            {
                long chk = 0, chk1 = 0, max = 0;
                setSpermFreezing();
                String re = ic.ivfDB.lspermDB.insertLabSperm(lsperm, ic.cStf.staff_id);
                if (long.TryParse(re, out chk))
                {
                    sB1.Text = "Save Freezing done";
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.cStf.staff_id = "";
            FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            frm.ShowDialog(this);
            if (!ic.cStf.staff_id.Equals(""))
            {
                long chk = 0, chk1 = 0, max = 0;
                setSperm();
                String re = ic.ivfDB.lspermDB.insertLabSperm(lsperm, ic.cStf.staff_id);
                if (long.TryParse(re, out chk))
                {
                    sB1.Text = "Save done";
                }
            }
        }
        private void setControl()
        {
            lsperm = ic.ivfDB.lspermDB.selectByPk1(spermId);
            lbReq = ic.ivfDB.lbReqDB.selectByPk1(lsperm.req_id);
            ic.setC1Combo(cboEmbryologistAppv, lsperm.staff_id_report);
            ic.setC1Combo(cboEmbryologistReport, lsperm.staff_id_approve);
            txtSfApproveDate.Value = lsperm.date_approve;
            txtSfReportDate.Value = lsperm.date_report;
            txtApproveDate.Value = lsperm.date_approve;
            txtReportDate.Value = lsperm.date_report;
            txtPeApproveDate.Value = lsperm.date_approve;
            txtPeReportDate.Value = lsperm.date_report;
            txtIuiApproveDate.Value = lsperm.date_approve;
            txtIuiReportDate.Value = lsperm.date_report;
            if (ic.iniC.statusCheckDonor.Equals("1"))
            {
                lsperm = new LabSperm();
                lsperm.status_lab_sperm = StatusSperm;
            }
            if (lsperm.status_lab_sperm.Equals("1"))
            {
                setControlSpermFreezing();
            }
            else if (lsperm.status_lab_sperm.Equals("2"))
            {
                setControlAnalysis();
            }
            else if (lsperm.status_lab_sperm.Equals("3"))
            {
                setControlPesa();
            }
            else if (lsperm.status_lab_sperm.Equals("4"))
            {
                setControlIui();
            }
        }
        private void setControlAnalysis()
        {
            txtID.Value = lsperm.sperm_id;
            txtHnFeMale.Value = lsperm.hn_female;
            txtHnMale.Value = lsperm.hn_male;
            txtNameFeMale.Value = lsperm.name_female;
            txtNameMale.Value = lsperm.name_male;
            txtLabReqCode.Value = lbReq.req_code;
            txtDobFeMale.Value = lsperm.dob_female;
            txtDobMale.Value = lsperm.dob_male;
            ic.setC1Combo(cboDoctor, lsperm.doctor_id);
            ic.setC1Combo(cboAppearance, lsperm.appearance);
            ic.setC1Combo(cboLiquefaction, lsperm.liquefaction);
            ic.setC1Combo(cboViscosity, lsperm.viscosity);

            txtSpermDate.Value = lsperm.sperm_date;
            txtAbstinenceday.Value = lsperm.abstinence_day;
            txtPh.Value = lsperm.ph;
            txtViability.Value = lsperm.viability;
            txtVolume.Value = lsperm.volume1;
            txtCount.Value = lsperm.count1;
            txtTotalCount.Value = lsperm.total_count;
            txtMotile.Value = lsperm.motile;
            txtMotility.Value = lsperm.motility;
            txtTotalMotile.Value = lsperm.total_motile;
            txtMotility4.Value = lsperm.motility_rate_4;
            txtMotility3.Value = lsperm.motility_rate_3;
            txtMotility2.Value = lsperm.motility_rate_2;
            //txtMotility1.Value = lsperm.motility_rate_1;
            txtWbc.Value = lsperm.wbc;
            txtEjacula.Value = lsperm.ejaculation_time;
            txtRecive.Value = lsperm.recive_time;
            txtExam.Value = lsperm.examination_time;
            txtFinish.Value = lsperm.finish_time;
            txtNormal.Value = lsperm.morphology_normal;
            txtAbnormal.Value = lsperm.morphology_abnormal;
            txtHead.Value = lsperm.morphology_head_defect;
            txtNeck.Value = lsperm.morphology_neck_defect;
            txtTail.Value = lsperm.morphology_tail_defect;
            txtApproveResult.Value = lsperm.staff_id_approve;
            txtApproveDate.Value = lsperm.date_approve;
            //txtSpermTime.Value = lsperm.time;
            ic.ivfDB.lspermDB.setCboRemark(cboRemark);
            ic.setC1ComboByName(cboRemark, lsperm.remark);
        }
        private void setControlSpermFreezing()
        {
            txtSfID.Value = lsperm.sperm_id;
            txtSfHnFeMale.Value = lsperm.hn_female;
            txtSfHnMale.Value = lsperm.hn_male;
            txtSfNameFeMale.Value = lsperm.name_female;
            txtSfNameMale.Value = lsperm.name_male;
            txtSfLabReqCode.Value = lbReq.req_code;
            txtSfDobFeMale.Value = lsperm.dob_female;
            txtSfDobMale.Value = lsperm.dob_male;
            ic.setC1Combo(cboSfDoctor, lsperm.doctor_id);
            ic.setC1Combo(cboSfAppearance, lsperm.appearance);
            ic.setC1Combo(cboSfLiquefaction, lsperm.liquefaction);
            ic.setC1Combo(cboSfViscosity, lsperm.viscosity);
            ic.setC1Combo(cboSfEmbryologistAppv, lsperm.staff_id_approve);
            ic.setC1Combo(cboSfEmbryologistReport, lsperm.staff_id_report);

            txtSfSpermDate.Value = lsperm.sperm_date;
            txtSfAbstinenceday.Value = lsperm.abstinence_day;
            txtSfPh.Value = lsperm.ph;
            txtSfViability.Value = lsperm.viability;
            txtSfVolume.Value = lsperm.volume1;
            txtSfCount.Value = lsperm.count1;
            txtSfTotalCount.Value = lsperm.total_count;
            txtSfMotile.Value = lsperm.motile;
            txtSfMotility.Value = lsperm.motility;
            txtSfTotalMotile.Value = lsperm.total_motile;
            txtSfMotility4.Value = lsperm.motility_rate_4;
            txtSfMotility3.Value = lsperm.motility_rate_3;
            txtSfMotility2.Value = lsperm.motility_rate_2;
            txtSfVial.Value = lsperm.no_of_vail;
            txtSfWbc.Value = lsperm.wbc;
            txtSfEjacula.Value = lsperm.ejaculation_time;
            txtSfRecive.Value = lsperm.recive_time;
            txtSfExam.Value = lsperm.examination_time;
            txtSfFinish.Value = lsperm.finish_time;
            txtSfNormal.Value = lsperm.morphology_normal;
            txtSfAbnormal.Value = lsperm.morphology_abnormal;
            txtSfHead.Value = lsperm.morphology_head_defect;
            txtSfNeck.Value = lsperm.morphology_neck_defect;
            txtSfTail.Value = lsperm.morphology_tail_defect;
            txtSfApproveResult.Value = lsperm.staff_id_approve;
            txtSfApproveDate.Value = lsperm.date_approve;
            //txtSpermTime.Value = lsperm.time;
            ic.ivfDB.lspermDB.setCboRemark(cboSfRemark);
            ic.setC1ComboByName(cboSfRemark, lsperm.remark);
        }
        private void setControlPesa()
        {
            txtPeID.Value = lsperm.sperm_id;
            txtPeHnFeMale.Value = lsperm.hn_female;
            txtPeHnMale.Value = lsperm.hn_male;
            txtPeNameFeMale.Value = lsperm.name_female;
            txtPeNameMale.Value = lsperm.name_male;
            txtPeLabReqCode.Value = lbReq.req_code;
            txtPeDobFeMale.Value = lsperm.dob_female;
            txtPeDobMale.Value = lsperm.dob_male;
            ic.setC1Combo(cboPeDoctor, lsperm.doctor_id);
            ic.setC1Combo(cboPeAppearance, lsperm.appearance);
            ic.setC1Combo(cboPeLiquefaction, lsperm.liquefaction);
            ic.setC1Combo(cboPeViscosity, lsperm.viscosity);

            txtPeSpermDate.Value = lsperm.sperm_date;
            txtPeAbstinenceday.Value = lsperm.abstinence_day;
            txtPePh.Value = lsperm.ph;
            txtPeViability.Value = lsperm.viability;
            txtPeVolume.Value = lsperm.volume1;
            txtPeCount.Value = lsperm.count1;
            txtPeTotalCount.Value = lsperm.total_count;
            txtPeMotile.Value = lsperm.motile;
            txtPeMotility.Value = lsperm.motility;
            txtPeTotalMotile.Value = lsperm.total_motile;
            txtPeMotility4.Value = lsperm.motility_rate_4;
            txtPeMotility3.Value = lsperm.motility_rate_3;
            txtPeMotility2.Value = lsperm.motility_rate_2;
            //txtMotility1.Value = lsperm.motility_rate_1;
            txtPeVial.Value = lsperm.no_of_vail;
            txtPeEjacula.Value = lsperm.ejaculation_time;
            txtPeRecive.Value = lsperm.recive_time;
            txtPeExam.Value = lsperm.examination_time;
            txtPeFinish.Value = lsperm.finish_time;
            //txtPeNormal.Value = lsperm.morphology_normal;
            //txtPeAbnormal.Value = lsperm.morphology_abnormal;
            //txtPeHead.Value = lsperm.morphology_head_defect;
            //txtPeNeck.Value = lsperm.morphology_neck_defect;
            //txtPeTail.Value = lsperm.morphology_tail_defect;
            txtPeApproveResult.Value = lsperm.staff_id_approve;
            txtPeApproveDate.Value = lsperm.date_approve;
            //txtSpermTime.Value = lsperm.time;
            ic.ivfDB.lspermDB.setCboRemark(cboPeRemark);
            ic.setC1ComboByName(cboPeRemark, lsperm.remark);
        }
        private void setControlIui()
        {
            txtIuiID.Value = lsperm.sperm_id;
            txtIuiHnFeMale.Value = lsperm.hn_female;
            txtIuiHnMale.Value = lsperm.hn_male;
            txtIuiNameFeMale.Value = lsperm.name_female;
            txtIuiNameMale.Value = lsperm.name_male;
            txtIuiLabReqCode.Value = lbReq.req_code;
            txtIuiDobFeMale.Value = lsperm.dob_female;
            txtIuiDobMale.Value = lsperm.dob_male;
            ic.setC1Combo(cboIuiDoctor, lsperm.doctor_id);
            ic.setC1Combo(cboIuiAppearance, lsperm.appearance);
            ic.setC1Combo(cboIuiLiquefaction, lsperm.liquefaction);
            ic.setC1Combo(cboIuiViscosity, lsperm.viscosity);

            txtIuiSpermDate.Value = lsperm.sperm_date;
            txtIuiAbstinenceday.Value = lsperm.abstinence_day;
            //txtIuiPh.Value = lsperm.ph;
            //txtIuiViability.Value = lsperm.viability;
            txtIuiVolume.Value = lsperm.volume1;
            txtIuiCount.Value = lsperm.count1;
            txtIuiTotalCount.Value = lsperm.total_count;
            txtIuiMotile.Value = lsperm.motile;
            txtIuiMotility.Value = lsperm.motility;
            txtIuiTotalMotile.Value = lsperm.total_motile;
            txtIuiMotility4.Value = lsperm.motility_rate_4;
            txtIuiMotility3.Value = lsperm.motility_rate_3;
            txtIuiMotility2.Value = lsperm.motility_rate_2;

            txtIuiVolumePost.Value = lsperm.volume1;
            txtIuiCountPost.Value = lsperm.count1;
            txtIuiTotalCountPost.Value = lsperm.total_count;
            txtIuiMotilePost.Value = lsperm.motile;
            txtIuiMotilityPost.Value = lsperm.motility;
            txtIuiTotalMotilePost.Value = lsperm.total_motile;
            txtIuiMotility4Post.Value = lsperm.motility_rate_4;
            txtIuiMotility3Post.Value = lsperm.motility_rate_3;
            txtIuiMotility2Post.Value = lsperm.motility_rate_2;
            //txtMotility1.Value = lsperm.motility_rate_1;
            //txtIuiWbc.Value = lsperm.wbc;
            txtIuiEjacula.Value = lsperm.ejaculation_time;
            txtIuiRecive.Value = lsperm.recive_time;
            txtIuiExam.Value = lsperm.examination_time;
            txtIuiFinish.Value = lsperm.finish_time;
            //txtIuiNormal.Value = lsperm.morphology_normal;
            //txtIuiAbnormal.Value = lsperm.morphology_abnormal;
            //txtIuiHead.Value = lsperm.morphology_head_defect;
            //txtIuiNeck.Value = lsperm.morphology_neck_defect;
            //txtIuiTail.Value = lsperm.morphology_tail_defect;
            txtIuiApproveResult.Value = lsperm.staff_id_approve;
            txtIuiApproveDate.Value = lsperm.date_approve;
            //txtSpermTime.Value = lsperm.time;

            txtIuiVolumePost.Value = lsperm.post_volume1;
            txtIuiCountPost.Value = lsperm.post_count;
            txtIuiTotalCountPost.Value = lsperm.post_total_count;
            txtIuiMotilePost.Value = lsperm.post_motile;
            txtIuiTotalMotilePost.Value = lsperm.post_total_motile;
            txtIuiMotility4Post.Value = lsperm.post_motility_rate_4;
            txtIuiMotility3Post.Value = lsperm.post_motility_rate_3;
            txtIuiMotility2Post.Value = lsperm.post_motility_rate_2;
            txtIuiMotilityPost.Value = lsperm.post_motility;
            ic.ivfDB.lspermDB.setCboRemark(cboIuiRemark);
            ic.setC1ComboByName(cboIuiRemark, lsperm.remark);
        }
        private void setSperm()
        {
            lsperm.sperm_id = txtID.Text;
            lsperm.hn_female = txtHnFeMale.Text;
            lsperm.hn_male = txtHnMale.Text;
            lsperm.name_female = txtNameFeMale.Text;
            lsperm.name_male = txtNameMale.Text;
            lbReq.req_code = txtLabReqCode.Text;
            lsperm.dob_female = ic.datetoDB(txtDobFeMale.Text);
            lsperm.dob_male = ic.datetoDB(txtDobMale.Text);
            lsperm.doctor_id = cboDoctor.SelectedItem == null ? "" : ((ComboBoxItem)cboDoctor.SelectedItem).Value;
            lsperm.appearance = cboAppearance.SelectedItem == null ? "" : ((ComboBoxItem)cboAppearance.SelectedItem).Value;
            lsperm.liquefaction = cboLiquefaction.SelectedItem == null ? "" : ((ComboBoxItem)cboLiquefaction.SelectedItem).Value;
            lsperm.viscosity = cboViscosity.SelectedItem == null ? "" : ((ComboBoxItem)cboViscosity.SelectedItem).Value;

            lsperm.sperm_date = txtSpermDate.Text;
            lsperm.abstinence_day = txtAbstinenceday.Text;
            lsperm.ph = txtPh.Text;
            lsperm.viability = txtViability.Text;
            lsperm.volume1 = txtVolume.Text;
            lsperm.count1 = txtCount.Text;
            lsperm.total_count = txtTotalCount.Text;
            lsperm.motile = txtMotile.Text;
            lsperm.motility = txtMotility.Text;
            lsperm.motility_rate_4 = txtMotility4.Text;
            lsperm.motility_rate_3 = txtMotility3.Text;
            lsperm.motility_rate_2 = txtMotility2.Text;
            lsperm.total_motile = txtTotalMotile.Text;
            //lsperm.no_of_vail = txtSfVial.Text;
            lsperm.wbc = txtWbc.Text;
            lsperm.ejaculation_time = txtEjacula.Text;
            lsperm.recive_time = txtRecive.Text;
            lsperm.examination_time = txtExam.Text;
            lsperm.finish_time = txtFinish.Text;
            lsperm.morphology_normal = txtNormal.Text;
            lsperm.morphology_abnormal = txtAbnormal.Text;
            lsperm.morphology_head_defect = txtHead.Text;
            lsperm.morphology_neck_defect = txtNeck.Text;
            lsperm.morphology_tail_defect = txtTail.Text;
            lsperm.staff_id_approve = txtApproveResult.Text;
            lsperm.date_approve = txtApproveDate.Text;
            lsperm.staff_id_report = cboEmbryologistReport.SelectedItem == null ? "0" : ((ComboBoxItem)cboEmbryologistReport.SelectedItem).Value;
            lsperm.staff_id_approve = cboEmbryologistAppv.SelectedItem == null ? "0" : ((ComboBoxItem)cboEmbryologistAppv.SelectedItem).Value;
            lsperm.date_approve = ic.datetoDB(txtApproveDate.Text);
            lsperm.date_report = ic.datetoDB(txtReportDate.Text);
            lsperm.remark = cboSfRemark.Text;
        }
        private void setSpermFreezing()
        {
            lsperm.sperm_id = txtSfID.Text;
            lsperm.hn_female = txtSfHnFeMale.Text;
            lsperm.hn_male = txtSfHnMale.Text;
            lsperm.name_female = txtSfNameFeMale.Text;
            lsperm.name_male = txtSfNameMale.Text;
            lbReq.req_code = txtSfLabReqCode.Text;
            lsperm.dob_female = ic.datetoDB(txtSfDobFeMale.Text);
            lsperm.dob_male = ic.datetoDB(txtSfDobMale.Text);
            lsperm.doctor_id = cboSfDoctor.SelectedItem == null ? "" : ((ComboBoxItem)cboSfDoctor.SelectedItem).Value;
            lsperm.appearance = cboSfAppearance.SelectedItem == null ? "" : ((ComboBoxItem)cboSfAppearance.SelectedItem).Value;
            lsperm.liquefaction = cboSfLiquefaction.SelectedItem == null ? "" : ((ComboBoxItem)cboSfLiquefaction.SelectedItem).Value;
            lsperm.viscosity = cboSfViscosity.SelectedItem == null ? "" : ((ComboBoxItem)cboSfViscosity.SelectedItem).Value;

            lsperm.sperm_date = txtSfSpermDate.Text;
            lsperm.abstinence_day = txtSfAbstinenceday.Text;
            lsperm.ph = txtSfPh.Text;
            lsperm.viability = txtSfViability.Text;
            lsperm.volume1 = txtSfVolume.Text;
            lsperm.count1 = txtSfCount.Text;
            lsperm.total_count = txtSfTotalCount.Text;
            lsperm.motile = txtSfMotile.Text;
            lsperm.motility = txtSfMotility.Text;
            lsperm.total_motile = txtTotalMotile.Text;
            lsperm.motility_rate_4 = txtSfMotility4.Text;
            lsperm.motility_rate_3 = txtSfMotility3.Text;
            lsperm.motility_rate_2 = txtSfMotility2.Text;
            lsperm.no_of_vail = txtSfVial.Text;
            lsperm.wbc = txtSfWbc.Text;
            lsperm.ejaculation_time = txtSfEjacula.Text;
            lsperm.recive_time = txtSfRecive.Text;
            lsperm.examination_time = txtSfExam.Text;
            lsperm.finish_time = txtSfFinish.Text;
            lsperm.morphology_normal = txtSfNormal.Text;
            lsperm.morphology_abnormal = txtSfAbnormal.Text;
            lsperm.morphology_head_defect = txtSfHead.Text;
            lsperm.morphology_neck_defect = txtSfNeck.Text;
            lsperm.morphology_tail_defect = txtSfTail.Text;
            lsperm.staff_id_approve = txtSfApproveResult.Text;
            lsperm.date_approve = txtSfApproveDate.Text;
            lsperm.staff_id_report = cboSfEmbryologistReport.SelectedItem == null ? "0" : ((ComboBoxItem)cboSfEmbryologistReport.SelectedItem).Value;
            lsperm.staff_id_approve = cboSfEmbryologistAppv.SelectedItem == null ? "0" : ((ComboBoxItem)cboSfEmbryologistAppv.SelectedItem).Value;
            lsperm.date_approve = ic.datetoDB(txtSfApproveDate.Text);
            lsperm.date_report = ic.datetoDB(txtSfReportDate.Text);
            lsperm.remark = cboSfRemark.Text;
        }
        private void setSpermPesa()
        {
            lsperm.sperm_id = txtPeID.Text;
            lsperm.hn_female = txtPeHnFeMale.Text;
            lsperm.hn_male = txtPeHnMale.Text;
            lsperm.name_female = txtPeNameFeMale.Text;
            lsperm.name_male = txtPeNameMale.Text;
            lbReq.req_code = txtPeLabReqCode.Text;
            lsperm.dob_female = ic.datetoDB(txtPeDobFeMale.Text);
            lsperm.dob_male = ic.datetoDB(txtPeDobMale.Text);
            lsperm.doctor_id = cboPeDoctor.SelectedItem == null ? "" : ((ComboBoxItem)cboPeDoctor.SelectedItem).Value;
            lsperm.appearance = cboPeAppearance.SelectedItem == null ? "" : ((ComboBoxItem)cboPeAppearance.SelectedItem).Value;
            lsperm.liquefaction = cboPeLiquefaction.SelectedItem == null ? "" : ((ComboBoxItem)cboPeLiquefaction.SelectedItem).Value;
            lsperm.viscosity = cboPeViscosity.SelectedItem == null ? "" : ((ComboBoxItem)cboPeViscosity.SelectedItem).Value;

            lsperm.sperm_date = txtPeSpermDate.Text;
            lsperm.abstinence_day = txtPeAbstinenceday.Text;
            lsperm.ph = txtPePh.Text;
            lsperm.viability = txtPeViability.Text;
            lsperm.volume1 = txtPeVolume.Text;
            lsperm.count1 = txtPeCount.Text;
            lsperm.total_count = txtPeTotalCount.Text;
            lsperm.motile = txtPeMotile.Text;
            lsperm.motility = txtPeMotility.Text;
            lsperm.total_motile = txtTotalMotile.Text;
            lsperm.motility_rate_4 = txtPeMotility4.Text;
            lsperm.motility_rate_3 = txtPeMotility3.Text;
            lsperm.motility_rate_2 = txtPeMotility2.Text;
            lsperm.no_of_vail = txtPeVial.Text;
            //lsperm.wbc = txtPeWbc.Text;
            lsperm.ejaculation_time = txtPeEjacula.Text;
            lsperm.recive_time = txtPeRecive.Text;
            lsperm.examination_time = txtPeExam.Text;
            lsperm.finish_time = txtPeFinish.Text;
            //lsperm.morphology_normal = txtPeNormal.Text;
            //lsperm.morphology_abnormal = txtPeAbnormal.Text;
            //lsperm.morphology_head_defect = txtPeHead.Text;
            //lsperm.morphology_neck_defect = txtPeNeck.Text;
            //lsperm.morphology_tail_defect = txtPeTail.Text;
            lsperm.staff_id_approve = txtPeApproveResult.Text;
            lsperm.date_approve = txtPeApproveDate.Text;
            lsperm.staff_id_report = cboEmbryologistReport.SelectedItem == null ? "0" : ((ComboBoxItem)cboEmbryologistReport.SelectedItem).Value;
            lsperm.staff_id_approve = cboEmbryologistAppv.SelectedItem == null ? "0" : ((ComboBoxItem)cboEmbryologistAppv.SelectedItem).Value;
            lsperm.date_approve = ic.datetoDB(txtPeApproveDate.Text);
            lsperm.date_report = ic.datetoDB(txtPeReportDate.Text);
            lsperm.remark = cboPeRemark.Text;
        }
        private void setSpermIui()
        {
            lsperm.sperm_id = txtIuiID.Text;
            lsperm.hn_female = txtIuiHnFeMale.Text;
            lsperm.hn_male = txtIuiHnMale.Text;
            lsperm.name_female = txtIuiNameFeMale.Text;
            lsperm.name_male = txtIuiNameMale.Text;
            lbReq.req_code = txtIuiLabReqCode.Text;
            lsperm.dob_female = ic.datetoDB(txtIuiDobFeMale.Text);
            lsperm.dob_male = ic.datetoDB(txtIuiDobMale.Text);
            lsperm.doctor_id = cboIuiDoctor.SelectedItem == null ? "" : ((ComboBoxItem)cboIuiDoctor.SelectedItem).Value;
            lsperm.appearance = cboIuiAppearance.SelectedItem == null ? "" : ((ComboBoxItem)cboIuiAppearance.SelectedItem).Value;
            lsperm.liquefaction = cboIuiLiquefaction.SelectedItem == null ? "" : ((ComboBoxItem)cboIuiLiquefaction.SelectedItem).Value;
            lsperm.viscosity = cboIuiViscosity.SelectedItem == null ? "" : ((ComboBoxItem)cboIuiViscosity.SelectedItem).Value;

            lsperm.sperm_date = txtIuiSpermDate.Text;
            lsperm.abstinence_day = txtIuiAbstinenceday.Text;
            //lsperm.ph = txtIuiPh.Text;
            //lsperm.viability = txtIuiViability.Text;
            lsperm.volume1 = txtIuiVolume.Text;
            lsperm.count1 = txtIuiCount.Text;
            lsperm.total_count = txtIuiTotalCount.Text;
            lsperm.motile = txtIuiMotile.Text;
            lsperm.motility = txtIuiMotility.Text;
            lsperm.motility_rate_4 = txtIuiMotility4.Text;
            lsperm.motility_rate_3 = txtIuiMotility3.Text;
            lsperm.motility_rate_2 = txtIuiMotility2.Text;
            lsperm.total_motile = txtIuiTotalMotile.Text;

            lsperm.volume1 = txtIuiVolumePost.Text;
            lsperm.count1 = txtIuiCountPost.Text;
            lsperm.total_count = txtIuiTotalCountPost.Text;
            lsperm.motile = txtIuiMotilePost.Text;
            lsperm.motility = txtIuiMotilityPost.Text;
            lsperm.total_motile = txtIuiTotalMotilePost.Text;
            lsperm.motility_rate_4 = txtIuiMotility4Post.Text;
            lsperm.motility_rate_3 = txtIuiMotility3Post.Text;
            lsperm.motility_rate_2 = txtIuiMotility2Post.Text;
            //lsperm.no_of_vail = txtSfVial.Text;
            //lsperm.wbc = txtIuiWbc.Text;
            lsperm.ejaculation_time = txtIuiEjacula.Text;
            lsperm.recive_time = txtIuiRecive.Text;
            lsperm.examination_time = txtIuiExam.Text;
            lsperm.finish_time = txtIuiFinish.Text;
            //lsperm.morphology_normal = txtIuiNormal.Text;
            //lsperm.morphology_abnormal = txtIuiAbnormal.Text;
            //lsperm.morphology_head_defect = txtIuiHead.Text;
            //lsperm.morphology_neck_defect = txtIuiNeck.Text;
            //lsperm.morphology_tail_defect = txtIuiTail.Text;
            lsperm.staff_id_approve = txtIuiApproveResult.Text;
            lsperm.date_approve = txtIuiApproveDate.Text;
            lsperm.staff_id_report = cboEmbryologistReport.SelectedItem == null ? "0" : ((ComboBoxItem)cboEmbryologistReport.SelectedItem).Value;
            lsperm.staff_id_approve = cboEmbryologistAppv.SelectedItem == null ? "0" : ((ComboBoxItem)cboEmbryologistAppv.SelectedItem).Value;
            lsperm.date_approve = ic.datetoDB(txtIuiApproveDate.Text);
            lsperm.date_report = ic.datetoDB(txtIuiReportDate.Text);

            lsperm.post_volume1 = txtIuiVolumePost.Text;
            lsperm.post_count = txtIuiCountPost.Text;
            lsperm.post_total_count = txtIuiTotalCountPost.Text;
            lsperm.post_motile = txtIuiMotilePost.Text;
            lsperm.post_total_motile = txtIuiTotalMotilePost.Text;
            lsperm.post_motility_rate_4 = txtIuiMotility4Post.Text;
            lsperm.post_motility_rate_3 = txtIuiMotility3Post.Text;
            lsperm.post_motility_rate_2 = txtIuiMotility2Post.Text;
            lsperm.post_motility = txtIuiMotilityPost.Text;
            lsperm.remark = cboIuiRemark.Text;
        }
        private void setTheme()
        {
            //theme2 = "Office2007Blue";
            if (lsperm.status_lab_sperm.Equals("1"))
            {
                theme2 = "Office2013Red";
                theme2 = "Office2016Colorful";
                theme1.SetTheme(this, theme2);
                theme1.SetTheme(panel7, theme2);
                theme1.SetTheme(groupBox3, theme2);
                theme1.SetTheme(groupBox4, theme2);
                foreach (Control ctl in panel7.Controls)
                {
                    if (ctl is C1PictureBox) continue;
                    theme1.SetTheme(ctl, theme2);
                }
                foreach (Control ctl in groupBox3.Controls)
                {
                    if (ctl is C1PictureBox) continue;
                    theme1.SetTheme(ctl, theme2);
                }
                foreach (Control ctl in groupBox4.Controls)
                {
                    if (ctl is C1PictureBox) continue;
                    theme1.SetTheme(ctl, theme2);
                }
            }
            else if (lsperm.status_lab_sperm.Equals("2"))
            {
                theme2 = "Office2007Blue";
                theme1.SetTheme(this, theme2);
                theme1.SetTheme(groupBox1, theme2);
                theme1.SetTheme(pnSememAnalysis, theme2);
                theme1.SetTheme(panel6, theme2);
                theme1.SetTheme(groupBox2, theme2);
                foreach (Control ctl in pnSememAnalysis.Controls)
                {
                    if (ctl is C1PictureBox) continue;
                    theme1.SetTheme(ctl, theme2);
                }
                foreach (Control ctl in groupBox1.Controls)
                {
                    if (ctl is C1PictureBox) continue;
                    theme1.SetTheme(ctl, theme2);
                }
                foreach (Control ctl in panel6.Controls)
                {
                    if (ctl is C1PictureBox) continue;
                    theme1.SetTheme(ctl, theme2);
                }
                foreach (Control ctl in groupBox2.Controls)
                {
                    if (ctl is C1PictureBox) continue;
                    theme1.SetTheme(ctl, theme2);
                }
            }
            else if (lsperm.status_lab_sperm.Equals("3"))
            {
                theme2 = "Office2010Barbie";
                theme1.SetTheme(this, theme2);
                theme1.SetTheme(panel9, theme2);
                theme1.SetTheme(groupBox5, theme2);
                foreach (Control ctl in panel9.Controls)
                {
                    if (ctl is C1PictureBox) continue;
                    theme1.SetTheme(ctl, theme2);
                }
                foreach (Control ctl in groupBox5.Controls)
                {
                    if (ctl is C1PictureBox) continue;
                    theme1.SetTheme(ctl, theme2);
                }
            }
            else if (lsperm.status_lab_sperm.Equals("4"))
            {
                theme2 = "Office2007Blue";
            }
            theme1.SetTheme(sB, "BeigeOne");
            //theme1.SetTheme(this, theme2);
            //theme1.SetTheme(groupBox1, theme2);
            //theme1.SetTheme(pnSememAnalysis, theme2);
            //theme1.SetTheme(panel6, theme2);
            //theme1.SetTheme(groupBox2, theme2);
            //foreach (Control ctl in pnSememAnalysis.Controls)
            //{
            //    if (ctl is C1PictureBox) continue;
            //    theme1.SetTheme(ctl, theme2);
            //}
            //foreach (Control ctl in groupBox1.Controls)
            //{
            //    if (ctl is C1PictureBox) continue;
            //    theme1.SetTheme(ctl, theme2);
            //}
            //foreach (Control ctl in panel6.Controls)
            //{
            //    if (ctl is C1PictureBox) continue;
            //    theme1.SetTheme(ctl, theme2);
            //}
            //foreach (Control ctl in groupBox2.Controls)
            //{
            //    if (ctl is C1PictureBox) continue;
            //    theme1.SetTheme(ctl, theme2);
            //}
        }
        private void FrmLabSpermAdd_Load(object sender, EventArgs e)
        {
            tC.SelectedTab = tabSpermFreezing;
            sCAnalysis.HeaderHeight = 0;
            sCIui.HeaderHeight = 0;
            sCPesa.HeaderHeight = 0;
            sCFreezing.HeaderHeight = 0;
            tC.ShowTabs = false;
            if (lsperm.status_lab_sperm.Equals("1"))
            {
                tC.SelectedTab = tabSpermFreezing;
            }
            else if (lsperm.status_lab_sperm.Equals("2"))
            {
                tC.SelectedTab = tabSememAna;
            }
            else if (lsperm.status_lab_sperm.Equals("3"))
            {
                tC.SelectedTab = tabSememPESA;
            }
            else if (lsperm.status_lab_sperm.Equals("4"))
            {
                tC.SelectedTab = TabSpermIUI;
            }
            
        }
    }
}
