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
        String lformaId = "", pttid = "", vsid = "", vsidOld = "";
        LabFormA lFormA;
        LabOpu opu;

        C1SuperTooltip stt;
        C1SuperErrorProvider sep;

        public FrmLabFormDay1(IvfControl ic, String lformaId, String pttid, String vsid, String vsidOld)
        {
            InitializeComponent();
            this.ic = ic;
            this.pttid = pttid;
            this.vsid = vsid;
            this.vsidOld = vsidOld;
            this.lformaId = lformaId;
            initConfig();
        }
        private void initConfig()
        {
            lFormA = new LabFormA();
            opu = new LabOpu();

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            ic.ivfDB.dtrOldDB.setCboDoctor(cboDoctor, "");
            ic.setCboDay(cboEmbryoFreezingDay, "");
            setControl();

            chkBiopsy.CheckedChanged += ChkBiopsy_CheckedChanged;
            chkEmbryoFreezingDay.CheckedChanged += ChkEmbryoFreezingDay_CheckedChanged;
            chkBlastocyst.CheckedChanged += ChkBlastocyst_CheckedChanged;
            chkEmbryoTransferFresh.CheckedChanged += ChkEmbryoTransferFresh_CheckedChanged;
            btnPrint.Click += BtnPrint_Click;
            chkPgsMin.CheckedChanged += ChkPgsMin_CheckedChanged;
            chkNgs.CheckedChanged += ChkNgs_CheckedChanged;

            ChkBiopsy_CheckedChanged(null, null);
            ChkEmbryoFreezingDay_CheckedChanged(null, null);
            ChkBlastocyst_CheckedChanged(null, null);
            ChkEmbryoTransferFresh_CheckedChanged(null, null);
            ChkPgsMin_CheckedChanged(null, null);
            ChkNgs_CheckedChanged(null, null);

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

            dt.NewRow();
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
            //dt.Columns.Add("", typeof(String));
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
            dt.Rows[0]["remark"] = txtRemark.Text;
            dt.Rows[0]["embryo_freezing_embryo_max"] = txtEmbryoFreezingEmbryoMax.Text;
            //dt.Rows[0][""]
            FrmReport frm = new FrmReport(ic);
            frm.setLabFormDay1Report(dt);
            frm.ShowDialog(this);
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
                LabRequest req = new LabRequest();
                req = ic.ivfDB.lbReqDB.selectByPk1(lFormA.req_id_opu);
                opu = ic.ivfDB.opuDB.selectByReqID(req.req_id);
                setControl1();
            }

        }
        private void setControl1()
        {
            txtID.Value = lFormA.form_a_id;
            //txtLabFormACode.Value = lFormA.form_a_code;
            txtPttId.Value = lFormA.t_patient_id;
            txtVsId.Value = lFormA.t_visit_id;
            txtVnOld.Value = lFormA.vn_old;
            txtHnOld.Value = lFormA.hn_old;
            txtHnFeMale.Value = lFormA.hn_female;
            txtNameFeMale.Value = lFormA.name_female;
            txtNameMale.Value = lFormA.name_male;
            txtHnMale.Value = lFormA.hn_male;
            txtDobFeMale.Value = lFormA.dob_female;
            txtDobMale.Value = lFormA.dob_male;
            ic.setC1Combo(cboDoctor, lFormA.doctor_id);

            txtFertili2Pn.Value = opu.fertili_2_pn;
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
