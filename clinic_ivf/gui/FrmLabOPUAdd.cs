using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1SuperTooltip;
using C1.Win.C1Themes;
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
    public partial class FrmLabOPUAdd : Form
    {
        IvfControl ic;
        String reqId = "", opuId="";
        LabRequest lbReq;
        LabOpu opu;

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;
        int colID = 1, colNum = 2, colDesc = 3, colDesc2=4, colDesc3=5;

        C1FlexGrid grfDay2, grfDay3, grfDay5, grfDay6;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;

        public FrmLabOPUAdd(IvfControl ic, String reqid, String opuid)
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

            sB1.Text = "";
            bg = txtHnFeMale.BackColor;
            fc = txtHnFeMale.ForeColor;
            ff = txtHnFeMale.Font;

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            opu = new LabOpu();
            lbReq = new LabRequest();

            ic.ivfDB.proceDB.setCboLabProce(cboOpuProce, objdb.LabProcedureDB.StatusLab.OPUProcedure);
            ic.ivfDB.dtrOldDB.setCboDoctor(cboDoctor, "");
            ic.ivfDB.stfDB.setCbEmbryologist(cboEmbryoForEtEmbryologist, "");
            ic.ivfDB.stfDB.setCbEmbryologist(cboEmbryologistAppv, "");
            ic.ivfDB.stfDB.setCbEmbryologist(cboEmbryologistReport, "");
            ic.setCboDay(CboEmbryoDay0, "");
            ic.setCboDay(CboEmbryoDay1, "");

            setControl();
            //stt.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.Gold;
            
            btnSave.Click += BtnSave_Click;
            btnSaveMatura.Click += BtnSaveMatura_Click;
            btnSaveFertili.Click += BtnSaveFertili_Click;
            btnSaveSperm.Click += BtnSaveSperm_Click;
            btnSaveEmbryoEt.Click += BtnSaveEmbryoEt_Click;
            btnSaveEmbryoFreezDay0.Click += BtnSaveEmbryoFreezDay0_Click;
            btnSaveEmbryoFreezDay1.Click += BtnSaveEmbryoFreezDay1_Click;

            setFocusColor();
            initGrfDay2();
            initGrfDay3();
            initGrfDay5();
            initGrfDay6();
            setGrfDay2();
            setGrfDay3();
            setGrfDay5();
            setGrfDay6();
        }

        private void BtnSaveEmbryoFreezDay1_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล Embryo for ET ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                ic.cStf.staff_id = "";
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    setOPUEmbryoFreezDay1();
                    String re = ic.ivfDB.opuDB.updateEmbryoFreezDay1(opu, ic.user.staff_id);
                    long chk1 = 0;
                    if (long.TryParse(re, out chk1))
                    {
                        btnSave.Image = Resources.accept_database24;
                    }
                    else
                    {
                        btnSave.Image = Resources.accept_database24;
                    }
                }
            }
        }

        private void BtnSaveEmbryoFreezDay0_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล Embryo for ET ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                ic.cStf.staff_id = "";
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    setOPUEmbryoFreezDay0();
                    String re = ic.ivfDB.opuDB.updateEmbryoFreezDay0(opu, ic.user.staff_id);
                    long chk1 = 0;
                    if (long.TryParse(re, out chk1))
                    {
                        btnSave.Image = Resources.accept_database24;
                    }
                    else
                    {
                        btnSave.Image = Resources.accept_database24;
                    }
                }
            }
        }

        private void BtnSaveEmbryoEt_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล Embryo for ET ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                ic.cStf.staff_id = "";
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    setOPUEmbryeEt();
                    String re = ic.ivfDB.opuDB.updateEmbryoEt(opu, ic.user.staff_id);
                    long chk1 = 0;
                    if (long.TryParse(re, out chk1))
                    {
                        btnSave.Image = Resources.accept_database24;
                    }
                    else
                    {
                        btnSave.Image = Resources.accept_database24;
                    }
                }
            }
        }

        private void BtnSaveSperm_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล Sperm Preparation ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                ic.cStf.staff_id = "";
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    setOPUSperm();
                    String re = ic.ivfDB.opuDB.updateSperm(opu, ic.user.staff_id);
                    long chk1 = 0;
                    if (long.TryParse(re, out chk1))
                    {
                        btnSave.Image = Resources.accept_database24;
                    }
                    else
                    {
                        btnSave.Image = Resources.accept_database24;
                    }
                }
            }
        }

        private void BtnSaveFertili_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล Fertilization ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                ic.cStf.staff_id = "";
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    setOPUFertilization();
                    String re = ic.ivfDB.opuDB.updateFertili(opu, ic.user.staff_id);
                    long chk1 = 0;
                    if (long.TryParse(re, out chk1))
                    {
                        btnSave.Image = Resources.accept_database24;
                    }
                    else
                    {
                        btnSave.Image = Resources.accept_database24;
                    }
                }
            }
        }

        private void BtnSaveMatura_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล Maturation ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                ic.cStf.staff_id = "";
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    setOPUMatura();
                    String re = ic.ivfDB.opuDB.updateMatura(opu, ic.user.staff_id);
                    long chk1 = 0;
                    if (long.TryParse(re, out chk1))
                    {
                        btnSave.Image = Resources.accept_database24;
                    }
                    else
                    {
                        btnSave.Image = Resources.accept_database24;
                    }
                }
            }
        }

        private void setFocusColor()
        {
            this.txtHnFeMale.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtHnFeMale.Enter += new System.EventHandler(this.textBox_Enter);

            //this.txtPosiNameT.Leave += new System.EventHandler(this.textBox_Leave);
            //this.txtPosiNameT.Enter += new System.EventHandler(this.textBox_Enter);

            //this.txtRemark.Leave += new System.EventHandler(this.textBox_Leave);
            //this.txtRemark.Enter += new System.EventHandler(this.textBox_Enter);
        }
        private void textBox_Leave(object sender, EventArgs e)
        {
            C1TextBox a = (C1TextBox)sender;
            a.BackColor = bg;
            a.ForeColor = fc;
            a.Font = new Font(ff, FontStyle.Regular);
        }
        private void textBox_Enter(object sender, EventArgs e)
        {
            C1TextBox a = (C1TextBox)sender;
            a.BackColor = ic.cTxtFocus;
            a.Font = new Font(ff, FontStyle.Bold);
        }
        private void setControl()
        {
            try
            {
                if (!reqId.Equals(""))
                {
                    lbReq = ic.ivfDB.lbReqDB.selectByPk1(reqId);

                    txtHnFeMale.Value = lbReq.hn_female;
                    txtHnMale.Value = lbReq.hn_male;
                    txtNameFeMale.Value = lbReq.name_female;
                    txtNameMale.Value = lbReq.name_male;
                    txtLabReqCode.Value = lbReq.req_code;
                }
                else
                {
                    opu = ic.ivfDB.opuDB.selectByPk1(opuId);
                    lbReq = ic.ivfDB.lbReqDB.selectByPk1(opu.req_id);

                    txtID.Value = opu.opu_id;
                    txtHnFeMale.Value = opu.hn_female;
                    txtHnMale.Value = opu.hn_male;
                    txtNameFeMale.Value = opu.name_female;
                    txtNameMale.Value = opu.name_male;
                    txtLabReqCode.Value = lbReq.req_code;
                    txtDobFeMale.Value = opu.dob_female;
                    txtDobMale.Value = opu.dob_male;
                    ic.setC1Combo(cboDoctor, opu.doctor_id);
                    txtOpuDate.Value = opu.opu_date;
                    ic.setC1Combo(cboOpuProce, opu.proce_id);
                    txtOpuCode.Value = opu.opu_code;

                    txtMaturaNoofOpu.Value = opu.matura_no_of_opu;
                    txtMaturaDate.Value = opu.matura_date;
                    txtMaturaMii.Value = opu.matura_m_ii;
                    txtMaturaMi.Value = opu.matura_m_i;
                    txtMaturaGv.Value = opu.matura_gv;
                    txtMaturaPostMat.Value = opu.matura_post_mat;
                    txtMaturaAbnor.Value = opu.matura_abmormal;
                    txtMaturaDead.Value = opu.matura_dead;

                    txtFertiliDate.Value = opu.fertili_date;
                    txtFertili2Pn.Value = opu.fertili_2_pn;
                    txtFertili1Pn.Value = opu.fertili_1_pn;
                    txtFertili3Pn.Value = opu.fertili_3_pn;
                    txtFertili4Pn.Value = opu.fertili_4_pn;
                    txtFertiliNoPn.Value = opu.fertili_no_pn;
                    txtFertiliDead.Value = opu.fertili_dead;

                    txtSpermDate.Value = opu.sperm_date;
                    txtSpermVol.Value = opu.sperm_volume;
                    txtSpermCnt.Value = opu.sperm_count;
                    txtSpermTotalCnt.Value = opu.sperm_count_total;
                    txtSpermMoti.Value = opu.sperm_motile;
                    txtSpermMotiTotal.Value = opu.sperm_motile_total;
                    txtSpermMotility.Value = opu.sperm_motility;
                    chkSpermFresh.Value = opu.sperm_fresh_sperm.Equals("1") ? true : false;
                    chkSpermFrozen.Value = opu.sperm_frozen_sperm.Equals("1") ? true : false;
                    txtEmbryoForEtNO.Value = opu.embryo_for_et_no_of_et;
                    txtEmbryoForEtDay.Value = opu.embryo_for_et_day;
                    txtEmbryoForEtDate.Value = opu.embryo_for_et_date;
                    txtEmbryoForEtAsseted.Value = opu.embryo_for_et_assisted;
                    txtEmbryoForEtVolume.Value = opu.embryo_for_et_volume;
                    txtEmbryoForEtCatheter.Value = opu.embryo_for_et_catheter;
                    txtEmbryoForEtDoctor.Value = opu.embryo_for_et_doctor;
                    txtEmbryoForEtNumTran.Value = opu.embryo_for_et_number_of_transfer;
                    txtEmbryoForEtNumFreeze.Value = opu.embryo_for_et_number_of_freeze;
                    txtEmbryoForEtNumDiscard.Value = opu.embryo_for_et_number_of_discard;
                    //cboEmbryoForEtEmbryologist.Value = opu.embryo_for_et_embryologist_id;
                    //cboEmbryologistReport.Value = opu.embryologist_report_id;
                    //cboEmbryologistAppv.Value = opu.embryologist_approve_id;
                    ic.setC1Combo(cboEmbryologistAppv, opu.embryologist_approve_id);
                    ic.setC1Combo(cboEmbryologistReport, opu.embryologist_report_id);
                    ic.setC1Combo(cboEmbryoForEtEmbryologist, opu.embryo_for_et_embryologist_id);
                    ic.setC1Combo(CboEmbryoDay0, opu.embryo_freez_day_0);
                    ic.setC1Combo(CboEmbryoDay1, opu.embryo_freez_day_1);
                    txtEmbryoFreezDate0.Value = opu.embryo_freez_date_0;
                    txtEmbryoFreezDate1.Value = opu.embryo_freez_date_1;
                    txtEmbryoFreezStage0.Value = opu.embryo_freez_stage_0;
                    txtEmbryoFreezStage1.Value = opu.embryo_freez_stage_1;
                    txtEmbryoFreezNoOg0.Value = opu.embryo_freez_no_og_0;
                    txtEmbryoFreezNoOg1.Value = opu.embryo_freez_no_og_1;
                    txtEmbryoFreezNoStraw0.Value = opu.embryo_freez_no_of_straw_0;
                    txtEmbryoFreezNoStraw1.Value = opu.embryo_freez_no_of_straw_1;
                    txtEmbryoFreezPosi0.Value = opu.embryo_freez_position_0;
                    txtEmbryoFreezPosi1.Value = opu.embryo_freez_position_1;
                    txtEmbryoFreezMethod0.Value = opu.embryo_freez_mothod_0;
                    txtEmbryoFreezMethod1.Value = opu.embryo_freez_mothod_1;
                    txtEmbryoFreezMedia0.Value = opu.embryo_freez_freeze_media_0;
                    txtEmbryoFreezMedia1.Value = opu.embryo_freez_freeze_media_1;

                    txtRemark.Value = opu.remark;
                    //CboEmbryoDay.Text = opu.emb
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(""+ex.Message, "");
            }
            
        }
        private void setOPU()
        {
            opu.opu_id = txtID.Text;
            opu.hn_female = txtHnFeMale.Text;
            opu.hn_male = txtHnMale.Text;
            opu.name_female = txtNameFeMale.Text;
            opu.name_male = txtNameMale.Text;
            //lbReq.req_code = txtLabReqCode.Text;
            opu.dob_female = txtDobFeMale.Text;
            opu.dob_male = txtDobMale.Text;
            ComboBoxItem item = new ComboBoxItem();
            if (cboDoctor.SelectedItem != null)
            {
                item = (ComboBoxItem)cboDoctor.SelectedItem;
                opu.doctor_id = item.Value;
            }
            else
            {
                opu.doctor_id = "0";
            }
            opu.opu_date = txtOpuDate.Text;
            if (cboDoctor.SelectedItem != null)
            {
                item = (ComboBoxItem)cboOpuProce.SelectedItem;
                opu.proce_id = item.Value;
            }
            else
            {
                opu.proce_id = "0";
            }
            opu.opu_code = txtOpuCode.Text;
            opu.remark = txtRemark.Text;
        }
        private void setOPUMatura()
        {
            opu.opu_id = txtID.Text;
            opu.matura_no_of_opu = txtMaturaNoofOpu.Text;
            opu.matura_date = txtMaturaDate.Text;
            opu.matura_m_ii = txtMaturaMii.Text;
            opu.matura_m_i = txtMaturaMi.Text;
            opu.matura_gv = txtMaturaGv.Text;
            opu.matura_post_mat = txtMaturaPostMat.Text;
            opu.matura_abmormal = txtMaturaAbnor.Text;            
            opu.matura_dead = txtMaturaDead.Text;            
        }
        private void setOPUFertilization()
        {
            opu.opu_id = txtID.Text;
            opu.fertili_date = txtFertiliDate.Text;
            opu.fertili_2_pn = txtFertili2Pn.Text;
            opu.fertili_1_pn = txtFertili1Pn.Text;
            opu.fertili_3_pn = txtFertili3Pn.Text;
            opu.fertili_4_pn = txtFertili4Pn.Text;
            opu.fertili_no_pn = txtFertiliNoPn.Text;
            opu.fertili_dead = txtFertiliDead.Text;
            //opu.matura_dead = txtMaturaDead.Text;
        }
        private void setOPUSperm()
        {
            opu.opu_id = txtID.Text;
            opu.sperm_date = txtSpermDate.Text;
            opu.sperm_volume = txtSpermVol.Text;
            opu.sperm_count = txtSpermCnt.Text;
            opu.sperm_count_total = txtSpermTotalCnt.Text;
            opu.sperm_motile = txtSpermMoti.Text;
            opu.sperm_motile_total = txtSpermMotiTotal.Text;
            opu.sperm_motility = txtSpermMotility.Text;
            opu.sperm_fresh_sperm = chkSpermFresh.Checked ? "1" : "0";
            opu.sperm_frozen_sperm = chkSpermFrozen.Checked ? "1" : "0";
        }
        private void setOPUEmbryeEt()
        {
            opu.opu_id = txtID.Text;
            opu.embryo_for_et_no_of_et = txtEmbryoForEtNO.Text;
            opu.embryo_for_et_day = txtEmbryoForEtDay.Text;
            opu.embryo_for_et_date = txtEmbryoForEtDate.Text;
            opu.embryo_for_et_assisted = txtEmbryoForEtAsseted.Text;
            opu.embryo_for_et_volume = txtEmbryoForEtVolume.Text;
            opu.embryo_for_et_catheter = txtEmbryoForEtCatheter.Text;
            opu.embryo_for_et_doctor = txtEmbryoForEtDoctor.Text;
            ComboBoxItem item = new ComboBoxItem();
            if (cboEmbryoForEtEmbryologist.SelectedItem != null)
            {
                item = (ComboBoxItem)cboEmbryoForEtEmbryologist.SelectedItem;
                opu.embryo_for_et_embryologist_id = item.Value;
            }
            else
            {
                opu.embryo_for_et_embryologist_id = "0";
            }
            if (cboEmbryologistReport.SelectedItem != null)
            {
                item = (ComboBoxItem)cboEmbryologistReport.SelectedItem;
                opu.embryologist_report_id = item.Value;
            }
            else
            {
                opu.embryologist_report_id = "0";
            }
            if (cboEmbryologistAppv.SelectedItem != null)
            {
                item = (ComboBoxItem)cboEmbryologistAppv.SelectedItem;
                opu.embryologist_approve_id = item.Value;
            }
            else
            {
                opu.embryologist_approve_id = "0";
            }

            opu.embryo_for_et_number_of_transfer = txtEmbryoForEtNumTran.Text;
            opu.embryo_for_et_number_of_freeze = txtEmbryoForEtNumFreeze.Text;
            opu.embryo_for_et_number_of_discard = txtEmbryoForEtNumDiscard.Text;
        }
        private void setOPUEmbryoFreezDay1()
        {
            opu.opu_id = txtID.Text;
            ComboBoxItem item = new ComboBoxItem();
            if (CboEmbryoDay1.SelectedItem != null)
            {
                item = (ComboBoxItem)CboEmbryoDay1.SelectedItem;
                opu.embryo_freez_day_1 = item.Value;
            }
            else
            {
                opu.embryo_freez_day_1 = "0";
            }

            opu.embryo_freez_date_1 = txtEmbryoFreezDate1.Text;
            opu.embryo_freez_stage_1 = txtEmbryoFreezStage1.Text;
            opu.embryo_freez_no_og_1 = txtEmbryoFreezNoOg1.Text;
            opu.embryo_freez_no_of_straw_1 = txtEmbryoFreezNoStraw1.Text;
            opu.embryo_freez_position_1 = txtEmbryoFreezPosi1.Text;
            opu.embryo_freez_mothod_1 = txtEmbryoFreezMethod1.Text;
            opu.embryo_freez_freeze_media_1 = txtEmbryoFreezMedia1.Text;
            //opu.matura_dead = txtMaturaDead.Text;
        }
        private void setOPUEmbryoFreezDay0()
        {
            opu.opu_id = txtID.Text;
            ComboBoxItem item = new ComboBoxItem();
            if (CboEmbryoDay0.SelectedItem != null)
            {
                item = (ComboBoxItem)CboEmbryoDay0.SelectedItem;
                opu.embryo_freez_day_0 = item.Value;
            }
            else
            {
                opu.embryo_freez_day_0 = "0";
            }

            opu.embryo_freez_date_0 = txtEmbryoFreezDate0.Text;
            opu.embryo_freez_stage_0 = txtEmbryoFreezStage0.Text;
            opu.embryo_freez_no_og_0 = txtEmbryoFreezNoOg0.Text;
            opu.embryo_freez_no_of_straw_0 = txtEmbryoFreezNoStraw0.Text;
            opu.embryo_freez_position_0 = txtEmbryoFreezPosi0.Text;
            opu.embryo_freez_mothod_0 = txtEmbryoFreezMethod0.Text;
            opu.embryo_freez_freeze_media_0 = txtEmbryoFreezMedia0.Text;
            //opu.matura_dead = txtMaturaDead.Text;
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                ic.cStf.staff_id = "";
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    setOPU();
                    String re = ic.ivfDB.opuDB.update(opu, ic.user.staff_id);
                    long chk1 = 0;
                    if (long.TryParse(re, out chk1))
                    {
                        btnSave.Image = Resources.accept_database24;
                    }
                    else
                    {
                        btnSave.Image = Resources.accept_database24;
                    }
                }
                
                //int chk = 0;
                //if (int.TryParse(re, out chk))
                //{
                //    btnSave.Image = Resources.accept_database24;
                //}
                //else
                //{
                //    btnSave.Image = Resources.accept_database24;
                //}
                //setGrfPosi();
                //setGrdView();
                //this.Dispose();
            }
        }

        private void initGrfDay2()
        {
            grfDay2 = new C1FlexGrid();
            grfDay2.Font = fEdit;
            grfDay2.Dock = System.Windows.Forms.DockStyle.Fill;
            grfDay2.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            //grfExpn.AfterRowColChange += GrfExpn_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfDay2.ContextMenu = menuGw;
            gbDay2.Controls.Add(grfDay2);

            theme1.SetTheme(grfDay2, "Office2010Blue");
        }
        private void initGrfDay6()
        {
            grfDay6 = new C1FlexGrid();
            grfDay6.Font = fEdit;
            grfDay6.Dock = System.Windows.Forms.DockStyle.Fill;
            grfDay6.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            //grfExpn.AfterRowColChange += GrfExpn_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfDay6.ContextMenu = menuGw;
            gbDay6.Controls.Add(grfDay6);

            theme1.SetTheme(grfDay6, "Office2010Blue");
        }
        private void initGrfDay3()
        {
            grfDay3 = new C1FlexGrid();
            grfDay3.Font = fEdit;
            grfDay3.Dock = System.Windows.Forms.DockStyle.Fill;
            grfDay3.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            //grfExpn.AfterRowColChange += GrfExpn_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfDay3.ContextMenu = menuGw;
            gbDay3.Controls.Add(grfDay3);

            theme1.SetTheme(grfDay3, "Office2010Silver");
        }
        private void initGrfDay5()
        {
            grfDay5 = new C1FlexGrid();
            grfDay5.Font = fEdit;
            grfDay5.Dock = System.Windows.Forms.DockStyle.Fill;
            grfDay5.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            //grfExpn.AfterRowColChange += GrfExpn_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfDay5.ContextMenu = menuGw;
            gbDay5.Controls.Add(grfDay5);

            theme1.SetTheme(grfDay5, "Office2010Red");
            //theme1.SetTheme(grfDay6, "Office2016DarkGray");
        }
        private void setGrfDay2()
        {
            //grfDept.Rows.Count = 7;
            grfDay2.Clear();
            DataTable dt = new DataTable();

            //grfExpn.DataSource = xC.xtDB.expndDB.selectAll1(cboYear.Text);
            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfDay2.Rows.Count = 41;
            grfDay2.Cols.Count = 64;
            C1TextBox txt = new C1TextBox();
            C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfDay2.Cols[colID].Editor = txt;
            grfDay2.Cols[colNum].Editor = txt;
            grfDay2.Cols[colDesc].Editor = txt;

            grfDay2.Cols[colNum].Width = 40;
            grfDay2.Cols[colDesc].Width = 150;

            grfDay2.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfDay2.Cols[colNum].Caption = "no";
            grfDay2.Cols[colDesc].Caption = "desc";
            grfDay2.Cols[colDesc2].Caption = "desc2";
            grfDay2.Cols[colDesc3].Caption = "desc3";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            grfDay2.Cols[colID].Visible = false;
            for (int i = 1; i <= 40; i++)
            {
                grfDay2[i, 0] = i;
            }
            grfDay2.Cols[colNum].Visible = false;
        }
        private void setGrfDay3()
        {
            //grfDept.Rows.Count = 7;
            grfDay3.Clear();
            DataTable dt = new DataTable();

            //grfExpn.DataSource = xC.xtDB.expndDB.selectAll1(cboYear.Text);
            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfDay3.Rows.Count = 41;
            grfDay3.Cols.Count = 4;
            C1TextBox txt = new C1TextBox();
            //txt.dat

            grfDay3.Cols[colID].Editor = txt;
            grfDay3.Cols[colNum].Editor = txt;
            grfDay3.Cols[colDesc].Editor = txt;

            grfDay3.Cols[colNum].Width = 40;
            grfDay3.Cols[colDesc].Width = 150;

            grfDay3.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfDay3.Cols[colNum].Caption = "no";
            grfDay3.Cols[colDesc].Caption = "desc";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            grfDay3.Cols[colID].Visible = false;
            for (int i = 1; i <= 40; i++)
            {
                grfDay3[i, 0] = i;
            }
            grfDay3.Cols[colNum].Visible = false;
        }
        private void setGrfDay5()
        {
            //grfDept.Rows.Count = 7;
            grfDay5.Clear();
            DataTable dt = new DataTable();

            //grfExpn.DataSource = xC.xtDB.expndDB.selectAll1(cboYear.Text);
            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfDay5.Rows.Count = 41;
            grfDay5.Cols.Count = 4;
            C1TextBox txt = new C1TextBox();
            //txt.dat

            grfDay5.Cols[colID].Editor = txt;
            grfDay5.Cols[colNum].Editor = txt;
            grfDay5.Cols[colDesc].Editor = txt;

            grfDay5.Cols[colNum].Width = 40;
            grfDay5.Cols[colDesc].Width = 150;

            grfDay5.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfDay5.Cols[colNum].Caption = "no";
            grfDay5.Cols[colDesc].Caption = "desc";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            grfDay5.Cols[colID].Visible = false;
            for (int i = 1; i <= 40; i++)
            {
                grfDay5[i, 0] = i;
            }
            grfDay5.Cols[colNum].Visible = false;
        }
        private void setGrfDay6()
        {
            //grfDept.Rows.Count = 7;
            grfDay6.Clear();
            DataTable dt = new DataTable();

            //grfExpn.DataSource = xC.xtDB.expndDB.selectAll1(cboYear.Text);
            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfDay6.Rows.Count = 41;
            grfDay6.Cols.Count = 4;
            C1TextBox txt = new C1TextBox();
            //txt.dat

            grfDay6.Cols[colID].Editor = txt;
            grfDay6.Cols[colNum].Editor = txt;
            grfDay6.Cols[colDesc].Editor = txt;

            grfDay6.Cols[colNum].Width = 40;
            grfDay6.Cols[colDesc].Width = 150;

            grfDay6.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfDay6.Cols[colNum].Caption = "no";
            grfDay6.Cols[colDesc].Caption = "desc";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            grfDay6.Cols[colID].Visible = false;
            for(int i = 1; i <= 40; i++)
            {
                grfDay6[i, 0] = i;
            }
            grfDay6.Cols[colNum].Visible = false;
        }
        private void FrmLabOPUAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
