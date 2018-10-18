using C1.Win.C1FlexGrid;
using C1.Win.C1SuperTooltip;
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
    public partial class FrmPatientAdd : Form
    {
        IvfControl ic;
        String reqId = "";

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;
        int colID = 1, colNum = 2, colDesc = 3, colDesc2 = 4, colDesc3 = 5;
        
        C1FlexGrid grfDay2, grfDay3, grfDay5, grfDay6;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;

        public FrmPatientAdd(IvfControl ic, String reqid)
        {
            InitializeComponent();
            this.ic = ic;
            reqId = reqid;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);
            
            theme1.SetTheme(sB, "BeigeOne");

            sB1.Text = "";
            bg = txtPttName.BackColor;
            fc = txtPttName.ForeColor;
            ff = txtPttName.Font;

            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();

        }
        private void FrmPatientAdd_Load(object sender, EventArgs e)
        {
            tC1.SelectedTab = tabFamily;
        }
    }
}
