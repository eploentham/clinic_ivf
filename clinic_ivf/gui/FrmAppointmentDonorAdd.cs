using C1.Win.C1FlexGrid;
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
    public partial class FrmAppointmentDonorAdd : Form
    {
        IvfControl ic;
        C1FlexGrid grfpApmAll, grfpApmVisit, grfpApmDayAll;
        Font fEdit, fEditB;
        Color bg, fc;
        Font ff, ffB;
        PatientAppointment pApm;
        int colId = 1, colAppointment = 2, colDate = 3, colTime = 4, colDoctor = 5, colSp = 6, colNotice=7;

        String pApmId = "";

        public FrmAppointmentDonorAdd(IvfControl ic, String papmId)
        {
            InitializeComponent();
            pApmId = papmId;
            InitConfig();
        }
        private void InitConfig()
        {
            pApm = new PatientAppointment();
            fEdit = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(ic.iniC.grdViewFontName, ic.grdViewFontSize, FontStyle.Bold);

            //theme1.SetTheme(sB, "BeigeOne");
            

            sB1.Text = "";
            bg = txtHn.BackColor;
            fc = txtHn.ForeColor;
            ff = txtHn.Font;

            cboTimepApm = ic.setCboApmTime(cboTimepApm);
            txtDatepApm.Value = System.DateTime.Now.Year.ToString() + "-" + System.DateTime.Now.ToString("MM-dd");

            initGrfpApmAll();
            initGrfpApmVisit();
            initGrfpApmDayAll();
        }
        private void initGrfpApmAll()
        {
            grfpApmAll = new C1FlexGrid();
            grfpApmAll.Font = fEdit;
            grfpApmAll.Dock = System.Windows.Forms.DockStyle.Fill;
            grfpApmAll.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);
            
            //grfpApmAll.ContextMenu = menuGw;
            panel1.Controls.Add(grfpApmAll);

            theme1.SetTheme(grfpApmAll, "Office2016Colorful");

        }
        private void initGrfpApmVisit()
        {
            grfpApmVisit = new C1FlexGrid();
            grfpApmVisit.Font = fEdit;
            grfpApmVisit.Dock = System.Windows.Forms.DockStyle.Fill;
            grfpApmVisit.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            //grfpApmAll.ContextMenu = menuGw;
            pnVisit.Controls.Add(grfpApmVisit);

            theme1.SetTheme(grfpApmVisit, "Office2016Colorful");

        }
        private void initGrfpApmDayAll()
        {
            grfpApmDayAll = new C1FlexGrid();
            grfpApmDayAll.Font = fEdit;
            grfpApmDayAll.Dock = System.Windows.Forms.DockStyle.Fill;
            grfpApmDayAll.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfExpn);

            //grfpApmAll.ContextMenu = menuGw;
            pnDay.Controls.Add(grfpApmDayAll);

            theme1.SetTheme(grfpApmDayAll, "Office2016Colorful");

        }
        private void FrmAppointmentAdd_Load(object sender, EventArgs e)
        {
            //c1Schedule1.sa
        }
    }
}
