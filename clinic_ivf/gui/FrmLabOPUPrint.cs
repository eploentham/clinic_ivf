using C1.Win.C1SuperTooltip;
using clinic_ivf.control;
using clinic_ivf.object1;
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

        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        Color color;
        public enum opuReport {OPUReport, OPUEmbryoDevReport };
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
            else
            {
                groupBox2.Show();
            }

            btnPrint.Click += BtnPrint_Click;
            chkEmbryoDev20.CheckedChanged += ChkEmbryoDev20_CheckedChanged;
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
                setOPUReport();
                //frm.setOPUReport(dt);
            }
            else if (opureport == opuReport.OPUEmbryoDevReport)
            {
                setEmbryoDev();
            }
            
        }
        private void setOPUReport()
        {
            FrmReport frm = new FrmReport(ic);
            DataTable dt = new DataTable();
            DataTable dtdev1 = new DataTable();
            DataTable dtdev2 = new DataTable();
            if (!chkEmbryoDev20.Checked && cboEmbryoDev2.Text.Equals(""))
            {
                MessageBox.Show("กรุณา เลือก Day 2", "");
                return;
            }
            dt = ic.ivfDB.opuDB.selectByPrintOPU(txtID.Text);
            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("No Data"+dt.Rows.Count, "");
                return;
            }
            if (cboEmbryoDev1.Text.Equals("2"))
            {
                dtdev1 = ic.ivfDB.opuEmDevDB.selectByOpuFetId_Day(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day2);
            }
            else if (cboEmbryoDev1.Text.Equals("3"))
            {
                dtdev1 = ic.ivfDB.opuEmDevDB.selectByOpuFetId_Day(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day3);
            }
            else if (cboEmbryoDev1.Text.Equals("5"))
            {
                dtdev1 = ic.ivfDB.opuEmDevDB.selectByOpuFetId_Day(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day5);
            }
            else if (cboEmbryoDev1.Text.Equals("6"))
            {
                dtdev1 = ic.ivfDB.opuEmDevDB.selectByOpuFetId_Day(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day6);
            }
            if (!chkEmbryoDev20.Checked && !cboEmbryoDev2.Text.Equals(""))
            {
                if (cboEmbryoDev2.Text.Equals("2"))
                {
                    dtdev2 = ic.ivfDB.opuEmDevDB.selectByOpuFetId_Day(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day2);
                }
                else if (cboEmbryoDev2.Text.Equals("3"))
                {
                    dtdev2 = ic.ivfDB.opuEmDevDB.selectByOpuFetId_Day(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day3);
                }
                else if (cboEmbryoDev2.Text.Equals("5"))
                {
                    dtdev2 = ic.ivfDB.opuEmDevDB.selectByOpuFetId_Day(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day5);
                }
                else if (cboEmbryoDev2.Text.Equals("6"))
                {
                    dtdev2 = ic.ivfDB.opuEmDevDB.selectByOpuFetId_Day(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day6);
                }
            }
            for (int i = 1; i <= 40; i++)
            {
                String col = "";
                col = "embryo_dev_0_" + i.ToString("00");
                dt.Columns.Add(col, typeof(String));
                col = "embryo_dev_1_" + i.ToString("00");
                dt.Columns.Add(col, typeof(String));
            }
            int j = 1;
            String col11 = "embryo_dev_1_name";
            dt.Columns.Add(col11, typeof(String));
            col11 = "embryo_dev_0_name";
            dt.Columns.Add(col11, typeof(String));
            dt.Columns.Add("embryo_dev_0_date", typeof(String));
            dt.Columns.Add("embryo_dev_1_date", typeof(String));
            dt.Columns.Add("embryo_dev_0_staff_name", typeof(String));
            dt.Columns.Add("embryo_dev_1_staff_name", typeof(String));
            dt.Columns.Add("embryo_dev_0_checked_name", typeof(String));
            dt.Columns.Add("embryo_dev_1_checked_name", typeof(String));

            if (!cboEmbryoDev1.Text.Equals("") && dt.Rows.Count > 0)
            {
                dt.Rows[0]["embryo_dev_0_name"] = "Embryo Development (Day " + cboEmbryoDev1.Text + ")";
            }
            if (!cboEmbryoDev2.Text.Equals("") && dt.Rows.Count > 0)
            {
                dt.Rows[0]["embryo_dev_1_name"] = "Embryo Development (Day " + cboEmbryoDev2.Text + ")";
            }
            String stfid = "", checkedid = "", embryodevdate = "", etName="";
            foreach (DataRow row in dtdev1.Rows)
            {
                if (j > 40) continue;
                if (row["desc0"].ToString().Equals("")) continue;
                String col = "embryo_dev_0_", vol = "";
                stfid = ""; checkedid = ""; embryodevdate = "";
                vol = "0" + row["opu_embryo_dev_no"].ToString();
                vol = vol.Substring(vol.Length - 2);
                col = col + vol;
                dt.Rows[0][col] = j+". "+row["desc0"].ToString()+" " + row["desc1"].ToString();
                stfid = row["staff_id"].ToString();
                checkedid = row["checked_id"].ToString();
                embryodevdate = row["embryo_dev_date"].ToString();
                j++;
            }
            dt.Rows[0]["embryo_dev_0_staff_name"] = ic.ivfDB.stfDB.getStaffNameBylStf(stfid);
            dt.Rows[0]["embryo_dev_0_checked_name"] = ic.ivfDB.stfDB.getStaffNameBylStf(checkedid);
            etName = dt.Rows[0]["embryo_for_et_embryologist_id"].ToString();
            dt.Columns.Remove("embryo_for_et_embryologist_id");
            dt.Columns.Add("embryo_for_et_embryologist_id", typeof(String));
            dt.Rows[0]["embryo_for_et_embryologist_id"] = ic.ivfDB.stfDB.getStaffNameBylStf(etName);
            //dt.Rows[0]["embryo_dev_0_date"] = ic.datetimetoShow(embryodevdate);
            dt.Rows[0]["embryo_dev_0_date"] = ic.datetoShow(embryodevdate).Replace("-", "/");
            j = 1;
            if (!chkEmbryoDev20.Checked && dtdev2.Rows.Count > 0)
            {
                foreach (DataRow row in dtdev2.Rows)
                {
                    if (j > 40) continue;
                    if (row["desc0"].ToString().Equals("")) continue;
                    String col = "embryo_dev_1_", vol = "";
                    stfid = ""; checkedid = ""; embryodevdate = "";
                    vol = "0" + row["opu_embryo_dev_no"].ToString();
                    vol = vol.Substring(vol.Length - 2);
                    col = col + vol;
                    dt.Rows[0][col] = j + ". " + row["desc0"].ToString();
                    stfid = row["staff_id"].ToString();
                    checkedid = row["checked_id"].ToString();
                    embryodevdate = row["embryo_dev_date"].ToString();
                    j++;
                }
            }
            dt.Rows[0]["embryo_dev_1_staff_name"] = ic.ivfDB.stfDB.getStaffNameBylStf(stfid);
            dt.Rows[0]["embryo_dev_1_checked_name"] = ic.ivfDB.stfDB.getStaffNameBylStf(checkedid);
            dt.Rows[0]["embryo_dev_1_date"] = ic.datetoShow(embryodevdate).Replace("-", "/");
            String date1 = "";
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.opuDB.opu.dob_female].ToString());
            dt.Rows[0][ic.ivfDB.opuDB.opu.dob_female] = date1.Replace("-","/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.opuDB.opu.dob_male].ToString());
            dt.Rows[0][ic.ivfDB.opuDB.opu.dob_male] = date1.Replace("-", "/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.opuDB.opu.matura_date].ToString());
            dt.Rows[0][ic.ivfDB.opuDB.opu.matura_date] = date1.Replace("-", "/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.opuDB.opu.fertili_date].ToString());
            dt.Rows[0][ic.ivfDB.opuDB.opu.fertili_date] = date1.Replace("-", "/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.opuDB.opu.embryo_for_et_date].ToString());
            dt.Rows[0][ic.ivfDB.opuDB.opu.embryo_for_et_date] = date1.Replace("-", "/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.opuDB.opu.embryo_freez_date_2].ToString());
            dt.Rows[0][ic.ivfDB.opuDB.opu.embryo_freez_date_2] = date1.Replace("-", "/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.opuDB.opu.embryo_freez_date_3].ToString());
            dt.Rows[0][ic.ivfDB.opuDB.opu.embryo_freez_date_3] = date1.Replace("-", "/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.opuDB.opu.embryo_freez_date_5].ToString());
            dt.Rows[0][ic.ivfDB.opuDB.opu.embryo_freez_date_5] = date1.Replace("-", "/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.opuDB.opu.embryo_freez_date_6].ToString());
            dt.Rows[0][ic.ivfDB.opuDB.opu.embryo_freez_date_6] = date1.Replace("-", "/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.opuDB.opu.embryo_freez_date_0].ToString());
            dt.Rows[0][ic.ivfDB.opuDB.opu.embryo_freez_date_0] = date1.Replace("-", "/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.opuDB.opu.embryo_freez_date_1].ToString());
            dt.Rows[0][ic.ivfDB.opuDB.opu.embryo_freez_date_1] = date1.Replace("-", "/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.opuDB.opu.date_pic_embryo].ToString());
            dt.Rows[0][ic.ivfDB.opuDB.opu.opu_date] = date1.Replace("-", "/");
            date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.opuDB.opu.sperm_date].ToString());
            dt.Rows[0][ic.ivfDB.opuDB.opu.sperm_date] = date1.Replace("-", "/");

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
            frm.ShowDialog(this);
        }
        private void setEmbryoDev()
        {
            FrmReport frm = new FrmReport(ic);
            DataTable dt = new DataTable();
            FrmWaiting frmW = new FrmWaiting();
            frmW.Show();
            try
            {
                int i = 0;
                String day = "";
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
                                String no = "", filename1 = "";
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
                            //}
                        }
                        i++;
                        frmW.pB.Value = i;
                    }
                }
                String date1 = "";
                date1 = ic.datetoShow(dt.Rows[0][ic.ivfDB.opuDB.opu.opu_date].ToString());
                dt.Rows[0][ic.ivfDB.opuDB.opu.opu_date] = date1.Replace("-", "/");
                frm.setOPUEmbryoDevReport(dt);

            }
            catch (Exception ex)
            {
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
            opu = ic.ivfDB.opuDB.selectByPk1(opuId);
            txtID.Value = opu.opu_id;
            txtHnFeMale.Value = opu.hn_female;
            txtHnMale.Value = opu.hn_male;
            txtNameFeMale.Value = opu.name_female;
            txtNameMale.Value = opu.name_male;
            txtOpuCode.Value = opu.opu_code;
        }
        private void FrmLabOPUPrint_Load(object sender, EventArgs e)
        {

        }
    }
}
