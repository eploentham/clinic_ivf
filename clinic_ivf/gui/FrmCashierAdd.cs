using C1.Win.C1FlexGrid;
using C1.Win.C1SuperTooltip;
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
    public partial class FrmCashierAdd : Form
    {
        IvfControl ic;
        String billhid = "", pttid = "", vsid = "", vsidOld = "";

        C1FlexGrid grfBillD;

        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        public FrmCashierAdd(IvfControl ic, String billid, String vnold)
        {
            InitializeComponent();
        }

        private void FrmCashierAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
