using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_ivf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            c1TextBox3.KeyUp += C1TextBox3_KeyUp;
        }

        private void C1TextBox3_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.Enter)
            {
                c1BarCode1.Text = c1TextBox3.Text;
                Image img = c1BarCode1.Image;
                img.Save("barcode.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
