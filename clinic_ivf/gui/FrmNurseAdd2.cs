using C1.C1Preview;
using C1.C1Report;
using C1.Win.C1Command;
using C1.Win.C1Document;
using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1Ribbon;
using C1.Win.C1SplitContainer;
using C1.Win.C1SuperTooltip;
using C1.Win.C1Themes;
using clinic_ivf.control;
using clinic_ivf.FlexGrid;
using clinic_ivf.object1;
using clinic_ivf.Properties;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.gui
{
    /*
     * 62-07-06     0006        LMP	คำนวณไม่ถูก
     * 63-01-11     0015        ลงโปรแกรมที่ ww แล้ว การเงิน คิดเงินผิด
     * 63-01-26     0016        ลงโปรแกรมที่ ww แล้ว การเงิน Package ที่พยาบาลป้อนไม่ขึ้น
     */
    public partial class FrmNurseAdd2 : Form
    {
        IvfControl ic;
        MainMenu menu;
        public C1DockingTabPage tab;

        String pttId = "", webcamname = "", vn = "", flagedit = "", pApmId = "", pid="";
        Patient ptt;
        VisitOld vsOld;
        Visit vs;
        PatientOld pttOld, pttO;
        PatientAppointment pApm;
        AppointmentOld pApmO;
        EggSti eggs;
        PatientMedicalHistory pmh;

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;

        C1FlexGrid grfBloodLab, grfSperm, grfEmbryo, grfGenetic, grfSpecial, grfRx, grfRxSet, grfOrder, grfPackage, grfPackageD, grfRxSetD, grfNote, grfpApmAll, grfpApmDayAll, grfpApmVisit, grfImgOutLab, grfHis;
        C1FlexGrid grfEggsd, grfLab, grfHisDrug, grfImg, grfPg, grfItminPkg, grfFormAView;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        List<C1FlexGrid> lgrfPkg;

        int colImgID = 1, colImgHn = 2, colImgImg = 3, colImgDesc = 4, colImgDesc2 = 5, colImgDesc3 = 6, colImgPathPic = 7, colImgBtn = 8, colImgStatus = 9, colImgDoctor = 10;
        int colBlId = 1, colBlName = 2, colBlQty = 3, colBlPrice = 4, colBlInclude = 5, colBlRemark = 6, colBlOrderGroup=7, colBlPkgName=8, colBlPkgId=9;
        int colPkgdId = 1, colPkgType = 2, colPkgItmName = 3, colPkgQty = 4, colPkgUse=5,colPkgsId = 6, colPkgItmId=7;
        int colRxdId = 1, colRxName = 2, colRxQty = 3, colRxPrice = 4, colRxInclude = 5, colRxRemark = 6, colRxUsE = 7, colRxUsT = 8, colRxId = 9, colRxItmId = 10;
        int colNoteId = 1, colNote = 2, colNoteStatusAll = 3;
        int colApmId = 1, colApmAppointment = 4, colApmDate = 2, colApmTime = 3, colApmDoctor = 5, colApmSp = 6, colApmNotice = 7, colE2 = 8, colLh = 9, colEndo = 10, colPrl = 10, colFsh = 11, colRt = 12, colLt = 13;
        int colRsLabReqId = 1, colRslabName = 2, colRsRemarkReq=3, colRsMethod = 4, colRsResult = 5, colRsInterpret = 6, colRsReactive = 7, colRsUnit = 8, colRsNormal = 9, colRsRemark = 10, colRsLabStatusShow = 11, colRsLabId = 12, colRsLabStatus = 13;
        int colRsLabSend=14, colRsLabReqdate=15, colRsLabDatetimereceive=16, colRsLabdatetimeresult=17, colRslabdatetimeapprove=18, colRslabjoblabid=19, colRslabjoblabreqid=20, colRslabStatusResult=21;
        int colHisVsId = 1, colHisVsDate = 2, colHisVsVn = 3;
        int colPgId = 1, colPgFilename = 2;
        int colItminPkgId = 1, colItminPgkOrdDate = 2, colItminPkgItmTyp = 3, colItminPkgItmName = 4, colItminPkgPrice = 5, colItminPkgQty=6, colItminPkgExtra=7, colItminPkgQtyAmt=8;

        int colFormADate = 1, colFormACode = 2, colFormAId = 3;
        int colOrderPID = 7, colOrderPIDS = 8, colOrderLName = 9, colOrderSP1V = 10, colOrderSP2V = 11, colOrderSP3V = 12;
        int colOrderSP4V = 13, colOrderSP5V = 14, colOrderSP6V = 15, colOrderSP7V = 16, colOrderSubItem = 17;
        int colOrderFileName = 18, colOrderWorder1 = 19, colOrderWorker2 = 20, colOrderWorker3 = 21, colOrderWorkder4 = 22;
        int colOrderWorker5 = 23, colOrderLGID = 24, colOrderQTY = 25, colOrderActive = 26;
        int colOrdid = 1, colOrdDate=2, colOrdlpid = 3, colOrdName = 4, colOrdPrice = 5, colOrdPrice1=6, colOrdQty = 7, colOrdstatus = 8, colOrdrow1 = 9, colOrditmid = 10, colOrdInclude = 11, colOrdAmt = 12, colOrdUsE = 13, colOrdUsT = 14, colOrdOrderId=15, colOrdStatusAmt=16, colOrdStatusOrdGrp=17, colOrdPkgSId=18;
        int rowOrder = 0, spHeight = 150;
        int colEggDay = 1, colEggDate = 2, colEggE2 = 3, colEggLH = 4, colEggFSH = 5, colEggProlactin = 6, colEggRt1 = 7, colEggRt2 = 8, colEggLt1 = 9, colEggLt2 = 10, colEggEndo = 11, colEggMedi = 12, colEggId = 13, colEggEdit = 14, colEggMedi2 = 15;
        
        //int colId = 1, colAppointment = 4, colDate = 2, colTime = 3, colDoctor = 5, colSp = 6, colNotice = 7, colE2 = 8, colLh = 9, colEndo = 10, colPrl = 10, colFsh = 11, colRt = 12, colLt = 13;

        Image imgCorr, imgTran;
        static String filenamepic = "";
        decimal rat = 0;
        Color color;

        string documentName, filePathNamePg;
        string documentPath;
        RichTextBoxStreamType documentFileType;
        FrmNurseView frmNurView;
        Boolean flagImg = false, pageLoad=false;
        [STAThread]
        private void richTextBox1SetText(String txt)
        {
            richTextBox1.Invoke(new EventHandler(delegate
            {
                richTextBox1.AppendText(txt);
            }));
        }
        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetDefaultPrinter(string Printer);
        public FrmNurseAdd2(IvfControl ic, MainMenu m, FrmNurseView frmNurseView, String pttid, String vn, String flagedit, String pid)
        {
            InitializeComponent();
            menu = m;
            this.ic = ic;
            this.vn = vn;
            this.pttId = pttid;
            this.pid = pid;
            this.flagedit = flagedit;
            this.frmNurView = frmNurseView;
            initConfig();
        }
        private void initConfig()
        {
            pageLoad = true;
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);

            //C1ThemeController.ApplicationTheme = ic.iniC.themeApplication;
            theme1.Theme = ic.iniC.themeApplication;
            theme1.SetTheme(sB, "BeigeOne");
            theme1.SetTheme(tabOrder, "MacSilver");     //spPatient
            theme1.SetTheme(sC, theme1.Theme);

            sB1.Text = "";
            bg = txtHn.BackColor;
            fc = txtHn.ForeColor;
            ff = txtHn.Font;

            vsOld = new VisitOld();
            vs = new Visit();
            ptt = new Patient();
            pttOld = new PatientOld();
            pttO = new PatientOld();
            pApm = new PatientAppointment();
            pApmO = new AppointmentOld();
            eggs = new EggSti();
            pmh = new PatientMedicalHistory();

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            lgrfPkg = new List<C1FlexGrid>();

            imgCorr = Resources.red_checkmark_png_16;
            imgTran = Resources.red_checkmark_png_51;

            ic.setCboLangSticker(cboLangSticker);

            ic.ivfDB.bspDB.setCboBsp(cboApmBsp, "");
            ic.ivfDB.opkgstDB.setCboPackageSellThru(cboSellThruID, "");
            ic.ivfDB.dtrOldDB.setCboDoctor(cboDoctor, "");
            ic.ivfDB.dtrOldDB.setCboDoctor(cboEggStiDtr, "");
            ic.ivfDB.pttDB.setCboAllergy(cboAllergyDesc);
            ic.ivfDB.pApmDB.setCboDoctorAnes(cboApmDtrAnes);
            ic.ivfDB.dtrOldDB.setCboDoctor(cboApmDtr,"");
            ic.setCboApmTime(cboApmTimepApm);
            ic.setCboApmTime(cboApmTvsTime);
            ic.setCboApmTime(cboApmOPUTime);
            ic.setCboApmTime(cboApmETTime);
            ic.setCboApmTime(cboApmFETTime);
            ic.setCboApmTime(cboApmOPUTimeDonor);
            ic.setCboApmTime(cboApmTvsTimeDonor);
            ic.ivfDB.eggsDB.setCboAddLab(cboEggStiAmh);
            ic.ivfDB.eggsDB.setCboTypingOther(cboEggStiOther);
            ic.ivfDB.eggsDB.setCboBhcgTest(cboEggStiBhcg);
            
            txtApmDatepApm.Value = System.DateTime.Now.Year.ToString() + "-" + System.DateTime.Now.ToString("MM-dd");

            tabOrder.Click += TabOrder_Click;
            btnPkgOrder.Click += BtnPkgOrder_Click;
            btnRxSetOrder.Click += BtnRxSetOrder_Click;
            btnFinish.Click += BtnFinish_Click;
            cboLangSticker.SelectedIndexChanged += CboLangSticker_SelectedIndexChanged;
            btnNoteAdd.Click += BtnNoteAdd_Click;
            tlpPatient.Resize += TlpPatient_Resize;
            btnSendDtr.Click += BtnSendDtr_Click;
            chkChronic.MouseHover += ChkChronic_MouseHover;
            chkDenyAllergy.CheckedChanged += ChkDenyAllergy_CheckedChanged;
            btnApmSave.Click += BtnApmSave_Click;
            txtApmDatepApm.ValueChanged += TxtApmDatepApm_ValueChanged;
            chkApmTvs.CheckedChanged += ChkApmTvs_CheckedChanged;
            chkApmOpu.CheckedChanged += ChkApmOpu_CheckedChanged;
            chkApmFet.CheckedChanged += ChkApmFet_CheckedChanged;
            chkApmEt.CheckedChanged += ChkApmEt_CheckedChanged;
            chkApmOther.CheckedChanged += ChkApmOther_CheckedChanged;
            chkApmTvsDonor.CheckedChanged += ChkApmTvsDonor_CheckedChanged;
            chkApmOpuDonor.CheckedChanged += ChkApmOpuDonor_CheckedChanged;
            btnApmPrint.Click += BtnApmPrint_Click;
            btnGenEggSti.Click += BtnGenEggSti_Click;
            btnEggStiPrint.Click += BtnEggStiPrint_Click;
            btnEggStiSave.Click += BtnEggStiSave_Click;
            FontBoldButton.Click += FontBoldButton_Click;
            FontItalicButton.Click += FontItalicButton_Click;
            FontUnderlineButton.Click += FontUnderlineButton_Click;
            FontStrikeoutButton.Click += FontStrikeoutButton_Click;
            FontColorPicker.Click += FontColorPicker_Click;
            BackColorPicker.Click += BackColorPicker_Click;
            ParagraphAlignLeftButton.Click += ParagraphAlignLeftButton_Click;
            ParagraphAlignCenterButton.Click += ParagraphAlignCenterButton_Click;
            ParagraphAlignRightButton.Click += ParagraphAlignRightButton_Click;
            DecreaseIndentButton.Click += DecreaseIndentButton_Click;
            IncreaseIndentButton.Click += IncreaseIndentButton_Click;
            FontSizeComboBox.ChangeCommitted += FontSizeComboBox_ChangeCommitted;
            FontFaceComboBox.ChangeCommitted += FontFaceComboBox_ChangeCommitted;
            CutButton.Click += CutButton_Click;
            CopyButton.Click += CopyButton_Click;
            FormatPainterButton.Click += FormatPainterButton_Click;
            PasteSplitButton.Click += PasteSplitButton_Click;
            SaveDocumentButton.Click += SaveDocumentButton_Click;
            UndoButton.Click += UndoButton_Click;
            RedoButton.Click += RedoButton_Click;
            btnApmVoid.Click += BtnApmVoid_Click;
            btnSavePmh.Click += BtnSavePmh_Click;
            btnPrintPmh.Click += BtnPrintPmh_Click;
            c1Calendar1.Click += C1Calendar1_Click;
            rbPgPrint.Click += RbPgPrint_Click;
            btnPrintHormone.Click += BtnPrintHormone_Click;
            btnPrintInfectious.Click += BtnPrintInfectious_Click;
            btnPrnLabReq.Click += BtnPrnLabReq_Click;
            btnLabReq.Click += BtnLabReq_Click;

            chkPmhMarried.CheckedChanged += ChkPmhMarried_CheckedChanged;
            chkPmhConOther.CheckedChanged += ChkPmhConOther_CheckedChanged;
            chkPmhDrugYes.CheckedChanged += ChkPmhDrugYes_CheckedChanged;
            chkPmhPastOther.CheckedChanged += ChkPmhPastOther_CheckedChanged;
            chkPmhSubsYes.CheckedChanged += ChkPmhSubsYes_CheckedChanged;
            chkPmhSurgYes.CheckedChanged += ChkPmhSurgYes_CheckedChanged;
            chkPmhTypeSec.CheckedChanged += ChkPmhTypeSec_CheckedChanged;
            chkPmhMenIrr.CheckedChanged += ChkPmhMenIrr_CheckedChanged;
            chkPmhMenLmp.CheckedChanged += ChkPmhMenLmp_CheckedChanged;
            chkPmhProvYes.CheckedChanged += ChkPmhProvYes_CheckedChanged;
            chkPmhPapsYes.CheckedChanged += ChkPmhPapsYes_CheckedChanged;
            chkPmhPttMaleDrugYes.CheckedChanged += ChkPmhPttMaleDrugYes_CheckedChanged;
            chkPmhPttMalePastOther.CheckedChanged += ChkPmhPttMalePastOther_CheckedChanged;
            chkPmhPttMaleSubsYes.CheckedChanged += ChkPmhPttMaleSubsYes_CheckedChanged;
            chkPmlPttMaleSmokingYes.CheckedChanged += ChkPmlPttMaleSmokingYes_CheckedChanged;
            chkPmlPttMaleDrinkingYes.CheckedChanged += ChkPmlPttMaleDrinkingYes_CheckedChanged;
            chkPmlPttMaleDrugYes.CheckedChanged += ChkPmlPttMaleDrugYes_CheckedChanged;
            chkPmlPttMaleSurgiYes.CheckedChanged += ChkPmlPttMaleSurgiYes_CheckedChanged;
            chkPmlPttMaleTreatYes.CheckedChanged += ChkPmlPttMaleTreatYes_CheckedChanged;
            cboEggStiId.SelectedIndexChanged += CboEggStiId_SelectedIndexChanged;
            btnEggsNew.Click += BtnEggsNew_Click;
            tC.SelectedIndexChanged += TC_SelectedIndexChanged;
            tCHistory.DoubleClick += TCHistory_DoubleClick;
            
            cboLabVs.SelectedIndexChanged += CboLabVs_SelectedIndexChanged;
            this.Disposed += FrmNurseAdd2_Disposed;

            setControl(vn);
            ChkDenyAllergy_CheckedChanged(null, null);
            //btnNew.Click += BtnNew_Click;
            //txtSearch.KeyUp += TxtSearch_KeyUp;
            initGrfBloodLab();
            setGrfBloodLab();
            initGrfSpermLab();
            setGrfSperm();
            initGrfEmbryoLab();
            setGrfEmbryo();
            initGrfGeneticLab();
            initGrfSpecialLab();
            initGrfRx();
            initGrfRxSet();
            initGrfOrder();
            initGrfPackage();
            initGrfPackageD();
            initGrfRxSetD();
            initGrfpApmAll();
            initGrfpApmDayAll();
            initGrfpApmVisit();
            setGrfGenetic();
            setGrfSpecial();
            setGrfRx();
            setGrfRxSet();
            setGrfpackage();
            setGrfOrder(txtVn.Text);
            initGrfNote();
            setGrfNote();
            //initGrfAdm();
            initGrfEggSti();
            //setGrfpApmAll();
            setGrfpApmVisit();
            setControlEggSti();
            setControlPmh();
            initGrfHistory();
            setGrfHistory();
            initGrfHistoryDrug();
            setGrfHistoryDrug();
            initGrfImg();
            setGrfImg();
            initGrfPg();
            setGrfPg();
            initGrfItminPgk();
            setGrfItminPkg();

            ChkPmhMarried_CheckedChanged(null, null);
            ChkPmhConOther_CheckedChanged(null, null);
            ChkPmhDrugYes_CheckedChanged(null, null);
            ChkPmhPastOther_CheckedChanged(null, null);
            ChkPmhSubsYes_CheckedChanged(null, null);
            ChkPmhSurgYes_CheckedChanged(null, null);
            ChkPmhTypeSec_CheckedChanged(null, null);
            ChkPmhMenIrr_CheckedChanged(null, null);
            ChkPmhMenLmp_CheckedChanged(null, null);
            ChkPmhProvYes_CheckedChanged(null, null);
            ChkPmhPapsYes_CheckedChanged(null, null);
            ChkPmhPttMaleDrugYes_CheckedChanged(null, null);
            ChkPmhPttMalePastOther_CheckedChanged(null, null);
            ChkPmhPttMaleSubsYes_CheckedChanged(null, null);
            ChkPmlPttMaleSmokingYes_CheckedChanged(null, null);
            ChkPmlPttMaleDrinkingYes_CheckedChanged(null, null);
            ChkPmlPttMaleDrugYes_CheckedChanged(null, null);
            ChkPmlPttMaleSurgiYes_CheckedChanged(null, null);
            ChkPmlPttMaleTreatYes_CheckedChanged(null, null);
            initGrfImgOutLab();
            setGrfImgOutLab();
            initGrfLab();
            setGrfLab();
            initPnLabFormA();
            setGrfLabFormA();
            if (flagedit.Equals("view"))
            {
                btnPkgOrder.Enabled = false;
            }
            picPtt.SizeMode = PictureBoxSizeMode.StretchImage;
            //initGrfPtt();
            //setGrfPtt("");
            initProgressNote();
            pageLoad = false;
        }
        private void initPnLabFormA()
        {
            C1SplitterPanel scFormAAdd = new C1.Win.C1SplitContainer.C1SplitterPanel();
            C1SplitterPanel scFormAView = new C1.Win.C1SplitContainer.C1SplitterPanel();
            C1SplitContainer sC = new C1.Win.C1SplitContainer.C1SplitContainer();
            Panel pnFormAView, pnFormAAdd;
            pnFormAView = new Panel();
            pnFormAView.Dock = DockStyle.Fill;
            pnFormAView.Name = "pnFormAView";
            pnFormAAdd = new Panel();
            pnFormAAdd.Dock = DockStyle.Fill;
            pnFormAAdd.Name = "pnFormAAdd";

            sC.SuspendLayout();
            scFormAAdd.SuspendLayout();
            scFormAView.SuspendLayout();
            pnFormAView.SuspendLayout();
            pnFormAAdd.SuspendLayout();
            pnLabFormA.SuspendLayout();

            scFormAAdd.Collapsible = true;
            scFormAAdd.Dock = C1.Win.C1SplitContainer.PanelDockStyle.Right;
            scFormAAdd.Location = new System.Drawing.Point(0, 21);
            scFormAAdd.Name = "scFormAAdd";
            scFormAAdd.Controls.Add(pnFormAAdd);
            scFormAView.Collapsible = true;
            scFormAView.Dock = C1.Win.C1SplitContainer.PanelDockStyle.Left;
            scFormAView.Location = new System.Drawing.Point(0, 21);
            scFormAView.Name = "scFormAView";
            scFormAView.Controls.Add(pnFormAView);
            sC.AutoSizeElement = C1.Framework.AutoSizeElement.Both;
            sC.Name = "sC";
            sC.Dock = System.Windows.Forms.DockStyle.Fill;
            sC.Panels.Add(scFormAAdd);
            sC.Panels.Add(scFormAView);
            
            grfFormAView = new C1FlexGrid();
            grfFormAView.Font = fEdit;
            grfFormAView.Dock = System.Windows.Forms.DockStyle.Fill;
            grfFormAView.Location = new System.Drawing.Point(0, 0);
            grfFormAView.Rows.Count = 1;
            grfFormAView.Cols.Count = 4;
            grfFormAView.Cols[colFormADate].Caption = "Date";
            grfFormAView.Cols[colFormACode].Caption = "FormA Code";
            
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("เพิ่ม ข้อมูล LAB Form A", new EventHandler(ContextMenu_grfformaview_add));
            grfFormAView.ContextMenu = menuGw;
            grfFormAView.DoubleClick += GrfFormAView_DoubleClick;
            theme1.SetTheme(grfFormAView, "RainerOrange");

            FrmLabFormA frm = new FrmLabFormA(ic, "", txtPttId.Text, txtVsId.Text, txtVn.Text,"", ic.theme);
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.AutoScroll = true;
            frm.Parent = pnLabFormA;
            frm.Show();
            pnLabFormA.Controls.Add(sC);
            pnFormAView.Controls.Add(grfFormAView);
            pnFormAAdd.Controls.Add(frm);

            sC.HeaderHeight = 20;
            scFormAAdd.SizeRatio = 80;

            scFormAView.ResumeLayout(false);
            scFormAAdd.ResumeLayout(false);
            sC.ResumeLayout(false);
            pnFormAAdd.ResumeLayout(false);
            pnFormAView.ResumeLayout(false);
            pnLabFormA.ResumeLayout(false);
            pnFormAAdd.PerformLayout();
            pnFormAView.PerformLayout();
            pnLabFormA.PerformLayout();
            scFormAView.PerformLayout();
            scFormAAdd.PerformLayout();
            sC.PerformLayout();
        }
        private void ContextMenu_grfformaview_add(object sender, System.EventArgs e)
        {

        }
        private void GrfFormAView_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

        }
        private void setGrfLabFormA()
        {
            //grfDept.Rows.Count = 7;
            //grfEmbryo.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.lFormaDB.selectReportByHn(txtHn.Text.Trim());
            grfFormAView.Rows.Count = 1;
            grfFormAView.Rows.Count = dt.Rows.Count + 1;
            //grfEmbryo.Rows.Count = dt.Rows.Count + 1;
            //grfEmbryo.DataSource = dt;
            grfFormAView.Cols.Count = 4;

            grfFormAView.Cols[colFormACode].Width = 100;
            grfFormAView.Cols[colFormADate].Width = 100;

            grfFormAView.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfFormAView.Cols[colFormACode].Caption = "FormA Code";
            grfFormAView.Cols[colFormADate].Caption = "Date";
            
            int i = 0;
            decimal aaa = 0;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    i++;
                    
                    grfFormAView[i, colFormAId] = row[ic.ivfDB.lFormaDB.lformA.form_a_id].ToString();
                    grfFormAView[i, colFormACode] = row[ic.ivfDB.lFormaDB.lformA.form_a_code].ToString();
                    grfFormAView[i, colFormADate] = ic.datetoShow(row[ic.ivfDB.lFormaDB.lformA.form_a_date].ToString());
                }
                catch (Exception ex)
                {
                    String err = "";
                }

            }
            CellNoteManager mgr = new CellNoteManager(grfFormAView);
            grfFormAView.Cols[colFormAId].Visible = false;
            //grfEmbryo.Cols[colBlInclude].Visible = false;
            //grfEmbryo.Cols[colBlPrice].Visible = false;

            grfFormAView.Cols[colFormADate].AllowEditing = false;
            grfFormAView.Cols[colFormACode].AllowEditing = false;
            
            theme1.SetTheme(grfFormAView, ic.theme);

        }
        private void FrmNurseAdd2_Disposed(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            frmNurView.Dispose();
        }

        private void BtnLabReq_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.labrequestremark = "";
            //FrmNurseLabNote frm = new FrmNurseLabNote(ic);
            //frm.ShowDialog(this);
            Patient ptt1 = new Patient();
            ptt1 = ic.ivfDB.pttDB.selectByPk1(txtPttId.Text);
            foreach(Row row in grfLab.Rows)
            {
                if (row[colRsLabId] == null) continue;
                if (row[colRsLabStatusShow] == null) continue;
                if (row[colRsLabStatusShow].ToString().Equals("ส่ง request"))
                {
                    try
                    {
                        stt.Show("<p><b>ส่ง request</b></p> <br>" + row[colRslabName].ToString(), txtName_2, 10, 20, 5);//<p><b>สวัสดี</b></p>
                                                                                                                                     //System.Threading.Thread.Sleep(1000);
                                                                                                                                     //Application.DoEvents();
                        String dtrid = "", errfor = "", lgid = "", reqid = "", itmid = "", jlabid = "", remark="";
                        LabRequest lbReq = new LabRequest();
                        dtrid = cboDoctor.SelectedItem == null ? "" : ((ComboBoxItem)cboDoctor.SelectedItem).Value;
                        jlabid = row[colRslabjoblabid] != null ? row[colRslabjoblabid].ToString() : "";
                        remark = row[colRsRemarkReq] != null ? row[colRsRemarkReq].ToString() : "";
                        OldJobLabDetail oldjobd = new OldJobLabDetail();
                        oldjobd = ic.ivfDB.oJlabdDB.selectByPk1(jlabid);
                        if (ptt.f_sex_id.Equals("1"))
                        {
                            
                            //lbReq = ic.ivfDB.setLabRequest("", txtVnOld.Text, dtrid, remark, "", ic.datetoDB(txtDob.Text), oldjobd.ID, oldjobd.LID, txtHn.Text, txtPttNameE.Text, "", "", "", txtVsId.Text);
                            lbReq = ic.ivfDB.setLabRequest("", txtVnOld.Text, dtrid, remark, "", ptt1.patient_birthday, oldjobd.ID, oldjobd.LID, txtHn.Text, txtPttNameE.Text, "", "", "", txtVsId.Text);
                        }
                        else if (ptt.f_sex_id.Equals("2"))
                        {
                            //lbReq = ic.ivfDB.setLabRequest(txtPttNameE.Text, txtVnOld.Text, dtrid, remark, txtHn.Text, ic.datetoDB(txtDob.Text), oldjobd.ID, oldjobd.LID, "", "", "", "", "", txtVsId.Text);
                            lbReq = ic.ivfDB.setLabRequest(txtPttNameE.Text, txtVnOld.Text, dtrid, remark, txtHn.Text, ptt1.patient_birthday, oldjobd.ID, oldjobd.LID, "", "", "", "", "", txtVsId.Text);
                        }
                        long chk = 0;
                        String re = ic.ivfDB.lbReqDB.insertLabRequest(lbReq, ic.userId);
                        if (long.TryParse(re, out chk))
                        {
                            String re1 = ic.ivfDB.oJlabdDB.updateReqId(re, oldjobd.ID);
                            if (long.TryParse(re1, out chk))
                            {
                                //setGrfLab();
                            }
                        }
                    }
                    catch(Exception ex)
                    {

                    }
                }
            }
            setGrfLab();
        }

        private void BtnPrnLabReq_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //PrinterSettings settings = new PrinterSettings();
            //printerOld = settings.PrinterName;
            SetDefaultPrinter(ic.iniC.printerAppointment);      //A5
            FrmReport frm = new FrmReport(ic);
            DataTable dt = new DataTable();
            String reqdate = "", stf = "", stfname="";
            dt = ic.ivfDB.lbReqDB.selectByNurseVn(cboLabVs.Text);
            if (dt.Rows.Count > 0)
            {
                reqdate = ic.datetoShow(dt.Rows[0][ic.ivfDB.lbReqDB.lbReq.req_date].ToString()) +""+ dt.Rows[0][ic.ivfDB.lbReqDB.lbReq.req_time].ToString();
                stf = dt.Rows[0][ic.ivfDB.lbReqDB.lbReq.user_create].ToString();
                String[] stf1 = stf.Split('@');
                if (stf1.Length > 1)
                {
                    stfname = ic.ivfDB.stfDB.getStaffNameBylStf(stf1[0]);
                }
            }
            frm.setLabBloodRequest(dt, txtHn.Text, txtPttNameE.Text, txtDob.Text, txtSex.Text, vs.visit_begin_visit_time, reqdate, cboDoctor.Text, stfname);
            frm.ShowDialog(this);
        }

        private void BtnPrintInfectious_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            SetDefaultPrinter(ic.iniC.printerAppointment);      //A5



            ic.setRptLabBloodInfectious(txtVsId.Text, this);



            //FrmReport frm = new FrmReport(ic);
            //DataTable dt = new DataTable();
            //dt = ic.ivfDB.lbresDB.selectLabBloodByVsIdInfectious(txtVsId.Text);
            //dt = ic.ivfDB.lbresDB.selectLabBloodByVsIdInfectious(txtVsId.Text);
            //String date1 = "", collectdate = "", receivedate = "", reportdate = "", approvedate = "", stfreport = "", stfapprove = "";
            //foreach (DataRow row in dt.Rows)
            //{
            //    collectdate = row[ic.ivfDB.lbresDB.lbRes.req_date_time].ToString();
            //    receivedate = row[ic.ivfDB.lbresDB.lbRes.date_time_receive].ToString();
            //    reportdate = row[ic.ivfDB.lbresDB.lbRes.date_time_result].ToString();
            //    approvedate = row[ic.ivfDB.lbresDB.lbRes.date_time_approve].ToString();
            //    stfapprove = row[ic.ivfDB.lbresDB.lbRes.staff_id_approve] != null ? row[ic.ivfDB.lbresDB.lbRes.staff_id_approve].ToString() : "";
            //    stfreport = row[ic.ivfDB.lbresDB.lbRes.staff_id_result].ToString();
            //}
            //reportdate = ic.datetimetoShow(reportdate);
            //approvedate = ic.datetimetoShow(approvedate);
            //stfapprove = ic.ivfDB.stfDB.getIdByName(stfapprove);
            //stfreport = ic.ivfDB.stfDB.getIdByName(stfreport);
            //frm.setLabBloodReportInfectious(dt, txtHn.Text, txtPttNameE.Text, txtDob.Text, txtSex.Text, stfreport, stfapprove, reportdate, approvedate, collectdate, receivedate);
            //frm.ShowDialog(this);
        }

        private void BtnPrintHormone_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            SetDefaultPrinter(ic.iniC.printerAppointment);      //A5
            String date1 = "", reportdate="", approvedate="";
            FrmReport frm = new FrmReport(ic);
            DataTable dt = new DataTable();
            dt = ic.ivfDB.lbresDB.selectLabBloodByVsIdHormone(txtVsId.Text);
            String amh = "", collectdate = "", receivedate = "", stfreport="", stfapprove="";
            foreach (DataRow row in dt.Rows)
            {
                collectdate = row[ic.ivfDB.lbresDB.lbRes.req_date_time].ToString();
                receivedate = row[ic.ivfDB.lbresDB.lbRes.date_time_receive].ToString();
                reportdate = row[ic.ivfDB.lbresDB.lbRes.date_time_result].ToString();
                approvedate = row[ic.ivfDB.lbresDB.lbRes.date_time_approve].ToString();
                stfapprove = row[ic.ivfDB.lbresDB.lbRes.staff_id_approve].ToString();
                stfreport = row[ic.ivfDB.lbresDB.lbRes.staff_id_result].ToString();
                if (row["LID"].ToString().Equals("10"))
                {
                    amh = "1";
                }
                else
                {
                    amh = "0";
                }
            }
            reportdate = ic.datetimetoShow(reportdate);
            approvedate = ic.datetimetoShow(approvedate);
            stfapprove = ic.ivfDB.stfDB.getIdByName(stfapprove);
            stfreport = ic.ivfDB.stfDB.getIdByName(stfreport);
            //LabResult lbRes = new LabResult();
            //lbRes = ic.ivfDB.lbresDB.selectBy(resId);
            if (ptt.f_sex_id.Equals("2") && (!ptt.patient_hn_1.Equals("") && !ptt.patient_hn_2.Equals("")))     // เป็น female และ เป็น donor  ไม่ต้องพิมพ์ หัว บริษัท
            {

                frm.setLabBloodReportHormone(dt, txtHn.Text, txtPttNameE.Text, txtDob.Text, txtSex.Text, stfreport, stfapprove, reportdate, approvedate, "", amh, collectdate, receivedate);
            }
            else
            {
                frm.setLabBloodReportHormone(dt, txtHn.Text, txtPttNameE.Text, txtDob.Text, txtSex.Text, stfreport, stfapprove, reportdate, approvedate, "", amh, collectdate, receivedate);
            }

            frm.ShowDialog(this);
        }

        private void CboLabVs_SelectedIndexChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setGrfLab();
        }
                
        
        private void RbPgPrint_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            PrinterSettings settings = new PrinterSettings();
            //C1DocumentSource cPdf = new C1DocumentSource();
            try
            {
                if (File.Exists(filePathNamePg))
                {
                    SetDefaultPrinter(ic.iniC.printerA4);
                    if (!Directory.Exists("report"))
                    {
                        Directory.CreateDirectory("report");
                    }
                    String filename = "", datetick="";
                    datetick = DateTime.Now.Ticks.ToString();
                    filename = "report\\"+ filePathNamePg + "_" + datetick + ".pdf";

                    var report = new C1.C1Report.C1Report();
                    report.Render();
                    var rtfText = File.ReadAllText(filePathNamePg);
                    var printDoc = new C1PrintDocument();
                    printDoc = report.C1Document;
                    printDoc.AllowNonReflowableDocs = true;
                    printDoc.TagOpenParen = "[@@";
                    printDoc.TagCloseParen = "@@]";
                    printDoc.StartDoc();

                    //add rtf containing img to renderer
                    var obj = new RenderRichText(printDoc);
                    obj.Rtf = rtfText;

                    //Add renderer to body
                    printDoc.Body.Children.Add(obj);

                    //ask to render
                    printDoc.RenderBlockRichText(obj.Rtf);
                    printDoc.EndDoc();
                    printDoc.Export(filename, false);

                    FrmPrintPreview frm = new FrmPrintPreview(ic, filename);
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(this);
                }
            }
            catch (PdfPasswordException)
            {
                string password = PasswordForm.DoEnterPassword(filePathNamePg);
                if (password == null)
                    return;
                cPdf.Credential.Password = password;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void C1Calendar1_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            DateTime[] aaa = c1Calendar1.SelectedDates;
            if (aaa.Length > 0)
            {
                DateTime date = aaa[0];
                setGrfpApmAll(date.Year+"-"+ date.ToString("MM-dd"));
            }
        }

        private void TCHistory_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (tCHistory.SelectedTab == tabHistoryScan)
            {
                grfImg.AutoSizeCols();
                grfImg.AutoSizeRows();
            }
        }

        private void TC_SelectedIndexChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if(tC.SelectedTab== tabHistory)
            {
                tCHistory.SelectedTab = tabHistoryDrug;
            }
            else if (tC.SelectedTab == tabLab)
            {
                setGrfLab();
            }
        }

        private void BtnEggsNew_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            cboEggStiId.Text = "";
            txtEggStiId.Value = "";
            txtEggStiVisitLMP.Value = "";
            
            txtEggStiDay.Value = "";
            txtEggStiOPUDate.Value = "";
            txtEggStiOPUTime.Value = "";
            txtEggStiEmbryoTranferDate.Value = "";

            chkAbnormal.Checked = false;
            chkTyping.Checked = false;
            chkEggStiOther.Checked = false;
            chkEggStiInfection.Checked = false;
            chkAmh.Checked =  false;
            txtAbnormal1.Value = "";
            txtAbnormal2.Value = "";
            cboEggStiOther.Text = "";
            cboEggStiBhcg.Text = "";
            cboEggStiAmh.Text = "";
            txtEggStiG.Value = "";
            txtEggStiP.Value = "";
            txtEggStiA.Value = "";
            cboEggStiDtr.Text = "";
            grfEggsd.Clear();
            grfEggsd.Rows.Count = 1;
            grfEggsd.Cols.Count = 16;

            grfEggsd.Cols[colEggDay].Caption = "day";
            grfEggsd.Cols[colEggDate].Caption = "date";
            grfEggsd.Cols[colEggE2].Caption = "E2";
            grfEggsd.Cols[colEggLH].Caption = "LH";
            grfEggsd.Cols[colEggFSH].Caption = "FSH";
            grfEggsd.Cols[colEggProlactin].Caption = "Prolactin";
            grfEggsd.Cols[colEggRt1].Caption = "Rt ovary";
            grfEggsd.Cols[colEggRt2].Caption = "Rt ovary";
            grfEggsd.Cols[colEggLt1].Caption = "Lt ovary";
            grfEggsd.Cols[colEggLt2].Caption = "Lt ovary";
            grfEggsd.Cols[colEggEndo].Caption = "Endo";
            grfEggsd.Cols[colEggMedi].Caption = "Medication";
            grfEggsd.Cols[colEggMedi2].Caption = "Medication2";
        }

        private void CboEggStiId_SelectedIndexChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String id = cboEggStiId.SelectedItem == null ? "" : ((ComboBoxItem)cboEggStiId.SelectedItem).Value;
            if (id.Length == 0) return;
            txtEggStiId.Value = id;
            setControlEggSti();
        }

        private void BtnPrintPmh_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmReport frm = new FrmReport(ic);
            DataTable dt = new DataTable();
            dt = ic.ivfDB.pmhDB.selectByPttId1(txtPttId.Text);
            
            String date1 = "";

            frm.setPmhReport(dt, txtHn.Text, txtPttNameE.Text, txtPmhPttDob.Text, cboOccup.Text, txtPmhPttMaleName.Text, txtPmhPttMaleDob.Text,"", chkPmhSingle.Checked ? "1" : "", txtPmhMarriedYear.Text);
            frm.ShowDialog(this);
        }

        private void ChkPmlPttMaleTreatYes_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (chkPmlPttMaleTreatYes.Checked)
            {
                txtPmlPttMaleTreat.Enabled = true;
            }
            else
            {
                txtPmlPttMaleTreat.Enabled = false;
            }
        }

        private void ChkPmlPttMaleSurgiYes_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (chkPmlPttMaleSurgiYes.Checked)
            {
                txtPmlPttMaleSurgi.Enabled = true;
            }
            else
            {
                txtPmlPttMaleSurgi.Enabled = false;
            }
        }

        private void ChkPmlPttMaleDrugYes_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (chkPmlPttMaleDrugYes.Checked)
            {
                txtPmlPttMaleDrug.Enabled = true;
            }
            else
            {
                txtPmlPttMaleDrug.Enabled = false;
            }
        }

        private void ChkPmlPttMaleDrinkingYes_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (chkPmlPttMaleDrinkingYes.Checked)
            {
                txtPmlPttMaleDrinking.Enabled = true;
            }
            else
            {
                txtPmlPttMaleDrinking.Enabled = false;
            }
        }

        private void ChkPmlPttMaleSmokingYes_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (chkPmlPttMaleSmokingYes.Checked)
            {
                txtPmlPttMaleSmoking.Enabled = true;
            }
            else
            {
                txtPmlPttMaleSmoking.Enabled = false;
            }
        }

        private void ChkPmhPttMaleSubsYes_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (chkPmhPttMaleSubsYes.Checked)
            {
                txtPmhPttMaleSubs.Enabled = true;
            }
            else
            {
                txtPmhPttMaleSubs.Enabled = false;
            }
        }

        private void ChkPmhPttMalePastOther_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (chkPmhPttMalePastOther.Checked)
            {
                txtPmhPttMalePastOther.Enabled = true;
            }
            else
            {
                txtPmhPttMalePastOther.Enabled = false;
            }
        }

        private void ChkPmhPttMaleDrugYes_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (chkPmhPttMaleDrugYes.Checked)
            {
                txtPmhPttMaleDrug.Enabled = true;
            }
            else
            {
                txtPmhPttMaleDrug.Enabled = false;
            }
        }

        private void ChkPmhPapsYes_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (chkPmhPapsYes.Checked)
            {
                txtPmhPaps.Enabled = true;
            }
            else
            {
                txtPmhPaps.Enabled = false;
            }
        }

        private void ChkPmhProvYes_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (chkPmhProvYes.Checked)
            {
                txtPmhProv.Enabled = true;
            }
            else
            {
                txtPmhProv.Enabled = false;
            }
        }

        private void ChkPmhMenLmp_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (chkPmhMenLmp.Checked)
            {
                txtPmhMenLmp.Enabled = true;
            }
            else
            {
                txtPmhMenLmp.Enabled = false;
            }
        }

        private void ChkPmhMenIrr_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (chkPmhMenIrr.Checked)
            {
                txtPmhMenDay.Enabled = true;
                txtPmhMenInter.Enabled = true;
                txtPmhMenAmt.Enabled = true;
            }
            else
            {
                txtPmhMenDay.Enabled = false;
                txtPmhMenInter.Enabled = false;
                txtPmhMenAmt.Enabled = false;
            }
        }

        private void ChkPmhTypeSec_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (chkPmhTypeSec.Checked)
            {
                txtPmhType.Enabled = true;
            }
            else
            {
                txtPmhType.Enabled = false;
            }
        }

        private void ChkPmhSurgYes_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (chkPmhSurgYes.Checked)
            {
                txtPmhSurg.Enabled = true;
            }
            else
            {
                txtPmhSurg.Enabled = false;
            }
        }

        private void ChkPmhSubsYes_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (chkPmhSubsYes.Checked)
            {
                txtPmhSubs.Enabled = true;
            }
            else
            {
                txtPmhSubs.Enabled = false;
            }
        }

        private void ChkPmhPastOther_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (chkPmhPastOther.Checked)
            {
                txtPmhPastOther.Enabled = true;
            }
            else
            {
                txtPmhPastOther.Enabled = false;
            }
        }

        private void ChkPmhDrugYes_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (chkPmhDrugYes.Checked)
            {
                txtPmhDrug.Enabled = true;
            }
            else
            {
                txtPmhDrug.Enabled = false;
            }
        }

        private void ChkPmhConOther_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (chkPmhConOther.Checked)
            {
                txtPmhConOther.Enabled = true;
            }
            else
            {
                txtPmhConOther.Enabled = false;
            }
        }

        private void ChkPmhMarried_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (chkPmhMarried.Checked)
            {
                txtPmhMarriedYear.Enabled = true;
            }
            else
            {
                txtPmhMarriedYear.Enabled = false;
            }
        }

        private void BtnSavePmh_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.cStf.staff_id = "";
            FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            frm.ShowDialog(this);
            if (!ic.cStf.staff_id.Equals(""))
            {
                txtUserReq.Value = ic.cStf.staff_fname_t + " " + ic.cStf.staff_lname_t;
                txtStfConfirmID.Value = ic.cStf.staff_id;
                btnSave.Text = "Confirm";
                btnSave.Image = Resources.Add_ticket_24;
                stt.Show("<p><b>สวัสดี</b></p>คุณ " + ic.cStf.staff_fname_t + " " + ic.cStf.staff_lname_t + "<br> กรุณายินยันการ confirm อีกครั้ง", txtApmRemark);
                btnSave.Focus();

                stt.Hide();
                String re = "";

                setPMh();
                re = ic.ivfDB.pmhDB.insertPatientMedicalHistory(pmh, txtStfConfirmID.Text);

                //txtID.Value = (!txtID.Text.Equals("") && re.Equals("1")) ? re : "";        //update
                long chk = 0;
                if (long.TryParse(re, out chk))
                {
                    btnSave.Text = "Save";
                    btnSave.Image = Resources.accept_database24;
                }
            }
            else
            {
                btnSave.Text = "Save";
                btnSave.Image = Resources.download_database24;
            }
        }

        private void initGrfLab()
        {
            grfLab = new C1FlexGrid();
            grfLab.Font = fEdit;
            grfLab.Dock = System.Windows.Forms.DockStyle.Fill;
            grfLab.Location = new System.Drawing.Point(0, 0);

            //FilterRowUnBound fr = new FilterRowUnBound(grfRx);

            grfLab.DoubleClick += GrfLab_DoubleClick;
            //grfRx.AfterFilter += GrfRx_AfterFilter;

            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //if (flagedit.Equals("edit"))
            //{
            //    menuGw.MenuItems.Add("สั่งการ", new EventHandler(ContextMenu_order_rx));
            //}
            ////menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_lab_Cancel));
            grfLab.ContextMenu = menuGw;
            pnLabVs.Controls.Add(grfLab);

            theme1.SetTheme(grfLab, "Office2010Black");

        }
        private void ContextMenu_lab_Cancel(object sender, System.EventArgs e)
        {
            String reqid = "", joblabid="", resid="", statusresult="";
            joblabid = grfLab[grfLab.Row, colRslabjoblabid] != null ? grfLab[grfLab.Row, colRslabjoblabid].ToString() : "";
            reqid = grfLab[grfLab.Row, colRsLabReqId] != null ? grfLab[grfLab.Row, colRsLabReqId].ToString() : "";
            resid = grfLab[grfLab.Row, colRsLabId] != null ? grfLab[grfLab.Row, colRsLabId].ToString() : "";
            
            ic.cStf.staff_id = "";
            FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            frm.ShowDialog(this);
            if (!ic.cStf.staff_id.Equals(""))
            {
                if (resid.Equals(""))       // lab ยังไม่ได้รับ  
                {
                    if (reqid.Equals(""))           //cancel  JobLabDetail
                    {
                        ic.ivfDB.oJlabdDB.deleteByPk(joblabid);
                    }
                    else
                    {
                        //ic.ivfDB.oJlabdDB.deleteByPk(joblabid);
                        ic.ivfDB.lbReqDB.VoidRequest(reqid, ic.cStf.staff_id);
                    }
                }
                else
                {       // lab ยังไม่ได้รับ     cancel lab_t_result, lab_t_request
                    LabRequest req = new LabRequest();
                    req = ic.ivfDB.lbReqDB.selectByPk1(reqid);
                    statusresult = grfLab[grfLab.Row, colRslabStatusResult] != null ? grfLab[grfLab.Row, colRslabStatusResult].ToString() : "";
                    if (!req.status_req.Equals("2"))
                    {
                        //ic.ivfDB.oJlabdDB.deleteByPk(joblabid);
                        ic.ivfDB.lbReqDB.VoidRequest(reqid, ic.cStf.staff_id);
                        ic.ivfDB.lbresDB.voidLabResult(resid, ic.cStf.staff_id);
                        setGrfLab();
                    }
                    else
                    {
                        MessageBox.Show("Lab Accept Request \n โทรแจ้งให้ทาง LAB ยกเลิกให้", "");
                    }
                }
            }
        }
        private void GrfLab_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if(grfLab.Col == colRsLabStatusShow)
            {
                if(grfLab[grfLab.Row, colRsLabStatusShow].ToString().Equals("ส่ง request"))
                {
                    stt.Show("<p><b>ส่ง request</b></p> <br>"+ grfLab[grfLab.Row, colRslabName].ToString(), txtName_2, 10,20,5);//<p><b>สวัสดี</b></p>
                    //System.Threading.Thread.Sleep(1000);
                    //Application.DoEvents();
                    String dtrid = "", errfor = "", lgid = "", reqid = "", itmid = "", jlabid="";
                    LabRequest lbReq = new LabRequest();
                    dtrid = cboDoctor.SelectedItem == null ? "" : ((ComboBoxItem)cboDoctor.SelectedItem).Value;
                    jlabid = grfLab[grfLab.Row, colRslabjoblabid] != null ? grfLab[grfLab.Row, colRslabjoblabid].ToString() : "";
                    OldJobLabDetail oldjobd = new OldJobLabDetail();
                    oldjobd = ic.ivfDB.oJlabdDB.selectByPk1(jlabid);
                    if (ptt.f_sex_id.Equals("1"))
                    {
                        lbReq = ic.ivfDB.setLabRequest("", txtVnOld.Text, dtrid, "", "", ic.datetoDB(txtDob.Text), oldjobd.ID, oldjobd.LID, txtHn.Text, txtPttNameE.Text, "", "", "", txtVsId.Text);
                    }
                    else if (ptt.f_sex_id.Equals("2"))
                    {
                        lbReq = ic.ivfDB.setLabRequest(txtPttNameE.Text, txtVnOld.Text, dtrid, "", txtHn.Text, ic.datetoDB(txtDob.Text), oldjobd.ID, oldjobd.LID, "", "", "", "", "", txtVsId.Text);
                    }
                    long chk = 0;
                    String re = ic.ivfDB.lbReqDB.insertLabRequest(lbReq, ic.userId);
                    if(long.TryParse(re, out chk))
                    {
                        String re1 = ic.ivfDB.oJlabdDB.updateReqId(re, oldjobd.ID);
                        if (long.TryParse(re1, out chk))
                        {
                            setGrfLab();
                        }
                    }
                }
            }
        }
        private void setGrfLab()
        {
            //grfLab.Rows.Count = 1;
            //if(grfLab !=null) grfLab.Rows.Count = 0;
            if (pageLoad) return;
            //grfLab.Clear();
            grfLab.DataSource = null;
            //grfLab.Rows.Count = 0;
            grfLab.Rows.Count = 1;
            grfLab.Cols.Count = 22;

            grfLab.Cols[colRslabName].Width = 200;
            grfLab.Cols[colRsLabStatus].Width = 80;
            
            grfLab.Cols[colRsMethod].Width = 100;
            grfLab.Cols[colRsResult].Width = 100;
            grfLab.Cols[colRsInterpret].Width = 150;
            grfLab.Cols[colRsUnit].Width = 100;
            grfLab.Cols[colRsNormal].Width = 100;
            grfLab.Cols[colRsRemark].Width = 200;
            grfLab.Cols[colRsReactive].Width = 150;
            grfLab.Cols[colRsLabReqdate].Width = 150;
            grfLab.Cols[colRsLabDatetimereceive].Width = 150;
            grfLab.Cols[colRsLabdatetimeresult].Width = 150;
            grfLab.Cols[colRslabdatetimeapprove].Width = 150;
            grfLab.Cols[colRsRemarkReq].Width = 120;

            grfLab.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfLab.Cols[colRslabName].Caption = "Lab Name";
            grfLab.Cols[colRsLabStatus].Caption = "Status";
            grfLab.Cols[colRsMethod].Caption = "Method";
            grfLab.Cols[colRsResult].Caption = "Result";
            grfLab.Cols[colRsInterpret].Caption = "Interpret";
            grfLab.Cols[colRsUnit].Caption = "Unit";
            grfLab.Cols[colRsNormal].Caption = "Normal";
            grfLab.Cols[colRsRemark].Caption = "Remark";
            grfLab.Cols[colRsReactive].Caption = "Reactive";
            grfLab.Cols[colRsLabReqdate].Caption = "request date";
            grfLab.Cols[colRsLabDatetimereceive].Caption = "receive date";
            grfLab.Cols[colRsLabdatetimeresult].Caption = "result date";
            grfLab.Cols[colRslabdatetimeapprove].Caption = "approve date";
            grfLab.Cols[colRsLabId].Caption = "result id";
            grfLab.Cols[colRsRemarkReq].Caption = "Remark request";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            Color colorred = ColorTranslator.FromHtml(ic.iniC.grfRowRed);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            DataTable dtlab = new DataTable();
            if (cboLabVs.Text.Equals(txtVn.Text))
            {
                dtlab = ic.ivfDB.oJlabdDB.selectByVNnoReq(cboLabVs.Text);
            }
            else
            {
                   
            }
            
            DataTable dt = new DataTable();
            dt = ic.ivfDB.lbReqDB.selectByNurseVn(cboLabVs.Text);
            int i = 0;
            Boolean chkSend = false;
            foreach(DataRow row in dtlab.Rows)
            {
                i++;
                //dtlab.Columns.Add("remark_req", typeof(String));
                Row row1 = grfLab.Rows.Add();
                row1[colRsLabId] = "";
                row1[colRsLabReqId] = "";
                row1[colRsLabStatusShow] = "ส่ง request";
                row1[colRslabName] = row["LName"].ToString();
                row1[colRslabjoblabid] = row["ID"];
                row1[colRslabjoblabreqid] = row["req_id"];
                //row1[colRsRemarkReq] = row["remark"];
                row1.StyleNew.BackColor = colorred;
                row1[0] = i;
                chkSend = true;
            }
            if (chkSend)
            {
                btnLabReq.Show();
            }
            else
            {
                btnLabReq.Hide();
            }
            foreach (DataRow row in dt.Rows)
            {
                i++;
                Row row1 = grfLab.Rows.Add();
                row1[colRsLabReqId] = row[ic.ivfDB.lbReqDB.lbReq.req_id].ToString();
                row1[colRslabName] = row["LName"].ToString();
                row1[colRsLabStatus] = row[ic.ivfDB.lbReqDB.lbReq.status_req].ToString();
                row1[colRsMethod] = ic.ivfDB.lbmDB.getNameById(row[ic.ivfDB.oLabiDB.labI.method_id].ToString());
                row1[colRsRemark] = row["remark_res"].ToString();
                row1[colRsResult] = row[ic.ivfDB.lbresDB.lbRes.result].ToString();
                row1[colRsInterpret] = row[ic.ivfDB.lbresDB.lbRes.interpret].ToString();
                row1[colRsUnit] = ic.ivfDB.lbuDB.getNameById(row[ic.ivfDB.oLabiDB.labI.lab_unit_id].ToString());
                row1[colRsReactive] = row[ic.ivfDB.lbresDB.lbRes.reactive_message].ToString();
                row1[colRsLabReqdate] = ic.datetoShow(row[ic.ivfDB.lbReqDB.lbReq.req_date].ToString()) + " " + ic.timetoShow(row[ic.ivfDB.lbReqDB.lbReq.req_time].ToString());
                row1[colRsLabDatetimereceive] = ic.datetimetoShow(row[ic.ivfDB.lbresDB.lbRes.date_time_receive].ToString());
                row1[colRsLabdatetimeresult] = ic.datetimetoShow(row[ic.ivfDB.lbresDB.lbRes.date_time_result].ToString());
                row1[colRslabdatetimeapprove] = ic.datetimetoShow(row[ic.ivfDB.lbresDB.lbRes.date_time_approve].ToString());
                row1[colRslabStatusResult] = ic.datetimetoShow(row[ic.ivfDB.lbresDB.lbRes.staff_id_result].ToString());
                if (row[ic.ivfDB.lbReqDB.lbReq.status_req].ToString().Equals("1"))
                {
                    row1[colRsLabId] = "";
                    //grfLab.Rows[i].StyleNew.BackColor = color;
                    row1.StyleNew.BackColor = color;
                    row1[colRsLabStatusShow] = "รอ lab accept";
                }
                else
                {
                    row1[colRsLabId] = row[ic.ivfDB.lbresDB.lbRes.result_id].ToString();
                    long chk = 0;
                    if(long.TryParse(row[ic.ivfDB.lbresDB.lbRes.result_id].ToString(), out chk))
                    {
                        if (row[ic.ivfDB.lbresDB.lbRes.status_result].ToString().Equals("1"))
                        {
                            row1[colRsLabStatusShow] = "lab process";
                        }
                        else if (row[ic.ivfDB.lbresDB.lbRes.status_result].ToString().Equals("2"))
                        {
                            row1[colRsLabStatusShow] = "lab result";
                        }
                        else
                        {
                            row1[colRsLabStatusShow] = "";
                        }
                    }
                }
                row1[colRsRemarkReq] = row["remark_req"].ToString();
                grfLab[i, 0] = i;
                
            }
            grfLab.Cols[colRsLabReqId].Visible = false;
            grfLab.Cols[colRslabjoblabid].Visible = false;
            grfLab.Cols[colRslabjoblabreqid].Visible = false;
            grfLab.Cols[colRslabStatusResult].Visible = false;

            grfLab.Cols[colRsLabId].AllowEditing = false;
            grfLab.Cols[colRslabdatetimeapprove].AllowEditing = false;
            grfLab.Cols[colRsLabdatetimeresult].AllowEditing = false;
            grfLab.Cols[colRsLabDatetimereceive].AllowEditing = false;
            grfLab.Cols[colRsLabReqdate].AllowEditing = false;
            grfLab.Cols[colRsReactive].AllowEditing = false;
            grfLab.Cols[colRsUnit].AllowEditing = false;
            grfLab.Cols[colRsInterpret].AllowEditing = false;
            grfLab.Cols[colRsResult].AllowEditing = false;
            grfLab.Cols[colRsRemark].AllowEditing = true;
            grfLab.Cols[colRsMethod].AllowEditing = false;
            grfLab.Cols[colRsLabStatus].AllowEditing = false;
            grfLab.Cols[colRslabName].AllowEditing = false;
            //grfImg.AutoSizeCols();
            grfLab.AutoSizeRows();
            theme1.SetTheme(grfLab, "Office2016Colorful");

        }
        private void BtnApmVoid_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            stt.Hide();
            btnVoid.Text = "Void";
            ic.cStf.staff_id = "";
            FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            frm.ShowDialog(this);
            if (!ic.cStf.staff_id.Equals(""))
            {
                //if (ic.iniC.statusAppDonor.Equals("1"))
                //{
                    String re = ic.ivfDB.pApmDB.VoidPatientAppointment(txtApmID.Text, txtStfConfirmID.Text);
                    int chk = 0;
                    //Patient ptt1 = new Patient();
                    if (re.Equals("1")) // ตอน update
                    {
                        re = ic.ivfDB.vsDB.updateOpenStatusNurse(txtVsId.Text);
                        re = ic.ivfDB.vsDB.updateStatusVoidAppointment(txtVsId.Text);
                        //setGrfpApmAll();
                        setGrfpApmVisit();
                        setGrfpApmDay();
                        //re = txtID.Text;
                        //setControlEnable(false);
                    }
                //}
                //else
                //{
                    //String re = ic.ivfDB.pttOldDB.insertPatientOld(ptt, txtStfConfirmID.Text);
                    //int chk = 0;
                    //if (int.TryParse(re, out chk))
                    //{

                    //}
                //}
            }
        }

        private void RedoButton_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.richTextBox1.Redo();
            this.UpdateUndoRedoButtons();
        }

        private void UndoButton_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.richTextBox1.Undo();
            this.UpdateUndoRedoButtons();
        }

        private void SaveDocumentButton_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.SaveDocument();
        }

        private void PasteSplitButton_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.richTextBox1.Paste();
        }

        private void FormatPainterButton_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.richTextBox1.Copy();
        }

        private void CutButton_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.richTextBox1.Cut();
        }

        private void FontFaceComboBox_ChangeCommitted(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Font font = this.richTextBox1.SelectionFont;

            if (font == null)
            {
                MessageBox.Show("Cannot change font family while selected text has more than one font.");
                return;
            }

            string fontFamilyName = this.FontFaceComboBox.Text;

            this.richTextBox1.SelectionFont = new Font(
                fontFamilyName,
                font.Size,
                font.Style,
                font.Unit);
        }

        private void FontSizeComboBox_ChangeCommitted(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Font font = this.richTextBox1.SelectionFont;

            if (font == null)
            {
                MessageBox.Show("Cannot change font size while selected text has more than one font.");
                return;
            }

            this.richTextBox1.SelectionFont = new Font(
                font.FontFamily,
                float.Parse(this.FontSizeComboBox.Text),
                font.Style,
                GraphicsUnit.Point);
        }

        private void IncreaseIndentButton_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.richTextBox1.SelectionIndent += 30;
        }

        private void DecreaseIndentButton_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.richTextBox1.SelectionIndent -= 30;
        }

        private void ParagraphAlignRightButton_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.SetParagraphAlignment(HorizontalAlignment.Right);
        }

        private void ParagraphAlignCenterButton_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.SetParagraphAlignment(HorizontalAlignment.Center);
        }

        private void ParagraphAlignLeftButton_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.SetParagraphAlignment(HorizontalAlignment.Left);
        }

        private void BackColorPicker_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.richTextBox1.SelectionBackColor = this.BackColorPicker.Color;
        }

        private void FontColorPicker_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.richTextBox1.SelectionColor = this.FontColorPicker.Color;
        }

        private void FontStrikeoutButton_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ToggleSelectionFontStyle(FontStyle.Strikeout);
        }

        private void FontUnderlineButton_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ToggleSelectionFontStyle(FontStyle.Underline);
        }

        private void FontItalicButton_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ToggleSelectionFontStyle(FontStyle.Italic);
        }

        private void FontBoldButton_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ToggleSelectionFontStyle(FontStyle.Bold);
        }
        void SetParagraphAlignment(HorizontalAlignment alignment)
        {
            this.richTextBox1.SelectionAlignment = alignment;

            // If the user clicks the same button twice, it will get unpressed.
            // We want 1 button to be pressed at all times, so we just set 
            // the buttons' states based on current text alignment.
            this.UpdateParagraphAlignmentButtons();
        }
        void ToggleSelectionFontStyle(FontStyle fontStyle)
        {
            if (this.richTextBox1.SelectionFont == null)
            {
                MessageBox.Show("Cannot change font style while selected text has more than one font.");
            }
            else
            {
                this.richTextBox1.SelectionFont = new Font(this.richTextBox1.SelectionFont,
                    this.richTextBox1.SelectionFont.Style ^ fontStyle);
            }
        }
        private void initProgressNote()
        {
            this.InitializeClipboardGroup();
            this.InitializeFontGroup();
            this.InitializeParagraphGroup();
            this.InitializeViewZoomGroup();

            this.InitializeRibbonStyleMenu();
            this.InitializeFocusManagement();
            this.InitializeUndoRedo();
            this.InitializeModifiedIcon();
            this.InitializeQatPosition();

            this.InitializeRecentDocumentList();
        }        
        private void InitializeClipboardGroup()
        {
            this.UpdateClipboardGroupBasedOnCurrentTextSelection();

            this.richTextBox1.SelectionChanged += delegate
            {
                this.UpdateClipboardGroupBasedOnCurrentTextSelection();
            };

            this.PasteButton.Click += new EventHandler(PasteButton_Click);
            this.PasteAsTextButton.Click += new EventHandler(PasteAsTextButton_Click);
        }
        void PasteButton_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Paste();
        }
        void PasteAsTextButton_Click(object sender, EventArgs e)
        {
            this.richTextBox1.SelectedText = Clipboard.GetText();
        }
        private void UpdateClipboardGroupBasedOnCurrentTextSelection()
        {
            this.CutButton.Enabled = this.CopyButton.Enabled =
                !string.IsNullOrEmpty(this.richTextBox1.SelectedText);
        }        
        private void InitializeFontGroup()
        {
            // Populate the Font Face combobox with font names.
            foreach (FontFamily fontFamily in FontFamily.Families)
            {
                this.FontFaceComboBox.Items.Add(new RibbonButton(fontFamily.Name));
            }

            // Populate the Font Size combobox with some typical font sizes.
            foreach (int size in new int[] { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 })
            {
                this.FontSizeComboBox.Items.Add(new RibbonButton(size.ToString()));
            }

            // Keep ribbon controls state updated based on current text selection.
            this.UpdateFontGroupBasedOnCurrentTextSelection();
            this.richTextBox1.SelectionChanged += delegate
            {
                this.UpdateFontGroupBasedOnCurrentTextSelection();
            };
        }
        private void UpdateFontGroupBasedOnCurrentTextSelection()
        {
            Font font = this.richTextBox1.SelectionFont;
            bool none = font == null;
            FontBoldButton.Pressed = none ? false : font.Bold;
            FontItalicButton.Pressed = none ? false : font.Italic;
            FontUnderlineButton.Pressed = none ? false : font.Underline;
            FontStrikeoutButton.Pressed = none ? false : font.Strikeout;
            FontFaceComboBox.Text = none ? "" : font.FontFamily.Name;
            FontSizeComboBox.Text = none ? "" : font.Size.ToString();
        }        
        private void InitializeParagraphGroup()
        {
            // Keep Ribbon controls state updated based on current text selection.
            this.UpdateParagraphGroupBasedOnCurrentTextSelection();
            this.richTextBox1.SelectionChanged += delegate
            {
                this.UpdateParagraphGroupBasedOnCurrentTextSelection();
            };
        }
        private void UpdateParagraphGroupBasedOnCurrentTextSelection()
        {
            this.UpdateParagraphAlignmentButtons();
        }
        private void UpdateParagraphAlignmentButtons()
        {
            HorizontalAlignment a = this.richTextBox1.SelectionAlignment;
            this.ParagraphAlignLeftButton.Pressed = a == HorizontalAlignment.Left;
            this.ParagraphAlignCenterButton.Pressed = a == HorizontalAlignment.Center;
            this.ParagraphAlignRightButton.Pressed = a == HorizontalAlignment.Right;
        }
        private void InitializeViewZoomGroup()
        {
            foreach (int percent in new int[] { 10, 30, 50, 80, 100, 120, 150, 200, 250, 300, 400, 700, 1000 })
            {
                this.ViewZoomCombobox.Items.Add(new RibbonButton(percent + "%"));
            }

            this.UpdateViewZoomComboBox();

            // Update the combo box when user zooms with the mouse wheel.
            this.richTextBox1.MouseWheel += delegate
            {
                this.UpdateViewZoomComboBox();
            };
        }
        private void UpdateViewZoomComboBox()
        {
            this.ViewZoomCombobox.Text = (this.richTextBox1.ZoomFactor * 100).ToString() + "%";
        }        
        private void InitializeRibbonStyleMenu()
        {
            ribbonStyleCombo.Items.Clear();
            string[] themes = C1ThemeController.GetThemes();
            var showThemes = themes.Where((tn) =>
            {
                var ltn = tn.ToLower();
                if (ltn.Contains("visualstyle")) // avoid old "visual style" themes
                    return false;
                else
                    return true;
            });
            ribbonStyleCombo.Items.Add("(No Theme)");
            foreach (string theme in showThemes)
                ribbonStyleCombo.Items.Add(theme);
            ribbonStyleCombo.SelectedIndex = 0;
        }        
        private void InitializeFocusManagement()
        {
            // Set initial focus on the text area.
            this.Shown += delegate { this.richTextBox1.Focus(); };

            // When a Ribbon button is clicked, move the focus back to the rich text box.
            this.c1Ribbon1.RibbonEvent += new RibbonEventHandler(c1Ribbon1_RibbonEvent);
        }
        void c1Ribbon1_RibbonEvent(object sender, RibbonEventArgs e)
        {
            switch (e.EventType)
            {
                case RibbonEventType.ChangeCommitted:
                case RibbonEventType.ChangeCanceled:
                case RibbonEventType.Click:
                case RibbonEventType.DialogLauncherClick:
                case RibbonEventType.DropDownClosed:
                    if (this.c1Ribbon1.Focused)
                    {
                        this.richTextBox1.Focus();
                    }
                    break;
            }
        }

        private void InitializeUndoRedo()
        {
            this.UpdateUndoRedoButtons();
            this.richTextBox1.TextChanged += delegate { this.UpdateUndoRedoButtons(); };
        }
        void UpdateUndoRedoButtons()
        {
            this.UndoButton.Enabled = this.richTextBox1.CanUndo;
            this.RedoButton.Enabled = this.richTextBox1.CanRedo;
        }
        private void InitializeModifiedIcon()
        {
            this.UpdateModifiedIcon();
            this.richTextBox1.ModifiedChanged += delegate { this.UpdateModifiedIcon(); };
        }
        private void UpdateModifiedIcon()
        {
            //this.DocumentModifiedLabel.Enabled = this.richTextBox1.Modified;
            //this.DocumentModifiedLabel.ToolTip = this.richTextBox1.Modified
            //    ? "Document modified"
            //    : "Document not modified";
        }
        private void InitializeQatPosition()
        {
            Properties.Settings settings = Properties.Settings.Default;

            // Initialize QAT position from application settings.
            this.c1Ribbon1.Qat.BelowRibbon = settings.QatBelowRibbon;

            // Update application setting when QAT position changes.
            this.c1Ribbon1.Qat.PositionChanged += delegate
            {
                settings.QatBelowRibbon = this.c1Ribbon1.Qat.BelowRibbon;
            };
        }
        private RecentDocumentList recentDocuments;
        private void InitializeRecentDocumentList()
        {
            // Create a new collection if it was not serialized before.
            if (Properties.Settings.Default.RecentDocuments == null)
            {
                Properties.Settings.Default.RecentDocuments = new StringCollection();
            }

            this.recentDocuments = new RecentDocumentList(this.c1Ribbon1.ApplicationMenu.RightPaneItems,  Settings.Default.RecentDocuments, this.LoadRecentDocument);

            //RichTextBoxStreamType fileType = RichTextBoxStreamType.RichText;
            //String filePathName = "progressnote" + "_" + txtVn.Text + ".rtf";
            //richTextBox1.LoadFile(filePathName, fileType);
            txtVnProgressNote.Value = txtVn.Text;
            Thread threadA = new Thread(new ParameterizedThreadStart(ExecuteProgressNote));
            threadA.Start();
        }
        private void ExecuteProgressNote(Object obj)
        {
            //Console.WriteLine("Executing parameterless thread!");
            try
            {
                RichTextBoxStreamType fileType = RichTextBoxStreamType.RichText;
                MemoryStream stream = new MemoryStream();
                String filePathName = "progressnote" + "_" + txtVnProgressNote.Text + ".rtf";
                if (File.Exists(filePathName))
                {
                    File.Delete(filePathName);
                    System.Threading.Thread.Sleep(200);
                }
                String aaa = ic.iniC.folderFTP + "/" + txtIdOld.Text+"/" + filePathName;
                //setPic(new Bitmap(ic.ftpC.download(filenamepic)));
                stream = ic.ftpC.download(aaa);
                //File file1 = new File();
                //FileStream fileStream = new FileStream(filePathName, FileMode.Create);
                //fileStream.CopyTo(stream);
                //using (FileStream fileStream1 = File.Create(filePathName))
                //using (StreamWriter writer = new StreamWriter(fileStream1))
                //{
                //    //writer.w("Example 1 written");
                //}
                if (stream.Length > 0)
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    using (FileStream file = new FileStream(filePathName, FileMode.Create, FileAccess.Write))
                    {
                        //byte[] bytes = new byte[stream.Length];
                        //file.Write(bytes, 0, (int)stream.Length);
                        stream.CopyTo(file);
                        file.Flush();
                        //stream.Write(bytes, 0, (int)file.Length);
                    }
                    //richTextBox1.LoadFile(filePathName, fileType);
                    if (File.Exists(filePathName))
                    {
                        richTextBox1.Invoke((Action)delegate
                        {
                            richTextBox1.LoadFile(filePathName, fileType);
                            filePathNamePg = filePathName;
                        });
                    }
                }
                else
                {
                    String txt = "";
                    txt = "Nursing Progress Note "+ Environment.NewLine;
                    txt += Environment.NewLine;
                    txt += "Date : "+ DateTime.Now.ToString("dd-MM-") + "-" + DateTime.Now.Year+" "+ DateTime.Now.ToString("hh:MM:ss")+ Environment.NewLine;
                    txt += Environment.NewLine;
                    txt += "Patient Name : "+ txtPttNameE .Text+ Environment.NewLine;
                    txt += "HN : " + txtHn.Text + " VN : "+txtVnShow.Text + Environment.NewLine;
                    txt += "DOB : "+ txtDob .Text + " SEX : "+ txtSex.Text + Environment.NewLine;
                    txt += "Disease : " + Environment.NewLine;
                    txt += "Drug allergy : " + cboAllergyDesc .Text + Environment.NewLine;
                    txt += "Food allergy : " + Environment.NewLine;
                    txt += "Surgery : " + Environment.NewLine;
                    txt += "Period : " + Environment.NewLine;
                    txt += "Chromosome : " + Environment.NewLine;
                    txt += Environment.NewLine;
                    txt += "Diagnosis : " + Environment.NewLine;
                    txt += Environment.NewLine;
                    txt += Environment.NewLine;
                    txt += Environment.NewLine;
                    txt += "Doctor : "+ cboDoctor .Text+ Environment.NewLine;
                    //richTextBox1.Text = txt;
                    //richTextBox1.AppendText(txt);
                    richTextBox1SetText(txt);
                }
            }
            catch (Exception ex)
            {
                String aaa = "";
            }
        }
        private void LoadRecentDocument(string filename)
        {
            if (!File.Exists(filename))
            {
                MessageBox.Show("File does not exist: " + filename);
                return;
            }

            if (!this.PromtToSaveDocument()) return;

            this.LoadDocument(filename);
        }
        private bool PromtToSaveDocument()
        {
            if (!this.richTextBox1.Modified) return true;

            DialogResult dr = MessageBox.Show(
                "Do you want to save '" + this.documentName + "'?",
                "WordPad Sample", MessageBoxButtons.YesNoCancel);

            switch (dr)
            {
                case DialogResult.Cancel:
                    return false;

                case DialogResult.No:
                    return true;

                case DialogResult.Yes:
                    return this.SaveDocument();
            }

            throw new ApplicationException();
        }
        private void LoadDocument(string filePathName)
        {
            RichTextBoxStreamType streamType = filePathName.EndsWith(".rtf") ? RichTextBoxStreamType.RichText : RichTextBoxStreamType.PlainText;
            try
            {
                this.richTextBox1.LoadFile(filePathName, streamType);
                this.SetDocumentProperties(filePathName, streamType);
                this.recentDocuments.Update(filePathName);
                this.RaiseRichTextBoxSelectionChanged();
            }
            catch (IOException e)
            {
                // there is no such file
                MessageBox.Show(e.Message);
            }
        }
        private bool SaveDocument()
        {
            return this.SaveDocument(this.documentPath == null);
        }

        private bool SaveDocument(bool showDialog)
        {
            //if (showDialog)
            //{
            //    SaveFileDialog dlg = new SaveFileDialog();
            //    dlg.FileName = this.documentName;
            //    if (this.documentPath != null) dlg.InitialDirectory = this.documentPath;
            //    dlg.Filter = "Rich text file (*.rtf)|*.rtf|"
            //        + "Rich text file, no OLE objects (*.rtf)|*.rtf|"
            //        + "Plain text file, no OLE objects (*.txt)|*.txt|"
            //        + "Plain text file, OLE objects replaced with text (*.txt)|*.txt|"
            //        + "Unicode text file, no OLE objects (*.txt)|*.txt";

            //    DialogResult dr = dlg.ShowDialog();
            //    if (dr == DialogResult.Cancel) return false;
            //    if (dr != DialogResult.OK) throw new ApplicationException();

            //    RichTextBoxStreamType fileType;

            //    switch (dlg.FilterIndex)
            //    {
            //        case 1: fileType = RichTextBoxStreamType.RichText; break;
            //        case 2: fileType = RichTextBoxStreamType.RichNoOleObjs; break;
            //        case 3: fileType = RichTextBoxStreamType.PlainText; break;
            //        case 4: fileType = RichTextBoxStreamType.TextTextOleObjs; break;
            //        case 5: fileType = RichTextBoxStreamType.UnicodePlainText; break;
            //        default: throw new ApplicationException();
            //    }

            //    this.SetDocumentProperties(dlg.FileName, fileType);
            //}
            RichTextBoxStreamType fileType = RichTextBoxStreamType.RichText;
            this.SetDocumentProperties("progressnote_"+txtVn.Text + ".rtf", fileType);
            this.SaveDocumentAs(this.documentFileType);
            setGrfPg();
            return true;
        }

        private void SaveDocumentAs(RichTextBoxStreamType fileType)
        {
            //string filePathName = this.documentPath + '\\' + this.documentName;
            try
            {
                ic.logw.WriteLog("g", "SaveDocumentAs HN " + txtHn.Text + " VN " + txtVn.Text);
                String filePathName = this.documentPath + '\\' + this.documentName;
                if (File.Exists(filePathName))
                {
                    File.Delete(filePathName);
                    System.Threading.Thread.Sleep(200);
                }
                this.richTextBox1.SaveFile(filePathName, fileType);
                this.recentDocuments.Update(filePathName);
                this.richTextBox1.Modified = false;
                //RichTextBoxStreamType fileType1 = RichTextBoxStreamType.RichText;
                //String ext = Path.GetExtension(filePathName);
                //String filename = filePathName.Replace(ext, "");
                //filename = filename+"_" + txtVn.Text + ext;
                ic.savePicOPUtoServer(txtIdOld.Text, documentName, filePathName);
            }
            catch(Exception ex)
            {
                ic.logw.WriteLog("e", "SaveDocumentAs HN " + txtHn.Text + " VN " + txtVn.Text+" "+ ex.Message);
            }
        }

        private void TabLab_Click(object sender, EventArgs e)
        {

        }

        private void CreateNewDocument()
        {
            this.richTextBox1.Clear();
            this.documentName = "Document";
            this.documentPath = null;
            this.documentFileType = RichTextBoxStreamType.RichText;

            this.RaiseRichTextBoxSelectionChanged();
        }
        private void SetDocumentProperties(string filePathName, RichTextBoxStreamType fileType)
        {
            FileInfo fileInfo = new FileInfo(filePathName);
            this.documentName = fileInfo.Name;
            this.documentPath = fileInfo.DirectoryName;
            this.documentFileType = fileType;
        }

        private void RaiseRichTextBoxSelectionChanged()
        {
            // Force a SelectionChanged event to update the state of Ribbon items 
            // that depend on current text selection.
            this.richTextBox1.SelectAll();
            this.richTextBox1.Select(0, 0);

            this.richTextBox1.Modified = false;
        }
        private void BtnEggStiSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (txtEggStiId.Text.Equals(""))
            {
                MessageBox.Show("ID ไม่ถูกต้อง ", "");
                return;
            }
            ic.cStf.staff_id = "";
            FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            frm.ShowDialog(this);
            if (!ic.cStf.staff_id.Equals(""))
            {
                setEggSti();
                String re = ic.ivfDB.eggsDB.insertEggSti(eggs, ic.cStf.staff_id);

                for (int i = 1; i <= 17; i++)
                {
                    if (grfEggsd.Rows[i][colEggEdit] == null) continue;
                    if (grfEggsd.Rows[i][colEggEdit].ToString().Equals("1"))
                    {
                        EggStiDay eggsd = new EggStiDay();
                        eggsd.egg_sti_day_id = grfEggsd.Rows[i][colEggId].ToString();
                        eggsd.egg_sti_id = txtEggStiId.Text;
                        eggsd.day1 = i.ToString();
                        eggsd.date = "";
                        eggsd.e2 = grfEggsd.Rows[i][colEggE2].ToString();
                        eggsd.lh = grfEggsd.Rows[i][colEggLH].ToString();
                        eggsd.active = "";
                        eggsd.remark = "";
                        eggsd.fsh = grfEggsd.Rows[i][colEggFSH].ToString();
                        eggsd.date_create = "";
                        eggsd.date_modi = "";
                        eggsd.date_cancel = "";
                        eggsd.user_create = "";
                        eggsd.user_modi = "";
                        eggsd.user_cancel = "";
                        eggsd.prolactin = grfEggsd.Rows[i][colEggProlactin].ToString();
                        eggsd.rt_ovary_1 = grfEggsd.Rows[i][colEggRt1].ToString();
                        eggsd.rt_ovary_2 = grfEggsd.Rows[i][colEggRt2].ToString();
                        eggsd.lt_ovary_1 = grfEggsd.Rows[i][colEggLt1].ToString();
                        eggsd.lt_ovary_2 = grfEggsd.Rows[i][colEggLt2].ToString();
                        eggsd.endo = grfEggsd.Rows[i][colEggEndo].ToString();
                        eggsd.medication = grfEggsd.Rows[i][colEggMedi].ToString();
                        eggsd.medication2 = grfEggsd.Rows[i][colEggMedi2].ToString();
                        ic.ivfDB.eggsdDB.insertEggStiDay(eggsd, ic.cStf.staff_id);
                    }
                }
            }
        }

        private void BtnEggStiPrint_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmReport frm = new FrmReport(ic);
            DataTable dt = new DataTable();
            dt = ic.ivfDB.eggsdDB.selectByEggStiId(txtEggStiId.Text);
            dt.Columns.Add("status_abnormal", typeof(String));
            dt.Columns.Add("abnormal1", typeof(String));
            dt.Columns.Add("abnormal2", typeof(String));
            dt.Columns.Add("status_typing", typeof(String));
            dt.Columns.Add("status_typing_other", typeof(String));
            dt.Columns.Add("typing_other", typeof(String));
            dt.Columns.Add("status_infectious", typeof(String));
            dt.Columns.Add("status_add_lab", typeof(String));
            dt.Columns.Add("add_lab", typeof(String));
            dt.Columns.Add("bhcg", typeof(String));
            //dt.Columns.Add("medication", typeof(String));
            //dt.Columns.Add("medicatio2", typeof(String));
            //dt.Columns.Add("rt_ovary", typeof(String));
            //dt.Columns.Add("lt_ovary", typeof(String));
            String date1 = "";
            foreach (DataRow row in dt.Rows)
            {
                date1 = ic.datetoShow(row["date"].ToString());
                row["date"] = date1.Replace("-", "/");
                row["status_abnormal"] = chkAbnormal.Checked ? "1" : "0";
                row["abnormal1"] = txtAbnormal1.Text;
                row["abnormal2"] = txtAbnormal2.Text;
                row["status_typing"] = chkTyping.Checked ? "1" : "0";
                row["status_typing_other"] = chkEggStiOther.Checked ? "1" : "0"; ;
                row["typing_other"] = cboEggStiOther.Text;
                row["status_infectious"] = chkEggStiInfection.Checked ? "1" : "0";
                row["status_add_lab"] = chkAmh.Checked ? "1" : "0";
                row["add_lab"] = cboEggStiAmh.Text;
                row["bhcg"] = cboEggStiBhcg.Text;
                //row["status_abnormal"] = "";
                //row["status_abnormal"] = "";
            }

            frm.setEggStiReport(dt, txtPttNameE.Text+" ["+txtHn.Text+"]"+" DOB "+ txtDob.Text, txtName_2.Text, txtEggStiVisitLMP.Text, txtEggStiG.Text, txtEggStiP.Text, txtEggStiA.Text
                , cboEggStiDtr.Text, txtEggStiOPUDate.Text, txtEggStiOPUTime.Text, txtEggStiEmbryoTranferDate.Text
                , txtEggStiEmbryoTranferTime.Text, txtAllergy.Text, txtVisitHeight.Text, txtVisitBP.Text, txtVisitBW.Text, txtVisitPulse.Text);
            frm.ShowDialog(this);
        }

        //private void setControlApm()
        //{
        //    ptt = ic.ivfDB.pttDB.selectByPk1(pttId);
        //    vs = ic.ivfDB.vsDB.selectByPk1(vsid);
        //    pApm = ic.ivfDB.pApmDB.selectByPk1(pApmId);
        //    if (ptt.t_patient_id.Equals(""))
        //    {
        //        ptt = ic.ivfDB.pttDB.selectByIDold(pttId);
        //    }
        //    txtPttId.Value = ptt.t_patient_id;
        //    txtVsId.Value = vs.t_visit_id;
        //    txtHn.Value = ptt.patient_hn;
        //    txtApmName.Value = ptt.Name;
        //    txtApmRemark.Value = ptt.remark;
        //    if (!pApm.t_patient_appointment_id.Equals(""))
        //    {
        //        txtApmDatepApm.Value = pApm.patient_appointment_date;
        //    }
        //    ic.setC1Combo(cboApmTimepApm, pApm.patient_appointment_time);
        //    ic.setC1Combo(cboBsp, pApm.patient_appointment_servicepoint);
        //    chkApmDonorE2.Checked = pApm.e2.Equals("1") ? true : false;
        //    chkApmLh.Checked = pApm.lh.Equals("1") ? true : false;
        //    chkApmFsh.Checked = pApm.fsh.Equals("1") ? true : false;
        //    chkApmPrl.Checked = pApm.prl.Equals("1") ? true : false;
        //    chkApmTvs.Checked = pApm.tvs.Equals("1") ? true : false;

        //    chkApmRE2.Checked = pApm.repeat_e2.Equals("1") ? true : false;
        //    chkApmRLh.Checked = pApm.repeat_lh.Equals("1") ? true : false;
        //    chkApmRFsh.Checked = pApm.repeat_fsh.Equals("1") ? true : false;
        //    chkApmRPrl.Checked = pApm.repeat_prl.Equals("1") ? true : false;
        //    chkSperm.Checked = pApm.sperm_collect.Equals("1") ? true : false;
        //    chkApmEt.Checked = pApm.e2.Equals("1") ? true : false;
        //    chkApmFet.Checked = pApm.e2.Equals("1") ? true : false;
        //    chkApmOther.Checked = pApm.e2.Equals("1") ? true : false;
        //    txtApmRemark.Value = pApm.remark;
        //    ic.setC1Combo(cboDoctor, pApm.patient_appointment_doctor);
        //    txtApmID.Value = pApm.t_patient_appointment_id;
        //    chkApmOpu.Checked = pApm.opu.Equals("1") ? true : false;
        //    ic.setC1Combo(cboApmDtrAnes, pApm.doctor_anes);
        //    cboApmDtrAnes.Enabled = chkApmOpu.Checked ? true : false;
        //    txtApmTvsDay.Value = pApm.tvs_day;
        //    txtApmTvsDay.Enabled = chkApmTvs.Checked ? true : false;
        //    ic.setC1Combo(cboApmTvsTime, pApm.tvs_time);
        //    ic.setC1Combo(cboApmOPUTime, pApm.opu_time);
        //    chkApmHormoneTest.Checked = pApm.hormone_test.Equals("1") ? true : false;
        //    chkApmHCG.Checked = pApm.beta_hgc.Equals("1") ? true : false;
        //    chkApmOther.Checked = pApm.other.Equals("1") ? true : false;
        //    txtApmOther.Value = pApm.other_remark;
        //    ic.setC1Combo(cboApmETTime, pApm.et_time);
        //    ic.setC1Combo(cboApmFETTime, pApm.fet_time);
        //    ic.setC1Combo(cboApmOPUTime, pApm.opu_time);
        //    ic.setC1Combo(cboApmTvsTime, pApm.tvs_time);
        //    txtApmTvsDay.Value = pApm.tvs_day;
        //    //chkOPU

        //    ChkApmTvs_CheckedChanged(null, null);
        //    ChkApmOpu_CheckedChanged(null, null);
        //    ChkApmFet_CheckedChanged(null, null);
        //    ChkApmEt_CheckedChanged(null, null);
        //    ChkApmOther_CheckedChanged(null, null);
        //    ChkApmTvsDonor_CheckedChanged(null, null);
        //    ChkApmOpuDonor_CheckedChanged(null, null);

        //    pttO = ic.ivfDB.pttOldDB.selectByPk1(pttId);
        //    txtPttIdOld.Value = pttO.PID;
        //    txtHn.Value = pttO.PIDS;
        //    txtApmName.Value = pttO.FullName;

        //    txtApmOPURemark.Value = "Not Allow to drink or eat from (งดน้ำ งดอาหาร ตั้งแต่เวลา)";

        //    if (pApm.patient_appointment_servicepoint.Equals("") && cboBsp.Items.Count > 3)
        //    {
        //        cboBsp.SelectedIndex = 3;
        //    }
        //    PatientImage pttI = new PatientImage();
        //    pttI = ic.ivfDB.pttImgDB.selectByPttIDStatus4(txtApmID.Text);
        //    filenamepic = pttI.image_path;
        //    Thread threadA = new Thread(new ParameterizedThreadStart(ExecuteA));
        //    threadA.Start();
        //}
        private void initGrfpApmVisit()
        {
            grfpApmVisit = new C1FlexGrid();
            grfpApmVisit.Font = fEdit;
            grfpApmVisit.Dock = System.Windows.Forms.DockStyle.Fill;
            grfpApmVisit.Location = new System.Drawing.Point(0, 0);
            grfpApmVisit.DoubleClick += GrfpApmVisit_DoubleClick;
            //FilterRow fr = new FilterRow(grfExpn);

            //grfpApmAll.ContextMenu = menuGw;
            pnApmVisit.Controls.Add(grfpApmVisit);

            theme1.SetTheme(grfpApmVisit, "Office2016Colorful");

        }

        private void GrfpApmVisit_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ContextMenu_edit_apm(null, null);
        }

        private void BtnApmPrint_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            SetDefaultPrinter(ic.iniC.printerAppointment);      //A5
            FrmReport frm = new FrmReport(ic);
            DataTable dt = new DataTable();
            DataTable dtOld = new DataTable();
            dt = ic.ivfDB.pApmDB.selectAppointmentByPk(txtApmID.Text);
            dtOld = ic.ivfDB.pApmOldDB.selectAppointmentByPk(txtApmID.Text);

            String date1 = "";
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.pApmDB.pApm.patient_appointment_date].ToString());
            dt.Rows[0][ic.ivfDB.pApmDB.pApm.patient_appointment_date] = date1;
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][ic.ivfDB.pApmDB.pApm.opu_remark].ToString().Length > 0)
                {
                    dt.Rows[0][ic.ivfDB.pApmDB.pApm.patient_appointment_notice] += Environment.NewLine + dt.Rows[0][ic.ivfDB.pApmDB.pApm.opu_remark].ToString()+Environment.NewLine;
                }
            }

            frm.setAppointmentPatient(dt);
            frm.ShowDialog(this);
        }

        private void ChkApmOpuDonor_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            cboApmOPUTimeDonor.Enabled = chkApmOpuDonor.Checked ? true : false;
            cboApmDtrAnes.Enabled = chkApmOpuDonor.Checked ? true : false;
        }

        private void ChkApmTvsDonor_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            txtApmTvsDayDonor.Enabled = chkApmTvsDonor.Checked ? true : false;
            cboApmTvsTimeDonor.Enabled = chkApmTvsDonor.Checked ? true : false;
        }

        private void ChkApmOther_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            txtApmOther.Enabled = chkApmOther.Checked ? true : false;
        }

        private void ChkApmEt_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            cboApmETTime.Enabled = chkApmEt.Checked ? true : false;
        }

        private void ChkApmFet_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            cboApmFETTime.Enabled = chkApmFet.Checked ? true : false;
        }

        private void ChkApmOpu_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            txtApmOPURemark.Enabled = chkApmOpu.Checked ? true : false;
            cboApmOPUTime.Enabled = chkApmOpu.Checked ? true : false;
            if (chkApmOpu.Checked)
            {
                txtApmOPURemark.Value = "Not Allow to drink or eat from (งดน้ำ งดอาหาร ตั้งแต่เวลา)";
            }
            else
            {
                txtApmOPURemark.Value = "";
            }
        }

        private void ChkApmTvs_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            txtApmTvsDay.Enabled = chkApmTvs.Checked ? true : false;
            cboApmTvsTime.Enabled = chkApmTvs.Checked ? true : false;
        }

        private void setGrfpApmDay()
        {
            //grfDept.Rows.Count = 7;
            grfpApmDayAll.Clear();
            DataTable dt = new DataTable();

            dt = ic.ivfDB.pApmDB.selectByDay(ic.datetoDB(txtApmDatepApm.Text), ic.datetoDB(txtApmDatepApm.Text));

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfpApmDayAll.Rows.Count = 1;
            grfpApmDayAll.Cols.Count = 14;
            C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfpApmDayAll.Cols[colApmNotice].Editor = txt;
            grfpApmDayAll.Cols[colApmAppointment].Editor = txt;
            grfpApmDayAll.Cols[colApmDoctor].Editor = txt;
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

            grfpApmDayAll.Cols[colApmDate].Width = 100;
            grfpApmDayAll.Cols[colApmTime].Width = 80;
            grfpApmDayAll.Cols[colApmAppointment].Width = 120;
            grfpApmDayAll.Cols[colApmDoctor].Width = 100;
            grfpApmDayAll.Cols[colApmSp].Width = 80;
            grfpApmDayAll.Cols[colApmNotice].Width = 200;
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

            grfpApmDayAll.Cols[colApmDate].Caption = "Date";
            grfpApmDayAll.Cols[colApmTime].Caption = "time";
            grfpApmDayAll.Cols[colApmAppointment].Caption = "นัด";
            grfpApmDayAll.Cols[colApmDoctor].Caption = "Doctor";
            grfpApmDayAll.Cols[colApmSp].Caption = "จุดบริการ";
            grfpApmDayAll.Cols[colApmNotice].Caption = "แจ้ง";
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
                row1[colApmId] = row[ic.ivfDB.pApmDB.pApm.t_patient_appointment_id].ToString();
                row1[colApmDate] = ic.datetoShow(row[ic.ivfDB.pApmDB.pApm.patient_appointment_date].ToString());
                row1[colApmTime] = row[ic.ivfDB.pApmDB.pApm.patient_appointment_time].ToString();
                row1[colApmAppointment] = row[ic.ivfDB.pApmDB.pApm.patient_appointment].ToString();
                row1[colApmDoctor] = row[ic.ivfDB.pApmDB.pApm.dtr_name];
                row1[colApmSp] = row["service_point_description"].ToString();
                row1[colApmNotice] = row[ic.ivfDB.pApmDB.pApm.patient_appointment_notice].ToString();

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
            grfpApmDayAll.Cols[colApmId].Visible = false;
            theme1.SetTheme(grfpApmDayAll, ic.theme);

        }
        private void TxtApmDatepApm_ValueChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setGrfpApmDay();
        }
        private void setControlApm()
        {
            //ptt = ic.ivfDB.pttDB.selectByPk1(pttId);
            //vs = ic.ivfDB.vsDB.selectByPk1(vsid);
            pApm = ic.ivfDB.pApmDB.selectByPk1(pApmId);
            if (ptt.t_patient_id.Equals(""))
            {
                ptt = ic.ivfDB.pttDB.selectByIDold(pttId);
            }
            txtPttId.Value = ptt.t_patient_id;
            //txtVsId.Value = vs.t_visit_id;
            txtHn.Value = ptt.patient_hn;
            txtApmName.Value = ptt.Name;
            txtApmRemark.Value = ptt.remark;
            if (!pApm.t_patient_appointment_id.Equals(""))
            {
                txtApmDatepApm.Value = pApm.patient_appointment_date;
            }
            ic.setC1Combo(cboApmTimepApm, pApm.patient_appointment_time);
            ic.setC1Combo(cboApmBsp, pApm.patient_appointment_servicepoint);
            chkApmDonorE2.Checked = pApm.e2.Equals("1") ? true : false;
            chkApmLh.Checked = pApm.lh.Equals("1") ? true : false;
            chkApmFsh.Checked = pApm.fsh.Equals("1") ? true : false;
            chkApmPrl.Checked = pApm.prl.Equals("1") ? true : false;
            chkApmTvs.Checked = pApm.tvs.Equals("1") ? true : false;

            chkApmRE2.Checked = pApm.repeat_e2.Equals("1") ? true : false;
            chkApmRLh.Checked = pApm.repeat_lh.Equals("1") ? true : false;
            chkApmRFsh.Checked = pApm.repeat_fsh.Equals("1") ? true : false;
            chkApmRPrl.Checked = pApm.repeat_prl.Equals("1") ? true : false;
            chkApmSpermCollect.Checked = pApm.sperm_collect.Equals("1") ? true : false;
            chkApmEt.Checked = pApm.et.Equals("1") ? true : false;
            chkApmFet.Checked = pApm.fet.Equals("1") ? true : false;
            chkApmOther.Checked = pApm.other.Equals("1") ? true : false;
            txtApmRemark.Value = pApm.remark;
            txtApmAppointment.Value = pApm.patient_appointment;
            ic.setC1Combo(cboApmDtr, pApm.patient_appointment_doctor);
            txtApmID.Value = pApm.t_patient_appointment_id;
            chkApmOpu.Checked = pApm.opu.Equals("1") ? true : false;
            ic.setC1Combo(cboApmDtrAnes, pApm.doctor_anes);
            cboApmDtrAnes.Enabled = chkApmOpu.Checked ? true : false;
            txtApmTvsDay.Value = pApm.tvs_day;
            txtApmTvsDay.Enabled = chkApmTvs.Checked ? true : false;
            ic.setC1Combo(cboApmTvsTime, pApm.tvs_time);
            ic.setC1Combo(cboApmOPUTime, pApm.opu_time);
            chkApmHormoneTest.Checked = pApm.hormone_test.Equals("1") ? true : false;
            chkApmHCG.Checked = pApm.beta_hgc.Equals("1") ? true : false;
            chkApmOther.Checked = pApm.other.Equals("1") ? true : false;
            chkApmSpermCollect.Checked = pApm.sperm_collect.Equals("1") ? true : false;
            chkApmSpermFreezing.Checked = pApm.sperm_freezing.Equals("1") ? true : false;
            chkApmPesa.Checked = pApm.pesa.Equals("1") ? true : false;
            chkApmSpermOPU.Checked = pApm.sperm_opu.Equals("1") ? true : false;
            chkApmSpermSA.Checked = pApm.sperm_opu.Equals("1") ? true : false;

            txtApmOther.Value = pApm.other_remark;
            ic.setC1Combo(cboApmETTime, pApm.et_time);
            ic.setC1Combo(cboApmFETTime, pApm.fet_time);
            ic.setC1Combo(cboApmOPUTime, pApm.opu_time);
            ic.setC1Combo(cboApmTvsTime, pApm.tvs_time);
            txtApmTvsDay.Value = pApm.tvs_day;
            //chkOPU

            ChkApmTvs_CheckedChanged(null, null);
            ChkApmOpu_CheckedChanged(null, null);
            ChkApmFet_CheckedChanged(null, null);
            ChkApmEt_CheckedChanged(null, null);
            ChkApmOther_CheckedChanged(null, null);
            ChkApmTvsDonor_CheckedChanged(null, null);
            ChkApmOpuDonor_CheckedChanged(null, null);

            pttO = ic.ivfDB.pttOldDB.selectByPk1(pttId);
            txtPttIdOld.Value = pttO.PID;
            txtHn.Value = pttO.PIDS;
            txtApmName.Value = pttO.FullName;
            txtApmRemark.Value = ptt.remark;
            txtApmOPURemark.Value = pApm.opu_remark;

            if (pApm.patient_appointment_servicepoint.Equals("") && cboBsp.Items.Count > 3)
            {
                cboBsp.SelectedIndex = 3;
            }
            PatientImage pttI = new PatientImage();
            pttI = ic.ivfDB.pttImgDB.selectByPttIDStatus4(txtApmID.Text);
            filenamepic = pttI.image_path;
            Thread threadA = new Thread(new ParameterizedThreadStart(ExecuteA));
            threadA.Start();
        }
        private void setControlEggSti()
        {
            eggs = ic.ivfDB.eggsDB.selectByPk1(txtEggStiId.Text);
            if (eggs.egg_sti_id.Equals(""))
            {
                eggs = ic.ivfDB.eggsDB.selectByVsId(vn);
                if (eggs.egg_sti_id.Equals(""))
                {
                    eggs = ic.ivfDB.eggsDB.selectByPttId(txtPttId.Text);
                    {
                        txtEggStiId.Value = eggs.egg_sti_id;
                    }
                }
                else
                {
                    txtEggStiId.Value = eggs.egg_sti_id;
                }
            }
            else
            {
                ic.setC1Combo(cboEggStiDtr, eggs.doctor_id);
                txtEggStiVisitLMP.Value = eggs.lmp_date;
            }
            txtEggStiVisitLMP.Value = eggs.lmp_date;
            txtEggStiDay.Value = eggs.day_start;
            txtEggStiOPUDate.Value = eggs.opu_date;
            txtEggStiOPUTime.Value = eggs.opu_time;
            txtEggStiEmbryoTranferDate.Value = eggs.fet;

            chkAbnormal.Checked = eggs.status_abnormal.Equals("1") ? true : false;
            chkTyping.Checked = eggs.status_typing.Equals("1") ? true : false;
            chkEggStiOther.Checked = eggs.status_typing_other.Equals("1") ? true : false;
            chkEggStiInfection.Checked = eggs.status_infectious.Equals("1") ? true : false;
            chkAmh.Checked = eggs.status_add_lab.Equals("1") ? true : false;
            txtAbnormal1.Value = eggs.abnormal1;
            txtAbnormal2.Value = eggs.abnormal2;
            ic.setC1ComboByName(cboEggStiOther, eggs.typing_other);
            ic.setC1ComboByName(cboEggStiBhcg, eggs.bhcg_test);
            ic.setC1ComboByName(cboEggStiAmh, eggs.add_lab);
            txtEggStiG.Value = eggs.g;
            txtEggStiP.Value = eggs.p;
            txtEggStiA.Value = eggs.a;
            ic.setC1Combo(cboEggStiDtr, eggs.doctor_id);

            txtLmp.Value = ptt.lmp;
            if (txtEggStiVisitLMP.Text.Equals(""))
            {
                txtEggStiVisitLMP.Value = ptt.lmp;
            }
            setGrfEggStiDay();
        }
        private void setControlPmh()
        {
            PatientMedicalHistory pmh = new PatientMedicalHistory();
            pmh = ic.ivfDB.pmhDB.selectByPttId(txtPttId.Text);
            txtPmhId.Value = pmh.patient_medical_history_id;
            txtPmhPttName.Value = ptt.Name;
            txtPmhSex.Value = ptt.f_sex_id.Equals("1") ? "ชาย" : "หญิง";
            chkPmhSingle.Checked = ptt.f_patient_marriage_status_id.Equals("2110000008") ? true : false;
            chkPmhMarried.Checked = ptt.f_patient_marriage_status_id.Equals("2110000009") ? true : false;

            chkPmhConPill.Checked = pmh.contraception.Equals("1") ? true : false;
            chkPmhConIud.Checked = pmh.contraception.Equals("2") ? true : false;
            chkPmhConInj.Checked = pmh.contraception.Equals("3") ? true : false;
            chkPmhConCondom.Checked = pmh.contraception.Equals("4") ? true : false;
            chkPmhConOther.Checked = pmh.contraception.Equals("5") ? true : false;
            if (chkPmhConOther.Checked)
            {
                txtPmhConOther.Enabled = true;
            }
            else
            {
                txtPmhConOther.Enabled = false;
            }
            txtPmhPttMaleName.Value = pmh.couple_name;
            txtPmhConOther.Value = pmh.contraception_other;
            //txtPmhMarriedYear.Value = pmh.m

            chkPmhDrugNo.Checked = pmh.drug_allergy.Equals("1") ? true : false;
            chkPmhDrugYes.Checked = pmh.drug_allergy.Equals("2") ? true : false;
            if (chkPmhDrugYes.Checked)
            {
                txtPmhDrug.Enabled = true;
            }
            else
            {
                txtPmhDrug.Enabled = false;
            }
            txtPmhDrug.Value = pmh.drug_allergy_other;

            chkPmhPastDia.Checked = pmh.past_illness_dialeteles.Equals("1") ? true : false;
            chkPmhPastHyp.Checked = pmh.past_illness_hypertention.Equals("1") ? true : false;
            chkPmhPastLiv.Checked = pmh.past_illness_liver_disease.Equals("1") ? true : false;
            chkPmhPastTub.Checked = pmh.past_illness_tuberculosis.Equals("1") ? true : false;
            chkPmhPastAsi.Checked = pmh.past_illness_asihma.Equals("1") ? true : false;
            chkPmhPastSie.Checked = pmh.past_illness_siezure.Equals("1") ? true : false;
            chkPmhPastSti.Checked = pmh.past_illness_sti.Equals("1") ? true : false;
            chkPmhPastThy.Checked = pmh.past_illness_thyroid_disorders.Equals("1") ? true : false;
            chkPmhPastOther.Checked = pmh.past_illness_other.Equals("1") ? true : false;
            if (chkPmhPastOther.Checked)
            {
                txtPmhPastOther.Enabled = true;
            }
            else
            {
                txtPmhPastOther.Enabled = false;
            }
            txtPmhPastOther.Value = pmh.past_illness_other_other;

            chkPmhSubsNo.Checked = pmh.substance_abuse.Equals("1") ? true : false;
            chkPmhSubsYes.Checked = pmh.substance_abuse.Equals("2") ? true : false;
            if (chkPmhSubsYes.Checked)
            {
                txtPmhSubs.Enabled = true;
            }
            else
            {
                txtPmhSubs.Enabled = false;
            }
            txtPmhSubs.Value = pmh.substance_abuse_other;

            chkPmhSurgNo.Checked = pmh.substance_abuse.Equals("1") ? true : false;
            chkPmhSurgYes.Checked = pmh.substance_abuse.Equals("2") ? true : false;
            if (chkPmhSurgYes.Checked)
            {
                txtPmhSurg.Enabled = true;
            }
            else
            {
                txtPmhSurg.Enabled = false;
            }
            txtPmhSurg.Value = pmh.surgical_history_other;

            chkPmhTypePri.Checked = pmh.type_of_infertility.Equals("1") ? true : false;
            chkPmhTypeSec.Checked = pmh.type_of_infertility.Equals("2") ? true : false;
            if (chkPmhTypeSec.Checked)
            {
                txtPmhType.Enabled = true;
            }
            else
            {
                txtPmhType.Enabled = false;
            }
            txtPmhType.Value = pmh.type_of_infertility_other;

            chkPmhProvNo.Checked = pmh.previous_treatment.Equals("1") ? true : false;
            chkPmhProvYes.Checked = pmh.previous_treatment.Equals("2") ? true : false;
            if (chkPmhTypeSec.Checked)
            {
                txtPmhProv.Enabled = true;
            }
            else
            {
                txtPmhProv.Enabled = false;
            }
            txtPmhProv.Value = pmh.previous_treatment;
            txtPmhType.Value = pmh.previous_treatment_other;
            txtPmhTypeDura.Value = "";

            chkPmhMenReg.Checked = pmh.menstrution.Equals("1") ? true : false;
            chkPmhMenIrr.Checked = pmh.menstrution.Equals("2") ? true : false;
            if (chkPmhMenIrr.Checked)
            {
                txtPmhMenDay.Enabled = true;
                txtPmhMenInter.Enabled = true;
                txtPmhMenAmt.Enabled = true;
            }
            else
            {
                txtPmhMenDay.Enabled = false;
                txtPmhMenInter.Enabled = true;
                txtPmhMenAmt.Enabled = true;
            }
            chkPmhMenLmp.Checked = pmh.menstrution.Equals("4") ? true : false;
            if (chkPmhMenLmp.Checked)
            {
                txtPmhMenLmp.Enabled = true;
            }
            else
            {
                txtPmhMenLmp.Enabled = false;
            }
            txtPmhMenLmp.Value = pmh.menstrution_lmp;
            txtPmhMenDay.Value = pmh.menstrution_days;
            txtPmhMenInter.Value = pmh.menstrution_interval;
            txtPmhMenAmt.Value = pmh.menstrution_amount;

            chkPmhPapsNo.Checked = pmh.pap_smear.Equals("1") ? true : false;
            chkPmhPapsYes.Checked = pmh.pap_smear.Equals("2") ? true : false;
            if (chkPmhSubsYes.Checked)
            {
                txtPmhPaps.Enabled = true;
            }
            else
            {
                txtPmhPaps.Enabled = false;
            }
            txtPmhPaps.Value = pmh.pap_smear_other;
            chkPmhPttMaleDrugNo.Checked = pmh.male_drug_allery.Equals("1") ? true : false;
            chkPmhPttMaleDrugYes.Checked = pmh.male_drug_allery.Equals("2") ? true : false;
            if (chkPmhDrugYes.Checked)
            {
                txtPmhPttMaleDrug.Enabled = true;
            }
            else
            {
                txtPmhPttMaleDrug.Enabled = false;
            }
            txtPmhPttMaleDrug.Value = pmh.drug_allergy_other;

            chkPmhPttMalePastDia.Checked = pmh.male_past_illness_dialeteles.Equals("1") ? true : false;
            chkPmhPttMalePastHyp.Checked = pmh.male_past_illness_hypertention.Equals("1") ? true : false;
            chkPmhPttMalePastLiv.Checked = pmh.male_past_illness_liver_disease.Equals("1") ? true : false;
            chkPmhPttMalePastTub.Checked = pmh.male_past_illness_tuberculosis.Equals("1") ? true : false;
            chkPmhPttMalePastAsi.Checked = pmh.male_past_illness_asihma.Equals("1") ? true : false;
            chkPmhPttMalePastSie.Checked = pmh.male_past_illness_siezure.Equals("1") ? true : false;
            chkPmhPttMalePastSti.Checked = pmh.male_past_illness_sti.Equals("1") ? true : false;
            chkPmhPttMalePastThy.Checked = pmh.male_past_illness_thyroid_disorders.Equals("1") ? true : false;
            chkPmhPttMalePastOther.Checked = pmh.male_past_illness_other.Equals("1") ? true : false;
            if (chkPmhPttMalePastOther.Checked)
            {
                txtPmhPttMalePastOther.Enabled = true;
            }
            else
            {
                txtPmhPttMalePastOther.Enabled = false;
            }
            txtPmhPttMalePastOther.Value = pmh.male_past_illness_other_other;

            chkPmhPttMaleSubsNo.Checked = pmh.male_substance_abuse.Equals("1") ? true : false;
            chkPmhPttMaleSubsYes.Checked = pmh.male_substance_abuse.Equals("2") ? true : false;
            if (chkPmhPttMaleSubsYes.Checked)
            {
                txtPmhPttMaleSubs.Enabled = true;
            }
            else
            {
                txtPmhPttMaleSubs.Enabled = false;
            }
            txtPmhPttMaleSubs.Value = pmh.male_substance_abuse_other;

            chkPmlPttMaleSmokingNo.Checked = pmh.male_smoking.Equals("1") ? true : false;
            chkPmlPttMaleSmokingYes.Checked = pmh.male_smoking.Equals("2") ? true : false;
            if (chkPmlPttMaleSmokingYes.Checked)
            {
                txtPmlPttMaleSmoking.Enabled = true;
            }
            else
            {
                txtPmlPttMaleSmoking.Enabled = false;
            }
            txtPmlPttMaleSmoking.Value = pmh.male_smoking_other;

            chkPmlPttMaleDrinkingNo.Checked = pmh.male_drinking.Equals("1") ? true : false;
            chkPmlPttMaleDrinkingYes.Checked = pmh.male_drinking.Equals("2") ? true : false;
            if (chkPmlPttMaleDrinkingYes.Checked)
            {
                txtPmlPttMaleDrinking.Enabled = true;
            }
            else
            {
                txtPmlPttMaleDrinking.Enabled = false;
            }
            txtPmlPttMaleDrinking.Value = pmh.male_drinking_other;

            chkPmlPttMaleDrugNo.Checked = pmh.male_drug.Equals("1") ? true : false;
            chkPmlPttMaleDrugYes.Checked = pmh.male_drug.Equals("2") ? true : false;
            if (chkPmlPttMaleDrugYes.Checked)
            {
                txtPmlPttMaleDrinking.Enabled = true;
            }
            else
            {
                txtPmlPttMaleDrinking.Enabled = false;
            }
            txtPmlPttMaleDrug.Value = pmh.male_drug_other;

            chkPmlPttMaleSurgiNo.Checked = pmh.male_surg.Equals("1") ? true : false;
            chkPmlPttMaleSurgiYes.Checked = pmh.male_surg.Equals("2") ? true : false;
            if (chkPmlPttMaleSurgiYes.Checked)
            {
                txtPmlPttMaleSurgi.Enabled = true;
            }
            else
            {
                txtPmlPttMaleSurgi.Enabled = false;
            }
            txtPmlPttMaleSurgi.Value = pmh.male_surg_other;

            chkPmlPttMaleTreatNo.Checked = pmh.male_infertility.Equals("1") ? true : false;
            chkPmlPttMaleTreatYes.Checked = pmh.male_infertility.Equals("2") ? true : false;
            if (chkPmlPttMaleTreatYes.Checked)
            {
                txtPmlPttMaleTreat.Enabled = true;
            }
            else
            {
                txtPmlPttMaleTreat.Enabled = false;
            }
            txtPmlPttMaleTreat.Value = pmh.male_infertility_other;

            txtPmhPttMaleName_1.Value = pmh.male_name;
        }
        private void setPMh()
        {
            pmh.patient_medical_history_id = txtPmhId.Text;
            pmh.t_patient_id = txtPttId.Text;
            pmh.patient_hn = txtHn.Text;
            pmh.patient_name = txtPmhPttName.Text;
            pmh.couple_name = txtPmhPttMaleName.Text;
            pmh.active = "1";
            pmh.remark = "";
            pmh.occupation = cboOccup.Text;
            pmh.date_create = "";
            pmh.date_modi = "";
            pmh.date_cancel = "";
            pmh.user_create = "";
            pmh.user_modi = "";
            pmh.user_cancel = "";
            pmh.contraception = chkPmhConPill.Checked ? "1" : chkPmhConIud.Checked ? "2" : chkPmhConInj.Checked ? "3" : chkPmhConCondom.Checked ? "4" : chkPmhConOther.Checked ? "5" : "";
            pmh.contraception_other = txtPmhConOther.Text;
            pmh.drug_allergy = chkPmhDrugNo.Checked ? "1" : chkPmhDrugYes.Checked ? "2" : "";
            pmh.drug_allergy_other = txtPmhDrug.Text;
            pmh.past_illness_dialeteles = chkPmhPastDia.Checked ? "1" : "";
            pmh.past_illness_asihma = chkPmhPastAsi.Checked ? "1" : "";
            //pmh.t_patient_id = "";
            pmh.past_illness_hypertention = chkPmhPastHyp.Checked ? "1" : "";
            pmh.past_illness_liver_disease = chkPmhPastLiv.Checked ? "1" : "";
            pmh.past_illness_tuberculosis = chkPmhPastTub.Checked ? "1" : "";
            pmh.past_illness_siezure = chkPmhPastSie.Checked ? "1" : "";
            pmh.past_illness_sti = chkPmhPastSti.Checked ? "1" : "";
            pmh.past_illness_thyroid_disorders = chkPmhPastThy.Checked ? "1" : "";
            pmh.past_illness_other = txtPmhPastOther.Text;
            pmh.substance_abuse = chkPmhSubsNo.Checked ? "1" : chkPmhSubsYes.Checked ? "2" : "";
            pmh.substance_abuse_other = txtPmhSubs.Text;
            pmh.surgical_history = chkPmhSurgNo.Checked ? "1" : chkPmhSurgYes.Checked ? "2" : "";
            pmh.surgical_history_other = txtPmhSurg.Text;
            pmh.type_of_infertility = chkPmhTypePri.Checked ? "1" : chkPmhTypeSec.Checked ? "2" : "";
            pmh.type_of_infertility_other = txtPmhType.Text;
            pmh.menstrution = chkPmhMenReg.Checked ? "1" : chkPmhMenIrr.Checked ? "2" : chkPmhMenLmp.Checked ? "4" : "";
            pmh.menstrution_days = txtPmhMenDay.Text;
            pmh.menstrution_interval = txtPmhMenInter.Text;
            pmh.menstrution_amount = txtPmhMenAmt.Text;
            pmh.menstrution_lmp = txtPmhMenLmp.Text;
            pmh.previous_treatment = chkPmhProvNo.Checked ? "1" : chkPmhProvYes.Checked ? "2" : "";
            pmh.previous_treatment_other = txtPmhProv.Text;
            pmh.pap_smear = chkPmhPapsNo.Checked ? "1" : chkPmhPapsYes.Checked ? "2" : "";
            pmh.pap_smear_other = txtPmhPaps.Text;
            pmh.male_name = txtPmhPttMaleName_1.Text;
            pmh.male_drug_allery = chkPmhPttMaleDrugNo.Checked ? "1" : chkPmhPttMaleDrugYes.Checked ? "2" : "";
            pmh.male_drug_allery_other = txtPmhPttMaleDrug.Text;
            pmh.male_past_illness_dialeteles = chkPmhPttMalePastDia.Checked ? "1" : "";
            pmh.male_past_illness_asihma = chkPmhPttMalePastAsi.Checked ? "1" : "";
            pmh.male_past_illness_hypertention = chkPmhPttMalePastHyp.Checked ? "1" : "";
            pmh.male_past_illness_liver_disease = chkPmhPttMalePastLiv.Checked ? "1" : "";
            pmh.male_past_illness_tuberculosis = chkPmhPttMalePastTub.Checked ? "1" : "";
            pmh.male_past_illness_siezure = chkPmhPttMalePastSie.Checked ? "1" : "";
            pmh.male_past_illness_sti = chkPmhPttMalePastSti.Checked ? "1" : "";
            pmh.male_past_illness_thyroid_disorders = chkPmhPttMalePastThy.Checked ? "1" : "";
            pmh.male_past_illness_other = txtPmhPttMalePastOther.Text;
            pmh.male_substance_abuse = chkPmhPttMaleSubsNo.Checked ? "1" : chkPmhPttMaleSubsYes.Checked ? "2" : "";
            pmh.male_substance_abuse_other = txtPmhPttMaleSubs.Text; ;
            pmh.male_smoking = chkPmlPttMaleSmokingNo.Checked ? "1" : chkPmlPttMaleSmokingYes.Checked ? "2" : "";
            pmh.male_smoking_other = txtPmlPttMaleSmoking.Text;
            pmh.male_drinking = chkPmlPttMaleDrinkingNo.Checked ? "1" : chkPmlPttMaleDrinkingYes.Checked ? "2" : "";
            pmh.male_drinking_other = txtPmlPttMaleDrinking.Text;
            pmh.male_drug = chkPmlPttMaleDrugNo.Checked ? "1" : chkPmlPttMaleDrugYes.Checked ? "2" : "";
            pmh.male_drug_other = txtPmlPttMaleDrug.Text;
            pmh.male_surg = chkPmlPttMaleSurgiNo.Checked ? "1" : chkPmlPttMaleSurgiYes.Checked ? "2" : "";
            pmh.male_surg_other = txtPmlPttMaleSurgi.Text;
            pmh.male_infertility = chkPmlPttMaleTreatNo.Checked ? "1" : chkPmlPttMaleTreatYes.Checked ? "2" : "";
            pmh.male_infertility_other = txtPmlPttMaleTreat.Text;
            pmh.past_illness_other_other = "";
            pmh.male_past_illness_other_other = "";
        }
        private void setEggSti()
        {
            eggs.egg_sti_id = txtEggStiId.Text;
            eggs.lmp_date = ic.datetoDB(txtEggStiVisitLMP.Text);
            eggs.nurse_t_egg_sticol = "";
            eggs.status_g = "";
            eggs.p = txtEggStiP.Text;
            eggs.active = "";
            eggs.remark = "";
            eggs.a = txtEggStiA.Text;
            eggs.date_create = "";
            eggs.date_modi = "";
            eggs.date_cancel = "";
            eggs.user_create = "";
            eggs.user_modi = "";
            eggs.user_cancel = "";
            eggs.g = txtEggStiG.Text;
            eggs.opu_date = ic.datetoDB(txtEggStiOPUDate.Text);
            eggs.opu_time = txtEggStiOPUTime.Text;
            eggs.et = "";
            eggs.fet = "";
            eggs.bhcg_test = cboEggStiBhcg.Text;
            eggs.t_patient_id = txtPttId.Text;
            eggs.t_visit_id = txtVsId.Text;
            eggs.egg_sti_date = DateTime.Now.Year.ToString() + "-" + DateTime.Now.ToString("MM-dd");
            eggs.doctor_id = cboEggStiDtr.SelectedItem == null ? "" : ((ComboBoxItem)cboEggStiDtr.SelectedItem).Value;
            eggs.status_abnormal = chkAbnormal.Checked ? "1" : "0";
            eggs.abnormal1 = txtAbnormal1.Text;
            eggs.abnormal2 = txtAbnormal2.Text;
            eggs.status_typing = chkTyping.Checked ? "1" : "0";
            eggs.status_typing_other = chkEggStiOther.Checked ? "1" : "0";
            eggs.typing_other = cboEggStiOther.Text;
            eggs.status_infectious = chkEggStiInfection.Checked ? "1" : "0";
            eggs.status_add_lab = chkAmh.Checked ? "1" : "0";
            eggs.add_lab = cboEggStiAmh.Text;
            eggs.day_start = txtEggStiDay.Text;
        }
        private void BtnGenEggSti_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String lmpdate = "",err="";
            DateTime lmpdate1 = new DateTime();
            lmpdate = ic.datetoDB(txtEggStiVisitLMP.Text);
            ic.logw.WriteLog("g","BtnGenEggSti_Click HN "+txtHn.Text+" VN "+txtVn.Text);
            if (!DateTime.TryParse(lmpdate, out lmpdate1))
            {
                MessageBox.Show("วันที่ LMP Date ไม่ถูกต้อง ", "");
                return;
            }
            if (MessageBox.Show("ต้องการ Day Egg Sti  \nวันที่ LMP Date " + txtEggStiVisitLMP.Text, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setEggSti();
                ic.cStf.staff_id = "";
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    long chk = 0, chk1 = 0, max=0;
                    ic.logw.WriteLog("g", "BtnGenEggSti_Click HN " + txtHn.Text + " VN " + txtVn.Text);
                    String re = ic.ivfDB.eggsDB.insertEggSti(eggs, ic.cStf.staff_id);
                    if (long.TryParse(re, out chk))
                    {
                        if(chk!=1)
                            txtEggStiId.Value = re;
                        ic.ivfDB.eggsdDB.VoidEggSti(txtEggStiId.Text, ic.cStf.staff_id);
                        try
                        {
                            lmpdate = ic.datetoDB(txtEggStiVisitLMP.Text);
                            if (DateTime.TryParse(lmpdate, out lmpdate1))
                            {
                                //if (txtEggStiDay.Text.Equals("1"))
                                //{

                                //}
                                //else
                                //{
                                //long.TryParse(txtEggStiDay.Text, out chk1);       //      -0005
                                //chk1++;
                                //lmpdate1 = lmpdate1.AddDays(chk1);
                                //}
                                //max = 17 + chk1;          //-0005
                                max = 17;       //+0005
                                for (long i = 1; i <= max; i++)
                                {
                                    if (i != 1)       //+0005
                                    {       //+0005
                                        lmpdate1 = lmpdate1.AddDays(1);       //+0005
                                    }       //+0005
                                    EggStiDay eggsd = new EggStiDay();
                                    eggsd.egg_sti_day_id = "";
                                    eggsd.egg_sti_id = txtEggStiId.Text;
                                    eggsd.day1 = i.ToString();
                                    eggsd.date = ic.datetoDB(lmpdate1.Year.ToString() + "-" + lmpdate1.ToString("MM-dd"));
                                    eggsd.e2 = "";
                                    eggsd.lh = "";
                                    eggsd.active = "";
                                    eggsd.remark = "";
                                    eggsd.fsh = "";
                                    eggsd.date_create = "";
                                    eggsd.date_modi = "";
                                    eggsd.date_cancel = "";
                                    eggsd.user_create = "";
                                    eggsd.user_modi = "";
                                    eggsd.user_cancel = "";
                                    eggsd.prolactin = "";
                                    eggsd.rt_ovary_1 = "";
                                    eggsd.rt_ovary_2 = "";
                                    eggsd.lt_ovary_1 = "";
                                    eggsd.lt_ovary_2 = "";
                                    eggsd.endo = "";
                                    eggsd.medication = "";
                                    eggsd.medication2 = "";
                                    chk1++;
                                    ic.ivfDB.eggsdDB.insertEggStiDay(eggsd, ic.cStf.staff_id);
                                }
                            }
                        }
                        catch(Exception ex)
                        {
                            ic.logw.WriteLog("e", "BtnGenEggSti_Click error " + ex.Message);
                        }
                        
                        setControlEggSti();
                    }
                    //else
                    //{
                    //    ic.logw.WriteLog("BtnGenEggSti_Click error " + re);
                    //}
                }
            }
        }
        private void initGrfEggSti()
        {
            grfEggsd = new C1FlexGrid();
            grfEggsd.Font = fEdit;
            grfEggsd.Dock = System.Windows.Forms.DockStyle.Fill;
            grfEggsd.Location = new System.Drawing.Point(0, 0);
            grfEggsd.ChangeEdit += GrfEggsd_ChangeEdit;

            //FilterRow fr = new FilterRow(grfExpn);

            pnEggSti.Controls.Add(grfEggsd);

            theme1.SetTheme(grfEggsd, "Office2010Blue");
        }
        private void GrfEggsd_ChangeEdit(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfEggsd.Row == null) return;
            if (grfEggsd.Row < 0) return;
            grfEggsd[grfEggsd.Row, colEggEdit] = "1";
            grfEggsd.Rows[grfEggsd.Row].StyleNew.BackColor = color;
        }
        private void setGrfEggStiDay()
        {
            //grfDept.Rows.Count = 7;
            grfEggsd.Clear();
            DataTable dt = new DataTable();

            dt = ic.ivfDB.eggsdDB.selectByEggStiId(txtEggStiId.Text);
            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfEggsd.Rows.Count = 1;
            grfEggsd.Cols.Count = 16;
            C1TextBox txt = new C1TextBox();
            C1ComboBox cboday3 = new C1ComboBox();
            C1ComboBox cboday3desc1 = new C1ComboBox();
            C1ComboBox cbomedi = new C1ComboBox();
            C1ComboBox cbomedi2 = new C1ComboBox();
            cboday3.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboday3.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboday3desc1.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboday3desc1.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbomedi.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbomedi.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbomedi2.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbomedi2.AutoCompleteSource = AutoCompleteSource.ListItems;
            ic.ivfDB.fdtDB.setCboEggStiRtOvary1(cboday3, "");
            ic.ivfDB.fdtDB.setCboEggStiRtOvary2(cboday3desc1, "");
            ic.ivfDB.fdtDB.setCboEggStiMedication(cbomedi, "");
            ic.ivfDB.fdtDB.setCboEggStiMedication2(cbomedi2, "");
            grfEggsd.Cols[colEggLt1].Editor = cboday3;
            grfEggsd.Cols[colEggLt2].Editor = cboday3desc1;
            grfEggsd.Cols[colEggRt1].Editor = cboday3;
            grfEggsd.Cols[colEggRt2].Editor = cboday3desc1;
            grfEggsd.Cols[colEggMedi].Editor = cbomedi;
            grfEggsd.Cols[colEggMedi2].Editor = cbomedi2;
            grfEggsd.Cols[colEggDay].Width = 40;
            grfEggsd.Cols[colEggDate].Width = 100;
            grfEggsd.Cols[colEggE2].Width = 80;
            grfEggsd.Cols[colEggLH].Width = 50;
            grfEggsd.Cols[colEggFSH].Width = 50;
            grfEggsd.Cols[colEggProlactin].Width = 50;
            grfEggsd.Cols[colEggRt1].Width = 160;
            grfEggsd.Cols[colEggRt2].Width = 160;
            grfEggsd.Cols[colEggLt1].Width = 160;
            grfEggsd.Cols[colEggLt2].Width = 160;
            grfEggsd.Cols[colEggEndo].Width = 50;
            grfEggsd.Cols[colEggMedi].Width = 160;
            grfEggsd.Cols[colEggMedi2].Width = 160;

            grfEggsd.Cols[colEggE2].AllowSorting = false;
            grfEggsd.Cols[colEggLH].AllowSorting = false;
            grfEggsd.Cols[colEggFSH].AllowSorting = false;

            grfEggsd.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";
            grfEggsd.Cols[colEggDay].Caption = "day";
            grfEggsd.Cols[colEggDate].Caption = "date";
            grfEggsd.Cols[colEggE2].Caption = "E2";
            grfEggsd.Cols[colEggLH].Caption = "LH";
            grfEggsd.Cols[colEggFSH].Caption = "FSH";
            grfEggsd.Cols[colEggProlactin].Caption = "Prolactin";
            grfEggsd.Cols[colEggRt1].Caption = "Rt ovary";
            grfEggsd.Cols[colEggRt2].Caption = "Rt ovary";
            grfEggsd.Cols[colEggLt1].Caption = "Lt ovary";
            grfEggsd.Cols[colEggLt2].Caption = "Lt ovary";
            grfEggsd.Cols[colEggEndo].Caption = "Endo";
            grfEggsd.Cols[colEggMedi].Caption = "Medication";
            grfEggsd.Cols[colEggMedi2].Caption = "Medication2";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            int i = 1;
            String staffId = "", checkId = "", dateday2 = "";
            foreach (DataRow row in dt.Rows)
            {
                Row row1 = grfEggsd.Rows.Add();
                //staffId = row[ic.ivfDB.opuEmDevDB.opuEmDev.staff_id].ToString();
                //checkId = row[ic.ivfDB.opuEmDevDB.opuEmDev.checked_id].ToString();
                row1[colEggId] = row[ic.ivfDB.eggsdDB.eggsd.egg_sti_day_id].ToString();
                row1[colEggDay] = row[ic.ivfDB.eggsdDB.eggsd.day1].ToString();
                row1[colEggDate] = ic.datetoShow(row[ic.ivfDB.eggsdDB.eggsd.date].ToString());
                row1[colEggE2] = row[ic.ivfDB.eggsdDB.eggsd.e2].ToString();
                row1[colEggLH] = row[ic.ivfDB.eggsdDB.eggsd.lh].ToString();
                row1[colEggFSH] = row[ic.ivfDB.eggsdDB.eggsd.fsh].ToString();
                row1[colEggProlactin] = row[ic.ivfDB.eggsdDB.eggsd.prolactin].ToString();
                row1[colEggRt1] = row[ic.ivfDB.eggsdDB.eggsd.rt_ovary_1].ToString();
                row1[colEggRt2] = row[ic.ivfDB.eggsdDB.eggsd.rt_ovary_2].ToString();
                row1[colEggLt1] = row[ic.ivfDB.eggsdDB.eggsd.lt_ovary_1].ToString();
                row1[colEggLt2] = row[ic.ivfDB.eggsdDB.eggsd.lt_ovary_2].ToString();
                row1[colEggEndo] = row[ic.ivfDB.eggsdDB.eggsd.endo].ToString();
                row1[colEggMedi] = row[ic.ivfDB.eggsdDB.eggsd.medication].ToString();
                row1[colEggMedi2] = row[ic.ivfDB.eggsdDB.eggsd.medication2].ToString();
                row1[colEggEdit] = "";
                row1[0] = i;
                i++;
            }
            grfEggsd.Rows.Add();
            grfEggsd.Cols[colEggId].Visible = false;
            grfEggsd.Cols[colEggEdit].Visible = false;
            grfEggsd.Cols[colEggDay].AllowEditing = false;
            grfEggsd.Cols[colEggDate].AllowEditing = false;
            grfEggsd.Cols[colEggDay].AllowSorting = false;
            grfEggsd.Cols[colEggDate].AllowSorting = false;
            grfEggsd.Cols[colEggE2].AllowSorting = false;
            grfEggsd.Cols[colEggLH].AllowSorting = false;
            grfEggsd.Cols[colEggFSH].AllowSorting = false;
            grfEggsd.Cols[colEggProlactin].AllowSorting = false;
            grfEggsd.Cols[colEggRt1].AllowSorting = false;
            grfEggsd.Cols[colEggRt2].AllowSorting = false;
            grfEggsd.Cols[colEggLt1].AllowSorting = false;
            grfEggsd.Cols[colEggLt2].AllowSorting = false;
            grfEggsd.Cols[colEggEndo].AllowSorting = false;
            grfEggsd.Cols[colEggMedi].AllowSorting = false;
            grfEggsd.Cols[colEggMedi2].AllowSorting = false;
            grfEggsd.AutoClipboard = true;
        }
        private void ContextMenu_edit_apm(object sender, System.EventArgs e)
        {
            String chk = "", name = "", id = "";
            id = grfpApmVisit[grfpApmVisit.Row, colApmId] != null ? grfpApmVisit[grfpApmVisit.Row, colApmId].ToString() : "";
            pApmId = id;
            setControlApm();

        }
        private void ContextMenu_edit_papm1(object sender, System.EventArgs e)
        {
            String chk = "", name = "", id = "";
            id = grfpApmAll[grfpApmAll.Row, colApmId] != null ? grfpApmAll[grfpApmAll.Row, colApmId].ToString() : "";
            pApmId = id;
            setControlApm();

        }
        private void setGrfpApmVisit()
        {
            //grfDept.Rows.Count = 7;
            grfpApmVisit.Clear();
            DataTable dt = new DataTable();

            dt = ic.ivfDB.pApmDB.selectByVisitId(vn);
            if (dt.Rows.Count <= 0)
            {
                VisitOld vsOld = new VisitOld();
                vsOld = ic.ivfDB.ovsDB.selectByPk1(vn);
                Patient ptt = new Patient();
                ptt = ic.ivfDB.pttDB.selectByIdOld(vsOld.PID);
                dt = ic.ivfDB.pApmDB.selectByPtt(ptt.t_patient_id);
            }

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfpApmVisit.Rows.Count = 1;
            grfpApmVisit.Cols.Count = 14;
            C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfpApmVisit.Cols[colApmNotice].Editor = txt;
            grfpApmVisit.Cols[colApmAppointment].Editor = txt;
            grfpApmVisit.Cols[colApmDoctor].Editor = txt;
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

            grfpApmVisit.Cols[colApmDate].Width = 100;
            grfpApmVisit.Cols[colApmTime].Width = 80;
            grfpApmVisit.Cols[colApmAppointment].Width = 120;
            grfpApmVisit.Cols[colApmDoctor].Width = 100;
            grfpApmVisit.Cols[colApmSp].Width = 80;
            grfpApmVisit.Cols[colApmNotice].Width = 200;
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

            grfpApmVisit.Cols[colApmDate].Caption = "Date";
            grfpApmVisit.Cols[colApmTime].Caption = "time";
            grfpApmVisit.Cols[colApmAppointment].Caption = "นัด";
            grfpApmVisit.Cols[colApmDoctor].Caption = "Doctor";
            grfpApmVisit.Cols[colApmSp].Caption = "จุดบริการ";
            grfpApmVisit.Cols[colApmNotice].Caption = "แจ้ง";
            grfpApmVisit.Cols[colE2].Caption = "E2";
            grfpApmVisit.Cols[colLh].Caption = "LH";
            grfpApmVisit.Cols[colEndo].Caption = "Endo";
            grfpApmVisit.Cols[colPrl].Caption = "PRL";
            grfpApmVisit.Cols[colFsh].Caption = "FSH";
            grfpApmVisit.Cols[colRt].Caption = "Rt";
            grfpApmVisit.Cols[colLt].Caption = "Lt";

            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("แก้ไข Appointment", new EventHandler(ContextMenu_edit_apm));
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
                row1[colApmId] = row[ic.ivfDB.pApmDB.pApm.t_patient_appointment_id].ToString();
                row1[colApmDate] = ic.datetoShow(row[ic.ivfDB.pApmDB.pApm.patient_appointment_date].ToString());
                row1[colApmTime] = row[ic.ivfDB.pApmDB.pApm.patient_appointment_time].ToString();
                row1[colApmAppointment] = row[ic.ivfDB.pApmDB.pApm.patient_appointment].ToString();
                row1[colApmDoctor] = row[ic.ivfDB.pApmDB.pApm.dtr_name];
                row1[colApmSp] = row["service_point_description"].ToString();
                row1[colApmNotice] = row[ic.ivfDB.pApmDB.pApm.patient_appointment_notice].ToString();

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
            grfpApmVisit.Cols[colApmId].Visible = false;
            theme1.SetTheme(grfpApmVisit, ic.theme);

        }
        private void setAppointmentOld()
        {
            pApmO.ID = txtApmIDOld.Text;
            pApmO.PID = txtPttIdOld.Text;
            pApmO.PIDS = txtHn.Text;
            pApmO.AppDate = ic.datetoDB(txtApmDatepApm.Text);
            pApmO.AppTime = cboApmTimepApm.Text;
            pApmO.Doctor = cboDoctor.Text;
            pApmO.Comment = txtApmRemark.Text;
            pApmO.MobilePhoneNo = "";
            pApmO.DateOfBirth = ic.datetoDB(txtDob.Text);
            pApmO.HormoneTest = chkApmHormoneTest.Checked ? "1" : "0";
            pApmO.BetaHCG = chkApmHCG.Checked ? "1" : "0";
            pApmO.et = chkApmEt.Checked ? "1" : "0";
            pApmO.OPU = chkApmOpu.Checked ? "1" : "0";
            pApmO.TVS = chkApmTvs.Checked ? "1" : "0";
            pApmO.sperm_colloect = chkApmSpermCollect.Checked ? "1" : "0";
            pApmO.ET_FET = chkApmFet.Checked ? "1" : "0";
            pApmO.Other = chkApmOther.Checked ? "1" : "0";
            pApmO.et_time = cboApmETTime.Text;
            pApmO.ET_FET_Time = cboApmFETTime.Text;
            pApmO.tvs_time = cboApmTvsTime.Text;
            pApmO.OPUTime = cboApmOPUTime.Text;
            pApmO.day1 = txtApmTvsDay.Text;
            pApmO.OtherRemark = txtApmOther.Text;
            pApmO.Status = "1";
            pApmO.OPURemark = txtApmOPURemark.Text;
            pApmO.PatientName = txtApmName.Text;
            pApmO.PName = txtApmName.Text;
            pApmO.PSurname = ptt.patient_firstname_e;
        }
        private Boolean setPatientAppointment()
        {
            Boolean chk = false;
            pApm.t_patient_appointment_id = txtApmID.Text;
            pApm.t_patient_id = txtPttId.Text;
            pApm.patient_appoint_date_time = System.DateTime.Now.Year.ToString() + "-" + System.DateTime.Now.ToString("MM-dd");
            DateTime dt = new DateTime();
            if (DateTime.TryParse(txtApmDatepApm.Text, out dt))
            {
                pApm.patient_appointment_date = ic.datetoDB(txtApmDatepApm.Text);
            }
            else
            {
                chk = false;
            }
            if (cboApmTimepApm.Text.Equals(""))
            {
                chk = false;
            }
            pApm.patient_appointment_time = cboApmTimepApm.Text;
            pApm.patient_appointment = txtApmAppointment.Text;
            pApm.patient_appointment_doctor = cboApmDtr.SelectedItem == null ? "" : ((ComboBoxItem)cboApmDtr.SelectedItem).Value;
            pApm.patient_appointment_servicepoint = cboApmBsp.SelectedItem == null ? "" : ((ComboBoxItem)cboApmBsp.SelectedItem).Value;
            pApm.patient_appointment_notice = txtApmRemarkpApm.Text;
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

            pApm.remark = txtApmRemarkpApm.Text;
            pApm.e2 = chkApmDonorE2.Checked ? "1" : "0";
            pApm.beta_hgc = chkApmHCG.Checked ? "1" : "0";
            pApm.prl = chkApmPrl.Checked ? "1" : "0";
            pApm.lh = chkApmLh.Checked ? "1" : "0";
            
            pApm.hormone_test = chkApmHormoneTest.Checked ? "1" : "0";
            pApm.fsh = chkApmFsh.Checked ? "1" : "0";
            pApm.tvs = chkApmTvs.Checked ? "1" : "0";

            pApm.repeat_e2 = chkApmRE2.Checked ? "1" : "0";
            pApm.repeat_prl = chkApmRPrl.Checked ? "1" : "0";
            pApm.repeat_lh = chkApmRLh.Checked ? "1" : "0";
            pApm.repeat_fsh = chkApmRFsh.Checked ? "1" : "0";
            pApm.opu = chkApmOpu.Checked ? "1" : "0";
            pApm.opu_time = cboApmOPUTime.Text;
            //pApm.o = cboApmOPUTime.Text;
            pApm.doctor_anes = cboApmDtrAnes.Text;
            pApm.tvs_day = txtApmTvsDay.Text;
            pApm.tvs_time = cboApmTvsTime.Text;
            pApm.sperm_collect = chkApmSpermCollect.Checked ? "1" : "0";

            pApm.et = chkApmEt.Checked ? "1" : "0";
            pApm.et_time = cboApmETTime.Text;
            pApm.fet = chkApmFet.Checked ? "1" : "0";
            pApm.fet_time = cboApmFETTime.Text;
            
            pApm.other = chkApmOther.Checked ? "1" : "0";
            pApm.other_remark = txtApmOther.Text;
            pApm.sperm_freezing = chkApmSpermFreezing.Checked ? "1" : "0";
            pApm.sperm_opu = chkApmSpermOPU.Checked ? "1" : "0";
            pApm.pesa = chkApmPesa.Checked ? "1" : "0";
            pApm.sperm_sa = chkApmSpermSA.Checked ? "1" : "0";
            pApm.opu_remark = txtApmOPURemark.Text.Trim();
            return chk;
        }
        private void BtnApmSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //if (btnSave.Text.Equals("Confirm"))
            //{

            //}
            //else
            //{
            String dt1 = "";
            DateTime dt = new DateTime();
            dt1 = txtApmDatepApm.Text;
            if(!DateTime.TryParse(dt1, out dt))
            {
                MessageBox.Show("วันนัด ไม่ถูกต้อง", "");
                return;
            }
            if (cboApmTimepApm.Text.Equals(""))
            {
                MessageBox.Show("เวลานัด ไม่ถูกต้อง", "");
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
                stt.Show("<p><b>สวัสดี</b></p>คุณ " + ic.cStf.staff_fname_t + " " + ic.cStf.staff_lname_t + "<br> กรุณายินยันการ confirm อีกครั้ง", txtApmRemark);
                btnSave.Focus();

                stt.Hide();
                String re = "";
                // check ว่า มี patient ยัง ถ้ายังไม่มี ให้ insert patient
                //เป็นการเอา ข้อมูลจาก database เดิม
                //Patient pttTemp = new Patient();
                //pttTemp = ic.ivfDB.pttDB.selectByIdOld(txtPttIdOld.Text);
                //if (pttTemp.t_patient_id.Equals(""))
                //{
                //    C1ComboBox cbo = new C1ComboBox();
                //    ic.ivfDB.fpnDB.setCboNation(cbo, "");

                //    pttO = ic.ivfDB.pttOldDB.selectByPk1(pttId);
                //    ic.setC1ComboByName(cbo, pttO.Nationality);
                //    pttTemp = new Patient();
                //    pttTemp = ic.ivfDB.pttDB.setPatient1(pttTemp);
                //    pttTemp.t_patient_id_old = pttO.PID;
                //    pttTemp.patient_hn = pttO.PIDS;
                //    pttTemp.patient_firstname_e = pttO.PName;
                //    pttTemp.patient_lastname_e = pttO.PSurname;
                //    pttTemp.patient_firstname = pttO.OName;
                //    pttTemp.patient_lastname = pttO.OSurname;
                //    pttTemp.f_patient_prefix_id = pttO.SurfixID;

                //    pttTemp.f_sex_id = pttO.SexID;
                //    pttTemp.passport = pttO.IDNumber;
                //    pttTemp.patient_birthday = ic.datetoDB(pttO.DateOfBirth);
                //    pttTemp.email = pttO.Email;
                //    pttTemp.f_patient_nation_id = cbo.SelectedItem == null ? "" : ((ComboBoxItem)cbo.SelectedItem).Value;
                //    String[] name = pttO.EmergencyPersonalContact.Split(' ');
                //    if (name.Length > 1)
                //    {
                //        pttTemp.patient_contact_firstname = name[0];
                //        pttTemp.patient_contact_lastname = name[1];
                //    }
                //    ic.ivfDB.oAgnDB.setCboAgent(cbo, "");
                //    ic.setC1Combo(cbo, pttO.AgentID);
                //    pttTemp.agent = cbo.SelectedItem == null ? "" : ((ComboBoxItem)cbo.SelectedItem).Value;
                //    String re1 = ic.ivfDB.pttDB.insertPatient(pttTemp, txtStfConfirmID.Text);
                //    ptt.t_patient_id = re1;
                //    txtPttId.Value = re1;
                //    //pttTemp.patient_birthday = pttO.DateOfBirth;
                //    //pttTemp.patient_birthday = pttO.DateOfBirth;
                //}
                setPatientAppointment();
                re = ic.ivfDB.pApmDB.insertPatientAppointment(pApm, txtStfConfirmID.Text);

                //txtID.Value = (!txtID.Text.Equals("") && re.Equals("1")) ? re : "";        //update
                long chk = 0;
                if (long.TryParse(re, out chk))
                {
                    txtApmID.Value = txtApmID.Text.Equals("") ? re : txtApmID.Text;
                    setAppointmentOld();
                    //if (!ic.iniC.statusAppDonor.Equals("1"))
                    //{
                    String re1 = ic.ivfDB.pApmOldDB.insertAppointmentOld(pApmO, txtStfConfirmID.Text);
                    //txtIDOld.Value = re1;
                    txtApmIDOld.Value = txtApmIDOld.Text.Equals("") ? re1 : txtApmIDOld.Text;
                    String re2 = ic.ivfDB.pApmDB.updateAppointmentIdOld(txtApmID.Text, re1);
                    //if (int.TryParse(re1, out chk))
                    //{
                    //if (txtID.Text.Equals(""))
                    //{
                    //    //PatientOld pttOld = new PatientOld();
                    //    //pttOld = ic.ivfDB.pttOldDB.selectByPk1(re1);
                    //    String re2 = ic.ivfDB.pttDB.updatePID(re, re1);
                    //    if (int.TryParse(re2, out chk))
                    //    {
                    //String re4 = ic.ivfDB.vsDB.updateCloseStatusNurse(txtVsId.Text);
                    String re3 = ic.ivfDB.vsDB.updateStatusAppointment(txtVsId.Text, txtApmID.Text);

                    btnSave.Text = "Save";
                    btnSave.Image = Resources.accept_database24;
                    //        txtID.Value = re;
                    //        txtPid.Focus();
                    //    }
                    //}
                    //}
                    //}

                    System.Threading.Thread.Sleep(500);
                    //setGrfpApmAll();
                    setGrfpApmVisit();
                    setGrfpApmDay();
                    //this.Dispose();
                }
            }
            else
            {
                btnSave.Text = "Save";
                btnSave.Image = Resources.download_database24;
            }
            //}
        }

        private void ChkDenyAllergy_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            cboAllergyDesc.Enabled = chkDenyAllergy.Checked ? true : false;
            cboAllergyDesc.Focus();
        }

        private void ChkChronic_MouseHover(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            stt.Show("<p><b> " + ptt.congenital_diseases_description + "</b></p>", chkChronic);
        }

        private void BtnSendDtr_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.cStf.staff_id = "";
            FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            frm.ShowDialog(this);
            if (!ic.cStf.staff_id.Equals(""))
            {
                String re = "";
                re = ic.ivfDB.vsDB.updateDoctor(vs.t_visit_id, cboDoctor.SelectedItem == null ? "" : ((ComboBoxItem)cboDoctor.SelectedItem).Value);
            }
        }

        private void TlpPatient_Resize(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            decimal hei = 0;
            hei = tlpPatient.Height;
            label19.Text = hei.ToString();
            
        }

        //private void PnPatient_Resize(object sender, EventArgs e)
        //{
        //    //throw new NotImplementedException();
        //    label2.Text = pnOrder.Width.ToString();
        //    if (pnOrder.Width > 500)
        //        grfOrder.Cols[colFooName].Width = pnOrder.Width - 300;
        //    else
        //        grfOrder.Cols[colFooName].Width = 300;
        //}

        private void BtnNoteAdd_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.cStf.staff_id = "";
            FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            frm.ShowDialog(this);
            if (!ic.cStf.staff_id.Equals(""))
            {
                Note1 note = new Note1();
                note.active = "1";
                note.date_cancel = "";
                note.date_create = "";
                note.date_modi = "";
                note.note_1 = txtNote.Text;
                note.note_2 = "";
                note.note_id = txtNoteId.Text;
                note.remark = "";
                note.t_patient_id = ptt.t_patient_id;
                note.user_cancel = "";
                note.user_create = "";
                note.user_modi = "";
                note.status_all = chkNoteAll.Checked ? "1" : "0";
                note.b_service_point_id = "2120000000";
                ic.ivfDB.noteDB.insertNote(note, ic.cStf.staff_id);
                setGrfNote();
                txtNote.Value = "";
            }
        }
        private void CboLangSticker_SelectedIndexChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (cboLangSticker.Text.Equals("English"))
            {
                grfRx.Cols[colRxUsT].Visible = false;
                grfRx.Cols[colRxUsE].Visible = true;

                grfRxSetD.Cols[colRxUsT].Visible = false;
                grfRxSetD.Cols[colRxUsE].Visible = true;
            }
            else
            {
                grfRx.Cols[colRxUsT].Visible = true;
                grfRx.Cols[colRxUsE].Visible = false;
                grfRxSetD.Cols[colRxUsT].Visible = true;
                grfRxSetD.Cols[colRxUsE].Visible = false;
            }
        }
        private void BtnFinish_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String err = "";
            try
            {
                String dtrid = "", errfor = "";
                err = "00";
                dtrid = cboDoctor.SelectedItem == null ? "" : ((ComboBoxItem)cboDoctor.SelectedItem).Value;
                err = "01";
                //foreach (Row row in grfOrder.Rows)
                //{
                //    try
                //    {
                //        String lgid = "", reqid = "", itmid = "";
                //        errfor = "000";
                //        lgid = row[colOrdlpid] != null ? row[colOrdlpid].ToString() : "";
                //        reqid = row[colOrdid] != null ? row[colOrdid].ToString() : "";
                //        itmid = row[colOrditmid] != null ? row[colOrditmid].ToString() : "";
                //        errfor = "001";
                //        if (lgid.Length <= 0) continue;
                //        LabRequest lbReq = new LabRequest();
                //        if (ptt.f_sex_id.Equals("1"))
                //        {
                //            lbReq = ic.ivfDB.setLabRequest("", txtVnOld.Text, dtrid, "", "", ic.datetoDB(txtDob.Text), reqid, itmid, txtHn.Text, txtPttNameE.Text, "", "", "", txtVsId.Text);
                //        }
                //        else if (ptt.f_sex_id.Equals("2"))
                //        {
                //            lbReq = ic.ivfDB.setLabRequest(txtPttNameE.Text, txtVnOld.Text, dtrid, "", txtHn.Text, ic.datetoDB(txtDob.Text), reqid, itmid, "", "", "", "", "", txtVsId.Text);
                //        }
                //        errfor = "002";
                //        String re = ic.ivfDB.lbReqDB.insertLabRequest(lbReq, ic.userId);
                //        ic.ivfDB.oJlabdDB.updateReqId(re, reqid);
                //    }
                //    catch(Exception ex)
                //    {
                //        MessageBox.Show("error "+ errfor+" " + ex.Message, "BtnFinish_Click foreach grfOrder.Rows");
                //    }
                //}
                ic.cStf.staff_id = "";
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    //      0015
                    //ic.ivfDB.nurseFinish(txtVnOld.Text, ic.cStf.staff_id);        // -0015
                    if (ic.iniC.statusCashierOldProgram.Equals("1"))        // +0015
                    {        // +0015
                        ic.ivfDB.nurseFinishCashierOldProgram(txtVnOld.Text, ic.cStf.staff_id);        // +0015
                    }        // +0015
                    else        // +0015
                    {        // +0015
                        ic.ivfDB.nurseFinish(txtVnOld.Text, ic.cStf.staff_id);        // +0015
                    }        // +0015
                    VisitOld ovs = new VisitOld();
                    ovs = ic.ivfDB.ovsDB.selectByPk1(txtVnOld.Text);
                    if (ovs.VSID.Equals("160"))
                    {
                        frmNurView.setGrfQuePublic();
                        frmNurView.setGrfFinishPublic();
                        menu.removeTab(tab);
                        //return;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("error "+err+" "+ex.Message, "BtnFinish_Click");
            }
            
            //setGrfOrder(txtVn.Text);
        }

        private void BtnRxSetOrder_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setRxSet();
            //if (grfRxSetD.Rows.Count > 0)
            //{
            //    String gdid = "";
            //    gdid = grfRxSet[grfRxSet.Row, colBlId].ToString();
            //    ic.ivfDB.PxSetAdd(gdid, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "");
            //    setGrfOrder(txtVnOld.Text);
            //}
        }

        private void BtnPkgOrder_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ////      if ($Pay2 == "0" or $Pay2 == ""){
            ////$PaymentTimes = 1;
            ////      } else {
            ////          if ($Pay3 == "0" or $Pay3 == ""){
            ////		$PaymentTimes = 2;
            ////          } else {
            ////              if ($Pay4 == "0" or $Pay4 == ""){
            ////			$PaymentTimes = 3;
            ////              } else {
            ////			$PaymentTimes = 4;
            ////              }
            ////          }
            ////      }
            
            String times = "";
            Decimal price = 0;
            if (Decimal.TryParse(txtPayment1.Text, out price))
            {
                times = "1";
            }
            if (Decimal.TryParse(txtPayment2.Text, out price))
            {
                times = "2";
            }
            if (Decimal.TryParse(txtPayment3.Text, out price))
            {
                times = "3";
            }
            if (Decimal.TryParse(txtPayment4.Text, out price))
            {
                times = "4";
            }
            Decimal amt = 0, pay2 = 0, pay3 = 0, pay4 = 0, pay1 = 0;
            Decimal.TryParse(txtPayment1.Text, out pay1);
            Decimal.TryParse(txtPayment2.Text, out pay2);
            Decimal.TryParse(txtPayment3.Text, out pay3);
            Decimal.TryParse(txtPayment4.Text, out pay4);
            Decimal.TryParse(txtPrice.Text, out price);
            amt = pay1 + pay2 + pay3 + pay4;
            if (amt < price)
            {
                MessageBox.Show("จำนวนเงิน ต่อ งวด รวมกันแล้ว น้อยกว่า มูลค่า Package", "");
                return;
            }
            OldPackageSold opkgs = new OldPackageSold();
            opkgs.PCKSID = "";
            opkgs.PID = txtIdOld.Text;
            opkgs.SellThruID = cboSellThruID.SelectedItem == null ? "" : ((ComboBoxItem)cboSellThruID.SelectedItem).Value;
            if ((opkgs.SellThruID.Length <= 0) || opkgs.SellThruID.Equals("000"))
            {
                MessageBox.Show("กรุณาเลือก Patient Comes Through", "");
                return;
            }
            opkgs.PCKID = txtPkgId.Text;
            opkgs.PackageName = txtPkgName.Text;
            opkgs.Price = txtPrice.Text;
            opkgs.Date = "";
            opkgs.PaymentTimes = times;
            //opkgs.Status = "1";       //  -0016
            opkgs.Status = "2";       //  +0016
            opkgs.Payment1 = txtPayment1.Text;
            opkgs.Payment2 = txtPayment2.Text;
            opkgs.Payment3 = txtPayment3.Text;
            opkgs.Payment4 = txtPayment4.Text;
            opkgs.P1BDetailID = "";
            opkgs.P2BDetailID = "";
            opkgs.P3BDetailID = "";
            opkgs.P4BDetailID = "";
            opkgs.VN = txtVnOld.Text;
            opkgs.row1 = grfOrder.Rows.Count.ToString();
            String pkgsid = ic.ivfDB.PackageAdd(opkgs, ic.userId);

            setGrfOrder(txtVn.Text);
            
            setTabPkg(pkgsid, txtPkgName.Text);
        }
        private void setTabPkg(String pkgsid, String tabname)
        {
            Boolean chk = false;
            foreach (Control tab in tcOrd.Controls)
            {
                if(tab is C1DockingTabPage)
                {
                    String name = tab.Name;
                    if (name.Length >= 10)
                    {
                        name = name.Substring(name.Length - 10);
                        if (name.Equals(pkgsid))
                        {
                            chk = true;
                        }
                    }
                }
            }
            if (chk) return;
            C1DockingTabPage tabPkgUse = new C1DockingTabPage();
            tabPkgUse.Name = "tabPkgUse_"+ pkgsid;
            tabPkgUse.TabIndex = 0;
            tabPkgUse.Text = tabname;
            tabPkgUse.Font = fEditB;
            tcOrd.Controls.Add(tabPkgUse);
            int cnt = 0;
            cnt = tcOrd.Controls.Count - 2;
            C1FlexGrid grfPkg = new C1FlexGrid();
            grfPkg.Font = fEdit;
            grfPkg.Dock = DockStyle.Fill;
            grfPkg.Location = new Point(0, 0);
            grfPkg.Rows.Count = 1;
            grfPkg.Name = "grfPkg_" + pkgsid;
            
            tabPkgUse.Controls.Add(grfPkg);
            setGrfPgk(pkgsid, grfPkg);
            lgrfPkg.Add(grfPkg);
        }
        private void setGrfPgk(String pkgsid, C1FlexGrid grfPkg)
        {
            //grfDept.Rows.Count = 7;
            //grfPkg.Clear();gr
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oPkgdpDB.selectByPkgId2(pkgsid);
            grfPkg.Rows.Count = 1;
            grfPkg.Rows.Count = dt.Rows.Count + 1;
            //grfEmbryo.Rows.Count = dt.Rows.Count + 1;
            //grfPackageD.DataSource = dt;
            grfPkg.Cols.Count = 8;

            grfPkg.Cols[colPkgType].Width = 100;
            grfPkg.Cols[colPkgItmName].Width = 320;
            grfPkg.Cols[colPkgQty].Width = 80;
            grfPkg.Cols[colPkgUse].Width = 80;

            grfPkg.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfPkg.Cols[colPkgType].Caption = "Type1";
            grfPkg.Cols[colPkgItmName].Caption = "Name";
            grfPkg.Cols[colPkgQty].Caption = "QTY";
            grfPkg.Cols[colPkgUse].Caption = "Use";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    Decimal chk = 0, qty=0;
                    grfPkg[i, 0] = i;
                    grfPkg[i, colPkgdId] = row["PCKDPSID"].ToString();
                    grfPkg[i, colPkgsId] = row["PCKSID"].ToString();
                    grfPkg[i, colPkgType] = row["ItemType"].ToString();
                    grfPkg[i, colPkgItmName] = row["ItemName"].ToString();
                    grfPkg[i, colPkgQty] = row["QTY"].ToString();
                    grfPkg[i, colPkgItmId] = row["ItemID"].ToString();
                    grfPkg[i, colPkgUse] = row["QTYused"].ToString();
                    Decimal.TryParse(row["QTY"].ToString(), out qty);
                    Decimal.TryParse(row["QTYused"].ToString(), out chk);
                    if (chk < qty)
                    {
                        grfPkg.Rows[i].StyleNew.BackColor = color;
                        //grfPkg.Rows[i].StyleNew.BackColor = Color.Red;
                    }
                    else if(chk>0)
                    {
                        grfPkg.Rows[i].StyleNew.BackColor = Color.Red;
                    }
                    //if (i % 2 == 0)
                    //    grfPtt.Rows[i].StyleNew.BackColor = color;
                    i++;
                }
                catch (Exception ex)
                {
                    String err = "";
                }
            }
            CellNoteManager mgr = new CellNoteManager(grfPkg);
            grfPkg.Cols[colPkgdId].Visible = false;
            grfPkg.Cols[colPkgsId].Visible = false;
            //grfPackageD.Cols[colPkgItmId].Visible = false;

            grfPkg.Cols[colPkgType].AllowEditing = false;
            grfPkg.Cols[colPkgItmName].AllowEditing = false;
            grfPkg.Cols[colPkgQty].AllowEditing = false;
            grfPkg.Cols[colPkgUse].AllowEditing = false;
            //theme1.SetTheme(grfFinish, ic.theme);

        }
        private void TabOrder_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (tabOrder.SelectedTab == tabRx)
            {
                ic.ivfDB.oJpxDB.setJobPx(txtVnOld.Text, txtHn.Text, txtIdOld.Text);
            }
            else if (tabOrder.SelectedTab == tabSpecialItem)
            {
                ic.ivfDB.oJsDB.setJobSpecial(txtVnOld.Text, txtHn.Text, txtIdOld.Text);
            }
            else if (tabOrder.SelectedTab == tabGeneticLab)
            {
                ic.ivfDB.oJlabDB.setJobLab(txtVnOld.Text, txtHn.Text, txtIdOld.Text);
            }
            else if (tabOrder.SelectedTab == tabEmbryoLab)
            {
                ic.ivfDB.oJlabDB.setJobLab(txtVnOld.Text, txtHn.Text, txtIdOld.Text);
            }
            else if (tabOrder.SelectedTab == tabSpermLab)
            {
                ic.ivfDB.oJlabDB.setJobLab(txtVnOld.Text, txtHn.Text, txtIdOld.Text);
            }
            else if (tabOrder.SelectedTab == tabBloodLab)
            {
                ic.ivfDB.oJlabDB.setJobLab(txtVnOld.Text, txtHn.Text, txtIdOld.Text);
            }
            else if (tabOrder.SelectedTab == tabRxSet)
            {
                btnPkgOrder.Enabled = false;
            }
            else if (tabOrder.SelectedTab == tabPackage)
            {

            }
        }
        private void initGrfHistoryDrug()
        {
            grfHisDrug = new C1FlexGrid();
            grfHisDrug.Font = fEdit;
            grfHisDrug.Dock = System.Windows.Forms.DockStyle.Fill;
            grfHisDrug.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfPackageD);

            //grfHisDrug.AfterDataRefresh += GrfOrder_AfterDataRefresh;
            //grfHisDrug.SubtotalPosition = SubtotalPositionEnum.BelowData;
            //grfOrder.mou
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            //ContextMenu menuGw = new ContextMenu();
            //if (flagedit.Equals("edit"))
            //{
            //    menuGw.MenuItems.Add("ยกเลิกรายการ", new EventHandler(ContextMenu_or_void));
            //}
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            //grfOrder.ContextMenu = menuGw;
            pnHistoryDrug.Controls.Add(grfHisDrug);

            theme1.SetTheme(grfHisDrug, "GreenHouse");

        }
        private void setGrfHistoryDrug()
        {
            //grfDept.Rows.Count = 7;
            grfHisDrug.Clear();
            DataTable dtAll = new DataTable();
            DataTable dtbl = new DataTable();
            DataTable dtse = new DataTable();
            DataTable dtpx = new DataTable();
            DataTable dtpkg = new DataTable();

            dtbl = ic.ivfDB.oJlabdDB.selectByPID(pttOld.PID);
            dtse = ic.ivfDB.ojsdDB.selectByPID(pttOld.PID);
            dtpx = ic.ivfDB.oJpxdDB.selectByPID(pttOld.PID);
            //dtpkg = ic.ivfDB.opkgsDB.selectByVN(vn);
            dtpkg = ic.ivfDB.opkgsDB.selectByPID1(pttOld.PID);    // ต้องดึงตาม HN เพราะ ถ้ามีงวดการชำระ 

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            //grfEmbryo.Rows.Count = dt.Rows.Count + 1;

            dtAll.Columns.Add("id", typeof(String));
            dtAll.Columns.Add("lgid", typeof(String));
            dtAll.Columns.Add("name", typeof(String));
            dtAll.Columns.Add("price", typeof(String));
            dtAll.Columns.Add("qty", typeof(String));
            dtAll.Columns.Add("status", typeof(String));
            dtAll.Columns.Add("row1", typeof(int));
            dtAll.Columns.Add("itmid", typeof(String));
            dtAll.Columns.Add("extra", typeof(String));
            dtAll.Columns.Add("usage", typeof(String));
            dtAll.Columns.Add("lab_order_id", typeof(String));
            dtAll.Columns.Add("status_amt", typeof(String));
            dtAll.Columns.Add("status_order_group", typeof(String));
            dtAll.Columns.Add("date", typeof(String));
            int i = 0;
            foreach (DataRow row in dtbl.Rows)
            {
                DataRow row1 = dtAll.NewRow();
                row1["id"] = row["ID"];
                row1["itmid"] = row["LID"];
                row1["lgid"] = row["LGID"];
                row1["name"] = row["LName"];
                row1["price"] = row["Price"];
                row1["qty"] = row["QTY"];
                row1["row1"] = row["row1"];
                row1["extra"] = row["Extra"];
                row1["usage"] = "";
                row1["lab_order_id"] = row["lab_order_id"];
                row1["status_amt"] = row["status_amt"];
                row1["status_order_group"] = row["status_order_group"];
                if (row["LGID"].ToString().Equals("1"))
                {
                    row1["status"] = "bloodlab";
                }
                else if (row["LGID"].ToString().Equals("2"))
                {
                    row1["status"] = "";
                }
                else if (row["LGID"].ToString().Equals("3"))
                {
                    row1["status"] = "Sperm Lab";
                }
                else if (row["LGID"].ToString().Equals("4"))
                {
                    row1["status"] = "Embryo Lab";
                }
                else if (row["LGID"].ToString().Equals("5"))
                {
                    row1["status"] = "Genetic Lab";
                }
                row1["date"] = row["visit_begin_visit_time"];
                dtAll.Rows.InsertAt(row1, i);
                i++;
            }
            foreach (DataRow row in dtse.Rows)
            {
                DataRow row1 = dtAll.NewRow();
                row1["id"] = row["ID"];
                row1["itmid"] = row["SID"];
                row1["lgid"] = "";
                row1["name"] = row["SName"];
                row1["price"] = row["Price"];
                row1["qty"] = row["qty"];
                row1["status"] = "specialitem";
                row1["row1"] = row["row1"];
                row1["extra"] = row["Extra"];
                row1["usage"] = "";
                row1["lab_order_id"] = "0";
                row1["status_amt"] = "1";
                row1["status_order_group"] = "0";
                row1["date"] = row["visit_begin_visit_time"];
                dtAll.Rows.InsertAt(row1, i);
                i++;
            }
            foreach (DataRow row in dtpx.Rows)
            {
                DataRow row1 = dtAll.NewRow();
                row1["id"] = row["ID"];
                row1["itmid"] = row["DUID"];
                row1["lgid"] = "";
                row1["name"] = row["DUName"];
                row1["price"] = row["Price"];
                row1["qty"] = row["QTY"];
                row1["status"] = "px";
                row1["row1"] = row["row1"];
                row1["extra"] = row["Extra"];
                row1["usage"] = row["TUsage"];
                row1["lab_order_id"] = "0";
                row1["status_amt"] = "1";
                row1["status_order_group"] = "0";
                row1["date"] = row["visit_begin_visit_time"];
                dtAll.Rows.InsertAt(row1, i);
                i++;

            }
            foreach (DataRow row in dtpkg.Rows)
            {
                String bill1 = "", bill2 = "", bill3 = "", bill4 = "", times = "", name = "";
                Decimal price = 0, pay1 = 0, pay2 = 0, pay3 = 0, pay4 = 0, pay = 0;
                Decimal.TryParse(row["price"].ToString(), out price);
                Decimal.TryParse(row["payment1"].ToString(), out pay1);
                Decimal.TryParse(row["payment2"].ToString(), out pay2);
                Decimal.TryParse(row["payment3"].ToString(), out pay3);
                Decimal.TryParse(row["payment4"].ToString(), out pay4);
                times = row["payment_times"].ToString();
                bill1 = row["P1BDetailID"].ToString();
                bill2 = row["P2BDetailID"].ToString();
                bill3 = row["P3BDetailID"].ToString();
                bill4 = row["P4BDetailID"].ToString();
                name = row["PackageName"].ToString();
                if (price > 0)
                {
                    if ((pay1 > 0) && bill1.Equals("0"))
                    {
                        pay = pay1;
                        name += "1/" + times;
                    }
                    else if ((pay2 > 0) && bill2.Equals("0"))
                    {
                        pay = pay2;
                        name += "2/" + times;
                    }
                    else if ((pay3 > 0) && bill3.Equals("0"))
                    {
                        pay = pay3;
                        name += "3/" + times;
                    }
                    else if ((pay4 > 0) && bill4.Equals("0"))
                    {
                        pay = pay4;
                        name += "4/" + times;
                    }
                    DataRow row1 = dtAll.NewRow();
                    row1["id"] = row["PCKSID"];
                    row1["itmid"] = row["PCKID"];
                    row1["lgid"] = "";
                    row1["name"] = name;
                    row1["price"] = pay;
                    row1["qty"] = "1";
                    row1["status"] = "package";
                    row1["row1"] = row["row1"];
                    row1["extra"] = "0";
                    row1["usage"] = "";
                    row1["lab_order_id"] = "0";
                    row1["status_amt"] = "1";
                    row1["status_order_group"] = "0";
                    row1["date"] = row["visit_begin_visit_time"];
                    dtAll.Rows.InsertAt(row1, i);
                    i++;
                }
            }
            dtAll.DefaultView.Sort = "date";
            DataView view = dtAll.DefaultView;
            view.Sort = "date, row1 ASC";
            DataTable sortedDate = view.ToTable();
            //grfOrder.DataSource = dtAll;
            grfHisDrug.Cols.Count = 18;
            //C1TextBox txt = new C1TextBox();
            //C1CheckBox chk = new C1CheckBox();
            //chk.Text = "Include Package";
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            //grfOrder.Cols[1].Editor = txt;
            //grfOrder.Cols[colOrderPrice].Editor = txt;
            //grfOrder.Cols[colOrderQTY].Editor = txt;
            //grfOrder.Cols[colRxId].Editor = txt;
            grfHisDrug.Cols[colOrdDate].Width = 120;
            grfHisDrug.Cols[colOrdName].Width = 280;
            grfHisDrug.Cols[colOrdPrice].Width = 100;
            grfHisDrug.Cols[colOrdQty].Width = 80;
            grfHisDrug.Cols[colOrdUsT].Width = 100;

            grfHisDrug.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";
            grfHisDrug.Cols[colOrdDate].Caption = "Date";
            grfHisDrug.Cols[colOrdName].Caption = "Name";
            grfHisDrug.Cols[colOrdPrice].Caption = "Price";
            grfHisDrug.Cols[colOrdQty].Caption = "QTY";
            grfHisDrug.Cols[colOrdInclude].Caption = "Include Package";
            grfHisDrug.Cols[colOrdUsT].Caption = "Usage";
            grfHisDrug.Cols[colOrdAmt].Caption = "Amount";
            //grfOrder.SubtotalPosition = SubtotalPositionEnum.BelowData;
            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            i = 1;
            grfHisDrug.Rows.Count = 1;
            Decimal inc = 0, ext = 0;
            foreach (DataRow row in sortedDate.Rows)
            {
                try
                {
                    Decimal price = 0, qty = 0;
                    Row row1 = grfHisDrug.Rows.Add();
                    row1[colOrdid] = row["id"].ToString();
                    row1[colOrdlpid] = row["lgid"].ToString();
                    row1[colOrdName] = row["name"].ToString();
                    row1[colOrdUsT] = row["usage"].ToString();
                    //row1[colOrdQty] = row["qty"].ToString();
                    row1[colOrdstatus] = row["status"].ToString();
                    row1[colOrdrow1] = row["row1"].ToString();
                    row1[colOrditmid] = row["itmid"].ToString();
                    row1[colOrdInclude] = row["extra"].ToString().Equals("1") ? "Extra" : "Include";

                    Decimal.TryParse(row["price"].ToString(), out price);
                    Decimal.TryParse(row["qty"].ToString(), out qty);
                    row1[colOrdPrice] = price.ToString("#,###.00");
                    row1[colOrdQty] = qty.ToString("#,###.00");
                    row1[colOrdAmt] = (price * qty).ToString("#,###.00");
                    if (row["status_amt"].ToString().Equals("1"))
                    {
                        if (row["extra"].ToString().Equals("1"))
                        {
                            ext += (price * qty);
                        }
                        else
                        {
                            if (row["status"].ToString().Equals("package"))
                            {
                                inc += (price * qty);
                            }
                        }
                    }

                    row1[colOrdAmt] = (price * qty).ToString("#,###.00");
                    row1[colOrdAmt] = (price * qty).ToString("#,###.00");
                    row1[colOrdOrderId] = row["lab_order_id"].ToString();
                    row1[colOrdStatusAmt] = row["status_amt"].ToString();
                    row1[colOrdStatusOrdGrp] = row["status_order_group"].ToString();
                    row1[colOrdDate] = ic.datetoShow(row["date"].ToString());
                    row1[0] = i;
                    //if (i % 2 == 0)
                    //    grfPtt.Rows[i].StyleNew.BackColor = color;
                    i++;
                }
                catch (Exception ex)
                {
                    String err = "";
                }
            }
            rowOrder = grfHisDrug.Rows.Count;

            grfHisDrug.Tree.Column = colOrdDate;
            grfHisDrug.Tree.Style = TreeStyleFlags.Simple;
            grfHisDrug.AllowMerging = AllowMergingEnum.Nodes;

            CellNoteManager mgr = new CellNoteManager(grfHisDrug);
            grfHisDrug.Cols[colOrdrow1].Visible = false;
            grfHisDrug.Cols[colOrdlpid].Visible = false;
            grfHisDrug.Cols[colOrdid].Visible = false;
            //grfOrder.Cols[colOrdstatus].Visible = false;
            grfHisDrug.Cols[colOrditmid].Visible = false;

            grfHisDrug.Cols[colOrdUsE].Visible = false;
            //grfOrder.Cols[colOrderPID].Visible = false;
            //grfOrder.Cols[colOrderPIDS].Visible = false;
            //grfOrder.Cols[colOrderSP1V].Visible = false;
            //grfOrder.Cols[colOrderSP2V].Visible = false;
            //grfOrder.Cols[colOrderSP3V].Visible = false;
            //grfOrder.Cols[colOrderSP4V].Visible = false;
            //grfOrder.Cols[colOrderSP5V].Visible = false;
            //grfOrder.Cols[colOrderSP6V].Visible = false;
            //grfOrder.Cols[colOrderSP7V].Visible = false;
            //grfOrder.Cols[colOrderSubItem].Visible = false;
            //grfOrder.Cols[colOrderFileName].Visible = false;
            //grfOrder.Cols[colOrderWorder1].Visible = false;
            //grfOrder.Cols[colOrderWorker2].Visible = false;
            //grfOrder.Cols[colOrderWorker3].Visible = false;
            //grfOrder.Cols[colOrderWorkder4].Visible = false;
            //grfOrder.Cols[colOrderWorker5].Visible = false;
            //grfOrder.Cols[colOrderLGID].Visible = false;
            //grfOrder.Cols[colOrderActive].Visible = false;
            //grfOrder.Cols[colOrderLID].Visible = false;
            grfHisDrug.Cols[colOrdUsT].AllowEditing = false;
            grfHisDrug.Cols[colOrdName].AllowEditing = false;
            grfHisDrug.Cols[colOrdPrice].AllowEditing = false;
            grfHisDrug.Cols[colOrdQty].AllowEditing = false;
            grfHisDrug.Cols[colOrdOrderId].AllowEditing = false;
            grfHisDrug.Cols[colOrdStatusAmt].AllowEditing = false;
            grfHisDrug.Cols[colOrdStatusOrdGrp].AllowEditing = false;
            //theme1.SetTheme(grfFinish, ic.theme);
            //UpdateTotals();
            String total = "";
            Decimal total1 = 0;
            //total = grfOrder[grfOrder.Rows.Count - 1, colOrdAmt] != null ? grfOrder[grfOrder.Rows.Count - 1, colOrdAmt].ToString() : "";
            //total1 = inc + ext;
            //Decimal.TryParse(total, out total1);
            //txtTotal.Value = total1.ToString("#,###.00");
            //txtInclude.Value = inc.ToString("#,###.00");
            //txtExtra.Value = ext.ToString("#,###.00");
        }
        private void initGrfHistory()
        {
            grfHis = new C1FlexGrid();
            grfHis.Font = fEdit;
            grfHis.Dock = System.Windows.Forms.DockStyle.Fill;
            grfHis.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            grfHis.AfterRowColChange += GrfHis_AfterRowColChange;
            //grfImg.MouseDown += GrfImg_MouseDown;
            grfHis.DoubleClick += GrfHis_DoubleClick;
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            //ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("Upload รูปบัตรประชาชน", new EventHandler(ContextMenu_grfimg_upload_ptt));
            //menuGw.MenuItems.Add("Upload สำเนาบัตรประชาชน ที่มีลายเซ็น", new EventHandler(ContextMenu_grfimg_upload_ptt));
            //menuGw.MenuItems.Add("Upload รูป Passport", new EventHandler(ContextMenu_grfimg_upload_ptt));
            //menuGw.MenuItems.Add("ยกเลิก", new EventHandler(ContextMenu_grfimg_Cancel));
            //grfImgOld.ContextMenu = menuGw;
            pnHistoryVs.Controls.Add(grfHis);

            theme1.SetTheme(grfHis, "Office2016Colorful");

        }

        private void GrfHis_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (grfHis.Row < 0 ) return;

        }

        private void GrfHis_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfHis.Row < 0) return;

        }
        private void setGrfHistory()
        {
            grfHis.Clear();
            grfHis.Rows.Count = 1;
            grfHis.Cols.Count = 4;
            DataTable dt = ic.ivfDB.vsDB.selectByPttId1(txtPttId.Text);

            grfHis.Rows.Count = dt.Rows.Count + 1;

            grfHis.Cols[colHisVsId].Width = 250;
            grfHis.Cols[colHisVsDate].Width = 120;

            grfHis.ShowCursor = true;

            grfHis.Cols[colHisVsDate].Caption = "Date";
            grfHis.Cols[colHisVsVn].Caption = "VN";

            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                grfHis[i, colHisVsId] = row[ic.ivfDB.vsDB.vs.t_visit_id].ToString();
                grfHis[i, colHisVsDate] = ic.datetoShow(row[ic.ivfDB.vsDB.vs.visit_begin_visit_time].ToString());
                grfHis[i, colHisVsVn] = row[ic.ivfDB.vsDB.vs.visit_vn].ToString();
                i++;
            }
            grfHis.Cols[colHisVsId].Visible = false;
            //grfHis.Cols[colNoteStatusAll].Visible = false;
            grfHis.Cols[colHisVsDate].AllowEditing = false;

            theme1.SetTheme(grfHis, "Office2016DarkGray");
        }
        //private void initGrfAdm()
        //{
        //    grfpApmAll = new C1FlexGrid();
        //    grfpApmAll.Font = fEdit;
        //    grfpApmAll.Dock = System.Windows.Forms.DockStyle.Fill;
        //    grfpApmAll.Location = new System.Drawing.Point(0, 0);
            
        //    grfpApmAll.DoubleClick += GrfpApmAll_DoubleClick;
        //    //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
        //    //ContextMenu menuGw = new ContextMenu();
        //    //menuGw.MenuItems.Add("Upload รูปบัตรประชาชน", new EventHandler(ContextMenu_grfimg_upload_ptt));
        //    //menuGw.MenuItems.Add("Upload สำเนาบัตรประชาชน ที่มีลายเซ็น", new EventHandler(ContextMenu_grfimg_upload_ptt));
        //    //menuGw.MenuItems.Add("Upload รูป Passport", new EventHandler(ContextMenu_grfimg_upload_ptt));
        //    //menuGw.MenuItems.Add("ยกเลิก", new EventHandler(ContextMenu_grfimg_Cancel));
        //    //grfImgOld.ContextMenu = menuGw;
        //    pnAdm.Controls.Add(grfpApmAll);

        //    theme1.SetTheme(grfpApmAll, "Office2016Colorful");

        //}

        private void GrfpApmAll_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

        }

        private void setGrfpApmAll(String date)
        {
            //grfDept.Rows.Count = 7;
            grfpApmAll.Clear();
            DataTable dt = new DataTable();

            dt = ic.ivfDB.pApmDB.selectByDate1(date);

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfpApmAll.Rows.Count = 1;
            grfpApmAll.Cols.Count = 14;
            C1TextBox txt = new C1TextBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfpApmAll.Cols[colApmNotice].Editor = txt;
            grfpApmAll.Cols[colApmAppointment].Editor = txt;
            grfpApmAll.Cols[colApmDoctor].Editor = txt;
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

            grfpApmAll.Cols[colApmDate].Width = 100;
            grfpApmAll.Cols[colApmTime].Width = 80;
            grfpApmAll.Cols[colApmAppointment].Width = 120;
            grfpApmAll.Cols[colApmDoctor].Width = 100;
            grfpApmAll.Cols[colApmSp].Width = 80;
            grfpApmAll.Cols[colApmNotice].Width = 200;
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

            grfpApmAll.Cols[colApmDate].Caption = "Date";
            grfpApmAll.Cols[colApmTime].Caption = "time";
            grfpApmAll.Cols[colApmAppointment].Caption = "นัด";
            grfpApmAll.Cols[colApmDoctor].Caption = "Doctor";
            grfpApmAll.Cols[colApmSp].Caption = "จุดบริการ";
            grfpApmAll.Cols[colApmNotice].Caption = "แจ้ง";
            grfpApmAll.Cols[colE2].Caption = "E2";
            grfpApmAll.Cols[colLh].Caption = "LH";
            grfpApmAll.Cols[colEndo].Caption = "Endo";
            grfpApmAll.Cols[colPrl].Caption = "PRL";
            grfpApmAll.Cols[colFsh].Caption = "FSH";
            grfpApmAll.Cols[colRt].Caption = "Rt";
            grfpApmAll.Cols[colLt].Caption = "Lt";

            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("แก้ไข Appointment", new EventHandler(ContextMenu_edit_papm1));
            grfpApmAll.ContextMenu = menuGw;

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                Row row1 = grfpApmAll.Rows.Add();
                row1[0] = i;
                row1[colApmId] = row[ic.ivfDB.pApmDB.pApm.t_patient_appointment_id].ToString();
                row1[colApmDate] = ic.datetoShow(row[ic.ivfDB.pApmDB.pApm.patient_appointment_date].ToString());
                row1[colApmTime] = row[ic.ivfDB.pApmDB.pApm.patient_appointment_time].ToString();
                row1[colApmAppointment] = row[ic.ivfDB.pApmDB.pApm.patient_appointment].ToString();
                row1[colApmDoctor] = row[ic.ivfDB.pApmDB.pApm.dtr_name];
                row1[colApmSp] = row["service_point_description"].ToString();
                row1[colApmNotice] = row[ic.ivfDB.pApmDB.pApm.patient_appointment_notice].ToString();

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
            grfpApmAll.Cols[colApmId].Visible = false;
            theme1.SetTheme(grfpApmAll, ic.theme);

        }
        private void ContextMenu_edit_papm(object sender, System.EventArgs e)
        {
            String chk = "", name = "", id = "";
            id = grfpApmAll[grfpApmAll.Row, colApmId] != null ? grfpApmAll[grfpApmAll.Row, colApmId].ToString() : "";
            pApmId = id;
            FrmAppointmentAdd frm = new FrmAppointmentAdd(ic, pApmId, pttId, vn,pttId);
            frm.ShowDialog(this);
            setGrfpApmVisit();

        }
        private void initGrfpApmAll()
        {
            grfpApmAll = new C1FlexGrid();
            grfpApmAll.Font = fEdit;
            grfpApmAll.Dock = System.Windows.Forms.DockStyle.Fill;
            grfpApmAll.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            //grfpApmAll.ContextMenu = menuGw;
            pnApmAll.Controls.Add(grfpApmAll);

            theme1.SetTheme(grfpApmAll, "Office2016Colorful");

        }
        private void initGrfpApmDayAll()
        {
            grfpApmDayAll = new C1FlexGrid();
            grfpApmDayAll.Font = fEdit;
            grfpApmDayAll.Dock = System.Windows.Forms.DockStyle.Fill;
            grfpApmDayAll.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            //grfpApmAll.ContextMenu = menuGw;
            pnApmDay.Controls.Add(grfpApmDayAll);

            theme1.SetTheme(grfpApmDayAll, "Office2016Colorful");

        }
        private void initGrfNote()
        {
            grfNote = new C1FlexGrid();
            grfNote.Font = fEdit;
            grfNote.Dock = System.Windows.Forms.DockStyle.Fill;
            grfNote.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            //grfImg.AfterRowColChange += GrfImg_AfterRowColChange;
            //grfImg.MouseDown += GrfImg_MouseDown;
            grfNote.DoubleClick += GrfNote_DoubleClick;
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            //ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("Upload รูปบัตรประชาชน", new EventHandler(ContextMenu_grfimg_upload_ptt));
            //menuGw.MenuItems.Add("Upload สำเนาบัตรประชาชน ที่มีลายเซ็น", new EventHandler(ContextMenu_grfimg_upload_ptt));
            //menuGw.MenuItems.Add("Upload รูป Passport", new EventHandler(ContextMenu_grfimg_upload_ptt));
            //menuGw.MenuItems.Add("ยกเลิก", new EventHandler(ContextMenu_grfimg_Cancel));
            //grfImgOld.ContextMenu = menuGw;
            pnNote.Controls.Add(grfNote);

            theme1.SetTheme(grfNote, "Office2016Colorful");

        }
        private void GrfNote_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfNote.Row < 0) return;
            String id = grfNote[grfNote.Row, colNoteId] != null ? grfNote[grfNote.Row, colNoteId].ToString() : "";
            String note = grfNote[grfNote.Row, colNote] != null ? grfNote[grfNote.Row, colNote].ToString() : "";
            txtNoteId.Value = id;
            txtNote.Value = note;
        }
        private void setGrfNote()
        {
            grfNote.Clear();
            grfNote.Rows.Count = 1;
            grfNote.Cols.Count = 4;
            DataTable dt = ic.ivfDB.noteDB.selectByPttId(ptt.t_patient_id);

            grfNote.Rows.Count = dt.Rows.Count + 1;

            grfNote.Cols[colNoteId].Width = 250;
            grfNote.Cols[colNote].Width = 600;

            grfNote.ShowCursor = true;

            grfNote.Cols[colNote].Caption = "Note";

            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                grfNote[i, colNoteId] = row[ic.ivfDB.noteDB.note.note_id].ToString();
                grfNote[i, colNote] = row[ic.ivfDB.noteDB.note.note_1].ToString();
                grfNote[i, colNoteStatusAll] = row[ic.ivfDB.noteDB.note.status_all].ToString();
                i++;
            }
            grfNote.Cols[colNoteId].Visible = false;
            grfNote.Cols[colNoteStatusAll].Visible = false;
            grfNote.Cols[colNote].AllowEditing = false;

            theme1.SetTheme(grfNote, "Office2016DarkGray");
        }
        private void UpdateTotals()
        {
            // clear existing totals
            //grfOrder.Subtotal(AggregateEnum.Clear);
            //grfOrder.Subtotal(AggregateEnum.Sum, 0, -1, colOrdAmt, "Total");
        }
        private void initGrfItminPgk()
        {
            grfItminPkg = new C1FlexGrid();
            grfItminPkg.Font = fEdit;
            grfItminPkg.Dock = System.Windows.Forms.DockStyle.Fill;
            grfItminPkg.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            //grfImg.AfterRowColChange += GrfImg_AfterRowColChange;
            //grfImg.MouseDown += GrfImg_MouseDown;
            //grfNote.DoubleClick += GrfNote_DoubleClick;
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            //ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("Upload รูปบัตรประชาชน", new EventHandler(ContextMenu_grfimg_upload_ptt));
            //menuGw.MenuItems.Add("Upload สำเนาบัตรประชาชน ที่มีลายเซ็น", new EventHandler(ContextMenu_grfimg_upload_ptt));
            //menuGw.MenuItems.Add("Upload รูป Passport", new EventHandler(ContextMenu_grfimg_upload_ptt));
            //menuGw.MenuItems.Add("ยกเลิก", new EventHandler(ContextMenu_grfimg_Cancel));
            //grfImgOld.ContextMenu = menuGw;
            pnItminPkg.Controls.Add(grfItminPkg);

            theme1.SetTheme(grfItminPkg, "Office2016Colorful");

        }
        private void setGrfItminPkg()
        {
            //grfDept.Rows.Count = 7;
            grfItminPkg.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.obildDB.selectByHn(txtHn.Text.Trim());
            grfItminPkg.Cols.Count = 9;
            //grfItminPgk.DataSource = dt;

            grfItminPkg.Cols[colItminPkgItmTyp].Width = 100;
            grfItminPkg.Cols[colItminPkgItmName].Width = 320;
            grfItminPkg.Cols[colItminPkgQty].Width = 80;
            grfItminPkg.Cols[colItminPkgPrice].Width = 80;
            grfItminPkg.Cols[colItminPkgExtra].Width = 80;
            grfItminPkg.Cols[colItminPkgQtyAmt].Width = 80;
            grfItminPkg.Cols[colItminPgkOrdDate].Width = 100;

            grfItminPkg.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfItminPkg.Cols[colItminPkgItmTyp].Caption = "Type1";
            grfItminPkg.Cols[colItminPkgItmName].Caption = "Name";
            grfItminPkg.Cols[colItminPkgQty].Caption = "QTY";
            grfItminPkg.Cols[colItminPkgPrice].Caption = "Price";
            grfItminPkg.Cols[colItminPkgExtra].Caption = "Extra";
            grfItminPkg.Cols[colItminPkgQtyAmt].Caption = "Amout";
            grfItminPkg.Cols[colItminPgkOrdDate].Caption = "Date";            
            //grfPackageD.Cols[colBlRemark].Caption = "Remark";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    Row row1 = grfItminPkg.Rows.Add();
                    row1[0] = i;
                    row1[colItminPkgId] = row["id"].ToString();
                    row1[colItminPkgItmTyp] = row["status"].ToString();
                    
                    row1[colItminPkgPrice] = row["Price"].ToString();
                    row1[colItminPkgQty] = row["qty"].ToString();
                    row1[colItminPgkOrdDate] = ic.ivfDB.datetoShow(row["Date"].ToString());
                    row1[colItminPkgExtra] = row["Extra"].ToString();
                    row1[colItminPkgQtyAmt] = "0";
                    if (row["status"].ToString().Equals("package"))
                    {
                        row1.StyleNew.BackColor = Color.FromArgb(143, 200, 127);
                        row1[colItminPkgItmName] = row["PackageName"].ToString();
                    }
                    else if (row["status"].ToString().Equals("special"))
                    {
                        row1.StyleNew.BackColor = Color.FromArgb(244, 222, 242);
                        row1[colItminPkgItmName] = row["SName"].ToString();
                    }
                    else if (row["status"].ToString().Equals("lab"))
                    {
                        row1.StyleNew.BackColor = Color.FromArgb(253, 233, 233);
                        row1[colItminPkgItmName] = row["LName"].ToString();
                    }
                    else if (row["status"].ToString().Equals("drug"))
                    {
                        row1.StyleNew.BackColor = Color.FromArgb(224, 224, 224);
                        row1[colItminPkgItmName] = row["DUName"].ToString();
                    }
                    i++;
                }
                catch (Exception ex)
                {
                    String err = "";
                }

            }
            CellNoteManager mgr = new CellNoteManager(grfItminPkg);
            grfItminPkg.Cols[colPkgdId].Visible = false;
            //grfPackageD.Cols[colPkgId].Visible = false;
            //grfPackageD.Cols[colPkgItmId].Visible = false;

            grfItminPkg.Cols[colPkgType].AllowEditing = false;
            grfItminPkg.Cols[colPkgItmName].AllowEditing = false;
            grfItminPkg.Cols[colPkgQty].AllowEditing = false;
            //theme1.SetTheme(grfFinish, ic.theme);

        }
        private void setControl(String vsid)
        {
            vsOld = ic.ivfDB.ovsDB.selectByPk1(vsid);
            pttOld = ic.ivfDB.pttOldDB.selectByPk1(vsOld.PID);
            vs = ic.ivfDB.vsDB.selectByVn(vsid);
            ptt = ic.ivfDB.pttDB.selectByHn(vsOld.PIDS);
            //ptt.patient_birthday = pttOld.DateOfBirth;        //bug ทำให้ year เกิดผิด
            txtHn.Value = vsOld.PIDS;
            txtApmHn.Value = vsOld.PIDS;
            txtVn.Value = vsOld.VN;
            txtVnShow.Value = ic.showVN(vsOld.VN);
            txtPttNameE.Value = vsOld.PName;
            txtApmName.Value = vsOld.PName;
            //txtDob.Value = ic.datetoShow(pttOld.DateOfBirth) + " [" + ptt.AgeStringShort() + "]";     //  bug ทำให้ year เกิดผิด
            txtDob.Value = ic.datetoShow(ptt.patient_birthday) + " [" + ptt.AgeStringShort() + "]";
            txtAllergy.Value = ptt.allergy_description;
            txtIdOld.Value = pttOld.PID;
            txtVnOld.Value = vsOld.VN;
            txtVsId.Value = vs.t_visit_id;
            txtPttId.Value = ptt.t_patient_id;
            txtSex.Value = ptt.f_sex_id.Equals("1") ? "ชาย" : "หญิง";
            txtBg.Value = ptt.f_patient_blood_group_id.Equals("2140000005") ? "O"
                : ptt.f_patient_blood_group_id.Equals("2140000002") ? "A" : ptt.f_patient_blood_group_id.Equals("2140000003") ? "B"
                : ptt.f_patient_blood_group_id.Equals("2140000004") ? "AB" : "ไม่ระบุ";
            txtVisitHeight.Value = vs.height;
            txtVisitBW.Value = vs.bw;
            txtVisitBP.Value = vs.bp;
            txtVisitPulse.Value = vs.pulse;
            chkChronic.Checked = ptt.status_congenial.Equals("1") ? true : false;
            ic.setC1Combo(cboDoctor, vs.doctor_id);
            Patient ptt1 = new Patient();
            //ptt1 = ic.ivfDB.pttDB.selectByHn(vs.patient_hn_male);
            ptt1 = ic.ivfDB.pttDB.selectByHn(ptt.patient_hn_1);
            txtNameMale.Value = ptt1.Name;
            stt.Show("<p><b>สวัสดี</b></p>คุณ " + ptt.congenital_diseases_description + "<br> กรุณา ป้อนรหัสผ่าน", chkChronic);
            txtCongenital.Value = ptt.congenital_diseases_description;
            //setControlPmh();
            if (cboBsp.Items.Count > 3)
            {
                cboBsp.SelectedIndex = 3;
            }
            ic.ivfDB.eggsDB.setCboPatient(cboEggStiId, txtPttId.Text);
            txtAgent.Value = ic.ivfDB.oAgnDB.getAgentNameById(ptt.agent);
            txtLmp.Value = ptt.lmp;
            ic.ivfDB.vsDB.setCboVisit(cboLabVs, txtVsId.Text, txtPttId.Text);

            Patient ptt2 = new Patient();
            ptt2 = ic.ivfDB.pttDB.selectByHn(ptt.patient_hn_2);
            txtName_2.Value = ptt2.Name;
            if (!ptt.t_patient_id.Equals(""))
            {
                PatientImage pttI = new PatientImage();
                pttI = ic.ivfDB.pttImgDB.selectByPttIDStatus4(ptt.t_patient_id);
                filenamepic = pttI.image_path;
                Thread threadA = new Thread(new ParameterizedThreadStart(ExecuteA));
                threadA.Start();
            }
            //txtBg.Value = pttOld.b
            //txtAllergy.Value = 
        }
        private void ExecuteA(Object obj)
        {
            //Console.WriteLine("Executing parameterless thread!");
            try
            {
                //MemoryStream stream = new MemoryStream();
                //FtpClient ftp = new FtpClient(host, user, pass);
                //stream = ic.ftpC.download(DateTime.Now.Year.ToString() + "/" + filenamepic + "." + System.Drawing.Imaging.ImageFormat.Jpeg);
                //Bitmap bitmap = new Bitmap(stream);
                //Bitmap bitmap = new Bitmap(ic.ftpC.download(DateTime.Now.Year.ToString() + "/" + filenamepic + "." + System.Drawing.Imaging.ImageFormat.Jpeg));
                //picPtt.Image = bitmap;
                //picPtt.SizeMode = PictureBoxSizeMode.StretchImage;
                //setPic(bitmap);
                String aaa = ic.iniC.folderFTP + "/" + txtIdOld.Text + "/" + txtIdOld.Text + "." + System.Drawing.Imaging.ImageFormat.Jpeg;
                //setPic(new Bitmap(ic.ftpC.download(filenamepic)));
                setPic(new Bitmap(ic.ftpC.download(aaa)));
            }
            catch (Exception ex)
            {

            }
        }
        private void setPic(Bitmap bitmap)
        {
            picPtt.Image = bitmap;
            picPtt.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void initGrfOrder()
        {
            grfOrder = new C1FlexGrid();
            grfOrder.Font = fEdit;
            grfOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            grfOrder.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfPackageD);

            grfOrder.AfterDataRefresh += GrfOrder_AfterDataRefresh;
            grfOrder.SubtotalPosition = SubtotalPositionEnum.BelowData;
            //grfOrder.mou
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            if (flagedit.Equals("edit"))
            {
                menuGw.MenuItems.Add("ยกเลิกรายการ", new EventHandler(ContextMenu_ord_void));
                menuGw.MenuItems.Add("Close Package", new EventHandler(ContextMenu_ord_close_package));
            }
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfOrder.ContextMenu = menuGw;
            pnOrder.Controls.Add(grfOrder);

            theme1.SetTheme(grfOrder, "GreenHouse");

        }
        private void ContextMenu_ord_close_package(object sender, System.EventArgs e)
        {
            if (grfOrder.Row < 0) return;
            if (grfOrder[grfOrder.Row, colOrdid] == null) return;
            String id = "", status = "", pkgsid = "", qty = "", itmid = "";
            rowOrder--;

            id = grfOrder[grfOrder.Row, colOrdid].ToString();
            status = grfOrder[grfOrder.Row, colOrdstatus].ToString();
            pkgsid = grfOrder[grfOrder.Row, colOrdPkgSId].ToString();
            qty = grfOrder[grfOrder.Row, colOrdQty].ToString();
            itmid = grfOrder[grfOrder.Row, colOrditmid].ToString();
            if (!status.Equals("package"))
            {
                MessageBox.Show("item is not package", "");
                return;
            }
            String re = "";
            re = ic.ivfDB.opkgsDB.updateStatusPackageClosePackage(pkgsid);
            long chk = 0;
            if(long.TryParse(re, out chk))
            {
                String re1 = ic.ivfDB.oPkgdpDB.voidPackageDepositByPkgsId(id);
                if (re1.Length >= 1)
                {
                    foreach (Control tab in tcOrd.Controls)
                    {
                        if (tab is C1DockingTabPage)
                        {
                            String name = tab.Name;
                            if (name.IndexOf("tabPkgUse_") >= 0)
                            {
                                if (name.Length > 10)
                                {
                                    name = name.Substring(name.Length - 10);
                                    if (name.Equals(id))
                                    {
                                        tcOrd.Controls.Remove(tab);
                                    }
                                }
                            }
                        }
                    }
                    foreach (C1FlexGrid grf in lgrfPkg)
                    {
                        String name = grf.Name;
                        if (name.IndexOf("grfPkg_") >= 0)
                        {
                            lgrfPkg.Remove(grf);
                            break;
                        }
                    }
                    setGrfOrder(txtVnOld.Text);
                }
            }
        }
        private void GrfOrder_AfterDataRefresh(object sender, ListChangedEventArgs e)
        {
            //throw new NotImplementedException();
            UpdateTotals();
        }
        private void setVoidOrd(int row)
        {
            String id = "", status = "", pkgsid = "", qty = "", itmid = "";
            id = grfOrder[row, colOrdid].ToString();
            status = grfOrder[row, colOrdstatus].ToString();
            pkgsid = grfOrder[row, colOrdPkgSId].ToString();
            qty = grfOrder[row, colOrdQty].ToString();
            itmid = grfOrder[row, colOrditmid].ToString();
            if (pkgsid.Length > 1)
            {
                setPkgDId(itmid, "-" + qty,"","");
            }
            if (status.Equals("bloodlab") || status.Equals("Sperm Lab") || status.Equals("Embryo Lab") || status.Equals("Genetic Lab"))
            {
                ic.ivfDB.oJlabdDB.deleteByPk(id);
                String re = ic.ivfDB.oPkgdpDB.upDateQtyUseMinus(pkgsid, itmid, qty);
            }
            else if (status.Equals("specialitem"))
            {
                ic.ivfDB.ojsdDB.deleteByPk(id);
                String re = ic.ivfDB.oPkgdpDB.upDateQtyUseMinus(pkgsid, itmid, qty);
            }
            else if (status.Equals("px"))
            {
                ic.ivfDB.oJpxdDB.deleteByPk(id);
                String re = ic.ivfDB.oPkgdpDB.upDateQtyUseMinus(pkgsid, itmid, qty);
            }
            else if (status.Equals("package"))
            {
                //String re = ic.ivfDB.oPkgdpDB.voidPackageDeposit(ptt.t_patient_id_old);
                String re = ic.ivfDB.oPkgdpDB.voidPackageDepositByPkgsId(id);
                if (re.Length >= 1)
                {
                    foreach (Control tab in tcOrd.Controls)
                    {
                        if (tab is C1DockingTabPage)
                        {
                            String name = tab.Name;
                            if (name.IndexOf("tabPkgUse_") >= 0)
                            {
                                if (name.Length > 10)
                                {
                                    name = name.Substring(name.Length - 10);
                                    if (name.Equals(id))
                                    {
                                        tcOrd.Controls.Remove(tab);
                                    }
                                }
                            }
                        }
                    }
                    foreach (C1FlexGrid grf in lgrfPkg)
                    {
                        String name = grf.Name;
                        if (name.IndexOf("grfPkg_") >= 0)
                        {
                            lgrfPkg.Remove(grf);
                            break;
                        }
                    }
                }
                ic.ivfDB.opkgsDB.deleteByPk(id);
                ic.ivfDB.oJpxdDB.deleteByPkgsId(id);
                ic.ivfDB.oJlabdDB.deleteByPkgsId(id);
                ic.ivfDB.ojsdDB.deleteByPkgsId(id);
            }
        }
        private void ContextMenu_ord_void(object sender, System.EventArgs e)
        {
            if (grfOrder.Row < 0) return;
            if (grfOrder[grfOrder.Row, colOrdid] == null) return;
            String id = "", status = "", pkgsid="", qty="", itmid="";
            

            CellRange cell = grfOrder.Selection;
            //if (cell is null) return;
            if (cell.TopRow<1) return;
            for (int i = cell.TopRow; i <= cell.BottomRow; i++)
            {
                rowOrder--;
                setVoidOrd(i);
            }
            setGrfOrder(txtVnOld.Text);

            foreach (C1FlexGrid grf in lgrfPkg)
            {
                if (grf.Name.Equals("grfPkg_" + pkgsid))
                {
                    setGrfPgk(pkgsid, grf);
                }
            }
        }
        private void setGrfOrder(String vn)
        {
            //grfDept.Rows.Count = 7;
            grfOrder.Clear();
            DataTable dtAll = new DataTable();
            DataTable dtbl = new DataTable();
            DataTable dtse = new DataTable();
            DataTable dtpx = new DataTable();
            DataTable dtpkg = new DataTable();

            dtbl = ic.ivfDB.oJlabdDB.selectByVN(vn);
            dtse = ic.ivfDB.ojsdDB.selectByVN(vn);
            dtpx = ic.ivfDB.oJpxdDB.selectByVN(vn);
            //dtpkg = ic.ivfDB.opkgsDB.selectByVN(vn);
            dtpkg = ic.ivfDB.opkgsDB.selectByPID(pid);    // ต้องดึงตาม HN เพราะ ถ้ามีงวดการชำระ 
            dtpkg = ic.ivfDB.opkgsDB.selectByPIDStatusPackageON(pid);    // ต้องดึงตาม HN เพราะ ถ้ามีงวดการชำระ 

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            //grfEmbryo.Rows.Count = dt.Rows.Count + 1;

            dtAll.Columns.Add("id", typeof(String));
            dtAll.Columns.Add("lgid", typeof(String));
            dtAll.Columns.Add("name", typeof(String));
            dtAll.Columns.Add("price", typeof(String));
            dtAll.Columns.Add("qty", typeof(String));
            dtAll.Columns.Add("status", typeof(String));
            dtAll.Columns.Add("row1", typeof(int));
            dtAll.Columns.Add("itmid", typeof(String));
            dtAll.Columns.Add("extra", typeof(String));
            dtAll.Columns.Add("usage", typeof(String));
            dtAll.Columns.Add("lab_order_id", typeof(String));
            dtAll.Columns.Add("status_amt", typeof(String));
            dtAll.Columns.Add("status_order_group", typeof(String));
            dtAll.Columns.Add("price1", typeof(String));
            dtAll.Columns.Add("pckdid", typeof(String));
            int i = 0;
            foreach (DataRow row in dtbl.Rows)
            {
                DataRow row1 = dtAll.NewRow();
                row1["id"] = row["ID"];
                row1["itmid"] = row["LID"];
                row1["lgid"] = row["LGID"];
                row1["name"] = row["LName"];
                row1["price"] = row["Price"];
                row1["qty"] = row["QTY"];
                row1["row1"] = row["row1"];
                row1["extra"] = row["Extra"];
                row1["usage"] = "";
                row1["lab_order_id"] = row["lab_order_id"];
                row1["status_amt"] = row["status_amt"];
                row1["status_order_group"] = row["status_order_group"];
                row1["price1"] = row["price1"];
                row1["pckdid"] = row["pckdid"];
                if (row["LGID"].ToString().Equals("1"))
                {
                    row1["status"] = "bloodlab";
                }
                else if (row["LGID"].ToString().Equals("2"))
                {
                    row1["status"] = "";
                }
                else if (row["LGID"].ToString().Equals("3"))
                {
                    row1["status"] = "Sperm Lab";
                }
                else if (row["LGID"].ToString().Equals("4"))
                {
                    row1["status"] = "Embryo Lab";
                }
                else if (row["LGID"].ToString().Equals("5"))
                {
                    row1["status"] = "Genetic Lab";
                }
                dtAll.Rows.InsertAt(row1, i);
                i++;
            }
            foreach (DataRow row in dtse.Rows)
            {
                DataRow row1 = dtAll.NewRow();
                row1["id"] = row["ID"];
                row1["itmid"] = row["SID"];
                row1["lgid"] = "";
                row1["name"] = row["SName"];
                row1["price"] = row["Price"];
                row1["qty"] = row["qty"];
                row1["status"] = "specialitem";
                row1["row1"] = row["row1"];
                row1["extra"] = row["Extra"];
                row1["usage"] = "";
                row1["lab_order_id"] = "0";
                row1["status_amt"] = "1";
                row1["status_order_group"] = "0";
                row1["price1"] = row["price1"];
                row1["pckdid"] = row["pckdid"];
                dtAll.Rows.InsertAt(row1, i);
                i++;
            }
            foreach (DataRow row in dtpx.Rows)
            {
                DataRow row1 = dtAll.NewRow();
                row1["id"] = row["ID"];
                row1["itmid"] = row["DUID"];
                row1["lgid"] = "";
                row1["name"] = row["DUName"];
                row1["price"] = row["Price"];
                row1["qty"] = row["QTY"];
                row1["status"] = "px";
                row1["row1"] = row["row1"];
                row1["extra"] = row["Extra"];
                row1["usage"] = row["TUsage"];
                row1["lab_order_id"] = "0";
                row1["status_amt"] = "1";
                row1["status_order_group"] = "0";
                row1["price1"] = row["price1"];
                row1["pckdid"] = row["pckdid"];
                dtAll.Rows.InsertAt(row1, i);
                i++;
            }
            
            foreach (DataRow row in dtpkg.Rows)
            {
                String bill1 = "", bill2 = "", bill3 = "", bill4 = "", times = "", name = "";
                Decimal price = 0, pay1 = 0, pay2 = 0, pay3 = 0, pay4 = 0, pay = 0;
                Decimal.TryParse(row["price"].ToString(), out price);
                Decimal.TryParse(row["payment1"].ToString(), out pay1);
                Decimal.TryParse(row["payment2"].ToString(), out pay2);
                Decimal.TryParse(row["payment3"].ToString(), out pay3);
                Decimal.TryParse(row["payment4"].ToString(), out pay4);
                times = row["payment_times"].ToString();
                bill1 = row["P1BDetailID"].ToString();
                bill2 = row["P2BDetailID"].ToString();
                bill3 = row["P3BDetailID"].ToString();
                bill4 = row["P4BDetailID"].ToString();
                name = row["PackageName"].ToString();
                if (price > 0)
                {
                    if ((pay1 > 0) && bill1.Equals("0"))
                    {
                        pay = pay1;
                        name += "1/" + times;
                    }
                    else if ((pay2 > 0) && bill2.Equals("0"))
                    {
                        pay = pay2;
                        name += "2/" + times;
                    }
                    else if ((pay3 > 0) && bill3.Equals("0"))
                    {
                        pay = pay3;
                        name += "3/" + times;
                    }
                    else if ((pay4 > 0) && bill4.Equals("0"))
                    {
                        pay = pay4;
                        name += "4/" + times;
                    }
                    DataRow row1 = dtAll.NewRow();
                    row1["id"] = row["PCKSID"];
                    row1["itmid"] = row["PCKID"];
                    row1["lgid"] = "";
                    row1["name"] = name;
                    row1["price"] = pay;
                    row1["qty"] = "1";
                    row1["status"] = "package";
                    row1["row1"] = row["row1"];
                    row1["extra"] = "0";
                    row1["usage"] = "";
                    row1["lab_order_id"] = "0";
                    row1["status_amt"] = "1";
                    row1["status_order_group"] = "0";
                    row1["price1"] = pay;
                    row1["pckdid"] = "";
                    dtAll.Rows.InsertAt(row1, i);
                    i++;
                }
                setTabPkg(row["PCKSID"].ToString(), row["PackageName"].ToString());
            }
            dtAll.DefaultView.Sort = "row1";
            DataView view = dtAll.DefaultView;
            view.Sort = "row1 ASC";
            DataTable sortedDate = view.ToTable();
            //grfOrder.DataSource = dtAll;
            grfOrder.Cols.Count = 19;
            //C1TextBox txt = new C1TextBox();
            //C1CheckBox chk = new C1CheckBox();
            //chk.Text = "Include Package";
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            //grfOrder.Cols[1].Editor = txt;
            //grfOrder.Cols[colOrderPrice].Editor = txt;
            //grfOrder.Cols[colOrderQTY].Editor = txt;
            //grfOrder.Cols[colRxId].Editor = txt;

            grfOrder.Cols[colOrdName].Width = 280;
            grfOrder.Cols[colOrdPrice].Width = 100;
            grfOrder.Cols[colOrdQty].Width = 80;
            grfOrder.Cols[colOrdUsT].Width = 100;

            grfOrder.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfOrder.Cols[colOrdName].Caption = "Name";
            if (ic.iniC.statusCashierOldProgram.Equals("1"))
            {
                grfOrder.Cols[colOrdPrice].Caption = "SumPrice";
                grfOrder.Cols[colOrdPrice1].Caption = "Price1";
            }
            else
            {
                grfOrder.Cols[colOrdPrice].Caption = "Price";
                grfOrder.Cols[colOrdPrice1].Caption = "Price1";
            }
            //grfOrder.Cols[colOrdPrice1].Caption = "Price";
            grfOrder.Cols[colOrdQty].Caption = "QTY";
            grfOrder.Cols[colOrdInclude].Caption = "Include Package";
            grfOrder.Cols[colOrdUsT].Caption = "Usage";
            grfOrder.Cols[colOrdAmt].Caption = "Amount";
            //grfOrder.SubtotalPosition = SubtotalPositionEnum.BelowData;
            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            i = 1;
            grfOrder.Rows.Count = 1;
            Decimal inc = 0, ext = 0;
            foreach (DataRow row in sortedDate.Rows)
            {
                try
                {
                    Decimal price = 0, qty = 0, price1=0;
                    Row row1 = grfOrder.Rows.Add();
                    row1[colOrdid] = row["id"].ToString();
                    row1[colOrdlpid] = row["lgid"].ToString();
                    row1[colOrdName] = row["name"].ToString();
                    row1[colOrdUsT] = row["usage"].ToString();
                    //row1[colOrdQty] = row["qty"].ToString();
                    row1[colOrdstatus] = row["status"].ToString();
                    row1[colOrdrow1] = row["row1"].ToString();
                    row1[colOrditmid] = row["itmid"].ToString();
                    row1[colOrdInclude] = row["extra"].ToString().Equals("1") ? "Extra" : "Include";

                    Decimal.TryParse(row["price"].ToString(), out price);
                    Decimal.TryParse(row["price1"].ToString(), out price1);
                    Decimal.TryParse(row["qty"].ToString(), out qty);
                    row1[colOrdPrice] = price.ToString("#,###.00");
                    row1[colOrdPrice1] = price1.ToString("#,###.00");
                    row1[colOrdQty] = qty.ToString("#,###.00");
                    row1[colOrdAmt] = (price * qty).ToString("#,###.00");
                    if (row["status_amt"].ToString().Equals("1"))
                    {
                        if (row["extra"].ToString().Equals("1"))
                        {
                            if (ic.iniC.statusCashierOldProgram.Equals("1"))
                            {
                                ext += price;
                            }
                            else
                            {
                                ext += (price1 * qty);
                            }
                        }
                        else
                        {
                            if (row["status"].ToString().Equals("package"))
                            {
                                if (ic.iniC.statusCashierOldProgram.Equals("1"))
                                {
                                    inc += price;
                                }
                                else
                                {
                                    inc += (price1 * qty);
                                }
                            }
                        }
                    }

                    if (ic.iniC.statusCashierOldProgram.Equals("1"))
                    {
                        row1[colOrdAmt] = price.ToString("#,###.00");
                    }
                    else
                    {
                        row1[colOrdAmt] = (price1 * qty).ToString("#,###.00");
                    }
                    row1[colOrdOrderId] = row["lab_order_id"].ToString();
                    row1[colOrdStatusAmt] = row["status_amt"].ToString();
                    row1[colOrdStatusOrdGrp] = row["status_order_group"].ToString();
                    row1[0] = i;
                    row1[colOrdPkgSId] = row["pckdid"].ToString();
                    if (row["status"].ToString().Equals("package"))
                        row1.StyleNew.BackColor = Color.FromArgb(143, 200, 127);
                    else if (row["status"].ToString().Equals("specialitem"))
                        row1.StyleNew.BackColor = Color.FromArgb(244, 222, 242);
                    else if (row["status"].ToString().Equals("bloodlab"))
                        row1.StyleNew.BackColor = Color.FromArgb(253, 233, 233);
                    else if (row["status"].ToString().Equals("Sperm Lab"))
                        row1.StyleNew.BackColor = Color.FromArgb(244, 252, 232);
                    else if (row["status"].ToString().Equals("Embryo Lab"))
                        row1.StyleNew.BackColor = Color.FromArgb(218, 237, 255);
                    else if (row["status"].ToString().Equals("Genetic Lab"))
                        row1.StyleNew.BackColor = Color.FromArgb(255, 255, 231);
                    else if (row["status"].ToString().Equals("px"))
                        row1.StyleNew.BackColor = Color.FromArgb(224, 224, 224);
                    if (row["pckdid"].ToString().Length>1)
                    {
                        CellNote note = new CellNote("Package "+ row["pckdid"].ToString());
                        CellRange rg = grfOrder.GetCellRange(i, colOrdName);
                        rg.UserData = note;
                    }
                    i++;
                }
                catch (Exception ex)
                {
                    String err = "";
                }
            }
            rowOrder = grfOrder.Rows.Count;
            CellNoteManager mgr = new CellNoteManager(grfOrder);
            grfOrder.Cols[colOrdrow1].Visible = false;
            grfOrder.Cols[colOrdlpid].Visible = false;
            grfOrder.Cols[colOrdid].Visible = false;
            //grfOrder.Cols[colOrdstatus].Visible = false;
            grfOrder.Cols[colOrditmid].Visible = false;
            if (ic.iniC.statusCashierOldProgram.Equals("1"))
            {
                grfOrder.Cols[colOrdPrice].Visible = false;
                grfOrder.Cols[colOrdPrice1].Visible = true;
            }
            else
            {
                grfOrder.Cols[colOrdPrice].Visible = true;
                grfOrder.Cols[colOrdPrice1].Visible = false;
            }
            grfOrder.Cols[colOrdUsE].Visible = false;
            grfOrder.Cols[colOrdDate].Visible = false;
            //grfOrder.Cols[colOrderPIDS].Visible = false;
            //grfOrder.Cols[colOrderSP1V].Visible = false;
            //grfOrder.Cols[colOrderSP2V].Visible = false;
            //grfOrder.Cols[colOrderSP3V].Visible = false;
            //grfOrder.Cols[colOrderSP4V].Visible = false;
            //grfOrder.Cols[colOrderSP5V].Visible = false;
            //grfOrder.Cols[colOrderSP6V].Visible = false;
            //grfOrder.Cols[colOrderSP7V].Visible = false;
            //grfOrder.Cols[colOrderSubItem].Visible = false;
            //grfOrder.Cols[colOrderFileName].Visible = false;
            //grfOrder.Cols[colOrderWorder1].Visible = false;
            //grfOrder.Cols[colOrderWorker2].Visible = false;
            //grfOrder.Cols[colOrderWorker3].Visible = false;
            //grfOrder.Cols[colOrderWorkder4].Visible = false;
            //grfOrder.Cols[colOrderWorker5].Visible = false;
            //grfOrder.Cols[colOrderLGID].Visible = false;
            //grfOrder.Cols[colOrderActive].Visible = false;
            //grfOrder.Cols[colOrderLID].Visible = false;
            grfOrder.Cols[colOrdUsT].AllowEditing = false;
            grfOrder.Cols[colOrdName].AllowEditing = false;
            grfOrder.Cols[colOrdPrice].AllowEditing = false;
            grfOrder.Cols[colOrdQty].AllowEditing = false;
            grfOrder.Cols[colOrdOrderId].AllowEditing = false;
            grfOrder.Cols[colOrdStatusAmt].AllowEditing = false;
            grfOrder.Cols[colOrdStatusOrdGrp].AllowEditing = false;
            grfOrder.Cols[colOrdPkgSId].AllowEditing = false;
            //theme1.SetTheme(grfFinish, ic.theme);
            //UpdateTotals();
            String total = "";
            Decimal total1 = 0;
            //total = grfOrder[grfOrder.Rows.Count - 1, colOrdAmt] != null ? grfOrder[grfOrder.Rows.Count - 1, colOrdAmt].ToString() : "";
            total1 = inc + ext;
            //Decimal.TryParse(total, out total1);
            txtTotal.Value = total1.ToString("#,###.00");
            txtInclude.Value = inc.ToString("#,###.00");
            txtExtra.Value = ext.ToString("#,###.00");
        }
        private void setGrfpackageD(String id)
        {
            //grfDept.Rows.Count = 7;
            grfPackageD.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oPkgdDB.selectByPkgId2(id);

            grfPackageD.Rows.Count = dt.Rows.Count + 1;
            //grfEmbryo.Rows.Count = dt.Rows.Count + 1;
            //grfPackageD.DataSource = dt;
            grfPackageD.Cols.Count = 8;
            //C1TextBox txt = new C1TextBox();
            //C1CheckBox chk = new C1CheckBox();
            ///*chk*/.Text = "Include Package";
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            //grfPackageD.Cols[colBlName].Editor = txt;
            //grfPackageD.Cols[colBlInclude].Editor = txt;
            //grfPackageD.Cols[colBlPrice].Editor = txt;
            //grfPackageD.Cols[colBlRemark].Editor = txt;

            grfPackageD.Cols[colPkgType].Width = 100;
            grfPackageD.Cols[colPkgItmName].Width = 320;
            grfPackageD.Cols[colPkgQty].Width = 80;
            grfPackageD.Cols[colPkgUse].Width = 80;

            grfPackageD.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfPackageD.Cols[colPkgType].Caption = "Type1";
            grfPackageD.Cols[colPkgItmName].Caption = "Name";
            grfPackageD.Cols[colPkgQty].Caption = "QTY";
            grfPackageD.Cols[colPkgUse].Caption = "Use";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    grfPackageD[i, 0] = i;
                    grfPackageD[i, colPkgdId] = row["ID"].ToString();
                    grfPackageD[i, colPkgsId] = row["PCKID"].ToString();
                    grfPackageD[i, colPkgType] = row["ItemType"].ToString();
                    grfPackageD[i, colPkgItmName] = row["ItemName"].ToString();
                    grfPackageD[i, colPkgQty] = row["QTY"].ToString();
                    grfPackageD[i, colPkgItmId] = row["ItemID"].ToString();
                    grfPackageD[i, colPkgUse] = "0";
                    //if (i % 2 == 0)
                    //    grfPtt.Rows[i].StyleNew.BackColor = color;
                    i++;
                }
                catch (Exception ex)
                {
                    String err = "";
                }

            }
            CellNoteManager mgr = new CellNoteManager(grfPackageD);
            grfPackageD.Cols[colPkgdId].Visible = false;
            grfPackageD.Cols[colPkgsId].Visible = false;
            //grfPackageD.Cols[colPkgItmId].Visible = false;

            grfPackageD.Cols[colPkgType].AllowEditing = false;
            grfPackageD.Cols[colPkgItmName].AllowEditing = false;
            grfPackageD.Cols[colPkgQty].AllowEditing = false;
            grfPackageD.Cols[colPkgUse].AllowEditing = false;
            //theme1.SetTheme(grfFinish, ic.theme);

        }
        private void initGrfPackageD()
        {
            grfPackageD = new C1FlexGrid();
            grfPackageD.Font = fEdit;
            grfPackageD.Dock = System.Windows.Forms.DockStyle.Fill;
            grfPackageD.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfPackageD);

            //grfPackageD.AfterRowColChange += GrfPackageD_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfPackageD.ContextMenu = menuGw;
            pnPackageD.Controls.Add(grfPackageD);

            theme1.SetTheme(grfPackageD, "GreenHouse");

        }

        private void GrfPackageD_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();

        }
        private void setGrfpackage()
        {
            //grfDept.Rows.Count = 7;
            grfPackage.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oPkgDB.selectAll();

            grfPackage.Rows.Count = dt.Rows.Count + 1;
            //grfEmbryo.Rows.Count = dt.Rows.Count + 1;
            //grfPackage.DataSource = dt;
            grfPackage.Cols.Count = 7;
            CellStyle cs = grfBloodLab.Styles.Add("bool");
            cs.DataType = typeof(bool);
            cs.ImageAlign = ImageAlignEnum.LeftCenter;

            grfPackage.Cols[colBlName].Width = 320;
            grfPackage.Cols[colBlInclude].Width = 80;
            grfPackage.Cols[colBlPrice].Width = 80;
            grfPackage.Cols[colBlRemark].Width = 100;
            grfPackage.Cols[colBlQty].Width = 60;

            grfPackage.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";                        

            CellRange rg = grfPackage.GetCellRange(2, colBlInclude, grfPackage.Rows.Count - 1, colBlInclude);
            rg.Style = cs;
            rg.Style = grfPackage.Styles["bool"];
            for (int col = 0; col < dt.Columns.Count; ++col)
            {
                grfPackage.Cols[col + 1].DataType = dt.Columns[col].DataType;
                grfPackage.Cols[col + 1].Caption = dt.Columns[col].ColumnName;
                grfPackage.Cols[col + 1].Name = dt.Columns[col].ColumnName;
            }
            grfPackage.Cols[colBlName].Caption = "PackageName";
            grfPackage.Cols[colBlInclude].Caption = "Include";
            grfPackage.Cols[colBlPrice].Caption = "Price";
            grfPackage.Cols[colBlRemark].Caption = "Remark";
            grfPackage.Cols[colBlQty].Caption = "QTY";
            int i = 0;
            decimal aaa = 0;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    i++;
                    if (i == 1) continue;
                    Decimal.TryParse(row[ic.ivfDB.oPkgDB.oPkg.Price].ToString(), out aaa);
                    grfPackage[i, colBlPrice] = aaa.ToString("#,##0");
                    grfPackage[i, colBlId] = row[ic.ivfDB.oPkgDB.oPkg.PCKID].ToString();
                    grfPackage[i, colBlName] = row[ic.ivfDB.oPkgDB.oPkg.PackageName].ToString();
                    grfPackage[i, colBlQty] = "1";
                }
                catch (Exception ex)
                {
                    String err = "";
                }

            }
            CellNoteManager mgr = new CellNoteManager(grfPackage);
            grfPackage.Cols[colBlId].Visible = false;
            grfPackage.Cols[colBlInclude].Visible = false;

            grfPackage.Cols[colBlQty].AllowEditing = false;
            grfPackage.Cols[colBlName].AllowEditing = false;
            grfPackage.Cols[colBlPrice].AllowEditing = false;
            grfPackage.Cols[colBlRemark].AllowEditing = false;

            FilterRow fr = new FilterRow(grfPackage);
            grfPackage.AllowFiltering = true;
            grfPackage.AfterFilter += GrfPackage_AfterFilter;
            //theme1.SetTheme(grfFinish, ic.theme);

        }

        private void GrfPackage_AfterFilter(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            for (int col = grfPackage.Cols.Fixed; col < grfPackage.Cols.Count; ++col)
            {
                var filter = grfPackage.Cols[col].ActiveFilter;
            }
        }

        private void initGrfPackage()
        {
            grfPackage = new C1FlexGrid();
            grfPackage.Font = fEdit;
            grfPackage.Dock = System.Windows.Forms.DockStyle.Fill;
            grfPackage.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfPackage);

            grfPackage.AfterRowColChange += GrfPackage_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            //ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("สั่งการ", new EventHandler(ContextMenu_order_pkg));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            //grfPackage.ContextMenu = menuGw;
            pnPackage.Controls.Add(grfPackage);

            theme1.SetTheme(grfPackage, "GreenHouse");

        }
        private void GrfPackage_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (grfPackage.Row < 0) return;
            if (grfPackage[grfPackage.Row, colBlId] == null) return;

            String id = "";
            id = grfPackage[grfPackage.Row, colBlId].ToString();
            OldPackageHeader opkg = new OldPackageHeader();
            opkg = ic.ivfDB.oPkgDB.selectByPk1(id);
            txtPkgName.Value = opkg.PackageName;
            txtPkgId.Value = opkg.PCKID;
            txtPrice.Value = opkg.Price;
            txtPayment1.Value = opkg.Price;
            setGrfpackageD(id);
        }
        
        private void setPkgPeriod()
        {
            OldPackageSold opkgs = new OldPackageSold();
            opkgs.PCKSID = "";
            opkgs.PID = txtIdOld.Text;
            opkgs.SellThruID = cboSellThruID.SelectedItem == null ? "" : ((ComboBoxItem)cboSellThruID.SelectedItem).Value;
            opkgs.PCKID = txtPkgId.Text;
            opkgs.PackageName = txtPkgName.Text;
            opkgs.Price = txtPrice.Text;
            opkgs.Date = "";
            opkgs.PaymentTimes = "";
            opkgs.Status = "1";
            opkgs.Payment1 = txtPayment1.Text;
            opkgs.Payment2 = txtPayment2.Text;
            opkgs.Payment3 = txtPayment3.Text;
            opkgs.Payment4 = txtPayment4.Text;
            opkgs.P1BDetailID = "";
            opkgs.P2BDetailID = "";
            opkgs.P3BDetailID = "";
            opkgs.P4BDetailID = "";
            opkgs.VN = txtVnOld.Text;
            opkgs.row1 = grfOrder.Rows.Count.ToString();
            ic.ivfDB.PackageAdd(opkgs,"");
        }
        private void initGrfRxSetD()
        {
            grfRxSetD = new C1FlexGrid();
            grfRxSetD.Font = fEdit;
            grfRxSetD.Dock = System.Windows.Forms.DockStyle.Fill;
            grfRxSetD.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfPackageD);

            grfRxSetD.AfterRowColChange += GrfRxSetD_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfRxSetD.ContextMenu = menuGw;
            pnRxSetD.Controls.Add(grfRxSetD);

            theme1.SetTheme(grfRxSetD, "Office2016DarkGray");

        }

        private void GrfRxSetD_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();

        }
        private void setGrfRxSetD(String id)
        {
            //grfDept.Rows.Count = 7;
            grfRxSetD.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oGudDB.selectByGdId1(id);

            grfRxSetD.Rows.Count = dt.Rows.Count + 1;
            //grfEmbryo.Rows.Count = dt.Rows.Count + 1;
            //grfRxSetD.DataSource = dt;
            grfRxSetD.Cols.Count = 11;
            CellStyle cs = grfRxSetD.Styles.Add("bool");
            cs.DataType = typeof(bool);
            cs.ImageAlign = ImageAlignEnum.LeftCenter;

            grfRxSetD.Cols[colRxName].Width = 300;
            grfRxSetD.Cols[colRxInclude].Width = 80;
            grfRxSetD.Cols[colRxPrice].Width = 80;
            grfRxSetD.Cols[colRxRemark].Width = 100;
            grfRxSetD.Cols[colRxUsE].Width = 200;
            grfRxSetD.Cols[colRxUsT].Width = 200;
            grfRxSetD.Cols[colRxQty].Width = 60;

            grfRxSetD.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfRxSetD.Cols[colRxName].Caption = "Name";
            grfRxSetD.Cols[colRxInclude].Caption = "Include";
            grfRxSetD.Cols[colRxPrice].Caption = "Price";
            grfRxSetD.Cols[colRxQty].Caption = "QTY";
            grfRxSetD.Cols[colRxRemark].Caption = "Remark";

            CellRange rg = grfRxSetD.GetCellRange(1, colRxInclude, grfRxSetD.Rows.Count - 1, colRxInclude);
            rg.Style = cs;
            rg.Style = grfRxSetD.Styles["bool"];
            int i = 0;
            decimal aaa = 0;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    i++;
                    //if (i == 1) continue;

                    Decimal.TryParse(row["Price"].ToString(), out aaa);
                    grfRxSetD[i, colRxPrice] = aaa.ToString("#,##0");
                    grfRxSetD[i, colRxdId] = row[ic.ivfDB.oGudDB.oGuD.DUID].ToString();
                    grfRxSetD[i, colRxName] = row[ic.ivfDB.oGudDB.oGuD.DUName].ToString();
                    grfRxSetD[i, colRxQty] = row[ic.ivfDB.oGudDB.oGuD.QTY].ToString();
                    grfRxSetD[i, colRxUsE] = row["EUsage"].ToString();
                    grfRxSetD[i, colRxUsT] = row["TUsage"].ToString();
                }
                catch (Exception ex)
                {
                    String err = "";
                }

            }
            CellNoteManager mgr = new CellNoteManager(grfRxSetD);
            grfRxSetD.Cols[colRxdId].Visible = false;
            grfRxSetD.Cols[colRxId].Visible = false;
            grfRxSetD.Cols[colRxItmId].Visible = false;
            grfRxSetD.Cols[colBlRemark].Visible = false;

            grfRxSetD.Cols[colRxName].AllowEditing = false;
            grfRxSetD.Cols[colRxQty].AllowEditing = false;
            //grfRxSetD.Cols[colBlRemark].AllowEditing = false;
            //theme1.SetTheme(grfFinish, ic.theme);

            if (dt.Rows.Count > 0)
                btnPkgOrder.Enabled = true;
        }
        private void initGrfRxSet()
        {
            grfRxSet = new C1FlexGrid();
            grfRxSet.Font = fEdit;
            grfRxSet.Dock = System.Windows.Forms.DockStyle.Fill;
            grfRxSet.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfRxSet);

            grfRxSet.AfterRowColChange += GrfRxSet_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            if (flagedit.Equals("edit"))
            {
                menuGw.MenuItems.Add("สั่งการ", new EventHandler(ContextMenu_order_rx_set));
            }
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfRxSet.ContextMenu = menuGw;
            pnRxSet.Controls.Add(grfRxSet);

            theme1.SetTheme(grfRxSet, "Office2016DarkGray");

        }
        private void setRxSet()
        {
            if (grfRxSetD.Rows.Count > 0)
            {
                if (grfRxSetD.Row <= 0) return;
                foreach (Row row in grfRxSetD.Rows)
                {
                    if (row[colRxdId] == null) continue;
                    String duid = "", include = "", qty = "", usaget = "", usagee = "", duname = "", price = "", usage = "";
                    duid = row[colRxdId].ToString();
                    usaget = row[colRxUsT].ToString();
                    usagee = row[colRxUsE].ToString();
                    duname = row[colRxName].ToString();
                    price = row[colRxPrice].ToString();
                    include = row[colRxInclude] != null ? row[colRxInclude].ToString().Equals("True") ? "1" : "0" : "0";
                    qty = row[colBlQty] != null ? row[colBlQty].ToString() : "1";
                    if (cboLangSticker.Text.Equals("English"))
                    {
                        usage = row[colRxUsE] != null ? row[colRxUsE].ToString() : "";
                    }
                    else
                    {
                        usage = row[colRxUsT] != null ? row[colRxUsT].ToString() : "";
                    }
                    usaget = usage;
                    if (include.Equals("1"))
                    {
                        ic.ivfDB.PxSetAdd(duid, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", grfOrder.Rows.Count.ToString(), qty, usaget, usagee, duname, price);
                    }
                    else
                    {
                        ic.ivfDB.PxSetAdd(duid, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "1", grfOrder.Rows.Count.ToString(), qty, usaget, usagee, duname, price);
                    }
                }

                setGrfOrder(txtVnOld.Text);
            }
        }
        private void ContextMenu_order_rx_set(object sender, System.EventArgs e)
        {
            setRxSet();
        }
        private void GrfRxSet_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (grfRxSet.Row < 0) return;
            if (grfRxSet[grfRxSet.Row, colBlId] == null) return;
            //btnPkgOrder.Enabled = false;
            String id = grfRxSet[grfRxSet.Row, colBlId].ToString();
            setGrfRxSetD(id);

        }

        private void setGrfRxSet()
        {
            //grfDept.Rows.Count = 7;
            grfRxSet.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oGrpDb.selectByGrpDrugH1();

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            //grfEmbryo.Rows.Count = dt.Rows.Count + 1;
            grfRxSet.DataSource = dt;
            grfRxSet.Cols.Count = 7;
            //C1TextBox txt = new C1TextBox();
            //C1CheckBox chk = new C1CheckBox();
            //chk.Text = "Include Package";
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            //grfRxSet.Cols[colBlName].Editor = txt;
            //grfRxSet.Cols[colBlInclude].Editor = txt;
            //grfRxSet.Cols[colBlPrice].Editor = txt;
            //grfRxSet.Cols[colBlRemark].Editor = txt;

            grfRxSet.Cols[colBlName].Width = 320;
            grfRxSet.Cols[colBlInclude].Width = 120;
            grfRxSet.Cols[colBlPrice].Width = 80;
            grfRxSet.Cols[colBlRemark].Width = 100;

            grfRxSet.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfRxSet.Cols[colBlName].Caption = "Name";
            grfRxSet.Cols[colBlInclude].Caption = "Include";
            grfRxSet.Cols[colBlPrice].Caption = "Price";
            grfRxSet.Cols[colBlRemark].Caption = "Remark";

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            int i = 0;
            foreach (Row row in grfRxSet.Rows)
            {
                try
                {
                    i++;
                    if (i == 1) continue;
                    //if (i == 2) continue;
                    row[0] = (i - 2);
                }
                catch (Exception ex)
                {
                    String err = "";
                }
            }
            CellNoteManager mgr = new CellNoteManager(grfRxSet);
            grfRxSet.Cols[colBlId].Visible = false;
            grfRxSet.Cols[colBlInclude].Visible = false;
            //grfRx.Cols[colBlPrice].Visible = false;

            grfRxSet.Cols[colBlName].AllowEditing = false;
            grfRxSet.Cols[colBlPrice].AllowEditing = false;
            grfRxSet.Cols[colBlRemark].AllowEditing = false;
            //theme1.SetTheme(grfFinish, ic.theme);

        }
        private void initGrfRx()
        {
            grfRx = new C1FlexGrid();
            grfRx.Font = fEdit;
            grfRx.Dock = System.Windows.Forms.DockStyle.Fill;
            grfRx.Location = new System.Drawing.Point(0, 0);

            //FilterRowUnBound fr = new FilterRowUnBound(grfRx);

            grfRx.DoubleClick += GrfRx_DoubleClick;
            //grfRx.AfterFilter += GrfRx_AfterFilter;

            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            if (flagedit.Equals("edit"))
            {
                menuGw.MenuItems.Add("สั่งการ", new EventHandler(ContextMenu_order_rx));
            }
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfRx.ContextMenu = menuGw;
            pnRx.Controls.Add(grfRx);

            theme1.SetTheme(grfRx, "Office2010Black");

        }
        private void GrfRx_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfRx.Col == colBlQty) return;
            if (flagedit.Equals("edit"))
            {
                setOrderRx();
            }
        }
        private void setOrderRx()
        {
            if (grfRx.Row <= 0) return;
            if (grfRx[grfRx.Row, colBlId] == null) return;
            String chk = "", name = "", drugid = "", qty = "", include = "", usage = "", pkgdid = "", qtyext="";
            drugid = grfRx[grfRx.Row, colRxdId] != null ? grfRx[grfRx.Row, colRxdId].ToString() : "";
            qty = grfRx[grfRx.Row, colRxQty] != null ? grfRx[grfRx.Row, colRxQty].ToString() : "";
            //include = grfRx[grfRx.Row, colRxInclude] != null ? grfRx[grfRx.Row, colRxInclude].ToString().Equals("True") ? "1" : "0" : "0";
            pkgdid = setPkgDId(drugid, qty,"","");
            String[] pkgdid1 = pkgdid.Split('#');
            if (pkgdid1.Length > 1)
            {
                qtyext = pkgdid1[1];
                pkgdid = pkgdid1[0];
            }
            else
            {
                include = pkgdid.Length > 0 ? "1" : "";
                qtyext = "";
            }
            
            if (cboLangSticker.Text.Equals("English"))
            {
                usage = grfRx[grfRx.Row, colRxUsE] != null ? grfRx[grfRx.Row, colRxUsE].ToString() : "";
            }
            else
            {
                usage = grfRx[grfRx.Row, colRxUsT] != null ? grfRx[grfRx.Row, colRxUsT].ToString() : "";
            }
            //sep.Clear();
            if (include.Equals("1"))
            {
                if (ic.iniC.statusCashierOldProgram.Equals("1"))
                {
                    if (qtyext.Length > 0)
                    {
                        Decimal qty1 = 0, qtyext1=0;
                        Decimal.TryParse(qty, out qty1);
                        Decimal.TryParse(qtyext, out qtyext1);
                        ic.ivfDB.PxAdd(drugid, (qty1 - qtyext1).ToString(), txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", grfOrder.Rows.Count.ToString(), usage, "old", pkgdid);
                        ic.ivfDB.PxAdd(drugid, qtyext, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "1", grfOrder.Rows.Count.ToString(), usage, "old", pkgdid);
                    }
                    else
                    {
                        ic.ivfDB.PxAdd(drugid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", grfOrder.Rows.Count.ToString(), usage, "old", pkgdid);
                    }
                }
                else
                {
                    if (qtyext.Length > 0)
                    {
                        Decimal qty1 = 0, qtyext1 = 0;
                        Decimal.TryParse(qty, out qty1);
                        Decimal.TryParse(qtyext, out qtyext1);
                        ic.ivfDB.PxAdd(drugid, (qty1 - qtyext1).ToString(), txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", grfOrder.Rows.Count.ToString(), usage, "old", pkgdid);
                        ic.ivfDB.PxAdd(drugid, qtyext, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", grfOrder.Rows.Count.ToString(), usage, "old", pkgdid);
                    }
                    else
                    {
                        ic.ivfDB.PxAdd(drugid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", grfOrder.Rows.Count.ToString(), usage, pkgdid);
                    }
                }
            }
            else
            {
                //if (ic.iniC.statusCashierOldProgram.Equals("1"))      // 63-05-05
                //{
                //    ic.ivfDB.PxAdd(drugid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "1", grfOrder.Rows.Count.ToString(), usage, "old");
                //}
                //else
                //{
                if (qtyext.Length > 0)
                {
                    Decimal qty1 = 0, qtyext1 = 0;
                    Decimal.TryParse(qty, out qty1);
                    Decimal.TryParse(qtyext, out qtyext1);
                    if((qty1 - qtyext1)> 0)
                    {
                        ic.ivfDB.PxAdd(drugid, (qty1 - qtyext1).ToString(), txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", grfOrder.Rows.Count.ToString(), usage, pkgdid);
                    }
                    ic.ivfDB.PxAdd(drugid, qtyext, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "1", grfOrder.Rows.Count.ToString(), usage, "");
                }
                else
                {
                    ic.ivfDB.PxAdd(drugid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "1", grfOrder.Rows.Count.ToString(), usage, "");
                }
                //}
            }
            setGrfOrder(txtVnOld.Text);
        }
        private void ContextMenu_order_rx(object sender, System.EventArgs e)
        {
            setOrderRx();
        }
        private void setGrfRx()
        {
            //grfDept.Rows.Count = 7;
            //grfRx.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oStkdDB.selectBySockDrug1();

            grfRx.Rows.Count = dt.Rows.Count + 1;
            //grfEmbryo.Rows.Count = dt.Rows.Count + 1;
            //grfRx.DataSource = dt;
            grfRx.Cols.Count = 9;
            CellStyle cs = grfRx.Styles.Add("bool");
            cs.DataType = typeof(bool);
            cs.ImageAlign = ImageAlignEnum.LeftCenter;

            grfRx.Cols[colRxName].Width = 300;
            grfRx.Cols[colRxInclude].Width = 80;
            grfRx.Cols[colRxPrice].Width = 80;
            grfRx.Cols[colRxRemark].Width = 100;
            grfRx.Cols[colRxUsE].Width = 200;
            grfRx.Cols[colRxUsT].Width = 200;
            grfRx.Cols[colRxQty].Width = 60;

            grfRx.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";
            
            CellRange rg = grfRx.GetCellRange(2, colBlInclude, grfRx.Rows.Count - 1, colBlInclude);
            rg.Style = cs;
            rg.Style = grfRx.Styles["bool"];
            for (int col = 0; col < dt.Columns.Count; ++col)
            {
                grfRx.Cols[col + 1].DataType = dt.Columns[col].DataType;
                grfRx.Cols[col + 1].Caption = dt.Columns[col].ColumnName;
                grfRx.Cols[col + 1].Name = dt.Columns[col].ColumnName;
            }
            grfRx.Cols[colRxName].Caption = "Name";
            grfRx.Cols[colRxInclude].Caption = "Include";
            //if (ic.iniC.statusCashierOldProgram.Equals("1"))
            //{
            //    grfRx.Cols[colRxPrice].Caption = "SumPrice";
            //}
            //else
            //{
                grfRx.Cols[colRxPrice].Caption = "Price";
            //}
                
            grfRx.Cols[colRxQty].Caption = "QTY";
            grfRx.Cols[colRxRemark].Caption = "Remark";
            grfRx.Cols[colRxUsE].Caption = "Usage English";
            grfRx.Cols[colRxUsT].Caption = "Usage Thai";
            int i = 0;
            decimal aaa = 0;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    i++;
                    if (i == 1) continue;
                    grfRx[i, colBlId] = row["DUID"].ToString();
                    grfRx[i, colRxName] = row["DUName"].ToString();
                    Decimal.TryParse(row[ic.ivfDB.oLabiDB.labI.Price].ToString(), out aaa);
                    grfRx[i, colRxPrice] = aaa.ToString("#,##0");
                    grfRx[i, colRxQty] = "1";
                    grfRx[i, colBlRemark] = "";
                    grfRx[i, colRxUsE] = row["EUsage"].ToString();
                    grfRx[i, colRxUsT] = row["TUsage"].ToString();
                    //Row row1 = grfRx.Rows.Add();
                    //row1[colBlId] = row["DUID"].ToString();
                    //row1[colBlName] = row["DUName"].ToString();
                    //row1[colBlPrice] = row["Price"].ToString();
                    //row1[colBlRemark] = "";
                    //if (i == 1) continue;
                    //if (i == 2) continue;
                    grfRx[i, 0] = (i - 2);
                }
                catch (Exception ex)
                {
                    String err = "";
                }
            }
            CellNoteManager mgr = new CellNoteManager(grfRx);
            grfRx.Cols[colBlId].Visible = false;
            grfRx.Cols[colBlRemark].Visible = false;
            //grfRx.Cols[colBlPrice].Visible = false;
            //FilterRowUnBound fr = new FilterRowUnBound(grfRx);
            grfRx.Cols[colBlName].AllowEditing = false;
            grfRx.Cols[colBlPrice].AllowEditing = false;
            grfRx.Cols[colBlRemark].AllowEditing = true;
            if (ic.iniC.statusNurseOrderInclude.Equals("1"))
            {
                grfRx.Cols[colBlInclude].Visible = true;
            }
            else
            {
                grfRx.Cols[colBlInclude].Visible = false;
            }
            //grfRx.AllowFiltering = true;

            FilterRow fr = new FilterRow(grfRx);
            grfRx.AllowFiltering = true;
            grfRx.AfterFilter += GrfRx_AfterFilter;
            //theme1.SetTheme(grfFinish, ic.theme);

        }

        private void GrfRx_AfterFilter(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            for (int col = grfRx.Cols.Fixed; col < grfRx.Cols.Count; ++col)
            {
                var filter = grfRx.Cols[col].ActiveFilter;
            }
        }

        private void initGrfSpecialLab()
        {
            grfSpecial = new C1FlexGrid();
            grfSpecial.Font = fEdit;
            grfSpecial.Dock = System.Windows.Forms.DockStyle.Fill;
            grfSpecial.Location = new System.Drawing.Point(0, 0);

            //FilterRow2 fr = new FilterRow2(grfSpecial);

            grfSpecial.AfterRowColChange += GrfMed_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            if (flagedit.Equals("edit"))
            {
                menuGw.MenuItems.Add("สั่งการ", new EventHandler(ContextMenu_order_se_set));
            }
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfSpecial.ContextMenu = menuGw;
            pnSpecial.Controls.Add(grfSpecial);

            theme1.SetTheme(grfSpecial, "Office2010Barbie");
            grfSpecial.AfterFilter += GrfSpecial_AfterFilter;
            grfSpecial.DoubleClick += GrfSpecial_DoubleClick;
        }

        private void ContextMenu_order_se_set(object sender, System.EventArgs e)
        {
            if (grfSpecial.Row <= 0) return;
            if (grfSpecial[grfSpecial.Row, colBlId] == null) return;
            String labid = "", include = "", qty = "", pkgdid = "";
            labid = grfSpecial[grfSpecial.Row, colBlId].ToString();
            include = grfSpecial[grfSpecial.Row, colBlInclude] != null ? grfSpecial[grfSpecial.Row, colBlInclude].ToString().Equals("True") ? "1" : "0" : "0";
            qty = grfSpecial[grfSpecial.Row, colBlQty] != null ? grfSpecial[grfSpecial.Row, colBlQty].ToString() : "1";
            pkgdid = setPkgDId(labid, qty,"","");
            include = pkgdid.Length > 0 ? "1" : "";
            if (include.Equals("1"))
            {
                ic.ivfDB.SpecialAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", "", "", "", "", grfOrder.Rows.Count.ToString(), pkgdid);
            }
            else
            {
                ic.ivfDB.SpecialAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "1", "", "", "", "", grfOrder.Rows.Count.ToString(), pkgdid);
            }

            setGrfOrder(txtVnOld.Text);
        }
        private void setGrfSpecial()
        {
            //grfDept.Rows.Count = 7;
            grfSpecial.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oSItmDB.selectBySpecialItem2();

            grfSpecial.Rows.Count = dt.Rows.Count + 1;
            //grfEmbryo.Rows.Count = dt.Rows.Count + 1;
            //grfSpecial.DataSource = dt;
            grfSpecial.Cols.Count = 7;
            CellStyle cs = grfSpecial.Styles.Add("bool");
            cs.DataType = typeof(bool);
            cs.ImageAlign = ImageAlignEnum.LeftCenter;

            grfSpecial.Cols[colBlName].Width = 320;
            grfSpecial.Cols[colBlQty].Width = 60;
            grfSpecial.Cols[colBlInclude].Width = 80;
            grfSpecial.Cols[colBlPrice].Width = 80;
            grfSpecial.Cols[colBlRemark].Width = 200;

            grfSpecial.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            CellRange rg = grfSpecial.GetCellRange(2, colBlInclude, grfSpecial.Rows.Count - 1, colBlInclude);
            rg.Style = cs;
            rg.Style = grfSpecial.Styles["bool"];

            for (int col = 0; col < dt.Columns.Count; ++col)
            {
                grfSpecial.Cols[col + 1].DataType = dt.Columns[col].DataType;
                grfSpecial.Cols[col + 1].Caption = dt.Columns[col].ColumnName;
                grfSpecial.Cols[col + 1].Name = dt.Columns[col].ColumnName;
            }
            grfSpecial.Cols[colBlName].Caption = "Name";
            grfSpecial.Cols[colBlInclude].Caption = "Include";
            //if (ic.iniC.statusCashierOldProgram.Equals("1"))
            //{
            //    grfSpecial.Cols[colBlPrice].Caption = "SumPrice";
            //}
            //else
            //{
                grfSpecial.Cols[colBlPrice].Caption = "Price";
            //}
            grfSpecial.Cols[colBlRemark].Caption = "Remark";
            grfSpecial.Cols[colBlQty].Caption = "QTY";
            int i = 0;
            decimal aaa = 0;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    i++;
                    if (i == 1) continue;

                    Decimal.TryParse(row[ic.ivfDB.oSItmDB.sitm.Price].ToString(), out aaa);
                    grfSpecial[i, colBlPrice] = aaa.ToString("#,##0");
                    grfSpecial[i, colBlId] = row[ic.ivfDB.oSItmDB.sitm.SID].ToString();
                    grfSpecial[i, colBlName] = row[ic.ivfDB.oSItmDB.sitm.SName].ToString();
                    grfSpecial[i, colBlQty] = "1";
                    grfSpecial[i, colBlRemark] = row["bilgrpname"].ToString();
                }
                catch (Exception ex)
                {
                    String err = "";
                }
            }
            //grfSpecial.Rows.Count = dt.Rows.Count + 2;
            //grfSpecial.Cols.Count = dt.Columns.Count + 1+2;
            //for (int row = 0; row < dt.Rows.Count; ++row)
            //{
            //    for (int col = 0; col < dt.Columns.Count; ++col)
            //    {
            //        grfSpecial[row + 2, col + 1] = dt.Rows[row][col];
            //    }
            //}
            CellNoteManager mgr = new CellNoteManager(grfSpecial);
            grfSpecial.Cols[colBlId].Visible = false;
            //grfSpecial.Cols[colBlInclude].Visible = false;
            //grfSpecial.Cols[colBlPrice].Visible = false;

            grfSpecial.Cols[colBlName].AllowEditing = false;
            grfSpecial.Cols[colBlPrice].AllowEditing = false;
            grfSpecial.Cols[colBlRemark].AllowEditing = false;
            if (ic.iniC.statusNurseOrderInclude.Equals("1"))
            {
                grfSpecial.Cols[colBlInclude].Visible = true;
            }
            else
            {
                grfSpecial.Cols[colBlInclude].Visible = false;
            }

            FilterRow fr = new FilterRow(grfSpecial);
            grfSpecial.AllowFiltering = true;
            
            //theme1.SetTheme(grfFinish, ic.theme);

        }

        private void GrfSpecial_AfterFilter(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            for (int col = grfSpecial.Cols.Fixed; col < grfSpecial.Cols.Count; ++col)
            {
                var filter = grfSpecial.Cols[col].ActiveFilter;
            }
        }
        private void GrfSpecial_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfSpecial.Col == colBlQty) return;
            if (flagedit.Equals("edit"))
            {
                setOrderSpecial();
            }
        }
        private void setOrderSpecial()
        {
            if (grfSpecial.Row <= 0) return;
            if (grfSpecial[grfSpecial.Row, colBlId] == null) return;
            String labid = "", include = "", qty = "", pkgdid = "", qtyext = "";
            rowOrder++;
            labid = grfSpecial[grfSpecial.Row, colBlId].ToString();
            include = grfSpecial[grfSpecial.Row, colBlInclude] != null ? grfSpecial[grfSpecial.Row, colBlInclude].ToString().Equals("True") ? "1" : "0" : "0";
            qty = grfSpecial[grfSpecial.Row, colBlQty] != null ? grfSpecial[grfSpecial.Row, colBlQty].ToString() : "1";
            pkgdid = setPkgDId(labid, qty,"","");
            String[] pkgdid1 = pkgdid.Split('#');
            if (pkgdid1.Length > 1)
            {
                qtyext = pkgdid1[1];
                pkgdid = pkgdid1[0];
            }
            else
            {
                include = pkgdid.Length > 0 ? "1" : "";
                qtyext = "";
            }
            //include = pkgdid.Length > 0 ? "1" : "";
            if (include.Equals("1"))
            {
                if (ic.iniC.statusCashierOldProgram.Equals("1"))
                {
                    if (qtyext.Length > 0)
                    {
                        Decimal qty1 = 0, qtyext1 = 0;
                        Decimal.TryParse(qty, out qty1);
                        Decimal.TryParse(qtyext, out qtyext1);
                        ic.ivfDB.SpecialAdd(labid, (qty1 - qtyext1).ToString(), txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", "", "", "", "", grfOrder.Rows.Count.ToString(), "old", pkgdid);
                        ic.ivfDB.SpecialAdd(labid, qtyext, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "1", "", "", "", "", grfOrder.Rows.Count.ToString(), "old", "");
                    }
                    else
                    {
                        ic.ivfDB.SpecialAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", "", "", "", "", grfOrder.Rows.Count.ToString(), "old", pkgdid);
                    }
                }
                else
                {
                    if (qtyext.Length > 0)
                    {
                        Decimal qty1 = 0, qtyext1 = 0;
                        Decimal.TryParse(qty, out qty1);
                        Decimal.TryParse(qtyext, out qtyext1);
                        ic.ivfDB.SpecialAdd(labid, (qty1 - qtyext1).ToString(), txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", "", "", "", "", grfOrder.Rows.Count.ToString(), pkgdid);
                        ic.ivfDB.SpecialAdd(labid, qtyext, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", "", "", "", "", grfOrder.Rows.Count.ToString(), pkgdid);
                    }
                    else
                    {
                        ic.ivfDB.SpecialAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", "", "", "", "", grfOrder.Rows.Count.ToString(), pkgdid);
                    }
                }
            }
            else
            {
                //if (ic.iniC.statusCashierOldProgram.Equals("1"))
                //{
                //    ic.ivfDB.SpecialAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "1", "", "", "", "", grfOrder.Rows.Count.ToString(), "old", pkgdid);
                //}
                //else
                //{
                //    ic.ivfDB.SpecialAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "1", "", "", "", "", grfOrder.Rows.Count.ToString(), pkgdid);
                //}
                if (qtyext.Length > 0)
                {
                    Decimal qty1 = 0, qtyext1 = 0;
                    Decimal.TryParse(qty, out qty1);
                    Decimal.TryParse(qtyext, out qtyext1);
                    if ((qty1 - qtyext1) > 0)
                    {
                        ic.ivfDB.SpecialAdd(labid, (qty1 - qtyext1).ToString(), txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", "", "", "", "", grfOrder.Rows.Count.ToString(), pkgdid);
                    }
                    ic.ivfDB.SpecialAdd(labid, qtyext, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "1", "", "", "", "", grfOrder.Rows.Count.ToString(), "");
                }
                else
                {
                    ic.ivfDB.SpecialAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "1", "", "", "", "", grfOrder.Rows.Count.ToString(), "");
                }
            }

            setGrfOrder(txtVnOld.Text);
        }
        private void _flex_AfterFilter(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            for (int col = grfSpecial.Cols.Fixed; col < grfSpecial.Cols.Count; ++col)
            {
                var filter = grfSpecial.Cols[col].ActiveFilter;
            }
        }

        private void initGrfGeneticLab()
        {
            grfGenetic = new C1FlexGrid();
            grfGenetic.Font = fEdit;
            grfGenetic.Dock = System.Windows.Forms.DockStyle.Fill;
            grfGenetic.Location = new System.Drawing.Point(0, 0);

            //FilterRow2 fr = new FilterRow2(grfGenetic);

            grfGenetic.DoubleClick += GrfGenetic_DoubleClick;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            if (flagedit.Equals("edit"))
            {
                menuGw.MenuItems.Add("สั่งการ", new EventHandler(ContextMenu_order_ge_set));
            }
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfGenetic.ContextMenu = menuGw;
            pnGenetic.Controls.Add(grfGenetic);

            theme1.SetTheme(grfGenetic, "RainerOrange");

        }

        private void GrfGenetic_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfGenetic.Col == colBlQty) return;
            if (flagedit.Equals("edit"))
            {
                setOrderGenetic();
            }
        }
        private void setOrderGenetic()
        {
            if (grfGenetic.Row <= 0) return;
            if (grfGenetic[grfGenetic.Row, colBlId] == null) return;
            String labid = "", include = "", qty = "", pkgdid = "";
            rowOrder++;
            labid = grfGenetic[grfGenetic.Row, colBlId].ToString();
            include = grfGenetic[grfGenetic.Row, colBlInclude] != null ? grfGenetic[grfGenetic.Row, colBlInclude].ToString().Equals("True") ? "1" : "0" : "0";
            qty = grfGenetic[grfGenetic.Row, colBlQty] != null ? grfGenetic[grfGenetic.Row, colBlQty].ToString() : "1";
            pkgdid = setPkgDId(labid, qty,"","");
            include = pkgdid.Length > 0 ? "1" : "";
            if (include.Equals("1"))
            {
                if (ic.iniC.statusCashierOldProgram.Equals("1"))
                {
                    ic.ivfDB.LabAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString(), "0", "1", "0", "old", pkgdid);
                }
                else
                {
                    ic.ivfDB.LabAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString(), "0", "1", "0", pkgdid);
                }
            }
            else
            {
                if (ic.iniC.statusCashierOldProgram.Equals("1"))
                {
                    ic.ivfDB.LabAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "1", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString(), "0", "1", "0", "old", pkgdid);
                }
                else
                {
                    ic.ivfDB.LabAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "1", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString(), "0", "1", "0", pkgdid);
                }
            }

            setGrfOrder(txtVnOld.Text);
        }
        private void ContextMenu_order_ge_set(object sender, System.EventArgs e)
        {
            setOrderGenetic();
        }
        private void setGrfGenetic()
        {
            //grfDept.Rows.Count = 7;
            grfGenetic.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oLabiDB.selectByGeneticLab1();

            grfGenetic.Rows.Count = dt.Rows.Count + 1;
            //grfEmbryo.Rows.Count = dt.Rows.Count + 1;
            //grfGenetic.DataSource = dt;
            grfGenetic.Cols.Count = 7;
            CellStyle cs = grfGenetic.Styles.Add("bool");
            cs.DataType = typeof(bool);
            cs.ImageAlign = ImageAlignEnum.LeftCenter;

            grfGenetic.Cols[colBlName].Width = 320;
            grfGenetic.Cols[colBlInclude].Width = 80;
            grfGenetic.Cols[colBlPrice].Width = 80;
            grfGenetic.Cols[colBlRemark].Width = 100;
            grfGenetic.Cols[colBlQty].Width = 60;

            grfGenetic.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";
            
            CellRange rg = grfGenetic.GetCellRange(2, colBlInclude, grfGenetic.Rows.Count - 1, colBlInclude);
            rg.Style = cs;
            rg.Style = grfGenetic.Styles["bool"];
            for (int col = 0; col < dt.Columns.Count; ++col)
            {
                grfGenetic.Cols[col + 1].DataType = dt.Columns[col].DataType;
                grfGenetic.Cols[col + 1].Caption = dt.Columns[col].ColumnName;
                grfGenetic.Cols[col + 1].Name = dt.Columns[col].ColumnName;
            }
            grfGenetic.Cols[colBlName].Caption = "Name";
            grfGenetic.Cols[colBlInclude].Caption = "Include";
            grfGenetic.Cols[colBlPrice].Caption = "Price";
            grfGenetic.Cols[colBlRemark].Caption = "Remark";
            grfGenetic.Cols[colBlQty].Caption = "QTY";
            int i = 0;
            decimal aaa = 0;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    i++;
                    if (i == 1) continue;

                    Decimal.TryParse(row[ic.ivfDB.oLabiDB.labI.Price].ToString(), out aaa);
                    grfGenetic[i, colBlPrice] = aaa.ToString("#,##0");
                    grfGenetic[i, colBlId] = row[ic.ivfDB.oLabiDB.labI.LID].ToString();
                    grfGenetic[i, colBlName] = row[ic.ivfDB.oLabiDB.labI.LName].ToString();
                    grfGenetic[i, colBlQty] = "1";
                }
                catch (Exception ex)
                {
                    String err = "";
                }
            }
            CellNoteManager mgr = new CellNoteManager(grfGenetic);
            grfGenetic.Cols[colBlId].Visible = false;
            //grfGenetic.Cols[colBlInclude].Visible = false;
            //grfGenetic.Cols[colBlPrice].Visible = false;

            grfGenetic.Cols[colBlName].AllowEditing = false;
            grfGenetic.Cols[colBlPrice].AllowEditing = false;
            grfGenetic.Cols[colBlRemark].AllowEditing = false;
            if (ic.iniC.statusNurseOrderInclude.Equals("1"))
            {
                grfGenetic.Cols[colBlInclude].Visible = true;
            }
            else
            {
                grfGenetic.Cols[colBlInclude].Visible = false;
            }

            FilterRow fr = new FilterRow(grfGenetic);
            grfGenetic.AllowFiltering = true;
            grfGenetic.AfterFilter += GrfGenetic_AfterFilter;
            //theme1.SetTheme(grfFinish, ic.theme);

        }

        private void GrfGenetic_AfterFilter(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            for (int col = grfGenetic.Cols.Fixed; col < grfGenetic.Cols.Count; ++col)
            {
                var filter = grfGenetic.Cols[col].ActiveFilter;
            }
        }

        private void initGrfEmbryoLab()
        {
            grfEmbryo = new C1FlexGrid();
            grfEmbryo.Font = fEdit;
            grfEmbryo.Dock = System.Windows.Forms.DockStyle.Fill;
            grfEmbryo.Location = new System.Drawing.Point(0, 0);

            //FilterRow2 fr = new FilterRow2(grfEmbryo);

            grfEmbryo.DoubleClick += GrfEmbryo_DoubleClick;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            if (flagedit.Equals("edit"))
            {
                menuGw.MenuItems.Add("สั่งการ", new EventHandler(ContextMenu_order_em_set));
            }
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfEmbryo.ContextMenu = menuGw;
            pnEmbryo.Controls.Add(grfEmbryo);

            theme1.SetTheme(grfEmbryo, "ShinyBlue");

        }
        private void setOrderEmbryo()
        {
            if (grfEmbryo.Row <= 0) return;
            if (grfEmbryo[grfEmbryo.Row, colBlId] == null) return;
            String labid = "", include = "", qty = "", pkgdid = "";
            rowOrder++;
            labid = grfEmbryo[grfEmbryo.Row, colBlId].ToString();
            include = grfEmbryo[grfEmbryo.Row, colBlInclude] != null ? grfEmbryo[grfEmbryo.Row, colBlInclude].ToString().Equals("True") ? "1" : "0" : "0";
            qty = grfEmbryo[grfEmbryo.Row, colBlQty] != null ? grfEmbryo[grfEmbryo.Row, colBlQty].ToString() : "1";
            pkgdid = setPkgDId(labid, qty,"","");
            include = pkgdid.Length > 0 ? "1" : "";
            if (include.Equals("1"))
            {
                if (ic.iniC.statusCashierOldProgram.Equals("1"))
                {
                    ic.ivfDB.LabAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString(), "0", "1", "0","old", pkgdid);
                }
                else
                {
                    ic.ivfDB.LabAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString(), "0", "1", "0", pkgdid);
                }
            }
            else
            {
                if (ic.iniC.statusCashierOldProgram.Equals("1"))
                {
                    ic.ivfDB.LabAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "1", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString(), "0", "1", "0","old", pkgdid);
                }
                else
                {
                    ic.ivfDB.LabAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "1", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString(), "0", "1", "0", pkgdid);
                }
            }
            setGrfOrder(txtVnOld.Text);
        }
        private void GrfEmbryo_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfEmbryo.Col == colBlQty) return;
            if (flagedit.Equals("edit"))
            {
                setOrderEmbryo();
            }
        }

        private void ContextMenu_order_em_set(object sender, System.EventArgs e)
        {
            setOrderEmbryo();
        }
        private void setGrfEmbryo()
        {
            //grfDept.Rows.Count = 7;
            grfEmbryo.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oLabiDB.selectByEmbryoLab1();

            grfEmbryo.Rows.Count = dt.Rows.Count + 1;
            //grfEmbryo.Rows.Count = dt.Rows.Count + 1;
            //grfEmbryo.DataSource = dt;
            grfEmbryo.Cols.Count = 7;
            CellStyle cs = grfEmbryo.Styles.Add("bool");
            cs.DataType = typeof(bool);
            cs.ImageAlign = ImageAlignEnum.LeftCenter;

            grfEmbryo.Cols[colBlName].Width = 320;
            grfEmbryo.Cols[colBlInclude].Width = 80;
            grfEmbryo.Cols[colBlPrice].Width = 80;
            grfEmbryo.Cols[colBlRemark].Width = 100;
            grfEmbryo.Cols[colBlQty].Width = 60;

            grfEmbryo.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";
            
            CellRange rg = grfEmbryo.GetCellRange(2, colBlInclude, grfEmbryo.Rows.Count - 1, colBlInclude);
            rg.Style = cs;
            rg.Style = grfEmbryo.Styles["bool"];
            for (int col = 0; col < dt.Columns.Count; ++col)
            {
                grfEmbryo.Cols[col + 1].DataType = dt.Columns[col].DataType;
                grfEmbryo.Cols[col + 1].Caption = dt.Columns[col].ColumnName;
                grfEmbryo.Cols[col + 1].Name = dt.Columns[col].ColumnName;
            }
            grfEmbryo.Cols[colBlName].Caption = "Name";
            grfEmbryo.Cols[colBlInclude].Caption = "Include";
            grfEmbryo.Cols[colBlPrice].Caption = "Price";
            grfEmbryo.Cols[colBlRemark].Caption = "Remark";
            grfEmbryo.Cols[colBlQty].Caption = "QTY";
            int i = 0;
            decimal aaa = 0;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    i++;
                    if (i == 1) continue;

                    Decimal.TryParse(row[ic.ivfDB.oLabiDB.labI.Price].ToString(), out aaa);
                    grfEmbryo[i, colBlPrice] = aaa.ToString("#,##0");
                    grfEmbryo[i, colBlId] = row[ic.ivfDB.oLabiDB.labI.LID].ToString();
                    grfEmbryo[i, colBlName] = row[ic.ivfDB.oLabiDB.labI.LName].ToString();
                    grfEmbryo[i, colBlQty] = "1";
                }
                catch (Exception ex)
                {
                    String err = "";
                }

            }
            CellNoteManager mgr = new CellNoteManager(grfEmbryo);
            grfEmbryo.Cols[colBlId].Visible = false;
            //grfEmbryo.Cols[colBlInclude].Visible = false;
            //grfEmbryo.Cols[colBlPrice].Visible = false;

            grfEmbryo.Cols[colBlName].AllowEditing = false;
            grfEmbryo.Cols[colBlPrice].AllowEditing = false;
            grfEmbryo.Cols[colBlRemark].AllowEditing = false;
            if (ic.iniC.statusNurseOrderInclude.Equals("1"))
            {
                grfEmbryo.Cols[colBlInclude].Visible = true;
            }
            else
            {
                grfEmbryo.Cols[colBlInclude].Visible = false;
            }

            FilterRow fr = new FilterRow(grfEmbryo);
            grfEmbryo.AllowFiltering = true;
            grfEmbryo.AfterFilter += GrfEmbryo_AfterFilter;
            //theme1.SetTheme(grfFinish, ic.theme);

        }

        private void GrfEmbryo_AfterFilter(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            for (int col = grfEmbryo.Cols.Fixed; col < grfEmbryo.Cols.Count; ++col)
            {
                var filter = grfEmbryo.Cols[col].ActiveFilter;
            }
        }

        private void initGrfSpermLab()
        {
            grfSperm = new C1FlexGrid();
            grfSperm.Font = fEdit;
            grfSperm.Dock = System.Windows.Forms.DockStyle.Fill;
            grfSperm.Location = new System.Drawing.Point(0, 0);

            //FilterRow2 fr = new FilterRow2(grfSperm);

            grfSperm.AfterRowColChange += GrfMed_AfterRowColChange;
            grfSperm.DoubleClick += GrfSperm_DoubleClick;
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            if (flagedit.Equals("edit"))
            {
                menuGw.MenuItems.Add("สั่งการ", new EventHandler(ContextMenu_order_sp_set));
            }
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfSperm.ContextMenu = menuGw;
            pnSperm.Controls.Add(grfSperm);

            theme1.SetTheme(grfSperm, "Office2010Green");

        }

        private void GrfSperm_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfSperm.Col == colBlQty) return;
            if (flagedit.Equals("edit"))
            {
                setOrderSperm();
            }
        }

        private void setOrderSperm()
        {
            if (grfSperm.Row <= 0) return;
            if (grfSperm[grfSperm.Row, colBlId] == null) return;
            String labid = "", include = "", qty = "", pkgdid = "";
            rowOrder++;
            labid = grfSperm[grfSperm.Row, colBlId].ToString();
            include = grfSperm[grfSperm.Row, colBlInclude] != null ? grfSperm[grfSperm.Row, colBlInclude].ToString().Equals("True") ? "1" : "0" : "0";
            qty = grfSperm[grfSperm.Row, colBlQty] != null ? grfSperm[grfSperm.Row, colBlQty].ToString() : "1";
            pkgdid = setPkgDId(labid, qty,"","");
            include = pkgdid.Length > 0 ? "1" : "";
            if (include.Equals("1"))
            {
                if (ic.iniC.statusCashierOldProgram.Equals("1"))
                {
                    ic.ivfDB.LabAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString(), "0", "1", "0", "old", pkgdid);
                }
                else
                {
                    ic.ivfDB.LabAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString(), "0", "1", "0", pkgdid);
                }
                    
            }
            else
            {
                if (ic.iniC.statusCashierOldProgram.Equals("1"))
                {
                    ic.ivfDB.LabAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "1", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString(), "0", "1", "0", "old", pkgdid);
                }
                else
                {
                    ic.ivfDB.LabAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "1", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString(), "0", "1", "0", pkgdid);
                }
            }

            setGrfOrder(txtVnOld.Text);
        }
        private void ContextMenu_order_sp_set(object sender, System.EventArgs e)
        {
            setOrderSperm();
        }
        private void setGrfSperm()
        {
            //grfDept.Rows.Count = 7;
            grfSperm.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oLabiDB.selectBySpermLab1();
            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfSperm.Rows.Count = dt.Rows.Count + 1;
            //grfSperm.DataSource = dt;
            grfSperm.Cols.Count = 7;
            CellStyle cs = grfSperm.Styles.Add("bool");
            cs.DataType = typeof(bool);
            cs.ImageAlign = ImageAlignEnum.LeftCenter;

            grfSperm.Cols[colBlName].Width = 320;
            grfSperm.Cols[colBlInclude].Width = 80;
            grfSperm.Cols[colBlPrice].Width = 80;
            grfSperm.Cols[colBlRemark].Width = 100;
            grfSperm.Cols[colBlQty].Width = 60;

            grfSperm.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfSperm.Cols[colBlName].Caption = "Name";
            grfSperm.Cols[colBlInclude].Caption = "Include";
            grfSperm.Cols[colBlQty].Caption = "QTY";
            //if (ic.iniC.statusCashierOldProgram.Equals("1"))
            //{
            //    grfSperm.Cols[colBlPrice].Caption = "SumPrice";
            //}
            //else
            //{
                grfSperm.Cols[colBlPrice].Caption = "Price";
            //}
            grfSperm.Cols[colBlRemark].Caption = "Remark";

            CellRange rg = grfSperm.GetCellRange(1, colBlInclude, grfSperm.Rows.Count - 1, colBlInclude);
            rg.Style = cs;
            rg.Style = grfSperm.Styles["bool"];

            int i = 0;
            decimal aaa = 0;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    i++;
                    //if (i == 1) continue;
                    Decimal.TryParse(row[ic.ivfDB.oLabiDB.labI.Price].ToString(), out aaa);
                    grfSperm[i, colBlPrice] = aaa.ToString("#,##0");
                    grfSperm[i, colBlId] = row[ic.ivfDB.oLabiDB.labI.LID].ToString();
                    grfSperm[i, colBlName] = row[ic.ivfDB.oLabiDB.labI.LName].ToString();
                    grfSperm[i, colBlQty] = "1";
                    row[0] = (i - 2);
                }
                catch (Exception ex)
                {
                    String err = "";
                }

            }
            CellNoteManager mgr = new CellNoteManager(grfSperm);
            grfSperm.Cols[colBlId].Visible = false;
            //grfSperm.Cols[colBlInclude].Visible = false;
            //grfSperm.Cols[colBlPrice].Visible = false;

            grfSperm.Cols[colBlName].AllowEditing = false;
            grfSperm.Cols[colBlPrice].AllowEditing = false;
            grfSperm.Cols[colBlRemark].AllowEditing = false;
            if (ic.iniC.statusNurseOrderInclude.Equals("1"))
            {
                grfSperm.Cols[colBlInclude].Visible = true;
            }
            else
            {
                grfSperm.Cols[colBlInclude].Visible = false;
            }
            //theme1.SetTheme(grfFinish, ic.theme);

        }
        private void initGrfBloodLab()
        {
            grfBloodLab = new C1FlexGrid();
            grfBloodLab.Font = fEdit;
            grfBloodLab.Dock = System.Windows.Forms.DockStyle.Fill;
            grfBloodLab.Location = new System.Drawing.Point(0, 0);

            //FilterRow2 fr = new FilterRow2(grfBloodLab);

            grfBloodLab.DoubleClick += GrfBloodLab_DoubleClick;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            if (flagedit.Equals("edit"))
            {
                menuGw.MenuItems.Add("สั่งการ", new EventHandler(ContextMenu_order_bl_set));
            }

            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfBloodLab.ContextMenu = menuGw;
            pnBloodLab.Controls.Add(grfBloodLab);

            theme1.SetTheme(grfBloodLab, "Office2010Red");

        }
        private void ContextMenu_order_bl_set(object sender, System.EventArgs e)
        {
            setOrderBloodLab();
        }
        private void GrfBloodLab_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfBloodLab.Col == colBlQty) return;
            if (flagedit.Equals("edit"))
            {
                setOrderBloodLab();
            }
        }
        private String setPkgDId(String id, String qty, String ordergroup, String itmid)
        {
            String pkgsid = "";
            foreach (C1FlexGrid grf in lgrfPkg)
            {
                foreach (Row row in grf.Rows)
                {
                    String id1 = "";
                    id1 = id;
                    if (row[colPkgItmId] == null) continue;
                    if (row[colPkgItmId].ToString().Equals(itmid))
                    {
                        id1 = itmid;
                    }
                    if (row[colPkgItmId].ToString().Equals(id1))
                    {
                        String pkgqty = "", pkguse = "";
                        Decimal pkgqty1 = 0, pkguse1 = 0, qty1 = 0,qtyamt=0, qtyamt1=0;
                        pkgqty = row[colPkgQty].ToString();
                        pkguse = row[colPkgUse].ToString();
                        //pkguse = row[colPkgUse].ToString();
                        Decimal.TryParse(pkgqty, out pkgqty1);
                        Decimal.TryParse(pkguse, out pkguse1);
                        Decimal.TryParse(qty, out qty1);
                        if(pkgqty1 < pkguse1)
                        {
                            pkgsid = "";
                            break;
                        }
                        qtyamt = pkgqty1 - pkguse1;
                        qtyamt1 = qtyamt - qty1;
                        if(qtyamt >= qty1)
                        {
                            // จำนวนคงเหลือ มากกว่า จำนวนที่ป้อน
                            //pkgsid = (pkgqty1 > pkguse1) ? row[colPkgsId].ToString() : row[colPkgsId].ToString() + "#" + qtyamt1.ToString();
                            pkgsid = row[colPkgsId].ToString();
                            row.StyleNew.BackColor = Color.Red;
                            row[colPkgUse] = (pkguse1 + qty1);
                            String re1 = ic.ivfDB.oPkgdpDB.upDateQtyUse(row[colPkgdId].ToString(), qty1.ToString());
                        }
                        else
                        {
                            pkgsid = row[colPkgsId].ToString() + "#" + Math.Abs(qtyamt1).ToString();
                            ic.ivfDB.oPkgdpDB.upDateQtyUse(row[colPkgdId].ToString(), qtyamt.ToString());
                            row.StyleNew.BackColor = Color.Red;
                            row[colPkgUse] = (pkguse1 + qtyamt);
                        }
                        break;
                    }
                }
            }
            return pkgsid;
        }
        private void setOrderBloodLab()
        {
            if (grfBloodLab.Row <= 0) return;
            if (grfBloodLab[grfBloodLab.Row, colBlId] == null) return;
            String labid = "", include = "", qty = "",ordergroup="", pkgdid="", qtyext = "";
            rowOrder++;
            labid = grfBloodLab[grfBloodLab.Row, colBlId].ToString();
            //include = grfBloodLab[grfBloodLab.Row, colBlInclude] != null ? grfBloodLab[grfBloodLab.Row, colBlInclude].ToString().Equals("True") ? "1" : "0" : "0";
            qty = grfBloodLab[grfBloodLab.Row, colBlQty] != null ? grfBloodLab[grfBloodLab.Row, colBlQty].ToString() : "1";
            ordergroup = grfBloodLab[grfBloodLab.Row, colBlOrderGroup] != null ? grfBloodLab[grfBloodLab.Row, colBlOrderGroup].ToString() : "0";
            
            if (ordergroup.Equals("1"))
            {
                DataTable dt = new DataTable();
                dt = ic.ivfDB.logDB.selectByLabOrderId(labid);
                foreach(DataRow row in dt.Rows)
                {
                    pkgdid = setPkgDId(row[ic.ivfDB.logDB.log.lab_id].ToString(), row[ic.ivfDB.logDB.log.qty].ToString(), ordergroup, labid);
                    String[] pkgdid1 = pkgdid.Split('#');
                    if (pkgdid1.Length > 1)
                    {
                        qtyext = pkgdid1[1];
                        pkgdid = pkgdid1[0];
                    }
                    else
                    {
                        include = pkgdid.Length > 0 ? "1" : "";
                        qtyext = "";
                    }
                    Decimal qty1 = 0, qty2=0, qty3=0;
                    Decimal.TryParse(row[ic.ivfDB.logDB.log.qty].ToString(), out qty1);
                    Decimal.TryParse(qty, out qty2);
                    qty3 = qty1 * qty2;
                    if (qty3 <= 0) qty3 = 1;
                    if (include.Equals("1"))
                    {
                        if (ic.iniC.statusCashierOldProgram.Equals("1"))
                        {
                            ic.ivfDB.LabAdd(row[ic.ivfDB.logDB.log.lab_id].ToString(), qty3.ToString(), txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString(), labid, "0", "1", "old", pkgdid);
                        }
                        else
                        {
                            ic.ivfDB.LabAdd(row[ic.ivfDB.logDB.log.lab_id].ToString(), qty3.ToString(), txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString(), labid, "0", "1", pkgdid);
                        }
                            
                    }
                    else
                    {
                        if (ic.iniC.statusCashierOldProgram.Equals("1"))
                        {
                            ic.ivfDB.LabAdd(row[ic.ivfDB.logDB.log.lab_id].ToString(), qty3.ToString(), txtIdOld.Text, txtHn.Text, txtVnOld.Text, "1", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString(), labid, "0", "1", "old", pkgdid);
                        }
                        else
                        {
                            ic.ivfDB.LabAdd(row[ic.ivfDB.logDB.log.lab_id].ToString(), qty3.ToString(), txtIdOld.Text, txtHn.Text, txtVnOld.Text, "1", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString(), labid, "0", "1", pkgdid);
                        }
                            
                    }
                }
            }
            else
            {
                pkgdid = setPkgDId(labid, qty,"","");
                String[] pkgdid1 = pkgdid.Split('#');
                if (pkgdid1.Length > 1)
                {
                    qtyext = pkgdid1[1];
                    pkgdid = pkgdid1[0];
                }
                else
                {
                    include = pkgdid.Length > 0 ? "1" : "";
                    qtyext = "";
                }
                if (include.Equals("1"))
                {
                    if (ic.iniC.statusCashierOldProgram.Equals("1"))
                    {
                        if (qtyext.Length > 0)
                        {
                            Decimal qty1 = 0, qtyext1 = 0;
                            Decimal.TryParse(qty, out qty1);
                            Decimal.TryParse(qtyext, out qtyext1);
                            ic.ivfDB.LabAdd(labid, (qty1 - qtyext1).ToString(), txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString(), "0", "1", "0", "old", pkgdid);
                            ic.ivfDB.LabAdd(labid, qtyext, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString(), "0", "1", "0", "old", pkgdid);
                        }
                        else
                        {
                            ic.ivfDB.LabAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString(), "0", "1", "0", "old", pkgdid);
                        }
                    }
                    else
                    {
                        if (qtyext.Length > 0)
                        {
                            Decimal qty1 = 0, qtyext1 = 0;
                            Decimal.TryParse(qty, out qty1);
                            Decimal.TryParse(qtyext, out qtyext1);
                            ic.ivfDB.LabAdd(labid, (qty1 - qtyext1).ToString(), txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString(), "0", "1", "0", pkgdid);
                            ic.ivfDB.LabAdd(labid, qtyext, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString(), "0", "1", "0", pkgdid);
                        }
                        else
                        {
                            ic.ivfDB.LabAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString(), "0", "1", "0", pkgdid);
                        }
                    }
                }
                else
                {
                    //if (ic.iniC.statusCashierOldProgram.Equals("1"))
                    //{
                    //    ic.ivfDB.LabAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "1", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString(), "0", "1", "0", "old", pkgdid);
                    //}
                    //else
                    //{
                    //    ic.ivfDB.LabAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "1", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString(), "0", "1", "0", pkgdid);
                    //}
                    if (qtyext.Length > 0)
                    {
                        Decimal qty1 = 0, qtyext1 = 0;
                        Decimal.TryParse(qty, out qty1);
                        Decimal.TryParse(qtyext, out qtyext1);
                        if ((qty1 - qtyext1) > 0)
                        {
                            ic.ivfDB.LabAdd(labid, (qty1 - qtyext1).ToString(), txtIdOld.Text, txtHn.Text, txtVnOld.Text, "0", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString(), "0", "1", "0", pkgdid);
                        }
                        ic.ivfDB.LabAdd(labid, qtyext, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "1", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString(), "0", "1", "0", pkgdid);
                    }
                    else
                    {
                        ic.ivfDB.LabAdd(labid, qty, txtIdOld.Text, txtHn.Text, txtVnOld.Text, "1", "", "", "", "", "", "", "", grfOrder.Rows.Count.ToString(), "0", "1", "0", pkgdid);
                    }
                }
            }
            
            setGrfOrder(txtVnOld.Text);
        }
        private void setGrfBloodLab()
        {
            //grfDept.Rows.Count = 7;
            grfBloodLab.Clear();
            DataTable dt = new DataTable();
            dt = ic.ivfDB.oLabiDB.selectByBloodLab1();
            //grfBloodLab.Rows.Count = dt.Rows.Count + 1;
            grfBloodLab.Rows.Count = dt.Rows.Count + 1;
            //grfBloodLab.DataSource = dt;
            grfBloodLab.Cols.Count = 8;

            CellStyle cs = grfBloodLab.Styles.Add("bool");
            cs.DataType = typeof(bool);
            cs.ImageAlign = ImageAlignEnum.LeftCenter;

            grfBloodLab.Cols[colBlName].Width = 330;
            grfBloodLab.Cols[colBlInclude].Width = 80;
            grfBloodLab.Cols[colBlPrice].Width = 80;
            grfBloodLab.Cols[colBlRemark].Width = 100;
            grfBloodLab.Cols[colBlQty].Width = 60;

            grfBloodLab.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            CellRange rg = grfBloodLab.GetCellRange(2, colBlInclude, grfBloodLab.Rows.Count - 1, colBlInclude);
            rg.Style = cs;
            rg.Style = grfBloodLab.Styles["bool"];
            for (int col = 0; col < dt.Columns.Count; ++col)
            {
                grfBloodLab.Cols[col + 1].DataType = dt.Columns[col].DataType;
                grfBloodLab.Cols[col + 1].Caption = dt.Columns[col].ColumnName;
                grfBloodLab.Cols[col + 1].Name = dt.Columns[col].ColumnName;
            }
            grfBloodLab.Cols[colBlName].Caption = "Name";
            grfBloodLab.Cols[colBlInclude].Caption = "Include";
            grfBloodLab.Cols[colBlPrice].Caption = "Price";
            grfBloodLab.Cols[colBlQty].Caption = "QTY";
            grfBloodLab.Cols[colBlRemark].Caption = "Remark";
            int i = 0;
            decimal aaa = 0;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    i++;
                    if (i == 1) continue;

                    Decimal.TryParse(row[ic.ivfDB.oLabiDB.labI.Price].ToString(), out aaa);
                    grfBloodLab[i, colBlPrice] = aaa.ToString("#,##0");
                    grfBloodLab[i, colBlId] = row[ic.ivfDB.oLabiDB.labI.LID].ToString();
                    grfBloodLab[i, colBlName] = row[ic.ivfDB.oLabiDB.labI.LName].ToString();
                    grfBloodLab[i, colBlQty] = "1";
                    grfBloodLab[i, colBlOrderGroup] = row[ic.ivfDB.oLabiDB.labI.status_order_group].ToString();
                    if (row[ic.ivfDB.oLabiDB.labI.status_order_group].ToString().Equals("1"))
                    {
                        DataTable dt1 = new DataTable();
                        dt1 = ic.ivfDB.logDB.selectByLabOrderId(row[ic.ivfDB.oLabiDB.labI.LID].ToString());
                        if (dt1.Rows.Count > 0)
                        {
                            String txt = "";
                            foreach(DataRow row1 in dt1.Rows)
                            {
                                txt += row1[ic.ivfDB.oLabiDB.labI.LName].ToString()+" \n ";
                            }
                            CellNote note = new CellNote(txt);
                            CellRange rg1 = grfBloodLab.GetCellRange(i, colBlName);
                            rg1.UserData = note;
                        }                        
                    }

                }
                catch (Exception ex)
                {
                    String err = "";
                }
            }
            CellNoteManager mgr = new CellNoteManager(grfBloodLab);
            grfBloodLab.Cols[colBlId].Visible = false;
            grfBloodLab.Cols[colBlOrderGroup].Visible = false;
            //grfBloodLab.Cols[colBlPrice].Visible = false;

            grfBloodLab.Cols[colBlName].AllowEditing = false;
            grfBloodLab.Cols[colBlPrice].AllowEditing = false;
            grfBloodLab.Cols[colBlRemark].AllowEditing = false;
            if (ic.iniC.statusNurseOrderInclude.Equals("1"))
            {
                grfBloodLab.Cols[colBlInclude].Visible = true;
            }
            else
            {
                grfBloodLab.Cols[colBlInclude].Visible = false;
            }

            FilterRow fr = new FilterRow(grfBloodLab);
            grfBloodLab.AllowFiltering = true;
            grfBloodLab.AfterFilter += GrfBloodLab_AfterFilter;
            //theme1.SetTheme(grfFinish, ic.theme);

        }

        private void GrfBloodLab_AfterFilter(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            for (int col = grfBloodLab.Cols.Fixed; col < grfBloodLab.Cols.Count; ++col)
            {
                var filter = grfBloodLab.Cols[col].ActiveFilter;
            }
        }

        private void GrfMed_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();

        }
        private void initGrfImg()
        {
            grfImg = new C1FlexGrid();
            grfImg.Font = fEdit;
            grfImg.Dock = System.Windows.Forms.DockStyle.Fill;
            grfImg.Location = new System.Drawing.Point(0, 0);
                        
            grfImg.DoubleClick += GrfImg_DoubleClick;
            
            pnHistoryScan.Controls.Add(grfImg);

            theme1.SetTheme(grfImg, "Office2016Colorful");

        }

        private void GrfImg_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfImg.Row < 0) return;
            if (grfImg.Col == colImgImg)
            {
                //MessageBox.Show("a "+grfImg[grfImg.Row, colImg].ToString(), "");
                int row = 0;
                //int.TryParse(grfImg[grfImg.Row, colImg].ToString(), out row);
                int.TryParse(grfImg.Row.ToString(), out row);
                //row *= 4;
                FrmShowImage frm = new FrmShowImage(ic, grfImg[row, colImgID] != null ? grfImg[row, colImgID].ToString() : "", txtPttIdOld.Text, grfImg[row, colImgPathPic] != null ? grfImg[row, colImgPathPic].ToString() : "", FrmShowImage.statusModule.Patient);
                frm.ShowDialog(this);
            }
        }
        private void setGrfImg()
        {
            grfImg.Clear();
            grfImg.DataSource = null;
            grfImg.Rows.Count = 2;
            grfImg.Cols.Count = 10;
                        
            Button btn = new Button();
            btn.BackColor = Color.Gray;
            
            grfImg.Cols[colImgBtn].Editor = btn;
            //grfImg.Cols[colImg].Editor = img;

            grfImg.Cols[colImgHn].Width = 250;
            grfImg.Cols[colImgImg].Width = 100;
            grfImg.Cols[colImgDesc].Width = 100;
            grfImg.Cols[colImgDesc2].Width = 100;
            grfImg.Cols[colImgDesc3].Width = 100;
            grfImg.Cols[colImgBtn].Width = 50;
            grfImg.Cols[colImgPathPic].Width = 100;

            grfImg.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfImg.Cols[colImgHn].Caption = "HN";
            grfImg.Cols[colImgDesc].Caption = "Desc1";
            grfImg.Cols[colImgDesc2].Caption = "Desc2";
            grfImg.Cols[colImgDesc3].Caption = "Desc3";
            grfImg.Cols[colImgBtn].Caption = "send";

            //Hashtable ht = new Hashtable();
            //foreach (DataRow dr in dt.Rows)
            //{
            //    ht.Add(dr["CategoryID"], LoadImage(dr["Picture"] as byte[]));
            //}
            //grfImg.Cols[colImg].ImageMap = ht;
            //grfImg.Cols[colImg].ImageAndText = false;

            //ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข Patient", new EventHandler(ContextMenu_edit));
            //grfImg.ContextMenu = menuGw;

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            if (txtPttId.Text.Equals(""))
                return;
            DataTable dt = new DataTable();
            dt = ic.ivfDB.pttImgDB.selectByPttIDDept(txtPttId.Text, "1090000001");
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                i++;
                Row row1 = grfImg.Rows.Add();
                row1[colImgID] = row[ic.ivfDB.pttImgDB.pttI.patient_image_id].ToString();
                row1[colImgDesc] = row[ic.ivfDB.pttImgDB.pttI.desc1].ToString();
                row1[colImgPathPic] = row[ic.ivfDB.pttImgDB.pttI.image_path].ToString();
                row1[colImgStatus] = row[ic.ivfDB.pttImgDB.pttI.status_image].ToString();
                String statusdoc = "";
                statusdoc = row[ic.ivfDB.pttImgDB.pttI.status_document].ToString();
                grfImg[i, 0] = i;
                if (row[ic.ivfDB.pttImgDB.pttI.image_path] != null && !row[ic.ivfDB.pttImgDB.pttI.image_path].ToString().Equals(""))
                {
                    int ii = i;
                    Thread pump = new Thread(() =>
                    {
                        Thread.CurrentThread.IsBackground = true;
                        Image loadedImage = null, resizedImage;
                        String aaa = row[ic.ivfDB.pttImgDB.pttI.image_path].ToString();
                        FtpWebRequest ftpRequest = null;
                        FtpWebResponse ftpResponse = null;
                        Stream ftpStream = null;
                        int bufferSize = 2048;
                        MemoryStream stream = new MemoryStream();
                        string host = null;
                        string user = null;
                        string pass = null;     //iniC.hostFTP, iniC.userFTP, iniC.passFTP
                        host = ic.iniC.hostFTP; user = ic.iniC.userFTP; pass = ic.iniC.passFTP;
                        try
                        {
                            ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + aaa);
                            ftpRequest.Credentials = new NetworkCredential(user, pass);
                            ftpRequest.UseBinary = true;
                            //ftpRequest.UsePassive = false;
                            ftpRequest.UsePassive = ic.ftpUsePassive;
                            ftpRequest.KeepAlive = true;
                            ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                            ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                            ftpStream = ftpResponse.GetResponseStream();
                            byte[] byteBuffer = new byte[bufferSize];
                            int bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
                            try
                            {
                                while (bytesRead > 0)
                                {
                                    stream.Write(byteBuffer, 0, bytesRead);
                                    bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
                                }
                            }
                            catch (Exception ex)
                            {
                                new LogWriter("e", "setGrfImgPatient 1 " + ex.Message + "\n " + host + "/" + aaa);
                                //Console.WriteLine(ex.ToString());
                                //MessageBox.Show("setGrfImgPatient 1 " + ex.Message + "\n " + aaa, "host " + ic.iniC.hostFTP + " user " + user + " pas  " + pass);
                            }
                            if (statusdoc.Equals("1"))
                            {
                                loadedImage = new Bitmap(stream);
                            }
                            ftpStream.Close();
                            ftpResponse.Close();
                            ftpRequest = null;
                        }
                        catch (Exception ex)
                        {
                            new LogWriter("e", "setGrfImgPatient 2 " + ex.Message + "\n " + host + "/" + aaa);
                            //Console.WriteLine(ex.ToString());
                            //MessageBox.Show("setGrfImgPatient 2 " + ex.Message + "\n " + aaa, "host " + ic.iniC.hostFTP + " user " + user + " pas  " + pass);
                        }
                        //grfImg.Cols[colImg].ImageAndText = true;
                        if (loadedImage != null)
                        {
                            int originalWidth = loadedImage.Width;
                            int newWidth = 180;
                            resizedImage = loadedImage.GetThumbnailImage(newWidth, (newWidth * loadedImage.Height) / originalWidth, null, IntPtr.Zero);
                            Column col = grfImg.Cols[colImgImg];
                            col.DataType = typeof(Image);
                            row1[colImgImg] = resizedImage;
                            flagImg = true;
                            //grfImg.AutoSizeCols();
                            //grfImg.AutoSizeRows();
                        }
                    });
                    pump.Start();
                    //pump.Join();
                    //grfImg.AutoSizeCols();
                    //grfImg.AutoSizeRows();
                }
                //if (i % 2 == 0)
                //grfPtt.Rows[i].StyleNew.BackColor = color;
            }
            grfImg.Cols[colImgID].Visible = false;
            //grfImg.Cols[colPathPic].Visible = false;
            grfImg.Cols[colImgImg].AllowEditing = false;
            //grfImg.AutoSizeCols();
            grfImg.AutoSizeRows();
            theme1.SetTheme(grfImg, "Office2016Colorful");

        }
        private void initGrfImgOutLab()
        {
            grfImgOutLab = new C1FlexGrid();
            grfImgOutLab.Font = fEdit;
            grfImgOutLab.Dock = System.Windows.Forms.DockStyle.Fill;
            grfImgOutLab.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            grfImgOutLab.MouseDown += GrfImgOutLab_MouseDown;
            grfImgOutLab.DoubleClick += GrfImgOutLab_DoubleClick;
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            menuGw.MenuItems.Add("Upload OUT LAB 1", new EventHandler(ContextMenu_grfimgOutLab_upload_ptt));
            menuGw.MenuItems.Add("Upload OUT LAB 2", new EventHandler(ContextMenu_grfimgOutLab_upload_ptt));
            menuGw.MenuItems.Add("Upload OUT LAB 3", new EventHandler(ContextMenu_grfimgOutLab_upload_ptt));
            menuGw.MenuItems.Add("Upload OUT LAB 4", new EventHandler(ContextMenu_grfimgOutLab_upload_ptt));
            menuGw.MenuItems.Add("Upload OUT LAB 5", new EventHandler(ContextMenu_grfimgOutLab_upload_ptt));
            menuGw.MenuItems.Add("Upload OUT LAB 6", new EventHandler(ContextMenu_grfimgOutLab_upload_ptt));
            menuGw.MenuItems.Add("Upload OUT LAB 8", new EventHandler(ContextMenu_grfimgOutLab_upload_ptt));
            menuGw.MenuItems.Add("Upload OUT LAB 9", new EventHandler(ContextMenu_grfimgOutLab_upload_ptt));
            menuGw.MenuItems.Add("Upload OUT LAB 10", new EventHandler(ContextMenu_grfimgOutLab_upload_ptt));
            menuGw.MenuItems.Add("ยกเลิก", new EventHandler(ContextMenu_grfimgOutLab_Cancel));
            grfImgOutLab.ContextMenu = menuGw;
            pnOutLabImage.Controls.Add(grfImgOutLab);

            theme1.SetTheme(grfImgOutLab, "Office2016Colorful");

        }

        private void GrfImgOutLab_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfImgOutLab.Row < 0) return;
            //MessageBox.Show("a "+grfImg[grfImg.Row, colImg].ToString(), "");
            try
            {
                MemoryStream stream = new MemoryStream();
                //loadedImage = Image.FromFile(filename);
                stream = ic.ftpC.download(grfImgOutLab[grfImgOutLab.Row, colImgPathPic].ToString());
                //int row = 0;
                //int.TryParse(grfImg[grfImg.Row, colImg].ToString(), out row);
                //int.TryParse(grfImg.Row.ToString(), out row);
                C1PdfDocumentSource pds = new C1PdfDocumentSource();
                //c1PdfDocumentSource1.LoadFromFile(@"SonoAce X7.pdf");
                //pds.LoadFromFile(@"SonoAce X7.pdf");
                pds.LoadFromStream(stream);
                c1FlexViewer1.DocumentSource = pds;
                //FrmShowPdf frm = new FrmShowPdf(stream);
                //frm.ShowDialog(this);
            }
            catch (Exception ex1)
            {
                String aaa = "";
                aaa = ex1.Message;
            }
            //row *= 4;
            
            //frm.ShowDialog(this);
            
        }

        private void GrfImgOutLab_MouseDown(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
            if (grfImgOutLab.MouseCol < 0) return;
            if (grfImgOutLab.Cols[grfImgOutLab.MouseCol].Editor is Button)
            {
                //Current cell enters in edit mode, and button is clicked
                //SendKeys.Send("{ENTER}");
                //SendKeys.Send("{ENTER}");
            }
        }
        private void ContextMenu_grfimgOutLab_upload_ptt(object sender, System.EventArgs e)
        {
            if (grfImgOutLab.Row < 0) return;

            String pathfile1 = grfImgOutLab[grfImgOutLab.Row, colImgPathPic] != null ? grfImgOutLab[grfImgOutLab.Row, colImgPathPic].ToString() : "";
            if (pathfile1.Length > 0)
            {
                MessageBox.Show("มีรูปภาพ อยู่แล้ว กรุณา ยกเลิก ก่อน Upload รูปใหม่ ", "");
                return;
            }

            //if (MessageBox.Show("ต้องการ Upload image to server ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
                OpenFileDialog ofd = new OpenFileDialog();
                //ofd.Filter = "Images (*.BMP;*.JPG;*.Jepg;*.Png;*.GIF)|*.BMP;*.JPG;*.Jepg;*.Png;*.GIF|Pdf Files|*.pdf|All files (*.*)|*.*";
                ofd.Filter = "PDF (Pdf Files)|*.pdf|All files (*.*)|*.*";
                ofd.Multiselect = false;
                ofd.Title = "PDF Browser";
                DialogResult dr = ofd.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    String id = grfImgOutLab[grfImgOutLab.Row, colImgID] != null ? grfImgOutLab[grfImgOutLab.Row, colImgID].ToString() : "";
                    String pathfile = ofd.FileName;
                    String desc = grfImgOutLab[grfImgOutLab.Row, colImgDesc] != null ? grfImgOutLab[grfImgOutLab.Row, colImgDesc].ToString() : "";
                    String no = grfImgOutLab[grfImgOutLab.Row, colImgHn] != null ? grfImgOutLab[grfImgOutLab.Row, colImgHn].ToString() : "";
                    if (pathfile.Length > 0)
                    {
                        ic.cStf.staff_id = "";
                        FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                        frm.ShowDialog(this);
                        if (!ic.cStf.staff_id.Equals(""))
                        {
                            String filename = "", re = "", status = "";
                            //String[] ext = pathfile.Split('.');
                            String ext = Path.GetExtension(ofd.FileName);
                            if (ext.Length > 1)
                            {
                                MenuItem aa = (MenuItem)sender;
                                status = aa.Text.Equals("Upload OUT LAB 1") ? "31" 
                                    : aa.Text.Equals("Upload OUT LAB 2") ? "32" 
                                    : aa.Text.Equals("Upload OUT LAB 3") ? "33"
                                    : aa.Text.Equals("Upload OUT LAB 4") ? "34"
                                    : aa.Text.Equals("Upload OUT LAB 5") ? "45"
                                    : aa.Text.Equals("Upload OUT LAB 6") ? "36"
                                    : aa.Text.Equals("Upload OUT LAB 7") ? "37"
                                    : aa.Text.Equals("Upload OUT LAB 8") ? "38"
                                    : aa.Text.Equals("Upload OUT LAB 9") ? "39"
                                    : aa.Text.Equals("Upload OUT LAB 10") ? "40"
                                    : "";
                                filename = txtHn.Text.Replace("-", "").Replace("/", "") + "_" + status + ext;
                                PatientImage ptti = new PatientImage();
                                ptti.patient_image_id = id;
                                ptti.t_patient_id = txtPttId.Text;
                                ptti.t_visit_id = txtVsId.Text;
                                ptti.desc1 = desc;
                                ptti.desc2 = "";
                                ptti.desc3 = "";
                                ptti.desc4 = "";
                                ptti.active = "1";
                                ptti.remark = "";
                                ptti.date_create = "";
                                ptti.date_modi = "";
                                ptti.date_cancel = "";
                                ptti.user_create = "";
                                ptti.user_modi = "";
                                ptti.user_cancel = "";
                                ptti.image_path = ic.iniC.folderFTP + "/" + txtHn.Text.Replace("-", "").Replace("/", "") + "/" + filename;
                                ptti.status_image = status;
                                ptti.status_document = "2";
                                ptti.dept_id = ic.user.dept_id;
                                re = ic.ivfDB.pttImgDB.insertpatientImage(ptti, ic.cStf.staff_id);
                                long chk = 0;
                                if (long.TryParse(re, out chk))
                                {
                                    ic.savePicOPUtoServer(txtHn.Text.Replace("-", "").Replace("/", ""), filename, pathfile);
                                    grfImgOutLab.Rows[grfImgOutLab.Row].StyleNew.BackColor = color;
                                    setGrfImgOutLab();
                                }
                            }
                        }
                    }
                }
            //}
        }
        private void ContextMenu_grfimgOutLab_Cancel(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("ต้องการ ยกเลิก ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                String id = grfImgOutLab[grfImgOutLab.Row, colImgID].ToString();
                ic.cStf.staff_id = "";
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    String pathfile = grfImgOutLab[grfImgOutLab.Row, colImgPathPic].ToString();
                    String re = ic.ivfDB.pttImgDB.updateVoid(id, ic.user.staff_id);
                    ic.delPicOPUtoServer(txtHn.Text.Replace("-", "").Replace("/", ""), pathfile);
                    setGrfImgOutLab();
                }
            }
        }
        private void setGrfImgOutLab()
        {
            grfImgOutLab.Clear();
            grfImgOutLab.DataSource = null;
            grfImgOutLab.Rows.Count = 2;
            grfImgOutLab.Cols.Count = 10;

            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            //grfCu.Rows.Count = 41;
            //grfCu.Cols.Count = 4;
            C1TextBox txt = new C1TextBox();
            Button btn = new Button();
            btn.BackColor = Color.Gray;
            btn.Click += Btn_Click;
            //PictureBox img = new PictureBox();
            //C1ComboBox cboproce = new C1ComboBox();
            //ic.ivfDB.itmDB.setCboItem(cboproce);
            grfImgOutLab.Cols[colImgHn].Editor = txt;
            grfImgOutLab.Cols[colImgDesc].Editor = txt;
            grfImgOutLab.Cols[colImgDesc2].Editor = txt;
            grfImgOutLab.Cols[colImgDesc3].Editor = txt;
            grfImgOutLab.Cols[colImgBtn].Editor = btn;
            //grfImg.Cols[colImg].Editor = img;

            grfImgOutLab.Cols[colImgHn].Width = 250;
            grfImgOutLab.Cols[colImgImg].Width = 100;
            grfImgOutLab.Cols[colImgDesc].Width = 100;
            grfImgOutLab.Cols[colImgDesc2].Width = 100;
            grfImgOutLab.Cols[colImgDesc3].Width = 100;
            grfImgOutLab.Cols[colImgBtn].Width = 50;
            grfImgOutLab.Cols[colImgPathPic].Width = 100;

            grfImgOutLab.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfImgOutLab.Cols[colImgHn].Caption = "HN";
            grfImgOutLab.Cols[colImgDesc].Caption = "Desc1";
            grfImgOutLab.Cols[colImgDesc2].Caption = "Desc2";
            grfImgOutLab.Cols[colImgDesc3].Caption = "Desc3";
            grfImgOutLab.Cols[colImgBtn].Caption = "send";

            //Hashtable ht = new Hashtable();
            //foreach (DataRow dr in dt.Rows)
            //{
            //    ht.Add(dr["CategoryID"], LoadImage(dr["Picture"] as byte[]));
            //}
            //grfImg.Cols[colImg].ImageMap = ht;
            //grfImg.Cols[colImg].ImageAndText = false;

            //ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข Patient", new EventHandler(ContextMenu_edit));
            //grfImg.ContextMenu = menuGw;

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            if (txtPttId.Text.Equals(""))
                return;
            DataTable dt = new DataTable();
            dt = ic.ivfDB.pttImgDB.selectByPttIDOutLabDept(txtPttId.Text, ic.user.dept_id);
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                i++;
                Row row1 = grfImgOutLab.Rows.Add();
                row1[colImgID] = row[ic.ivfDB.pttImgDB.pttI.patient_image_id].ToString();
                row1[colImgDesc] = row[ic.ivfDB.pttImgDB.pttI.desc1].ToString();
                row1[colImgPathPic] = row[ic.ivfDB.pttImgDB.pttI.image_path].ToString();
                row1[colImgStatus] = row[ic.ivfDB.pttImgDB.pttI.status_image].ToString();
                grfImgOutLab[i, 0] = i;
                //if (row[ic.ivfDB.pttImgDB.pttI.image_path] != null && !row[ic.ivfDB.pttImgDB.pttI.image_path].ToString().Equals(""))
                //{
                //    int ii = i;
                //    Thread pump = new Thread(() =>
                //    {
                //        Thread.CurrentThread.IsBackground = true;
                //        Image loadedImage = null, resizedImage;
                //        String aaa = row[ic.ivfDB.pttImgDB.pttI.image_path].ToString();
                //        FtpWebRequest ftpRequest = null;
                //        FtpWebResponse ftpResponse = null;
                //        Stream ftpStream = null;
                //        int bufferSize = 2048;
                //        MemoryStream stream = new MemoryStream();
                //        string host = null;
                //        string user = null;
                //        string pass = null;     //iniC.hostFTP, iniC.userFTP, iniC.passFTP
                //        host = ic.iniC.hostFTP; user = ic.iniC.userFTP; pass = ic.iniC.passFTP;
                //        try
                //        {
                //            ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + aaa);
                //            ftpRequest.Credentials = new NetworkCredential(user, pass);
                //            ftpRequest.UseBinary = true;
                //            //ftpRequest.UsePassive = false;
                //            ftpRequest.UsePassive = ic.ftpUsePassive;
                //            ftpRequest.KeepAlive = true;
                //            ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                //            ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                //            ftpStream = ftpResponse.GetResponseStream();
                //            byte[] byteBuffer = new byte[bufferSize];
                //            int bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
                //            try
                //            {
                //                while (bytesRead > 0)
                //                {
                //                    stream.Write(byteBuffer, 0, bytesRead);
                //                    bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
                //                }
                //            }
                //            catch (Exception ex)
                //            {
                //                Console.WriteLine(ex.ToString());
                //                MessageBox.Show("setGrfImg 1 " + ex.Message + "\n " + aaa, "host " + ic.iniC.hostFTP + " user " + user + " pas  " + pass);
                //            }
                //            String ext = Path.GetExtension(aaa);
                //            if (ext.ToLower().IndexOf("pdf")<0)
                //            {
                //                loadedImage = new Bitmap(stream);
                //            }
                //            ftpStream.Close();
                //            ftpResponse.Close();
                //            ftpRequest = null;
                //        }
                //        catch (Exception ex)
                //        {
                //            Console.WriteLine(ex.ToString());
                //            MessageBox.Show("setGrfImg 2 " + ex.Message + "\n " + aaa, "host " + ic.iniC.hostFTP + " user " + user + " pas  " + pass);
                //        }
                //        //grfImg.Cols[colImg].ImageAndText = true;
                //        if (loadedImage != null)
                //        {
                //            int originalWidth = loadedImage.Width;
                //            int newWidth = 180;
                //            resizedImage = loadedImage.GetThumbnailImage(newWidth, (newWidth * loadedImage.Height) / originalWidth, null, IntPtr.Zero);
                //            Column col = grfImg.Cols[colImgImg];
                //            col.DataType = typeof(Image);
                //            row1[colImgImg] = resizedImage;
                //            flagImg = true;
                //            //grfImg.AutoSizeCols();
                //            //grfImg.AutoSizeRows();
                //        }
                //    });
                //    pump.Start();
                //    //pump.Join();
                //    //grfImg.AutoSizeCols();
                //    //grfImg.AutoSizeRows();
                //}
                //if (i % 2 == 0)
                //grfPtt.Rows[i].StyleNew.BackColor = color;
            }
            grfImgOutLab.Cols[colImgID].Visible = false;
            grfImgOutLab.Cols[colImgHn].Visible = false;
            grfImgOutLab.Cols[colImgBtn].Visible = false;
            grfImgOutLab.Cols[colImgImg].Visible = false;
            //grfImg.Cols[colPathPic].Visible = false;
            grfImgOutLab.Cols[colImgImg].AllowEditing = false;
            //grfImg.AutoSizeCols();
            grfImgOutLab.AutoSizeRows();
            theme1.SetTheme(grfImgOutLab, "Office2016Colorful");

        }

        private void Btn_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

        }
        private void initGrfPg()
        {
            grfPg = new C1FlexGrid();
            grfPg.Font = fEdit;
            grfPg.Dock = System.Windows.Forms.DockStyle.Fill;
            grfPg.Location = new System.Drawing.Point(0, 0);

            grfPg.DoubleClick += GrfPg_DoubleClick;
            
            pnPgView.Controls.Add(grfPg);

            theme1.SetTheme(grfPg, "Office2016Colorful");

        }

        private void GrfPg_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String id = "";
            if (grfPg.Row < 0) return;
            id = grfPg[grfPg.Row, colPgId].ToString();
            id = id.Replace(ic.iniC.folderFTP, "").Replace("/", "").Replace("progressnote", "").Replace(".rtf", "").Replace("_", "").Replace(txtIdOld.Text, "");
            txtVnProgressNote.Value = id;
            Thread threadA = new Thread(new ParameterizedThreadStart(ExecuteProgressNote));
            threadA.Start();
        }
        
        private void setGrfPg()
        {
            grfPg.Clear();
            grfPg.DataSource = null;
            grfPg.Rows.Count = 1;
            grfPg.Cols.Count = 3;

            grfPg.Cols[colPgId].Width = 250;
            grfPg.Cols[colPgFilename].Width = 300;

            grfPg.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";
                        
            grfPg.Cols[colPgFilename].Caption = "Desc1";
                        

            Color color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);
            //CellRange rg1 = grfBank.GetCellRange(1, colE, grfBank.Rows.Count, colE);
            //rg1.Style = grfBank.Styles["date"];
            //grfCu.Cols[colID].Visible = false;
            if (txtPttId.Text.Equals(""))
                return;
            
            
            Thread pump = new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                
                FtpWebRequest ftpRequest = null;
                FtpWebResponse ftpResponse = null;
                Stream ftpStream = null;
                int bufferSize = 2048;
                MemoryStream stream = new MemoryStream();
                string host = null;
                string user = null;
                string pass = null;     //iniC.hostFTP, iniC.userFTP, iniC.passFTP
                host = ic.iniC.hostFTP; user = ic.iniC.userFTP; pass = ic.iniC.passFTP;
                try
                {
                    //String aaa = ic.iniC.folderFTP + "/" + txtIdOld.Text + "/" + filePathName;
                    ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + ic.iniC.folderFTP + "/" + txtIdOld.Text);
                    ftpRequest.Credentials = new NetworkCredential(user, pass);
                    ftpRequest.UseBinary = true;
                    //ftpRequest.UsePassive = false;
                    ftpRequest.UsePassive = ic.ftpUsePassive;
                    ftpRequest.KeepAlive = true;
                    ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                    ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                    //ftpStream = ftpResponse.GetResponseStream();
                    List<string> filestxt = new List<string>();
                    StreamReader streamReader=null;
                    try
                    {
                        streamReader = new StreamReader(ftpResponse.GetResponseStream());
                        string line = streamReader.ReadLine();
                        while (!string.IsNullOrEmpty(line))
                        {
                            if (line.Contains(".rtf"))
                            {
                                //MessageBox.Show(line);
                                filestxt.Add(line);
                                line = streamReader.ReadLine();
                            }
                            else
                            {
                                line = streamReader.ReadLine();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        new LogWriter("e", "setGrfPg 1 " + ex.Message + "\n " + host + "/" + ic.iniC.folderFTP + "/" + txtIdOld.Text);
                        //Console.WriteLine(ex.ToString());
                        //MessageBox.Show("setGrfPg 1 " + ex.Message + "\n " , "host " + ic.iniC.hostFTP + " user " + user + " pas  " + pass);
                    }
                    finally
                    {
                        streamReader.Close();
                    }
                    //ftpStream.Close();
                    ftpResponse.Close();
                    ftpRequest = null;
                    foreach (String aaa in filestxt)
                    {
                        Row row = grfPg.Rows.Add();
                        row[colPgId] = aaa;
                        row[colPgFilename] = aaa.Replace(txtIdOld.Text, "").Replace("/", "");
                    }
                }
                catch (Exception ex)
                {
                    new LogWriter("e", "setGrfPg 2 " + ex.Message + "\n " + host + "/" + ic.iniC.folderFTP + "/" + txtIdOld.Text);
                    //Console.WriteLine(ex.ToString());
                    //MessageBox.Show("setGrfPg 2 " + ex.Message + "\n ", "host " + ic.iniC.hostFTP + " user " + user + " pas  " + pass);
                }
            });
            pump.Start();
                    //pump.Join();
                    //grfImg.AutoSizeCols();
                    //grfImg.AutoSizeRows();
                
            grfPg.Cols[colPgId].Visible = false;
            //grfImg.Cols[colPathPic].Visible = false;
            grfPg.Cols[colPgFilename].AllowEditing = false;
            
            theme1.SetTheme(grfPg, "Office2016Colorful");

        }
        private void FrmNurseAdd2_Load(object sender, EventArgs e)
        {
            sC.HeaderHeight = 0;
            sCOrder.HeaderHeight = 0;
            //sCApm.HeaderHeight = 0;
            sCApmAdd.HeaderHeight = 0;
            spPatient.Height = spHeight;
            sCHistory.Height = 0;
            rat = picPtt.Height / picPtt.Width;
            picPtt.Height = picPtt.Height - 50;
            //tlpPatient.
            //tlpPatient[1].SizeType = SizeType.Absolute;
            spPatient.SizeRatio = 15;
            theme1.SetTheme(sC, theme1.Theme);
            foreach (Control ctl in spPatient.Controls)
            {
                theme1.SetTheme(ctl, theme1.Theme);
            }
            tC.SelectedTab = tabDrug;
            tCApm.SelectedTab = tabApmVisit;
            tCApm1.SelectedTab = tabApmPtt;
            tabOrder.SelectedTab = tabPackage;
            tcPackage.SelectedTab = tabPkgOrder;
            tcOrd.SelectedTab = tabOrd;
            //sB1.Text = "Date " + ic.cop.day + "-" + ic.cop.month + "-" + ic.cop.year + " Server " + ic.iniC.hostDB + " FTP " + ic.iniC.hostFTP;
            sB1.Text = "Date " + ic.cop.day + "-" + ic.cop.month + "-" + ic.cop.year + " Server " + ic.iniC.hostDB + " FTP " + ic.iniC.hostFTP + "/" + ic.iniC.folderFTP;
        }
    }
}
