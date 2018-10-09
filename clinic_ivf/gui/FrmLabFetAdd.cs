using C1.Win.C1FlexGrid;
using C1.Win.C1SuperTooltip;
using C1.Win.C1Themes;
using clinic_ivf.control;
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
    public partial class FrmLabFetAdd : Form
    {
        IvfControl ic;
        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;
        int colID = 1, colNum = 2, colDesc = 3;

        C1FlexGrid grfDay3, grfDay5, grfDay6;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;

        public FrmLabFetAdd(IvfControl ic)
        {
            InitializeComponent();
            this.ic = ic;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);

            C1ThemeController.ApplicationTheme = ic.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;
            theme1.SetTheme(sB, "BeigeOne");

            sB1.Text = "";

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            //stt.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.Gold;

            //initGrfDay3();
            //initGrfDay5();
            //initGrfDay6();
            //setGrfDay3();
            //setGrfDay5();
            //setGrfDay6();
        }
        private void FrmLabFetAdd_Load(object sender, EventArgs e)
        {
            spMain.Panel1MinSize = 120;
            spMain.SplitterDistance = 120;
        }
    }
}
