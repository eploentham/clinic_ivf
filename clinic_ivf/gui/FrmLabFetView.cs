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
    public partial class FrmLabFetView : Form
    {
        IvfControl ic;
        MainMenu menu;

        public FrmLabFetView(IvfControl ic, MainMenu m)
        {
            InitializeComponent();
            this.ic = ic;
            menu = m;

            btnNew.Click += BtnNew_Click;
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmLabFetAdd frm = new FrmLabFetAdd(ic);
            String txt = "ป้อน LAB FET ใหม่";

            frm.FormBorderStyle = FormBorderStyle.None;
            menu.AddNewTab(frm, txt);
        }

        private void FrmLabFetView_Load(object sender, EventArgs e)
        {
            
        }
    }
}
