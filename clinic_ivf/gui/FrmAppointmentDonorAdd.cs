﻿using C1.Win.C1FlexGrid;
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.gui
{
    public partial class FrmAppointmentDonorAdd : Form
    {
        IvfControl ic;
        String pApmId = "", pttId = "", vsId = "";

        C1FlexGrid grfpApmAll, grfpApmVisit, grfpApmDayAll;
        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;
        PatientAppointment pApm;
        Patient ptt;
        Visit vs;

        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        int colId = 1, colAppointment = 4, colDate = 2, colTime = 3, colDoctor = 5, colSp = 6, colNotice=7, colE2=8, colLh=9, colEndo=10, colPrl=10, colFsh=11, colRt=12, colLt=13;
        Image imgCorr, imgTran;

        public FrmAppointmentDonorAdd(IvfControl ic, String papmId, String pttid, String vsid)
        {
            InitializeComponent();
            this.ic = ic;
            pApmId = papmId;
            pttId = pttid;
            vsId = vsid;
            InitConfig();
        }
        private void InitConfig()
        {
            pApm = new PatientAppointment();
            ptt = new Patient();
            vs = new Visit();
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

            cboTimepApm = ic.setCboApmTime(cboTimepApm);
            txtDatepApm.Value = System.DateTime.Now.Year.ToString() + "-" + System.DateTime.Now.ToString("MM-dd");
            btnSave.Click += BtnSave_Click;
            txtDatepApm.ValueChanged += TxtDatepApm_ValueChanged;
            btnVoid.Click += BtnVoid_Click;

            initGrfpApmAll();
            initGrfpApmVisit();
            initGrfpApmDayAll();
            setGrfpApmAll();
            setGrfpApmVisit();
            setGrfpApmDay();
            setControl();
        }

        private void BtnVoid_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (btnVoid.Text.Equals("Confirm"))
            {
                stt.Hide();
                btnVoid.Text = "Void";
                //setPatient();
                //String re = ic.ivfDB.pttDB.insertPatient(ptt, txtStfConfirmID.Text);
                if (ic.iniC.statusAppDonor.Equals("1"))
                {
                    String re = ic.ivfDB.pApmDB.VoidPatientAppointment(txtID.Text, txtStfConfirmID.Text);
                    int chk = 0;
                    //Patient ptt1 = new Patient();
                    if (re.Equals("1")) // ตอน update
                    {
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
            else
            {
                ic.cStf.staff_id = "";
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    txtUserReq.Value = ic.cStf.staff_fname_t + " " + ic.cStf.staff_lname_t;
                    txtStfConfirmID.Value = ic.cStf.staff_id;
                    btnVoid.Text = "Confirm";
                    //btnSave.Image = Resources.Add_ticket_24;
                    stt.Show("<p><b>สวัสดี</b></p>คุณ " + ic.cStf.staff_fname_t + " " + ic.cStf.staff_lname_t + "<br> กรุณายินยันการ confirm อีกครั้ง", btnSave);
                    btnVoid.Focus();
                }
                else
                {
                    btnVoid.Text = "Void";
                    //btnSave.Image = Resources.download_database24;
                }
            }
        }

        private void TxtDatepApm_ValueChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setGrfpApmDay();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (btnSave.Text.Equals("Confirm"))
            {
                stt.Hide();
                String re = "";
                setPatientAppointment();
                re = ic.ivfDB.pApmDB.insertPatientAppointment(pApm, txtStfConfirmID.Text);
                                
                long chk = 0;
                if (long.TryParse(re, out chk))
                {
                    //if (!ic.iniC.statusAppDonor.Equals("1"))
                    //{
                    //String re1 = ic.ivfDB.pttOldDB.insertPatientOld(ptt, txtStfConfirmID.Text);
                    //if (int.TryParse(re1, out chk))
                    //{
                    //if (txtID.Text.Equals(""))
                    //{
                    //    //PatientOld pttOld = new PatientOld();
                    //    //pttOld = ic.ivfDB.pttOldDB.selectByPk1(re1);
                    //    String re2 = ic.ivfDB.pttDB.updatePID(re, re1);
                    //    if (int.TryParse(re2, out chk))
                    //    {
                    re = ic.ivfDB.vsDB.updateCloseStatusNurse(txtVsId.Text);
                    txtID.Value = re;
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
                ic.cStf.staff_id = "";
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
                }
                else
                {
                    btnSave.Text = "Save";
                    btnSave.Image = Resources.download_database24;
                }
            }
        }

        private void setControl()
        {
            ptt = ic.ivfDB.pttDB.selectByPk1(pttId);
            vs = ic.ivfDB.vsDB.selectByPk1(vsId);
            pApm = ic.ivfDB.pApmDB.selectByPk1(pApmId);
            txtPttId.Value = ptt.t_patient_id;
            txtVsId.Value = vs.t_visit_id;
            txtHn.Value = ptt.patient_hn;
            txtName.Value = ptt.Name;
            txtRemark.Value = ptt.remark;

            txtDatepApm.Value = pApm.patient_appointment_date;
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
            txtRemark.Value = pApm.remark;
            ic.setC1Combo(cboDoctor, pApm.patient_appointment_doctor);
            txtID.Value = pApm.t_patient_appointment_id;
        }
        private void initGrfpApmAll()
        {
            grfpApmAll = new C1FlexGrid();
            grfpApmAll.Font = fEdit;
            grfpApmAll.Dock = System.Windows.Forms.DockStyle.Fill;
            grfpApmAll.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);
            
            //grfpApmAll.ContextMenu = menuGw;
            panel1.Controls.Add(grfpApmAll);

            theme1.SetTheme(grfpApmAll, "Office2016Colorful");

        }
        private void initGrfpApmVisit()
        {
            grfpApmVisit = new C1FlexGrid();
            grfpApmVisit.Font = fEdit;
            grfpApmVisit.Dock = System.Windows.Forms.DockStyle.Fill;
            grfpApmVisit.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            //grfpApmAll.ContextMenu = menuGw;
            pnVisit.Controls.Add(grfpApmVisit);

            theme1.SetTheme(grfpApmVisit, "Office2016Colorful");

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
            
            dt = ic.ivfDB.pApmDB.selectByPtt(pttId);
            
            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfpApmAll.Rows.Count =  1;
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

            //ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&ออก Visit", new EventHandler(ContextMenu_edit));
            //grfpApmAll.ContextMenu = menuGw;

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
            grfpApmVisit.Clear();
            DataTable dt = new DataTable();

            dt = ic.ivfDB.pApmDB.selectByVisitId(vsId);

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfpApmVisit.Rows.Count = 1;
            grfpApmVisit.Cols.Count = 14;
            C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfpApmVisit.Cols[colNotice].Editor = txt;
            grfpApmVisit.Cols[colAppointment].Editor = txt;
            grfpApmVisit.Cols[colDoctor].Editor = txt;
            Column colE21 = grfpApmVisit.Cols[colE2];
            colE21.DataType = typeof(Image);
            Column colLh1 = grfpApmVisit.Cols[colLh];
            colLh1.DataType = typeof(Image);
            Column colEndo1 = grfpApmVisit.Cols[colEndo];
            colEndo1.DataType = typeof(Image);
            Column colPrl1 = grfpApmVisit.Cols[colPrl];
            colPrl1.DataType = typeof(Image);
            Column colFsh1 = grfpApmVisit.Cols[colFsh];
            colFsh1.DataType = typeof(Image);
            Column colRt1 = grfpApmVisit.Cols[colRt];
            colRt1.DataType = typeof(Image);
            Column colLt1 = grfpApmVisit.Cols[colLt];
            colLt1.DataType = typeof(Image);

            grfpApmVisit.Cols[colDate].Width = 100;
            grfpApmVisit.Cols[colTime].Width = 80;
            grfpApmVisit.Cols[colAppointment].Width = 120;
            grfpApmVisit.Cols[colDoctor].Width = 100;
            grfpApmVisit.Cols[colSp].Width = 80;
            grfpApmVisit.Cols[colNotice].Width = 200;
            grfpApmVisit.Cols[colE2].Width = 50;
            grfpApmVisit.Cols[colLh].Width = 50;
            grfpApmVisit.Cols[colEndo].Width = 50;
            grfpApmVisit.Cols[colPrl].Width = 50;
            grfpApmVisit.Cols[colFsh].Width = 50;
            grfpApmVisit.Cols[colRt].Width = 50;
            grfpApmVisit.Cols[colLt].Width = 50;

            grfpApmVisit.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfpApmVisit.Cols[colDate].Caption = "Date";
            grfpApmVisit.Cols[colTime].Caption = "time";
            grfpApmVisit.Cols[colAppointment].Caption = "นัด";
            grfpApmVisit.Cols[colDoctor].Caption = "Doctor";
            grfpApmVisit.Cols[colSp].Caption = "จุดบริการ";
            grfpApmVisit.Cols[colNotice].Caption = "แจ้ง";
            grfpApmVisit.Cols[colE2].Caption = "E2";
            grfpApmVisit.Cols[colLh].Caption = "LH";
            grfpApmVisit.Cols[colEndo].Caption = "Endo";
            grfpApmVisit.Cols[colPrl].Caption = "PRL";
            grfpApmVisit.Cols[colFsh].Caption = "FSH";
            grfpApmVisit.Cols[colRt].Caption = "Rt";
            grfpApmVisit.Cols[colLt].Caption = "Lt";

            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("แก้ไข Appointment", new EventHandler(ContextMenu_edit));
            grfpApmVisit.ContextMenu = menuGw;

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                Row row1 = grfpApmVisit.Rows.Add();
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
            grfpApmVisit.Cols[colE2].AllowEditing = false;
            grfpApmVisit.Cols[colLh].AllowEditing = false;
            grfpApmVisit.Cols[colEndo].AllowEditing = false;
            grfpApmVisit.Cols[colPrl].AllowEditing = false;
            grfpApmVisit.Cols[colFsh].AllowEditing = false;
            grfpApmVisit.Cols[colRt].AllowEditing = false;
            grfpApmVisit.Cols[colLt].AllowEditing = false;
            grfpApmVisit.Cols[colId].Visible = false;
            theme1.SetTheme(grfpApmVisit, ic.theme);

        }
        private void ContextMenu_edit(object sender, System.EventArgs e)
        {
            String chk = "", name = "", id = "";
            id = grfpApmVisit[grfpApmVisit.Row, colId] != null ? grfpApmVisit[grfpApmVisit.Row, colId].ToString() : "";
            pApmId = id;
            setControl();
            //chk = grfPtt[grfPtt.Row, colPttHn] != null ? grfPtt[grfPtt.Row, colPttHn].ToString() : "";
            //name = grfPtt[grfPtt.Row, colVsPttName] != null ? grfPtt[grfPtt.Row, colVsPttName].ToString() : "";
            //if (MessageBox.Show("ต้องการ แก้ไข Patient  \n  hn number " + chk + " \n name " + name, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            //grfReq.Rows.Remove(grfReq.Row);
            //openPatientAdd(id, name);
            //}
        }
        private void setGrfpApmDay()
        {
            //grfDept.Rows.Count = 7;
            grfpApmDayAll.Clear();
            DataTable dt = new DataTable();

            dt = ic.ivfDB.pApmDB.selectByDay(ic.datetoDB(txtDatepApm.Text));

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
        private void setPatientAppointment()
        {
            pApm.t_patient_appointment_id = txtID.Text;
            pApm.t_patient_id = txtPttId.Text;
            pApm.patient_appoint_date_time = System.DateTime.Now.Year.ToString() + "-" + System.DateTime.Now.ToString("MM-dd");
            pApm.patient_appointment_date = ic.datetoDB(txtDatepApm.Text);
            pApm.patient_appointment_time = cboTimepApm.Text;
            pApm.patient_appointment = txtAppointment.Text;
            pApm.patient_appointment_doctor = cboDoctor.SelectedItem == null ? "" : ((ComboBoxItem)cboDoctor.SelectedItem).Value;
            pApm.patient_appointment_servicepoint = cboBsp.SelectedItem == null ? "" : ((ComboBoxItem)cboBsp.SelectedItem).Value;
            pApm.patient_appointment_notice = txtRemark.Text;
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
            pApm.endo = chkEndo.Checked ? "1" : "0";
            pApm.prl = chkPrl.Checked ? "1" : "0";
            pApm.lh = chkLh.Checked ? "1" : "0";
            pApm.rt_ovary = chkRt.Checked ? "1" : "0";
            pApm.lt_ovary = chkLt.Checked ? "1" : "0";
            pApm.fsh = chkFsh.Checked ? "1" : "0";
            pApm.tvs = chkTvs.Checked ? "1" : "0";

            pApm.repeat_e2 = chkRE2.Checked ? "1" : "0";
            pApm.repeat_prl = chkRPrl.Checked ? "1" : "0";
            pApm.repeat_lh = chkRLh.Checked ? "1" : "0";
            pApm.repeat_fsh = chkRFsh.Checked ? "1" : "0";
        }
        private void FrmAppointmentAdd_Load(object sender, EventArgs e)
        {
            tC.SelectedTab = tabVisit;
        }
    }
}
