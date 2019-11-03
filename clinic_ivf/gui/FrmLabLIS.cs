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
    public partial class FrmLabLIS : Form
    {
        IvfControl ic;
        public FrmLabLIS(IvfControl ic)
        {
            InitializeComponent();
            //MessageBox.Show("11111", "");
            initConfig();
            this.Resize += FrmLabLIS_Resize;
            //MessageBox.Show("33333", "");
            menuShow.Click += MenuShow_Click;
            notifyIcon1.MouseDoubleClick += NotifyIcon1_MouseDoubleClick;
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Show();
        }

        private void NotifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Show();
        }

        private void MenuShow_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.WindowState = FormWindowState.Normal;
            this.Show();
        }

        private void FrmLabLIS_Resize(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.ShowBalloonTip(2000, "system hide", "11", ToolTipIcon.Info);
                this.ShowInTaskbar = true;
            }
        }

        private void initConfig()
        {
            notifyIcon1 = new NotifyIcon();
            //MessageBox.Show("2222", "");
        }

        private void FrmLabLIS_Load(object sender, EventArgs e)
        {
            new LogWriter("n", "Form1 Load");
            notifyIcon1.Visible = true;
            //notifyIcon1.BalloonTipText = "notifyIcon1";
            //notifyIcon1.ShowBalloonTip(2000, "Start IVF LIS", "", ToolTipIcon.Info);
            //_ = this.WindowState == FormWindowState.Minimized;
        }
    }
}
