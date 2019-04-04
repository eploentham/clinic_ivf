using C1.Win.C1FlexGrid;
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
    public partial class FrmOrReqAdd : Form
    {
        IvfControl ic;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;

        OrRequest orreq;
        Patient ptt;
        C1FlexGrid grfReq, grfReqOr, grfAnes, grfDtr;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;

        int colID = 1, colCode = 2, colName = 3, colGrdId=4, colGrdname=5, colCnt = 6;
        int colreqID = 1, colreqHn = 2, colreqDate = 3, colreqDiag = 4, colreqCnt = 5;
        Boolean pageLoad = false;

        public FrmOrReqAdd(IvfControl ic)
        {
            InitializeComponent();
            this.ic = ic;
            initConfig();
        }
        private void initConfig()
        {
            pageLoad = true;
            theme1 = new C1.Win.C1Themes.C1ThemeController();
            theme1.Theme = "Office2013Red";
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();

            orreq = new OrRequest();
            ptt = new Patient();
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);

            txtReqDate.Value = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd HH:mm:ss");
            
            //btnReq.Image = Resources.Ticket_24;
            btnSearch.Click += BtnSearch_Click;
            cboFetDay.SelectedIndexChanged += CboFetDay_SelectedIndexChanged;
            btnSave.Click += BtnSave_Click;
            btnPrint.Click += BtnPrint_Click;

            initGrfDiag();
            setGrfPosi("");
            initGrfReqOr();
            setGrfReqOr("");
            initGrfAnes();
            setGrfAnes();
            initGrfDtr();
            setGrfDtr();
            //ic.ivfDB.itmDB.setCboItem(cboLabReq, "");
            //ic.ivfDB.dtrOldDB.setCboDoctor(cboDoctor, "");

            //btnSearch.Click += BtnSearch_Click;
            //btnReq.Click += BtnReq_Click;
            pageLoad = false;
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmReport frm = new FrmReport(ic);
            DataTable dt = new DataTable();
            
            dt = ic.ivfDB.orreqDB.selectByOrAppointment(txtID.Text);
            dt.Rows[0]["age"] = txtDob.Text;
            frm.setOrAppointment(dt);
            frm.ShowDialog(this);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.cStf.staff_id = "";
            FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            frm.ShowDialog(this);
            if (!ic.cStf.staff_id.Equals(""))
            {
                setOrRequest();
                String re = "";
                long chk = 0;
                re = ic.ivfDB.orreqDB.insertOrRequest(orreq, ic.cStf.staff_id);
                if(long.TryParse(re, out chk))
                {
                    btnSave.Image = Resources.accept_database24;
                    setGrfReqOr(txtPttId.Text);
                }
                else
                {

                }
            }
        }

        private void CboFetDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            cboFetDay.Enabled = false;
            String id = "";
            //id = cboFetDay.SelectedItem == null ? "" : ((ComboBoxItem)cboFetDay.SelectedItem).Value;
            id = ic.getC1ComboBySelectedIndex(cboFetDay);
            //String deptId = "";
            //deptId = grfReq[e.NewRange.r1, colID] != null ? grfReq[e.NewRange.r1, colID].ToString() : "";
            setGrfPosi(id);
            cboFetDay.Enabled = true;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.sVsOld.PIDS = "";
            ic.sVsOld.PName = "";
            FrmSearchHn frm = new FrmSearchHn(ic, FrmSearchHn.StatusConnection.host, FrmSearchHn.StatusSearch.PttSearch, FrmSearchHn.StatusSearchTable.PttSearch);
            frm.ShowDialog(this);
            ptt = new Patient();
            ptt = ic.ivfDB.pttDB.selectByHn(ic.sVsOld.PIDS);
            txtHn.Value = ic.sVsOld.PIDS;
            txtPttNameE.Value = ic.sVsOld.PName;
            txtDob.Value = ic.sVsOld.dob +"["+ ptt.AgeStringShort()+"]";
            txtPttId.Value = ptt.t_patient_id;
            txtSex.Value = ptt.f_sex_id.Equals("1") ? "ชาย" : "หญิง";
            txtBg.Value = ptt.f_patient_blood_group_id.Equals("2140000005") ? "O"
                : ptt.f_patient_blood_group_id.Equals("2140000002") ? "A" : ptt.f_patient_blood_group_id.Equals("2140000003") ? "B"
                : ptt.f_patient_blood_group_id.Equals("2140000004") ? "AB" : "ไม่ระบุ";
            setGrfReqOr(txtPttId.Text);
        }
        private void setOrRequest()
        {
            orreq.or_req_id = txtID.Text;
            orreq.or_req_code = ic.ivfDB.copDB.genReqDoc();
            orreq.or_req_date = ic.datetoDB(txtReqDate.Text);
            orreq.patient_hn = txtHn.Text;
            orreq.patient_name = txtPttNameE.Text;
            orreq.remark = txtRemark.Text;
            orreq.date_create = "";
            orreq.date_modi = "";
            orreq.date_cancel = "";
            orreq.user_create = "";
            orreq.user_modi = "";
            orreq.user_cancel = "";
            orreq.active = "";
            orreq.doctor_anesthesia_id = "";
            orreq.doctor_surgical_id = "";
            orreq.or_date = ic.datetoDB(txtOrDate.Text);
            orreq.or_time = txtOrTime.Text;
            orreq.status_or = "1";
            orreq.b_service_point_id = cboVisitBsp.SelectedItem == null ? "" : ((ComboBoxItem)cboVisitBsp.SelectedItem).Value; ;
            orreq.or_id = "";
            orreq.opera_id = txtDiagId.Text;
            orreq.t_patient_id = txtPttId.Text;
            orreq.status_urgent = chkUrgent.Checked ? "1" : "2";
            orreq.anesthesia_id = txtAnesId.Text;
            orreq.doctor_surgical_id = txtDtrId.Text;
        }
        private void setControl(String id)
        {
            orreq = ic.ivfDB.orreqDB.selectByPk1(id);
            ptt = ic.ivfDB.pttDB.selectByPk1(orreq.t_patient_id);
            txtID.Value = orreq.or_req_id;
            txtHn.Value = orreq.patient_hn;
            txtPttNameE.Value = orreq.patient_name;
            txtDob.Value = ic.sVsOld.dob + "[" + ptt.AgeStringShort() + "]";
            txtPttId.Value = ptt.t_patient_id;
            txtSex.Value = ptt.f_sex_id.Equals("1") ? "ชาย" : "หญิง";
            txtBg.Value = ptt.f_patient_blood_group_id.Equals("2140000005") ? "O"
                : ptt.f_patient_blood_group_id.Equals("2140000002") ? "A" : ptt.f_patient_blood_group_id.Equals("2140000003") ? "B"
                : ptt.f_patient_blood_group_id.Equals("2140000004") ? "AB" : "ไม่ระบุ";
            txtID.Value = orreq.or_req_id;
            txtReqCode.Value = orreq.or_req_code;
            //txtDiagGrpId.Value = orreq.id
            txtDiagId.Value = orreq.opera_id;
            txtAnesId.Value = orreq.anesthesia_id;
            txtDtrId.Value = orreq.doctor_surgical_id;
            txtReqDate.Value = orreq.or_req_date;
            txtDiagGrp.Value = orreq.operation_group_name;
            txtOpera.Value = orreq.operation_name;
            txtAnes.Value = orreq.anesthesia_name;
            txtRemark.Value = orreq.remark;
            txtOrDate.Value = orreq.or_date;
            txtOrTime.Value = orreq.or_time;
            txtDtrName.Value = orreq.surgeon;
        }
        private void initGrfDtr()
        {
            grfDtr = new C1FlexGrid();
            grfDtr.Font = fEdit;
            grfDtr.Dock = System.Windows.Forms.DockStyle.Fill;
            grfDtr.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfPosi);

            grfDtr.AfterRowColChange += GrfDtr_AfterRowColChange;
            //grfAgn.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellButtonClick);
            //grfAgn.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellChanged);

            panel7.Controls.Add(this.grfDtr);

            C1Theme theme = C1ThemeController.GetThemeByName("Office2013Red", false);
            C1ThemeController.ApplyThemeToObject(grfDtr, theme);
        }

        private void GrfDtr_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;
            if (pageLoad) return;

            String deptId = "", name, grdid = "", grdname = "";
            deptId = grfDtr[e.NewRange.r1, colID] != null ? grfDtr[e.NewRange.r1, colID].ToString() : "";
            name = grfDtr[e.NewRange.r1, colName] != null ? grfDtr[e.NewRange.r1, colName].ToString() : "";
            txtDtrName.Value = name;
            txtDtrId.Value = deptId;
        }

        private void setGrfDtr()
        {
            //grfDept.Rows.Count = 7;
            //grfReqOr.Rows.Count = 1;
            grfDtr.DataSource = ic.ivfDB.stfDB.selectAllDoctor();
            grfDtr.Cols.Count = colCnt;

            grfDtr.Cols[colCode].Width = 80;
            grfDtr.Cols[colName].Width = 300;

            grfDtr.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfDtr.Cols[colCode].Caption = "รหัส";
            grfDtr.Cols[colName].Caption = "Doctor ";

            for (int i = 1; i < grfDtr.Rows.Count; i++)
            {
                grfDtr[i, 0] = i;
                if (i % 2 == 0)
                    grfDtr.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            }
            grfDtr.Cols[colID].Visible = false;
            //grfDtr.Cols[colGrdId].Visible = false;
            //grfDtr.Cols[colGrdname].Visible = false;
            //grfAgn.Cols[colRemark].Visible = false;
        }
        private void initGrfAnes()
        {
            grfAnes = new C1FlexGrid();
            grfAnes.Font = fEdit;
            grfAnes.Dock = System.Windows.Forms.DockStyle.Fill;
            grfAnes.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfPosi);

            grfAnes.AfterRowColChange += GrfAnes_AfterRowColChange;
            //grfAgn.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellButtonClick);
            //grfAgn.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellChanged);

            panel6.Controls.Add(this.grfAnes);

            C1Theme theme = C1ThemeController.GetThemeByName("Office2013Red", false);
            C1ThemeController.ApplyThemeToObject(grfAnes, theme);
        }
        
        private void GrfAnes_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;
            if (pageLoad) return;

            String deptId = "", name, grdid = "", grdname = "";
            deptId = grfAnes[e.NewRange.r1, colID] != null ? grfAnes[e.NewRange.r1, colID].ToString() : "";
            name = grfAnes[e.NewRange.r1, colName] != null ? grfAnes[e.NewRange.r1, colName].ToString() : "";
            txtAnes.Value = name;
            txtAnesId.Value = deptId;
        }

        private void setGrfAnes()
        {
            //grfDept.Rows.Count = 7;
            //grfReqOr.Rows.Count = 1;
            grfAnes.DataSource = ic.ivfDB.oranesDB.selectAll1();
            grfAnes.Cols.Count = colCnt;

            grfAnes.Cols[colCode].Width = 80;
            grfAnes.Cols[colName].Width = 300;            

            grfAnes.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfAnes.Cols[colCode].Caption = "รหัส";
            grfAnes.Cols[colName].Caption = "Anesthesia ";

            for (int i = 1; i < grfAnes.Rows.Count; i++)
            {
                grfAnes[i, 0] = i;
                if (i % 2 == 0)
                    grfAnes.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            }
            grfAnes.Cols[colID].Visible = false;
            //grfReq.Cols[colGrdId].Visible = false;
            //grfReq.Cols[colGrdname].Visible = false;
            //grfAgn.Cols[colRemark].Visible = false;
        }
        private void initGrfReqOr()
        {
            grfReqOr = new C1FlexGrid();
            grfReqOr.Font = fEdit;
            grfReqOr.Dock = System.Windows.Forms.DockStyle.Fill;
            grfReqOr.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfPosi);
            grfReqOr.DoubleClick += GrfReqOr_DoubleClick;
            //grfOr.Dou
            //grfAgn.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellButtonClick);
            //grfAgn.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellChanged);

            panel3.Controls.Add(this.grfReqOr);

            C1Theme theme = C1ThemeController.GetThemeByName("Office2013Red", false);
            C1ThemeController.ApplyThemeToObject(grfReqOr, theme);
        }

        private void GrfReqOr_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfReqOr.Row < 0) return;
            String id = grfReqOr[grfReqOr.Row, colreqID] != null ? grfReqOr[grfReqOr.Row, colreqID].ToString() : "";
            setControl(id);
        }

        private void setGrfReqOr(String id)
        {
            //grfDept.Rows.Count = 7;
            //grfReqOr.Rows.Count = 1;
            grfReqOr.DataSource = ic.ivfDB.orreqDB.selectByPtt1(id);
            grfReqOr.Cols.Count = colreqCnt;

            grfReqOr.Cols[colreqHn].Width = 80;
            grfReqOr.Cols[colreqDate].Width = 80;
            grfReqOr.Cols[colreqDiag].Width = 300;

            grfReqOr.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfReqOr.Cols[colreqHn].Caption = "รหัส";
            grfReqOr.Cols[colreqDate].Caption = "Date ";
            grfReqOr.Cols[colreqDiag].Caption = "Diagnosis ";

            for (int i = 1; i < grfReqOr.Rows.Count; i++)
            {
                grfReqOr[i, 0] = i;
                if (i % 2 == 0)
                    grfReqOr.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            }
            grfReqOr.Cols[colreqID].Visible = false;
            grfReqOr.Cols[colreqHn].AllowEditing = false;
            grfReqOr.Cols[colreqDate].AllowEditing = false;
            grfReqOr.Cols[colreqDiag].AllowEditing = false;
        }
        private void initGrfDiag()
        {
            grfReq = new C1FlexGrid();
            grfReq.Font = fEdit;
            grfReq.Dock = System.Windows.Forms.DockStyle.Fill;
            grfReq.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfPosi);

            grfReq.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grfPosi_AfterRowColChange);
            //grfAgn.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellButtonClick);
            //grfAgn.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellChanged);

            panel5.Controls.Add(this.grfReq);

            C1Theme theme = C1ThemeController.GetThemeByName("Office2013Red", false);
            C1ThemeController.ApplyThemeToObject(grfReq, theme);
        }
        private void grfPosi_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;
            if (pageLoad) return;

            String deptId = "", name, grdid="", grdname="";
            deptId = grfReq[e.NewRange.r1, colID] != null ? grfReq[e.NewRange.r1, colID].ToString() : "";
            name = grfReq[e.NewRange.r1, colName] != null ? grfReq[e.NewRange.r1, colName].ToString() : "";
            grdid = grfReq[e.NewRange.r1, colGrdId] != null ? grfReq[e.NewRange.r1, colGrdId].ToString() : "";
            grdname = grfReq[e.NewRange.r1, colGrdname] != null ? grfReq[e.NewRange.r1, colGrdname].ToString() : "";
            txtOpera.Value = name;
            txtDiagId.Value = deptId;
            txtDiagGrpId.Value = grdid;
            txtDiagGrp.Value = grdname;
            //setGrfPosi(deptId);
            //setControlEnable(false);
            //setControlAddr(addrId);
            //setControlAddrEnable(false);
        }
        private void setGrfPosi(String id)
        {
            //grfDept.Rows.Count = 7;

            grfReq.DataSource = ic.ivfDB.ordDB.selectByGroup1(id);
            grfReq.Cols.Count = colCnt;

            grfReq.Cols[colID].Width = 80;

            grfReq.Cols[colCode].Width = 80;
            grfReq.Cols[colName].Width = 300;

            grfReq.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfReq.Cols[colCode].Caption = "รหัส";
            grfReq.Cols[colName].Caption = "ชื่อ Diagnosis ";

            for (int i = 1; i < grfReq.Rows.Count; i++)
            {
                grfReq[i, 0] = i;
                if (i % 2 == 0)
                    grfReq.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            }
            grfReq.Cols[colID].Visible = false;
            grfReq.Cols[colGrdId].Visible = false;
            grfReq.Cols[colGrdname].Visible = false;
            //grfAgn.Cols[colRemark].Visible = false;
        }
        private void FrmOrReqAdd_Load(object sender, EventArgs e)
        {
            ic.ivfDB.ordgDB.setC1CboDiagGroup(cboFetDay);
            ic.ivfDB.bspDB.setCboBsp(cboVisitBsp, "2120000010");
        }
    }
}
