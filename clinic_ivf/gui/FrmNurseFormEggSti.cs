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
    public partial class FrmNurseFormEggSti : Form
    {
        IvfControl ic;
        String pttid = "", webcamname = "", vsid = "", flagedit = "", pApmId = "", vsidOld = "";

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;

        Patient ptt;
        VisitOld vsOld;
        Visit vs;
        PatientOld pttOld;

        C1FlexGrid grfEggsd;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        public FrmNurseFormEggSti(IvfControl ic, String pttid, String vsid, String flagedit)
        {
            InitializeComponent();
            this.ic = ic;
            this.vsid = vsid;
            this.pttid = pttid;
            this.flagedit = flagedit;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);

            //C1ThemeController.ApplicationTheme = ic.iniC.themeApplication;
            theme1.Theme = ic.iniC.themeApplication;
            theme1.SetTheme(sB, "BeigeOne");
            //theme1.SetTheme(tabOrder, "MacSilver");
            ic.ivfDB.dtrOldDB.setCboDoctor(cboDoctor, "");

            sB1.Text = "";
            bg = txtHn.BackColor;
            fc = txtHn.ForeColor;
            ff = txtHn.Font;

            vsOld = new VisitOld();
            vs = new Visit();
            ptt = new Patient();
            pttOld = new PatientOld();
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
        }
        private void FrmNurseFormEggSti_Load(object sender, EventArgs e)
        {

        }
    }
}
