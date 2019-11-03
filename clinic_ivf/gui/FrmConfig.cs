using clinic_ivf.control;
using Microsoft.Win32;
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
    public partial class FrmConfig : Form
    {
        IvfControl ic;
        MainMenu menu;
        public FrmConfig(IvfControl ic, MainMenu m)
        {
            InitializeComponent();
            this.ic = ic;
            menu = m;
            initConfig();
        }
        public FrmConfig(IvfControl ic)
        {
            InitializeComponent();
            this.ic = ic;
            initConfig();
        }
        private void initConfig()
        {
            btnLabLis.Click += BtnLabLis_Click;
        }

        private void BtnLabLis_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String path = "";
            RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            reg.SetValue("IVF LIS", Application.ExecutablePath.ToString()+" -m lis");
        }

        private void FrmConfig_Load(object sender, EventArgs e)
        {

        }
    }
}
