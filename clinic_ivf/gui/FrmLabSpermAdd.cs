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
        String reqId = "", opuId = "";
        LabRequest lbReq;
        LabSperm lsperm;

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;
        Color color;

        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        String theme2 = "Office2007Blue";

        public FrmLabSpermAdd(IvfControl ic, String reqid, String opuid)
        {
            InitializeComponent();
            this.ic = ic;
            reqId = reqid;
            opuId = opuid;

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

            sB1.Text = "";
            bg = txtHnFeMale.BackColor;
            fc = txtHnFeMale.ForeColor;
            ff = txtHnFeMale.Font;
            ic.ivfDB.dtrOldDB.setCboDoctor(cboDoctor, "");
            ic.ivfDB.fdtDB.setCboSpermAnalysisAppearance(cboAppearance);
            ic.ivfDB.fdtDB.setCboSpermAnalysisAppearance(cboLiquefaction);
            ic.ivfDB.fdtDB.setCboSpermAnalysisAppearance(cboViscosity);

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            lsperm = new LabSperm();
            lbReq = new LabRequest();

            setControl();
            setTheme();
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
                String re = ic.ivfDB.lspermDB.insertLabSperm(lsperm, ic.cStf.staff_id);
                if (long.TryParse(re, out chk))
                {
                    sB1.Text = "Save done";
                }
            }
        }

        private void setControl()
        {
            lsperm = ic.ivfDB.lspermDB.selectByPk1(opuId);
            lbReq = ic.ivfDB.lbReqDB.selectByPk1(lsperm.req_id);

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
            txtMotility4.Value = lsperm.motility_rate_4;
            txtMotility3.Value = lsperm.motility_rate_3;
            txtMotility2.Value = lsperm.motility_rate_2;
            txtMotility1.Value = lsperm.motility_rate_1;
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

        }
        private void setSperm()
        {
            lsperm.sperm_id = txtID.Text;
            lsperm.hn_female = txtHnFeMale.Text;
            lsperm.hn_male = txtHnMale.Text;
            lsperm.name_female = txtNameFeMale.Text;
            lsperm.name_male = txtNameMale.Text;
            lbReq.req_code = txtLabReqCode.Text;
            lsperm.dob_female = txtDobFeMale.Text;
            lsperm.dob_male = txtDobMale.Text;
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
            lsperm.motility_rate_1 = txtMotility1.Text;
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
        }
        private void setTheme()
        {
            theme1.SetTheme(sB, "BeigeOne");
            theme1.SetTheme(this, theme2);
            theme1.SetTheme(groupBox1, theme2);
            theme1.SetTheme(pnSememAnalysis, theme2);
            theme1.SetTheme(panel6, theme2);
            foreach (Control ctl in pnSememAnalysis.Controls)
            {
                theme1.SetTheme(ctl, theme2);
            }
            foreach (Control ctl in groupBox1.Controls)
            {
                theme1.SetTheme(ctl, theme2);
            }
            foreach (Control ctl in panel6.Controls)
            {
                theme1.SetTheme(ctl, theme2);
            }
        }
        private void FrmLabSpermAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
