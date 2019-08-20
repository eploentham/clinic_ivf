using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1SuperTooltip;
using clinic_ivf.control;
using clinic_ivf.object1;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.gui
{
    public partial class FrmLabBloodAdd : Form
    {
        IvfControl ic;

        String resId = "", body = "";
        LabRequest lbReq;
        LabResult lbRes;
        Patient ptt;
        Visit vs;

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;
        Color color;
        int colRsId = 1, colRsLabName = 2, colRsMethod = 3, colRsResult = 4, colRsInterpret = 5, colRsUnit = 6, colRsNormal = 7, colRsRemark = 8, colRsLabId=9, colRsReqId=10, colRsEdit=11, colRsLotInput=12;

        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        C1FlexGrid grfProc;

        String theme2 = "Office2007Blue";
        public String StatusSperm = "";
        SmtpClient SmtpServer;
        List<LinkedResource> theEmailImage1 = new List<LinkedResource>();
        public FrmLabBloodAdd(IvfControl ic, String resid)
        {
            InitializeComponent();
            this.ic = ic;
            resId = resid;

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
            SmtpServer = new SmtpClient("smtp.gmail.com");

            btnSave.Click += BtnSave_Click;
            btnApproveResult.Click += BtnApproveResult_Click;
            btnPrintHomone.Click += BtnPrintHomone_Click;
            btnSendEmail.Click += BtnSendEmail_Click;
            btnPrintInfectious.Click += BtnPrintInfectious_Click;

            sB1.Text = "";
            bg = txtHn.BackColor;
            fc = txtHn.ForeColor;
            ff = txtHn.Font;

            ic.ivfDB.stfDB.setCboEmbryologist(cboEmbryologistAppv, "");
            ic.ivfDB.stfDB.setCboEmbryologist(cboEmbryologistReport, "");

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            lbRes = new LabResult();
            lbReq = new LabRequest();
            ptt = new Patient();
            vs = new Visit();

            initGrfProc();
            setControl();
        }

        private void BtnPrintInfectious_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmReport frm = new FrmReport(ic);
            DataTable dt = new DataTable();
            dt = ic.ivfDB.lbresDB.selectLabBloodByVsIdInfectious(txtVsId.Text);

            String date1 = "";

            frm.setLabBloodReport(dt, txtHn.Text, txtPttNameE.Text, txtDob.Text, txtSex.Text, cboEmbryologistReport.Text, cboEmbryologistAppv.Text, txtReportDate.Text, txtApprovDate.Text);
            frm.ShowDialog(this);
        }

        private Boolean setReportLabBlood(String filename)
        {
            Boolean chk1 = true;
            DataTable dt = new DataTable();
            dt = ic.ivfDB.lbresDB.selectLabBloodByVsId(txtVsId.Text);
            String chk = "", printerDefault = "";
            ReportDocument rpt = new ReportDocument();
            try
            {
                String date1 = dt.Rows[0]["date_report"].ToString();
                String date2 = dt.Rows[0]["date_approve"].ToString();
                date1 = ic.datetimetoShow(dt.Rows[0]["date_report"]);
                date2 = ic.datetimetoShow(dt.Rows[0]["date_approve"]);
                dt.Rows[0]["date_report"] = date1;
                dt.Rows[0]["date_approve"] = date2;

                rpt.Load("lab_blood_form1.rpt");

                rpt.SetDataSource(dt);
                rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                rpt.SetParameterValue("line2", ic.cop.addr1);
                rpt.SetParameterValue("line3", ic.cop.addr2);
                //rpt.SetParameterValue("report_name", " Summary of OPU Report");
                //rpt.SetParameterValue("date1", "" + date1);
                this.cryLab.ReportSource = rpt;
                this.cryLab.Refresh();

                if (File.Exists(filename))
                {
                    File.Delete(filename);
                    System.Threading.Thread.Sleep(200);
                }

                ExportOptions CrExportOptions;
                DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                CrDiskFileDestinationOptions.DiskFileName = filename;
                CrExportOptions = rpt.ExportOptions;
                {
                    CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                    CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                    CrExportOptions.FormatOptions = CrFormatTypeOptions;
                }

                rpt.Export();
            }
            catch (Exception ex)
            {
                chk1 = false;
                chk = ex.Message.ToString();
                MessageBox.Show("error " + ex.Message, "");
            }
            return chk1;
        }
        private void BtnSendEmail_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //FrmReport frm = new FrmReport(ic);
            //DataTable dt = new DataTable();
            //dt = ic.ivfDB.lbresDB.selectLabBloodByVsId(txtVsId.Text);
            //String date1 = dt.Rows[0]["date_report"].ToString();
            //String date2 = dt.Rows[0]["date_approve"].ToString();
            //date1 = ic.datetimetoShow(dt.Rows[0]["date_report"]);
            //date2 = ic.datetimetoShow(dt.Rows[0]["date_approve"]);
            //dt.Rows[0]["date_report"] = date1;
            //dt.Rows[0]["date_approve"] = date2;
            ////FrmWaiting frmW = new FrmWaiting();
            ////frmW.Show();
            //frm.setSpermSf(dt);
            //frm.ShowDialog(this);

            FrmWaiting frmW = new FrmWaiting();
            frmW.Show();
            String filename = "", datetick = "";
            if (!Directory.Exists("report"))
            {
                Directory.CreateDirectory("report");
            }
            datetick = DateTime.Now.Ticks.ToString();
            filename = "report\\lab_blood_" + datetick + ".pdf";
            if (!setReportLabBlood(filename))
            {
                return;
            }
            frmW.Dispose();

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(txtEmailTo.Text);
            mail.To.Add(txtEmailTo.Text);
            mail.Subject = txtEmailSubject.Text;
            mail.Body = txtEmailBody.Text;

            mail.IsBodyHtml = true;
            if (File.Exists(filename))
            {
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(filename);
                mail.Attachments.Add(attachment);
            }

            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
            mail.AlternateViews.Add(htmlView);

            foreach (LinkedResource linkimg in theEmailImage1)
            {
                htmlView.LinkedResources.Add(linkimg);
            }

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(ic.iniC.email_auth_user, ic.iniC.email_auth_pass);

            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
        }

        private void BtnPrintHomone_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmReport frm = new FrmReport(ic);
            DataTable dt = new DataTable();
            dt = ic.ivfDB.lbresDB.selectLabBloodByVsIdHomone(txtVsId.Text);

            String date1 = "";

            frm.setLabBloodReport(dt, txtHn.Text, txtPttNameE.Text, txtDob.Text, txtSex.Text, cboEmbryologistReport.Text, cboEmbryologistAppv.Text, txtReportDate.Text, txtApprovDate.Text);
            frm.ShowDialog(this);
        }

        private void BtnApproveResult_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.ivfDB.lbresDB.updateResultFinish(txtVsId.Text);
            tC.SelectedTab = tabEmail;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String stfapp = "", stfrpt = "", dateapp = "", daterpt = "";
            DateTime daterpt1 = new DateTime();
            DateTime dateapp1 = new DateTime();
            stfrpt = cboEmbryologistReport.SelectedItem == null ? "" : ((ComboBoxItem)cboEmbryologistReport.SelectedItem).Value;
            stfapp = cboEmbryologistAppv.SelectedItem == null ? "" : ((ComboBoxItem)cboEmbryologistAppv.SelectedItem).Value;
            daterpt = ic.dateTimetoDB1(txtReportDate.Text);
            dateapp = ic.dateTimetoDB1(txtApprovDate.Text);

            Staff stf = new Staff();
            stf = ic.ivfDB.stfDB.selectByPk1(stfrpt);
            if (stf.staff_id.Equals(""))
            {
                MessageBox.Show("ไม่พบ รายชื่อพนักงาน Report", "");
                return;
            }
            stf = ic.ivfDB.stfDB.selectByPk1(stfapp);
            if (stf.staff_id.Equals(""))
            {
                MessageBox.Show("ไม่พบ รายชื่อพนักงาน Approve", "");
                return;
            }
            if(!DateTime.TryParse(daterpt, out daterpt1))
            {
                MessageBox.Show("วันที่ ไม่ถูกต้อง", "");
                return;
            }
            if (!DateTime.TryParse(dateapp, out dateapp1))
            {
                MessageBox.Show("วันที่ ไม่ถูกต้อง", "");
                return;
            }
            String lotInput = "";
            foreach(Row row in grfProc.Rows)
            {
                String id = "", edit = "", result="", interpret="", remark, lotinput="";
                id = row[colRsId] != null ? row[colRsId].ToString() : "";
                edit = row[colRsEdit] != null ? row[colRsEdit].ToString() : "";
                result = row[colRsResult] != null ? row[colRsResult].ToString() : "";
                interpret = row[colRsInterpret] != null ? row[colRsInterpret].ToString() : "";
                remark = row[colRsRemark] != null ? row[colRsRemark].ToString() : "";
                lotinput = row[colRsLotInput] != null ? row[colRsLotInput].ToString() : "";
                if (edit.Equals("1") && !result.Equals(""))
                {
                    if (lotinput.Equals(""))
                    {
                        lotinput = ic.ivfDB.lbresDB.selectLotInput(txtVsId.Text);
                        int chk1 = 0;
                        if(int.TryParse(lotinput, out chk1))
                        {
                            lotinput = (chk1 + 1).ToString();
                        }
                    }
                    String re = ic.ivfDB.lbresDB.updateResult(result, interpret, stfapp, stfrpt, dateapp, daterpt, remark, lotinput, id);
                    long chk = 0;
                    if(long.TryParse(re, out chk))
                    {

                    }
                }
            }
        }
        private void setControl()
        {
            lbRes = ic.ivfDB.lbresDB.selectByPk(resId);
            vs = ic.ivfDB.vsDB.selectByPk1(lbRes.visit_id);
            ptt = ic.ivfDB.pttDB.selectByPk1(vs.t_patient_id);

            txtVn.Value = vs.visit_vn;
            txtPttId.Value = ptt.t_patient_id;
            txtVsId.Value = vs.t_visit_id;

            txtVnShow.Value = ic.showVN(vs.visit_vn);
            txtHn.Value = ptt.patient_hn;
            txtPttNameE.Value = ptt.Name;
            txtDob.Value = ic.datetoShow(ptt.patient_birthday) + " [" + ptt.AgeStringShort() + "]";
            txtSex.Value = ptt.f_sex_id.Equals("1") ? "ชาย" : "หญิง";

            ic.setC1Combo(cboEmbryologistAppv, lbRes.staff_id_approve);
            ic.setC1Combo(cboEmbryologistReport, lbRes.staff_id_result);

            txtApprovDate.Value = lbRes.date_time_approve;
            txtReportDate.Value = lbRes.date_time_result;

            txtEmailTo.Value = ic.iniC.email_to_sperm_freezing;
            txtEmailSubject.Value = "Result LAB Blood HN " + txtHn.Text + " Name " + txtPttNameE.Text + " [VN " + txtVnShow.Text + "]";

            setGrfProc();
        }
        private void initGrfProc()
        {
            grfProc = new C1FlexGrid();
            grfProc.Font = fEdit;
            grfProc.Dock = System.Windows.Forms.DockStyle.Fill;
            grfProc.Location = new System.Drawing.Point(0, 0);
            grfProc.ChangeEdit += GrfProc_ChangeEdit;
            grfProc.AfterRowColChange += GrfProc_AfterRowColChange;
            grfProc.AfterEdit += GrfProc_AfterEdit;
            //FilterRow fr = new FilterRow(grfExpn);

            pnProc.Controls.Add(grfProc);

            theme1.SetTheme(grfProc, "Office2010Blue");
        }

        private void GrfProc_AfterEdit(object sender, RowColEventArgs e)
        {
            //throw new NotImplementedException();
            if (grfProc.Row <= 0) return;
            if (grfProc.Col <= 0) return;
            if (grfProc.Col == colRsResult)
            {
                String resid = "", labid = "", result = "", result2="";
                result = grfProc[grfProc.Row, colRsResult] != null ? grfProc[grfProc.Row, colRsResult].ToString() : "";
                if (result.Equals("w"))
                {
                    grfProc[grfProc.Row, colRsInterpret] = "Wait for Result";
                }
                else
                {
                    Decimal result1 = 0;
                    OldLabItem labI = new OldLabItem();
                    resid = grfProc[grfProc.Row, colRsId] != null ? grfProc[grfProc.Row, colRsId].ToString() : "";
                    labid = grfProc[grfProc.Row, colRsLabId] != null ? grfProc[grfProc.Row, colRsLabId].ToString() : "";

                    labI = ic.ivfDB.oLabiDB.selectByPk1(labid);
                    if (labI.LID.Length <= 0) return;
                    if (labI.status_interpret.Equals("1"))
                    {
                        if(result.Equals(""))
                        {
                            grfProc[grfProc.Row, colRsInterpret] = "";
                        }
                        if (result.IndexOf("<") >= 0 || (result.IndexOf(">") >= 0))
                        {
                            result2 = result.Replace("<", "").Replace(">", "");
                        }
                        if (!Decimal.TryParse(result2, out result1)) return;
                        grfProc[grfProc.Row, colRsInterpret] = ic.ivfDB.lbinDB.selectInterpret(labid, result1.ToString());
                    }
                    else
                    {
                        grfProc[grfProc.Row, colRsInterpret] = result;
                    }
                }
                
                grfProc[grfProc.Row, colRsEdit] = "1";
                grfProc.Rows[grfProc.Row].StyleNew.BackColor = color;
            }
        }

        private void GrfProc_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            
            
        }

        private void setGrfProc()
        {
            //grfDept.Rows.Count = 7;
            grfProc.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.lbresDB.selectLabBloodByProcess(lbRes.visit_id);
            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfProc.Rows.Count = dt.Rows.Count + 1;
            //grfSperm.DataSource = dt;
            grfProc.Cols.Count = 13;
            CellStyle cs = grfProc.Styles.Add("bool");
            cs.DataType = typeof(bool);
            cs.ImageAlign = ImageAlignEnum.LeftCenter;

            C1ComboBox cboMethod = new C1ComboBox();
            cboMethod.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboMethod.AutoCompleteSource = AutoCompleteSource.ListItems;
            ic.ivfDB.lbmDB.setCboLabMethod(cboMethod, "");
            C1ComboBox cboUnit = new C1ComboBox();
            cboUnit.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboUnit.AutoCompleteSource = AutoCompleteSource.ListItems;
            ic.ivfDB.lbuDB.setCboLabUnit(cboUnit, "");

            grfProc.Cols[colRsMethod].Editor = cboMethod;
            grfProc.Cols[colRsUnit].Editor = cboUnit;
            grfProc.Cols[colRsLabName].Width = 200;
            grfProc.Cols[colRsMethod].Width = 100;
            grfProc.Cols[colRsResult].Width = 100;
            grfProc.Cols[colRsInterpret].Width = 100;
            grfProc.Cols[colRsUnit].Width = 100;
            grfProc.Cols[colRsNormal].Width = 100;
            grfProc.Cols[colRsRemark].Width = 200;
            //grfProc.Cols[colBlQty].Width = 60;
            
            grfProc.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfProc.Cols[colRsLabName].Caption = "Name";
            grfProc.Cols[colRsMethod].Caption = "Method";
            grfProc.Cols[colRsResult].Caption = "Result";
            grfProc.Cols[colRsInterpret].Caption = "Interpret";
            grfProc.Cols[colRsUnit].Caption = "Unit";
            grfProc.Cols[colRsNormal].Caption = "Normal";
            grfProc.Cols[colRsRemark].Caption = "Remark";
            //grfProc.Cols[colUnit].Caption = "Remark";
            //grfProc.Cols[colUnit].Caption = "Remark";

            //CellRange rg = grfProc.GetCellRange(1, colBlInclude, grfProc.Rows.Count - 1, colBlInclude);
            //rg.Style = cs;
            //rg.Style = grfProc.Styles["bool"];

            int i = 0;
            decimal aaa = 0;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    i++;
                    //if (i == 1) continue;
                    //Decimal.TryParse(row[ic.ivfDB.oLabiDB.labI.Price].ToString(), out aaa);
                    grfProc[i, colRsId] = row[ic.ivfDB.lbresDB.lbRes.result_id].ToString();
                    grfProc[i, colRsLabName] = row[ic.ivfDB.oLabiDB.labI.LName].ToString();
                    grfProc[i, colRsMethod] =  ic.ivfDB.lbmDB.getNameById(row[ic.ivfDB.oLabiDB.labI.method_id].ToString());
                    grfProc[i, colRsRemark] = row[ic.ivfDB.lbresDB.lbRes.remark].ToString();
                    grfProc[i, colRsLotInput] = row[ic.ivfDB.lbresDB.lbRes.lot_input].ToString();
                    if (row[ic.ivfDB.oLabiDB.labI.status_datatype_result].ToString().Equals("4"))       // combobox
                    {
                        C1ComboBox cbo = new C1ComboBox();
                        cbo.AutoCompleteMode = AutoCompleteMode.Suggest;
                        cbo.AutoCompleteSource = AutoCompleteSource.ListItems;
                        ic.ivfDB.lbDtDB.setCboLabDataTypeComboBox(cbo, "", row[ic.ivfDB.lbresDB.lbRes.lab_id].ToString());

                        CellRange cr = grfProc.GetCellRange(i, colRsResult, i, colRsResult);
                        //cr.Style = grfProc.Styles["emp"];
                        cr.StyleNew.Editor = cbo;
                        //CellStyle cs1 = grfProc.Styles.Add("bool");
                        //cr.Style = cs1;
                    }
                    else if (row[ic.ivfDB.oLabiDB.labI.status_datatype_result].ToString().Equals("2"))      // integer
                    {
                    //    C1ComboBox cbo = new C1ComboBox();
                    //    cbo.AutoCompleteMode = AutoCompleteMode.Suggest;
                    //    cbo.AutoCompleteSource = AutoCompleteSource.ListItems;
                    //    ic.ivfDB.lbinDB.setCboLabInterpretComboBox(cbo, "", row[ic.ivfDB.lbresDB.lbRes.lab_id].ToString());
                        
                        CellRange cr = grfProc.GetCellRange(i, colRsResult, i, colRsResult);
                        //cr.StyleNew.Editor = cbo;
                        CellStyle cs1 = grfProc.Styles.Add("integer");
                        cs.DataType = typeof(int);
                        cs.ForeColor = Color.CornflowerBlue;
                        cr.Style = cs1;
                    }
                    else if (row[ic.ivfDB.oLabiDB.labI.status_datatype_result].ToString().Equals("3"))      // decimal
                    {
                        CellRange cr = grfProc.GetCellRange(i, colRsResult, i, colRsResult);
                        //cr.StyleNew.Editor = cbo;
                        CellStyle cs1 = grfProc.Styles.Add("decimal");
                        cs.DataType = typeof(decimal);
                        cs.ForeColor = Color.DarkGreen;
                        cr.Style = cs1;
                    }
                    grfProc[i, colRsResult] = row[ic.ivfDB.lbresDB.lbRes.result].ToString();
                    grfProc[i, colRsInterpret] = row[ic.ivfDB.lbresDB.lbRes.interpret].ToString();
                    grfProc[i, colRsUnit] = ic.ivfDB.lbuDB.getNameById(row[ic.ivfDB.oLabiDB.labI.lab_unit_id].ToString());
                    grfProc[i, colRsNormal] = row[ic.ivfDB.lbresDB.lbRes.normal_value].ToString();
                    grfProc[i, colRsRemark] = row[ic.ivfDB.lbresDB.lbRes.remark].ToString();
                    grfProc[i, colRsLabId] = row[ic.ivfDB.oLabiDB.labI.LID].ToString();
                    grfProc[i, colRsEdit] = "";
                    //grfSgrfProcperm[i, colBlQty] = "1";
                    row[0] = (i - 2);
                }
                catch (Exception ex)
                {
                    String err = "";
                }

            }
            CellNoteManager mgr = new CellNoteManager(grfProc);
            grfProc.Cols[colRsId].Visible = false;
            grfProc.Cols[colRsLabId].Visible = false;
            grfProc.Cols[colRsReqId].Visible = false;
            grfProc.Cols[colRsEdit].Visible = false;
            grfProc.Cols[colRsLotInput].Visible = false;

            grfProc.Cols[colRsLabName].AllowEditing = false;
            //grfProc.Cols[colRsMethod].AllowEditing = false;
            //grfProc.Cols[colRsResult].AllowEditing = false;
            //grfProc.Cols[colRsInterpret].AllowEditing = false;
            grfProc.Cols[colRsEdit].AllowEditing = false;
            grfProc.Cols[colRsNormal].AllowEditing = false;
            grfProc.Cols[colRsRemark].AllowEditing = false;
            //theme1.SetTheme(grfFinish, ic.theme);

        }
        private void GrfProc_ChangeEdit(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            grfProc[grfProc.Row, colRsEdit] = "1";
            grfProc.Rows[grfProc.Row].StyleNew.BackColor = color;
        }

        private void FrmLabBloodAdd_Load(object sender, EventArgs e)
        {
            tC.SelectedTab = tabResult;
        }
    }
}
