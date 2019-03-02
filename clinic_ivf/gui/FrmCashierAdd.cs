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
    public partial class FrmCashierAdd : Form
    {
        IvfControl ic;
        String billhid = "", pttid = "", vsid = "", vsidOld = "";
        OldBillheader obilh;
        VisitOld ovs;
        PatientOld optt;

        C1FlexGrid grfBillD;
        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;
        Color color;
        String vnold = "";

        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        public FrmCashierAdd(IvfControl ic, String billid, String vnold)
        {
            InitializeComponent();
            this.ic = ic;
            this.vnold = vnold;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);
            ovs = new VisitOld();
            optt = new PatientOld();

            //C1ThemeController.ApplicationTheme = ic.iniC.themeApplication;
            //theme1.Theme = C1ThemeController.ApplicationTheme;
            theme1.SetTheme(sB, "BeigeOne");
            color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);

            sB1.Text = "";
            bg = txtHn.BackColor;
            fc = txtHn.ForeColor;
            ff = txtHn.Font;
            ic.ivfDB.ol

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();

            setControl();
        }
        private void setControl()
        {
            ovs = ic.ivfDB.vsOldDB.selectByPk1(vnold);
            optt = ic.ivfDB.pttOldDB.selectByPk1(ovs.PID);
            txtHn.Value = optt.PIDS;
            txtPttNameE.Value = optt.FullName;
            txtDob.Value = optt.DateOfBirth;
            txtHnOld.Value = optt.PIDS;
            txtVnOld.Value = vsidOld;
            txtPttId.Value = optt.PID;
            txtVsId.Value = ovs.VN;
            txtVnOld.Value = ovs.VN;
            txtHnOld.Value = ovs.PIDS;
        }
        private void FrmCashierAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
