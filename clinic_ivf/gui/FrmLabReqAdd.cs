using clinic_ivf.control;
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

        public FrmLabReqAdd(IvfControl ic)
        {
            InitializeComponent();
            this.ic = ic;
            initConfig();
        }
        private void initConfig()
        {
            txtReqDate.Value = System.DateTime.Now.Year+"-" + System.DateTime.Now.ToString("MM-dd HH:mm:ss");

            btnSearch.Click += BtnSearch_Click;
            btnReq.Click += BtnReq_Click;
        }

        private void BtnReq_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

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
