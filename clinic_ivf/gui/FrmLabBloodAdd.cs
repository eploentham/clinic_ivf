using C1.Win.C1FlexGrid;
using C1.Win.C1SuperTooltip;
using clinic_ivf.control;
using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        int colRsId = 1, colRsLabName = 2, colRsMethod = 3, colRsResult = 4, colRsInterpret = 5, colRsUnit = 6, colRsNormal = 7, colRsRemark = 8, colRsLabId=9, colRsReqId=10;

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
            txtName.Value = ptt.Name;
            txtDobFeMale.Value = ic.datetoShow(ptt.patient_birthday) + " [" + ptt.AgeStringShort() + "]";
            txtSex.Value = ptt.f_sex_id.Equals("1") ? "ชาย" : "หญิง";

            setGrfProc();
        }
        private void initGrfProc()
        {
            grfProc = new C1FlexGrid();
            grfProc.Font = fEdit;
            grfProc.Dock = System.Windows.Forms.DockStyle.Fill;
            grfProc.Location = new System.Drawing.Point(0, 0);
            grfProc.ChangeEdit += GrfProc_ChangeEdit;

            //FilterRow fr = new FilterRow(grfExpn);

            pnProc.Controls.Add(grfProc);

            theme1.SetTheme(grfProc, "Office2010Blue");
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
            grfProc.Cols.Count = 11;
            CellStyle cs = grfProc.Styles.Add("bool");
            cs.DataType = typeof(bool);
            cs.ImageAlign = ImageAlignEnum.LeftCenter;

            grfProc.Cols[colRsLabName].Width = 200;
            grfProc.Cols[colRsMethod].Width = 100;
            grfProc.Cols[colRsResult].Width = 100;
            grfProc.Cols[colRsInterpret].Width = 100;
            grfProc.Cols[colRsUnit].Width = 80;
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
                    grfProc[i, colRsMethod] = row[ic.ivfDB.lbresDB.lbRes.method].ToString();
                    grfProc[i, colRsResult] = row[ic.ivfDB.lbresDB.lbRes.result].ToString();
                    grfProc[i, colRsInterpret] = row[ic.ivfDB.lbresDB.lbRes.interpret].ToString();
                    grfProc[i, colRsUnit] = row[ic.ivfDB.lbresDB.lbRes.unit].ToString();
                    grfProc[i, colRsNormal] = row[ic.ivfDB.lbresDB.lbRes.normal_value].ToString();
                    grfProc[i, colRsRemark] = row[ic.ivfDB.lbresDB.lbRes.remark].ToString();
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

            grfProc.Cols[colRsLabName].AllowEditing = false;
            grfProc.Cols[colRsMethod].AllowEditing = false;
            grfProc.Cols[colRsResult].AllowEditing = false;
            grfProc.Cols[colRsInterpret].AllowEditing = false;
            grfProc.Cols[colRsUnit].AllowEditing = false;
            grfProc.Cols[colRsNormal].AllowEditing = false;
            grfProc.Cols[colRsRemark].AllowEditing = false;
            //theme1.SetTheme(grfFinish, ic.theme);

        }
        private void GrfProc_ChangeEdit(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

        }

        private void FrmLabBloodAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
