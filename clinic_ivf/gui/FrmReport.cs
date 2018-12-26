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
        public enum flagEmbryoDev { onecolumn, twocolumn};
        public enum flagEmbryoDevMore20 { More20, Days2 };
        public FrmReport(IvfControl ic)
        {
            InitializeComponent();
            this.ic = ic;
        }
        public void setOPDCardOldReport(DataTable dt)
        {
            String chk = "", printerDefault = "";
            ReportDocument rpt = new ReportDocument();
            try
            {
                rpt.Load("opd_card_old.rpt");
                rpt.SetDataSource(dt);
                //rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                //rpt.SetParameterValue("line2", "โทรศัพท์ " + ic.cop.tele);
                //rpt.SetParameterValue("report_name", " Embryo development");
                //rpt.SetParameterValue("date1", "" + date1);
                this.crystalReportViewer1.ReportSource = rpt;
                this.crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                chk = ex.Message.ToString();
            }
        }
        public void setVisitCheckList1Report(DataTable dt)
        {
            String chk = "", printerDefault = "";
            ReportDocument rpt = new ReportDocument();
            try
            {
                rpt.Load("visit_check_list1.rpt");
                rpt.SetDataSource(dt);
                //rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                //rpt.SetParameterValue("line2", "โทรศัพท์ " + ic.cop.tele);
                //rpt.SetParameterValue("report_name", " Embryo development");
                //rpt.SetParameterValue("date1", "" + date1);
                this.crystalReportViewer1.ReportSource = rpt;
                this.crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                chk = ex.Message.ToString();
            }
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
        public void setOPUReport(DataTable dt, flagEmbryoDev flagembryodev, flagEmbryoDevMore20 flagembryodevmore20)
        {
            String chk = "", printerDefault = "";
            ReportDocument rpt = new ReportDocument();
            try
            {
                //rpt.Load("lab_opu.rpt");
                if(flagembryodev == flagEmbryoDev.onecolumn)
                {
                    if(flagembryodevmore20 == flagEmbryoDevMore20.Days2)
                    {
                        rpt.Load("lab_opu.rpt");
                    }
                    else
                    {
                        rpt.Load("lab_opu_more_20.rpt");
                    }
                }
                else
                {
                    if (flagembryodevmore20 == flagEmbryoDevMore20.Days2)
                    {
                        rpt.Load("lab_opu_freeze_2_column.rpt");
                    }
                    else
                    {
                        rpt.Load("lab_opu_freeze_2_column_more_20.rpt");
                    }
                }
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
