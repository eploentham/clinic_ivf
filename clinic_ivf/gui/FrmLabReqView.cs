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
    public partial class FrmLabReqView : Form
    {
        IvfControl ic;

        public FrmLabReqView(IvfControl ic)
        {
            InitializeComponent();
            this.ic = ic;

            btnNew.Click += BtnNew_Click;
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmLabReqAdd frm = new FrmLabReqAdd(ic);
            frm.ShowDialog(this);

            
            
        }

        private void FrmLabReqView_Load(object sender, EventArgs e)
        {

        }
    }
}
