using clinic_ivf.control;
using clinic_ivf.object1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.gui
{
    public partial class FrmPrintCritiAnes : Form
    {
        IvfControl ic;
        String hn = "", name = "", vsid = "", dtrid = "";
        Patient ptt;
        Visit vs;

        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetDefaultPrinter(string Printer);
        public FrmPrintCritiAnes(IvfControl ic, String hn, String name, String vsid)
        {
            InitializeComponent();
            this.ic = ic;
            this.hn = hn;
            this.name = name;
            this.vsid = vsid;
            //this.dtrid = dtrid;
            initConifg();
        }
        private void initConifg()
        {
            ptt = new Patient();
            vs = new Visit();
            ptt = ic.ivfDB.pttDB.selectByHn(hn);
            vs = ic.ivfDB.vsDB.selectByPk1(vsid);
            txtPttNameE.Value = name;
            txtHn.Value = hn;
            txtDob.Value = ptt.AgeStringShort()+" ["+ic.datetoShow(ptt.patient_birthday)+"]";
            ic.ivfDB.stfDB.setCboDoctor(cboDoctor, vs.doctor_id);
            ic.ivfDB.stfDB.setCboDoctor(cboAnes, "");

            btnFinish.Click += BtnFinish_Click;
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            SetDefaultPrinter(ic.iniC.printerA4);

            String date = "";
            date = DateTime.Now.ToString("dd/MM/") + DateTime.Now.Year;
            FrmReport frm = new FrmReport(ic);
            frm.setOpdAuthenSign(txtPttNameE.Text, txtHn.Text, txtDob.Text, cboDoctor.Text, cboAnes.Text, date, cboOperation.Text);
            frm.ShowDialog(this);

        }

        private void FrmPrintCritiAnes_Load(object sender, EventArgs e)
        {

        }
    }
}
