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
        public void setORFormA(String name, String hn, String or_date, String diagnosis, String operation, String surgeon, String age, String anesthesia)
        {
            String chk = "", printerDefault = "";
            ReportDocument rpt = new ReportDocument();
            try
            {
                rpt.Load("or_form_a.rpt");
                //rpt.SetDataSource(dt);
                rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                rpt.SetParameterValue("line2", ic.cop.addr1);
                rpt.SetParameterValue("line3", ic.cop.addr2);
                rpt.SetParameterValue("patient_hn", hn);
                rpt.SetParameterValue("patient_name", name);
                rpt.SetParameterValue("or_date", or_date);
                rpt.SetParameterValue("diagnosis", diagnosis);
                rpt.SetParameterValue("operation", operation);
                rpt.SetParameterValue("surgeon_name", surgeon);
                rpt.SetParameterValue("age", age);
                rpt.SetParameterValue("anesthesia_name", anesthesia);
                this.crystalReportViewer1.ReportSource = rpt;
                this.crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                chk = ex.Message.ToString();
                MessageBox.Show("error " + ex.Message, "");
            }
        }
        public void setORDf(String name, String hn, String or_date, String diagnosis, String operation)
        {
            String chk = "", printerDefault = "";
            ReportDocument rpt = new ReportDocument();
            try
            {
                rpt.Load("or_form_df.rpt");
                //rpt.SetDataSource(dt);
                rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                rpt.SetParameterValue("line2", ic.cop.addr1);
                rpt.SetParameterValue("line3", ic.cop.addr2);
                rpt.SetParameterValue("patient_hn", hn);
                rpt.SetParameterValue("patient_name", name);
                rpt.SetParameterValue("or_date", or_date);
                rpt.SetParameterValue("diagnosis", diagnosis);
                rpt.SetParameterValue("operation", operation);
                //rpt.SetParameterValue("patient_name", name);
                //rpt.SetParameterValue("report_name", " OPD Record ");
                //rpt.SetParameterValue("age1", "" + age);
                this.crystalReportViewer1.ReportSource = rpt;
                this.crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                chk = ex.Message.ToString();
                MessageBox.Show("error " + ex.Message, "");
            }
        }
        public void setOrAppointment(DataTable dt)
        {
            String chk = "", printerDefault = "", err = "";
            ReportDocument rpt = new ReportDocument();
            try
            {
                err = "00" + ic.iniC.statusAppDonor;

                rpt.Load("or_appointment.rpt");

                err = "01";
                rpt.SetDataSource(dt);
                err = "02";
                rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                //rpt.SetParameterValue("line2", "โทรศัพท์ " + ic.cop.tele);
                //rpt.SetParameterValue("line2", "โทรศัพท์ " + ic.cop.comp_address_e + " " + ic.cop.tele);
                //rpt.SetParameterValue("report_name", " Appointment/ใบแพทย์นัด ");

                err = "03";
                //rpt.SetParameterValue("age1", "" + age);
                this.crystalReportViewer1.ReportSource = rpt;
                err = "04";
                this.crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                chk = ex.Message.ToString();
                MessageBox.Show("error " + ex.Message, "err " + err);
            }
        }
        public void setOpdpostoperationnote(String name, String hn)
        {
            String chk = "", printerDefault = "";
            ReportDocument rpt = new ReportDocument();
            try
            {
                rpt.Load("opd_post_operation_note.rpt");
                //rpt.SetDataSource(dt);
                rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                rpt.SetParameterValue("line2", ic.cop.addr1);
                rpt.SetParameterValue("line3", ic.cop.addr2);
                rpt.SetParameterValue("hn", hn);
                rpt.SetParameterValue("name", name);
                this.crystalReportViewer1.ReportSource = rpt;
                this.crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                chk = ex.Message.ToString();
                MessageBox.Show("error " + ex.Message, "");
            }
        }
        public void setOpdOrderETFET(String name, String hn)
        {
            String chk = "", printerDefault = "";
            ReportDocument rpt = new ReportDocument();
            try
            {
                rpt.Load("opd_order_et_fet.rpt");
                //rpt.SetDataSource(dt);
                rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                rpt.SetParameterValue("line2", ic.cop.addr1);
                rpt.SetParameterValue("line3", ic.cop.addr2);
                rpt.SetParameterValue("hn", hn);
                rpt.SetParameterValue("name", name);
                this.crystalReportViewer1.ReportSource = rpt;
                this.crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                chk = ex.Message.ToString();
                MessageBox.Show("error " + ex.Message, "");
            }
        }
        public void setOpdOrderOPU(String name, String hn)
        {
            String chk = "", printerDefault = "";
            ReportDocument rpt = new ReportDocument();
            try
            {
                rpt.Load("opd_order_opu.rpt");
                //rpt.SetDataSource(dt);
                rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                rpt.SetParameterValue("line2", ic.cop.addr1);
                rpt.SetParameterValue("line3", ic.cop.addr2);
                rpt.SetParameterValue("hn", hn);
                rpt.SetParameterValue("name", name);                
                this.crystalReportViewer1.ReportSource = rpt;
                this.crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                chk = ex.Message.ToString();
                MessageBox.Show("error " + ex.Message, "");
            }
        }
        public void setOpdAuthenSign(String name, String hn)
        {
            String chk = "", printerDefault = "";
            ReportDocument rpt = new ReportDocument();
            try
            {
                rpt.Load("opd_authen_sign.rpt");
                //rpt.SetDataSource(dt);
                rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                rpt.SetParameterValue("line2", ic.cop.addr1);
                rpt.SetParameterValue("line3", ic.cop.addr2);
                rpt.SetParameterValue("hn", hn);
                rpt.SetParameterValue("name", name);
                //rpt.SetParameterValue("line2", "โทรศัพท์ " + ic.cop.tele);
                //rpt.SetParameterValue("report_name", " OPD Record ");
                //rpt.SetParameterValue("age1", "" + age);
                this.crystalReportViewer1.ReportSource = rpt;
                this.crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                chk = ex.Message.ToString();
                MessageBox.Show("error " + ex.Message, "");
            }
        }
        public void setOpdCheckList(String name)
        {
            String chk = "", printerDefault = "";
            ReportDocument rpt = new ReportDocument();
            try
            {
                rpt.Load("opd_check_list.rpt");
                //rpt.SetDataSource(dt);
                rpt.SetParameterValue("name", name);
                //rpt.SetParameterValue("line2", "โทรศัพท์ " + ic.cop.tele);
                //rpt.SetParameterValue("report_name", " OPD Record ");
                //rpt.SetParameterValue("age1", "" + age);
                this.crystalReportViewer1.ReportSource = rpt;
                this.crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                chk = ex.Message.ToString();
                MessageBox.Show("error " + ex.Message, "");
            }
        }
        public void setDeliverPttReport(DataTable dt)
        {
            String chk = "", printerDefault = "";
            ReportDocument rpt = new ReportDocument();
            try
            {
                rpt.Load("ptt_deliver.rpt");
                rpt.SetDataSource(dt);
                //rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                //rpt.SetParameterValue("line2", "โทรศัพท์ " + ic.cop.tele);
                //rpt.SetParameterValue("report_name", " OPD Record ");
                //rpt.SetParameterValue("age1", "" + age);
                this.crystalReportViewer1.ReportSource = rpt;
                this.crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                chk = ex.Message.ToString();
                MessageBox.Show("error " + ex.Message, "");
            }
        }
        public void setPrintBill(DataTable dt, String hn, String name, String thai_baht, String amount, String bill_no, String bill_date, String payby)
        {
            String chk = "", printerDefault = "";
            ReportDocument rpt = new ReportDocument();
            try
            {
                rpt.Load("print_bill.rpt");
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                rpt.SetParameterValue("line2", ic.cop.addr1);
                rpt.SetParameterValue("line3", ic.cop.addr2);
                rpt.SetParameterValue("line4", "");
                rpt.SetParameterValue("bill_no", bill_no);
                rpt.SetParameterValue("bill_date", bill_date);
                rpt.SetParameterValue("amount", amount);
                rpt.SetParameterValue("thai_baht", thai_baht);
                rpt.SetParameterValue("hn", hn);
                rpt.SetParameterValue("name", name);
                rpt.SetParameterValue("footer1", "คลินิกจะรับคืนยาเฉพาะรายที่มีอาการแพ้ยาซึ่งวินิจฉัยโดยแพทย์เท่านั้น กรุณาเก็บใบเสร็จรับเงินเป็นหลักฐานในการติดต่อกับคลินิกทุกครั้ง");
                rpt.SetParameterValue("footer2", "Patients may return the medicine only if they have experienced adverse reaction to that medication.");
                rpt.SetParameterValue("footer3", "Please keep this receipt for reference.");
                rpt.SetParameterValue("footer4", "เจ้าหน้าที่การเงิน (Cashier)");
                rpt.SetParameterValue("payby", payby);
                this.crystalReportViewer1.ReportSource = rpt;
                this.crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                chk = ex.Message.ToString();
                MessageBox.Show("error " + ex.Message, "");
            }
        }
        public void setLabFormDay1Report(DataTable dt)
        {
            String chk = "", printerDefault = "", err = "";
            ReportDocument rpt = new ReportDocument();
            try
            {
                err = "00" + ic.iniC.statusAppDonor;

                rpt.Load("lab_form_day1.rpt");

                err = "01";
                rpt.SetDataSource(dt);
                err = "02";
                rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                rpt.SetParameterValue("line2", "โทรศัพท์ " + ic.cop.tele);
                rpt.SetParameterValue("report_name", " Laboratory Request Form Day1 ");
                err = "03";
                //rpt.SetParameterValue("age1", "" + age);
                this.crystalReportViewer1.ReportSource = rpt;
                err = "04";
                this.crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                chk = ex.Message.ToString();
                MessageBox.Show("error " + ex.Message, "err " + err);
            }
        }
        public void setAppointmentPatient(DataTable dt)
        {
            String chk = "", printerDefault = "", err = "";
            ReportDocument rpt = new ReportDocument();
            try
            {
                err = "00" + ic.iniC.statusAppDonor;

                rpt.Load("Appointment_Patient.rpt");

                err = "01";
                rpt.SetDataSource(dt);
                err = "02";
                rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                //rpt.SetParameterValue("line2", "โทรศัพท์ " + ic.cop.tele);
                rpt.SetParameterValue("line2", "โทรศัพท์ " + ic.cop.comp_address_e+" "+ ic.cop.tele);
                rpt.SetParameterValue("report_name", " Appointment/ใบแพทย์นัด ");

                err = "03";
                //rpt.SetParameterValue("age1", "" + age);
                this.crystalReportViewer1.ReportSource = rpt;
                err = "04";
                this.crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                chk = ex.Message.ToString();
                MessageBox.Show("error " + ex.Message, "err " + err);
            }
        }
        public void setLabFormAFetReport(DataTable dt)
        {
            String chk = "", printerDefault = "", err = "";
            ReportDocument rpt = new ReportDocument();
            try
            {
                err = "00" + ic.iniC.statusAppDonor;

                rpt.Load("lab_form_a_fet.rpt");

                err = "01";
                rpt.SetDataSource(dt);
                err = "02";
                rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                rpt.SetParameterValue("line2", "โทรศัพท์ " + ic.cop.tele);
                rpt.SetParameterValue("report_name", " Laboratory Request Form ");
                err = "03";
                //rpt.SetParameterValue("age1", "" + age);
                this.crystalReportViewer1.ReportSource = rpt;
                err = "04";
                this.crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                chk = ex.Message.ToString();
                MessageBox.Show("error " + ex.Message, "err " + err);
            }
        }
        public void setLabFormAOPUReport(DataTable dt)
        {
            String chk = "", printerDefault = "", err = "";
            ReportDocument rpt = new ReportDocument();
            try
            {
                err = "00" + ic.iniC.statusAppDonor;

                rpt.Load("lab_form_a_opu.rpt");

                err = "01";
                rpt.SetDataSource(dt);
                err = "02";
                rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                rpt.SetParameterValue("line2", "โทรศัพท์ " + ic.cop.tele);
                rpt.SetParameterValue("report_name", " Laboratory Request Form ");
                err = "03";
                //rpt.SetParameterValue("age1", "" + age);
                this.crystalReportViewer1.ReportSource = rpt;
                err = "04";
                this.crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                chk = ex.Message.ToString();
                MessageBox.Show("error " + ex.Message, "err " + err);
            }
        }
        public void setLabFormAReport(DataTable dt)
        {
            String chk = "", printerDefault = "", err = "";
            ReportDocument rpt = new ReportDocument();
            try
            {
                err = "00" + ic.iniC.statusAppDonor;
                
                rpt.Load("lab_form_a.rpt");
                
                err = "01";
                rpt.SetDataSource(dt);
                err = "02";
                rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                rpt.SetParameterValue("line2", "โทรศัพท์ " + ic.cop.tele);
                rpt.SetParameterValue("report_name", " Laboratory Request Form ");
                err = "03";
                //rpt.SetParameterValue("age1", "" + age);
                this.crystalReportViewer1.ReportSource = rpt;
                err = "04";
                this.crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                chk = ex.Message.ToString();
                MessageBox.Show("error " + ex.Message, "err " + err);
            }
        }
        public void setAppoitmentDailyReport(DataTable dt)
        {
            String chk = "", printerDefault = "", err="";
            ReportDocument rpt = new ReportDocument();
            try
            {
                err = "00"+ ic.iniC.statusAppDonor;
                if (ic.iniC.statusAppDonor.Equals("1"))
                {
                    rpt.Load("Appointment_daily_donor.rpt");
                }
                else
                {
                    rpt.Load("Appointment_daily_old.rpt");
                }
                err = "01";
                rpt.SetDataSource(dt);
                err = "02";
                rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                rpt.SetParameterValue("line2", "โทรศัพท์ " + ic.cop.tele);
                rpt.SetParameterValue("report_name", " Appointment Daily Report ");
                err = "03";
                //rpt.SetParameterValue("age1", "" + age);
                this.crystalReportViewer1.ReportSource = rpt;
                err = "04";
                this.crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                chk = ex.Message.ToString();
                MessageBox.Show("error "+ ex.Message, "err "+ err);
            }
        }
        public void setOPDCardOldReport(DataTable dt, String age)
        {
            String chk = "", printerDefault = "";
            ReportDocument rpt = new ReportDocument();
            try
            {
                rpt.Load("opd_card_old.rpt");
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                rpt.SetParameterValue("line2", "โทรศัพท์ " + ic.cop.tele);
                rpt.SetParameterValue("report_name", " OPD Record ");
                rpt.SetParameterValue("age1", "" + age);
                this.crystalReportViewer1.ReportSource = rpt;
                this.crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                chk = ex.Message.ToString();
                MessageBox.Show("error " + ex.Message, "");
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
                MessageBox.Show("error " + ex.Message, "");
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
                MessageBox.Show("error " + ex.Message, "");
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
                MessageBox.Show("error " + ex.Message, "");
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
                date1 = ic.datetimetoShow(date1);
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
                MessageBox.Show("error " + ex.Message, "");
            }
        }
        private void FrmReport_Load(object sender, EventArgs e)
        {

        }
    }
}
