using C1.Win.C1Command;
using C1.Win.C1FlexGrid;
using C1.Win.C1SplitContainer;
using C1.Win.C1Themes;
using clinic_ivf.control;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.gui
{
    public class FrmCashierRefund:Form
    {
        IvfControl ic;
        String hn = "";

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;

        C1ThemeController theme1;
        C1DockingTab tC1;
        C1DockingTabPage tabReq, tabApm, tabFinish, tabListen, tabmaster;
        C1FlexGrid grfReq, grfProc, grfFinish, grfMaster;
        
        C1SplitContainer sCRefund;
        C1SplitterPanel scHn, scRefund, scPrescription;
        Panel panel1;

        public FrmCashierRefund(IvfControl ic, String hn)
        {
            this.ic = ic;
            this.hn = hn;
        }
    }
}
