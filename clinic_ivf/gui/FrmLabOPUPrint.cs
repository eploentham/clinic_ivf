using C1.Win.C1SuperTooltip;
using clinic_ivf.control;
using clinic_ivf.object1;
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

        public FrmLabOPUPrint(IvfControl ic, String opuid)
        {
            InitializeComponent();
            this.ic = ic;
            opuId = opuid;
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

            btnPrint.Click += BtnPrint_Click;
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmReport frm = new FrmReport(ic);
            DataTable dt = new DataTable();
            DataTable dtdev = new DataTable();
            dt = ic.ivfDB.opuDB.selectByPrintOPU(txtID.Text);
            dtdev = ic.ivfDB.opuEmDevDB.selectByOpuFetId_Day(txtID.Text, objdb.LabOpuEmbryoDevDB.Day1.Day2);
            for (int i = 1; i <= 40; i++)
            {
                String col = "";
                col = "embryo_dev_0_"+i.ToString("00");
                dt.Columns.Add(col, typeof(String));
                col = "embryo_dev_1_" + i.ToString("00");
                dt.Columns.Add(col, typeof(String));
            }
            int j = 1;
            foreach(DataRow row in dtdev.Rows)
            {
                String col = "embryo_dev_0_", vol="";
                //col = "embryo_dev_0_" + j.ToString("00");
                vol = "0"+row["opu_embryo_dev_no"].ToString();
                vol = vol.Substring(vol.Length - 2);
                col = col + vol;
                dt.Rows[0][col] = row["desc0"].ToString();
                //if (row["opu_embryo_dev_no"].ToString().Equals(""))
                //{

                //}
                j++;
            }
            frm.setOPUReport(dt);
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
    }
}
