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
using System.Runtime.InteropServices;
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

        Boolean statusOpenPort = false;

        
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
                ic.setCboPrinter(cboPrinter);
                //SerialPinChangedEventHandler1 = new SerialPinChangedEventHandler(PinChanged);
                ComPort.DataReceived += ComPort_DataReceived;

                this.Resize += FrmLabLIS_Resize;
                //MessageBox.Show("33333", "");
                menuShow.Click += MenuShow_Click;
                notifyIcon1.MouseDoubleClick += NotifyIcon1_MouseDoubleClick;
                this.FormClosing += FrmLabLIS_FormClosing;
                BtnConnect.Click += BtnConnect_Click;
                btnPrnSticker.Click += BtnPrnSticker_Click;
                //MessageBox.Show("2222", "");
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.Message, "");
            }
        }

        private void BtnPrnSticker_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            string WT1 = txtName.Text.Trim();
            string B1 = txtBarcode.Text.Trim();
            byte[] result_unicode = System.Text.Encoding.GetEncoding("utf-16").GetBytes("unicode test");
            byte[] result_utf8 = System.Text.Encoding.UTF8.GetBytes("TEXT 40,620,\"ARIAL.TTF\",0,12,12,\"utf8 test Wörter auf Deutsch\"");

            //TSCLIB_DLL.about();
            byte status = TSCLIB_DLL.usbportqueryprinter();//0 = idle, 1 = head open, 16 = pause, following <ESC>!? command of TSPL manual
            TSCLIB_DLL.openport("TSC TE210");
            TSCLIB_DLL.sendcommand("SIZE 100 mm, 120 mm");
            TSCLIB_DLL.sendcommand("SPEED 4");
            TSCLIB_DLL.sendcommand("DENSITY 12");
            TSCLIB_DLL.sendcommand("DIRECTION 1");
            TSCLIB_DLL.sendcommand("SET TEAR ON");
            TSCLIB_DLL.sendcommand("CODEPAGE UTF-8");
            TSCLIB_DLL.clearbuffer();
            //TSCLIB_DLL.downloadpcx("UL.PCX", "UL.PCX");
            TSCLIB_DLL.windowsfont(40, 490, 48, 0, 0, 0, "Arial", "Windows Font Test");
            TSCLIB_DLL.windowsfontUnicode(40, 550, 48, 0, 0, 0, "Arial", result_unicode);
            //TSCLIB_DLL.sendcommand("PUTPCX 40,40,\"UL.PCX\"");
            TSCLIB_DLL.sendBinaryData(result_utf8, result_utf8.Length);
            TSCLIB_DLL.barcode("40", "300", "128", "80", "1", "0", "2", "2", B1);
            TSCLIB_DLL.printerfont("40", "250", "0", "0", "15", "15", WT1);
            TSCLIB_DLL.printlabel("1", "1");
            TSCLIB_DLL.closeport();
        }

        private void ComPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //throw new NotImplementedException();
            InputData = ComPort.ReadExisting();
            if (InputData != String.Empty)
            {
                this.BeginInvoke(new SetTextCallback(SetText), new object[] { InputData });
            }
        }
        private void SetText(string text)
        {
            this.rtbIncoming.Text += text;
        }
        private void BtnConnect_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //SerialPort port = new SerialPort()
            if (statusOpenPort)
            {
                if (ComPort.IsOpen)
                {
                    ComPort.Close();
                }
                statusOpenPort = false;
                BtnConnect.Text = "DisConnect";
            }
            else
            {
                if (!ComPort.IsOpen)
                {
                    ComPort.PortName = cboPORT.Text;
                    ComPort.BaudRate = Convert.ToInt32(cboBAUDRATE.Text);
                    ComPort.DataBits = Convert.ToInt16(cboDATABIT.Text);
                    ComPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cboSTOPBIT.Text);
                    ComPort.Handshake = (Handshake)Enum.Parse(typeof(Handshake), cboHandshake.Text);
                    ComPort.Parity = (Parity)Enum.Parse(typeof(Parity), cboParity.Text);
                    ComPort.Open();
                    
                    BtnConnect.Text = "Connect";
                }
                else
                {
                    MessageBox.Show("comm port is open", "");
                }
                statusOpenPort = true;
            }
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
