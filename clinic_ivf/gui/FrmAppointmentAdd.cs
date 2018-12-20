using C1.Win.C1FlexGrid;
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
    public partial class FrmAppointmentAdd : Form
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
        int colId = 1, colAppointment = 4, colDate = 2, colTime = 3, colDoctor = 5, colSp = 6, colNotice = 7, colE2 = 8, colLh = 9, colEndo = 10, colPrl = 10, colFsh = 11, colRt = 12, colLt = 13;
        Image imgCorr, imgTran;

        public FrmAppointmentAdd(IvfControl ic, String papmId, String pttid, String vsid)
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
        }
        private void FrmAppointmentAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
