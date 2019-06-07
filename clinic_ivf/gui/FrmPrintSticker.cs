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
    public partial class FrmPrintSticker : Form
    {
        IvfControl ic;
        public FrmPrintSticker(IvfControl ic)
        {
            InitializeComponent();
            initConfig();
        }
        private void initConfig()
        {
            btnOk.Click += BtnOk_Click;
            txtNumSticker.KeyPress += TxtNumSticker_KeyPress;
        }

        private void TxtNumSticker_KeyPress(object sender, KeyPressEventArgs e)
        {
            //throw new NotImplementedException();
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ic.NumSticker = txtNumSticker.Text;
            Close();
        }

        private void FrmPrintSticker_Load(object sender, EventArgs e)
        {

        }
    }
}
