using C1.Win.C1SuperTooltip;
using clinic_ivf.control;
using clinic_ivf.object1;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.gui
{
    public partial class FrmLabOPUPrint : Form
    {
        IvfControl ic;
        String reqId = "", opuId = "";
        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;

        LabOpu opu;
        LabFet fet;

        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        Color color;
        public enum opuReport {OPUReport, OPUEmbryoDevReport, FETReport, FETEmbryoDevReport };
        opuReport opureport;
        String aaa = "₀₁₂₃₄₅₆₇₈₉";

        
        public FrmLabOPUPrint(IvfControl ic, String opuid, opuReport opureport)
        {
            InitializeComponent();
            this.ic = ic;
            opuId = opuid;
            this.opureport = opureport;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);
            theme1.SetTheme(sB, "BeigeOne");
            color = ColorTranslator.FromHtml(ic.iniC.grfRowColor);

            opu = new LabOpu();
            fet = new LabFet();
            setControl();

            sB1.Text = "";
            bg = txtHnFeMale.BackColor;
            fc = txtHnFeMale.ForeColor;
            ff = txtHnFeMale.Font;
            
            ic.setCboDayEmbryoDev(cboEmbryoDev1, "");
            ic.setCboDayEmbryoDev(cboEmbryoDev2, "");

            if (opureport == opuReport.OPUEmbryoDevReport)
            {
                groupBox2.Hide();
                label7.Hide();
                cboEmbryoDev2.Hide();
                chkEmbryoDev20.Hide();
                label1.Text = "Day :";
            }
            else if (opureport == opuReport.FETEmbryoDevReport)
            {
                groupBox2.Hide();
                chkEmbryoDev20.Hide();
                label7.Hide();
                cboEmbryoDev2.Hide();

            }
            else
            {
                groupBox2.Show();
            }

            btnPrint.Click += BtnPrint_Click;
            btnExport.Click += BtnExport_Click;
            chkEmbryoDev20.CheckedChanged += ChkEmbryoDev20_CheckedChanged;
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setExportOPU();
        }
        private void setExportOPU()
        {
            DataTable dt = new DataTable();
            dt = ic.ivfDB.setOPUReport(txtID.Text, cboEmbryoDev1.Text, cboEmbryoDev2.Text, chkEmbryoDev20.Checked);
            try
            {
                ReportDocument rpt;
                CrystalReportViewer crv = new CrystalReportViewer();
                rpt = new ReportDocument();
                rpt.Load("lab_opu_more_20.rpt");
                crv.ReportSource = rpt;

                crv.Refresh();
                //rpt.Load(Application.StartupPath + "\\lab_opu_embryo_dev.rpt");
                //rd.Load("StudentReg.rpt");
                rpt.SetDataSource(dt);
                //crv.ReportSource = rd;
                //crv.Refresh();
                if (File.Exists("embryo.pdf"))
                    File.Delete("embryo.pdf");

                ExportOptions CrExportOptions;
                DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                CrDiskFileDestinationOptions.DiskFileName = "embryo.pdf";
                CrExportOptions = rpt.ExportOptions;
                {
                    CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                    CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                    CrExportOptions.FormatOptions = CrFormatTypeOptions;
                }
                rpt.Export();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void ChkEmbryoDev20_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (chkEmbryoDev20.Checked)
            {
                cboEmbryoDev2.Enabled = false;
            }
            else
            {
                cboEmbryoDev2.Enabled = true;
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (opureport == opuReport.OPUReport)
            {
                printOPUReport();
            }
            else if (opureport == opuReport.OPUEmbryoDevReport)
            {
                printOPUEmbryoDev();
            }
            else if (opureport == opuReport.FETEmbryoDevReport)
            {
                //printFETEmbryoDev();
            }

        }
        private void printFETEmbryoDev()
        {
            //FrmReport frm = new FrmReport(ic);
            //DataTable dt = new DataTable();
            //FrmWaiting frmW = new FrmWaiting();
            //frmW.Show();
            //try
            //{
            //    int i = 0;
            //    String day = "";
            //    LabFet fet = new LabFet();
            //    fet = ic.ivfDB.fetDB.selectByPk1(txtID.Text);
            //    day = cboEmbryoDev1.SelectedItem == null ? "" : ((ComboBoxItem)cboEmbryoDev1.SelectedItem).Value;
            //    if (day.Equals("2"))
            //    {
            //        dt = ic.ivfDB.opuEmDevDB.selectByFetFetId_DayPrint(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day2);
            //    }
            //    else if (day.Equals("3"))
            //    {
            //        dt = ic.ivfDB.opuEmDevDB.selectByFetFetId_DayPrint(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day3);
            //    }
            //    else if (day.Equals("5"))
            //    {
            //        dt = ic.ivfDB.opuEmDevDB.selectByFetFetId_DayPrint(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day5);
            //    }
            //    else if (day.Equals("6"))
            //    {
            //        dt = ic.ivfDB.opuEmDevDB.selectByFetFetId_DayPrint(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day6);
            //    }
            //    if (dt.Rows.Count > 0)
            //    {
            //        frmW.pB.Minimum = 1;
            //        frmW.pB.Maximum = dt.Rows.Count;
            //        foreach (DataRow row in dt.Rows)
            //        {
            //            String path_pic = "", opuCode = "";
            //            path_pic = row["no1_pathpic"] != null ? row["no1_pathpic"].ToString() : "";
            //            opuCode = row["fet_code"] != null ? row["fet_code"].ToString() : "";
            //            if (!path_pic.Equals(""))
            //            {
            //                MemoryStream stream = ic.ftpC.download(path_pic);
            //                Image loadedImage = new Bitmap(stream);
            //                String[] ext = path_pic.Split('.');
            //                var extension = Path.GetExtension(path_pic);
            //                var name = Path.GetFileNameWithoutExtension(path_pic); // Get the name only
            //                //if (ext.Length > 0)
            //                //{
            //                String filename = name;
            //                String no = "", filename1 = "", st = "";
            //                no = filename.Substring(filename.Length - 2);
            //                no = no.Replace("_", "");
            //                filename1 = "embryo_dev_" + no + extension;
            //                if (File.Exists(filename1))
            //                {
            //                    File.Delete(filename1);
            //                    System.Threading.Thread.Sleep(200);
            //                }
            //                loadedImage.Save(filename1);
            //                row["no1_pathpic"] = System.IO.Directory.GetCurrentDirectory() + "\\" + filename1;
            //                //st = row["no1_desc2"].ToString();
            //                st = row["no1_desc3"].ToString();
            //                row["no1_desc2"] = "st# " + st;
            //                row["no1_desc3"] = row["no1_desc4"].ToString();
            //                //}footer11
            //            }
            //            //row["footer11"] = opu.remark_day2;
            //            //row["footer12"] = opu.remark_day3;
            //            //row["footer13"] = opu.remark_day5;
            //            //row["footer14"] = opu.remark_day6;
            //            //row["footer15"] = "";
            //            //row["footer16"] = "";
            //            i++;
            //            frmW.pB.Value = i;
            //        }
            //    }
            //    String date1 = "";
            //    date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.fetDB.fet.fet_date].ToString());
            //    dt.Rows[0][ic.ivfDB.fetDB.fet.fet_date] = date1.Replace("-", "/");

            //    frm.setFETEmbryoDevReport(dt);

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("" + ex.Message, "");
            //}
            //finally
            //{
            //    frmW.Dispose();
            //}
            //frm.ShowDialog(this);
        }
        private void printOPUReport()
        {
            DataTable dt = new DataTable();
            FrmReport frm = new FrmReport(ic);
            dt = ic.ivfDB.setOPUReport(txtID.Text, cboEmbryoDev1.Text, cboEmbryoDev2.Text, chkEmbryoDev20.Checked);
            if (dt == null) return;
            if (chkEmbryoFreez2Col.Checked)
            {
                if (chkEmbryoDev20.Checked)
                {
                    frm.setOPUReport(dt, FrmReport.flagEmbryoDev.twocolumn, FrmReport.flagEmbryoDevMore20.More20);
                }
                else
                {
                    frm.setOPUReport(dt, FrmReport.flagEmbryoDev.twocolumn, FrmReport.flagEmbryoDevMore20.Days2);
                }
            }
            else
            {
                if (chkEmbryoDev20.Checked)
                {
                    frm.setOPUReport(dt, FrmReport.flagEmbryoDev.onecolumn, FrmReport.flagEmbryoDevMore20.More20);
                }
                else
                {
                    frm.setOPUReport(dt, FrmReport.flagEmbryoDev.onecolumn, FrmReport.flagEmbryoDevMore20.Days2);
                }
            }
            //dt.AcceptChanges();
            frm.ShowDialog(this);
            //frm.setOPUReport(dt);
        }
        private void printOPUEmbryoDev()
        {
            FrmReport frm = new FrmReport(ic);
            DataTable dt = new DataTable();
            FrmWaiting frmW = new FrmWaiting();
            frmW.Show();
            try
            {
                //MessageBox.Show("aaaaa", "");
                int i = 0;
                String day = "";
                LabOpu opu = new LabOpu();
                opu = ic.ivfDB.opuDB.selectByPk1(txtID.Text);
                day = cboEmbryoDev1.SelectedItem == null ? "" : ((ComboBoxItem)cboEmbryoDev1.SelectedItem).Value;
                if (day.Equals("2"))
                {
                    dt = ic.ivfDB.opuEmDevDB.selectByOpuFetId_DayPrint(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day2);
                }
                else if (day.Equals("3"))
                {
                    dt = ic.ivfDB.opuEmDevDB.selectByOpuFetId_DayPrint(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day3);
                }
                else if (day.Equals("5"))
                {
                    dt = ic.ivfDB.opuEmDevDB.selectByOpuFetId_DayPrint(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day5);
                }
                else if (day.Equals("6"))
                {
                    dt = ic.ivfDB.opuEmDevDB.selectByOpuFetId_DayPrint(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day6);
                }
                dt.Columns.Add("footer11", typeof(String));
                dt.Columns.Add("footer12", typeof(String));
                dt.Columns.Add("footer13", typeof(String));
                dt.Columns.Add("footer14", typeof(String));
                dt.Columns.Add("footer15", typeof(String));
                dt.Columns.Add("footer16", typeof(String));
                if (dt.Rows.Count > 0)
                {
                    frmW.pB.Minimum = 1;
                    frmW.pB.Maximum = dt.Rows.Count;
                    foreach (DataRow row in dt.Rows)
                    {
                        String path_pic = "", opuCode = "";
                        path_pic = row["no1_pathpic"] != null ? row["no1_pathpic"].ToString() : "";
                        opuCode = row["opu_code"] != null ? row["opu_code"].ToString() : "";
                        if (!path_pic.Equals(""))
                        {
                            MemoryStream stream = ic.ftpC.download(path_pic);
                            Image loadedImage = new Bitmap(stream);
                            String[] ext = path_pic.Split('.');
                            var extension = Path.GetExtension(path_pic);
                            var name = Path.GetFileNameWithoutExtension(path_pic); // Get the name only
                            //if (ext.Length > 0)
                            //{
                            String filename = name;
                            String no = "", filename1 = "",st="";
                            no = filename.Substring(filename.Length - 2);
                            no = no.Replace("_", "");
                            filename1 = "embryo_dev_" + no + extension;
                            if (File.Exists(filename1))
                            {
                                File.Delete(filename1);
                                System.Threading.Thread.Sleep(200);
                            }
                            loadedImage.Save(filename1);
                            row["no1_pathpic"] = System.IO.Directory.GetCurrentDirectory() + "\\" + filename1;
                            //st = row["no1_desc2"].ToString();
                            st = row["no1_desc3"].ToString();
                            row["no1_desc2"] = "st# " + st;
                            row["no1_desc3"] = row["no1_desc4"].ToString();
                            //}footer11
                        }
                        row["footer11"] = opu.remark_day2;
                        row["footer12"] = opu.remark_day3;
                        row["footer13"] = opu.remark_day5;
                        row["footer14"] = opu.remark_day6;
                        row["footer15"] = "";
                        row["footer16"] = "";
                        i++;
                        frmW.pB.Value = i;
                    }
                }
                String date1 = "";
                date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.opuDB.opu.opu_date].ToString());
                dt.Rows[0][ic.ivfDB.opuDB.opu.opu_date] = date1.Replace("-", "/");

                frm.setOPUEmbryoDevReport(dt);
                //MessageBox.Show("bbbbbb", "");
            }
            catch (Exception ex)
            {
                ic.logw.WriteLog("e", "error printOPUEmbryoDev " + ex.Message);
                MessageBox.Show("" + ex.Message, "");
            }
            finally
            {
                frmW.Dispose();
            }
            frm.ShowDialog(this);
        }
        private void setControl()
        {
            if(opureport == opuReport.OPUReport || opureport == opuReport.OPUEmbryoDevReport)
            {
                opu = ic.ivfDB.opuDB.selectByPk1(opuId);
                txtID.Value = opu.opu_id;
                txtHnFeMale.Value = opu.hn_female;
                txtHnMale.Value = opu.hn_male;
                txtNameFeMale.Value = opu.name_female;
                txtNameMale.Value = opu.name_male;
                txtOpuCode.Value = opu.opu_code;
            }
            else
            {
                fet = ic.ivfDB.fetDB.selectByPk1(opuId);
                txtID.Value = fet.fet_id;
                txtHnFeMale.Value = fet.hn_female;
                txtHnMale.Value = fet.hn_male;
                txtNameFeMale.Value = fet.name_female;
                txtNameMale.Value = fet.name_male;
                txtOpuCode.Value = fet.fet_code;
            }
        }
        private void FrmLabOPUPrint_Load(object sender, EventArgs e)
        {

        }
    }
}
