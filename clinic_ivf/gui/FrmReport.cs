using clinic_ivf.control;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.gui
{
    public partial class FrmReport : Form
    {
        IvfControl ic;

        public FrmReport(IvfControl ic)
        {
            InitializeComponent();
            this.ic = ic;
        }
        public void setOPUEmbryoDevReport(DataTable dt)
        {
            String chk = "", printerDefault = "";
            ReportDocument rpt = new ReportDocument();
            try
            {
                rpt.Load("lab_opu_embryo_dev.rpt");
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                rpt.SetParameterValue("line2", "โทรศัพท์ " + ic.cop.tele);
                rpt.SetParameterValue("report_name", " Embryo development");
                //rpt.SetParameterValue("date1", "" + date1);
                this.crystalReportViewer1.ReportSource = rpt;
                this.crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                chk = ex.Message.ToString();
            }
        }
        public void setOPUReport(DataTable dt)
        {
            String chk = "", printerDefault = "";
            ReportDocument rpt = new ReportDocument();
            try
            {
                rpt.Load("lab_opu.rpt");
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                rpt.SetParameterValue("line2", "โทรศัพท์ " + ic.cop.tele);
                rpt.SetParameterValue("report_name", " Summary of OPU Report");
                //rpt.SetParameterValue("date1", "" + date1);
                this.crystalReportViewer1.ReportSource = rpt;
                this.crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                chk = ex.Message.ToString();
            }
        }
        public void setStickerDrugReport(String date, DataTable dt)
        {
            String chk = "", printerDefault="";
            ReportDocument rpt = new ReportDocument();
            try
            {
                PrinterSettings settings = new PrinterSettings();
                foreach (string printer in PrinterSettings.InstalledPrinters)
                {
                    settings.PrinterName = printer;
                    if (settings.IsDefaultPrinter)
                        printerDefault = printer;
                }
                //Properties.Settings.Default["PrinterName"] = ic.iniC.printerSticker;
                                
                PrinterSettings settings1 = new PrinterSettings();
                settings1.PrinterName = ic.iniC.printerSticker;

                String date1 = "";
                date1 = DateTime.Now.Year + "-" + DateTime.Now.ToString("MM-dd HH:mm:ss");

                rpt.Load("sticker_drug.rpt");

                rpt.SetDataSource(dt);
                
                //ic.cop = ic.ivfDB.copDB.selectByCode1("001");
                rpt.SetParameterValue("line11", ic.cop.comp_name_t);
                rpt.SetParameterValue("line12", "โทรศัพท์ "+ic.cop.tele);
                rpt.SetParameterValue("date1", "" + date1);
                this.crystalReportViewer1.ReportSource = rpt;
                this.crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                chk = ex.Message.ToString();
            }
        }
        private void FrmReport_Load(object sender, EventArgs e)
        {

        }
    }
}
