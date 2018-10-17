using C1.Win.C1SuperTooltip;
using C1.Win.C1Themes;
using clinic_ivf.control;
using clinic_ivf.object1;
using clinic_ivf.Properties;
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
    public partial class FrmLabReqAdd : Form
    {
        IvfControl ic;
        LabRequest lbReq;

        //C1ThemeController theme1;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;

        public FrmLabReqAdd(IvfControl ic)
        {
            InitializeComponent();
            this.ic = ic;
            initConfig();
        }
        private void initConfig()
        {
            theme1 = new C1.Win.C1Themes.C1ThemeController();
            theme1.Theme = "Office2013Red";
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();

            lbReq = new LabRequest();

            txtReqDate.Value = System.DateTime.Now.Year+"-" + System.DateTime.Now.ToString("MM-dd HH:mm:ss");
            btnReq.Image = Resources.Ticket_24;

            ic.ivfDB.itmDB.setCboItem(cboLabReq,"");
            btnSearch.Click += BtnSearch_Click;
            btnReq.Click += BtnReq_Click;
        }
        private void setLabRequest()
        {
            lbReq.req_id = txtID.Text;
            lbReq.req_code = ic.ivfDB.copDB.genReqDoc();
            lbReq.req_date = ic.datetoDB(txtReqDate.Text);
            lbReq.hn_male = "";
            lbReq.name_male = "";
            lbReq.hn_female = txtHn.Text;
            lbReq.name_female = txtName.Text;
            lbReq.status_req = "1";
            lbReq.accept_date = "";
            lbReq.start_date = "";
            lbReq.result_date = "";
            lbReq.visit_id = "";
            lbReq.vn = txtVn.Text;
            lbReq.active = "1";
            lbReq.remark = txtRemark.Text;
            lbReq.date_create = "";
            lbReq.date_modi = "";
            lbReq.date_cancel = "";
            lbReq.user_create = "";
            lbReq.user_modi = "";
            lbReq.user_cancel = "";
            lbReq.item_id = cboLabReq.SelectedItem != null ? ((ComboBoxItem)(cboLabReq.SelectedItem)).Value : "";
            lbReq.doctor_id = cboDoctor.SelectedItem != null ? ((ComboBoxItem)(cboDoctor.SelectedItem)).Value : "";
        }
        private void BtnReq_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (btnReq.Text.Equals("Confirm Request"))
            {
                stt.Hide();
                setLabRequest();
                String re = ic.ivfDB.lbReqDB.insertLabRequest(lbReq, ic.user.staff_id);
                int chk = 0;
                if (int.TryParse(re, out chk))
                {
                    btnReq.Image = Resources.accept_database24;
                    System.Threading.Thread.Sleep(2000);
                    this.Dispose();
                }
            }
            else
            {
                ic.cStf.staff_id = "";
                FrmPasswordConfirm frm = new FrmPasswordConfirm(ic);
                frm.ShowDialog(this);
                if (!ic.cStf.staff_id.Equals(""))
                {
                    txtUserReq.Value = ic.cStf.staff_fname_t + " " + ic.cStf.staff_lname_t;
                    txtStfConfirmID.Value = ic.cStf.staff_id;
                    btnReq.Text = "Confirm Request";
                    btnReq.Image = Resources.Add_ticket_24;
                    stt.Show("<p><b>สวัสดี</b></p>คุณ " + ic.cStf.staff_fname_t + " " + ic.cStf.staff_lname_t + "<br> กรุณายินยันการ confirm อีกครั้ง", btnReq);
                }
                else
                {
                    btnReq.Text = "Request";
                    btnReq.Image = Resources.Ticket_24;
                }
            }
            
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmSearchHn frm = new FrmSearchHn(ic);
            frm.ShowDialog(this);
            txtHn.Value = ic.sVsOld.PIDS;
            txtName.Value = ic.sVsOld.PName;
            txtVn.Value = ic.sVsOld.VN;
        }

        private void FrmLabReqAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
