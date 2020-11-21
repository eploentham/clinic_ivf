using clinic_ivf.control;
using clinic_ivf.object1;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.gui
{
    public partial class FrmNurseFormPrint : Form
    {
        IvfControl ic;
        String hn = "", name = "", vsid = "", dtrid = "";
        Patient ptt;
        Visit vs;

        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetDefaultPrinter(string Printer);
        public FrmNurseFormPrint(IvfControl ic, String hn, String name, String vsid)
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
            
            vs = ic.ivfDB.vsDB.selectByPk1(vsid);
            ptt = ic.ivfDB.pttDB.selectByPk1(vs.t_patient_id);
            txtPttNameE.Value = ptt.patient_name;
            txtHn.Value = ic.showHN(ptt.patient_hn,ptt.patient_year);
            txtDob.Value = ptt.AgeStringShort() + " [" + ic.datetoShow(ptt.patient_birthday) + "]";
            ic.ivfDB.stfDB.setCboDoctor(cboDoctor, vs.doctor_id);
            ic.ivfDB.stfDB.setCboDoctor(cboAnes, "");

            btnFinish.Click += BtnFinish_Click;
        }
        private void BtnFinish_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            SetDefaultPrinter(ic.iniC.printerA4);

            DataTable dt = new DataTable();
            String chk = "", printerDefault = "";
            ReportDocument rpt = new ReportDocument();
            PrinterSettings getprinterName = new PrinterSettings();
            rpt.PrintOptions.PrinterName = getprinterName.PrinterName;
            if (chkPrnCheckList.Checked)
            {
                try
                {
                    Patient ptt = new Patient();
                    ptt = ic.ivfDB.pttDB.selectByHn(txtHn.Text.Trim());
                    Patient ptt2 = new Patient();
                    ptt2 = ic.ivfDB.pttDB.selectByHn(ptt.patient_hn_2);

                    rpt = new ReportDocument();
                    rpt.Load("opd_check_list.rpt");
                    //rpt.SetDataSource(dt);
                    rpt.SetParameterValue("name", txtPttNameE.Text);
                    rpt.SetParameterValue("hn", txtHn.Text);
                    rpt.SetParameterValue("age", txtDob.Text);
                    rpt.SetParameterValue("name1", ptt2.Name);
                    rpt.PrintOptions.PrinterName = getprinterName.PrinterName;
                    rpt.PrintToPrinter(1, true, 0, 0);
                    lbPrint1.Text = rpt.PrintOptions.PrinterName;
                }
                catch (Exception ex)
                {
                    //chk1 = false;
                    chk = ex.Message.ToString();
                    MessageBox.Show("error " + ex.Message, "");
                }
            }
            if (chkAuthenSign.Checked)
            {
                String date1 = "";
                date1 = DateTime.Now.ToString("dd/MM/") + DateTime.Now.Year;

                rpt = new ReportDocument();
                rpt.Load("opd_authen_sign.rpt");
                //rpt.SetDataSource(dt);
                rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                rpt.SetParameterValue("line2", ic.cop.addr1);
                rpt.SetParameterValue("line3", ic.cop.addr2);
                rpt.SetParameterValue("hn", txtHn.Text);
                rpt.SetParameterValue("name", txtPttNameE.Text);
                rpt.SetParameterValue("age", txtDob.Text);
                rpt.SetParameterValue("date", date1);
                rpt.SetParameterValue("doctorname", cboDoctor.Text);
                rpt.SetParameterValue("doctoranes", cboAnes.Text);
                rpt.SetParameterValue("operation", cboOperation.Text);
                //rpt.SetParameterValue("doctor", cboDoctor.Text);
                rpt.PrintOptions.PrinterName = getprinterName.PrinterName;
                rpt.PrintToPrinter(1, true, 0, 0);
                lbPrinter.Text = "chkAuthenSign";
                lbPrint1.Text = rpt.PrintOptions.PrinterName;
            }
            if (chkOperaNote.Checked)
            {
                rpt = new ReportDocument();
                rpt.Load("opd_post_operation_note.rpt");
                //rpt.SetDataSource(dt);
                rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                rpt.SetParameterValue("line2", ic.cop.addr1);
                rpt.SetParameterValue("line3", ic.cop.addr2);
                rpt.SetParameterValue("hn", txtHn.Text);
                rpt.SetParameterValue("name", txtPttNameE.Text);
                rpt.SetParameterValue("age", txtDob.Text);
                rpt.SetParameterValue("doctor", cboDoctor.Text);
                rpt.PrintOptions.PrinterName = getprinterName.PrinterName;
                rpt.PrintToPrinter(1, true, 0, 0);
                lbPrint1.Text = rpt.PrintOptions.PrinterName;
            }
            if (chkOrdFET.Checked)
            {
                String date1 = "";
                date1 = DateTime.Now.ToString("dd/MM/") + DateTime.Now.Year;

                rpt = new ReportDocument();
                rpt.Load("opd_order_et_fet.rpt");
                //rpt.SetDataSource(dt);
                rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                rpt.SetParameterValue("line2", ic.cop.addr1);
                rpt.SetParameterValue("line3", ic.cop.addr2);
                rpt.SetParameterValue("hn", txtHn.Text);
                rpt.SetParameterValue("name", txtPttNameE.Text);
                rpt.SetParameterValue("age", txtDob.Text);
                rpt.SetParameterValue("date", date1);
                rpt.SetParameterValue("doctor", cboDoctor.Text);
                rpt.PrintOptions.PrinterName = getprinterName.PrinterName;
                rpt.PrintToPrinter(1, true, 0, 0);
                lbPrint1.Text = rpt.PrintOptions.PrinterName;
            }
            if (chkOrdOPU.Checked)
            {
                rpt = new ReportDocument();
                rpt.Load("opd_order_opu.rpt");
                //rpt.SetDataSource(dt);
                rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                rpt.SetParameterValue("line2", ic.cop.addr1);
                rpt.SetParameterValue("line3", ic.cop.addr2);
                rpt.SetParameterValue("hn", txtHn.Text);
                rpt.SetParameterValue("name", txtPttNameE.Text);
                rpt.SetParameterValue("age", txtDob.Text);
                rpt.SetParameterValue("doctor", cboDoctor.Text);
                rpt.PrintOptions.PrinterName = getprinterName.PrinterName;
                rpt.PrintToPrinter(1, true, 0, 0);
                lbPrint1.Text = rpt.PrintOptions.PrinterName;
            }
            if (chkPrnPmh.Checked)
            {
                rpt = new ReportDocument();
                rpt.Load("pmh.rpt");
                //rpt.SetDataSource(dt);
                rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                rpt.SetParameterValue("line2", ic.cop.addr1);
                rpt.SetParameterValue("line3", ic.cop.addr2);
                rpt.SetParameterValue("hn", txtHn.Text);
                rpt.SetParameterValue("name", txtPttNameE.Text);
                rpt.PrintOptions.PrinterName = getprinterName.PrinterName;
                rpt.PrintToPrinter(1, true, 0, 0);
                lbPrint1.Text = rpt.PrintOptions.PrinterName;
            }
            //String date = "";
            //date = DateTime.Now.ToString("dd/MM/") + DateTime.Now.Year;
            //FrmReport frm = new FrmReport(ic);
            //frm.setOpdAuthenSign(txtPttNameE.Text, txtHn.Text, txtDob.Text, cboDoctor.Text, cboAnes.Text, date, cboOperation.Text);
            //frm.ShowDialog(this);

        }
        private void FrmNurseFormPrint_Load(object sender, EventArgs e)
        {
            SetDefaultPrinter(ic.iniC.printerA4);
            PrinterSettings getprinterName = new PrinterSettings();
            lbPrinter.Text = getprinterName.PrinterName;
        }
    }
}
