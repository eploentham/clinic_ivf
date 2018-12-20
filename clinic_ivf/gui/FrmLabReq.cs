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
    public partial class FrmLabReq : Form
    {
        IvfControl ic;

        public FrmLabReq(IvfControl ic)
        {
            InitializeComponent();
            this.ic = ic;
        }

        private void FrmLabOPUReq_Load(object sender, EventArgs e)
        {

        }
    }
}
