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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.gui
{
    public partial class FrmNurseAdd : Form
    {
        IvfControl ic;
        String pttId = "", webcamname = "", vsid = "";
        Patient ptt;
        VisitOld vsOld;
        PatientOld pttOld;

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;

        C1FlexGrid grfDrug, grfLab, grfAppt, grfCert;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;

        public FrmNurseAdd(IvfControl ic, String pttid, String vsid)
        {
            InitializeComponent();
            this.ic = ic;
            this.vsid = vsid;
            this.pttId = pttid;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);

            //C1ThemeController.ApplicationTheme = ic.iniC.themeApplication;
            theme1.Theme = ic.iniC.themeApplication;
            theme1.SetTheme(sB, "BeigeOne");

            sB1.Text = "";
            bg = txtHn.BackColor;
            fc = txtHn.ForeColor;
            ff = txtHn.Font;

            vsOld = new VisitOld();
            ptt = new Patient();
            pttOld = new PatientOld();
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();

            setControl(vsid);
            //btnNew.Click += BtnNew_Click;
            //txtSearch.KeyUp += TxtSearch_KeyUp;

            //initGrfPtt();
            //setGrfPtt("");
        }
        private void setControl(String vsid)
        {
            vsOld = ic.ivfDB.vsOldDB.selectByPk1(vsid);
            pttOld = ic.ivfDB.pttOldDB.selectByPk1(vsOld.PID);
            ptt.patient_birthday = pttOld.DateOfBirth;
            txtHn.Value = vsOld.PIDS;
            txtVn.Value = vsOld.VN;
            txtPttName.Value = vsOld.PName;
            txtDob.Value = ic.datetoShow(pttOld.DateOfBirth) + " ["+ptt.AgeStringShort()+"]";
            txtAllergy.Value = pttOld.Allergy;
            //txtBg.Value = pttOld.b
        }
        private void initGrfPtt()
        {
            grfDrug = new C1FlexGrid();
            grfDrug.Font = fEdit;
            grfDrug.Dock = System.Windows.Forms.DockStyle.Fill;
            grfDrug.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            grfDrug.AfterRowColChange += GrfMed_AfterRowColChange;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grfDrug.ContextMenu = menuGw;
            pnDrug.Controls.Add(grfDrug);

            theme1.SetTheme(grfDrug, "Office2010Blue");

        }

        private void GrfMed_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();

        }

        private void FrmNurseAdd_Load(object sender, EventArgs e)
        {
            tC.SelectedTab = tabDrug;
        }
    }
}
