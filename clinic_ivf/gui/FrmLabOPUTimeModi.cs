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
    public partial class FrmLabOPUTimeModi : Form
    {
        IvfControl ic;
        String lformaId = "", reqid="";
        LabFormA lFormA;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;

        public FrmLabOPUTimeModi(IvfControl ic, String reqid, String lformaId)
        {
            InitializeComponent();
            this.ic = ic;
            this.reqid = reqid;
            this.lformaId = lformaId;
            initConfig();
        }
        private void initConfig()
        {
            lFormA = new LabFormA();
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            btnSave.Click += BtnSave_Click;
            setControl();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.cStf.staff_id = "";
            Boolean chkSave = false;
            FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
            frm.ShowDialog(this);
            if (!ic.cStf.staff_id.Equals(""))
            {
                String re = "";
                re = ic.ivfDB.lFormaDB.updateStatusOPUtimeModiAccept(txtID.Text);
                long chk = 0;
                if (long.TryParse(re, out chk))
                {
                    Close();
                }
            }
        }

        private void setControl()
        {
            //lFormA = ic.ivfDB.lFormaDB.selectByPk1(lformaId);
            lFormA = ic.ivfDB.lFormaDB.selectBReqOPU(lformaId);
            txtID.Value = lFormA.form_a_id;
            txtLabFormACode.Value = lFormA.form_a_code;
            txtHnFeMale.Value = lFormA.hn_female;
            txtNameFeMale.Value = lFormA.name_female;
            txtNameMale.Value = lFormA.name_male;
            txtHnMale.Value = lFormA.hn_male;
            txtOPUDate.Value = lFormA.opu_date;
            txtOPUTime.Value = lFormA.opu_time;
            txtOPUTimeModi.Value = lFormA.opu_time_modi;

        }
        private void FrmMabOPUTimeModi_Load(object sender, EventArgs e)
        {

        }
    }
}
