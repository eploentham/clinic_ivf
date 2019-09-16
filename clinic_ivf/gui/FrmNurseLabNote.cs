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
    public partial class FrmNurseLabNote : Form
    {
        IvfControl ic;

        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;
        public FrmNurseLabNote(IvfControl ic)
        {
            InitializeComponent();
            this.ic = ic;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);
            ic.ivfDB.lbReqDB.setCboRemark(cboRemark);
        }
        private void FrmNurseLabNote_Load(object sender, EventArgs e)
        {

        }
    }
}
