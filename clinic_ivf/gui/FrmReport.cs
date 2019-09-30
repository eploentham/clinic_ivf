using clinic_ivf.control;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
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
        //DataTable dtt = new DataTable();
        public FrmReport(IvfControl ic)
        {
            InitializeComponent();
            this.ic = ic;
        }
        public void setLabBloodRequest(DataTable dt, String hn, String name, String age, String sex, String vsdate, String reqdate, String doctor, String stforder)
        {
            String chk = "", printerDefault = "", err = "";
            ReportDocument rpt = new ReportDocument();
            try
            {
                err = "00" + ic.iniC.statusAppDonor;

                rpt.Load("lab_blood_request.rpt");

                err = "01";
                rpt.SetDataSource(dt);
                err = "02";
                rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                rpt.SetParameterValue("line2", ic.cop.addr1);
                rpt.SetParameterValue("line3", ic.cop.addr2);
                rpt.SetParameterValue("hn", hn);
                rpt.SetParameterValue("name", name);
                rpt.SetParameterValue("dob", age);
                rpt.SetParameterValue("sex", sex);
                rpt.SetParameterValue("visit_date", vsdate);
                rpt.SetParameterValue("req_date", reqdate);
                rpt.SetParameterValue("doctor", doctor);
                rpt.SetParameterValue("staff_order", stforder);
                //rpt.SetParameterValue("collect_date", approve_date);
                //rpt.SetParameterValue("receive_date", approve_date);
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
        public void setLabBloodReportInfectious(DataTable dt, String hn, String name, String age, String sex, String report_by, String approve_by, String report_date, String approve_date, String collect_date, String receive_date)
        {
            String chk = "", printerDefault = "", err = "";
            ReportDocument rpt = new ReportDocument();
            try
            {
                err = "00" + ic.iniC.statusAppDonor;

                rpt.Load("lab_blood_form2.rpt");

                err = "01";
                rpt.SetDataSource(dt);
                err = "02";
                rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                rpt.SetParameterValue("line2", ic.cop.addr1);
                rpt.SetParameterValue("line3", ic.cop.addr2);
                rpt.SetParameterValue("hn", hn);
                rpt.SetParameterValue("name", name);
                rpt.SetParameterValue("dob", age);
                rpt.SetParameterValue("sex", sex);
                rpt.SetParameterValue("report_by", report_by);
                rpt.SetParameterValue("approve_by", approve_by);
                rpt.SetParameterValue("report_date", report_date);
                rpt.SetParameterValue("approve_date", approve_date);
                rpt.SetParameterValue("collect_date", collect_date);
                rpt.SetParameterValue("receive_date", receive_date);
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
        public void setLabBloodReportHormone(DataTable dt, String hn, String name, String age, String sex, String report_by, String approve_by, String report_date, String approve_date, String flagDonor, String flagamh, String collect_date, String receive_date)
        {
            String chk = "", printerDefault = "", err = "";
            ReportDocument rpt = new ReportDocument();
            try
            {
                err = "00" + ic.iniC.statusAppDonor;
                if (flagamh.Equals("1"))
                {
                    rpt.Load("lab_blood_form1_amh.rpt");
                }
                else
                {
                    rpt.Load("lab_blood_form1.rpt");
                }
                

                err = "01";
                rpt.SetDataSource(dt);
                err = "02";
                if (flagDonor.Equals("1"))
                {
                    rpt.SetParameterValue("line1", "");
                    rpt.SetParameterValue("line2", "");
                    rpt.SetParameterValue("line3", "");
                }
                else
                {
                    rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                    rpt.SetParameterValue("line2", ic.cop.addr1);
                    rpt.SetParameterValue("line3", ic.cop.addr2);
                }
                rpt.SetParameterValue("hn", hn);
                rpt.SetParameterValue("name", name);
                rpt.SetParameterValue("dob", age);                
                rpt.SetParameterValue("sex", sex);
                rpt.SetParameterValue("report_by", report_by);
                rpt.SetParameterValue("approve_by", approve_by);
                rpt.SetParameterValue("report_date", report_date);
                rpt.SetParameterValue("approve_date", approve_date);
                rpt.SetParameterValue("collect_date", collect_date);
                rpt.SetParameterValue("receive_date", receive_date);
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
        public void setPmhReport(DataTable dt, String hn, String name, String dob, String occup, String couple_name, String couple_age, String couple_occup, String sex, String married)
        {
            String chk = "", printerDefault = "", err = "";
            ReportDocument rpt = new ReportDocument();
            try
            {
                err = "00" + ic.iniC.statusAppDonor;

                rpt.Load("pmh.rpt");

                err = "01";
                rpt.SetDataSource(dt);
                err = "02";
                rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                rpt.SetParameterValue("line2", "โทรศัพท์ " + ic.cop.tele);
                rpt.SetParameterValue("line3", " Patient Medical History");
                rpt.SetParameterValue("hn", hn);
                rpt.SetParameterValue("name", name);
                rpt.SetParameterValue("dob", dob);
                rpt.SetParameterValue("occup", occup);
                rpt.SetParameterValue("couple_name", couple_name);
                rpt.SetParameterValue("couple_age", couple_age);
                rpt.SetParameterValue("couple_occup", couple_occup);
                rpt.SetParameterValue("sex", sex);
                rpt.SetParameterValue("married", married);
                //rpt.SetParameterValue("et", et);
                //rpt.SetParameterValue("fet", fet);
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
        public void setLabFormASpermReport(DataTable dt)
        {
            String chk = "", printerDefault = "", err = "";
            ReportDocument rpt = new ReportDocument();
            try
            {
                err = "00" + ic.iniC.statusAppDonor;

                rpt.Load("lab_form_a_sperm.rpt");

                err = "01";
                rpt.SetDataSource(dt);
                err = "02";
                rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                rpt.SetParameterValue("line2", "โทรศัพท์ " + ic.cop.tele);
                rpt.SetParameterValue("report_name", " Laboratory Request Form Sperm");
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
        public void setPatientMedicalHistory(String name, String hn)
        {
            String chk = "", printerDefault = "";
            ReportDocument rpt = new ReportDocument();
            try
            {
                rpt.Load("pmh.rpt");
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
        public void setStickerPatientThemalLIS(DataTable dt)
        {
            String chk = "", printerDefault = "";
            ReportDocument rpt = new ReportDocument();
            try
            {
                rpt.Load("sticker_patient_lis.rpt");
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
        public void setStickerPatientLISThemal(DataTable dt)
        {
            String chk = "", printerDefault = "";
            ReportDocument rpt = new ReportDocument();
            try
            {
                rpt.Load("sticker_patient_lis.rpt");
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
        public void setStickerPatientThemal(DataTable dt)
        {
            String chk = "", printerDefault = "";
            ReportDocument rpt = new ReportDocument();
            try
            {
                rpt.Load("sticker_patient.rpt");
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
        public void setSpermIui(DataTable dt)
        {
            String chk = "", printerDefault = "";
            ReportDocument rpt = new ReportDocument();
            try
            {
                rpt.Load("lab_sperm_iui.rpt");
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                rpt.SetParameterValue("line2", "");
                rpt.SetParameterValue("line3", " ");
                this.crystalReportViewer1.ReportSource = rpt;
                this.crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                chk = ex.Message.ToString();
                MessageBox.Show("error " + ex.Message, "");
            }
        }
        public void setSpermPesa(DataTable dt)
        {
            String chk = "", printerDefault = "";
            ReportDocument rpt = new ReportDocument();
            try
            {
                rpt.Load("lab_sperm_pesa.rpt");
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                rpt.SetParameterValue("line2", "");
                rpt.SetParameterValue("line3", " ");
                this.crystalReportViewer1.ReportSource = rpt;
                this.crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                chk = ex.Message.ToString();
                MessageBox.Show("error " + ex.Message, "");
            }
        }
        public void setSpermSa(DataTable dt)
        {
            String chk = "", printerDefault = "";
            ReportDocument rpt = new ReportDocument();
            try
            {
                rpt.Load("lab_sperm_sa.rpt");
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                rpt.SetParameterValue("line2", "");
                rpt.SetParameterValue("line3", " ");
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
        public void setSpermSf(DataTable dt)
        {
            String chk = "", printerDefault = "";
            ReportDocument rpt = new ReportDocument();
            try
            {
                rpt.Load("lab_sperm_sf.rpt");
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                rpt.SetParameterValue("line2", "" );
                rpt.SetParameterValue("line3", " ");
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
        public void setEggStiReport(DataTable dt, String ptt_female, String ptt_male, String lmp, String g, String p, String a
            , String doctor_name, String opu_date, String opu_time, String et, String fet, String allergy1
            ,String height, String bp, String bw, String pulse)
        {
            String chk = "", printerDefault = "", err = "";
            ReportDocument rpt = new ReportDocument();
            try
            {
                err = "00" + ic.iniC.statusAppDonor;

                rpt.Load("EggSti.rpt");

                err = "01";
                rpt.SetDataSource(dt);
                err = "02";
                rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                rpt.SetParameterValue("line2", "โทรศัพท์ " + ic.cop.tele);
                rpt.SetParameterValue("line3", " Form Egg Stimulation");
                rpt.SetParameterValue("ptt_female", ptt_female);
                rpt.SetParameterValue("ptt_male", ptt_male);
                rpt.SetParameterValue("lmp", lmp);
                rpt.SetParameterValue("g", g);
                rpt.SetParameterValue("p", p);
                rpt.SetParameterValue("a", a);
                rpt.SetParameterValue("doctor_name", doctor_name);
                rpt.SetParameterValue("opu_date", opu_date);
                rpt.SetParameterValue("opu_time", opu_time);
                rpt.SetParameterValue("et", et);
                rpt.SetParameterValue("fet", fet);
                rpt.SetParameterValue("allergy1", allergy1);
                rpt.SetParameterValue("height", height);
                rpt.SetParameterValue("bw", bw);
                rpt.SetParameterValue("bp", bp);
                rpt.SetParameterValue("pulse", pulse);
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
        public void setOpdpostoperationnote(String name, String hn, String age)
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
                rpt.SetParameterValue("age", age);
                this.crystalReportViewer1.ReportSource = rpt;
                this.crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                chk = ex.Message.ToString();
                MessageBox.Show("error " + ex.Message, "");
            }
        }
        public void setOpdOrderETFET(String name, String hn, String age)
        {
            String chk = "", printerDefault = "";
            String date = "";
            date = DateTime.Now.ToString("dd/MM/") + DateTime.Now.Year;
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
                rpt.SetParameterValue("age", age);
                rpt.SetParameterValue("date", date);
                this.crystalReportViewer1.ReportSource = rpt;
                this.crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                chk = ex.Message.ToString();
                MessageBox.Show("error " + ex.Message, "");
            }
        }
        public void setOpdOrderOPU(String name, String hn, String age)
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
                rpt.SetParameterValue("age", age);
                this.crystalReportViewer1.ReportSource = rpt;
                this.crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                chk = ex.Message.ToString();
                MessageBox.Show("error " + ex.Message, "");
            }
        }
        public void setOpdAuthenSign(String name, String hn, String age, String dtrname, String anesname, String date, String operation)
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
                rpt.SetParameterValue("age", age);
                rpt.SetParameterValue("date", date);
                rpt.SetParameterValue("doctorname", dtrname);
                rpt.SetParameterValue("doctoranes", anesname);
                rpt.SetParameterValue("operation", operation);
                this.crystalReportViewer1.ReportSource = rpt;
                this.crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                chk = ex.Message.ToString();
                MessageBox.Show("error " + ex.Message, "");
            }
        }
        public void setOpdCheckList(String name, String hn, String age, String name1)
        {
            String chk = "", printerDefault = "";
            ReportDocument rpt = new ReportDocument();
            try
            {
                rpt.Load("opd_check_list.rpt");
                //rpt.SetDataSource(dt);
                rpt.SetParameterValue("name", name);
                rpt.SetParameterValue("hn", hn);
                rpt.SetParameterValue("age", age);
                rpt.SetParameterValue("name1", name1);
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
        public void setPrintBill(DataTable dt, String hn, String name, String thai_baht, String amount, String bill_no, String bill_date, String payby, String billname, String sumprice)
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
                if (billname.IndexOf("Receipt")>=0)
                {
                    rpt.SetParameterValue("bill_no", "เลขที่/Receipt No " + bill_no);
                }
                else
                {
                    rpt.SetParameterValue("bill_no", "เลขที่/Bill No " + bill_no);
                }
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
                rpt.SetParameterValue("bill_name", billname);
                rpt.SetParameterValue("sum_price", sumprice);
                //rpt.SetParameterValue("pay_by", sumprice);
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
                rpt.SetParameterValue("line2", ic.cop.comp_address_e+" "+ ic.cop.tele);
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
                rpt.SetParameterValue("report_name", " Laboratory Request Form FET");
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
                rpt.SetParameterValue("report_name", " Laboratory Request Form OPU");
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
                //dtt = dt;
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("line1", ic.cop.comp_name_t);
                rpt.SetParameterValue("line2", "โทรศัพท์ " + ic.cop.tele);
                rpt.SetParameterValue("report_name", " Summary of OPU Report");
                //rpt.SetParameterValue("date1", "" + date1);
                this.crystalReportViewer1.ReportSource = rpt;
                this.crystalReportViewer1.Refresh();

                //ExportOptions CrExportOptions;
                //DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                //PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                //CrDiskFileDestinationOptions.DiskFileName = "embryo.pdf";
                //CrExportOptions = rpt.ExportOptions;
                //{
                //    CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                //    CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                //    CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                //    CrExportOptions.FormatOptions = CrFormatTypeOptions;
                //}

                //rpt.Export();
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
                //PrinterSettings settings = new PrinterSettings();
                //foreach (string printer in PrinterSettings.InstalledPrinters)
                //{
                //    settings.PrinterName = printer;
                //    if (settings.IsDefaultPrinter)
                //        printerDefault = printer;
                //}
                //Properties.Settings.Default["PrinterName"] = ic.iniC.printerSticker;
                
                //PrinterSettings settings1 = new PrinterSettings();
                //settings1.DefaultPageSettings.PrinterSettings.PrinterName = ic.iniC.printerSticker;
                //settings1.PrinterName = ic.iniC.printerSticker;

                String date1 = "";
                //date1 = DateTime.Now.Year + "-" + DateTime.Now.ToString("MM-dd HH:mm:ss");
                date1 =  DateTime.Now.ToString("dd-MM") + "-"+ DateTime.Now.Year;
                //date1 = ic.da(date1);
                rpt.Load("sticker_drug.rpt");

                rpt.SetDataSource(dt);
                
                //ic.cop = ic.ivfDB.copDB.selectByCode1("001");
                rpt.SetParameterValue("line11", ic.cop.comp_name_t);
                rpt.SetParameterValue("line12", "โทรศัพท์ "+ic.cop.tele);
                rpt.SetParameterValue("date1", "" + date1);
                //rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.
                //rpt.PrintOptions.PrinterName = ic.iniC.printerSticker;
                //rpt.PrintToPrinter(1, false, 1, 1);
                //crystalReportViewer1.
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
