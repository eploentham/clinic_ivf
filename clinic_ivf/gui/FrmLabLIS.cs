using clinic_ivf.control;
using clinic_ivf.object1;
using clinic_ivf.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf.gui
{
    public partial class FrmLabLIS : Form
    {
        IvfControl ic;
        NotifyIcon notifyIcon1;

        SerialPort ComPort = new SerialPort();
        internal delegate void SerialDataReceivedEventHandlerDelegate(object sender, SerialDataReceivedEventArgs e);
        internal delegate void SerialPinChangedEventHandlerDelegate(object sender, SerialPinChangedEventArgs e);
        private SerialPinChangedEventHandler SerialPinChangedEventHandler1;
        delegate void SetTextCallback(string text);
        string InputData = String.Empty;
        public FrmLabLIS()
        {
            InitializeComponent();
            //MessageBox.Show("FrmLabLIS 11111", "");
            initConfig();
            // https://www.codeproject.com/Articles/678025/Serial-Comms-in-Csharp-for-Beginners
        }
        private void initConfig()
        {
            try
            {
                this.StartPosition = FormStartPosition.CenterScreen;
                //MessageBox.Show("FriendlyName " + System.AppDomain.CurrentDomain.FriendlyName, "");
                notifyIcon1 = new NotifyIcon();
                notifyIcon1.Icon = Resources.ivf_lis;
                notifyIcon1.BalloonTipText = "";
                notifyIcon1.BalloonTipTitle = "LIS";
                notifyIcon1.Visible = true;
                ic.setCboPORT(cboPORT);
                ic.setCboBAUDRATE(cboBAUDRATE);
                ic.setCboDATABIT(cboDATABIT);
                ic.setCboStopBIT(cboSTOPBIT);
                ic.setCboParity(cboParity);
                ic.setCboHandShaking(cboHandshake);

                //SerialPinChangedEventHandler1 = new SerialPinChangedEventHandler(PinChanged);
                ComPort.DataReceived += ComPort_DataReceived;

                this.Resize += FrmLabLIS_Resize;
                //MessageBox.Show("33333", "");
                menuShow.Click += MenuShow_Click;
                notifyIcon1.MouseDoubleClick += NotifyIcon1_MouseDoubleClick;
                this.FormClosing += FrmLabLIS_FormClosing;
                BtnConnect.Click += BtnConnect_Click;
                //MessageBox.Show("2222", "");
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.Message, "");
            }
        }

        private void ComPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //throw new NotImplementedException();

        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //SerialPort port = new SerialPort()
        }

        private void FrmLabLIS_FormClosing(object sender, FormClosingEventArgs e)
        {
            //throw new NotImplementedException();
            if(MessageBox.Show("","", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.OK)
            {
                return;
            }
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
            try
            {
                //MessageBox.Show("1111", "");
                this.Show();
                //MessageBox.Show("2222", "");
                this.WindowState = FormWindowState.Normal;
                //MessageBox.Show("3333", "");
                this.StartPosition = FormStartPosition.CenterScreen;
                //MessageBox.Show("4444", "");
            }
            catch(Exception ex)
            {
                MessageBox.Show("error "+ex.Message, "");
            }
        }

        private void MenuShow_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //this.WindowState = FormWindowState.Normal;
            //this.Show();
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

        private void FrmLabLIS_Load(object sender, EventArgs e)
        {
            //new LogWriter("n", "Form1 Load");
            //notifyIcon1.Visible = true;
            //notifyIcon1.BalloonTipText = "notifyIcon1";
            //notifyIcon1.ShowBalloonTip(2000, "Start IVF LIS", "", ToolTipIcon.Info);
            //_ = this.WindowState == FormWindowState.Minimized;
        }
    }
}
